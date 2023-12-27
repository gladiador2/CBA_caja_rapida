#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.DetallesPersonalizados;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class LegajoSubentradasService
    {
        #region GetTipoDetallePersonalizado
        /// <summary>
        /// Gets the tipo detalle personalizado.
        /// </summary>
        /// <param name="legajo_persona_subentrada_id">The legajo_persona_subentrada_id.</param>
        /// <returns></returns>
        public static decimal GetTipoDetallePersonalizado(decimal legajo_persona_subentrada_id)
        {
            using (SessionService sesion = new SessionService())
            {
                LEGAJO_SUBENTRADASRow row = sesion.Db.LEGAJO_SUBENTRADASCollection.GetByPrimaryKey(legajo_persona_subentrada_id);

                if (row.IsTIPO_DETALLE_PERSONALIZADO_IDNull)
                    return Definiciones.Error.Valor.EnteroPositivo;
                else
                    return row.TIPO_DETALLE_PERSONALIZADO_ID;
            }
        }

        #endregion GetLegajoPersonasSubentradasDataTable

        #region GetUnico
        /// <summary>
        /// Gets the unico.
        /// </summary>
        /// <param name="legajo_persona_subentrada_id">The legajo_persona_subentrada_id.</param>
        /// <returns></returns>
        public static bool GetUnico(decimal legajo_persona_subentrada_id)
        {
            using (SessionService sesion = new SessionService())
            {
                LEGAJO_SUBENTRADASRow row = sesion.Db.LEGAJO_SUBENTRADASCollection.GetByPrimaryKey(legajo_persona_subentrada_id);

                return row.UNICO.Equals(Definiciones.SiNo.Si);
            }
        }

        #endregion GetUnico

        #region GetLegajoPersonasSubentradasDataTable
        /// <summary>
        /// Gets the legajo personas subentradas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetLegajoPersonasSubentradasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.LEGAJO_SUBENTRADASCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetLegajoPersonasSubentradasDataTable

        #region GetLegajoPersonasSubentradasInfoCompleta
        /// <summary>
        /// Gets the legajo personas subentradas info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetLegajoPersonasSubentradasInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.LEGAJO_SUBENTS_INF_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetLegajoPersonasSubentradasInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    LEGAJO_SUBENTRADASRow row;
                    string valorAnterior = string.Empty;

                    if (!campos.Contains(LegajoSubentradasService.Id_NombreCol))
                    {
                        row = new LEGAJO_SUBENTRADASRow();
                        row.ID = sesion.Db.GetSiguienteSecuencia("legajo_subents_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.LEGAJO_SUBENTRADASCollection.GetRow(Id_NombreCol + " = " + campos[LegajoSubentradasService.Id_NombreCol].ToString());
                        valorAnterior = row.ToString();
                    }

                    row.LEGAJO_ENTRADA_ID = (decimal)campos[LegajoSubentradasService.LegajoEntradaId_NombreCol];
                    row.DESCRIPCION = (string)campos[LegajoSubentradasService.Descripcion_NombreCol];
                    row.ESTADO = (string)campos[LegajoSubentradasService.Estado_NombreCol];
                    row.NOMBRE = (string)campos[LegajoSubentradasService.Nombre_NombreCol];
                    row.UNICO = (string)campos[LegajoSubentradasService.Unico_NombreCol];

                    if (campos.Contains(LegajoSubentradasService.TipoDetallePersonalizadoId_NombreCol))
                    {
                        if (row.IsTIPO_DETALLE_PERSONALIZADO_IDNull || row.TIPO_DETALLE_PERSONALIZADO_ID != (decimal)campos[LegajoSubentradasService.TipoDetallePersonalizadoId_NombreCol])
                        { 
                            row.TIPO_DETALLE_PERSONALIZADO_ID = (decimal)campos[LegajoSubentradasService.TipoDetallePersonalizadoId_NombreCol];
                            if (!TiposDetallesPersonalizadosService.EstaActivo(row.TIPO_DETALLE_PERSONALIZADO_ID))
                                throw new Exception("El tipo de detalle personalizado no está activo.");
                        }
                    }
                    else
                    {
                        row.IsTIPO_DETALLE_PERSONALIZADO_IDNull = true;
                    }

                    if (!campos.Contains(LegajoSubentradasService.Id_NombreCol)) sesion.Db.LEGAJO_SUBENTRADASCollection.Insert(row);
                    else sesion.Db.LEGAJO_SUBENTRADASCollection.Update(row);

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
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "LEGAJO_SUBENTRADAS"; }
        }
        public static string Descripcion_NombreCol
        {
            get { return LEGAJO_SUBENTRADASCollection.DESCRIPCIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return LEGAJO_SUBENTRADASCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return LEGAJO_SUBENTRADASCollection.IDColumnName; }
        }
        public static string LegajoEntradaId_NombreCol
        {
            get { return LEGAJO_SUBENTRADASCollection.LEGAJO_ENTRADA_IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return LEGAJO_SUBENTRADASCollection.NOMBREColumnName; }
        }
        public static string TipoDetallePersonalizadoId_NombreCol
        {
            get { return LEGAJO_SUBENTRADASCollection.TIPO_DETALLE_PERSONALIZADO_IDColumnName; }
        }
        public static string Unico_NombreCol
        {
            get { return LEGAJO_SUBENTRADASCollection.UNICOColumnName; }
        }
        public static string VistaLegajoEntradaDesc_NombreCol
        {
            get { return LEGAJO_SUBENTS_INF_COMPLCollection.LEGAJO_ENTRADA_DESCColumnName; }
        }
        public static string VistaLegajoEntradaNombre_NombreCol
        {
            get { return LEGAJO_SUBENTS_INF_COMPLCollection.LEGAJO_ENTRADA_NOMBREColumnName; }
        }
        public static string VistaTipoDetallePersonaliNombre_NombreCol
        {
            get { return LEGAJO_SUBENTS_INF_COMPLCollection.TIPO_DETALLE_PERSONALI_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
