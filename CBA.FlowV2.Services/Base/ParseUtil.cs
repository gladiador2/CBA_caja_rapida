using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;
using System.Text.RegularExpressions;

namespace CBA.FlowV2.Services.Base
{
    public class ParseUtil
    {
        public static Hashtable Buscar(string texto, string token)
        {
            string[] aTexto = Regex.Replace(texto, @"\s+", " ").Split(' ');

            List<UsuariosService> lUsuarios = new List<UsuariosService>();

            for (int i = 0; i < aTexto.Length; i++)
            {
                if (aTexto[i].StartsWith(token))
                {
                    switch (token)
                    {
                        case Definiciones.ParseUtil.Usuario:
                            DataTable objeto = UsuariosService.GetUsuarios("upper(" + UsuariosService.Usuario_NombreCol + ") = '" + aTexto[i].Replace(Definiciones.ParseUtil.Usuario, string.Empty).ToUpper() + "' and " + UsuariosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'", string.Empty);
                            if (objeto.Rows.Count > 0)
                                lUsuarios.Add(new UsuariosService((decimal)objeto.Rows[0][UsuariosService.Id_NombreCol]));
                            break;
                        default:
                            throw new Exception("ParseUtil.Buscar(). Token " + token + " no implementado.");
                    }
                }
            }

            var ht = new Hashtable();

            if (lUsuarios.Count > 0)
                ht.Add(typeof(UsuariosService), lUsuarios);
            
            return ht;
        }
    }
}
