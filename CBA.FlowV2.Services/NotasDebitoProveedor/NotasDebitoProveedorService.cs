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
using System.Collections;
using System.Collections.Generic;

namespace CBA.FlowV2.Services.NotasDebitoProveedor
{
    public class NotasDebitoProveedorService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.NOTA_DEBITO_PROVEEDOR;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var drCabecera = (DataRow)caso_cabecera;
            var drDetalle = (DataRow)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);
            
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, );
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, drDetalle[NotasDebitoProveedorDetalleService.ActivoId_NombreCol]);
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
                    NOTA_DEBITO_PROVEEDORRow cabeceraRow = sesion.Db.NOTA_DEBITO_PROVEEDORCollection.GetByCASO_ID(caso_id)[0];
                    NOTA_DEBITO_PROVEEDOR_DETALLERow[] detalleRow = sesion.Db.NOTA_DEBITO_PROVEEDOR_DETALLECollection.GetByNOTA_DEBITO_PROVEEDOR_ID(cabeceraRow.ID);
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //Crear una autonumeracion si no existe.
                        exito = true;
                        revisarRequisitos = true;

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado

                        #region generar autonumeracion
                        
                        //Si no existe un comprobante se crea
                        if (exito && cabeceraRow.NRO_COMPROBANTE== null)
                        {
                            cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, sesion);
                        }
                        #endregion generar autonumeracion
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
                        //Ninguna
                        exito = true;
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //Afectar la cuenta corriente del proveedor
                        exito = true;
                        revisarRequisitos = true;

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado

                        if (exito)
                        {
                            #region afectar ctacte
                            //Ingresar el debito
                            CuentaCorrienteProveedoresService.AgregarCredito((decimal)cabeceraRow.PROVEEDOR_ID,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.CuentaCorrienteValores.NotaDeDebito,
                                                        Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                        cabeceraRow.CASO_ID,
                                                        cabeceraRow.MONEDA_ID,
                                                        cabeceraRow.MONTO,
                                                        string.Empty,
                                                        DateTime.Now,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        sesion);

                            #endregion afectar ctacte
                        }
                        
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //ninguna.
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
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.NOTA_DEBITO_PROVEEDORCollection.Update(cabeceraRow);
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
            try
            {
                CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                NOTA_DEBITO_PROVEEDORRow cabeceraRow = sesion.Db.NOTA_DEBITO_PROVEEDORCollection.GetByCASO_ID(caso_id)[0];
                return cabeceraRow.NRO_COMPROBANTE;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Implementacion de metodos abstract

        #region GetNotaDebitoProveedorDataTable
        /// <summary>
        /// Gets the nota debito proveedor data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetNotaDebitoProveedorDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaDebitoProveedorDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaDebitoProveedorDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.NOTA_DEBITO_PROVEEDORCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetNotaDebitoProveedorDataTable

        #region GetNotaDebitoProveedorInfoCompleta
        /// <summary>
        /// Gets the nota debito proveedor info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetNotaDebitoProveedorInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaDebitoProveedorInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaDebitoProveedorInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ND_PROVEEDOR_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetNotaDebitoProveedorInfoCompleta

        #region VerificarPuedeAvanzarEstado
        public static bool VerificarPuedeAvanzarEstado(decimal caso_id, out string mensaje, SessionService sesion)
        {
            return FlujosService.VerificarPuedeAvanzarEstado(caso_id, out mensaje, "NOTAS DEBITO PROVEEDOR NO CONTROLAR MARGEN DIAS PUEDE AVANZAR", Definiciones.VariablesDeSistema.NDProveedorMargenDiasPuedeAvanzar, sesion);
        }
        #endregion VerificarPuedeAvanzarEstado

        #region RecalcularTotal

        /// <summary>
        /// Recalculars the total.
        /// </summary>
        /// <param name="nota_debito_proveedor_id">The nota_debito_proveedor_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void RecalcularTotal(decimal nota_debito_proveedor_id, SessionService sesion)
        {
            NOTA_DEBITO_PROVEEDORRow row = sesion.Db.NOTA_DEBITO_PROVEEDORCollection.GetByPrimaryKey(nota_debito_proveedor_id);
            NOTA_DEBITO_PROVEEDOR_DETALLERow[] detalleRows = sesion.Db.NOTA_DEBITO_PROVEEDOR_DETALLECollection.GetByNOTA_DEBITO_PROVEEDOR_ID(nota_debito_proveedor_id);
            decimal total = 0;
            decimal impuesto = 0;
            string valorAnterior;

            valorAnterior = row.MONTO.ToString();

            for (int i = 0; i < detalleRows.Length; i++)
            {
                total += detalleRows[i].MONTO;
                impuesto += detalleRows[i].MONTO_IMPUESTO;
            }

            row.MONTO = total;
    
            row.MONTO_IMPUESTO = impuesto;

            sesion.Db.NOTA_DEBITO_PROVEEDORCollection.Update(row);
            LogCambiosService.LogDeColumna(Nombre_Tabla, Monto_NombreCol, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion RecalcularTotal

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
                NOTA_DEBITO_PROVEEDORRow row = new NOTA_DEBITO_PROVEEDORRow();

                try
                {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[SucursalId_NombreCol].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.NOTA_DEBITO_PROVEEDOR.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("NOTA_DEBITO_PROVEEDOR_SQC");
                      
                        row.MONTO = 0;
                        
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.NOTA_DEBITO_PROVEEDORCollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    row.FECHA = DateTime.Parse(campos[Fecha_NombreCol].ToString());
                    if (campos.Contains(NroComprobante_NombreCol))
                        row.NRO_COMPROBANTE = campos[NroComprobante_NombreCol].ToString();

                    if (row.SUCURSAL_ID != decimal.Parse(campos[SucursalId_NombreCol].ToString()))
                    {
                        if (SucursalesService.EstaActivo(decimal.Parse(campos[SucursalId_NombreCol].ToString())))
                        {
                            row.SUCURSAL_ID = decimal.Parse(campos[SucursalId_NombreCol].ToString());
                            CasosService.ActualizarSucursal(row.CASO_ID, row.SUCURSAL_ID, sesion);
                        }
                        else
                            throw new System.Exception("La sucursal se encuentra inactiva.");
                    }
                    

                    if (row.PROVEEDOR_ID != decimal.Parse(campos[ProveedorId_NombreCol].ToString()))
                    {
                        if (ProveedoresService.EstaActivo(decimal.Parse(campos[ProveedorId_NombreCol].ToString())))
                            row.PROVEEDOR_ID = decimal.Parse(campos[ProveedorId_NombreCol].ToString());
                        else
                            throw new System.Exception("El proveedor se encuentra inactivo.");
                    }

                    row.AUTONUMERACION_ID = decimal.Parse(campos[AutonumeracionId_NombreCol].ToString());

                    if (campos.Contains(NroComprobante_NombreCol))row.NRO_COMPROBANTE = (string)campos[NroComprobante_NombreCol];

                    if (!MonedasService.EstaActivo((decimal.Parse(campos[MonedaId_NombreCol].ToString()))))
                    {
                        throw new System.Exception("La moneda se encuentra inactiva.");
                    }
                    else
                    {
                        row.MONEDA_ID = decimal.Parse(campos[MonedaId_NombreCol].ToString());

                        
                        row.COTIZACION = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, row.FECHA, sesion);

                        if (row.COTIZACION.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("Debe actualizarse la cotización de la moneda.");
                    }
                  
                    row.OBSERVACION = (string)campos[Observacion_NombreCol];

                    if (insertarNuevo) sesion.Db.NOTA_DEBITO_PROVEEDORCollection.Insert(row);
                    else sesion.Db.NOTA_DEBITO_PROVEEDORCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.ProveedorId_NombreCol, row.PROVEEDOR_ID);
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
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
        public static bool Borrar(decimal caso_id)
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
                    NOTA_DEBITO_PROVEEDORRow cabecera = sesion.Db.NOTA_DEBITO_PROVEEDORCollection.GetByCASO_ID(caso_id)[0];
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
                        dtDetalles = NotasDebitoProveedorDetalleService.GetNotaDebitoProveedorDetalleDataTable(cabecera.ID);
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            NotasDebitoProveedorDetalleService.Borrar((decimal)dtDetalles.Rows[i][Id_NombreCol]);
                        }

                        sesion.Db.NOTA_DEBITO_PROVEEDORCollection.DeleteByCASO_ID(caso_id);
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
            get { return "NOTA_DEBITO_PROVEEDOR"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDORCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDORCollection.CASO_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDORCollection.COTIZACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDORCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDORCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDORCollection.MONTOColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDORCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDORCollection.OBSERVACIONColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDORCollection.PROVEEDOR_IDColumnName; }
        }
        
        public static string SucursalId_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDORCollection.SUCURSAL_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDORCollection.FECHAColumnName; }
        }
        public static string TotalImpuesto_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDORCollection.MONTO_IMPUESTOColumnName; }
        }
        
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return ND_PROVEEDOR_INFO_COMPLETACollection.CASO_ESTADOColumnName; }
        }

        public static string VistaSucursalNombre_NombreCol
        {
            get { return ND_PROVEEDOR_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return ND_PROVEEDOR_INFO_COMPLETACollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return ND_PROVEEDOR_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return ND_PROVEEDOR_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaFechaCaso_NombreCol
        {
            get { return ND_PROVEEDOR_INFO_COMPLETACollection.CASO_FECHAColumnName; }
        }
          #endregion Accessors
    }
}
