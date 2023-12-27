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
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Services.Tramites
{
    public class TramitesCamposEtapasValoresService
    {
        #region GetTramitesCamposEtapasValoresDataTable
        public static DataTable GetTramitesCamposEtapasValoresDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTramitesCamposEtapasValoresDataTable(clausula, orden, sesion);
            }
        }
        public static DataTable GetTramitesCamposEtapasValoresDataTable(string clausula, string orden, SessionService sesion)
        {
            return sesion.Db.TRAMITES_CAMPOS_ETAPAS_VALORESCollection.GetAsDataTable(clausula, orden);
        }
        #endregion GetTramitesCamposEtapasValoresDataTable

        #region GetTramitesCamposEtapasValoresInfoCompleta
        /// <summary>
        /// Gets the tramites campos etapas valores info completa.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesCamposEtapasValoresInfoCompleta(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMIT_CAMP_ETAP_VAL_INF_COMPCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesCamposEtapasValoresInfoCompleta

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Guardar(campos, insertarNuevo, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            TRAMITES_CAMPOS_ETAPAS_VALORESRow row = new TRAMITES_CAMPOS_ETAPAS_VALORESRow();
            TRAMITES_CAMPOS_ETAPAS_VALORESRow rowOriginal = null;
            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("tramites_campos_et_valores_sqc");
                row.TRAMITE_CAMPOS_ETAPAS_ID = (decimal)campos[TramitesCamposEtapasValoresService.TramiteCamposEtapasId_NombreCol];
                row.TRAMITE_ID = (decimal)campos[TramitesCamposEtapasValoresService.TramiteId_NombreCol];
                rowOriginal = row.Clonar();
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.Db.TRAMITES_CAMPOS_ETAPAS_VALORESCollection.GetRow(TramitesCamposEtapasValoresService.Id_NombreCol + " = " + campos[TramitesCamposEtapasValoresService.Id_NombreCol]);
                valorAnterior = row.ToString();
            }

            if (campos.Contains(TramitesCamposEtapasValoresService.ValorFecha_NombreCol))
                row.VALOR_FECHA = (DateTime)campos[TramitesCamposEtapasValoresService.ValorFecha_NombreCol];
            else
                row.IsVALOR_FECHANull = true;

            if (campos.Contains(TramitesCamposEtapasValoresService.ValorNumero_NombreCol))
                row.VALOR_NUMERO = (decimal)campos[TramitesCamposEtapasValoresService.ValorNumero_NombreCol];
            else
                row.IsVALOR_NUMERONull = true;

            if (campos.Contains(TramitesCamposEtapasValoresService.ValorTexto_NombreCol))
                row.VALOR_TEXTO = (string)campos[TramitesCamposEtapasValoresService.ValorTexto_NombreCol];
            else
                row.VALOR_TEXTO = string.Empty;

            if (insertarNuevo) sesion.Db.TRAMITES_CAMPOS_ETAPAS_VALORESCollection.Insert(row);
            else sesion.Db.TRAMITES_CAMPOS_ETAPAS_VALORESCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            GuardarAccionesPorCliente(row, rowOriginal, sesion);
        }
        #endregion Guardar

        #region GuardarAccionesPorCliente
        private static void GuardarAccionesPorCliente(TRAMITES_CAMPOS_ETAPAS_VALORESRow row_actual, TRAMITES_CAMPOS_ETAPAS_VALORESRow row_original, SessionService sesion)
        {
            switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.Cliente))
            {
                case Definiciones.Clientes.Electroban:
                    GuardarAccionesPorCliente_9(row_actual, row_original, sesion);
                    break;
            }
        }

        private static void GuardarAccionesPorCliente_9(TRAMITES_CAMPOS_ETAPAS_VALORESRow row_actual, TRAMITES_CAMPOS_ETAPAS_VALORESRow row_original, SessionService sesion)
        {
            //Tipo "Gestión judicial", Camppo "Estado del juicio"
            //Si el valor es el texto predefinido id 1180 (A.I.)
            //actualizar los campos de judicial en la ficha de persona
            if (row_actual.TRAMITE_CAMPOS_ETAPAS_ID == 6 && row_actual.VALOR_NUMERO == 1191)
            {
                if (row_original == null || row_original.VALOR_NUMERO != 1191)
                {
                    var dtTramite = TramitesService.GetTramitesDataTable(TramitesService.Id_NombreCol + " = " + row_actual.TRAMITE_ID, TramitesService.Id_NombreCol, sesion);
                    if (!Interprete.EsNullODBNull(dtTramite.Rows[0][TramitesService.PersonaId_NombreCol]))
                    {
                        var dtTramiteEtapaValor = TramitesCamposEtapasValoresService.GetTramitesCamposEtapasValoresDataTable(TramitesCamposEtapasValoresService.TramiteId_NombreCol + " = " + row_actual.TRAMITE_ID + " and " + TramitesCamposEtapasValoresService.TramiteCamposEtapasId_NombreCol + " = 18", string.Empty, sesion);
                        if (dtTramiteEtapaValor.Rows.Count > 0)
                            PersonasService.ActualizarDatosJudiciales((decimal)dtTramite.Rows[0][TramitesService.PersonaId_NombreCol], (decimal)dtTramiteEtapaValor.Rows[0][TramitesCamposEtapasValoresService.ValorNumero_NombreCol], true, sesion);
                    }
                }
            }
        }
        #endregion GuardarAccionesPorCliente

        #region Borrar
        /// <summary>
        /// Borrars the specified tramite_campo_etapa_valor_id.
        /// </summary>
        /// <param name="tramite_campo_etapa_valor_id">The tramite_campo_etapa_valor_id.</param>
        public static void Borrar(decimal tramite_campo_etapa_valor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    TRAMITES_CAMPOS_ETAPAS_VALORESRow row = new TRAMITES_CAMPOS_ETAPAS_VALORESRow();
                    row = sesion.Db.TRAMITES_CAMPOS_ETAPAS_VALORESCollection.GetByPrimaryKey(tramite_campo_etapa_valor_id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.TRAMITES_CAMPOS_ETAPAS_VALORESCollection.DeleteByPrimaryKey(tramite_campo_etapa_valor_id);
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
            get { return "TRAMITES_CAMPOS_ETAPAS_VALORES"; }
        }
        public static string Id_NombreCol
        {
            get { return TRAMITES_CAMPOS_ETAPAS_VALORESCollection.IDColumnName; }
        }
        public static string TramiteCamposEtapasId_NombreCol
        {
            get { return TRAMITES_CAMPOS_ETAPAS_VALORESCollection.TRAMITE_CAMPOS_ETAPAS_IDColumnName; }
        }
        public static string TramiteId_NombreCol
        {
            get { return TRAMITES_CAMPOS_ETAPAS_VALORESCollection.TRAMITE_IDColumnName; }
        }
        public static string ValorFecha_NombreCol
        {
            get { return TRAMITES_CAMPOS_ETAPAS_VALORESCollection.VALOR_FECHAColumnName; }
        }
        public static string ValorNumero_NombreCol
        {
            get { return TRAMITES_CAMPOS_ETAPAS_VALORESCollection.VALOR_NUMEROColumnName; }
        }
        public static string ValorTexto_NombreCol
        {
            get { return TRAMITES_CAMPOS_ETAPAS_VALORESCollection.VALOR_TEXTOColumnName; }
        }
        public static string VistaTramiteCamposEtapasNombre_NombreCol
        {
            get { return TRAMIT_CAMP_ETAP_VAL_INF_COMPCollection.TRAMITE_CAMPOS_ETAPAS_NOMBREColumnName; }
        }
        public static string VistaTramiteTitulo_NombreCol
        {
            get { return TRAMIT_CAMP_ETAP_VAL_INF_COMPCollection.TRAMITE_TITULOColumnName; }
        }
        public static string VistaTramiteObservacion_NombreCol
        {
            get { return TRAMIT_CAMP_ETAP_VAL_INF_COMPCollection.TRAMITE_OBSERVACIONColumnName; }
        }
        public static string VistaTramiteTipoId_NombreCol
        {
            get { return TRAMIT_CAMP_ETAP_VAL_INF_COMPCollection.TRAMITE_TIPO_IDColumnName; }
        }
        public static string VistaTramiteTipoNombre_NombreCol
        {
            get { return TRAMIT_CAMP_ETAP_VAL_INF_COMPCollection.TRAMITE_TIPO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
