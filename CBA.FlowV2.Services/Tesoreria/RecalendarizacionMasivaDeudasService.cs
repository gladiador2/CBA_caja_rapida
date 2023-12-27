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
using CBA.FlowV2.Services.Facturacion;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class RecalendarizacionMasivaDeudasService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de Metodos Heredados
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.RECALENDARIZACION_MASIVA_DEUDAS;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);
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
                RECALENDARIZACION_MASIVARow cabeceraRow = sesion.Db.RECALENDARIZACION_MASIVACollection.GetByCASO_ID(caso_id)[0];
                RECALENDARIZACION_MAS_DETALLESRow[] detallesRows = sesion.Db.RECALENDARIZACION_MAS_DETALLESCollection.GetByRECALENDARIZACION_MASIVA_ID(cabeceraRow.ID);
               
                // de borrador a anulado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna
                    exito = true;
                    revisarRequisitos = true;
                }
                // de borrador a pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Se genera la numeracion a partir de la autonumeracion que haya indicado el usuario, si el 
                    //caso no tenia previamente un numero asignado
                    exito = true;
                    revisarRequisitos = true;

                    if (detallesRows.Length <= 0)
                    {
                        mensaje = "La recalendarización no tiene detalles.";
                        exito = false;
                    }

                    if (AutonumeracionesService.EsGeneracionManual(cabeceraRow.AUTONUMERACION_ID, sesion))
                    {
                        if (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Length == 0)
                            throw new Exception("Debe indicarse el número de comprobante");
                    }

                    #region Se genera el numero de comprobante
                    if (Interprete.EsNullODBNull(cabeceraRow.NRO_COMPROBANTE))
                    {
                        try
                        {
                            cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID);

                            //Controlar que se logro asignar una numeracion
                            if (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Length == 0)
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
                    #endregion Se genera el numero de comprobante
                }
                //de pendiente a borrador
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //Ninguna
                    exito = true;
                    revisarRequisitos = true;
                }
                // de pendiente a aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones
                    //Se verifica que las cuotas efectivamente estén pendientes de pago
                    //Se agrega dédito para saldar las deudas
                    //Se crean nuevos calendarios de pago y cuotas
                    //Se actualiza la fecha de vencimiento de la factura
                    //Se actualiza detalle asignando el caso de refinanciación
                    exito = true;
                    revisarRequisitos = true;

                    if (detallesRows.Length <= 0)
                    {
                        mensaje = "La recalendarización no tiene detalles.";
                        exito = false;
                    }

                    foreach (var detalle in detallesRows)
                    {
                        var cuotasRows = sesion.db.RECALENDARIZACION_MAS_CUOTASCollection.GetByRECAL_MASIVA_DET_ID(detalle.ID);
                        foreach (var cuotas in cuotasRows)
                        {
                            CuentaCorrientePersonasService cuentaCorriente = new CuentaCorrientePersonasService(CuentaCorrientePersonasService.CalendarioPagoFcCliId_NombreCol, cuotas.CAL_PAGO_CLI_FC_ORIGINAL_ID, sesion);

                            if (cuentaCorriente.Estado != Definiciones.Estado.Activo || cuentaCorriente.Credito == cuentaCorriente.Debito )
                                throw new Exception("Favor verificar el detalle caso factura nro: " + detalle.CASO_FACTURA_ID + ", sin deudas.");

                            decimal[] impuestoId, monto;
                            decimal saldo = cuentaCorriente.Credito - cuentaCorriente.Debito;
                            decimal proporcion = saldo / cuentaCorriente.Credito;

                            #region Calcular monto por tipo de impuesto
                            Hashtable montoPorImpuesto = new Hashtable();
                            DataTable dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable(cuentaCorriente.Id.Value, sesion);

                            for (int j = 0; j < dtCtactePersonaDet.Rows.Count; j++)
                            {
                                if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                                    montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + (decimal)dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol] * proporcion;
                                else
                                    montoPorImpuesto.Add(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], (decimal)dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol] * proporcion);
                            }

                            impuestoId = new decimal[montoPorImpuesto.Count];
                            monto = new decimal[montoPorImpuesto.Count];

                            int indiceAux = 0;
                            decimal montoVerificacion = 0;
                            foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                            {
                                impuestoId[indiceAux] = (decimal)par.Key;
                                monto[indiceAux] = (decimal)par.Value;

                                montoVerificacion += monto[indiceAux];

                                indiceAux++;
                            }

                            if (Math.Round(saldo, cuentaCorriente.Moneda.CantidadDecimales) != Math.Round(montoVerificacion, cuentaCorriente.Moneda.CantidadDecimales))
                                throw new Exception("El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el saldo es de " + saldo + ".");
                            #endregion Calcular monto por tipo de impuesto

                            //Ingresar el debito
                            CuentaCorrientePersonasService.AgregarDebito(cuentaCorriente.PersonaId,
                                                        cuentaCorriente.Id.Value,
                                                        Definiciones.CuentaCorrienteConceptos.DebitoPorPago,
                                                        Definiciones.CuentaCorrienteValores.Efectivo, //Se agrega efectivo por completar el dato simplemente
                                                        cabeceraRow.CASO_ID,
                                                        cuentaCorriente.MonedaId,
                                                        cuentaCorriente.CotizacionMoneda,
                                                        impuestoId,
                                                        monto,
                                                        string.Empty,
                                                        cabeceraRow.FECHA,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        sesion);

                            //Se desbloquea la cuota pagada
                            CuentaCorrientePersonasService.SetBloqueado(cuentaCorriente.Id.Value, false, sesion);

                            #region agregar cuota a calendario
                            Hashtable campos = new Hashtable();
                            var calendario = sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.GetByPrimaryKey(cuotas.CAL_PAGO_CLI_FC_ORIGINAL_ID);
                            campos.Add(CalendarioPagosFCClienteService.FacturaClienteId_NombreCol, calendario.FACTURA_CLIENTE_ID);
                            campos.Add(CalendarioPagosFCClienteService.MontoCapital_NombreCol, saldo);
                            campos.Add(CalendarioPagosFCClienteService.MontoInteres_NombreCol, 0);
                            campos.Add(CalendarioPagosFCClienteService.NumeroCuota_NombreCol, cuentaCorriente.CuotaNumero.Value);
                            campos.Add(CalendarioPagosFCClienteService.FechaVencimiento_NombreCol, cuotas.NUEVO_VENCIMIENTO);

                            decimal cuotaNuevaId = CalendarioPagosFCClienteService.Guardar(campos, sesion);
                            #endregion agregar cuota a calendario

                            //se setea calendario nuevo de pago
                            RecalendarizacionMasivaDeudasCuotasService.AsignarNuevaCuotaId(cuotas.ID, cuotaNuevaId, sesion);

                            // se actualiza el vencimiento de la factura
                            FacturasClienteService.ActualizarFechaVencimiento(calendario.FACTURA_CLIENTE_ID, cuotas.NUEVO_VENCIMIENTO, false, false, sesion);

                            #region Agregar la cuota a la cuenta corriente
                            CuentaCorrientePersonasService.AgregarCredito(cuentaCorriente.PersonaId,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                                cabeceraRow.CASO_ID,
                                                                cuentaCorriente.MonedaId,
                                                                cuentaCorriente.CotizacionMoneda,
                                                                impuestoId,
                                                                monto,
                                                                string.Empty,
                                                                cuotas.NUEVO_VENCIMIENTO,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                cuotaNuevaId,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                cuentaCorriente.CuotaNumero.Value,
                                                                cuentaCorriente.CuotaTotal.Value,
                                                                sesion);
                            #endregion Agregar la cuota a la cuenta corriente
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
                    sesion.Db.RECALENDARIZACION_MASIVACollection.Update(cabeceraRow);
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

        #region GetRecalendarizacionDeudasDataTable
        public static DataTable GetRecalendarizacionDeudasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetRecalendarizacionDeudasDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetRecalendarizacionDeudasDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.RECALENDARIZACION_MASIVACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetRecalendarizacionDeudasDataTable

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                RECALENDARIZACION_MASIVARow row = new RECALENDARIZACION_MASIVARow();
                try
                {

                    if (!campos.Contains(Fecha_NombreCol))
                        throw new Exception("Debe indicar la fecha.");

                    if (!campos.Contains(SucursalId_NombreCol))
                        throw new Exception("Debe indicar la sucursal.");

                    if (!campos.Contains(AutonumeracionId_NombreCol))
                        throw new Exception("Debe indicar el talonario."); 
                    
                    string valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("recalendarizacion_masiva_sqc");
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[SucursalId_NombreCol].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.RECALENDARIZACION_MASIVA_DEUDAS.ToString()),
                                                             int.Parse(sesion.Usuario_Id.ToString()),
                                                             SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        caso_id = row.CASO_ID;
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                        row.FECHA = DateTime.Now;
                    }
                    else
                    {
                        row = sesion.Db.RECALENDARIZACION_MASIVACollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.FECHA = (DateTime)campos[Fecha_NombreCol];
                    row.SUCURSAL_ID = (decimal)campos[SucursalId_NombreCol];

                    if (campos.Contains(AutonumeracionId_NombreCol))
                        row.AUTONUMERACION_ID = (decimal)campos[AutonumeracionId_NombreCol];

                    if (AutonumeracionesService.EstaActivo((decimal)campos[AutonumeracionId_NombreCol]))
                        row.AUTONUMERACION_ID = (decimal)campos[AutonumeracionId_NombreCol];
                    else
                        throw new Exception("El talonario deseado está inactivo.");

                    if (campos.Contains(NroComprobante_NombreCol))
                        row.NRO_COMPROBANTE = (string)campos[NroComprobante_NombreCol];

                    if (insertarNuevo) sesion.Db.RECALENDARIZACION_MASIVACollection.Insert(row);
                    else sesion.Db.RECALENDARIZACION_MASIVACollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    return row.ID;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion Guardar
        
        #region Borrar
        public static bool Borrar(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    bool exito = true;
                    String mensaje = "Error.";

                    //Se obtienen el caso y la recalendarizacion a ser borrados
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    RECALENDARIZACION_MASIVARow cabeceraRow = sesion.Db.RECALENDARIZACION_MASIVACollection.GetByCASO_ID(caso_id)[0];
               
                    if (!casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Se obtienen los detalles del caso a ser borrados.
                    RECALENDARIZACION_MAS_DETALLESRow[] detallesRows = sesion.Db.RECALENDARIZACION_MAS_DETALLESCollection.GetByRECALENDARIZACION_MASIVA_ID(cabeceraRow.ID);

                    //Si el caso posee detalles no puede ser borrado
                    if (detallesRows.Length > 0)
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que posee detalles.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.RECALENDARIZACION_MASIVACollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, cabeceraRow.ID, cabeceraRow.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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
            get { return "RECALENDARIZACION_MASIVA"; }
        }
        public static string Id_NombreCol
        {
            get { return RECALENDARIZACION_MASIVACollection.IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return RECALENDARIZACION_MASIVACollection.CASO_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return RECALENDARIZACION_MASIVACollection.FECHAColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return RECALENDARIZACION_MASIVACollection.SUCURSAL_IDColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return RECALENDARIZACION_MASIVACollection.AUTONUMERACION_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return RECALENDARIZACION_MASIVACollection.NRO_COMPROBANTEColumnName; }
        }
        #endregion Tabla
        #endregion Accessors
    }
}