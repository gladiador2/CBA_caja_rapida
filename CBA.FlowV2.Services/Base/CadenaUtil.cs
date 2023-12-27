using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Base
{
    public static class CadenaUtil
    {
        public static string FormatearCadena(string cadena, int variable)
        {            
            string valor = string.Empty;
            switch (variable)
            {
                case 1:
                    valor= StringUtil.TodoMayuscula(cadena);
                break;
                default:
                    valor = cadena;
                break;
            }
            return valor;
        }
    }
}
