#region Using
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using System.Collections.Generic;
#endregion Using

namespace CBA.FlowV2.Services.Base
{
    public class SeguimientosAutomaticosService
    {
        #region Evaluar
        public static void Evaluar(decimal caso_id, string estado_destino_id)
        {
            using (SessionService sesion = new SessionService())
            {
                Evaluar(caso_id, estado_destino_id, sesion);
            }
        }

        public static void Evaluar(decimal caso_id, string estado_destino_id, SessionService sesion)
        {
            string clausulas, texto, asunto, direccion_destino;
            decimal flujoId;
            SEGUIMIENTOS_AUTOMATICOSRow[] rows;
            HashSet<decimal> usuariosDestinatarios = new HashSet<decimal>();
            
            flujoId = CasosService.GetFlujo(caso_id, sesion);
            clausulas = SeguimientosAutomaticosService.FlujoId_NombreCol + " = " + flujoId + " and " +
                        SeguimientosAutomaticosService.EstadoId_NombreCol + " = '" + estado_destino_id + "' ";
            
            asunto = "Se registraron cambios en el caso " + caso_id + " del flujo " + Definiciones.FlujosIDs.GetNombre(flujoId) + ".";
            texto = "<html><body>" + asunto + "<br><br><a href='" + Traducciones.Link_al_CBAFlow + "'>Ir al sistema.</a></body></html>";

            //Se obtienen los roles afectados
            rows = sesion.Db.SEGUIMIENTOS_AUTOMATICOSCollection.GetAsArray(clausulas, string.Empty);
            
            //Se obtienen los usuarios que poseen los roles
            for (int i = 0; i < rows.Length; i++)
            {
                DataTable dtUsuarios = UsuariosRolesService.GetUsuariosRolesDataTable(UsuariosRolesService.RolId_NombreCol + " = " + rows[i].ROL_ID, string.Empty, sesion);
                for (int j = 0; j < dtUsuarios.Rows.Count; j++)
                    usuariosDestinatarios.Add((decimal)dtUsuarios.Rows[j][UsuariosRolesService.UsuarioId_NombreCol]);
            }

            foreach (decimal usuarioId in usuariosDestinatarios)
            {
                using (EmailService correo = new EmailService(false, sesion))
                {
                    DataTable dtUsuario = new UsuariosService().GetUsuario(usuarioId);
                    direccion_destino = (string)dtUsuario.Rows[0][UsuariosService.Email_NombreCol];

                    correo.EnviarMail(direccion_destino, asunto, texto);
                }
            }
        }
        #endregion Evaluar

        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "SEGUIMIENTOS_AUTOMATICOS"; }
        }

        public static string EstadoId_NombreCol
        {
            get { return SEGUIMIENTOS_AUTOMATICOSCollection.ESTADO_IDColumnName; }
        }
        public static string FlujoId_NombreCol
        {
            get { return SEGUIMIENTOS_AUTOMATICOSCollection.FLUJO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return SEGUIMIENTOS_AUTOMATICOSCollection.IDColumnName; }
        }
        public static string RolId_NombreCol
        {
            get { return SEGUIMIENTOS_AUTOMATICOSCollection.ROL_IDColumnName; }
        }
        #endregion Accesors
    }
}
