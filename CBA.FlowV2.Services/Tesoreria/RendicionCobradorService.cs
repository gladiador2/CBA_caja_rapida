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

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class RendicionCobradorService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de Metodos Heredados
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.RENDICION_COBRADOR;
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

        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            RENDICION_COBRADORRow[] rows;
            rows = sesion.Db.RENDICION_COBRADORCollection.GetByCASO_ID(caso_id);
            if (rows.Length == 1)
                return rows[0].NRO_COMPROBANTE.ToString();
            else
                return string.Empty;
        }

        public static DataTable GetRendicionCobradorDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.RENDICION_COBRADORCollection.GetAsDataTable(clausulas, orden);
            }
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
                    RENDICION_COBRADORRow cabeceraRow = sesion.Db.RENDICION_COBRADORCollection.GetByCASO_ID(caso_id)[0];
                    RENDICION_COBRADOR_DETALLERow[] detalleRows = sesion.Db.RENDICION_COBRADOR_DETALLECollection.GetByRENDICION_COBRADOR_ID(cabeceraRow.ID);
                    
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
                        if (cabeceraRow.NRO_COMPROBANTE==null)
                        {
                            cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID);
                        }
                        sesion.Db.RENDICION_COBRADORCollection.Update(cabeceraRow);

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

                        exito = true;
                        revisarRequisitos = true;

                        DataTable dt = RendicionCobradorDetalleService.GetRendicionCobradorDetalleInfoCompleta( "( " +RendicionCobradorDetalleService.VistaEstadoCaso_NombreCol + " IS NULL  OR " + RendicionCobradorDetalleService.VistaEstadoCaso_NombreCol + " = '" + Definiciones.EstadosFlujos.Pendiente + "' OR " + RendicionCobradorDetalleService.VistaEstadoCaso_NombreCol + " = '" + Definiciones.EstadosFlujos.Borrador + "') AND " + RendicionCobradorDetalleService.RendicionCobradorId_NombreCol + " = " + cabeceraRow.ID, string.Empty);
                        if (dt.Rows.Count > 0)
                        {
                            exito = false;
                            mensaje = "No pueden quedar casos de pago en estado BORRADOR ni PENDIENTE";
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
                        sesion.Db.RENDICION_COBRADORCollection.Update(cabeceraRow);
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
                RENDICION_COBRADORRow row = new RENDICION_COBRADORRow();
                try
                {
                    string valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("RENDICION_COBRADOR_SQC");
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[SucursalId_NombreCol].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.RENDICION_COBRADOR.ToString()),
                                                             int.Parse(sesion.Usuario_Id.ToString()),
                                                             SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                        row.FECHA = DateTime.Now;
                        row.USUARIO_CREACION_ID = sesion.Usuario.ID;

                        row.FUNCIONARIO_ID = (decimal)campos[RendicionCobradorService.FuncionarioId_NombreCol];
                    }
                    else
                    {
                        row = sesion.Db.RENDICION_COBRADORCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    // a partir de este punto se asignan los valores
                    if (campos.Contains(SucursalId_NombreCol)) row.SUCURSAL_ID = decimal.Parse(campos[SucursalId_NombreCol].ToString());
                    else throw new System.ArgumentException("La sucursal no puede ser nula");

                    if (campos.Contains(AutonumeracionId_NombreCol)) row.AUTONUMERACION_ID = decimal.Parse(campos[AutonumeracionId_NombreCol].ToString());
                    else throw new System.ArgumentException("La autonumeración no puede ser nula");

                    if (campos.Contains(NroComprobante_NombreCol)) row.NRO_COMPROBANTE = campos[NroComprobante_NombreCol].ToString();
                    
                    if (insertarNuevo) sesion.Db.RENDICION_COBRADORCollection.Insert(row);
                    else sesion.Db.RENDICION_COBRADORCollection.Update(row);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.FUNCIONARIO_ID);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
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
                    RENDICION_COBRADORRow cabecera = sesion.Db.RENDICION_COBRADORCollection.GetByCASO_ID(caso_id)[0];
                    RENDICION_COBRADOR_DETALLERow[] detalles = sesion.Db.RENDICION_COBRADOR_DETALLECollection.GetByRENDICION_COBRADOR_ID(cabecera.ID);

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
                        sesion.Db.RENDICION_COBRADORCollection.DeleteByCASO_ID(caso_id);
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

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "RENDICION_COBRADOR"; }
        }
        public static string Id_NombreCol
        {
            get { return RENDICION_COBRADORCollection.IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return RENDICION_COBRADORCollection.FECHAColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return RENDICION_COBRADORCollection.CASO_IDColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return RENDICION_COBRADORCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return RENDICION_COBRADORCollection.OBSERVACIONColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return RENDICION_COBRADORCollection.SUCURSAL_IDColumnName; }
        }
        public static string UsuarioCreacionId_NombreCol
        {
            get { return RENDICION_COBRADORCollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return RENDICION_COBRADORCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return RENDICION_COBRADORCollection.AUTONUMERACION_IDColumnName; }
        }
        #endregion Tabla

        #region Vista

        #endregion Vista

        #endregion Accessors
    }
}




