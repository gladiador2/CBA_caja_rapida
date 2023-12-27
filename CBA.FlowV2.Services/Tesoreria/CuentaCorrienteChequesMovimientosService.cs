#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using System.Collections;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteChequesMovimientosService
    {
        #region Guardar
        public void Guardar(Hashtable campos, SessionService sesion)
        {
            try
            {
                CTACTE_CHEQUES_MOVIMIENTOSRow row = new CTACTE_CHEQUES_MOVIMIENTOSRow();
                string valorAnterior = string.Empty;

                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_chq_movimientos_sqc");
                row.FECHA_MOVIMIENTO = DateTime.Now;
                valorAnterior = Definiciones.Log.RegistroNuevo;
                row.ESTADO_DESTINO_ID = (decimal)campos[CuentaCorrienteChequesMovimientosService.EstadoDestinoId_NombreCol];
                
                if (campos.Contains(CuentaCorrienteChequesMovimientosService.EstadoOriginalId_NombreCol))
                    row.ESTADO_ORIGINAL_ID = (decimal)campos[CuentaCorrienteChequesMovimientosService.EstadoOriginalId_NombreCol];
                
                row.USUARIO_ID = sesion.Usuario.ID;

                if (campos.Contains(CuentaCorrienteChequesMovimientosService.Observacion_NombreCol))
                    row.OBSERVACION =(string)campos[CuentaCorrienteChequesMovimientosService.EstadoOriginalId_NombreCol];

                if (campos.Contains(CuentaCorrienteChequesMovimientosService.CtaCteChequeGiradoId_NombreCol))
                    row.CTACTE_CHEQUE_GIRADO_ID = (decimal)campos[CuentaCorrienteChequesMovimientosService.CtaCteChequeGiradoId_NombreCol];

                if (campos.Contains(CuentaCorrienteChequesMovimientosService.CtaCteChequeRecibidoId_NombreCol))
                    row.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)campos[CuentaCorrienteChequesMovimientosService.CtaCteChequeRecibidoId_NombreCol];

                if (campos.Contains(CuentaCorrienteChequesMovimientosService.CasoIdId_NombreCol))
                    row.CASO_ID = (decimal)campos[CuentaCorrienteChequesMovimientosService.CasoIdId_NombreCol];

                if (campos.Contains(CuentaCorrienteChequesMovimientosService.TextoPredefinidoId_NombreCol))
                    row.TEXTO_PREDEFINIDO_ID = (decimal)campos[CuentaCorrienteChequesMovimientosService.TextoPredefinidoId_NombreCol];
                else 
                    row.IsTEXTO_PREDEFINIDO_IDNull = true;

                sesion.Db.CTACTE_CHEQUES_MOVIMIENTOSCollection.Insert(row);
                
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Guardar
        
        #region GetEstadoAnterior
        public static decimal GetEstadoAnterior(decimal ctacte_cheque_id) 
        {
            DataTable estadosDelCheque = GetMovimientosPorChequeRecibido(ctacte_cheque_id);
            return (decimal)estadosDelCheque.Rows[estadosDelCheque.Rows.Count - 1][CuentaCorrienteChequesMovimientosService.EstadoOriginalId_NombreCol];
        }
        #endregion GetEstadoAnterior

        #region GetChequesMovimientosDataTable
        public static DataTable GetChequesMovimientosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return CuentaCorrienteChequesMovimientosService.GetChequesMovimientosDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetChequesMovimientosDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_CHEQUES_MOVIMIENTOSCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetChequesMovimientosDataTable

        #region GetMovimientosPorChequeRecido
        /// <summary>
        /// Gets the movimientos por cheque recibido.
        /// </summary>
        /// <param name="ctacte_cheque_id">The ctacte_cheque_id.</param>
        /// <returns></returns>
        public static DataTable GetMovimientosPorChequeRecibido(decimal ctacte_cheque_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = CuentaCorrienteChequesMovimientosService.CtaCteChequeRecibidoId_NombreCol + " = " + ctacte_cheque_id;
                return sesion.Db.CTACTE_CHQ_MOV_INFO_COMPLCollection.GetAsDataTable(where, CuentaCorrienteChequesMovimientosService.FechaMovimiento_NombreCol);
            }
        }
        #endregion GetMovimientosPorChequeRecibido

        #region GetMovimientosPorChequeRecibidoPorPersona

        /// <summary>
        /// Gets the movimientos por cheque recibido por persona.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <returns></returns>
        public DataTable GetMovimientosPorChequeRecibidoPorPersona(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = CuentaCorrienteChequesMovimientosService.VistaChequeRecibidoPersonaId_NombreCol + "=" + persona_id;
                return sesion.Db.CTACTE_CHQ_MOV_INFO_COMPLCollection.GetAsDataTable(where, CuentaCorrienteChequesMovimientosService.FechaMovimiento_NombreCol);
            }
        }
        #endregion GetMovimientosPorChequeRecibidoPorPersona

        #region GetMovimientosChequeRecibidos


        /// <summary>
        /// Gets the movimientos cheque recibidos.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <returns></returns>
        public DataTable GetMovimientosChequeRecibidos(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                string entidad = CuentaCorrienteChequesMovimientosService.VistaChequeRecibidoEntidadId_NombreCol + " = " + sesion.Entidad.ID;
                if (!clausula.Equals(string.Empty)) clausula += " and ";
                clausula += entidad;

                return sesion.Db.CTACTE_CHQ_MOV_INFO_COMPLCollection.GetAsDataTable(clausula, CuentaCorrienteChequesMovimientosService.FechaMovimiento_NombreCol);
            }
        }
        #endregion GetMovimientosChequeRecibidos

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "CTACTE_CHEQUES_MOVIMIENTOS"; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_CHEQUES_MOVIMIENTOSCollection.IDColumnName; }
        }
        public static string CtaCteChequeGiradoId_NombreCol
        {
            get { return CTACTE_CHEQUES_MOVIMIENTOSCollection.CTACTE_CHEQUE_GIRADO_IDColumnName; }
        }
        public static string CasoIdId_NombreCol
        {
            get { return CTACTE_CHEQUES_MOVIMIENTOSCollection.CASO_IDColumnName; }
        }
        public static string CtaCteChequeRecibidoId_NombreCol
        {
            get { return CTACTE_CHEQUES_MOVIMIENTOSCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string EstadoDestinoId_NombreCol
        {
            get { return CTACTE_CHEQUES_MOVIMIENTOSCollection.ESTADO_DESTINO_IDColumnName; }
        }
        public static string EstadoOriginalId_NombreCol
        {
            get { return CTACTE_CHEQUES_MOVIMIENTOSCollection.ESTADO_ORIGINAL_IDColumnName; }
        }
        public static string FechaMovimiento_NombreCol
        {
            get { return CTACTE_CHEQUES_MOVIMIENTOSCollection.FECHA_MOVIMIENTOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CTACTE_CHEQUES_MOVIMIENTOSCollection.OBSERVACIONColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return CTACTE_CHEQUES_MOVIMIENTOSCollection.USUARIO_IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return CTACTE_CHEQUES_MOVIMIENTOSCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string VistaEstadoDestinoAlias_NombreCol
        {
            get { return CTACTE_CHQ_MOV_INFO_COMPLCollection.ESTADO_DESTINO_ALIASColumnName; }
        }
        public static string VistaEstadoDestinoNombre_NombreCol
        {
            get { return CTACTE_CHQ_MOV_INFO_COMPLCollection.ESTADO_DESTINO_NOMBREColumnName; }
        }
        public static string VistaEstadoOrigenAlias_NombreCol
        {
            get { return CTACTE_CHQ_MOV_INFO_COMPLCollection.ESTADO_ORIGEN_ALIASColumnName; }
        }
        public static string VistaEstadoOrigenNombre_NombreCol
        {
            get { return CTACTE_CHQ_MOV_INFO_COMPLCollection.ESTADO_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaUsarioNombre_NombreCol
        {
            get { return CTACTE_CHQ_MOV_INFO_COMPLCollection.USUARIO_NOMBREColumnName; }
        }
        public static string VistaChequeGiradoPersonaId_NombreCol
        {
            get { return CTACTE_CHQ_MOV_INFO_COMPLCollection.CHEQUE_GIRADO_PERSONAColumnName; }
        }
        public static string VistaChequeGiradoProveedorId_NombreCol
        {
            get { return CTACTE_CHQ_MOV_INFO_COMPLCollection.CHEQUE_GIRADO_PROVEEDORColumnName; }
        }
        public static string VistaChequeRecibidoPersonaId_NombreCol
        {
            get { return CTACTE_CHQ_MOV_INFO_COMPLCollection.CHEQUE_RECIBIDO_PERSONAColumnName; }
        }
        public static string VistaChequeRecibidoProveedorId_NombreCol
        {
            get { return CTACTE_CHQ_MOV_INFO_COMPLCollection.CHEQUE_RECIBIDO_PROVEEDORColumnName; }
        }
        public static string VistaChequeRecibidoEntidadId_NombreCol
        {
            get { return CTACTE_CHQ_MOV_INFO_COMPLCollection.CHEQUE_RECIBIDO_ENTIDADColumnName; }
        }
        public static string VistaChequeGiradoEntidadId_NombreCol
        {
            get { return CTACTE_CHQ_MOV_INFO_COMPLCollection.CHEQUE_GIRADO_ENTIDADColumnName; }
        }
        
        #endregion Vista
        #endregion Accessors
    }
}
