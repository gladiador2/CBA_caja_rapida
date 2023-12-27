#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Services.NotasCreditoPersona
{
    public class NotasCreditoPersonaAplicacionDocumentosService
    {
        #region GetNotaCreditoAplicacionValoresDataTable
        /// <summary>
        /// Gets the nota credito persona aplicacion valores data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetNotaCreditoAplicacionDocumentosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaCreditoAplicacionDocumentosDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaCreditoAplicacionDocumentosDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.APLICACION_DOCUMENTOS_DOCCollection.GetAsDataTable(clausulas, orden);
        }

        #endregion GetNotaCreditoAplicacionValoresDataTable

        #region GetNotaCreditoAplicaionDocumentosInfoCompleta

        public static DataTable GetNotaCreditoAplicacionDocumentosInfoCompleta(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.APLICACION_DOCUMEN_DOC_INFO_COCollection.GetAsDataTable(clausulas, Id_NombreCol);
            }
        }
        public static DataTable GetAplicacionDocumentos(string ctactePersonaId){
        using (SessionService sesion = new SessionService())
        {   DataTable dt = null;
        string queryApliDoc = "select ad.caso_id " + NotasCreditoPersonaAplicacionDocumentosService.VistaCasoId_NombreCol + ",  ad.nro_recibo_manual " + NotasCreditoPersonaAplicacionDocumentosService .VistaNroComprobante_NombreCol+ "\n" +
            "from aplicacion_documentos_doc addoc, aplicacion_documentos ad\n" +
                                        "where ad.id = addoc.aplicacion_documento_id\n" +
                                        "and addoc.ctacte_persona_id = " + ctactePersonaId+ "\n";

             dt = sesion.db.EjecutarQuery(queryApliDoc);

             if (dt.Rows.Count > 0) return dt;
             else return null;
        }
        }
        #endregion GetNotaCreditoAplicaionValoresInfoCompleta

        #region Desbloquear Registros de la cuenta Corriente
        public static void DesbloquearDetalles(decimal aplicacion_documento_id, SessionService sesion)
        {
            DataTable dtDocumentos = sesion.Db.APLICACION_DOCUMENTOS_DOCCollection.GetByAPLICACION_DOCUMENTO_IDAsDataTable(aplicacion_documento_id);

            foreach (DataRow row in dtDocumentos.Rows)
            {
                if (Interprete.EsNullODBNull(row[CtaCtePersonaId_NombreCol]))
                    continue;
                CuentaCorrientePersonasService.SetBloqueado((decimal)row[CtaCtePersonaId_NombreCol], false, sesion);
            }
        }
        #endregion Desbloquear Registros de la cuenta Corriente

        #region Item Existe en la Lista
        /// <summary>
        /// Verificamos si la cuota ya esta incluidad dentro de la lista de valores
        /// </summary>
        /// <param name="NotaCreditoId">The nota credito identifier.</param>
        /// <returns></returns>
        public static bool ItemExisteEnLista(decimal CtaCtePerId, decimal caso_id)
        {

            string clausulas = NotasCreditoPersonaAplicacionDocumentosService.VistaCtaCteId_NombreCol + " = " + CtaCtePerId.ToString() + (caso_id > 0 ? " and " +
                NotasCreditoPersonaAplicacionDocumentosService.VistaAplicacionDocCasoId_NombreCol + " = " + caso_id : "");
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.APLICACION_DOCUMEN_DOC_INFO_COCollection.GetAsDataTable(clausulas, string.Empty).Rows.Count > 0 ? true : false;
            }

        }
        #endregion Item Existe en la lista

        #region Obtener Total Documentos
        /// <summary>
        /// Obtener Total Documentos
        /// </summary>
        /// <param name="NotaCreditoAplicacionId">The nota credito aplicacion identifier.</param>
        /// <returns></returns>
        public static decimal ObtenerTotalDocumentos(decimal NotaCreditoAplicacionId)
        {
            using (SessionService sesion = new SessionService())
            {
                return ObtenerTotalDocumentos(NotaCreditoAplicacionId, sesion);
            }
        }

        public static decimal ObtenerTotalDocumentos(decimal NotaCreditoAplicacionId, SessionService sesion)
        {

            string clausulas = NotasCreditoPersonaAplicacionDocumentosService.VistaAplicacionDocumentoId_NombreCol + " = " + NotaCreditoAplicacionId.ToString();

            DataTable dtResult = sesion.Db.APLICACION_DOCUMEN_DOC_INFO_COCollection.GetAsDataTable(clausulas, string.Empty);
            decimal totalDocumentos = 0;
            if (dtResult.Rows.Count > 0)
            {

                foreach (DataRow row in dtResult.Rows)
                {
                    totalDocumentos += (decimal)row[NotasCreditoPersonaAplicacionDocumentosService.VistaMontoDestino_NombreCol];
                }
            }

            return totalDocumentos;

        }
        #endregion Obtener Total Documentos

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    decimal id = Guardar(campos, sesion);
                    sesion.Db.CommitTransaction();
                    return id;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static decimal Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            APLICACION_DOCUMENTOS_DOCRow row = new APLICACION_DOCUMENTOS_DOCRow();
            DataTable dtCabecera = NotasCreditoPersonaAplicacionesService.GetNotaCreditoAplicacionDataTable((decimal)campos[NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocumentoId_NombreCol], sesion);
            string valorAnterior;

            if (campos.Contains(NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol))
            {
                var ctactePersona = new CuentaCorrientePersonasService((decimal)campos[NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol], sesion);
                if (!ctactePersona.ExisteEnDB)
                    throw new System.Exception("El documento no fue encontrado.");

                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionCtacteIndependiente, sesion) == Definiciones.SiNo.Si && ctactePersona.CasoId.HasValue)
                {
                    var sucursal = new SucursalesService((decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.SucursalId_NombreCol], sesion);
                    if (ctactePersona.Caso.Sucursal.RegionId != sucursal.RegionId)
                        throw new Exception("El documento proviene de una región distinta al caso.");
                }
            }

            valorAnterior = Definiciones.Log.RegistroNuevo;
            row.ID = sesion.Db.GetSiguienteSecuencia("APLICACION_DOCUMENTOS_DOC_SQC");

            row.APLICACION_DOCUMENTO_ID = (decimal)campos[NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocumentoId_NombreCol];

            //El detalle apunta a una cuenta corriente o a otro registro de la tabla para indicar un recargo
            if (campos.Contains(NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol))
                row.CTACTE_PERSONA_ID = (decimal)campos[NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol];
            else
                row.APLICACION_DOCU_DOC_REFERID_ID = (decimal)campos[NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocuDocReferidId_NombreCol];

            row.MONTO_ORIGEN = (decimal)campos[NotasCreditoPersonaAplicacionDocumentosService.MontoOrigen_NombreCol];
            row.MONTO_DESTINO = (decimal)campos[NotasCreditoPersonaAplicacionDocumentosService.MontoDestino_NombreCol];

            row.COTIZACION = (decimal)campos[NotasCreditoPersonaAplicacionDocumentosService.Cotizacion_NombreCol];
            row.MONEDA_ID = (decimal)campos[NotasCreditoPersonaAplicacionDocumentosService.MonedaId_NombreCol];

            sesion.Db.APLICACION_DOCUMENTOS_DOCCollection.Insert(row);

            if (!row.IsCTACTE_PERSONA_IDNull)
                CuentaCorrientePersonasService.SetBloqueado(row.CTACTE_PERSONA_ID, true, sesion);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }


        public static void Actualizar(APLICACION_DOCUMENTOS_DOCRow detalle)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    string valorAnterior = sesion.Db.APLICACION_DOCUMENTOS_DOCCollection.GetByPrimaryKey(detalle.ID).ToString();
                    sesion.Db.APLICACION_DOCUMENTOS_DOCCollection.Update(detalle);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, detalle.ID, valorAnterior, detalle.ToString(), sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        ///// <summary>
        ///// Borrars the specified nota_credito_persona_detalle_id.
        ///// </summary>
        ///// <param name="nota_credito_persona_detalle_id">The nota_credito_persona_detalle_id.</param>
        public static void Eliminar(decimal detalleId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    //Borrar los recargos asociados al registro
                    sesion.db.APLICACION_DOCUMENTOS_DOCCollection.DeleteByAPLICACION_DOCU_DOC_REFERID_ID(detalleId);

                    APLICACION_DOCUMENTOS_DOCRow row = sesion.Db.APLICACION_DOCUMENTOS_DOCCollection.GetByPrimaryKey(detalleId);
                    string valorAnterior = row.ToString();
                    sesion.Db.APLICACION_DOCUMENTOS_DOCCollection.DeleteByPrimaryKey(detalleId);

                    CuentaCorrientePersonasService.SetBloqueado(row.CTACTE_PERSONA_ID, false, sesion);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, detalleId, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }

        }
        #endregion Borrar

        #region Accessors

        public static string Nombre_Tabla
        {
            get { return "APLICACION_DOCUMENTOS_DOC"; }
        }
        public static string Nombre_Vista
        {
            get { return "APLICACION_DOCUMEN_DOC_INFO_CO"; }
        }

        #region Tabla
        public static string AplicacionDocuDocReferidId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_DOCCollection.APLICACION_DOCU_DOC_REFERID_IDColumnName; }
        }
        
        public static string Id_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_DOCCollection.IDColumnName; }
        }

        public static string CtaCtePersonaId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_DOCCollection.CTACTE_PERSONA_IDColumnName; }
        }

        public static string MontoOrigen_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_DOCCollection.MONTO_ORIGENColumnName; }
        }

        public static string MontoDestino_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_DOCCollection.MONTO_DESTINOColumnName; }
        }

        public static string MonedaId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_DOCCollection.MONEDA_IDColumnName; }
        }

        public static string Cotizacion_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_DOCCollection.COTIZACIONColumnName; }
        }

        public static string AplicacionDocumentoId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_DOCCollection.APLICACION_DOCUMENTO_IDColumnName; }
        }

        #endregion Tabla

        #region Vista
        public static string VistaAplicacionDocuDocReferidId_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.APLICACION_DOCU_DOC_REFERID_IDColumnName; }
        }

        public static string VistaAplicacionDocCasoId_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.APLICACION_DOC_CASO_IDColumnName; }
        }

        public static string VistaCasoId_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.CASO_IDColumnName; }
        }

        public static string VistaCadenaDecimales_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.CADENA_DECIMALESColumnName; }
        }

        public static string VistaId_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.CASO_IDColumnName; }
        }

        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.MONEDA_SIMBOLOColumnName; }
        }


        public static string VistaNroComprobante_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.CASO_NRO_COMPROBANTEColumnName; }
        }

        public static string VistaCotizacionMoneda_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.COTIZACION_MONEDAColumnName; }
        }

        public static string VistaCtaCteId_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.CTACTE_IDColumnName; }
        }

        public static string VistaCuotaNro_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.CUOTA_NUMEROColumnName; }
        }

        public static string VistaCuotaTotal_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.CUOTA_TOTALColumnName; }
        }

        public static string VistaCuota_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.CUOTAColumnName; }
        }

        public static string VistaFechaPostergacion_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.FECHA_POSTERGACIONColumnName; }
        }

        public static string VistaFechaVencimiento_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.FECHA_VENCIMIENTOColumnName; }
        }

        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.MONEDA_CANTIDAD_DECIMALESColumnName; }
        }

        public static string VistaMonedaId_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.MONEDA_IDColumnName; }
        }

        public static string VistaMonedaNombreNombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.MONEDA_NOMBREColumnName; }
        }

        public static string VistaMontoDestino_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.MONTO_DESTINOColumnName; }
        }

        public static string VistaMontoOrigen_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.MONTO_ORIGENColumnName; }
        }

        public static string VistaAplicacionDocumentoId_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.APLICACION_DOCUMENTO_IDColumnName; }
        }

        public static string VistaPersonaCodigo_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.PERSONA_CODIGOColumnName; }
        }

        public static string VistaPersonaId_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.PERSONA_IDColumnName; }
        }

        public static string VistaPersonaNombreCompleto_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }

        public static string VistaSaldoDebito_NombreCol
        {
            get { return APLICACION_DOCUMEN_DOC_INFO_COCollection.SALDO_DEBITOColumnName; }
        }

        #endregion Vista

        #endregion Accessors
    }
}
