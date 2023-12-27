#region using
using System;
using System.IO;
using System.Net;
using CBA.FlowV2.Services.Sesion;

#endregion using

namespace CBA.FlowV2.Services.Base
{
    public class SMS
    {
        private class mensaje
        {
            public string msisdn { get; set; } //Destinatario
            public string msg { get; set; } //Texto del mensaje
            public string operadora { get; set; }
        }

        private class paqueteSimple
        {
            public string client_id { get; set; }
            public string api_key { get; set; }
            public mensaje sms_data { get; set; }

            public paqueteSimple(string destinatario, string mensaje, string operadora)
            {
                this.client_id = "f6db53f6-3025-4c3b-a302-143e3eabe108";
                this.api_key = "bd9df46f-0ddd-4bb4-b2e2-e3b77459fc68";

                this.sms_data = new mensaje();
                this.sms_data.msisdn = destinatario;
                this.sms_data.msg = mensaje;
                this.sms_data.operadora = operadora;
            }

            public string GetJSON()
            {
                return JsonUtil.Serializar(this);
            }
        }

        public static void EnviarMenuMovil(string numero_destino, string mensaje, string telefonia, SessionService sesion)
        {
            try
            {
                string url = "https://cph.menumovil.com/api/smsgateway/add/";
                paqueteSimple paquete = new paqueteSimple(numero_destino, mensaje, telefonia);
                string json = paquete.GetJSON();

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "POST";
                
                //Ignorar el certificado
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    delegate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                                            System.Security.Cryptography.X509Certificates.X509Chain chain,
                                            System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true; // **** Always accept
                    };

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
