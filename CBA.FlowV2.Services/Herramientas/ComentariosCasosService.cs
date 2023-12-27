using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.General;

namespace CBA.FlowV2.Services.Herramientas
{
    public class ComentariosCasosService
    {
        #region GetComentariosCasosDataTable
        public DataTable GetComentariosCasosDataTable(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    string where = ComentariosCasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                    if (clausulas.Length > 0)
                        where += " and " + clausulas;

                    return sesion.Db.COMENTARIOS_CASOSCollection.GetAsDataTable(where, orden);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetComentariosCasosDataTable

        #region GetComentariosInfoCompleta
        public static DataTable GetComentariosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = ComentariosCasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas.Length > 0)
                    where += " and " + clausulas;

                return sesion.db.COMENTARIOS_CASOS_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetComentariosInfoCompleta

        #region Guardar
        public decimal Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    decimal id = Guardar(campos, sesion);
                    sesion.db.CommitTransaction();
                    return id;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        public decimal Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            COMENTARIOS_CASOSRow row = new COMENTARIOS_CASOSRow();
            string valorAnterior = string.Empty;

        
            row.ID = sesion.Db.GetSiguienteSecuencia("comentarios_casos_sqc");
            row.RECORDATORIO = Definiciones.Estado.Inactivo;
            valorAnterior = Definiciones.Log.RegistroNuevo;

            row.USUARIO_ID = sesion.Usuario.ID;

            if (campos.Contains(ComentariosCasosService.CasoId_NombreCol) &&
                !campos.Contains(ComentariosCasosService.TablaId_NombreCol))
            {
                row.CASO_ID = (decimal)campos[ComentariosCasosService.CasoId_NombreCol];
                row.TABLA_ID = string.Empty;
                row.IsTABLA_REGISTRO_IDNull = true;
            }
            else if (!campos.Contains(ComentariosCasosService.CasoId_NombreCol) &&
                    campos.Contains(ComentariosCasosService.TablaId_NombreCol))
            {
                row.IsCASO_IDNull = true;
                row.TABLA_ID = campos[ComentariosCasosService.TablaId_NombreCol].ToString().ToUpper();
                row.TABLA_REGISTRO_ID = (decimal)campos[ComentariosCasosService.TablaRegistroId_NombreCol];
            }
            else
            {
                throw new Exception("El comentario debe ser sobre una entidad o caso");
            }

            row.ES_PRIVADO = (string)campos[ComentariosCasosService.EsPrivado_NombreCol];
            row.ESTADO = Definiciones.Estado.Activo;
            row.FECHA = DateTime.Now;
            row.OBSERVACION = (string)campos[ComentariosCasosService.Observacion_NombreCol];

            sesion.Db.COMENTARIOS_CASOSCollection.Insert(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }
        #endregion Guardar

        #region ActivarRecordatorio
        public static void ActivarRecordatorio(decimal comentario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    COMENTARIOS_CASOSRow row = new COMENTARIOS_CASOSRow();
                    row = sesion.Db.COMENTARIOS_CASOSCollection.GetByPrimaryKey(comentario_id);                    
                    string valorAnterior = row.ToString();

                    row.RECORDATORIO = Definiciones.Estado.Activo;

                    sesion.db.COMENTARIOS_CASOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion ActivarRecordatorio

        #region Borrar
        /// <summary>
        /// Borrars the specified comentario_caso_id.
        /// </summary>
        /// <param name="comentario_caso_id">The comentario_caso_id.</param>
        public void Borrar(decimal comentario_caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                COMENTARIOS_CASOSRow row = sesion.Db.COMENTARIOS_CASOSCollection.GetByPrimaryKey(comentario_caso_id);
                string valorAnterior = row.ToString();

                row.USUARIO_BORRADO_ID = sesion.Usuario.ID;
                row.FECHA_BORRADO = DateTime.Now;
                row.ESTADO = Definiciones.Estado.Inactivo;

                sesion.Db.COMENTARIOS_CASOSCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
        }
        #endregion Borrar

        #region BorrarTodosDelCaso
        /// <summary>
        /// Borrars the todos del caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// 
        public void BorrarTodosDelCaso(decimal caso_id, SessionService sesion)
        {
            COMENTARIOS_CASOSRow[] rows = sesion.Db.COMENTARIOS_CASOSCollection.GetByCASO_ID(caso_id);

            for (int i = 0; i < rows.Length; i++)
            {
                sesion.Db.COMENTARIOS_CASOSCollection.Delete(rows[i]);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[i].ID, rows[i].ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
        }
        #endregion BorrarTodosDelCaso

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "COMENTARIOS_CASOS"; }
        }
        public static string CasoId_NombreCol
        {
            get { return COMENTARIOS_CASOSCollection.CASO_IDColumnName; }
        }
        public static string EsPrivado_NombreCol
        {
            get { return COMENTARIOS_CASOSCollection.ES_PRIVADOColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return COMENTARIOS_CASOSCollection.ESTADOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return COMENTARIOS_CASOSCollection.FECHAColumnName; }
        }
        public static string FechaBorrado_NombreCol
        {
            get { return COMENTARIOS_CASOSCollection.FECHA_BORRADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return COMENTARIOS_CASOSCollection.IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return COMENTARIOS_CASOSCollection.OBSERVACIONColumnName; }
        }
        public static string TablaId_NombreCol
        {
            get { return COMENTARIOS_CASOSCollection.TABLA_IDColumnName; }
        }
        public static string TablaRegistroId_NombreCol
        {
            get { return COMENTARIOS_CASOSCollection.TABLA_REGISTRO_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return COMENTARIOS_CASOSCollection.USUARIO_IDColumnName; }
        }
        public static string UsuarioBorradoId_NombreCol
        {
            get { return COMENTARIOS_CASOSCollection.USUARIO_BORRADO_IDColumnName; }
        }
        public static string Recordatorio_NombreCol
        {
            get { return COMENTARIOS_CASOSCollection.RECORDATORIOColumnName; }
        }
        public static string VistaAdjuntoNombreArchivo_NombreCol
        {
            get { return COMENTARIOS_CASOS_INFO_COMPCollection.ADJUNTO_NOMBRE_ARCHIVOColumnName; }
        }
        public static string VistaUsuarioNombre_NombreCol
        {
            get { return COMENTARIOS_CASOS_INFO_COMPCollection.USUARIO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
