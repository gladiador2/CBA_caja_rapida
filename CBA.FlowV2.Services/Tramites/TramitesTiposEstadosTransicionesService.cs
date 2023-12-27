#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Tramites
{
    public class TramitesTiposEstadosTransicionesService
    {
        #region GetTramitesTiposEstadosTransicionesDataTable
        /// <summary>
        /// Gets the tramites tipos estados transiciones data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesTiposEstadosTransicionesDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMITES_TIPOS_EST_TRANSICIONCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesTiposEstadosTransicionesDataTable

        #region GetTramitesTiposEstadosTransicionesInfoCompleta
        /// <summary>
        /// Gets the tramites tipos estados transiciones info completa.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesTiposEstadosTransicionesInfoCompleta(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMIT_TIP_EST_TRANS_INF_COMPCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesTiposEstadosTransicionesInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    TRAMITES_TIPOS_EST_TRANSICIONRow row = new TRAMITES_TIPOS_EST_TRANSICIONRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("tramit_tip_est_transicion_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.TRAMITES_TIPOS_EST_TRANSICIONCollection.GetRow(TramitesTiposEstadosTransicionesService.Id_NombreCol + " = " + campos[TramitesTiposEstadosTransicionesService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.TRAMITE_TIPO_ESTADO_DESTINO_ID = (decimal)campos[TramitesTiposEstadosTransicionesService.TramiteTipoEstadoDestinoId_NombreCol];
                    row.TRAMITE_TIPO_ESTADO_ORIGEN_ID = (decimal)campos[TramitesTiposEstadosTransicionesService.TramiteTipoEstadoOrigenId_NombreCol];

                    if (insertarNuevo) sesion.Db.TRAMITES_TIPOS_EST_TRANSICIONCollection.Insert(row);
                    else sesion.Db.TRAMITES_TIPOS_EST_TRANSICIONCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified estado_transicion_id.
        /// </summary>
        /// <param name="estado_transicion_id">The estado_transicion_id.</param>
        public static void Borrar(decimal estado_transicion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    TRAMITES_TIPOS_EST_TRANSICIONRow row = new TRAMITES_TIPOS_EST_TRANSICIONRow();
                    row = sesion.Db.TRAMITES_TIPOS_EST_TRANSICIONCollection.GetByPrimaryKey(estado_transicion_id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.TRAMITES_TIPOS_EST_TRANSICIONCollection.DeleteByPrimaryKey(estado_transicion_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TRAMITES_TIPOS_EST_TRANSICION"; }
        }
        public static string Id_NombreCol
        {
            get { return TRAMITES_TIPOS_EST_TRANSICIONCollection.IDColumnName; }
        }
        public static string TramiteTipoEstadoDestinoId_NombreCol
        {
            get { return TRAMITES_TIPOS_EST_TRANSICIONCollection.TRAMITE_TIPO_ESTADO_DESTINO_IDColumnName; }
        }
        public static string TramiteTipoEstadoOrigenId_NombreCol
        {
            get { return TRAMITES_TIPOS_EST_TRANSICIONCollection.TRAMITE_TIPO_ESTADO_ORIGEN_IDColumnName; }
        }
        public static string VistaTramiteTipoEstadoOrigenNombre_NombreCol
        {
            get { return TRAMIT_TIP_EST_TRANS_INF_COMPCollection.TRAMITE_TIPO_ESTADO_ORIGEN_NOMColumnName; }
        }
        public static string VistaTramiteTipoEstadoDestinoNombre_NombreCol
        {
            get { return TRAMIT_TIP_EST_TRANS_INF_COMPCollection.TRAMITES_TIPOS_ESTAD_DEST_NOMColumnName; }
        }
        public static string VistaTramiteTipoEtapaDestinoId_NombreCol
        {
            get { return TRAMIT_TIP_EST_TRANS_INF_COMPCollection.TRAMITE_TIPO_ETAPA_DEST_IDColumnName; }
        }
        public static string VistaTramiteTipoEtapaDestinoNombre_NombreCol
        {
            get { return TRAMIT_TIP_EST_TRANS_INF_COMPCollection.TRAMITE_TIPO_ETAPA_DEST_NOMBREColumnName; }
        }
        public static string VistaTramiteTipoEtapaOrigenId_NombreCol
        {
            get { return TRAMIT_TIP_EST_TRANS_INF_COMPCollection.TRAMITE_TIPO_ETAPA_ORIG_IDColumnName; }
        }
        public static string VistaTramiteTipoEtapaOrigenNombre_NombreCol
        {
            get { return TRAMIT_TIP_EST_TRANS_INF_COMPCollection.TRAMITE_TIPO_ETAPA_ORIG_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
