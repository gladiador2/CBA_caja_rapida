#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.Common;


#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class TransferenciasCajasTesoreriaService : FlujosServiceBaseWorkaround
    {

        #region Implementacion de Metodos Heredados
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_TESORERIA;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var drCabecera = (DataRow)caso_cabecera;
            var drDetalle = (DataRow)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            if (!Interprete.EsNullODBNull(drCabecera[TransferenciasCajasTesoreriaService.SucursalDestinoId_NombreCol]))
                campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.SucursalRelacionada, drCabecera[TransferenciasCajasTesoreriaService.SucursalDestinoId_NombreCol]);
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

        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            TRANSFERENCIAS_TESORERIARow[] rows;
            rows = sesion.Db.TRANSFERENCIAS_TESORERIACollection.GetByCASO_ID(caso_id);
            if (rows.Length == 1)
                return rows[0].NRO_COMPROBANTE.ToString();
            else
                return string.Empty;
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
                    TRANSFERENCIAS_TESORERIARow TransferenciaRow = sesion.Db.TRANSFERENCIAS_TESORERIACollection.GetByCASO_ID(caso_id)[0];
                    TRANSFERENCIAS_TESORERIAS_DETRow[] detalleRows = sesion.Db.TRANSFERENCIAS_TESORERIAS_DETCollection.GetByTRANSFERENCIAS_ID(TransferenciaRow.ID);
                    // de borrador a anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        exito = true;
                        revisarRequisitos = true;
                    }
                    // de borrador a pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        if (TransferenciaRow.NRO_COMPROBANTE==null)
                        {
                            TransferenciaRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(TransferenciaRow.AUTONUMERACION_ID);
                        }
                        sesion.Db.TRANSFERENCIAS_TESORERIACollection.Update(TransferenciaRow);


                        exito = true;
                        revisarRequisitos = true;
                    }
                    //de pendiente a borrador
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                           estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {

                        exito = true;
                        revisarRequisitos = true;

                    }
                    //de pendiente a anulado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        
                        exito = true;
                        revisarRequisitos = true;
                    }
                    // de pendiente a aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        CuentaCorrienteChequesRecibidosService chequeRecibido = new CuentaCorrienteChequesRecibidosService();
                        decimal id_chequeRecibido = 0;
                        for (int i = 0; i < detalleRows.Length; i++)
                        {
                            if (detalleRows[i].CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Efectivo)
                            {
                                decimal saldo = CuentaCorrienteCajasTesoreriaService.SaldoEfectivoPorCaja(TransferenciaRow.CAJA_TESORERIA_ORIGEN_ID, detalleRows[i].MONEDA_ID, sesion);
                                if (detalleRows[i].MONTO <= saldo)
                                {
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(TransferenciaRow.CAJA_TESORERIA_ORIGEN_ID, Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_TESORERIA, string.Empty, detalleRows[i].TRANSFERENCIAS_ID, detalleRows[i].ID, detalleRows[i].CTACTE_VALOR_ID, Definiciones.Error.Valor.EnteroPositivo, detalleRows[i].MONEDA_ID, detalleRows[i].COTIZACION_MONEDA, detalleRows[i].MONTO, TransferenciaRow.FECHA, sesion);
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(TransferenciaRow.CAJA_TESORERIA_DESTINO_ID, Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_TESORERIA, string.Empty, detalleRows[i].TRANSFERENCIAS_ID, detalleRows[i].ID, detalleRows[i].CTACTE_VALOR_ID, Definiciones.Error.Valor.EnteroPositivo, detalleRows[i].MONEDA_ID, detalleRows[i].COTIZACION_MONEDA, detalleRows[i].MONTO, TransferenciaRow.FECHA, sesion);
                                }
                                else throw new NotImplementedException("Saldo Insuficiente en la caja");
                            }
                            else 
                            {
                                DataTable dt = CuentaCorrienteChequesRecibidosService.GetDataTable(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + detalleRows[i].CTACTE_CHEQUE_RECIBIDO_ID, string.Empty, sesion);
                                string estado = dt.Rows[0][CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol].ToString();
                                if (!(estado.Equals(Definiciones.CuentaCorrienteChequesEstados.Efectivizado) || estado.Equals(Definiciones.CuentaCorrienteChequesEstados.Depositado)))
                                {

                                    id_chequeRecibido = detalleRows[i].CTACTE_CHEQUE_RECIBIDO_ID;
                                    //chequeRecibido.UtilizadoPorFlujo(detalleRows[i].CTACTE_CHEQUE_RECIBIDO_ID, sesion);
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(TransferenciaRow.CAJA_TESORERIA_ORIGEN_ID, Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_TESORERIA, string.Empty, detalleRows[i].TRANSFERENCIAS_ID, detalleRows[i].ID, detalleRows[i].CTACTE_VALOR_ID, detalleRows[i].CTACTE_CHEQUE_RECIBIDO_ID, detalleRows[i].MONEDA_ID, detalleRows[i].COTIZACION_MONEDA, detalleRows[i].MONTO, TransferenciaRow.FECHA, sesion);
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(TransferenciaRow.CAJA_TESORERIA_DESTINO_ID, Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_TESORERIA, string.Empty, detalleRows[i].TRANSFERENCIAS_ID, detalleRows[i].ID, detalleRows[i].CTACTE_VALOR_ID, id_chequeRecibido, detalleRows[i].MONEDA_ID, detalleRows[i].COTIZACION_MONEDA, detalleRows[i].MONTO, TransferenciaRow.FECHA, sesion);
                                   
                                }
                                else
                                {
                                    throw new NotImplementedException("el cheque ya no esta disponible para esta transaccion");
                                }
                            }
                        }
                       
                        exito = true;
                        revisarRequisitos = true;

                    }

                    //Verificar si se cumplen los requisitos
                    if (exito && revisarRequisitos)
                    {
                        exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                    }

                    if (exito)
                    {
                        
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

        #region GetTransferenciaCajaTesoreriaDataTable
        public DataTable GetTransferenciaCajaTesoreriaDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRANSFERENCIAS_TESORERIACollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTransferenciaCajaTesoreriaDataTable

        #region GetTransferenciaCajaTesoreriaInfoCompleta
        /// <summary>
        /// Gets the transferencia caja tesoreria info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetTransferenciaCajaTesoreriaInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRANSFERENCIAS_TESO_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetTransferenciaCajaTesoreriaInfoCompleta

        #region GetTransferenciaCajaTesoreriaPorCaso


        /// <summary>
        /// Gets the transferencia caja tesoreria por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetTransferenciaCajaTesoreriaPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRANSFERENCIAS_TESORERIACollection.GetAsDataTable(StockTransferenciasService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetTransferenciaCajaTesoreriaPorCaso

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                TRANSFERENCIAS_TESORERIARow row = new TRANSFERENCIAS_TESORERIARow();
                try
                {
                    string valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("TRANSFERENCIAS_CAJAS_TESO_SQC");
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[SucursalOrigenId_NombreCol].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_TESORERIA.ToString()),
                                                             int.Parse(sesion.Usuario_Id.ToString()),
                                                             SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                       
                    }
                    else
                    {
                        row = sesion.Db.TRANSFERENCIAS_TESORERIACollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.FECHA = (DateTime)campos[TransferenciasCajasTesoreriaService.FechaId_NombreCol];

                    // a partir de este punto se asignan los valores
                    if (campos.Contains(SucursalOrigenId_NombreCol)) row.SUCURSAL_ORIGEN_ID = decimal.Parse(campos[SucursalOrigenId_NombreCol].ToString());
                    else throw new System.ArgumentException("La sucursal origen no puede ser nula");

                    if (campos.Contains(CajaTesoreriaOrigenId_NombreCol)) row.CAJA_TESORERIA_ORIGEN_ID = decimal.Parse(campos[CajaTesoreriaOrigenId_NombreCol].ToString());
                    else throw new System.ArgumentException("La caja de tesorería origen no puede ser nula");

                    if (campos.Contains(SucursalDestinoId_NombreCol)) row.SUCURSAL_DESTINO_ID = decimal.Parse(campos[SucursalDestinoId_NombreCol].ToString());
                    else throw new System.ArgumentException("La sucursal destino no puede ser nula");

                    if (campos.Contains(CajaTesoreriaDestinoId_NombreCol)) row.CAJA_TESORERIA_DESTINO_ID = decimal.Parse(campos[CajaTesoreriaDestinoId_NombreCol].ToString());
                    else throw new System.ArgumentException("La caja de tesorería destino no puede ser nula");

                    if (campos.Contains(AutonumeracionId_NombreCol)) row.AUTONUMERACION_ID = decimal.Parse(campos[AutonumeracionId_NombreCol].ToString());
                    else throw new System.ArgumentException("La autonumeracion no puede ser nula");


                    if (campos.Contains(NroComprobante_NombreCol)) row.NRO_COMPROBANTE = campos[NroComprobante_NombreCol].ToString();

                    if (campos.Contains(Observacion_NombreCol)) row.OBSERVACION = campos[Observacion_NombreCol].ToString();

                    if (insertarNuevo) sesion.Db.TRANSFERENCIAS_TESORERIACollection.Insert(row);
                    else sesion.Db.TRANSFERENCIAS_TESORERIACollection.Update(row);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

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
        public bool Borrar(decimal caso_id)
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
                    TRANSFERENCIAS_TESORERIARow cabecera = sesion.Db.TRANSFERENCIAS_TESORERIACollection.GetByCASO_ID(caso_id)[0];
                    TRANSFERENCIAS_TESORERIAS_DETRow[] detalles = sesion.Db.TRANSFERENCIAS_TESORERIAS_DETCollection.GetByTRANSFERENCIAS_ID(cabecera.ID);

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    if(exito && detalles.Length > 0)
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que posee detalles.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.TRANSFERENCIAS_TESORERIACollection.DeleteByCASO_ID(caso_id);
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

        #region RecalcularTotal
        /// <summary>
        /// Recalculars the total.
        /// </summary>
        /// <param name="movimiento_id">The movimiento_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void RecalcularTotal(decimal movimiento_id, SessionService sesion) 
        {
            
                
                    
                    //se obtiene la cabecera
                        TRANSFERENCIAS_TESORERIARow row = new TRANSFERENCIAS_TESORERIARow();
                        row = sesion.Db.TRANSFERENCIAS_TESORERIACollection.GetByPrimaryKey(movimiento_id);
                    
                    //se obtienen los detalles
                        TRANSFERENCIAS_TESORERIAS_DETRow[] detallesRow = sesion.Db.TRANSFERENCIAS_TESORERIAS_DETCollection.GetByTRANSFERENCIAS_ID(row.ID);

                    // se reinicia el total
                    row.TOTAL_DOLARIZADO = 0;
                    //si la cantidad de detalles es cero retorna
                    if (detallesRow.Length == 0) return;
                    for (int i = 0; i < detallesRow.Length; i++) 
                    {
                        row.TOTAL_DOLARIZADO += detallesRow[i].MONTO / detallesRow[i].COTIZACION_MONEDA;
                    }
                    sesion.Db.TRANSFERENCIAS_TESORERIACollection.Update(row);
                    

               
                        
        }
        #endregion RecalcularTotal

        #region Accessors
        #region Tablas
        public static string Nombre_Tabla
        {
            get { return "TRANSFERENCIAS_TESORERIA"; }
        }
        public static string Id_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIACollection.IDColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIACollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIACollection.CASO_IDColumnName; }
        }
        public static string SucursalOrigenId_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIACollection.SUCURSAL_ORIGEN_IDColumnName; }
        }
        public static string CajaTesoreriaDestinoId_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIACollection.CAJA_TESORERIA_DESTINO_IDColumnName; }
        }
        public static string SucursalDestinoId_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIACollection.SUCURSAL_DESTINO_IDColumnName; }
        }
        public static string CajaTesoreriaOrigenId_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIACollection.CAJA_TESORERIA_ORIGEN_IDColumnName; }
        }
        public static string FechaId_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIACollection.FECHAColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIACollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIACollection.OBSERVACIONColumnName; }
        }
        
        public static string TotalDolarizado_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIACollection.TOTAL_DOLARIZADOColumnName; }
        }
        
        #endregion Tablas

        #region Vistas
        public static string Nombre_Vista
        {
            get { return "TRANSFERENCIAS_TESO_INFO_COMPL"; }
        }
        public static string VistaCasoEstado_NombreCol
        {
            get { return TRANSFERENCIAS_TESO_INFO_COMPLCollection.CASO_ESTADOColumnName; }
        }
        public static string VistaSucursalOrigenNombre_NombreCol
        {
            get { return TRANSFERENCIAS_TESO_INFO_COMPLCollection.SUCURSAL_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaSucursalOrigenAbreviatura_NombreCol
        {
            get { return TRANSFERENCIAS_TESO_INFO_COMPLCollection.SUCURSAL_ORIGEN_NOMBREColumnName; }
        }
        
        public static string VistaCajaTesoreriaOrigenNombre_NombreCol
        {
            get { return TRANSFERENCIAS_TESO_INFO_COMPLCollection.CAJA_TESORERIA_ORIGEN_NOMBREColumnName; }
        }

        public static string VistaSucursalDestinoNombre_NombreCol
        {
            get { return TRANSFERENCIAS_TESO_INFO_COMPLCollection.SUCURSAL_DESTINO_NOMBREColumnName; }
        }
        public static string VistaSucursalDestinoAbreviatura_NombreCol
        {
            get { return TRANSFERENCIAS_TESO_INFO_COMPLCollection.SUCURSAL_DESTINO_NOMBREColumnName; }
        }

        public static string VistaCajaTesoreriaDestinoNombre_NombreCol
        {
            get { return TRANSFERENCIAS_TESO_INFO_COMPLCollection.CAJA_TESORERIA_DESTINO_NOMBREColumnName; }
        }

        public static string VistaEntidadNombre_NombreCol
        {
            get { return TRANSFERENCIAS_TESO_INFO_COMPLCollection.ENTIDAD_NOMBREColumnName; }
        }
        public static string VistaEntidadId_NombreCol
        {
            get { return TRANSFERENCIAS_TESO_INFO_COMPLCollection.ENTIDAD_IDColumnName; }
        }
        public static string VistaEntidadAbreviatura_NombreCol
        {
            get { return TRANSFERENCIAS_TESO_INFO_COMPLCollection.ENTIDAD_ABREVIATURAColumnName; }
        }
        public static string VistaOrdenPagoRespaldaCasoId_NombreCol
        {
            get { return TRANSFERENCIAS_TESO_INFO_COMPLCollection.ORDEN_PAGO_RESPALDA_CASO_IDColumnName; }
        }
        
        #endregion Vistas
        #endregion Accessors
    }
}




