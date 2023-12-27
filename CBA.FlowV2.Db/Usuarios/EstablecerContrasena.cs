using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace CBA.FlowV2.Db.Usuarios
{
    public class EstablecerContrasena
    {
        #region Establecer
        /// <summary>
        /// Initializes a new instance of the <see cref="EstablecerContrasena"/> class.
        /// </summary>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <param name="contrasena">The contrasena.</param>
        public static void Establecer(decimal usuario_id, string contrasena)
        {
            try
            {
                CBAV2 db = new CBAV2();
                string procedimientoAlamacenado = "TRC.LOGUEO.ESTABLECERPASS";

                OracleCommand cmd = new OracleCommand(procedimientoAlamacenado, db.Connection as OracleConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                #region Parametros ENTRANTES
                cmd.Parameters.Add(new OracleParameter("pUsuarioId", OracleDbType.Int32));
                cmd.Parameters["pUsuarioId"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new OracleParameter("pClave", OracleDbType.Varchar2, 50));
                cmd.Parameters["pClave"].Direction = ParameterDirection.Input;
                #endregion

                #region Parametros VALORES
                cmd.Parameters["pUsuarioId"].Value = usuario_id;
                cmd.Parameters["pClave"].Value = contrasena;
                #endregion

                // Ejecutamos el procedimiento almacenado
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion Establecer
    }
}
