using System.Linq.Expressions;
using System;
using CBA.FlowV2.Services.Sesion;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using CBA.FlowV2.Services.Articulos;
using System.Net;
using System.IO;
using System.Text;
using CBA.FlowV2.Services.Herramientas;
using System.Linq;
namespace CBA.FlowV2.Services.Base
{
    public class RecomendadoresService
    {
        #region Propiedades
        public int Tipo;
        public string URL;
        #endregion Propiedades

        #region Get
        public static ArticulosService[] Get(int tipo, Hashtable datos, SessionService sesion)
        {
            string json = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.Recomendadores);
            RecomendadoresService[] recomendadores = JsonUtil.Deserializar<RecomendadoresService[]>(json);

            RecomendadoresService recomendador = null;
            foreach (var r in recomendadores)
            {
                if (r.Tipo == tipo)
                {
                    switch (r.Tipo)
                    { 
                        case Definiciones.Recomendadores.PorArticulo:
                            recomendador = new RecomendadorPorArticulo{ Tipo = r.Tipo, URL = r.URL };
                            break;
                        case Definiciones.Recomendadores.PorPersona:
                            recomendador = new RecomendadorPorPersona { Tipo = r.Tipo, URL = r.URL };
                            break;
                        default:
                            throw new Exception("RecomendadoresService. Recomendador tipo " + tipo + " no implementado.");
                    }
                    break;
                }
            }

            return recomendador.ConsumirWS(datos, sesion);
        }
        #endregion Get

        protected ArticulosService[] ConsumirWS(WebRequest req, SessionService sesion)
        {
            List<ArticulosService> lArticulos = new List<ArticulosService>();

            req.Method = "GET";

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader readStream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);

            string respuesta = readStream.ReadToEnd();
            if (respuesta == "{}")
                return new ArticulosService[0];

            Dictionary<string, object> recomendadores = JsonUtil.Deserializar<Dictionary<string, object>>(respuesta);
            Dictionary<string, object> dAux;
            resp.Close();
            readStream.Close();

            #region recomendadores
            if (recomendadores.ContainsKey("random"))
            {
                dAux = JsonUtil.Deserializar<Dictionary<string, object>>(recomendadores["random"].ToString());
                if (dAux.ContainsKey("recomendacion"))
                {
                    List<Dictionary<string, object>> lRecomendaciones = JsonUtil.Deserializar<List<Dictionary<string, object>>>(dAux["recomendacion"].ToString());
                    foreach (Dictionary<string, object> item in lRecomendaciones)
                        lArticulos.Add(new ArticulosService(decimal.Parse(item["articulo"].ToString()), sesion));
                }
            }
            else if (recomendadores.ContainsKey("distancia_item"))
            {
                dAux = JsonUtil.Deserializar<Dictionary<string, object>>(recomendadores["distancia_item"].ToString());
                if (dAux.ContainsKey("recomendacion"))
                {
                    List<Dictionary<string, object>> lRecomendaciones = JsonUtil.Deserializar<List<Dictionary<string, object>>>(dAux["recomendacion"].ToString());
                    foreach (Dictionary<string, object> item in lRecomendaciones)
                        lArticulos.Add(new ArticulosService(decimal.Parse(item["articulo"].ToString()), sesion));
                }
            }

            if (recomendadores.ContainsKey("experto"))
            {
                dAux = JsonUtil.Deserializar<Dictionary<string, object>>(recomendadores["experto"].ToString());
                if (dAux.ContainsKey("recomendacion"))
                {
                    List<Dictionary<string, object>> lRecomendaciones = JsonUtil.Deserializar<List<Dictionary<string, object>>>(dAux["recomendacion"].ToString());
                    foreach (Dictionary<string, object> item in lRecomendaciones)
                        lArticulos.Add(new ArticulosService(decimal.Parse(item["articulo"].ToString()), sesion));
                }
            }

            if (recomendadores.ContainsKey("empresa"))
            {
                dAux = JsonUtil.Deserializar<Dictionary<string, object>>(recomendadores["empresa"].ToString());
                if (dAux.ContainsKey("recomendacion"))
                {
                    List<Dictionary<string, object>> lRecomendaciones = JsonUtil.Deserializar<List<Dictionary<string, object>>>(dAux["recomendacion"].ToString());
                    foreach (Dictionary<string, object> item in lRecomendaciones)
                        lArticulos.Add(new ArticulosService(decimal.Parse(item["articulo"].ToString()), sesion));
                }
            }

            if (recomendadores.ContainsKey("colaborativo_item_als"))
            {
                dAux = JsonUtil.Deserializar<Dictionary<string, object>>(recomendadores["colaborativo_item_als"].ToString());
                if (dAux.ContainsKey("recomendacion"))
                {
                    List<Dictionary<string, object>> lRecomendaciones = JsonUtil.Deserializar<List<Dictionary<string, object>>>(dAux["recomendacion"].ToString());
                    foreach (Dictionary<string, object> item in lRecomendaciones)
                        lArticulos.Add(new ArticulosService(decimal.Parse(item["articulo"].ToString()), sesion));
                }
            }

            if (recomendadores.ContainsKey("colaborativo_item_bm25"))
            {
                dAux = JsonUtil.Deserializar<Dictionary<string, object>>(recomendadores["colaborativo_item_bm25"].ToString());
                if (dAux.ContainsKey("recomendacion"))
                {
                    List<Dictionary<string, object>> lRecomendaciones = JsonUtil.Deserializar<List<Dictionary<string, object>>>(dAux["recomendacion"].ToString());
                    foreach (Dictionary<string, object> item in lRecomendaciones)
                        lArticulos.Add(new ArticulosService(decimal.Parse(item["articulo"].ToString()), sesion));
                }
            }

            if (recomendadores.ContainsKey("colaborativo_item_cosine"))
            {
                dAux = JsonUtil.Deserializar<Dictionary<string, object>>(recomendadores["colaborativo_item_cosine"].ToString());
                if (dAux.ContainsKey("recomendacion"))
                {
                    List<Dictionary<string, object>> lRecomendaciones = JsonUtil.Deserializar<List<Dictionary<string, object>>>(dAux["recomendacion"].ToString());
                    foreach (Dictionary<string, object> item in lRecomendaciones)
                        lArticulos.Add(new ArticulosService(decimal.Parse(item["articulo"].ToString()), sesion));
                }
            }

            if (recomendadores.ContainsKey("multiobjetivo_opcion1"))
            {
                dAux = JsonUtil.Deserializar<Dictionary<string, object>>(recomendadores["multiobjetivo_opcion1"].ToString());
                if (dAux.ContainsKey("recomendacion"))
                {
                    List<Dictionary<string, object>> lRecomendaciones = JsonUtil.Deserializar<List<Dictionary<string, object>>>(dAux["recomendacion"].ToString());
                    foreach (Dictionary<string, object> item in lRecomendaciones)
                        lArticulos.Add(new ArticulosService(decimal.Parse(item["articulo"].ToString()), sesion));
                }
            }

            if (recomendadores.ContainsKey("multiobjetivo_opcion2"))
            {
                dAux = JsonUtil.Deserializar<Dictionary<string, object>>(recomendadores["multiobjetivo_opcion2"].ToString());
                if (dAux.ContainsKey("recomendacion"))
                {
                    List<Dictionary<string, object>> lRecomendaciones = JsonUtil.Deserializar<List<Dictionary<string, object>>>(dAux["recomendacion"].ToString());
                    foreach (Dictionary<string, object> item in lRecomendaciones)
                        lArticulos.Add(new ArticulosService(decimal.Parse(item["articulo"].ToString()), sesion));
                }
            }

            if (recomendadores.ContainsKey("multiobjetivo_opcion3"))
            {
                dAux = JsonUtil.Deserializar<Dictionary<string, object>>(recomendadores["multiobjetivo_opcion3"].ToString());
                if (dAux.ContainsKey("recomendacion"))
                {
                    List<Dictionary<string, object>> lRecomendaciones = JsonUtil.Deserializar<List<Dictionary<string, object>>>(dAux["recomendacion"].ToString());
                    foreach (Dictionary<string, object> item in lRecomendaciones)
                        lArticulos.Add(new ArticulosService(decimal.Parse(item["articulo"].ToString()), sesion));
                }
            }

            if (recomendadores.ContainsKey("multiobjetivo_opcion4"))
            {
                dAux = JsonUtil.Deserializar<Dictionary<string, object>>(recomendadores["multiobjetivo_opcion4"].ToString());
                if (dAux.ContainsKey("recomendacion"))
                {
                    List<Dictionary<string, object>> lRecomendaciones = JsonUtil.Deserializar<List<Dictionary<string, object>>>(dAux["recomendacion"].ToString());
                    foreach (Dictionary<string, object> item in lRecomendaciones)
                        lArticulos.Add(new ArticulosService(decimal.Parse(item["articulo"].ToString()), sesion));
                }
            }

            if (recomendadores.ContainsKey("colaborativo_usuario"))
            {
                dAux = JsonUtil.Deserializar<Dictionary<string, object>>(recomendadores["colaborativo_usuario"].ToString());
                if (dAux.ContainsKey("recomendacion"))
                {
                    List<Dictionary<string, object>> lRecomendaciones = JsonUtil.Deserializar<List<Dictionary<string, object>>>(dAux["recomendacion"].ToString());
                    foreach (Dictionary<string, object> item in lRecomendaciones)
                        lArticulos.Add(new ArticulosService(decimal.Parse(item["articulo"].ToString()), sesion));
                }
            }
            #endregion recomendadores

            //Evitar duplicacion de articulos
            var articulosDistintos = lArticulos.GroupBy(a => a.Id.Value).Select(grp => grp.ToList());
            ArticulosService[] aArticulos = new ArticulosService[articulosDistintos.Count<List<ArticulosService>>()];
            int contador = 0;
            foreach (var a in articulosDistintos)
                aArticulos[contador++] = a.First<ArticulosService>();

            return aArticulos;
        }

        //Metodo que debe ser redefinido en cada clase que hereda
        public virtual ArticulosService[] ConsumirWS(Hashtable datos, SessionService sesion) { return new ArticulosService[0]; }

        #region Clase RecomendadorPorArticulo
        private class RecomendadorPorArticulo : RecomendadoresService
        {
            #region ConsumirWS
            public override ArticulosService[] ConsumirWS(Hashtable datos, SessionService sesion)
            {
                ArticulosService articulo = (ArticulosService)datos["articulo"];
                WebRequest req = WebRequest.Create(this.URL + "/" + articulo.Id.Value);
                return ConsumirWS(req, sesion);
            }
            #endregion ConsumirWS
        }
        #endregion Clase RecomendadorPorArticulo

        #region Clase RecomendadorPorPersona
        private class RecomendadorPorPersona : RecomendadoresService
        {
            #region ConsumirWS
            public override ArticulosService[] ConsumirWS(Hashtable datos, SessionService sesion)
            {
                PersonasService persona = (PersonasService)datos["persona"];
                WebRequest req = WebRequest.Create(this.URL + "/" + persona.Id.Value);
                return ConsumirWS(req, sesion);
            }
            #endregion ConsumirWS
        }
        #endregion Clase RecomendadorPorPersona
    }
}
