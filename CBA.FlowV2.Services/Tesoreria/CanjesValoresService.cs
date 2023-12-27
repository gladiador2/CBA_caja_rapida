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
    public class CanjesValoresService : FlujosServiceBaseWorkaround
    {
        #region GetCasoID
        public static decimal GetCasoID(decimal canje_id)
        {
            using (SessionService sesion = new SessionService()) {
                CANJES_VALORESRow rows;
                rows = sesion.Db.CANJES_VALORESCollection.GetByPrimaryKey(canje_id);
                return rows.CASO_ID;                
            }
        }
        #endregion GetCasoID

        #region Implementacion de Metodos Heredados
        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            CANJES_VALORESRow[] rows;
            rows = sesion.Db.CANJES_VALORESCollection.GetByCASO_ID(caso_id);
            if (rows.Length > 0)
                return rows[0].NRO_COMPROBANTE.ToString();
            else
                return string.Empty;
        }

        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.CANJES_VALORES;
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
                mensaje = string.Empty;
                bool exito = false;
                bool revisarRequisitos = false;
                mensaje = "";
                try
                {
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    CANJES_VALORESRow cabeceraRow = sesion.Db.CANJES_VALORESCollection.GetByCASO_ID(caso_id)[0];
                    DataTable dtDetalles = CanjesValoresDetallesService.GetCanjesValoresDetalleDataTable(CanjesValoresDetallesService.CanjeValorId_NombreCol + " = " + cabeceraRow.ID, string.Empty);
                    DataTable dtValores = CanjesValoresValoresService.GetCanjesValoresValoresDataTable(CanjesValoresValoresService.CanjeValorId_NombreCol + " = " + cabeceraRow.ID, string.Empty);
                    
                    // de borrador a anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Regresar el estado de los cheques al que era antes de ParaCanje

                        exito = true;
                        revisarRequisitos = true;

                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            CanjesValoresDetallesService.Borrar((decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.Id_NombreCol]);
                        }
                    }
                    // de borrador a pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //Controlar que la suma dolarizada de detalles coincida con la de valores (redondeo a 2 decimales)
                        //Generar el numero de comprobante si no estaba definido
                        exito = true;
                        revisarRequisitos = true;

                        decimal sumaDetalles = 0, sumaValores = 0;

                        #region Verifizar suma dolarizada entre detalles y valores
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                            sumaDetalles += (decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.Monto_NombreCol] / (decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.CotizacionMoneda_NombreCol];

                        for (int i = 0; i < dtValores.Rows.Count; i++)
                            sumaValores += (decimal)dtValores.Rows[i][CanjesValoresValoresService.Monto_NombreCol] / (decimal)dtValores.Rows[i][CanjesValoresValoresService.CotizacionMoneda_NombreCol];

                        if (Math.Round(sumaDetalles) != Math.Round(sumaValores))
                        {
                            MonedasService moneda = new MonedasService(VariablesSistemaEntidadService.GetValorInt(CBA.FlowV2.Services.Base.Definiciones.VariablesDeSistema.MonedaBaseSistemaId));
                            exito = false;
                            mensaje = "La suma dolarizada de detalles es " + sumaDetalles.ToString(moneda.CadenaDecimales) +
                                      " mientras que la de valores es " + sumaValores.ToString(moneda.CadenaDecimales) + ".";
                        }
                        #endregion Verifizar suma dolarizada entre detalles y valores

                        if (cabeceraRow.NRO_COMPROBANTE == null)
                        {
                            cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID);
                        }

                    }
                    //de pendiente a borrador
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                           estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        //Acciones
                        //Controlar que la suma dolarizada de detalles coincida con la de valores (redondeo a 2 decimales)

                        exito = true;
                        revisarRequisitos = true;

                        
                    }
                    // de pendiente a aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //Controlar que la suma dolarizada de detalles coincida con la de valores (redondeo a 2 decimales)
                        //Dar salida a los detalles
                        //Dar entradas a los valores

                        exito = true;
                        revisarRequisitos = true;

                        CuentaCorrienteChequesRecibidosService chequeRecibido = new CuentaCorrienteChequesRecibidosService();
                        decimal idChequeRecibido = 0;
                        decimal saldoExistente;
                        int ctacteValorId;
                        decimal sumaDetalles = 0, sumaValores = 0;

                        #region Verifizar suma dolarizada entre detalles y valores
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                            sumaDetalles += (decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.Monto_NombreCol] / (decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.CotizacionMoneda_NombreCol];

                        for (int i = 0; i < dtValores.Rows.Count; i++)
                            sumaValores += (decimal)dtValores.Rows[i][CanjesValoresValoresService.Monto_NombreCol] / (decimal)dtValores.Rows[i][CanjesValoresValoresService.CotizacionMoneda_NombreCol];

                        if (Math.Round(sumaDetalles) != Math.Round(sumaValores))
                        {
                            exito = false;
                            mensaje = "La suma dolarizada de detalles es " + sumaDetalles.ToString(MonedasService.CadenaDecimales2(Definiciones.Monedas.Dolares)) +
                                      " mientras que la de valores es " + sumaValores.ToString(MonedasService.CadenaDecimales2(Definiciones.Monedas.Dolares)) + ".";
                        }
                        #endregion Verifizar suma dolarizada entre detalles y valores

                        if (exito)
                        {
                            #region Dar salida a valores
                            for (int i = 0; i < dtDetalles.Rows.Count; i++)
                            {
                                ctacteValorId = int.Parse(dtDetalles.Rows[i][CanjesValoresDetallesService.CtacteValorId_NombreCol].ToString());
                                switch (ctacteValorId)
                                {
                                    case Definiciones.CuentaCorrienteValores.Efectivo:
                                        saldoExistente = CuentaCorrienteCajasTesoreriaService.SaldoEfectivoPorCaja(cabeceraRow.CTACTE_CAJA_TESORERIA_ID, (decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.MonedaId_NombreCol], sesion);
                                        if ((decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.Monto_NombreCol] <= saldoExistente)
                                            CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(cabeceraRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.CANJES_VALORES, string.Empty, cabeceraRow.ID, (decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.Id_NombreCol], Definiciones.CuentaCorrienteValores.Efectivo, Definiciones.Error.Valor.EnteroPositivo, (decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.CotizacionMoneda_NombreCol], (decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.MonedaId_NombreCol], DateTime.Now, sesion);
                                        else
                                            throw new NotImplementedException("Saldo Insuficiente en la caja");

                                        break;
                                    case Definiciones.CuentaCorrienteValores.Cheque:
                                        DataTable dt = CuentaCorrienteChequesRecibidosService.GetDataTable(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + dtDetalles.Rows[i][CanjesValoresDetallesService.CtacteChequeRecibidoId_NombreCol], string.Empty, sesion);

                                        //chequeRecibido.UtilizadoPorFlujo((decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.CtacteChequeRecibidoId_NombreCol], sesion);
                                        CuentaCorrienteChequesRecibidosService.CambiarEstado((decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.CtacteChequeRecibidoId_NombreCol], casoRow.ID, Definiciones.CuentaCorrienteChequesEstados.Canjeado, sesion, false, Definiciones.Error.Valor.EnteroPositivo);

                                        CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(cabeceraRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.CANJES_VALORES, string.Empty, cabeceraRow.ID, (decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.Id_NombreCol], Definiciones.CuentaCorrienteValores.Cheque, (decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.CtacteChequeRecibidoId_NombreCol], (decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.CotizacionMoneda_NombreCol], (decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.Monto_NombreCol], DateTime.Now, sesion);
                                        
                                        break;
                                    default: throw new Exception("Error en CanjesValoresService.ProcesarCambioEstado(). No está implementada la salida del tipo de valor del detalle.");
                                }
                            }
                            #endregion Dar salida a valores

                            #region Dar entrada a valores
                            for (int i = 0; i < dtValores.Rows.Count; i++)
                            {
                                ctacteValorId = int.Parse(dtValores.Rows[i][CanjesValoresValoresService.CtacteValorId_NombreCol].ToString());
                                switch (ctacteValorId)
                                {
                                    case Definiciones.CuentaCorrienteValores.Efectivo:
                                        CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(cabeceraRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.CANJES_VALORES, string.Empty, cabeceraRow.ID, (decimal)dtValores.Rows[i][CanjesValoresValoresService.Id_NombreCol], Definiciones.CuentaCorrienteValores.Efectivo, Definiciones.Error.Valor.EnteroPositivo, (decimal)dtValores.Rows[i][CanjesValoresValoresService.MonedaId_NombreCol], (decimal)dtValores.Rows[i][CanjesValoresValoresService.CotizacionMoneda_NombreCol], (decimal)dtValores.Rows[i][CanjesValoresValoresService.Monto_NombreCol], DateTime.Now, sesion);

                                        break;
                                    case Definiciones.CuentaCorrienteValores.Cheque:
                                        System.Collections.Hashtable campos = new System.Collections.Hashtable();
                                        campos.Add(CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol, dtValores.Rows[i][CanjesValoresValoresService.CotizacionMoneda_NombreCol]);
                                        campos.Add(CuentaCorrienteChequesRecibidosService.CtacteBancoId_NombreCol, dtValores.Rows[i][CanjesValoresValoresService.CtacteBancoId_NombreCol]);
                                        campos.Add(CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol, string.Empty);
                                        campos.Add(CuentaCorrienteChequesRecibidosService.FechaCreacion_NombreCol, dtValores.Rows[i][CanjesValoresValoresService.FechaCreacion_NombreCol]);
                                        campos.Add(CuentaCorrienteChequesRecibidosService.EsDiferido_NombreCol, dtValores.Rows[i][CanjesValoresValoresService.EsDiferido_NombreCol]);
                                        campos.Add(CuentaCorrienteChequesRecibidosService.FechaPosdatado_NombreCol, dtValores.Rows[i][CanjesValoresValoresService.FechaPosdatado_NombreCol]);
                                        campos.Add(CuentaCorrienteChequesRecibidosService.FechaVencimiento_NombreCol, dtValores.Rows[i][CanjesValoresValoresService.FechaVencimiento_NombreCol]);
                                        campos.Add(CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol, dtValores.Rows[i][CanjesValoresValoresService.MonedaId_NombreCol]);
                                        campos.Add(CuentaCorrienteChequesRecibidosService.Monto_NombreCol, dtValores.Rows[i][CanjesValoresValoresService.Monto_NombreCol]);
                                        campos.Add(CuentaCorrienteChequesRecibidosService.NombreBeneficiario_NombreCol, dtValores.Rows[i][CanjesValoresValoresService.NombreBeneficiario_NombreCol]);
                                        campos.Add(CuentaCorrienteChequesRecibidosService.NombreEmisor_NombreCol, dtValores.Rows[i][CanjesValoresValoresService.NombreEmisor_NombreCol]);
                                        campos.Add(CuentaCorrienteChequesRecibidosService.NumeroCheque_NombreCol, dtValores.Rows[i][CanjesValoresValoresService.NumeroCheque_NombreCol]);
                                        campos.Add(CuentaCorrienteChequesRecibidosService.NumeroCuenta_NombreCol, dtValores.Rows[i][CanjesValoresValoresService.NumeroCuenta_NombreCol]);
                                        campos.Add(CuentaCorrienteChequesRecibidosService.NumeroDocumentoEmisor_NombreCol, dtValores.Rows[i][CanjesValoresValoresService.NumeroDocumentoEmisor_NombreCol].Equals(DBNull.Value) ? string.Empty : dtValores.Rows[i][CanjesValoresValoresService.NumeroDocumentoEmisor_NombreCol]);
                                        campos.Add(CuentaCorrienteChequesRecibidosService.ChequeDeTerceros_NombreCol, dtValores.Rows[i][CanjesValoresValoresService.ChequeDeTerceros_NombreCol]);
                                        campos.Add(CuentaCorrienteChequesRecibidosService.CasoCreadorId_NombreCol, casoRow.ID);
                                        idChequeRecibido = chequeRecibido.Guardar(campos, true, sesion);

                                        CanjesValoresValoresService.SetIdChequeCreado((decimal)dtValores.Rows[i][CanjesValoresValoresService.Id_NombreCol], idChequeRecibido, sesion);
                                        CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(cabeceraRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.CANJES_VALORES, string.Empty, cabeceraRow.ID, (decimal)dtValores.Rows[i][CanjesValoresValoresService.Id_NombreCol], Definiciones.CuentaCorrienteValores.Cheque, idChequeRecibido, (decimal)dtValores.Rows[i][CanjesValoresValoresService.MonedaId_NombreCol], (decimal)dtValores.Rows[i][CanjesValoresValoresService.CotizacionMoneda_NombreCol], (decimal)dtValores.Rows[i][CanjesValoresValoresService.Monto_NombreCol], DateTime.Now, sesion);

                                        break;
                                    default: throw new Exception("Error en CanjesValoresService.ProcesarCambioEstado(). No está implementada la entrada del tipo de valor.");
                                }
                            }
                            #endregion Dar entrada a valores
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
                        sesion.Db.CANJES_VALORESCollection.Update(cabeceraRow);
                    }
         
                    return exito;

                }
                catch (Exception exp)
                {
                    exito = false;
                    throw exp;
                }
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza acciones necesarias una vez que se efectuo el cambio de estado
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion) { }

        #endregion Implementacion de Metodos Heredados

        #region GetCanjesValoresDataTable
        /// <summary>
        /// Gets the canjes valores data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCanjesValoresDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;
                dt = sesion.Db.CANJES_VALORESCollection.GetAsDataTable(clausula, orden);

                return dt;
            }
        }
        #endregion GetCanjesValoresDataTable

        #region GetCanjesValoresInfoCompleta
        /// <summary>
        /// Gets the canjes valores info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCanjesValoresInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;

                dt = sesion.Db.CANJES_VALORES_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);

          
                return dt;
            }
        }
        #endregion GetCanjesValoresInfoCompleta

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CANJES_VALORESRow row = new CANJES_VALORESRow();
                try
                {
                    string valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("canjes_valores_sqc");
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[CanjesValoresService.SucursalId_NombreCol].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.CANJES_VALORES.ToString()),
                                                             int.Parse(sesion.Usuario_Id.ToString()),
                                                             SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.SUCURSAL_ID = (decimal)campos[CanjesValoresService.SucursalId_NombreCol];
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                        row.FECHA = DateTime.Now;
                    }
                    else
                    {
                        row = sesion.Db.CANJES_VALORESCollection.GetByPrimaryKey((decimal)campos[CanjesValoresService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    if(row.CTACTE_CAJA_TESORERIA_ID != (decimal)campos[CanjesValoresService.CtacteCajaTesoreriaId_NombreCol])
                    {
                        row.CTACTE_CAJA_TESORERIA_ID = (decimal)campos[CanjesValoresService.CtacteCajaTesoreriaId_NombreCol];
                        if(!CuentaCorrienteCajasTesoreriaService.EstaActivo(row.CTACTE_CAJA_TESORERIA_ID))
                            throw new Exception("La caja de tesorería no está activa.");
                    }

                    if (row.PERSONA_ID != (decimal)campos[CanjesValoresService.PersonaId_NombreCol])
                    {
                        DataTable dtDetalles = CanjesValoresDetallesService.GetCanjesValoresDetalleDataTable(CanjesValoresDetallesService.CanjeValorId_NombreCol + " = " + row.ID, string.Empty);
                        if (dtDetalles.Rows.Count > 0)
                            throw new Exception("No puede modificar la persona debido a que existen detalles cargados.");

                        row.PERSONA_ID = (decimal)campos[CanjesValoresService.PersonaId_NombreCol];
                        if (!PersonasService.EstaActivo(row.PERSONA_ID))
                            throw new Exception("La persona no está activa.");
                    }

                    if(row.AUTONUMERACION_ID != (decimal)campos[CanjesValoresService.AutonumeracionId_NombreCol])
                    {
                        row.AUTONUMERACION_ID = (decimal)campos[CanjesValoresService.AutonumeracionId_NombreCol];
                        if(!AutonumeracionesService.EstaActivo(row.AUTONUMERACION_ID))
                            throw new Exception("El talonario no está activo.");
                    }

                    row.FECHA = (DateTime)campos[CanjesValoresService.Fecha_NombreCol];
                    row.NRO_COMPROBANTE = (string)campos[CanjesValoresService.NroComprobante_NombreCol];
                    row.OBSERVACION = (string)campos[CanjesValoresService.Observacion_NombreCol];

                    if (insertarNuevo) sesion.Db.CANJES_VALORESCollection.Insert(row);
                    else sesion.Db.CANJES_VALORESCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    return true;
                }
                catch (Exception)
                {
                    if (insertarNuevo && row.CASO_ID > 0)
                    {
                        (new CasosService()).Eliminar(row.CASO_ID, sesion);
                        caso_id = Definiciones.Error.Valor.EnteroPositivo;
                        estado_id = string.Empty;
                    }

                    throw;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borra de la base de datos el caso y la cabecera del flujo
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
                    string mensaje = string.Empty;

                    //Se obtienen el caso y la factura a ser borrados
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    CANJES_VALORESRow cabecera = sesion.Db.CANJES_VALORESCollection.GetByCASO_ID(caso_id)[0];
                    DataTable dtValores, dtDetalles;

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Borrar los detalles
                    dtDetalles = CanjesValoresDetallesService.GetCanjesValoresDetalleDataTable(CanjesValoresDetallesService.CanjeValorId_NombreCol + " = " + cabecera.ID, string.Empty);
                    for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        CanjesValoresDetallesService.Borrar((decimal)dtDetalles.Rows[i][CanjesValoresDetallesService.Id_NombreCol]);

                    //Borrar los valores
                    dtValores = CanjesValoresValoresService.GetCanjesValoresValoresDataTable(CanjesValoresValoresService.CanjeValorId_NombreCol + " = " + cabecera.ID, string.Empty);
                    for (int i = 0; i < dtValores.Rows.Count; i++)
                        CanjesValoresValoresService.Borrar((decimal)dtValores.Rows[i][CanjesValoresValoresService.Id_NombreCol]);
                    
                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.CANJES_VALORESCollection.DeleteByCASO_ID(caso_id);
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
            get { return "CANJES_VALORES"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return CANJES_VALORESCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return CANJES_VALORESCollection.CASO_IDColumnName; }
        }
        public static string CtacteCajaTesoreriaId_NombreCol
        {
            get { return CANJES_VALORESCollection.CTACTE_CAJA_TESORERIA_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CANJES_VALORESCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CANJES_VALORESCollection.IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return CANJES_VALORESCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CANJES_VALORESCollection.OBSERVACIONColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return CANJES_VALORESCollection.PERSONA_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CANJES_VALORESCollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return CANJES_VALORES_INFO_COMPLETACollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCtacteCajaTesoreriaNombre_NombreCol
        {
            get { return CANJES_VALORES_INFO_COMPLETACollection.CTACTE_CAJA_TESORERIA_NOMBREColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return CANJES_VALORES_INFO_COMPLETACollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return CANJES_VALORES_INFO_COMPLETACollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CANJES_VALORES_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaTotalDetallesDolarizado_NombreCol
        {
            get { return CANJES_VALORES_INFO_COMPLETACollection.TOTAL_DETALLES_DOLARIZADOColumnName; }
        }
        public static string VistaTotalValoresDolarizado_NombreCol
        {
            get { return CANJES_VALORES_INFO_COMPLETACollection.TOTAL_VALORES_DOLARIZADOColumnName; }
        }
        #endregion Accessors
    }
}