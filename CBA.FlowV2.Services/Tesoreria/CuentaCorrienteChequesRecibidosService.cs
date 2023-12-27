using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using System.Collections;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteChequesRecibidosService
    {
        #region GetDataTable
        public static DataTable GetDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = CuentaCorrienteChequesRecibidosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                if (clausulas.Length > 0)
                    where += " and (" + clausulas + ")";

                return sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetAsDataTable(where, orden);
            }
        }

        public static DataTable GetDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = CuentaCorrienteChequesRecibidosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            if (clausulas.Length > 0)
                where += " and (" + clausulas + ")";

            return sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetAsDataTable(where, orden);
        }
        #endregion GetDataTable

        #region GetCuentaCorrienteChequesRecibidosPersonaEstadoMoneda

        /// <summary>
        /// Gets the cuenta corriente cheques recibidos persona estado moneda.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <returns></returns>
        public decimal GetCuentaCorrienteChequesRecibidosPersonaEstadoMoneda(decimal persona_id, decimal estado_id, decimal moneda_id)
        {
            decimal total=0;
            decimal monto=0;
            decimal cotizacion=0;
            string clausulas = CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol + "=" + persona_id +
                                " and " + CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol + "=" + estado_id +
                                " and " + CuentaCorrienteChequesRecibidosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            using (SessionService sesion = new SessionService())
            {
               CTACTE_CHEQUES_REC_INFO_COMPLRow[] rows= sesion.Db.CTACTE_CHEQUES_REC_INFO_COMPLCollection.GetAsArray(clausulas,string.Empty);
                for(int i=0;i<rows.Length;i++)
                {
                    CTACTE_CHEQUES_REC_INFO_COMPLRow row= rows[i];
                    monto =row.MONTO;
                    cotizacion = CotizacionesService.GetCotizacionMonedaVenta(row.MONEDA_ID);
                    total += monto / cotizacion;
                }
                 cotizacion = CotizacionesService.GetCotizacionMonedaVenta(moneda_id);
                 total = total / cotizacion;

            }
            return total;
        }

        #endregion GetCuentaCorrienteChequesRecibidosPersonaEstadoMoneda

        #region GetCuentaCorrienteChequesRecibidosInfoCompleta
        /// <summary>
        /// Gets the cuenta corriente cheques recibidos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetCuentaCorrienteChequesRecibidosInfoCompleta(string clausulas, string orden)
        {

            using (SessionService sesion = new SessionService())
            {
                string entidad = CuentaCorrienteChequesRecibidosService.VistaBancoEntidaId_NombreCol + "=" + sesion.Entidad.ID + " and " +
                                 CuentaCorrienteChequesRecibidosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

                if (!clausulas.Equals(string.Empty)) clausulas += " and ";
                clausulas += entidad;
                return sesion.Db.CTACTE_CHEQUES_REC_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetCuentaCorrienteChequesRecibidosInfoCompleta2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrienteChequesRecibidosInfoCompleta2(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCuentaCorrienteChequesRecibidosInfoCompleta2(string clausulas, string orden, SessionService sesion)
        {
            string entidad = CuentaCorrienteChequesRecibidosService.VistaBancoEntidaId_NombreCol + "=" + sesion.Entidad.ID + " and " +
                             CuentaCorrienteChequesRecibidosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (!clausulas.Equals(string.Empty)) clausulas += " and ";
            clausulas += entidad;
            return sesion.Db.CTACTE_CHEQUES_REC_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCuentaCorrienteChequesRecibidosInfoCompleta

        #region GetCuentaCorrienteChequesRecibidosDataRow
        public static DataRow GetCuentaCorrienteChequesRecibidosDataRow(string id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string clausula = CuentaCorrienteChequesRecibidosService.Id_NombreCol + "=" + id;

                table = sesion.Db.CTACTE_CHEQUES_REC_INFO_COMPLCollection.GetAsDataTable(clausula, string.Empty);
                return table.Rows[0];
            }
        }
        #endregion GetGetCuentaCorrienteChequesRecibidosDataRow

        #region GetChequesAdelantadosMontoTotalPorPersonaId
        public static decimal GetChequesAdelantadosMontoTotalPorPersonaId(decimal personaId)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetChequesAdelantadosMontoTotalPorPersonaId(personaId, sesion);
            }
        }

        public static decimal GetChequesAdelantadosMontoTotalPorPersonaId(decimal personaId, SessionService sesion)
        {           
            string query = "";
            query += "select sum(ccr." + CuentaCorrienteChequesRecibidosService.Monto_NombreCol + ")" + CuentaCorrienteChequesRecibidosService.Monto_NombreCol + " \n";
            query += "from " + CuentaCorrienteChequesRecibidosService.Nombre_Tabla + " ccr, " + CasosService.Nombre_Tabla + " c " + "\n";
            query += "where ccr." + CuentaCorrienteChequesRecibidosService.CasoCreadorId_NombreCol + " = c." + CasosService.Id_NombreCol + " \n";
            query += "and ccr." + CuentaCorrienteChequesRecibidosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " + "\n";
            query += "and ccr." + CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol + " = " + CBA.FlowV2.Services.Base.Definiciones.CuentaCorrienteChequesEstados.Adelantado + "\n";
            query += "and c." + CasosService.PersonaId_NombreCol + " = " + personaId;

            DataTable dt = sesion.db.EjecutarQuery(query);

            if (dt.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol] != DBNull.Value)
                return decimal.Parse(dt.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol].ToString());
            else
                return 0;
        }
        #endregion GetChequesAdelantadosMontoTotalPorPersonaId

        #region GetTotalPorEstado
        /// <summary>
        /// Gets the total por estado.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetTotalPorEstado(string clausula, string orden)
        {
            DataTable dt = GetCuentaCorrienteChequesRecibidosInfoCompleta(clausula, orden);
            DataTable dtEstados;
            DataTable dtMontoPorMoneda;
            DataTable dtMonedas = new DataTable();
            DataTable dtResumen = new DataTable();
            
            using (SessionService sesion = new SessionService())
            {
                dtEstados = sesion.Db.ObtenerDistintos(new string[] { CuentaCorrienteChequesRecibidosService.VistaEstadoNombre_NombreCol,CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol}, dt);
                dtMonedas = sesion.Db.ObtenerDistintos(new string[] { CuentaCorrienteChequesRecibidosService.VistaMonedaNombre_NombreCol, CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol }, dt);


                //Se agregan las columnas estáticas
                dtResumen.Columns.Add(CuentaCorrienteChequesRecibidosService.VistaEstadoNombre_NombreCol, typeof(string));

                //Agregamos la cantidad de columnas dependiendo de la cantidad de monedas existentes
                for(int i = 0; i < dtMonedas.Rows.Count; i++)
                {
                    dtResumen.Columns.Add(dtMonedas.Rows[i][CuentaCorrienteChequesRecibidosService.VistaMonedaNombre_NombreCol].ToString(), typeof(string)).DefaultValue = 0;
                    dtResumen.Columns.Add(dtMonedas.Rows[i][CuentaCorrienteChequesRecibidosService.VistaMonedaNombre_NombreCol].ToString() + "_ID", typeof(decimal)).DefaultValue = (decimal)dtMonedas.Rows[i][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol];
                }

                string idEstado = string.Empty;
                DataRow dr;
 
                for (int i = 0; i < dtEstados.Rows.Count; i++)
                {
                    dr = dtResumen.NewRow();
                    idEstado = dtEstados.Rows[i][CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol].ToString();
                    dtMontoPorMoneda = sesion.Db.CTACTE_CHEQUES_REC_MONTOCollection.GetAsDataTable(CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol + " = " + idEstado, string.Empty);

                    dr[CuentaCorrienteChequesRecibidosService.VistaEstadoNombre_NombreCol] = dtEstados.Rows[i][CuentaCorrienteChequesRecibidosService.VistaEstadoNombre_NombreCol].ToString();
                     
                    for (int j = 0; j < dtMontoPorMoneda.Rows.Count; j++)
                    {
                        dr[dtMontoPorMoneda.Rows[j][CuentaCorrienteChequesRecibidosService.VistaMonedaNombre_NombreCol].ToString()] = (decimal)dtMontoPorMoneda.Rows[j][CuentaCorrienteChequesRecibidosService.SumaMonto_NombreCol];

                    }

                    dtResumen.Rows.Add(dr);
                }

            }
            return dtResumen;
        }
        #endregion GetTotalPorEstado

        #region GetTotalPorClienteEstado

        /// <summary>
        /// Gets the total por cliente estado.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <returns></returns>
        public DataTable GetTotalPorClienteEstado(decimal persona_id)
        {
            DataTable dt =GetCuentaCorrienteChequesRecibidosPorPersona(persona_id);
            DataTable dtEstados;
            DataTable dtMontoPorMoneda;
            DataTable dtMonedas = new DataTable();
            DataTable dtResumen = new DataTable();

            using (SessionService sesion = new SessionService())
            {
                dtEstados = sesion.Db.ObtenerDistintos(new string[] { CuentaCorrienteChequesRecibidosService.VistaEstadoNombre_NombreCol, CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol }, dt);
                dtMonedas = sesion.Db.ObtenerDistintos(new string[] { CuentaCorrienteChequesRecibidosService.VistaMonedaNombre_NombreCol, CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol }, dt);


                //Se agregan las columnas estáticas
                dtResumen.Columns.Add(CuentaCorrienteChequesRecibidosService.VistaEstadoNombre_NombreCol, typeof(string));

                //Agregamos la cantidad de columnas dependiendo de la cantidad de monedas existentes
                for (int i = 0; i < dtMonedas.Rows.Count; i++)
                {
                    dtResumen.Columns.Add(dtMonedas.Rows[i][CuentaCorrienteChequesRecibidosService.VistaMonedaNombre_NombreCol].ToString(), typeof(string)).DefaultValue = 0;
                    dtResumen.Columns.Add(dtMonedas.Rows[i][CuentaCorrienteChequesRecibidosService.VistaMonedaNombre_NombreCol].ToString() + "_ID", typeof(decimal)).DefaultValue = (decimal)dtMonedas.Rows[i][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol];
                }

                string idEstado = string.Empty;
                DataRow dr;

                for (int i = 0; i < dtEstados.Rows.Count; i++)
                {
                    dr = dtResumen.NewRow();
                    idEstado = dtEstados.Rows[i][CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol].ToString();
                    dtMontoPorMoneda = sesion.Db.CTACTE_CHEQUES_REC_MONTO_PERCollection.GetAsDataTable(CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol + " = " + idEstado + " AND " + CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol + " = " + persona_id, string.Empty);

                    dr[CuentaCorrienteChequesRecibidosService.VistaEstadoNombre_NombreCol] = dtEstados.Rows[i][CuentaCorrienteChequesRecibidosService.VistaEstadoNombre_NombreCol].ToString();

                    for (int j = 0; j < dtMontoPorMoneda.Rows.Count; j++)
                    {
                        dr[dtMontoPorMoneda.Rows[j][CuentaCorrienteChequesRecibidosService.VistaMonedaNombre_NombreCol].ToString()] = (decimal)dtMontoPorMoneda.Rows[j][CuentaCorrienteChequesRecibidosService.SumaMonto_NombreCol];

                    }

                    dtResumen.Rows.Add(dr);
                }

            }
            return dtResumen;
        }
        #endregion GetTotalPorClienteEstado

        #region GetCuentaCorrienteChequesRecibidosPorPersona
        /// <summary>
        /// Gets the cuenta corriente cheques recibidos por persona.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <returns></returns>
        public DataTable GetCuentaCorrienteChequesRecibidosPorPersona(decimal persona_id)
        {
            string where = CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol+"="+persona_id;
            return GetCuentaCorrienteChequesRecibidosInfoCompleta(where, CuentaCorrienteChequesRecibidosService.FechaCreacion_NombreCol);


        }
        #endregion GetCuentaCorrienteChequesRecibidosPorPersona

        #region GetEstado
        /// <summary>
        /// Gets the estado.
        /// </summary>
        /// <param name="cheque_recibido_id">The cheque_recibido_id.</param>
        /// <returns></returns>
        public static decimal GetEstado(decimal cheque_recibido_id, SessionService sesion)
        {
            CTACTE_CHEQUES_RECIBIDOSRow row = sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(cheque_recibido_id);
            return row.CHEQUE_ESTADO_ID;
        }
        #endregion GetEstado

        #region SetFuncionarioAsignado
        /// <summary>
        /// Sets the funcionario asignado.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="funcionario_id">The funcionario_id.</param>
        public void SetFuncionarioAsignado(decimal ctacte_cheque_recibido_id, decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_CHEQUES_RECIBIDOSRow row = sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(ctacte_cheque_recibido_id);
                string valorAnterior = row.ToString();

                if (!funcionario_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    if (!FuncionariosService.EstaActivo(funcionario_id))
                        throw new Exception("El funcionario no se encuentra activo.");

                    row.FUNCIONARIO_ASIGNADO_ID = funcionario_id;
                }
                else
                {
                    row.IsFUNCIONARIO_ASIGNADO_IDNull = true;
                }

                sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
        }
        #endregion SetFuncionarioAsignado

        #region ParaDepositoPorDepositoBancario
        /// <summary>
        /// Paras the deposito por deposito bancario.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="deposito_bancario_id">The deposito_bancario_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void ParaDepositoPorDepositoBancario(decimal ctacte_cheque_recibido_id, decimal deposito_bancario_id, SessionService sesion)
        {
            DataTable dtDeposito = sesion.Db.DEPOSITOS_BANCARIOSCollection.GetAsDataTable(DepositosBancariosService.Id_NombreCol + " = " + deposito_bancario_id, string.Empty);
            CTACTE_CHEQUES_RECIBIDOSRow row = sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(ctacte_cheque_recibido_id);
            string valorAnterior = row.ToString();

            row.DEPOSITO_BANCARIO_ID = deposito_bancario_id;
            row.FECHA_COBRO = (DateTime)dtDeposito.Rows[0][DepositosBancariosService.Fecha_NombreCol];

            sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            CuentaCorrienteChequesRecibidosService.CambiarEstado(ctacte_cheque_recibido_id, (decimal)dtDeposito.Rows[0][DepositosBancariosService.CasoId_NombreCol], Definiciones.CuentaCorrienteChequesEstados.ParaDeposito, sesion, false, Definiciones.Error.Valor.EnteroPositivo);
        }
        #endregion ParaDepositoPorDepositoBancario

        #region DepositadoPorDepositoBancario
        /// <summary>
        /// Depositadoes the por deposito bancario.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="deposito_bancario_id">The deposito_bancario_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void DepositadoPorDepositoBancario(decimal ctacte_cheque_recibido_id, decimal deposito_bancario_id, SessionService sesion)
        {
            DataTable dtDeposito = sesion.Db.DEPOSITOS_BANCARIOSCollection.GetAsDataTable(DepositosBancariosService.Id_NombreCol + " = " + deposito_bancario_id, string.Empty);
            CuentaCorrienteChequesRecibidosService.CambiarEstado(ctacte_cheque_recibido_id, (decimal)dtDeposito.Rows[0][DepositosBancariosService.CasoId_NombreCol], Definiciones.CuentaCorrienteChequesEstados.Depositado, sesion, false, Definiciones.Error.Valor.EnteroPositivo);
        }
        #endregion DepositadoPorDepositoBancario

        #region DeshacerDepositadoPorDepositoBancario
        /// <summary>
        /// Deshacers the depositado por deposito bancario.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void DeshacerParaDepositoPorDepositoBancario(decimal ctacte_cheque_recibido_id, SessionService sesion)
        {
            CTACTE_CHEQUES_RECIBIDOSRow row = sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(ctacte_cheque_recibido_id);
            string valorAnterior = row.ToString();

            row.IsDEPOSITO_BANCARIO_IDNull = true;
            row.IsFECHA_COBRONull = true;

            sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            decimal estadoDestino = DateTime.Parse(row.FECHA_VENCIMIENTO.ToShortDateString()) > DateTime.Parse(DateTime.Now.ToShortDateString()) ? Definiciones.CuentaCorrienteChequesEstados.Adelantado : Definiciones.CuentaCorrienteChequesEstados.AlDia;

            CuentaCorrienteChequesRecibidosService.CambiarEstado(ctacte_cheque_recibido_id, Definiciones.Error.Valor.EnteroPositivo, estadoDestino, sesion, false, Definiciones.Error.Valor.EnteroPositivo);
        }
        #endregion DeshacerDepositadoPorDepositoBancario

        #region CustodiadoPorCustodiaDeValores
        /// <summary>
        /// Custodiadoes the por custodia de valores.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="custodia_valores_id">The custodia_valores_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void CustodiadoPorCustodiaDeValores(decimal ctacte_cheque_recibido_id, decimal custodia_valores_id, SessionService sesion)
        {
            CTACTE_CHEQUES_RECIBIDOSRow row = sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(ctacte_cheque_recibido_id);
            string valorAnterior = row.ToString();
            row.CUSTODIA_VALORES_ID = custodia_valores_id;
            sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            CuentaCorrienteChequesRecibidosService.CambiarEstado(ctacte_cheque_recibido_id, Definiciones.Error.Valor.EnteroPositivo, Definiciones.CuentaCorrienteChequesEstados.Custodia, sesion, false, Definiciones.Error.Valor.EnteroPositivo);
            
        }
        #endregion DepositadoPorDepositoBancario

        #region CanjeadoPorCanjeDeValores
        /// <summary>
        /// Canjeadoes the por canje de valores.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="canje_valor_id">The canje_valor_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void CanjeadoPorCanjeDeValores(decimal ctacte_cheque_recibido_id, decimal canje_valor_id, SessionService sesion)
        {
            CTACTE_CHEQUES_RECIBIDOSRow row = sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(ctacte_cheque_recibido_id);
            string valorAnterior = row.ToString();

            sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion CanjeadoPorCanjeDeValores

        #region RetiradoDeCustodiaPorCustodiaDeValores
        /// <summary>
        /// Retiradoes the de custodia por custodia de valores.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="custodia_valores_id">The custodia_valores_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void RetiradoDeCustodiaPorCustodiaDeValores(decimal ctacte_cheque_recibido_id, decimal custodia_valores_id, SessionService sesion)
        {
            CTACTE_CHEQUES_RECIBIDOSRow row = sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(ctacte_cheque_recibido_id);
            string valorAnterior = row.ToString();

            row.IsCUSTODIA_VALORES_IDNull = true;

            sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            decimal estadoDestino = row.FECHA_VENCIMIENTO >DateTime.Parse(DateTime.Now.ToShortDateString())? Definiciones.CuentaCorrienteChequesEstados.Adelantado : Definiciones.CuentaCorrienteChequesEstados.AlDia;

            CuentaCorrienteChequesRecibidosService.CambiarEstado(ctacte_cheque_recibido_id, Definiciones.Error.Valor.EnteroPositivo, estadoDestino, sesion, false, Definiciones.Error.Valor.EnteroPositivo);


        }
        #endregion RetiradoDeCustodiaPorCustodiaDeValores

        #region DeshacerCustodiadoPorCustodiaDeValores
        /// <summary>
        /// Deshacers the custodiado por custodia de valores.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void DeshacerCustodiadoPorCustodiaDeValores(decimal ctacte_cheque_recibido_id, SessionService sesion)
        {
            CTACTE_CHEQUES_RECIBIDOSRow row = sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(ctacte_cheque_recibido_id);
            string valorAnterior = row.ToString();

            sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);


            decimal estadoDestino = row.FECHA_VENCIMIENTO > DateTime.Parse(DateTime.Now.ToShortDateString()) ? Definiciones.CuentaCorrienteChequesEstados.Adelantado : Definiciones.CuentaCorrienteChequesEstados.AlDia;

            CuentaCorrienteChequesRecibidosService.CambiarEstado(ctacte_cheque_recibido_id, Definiciones.Error.Valor.EnteroPositivo, estadoDestino, sesion, false, Definiciones.Error.Valor.EnteroPositivo);
        }
        #endregion DeshacerCustodiadoPorCustodiaDeValores

        #region NegociadoPorDescuentoDeDocumentos
        /// <summary>
        /// Negociadoes the por descuento de documentos.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="descuento_documentos_id">The descuento_documentos_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void NegociadoPorDescuentoDeDocumentos(decimal ctacte_cheque_recibido_id, decimal descuento_documentos_id, SessionService sesion)
        {
            CTACTE_CHEQUES_RECIBIDOSRow row = sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(ctacte_cheque_recibido_id);
            string valorAnterior = row.ToString();
            row.DESCUENTO_DOCUMENTOS_ID = descuento_documentos_id;
            sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            CuentaCorrienteChequesRecibidosService.CambiarEstado(ctacte_cheque_recibido_id, Definiciones.Error.Valor.EnteroPositivo, Definiciones.CuentaCorrienteChequesEstados.Negociado, sesion, false, Definiciones.Error.Valor.EnteroPositivo);
        }
        #endregion NegociadoPorDescuentoDeDocumentos

        #region DeshacerNegociadoPorDescuentoDeDocumentos
        /// <summary>
        /// Deshacers the negociado por descuento de documentos.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void DeshacerNegociadoPorDescuentoDeDocumentos(decimal ctacte_cheque_recibido_id, SessionService sesion)
        {
            CTACTE_CHEQUES_RECIBIDOSRow row = sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(ctacte_cheque_recibido_id);
            string valorAnterior = row.ToString();

            sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            decimal estadoDestino = row.FECHA_VENCIMIENTO > DateTime.Parse(DateTime.Now.ToShortDateString()) ? Definiciones.CuentaCorrienteChequesEstados.Adelantado : Definiciones.CuentaCorrienteChequesEstados.AlDia;

            CuentaCorrienteChequesRecibidosService.CambiarEstado(ctacte_cheque_recibido_id, Definiciones.Error.Valor.EnteroPositivo, estadoDestino, sesion, false, Definiciones.Error.Valor.EnteroPositivo);
        }
        #endregion DeshacerNegociadoPorDescuentoDeDocumentos

        #region Efectivizar
        /// <summary>
        /// Efectivizars the specified ctacte_cheque_recibido_id.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        public void Efectivizar(decimal ctacte_cheque_recibido_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = this.GetCuentaCorrienteChequesRecibidosInfoCompleta(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + ctacte_cheque_recibido_id, string.Empty);

                if (dt.Rows.Count <= 0)
                    throw new Exception("Error en CuentacorrienteChequesRecibidosService.Efectivizar(). No se encontró el cheque.");

                //Dar egreso al cheque
                CuentaCorrienteCajasTesoreriaMovimientosService.Egreso((decimal)dt.Rows[0][CuentaCorrienteChequesRecibidosService.VistaCtacteCajaTesorereiaId_NombreCol],
                                               Definiciones.Error.Valor.IntPositivo,
                                               CuentaCorrienteChequesRecibidosService.Nombre_Tabla,
                                               Definiciones.Error.Valor.EnteroPositivo,
                                               Definiciones.Error.Valor.EnteroPositivo, 
                                               Definiciones.CuentaCorrienteValores.Cheque,
                                               (decimal)dt.Rows[0][CuentaCorrienteChequesRecibidosService.Id_NombreCol],
                                               (decimal)dt.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol],
                                               (decimal)dt.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol],
                                               (decimal)dt.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol],
                                               DateTime.Now,
                                               sesion);

                //Marcar el chque como efectivizado
                CuentaCorrienteChequesRecibidosService.CambiarEstado(ctacte_cheque_recibido_id, Definiciones.Error.Valor.EnteroPositivo, Definiciones.CuentaCorrienteChequesEstados.Efectivizado, sesion, false, Definiciones.Error.Valor.EnteroPositivo);

                //Dar ingreso al efectivo
                CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2((decimal)dt.Rows[0][CuentaCorrienteChequesRecibidosService.VistaCtacteCajaTesorereiaId_NombreCol],
                                               Definiciones.Error.Valor.IntPositivo,
                                               CuentaCorrienteChequesRecibidosService.Nombre_Tabla,
                                               Definiciones.Error.Valor.EnteroPositivo,
                                               Definiciones.Error.Valor.EnteroPositivo,
                                               Definiciones.CuentaCorrienteValores.Efectivo,
                                               Definiciones.Error.Valor.EnteroPositivo,
                                               (decimal)dt.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol],
                                               (decimal)dt.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol],
                                               (decimal)dt.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol],
                                               DateTime.Now,
                                               sesion);
            }
        }
        #endregion Efectivizar

        #region Rechazar

        public static void Rechazar(decimal ctacte_cheque_recibido_id, decimal texto_predefinido_id) 
        {
            using (SessionService sesion = new SessionService()) {
                //Marcar el cheque como rechazado
                CambiarEstado(ctacte_cheque_recibido_id, Definiciones.Error.Valor.EnteroPositivo, Definiciones.CuentaCorrienteChequesEstados.Rechazado, sesion, false, texto_predefinido_id);
            }
        }

        #endregion Rechazar

        #region UtilizadoPorFlujo
        /// <summary>
        /// Utilizadoes the por flujo.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void UtilizadoPorFlujo (decimal ctacte_cheque_recibido_id, SessionService sesion)
        {
           
            CTACTE_CHEQUES_RECIBIDOSRow row = sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(ctacte_cheque_recibido_id);

            //Se controla que no se haya realizado otra accion anterior con el cheque
            if (row.CHEQUE_ESTADO_ID != Definiciones.CuentaCorrienteChequesEstados.AlDia && row.CHEQUE_ESTADO_ID != Definiciones.CuentaCorrienteChequesEstados.Adelantado)
                    throw new Exception("El cheque no puede ser utilizado ya que se encuentra en estado " + CuentaCorrienteChequesEstadosService.GetNombre(row.CHEQUE_ESTADO_ID) + ".");

            CuentaCorrienteChequesRecibidosService.CambiarEstado(ctacte_cheque_recibido_id, Definiciones.Error.Valor.EnteroPositivo, Definiciones.CuentaCorrienteChequesEstados.Utilizado, sesion, false, Definiciones.Error.Valor.EnteroPositivo);
        }
        #endregion UtilizadoPorFlujo

        #region DeshacerUtilizadoPorFlujo
        /// <summary>
        /// Deshacers the utilizado por flujo.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void DeshacerUtilizadoPorFlujo(decimal ctacte_cheque_recibido_id, decimal caso_id,SessionService sesion)
        {
            //Se verifica la fecha de vencimiento
            decimal estadoDestino = Definiciones.Error.Valor.EnteroPositivo;
            if (GetEstado(ctacte_cheque_recibido_id, sesion).Equals(Definiciones.CuentaCorrienteChequesEstados.Rechazado))
                estadoDestino = Definiciones.CuentaCorrienteChequesEstados.Rechazado;
            else
                estadoDestino = GetFechaVencimiento(ctacte_cheque_recibido_id, sesion) > DateTime.Parse(DateTime.Now.ToShortDateString()) ? Definiciones.CuentaCorrienteChequesEstados.Adelantado : Definiciones.CuentaCorrienteChequesEstados.AlDia;
            CuentaCorrienteChequesRecibidosService.CambiarEstado(ctacte_cheque_recibido_id, caso_id, estadoDestino, sesion, false, Definiciones.Error.Valor.EnteroPositivo);
        }
        #endregion DeshacerUtilizadoPorFlujo

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="sesion">The sesion.</param>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                CTACTE_CHEQUES_RECIBIDOSRow row = new CTACTE_CHEQUES_RECIBIDOSRow();
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cheques_recibidos_sqc");
                    row.ESTADO = Definiciones.Estado.Activo;
                    row.FECHA_CREACION = DateTime.Now;
                    
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }
                else
                {
                    row = sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetRow(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + campos[CuentaCorrienteChequesRecibidosService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                row.COTIZACION_MONEDA = (decimal)campos[CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol];
                if(campos.Contains(FechaCreacion_NombreCol)) row.FECHA_CREACION= DateTime.Parse(campos[FechaCreacion_NombreCol].ToString());
                //Si cambia, se controla que la nueva se encuentre activa
                if (!row.CTACTE_BANCO_ID.Equals((decimal)campos[CuentaCorrienteChequesRecibidosService.CtacteBancoId_NombreCol]))
                {
                    if (!CuentaCorrienteBancosService.EstaActivo((decimal)campos[CuentaCorrienteChequesRecibidosService.CtacteBancoId_NombreCol]))
                    {
                        throw new System.Exception("El banco se encuentra inactivo.");
                    }
                    else
                    {
                        row.CTACTE_BANCO_ID = (decimal)campos[CuentaCorrienteChequesRecibidosService.CtacteBancoId_NombreCol];
                    }
                }

                row.CHEQUE_DE_TERCEROS = (string)campos[CuentaCorrienteChequesRecibidosService.ChequeDeTerceros_NombreCol];
                row.ES_DIFERIDO = (string)campos[CuentaCorrienteChequesRecibidosService.EsDiferido_NombreCol];

                if (campos.Contains(CuentaCorrienteChequesRecibidosService.DepositoBancarioId_NombreCol))
                    row.DEPOSITO_BANCARIO_ID = (decimal)campos[CuentaCorrienteChequesRecibidosService.DepositoBancarioId_NombreCol];
                else
                    row.IsDEPOSITO_BANCARIO_IDNull = true;

                if (campos.Contains(CuentaCorrienteChequesRecibidosService.CustodiaValoresId_NombreCol))
                    row.CUSTODIA_VALORES_ID= (decimal)campos[CuentaCorrienteChequesRecibidosService.CustodiaValoresId_NombreCol];
                else
                    row.IsCUSTODIA_VALORES_IDNull = true;

                if (campos.Contains(CuentaCorrienteChequesRecibidosService.DescuentoDocumentosId_NombreCol))
                    row.DESCUENTO_DOCUMENTOS_ID = (decimal)campos[CuentaCorrienteChequesRecibidosService.DescuentoDocumentosId_NombreCol];
                else
                    row.IsDESCUENTO_DOCUMENTOS_IDNull = true;
                
                if (campos.Contains(CuentaCorrienteChequesRecibidosService.NumeroDocumentoEmisor_NombreCol))
                    row.NUMERO_DOCUMENTO_EMISOR = (string)campos[CuentaCorrienteChequesRecibidosService.NumeroDocumentoEmisor_NombreCol];
                else
                    row.NUMERO_DOCUMENTO_EMISOR = string.Empty;

                if (campos.Contains(CuentaCorrienteChequesRecibidosService.FuncionarioAsignadoId_NombreCol))
                {
                    if (campos[CuentaCorrienteChequesRecibidosService.FuncionarioAsignadoId_NombreCol] != DBNull.Value)
                        row.FUNCIONARIO_ASIGNADO_ID = (decimal)campos[CuentaCorrienteChequesRecibidosService.FuncionarioAsignadoId_NombreCol];
                    else
                        row.IsFUNCIONARIO_ASIGNADO_IDNull = true;
                }
                
                if (campos.Contains(CuentaCorrienteChequesRecibidosService.FechaCobro_NombreCol))
                    row.FECHA_COBRO = (DateTime)campos[CuentaCorrienteChequesRecibidosService.FechaCobro_NombreCol];
                else
                    row.IsFECHA_COBRONull = true;

                row.FECHA_POSDATADO = (DateTime)campos[CuentaCorrienteChequesRecibidosService.FechaPosdatado_NombreCol];
                
                if (campos.Contains(CuentaCorrienteChequesRecibidosService.FechaRechazado_NombreCol))
                    row.FECHA_RECHAZO = (DateTime)campos[CuentaCorrienteChequesRecibidosService.FechaRechazado_NombreCol];
                else
                    row.IsFECHA_RECHAZONull = true;

                row.FECHA_VENCIMIENTO = (DateTime)campos[CuentaCorrienteChequesRecibidosService.FechaVencimiento_NombreCol];

                row.CHEQUE_ESTADO_ID = row.FECHA_VENCIMIENTO.Date > DateTime.Now.Date ? Definiciones.CuentaCorrienteChequesEstados.Adelantado : Definiciones.CuentaCorrienteChequesEstados.AlDia;
                
                //Si cambia, se controla que la nueva se encuentre activa
                if (!row.MONEDA_ID.Equals((decimal)campos[CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]))
                {
                    if (!MonedasService.EstaActivo((decimal)campos[CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]))
                    {
                        throw new System.Exception("La moneda se encuentra inactiva.");
                    }
                    else
                    {
                        row.MONEDA_ID = (decimal)campos[CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol];
                    }
                }

                row.MONTO = (decimal)campos[CuentaCorrienteChequesRecibidosService.Monto_NombreCol];

                if (campos.Contains(CuentaCorrienteChequesRecibidosService.MotivoRechazo_NombreCol))
                    row.MOTIVO_RECHAZO = (string)campos[CuentaCorrienteChequesRecibidosService.MotivoRechazo_NombreCol];

                //NOMBRE_BENEFICIARIO
                if (campos[CuentaCorrienteChequesRecibidosService.NombreBeneficiario_NombreCol] == System.DBNull.Value)
                    row.NOMBRE_BENEFICIARIO = string.Empty;
                else
                    row.NOMBRE_BENEFICIARIO = (string)campos[CuentaCorrienteChequesRecibidosService.NombreBeneficiario_NombreCol];

                //NOMBRE_EMISOR
                if (campos[CuentaCorrienteChequesRecibidosService.NombreEmisor_NombreCol] == System.DBNull.Value)
                    row.NOMBRE_EMISOR = string.Empty;
                else
                    row.NOMBRE_EMISOR = (string)campos[CuentaCorrienteChequesRecibidosService.NombreEmisor_NombreCol];

                //NUMERO_CHEQUE
                if (campos[CuentaCorrienteChequesRecibidosService.NumeroCheque_NombreCol] == System.DBNull.Value)
                    row.NUMERO_CHEQUE = string.Empty;
                else
                    row.NUMERO_CHEQUE = (string)campos[CuentaCorrienteChequesRecibidosService.NumeroCheque_NombreCol];

                //NUMERO_CUENTA
                if (campos[CuentaCorrienteChequesRecibidosService.NumeroCuenta_NombreCol] == System.DBNull.Value)
                    row.NUMERO_CUENTA = string.Empty;
                else
                    row.NUMERO_CUENTA = (string)campos[CuentaCorrienteChequesRecibidosService.NumeroCuenta_NombreCol];
                
                if (campos.Contains(CuentaCorrienteChequesRecibidosService.CasoCreadorId_NombreCol))
                {
                    row.CASO_CREADOR_ID = (decimal)campos[CuentaCorrienteChequesRecibidosService.CasoCreadorId_NombreCol];
                }
                else
                {
                    row.IsCASO_CREADOR_IDNull = true;
                }
                
                if (insertarNuevo) sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.Insert(row);
                else sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                decimal casoCreador = row.IsCASO_CREADOR_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.CASO_CREADOR_ID;
                
                decimal estadoDestino = row.FECHA_VENCIMIENTO > DateTime.Parse(DateTime.Now.ToShortDateString()) ? Definiciones.CuentaCorrienteChequesEstados.Adelantado : Definiciones.CuentaCorrienteChequesEstados.AlDia;

                CuentaCorrienteChequesRecibidosService.CambiarEstado(row.ID, casoCreador, estadoDestino, sesion, insertarNuevo, Definiciones.Error.Valor.EnteroPositivo);

                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal ctacte_cheque_recibido_id, SessionService sesion)
        {
            CTACTE_CHEQUES_RECIBIDOSRow row = sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(ctacte_cheque_recibido_id);
            string valorAnterior = row.ToString();

            if (!row.CHEQUE_ESTADO_ID.Equals(Definiciones.CuentaCorrienteChequesEstados.AlDia) && !row.CHEQUE_ESTADO_ID.Equals(Definiciones.CuentaCorrienteChequesEstados.Adelantado))
                throw new Exception("Error al Borrar el Cheque. Verifque el estado. \n Los cheques solo pueden ser Borrados en el estado Al DIA y ADELANTADO. \n El estado actual del Cheque es: " + CuentaCorrienteChequesEstadosService.GetNombre(row.CHEQUE_ESTADO_ID));

            row.ESTADO = Definiciones.Estado.Inactivo;
            row.NUMERO_CHEQUE += "-" + row.ID;

            sesion.db.CTACTE_CHEQUES_RECIBIDOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion Borrar
        
        #region CambiarEstado
        /// <summary>
        /// Cambiars the estado.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_destino">The estado_destino.</param>
        /// <param name="sesion">The sesion.</param>
        public static void CambiarEstado(decimal ctacte_cheque_recibido_id, decimal caso_id, decimal estado_destino, SessionService sesion, bool esNuevo, decimal texto_predefinido_id)
        {
            CTACTE_CHEQUES_RECIBIDOSRow row = sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(ctacte_cheque_recibido_id);
            string valorAnterior = row.ToString();
            decimal estadoAnterior = row.CHEQUE_ESTADO_ID;
            if (esNuevo) { estadoAnterior = Definiciones.Error.Valor.EnteroPositivo; }

            row.CHEQUE_ESTADO_ID = estado_destino;

            // Se actualiza el estado del cheque
            sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.Update(row);

            //se guarda el movimiento
            Hashtable campos = new Hashtable();
            campos.Add(CuentaCorrienteChequesMovimientosService.CtaCteChequeRecibidoId_NombreCol, row.ID);

            if (estadoAnterior != Definiciones.Error.Valor.EnteroPositivo) { campos.Add(CuentaCorrienteChequesMovimientosService.EstadoOriginalId_NombreCol, estadoAnterior); }

            campos.Add(CuentaCorrienteChequesMovimientosService.EstadoDestinoId_NombreCol, row.CHEQUE_ESTADO_ID);

            if (caso_id != Definiciones.Error.Valor.EnteroPositivo) { campos.Add(CuentaCorrienteChequesMovimientosService.CasoIdId_NombreCol, caso_id); }

            if (texto_predefinido_id != Definiciones.Error.Valor.EnteroPositivo) { campos.Add(CuentaCorrienteChequesMovimientosService.TextoPredefinidoId_NombreCol, texto_predefinido_id); }

            (new CuentaCorrienteChequesMovimientosService()).Guardar(campos, sesion);

            //se guarda el log
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            //Crear asiento automatico por cambio de estado en cheque
            Contabilidad.GenerarAsientosEntidades.AsientosChequesRecibidosCambioEstado.AsentarCambioEstado(ctacte_cheque_recibido_id, estadoAnterior, row.CHEQUE_ESTADO_ID, sesion.SucursalActiva.PAIS_ID, sesion);
        }
        #endregion CambiarEstado

        #region CambiarFecha
        public static void CambiarFecha(decimal ctacte_cheque_recibido_id, DateTime fecha_posdatado, DateTime fecha_vencimiento)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_CHEQUES_RECIBIDOSRow row = sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(ctacte_cheque_recibido_id);
                string valorAnterior = row.ToString();

                if (fecha_vencimiento < fecha_posdatado)
                    throw new Exception("La fecha de vencimiento no puede sar anterior a la de confección.");

                row.FECHA_POSDATADO = fecha_posdatado;
                row.FECHA_VENCIMIENTO = fecha_vencimiento;

                sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
        }
        #endregion CambiarFecha

        #region GetFechaVencimiento
        /// <summary>
        /// Gets the fecha vencimiento.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <returns></returns>
        private DateTime GetFechaVencimiento(decimal ctacte_cheque_recibido_id, SessionService sesion)
        {
            return sesion.Db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(ctacte_cheque_recibido_id).FECHA_VENCIMIENTO;
        }
        #endregion GetFechaVencimiento

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_CHEQUES_RECIBIDOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "CTACTE_CHEQUES_REC_INFO_COMPL"; }
        }
        public static string ChequeDeTerceros_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.CHEQUE_DE_TERCEROSColumnName; }
        }
        public static string SumaMonto_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_MONTOCollection.MONTOColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteBancoId_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.CTACTE_BANCO_IDColumnName; }
        }
        public static string CustodiaValoresId_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.CUSTODIA_VALORES_IDColumnName; }
        }
        public static string DepositoBancarioId_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.DEPOSITO_BANCARIO_IDColumnName; }
        }
        public static string DescuentoDocumentosId_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.DESCUENTO_DOCUMENTOS_IDColumnName; }
        }
        public static string EstadoChequeId_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.CHEQUE_ESTADO_IDColumnName; }
        }
        public static string EsDiferido_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.ES_DIFERIDOColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.ESTADOColumnName; }
        }
        public static string FechaCobro_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.FECHA_COBROColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.FECHA_CREACIONColumnName; }
        }
        public static string FechaPosdatado_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.FECHA_POSDATADOColumnName; }
        }
        public static string FechaRechazado_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.FECHA_RECHAZOColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string FuncionarioAsignadoId_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.FUNCIONARIO_ASIGNADO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.MONTOColumnName; }
        }
        public static string MotivoRechazo_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.MOTIVO_RECHAZOColumnName; }
        }
        public static string NombreBeneficiario_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string NombreEmisor_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.NOMBRE_EMISORColumnName; }
        }
        public static string NumeroCheque_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.NUMERO_CHEQUEColumnName; }
        }
        public static string NumeroCuenta_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.NUMERO_CUENTAColumnName; }
        }
        public static string NumeroDocumentoEmisor_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.NUMERO_DOCUMENTO_EMISORColumnName; }
        }
        public static string CasoCreadorId_NombreCol
        {
            get { return CTACTE_CHEQUES_RECIBIDOSCollection.CASO_CREADOR_IDColumnName; }
        }
        public static string VistaCtacteCajaTesorereiaId_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.CTACTE_CAJA_TESORERIA_IDColumnName; }
        }
        public static string VistaCtacteCajaTesorereiaNombre_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.CTACTE_CAJA_TESORERIA_NOMBREColumnName; }
        }
        public static string VistaEstadoNombre_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.ESTADO_CHEQUEColumnName; }
        }
        public static string VistaBancoEntidaId_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.BANCO_ENTIDADColumnName; }
        }
        public static string VistaFuncionarioAsignadoNombre_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.FUNCIONARIO_ASIGNADO_NOMBREColumnName; }
        }
        public static string VistaPersonaId_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.PERSONA_IDColumnName; }
        }
        public static string VistaProveedorId_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.PROVEEDOR_IDColumnName; }
        }
        public static string VistaBancoAbreviatura_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.BANCO_ABREVIATURAColumnName; }
        }
        public static string VistaBancoCodigo_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.BANCO_CODIGOColumnName; }
        }
        public static string VistaBancoNombre_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.BANCO_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.MONEDAS_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.MONEDAS_SIMBOLOColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaProveedorRazonSocial_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.PROVEEDOR_RAZON_SOCIALColumnName; }
        }
        public static string VistaDatosResumidosSinMonto_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.DATOS_RESUMIDOS_SIN_MONTOColumnName; }
        }
        public static string VistaEstadoAbreviado_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.ESTADO_ABREVIADOColumnName; }
        }
        public static string VistaCantidadesDecimalesMoneda_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.CANTIDADES_DECIMALESColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalId_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaPersonaCodigo_NombreCol
        {
            get { return CTACTE_CHEQUES_REC_INFO_COMPLCollection.PERSONA_CODIGOColumnName; }
        }
                
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static CuentaCorrienteChequesRecibidosService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new CuentaCorrienteChequesRecibidosService(e.RegistroId, sesion);
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
        protected CTACTE_CHEQUES_RECIBIDOSRow row;
        protected CTACTE_CHEQUES_RECIBIDOSRow rowSinModificar;
        public class Modelo : CTACTE_CHEQUES_RECIBIDOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? CasoCreadorId { get { if (row.IsCASO_CREADOR_IDNull) return null; else return row.CASO_CREADOR_ID; } set { if (value.HasValue) row.CASO_CREADOR_ID = value.Value; else row.IsCASO_CREADOR_IDNull = true; } }
        public string ChequeDeTerceros { get { return ClaseCBABase.GetStringHelper(row.CHEQUE_DE_TERCEROS); } set { row.CHEQUE_DE_TERCEROS = value; } }
        public decimal? ChequeEstadoId { get { if (row.IsCHEQUE_ESTADO_IDNull) return null; else return row.CHEQUE_ESTADO_ID; } set { if (value.HasValue) row.CHEQUE_ESTADO_ID = value.Value; else row.IsCHEQUE_ESTADO_IDNull = true; } }
        public decimal CotizacionMoneda { get { return row.COTIZACION_MONEDA; } set { row.COTIZACION_MONEDA = value; } }
        public decimal CtacteBancoId { get { return row.CTACTE_BANCO_ID; } set { row.CTACTE_BANCO_ID = value; } }
        public decimal? CustodiaValoresId { get { if (row.IsCUSTODIA_VALORES_IDNull) return null; else return row.CUSTODIA_VALORES_ID; } set { if (value.HasValue) row.CUSTODIA_VALORES_ID = value.Value; else row.IsCUSTODIA_VALORES_IDNull = true; } }
        public decimal? DepositoBancarioId { get { if (row.IsDEPOSITO_BANCARIO_IDNull) return null; else return row.DEPOSITO_BANCARIO_ID; } set { if (value.HasValue) row.DEPOSITO_BANCARIO_ID = value.Value; else row.IsDEPOSITO_BANCARIO_IDNull = true; } }
        public decimal? DescuentoDocumentoId { get { if (row.IsDESCUENTO_DOCUMENTOS_IDNull) return null; else return row.DESCUENTO_DOCUMENTOS_ID; } set { if (value.HasValue) row.DESCUENTO_DOCUMENTOS_ID = value.Value; else row.IsDESCUENTO_DOCUMENTOS_IDNull = true; } }
        public string EsDiferido { get { return ClaseCBABase.GetStringHelper(row.ES_DIFERIDO); } set { row.ES_DIFERIDO = value; } }
        public string Estado { get { return ClaseCBABase.GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public string EstudioJuridico { get { return ClaseCBABase.GetStringHelper(row.ESTUDIO_JURIDICO); } set { row.ESTUDIO_JURIDICO = value; } }
        public DateTime? FechaCobro { get { if (row.IsFECHA_COBRONull) return null; else return row.FECHA_COBRO; } set { if (value.HasValue) row.FECHA_COBRO = value.Value; else row.IsFECHA_COBRONull = true; } }
        public DateTime FechaCreacion { get { return row.FECHA_CREACION; } set { row.FECHA_CREACION = value; } }
        public DateTime FechaPosdatado { get { return row.FECHA_POSDATADO; } set { row.FECHA_POSDATADO = value; } }
        public DateTime? FechaRechazo { get { if (row.IsFECHA_RECHAZONull) return null; else return row.FECHA_RECHAZO; } set { if (value.HasValue) row.FECHA_RECHAZO = value.Value; else row.IsFECHA_RECHAZONull = true; } }
        public DateTime FechaVencimiento { get { return row.FECHA_VENCIMIENTO; } set { row.FECHA_VENCIMIENTO = value; } }
        public decimal? FuncionarioAsignadoId { get { if (row.IsFUNCIONARIO_ASIGNADO_IDNull) return null; else return row.FUNCIONARIO_ASIGNADO_ID; } set { if (value.HasValue) row.FUNCIONARIO_ASIGNADO_ID = value.Value; else row.IsFUNCIONARIO_ASIGNADO_IDNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal Monto { get { return row.MONTO; } set { row.MONTO = value; } }
        public string MotivoRechazo { get { return ClaseCBABase.GetStringHelper(row.MOTIVO_RECHAZO); } set { row.MOTIVO_RECHAZO = value; } }
        public string NombreBeneficiario { get { return ClaseCBABase.GetStringHelper(row.NOMBRE_BENEFICIARIO); } set { row.NOMBRE_BENEFICIARIO = value; } }
        public string NombreEmisor { get { return ClaseCBABase.GetStringHelper(row.NOMBRE_EMISOR); } set { row.NOMBRE_EMISOR = value; } }
        public string NumeroCheque { get { return ClaseCBABase.GetStringHelper(row.NUMERO_CHEQUE); } set { row.NUMERO_CHEQUE = value; } }
        public string NumeroCuenta { get { return ClaseCBABase.GetStringHelper(row.NUMERO_CUENTA); } set { row.NUMERO_CUENTA = value; } }
        public string NumeroCuentaEmisor { get { return ClaseCBABase.GetStringHelper(row.NUMERO_DOCUMENTO_EMISOR); } set { row.NUMERO_DOCUMENTO_EMISOR = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CasosService _caso_creador;
        public CasosService CasoCreador
        {
            get
            {
                if (this._caso_creador == null)
                    this._caso_creador = new CasosService(this.CasoCreadorId.Value);
                return this._caso_creador;
            }
        }

        private CuentaCorrienteBancosService _ctacte_banco;
        public CuentaCorrienteBancosService CtacteBanco
        {
            get
            {
                if (this._ctacte_banco == null)
                    this._ctacte_banco = new CuentaCorrienteBancosService(this.CtacteBancoId);
                return this._ctacte_banco;
            }
        }

        private DepositosBancariosService _deposito_bancario;
        public DepositosBancariosService DepositoBancario
        {
            get
            {
                if (this._deposito_bancario == null)
                    this._deposito_bancario = new DepositosBancariosService(this.DepositoBancarioId.Value);
                return this._deposito_bancario;
            }
        }

        private FuncionariosService _funcionario_asignado;
        public FuncionariosService FuncionarioAsignado
        {
            get
            {
                if (this._funcionario_asignado == null)
                    this._funcionario_asignado = new FuncionariosService(this.FuncionarioAsignadoId.Value);
                return this._funcionario_asignado;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                    this._moneda = new MonedasService(this.MonedaId);
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
                this.row = sesion.db.CTACTE_CHEQUES_RECIBIDOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_CHEQUES_RECIBIDOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(CTACTE_CHEQUES_RECIBIDOSRow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CuentaCorrienteChequesRecibidosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrienteChequesRecibidosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CuentaCorrienteChequesRecibidosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public CuentaCorrienteChequesRecibidosService(EdiCBA.ChequeRecibido edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = CuentaCorrienteChequesRecibidosService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            if (edi.caso_creador_id.HasValue)
                this.CasoCreadorId = edi.caso_creador_id.Value;
            this.ChequeDeTerceros = edi.cheque_de_terceros ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
            this.ChequeEstadoId = edi.cheque_estado;

            if (edi.cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion'.");
            this.CotizacionMoneda = edi.cotizacion.venta;
            
            #region ctacte banco
            if (!string.IsNullOrEmpty(edi.banco_uuid))
                this._ctacte_banco = CuentaCorrienteBancosService.GetPorUUID(edi.banco_uuid, sesion);
            if (this._ctacte_banco == null && edi.banco != null)
                this._ctacte_banco = new CuentaCorrienteBancosService(edi.banco, almacenar_localmente, sesion);
            if (this._ctacte_banco != null)
            {
                if (!this.CtacteBanco.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.CtacteBanco.Id.HasValue)
                    this.CtacteBancoId = this.CtacteBanco.Id.Value;
            }
            #endregion ctacte banco

            //TODO: cuando custodia de valores tenga orientación a objetos
            //this.CustodiaValoresId

            #region deposito bancario
            if (!string.IsNullOrEmpty(edi.deposito_bancario_uuid))
                this._deposito_bancario = DepositosBancariosService.GetPorUUID(edi.deposito_bancario_uuid, sesion);
            if (this._deposito_bancario == null && edi.deposito_bancario != null)
                this._deposito_bancario = new DepositosBancariosService(edi.deposito_bancario, almacenar_localmente, sesion);
            if (this._deposito_bancario != null)
            {
                if (!this.DepositoBancario.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.DepositoBancario.Id.HasValue)
                    this.DepositoBancarioId = this.DepositoBancario.Id.Value;
            }
            #endregion deposito bancario

            //TODO: cuando descuento de documentos tenga orientación a objetos
            //this.DescuentoDocumentoId

            this.EsDiferido = edi.es_diferido ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
            this.Estado = Definiciones.Estado.Activo;
            this.FechaCobro = edi.fecha_cobro;
            this.FechaPosdatado = edi.fecha_emision;
            this.FechaRechazo = edi.fecha_rechazo;
            this.FechaVencimiento = edi.fecha_vencimiento;
            
            #region moneda
            if (!string.IsNullOrEmpty(edi.moneda_uuid))
                this._moneda = MonedasService.GetPorUUID(edi.moneda_uuid, sesion);
            
            if (this._moneda == null)
                throw new Exception("No se encontró el UUID " + edi.moneda_uuid + " ni se definieron los datos del objeto.");

            if (!this.Moneda.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Moneda.Id.HasValue)
                this.MonedaId = this.Moneda.Id.Value;
            #endregion moneda

            this.Monto = edi.monto;
            this.MotivoRechazo = edi.motivo_rechazo;
            this.NombreBeneficiario = edi.nombre_beneficiario;
            this.NombreEmisor = edi.nombre_emisor;
            this.NumeroCheque = edi.numero_cheque;
            this.NumeroCuenta = edi.numero_cuenta;
            this.NumeroCuentaEmisor = edi.numero_cuenta_emisor;
        }
        private CuentaCorrienteChequesRecibidosService(CTACTE_CHEQUES_RECIBIDOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.ChequeRecibido()
            {
                banco_uuid = this.CtacteBanco.GetOrCreateUUID(sesion),
                caso_creador_id = this.CasoCreadorId,
                cheque_de_terceros = this.ChequeDeTerceros == Definiciones.SiNo.Si,
                cheque_estado = (int)this.ChequeEstadoId.Value,
                cotizacion_uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, Modelo.COTIZACION_MONEDAColumnName, this.Id.Value, sesion),
                es_diferido = this.EsDiferido == Definiciones.SiNo.Si,
                fecha_cobro = this.FechaCobro,
                fecha_emision = this.FechaCreacion,
                fecha_rechazo = this.FechaRechazo,
                fecha_vencimiento = this.FechaVencimiento,
                moneda_uuid = this.Moneda.GetOrCreateUUID(sesion),
                monto = this.Monto,
                motivo_rechazo = this.MotivoRechazo,
                nombre_beneficiario = this.NombreBeneficiario,
                nombre_emisor = this.NombreEmisor,
                numero_cheque = this.NumeroCheque,
                numero_cuenta = this.NumeroCuenta,
                numero_cuenta_emisor = this.NumeroCuentaEmisor,
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.banco = (EdiCBA.Banco)this.CtacteBanco.ToEDI(nueva_profundidad, sesion);
                e.cotizacion = new EdiCBA.Cotizacion()
                {
                    uuid = e.cotizacion_uuid,
                    fecha = this.FechaCreacion,
                    moneda_uuid = e.moneda_uuid,
                    venta = this.CotizacionMoneda
                };
                e.moneda = (EdiCBA.Moneda)this.Moneda.ToEDI(nueva_profundidad, sesion);
                
            }

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value);
            }
            return e;
        }
        #endregion ToEDI
        
        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._caso_creador = null;
            this._ctacte_banco = null;
            this._deposito_bancario = null;
            this._funcionario_asignado = null;
            this._moneda = null;
        }
        #endregion ResetearPropiedadesExtendidas
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
