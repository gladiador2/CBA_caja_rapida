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
    public class TramitesTiposEtapasService
    {
        #region GetTramitesTiposEtapasDataTable
        /// <summary>
        /// Gets the tramites tipos etapas data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesTiposEtapasDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMITES_TIPOS_ETAPASCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesTiposEtapasDataTable

        #region GetTramitesTiposEtapasInfoCompleta
        /// <summary>
        /// Gets the tramites tipos etapas info completa.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesTiposEtapasInfoCompleta(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMITES_TIPOS_ETAP_INF_COMPLCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesTiposEtapasInfoCompleta
        
        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    TRAMITES_TIPOS_ETAPASRow row = new TRAMITES_TIPOS_ETAPASRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("tramites_tipos_etapas_sqc");
                        row.TRAMITE_TIPO_ID = (decimal)campos[TramitesTiposEtapasService.TramiteTipoId_NombreCol];
                    }
                    else
                    {
                        row = sesion.Db.TRAMITES_TIPOS_ETAPASCollection.GetByPrimaryKey(decimal.Parse(campos[TramitesTiposEtapasService.Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = (string)campos[TramitesTiposEtapasService.Nombre_NombreCol];
                    row.ORDEN = decimal.Parse(campos[TramitesTiposEtapasService.Orden_NombreCol].ToString());
                    if (campos.Contains(TramitesTiposEtapasService.VerificarCasosAsociados_NombreCol))
                        row.VERIFICAR_CASOS_ASOCIADOS = campos[TramitesTiposEtapasService.VerificarCasosAsociados_NombreCol].ToString();
                    else
                        row.VERIFICAR_CASOS_ASOCIADOS = Definiciones.SiNo.No;
                    
                    if (insertarNuevo) sesion.Db.TRAMITES_TIPOS_ETAPASCollection.Insert(row);
                    else sesion.Db.TRAMITES_TIPOS_ETAPASCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

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
        /// Borrars the specified tramite tipo etapa id.
        /// </summary>
        /// <param name="tramiteTipoEtapaId">The tramite tipo etapa id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal tramiteTipoEtapaId, SessionService sesion)
        {
            try
            {
                TRAMITES_TIPOS_ETAPASRow fila = sesion.Db.TRAMITES_TIPOS_ETAPASCollection.GetByPrimaryKey(tramiteTipoEtapaId);

                sesion.Db.TRAMITES_TIPOS_ETAPASCollection.DeleteByPrimaryKey(tramiteTipoEtapaId);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, tramiteTipoEtapaId, fila.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }


        public static void Borrar(decimal tramiteTipoEtapaId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Borrar(tramiteTipoEtapaId, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TRAMITES_TIPOS_ETAPAS"; }
        }
        public static string Id_NombreCol
        {
            get { return TRAMITES_TIPOS_ETAPASCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TRAMITES_TIPOS_ETAPASCollection.NOMBREColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return TRAMITES_TIPOS_ETAPASCollection.ORDENColumnName; }
        }
        public static string TramiteTipoId_NombreCol
        {
            get { return TRAMITES_TIPOS_ETAPASCollection.TRAMITE_TIPO_IDColumnName; }
        }
        public static string VerificarCasosAsociados_NombreCol
        {
            get { return TRAMITES_TIPOS_ETAPASCollection.VERIFICAR_CASOS_ASOCIADOSColumnName; }
        }
        public static string VistaTramiteTipoNombre_NombreCol
        {
            get { return TRAMITES_TIPOS_ETAP_INF_COMPLCollection.TRAMITE_TIPO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
