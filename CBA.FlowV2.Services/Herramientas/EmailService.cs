using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Web.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using CBA.FlowV2.Services.Common;

namespace CBA.FlowV2.Services.Herramientas
{
    public class EmailService : IDisposable
    {
        #region propiedades
              

        private string nombreDeUsuario;
        private string contrasena;
        private string STMPHost;
        private decimal puerto;
        #endregion

        public string Usuario
        {
            get { return this.nombreDeUsuario; }
        }

        public EmailService(bool usar_smtp_cliente, SessionService sesion)
        {
            DataTable dt = null;

            if (usar_smtp_cliente)
                dt = new EntidadesConfiguracionMailService().GetEntidadesConfigEmailDataTable(2, sesion);

            if (!usar_smtp_cliente || dt.Rows.Count <= 0)
                dt = new EntidadesConfiguracionMailService().GetEntidadesConfigEmailDataTable(1, sesion);

            if (dt.Rows.Count <= 0)
                throw new Exception("EmailService(). Error de configuracion para envio de mails.");

            this.contrasena = dt.Rows[0][EntidadesConfiguracionMailService.Contrasena_NombreCol].ToString();
            this.nombreDeUsuario = dt.Rows[0][EntidadesConfiguracionMailService.NombreUsuario_NombreCol].ToString();
            this.STMPHost = dt.Rows[0][EntidadesConfiguracionMailService.ServidorSMTP_NombreCol].ToString();
            this.puerto = (decimal)dt.Rows[0][EntidadesConfiguracionMailService.Puerto_NombreCol];
        }
        public EmailService(string user, string pass, string host)
        {

            this.contrasena = pass;
            this.nombreDeUsuario = user;
            this.STMPHost = host;
        }


        public bool EnviarMail(string direccion_destino, string asunto, string mensaje)
        {
            using (SessionService sesion = new SessionService())
            {
                return EnviarMail(direccion_destino, asunto, mensaje, sesion);
            }
        }

        public bool EnviarMail(string direccion_destino, string asunto, string mensaje, SessionService sesion)
        {
            return EnviarMail(direccion_destino, asunto, mensaje, sesion, string.Empty);
        }

        public bool EnviarMail(string direccion_destino, string asunto, string mensaje, SessionService sesion, string archivo_adjunto)
        {
            return EnviarMail(direccion_destino, asunto, mensaje, sesion, archivo_adjunto, 6);
        }

        public bool EnviarMail(string direccion_destino, string asunto, string mensaje, SessionService sesion, string archivo_adjunto, int archivo_adjunto_reintentos)
        {
            return EnviarMail(new string[] { direccion_destino }, asunto, mensaje, sesion, archivo_adjunto, archivo_adjunto_reintentos);
        }

        public bool EnviarMail(string[] direcciones_destino, string asunto, string mensaje, SessionService sesion, string archivo_adjunto, int archivo_adjunto_reintentos)
        { 
            try
            {
                System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
                correo.IsBodyHtml = true;
                
                for (int i = 0; i < direcciones_destino.Length; i++)
                {
                    if (direcciones_destino[i] == string.Empty)
                        continue;

                    foreach (var direccion in direcciones_destino[i].Split(';'))
                        correo.To.Add(new MailAddress(direccion));
                }

                if (correo.To.Count <= 0)
                    return false;
                
                correo.Subject = asunto;

                correo.From = new System.Net.Mail.MailAddress(this.nombreDeUsuario);
                correo.Body = mensaje;

                #region Archivo adjunto
                if (!archivo_adjunto.Equals(string.Empty))
                {
                    //Workaround por no existir un callback cuando termino de crearse el archivo
                    int reintentos = archivo_adjunto_reintentos;
                    Exception excepcion = null;
                    while (reintentos > 0)
                    {
                        try
                        {
                            System.Threading.Thread.Sleep(1000);
                            correo.Attachments.Add(new Attachment(archivo_adjunto));
                            break;
                        }
                        catch(Exception e)
                        {
                            reintentos--;
                            excepcion = e;
                            System.Threading.Thread.Sleep(5000);//Esperar 5 segundos
                        }

                        if (reintentos == 0 && excepcion != null)
                            throw excepcion;
                    }
                }
                #endregion Archivo adjunto

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(this.STMPHost);
                smtp.Port = (int)this.puerto;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential(this.nombreDeUsuario, this.contrasena);
            
                ServicePointManager.ServerCertificateValidationCallback =
                  delegate(object s
                      , X509Certificate certificate
                      , X509Chain chain
                      , SslPolicyErrors sslPolicyErrors)
                  { return true; };
               
                smtp.Send(correo);
            }
            catch (Exception)
            {
                return false;
            }

            return true;

        }

        #region IDisposable Members
        public void Dispose()
        {
        }
        #endregion
    }
}
