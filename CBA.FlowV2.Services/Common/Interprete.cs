
using System;
using System.Linq; 
namespace CBA.FlowV2.Services.Common
{
    public static class Interprete
    {
        public static decimal ObtenerDecimal(object valor)
        {
            return valor is decimal ? (decimal)valor : decimal.Parse((string)valor);
        }

        public static string ObtenerString(object valor)
        {
            if (Interprete.EsNullODBNull(valor))
                return string.Empty;

            return valor is string ? (string)valor : valor.ToString();
        }
        
        public static bool EsNullODBNull(object objeto_a_probar)
        {
            return objeto_a_probar == null || DBNull.Value.Equals(objeto_a_probar);
        }

        /// <summary>
        /// Retorna true si el valor es igual cualquiera de los argumentos 
        /// siguientes
        /// </summary>
        /// <typeparam name="T"> Tipo que soporte Equals()</typeparam>
        /// <param name="valor">valor a ser comparado</param>
        /// <param name="parametros">lista de parametros variable</param>
        /// <returns></returns>
        public static bool In<T>(this T valor, params T[] parametros)
        {
            return parametros.Contains(valor);
        }

        public static decimal Redondear(decimal valor, int precision)
        {
            return decimal.Round(valor, precision, MidpointRounding.AwayFromZero);
        }
    }
}
