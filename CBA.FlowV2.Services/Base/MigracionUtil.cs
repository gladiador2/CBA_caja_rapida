using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace CBA.FlowV2.Services.Base
{
    //public class valores : CBAEdi.Cliente
    
    public class MigracionUtil
    {
        #region CrearMK2

        public static string CrearMK2(string entidad, object valor)
        {
            string urlBase = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.MigracionMK2);
            if (urlBase.Length <= 10)
                return "{}"; 
            //PARA QUE SE ACEPTE EL JSON EN EL MK2, LOS DATOS TIENEN QUE ESTAR DENTRO DE {"valores":{object}}
            string valoresJson = JsonUtil.Serializar(valor);
            //ESTO HAY QUE CAMBIAR
            valoresJson = "{\"valores\":" + valoresJson;
            valoresJson = valoresJson + "}";
            //NO TIENE QUE QUEDAR EN DURO 
            byte[] dataStream = Encoding.UTF8.GetBytes(valoresJson);

            WebRequest req = WebRequest.Create(urlBase + "/" + entidad.ToLower() +"/edi/crear");
            req.Method = "POST";
            req.ContentType = "application/json";
            req.ContentLength = valoresJson.Length;

            Stream newStream = req.GetRequestStream();
            newStream.Write(dataStream, 0, dataStream.Length);
            newStream.Close();

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader readStream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            string respuesta = readStream.ReadToEnd();
            Dictionary<string, object> resultado = JsonUtil.Deserializar<Dictionary<string, object>>(respuesta);
            resp.Close();
            readStream.Close();

            if (resultado == null)
                throw new Exception("Hubo un error en la respuesta a " + req.RequestUri.ToString());

            return respuesta;
        }
        #endregion CrearMK2

        #region BorrarMK2
        public static string BorrarMK2(string entidad, object valor)
        {
            string urlBase = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.MigracionMK2);
            if (urlBase.Length <= 10)
                return "{}";

            string valoresJson = JsonUtil.Serializar(valor);
            byte[] dataStream = Encoding.UTF8.GetBytes(valoresJson);

            WebRequest req = WebRequest.Create(urlBase + "/" + entidad + "/edi/borrar/");
            req.Method = "POST";
            req.ContentType = "application/json";
            req.ContentLength = valoresJson.Length;

            Stream newStream = req.GetRequestStream();
            newStream.Write(dataStream, 0, dataStream.Length);
            newStream.Close();

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader readStream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            string respuesta = readStream.ReadToEnd();
            Dictionary<string, object> resultado = JsonUtil.Deserializar<Dictionary<string, object>>(respuesta);
            resp.Close();
            readStream.Close();

            if (resultado == null)
                throw new Exception("Hubo un error en la respuesta a " + req.RequestUri.ToString());

            return respuesta;
        }
        #endregion BorrarMK2

        #region ModificarMK2
        public static string ModificarMK2(string entidad, object valor)
        {
            string urlBase = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.MigracionMK2);
            if (urlBase.Length <= 10)
                return "{}";

            string valoresJson = JsonUtil.Serializar(valor);
            byte[] dataStream = Encoding.UTF8.GetBytes(valoresJson);

            WebRequest req = WebRequest.Create(urlBase + "/" + entidad.ToLower() + "/edi/modificar");
            req.Method = "POST";
            req.ContentType = "application/json";
            req.ContentLength = valoresJson.Length;

            Stream newStream = req.GetRequestStream();
            newStream.Write(dataStream, 0, dataStream.Length);
            newStream.Close();

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader readStream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            string respuesta = readStream.ReadToEnd();
            Dictionary<string, object> resultado = JsonUtil.Deserializar<Dictionary<string, object>>(respuesta);
            resp.Close();
            readStream.Close();

            if (resultado == null)
                throw new Exception("Hubo un error en la respuesta a " + req.RequestUri.ToString());

            return respuesta;
        }
        #endregion ModificarMK2
    }
}
