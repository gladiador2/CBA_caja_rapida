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
    public class TramitesTiposEtapasDestinoService
    {
        #region GetTramitesTiposEtapasDestinoDataTable
        /// <summary>
        /// Gets the tramites tipos etapas destino data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesTiposEtapasDestinoDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMITES_TIPOS_ETAPAS_DESTINOCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesTiposEtapasDestinoDataTable

        #region GetTramitesTiposEtapasDestinoInfoCompleta
        /// <summary>
        /// Gets the tramites tipos etapas destino data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesTiposEtapasDestinoInfoCompleta(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMIT_TIP_ET_DEST_INF_COMPCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesTiposEtapasDestinoInfoCompleta

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

                    TRAMITES_TIPOS_ETAPAS_DESTINORow row = new TRAMITES_TIPOS_ETAPAS_DESTINORow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("tramites_tipos_et_destino_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.TRAMITES_TIPOS_ETAPAS_DESTINOCollection.GetRow(TramitesTiposEtapasDestinoService.Id_NombreCol + " = " + campos[TramitesTiposEtapasDestinoService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.TRAMITE_TIPO_ESTADO_ORIGEN_ID = (decimal)campos[TramitesTiposEtapasDestinoService.TramiteTipoEstadoOrigenId_NombreCol];
                    row.TRAMITE_TIPO_ETAPA_DESTINO_ID = (decimal)campos[TramitesTiposEtapasDestinoService.TramiteTipoEtapaDestinoId_NombreCol];

                    if (insertarNuevo) sesion.Db.TRAMITES_TIPOS_ETAPAS_DESTINOCollection.Insert(row);
                    else sesion.Db.TRAMITES_TIPOS_ETAPAS_DESTINOCollection.Update(row);

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
        /// Borrars the specified etapa_destino_id.
        /// </summary>
        /// <param name="etapa_destino_id">The etapa_destino_id.</param>
        public static void Borrar(decimal etapa_destino_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    TRAMITES_TIPOS_ETAPAS_DESTINORow row = new TRAMITES_TIPOS_ETAPAS_DESTINORow();
                    row = sesion.Db.TRAMITES_TIPOS_ETAPAS_DESTINOCollection.GetByPrimaryKey(etapa_destino_id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.TRAMITES_TIPOS_ETAPAS_DESTINOCollection.DeleteByPrimaryKey(etapa_destino_id);
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
            get { return "TRAMITES_TIPOS_ETAPAS_DESTINO"; }
        }
        public static string Id_NombreCol
        {
            get { return TRAMITES_TIPOS_ETAPAS_DESTINOCollection.IDColumnName; }
        }
        public static string TramiteTipoEstadoOrigenId_NombreCol
        {
            get { return TRAMITES_TIPOS_ETAPAS_DESTINOCollection.TRAMITE_TIPO_ESTADO_ORIGEN_IDColumnName; }
        }
        public static string TramiteTipoEtapaDestinoId_NombreCol
        {
            get { return TRAMITES_TIPOS_ETAPAS_DESTINOCollection.TRAMITE_TIPO_ETAPA_DESTINO_IDColumnName; }
        }
        public static string VistaTramiteTipoEstadoNombre_NombreCol
        {
            get { return TRAMIT_TIP_ET_DEST_INF_COMPCollection.TRAMITE_TIPO_ESTADO_NOMBREColumnName; }
        }
        public static string VistaTramiteTipoEtapaNombre_NombreCol
        {
            get { return TRAMIT_TIP_ET_DEST_INF_COMPCollection.TRAMITES_TIPOS_ETAPAS_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
