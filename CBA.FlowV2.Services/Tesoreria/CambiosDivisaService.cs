using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using System.Collections;
using System.Collections.Generic;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CambiosDivisaService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.CUSTODIA_DE_VALORES;
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
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    CAMBIOS_DIVISARow cabeceraRow = sesion.Db.CAMBIOS_DIVISACollection.GetByCASO_ID(caso_id)[0];
                    DataTable dtDetalles = (new CambiosDivisaDetalleService()).GetCambiosDivisaDetalleInfoCompleta(CambiosDivisaDetalleService.CambioDivisaId_NombreCol + " = " + cabeceraRow.ID, string.Empty);

                    //Borrador a Anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Los valores a ser cambiados son devueltos a la caja de tesoreria.
                        exito = true;
                        revisarRequisitos = true;
    
                        //Se reingresa cada valor
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.CAMBIO_DIVISA, string.Empty, (decimal)dtDetalles.Rows[i][CambiosDivisaDetalleService.Id_NombreCol], casoRow.ID, sesion);
                        }
                    }
                    //Borrador a Pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;

                        #region Se genera el numero de comprobante
                        if (exito && cabeceraRow.NRO_COMPROBANTE == null)
                        {
                            try
                            {
                                cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, sesion);

                                //Controlar que se logro asignar una numeracion
                                if (cabeceraRow.NRO_COMPROBANTE.Equals(""))
                                {
                                    exito = false;
                                    mensaje = "No se pudo asignar una numeración válida.";
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
                    //Pendiente a Borrador 
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        //Acciones
                        //se verifica que no haya una orden de pago respaldando el caso.
                        exito = true;

                        //Controlar si existe una OP respaldando al caso
                        string clausulas = CambiosDivisaService.Id_NombreCol + " = " + cabeceraRow.ID;
                        DataTable dtCambioDivisa = (new CambiosDivisaService().GetCambiosDivisaInfoCompleta(clausulas, string.Empty));

                        if (!dtCambioDivisa.Rows[0][CambiosDivisaService.VistaOrdenPagoCasoId_NombreCol].Equals(DBNull.Value))
                        {
                            exito = false;
                            mensaje = "No se puede devolver a Borrador el caso ya que la Orden de Pago caso " + 
                                      dtCambioDivisa.Rows[0][CambiosDivisaService.VistaOrdenPagoCasoId_NombreCol] + 
                                      " se encuentra respaldándolo.";
                        }

                    }
                    //Pendiente a Anulado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Los valores a ser cambiados son devueltos a la caja de tesoreria.
                        //No se puede utilizar la transicion si existe una Orden de Pago que relaciona al caso.
                        exito = true;
                        revisarRequisitos = true;

                        //Controlar si existe una OP respaldando al caso
                        string clausulas = CambiosDivisaService.Id_NombreCol + " = " + cabeceraRow.ID;
                        DataTable dtCambioDivisa = (new CambiosDivisaService().GetCambiosDivisaInfoCompleta(clausulas, string.Empty));

                        if (!dtCambioDivisa.Rows[0][CambiosDivisaService.VistaOrdenPagoCasoId_NombreCol].Equals(DBNull.Value))
                        {
                            exito = false;
                            mensaje = "No se puede devolver a Borrador el caso ya que la Orden de Pago caso " +
                                      dtCambioDivisa.Rows[0][CambiosDivisaService.VistaOrdenPagoCasoId_NombreCol] +
                                      " se encuentra respaldándolo.";
                        }

                        //Se reingresa cada valor
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.CAMBIO_DIVISA, string.Empty, (decimal)dtDetalles.Rows[i][CambiosDivisaDetalleService.Id_NombreCol], casoRow.ID, sesion);
                        }
                    }
                    //Pendiente a Aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //Los valores cambiados ingresan a la caja de tesoreria.
                        //Si el monto total dolarizado supera el limite, el caso debe ser respaldado por una Orden de Pago
                        exito = true;
                        revisarRequisitos = true;

                        decimal montoDolarizadoNecesitaRespaldo = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.CambiosDivisaMaximoDolaresSinOrdenPago);

                        //Controlar si el caso necesita una OP que lo respalde
                        if (montoDolarizadoNecesitaRespaldo <= cabeceraRow.TOTAL_DOLARIZADO)
                        { 
                            //Controlar si existe una OP respaldando al caso
                            string clausulas = CambiosDivisaService.Id_NombreCol + " = " + cabeceraRow.ID;
                            DataTable dtCambioDivisa = (new CambiosDivisaService().GetCambiosDivisaInfoCompleta(clausulas, string.Empty));
                            decimal caso_orden_pago;

                            //Obtener el caso de OP
                            if (!dtCambioDivisa.Rows[0][CambiosDivisaService.VistaOrdenPagoCasoId_NombreCol].Equals(DBNull.Value))
                                caso_orden_pago = (decimal)dtCambioDivisa.Rows[0][CambiosDivisaService.VistaOrdenPagoCasoId_NombreCol];
                            else
                                throw new Exception("Cambios de Divisa con monto superior a los U$D " + montoDolarizadoNecesitaRespaldo + " deben ser respaldados por una Orden de Pago.");

                            //Verificar que la OP este cerrada
                            if (CasosService.GetEstadoCaso(caso_orden_pago) != Definiciones.EstadosFlujos.Cerrado)
                                throw new Exception("La Orden de Pago caso " + caso_orden_pago + " deben estar cerrada antes de poder aprobar el Cambio de Divisa.");
                        }

                        //Debe haberse ingresado el numero de comprobante
                        if(cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Equals(DBNull.Value))
                        {
                            exito = false;
                            mensaje = "Debe indicar el número de comprobante.";
                        }

                        if (exito)
                        {
                            for (int i = 0; i < dtDetalles.Rows.Count; i++)
                            {
                                CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(
                                      cabeceraRow.CTACTE_CAJA_TESORERIA_ID,
                                      Definiciones.FlujosIDs.CAMBIO_DIVISA,
                                      string.Empty,
                                      cabeceraRow.ID,
                                      (decimal)dtDetalles.Rows[i][CambiosDivisaDetalleService.Id_NombreCol],
                                      Definiciones.CuentaCorrienteValores.Efectivo,
                                      Definiciones.Error.Valor.EnteroPositivo,
                                      (decimal)dtDetalles.Rows[i][CambiosDivisaDetalleService.MonedaDestinoId_NombreCol],
                                      (decimal)dtDetalles.Rows[i][CambiosDivisaDetalleService.CotizacionMonedaDestino_NombreCol],
                                      (decimal)dtDetalles.Rows[i][CambiosDivisaDetalleService.MontoDestino_NombreCol],
                                      cabeceraRow.FECHA,
                                      sesion
                                   );
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
                        sesion.Db.CAMBIOS_DIVISACollection.Update(cabeceraRow);
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

        #endregion Implementacion de metodos abstract

        #region GetCambiosDivisaDataTable
        /// <summary>
        /// Gets the cambios divisa data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCambiosDivisaDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CAMBIOS_DIVISACollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCambiosDivisaDataTable

        #region GetCambiosDivisaInfoCompleta
        /// <summary>
        /// Gets the cambios divisa info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCambiosDivisaInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CAMBIOS_DIVISA_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCambiosDivisaInfoCompleta

        #region GetCambioDivisaPorCaso
        /// <summary>
        /// Gets the cambio divisa por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetCambioDivisaPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CAMBIOS_DIVISACollection.GetAsDataTable(CambiosDivisaService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetCambioDivisaPorCaso

        #region GetNumeroComprobante
        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            CAMBIOS_DIVISARow row = sesion.Db.CAMBIOS_DIVISACollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? string.Empty : row.NRO_COMPROBANTE;
        }
        #endregion GetNumeroComprobante

        #region CalcularTotales
        /// <summary>
        /// Calculars the totales.
        /// </summary>
        /// <param name="cambio_divisa_id">The cambio_divisa_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void CalcularTotales(decimal cambio_divisa_id, SessionService sesion)
        {
            DataTable dtCambioDivisaDet = (new CambiosDivisaDetalleService()).GetCambiosDivisaDetalleDataTable(CambiosDivisaDetalleService.CambioDivisaId_NombreCol + " = " + cambio_divisa_id, string.Empty, sesion);
            CAMBIOS_DIVISARow row = sesion.Db.CAMBIOS_DIVISACollection.GetByPrimaryKey(cambio_divisa_id);
            string valorAnterior = row.ToString();

            row.TOTAL_DOLARIZADO = 0;
            
            for (int i = 0; i < dtCambioDivisaDet.Rows.Count; i++)
            {
                //Se suma al total el monto dolarizado
                row.TOTAL_DOLARIZADO += (decimal)dtCambioDivisaDet.Rows[i][CambiosDivisaDetalleService.MontoOrigen_NombreCol] /
                                        (decimal)dtCambioDivisaDet.Rows[i][CambiosDivisaDetalleService.CotizacionMonedaOrigen_NombreCol];
            }

            sesion.Db.CAMBIOS_DIVISACollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion CalcularTotales

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
                CAMBIOS_DIVISARow row = new CAMBIOS_DIVISARow();

                try
                {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[CambiosDivisaService.SucursalId_NombreCol].ToString()),
                                                              Definiciones.FlujosIDs.CAMBIO_DIVISA,
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("cambios_divisa_sqc");
                        row.SUCURSAL_ID = (decimal)campos[CambiosDivisaService.SucursalId_NombreCol]; //Una vez creado el caso no puede cambiarse de sucursal
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.CAMBIOS_DIVISACollection.GetRow(CambiosDivisaService.Id_NombreCol + " = " + campos[CambiosDivisaService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    //Se controla al crear el caso que la sucursal este activa
                    if(insertarNuevo)
                    {
                        if(!SucursalesService.EstaActivo(row.SUCURSAL_ID))
                            throw new Exception("La sucursal no se encuentra activa.");
                    }

                    //Si cambia
                    if (row.CTACTE_CAJA_TESORERIA_ID.Equals(DBNull.Value) || row.CTACTE_CAJA_TESORERIA_ID != (decimal)campos[CambiosDivisaService.CtacteCajaTesoreriaId_NombreCol])
                    {
                        if (!CuentaCorrienteCajasTesoreriaService.EstaActivo((decimal)campos[CambiosDivisaService.CtacteCajaTesoreriaId_NombreCol]))
                            throw new Exception("La caja de tesorería no se encuentra activa");

                        row.CTACTE_CAJA_TESORERIA_ID = (decimal)campos[CambiosDivisaService.CtacteCajaTesoreriaId_NombreCol];
                    }

                    row.FECHA = (DateTime)campos[CambiosDivisaService.Fecha_NombreCol];

                    //Si cambia
                    if (row.FUNCIONARIO_ID.Equals(DBNull.Value) || row.FUNCIONARIO_ID != (decimal)campos[CambiosDivisaService.FuncionarioId_NombreCol])
                    {
                        if (!FuncionariosService.EstaActivo((decimal)campos[CambiosDivisaService.FuncionarioId_NombreCol]))
                            throw new Exception("El funcionario no se encuentra activa");

                        row.FUNCIONARIO_ID = (decimal)campos[CambiosDivisaService.FuncionarioId_NombreCol];
                    }

                    row.NRO_COMPROBANTE = (string)campos[CambiosDivisaService.NroComprobante_NombreCol];
                    row.OBSERVACION = (string)campos[CambiosDivisaService.Observacion_NombreCol];

                    if (campos.Contains(Autonumeracion_ID_NombreCol))
                    {
                        row.AUTONUMERACION_ID = (decimal)campos[CambiosDivisaService.Autonumeracion_ID_NombreCol];
                    }
                    else
                    {
                        row.IsAUTONUMERACION_IDNull = true;
                    }
                    
                    if (insertarNuevo) sesion.Db.CAMBIOS_DIVISACollection.Insert(row);
                    else sesion.Db.CAMBIOS_DIVISACollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.FUNCIONARIO_ID);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    return true;
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
                    CAMBIOS_DIVISARow cabecera = sesion.Db.CAMBIOS_DIVISACollection.GetByCASO_ID(caso_id)[0];

                    if (! caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.CAMBIOS_DIVISACollection.DeleteByCASO_ID(caso_id);
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
            get { return "CAMBIOS_DIVISA"; }
        }
        public static string CasoId_NombreCol
        {
            get { return CAMBIOS_DIVISACollection.CASO_IDColumnName; }
        }
        public static string Autonumeracion_ID_NombreCol
        {
            get { return CAMBIOS_DIVISACollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CtacteCajaTesoreriaId_NombreCol
        {
            get { return CAMBIOS_DIVISACollection.CTACTE_CAJA_TESORERIA_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CAMBIOS_DIVISACollection.FECHAColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return CAMBIOS_DIVISACollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CAMBIOS_DIVISACollection.IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return CAMBIOS_DIVISACollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CAMBIOS_DIVISACollection.OBSERVACIONColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CAMBIOS_DIVISACollection.SUCURSAL_IDColumnName; }
        }
        public static string TotalDolarizado
        {
            get { return CAMBIOS_DIVISACollection.TOTAL_DOLARIZADOColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return CAMBIOS_DIVISA_INFO_COMPLETACollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCtacteCajaTesoreriaAbrev_NombreCol
        {
            get { return CAMBIOS_DIVISA_INFO_COMPLETACollection.CTACTE_CAJA_TESORERIA_ABREVColumnName; }
        }
        public static string VistaCtacteCajaTesoreriaNombre_NombreCol
        {
            get { return CAMBIOS_DIVISA_INFO_COMPLETACollection.CTACTE_CAJA_TESORERIA_NOMBREColumnName; }
        }
        public static string VistaCtacteCajaTesoreriaSucId_NombreCol
        {
            get { return CAMBIOS_DIVISA_INFO_COMPLETACollection.CTACTE_CAJA_TESORERIA_SUC_IDColumnName; }
        }
        public static string VistaCtacteCajaTesoreriaSucNombre_NombreCol
        {
            get { return CAMBIOS_DIVISA_INFO_COMPLETACollection.CTACTE_CAJA_TESORERIA_SUC_NOMColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return CAMBIOS_DIVISA_INFO_COMPLETACollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaOrdenPagoCasoId_NombreCol
        {
            get { return CAMBIOS_DIVISA_INFO_COMPLETACollection.ORDEN_PAGO_CASO_IDColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return CAMBIOS_DIVISA_INFO_COMPLETACollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CAMBIOS_DIVISA_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
