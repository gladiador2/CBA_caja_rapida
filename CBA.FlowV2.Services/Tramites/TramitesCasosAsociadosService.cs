#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using Oracle.ManagedDataAccess.Client;
using System.Data;
#endregion Using

namespace CBA.FlowV2.Services.Tramites
{
    public class TramitesCasosAsociadosService
    {
        #region GetTramitesCasosAsociadosDataTable
        /// <summary>
        /// Gets the tramites casos asociados data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesCasosAsociadosDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMITES_CASOS_ASOCIADOSCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesCasosAsociadosDataTable

        #region GetTramitesCasosAsociadosInfoCompleta
        /// <summary>
        /// Gets the tramites casos asociados info completa.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesCasosAsociadosInfoCompleta(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMITES_CAS_ASOC_INF_COMPCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesCasosAsociadosInfoCompleta
        
        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    Guardar(campos, insertarNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            TRAMITES_CASOS_ASOCIADOSRow row = new TRAMITES_CASOS_ASOCIADOSRow();
            String valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                valorAnterior = Definiciones.Log.RegistroNuevo;
                row.ID = sesion.Db.GetSiguienteSecuencia("tramites_casos_asociados_sqc");
                row.TRAMITE_ID = (decimal)campos[TramitesCasosAsociadosService.TramiteId_NombreCol];
            }
            else
            {
                row = sesion.Db.TRAMITES_CASOS_ASOCIADOSCollection.GetByPrimaryKey(decimal.Parse(campos[TramitesCasosAsociadosService.Id_NombreCol].ToString()));
                valorAnterior = row.ToString();
            }

            row.CASO_ID = (decimal)campos[TramitesCasosAsociadosService.CasoId_NombreCol];
            row.FECHA_AGREGADO = (DateTime)campos[TramitesCasosAsociadosService.FechaAgregado_NombreCol];
            row.USUARIO_ID = (decimal)campos[TramitesCasosAsociadosService.UsuarioId_NombreCol];
            if (campos.Contains(TramitesCasosAsociadosService.Observacion_NombreCol))
                row.OBSERVACION = (string)campos[TramitesCasosAsociadosService.Observacion_NombreCol];

            if (campos.Contains(TramitesCasosAsociadosService.TramiteTipoEtapaId_NombreCol))
                row.TRAMITE_TIPO_ETAPA_ID = (decimal)campos[TramitesCasosAsociadosService.TramiteTipoEtapaId_NombreCol];

            if (insertarNuevo) sesion.Db.TRAMITES_CASOS_ASOCIADOSCollection.Insert(row);
            else sesion.Db.TRAMITES_CASOS_ASOCIADOSCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified tramite caso asociado id.
        /// </summary>
        /// <param name="tramiteCasoAsociadoId">The tramite caso asociado id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal tramiteCasoAsociadoId, SessionService sesion)
        {
            try
            {
                TRAMITES_CASOS_ASOCIADOSRow fila = sesion.Db.TRAMITES_CASOS_ASOCIADOSCollection.GetByPrimaryKey(tramiteCasoAsociadoId);

                sesion.Db.TRAMITES_CASOS_ASOCIADOSCollection.DeleteByPrimaryKey(tramiteCasoAsociadoId);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, tramiteCasoAsociadoId, fila.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static void Borrar(decimal tramiteCasoAsociadoId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Borrar(tramiteCasoAsociadoId, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void BorrarPorCasoAsociado(decimal caso_asociado_id, SessionService sesion)
        {
            try
            {
                var rows = sesion.Db.TRAMITES_CASOS_ASOCIADOSCollection.GetByCASO_ID(caso_asociado_id);
                for (int i = 0; i < rows.Length; i++)
                {
                    sesion.Db.TRAMITES_CASOS_ASOCIADOSCollection.DeleteByPrimaryKey(rows[i].ID);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[i].ID, rows[i].ToString(), Definiciones.Log.RegistroBorrado, sesion);    
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TRAMITES_CASOS_ASOCIADOS"; }
        }
        public static string CasoId_NombreCol
        {
            get { return TRAMITES_CASOS_ASOCIADOSCollection.CASO_IDColumnName; }
        }
        public static string FechaAgregado_NombreCol
        {
            get { return TRAMITES_CASOS_ASOCIADOSCollection.FECHA_AGREGADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return TRAMITES_CASOS_ASOCIADOSCollection.IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return TRAMITES_CASOS_ASOCIADOSCollection.OBSERVACIONColumnName; }
        }
        public static string TramiteId_NombreCol
        {
            get { return TRAMITES_CASOS_ASOCIADOSCollection.TRAMITE_IDColumnName; }
        }
        public static string TramiteTipoEtapaId_NombreCol
        {
            get { return TRAMITES_CASOS_ASOCIADOSCollection.TRAMITE_TIPO_ETAPA_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return TRAMITES_CASOS_ASOCIADOSCollection.USUARIO_IDColumnName; }
        }
        public static string VistaCasoFlujoDescripcion_NombreCol
        {
            get { return TRAMITES_CAS_ASOC_INF_COMPCollection.CASO_FLUJO_DESCRIPCIONColumnName; }
        }
        public static string VistaCasoFlujoId_NombreCol
        {
            get { return TRAMITES_CAS_ASOC_INF_COMPCollection.CASO_FLUJO_IDColumnName; }
        }
        public static string VistaTramiteTitulo_NombreCol
        {
            get { return TRAMITES_CAS_ASOC_INF_COMPCollection.TRAMITE_TITULOColumnName; }
        }
        public static string VistaTramiteTipoEtapaNombre_NombreCol
        {
            get { return TRAMITES_CAS_ASOC_INF_COMPCollection.TRAMITE_TIPO_ETAPA_NOMBREColumnName; }
        }
        public static string VistaUsuarioNombre_NombreCol
        {
            get { return TRAMITES_CAS_ASOC_INF_COMPCollection.USUARIO_NOMBREColumnName; }
        }
        
        #endregion Accessors
    }
}
