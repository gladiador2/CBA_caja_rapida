using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CBA.FlowV2.Services.Reportes.Configuraciones
{
    public static class ConfiguracionesReportes
    {
        public static string pathAplicacionReportes = ConfiguracionesReportes.GetRuta();

        private static string GetRuta()
        {
            string ruta;
            string strAux, strBorrar;
            int indice1, indice2;
            Uri url = HttpContext.Current.Request.Url;

            //Obtener la subcadena desde el nombre de aplicacion
            strAux = Uri.SchemeDelimiter + url.Host;
            indice1 = url.AbsoluteUri.IndexOf(strAux);
            strAux = url.AbsoluteUri.Substring(indice1 + strAux.Length);

            //Se obtiene lo que se encuentra entre dos barras
            indice1 = strAux.IndexOf("/");
            indice2 = strAux.Substring(indice1 + 1).IndexOf("/");
            strAux = strAux.Substring(indice1, indice2 - indice1 + 1);

            //Si el reporte es lanzado desde un webservice debe quitarse '_webservices'
            //del path para obtener la direccion base del sistema del cliente
            strBorrar = "_webservices";
            indice1 = strAux.IndexOf(strBorrar);
            strAux = (indice1 < 0)
                     ? strAux
                     : strAux.Remove(indice1, strBorrar.Length);

            ruta = String.Format("{0}{1}{2}{3}{4}",
                             url.Scheme,
                             Uri.SchemeDelimiter,
                             url.Host,
                             strAux,
                             "_reportes/Default.aspx");
            return ruta;
        }
    }
}
