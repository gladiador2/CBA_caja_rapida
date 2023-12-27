using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrientePagaresDocumentosService
    {
        #region GetCuentaCorrientePagaresDocumentosDataTable
        public static DataTable GetCuentaCorrientePagaresDocumentosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrientePagaresDocumentosDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCuentaCorrientePagaresDocumentosDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_PAGARES_DOCUMENTOSCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCuentaCorrientePagaresDocumentosDataTable
        
        #region GetCuentaCorrientePagaresDocumentosInfoCompleta
        /// <summary>
        /// Gets the cuenta corriente pagares documentos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagaresDocumentosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_PAGARES_DOC_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCuentaCorrientePagaresDocumentosInfoCompleta

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

                    CTACTE_PAGARES_DOCUMENTOSRow row = new CTACTE_PAGARES_DOCUMENTOSRow();
                    DataTable dtCtactePersona;
                    DataTable dtCtactePagares;
                    DataTable dtCtactePersonaDet;
                    decimal[] impuestoId, monto;
                    string valorAnterior = Definiciones.Log.RegistroNuevo;

                    row.CTACTE_PAGARE_ID = (decimal)campos[CuentaCorrientePagaresDocumentosService.CtactePagareId_NombreCol];
                    dtCtactePagares = CuentaCorrientePagaresService.GetCuentaCorrientePagaresInfoCompleta(CuentaCorrientePagaresService.Id_NombreCol + " = " + row.CTACTE_PAGARE_ID, string.Empty);

                    //Se controla que no hayan pagos sobre el juego de pagares
                    if (!dtCtactePagares.Rows[0][CuentaCorrientePagaresService.VistaMontoSaldo_NombreCol].Equals(DBNull.Value))
                    {
                        if((decimal)dtCtactePagares.Rows[0][CuentaCorrientePagaresService.VistaMontoSaldo_NombreCol] > 0)
                            throw new Exception("Ya se realizaron pagos sobre el juego de pagarés. No puede editar los documentos que respalda.");
                    }

                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_pagares_doc_sqc");

                    row.MONEDA_ID = (decimal)campos[CuentaCorrientePagaresDocumentosService.MonedaId_NombreCol];
                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtCtactePagares.Rows[0][CuentaCorrientePagaresService.SucursalId_NombreCol]), row.MONEDA_ID);
                    if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda origen (del documento en la cuenta corriente).");

                    row.CTACTE_PERSONA_ID = (decimal)campos[CuentaCorrientePagaresDocumentosService.CtactePersonaId_NombreCol];
                    row.MONTO_ORIGEN = (decimal)campos[CuentaCorrientePagaresDocumentosService.MontoOrigen_NombreCol];

                    row.MONTO_DESTINO = (row.MONTO_ORIGEN / row.COTIZACION_MONEDA) * (decimal)dtCtactePagares.Rows[0][CuentaCorrientePagaresService.CotizacionMoneda_NombreCol];

                    //Se agrega el registro
                    sesion.Db.CTACTE_PAGARES_DOCUMENTOSCollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    //Se realiza el commit ya que la actualizacion
                    //de cabecera no esta logrando acceder a los datos actualizados
                    sesion.CommitTransaction();
                    sesion.BeginTransaction();

                    //Se actualiza la cabecera
                    decimal montoSoloAfectaPagareGarantia = 0;
                    CuentaCorrientePagaresService.ActualizarTotal(row.CTACTE_PAGARE_ID, montoSoloAfectaPagareGarantia, false, sesion);

                    //Se realiza el commit ya que ctactePersona.AgregarDebito abre una nueva conexion
                    sesion.Db.CommitTransaction();

                    #region Se afecta la cuenta corriente
                    //Se obtiene el registro de la cuenta corriente de la persona
                    dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.Id_NombreCol + " = " + row.CTACTE_PERSONA_ID, string.Empty, sesion);
                    dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Id_NombreCol], sesion);

                    impuestoId = new decimal[dtCtactePersonaDet.Rows.Count];
                    monto = new decimal[dtCtactePersonaDet.Rows.Count];

                    for (int i = 0; i < dtCtactePersonaDet.Rows.Count; i++)
                    {
                        impuestoId[i] = (decimal)dtCtactePersonaDet.Rows[i][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol];
                        monto[i] = row.MONTO_DESTINO / (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol] * (decimal)dtCtactePersonaDet.Rows[i][CuentaCorrientePersonasDetalleService.Monto_NombreCol];
                    }

                    //Ingresar el debito
                    CuentaCorrientePersonasService.AgregarDebito((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.PersonaId_NombreCol],
                                                (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Id_NombreCol],
                                                Definiciones.CuentaCorrienteConceptos.Financiacion,
                                                Definiciones.CuentaCorrienteValores.Pagare,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                row.MONEDA_ID,
                                                row.COTIZACION_MONEDA,
                                                impuestoId,
                                                monto,
                                                string.Empty,
                                                (DateTime)dtCtactePagares.Rows[0][CuentaCorrientePagaresService.Fecha_NombreCol],
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                row.ID,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                sesion);

                    #endregion Se afecta la cuenta corriente
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
        /// Borrars the specified ctacte_pagares_documento_id.
        /// </summary>
        /// <param name="ctacte_pagares_documento_id">The ctacte_pagares_documento_id.</param>
        public static void Borrar(decimal ctacte_pagares_documento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    CTACTE_PAGARES_DOCUMENTOSRow row = sesion.Db.CTACTE_PAGARES_DOCUMENTOSCollection.GetByPrimaryKey(ctacte_pagares_documento_id);
                    DataTable dtCtactePagares;

                    //Se controla que no hayan pagos sobre el juego de pagares
                    dtCtactePagares = CuentaCorrientePagaresService.GetCuentaCorrientePagaresInfoCompleta(CuentaCorrientePagaresService.Id_NombreCol + " = " + row.CTACTE_PAGARE_ID, string.Empty);
                    if (!dtCtactePagares.Rows[0][CuentaCorrientePagaresService.VistaMontoSaldo_NombreCol].Equals(DBNull.Value))
                    {
                        if ((decimal)dtCtactePagares.Rows[0][CuentaCorrientePagaresService.VistaMontoSaldo_NombreCol] > 0)
                            throw new Exception("Ya se realizaron pagos sobre el juego de pagarés. No puede editar los documentos que respalda.");
                    }

                    //Deshacer el debito en la cuenta corriente
                    CuentaCorrientePersonasService.DeshacerAgregarDebito(Definiciones.Error.Valor.EnteroPositivo, row.ID, sesion);

                    //Se borra el documento del juego de pagares
                    sesion.Db.CTACTE_PAGARES_DOCUMENTOSCollection.Delete(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    //Se realiza el commit ya que la actualizacion
                    //de cabecera no esta logrando acceder a los datos actualizados
                    sesion.CommitTransaction();
                    sesion.BeginTransaction();

                    //Se recalculan los totales de la cabecera
                    decimal montoSoloAfectaPagareGarantia = 0;
                    CuentaCorrientePagaresService.ActualizarTotal(row.CTACTE_PAGARE_ID, montoSoloAfectaPagareGarantia, false, sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PAGARES_DOCUMENTOS"; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_PAGARES_DOCUMENTOSCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtactePagareId_NombreCol
        {
            get { return CTACTE_PAGARES_DOCUMENTOSCollection.CTACTE_PAGARE_IDColumnName; }
        }
        public static string CtactePersonaId_NombreCol
        {
            get { return CTACTE_PAGARES_DOCUMENTOSCollection.CTACTE_PERSONA_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PAGARES_DOCUMENTOSCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_PAGARES_DOCUMENTOSCollection.MONEDA_IDColumnName; }
        }
        public static string MontoDestino_NombreCol
        {
            get { return CTACTE_PAGARES_DOCUMENTOSCollection.MONTO_DESTINOColumnName; }
        }
        public static string MontoOrigen_NombreCol
        {
            get { return CTACTE_PAGARES_DOCUMENTOSCollection.MONTO_ORIGENColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_PAGARES_DOC_INFO_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_PAGARES_DOC_INFO_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaMonedaOrigenId_NombreCol
        {
            get { return CTACTE_PAGARES_DOC_INFO_COMPCollection.MONEDA_ORIGEN_IDColumnName; }
        }
        public static string VistaMonedaOrigenNombre_NombreCol
        {
            get { return CTACTE_PAGARES_DOC_INFO_COMPCollection.MONEDA_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaMonedaOrigenSimbolo_NombreCol
        {
            get { return CTACTE_PAGARES_DOC_INFO_COMPCollection.MONEDA_ORIGEN_SIMBOLOColumnName; }
        }
        public static string VistaCtactePersonaObservacion_NombreCol
        {
            get { return CTACTE_PAGARES_DOC_INFO_COMPCollection.CTACTE_PERSONA_OBSERVACIONColumnName; }
        }
        #endregion Accessors
    }
}
