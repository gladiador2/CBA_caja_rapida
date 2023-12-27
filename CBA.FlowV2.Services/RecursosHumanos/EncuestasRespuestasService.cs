using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class EncuestasRespuestasService
    {
        #region Getters
        /// <summary>
        /// Gets the encuesta respuestas row.
        /// </summary>
        /// <param name="encueta_respuesta_id">The encueta_respuesta_id.</param>
        /// <returns></returns>
        public DataRow GetEncuestaRespuestasRow(decimal encueta_respuesta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.ENCUESTAS_RESPUESTASCollection.GetAsDataTable(EncuestasRespuestasService.EncuestasRespuestasId_NombreCol + " = " + encueta_respuesta_id, EncuestasRespuestasService.EncuestasRespuestasOrden_NombreCol);
                return table.Rows[0];
            }
        }

        /// <summary>
        /// Gets the encuestas respuestas.
        /// </summary>
        /// <param name="encuestas_pregunta_id">The encuestas_pregunta_id.</param>
        /// <returns></returns>
        public DataTable GetEncuestasRespuestas(decimal encuestas_pregunta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ENCUESTAS_RESPUESTASCollection.GetByENCUESTAS_PREGUNTA_IDAsDataTable(encuestas_pregunta_id);
            }
        }
        #endregion Getters

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    ENCUESTAS_RESPUESTASRow row = new ENCUESTAS_RESPUESTASRow();
                    String valorAnterior = "";
                    
                    if (insertarNuevo)
                    {
                        sesion.Db.BeginTransaction(); //Si se iniciaba una sola vez, no actualizaba todos los registros
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("encuestas_respuestas_sqc");
                        row.ENCUESTAS_PREGUNTA_ID = decimal.Parse(campos["ENCUESTAS_PREGUNTA_ID"].ToString());                        
                        sesion.Db.CommitTransaction();
                    }
                    else
                    {
                        row = sesion.Db.ENCUESTAS_RESPUESTASCollection.GetRow(" id = " + decimal.Parse(campos["ID"].ToString()));
                        valorAnterior = row.ToString();
                    }
                    row.TEXTO = campos["TEXTO"].ToString();
                    row.VALOR_NUMERICO = decimal.Parse(campos["VALOR_NUMERICO"].ToString());
                    row.ORDEN = decimal.Parse(campos["ORDEN"].ToString());

                    sesion.Db.BeginTransaction(); //Si se iniciaba una sola vez, no actualizaba todos los registros

                    if (insertarNuevo) sesion.Db.ENCUESTAS_RESPUESTASCollection.Insert(row);
                    else sesion.Db.ENCUESTAS_RESPUESTASCollection.Update(row);
                        
                    LogCambiosService.LogDeRegistro("encuestas_respuestas", row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified encuestas_respuesta_id.
        /// </summary>
        /// <param name="encuestas_respuesta_id">The encuestas_respuesta_id.</param>
        public void Borrar(decimal encuestas_respuesta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    ENCUESTAS_RESPUESTASRow row = sesion.Db.ENCUESTAS_RESPUESTASCollection.GetByPrimaryKey(encuestas_respuesta_id);
                    
                    sesion.Db.BeginTransaction();

                    sesion.Db.ENCUESTAS_RESPUESTASCollection.Delete(row);
                    LogCambiosService.LogDeRegistro("encuestas_respuestas", row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region BorrarSegunPregunta
        /// <summary>
        /// Borrars the segun pregunta.
        /// </summary>
        /// <param name="encuestas_pregunta_id">The encuestas_pregunta_id.</param>
        public void BorrarSegunPregunta(decimal encuestas_pregunta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    ENCUESTAS_RESPUESTASRow[] rows = sesion.Db.ENCUESTAS_RESPUESTASCollection.GetByENCUESTAS_PREGUNTA_ID(encuestas_pregunta_id);

                    sesion.Db.BeginTransaction();

                    foreach (ENCUESTAS_RESPUESTASRow row in rows)
                    {
                        sesion.Db.ENCUESTAS_RESPUESTASCollection.Delete(row);
                        LogCambiosService.LogDeRegistro("encuestas_respuestas", row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    }

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Metodos estaticos
        public static string EncuestasRespuestasEncuestaPreguntaId_NombreCol
        {
            get { return ENCUESTAS_RESPUESTASCollection.ENCUESTAS_PREGUNTA_IDColumnName; }
        }
        public static string EncuestasRespuestasId_NombreCol
        {
            get { return ENCUESTAS_RESPUESTASCollection.IDColumnName; }
        }
        public static string EncuestasRespuestasOrden_NombreCol
        {
            get { return ENCUESTAS_RESPUESTASCollection.ORDENColumnName; }
        }
        public static string EncuestasRespuestasTexto_NombreCol
        {
            get { return ENCUESTAS_RESPUESTASCollection.TEXTOColumnName; }
        }
        public static string EncuestasRespuestasValorNumerico_NombreCol
        {
            get { return ENCUESTAS_RESPUESTASCollection.VALOR_NUMERICOColumnName; }
        }
        #endregion Metodos estaticos
    }
}
