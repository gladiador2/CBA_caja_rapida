using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Base;
using System.Data;

namespace CBA.FlowV2.Framework.Common
{
    public static class SQL
    {
        public static string OR = "OR";
        public static string AND = "AND";
        /// <summary>
        /// Al agregar condiciones a una clasula es necesario saber si
        /// concatenamos la condicion con o sin la disyuncion "OR".
        /// </summary>
        /// <param name="clausula">La clausula.</param>
        /// <returns>" "OR" o String.Empty"</returns>
        public static string Or(string clausula)
        {
            return clausula.Length == 0 ? String.Empty : OR;
        }

        /// <summary>
        /// Al agregar condiciones a una clasula es necesario saber si
        /// concatenamos la condicion con o sin la disyuncion "OR".
        /// </summary>
        /// <param name="clausula">La clausula.</param>
        /// <returns>" "OR" o String.Empty"</returns>
        public static string Or(StringBuilder clausula)
        {
            return clausula.Length == 0 ? String.Empty : OR;
        }

        /// <summary>
        /// Al agregar condiciones a una clasula es necesario saber si
        /// concatenamos la condicion con o sin la conjuncion "AND".
        /// </summary>
        /// <param name="clausula">La clausula.</param>
        /// <returns>" "AND" o String.Empty"</returns>
        public static string And(string clausula)
        {
            return clausula.Length == 0 ? String.Empty : AND;
        }

        /// <summary>
        /// Al agregar condiciones a una clasula es necesario saber si
        /// concatenamos la condicion con o sin la conjuncion "AND".
        /// </summary>
        /// <param name="clausula">La clausula.</param>
        /// <returns>" "AND" o String.Empty"</returns>
        public static string And(StringBuilder clausula)
        {
            return clausula.Length == 0 ? String.Empty : AND;
        }

        #region ClausulaIn
        public static string ClausulaIn(string columna_in, DataTable dt, string columna_dt, bool valores_no_numericos)
        {
            StringBuilder sb = new StringBuilder();
            int contador;
            string comilla = valores_no_numericos ? "'" : string.Empty;

            sb.Append("(" + columna_in + " in (" + comilla + Definiciones.Error.Valor.EnteroPositivo + comilla);
            contador = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (contador > 999)
                {
                    sb.Append(") or " + columna_in + " in (" + comilla + Definiciones.Error.Valor.EnteroPositivo + comilla);
                    contador = 1;
                }
                sb.Append("," + comilla + dt.Rows[i][columna_dt] + comilla);
                contador++;
            }
            sb.Append("))");

            return sb.ToString();
        }
        #endregion ClausulaIn
    }
}
