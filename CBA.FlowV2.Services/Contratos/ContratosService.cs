#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Presupuestos;
using System.Collections;
using System.Collections.Generic;
#endregion Using

namespace CBA.FlowV2.Services.Contratos
{
    public class ContratosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.CONTRATOS;
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
                    CONTRATOSRow cabeceraRow = sesion.Db.CONTRATOSCollection.GetByCASO_ID(caso_id)[0];
 
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

                        #region generar autonumeracion
                        
                        //Si no existe un comprobante se crea
                        if (cabeceraRow.NRO_COMPROBANTE == null)
                            cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, sesion);
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
                        //Afectar la cuenta corriente de la persona
                        exito = true;
                        revisarRequisitos = true;                        
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //Afectar la cuenta corriente de la persona
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
                        sesion.Db.CONTRATOSCollection.Update(cabeceraRow);
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
                CONTRATOSRow cabeceraRow = sesion.Db.CONTRATOSCollection.GetByCASO_ID(caso_id)[0];
                return cabeceraRow.NRO_COMPROBANTE;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Implementacion de metodos abstract

        #region GetContratosDataTable

        /// <summary>
        /// Gets the contratos data table.
        /// </summary>
        /// <param name="presupuesto_id">The presupuesto_id.</param>
        /// <returns></returns>
        public DataTable GetContratosDataTable(decimal presupuesto_id)
        {
            return GetContratosDataTable(Id_NombreCol + " = " + presupuesto_id, string.Empty);
        }

        /// <summary>
        /// Gets the contratos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetContratosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CONTRATOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetContratosDataTable

        #region GetContratosInfoCompletaDataTable


        /// <summary>
        /// Gets the contratos info completa data table.
        /// </summary>
        /// <param name="contrato_id">The contrato_id.</param>
        /// <returns></returns>
        public DataTable GetContratosInfoCompletaDataTable(decimal contrato_id)
        {
            return GetContratosInfoCompletaDataTable(Id_NombreCol + " = " + contrato_id, string.Empty);
        }


        /// <summary>
        /// Gets the contratos info completa data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetContratosInfoCompletaDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CONTRATOS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetContratosInfoCompletaDataTable

        #region GetContratoPorCaso


        /// <summary>
        /// Gets the contrato por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetContratoPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CONTRATOSCollection.GetAsDataTable(CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetContratoPorCaso

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
                CONTRATOSRow row = new CONTRATOSRow();

                try
                {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[SucursalId_NombreCol].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.CONTRATOS.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("CONTRATOS_SQC");
                        row.FECHA_CREACION = DateTime.Now;
                        
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador; 
                    }
                    else
                    {
                        row = sesion.Db.CONTRATOSCollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    
                    
                    if (SucursalesService.EstaActivo((decimal)(campos[SucursalId_NombreCol])))
                        row.SUCURSAL_ID = (decimal)campos[SucursalId_NombreCol];
                    else
                        throw new System.Exception("La sucursal se encuentra inactiva.");
                    

                   
                    if (campos.Contains(AutonumeracionId_NombreCol)) row.AUTONUMERACION_ID = decimal.Parse(campos[AutonumeracionId_NombreCol].ToString());
                    row.TIPO = campos[ContratosService.Tipo_NombreCol].ToString();

                    if (campos.Contains(ContratosService.ProveedorId_NombreCol)) row.PROVEEDOR_ID = decimal.Parse(campos[ContratosService.ProveedorId_NombreCol].ToString());
                    if (campos.Contains(ContratosService.PersonaId_NombreCol)) row.PERSONA_ID = decimal.Parse(campos[ContratosService.PersonaId_NombreCol].ToString());

                    if (campos.Contains(ContratosService.FechaInicio_NombreCol)) row.FECHA_INICIO= DateTime.Parse(campos[ContratosService.FechaInicio_NombreCol].ToString());
                    if (campos.Contains(ContratosService.FechaFin_NombreCol)) row.FECHA_FIN = DateTime.Parse(campos[ContratosService.FechaFin_NombreCol].ToString());

                    if (campos.Contains(ContratosService.MonedaId_NombreCol)) row.MONEDA_ID = decimal.Parse(campos[ContratosService.MonedaId_NombreCol].ToString());
                    if (campos.Contains(ContratosService.Cotizacion_NombreCol)) row.COTIZACION = decimal.Parse(campos[ContratosService.Cotizacion_NombreCol].ToString());

                    if (campos.Contains(Objeto_NombreCol)) row.OBJETO = campos[Objeto_NombreCol].ToString();

                    if(campos.Contains(Observacion_NombreCol))  row.OBSERVACIONES = campos[Observacion_NombreCol].ToString();
                    
                    if (insertarNuevo) sesion.Db.CONTRATOSCollection.Insert(row);
                    else sesion.Db.CONTRATOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA_CREACION);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    if (!row.IsPERSONA_IDNull)
                        camposCaso.Add(CasosService.ProveedorId_NombreCol, row.PERSONA_ID);
                    if (!row.IsPROVEEDOR_IDNull)
                        camposCaso.Add(CasosService.ProveedorId_NombreCol, row.PROVEEDOR_ID);
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
        /// <returns>bool</returns>
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
                    CONTRATOSRow cabecera = sesion.Db.CONTRATOSCollection.GetByCASO_ID(caso_id)[0];
                    ContratosDetalleService presupuestos = new ContratosDetalleService();
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
                        dtDetalles = presupuestos.GetContratosDetalleDataTable(cabecera.ID);
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            presupuestos.Borrar((decimal)dtDetalles.Rows[i][Id_NombreCol]);
                        }

                        sesion.Db.CONTRATOSCollection.DeleteByCASO_ID(caso_id);
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

        #region CompletarCampos
        /// <summary>
        /// Completars the campos.
        /// </summary>
        /// <param name="contrato_id">The contrato_id.</param>
        public void CompletarCampos(decimal contrato_id)
        {

        }
        #endregion CompletarCampos

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "CONTRATOS"; }
        }
        public static string Id_NombreCol
        {
            get { return CONTRATOSCollection.IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return CONTRATOSCollection.CASO_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CONTRATOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return CONTRATOSCollection.AUTONUMERACION_IDColumnName; }
        }
         public static string NroComprobante_NombreCol
        {
            get { return CONTRATOSCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CONTRATOSCollection.OBSERVACIONESColumnName; }
        }
        public static string Tipo_NombreCol
        {
            get { return CONTRATOSCollection.TIPOColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return CONTRATOSCollection.FECHA_CREACIONColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return CONTRATOSCollection.PROVEEDOR_IDColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return CONTRATOSCollection.PERSONA_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CONTRATOSCollection.MONEDA_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return CONTRATOSCollection.COTIZACIONColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return CONTRATOSCollection.FECHA_INICIOColumnName; }
        }
        public static string FechaFin_NombreCol
        {
            get { return CONTRATOSCollection.FECHA_FINColumnName; }
        }
        public static string Objeto_NombreCol
        {
            get { return CONTRATOSCollection.OBJETOColumnName; }
        }
        #endregion Tabla


        #region Vista
        public static string VistaCasoFecha_NombreCol
        {
            get { return CONTRATOS_INFO_COMPLETACollection.CASO_FECHAColumnName; }
        }
        
        public static string VistaCasoEstado_NombreCol
        {
            get { return CONTRATOS_INFO_COMPLETACollection.CASO_ESTADOColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CONTRATOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaProveedorRazonSocial_NombreCol
        {
            get { return CONTRATOS_INFO_COMPLETACollection.PROVEEDOR_RAZON_SOCIALColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return CONTRATOS_INFO_COMPLETACollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CONTRATOS_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CONTRATOS_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        #endregion Vista
        #endregion Accessors
    }
}
