using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteChequesRecibidosAbogadosService
    {
        #region GetCuentaCorrienteChequesRecibidosAbogadosDataTable
        /// <summary>
        /// Gets the cuenta corriente cheques recibidos abogados data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCuentaCorrienteChequesRecibidosAbogadosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_CHEQUES_REC_ABOGADOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCuentaCorrienteChequesRecibidosAbogadosDataTable

        #region GetCuentaCorrienteChequesRecibidosAbogadosInfoCompleta
        /// <summary>
        /// Gets the cuenta corriente cheques recibidos abogados info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCuentaCorrienteChequesRecibidosAbogadosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCuentaCorrienteChequesRecibidosAbogadosInfoCompleta

        #region Asignar
        /// <summary>
        /// Asignars the specified ctacte_cheque_recibido_id.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="abogado_id">The abogado_id.</param>
        /// <param name="fecha_asignacion">The fecha_asignacion.</param>
        /// <param name="observacion">The observacion.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public decimal Asignar(decimal ctacte_cheque_recibido_id, decimal abogado_id, DateTime fecha_asignacion, string observacion,  SessionService sesion)
        {
            try
            {
                CTACTE_CHEQUES_REC_ABOGADOSRow row = new CTACTE_CHEQUES_REC_ABOGADOSRow();
                string valorAnterior = Definiciones.Log.RegistroNuevo;
                
                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cheques_rec_abog_sqc");
                
                row.ABOGADO_ID = abogado_id;
                if(!EstudiosJuridicosService.EstaActivo(abogado_id))
                    throw new Exception("El estudio jurídico no se encuentra activo.");

                row.CTACTE_CHEQUE_RECIBIDO_ID = ctacte_cheque_recibido_id;
                row.FECHA_ASIGNACION = fecha_asignacion;
                row.OBSERVACION_ASIGNACION = observacion;
                row.USUARIO_ASIGNACION_FECHA = DateTime.Now;
                row.USUARIO_ASIGNACION_ID = sesion.Usuario.ID;

                sesion.Db.CTACTE_CHEQUES_REC_ABOGADOSCollection.Insert(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Asignar

        #region Desasignar
        /// <summary>
        /// Desasignars the specified ctacte_cheque_recibido_id.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="fecha_desasignacion">The fecha_desasignacion.</param>
        /// <param name="observacion">The observacion.</param>
        /// <param name="sesion">The sesion.</param>
        public void Desasignar(decimal ctacte_cheque_recibido_id, DateTime fecha_desasignacion, string observacion, SessionService sesion)
        {
            try
            {
                CTACTE_CHEQUES_REC_ABOGADOSRow[] rows;
                string clausulas;
                string valorAnterior;

                clausulas = CuentaCorrienteChequesRecibidosAbogadosService.CtacteChequeRecibidoId_NombreCol + " = " + ctacte_cheque_recibido_id + " and " +
                            CuentaCorrienteChequesRecibidosAbogadosService.FechaDesasignacion_NombreCol + " is null ";

                rows = sesion.Db.CTACTE_CHEQUES_REC_ABOGADOSCollection.GetAsArray(clausulas, string.Empty);

                if (rows.Length <= 0)
                    throw new Exception("El cheque no estaba asignado a ningún estudio jurídico.");

                if(rows.Length > 1)
                    throw new Exception("El cheque estaba asignado a más de un estudio jurídico, quedando en estado inconsistente.");

                if(rows[0].FECHA_ASIGNACION > fecha_desasignacion)
                    throw new Exception("La fecha de desasignación no puede ser posterior a la de asignación.");

                valorAnterior = rows[0].ToString();

                rows[0].FECHA_DESASIGNACION = fecha_desasignacion;
                rows[0].OBSERVACION_DESASIGNACION = observacion;
                rows[0].USUARIO_DESASIGNACION_FECHA = DateTime.Now;
                rows[0].USUARIO_DESASIGNACION_ID = sesion.Usuario.ID;

                sesion.Db.CTACTE_CHEQUES_REC_ABOGADOSCollection.Update(rows[0]);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[0].ID, valorAnterior, rows[0].ToString(), sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Desasignar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_CHEQUES_REC_ABOGADOS"; }
        }
        public static string AbogadoId_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOGADOSCollection.ABOGADO_IDColumnName; }
        }
        public static string CtacteChequeRecibidoId_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOGADOSCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string FechaAsignacion_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOGADOSCollection.FECHA_ASIGNACIONColumnName; }
        }
        public static string FechaDesasignacion_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOGADOSCollection.FECHA_DESASIGNACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOGADOSCollection.IDColumnName; }
        }
        public static string ObservacionAsignacion_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOGADOSCollection.OBSERVACION_ASIGNACIONColumnName; }
        }
        public static string ObservacionDesasignacion_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOGADOSCollection.OBSERVACION_DESASIGNACIONColumnName; }
        }
        public static string UsuarioAsignacionFecha_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOGADOSCollection.USUARIO_ASIGNACION_FECHAColumnName; }
        }
        public static string UsuarioAsignacionId_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOGADOSCollection.USUARIO_ASIGNACION_IDColumnName; }
        }
        public static string UsuarioDesasignacionFecha_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOGADOSCollection.USUARIO_DESASIGNACION_FECHAColumnName; }
        }
        public static string UsuariodesasignacionId_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOGADOSCollection.USUARIO_DESASIGNACION_IDColumnName; }
        }
        public static string VistaAbogadoNombreCompleto_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.ABOGADO_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaAbogadoNombreEstudio_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.ABOGADO_NOMBRE_ESTUDIOColumnName; }
        }
        public static string VistaChequeDeTerceros_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.CHEQUE_DE_TERCEROSColumnName; }
        }
        public static string VistaCotizacionMoneda_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string VistaCtacteBancoId_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.CTACTE_BANCO_IDColumnName; }
        }
        public static string VistaCtacteBancoNombre_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.CTACTE_BANCO_NOMBREColumnName; }
        }
        public static string VistaEstadoChequeNombre_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.ESTADO_CHEQUE_NOMBREColumnName; }
        }
        public static string VistaEstadoCheque_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.CHEQUE_ESTADO_IDColumnName; }
        }
        public static string VistaFechaCobro_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.FECHA_COBROColumnName; }
        }
        public static string VistaFechaCreacion_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.FECHA_CREACIONColumnName; }
        }
        public static string VistaFechaPosdatada_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.FECHA_POSDATADOColumnName; }
        }
        public static string VistaFechaRechazo_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.FECHA_RECHAZOColumnName; }
        }
        public static string VistaFechaVencimiento_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string VistaMonedaId_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.MONEDA_IDColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.MONEDAS_NOMBREColumnName; }
        }
        public static string VistaMonto_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.MONTOColumnName; }
        }
        public static string VistaMotivoRechazo_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.MOTIVO_RECHAZOColumnName; }
        }
        public static string VistaNombreBeneficiario_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string VistaNombreEmisor_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.NOMBRE_EMISORColumnName; }
        }
        public static string VistaNumeroCheque_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.NUMERO_CHEQUEColumnName; }
        }
        public static string VistaNumeroCuenta_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.NUMERO_CUENTAColumnName; }
        }
        public static string VistaNumeroDocumentoEmisor_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_ABOG_INFO_CCollection.NUMERO_DOCUMENTO_EMISORColumnName; }
        }
        #endregion Accessors
    }
}
