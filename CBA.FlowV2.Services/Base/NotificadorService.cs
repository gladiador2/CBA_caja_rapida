#region using
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using CBA.FlowV2.Services.Sesion;

using System.Collections.Generic;
using System.Windows.Forms;

#endregion using

namespace CBA.FlowV2.Services.Base
{
    public class NotificadorService
    {
        #region Propiedades

        private static string _URLRegistrar = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.DireccionServidorDjango) + "/notificaciones/registrar/";
        private static string _URLTracker = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.DireccionServidorDjango) + "/notificaciones/tracker/";
        private static string _URLInterfaz = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.DireccionServidorDjango) + "/notificaciones/";
        private static string _URLEnviar = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.DireccionServidorDjango) + "/notificaciones/nuevo/";

        #region Accesores

        public static string URLInterfaz
        {
            get { return _URLInterfaz; }
        }
        public static string URLTracker
        {
            get { return _URLTracker; }
        }
        #endregion Accesores

        #endregion Propiedades

        public static bool Registrar()
        {
            try
            {
                SessionService sesion = new SessionService();
                NameValueCollection parametros = HttpUtility.ParseQueryString(String.Empty);

                parametros.Add("aplicacion", VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.TnsName));
                parametros.Add("usuario", sesion.Usuario.ID.ToString());
                parametros.Add("token", sesion.Usuario.SESION.ToString());

                byte[] byteArray = Encoding.UTF8.GetBytes(parametros.ToString());

                string url = _URLRegistrar;
                
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Los recordatorios no se encuentran disponibles");

                return false;
            }
        }

        public static bool Enviar(string[] receptor, string titulo, string mensaje)
        {
            string receptores = string.Join(",", receptor);
            return Enviar(receptores, titulo, mensaje);
        }

        public static bool Enviar(string receptor, string titulo, string mensaje)
        {
            return Enviar(receptor, titulo, mensaje, false, false, string.Empty);
        }

        public static bool Enviar(string[] receptor, string titulo, string mensaje, Boolean alarma, Boolean importante, string fecha)
        { 
            string receptores = string.Join(",", receptor);
            return Enviar(receptores, titulo, mensaje, alarma, importante, fecha);
        }

        public static bool Enviar(string receptor, string titulo, string mensaje, Boolean alarma, Boolean importante, string fecha)
        {
            using (SessionService sesion = new SessionService())
            { 
                return Enviar(receptor, titulo, mensaje, alarma, importante, fecha, sesion);
            }
        }

        public static bool Enviar(string receptor, string titulo, string mensaje, Boolean alarma, Boolean importante, string fecha, SessionService sesion)
        {
            try
            {
                NameValueCollection parametros = HttpUtility.ParseQueryString(String.Empty);

                int dif;
                if (fecha == string.Empty)
                    dif = 0;
                else
                    dif = (int)(DateTime.Parse(fecha) - DateTime.Now).TotalMilliseconds;
                
                parametros.Add("aplicacion", VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.TnsName));
                parametros.Add("usuario", sesion.Usuario.ID.ToString());
                parametros.Add("token", sesion.Usuario.SESION.ToString());
                parametros.Add("receptor", receptor);
                parametros.Add("fecha", dif.ToString());
                parametros.Add("titulo", titulo);
                parametros.Add("mensaje", mensaje);
                parametros.Add("alarma", alarma.ToString());
                parametros.Add("importante", importante.ToString());

                byte[] byteArray = Encoding.UTF8.GetBytes(parametros.ToString());

                string url = _URLEnviar;

                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
