using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.NotaCreditosProveedores;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotasDebitoProveedor;
using System.Collections.Generic;
using CBA.FlowV2.Services.Common;
using System.Globalization;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.ToolbarFlujo;

namespace CBA.FlowV2.Services.EgresosVariosCaja
{
    public class EgresosVariosCajaService : FlujosServiceBaseWorkaround
    {
        #region Sub clase propiedades cabecera
        [Serializable]
        public class PropiedadesCabecera
        {
            //decimal
            public decimal CtaCteFondoFijoId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal CtaCteCajaSucursalId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal SucursalId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal AutonumeracionId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal MonedaId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal CotizacionMoneda = Definiciones.Error.Valor.EnteroPositivo;
            public decimal MontoTotal = Definiciones.Error.Valor.EnteroPositivo;
            public decimal RetencionAutonumeracionId = Definiciones.Error.Valor.EnteroPositivo;

            //string/fechas
            public string Fecha_yyyymmdd = DateTime.MinValue.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            public string FechaReciboBeneficiario_yyyymmdd = DateTime.MinValue.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            //string 
            public string NroComprobante = string.Empty;
            public string NombreBeneficiario = string.Empty;
            public string NroReciboBeneficiario = string.Empty;
            public string Observacion = string.Empty;
            public string RetencionUnificada = string.Empty;

            //bool
            public bool GastoDirectivo = false;
        }
        #endregion Sub clase propiedades cabecera

        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.EGRESO_VARIO_CAJA;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var drCabecera = (DataRow)caso_cabecera;
            var drDetalle = (DataRow)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);

            if (drDetalle != null)
            {
                if (drDetalle.Table.Columns.Contains(EgresosVariosCajaDetalleService.PersonaId_NombreCol) && !Interprete.EsNullODBNull(drDetalle[EgresosVariosCajaDetalleService.PersonaId_NombreCol]))
                    campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, drDetalle[EgresosVariosCajaDetalleService.PersonaId_NombreCol]);
                else
                    campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);

                if (drDetalle.Table.Columns.Contains(EgresosVariosCajaDetalleService.ProveedorId_NombreCol) && !Interprete.EsNullODBNull(drDetalle[EgresosVariosCajaDetalleService.ProveedorId_NombreCol]))
                    campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, drDetalle[EgresosVariosCajaDetalleService.ProveedorId_NombreCol]);
                else
                    campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);
            }

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

            mensaje = string.Empty;
            try
            {
                CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                EGRESOS_VARIOS_CAJARow cabeceraRow = sesion.Db.EGRESOS_VARIOS_CAJACollection.GetByCASO_ID(caso_id)[0];
                EGRESOS_VARIOS_CAJA_DETRow[] detalleRows = sesion.Db.EGRESOS_VARIOS_CAJA_DETCollection.GetByEGRESO_VARIO_CAJA_ID(cabeceraRow.ID);
                EGRESOS_VARIOS_CAJA_VALRow[] valorRows = sesion.Db.EGRESOS_VARIOS_CAJA_VALCollection.GetAsArray(EgresosVariosCajaValoresService.EgresoVarioCajaId_NombreCol + " = " + cabeceraRow.ID + " and " + EgresosVariosCajaValoresService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'", string.Empty);

                //Borrador a Pendiente
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Asignar la numeracion si aun no había sido generada.

                    exito = true;
                    revisarRequisitos = true;

                    //Asignar numeracion
                    if (exito && (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Length <= 0))
                    {
                        try
                        {
                            if (AutonumeracionesService.EsGeneracionManual(cabeceraRow.AUTONUMERACION_ID))
                            {
                                throw new Exception("Debe indicar el número de comprobante que es de numeración manual.");
                            }
                            else
                            {
                                cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID);

                                //Controlar que se logro asignar una numeracion
                                if (cabeceraRow.NRO_COMPROBANTE.Equals(""))
                                {
                                    exito = false;
                                    mensaje = "No se pudo asignar una numeración válida";
                                }
                            }
                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                            throw exp;
                        }
                    }
                }
                //Borrador a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //ninguna.
                    exito = true;
                    revisarRequisitos = true;
                }
                //Pendiente a Borrador 
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //ninguna.
                    exito = true;
                }
                //Pendiente a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //ninguna.
                    exito = true;
                    revisarRequisitos = true;
                }
                //Pendiente a Aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones:
                    //Validar que el monto de documentos es mayor o igual a los valores
                    //Completar el saldo por pagar con efectivo
                    //Confirmar que existe saldo suficiente y emitir los valores.
                    //Actualizar la cuenta corriente de proveedor y persona.

                    exito = true;
                    revisarRequisitos = true;

                    CuentaCorrienteFondosFijosMovimientosService ctacteFondoFijoMov = new CuentaCorrienteFondosFijosMovimientosService();
                    decimal deudaMovimiento;
                    Hashtable campos;

                    //Validar que el monto de documentos es mayor o igual a los valores
                    decimal totalDocumentos = 0;
                    decimal totalValores = 0;
                    int cantidadDecimales = MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID, sesion);

                    for (int i = 0; i < detalleRows.Length; i++)
                        totalDocumentos += Math.Round(detalleRows[i].MONTO_DESTINO, cantidadDecimales);

                    for (int i = 0; i < valorRows.Length; i++)
                        totalValores += Math.Round(valorRows[i].MONTO_DESTINO, cantidadDecimales);

                    decimal diferenciaValores = Math.Round(totalDocumentos, cantidadDecimales) - Math.Round(totalValores, cantidadDecimales);

                    if (diferenciaValores < 0)
                        throw new Exception("El monto de valores no puede ser mayor al monto de documentos.");

                    //Agregar efectivo por el saldo a completar
                    if (totalValores < totalDocumentos)
                    {
                        campos = new Hashtable();
                        campos.Add(EgresosVariosCajaValoresService.EgresoVarioCajaId_NombreCol, cabeceraRow.ID);
                        campos.Add(EgresosVariosCajaValoresService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo);
                        campos.Add(EgresosVariosCajaValoresService.MonedaOrigenId_NombreCol, cabeceraRow.MONEDA_ID);
                        campos.Add(EgresosVariosCajaValoresService.MontoOrigen_NombreCol, diferenciaValores);
                        campos.Add(EgresosVariosCajaValoresService.CotizacionMonedaDestino_NombreCol, cabeceraRow.COTIZACION_MONEDA);
                        campos.Add(EgresosVariosCajaValoresService.Observacion_NombreCol, string.Empty);

                        //Guardar los datos
                        EgresosVariosCajaValoresService.Guardar(campos, sesion);
                    }

                    decimal totalEfectivo = EgresosVariosCajaValoresService.GetTotal(cabeceraRow.ID, Definiciones.CuentaCorrienteValores.Efectivo, sesion);

                    if (!cabeceraRow.IsCTACTE_FONDO_FIJO_IDNull)
                    {
                        DataTable dtCtacteFondoFijo = CuentaCorrienteFondosFijosService.GetCuentaCorrienteFondosFijosDataTable(CuentaCorrienteFondosFijosService.Id_NombreCol + " = " + cabeceraRow.CTACTE_FONDO_FIJO_ID, string.Empty);

                        //Confirmar que existe saldo suficiente
                        if (Math.Round(totalEfectivo, cantidadDecimales) > Math.Round((decimal)dtCtacteFondoFijo.Rows[0][CuentaCorrienteFondosFijosService.MontoActual_NombreCol] + (decimal)dtCtacteFondoFijo.Rows[0][CuentaCorrienteFondosFijosService.MontoSobregiro_NombreCol], cantidadDecimales))
                        {
                            exito = false;
                            mensaje = "No existe saldo suficiente. El fondo fijo tiene una disponibilidad de " + Math.Round((decimal)dtCtacteFondoFijo.Rows[0][CuentaCorrienteFondosFijosService.MontoActual_NombreCol] + (decimal)dtCtacteFondoFijo.Rows[0][CuentaCorrienteFondosFijosService.MontoSobregiro_NombreCol], cantidadDecimales) +
                                      " y el egreso requiere " + Math.Round(totalEfectivo, cantidadDecimales) + ".";
                        }
                    }

                    if (!cabeceraRow.IsCTACTE_CAJA_SUCURSAL_IDNull)
                    {
                        var totalEfectivoCaja = CuentaCorrienteCajasSucursalService.GetSumaEfectivo(cabeceraRow.CTACTE_CAJA_SUCURSAL_ID, cabeceraRow.MONEDA_ID, sesion);

                        //Confirmar que existe saldo suficiente
                        if (Math.Round(totalEfectivo, cantidadDecimales) > Math.Round(totalEfectivoCaja, cantidadDecimales))
                        {
                            exito = false;
                            mensaje = "No existe saldo suficiente. La caja tiene una disponibilidad de " + Math.Round(totalEfectivoCaja, cantidadDecimales) +
                                      " y el egreso requiere " + Math.Round(totalEfectivo, cantidadDecimales) + ".";
                        }
                    }

                    if (exito)
                    {
                        DataTable dtValores = EgresosVariosCajaValoresService.GetDataTable(EgresosVariosCajaValoresService.EgresoVarioCajaId_NombreCol + " = " + cabeceraRow.ID, string.Empty, sesion);

                        for (int i = 0; i < dtValores.Rows.Count; i++)
                        {
                            int ctacteValorId = int.Parse(dtValores.Rows[i][EgresosVariosCajaValoresService.CtacteValorId_NombreCol].ToString());
                            switch (ctacteValorId)
                            {
                                case Definiciones.CuentaCorrienteValores.Efectivo:
                                    if (!cabeceraRow.IsCTACTE_FONDO_FIJO_IDNull)
                                    {
                                        //Actualizar el saldo del fondo fijo
                                        ctacteFondoFijoMov.Egreso(cabeceraRow.CTACTE_FONDO_FIJO_ID, Definiciones.Error.Valor.EnteroPositivo,
                                                                  Definiciones.FlujosIDs.EGRESO_VARIO_CAJA,
                                                                  cabeceraRow.ID,
                                                                  (decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.MontoDestino_NombreCol],
                                                                  (decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.CotizacionMonedaDestino_NombreCol],
                                                                  "Egreso por Egreso Vario de Caja " + cabeceraRow.CASO_ID + " pasado al estado " + estado_destino + ".",
                                                                  cabeceraRow.FECHA,
                                                                  sesion);
                                    }
                                    else if (!cabeceraRow.IsCTACTE_CAJA_SUCURSAL_IDNull)
                                    {
                                        //Egresar efectivo de la caja
                                        DataTable dtCtacteCajaSucusral = new CuentaCorrienteCajasSucursalService().GetCuentaCorrienteCajasSucursalDataTable(CuentaCorrienteCajasSucursalService.Id_NombreCol + " = " + cabeceraRow.CTACTE_CAJA_SUCURSAL_ID, string.Empty);
                                        campos = new System.Collections.Hashtable()
                                        {
                                            { CuentaCorrienteCajaService.Fecha_NombreCol, cabeceraRow.FECHA },
                                            { CuentaCorrienteCajaService.MonedaId_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.MonedaOrigenId_NombreCol] },
                                            { CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.CotizacionMonedaDestino_NombreCol] },
                                            { CuentaCorrienteCajaService.Monto_NombreCol, -(decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.MontoOrigen_NombreCol] },
                                            { CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo },
                                            { CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID },
                                            { CuentaCorrienteCajaService.SucursalId_NombreCol, dtCtacteCajaSucusral.Rows[0][CuentaCorrienteCajasSucursalService.SucursalId_NombreCol] },
                                            { CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, dtCtacteCajaSucusral.Rows[0][CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol] },
                                            { CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.DebitoPorFlujo },
                                            { CuentaCorrienteCajaService.EgresoVarioId_NombreCol, cabeceraRow.ID },
                                            { CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, cabeceraRow.CTACTE_CAJA_SUCURSAL_ID }
                                        };
                                        CuentaCorrienteCajaService.Guardar(campos, sesion);
                                    }
                                    break;
                                case Definiciones.CuentaCorrienteValores.Cheque:
                                    #region Cheque girado
                                    EGRESOS_VARIOS_CAJA_VALRow egresoVarioCajaValorRow;
                                    campos = new Hashtable();
                                    decimal autonumeracion_id = Definiciones.Error.Valor.EnteroPositivo;
                                    string nroCheque;

                                    campos.Add(CuentaCorrienteChequesGiradosService.CasoCreadorId_NombreCol, cabeceraRow.CASO_ID);
                                    campos.Add(CuentaCorrienteChequesGiradosService.CotizacionMoneda_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.CotizacionMonedaOrigen_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesGiradosService.CtaCteBancariaId_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.CGCtacteBancariaId_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesGiradosService.EsDiferido_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.CGEsDiferido_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesGiradosService.FechaPosdatado_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.CGFechaEmision_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesGiradosService.FechaVencimiento_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.CGFechaVencimiento_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesGiradosService.MonedaId_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.MonedaOrigenId_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesGiradosService.Monto_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.MontoOrigen_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.CGNombreBeneficiario_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesGiradosService.NumeroCtaBeneficiario_NombreCol, string.Empty);
                                    campos.Add(CuentaCorrienteChequesGiradosService.NombreEmisor_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.CGNombreEmisor_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesGiradosService.Observacion_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.Observacion_NombreCol]);
                                    if (!Interprete.EsNullODBNull(dtValores.Rows[i][EgresosVariosCajaValoresService.CGAutonumeracionId_NombreCol]))
                                    {
                                        campos.Add(CuentaCorrienteChequesGiradosService.AutonumeracionId_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.CGAutonumeracionId_NombreCol]);
                                        autonumeracion_id = (decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.CGAutonumeracionId_NombreCol];
                                    }

                                    if (!Interprete.EsNullODBNull(dtValores.Rows[i][EgresosVariosCajaValoresService.CGNumeroCheque_NombreCol]))
                                        campos.Add(CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.CGNumeroCheque_NombreCol]);

                                    //Se obtiene el registro para posterior update
                                    egresoVarioCajaValorRow = sesion.Db.EGRESOS_VARIOS_CAJA_VALCollection.GetByPrimaryKey((decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.Id_NombreCol]);

                                    //Se crea el cheque girado
                                    egresoVarioCajaValorRow.CG_CTACTE_CHEQUE_GIRADO_ID = CuentaCorrienteChequesGiradosService.Emitir(campos, autonumeracion_id, out nroCheque, sesion);
                                    egresoVarioCajaValorRow.CG_NUMERO_CHEQUE = nroCheque;

                                    //Se actualiza en la base de datos el id del cheque girado
                                    sesion.Db.EGRESOS_VARIOS_CAJA_VALCollection.Update(egresoVarioCajaValorRow);

                                    //Se afecta la cuenta bancaria si el cheque no es adelantado
                                    if (egresoVarioCajaValorRow.CG_FECHA_VENCIMIENTO.Date <= DateTime.Now.Date)
                                    {
                                        CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                              egresoVarioCajaValorRow.CG_CTACTE_BANCARIA_ID,
                                              Definiciones.FlujosIDs.EGRESO_VARIO_CAJA,
                                              cabeceraRow.CASO_ID,
                                              Definiciones.Error.Valor.EnteroPositivo,
                                              cabeceraRow.ID,
                                              egresoVarioCajaValorRow.MONEDA_ORIGEN_ID,
                                              egresoVarioCajaValorRow.MONTO_ORIGEN * (-1),
                                              egresoVarioCajaValorRow.COTIZACION_MONEDA_ORIGEN,
                                              cabeceraRow.FECHA,
                                              "Caso " + cabeceraRow.CASO_ID + " de " + FlujosService.GetDescripcionImpresion(Definiciones.FlujosIDs.EGRESO_VARIO_CAJA) + " (" + egresoVarioCajaValorRow.CG_NOMBRE_BENEFICIARIO + ") pasado al estado " + estado_destino + ". Cheque " + egresoVarioCajaValorRow.CG_NUMERO_CHEQUE + " fecha " + egresoVarioCajaValorRow.CG_FECHA_EMISION.Date + ".",
                                              egresoVarioCajaValorRow.CG_CTACTE_CHEQUE_GIRADO_ID,
                                              null,
                                              false,
                                              sesion);
                                    }
                                    #endregion Cheque girado
                                    break;
                                case Definiciones.CuentaCorrienteValores.RetencionIVA:
                                    #region Retencion
                                    FacturasProveedorService facturaProveedor = new FacturasProveedorService();
                                    ORDENES_PAGO_VALORESRow ordenPagoValorEditado;
                                    CuentaCorrienteRetencionesEmitidasService retencionEmitida = new CuentaCorrienteRetencionesEmitidasService();
                                    CuentaCorrienteRetencionesEmitidasDetalleService retencionEmitidaDet = new CuentaCorrienteRetencionesEmitidasDetalleService();
                                    decimal retencion_detalle_id;
                                    string[] strAuxFacturas, strAuxMontos;

                                    // Se verifica que exista una autonumeracion para las retenciones a emitir en la cabecera de la OP
                                    if (cabeceraRow.IsRETENCION_AUTONUMERACION_IDNull)
                                        throw new Exception("Debe definir una autonumeración para las retenciones a emitir en la cabecera del Egreso Vario.");

                                    //Se desglosan los detalles de retencion que se crearan
                                    strAuxFacturas = dtValores.Rows[i][EgresosVariosCajaValoresService.RetencionAuxCasos_NombreCol].ToString().Split('@');
                                    strAuxMontos = dtValores.Rows[i][EgresosVariosCajaValoresService.RetencionAuxMontos_NombreCol].ToString().Split('@');

                                    // Se crea la cabecera de la retencion 
                                    campos = new Hashtable();
                                    campos.Add(CuentaCorrienteRetencionesEmitidasService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ID);
                                    campos.Add(CuentaCorrienteRetencionesEmitidasService.MonedaId_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.MonedaOrigenId_NombreCol]);
                                    campos.Add(CuentaCorrienteRetencionesEmitidasService.Cotizacion_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.CotizacionMonedaOrigen_NombreCol]);
                                    campos.Add(CuentaCorrienteRetencionesEmitidasService.ProveedorId_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.RetencionProveedorId_NombreCol]);
                                    campos.Add(CuentaCorrienteRetencionesEmitidasService.AutonumeracionId_NombreCol, cabeceraRow.RETENCION_AUTONUMERACION_ID);
                                    campos.Add(CuentaCorrienteRetencionesEmitidasService.Observacion_NombreCol, string.Empty);

                                    #region Actualizar la fecha de la retencion
                                    if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RetencionProveedoresUsarFechaFactura) == Definiciones.SiNo.No)
                                    {
                                        DataTable dtFacturaProveedor = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " = " + strAuxFacturas[0], string.Empty, sesion);
                                        if (CondicionesPagoService.EsContado((decimal)dtFacturaProveedor.Rows[0][FacturasProveedorService.CtacteCondicionPagoId_NombreCol]))
                                            campos.Add(CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol, dtFacturaProveedor.Rows[0][FacturasProveedorService.FechaFactura_NombreCol]);
                                        else
                                            campos.Add(CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol, cabeceraRow.IsFECHA_RECIBO_BENEFICIARIONull ? cabeceraRow.FECHA : cabeceraRow.FECHA_RECIBO_BENEFICIARIO);
                                    }
                                    else
                                    {
                                        campos.Add(CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol, cabeceraRow.IsFECHA_RECIBO_BENEFICIARIONull ? cabeceraRow.FECHA : cabeceraRow.FECHA_RECIBO_BENEFICIARIO);
                                    }
                                    #endregion Actualizar la fecha de la retencion

                                    if (!dtValores.Rows[0][EgresosVariosCajaValoresService.NroComprobanteRetencion_NombreCol].ToString().Trim().Equals(string.Empty))
                                        campos.Add(CuentaCorrienteRetencionesEmitidasService.NroComprobante_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.NroComprobanteRetencion_NombreCol]);

                                    decimal retencionEmitidaId = retencionEmitida.Guardar(cabeceraRow.ID, campos, sesion);
                                    EgresosVariosCajaValoresService.ActualizarRetenciones((decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.Id_NombreCol], retencionEmitidaId, (DateTime)campos[CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol], sesion);

                                    // Se crean los detalles de la retencion
                                    for (int indexDetalle = 0; indexDetalle < strAuxFacturas.Length; indexDetalle++)
                                    {
                                        campos = new Hashtable();
                                        campos.Add(CuentaCorrienteRetencionesEmitidasDetalleService.CtacteRetencionEmitidaId_NombreCol, retencionEmitidaId);
                                        campos.Add(CuentaCorrienteRetencionesEmitidasDetalleService.RetencionTipoId_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.RetencionTipoId_NombreCol]);
                                        campos.Add(CuentaCorrienteRetencionesEmitidasDetalleService.Monto_NombreCol, decimal.Parse(strAuxMontos[indexDetalle]));
                                        campos.Add(CuentaCorrienteRetencionesEmitidasDetalleService.CasoId_NombreCol, decimal.Parse(strAuxFacturas[indexDetalle]));
                                        retencion_detalle_id = retencionEmitidaDet.Guardar(campos, sesion);
                                    }
                                    #endregion Retencion
                                    break;
                                case Definiciones.CuentaCorrienteValores.Ajuste:
                                    break;
                                default: throw new Exception("Tipo de valor no implementado.");
                            }
                        }

                        //Actualizar la cuenta corriente de proveedor o persona
                        for (int i = 0; i < detalleRows.Length; i++)
                        {
                            if (!detalleRows[i].IsCTACTE_PROVEEDOR_IDNull)
                            {
                                #region Pago a Proveedores
                                DataTable dtCtacteProveedor = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresInfoCompleta(CuentaCorrienteProveedoresService.Id_NombreCol + " = " + detalleRows[i].CTACTE_PROVEEDOR_ID, string.Empty, sesion);
                                deudaMovimiento = (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.Credito_NombreCol] - (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.Debito_NombreCol];

                                if (Math.Round(detalleRows[i].MONTO_ORIGEN, 4) > Math.Round(deudaMovimiento, 4))
                                    throw new Exception("No pueden descontarse " + detalleRows[i].MONTO_ORIGEN + " ya que el movimiento actualmente tiene una deuda de " + deudaMovimiento + ".");

                                CuentaCorrienteProveedoresService.AgregarDebito(detalleRows[i].PROVEEDOR_ID,
                                                    detalleRows[i].CTACTE_PROVEEDOR_ID,
                                                    Definiciones.CuentaCorrienteConceptos.DebitoPorFlujo,
                                                    Definiciones.CuentaCorrienteValores.Efectivo,
                                                    cabeceraRow.CASO_ID,
                                                    detalleRows[i].MONEDA_ORIGEN_ID,
                                                    detalleRows[i].MONTO_ORIGEN,
                                                    string.Empty,
                                                    DateTime.Now,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    cabeceraRow.ID,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    sesion);

                                switch (int.Parse(dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.VistaFlujoId_NombreCol].ToString()))
                                {
                                    case Definiciones.FlujosIDs.CREDITOS_PROVEEDOR:
                                        DataTable dtCredito = CreditosProveedorService.GetCreditosProveedorDataTable(CreditosProveedorService.CasoId_NombreCol + " = " + dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.CasoId_NombreCol], string.Empty, sesion);
                                        DataTable dtCreditoDet = CreditosProveedorDetalleService.GetCreditosProveedorDetalleDataTable(CreditosProveedorDetalleService.Id_NombreCol + " = " + dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.CreditoProveedorDetId_NombreCol], string.Empty);
                                        decimal relacionInteresCapital = (decimal)dtCreditoDet.Rows[0][CreditosProveedorDetalleService.MontoInteres_NombreCol] / (decimal)dtCreditoDet.Rows[0][CreditosProveedorDetalleService.MontoCapital_NombreCol];

                                        CreditosProveedorService.EmitirFactura((decimal)dtCredito.Rows[0][CreditosProveedorService.Id_NombreCol],
                                                                               (1 - relacionInteresCapital) * detalleRows[i].MONTO_ORIGEN,
                                                                               relacionInteresCapital * detalleRows[i].MONTO_ORIGEN,
                                                                               cabeceraRow.FECHA,
                                                                               "Factura correspondiente a pago de Crédito de Proveedor caso " + dtCredito.Rows[0][CreditosProveedorService.CasoId_NombreCol] + " con la Orden de Pago caso " + cabeceraRow.CASO_ID + ".",
                                                                               sesion);

                                        break;
                                }
                                #endregion Pago a Proveedores
                            }
                            else if (!detalleRows[i].IsCTACTE_PERSONA_IDNull)
                            {
                                #region Pago a Personas
                                decimal saldoMovimiento = CuentaCorrientePersonasService.GetSaldoDeMovimiento(detalleRows[i].CTACTE_PERSONA_ID, sesion);
                                int flujoId;

                                DataTable dtCtactePersonaDet, dtCtactePersona;
                                System.Collections.Hashtable montoPorImpuesto = new System.Collections.Hashtable();
                                decimal[] impuestoId, monto;
                                int indiceAux;
                                decimal montoVerificacion, montoTotalDocumento, relacionEntrePagoYTotal;

                                if (detalleRows[i].MONTO_ORIGEN > saldoMovimiento)
                                    throw new Exception("No pueden acreditarse " + detalleRows[i].MONTO_ORIGEN + " ya que el movimiento actualmente tiene un saldo de " + saldoMovimiento + ".");

                                #region Calcular monto por tipo de impuesto

                                //Se obtiene el registro de la cuenta corriente de la persona
                                dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.Id_NombreCol + " = " + (decimal)detalleRows[i].CTACTE_PERSONA_ID, string.Empty, sesion);
                                montoTotalDocumento = (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol];
                                relacionEntrePagoYTotal = detalleRows[i].MONTO_ORIGEN / montoTotalDocumento;

                                dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable((decimal)detalleRows[i].CTACTE_PERSONA_ID, sesion);

                                for (int k = 0; k < dtCtactePersonaDet.Rows.Count; k++)
                                {
                                    if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                                        montoPorImpuesto[dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + (decimal)dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.Monto_NombreCol] * relacionEntrePagoYTotal;
                                    else
                                        montoPorImpuesto.Add(dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], (decimal)dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.Monto_NombreCol] * relacionEntrePagoYTotal);
                                }

                                impuestoId = new decimal[montoPorImpuesto.Count];
                                monto = new decimal[montoPorImpuesto.Count];

                                indiceAux = 0;
                                montoVerificacion = 0;
                                foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                                {
                                    impuestoId[indiceAux] = (decimal)par.Key;
                                    monto[indiceAux] = (decimal)par.Value;

                                    montoVerificacion += monto[indiceAux];

                                    indiceAux++;
                                }

                                if (Math.Round(detalleRows[i].MONTO_ORIGEN) != Math.Round(montoVerificacion))
                                    throw new Exception("Error en TransferenciasCtaCtePersonasService.ProcesarCambioEstado(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + cabeceraRow.MONTO_TOTAL + ".");
                                #endregion Calcular monto por tipo de impuesto

                                CuentaCorrientePersonasService.AgregarCredito(detalleRows[i].PERSONA_ID,
                                                detalleRows[i].CTACTE_PERSONA_ID,
                                                Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                cabeceraRow.CASO_ID,
                                                detalleRows[i].MONEDA_ORIGEN_ID,
                                                detalleRows[i].COTIZACION_COMPRA_ORIGEN,
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
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                1,
                                                1,
                                                sesion);

                                switch ((int)(decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaFlujoId_NombreCol])
                                {
                                    case Definiciones.FlujosIDs.ANTICIPO_PERSONA:
                                        //Se disminuye el saldo
                                        DataTable dtAnticipoPersona = AnticiposPersonaService.GetAnticipoPersonaDataTable(AnticiposPersonaService.CasoId_NombreCol + " = " + dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], string.Empty);
                                        AnticiposPersonaService.DisminuirSaldoDisponible((decimal)dtAnticipoPersona.Rows[0][AnticiposPersonaService.Id_NombreCol], detalleRows[i].MONTO_ORIGEN, true, sesion);
                                        break;
                                    case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:
                                        //Se disminuye el saldo
                                        DataTable dtNotaCreditoPersona = NotasCreditoPersonaService.GetNotaCreditoPersonaDataTable(NotasCreditoPersonaService.CasoId_NombreCol + " = " + dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], string.Empty);
                                        NotasCreditoPersonaService.DisminuirSaldoDisponible((decimal)dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.Id_NombreCol], detalleRows[i].MONTO_ORIGEN, true, sesion);
                                        break;
                                    case Definiciones.FlujosIDs.CREDITOS:
                                        //Una vez que se haya finalizado el desembolso por el credito, el mismo debe pasar a En-Proceso
                                        //Esa accion es realizada en el metodo EjecutarAccionesLuegoDeCAmbioEstado
                                        break;
                                    case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES:
                                        //Una vez que se haya finalizado el desembolso por el credito, el mismo debe pasar a En-Proceso
                                        //Esa accion es realizada en el metodo EjecutarAccionesLuegoDeCAmbioEstado
                                        break;
                                    default:
                                        throw new Exception("Error en EgresosVariosCajaService.ProcesarCambioEstado(). Flujo no implementado para devolución a persona.");
                                }
                                #endregion Pago a Personas
                            }
                        }
                    }
                }
                //Aprobado a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                         estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Actualizar la ctacte del proveedor
                    //Borrar las retenciones emitidas
                    //Borrar el efectivo agregado anteriormente
                    //Actualizar el movimiento de fondo fijo.
                    exito = true;
                    revisarRequisitos = true;

                    if (exito)
                    {
                        CuentaCorrienteFondosFijosMovimientosService ctacteFondoFijoMov = new CuentaCorrienteFondosFijosMovimientosService();
                        CuentaCorrienteRetencionesEmitidasService ctacteRetencionEmitida = new CuentaCorrienteRetencionesEmitidasService();

                        DataTable dtValores = EgresosVariosCajaValoresService.GetDataTable(EgresosVariosCajaValoresService.EgresoVarioCajaId_NombreCol + " = " + cabeceraRow.ID, string.Empty, sesion);
                        for (int i = 0; i < dtValores.Rows.Count; i++)
                        {
                            int ctacteValorId = int.Parse(dtValores.Rows[i][EgresosVariosCajaValoresService.CtacteValorId_NombreCol].ToString());
                            switch (ctacteValorId)
                            {
                                case Definiciones.CuentaCorrienteValores.Efectivo:
                                    //Borrar el efectivo agregado anteriormente
                                    EgresosVariosCajaValoresService.Borrar((decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.Id_NombreCol], sesion);

                                    if (!cabeceraRow.IsCTACTE_FONDO_FIJO_IDNull)
                                    {
                                        //Actualizar el saldo del fondo fijo
                                        ctacteFondoFijoMov.Ingreso(cabeceraRow.CTACTE_FONDO_FIJO_ID,
                                                                  Definiciones.Error.Valor.EnteroPositivo,
                                                                  Definiciones.FlujosIDs.EGRESO_VARIO_CAJA,
                                                                  cabeceraRow.ID,
                                                                  (decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.MontoDestino_NombreCol],
                                                                  (decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.CotizacionMonedaDestino_NombreCol],
                                                                  "Ingreso por Egreso Vario de Caja " + cabeceraRow.CASO_ID + " pasado del estado " + casoRow.ESTADO_ID + " a " + estado_destino + ".",
                                                                  cabeceraRow.FECHA,
                                                                  sesion);
                                    }
                                    else if (!cabeceraRow.IsCTACTE_CAJA_SUCURSAL_IDNull)
                                    {
                                        DataTable dtCtacteCajaSucusral = new CuentaCorrienteCajasSucursalService().GetCuentaCorrienteCajasSucursalDataTable(CuentaCorrienteCajasSucursalService.Id_NombreCol + " = " + cabeceraRow.CTACTE_CAJA_SUCURSAL_ID, string.Empty);
                                        //Re-ingresar efectivo a la caja
                                        var campos = new System.Collections.Hashtable()
                                        {
                                            { CuentaCorrienteCajaService.Fecha_NombreCol, cabeceraRow.FECHA },
                                            { CuentaCorrienteCajaService.MonedaId_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.MonedaOrigenId_NombreCol] },
                                            { CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.CotizacionMonedaDestino_NombreCol] },
                                            { CuentaCorrienteCajaService.Monto_NombreCol, dtValores.Rows[i][EgresosVariosCajaValoresService.MontoOrigen_NombreCol] },
                                            { CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo },
                                            { CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID },
                                            { CuentaCorrienteCajaService.SucursalId_NombreCol, dtCtacteCajaSucusral.Rows[0][CuentaCorrienteCajasSucursalService.SucursalId_NombreCol] },
                                            { CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, dtCtacteCajaSucusral.Rows[0][CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol] },
                                            { CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.DebitoPorFlujo },
                                            { CuentaCorrienteCajaService.EgresoVarioId_NombreCol, cabeceraRow.ID },
                                            { CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, cabeceraRow.CTACTE_CAJA_SUCURSAL_ID }
                                        };
                                        CuentaCorrienteCajaService.Guardar(campos, sesion);
                                    }
                                    break;
                                case Definiciones.CuentaCorrienteValores.Cheque:
                                    #region Cheque girado
                                    //Se anula el cheque
                                    CuentaCorrienteChequesGiradosService.Anular((decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.CGCtacteChequeGiradoId_NombreCol],
                                                              "Anulado al pasar Egreso Vario de Caja caso " + cabeceraRow.CASO_ID + " del estado " + casoRow.ESTADO_ID + " a " + estado_destino + ".",
                                                              sesion);

                                    //Se afecta la cuenta bancaria si el cheque ya la habia afectado
                                    if (CuentaCorrienteChequesGiradosService.SaldoAfectado((decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.CGCtacteChequeGiradoId_NombreCol], sesion))
                                    {
                                        CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                              (decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.CGCtacteBancariaId_NombreCol],
                                              Definiciones.FlujosIDs.EGRESO_VARIO_CAJA,
                                              cabeceraRow.CASO_ID,
                                              Definiciones.Error.Valor.EnteroPositivo,
                                              cabeceraRow.ID,
                                              (decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.MonedaOrigenId_NombreCol],
                                              (decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.MontoOrigen_NombreCol],
                                              (decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.CotizacionMonedaOrigen_NombreCol],
                                              (DateTime)dtValores.Rows[i][EgresosVariosCajaValoresService.CGFechaVencimiento_NombreCol],
                                              "Caso " + cabeceraRow.CASO_ID + " de " + Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.EGRESO_VARIO_CAJA) + " pasado del estado " + casoRow.ESTADO_ID + " al estado " + estado_destino + ". Anulación del cheque " + dtValores.Rows[i][EgresosVariosCajaValoresService.CGNumeroCheque_NombreCol] + " fecha " + ((DateTime)dtValores.Rows[i][EgresosVariosCajaValoresService.CGFechaEmision_NombreCol]).Date + ".",
                                              (decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.CGCtacteChequeGiradoId_NombreCol],
                                              null,
                                              true,
                                              sesion);
                                    }
                                    #endregion Cheque girado
                                    break;
                                case Definiciones.CuentaCorrienteValores.Ajuste:
                                    break;
                                case Definiciones.CuentaCorrienteValores.RetencionIVA:
                                    //Anular los comprobantes de retencion
                                    ctacteRetencionEmitida.Anular((decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.RetencionEmitidaId_NombreCol], sesion);
                                    break;
                                default: throw new Exception("Tipo de valor no implementado.");
                            }
                            //Borrado lógico valores
                            //EgresosVariosCajaValoresService.ActualizarEstado(decimal.Parse(dtValores.Rows[i][EgresosVariosCajaValoresService.Id_NombreCol].ToString()), Definiciones.Estado.Inactivo, sesion);
                        }

                        //Actualizar la cuenta corriente del proveedor
                        for (int i = 0; i < detalleRows.Length; i++)
                        {
                            if (!detalleRows[i].IsCTACTE_PERSONA_IDNull)
                                throw new Exception("No pueden retrocederse casos que contengan pagos a personas.");


                            CuentaCorrienteProveedoresService.DeshacerPagarCredito(detalleRows[i].CTACTE_PROVEEDOR_ID, cabeceraRow.CASO_ID, sesion);
                            //Borrado lógico detalles
                            //EgresosVariosCajaDetalleService.ActualizarEstado(detalleRows[i].ID, Definiciones.Estado.Inactivo, sesion);
                        }

                        //Borrar el asiento que se creo cuando se aprobo el pago
                        CBA.FlowV2.Services.Contabilidad.AsientosService.BorrarPorCasoYTransicion(
                        cabeceraRow.CASO_ID,
                        TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.EGRESO_VARIO_CAJA, Definiciones.EstadosFlujos.Pendiente, Definiciones.EstadosFlujos.Aprobado, sesion),
                        sesion);
                    }
                }

                //Verificar si se cumplen los requisitos
                if (exito && revisarRequisitos)
                {
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                }

                if (exito)
                {
                    sesion.Db.CASOSCollection.Update(casoRow);
                    sesion.Db.EGRESOS_VARIOS_CAJACollection.Update(cabeceraRow);
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
                EGRESOS_VARIOS_CAJARow cabeceraRow = sesion.Db.EGRESOS_VARIOS_CAJACollection.GetByCASO_ID(caso_id)[0];
                EGRESOS_VARIOS_CAJA_DETRow[] detalleRows = sesion.Db.EGRESOS_VARIOS_CAJA_DETCollection.GetByEGRESO_VARIO_CAJA_ID(cabeceraRow.ID);
                decimal deudaMovimiento, casoReferidoId;

                string msg;
                bool exitoCasoAsociado;

                if (casoRow.ESTADO_ID == Definiciones.EstadosFlujos.Aprobado &&
                    casoRow.ESTADO_ANTERIOR_ID == Definiciones.EstadosFlujos.Pendiente)
                {
                    for (int i = 0; i < detalleRows.Length; i++)
                    {
                        if (!detalleRows[i].IsCTACTE_PROVEEDOR_IDNull)
                        {
                            #region ctacte proveedor
                            DataTable dtCtacteProveedor = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresInfoCompleta(CuentaCorrienteProveedoresService.Id_NombreCol + " = " + detalleRows[i].CTACTE_PROVEEDOR_ID, string.Empty, sesion);
                            if (!dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.VistaFlujoId_NombreCol].Equals(DBNull.Value))
                            {
                                deudaMovimiento = CuentaCorrienteProveedoresService.GetDeudaTotal(detalleRows[i].CTACTE_PROVEEDOR_ID, sesion);
                                casoReferidoId = (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.CasoId_NombreCol];

                                if (Math.Round(deudaMovimiento, 4) == 0)
                                {
                                    switch (int.Parse(dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.VistaFlujoId_NombreCol].ToString()))
                                    {
                                        case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                                            exitoCasoAsociado = (new FacturasProveedorService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, false, out msg, sesion);
                                            if (exitoCasoAsociado)
                                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso del Ereso Vario de Caja " + cabeceraRow.CASO_ID + " al estado " + casoRow.ESTADO_ID + ".", sesion);
                                            if (exitoCasoAsociado)
                                                (new FacturasProveedorService()).EjecutarAccionesLuegoDeCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, sesion);
                                            break;
                                        case Definiciones.FlujosIDs.NOTA_DEBITO_PROVEEDOR:
                                            exitoCasoAsociado = (new NotasDebitoProveedorService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, false, out msg, sesion);
                                            if (exitoCasoAsociado)
                                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso del Ereso Vario de Caja " + cabeceraRow.CASO_ID + " al estado " + casoRow.ESTADO_ID + ".", sesion);
                                            if (exitoCasoAsociado)
                                                (new NotasDebitoProveedorService()).EjecutarAccionesLuegoDeCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, sesion);
                                            break;
                                        default:
                                            throw new Exception("Error en EgresosVariosCajaService.EjecutarAccionesLuegoDeCambioEstado(). Flujo no implementado para pago a proveedor.");
                                    }
                                }
                            }
                            #endregion ctacte proveedor
                        }
                        else if (!detalleRows[i].IsCTACTE_PERSONA_IDNull)
                        {
                            #region ctacte persona
                            decimal saldoMovimiento = CuentaCorrientePersonasService.GetSaldoDeMovimiento(detalleRows[i].CTACTE_PERSONA_ID, sesion);

                            //Cerrar la FC de Proveedor si el saldo es cero
                            if (Math.Round(saldoMovimiento, 4) == 0)
                            {
                                DataTable dtCtactePers = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.Id_NombreCol + " = " + detalleRows[i].CTACTE_PERSONA_ID, string.Empty, sesion);
                                casoReferidoId = (decimal)dtCtactePers.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol];
                                int flujoId = int.Parse(dtCtactePers.Rows[0][CuentaCorrientePersonasService.VistaFlujoId_NombreCol].ToString());

                                switch (flujoId)
                                {
                                    case Definiciones.FlujosIDs.ANTICIPO_PERSONA:
                                        exitoCasoAsociado = (new AnticiposPersonaService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, false, out msg, sesion);
                                        if (exitoCasoAsociado)
                                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso de la Orden de Pago caso " + cabeceraRow.CASO_ID + " al estado " + casoRow.ESTADO_ID + ".", sesion);
                                        if (exitoCasoAsociado)
                                            (new AnticiposPersonaService()).EjecutarAccionesLuegoDeCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, sesion);
                                        if (!exitoCasoAsociado)
                                            throw new Exception("Error en EgresosVariosCajaService.EjecutarAccionesLuegoDeCambioEstado(), Anticipo Persona. " + msg + ".");
                                        break;
                                    case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:
                                        exitoCasoAsociado = (new NotasCreditoPersonaService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, false, out msg, sesion);
                                        if (exitoCasoAsociado)
                                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso de la Orden de Pago caso " + cabeceraRow.CASO_ID + " al estado " + casoRow.ESTADO_ID + ".", sesion);
                                        if (exitoCasoAsociado)
                                            (new NotasCreditoPersonaService()).EjecutarAccionesLuegoDeCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, sesion);
                                        if (!exitoCasoAsociado)
                                            throw new Exception("Error en EgresosVariosCajaService.EjecutarAccionesLuegoDeCambioEstado(), NC Persona. " + msg + ".");
                                        break;
                                    case Definiciones.FlujosIDs.CREDITOS:
                                        var credito = CreditosService.GetPorCaso(casoReferidoId, sesion);
                                        credito.IniciarUsingSesion(sesion);
                                        credito.ProcesarCambioEstado(Definiciones.EstadosFlujos.Vigente, false, new ToolbarFlujoService.ComentarioTransicion { texto = "Transición automática." }, sesion);
                                        credito.FinalizarUsingSesion();
                                        break;
                                    case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES:
                                        exitoCasoAsociado = new DescuentoDocumentosClienteService().ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Vigente, false, out msg, sesion);
                                        if (exitoCasoAsociado)
                                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Vigente, "Transición automática.", sesion);
                                        if (exitoCasoAsociado)
                                            new DescuentoDocumentosClienteService().EjecutarAccionesLuegoDeCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Vigente, sesion);
                                        if (!exitoCasoAsociado)
                                            throw new Exception("Error en EgresosVariosCajaService.EjecutarAccionesLuegoDeCambioEstado(), Descuento Documento Persona. " + msg + ".");
                                        break;
                                    default:
                                        throw new Exception("Error en EgresosVariosCajaService.EjecutarAccionesLuegoDeCambioEstado(). Flujo no implementado para pago a personas.");
                                }
                            }
                            #endregion ctacte persona
                        }
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
            EGRESOS_VARIOS_CAJARow row = sesion.Db.EGRESOS_VARIOS_CAJACollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE;
        }

        #endregion Implementacion de metodos abstract

        #region GetEgresosVariosCajaDataTable
        /// <summary>
        /// Gets the egresos varios caja data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetEgresosVariosCajaDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetEgresosVariosCajaDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetEgresosVariosCajaDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.EGRESOS_VARIOS_CAJACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetEgresosVariosCajaDataTable

        #region GetEgresosVariosCajaInfoCompleta
        /// <summary>
        /// Gets the egresos varios caja info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetEgresosVariosCajaInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetEgresosVariosCajaInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetEgresosVariosCajaInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.EGRESOS_VARIOS_CAJA_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetEgresosVariosCajaInfoCompleta

        #region GetFacturasProveedoresPorPagar
        /// <summary>
        /// Gets the facturas proveedores por pagar.
        /// </summary>
        /// <param name="proveedor_id">The proveedor_id.</param>
        /// <returns></returns>
        public static DataTable GetFacturasProveedoresPorPagar(decimal proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = string.Empty;

                clausulas = CuentaCorrienteProveedoresService.ProveedorId_NombreCol + " = " + proveedor_id + " and " +
                            CuentaCorrienteProveedoresService.Credito_NombreCol + " > " + CuentaCorrienteProveedoresService.Debito_NombreCol;

                return CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresInfoCompleta(clausulas, string.Empty, sesion);
            }
        }
        #endregion GetFacturasProveedoresPorPagar

        #region GetCasosRelacionadosADetalles
        public static decimal[] GetCasosRelacionadosADetalles(decimal egreso_vario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                List<decimal> lCasos = new List<decimal>();
                DataTable dtDetalles = EgresosVariosCajaDetalleService.GetEgresosVariosCajaDetallesInfoCompleta(EgresosVariosCajaDetalleService.EgresoVarioCajaId_NombreCol + " = " + egreso_vario_id, string.Empty, sesion);

                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                {
                    DataTable dtCaso = CasosService.GetCasosDataTable(CasosService.Id_NombreCol + " = " + dtDetalles.Rows[i][EgresosVariosCajaDetalleService.VistaCasoReferidoId_NombreCol], string.Empty);
                    switch ((int)(decimal)dtCaso.Rows[0][CasosService.FlujoId_NombreCol])
                    {
                        case Definiciones.FlujosIDs.CREDITOS:
                            DataTable dtFacturas = FacturasClienteService.GetFacturaClienteDataTable(FacturasClienteService.CasoOrigenId_NombreCol + " = " + dtCaso.Rows[0][CasosService.Id_NombreCol], FacturasClienteService.CasoId_NombreCol, sesion);
                            for (int j = 0; j < dtFacturas.Rows.Count; j++)
                                lCasos.Add((decimal)dtFacturas.Rows[j][FacturasClienteService.CasoId_NombreCol]);
                            break;
                    }
                }

                return lCasos.ToArray();
            }
        }
        #endregion GetCasosRelacionadosADetalles

        #region CalcularTotales
        /// <summary>
        /// Calculars the totales.
        /// </summary>
        /// <param name="egreso_vario_caja_id">The egreso_vario_caja_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void CalcularTotales(decimal egreso_vario_caja_id, SessionService sesion)
        {
            DataTable dtEgresoVarioDetalle = sesion.Db.EGRESOS_VARIOS_CAJA_DETCollection.GetByEGRESO_VARIO_CAJA_IDAsDataTable(egreso_vario_caja_id);
            EGRESOS_VARIOS_CAJARow row = sesion.Db.EGRESOS_VARIOS_CAJACollection.GetByPrimaryKey(egreso_vario_caja_id);
            string valorAnterior = row.ToString();

            row.MONTO_TOTAL = 0;

            for (int i = 0; i < dtEgresoVarioDetalle.Rows.Count; i++)
                row.MONTO_TOTAL += (decimal)dtEgresoVarioDetalle.Rows[i][EgresosVariosCajaDetalleService.MontoDestino_NombreCol];

            sesion.Db.EGRESOS_VARIOS_CAJACollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion CalcularTotales

        #region Crear Caso

        public static bool CrearCabecera(decimal? ctacte_fondo_fijo_id, decimal? ctacte_caja_sucursal_id, decimal sucursal_id, decimal autonumeracion_id, decimal moneda_id, decimal cotizacion_moneda, decimal monto_total, string fecha_yyyymmdd, string fecha_recibo_beneficiario_yyyymmdd, string NroComprobante, string NombreBeneficiario, string NroReciboBeneficiario, string observacion, bool gasto_directivo, string retencion_unificada, decimal retencion_autonumeracion_id, ref decimal egresos_varios_caja_id, ref decimal egresos_varios_caja_caso_id, SessionService sesion)
        {
            EgresosVariosCajaService.PropiedadesCabecera egresosVariosCajaCabecera = new EgresosVariosCajaService.PropiedadesCabecera();

            if(ctacte_fondo_fijo_id.HasValue)
                egresosVariosCajaCabecera.CtaCteFondoFijoId = ctacte_fondo_fijo_id.Value;
            if (ctacte_caja_sucursal_id.HasValue)
                egresosVariosCajaCabecera.CtaCteCajaSucursalId = ctacte_caja_sucursal_id.Value;
            egresosVariosCajaCabecera.SucursalId = sucursal_id;
            egresosVariosCajaCabecera.AutonumeracionId = autonumeracion_id;
            egresosVariosCajaCabecera.MonedaId = moneda_id;
            egresosVariosCajaCabecera.CotizacionMoneda = cotizacion_moneda;
            egresosVariosCajaCabecera.MontoTotal = monto_total;
            egresosVariosCajaCabecera.Fecha_yyyymmdd = fecha_yyyymmdd;
            egresosVariosCajaCabecera.FechaReciboBeneficiario_yyyymmdd = fecha_recibo_beneficiario_yyyymmdd;
            egresosVariosCajaCabecera.NombreBeneficiario = NombreBeneficiario;
            egresosVariosCajaCabecera.NroComprobante = NroComprobante;
            egresosVariosCajaCabecera.NroReciboBeneficiario = NroReciboBeneficiario;
            egresosVariosCajaCabecera.Observacion = observacion;
            egresosVariosCajaCabecera.GastoDirectivo = gasto_directivo;
            egresosVariosCajaCabecera.RetencionUnificada = retencion_unificada;
            egresosVariosCajaCabecera.RetencionAutonumeracionId = retencion_autonumeracion_id;

            return EgresosVariosCajaService.Crear(egresosVariosCajaCabecera, out egresos_varios_caja_id, out egresos_varios_caja_caso_id, sesion);
        }

        #endregion Crear Caso

        #region Crear
        public static bool Crear(PropiedadesCabecera cabecera, out decimal egresos_varios_caja_id, out decimal egresos_varios_caja_caso_id, SessionService sesion)
        {
            bool exito = false;

            try
            {
                decimal casoId = Definiciones.Error.Valor.EnteroPositivo;
                string estadoId = Definiciones.Error.Valor.EnteroPositivo.ToString();
                DateTime fecha, fechaReciboBeneficiario;
                System.Collections.Hashtable campos = new System.Collections.Hashtable();

                fecha = DateTime.ParseExact(cabecera.Fecha_yyyymmdd, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                fechaReciboBeneficiario = DateTime.ParseExact(cabecera.FechaReciboBeneficiario_yyyymmdd, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);

                #region Cabecera
                campos.Add(EgresosVariosCajaService.AutonumeracionId_NombreCol, cabecera.AutonumeracionId);
                campos.Add(EgresosVariosCajaService.CotizacionMoneda_NombreCol, cabecera.CotizacionMoneda);
                if (cabecera.CtaCteFondoFijoId != Definiciones.Error.Valor.EnteroPositivo)
                    campos.Add(EgresosVariosCajaService.CtacteFondoFijoId_NombreCol, cabecera.CtaCteFondoFijoId);
                else if (cabecera.CtaCteCajaSucursalId != Definiciones.Error.Valor.EnteroPositivo)
                    campos.Add(EgresosVariosCajaService.CtacteCajaSucursalId_NombreCol, cabecera.CtaCteCajaSucursalId);
                else
                    throw new Exception("No se definió un fondo fijo o caja de sucursal para el egreso vario.");
                campos.Add(EgresosVariosCajaService.Fecha_NombreCol, fecha);
                campos.Add(EgresosVariosCajaService.FechaReciboBeneficiario_NombreCol, fechaReciboBeneficiario);
                campos.Add(EgresosVariosCajaService.GastoDirectivo_NombreCol, cabecera.GastoDirectivo ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(EgresosVariosCajaService.MonedaId_NombreCol, cabecera.MonedaId);
                campos.Add(EgresosVariosCajaService.MontoTotal_NombreCol, cabecera.MontoTotal);
                campos.Add(EgresosVariosCajaService.NombreBeneficiario_NombreCol, cabecera.NombreBeneficiario);
                campos.Add(EgresosVariosCajaService.NroComprobante_NombreCol, cabecera.NroComprobante);
                campos.Add(EgresosVariosCajaService.NroReciboBeneficiario_NombreCol, cabecera.NroReciboBeneficiario);
                campos.Add(EgresosVariosCajaService.Observacion_NombreCol, cabecera.Observacion);
                campos.Add(EgresosVariosCajaService.SucursalId_NombreCol, cabecera.SucursalId);
                campos.Add(EgresosVariosCajaService.RetencionUnificada_NombreCol, cabecera.RetencionUnificada);
                campos.Add(EgresosVariosCajaService.RetencionAutonumeracionId_NombreCol, cabecera.RetencionAutonumeracionId);

                exito = EgresosVariosCajaService.Guardar(campos, true, ref casoId, ref estadoId, sesion);

                if (exito)
                {
                    EGRESOS_VARIOS_CAJARow row = sesion.Db.EGRESOS_VARIOS_CAJACollection.GetRow(EgresosVariosCajaService.CasoId_NombreCol + " = " + casoId);
                    egresos_varios_caja_caso_id = row.CASO_ID;
                    egresos_varios_caja_id = row.ID;
                }
                else
                {
                    egresos_varios_caja_caso_id = Definiciones.Error.Valor.EnteroPositivo;
                    egresos_varios_caja_id = Definiciones.Error.Valor.EnteroPositivo;
                }

                #endregion Cabecera

                return exito;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Crear

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        /// 
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
            EGRESOS_VARIOS_CAJARow row = new EGRESOS_VARIOS_CAJARow();

            try
            {
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[EgresosVariosCajaService.SucursalId_NombreCol].ToString()),
                                                          int.Parse(Definiciones.FlujosIDs.EGRESO_VARIO_CAJA.ToString()),
                                                          int.Parse(sesion.Usuario_Id.ToString()),
                                                          SessionService.GetClienteIP());
                    row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                    row.ID = sesion.Db.GetSiguienteSecuencia("egresos_varios_caja_sqc");
                    caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                    estado_id = Definiciones.EstadosFlujos.Borrador;
                }
                else
                {
                    row = sesion.Db.EGRESOS_VARIOS_CAJACollection.GetRow(EgresosVariosCajaService.Id_NombreCol + " = " + campos[EgresosVariosCajaService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                row.AUTONUMERACION_ID = (decimal)campos[EgresosVariosCajaService.AutonumeracionId_NombreCol];

                if (campos.Contains(EgresosVariosCajaService.NroComprobante_NombreCol))
                    row.NRO_COMPROBANTE = (string)campos[EgresosVariosCajaService.NroComprobante_NombreCol];

                if (campos.Contains(EgresosVariosCajaService.RetencionAutonumeracionId_NombreCol))
                    row.RETENCION_AUTONUMERACION_ID = (decimal)campos[EgresosVariosCajaService.RetencionAutonumeracionId_NombreCol];
                else
                    row.IsRETENCION_AUTONUMERACION_IDNull = true;
                row.RETENCION_UNIFICADA = (string)campos[EgresosVariosCajaService.RetencionUnificada_NombreCol];

                row.FECHA = (DateTime)campos[EgresosVariosCajaService.Fecha_NombreCol];

                if (campos.Contains(EgresosVariosCajaService.FechaReciboBeneficiario_NombreCol))
                    row.FECHA_RECIBO_BENEFICIARIO = (DateTime)campos[EgresosVariosCajaService.FechaReciboBeneficiario_NombreCol];
                else
                    row.IsFECHA_RECIBO_BENEFICIARIONull = true;

                row.NRO_RECIBO_BENEFICIARIO = (string)campos[EgresosVariosCajaService.NroReciboBeneficiario_NombreCol];
                row.NOMBRE_BENEFICIARIO = (string)campos[EgresosVariosCajaService.NombreBeneficiario_NombreCol];

                row.OBSERVACION = (string)campos[EgresosVariosCajaService.Observacion_NombreCol];

                //Si cambia
                if (!row.SUCURSAL_ID.Equals(campos[EgresosVariosCajaService.SucursalId_NombreCol]))
                {
                    if (!SucursalesService.EstaActivo((decimal)campos[EgresosVariosCajaService.SucursalId_NombreCol]))
                        throw new Exception("La sucursal no está activa.");

                    row.SUCURSAL_ID = (decimal)campos[EgresosVariosCajaService.SucursalId_NombreCol];
                }

                //Si cambia
                if (row.MONEDA_ID.Equals(DBNull.Value) || row.MONEDA_ID != (decimal)campos[EgresosVariosCajaService.MonedaId_NombreCol])
                {
                    if (!MonedasService.EstaActivo((decimal)campos[EgresosVariosCajaService.MonedaId_NombreCol]))
                        throw new Exception("La moneda no está activa");

                    row.MONEDA_ID = (decimal)campos[EgresosVariosCajaService.MonedaId_NombreCol];

                    //Se actualiza la cotizacion de la moneda
                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, row.FECHA, sesion);
                    if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda origen.");
                }

                if (!campos.Contains(EgresosVariosCajaService.CtacteFondoFijoId_NombreCol))
                {
                    row.IsCTACTE_FONDO_FIJO_IDNull = true;
                }
                else
                {
                    //Si cambia
                    if (row.IsCTACTE_FONDO_FIJO_IDNull || row.CTACTE_FONDO_FIJO_ID != (decimal)campos[EgresosVariosCajaService.CtacteFondoFijoId_NombreCol])
                    {
                        if (!CuentaCorrienteFondosFijosService.EstaActivo((decimal)campos[EgresosVariosCajaService.CtacteFondoFijoId_NombreCol], sesion))
                            throw new Exception("El fondo fijo no está activo.");

                        row.CTACTE_FONDO_FIJO_ID = (decimal)campos[EgresosVariosCajaService.CtacteFondoFijoId_NombreCol];
                    }
                }

                if (!campos.Contains(EgresosVariosCajaService.CtacteCajaSucursalId_NombreCol))
                {
                    row.IsCTACTE_CAJA_SUCURSAL_IDNull = true;
                }
                else
                {
                    if (row.IsCTACTE_CAJA_SUCURSAL_IDNull || row.CTACTE_CAJA_SUCURSAL_ID != (decimal)campos[EgresosVariosCajaService.CtacteCajaSucursalId_NombreCol])
                    {
                        if (!CuentaCorrienteCajasSucursalService.EstaAbierta((decimal)campos[EgresosVariosCajaService.CtacteCajaSucursalId_NombreCol], sesion))
                            throw new Exception("La caja no está abierta.");

                        row.CTACTE_CAJA_SUCURSAL_ID = (decimal)campos[EgresosVariosCajaService.CtacteCajaSucursalId_NombreCol];
                    }
                }

                //se agrega/modifica el tipo de cuenta bancaria si es que existe
                if (campos.Contains(EgresosVariosCajaService.GastoDirectivo_NombreCol))
                    row.GASTO_DIRECTIVO = campos[EgresosVariosCajaService.GastoDirectivo_NombreCol].ToString();
                else
                    if (insertarNuevo)
                        row.GASTO_DIRECTIVO = Definiciones.SiNo.No;

                if (insertarNuevo) sesion.Db.EGRESOS_VARIOS_CAJACollection.Insert(row);
                else sesion.Db.EGRESOS_VARIOS_CAJACollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();
                camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                if (!Interprete.EsNullODBNull(row.NRO_RECIBO_BENEFICIARIO))
                    camposCaso.Add(CasosService.NroComprobante2_NombreCol, row.NRO_RECIBO_BENEFICIARIO);
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
        #endregion Guardar

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
                    string mensaje = string.Empty;

                    //Se obtienen el caso y la factura a ser borrados
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    EGRESOS_VARIOS_CAJARow cabecera = sesion.Db.EGRESOS_VARIOS_CAJACollection.GetByCASO_ID(caso_id)[0];

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Se obtienen los detalles del caso a ser borrados.
                    DataTable detalles = EgresosVariosCajaDetalleService.GetEgresosVariosCajaDetallesDataTable(EgresosVariosCajaDetalleService.EgresoVarioCajaId_NombreCol + " = " + cabecera.ID, string.Empty);

                    //Si el caso posee detalles no puede ser borrado
                    if (exito && detalles.Rows.Count > 0)
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que posee detalles.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.EGRESOS_VARIOS_CAJACollection.DeleteByCASO_ID(caso_id);
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
            get { return "EGRESOS_VARIOS_CAJA"; }
        }
        public static string Nombre_Vista
        {
            get { return "EGRESOS_VARIOS_CAJA_INFO_COMPL"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.CASO_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteCajaSucursalId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        public static string CtacteFondoFijoId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.CTACTE_FONDO_FIJO_IDColumnName; }
        }
        public static string FechaReciboBeneficiario_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.FECHA_RECIBO_BENEFICIARIOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.MONEDA_IDColumnName; }
        }
        public static string MontoTotal_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.MONTO_TOTALColumnName; }
        }
        public static string NombreBeneficiario_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.NRO_COMPROBANTEColumnName; }
        }
        public static string NroReciboBeneficiario_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.NRO_RECIBO_BENEFICIARIOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.OBSERVACIONColumnName; }
        }
        public static string RetencionAutonumeracionId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.RETENCION_AUTONUMERACION_IDColumnName; }
        }
        public static string RetencionUnificada_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.RETENCION_UNIFICADAColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.SUCURSAL_IDColumnName; }
        }
        public static string GastoDirectivo_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJACollection.GASTO_DIRECTIVOColumnName; }
        }

        #region Vista

        public static string VistaCasoEstadoId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_INFO_COMPLCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCtacteFondoFijoAbreviatura_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_INFO_COMPLCollection.CTACTE_FONDO_FIJO_ABREVIATURAColumnName; }
        }
        public static string VistaCtacteFondoFijoNombre_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_INFO_COMPLCollection.CTACTE_FONDO_FIJO_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; }
        }
        #endregion Vista

        #endregion Accessors
    }
}
