using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class EncuestasPreguntasService
    {
        #region Getters
        /// <summary>
        /// Gets the encuesta preguntas row.
        /// </summary>
        /// <param name="encuesta_pregunta_id">The encuesta_pregunta_id.</param>
        /// <returns></returns>
        public DataRow GetEncuestaPreguntasRow(decimal encuesta_pregunta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;
                dt = sesion.Db.ENCUESTAS_PREGUNTASCollection.GetAsDataTable(EncuestasPreguntasService.EncuestasPreguntasId_NombreCol + "=" + encuesta_pregunta_id, "");

                return dt.Rows[0];
            }
        }

        /// <summary>
        /// Obtener las preguntas que conforman la encuesta.
        /// </summary>
        /// <param name="encuesta_id">The encuesta_id.</param>
        /// <param name="numero_pregunta_empezando_1">The numero_pregunta_empezando_1.</param>
        /// <returns></returns>
        public DataRow GetEncuestaPreguntasRow(decimal encuesta_id, int numero_pregunta_empezando_1)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.ENCUESTAS_PREGUNTASCollection.GetAsDataTable(EncuestasPreguntasService.EncuestasPreguntasEncuestaId_NombreCol + " = " + encuesta_id, EncuestasPreguntasService.EncuestasPreguntasOrden_NombreCol);
                
                if(table.Rows.Count < numero_pregunta_empezando_1) return table.Rows[0];
                else return table.Rows[numero_pregunta_empezando_1 - 1];
            }
        }

        /// <summary>
        /// Gets the encuesta preguntas.
        /// </summary>
        /// <param name="encuesta_id">The encuesta_id.</param>
        /// <returns></returns>
        public DataTable GetEncuestaPreguntas(decimal encuesta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dtTiposPregunta;
                DataTable dtPreguntas;
                DataSet ds = new DataSet();
                DataRelation relTipoPregunta;

                dtPreguntas = sesion.Db.ENCUESTAS_PREGUNTASCollection.GetAsDataTable(EncuestasPreguntasService.EncuestasPreguntasEncuestaId_NombreCol + " = " + encuesta_id, EncuestasPreguntasService.EncuestasPreguntasOrden_NombreCol);
                dtTiposPregunta = sesion.Db.TIPOS_ITEM_ENCUESTACollection.GetAllAsDataTable();

                ds.Tables.Add(dtTiposPregunta);
                ds.Tables.Add(dtPreguntas);

                relTipoPregunta = new DataRelation("relTipoPregunta", dtTiposPregunta.Columns["ID"], dtPreguntas.Columns["TIPOS_ITEM_ENCUESTA_ID"]);
                ds.Relations.Add(relTipoPregunta);

                dtPreguntas.Columns.Add("tipo_item_encuesta_nombre", typeof(String));
                foreach (DataRow dr in dtPreguntas.Rows)
                {
                    dr["tipo_item_encuesta_nombre"] = dr.GetParentRow("relTipoPregunta")["NOMBRE"];
                }

                return dtPreguntas;
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
                    ENCUESTAS_PREGUNTASRow row = new ENCUESTAS_PREGUNTASRow();
                    EncuestasService Encuesta = new EncuestasService();
                    EncuestasRespuestasService EncuestaRespuesta = new EncuestasRespuestasService();
                    System.Collections.Hashtable camposRespuesta;

                    String valorAnterior = "";
                    
                    if (insertarNuevo)
                    {
                        sesion.Db.BeginTransaction(); //Si se iniciaba una sola vez, no actualizaba todos los registros
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("encuestas_preguntas_sqc");
                        row.ENCUESTA_ID = decimal.Parse(campos["ENCUESTA_ID"].ToString());
                        
                        //Se aumenta el contador de preguntas en la cabecera
                        Encuesta.VariarCantidadPreguntas(row.ENCUESTA_ID, 1);

                        sesion.Db.CommitTransaction();
                    }
                    else
                    {
                        row = sesion.Db.ENCUESTAS_PREGUNTASCollection.GetRow(" id = " + decimal.Parse(campos["ID"].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.TIPOS_ITEM_ENCUESTA_ID = decimal.Parse(campos["TIPOS_ITEM_ENCUESTA_ID"].ToString());
                    row.TITULO = campos["TITULO"].ToString();
                    row.DESCRIPCION = campos["DESCRIPCION"].ToString();
                    row.ORDEN = decimal.Parse(campos["ORDEN"].ToString());

                    sesion.Db.BeginTransaction(); //Si se iniciaba una sola vez, no actualizaba todos los registros

                    if (insertarNuevo) sesion.Db.ENCUESTAS_PREGUNTASCollection.Insert(row);
                    else sesion.Db.ENCUESTAS_PREGUNTASCollection.Update(row);

                    LogCambiosService.LogDeRegistro("encuestas_pregustas", row.ID, valorAnterior, row.ToString(), sesion);
                    sesion.Db.CommitTransaction();

                    if (insertarNuevo){
                        //Segun el tipo de pregunta, se agregan automaticamente posibles respuestas
                        switch ((int)row.TIPOS_ITEM_ENCUESTA_ID)
                        {
                            case Definiciones.EncuestasTiposPreguntas.SiNo:
                                camposRespuesta = new System.Collections.Hashtable();
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasEncuestaPreguntaId_NombreCol, row.ID);
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasTexto_NombreCol, "SI");
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasValorNumerico_NombreCol, 1);
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasOrden_NombreCol, 1);
                                EncuestaRespuesta.Guardar(camposRespuesta, true);

                                camposRespuesta = new System.Collections.Hashtable();
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasEncuestaPreguntaId_NombreCol, row.ID);
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasTexto_NombreCol, "NO");
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasValorNumerico_NombreCol, 0);
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasOrden_NombreCol, 2);
                                EncuestaRespuesta.Guardar(camposRespuesta, true);
                                break;

                            case Definiciones.EncuestasTiposPreguntas.VerdaderoFalso:
                                camposRespuesta = new System.Collections.Hashtable();
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasEncuestaPreguntaId_NombreCol, row.ID);
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasTexto_NombreCol, "VERDADERO");
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasValorNumerico_NombreCol, 1);
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasOrden_NombreCol, 1);
                                EncuestaRespuesta.Guardar(camposRespuesta, true);

                                camposRespuesta = new System.Collections.Hashtable();
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasEncuestaPreguntaId_NombreCol, row.ID);
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasTexto_NombreCol, "FALSO");
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasValorNumerico_NombreCol, 0);
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasOrden_NombreCol, 2);
                                EncuestaRespuesta.Guardar(camposRespuesta, true);
                                break;

                            case Definiciones.EncuestasTiposPreguntas.Texto:
                                camposRespuesta = new System.Collections.Hashtable();
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasEncuestaPreguntaId_NombreCol, row.ID);
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasTexto_NombreCol, "TEXTO");
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasValorNumerico_NombreCol, 1);
                                camposRespuesta.Add(EncuestasRespuestasService.EncuestasRespuestasOrden_NombreCol, 1);
                                EncuestaRespuesta.Guardar(camposRespuesta, true);
                                break;
                        }
                    }
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
        /// Borrars the specified encuestas_pregunta_id.
        /// </summary>
        /// <param name="encuestas_pregunta_id">The encuestas_pregunta_id.</param>
        public void Borrar(decimal encuestas_pregunta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    ENCUESTAS_PREGUNTASRow row = sesion.Db.ENCUESTAS_PREGUNTASCollection.GetByPrimaryKey(encuestas_pregunta_id);
                    EncuestasService Encuesta = new EncuestasService();
                    EncuestasRespuestasService Respuestas = new EncuestasRespuestasService();
                    
                    sesion.Db.BeginTransaction();

                    Respuestas.BorrarSegunPregunta(row.ID);
                    sesion.Db.ENCUESTAS_PREGUNTASCollection.Delete(row);
                    Encuesta.VariarCantidadPreguntas(row.ENCUESTA_ID, -1);

                    LogCambiosService.LogDeRegistro("encuestas_preguntas", row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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
        public static string EncuestasPreguntasDescripcion_NombreCol
        {
            get { return ENCUESTAS_PREGUNTASCollection.DESCRIPCIONColumnName; }
        }
        public static string EncuestasPreguntasEncuestaId_NombreCol
        {
            get { return ENCUESTAS_PREGUNTASCollection.ENCUESTA_IDColumnName; }
        }
        public static string EncuestasPreguntasId_NombreCol
        {
            get { return ENCUESTAS_PREGUNTASCollection.IDColumnName; }
        }
        public static string EncuestasPreguntasOrden_NombreCol
        {
            get { return ENCUESTAS_PREGUNTASCollection.ORDENColumnName; }
        }
        public static string EncuestasPreguntasTipoItemEncuestaId_NombreCol
        {
            get { return ENCUESTAS_PREGUNTASCollection.TIPOS_ITEM_ENCUESTA_IDColumnName; }
        }
        public static string EncuestasPreguntasTitulo_NombreCol
        {
            get { return ENCUESTAS_PREGUNTASCollection.TITULOColumnName; }
        }
        #endregion Metodos estaticos
    }
}
