using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class EntidadesConfiguracionMailService
    {
        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ENTIDADES_CONFIG_MAIL"; }
        }
        public static string Contrasena_NombreCol
        {
            get { return ENTIDADES_CONFIG_MAILCollection.CONTRASENAColumnName; }
        }
        public static string EntidadId_NombreCol
        {
            get { return ENTIDADES_CONFIG_MAILCollection.ENTIDAD_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return ENTIDADES_CONFIG_MAILCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ENTIDADES_CONFIG_MAILCollection.IDColumnName; }
        }
        public static string NombreUsuario_NombreCol
        {
            get { return ENTIDADES_CONFIG_MAILCollection.NOMBRE_USUARIOColumnName; }
        }
        public static string ServidorSMTP_NombreCol
        {
            get { return ENTIDADES_CONFIG_MAILCollection.SERVIDOR_SMTPColumnName; }
        }
        public static string Puerto_NombreCol
        {
            get { return ENTIDADES_CONFIG_MAILCollection.PUERTOColumnName; }
        }
        #endregion Accessors

        public DataTable GetEntidadesConfigEmailDataTable(decimal id_entidad)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetEntidadesConfigEmailDataTable(id_entidad, sesion);
            }
        }

        public DataTable GetEntidadesConfigEmailDataTable(decimal id_entidad, SessionService sesion)
        {
            return sesion.Db.ENTIDADES_CONFIG_MAILCollection.GetAsDataTable(" " + EntidadesConfiguracionMailService.EntidadId_NombreCol.ToString() + " = 1 and " + EntidadesConfiguracionMailService.Id_NombreCol +"="+id_entidad+" and " + EntidadesConfiguracionMailService.Estado_NombreCol + " = 'A'", string.Empty);
        }
    }
}
