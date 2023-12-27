using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CBA.FlowV2.Services.Base
{
    public class StringUtil
    {
        public static string MayusculaPrimero(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public static string TodoMayuscula(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            s = s.ToUpper();

            return s;
        }

        #region FormatearNumero
        public static string FormatearNumero(object numero, string cadena_decimales)
        {
            return FormatearNumero(double.Parse(numero.ToString()), cadena_decimales);
        }
        public static string FormatearNumero(decimal numero, string cadena_decimales)
        {
            return FormatearNumero((double)numero, cadena_decimales);
        }
        public static string FormatearNumero(double numero, string cadena_decimales)
        {
            return numero.ToString(cadena_decimales);
        }

        public static string FormatearNumero(decimal numero, int cantidad_decimales)
        {
            return FormatearNumero((double)numero, cantidad_decimales);
        }
        public static string FormatearNumero(double numero, int cantidad_decimales)
        {
            return Math.Round(numero, cantidad_decimales).ToString();
        }
        #endregion FormatearNumero

        #region CrearHash
        /// <summary>
        /// Crears the hash.
        /// </summary>
        /// <param name="largo">The largo.</param>
        /// <returns></returns>
        public static string CrearHash(int largo)
        {
            string input = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random(DateTime.Now.Millisecond * DateTime.Now.Second);
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            char ch;
            for (int i = 0; i < largo; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }
            return builder.ToString();
        }
        #endregion CrearHash

        #region QuitarCaracteresNoImprimibles
        public static string QuitarCaracteresNoImprimibles(object valor)
        {
            string texto = string.Empty;
            if (valor != null)
                texto = valor.ToString();
            return Regex.Replace(texto, @"\p{C}+", string.Empty);
        }
        #endregion QuitarCaracteresNoImprimibles
    }
}
