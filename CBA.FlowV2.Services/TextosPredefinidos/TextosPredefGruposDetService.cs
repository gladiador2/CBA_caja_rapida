#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Services.TextosPredefinidos
{
    public class TextosPredefinidoGruposDetService
    {
        #region GetDataTable
        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <param name="texto_predefinido_grupo_id">The texto_predefinido_grupo_id.</param>
        /// <returns></returns>
        public static DataTable GetDataTable(decimal texto_predefinido_grupo_id)
        {
            using (SessionService sesion = new SessionService()) 
            {
                return sesion.Db.TEXTO_PREDEF_GRUPOS_DETCollection.GetAsDataTable(TextoPredefinidoGrupoId_NombreCol + " = " + texto_predefinido_grupo_id, string.Empty);
            }
        }
        #endregion GetDataTable

        #region GetInfoCompleta
        /// <summary>
        /// Gets the information completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TEXTO_PREDEF_GRUPO_DET_INF_COMCollection.GetAsDataTable(clausulas, orden);    
            }
        }
        #endregion GetInfoCompleta

        #region GetTextosPredefinidosDataTable
        /// <summary>
        /// Gets the textos predefinidos en grupo.
        /// </summary>
        /// <param name="texto_predefinido_grupo_id">The texto_predefinido_grupo_id.</param>
        /// <returns></returns>
        public static List<decimal> GetTextosPredefinidosEnGrupo(decimal texto_predefinido_grupo_id)
        {
            List<decimal> textosIncluidos = new List<decimal>();
            GetTextosPredefinidosEnGrupo(texto_predefinido_grupo_id, ref textosIncluidos);
            return textosIncluidos;
        }

        private static void GetTextosPredefinidosEnGrupo(decimal texto_predefinido_grupo_id, ref List<decimal> textos_incluidos)
        {
            DataTable dt = GetDataTable(texto_predefinido_grupo_id);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Interprete.EsNullODBNull(dt.Rows[i][TextoPredefinidoId_NombreCol]))
                    GetTextosPredefinidosEnGrupo((decimal)dt.Rows[i][TextoPredefinidoGrupoHijoId_NombreCol], ref textos_incluidos);
                else
                    textos_incluidos.Add((decimal)dt.Rows[i][TextoPredefinidoId_NombreCol]);
            }
        }
        #endregion GetTextosPredefinidosDataTable

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <returns></returns>
        public static decimal Guardar(decimal texto_predefinido_id, decimal texto_predefinido_grupo_id, decimal texto_predefinido_g_hijo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    #region Validar que no es parte del grupo
                    string clausulas = TextosPredefinidoGruposDetService.TextoPredefinidoGrupoId_NombreCol + " = " + texto_predefinido_grupo_id + " and " +
                                       TextosPredefinidoGruposDetService.TextoPredefinidoId_NombreCol + " = " + texto_predefinido_id;
                    DataTable dt = GetInfoCompleta(clausulas, string.Empty);

                    if (dt.Rows.Count > 0)
                        throw new Exception("El Texto Predefinido " + dt.Rows[0][TextosPredefinidoGruposDetService.VistaTextoPredefinido_NombreCol] + " ya forma parte del grupo.");
                    #endregion Validar que no es parte del grupo

                    TEXTO_PREDEF_GRUPOS_DETRow row = new TEXTO_PREDEF_GRUPOS_DETRow();
                    string valorAnterior = string.Empty;
                    
                    row.ID = sesion.Db.GetSiguienteSecuencia("TEXTO_PREDEF_GRUPOS_DET_SQC");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    
                    row.TEXTO_PREDEFINIDO_GRUPO_ID = texto_predefinido_grupo_id;
                   
                    if (!texto_predefinido_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        row.TEXTO_PREDEFINIDO_ID = texto_predefinido_id;

                    if (!texto_predefinido_g_hijo_id.Equals(Definiciones.Error.Valor.EnteroPositivo))   
                        row.TEXTO_PREDEF_G_HIJO_ID = texto_predefinido_g_hijo_id;                   
                    
                    sesion.Db.TEXTO_PREDEF_GRUPOS_DETCollection.Insert(row);
                    
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();

                    return row.ID;
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
        /// Borrars the specified centro_costo_grupo_detalle_id.
        /// </summary>
        /// <param name="centro_costo_grupo_detalle_id">The centro_costo_grupo_detalle_id.</param>
        public static void Borrar(decimal texto_predef_grupo_det_id)
        {
            using (SessionService sesion = new SessionService())
            {
                TEXTO_PREDEF_GRUPOS_DETRow row = sesion.Db.TEXTO_PREDEF_GRUPOS_DETCollection.GetByPrimaryKey(texto_predef_grupo_det_id);
                sesion.Db.TEXTO_PREDEF_GRUPOS_DETCollection.Delete(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TEXTO_PREDEF_GRUPOS_DET"; }
        }
        public static string Nombre_Vista
        {
            get { return "TEXTO_PREDEF_GRUPO_DET_INF_COM"; }
        }
        public static string Id_NombreCol
        {
            get { return TEXTO_PREDEF_GRUPOS_DETCollection.IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return TEXTO_PREDEF_GRUPOS_DETCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string TextoPredefinidoGrupoId_NombreCol
        {
            get { return TEXTO_PREDEF_GRUPOS_DETCollection.TEXTO_PREDEFINIDO_GRUPO_IDColumnName; }
        }
        public static string TextoPredefinidoGrupoHijoId_NombreCol
        {
            get { return TEXTO_PREDEF_GRUPOS_DETCollection.TEXTO_PREDEF_G_HIJO_IDColumnName; }
        }
        public static string VistaTextoPredefinido_NombreCol
        {
            get { return TEXTO_PREDEF_GRUPO_DET_INF_COMCollection.TEXTO_PREDEFINIDOColumnName;  }
        }
        public static string VistaTextoPredefinidoGrupoNombre_NombreCol
        {
            get { return TEXTO_PREDEF_GRUPO_DET_INF_COMCollection.TEXTO_PRED_GRUPO_NOMBREColumnName; }
        }
        public static string VistaTextoPredefinidoGrupoEstado_NombreCol
        {
            get { return TEXTO_PREDEF_GRUPO_DET_INF_COMCollection.TEXTO_PRED_GRUPO_ESTADOColumnName; }
        }
        public static string VistaTextoPredefinidoGrupoHijoNombre_NombreCol
        {
            get { return TEXTO_PREDEF_GRUPO_DET_INF_COMCollection.TEXTO_PREDEF_G_HIJO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}




