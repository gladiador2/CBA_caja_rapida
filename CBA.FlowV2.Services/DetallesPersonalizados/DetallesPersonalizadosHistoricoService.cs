#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.IO;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.DetallesPersonalizados
{
    public class DetallesPersonalizadosHistoricoService
    {
        #region GetDetallesPersonalizdos
        /// <summary>
        /// Gets the detalles personalizados.
        /// </summary>
        /// <param name="tipo_detalle_personalizado_id">The tipo_detalle_personalizado_id.</param>
        /// <param name="tabla_id">The tabla_id.</param>
        /// <param name="columna">The columna.</param>
        /// <param name="registro_id">The registro_id.</param>
        /// <param name="orden_descendente">if set to <c>true</c> [orden_descendente].</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static decimal[] GetDetallesPersonalizados(decimal[] tipo_detalle_personalizado_id, string tabla_id, string columna, string registro_id, bool orden_descendente, decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string[] strId = Array.ConvertAll(tipo_detalle_personalizado_id, x => x.ToString());
                string clausulas = DetallesPersonalizadosHistoricoService.TipoDetallePersonalizadoId_NombreCol + " in (" + string.Join(",", strId) + ") and " +
                                   DetallesPersonalizadosHistoricoService.TablaId_NombreCol + " = '" + tabla_id + "' and " +
                                   DetallesPersonalizadosHistoricoService.Columna_NombreCol + " = '" + columna + "' and " +
                                   DetallesPersonalizadosHistoricoService.RegistroId_NombreCol + " = '" + registro_id + "' and " +
                                   DetallesPersonalizadosHistoricoService.CasoId_NombreCol + " = " + caso_id;

                string orden = DetallesPersonalizadosHistoricoService.FechaCreacion_NombreCol;
                if (orden_descendente) orden += " desc";
                
                DETALLES_PERSONALIZADOS_HISTRow[] rows = sesion.Db.DETALLES_PERSONALIZADOS_HISTCollection.GetAsArray(clausulas, orden);

                decimal[] registros = new decimal[rows.Length];

                for (int i = 0; i < registros.Length; i++)
                    registros[i] = rows[i].ID;

                return registros;
            }
        }
        #endregion GetDetallesPersonalizdos

        #region Guardar
        /// <summary>
        /// Guardars the specified tipo_detalle_personalizado_id.
        /// </summary>
        /// <param name="tipo_detalle_personalizado_id">The tipo_detalle_personalizado_id.</param>
        /// <param name="tabla_id">The tabla_id.</param>
        /// <param name="columna">The columna.</param>
        /// <param name="registro_id">The registro_id.</param>
        /// <param name="orden_descendente">if set to <c>true</c> [orden_descendente].</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Guardar(decimal tipo_detalle_personalizado_id, string tabla_id, string columna, string registro_id, bool orden_descendente, decimal caso_id, SessionService sesion)
        {
            string clausulas;
            DataTable dtDetallesActuales;

            //Borrar posibles valores almacenados previamente para el tipo de detalle y caso dados
            clausulas = DetallesPersonalizadosHistoricoService.TipoDetallePersonalizadoId_NombreCol + " = " + tipo_detalle_personalizado_id + " and " +
                        DetallesPersonalizadosHistoricoService.CasoId_NombreCol + " = " + caso_id;
            dtDetallesActuales = sesion.Db.DETALLES_PERSONALIZADOS_HISTCollection.GetAsDataTable(clausulas, string.Empty);
            for (int i = 0; i < dtDetallesActuales.Rows.Count; i++)
            {
                DetallesPersonalizadosHistoricoDetallesService.Borrar((decimal)dtDetallesActuales.Rows[i][DetallesPersonalizadosHistoricoService.Id_NombreCol], sesion);
            }
            sesion.Db.DETALLES_PERSONALIZADOS_HISTCollection.Delete(clausulas);

            //Obtener los detalles personalizados por tipo para 
            dtDetallesActuales = DetallesPersonalizadosService.GetDetallesPersonalizadosDataTable(new decimal[] { tipo_detalle_personalizado_id }, tabla_id, columna, registro_id, orden_descendente);
            for (int i = 0; i < dtDetallesActuales.Rows.Count; i++)
            {
                DETALLES_PERSONALIZADOS_HISTRow row = new DETALLES_PERSONALIZADOS_HISTRow();
                row.CASO_ID = caso_id;
                row.COLUMNA = (string)dtDetallesActuales.Rows[i][DetallesPersonalizadosService.Columna_NombreCol];
                row.FECHA_COPIADO = DateTime.Now;
                row.FECHA_CREACION = (DateTime)dtDetallesActuales.Rows[i][DetallesPersonalizadosService.FechaCreacion_NombreCol];
                row.ID = sesion.Db.GetSiguienteSecuencia("detalles_personaliz_hist_sqc");
                row.REGISTRO_ID = (string)dtDetallesActuales.Rows[i][DetallesPersonalizadosService.RegistroId_NombreCol];
                row.TABLA_ID = (string)dtDetallesActuales.Rows[i][DetallesPersonalizadosService.TablaId_NombreCol];
                row.TIPO_DETALLE_PERSONALIZADO_ID = (decimal)dtDetallesActuales.Rows[i][DetallesPersonalizadosService.TipoDetallePersonalizadoId_NombreCol];
                row.USUARIO_COPIADO_ID = sesion.Usuario.ID;
                row.USUARIO_CREACION_ID = (decimal)dtDetallesActuales.Rows[i][DetallesPersonalizadosService.UsuarioCreacionId_NombreCol];

                sesion.Db.DETALLES_PERSONALIZADOS_HISTCollection.Insert(row);

                #region Guardar los detalles segun el tipo
                DataTable dtDetallesActualesValores = DetallesPersonalizadosDetallesService.GetDetallesPersonalizadosDetalleDataTable((decimal)dtDetallesActuales.Rows[i][DetallesPersonalizadosService.Id_NombreCol]);
                for (int j = 0; j < dtDetallesActualesValores.Rows.Count; j++)
                {
                    object valorHistorico;

                    if(!dtDetallesActualesValores.Rows[j][DetallesPersonalizadosDetallesService.ValorFecha_NombreCol].Equals(DBNull.Value))
                    {
                        valorHistorico = dtDetallesActualesValores.Rows[j][DetallesPersonalizadosDetallesService.ValorFecha_NombreCol];
                        DetallesPersonalizadosHistoricoDetallesService.Guardar(row.ID, valorHistorico, false, false, true, (decimal)dtDetallesActualesValores.Rows[j][DetallesPersonalizadosDetallesService.Orden_NombreCol], sesion);
                    }
                    else if(!dtDetallesActualesValores.Rows[j][DetallesPersonalizadosDetallesService.ValorNumero_NombreCol].Equals(DBNull.Value))
                    {
                        valorHistorico = dtDetallesActualesValores.Rows[j][DetallesPersonalizadosDetallesService.ValorNumero_NombreCol];
                        DetallesPersonalizadosHistoricoDetallesService.Guardar(row.ID, valorHistorico, true, false, false, (decimal)dtDetallesActualesValores.Rows[j][DetallesPersonalizadosDetallesService.Orden_NombreCol], sesion);
                    }
                    else
                    {
                        valorHistorico = dtDetallesActualesValores.Rows[j][DetallesPersonalizadosDetallesService.ValorTexto_NombreCol];
                        DetallesPersonalizadosHistoricoDetallesService.Guardar(row.ID, valorHistorico, false, true, false, (decimal)dtDetallesActualesValores.Rows[j][DetallesPersonalizadosDetallesService.Orden_NombreCol], sesion);
                    }
                }
                #endregion Guardar los detalles segun el tipo
            }
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "DETALLES_PERSONALIZADOS_HIST"; }
        }
        public static string CasoId_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HISTCollection.CASO_IDColumnName; }
        }
        public static string Columna_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HISTCollection.COLUMNAColumnName; }
        }
        public static string FechaCopiado_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HISTCollection.FECHA_COPIADOColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HISTCollection.FECHA_CREACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HISTCollection.IDColumnName; }
        }
        public static string TablaId_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HISTCollection.TABLA_IDColumnName; }
        }
        public static string TipoDetallePersonalizadoId_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HISTCollection.TIPO_DETALLE_PERSONALIZADO_IDColumnName; }
        }
        public static string RegistroId_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HISTCollection.REGISTRO_IDColumnName; }
        }
        public static string UsuarioCopiadoId_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HISTCollection.USUARIO_COPIADO_IDColumnName; }
        }
        public static string UsuarioCreacionId_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HISTCollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string VistaTipoDetallePersNombre_NombreCol
        {
            get { return DETALLES_PERSON_HIST_INF_COMPLCollection.TIPO_DETALLE_PERS_NOMBREColumnName; }
        }
        public static string VistaUsuarioCopiadoNombre_NombreCol
        {
            get { return DETALLES_PERSON_HIST_INF_COMPLCollection.USUARIO_COPIADO_NOMBREColumnName; }
        }
        public static string VistaUsuarioCreacionNombre_NombreCol
        {
            get { return DETALLES_PERSON_HIST_INF_COMPLCollection.USUARIO_CREACION_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
