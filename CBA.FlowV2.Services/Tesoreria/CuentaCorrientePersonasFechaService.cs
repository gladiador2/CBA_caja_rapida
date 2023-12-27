using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrientePersonasFechaService
    {
        public static bool GenerarCierreCtaCteFechaFecha(DateTime fecha, SessionService sesion)
        {
            bool exito = false;
            try
            {
                string procedimientoAlamacenado = "TRC.PROC.generar_ctacte_persona_fecha";
                OracleCommand cmd = new OracleCommand(procedimientoAlamacenado, sesion.db.Connection as OracleConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                #region Parametros ENTRANTES
                cmd.Parameters.Add(new OracleParameter("fecha", OracleDbType.Date));
                cmd.Parameters["fecha"].Direction = ParameterDirection.Input;
                #endregion

                #region Parametros VALORES
                cmd.Parameters["fecha"].Value = fecha;
                
                #endregion

                // Ejecutamos el procedimiento almacenado
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception exp)
            {
                exito = false;
                throw new Exception("Error al generar el cierre de Ctacte");
            }
            return exito;
        }
        
        public static bool EliminarCierre(DateTime fecha, SessionService sesion)
        {
            bool exito = false;
            try
            {
                string comando = "delete from " + CuentaCorrientePersonasFechaService.Nombre_Tabla +
                                 " where " + CuentaCorrientePersonasFechaService.FechaFormatoNumero_NombreCol + " = " + fecha.ToString(CBA.FlowV2.Services.Base.Definiciones.FechaFormatoISO);
                OracleCommand cmd = new OracleCommand( comando, sesion.db.Connection as OracleConnection);
                cmd.CommandType = System.Data.CommandType.Text;

                // Ejecutamos el comando
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception exp)
            {
                exito = false;
                throw new Exception("Error al eliminar el cierre de Ctacte");
            }
            return exito;
        }
        
        #region GetDataTable
        public static DataTable GetDataTable(string clausulas, string orden)
        {
            try 
            {
                using (SessionService sesion = new SessionService()) 
                {
                    return GetDataTable(clausulas, orden, sesion);
                }
            } 
            catch (System.Exception exp) 
            {
                throw exp;
            }
        }

        public static DataTable GetDataTable(string clausulas, string orden, SessionService sesion)
        {
            try 
            {
                return sesion.Db.CTACTE_PERSONAS_FECHACollection.GetAsDataTable(clausulas, orden);
            } 
            catch (Exception) 
            {
                throw;
            }
        }
        #endregion GetDataTable

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PERSONAS_FECHA"; }
        }
        public static string Credito_NombreCol
        {
            get { return CTACTE_PERSONAS_FECHACollection.CREDITOColumnName; }
        }
        public static string Debito_NombreCol
        {
            get { return CTACTE_PERSONAS_FECHACollection.DEBITOColumnName; }
        }
        public static string FechaFormatoNumero_NombreCol
        {
            get { return CTACTE_PERSONAS_FECHACollection.FECHA_FORMATO_NUMEROColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PERSONAS_FECHACollection.IDColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return CTACTE_PERSONAS_FECHACollection.PERSONA_IDColumnName; }
        }
        public static string SaldoAVencer_NombreCol
        {
            get { return CTACTE_PERSONAS_FECHACollection.SALDO_A_VENCERColumnName; }
        }
        public static string SaldoVencido_NombreCol
        {
            get { return CTACTE_PERSONAS_FECHACollection.SALDO_VENCIDOColumnName; }
        }
        #endregion Accessors
    }
}
