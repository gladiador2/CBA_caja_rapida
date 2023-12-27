using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Facturacion;
using System.Collections;
using System.Text.RegularExpressions;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteCajasSucursalService
    {
        #region EstaAbierta
        public static bool EstaAbierta(decimal ctacte_caja_sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return EstaAbierta(ctacte_caja_sucursal_id, sesion);
            }
        }
        public static bool EstaAbierta(decimal ctacte_caja_sucursal_id, SessionService sesion)
        {
            CTACTE_CAJAS_SUCURSALRow row = sesion.Db.CTACTE_CAJAS_SUCURSALCollection.GetByPrimaryKey(ctacte_caja_sucursal_id);
            return row.CTACTE_CAJA_SUCURSAL_ESTADO_ID == Definiciones.CuentaCorrienteCajaSucursalEstados.Abierta;
        }
        #endregion EstaAbierta

        #region GetEstado
        public static string GetEstado(decimal ctacte_caja_sucursal_id, SessionService sesion)
        {
            CTACTE_CAJAS_SUCURSALRow row = sesion.Db.CTACTE_CAJAS_SUCURSALCollection.GetByPrimaryKey(ctacte_caja_sucursal_id);
            return row.CTACTE_CAJA_SUCURSAL_ESTADO_ID;
        }
        #endregion GetEstado

        #region GetCuentaCorrienteCajasSucursalDataTable
        /// <summary>
        /// Gets the cuenta corriente cajas sucursal data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrienteCajasSucursalDataTable2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrienteCajasSucursalDataTable2(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCuentaCorrienteCajasSucursalDataTable2(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_CAJAS_SUCURSALCollection.GetAsDataTable(clausulas, orden);
        }

        public DataTable GetCuentaCorrienteCajasSucursalDataTable(string clausulas, string orden)
        {
            return GetCuentaCorrienteCajasSucursalDataTable2(clausulas, orden);
        }
        #endregion GetCuentaCorrienteCajasSucursalDataTable

        #region GetCuentaCorrienteCajasSucursalInfoCompleta
        public DataTable GetCuentaCorrienteCajasSucursalInfoCompleta(string clausulas, string orden)
        { 
            return GetCuentaCorrienteCajasSucursalInfoCompleta2(clausulas, orden);
        }

        /// <summary>
        /// Gets the cuenta corriente cajas sucursal info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrienteCajasSucursalInfoCompleta2(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return sesion.Db.CTACTE_CAJAS_SUC_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        public static DataTable GetCuentaCorrienteCajasSucursalInfoCompleta(decimal caja_id)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    string clausulas = Id_NombreCol + " = " + caja_id;
                    return sesion.Db.CTACTE_CAJAS_SUC_INFO_COMPCollection.GetAsDataTable(clausulas,string.Empty);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetCuentaCorrienteCajasSucursalInfoCompleta

        #region GetFechaInicioCaja
        public static DateTime GetFechaInicioCaja(decimal caja_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_CAJAS_SUCURSALRow caja = sesion.db.CTACTE_CAJAS_SUCURSALCollection.GetByPrimaryKey(caja_id);
                return caja.FECHA_INICIO;
            }
        }
        #endregion GetFechaInicioCaja

        #region GetFuncionarioCobradorId
        /// <summary>
        /// Gets the funcionario cobrador identifier.
        /// </summary>
        /// <param name="caja_id">The caja_id.</param>
        /// <returns></returns>
        public static decimal GetFuncionarioCobradorId(decimal caja_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFuncionarioCobradorId(caja_id, sesion);
            }
        }

        public static decimal GetFuncionarioCobradorId(decimal caja_id, SessionService sesion)
        {
            CTACTE_CAJAS_SUCURSALRow caja = sesion.db.CTACTE_CAJAS_SUCURSALCollection.GetByPrimaryKey(caja_id);
            return caja.FUNCIONARIO_ID;
        }
        #endregion GetFuncionarioCobradorId

        #region GetExisteCajaAbiertaParaSucursalYFuncionario
        /// <summary>
        /// Gets the existe caja abierta para sucursal Y funcionario.
        /// </summary>
        /// <param name="sucursal_id">The sucursal_id.</param>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static bool GetExisteCajaAbiertaParaSucursalYFuncionario(decimal sucursal_id, decimal funcionario_id)
        {
            decimal id = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(sucursal_id, funcionario_id);

            if (id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                return false;
            else
                return true;
        }
        #endregion GetExisteCajaAbiertaParaSucursalYFuncionario

        #region GetCajaAbiertaParaSucursalYFuncionario
        /// <summary>
        /// Gets the caja abierta para sucursal Y funcionario.
        /// </summary>
        /// <param name="sucursal_id">The sucursal_id.</param>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static decimal GetCajaAbiertaParaSucursalYFuncionario(decimal sucursal_id, decimal? funcionario_id)
        {
            string clausulas = CuentaCorrienteCajasSucursalService.SucursalId_NombreCol + " = " + sucursal_id + " and " +
                               CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol + " = '" + Definiciones.CuentaCorrienteCajaSucursalEstados.Abierta + "' ";

            if (funcionario_id.HasValue)
                clausulas += " and " + CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol + " = " + funcionario_id;

            DataTable dt = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalDataTable2(clausulas, CuentaCorrienteCajasSucursalService.Id_NombreCol + " desc");

            if (dt.Rows.Count > 0)
                return (decimal)dt.Rows[0][CuentaCorrienteCajasSucursalService.Id_NombreCol];
            else
                return Definiciones.Error.Valor.EnteroPositivo;
        }
        public static DataTable GetCajaAbiertaParaSucursalYFuncionarioInfoCompleta(decimal sucursal_id, decimal funcionario_id)
        {
            string clausulas = CuentaCorrienteCajasSucursalService.SucursalId_NombreCol + " = " + sucursal_id + " and " +
                               CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol + " = " + funcionario_id + " and " +
                               CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol + " = '" + Definiciones.CuentaCorrienteCajaSucursalEstados.Abierta + "' ";

            DataTable dt = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalInfoCompleta2(clausulas, string.Empty);

            return dt;
        }
        #endregion GetCajaAbiertaParaSucursalYFuncionario

        #region getCajaAbiertas
        public static DataTable GetCajasAbiertas()
        {
            string clausulas = CuentaCorrienteCajasSucursalService.SucursalId_NombreCol + " is not null and " +
                               CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol + " is not null and " +
                CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol + " = '" + Definiciones.CuentaCorrienteCajaSucursalEstados.Abierta + "' ";

            DataTable dt = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalDataTable2(clausulas, CuentaCorrienteCajasSucursalService.Id_NombreCol + " desc");

            return dt;
        }
        #endregion getCajaAbiertas

        #region GetCajaAbiertaMejorEsfuerzo
        public static decimal GetCajaAbiertaMejorEsfuerzo(decimal? sucursal_id, decimal? funcionario_id, SessionService sesion)
        {
            string clausulas = string.Empty;

            if (sucursal_id.HasValue && funcionario_id.HasValue)
            {
                clausulas = CuentaCorrienteCajasSucursalService.SucursalId_NombreCol + " = " + sucursal_id.Value + " and " +
                            CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol + " = " + funcionario_id.Value + " and " +
                            CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol + " = '" + Definiciones.CuentaCorrienteCajaSucursalEstados.Abierta + "' ";
                DataTable dt = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalDataTable2(clausulas, string.Empty, sesion);
                if (dt.Rows.Count > 0)
                    return (decimal)dt.Rows[0][CuentaCorrienteCajasSucursalService.Id_NombreCol];
            }

            if (funcionario_id.HasValue)
            {
                clausulas = CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol + " = " + funcionario_id.Value + " and " +
                            CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol + " = '" + Definiciones.CuentaCorrienteCajaSucursalEstados.Abierta + "' ";
                DataTable dt = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalDataTable2(clausulas, string.Empty, sesion);

                if (dt.Rows.Count > 0)
                    return (decimal)dt.Rows[0][CuentaCorrienteCajasSucursalService.Id_NombreCol];
            }

            if (sucursal_id.HasValue)
            {
                clausulas = CuentaCorrienteCajasSucursalService.SucursalId_NombreCol + " = " + sucursal_id.Value + " and " +
                            CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol + " = '" + Definiciones.CuentaCorrienteCajaSucursalEstados.Abierta + "' ";
                DataTable dt = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalDataTable2(clausulas, string.Empty, sesion);

                if (dt.Rows.Count > 0)
                    return (decimal)dt.Rows[0][CuentaCorrienteCajasSucursalService.Id_NombreCol];
            }

            return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion GetCajaAbiertaMejorEsfuerzo

        #region VerificarCajaAbierta
        public static bool VerificarCajaAbierta()
        {
            string clausulas =  CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol + " = '" + Definiciones.CuentaCorrienteCajaSucursalEstados.Abierta + "' ";

            DataTable dt = GetCuentaCorrienteCajasSucursalDataTable2(clausulas, string.Empty);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        #endregion VerificarCajaAbierta

        #region GetChequesRecibidosEnCaja
        /// <summary>
        /// Gets the cheques recibidos en caja.
        /// </summary>
        /// <param name="ctacte_caja_sucursal_id">The ctacte_caja_sucursal_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <returns></returns>
        public DataTable GetChequesRecibidosEnCaja(decimal ctacte_caja_sucursal_id, decimal moneda_id)
        {
            CuentaCorrienteCajaService ctacteCajaMov = new CuentaCorrienteCajaService();
            string clausulas = CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol + " = " + ctacte_caja_sucursal_id + " and " +
                               CuentaCorrienteCajaService.CtacteValorId_NombreCol + " = " + Definiciones.CuentaCorrienteValores.Cheque + " and " +
                               CuentaCorrienteCajaService.MonedaId_NombreCol + " = " + moneda_id + " and " +
                               CuentaCorrienteCajaService.VistaCtacteChequeRecibidoEstadoId_NombreCol + " in(" + Definiciones.CuentaCorrienteChequesEstados.AlDia + "," + Definiciones.CuentaCorrienteChequesEstados.AlDia+")"; 
            //Solo los cheques en estado Al Dia o Adelantado

            DataTable dt = ctacteCajaMov.GetCtacteCajaInfoCompleta(clausulas, CuentaCorrienteCajaService.VistaCtacteChequeRecibidoEmisor_NombreCol);
            return dt;
        }
        #endregion GetChequesRecibidosEnCaja

        #region GetChequesRecibidosEnCajaVenc
        /// <summary>
        /// Gets the cheques recibidos en caja.
        /// </summary>
        /// <param name="ctacte_caja_sucursal_id">The ctacte_caja_sucursal_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <param name="desde">The desde.</param>
        /// <param name="hasta">The hasta.</param>
        /// <param name="parte_texto">The parte_texto.</param>
        /// <returns></returns>
        public DataTable GetChequesRecibidosEnCajaVenc(decimal ctacte_caja_sucursal_id, decimal moneda_id, DateTime desde, DateTime hasta, string parte_texto)
        {
            CuentaCorrienteCajaService ctacteCajaMov = new CuentaCorrienteCajaService();
            string clausulas = CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol + " = " + ctacte_caja_sucursal_id + " and " +
                               CuentaCorrienteCajaService.CtacteValorId_NombreCol + " = " + Definiciones.CuentaCorrienteValores.Cheque + " and " +
                               CuentaCorrienteCajaService.MonedaId_NombreCol + " = " + moneda_id + " and " +
                               CuentaCorrienteCajaService.VistaCtacteChequeRecibidoEstadoId_NombreCol + " in (" + Definiciones.CuentaCorrienteChequesEstados.AlDia + ", " + Definiciones.CuentaCorrienteChequesEstados.Adelantado + ") and " +
                               " (" + CuentaCorrienteCajaService.VistaCtacteChequeRecibidoVenc_NombreCol + " between trunc(to_date('" + desde + "','dd/mm/yyyy hh24:mi:ss'),'DD')  and trunc(to_date('" + hasta + "','dd/mm/yyyy hh24:mi:ss'),'DD') ) and " +
                               CuentaCorrienteCajaService.CtacteConceptoId_NombreCol + " <> " + Definiciones.CuentaCorrienteConceptos.EgresoPorTransferencia;
                               
            if (parte_texto.Length > 0)
            {
                decimal monto;

                clausulas += " and ( " +
                            "   upper(" + CuentaCorrienteCajaService.VistaCtacteChequeRecibidoEmisor_NombreCol + ") like '%" + parte_texto.ToUpper() + "%' or " +
                            "   upper(" + CuentaCorrienteCajaService.VistaCtacteChequeRecibidoNumero_NombreCol + ") like '%" + parte_texto.ToUpper() + "%' ";

                if (decimal.TryParse(parte_texto, out monto))
                    clausulas += " or " + CuentaCorrienteCajaService.Monto_NombreCol + " = " + monto + " ";

                clausulas += ") ";
            }

            DataTable dt = ctacteCajaMov.GetCtacteCajaInfoCompleta(clausulas, CuentaCorrienteCajaService.VistaCtacteChequeRecibidoEmisor_NombreCol);
            return dt;
        }
        #endregion GetChequesRecibidosEnCajaVenc

        #region GetSumaEfectivo
        public static decimal GetSumaEfectivo(decimal ctacte_caja_sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dtCaja = GetCuentaCorrienteCajasSucursalDataTable2(CuentaCorrienteCajasSucursalService.Id_NombreCol + " = " + ctacte_caja_sucursal_id, string.Empty);
                return GetSumaEfectivo(ctacte_caja_sucursal_id, SucursalesService.GetMonedaSucursal((decimal)dtCaja.Rows[0][CuentaCorrienteCajasSucursalService.SucursalId_NombreCol]), sesion);
            }
        }

        public static decimal GetSumaEfectivo(decimal ctacte_caja_sucursal_id, decimal moneda_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetSumaEfectivo(ctacte_caja_sucursal_id, moneda_id, sesion);
            }
        }

        public static decimal GetSumaEfectivo(decimal ctacte_caja_sucursal_id, decimal moneda_id, SessionService sesion)
        { 
            string clausula = CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol + " = " + ctacte_caja_sucursal_id + " and " +
                              CuentaCorrienteCajaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                              CuentaCorrienteCajaService.MonedaId_NombreCol+ " = " + moneda_id + " and " +
                              "(" + CuentaCorrienteCajaService.CtacteValorId_NombreCol + " = " + Definiciones.CuentaCorrienteValores.Efectivo + " or " +
                                    CuentaCorrienteCajaService.CtacteConceptoId_NombreCol + " = " + Definiciones.CuentaCorrienteConceptos.SaldoCaja + 
                              ")";
            DataTable ctacte_caja = CuentaCorrienteCajaService.GetCtacteCajaDataTable2(clausula, string.Empty, sesion);
            decimal efectivo = 0;
            foreach (DataRow row in ctacte_caja.Rows) {
                efectivo += decimal.Parse(row[CuentaCorrienteCajaService.Monto_NombreCol].ToString());
            }
            return efectivo;
        }
        #endregion GetSumaEfectivo

        #region GetSaldoCierre
        /// <summary>
        /// Gets the saldo cierre.
        /// </summary>
        /// <param name="ctacte_caja_sucursal_id">The ctacte_caja_sucursal_id.</param>
        /// <returns></returns>
        public static decimal GetSaldoCierre(decimal ctacte_caja_sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_CAJAS_SUCURSALRow row = sesion.db.CTACTE_CAJAS_SUCURSALCollection.GetByPrimaryKey(ctacte_caja_sucursal_id);
                return row.SALDO_CIERRE;
            }
        }
        #endregion GetSaldoCierre

        #region RefrescarCombobox
        public static void RefrescarCombobox(ref System.Windows.Forms.ComboBox cbo, decimal sucursal_id, bool solo_abiertas)
        {
            CuentaCorrienteCajasSucursalService.RefrescarCombobox(ref cbo, sucursal_id, true, solo_abiertas);
        }

        public static void RefrescarCombobox(ref System.Windows.Forms.ComboBox cbo, decimal sucursal_id, bool restringir_sucursal, bool solo_abiertas)
        {
            using (SessionService sesion = new SessionService())
            {
                cbo.DataSource = null;
                string clausulas = "1=1", expresion = string.Empty;

                if(solo_abiertas)
                    clausulas += " and " + CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol + " = '" + Definiciones.EstadosCajaSucursal.Abierta + "'";

                if (restringir_sucursal && !RolesService.Tiene("CTACTE CAJAS SUCURSAL VER TODAS SUCURSALES"))
                    clausulas += " and " + CuentaCorrienteCajasSucursalService.SucursalId_NombreCol + " = " + sucursal_id;
                
                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionRepresentaEmpresa) == Definiciones.SiNo.Si)
                    clausulas += " and " + CuentaCorrienteCajasSucursalService.VistaRegionId_NombreCol + " = " + SucursalesService.GetRegionID(sucursal_id);

                expresion += "'Nº' + isnull(" + CuentaCorrienteCajasSucursalService.NroComprobante_NombreCol + ", '-') + ' ' + " +
                             CuentaCorrienteCajasSucursalService.VistaFuncionarioNombre_NombreCol;
                if(!solo_abiertas)
                    expresion += " + ' (' + " + CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol + " + ')'";
                if (!restringir_sucursal)
                    expresion += " + ' ' + " + CuentaCorrienteCajasSucursalService.VistaSucursalNombre_NombreCol;

                DataTable dt = GetCuentaCorrienteCajasSucursalInfoCompleta2(clausulas, CuentaCorrienteCajasSucursalService.NroComprobante_NombreCol + ", " + CuentaCorrienteCajasSucursalService.VistaFuncionarioNombre_NombreCol);
                dt.Columns.Add("caja_nombre", typeof(string), expresion);

                cbo.DataSource = dt;
                cbo.ValueMember = CuentaCorrienteCajasSucursalService.Id_NombreCol;
                cbo.DisplayMember = "caja_nombre";

                //Pre-seleccionar la caja perteneciente a la sucursal de la cabecera
                if (cbo.Items.Count > 0)
                {
                    //Intentar primero de seleccionar la caja del funcionario asociado al usuario
                    clausulas = CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol + " = '" + Definiciones.EstadosCajaSucursal.Abierta + "' and " +
                                CuentaCorrienteCajasSucursalService.SucursalId_NombreCol + " = " + sucursal_id + " and " +
                                CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol + " = " + sesion.Usuario_Funcionario_id;
                    dt = GetCuentaCorrienteCajasSucursalInfoCompleta2(clausulas, CuentaCorrienteCajasSucursalService.NroComprobante_NombreCol + ", " + CuentaCorrienteCajasSucursalService.VistaFuncionarioNombre_NombreCol);
                    if (dt.Rows.Count > 0)
                        cbo.SelectedValue = dt.Rows[0][CuentaCorrienteCajasSucursalService.Id_NombreCol];

                    if (dt.Rows.Count <= 0)
                    {
                        clausulas = CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol + " = '" + Definiciones.EstadosCajaSucursal.Abierta + "' and " +
                                    CuentaCorrienteCajasSucursalService.SucursalId_NombreCol + " = " + sucursal_id;
                        dt = GetCuentaCorrienteCajasSucursalInfoCompleta2(clausulas, CuentaCorrienteCajasSucursalService.NroComprobante_NombreCol + ", " + CuentaCorrienteCajasSucursalService.VistaFuncionarioNombre_NombreCol);
                        if (dt.Rows.Count > 0)
                            cbo.SelectedValue = dt.Rows[0][CuentaCorrienteCajasSucursalService.Id_NombreCol];
                    }
                }
            }
        }
        #endregion RefrescarCombobox

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.BeginTransaction();

                try
                {
                    CTACTE_CAJAS_SUCURSALRow row = new CTACTE_CAJAS_SUCURSALRow();
                    string valorAnterior = Definiciones.Log.RegistroNuevo;
                    bool existeCajaPrevia;

                    //Se controla que no exista una caja abierta para el funcionario y sucursal
                    existeCajaPrevia = CuentaCorrienteCajasSucursalService.GetExisteCajaAbiertaParaSucursalYFuncionario(
                                            (decimal)campos[CuentaCorrienteCajasSucursalService.SucursalId_NombreCol],
                                            (decimal)campos[CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol]);
                    if(existeCajaPrevia)
                        throw new Exception("Existe una caja abierta del funcionario en la sucursal.");

                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_sucursal_sqc");
                    row.CTACTE_CAJA_SUCURSAL_ESTADO_ID = Definiciones.CuentaCorrienteCajaSucursalEstados.Abierta;

                    if (campos.Contains(CuentaCorrienteCajasSucursalService.AutonumeracionId_NombreCol))
                        row.AUTONUMERACION_ID = (decimal)campos[CuentaCorrienteCajasSucursalService.AutonumeracionId_NombreCol];
                    else
                        row.IsAUTONUMERACION_IDNull = true;
                    
                    row.FECHA_INICIO = DateTime.Now;

                    if(FuncionariosService.EstaActivo((decimal)campos[CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol]))
                        row.FUNCIONARIO_ID = (decimal)campos[CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol];
                    else
                        throw new Exception("El funcionario cobrador se encuentra inactivo.");

                    if(SucursalesService.EstaActivo((decimal)campos[CuentaCorrienteCajasSucursalService.SucursalId_NombreCol]))
                        row.SUCURSAL_ID = (decimal)campos[CuentaCorrienteCajasSucursalService.SucursalId_NombreCol];
                    else
                        throw new Exception("La sucursal se encuentra inactiva.");

                    row.MONEDA_PRINCIPAL_ID = SucursalesService.GetMonedaSucursal(row.SUCURSAL_ID);
                    row.SALDO_CIERRE = (decimal)campos[CuentaCorrienteCajasSucursalService.SaldoCierre_NombreCol];
                    row.EXISTE_CAJA_SIGUIENTE = Definiciones.SiNo.No;

                    if (campos.Contains(CuentaCorrienteCajasSucursalService.CtacteCajaSucAnteriorId_NombreCol))
                    {
                        row.CTACTE_CAJA_SUC_ANTERIOR_ID = (decimal)campos[CuentaCorrienteCajasSucursalService.CtacteCajaSucAnteriorId_NombreCol];
                        CuentaCorrienteCajasSucursalService.ActualizarExisteCajaSiguiente(row.CTACTE_CAJA_SUC_ANTERIOR_ID, true, sesion);
                        //si el campo de monto cierre de caja es automatico, transladar ese monto de la caja anterior al monto de cierre de caja actual
                        if(VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.CajasSucursalSaldoCierreAutomatico).Equals(Definiciones.SiNo.Si))
                            row.SALDO_CIERRE = CuentaCorrienteCajasSucursalService.GetSaldoCierre(row.CTACTE_CAJA_SUC_ANTERIOR_ID);
                    }

                    if (CuentaCorrienteCajasTesoreriaService.EstaActivo((decimal)campos[CuentaCorrienteCajasSucursalService.CtacteCajaTesoreriaId_NombreCol]))
                        row.CTACTE_CAJA_TESORERIA_ID = (decimal)campos[CuentaCorrienteCajasSucursalService.CtacteCajaTesoreriaId_NombreCol];
                    else
                        throw new Exception("La caja de tesorería se encuentra inactiva.");

                    row.USUARIO_ABRE_ID = sesion.Usuario.ID;
                    
                    sesion.Db.CTACTE_CAJAS_SUCURSALCollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    if (!row.IsCTACTE_CAJA_SUC_ANTERIOR_IDNull)
                    {
                        //Agregar el saldo de apertura segun saldo de cierre de la caja anterior
                        decimal monto = CuentaCorrienteCajasSucursalService.GetSaldoCierre(row.CTACTE_CAJA_SUC_ANTERIOR_ID);

                        if (monto > 0)
                        {
                            Hashtable camposIngreso = new System.Collections.Hashtable();
                            camposIngreso.Add(CuentaCorrienteCajaService.Fecha_NombreCol, DateTime.Now);
                            camposIngreso.Add(CuentaCorrienteCajaService.MonedaId_NombreCol, row.MONEDA_PRINCIPAL_ID);
                            camposIngreso.Add(CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_PRINCIPAL_ID));
                            camposIngreso.Add(CuentaCorrienteCajaService.Monto_NombreCol, monto);
                            camposIngreso.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo);
                            camposIngreso.Add(CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID);
                            camposIngreso.Add(CuentaCorrienteCajaService.SucursalId_NombreCol, row.SUCURSAL_ID);
                            camposIngreso.Add(CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, row.FUNCIONARIO_ID);
                            camposIngreso.Add(CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.SaldoCaja);
                            camposIngreso.Add(CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, row.ID);
                            CuentaCorrienteCajaService.Guardar(camposIngreso, sesion);
                        }

                        //Crear las reservas que hayan quedado en la caja anterior
                        CuentaCorrienteCajaReservasService.TransladarANuevaCaja(row.ID, sesion);
                    }

                    sesion.CommitTransaction();
                    return row.ID;
                }
                catch (Exception)
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Guardar

        #region ActualizarExisteCajaSiguiente
        /// <summary>
        /// Actualizars the existe caja siguiente.
        /// </summary>
        /// <param name="ctacte_caja_sucursal_id">The ctacte_caja_sucursal_id.</param>
        /// <param name="existe">if set to <c>true</c> [existe].</param>
        /// <param name="sesion">The sesion.</param>
        private static void ActualizarExisteCajaSiguiente(decimal ctacte_caja_sucursal_id, bool existe, SessionService sesion)
        {
            CTACTE_CAJAS_SUCURSALRow row = sesion.db.CTACTE_CAJAS_SUCURSALCollection.GetByPrimaryKey(ctacte_caja_sucursal_id);
            row.EXISTE_CAJA_SIGUIENTE = existe ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
            sesion.db.CTACTE_CAJAS_SUCURSALCollection.Update(row);
        }
        #endregion ActualizarExisteCajaSiguiente

        #region CorregirSaldoCierre
        public static void CorregirSaldoCierre(decimal ctacte_caja_sucursal_id, decimal saldo_cierre) {
            using (SessionService sesion = new SessionService()){
                CTACTE_CAJAS_SUCURSALRow row = sesion.Db.CTACTE_CAJAS_SUCURSALCollection.GetByPrimaryKey(ctacte_caja_sucursal_id);

                decimal saldo_cierre_original = row.SALDO_CIERRE;
                row.SALDO_CIERRE = saldo_cierre;
                // verificar que el estado de la caja sea cerrado, teoricamente la verificacion siempre tiene que ser true pues desde la UI
                // no se deberia habilitar el boton de editar en otro estado.
                if (row.CTACTE_CAJA_SUCURSAL_ESTADO_ID == Definiciones.CuentaCorrienteCajaSucursalEstados.Cerrada) {
                    sesion.Db.CTACTE_CAJAS_SUCURSALCollection.Update(row);
                    if (saldo_cierre_original == 0) { // si el saldo_cierre anterior es cero, se debe crear el egreso
                        
                        #region Cargar Egreso
                        Hashtable campos = new System.Collections.Hashtable();
                        campos.Add(CuentaCorrienteCajaService.Fecha_NombreCol, DateTime.Now);
                        campos.Add(CuentaCorrienteCajaService.MonedaId_NombreCol, row.MONEDA_PRINCIPAL_ID);
                        campos.Add(CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_PRINCIPAL_ID));
                        campos.Add(CuentaCorrienteCajaService.Monto_NombreCol, -row.SALDO_CIERRE); //Monto negativo por ser un egreso para la caja
                        campos.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo);
                        campos.Add(CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID);
                        campos.Add(CuentaCorrienteCajaService.SucursalId_NombreCol, row.SUCURSAL_ID);
                        campos.Add(CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, row.FUNCIONARIO_ID);
                        campos.Add(CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.SaldoCaja);
                        campos.Add(CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, row.ID);
                        CuentaCorrienteCajaService.Guardar(campos, sesion);
                        #endregion Cargar Egreso

                        if (row.EXISTE_CAJA_SIGUIENTE.Equals(Definiciones.SiNo.Si)) { // si ya existe una caja de sucursal siguiente, se debe crear el ingreso
                            CTACTE_CAJAS_SUCURSALRow[] siguientes_rows = sesion.Db.CTACTE_CAJAS_SUCURSALCollection.GetByCTACTE_CAJA_SUC_ANTERIOR_ID(row.ID);
                            if (siguientes_rows.Length == 1) {
                                CTACTE_CAJAS_SUCURSALRow row_siguiente = siguientes_rows[0];
                                #region Cargar Ingreso
                                Hashtable camposIngreso = new System.Collections.Hashtable();
                                camposIngreso.Add(CuentaCorrienteCajaService.Fecha_NombreCol, DateTime.Now);
                                camposIngreso.Add(CuentaCorrienteCajaService.MonedaId_NombreCol, row_siguiente.MONEDA_PRINCIPAL_ID);
                                camposIngreso.Add(CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais(row_siguiente.SUCURSAL_ID), row_siguiente.MONEDA_PRINCIPAL_ID));
                                camposIngreso.Add(CuentaCorrienteCajaService.Monto_NombreCol, saldo_cierre);
                                camposIngreso.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo);
                                camposIngreso.Add(CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID);
                                camposIngreso.Add(CuentaCorrienteCajaService.SucursalId_NombreCol, row_siguiente.SUCURSAL_ID);
                                camposIngreso.Add(CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, row_siguiente.FUNCIONARIO_ID);
                                camposIngreso.Add(CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.SaldoCaja);
                                camposIngreso.Add(CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, row_siguiente.ID);
                                CuentaCorrienteCajaService.Guardar(camposIngreso, sesion);
                                #endregion Cargar Ingreso
                            }
                        }
                    } else { // si el saldo_cierre anterior no es cero, entonces se debe recuperar el registro de la caja corriente correspondiente al ingreso
                        // debe existir un unico registro ligado a esta caja de sucursal con y con el monto original negativo
                        string clausula_egreso = CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol + " = " + row.ID +
                            " and " + CuentaCorrienteCajaService.Monto_NombreCol + " = -" + Regex.Replace(saldo_cierre_original.ToString(), "[^0-9]+", ".") +
                            " and " + CuentaCorrienteCajaService.CtacteConceptoId_NombreCol + " = " + Definiciones.CuentaCorrienteConceptos.SaldoCaja;
                        
                        DataTable ctacte_caja = CuentaCorrienteCajaService.GetCtacteCajaDataTable2(clausula_egreso, string.Empty);
                        if (ctacte_caja.Rows.Count == 1) {

                            // modificar egreso
                            CuentaCorrienteCajaService.CorregirMonto(decimal.Parse(ctacte_caja.Rows[0][CuentaCorrienteCajaService.Id_NombreCol].ToString()), -saldo_cierre, sesion);

                            if (row.EXISTE_CAJA_SIGUIENTE.Equals(Definiciones.SiNo.Si)) { //si ya existe una caja de sucursal siguiente, se debe modificar el monto del ingreso en la caja corriente
                                // se obtiene la caja de sucursal siguiente (solo puede existir una, de lo contrario falla)
                                CTACTE_CAJAS_SUCURSALRow[] siguientes_rows = sesion.Db.CTACTE_CAJAS_SUCURSALCollection.GetByCTACTE_CAJA_SUC_ANTERIOR_ID(row.ID);
                                if(siguientes_rows.Length == 1){
                                    CTACTE_CAJAS_SUCURSALRow row_siguiente = siguientes_rows[0];
                                    string clausula_ingreso = CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol + " = " + row_siguiente.ID +
                                    " and " + CuentaCorrienteCajaService.Monto_NombreCol + " = " + Regex.Replace(saldo_cierre_original.ToString(), "[^0-9]+", ".") +
                                    " and " + CuentaCorrienteCajaService.CtacteConceptoId_NombreCol + " = " + Definiciones.CuentaCorrienteConceptos.SaldoCaja;
                                    DataTable ctacte_caja_siguiente = CuentaCorrienteCajaService.GetCtacteCajaDataTable2(clausula_ingreso, string.Empty);
                                    if (ctacte_caja_siguiente.Rows.Count == 1) { 
                                        //modificar ingreso
                                        CuentaCorrienteCajaService.CorregirMonto(decimal.Parse(ctacte_caja_siguiente.Rows[0][CuentaCorrienteCajaService.Id_NombreCol].ToString()), saldo_cierre, sesion);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion CorregirSaldoCierre

        #region CerrarCaja
        /// <summary>
        /// Cerrars the caja.
        /// </summary>
        /// <param name="ctacte_caja_sucursal_id">The ctacte_caja_sucursal_id.</param>
        /// <returns></returns>
        public static decimal CerrarCaja(decimal ctacte_caja_sucursal_id, decimal saldo_cierre)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    AutonumeracionesService autonumeracion = new AutonumeracionesService();
                    CTACTE_CAJAS_SUCURSALRow row = sesion.Db.CTACTE_CAJAS_SUCURSALCollection.GetByPrimaryKey(ctacte_caja_sucursal_id);
                    Hashtable campos;
                    string valorAnterior = row.ToString();
                    string listadoCasos = string.Empty;

                    //Control de depositos Bancarios no Finiquitados.
                    //Se hace el subselect mientras no exista borrado logico de la cabecera del deposito
                    string clausulas = DepositosBancariosService.CtacteCajaSucursalId_NombreCol + " = " + row.ID + " and " +
                                       "     exists(select " + CasosService.Id_NombreCol +
                                       "              from " + CasosService.Nombre_Tabla + " c " +
                                       "             where c." + CasosService.Id_NombreCol + " = " + DepositosBancariosService.Nombre_Tabla + "." + DepositosBancariosService.CasoId_NombreCol +
                                       "               and c." + CasosService.EstadoId_NombreCol + " in ('" + Definiciones.EstadosFlujos.Borrador + "','" + Definiciones.EstadosFlujos.Pendiente + "','" + Definiciones.EstadosFlujos.PreAprobado + "') " +
                                       "               and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                                       "            )";
                    DataTable dtDepositos = DepositosBancariosService.GetDepositosBancariosDataTable(clausulas, DepositosBancariosService.CasoId_NombreCol);
                    if (dtDepositos.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDepositos.Rows.Count; i++)
                        {
                            if (!listadoCasos.Equals(string.Empty))
                                listadoCasos += ",";
                            listadoCasos += dtDepositos.Rows[i][DepositosBancariosService.CasoId_NombreCol].ToString();
                        }
                        throw new Exception("Los casos de Depósito Bancario " + listadoCasos + " no están Finiquitados. Favor finalizar el proceso.");
                    }

                    //Control de transferencias Entre cajas de Sucursal y Fondo Fijos (Flujo = 52)
                    string whereTRansferencias = "(" + TransferenciaCajasSucursalService.CajaSucursalOrigenId_NombreCol + "=" + row.ID + " or " + TransferenciaCajasSucursalService.CajaSucursalDestinoId_NombreCol + "=" + row.ID + " ) and " + TransferenciaCajasSucursalService.VistaCasoEstadoId_NombreCol + " not in('" + Definiciones.EstadosFlujos.Anulado + "','" + Definiciones.EstadosFlujos.Cerrado + "')";
                    DataTable dtTRansferencias = TransferenciaCajasSucursalService.GetTransferenciaCajasInfoCompleta(whereTRansferencias, TransferenciaCajasSucursalService.CasoId_NombreCol);
                    if (dtTRansferencias.Rows.Count > 0)
                    {
                        listadoCasos = string.Empty;
                        for (int i = 0; i < dtTRansferencias.Rows.Count; i++)
                        {
                            if (!listadoCasos.Equals(string.Empty))
                            {
                                listadoCasos += ",";
                            }
                            listadoCasos += dtTRansferencias.Rows[i][TransferenciaCajasSucursalService.CasoId_NombreCol].ToString();
                        }
                        throw new Exception("Los casos de Transferencia de Caja " + listadoCasos + " no están Finiquitados. Favor finalizar el proceso.");
                    }

                    //Control de facturas no finiquitadas (Flujo = 9)
                    string queryFacturas = "select fc.* from " + FacturasClienteService.Nombre_Tabla + " fc," + CasosService.Nombre_Tabla+" c";
                    queryFacturas += " where fc." + FacturasClienteService.CtaCteCajaSucursalId_NombreCol + "=" + row.ID;
                    queryFacturas += " and c." + CasosService.EstadoId_NombreCol+ " not in('" + Definiciones.EstadosFlujos.Anulado + "','";
                    queryFacturas += Definiciones.EstadosFlujos.Caja + "','" + Definiciones.EstadosFlujos.Cerrado;
                    queryFacturas += "') and fc." + FacturasClienteService.Estado_NombreCol + "='" + Definiciones.Estado.Activo + "'";
                    queryFacturas += " and c." + CasosService.Id_NombreCol + "=fc." + FacturasClienteService.CasoId_NombreCol;
                    queryFacturas += " and c." + CasosService.Estado_NombreCol + "='" + Definiciones.Estado.Activo + "'";
                    
                    DataTable dtFacturas = sesion.db.EjecutarQuery(queryFacturas);
                    if (dtFacturas.Rows.Count > 0)
                    {
                        listadoCasos = string.Empty;
                        for (int i = 0; i < dtFacturas.Rows.Count; i++)
                        {
                            if (!listadoCasos.Equals(string.Empty))
                            {
                                listadoCasos += ",";
                            }
                            listadoCasos += dtFacturas.Rows[i][FacturasClienteService.CasoId_NombreCol].ToString();
                        }
                        throw new Exception("Los casos de Factura " + listadoCasos + " no están Finiquitados. Favor finalizar el proceso.");
                    }

                    if (!RolesService.Tiene("CTACTE CAJAS SUCURSAL CIERRE NO CONTROLAR FC CONTADOS SIN PAGO"))
                    {
                        //Control de facturas contado con saldo (Flujo = 9)
                        string queryFacturasContado = "select fc.* from " + FacturasClienteService.Nombre_Tabla + " fc," + CasosService.Nombre_Tabla + " c" +
                                         " where fc." + FacturasClienteService.CtaCteCajaSucursalId_NombreCol + " = " + row.ID +
                                         " and c." + CasosService.EstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Caja + "' " +
                                         " and fc." + FacturasClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                                         " and c." + CasosService.Id_NombreCol + " = fc." + FacturasClienteService.CasoId_NombreCol +
                                         " and c." + CasosService.Estado_NombreCol + "='" + Definiciones.Estado.Activo + "'" +
                                         " and fc." + FacturasClienteService.TipoFacturaId_NombreCol + " = '" + Definiciones.TipoFactura.Contado + "'";

                        DataTable dtFacturasContado = sesion.db.EjecutarQuery(queryFacturasContado);
                        if (dtFacturasContado.Rows.Count > 0)
                        {
                            listadoCasos = string.Empty;
                            for (int i = 0; i < dtFacturasContado.Rows.Count; i++)
                            {
                                if (!listadoCasos.Equals(string.Empty))
                                {
                                    listadoCasos += ",";
                                }
                                listadoCasos += dtFacturasContado.Rows[i][FacturasClienteService.CasoId_NombreCol].ToString();
                            }
                            throw new Exception("Los casos de Factura Contado " + listadoCasos + " no están pagados. Favor finalizar el proceso.");
                        }
                    }

                    if (!RolesService.Tiene("CTACTE CAJAS SUCURSAL CIERRE NO CONTROLAR FC ENTREGA INICIAL SIN PAGO"))
                    {
                        //Control de facturas contado con saldo (Flujo = 9)
                        string queryEntregaInicial = "select fc.* from " + FacturasClienteService.Nombre_Tabla + " fc," + CuentaCorrientePersonasService.Nombre_Tabla + " cp" +
                                         " where fc." + FacturasClienteService.CtaCteCajaSucursalId_NombreCol + " = " + row.ID +
                                         " and fc." + FacturasClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                                         " and cp." + CuentaCorrientePersonasService.CasoId_NombreCol + " = fc." + FacturasClienteService.CasoId_NombreCol + " " +
                                         " and cp." + CuentaCorrientePersonasService.CtaCteConceptoId_NombreCol + " = " + Definiciones.CuentaCorrienteConceptos.EntregaInicial +
                                         " and cp." + CuentaCorrientePersonasService.Estado_NombreCol + "='" + Definiciones.Estado.Activo + "'" +
                                         " and cp." + CuentaCorrientePersonasService.Debito_NombreCol + " < cp." + CuentaCorrientePersonasService.Credito_NombreCol;

                            DataTable dtEntregaInicial = sesion.db.EjecutarQuery(queryEntregaInicial);
                        if (dtEntregaInicial.Rows.Count > 0)
                        {
                            listadoCasos = string.Empty;
                            for (int i = 0; i < dtEntregaInicial.Rows.Count; i++)
                            {
                                if (!listadoCasos.Equals(string.Empty))
                                {
                                    listadoCasos += ",";
                                }
                                listadoCasos += dtEntregaInicial.Rows[i][FacturasClienteService.CasoId_NombreCol].ToString();
                            }
                            throw new Exception("Los casos de Factura " + listadoCasos + " tienen entrega inicial no pagada. Favor finalizar el proceso.");
                        }
                    }

                    row.FECHA_FIN = DateTime.Now;
                    row.USUARIO_CIERRA_ID = sesion.Usuario.ID;
                    row.CTACTE_CAJA_SUCURSAL_ESTADO_ID = Definiciones.CuentaCorrienteCajaSucursalEstados.Cerrada;
                    row.SALDO_CIERRE = saldo_cierre;

                    //Agregar el movimiento de egreso por saldo que queda para la siguiente caja
                    if (saldo_cierre > 0)
                    {
                        campos = new System.Collections.Hashtable();
                        campos.Add(CuentaCorrienteCajaService.Fecha_NombreCol, DateTime.Now);
                        campos.Add(CuentaCorrienteCajaService.MonedaId_NombreCol, row.MONEDA_PRINCIPAL_ID);
                        campos.Add(CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_PRINCIPAL_ID));
                        campos.Add(CuentaCorrienteCajaService.Monto_NombreCol, -row.SALDO_CIERRE); //Monto negativo por ser un egreso para la caja
                        campos.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo);
                        campos.Add(CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID);
                        campos.Add(CuentaCorrienteCajaService.SucursalId_NombreCol, row.SUCURSAL_ID);
                        campos.Add(CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, row.FUNCIONARIO_ID);
                        campos.Add(CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.SaldoCaja);
                        campos.Add(CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, row.ID);
                        CuentaCorrienteCajaService.Guardar(campos, sesion);
                    }
                    
                    //Obtener la numeracion de la planilla de cierre de caja
                    if(!row.IsAUTONUMERACION_IDNull)
                        row.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(row.AUTONUMERACION_ID, sesion);

                    #region realizar Transferencia de cajas, cuando la caja se aprueba
                    CuentaCorrientePagosPersonaDetalleService.TransferenciaDeCaja_POS_agrupado(row.SUCURSAL_ID, row.FUNCIONARIO_ID , sesion);
                    #endregion realizar Transferencia de cajas, cuando la caja se aprueba

                    sesion.Db.CTACTE_CAJAS_SUCURSALCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    return row.ID;
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion CerrarCaja

        #region RemitirCajaATesoreria
        /// <summary>
        /// Remitirs the caja A tesoreria.
        /// </summary>
        /// <param name="ctacte_caja_sucursal_id">The ctacte_caja_sucursal_id.</param>
        /// <returns></returns>
        public static decimal RemitirCajaATesoreria(decimal ctacte_caja_sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CTACTE_CAJAS_SUCURSALRow row = sesion.Db.CTACTE_CAJAS_SUCURSALCollection.GetByPrimaryKey(ctacte_caja_sucursal_id);
                    string valorAnterior = row.ToString();

                    row.CTACTE_CAJA_SUCURSAL_ESTADO_ID = Definiciones.CuentaCorrienteCajaSucursalEstados.Remitida;
                    
                    sesion.Db.CTACTE_CAJAS_SUCURSALCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    return row.ID;
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion RemitirCajaATesoreria

        #region AceptarCajaEnTesoreria
        /// <summary>
        /// Aceptars the caja en tesoreria.
        /// </summary>
        /// <param name="ctacte_caja_sucursal_id">The ctacte_caja_sucursal_id.</param>
        /// <returns></returns>
        public static decimal AceptarCajaEnTesoreria(decimal ctacte_caja_sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    CTACTE_CAJAS_SUCURSALRow row = sesion.Db.CTACTE_CAJAS_SUCURSALCollection.GetByPrimaryKey(ctacte_caja_sucursal_id);
                    string valorAnterior = row.ToString();
                    string listadoCasos = string.Empty;

                    row.CTACTE_CAJA_SUCURSAL_ESTADO_ID = Definiciones.CuentaCorrienteCajaSucursalEstados.Aceptada;

                    (new CuentaCorrienteCajasTesoreriaMovimientosService()).IngresoValoresCierreCajaSucursal(ctacte_caja_sucursal_id, sesion);

                    sesion.Db.CTACTE_CAJAS_SUCURSALCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.CommitTransaction();

                    return row.ID;
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion AceptarCajaEnTesoreria

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_CAJAS_SUCURSAL"; }
        }
        public static string Nombre_Vista
        {
            get { return "CTACTE_CAJAS_SUC_INFO_COMP"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSALCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CtacteCajaSucAnteriorId_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSALCollection.CTACTE_CAJA_SUC_ANTERIOR_IDColumnName; }
        }
        public static string CtacteCajaSucursalEstadoId_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSALCollection.CTACTE_CAJA_SUCURSAL_ESTADO_IDColumnName; }
        }
        public static string CtacteCajaTesoreriaId_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSALCollection.CTACTE_CAJA_TESORERIA_IDColumnName; }
        }
        public static string ExisteCajaSiguiente_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSALCollection.EXISTE_CAJA_SIGUIENTEColumnName; }
        }
        public static string FechaFin_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSALCollection.FECHA_FINColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSALCollection.FECHA_INICIOColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSALCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSALCollection.IDColumnName; }
        }
        public static string MonedaPrincipalId_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSALCollection.MONEDA_PRINCIPAL_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSALCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string SaldoCierre_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSALCollection.SALDO_CIERREColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSALCollection.SUCURSAL_IDColumnName; }
        }
        public static string UsuarioAbreId_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSALCollection.USUARIO_ABRE_IDColumnName; }
        }
        public static string UsuarioCierraId_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSALCollection.USUARIO_CIERRA_IDColumnName; }
        }
        public static string VistaFuncionarioCodigo_NombreCol
        {
            get { return CTACTE_CAJAS_SUC_INFO_COMPCollection.FUNCIONARIO_CODIGOColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return CTACTE_CAJAS_SUC_INFO_COMPCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaCtacteCajaTesoreriaAbrev_NombreCol
        {
            get { return CTACTE_CAJAS_SUC_INFO_COMPCollection.CTACTE_CAJA_TESORERIA_ABREVColumnName; }
        }
        public static string VistaCtacteCajaTesoreriaNombre_NombreCol
        {
            get { return CTACTE_CAJAS_SUC_INFO_COMPCollection.CTACTE_CAJA_TESORERIA_NOMBREColumnName; }
        }
        public static string VistaRegionId_NombreCol
        {
            get { return CTACTE_CAJAS_SUC_INFO_COMPCollection.REGION_IDColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CTACTE_CAJAS_SUC_INFO_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaNroComprobante_NombreCol
        {
            get { return CTACTE_CAJAS_SUC_INFO_COMPCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaFechaInicio_NombreCol
        {
            get { return CTACTE_CAJAS_SUC_INFO_COMPCollection.FECHA_INICIOColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static CuentaCorrienteCajasSucursalService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new CuentaCorrienteCajasSucursalService(e.RegistroId, sesion);
        }

        public static decimal? GetIdPorUUID(string uuid, SessionService sesion)
        {
            if (uuid.Length <= 0)
                return null;

            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return e.RegistroId;
        }
        #endregion interfaz IEntidadMigrable

        #region Propiedades
        protected CTACTE_CAJAS_SUCURSALRow row;
        protected CTACTE_CAJAS_SUCURSALRow rowSinModificar;
        public class Modelo : CTACTE_CAJAS_SUCURSALCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? AutonumeracionId { get { if (row.IsAUTONUMERACION_IDNull) return null; else return row.AUTONUMERACION_ID; } set { if (value.HasValue) row.AUTONUMERACION_ID = value.Value; else row.IsAUTONUMERACION_IDNull = true; } }
        public decimal? CtacteCajaSucAnteriorId { get { if (row.IsCTACTE_CAJA_SUC_ANTERIOR_IDNull) return null; else return row.CTACTE_CAJA_SUC_ANTERIOR_ID; } set { if (value.HasValue) row.CTACTE_CAJA_SUC_ANTERIOR_ID = value.Value; else row.IsCTACTE_CAJA_SUC_ANTERIOR_IDNull = true; } }
        public string CtacteCajaSucursalEstadoId { get { return ClaseCBABase.GetStringHelper(row.CTACTE_CAJA_SUCURSAL_ESTADO_ID); } set { row.CTACTE_CAJA_SUCURSAL_ESTADO_ID = value; } }
        public decimal CtacteCajaTesoreriaId { get { return row.CTACTE_CAJA_TESORERIA_ID; } private set { row.CTACTE_CAJA_TESORERIA_ID = value; } }
        public string ExisteCajaSiguiente { get { return ClaseCBABase.GetStringHelper(row.EXISTE_CAJA_SIGUIENTE); } set { row.EXISTE_CAJA_SIGUIENTE = value; } }
        public DateTime? FechaFin { get { if (row.IsFECHA_FINNull) return null; else return row.FECHA_FIN; } set { if (value.HasValue) row.FECHA_FIN = value.Value; else row.IsFECHA_FINNull = true; } }
        public DateTime FechaInicio { get { return row.FECHA_INICIO; } set { row.FECHA_INICIO = value; } }
        public decimal FuncionarioId { get { return row.FUNCIONARIO_ID; } private set { row.FUNCIONARIO_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaPrincipalId { get { return row.MONEDA_PRINCIPAL_ID; } private set { row.MONEDA_PRINCIPAL_ID = value; } }
        public string NroComprobante { get { return ClaseCBABase.GetStringHelper(row.NRO_COMPROBANTE); } set { row.NRO_COMPROBANTE = value; } }
        public decimal SaldoCierre { get { return row.SALDO_CIERRE; } private set { row.SALDO_CIERRE = value; } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } private set { row.SUCURSAL_ID = value; } }
        public decimal UsuarioAbreId { get { return row.USUARIO_ABRE_ID; } private set { row.USUARIO_ABRE_ID = value; } }
        public decimal? UsuarioCierraId { get { if (row.IsUSUARIO_CIERRA_IDNull) return null; else return row.USUARIO_CIERRA_ID; } set { if (value.HasValue) row.USUARIO_CIERRA_ID = value.Value; else row.IsUSUARIO_CIERRA_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CuentaCorrienteCajasSucursalService _ctacte_caja_suc_anterior;
        public CuentaCorrienteCajasSucursalService CtacteCajaSucAnterior
        {
            get
            {
                if (this._ctacte_caja_suc_anterior == null)
                    this._ctacte_caja_suc_anterior = new CuentaCorrienteCajasSucursalService(this.CtacteCajaSucAnteriorId.Value);
                return this._ctacte_caja_suc_anterior;
            }
        }

        private CuentaCorrienteCajasTesoreriaService _ctacte_caja_tesoreria;
        public CuentaCorrienteCajasTesoreriaService CtacteCajaTesoreria
        {
            get
            {
                if (this._ctacte_caja_tesoreria == null)
                    this._ctacte_caja_tesoreria = new CuentaCorrienteCajasTesoreriaService(this.CtacteCajaTesoreriaId);
                return this._ctacte_caja_tesoreria;
            }
        }

        private FuncionariosService _funcionario;
        public FuncionariosService Funcionario
        {
            get
            {
                if (this._funcionario == null)
                    this._funcionario = new FuncionariosService(this.FuncionarioId);
                return this._funcionario;
            }
        }

        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                    this._sucursal = new SucursalesService(this.SucursalId);
                return this._sucursal;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_CAJAS_SUCURSALCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_CAJAS_SUCURSALRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(CTACTE_CAJAS_SUCURSALRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public CuentaCorrienteCajasSucursalService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrienteCajasSucursalService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CuentaCorrienteCajasSucursalService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public CuentaCorrienteCajasSucursalService(EdiCBA.CajaRecaudacion edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = DepositosBancariosService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion);

            #region sucursal
            if (!string.IsNullOrEmpty(edi.sucursal_uuid))
                this._sucursal = SucursalesService.GetPorUUID(edi.sucursal_uuid, sesion);
            if (this._sucursal == null && edi.sucursal != null)
                this._sucursal = new SucursalesService(edi.sucursal, almacenar_localmente, sesion);
            if (this._sucursal == null)
                throw new Exception("No se encontró el UUID " + edi.sucursal_uuid + " ni se definieron los datos del objeto.");

            if (!this.Sucursal.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Sucursal.Id.HasValue)
                this.SucursalId = this.Sucursal.Id.Value;
            #endregion sucursal

            #region caja recaudacion anterior
            if (!string.IsNullOrEmpty(edi.caja_recaudacion_anterior_uuid))
                this._ctacte_caja_suc_anterior = CuentaCorrienteCajasSucursalService.GetPorUUID(edi.caja_recaudacion_anterior_uuid, sesion);
            if (this._ctacte_caja_suc_anterior == null && edi.caja_recaudacion_anterior != null)
                this._ctacte_caja_suc_anterior = new CuentaCorrienteCajasSucursalService(edi.caja_recaudacion_anterior, almacenar_localmente, sesion);
            if (this._ctacte_caja_suc_anterior == null)
                throw new Exception("No se encontró el UUID " + edi.caja_recaudacion_anterior_uuid + " ni se definieron los datos del objeto.");

            if (this._ctacte_caja_suc_anterior != null && !this._ctacte_caja_suc_anterior.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this._ctacte_caja_suc_anterior.Id.HasValue)
                this.CtacteCajaSucAnteriorId = this._ctacte_caja_suc_anterior.Id.Value;
            #endregion caja recaudacion anterior
            
            #region caja tesoreria
            if (!string.IsNullOrEmpty(edi.caja_tesoreria_uuid))
                this._ctacte_caja_tesoreria = CuentaCorrienteCajasTesoreriaService.GetPorUUID(edi.caja_tesoreria_uuid, sesion);
            if (this._ctacte_caja_tesoreria == null && edi.caja_tesoreria != null)
                this._ctacte_caja_tesoreria = new CuentaCorrienteCajasTesoreriaService(edi.caja_tesoreria, almacenar_localmente, sesion);
            if (this._ctacte_caja_tesoreria == null)
                throw new Exception("No se encontró el UUID " + edi.caja_tesoreria_uuid + " ni se definieron los datos del objeto.");

            if (this._ctacte_caja_tesoreria != null && !this._ctacte_caja_tesoreria.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this._ctacte_caja_tesoreria.Id.HasValue)
                this.CtacteCajaTesoreriaId = this._ctacte_caja_tesoreria.Id.Value;
            #endregion caja tesoreria

            this.FechaFin = edi.fecha_cierre;
            this.FechaInicio = edi.fecha_apertura.HasValue ? edi.fecha_apertura.Value : DateTime.Now;

            this.ExisteCajaSiguiente = Definiciones.SiNo.No;

            this.CtacteCajaSucursalEstadoId = Definiciones.CuentaCorrienteCajaSucursalEstados.Abierta;
            if(this.FechaFin.HasValue)
                this.CtacteCajaSucursalEstadoId = Definiciones.CuentaCorrienteCajaSucursalEstados.Cerrada;

            #region funcionario
            if (!string.IsNullOrEmpty(edi.funcionario_uuid))
                this._funcionario = FuncionariosService.GetPorUUID(edi.funcionario_uuid, sesion);
            if (this._funcionario == null && edi.funcionario != null)
                this._funcionario = new FuncionariosService(edi.funcionario, almacenar_localmente, sesion);
            if (this._funcionario != null && !this._funcionario.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this._funcionario.Id.HasValue)
                this.FuncionarioId = this._funcionario.Id.Value;
            #endregion funcionario

            this.MonedaPrincipalId = this.Sucursal.MonedaId;
            this.NroComprobante = edi.nro_comprobante;
            this.SaldoCierre = 0;
            this.UsuarioAbreId = Definiciones.Usuarios.Soporte;
        }
        private CuentaCorrienteCajasSucursalService(CTACTE_CAJAS_SUCURSALRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._ctacte_caja_suc_anterior = null;
            this._ctacte_caja_tesoreria = null;
            this._funcionario = null;
            this._sucursal = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.CajaRecaudacion()
            {
                caja_recaudacion_anterior_uuid = this.CtacteCajaSucAnterior.GetOrCreateUUID(sesion),
                caja_tesoreria_uuid = this.CtacteCajaTesoreria.GetOrCreateUUID(sesion),
                fecha_apertura = this.FechaInicio,
                fecha_cierre = this.FechaFin,
                funcionario_uuid = this.Funcionario.GetOrCreateUUID(sesion),
                nro_comprobante = this.NroComprobante,
                sucursal_uuid = this.Sucursal.GetOrCreateUUID(sesion),
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.caja_recaudacion_anterior = (EdiCBA.CajaRecaudacion)this.CtacteCajaSucAnterior.ToEDI(nueva_profundidad, sesion);
                e.caja_tesoreria = (EdiCBA.CajaTesoreria)this.CtacteCajaTesoreria.ToEDI(nueva_profundidad, sesion);
                e.funcionario = (EdiCBA.Funcionario)this.Funcionario.ToEDI(nueva_profundidad, sesion);
                e.sucursal = (EdiCBA.Sucursal)this.Sucursal.ToEDI(nueva_profundidad, sesion);
            }

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value);
            }
            return e;
        }
        #endregion ToEDI
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
