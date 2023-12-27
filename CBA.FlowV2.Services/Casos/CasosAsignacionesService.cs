#region Using
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using System;

#endregion Using

namespace CBA.FlowV2.Services.Casos
{
    public class CasosAsignacionesService
    {

        #region GetCasosAsignacionesInfoCompleta
        /// <summary>
        /// Gets the casos asignaciones info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCasosAsignacionesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CASOS_ASIGNACIONES_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCasosAsignacionesInfoCompleta

        #region GetCasosAsignacionesDataTable
        /// <summary>
        /// Gets the casos asignaciones data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCasosAsignacionesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CASOS_ASIGNACIONESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCasosAsignacionesDataTable

        #region GetCasosAsignadosPorUsuario
        /// <summary>
        /// Gets the casos asignados por usuario.
        /// </summary>
        /// <param name="usuario_involucrado_id">The usuario_involucrado_id.</param>
        /// <param name="incluir_acciones_finalizadas">if set to <c>true</c> [incluir_acciones_finalizadas].</param>
        /// <param name="usuario_es_asignado_actual">if set to <c>true</c> [usuario_es_asignado_actual].</param>
        /// <returns></returns>
        public static DataTable GetCasosAsignadosPorUsuario(decimal usuario_involucrado_id, bool incluir_acciones_finalizadas, bool usuario_es_asignado_actual)
        {
            using (SessionService sesion = new SessionService())
            {
                string sql;
                string sqlAccionesFinalizadas, sqlUsuarioEsAsignadoActual;

                if (incluir_acciones_finalizadas)
                    sqlAccionesFinalizadas = " 1=1 ";
                else
                    sqlAccionesFinalizadas = "ca." + CasosAsignacionesService.AccionesFinalizadas_NombreCol + " = '" + Definiciones.SiNo.No + "'";

                if (usuario_es_asignado_actual)
                    sqlUsuarioEsAsignadoActual = CasosAsignacionesService.UsuarioAsignadoId_NombreCol + " = "+ usuario_involucrado_id;
                else
                    sqlUsuarioEsAsignadoActual = " 1=1 ";

                sql = "SELECT * FROM ( " +
                      "        SELECT caic.*, " +
                      "               RANK() OVER (PARTITION BY " + CasosAsignacionesService.CasoId_NombreCol + " ORDER BY id DESC) orden " +
                      "          FROM " + CasosAsignacionesService.Nombre_Vista + " caic " +
                      "         WHERE exists " +
                      "                 ( select * " +
                      "                     from " + CasosAsignacionesService.Nombre_Tabla + " ca " +
                      "                    where ca." + CasosAsignacionesService.UsuarioAsignadoId_NombreCol + " = " + usuario_involucrado_id +
                      "                      and ca." + CasosAsignacionesService.CasoId_NombreCol + " = caic." + CasosAsignacionesService.CasoId_NombreCol + " " +
                      "                      and " + sqlAccionesFinalizadas +
                      "                 ) " +
                      "               ) " +
                      "  WHERE orden = 1 " +
                      "    and " + sqlUsuarioEsAsignadoActual;

                return sesion.Db.EjecutarQuery(sql);
            }
        }
        #endregion GetCasosAsignadosPorUsuario

        #region Asignar
        /// <summary>
        /// Asignars the specified caso_id.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <param name="texto_predefinido_id">The texto_predefinido_id.</param>
        /// <param name="observacion">The observacion.</param>
        public static void Asignar(decimal caso_id, decimal usuario_id, decimal texto_predefinido_id, string observacion)
        {
            using (SessionService sesion = new SessionService())
            {
                Asignar(caso_id, usuario_id, texto_predefinido_id, observacion, sesion);
            }
        }

        /// <summary>
        /// Asignars the specified caso_id.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <param name="texto_predefinido_id">The texto_predefinido_id.</param>
        /// <param name="observacion">The observacion.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Asignar(decimal caso_id, decimal usuario_id, decimal texto_predefinido_id, string observacion, SessionService sesion)
        {
            CASOS_ASIGNACIONESRow row = new CASOS_ASIGNACIONESRow();
            row.ID = sesion.Db.GetSiguienteSecuencia("casos_asignaciones_sqc");
            row.CASO_ID = caso_id;
            row.USUARIO_CREACION_ID = sesion.Usuario.ID;
            row.ACCIONES_FINALIZADAS = Definiciones.SiNo.No;
            row.FECHA_CREACION = DateTime.Now;
            row.OBSERVACION = observacion;

            if (!usuario_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                row.USUARIO_ASIGNADO_ID = usuario_id;

            if (!texto_predefinido_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                row.TEXTO_PREDEFINIDO_ID = texto_predefinido_id;

            sesion.Db.CASOS_ASIGNACIONESCollection.Insert(row);
        }
        #endregion Asignar

        #region SetFinalizado
        /// <summary>
        /// Sets the finalizado.
        /// </summary>
        /// <param name="caso_asignacion_id">The caso_asignacion_id.</param>
        public static void SetFinalizado(decimal caso_asignacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CASOS_ASIGNACIONESRow row = sesion.Db.CASOS_ASIGNACIONESCollection.GetByPrimaryKey(caso_asignacion_id);
                row.ACCIONES_FINALIZADAS = Definiciones.SiNo.Si;
                row.FECHA_ACCION_FINALIZADA = DateTime.Now;
                sesion.Db.CASOS_ASIGNACIONESCollection.Update(row);
            }
        }
        #endregion SetFinalizado

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CASOS_ASIGNACIONES"; }
        }
        public static string Nombre_Vista
        {
            get { return "casos_asignaciones_info_comp"; }
        }
        public static string AccionesFinalizadas_NombreCol
        {
            get { return CASOS_ASIGNACIONESCollection.ACCIONES_FINALIZADASColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return CASOS_ASIGNACIONESCollection.CASO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CASOS_ASIGNACIONESCollection.IDColumnName; }
        }
        public static string FechaAccionFinalizada_NombreCol
        {
            get { return CASOS_ASIGNACIONESCollection.FECHA_ACCION_FINALIZADAColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return CASOS_ASIGNACIONESCollection.FECHA_CREACIONColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CASOS_ASIGNACIONESCollection.OBSERVACIONColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return CASOS_ASIGNACIONESCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string UsuarioAsignadoId_NombreCol
        {
            get { return CASOS_ASIGNACIONESCollection.USUARIO_ASIGNADO_IDColumnName; }
        }
        public static string UsuarioCreacionId_NombreCol
        {
            get { return CASOS_ASIGNACIONESCollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return CASOS_ASIGNACIONES_INFO_COMPCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCasoFlujoDescripcion_NombreCol
        {
            get { return CASOS_ASIGNACIONES_INFO_COMPCollection.CASO_FLUJO_DESCRIPCIONColumnName; }
        }
        public static string VistaCasoFlujoId_NombreCol
        {
            get { return CASOS_ASIGNACIONES_INFO_COMPCollection.CASO_FLUJO_IDColumnName; }
        }
        public static string VistaTextoPredefinidoTexto_NombreCol
        {
            get { return CASOS_ASIGNACIONES_INFO_COMPCollection.TEXTO_PREDEFINIDO_TEXTOColumnName; }
        }
        public static string VistaUsuarioAsignadoNombre_NombreCol
        {
            get { return CASOS_ASIGNACIONES_INFO_COMPCollection.USUARIO_ASIGNADO_NOMBREColumnName; }
        }
        public static string VistaUsuarioCreacionNombre_NombreCol
        {
            get { return CASOS_ASIGNACIONES_INFO_COMPCollection.USUARIO_CREACION_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
