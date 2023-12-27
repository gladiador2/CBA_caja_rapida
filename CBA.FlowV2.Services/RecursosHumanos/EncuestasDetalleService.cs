using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class EncuestasDetalleService
    {
        #region Getters
        /// <summary>
        /// Gets the encuestas detalle row.
        /// </summary>
        /// <param name="encuesta_detalle_id">The encuesta_detalle_id.</param>
        /// <returns></returns>
        public DataRow GetEncuestasDetalleRow(decimal encuesta_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.ENCUESTAS_DETALLECollection.GetAsDataTable(EncuestasDetalleService.EncuestasDetalleId_NombreCol + "=" + encuesta_detalle_id, "");
                
                return table.Rows[0];
            }
        }

        /// <summary>
        /// Gets the encuesta detalle.
        /// </summary>
        /// <param name="encuesta_pregunta_id">The encuesta_pregunta_id.</param>
        /// <param name="persona_o_funcionario_id">The persona_o_funcionario_id.</param>
        /// <returns></returns>
        public DataTable GetEncuestaDetalle(decimal encuesta_pregunta_id, decimal persona_o_funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string where;

                where = EncuestasDetalleService.EncuestasDetalleEncuestasPreguntaId_NombreCol + " = " + encuesta_pregunta_id + 
                        " and ( " +
                        EncuestasDetalleService.EncuestasDetallePersonaId_NombreCol + " = " + persona_o_funcionario_id + " or " + 
                        EncuestasDetalleService.EncuestasDetalleFuncionarioId_NombreCol + " = " + persona_o_funcionario_id + ")" +
                        " and " + EncuestasDetalleService.EncuestasDetalleEstado_NombreCol + "='" + Definiciones.Estado.Activo+"'";

                table = sesion.Db.ENCUESTAS_DETALLECollection.GetAsDataTable(where, "");
                return table;
            }
        }
        #endregion Getters

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    String valorAnterior = Definiciones.Log.RegistroNuevo;

                    ENCUESTAS_DETALLERow row = new ENCUESTAS_DETALLERow();
                    row.ID = sesion.Db.GetSiguienteSecuencia("encuestas_detalle_sqc");
                    row.ENCUESTAS_PREGUNTA_ID = decimal.Parse(campos[EncuestasDetalleEncuestasPreguntaId_NombreCol].ToString());
                    row.ENCUESTAS_RESPUESTA_ID = decimal.Parse(campos[EncuestasDetalleEncuestasRespuestaId_NombreCol].ToString());
                    row.ESTADO = Definiciones.Estado.Activo;

                    if (campos.Contains(EncuestasDetalleFuncionarioId_NombreCol))
                    {
                        row.FUNCIONARIO_ID = decimal.Parse(campos[EncuestasDetalleFuncionarioId_NombreCol].ToString());
                        if (!FuncionariosService.EstaActivo(row.FUNCIONARIO_ID))
                        {
                            throw new Exception("El funcionario no se encuentra activo.");
                        }
                    }

                    if (campos.Contains(EncuestasDetallePersonaId_NombreCol))
                    {
                        row.PERSONA_ID = decimal.Parse(campos[EncuestasDetallePersonaId_NombreCol].ToString());
                        if (!PersonasService.EstaActivo(row.PERSONA_ID))
                        {
                            throw new Exception("La persona no se encuentra activa.");
                        }
                    }

                    row.TEXTO = campos[EncuestasDetalleTexto_NombreCol].ToString();

                    sesion.Db.BeginTransaction();
                    sesion.Db.ENCUESTAS_DETALLECollection.Insert(row);

                    LogCambiosService.LogDeRegistro("encuestas_detalle", row.ID, valorAnterior, row.ToString(), sesion);

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

        #region BorrarRespuestasDePersona
        /// <summary>
        /// Borra de la base de datos el caso y la cabecera del flujo
        /// </summary>
        /// <param name="encuesta_id">The encuesta_id.</param>
        /// <param name="persona_id">The persona_id.</param>
        public void BorrarRespuestasDePersona(decimal encuesta_id, decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    EncuestasPreguntasService EncuestasPreguntas = new EncuestasPreguntasService();
                    DataTable dtPreguntas;
                    ENCUESTAS_DETALLERow[] rows;
                    string where, valorAnterior;

                    sesion.BeginTransaction();

                    dtPreguntas = EncuestasPreguntas.GetEncuestaPreguntas(encuesta_id);

                    foreach (DataRow dr in dtPreguntas.Rows)
                    {
                        where = EncuestasDetalleEncuestasPreguntaId_NombreCol + "=" + dr[EncuestasPreguntasService.EncuestasPreguntasId_NombreCol] +
                                " and " + EncuestasDetallePersonaId_NombreCol + "=" + persona_id;

                        rows = sesion.Db.ENCUESTAS_DETALLECollection.GetAsArray(where, "");
                        foreach (ENCUESTAS_DETALLERow row in rows)
                        {
                            if (row.ESTADO.Equals(Definiciones.Estado.Inactivo)) continue;

                            valorAnterior = row.ESTADO;
                            row.ESTADO = Definiciones.Estado.Inactivo;

                            sesion.Db.ENCUESTAS_DETALLECollection.Update(row);
                            LogCambiosService.LogDeColumna("encuestas_detalle", EncuestasDetalleEstado_NombreCol, row.ID, valorAnterior, row.ESTADO, sesion);
                        }
                    }

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion BorrarRespuestasDePersona

        #region BorrarRespuestasDeFuncionario
        /// <summary>
        /// Borra de la base de datos el caso y la cabecera del flujo
        /// </summary>
        /// <param name="encuesta_id">The encuesta_id.</param>
        /// <param name="funcionario_id">The funcionario_id.</param>
        public void BorrarRespuestasDeFuncionario(decimal encuesta_id, decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    EncuestasPreguntasService EncuestasPreguntas = new EncuestasPreguntasService();
                    DataTable dtPreguntas;
                    ENCUESTAS_DETALLERow[] rows;
                    string where, valorAnterior;

                    sesion.BeginTransaction();

                    dtPreguntas = EncuestasPreguntas.GetEncuestaPreguntas(encuesta_id);

                    foreach (DataRow dr in dtPreguntas.Rows)
                    {
                        where = EncuestasDetalleEncuestasPreguntaId_NombreCol + "=" + dr[EncuestasPreguntasService.EncuestasPreguntasId_NombreCol] +
                                " and " + EncuestasDetalleFuncionarioId_NombreCol + "=" + funcionario_id;

                        rows = sesion.Db.ENCUESTAS_DETALLECollection.GetAsArray(where, "");
                        foreach (ENCUESTAS_DETALLERow row in rows)
                        {
                            if (row.ESTADO.Equals(Definiciones.Estado.Inactivo)) continue;

                            valorAnterior = row.ESTADO;
                            row.ESTADO = Definiciones.Estado.Inactivo;

                            sesion.Db.ENCUESTAS_DETALLECollection.Update(row);
                            LogCambiosService.LogDeColumna("encuestas_detalle", EncuestasDetalleEstado_NombreCol, row.ID, valorAnterior, row.ESTADO, sesion);
                        }
                    }

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion BorrarRespuestasDeFuncionario

        #region BorrarRespuestasTodas
        /// <summary>
        /// Borra de la base de datos el caso y la cabecera del flujo
        /// </summary>
        /// <param name="encuesta_id">The encuesta_id.</param>
        public void BorrarRespuestasTodas(decimal encuesta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    EncuestasPreguntasService EncuestasPreguntas = new EncuestasPreguntasService();
                    DataTable dtPreguntas;
                    ENCUESTAS_DETALLERow[] rows;
                    string valorAnterior;

                    sesion.BeginTransaction();

                    dtPreguntas = EncuestasPreguntas.GetEncuestaPreguntas(encuesta_id);

                    foreach (DataRow dr in dtPreguntas.Rows)
                    {
                        rows = sesion.Db.ENCUESTAS_DETALLECollection.GetByENCUESTAS_PREGUNTA_ID((decimal)dr[EncuestasPreguntasService.EncuestasPreguntasId_NombreCol]);
                        foreach (ENCUESTAS_DETALLERow row in rows)
                        {
                            if (row.ESTADO.Equals(Definiciones.Estado.Inactivo)) continue;

                            valorAnterior = row.ESTADO;
                            row.ESTADO = Definiciones.Estado.Inactivo;

                            sesion.Db.ENCUESTAS_DETALLECollection.Update(row);
                            LogCambiosService.LogDeColumna("encuestas_detalle", EncuestasDetalleEstado_NombreCol, row.ID, valorAnterior, row.ESTADO, sesion);
                        }
                    }
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion BorrarRespuestasTodas

        #region Metodos estaticos
        public static string Nombre_Tabla
        {
            get { return "ENCUESTAS_DETALLE"; }
        }
        public static string EncuestasDetalleId_NombreCol
        {
            get { return ENCUESTAS_DETALLECollection.IDColumnName; }
        }
        public static string EncuestasDetalleEncuestasPreguntaId_NombreCol
        {
            get { return ENCUESTAS_DETALLECollection.ENCUESTAS_PREGUNTA_IDColumnName; }
        }
        public static string EncuestasDetalleEncuestasRespuestaId_NombreCol
        {
            get { return ENCUESTAS_DETALLECollection.ENCUESTAS_RESPUESTA_IDColumnName; }
        }
        public static string EncuestasDetalleEstado_NombreCol
        {
            get { return ENCUESTAS_DETALLECollection.ESTADOColumnName; }
        }
        public static string EncuestasDetalleFuncionarioId_NombreCol
        {
            get { return ENCUESTAS_DETALLECollection.FUNCIONARIO_IDColumnName; }
        }
        public static string EncuestasDetallePersonaId_NombreCol
        {
            get { return ENCUESTAS_DETALLECollection.PERSONA_IDColumnName; }
        }
        public static string EncuestasDetalleTexto_NombreCol
        {
            get { return ENCUESTAS_DETALLECollection.TEXTOColumnName; }
        }
        #endregion Metodos estaticos
    }
}
