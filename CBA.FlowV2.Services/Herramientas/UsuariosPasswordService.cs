using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;


namespace CBA.FlowV2.Services.Herramientas
{
    public class UsuariosPasswordService
    {   
        #region GetContrasena
        public DataTable GetContrasena(decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.USUARIOS_PASSWORDCollection.GetByUSUARIO_IDAsDataTable(usuario_id);
            }
        }
        #endregion GetContrasena

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "USUARIOS_PASSWORD"; }
        }

        public static string UsuarioId_NombreCol
        {
            get { return USUARIOS_PASSWORDCollection.USUARIO_IDColumnName; }
        }
        public static string Passwd_NombreCol
        {
            get { return USUARIOS_PASSWORDCollection.PASSWDColumnName; }
        }
        #endregion Accessors
    }
}
