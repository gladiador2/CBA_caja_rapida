using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;

namespace CBA.FlowV2.Services.Base
{
    public static class ContrasenhasUtil
    {
        public sealed class ContrasenhasRequisitosMinimos
        {
            public static readonly ContrasenhasRequisitosMinimos Instancia = new ContrasenhasRequisitosMinimos();

            public int longitudMinima { get; private set; }
            public int letrasMayusculas { get; private set; }
            public int letrasMinusculas { get; private set; }
            public int numeros { get; private set; }
            public int simbolos { get; private set; }

            private ContrasenhasRequisitosMinimos()
            {
                this.longitudMinima = 0;
                this.letrasMayusculas = 0;
                this.letrasMinusculas = 0;
                this.numeros = 0;
                this.simbolos = 0;

                string json = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.ContrasenhaRequerimientosMinimos);
                Hashtable configuracion = JsonUtil.Deserializar<Hashtable>(json);
                if (configuracion.ContainsKey("longitudMinima"))
                    this.longitudMinima = int.Parse(configuracion["longitudMinima"].ToString());
                if (configuracion.ContainsKey("letrasMayusculas"))
                    this.letrasMayusculas = int.Parse(configuracion["letrasMayusculas"].ToString());
                if (configuracion.ContainsKey("letrasMinusculas"))
                    this.letrasMinusculas = int.Parse(configuracion["letrasMinusculas"].ToString());
                if (configuracion.ContainsKey("numeros"))
                    this.numeros = int.Parse(configuracion["numeros"].ToString());
                if (configuracion.ContainsKey("simbolos"))
                    this.simbolos = int.Parse(configuracion["simbolos"].ToString());
            }

            public static bool Validar(string contrasenha, out string mensaje)
            {
                var deficiencias = new List<string>();
                int letrasMayusculas = 0;
                int letrasMinusculas = 0;
                int numeros = 0;
                int simbolos = 0;

                for (int i = 0; i < contrasenha.Length; i++)
			    {
                    if (char.IsUpper(contrasenha[i]))
                        letrasMayusculas++;
                    else if (char.IsLower(contrasenha[i]))
                        letrasMinusculas++;
                    else if (char.IsNumber(contrasenha[i]))
                        numeros++;
                    else
                        simbolos++;
			    }

                if (Instancia.longitudMinima > 0 && numeros+letrasMinusculas+letrasMayusculas+simbolos < Instancia.longitudMinima)
                    deficiencias.Add("Al menos " + Instancia.longitudMinima + (Instancia.longitudMinima == 1 ? " caracter." : " caracteres."));
                if (Instancia.letrasMayusculas > 0 && letrasMayusculas < Instancia.letrasMayusculas)
                    deficiencias.Add("Al menos " + Instancia.letrasMayusculas + (Instancia.letrasMayusculas == 1 ? " letra mayúscula." : " letras mayúsculas."));
                if (Instancia.letrasMinusculas > 0 && letrasMinusculas < Instancia.letrasMinusculas)
                    deficiencias.Add("Al menos " + Instancia.letrasMinusculas + (Instancia.letrasMinusculas == 1 ? " letra minúscula." : " letras minúsculas."));
                if (Instancia.numeros > 0 && numeros < Instancia.numeros)
                    deficiencias.Add("Al menos " + Instancia.numeros + (Instancia.numeros == 1 ? " número." : " números."));
                if (Instancia.simbolos > 0 && simbolos < Instancia.simbolos)
                    deficiencias.Add("Al menos " + Instancia.simbolos + (Instancia.simbolos == 1 ? " símbolo." : " símbolos."));

                mensaje = "La contraseña ingresada no cumple con tener:\n" + string.Join("\n", deficiencias.ToArray());
                return deficiencias.Count == 0;
            }
        }
    }
}
