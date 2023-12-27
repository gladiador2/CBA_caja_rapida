using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using System.Collections;
using System.Collections.Generic;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class AsignacionCargosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.ASIGNACION_CARGOS;
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
                mensaje = "";
                try
                {
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    ASIGNACIONES_CARGOSRow cabeceraRow = sesion.Db.ASIGNACIONES_CARGOSCollection.GetByCASO_ID(caso_id)[0];
                    ASIGNACIONES_CARGOS_DETALLERow[] detalleRows = sesion.Db.ASIGNACIONES_CARGOS_DETALLECollection.GetByASIGNACIONES_CARGOS_ID(cabeceraRow.ID);

                    //Borrador a Anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    //Borrador a Pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //Se genera la numeracion del caso a partir de la autonumeracion que haya indicado el usuario, si el 
                        //caso no tenia previamente un numero asignado (i.e. realizo la transicion anteriormete). 

                        exito = true;
                        revisarRequisitos = true;

                        if (cabeceraRow.NRO_COMPROBANTE == null)
                        {
                            try
                            {
                                cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, sesion);

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
                    //Pendiente a Borrador 
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                    }
                    //Pendiente a Pre-aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.PreAprobado))
                    {
                        //Acciones:
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    //Pre-aprobado a Pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.PreAprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                    }
                    //Pre-aprobado a Aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.PreAprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    //Aprobado a Pre-aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.PreAprobado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                    }
                    //Aprobado a Cerrado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //Se asignan los cargos a los funcionarios.
                        exito = true;
                        revisarRequisitos = true;

                        EmpresaCargosFuncionariosService EmpresaCargoFuncionario = new EmpresaCargosFuncionariosService();
                        foreach (ASIGNACIONES_CARGOS_DETALLERow d in detalleRows)
                        {
                            //EmpresaCargoFuncionario.Agregar(d.FUNCIONARIO_ID, d.EMPRESA_CARGO_ID);
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
                        sesion.Db.ASIGNACIONES_CARGOSCollection.Update(cabeceraRow);
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
            ASIGNACIONES_CARGOSRow row = sesion.Db.ASIGNACIONES_CARGOSCollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE;
        }

        #endregion Implementacion de metodos abstract

        #region GetAsignacionCargos

        /// <summary>
        /// Gets the asignacion cargos.
        /// </summary>
        /// <param name="asignacion_cargos_id">The asignacion_cargos_id.</param>
        /// <returns></returns>
        public ASIGNACIONES_CARGOSRow GetAsignacionCargos(Decimal asignacion_cargos_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ASIGNACIONES_CARGOSCollection.GetByPrimaryKey(asignacion_cargos_id);
            }
        }
        #endregion GetAsignacionCargos

        #region GetAsignacionCargosPorCaso
        /// <summary>
        /// Gets the asignacion cargos por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetAsignacionCargosPorCaso(Decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ASIGNACIONES_CARGOSCollection.GetAsDataTable(" caso_id = " + caso_id, "");
            }
        }
        #endregion GetAsignacionCargosPorCaso

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        public bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                ASIGNACIONES_CARGOSRow row = new ASIGNACIONES_CARGOSRow();

                try
                {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos["SUCURSAL_ID"].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.ASIGNACION_CARGOS.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("asignaciones_cargos_sqc");
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.ASIGNACIONES_CARGOSCollection.GetRow(" id = " + decimal.Parse((string)campos["ID"]));
                        valorAnterior = row.ToString();
                    }

                    row.SUCURSAL_ID = decimal.Parse(campos["SUCURSAL_ID"].ToString());
                    row.FECHA = DateTime.Parse((string)campos["FECHA"]);

                    if (campos.Contains("AUTONUMERACION_ID")) row.AUTONUMERACION_ID = decimal.Parse(campos["AUTONUMERACION_ID"].ToString());
                    else row.IsAUTONUMERACION_IDNull = true;
                    row.NRO_COMPROBANTE = campos["NRO_COMPROBANTE"].ToString();

                    row.OBSERVACION = campos["OBSERVACION"].ToString();

                    if (insertarNuevo) sesion.Db.ASIGNACIONES_CARGOSCollection.Insert(row);
                    else sesion.Db.ASIGNACIONES_CARGOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro("asignaciones_cargos", row.ID, valorAnterior, row.ToString(), sesion);

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
        /// Borra de la base de datos el caso y la cabecera del flujo
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
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
                    ASIGNACIONES_CARGOSRow cabecera = sesion.Db.ASIGNACIONES_CARGOSCollection.GetByCASO_ID(caso_id)[0];

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Se obtienen los detalles del caso a ser borrados.
                    DataTable detalles = (new AsignacionCargosDetalleService()).GetAsignacionCargosDetalle(cabecera.ID);

                    //Si el caso posee detalles no puede ser borrado
                    if (detalles.Rows.Count > 0)
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que posee detalles.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.ASIGNACIONES_CARGOSCollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro("asignaciones_cargos", cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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
            get { return "ASIGNACIONES_CARGOS"; }
        }
        #endregion Accessors
    }
}
