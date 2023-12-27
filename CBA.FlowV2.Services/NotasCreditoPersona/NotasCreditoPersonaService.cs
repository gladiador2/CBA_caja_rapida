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
#endregion Using

namespace CBA.FlowV2.Services.NotasCreditoPersona
{
    public class NotasCreditoPersonaService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var cabecera = (NotasCreditoPersonaService)caso_cabecera;
            var detalle = (NotasCreditoPersonaDetalleService)caso_detalle;
            
            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);

            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, cabecera.DepositoId.Value);
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
            mensaje = string.Empty;
            try
            {
                CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                NOTAS_CREDITO_PERSONASRow cabeceraRow = sesion.Db.NOTAS_CREDITO_PERSONASCollection.GetByCASO_ID(caso_id)[0];
                NOTAS_CREDITO_PERSONAS_DETRow[] detalles = sesion.Db.NOTAS_CREDITO_PERSONAS_DETCollection.GetByNOTA_CREDITO_PERSONA_ID(cabeceraRow.ID);
                string valorAnteriorNC = cabeceraRow.ToString();

                bool tieneDetalles = NotasCreditoPersonaDetalleService.NcTieneDetalles(cabeceraRow.ID, sesion);

                if (tieneDetalles)
                {
                    #region BORRADOR A ANULADO
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        #region Actualizar Cantidad Devuelta
                        //Si es una devolucion se debe actulizar la columna de cantidad devuelta por cada item de la nota de crédito
                        NotasCreditoPersonaService notaCreditoPersona = new NotasCreditoPersonaService();
                        FACTURAS_CLIENTE_DETALLERow rowFacturaDetalle = new FACTURAS_CLIENTE_DETALLERow();
                        for (int i = 0; i < detalles.Length; i++)
                        {
                            if (!detalles[i].IsFACTURA_CLIENTE_DETALLE_IDNull)
                            {
                                //Se obtiene el item de factura asociada al detalle y Se repone la cantidad a la factura
                                FacturasClienteDetalleService.SumarCantidadDevueltaNC(detalles[i].FACTURA_CLIENTE_DETALLE_ID, -detalles[i].CANTIDAD, sesion);
                            }
                            else
                            {
                                FacturasClienteService.RecalcularTotalNetoDespuesDeNC(detalles[i].FACTURA_CLIENTE_ID, -detalles[i].TOTAL, sesion);
                            }
                        }
                        #endregion Actualizar Cantidad Devuelta

                        exito = true;
                        revisarRequisitos = true;
                    }
                    #endregion BORRADOR A ANULADO

                    #region BORRADOR A PENDIENTE
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        exito = true;
                        revisarRequisitos = true;

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado
                    }
                    #endregion BORRADOR A PENDIENTE

                    #region PENDIENTE A BORRADOR
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                    }
                    #endregion PENDIENTE A BORRADOR

                    #region PENDIENTE A ANULADO
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        #region Actualizar Cantidad Devuelta
                        //Si es una devolucion se debe actulizar la columna de cantidad devuelta por cada item de la nota de crédito
                        NotasCreditoPersonaService notaCreditoPersona = new NotasCreditoPersonaService();
                        FACTURAS_CLIENTE_DETALLERow rowFacturaDetalle = new FACTURAS_CLIENTE_DETALLERow();
                        string valorAnterior = string.Empty;
                        for (int i = 0; i < detalles.Length; i++)
                        {
                            if (!detalles[i].IsFACTURA_CLIENTE_DETALLE_IDNull)
                            {
                                //Se obtiene el item de factura asociada al detalle y se repone la cantidad a la factura
                                FacturasClienteDetalleService.SumarCantidadDevueltaNC(detalles[i].FACTURA_CLIENTE_DETALLE_ID, -detalles[i].CANTIDAD, sesion);
                            }
                            else
                            {
                                FacturasClienteService.RecalcularTotalNetoDespuesDeNC(detalles[i].FACTURA_CLIENTE_ID, -detalles[i].TOTAL, sesion);
                            }
                        }
                        #endregion Actualizar Cantidad Devuelta
                        exito = true;
                    }
                    #endregion PENDIENTE A ANULADO

                    #region PENDIENTE A PRE-APROBADO
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.PreAprobado))
                    {
                        exito = true;

                        #region Generar numeracion
                        if (exito && (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Length <= 0))
                        {
                            try
                            {
                                if (cabeceraRow.IsAUTONUMERACION_IDNull)
                                    throw new Exception("Debe indicarse el talonario.");

                                if (AutonumeracionesService.EsGeneracionManual(cabeceraRow.AUTONUMERACION_ID, sesion))
                                {
                                    throw new Exception("Debe indicar el número de comprobante que es de numeración manual.");
                                }
                                else
                                {
                                    //Se debe traer el siguiente numero para completar las validaciones. Aun no se debe actualizar el talonario
                                    string nroComprobanteAux = AutonumeracionesService.ConsultarSiguienteNumero(cabeceraRow.AUTONUMERACION_ID, sesion);
                                    decimal nroComprobanteNumerico = Definiciones.Error.Valor.EnteroPositivo;

                                    if (this.GetExisteNroComprobante(cabeceraRow.ID, cabeceraRow.AUTONUMERACION_ID, nroComprobanteAux, sesion))
                                        throw new Exception("Ya existe una NC con el mismo número de comprobante.");

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

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado
                    }
                    #endregion PENDIENTE A PRE-APROBADO

                    #region PRE-APROBADO A ANULADO
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.PreAprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        #region Actualizar Cantidad Devuelta
                        //Si es una devolucion se debe actulizar la columna de cantidad devuelta por cada item de la nota de crédito
                        NotasCreditoPersonaService notaCreditoPersona = new NotasCreditoPersonaService();
                        FACTURAS_CLIENTE_DETALLERow rowFacturaDetalle = new FACTURAS_CLIENTE_DETALLERow();
                        string valorAnterior = string.Empty;
                        for (int i = 0; i < detalles.Length; i++)
                        {
                            if (!detalles[i].IsFACTURA_CLIENTE_DETALLE_IDNull)
                            {
                                //Se obtiene el item de factura asociada al detalle y se repone la cantidad a la factura
                                FacturasClienteDetalleService.SumarCantidadDevueltaNC(detalles[i].FACTURA_CLIENTE_DETALLE_ID, -detalles[i].CANTIDAD, sesion);
                            }
                            else
                            {
                                FacturasClienteService.RecalcularTotalNetoDespuesDeNC(detalles[i].FACTURA_CLIENTE_ID, -detalles[i].TOTAL, sesion);
                            }
                        }
                        #endregion Actualizar Cantidad Devuelta

                        exito = true;

                    }
                    #endregion PRE-APROBADO A ANULADO

                    #region PRE-APROBADO A APROBADO
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.PreAprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        exito = true;

                        //Acciones
                        if (RepartosDetalleService.CasoEstaEnRepartoEnProceso(casoRow.ID))
                        {
                            exito = false;
                            mensaje = "El caso se encuentra en un Reparto en Proceso, por lo tanto no puede ser modificado";
                        }

                        if (cabeceraRow.IsCTACTE_CAJA_SUCURSAL_IDNull)
                            throw new Exception("Debe definirse la caja de sucursal asociada.");

                        if (exito)
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);

                        if (exito)
                        {
                            exito = true;
                            revisarRequisitos = true;
                            // AfectaStock, AfectaCostos, Descuenta las Comisiones
                            ProcesarDevolucion(caso_id, estado_destino, cabeceraRow, detalles, sesion);
                        }
                    }
                    #endregion PRE-APROBADO A APROBADO

                    #region APROBADO A CERRADO
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;

                        if (cambio_pedido_por_usuario)
                            throw new Exception("NotasCreditoPersonaService.ProcesarCambioEstado(). La transición Aprobado a Cerrado no puede ser realizada por un usuario.");
                    }
                    #endregion APROBADO A CERRADO

                    #region CERRADO A APROBADO
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Cerrado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;

                        if (cambio_pedido_por_usuario)
                            throw new Exception("NotasCreditoPersonaService.ProcesarCambioEstado(). La transición Cerrado a Aprobado no puede ser realizada por un usuario.");
                    }
                    #endregion CERRADO A APROBADO
                }
                else
                {
                    exito = false;
                    mensaje = "La Nota de Crédito debe tener al menos un detalle";
                }

                //Verificar si se cumplen los requisitos
                if (exito && revisarRequisitos)
                {
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                }

                if (exito)
                {
                    sesion.Db.CASOSCollection.Update(casoRow);
                    sesion.Db.NOTAS_CREDITO_PERSONASCollection.Update(cabeceraRow);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, cabeceraRow.ID, valorAnteriorNC, cabeceraRow.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, cabeceraRow.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, cabeceraRow.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ID);
                    camposCaso.Add(CasosService.PersonaId_NombreCol, cabeceraRow.PERSONA_ID);
                    camposCaso.Add(CasosService.FuncionarioId_NombreCol, cabeceraRow.FUNCIONARIO_COBRADOR_ID);
                    CasosService.ActualizarCampos(cabeceraRow.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos
                }
            }
            catch
            {
                // En serio esto no hace falta, el flujo de control nunca
                // llega a retornar este valor
                exito = false;
                throw;
            }
            return exito;
        }

        private static void ProcesarDevolucion(decimal caso_id, string estado_destino, NOTAS_CREDITO_PERSONASRow cabeceraRow, NOTAS_CREDITO_PERSONAS_DETRow[] detalles, SessionService sesion)
        {
            int politica = (int)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PoliticaNotaCredito);
            decimal[] impuestoId;
            decimal[] monto;
            CalcularMontoImpuesto(cabeceraRow, detalles, out impuestoId, out monto);
            AfectarCtaCte(cabeceraRow, impuestoId, monto, sesion);
            if (politica == Definiciones.PoliticasNotasCredito.General)
            {
                AfectarStockSimple(caso_id, estado_destino, cabeceraRow, detalles, politica, sesion);
            }
            else
            {
                if (politica == Definiciones.PoliticasNotasCredito.Especifica)
                {
                    if(TipoNotaCreditoService.AfectaStockComplejo((int)cabeceraRow.TIPO_NOTA_CREDITO_ID))
                        AfectarStockCodigoReingreso(caso_id, estado_destino, cabeceraRow, detalles, sesion);
                    else if (TipoNotaCreditoService.AfectaStockSimple((int)cabeceraRow.TIPO_NOTA_CREDITO_ID))
                        AfectarStockSimple(caso_id, estado_destino, cabeceraRow, detalles, politica, sesion);
                }
            }
            DescontarComisiones(sesion, detalles);
        }

        private static void DescontarComisiones(SessionService sesion, NOTAS_CREDITO_PERSONAS_DETRow[] detalles)
        {
            foreach (NOTAS_CREDITO_PERSONAS_DETRow detalle in detalles)
            {
                if (detalle.IsFACTURA_CLIENTE_DETALLE_IDNull)
                    continue;

                DataRow detalleFactura, factura;
                factura = FacturasClienteService.GetFacturaClienteDataTable(detalle.FACTURA_CLIENTE_ID).Rows[0];
                detalleFactura = FacturasClienteDetalleService.GetFacturaClienteDetalleEspecifico2(detalle.FACTURA_CLIENTE_DETALLE_ID).Rows[0];
                decimal vendedorComisionistaId = Definiciones.Error.Valor.EnteroPositivo;

                if (!Interprete.EsNullODBNull(detalleFactura[FacturasClienteDetalleService.VendedorComisionistaId_NombreCol]))
                    vendedorComisionistaId = (decimal)detalleFactura[FacturasClienteDetalleService.VendedorComisionistaId_NombreCol];
                else if (!Interprete.EsNullODBNull(factura[FacturasClienteService.VendedorId_NombreCol]))
                    vendedorComisionistaId = (decimal)factura[FacturasClienteService.VendedorId_NombreCol];
                else
                    continue;

                decimal porcentajeComision = (decimal)detalleFactura[FacturasClienteDetalleService.PorcentajeComisionVenta_NombreCol];
                decimal montoComision = (detalle.TOTAL - detalle.IMPUESTO_MONTO) * porcentajeComision / 100;

                if (montoComision != 0)
                {
                    FuncionariosComisionesService funcionarioComisiones = new FuncionariosComisionesService();
                    Hashtable campos = new Hashtable();
                    campos.Add(FuncionariosComisionesService.CasoId_NombreCol, factura[FacturasClienteService.CasoId_NombreCol]);
                    campos.Add(FuncionariosComisionesService.Cobrado_NombreCol, Definiciones.SiNo.No);
                    campos.Add(FuncionariosComisionesService.Cotizacion_NombreCol, (decimal)factura[FacturasClienteService.CotizacionDestino_NombreCol]);
                    campos.Add(FuncionariosComisionesService.Fecha_NombreCol, DateTime.Now);
                    campos.Add(FuncionariosComisionesService.FuncionarioId_NombreCol, vendedorComisionistaId);
                    campos.Add(FuncionariosComisionesService.MonedaId_NombreCol, (decimal)factura[FacturasClienteService.MonedaDestinoId_NombreCol]);
                    campos.Add(FuncionariosComisionesService.Monto_NombreCol, montoComision * (-1));
                    campos.Add(FuncionariosComisionesService.TipoComision_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
                    campos.Add(FuncionariosComisionesService.TipoFuncionario_NombreCol, Definiciones.TipoFuncionarioComision.Vendedor);
                    funcionarioComisiones.Guardar(campos, true, sesion);
                }
            }
        }

        private static void CalcularMontoImpuesto(NOTAS_CREDITO_PERSONASRow cabeceraRow, NOTAS_CREDITO_PERSONAS_DETRow[] detalles, out decimal[] impuestoId, out decimal[] monto)
        {
            Hashtable montoPorImpuesto = new Hashtable();

            decimal montoVerificacion;
            int indiceAux; for (int i = 0; i < detalles.Length; i++)
            {
                if (montoPorImpuesto.Contains(detalles[i].IMPUESTO_ID))
                    montoPorImpuesto[detalles[i].IMPUESTO_ID] = (decimal)montoPorImpuesto[detalles[i].IMPUESTO_ID] + detalles[i].TOTAL;
                else
                    montoPorImpuesto.Add(detalles[i].IMPUESTO_ID, detalles[i].TOTAL);
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

            if (Math.Round(cabeceraRow.MONTO_TOTAL, 4) != Math.Round(montoVerificacion, 4))
                throw new Exception("Error en NotasCreditoPersonasService.ProcesarCambioEstado(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + cabeceraRow.MONTO_TOTAL + ".");
        }

        private static void AfectarCtaCte(NOTAS_CREDITO_PERSONASRow cabeceraRow, decimal[] impuestoId, decimal[] monto, SessionService sesion)
        {
            CuentaCorrientePersonasService.AgregarDebito(
                (decimal)cabeceraRow.PERSONA_ID,
                Definiciones.Error.Valor.EnteroPositivo,
                Definiciones.CuentaCorrienteConceptos.DebitoPorFlujo,
                Definiciones.CuentaCorrienteValores.NotaDeCredito,
                cabeceraRow.CASO_ID,
                cabeceraRow.MONEDA_ID,
                cabeceraRow.COTIZACION_MONEDA,
                impuestoId,
                monto,
                string.Empty,
                cabeceraRow.FECHA.AddYears(1),
                Definiciones.Error.Valor.EnteroPositivo,
                Definiciones.Error.Valor.EnteroPositivo,
                Definiciones.Error.Valor.EnteroPositivo,
                Definiciones.Error.Valor.EnteroPositivo,
                Definiciones.Error.Valor.EnteroPositivo,
                Definiciones.Error.Valor.EnteroPositivo,
                Definiciones.Error.Valor.EnteroPositivo,
                sesion);
        }

        private static void AfectarStockSimple(decimal caso_id, string estado_destino, NOTAS_CREDITO_PERSONASRow cabeceraRow, NOTAS_CREDITO_PERSONAS_DETRow[] detalles, int politicaNC, SessionService sesion)
        {
            foreach (NOTAS_CREDITO_PERSONAS_DETRow detalle in detalles)
            {
                //Si el detalle es por una devolucion
                if (!detalle.IsTEXTO_PREDEFINIDO_IDNull)
                    continue;

                var articulo = new ArticulosService(detalle.ARTICULO_ID, sesion);
                StockService.Costo costo = null;

                if (articulo.Servicio == Definiciones.SiNo.No)
                {
                    var dtFactura = FacturasClienteService.GetFacturaClienteDataTable(detalle.FACTURA_CLIENTE_ID, sesion);
                    var sm = new StockMovimientoService();
                    sm.IniciarUsingSesion(sesion);
                    var smFacturaDet = sm.GetPrimero<StockMovimientoService>(new Filtro[]
                    {
                        new Filtro() { Columna = StockMovimientoService.Modelo.CASO_IDColumnName, Valor = dtFactura.Rows[0][FacturasClienteService.CasoId_NombreCol] },
                        new Filtro() { Columna = StockMovimientoService.Modelo.REGISTRO_IDColumnName, Valor = detalle.FACTURA_CLIENTE_DETALLE_ID },
                        new Filtro() { Columna = StockMovimientoService.Modelo.IDColumnName, OrderBy = true, Valor = "desc" }
                    });
                    sm.FinalizarUsingSesion();

                    if (smFacturaDet != null)
                    {
                        costo = new StockService.Costo()
                        {
                            moneda_origen_id = smFacturaDet.CostoMonedaOrigenId,
                            cotizacion_origen = smFacturaDet.CostoCotizacionMonedaOrigen,
                            costo_origen = smFacturaDet.CostoOrigen,
                            moneda_id = smFacturaDet.CostoMonedaId,
                            cotizacion = smFacturaDet.CostoCotizacionMoneda,
                            costo = smFacturaDet.Costo
                        };
                    }
                    else
                        costo = null;
                }

                StockService.modificarStock(
                    cabeceraRow.DEPOSITO_ID,
                    detalle.ARTICULO_ID,
                    detalle.CANTIDAD,
                    Definiciones.Stock.TipoMovimiento.NotaCreditoCliente,
                    caso_id,
                    detalle.LOTE_ID,
                    estado_destino,
                    sesion,
                    costo,
                    detalle.IMPUESTO_ID,
                    detalle.ID
                );
            }
        }

        private static void AfectarStockCodigoReingreso(decimal caso_id, string estado_destino, NOTAS_CREDITO_PERSONASRow cabeceraRow, NOTAS_CREDITO_PERSONAS_DETRow[] detalles, SessionService sesion)
        {

            foreach (NOTAS_CREDITO_PERSONAS_DETRow detalle in detalles)
            {
                //Si el detalle es por una devolucion
                if (!detalle.IsTEXTO_PREDEFINIDO_IDNull)
                    continue;
                
                // El detalle trae un costo modificado que coincide con la tasacion
                // Crea codigo de reingreso por lo que se debe modificar el código
                // y crear un nuevo lote, el metodo reasigna el lote y el articulo
                decimal lote_nuevo_id;
                decimal articulo_id;
                CrearArticuloDevuelto(detalle, (int)cabeceraRow.TIPO_NOTA_CREDITO_ID, cabeceraRow.ID, sesion, out lote_nuevo_id, out articulo_id);

                var articulo = new ArticulosService(articulo_id, sesion);
                StockService.Costo costo = null;

                if (articulo.Servicio == Definiciones.SiNo.No)
                {
                    costo = new StockService.Costo()
                    {
                        moneda_origen_id = cabeceraRow.MONEDA_ID,
                        cotizacion_origen = cabeceraRow.COTIZACION_MONEDA,
                        costo_origen = detalle.COSTO_UNITARIO - detalle.IMPUESTO_MONTO,
                    };
                }

                // Aumentamos su existencia
                StockService.modificarStock(
                    cabeceraRow.DEPOSITO_ID,
                    articulo_id,
                    detalle.CANTIDAD,
                    Definiciones.Stock.TipoMovimiento.NotaCreditoCliente,
                    caso_id,
                    lote_nuevo_id, 
                    estado_destino, 
                    sesion,
                    costo,
                    detalle.IMPUESTO_ID,
                    detalle.ID
                );
            }
        }

        private static void CrearArticuloDevuelto(NOTAS_CREDITO_PERSONAS_DETRow detalle, int tipo_nc, decimal nota_credito_id, SessionService sesion, out decimal lote_nuevo_id, out decimal articulo_id)
        {
            decimal costo_base = detalle.COSTO_UNITARIO - detalle.IMPUESTO_MONTO;

            ARTICULOSRow articulo = ArticulosService.CrearArticuloDevolucion(nota_credito_id, detalle.ARTICULO_ID, tipo_nc, detalle.LOTE_ID, out lote_nuevo_id, costo_base, sesion);
            articulo_id = articulo.ID;
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

        #region ActualizarImpreso
        public static void ActualizarImpreso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                NOTAS_CREDITO_PERSONASRow row = new NOTAS_CREDITO_PERSONASRow();
                string valorAnterior = string.Empty;
                try
                {
                    sesion.Db.BeginTransaction();

                    row = sesion.Db.NOTAS_CREDITO_PERSONASCollection.GetRow(CasoId_NombreCol + " = " + caso_id);
                    valorAnterior = row.ToString();
                    if (row.IMPRESO.Equals(Definiciones.SiNo.No))
                    {
                        if (row.IMPRESO == Definiciones.SiNo.No && EsActualizable && !AutonumeracionesService.EsGeneracionManual(row.AUTONUMERACION_ID, sesion))
                        {
                            row.FECHA = DateTime.Today;
                            row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, row.FECHA, sesion);
                        }

                        row.IMPRESO = Definiciones.SiNo.Si;

                        sesion.Db.NOTAS_CREDITO_PERSONASCollection.Update(row);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    }


                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        public static bool EsActualizable
        {
            get
            {
                return VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.ReportesActualizarImpreso).Equals(Definiciones.SiNo.Si);
            }
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
                NOTAS_CREDITO_PERSONASRow row = sesion.Db.NOTAS_CREDITO_PERSONASCollection.GetRow(CasoId_NombreCol + " = " + casoId);
                return row.IMPRESO.Equals(Definiciones.SiNo.Si);
            }
        }

        #endregion ActualizarImpreso

        #region Generar Nro. de Comprobante
        public string GenerarNumeroComprobante(decimal caso_id)
        {
            decimal numero;
            return GenerarNumeroComprobante(caso_id, out numero);
        }
        public string GenerarNumeroComprobante(decimal caso_id, out decimal numero_actual)
        {
            using (SessionService sesion = new SessionService())
            {
                return GenerarNumeroComprobante(caso_id, out numero_actual, sesion);
            }
        }

        public string GenerarNumeroComprobante(decimal caso_id, out decimal numero_actual, SessionService sesion)
        {
            NOTAS_CREDITO_PERSONASRow cabeceraRow = sesion.Db.NOTAS_CREDITO_PERSONASCollection.GetByCASO_ID(caso_id)[0];
            string nroComprobante = string.Empty;
            numero_actual = Definiciones.IdNull;
            if (cabeceraRow.IsAUTONUMERACION_IDNull)
            {
                throw new Exception("Debe indicarse el talonario o un número de comprobante manual.");
            }

            //Si no existe un nro. de comprobante se crea.
            if (cabeceraRow.NRO_COMPROBANTE == null)
            {
                if (!AutonumeracionesService.FuncionarioPuedeUsar(cabeceraRow.AUTONUMERACION_ID, cabeceraRow.FUNCIONARIO_COBRADOR_ID, sesion))
                    throw new Exception("El talonario no puede ser utilizado por el funcionario seleccionado.");

                nroComprobante = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, out numero_actual, sesion);

                if (this.GetExisteNroComprobante(cabeceraRow.ID, cabeceraRow.AUTONUMERACION_ID, nroComprobante, sesion))
                    throw new Exception("Ya existe una factura con el mismo número de comprobante.");
            }

            //Controlar que se logro asignar una numeracion
            if (nroComprobante.Equals(""))
            {
                throw new Exception("No se pudo asignar una numeración válida");
            }

            return nroComprobante;
        }
        #endregion Generar Nro. de Comprobante

        #region Getters

        #region GetExisteNroComprobante
        private bool GetExisteNroComprobante(decimal notaCredito_id, decimal autonumeracion_id, string nro_comprobante, SessionService sesion)
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

        #region GetNotaCreditoPersonaDataTable
        /// <summary>
        /// Gets the nota credito persona data table.
        /// </summary>
        /// <param name="nota_credito_persona_id">The nota_credito_persona_id.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetNotaCreditoPersonaDataTable(decimal nota_credito_persona_id)
        {
            return GetNotaCreditoPersonaDataTable(NotasCreditoPersonaService.Id_NombreCol + " = " + nota_credito_persona_id, string.Empty);
        }

        public static DataTable GetNotaCreditoPersonaDataTable2(decimal nota_credito_persona_id)
        {
            return GetNotaCreditoPersonaDataTable(NotasCreditoPersonaService.Id_NombreCol + " = " + nota_credito_persona_id, string.Empty);
        }

        public static DataTable GetNotaCreditoPersonaPorCasoDataTable2(decimal nota_credito_caso_id)
        {
            return GetNotaCreditoPersonaDataTable(NotasCreditoPersonaService.CasoId_NombreCol + " = " + nota_credito_caso_id, string.Empty);
        }

        public static DataTable GetNotaCreditoPersonaPorCasoDataTable2(decimal nota_credito_caso_id, SessionService sesion)
        {
            return GetNotaCreditoPersonaDataTable(NotasCreditoPersonaService.CasoId_NombreCol + " = " + nota_credito_caso_id, string.Empty, sesion);
        }

        public static DataTable GetNotaCreditoPersonaDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaCreditoPersonaDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaCreditoPersonaDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.NOTAS_CREDITO_PERSONASCollection.GetAsDataTable(clausulas, orden);
        }

        #endregion GetNotaCreditoPersonaDataTable

        #region GetNotaCreditoPersona
        /// <summary>
        /// Gets the nota de credito persona.
        /// </summary>
        /// <param name="nota_credito_persona_id">The nota_credito_persona_id.</param>
        /// <returns></returns>
        public static NOTAS_CREDITO_PERSONASRow GetNotaCreditoPersona(decimal nota_credito_persona_id, SessionService sesion)
        {
            string clausulas = NotasCreditoPersonaService.Id_NombreCol + " = " + nota_credito_persona_id;
            NOTAS_CREDITO_PERSONASRow[] rows = sesion.Db.NOTAS_CREDITO_PERSONASCollection.GetAsArray(clausulas, NotasCreditoPersonaService.Id_NombreCol);
            if (rows.Length > 0)
                return rows[0];
            else
                throw new Exception("Nota de Crédito no encontrada.");
        }
        #endregion GetNotaCreditoPersona

        #region GetNotaCreditoPersonaInfoCompleta
        /// <summary>
        /// Gets the nota credito persona info completa.
        /// </summary>
        /// <param name="nota_credito_persona_id">The nota_credito_persona_id.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetNotaCreditoPersonaInfoCompleta(decimal nota_credito_persona_id)
        {
            return GetNotaCreditoPersonaInfoCompleta(NotasCreditoPersonaService.Id_NombreCol + " = " + nota_credito_persona_id, string.Empty);
        }
        public static DataTable GetNotaCreditoPersonaInfoCompleta2(decimal nota_credito_persona_id)
        {
            return GetNotaCreditoPersonaInfoCompleta2(NotasCreditoPersonaService.Id_NombreCol + " = " + nota_credito_persona_id, string.Empty);
        }

        /// <summary>
        /// Gets the nota credito persona info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetNotaCreditoPersonaInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.NOTAS_CREDITO_PERSONA_INF_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        public static DataTable GetNotaCreditoPersonaInfoCompleta2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaCreditoPersonaInfoCompleta2(clausulas, orden, sesion);
            }
        }
        public static DataTable GetNotaCreditoPersonaInfoCompleta2(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.NOTAS_CREDITO_PERSONA_INF_COMPCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetNotaCreditoPersonaInfoCompleta

        #region GetNotaCreditoPersonaPorCaso
        /// <summary>
        /// Gets the nota credito persona por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetNotaCreditoPersonaPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.NOTAS_CREDITO_PERSONASCollection.GetAsDataTable(NotasCreditoPersonaService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }

        /// <summary>
        /// Gets the nota credito persona por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetNotaCreditoPersonaPorCasoInfoCompleta(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.NOTAS_CREDITO_PERSONA_INF_COMPCollection.GetAsDataTable(NotasCreditoPersonaService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetNotaCreditoPersonaPorCaso

        #region GetMontoDevuelto
        /// <summary>
        /// Gets the monto devuelto.
        /// </summary>
        /// <param name="nota_credito_id">The nota_credito_id.</param>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <param name="cantidad_devuelta">The cantidad_devuelta.</param>
        /// <returns></returns>
        public static decimal GetMontoDevuelto(decimal nota_credito_id, decimal factura_cliente_detalle_id, decimal cantidad_devuelta)
        {
            using (SessionService sesion = new SessionService())
            {
                if (cantidad_devuelta <= 0) return 0;

                DataTable dtFacturaDet = FacturasClienteDetalleService.GetFacturaClienteDetalleDataTable(FacturasClienteDetalleService.Id_NombreCol + " = " + factura_cliente_detalle_id, string.Empty);
                DataTable dtFactura = FacturasClienteService.GetFacturaClienteDataTable(FacturasClienteService.Id_NombreCol + " = " + dtFacturaDet.Rows[0][FacturasClienteDetalleService.FacturaClienteId_NombreCol], string.Empty);
                DataTable dtNotaCredito = NotasCreditoPersonaService.GetNotaCreditoPersonaDataTable(NotasCreditoPersonaService.Id_NombreCol + " = " + nota_credito_id, string.Empty);
                decimal politicaNotaCredito = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PoliticaNotaCredito);

                decimal porcentaje = (decimal)dtFactura.Rows[0][FacturasClienteService.PorcentajeDescSobreTotal_NombreCol] / 100M;

                //calculamos el monto unitario
                decimal PrecioUnitario;
                decimal CantidadTotal = (decimal)dtFacturaDet.Rows[0][FacturasClienteDetalleService.CantidadUnitariaTotalDest_NombreCol];
                decimal CantidadDevuelta = (decimal)dtFacturaDet.Rows[0][FacturasClienteDetalleService.CantidadDevueltaNotaCredito_NombreCol];
                decimal total_neto_luego_de_nc = (decimal)dtFacturaDet.Rows[0][FacturasClienteDetalleService.TotalNetoLuegoDeNC_NombreCol];
                decimal total_neto_luego_de_nc_aux = (decimal)dtFacturaDet.Rows[0][FacturasClienteDetalleService.TotalNetoLuegoDeNCAux_NombreCol];
                decimal cantidad_anterior_aux = (decimal)dtFacturaDet.Rows[0][FacturasClienteDetalleService.CantidadAnteriorAux_NombreCol];
                if (total_neto_luego_de_nc != 0)
                {// aun existe algo que se puede devolver, por lo tanto el monto unitario depende de este valor
                    PrecioUnitario = total_neto_luego_de_nc / (CantidadTotal - CantidadDevuelta);
                }
                else
                {//si es cero, o estamos eliminando el detalle de la nc o estamos tratanto de agregar un detalle no valido
                    PrecioUnitario = total_neto_luego_de_nc_aux / cantidad_anterior_aux;
                }

                decimal montBruto = PrecioUnitario * cantidad_devuelta;
                decimal monto = montBruto * (1M - porcentaje);
                /*
                if (politicaNotaCredito != Definiciones.PoliticasNotasCredito.Especifica)
                    return monto;

                switch (int.Parse(dtNotaCredito.Rows[0][NotasCreditoPersonaService.TipoNotaCreditoId_NombreCol].ToString()))
                {
                    case (Definiciones.TiposNotasCredito.DesperfectoMercaderia):
                        monto = CuentaCorrientePersonasService.GetSaldoCasoEnMoneda((decimal)dtFactura.Rows[0][FacturasClienteService.CasoId_NombreCol], (decimal)dtNotaCredito.Rows[0][NotasCreditoPersonaService.MonedaId_NombreCol]);
                        break;
                    case (Definiciones.TiposNotasCredito.CambioTitular):
                        monto = CuentaCorrientePersonasService.GetSaldoCasoEnMoneda((decimal)dtFactura.Rows[0][FacturasClienteService.CasoId_NombreCol], (decimal)dtNotaCredito.Rows[0][NotasCreditoPersonaService.MonedaId_NombreCol]);
                        break;
                    default:
                        break;
                }
                */
                return monto;
            }
        }
        #endregion GetMontoDevuelto

        #region GetMontoReingreso
        /// <summary>
        /// Gets the monto reingreso.
        /// </summary>
        /// <param name="nota_credito_id">The nota_credito_id.</param>
        /// <param name="factura_cliente_detalle_id">The factura_cliente_detalle_id.</param>
        /// <param name="cantidad_devuelta">The cantidad_devuelta.</param>
        /// <param name="tasacion_activo">if set to <c>true</c> [tasacion_activo].</param>
        /// <returns></returns>
        public static decimal GetMontoReingreso(decimal nota_credito_id, decimal factura_cliente_detalle_id, decimal cantidad_devuelta)
        {
            using (SessionService sesion = new SessionService())
            {
                if (cantidad_devuelta <= 0) return 0;

                DataTable dtFacturaDet = FacturasClienteDetalleService.GetFacturaClienteDetalleDataTable(FacturasClienteDetalleService.Id_NombreCol + " = " + factura_cliente_detalle_id, string.Empty);
                DataTable dtFactura = FacturasClienteService.GetFacturaClienteDataTable(FacturasClienteService.Id_NombreCol + " = " + dtFacturaDet.Rows[0][FacturasClienteDetalleService.FacturaClienteId_NombreCol], string.Empty);
                DataTable dtNotaCredito = NotasCreditoPersonaService.GetNotaCreditoPersonaDataTable(NotasCreditoPersonaService.Id_NombreCol + " = " + nota_credito_id, string.Empty);

                decimal monto = (decimal)dtFacturaDet.Rows[0][FacturasClienteDetalleService.TotalNeto_NombreCol] / (decimal)dtFacturaDet.Rows[0][FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol];
                decimal politicaNotaCredito = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PoliticaNotaCredito);

                decimal tipoNotaCredito = Definiciones.Error.Valor.EnteroPositivo;
                if (!Interprete.EsNullODBNull(dtNotaCredito.Rows[0][NotasCreditoPersonaService.TipoNotaCreditoId_NombreCol]))
                    tipoNotaCredito = (decimal)dtNotaCredito.Rows[0][NotasCreditoPersonaService.TipoNotaCreditoId_NombreCol];

                if (politicaNotaCredito != Definiciones.PoliticasNotasCredito.Especifica)
                    return monto;

                monto = NotasCreditoPersonaService.GetMontoDevuelto(nota_credito_id, factura_cliente_detalle_id, cantidad_devuelta);
                if (tipoNotaCredito == Definiciones.TiposNotasCredito.RecuperoMercaderia)
                    monto = (1M - 0.15M) * NotasCreditoPersonaService.GetMontoDevuelto(nota_credito_id, factura_cliente_detalle_id, cantidad_devuelta);

                return monto;
            }
        }
        #endregion GetMontoReingreso

        #region GetMonedaId
        public static decimal GetMonedaId(decimal notaCreditoId)
        {
            using (SessionService sesion = new SessionService())
            {
                NOTAS_CREDITO_PERSONASRow row = new NOTAS_CREDITO_PERSONASRow();
                                
                row = sesion.Db.NOTAS_CREDITO_PERSONASCollection.GetRow(Id_NombreCol + " = " + notaCreditoId);

                return row.MONEDA_ID;
            }
        }
        #endregion GetMonedaId
        #endregion Getters
            
        #region Setters
        #region SetCajaSucursal
        /// <summary>
        /// Sets the ctacte_caja_sucursal_id.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="ctacte_caja_sucursal_id">The ctacte_caja_sucursal_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void SetCajaSucursal(decimal caso_id, decimal ctacte_caja_sucursal_id, SessionService sesion)
        {
            NOTAS_CREDITO_PERSONASRow row = new NOTAS_CREDITO_PERSONASRow();

            try
            {
                row = sesion.Db.NOTAS_CREDITO_PERSONASCollection.GetRow(CasoId_NombreCol + " = " + caso_id);
                string valorAnteriorFactura = row.ToString();
                row.CTACTE_CAJA_SUCURSAL_ID = ctacte_caja_sucursal_id;
                sesion.db.NOTAS_CREDITO_PERSONASCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnteriorFactura, row.ToString(), sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion SetCajaSucursal

        #endregion Setters

        #region DisminuirSaldoDisponible
        /// <summary>
        /// Disminuirs the saldo disponible.
        /// </summary>
        /// <param name="nota_credito_persona_id">The nota_credito_persona_id.</param>
        /// <param name="total_afectado">The total_afectado.</param>
        /// <param name="llamada_desde_cambio_estado_otro_flujo">if set to <c>true</c> [llamada_desde_cambio_estado_otro_flujo].</param>
        /// <param name="sesion">The sesion.</param>
        public static void DisminuirSaldoDisponible(decimal nota_credito_persona_id, decimal total_afectado, bool llamada_desde_cambio_estado_otro_flujo, SessionService sesion)
        {
            NOTAS_CREDITO_PERSONASRow row = sesion.Db.NOTAS_CREDITO_PERSONASCollection.GetByPrimaryKey(nota_credito_persona_id);
            string valorAnterior = row.SALDO_POR_APLICAR.ToString();
            bool exito = false;
            string mensaje;

            int cantidadDecimales = MonedasService.CantidadDecimalesStatic(row.MONEDA_ID);
            if (decimal.Round(row.SALDO_POR_APLICAR, cantidadDecimales) < decimal.Round(total_afectado, cantidadDecimales))
                throw new Exception("La NC no cuenta con suficiente saldo para ser aplicado.");

            row.SALDO_POR_APLICAR -= total_afectado;

            sesion.Db.NOTAS_CREDITO_PERSONASCollection.Update(row);
            LogCambiosService.LogDeColumna(Nombre_Tabla, NotasCreditoPersonaService.SaldoPorAplicar_NombreCol, row.ID, valorAnterior, row.SALDO_POR_APLICAR.ToString(), sesion);

            //Las llamladas desde el cambio de estado de un flujo no deben afecatar al estado del anticipo
            //Las acciones posteriores al cambio de estado realizaran las acciones qeu se encuentran en este bloque IF
            if (!llamada_desde_cambio_estado_otro_flujo)
            {//Si el saldo por aplicar llega a cero, el caso debe
                //ser pasado a cerrado
                if (decimal.Round(row.SALDO_POR_APLICAR, cantidadDecimales) <= 0)
                {
                    //Para evitar un deadlock
                    //sesion.CommitTransaction();

                    exito = new NotasCreditoPersonaService().ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Cerrado, "El saldo de la NC llegó a cero.", sesion);
                    if (exito)
                        new NotasCreditoPersonaService().EjecutarAccionesLuegoDeCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);

                    if (!exito)
                        throw new Exception("Error en NotasCreditoPersonas.DisminuirSaldoDisponible. El saldo fue agotado pero el caso no pudo ser pasado a cerrado. " + mensaje + ".");
                }
            }
        }
        #endregion DisminuirSaldoDisponible

        #region AumentarSaldoDisponible
        public static void AumentarSaldoDisponible(decimal nota_credito_persona_id, decimal total_afectado, SessionService sesion)
        {
            NOTAS_CREDITO_PERSONASRow row = sesion.Db.NOTAS_CREDITO_PERSONASCollection.GetByPrimaryKey(nota_credito_persona_id);
            decimal saldoAnterior = row.SALDO_POR_APLICAR;
            string valorAnterior = row.SALDO_POR_APLICAR.ToString();
            bool exito = false;
            string mensaje;

            if (row.MONTO_TOTAL < row.SALDO_POR_APLICAR + total_afectado)
                throw new Exception("El saldo no puede ser mayor al monto inicial de la nota de crédito.");

            row.SALDO_POR_APLICAR += total_afectado;

            sesion.Db.NOTAS_CREDITO_PERSONASCollection.Update(row);
            LogCambiosService.LogDeColumna(Nombre_Tabla, NotasCreditoPersonaService.SaldoPorAplicar_NombreCol, row.ID, valorAnterior, row.SALDO_POR_APLICAR.ToString(), sesion);

            //Si el caso estaba cerrado y ahora tiene saldo, debe regresar a aprobado
            if (saldoAnterior == 0 && row.SALDO_POR_APLICAR > 0)
            {
                exito = new NotasCreditoPersonaService().ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                if (exito)
                    exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Aprobado, "El anticipo tiene saldo por aplicar.", sesion);
                if (exito)
                    new NotasCreditoPersonaService().EjecutarAccionesLuegoDeCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Aprobado, sesion);
                if (!exito)
                    throw new Exception("Error en NotasCreditoPersonaService.AumentarSaldoDisponible. El saldo fue aumentado pero el caso no pudo ser pasado a aprobado. " + mensaje + ".");
            }
        }
        #endregion AumentarSaldoDisponible

        #region VerificarPuedeAvanzarEstado
        public static bool VerificarPuedeAvanzarEstado(decimal caso_id, out string mensaje, SessionService sesion)
        {
            return FlujosService.VerificarPuedeAvanzarEstado(caso_id, out mensaje, "NOTAS CREDITO PERSONA NO CONTROLAR MARGEN DIAS PUEDE AVANZAR", Definiciones.VariablesDeSistema.NCPersonasMargenDiasPuedeAvanzar, sesion);
        }
        #endregion VerificarPuedeAvanzarEstado

        #region RecalcularTotal
        /// <summary>
        /// Recalculars the total.
        /// </summary>
        /// <param name="nota_credito_persona_id">The nota_credito_persona_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void RecalcularTotal(decimal nota_credito_persona_id, SessionService sesion)
        {
            NOTAS_CREDITO_PERSONASRow row = sesion.Db.NOTAS_CREDITO_PERSONASCollection.GetByPrimaryKey(nota_credito_persona_id);
            NOTAS_CREDITO_PERSONAS_DETRow[] detalleRows = sesion.Db.NOTAS_CREDITO_PERSONAS_DETCollection.GetByNOTA_CREDITO_PERSONA_ID(nota_credito_persona_id);
            decimal total = 0;
            decimal impuesto = 0;
            string valorAnterior;

            valorAnterior = row.MONTO_TOTAL.ToString();

            for (int i = 0; i < detalleRows.Length; i++)
            {
                total += detalleRows[i].TOTAL;
                impuesto += detalleRows[i].IMPUESTO_MONTO;
            }

            row.MONTO_TOTAL = total;
            row.SALDO_POR_APLICAR = total;
            row.TOTAL_IMPUESTO = impuesto;

            sesion.Db.NOTAS_CREDITO_PERSONASCollection.Update(row);
            LogCambiosService.LogDeColumna(Nombre_Tabla, NotasCreditoPersonaService.MontoTotal_NombreCol, row.ID, valorAnterior, row.MONTO_TOTAL.ToString(), sesion);
        }
        #endregion RecalcularTotal

        #region ObtenerPagosAsociados
        public static DataTable ObtenerPagosAsociados(decimal notaCreditoId)
        {
            using (SessionService sesion = new SessionService())
            {
                String sql = "";

                sql = "select cpp." + PagosDePersonaService.CasoId_NombreCol + " , cppd."
                    + CuentaCorrientePagosPersonaDetalleService.Monto_NombreCol + " " + "\n"
                + "  from " + CuentaCorrientePagosPersonaDetalleService.Nombre_Tabla + " cppd " + "\n"
                + "  join " + PagosDePersonaService.Nombre_Tabla + " cpp on cppd."
                + CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol + " = cpp." + PagosDePersonaService.Id_NombreCol
                + "   where cppd." + CuentaCorrientePagosPersonaDetalleService.NotaCreditoId_NombreCol + " = " + notaCreditoId
                + "     and cppd." + CuentaCorrientePagosPersonaDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";


                return sesion.db.EjecutarQuery(sql); ;
            }
        }
        #endregion ObtenerPagosAsociados

        #region ObtenerAplicacíonNotaCreditosAsociados
        public static DataTable ObtenerAplicacíonNotaCreditosAsociados(decimal notaCreditoCasoId)
        {
            using (SessionService sesion = new SessionService())
            {
                String sql = "";

                sql = " select distinct nca." + NotasCreditoPersonaAplicacionesService.CasoId_NombreCol + ", " +
                       "cp." + CuentaCorrientePersonasService.CasoId_NombreCol + ", " +
                       "ncav." + NotasCreditoPersonaAplicacionValoresService.MontoOrigen_NombreCol +
                       " from " + NotasCreditoPersonaAplicacionesService.Nombre_Vista + " nca" +
                       " join " + NotasCreditoPersonaAplicacionDocumentosService.Nombre_Tabla +
                       " ncad on nca." + NotasCreditoPersonaAplicacionesService.Id_NombreCol +
                       " = ncad." + NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocumentoId_NombreCol +
                       " join " + CuentaCorrientePersonasService.Nombre_Tabla + " cp on ncad."
                       + NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol + " = cp." +
                       CuentaCorrientePersonasService.Id_NombreCol +
                       " join " + NotasCreditoPersonaAplicacionValoresService.Nombre_Vista +
                       " ncav on nca." + NotasCreditoPersonaAplicacionesService.Id_NombreCol +
                       " = ncav." + NotasCreditoPersonaAplicacionValoresService.AplicacionDocumentoId_NombreCol +
                       " where ncav." + NotasCreditoPersonaAplicacionValoresService.VistaNumeroCasoId_NombreCol + " = " + notaCreditoCasoId +
                       "   and nca." + NotasCreditoPersonaAplicacionesService.VistaCasoEstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Aprobado + "' ";


                return sesion.db.EjecutarQuery(sql); ;
            }
        }
        #endregion ObtenerAplicacíonNotaCreditosAsociados

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        [Obsolete("Utilizar metodos estaticos")]
        public bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            return Guardar2(campos, insertarNuevo, ref caso_id, ref estado_id);
        }

        public static bool Guardar2(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id, SessionService sesion)
        {
            bool exito = false;
            NOTAS_CREDITO_PERSONASRow row = new NOTAS_CREDITO_PERSONASRow();

            try
            {
                SucursalesService sucursal = new SucursalesService();
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[NotasCreditoPersonaService.SucursalId_NombreCol].ToString()),
                                                          int.Parse(Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA.ToString()),
                                                          int.Parse(sesion.Usuario_Id.ToString()),
                                                          SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                    row.ID = sesion.Db.GetSiguienteSecuencia("notas_credito_personas_sqc");
                    row.FECHA = DateTime.Now;
                    row.MONTO_TOTAL = 0;
                    row.SALDO_POR_APLICAR = 0;
                    row.IMPRESO = Definiciones.SiNo.No;

                    caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                    estado_id = Definiciones.EstadosFlujos.Borrador;
                }
                else
                {
                    row = sesion.Db.NOTAS_CREDITO_PERSONASCollection.GetByPrimaryKey((decimal)campos[NotasCreditoPersonaService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                if (row.SUCURSAL_ID != (decimal)campos[NotasCreditoPersonaService.SucursalId_NombreCol])
                {
                    if (SucursalesService.EstaActivo((decimal)campos[NotasCreditoPersonaService.SucursalId_NombreCol]))
                    {
                        row.SUCURSAL_ID = (decimal)campos[NotasCreditoPersonaService.SucursalId_NombreCol];
                        CasosService.ActualizarSucursal(row.CASO_ID, row.SUCURSAL_ID, sesion);
                    }
                    else
                        throw new System.Exception("La sede se encuentra inactiva.");
                }
                if (campos.Contains(NotasCreditoPersonaService.DepositoId_NombreCol))
                {
                    row.DEPOSITO_ID = (decimal)campos[NotasCreditoPersonaService.DepositoId_NombreCol];
                    if (StockDepositosService.GetStockDeposito(row.DEPOSITO_ID).PARA_FACTURAR == Definiciones.SiNo.No)
                    {
                        throw new Exception("No se pude facturar del deposito seleccionado");
                    }
                }

                if (campos.Contains(NotasCreditoPersonaService.CtaCteCajaSucursalId_NombreCol))
                    row.CTACTE_CAJA_SUCURSAL_ID = (decimal)campos[NotasCreditoPersonaService.CtaCteCajaSucursalId_NombreCol];
                else
                    row.IsCTACTE_CAJA_SUCURSAL_IDNull = true;

                if (campos.Contains(NotasCreditoPersonaService.TipoNotaCreditoId_NombreCol))
                    row.TIPO_NOTA_CREDITO_ID = (decimal)campos[NotasCreditoPersonaService.TipoNotaCreditoId_NombreCol];

                if (row.PERSONA_ID != (decimal)campos[NotasCreditoPersonaService.PersonaId_NombreCol])
                {
                    if (PersonasService.EstaActivo((decimal)campos[NotasCreditoPersonaService.PersonaId_NombreCol]))
                        row.PERSONA_ID = (decimal)campos[NotasCreditoPersonaService.PersonaId_NombreCol];
                    else
                        throw new System.Exception("La persona se encuentra inactiva.");
                }
                
                if (campos.Contains(NotasCreditoPersonaService.NroComprobanteSecuencia_NombreCol))
                    row.NRO_COMPROBANTE_SECUENCIA = (decimal)campos[NotasCreditoPersonaService.NroComprobanteSecuencia_NombreCol];
                
                //Si cambia, se verifica que este activo
                if (campos.Contains(NotasCreditoPersonaService.AutonumeracionId_NombreCol))
                {
                    if (row.IsAUTONUMERACION_IDNull || !row.AUTONUMERACION_ID.Equals((decimal)campos[NotasCreditoPersonaService.AutonumeracionId_NombreCol]))
                    {
                        if (!AutonumeracionesService.EstaActivo((decimal)campos[NotasCreditoPersonaService.AutonumeracionId_NombreCol]))
                            throw new Exception("El talonario se encuentra inactivo");
                        row.AUTONUMERACION_ID = (decimal)campos[NotasCreditoPersonaService.AutonumeracionId_NombreCol];
                    }
                }
                else
                {
                    row.IsAUTONUMERACION_IDNull = true;
                }

                // Se verifica que el talonario y nro de comprobante no sea igual a alguna NC existente, exceptuando las no activas
                // Nro de Comprobantes vacios si se permiten repetidos
                if (row.IsAUTONUMERACION_IDNull || campos[NotasCreditoPersonaService.NroComprobante_NombreCol].ToString().Equals(string.Empty))
                {
                    row.NRO_COMPROBANTE = (string)campos[NotasCreditoPersonaService.NroComprobante_NombreCol];
                }
                else
                {
                    string clausulas = NotasCreditoPersonaService.AutonumeracionId_NombreCol + " = " + row.AUTONUMERACION_ID.ToString() + " and " +
                                       NotasCreditoPersonaService.NroComprobante_NombreCol + " = '" + campos[NotasCreditoPersonaService.NroComprobante_NombreCol].ToString() + "' and " +
                                       NotasCreditoPersonaService.VistaCasoEstado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                                       NotasCreditoPersonaService.CasoId_NombreCol + " <> " + row.CASO_ID;
                    DataTable dtNotasCredito = NotasCreditoPersonaService.GetNotaCreditoPersonaInfoCompleta2(clausulas, string.Empty);

                    if (dtNotasCredito.Rows.Count <= 0)
                        row.NRO_COMPROBANTE = (string)campos[NotasCreditoPersonaService.NroComprobante_NombreCol];                        
                    else
                        throw new Exception("Ya existe una nota de crédito con ese talonario y ese número de comprobante.");
                }

                row.FECHA = (DateTime)campos[NotasCreditoPersonaService.Fecha_NombreCol];

                if (!MonedasService.EstaActivo((decimal)campos[NotasCreditoPersonaService.MonedaId_NombreCol]))
                {
                    throw new System.Exception("La moneda se encuentra inactiva.");
                }
                else
                {
                    row.MONEDA_ID = (decimal)campos[NotasCreditoPersonaService.MonedaId_NombreCol];

                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, row.FECHA, sesion);

                    // Si no existe una cotización definida para la fecha, intentar con la fecha de creación del caso
                    if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    {
                        DateTime fecha = (DateTime)CasosService.GetCasoPorId(Convert.ToDecimal(caso_id), sesion).FECHA_CREACION;
                        row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, fecha, sesion);
                    }

                    if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda.");
                }

                if (!FuncionariosService.EstaActivo((decimal)campos[NotasCreditoPersonaService.FuncionarioCobradorId_NombreCol]))
                    throw new System.Exception("El funcionario se encuentra inactivo.");
                else
                    row.FUNCIONARIO_COBRADOR_ID = (decimal)campos[NotasCreditoPersonaService.FuncionarioCobradorId_NombreCol];

                row.OBSERVACION = (string)campos[NotasCreditoPersonaService.Observacion_NombreCol];


                if (insertarNuevo) sesion.Db.NOTAS_CREDITO_PERSONASCollection.Insert(row);
                else sesion.Db.NOTAS_CREDITO_PERSONASCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();
                camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.FUNCIONARIO_COBRADOR_ID);
                camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                if (!row.IsTIPO_NOTA_CREDITO_IDNull)
                    camposCaso.Add(CasosService.TipoEspecifico_NombreCol, row.TIPO_NOTA_CREDITO_ID);
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

        public static bool Guardar2(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return Guardar2(campos, insertarNuevo, ref caso_id, ref estado_id, sesion);
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
                    NOTAS_CREDITO_PERSONASRow cabecera = sesion.Db.NOTAS_CREDITO_PERSONASCollection.GetByCASO_ID(caso_id)[0];
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
                        //Borrar los detalles del caso
                        dtDetalles = NotasCreditoPersonaDetalleService.GetNotaCreditoPersonaDetalleDataTable(NotasCreditoPersonaDetalleService.NotaCreditoPersonaId_NombreCol + " = " + cabecera.ID, NotasCreditoPersonaDetalleService.Id_NombreCol, sesion);
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            NotasCreditoPersonaDetalleService.Borrar((decimal)dtDetalles.Rows[i][NotasCreditoPersonaDetalleService.Id_NombreCol]);
                        }

                        sesion.Db.NOTAS_CREDITO_PERSONASCollection.DeleteByCASO_ID(caso_id);
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
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "NOTAS_CREDITO_PERSONAS"; }
        }
        public static string Nombre_Vista
        {
            get { return "NOTAS_CREDITO_PERSONA_INF_COMP"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.CASO_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.DEPOSITO_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.FECHAColumnName; }
        }
        public static string FuncionarioCobradorId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.FUNCIONARIO_COBRADOR_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.IDColumnName; }
        }
        public static string Impreso_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.IMPRESOColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.MONEDA_IDColumnName; }
        }
        public static string MontoTotal_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.MONTO_TOTALColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string NroComprobanteSecuencia_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.NRO_COMPROBANTE_SECUENCIAColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.OBSERVACIONColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.PERSONA_IDColumnName; }
        }
        public static string SaldoPorAplicar_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.SALDO_POR_APLICARColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.SUCURSAL_IDColumnName; }
        }
        public static string TotalImpuesto_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.TOTAL_IMPUESTOColumnName; }
        }
        public static string TipoNotaCreditoId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.TIPO_NOTA_CREDITO_IDColumnName; }
        }
        public static string CtaCteCajaSucursalId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONASCollection.CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string VistaAutonumeracionTimbrado_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.AUTONUMERACION_TIMBRADOColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCasoEstado_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.CASO_ESTADOColumnName; }
        }
        public static string VistaCasoFechaCreacion_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.CASO_FECHA_CREACIONColumnName; }
        }
        public static string VistaCasoUltimoUsuarioNombre_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.CASO_ULTIMO_USUARIO_NOMBREColumnName; }
        }
        public static string VistaCasoUsuarioCreacionNombre_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.CASO_USUARIO_CREACION_NOMBREColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.MONEDA_CANTIDAD_DECIMALESColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaDepositoNombre_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaAutonumeracionCodigo_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.AUTONUMERACION_CODIGOColumnName; }
        }
        public static string VistaTipoNOmbre_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.TIPO_NC_NOMBREColumnName; }
        }
        public static string VistaTipoPrefijo_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.TIPO_NC_PREFIJOColumnName; }
        }
        public static string VistaMonedaCadenaDecimales_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.MONEDA_CADENA_DECIMALESColumnName; }
        }
        public static string VistaTipoClienteNombre_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONA_INF_COMPCollection.TIPO_CLIENTES_NOMBREColumnName; }
        }
        #endregion Vista
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static NotasCreditoPersonaService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new NotasCreditoPersonaService(e.RegistroId, sesion);
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
        protected NOTAS_CREDITO_PERSONASRow row;
        protected NOTAS_CREDITO_PERSONASRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? AutonumeracionId { get { if (row.IsAUTONUMERACION_IDNull) return null; else return row.AUTONUMERACION_ID; } set { if (value.HasValue) row.AUTONUMERACION_ID = value.Value; else row.IsAUTONUMERACION_IDNull = true; } }
        public decimal CasoId { get { return row.CASO_ID; } set { row.CASO_ID = value; } }
        public decimal CotizacionMoneda { get { return row.COTIZACION_MONEDA; } set { row.COTIZACION_MONEDA = value; } }
        public decimal? CtacteCajaSucursalId { get { if (row.IsCTACTE_CAJA_SUCURSAL_IDNull) return null; else return row.CTACTE_CAJA_SUCURSAL_ID; } set { if (value.HasValue) row.CTACTE_CAJA_SUCURSAL_ID = value.Value; else row.IsCTACTE_CAJA_SUCURSAL_IDNull = true; } }
        public decimal? DepositoId { get { if (row.IsDEPOSITO_IDNull) return null; else return row.DEPOSITO_ID; } set { if (value.HasValue) row.DEPOSITO_ID = value.Value; else row.IsDEPOSITO_IDNull = true; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public decimal FuncionarioCobradorId { get { return row.FUNCIONARIO_COBRADOR_ID; } set { row.FUNCIONARIO_COBRADOR_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Impreso { get { return ClaseCBABase.GetStringHelper(row.IMPRESO); } set { row.IMPRESO = value; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal MontoTotal { get { return row.MONTO_TOTAL; } set { row.MONTO_TOTAL = value; } }
        public string NroComprobante { get { return ClaseCBABase.GetStringHelper(row.NRO_COMPROBANTE); } set { row.NRO_COMPROBANTE = value; } }
        public decimal? NroComprobanteSecuencia { get { if (row.IsNRO_COMPROBANTE_SECUENCIANull) return null; else return row.NRO_COMPROBANTE_SECUENCIA; } set { if (value.HasValue) row.NRO_COMPROBANTE_SECUENCIA = value.Value; else row.IsNRO_COMPROBANTE_SECUENCIANull = true; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal PersonaId { get { return row.PERSONA_ID; } set { row.PERSONA_ID = value; } }
        public decimal Saldo { get { return row.SALDO_POR_APLICAR; } set { row.SALDO_POR_APLICAR = value; } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } set { row.SUCURSAL_ID = value; } }
        public decimal? TipoNotaCreditoId { get { if (row.IsTIPO_NOTA_CREDITO_IDNull) return null; else return row.TIPO_NOTA_CREDITO_ID; } set { if (value.HasValue) row.TIPO_NOTA_CREDITO_ID = value.Value; else row.IsTIPO_NOTA_CREDITO_IDNull = true; } }
        public decimal? TotalImpuesto { get { if (row.IsTOTAL_IMPUESTONull) return null; else return row.TOTAL_IMPUESTO; } set { if (value.HasValue) row.TOTAL_IMPUESTO = value.Value; else row.IsTOTAL_IMPUESTONull = true; } }
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
                this.row = sesion.db.NOTAS_CREDITO_PERSONASCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new NOTAS_CREDITO_PERSONASRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(NOTAS_CREDITO_PERSONASRow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public NotasCreditoPersonaService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public NotasCreditoPersonaService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public NotasCreditoPersonaService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        public NotasCreditoPersonaService(EdiCBA.NotaCreditoCliente edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = NotasCreditoPersonaService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            this.CasoId = edi.caso_id;

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

            this.Fecha = edi.fecha;
            
            if(edi.cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion'.");
            this.CotizacionMoneda = edi.cotizacion.compra;
            
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
            #endregion moneda destino
            
            #region funcionario cobrador
            if (!string.IsNullOrEmpty(edi.funcionario_uuid))
                this._funcionario_cobrador = FuncionariosService.GetPorUUID(edi.funcionario_uuid, sesion);
            if (this._funcionario_cobrador == null && edi.funcionario != null)
                this._funcionario_cobrador = new FuncionariosService(edi.funcionario, almacenar_localmente, sesion);
            if (this._funcionario_cobrador != null)
            {
                if (!this.FuncionarioCobrador.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.FuncionarioCobrador.Id.HasValue)
                    this.FuncionarioCobradorId = this.FuncionarioCobrador.Id.Value;
            }
            #endregion funcionario cobrador

            this.NroComprobante = edi.nro_comprobante;
            this.NroComprobanteSecuencia = edi.nro_comprobante_numerico;
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

            this.MontoTotal = edi.total_neto;
            this.TotalImpuesto = edi.total_impuesto;
            this.Saldo = edi.total_saldo;

            if(edi.tipo_descuento)
                this.TipoNotaCreditoId = Definiciones.TiposNotasCredito.Descuento;
            if (edi.tipo_devolucion)
                this.TipoNotaCreditoId = Definiciones.TiposNotasCredito.DevolucionMercaderia;
            if (!this.TipoNotaCreditoId.HasValue)
                this.TipoNotaCreditoId = Definiciones.TiposNotasCredito.EstandarCBA;

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
                this.Caso.FlujoId = Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA;
                this.Caso.NroComprobante2 = edi.nro_comprobante_externo;
            }
            #endregion caso
        }
        private NotasCreditoPersonaService(NOTAS_CREDITO_PERSONASRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCaso
        public static NotasCreditoPersonaService GetPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCaso(caso_id, sesion);
            }
        }

        public static NotasCreditoPersonaService GetPorCaso(decimal caso_id, SessionService sesion)
        {
            var row = sesion.db.NOTAS_CREDITO_PERSONASCollection.GetByCASO_ID(caso_id)[0];
            return new NotasCreditoPersonaService(row);
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

            var e = new EdiCBA.NotaCreditoCliente()
            {
                caso_id = this.CasoId,
                persona_uuid = this.Persona.GetOrCreateUUID(sesion),
                cotizacion_uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, NotasCreditoPersonaService.CotizacionMoneda_NombreCol, this.Id.Value, sesion),
                deposito_uuid = this.Deposito.GetOrCreateUUID(sesion),
                estado_id = this.Caso.EstadoId,
                fecha = this.Fecha,
                moneda_uuid = this.Moneda.GetOrCreateUUID(sesion),
                nro_comprobante = this.NroComprobante,
                nro_comprobante_numerico = this.NroComprobanteSecuencia,
                observacion = this.Observacion,
                sucursal_uuid = this.Sucursal.GetOrCreateUUID(sesion),
                total_neto = this.MontoTotal,
                total_impuesto = this.TotalImpuesto.HasValue ? this.TotalImpuesto.Value : 0,
                total_saldo = this.Saldo
            };

            var detalles = NotasCreditoPersonaDetalleService.GetPorCabecera(this.Id.Value, sesion);
            e.nota_credito_cliente_detalles_uuid = new string[detalles.Length];
            for (int i = 0; i < detalles.Length; i++)
                e.nota_credito_cliente_detalles_uuid[i] = detalles[i].GetOrCreateUUID(sesion);

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.persona = (EdiCBA.Persona)this.Persona.ToEDI(nueva_profundidad, sesion);
                e.cotizacion = new EdiCBA.Cotizacion()
                {
                    uuid = e.cotizacion_uuid,
                    fecha = this.Fecha,
                    moneda_uuid = e.moneda_uuid,
                    compra = this.CotizacionMoneda
                };
                e.deposito = (EdiCBA.Deposito)this.Deposito.ToEDI(nueva_profundidad, sesion);
                e.funcionario = (EdiCBA.Funcionario)this.FuncionarioCobrador.ToEDI(nueva_profundidad, sesion);
                e.moneda = (EdiCBA.Moneda)this.Moneda.ToEDI(nueva_profundidad, sesion);
                e.sucursal = (EdiCBA.Sucursal)this.Sucursal.ToEDI(nueva_profundidad, sesion);

                e.nota_credito_cliente_detalles = new EdiCBA.NotaCreditoClienteDetalle[detalles.Length];
               
            }

            if (this.TipoNotaCreditoId == Definiciones.TiposNotasCredito.Descuento)
                e.tipo_descuento = true;
            e.tipo_devolucion = !e.tipo_descuento;

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
