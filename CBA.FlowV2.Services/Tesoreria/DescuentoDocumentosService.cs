#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using System.Collections;
using System.Collections.Generic;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class DescuentoDocumentosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS;
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
                mensaje = string.Empty;
                try
                {
                    DescuentoDocumentosDetalleService descuentoDocumentoDet = new DescuentoDocumentosDetalleService();
                    DescuentoDocumentosPagosService descuentoDocumentoPago = new DescuentoDocumentosPagosService();
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    DESCUENTO_DOCUMENTOSRow cabeceraRow = sesion.Db.DESCUENTO_DOCUMENTOSCollection.GetByCASO_ID(caso_id)[0];
                    DataTable dtDetalles = descuentoDocumentoDet.GetDescuentoDocumentosDetalleDataTable(DescuentoDocumentosDetalleService.DescuentoDocumentosId_NombreCol + " = " + cabeceraRow.ID, string.Empty);
                    DataTable dtPagos = descuentoDocumentoPago.GetDescuentosDocumentosPagosDataTable(DescuentoDocumentosPagosService.DescuentoDocumentoId_NombreCol + " = " + cabeceraRow.ID, string.Empty);
 
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Los valores del detalle del caso son reingresados a traves de borrar los detalles.
                        exito = true;
                        revisarRequisitos = true;

                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            descuentoDocumentoDet.Borrar((decimal)dtDetalles.Rows[i][DescuentoDocumentosDetalleService.Id_NombreCol]);
                        }
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //Controlar que el monto total del pago coincide con el total de
                        //documentos a descontar menos la comision.
                        exito = true;
                        revisarRequisitos = true;

                        //Totales en dolares
                        decimal totalDocumentos = 0, totalComision = 0, totalPagado = 0;
                        decimal totalDocumentosUSD = 0, totalComisionUSD = 0, totalPagadoUSD = 0;
                        decimal monedaPagoUniforme = Definiciones.Error.Valor.EnteroPositivo;
                        decimal monedaCotizacion = cabeceraRow.MONEDA_COTIZACION;
                        string monedaSimbolo = MonedasService.GetSimbolo(cabeceraRow.MONEDA_ID);
                        string monedaCadenaFormato = MonedasService.CadenaDecimales2(cabeceraRow.MONEDA_ID);
                        int monedaCantidadDecimales = MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID);

                        // Se calculan los totales de los detalles
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            totalDocumentos += (decimal)dtDetalles.Rows[i][DescuentoDocumentosDetalleService.Monto_NombreCol];
                            totalComision += (decimal)dtDetalles.Rows[i][DescuentoDocumentosDetalleService.MontoComision_NombreCol];
                        }

                        // Se dolarizan los totales de documentos y comision
                        totalDocumentosUSD += totalDocumentos / monedaCotizacion;
                        totalComisionUSD += totalComision / monedaCotizacion;

                        // Se calculan los totales de los pagos
                        for (int i = 0; i < dtPagos.Rows.Count; i++)
                        {
                            // Se verifica si la moneda es uniforme en todos los pagos
                            if (i == 0)
                            {
                                monedaPagoUniforme = (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.MonedaId_NombreCol];
                            }
                            else if (!monedaPagoUniforme.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            {
                                if (monedaPagoUniforme != (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.MonedaId_NombreCol])
                                    monedaPagoUniforme = Definiciones.Error.Valor.EnteroPositivo;
                            }

                            totalPagado += (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.Monto_NombreCol];
                            totalPagadoUSD += (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.Monto_NombreCol] / (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.CotizacionMoneda_NombreCol];
                        }

                        // Se comparan los totales de detalles con los totales de pagos
                        if (cabeceraRow.MONEDA_ID == monedaPagoUniforme)
                        {
                            // Si la moneda de los detalles (que es siempre la de la cabecera del caso) es igual a la unica que se usa en pagos, se compara directo
                            if (Math.Round((totalDocumentos - totalComision), monedaCantidadDecimales) != Math.Round(totalPagado, monedaCantidadDecimales))
                            {
                                exito = false;
                                if (cabeceraRow.MONEDA_ID == Definiciones.Monedas.Guaranies)
                                    mensaje = "El total del pago que se recibirá es " + monedaSimbolo + " " + Math.Round(totalPagado, 0).ToString(monedaCadenaFormato) + " mientras que debería ser " + monedaSimbolo + " " + Math.Round((totalDocumentos - totalComision), 0).ToString(monedaCadenaFormato) + ".";
                                else
                                    mensaje = "El total del pago que se recibirá es " + monedaSimbolo + " " + Math.Round(totalPagado, 2).ToString(monedaCadenaFormato) + " mientras que debería ser " + monedaSimbolo + " " + Math.Round((totalDocumentos - totalComision), 2).ToString(monedaCadenaFormato) + ".";
                            }
                        }
                        else
                        {
                            // Si los pagos son en monedas variadas, se debe comparar el total de detalles dolarizado con el total de pagos dolarizado.
                            // Es decir, el dolar es la moneda referencia.
                            // Esto puede causar impresiciones en los pagos si la cotizacion de la cabecera no coincida con las cotizaciones de los pagos,
                            // porque estos fueron ingresados en otro dia o algo que implique que la cotizacion sea distinta a la de la cabecera.
                            if (Math.Round((totalDocumentosUSD - totalComisionUSD), 2) != Math.Round(totalPagadoUSD, 2))
                            {
                                exito = false;
                                if (cabeceraRow.MONEDA_ID == Definiciones.Monedas.Guaranies)
                                    mensaje = "El total del pago que se recibirá es " + monedaSimbolo + " " + Math.Round(totalPagadoUSD * monedaCotizacion, 0) + " mientras que debería ser " + monedaSimbolo + " " + Math.Round((totalDocumentosUSD - totalComisionUSD) * monedaCotizacion, 0) + ".";
                                else
                                    mensaje = "El total del pago que se recibirá es " + monedaSimbolo + " " + Math.Round(totalPagadoUSD * monedaCotizacion, 2) + " mientras que debería ser " + monedaSimbolo + " " + Math.Round((totalDocumentosUSD - totalComisionUSD) * monedaCotizacion, 2) + ".";
                            }
                        }

                        #region Se genera el numero de comprobante
                        if (exito && cabeceraRow.NRO_COMPROBANTE == null)
                        {
                            try
                            {
                                // Si tiene autonumeracion definida
                                if (!cabeceraRow.IsAUTONUMERACION_IDNull)
                                {
                                    cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, sesion);

                                    //Controlar que se logro asignar una numeracion
                                    if (cabeceraRow.NRO_COMPROBANTE.Equals(""))
                                    {
                                        exito = false;
                                        mensaje = "No se pudo asignar una numeración válida";
                                    }
                                }
                                // Si no tiene autonumeracion definida, se pide nro de comprobante.
                                else if (cabeceraRow.NRO_COMPROBANTE == null)
                                { 
                                    exito = false;
                                    mensaje = "Debe asignar un número de comprobante al caso, o seleccionar un talonario para que el sistema asigne un número.";
                                }
                            }
                            catch (Exception exp)
                            {
                                mensaje = exp.Message.ToString();
                                exito = false;
                            }
                        }
                        #endregion Se genera el numero de comprobante

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
                        //Los valores del detalle del caso son reingresados a traves de borrar los detalles.
                        exito = true;

                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            descuentoDocumentoDet.Borrar((decimal)dtDetalles.Rows[i][DescuentoDocumentosDetalleService.Id_NombreCol]);
                        }
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //Ninguna
                        exito = true;
                        revisarRequisitos = true;                        
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //Los pagos en retribución son creados e ingresados a la caja de tesorería.
                        exito = true;
                        revisarRequisitos = true;

                        System.Collections.Hashtable campos;
                        int ctacteValorId;

                        //Realizar acciones por cada tipo de valor
                        for (int i = 0; i < dtPagos.Rows.Count; i++)
                        {
                            campos = new System.Collections.Hashtable();
                            ctacteValorId = Convert.ToInt32(dtPagos.Rows[i][DescuentoDocumentosPagosService.CtacteValorId_NombreCol]);
                            CuentaCorrienteChequesRecibidosService ctacteChequeRecibido = new CuentaCorrienteChequesRecibidosService();
                            decimal valorCreado;

                            //Crear el valor y dar ingreso a la caja o cuenta bancaria
                            switch (ctacteValorId)
                            {
                                case Definiciones.CuentaCorrienteValores.Cheque:
                                    //Debe crearse el cheque y luego incluirse el pago
                                    campos = new System.Collections.Hashtable();
                                    campos.Add(CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol, dtPagos.Rows[i][DescuentoDocumentosPagosService.CotizacionMoneda_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.CtacteBancoId_NombreCol, dtPagos.Rows[i][DescuentoDocumentosPagosService.ChequeCtacteBancoId_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol, string.Empty);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.EsDiferido_NombreCol, dtPagos.Rows[i][DescuentoDocumentosPagosService.ChequeEsDiferido_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.FechaPosdatado_NombreCol, dtPagos.Rows[i][DescuentoDocumentosPagosService.ChequeFechaPostdatado_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.FechaVencimiento_NombreCol, dtPagos.Rows[i][DescuentoDocumentosPagosService.ChequeFechaVencimiento_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol, dtPagos.Rows[i][DescuentoDocumentosPagosService.MonedaId_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.Monto_NombreCol, dtPagos.Rows[i][DescuentoDocumentosPagosService.Monto_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.NombreBeneficiario_NombreCol, dtPagos.Rows[i][DescuentoDocumentosPagosService.ChequeNombreBeneficiario_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.NombreEmisor_NombreCol, dtPagos.Rows[i][DescuentoDocumentosPagosService.ChequeNombreEmisor_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.NumeroCheque_NombreCol, dtPagos.Rows[i][DescuentoDocumentosPagosService.ChequeNroCheque_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.NumeroCuenta_NombreCol, dtPagos.Rows[i][DescuentoDocumentosPagosService.ChequeNroCuenta_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.ChequeDeTerceros_NombreCol, Definiciones.SiNo.No);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.NumeroDocumentoEmisor_NombreCol, dtPagos.Rows[i][DescuentoDocumentosPagosService.ChequeDocumentoEmisor_NombreCol]);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.CasoCreadorId_NombreCol, cabeceraRow.CASO_ID);
                                    
                                    valorCreado = ctacteChequeRecibido.Guardar(campos, true, sesion);
                                    descuentoDocumentoPago.GuardarIdChequeCreado((decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.Id_NombreCol], valorCreado, sesion);

                                    //Se da ingreso a la caja de tesoreria
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(cabeceraRow.CTACTE_CAJA_TESORERIA_ID,
                                                                   Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS,
                                                                   string.Empty,
                                                                   cabeceraRow.ID,
                                                                   (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.Id_NombreCol],
                                                                   Definiciones.CuentaCorrienteValores.Cheque,
                                                                   valorCreado,
                                                                   (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.MonedaId_NombreCol],
                                                                   (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.CotizacionMoneda_NombreCol],
                                                                   (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.Monto_NombreCol],
                                                                   DateTime.Now,
                                                                   sesion);
                                    break;
                                case Definiciones.CuentaCorrienteValores.DepositoBancario:
                                    //Se da ingreso a la cuenta bancaria
                                    CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                        (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.DepositoCtacteBancariaId_NombreCol],
                                        Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS,
                                        cabeceraRow.CASO_ID,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        cabeceraRow.ID,
                                        (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.MonedaId_NombreCol],
                                        (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.Monto_NombreCol],
                                        (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.CotizacionMoneda_NombreCol],
                                        (DateTime)cabeceraRow.FECHA,
                                        "Caso " + cabeceraRow.CASO_ID + " de " + Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS) + " pasado al estado " + estado_destino + ".",
                                        null,
                                        null,
                                        false,
                                        sesion);
                                    break;

                                case Definiciones.CuentaCorrienteValores.Efectivo:
                                    //Se da ingreso a la caja de tesoreria
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(cabeceraRow.CTACTE_CAJA_TESORERIA_ID,
                                                                   Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS,
                                                                   string.Empty,
                                                                   cabeceraRow.ID,
                                                                   (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.Id_NombreCol],
                                                                   Definiciones.CuentaCorrienteValores.Efectivo,
                                                                   Definiciones.Error.Valor.EnteroPositivo,
                                                                   (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.MonedaId_NombreCol],
                                                                   (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.CotizacionMoneda_NombreCol],
                                                                   (decimal)dtPagos.Rows[i][DescuentoDocumentosPagosService.Monto_NombreCol],
                                                                   DateTime.Now,
                                                                   sesion);
                                    break;
                                case Definiciones.CuentaCorrienteValores.TransferenciaBancaria:
                                    //Ninguna accion
                                    break;
                                default: throw new Exception("Error. El tipo de valor indefinido.");
                            }
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
                        sesion.Db.DESCUENTO_DOCUMENTOSCollection.Update(cabeceraRow);
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
            DESCUENTO_DOCUMENTOSRow row = sesion.Db.DESCUENTO_DOCUMENTOSCollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE;
        }

        #endregion Implementacion de metodos abstract
        
        #region GetDescuentoDocumentosDataTable
        /// <summary>
        /// Gets the descuento documentos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetDescuentoDocumentosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESCUENTO_DOCUMENTOSCollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetDescuentoDocumentosDataTable2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESCUENTO_DOCUMENTOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetDescuentoDocumentosDataTable

        #region GetDescuentoDocumentosInfoCompleta
        /// <summary>
        /// Gets the descuento documentos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetDescuentoDocumentosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESC_DOCS_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetDescuentoDocumentosInfoCompleta2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESC_DOCS_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetDescuentoDocumentosInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                DESCUENTO_DOCUMENTOSRow row = new DESCUENTO_DOCUMENTOSRow();

                try
                {
                    SucursalesService sucursal = new SucursalesService();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[DescuentoDocumentosService.SucursalId_NombreCol].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("DESCUENTO_DOCUMENTOS_SQC");
                        
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador; 
                    }
                    else
                    {
                        row = sesion.Db.DESCUENTO_DOCUMENTOSCollection.GetByPrimaryKey((decimal)campos[DescuentoDocumentosService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    
                    if (row.SUCURSAL_ID.Equals(DBNull.Value) || row.SUCURSAL_ID != (decimal)campos[DescuentoDocumentosService.SucursalId_NombreCol])
                    {
                        if (SucursalesService.EstaActivo((decimal)(campos[DescuentoDocumentosService.SucursalId_NombreCol])))
                            row.SUCURSAL_ID = (decimal)campos[DescuentoDocumentosService.SucursalId_NombreCol];
                        else
                            throw new System.Exception("La sucursal se encuentra inactiva.");
                    }

                    if (campos.Contains(DescuentoDocumentosService.CtacteBancoId_NombreCol))
                    {
                        if (row.IsCTACTE_BANCO_IDNull || row.CTACTE_BANCO_ID != (decimal)campos[DescuentoDocumentosService.CtacteBancoId_NombreCol])
                        {
                            if (CuentaCorrienteBancosService.EstaActivo((decimal)(campos[DescuentoDocumentosService.CtacteBancoId_NombreCol])))
                                row.CTACTE_BANCO_ID = (decimal)campos[DescuentoDocumentosService.CtacteBancoId_NombreCol];
                            else
                                throw new System.Exception("El banco se encuentra inactivo.");
                        }
                    }
                    else
                    {
                        row.IsCTACTE_BANCO_IDNull = true;
                    }

                    if (campos.Contains(DescuentoDocumentosService.CtacteBancariaId_NombreCol))
                    {
                        if (row.IsCTACTE_BANCARIA_IDNull || row.CTACTE_BANCARIA_ID != (decimal)campos[DescuentoDocumentosService.CtacteBancariaId_NombreCol])
                        {
                            if (CuentaCorrienteCuentasBancariasService.EstaActivo((decimal)(campos[DescuentoDocumentosService.CtacteBancariaId_NombreCol])))
                                row.CTACTE_BANCARIA_ID = (decimal)campos[DescuentoDocumentosService.CtacteBancariaId_NombreCol];
                            else
                                throw new System.Exception("La cuenta bancaria se encuentra inactiva.");
                        }
                    }
                    else
                    {
                        row.IsCTACTE_BANCARIA_IDNull = true;
                    }

                    if (row.CTACTE_CAJA_TESORERIA_ID.Equals(DBNull.Value) || row.CTACTE_CAJA_TESORERIA_ID != (decimal)campos[DescuentoDocumentosService.CtacteCajaTesoreriaId_NombreCol])
                    {
                        if (CuentaCorrienteCajasTesoreriaService.EstaActivo((decimal)(campos[DescuentoDocumentosService.CtacteCajaTesoreriaId_NombreCol])))
                            row.CTACTE_CAJA_TESORERIA_ID = (decimal)campos[DescuentoDocumentosService.CtacteCajaTesoreriaId_NombreCol];
                        else
                            throw new System.Exception("La caja se encuentra inactiva.");
                    }
                    
                    row.FECHA = (DateTime)campos[DescuentoDocumentosService.Fecha_NombreCol];
                    row.OBSERVACION = (string)campos[DescuentoDocumentosService.Observacion_NombreCol];
                    row.NOMBRE_INSTITUCION = (string)campos[DescuentoDocumentosService.NombreInstitucion_NombreCol];
                    row.NRO_COMPROBANTE = (string)campos[DescuentoDocumentosService.NroComprobante_NombreCol];
                    row.MONEDA_ID = (decimal)campos[DescuentoDocumentosService.MonedaId_NombreCol];
                    row.MONEDA_COTIZACION = (decimal)campos[DescuentoDocumentosService.MonedaCotizacion_NombreCol];

                    if (campos.Contains(AutonumeracionId_NombreCol))
                    {
                        row.AUTONUMERACION_ID = (decimal)campos[DescuentoDocumentosService.AutonumeracionId_NombreCol];
                    }
                    else
                    {
                        row.IsAUTONUMERACION_IDNull = true;
                    }

                    if (insertarNuevo) sesion.Db.DESCUENTO_DOCUMENTOSCollection.Insert(row);
                    else sesion.Db.DESCUENTO_DOCUMENTOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
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
        /// Borrars the specified caso_id.
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
                    DESCUENTO_DOCUMENTOSRow cabecera = sesion.Db.DESCUENTO_DOCUMENTOSCollection.GetByCASO_ID(caso_id)[0];
                    DescuentoDocumentosDetalleService descuentoDocumentoDet = new DescuentoDocumentosDetalleService();
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
                        dtDetalles = descuentoDocumentoDet.GetDescuentoDocumentosDetalleDataTable(DescuentoDocumentosDetalleService.DescuentoDocumentosId_NombreCol + " = " + cabecera.ID, string.Empty);
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            descuentoDocumentoDet.Borrar((decimal)dtDetalles.Rows[i][DescuentoDocumentosDetalleService.Id_NombreCol]);
                        }

                        sesion.Db.DESCUENTO_DOCUMENTOSCollection.DeleteByCASO_ID(caso_id);
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
            get { return "DESCUENTO_DOCUMENTOS"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOSCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOSCollection.CASO_IDColumnName; }
        }
        public static string CtacteBancariaId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOSCollection.CTACTE_BANCARIA_IDColumnName; }
        }
        public static string CtacteBancoId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOSCollection.CTACTE_BANCO_IDColumnName; }
        }
        public static string CtacteCajaTesoreriaId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOSCollection.CTACTE_CAJA_TESORERIA_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOSCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOSCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOSCollection.MONEDA_IDColumnName; }
        }
        public static string MonedaCotizacion_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOSCollection.MONEDA_COTIZACIONColumnName; }
        }
        public static string NombreInstitucion_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOSCollection.NOMBRE_INSTITUCIONColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOSCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOSCollection.OBSERVACIONColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaCtacteBancariaNroCuenta_NombreCol
        {
            get { return DESC_DOCS_INFO_COMPLCollection.CTACTE_BANCARIA_NRO_CUENTAColumnName; }
        }
        public static string VistaCtacteBancoNombre_NombreCol
        {
            get { return DESC_DOCS_INFO_COMPLCollection.CTACTE_BANCO_NOMBREColumnName; }
        }
        public static string VistaCtacteBancoAbreviatura_NombreCol
        {
            get { return DESC_DOCS_INFO_COMPLCollection.CTACTE_BANCO_ABREVIATURAColumnName; }
        }
        public static string VistaCtacteCajaTesoreriaAbrev_NombreCol
        {
            get { return DESC_DOCS_INFO_COMPLCollection.CTACTE_CAJA_TESORERIA_ABREVColumnName; }
        }
        public static string VistaCtacteCajaTesoreriaNombre_NombreCol
        {
            get { return DESC_DOCS_INFO_COMPLCollection.CTACTE_CAJA_TESORERIA_NOMBREColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return DESC_DOCS_INFO_COMPLCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return DESC_DOCS_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return DESC_DOCS_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaMontoComisionDolarizado_NombreCol
        {
            get { return DESC_DOCS_INFO_COMPLCollection.MONTO_COMISION_DOLARIZADOColumnName; }
        }
        public static string VistaMontoDolarizado_NombreCol
        {
            get { return DESC_DOCS_INFO_COMPLCollection.MONTO_DOLARIZADOColumnName; }
        }
        public static string VistaMontoImpuestoDolarizado_NombreCol
        {
            get { return DESC_DOCS_INFO_COMPLCollection.MONTO_IMPUESTO_DOLARIZADOColumnName; }
        }
        public static string VistaOrdenPagoRespaldaCasoId_NombreCol
        {
            get { return DESC_DOCS_INFO_COMPLCollection.ORDEN_PAGO_RESPALDA_CASO_IDColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return DESC_DOCS_INFO_COMPLCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return DESC_DOCS_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaMontoEfectivoDolarizado_NombreCol
        {
            get { return DESC_DOCS_INFO_COMPLCollection.MONTO_EFECTIVO_DOLARIZADOColumnName; }
        }
        #endregion Accessors
    }
}
