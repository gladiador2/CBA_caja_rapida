#region using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.EgresosVariosCaja;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.ToolbarFlujo;
using CBA.FlowV2.Services.ListaDePrecio;
using CBA.FlowV2.Services.NotaCreditosProveedores;
#endregion using

namespace CBA.FlowV2.Services.Facturacion
{
    public class FacturasProveedorService : FlujosServiceBaseWorkaround
    {
        #region Clase Webmethods
        private static class Webmethods
        {
            #region Clase FacturaAprobada
            public static class FacturaAprobada
            {
                public static bool Avisar(FACTURAS_PROVEEDORRow factura_proveedor, out string mensaje, SessionService sesion)
                {
                    bool exito = true;
                    mensaje = string.Empty;

                    switch (Convert.ToInt32(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.Cliente)))
                    {
                        case Definiciones.Clientes.Documenta:
                            exito = Cliente_13(factura_proveedor, out mensaje, sesion);
                            break;
                    }

                    return exito;
                }

                #region Cliente_13
                public static bool Cliente_13(FACTURAS_PROVEEDORRow factura_proveedor, out string mensaje, SessionService sesion)
                {
                    decimal parametroId = Definiciones.Error.Valor.EnteroPositivo;

                    try
                    {
                        bool exito = false;
                        mensaje = string.Empty;

                        DataTable dtDetalles = FacturasProveedorDetalleService.GetFacturaProveedorDetalleInfoCompleta(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + factura_proveedor.ID, string.Empty, sesion);
                        if (dtDetalles.Rows.Count <= 0)
                        {
                            mensaje = "La factura no tiene detalles.";
                            return false;
                        }

                        bool contieneArticuloBuscado = false;
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            string articuloCodigo = Interprete.ObtenerString(dtDetalles.Rows[i][FacturasProveedorDetalleService.VistaArticuloCodigo_NombreCol]);
                            if (articuloCodigo == "001" || articuloCodigo == "002")
                            {
                                contieneArticuloBuscado = true;
                                break;
                            }
                        }
                        if (!contieneArticuloBuscado)
                            return true;

                        ProveedoresService proveedor = new ProveedoresService(factura_proveedor.PROVEEDOR_ID, sesion);
                        SucursalesService sucursal = new SucursalesService(factura_proveedor.SUCURSAL_ID, sesion);

                        var valores = new Hashtable
                        {
                             { "sucursal", sucursal.Nombre },
                             { "recaudador", int.Parse(proveedor.Codigo) },
                             { "monto", (int)factura_proveedor.TOTAL_PAGO },
                             { "nroFactura", factura_proveedor.NRO_COMPROBANTE },
                             { "timbrado", factura_proveedor.NRO_TIMBRADO },
                             { "fechaFactura", factura_proveedor.FECHA_FACTURA.ToShortDateString() },
                             { "vencimientoTimbrado", factura_proveedor.FECHA_VENCIMIENTO_TIMBRADO.ToShortDateString() },
                             { "fechaPeriodo", factura_proveedor.IsFECHA_FACTURANull ? DateTime.Now.ToShortDateString() :  factura_proveedor.FECHA_RECEPCION.ToShortDateString() },
                             { "usuario", sesion.Usuario_Nombre },
                        };

                        string valoresJson = JsonUtil.Serializar(valores);

                        parametroId = WebservicesParametrosService.Guardar(
                                                         Definiciones.Error.Valor.EnteroPositivo,
                                                         "webresources/bills/insertbill",
                                                         valoresJson,
                                                         string.Empty,
                                                         true);

                        byte[] dataStream = Encoding.UTF8.GetBytes(valoresJson);

                        WebRequest req = WebRequest.Create("http://ws.documenta.com.py:8099/VistasRest/webresources/bills/insertbill");
                        req.Method = "POST";
                        req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("cbaflow:cbaflow"));
                        req.ContentType = "application/x-www-form-urlencoded";
                        req.ContentLength = valoresJson.Length;

                        Stream newStream = req.GetRequestStream();
                        newStream.Write(dataStream, 0, dataStream.Length);
                        newStream.Close();

                        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                        StreamReader readStream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                        string respuesta = readStream.ReadToEnd();
                        Dictionary<string, object> resultado = JsonUtil.Deserializar<Dictionary<string, object>>(respuesta);
                        resp.Close();
                        readStream.Close();

                        if (resultado == null)
                            throw new Exception("Hubo un error en la respuesta a " + req.RequestUri.ToString());

                        WebservicesParametrosService.GuardarRespuesta(parametroId, respuesta);

                        mensaje = resultado["mensaje"].ToString();
                        switch (resultado["estado"].ToString())
                        {
                            case "1":
                                exito = true;
                                break;
                            case "2":
                                exito = true;
                                break;
                            case "5":
                                exito = false;
                                break;
                            default: throw new Exception("FacturaAprobada. Código de respuesta no implementado.");
                        }

                        if (exito)
                        {
                            factura_proveedor.NUMERO_CONTRATO = resultado["idFacturacion"].ToString();
                            factura_proveedor.NRO_DOCUMENTO_EXTERNO = resultado["periodo"].ToString();
                        }

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
            #endregion Clase FacturaAprobada

            #region Clase FacturaDesaprobada
            public static class FacturaDesaprobada
            {
                public static bool Avisar(FACTURAS_PROVEEDORRow factura_proveedor, out string mensaje, SessionService sesion)
                {
                    bool exito = true;
                    mensaje = string.Empty;

                    switch (Convert.ToInt32(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.Cliente)))
                    {
                        case Definiciones.Clientes.Documenta:
                            exito = Cliente_13(factura_proveedor, out mensaje, sesion);
                            break;
                    }

                    return exito;
                }

                #region Cliente_13
                public static bool Cliente_13(FACTURAS_PROVEEDORRow factura_proveedor, out string mensaje, SessionService sesion)
                {
                    decimal parametroId = Definiciones.Error.Valor.EnteroPositivo;

                    try
                    {
                        bool exito = false;
                        mensaje = string.Empty;

                        DataTable dtDetalles = FacturasProveedorDetalleService.GetFacturaProveedorDetalleInfoCompleta(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + factura_proveedor.ID, string.Empty, sesion);
                        
                        bool contieneArticuloBuscado = false;
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            string articuloCodigo = Interprete.ObtenerString(dtDetalles.Rows[i][FacturasProveedorDetalleService.VistaArticuloCodigo_NombreCol]);
                            if (articuloCodigo == "001" || articuloCodigo == "002")
                            {
                                contieneArticuloBuscado = true;
                                break;
                            }
                        }
                        if (!contieneArticuloBuscado)
                            return true;

                        ProveedoresService proveedor = new ProveedoresService(factura_proveedor.PROVEEDOR_ID, sesion);

                        var valores = new Hashtable
                        {
                             { "recaudador", int.Parse(proveedor.Codigo) },
                             { "nroFactura", factura_proveedor.NRO_COMPROBANTE },
                             { "fechaPeriodo", factura_proveedor.IsFECHA_FACTURANull ? DateTime.Now.ToShortDateString() :  factura_proveedor.FECHA_RECEPCION.ToShortDateString() },
                        };

                        string valoresJson = JsonUtil.Serializar(valores);

                        parametroId = WebservicesParametrosService.Guardar(
                                                         Definiciones.Error.Valor.EnteroPositivo,
                                                         "webresources/bills/deletebill",
                                                         valoresJson,
                                                         string.Empty,
                                                         true);

                        byte[] dataStream = Encoding.UTF8.GetBytes(valoresJson);

                        WebRequest req = WebRequest.Create("http://ws.documenta.com.py:8099/VistasRest/webresources/bills/deletebill");
                        req.Method = "POST";
                        req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("cbaflow:cbaflow"));
                        req.ContentType = "application/x-www-form-urlencoded";
                        req.ContentLength = valoresJson.Length;

                        Stream newStream = req.GetRequestStream();
                        newStream.Write(dataStream, 0, dataStream.Length);
                        newStream.Close();

                        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                        StreamReader readStream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                        string respuesta = readStream.ReadToEnd();
                        Dictionary<string, object> resultado = JsonUtil.Deserializar<Dictionary<string, object>>(respuesta);
                        resp.Close();
                        readStream.Close();

                        if (resultado == null)
                            throw new Exception("Hubo un error en la respuesta a " + req.RequestUri.ToString());

                        WebservicesParametrosService.GuardarRespuesta(parametroId, respuesta);

                        mensaje = resultado["mensaje"].ToString();
                        switch (resultado["estado"].ToString())
                        {
                            case "1":
                                exito = true;
                                break;
                            case "5":
                                exito = false;
                                break;
                            default: throw new Exception("FacturaDesaprobada. Código de respuesta no implementado.");
                        }

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
            #endregion Clase FacturaDesaprobada
        }
        #endregion Clase Webmethods

        #region Sub clase propiedades cabecera
        [Serializable]
        public class PropiedadesCabecera
        {
            public decimal TipoFacturaId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal ProveedorId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal SucursalId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal DepositoId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal FuncionarioId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal CondicionPagoId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal CasoAsociadoId = Definiciones.Error.Valor.EnteroPositivo;
            public string FechaPedido_yyyymmdd = DateTime.MinValue.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            public string FechaFactura_yyyymmdd = DateTime.MinValue.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            public string FechaVencimientoTimbrado_yyyymmdd = DateTime.MinValue.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            public bool UsarFechaFactura = false;
            public string FechaEntrega_yyyymmdd = DateTime.MinValue.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            public bool UsarFechaEntrega = false;
            public decimal MonedaId = Definiciones.Error.Valor.EnteroPositivo;
            public string NroTimbrado = string.Empty;
            public string NroComprobante = string.Empty;
            public string NroDocumentoExterno = string.Empty;
            public string NroContrato = string.Empty;
            public string Observaciones = string.Empty;
            public decimal TipoEmbarqueId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal ImportacionId = Definiciones.Error.Valor.EnteroPositivo;
            public bool PagarPorFondoFijo = false;
            public decimal CtacteFondoFijoId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal PorcentajeDescuento = 0;
            public bool PasibleRetencion = true;
            public bool AfectaCtacteProveedor = true;
            public bool AfectarCtactePersona = false;
            public bool AfectarCreditoFiscalEmpresa = true;
            public bool AfectarCreditoFiscalPersona = false;
            public bool CentroCostoObligatorio = false;
        }
        #endregion Sub clase propiedades cabecera

        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.FACTURACION_PROVEEDOR;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var cabecera = (FacturasProveedorService)caso_cabecera;
            var detalle = (FacturasProveedorDetalleService)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);

            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, cabecera.StockDepositoId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, detalle.ArticuloId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, detalle.TextoPredefinidoId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, detalle.ActivoId);

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
                CasosService caso = new CasosService(caso_id, sesion);
                FACTURAS_PROVEEDORRow cabeceraRow = sesion.Db.FACTURAS_PROVEEDORCollection.GetByCASO_ID(caso_id)[0];
                DataTable dtDetalles = FacturasProveedorDetalleService.GetFacturaProveedorDetalleDataTable(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + cabeceraRow.ID, FacturasProveedorDetalleService.Id_NombreCol, sesion);

                #region Borrador a Anulado
                //Borrador a Anulado
                if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    exito = true;
                    revisarRequisitos = true;
                    DesvincularCasosCreditos(cabeceraRow.CASO_ID, sesion);
                }
                #endregion Borrador a Anulado

                #region Pendiente a Anulado
                //Pendiente a anulado
                else if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    exito = true;
                    revisarRequisitos = true;
                    DesvincularCasosCreditos(cabeceraRow.CASO_ID, sesion);
                }
                #endregion Pendiente a Anulado

                #region Borrador a Pendiente
                //Borrador a Pendiente
                else if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    exito = true;
                    revisarRequisitos = true;

                    if (dtDetalles.Rows.Count <= 0)
                    {
                        mensaje = "La factura no tiene detalles.";
                        exito = false;
                    }

                    #region control fecha timbrado
                    if (exito)
                    {
                        if (cabeceraRow.ES_TICKET == Definiciones.SiNo.No && cabeceraRow.FECHA_FACTURA.Date > cabeceraRow.FECHA_VENCIMIENTO_TIMBRADO.Date && cabeceraRow.FECHA_VENCIMIENTO_TIMBRADO.Date > DateTime.Parse("01/01/1753"))
                        {
                            //si la fecha del timbrado del proveedor no es ticket y
                            //si la fecha de la factura es mayor a la fecha de vcto del timbrado y
                            //si la fecha de vcto del timbrado es distinto a 01/01/1753.
                            //se controla este ultimo porque cuando el timbrado del proveedor no tiene fecha de vcto, por defecto se guarda esta fecha '01/01/1753' en la cabecera de la factura,
                            //entonces, si tiene esta fecha no se tiene que hacer el contrl de vcto de timbrado.
                            mensaje = "El timbrado está vencido.";
                            exito = false;
                        }
                    }
                    #endregion control fecha timbrado

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    #region Actualizar stock y costo
                    string vGeneracionTempranaIngreso = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.GeneracionTempranaIngresoStock, sesion);
                    if (exito && vGeneracionTempranaIngreso == Definiciones.SiNo.Si)
                    {
                        decimal vAfectarstock = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.AfectarStock, sesion);

                        decimal tipoFacturaProveedor = cabeceraRow.TIPO_FACTURA_PROVEEDOR_ID;

                        //para actualizar el stock, no debe de ser creado desde la factura cliente - transferencia de articulo
                        if (cabeceraRow.IsCASO_ASOCIADO_IDNull || !CasosService.GetFlujo(cabeceraRow.CASO_ASOCIADO_ID).Equals(Definiciones.FlujosIDs.FACTURACION_CLIENTE))
                        {
                            if (vAfectarstock == Definiciones.AfectarStock.PorIngresoStock)
                            {
                                #region Crear Caso de Ingreso
                                try
                                {
                                    bool generarIngresoStock = false;
                                    for (int i = 0; i < dtDetalles.Rows.Count && !generarIngresoStock; i++)
                                        generarIngresoStock = (string)dtDetalles.Rows[i][FacturasProveedorDetalleService.AfectaStock_NombreCol] == Definiciones.SiNo.Si;

                                    if (generarIngresoStock)
                                    {
                                        decimal casoResultante = 0;
                                        IngresoStockService.CrearCaso(caso_id, sesion.Usuario.ID, SessionService.GetClienteIP(), out casoResultante, sesion, out  mensaje, CBA.FlowV2.Services.Base.Definiciones.EstadosFlujos.Pendiente);

                                        //En caso que el campo de caso asociado esté libre, asociar el ingreso de stock a la factura de proveedor
                                        if (cabeceraRow.IsCASO_ASOCIADO_IDNull && casoResultante > 0)
                                        {
                                            cabeceraRow.CASO_ASOCIADO_ID = casoResultante;
                                        }
                                    }
                                }
                                catch (Exception exp)
                                {
                                    mensaje = exp.Message.ToString();
                                    exito = false;
                                }
                                #endregion Crear Caso de Ingreso
                            }
                        }
                    }
                    #endregion Actualizar stock y costo
                }
                #endregion Borrador  a Pendiente

                #region Pendiente a Borrador
                else if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    exito = true;
                    revisarRequisitos = false;


                }
                #endregion Pendiente a Borrador

                #region Pendiente a Proforma
                else if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Proforma))
                {
                    exito = true;

                    #region control fecha timbrado
                    if (exito)
                    {
                        if (cabeceraRow.ES_TICKET == Definiciones.SiNo.No && cabeceraRow.FECHA_FACTURA.Date > cabeceraRow.FECHA_VENCIMIENTO_TIMBRADO.Date && cabeceraRow.FECHA_VENCIMIENTO_TIMBRADO.Date > DateTime.Parse("01/01/1753"))
                        {
                            mensaje = "El timbrado está vencido.";
                            exito = false;
                        }
                    }
                    #endregion control fecha timbrado

                    #region control centros de costo
                    if (cabeceraRow.CENTRO_COSTO_OBLIGATORIO == Definiciones.SiNo.Si)
                    {
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            if (!FacturasProveedorDetalleService.GetTieneCentrosCostoManual((decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.Id_NombreCol], sesion))
                                throw new Exception("El detalle número " + i + " debe tener centros de costo asignados en forma manual.");
                        }
                    }
                    #endregion control centros de costo

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    revisarRequisitos = false;
                }
                #endregion Pendiente a Proforma

                #region Proforma a Viajando
                else if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Proforma) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Viajando))
                {
                    exito = true;

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    revisarRequisitos = false;
                }
                #endregion Proforma a Viajando

                #region Viajando a En Revision
                else if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Viajando) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.EnRevision))
                {
                    exito = true;

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    revisarRequisitos = false;
                }
                #endregion Viajando a En Revision

                #region En revision a Aprobado
                //En revision a Aprobado
                else if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.EnRevision) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones
                    //Comprobar existencia de nro de timbrado y nro de comprobante
                    //Si se indicaron las cuentas contables a asentar, controlar que sumen 100%
                    //Aumentar el stock
                    //Aumentar la cuenta corriente del proveedor si corresponde
                    //Aumentar la cuenta corriente de la persona si corresponde
                    exito = true;
                    revisarRequisitos = true;

                    if (!cabeceraRow.IsAUTONUMERACION_IDNull)
                    {
                        //Se debe traer el siguiente numero para completar las validaciones. Aun no se debe actualizar el talonario
                        string nroComprobanteAux = AutonumeracionesService.ConsultarSiguienteNumero(cabeceraRow.AUTONUMERACION_ID, sesion);
                        decimal nroComprobanteNumerico = Definiciones.Error.Valor.EnteroPositivo;

                        if (FacturasProveedorService.GetExisteNroComprobante(cabeceraRow.ID, cabeceraRow.AUTONUMERACION_ID, nroComprobanteAux, sesion))
                            throw new Exception("Ya existe una factura con el mismo número de comprobante.");

                        //Controlar que se logro asignar una numeracion
                        if (nroComprobanteAux.Equals(""))
                        {
                            exito = false;
                            mensaje = "No se pudo asignar una numeración válida";
                        }

                        //Si se pasaron todas las validaciones. Generar comprobante.
                        cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, out nroComprobanteNumerico, sesion);
                    }

                    if (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Equals(string.Empty))
                    {
                        exito = false;
                        mensaje = "Debe indicar el número de comprobante de la factura.";
                    }

                    if ((cabeceraRow.NRO_TIMBRADO == null || cabeceraRow.NRO_TIMBRADO.Equals(string.Empty)) && (cabeceraRow.IsAUTONUMERACION_IDNull))
                    {
                        exito = false;
                        mensaje = "Debe indicar el número de timbrado de la factura.";
                    }

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    if (exito)
                        exito = Webmethods.FacturaAprobada.Avisar(cabeceraRow, out mensaje, sesion);

                    if (exito)
                    {
                        //Controla que los detalles que son articulos del sistema indiquen el lote
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            if (!dtDetalles.Rows[i][FacturasProveedorDetalleService.ArticuloId_NombreCol].Equals(DBNull.Value))
                            {
                                if (dtDetalles.Rows[i][FacturasProveedorDetalleService.LoteId_NombreCol].Equals(DBNull.Value))
                                {
                                    exito = false;
                                    throw new System.ArgumentException("Todo los detalles deben especificar el lote.");
                                }
                            }
                        }
                    }

                    if (exito)
                    {
                        decimal totalPagos = CalendarioPagosFCProveedorService.CalcularTotalPagosPorFactura(cabeceraRow.ID);
                        if (totalPagos != Math.Round(cabeceraRow.TOTAL_PAGO, MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID)))
                        {
                            exito = false;
                            throw new System.ArgumentException("La suma de los Pagos no coinciden con el total de la factura");
                        }
                    }

                    #region comprobar consistencia entre tipo de fc y configuracion
                    if (exito)
                    {
                        //Si la fc no es de pago a terceros, no puede afectar ctacte persona y debe dar credito fiscal a la empresa
                        if (cabeceraRow.TIPO_FACTURA_PROVEEDOR_ID != Definiciones.TipoFacturaProveedor.PagoTerceros)
                        {
                            exito = (cabeceraRow.AFECTA_CTACTE_PROVEEDOR.Equals(Definiciones.SiNo.Si)) &&
                                    (cabeceraRow.AFECTA_CTACTE_PERSONA.Equals(Definiciones.SiNo.No)) &&
                                    (cabeceraRow.AFECTA_CRED_FISCAL_EMPRESA.Equals(Definiciones.SiNo.Si)) &&
                                    (cabeceraRow.AFECTA_CRED_FISCAL_PERSONA.Equals(Definiciones.SiNo.No));

                            if (!exito)
                                throw new System.ArgumentException("Verifique el tipo de factura. Algunos datos no son consistentes");
                        }
                        else
                        {
                            exito = FCProveedorPagosTercPersonasService.PorcentajeTotalValido(cabeceraRow.ID, sesion);

                            if (!exito)
                                throw new System.ArgumentException("El porcentaje del monto asignado a personas no es válido");

                        }
                    }
                    #endregion comprobar consistencia entre tipo de fc y configuracion

                    #region Comprobar distribucion en cuentas contables
                    if (exito)
                    {
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            //Si se indicaron las cuentas contables a asentar, controlar que sumen 100%
                            DataTable dtCuentas = FacturasProveedorDetalleCuentaContableService.GetFacturasProveedorDetalleCuentaContableDataTable(FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol + " = " + dtDetalles.Rows[i][FacturasProveedorDetalleService.Id_NombreCol], string.Empty);
                            decimal sumaPorcentaje;

                            if (dtCuentas.Rows.Count > 0)
                            {
                                sumaPorcentaje = 0;
                                for (int j = 0; j < dtCuentas.Rows.Count; j++)
                                {
                                    sumaPorcentaje += (decimal)dtCuentas.Rows[j][FacturasProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                }

                                if (sumaPorcentaje != 100)
                                {
                                    exito = false;
                                    throw new System.Exception("FC " + cabeceraRow.NRO_COMPROBANTE + " (caso " + cabeceraRow.CASO_ID + ") detalle " + (i + 1) + ", la distribución de porcentajes suma " + sumaPorcentaje + ".");
                                }
                            }
                        }
                    }
                    #endregion

                    #region Actualizar stock y costo
                    if (exito)
                    {
                        decimal vAfectarstock = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.AfectarStock, sesion);
                        decimal tipoFacturaProveedor = cabeceraRow.TIPO_FACTURA_PROVEEDOR_ID;
                        if (!tipoFacturaProveedor.Equals(Definiciones.TipoFacturaProveedor.CompraArticulos) || vAfectarstock == Definiciones.AfectarStock.PorFacturaProveedor)
                        {
                            #region Directamente
                            for (int i = 0; i < dtDetalles.Rows.Count; i++)
                            {
                                if (Interprete.EsNullODBNull(dtDetalles.Rows[i][FacturasProveedorDetalleService.ArticuloId_NombreCol]))
                                    continue;
                                if ((string)dtDetalles.Rows[i][FacturasProveedorDetalleService.AfectaStock_NombreCol] == Definiciones.SiNo.No)
                                    continue;

                                var articulo = new ArticulosService((decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.ArticuloId_NombreCol], sesion);
                                StockService.Costo costo = null;

                                if (articulo.Servicio == Definiciones.SiNo.No)
                                {
                                    decimal montoImpuesto = 0;
                                    if ((decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.PorcentajeImpuesto_NombreCol] > 0)
                                        montoImpuesto = (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.PrecioBrutoUnitarioOrigen_NombreCol] / (1 + (100 / (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.PorcentajeImpuesto_NombreCol]));

                                    costo = new StockService.Costo()
                                    {
                                        moneda_origen_id = cabeceraRow.MONEDA_ID,
                                        cotizacion_origen = cabeceraRow.MONEDA_COTIZACION,
                                        costo_origen = (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.PrecioBrutoUnitarioOrigen_NombreCol] - montoImpuesto,
                                        moneda_id = caso.Sucursal.Region.SucursalCasaMatriz.Pais.MonedaId
                                    };

                                    if (costo.moneda_origen_id == costo.moneda_id)
                                    {
                                        costo.cotizacion = costo.cotizacion_origen;
                                        costo.costo = costo.costo_origen;
                                    }
                                    else
                                    {
                                        costo.cotizacion = cabeceraRow.MONEDA_PAIS_COTIZACION;
                                        costo.costo = costo.costo_origen / costo.cotizacion_origen * costo.cotizacion;
                                    }
                                }

                                StockService.modificarStock(cabeceraRow.STOCK_DEPOSITO_ID,
                                                      (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.ArticuloId_NombreCol],
                                                      Interprete.Redondear((decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.CantidadUnitariaTotalOrigen_NombreCol], 2),
                                                      Definiciones.Stock.TipoMovimiento.Compra,
                                                      cabeceraRow.CASO_ID,
                                                      (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.LoteId_NombreCol],
                                                      estado_destino,
                                                      sesion,
                                                      costo,
                                                      (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.ImpuestoId_NombreCol],
                                                      (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.Id_NombreCol]);
                            }
                            #endregion Directamente
                        }
                        else
                        {
                            #region Crear Caso de Ingreso
                            try
                            {
                                bool generarIngresoStock = false;
                                for (int i = 0; i < dtDetalles.Rows.Count && !generarIngresoStock; i++)
                                    generarIngresoStock = (string)dtDetalles.Rows[i][FacturasProveedorDetalleService.AfectaStock_NombreCol] == Definiciones.SiNo.Si;

                                if (generarIngresoStock)
                                {
                                    decimal casoResultante = 0;
                                    IngresoStockService.CrearCaso(caso_id, sesion.Usuario.ID, SessionService.GetClienteIP(), out casoResultante, sesion, out  mensaje, CBA.FlowV2.Services.Base.Definiciones.EstadosFlujos.Borrador);

                                    //En caso que el campo de caso asociado esté libre, asociar el ingreso de stock a la factura de proveedor
                                    if (cabeceraRow.IsCASO_ASOCIADO_IDNull && casoResultante > 0)
                                        cabeceraRow.CASO_ASOCIADO_ID = casoResultante;
                                }
                            }
                            catch (Exception exp)
                            {
                                mensaje = exp.Message.ToString();
                                exito = false;
                            }
                            #endregion Crear Caso de Ingreso
                        }
                    }
                    #endregion Actualizar stock y costo

                    #region Actualizar cuenta corriente proveedor
                    //comprobar si la factura debe afectar la ctacte del proveedor
                    if (exito && cabeceraRow.AFECTA_CTACTE_PROVEEDOR.Equals(Definiciones.SiNo.Si))
                    {
                        DataTable dt = CalendarioPagosFCProveedorService.GetCalendariosPagosPorFactura(cabeceraRow.ID);

                        foreach (DataRow row in dt.Rows)
                        {
                            decimal montoPago = decimal.Parse(row[CalendarioPagosFCProveedorService.MontoPago_NombreCol].ToString());
                            decimal calendario_pagos_id = decimal.Parse(row[CalendarioPagosFCProveedorService.Id_NombreCol].ToString());
                            DateTime fechaVencimiento = DateTime.Parse(row[CalendarioPagosFCProveedorService.FechaVencimiento_NombreCol].ToString());
                            CuentaCorrienteProveedoresService.AgregarCredito(cabeceraRow.PROVEEDOR_ID,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.CuentaCorrienteValores.Factura,
                                                            Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                            caso.Id.Value,
                                                            cabeceraRow.MONEDA_ID,
                                                            montoPago,
                                                            string.Empty,
                                                            fechaVencimiento,
                                                            calendario_pagos_id,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            sesion);
                        }
                    }
                    #endregion Actualizar cuenta corriente proveedor

                    #region Afectar ctacte persona
                    //comprobar si la factura debe afectar la ctacte de la persona
                    if (exito && cabeceraRow.AFECTA_CTACTE_PERSONA.Equals(Definiciones.SiNo.Si))
                    {
                        //Ingresar el credito
                        string clausulas = FCProveedorPagosTercPersonasService.FCProveedorId_NombreCol + " = " + cabeceraRow.ID;
                        DataTable dtPagoTercPersonas = FCProveedorPagosTercPersonasService.GetFCProveedorPagosTercPersonas(clausulas, string.Empty);
                        System.Collections.Hashtable montoPorImpuesto = new System.Collections.Hashtable();
                        decimal[] impuestoId, monto, montoCuota;
                        decimal impuestoIdAux;
                        decimal montoAux;
                        int indiceAux;

                        #region Calcular monto por tipo de impuesto
                        if (cabeceraRow.AFECTA_CRED_FISCAL_PERSONA.Equals(Definiciones.SiNo.Si))
                        {
                            for (int i = 0; i < dtDetalles.Rows.Count; i++)
                            {
                                impuestoIdAux = (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.ImpuestoId_NombreCol];
                                if (montoPorImpuesto.Contains(impuestoIdAux))
                                    montoPorImpuesto[impuestoIdAux] = (decimal)montoPorImpuesto[impuestoIdAux] + (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalPago_NombreCol];
                                else
                                    montoPorImpuesto.Add(impuestoIdAux, (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalPago_NombreCol]);
                            }
                        }
                        else
                        {
                            montoPorImpuesto.Add(Definiciones.Impuestos.Exenta, cabeceraRow.TOTAL_PAGO);
                        }

                        impuestoId = new decimal[montoPorImpuesto.Count];
                        monto = new decimal[montoPorImpuesto.Count];
                        montoCuota = new decimal[montoPorImpuesto.Count];
                        indiceAux = 0;

                        foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                        {
                            impuestoId[indiceAux] = (decimal)par.Key;
                            monto[indiceAux] = (decimal)par.Value;
                            indiceAux++;
                        }

                        #endregion Calcular monto por tipo de impuesto

                        for (int i = 0; i < dtPagoTercPersonas.Rows.Count; i++)
                        {
                            DataRow rowPersona = dtPagoTercPersonas.Rows[i];

                            #region Calcular monto de cuota
                            for (int j = 0; j < monto.Length; j++)
                            {
                                //Monto total de la deuda
                                montoAux = (monto[j] * (decimal)rowPersona[FCProveedorPagosTercPersonasService.PorcentajeAsignado_NombreCol]) / 100;

                                //Monto total + comision
                                montoAux *= (1 + ((decimal)rowPersona[FCProveedorPagosTercPersonasService.PorcentajeComision_NombreCol] / 100));

                                //monto de la cuota
                                montoCuota[j] = montoAux * (decimal)rowPersona[FCProveedorPagosTercPersonasService.PorcentajeAsignadoCuota_NombreCol] / 100;
                            }
                            #endregion Calcular monto de cuota

                            CuentaCorrientePersonasService.AgregarCredito((decimal)rowPersona[FCProveedorPagosTercPersonasService.PersonaId_NombreCol],
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                    cabeceraRow.CASO_ID,
                                                    cabeceraRow.MONEDA_ID,
                                                    cabeceraRow.MONEDA_COTIZACION,
                                                    impuestoId,
                                                    montoCuota,
                                                    string.Empty,
                                                    DateTime.Parse(rowPersona[FCProveedorPagosTercPersonasService.FechaVencimiento_NombreCol].ToString()),
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
                                                    (decimal)rowPersona[FCProveedorPagosTercPersonasService.NroCuota_NombreCol],
                                                    (decimal)rowPersona[FCProveedorPagosTercPersonasService.TotalCuotas_NombreCol],
                                                    sesion);
                        }
                    }
                    #endregion Afectar ctacte persona
                }

                #endregion En revision a Aprobado

                #region Pendiente a Aprobado
                else if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones
                    //Comprobar existencia de nro de timbrado y nro de comprobante
                    //Comprobar la asignacion de centros de costo en forma manual
                    //Si se indicaron las cuentas contables a asentar, controlar que sumen 100%
                    //Aumentar el stock
                    //Aumentar la cuenta corriente del proveedor si corresponde
                    //Aumentar la cuenta corriente de la persona si corresponde
                    //Actualizar lista de precio base, cuando el articulo es para venta y si el tipo de FP es compra de articulo
                    exito = true;
                    revisarRequisitos = true;

                    if (!cabeceraRow.IsAUTONUMERACION_IDNull)
                    {
                        //Se debe traer el siguiente numero para completar las validaciones. Aun no se debe actualizar el talonario
                        string nroComprobanteAux = AutonumeracionesService.ConsultarSiguienteNumero(cabeceraRow.AUTONUMERACION_ID, sesion);
                        decimal nroComprobanteNumerico = Definiciones.Error.Valor.EnteroPositivo;

                        if (FacturasProveedorService.GetExisteNroComprobante(cabeceraRow.ID, cabeceraRow.AUTONUMERACION_ID, nroComprobanteAux, sesion))
                            throw new Exception("Ya existe una factura con el mismo número de comprobante.");

                        //Controlar que se logro asignar una numeracion
                        if (nroComprobanteAux.Equals(""))
                        {
                            exito = false;
                            mensaje = "No se pudo asignar una numeración válida";
                        }

                        //Si se pasaron todas las validaciones. Generar comprobante.
                        cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, out nroComprobanteNumerico, sesion);
                    }

                    if (exito && (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Equals(string.Empty)))
                    {
                        exito = false;
                        mensaje = "Debe indicar el número de comprobante de la factura.";
                    }

                    if (exito && (cabeceraRow.NRO_TIMBRADO == null || cabeceraRow.NRO_TIMBRADO.Equals(string.Empty)) && (cabeceraRow.IsAUTONUMERACION_IDNull))
                    {
                        exito = false;
                        mensaje = "Debe indicar el número de timbrado de la factura.";
                    }

                    #region control fecha timbrado
                    if (exito)
                    {

                        if (cabeceraRow.ES_TICKET == Definiciones.SiNo.No && cabeceraRow.FECHA_FACTURA.Date > cabeceraRow.FECHA_VENCIMIENTO_TIMBRADO.Date && cabeceraRow.FECHA_VENCIMIENTO_TIMBRADO.Date > DateTime.Parse("01/01/1753"))
                            //if (cabeceraRow.ES_TICKET == Definiciones.SiNo.No && cabeceraRow.FECHA_FACTURA.Date > cabeceraRow.FECHA_VENCIMIENTO_TIMBRADO.Date)
                        {
                            mensaje = "El timbrado está vencido.";
                            exito = false;
                        }
                    }
                    #endregion control fecha timbrado

                    #region control centros de costo
                    if (cabeceraRow.CENTRO_COSTO_OBLIGATORIO == Definiciones.SiNo.Si)
                    {
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            if (!FacturasProveedorDetalleService.GetTieneCentrosCostoManual((decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.Id_NombreCol], sesion))
                                throw new Exception("El detalle número " + (i + 1) + " debe tener centros de costo asignados en forma manual.");
                        }
                    }
                    #endregion control centros de costo

                    #region actualizar Listas De Precios
                    decimal tipoFacturaProveedor = cabeceraRow.TIPO_FACTURA_PROVEEDOR_ID;

                    if (tipoFacturaProveedor.Equals(Definiciones.TipoFacturaProveedor.CompraArticulos))
                    {
                        DataTable dtListasDePrecioBase = ListasDePrecioService.GetListasDePrecioBaseDataTable();
                        //DataTable dtSucursales = SucursalesService.GetSucursalesDataTable2(SucursalesService.ParaFacturar_NombreCol + " = '" + Definiciones.SiNo.Si + "'", string.Empty, true);

                        // recorrer detalles de la factura, comprobar si es para venta
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            decimal articuloId = decimal.Parse(dtDetalles.Rows[i][FacturasProveedorDetalleService.ArticuloId_NombreCol].ToString());
                            //verificar si el articulo es para venta
                            if (!ArticulosService.EsParaVenta(articuloId))
                                continue;

                            // por cada detalle, actualizar el precio del articulo en todas las listas de precio base
                            for (int a = 0; a < dtListasDePrecioBase.Rows.Count; a++)
                            {
                                string clausulas1 = ArticulosMargenRentabilidadService.ArticulosID_NombreCol + " = " + articuloId +
                                                " and " + ArticulosMargenRentabilidadService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                                                " and " + ArticulosMargenRentabilidadService.ListaPreciosId_NombreCol + " = " + dtListasDePrecioBase.Rows[a][ListasDePrecioService.Id_NombreCol] +
                                                " and " + ArticulosMargenRentabilidadService.SucursalesId_NombreCol + " = " + cabeceraRow.SUCURSAL_ID +
                                                " and " + ArticulosMargenRentabilidadService.FechaInicio_NombreCol + " <= '" + DateTime.Now.ToShortDateString() + "' " +
                                                " and (" + ArticulosMargenRentabilidadService.FechaFin_NombreCol + " >= '" + DateTime.Now.ToShortDateString() + "' " +
                                                " or   " + ArticulosMargenRentabilidadService.FechaFin_NombreCol + " is null)";

                                DataTable dtMargenRentabilidad = ArticulosMargenRentabilidadService.GetArticulosMargenRentabilidadDataTable(clausulas1, ArticulosMargenRentabilidadService.FechaFin_NombreCol + " asc");
                                decimal porcentaje = Definiciones.Error.Valor.EnteroPositivo;
                                decimal precio = Definiciones.Error.Valor.EnteroPositivo;
                                //verificar si por cada sucursal existe un registro (activo y para la fecha actual) en la tabla margen_rentabilidad, sino, cortar la ejecucion y lanzar un mensaje de alerta.

                                if (dtMargenRentabilidad.Rows.Count == 0)
                                {

                                    var articulo = new ArticulosService((decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.ArticuloId_NombreCol], sesion);

                                    throw new Exception("Definir margen de rentabilidad del artículo " + articulo.CodigoEmpresa + "-" + articulo.DescripcionInterna + " para la fecha actual, sucursal y lista de precios " + dtListasDePrecioBase.Rows[a][ListasDePrecioService.Nombre_NombreCol]);
                                }
                                ListasDePrecioDetalleService listaPreciosDetalle = new ListasDePrecioDetalleService();

                                // recorrer para inactivar registros

                                #region inactivarRegistros
                                /*for (int k = 0; k < dtMargenRentabilidad.Rows.Count; k++)
                                {
                                    porcentaje = decimal.Parse(dtMargenRentabilidad.Rows[k][ArticulosMargenRentabilidadService.Porcentaje_NombreCol].ToString());

                                    Hashtable campos = new Hashtable();
                                    if (!Interprete.EsNullODBNull(dtMargenRentabilidad.Rows[k][ArticulosMargenRentabilidadService.SucursalesId_NombreCol]))
                                        campos.Add(ListasDePrecioDetalleService.SucursalId_NombreCol, decimal.Parse(dtMargenRentabilidad.Rows[k][ArticulosMargenRentabilidadService.SucursalesId_NombreCol].ToString()));
                                    else
                                        throw new Exception("Seleccionar la sucursal para continuar.");

                                    campos.Add(ListasDePrecioDetalleService.ListaPrecioId_NombreCol, dtMargenRentabilidad.Rows[k][ArticulosMargenRentabilidadService.ListaPreciosId_NombreCol]);
                                    campos.Add(ListasDePrecioDetalleService.ArticuloId_NombreCol, articuloId);
                                    campos.Add(ListasDePrecioDetalleService.CantidadMinima_NombreCol, 1);
                                    campos.Add(ListasDePrecioDetalleService.DescuentoMaximo_NombreCol, 0);
                                    campos.Add(ListasDePrecioDetalleService.FechaInicio_NombreCol, dtMargenRentabilidad.Rows[k][ListaDePreciosModificarDetallesService.FechaInicio_NombreCol]);
                                    if (!Interprete.EsNullODBNull(dtMargenRentabilidad.Rows[k][ListaDePreciosModificarDetallesService.FechaFin_NombreCol]))
                                        campos.Add(ListasDePrecioDetalleService.FechaFin_NombreCol, dtMargenRentabilidad.Rows[k][ListaDePreciosModificarDetallesService.FechaFin_NombreCol]);
                                    campos.Add(ListasDePrecioDetalleService.Estado_NombreCol, Definiciones.Estado.Activo);

                                    campos.Add(ListasDePrecioDetalleService.Precio_NombreCol, precio);
                                    listaPreciosDetalle.InactivarRegistrosDePrecios(campos, sesion);
                                }*/
                                #endregion inactivarRegistros

                                // recorrer para actualizar precios indicando margen_rentabilidad por sucursal
                                #region actualizarPreciosPor margen_rentabilidad
                                for (int k = 0; k < dtMargenRentabilidad.Rows.Count; k++)
                                {
                                    listaPreciosDetalle = new ListasDePrecioDetalleService();
                                    porcentaje = decimal.Parse(dtMargenRentabilidad.Rows[k][ArticulosMargenRentabilidadService.Porcentaje_NombreCol].ToString());

                                    Hashtable campos = new Hashtable();
                                    if (!Interprete.EsNullODBNull(dtMargenRentabilidad.Rows[k][ArticulosMargenRentabilidadService.SucursalesId_NombreCol]))
                                        campos.Add(ListasDePrecioDetalleService.SucursalId_NombreCol, decimal.Parse(dtMargenRentabilidad.Rows[k][ArticulosMargenRentabilidadService.SucursalesId_NombreCol].ToString()));
                                    else
                                        throw new Exception("Seleccionar la sucursal para continuar.");
                                    campos.Add(ListasDePrecioDetalleService.ListaPrecioId_NombreCol, dtMargenRentabilidad.Rows[k][ArticulosMargenRentabilidadService.ListaPreciosId_NombreCol]);
                                    campos.Add(ListasDePrecioDetalleService.ArticuloId_NombreCol, articuloId);
                                    campos.Add(ListasDePrecioDetalleService.CantidadMinima_NombreCol, 1);
                                    campos.Add(ListasDePrecioDetalleService.DescuentoMaximo_NombreCol, 0);
                                    campos.Add(ListasDePrecioDetalleService.FechaInicio_NombreCol, dtMargenRentabilidad.Rows[k][ListaDePreciosModificarDetallesService.FechaInicio_NombreCol]);
                                    if (!Interprete.EsNullODBNull(dtMargenRentabilidad.Rows[k][ListaDePreciosModificarDetallesService.FechaFin_NombreCol]))
                                        campos.Add(ListasDePrecioDetalleService.FechaFin_NombreCol, dtMargenRentabilidad.Rows[k][ListaDePreciosModificarDetallesService.FechaFin_NombreCol]);
                                    campos.Add(ListasDePrecioDetalleService.Estado_NombreCol, Definiciones.Estado.Activo);

                                    #region calcularPrecio
                                    precio = decimal.Parse(dtDetalles.Rows[i][FacturasProveedorDetalleService.PrecioBrutoUnitarioDestino_NombreCol].ToString());
                                    precio = (decimal)(precio + (precio * porcentaje / 100));
                                    #endregion calcularPrecio

                                    campos.Add(ListasDePrecioDetalleService.Precio_NombreCol, precio);
                                    bool actualizarTodasLasListas = true;
                                    listaPreciosDetalle.Guardar(campos, actualizarTodasLasListas, sesion);
                                }
                            }
                                #endregion actualizarPreciosPor margen_rentabilidad
                        }
                    }
                    #endregion actualizar Listas De Precios

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    #region verificar lote
                    if (exito)
                        exito = Webmethods.FacturaAprobada.Avisar(cabeceraRow, out mensaje, sesion);

                    if (exito)
                    {
                        //Controla que los detalles que son articulos del sistema indiquen el lote
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            if (!dtDetalles.Rows[i][FacturasProveedorDetalleService.ArticuloId_NombreCol].Equals(DBNull.Value))
                            {
                                if (dtDetalles.Rows[i][FacturasProveedorDetalleService.LoteId_NombreCol].Equals(DBNull.Value))
                                {
                                    exito = false;
                                    throw new System.ArgumentException("Todo los detalles deben especificar el lote.");
                                }
                            }
                        }
                    }
                    #endregion verificar lote

                    #region verificar suma de pagos

                    if (exito)
                    {
                        decimal totalPagos = CalendarioPagosFCProveedorService.CalcularTotalPagosPorFactura(cabeceraRow.ID, sesion);
                        if (totalPagos != Math.Round(cabeceraRow.TOTAL_PAGO, MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID)))
                        {
                            exito = false;
                            throw new System.ArgumentException("La suma de los Pagos no coinciden con el total de la factura");
                        }

                    }
                    #endregion verificar suma de pagos

                    #region comprobar consistencia entre tipo de fc y configuracion
                    if (exito)
                    {
                        //Si la fc no es de pago a terceros, no puede afectar ctacte persona y debe dar credito fiscal a la empresa
                        if (cabeceraRow.TIPO_FACTURA_PROVEEDOR_ID != Definiciones.TipoFacturaProveedor.PagoTerceros)
                        {
                            exito = (cabeceraRow.AFECTA_CTACTE_PERSONA.Equals(Definiciones.SiNo.No)) &&
                                    (cabeceraRow.AFECTA_CRED_FISCAL_EMPRESA.Equals(Definiciones.SiNo.Si)) &&
                                    (cabeceraRow.AFECTA_CRED_FISCAL_PERSONA.Equals(Definiciones.SiNo.No));

                            if (!exito)
                                throw new System.ArgumentException("Verifique el tipo de factura. Algunos datos no son consistentes");
                        }
                        else
                        {
                            exito = FCProveedorPagosTercPersonasService.PorcentajeTotalValido(cabeceraRow.ID, sesion);

                            if (!exito)
                                throw new System.ArgumentException("El porcentaje del monto asignado a personas no es válido");

                        }
                    }
                    #endregion comprobar consistencia entre tipo de fc y configuracion

                    #region Comprobar distribucion en cuentas contables
                    if (exito)
                    {
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            //Si se indicaron las cuentas contables a asentar, controlar que sumen 100%
                            DataTable dtCuentas = FacturasProveedorDetalleCuentaContableService.GetFacturasProveedorDetalleCuentaContableDataTable(FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol + " = " + dtDetalles.Rows[i][FacturasProveedorDetalleService.Id_NombreCol], string.Empty);
                            decimal sumaPorcentaje;

                            if (dtCuentas.Rows.Count > 0)
                            {
                                sumaPorcentaje = 0;
                                for (int j = 0; j < dtCuentas.Rows.Count; j++)
                                {
                                    sumaPorcentaje += (decimal)dtCuentas.Rows[j][FacturasProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                }

                                if (sumaPorcentaje != 100)
                                {
                                    exito = false;
                                    throw new System.Exception("FC " + cabeceraRow.NRO_COMPROBANTE + " detalle " + i + ", la distribución de porcentajes suma " + sumaPorcentaje + ".");
                                }
                            }
                        }
                    }
                    #endregion

                    #region Actualizar stock y costo
                    string vGeneracionTempranaIngreso = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.GeneracionTempranaIngresoStock, sesion);
                    if (exito && vGeneracionTempranaIngreso == Definiciones.SiNo.No)
                    {
                        decimal vAfectarstock = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.AfectarStock, sesion);

                        //para actualizar el stock, no debe de ser creado desde la factura cliente - transferencia de articulo
                        if (cabeceraRow.IsCASO_ASOCIADO_IDNull || !CasosService.GetFlujo(cabeceraRow.CASO_ASOCIADO_ID).Equals(Definiciones.FlujosIDs.FACTURACION_CLIENTE))
                        {
                            if (cabeceraRow.TIPO_FACTURA_PROVEEDOR_ID != Definiciones.TipoFacturaProveedor.CompraArticulos || vAfectarstock == Definiciones.AfectarStock.PorFacturaProveedor)
                            {
                                #region Directamente
                                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                                {
                                    if (Interprete.EsNullODBNull(dtDetalles.Rows[i][FacturasProveedorDetalleService.ArticuloId_NombreCol]))
                                        continue;
                                    if ((string)dtDetalles.Rows[i][FacturasProveedorDetalleService.AfectaStock_NombreCol] == Definiciones.SiNo.No)
                                        continue;

                                    var articulo = new ArticulosService((decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.ArticuloId_NombreCol], sesion);
                                    StockService.Costo costo = null;

                                    if (articulo.Servicio == Definiciones.SiNo.No)
                                    {
                                        costo = new StockService.Costo()
                                        {
                                            moneda_origen_id = cabeceraRow.MONEDA_ID,
                                            cotizacion_origen = cabeceraRow.MONEDA_COTIZACION,
                                            costo_origen = ((decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalPago_NombreCol] - (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol]) / (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.CantidadUnitariaTotalOrigen_NombreCol],
                                            moneda_id = caso.Sucursal.Region.SucursalCasaMatriz.Pais.MonedaId
                                        };

                                        if (costo.moneda_origen_id == costo.moneda_id)
                                        {
                                            costo.cotizacion = costo.cotizacion_origen;
                                            costo.costo = costo.costo_origen;
                                        }
                                        else
                                        {
                                            costo.cotizacion = cabeceraRow.MONEDA_PAIS_COTIZACION;
                                            costo.costo = costo.costo_origen / costo.cotizacion_origen * costo.cotizacion;
                                        }
                                    }

                                    bool afectarCostos = StockService.modificarStock(cabeceraRow.STOCK_DEPOSITO_ID,
                                                          (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.ArticuloId_NombreCol],
                                                          Interprete.Redondear((decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.CantidadUnitariaTotalOrigen_NombreCol], 2),
                                                          Definiciones.Stock.TipoMovimiento.Compra,
                                                          cabeceraRow.CASO_ID,
                                                          (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.LoteId_NombreCol],
                                                          estado_destino,
                                                          sesion,
                                                          costo,
                                                          (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.ImpuestoId_NombreCol],
                                                          (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.Id_NombreCol]);
                                }
                                #endregion Directamente
                            }
                            else
                            {
                                #region Crear Caso de Ingreso
                                try
                                {
                                    decimal casoResultante = 0;
                                    IngresoStockService.CrearCaso(caso_id, sesion.Usuario.ID, SessionService.GetClienteIP(), out casoResultante, sesion, out  mensaje, CBA.FlowV2.Services.Base.Definiciones.EstadosFlujos.Borrador);

                                    //En caso que el campo de caso asociado esté libre, asociar el ingreso de stock a la factura de proveedor
                                    if (cabeceraRow.IsCASO_ASOCIADO_IDNull && casoResultante > 0)
                                    {
                                        cabeceraRow.CASO_ASOCIADO_ID = casoResultante;
                                    }
                                }
                                catch (Exception exp)
                                {
                                    mensaje = exp.Message.ToString();
                                    exito = false;
                                }
                                #endregion Crear Caso de Ingreso
                            }
                        }
                    }
                    #endregion Actualizar stock y costo

                    #region Actualizar cuenta corriente del proveedor
                    //comprobar si la factura debe afectar la ctacte del proveedor
                    if (exito && cabeceraRow.AFECTA_CTACTE_PROVEEDOR.Equals(Definiciones.SiNo.Si))
                    {

                        DataTable dt = CalendarioPagosFCProveedorService.GetCalendariosPagosPorFactura(cabeceraRow.ID);

                        foreach (DataRow row in dt.Rows)
                        {
                            decimal montoPago = decimal.Parse(row[CalendarioPagosFCProveedorService.MontoPago_NombreCol].ToString());
                            decimal calendario_pagos_id = decimal.Parse(row[CalendarioPagosFCProveedorService.Id_NombreCol].ToString());
                            DateTime fechaVencimiento = DateTime.Parse(row[CalendarioPagosFCProveedorService.FechaVencimiento_NombreCol].ToString());
                            CuentaCorrienteProveedoresService.AgregarCredito(cabeceraRow.PROVEEDOR_ID,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.CuentaCorrienteValores.Factura,
                                                            Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                            caso.Id.Value,
                                                            cabeceraRow.MONEDA_ID,
                                                            montoPago,
                                                            string.Empty,
                                                            fechaVencimiento,
                                                            calendario_pagos_id,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            sesion);
                        }
                    }
                    #endregion Actualizar cuenta corriente del proveedor

                    #region Afectar ctacte persona
                    //comprobar si la factura debe afectar la ctacte de la persona
                    if (exito && cabeceraRow.AFECTA_CTACTE_PERSONA.Equals(Definiciones.SiNo.Si))
                    {
                        //Ingresar el credito
                        string clausulas = FCProveedorPagosTercPersonasService.FCProveedorId_NombreCol + " = " + cabeceraRow.ID;
                        DataTable dtPagoTercPersonas = FCProveedorPagosTercPersonasService.GetFCProveedorPagosTercPersonas(clausulas, string.Empty);
                        System.Collections.Hashtable montoPorImpuesto = new System.Collections.Hashtable();
                        decimal[] impuestoId, monto, montoCuota;
                        decimal impuestoIdAux;
                        decimal montoAux;
                        int indiceAux;

                        #region Calcular monto por tipo de impuesto
                        if (cabeceraRow.AFECTA_CRED_FISCAL_PERSONA.Equals(Definiciones.SiNo.Si))
                        {
                            for (int i = 0; i < dtDetalles.Rows.Count; i++)
                            {
                                impuestoIdAux = (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.ImpuestoId_NombreCol];
                                if (montoPorImpuesto.Contains(impuestoIdAux))
                                    montoPorImpuesto[impuestoIdAux] = (decimal)montoPorImpuesto[impuestoIdAux] + (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalPago_NombreCol];
                                else
                                    montoPorImpuesto.Add(impuestoIdAux, (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalPago_NombreCol]);
                            }
                        }
                        else
                        {
                            montoPorImpuesto.Add(Definiciones.Impuestos.Exenta, cabeceraRow.TOTAL_PAGO);
                        }

                        impuestoId = new decimal[montoPorImpuesto.Count];
                        monto = new decimal[montoPorImpuesto.Count];
                        montoCuota = new decimal[montoPorImpuesto.Count];
                        indiceAux = 0;

                        foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                        {
                            impuestoId[indiceAux] = (decimal)par.Key;
                            monto[indiceAux] = (decimal)par.Value;
                            indiceAux++;
                        }

                        #endregion Calcular monto por tipo de impuesto

                        for (int i = 0; i < dtPagoTercPersonas.Rows.Count; i++)
                        {
                            DataRow rowPersona = dtPagoTercPersonas.Rows[i];

                            #region Calcular monto de cuota
                            for (int j = 0; j < monto.Length; j++)
                            {
                                int cantidadDecimales = MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID);

                                //Monto total de la deuda
                                montoAux = (monto[j] * (decimal)rowPersona[FCProveedorPagosTercPersonasService.PorcentajeAsignado_NombreCol]) / 100;

                                //Monto total + comision
                                montoAux *= (1 + ((decimal)rowPersona[FCProveedorPagosTercPersonasService.PorcentajeComision_NombreCol] / 100));

                                //monto de la cuota
                                montoCuota[j] = Math.Round(montoAux * (decimal)rowPersona[FCProveedorPagosTercPersonasService.PorcentajeAsignadoCuota_NombreCol] / 100, cantidadDecimales);
                            }
                            #endregion Calcular monto de cuota

                            CuentaCorrientePersonasService.AgregarCredito((decimal)rowPersona[FCProveedorPagosTercPersonasService.PersonaId_NombreCol],
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                    cabeceraRow.CASO_ID,
                                                    cabeceraRow.MONEDA_ID,
                                                    cabeceraRow.MONEDA_COTIZACION,
                                                    impuestoId,
                                                    montoCuota,
                                                    string.Empty,
                                                    DateTime.Parse(rowPersona[FCProveedorPagosTercPersonasService.FechaVencimiento_NombreCol].ToString()),
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
                                                    (decimal)rowPersona[FCProveedorPagosTercPersonasService.NroCuota_NombreCol],
                                                    (decimal)rowPersona[FCProveedorPagosTercPersonasService.TotalCuotas_NombreCol],
                                                    sesion);
                        }
                    }
                    #endregion Afectar ctacte persona

                    #region Aprobar Ingreso de Stock
                    if (!cabeceraRow.IsCASO_ASOCIADO_IDNull)
                    {
                        string casoAsociadoEstado = CasosService.GetEstadoCaso(decimal.Parse(cabeceraRow.CASO_ASOCIADO_ID.ToString()), sesion);
                        bool exitoIngreso;
                        string mensajeIngreso = string.Empty;
                        if (casoAsociadoEstado == Definiciones.EstadosFlujos.Borrador)
                        {
                            IngresoStockService ingresoStock = new IngresoStockService();
                            CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService ToolbarFlujo = new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService();

                            ingresoStock.pasarelaCambioEstadoCampos = this.pasarelaCambioEstadoCampos;
                            exitoIngreso = ingresoStock.ProcesarCambioEstado(decimal.Parse(cabeceraRow.CASO_ASOCIADO_ID.ToString()), Definiciones.EstadosFlujos.Pendiente, false, out mensajeIngreso, sesion);
                            if (exitoIngreso)
                                exitoIngreso = ToolbarFlujo.ProcesarCambioEstado(decimal.Parse(cabeceraRow.CASO_ASOCIADO_ID.ToString()), Definiciones.EstadosFlujos.Pendiente, "Transición automática por aprobación de Factura Proveedor.", sesion);
                            if (!exitoIngreso)
                                throw new Exception("Error en ingresoStock.ProcesarCambioEstado al pasar el ingreso a pendiente. " + mensajeIngreso + ".");

                            exitoIngreso = ingresoStock.ProcesarCambioEstado(decimal.Parse(cabeceraRow.CASO_ASOCIADO_ID.ToString()), Definiciones.EstadosFlujos.Aprobado, false, out mensajeIngreso, sesion);
                            if (exitoIngreso)
                                exitoIngreso = ToolbarFlujo.ProcesarCambioEstado(decimal.Parse(cabeceraRow.CASO_ASOCIADO_ID.ToString()), Definiciones.EstadosFlujos.Aprobado, "Transición automática por aprobación de Factura Proveedor.", sesion);
                            if (!exitoIngreso)
                                throw new Exception("Error en ingresoStock.ProcesarCambioEstado al pasar el ingreso a aprobado. " + mensajeIngreso + ".");
                        }
                        else
                            if (casoAsociadoEstado == Definiciones.EstadosFlujos.Pendiente)
                            {
                                IngresoStockService ingresoStock = new IngresoStockService();
                                CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService ToolbarFlujo = new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService();

                                ingresoStock.pasarelaCambioEstadoCampos = this.pasarelaCambioEstadoCampos;
                                exitoIngreso = ingresoStock.ProcesarCambioEstado(decimal.Parse(cabeceraRow.CASO_ASOCIADO_ID.ToString()), Definiciones.EstadosFlujos.Aprobado, false, out mensajeIngreso, sesion);
                                if (exitoIngreso)
                                    exitoIngreso = ToolbarFlujo.ProcesarCambioEstado(decimal.Parse(cabeceraRow.CASO_ASOCIADO_ID.ToString()), Definiciones.EstadosFlujos.Aprobado, "Transición automática por aprobación de Factura Proveedor.", sesion);
                                if (!exitoIngreso)
                                    throw new Exception("Error en ingresoStock.ProcesarCambioEstado al pasar el ingreso a aprobado. " + mensajeIngreso + ".");
                            }
                    }
                    #endregion Aprobar Ingreso de Stock
                }
                #endregion Pendiente a Aprobado

                #region Aprobado a Pendiente
                else if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Comprobar que no se haya afectado la ctacte de personas
                    //Comprobar que no existen pagos sobre la factura
                    //Comprobar que los detalles de artículos que no son servicio no tengan movimiento posterior en el depósito
                    //Desafectar la ctacte del proveedor
                    //Borrar los costos ingresados
                    //Borrar el asiento contable si existe
                    exito = true;
                    revisarRequisitos = true;

                    decimal transicionId;

                    //Comprobar que no se haya afectado la ctacte de personas
                    if (cabeceraRow.AFECTA_CTACTE_PERSONA.Equals(Definiciones.SiNo.Si))
                    {
                        DataTable dtCtacteExistente = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CasoId_NombreCol + " = " + cabeceraRow.CASO_ID, string.Empty, sesion);
                        decimal totalDebito = 0;
                        for (int i = 0; i < dtCtacteExistente.Rows.Count; i++)
                            totalDebito += (decimal)dtCtacteExistente.Rows[i][CuentaCorrientePersonasService.Debito_NombreCol];

                        if (totalDebito > 0)
                        {
                            throw new Exception("Ya afectó ctacte de clientes y ya tiene casos de Pago confirmado.");
                        }
                        else
                        {
                            for (int i = 0; i < dtCtacteExistente.Rows.Count; i++)
                                CuentaCorrientePersonasService.Borrar((decimal)dtCtacteExistente.Rows[i][CuentaCorrientePersonasService.Id_NombreCol], sesion);
                        }
                    }

                    //Comprobar que no existen pagos sobre la factura
                    if (CuentaCorrienteProveedoresService.TienePagoCaso(cabeceraRow.CASO_ID, sesion))
                        throw new Exception("El caso " + cabeceraRow.CASO_ID + " ya cuenta con pagos.");

                    exito = Webmethods.FacturaDesaprobada.Avisar(cabeceraRow, out mensaje, sesion);
                    if (!exito)
                        throw new Exception(mensaje);

                    //Comprobar que los detalles de artículos que no son servicio no tengan movimiento posterior en el depósito
                    for (int i = 0; i < dtDetalles.Rows.Count; i++)
                    {
                        if (!Interprete.EsNullODBNull(dtDetalles.Rows[i][FacturasProveedorDetalleService.ArticuloId_NombreCol]) &&
                            (string)dtDetalles.Rows[i][FacturasProveedorDetalleService.AfectaStock_NombreCol] == Definiciones.SiNo.Si &&
                            !ArticulosService.EsServicio((decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.ArticuloId_NombreCol], sesion))
                        {

                            //Puede desafectar el stock solo si no existen movimientos posteriores
                            if (StockMovimientoService.ExisteMovimientoPosterior(cabeceraRow.CASO_ID, (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.LoteId_NombreCol], cabeceraRow.STOCK_DEPOSITO_ID, sesion))
                                throw new Exception("No puede pasarse a pendiente el caso " + cabeceraRow.CASO_ID + ". Un artículo de los detalles tuvo movimientos posteriores en el depósito.");
                        }
                    }

                    //Desafectar la ctacte del proveedor
                    DataTable dtCalendario = CalendarioPagosFCProveedorService.GetCalendariosPagosPorFactura(cabeceraRow.ID, sesion);
                    for (int i = 0; i < dtCalendario.Rows.Count; i++)
                        CuentaCorrienteProveedoresService.BorrarPorCalendarioPagoId((decimal)dtCalendario.Rows[i][CalendarioPagosFCProveedorService.Id_NombreCol], sesion);

                    #region Actualizar stock y costo
                    decimal vAfectarstock = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.AfectarStock, sesion);

                    //para actualizar el stock, no debe de ser creado desde la factura cliente - transferencia de articulo
                    if (cabeceraRow.IsCASO_ASOCIADO_IDNull || !CasosService.GetFlujo(cabeceraRow.CASO_ASOCIADO_ID).Equals(Definiciones.FlujosIDs.FACTURACION_CLIENTE))
                    {
                        if (cabeceraRow.TIPO_FACTURA_PROVEEDOR_ID != Definiciones.TipoFacturaProveedor.CompraArticulos || vAfectarstock == Definiciones.AfectarStock.PorFacturaProveedor)
                        {
                            #region Directamente
                            for (int i = 0; i < dtDetalles.Rows.Count; i++)
                            {
                                if (Interprete.EsNullODBNull(dtDetalles.Rows[i][FacturasProveedorDetalleService.ArticuloId_NombreCol]))
                                    continue;
                                if ((string)dtDetalles.Rows[i][FacturasProveedorDetalleService.AfectaStock_NombreCol] == Definiciones.SiNo.No)
                                    continue;

                                var articulo = new ArticulosService((decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.ArticuloId_NombreCol], sesion);
                                StockService.Costo costo = null;

                                if (articulo.Servicio == Definiciones.SiNo.No)
                                {
                                    decimal montoImpuesto = 0;
                                    if ((decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.PorcentajeImpuesto_NombreCol] > 0)
                                        montoImpuesto = (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.PrecioBrutoUnitarioOrigen_NombreCol] / (1 + (100 / (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.PorcentajeImpuesto_NombreCol]));

                                    costo = new StockService.Costo()
                                    {
                                        moneda_origen_id = cabeceraRow.MONEDA_ID,
                                        cotizacion_origen = cabeceraRow.MONEDA_COTIZACION,
                                        costo_origen = (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.PrecioBrutoUnitarioOrigen_NombreCol] - montoImpuesto,
                                        moneda_id = caso.Sucursal.Region.SucursalCasaMatriz.Pais.MonedaId
                                    };

                                    if (costo.moneda_origen_id == costo.moneda_id)
                                    {
                                        costo.cotizacion = costo.cotizacion_origen;
                                        costo.costo = costo.costo_origen;
                                    }
                                    else
                                    {
                                        costo.cotizacion = cabeceraRow.MONEDA_PAIS_COTIZACION;
                                        costo.costo = costo.costo_origen / costo.cotizacion_origen * costo.cotizacion;
                                    }
                                }

                                bool afectarCostos = StockService.modificarStock(cabeceraRow.STOCK_DEPOSITO_ID,
                                                      (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.ArticuloId_NombreCol],
                                                      (-1) * Interprete.Redondear((decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.CantidadUnitariaTotalOrigen_NombreCol], 2),
                                                      Definiciones.Stock.TipoMovimiento.Compra,
                                                      cabeceraRow.CASO_ID,
                                                      (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.LoteId_NombreCol],
                                                      estado_destino,
                                                      sesion,
                                                      costo,
                                                      (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.ImpuestoId_NombreCol],
                                                      (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.Id_NombreCol]);

                            }
                            #endregion Directamente
                        }
                        else
                        {
                            #region Borrar Caso de Ingreso
                            DataTable dtIngresoStock = IngresoStockService.GetIngresoStockInfoCompleta(IngresoStockService.CasoFcProveedorId_NombreCol + " = " + cabeceraRow.CASO_ID, string.Empty, sesion);
                            for (int i = 0; i < dtIngresoStock.Rows.Count; i++)
                            {
                                switch ((string)dtIngresoStock.Rows[i][IngresoStockService.VistaCasoEstado_NombreCol])
                                {
                                    case Definiciones.EstadosFlujos.Borrador:
                                        new IngresoStockService().Borrar((decimal)dtIngresoStock.Rows[i][IngresoStockService.CasoId_NombreCol], sesion);
                                        break;
                                    case Definiciones.EstadosFlujos.Anulado:
                                        break;
                                    default:
                                        throw new Exception("El ingreso de stock caso " + dtIngresoStock.Rows[i][IngresoStockService.CasoId_NombreCol] + " asociado está en " + dtIngresoStock.Rows[i][IngresoStockService.VistaCasoEstado_NombreCol]);
                                }
                            }
                            #endregion Borrar Caso de Ingreso
                            cabeceraRow.IsCASO_ASOCIADO_IDNull = true;
                        }
                    }
                    #endregion Actualizar stock y costo

                    //Borrar el asiento contable si existe
                    transicionId = TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.FACTURACION_PROVEEDOR, Definiciones.EstadosFlujos.Pendiente, Definiciones.EstadosFlujos.Aprobado, sesion);
                    CBA.FlowV2.Services.Contabilidad.AsientosService.BorrarPorCasoYTransicion(cabeceraRow.CASO_ID, transicionId, sesion);
                    transicionId = TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.FACTURACION_PROVEEDOR, Definiciones.EstadosFlujos.EnRevision, Definiciones.EstadosFlujos.Aprobado, sesion);
                    CBA.FlowV2.Services.Contabilidad.AsientosService.BorrarPorCasoYTransicion(cabeceraRow.CASO_ID, transicionId, sesion);
                }
                #endregion Aprobado a Pendiente

                #region Aprobado a Cerrado
                else if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                {
                    //Acciones
                    //Validar relaciones
                    //Cerrar Orden de Compra.
                    revisarRequisitos = true;

                    if (cambio_pedido_por_usuario)
                    {
                        exito = false;
                        mensaje = "Solo el sistema puede utilizar la transición 'Aprobado' -> 'Cerrado'.";
                    }
                    else
                    {
                        exito = true;
                    }

                    #region Validar Ordenes de Compra
                    var detallesFCP = new string[dtDetalles.Rows.Count];
                    for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        detallesFCP[i] = dtDetalles.Rows[i][FacturasProveedorDetalleService.Id_NombreCol].ToString();

                    //consulta que obtiene todas las ordenes de compra de la factura
                    StringBuilder query = new StringBuilder();
                    query.Append("select oc." + OrdenesCompraService.CasoId_NombreCol + " \n");
                    query.Append("  from " + OrdenesCompraService.Nombre_Tabla + " oc \n");
                    query.Append("  join " + OrdenesCompraDetalleService.Nombre_Tabla + " ocd on oc." + OrdenesCompraService.Id_NombreCol + " = ocd." + OrdenesCompraDetalleService.OrdenCompraId_NombreCol + " \n");
                    query.Append("  join " + OrdenesCompraDetalleRelacionesService.Nombre_Tabla + " ocdr on ocd." + OrdenesCompraDetalleService.Id_NombreCol + " = ocdr." + OrdenesCompraDetalleRelacionesService.OrdenCompraDetalleId_NombreCol + " \n");
                    query.Append("  join " + FacturasProveedorDetalleService.Nombre_Tabla + " fpd on ocdr." + OrdenesCompraDetalleRelacionesService.FacturaProveedorDetalleId_NombreCol + " = fpd." + FacturasProveedorDetalleService.Id_NombreCol + " \n");
                    query.Append(" where fpd." + FacturasProveedorDetalleService.Id_NombreCol + " in (" + string.Join(",", detallesFCP) + ")");
                    query.Append(" group by oc." + OrdenesCompraService.CasoId_NombreCol + " \n");
                    DataTable ordenes_compra = sesion.db.EjecutarQuery(query.ToString());

                    for (int i = 0; i < ordenes_compra.Rows.Count; i++)
                    {
                        //consulta que valida que las cantidades de todos los detalles de la orden de compra hayan sido utilizados 
                        //en su totalidad en facturas proveedores en estados avanzados
                        query = new StringBuilder();
                        query.Append("select oc." + OrdenesCompraService.CasoId_NombreCol + ", ocd." + OrdenesCompraDetalleService.Id_NombreCol + ", ocd." + OrdenesCompraDetalleService.Cantidad_NombreCol + ", sum(ocdr." + OrdenesCompraDetalleRelacionesService.Cantidad_NombreCol + ") \n");
                        query.Append("  from " + OrdenesCompraService.Nombre_Tabla + " oc \n");
                        query.Append("  join " + OrdenesCompraDetalleService.Nombre_Tabla + " ocd on oc." + OrdenesCompraService.Id_NombreCol + " = ocd." + OrdenesCompraDetalleService.OrdenCompraId_NombreCol + " \n");
                        query.Append("  join " + OrdenesCompraDetalleRelacionesService.Nombre_Tabla + " ocdr on ocd." + OrdenesCompraDetalleService.Id_NombreCol + " = ocdr." + OrdenesCompraDetalleRelacionesService.OrdenCompraDetalleId_NombreCol + " \n");
                        query.Append("  join " + FacturasProveedorDetalleService.Nombre_Tabla + " fpd on ocdr." + OrdenesCompraDetalleRelacionesService.FacturaProveedorDetalleId_NombreCol + " = fpd." + FacturasProveedorDetalleService.Id_NombreCol + " \n");
                        query.Append("  join " + FacturasProveedorService.Nombre_Tabla + " fp on fpd." + FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = fp." + FacturasProveedorService.Id_NombreCol + " \n");
                        query.Append("  join " + CasosService.Nombre_Tabla + " c on fp." + FacturasProveedorService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " \n");
                        query.Append(" where oc." + OrdenesCompraService.CasoId_NombreCol + " = " + ordenes_compra.Rows[i][OrdenesCompraService.CasoId_NombreCol] + " \n");
                        //por cuestiones de sesion, se le indica el caso actual de FC proveedor para realizar la suma de cantidades usadas
                        query.Append("   and (c." + CasosService.EstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Cerrado + "' or c." + CasosService.Id_NombreCol + " = " + cabeceraRow.CASO_ID + ") \n");
                        query.Append(" group by oc." + OrdenesCompraService.CasoId_NombreCol + ", ocd." + OrdenesCompraDetalleService.Id_NombreCol + ", ocd." + OrdenesCompraDetalleService.Cantidad_NombreCol + " \n");
                        query.Append("having ocd." + OrdenesCompraDetalleService.Cantidad_NombreCol + " > sum(ocdr." + OrdenesCompraDetalleRelacionesService.Cantidad_NombreCol + ") \n");
                        DataTable ordenes_compra_relaciones = sesion.db.EjecutarQuery(query.ToString());

                        //si existen registros, no se llegó a utilizar todos los detalles de las ordenes de compra
                        if (ordenes_compra_relaciones.Rows.Count == 0)
                        {
                            //cerrar orden de compra
                            exito = true;
                            mensaje = string.Empty;
                            if (exito)
                                exito = new OrdenesCompraService().ProcesarCambioEstado((decimal)ordenes_compra.Rows[i][OrdenesCompraService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                            if (exito)
                                exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado((decimal)ordenes_compra.Rows[i][OrdenesCompraService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, string.Empty, sesion);
                        }
                    }
                    #endregion Validar Ordenes de Compra
                }
                #endregion Aprobado a Cerrado

                //Verificar si se cumplen los requisitos
                if (exito && revisarRequisitos)
                {
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                }

                if (exito)
                {
                    caso.Guardar(sesion);
                    sesion.Db.FACTURAS_PROVEEDORCollection.Update(cabeceraRow);
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                exito = false;

                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.STOCK_INCONSISTENCIA:
                        throw new System.ArgumentException("Inconsistencia de stock. Favor comuníquese con el soporte técnico.");
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
            CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
            FACTURAS_PROVEEDORRow cabeceraRow = sesion.Db.FACTURAS_PROVEEDORCollection.GetByCASO_ID(caso_id)[0];
            if (!cabeceraRow.IsIMPORTACION_IDNull &&
                (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Cerrado) ||
                 casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Anulado)))
            {
                ImportacionesService importacion = new ImportacionesService();
                importacion.ControlarFinalizado(cabeceraRow.IMPORTACION_ID);
            }

            //Segun sea el flujo del caso asociado
            if (!cabeceraRow.IsCASO_ASOCIADO_IDNull)
            {
                DataTable dtCasoAsociado = CasosService.GetCasosDataTable(CasosService.Id_NombreCol + " = " + cabeceraRow.CASO_ASOCIADO_ID, string.Empty, sesion);
                int flujoAsociado = int.Parse(dtCasoAsociado.Rows[0][CasosService.FlujoId_NombreCol].ToString());
                bool exitoCasoAsociado = true;
                string msg;

                switch (flujoAsociado)
                {
                    case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES:
                        if (casoRow.ESTADO_ID == Definiciones.EstadosFlujos.Aprobado)
                        {
                            exitoCasoAsociado = new DescuentoDocumentosClienteService().ProcesarCambioEstado(cabeceraRow.CASO_ASOCIADO_ID, Definiciones.EstadosFlujos.Vigente, false, out msg, sesion);
                            if (exitoCasoAsociado)
                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(cabeceraRow.CASO_ASOCIADO_ID, Definiciones.EstadosFlujos.Vigente, "Transición automática.", sesion);
                            if (exitoCasoAsociado)
                                new DescuentoDocumentosClienteService().EjecutarAccionesLuegoDeCambioEstado(cabeceraRow.CASO_ASOCIADO_ID, Definiciones.EstadosFlujos.Vigente, sesion);

                            if (!exitoCasoAsociado)
                                throw new Exception("Error en FacturasProveedorService.EjecutarAccionesLuegoDeCambioEstado(), Descuento Documento Persona. " + msg + ".");
                        }
                        break;
                }
            }

            if(casoRow.ESTADO_ANTERIOR_ID == Definiciones.EstadosFlujos.Pendiente && casoRow.ESTADO_ID == Definiciones.EstadosFlujos.Aprobado)
            {
                #region Crear Egreso Vario de Caja
                if (!cabeceraRow.IsCTACTE_FONDO_FIJO_IDNull && RolesService.Tiene("FC PROVEEDOR GENERAR EGRESO VARIO DE CAJA"))
                {
                    decimal egresosVariosCajaId = Definiciones.Error.Valor.EnteroPositivo;
                    decimal egresosVariosCajaCasoId = Definiciones.Error.Valor.EnteroPositivo;
                    string mensaje;

                    DataTable dtTalonarioRetencion = AutonumeracionesService.GetAutonumeracionesPorTabla2(CuentaCorrienteRetencionesEmitidasService.Nombre_Tabla, cabeceraRow.SUCURSAL_ID);
                    if (!(dtTalonarioRetencion.Rows.Count > 0))
                        throw new Exception("No existe un talonario de retención activo");

                    if (cabeceraRow.IsEGRESO_VARIO_CAJA_AUTONUM_IDNull)
                        throw new Exception("No existe un talonario asignado para el Egreso Vario Caja.");

                    EgresosVariosCajaService.CrearCabecera(cabeceraRow.CTACTE_FONDO_FIJO_ID, null, cabeceraRow.SUCURSAL_ID, cabeceraRow.EGRESO_VARIO_CAJA_AUTONUM_ID, cabeceraRow.MONEDA_ID, cabeceraRow.MONEDA_COTIZACION, cabeceraRow.TOTAL_PAGO, cabeceraRow.EGRESO_VARIO_CAJA_FECHA.ToString("yyyyMMdd"), cabeceraRow.EGRESO_VARIO_CAJA_FECHA.ToString("yyyyMMdd"), cabeceraRow.EGRESO_VARIO_CAJA_NRO_COMPR, string.Empty, string.Empty, string.Empty, false, Definiciones.SiNo.No, (decimal)dtTalonarioRetencion.Rows[0][AutonumeracionesService.Id_NombreCol], ref egresosVariosCajaId, ref egresosVariosCajaCasoId, sesion);
                    DataTable dtCuentaCorrienteProveedor = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresDataTable(CuentaCorrienteProveedoresService.CasoId_NombreCol + " = " + cabeceraRow.CASO_ID, string.Empty, sesion);
                    EgresosVariosCajaDetalleService.CrearDetalleProveedor(egresosVariosCajaId, decimal.Parse(dtCuentaCorrienteProveedor.Rows[0][CuentaCorrienteProveedoresService.Id_NombreCol].ToString()), cabeceraRow.MONEDA_ID, cabeceraRow.MONEDA_COTIZACION, cabeceraRow.TOTAL_PAGO, cabeceraRow.TOTAL_PAGO, string.Empty, cabeceraRow.PROVEEDOR_ID, sesion);

                    bool exito;
                    exito = new EgresosVariosCajaService().ProcesarCambioEstado(egresosVariosCajaCasoId, Definiciones.EstadosFlujos.Pendiente, true, out mensaje, sesion);
                    if (exito)
                        new ToolbarFlujoService().ProcesarCambioEstado(egresosVariosCajaCasoId, Definiciones.EstadosFlujos.Pendiente, "Paso de Estado Automático por Factura caso " + casoRow.ID, sesion);
                    if (exito)
                        (new EgresosVariosCajaService()).EjecutarAccionesLuegoDeCambioEstado(egresosVariosCajaCasoId, Definiciones.EstadosFlujos.Pendiente, sesion);

                    exito = new EgresosVariosCajaService().ProcesarCambioEstado(egresosVariosCajaCasoId, Definiciones.EstadosFlujos.Aprobado, true, out mensaje, sesion);
                    if (exito)
                        new ToolbarFlujoService().ProcesarCambioEstado(egresosVariosCajaCasoId, Definiciones.EstadosFlujos.Aprobado, "Paso de Estado Automático por Factura caso " + casoRow.ID, sesion);
                    if (exito)
                        (new EgresosVariosCajaService()).EjecutarAccionesLuegoDeCambioEstado(egresosVariosCajaCasoId, Definiciones.EstadosFlujos.Aprobado, sesion);
                }
                #endregion Crear Egreso Vario de Caja

                //Si la factura es por monot 0 debe pasarse a cerrado
                if (cabeceraRow.TOTAL_PAGO == 0)
                {
                    bool exito = true;
                    string mensaje = string.Empty;
                    if (exito)
                        exito = new FacturasProveedorService().ProcesarCambioEstado(caso_id, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(caso_id, Definiciones.EstadosFlujos.Cerrado, string.Empty, sesion);
                    if (exito)
                        new FacturasProveedorService().EjecutarAccionesLuegoDeCambioEstado(caso_id, Definiciones.EstadosFlujos.Cerrado, sesion);
                }
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
            FACTURAS_PROVEEDORRow row = sesion.Db.FACTURAS_PROVEEDORCollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE.Equals(DBNull.Value) ? string.Empty : row.NRO_COMPROBANTE;
        }

        #endregion Implementacion de metodos abstract
        
        #region GetFacturaProveedorDataTable
        /// <summary>
        /// Gets the factura proveedor data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        [Obsolete("utilizar metodos estaticos")]
        public DataTable GetFacturaProveedorDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FACTURAS_PROVEEDORCollection.GetAsDataTable(clausulas, orden);
            }
        }

        [Obsolete("utilizar metodos estaticos")]
        public DataTable GetFacturaProveedorDataTable(Decimal facturacion_proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FACTURAS_PROVEEDORCollection.GetAsDataTable(FacturasProveedorService.Id_NombreCol + "=" + facturacion_proveedor_id, FacturasProveedorService.Id_NombreCol);
            }
        }

        public static DataTable GetFacturaProveedorDataTable2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFacturaProveedorDataTable2(clausulas, orden, sesion);
            }
        }

        public static DataTable GetFacturaProveedorDataTable2(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.FACTURAS_PROVEEDORCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetFacturaProveedorDataTable

        #region GetFacturaProveedorInfoCompleta
        public static DataTable GetFacturaProveedorInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFacturaProveedorInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetFacturaProveedorInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            if (!clausulas.Equals(string.Empty))
                clausulas += " and ";
            
            if (orden.Equals(string.Empty))
                orden = FacturasProveedorService.CasoId_NombreCol;
            
            clausulas += " " + FacturasProveedorService.VistaEntidadId_NombreCol + " = " + sesion.Entidad.ID;

            return sesion.Db.FACTURAS_PROVEEDOR_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetFacturaProveedorInfoCompleta

        #region GetTimbradoAnterior
        public static void GetTimbradoAnterior(decimal proveedor_id, out string nro_timbrado, out DateTime fecha_vencimiento)
        {
            using (SessionService sesion = new SessionService())
            {
                string query = "";
                query += "select * from ( " + "\n";
                query += "select fp." + FacturasProveedorService.Id_NombreCol + ", fp." + FacturasProveedorService.NroTimbrado_NombreCol + 
                         ", fp." + FacturasProveedorService.FechaVencimientoTimbrado_NombreCol + 
                         ", row_number() over (order by " +FacturasProveedorService.Id_NombreCol + " desc) as rn " + "\n";
                query += "from " + FacturasProveedorService.Nombre_Tabla + " fp " + "\n";
                query += "where fp." + FacturasProveedorService.ProveedorId_NombreCol + " = " + proveedor_id + " and " + "\n";
                query += "fp." + FacturasProveedorService.NroTimbrado_NombreCol + " is not null) " + "\n";
                query += "where rn = 1";      
                       
                DataTable dt = sesion.db.EjecutarQuery(query);
                nro_timbrado = string.Empty;               
                fecha_vencimiento = DateTime.Now;
                if (dt.Rows.Count > 0)
                {
                     nro_timbrado = (string)dt.Rows[0][FacturasProveedorService.NroTimbrado_NombreCol];
                     if (!Interprete.EsNullODBNull(dt.Rows[0][FacturasProveedorService.FechaVencimientoTimbrado_NombreCol]))
                        fecha_vencimiento = (DateTime)dt.Rows[0][FacturasProveedorService.FechaVencimientoTimbrado_NombreCol];
                }
            }  
        }
        #endregion GetTimbradoAnterior

        #region GetTimbradosAnteriores
        public static DataTable GetTimbradosAnteriores(decimal proveedor_id, DateTime fecha_factura)
        {
            using (SessionService sesion = new SessionService())
            {
                string sql = "select " + FacturasProveedorService.NroTimbrado_NombreCol + ", max(" + FacturasProveedorService.FechaVencimientoTimbrado_NombreCol + ") " +
                             "  from " + FacturasProveedorService.Nombre_Tabla + 
                             " where " + FacturasProveedorService.ProveedorId_NombreCol + " = " + proveedor_id +
                             "   and " + FacturasProveedorService.NroTimbrado_NombreCol + " is not null " + 
                             "   and trunc(" + FacturasProveedorService.FechaVencimientoTimbrado_NombreCol + ") >= to_date('" + fecha_factura.ToShortDateString() + "', 'dd/mm/yyyy') " +
                             " group by " + FacturasProveedorService.NroTimbrado_NombreCol +
                             " order by max(" + FacturasProveedorService.FechaVencimientoTimbrado_NombreCol + ") desc";
                return sesion.Db.EjecutarQuery(sql);
            }
        }
        #endregion GetTimbradosAnteriores

        #region GetFechaVencimientoTimbrado
        public static DateTime? GetFechaVencimientoTimbrado(decimal proveedor_id, string nro_timbrado, decimal caso_excluir_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string sql = "select max( " + FacturasProveedorService.FechaVencimientoTimbrado_NombreCol + ") " +
                                  "  from " + FacturasProveedorService.Nombre_Tabla +
                                  " where " + FacturasProveedorService.ProveedorId_NombreCol + " = " + proveedor_id +
                                  "   and " + FacturasProveedorService.NroTimbrado_NombreCol + " = '" + nro_timbrado + "' " +
                                  "   and " + FacturasProveedorService.CasoId_NombreCol + " <> " + caso_excluir_id;
                DataTable dt = sesion.Db.EjecutarQuery(sql);
                if (!Interprete.EsNullODBNull(dt.Rows[0][0]))
                    return (DateTime)dt.Rows[0][0];
                else
                    return null;
            }
        }
        #endregion GetFechaVencimientoTimbrado

        #region GetCasoId
        public static decimal GetCasoId(decimal factura_proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.FACTURAS_PROVEEDORCollection.GetByPrimaryKey(factura_proveedor_id).CASO_ID;
            }
        }

        public static decimal GetCasoId(decimal factura_proveedor_id, SessionService sesion)
        {
                return sesion.db.FACTURAS_PROVEEDORCollection.GetByPrimaryKey(factura_proveedor_id).CASO_ID;   
        }
        #endregion GetCasoId

        #region GetFacturaIdPorCaso
        public static decimal GetFacturaIdPorCaso(decimal Caso_Nro)
        {
            string clausula = FacturasProveedorService.CasoId_NombreCol + "=" + Caso_Nro;
            DataTable dtFactura =FacturasProveedorService.GetFacturaProveedorDataTable2(clausula, FacturasProveedorService.Id_NombreCol);
            if (dtFactura.Rows.Count > 0)
                return decimal.Parse(dtFactura.Rows[0][FacturasProveedorService.Id_NombreCol].ToString());
            else
                return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion

        #region GetFacturaNroComprobantePorCaso
        public static string GetFacturaNroComprobantePorCaso(decimal Caso_Nro)
        {
            string clausula = FacturasProveedorService.CasoId_NombreCol + "=" + Caso_Nro;
            DataTable dtFactura = FacturasProveedorService.GetFacturaProveedorDataTable2(clausula, FacturasProveedorService.Id_NombreCol);
            if (dtFactura.Rows.Count > 0)
                return dtFactura.Rows[0][FacturasProveedorService.NroComprobante_NombreCol].ToString();
            else
                return string.Empty;
        }
        #endregion

        #region AfectaCtaCteProveedor
        public static string AfectaCtaCteProveedor(decimal factura_proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return AfectaCtaCteProveedor(factura_proveedor_id, sesion);
            }
        }

        public static string AfectaCtaCteProveedor(decimal factura_proveedor_id, SessionService sesion)
        {
            return sesion.db.FACTURAS_PROVEEDORCollection.GetByPrimaryKey(factura_proveedor_id).AFECTA_CTACTE_PROVEEDOR;
        }
        #endregion AfectaCtaCteProveedor

        #region GetCasoAsociado
        public static decimal GetCasoAsociadoId(decimal factura_proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FACTURAS_PROVEEDORRow fc = new FACTURAS_PROVEEDORRow();
                fc= sesion.db.FACTURAS_PROVEEDORCollection.GetByPrimaryKey(factura_proveedor_id);
                if (fc.IsCASO_ASOCIADO_IDNull)
                {
                    return Definiciones.Error.Valor.EnteroPositivo;
                }
                else {
                    return fc.CASO_ASOCIADO_ID;
                }
            }
        }
        #endregion GetCasoAsociado

        #region GetMonedaId
        public static decimal GetMonedaId(decimal factura_proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.FACTURAS_PROVEEDORCollection.GetByPrimaryKey(factura_proveedor_id).MONEDA_ID;
            }
        }
        #endregion  GetMonedaId

        #region GetMonedaId
        public static decimal GetTotalPago(decimal factura_proveedor_id, SessionService sesion)
        {
            return sesion.db.FACTURAS_PROVEEDORCollection.GetByPrimaryKey(factura_proveedor_id).TOTAL_PAGO;
        }
        #endregion  GetMonedaId

        #region GetProveedorId
        public static decimal GetProveedorId(decimal factura_proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.FACTURAS_PROVEEDORCollection.GetByPrimaryKey(factura_proveedor_id).PROVEEDOR_ID;
            }
        }
        #endregion GetProveedorId

        #region GetMontoRetencion
        /// <summary>
        /// Gets the monto retencion.
        /// </summary>
        /// <param name="factura_proveedor_id">The factura_proveedor_id.</param>
        /// <returns></returns>
        public static decimal GetMontoRetencion(decimal factura_proveedor_id, bool descontarImpuestoNC)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetMontoRetencion(factura_proveedor_id, descontarImpuestoNC, sesion);
            }
        }

        /// <summary>
        /// Gets the monto retencion.
        /// </summary>
        /// <param name="factura_proveedor_id">The factura_proveedor_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal GetMontoRetencion(decimal factura_proveedor_id, bool descontarImpuestoNC, SessionService sesion)
        {
            FACTURAS_PROVEEDORRow row = sesion.db.FACTURAS_PROVEEDORCollection.GetByPrimaryKey(factura_proveedor_id);
            decimal sumaTotalSinImpuesto = 0, sumaImpuesto = 0, sumaNeto = 0;
            decimal montoRetencion = 0;
            decimal factorConversion;
            decimal montoEmpiezaRetencion, monedaMontoEmpiezaRetencion, porcentajeRetencion, cotizacionMonedaRetencion;

            if (!ProveedoresService.EsPasibleRetencion(row.PROVEEDOR_ID, row.FECHA_FACTURA))
                return 0;

            DataTable dtRetenciones = TiposRetencionesService.GetTiposRetencionesDataTable(TiposRetencionesService.EmitirRetencion_NombreCol + " = '" + Definiciones.SiNo.Si + "'", string.Empty);
            if (dtRetenciones.Rows.Count <= 0)
                return 0;

            string query = string.Empty;

            if (descontarImpuestoNC)
            {
                string sqlImpuestoNC = "nvl((" +
                    "select sum(ncpd." + NotasCreditoProveedorDetalleService.ImpuestoMonto_NombreCol + ") " +
                    "  from " + NotasCreditoProveedorService.Nombre_Vista + " ncpic, " + NotasCreditoProveedorDetalleService.Nombre_Tabla + " ncpd " +
                    " where ncpd." + NotasCreditoProveedorDetalleService.FacturaProveedorId_NombreCol + " = fp." + FacturasProveedorService.Id_NombreCol +
                    "   and ncpic." + NotasCreditoProveedorService.Id_NombreCol + " = ncpd." + NotasCreditoProveedorDetalleService.NotaCreditoId_NombreCol +
                    "   and ncpic." + NotasCreditoProveedorService.VistaCasoEstadoId_NombreCol + " in ('" + Definiciones.EstadosFlujos.Aprobado + "', '" + Definiciones.EstadosFlujos.Cerrado + "') " +
                    "),0)";

                query = "";
                query += "select a." + ArticulosService.Retencion_Nombrecol + 
                    ", fpd." + FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol + " - " + sqlImpuestoNC + " " + FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol + ", fpd.* " + "\n";
                query += "from " + FacturasProveedorService.Nombre_Tabla + " fp, "  + FacturasProveedorDetalleService.Nombre_Tabla + " fpd, " + ArticulosService.Nombre_Tabla + " a " + "\n";
                query += "where fpd." + FacturasProveedorDetalleService.ArticuloId_NombreCol + " = a." + ArticulosService.Id_NombreCol + " \n";
                query += " and fpd." + FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = fp." + FacturasProveedorService.Id_NombreCol + " \n";
                query += " and fpd." + FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + row.ID;
            }
            else
            {
                query = "select a." + ArticulosService.Retencion_Nombrecol + ", fpd.* " + "\n";
                query += "from " + FacturasProveedorDetalleService.Nombre_Tabla + " fpd, " + ArticulosService.Nombre_Tabla + " a " + "\n";
                query += "where fpd." + FacturasProveedorDetalleService.ArticuloId_NombreCol + " = a." + ArticulosService.Id_NombreCol + " \n";
                query += " and fpd." + FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + row.ID;
            }

            DataTable dtDetalles = sesion.db.EjecutarQuery(query);

            for (int i = 0; i < dtDetalles.Rows.Count; i++)
            {
                sumaNeto += (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalPago_NombreCol];
                sumaTotalSinImpuesto += ((decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalPago_NombreCol] - (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol]);
                sumaImpuesto += (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol];
            }

            foreach (DataRow retencion in dtRetenciones.Rows)
            {
                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                {
                    decimal neto = (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalPago_NombreCol];
                    decimal totalSinImpuesto = ((decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalPago_NombreCol] - (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol]);
                    decimal impuesto = (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol];

                    montoEmpiezaRetencion = (decimal)retencion[TiposRetencionesService.MontoMinimo_NombreCol];
                    monedaMontoEmpiezaRetencion = (decimal)retencion[TiposRetencionesService.MonedaId_NombreCol];

                    porcentajeRetencion = (decimal)dtDetalles.Rows[i][ArticulosService.Retencion_Nombrecol];
                    if (porcentajeRetencion == 0)
                        porcentajeRetencion = (decimal)retencion[TiposRetencionesService.Porcentaje_NombreCol];

                    cotizacionMonedaRetencion = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais(row.SUCURSAL_ID), monedaMontoEmpiezaRetencion, row.FECHA, sesion);

                    if (monedaMontoEmpiezaRetencion == row.MONEDA_ID)
                        factorConversion = 1;
                    else
                        factorConversion = cotizacionMonedaRetencion / row.MONEDA_COTIZACION;

                    if (neto * factorConversion >= montoEmpiezaRetencion)
                    {
                        if (decimal.ToInt32((decimal)retencion[TiposRetencionesService.TipoMontoAAplicar_NombreCol]).Equals(Definiciones.TiposMontosAAplicarRetenciones.IVA))
                            montoRetencion += impuesto * porcentajeRetencion / 100;
                        else
                            if (decimal.ToInt32((decimal)retencion[TiposRetencionesService.TipoMontoAAplicar_NombreCol]).Equals(Definiciones.TiposMontosAAplicarRetenciones.TotalSinIVA))
                                montoRetencion += totalSinImpuesto * porcentajeRetencion / 100;
                            else
                                throw new Exception("Error en FacturasProveedorService: Tipo de Monto a Aplicar Retenciones no implementado.");
                    }
                }
            }

            return montoRetencion;
        }
        #endregion GetMontoRetencion

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref String estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    var id = Guardar(campos, insertarNuevo, ref caso_id, ref estado_id, sesion);
                    sesion.CommitTransaction();
                    return id;
                }
                catch (Exception)
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref String estado_id, SessionService sesion) 
        {
            FACTURAS_PROVEEDORRow filaFacturaProveedor = new FACTURAS_PROVEEDORRow();

            try
            {
                UsuariosService usuario = new UsuariosService();

                if (usuario.GetPersonaId(sesion.Usuario_Id) == ProveedoresService.GetPersonaIdPorProveedorId((decimal)campos[FacturasProveedorService.ProveedorId_NombreCol]) && usuario.GetPersonaId(sesion.Usuario_Id) != Definiciones.Error.Valor.EnteroPositivo)
                    throw new Exception("El usuario no puede crear un caso de sí mismo.");

                string valorAnterior = string.Empty;
                bool vFCProveedorUsarFechaPedidoYRecepcion = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCProveedorUsarFechaPedidoYRecepcion) == Definiciones.SiNo.Si;
                bool actualizarMovimientos = false;

                #region Validar Fechas
                DateTime fechaPedido, fechaFactura, fechaRecepcion;
                if (!vFCProveedorUsarFechaPedidoYRecepcion && campos.Contains(FechaFactura_NombreCol))
                {
                    fechaFactura = ((DateTime)campos[FacturasProveedorService.FechaFactura_NombreCol]).Date;
                    campos[FacturasProveedorService.Fecha_NombreCol] = fechaFactura;

                    if (campos.Contains(FechaRecepcion_NombreCol))
                        campos[FacturasProveedorService.FechaRecepcion_NombreCol] = fechaFactura;
                    else
                        campos.Add(FacturasProveedorService.FechaRecepcion_NombreCol, fechaFactura);
                }
                if (campos.Contains(FacturasProveedorService.Fecha_NombreCol))
                     fechaPedido = ((DateTime)campos[FacturasProveedorService.Fecha_NombreCol]).Date;
                else
                    fechaPedido = DateTime.Now;
                //Poner como valor por defecto la fecha de pedido, por si no estan chequeados estos campos
                fechaFactura = fechaPedido;
                fechaRecepcion = fechaPedido;

                if (campos.Contains(FechaFactura_NombreCol))
                    fechaFactura = ((DateTime)campos[FacturasProveedorService.FechaFactura_NombreCol]).Date;

                if (campos.Contains(FechaRecepcion_NombreCol))
                    fechaRecepcion = ((DateTime)campos[FacturasProveedorService.FechaRecepcion_NombreCol]).Date;

                if (fechaFactura.Date < fechaPedido.Date)
                    throw new Exception("La fecha de la factura no puede ser anterior a la del pedido.");

                #endregion Validar Fechas

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[FacturasProveedorService.SucursalId_NombreCol].ToString()),
                                                          int.Parse(Definiciones.FlujosIDs.FACTURACION_PROVEEDOR.ToString()),
                                                          int.Parse(sesion.Usuario_Id.ToString()),
                                                          SessionService.GetClienteIP());
                    filaFacturaProveedor.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                    filaFacturaProveedor.ID = sesion.Db.GetSiguienteSecuencia("facturas_proveedor_sqc");
                    caso_id = filaFacturaProveedor.CASO_ID; //Se copia al parametro pasado por referencia
                    estado_id = Definiciones.EstadosFlujos.Borrador;

                    //Una vez creado el caso no puede cambiarse la sucursal
                    filaFacturaProveedor.SUCURSAL_ID = (decimal)campos[FacturasProveedorService.SucursalId_NombreCol];
                    if (!SucursalesService.EstaActivo(filaFacturaProveedor.SUCURSAL_ID))
                        throw new Exception("La sucursal no está activa.");
                    
                    filaFacturaProveedor.TOTAL_BRUTO = 0;
                    filaFacturaProveedor.TOTAL_DESCUENTO = 0;
                    filaFacturaProveedor.TOTAL_IMPUESTO = 0;
                    filaFacturaProveedor.TOTAL_PAGO = 0;
                }
                else
                {
                    filaFacturaProveedor = sesion.Db.FACTURAS_PROVEEDORCollection.GetByPrimaryKey(decimal.Parse(campos[FacturasProveedorService.Id_NombreCol].ToString()));
                    valorAnterior = filaFacturaProveedor.ToString();
                }

                //Si cambia la sucursal debe actualizarse en Casos
                if (campos.Contains(FacturasProveedorService.SucursalId_NombreCol))
                {
                    if (filaFacturaProveedor.SUCURSAL_ID != (decimal)campos[FacturasProveedorService.SucursalId_NombreCol])
                    {
                        filaFacturaProveedor.SUCURSAL_ID = (decimal)campos[FacturasProveedorService.SucursalId_NombreCol];
                        CasosService.ActualizarSucursal(filaFacturaProveedor.CASO_ID, filaFacturaProveedor.SUCURSAL_ID, sesion);
                    } 
                }

                if (campos.Contains(PorcentajeDescSobreTotal_NombreCol))
                {
                    filaFacturaProveedor.PORCENTAJE_DESC_SOBRE_TOTAL = decimal.Parse(campos[PorcentajeDescSobreTotal_NombreCol].ToString()); ;
  
                }
                if (campos.Contains(FacturasProveedorService.ProveedorId_NombreCol))
                {
                    if (filaFacturaProveedor.PROVEEDOR_ID.Equals(DBNull.Value) || filaFacturaProveedor.PROVEEDOR_ID != (decimal)campos[FacturasProveedorService.ProveedorId_NombreCol])
                    {
                        filaFacturaProveedor.PROVEEDOR_ID = (decimal)campos[FacturasProveedorService.ProveedorId_NombreCol];
                        if (!ProveedoresService.EstaActivo(filaFacturaProveedor.PROVEEDOR_ID))
                            throw new Exception("El proveedor no está activo.");
                    } 
                }
                if (campos.Contains(FacturasProveedorService.StockDepositoId_NombreCol))
                {
                    if (campos[FacturasProveedorService.StockDepositoId_NombreCol] != null)
                    {
                        if (filaFacturaProveedor.STOCK_DEPOSITO_ID.Equals(DBNull.Value) || filaFacturaProveedor.STOCK_DEPOSITO_ID != (decimal)campos[FacturasProveedorService.StockDepositoId_NombreCol])
                        {
                            filaFacturaProveedor.STOCK_DEPOSITO_ID = (decimal)campos[FacturasProveedorService.StockDepositoId_NombreCol];
                            if (!StockDepositosService.EstaActivo(filaFacturaProveedor.STOCK_DEPOSITO_ID))
                                throw new Exception("El depósito no está activo.");
                        }
                    }   
                }
               

                if (campos.Contains(FacturasProveedorService.RubroId_NombreCol))
                    filaFacturaProveedor.RUBRO_ID = (decimal)campos[FacturasProveedorService.RubroId_NombreCol];
                else
                    filaFacturaProveedor.IsRUBRO_IDNull = true;

                if (campos.Contains(FacturasProveedorService.CantidadContenedores_NombreCol))
                    filaFacturaProveedor.CANTIDAD_CONTENEDORES = (decimal)campos[FacturasProveedorService.CantidadContenedores_NombreCol];
                else
                    filaFacturaProveedor.IsCANTIDAD_CONTENEDORESNull = true;
                if (campos.Contains(FacturasProveedorService.CtacteCondicionPagoId_NombreCol))
                {
                    filaFacturaProveedor.CTACTE_CONDICION_PAGO_ID = (decimal)campos[FacturasProveedorService.CtacteCondicionPagoId_NombreCol];
 
                }
               
                if (campos.Contains(FacturasProveedorService.EstadoDocumentacionId_NombreCol))
                    filaFacturaProveedor.ESTADO_DOCUMENTACION_ID = (decimal)campos[FacturasProveedorService.EstadoDocumentacionId_NombreCol];
                else
                    filaFacturaProveedor.IsESTADO_DOCUMENTACION_IDNull = true;
                if (campos.Contains(FacturasProveedorService.Fecha_NombreCol))
                {
                    if (filaFacturaProveedor.FECHA.Equals(DBNull.Value) || filaFacturaProveedor.FECHA != (DateTime)campos[FacturasProveedorService.Fecha_NombreCol])
                        filaFacturaProveedor.FECHA = (DateTime)campos[FacturasProveedorService.Fecha_NombreCol];

                }
                
                if (campos.Contains(FacturasProveedorService.FechaFactura_NombreCol))
                {
                    if (filaFacturaProveedor.IsFECHA_FACTURANull || filaFacturaProveedor.FECHA_FACTURA != (DateTime)campos[FacturasProveedorService.FechaFactura_NombreCol])
                        actualizarMovimientos = true;
                    filaFacturaProveedor.FECHA_FACTURA = (DateTime)campos[FacturasProveedorService.FechaFactura_NombreCol];
                }
                else
                {
                    filaFacturaProveedor.IsFECHA_FACTURANull = true;
                }

                if (campos.Contains(FacturasProveedorService.FechaRecepcion_NombreCol))
                    filaFacturaProveedor.FECHA_RECEPCION = (DateTime)campos[FacturasProveedorService.FechaRecepcion_NombreCol];
                else
                    filaFacturaProveedor.IsFECHA_RECEPCIONNull = true;

                if (campos.Contains(FacturasProveedorService.AutonumeracionId_NombreCol))
                    filaFacturaProveedor.AUTONUMERACION_ID = (decimal)campos[FacturasProveedorService.AutonumeracionId_NombreCol];
                else
                    filaFacturaProveedor.IsAUTONUMERACION_IDNull = true;
                if (campos.Contains(FacturasProveedorService.FechaVencimientoTimbrado_NombreCol))
                {
                    if (filaFacturaProveedor.IsAUTONUMERACION_IDNull)
                    {
                        filaFacturaProveedor.FECHA_VENCIMIENTO_TIMBRADO = (DateTime)campos[FacturasProveedorService.FechaVencimientoTimbrado_NombreCol];
                    }
                    else
                    {
                        AUTONUMERACIONESRow autonumeracion = new AUTONUMERACIONESRow();
                        autonumeracion = sesion.db.AUTONUMERACIONESCollection.GetByPrimaryKey(filaFacturaProveedor.AUTONUMERACION_ID);
                        filaFacturaProveedor.FECHA_VENCIMIENTO_TIMBRADO = autonumeracion.VENCIMIENTO;
                    }   
                }
                
                //Si cambia
                if (campos.Contains(FacturasProveedorService.MonedaId_NombreCol))
                {
                    if (filaFacturaProveedor.MONEDA_ID.Equals(DBNull.Value) || filaFacturaProveedor.MONEDA_ID != (decimal)campos[FacturasProveedorService.MonedaId_NombreCol])
                    {
                        if (!MonedasService.EstaActivo((decimal)campos[FacturasProveedorService.MonedaId_NombreCol]))
                            throw new Exception("La moneda no está activa");

                        filaFacturaProveedor.MONEDA_ID = (decimal)campos[FacturasProveedorService.MonedaId_NombreCol];
                    }   
                }
               

                if (campos.Contains(FacturasProveedorService.DireccionLugarTransaccion_NombreCol))
                {
                    filaFacturaProveedor.DIRECCION_LUGAR_TRANSACCION = (string)campos[FacturasProveedorService.DireccionLugarTransaccion_NombreCol];
                }
                else
                {
                    if (campos.Contains(FacturasProveedorService.SucursalId_NombreCol))
                    {
                        string where = SucursalesService.Id_NombreCol + " = " + (decimal)campos[FacturasProveedorService.SucursalId_NombreCol];
                        SUCURSALESRow sucursal = sesion.Db.SUCURSALESCollection.GetRow(where);
                        filaFacturaProveedor.DIRECCION_LUGAR_TRANSACCION = sucursal.DIRECCION;
                    }
                }

                if (campos.Contains(FacturasProveedorService.MonedaCotizacion_NombreCol))
                {
                    if (filaFacturaProveedor.MONEDA_COTIZACION != (decimal)campos[FacturasProveedorService.MonedaCotizacion_NombreCol])
                        actualizarMovimientos = true;
                    filaFacturaProveedor.MONEDA_COTIZACION = (decimal)campos[FacturasProveedorService.MonedaCotizacion_NombreCol];
                }
                else
                {
                    var cotizacion = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais(filaFacturaProveedor.SUCURSAL_ID), filaFacturaProveedor.MONEDA_ID, filaFacturaProveedor.FECHA, sesion);
                    if (filaFacturaProveedor.MONEDA_COTIZACION != cotizacion)
                        actualizarMovimientos = true;
                    
                    filaFacturaProveedor.MONEDA_COTIZACION = cotizacion;
                    if (filaFacturaProveedor.MONEDA_COTIZACION.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda origen.");
                }

                if (campos.Contains(FacturasProveedorService.MonedaPaisCotizacion_NombreCol))
                {
                    filaFacturaProveedor.MONEDA_PAIS_COTIZACION = (decimal)campos[FacturasProveedorService.MonedaPaisCotizacion_NombreCol];
                }
                else
                { 
                    var sucursal = new SucursalesService(filaFacturaProveedor.SUCURSAL_ID, sesion);
                    if (filaFacturaProveedor.MONEDA_ID == sucursal.Pais.MonedaId)
                        filaFacturaProveedor.MONEDA_PAIS_COTIZACION = filaFacturaProveedor.MONEDA_COTIZACION;
                    else
                        filaFacturaProveedor.MONEDA_PAIS_COTIZACION = CotizacionesService.GetCotizacionMonedaVenta(sucursal.PaisId, sucursal.Pais.MonedaId, filaFacturaProveedor.FECHA_FACTURA);
                }

                // Se guarda el nro de timbrado y comprobante si no existe ya en db una factura de ese proveedor con ese nro de timbrado y comprobante
                if (insertarNuevo)
                {
                    if (filaFacturaProveedor.IsAUTONUMERACION_IDNull)
                    {
                        if (!(campos[FacturasProveedorService.NroTimbrado_NombreCol].ToString() == string.Empty) && !(campos[FacturasProveedorService.NroComprobante_NombreCol].ToString() == string.Empty) && !(campos[FacturasProveedorService.NroTimbrado_NombreCol].ToString() == null) && !(campos[FacturasProveedorService.NroComprobante_NombreCol].ToString() == null))
                        {
                            string clausula = FacturasProveedorService.ProveedorId_NombreCol + " = " + (decimal)campos[FacturasProveedorService.ProveedorId_NombreCol];
                            clausula += " and " + FacturasProveedorService.NroTimbrado_NombreCol + " = '" + (string)campos[FacturasProveedorService.NroTimbrado_NombreCol] + "'";
                            clausula += " and " + FacturasProveedorService.NroComprobante_NombreCol + " = '" + (string)campos[FacturasProveedorService.NroComprobante_NombreCol] + "'";

                            DataTable dtFacturasRepetidas = FacturasProveedorService.GetFacturaProveedorDataTable2(clausula, string.Empty, sesion);
                            if (dtFacturasRepetidas.Rows.Count > 0)
                            {
                                throw new Exception("Ya existe una factura de ese proveedor con ese nro. de timbrado y nro. de comprobante.");
                            }
                            else
                            {
                                filaFacturaProveedor.NRO_COMPROBANTE = (string)campos[FacturasProveedorService.NroComprobante_NombreCol];
                                filaFacturaProveedor.NRO_TIMBRADO = campos[FacturasProveedorService.NroTimbrado_NombreCol].ToString();
                            }
                        }
                        else
                        {
                            /*Permite introducir string.emply al comprobante y al timbrado*/
                            filaFacturaProveedor.NRO_COMPROBANTE = (string)campos[FacturasProveedorService.NroComprobante_NombreCol];
                            filaFacturaProveedor.NRO_TIMBRADO = campos[FacturasProveedorService.NroTimbrado_NombreCol].ToString();
                        }
                    }
                    else
                    {
                        /*Si contiene una autonumeracion*/
                        string clausula = FacturasProveedorService.VistaEntidadId_NombreCol + " = " + sesion.Entidad.ID;
                        clausula += " and " + FacturasProveedorService.AutonumeracionId_NombreCol + " = " + filaFacturaProveedor.AUTONUMERACION_ID;

                        if (campos.Contains(FacturasProveedorService.NroComprobante_NombreCol))
                            clausula += " and " + FacturasProveedorService.NroComprobante_NombreCol + " = '" + campos[FacturasProveedorService.NroComprobante_NombreCol] + "'";

                        clausula += " and " + FacturasProveedorService.VistaCasoEstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "'";

                        DataTable dtFacturasRepetidas = FacturasProveedorService.GetFacturaProveedorInfoCompleta(clausula, string.Empty);

                        if (dtFacturasRepetidas.Rows.Count > 0)
                            throw new Exception("Ya existe una factura de ese proveedor con ese nro. de comprobante");

                        if (campos.Contains(FacturasProveedorService.NroComprobante_NombreCol))
                            filaFacturaProveedor.NRO_COMPROBANTE = (string)campos[FacturasProveedorService.NroComprobante_NombreCol];
                        else
                            filaFacturaProveedor.NRO_COMPROBANTE = string.Empty;

                        filaFacturaProveedor.NRO_TIMBRADO = string.Empty;
                    }
                }
                else
                {
                    if (filaFacturaProveedor.IsAUTONUMERACION_IDNull)
                    {
                        if (campos.Contains(FacturasProveedorService.NroTimbrado_NombreCol))
                        {
                            if (!(campos[FacturasProveedorService.NroTimbrado_NombreCol].ToString() == string.Empty) && !(campos[FacturasProveedorService.NroComprobante_NombreCol].ToString() == string.Empty) && !(campos[FacturasProveedorService.NroTimbrado_NombreCol].ToString() == null) && !(campos[FacturasProveedorService.NroComprobante_NombreCol].ToString() == null))
                            {
                                string clausula = FacturasProveedorService.ProveedorId_NombreCol + " = " + (decimal)campos[FacturasProveedorService.ProveedorId_NombreCol];
                                clausula += " and " + FacturasProveedorService.NroTimbrado_NombreCol + " = '" + (string)campos[FacturasProveedorService.NroTimbrado_NombreCol] + "'";
                                clausula += " and " + FacturasProveedorService.NroComprobante_NombreCol + " = '" + (string)campos[FacturasProveedorService.NroComprobante_NombreCol] + "'";
                                clausula += " and " + FacturasProveedorService.Id_NombreCol + " <> " + (decimal)campos[FacturasProveedorService.Id_NombreCol];

                                DataTable dtFacturasRepetidas = FacturasProveedorService.GetFacturaProveedorDataTable2(clausula, string.Empty, sesion);
                                if (dtFacturasRepetidas.Rows.Count > 0)
                                {
                                    throw new Exception("Ya existe una factura de ese proveedor con ese nro. de timbrado y nro. de comprobante.");
                                }
                                else
                                {
                                    filaFacturaProveedor.NRO_COMPROBANTE = (string)campos[FacturasProveedorService.NroComprobante_NombreCol];
                                    filaFacturaProveedor.NRO_TIMBRADO = campos[FacturasProveedorService.NroTimbrado_NombreCol].ToString();
                                }
                            }
                            else
                            {
                                if (campos.Contains(FacturasProveedorService.NroComprobante_NombreCol))
                                {
                                    /*Permite introducir string.emply al comprobante y al timbrado*/
                                    filaFacturaProveedor.NRO_COMPROBANTE = (string)campos[FacturasProveedorService.NroComprobante_NombreCol];
                                    filaFacturaProveedor.NRO_TIMBRADO = campos[FacturasProveedorService.NroTimbrado_NombreCol].ToString(); 
                                }

                                
                            }  
                        }
                        
                    }
                    else
                    {
                        /*Si contiene una autonumeracion*/
                        string clausula = FacturasProveedorService.VistaEntidadId_NombreCol + " = " + sesion.Entidad.ID;
                        clausula += " and " + FacturasProveedorService.AutonumeracionId_NombreCol + " = " + filaFacturaProveedor.AUTONUMERACION_ID;

                        if (campos.Contains(FacturasProveedorService.NroComprobante_NombreCol))
                            clausula += " and " + FacturasProveedorService.NroComprobante_NombreCol + " = '" + campos[FacturasProveedorService.NroComprobante_NombreCol] + "'";
                        if (campos.Contains(FacturasProveedorService.Id_NombreCol))
                        {
                            clausula += " and " + FacturasProveedorService.Id_NombreCol + " <> " + campos[FacturasProveedorService.Id_NombreCol];
                            clausula += " and " + FacturasProveedorService.VistaCasoEstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "'";  
                        }
                        
                        DataTable dtFacturasRepetidas = FacturasProveedorService.GetFacturaProveedorInfoCompleta(clausula, string.Empty);

                        if (dtFacturasRepetidas.Rows.Count > 0)
                            throw new Exception("Ya existe una factura de ese proveedor con ese nro. de comprobante");

                        if (campos.Contains(FacturasProveedorService.NroComprobante_NombreCol))
                            filaFacturaProveedor.NRO_COMPROBANTE = (string)campos[FacturasProveedorService.NroComprobante_NombreCol];
                        else
                            filaFacturaProveedor.NRO_COMPROBANTE = string.Empty;

                        filaFacturaProveedor.NRO_TIMBRADO = string.Empty;
                    }
                }
                if (campos.Contains(FacturasProveedorService.CentroCostoObligatorio_NombreCol))
                {
                    filaFacturaProveedor.CENTRO_COSTO_OBLIGATORIO = (string)campos[FacturasProveedorService.CentroCostoObligatorio_NombreCol];
                    filaFacturaProveedor.NUMERO_CONTRATO = (string)campos[FacturasProveedorService.NumeroContrato_NombreCol];
                    filaFacturaProveedor.OBSERVACION = (string)campos[FacturasProveedorService.Observacion_NombreCol];
  
                }
                
                if (campos.Contains(FacturasProveedorService.FuncionarioId_NombreCol))
                    filaFacturaProveedor.FUNCIONARIO_ID = (decimal)campos[FacturasProveedorService.FuncionarioId_NombreCol];
                else
                    filaFacturaProveedor.IsFUNCIONARIO_IDNull = true;

                if (campos.Contains(FacturasProveedorService.TipoContenedorId_NombreCol))
                    filaFacturaProveedor.TIPO_CONTENEDOR_ID = (decimal)campos[FacturasProveedorService.TipoContenedorId_NombreCol];
                else
                    filaFacturaProveedor.IsTIPO_CONTENEDOR_IDNull = true;

                if (campos.Contains(FacturasProveedorService.TipoEmbarqueId_NombreCol))
                    filaFacturaProveedor.TIPO_EMBARQUE_ID = (decimal)campos[FacturasProveedorService.TipoEmbarqueId_NombreCol];
                else
                    filaFacturaProveedor.IsTIPO_EMBARQUE_IDNull = true;

                if (campos.Contains(FacturasProveedorService.ImportacionId_NombreCol))
                    filaFacturaProveedor.IMPORTACION_ID = (decimal)campos[FacturasProveedorService.ImportacionId_NombreCol];
                else
                    filaFacturaProveedor.IsIMPORTACION_IDNull = true;

                if (campos.Contains(FacturasProveedorService.EgresoVarioCajaAutonumeracionId_NombreCol))
                    filaFacturaProveedor.EGRESO_VARIO_CAJA_AUTONUM_ID = (decimal)campos[FacturasProveedorService.EgresoVarioCajaAutonumeracionId_NombreCol];

                if (campos.Contains(FacturasProveedorService.EgresoVarioCajaNroComprobante_NombreCol))
                    filaFacturaProveedor.EGRESO_VARIO_CAJA_NRO_COMPR = (string)campos[FacturasProveedorService.EgresoVarioCajaNroComprobante_NombreCol];

                if (campos.Contains(FacturasProveedorService.EgresoVarioCajaFecha_NombreCol))
                    filaFacturaProveedor.EGRESO_VARIO_CAJA_FECHA = (DateTime)campos[FacturasProveedorService.EgresoVarioCajaFecha_NombreCol];
                else
                    filaFacturaProveedor.IsEGRESO_VARIO_CAJA_FECHANull = true;

                if (campos.Contains(FacturasProveedorService.OrdenPagoCtacteBancariaId_NombreCol))
                    filaFacturaProveedor.ORDEN_PAGO_CTACTE_BANCARIA_ID = (decimal)campos[FacturasProveedorService.OrdenPagoCtacteBancariaId_NombreCol];
                else
                    filaFacturaProveedor.IsORDEN_PAGO_CTACTE_BANCARIA_IDNull = true;
                if (campos.Contains(FacturasProveedorService.PasibleRetencion_NombreCol))
                {
                    filaFacturaProveedor.PASIBLE_RETENCION = (string)campos[FacturasProveedorService.PasibleRetencion_NombreCol];
   
                }
                
                // Se asigna el tipo de factura proveedor
                if (campos.Contains(FacturasProveedorService.TipoFacturaProveedorId_NombreCol))
                {
                    // Si se cambia el tipo de factura y la factura anterior era del tipo Gastos de Despacho, se hace null el campo Proveedor Gasto Id
                    if ((decimal)campos[FacturasProveedorService.TipoFacturaProveedorId_NombreCol] != filaFacturaProveedor.TIPO_FACTURA_PROVEEDOR_ID
                                                        && filaFacturaProveedor.TIPO_FACTURA_PROVEEDOR_ID == Definiciones.TipoFacturaProveedor.GastosDeDespacho)
                        filaFacturaProveedor.IsPROVEEDOR_GASTO_IDNull = true;

                    filaFacturaProveedor.TIPO_FACTURA_PROVEEDOR_ID = (decimal)campos[FacturasProveedorService.TipoFacturaProveedorId_NombreCol];
                }
                else
                {
                    if (campos.Count >2)
                    {
                        throw new Exception("Debe definirse el tipo de factura de proveedor");   
                    }
               
                }

                if (campos.Contains(FacturasProveedorService.PagarPorFondoFijo_NombreCol))
                    filaFacturaProveedor.PAGAR_POR_FONDO_FIJO = (string)campos[FacturasProveedorService.PagarPorFondoFijo_NombreCol];
                else
                    if (campos.Count > 2) {
                        throw new Exception("Debe definirse si el origen del pago es el fondo fijo o no");
                    }
                    

                if (campos.Contains(FacturasProveedorService.CtacteFondoFijoId_NombreCol) && filaFacturaProveedor.PAGAR_POR_FONDO_FIJO == Definiciones.SiNo.Si)
                    filaFacturaProveedor.CTACTE_FONDO_FIJO_ID = (decimal)campos[FacturasProveedorService.CtacteFondoFijoId_NombreCol];
                else
                    filaFacturaProveedor.IsCTACTE_FONDO_FIJO_IDNull = true;

                if (filaFacturaProveedor.PAGAR_POR_FONDO_FIJO == Definiciones.SiNo.Si && filaFacturaProveedor.IsCTACTE_FONDO_FIJO_IDNull)
                    throw new Exception("Se marcó pagar por fondo fijo pero no se definió desde cuál.");
                if (campos.Contains(FacturasProveedorService.CasoAsociadoId_NombreCol))
                {
                    if (campos[FacturasProveedorService.CasoAsociadoId_NombreCol].ToString().Equals(string.Empty))
                        filaFacturaProveedor.IsCASO_ASOCIADO_IDNull = true;
                    else
                        filaFacturaProveedor.CASO_ASOCIADO_ID = decimal.Parse(campos[FacturasProveedorService.CasoAsociadoId_NombreCol].ToString());
                }
                //Pagos a terceros
                if (campos.Count > 2)
                {
                    if (campos.Contains(FacturasProveedorService.AfectaCtacteProveedor_NombreCol))
                        filaFacturaProveedor.AFECTA_CTACTE_PROVEEDOR = (string)campos[FacturasProveedorService.AfectaCtacteProveedor_NombreCol];
                    else
                        filaFacturaProveedor.AFECTA_CTACTE_PROVEEDOR = Definiciones.SiNo.Si;

                    if (campos.Contains(FacturasProveedorService.AfectaCtactePersona_NombreCol))
                        filaFacturaProveedor.AFECTA_CTACTE_PERSONA = (string)campos[FacturasProveedorService.AfectaCtactePersona_NombreCol];
                    else
                        filaFacturaProveedor.AFECTA_CTACTE_PERSONA = Definiciones.SiNo.No;

                    if (campos.Contains(FacturasProveedorService.AfectaCreditoFiscalEmpresa_NombreCol))
                        filaFacturaProveedor.AFECTA_CRED_FISCAL_EMPRESA = (string)campos[FacturasProveedorService.AfectaCreditoFiscalEmpresa_NombreCol];
                    else
                        filaFacturaProveedor.AFECTA_CRED_FISCAL_EMPRESA = Definiciones.SiNo.Si;

                    if (campos.Contains(FacturasProveedorService.AfectaCreditoFiscalPersona_NombreCol))
                        filaFacturaProveedor.AFECTA_CRED_FISCAL_PERSONA = (string)campos[FacturasProveedorService.AfectaCreditoFiscalPersona_NombreCol];
                    else
                        filaFacturaProveedor.AFECTA_CRED_FISCAL_PERSONA = Definiciones.SiNo.No;

                    if (campos.Contains(NroDocumentoExterno_NombreCol))
                        filaFacturaProveedor.NRO_DOCUMENTO_EXTERNO = campos[NroDocumentoExterno_NombreCol].ToString();

                    
                
                // Gastos de Despacho
                if (campos.Contains(FacturasProveedorService.ProveedorGastoId_NombreCol))
                    filaFacturaProveedor.PROVEEDOR_GASTO_ID = (decimal)campos[FacturasProveedorService.ProveedorGastoId_NombreCol];
                else
                    filaFacturaProveedor.IsPROVEEDOR_GASTO_IDNull = true;
                if (campos.Contains(FacturasProveedorService.EsTicket_NombreCol))
                {
                    //Es Ticket
                    filaFacturaProveedor.ES_TICKET = (string)campos[FacturasProveedorService.EsTicket_NombreCol];   
                }

                if (campos.Contains(FacturasProveedorService.EsFactElectronica_NombreCol))
                {
                    // Nuevo campo. Es Fact Electronica
                    filaFacturaProveedor.ES_FACT_ELECTRONICA = (string)campos[FacturasProveedorService.EsFactElectronica_NombreCol];
               
                }
                if (campos.Contains(FacturasProveedorService.TipoMovimientoSet_NombreCol))
                {
                    // Nuevo campo. Tipo Movimientos Set
                    filaFacturaProveedor.TIPO_MOVIMIENTO_SET = (string)campos[FacturasProveedorService.TipoMovimientoSet_NombreCol];

                }
                
                if (campos.Contains(FacturasProveedorService.ImputaIva_NombreCol))
                    filaFacturaProveedor.IMPUTA_IVA = (string)campos[FacturasProveedorService.ImputaIva_NombreCol];

                if (campos.Contains(FacturasProveedorService.ImputaIre_NombreCol))
                    filaFacturaProveedor.IMPUTA_IRE = (string)campos[FacturasProveedorService.ImputaIre_NombreCol];

                if (campos.Contains(FacturasProveedorService.TipoComprobanteSet_NombreCol))
                    filaFacturaProveedor.CTB_TIPO_COMPROBANTE_SET_ID = (decimal)campos[FacturasProveedorService.TipoComprobanteSet_NombreCol];

                //Aplicar Prorrareto servicios
                if (campos.Contains(FacturasProveedorService.AplicarProrrateoServicios_NombreCol))
                    filaFacturaProveedor.APLICAR_PRORRATEO_SERVICIOS = (string)campos[FacturasProveedorService.AplicarProrrateoServicios_NombreCol];
                else
                    filaFacturaProveedor.APLICAR_PRORRATEO_SERVICIOS = Definiciones.SiNo.No;

                if (campos.Contains(FacturasProveedorService.PagoContratistaDetalleId_NombreCol))
                    filaFacturaProveedor.PAGO_CONTRATISTA_DETALLE_ID = (decimal)campos[FacturasProveedorService.PagoContratistaDetalleId_NombreCol];
                }
                if (insertarNuevo) sesion.Db.FACTURAS_PROVEEDORCollection.Insert(filaFacturaProveedor);
                else sesion.Db.FACTURAS_PROVEEDORCollection.Update(filaFacturaProveedor);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, filaFacturaProveedor.ID, valorAnterior, filaFacturaProveedor.ToString(), sesion);

                RecalcularTotales(filaFacturaProveedor.ID, sesion);

                #region Actualizar stock movimientos si ya existieron y cambio la fecha o cotizacion
                if (actualizarMovimientos)
                {
                    List<string> lCasos = new List<string>();
                    DataTable dtIngresoStock = IngresoStockService.GetIngresoStockDataTable(IngresoStockService.CasoFcProveedorId_NombreCol + " = " + filaFacturaProveedor.CASO_ID, string.Empty, sesion);
                    if(dtIngresoStock.Rows.Count > 0)
                        lCasos.Add(dtIngresoStock.Rows[0][IngresoStockService.CasoId_NombreCol].ToString());
                    lCasos.Add(filaFacturaProveedor.CASO_ID.ToString());

                    var movimientos = new StockMovimientoService();
                    movimientos.IniciarUsingSesion(sesion);
                    foreach (var sm in movimientos.GetFiltrado<StockMovimientoService>(new Filtro() { Columna = StockMovimientoService.Modelo.CASO_IDColumnName, Valor = string.Join(",", lCasos.ToArray()), Exacto = false }))
                    {
                        sm.IniciarUsingSesion(sesion);
                        sm.FechaFormulario = filaFacturaProveedor.FECHA_FACTURA;
                        sm.CostoCotizacionMonedaOrigen = filaFacturaProveedor.MONEDA_COTIZACION;
                        sm.Guardar();
                        sm.FinalizarUsingSesion();
                    }
                    movimientos.FinalizarUsingSesion();
                }
                #endregion Actualizar stock movimientos si ya existieron y cambio la fecha o cotizacion

                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();
                if (!filaFacturaProveedor.IsFUNCIONARIO_IDNull)
                    camposCaso.Add(CasosService.FuncionarioId_NombreCol, filaFacturaProveedor.FUNCIONARIO_ID);
                if(!filaFacturaProveedor.IsFECHA_FACTURANull)
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, filaFacturaProveedor.FECHA_FACTURA);
                camposCaso.Add(CasosService.NroComprobante_NombreCol, filaFacturaProveedor.NRO_COMPROBANTE);
                if (!Interprete.EsNullODBNull(filaFacturaProveedor.NRO_DOCUMENTO_EXTERNO))
                    camposCaso.Add(CasosService.NroComprobante2_NombreCol, filaFacturaProveedor.NRO_DOCUMENTO_EXTERNO);
                camposCaso.Add(CasosService.ProveedorId_NombreCol, filaFacturaProveedor.PROVEEDOR_ID);
                camposCaso.Add(CasosService.TipoEspecifico_NombreCol, filaFacturaProveedor.TIPO_FACTURA_PROVEEDOR_ID);
                camposCaso.Add(CasosService.SucursalId_NombreCol, filaFacturaProveedor.SUCURSAL_ID);
                CasosService.ActualizarCampos(filaFacturaProveedor.CASO_ID, camposCaso, sesion);
                #endregion Actualizar datos en tabla casos

                return filaFacturaProveedor.ID;
            }
            catch (Exception exp)
            {
                //Si el caso fue creado el mismo debe borrarse
                if (insertarNuevo && filaFacturaProveedor.CASO_ID > 0)
                {
                    (new CasosService()).Eliminar(filaFacturaProveedor.CASO_ID, sesion);
                    caso_id = Definiciones.Error.Valor.EnteroPositivo;
                    estado_id = string.Empty;
                }
                if (exp.Message.Equals("ORA-00001: unique constraint (TRC.UK_FC_PROVEEDOR_NRO_COMPROB) violated"))
                { 
                    throw new Exception("Ya existe el Comprobante " + filaFacturaProveedor.NRO_COMPROBANTE + " Timbrado :" + filaFacturaProveedor.NRO_TIMBRADO);
                }
                throw exp;
            }
        }
        #endregion Guardar

        #region Recalcular totales
        public static void RecalcularTotales(decimal factura_proveedor_id, SessionService sesion)
        {
            try
            {
                FACTURAS_PROVEEDORRow factura = sesion.Db.FACTURAS_PROVEEDORCollection.GetByPrimaryKey(factura_proveedor_id);
                string valorAnterior = factura.ToString();
                DataTable dtDetalles = FacturasProveedorDetalleService.GetFacturaProveedorDetalleDataTable(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + factura_proveedor_id, string.Empty, sesion);
                decimal totalPagoAnterior = factura.TOTAL_PAGO;

                factura.TOTAL_BRUTO = 0;
                factura.TOTAL_DESCUENTO = 0;
                factura.TOTAL_IMPUESTO = 0;
                factura.TOTAL_PAGO = 0;

                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                {
                    factura.TOTAL_BRUTO += (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalBruto_NombreCol];
                    factura.TOTAL_DESCUENTO += (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalDescuento_NombreCol];
                    factura.TOTAL_IMPUESTO += (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol];
                    factura.TOTAL_PAGO += (decimal)dtDetalles.Rows[i][FacturasProveedorDetalleService.TotalPago_NombreCol];
                }

                decimal descuento = factura.TOTAL_PAGO;
                if (factura.PORCENTAJE_DESC_SOBRE_TOTAL != 0)
                    descuento = (factura.TOTAL_PAGO * factura.PORCENTAJE_DESC_SOBRE_TOTAL) / 100;
                
                if (factura.PORCENTAJE_DESC_SOBRE_TOTAL != 0)
                factura.TOTAL_DESCUENTO += descuento;

                factura.TOTAL_IMPUESTO = factura.TOTAL_IMPUESTO * (100 - factura.PORCENTAJE_DESC_SOBRE_TOTAL) / 100;
                
                if (factura.PORCENTAJE_DESC_SOBRE_TOTAL != 0)
                factura.TOTAL_PAGO -= descuento;
                
                sesion.Db.FACTURAS_PROVEEDORCollection.Update(factura);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, factura.ID, valorAnterior, factura.ToString(), sesion);

                if (totalPagoAnterior != factura.TOTAL_PAGO)
                    CalendarioPagosFCProveedorService.ActualizarPagos(factura.ID, factura.FECHA, factura.TOTAL_PAGO, factura.CTACTE_CONDICION_PAGO_ID, sesion);
            }
            catch (Exception)
            {
                throw ;
            }
        }
        #endregion Recalcular totales

        #region Actualizar Condicion de Pagos
        /// <summary>
        /// Actualizars the condicion pagos.
        /// </summary>
        /// <param name="factura_id">The factura_id.</param>
        /// <param name="condicion_pago_id">The condicion_pago_id.</param>
        public void ActualizarCondicionPagos(decimal factura_id, decimal condicion_pago_id)
        {
            using (SessionService sesion = new SessionService())
            {

                try
                {
                    string anterior = string.Empty;
                    sesion.Db.BeginTransaction();
                    FACTURAS_PROVEEDORRow factura = sesion.Db.FACTURAS_PROVEEDORCollection.GetByPrimaryKey(factura_id);

                    anterior = factura.ToString();
                    factura.CTACTE_CONDICION_PAGO_ID = condicion_pago_id;
                    sesion.Db.FACTURAS_PROVEEDORCollection.Update(factura);
                    LogCambiosService.LogDeRegistro(FacturasProveedorService.Nombre_Tabla, factura.ID, anterior, factura.ToString(), sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Actualizar Condicion de Pagos

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
                    FACTURAS_PROVEEDORRow factura = sesion.Db.FACTURAS_PROVEEDORCollection.GetByCASO_ID(caso_id)[0];

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) && !caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        exito = false;
                        mensaje = "El caso no puede ser eliminado en el estado " + caso.ESTADO_ID ;
                    }

                    //Borrar los detalles
                    if (exito)
                    {
                        DataTable dt = FacturasProveedorDetalleService.GetFacturaProveedorDetalleDataTable(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + factura.ID, string.Empty, sesion);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            FacturasProveedorDetalleService.Borrar((decimal)dt.Rows[i][FacturasProveedorDetalleService.Id_NombreCol]);
                        }
                    }

                    //Borrar calendario pago
                    if (exito)
                    {
                        DataTable dt = CalendarioPagosFCProveedorService.GetCalendariosPagosPorFactura(factura.ID);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            CalendarioPagosFCProveedorService.Borrar((decimal)dt.Rows[i][CalendarioPagosFCProveedorService.Id_NombreCol], sesion);
                        }
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.FACTURAS_PROVEEDORCollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, factura.ID, factura.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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
        #endregion Borrar

        #region Crear Cabecera
        public static PropiedadesCabecera CrearCabecera(decimal sucursalId, decimal depositoId, decimal personaId, DateTime fecha, decimal moneda_id, string observacion, string nroTimbrado, DateTime fechaVencimientoTimbrado, string nroComprobante, decimal casoId, ref decimal facturaProveedorCasoId, ref decimal facturaProveedorId, decimal condicionPagoId, decimal porcentaje_descuento, bool afecta_ctacte, SessionService sesion)
        {

            FacturasProveedorService.PropiedadesCabecera fcProveedorCabecera;

            //se obtiene el id del proveedor/persona
            string clausula = ProveedoresService.PersonaId_NombreCol + " = " + personaId;
            DataTable proveedorDt = ProveedoresService.GetProveedoresInfoCompleta2(clausula, string.Empty, true);
            fcProveedorCabecera = new FacturasProveedorService.PropiedadesCabecera();

            if (proveedorDt.Rows.Count >= 1)
            {
                fcProveedorCabecera.DepositoId = depositoId;
                fcProveedorCabecera.FechaEntrega_yyyymmdd = fecha.ToString("yyyyMMdd");
                fcProveedorCabecera.FechaFactura_yyyymmdd = fcProveedorCabecera.FechaEntrega_yyyymmdd;
                fcProveedorCabecera.FechaPedido_yyyymmdd = fcProveedorCabecera.FechaEntrega_yyyymmdd;
                fcProveedorCabecera.MonedaId = moneda_id;
                fcProveedorCabecera.NroComprobante = nroComprobante;
                fcProveedorCabecera.NroTimbrado = nroTimbrado;
                fcProveedorCabecera.FechaVencimientoTimbrado_yyyymmdd = fechaVencimientoTimbrado.ToString("yyyyMMdd");
                fcProveedorCabecera.Observaciones = observacion;
                fcProveedorCabecera.ProveedorId = decimal.Parse(proveedorDt.Rows[0][ProveedoresService.Id_NombreCol].ToString());
                fcProveedorCabecera.SucursalId = sucursalId;
                fcProveedorCabecera.TipoFacturaId = Definiciones.TipoFacturaProveedor.CompraArticulos;
                fcProveedorCabecera.UsarFechaFactura = true;
                fcProveedorCabecera.CasoAsociadoId = casoId;
                fcProveedorCabecera.CondicionPagoId = condicionPagoId;
                fcProveedorCabecera.PorcentajeDescuento = porcentaje_descuento;
                fcProveedorCabecera.AfectaCtacteProveedor = afecta_ctacte;

                facturaProveedorCasoId = FacturasProveedorService.Crear(fcProveedorCabecera, out facturaProveedorId, sesion);
            }

            return fcProveedorCabecera;
        }
        #endregion Crear Cabecera

        #region Crear
        public static decimal Crear(PropiedadesCabecera cabecera, out decimal factura_proveedor_id, SessionService sesion)
        {
            try
            {
                decimal casoId = Definiciones.Error.Valor.EnteroPositivo;
                string estadoId = Definiciones.Error.Valor.EnteroPositivo.ToString();
                DateTime fechaPedido, fechaFactura, fechaEntrega, fechaVencimientoTimbrado;
                System.Collections.Hashtable campos = new System.Collections.Hashtable();

                #region Cabecera
                campos.Add(FacturasProveedorService.SucursalId_NombreCol, cabecera.SucursalId);
                campos.Add(FacturasProveedorService.ProveedorId_NombreCol, cabecera.ProveedorId);
                campos.Add(FacturasProveedorService.StockDepositoId_NombreCol, cabecera.DepositoId);
                campos.Add(FacturasProveedorService.CtacteCondicionPagoId_NombreCol, cabecera.CondicionPagoId);
                if (cabecera.CasoAsociadoId != Definiciones.Error.Valor.EnteroPositivo)
                    campos.Add(FacturasProveedorService.CasoAsociadoId_NombreCol, cabecera.CasoAsociadoId);
                fechaPedido = DateTime.ParseExact(cabecera.FechaPedido_yyyymmdd, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                campos.Add(FacturasProveedorService.Fecha_NombreCol, fechaPedido);
                if (cabecera.UsarFechaFactura)
                {
                    fechaFactura = DateTime.ParseExact(cabecera.FechaFactura_yyyymmdd, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                    campos.Add(FacturasProveedorService.FechaFactura_NombreCol, fechaFactura);
                }
                if (cabecera.UsarFechaEntrega)
                {
                    fechaEntrega = DateTime.ParseExact(cabecera.FechaEntrega_yyyymmdd, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                    campos.Add(FacturasProveedorService.FechaRecepcion_NombreCol, fechaEntrega);
                }

                fechaVencimientoTimbrado = DateTime.ParseExact(cabecera.FechaVencimientoTimbrado_yyyymmdd, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                if (fechaVencimientoTimbrado.Equals(DateTime.MinValue))
                    fechaVencimientoTimbrado = fechaPedido;

                if (cabecera.FuncionarioId != Definiciones.Error.Valor.EnteroPositivo)
                    campos.Add(FacturasProveedorService.FuncionarioId_NombreCol, cabecera.FuncionarioId);

                campos.Add(FacturasProveedorService.FechaVencimientoTimbrado_NombreCol, fechaVencimientoTimbrado);
                campos.Add(FacturasProveedorService.EsTicket_NombreCol, Definiciones.SiNo.No);
                campos.Add(FacturasProveedorService.MonedaId_NombreCol, cabecera.MonedaId);
                campos.Add(FacturasProveedorService.NumeroContrato_NombreCol, cabecera.NroContrato);
                campos.Add(FacturasProveedorService.NroComprobante_NombreCol, cabecera.NroComprobante);
                campos.Add(FacturasProveedorService.NroTimbrado_NombreCol, cabecera.NroTimbrado);
                campos.Add(FacturasProveedorService.NroDocumentoExterno_NombreCol, cabecera.NroDocumentoExterno);
                campos.Add(FacturasProveedorService.Observacion_NombreCol, cabecera.Observaciones);
                if (cabecera.TipoEmbarqueId != Definiciones.Error.Valor.EnteroPositivo)
                    campos.Add(FacturasProveedorService.TipoEmbarqueId_NombreCol, cabecera.TipoEmbarqueId);
                if (cabecera.ImportacionId != Definiciones.Error.Valor.EnteroPositivo)
                    campos.Add(FacturasProveedorService.ImportacionId_NombreCol, cabecera.ImportacionId);
                campos.Add(FacturasProveedorService.TipoFacturaProveedorId_NombreCol, cabecera.TipoFacturaId);
                campos.Add(FacturasProveedorService.CtacteFondoFijoId_NombreCol, cabecera.CtacteFondoFijoId);
                campos.Add(FacturasProveedorService.CentroCostoObligatorio_NombreCol, cabecera.CentroCostoObligatorio ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(FacturasProveedorService.PagarPorFondoFijo_NombreCol, cabecera.PagarPorFondoFijo ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(FacturasProveedorService.PasibleRetencion_NombreCol, cabecera.PasibleRetencion ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(FacturasProveedorService.AfectaCtacteProveedor_NombreCol, cabecera.AfectaCtacteProveedor ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(FacturasProveedorService.AfectaCtactePersona_NombreCol, cabecera.AfectarCtactePersona ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(FacturasProveedorService.AfectaCreditoFiscalEmpresa_NombreCol, cabecera.AfectarCreditoFiscalEmpresa ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(FacturasProveedorService.AfectaCreditoFiscalPersona_NombreCol, cabecera.AfectarCreditoFiscalPersona ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol, cabecera.PorcentajeDescuento);

                factura_proveedor_id = FacturasProveedorService.Guardar(campos, true, ref casoId, ref estadoId, sesion);
                #endregion Cabecera

                return casoId;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Crear

        #region VerificarFacturasPendientes
        public static bool VerificarFacturasPendientes(DateTime fecha, decimal proveedorId)
        {
            string clausula = FacturasProveedorService.VistaCasoEstadoId_NombreCol + " in ('" + Definiciones.EstadosFlujos.Borrador + "', '" + Definiciones.EstadosFlujos.Pendiente + "')" + " and " + FacturasProveedorService.FechaFactura_NombreCol + " < " + "to_date('" + fecha.ToShortDateString() + "', 'dd/mm/yyyy')" + " and " + FacturasProveedorService.ProveedorId_NombreCol + " = " + proveedorId;
            DataTable dt = GetFacturaProveedorInfoCompleta(clausula, string.Empty);

            if (dt.Rows.Count > 0) return true;
            else return false;
        }
        #endregion VerificarFacturasPendientes

        #region VerificarPuedeAvanzarEstado
        public static bool VerificarPuedeAvanzarEstado(decimal caso_id, out string mensaje, SessionService sesion)
        {
            return FlujosService.VerificarPuedeAvanzarEstado(caso_id, out mensaje, "FC PROVEEDOR NO CONTROLAR MARGEN DIAS PUEDE AVANZAR", Definiciones.VariablesDeSistema.FCProveedorMargenDiasPuedeAvanzar, sesion);
        }
        #endregion VerificarPuedeAvanzarEstado

        #region VincularFacturaOrdenServicio
        public static void VincularFacturaOrdenServicio(decimal casoFacturaProveedor, decimal casoOrdenServicio, SessionService sesion)
        {
            FACTURAS_PROVEEDORRow factura = sesion.Db.FACTURAS_PROVEEDORCollection.GetRow(FacturasProveedorService.CasoId_NombreCol  + " = " + casoFacturaProveedor);
            factura.CASO_ASOCIADO_ID = casoOrdenServicio;
            sesion.Db.FACTURAS_PROVEEDORCollection.Update(factura);
        }
        #endregion VincularFacturaOrdenServicio

        #region DesvincularFacturaOrdenServicio
        public static void DesvincularFacturaOrdenServicio(decimal casoFacturaProveedor, decimal casoOrdenServicio, SessionService sesion)
        {
            FACTURAS_PROVEEDORRow factura = sesion.Db.FACTURAS_PROVEEDORCollection.GetRow(FacturasProveedorService.CasoId_NombreCol + " = " + casoFacturaProveedor);
            factura.IsCASO_ASOCIADO_IDNull = true;
            sesion.Db.FACTURAS_PROVEEDORCollection.Update(factura);
        }
        #endregion DesvincularFacturaOrdenServicio

        #region DesvincularCasoCredito
        public static void DesvincularCasosCreditos(decimal casoFacturaProveedorId, SessionService sesion)
        {
            CREDITOSRow[] creditos = sesion.Db.CREDITOSCollection.GetByCASO_ASOCIADO_ID(casoFacturaProveedorId);

            for (int i = 0; i < creditos.Length; i++)
            {
                creditos[i].IsCASO_ASOCIADO_IDNull = true;
                sesion.Db.CREDITOSCollection.Update(creditos[i]);
            }
        }
        #endregion DesvincularCasoCredito

        #region Generar Factura Proveedor
        public static decimal GenerarFacturaProveedor(Hashtable datos, decimal totalSaldo)
        {
            decimal casoId = Definiciones.Error.Valor.EnteroPositivo;
            try
            {
                bool exito = true;

                #region CARGAR CABECERA DE LA FACTURA
                System.Collections.Hashtable campos = new System.Collections.Hashtable();
                campos.Add(FacturasProveedorService.SucursalId_NombreCol, (decimal)datos[FacturasProveedorService.SucursalId_NombreCol]);
                campos.Add(FacturasProveedorService.ProveedorId_NombreCol, (decimal)datos[FacturasProveedorService.ProveedorId_NombreCol]);

                if (datos.Contains(FacturasProveedorService.FuncionarioId_NombreCol))
                    campos.Add(FacturasProveedorService.FuncionarioId_NombreCol, datos[FacturasProveedorService.FuncionarioId_NombreCol]);

                if (datos.Contains(FacturasProveedorService.StockDepositoId_NombreCol))
                {
                    campos.Add(FacturasProveedorService.StockDepositoId_NombreCol, (decimal)datos[FacturasProveedorService.StockDepositoId_NombreCol]);
                }
                else
                {
                    DataTable dtDepositos = StockDepositosService.GetStockDepositosDataTable2((decimal)datos[FacturasProveedorService.SucursalId_NombreCol]);

                    if (dtDepositos.Rows.Count == 0)
                        throw new Exception("No existe un deposito habilitado para esta sucursal");
                    else
                        campos.Add(FacturasProveedorService.StockDepositoId_NombreCol, (decimal)dtDepositos.Rows[0][StockDepositosService.Id_NombreCol]);
                }

                if (datos.Contains(FacturasProveedorService.NroComprobante_NombreCol) && datos[FacturasProveedorService.NroComprobante_NombreCol].ToString() != string.Empty)
                    campos.Add(FacturasProveedorService.NroComprobante_NombreCol, "FP-" + datos[FacturasProveedorService.NroComprobante_NombreCol]);
                else
                    campos.Add(FacturasProveedorService.NroComprobante_NombreCol, string.Empty);

                if (datos.Contains(FacturasProveedorService.NroTimbrado_NombreCol) && datos[FacturasProveedorService.NroTimbrado_NombreCol].ToString() != string.Empty)
                    campos.Add(FacturasProveedorService.NroTimbrado_NombreCol, datos[FacturasProveedorService.NroTimbrado_NombreCol]);
                else
                    campos.Add(FacturasProveedorService.NroTimbrado_NombreCol, string.Empty);
                

                if (datos.Contains(FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol))
                    campos.Add(FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol, (decimal)datos[FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol]);
                else
                    campos.Add(FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol, 0);

                if (datos.Contains(FacturasProveedorService.TipoFacturaProveedorId_NombreCol))
                    campos.Add(FacturasProveedorService.TipoFacturaProveedorId_NombreCol, (decimal)datos[FacturasProveedorService.TipoFacturaProveedorId_NombreCol]);
                else
                    campos.Add(FacturasProveedorService.TipoFacturaProveedorId_NombreCol, Definiciones.TipoFacturaProveedor.Gastos);

                campos.Add(FacturasProveedorService.CtacteCondicionPagoId_NombreCol, datos[FacturasProveedorService.CtacteCondicionPagoId_NombreCol]);
                campos.Add(FacturasProveedorService.Fecha_NombreCol, datos[FacturasProveedorService.FechaFactura_NombreCol]);
                campos.Add(FacturasProveedorService.FechaFactura_NombreCol, datos[FacturasProveedorService.FechaFactura_NombreCol]);
                campos.Add(FacturasProveedorService.FechaVencimientoTimbrado_NombreCol, datos[FacturasProveedorService.FechaFactura_NombreCol]);
                campos.Add(FacturasProveedorService.MonedaId_NombreCol, datos[FacturasProveedorService.MonedaId_NombreCol]);
                campos.Add(FacturasProveedorService.NumeroContrato_NombreCol, string.Empty);

                /*Obs= Se genera un comentario con el caso desde donde se genere la factura si desde un credito o anticipo*/
                if (datos.Contains(FacturasProveedorService.Observacion_NombreCol) && datos.Contains(CasosService.Id_NombreCol))
                    campos.Add(FacturasProveedorService.Observacion_NombreCol, "Factura de proveedor generada desde el caso: " + datos[CasosService.Id_NombreCol].ToString());
                else if (datos.Contains(FacturasProveedorService.Observacion_NombreCol))
                    campos.Add(FacturasProveedorService.Observacion_NombreCol, datos[FacturasProveedorService.Observacion_NombreCol].ToString());
                else
                    campos.Add(FacturasProveedorService.Observacion_NombreCol, string.Empty);

                if (datos.Contains(FacturasProveedorService.CasoAsociadoId_NombreCol))
                {
                    campos.Add(FacturasProveedorService.CasoAsociadoId_NombreCol, decimal.Parse(datos[FacturasProveedorService.CasoAsociadoId_NombreCol].ToString()));
                }

                campos.Add(FacturasProveedorService.NroDocumentoExterno_NombreCol, string.Empty);
                campos.Add(FacturasProveedorService.CtacteFondoFijoId_NombreCol, Definiciones.Error.Valor.EnteroPositivo);
                campos.Add(FacturasProveedorService.PagarPorFondoFijo_NombreCol, Definiciones.SiNo.No);
                campos.Add(FacturasProveedorService.PasibleRetencion_NombreCol, Definiciones.SiNo.No);
                campos.Add(FacturasProveedorService.AfectaCtacteProveedor_NombreCol, Definiciones.SiNo.Si);
                campos.Add(FacturasProveedorService.AfectaCtactePersona_NombreCol, Definiciones.SiNo.No);
                campos.Add(FacturasProveedorService.AfectaCreditoFiscalEmpresa_NombreCol, Definiciones.SiNo.Si);
                campos.Add(FacturasProveedorService.EsTicket_NombreCol, Definiciones.SiNo.No);
                campos.Add(FacturasProveedorService.CentroCostoObligatorio_NombreCol, Definiciones.SiNo.No);

                #endregion

                if (exito)
                {
                    #region GUARDAR CABECERA
                    decimal vCasoId = Definiciones.Error.Valor.EnteroPositivo;
                    string vCasoEstado = string.Empty;
                    string clausulas;
                    FacturasProveedorService.Guardar(campos, true, ref vCasoId, ref vCasoEstado);
                    DataTable registroActual = new DataTable();

                    clausulas = FacturasProveedorService.CasoId_NombreCol + " = " + vCasoId;

                    casoId = vCasoId;

                    registroActual = FacturasProveedorService.GetFacturaProveedorDataTable2(clausulas, string.Empty);

                    #endregion

                    #region CARGAR DETALLES DE LA FACTURA
                    System.Collections.Hashtable camposDetalle = new System.Collections.Hashtable();

                    camposDetalle.Add(FacturasProveedorDetalleService.TipoDetalle_NombreCol, (decimal)Definiciones.TiposDetalleFacturaProveedor.Estandar);
                    camposDetalle.Add(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol, registroActual.Rows[0][FacturasProveedorService.Id_NombreCol]);
                    camposDetalle.Add(FacturasProveedorDetalleService.UnidadIdDestino_NombreCol, Definiciones.UnidadesMedida.Simbolo.Unidades);
                    camposDetalle.Add(FacturasProveedorDetalleService.TextoPredefinidoId_NombreCol, (decimal)datos[FacturasProveedorDetalleService.TextoPredefinidoId_NombreCol]);

                    if (datos.Contains(FacturasProveedorService.Observacion_NombreCol))
                        camposDetalle.Add(FacturasProveedorDetalleService.Observacion_NombreCol, datos[FacturasProveedorDetalleService.Observacion_NombreCol]);
                    else
                        camposDetalle.Add(FacturasProveedorDetalleService.Observacion_NombreCol, string.Empty);

                    if (datos.Contains(FacturasProveedorDetalleService.ImpuestoId_NombreCol))
                        camposDetalle.Add(FacturasProveedorDetalleService.ImpuestoId_NombreCol, (decimal)datos[FacturasProveedorDetalleService.ImpuestoId_NombreCol]);
                    else
                        camposDetalle.Add(FacturasProveedorDetalleService.ImpuestoId_NombreCol, Definiciones.Impuestos.Exenta);

                    if(datos.Contains(FacturasProveedorDetalleService.PorcentajeDescuento_NombreCol))
                        camposDetalle.Add(FacturasProveedorDetalleService.PorcentajeDescuento_NombreCol, (decimal)datos[FacturasProveedorDetalleService.PorcentajeDescuento_NombreCol]);
                    else
                        camposDetalle.Add(FacturasProveedorDetalleService.PorcentajeDescuento_NombreCol, 0);

                    camposDetalle.Add(FacturasProveedorDetalleService.PrecioBrutoUnitarioDestino_NombreCol, (decimal)totalSaldo);
                    camposDetalle.Add(FacturasProveedorDetalleService.CantidadEmbaladaDestino_NombreCol, 0);
                    camposDetalle.Add(FacturasProveedorDetalleService.CantidadUnidadDestino_NombreCol, 1);
                    #endregion 

                    #region GUARDAR DETALLES Y VALIDAR EXITO
                    if (FacturasProveedorDetalleService.Guardar(camposDetalle).Equals(Definiciones.Error.Valor.EnteroPositivo))
                    {
                        exito = false;
                    }

                    if (exito)
                    {
                        CalendarioPagosFCProveedorService.ActualizarPagos((decimal)registroActual.Rows[0][FacturasProveedorService.Id_NombreCol], (DateTime)datos[FacturasProveedorService.FechaFactura_NombreCol], (decimal)totalSaldo, Definiciones.CondicionPago.Contado);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return casoId;
        }
        #endregion Generar Factura Proveedor

        #region GetExisteNroComprobante
        private static bool GetExisteNroComprobante(decimal factura_id, decimal autonumeracion_id, string nro_comprobante, SessionService sesion)
        {
            bool existe = false;
            string clausulas = FacturasProveedorService.NroComprobante_NombreCol + " = '" + nro_comprobante + "' " +
                 " and " + FacturasProveedorService.Id_NombreCol + " <> " + factura_id;

            if (!autonumeracion_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                clausulas += " and " + FacturasProveedorService.AutonumeracionId_NombreCol + " = " + autonumeracion_id;

            FACTURAS_PROVEEDOR_INFO_COMPRow[] rows = sesion.Db.FACTURAS_PROVEEDOR_INFO_COMPCollection.GetAsArray(clausulas, string.Empty);

            existe = rows.Length > 0;

            return existe;
        }
        #endregion GetExisteNroComprobante

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "FACTURAS_PROVEEDOR"; }
        }
        public static string Nombre_Vista
        {
            get { return "FACTURAS_PROVEEDOR_INFO_COMP"; }
        }
        public static string AfectaCreditoFiscalEmpresa_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.AFECTA_CRED_FISCAL_EMPRESAColumnName; }
        }
        public static string AfectaCreditoFiscalPersona_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.AFECTA_CRED_FISCAL_PERSONAColumnName; }
        }
        public static string AfectaCtactePersona_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.AFECTA_CTACTE_PERSONAColumnName; }
        }
        public static string AfectaCtacteProveedor_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.AFECTA_CTACTE_PROVEEDORColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.AUTONUMERACION_IDColumnName;}
        }
        public static string CantidadContenedores_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.CANTIDAD_CONTENEDORESColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.CASO_IDColumnName; }
        }
        public static string CentroCostoObligatorio_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.CENTRO_COSTO_OBLIGATORIOColumnName; }
        }
        public static string CtacteCondicionPagoId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.CTACTE_CONDICION_PAGO_IDColumnName; }
        }
        public static string CtacteFondoFijoId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.CTACTE_FONDO_FIJO_IDColumnName; }
        }
        public static string DireccionLugarTransaccion_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.DIRECCION_LUGAR_TRANSACCIONColumnName; }
        }
        public static string EstadoDocumentacionId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.ESTADO_DOCUMENTACION_IDColumnName; }
        }
        public static string EgresoVarioCajaAutonumeracionId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.EGRESO_VARIO_CAJA_AUTONUM_IDColumnName; }
        }
        public static string EgresoVarioCajaNroComprobante_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.EGRESO_VARIO_CAJA_NRO_COMPRColumnName; }
        }
        public static string EgresoVarioCajaFecha_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.EGRESO_VARIO_CAJA_FECHAColumnName; }
        }
        public static string FechaFactura_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.FECHA_FACTURAColumnName; }
        }
        public static string FechaRecepcion_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.FECHA_RECEPCIONColumnName; }
        }
        public static string FechaVencimientoTimbrado_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.FECHA_VENCIMIENTO_TIMBRADOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.FECHAColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.IDColumnName; }
        }
        public static string MonedaCotizacion_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.MONEDA_COTIZACIONColumnName; }
        }
        public static string MonedaPaisCotizacion_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.MONEDA_PAIS_COTIZACIONColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.MONEDA_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string NroDocumentoExterno_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.NRO_DOCUMENTO_EXTERNOColumnName; }
        }
        public static string NumeroContrato_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.NUMERO_CONTRATOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.OBSERVACIONColumnName; }
        }
        public static string OrdenPagoCtacteBancariaId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.ORDEN_PAGO_CTACTE_BANCARIA_IDColumnName; }
        }
        public static string PagoContratistaDetalleId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.PAGO_CONTRATISTA_DETALLE_IDColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.PROVEEDOR_IDColumnName; }
        }
        public static string ProveedorGastoId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.PROVEEDOR_GASTO_IDColumnName; }
        }
        public static string PagarPorFondoFijo_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.PAGAR_POR_FONDO_FIJOColumnName; }
        }
        public static string StockDepositoId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.STOCK_DEPOSITO_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.SUCURSAL_IDColumnName; }
        }
        public static string TipoContenedorId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.TIPO_CONTENEDOR_IDColumnName; }
        }
        public static string TipoEmbarqueId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.TIPO_EMBARQUE_IDColumnName; }
        }
        public static string TotalBruto_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.TOTAL_BRUTOColumnName; }
        }
        public static string TotalDescuento_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.TOTAL_DESCUENTOColumnName; }
        }
        public static string TotalImpuesto_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.TOTAL_IMPUESTOColumnName; }
        }
        public static string TotalPago_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.TOTAL_PAGOColumnName; }
        }
        public static string RubroId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.RUBRO_IDColumnName; }
        }
        public static string ImportacionId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.IMPORTACION_IDColumnName; }
        }
        public static string CentroCostoId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string NroTimbrado_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.NRO_TIMBRADOColumnName; }
        }
        public static string PasibleRetencion_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.PASIBLE_RETENCIONColumnName; }
        }
        public static string TipoFacturaProveedorId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.TIPO_FACTURA_PROVEEDOR_IDColumnName; }
        }
        public static string CasoAsociadoId_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.CASO_ASOCIADO_IDColumnName; }
        }
        public static string PorcentajeDescSobreTotal_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.PORCENTAJE_DESC_SOBRE_TOTALColumnName; }
        }
        public static string EsTicket_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.ES_TICKETColumnName; }
        }
        public static string EsFactElectronica_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.ES_FACT_ELECTRONICAColumnName; }
        }
        public static string AplicarProrrateoServicios_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.APLICAR_PRORRATEO_SERVICIOSColumnName; }
        }
        public static string TipoMovimientoSet_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.TIPO_MOVIMIENTO_SETColumnName; }
        }
        public static string TipoComprobanteSet_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.CTB_TIPO_COMPROBANTE_SET_IDColumnName; }
        }
        public static string ImputaIva_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.IMPUTA_IVAColumnName; }
        }
        public static string ImputaIre_NombreCol
        {
            get { return FACTURAS_PROVEEDORCollection.IMPUTA_IREColumnName; }
        }
        #endregion Tabla
        
        #region Vista
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaProveedorNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.PROVEEDOR_NOMBREColumnName; }
        }
        public static string VistaProveedorGastoNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.PROVEEDOR_GASTO_NOMBREColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaStockDepositoAbreviatura_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.STOCK_DEPOSITO_ABREVIATURAColumnName; }
        }
        public static string VistaStockDepositoNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.STOCK_DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaCtacteCondicionPagoNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.CTACTE_CONDICION_PAGO_NOMBREColumnName; }
        }
        public static string VistaEstadoDocumentacionNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.ESTADO_DOCUMENTACION_NOMBREColumnName; }
        }
        public static string VistaTipoContenedorNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.TIPO_CONTENEDOR_NOMBREColumnName; }
        }
        public static string VistaTipoEmbarqueNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.TIPO_EMBARQUE_NOMBREColumnName; }
        }
        public static string VistaEntidadId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.ENTIDAD_IDColumnName; }
        }
        public static string VistaRubroNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.RUBRO_NOMBREColumnName; }
        }
        public static string VistaPorcentajeProrrateoImportacion_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.PORC_PROR_IMPORTColumnName; }
        }
        public static string VistaTipoFacturaProveedorNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.TIPO_FACTURA_PROVEEDOR_NOMBREColumnName; }
        }
        public static string VistaCasoAsociadoId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_INFO_COMPCollection.CASO_ASOCIADO_IDColumnName; }
        }
        #endregion Vista

        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static FacturasProveedorService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new FacturasProveedorService(e.RegistroId, sesion);
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
        protected FACTURAS_PROVEEDORRow row;
        protected FACTURAS_PROVEEDORRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string AfectaCredFiscalEmpresa { get { return GetStringHelper(row.AFECTA_CRED_FISCAL_EMPRESA); } set { row.AFECTA_CRED_FISCAL_EMPRESA = value; } }
        public string AfectaCredFiscalPersona { get { return GetStringHelper(row.AFECTA_CRED_FISCAL_PERSONA); } set { row.AFECTA_CRED_FISCAL_PERSONA = value; } }
        public string AfectaCtactePersona { get { return GetStringHelper(row.AFECTA_CTACTE_PERSONA); } set { row.AFECTA_CTACTE_PERSONA = value; } }
        public string AfectaCtacteProveedor { get { return GetStringHelper(row.AFECTA_CTACTE_PROVEEDOR); } set { row.AFECTA_CTACTE_PROVEEDOR = value; } }
        public string AplicarProrrateo { get { return GetStringHelper(row.APLICAR_PRORRATEO_SERVICIOS); } set { row.APLICAR_PRORRATEO_SERVICIOS = value; } }
        public decimal? AutonumeracionId { get { if (row.IsAUTONUMERACION_IDNull) return null; else return row.AUTONUMERACION_ID; } set { if (value.HasValue) row.AUTONUMERACION_ID = value.Value; else row.IsAUTONUMERACION_IDNull = true; } }
        public decimal? CantidadContenedores { get { if (row.IsCANTIDAD_CONTENEDORESNull) return null; else return row.CANTIDAD_CONTENEDORES; } set { if (value.HasValue) row.CANTIDAD_CONTENEDORES = value.Value; else row.IsCANTIDAD_CONTENEDORESNull = true; } }
        public decimal? CasoAsociadoId { get { if (row.IsCASO_ASOCIADO_IDNull) return null; else return row.CASO_ASOCIADO_ID; } set { if (value.HasValue) row.CASO_ASOCIADO_ID = value.Value; else row.IsCASO_ASOCIADO_IDNull = true; } }
        public decimal CasoId { get { return row.CASO_ID; } set { row.CASO_ID = value; } }
        public decimal? CentroCostoId { get { if (row.IsCENTRO_COSTO_IDNull) return null; else return row.CENTRO_COSTO_ID; } set { if (value.HasValue) row.CENTRO_COSTO_ID = value.Value; else row.IsCENTRO_COSTO_IDNull = true; } }
        public string CentroCostoObligatorio { get { return GetStringHelper(row.CENTRO_COSTO_OBLIGATORIO); } set { row.CENTRO_COSTO_OBLIGATORIO = value; } }
        public decimal CtacteCondicionPagoId { get { return row.CTACTE_CONDICION_PAGO_ID; } set { row.CTACTE_CONDICION_PAGO_ID = value; } }
        public decimal? CtacteFondoFijoId { get { if (row.IsCTACTE_FONDO_FIJO_IDNull) return null; else return row.CTACTE_FONDO_FIJO_ID; } set { if (value.HasValue) row.CTACTE_FONDO_FIJO_ID = value.Value; else row.IsCTACTE_FONDO_FIJO_IDNull = true; } }
        public string DireccionLugarTransaccion { get { return GetStringHelper(row.DIRECCION_LUGAR_TRANSACCION); } set { row.DIRECCION_LUGAR_TRANSACCION = value; } }
        public decimal? EgresoVarioCajaAutonum { get { if (row.IsEGRESO_VARIO_CAJA_AUTONUM_IDNull) return null; else return row.EGRESO_VARIO_CAJA_AUTONUM_ID; } set { if (value.HasValue) row.EGRESO_VARIO_CAJA_AUTONUM_ID = value.Value; else row.IsEGRESO_VARIO_CAJA_AUTONUM_IDNull = true; } }
        public DateTime? EgresoVarioCajaFecha { get { if (row.IsEGRESO_VARIO_CAJA_FECHANull) return null; else return row.EGRESO_VARIO_CAJA_FECHA; } set { if (value.HasValue) row.EGRESO_VARIO_CAJA_FECHA = value.Value; else row.IsEGRESO_VARIO_CAJA_FECHANull = true; } }
        public string EgresoVarioCajaNroCompr { get { return GetStringHelper(row.EGRESO_VARIO_CAJA_NRO_COMPR); } set { row.EGRESO_VARIO_CAJA_NRO_COMPR = value; } }
        public string EsTicket { get { return GetStringHelper(row.ES_TICKET); } set { row.ES_TICKET = value; } }
        public decimal? EstadoDocumentacionId { get { if (row.IsESTADO_DOCUMENTACION_IDNull) return null; else return row.ESTADO_DOCUMENTACION_ID; } set { if (value.HasValue) row.ESTADO_DOCUMENTACION_ID = value.Value; else row.IsESTADO_DOCUMENTACION_IDNull = true; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public DateTime? FechaFactura { get { if (row.IsFECHA_FACTURANull) return null; else return row.FECHA_FACTURA; } set { if (value.HasValue) row.FECHA_FACTURA = value.Value; else row.IsFECHA_FACTURANull = true; } }
        public DateTime? FechaRecepcion { get { if (row.IsFECHA_RECEPCIONNull) return null; else return row.FECHA_RECEPCION; } set { if (value.HasValue) row.FECHA_RECEPCION = value.Value; else row.IsFECHA_RECEPCIONNull = true; } }
        public DateTime FechaVencimientoTimbrado { get { return row.FECHA_VENCIMIENTO_TIMBRADO; } set { row.FECHA_VENCIMIENTO_TIMBRADO = value; } }
        public decimal? FuncionarioId { get { if (row.IsFUNCIONARIO_IDNull) return null; else return row.FUNCIONARIO_ID; } set { if (value.HasValue) row.FUNCIONARIO_ID = value.Value; else row.IsFUNCIONARIO_IDNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? ImportacionId { get { if (row.IsIMPORTACION_IDNull) return null; else return row.IMPORTACION_ID; } set { if (value.HasValue) row.IMPORTACION_ID = value.Value; else row.IsIMPORTACION_IDNull = true; } }
        public decimal MonedaCotizacion { get { return row.MONEDA_COTIZACION; } set { row.MONEDA_COTIZACION = value; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal MonedaPaisCotizacion { get { return row.MONEDA_PAIS_COTIZACION; } set { row.MONEDA_PAIS_COTIZACION = value; } }
        public string NroComprobante { get { return GetStringHelper(row.NRO_COMPROBANTE); } set { row.NRO_COMPROBANTE = value; } }
        public string NroDocumentoExterno { get { return GetStringHelper(row.NRO_DOCUMENTO_EXTERNO); } set { row.NRO_DOCUMENTO_EXTERNO = value; } }
        public string NroTimbrado { get { return GetStringHelper(row.NRO_TIMBRADO); } set { row.NRO_TIMBRADO = value; } }
        public string NumeroContrato { get { return GetStringHelper(row.NUMERO_CONTRATO); } set { row.NUMERO_CONTRATO = value; } }
        public string Observacion { get { return GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal? OrdenPagoCtacteBancariaId { get { if (row.IsORDEN_PAGO_CTACTE_BANCARIA_IDNull) return null; else return row.ORDEN_PAGO_CTACTE_BANCARIA_ID; } set { if (value.HasValue) row.ORDEN_PAGO_CTACTE_BANCARIA_ID = value.Value; else row.IsORDEN_PAGO_CTACTE_BANCARIA_IDNull = true; } }
        public string PagarPorFondoFijo { get { return GetStringHelper(row.PAGAR_POR_FONDO_FIJO); } set { row.PAGAR_POR_FONDO_FIJO = value; } }
        public decimal? PagoContratistaDetalleId { get { if (row.IsPAGO_CONTRATISTA_DETALLE_IDNull) return null; else return row.PAGO_CONTRATISTA_DETALLE_ID; } set { if (value.HasValue) row.PAGO_CONTRATISTA_DETALLE_ID = value.Value; else row.IsPAGO_CONTRATISTA_DETALLE_IDNull = true; } }
        public string PasibleRetencion { get { return GetStringHelper(row.PASIBLE_RETENCION); } set { row.PASIBLE_RETENCION = value; } }
        public decimal PorcentajeDescSobreTotal { get { return row.PORCENTAJE_DESC_SOBRE_TOTAL; } set { row.PORCENTAJE_DESC_SOBRE_TOTAL = value; } }
        public decimal? ProveedorGastoId { get { if (row.IsPROVEEDOR_GASTO_IDNull) return null; else return row.PROVEEDOR_GASTO_ID; } set { if (value.HasValue) row.PROVEEDOR_GASTO_ID = value.Value; else row.IsPROVEEDOR_GASTO_IDNull = true; } }
        public decimal ProveedorId { get { return row.PROVEEDOR_ID; } set { row.PROVEEDOR_ID = value; } }
        public decimal? RubroId { get { if (row.IsRUBRO_IDNull) return null; else return row.RUBRO_ID; } set { if (value.HasValue) row.RUBRO_ID = value.Value; else row.IsRUBRO_IDNull = true; } }
        public decimal StockDepositoId { get { return row.STOCK_DEPOSITO_ID; } set { row.STOCK_DEPOSITO_ID = value; } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } set { row.SUCURSAL_ID = value; } }
        public decimal? TipoContenedorId { get { if (row.IsTIPO_CONTENEDOR_IDNull) return null; else return row.TIPO_CONTENEDOR_ID; } set { if (value.HasValue) row.TIPO_CONTENEDOR_ID = value.Value; else row.IsTIPO_CONTENEDOR_IDNull = true; } }
        public decimal? TipoEmbarqueId { get { if (row.IsTIPO_EMBARQUE_IDNull) return null; else return row.TIPO_EMBARQUE_ID; } set { if (value.HasValue) row.TIPO_EMBARQUE_ID = value.Value; else row.IsTIPO_EMBARQUE_IDNull = true; } }
        public decimal TipoFacturaProveedorId { get { return row.TIPO_FACTURA_PROVEEDOR_ID; } set { row.TIPO_FACTURA_PROVEEDOR_ID = value; } }
        public decimal? TotalBruto { get { if (row.IsTOTAL_BRUTONull) return null; else return row.TOTAL_BRUTO; } set { if (value.HasValue) row.TOTAL_BRUTO = value.Value; else row.IsTOTAL_BRUTONull = true; } }
        public decimal? TotalDescuento { get { if (row.IsTOTAL_DESCUENTONull) return null; else return row.TOTAL_DESCUENTO; } set { if (value.HasValue) row.TOTAL_DESCUENTO = value.Value; else row.IsTOTAL_DESCUENTONull = true; } }
        public decimal? TotalImpuesto { get { if (row.IsTOTAL_IMPUESTONull) return null; else return row.TOTAL_IMPUESTO; } set { if (value.HasValue) row.TOTAL_IMPUESTO = value.Value; else row.IsTOTAL_IMPUESTONull = true; } }
        public decimal? TotalPago { get { if (row.IsTOTAL_PAGONull) return null; else return row.TOTAL_PAGO; } set { if (value.HasValue) row.TOTAL_PAGO = value.Value; else row.IsTOTAL_PAGONull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
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

        private CondicionesPagoService _ctacte_condicion_pago;
        public CondicionesPagoService CtacteCondicionPago
        {
            get
            {
                if (this._ctacte_condicion_pago == null)
                {
                    if (this.sesion != null)
                        this._ctacte_condicion_pago = new CondicionesPagoService(this.CtacteCondicionPagoId, this.sesion);
                    else
                        this._ctacte_condicion_pago = new CondicionesPagoService(this.CtacteCondicionPagoId);
                }
                return this._ctacte_condicion_pago;
            }
        }

        private CuentaCorrienteFondosFijosService _ctacte_fondo_fijo;
        public CuentaCorrienteFondosFijosService CtacteFondoFijo
        {
            get
            {
                if (this._ctacte_fondo_fijo == null)
                {
                    if (this.sesion != null)
                        this._ctacte_fondo_fijo = new CuentaCorrienteFondosFijosService(this.CtacteFondoFijoId.Value, this.sesion);
                    else
                        this._ctacte_fondo_fijo = new CuentaCorrienteFondosFijosService(this.CtacteFondoFijoId.Value);
                }
                return this._ctacte_fondo_fijo;
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
                        this._funcionario = new FuncionariosService(this.FuncionarioId.Value, this.sesion);
                    else
                        this._funcionario = new FuncionariosService(this.FuncionarioId.Value);
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
                {
                    if (this.sesion != null)
                        this._moneda = new MonedasService(this.MonedaId, this.sesion);
                    else
                        this._moneda = new MonedasService(this.MonedaId);
                }
                return this._moneda;
            }
        }

        private ProveedoresService _proveedor;
        public ProveedoresService Proveedor
        {
            get
            {
                if (this._proveedor == null)
                {
                    if (this.sesion != null)
                        this._proveedor = new ProveedoresService(this.ProveedorId, this.sesion);
                    else
                        this._proveedor = new ProveedoresService(this.ProveedorId);
                }
                return this._proveedor;
            }
        }

        private StockDepositosService _stock_deposito;
        public StockDepositosService StockDeposito
        {
            get
            {
                if (this._stock_deposito == null)
                {
                    if (this.sesion != null)
                        this._stock_deposito = new StockDepositosService(this.StockDepositoId, this.sesion);
                    else
                        this._stock_deposito = new StockDepositosService(this.StockDepositoId);
                }
                return this._stock_deposito;
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

        #region Propiedades OneToMany
        private FacturasProveedorDetalleService[] _factura_proveedor_detalles;
        public FacturasProveedorDetalleService[] FacturaProveedorDetalles
        {
            get
            {
                if (this._factura_proveedor_detalles == null)
                    this._factura_proveedor_detalles = FacturasProveedorDetalleService.GetPorCabecera(this.Id.Value);
                return this._factura_proveedor_detalles;
            }
        }
        #endregion Propiedades OneToMany

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.FACTURAS_PROVEEDORCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new FACTURAS_PROVEEDORRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(FACTURAS_PROVEEDORRow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public FacturasProveedorService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public FacturasProveedorService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public FacturasProveedorService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        public FacturasProveedorService(EdiCBA.FacturaProveedor edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = FacturasProveedorService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            this.CasoId = edi.caso_id;
            
            #region condicion pago
            if (!string.IsNullOrEmpty(edi.condicion_pago_uuid))
                this._ctacte_condicion_pago = CondicionesPagoService.GetPorUUID(edi.condicion_pago_uuid, sesion);
            if (this._ctacte_condicion_pago == null && edi.condicion_pago != null)
                this._ctacte_condicion_pago = new CondicionesPagoService(edi.condicion_pago, almacenar_localmente, sesion);
            if (this._ctacte_condicion_pago == null)
                throw new Exception("No se encontró el UUID " + edi.condicion_pago_uuid + " ni se definieron los datos del objeto.");
            
            if(!this.CtacteCondicionPago.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.CtacteCondicionPago.Id.HasValue)
                this.CtacteCondicionPagoId = this.CtacteCondicionPago.Id.Value;
            #endregion condicion pago
            
            if(edi.cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion'.");
            this.MonedaCotizacion = edi.cotizacion.venta;
            
            if (edi.cotizacion_moneda_pais == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion_moneda_pais'.");
            this.MonedaPaisCotizacion = edi.cotizacion_moneda_pais.venta;

            #region deposito
            if (!string.IsNullOrEmpty(edi.deposito_uuid))
                this._stock_deposito = StockDepositosService.GetPorUUID(edi.deposito_uuid, sesion);
            if (this._stock_deposito == null && edi.deposito != null)
                this._stock_deposito = new StockDepositosService(edi.deposito, almacenar_localmente, sesion);
            if (this._stock_deposito == null)
                throw new Exception("No se encontró el UUID " + edi.deposito_uuid + " ni se definieron los datos del objeto.");

            if (!this.StockDeposito.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.StockDeposito.Id.HasValue)
                this.StockDepositoId = this.StockDeposito.Id.Value;
            #endregion deposito

            this.Fecha = edi.fecha;
            this.FechaFactura = edi.fecha;
            if(edi.fecha_vencimiento_timbrado.HasValue)
                this.FechaVencimientoTimbrado = edi.fecha_vencimiento_timbrado.Value;
            
            #region moneda
            if (!string.IsNullOrEmpty(edi.moneda_uuid))
                this._moneda = MonedasService.GetPorUUID(edi.moneda_uuid, sesion);
           
            if (this._moneda == null)
                throw new Exception("No se encontró el UUID " + edi.moneda_uuid + " ni se definieron los datos del objeto.");

            if (!this.Moneda.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Moneda.Id.HasValue)
                this.MonedaId = this.Moneda.Id.Value;
            #endregion moneda
            
            this.NroComprobante = edi.nro_comprobante;
            this.NroDocumentoExterno = edi.nro_comprobante_externo;
            this.NroTimbrado = edi.nro_timbrado;
            this.Observacion = edi.observacion;
            
            #region proveedor
            if (!string.IsNullOrEmpty(edi.proveedor_uuid))
                this._proveedor = ProveedoresService.GetPorUUID(edi.proveedor_uuid, sesion);
            if (this._proveedor == null && edi.proveedor != null)
                this._proveedor = new ProveedoresService(edi.proveedor, almacenar_localmente, sesion);
            if (this._proveedor == null)
                throw new Exception("No se encontró el UUID " + edi.proveedor_uuid + " ni se definieron los datos del objeto.");

            if (!this.Proveedor.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Proveedor.Id.HasValue)
                this.ProveedorId = this.Proveedor.Id.Value;
            #endregion proveedor

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

            #region funcionario
            if (!string.IsNullOrEmpty(edi.funcionario_uuid))
                this._funcionario = FuncionariosService.GetPorUUID(edi.funcionario_uuid, sesion);
            if (this._funcionario == null && edi.funcionario != null)
                this._funcionario = new FuncionariosService(edi.funcionario, almacenar_localmente, sesion);
            if (this._funcionario != null)
            {
                if (!this.Funcionario.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.Funcionario.Id.HasValue)
                    this.FuncionarioId = this.Funcionario.Id.Value;
            }
            #endregion funcionario

            this.TipoFacturaProveedorId = edi.tipo_factura;
            this.EsTicket = edi.es_ticket ? Definiciones.SiNo.Si : Definiciones.SiNo.No;

            this.AfectaCredFiscalEmpresa = Definiciones.SiNo.Si;
            this.AfectaCredFiscalPersona = Definiciones.SiNo.No;
            this.AfectaCtactePersona = Definiciones.SiNo.No;
            this.AfectaCtacteProveedor = Definiciones.SiNo.Si;

            this.TotalBruto = edi.total_bruto;
            this.TotalDescuento = edi.total_descuento;
            this.TotalImpuesto = edi.total_impuesto;
            this.TotalPago = edi.total_neto;

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
                this.Caso.FlujoId = Definiciones.FlujosIDs.FACTURACION_PROVEEDOR;
                this.Caso.NroComprobante2 = edi.nro_comprobante_externo;
            }
            #endregion caso
        }
        private FacturasProveedorService(FACTURAS_PROVEEDORRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCaso
        public static FacturasProveedorService GetPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCaso(caso_id, sesion);
            }
        }

        public static FacturasProveedorService GetPorCaso(decimal caso_id, SessionService sesion)
        {
            var row = sesion.db.FACTURAS_PROVEEDORCollection.GetByCASO_ID(caso_id)[0];
            return new FacturasProveedorService(row);
        }
        #endregion GetPorCaso

       
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
