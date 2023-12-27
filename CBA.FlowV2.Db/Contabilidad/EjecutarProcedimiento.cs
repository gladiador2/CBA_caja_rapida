using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace CBA.FlowV2.Db.Contabilidad
{
    public class EjecutarProcedimiento
    {        
        #region Ejecutar
        /// <summary>
        /// Ejecutars the specified nombre_procedimiento.
        /// </summary>
        /// <param name="nombre_procedimiento">The nombre_procedimiento.</param>
        /// <param name="ctb_asiento_automatico_id">The ctb_asiento_automatico_id.</param>
        /// <param name="registro_valor_id">The registro_valor_id.</param>
        /// <param name="entidad_id">The entidad_id.</param>
        /// <returns></returns>
        public static string Ejecutar(string nombre_procedimiento, decimal ctb_asiento_automatico_id, string registro_valor_id, decimal entidad_id)
        {
            try
            {                
                CBAV2 db = new CBAV2();
                OracleCommand cmd = new OracleCommand(nombre_procedimiento, db.Connection as OracleConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                #region Parametros ENTRANTES
                cmd.Parameters.Add(new OracleParameter("pCtbAsientoAutomaticoId", OracleDbType.Int32));
                cmd.Parameters["pCtbAsientoAutomaticoId"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new OracleParameter("pRegistroValorId", OracleDbType.Varchar2));
                cmd.Parameters["pRegistroValorId"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new OracleParameter("pEntidadId", OracleDbType.Int32));
                cmd.Parameters["pEntidadId"].Direction = ParameterDirection.Input;
                #endregion

                #region Parametros SALIENTES
                cmd.Parameters.Add(new OracleParameter("mensaje", OracleDbType.Varchar2, 400));
                cmd.Parameters["mensaje"].Direction = ParameterDirection.Output;
                #endregion

                #region Parametros VALORES
                cmd.Parameters["pCtbAsientoAutomaticoId"].Value = ctb_asiento_automatico_id;
                cmd.Parameters["pRegistroValorId"].Value = registro_valor_id;
                cmd.Parameters["pEntidadId"].Value = entidad_id;
                #endregion
                
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                return cmd.Parameters["mensaje"].Value.ToString();
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

      
        #endregion
    }
}



