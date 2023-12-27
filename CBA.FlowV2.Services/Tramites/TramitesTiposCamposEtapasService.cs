#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using Oracle.ManagedDataAccess.Client;
#endregion Using

namespace CBA.FlowV2.Services.Tramites
{
    public class TramitesTiposCamposEtapasService
    {
        #region GetTramitesTiposCamposEtapasDataTable
        /// <summary>
        /// Gets the tramites tipos campos etapas data table.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        public static DataTable GetTramitesTiposCamposEtapasDataTable(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService()) {
                return sesion.Db.TRAMITES_TIPOS_CAMPOS_ETAPASCollection.GetAsDataTable(where, orderBy);
            } 
        }
        #endregion GetTramitesTiposCamposEtapasDataTable

        #region GetTramitesTiposCamposEtapasInfoCompleta
        /// <summary>
        /// Gets the tramites tipos campos etapas data table.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        public static DataTable GetTramitesTiposCamposEtapasInfoCompleta(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMIT_TIP_CAMP_ETAP_INF_COMPCollection.GetAsDataTable(where, orderBy);
            }
        }
        #endregion GetTramitesTiposCamposEtapasInfoCompleta

        #region GetTipoTextoPredefinidoId
        public static int GetTipoTextoPredefinidoId(decimal tramite_tipo_campo_etapa_id)
        {
            int tipoTextoPredefinidoId;
            using (CBAV2 db = new CBAV2())
            {
                tipoTextoPredefinidoId = (int)db.TRAMITES_TIPOS_CAMPOS_ETAPASCollection.GetByPrimaryKey(tramite_tipo_campo_etapa_id).TIPO_TEXTO_PREDEFINIDO_ID;
            }
            return tipoTextoPredefinidoId;
        }
        #endregion GetTipoTextoPredefinidoId

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
                    sesion.Db.BeginTransaction();
                    TRAMITES_TIPOS_CAMPOS_ETAPASRow row = new TRAMITES_TIPOS_CAMPOS_ETAPASRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("tramites_tipos_campos_et_sqc");
                    }
                    else
                    {
                        row = sesion.Db.TRAMITES_TIPOS_CAMPOS_ETAPASCollection.GetByPrimaryKey(decimal.Parse(campos[TramitesTiposCamposEtapasService.Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = campos[TramitesTiposCamposEtapasService.Nombre_NombreCol].ToString();
                    row.ORDEN = decimal.Parse(campos[TramitesTiposCamposEtapasService.Orden_NombreCol].ToString());
                    row.TIPO_DE_DATO_ID = decimal.Parse(campos[TramitesTiposCamposEtapasService.TipoDeDatoId_NombreCol].ToString());
                    row.ES_OBLIGATORIO = (string)campos[TramitesTiposCamposEtapasService.EsObligatorio_NombreCol];
                    row.GENERA_ALARMA = campos[TramitesTiposCamposEtapasService.GeneraAlarma_NombreCol].ToString();

                    //Debe traer o la etapa id, o el tipo de tramite id en el caso de que el campo no pertenece a ninguna etapa.
                    if (campos.Contains(TramitesTiposCamposEtapasService.TramiteTipoEtapaId_NombreCol) || campos.Contains(TramitesTiposCamposEtapasService.TramiteTipoId_NombreCol))
                    {
                        if (campos.Contains(TramitesTiposCamposEtapasService.TramiteTipoEtapaId_NombreCol)){
                            if (decimal.Parse(campos[TramitesTiposCamposEtapasService.TramiteTipoEtapaId_NombreCol].ToString()).Equals(Definiciones.Error.Valor.EnteroPositivo))
                                row.IsTRAMITE_TIPO_ETAPA_IDNull = true;
                            else
                                row.TRAMITE_TIPO_ETAPA_ID = decimal.Parse(campos[TramitesTiposCamposEtapasService.TramiteTipoEtapaId_NombreCol].ToString());
                        }
                        if (campos.Contains(TramitesTiposCamposEtapasService.TramiteTipoId_NombreCol))
                            row.TRAMITE_TIPO_ID = decimal.Parse(campos[TramitesTiposCamposEtapasService.TramiteTipoId_NombreCol].ToString());
                    }
                    else
                    {
                        throw new Exception("Debe traer el id de la etapa a la que corresponde el campo, o en su defecto el id del tipo de trámite.");
                    }

                    if (campos.Contains(TramitesTiposCamposEtapasService.TipoTextoPredefinidoId_NombreCol))
                        row.TIPO_TEXTO_PREDEFINIDO_ID = (decimal)campos[TramitesTiposCamposEtapasService.TipoTextoPredefinidoId_NombreCol];
                    else
                        row.IsTIPO_TEXTO_PREDEFINIDO_IDNull = true;
                    
                    if (insertarNuevo) sesion.Db.TRAMITES_TIPOS_CAMPOS_ETAPASCollection.Insert(row);
                    else sesion.Db.TRAMITES_TIPOS_CAMPOS_ETAPASCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

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

        #region Borrar
        /// <summary>
        /// Borrars the specified tramite tipo id.
        /// </summary>
        /// <param name="tramiteTipoId">The tramite tipo id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal tramiteTipoId, SessionService sesion)
        {
            try
            {
                TRAMITES_TIPOS_CAMPOS_ETAPASRow fila = sesion.Db.TRAMITES_TIPOS_CAMPOS_ETAPASCollection.GetByPrimaryKey(tramiteTipoId);

                sesion.Db.TRAMITES_TIPOS_CAMPOS_ETAPASCollection.DeleteByPrimaryKey(tramiteTipoId);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, tramiteTipoId, fila.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Borrars the specified tramite tipo id.
        /// </summary>
        /// <param name="tramiteTipoId">The tramite tipo id.</param>
        public static void Borrar(decimal tramiteTipoId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Borrar(tramiteTipoId, sesion);
                    sesion.CommitTransaction();
                }
                catch(Exception exp)
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
            get { return "TRAMITES_TIPOS_CAMPOS_ETAPAS"; }
        }
        public static string EsObligatorio_NombreCol
        {
            get { return TRAMITES_TIPOS_CAMPOS_ETAPASCollection.ES_OBLIGATORIOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return TRAMITES_TIPOS_CAMPOS_ETAPASCollection.IDColumnName; } 
        }
        public static string GeneraAlarma_NombreCol
        {
            get { return TRAMITES_TIPOS_CAMPOS_ETAPASCollection.GENERA_ALARMAColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TRAMITES_TIPOS_CAMPOS_ETAPASCollection.NOMBREColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return TRAMITES_TIPOS_CAMPOS_ETAPASCollection.ORDENColumnName; }
        }
        public static string TipoTextoPredefinidoId_NombreCol
        {
            get { return TRAMITES_TIPOS_CAMPOS_ETAPASCollection.TIPO_TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string TipoDeDatoId_NombreCol
        {
            get { return TRAMITES_TIPOS_CAMPOS_ETAPASCollection.TIPO_DE_DATO_IDColumnName; }
        }
        public static string VistaTipoTextoPredefinidoNombre_NombreCol
        {
            get { return TRAMIT_TIP_CAMP_ETAP_INF_COMPCollection.TIPO_TEXTO_PREDEFINIDO_NOMBREColumnName; }
        }
        public static string TramiteTipoEtapaId_NombreCol
        {
            get { return TRAMITES_TIPOS_CAMPOS_ETAPASCollection.TRAMITE_TIPO_ETAPA_IDColumnName; }
        }
        public static string TramiteTipoId_NombreCol
        {
            get { return TRAMITES_TIPOS_CAMPOS_ETAPASCollection.TRAMITE_TIPO_IDColumnName; }
        }
        public static string VistaTramiteTipoEtapaNombre_NombreCol
        {
            get { return TRAMIT_TIP_CAMP_ETAP_INF_COMPCollection.TRAMITE_TIPO_ETAPA_NOMBREColumnName; }
        }
        public static string VistaTramiteTipoNombre_NombreCol
        {
            get { return TRAMIT_TIP_CAMP_ETAP_INF_COMPCollection.TRAMITE_TIPO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
