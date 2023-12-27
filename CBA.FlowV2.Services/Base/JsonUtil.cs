using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Data;

namespace CBA.FlowV2.Services.Base
{
    public class JsonUtil
    {
        public static string Serializar(object o)
        {
            return JsonConvert.SerializeObject(o, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        public static T Deserializar<T>(string texto)
        {
            return JsonConvert.DeserializeObject<T>(texto);
        }

        public static string SerializarDataTable(DataTable datos)
        {
            return Serializar(Common.Serializacion.DataTableSerializable(datos));
        }
    }
}
