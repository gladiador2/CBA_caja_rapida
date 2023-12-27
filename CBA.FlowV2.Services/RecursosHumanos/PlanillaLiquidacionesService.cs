#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.RecursosHumanos;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotasDebitoPersona;
using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.ToolbarFlujo;
using System.Text;
using System.Net;
using System.IO;
#endregion Using

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class PlanillaLiquidacionesService : FlujosServiceBaseWorkaround
    {
        #region Clase Webmethods
        private static class Webmethods
        {
            #region Clase EnviarRecibos
            public static class EnviarRecibos
            {
                public static bool Enviar(decimal planilla_liquidacion_id, out string mensaje, SessionService sesion)
                {
                    bool exito = true;
                    mensaje = string.Empty;

                    switch (Convert.ToInt32(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.Cliente)))
                    {
                        case Definiciones.Clientes.Documenta:
                            exito = Cliente_13(planilla_liquidacion_id, out mensaje, sesion);
                            break;
                    }

                    return exito;
                }

                #region Cliente_13
                public static bool Cliente_13(decimal planilla_liquidacion_id, out string mensaje, SessionService sesion)
                {
                    decimal parametroId = Definiciones.Error.Valor.EnteroPositivo;

                    try
                    {
                        bool exito = false;
                        mensaje = string.Empty;

                        DataTable dtCabecera = PlanillaLiquidacionesService.GetInfoCompleta(PlanillaLiquidacionesService.Id_NombreCol + " = " + planilla_liquidacion_id, string.Empty, sesion);
                        DataTable dtDetalles = PlanillaLiquidacionesDetallesService.GetDataTable(planilla_liquidacion_id, sesion);
                        if (dtDetalles.Rows.Count <= 0)
                        {
                            mensaje = "La liquidación no tiene detalles.";
                            return false;
                        }

                        var comprobantes = new Hashtable[dtDetalles.Rows.Count];
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            var email = string.Empty;
                            var funcionario = new FuncionariosService((decimal)dtDetalles.Rows[i][PlanillaLiquidacionesDetallesService.FuncionarioId_NombreCol], sesion);
                            if (funcionario.Email1.Length > 0)
                                email = funcionario.Email1;
                            else if (funcionario.Email2.Length > 0)
                                email = funcionario.Email2;
                            else if (funcionario.Email3.Length > 0)
                                email = funcionario.Email3;

                            var dtEmpresaCargosFuncionario = EmpresaCargosFuncionariosService.GetEmpresaCargosFuncionariosInfoCompleta(funcionario.Id.Value, sesion);

                            comprobantes[i] = new Hashtable 
                            {
                                { "nombre", funcionario.Nombre + " " + funcionario.Apellido },
                                { "email", email },
                                { "cedula", funcionario.NumeroDocumento },
                                { "sucursal", funcionario.Sucursal.Nombre },
                                { "departamento", dtEmpresaCargosFuncionario.Rows.Count > 0 ? (string)dtEmpresaCargosFuncionario.Rows[0][EmpresaCargosFuncionariosService.VistaEmpresaDepartamentoId_NombreCol] : string.Empty },
                                { "seccion", dtEmpresaCargosFuncionario.Rows.Count > 0 ? (string)dtEmpresaCargosFuncionario.Rows[0][EmpresaCargosFuncionariosService.VistaEmpresaSeccionesNombre_NombreCol] : string.Empty },
                                { "firmaFuncionario", false },
                                { "fechaFirmaFuncionario", null },
                                { "firmaEmpresa", false },
                                { "fechaFirmaEmpresa", null },
                                { "uri", string.Empty },
                                { "idEmpresa", (int)10 },
                                { "idLiquidacion", null },
                                { "tokenTransaccion", null },
                                { "anulado", false },
                                { "codigoLiquidacion", (string)dtCabecera.Rows[0][PlanillaLiquidacionesService.NroComprobante_NombreCol] },
                                { "base64", string.Empty },
                            };
                        }

                        var valores = new Hashtable
                        {
                            { "codigo", (string)dtCabecera.Rows[0][PlanillaLiquidacionesService.NroComprobante_NombreCol] },
                            { "totalFuncionarios", dtDetalles.Rows.Count },
                            { "idEmpresa", (int)10 },
                            { "empresa", "Documenta" },
                            { "anhoPago", ((DateTime)dtCabecera.Rows[0][PlanillaLiquidacionesService.FechaDesde_NombreCol]).Year.ToString("0000") },
                            { "mesPago", ((DateTime)dtCabecera.Rows[0][PlanillaLiquidacionesService.FechaDesde_NombreCol]).Month.ToString("00")},
                            { "comprobantes", comprobantes },
                        };

                        string valoresJson = JsonUtil.Serializar(valores);

                        parametroId = WebservicesParametrosService.Guardar(
                                                         Definiciones.Error.Valor.EnteroPositivo,
                                                         "webresources/bills/insertbill",
                                                         valoresJson,
                                                         string.Empty,
                                                         true);

                        byte[] dataStream = Encoding.UTF8.GetBytes(valoresJson);

                        WebRequest req = WebRequest.Create("http://ws.documenta.com.py:8099/gfdc/api/liquidaciones/insertarLiquidacion");
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
                            default: throw new Exception("EnviarRecibos. Código de respuesta no implementado.");
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
            #endregion Clase EnviarRecibos
        }
        #endregion Clase Webmethods

        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.PLANILLA_LIQUIDACIONES;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var drCabecera = (DataRow)caso_cabecera;
            var drDetalle = (DataRow)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, drDetalle[PlanillaLiquidacionesDetallesService.FuncionarioId_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);

            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Obtener el numero de comprobante
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns>String con el numero de comprobante</returns>
        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            PLANILLA_LIQUIDACIONESRow row = sesion.Db.PLANILLA_LIQUIDACIONESCollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE;
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
                    PLANILLA_LIQUIDACIONESRow cabeceraRow = sesion.Db.PLANILLA_LIQUIDACIONESCollection.GetByCASO_ID(caso_id)[0];
                    PLANILLA_LIQUIDACIONES_DETRow[] detalleRow = sesion.Db.PLANILLA_LIQUIDACIONES_DETCollection.GetByPLANILLA_ID(cabeceraRow.ID);

                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Se borran los detalles al anular la planilla
                        for (int i = 0; i < detalleRow.Length; i++)
                            PlanillaLiquidacionesDetallesService.Borrar(detalleRow[i].ID, sesion);

                        exito = true;
                        revisarRequisitos = true;
                       
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //Obtener el numero de comprobante

                        exito = true;
                        revisarRequisitos = true;
                        if (exito && cabeceraRow.NRO_COMPROBANTE == null)
                        {
                            try
                            {
                                cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, sesion);

                                //Controlar que se logro asignar una numeracion
                                if (cabeceraRow.NRO_COMPROBANTE.Equals(""))
                                {
                                    exito = false;
                                    mensaje = "No se pudo asignar una numeración válida";
                                }
                            }
                            catch (Exception exp)
                            {
                                mensaje = exp.Message.ToString();
                                exito = false;
                            }
                        }
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        //Acciones
                        //ninguna.
                       
                        exito = true;
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Se borran los detalles al anular la planilla
                        for (int i = 0; i < detalleRow.Length; i++)
                            PlanillaLiquidacionesDetallesService.Borrar(detalleRow[i].ID, sesion);
                        
                        exito = true;
                        revisarRequisitos = true;
               
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //Ninguna
                        if (cabeceraRow.NRO_COMPROBANTE != null)
                        {
                            exito = true;
                        }
                        else
                        {
                            exito = false;
                            mensaje = "Debe asignar un número de comprobante";
                        }

                        revisarRequisitos = true;
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //Revisar que no existan Ordenes de Pago fuera del estado Anulado
                        #region Aprobado a Pendiente
                        exito = true;
                        revisarRequisitos = true;

                        string clausulas = OrdenesPagoDetalleService.CasoReferidoId_NombreCol + " = " + cabeceraRow.CASO_ID;
                        List<string> casosOp = new List<string>();
                        DataTable dtOrdenPagoDet = OrdenesPagoDetalleService.GetOrdenesPagoDetallesDataTable2(clausulas, string.Empty, sesion);
                        for (int i = 0; i < dtOrdenPagoDet.Rows.Count; i++)
                        {
                            clausulas = OrdenesPagoService.Id_NombreCol + " = " + dtOrdenPagoDet.Rows[i][OrdenesPagoDetalleService.OrdenPagoId_NombreCol];
                            DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoInfoCompleta(clausulas, string.Empty, sesion);

                            if (dtOrdenPago.Rows.Count > 0 && (string)dtOrdenPago.Rows[0][OrdenesPagoService.VistaCasoEstadoId_NombreCol] != Definiciones.EstadosFlujos.Anulado)
                                casosOp.Add(dtOrdenPago.Rows[0][OrdenesPagoService.CasoId_NombreCol].ToString());
                        }

                        if (casosOp.Count == 1)
                            throw new Exception("La Orden de Pago caso " + casosOp[0] + " está vinculada a la Planilla.");
                        else if (casosOp.Count > 1)
                            throw new Exception("Las Órdenes de Pago " + string.Join(", ", casosOp.ToArray()) + " están vinculadas a la Planilla.");
                        #endregion Aprobado a Pendiente
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //ninguna.
                        #region Aprobado a Cerrado
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
                        DataTable dtLiquidacionesDetalles;
                        for (int i = 0; i < detalleRow.Length; i++)
                        {
                            dtLiquidacionesDetalles = (new FuncionariosLiquidacionesDetallesService()).GetLiquidacionesDetallesDataTable(detalleRow[i].LIQUIDACION_ID, Definiciones.TipoItemLiquidacion.CtaCte);
                            for (int j = 0; j < dtLiquidacionesDetalles.Rows.Count; j++)
                            {
                                #region declaracion de variables
                                DataTable dtCtactePersona;
                                decimal saldo;
                                decimal montoAPagar = (decimal)dtLiquidacionesDetalles.Rows[j][FuncionariosLiquidacionesDetallesService.Monto_NombreCol];
                                decimal ctacteId = (decimal)dtLiquidacionesDetalles.Rows[j][FuncionariosLiquidacionesDetallesService.ItemId_NombreCol];
                                DataTable dtCtactePersonaDet;
                                Hashtable montoPorImpuesto;
                                decimal[] impuestoId, monto;
                                int indiceAux;
                                decimal montoVerificacion;
                                string clausulas;
                                #endregion declaracion de variables

                                clausulas = CuentaCorrientePersonasService.Id_NombreCol + " = " + ctacteId;
                                dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(clausulas, string.Empty, sesion);

                                #region Calcular monto por tipo de impuesto
                                montoPorImpuesto = new System.Collections.Hashtable();
                                dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable(ctacteId, sesion);

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
                                    monto[indiceAux] = (decimal)par.Value / Math.Max((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol], (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol]) * montoAPagar;

                                    montoVerificacion += monto[indiceAux];

                                    indiceAux++;
                                }

                                if (Math.Round(montoAPagar, 4) != Math.Round(montoVerificacion, 4))
                                    throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.ConfirmarDocumentos(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + montoAPagar + ".");
                                #endregion Calcular monto por tipo de impuesto

                                #region AgregarDebito
                                //Ingresar el debito
                                CuentaCorrientePersonasService.AgregarDebito((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.PersonaId_NombreCol],
                                                            (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Id_NombreCol],
                                                            Definiciones.CuentaCorrienteConceptos.DebitoPorPago,
                                                            Definiciones.CuentaCorrienteValores.Efectivo, //Se agrega efectivo por completar el dato simplemente
                                                            cabeceraRow.CASO_ID,
                                                            (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.MonedaId_NombreCol],
                                                            (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CotizacionMoneda_NombreCol],
                                                            impuestoId,
                                                            monto,
                                                            string.Empty,
                                                            cabeceraRow.FECHA_DESDE,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            sesion);

                                #endregion AgregarDebito

                                #region Control de Saldo
                                //Saldo antes del pago actual
                                saldo = (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol] -
                                        (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol];

                                //Saldo luego del pago actual
                                saldo -= montoAPagar;

                                //Desbloquear la ctacte
                                CuentaCorrientePersonasService.SetBloqueado(ctacteId, false, sesion);

                                //Si es FC, ND o credito de clientes, el saldo es cero y no existe otros movimientos con saldo debe cerrarse el caso pagado
                                if (!dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaFlujoId_NombreCol].Equals(DBNull.Value) &&
                                    !dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CtaCteConceptoId_NombreCol].Equals(Definiciones.CuentaCorrienteConceptos.Recargo) &&
                                     Math.Round(saldo, 4) == 0 && dtCtactePersona.Rows.Count < 1)
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
                                #endregion Control de Saldo
                            }
                        }
                        #endregion Aprobado a Cerrado
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Cerrado) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        #region Cerrado a Aprobado
                        if (cambio_pedido_por_usuario)
                        {
                            exito = false;
                            mensaje = "Solo el sistema puede utilizar la transición 'Cerrado' -> 'Aprobado'.";
                        }
                        else
                        {
                            exito = true;
                        }

                        for (int i = 0; i < detalleRow.Length; i++)
                        {
                            DataTable dtLiquidacionesDetalles;
                            dtLiquidacionesDetalles = (new FuncionariosLiquidacionesDetallesService()).GetLiquidacionesDetallesDataTable(detalleRow[i].LIQUIDACION_ID, Definiciones.TipoItemLiquidacion.CtaCte);
                            for (int j = 0; j < dtLiquidacionesDetalles.Rows.Count; j++)
                            {
                                decimal ctacteId = (decimal)dtLiquidacionesDetalles.Rows[j][FuncionariosLiquidacionesDetallesService.ItemId_NombreCol];
                                //en teoría este método ya realiza la reversión de estado del caso de la ctacte
                                CuentaCorrientePersonasService.DeshacerAgregarDebito(Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo, sesion, ctacteId);
                            }
                        }
                        #endregion Cerrado a Aprobado
                    }
                    
                    //Verificar si se cumplen los requisitos
                    if (exito && revisarRequisitos)
                    {
                        exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                    }

                    if (exito)
                    {
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.PLANILLA_LIQUIDACIONESCollection.Update(cabeceraRow);
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

        #endregion Implementacion de metodos abstract

        #region GetPlanilaLiquidacionesDataTable

        /// <summary>
        /// Gets the planila liquidaciones data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPlanilaLiquidacionesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PLANILLA_LIQUIDACIONESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPlanilaLiquidacionesDataTable

        #region GetInfoCompleta

        /// <summary>
        /// Gets the planila liquidaciones info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.PLANILLA_LIQ_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        }

        #endregion GetInfoCompleta

        #region GetPlanillaLiquidacionesPorCaso
        /// <summary>
        /// Gets the planilla liquidaciones por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetPlanillaLiquidacionesPorCaso(Decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PLANILLA_LIQ_INFO_COMPLCollection.GetAsDataTable(PlanillaLiquidacionesService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }

        public static DataTable GetPlanillaLiquidacionesPorCasoStatic(Decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PLANILLA_LIQ_INFO_COMPLCollection.GetAsDataTable(PlanillaLiquidacionesService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetPlanillaLiquidacionesPorCaso

        #region GetPlanilaLiquidacionesPorRangoDeFechasTipoLiquidacion

        public static DataTable GetPlanilaLiquidacionesPorRangoDeFechasTipoLiquidacion(DateTime fecha_inicio, DateTime fecha_hasta, decimal tipoPlanilla)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = "TO_DATE(" + FechaDesde_NombreCol + ",'DD/MM/YY')" + ">=" + "TO_DATE('" + fecha_inicio.ToShortDateString()  + "','DD/MM/YY')" +
                                    " and " + "TO_DATE(" + FechaHasta_NombreCol + ",'DD/MM/YY')" + "<=" + "TO_DATE('" + fecha_hasta.ToShortDateString() + "','DD/MM/YY')"+
                                    " and " + PlanillaLiquidacionesService.Tipo_NombreCol+" = "+tipoPlanilla;

                return sesion.Db.PLANILLA_LIQ_INFO_COMPLCollection.GetAsDataTable(clausula, FechaDesde_NombreCol);
            }
        }
        #endregion

        #region CrearCasosOrdenPago
        public static bool CrearCasosOrdenPagoPlanillaLiquidacion(decimal planillaLiquidacionId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    bool exito = true;
                    
                    // Se obtiene la planilla y el caso
                    PLANILLA_LIQUIDACIONESRow planillaRow = sesion.db.PLANILLA_LIQUIDACIONESCollection.GetByPrimaryKey(planillaLiquidacionId);
                    CASOSRow casoRow = sesion.db.CASOSCollection.GetByPrimaryKey(planillaRow.CASO_ID);

                    // La planilla debe estar en aprobado
                    if (!casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado))
                        throw new Exception("El caso debe estar en APROBADO para generar la OP.");

                    // El monto de la planilla no debe ser cero
                    if (planillaRow.TOTAL == 0)
                        throw new Exception("La orden de pago no puede ser creada porque el monto de la planilla es cero.");

                    // Se crea OP del tipo Pago a Funcionarios                    
                                        
                    int tipoOP = Definiciones.TiposOrdenesPago.PagoFuncionarios;
                    bool opCreada = false;

                    // Se traen las liquidaciones que esten asociadas a los detalles de esta planilla y que no tengan casos asociados                    
                    DataTable dtPlanillaLiqDetalles = PlanillaLiquidacionesDetallesService.GetDataTable(planillaRow.ID, sesion);
                    string detalles = string.Empty;
                    foreach (DataRow row in dtPlanillaLiqDetalles.Rows)
                        detalles += row[PlanillaLiquidacionesDetallesService.LiquidacionID_NombreCol].ToString() + ",";

                    detalles = detalles.Substring(0, detalles.Length - 1);
                    string clausulas = FuncionariosLiquidacionesService.Id_NombreCol + " in (" + detalles + ") and " +
                                       FuncionariosLiquidacionesService.CasoAsociadoId_NombreCol + " is null";

                    DataTable dtLiquidaciones = FuncionariosLiquidacionesService.GetLiquidacionesInfoCompletaDataTable2(clausulas, string.Empty, sesion);
                    decimal caso_id = Definiciones.Error.Valor.EnteroPositivo;
                    string estado_id = string.Empty;
                    decimal orden_pago_id = Definiciones.Error.Valor.EnteroPositivo;

                    // Para cada liquidacion, si orden_pago_id es null (campo de la vista) y si aun no se creo la OP (bandera), se crea la op y se flipea la bandera
                    // Se crean tantos detalles en la OP como liquidaciones hay
                    for (int i = 0; i < dtLiquidaciones.Rows.Count; i++)
                    {
                        if (dtLiquidaciones.Rows[i][FuncionariosLiquidacionesService.VistaOrdenPagoId_NombreCol].Equals(DBNull.Value))
                        {
                            if (!opCreada)
                            {
                                Hashtable campos = new Hashtable();

                                campos.Add(OrdenesPagoService.SucursalOrigenId_NombreCol, planillaRow.SUCURSAL_ID);
                                campos.Add(OrdenesPagoService.Fecha_NombreCol, DateTime.Now);
                                campos.Add(OrdenesPagoService.OrdenPagoTipoId_NombreCol, tipoOP);
                                campos.Add(OrdenesPagoService.MonedaId_NombreCol, planillaRow.MONEDA_ID);
                                campos.Add(OrdenesPagoService.CotizacionMoneda_NombreCol, planillaRow.COTIZACION);
                                campos.Add(OrdenesPagoService.MontoTotal_NombreCol, 0);
                                campos.Add(OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol, planillaRow.CTACTECAJATESORERIA_ID);
                                campos.Add(OrdenesPagoService.Observacion_NombreCol, "Planilla de Liquidación - Caso Nº " + planillaRow.CASO_ID.ToString());

                                OrdenesPagoService.Guardar(campos, true, ref caso_id, ref estado_id, sesion);

                                opCreada = true;

                                DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoDataTable(OrdenesPagoService.CasoId_NombreCol + " = " + caso_id, string.Empty);
                                orden_pago_id = (decimal)dtOrdenPago.Rows[0][OrdenesPagoService.Id_NombreCol];
                            }

                            // Se crean los detalles de la OP
                            Hashtable camposDet = new Hashtable();

                            camposDet.Add(OrdenesPagoDetalleService.OrdenPagoId_NombreCol, orden_pago_id);
                            camposDet.Add(OrdenesPagoDetalleService.SucursalDestinoId_NombreCol, planillaRow.SUCURSAL_ID);
                            camposDet.Add(OrdenesPagoDetalleService.MonedaOrigenId_NombreCol, dtLiquidaciones.Rows[i][FuncionariosLiquidacionesService.MonedaId_NombreCol]);
                            camposDet.Add(OrdenesPagoDetalleService.MontoOrigen_NombreCol, dtLiquidaciones.Rows[i][FuncionariosLiquidacionesService.TotalACobrar_NombreCol]);
                            camposDet.Add(OrdenesPagoDetalleService.CotizacionMonedaOrigen_NombreCol, dtLiquidaciones.Rows[i][FuncionariosLiquidacionesService.Cotizacion_NombreCol]);
                            camposDet.Add(OrdenesPagoDetalleService.MontoDestino_NombreCol, dtLiquidaciones.Rows[i][FuncionariosLiquidacionesService.TotalACobrar_NombreCol]);
                            camposDet.Add(OrdenesPagoDetalleService.LiquidacionId_NombreCol, dtLiquidaciones.Rows[i][FuncionariosLiquidacionesService.Id_NombreCol]);
                            camposDet.Add(OrdenesPagoDetalleService.FlujoReferidoId_NombreCol, (decimal)32);
                            camposDet.Add(OrdenesPagoDetalleService.CasoReferidoId_NombreCol, planillaRow.CASO_ID);
                            camposDet.Add(OrdenesPagoDetalleService.Observacion_NombreCol, "Liquidación Nº " + dtLiquidaciones.Rows[i][FuncionariosLiquidacionesService.Id_NombreCol].ToString() + " - " + dtLiquidaciones.Rows[i][FuncionariosLiquidacionesService.VistaFuncionarioNombreCompleto_NombreCol]);

                            OrdenesPagoDetalleService.Guardar(camposDet, sesion);
                        }
                    }

                    // Se hace el mismo proceso para crear una OP de Pago a Proveedores, excepto que se toman liquidaciones con caso asociado
                    tipoOP = Definiciones.TiposOrdenesPago.PagoAProveedor;

                    dtLiquidaciones.Clear();

                    clausulas = FuncionariosLiquidacionesService.Id_NombreCol + " = (" + detalles + ") and " +
                                FuncionariosLiquidacionesService.CasoAsociadoId_NombreCol + " is not null";
                    
                    dtLiquidaciones = FuncionariosLiquidacionesService.GetLiquidacionesInfoCompletaDataTable2(clausulas, string.Empty, sesion);

                    for (int i = 0; i < dtLiquidaciones.Rows.Count; i++)
                    {
                        if (dtLiquidaciones.Rows[i][FuncionariosLiquidacionesService.VistaOrdenPagoId_NombreCol].Equals(DBNull.Value))
                        {
                            DataTable dtCasos = CasosService.GetCasosDataTable(CasosService.Id_NombreCol + " = " + dtLiquidaciones.Rows[i][FuncionariosLiquidacionesService.CasoAsociadoId_NombreCol].ToString(), string.Empty, sesion);
                            
                            // Se crea la OP, aparentemente todas las veces a juzgar por el codigo en PROC
                            Hashtable campos = new Hashtable();

                            campos.Add(OrdenesPagoService.SucursalOrigenId_NombreCol, planillaRow.SUCURSAL_ID);
                            campos.Add(OrdenesPagoService.Fecha_NombreCol, DateTime.Now);
                            campos.Add(OrdenesPagoService.OrdenPagoTipoId_NombreCol, tipoOP);
                            campos.Add(OrdenesPagoService.MonedaId_NombreCol, planillaRow.MONEDA_ID);
                            campos.Add(OrdenesPagoService.ProveedorId_NombreCol, dtCasos.Rows[0][CasosService.ProveedorId_NombreCol]);
                            campos.Add(OrdenesPagoService.CotizacionMoneda_NombreCol, planillaRow.COTIZACION);
                            campos.Add(OrdenesPagoService.MontoTotal_NombreCol, 0);
                            campos.Add(OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol, planillaRow.CTACTECAJATESORERIA_ID);
                            campos.Add(OrdenesPagoService.Observacion_NombreCol, "Planilla de Liquidación - Caso Nº " + planillaRow.CASO_ID.ToString());

                            OrdenesPagoService.Guardar(campos, true, ref caso_id, ref estado_id, sesion);

                            DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoDataTable(OrdenesPagoService.CasoId_NombreCol + " = " + caso_id, string.Empty);
                            orden_pago_id = (decimal)dtOrdenPago.Rows[0][OrdenesPagoService.Id_NombreCol];

                            // Se traen las entradas de ctacte proveedor para el caso
                            clausulas = CuentaCorrienteProveedoresService.CasoId_NombreCol + " = " + dtLiquidaciones.Rows[i][FuncionariosLiquidacionesService.CasoAsociadoId_NombreCol].ToString() + " and " +
                                        CuentaCorrienteProveedoresService.Credito_NombreCol + " > " + CuentaCorrienteProveedoresService.Debito_NombreCol;
                            DataTable dtCtacteProveedor = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresInfoCompleta(clausulas, orden_pago_id.ToString(), sesion);
                            
                            // Se crean los detalles de la OP
                            for (int j = 0; j < dtCtacteProveedor.Rows.Count; j++)
                            {
                                Hashtable camposDet = new Hashtable();

                                camposDet.Add(OrdenesPagoDetalleService.OrdenPagoId_NombreCol, orden_pago_id);
                                camposDet.Add(OrdenesPagoDetalleService.SucursalDestinoId_NombreCol, planillaRow.SUCURSAL_ID);
                                camposDet.Add(OrdenesPagoDetalleService.CtacteProveedorId_NombreCol, dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.Id_NombreCol]);
                                camposDet.Add(OrdenesPagoDetalleService.MonedaOrigenId_NombreCol, dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.MonedaId_NombreCol]);
                                camposDet.Add(OrdenesPagoDetalleService.MontoOrigen_NombreCol, (decimal)dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.Credito_NombreCol] - (decimal)dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.Debito_NombreCol]);
                                camposDet.Add(OrdenesPagoDetalleService.CotizacionMonedaOrigen_NombreCol, dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.CotizacionMoneda_NombreCol]);
                                if (dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.MonedaId_NombreCol].Equals(planillaRow.MONEDA_ID))
                                    camposDet.Add(OrdenesPagoDetalleService.MontoDestino_NombreCol, (decimal)dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.Credito_NombreCol] - (decimal)dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.Debito_NombreCol]); 
                                else
                                    camposDet.Add(OrdenesPagoDetalleService.MontoDestino_NombreCol, ((decimal)dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.Credito_NombreCol] - (decimal)dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.Debito_NombreCol]) / (decimal)dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.CotizacionMoneda_NombreCol] * planillaRow.COTIZACION);
                                camposDet.Add(OrdenesPagoDetalleService.LiquidacionId_NombreCol, dtLiquidaciones.Rows[i][FuncionariosLiquidacionesService.Id_NombreCol]);
                                camposDet.Add(OrdenesPagoDetalleService.FlujoReferidoId_NombreCol, 10);
                                camposDet.Add(OrdenesPagoDetalleService.CasoReferidoId_NombreCol, dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.CasoId_NombreCol]);
                                camposDet.Add(OrdenesPagoDetalleService.Observacion_NombreCol, dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.VistaObservacion_NombreCol]);

                                OrdenesPagoDetalleService.Guardar(camposDet, sesion);
                            }
                        }
                    }

                    return exito;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static bool CrearCasosOrdenPagoLiquidacionFuncionario(decimal liquidacionId, decimal planillaLiquidacionId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    bool exito = true;
                    
                    // Se trae la planilla
                    PLANILLA_LIQUIDACIONESRow planillaRow = sesion.db.PLANILLA_LIQUIDACIONESCollection.GetByPrimaryKey(planillaLiquidacionId);
                    CASOSRow casoRow = sesion.db.CASOSCollection.GetByPrimaryKey(planillaRow.CASO_ID);

                    // La planilla debe estar en aprobado
                    if (!casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado))
                        throw new Exception("El caso debe estar en APROBADO para generar la OP.");

                    // Se trae los datos de la liquidacion
                    DataTable dtLiquidaciones = FuncionariosLiquidacionesService.GetLiquidacionesInfoCompletaDataTable2(FuncionariosLiquidacionesService.Id_NombreCol + " = " + liquidacionId, string.Empty, sesion);

                    decimal caso_id = Definiciones.Error.Valor.EnteroPositivo;
                    string estado_id = string.Empty;
                    decimal orden_pago_id = Definiciones.Error.Valor.EnteroPositivo;

                    // Se define el tipo de OP a ser creada
                    int tipoOP;
                    if (dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.CasoAsociadoId_NombreCol].Equals(DBNull.Value))
                        tipoOP = Definiciones.TiposOrdenesPago.PagoFuncionarios;
                    else
                        tipoOP = Definiciones.TiposOrdenesPago.PagoAProveedor;

                    // Si total_cobrar de la liquidacion es cero, no se crea la op
                    if (dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.TotalACobrar_NombreCol].Equals(DBNull.Value))
                        throw new Exception("La orden de pago no puede ser creada porque el monto de la planilla es cero.");

                    // Se crea el caso de OP que puede ser con o sin proveedor segun el tipoOP
                    DataTable dtCasos = new DataTable();
                    if (tipoOP.Equals(Definiciones.TiposOrdenesPago.PagoAProveedor))
                        dtCasos = CasosService.GetCasosDataTable(CasosService.Id_NombreCol + " = " + dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.CasoAsociadoId_NombreCol].ToString(), string.Empty, sesion);

                    Hashtable campos = new Hashtable();
                    campos.Add(OrdenesPagoService.SucursalOrigenId_NombreCol, planillaRow.SUCURSAL_ID);
                    campos.Add(OrdenesPagoService.Fecha_NombreCol, DateTime.Now);
                    campos.Add(OrdenesPagoService.OrdenPagoTipoId_NombreCol, tipoOP);
                    campos.Add(OrdenesPagoService.MonedaId_NombreCol, (decimal)dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.MonedaId_NombreCol]);
                    if (tipoOP.Equals(Definiciones.TiposOrdenesPago.PagoAProveedor))
                        campos.Add(OrdenesPagoService.ProveedorId_NombreCol, dtCasos.Rows[0][CasosService.ProveedorId_NombreCol]);
                    campos.Add(OrdenesPagoService.CotizacionMoneda_NombreCol, (decimal)dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.Cotizacion_NombreCol]);
                    campos.Add(OrdenesPagoService.MontoTotal_NombreCol, 0);
                    campos.Add(OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol, planillaRow.CTACTECAJATESORERIA_ID);
                    campos.Add(OrdenesPagoService.Observacion_NombreCol, "Planilla de Liquidación - Caso N° " + planillaRow.CASO_ID.ToString());

                    OrdenesPagoService.Guardar(campos, true, ref caso_id, ref estado_id, sesion);
                    DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoDataTable(OrdenesPagoService.CasoId_NombreCol + " = " + caso_id, string.Empty);
                    orden_pago_id = (decimal)dtOrdenPago.Rows[0][OrdenesPagoService.Id_NombreCol];

                    // Se crean los detalles de la OP
                    // Si es Pago a Proveedor, los detalles se quitan de la ctacte proveedor
                    if (tipoOP.Equals(Definiciones.TiposOrdenesPago.PagoAProveedor))
                    {
                        string clausulas = CuentaCorrienteProveedoresService.CasoId_NombreCol + " = " + dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.CasoAsociadoId_NombreCol].ToString() + " and " +
                                        CuentaCorrienteProveedoresService.Credito_NombreCol + " > " + CuentaCorrienteProveedoresService.Debito_NombreCol;
                        DataTable dtCtacteProveedor = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresInfoCompleta(clausulas, OrdenesPagoService.Id_NombreCol, sesion);

                        // Se crean los detalles de la OP
                        for (int j = 0; j < dtCtacteProveedor.Rows.Count; j++)
                        {
                            Hashtable camposDet = new Hashtable();

                            camposDet.Add(OrdenesPagoDetalleService.OrdenPagoId_NombreCol, orden_pago_id);
                            camposDet.Add(OrdenesPagoDetalleService.SucursalDestinoId_NombreCol, planillaRow.SUCURSAL_ID);
                            camposDet.Add(OrdenesPagoDetalleService.CtacteProveedorId_NombreCol, dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.Id_NombreCol]);
                            camposDet.Add(OrdenesPagoDetalleService.MonedaOrigenId_NombreCol, dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.MonedaId_NombreCol]);
                            camposDet.Add(OrdenesPagoDetalleService.MontoOrigen_NombreCol, (decimal)dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.Credito_NombreCol] - (decimal)dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.Debito_NombreCol]);
                            camposDet.Add(OrdenesPagoDetalleService.CotizacionMonedaOrigen_NombreCol, dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.CotizacionMoneda_NombreCol]);
                            if (dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.MonedaId_NombreCol].Equals((decimal)dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.MonedaId_NombreCol]))
                                camposDet.Add(OrdenesPagoDetalleService.MontoDestino_NombreCol, (decimal)dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.Credito_NombreCol] - (decimal)dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.Debito_NombreCol]);
                            else
                                camposDet.Add(OrdenesPagoDetalleService.MontoDestino_NombreCol, ((decimal)dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.Credito_NombreCol] - (decimal)dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.Debito_NombreCol]) / (decimal)dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.CotizacionMoneda_NombreCol] * (decimal)dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.Cotizacion_NombreCol]);
                            camposDet.Add(OrdenesPagoDetalleService.LiquidacionId_NombreCol, dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.Id_NombreCol]);
                            camposDet.Add(OrdenesPagoDetalleService.FlujoReferidoId_NombreCol, 10);
                            camposDet.Add(OrdenesPagoDetalleService.CasoReferidoId_NombreCol, dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.CasoId_NombreCol]);
                            camposDet.Add(OrdenesPagoDetalleService.Observacion_NombreCol, dtCtacteProveedor.Rows[j][CuentaCorrienteProveedoresService.VistaObservacion_NombreCol]);

                            OrdenesPagoDetalleService.Guardar(camposDet, sesion);
                        }
                    }
                    // Si es Pago a Funcionario, se quita de la liquidacion
                    else
                    {
                        // Se crean los detalles de la OP
                        Hashtable camposDet = new Hashtable();

                        camposDet.Add(OrdenesPagoDetalleService.OrdenPagoId_NombreCol, orden_pago_id);
                        camposDet.Add(OrdenesPagoDetalleService.SucursalDestinoId_NombreCol, planillaRow.SUCURSAL_ID);
                        camposDet.Add(OrdenesPagoDetalleService.MonedaOrigenId_NombreCol, dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.MonedaId_NombreCol]);
                        camposDet.Add(OrdenesPagoDetalleService.MontoOrigen_NombreCol, dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.TotalACobrar_NombreCol]);
                        camposDet.Add(OrdenesPagoDetalleService.CotizacionMonedaOrigen_NombreCol, dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.Cotizacion_NombreCol]);
                        camposDet.Add(OrdenesPagoDetalleService.MontoDestino_NombreCol, dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.TotalACobrar_NombreCol]);
                        camposDet.Add(OrdenesPagoDetalleService.LiquidacionId_NombreCol, dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.Id_NombreCol]);
                        camposDet.Add(OrdenesPagoDetalleService.FlujoReferidoId_NombreCol, (decimal)32);
                        camposDet.Add(OrdenesPagoDetalleService.CasoReferidoId_NombreCol, planillaRow.CASO_ID);
                        camposDet.Add(OrdenesPagoDetalleService.Observacion_NombreCol, "Liquidación Nº " + dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.Id_NombreCol].ToString() + " - " + dtLiquidaciones.Rows[0][FuncionariosLiquidacionesService.VistaFuncionarioNombreCompleto_NombreCol]);

                        OrdenesPagoDetalleService.Guardar(camposDet, sesion);
                    }

                    return exito;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion CrearCasosOrdenPago

        #region ActualizarTotal
        public void ActualizarTotal(decimal planilla_id, SessionService sesion) 
        {
            PLANILLA_LIQUIDACIONESRow rowCabecera = sesion.Db.PLANILLA_LIQUIDACIONESCollection.GetByPrimaryKey(planilla_id);
            PLANILLA_LIQUIDACIONES_DETRow[] detalleRow = sesion.Db.PLANILLA_LIQUIDACIONES_DETCollection.GetByPLANILLA_ID(planilla_id);
            rowCabecera.TOTAL=0;
            for (int i = 0; i < detalleRow.Length; i++)
            {
                if (rowCabecera.MONEDA_ID != detalleRow[i].MONEDA_ID)
                {
                    rowCabecera.TOTAL += (detalleRow[i].TOTAL_A_COBRAR / detalleRow[i].COTIZACION * rowCabecera.COTIZACION);
                }
                else 
                {
                    rowCabecera.TOTAL +=detalleRow[i].TOTAL_A_COBRAR;
                }
            }
            sesion.Db.PLANILLA_LIQUIDACIONESCollection.Update(rowCabecera);
        }
        #endregion ActualizarTotal

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        public bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                PLANILLA_LIQUIDACIONESRow row = new PLANILLA_LIQUIDACIONESRow();

                try
                {
                    SucursalesService sucursal = new SucursalesService();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[PlanillaLiquidacionesService.SucursalId_NombreCol].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.PLANILLA_LIQUIDACIONES.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("planilla_liquidaciones_sqc");
                       
                       
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                        
                       
                    }
                    else
                    {
                        row = sesion.Db.PLANILLA_LIQUIDACIONESCollection.GetByPrimaryKey((decimal)campos[PlanillaLiquidacionesService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    // se carga la fecha de creacion con la fecha actual
                    row.FECHA_CREACION = DateTime.Now;

                    // se carga el usuario creador
                    row.USUARIO_CREACION_ID = sesion.Usuario.ID;

                    // campos no obligatorios
                    if (campos.Contains(PlanillaLiquidacionesService.Observacion_NombreCol))
                        row.OBSERVACION = campos[PlanillaLiquidacionesService.Observacion_NombreCol].ToString();
                    if (campos.Contains(PlanillaLiquidacionesService.NroComprobante_NombreCol))
                        row.NRO_COMPROBANTE = campos[PlanillaLiquidacionesService.NroComprobante_NombreCol].ToString();
                    
                    //se verifican que los campos obligatorios
                    if (campos.Contains(PlanillaLiquidacionesService.FechaDesde_NombreCol))
                        row.FECHA_DESDE = DateTime.Parse(campos[PlanillaLiquidacionesService.FechaDesde_NombreCol].ToString()).Date;
                    else
                        throw new ArgumentException("La fecha de inicio es un campo obligatorio");

                    if (campos.Contains(PlanillaLiquidacionesService.FechaDesde_NombreCol))
                        row.FECHA_HASTA = DateTime.Parse(campos[PlanillaLiquidacionesService.FechaHasta_NombreCol].ToString()).Date;
                    else
                        throw new ArgumentException("La fecha de fin es un campo obligatorio");
                   
                    if (campos.Contains(PlanillaLiquidacionesService.Cotizacion_NombreCol)) 
                        row.COTIZACION = decimal.Parse(campos[PlanillaLiquidacionesService.Cotizacion_NombreCol].ToString());
                    else 
                        throw new ArgumentException("La cotización es un campo obligatorio");
                    if (campos.Contains(PlanillaLiquidacionesService.AutonmeracionId_NombreCol)) 
                        row.AUTONUMERACION_ID = decimal.Parse(campos[PlanillaLiquidacionesService.AutonmeracionId_NombreCol].ToString());
                    else
                        throw new ArgumentException("La talonario es un campo obligatorio");

                    if (campos.Contains(PlanillaLiquidacionesService.MonedaId_NombreCol))
                        row.MONEDA_ID = decimal.Parse(campos[PlanillaLiquidacionesService.MonedaId_NombreCol].ToString());
                    else
                        throw new ArgumentException("La moneda es un campo obligatorio");
                    
                    if (campos.Contains(PlanillaLiquidacionesService.SucursalId_NombreCol))
                        row.SUCURSAL_ID = decimal.Parse(campos[PlanillaLiquidacionesService.SucursalId_NombreCol].ToString());
                    else
                        throw new ArgumentException("La sucursal es un campo obligatorio");

                    if (campos.Contains(PlanillaLiquidacionesService.CajaTesoreriaId_NombreCol))
                        row.CTACTECAJATESORERIA_ID = decimal.Parse(campos[PlanillaLiquidacionesService.CajaTesoreriaId_NombreCol].ToString());
                    else
                        throw new ArgumentException("La caja de tesoreria es un campo obligatorio");

                    if (campos.Contains(PlanillaLiquidacionesService.Tipo_NombreCol))
                        row.TIPO = decimal.Parse(campos[PlanillaLiquidacionesService.Tipo_NombreCol].ToString());
                    else
                        throw new ArgumentException("El tipo de liquidacion es un campo obligatorio");

                    if (campos.Contains(PlanillaLiquidacionesService.Total_NombreCol))
                        row.TOTAL = decimal.Parse(campos[PlanillaLiquidacionesService.Total_NombreCol].ToString());
                    else
                        throw new ArgumentException("El total de la liquidacion es un campo obligatorio");

                    if (insertarNuevo) sesion.Db.PLANILLA_LIQUIDACIONESCollection.Insert(row);
                    else sesion.Db.PLANILLA_LIQUIDACIONESCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA_DESDE);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.TipoEspecifico_NombreCol, row.TIPO);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    exito = true;
                }
                catch (Exception)
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
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borra de la base de datos el caso y la cabecera del flujo
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public bool Borrar(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    bool exito = true;
                    String mensaje = "Error.";

                    //Se obtiene el caso a ser borrado
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    PLANILLA_LIQUIDACIONESRow cabecera = sesion.Db.PLANILLA_LIQUIDACIONESCollection.GetByCASO_ID(caso_id)[0];
                

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }


                    PLANILLA_LIQUIDACIONES_DETRow[] detalles = sesion.Db.PLANILLA_LIQUIDACIONES_DETCollection.GetByPLANILLA_ID(cabecera.ID);
                    if (detalles.Length > 0) 
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que aún tiene detalles";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {


                        sesion.Db.PLANILLA_LIQUIDACIONESCollection.DeleteByPrimaryKey(cabecera.ID);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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

        #region Puede Cerrar Planilla
        //verifica que todas las ops asociadas a la planilla esten pagadas
        public static bool PuedeCerrarPlanilla(decimal planilla_caso_id, decimal orden_pago_caso_id, SessionService sesion)
        {
            bool puedeCerrar = true;
            string planilla_id = GetPlanillaLiquidacionesPorCasoStatic(planilla_caso_id).Rows[0][Id_NombreCol].ToString();

            //obtenemos todas las liquidaciones con las OP's asociadas
            //exlcuimos liquidaciones que no generan OP (total a pagar > 0)
            //y la verificacion lo hacemos a partir de una OP (orden_pago_caso_id)
            string clausula = FuncionariosLiquidacionesService.PlanillaSalarioId_NombreCol + " = " + planilla_id + " and (" +
                              FuncionariosLiquidacionesService.TotalACobrar_NombreCol + " > 0 or " + FuncionariosLiquidacionesService.CasoAsociadoId_NombreCol + " is not null) and (" +
                              FuncionariosLiquidacionesService.VistaOrdenCasoId_NombreCol + " <> " + orden_pago_caso_id + " or " +
                              FuncionariosLiquidacionesService.VistaOrdenCasoId_NombreCol + " is null)";
            
            DataTable liquidaciones = FuncionariosLiquidacionesService.GetLiquidacionesInfoCompletaDataTable2(clausula, string.Empty, sesion);

            DataRow[] ordenes_pago_sin_cerrar = liquidaciones.Select(FuncionariosLiquidacionesService.VistaOrdenCasoEstadoId_NombreCol + " not like '" + Definiciones.EstadosFlujos.Cerrado + "' or " + FuncionariosLiquidacionesService.VistaOrdenCasoEstadoId_NombreCol + " is null");

            //si existe OP's en estado distingo a Cerrados, no puede cerrarse la planilla
            if (ordenes_pago_sin_cerrar.Length > 0)
                puedeCerrar = false;

            return puedeCerrar;
        }
        #endregion Puede Cerrar Planilla

        #region EnviarRecibosWebservice
        public static string EnviarRecibosWebservice(decimal planilla_liquidacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string mensaje = string.Empty;

                try
                {
                    sesion.BeginTransaction();

                    var row = sesion.db.PLANILLA_LIQUIDACIONESCollection.GetByPrimaryKey(planilla_liquidacion_id);
                    var caso = new CasosService(row.CASO_ID, sesion);

                    if (caso.EstadoId != Definiciones.EstadosFlujos.Aprobado && caso.EstadoId != Definiciones.EstadosFlujos.Cerrado)
                        throw new Exception("La planilla debe estar en estado Aprobado o Cerrado.");

                    Webmethods.EnviarRecibos.Enviar(planilla_liquidacion_id, out mensaje, sesion);
                    if (mensaje == string.Empty)
                        mensaje = "Enviado con éxito.";

                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }

                return mensaje;
            }
            
        }
        #endregion EnviarRecibosWebservice

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PLANILLA_LIQUIDACIONES"; }
        }

        #region Tabla
        public static string AutonmeracionId_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONESCollection.AUTONUMERACION_IDColumnName; }
        }
        
        public static string CasoId_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONESCollection.CASO_IDColumnName; }
        }

        public static string Cotizacion_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONESCollection.COTIZACIONColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONESCollection.FECHA_CREACIONColumnName; }
        }
        public static string FechaDesde_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONESCollection.FECHA_DESDEColumnName; }
        }
        
        public static string FechaHasta_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONESCollection.FECHA_HASTAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONESCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONESCollection.MONEDA_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONESCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONESCollection.OBSERVACIONColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONESCollection.SUCURSAL_IDColumnName; }
        }
        public static string Tipo_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONESCollection.TIPOColumnName; }
        }
        public static string Total_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONESCollection.TOTALColumnName; }
        }
        public static string UsuarioCreacion_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONESCollection.USUARIO_CREACION_IDColumnName; }
        }
        
        public static string CajaTesoreriaId_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONESCollection.CTACTECAJATESORERIA_IDColumnName; }
        }
        
        #endregion Tabla

        #region Vista
        public static string VistaCasoEstado_NombreCol
        {
            get { return PLANILLA_LIQ_INFO_COMPLCollection.CASOS_ESTADOColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return PLANILLA_LIQ_INFO_COMPLCollection.MONEDAS_NOMBRESColumnName; }
        }

        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return PLANILLA_LIQ_INFO_COMPLCollection.MONEDAS_SIMBOLOSColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return PLANILLA_LIQ_INFO_COMPLCollection.SUCURSALES_ABREVIATURASColumnName; }
        }
        public static string VistaSucursalEntidaId_NombreCol
        {
            get { return PLANILLA_LIQ_INFO_COMPLCollection.SUCURSALES_ENTIDAD_IDColumnName; }
        }
        public static string VistaSucursalEntidaNombre_NombreCol
        {
            get { return PLANILLA_LIQ_INFO_COMPLCollection.SUCURSALES_ENTIDAD_NOMBREColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return PLANILLA_LIQ_INFO_COMPLCollection.SUCURSALES_NOMBREColumnName; }
        }
        public static string VistaUsuarioCreacion_NombreCol
        {
            get { return PLANILLA_LIQ_INFO_COMPLCollection.USUARIOS_USUARIOColumnName; }
        }
       
        #endregion Vista

        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static PlanillaLiquidacionesService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new PlanillaLiquidacionesService(e.RegistroId, sesion);
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
        protected PLANILLA_LIQUIDACIONESRow row;
        protected PLANILLA_LIQUIDACIONESRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal AutonumeracionId { get { return row.AUTONUMERACION_ID; } set { row.AUTONUMERACION_ID = value; } }
        public decimal CasoId { get { return row.CASO_ID; } set { row.CASO_ID = value; } }
        public decimal Cotizacion { get { return row.COTIZACION; } set { row.COTIZACION = value; } }
        public decimal? CtaCteCajaTesoreriaId { get { if (row.IsCTACTECAJATESORERIA_IDNull) return null; else return row.CTACTECAJATESORERIA_ID; } set { if (value.HasValue) row.CTACTECAJATESORERIA_ID = value.Value; else row.IsCTACTECAJATESORERIA_IDNull = true; } }
        public DateTime FechaCreacion { get { return row.FECHA_CREACION; } set { row.FECHA_CREACION = value; } }
        public DateTime FechaDesde { get { return row.FECHA_DESDE; } set { row.FECHA_DESDE = value; } }
        public DateTime FechaHasta { get { return row.FECHA_HASTA; } set { row.FECHA_HASTA = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public string NroComprobante { get { return GetStringHelper(row.NRO_COMPROBANTE); } set { row.NRO_COMPROBANTE = value; } }
        public string Observacion { get { return GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } set { row.SUCURSAL_ID = value; } }
        public decimal Tipo { get { return row.TIPO; } set { row.TIPO = value; } }
        public decimal Total { get { return row.TOTAL; } set { row.TOTAL = value; } }
        public decimal UsuarioCreacionId { get { return row.USUARIO_CREACION_ID; } set { row.USUARIO_CREACION_ID = value; } }
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
                this.row = sesion.db.PLANILLA_LIQUIDACIONESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new PLANILLA_LIQUIDACIONESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }

        private void Inicializar(PLANILLA_LIQUIDACIONESRow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public PlanillaLiquidacionesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public PlanillaLiquidacionesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public PlanillaLiquidacionesService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        public PlanillaLiquidacionesService(EdiCBA.PlanillaLiquidacion edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = PlanillaLiquidacionesService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            this.CasoId = edi.caso_id;
            
            if(edi.cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion'.");
            this.Cotizacion = edi.cotizacion.compra;
            
            this.FechaCreacion = edi.fecha_creacion;
            this.FechaDesde = edi.fecha_desde;
            this.FechaHasta = edi.fecha_hasta;
            
            #region moneda
            if (!string.IsNullOrEmpty(edi.moneda_uuid))
                this._moneda = MonedasService.GetPorUUID(edi.moneda_uuid, sesion);
          
            if (this._moneda == null)
                throw new Exception("No se encontró el UUID " + edi.moneda_uuid + " ni se definieron los datos del objeto.");
            #endregion moneda
            
            this.NroComprobante = edi.nro_comprobante;
            this.Observacion = edi.observacion;
            
            #region sucursal
            if (!string.IsNullOrEmpty(edi.sucursal_uuid))
                this._sucursal = SucursalesService.GetPorUUID(edi.sucursal_uuid, sesion);
            if (this._sucursal == null && edi.sucursal != null)
                this._sucursal = new SucursalesService(edi.sucursal, almacenar_localmente, sesion);
            if (this._sucursal == null)
                throw new Exception("No se encontró el UUID " + edi.sucursal_uuid + " ni se definieron los datos del objeto.");

            if (!this.Sucursal.ExisteEnDB && almacenar_localmente)
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            
            if (this.Sucursal.Id.HasValue)
                this.SucursalId = this.Sucursal.Id.Value;
            #endregion sucursal

            this.Tipo = edi.tipo;
            this.Total = edi.total;

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
                this.Caso.FechaFormulario = edi.fecha_desde;
                this.Caso.FlujoId = Definiciones.FlujosIDs.PLANILLA_LIQUIDACIONES;
            }
            #endregion caso
        }
        private PlanillaLiquidacionesService(PLANILLA_LIQUIDACIONESRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._caso = null;
            //this._factura_cliente_detalles = null;
            this._moneda  = null;
            this._sucursal = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region GetPorCaso
        public static PlanillaLiquidacionesService GetPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCaso(caso_id, sesion);
            }
        }

        public static PlanillaLiquidacionesService GetPorCaso(decimal caso_id, SessionService sesion)
        {
            var row = sesion.db.PLANILLA_LIQUIDACIONESCollection.GetByCASO_ID(caso_id)[0];
            return new PlanillaLiquidacionesService(row);
        }
        #endregion GetPorCaso

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
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
