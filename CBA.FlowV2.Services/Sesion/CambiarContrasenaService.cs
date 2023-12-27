using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db.Usuarios;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Sesion
{
    public class CambiarContrasenaService
    {
        #region CambiarContrasena
        public string cambiarContrasena(string actual, string nueva, string repeticion)
        {
            using (SessionService sesion = new CBA.FlowV2.Services.Sesion.SessionService())
            {
                if (nueva != repeticion)
                    throw new Exception("La confirmación de la contraseña no coincide con la nueva contraseña elegida.");

                string mensaje;
                if (!ContrasenhasUtil.ContrasenhasRequisitosMinimos.Validar(nueva, out mensaje))
                    throw new Exception(mensaje);

                CambiarContrasena cambiar = new CambiarContrasena(sesion.Usuario.USUARIO,sesion.Usuario.ID, actual, nueva, repeticion, sesion.Entidad.NOMBRE,sesion.SucursalActiva_Id); 
                mensaje = cambiar.Ejecutar();

                UsuariosService.SetRequerirCambioContrasenha(sesion.Usuario.ID, Definiciones.SiNo.No, sesion);

                return mensaje;
             }
        }
        #endregion CambiarContrasena
    }
}