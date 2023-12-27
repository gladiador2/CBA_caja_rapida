using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.RecursosHumanos;
using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.Casos;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class FuncionarioAdelantoService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.ADELANTO_FUNCIONARIO;
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
        /// Obtener el numero de comprobante
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns>String con el numero de comprobante</returns>
        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            FUNCIONARIOS_ADELANTOSRow row = sesion.Db.FUNCIONARIOS_ADELANTOSCollection.GetByCASO_ID(caso_id)[0];
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
                    FUNCIONARIOS_ADELANTOSRow cabeceraRow = sesion.Db.FUNCIONARIOS_ADELANTOSCollection.GetByCASO_ID(caso_id)[0];
                    

                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Si fue emitido un recibo, el mismo es anulado.
                        exito = true;
                        revisarRequisitos = true;

                       
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //Si no existe un recibo, generarlo.
                        //Si ya existe y cambio el monto total, actualizar el recibo
                        exito = true;
                        revisarRequisitos = true;
                        if (exito && cabeceraRow.NRO_COMPROBANTE == null)
                        {
                            try
                            {
                                cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID);

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
                        //Se anula el recibo.
                        exito = true;

               
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //Crear los valores.
                        //Afectar la cuenta corriente de la persona
                        exito = true;
                        revisarRequisitos = true;
                        
                        if (cabeceraRow.NRO_COMPROBANTE != null)
                        {
                            exito = true;
                        }
                        else
                        {
                            exito = false;
                            mensaje = "Debe asignar un número de comprobante";
                        }

                        
                        decimal montoMaximoAdelanto = FuncionariosService.MontoMaximoAdelanto(cabeceraRow.FUNCIONARIO_ID);
                        
                        decimal mesAdelantoActual = Definiciones.Error.Valor.EnteroPositivo;
                        decimal anhoAdelantoActual = Definiciones.Error.Valor.EnteroPositivo;

                        if (!cabeceraRow.IsFECHANull)
                        {
                          mesAdelantoActual = cabeceraRow.FECHA.Month;
                          anhoAdelantoActual = cabeceraRow.FECHA.Year;
                        }

                        decimal mesAdelantoAnterior = 0;
                        decimal anhoAdelantoAnterior = 0;
                        decimal montoTotalAdelantos = 0;

                        FUNC_ADELANTOS_INFO_COMPLRow[] adelantos = sesion.Db.FUNC_ADELANTOS_INFO_COMPLCollection.GetAsArray(FuncionarioAdelantoService.FuncionarioId_NombreCol +" = "+cabeceraRow.FUNCIONARIO_ID +" and ("+
                                                                                                                               FuncionarioAdelantoService.VistaCasoEstadoId_NombreCol +" = '" + Definiciones.EstadosFlujos.Aprobado + "'"+ " OR "+
                                                                                                                               FuncionarioAdelantoService.VistaCasoEstadoId_NombreCol +" = '" + Definiciones.EstadosFlujos.Cerrado + "')",string.Empty);
                        for (int i = 0; i < adelantos.Length; i++) 
                        {
                            if (adelantos[i].ID != cabeceraRow.ID)
                            {
                                mesAdelantoAnterior = adelantos[i].CASO_FECHA.Month;
                                if ((mesAdelantoActual == mesAdelantoAnterior) && (anhoAdelantoActual == anhoAdelantoAnterior)) 
                                {
                                    montoTotalAdelantos += adelantos[i].MONTO_CONCEDIDO;
                                }
                            }
                        }
                        montoTotalAdelantos += cabeceraRow.MONTO_CONCEDIDO;
                        if (montoTotalAdelantos > montoMaximoAdelanto) 
                        {
                            exito = false;
                            mensaje = "El total de adelantos del funcionario excede al maximo permitido para le mismo. Caso: " +cabeceraRow.CASO_ID;
                        }

                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //ninguna.
                        revisarRequisitos = true;

                        if (cambio_pedido_por_usuario)
                        {
                            exito = false;
                            mensaje = "Solo el sistema puede utilizar la transición 'Aprobado' -> 'Cerrado'.";
                        }
                        else
                        {
                            FuncionariosDescuentosService descuento = new FuncionariosDescuentosService();
                            System.Collections.Hashtable campos = new System.Collections.Hashtable();
                            campos.Add(FuncionariosDescuentosService.DescuentoId_NombreCol, Definiciones.TipoDescuento.AdelantoSalario);
                            campos.Add(FuncionariosDescuentosService.FuncionarioId_NombreCol, cabeceraRow.FUNCIONARIO_ID);
                            campos.Add(FuncionariosDescuentosService.MonedaId_NombreCol, cabeceraRow.MONEDA_ID);
                            campos.Add(FuncionariosDescuentosService.CotizacionMoneda_NombreCol, cabeceraRow.COTIZACION);
                            campos.Add(FuncionariosDescuentosService.Monto_NombreCol, cabeceraRow.MONTO_CONCEDIDO);
                            campos.Add(FuncionariosDescuentosService.UtilizarPorcentaje_NombreCol, Definiciones.SiNo.No);
                            campos.Add(FuncionariosDescuentosService.Estado_NombreCol, Definiciones.Estado.Activo);
                            campos.Add(FuncionariosDescuentosService.Observacion_NombreCol, cabeceraRow.CASO_ID + ". " +cabeceraRow.OBSERVACION);
                            campos.Add(FuncionariosDescuentosService.FechaCreacion_NombreCol, cabeceraRow.FECHA);
                            campos.Add(FuncionariosDescuentosService.CasoOrigenId_NombreCol, cabeceraRow.CASO_ID);
                            descuento.Guardar(campos, true,sesion);
                            exito = true;
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
                        sesion.Db.FUNCIONARIOS_ADELANTOSCollection.Update(cabeceraRow);
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

        #region GetFuncionarioAdelantoDataTable
        /// <summary>
        /// Gets the funcionario adelanto data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetFuncionarioAdelantoDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FUNCIONARIOS_ADELANTOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        public static DataTable GetFuncionarioAdelantoDataTableStatic(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FUNCIONARIOS_ADELANTOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetFuncionarioAdelantoDataTable

        #region GetFuncionarioAdelantoInfoCompleta
        /// <summary>
        /// Gets the funcionario adelanto info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetFuncionarioAdelantoInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {

                return sesion.Db.FUNC_ADELANTOS_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        public static DataTable GetFuncionarioAdelantoInfoCompletaStatic(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {

                return sesion.Db.FUNC_ADELANTOS_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetFuncionarioAdelantoInfoCompleta

        #region GetAnticipoProveedorInfoCompleta


        //public DataTable GetAnticipoProveedorInfoCompleta(string clausulas, string orden)
        //{
        //    using (SessionService sesion = new SessionService())
        //    {
        //        return sesion.Db.ANTICIPOS_PROVEED_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        //    }
        //}
        #endregion GetAnticipoProveedorInfoCompleta

        #region GetAdelantoFuncionarioPorCaso


        /// <summary>
        /// Gets the adelanto funcionario por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetAdelantoFuncionarioPorCaso(Decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FUNCIONARIOS_ADELANTOSCollection.GetAsDataTable(FuncionarioAdelantoService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetAdelantoFuncionarioPorCaso

        #region GetAdelantoParaOrdenDePago

        //public DataTable GetAnticipoProveedorParaOrdenDePago(decimal proveedor_id)
        //{
        //    using (SessionService sesion = new SessionService())
        //    {
        //        string clausulas = AnticiposProveedorService.VistaOrdenPagoUtilizaCasoId_NombreCol + " is null and " +
        //                           AnticiposProveedorService.ProveedorId_NombreCol + " = " + proveedor_id + " and " +
        //                           AnticiposProveedorService.VistaCasoEstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Aplicacion + "'";

        //        return sesion.Db.ANTICIPOS_PROVEED_INFO_COMPLCollection.GetAsDataTable(clausulas, AnticiposProveedorService.Fecha_NombreCol);
        //    }
        //}
        #endregion GetAdelantoParaOrdenDePago

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return Guardar(campos, insertarNuevo, ref caso_id, ref estado_id,sesion);
            }
        }
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id,SessionService sesion)
        {
            
                bool exito = false;
                FUNCIONARIOS_ADELANTOSRow row = new FUNCIONARIOS_ADELANTOSRow();

                try
                {
                    SucursalesService sucursal = new SucursalesService();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(sesion.SucursalActiva.ID.ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.ADELANTO_FUNCIONARIO.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("funcionarios_adelantos_sqc");


                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;


                    }
                    else
                    {
                        row = sesion.Db.FUNCIONARIOS_ADELANTOSCollection.GetByPrimaryKey((decimal)campos[FuncionarioAdelantoService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    if (campos.Contains(MontoSolicitado_NombreCol))
                    {
                        row.MONTO_SOLICITADO = decimal.Parse(campos[FuncionarioAdelantoService.MontoSolicitado_NombreCol].ToString());
                        if (insertarNuevo)
                        {
                            row.MONTO_CONCEDIDO = row.MONTO_SOLICITADO;
                        }
                    }
                    if (!insertarNuevo)
                    {
                        if (campos.Contains(MontoConcedido_NombreCol))
                        {
                            row.MONTO_CONCEDIDO = decimal.Parse(campos[FuncionarioAdelantoService.MontoConcedido_NombreCol].ToString());
                        }
                    }
                    if (campos.Contains(Nro_Comprobante_NombreCol))
                    {
                        row.NRO_COMPROBANTE = campos[FuncionarioAdelantoService.Nro_Comprobante_NombreCol].ToString();
                    }
                    if (campos.Contains(Observacion_NombreCol))
                    {
                        row.OBSERVACION = campos[FuncionarioAdelantoService.Observacion_NombreCol].ToString();
                    }
                    if (campos.Contains(Cotizacion_NombreCol))
                    {
                        row.COTIZACION = decimal.Parse(campos[FuncionarioAdelantoService.Cotizacion_NombreCol].ToString());
                    }
                    if (campos.Contains(AutonmeracionId_NombreCol))
                    {
                        row.AUTONUMERACION_ID = decimal.Parse(campos[FuncionarioAdelantoService.AutonmeracionId_NombreCol].ToString());
                    }
                    if (campos.Contains(FuncionarioId_NombreCol))
                    {
                        row.FUNCIONARIO_ID = decimal.Parse(campos[FuncionarioAdelantoService.FuncionarioId_NombreCol].ToString());
                    }
                    if (campos.Contains(MonedaId_NombreCol))
                    {
                        row.MONEDA_ID = decimal.Parse(campos[FuncionarioAdelantoService.MonedaId_NombreCol].ToString());
                    }
                    if (campos.Contains(Fecha_NombreCol))
                    {
                        //si se ha cambiado la fecha, debe de actualizar el descuento si está generado
                        if (!row.IsFECHANull && row.FECHA != DateTime.Parse(campos[FuncionarioAdelantoService.Fecha_NombreCol].ToString()) 
                            && FuncionariosDescuentosService.GetExisteDescuento(row.CASO_ID.ToString(), sesion))
                            FuncionariosDescuentosService.ActualizarFecha(row.CASO_ID.ToString(), sesion, DateTime.Parse(campos[FuncionarioAdelantoService.Fecha_NombreCol].ToString()));

                        row.FECHA = DateTime.Parse(campos[FuncionarioAdelantoService.Fecha_NombreCol].ToString());
                    }
                    if (campos.Contains(CasoOrigenId_NombreCol))
                    {
                        row.CASO_ORIGEN_ID = Decimal.Parse(campos[FuncionarioAdelantoService.CasoOrigenId_NombreCol].ToString());
                    }

                    if (insertarNuevo) sesion.Db.FUNCIONARIOS_ADELANTOSCollection.Insert(row);
                    else sesion.Db.FUNCIONARIOS_ADELANTOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.FUNCIONARIO_ID);
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
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
                    FUNCIONARIOS_ADELANTOSRow cabecera = sesion.Db.FUNCIONARIOS_ADELANTOSCollection.GetByCASO_ID(caso_id)[0];
                

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {

                       
                        sesion.Db.FUNCIONARIOS_ADELANTOSCollection.DeleteByPrimaryKey(cabecera.ID);
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
        #endregion Borrar

        #region Set Monto Concedido
        public static void setMontoConcedido(decimal caso_id, decimal monto)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {


                    sesion.Db.BeginTransaction();
                    FUNCIONARIOS_ADELANTOSRow row = sesion.Db.FUNCIONARIOS_ADELANTOSCollection.GetByCASO_ID(caso_id)[0];
                    string anterior = row.ToString();
                    row.MONTO_CONCEDIDO = monto;

                    sesion.Db.FUNCIONARIOS_ADELANTOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, anterior, row.ToString(), sesion);
                    sesion.Db.CommitTransaction();



                }
                catch (Exception ex)
                {
                    sesion.Db.RollbackTransaction();
                    throw ex;
                }
              }
        }
        #endregion Set Monto Concedido

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "FUNCIONARIOS_ADELANTOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "FUNC_ADELANTOS_INFO_COMPL"; }
        }
        public static string AutonmeracionId_NombreCol
        {
            get { return FUNCIONARIOS_ADELANTOSCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return FUNCIONARIOS_ADELANTOSCollection.CASO_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return FUNCIONARIOS_ADELANTOSCollection.COTIZACIONColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return FUNCIONARIOS_ADELANTOSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return FUNCIONARIOS_ADELANTOSCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return FUNCIONARIOS_ADELANTOSCollection.MONEDA_IDColumnName; }
        }
        public static string MontoSolicitado_NombreCol
        {
            get { return FUNCIONARIOS_ADELANTOSCollection.MONTO_SOLICITADOColumnName; }
        }
        public static string MontoConcedido_NombreCol
        {
            get { return FUNCIONARIOS_ADELANTOSCollection.MONTO_CONCEDIDOColumnName; }
        }
        public static string Nro_Comprobante_NombreCol
        {
            get { return FUNCIONARIOS_ADELANTOSCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return FUNCIONARIOS_ADELANTOSCollection.OBSERVACIONColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return FUNCIONARIOS_ADELANTOSCollection.FECHAColumnName; }
        }
        public static string CasoOrigenId_NombreCol
        {
            get { return FUNCIONARIOS_ADELANTOSCollection.CASO_ORIGEN_IDColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return FUNC_ADELANTOS_INFO_COMPLCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCasoFecha_NombreCol
        {
            get { return FUNC_ADELANTOS_INFO_COMPLCollection.CASO_FECHAColumnName; }
        }
        public static string VistaCasoUsuarioId_NombreCol
        {
            get { return FUNC_ADELANTOS_INFO_COMPLCollection.CASO_USUARIO_IDColumnName; }
        }
        public static string VistaCasoSucursalId_NombreCol
        {
            get { return FUNC_ADELANTOS_INFO_COMPLCollection.CASO_SUCURSAL_IDColumnName; }
        }
        public static string VistaCasoSucursalAbreviatura_NombreCol
        {
            get { return FUNC_ADELANTOS_INFO_COMPLCollection.CASO_SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaCasoSucursalNombre_NombreCol
        {
            get { return FUNC_ADELANTOS_INFO_COMPLCollection.CASO_SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaFuncionarioCodigo_NombreCol
        {
            get { return FUNC_ADELANTOS_INFO_COMPLCollection.FUNCIONARIO_CODIGOColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return FUNC_ADELANTOS_INFO_COMPLCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return FUNC_ADELANTOS_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return FUNC_ADELANTOS_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaOrdenPagoRespaldaCasoId_NombreCol
        {
            get { return FUNC_ADELANTOS_INFO_COMPLCollection.ORDEN_PAGO_RESPALDA_CASO_IDColumnName; }
        }
        #endregion Accessors
    }
}
