#region Using
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
#endregion Using

namespace CBA.FlowV2.Services.Base
{
    public class SeguimientosDestinatariosService
    {
        #region EstaSiguiendo
        /// <summary>
        /// Estas the siguiendo.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="tabla_id">The tabla_id.</param>
        /// <param name="columna_id">The columna_id.</param>
        /// <param name="registro_id">The registro_id.</param>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <param name="mail">The mail.</param>
        /// <returns></returns>
        public static bool EstaSiguiendo(decimal caso_id, string tabla_id, string columna_id, decimal registro_id, decimal usuario_id, string mail)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas;
                SEGUIMIENTOS_DESTINATARIOSRow[] rows;

                if (caso_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    clausulas = SeguimientosDestinatariosService.LogCampoId_NombreCol + " = " + LogCamposService.GetLogCampos(tabla_id, columna_id) + " and " +
                                SeguimientosDestinatariosService.RegistroId_NombreCol + " = " + registro_id;
                }
                else
                {
                    clausulas = SeguimientosDestinatariosService.CasoId_NombreCol + " = " + caso_id;
                }

                if (usuario_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    clausulas += " and " + SeguimientosDestinatariosService.Mail_NombreCol + " = '" + mail + "' ";
                else
                    clausulas += " and " + SeguimientosDestinatariosService.UsuarioId_NombreCol + " = " + usuario_id;

                clausulas += " and " + SeguimientosDestinatariosService.FechaCancelaSeguimiento_NombreCol + " is null ";

                rows = sesion.Db.SEGUIMIENTOS_DESTINATARIOSCollection.GetAsArray(clausulas, string.Empty);

                return rows.Length > 0;
            }
        }
        #endregion EstaSiguiendo

        #region Evaluar
        public static void Evaluar(decimal caso_id, string tabla_id, string columna_id, decimal registro_id, SessionService sesion)
        {
            string clausulas, texto, asunto, direccion_destino;
            SEGUIMIENTOS_DESTINATARIOSRow[] rows;
            
            //Se crea la consulta para obtener los destinatarios
            if (caso_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
            {
                clausulas = SeguimientosDestinatariosService.LogCampoId_NombreCol + " = " + LogCamposService.GetLogCampos(tabla_id, columna_id) + " and " +
                            SeguimientosDestinatariosService.RegistroId_NombreCol + " = " + registro_id;

                asunto = "Se registraron cambios en la tabla " + tabla_id + " registro " + registro_id + ".";

                texto = "<html><body>" + asunto + "<br><br><a href='" + Traducciones.Link_al_CBAFlow + "'>Ir al sistema.</a></body></html>";
            }
            else
            {
                clausulas = SeguimientosDestinatariosService.CasoId_NombreCol + " = " + caso_id;
                asunto = "Se registraron cambios en el caso " + caso_id + " del flujo " + Definiciones.FlujosIDs.GetNombre(CasosService.GetFlujo(caso_id, sesion)) + ".";
                
                texto = "<html><body>" + asunto + "<br><br><a href='" + Traducciones.Link_al_CBAFlow + "'>Ir al sistema.</a></body></html>";
            }

            clausulas += " and " + SeguimientosDestinatariosService.FechaCancelaSeguimiento_NombreCol + " is null ";

            //Se obtienen los destinatarios
            rows = sesion.Db.SEGUIMIENTOS_DESTINATARIOSCollection.GetAsArray(clausulas, string.Empty);
            
            for (int i = 0; i < rows.Length; i++)
            {
                using (EmailService correo = new EmailService(false, sesion))
                {
                    if (rows[i].IsUSUARIO_IDNull)
                    {
                        direccion_destino = rows[i].MAIL;
                    }
                    else
                    {
                        DataTable dtUsuario = new UsuariosService().GetUsuario(rows[i].USUARIO_ID);
                        direccion_destino = (string)dtUsuario.Rows[0][UsuariosService.Email_NombreCol];
                    }

                    correo.EnviarMail(direccion_destino, asunto, texto);
                }
            }
        }

        public static void EvaluarPersonalizado(decimal caso_id, decimal usuarioDestinoId)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                using (EmailService correo = new EmailService(false, sesion))
                {
                    string texto, asunto, direccion_destino;

                    //Se crea la consulta para obtener los destinatarios
                    string nombreUsuarioAsignador = UsuariosService.GetNombreCompleto2(sesion.Usuario_Id);

                    asunto = "El usuario " + nombreUsuarioAsignador + " le ha asignado el caso " + caso_id + " del flujo " + Definiciones.FlujosIDs.GetNombre(CasosService.GetFlujo(caso_id, sesion)) + ".";

                    texto = "<html><body>" + asunto + "<br><br><a href='" + Traducciones.Link_al_CBAFlow + "'>Ir al sistema.</a></body></html>";


                    DataTable dtUsuario = new UsuariosService().GetUsuario(usuarioDestinoId);
                    direccion_destino = (string)dtUsuario.Rows[0][UsuariosService.Email_NombreCol];

                    if (direccion_destino.Trim().Length <= 0)
                        throw new Exception("El usuario al que se asigno el caso no tiene cargado su dirección de correo");

                    correo.EnviarMail(direccion_destino, asunto, texto);
                }
            }
            catch 
            {
                throw new Exception("Error al enviar mail");
            }
            
        }

        #endregion Evaluar

        #region QuitarSeguimiento
        /// <summary>
        /// Quitars the seguimiento.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="tabla_id">The tabla_id.</param>
        /// <param name="columna_id">The columna_id.</param>
        /// <param name="registro_id">The registro_id.</param>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <param name="mail">The mail.</param>
        public static void QuitarSeguimiento(decimal caso_id, string tabla_id, string columna_id, decimal registro_id, decimal usuario_id, string mail)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas, valorAnterior;
                SEGUIMIENTOS_DESTINATARIOSRow[] rows;

                if (caso_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    clausulas = SeguimientosDestinatariosService.LogCampoId_NombreCol + " = " + LogCamposService.GetLogCampos(tabla_id, columna_id) + " and " + 
                                SeguimientosDestinatariosService.RegistroId_NombreCol + " = " + registro_id;
                }
                else
                {
                    clausulas = SeguimientosDestinatariosService.CasoId_NombreCol + " = " + caso_id;
                }

                if (usuario_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    clausulas += " and " + SeguimientosDestinatariosService.Mail_NombreCol + " = '" + mail + "' ";
                else
                    clausulas += " and " + SeguimientosDestinatariosService.UsuarioId_NombreCol + " = " + usuario_id;

                clausulas += " and " + SeguimientosDestinatariosService.FechaCancelaSeguimiento_NombreCol + " is null ";

                rows = sesion.Db.SEGUIMIENTOS_DESTINATARIOSCollection.GetAsArray(clausulas, string.Empty);

                for (int i = 0; i < rows.Length; i++)
                {
                    valorAnterior = rows[i].ToString();
                    rows[i].FECHA_CANCELA_SEGUIMIENTO = DateTime.Now;
                    sesion.Db.SEGUIMIENTOS_DESTINATARIOSCollection.Update(rows[i]);
                    LogCambiosService.LogDeRegistro(SeguimientosDestinatariosService.Nombre_Tabla, rows[i].ID, valorAnterior, rows[i].ToString(), sesion);
                }
            }
        }
        #endregion QuitarSeguimiento

        #region AgregarSeguimiento
        /// <summary>
        /// Gets the porcentaje por id.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="tabla_id">The tabla_id.</param>
        /// <param name="columna_id">The columna_id.</param>
        /// <param name="registro_id">The registro_id.</param>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <param name="mail">The mail.</param>
        public static void AgregarSeguimiento(decimal caso_id, string tabla_id, string columna_id, decimal registro_id, decimal usuario_id, string mail)
        {
            using (SessionService sesion = new SessionService())
            {
                SEGUIMIENTOS_DESTINATARIOSRow row = new SEGUIMIENTOS_DESTINATARIOSRow();

                if (caso_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    row.LOG_CAMPO_ID = LogCamposService.GetLogCampos(tabla_id, columna_id);
                    row.REGISTRO_ID = registro_id;
                }
                else
                {
                    row.CASO_ID = caso_id;
                }

                row.FECHA_INICIA_SEGUIMIENTO = DateTime.Now;
                row.ID = sesion.Db.GetSiguienteSecuencia("seguimientos_destinatarios_sqc");

                if (usuario_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.MAIL = mail;
                else
                    row.USUARIO_ID = usuario_id;

                sesion.Db.SEGUIMIENTOS_DESTINATARIOSCollection.Insert(row);
                LogCambiosService.LogDeRegistro(SeguimientosDestinatariosService.Nombre_Tabla, row.ID, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);
            }
        }
        #endregion AgregarSeguimiento

        #region Accesors

        public static string Nombre_Tabla
        {
            get { return "SEGUIMIENTOS_DESTINATARIOS"; }
        }

        public static string CasoId_NombreCol
        {
            get { return SEGUIMIENTOS_DESTINATARIOSCollection.CASO_IDColumnName; }
        }
        public static string FechaCancelaSeguimiento_NombreCol
        {
            get { return SEGUIMIENTOS_DESTINATARIOSCollection.FECHA_CANCELA_SEGUIMIENTOColumnName; }
        }
        public static string FechaIniciaSeguimiento_NombreCol
        {
            get { return SEGUIMIENTOS_DESTINATARIOSCollection.FECHA_INICIA_SEGUIMIENTOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return SEGUIMIENTOS_DESTINATARIOSCollection.IDColumnName; }
        }
        public static string LogCampoId_NombreCol
        {
            get { return SEGUIMIENTOS_DESTINATARIOSCollection.LOG_CAMPO_IDColumnName; }
        }
        public static string Mail_NombreCol
        {
            get { return SEGUIMIENTOS_DESTINATARIOSCollection.MAILColumnName; }
        }
        public static string RegistroId_NombreCol
        {
            get { return SEGUIMIENTOS_DESTINATARIOSCollection.REGISTRO_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return SEGUIMIENTOS_DESTINATARIOSCollection.USUARIO_IDColumnName; }
        }
        #endregion Accesors
    }
}
