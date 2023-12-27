#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using System.Windows.Forms;
using CBA.FlowV2.Services.DetallesPersonalizados;
using System.Collections;
using System.Collections.Generic;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class AlarmasService
    {
        #region GetAlarmasDataTable
        /// <summary>
        /// Gets the alarmas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAlarmasDataTable(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                    return sesion.Db.ALARMASCollection.GetAsDataTable(clausulas, orden);
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetAlarmasDataTable

        #region GetAlarmasInfoCompleta
        /// <summary>
        /// Gets the alarmas info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetAlarmasInfoCompleta(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                    return sesion.Db.ALARMAS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetAlarmasInfoCompleta

        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="alarma_id">The alarma_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal alarma_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ALARMASRow row = sesion.Db.ALARMASCollection.GetByPrimaryKey(alarma_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                ALARMASRow row = new ALARMASRow();
                bool exito = false;
                try
                {
                    sesion.Db.BeginTransaction();

                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("alarmas_sqc");
                        row.ENTIDAD_ID = sesion.Entidad.ID;
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.ALARMASCollection.GetByPrimaryKey((decimal)campos[AlarmasService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    
                    row.ESTADO = (string)campos[AlarmasService.Estado_NombreCol];
                    row.NOMBRE = (string)campos[AlarmasService.Nombre_NombreCol];
                    row.TIPO_ALARMA_ID = (decimal)campos[AlarmasService.TipoAlarmaId_NombreCol];
                    row.DESCRIPCION = (string)campos[AlarmasService.Descripcion_NombreCol];

                    if (campos.Contains(AlarmasService.UsuarioId_NombreCol))
                        row.USUARIO_ID = (decimal)campos[AlarmasService.UsuarioId_NombreCol];
                    else
                        row.IsUSUARIO_IDNull = true;

                    if (campos.Contains(AlarmasService.RolId_NombreCol))
                        row.ROL_ID = (decimal)campos[AlarmasService.RolId_NombreCol];
                    else
                        row.IsROL_IDNull = true;

                    if (campos.Contains(AlarmasService.FlujoId_NombreCol))
                        row.FLUJO_ID = (decimal)campos[AlarmasService.FlujoId_NombreCol];
                    else
                        row.IsFLUJO_IDNull = true;

                    row.FLUJO_ESTADO_ID = (string)campos[AlarmasService.FlujoEstadoId_NombreCol];

                    if (campos.Contains(AlarmasService.LogCampoId_NombreCol))
                        row.LOG_CAMPO_ID = (decimal)campos[AlarmasService.LogCampoId_NombreCol];
                    else
                        row.IsLOG_CAMPO_IDNull = true;

                    if (campos.Contains(AlarmasService.TipoDato_NombreCol))
                        row.TIPO_DATO = decimal.Parse(campos[AlarmasService.TipoDato_NombreCol].ToString());
                    else
                        row.IsTIPO_DATONull = true;

                    if (campos.Contains(AlarmasService.ValorInferior_NombreCol))
                        row.VALOR_INFERIOR = campos[AlarmasService.ValorInferior_NombreCol].ToString();
                    
                    if (campos.Contains(AlarmasService.ValorSuperior_NombreCol))
                        row.VALOR_SUPERIOR = campos[AlarmasService.ValorSuperior_NombreCol].ToString();

                    if (campos.Contains(AlarmasService.TipoRango_NombreCol))
                        row.TIPO_RANGO = decimal.Parse(campos[AlarmasService.TipoRango_NombreCol].ToString());
                    else
                        row.IsTIPO_RANGONull = true;

                    if (campos.Contains(AlarmasService.Mail_NombreCol))
                        row.MAIL = campos[AlarmasService.Mail_NombreCol].ToString();

                    row.EXISTENCIA_MAYOR_CERO = campos[AlarmasService.ExistenciaMayorCero_NombreCol].ToString();
                    row.TIPO_ENVIO_PARA_USUARIO = (decimal)campos[AlarmasService.TipoEnvioParaUsuario_NombreCol];
                    row.RESUMIDO = (string)campos[AlarmasService.Resumido_NombreCol];

                    if (insertarNuevo) sesion.Db.ALARMASCollection.Insert(row);
                    else sesion.Db.ALARMASCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    exito = true;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }

                return exito ? row.ID : Definiciones.Error.Valor.EnteroPositivo;
            }
        }
        #endregion Guardar

        #region EvaluarAlarmas
        public static void EvaluarAlarmas()
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    // Se obtienen todas las alarmas activas de la base de datos
                    string clausulas = AlarmasService.EntidadId_NombreCol + " = " + sesion.EntidadActual_Id + " and " +
                                       AlarmasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

                    DataTable alarmasActivas = AlarmasService.GetAlarmasDataTable(clausulas, string.Empty);

                    foreach (DataRow fila in alarmasActivas.Rows)
                    {
                        // Se llama a la funcion necesaria segun tipo de alarma
                        if ((decimal)fila[AlarmasService.TipoAlarmaId_NombreCol] == Definiciones.TipoAlarma.campoValor)
                            AlarmasService.EvaluarAlarmasCampoValor(fila);
                        else if ((decimal)fila[AlarmasService.TipoAlarmaId_NombreCol] == ((decimal)Definiciones.TipoAlarma.tiempo))
                            AlarmasService.EvaluarAlarmasTiempo(fila);
                        else if ((decimal)fila[AlarmasService.TipoAlarmaId_NombreCol] == ((decimal)Definiciones.TipoAlarma.registroNuevo))
                            AlarmasService.EvaluarAlarmasRegistroNuevo(fila);
                        else if ((decimal)fila[AlarmasService.TipoAlarmaId_NombreCol] == ((decimal)Definiciones.TipoAlarma.sql))
                            AlarmasService.EvaluarAlarmasSQL(fila);
                        else
                            throw new Exception("Se encontró una alarma con un tipo no reconocido.");
                    }
                }
                catch (System.Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion EvaluarAlarmas

        #region EvaluarAlarmasCampoValor
        private static void EvaluarAlarmasCampoValor(DataRow alarma)
        {
            EvaluarAlarmasCampoValor(alarma, false);
        }

        private static void EvaluarAlarmasCampoValor(DataRow alarma, bool usar_smtp_cliente)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    #region Crear el Mensaje
                    // Se obtiene el log campo de la alarma
                    DataTable logCampo = LogCamposService.GetLogCamposDataTable(LogCamposService.Id_NombreCol + " = " + alarma[AlarmasService.LogCampoId_NombreCol].ToString(), string.Empty);

                    if (logCampo.Rows.Count <= 0)
                        throw new Exception("No se encuentra registro del log campo solicitado.");

                    // Se genera un sql para enviar una query a la base de datos
                    string sql = "select * from " + logCampo.Rows[0][LogCamposService.TablaId_NombreCol].ToString();

                    // ESTA CLAUSULA FUNCIONA SOLO PARA DATOS DEL TIPO NUMERICO O FECHAS, NO ASI PARA STRINGS!
                    // El where del query dependera del tipo de rango a verificar (interno, externo, unico)
                    if (alarma[AlarmasService.TipoRango_NombreCol].Equals(Definiciones.TipoRangoAlarma.Interior))
                    {
                        if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.NumeroCantidad)
                        {
                            sql += " where " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + " >= " + alarma[AlarmasService.ValorInferior_NombreCol].ToString();
                            sql += " and " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + " <= " + alarma[AlarmasService.ValorSuperior_NombreCol].ToString();
                        }
                        else if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.Fecha)
                        {
                            sql += " where " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + " >= to_date(" + alarma[AlarmasService.ValorInferior_NombreCol].ToString() + ", 'DD-MM-YYYY')";
                            sql += " and " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + " <= to_date(" + alarma[AlarmasService.ValorSuperior_NombreCol].ToString() + ", 'DD-MM-YYYY')";
                        }
                        else
                            throw new Exception("Se encontró una alarma del tipo CampoValor con rango interior, pero con un tipo de dato no reconocido.");
                    }
                    else if (alarma[AlarmasService.TipoRango_NombreCol].Equals(Definiciones.TipoRangoAlarma.Exterior))
                    {
                        if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.NumeroCantidad)
                        {
                            sql += " where " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + " <= " + alarma[AlarmasService.ValorInferior_NombreCol].ToString();
                            sql += " or " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + " >= " + alarma[AlarmasService.ValorSuperior_NombreCol].ToString();
                        }
                        else if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.Fecha)
                        {
                            sql += " where " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + " <= to_date(" + alarma[AlarmasService.ValorInferior_NombreCol].ToString() + ", 'DD-MM-YYYY')";
                            sql += " or " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + " >= to_date(" + alarma[AlarmasService.ValorSuperior_NombreCol].ToString() + ", 'DD-MM-YYYY'";
                        }
                        else
                            throw new Exception("Se encontró una alarma del tipo CampoValor con rango exterior, pero con un tipo de dato no reconocido.");
                    }
                    else if (alarma[AlarmasService.TipoRango_NombreCol].Equals(Definiciones.TipoRangoAlarma.Unico))
                    {
                        if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.NumeroCantidad)
                            sql += " where " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + " = " + alarma[AlarmasService.ValorInferior_NombreCol].ToString();
                        else if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.Fecha)
                            sql += " where " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + " = to_date(" + alarma[AlarmasService.ValorInferior_NombreCol].ToString() + ", 'DD-MM-YYYY')";
                        else
                            throw new Exception("Se encontró una alarma del tipo CampoValor con rango único, pero con un tipo de dato no reconocido.");
                    }
                    else
                        throw new Exception("Se encontró una alarma del tipo CampoValor, pero con un tipo de rango no reconocido.");

                    // Se ejecuta el query y se lo guarda en una datatable
                    DataTable registrosEncontrados = new DataTable();
                    registrosEncontrados = sesion.Db.EjecutarQuery(sql);

                    string mensaje = string.Empty;

                    // Si el datatable tiene mas de un registro, la alarma debe ser activada
                    if (registrosEncontrados.Rows.Count > 0 && alarma[AlarmasService.ExistenciaMayorCero_NombreCol].Equals(Definiciones.SiNo.Si))
                    {
                        // Se genera el mensaje a enviar, utilizando los parametros utilizados para encontrar los registros                        
                        mensaje = string.Empty;

                        if (registrosEncontrados.Rows.Count == 1)
                            mensaje = "Se ha encontrado un registro ";
                        else
                            mensaje = "Se han encontrado " + registrosEncontrados.Rows.Count.ToString() + " registros ";

                        mensaje += "en la tabla " + logCampo.Rows[0][LogCamposService.TablaId_NombreCol].ToString() +
                                   " con el campo " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString();

                        if (alarma[AlarmasService.TipoRango_NombreCol].Equals(Definiciones.TipoRangoAlarma.Exterior))
                            mensaje += " fuera del rango " + alarma[AlarmasService.ValorInferior_NombreCol].ToString() + " y " + alarma[AlarmasService.ValorSuperior_NombreCol].ToString() + ".";
                        if (alarma[AlarmasService.TipoRango_NombreCol].Equals(Definiciones.TipoRangoAlarma.Interior))
                            mensaje += " dentro del rango " + alarma[AlarmasService.ValorInferior_NombreCol].ToString() + " y " + alarma[AlarmasService.ValorSuperior_NombreCol].ToString() + ".";
                        if (alarma[AlarmasService.TipoRango_NombreCol].Equals(Definiciones.TipoRangoAlarma.Unico))
                            mensaje += " igual al valor " + alarma[AlarmasService.ValorInferior_NombreCol].ToString() + ".";

                    }
                    else if (registrosEncontrados.Rows.Count <= 0 && alarma[AlarmasService.ExistenciaMayorCero_NombreCol].Equals(Definiciones.SiNo.No))
                    {
                        mensaje = "No se ha encontrado ningún registro ";

                        mensaje += "en la tabla " + logCampo.Rows[0][LogCamposService.TablaId_NombreCol].ToString() +
                                   " con el campo " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString();

                        if (alarma[AlarmasService.TipoRango_NombreCol].Equals(Definiciones.TipoRangoAlarma.Exterior))
                            mensaje += " fuera del rango " + alarma[AlarmasService.ValorInferior_NombreCol].ToString() + " y " + alarma[AlarmasService.ValorSuperior_NombreCol].ToString() + ".";
                        if (alarma[AlarmasService.TipoRango_NombreCol].Equals(Definiciones.TipoRangoAlarma.Interior))
                            mensaje += " dentro del rango " + alarma[AlarmasService.ValorInferior_NombreCol].ToString() + " y " + alarma[AlarmasService.ValorSuperior_NombreCol].ToString() + ".";
                        if (alarma[AlarmasService.TipoRango_NombreCol].Equals(Definiciones.TipoRangoAlarma.Unico))
                            mensaje += " igual al valor " + alarma[AlarmasService.ValorInferior_NombreCol].ToString() + ".";
                    }
                    #endregion Crear el Mensaje

                    #region Envio del mensaje
                    // Se envia el mensaje a quien corresponda
                    if (!mensaje.Equals(string.Empty))
                    {
                        #region Envios tipo Mensajes del sistema

                        string htmlMensaje= "<h2> Alarma del sistema! </h2>";
                        htmlMensaje += mensaje;

                        Hashtable campos = new Hashtable();

                        campos.Add(MensajesDeSistemaService.Estado_NombreCol, Definiciones.Estado.Activo);
                        campos.Add(MensajesDeSistemaService.FechaInicio_NombreCol, DateTime.Today);
                        campos.Add(MensajesDeSistemaService.Texto_NombreCol, htmlMensaje);                            
                        campos.Add(MensajesDeSistemaService.TipoMensaje_NombreCol, (decimal)alarma[AlarmasService.TipoAlarmaId_NombreCol]);

                        // Se envia mensaje de sistema a todos aquellos que tengan el rol determinado en la alarma
                       
                        #region mensaje para el rol
                        if (!alarma[AlarmasService.RolId_NombreCol].Equals(DBNull.Value))
                        {
                            campos.Add(MensajesDeSistemaService.RolId_NombreCol, (decimal)alarma[AlarmasService.RolId_NombreCol]);
                            MensajesDeSistemaService.Guardar(campos, true);
                        }
                        #endregion mensaje para el rol

                        #region Mensaje para el usuario del sistema
                        if (!alarma[AlarmasService.UsuarioId_NombreCol].Equals(DBNull.Value))
                        {
                            bool userTieneRol = false;
                            if (!alarma[AlarmasService.RolId_NombreCol].Equals(DBNull.Value))
                            {
                                DataTable dtUsuarioTieneRol = UsuariosRolesService.GetUsuariosRolesDataTable(UsuariosRolesService.RolId_NombreCol + " = " + alarma[AlarmasService.RolId_NombreCol] + " and " + UsuariosRolesService.UsuarioId_NombreCol + " = " + alarma[AlarmasService.UsuarioId_NombreCol].ToString(), string.Empty, sesion);
                                userTieneRol = dtUsuarioTieneRol.Rows.Count > 0;
                            }

                            //Enviar un mensaje de sistema
                            if ((decimal)alarma[AlarmasService.TipoEnvioParaUsuario_NombreCol] == Definiciones.AlarmasTiposEnvio.MensajeDeSistema)
                            {
                                //Verificar si el usuario no tenia el rol asociado a la alarma
                                if (!userTieneRol)
                                {
                                    campos.Add(MensajesDeSistemaService.UsuarioId_NombreCol, (decimal)alarma[AlarmasService.UsuarioId_NombreCol]);
                                    MensajesDeSistemaService.Guardar(campos, true);
                                }
                            }
                        }
                        #endregion Mensaje para el usuario del sistema
                            
                        #endregion Envios tipo Mensajes del sistema

                        #region Mensaje para direccion de correo especifica
                        HashSet<decimal> usuariosDestinatarios = new HashSet<decimal>();
                        
                        string asunto = "Alarma del CBAFlow";
                        string texto = "<html><body>" + mensaje + "<br><br><a href='" + Traducciones.Link_al_CBAFlow + "'>Ir al sistema.</a></body></html>";
                                                
                        #region Mandar correo a la direccion dada
                        // Se envia un correo electronico a la direccion definida en la alarma y al usuario definido
                        if (!alarma[AlarmasService.Mail_NombreCol].Equals(DBNull.Value))
                        {
                            using (EmailService correo = new EmailService(usar_smtp_cliente, sesion))
                            {
                                correo.EnviarMail(alarma[AlarmasService.Mail_NombreCol].ToString(), asunto, texto);
                            }
                        }
                        #endregion Mandar correo a la direccion dada

                        #region Mandar el correo al usuario especificado
                        
                        if (!alarma[AlarmasService.UsuarioId_NombreCol].Equals(DBNull.Value) && (decimal)alarma[AlarmasService.TipoEnvioParaUsuario_NombreCol] == Definiciones.AlarmasTiposEnvio.Email)
                        {
                            DataTable dtUsuario = new UsuariosService().GetUsuario((decimal)alarma[AlarmasService.UsuarioId_NombreCol]);
                            string mailUsuario = dtUsuario.Rows[0][UsuariosService.Email_NombreCol].ToString();
                            
                            //Verificar que no se este enviando el correo a la misma direccion
                            if (!alarma[AlarmasService.Mail_NombreCol].Equals(mailUsuario))
                            {
                                using (EmailService correo = new EmailService(usar_smtp_cliente, sesion))
                                {
                                    correo.EnviarMail(mailUsuario, asunto, texto);
                                }
                            }
                        }
                        #endregion Mandar el correo al usuario especificado

                    // CODIGO POR SI SE SUGIERE ENVIAR CORREO A TODOS LOS USUARIOS CON EL ROL, NO SOLO MENSAJE DE SISTEMA!
                        //string direccion_destino;
                        //if (false)
                        //{
                        //    DataTable dtUsuarios = new UsuariosRolesService().GetUsuariosRolesDataTable(UsuariosRolesService.RolId_NombreCol + " = " + alarma[AlarmasService.RolId_NombreCol].ToString(), string.Empty);
                        //    for (int j = 0; j < dtUsuarios.Rows.Count; j++)
                        //        usuariosDestinatarios.Add((decimal)dtUsuarios.Rows[j][UsuariosRolesService.UsuraioId_NombreCol]);

                        //    foreach (decimal usuarioId in usuariosDestinatarios)
                        //    {
                        //        DataTable dtUsuario = new UsuariosService().GetUsuario(usuarioId);
                        //        direccion_destino = (string)dtUsuario.Rows[0][UsuariosService.Email_NombreCol];

                        //        correo.EnviarMail((string)usuario_creador_del_caso.Rows[0][UsuariosService.Email_NombreCol], direccion_destino, asunto, texto);
                        //    }
                        //}

                        #endregion Mensaje para direccion de correo especifica                  
                    }
                    #endregion Envio del mensaje
                }
                catch (System.Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion EvaluarAlarmasCampoValor

        #region EvaluarAlarmasTiempo
        private static void EvaluarAlarmasTiempo(DataRow alarma)
        {
            EvaluarAlarmasTiempo(alarma, false);
        }

        private static void EvaluarAlarmasTiempo(DataRow alarma, bool usar_smtp_cliente)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    #region Crear el Mensaje
                    // Se obtiene el log campo de la alarma
                    DataTable logCampo = LogCamposService.GetLogCamposDataTable(LogCamposService.Id_NombreCol + " = " + alarma[AlarmasService.LogCampoId_NombreCol].ToString(), string.Empty);

                    if (logCampo.Rows.Count <= 0)
                        throw new Exception("No se encuentra registro del log campo solicitado.");

                    // Se genera un sql para enviar una query a la base de datos
                    string sql = "select * from " + logCampo.Rows[0][LogCamposService.TablaId_NombreCol].ToString();

                    // El where del query dependera del tipo de rango a verificar (interno, externo)
                    if (alarma[AlarmasService.TipoRango_NombreCol].Equals(Definiciones.TipoRangoAlarma.Interior))
                    {
                        //Se verifica si existen registros cuyo campo en cuestion este a MENOR distancia que la establecida a la fecha de referencia, segun el tipo de dato
                        if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.NumeroDia)
                            sql += " where (to_date(" + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + ", 'DD-MM-YYYY') - (select to_date(sysdate, 'DD-MM-YYYY') from dual)) between 0 and " + alarma[AlarmasService.ValorInferior_NombreCol].ToString();
                        else if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.NumeroMes)
                            sql += " where (to_date(" + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + ", 'DD-MM-YYYY') - (select to_date(sysdate, 'DD-MM-YYYY') from dual)) / 30 between 0 and " + alarma[AlarmasService.ValorInferior_NombreCol].ToString();
                        else if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.NumeroAnho)
                            sql += " where (to_date(" + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + ", 'DD-MM-YYYY') - (select to_date(sysdate, 'DD-MM-YYYY') from dual)) / 365 between 0 and " + alarma[AlarmasService.ValorInferior_NombreCol].ToString();
                        else
                            throw new Exception("Se ha encontrado una alarma del tipo Tiempo y rango Interior, pero con un tipo de dato no reconocido.");
                    }
                    else if (alarma[AlarmasService.TipoRango_NombreCol].Equals(Definiciones.TipoRangoAlarma.Exterior))
                    {
                        //Se verifica si existen registros cuyo campo en cuestion este a MAYOR distancia que la establecida a la fecha de referencia
                        if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.NumeroDia)
                            sql += " where ((select to_date(sysdate, 'MM-DD-YYYY') from dual) - to_date(" + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + ", 'DD-MM-YYYY')) >= " + alarma[AlarmasService.ValorInferior_NombreCol].ToString();
                        else if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.NumeroMes)
                            sql += " where ((select to_date(sysdate, 'MM-DD-YYYY') from dual) - to_date(" + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + ", 'DD-MM-YYYY')) / 30 >= " + alarma[AlarmasService.ValorInferior_NombreCol].ToString();
                        else if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.NumeroAnho)
                            sql += " where ((select to_date(sysdate, 'MM-DD-YYYY') from dual) - to_date(" + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() + ", 'DD-MM-YYYY')) / 365 >= " + alarma[AlarmasService.ValorInferior_NombreCol].ToString();
                        else
                            throw new Exception("Se ha encontrado una alarma del tipo Tiempo y rango Exterior, pero con un tipo de dato no reconocido.");
                    }
                    else
                        throw new Exception("Se encontró una alarma del tipo Tiempo, pero con un tipo de rango no reconocido.");

                    // Se ejecuta el query y se lo guarda en una datatable
                    DataTable registrosEncontrados = new DataTable();
                    registrosEncontrados = sesion.Db.EjecutarQuery(sql);

                    string mensaje = string.Empty;

                    // Si el datatable tiene mas de un registro, la alarma debe ser activada
                    if (registrosEncontrados.Rows.Count > 0 && alarma[AlarmasService.ExistenciaMayorCero_NombreCol].Equals(Definiciones.SiNo.Si))
                    {
                        // Se genera el mensaje a enviar, utilizando los parametros utilizados para encontrar los registros                        
                        mensaje = string.Empty;

                        if (registrosEncontrados.Rows.Count == 1)
                            mensaje = "Se ha encontrado un registro";
                        else
                            mensaje = "Se han encontrado " + registrosEncontrados.Rows.Count.ToString() + " registros ";

                        if (registrosEncontrados.Rows.Count == 1)
                        {
                            if ((decimal)alarma[AlarmasService.TipoRango_NombreCol] == Definiciones.TipoRangoAlarma.Interior)
                                mensaje += " en el que falta menos de " + alarma[AlarmasService.ValorInferior_NombreCol].ToString();
                            else if ((decimal)alarma[AlarmasService.TipoRango_NombreCol] == Definiciones.TipoRangoAlarma.Exterior)
                                mensaje += " en el que ya ha pasado más de " + alarma[AlarmasService.ValorInferior_NombreCol].ToString();
                            else
                                throw new Exception("Tipo de rango no reconocido al generar el mensaje de alarma del tipo Tiempo.");
                        }
                        else if (registrosEncontrados.Rows.Count > 1)
                        {
                            if ((decimal)alarma[AlarmasService.TipoRango_NombreCol] == Definiciones.TipoRangoAlarma.Interior)
                                mensaje += "en los que faltan menos de " + alarma[AlarmasService.ValorInferior_NombreCol].ToString();
                            else if ((decimal)alarma[AlarmasService.TipoRango_NombreCol] == Definiciones.TipoRangoAlarma.Exterior)
                                mensaje += "en los que ya han pasado más de " + alarma[AlarmasService.ValorInferior_NombreCol].ToString();
                            else
                                throw new Exception("Tipo de rango no reconocido al generar el mensaje de alarma del tipo Tiempo.");
                        }

                        if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.NumeroDia)
                            mensaje += (decimal.Parse((string)alarma[AlarmasService.ValorInferior_NombreCol]) <= 1) ? " día " : " días ";
                        else if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.NumeroMes)
                            mensaje += (decimal.Parse((string)alarma[AlarmasService.ValorInferior_NombreCol]) <= 1) ? " mes " : " meses ";
                        else if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.NumeroAnho)
                            mensaje += (decimal.Parse((string)alarma[AlarmasService.ValorInferior_NombreCol]) <= 1) ? " año " : " años ";
                        else
                            throw new Exception("Tipo de dato no reconocido al generar el mensaje de alarma del tipo Tiempo.");

                        if ((decimal)alarma[AlarmasService.TipoRango_NombreCol] == Definiciones.TipoRangoAlarma.Interior)
                        {
                            mensaje += "para llegar a la fecha establecida del campo " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() +
                                       " de la tabla " + logCampo.Rows[0][LogCamposService.TablaId_NombreCol].ToString() + ".";
                        }
                        else if ((decimal)alarma[AlarmasService.TipoRango_NombreCol] == Definiciones.TipoRangoAlarma.Exterior)
                        {
                            mensaje += "desde que el campo " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() +
                                       " de la tabla " + logCampo.Rows[0][LogCamposService.TablaId_NombreCol].ToString() +
                                       " llegó a su fecha establecida.";
                        }
                        else
                            throw new Exception("Tipo de rango no reconocido al generar el mensaje de alarma del tipo Tiempo.");

                    }
                    else if (registrosEncontrados.Rows.Count <= 0 && alarma[AlarmasService.ExistenciaMayorCero_NombreCol].Equals(Definiciones.SiNo.No))
                    {
                        mensaje = "No se ha encontrado ningún registro ";

                        if ((decimal)alarma[AlarmasService.TipoRango_NombreCol] == Definiciones.TipoRangoAlarma.Interior)
                            mensaje += " en el que falta menos de " + alarma[AlarmasService.ValorInferior_NombreCol].ToString();
                        else if ((decimal)alarma[AlarmasService.TipoRango_NombreCol] == Definiciones.TipoRangoAlarma.Exterior)
                            mensaje += " en el que ya ha pasado más de " + alarma[AlarmasService.ValorInferior_NombreCol].ToString();
                        else
                            throw new Exception("Tipo de rango no reconocido al generar el mensaje de alarma del tipo Tiempo.");

                        if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.NumeroDia)
                            mensaje += (decimal.Parse((string)alarma[AlarmasService.ValorInferior_NombreCol]) <= 1) ? " día " : " días ";
                        else if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.NumeroMes)
                            mensaje += (decimal.Parse((string)alarma[AlarmasService.ValorInferior_NombreCol]) <= 1) ? " mes " : " meses ";
                        else if ((decimal)alarma[AlarmasService.TipoDato_NombreCol] == TiposDetallesPersonalizadosService.TipoDato.NumeroAnho)
                            mensaje += (decimal.Parse((string)alarma[AlarmasService.ValorInferior_NombreCol]) <= 1) ? " año " : " años ";
                        else
                            throw new Exception("Tipo de dato no reconocido al generar el mensaje de alarma del tipo Tiempo.");

                        if ((decimal)alarma[AlarmasService.TipoRango_NombreCol] == Definiciones.TipoRangoAlarma.Interior)
                        {
                            mensaje += "para llegar a la fecha establecida del campo " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() +
                                       " de la tabla " + logCampo.Rows[0][LogCamposService.TablaId_NombreCol].ToString() + ".";
                        }
                        else if ((decimal)alarma[AlarmasService.TipoRango_NombreCol] == Definiciones.TipoRangoAlarma.Exterior)
                        {
                            mensaje += "desde que el campo " + logCampo.Rows[0][LogCamposService.CampoId_NombreCol].ToString() +
                                       " de la tabla " + logCampo.Rows[0][LogCamposService.TablaId_NombreCol].ToString() +
                                       " llegó a su fecha establecida.";
                        }
                        else
                            throw new Exception("Tipo de rango no reconocido al generar el mensaje de alarma del tipo Tiempo.");
                    }
                    #endregion Crear el Mensaje

                    #region Envio del mensaje
                    // Se envia el mensaje a quien corresponda
                    if (!mensaje.Equals(string.Empty))
                    {
                        #region Envios tipo Mensajes del sistema

                        string htmlMensaje = "<h2> Alarma del sistema! </h2>";
                        htmlMensaje += mensaje;

                        Hashtable campos = new Hashtable();

                        campos.Add(MensajesDeSistemaService.Estado_NombreCol, Definiciones.Estado.Activo);
                        campos.Add(MensajesDeSistemaService.FechaInicio_NombreCol, DateTime.Today);
                        campos.Add(MensajesDeSistemaService.Texto_NombreCol, htmlMensaje);
                        campos.Add(MensajesDeSistemaService.TipoMensaje_NombreCol, (decimal)alarma[AlarmasService.TipoAlarmaId_NombreCol]);

                        // Se envia mensaje de sistema a todos aquellos que tengan el rol determinado en la alarma

                        #region mensaje para el rol
                        if (!alarma[AlarmasService.RolId_NombreCol].Equals(DBNull.Value))
                        {
                            campos.Add(MensajesDeSistemaService.RolId_NombreCol, (decimal)alarma[AlarmasService.RolId_NombreCol]);
                            MensajesDeSistemaService.Guardar(campos, true);
                        }
                        #endregion mensaje para el rol

                        #region Mensaje para el usuario del sistema
                        if (!alarma[AlarmasService.UsuarioId_NombreCol].Equals(DBNull.Value))
                        {
                            bool userTieneRol = false;
                            if (!alarma[AlarmasService.RolId_NombreCol].Equals(DBNull.Value))
                            {
                                DataTable dtUsuarioTieneRol = UsuariosRolesService.GetUsuariosRolesDataTable(UsuariosRolesService.RolId_NombreCol + " = " + alarma[AlarmasService.RolId_NombreCol].ToString() + " and " + UsuariosRolesService.UsuarioId_NombreCol + " = " + alarma[AlarmasService.UsuarioId_NombreCol], string.Empty, sesion);
                                userTieneRol = dtUsuarioTieneRol.Rows.Count > 0;
                            }

                            //Enviar un mensaje de sistema
                            if ((decimal)alarma[AlarmasService.TipoEnvioParaUsuario_NombreCol] == Definiciones.AlarmasTiposEnvio.MensajeDeSistema)
                            {
                                //Verificar si el usuario no tenia el rol asociado a la alarma
                                if (!userTieneRol)
                                {
                                    campos.Add(MensajesDeSistemaService.UsuarioId_NombreCol, (decimal)alarma[AlarmasService.UsuarioId_NombreCol]);
                                    MensajesDeSistemaService.Guardar(campos, true);
                                }
                            }
                        }
                        #endregion Mensaje para el usuario del sistema

                        #endregion Envios tipo Mensajes del sistema

                        #region Mensaje para direccion de correo especifica
                        HashSet<decimal> usuariosDestinatarios = new HashSet<decimal>();
                        
                        string asunto = "Alarma del CBAFlow";
                        string texto = "<html><body>" + mensaje + "<br><br><a href='" + Traducciones.Link_al_CBAFlow + "'>Ir al sistema.</a></body></html>";

                        #region Mandar correo a la direccion dada
                        // Se envia un correo electronico a la direccion definida en la alarma y al usuario definido
                        if (!alarma[AlarmasService.Mail_NombreCol].Equals(DBNull.Value))
                        {
                            using (EmailService correo = new EmailService(usar_smtp_cliente, sesion))
                            {
                                correo.EnviarMail(alarma[AlarmasService.Mail_NombreCol].ToString(), asunto, texto);
                            }
                        }
                        #endregion Mandar correo a la direccion dada

                        #region Mandar el correo al usuario especificado

                        if (!alarma[AlarmasService.UsuarioId_NombreCol].Equals(DBNull.Value) && (decimal)alarma[AlarmasService.TipoEnvioParaUsuario_NombreCol] == Definiciones.AlarmasTiposEnvio.Email)
                        {
                            DataTable dtUsuario = new UsuariosService().GetUsuario((decimal)alarma[AlarmasService.UsuarioId_NombreCol]);
                            string mailUsuario = dtUsuario.Rows[0][UsuariosService.Email_NombreCol].ToString();

                            //Verificar que no se este enviando el correo a la misma direccion
                            if (!alarma[AlarmasService.Mail_NombreCol].Equals(mailUsuario))
                            {
                                using (EmailService correo = new EmailService(usar_smtp_cliente, sesion))
                                {
                                    correo.EnviarMail(mailUsuario, asunto, texto);
                                }
                            }
                        }
                        #endregion Mandar el correo al usuario especificado

                        // CODIGO POR SI SE SUGIERE ENVIAR CORREO A TODOS LOS USUARIOS CON EL ROL, NO SOLO MENSAJE DE SISTEMA!
                        //string direccion_destino;
                        //if (false)
                        //{
                        //    DataTable dtUsuarios = new UsuariosRolesService().GetUsuariosRolesDataTable(UsuariosRolesService.RolId_NombreCol + " = " + alarma[AlarmasService.RolId_NombreCol].ToString(), string.Empty);
                        //    for (int j = 0; j < dtUsuarios.Rows.Count; j++)
                        //        usuariosDestinatarios.Add((decimal)dtUsuarios.Rows[j][UsuariosRolesService.UsuraioId_NombreCol]);

                        //    foreach (decimal usuarioId in usuariosDestinatarios)
                        //    {
                        //        DataTable dtUsuario = new UsuariosService().GetUsuario(usuarioId);
                        //        direccion_destino = (string)dtUsuario.Rows[0][UsuariosService.Email_NombreCol];

                        //        correo.EnviarMail((string)usuario_creador_del_caso.Rows[0][UsuariosService.Email_NombreCol], direccion_destino, asunto, texto);
                        //    }
                        //}

                        #endregion Mensaje para direccion de correo especifica
                    }
                    #endregion Envio del mensaje
                }
                catch (System.Exception exp)
                {
                    throw exp;
                }
            } 
        }  
        #endregion EvaluarAlarmasTiempo

        #region EvaluarAlarmasRegistroNuevo
        private static void EvaluarAlarmasRegistroNuevo(DataRow alarma)
        {
            EvaluarAlarmasRegistroNuevo(alarma, false);
        }

        private static void EvaluarAlarmasRegistroNuevo(DataRow alarma, bool usar_smtp_cliente)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    #region Generar el mensaje
                    // Se genera un sql para enviar una query a la base de datos en la que se buscan casos de un flujo que hayan transicionado a un estado dado en el ultimo dia
                    string sql = "select * from operaciones_info_completa where flujo_id = " + alarma[AlarmasService.FlujoId_NombreCol].ToString() +
                                " and estado_resultante_id = '" + alarma[AlarmasService.FlujoEstadoId_NombreCol].ToString() + "'" + 
                                " and ((select to_date(sysdate, 'DD-MM-YYYY') from dual) - to_date(fecha, 'DD-MM-YYYY')) < 1";

                    // Se ejecuta el query y se lo guarda en una datatable
                    DataTable registrosEncontrados = new DataTable();
                    registrosEncontrados = sesion.Db.EjecutarQuery(sql);

                    string mensaje = string.Empty;

                    // Si el datatable tiene mas de un registro, la alarma debe ser activada
                    if (registrosEncontrados.Rows.Count > 0 && alarma[AlarmasService.ExistenciaMayorCero_NombreCol].Equals(Definiciones.SiNo.Si))
                    {
                        // Se genera el mensaje a enviar, utilizando los parametros utilizados para encontrar los registros                        
                        mensaje = string.Empty;
                        if (((string)alarma[AlarmasService.FlujoEstadoId_NombreCol]).Equals(Definiciones.EstadosFlujos.Borrador))
                        {
                            if (registrosEncontrados.Rows.Count == 1)
                                mensaje = "Se ha generado un nuevo caso (o el mismo a vuelto al estado BORRADOR) ";
                            else
                                mensaje = "Se han generado " + registrosEncontrados.Rows.Count.ToString() + " nuevos casos (o los mismos han vuelto al estado BORRADOR) ";
                        }
                        else
                        {
                            if (registrosEncontrados.Rows.Count == 1)
                                mensaje = "Se ha registrado la transición de un caso al estado " + alarma[AlarmasService.FlujoEstadoId_NombreCol].ToString() + " ";
                            else
                                mensaje = "Se han registrado las transiciones de " + registrosEncontrados.Rows.Count.ToString() + " casos  al estado " + alarma[AlarmasService.FlujoEstadoId_NombreCol].ToString() + " ";
                        }

                        string flujoDescripcion = FlujosService.GetFlujoDescripcion((decimal)alarma[AlarmasService.FlujoId_NombreCol]);

                        mensaje += "del flujo " + flujoDescripcion + " en las últimas 24 hrs.";

                    }
                    else if (registrosEncontrados.Rows.Count <= 0 && alarma[AlarmasService.ExistenciaMayorCero_NombreCol].Equals(Definiciones.SiNo.No))
                    {
                        mensaje = "No se ha encontrado ningún registro de nuevo caso ";

                        string flujoDescripcion = FlujosService.GetFlujoDescripcion((decimal)alarma[AlarmasService.FlujoId_NombreCol]);

                        mensaje += "del flujo " + flujoDescripcion + " en las últimas 24 hrs.";
                    }
                    #endregion Generar el mensaje

                    #region Envio del mensaje
                    // Se envia el mensaje a quien corresponda
                    if (!mensaje.Equals(string.Empty))
                    {
                        #region Envios tipo Mensajes del sistema

                        string htmlMensaje = "<h2> Alarma del sistema! </h2>";
                        htmlMensaje += mensaje;

                        Hashtable campos = new Hashtable();

                        campos.Add(MensajesDeSistemaService.Estado_NombreCol, Definiciones.Estado.Activo);
                        campos.Add(MensajesDeSistemaService.FechaInicio_NombreCol, DateTime.Today);
                        campos.Add(MensajesDeSistemaService.Texto_NombreCol, htmlMensaje);
                        campos.Add(MensajesDeSistemaService.TipoMensaje_NombreCol, (decimal)alarma[AlarmasService.TipoAlarmaId_NombreCol]);

                        // Se envia mensaje de sistema a todos aquellos que tengan el rol determinado en la alarma

                        #region mensaje para el rol
                        if (!alarma[AlarmasService.RolId_NombreCol].Equals(DBNull.Value))
                        {
                            campos.Add(MensajesDeSistemaService.RolId_NombreCol, (decimal)alarma[AlarmasService.RolId_NombreCol]);
                            MensajesDeSistemaService.Guardar(campos, true);
                        }
                        #endregion mensaje para el rol

                        #region Mensaje para el usuario del sistema
                        if (!alarma[AlarmasService.UsuarioId_NombreCol].Equals(DBNull.Value))
                        {
                            bool userTieneRol = false;
                            if (!alarma[AlarmasService.RolId_NombreCol].Equals(DBNull.Value))
                            {
                                DataTable dtUsuarioTieneRol = UsuariosRolesService.GetUsuariosRolesDataTable(UsuariosRolesService.RolId_NombreCol + " = " + alarma[AlarmasService.RolId_NombreCol].ToString() + " and " + UsuariosRolesService.UsuarioId_NombreCol + " = " + alarma[AlarmasService.UsuarioId_NombreCol], string.Empty, sesion);
                                userTieneRol = dtUsuarioTieneRol.Rows.Count > 0;
                            }

                            //Enviar un mensaje de sistema
                            if ((decimal)alarma[AlarmasService.TipoEnvioParaUsuario_NombreCol] == Definiciones.AlarmasTiposEnvio.MensajeDeSistema)
                            {
                                //Verificar si el usuario no tenia el rol asociado a la alarma
                                if (!userTieneRol)
                                {
                                    campos.Add(MensajesDeSistemaService.UsuarioId_NombreCol, (decimal)alarma[AlarmasService.UsuarioId_NombreCol]);
                                    MensajesDeSistemaService.Guardar(campos, true);
                                }
                            }
                        }
                        #endregion Mensaje para el usuario del sistema

                        #endregion Envios tipo Mensajes del sistema

                        #region Mensaje para direccion de correo especifica
                        HashSet<decimal> usuariosDestinatarios = new HashSet<decimal>();
                        
                        string asunto = "Alarma del CBAFlow";
                        string texto = "<html><body>" + mensaje + "<br><br><a href='" + Traducciones.Link_al_CBAFlow + "'>Ir al sistema.</a></body></html>";

                        #region Mandar correo a la direccion dada
                        // Se envia un correo electronico a la direccion definida en la alarma y al usuario definido
                        if (!alarma[AlarmasService.Mail_NombreCol].Equals(DBNull.Value))
                        {
                            using (EmailService correo = new EmailService(usar_smtp_cliente, sesion))
                            {
                                correo.EnviarMail(alarma[AlarmasService.Mail_NombreCol].ToString(), asunto, texto);
                            }
                        }
                        #endregion Mandar correo a la direccion dada

                        #region Mandar el correo al usuario especificado

                        if (!alarma[AlarmasService.UsuarioId_NombreCol].Equals(DBNull.Value) && (decimal)alarma[AlarmasService.TipoEnvioParaUsuario_NombreCol] == Definiciones.AlarmasTiposEnvio.Email)
                        {
                            DataTable dtUsuario = new UsuariosService().GetUsuario((decimal)alarma[AlarmasService.UsuarioId_NombreCol]);
                            string mailUsuario = dtUsuario.Rows[0][UsuariosService.Email_NombreCol].ToString();

                            //Verificar que no se este enviando el correo a la misma direccion
                            if (!alarma[AlarmasService.Mail_NombreCol].Equals(mailUsuario))
                            {
                                using (EmailService correo = new EmailService(usar_smtp_cliente, sesion))
                                {
                                    correo.EnviarMail(mailUsuario, asunto, texto);
                                }
                            }
                        }
                        #endregion Mandar el correo al usuario especificado

                        // CODIGO POR SI SE SUGIERE ENVIAR CORREO A TODOS LOS USUARIOS CON EL ROL, NO SOLO MENSAJE DE SISTEMA!
                        //string direccion_destino;
                        //if (false)
                        //{
                        //    DataTable dtUsuarios = new UsuariosRolesService().GetUsuariosRolesDataTable(UsuariosRolesService.RolId_NombreCol + " = " + alarma[AlarmasService.RolId_NombreCol].ToString(), string.Empty);
                        //    for (int j = 0; j < dtUsuarios.Rows.Count; j++)
                        //        usuariosDestinatarios.Add((decimal)dtUsuarios.Rows[j][UsuariosRolesService.UsuraioId_NombreCol]);

                        //    foreach (decimal usuarioId in usuariosDestinatarios)
                        //    {
                        //        DataTable dtUsuario = new UsuariosService().GetUsuario(usuarioId);
                        //        direccion_destino = (string)dtUsuario.Rows[0][UsuariosService.Email_NombreCol];

                        //        correo.EnviarMail((string)usuario_creador_del_caso.Rows[0][UsuariosService.Email_NombreCol], direccion_destino, asunto, texto);
                        //    }
                        //}

                        #endregion Mensaje para direccion de correo especifica
                    }
                    #endregion Envio del mensaje
                }
                catch (System.Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion EvaluarAlarmasRegistroNuevo

        #region EvaluarAlarmasSQL
        private static void EvaluarAlarmasSQL(DataRow alarma)
        {
            EvaluarAlarmasSQL(alarma, false);
        }

        private static void EvaluarAlarmasSQL(DataRow alarma, bool usar_smtp_cliente)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    #region Generar el mensaje
                    // Se genera un sql para enviar una query a la base de datos en la que se buscan casos de un flujo que hayan transicionado a un estado dado en el ultimo dia
                    string sql = (string)alarma[AlarmasService.SQL_NombreCol];

                    // Se ejecuta el query y se lo guarda en una datatable
                    DataTable registrosEncontrados = new DataTable();
                    registrosEncontrados = sesion.Db.EjecutarQuery(sql);

                    string mensaje = string.Empty;

                    // Si el datatable tiene mas de un registro, la alarma debe ser activada
                    if (registrosEncontrados.Rows.Count > 0 && alarma[AlarmasService.ExistenciaMayorCero_NombreCol].Equals(Definiciones.SiNo.Si))
                    {
                        if (alarma[AlarmasService.Resumido_NombreCol].Equals(Definiciones.SiNo.Si))
                        {
                            mensaje = "Se han encontrado " + registrosEncontrados.Rows.Count + " registros de la alarma " + (string)alarma[AlarmasService.Nombre_NombreCol] + ".";
                        }
                    }
                    else if (registrosEncontrados.Rows.Count <= 0 && alarma[AlarmasService.ExistenciaMayorCero_NombreCol].Equals(Definiciones.SiNo.No))
                    {
                        mensaje = "No se ha encontrado ningún registro de la alarma " + (string)alarma[AlarmasService.Nombre_NombreCol] + ".";
                    }
                    #endregion Generar el mensaje

                    #region Envio del mensaje
                    // Se envia el mensaje a quien corresponda
                    if (alarma[AlarmasService.Resumido_NombreCol].Equals(Definiciones.SiNo.Si))
                    {
                        if (!mensaje.Equals(string.Empty))
                        {
                            #region Envios tipo Mensajes del sistema

                            string htmlMensaje = "<h2> Alarma del sistema! </h2>";
                            htmlMensaje += mensaje;

                            Hashtable campos = new Hashtable();

                            campos.Add(MensajesDeSistemaService.Estado_NombreCol, Definiciones.Estado.Activo);
                            campos.Add(MensajesDeSistemaService.FechaInicio_NombreCol, DateTime.Today);
                            campos.Add(MensajesDeSistemaService.Texto_NombreCol, htmlMensaje);
                            campos.Add(MensajesDeSistemaService.TipoMensaje_NombreCol, (decimal)alarma[AlarmasService.TipoAlarmaId_NombreCol]);

                            // Se envia mensaje de sistema a todos aquellos que tengan el rol determinado en la alarma

                            #region mensaje para el rol
                            if (!alarma[AlarmasService.RolId_NombreCol].Equals(DBNull.Value))
                            {
                                campos.Add(MensajesDeSistemaService.RolId_NombreCol, (decimal)alarma[AlarmasService.RolId_NombreCol]);
                                MensajesDeSistemaService.Guardar(campos, true);
                            }
                            #endregion mensaje para el rol

                            #region Mensaje para el usuario del sistema
                            if (!alarma[AlarmasService.UsuarioId_NombreCol].Equals(DBNull.Value))
                            {
                                bool userTieneRol = false;
                                if (!alarma[AlarmasService.RolId_NombreCol].Equals(DBNull.Value))
                                {
                                    DataTable dtUsuarioTieneRol = UsuariosRolesService.GetUsuariosRolesDataTable(UsuariosRolesService.RolId_NombreCol + " = " + alarma[AlarmasService.RolId_NombreCol].ToString() + " and " + UsuariosRolesService.UsuarioId_NombreCol + " = " + alarma[AlarmasService.UsuarioId_NombreCol], string.Empty, sesion);
                                    userTieneRol = dtUsuarioTieneRol.Rows.Count > 0;
                                }

                                //Enviar un mensaje de sistema
                                if ((decimal)alarma[AlarmasService.TipoEnvioParaUsuario_NombreCol] == Definiciones.AlarmasTiposEnvio.MensajeDeSistema)
                                {
                                    //Verificar si el usuario no tenia el rol asociado a la alarma
                                    if (!userTieneRol)
                                    {
                                        campos.Add(MensajesDeSistemaService.UsuarioId_NombreCol, (decimal)alarma[AlarmasService.UsuarioId_NombreCol]);
                                        MensajesDeSistemaService.Guardar(campos, true);
                                    }
                                }
                            }
                            #endregion Mensaje para el usuario del sistema

                            #endregion Envios tipo Mensajes del sistema

                            #region Mensaje para direccion de correo especifica
                            HashSet<decimal> usuariosDestinatarios = new HashSet<decimal>();
                            
                            string asunto = "Alarma del CBAFlow";
                            string texto = "<html><body>" + mensaje + "<br><br><a href='" + Traducciones.Link_al_CBAFlow + "'>Ir al sistema.</a></body></html>";

                            #region Mandar correo a la direccion dada
                            // Se envia un correo electronico a la direccion definida en la alarma y al usuario definido
                            if (!alarma[AlarmasService.Mail_NombreCol].Equals(DBNull.Value))
                            {
                                using (EmailService correo = new EmailService(usar_smtp_cliente, sesion))
                                {
                                    correo.EnviarMail(alarma[AlarmasService.Mail_NombreCol].ToString(), asunto, texto);
                                }
                            }
                            #endregion Mandar correo a la direccion dada

                            #region Mandar el correo al usuario especificado

                            if (!alarma[AlarmasService.UsuarioId_NombreCol].Equals(DBNull.Value) && (decimal)alarma[AlarmasService.TipoEnvioParaUsuario_NombreCol] == Definiciones.AlarmasTiposEnvio.Email)
                            {
                                DataTable dtUsuario = new UsuariosService().GetUsuario((decimal)alarma[AlarmasService.UsuarioId_NombreCol]);
                                string mailUsuario = dtUsuario.Rows[0][UsuariosService.Email_NombreCol].ToString();

                                //Verificar que no se este enviando el correo a la misma direccion
                                if (!alarma[AlarmasService.Mail_NombreCol].Equals(mailUsuario))
                                {
                                    using (EmailService correo = new EmailService(usar_smtp_cliente, sesion))
                                    {
                                        correo.EnviarMail(mailUsuario, asunto, texto);
                                    }
                                }
                            }
                            #endregion Mandar el correo al usuario especificado

                            #region Mandar el correo a todos los usuarios con el rol dado
                            string direccion_destino;
                            if (!alarma[AlarmasService.RolId_NombreCol].Equals(DBNull.Value))
                            {
                                DataTable dtUsuarios = UsuariosRolesService.GetUsuariosRolesDataTable(UsuariosRolesService.RolId_NombreCol + " = " + alarma[AlarmasService.RolId_NombreCol], string.Empty, sesion);
                                for (int j = 0; j < dtUsuarios.Rows.Count; j++)
                                    usuariosDestinatarios.Add((decimal)dtUsuarios.Rows[j][UsuariosRolesService.UsuarioId_NombreCol]);

                                foreach (decimal usuarioId in usuariosDestinatarios)
                                {
                                    DataTable dtUsuario = new UsuariosService().GetUsuario(usuarioId);
                                    direccion_destino = (string)dtUsuario.Rows[0][UsuariosService.Email_NombreCol];

                                    using (EmailService correo = new EmailService(usar_smtp_cliente, sesion))
                                    {
                                        correo.EnviarMail(direccion_destino, asunto, texto);
                                    }
                                }
                            }
                            #endregion Mandar el correo a todos los usuarios con el rol dado

                            #endregion Mensaje para direccion de correo especifica
                        }
                    }
                    else
                    {
                        foreach (DataRow fila in registrosEncontrados.Rows)
                        {
                            #region Envios tipo Mensajes del sistema

                            string htmlMensaje = "<h2> Alarma del sistema! </h2>";
                            htmlMensaje += (string)fila["Mensaje"];

                            Hashtable campos = new Hashtable();

                            campos.Add(MensajesDeSistemaService.Estado_NombreCol, Definiciones.Estado.Activo);
                            campos.Add(MensajesDeSistemaService.FechaInicio_NombreCol, DateTime.Today);
                            campos.Add(MensajesDeSistemaService.Texto_NombreCol, htmlMensaje);
                            campos.Add(MensajesDeSistemaService.TipoMensaje_NombreCol, (decimal)alarma[AlarmasService.TipoAlarmaId_NombreCol]);

                            // Se envia mensaje de sistema a todos aquellos que tengan el rol determinado en la alarma

                            #region mensaje para el rol
                            if (!alarma[AlarmasService.RolId_NombreCol].Equals(DBNull.Value))
                            {
                                campos.Add(MensajesDeSistemaService.RolId_NombreCol, (decimal)alarma[AlarmasService.RolId_NombreCol]);
                                MensajesDeSistemaService.Guardar(campos, true);
                            }
                            #endregion mensaje para el rol

                            #region Mensaje para el usuario del sistema
                            if (!alarma[AlarmasService.UsuarioId_NombreCol].Equals(DBNull.Value))
                            {
                                bool userTieneRol = false;
                                if (!alarma[AlarmasService.RolId_NombreCol].Equals(DBNull.Value))
                                {
                                    DataTable dtUsuarioTieneRol = UsuariosRolesService.GetUsuariosRolesDataTable(UsuariosRolesService.RolId_NombreCol + " = " + alarma[AlarmasService.RolId_NombreCol] + " and " + UsuariosRolesService.UsuarioId_NombreCol + " = " + alarma[AlarmasService.UsuarioId_NombreCol].ToString(), string.Empty, sesion);
                                    userTieneRol = dtUsuarioTieneRol.Rows.Count > 0;
                                }

                                //Enviar un mensaje de sistema
                                if ((decimal)alarma[AlarmasService.TipoEnvioParaUsuario_NombreCol] == Definiciones.AlarmasTiposEnvio.MensajeDeSistema)
                                {
                                    //Verificar si el usuario no tenia el rol asociado a la alarma
                                    if (!userTieneRol)
                                    {
                                        campos.Add(MensajesDeSistemaService.UsuarioId_NombreCol, (decimal)alarma[AlarmasService.UsuarioId_NombreCol]);
                                        MensajesDeSistemaService.Guardar(campos, true);
                                    }
                                }
                            }
                            #endregion Mensaje para el usuario del sistema

                            #endregion Envios tipo Mensajes del sistema

                            #region Mensaje para direccion de correo especifica
                            HashSet<decimal> usuariosDestinatarios = new HashSet<decimal>();
                            
                            string asunto = "Alarma del CBAFlow";
                            string texto = "<html><body>" + (string)fila["Mensaje"] + "<br><br><a href='" + Traducciones.Link_al_CBAFlow + "'>Ir al sistema.</a></body></html>";

                            #region Mandar correo a la direccion dada
                            // Se envia un correo electronico a la direccion definida en la alarma y al usuario definido
                            if (!alarma[AlarmasService.Mail_NombreCol].Equals(DBNull.Value))
                            {
                                using (EmailService correo = new EmailService(usar_smtp_cliente, sesion))
                                {
                                    correo.EnviarMail(alarma[AlarmasService.Mail_NombreCol].ToString(), asunto, texto);
                                }
                            }
                            #endregion Mandar correo a la direccion dada

                            #region Mandar el correo al usuario especificado

                            if (!alarma[AlarmasService.UsuarioId_NombreCol].Equals(DBNull.Value) && (decimal)alarma[AlarmasService.TipoEnvioParaUsuario_NombreCol] == Definiciones.AlarmasTiposEnvio.Email)
                            {
                                DataTable dtUsuario = new UsuariosService().GetUsuario((decimal)alarma[AlarmasService.UsuarioId_NombreCol]);
                                string mailUsuario = dtUsuario.Rows[0][UsuariosService.Email_NombreCol].ToString();

                                //Verificar que no se este enviando el correo a la misma direccion
                                if (!alarma[AlarmasService.Mail_NombreCol].Equals(mailUsuario))
                                {
                                    using (EmailService correo = new EmailService(usar_smtp_cliente, sesion))
                                    {
                                        correo.EnviarMail(mailUsuario, asunto, texto);
                                    }
                                }
                            }
                            #endregion Mandar el correo al usuario especificado

                            // CODIGO POR SI SE SUGIERE ENVIAR CORREO A TODOS LOS USUARIOS CON EL ROL, NO SOLO MENSAJE DE SISTEMA!
                            //string direccion_destino;
                            //if (false)
                            //{
                            //    DataTable dtUsuarios = new UsuariosRolesService().GetUsuariosRolesDataTable(UsuariosRolesService.RolId_NombreCol + " = " + alarma[AlarmasService.RolId_NombreCol].ToString(), string.Empty);
                            //    for (int j = 0; j < dtUsuarios.Rows.Count; j++)
                            //        usuariosDestinatarios.Add((decimal)dtUsuarios.Rows[j][UsuariosRolesService.UsuraioId_NombreCol]);

                            //    foreach (decimal usuarioId in usuariosDestinatarios)
                            //    {
                            //        DataTable dtUsuario = new UsuariosService().GetUsuario(usuarioId);
                            //        direccion_destino = (string)dtUsuario.Rows[0][UsuariosService.Email_NombreCol];

                            //        correo.EnviarMail((string)usuario_creador_del_caso.Rows[0][UsuariosService.Email_NombreCol], direccion_destino, asunto, texto);
                            //    }
                            //}

                            #endregion Mensaje para direccion de correo especifica
                        }
                    }
                    
                    #endregion Envio del mensaje
                }
                catch (System.Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion EvaluarAlarmasSQL

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ALARMAS"; }
        }
        public static string Descripcion_NombreCol
        {
            get { return ALARMASCollection.DESCRIPCIONColumnName; }
        }
        public static string EntidadId_NombreCol
        {
            get { return ALARMASCollection.ENTIDAD_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return ALARMASCollection.ESTADOColumnName; }
        }
        public static string ExistenciaMayorCero_NombreCol
        {
            get { return ALARMASCollection.EXISTENCIA_MAYOR_CEROColumnName; }
        }
        public static string FlujoEstadoId_NombreCol
        {
            get { return ALARMASCollection.FLUJO_ESTADO_IDColumnName; }
        }
        public static string FlujoId_NombreCol
        {
            get { return ALARMASCollection.FLUJO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ALARMASCollection.IDColumnName; }
        }
        public static string LogCampoId_NombreCol
        {
            get { return ALARMASCollection.LOG_CAMPO_IDColumnName; }
        }
        public static string Mail_NombreCol
        {
            get { return ALARMASCollection.MAILColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return ALARMASCollection.NOMBREColumnName; }
        }
        public static string Resumido_NombreCol
        {
            get { return ALARMASCollection.RESUMIDOColumnName; }
        }
        public static string RolId_NombreCol
        {
            get { return ALARMASCollection.ROL_IDColumnName; }
        }
        public static string SQL_NombreCol
        {
            get { return ALARMASCollection.SQLColumnName; }
        }
        public static string TipoAlarmaId_NombreCol
        {
            get { return ALARMASCollection.TIPO_ALARMA_IDColumnName; }
        }
        public static string TipoDato_NombreCol
        {
            get { return ALARMASCollection.TIPO_DATOColumnName; }
        }
        public static string TipoEnvioParaUsuario_NombreCol
        {
            get { return ALARMASCollection.TIPO_ENVIO_PARA_USUARIOColumnName; }
        }
        public static string TipoRango_NombreCol
        {
            get { return ALARMASCollection.TIPO_RANGOColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return ALARMASCollection.USUARIO_IDColumnName; }
        }
        public static string ValorInferior_NombreCol
        {
            get { return ALARMASCollection.VALOR_INFERIORColumnName; }
        }
        public static string ValorSuperior_NombreCol
        {
            get { return ALARMASCollection.VALOR_SUPERIORColumnName; }
        }
        public static string VistaFlujoDescripcion_NombreCol
        {
            get { return ALARMAS_INFO_COMPLETACollection.FLUJO_DESCRIPCIONColumnName; }
        }
        public static string VistaLogCampoCampoId_NombreCol
        {
            get { return ALARMAS_INFO_COMPLETACollection.LOG_CAMPO_CAMPO_IDColumnName; }
        }
        public static string VistaLogCampoTablaId_NombreCol
        {
            get { return ALARMAS_INFO_COMPLETACollection.LOG_CAMPO_TABLA_IDColumnName; }
        }
        public static string VistaRolDescripcion_NombreCol
        {
            get { return ALARMAS_INFO_COMPLETACollection.ROL_DESCRIPCIONColumnName; }
        }
        public static string VistaUsuarioApellido_NombreCol
        {
            get { return ALARMAS_INFO_COMPLETACollection.USUARIO_APELLIDOColumnName; }
        }
        public static string VistaUsuarioNombre_NombreCol
        {
            get { return ALARMAS_INFO_COMPLETACollection.USUARIO_NOMBREColumnName; }
        }
        public static string VistaUsuario_NombreCol
        {
            get { return ALARMAS_INFO_COMPLETACollection.USUARIOColumnName; }
        }
        #endregion Accessors
    }
}
