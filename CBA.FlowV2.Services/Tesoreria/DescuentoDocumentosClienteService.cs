#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;

using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using System.Collections;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Stock;
using System.Collections.Generic;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class DescuentoDocumentosClienteService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES;
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
                mensaje = string.Empty;
                try
                {
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    DESCUENTO_DOCUMENTOS_CLIENTERow cabeceraRow = sesion.Db.DESCUENTO_DOCUMENTOS_CLIENTECollection.GetByCASO_ID(caso_id)[0];
                    DataTable dtDetalles = DescuentoDocumentosClienteDetalleService.GetDescuentoDocumentosClienteDetalleDataTable(DescuentoDocumentosClienteDetalleService.DescuentoDocumentosCliId_NombreCol + " = " + cabeceraRow.ID, string.Empty);

                    //Verificar si se cumplen los requisitos
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                    if (!exito)
                        throw new Exception("Requisitos no cumplidos.");

                    //Borrador a Pendiente
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //Se genera la numeracion si no existia un numero de comprobante definido
                        exito = true;

                        if (cabeceraRow.NRO_COMPROBANTE == null)
                        {
                            try
                            {
                                cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID);

                                //Controlar que se logro asignar una numeracion
                                if (cabeceraRow.NRO_COMPROBANTE.Equals(string.Empty))
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
                    //Pendiente a Borrador
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                    }
                    //Pendiente a PreAprobado 
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.PreAprobado))
                    {
                        //Acciones
                        //Controlar que el total efectivo menos los gastos extra son mayor a cero.
                        exito = true;

                        decimal totalEfectivo = 0;

                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                            totalEfectivo += (decimal)dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.TotalValorEfectivo_NombreCol];

                        if (exito && totalEfectivo <= 0)
                        {
                            exito = false;
                            mensaje = "El monto total efectivo debe ser mayor a cero.";
                        }

                        if (exito && totalEfectivo - cabeceraRow.MONTO_GASTO_EXTRA <= 0)
                        {
                            exito = false;
                            mensaje = "El monto total efectivo debe ser mayor al gasto extra.";
                        }
                    }
                    //PreAprobado a Aprobado 
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.PreAprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //Afectar la ctacte de la persona con el debito (monto a ser desembolsado a traves de OP)
                        exito = true;

                        decimal totalEfectivo = 0;

                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                            totalEfectivo += (decimal)dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.TotalValorEfectivo_NombreCol];

                        totalEfectivo -= cabeceraRow.MONTO_GASTO_EXTRA;

                        if (totalEfectivo <= 0)
                            throw new Exception("El total efectivo debe ser mayor a cero (tomando en cuenta el gasto extra).");

                        #region Afectar ctacte agregando debito
                        if (exito)
                        {
                            try
                            {
                                if (cabeceraRow.AFECTAR_CTACTE_PERSONA_DEBITO.Equals(Definiciones.SiNo.Si))
                                {
                                    //Ingresar el debito
                                    CuentaCorrientePersonasService.AgregarDebito((decimal)cabeceraRow.PERSONA_ID,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.CuentaCorrienteConceptos.DebitoPorFlujo,
                                                        Definiciones.CuentaCorrienteValores.DescuentoDocumentos,
                                                        cabeceraRow.CASO_ID,
                                                        cabeceraRow.MONEDA_ID,
                                                        cabeceraRow.COTIZACION_MONEDA,
                                                        new decimal[] { Definiciones.Impuestos.Exenta },
                                                        new decimal[] { totalEfectivo },
                                                        "Otorgamiento de descuento de documentos.",
                                                        cabeceraRow.FECHA,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        sesion);
                                }
                                else
                                {
                                    //Si el debito no se va a generar en el descuento docuemento se deberá generar la factura Proveedor Correspondiente
                                    exito = GenerarFacturaProveedor(cabeceraRow,out mensaje, sesion);

                                }
                            }
                            catch (Exception exp)
                            {
                                mensaje = exp.Message.ToString();
                                exito = false;
                            }
                        }
                        #endregion Afectar ctacte agregando debito
                    }
                    //Aprobado a Vigente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Vigente))
                    {
                        //Acciones
                        //Transicion efectuada debido a que la Orden de Pago fue cerrada.
                        //Crear los documentos recibidos
                        //Afectar la ctacte de la persona con las cuotas de documentos recibidos
                        exito = true;

                        if (cambio_pedido_por_usuario)
                        {
                            exito = false;
                            mensaje = "La transición de Aprobado a Vigente es realizada desde el flujo Orden de Pago";
                        }
                        else
                        {
                            Hashtable campos;
                            decimal ctacteDocumentoId, ctacteChequeRecibidoId;
                            DataTable dtVencimientos, dtDesglose, dtCtacteDocumentosVencimientos;

                            for (int i = 0; i < dtDetalles.Rows.Count; i++)
                            {
                                dtVencimientos = DescuentoDocumentosClienteDetalleVencimientosService.GetDescuentoDocumentosClienteDetalleVencimientosDataTable(DescuentoDocumentosClienteDetalleVencimientosService.DescuentoDocumentoDetId_NombreCol + " = " + dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.Id_NombreCol], DescuentoDocumentosClienteDetalleVencimientosService.FechaVencimiento_NombreCol);

                                if ((decimal)dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.CtacteValorId_NombreCol] == Definiciones.CuentaCorrienteValores.Cheque)
                                {
                                    #region Crear el cheque recibido
                                    System.Collections.Hashtable camposCheque = new System.Collections.Hashtable();
                                    camposCheque.Add(CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.CotizacionMoneda_NombreCol]);
                                    camposCheque.Add(CuentaCorrienteChequesRecibidosService.CtacteBancoId_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.ChequeCtacteBancoId_NombreCol]);
                                    camposCheque.Add(CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol, string.Empty);
                                    camposCheque.Add(CuentaCorrienteChequesRecibidosService.EsDiferido_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.ChequeEsDiferido_NombreCol]);
                                    camposCheque.Add(CuentaCorrienteChequesRecibidosService.FechaPosdatado_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.FechaCreacion_NombreCol]);
                                    camposCheque.Add(CuentaCorrienteChequesRecibidosService.FechaVencimiento_NombreCol, dtVencimientos.Rows[0][DescuentoDocumentosClienteDetalleVencimientosService.FechaVencimiento_NombreCol]);
                                    camposCheque.Add(CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.MonedaId_NombreCol]);
                                    camposCheque.Add(CuentaCorrienteChequesRecibidosService.Monto_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.TotalValorNominal_NombreCol]);
                                    camposCheque.Add(CuentaCorrienteChequesRecibidosService.NombreBeneficiario_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.NombreBeneficiario_NombreCol]);
                                    camposCheque.Add(CuentaCorrienteChequesRecibidosService.NombreEmisor_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.NombreDeudor_NombreCol]);
                                    camposCheque.Add(CuentaCorrienteChequesRecibidosService.NumeroCheque_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.NroComprobante_NombreCol]);
                                    camposCheque.Add(CuentaCorrienteChequesRecibidosService.NumeroCuenta_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.ChequeNroCuenta_NombreCol]);
                                    camposCheque.Add(CuentaCorrienteChequesRecibidosService.ChequeDeTerceros_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.ChequeDeTerceros_NombreCol]);
                                    camposCheque.Add(CuentaCorrienteChequesRecibidosService.NumeroDocumentoEmisor_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.ChequeDocumentoEmisor_NombreCol]);
                                    camposCheque.Add(CuentaCorrienteChequesRecibidosService.CasoCreadorId_NombreCol, cabeceraRow.CASO_ID);
                                    ctacteChequeRecibidoId = new CuentaCorrienteChequesRecibidosService().Guardar(camposCheque, true, sesion);
                                    DescuentoDocumentosClienteDetalleService.ActualizarChequeRecibido((decimal)dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.Id_NombreCol], ctacteChequeRecibidoId, sesion);
                                    #endregion Crear el cheque recibido

                                    //Ingresar el cheque a la caja de tesoreria
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(cabeceraRow.CTACTE_CAJA_TESORERIA_ID, 
                                                                                             Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES, 
                                                                                             string.Empty, 
                                                                                             cabeceraRow.ID, 
                                                                                             (decimal)dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.Id_NombreCol], (decimal)dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.CtacteValorId_NombreCol],
                                                                                             ctacteChequeRecibidoId,
                                                                                             (decimal)dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.MonedaId_NombreCol],
                                                                                             (decimal)dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.CotizacionMoneda_NombreCol],
                                                                                             (decimal)dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.TotalValorNominal_NombreCol],
                                                                                             cabeceraRow.FECHA,
                                                                                             sesion);
                                }
                                else
                                {
                                    #region Crear documentos recibidos

                                    #region creaar cabecera documento
                                    campos = new Hashtable();

                                    if (dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.PersonaId_NombreCol].Equals(DBNull.Value))
                                        campos.Add(CuentaCorrienteDocumentosService.PersonaId_NombreCol, cabeceraRow.PERSONA_ID);
                                    else
                                        campos.Add(CuentaCorrienteDocumentosService.PersonaId_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.PersonaId_NombreCol]);

                                    campos.Add(CuentaCorrienteDocumentosService.CtacteValorId_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.CtacteValorId_NombreCol]);
                                    campos.Add(CuentaCorrienteDocumentosService.CotizacionMoneda_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.CotizacionMoneda_NombreCol]);
                                    campos.Add(CuentaCorrienteDocumentosService.MonedaId_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.MonedaId_NombreCol]);
                                    campos.Add(CuentaCorrienteDocumentosService.FechaCreacion_NombreCol, DateTime.Now);
                                    campos.Add(CuentaCorrienteDocumentosService.NombreBeneficiario_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.NombreBeneficiario_NombreCol]);
                                    campos.Add(CuentaCorrienteDocumentosService.NombreDeudor_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.NombreDeudor_NombreCol]);
                                    campos.Add(CuentaCorrienteDocumentosService.NroComprobante_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.NroComprobante_NombreCol]);
                                    campos.Add(CuentaCorrienteDocumentosService.Observacion_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.Observacion_NombreCol].Equals(DBNull.Value) ? string.Empty : dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.Observacion_NombreCol]);
                                    campos.Add(CuentaCorrienteDocumentosService.TotalBruto_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.TotalValorNominal_NombreCol]);
                                    campos.Add(CuentaCorrienteDocumentosService.TotalRetencion_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.TotalRetencion_NombreCol]);
                                    campos.Add(CuentaCorrienteDocumentosService.DescDocCliDetId_NombreCol, dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.Id_NombreCol]);
                                    ctacteDocumentoId = CuentaCorrienteDocumentosService.Guardar(campos, sesion);
                                    DescuentoDocumentosClienteDetalleService.ActualizarDocumentoRecibido((decimal)dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.Id_NombreCol], ctacteDocumentoId, sesion);
                                    #endregion creaar cabecera documento

                                    #region crear vencimientos documento
                                    for (int j = 0; j < dtVencimientos.Rows.Count; j++)
                                    {
                                        campos = new Hashtable();
                                        campos.Add(CuentaCorrienteDocumentosVencimientosService.CtaCteDocumentoId_NombreCol, ctacteDocumentoId);
                                        campos.Add(CuentaCorrienteDocumentosVencimientosService.FechaVencimiento_NombreCol, dtVencimientos.Rows[j][DescuentoDocumentosClienteDetalleVencimientosService.FechaVencimiento_NombreCol]);
                                        campos.Add(CuentaCorrienteDocumentosVencimientosService.Monto_NombreCol, dtVencimientos.Rows[j][DescuentoDocumentosClienteDetalleVencimientosService.Monto_NombreCol]);
                                        CuentaCorrienteDocumentosVencimientosService.Guardar(campos, sesion);
                                    }
                                    #endregion crear vencimientos documento

                                    #region crear desglose documento
                                    dtDesglose = DescuentoDocumentosClienteDetalleDesgloseService.GetDescuentoDocumentosClienteDetalleDesgloseDataTable(DescuentoDocumentosClienteDetalleDesgloseService.DescuentoDocumentoDetId_NombreCol + " = " + dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.Id_NombreCol], DescuentoDocumentosClienteDetalleDesgloseService.Id_NombreCol);
                                    for (int j = 0; j < dtDesglose.Rows.Count; j++)
                                    {
                                        campos = new Hashtable();
                                        campos.Add(CuentaCorrienteDocumentosDesgloseService.CtaCteDocumentoId_NombreCol, ctacteDocumentoId);
                                        campos.Add(CuentaCorrienteDocumentosDesgloseService.ImpuestoId_NombreCol, dtDesglose.Rows[j][DescuentoDocumentosClienteDetalleDesgloseService.ImpuestoId_NombreCol]);
                                        campos.Add(CuentaCorrienteDocumentosDesgloseService.Monto_NombreCol, dtDesglose.Rows[j][DescuentoDocumentosClienteDetalleDesgloseService.Monto_NombreCol]);
                                        CuentaCorrienteDocumentosDesgloseService.Guardar(campos, sesion);
                                    }
                                    #endregion crear desglose documento

                                    #endregion Crear documentos recibidos

                                    #region Afectar ctacte agregando credito

                                    #region crear vencimientos en ctacte
                                    dtCtacteDocumentosVencimientos = CuentaCorrienteDocumentosVencimientosService.GetCuentaCorrienteDocumentosVencimientosDataTable(CuentaCorrienteDocumentosVencimientosService.CtaCteDocumentoId_NombreCol + " = " + ctacteDocumentoId, CuentaCorrienteDocumentosVencimientosService.FechaVencimiento_NombreCol, sesion);
                                    for (int j = 0; j < dtCtacteDocumentosVencimientos.Rows.Count; j++)
                                    {
                                        decimal personaId;


                                        if (cabeceraRow.DESCUENTO_DOC_CON_RECURSO.Equals(Definiciones.SiNo.Si))
                                        {
                                            personaId = cabeceraRow.PERSONA_ID;
                                        }
                                        else
                                        {
                                            if (dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.PersonaId_NombreCol].Equals(DBNull.Value))
                                                personaId = cabeceraRow.PERSONA_ID;
                                            else
                                                personaId = (decimal)dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.PersonaId_NombreCol];
                                        }


                                        CuentaCorrientePersonasService.AgregarCredito(
                                                        personaId,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                        cabeceraRow.CASO_ID,
                                                        (decimal)dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.MonedaId_NombreCol],
                                                        (decimal)dtDetalles.Rows[i][DescuentoDocumentosClienteDetalleService.CotizacionMoneda_NombreCol],
                                                        new decimal[] { Definiciones.Impuestos.Exenta },
                                                        new decimal[] { (decimal)dtCtacteDocumentosVencimientos.Rows[j][CuentaCorrienteDocumentosVencimientosService.Monto_NombreCol] },
                                                        "Vto " + (j+1) + "/" + dtCtacteDocumentosVencimientos.Rows.Count + ".",
                                                        (DateTime)dtCtacteDocumentosVencimientos.Rows[j][CuentaCorrienteDocumentosVencimientosService.FechaVencimiento_NombreCol],
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        (decimal)dtCtacteDocumentosVencimientos.Rows[j][CuentaCorrienteDocumentosVencimientosService.Id_NombreCol],
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        j+1,
                                                        dtCtacteDocumentosVencimientos.Rows.Count,
                                                        sesion);
                                    }
                                    #endregion crear vencimientos documento

                                    #endregion Afectar ctacte agregando credito
                                }
                            }
                        }
                    }
                    //Vigente a Cerrado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Vigente) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //Ninguna, la transicion es realizada por el sistema y no por el usuario
                        exito = true;

                        if (cambio_pedido_por_usuario)
                        {
                            exito = false;
                            mensaje = "La transición de Vigente a Cerrado es realizada por el sistema cuando se salda la deuda";
                        }

                    }
                    //Borrador a Anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Ninguna
                        exito = true;

                    }
                    //Pendiente a Anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Ninguna
                        exito = true;

                    }
                    //PreAprobado a Anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.PreAprobado) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Ninguna
                        exito = true;

                    }
                    //Aprobado a Anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Revertir en la ctacte de la persona el debito asignado en transicion anterior
                        exito = true;

                        try
                        {
                            if (cabeceraRow.AFECTAR_CTACTE_PERSONA_DEBITO.Equals(Definiciones.SiNo.Si))
                            {
                                //Revertir debito
                                CuentaCorrientePersonasService.DeshacerAgregarDebitoMovimientoPrincipal(cabeceraRow.CASO_ID, sesion);
                            }
                        }
                        catch (Exception exp)
                        {
                            exito = false;
                            mensaje = exp.Message;
                        }
                    }
                    //Pendiente a Rechazado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Rechazado))
                    {
                        //Acciones
                        //ninguna
                        exito = true;
                    }
                    //Aprobado a Rechazado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Rechazado))
                    {
                        //Acciones
                        //Revertir en la ctacte de la persona el debito asignado en transicion anterior
                        exito = true;

                        try
                        {
                            //Revertir debito
                            CuentaCorrientePersonasService.DeshacerAgregarDebitoMovimientoPrincipal(cabeceraRow.CASO_ID, sesion);
                        }
                        catch (Exception exp)
                        {
                            exito = false;
                            mensaje = exp.Message;
                        }
                    }

                    if (exito)
                    {
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.DESCUENTO_DOCUMENTOS_CLIENTECollection.Update(cabeceraRow);
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
            
            try {
                CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                DESCUENTO_DOCUMENTOS_CLIENTERow cabeceraRow = sesion.Db.DESCUENTO_DOCUMENTOS_CLIENTECollection.GetByCASO_ID(caso_id)[0];

                //Aprobado
                if (cabeceraRow.AFECTAR_CTACTE_PERSONA_DEBITO.Equals(Definiciones.SiNo.Si))
                {
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        #region crear la OP
                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.DescuentoDocumentosClienteGenerarOPAlAprobar).Equals(Definiciones.SiNo.Si))
                        {
                            GenerarOrdenDePago(cabeceraRow.ID);
                        }
                        #endregion crear la OP
                    }
                }
            } 
            catch (Exception exp) 
            {
                throw exp;
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
            DESCUENTO_DOCUMENTOS_CLIENTERow row = sesion.Db.DESCUENTO_DOCUMENTOS_CLIENTECollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE;
        }

        #endregion Implementacion de metodos abstract

        #region GenerarOrdenDePago
        static string GenerarOrdenDePago(decimal descuento_documento_cliente_id)
        {
            try {
                using (SessionService sesion = new SessionService()) {
                    OrdenesPagoService ordenPago = new OrdenesPagoService();
                    OrdenesPagoDetalleService ordenPagoDetalle = new OrdenesPagoDetalleService();
                    DESCUENTO_DOCUMENTOS_CLI_INF_CRow descuento = sesion.Db.DESCUENTO_DOCUMENTOS_CLI_INF_CCollection.GetRow(DescuentoDocumentosClienteService.Id_NombreCol + " = " + descuento_documento_cliente_id);
                    System.Collections.Hashtable campos = new System.Collections.Hashtable();

                    campos.Add(OrdenesPagoService.Fecha_NombreCol, descuento.FECHA);
                    campos.Add(OrdenesPagoService.NroReciboBeneficiario_NombreCol, "A confirmar");
                    campos.Add(OrdenesPagoService.NombreBeneficiario_NombreCol, descuento.PERSONA_NOMBRE_COMPLETO);
                    campos.Add(OrdenesPagoService.Observacion_NombreCol, "Orden de pago generada por Descuento de Documentos Cliente N°" + descuento.NRO_COMPROBANTE);
                    campos.Add(OrdenesPagoService.ObservacionInterna_NombreCol, "Orden de pago generada por Descuento de Documentos Cliente N°" + descuento.NRO_COMPROBANTE);
                    campos.Add(OrdenesPagoService.OrdenPagoTipoId_NombreCol, Definiciones.TiposOrdenesPago.PagoAPersona);
                    campos.Add(OrdenesPagoService.SucursalOrigenId_NombreCol, descuento.SUCURSAL_ID);
                    campos.Add(OrdenesPagoService.MonedaId_NombreCol, descuento.MONEDA_ID);
                    campos.Add(OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol, descuento.CTACTE_CAJA_TESORERIA_ID);
                    campos.Add(OrdenesPagoService.PersonaId_NombreCol, descuento.PERSONA_ID);
                    campos.Add(OrdenesPagoService.CasoOriginarioId_NombreCol, descuento.CASO_ID);

                    //Guardar los datos
                    decimal vCasoId = Definiciones.Error.Valor.EnteroPositivo;
                    string vCasoEstado = string.Empty;
                    bool exito = OrdenesPagoService.Guardar(campos, true, ref vCasoId, ref vCasoEstado);
                    decimal ordenId = OrdenesPagoService.GetOrdenPagoIDPorCaso2(vCasoId);

                    System.Collections.Hashtable campos2 = new System.Collections.Hashtable();
                    DataTable detalles = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CasoId_NombreCol + " = " + descuento.CASO_ID, CuentaCorrientePersonasService.Id_NombreCol, sesion);
                    foreach (DataRow dr in detalles.Rows) {
                        campos2.Add(OrdenesPagoDetalleService.OrdenPagoId_NombreCol, ordenId);
                        campos2.Add(OrdenesPagoDetalleService.CtactePersonaId_NombreCol, dr[CuentaCorrientePersonasService.Id_NombreCol]);
                        campos2.Add(OrdenesPagoDetalleService.MonedaOrigenId_NombreCol, dr[CuentaCorrientePersonasService.MonedaId_NombreCol]);
                        campos2.Add(OrdenesPagoDetalleService.MontoOrigen_NombreCol, dr[CuentaCorrientePersonasService.Debito_NombreCol]);
                        campos2.Add(OrdenesPagoDetalleService.Observacion_NombreCol, "Detalle Generado por Descuento de Documentos N°" + descuento.NRO_COMPROBANTE);
                        campos2.Add(OrdenesPagoDetalleService.CasoReferidoId_NombreCol, descuento.CASO_ID);
                        campos2.Add(OrdenesPagoDetalleService.FlujoReferidoId_NombreCol, (decimal)Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES);
                        //Guardar los datos
                        OrdenesPagoDetalleService.Guardar(campos2);
                    }

                    return ordenId.ToString();
                }
            } catch (Exception e) {
                throw e;
            }
        }
        #endregion GenerarOrdenDePago

        #region Generar Factura Proveedor
        private bool GenerarFacturaProveedor(DESCUENTO_DOCUMENTOS_CLIENTERow cabeceraRow, out string mensaje, SessionService sesion)
        {
            bool exito = true;
            mensaje = string.Empty;
            System.Collections.Hashtable campos = new System.Collections.Hashtable();

            campos.Add(FacturasProveedorService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ID);

            string clausulas = ProveedoresService.PersonaId_NombreCol + " = " + cabeceraRow.PERSONA_ID.ToString();
            DataTable dt = ProveedoresService.GetProveedoresDataTable2(clausulas, string.Empty, true, sesion);
            if (dt.Rows.Count == 0)
            {
                mensaje = "La persona seleccionada no es un proveedor";
                exito = false;
            }
            else
            {
                campos.Add(FacturasProveedorService.ProveedorId_NombreCol, (decimal)dt.Rows[0][ProveedoresService.Id_NombreCol]);
            }

            DataTable dtDepositos = StockDepositosService.GetStockDepositosDataTable2(cabeceraRow.SUCURSAL_ID);

            if (dtDepositos.Rows.Count == 0)
            {
                mensaje = "No existe ningun deposito creado para esta sucursal";
                exito = false;
            }
            else
            {
                campos.Add(FacturasProveedorService.StockDepositoId_NombreCol, (decimal)dtDepositos.Rows[0][StockDepositosService.Id_NombreCol]);
            }
            campos.Add(FacturasProveedorService.CtacteCondicionPagoId_NombreCol, Definiciones.CondicionPago.Contado);
            campos.Add(FacturasProveedorService.Fecha_NombreCol, cabeceraRow.FECHA);
            campos.Add(FacturasProveedorService.FechaFactura_NombreCol, cabeceraRow.FECHA);
            campos.Add(FacturasProveedorService.FechaVencimientoTimbrado_NombreCol, cabeceraRow.FECHA);
            campos.Add(FacturasProveedorService.MonedaId_NombreCol, cabeceraRow.MONEDA_ID);
            campos.Add(FacturasProveedorService.NumeroContrato_NombreCol, string.Empty);
            campos.Add(FacturasProveedorService.NroComprobante_NombreCol, "FP-" + cabeceraRow.NRO_COMPROBANTE);
            campos.Add(FacturasProveedorService.NroTimbrado_NombreCol, "--");
            campos.Add(FacturasProveedorService.Observacion_NombreCol, string.Empty);
            campos.Add(FacturasProveedorService.NroDocumentoExterno_NombreCol, string.Empty);
            campos.Add(FacturasProveedorService.TipoFacturaProveedorId_NombreCol, Definiciones.TipoFacturaProveedor.Gastos);
            campos.Add(FacturasProveedorService.PagarPorFondoFijo_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasProveedorService.PasibleRetencion_NombreCol,  Definiciones.SiNo.No);
            campos.Add(FacturasProveedorService.AfectaCtacteProveedor_NombreCol, Definiciones.SiNo.Si);
            campos.Add(FacturasProveedorService.AfectaCtactePersona_NombreCol,  Definiciones.SiNo.No);
            campos.Add(FacturasProveedorService.AfectaCreditoFiscalEmpresa_NombreCol, Definiciones.SiNo.Si);
            campos.Add(FacturasProveedorService.CasoAsociadoId_NombreCol, cabeceraRow.CASO_ID);
            campos.Add(FacturasProveedorService.EsTicket_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol, 0);
            campos.Add(FacturasProveedorService.CentroCostoObligatorio_NombreCol, Definiciones.SiNo.No);

            if (exito)
            {
                //Guardar los datos
                decimal vCasoId = Definiciones.Error.Valor.EnteroPositivo;
                string vCasoEstado = string.Empty;
                FacturasProveedorService.Guardar(campos, true, ref vCasoId, ref vCasoEstado, sesion);
                DataTable registroActual = new DataTable();

                clausulas = FacturasProveedorService.CasoId_NombreCol + " = " + vCasoId;

                registroActual = FacturasProveedorService.GetFacturaProveedorDataTable2(clausulas, string.Empty, sesion);
                System.Collections.Hashtable camposDetalle = new System.Collections.Hashtable();

                // Se define el tipo de detalle
                camposDetalle.Add(FacturasProveedorDetalleService.TipoDetalle_NombreCol, (decimal)Definiciones.TiposDetalleFacturaProveedor.Estandar);
                camposDetalle.Add(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol, registroActual.Rows[0][FacturasProveedorService.Id_NombreCol]);

                clausulas = DescuentoDocumentosClienteDetalleService.DescuentoDocumentosCliId_NombreCol + " = " + cabeceraRow.ID.ToString();
                DataTable detDescuentos = DescuentoDocumentosClienteDetalleService.GetDescuentoDocumentosClienteDetalleDataTable(clausulas, string.Empty, sesion);

                object totalSaldo = detDescuentos.Compute("Sum(" + DescuentoDocumentosClienteDetalleService.TotalValorNominal_NombreCol + ")", "");

                camposDetalle.Add(FacturasProveedorDetalleService.UnidadIdDestino_NombreCol, Definiciones.UnidadesMedida.Simbolo.Unidades);
                camposDetalle.Add(FacturasProveedorDetalleService.Observacion_NombreCol, "Desembolso en concepto de descuento documento caso nro : (" + cabeceraRow.CASO_ID + ")");
                camposDetalle.Add(FacturasProveedorDetalleService.PrecioBrutoUnitarioDestino_NombreCol, (decimal)totalSaldo);
                camposDetalle.Add(FacturasProveedorDetalleService.PorcentajeDescuento_NombreCol, 0);
                camposDetalle.Add(FacturasProveedorDetalleService.ImpuestoId_NombreCol, Definiciones.Impuestos.Exenta);
                camposDetalle.Add(FacturasProveedorDetalleService.CantidadEmbaladaDestino_NombreCol, 0);
                camposDetalle.Add(FacturasProveedorDetalleService.CantidadUnidadDestino_NombreCol, 1);

                if (FacturasProveedorDetalleService.Guardar(camposDetalle, true, sesion).Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    mensaje = "Error al generar el detalle de la factura";
                    exito = false;
                }
            }

            return exito;
        }

        #endregion Generar Factura Proveedor

        #region GetDescuentoDocumentosClienteDataTable
        /// <summary>
        /// Gets the descuento documentos cliente data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetDescuentoDocumentosClienteDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESCUENTO_DOCUMENTOS_CLIENTECollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetDescuentoDocumentosClienteDataTable

        #region GetDescuentoDocumentosClienteInfoCompleta
        /// <summary>
        /// Gets the descuento documentos cliente info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetDescuentoDocumentosClienteInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESCUENTO_DOCUMENTOS_CLI_INF_CCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetDescuentoDocumentosClienteInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                DESCUENTO_DOCUMENTOS_CLIENTERow row = new DESCUENTO_DOCUMENTOS_CLIENTERow();

                try
                {
                    SucursalesService sucursal = new SucursalesService();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[DescuentoDocumentosClienteService.SucursalId_NombreCol].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.SUCURSAL_ID = (decimal)campos[DescuentoDocumentosClienteService.SucursalId_NombreCol];
                        row.ID = sesion.Db.GetSiguienteSecuencia("DESCUENTO_DOCUMENTOS_CLI_SQC");
                        
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.DESCUENTO_DOCUMENTOS_CLIENTECollection.GetByPrimaryKey((decimal)campos[DescuentoDocumentosClienteService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.MONTO_GASTO_EXTRA = (decimal)campos[DescuentoDocumentosClienteService.MontoGastoExtra_NombreCol];
                    row.AUTONUMERACION_ID = (decimal)campos[DescuentoDocumentosClienteService.AutonumeracionId_NombreCol];
                    row.NRO_COMPROBANTE = (string)campos[DescuentoDocumentosClienteService.NroComprobante_NombreCol];
                    row.PORCENTAJE_DIARIO_MORA = (decimal)campos[DescuentoDocumentosClienteService.PorcentajeDiarioMora_NombreCol];
                    row.OBSERVACION = (string)campos[DescuentoDocumentosClienteService.Observacion_NombreCol];
                    row.USAR_INTERES_EN_CALCULO = (string)campos[DescuentoDocumentosClienteService.UsarInteresEnCalculo_NombreCol];
                    row.INTERES_INCLUYE_IMPUESTO = (string)campos[DescuentoDocumentosClienteService.InteresIncluyeImpuesto_NombreCol];

                    if (row.FECHA.Equals(DBNull.Value) || row.FECHA != (DateTime)campos[DescuentoDocumentosClienteService.Fecha_NombreCol])
                    {
                        row.FECHA = (DateTime)campos[DescuentoDocumentosClienteService.Fecha_NombreCol];
                        DescuentoDocumentosClienteDetalleService.ActualizarValorEfectivo(row.ID, row.FECHA, row.INTERES_INCLUYE_IMPUESTO == Definiciones.SiNo.Si, sesion);
                    }

                    if (row.MONEDA_ID.Equals(DBNull.Value) || row.MONEDA_ID != (decimal)campos[DescuentoDocumentosClienteService.MonedaId_NombreCol])
                    {
                        if (MonedasService.EstaActivo((decimal)(campos[DescuentoDocumentosClienteService.MonedaId_NombreCol])))
                            row.MONEDA_ID = (decimal)campos[DescuentoDocumentosClienteService.MonedaId_NombreCol];
                        else
                            throw new System.Exception("La moneda no está activa.");

                        row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, row.FECHA, sesion);
                        if(row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("Debe actualizarse la cotización de la moneda.");
                    }

                    if (campos.Contains(AfectarCtaCtePersonaDebito_NombreCol))
                        row.AFECTAR_CTACTE_PERSONA_DEBITO = campos[AfectarCtaCtePersonaDebito_NombreCol].ToString();
                    else
                        row.AFECTAR_CTACTE_PERSONA_DEBITO = Definiciones.SiNo.No;

                    if (campos.Contains(DescuentoDocConRecurso_NombreCol))
                        row.DESCUENTO_DOC_CON_RECURSO = campos[DescuentoDocConRecurso_NombreCol].ToString();
                    else
                        row.DESCUENTO_DOC_CON_RECURSO = Definiciones.SiNo.No;


                    if (row.FUNCIONARIO_ID.Equals(DBNull.Value) || row.FUNCIONARIO_ID != (decimal)campos[DescuentoDocumentosClienteService.FuncionarioId_NombreCol])
                    {
                        if (FuncionariosService.EstaActivo((decimal)(campos[DescuentoDocumentosClienteService.FuncionarioId_NombreCol])))
                            row.FUNCIONARIO_ID = (decimal)campos[DescuentoDocumentosClienteService.FuncionarioId_NombreCol];
                        else
                            throw new System.Exception(Traducciones.El_funcionario_esta_inactivo);
                    }

                    if (row.PERSONA_ID.Equals(DBNull.Value) || row.PERSONA_ID != (decimal)campos[DescuentoDocumentosClienteService.PersonaId_NombreCol])
                    {
                        if (PersonasService.EstaActivo((decimal)(campos[DescuentoDocumentosClienteService.PersonaId_NombreCol])))
                            row.PERSONA_ID = (decimal)campos[DescuentoDocumentosClienteService.PersonaId_NombreCol];
                        else
                            throw new System.Exception(Traducciones.La_persona_esta_inactiva);
                    }
                    
                    if (campos.Contains(DescuentoDocumentosClienteService.AutonumeracionId_NombreCol))
                    {
                        row.AUTONUMERACION_ID = (decimal)campos[DescuentoDocumentosClienteService.AutonumeracionId_NombreCol];
                    }
                    row.NRO_COMPROBANTE = campos[DescuentoDocumentosClienteService.NroComprobante_NombreCol].ToString();

                    if (campos.Contains(DescuentoDocumentosClienteService.CtaCteCajaTesoreriaId_NombreCol))
                        row.CTACTE_CAJA_TESORERIA_ID = (decimal)campos[DescuentoDocumentosClienteService.CtaCteCajaTesoreriaId_NombreCol];
                    else
                        row.IsCTACTE_CAJA_TESORERIA_IDNull = true;

                    if (campos.Contains(DescuentoDocumentosClienteService.PersonaGaranteId_NombreCol))
                    {
                        row.PERSONA_GARANTE_ID = (decimal)campos[DescuentoDocumentosClienteService.PersonaGaranteId_NombreCol];
                    }

                    if (insertarNuevo) sesion.Db.DESCUENTO_DOCUMENTOS_CLIENTECollection.Insert(row);
                    else sesion.Db.DESCUENTO_DOCUMENTOS_CLIENTECollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                    camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.FUNCIONARIO_ID);
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

                    exito = false;
                    throw;
                }
                return exito;
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified caso_id.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static bool Borrar(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    bool exito = true;
                    string mensaje = "Error.";

                    //Se obtiene el caso a ser borrado
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    DESCUENTO_DOCUMENTOS_CLIENTERow cabecera = sesion.Db.DESCUENTO_DOCUMENTOS_CLIENTECollection.GetByCASO_ID(caso_id)[0];
                    DataTable dtDetalles;

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        DescuentoDocumentosClienteDetalleService.BorrarTodos(cabecera.ID, sesion);
                        sesion.Db.DESCUENTO_DOCUMENTOS_CLIENTECollection.DeleteByCASO_ID(caso_id);
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

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "DESCUENTO_DOCUMENTOS_CLIENTE"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.AUTONUMERACION_IDColumnName; }
        }
        public static string AfectarCtaCtePersonaDebito_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.AFECTAR_CTACTE_PERSONA_DEBITOColumnName; }
        }
        public static string DescuentoDocConRecurso_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.DESCUENTO_DOC_CON_RECURSOColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.CASO_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.COTIZACION_MONEDAColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.FECHAColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.MONEDA_IDColumnName; }
        }
        public static string InteresIncluyeImpuesto_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.INTERES_INCLUYE_IMPUESTOColumnName; }
        }
        public static string MontoGastoExtra_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.MONTO_GASTO_EXTRAColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.OBSERVACIONColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.PERSONA_IDColumnName; }
        }
        public static string PorcentajeDiarioMora_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.PORCENTAJE_DIARIO_MORAColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.SUCURSAL_IDColumnName; }
        }
        public static string UsarInteresEnCalculo_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.USAR_INTERES_EN_CALCULOColumnName; }
        }
        public static string CtaCteCajaTesoreriaId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.CTACTE_CAJA_TESORERIA_IDColumnName; }
        }
        public static string PersonaGaranteId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLIENTECollection.PERSONA_GARANTE_IDColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_INF_CCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaFuncionarioNombreCompleto_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_INF_CCollection.FUNCIONARIO_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_INF_CCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_INF_CCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaPersonaNombreCompleto_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_INF_CCollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_INF_CCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_INF_CCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaTotalRetencion_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_INF_CCollection.TOTAL_RETENCIONColumnName; }
        }
        public static string VistaTotalValorEfectivo_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_INF_CCollection.TOTAL_VALOR_EFECTIVOColumnName; }
        }
        public static string VistaTotalValorNominal_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_INF_CCollection.TOTAL_VALOR_NOMINALColumnName; }
        }
        #endregion Accessors
    }
}
