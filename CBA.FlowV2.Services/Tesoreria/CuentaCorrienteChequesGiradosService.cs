#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using System.Collections;
using CBA.FlowV2.Services.EgresosVariosCaja;
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteChequesGiradosService
    {
        #region ExisteNumero
        /// <summary>
        /// Existes the numero.
        /// </summary>
        /// <param name="ctacte_bancaria_id">The ctacte_bancaria_id.</param>
        /// <param name="numero_cheque">The numero_cheque.</param>
        /// <returns></returns>
        public static bool ExisteNumero(decimal ctacte_bancaria_id, string numero_cheque)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = CuentaCorrienteChequesGiradosService.CtaCteBancariaId_NombreCol + " = " + ctacte_bancaria_id + " and " +
                                   CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol + " = '" + numero_cheque + "' and " +
                                   CuentaCorrienteChequesGiradosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                CTACTE_CHEQUES_GIRADOSRow[] rows = sesion.Db.CTACTE_CHEQUES_GIRADOSCollection.GetAsArray(clausulas, string.Empty);
                return rows.Length > 0;
            }
        }
        #endregion ExisteNumero

        #region GetEstado
        /// <summary>
        /// Gets the estado.
        /// </summary>
        /// <param name="cheque_recibido_id">The cheque_recibido_id.</param>
        /// <returns></returns>
        public static decimal GetEstado(decimal cheque_girado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetEstado(cheque_girado_id, sesion);
            }
        }

        public static decimal GetEstado(decimal cheque_girado_id, SessionService sesion)
        {
            CTACTE_CHEQUES_GIRADOSRow row = sesion.Db.CTACTE_CHEQUES_GIRADOSCollection.GetByPrimaryKey(cheque_girado_id);
            return row.CHEQUE_ESTADO_ID;
        }
        #endregion GetEstado

        #region GetNombreBeneficiariosPorProveedor
        public static DataTable GetNombreBeneficiariosPorProveedor(decimal proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                var proveedor = new ProveedoresService(proveedor_id, sesion);
                
                string sql = " select distinct " + CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol +
                            " from ( " +
                            " select " + CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol +
                            " from ( " +
                            " select ccg." + CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol + " " + CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol + 
                            ", row_number() over (order by ccg.fecha_creacion desc) as num_registro " +                            
                            " from " + CuentaCorrienteChequesGiradosService.Nombre_Tabla + " ccg, " + CasosService.Nombre_Tabla + " c " +
                            " where c." + CasosService.Id_NombreCol + " = ccg." + CuentaCorrienteChequesGiradosService.CasoCreadorId_NombreCol +
                            " and c." + CasosService.ProveedorId_NombreCol + " = " + proveedor.Id.Value +
                            " and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                            " and ccg." + CuentaCorrienteChequesGiradosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " + 
                            " ) " +
                            " where num_registro < 11 " +
                            " ) " +
                            " union " +
                             "select '" + proveedor.RazonSocial.Replace("'", "''") + "' from dual" +
                             " order by 1";

                /*string sql = "select distinct ccg." + CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol + " " + CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol +
                             "  from " + CuentaCorrienteChequesGiradosService.Nombre_Tabla + " ccg, " + CasosService.Nombre_Tabla + " c " +
                             " where c." + CasosService.Id_NombreCol + " = ccg." + CuentaCorrienteChequesGiradosService.CasoCreadorId_NombreCol +
                             "   and c." + CasosService.ProveedorId_NombreCol + " = " + proveedor.Id.Value +
                             "   and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                             "   and ccg." + CuentaCorrienteChequesGiradosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                             "union " +
                             "select '" + proveedor.RazonSocial.Replace("'", "''") + "' from dual" +
                             " order by 1";*/
                return sesion.db.EjecutarQuery(sql);
            }
        }
        #endregion GetNombreBeneficiariosPorProveedor

        #region SaldoAfectado
        /// <summary>
        /// Saldoes the afectado.
        /// </summary>
        /// <param name="cheque_girado_id">The cheque_girado_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static bool SaldoAfectado(decimal cheque_girado_id, SessionService sesion)
        {
            CTACTE_CHEQUES_GIRADOSRow row = sesion.Db.CTACTE_CHEQUES_GIRADOSCollection.GetByPrimaryKey(cheque_girado_id);
            return row.SALDO_AFECTADO.Equals(Definiciones.SiNo.Si);
        }
        #endregion SaldoAfectado

        #region GetChequeGiradoHashtable
        public static Hashtable GetChequeGiradoHashtable(decimal cheque_girado_id)
        {
            Hashtable chequeHashtable = new Hashtable();
            DataTable chequeGirado = CuentaCorrienteChequesGiradosService.GetCuentaCorrienteChequesGiradosInfoCompleta2(CuentaCorrienteChequesGiradosService.Id_NombreCol + " = " + cheque_girado_id, string.Empty);
            if (chequeGirado.Rows.Count <= 0)
                throw new Exception("El cheque seleccionado no existe");

            DataRow cheque = chequeGirado.Rows[0];
            chequeHashtable[CuentaCorrienteChequesGiradosService.CasoCreadorId_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.CasoCreadorId_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.CotizacionMoneda_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.CotizacionMoneda_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.CtaCteBancariaId_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.CtaCteBancariaId_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.CtacteBancoId_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.CtacteBancoId_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.CtaCteVistaBancoEntidadId_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.CtaCteVistaBancoEntidadId_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.CtaCteVistaChequeEstado_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.CtaCteVistaChequeEstado_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.EstadoChequeId_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.EstadoChequeId_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.FechaCobro_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.FechaCobro_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.FechaCreacion_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.FechaCreacion_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.FechaPosdatado_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.FechaPosdatado_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.FechaVencimiento_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.FechaVencimiento_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.Id_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.Id_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.MonedaId_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.MonedaId_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.Monto_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.Monto_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.NumeroCtaBeneficiario_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.NumeroCtaBeneficiario_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.NombreEmisor_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.NombreEmisor_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.EsDiferido_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.EsDiferido_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.VistaImpresionDeltaAltura_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.VistaImpresionDeltaAltura_NombreCol];
            chequeHashtable[CuentaCorrienteChequesGiradosService.VistaImpresionDeltaAncho_NombreCol] = cheque[CuentaCorrienteChequesGiradosService.VistaImpresionDeltaAncho_NombreCol];

            return chequeHashtable;
        }
        #endregion GetChequeGiradoHashtable

        #region GetCuentaCorrienteChequesGiradosDataTable
        /// <summary>
        /// Gets the cuenta corriente cheques girados data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrienteChequesGiradosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = CuentaCorrienteChequesGiradosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                if (clausulas.Length > 0)
                    where += " and (" + clausulas + ")";

                return sesion.Db.CTACTE_CHEQUES_GIRADOSCollection.GetAsDataTable(where, orden);
            }
        }

        #endregion GetCuentaCorrienteChequesGiradosDataTable

        #region GetCuentaCorrienteChequesGiradosInfoCompleta
        /// <summary>
        /// Gets the cuenta corriente cheques girados data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        [Obsolete("utilizar metodos estaticos")]
        public DataTable GetCuentaCorrienteChequesGiradosInfoCompleta(string clausulas, string orden)
        {
            return GetCuentaCorrienteChequesGiradosInfoCompleta2(clausulas, orden);
        }

        public static DataTable GetCuentaCorrienteChequesGiradosInfoCompleta2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrienteChequesGiradosInfoCompleta2(clausulas, orden, sesion);
            }
        }
        public static DataTable GetCuentaCorrienteChequesGiradosInfoCompleta2(string clausulas, string orden, SessionService sesion)
        {
            string where = CuentaCorrienteChequesGiradosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            if (clausulas.Length > 0)
                where += " and (" + clausulas + ")";

            return sesion.Db.CTACTE_CHEQUES_GIR_INFO_COMPLCollection.GetAsDataTable(where, orden);
        }
        #endregion GetCuentaCorrienteChequesGiradosInfoCompleta

        #region Emitir
        /// <summary>
        /// Emitirs the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="usarAutonumeracion">if set to <c>true</c> [usar autonumeracion].</param>
        /// <param name="autonumeracion_id">The autonumeracion_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal Emitir(Hashtable campos, decimal autonumeracion_id, out string nro_cheque, SessionService sesion)
        {
            try
            {
                CTACTE_CHEQUES_GIRADOSRow row = new CTACTE_CHEQUES_GIRADOSRow();
                DataTable dtCtacteBancaria;

                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cheques_girados_sqc");
                row.ESTADO = Definiciones.Estado.Activo;
                row.FECHA_CREACION = DateTime.Now;

                row.COTIZACION_MONEDA = (decimal)campos[CuentaCorrienteChequesGiradosService.CotizacionMoneda_NombreCol];
                
                row.CTACTE_BANCARIA_ID = (decimal)campos[CuentaCorrienteChequesGiradosService.CtaCteBancariaId_NombreCol];
                if(!(CuentaCorrienteCuentasBancariasService.EstaActivo(row.CTACTE_BANCARIA_ID)))
                    throw new Exception("La cuenta bancaria no se encuentra activa.");

                dtCtacteBancaria = CuentaCorrienteCuentasBancariasService.GetCuentaCorrienteBancariasDataTable(CuentaCorrienteCuentasBancariasService.Id_NombreCol + " = " + row.CTACTE_BANCARIA_ID, string.Empty, true);
                row.CTACTE_BANCO_ID = (decimal)dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.CtacteBancoId_NombreCol];
                
                row.FECHA_POSDATADO = (DateTime)campos[CuentaCorrienteChequesGiradosService.FechaPosdatado_NombreCol];
                row.FECHA_VENCIMIENTO = (DateTime)campos[CuentaCorrienteChequesGiradosService.FechaVencimiento_NombreCol];

                row.MONEDA_ID = (decimal)campos[CuentaCorrienteChequesGiradosService.MonedaId_NombreCol];
                if (!MonedasService.EstaActivo(row.MONEDA_ID))
                    throw new Exception("La moneda no se encuentra activa.");

                row.MONTO = (decimal)campos[CuentaCorrienteChequesGiradosService.Monto_NombreCol];
                row.ES_DIFERIDO = (string)campos[CuentaCorrienteChequesGiradosService.EsDiferido_NombreCol];

                if (campos.Contains(CuentaCorrienteChequesGiradosService.AutonumeracionId_NombreCol))
                    row.AUTONUMERACION_ID = (decimal)campos[CuentaCorrienteChequesGiradosService.AutonumeracionId_NombreCol];
                else
                    row.IsAUTONUMERACION_IDNull = true;

                row.NOMBRE_BENEFICIARIO = (string)campos[CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol];
                row.NUMERO_CTA_BENEFICIARIO = (string)campos[CuentaCorrienteChequesGiradosService.NumeroCtaBeneficiario_NombreCol];
                row.NOMBRE_EMISOR = (string)campos[CuentaCorrienteChequesGiradosService.NombreEmisor_NombreCol];

                if (campos.Contains(CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol))
                    row.NUMERO_CHEQUE = (string)campos[CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol];
                else
                    row.NUMERO_CHEQUE = AutonumeracionesService.GetSiguienteNumero2(autonumeracion_id, sesion);

                nro_cheque = row.NUMERO_CHEQUE;

                if (row.FECHA_VENCIMIENTO.Date > DateTime.Now.Date)
                {
                    row.SALDO_AFECTADO = Definiciones.SiNo.No;
                    row.CHEQUE_ESTADO_ID = Definiciones.CuentaCorrienteChequesEstados.Adelantado;
                }
                else
                {
                    row.SALDO_AFECTADO = Definiciones.SiNo.Si;
                    row.CHEQUE_ESTADO_ID = Definiciones.CuentaCorrienteChequesEstados.AlDia;
                }

                if (campos.Contains(CuentaCorrienteChequesGiradosService.CasoCreadorId_NombreCol))
                    row.CASO_CREADOR_ID = (decimal)campos[CuentaCorrienteChequesGiradosService.CasoCreadorId_NombreCol];
                else 
                    row.IsCASO_CREADOR_IDNull = true;

                if (campos.Contains(CuentaCorrienteChequesGiradosService.Observacion_NombreCol) && !Interprete.EsNullODBNull(campos[CuentaCorrienteChequesGiradosService.Observacion_NombreCol]))
                    row.OBSERVACION = (string)campos[CuentaCorrienteChequesGiradosService.Observacion_NombreCol];

                sesion.Db.CTACTE_CHEQUES_GIRADOSCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);

                decimal casoCreador = row.IsCASO_CREADOR_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.CASO_CREADOR_ID;
                CambiarEstado(row.ID, casoCreador, row.CHEQUE_ESTADO_ID, sesion, true);

                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Emitir

        #region Anular
        /// <summary>
        /// Anulars the specified ctacte_cheque_girado_id.
        /// </summary>
        /// <param name="ctacte_cheque_girado_id">The ctacte_cheque_girado_id.</param>
        /// <param name="motivo">The motivo.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Anular(decimal ctacte_cheque_girado_id, string motivo, SessionService sesion)
        {
            CTACTE_CHEQUES_GIRADOSRow row = sesion.Db.CTACTE_CHEQUES_GIRADOSCollection.GetByPrimaryKey(ctacte_cheque_girado_id);
            string valorAnterior = row.ToString();

            row.MOTIVO_ANULACION = motivo;

            sesion.Db.CTACTE_CHEQUES_GIRADOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            CuentaCorrienteChequesGiradosService.CambiarEstado(row.ID, Definiciones.Error.Valor.EnteroPositivo, Definiciones.CuentaCorrienteChequesEstados.Anulado, sesion,false);
        }
        #endregion Anular

        #region Borrar
        public static void Borrar(decimal ctacte_cheque_girado_id, SessionService sesion)
        {
            CTACTE_CHEQUES_GIRADOSRow row = sesion.Db.CTACTE_CHEQUES_GIRADOSCollection.GetByPrimaryKey(ctacte_cheque_girado_id);
            string valorAnterior = row.ToString();            

            row.ESTADO = Definiciones.Estado.Inactivo;

            sesion.db.CTACTE_CHEQUES_GIRADOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion Borrar

        #region CambiarEstado
        /// <summary>
        /// Cambiars the estado.
        /// </summary>
        /// <param name="ctacte_cheque_girado_id">The ctacte_cheque_girado_id.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_destino">The estado_destino.</param>
        /// <param name="sesion">The sesion.</param>
        private static void CambiarEstado(decimal ctacte_cheque_girado_id, decimal caso_id, decimal estado_destino, SessionService sesion, bool esNuevo)
        {
            CTACTE_CHEQUES_GIRADOSRow row = sesion.Db.CTACTE_CHEQUES_GIRADOSCollection.GetByPrimaryKey(ctacte_cheque_girado_id);
            string valorAnterior = row.ToString();
            decimal estadoAnterior = 0;

            if (!row.IsCHEQUE_ESTADO_IDNull)
            {
                estadoAnterior = row.CHEQUE_ESTADO_ID;
            }

            if (esNuevo)
            {
                estadoAnterior = Definiciones.Error.Valor.EnteroPositivo;
            }

            row.CHEQUE_ESTADO_ID = estado_destino;

            // Se actualiza el estado del cheque
            sesion.Db.CTACTE_CHEQUES_GIRADOSCollection.Update(row);

            //se guarda el movimiento
            Hashtable campos = new Hashtable();
            campos.Add(CuentaCorrienteChequesMovimientosService.CtaCteChequeGiradoId_NombreCol, row.ID);

            if (estadoAnterior != Definiciones.Error.Valor.EnteroPositivo)
                campos.Add(CuentaCorrienteChequesMovimientosService.EstadoOriginalId_NombreCol, estadoAnterior);

            campos.Add(CuentaCorrienteChequesMovimientosService.EstadoDestinoId_NombreCol, row.CHEQUE_ESTADO_ID);

            if (caso_id != Definiciones.Error.Valor.EnteroPositivo)
                campos.Add(CuentaCorrienteChequesMovimientosService.CasoIdId_NombreCol, caso_id);

            new CuentaCorrienteChequesMovimientosService().Guardar(campos, sesion);

            //se guarda el log
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }

        #endregion CambiarEstado

        #region CambiarFecha
        public static void CambiarFecha(decimal ctacte_cheque_girado_id, DateTime fecha_posdatado, DateTime fecha_vencimiento)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_CHEQUES_GIRADOSRow row = sesion.Db.CTACTE_CHEQUES_GIRADOSCollection.GetByPrimaryKey(ctacte_cheque_girado_id);
                string valorAnterior = row.ToString();

                if (fecha_vencimiento < fecha_posdatado)
                    throw new Exception("La fecha de vencimiento no puede sar anterior a la de confección.");

                row.FECHA_POSDATADO = fecha_posdatado;
                row.FECHA_VENCIMIENTO = fecha_vencimiento;

                sesion.Db.CTACTE_CHEQUES_GIRADOSCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
        }
        #endregion CambiarFecha

        #region ExisteChequeGiradoParaCuentaYNumero
        public static bool ExisteChequeGiradoParaCuentaYNumero(decimal ctacte_bancaria_id, string numero_cheque, out decimal caso_existe_cheque_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas;
                DataTable dt;
                caso_existe_cheque_id = Definiciones.Error.Valor.EnteroPositivo;

                clausulas = OrdenesPagoValoresService.CGCtacteBancariaId_NombreCol + " = " + ctacte_bancaria_id + " and " +
                                   OrdenesPagoValoresService.CGNumeroCheque_NombreCol + " = '" + numero_cheque + "' and " +
                                   OrdenesPagoValoresService.VistaOrdenPagoCasoEstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' ";
                dt = OrdenesPagoValoresService.GetOrdenesPagoValoresInfoCompleta(clausulas, string.Empty, sesion);
                if (dt.Rows.Count > 0)
                {
                    caso_existe_cheque_id = (decimal)dt.Rows[0][OrdenesPagoValoresService.VistaOrdenPagoCasoId_NombreCol];
                    return true;
                }

                clausulas = EgresosVariosCajaValoresService.CGCtacteBancariaId_NombreCol + " = " + ctacte_bancaria_id + " and " +
                            EgresosVariosCajaValoresService.CGNumeroCheque_NombreCol + " = '" + numero_cheque + "' and " +
                            EgresosVariosCajaValoresService.VistaCasoEstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' ";
                dt = EgresosVariosCajaValoresService.GetInfoCompleta(clausulas, string.Empty, sesion);
                if (dt.Rows.Count > 0)
                {
                    caso_existe_cheque_id = (decimal)dt.Rows[0][EgresosVariosCajaValoresService.VistaCasoId_NombreCol];
                    return true;
                }

                return false;
            }
        }
        #endregion ExisteChequeGiradoParaCuentaYNumero

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_CHEQUES_GIRADOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "ctacte_cheques_gir_info_compl"; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CtacteBancoId_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.CTACTE_BANCO_IDColumnName; }
        }
        public static string EstadoChequeId_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.CHEQUE_ESTADO_IDColumnName; }
        }
        public static string EsDiferido_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.ES_DIFERIDOColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.ESTADOColumnName; }
        }
        public static string FechaCobro_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.FECHA_COBROColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.FECHA_CREACIONColumnName; }
        }
        public static string FechaPosdatado_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.FECHA_POSDATADOColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.MONTOColumnName; }
        }
        public static string NombreBeneficiario_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string NombreEmisor_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.NOMBRE_EMISORColumnName; }
        }
        public static string NumeroCheque_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.NUMERO_CHEQUEColumnName; }
        }
        public static string NumeroCtaBeneficiario_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.NUMERO_CTA_BENEFICIARIOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.OBSERVACIONColumnName; }
        }
        public static string SaldoAfectado_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.SALDO_AFECTADOColumnName; }
        }
        public static string CasoCreadorId_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.CASO_CREADOR_IDColumnName; }
        }
        public static string CtaCteBancariaId_NombreCol
        {
            get { return CTACTE_CHEQUES_GIRADOSCollection.CTACTE_BANCARIA_IDColumnName; }
        }
        public static string CtaCteVistaBancoEntidadId_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.BANCO_ENTIDADColumnName; }
        }
        public static string CtaCteVistaChequeEstado_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.CHEQUE_ESTADOColumnName; }
        }
        public static string VistaImpresionDeltaAltura_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.IMPRESION_DELTA_ALTURAColumnName; }
        }
        public static string VistaImpresionDeltaAncho_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.IMPRESION_DELTA_ANCHOColumnName; }
        }
        public static string VistaCuentaBancaria_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.CTACTE_BANCARIAS_NUMEROColumnName; }
        }
        public static string VistaCtaCteBanco_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.BANCO_NOMBREColumnName; }
        }
        public static string VistaCtaCteBancoAbreviatura_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.BANCO_ABREVIATURAColumnName; }
        }
        public static string VistaCtaCteBancoId_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.CTACTE_BANCO_IDColumnName; }
        }
        public static string VistaCtaCteEntidad_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.ENTIDAD_NOMBREColumnName; }
        }
        public static string VistaCtaCteMonedaId_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.MONEDA_IDColumnName; }
        }
        public static string VistaCtaCteMonedas_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.MONEDAS_NOMBREColumnName; }
        }
        public static string VistaCtaCteMonedaSimbolo_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.MONEDAS_SIMBOLOColumnName; }
        }
        public static string VistaCtaCteMonto_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.MONTOColumnName; }
        }
        public static string VistaCtaCteEstado_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.ESTADOColumnName; }
        }
        public static string VistaCtaCteNumeroCheque_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.NUMERO_CHEQUEColumnName; }
        }
        public static string VistaCtaCteBancariaId_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.CTACTE_BANCARIA_IDColumnName; }
        }
        public static string VistaCtaCteEmisor_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.NOMBRE_EMISORColumnName; }
        }
        public static string VistaCtaCteFechaCobro_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.FECHA_COBROColumnName; }
        }
        public static string VistaCtaCteFechaCreacion_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.FECHA_CREACIONColumnName; }
        }
        public static string VistaCtaCteFechaEntrega_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.FECHA_ENTREGAColumnName; }
        }
        public static string VistaCtaCteBeneficiario_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string VistaCtaCteFechaPosDatado_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.FECHA_POSDATADOColumnName; }
        }
        public static string VistaCtaCteFechaVencimiento_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string VistaCtaCteCotizacionMoneda_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string VistaCtaCteSaldoAfectado_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.SALDO_AFECTADOColumnName; }
        }
        public static string VistaCtaCteChequeEstadoId_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.CHEQUE_ESTADO_IDColumnName; }
        }
        public static string VistaCtaCteChequeEstado_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.CHEQUE_ESTADOColumnName; }
        }
        public static string VistaCtaCteMotivoAnulacion_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.MOTIVO_ANULACIONColumnName; }
        }
        public static string VistaCtaCteCasoCreadorId_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.CASO_CREADOR_IDColumnName; }
        }
        public static string VistaCtaCteId_NombreCol
        {
            get { return CTACTE_CHEQUES_GIR_INFO_COMPLCollection.IDColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region Propiedades
        protected CTACTE_CHEQUES_GIRADOSRow row;
        protected CTACTE_CHEQUES_GIRADOSRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? AutonumeracionId { get { if (row.IsAUTONUMERACION_IDNull) return null; else return row.AUTONUMERACION_ID; } set { if (value.HasValue) row.AUTONUMERACION_ID = value.Value; else row.IsAUTONUMERACION_IDNull = true; } }
        public decimal? CasoCreadorId { get { if (row.IsCASO_CREADOR_IDNull) return null; else return row.CASO_CREADOR_ID; } set { if (value.HasValue) row.CASO_CREADOR_ID = value.Value; else row.IsCASO_CREADOR_IDNull = true; } }
        public decimal? ChequeEstadoId { get { if (row.IsCHEQUE_ESTADO_IDNull) return null; else return row.CHEQUE_ESTADO_ID; } set { if (value.HasValue) row.CHEQUE_ESTADO_ID = value.Value; else row.IsCHEQUE_ESTADO_IDNull = true; } }
        public decimal CotizacionMoneda { get { return row.COTIZACION_MONEDA; } set { row.COTIZACION_MONEDA = value; } }
        public decimal CtacteBancariaId { get { return row.CTACTE_BANCARIA_ID; } set { row.CTACTE_BANCARIA_ID = value; } }
        public decimal CtacteBancoId { get { return row.CTACTE_BANCO_ID; } set { row.CTACTE_BANCO_ID = value; } }
        public string EsDiferido { get { return ClaseCBABase.GetStringHelper(row.ES_DIFERIDO); } set { row.ES_DIFERIDO = value; } }
        public DateTime? FechaCobro { get { if (row.IsFECHA_COBRONull) return null; else return row.FECHA_COBRO; } set { if (value.HasValue) row.FECHA_COBRO = value.Value; else row.IsFECHA_COBRONull = true; } }
        public DateTime? FechaEntrega { get { if (row.IsFECHA_ENTREGANull) return null; else return row.FECHA_ENTREGA; } set { if (value.HasValue) row.FECHA_ENTREGA = value.Value; else row.IsFECHA_ENTREGANull = true; } }
        public DateTime FechaPosdatado { get { return row.FECHA_POSDATADO; } set { row.FECHA_POSDATADO = value; } }
        public DateTime FechaVencimiento { get { return row.FECHA_VENCIMIENTO; } set { row.FECHA_VENCIMIENTO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal Monto { get { return row.MONTO; } set { row.MONTO = value; } }
        public string MotivoAnulacion { get { return ClaseCBABase.GetStringHelper(row.MOTIVO_ANULACION); } set { row.MOTIVO_ANULACION = value; } }
        public string NombreBeneficiario { get { return ClaseCBABase.GetStringHelper(row.NOMBRE_BENEFICIARIO); } set { row.NOMBRE_BENEFICIARIO = value; } }
        public string NombreEmisor { get { return ClaseCBABase.GetStringHelper(row.NOMBRE_EMISOR); } set { row.NOMBRE_EMISOR = value; } }
        public string NumeroCheque { get { return ClaseCBABase.GetStringHelper(row.NUMERO_CHEQUE); } set { row.NUMERO_CHEQUE = value; } }
        public string saldoAfectado { get { return row.SALDO_AFECTADO; } set { row.SALDO_AFECTADO = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CasosService _caso_creador;
        public CasosService CasoCreador
        {
            get
            {
                if (this._caso_creador == null)
                {
                    //Descomentar cuando la clase sea orientada a objetos
                    //if(this.sesion != null)
                    //    this._caso = new CasosService(this.CasoId.Value, this.sesion);
                    //else
                        this._caso_creador = new CasosService(this.CasoCreadorId.Value);
                }
                return this._caso_creador;
            }
        }

        private CuentaCorrienteCuentasBancariasService _ctacte_bancaria;
        public CuentaCorrienteCuentasBancariasService CtacteBancaria
        {
            get
            {
                if (this._ctacte_bancaria == null)
                {
                    //Descomentar cuando la clase sea orientada a objetos
                    //if(this.sesion != null)
                    //    this._caso = new CuentaCorrienteCuentasBancariasService(this.CtacteBancariaId, this.sesion);
                    //else
                    this._ctacte_bancaria = new CuentaCorrienteCuentasBancariasService(this.CtacteBancariaId);
                }
                return this._ctacte_bancaria;
            }
        }

        private CuentaCorrienteBancosService _ctacte_banco;
        public CuentaCorrienteBancosService CtacteBanco
        {
            get
            {
                if (this._ctacte_banco == null)
                {
                    //Descomentar cuando la clase sea orientada a objetos
                    //if(this.sesion != null)
                    //    this._caso = new CuentaCorrienteBancosService(this.CtacteBancoId, this.sesion);
                    //else
                    this._ctacte_banco = new CuentaCorrienteBancosService(this.CtacteBancoId);
                }
                return this._ctacte_banco;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                    this._moneda = MonedasService.Instancia.Get<MonedasService>(this.MonedaId);
                return this._moneda;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_CHEQUES_GIRADOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_CHEQUES_GIRADOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(CTACTE_CHEQUES_GIRADOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public CuentaCorrienteChequesGiradosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrienteChequesGiradosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CuentaCorrienteChequesGiradosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        private CuentaCorrienteChequesGiradosService(CTACTE_CHEQUES_GIRADOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._caso_creador = null;
            this._ctacte_bancaria = null;
            this._ctacte_banco = null;
            this._moneda = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        public static CuentaCorrienteChequesGiradosService[] Buscar(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return Buscar(clausulas, orden, sesion);
            }
        }

        public static CuentaCorrienteChequesGiradosService[] Buscar(string clausulas, string orden, SessionService sesion)
        {
            var rows = sesion.db.CTACTE_CHEQUES_GIRADOSCollection.GetAsArray(clausulas, orden);
            var cp = new CuentaCorrienteChequesGiradosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                cp[i] = new CuentaCorrienteChequesGiradosService(rows[i]);
            return cp;
        }
        #endregion Buscar
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
