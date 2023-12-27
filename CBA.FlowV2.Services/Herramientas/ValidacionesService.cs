using System;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class ValidacionesService
    {
        public static String RecortarDecimales(String numero, int cantidadDecimales)
        {
            int posicion = Definiciones.Error.Valor.IntPositivo;
            String resultado;

            //Se encuentra la posicion de la coma en la cadena
            posicion = numero.IndexOf(',');

            //Si se utiliza punto en vez de coma, se encuentra su posicion
            if (posicion == Definiciones.Error.Valor.IntPositivo)
            {
                posicion = numero.IndexOf('.');
            }

            //Si la cadena tiene parte decimal, y la misma tiene mas de cantidadDecimales decimales
            //se corta en la cantidad indicada
            if (posicion != Definiciones.Error.Valor.IntPositivo && numero.Length > posicion + cantidadDecimales)
                resultado = numero.Substring(0, posicion + 1 + cantidadDecimales);
            else
                resultado = numero;

            return resultado;
        }
    }
}
