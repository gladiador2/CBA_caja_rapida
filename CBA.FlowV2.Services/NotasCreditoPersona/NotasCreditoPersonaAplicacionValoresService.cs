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
using CBA.FlowV2.Services.Casos;
#endregion Using

namespace CBA.FlowV2.Services.NotasCreditoPersona
{
    public class NotasCreditoPersonaAplicacionValoresService
    {
        #region GetNotaCreditoAplicacionValoresDataTable
        public static DataTable GetNotaCreditoAplicacionValoresDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.APLICACION_DOCUMENTOS_VALCollection.GetAsDataTable(clausulas, orden);
        }

        public static DataTable GetNotaCreditoAplicacionValoresDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaCreditoAplicacionValoresDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaCreditoAplicacionValoresDataTable(decimal ncAplicacionId)
        {
            return GetNotaCreditoAplicacionValoresDataTable(NotasCreditoPersonaAplicacionValoresService.AplicacionDocumentoId_NombreCol + " = " + ncAplicacionId, NotasCreditoPersonaAplicacionValoresService.Id_NombreCol);
        }
        #endregion GetNotaCreditoAplicacionValoresDataTable

        #region GetNotaCreditoAplicaionValoresInfoCompleta

        public static DataTable GetNotaCreditoAplicacionValoresInfoCompleta(string clausulas)
        {
            return GetNotaCreditoAplicacionValoresInfoCompleta(clausulas, string.Empty);
        }

        public static DataTable GetNotaCreditoAplicacionValoresInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.APLICACION_DOCUMEN_VAL_INFO_COCollection.GetAsDataTable(clausulas, string.Empty);
            }
        }

        #endregion GetNotaCreditoAplicaionValoresInfoCompleta

        #region Item Existe en la Lista
        /// <summary>
        /// Verificamos si la nota de credito ya esta incluidad dentro de la lista de valores
        /// </summary>
        /// <param name="NotaCreditoId">The nota credito identifier.</param>
        /// <returns></returns>
        public static bool ItemExisteEnLista(decimal ctacteId, decimal casoId, int tipo)
        {
            string clausulas = string.Empty;

            if (tipo == Definiciones.TipoComprobanteAplicable.Persona)
            {
                clausulas = NotasCreditoPersonaAplicacionValoresService.CtaCtePersonaId_NombreCol + " = " + ctacteId;
            }
            else
            {
                clausulas = NotasCreditoPersonaAplicacionValoresService.CtaCteProveedorId_NombreCol + " = " + ctacteId;
            }

            if(casoId!= Definiciones.Error.Valor.EnteroPositivo)
                clausulas = clausulas + " and " + NotasCreditoPersonaAplicacionValoresService.VistaNotaCreditoAplicacionCasoId_NombreCol + " = " + casoId;

            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.APLICACION_DOCUMEN_VAL_INFO_COCollection.GetAsDataTable(clausulas, string.Empty).Rows.Count > 0 ? true : false;
            }

        }
        #endregion Item Existe en la lista

        #region Obtener Total Valores
        /// <summary>
        /// Obtener Total Documentos
        /// </summary>
        /// <param name="NotaCreditoAplicacionId">The nota credito aplicacion identifier.</param>
        /// <returns></returns>
        public static decimal ObtenerTotalValores(decimal NotaCreditoAplicacionId)
        {

            string clausulas = NotasCreditoPersonaAplicacionValoresService.VistaAplicaiconDocumentoId_NombreCol + " = " + NotaCreditoAplicacionId.ToString();
            using (SessionService sesion = new SessionService())
            {
                DataTable dtResult = sesion.Db.APLICACION_DOCUMEN_VAL_INFO_COCollection.GetAsDataTable(clausulas, string.Empty);
                decimal totalValores = 0;
                if (dtResult.Rows.Count > 0)
                {

                    foreach (DataRow row in dtResult.Rows)
                    {
                        totalValores += (decimal)row[NotasCreditoPersonaAplicacionValoresService.VistaMontoDestino_NombreCol];
                    }
                }

                return totalValores;
            }

        }
        #endregion Obtener Total Valores

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                Guardar(campos, sesion);
            }
        }

        public static void Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                APLICACION_DOCUMENTOS_VALRow row = new APLICACION_DOCUMENTOS_VALRow();
                DataTable dtCabecera = NotasCreditoPersonaAplicacionesService.GetNotaCreditoAplicacionDataTable((decimal)campos[NotasCreditoPersonaAplicacionValoresService.AplicacionDocumentoId_NombreCol], sesion);
                string valorAnterior;
                SucursalesService sucursal = new SucursalesService((decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.SucursalId_NombreCol], sesion);

                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionCtacteIndependiente, sesion) == Definiciones.SiNo.Si)
                {
                    if (campos.Contains(NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol))
                    {
                        var ctactePersona = new CuentaCorrientePersonasService((decimal)campos[NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol], sesion);
                        if (!ctactePersona.ExisteEnDB)
                            throw new System.Exception("El documento no fue encontrado.");
                        if(ctactePersona.CasoId.HasValue)
                        {
                            var caso = new CasosService(ctactePersona.CasoId.Value, sesion);
                            if (caso.Sucursal.RegionId != sucursal.RegionId)
                                throw new Exception("El documento proviene de una región distinta al caso.");
                        }
                    }

                    if (campos.Contains(NotasCreditoPersonaAplicacionValoresService.CtaCteProveedorId_NombreCol))
                    {
                        var ctacteProveedor = new CuentaCorrienteProveedoresService((decimal)campos[NotasCreditoPersonaAplicacionValoresService.CtaCteProveedorId_NombreCol], sesion);
                        if (!ctacteProveedor.ExisteEnDB)
                            throw new System.Exception("El documento no fue encontrado.");
                        if (ctacteProveedor.CasoId.HasValue)
                        {
                            var caso = new CasosService(ctacteProveedor.CasoId.Value, sesion);
                            if (caso.Sucursal.RegionId != sucursal.RegionId)
                                throw new Exception("El documento proviene de una región distinta al caso.");
                        }
                    }
                }
                
                valorAnterior = Definiciones.Log.RegistroNuevo;
                row.ID = sesion.Db.GetSiguienteSecuencia("APLICACION_DOCUMENTOS_VAL_SQC");

                row.TIPO = decimal.Parse(campos[NotasCreditoPersonaAplicacionValoresService.Tipo_NombreCol].ToString());
                if (campos.Contains(NotasCreditoPersonaAplicacionValoresService.CtaCtePersonaId_NombreCol))
                    row.CTACTE_PERSONA_ID = (decimal)campos[NotasCreditoPersonaAplicacionValoresService.CtaCtePersonaId_NombreCol];
                if (campos.Contains(NotasCreditoPersonaAplicacionValoresService.CtaCteProveedorId_NombreCol))
                    row.CTACTE_PROVEEDOR_ID = (decimal)campos[NotasCreditoPersonaAplicacionValoresService.CtaCteProveedorId_NombreCol];

                row.APLICACION_DOCUMENTO_ID = (decimal)campos[NotasCreditoPersonaAplicacionValoresService.AplicacionDocumentoId_NombreCol];
                row.MONTO_DESTINO = (decimal)campos[NotasCreditoPersonaAplicacionValoresService.MontoDestino_NombreCol];
                row.MONTO_ORIGEN = (decimal)campos[NotasCreditoPersonaAplicacionValoresService.MontoOrigen_NombreCol];
                row.MONEDA_ID = (decimal)campos[NotasCreditoPersonaAplicacionValoresService.MonedaId_NombreCol];
                row.COTIZACION = (decimal)(decimal)campos[NotasCreditoPersonaAplicacionValoresService.Cotizacion_NombreCol];

                sesion.Db.APLICACION_DOCUMENTOS_VALCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Exception exp)
            {
                
                throw exp;
            }
        }

        public static void Actualizar(APLICACION_DOCUMENTOS_VALRow detalle)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    string valorAnterior = sesion.Db.APLICACION_DOCUMENTOS_VALCollection.GetByPrimaryKey(detalle.ID).ToString();
                    sesion.Db.APLICACION_DOCUMENTOS_VALCollection.Update(detalle);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, detalle.ID, valorAnterior, detalle.ToString(), sesion);
                }
                catch
                {
                    throw;
                }
            }
        }
        #endregion Guardar

        #region ObtenerValoresDiponibles
        public static DataTable ObtenerValoresDiponiblesDatatable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.CTACTE_PERSONAS_COMPR_APLICollection.GetAsDataTable(clausulas, orden);
            }
        }
        public static DataTable ObtenerValoresDiponiblesDatatable(string clausulas, string orden, bool verCtacteProveedor)
        {
            clausulas += " and " + NotasCreditoPersonaAplicacionValoresService.Tipo_NombreCol + " in (" + Definiciones.TipoComprobanteAplicable.Persona;
            if (verCtacteProveedor)
                clausulas += "," + Definiciones.TipoComprobanteAplicable.Proveedor;
            clausulas += ")";

            using (SessionService sesion = new SessionService())
            {
                return sesion.db.CTACTE_PERSONAS_COMPR_APLICollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion ObtenerValoresDiponibles

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
                    string valorAnterior = sesion.Db.APLICACION_DOCUMENTOS_VALCollection.GetByPrimaryKey(detalleId).ToString();
                    sesion.Db.APLICACION_DOCUMENTOS_VALCollection.DeleteByPrimaryKey(detalleId);
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

        #region Valores Incluidos
        public static string Nombre_Tabla
        {
            get { return "APLICACION_DOCUMENTOS_VAL"; }
        }

        public static string Nombre_Vista
        {
            get { return "APLICACION_DOCUMEN_VAL_INFO_CO"; }
        }

        #region Tabla
        public static string Id_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_VALCollection.IDColumnName; }
        }

        public static string Cotizacion_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_VALCollection.COTIZACIONColumnName; }
        }

        public static string MonedaId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_VALCollection.MONEDA_IDColumnName; }
        }

        public static string MontoOrigen_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_VALCollection.MONTO_ORIGENColumnName; }
        }

        public static string MontoDestino_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_VALCollection.MONTO_DESTINOColumnName; }
        }

        public static string AplicacionDocumentoId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_VALCollection.APLICACION_DOCUMENTO_IDColumnName; }
        }
        public static string CtaCtePersonaId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_VALCollection.CTACTE_PERSONA_IDColumnName; }
        }
        public static string CtaCteProveedorId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_VALCollection.CTACTE_PROVEEDOR_IDColumnName; }
        }
        public static string Tipo_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_VALCollection.TIPOColumnName; }
        }


        #endregion Tabla

        #region Vista

        public static string VistaCasoId_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.CASO_IDColumnName; }
        }


        public static string VistaNotaCreditoAplicacionCasoId_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.CASO_ID_NC_APLICACIONColumnName; }
        }


        public static string VistaCotizacionMoneda_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.COTIZACION_MONEDAColumnName; }
        }

        public static string VistaCantidadDecimales_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.MONEDA_CANTIDAD_DECIMALESColumnName; }
        }

        public static string VistaCadenaDecimales_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.MONEDA_CADENA_DECIMALESColumnName; }
        }

        public static string VistaMonedaNombre_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.MONEDA_NOMBREColumnName; }
        }

        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.MONEDA_SIMBOLOColumnName; }
        }

        public static string VistaId_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.IDColumnName; }
        }

        public static string VistaMontoTotal_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.MONTO_TOTALColumnName; }
        }

        public static string VistaMontoDestino_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.MONTO_DESTINOColumnName; }
        }

        public static string VistaMontoOrigen_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.MONTO_ORIGENColumnName; }
        }

        public static string VistaAplicaiconDocumentoId_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.APLICACION_DOCUMENTO_IDColumnName; }
        }
        public static string VistaNumeroCasoId_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.CASO_IDColumnName; }
        }

        public static string VistaNumeroComprobante_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.CASO_NRO_COMPROBANTEColumnName; }
        }

        public static string VistaPersonaId_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.PERSONA_IDColumnName; }
        }

        public static string VistaPersonaNombre_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.PERSONA_NOMBREColumnName; }
        }

        public static string VistaSaldoPorAplicar_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.SALDO_POR_APLICARColumnName; }
        }
        public static string VistaFechaVencimiento_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string VistaFlujoNombre_NombreCol
        {
            get { return APLICACION_DOCUMEN_VAL_INFO_COCollection.FLUJO_NOMBREColumnName; }
        }


        #endregion Vista

        #endregion Valores Incluidos

        #region Valores Disponibles
        public static string Nombre_ctace_personas_comprobantes_aplicables
        {
            get { return "ctacte_personas_compr_apli"; }
        }
        public static string ComprobantesAplicablesCtaCtaeId_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.IDColumnName; }
        }
        public static string ComprobantesAplicablesFechaVencimiento_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string ComprobantesAplicablesCasoEstadoId_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.CASO_ESTADO_IDColumnName; }
        }
        public static string ComprobantesAplicablesCasoId_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.CASO_IDColumnName; }
        }
        public static string ComprobantesAplicacionesCasoNroComprobante_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.CASO_NRO_COMPROBANTEColumnName; }
        }
        public static string ComprobantesAplicacionesTotal_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.TOTALColumnName; }
        }
        public static string ComprobantesAplicacionesFlujoId_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.FLUJO_IDColumnName; }
        }
        public static string ComprobantesAplicacionesFlujoNombre_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.FLUJO_NOMBREColumnName; }
        }
        public static string ComprobantesAplicacionesPersonaCodigo_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.PERSONA_CODIGOColumnName; }
        }
        public static string ComprobantesAplicacionesPersonaId_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.PERSONA_IDColumnName; }
        }
        public static string ComprobantesAplicacionesPersonaNombreCompleto_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string ComprobantesAplicacionesSaldo_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.SALDOColumnName; }
        }
        public static string ComprobantesAplicacionesTipo_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.TIPOColumnName; }
        }
        public static string ComprobantesAplicacionesMonedaId_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.MONEDA_IDColumnName; }
        }
        public static string ComprobantesAplicacionesMonedaNombre_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.MONEDA_NOMBREColumnName; }
        }
        public static string ComprobantesAplicacionesMonedaSimbolo_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string ComprobantesAplicacionesMonedaCadenaDecimales_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.MONEDA_CADENA_DECIMALESColumnName; }
        }
        public static string ComprobantesAplicacionesMonedaCantidadDecimales_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.MONEDA_CANTIDAD_DECIMALESColumnName; }
        }
        public static string ComprobantesAplicacionesMonedaCotizacion_NombreCol
        {
            get { return CTACTE_PERSONAS_COMPR_APLICollection.COTIZACION_MONEDAColumnName; }
        }
        #endregion Valores Disponibles

        #endregion Accessors
    }
}
