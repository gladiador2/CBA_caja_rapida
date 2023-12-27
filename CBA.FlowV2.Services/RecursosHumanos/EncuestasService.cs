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
    public class EncuestasService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.ENCUESTAS;
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
                    ENCUESTASRow cabeceraRow = sesion.Db.ENCUESTASCollection.GetByCASO_ID(caso_id)[0];
                    ENCUESTAS_PREGUNTASRow[] preguntasRows = sesion.Db.ENCUESTAS_PREGUNTASCollection.GetByENCUESTA_ID(cabeceraRow.ID);

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
                    //Pendiente a Abierto
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Abierto))
                    {
                        //Acciones:
                        //Se controla que esten definidas las fechas de inicio y fin.
                        exito = true;
                        revisarRequisitos = true;

                        if (cabeceraRow.IsFECHA_INICIONull || cabeceraRow.IsFECHA_FINNull)
                        {
                            exito = false;
                            mensaje = "Debe definir tanto la fecha de inicio como la de fin en que la encuesta puede ser respondida.";
                        }
                    }
                    //Abierto a En-revision
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Abierto) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.EnRevision))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    //En-revision a Abierto
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnRevision) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Abierto))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                    }
                    //En-revision a Cerrado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnRevision) &&
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
                        sesion.Db.ENCUESTASCollection.Update(cabeceraRow);
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
            ENCUESTASRow row = sesion.Db.ENCUESTASCollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE;
        }

        #endregion Implementacion de metodos abstract

        #region GetEncuesta

        /// <summary>
        /// Gets the encuesta.
        /// </summary>
        /// <param name="encuesta_id">The encuesta_id.</param>
        /// <returns></returns>
        public ENCUESTASRow GetEncuesta(decimal encuesta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ENCUESTASCollection.GetByPrimaryKey(encuesta_id);
            }
        }
        #endregion GetEncuesta

        #region GetEncuestasFiltradas
        /// <summary>
        /// Gets the encuestas filtradas.
        /// </summary>
        /// <param name="parte_texto">The parte_texto.</param>
        /// <param name="persona_id">The persona_id.</param>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public DataTable GetEncuestasFiltradas(string parte_texto, bool para_persona, bool para_funcionario, bool buscar_todas)
        {
            using (SessionService sesion = new SessionService())
            {
                string listaCasos = CasosService.GetListaDeCasos(Definiciones.FlujosIDs.ENCUESTAS, Definiciones.EstadosFlujos.Abierto);
                string where = " 1=1 ";
                
                //Se toman solo los casos en estado abierto
                if(listaCasos != string.Empty)
                {
                    where += " and " + EncuestasService.EncuestasCasoId_NombreCol + " in (" + listaCasos + ") ";
                }

                //Se filtra por titulo u observacion
                if (parte_texto.Length > 0)
                {
                    where += " and (upper(" + EncuestasService.EncuestasTitulo_NombreCol + ") like '%" + parte_texto.ToUpper() + "%' or " +
                             "      upper(" + EncuestasService.EncuestasObservacion_NombreCol + ") like '%" + parte_texto.ToUpper() + "%') ";
                }

                //Puede ser respondido por personas
                if (para_persona)
                {
                    where += " and "+EncuestasService.EncuestasParaPersonas_NombreCol+" = '" + Definiciones.SiNo.Si + "' ";
                }

                //Puede ser respondido por funcionarios
                if (para_funcionario)
                {
                    where += " and " + EncuestasService.EncuestasParaFuncionarios_NombreCol + " = '" + Definiciones.SiNo.Si + "' ";
                }

                //No respetar el rango de fechas en que se encuentra disponible
                if (!buscar_todas) 
                {
                    where += " and " + EncuestasService.EncuestasFechaInicio_NombreCol + " < sysdate and " + EncuestasService.EncuestasFechaFin_NombreCol + " > sysdate ";
                }

                return sesion.Db.ENCUESTASCollection.GetAsDataTable(where, "");
            }
        }
        #endregion GetEncuestasFiltradas

        #region GetEncuestaPorCaso
        public DataTable GetEncuestaPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ENCUESTASCollection.GetAsDataTable(" caso_id = " + caso_id, "");
            }
        }
        #endregion GetEncuestaPorCaso

        #region GetEncuestaAsDataTable
        public DataTable GetEncuestaAsDataTable(string clausula,string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ENCUESTASCollection.GetAsDataTable(clausula,orden);
            }
        }
        #endregion GetEncuestaAsDataTable

        #region VariarCantidadPreguntas
        /// <summary>
        /// Variars the cantidad preguntas.
        /// </summary>
        /// <param name="encuesta_id">The encuesta_id.</param>
        /// <param name="cantidad_variacion">The cantidad_variacion.</param>
        public void VariarCantidadPreguntas(decimal encuesta_id, decimal cantidad_variacion)
        { 
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    ENCUESTASRow row = sesion.Db.ENCUESTASCollection.GetByPrimaryKey(encuesta_id);
                    row.CANTIDAD_PREGUNTAS += cantidad_variacion;
                    sesion.Db.ENCUESTASCollection.Update(row);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion VariarCantidadPreguntas

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        public bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id) {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                ENCUESTASRow row = new ENCUESTASRow();

                try
                {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos["SUCURSAL_ID"].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.ENCUESTAS.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("encuestas_sqc");
                        row.CANTIDAD_PREGUNTAS = 0; //por inicializacion
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.ENCUESTASCollection.GetRow(" id = " + decimal.Parse((string)campos["ID"]));
                        valorAnterior = row.ToString();
                    }

                    row.SUCURSAL_ID = decimal.Parse(campos["SUCURSAL_ID"].ToString());
                    row.TITULO = campos["TITULO"].ToString();
                    
                    if (campos.Contains("AUTONUMERACION_ID")) row.AUTONUMERACION_ID = decimal.Parse(campos["AUTONUMERACION_ID"].ToString());
                    else row.IsAUTONUMERACION_IDNull = true;
                    row.NRO_COMPROBANTE = campos["NRO_COMPROBANTE"].ToString();

                    if (campos.Contains("FECHA_INICIO")) row.FECHA_INICIO = DateTime.Parse((string)campos["FECHA_INICIO"]);
                    else row.IsFECHA_INICIONull = true;
                    if (campos.Contains("FECHA_FIN")) row.FECHA_FIN = DateTime.Parse((string)campos["FECHA_FIN"]);
                    else row.IsFECHA_FINNull = true;

                    row.PARA_FUNCIONARIOS = campos["PARA_FUNCIONARIOS"].ToString();
                    row.PARA_PERSONAS = campos["PARA_PERSONAS"].ToString();

                    row.OBSERVACION = campos["OBSERVACION"].ToString();

                    if (insertarNuevo) sesion.Db.ENCUESTASCollection.Insert(row);
                    else sesion.Db.ENCUESTASCollection.Update(row);
                    LogCambiosService.LogDeRegistro("encuestas", row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA_INICIO);
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
                    String mensaje = "Error.";

                    //Se obtiene el caso a ser borrado
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    ENCUESTASRow cabecera = sesion.Db.ENCUESTASCollection.GetByCASO_ID(caso_id)[0];

                    if (! caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Se obtienen los detalles del caso a ser borrados.
                    DataTable detalles = (new EncuestasPreguntasService()).GetEncuestaPreguntas(cabecera.ID);

                    //Si el caso posee detalles no puede ser borrado
                    if (detalles.Rows.Count > 0)
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que posee preguntas.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.ENCUESTASCollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro("encuestas", cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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

        #region Metodos estaticos
        public static string Nombre_Tabla
        {
            get { return "ENCUESTAS"; }
        }
        public static string EncuestasAutonumeracionId_NombreCol
        {
            get { return ENCUESTASCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string EncuestasCantidadPreguntas_NombreCol
        {
            get { return ENCUESTASCollection.CANTIDAD_PREGUNTASColumnName; }
        }
        public static string EncuestasCasoId_NombreCol
        {
            get { return ENCUESTASCollection.CASO_IDColumnName; }
        }
        public static string EncuestasId_NombreCol
        {
            get { return ENCUESTASCollection.IDColumnName; }
        }
        public static string EncuestasNroComprobante
        {
            get { return ENCUESTASCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string EncuestasParaFuncionarios_NombreCol
        {
            get { return ENCUESTASCollection.PARA_FUNCIONARIOSColumnName; }
        }
        public static string EncuestasParaPersonas_NombreCol
        {
            get { return ENCUESTASCollection.PARA_PERSONASColumnName; }
        }
        public static string EncuestasSucursalId_NombreCol
        {
            get { return ENCUESTASCollection.SUCURSAL_IDColumnName; }
        }
        public static string EncuestasTitulo_NombreCol
        {
            get { return ENCUESTASCollection.TITULOColumnName; }
        }
        public static string EncuestasFechaInicio_NombreCol
        {
            get { return ENCUESTASCollection.FECHA_INICIOColumnName; }
        }
        public static string EncuestasFechaFin_NombreCol
        {
            get { return ENCUESTASCollection.FECHA_FINColumnName; }
        }
        public static string EncuestasObservacion_NombreCol
        {
            get { return ENCUESTASCollection.OBSERVACIONColumnName; }
        }
        #endregion Metodos estaticos

    }
}
