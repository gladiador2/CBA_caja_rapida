using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.NotaCreditosProveedores;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class TransferenciasCtaCtePersonasDetallesService
    {
        #region GetTransferenciaDetalles
        /// <summary>
        /// Gets the transferencia detalles.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTransferenciaDetalles(string where, string orden)
        {
            using(SessionService sesion= new SessionService())
            {
                return sesion.Db.TRANSF_CTACTE_PERSONA_DETCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetTransferenciaDetalles

        #region GetTransferenciaDetallesPorTransferencia
        /// <summary>
        /// Gets the transferencia detalles por transferencia.
        /// </summary>
        /// <param name="transferencia_id">The transferencia_id.</param>
        /// <returns></returns>
        public static DataTable GetTransferenciaDetallesPorTransferencia(decimal transferencia_id)
        {
            using (SessionService sesion = new SessionService())
            {
              return  sesion.Db.TRANSF_CTACTE_PERSONA_DETCollection.GetByTRANSF_CTACTE_PERSONA_IDAsDataTable(transferencia_id);
            }
        }
        #endregion GetTransferenciaDetallesPorTransferencia

        #region GetTransferenciaDetallesInfoCompletaPorTransferencia

        /// <summary>
        /// Gets the transferencia detalles info completa por transferencia.
        /// </summary>
        /// <param name="transferencia_id">The transferencia_id.</param>
        /// <returns></returns>
        public static DataTable GetTransferenciaDetallesInfoCompletaPorTransferencia(decimal transferencia_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = TransferenciasCtaCtePersonasDetallesService.TransferenciaCtaCtePersonaId_NombreCol + "=" + transferencia_id;
                return sesion.Db.TRAN_CTACTE_PERS_DET_INF_COMPLCollection.GetAsDataTable(where,TransferenciasCtaCtePersonasDetallesService.TransferenciaCtaCtePersonaId_NombreCol);
            }
        }
        #endregion GetTransferenciaDetallesInfoCompletaPorTransferencia

        #region GetTransferenciaDetallesPorTransferencia

        /// <summary>
        /// Gets the transferencia detalles por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static DataTable GetTransferenciaDetallesPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                decimal transferencia_id = sesion.Db.TRANSFERENCIA_CTACTE_PERSONACollection.GetByCASO_ID(caso_id)[0].ID;
                return sesion.Db.TRANSF_CTACTE_PERSONA_DETCollection.GetByTRANSF_CTACTE_PERSONA_IDAsDataTable(transferencia_id);
            }
        }
        #endregion GetTransferenciaDetallesPorCaso

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    TRANSF_CTACTE_PERSONA_DETRow row;
                    string valorAnterior = Definiciones.Log.RegistroNuevo;
                    if(insertarNuevo){
                        row = new TRANSF_CTACTE_PERSONA_DETRow();
                        row.TRANSF_CTACTE_PERSONA_ID = (decimal)campos[TransferenciasCtaCtePersonasDetallesService.TransferenciaCtaCtePersonaId_NombreCol];
                        row.CTACTE_PERSONA_ORIG_ID = (decimal)campos[TransferenciasCtaCtePersonasDetallesService.CtaCtePersonaOrigenId_NombreCol];
                        //campos identificatorios
                        row.ID = sesion.Db.GetSiguienteSecuencia("TRAN_CTACTE_PERSONA_DET_SQC");
                        row.CTACTE_PERSONA_ORIG_ID = (decimal)campos[TransferenciasCtaCtePersonasDetallesService.CtaCtePersonaOrigenId_NombreCol];
                        row.MONEDA_ID=(decimal)campos[TransferenciasCtaCtePersonasDetallesService.MonedaId_NombreCol];
                        row.COTIZACION = (decimal)campos[TransferenciasCtaCtePersonasDetallesService.Cotizacion_NombreCol];
                        // se controla que no se incluyan mas de una vez el mismo item de la ctacte de la persona
                        TRANSF_CTACTE_PERSONA_DETRow[] incluidos = sesion.Db.TRANSF_CTACTE_PERSONA_DETCollection.GetByTRANSF_CTACTE_PERSONA_ID(row.TRANSF_CTACTE_PERSONA_ID);
                        for (int i = 0; i < incluidos.Length; i++) {
                            if (incluidos[i].CTACTE_PERSONA_ORIG_ID == row.CTACTE_PERSONA_ORIG_ID) {
                                throw (new Exception("Ese item ya esta incluida en la transferencia"));
                            }
                        }
                    }else{
                        row = sesion.Db.TRANSF_CTACTE_PERSONA_DETCollection.GetByPrimaryKey((decimal)campos[TransferenciasCtaCtePersonasDetallesService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    
                    row.MONTO_CREDITO_ORIGEN = (decimal)campos[TransferenciasCtaCtePersonasDetallesService.MontoCreditoOrigen_NombreCol];
                    row.MONTO_CREDITO_DESTINO = (decimal)campos[TransferenciasCtaCtePersonasDetallesService.MontoCreditoDestino_NombreCol];
                    row.MONTO_DEBITO_ORIGEN = (decimal)campos[TransferenciasCtaCtePersonasDetallesService.MontoDebitoOrigen_NombreCol];
                    row.MONTO_DEBITO_DESTINO = (decimal)campos[TransferenciasCtaCtePersonasDetallesService.MontoDebitoDestino_NombreCol];

                    if (campos.Contains(Observacion_NombreCol)) row.OBSERVACION = campos[Observacion_NombreCol].ToString();
                    if (campos.Contains(CtaCtePersonaDestinoId_NombreCol)) row.CTACTE_PERSONA_DEST_ID = (decimal)campos[CtaCtePersonaDestinoId_NombreCol];
                    
                    if(insertarNuevo)sesion.Db.TRANSF_CTACTE_PERSONA_DETCollection.Insert(row);
                    else sesion.Db.TRANSF_CTACTE_PERSONA_DETCollection.Update(row);
                    
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                                  
                   
                    sesion.Db.CommitTransaction();
                    // se actualiza el total de la transferencia;
                    decimal totalCredito, totalDebito;
                    TransferenciasCtaCtePersonasDetallesService.ObtenerTotalCreditoPorTransferencia(row.TRANSF_CTACTE_PERSONA_ID, out totalCredito, out totalDebito);
                    TransferenciasCtaCtePersonasService.ActualizarTotal(row.TRANSF_CTACTE_PERSONA_ID, totalCredito, totalDebito);
                    
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region ObtenerTotalCreditoPorTransferencia
        /// <summary>
        /// Obteners the total por transferencia.
        /// </summary>
        /// <param name="transferencia_id">The transferencia_id.</param>
        /// <returns></returns>
        private static void ObtenerTotalCreditoPorTransferencia(decimal transferencia_id, out decimal total_credito, out decimal total_debito)
        {
            using (SessionService sesion = new SessionService())
            {
                total_credito = 0;
                total_debito = 0;
                TRANSF_CTACTE_PERSONA_DETRow[] detalles = sesion.Db.TRANSF_CTACTE_PERSONA_DETCollection.GetByTRANSF_CTACTE_PERSONA_ID(transferencia_id);
                   
                    for (int i = 0; i < detalles.Length; i++)
                    {
                        total_credito += detalles[i].MONTO_CREDITO_DESTINO;
                        total_debito += detalles[i].MONTO_DEBITO_DESTINO;
                    }
            }
        }
        #endregion ObtenerTotalCreditoPorTransferencia

        #region ObtenerTotalDebitoPorTransferencia
        /// <summary>
        /// Obteners the total debito por transferencia.
        /// </summary>
        /// <param name="transferencia_id">The transferencia_id.</param>
        /// <returns></returns>
        private static decimal ObtenerTotalDebitoPorTransferencia(decimal transferencia_id)
        {
            using (SessionService sesion = new SessionService())
            {
                decimal total = 0;
                TRANSF_CTACTE_PERSONA_DETRow[] detalles = sesion.Db.TRANSF_CTACTE_PERSONA_DETCollection.GetByTRANSF_CTACTE_PERSONA_ID(transferencia_id);


                for (int i = 0; i < detalles.Length; i++)
                {

                    total += detalles[i].MONTO_DEBITO_DESTINO;
                }

                return total;
            }
        }
        #endregion ObtenerTotalDebitoPorTransferencia

        #region Borrar
        public static void Borrar(decimal transferencia_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    TRANSF_CTACTE_PERSONA_DETRow row = new TRANSF_CTACTE_PERSONA_DETRow();
                    TransferenciasCtaCtePersonasService transferencia = new TransferenciasCtaCtePersonasService();



                    row = sesion.Db.TRANSF_CTACTE_PERSONA_DETCollection.GetByPrimaryKey(transferencia_detalle_id);


                    sesion.Db.TRANSF_CTACTE_PERSONA_DETCollection.Delete(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                  // movimiento.RecalcularTotal(row.TRANSFERENCIAS_ID, sesion);

                    sesion.CommitTransaction();

                    // se actualiza el total de la transferencia;
                    decimal totalCredito = 0, totalDebito = 0;
                    TransferenciasCtaCtePersonasDetallesService.ObtenerTotalCreditoPorTransferencia(row.TRANSF_CTACTE_PERSONA_ID, out totalDebito, out totalDebito);
                    TransferenciasCtaCtePersonasService.ActualizarTotal(row.TRANSF_CTACTE_PERSONA_ID, totalCredito, totalDebito);
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
        #region Tablas
        public static string Nombre_Tabla
        {
            get { return "TRANSF_CTACTE_PERSONA_DET"; }
        }

        public static string Id_NombreCol
        {
            get { return TRANSF_CTACTE_PERSONA_DETCollection.IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return TRANSF_CTACTE_PERSONA_DETCollection.COTIZACIONColumnName; }
        }
        public static string CtaCtePersonaDestinoId_NombreCol
        {
            get { return TRANSF_CTACTE_PERSONA_DETCollection.CTACTE_PERSONA_DEST_IDColumnName; }
        }
        public static string CtaCtePersonaOrigenId_NombreCol
        {
            get { return TRANSF_CTACTE_PERSONA_DETCollection.CTACTE_PERSONA_ORIG_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return TRANSF_CTACTE_PERSONA_DETCollection.MONEDA_IDColumnName; }
        }
        public static string MontoCreditoDestino_NombreCol
        {
            get { return TRANSF_CTACTE_PERSONA_DETCollection.MONTO_CREDITO_DESTINOColumnName; }
        }
        public static string MontoCreditoOrigen_NombreCol
        {
            get { return TRANSF_CTACTE_PERSONA_DETCollection.MONTO_CREDITO_ORIGENColumnName; }
        }
        public static string MontoDebitoDestino_NombreCol
        {
            get { return TRANSF_CTACTE_PERSONA_DETCollection.MONTO_DEBITO_DESTINOColumnName; }
        }
        public static string MontoDebitoOrigen_NombreCol
        {
            get { return TRANSF_CTACTE_PERSONA_DETCollection.MONTO_DEBITO_ORIGENColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return TRANSF_CTACTE_PERSONA_DETCollection.OBSERVACIONColumnName; }
        }
        public static string TransferenciaCtaCtePersonaId_NombreCol
        {
            get { return TRANSF_CTACTE_PERSONA_DETCollection.TRANSF_CTACTE_PERSONA_IDColumnName; }
        }
        #endregion Tablas
        
        #region Vistas
        public static string VistaCtaCtaOrigenObservacion_NombreCol
        {
            get { return TRAN_CTACTE_PERS_DET_INF_COMPLCollection.OBSERVACION_CUENTA_ORIGENColumnName; }
        }
        public static string VistaCtaCtaOrigenFechaVencimiento_NombreCol
        {
            get { return TRAN_CTACTE_PERS_DET_INF_COMPLCollection.VENCIMIENTO_CUENTA_ORIGENColumnName; }
        }
        public static string VistaMonedaOrigenNombre_NombreCol
        {
            get { return TRAN_CTACTE_PERS_DET_INF_COMPLCollection.MONEDA_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaMonedaOrigenId_NombreCol
        {
            get { return TRAN_CTACTE_PERS_DET_INF_COMPLCollection.MONEDA_ORIGEN_IDColumnName; }
        }
        public static string VistaMonedaOrigenSimbolo_NombreCol
        {
            get { return TRAN_CTACTE_PERS_DET_INF_COMPLCollection.MONEDA_ORIGEN_SIMBOLOColumnName; }
        }
        public static string VistaMonedaDestinoNombre_NombreCol
        {
            get { return TRAN_CTACTE_PERS_DET_INF_COMPLCollection.MONEDA_DESTINO_NOMBREColumnName; }
        }
        public static string VistaMonedaDestinoId_NombreCol
        {
            get { return TRAN_CTACTE_PERS_DET_INF_COMPLCollection.MONEDA_DESTINO_IDColumnName; }
        }
        public static string VistaMonedaDestinoSimbolo_NombreCol
        {
            get { return TRAN_CTACTE_PERS_DET_INF_COMPLCollection.MOENDA_DESTINO_SIMBOLOColumnName; }
        }

        #endregion Vistas
        #endregion Accessors
    }
}
