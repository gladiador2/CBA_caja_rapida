using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace CBA.FlowV2.Db.Casos
{
    public class CambioEstado 
    {
    public bool ProcesarCambioEstado(string estado_destino, Decimal caso_id, string comentario, decimal comentario_texto_id, Decimal sesion_id, Decimal usuario_id, string direccion_ip, CBAV2 db)
        {
            bool exito = false;
            try
            {
                    string procedimientoAlamacenado = "TRC.PROC.actualizar_estado";
                    OracleCommand cmd = new OracleCommand(procedimientoAlamacenado, db.Connection as OracleConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    #region Parametros ENTRANTES
                    cmd.Parameters.Add(new OracleParameter("pCaso", OracleDbType.Int32));
                    cmd.Parameters["pCaso"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("pEstado", OracleDbType.Varchar2, 50));
                    cmd.Parameters["pEstado"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("p_SesionNro", OracleDbType.Int32));
                    cmd.Parameters["p_SesionNro"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("pUsuario_Proceso", OracleDbType.Int32));
                    cmd.Parameters["pUsuario_Proceso"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("pComentario", OracleDbType.Varchar2, 400));
                    cmd.Parameters["pComentario"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("pComentarioTextoId", OracleDbType.Int32));
                    cmd.Parameters["pComentarioTextoId"].Direction = ParameterDirection.Input;
                    
                    cmd.Parameters.Add(new OracleParameter("pDireccionIP", OracleDbType.Varchar2, 16));
                    cmd.Parameters["pDireccionIP"].Direction = ParameterDirection.Input;
                    #endregion

                    #region Parametros SALIENTES
                    cmd.Parameters.Add(new OracleParameter("mensaje", OracleDbType.Varchar2, 400));
                    cmd.Parameters["mensaje"].Direction = ParameterDirection.Output;
                    #endregion

                    #region Parametros VALORES
                    cmd.Parameters["pCaso"].Value            = (Int32)caso_id;
                    cmd.Parameters["pEstado"].Value          = estado_destino;
                    cmd.Parameters["p_SesionNro"].Value      = (Int32)sesion_id;
                    cmd.Parameters["pUsuario_Proceso"].Value = (Int32)usuario_id;
                    cmd.Parameters["pDireccionIP"].Value     = direccion_ip;
                    cmd.Parameters["pComentario"].Value       = comentario;
                    if (comentario_texto_id == -1)
                    {
                        cmd.Parameters["pComentarioTextoId"].Value = null;
                    }
                    else
                    {
                        cmd.Parameters["pComentarioTextoId"].Value = (Int32)comentario_texto_id;
                    }
                    #endregion

                    // Ejecutamos el procedimiento almacenado
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    
                    exito = true;
            }
            catch (System.Exception exp)
            {
                exito = false;
                throw exp;
            }
            return exito;
        }

    }
}
