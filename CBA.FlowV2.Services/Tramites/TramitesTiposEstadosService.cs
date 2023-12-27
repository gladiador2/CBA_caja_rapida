#region Using
using System;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;
using System.Data;
#endregion Using

namespace CBA.FlowV2.Services.Tramites
{
    public class TramitesTiposEstadosService
    {
        #region GetTramitesTiposEstadosServiceDataTable
        /// <summary>
        /// Gets the tramites tipos estados service data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesTiposEstadosServiceDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMITES_TIPOS_ESTADOSCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesTiposEstadosServiceDataTable

        #region GetTramitesTiposEstadosServiceInfoCompleta
        /// <summary>
        /// Gets the tramites tipos estados service info completa.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesTiposEstadosServiceInfoCompleta(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMITES_TIPOS_ESTAD_INF_COMPLCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesTiposEstadosServiceInfoCompleta

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

                    TRAMITES_TIPOS_ESTADOSRow row = new TRAMITES_TIPOS_ESTADOSRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("tramites_tipos_estados_sqc");
                        row.TRAMITE_TIPO_ETAPA_ID = (decimal)campos[TramitesTiposEstadosService.TramiteTipoEtapaId_NombreCol];
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.TRAMITES_TIPOS_ESTADOSCollection.GetRow(TramitesTiposEstadosService.Id_NombreCol + " = " + campos[TramitesTiposEstadosService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    if (!campos[TramitesTiposEstadosService.Nombre_NombreCol].Equals(string.Empty))
                        row.NOMBRE = (string)campos[TramitesTiposEstadosService.Nombre_NombreCol];
                    else
                        throw new Exception("El campo Nombre no puede estar vacío");

                    if (campos.Contains(TramitesTiposEstadosService.Descripcion_NombreCol))
                        row.DESCRIPCION = (string)campos[TramitesTiposEstadosService.Descripcion_NombreCol];

                    if (campos.Contains(TramitesTiposEstadosService.EsInicio_NombreCol))
                        row.ES_INICIO = (string)campos[TramitesTiposEstadosService.EsInicio_NombreCol];

                    if (campos.Contains(TramitesTiposEstadosService.EsFin_NombreCol))
                        row.ES_FIN = (string)campos[TramitesTiposEstadosService.EsFin_NombreCol];

                    if (insertarNuevo)
                        sesion.Db.TRAMITES_TIPOS_ESTADOSCollection.Insert(row);
                    else
                        sesion.Db.TRAMITES_TIPOS_ESTADOSCollection.Update(row);

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
        /// Borrars the specified estado_id.
        /// </summary>
        /// <param name="estado_id">The estado_id.</param>
        public static void Borrar(decimal estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    TRAMITES_TIPOS_ESTADOSRow row = new TRAMITES_TIPOS_ESTADOSRow();
                    row = sesion.Db.TRAMITES_TIPOS_ESTADOSCollection.GetByPrimaryKey(estado_id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.TRAMITES_TIPOS_ESTADOSCollection.DeleteByPrimaryKey(estado_id);
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
            get { return "TRAMITES_TIPOS_ESTADOS"; }
        }
        public static string Descripcion_NombreCol
        {
            get { return TRAMITES_TIPOS_ESTADOSCollection.DESCRIPCIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return TRAMITES_TIPOS_ESTADOSCollection.IDColumnName; }
        }
        public static string EsFin_NombreCol
        {
            get { return TRAMITES_TIPOS_ESTADOSCollection.ES_FINColumnName; }
        }
        public static string EsInicio_NombreCol
        {
            get { return TRAMITES_TIPOS_ESTADOSCollection.ES_INICIOColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TRAMITES_TIPOS_ESTADOSCollection.NOMBREColumnName; }
        }
        public static string TramiteTipoEtapaId_NombreCol
        {
            get { return TRAMITES_TIPOS_ESTADOSCollection.TRAMITE_TIPO_ETAPA_IDColumnName; }
        }
        public static string VistaTramiteTipoEtapaNombre_NombreCol
        {
            get { return TRAMITES_TIPOS_ESTAD_INF_COMPLCollection.TRAMITE_TIPO_ETAPA_NOMBREColumnName; }
        }
        public static string VistaTramiteTipoId_NombreCol
        {
            get { return TRAMITES_TIPOS_ESTAD_INF_COMPLCollection.TRAMITE_TIPO_IDColumnName; }
        }
        public static string VistaTramiteTipoNombre_NombreCol
        {
            get { return TRAMITES_TIPOS_ESTAD_INF_COMPLCollection.TRAMITE_TIPO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
