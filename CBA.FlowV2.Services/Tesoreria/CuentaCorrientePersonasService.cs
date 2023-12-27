using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Casos;
using System.Text;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotasCreditoPersona;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrientePersonasService
    {
        #region GetCuentaCorrientePersonasDataTable
        /// <summary>
        /// Gets the cuenta corriente personas data table2.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePersonasDataTable(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return GetCuentaCorrientePersonasDataTable(clausulas, orden, sesion);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        public static DataTable GetCuentaCorrientePersonasDataTable(string clausulas, string orden, SessionService sesion)
        {
            try
            {
                string where = CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas.Length > 0)
                    where += " and " + clausulas;

                return sesion.Db.CTACTE_PERSONASCollection.GetAsDataTable(where, orden);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion GetCuentaCorrientePersonasDataTable

        #region GetCuentaCorrientePersonasInfoCompleta
        /// <summary>
        /// Gets the cuenta corriente personas info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCuentaCorrientePersonasInfoCompleta(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    string where = CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                    if (clausulas.Length > 0)
                        where += " and " + clausulas;

                    return sesion.Db.CTACTE_PERSONAS_INFO_COMPLETACollection.GetAsDataTable(where, orden);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        public static DataTable GetCuentaCorrientePersonasInfoCompleta2(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return GetCuentaCorrientePersonasInfoCompleta2(clausulas, orden, sesion);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        public static DataTable GetCuentaCorrientePersonasInfoCompleta2(string clausulas, string orden, SessionService sesion)
        {
            try
            {
                string where = CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas.Length > 0)
                    where += " and " + clausulas;

                return sesion.Db.CTACTE_PERSONAS_INFO_COMPLETACollection.GetAsDataTable(where, orden);
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetCuentaCorrientePersonasInfoCompleta

        #region GetOrdenadoPorVencimientoDataTable
        public static DataTable GetOrdenadoPorVencimientoDataTable(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetOrdenadoPorVencimientoDataTable(persona_id, string.Empty, sesion);
            }
        }

        public static DataTable GetOrdenadoPorVencimientoDataTable(decimal persona_id, string clausulas_extra, SessionService sesion)
        {
            //Ordenar los vencimientos privilegiando lo contado, para lo cual se le resta 100 anhos
            string sql = "select " + CuentaCorrientePersonasService.Id_NombreCol + ", " +
                         "       " + CuentaCorrientePersonasService.CasoId_NombreCol + ", " +
                         "       " + CuentaCorrientePersonasService.CotizacionMoneda_NombreCol + ", " +
                         "       " + CuentaCorrientePersonasService.VistaObservacion_NombreCol + ", " +
                         "       " + CuentaCorrientePersonasService.VistaSucursalId + ", " +
                         "       " + CuentaCorrientePersonasService.FechaVencimiento_NombreCol + ", " +
                         "       " + CuentaCorrientePersonasService.FechaInsercion_NombreCol + ", " +
                         "       " + CuentaCorrientePersonasService.MonedaId_NombreCol + ", " +
                         "       " + CuentaCorrientePersonasService.VistaMonedaSimbolo_NombreCol + ", " +
                         "       " + CuentaCorrientePersonasService.CuotaNumero_NombreCol + ", " +
                         "       " + CuentaCorrientePersonasService.CuotaTotal_NombreCol + ", " +
                         "       " + CuentaCorrientePersonasService.Credito_NombreCol + ", " +
                         "       " + CuentaCorrientePersonasService.Debito_NombreCol + ", " +
                         "       " + CuentaCorrientePersonasService.VistaSaldoDebito_NombreCol + ", " +
                         "       case when " + CuentaCorrientePersonasService.VistaFacturaClienteTipo_NombreCol + " is null then " + CuentaCorrientePersonasService.FechaVencimiento_NombreCol +
                         "            when " + CuentaCorrientePersonasService.VistaFacturaClienteTipo_NombreCol + " = '" + Definiciones.TipoFactura.Contado + "' then add_months(" + CuentaCorrientePersonasService.FechaVencimiento_NombreCol + ", -1200)" +
                         "            else " + CuentaCorrientePersonasService.FechaVencimiento_NombreCol +
                         "        end columna_orden " +
                         "  from " + CuentaCorrientePersonasService.Nombre_Vista +
                         " where " + CuentaCorrientePersonasService.PersonaId_NombreCol + " = " + persona_id +
                         "   and " + CuentaCorrientePersonasService.Credito_NombreCol + " > " + CuentaCorrientePersonasService.Debito_NombreCol +
                         "   and " + CuentaCorrientePersonasService.CtactePersonaRelacionada_NombreCol + " is null " +
                         "   and " + CuentaCorrientePersonasService.Bloqueado_NombreCol + " = '" + Definiciones.SiNo.No + "' " +
                         "   and " + CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                         "   and (" + CuentaCorrientePersonasService.VistaJuegoPagaresAprobado_NombreCol + " is null or " + CuentaCorrientePersonasService.VistaJuegoPagaresAprobado_NombreCol + " = 'S') ";
            if (clausulas_extra.Length > 0)
                sql += "and (" + clausulas_extra + ")";
            sql += " order by columna_orden";

            return sesion.db.EjecutarQuery(sql);
        }
        #endregion GetOrdenadoPorVencimientoDataTable

        #region GetDeudaALaFechaEnDolares
        /// <summary>
        /// Gets the deuda A la fecha en dolares.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <param name="fecha">The fecha.</param>
        /// <returns></returns>
        public decimal GetDeudaALaFechaEnDolares(decimal persona_id, DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dtCtacte;
                string clausulas;
                decimal total = 0;
                clausulas = CuentaCorrientePersonasService.PersonaId_NombreCol + " = " + persona_id + " and " +
                            CuentaCorrientePersonasService.FechaVencimiento_NombreCol + " <= to_date('" + fecha.ToShortDateString() + "', 'dd/mm/yyyy') ";
                dtCtacte = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(clausulas, CuentaCorrientePersonasService.FechaInsercion_NombreCol);
                for (int i = 0; i < dtCtacte.Rows.Count; i++)
                {
                    total += ((decimal)dtCtacte.Rows[i][CuentaCorrientePersonasService.Credito_NombreCol] - (decimal)dtCtacte.Rows[i][CuentaCorrientePersonasService.Debito_NombreCol])
                              / (decimal)dtCtacte.Rows[i][CuentaCorrientePersonasService.CotizacionMoneda_NombreCol];
                }

                return total;
            }
        }
        #endregion GetDeudaALaFechaEnDolares

        #region GetSaldoPersonaEnDolares
        public static decimal GetSaldoPersonaEnDolares(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetSaldoPersonaEnDolares(persona_id, sesion);
            }
        }

        public static decimal GetSaldoPersonaEnDolares(decimal persona_id, SessionService sesion)
        {
            DataTable dtCtacte;
            string clausulas;
            decimal total = 0;
            clausulas = CuentaCorrientePersonasService.PersonaId_NombreCol + " = " + persona_id;
            dtCtacte = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(clausulas, CuentaCorrientePersonasService.FechaInsercion_NombreCol, sesion);
            for (int i = 0; i < dtCtacte.Rows.Count; i++)
            {
                total += ((decimal)dtCtacte.Rows[i][CuentaCorrientePersonasService.Credito_NombreCol]
                    - (decimal)dtCtacte.Rows[i][CuentaCorrientePersonasService.Debito_NombreCol]
                    ) / (decimal)dtCtacte.Rows[i][CuentaCorrientePersonasService.CotizacionMoneda_NombreCol];
            }

            total += GetSaldoComoGaranteEnDolares(persona_id, sesion);
            return total;
        }

        public static decimal GetSaldoComoGaranteEnDolares(decimal persona_id, SessionService sesion)
        { 
            //Debe ir agregandose la consulta por cada flujo donde pueda participar como garante
            decimal monto = 0;
            string clausulas = string.Empty;
            //Flujo Facturas Cliente
            clausulas = FacturasClienteService.VistaCasoEstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Caja + "' and " +
                        "(nvl(" + FacturasClienteService.PersonaGarante1Id_NombreCol + ", -1) = " + persona_id + " or " +
                        " nvl(" + FacturasClienteService.PersonaGarante2Id_NombreCol + ", -1) = " + persona_id + " or " +
                        " nvl(" + FacturasClienteService.PersonaGarante3Id_NombreCol + ", -1) = " + persona_id + ") and " +
                        FacturasClienteService.VistaCasoEstado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                        FacturasClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            var dtFacturas = FacturasClienteService.GetFacturaClienteInfoCompleta(clausulas, string.Empty);
            for (int i = 0; i < dtFacturas.Rows.Count; i++)
                monto += CuentaCorrientePersonasService.GetSaldoCasoEnDolares((decimal)dtFacturas.Rows[i][FacturasClienteService.CasoId_NombreCol], sesion);
            //Flujo Creditos
            var credito = CreditosService.Instancia;
            credito.IniciarUsingSesion(sesion);
            var aCreditos = credito.GetFiltrado<CreditosService>(new CreditosService.Filtro[]
                { 
                    new CreditosService.Filtro() { Columna =  CreditosService.FiltroExtension.PersonaDeudoraOGaranteId, Valor = persona_id },
                    new CreditosService.Filtro() { Columna =  CreditosService.Modelo.PERSONA_IDColumnName, Comparacion = "<>", Valor = persona_id },
                    new CreditosService.Filtro() { Columna =  CreditosService.FiltroExtension.CasoEstadoId, Exacto = false, Valor = new string[] { Definiciones.EstadosFlujos.Vigente, Definiciones.EstadosFlujos.EnRevision } },
                });
            credito.FinalizarUsingSesion();
            for (int i = 0; i < aCreditos.Length; i++)
                monto += CuentaCorrientePersonasService.GetSaldoCasoEnDolares(aCreditos[i].CasoId.Value, sesion);

            return monto;
        }

        public static decimal GetSaldoCasoEnDolares(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetSaldoCasoEnDolares(caso_id, sesion);
            }
        }

        public static decimal GetSaldoCasoEnDolares(decimal caso_id, SessionService sesion)
        {
            string clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + caso_id + " and " +
                               CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            var resultado = sesion.Db.CTACTE_PERSONASCollection.GetAsArray(clausulas, CuentaCorrientePersonasService.Id_NombreCol);
            return resultado.Sum((fila) => (fila.CREDITO - fila.DEBITO) / fila.COTIZACION_MONEDA);
        }
        #endregion GetSaldoPersonaEnDolares

        #region GetSaldoPersonaEnMoneda
        /// <summary>
        /// Gets the saldo persona en moneda.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <returns></returns>
        public decimal GetSaldoPersonaEnMoneda(decimal persona_id, decimal moneda_id)
        {
            decimal totalenDolares = GetSaldoPersonaEnDolares(persona_id);
            return totalenDolares * CotizacionesService.GetCotizacionMonedaVenta(moneda_id);
        }       

        public static decimal GetSaldoCasoEnMoneda(decimal caso_id, decimal moneda_id)
        {
            decimal saldoDolares = GetSaldoCasoEnDolares(caso_id);
            decimal saldoMoneda = saldoDolares;
            using (SessionService sesion = new SessionService())
            {
                CTACTE_PERSONASRow[] rows;
                string clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + caso_id + " and " +
                                   CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                rows = sesion.Db.CTACTE_PERSONASCollection.GetAsArray(clausulas, CuentaCorrientePersonasService.Id_NombreCol);
                if (rows != null && rows.Length > 0)
                {
                    decimal cotizacion = 0m;
                    IEnumerable<IGrouping<decimal, CTACTE_PERSONASRow>> monedas;
                    monedas = rows.GroupBy((a) => a.COTIZACION_MONEDA);

                    if (monedas.Count() > 1)
                        throw new Exception("Existe mas de una cotizacion para el caso");

                    if (monedas.ElementAt(0).ElementAt(0).MONEDA_ID == moneda_id)
                        cotizacion = monedas.ElementAt(0).Key;
                    else
                        cotizacion = CotizacionesService.GetCotizacionMonedaVenta(moneda_id);
                    saldoMoneda *= cotizacion;
                }
            }
            return saldoMoneda;
        }
        #endregion GetSaldoPersonaEnMoneda

        #region GetSaldoPersona
        public static decimal GetSaldoPersona(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetSaldoPersona(persona_id, sesion);
            }
        }

        public static decimal GetSaldoPersona(decimal persona_id, SessionService sesion)
        {
            DataTable dtCtacte;
            string clausulas;
            decimal total = 0;

            clausulas = "cp." + CuentaCorrientePersonasService.PersonaId_NombreCol + " = " + persona_id;

            string query = "select cp.*, fc." + FacturasClienteService.CondicionPagoId_NombreCol + 
                           " from " + CuentaCorrientePersonasService.Nombre_Tabla + " cp, " +
                           FacturasClienteService.Nombre_Tabla + " fc \n" +
                           "where cp." + CuentaCorrientePersonasService.CasoId_NombreCol + 
                           " = fc." + FacturasClienteService.CasoId_NombreCol + 
                           " and fc." + FacturasClienteService.CondicionPagoId_NombreCol + " != "  + Definiciones.CondicionPago.Contado + 
                           " and cp." + CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo +
                           "' and fc." + FacturasClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " + clausulas;

            dtCtacte = sesion.db.EjecutarQuery(query);           
            
            for (int i = 0; i < dtCtacte.Rows.Count; i++)
            {
                total += ((decimal)dtCtacte.Rows[i][CuentaCorrientePersonasService.Credito_NombreCol]
                    - (decimal)dtCtacte.Rows[i][CuentaCorrientePersonasService.Debito_NombreCol]);
            }

            total += GetSaldoComoGarante(persona_id, sesion);

            return total;
        }

        public static decimal GetSaldoComoGarante(decimal persona_id, SessionService sesion)
        {
            //Debe ir agregandose la consulta por cada flujo donde pueda participar como garante
            decimal monto = 0;
            string clausulas = string.Empty;

            //Flujo Facturas Cliente
            clausulas = FacturasClienteService.VistaCasoEstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Caja + "' and " +
                        "(nvl(" + FacturasClienteService.PersonaGarante1Id_NombreCol + ", -1) = " + persona_id + " or " +
                        " nvl(" + FacturasClienteService.PersonaGarante2Id_NombreCol + ", -1) = " + persona_id + " or " +
                        " nvl(" + FacturasClienteService.PersonaGarante3Id_NombreCol + ", -1) = " + persona_id + ") and " +
                        FacturasClienteService.VistaCasoEstado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                        FacturasClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            var dtFacturas = FacturasClienteService.GetFacturaClienteInfoCompleta(clausulas, string.Empty);
            for (int i = 0; i < dtFacturas.Rows.Count; i++)
                monto += CuentaCorrientePersonasService.GetSaldoCasoEnMoneda((decimal)dtFacturas.Rows[i][FacturasClienteService.CasoId_NombreCol], Definiciones.Monedas.Guaranies);
            //Flujo Creditos
            var credito = CreditosService.Instancia;
            credito.IniciarUsingSesion(sesion);
            var aCreditos = credito.GetFiltrado<CreditosService>(new CreditosService.Filtro[]
                { 
                    new CreditosService.Filtro() { Columna =  CreditosService.FiltroExtension.PersonaDeudoraOGaranteId, Valor = persona_id },
                    new CreditosService.Filtro() { Columna =  CreditosService.Modelo.PERSONA_IDColumnName, Comparacion = "<>", Valor = persona_id },
                    new CreditosService.Filtro() { Columna =  CreditosService.FiltroExtension.CasoEstadoId, Exacto = false, Valor = new string[] { Definiciones.EstadosFlujos.Vigente, Definiciones.EstadosFlujos.EnRevision } },
                });
            credito.FinalizarUsingSesion();
            for (int i = 0; i < aCreditos.Length; i++)
                monto += CuentaCorrientePersonasService.GetSaldoCasoEnMoneda((decimal)dtFacturas.Rows[i][FacturasClienteService.CasoId_NombreCol], Definiciones.Monedas.Guaranies);

            return monto;
        }
        #endregion GetSaldoPersona

        #region GetSaldoDeMovimiento
        /// <summary>
        /// Gets the saldo de movimiento.
        /// </summary>
        /// <param name="ctacte_persona_id">The ctacte_persona_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal GetSaldoDeMovimiento(decimal ctacte_persona_id, SessionService sesion)
        {
            DataTable dtCtacte;
            dtCtacte = GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.Id_NombreCol + " = " + ctacte_persona_id, string.Empty, sesion);
            return (decimal)dtCtacte.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol] - (decimal)dtCtacte.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol];
        }
        #endregion GetSaldoDeMovimiento

        #region GetSaldoDePorCaso
        public static decimal GetSaldoDePorCaso(decimal caso_id, SessionService sesion)
        {
            DataTable dtCtacte = GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CasoId_NombreCol + " = " + caso_id +
                       " and " + CuentaCorrientePersonasService.CtactePersonaRelacionada_NombreCol + " is null ", string.Empty, sesion);
            decimal saldo = 0;
            decimal debito = 0;
            decimal credito = 0;
            decimal ctacte_concepto = -1;
            for (int i = 0; i < dtCtacte.Rows.Count; i++)
            {
                credito += (decimal)dtCtacte.Rows[i][CuentaCorrientePersonasService.Credito_NombreCol];
                debito += (decimal)dtCtacte.Rows[i][CuentaCorrientePersonasService.Debito_NombreCol];
                ctacte_concepto = (decimal)dtCtacte.Rows[0][CuentaCorrientePersonasService.CtaCteConceptoId_NombreCol];
            }

            if (ctacte_concepto == 1/*DÉBITO POR FLUJO*/)
                saldo = debito - credito;
            else if (ctacte_concepto == 2/*CRÉDITO POR FLUJO*/)
                saldo = credito - debito;

            return saldo;
        }
        #endregion GetSaldoDePorCaso

        #region SetBloqueado
        /// <summary>
        /// Sets the bloqueado.
        /// </summary>
        /// <param name="ctacte_persona_id">The ctacte_persona_id.</param>
        /// <param name="bloquear">if set to <c>true</c> [bloquear].</param>
        /// <param name="sesion">The sesion.</param>
        public static void SetBloqueado(decimal ctacte_persona_id, bool bloquear, SessionService sesion)
        {
            try
            {
                CTACTE_PERSONASRow row = sesion.db.CTACTE_PERSONASCollection.GetByPrimaryKey(ctacte_persona_id);
                string valorAnterior = row.ToString();
                row.BLOQUEADO = bloquear ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
                sesion.db.CTACTE_PERSONASCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion SetBloqueado

        #region GetBloqueado
        /// <summary>
        /// get the bloqueado.
        /// </summary>
        /// <param name="ctacte_persona_id">The ctacte_persona_id.</param>
        /// <param name="bloquear">if set to <c>true</c> [bloquear].</param>
        /// <param name="sesion">The sesion.</param>
        /// 
        public static string GetBloqueado(decimal ctacte_persona_id)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return GetBloqueado(ctacte_persona_id, sesion);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetBloqueado(decimal ctacte_persona_id, SessionService sesion)
        {
            try
            {
                CTACTE_PERSONASRow row = sesion.db.CTACTE_PERSONASCollection.GetByPrimaryKey(ctacte_persona_id);
                return row.BLOQUEADO.Equals(Definiciones.SiNo.Si) ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion GetBloqueado

        #region AgregarCredito
        public static decimal AgregarCredito(decimal persona_id, decimal ctacte_persona_relacionada_id, decimal concepto_id, decimal caso_id, decimal moneda_id, decimal cotizacion, decimal[] impuesto_id, decimal[] monto, string comentario, DateTime fecha_vencimiento, decimal ctacte_pago_persona_det_id, decimal ctacte_pago_persona_doc_id, decimal ctacte_pagare_det_id, decimal calendario_pagos_cliente_id, decimal calendario_pagos_credito_id, decimal orden_pago_id, decimal ctacte_pago_persona_rec_id, decimal ctacte_documento_vencimiento_id, decimal aplicacion_documento_id, decimal aplicacion_documento_valor_id, decimal aplicacion_documento_rec_id, decimal cuota_numero, decimal cuota_total, SessionService sesion)
        {
            CTACTE_PERSONASRow row = new CTACTE_PERSONASRow();
            CTACTE_PERSONASRow rowPrincipal;
            string valorAnterior;
            decimal montoTotal, porcentajeAjuste;
            row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_personas_sqc");
            row.PERSONA_ID = persona_id;
            montoTotal = 0;
            for (int i = 0; i < monto.Length; i++)
                montoTotal += monto[i];
            //Se ajusta el desglose de monto por impuesto para que la suma 
            //este redondeada a la cantidad de decimales de la moneda
            if (montoTotal != 0)
            {
                porcentajeAjuste = Math.Round(montoTotal, MonedasService.CantidadDecimalesStatic(moneda_id, sesion)) / montoTotal;
                montoTotal *= porcentajeAjuste;
                for (int i = 0; i < monto.Length; i++)
                    monto[i] *= porcentajeAjuste;
            }

            if (caso_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                row.IsCASO_IDNull = true;
            else
                row.CASO_ID = caso_id;

            if (ctacte_pago_persona_det_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                row.IsCTACTE_PAGO_PERSONA_DET_IDNull = true;
            else
                row.CTACTE_PAGO_PERSONA_DET_ID = ctacte_pago_persona_det_id;

            if (ctacte_pago_persona_rec_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                row.IsCTACTE_PAGO_PERSONA_REC_IDNull = true;
            else
                row.CTACTE_PAGO_PERSONA_REC_ID = ctacte_pago_persona_rec_id;

            if (ctacte_pago_persona_doc_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                row.IsCTACTE_PAGO_PERSONA_DOC_IDNull = true;
            else
                row.CTACTE_PAGO_PERSONA_DOC_ID = ctacte_pago_persona_doc_id;

            if (aplicacion_documento_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                row.IsAPLICACION_DOCUMENTOS_IDNull = true;
            else
                row.APLICACION_DOCUMENTOS_ID = aplicacion_documento_id;

            if (aplicacion_documento_valor_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                row.IsAPLICACION_DOCUMENTOS_VAL_IDNull = true;
            else
                row.APLICACION_DOCUMENTOS_VAL_ID = aplicacion_documento_valor_id;

            if (aplicacion_documento_rec_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                row.IsAPLICACION_DOCUMENTOS_REC_IDNull = true;
            else
                row.APLICACION_DOCUMENTOS_REC_ID = aplicacion_documento_rec_id;

            if (ctacte_documento_vencimiento_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                row.IsCTACTE_DOCUMENTO_VENC_IDNull = true;
            else
                row.CTACTE_DOCUMENTO_VENC_ID = ctacte_documento_vencimiento_id;

            if (!row.IsCASO_IDNull)
            {
                int flujo_id = (int)CasosService.GetFlujo(row.CASO_ID, sesion);
                switch (flujo_id)
                {
                    case Definiciones.FlujosIDs.ANTICIPO_PERSONA:
                        row.CTACTE_VALOR_ID = Definiciones.CuentaCorrienteValores.Anticipo;
                        break;
                    case Definiciones.FlujosIDs.CREDITOS:
                        row.CTACTE_VALOR_ID = Definiciones.CuentaCorrienteValores.Credito;
                        break;
                    case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES:
                        row.CTACTE_VALOR_ID = Definiciones.CuentaCorrienteValores.DescuentoDocumentos;
                        break;
                    case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                        row.CTACTE_VALOR_ID = Definiciones.CuentaCorrienteValores.Factura;
                        break;
                    case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                        row.CTACTE_VALOR_ID = Definiciones.CuentaCorrienteValores.Factura;
                        break;
                    case Definiciones.FlujosIDs.EGRESO_VARIO_CAJA:
                        row.CTACTE_VALOR_ID = Definiciones.CuentaCorrienteValores.EgresoVarioCaja;
                        break;
                    case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                        row.CTACTE_VALOR_ID = Definiciones.CuentaCorrienteValores.OrdenDePago;
                        break;
                    case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:
                        row.CTACTE_VALOR_ID = Definiciones.CuentaCorrienteValores.NotaDeCredito;
                        break;
                    case Definiciones.FlujosIDs.NOTA_DEBITO_PERSONA:
                        row.CTACTE_VALOR_ID = Definiciones.CuentaCorrienteValores.NotaDeDebito;
                        break;
                    case Definiciones.FlujosIDs.TRANSFERENCIA_CTACTE_PERSONA:
                        row.CTACTE_VALOR_ID = Definiciones.CuentaCorrienteValores.TransferenciaCtacte;
                        break;
                    default:
                        row.IsCTACTE_VALOR_IDNull = true;
                        break;
                }
            }

            if (ctacte_pagare_det_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
            {
                row.IsCTACTE_PAGARE_DET_IDNull = true;
            }
            else
            {
                row.CTACTE_PAGARE_DET_ID = ctacte_pagare_det_id;
                row.CTACTE_VALOR_ID = Definiciones.CuentaCorrienteValores.Pagare;
            }

            if (orden_pago_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                row.IsORDEN_PAGO_IDNull = true;
            else
                row.ORDEN_PAGO_ID = orden_pago_id;

            //Si el movimiento es principal entonces debe guardarse el numero de caso y el debito debe ser 0
            //Si no es principal, entonces el debito es igual al credito (ya que tambien se actualiza el credito
            //del movimiento principal y el numero de caso no es almacenado.
            if (ctacte_persona_relacionada_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
            {
                row.DEBITO = 0;
            }
            else
            {
                //El debito es igual al credito para no duplicar el debe.
                //ya que se afecta el credito al movimiento principal
                row.DEBITO = montoTotal;
                if (!ctacte_persona_relacionada_id.Equals(Definiciones.Error.Valor.EnteroPositivo) && !caso_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    row.CASO_ID = caso_id;
                }
                else
                {
                    row.IsCASO_IDNull = true;
                }

                row.CTACTE_PERSONA_RELACIONADA_ID = ctacte_persona_relacionada_id;
                rowPrincipal = sesion.Db.CTACTE_PERSONASCollection.GetByPrimaryKey(ctacte_persona_relacionada_id);
                valorAnterior = rowPrincipal.ToString();
                rowPrincipal.CREDITO += montoTotal;
                //Se actualiza el movimiento principal
                sesion.Db.CTACTE_PERSONASCollection.Update(rowPrincipal);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, rowPrincipal.ID, valorAnterior, rowPrincipal.ToString(), sesion);
            }

            row.MONEDA_ID = moneda_id;
            row.COTIZACION_MONEDA = cotizacion;
            if (row.COTIZACION_MONEDA == Definiciones.Error.Valor.EnteroPositivo)
                throw new Exception("CuentaCorrientePersonasService.AgregarCredito. La cotización no puede ser -1.");

            row.CTACTE_CONCEPTO_ID = concepto_id;
            row.CREDITO = montoTotal;
            row.CONCEPTO = comentario;
            row.FECHA_INSERCION = DateTime.Now;
            row.FECHA_VENCIMIENTO = fecha_vencimiento;
            row.JUDICIAL = Definiciones.SiNo.No;
            row.BLOQUEADO = Definiciones.SiNo.No;
            row.ESTADO = Definiciones.Estado.Activo;
            if (calendario_pagos_cliente_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                row.IsCALENDARIO_PAGOS_FC_CLI_IDNull = true;
            else
                row.CALENDARIO_PAGOS_FC_CLI_ID = calendario_pagos_cliente_id;

            if (calendario_pagos_credito_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                row.IsCALENDARIO_PAGOS_CR_CLI_IDNull = true;
            else
                row.CALENDARIO_PAGOS_CR_CLI_ID = calendario_pagos_credito_id;

            row.CUOTA_NUMERO = cuota_numero;
            row.CUOTA_TOTAL = cuota_total;

            sesion.Db.CTACTE_PERSONASCollection.Insert(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);
            //Guardar los detalles identificando el monto por cada impuesto
            CuentaCorrientePersonasDetalleService.Guardar(row.ID, impuesto_id, monto, sesion);
            return row.ID;
        }
        #endregion AgregarCredito

        #region DeshacerAgregarCredito
        /// <summary>
        /// Deshacers the agregar credito.
        /// </summary>
        /// <param name="ctacte_pagare_det_id">The ctacte_pagare_det_id.</param>
        /// <param name="ctacte_pago_persona_recargo_id">The ctacte_pago_persona_recargo_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <exception cref="System.Exception">El documento tiene pagos por lo que no puede deshacer el crédito.</exception>
        public static void DeshacerAgregarCredito(decimal ctacte_pagare_det_id, decimal ctacte_pago_persona_recargo_id, decimal aplicacion_documento_recargo_id, bool revisar_pagos_hechos, SessionService sesion)
        {
            try
            {
                CTACTE_PERSONASRow row;
                string clausulas;
                if (!ctacte_pagare_det_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    clausulas = CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                                CuentaCorrientePersonasService.CtactePagareDetId_NombreCol + " = " + ctacte_pagare_det_id;
                    row = sesion.Db.CTACTE_PERSONASCollection.GetAsArray(clausulas, CuentaCorrientePersonasService.Id_NombreCol)[0];
                }
                else if (!ctacte_pago_persona_recargo_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    clausulas = CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                                CuentaCorrientePersonasService.CtactePagoPersonaRecId_NombreCol + " = " + ctacte_pago_persona_recargo_id;
                    CTACTE_PERSONASRow[] rowsAux = sesion.Db.CTACTE_PERSONASCollection.GetAsArray(clausulas, CuentaCorrientePersonasService.Id_NombreCol);
                    if (rowsAux.Length <= 0)
                        return;

                    row = rowsAux[0];
                }
                else if (!aplicacion_documento_recargo_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    clausulas = CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                                CuentaCorrientePersonasService.AplicacionDocumentosRecId_NombreCol + " = " + aplicacion_documento_recargo_id;
                    CTACTE_PERSONASRow[] rowsAux = sesion.Db.CTACTE_PERSONASCollection.GetAsArray(clausulas, CuentaCorrientePersonasService.Id_NombreCol);
                    if (rowsAux.Length <= 0)
                        return;

                    row = rowsAux[0];
                }
                else
                {
                    throw new Exception("CuentaCorrientePersonasService.DeshacerAgregarCredito() Error en parámetros.");
                }
                //Controlar que no existan pagos sobre el movimiento
                if (revisar_pagos_hechos && row.DEBITO > 0)
                    throw new Exception("El documento tiene pagos por lo que no puede deshacer el crédito.");
                //Si es un recargo debe borrarse primero el pago realizado para saldarlo
                if (!ctacte_pago_persona_recargo_id.Equals(Definiciones.Error.Valor.EnteroPositivo) || !aplicacion_documento_recargo_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    clausulas = CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                                CuentaCorrientePersonasService.CtactePersonaRelacionada_NombreCol + " = " + row.ID;
                    CTACTE_PERSONASRow[] rowPagoRecargo = sesion.db.CTACTE_PERSONASCollection.GetAsArray(clausulas, CuentaCorrientePersonasService.Id_NombreCol);
                    if (rowPagoRecargo.Length > 0)
                    {
                        rowPagoRecargo[0].ESTADO = Definiciones.Estado.Inactivo;
                        sesion.db.CTACTE_PERSONASCollection.Update(rowPagoRecargo[0]);
                    }
                }
                //Borrar los detalles
                CuentaCorrientePersonasDetalleService.Borrar(row.ID, sesion);
                //Se borra el movimiento
                row.ESTADO = Definiciones.Estado.Inactivo;
                sesion.Db.CTACTE_PERSONASCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion DeshacerAgregarCredito

        #region DeshacerAgregarCreditoPorCaso
        /// <summary>
        /// Deshacers the agregar credito.
        /// </summary>
        public static void DeshacerAgregarCreditoPorCaso(decimal caso_id, SessionService sesion)
        {
            try
            {
                CTACTE_PERSONASRow[] row;
                string clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + caso_id + " and " + CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                row = sesion.Db.CTACTE_PERSONASCollection.GetAsArray(clausulas, CuentaCorrientePersonasService.Id_NombreCol);
                //Controlar que no existan pagos sobre el movimiento
                bool bandera = false;
                for (int i = 0; i < row.Length; i++)
                {
                    if (row[i].DEBITO > 0)
                    {
                        bandera = true;
                        break;
                    }
                }

                if (bandera)
                    throw new Exception("El documento tiene pagos por lo que no puede deshacer el crédito.");
                //Borrar los detalles
                for (int i = 0; i < row.Length; i++)
                {
                    //Se borra el movimiento dejando el registro en ctacte_personas_detalle
                    row[i].ESTADO = Definiciones.Estado.Inactivo;
                    sesion.Db.CTACTE_PERSONASCollection.Update(row[i]);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row[i].ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion DeshacerAgregarCredito

        #region DeshacerAgregarCredito
        public static void DeshacerAgregarCredito(decimal ctacte_pago_persona_det_id, SessionService sesion)
        {
            string flujoId = string.Empty;
            string estadoActual = string.Empty;
            CTACTE_PERSONASRow[] rowRelacionado = sesion.db.CTACTE_PERSONASCollection.GetByCTACTE_PAGO_PERSONA_DET_ID(ctacte_pago_persona_det_id);
            if (rowRelacionado.Length > 0)
            {
                CTACTE_PERSONASRow rowPrincipal = sesion.db.CTACTE_PERSONASCollection.GetByPrimaryKey(rowRelacionado[0].CTACTE_PERSONA_RELACIONADA_ID);
                rowPrincipal.CREDITO -= rowRelacionado[0].CREDITO;
                sesion.db.CTACTE_PERSONASCollection.Update(rowPrincipal);

                rowRelacionado[0].ESTADO = Definiciones.Estado.Inactivo;
                sesion.db.CTACTE_PERSONASCollection.Update(rowRelacionado[0]);
            }
        }
        #endregion DeshacerAgregarCredito

        #region AgregarDebito
        /// <summary>
        /// Agregars the debito.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <param name="ctacte_persona_relacionada_id">The ctacte_persona_relacionada_id.</param>
        /// <param name="concepto_id">The concepto_id.</param>
        /// <param name="ctacte_valor_id">The ctacte_valor_id.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <param name="cotizacion_compra">The cotizacion_compra.</param>
        /// <param name="impuesto_id">The impuesto_id.</param>
        /// <param name="monto">The monto.</param>
        /// <param name="comentario">The comentario.</param>
        /// <param name="fecha_vencimiento">The fecha_vencimiento.</param>
        /// <param name="ctacte_pago_persona_det_id">The ctacte_pago_persona_det_id.</param>
        /// <param name="ctacte_pago_persona_doc_id">The ctacte_pago_persona_doc_id.</param>
        /// <param name="ctacte_pagare_doc_id">The ctacte_pagare_doc_id.</param>
        /// <param name="ctacte_pago_persona_rec_id">The ctacte_pago_persona_rec_id.</param>
        /// <param name="aplicacion_documento_id">The aplicacion_documento_id.</param>
        /// <param name="aplicacion_documento_valor_id">The aplicacion_documento_valor_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal AgregarDebito(decimal persona_id, decimal ctacte_persona_relacionada_id, decimal concepto_id, decimal ctacte_valor_id, decimal caso_id, decimal moneda_id, decimal cotizacion_compra, decimal[] impuesto_id, decimal[] monto, string comentario, DateTime fecha_vencimiento, decimal ctacte_pago_persona_det_id, decimal ctacte_pago_persona_doc_id, decimal ctacte_pagare_doc_id, decimal ctacte_pago_persona_rec_id, decimal aplicacion_documento_id, decimal aplicacion_documento_valor_id, decimal aplicacion_documento_rec_id, SessionService sesion)
        {
            CTACTE_PERSONASRow row = new CTACTE_PERSONASRow();

            try
            {
                CTACTE_PERSONASRow rowPrincipal;
                string valorAnterior;
                decimal montoTotal, porcentajeAjuste;
                montoTotal = 0;
                for (int i = 0; i < monto.Length; i++)
                    montoTotal += monto[i];
                //Se ajusta el desglose de monto por impuesto para que la suma 
                //este redondeada a la cantidad de decimales de la moneda
                if (montoTotal != 0)
                {
                    porcentajeAjuste = Math.Round(montoTotal, MonedasService.CantidadDecimalesStatic(moneda_id, sesion)) / montoTotal;
                    montoTotal *= porcentajeAjuste;
                    for (int i = 0; i < monto.Length; i++)
                        monto[i] *= porcentajeAjuste;
                }

                #region Creacion del row a insertar
                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_personas_sqc");
                row.PERSONA_ID = persona_id;
                row.MONEDA_ID = moneda_id;
                row.JUDICIAL = Definiciones.SiNo.No;
                row.BLOQUEADO = Definiciones.SiNo.No;
                row.ESTADO = Definiciones.Estado.Activo;
                if (cotizacion_compra.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(sesion.SucursalActiva.PAIS_ID, moneda_id, row.FECHA_INSERCION, sesion);
                else
                    row.COTIZACION_MONEDA = cotizacion_compra;

                if (ctacte_pago_persona_det_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsCTACTE_PAGO_PERSONA_DET_IDNull = true;
                else
                    row.CTACTE_PAGO_PERSONA_DET_ID = ctacte_pago_persona_det_id;

                if (ctacte_pago_persona_doc_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsCTACTE_PAGO_PERSONA_DOC_IDNull = true;
                else
                    row.CTACTE_PAGO_PERSONA_DOC_ID = ctacte_pago_persona_doc_id;

                if (ctacte_pago_persona_rec_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsCTACTE_PAGO_PERSONA_REC_IDNull = true;
                else
                    row.CTACTE_PAGO_PERSONA_REC_ID = ctacte_pago_persona_rec_id;

                if (aplicacion_documento_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsAPLICACION_DOCUMENTOS_IDNull = true;
                else
                    row.APLICACION_DOCUMENTOS_ID = aplicacion_documento_id;

                if (aplicacion_documento_valor_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsAPLICACION_DOCUMENTOS_VAL_IDNull = true;
                else
                    row.APLICACION_DOCUMENTOS_VAL_ID = aplicacion_documento_valor_id;

                if (aplicacion_documento_rec_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsAPLICACION_DOCUMENTOS_REC_IDNull = true;
                else
                    row.APLICACION_DOCUMENTOS_REC_ID = aplicacion_documento_rec_id;

                if (ctacte_pagare_doc_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsCTACTE_PAGARE_DOC_IDNull = true;
                else
                    row.CTACTE_PAGARE_DOC_ID = ctacte_pagare_doc_id;

                row.CTACTE_CONCEPTO_ID = concepto_id;
                row.CTACTE_VALOR_ID = ctacte_valor_id;
                if (ctacte_persona_relacionada_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsCTACTE_PERSONA_RELACIONADA_IDNull = true;
                else 
                    row.CTACTE_PERSONA_RELACIONADA_ID = ctacte_persona_relacionada_id;

                row.DEBITO = montoTotal;
                row.CONCEPTO = comentario;
                row.FECHA_INSERCION = DateTime.Now;
                row.FECHA_VENCIMIENTO = fecha_vencimiento;
                #endregion Creacion del row a insertar

                //Si el movimiento de debito es por pago a un credito, se debe
                //haber indicado ctacte_persona_relacionada_id.
                //Si dicho campo es -1 entonces se trata de un debito por Anticipo
                //o algun flujo equivalente y no hay un credito que se este pagando
                #region Actualizacion del movimiento principal
                if (!ctacte_persona_relacionada_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    if (!caso_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    {
                        row.CASO_ID = caso_id;
                    }

                    rowPrincipal = sesion.Db.CTACTE_PERSONASCollection.GetByPrimaryKey(ctacte_persona_relacionada_id);
                    valorAnterior = rowPrincipal.ToString();
                    rowPrincipal.DEBITO += row.DEBITO;
                    //El credito es igual al debito para no duplicar el haber.
                    //ya que se afecta el debito al movimiento principal
                    row.CREDITO = montoTotal;
                    //Se actualiza el movimiento principal
                    sesion.Db.CTACTE_PERSONASCollection.Update(rowPrincipal);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rowPrincipal.ID, valorAnterior, rowPrincipal.ToString(), sesion);
                }
                else
                {
                    row.CASO_ID = caso_id;
                }
                #endregion Actualizacion del movimiento principal

                //Se inserta el movimiento nuevo
                sesion.Db.CTACTE_PERSONASCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);
                //Guardar los detalles identificando el monto por cada impuesto
                CuentaCorrientePersonasDetalleService.Guardar(row.ID, impuesto_id, monto, sesion);
            }
            catch (System.Exception exp)
            {
                throw exp;
            }

            return row.ID;
        }
        #endregion AgregarDebito

        #region DeshacerAgregarDebito
        /// <summary>
        /// Deshacers the agregar debito.
        /// </summary>
        /// <param name="ctacte_pagare_doc_id">The ctacte_pagare_doc_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void DeshacerAgregarDebito(decimal ctacte_pago_persona_doc_id, decimal ctacte_pagare_doc_id, SessionService sesion)
        {
            DeshacerAgregarDebito(ctacte_pago_persona_doc_id, ctacte_pagare_doc_id, sesion, Definiciones.Error.Valor.EnteroPositivo);
        }

        public static void DeshacerAgregarDebito(decimal ctacte_pago_persona_doc_id, decimal ctacte_pagare_doc_id, SessionService sesion, decimal ctacte_persona_relac_id)
        {
            try
            {
                CTACTE_PERSONASRow[] rows;
                CTACTE_PERSONASRow row, rowPrincipal;
                string valorAnterior, estadoActual = string.Empty, flujoId = string.Empty;
                if (ctacte_pago_persona_doc_id != Definiciones.Error.Valor.EnteroPositivo)
                {
                    string clausulas = CuentaCorrientePersonasService.CtactePagoPersonaDocId_NombreCol + " = " + ctacte_pago_persona_doc_id + " and " +
                                       CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                    rows = sesion.Db.CTACTE_PERSONASCollection.GetAsArray(clausulas, CuentaCorrientePersonasService.Id_NombreCol);
                }
                else if (ctacte_pagare_doc_id != Definiciones.Error.Valor.EnteroPositivo)
                {
                    string clausulas = CuentaCorrientePersonasService.CtactePagareDocId_NombreCol + " = " + ctacte_pagare_doc_id + " and " +
                                       CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                    rows = sesion.Db.CTACTE_PERSONASCollection.GetAsArray(clausulas, CuentaCorrientePersonasService.Id_NombreCol);
                }
                else if (ctacte_persona_relac_id != Definiciones.Error.Valor.EnteroPositivo)
                {
                    string clausulas = CuentaCorrientePersonasService.CtactePersonaRelacionada_NombreCol + " = " + ctacte_persona_relac_id + " and " +
                                       CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                    rows = sesion.Db.CTACTE_PERSONASCollection.GetAsArray(clausulas, CuentaCorrientePersonasService.Id_NombreCol);
                }
                else
                {
                    throw new Exception("Ctacte.DeshacerDebito(). Valor no implementado.");
                }

                if (rows.Length <= 0)
                    return;

                row = rows[0];
                rowPrincipal = sesion.Db.CTACTE_PERSONASCollection.GetByPrimaryKey(row.CTACTE_PERSONA_RELACIONADA_ID);
                //Borrar los detalles, 
                CuentaCorrientePersonasDetalleService.Borrar(row.ID, sesion);
                //Se borra el movimiento
                row.ESTADO = Definiciones.Estado.Inactivo;
                sesion.Db.CTACTE_PERSONASCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                //Se actualiza el movimiento principal
                valorAnterior = rowPrincipal.ToString();
                rowPrincipal.DEBITO -= row.DEBITO;
                sesion.Db.CTACTE_PERSONASCollection.Update(rowPrincipal);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, rowPrincipal.ID, valorAnterior, rowPrincipal.ToString(), sesion);

                //Segun sea el flujo, el caso pudo cambiar de estado si se habia finiquitado
                #region cambiar estado segun flujo
                if (!rowPrincipal.IsCASO_IDNull)
                {
                    CasosService.GetFlujoYEstado(rowPrincipal.CASO_ID, ref flujoId, ref estadoActual, sesion);
                    switch (int.Parse(flujoId))
                    {
                        case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                            if (estadoActual == Definiciones.EstadosFlujos.Cerrado)
                                CambioEstadoCasoService.BorrarCambioEstado(rowPrincipal.CASO_ID, Definiciones.EstadosFlujos.Caja, Definiciones.EstadosFlujos.Cerrado, sesion);
                            break;
                        case Definiciones.FlujosIDs.NOTA_DEBITO_PERSONA:
                            if (estadoActual == Definiciones.EstadosFlujos.Cerrado)
                                CambioEstadoCasoService.BorrarCambioEstado(rowPrincipal.CASO_ID, Definiciones.EstadosFlujos.Aprobado, Definiciones.EstadosFlujos.Cerrado, sesion);
                            break;
                        case Definiciones.FlujosIDs.CREDITOS:
                            if (estadoActual == Definiciones.EstadosFlujos.Cerrado)
                                CambioEstadoCasoService.BorrarCambioEstado(rowPrincipal.CASO_ID, Definiciones.EstadosFlujos.Vigente, Definiciones.EstadosFlujos.Cerrado, sesion);
                            break;
                        case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES:
                            if (estadoActual == Definiciones.EstadosFlujos.Cerrado)
                                CambioEstadoCasoService.BorrarCambioEstado(rowPrincipal.CASO_ID, Definiciones.EstadosFlujos.Vigente, Definiciones.EstadosFlujos.Cerrado, sesion);
                            break;
                    }
                }
                #endregion cambiar estado segun flujo
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion DeshacerAgregarDebito

        #region DeshacerAgregarDebitoMovimientoPrincipal
        /// <summary>
        /// Deshacers the agregar debito movimiento principal.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void DeshacerAgregarDebitoMovimientoPrincipal(decimal caso_id, SessionService sesion)
        {
            try
            {
                DataTable dtCtactePersonaPrincipal, dtCtactePersonaRelacionada;
                dtCtactePersonaPrincipal = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CasoId_NombreCol + " = " + caso_id + " and " + CuentaCorrientePersonasService.CtactePersonaRelacionada_NombreCol + " is null", string.Empty, sesion);
                if (dtCtactePersonaPrincipal.Rows.Count <= 0)
                    throw new Exception("No se encontró el movimiento principal al intentar deshacer el débito.");

                if (dtCtactePersonaPrincipal.Rows.Count > 1)
                    throw new Exception("Se encontró múltiples movimientos principales al intentar deshacer el débito.");

                dtCtactePersonaRelacionada = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CtactePersonaRelacionada_NombreCol + " = " + dtCtactePersonaPrincipal.Rows[0][CuentaCorrientePersonasService.Id_NombreCol], string.Empty, sesion);
                if (dtCtactePersonaRelacionada.Rows.Count > 0)
                    throw new Exception("No puede deshacerse la asignación del débito ya que el movimiento principal tiene movimientos asociados.");

                CTACTE_PERSONASRow rowPrincipal = sesion.Db.CTACTE_PERSONASCollection.GetByPrimaryKey((decimal)dtCtactePersonaPrincipal.Rows[0][CuentaCorrientePersonasService.Id_NombreCol]);
                //Borrar los detalles
                CuentaCorrientePersonasDetalleService.Borrar(rowPrincipal.ID, sesion);
                //Se borra el movimiento
                rowPrincipal.ESTADO = Definiciones.Estado.Inactivo;
                sesion.Db.CTACTE_PERSONASCollection.Update(rowPrincipal);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, rowPrincipal.ID, rowPrincipal.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion DeshacerAgregarDebitoMovimientoPrincipal

        #region ActualizarFechaVencimiento
        public static void ActualizarFechaVencimientoYMonto(decimal ctacte_persona_id, DateTime fecha_vencimiento, decimal monto)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    ActualizarFechaVencimientoYMonto(ctacte_persona_id, fecha_vencimiento, monto, true, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        /// <summary>
        /// Actualizars the fecha vencimiento Y monto.
        /// </summary>
        /// <param name="ctacte_persona_id">The ctacte_persona_id.</param>
        /// <param name="fecha_vencimiento">The fecha_vencimiento.</param>
        /// <param name="monto">The monto.</param>
        public static void ActualizarFechaVencimientoYMonto(decimal ctacte_persona_id, DateTime fecha_vencimiento, decimal monto, bool verificar_existen_pagos, SessionService sesion)
        {
            try
            {
                CTACTE_PERSONASRow row = sesion.Db.CTACTE_PERSONASCollection.GetByPrimaryKey(ctacte_persona_id);
                string valorAnterior = row.ToString();
                if (verificar_existen_pagos && row.DEBITO > 0)
                    throw new Exception("El documento no puede ser modificado porque ya existen pagos asociados al mismo.");

                row.FECHA_VENCIMIENTO = fecha_vencimiento;
                row.CREDITO = monto;
                sesion.Db.CTACTE_PERSONASCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion ActualizarFechaVencimiento

        #region ActualizarFechaVencimientoPorCalendarioFC
        public static void ActualizarFechaVencimientoPorCalendarioFC(decimal calendario_factura_persona_id, DateTime fecha_vencimiento, SessionService sesion)
        {
            try
            {
                CTACTE_PERSONASRow[] rows = sesion.Db.CTACTE_PERSONASCollection.GetAsArray(CalendarioPagoFcCliId_NombreCol + " = " + calendario_factura_persona_id + " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'", string.Empty);
                if (rows.Length <= 0)
                    return;

                string valorAnterior = rows[0].ToString();
                rows[0].FECHA_VENCIMIENTO = fecha_vencimiento;
                sesion.Db.CTACTE_PERSONASCollection.Update(rows[0]);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[0].ID, valorAnterior, rows[0].ToString(), sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion ActualizarFechaVencimientoPorCalendarioFC

        #region GetCuotaMasVencida
        public static DataTable GetCuotaMasVencida(decimal personaId, decimal montoApagar, DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                StringBuilder query = new StringBuilder();
                query.Append("select * \n");
                query.Append("  from ctacte_personas \n");
                query.Append(" where (id, fecha_vencimiento) in (select id, min(to_date('").Append(fecha.ToShortDateString()).Append("', 'dd/mm/yyyy')) \n");
                query.Append("                                     from ctacte_personas \n");
                query.Append("                                    where persona_id = ").Append(personaId.ToString()).Append("\n");
                query.Append("                                      and debito < credito  and bloqueado = 'N' \n");
                query.Append("                                      and round(credito) = round(").Append(montoApagar.ToString() + " ) ");
                query.Append("                                      and rownum = 1 \n");
                query.Append("                                    group by id)");
                return sesion.db.EjecutarQuery(query.ToString());
            }
        }
        #endregion GetCuotaMasVencida

        #region GetPagosAnterioresCuota
        public static decimal GetPagosAnterioresCuota(decimal ctacte_persona_id, DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                StringBuilder query = new StringBuilder();
                query.Append("select sum(" + Credito_NombreCol + ") " + Credito_NombreCol + " \n");
                query.Append("  from " + Nombre_Tabla + " cper \n");
                query.Append(" where cper." + CtactePersonaRelacionada_NombreCol + " = " + ctacte_persona_id + " \n");
                query.Append("   and trunc(decode(cper." + CasoId_NombreCol + ", \n");
                query.Append("                    null, \n");
                query.Append("                    (select cpp.fecha \n");
                query.Append("                       from ctacte_pagos_persona           cpp, \n");
                query.Append("                            ctacte_pagos_persona_documento cppdo \n");
                query.Append("                      where cper.ctacte_pago_persona_doc_id = cppdo.id \n");
                query.Append("                        and cppdo.ctacte_pagos_persona_id = cpp.id), \n");
                query.Append("                    (select c.fecha_formulario \n");
                query.Append("                       from casos c \n");
                query.Append("                      where c.id = cper.caso_id))) < to_date('" + fecha.ToShortDateString() + "', 'dd/mm/yyyy') \n");
                query.Append("   and cper.estado = '" + Definiciones.Estado.Activo + "'");
                DataTable dt = sesion.db.EjecutarQuery(query.ToString());

                if (dt.Rows.Count > 0 && dt.Rows[0]["credito"] != DBNull.Value)
                    return (decimal)dt.Rows[0]["credito"];

                return 0;
            }
        }
        #endregion GetPagosAnterioresCuota

        #region Postergar
        /// <summary>
        /// Actualizars the fecha vencimiento Y monto.
        /// </summary>
        /// <param name="ctacte_persona_id">The ctacte_persona_id.</param>
        /// <param name="fecha_vencimiento">The fecha_vencimiento.</param>
        /// <param name="monto">The monto.</param>
        public static void Postergar(decimal ctacte_persona_id, DateTime fecha_postergacion)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    CTACTE_PERSONASRow row = sesion.Db.CTACTE_PERSONASCollection.GetByPrimaryKey(ctacte_persona_id);
                    string valorAnterior = row.ToString();
                    if (row.FECHA_VENCIMIENTO > fecha_postergacion)
                        throw new Exception("La fecha de postergación debe ser mayor a la fecha de vencimiento.");

                    row.FECHA_POSTERGACION = fecha_postergacion;
                    sesion.Db.CTACTE_PERSONASCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Postergar

        #region ModificarJudicial
        public void ModificarJudicial(SessionService sesion, decimal caso_id, bool agregar)
        {
            string clausulas = CasoId_NombreCol + " = " + caso_id +
                " and " + CtactePersonaRelacionada_NombreCol + " is null";
            DataTable dt = GetCuentaCorrientePersonasDataTable(clausulas, string.Empty);
            foreach (DataRow row in dt.Rows)
            {
                decimal id = (decimal)row[Id_NombreCol];
                CTACTE_PERSONASRow personaRow = sesion.Db.CTACTE_PERSONASCollection.GetByPrimaryKey(id);
                personaRow.JUDICIAL = agregar ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
                sesion.Db.CTACTE_PERSONASCollection.Update(personaRow);
            }
        }
        #endregion ModificarJudicial

        #region Borrar
        /// <summary>
        /// Borrars the specified ctacte_persona_id.
        /// </summary>
        /// <param name="ctacte_persona_id">The ctacte_persona_id.</param>
        /// 
        public static void Borrar(decimal ctacte_persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                Borrar(ctacte_persona_id, sesion);
            }
        }

        public static void Borrar(decimal ctacte_persona_id, SessionService sesion)
        {
            try
            {
                CTACTE_PERSONASRow row = sesion.Db.CTACTE_PERSONASCollection.GetByPrimaryKey(ctacte_persona_id);
                //Se inactiva sin borrar ctacte_personas_detalle
                row.ESTADO = Definiciones.Estado.Inactivo;
                sesion.Db.CTACTE_PERSONASCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        #endregion AgregarDebito

        #region TienePagoConfirmado
        public static bool TienePagoConfirmado(decimal ctacte_persona_id)
        {
            string clausulas = CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol + " = " + ctacte_persona_id + " and " + CuentaCorrientePagosPersonaDocumentoService.VistaPagoConfirmado_NombreCol + " = '" + Definiciones.SiNo.Si + "'";
            DataTable dt = CuentaCorrientePagosPersonaDocumentoService.GetCuentaCorrientePagosPersonaDocumentoInfoCompleta(clausulas, string.Empty, new SessionService());
            return dt.Rows.Count > 0;
        }

        public static bool TienePagos(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return TienePagos(caso_id, sesion);
            }
        }

        public static bool TienePagos(decimal caso_id, SessionService sesion)
        {
            string clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + caso_id + " and " +
                               CuentaCorrientePersonasService.Debito_NombreCol + " > 0 ";
            DataTable dt = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(clausulas, string.Empty, sesion);
            return dt.Rows.Count > 0;
        }
        #endregion TienePagoConfirmado

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PERSONAS"; }
        }
        public static string AplicacionDocumentosId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.APLICACION_DOCUMENTOS_IDColumnName; }
        }
        public static string AplicacionDocumentosRecId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.APLICACION_DOCUMENTOS_REC_IDColumnName; }
        }
        public static string AplicacionDocumentosValId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.APLICACION_DOCUMENTOS_VAL_IDColumnName; }
        }
        public static string Bloqueado_NombreCol
        {
            get { return CTACTE_PERSONASCollection.BLOQUEADOColumnName; }
        }
        public static string CalendarioPagoFcCliId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CALENDARIO_PAGOS_FC_CLI_IDColumnName; }
        }
        public static string CalendarioPagosCrCliId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CALENDARIO_PAGOS_CR_CLI_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CASO_IDColumnName; }
        }
        public static string Concepto_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CONCEPTOColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_PERSONASCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string Credito_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CREDITOColumnName; }
        }
        public static string CtaCteConceptoId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CTACTE_CONCEPTO_IDColumnName; }
        }
        public static string CtacteDocumentoVencId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CTACTE_DOCUMENTO_VENC_IDColumnName; }
        }
        public static string CtactePagareDetId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CTACTE_PAGARE_DET_IDColumnName; }
        }
        public static string CtactePagareDocId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CTACTE_PAGARE_DOC_IDColumnName; }
        }
        public static string CtactePagoPersonaDocId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CTACTE_PAGO_PERSONA_DOC_IDColumnName; }
        }
        public static string CtactePagoPersonaDetId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CTACTE_PAGO_PERSONA_DET_IDColumnName; }
        }
        public static string CtactePagoPersonaRecId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CTACTE_PAGO_PERSONA_REC_IDColumnName; }
        }
        public static string CtactePersonaRelacionada_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CTACTE_PERSONA_RELACIONADA_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string Debito_NombreCol
        {
            get { return CTACTE_PERSONASCollection.DEBITOColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_PERSONASCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PERSONASCollection.IDColumnName; }
        }
        public static string FechaInsercion_NombreCol
        {
            get { return CTACTE_PERSONASCollection.FECHA_INSERCIONColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return CTACTE_PERSONASCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string FechaPostergacion_NombreCol
        {
            get { return CTACTE_PERSONASCollection.FECHA_POSTERGACIONColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.MONEDA_IDColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.PERSONA_IDColumnName; }
        }
        public static string OrdenPagoId_NombreCol
        {
            get { return CTACTE_PERSONASCollection.ORDEN_PAGO_IDColumnName; }
        }
        public static string Judicial_NombreCol
        {
            get { return CTACTE_PERSONASCollection.JUDICIALColumnName; }
        }
        public static string CuotaNumero_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CUOTA_NUMEROColumnName; }
        }
        public static string CuotaTotal_NombreCol
        {
            get { return CTACTE_PERSONASCollection.CUOTA_TOTALColumnName; }
        }
        public static string Nombre_Vista
        {
            get { return "CTACTE_PERSONAS_INFO_COMPLETA"; }
        }
        public static string VistaPersonaCodigo_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.PERSONA_CODIGOColumnName; }
        }
        public static string VistaPersonaNombreCompleto_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaPersonaNumeroDocumento_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.PERSONA_NUMERO_DOCUMENTOColumnName; }
        }
        public static string VistaPersonaCobradorHabitualId_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.PERSONA_COBRADOR_HABITUALColumnName; }
        }
        public static string VistaCasoNroComprobante_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.CASO_NRO_COMPROBANTEColumnName; }
        }
        public static string VistaCasoNroComprobante2_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.CASO_NRO_COMPROBANTE2ColumnName; }
        }
        public static string VistaCasoId_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.CASO_IDColumnName; }
        }
        public static string VistaCtacteConceptoDescripcion_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.CTACTE_CONCEPTO_DESCRIPCIONColumnName; }
        }
        public static string VistaCtactePagareId_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.CTACTE_PAGARE_IDColumnName; }
        }
        public static string VistaCtacteValorNombre_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.CTACTE_VALOR_NOMBREColumnName; }
        }
        public static string VistaFacturaClienteTipo_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.FACTURA_CLIENTE_TIPOColumnName; }
        }
        public static string VistaFacturaClienteVendedorId_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.FACTURA_CLIENTE_VENDEDOR_IDColumnName; }
        }
        public static string VistaFacturaClienteVendedorCod_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.FACTURA_CLIENTE_VENDEDOR_CODColumnName; }
        }
        public static string VistaFacturaClienteVendedorNombre_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.FACTURA_CLIENTE_VENDEDOR_NOMBRColumnName; }
        }
        public static string VistaFechaUltimoPago_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.FECHA_ULTIMO_PAGOColumnName; }
        }
        public static string VistaFechaVencimientoTexto_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.FECHA_VENCIMIENTO_TEXTOColumnName; }
        }
        public static string VistaFlujoId_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.FLUJO_IDColumnName; }
        }
        public static string VistaFlujoNombre_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.FLUJO_NOMBREColumnName; }
        }
        public static string VistaJuegoPagaresAprobado_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.JUEGO_PAGARES_APROBADOColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.MONEDA_CANTIDAD_DECIMALESColumnName; }
        }
        public static string VistaMonedaCadenaDecimales_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.MONEDA_CADENA_DECIMALESColumnName; }
        }
        public static string VistaMontoEnProceso_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.MONTO_EN_PROCESOColumnName; }
        }
        public static string VistaObservacion_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.OBSERVACIONColumnName; }
        }
        public static string VistaRetencionAplicada_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.RETENCION_APLICADAColumnName; }
        }
        public static string VistaSaldoDebito_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.SALDO_DEBITOColumnName; }
        }
        public static string VistaCuota_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.CUOTAColumnName; }
        }
        public static string VistaPersonaEmail1_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.PERSONA_EMAIL1ColumnName; }
        }
        public static string VistaPersonaEmail2_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.PERSONA_EMAIL2ColumnName; }
        }
        public static string VistaPersonaEmail3_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.PERSONA_EMAIL3ColumnName; ; }
        }

        public static string VistaPersonaTelefono1_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.PERSONA_TELEFONO1ColumnName; }
        }
        public static string VistaPersonaTelefono2_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.PERSONA_TELEFONO2ColumnName; }
        }
        public static string VistaPersonaTelefono3_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.PERSONA_TELEFONO3ColumnName; ; }
        }
        public static string VistaPersonaTelefono4_NombreCol
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.PERSONA_TELEFONO4ColumnName; ; }
        }
        public static string VistaCasoEstadoId
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.CASO_ESTADO_IDColumnName; ; }
        }
        public static string VistaSucursalId
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaSucursalRegionId
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.SUCURSAL_REGION_IDColumnName; }
        }
        public static string VistaSucursalRegionNombre
        {
            get { return CTACTE_PERSONAS_INFO_COMPLETACollection.SUCURSAL_REGION_NOMBREColumnName; }
        }
        public static string SQLTotalDeuda
        {
            get { return "SUMA"; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static CuentaCorrientePersonasService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new CuentaCorrientePersonasService(e.RegistroId, sesion);
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
        protected CTACTE_PERSONASRow row;
        protected CTACTE_PERSONASRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? AplicacionDocumentosId { get { if (row.IsAPLICACION_DOCUMENTOS_IDNull) return null; else return row.APLICACION_DOCUMENTOS_ID; } set { if (value.HasValue) row.APLICACION_DOCUMENTOS_ID = value.Value; else row.IsAPLICACION_DOCUMENTOS_IDNull = true; } }
        public decimal? AplicacionDocumentosValId { get { if (row.IsAPLICACION_DOCUMENTOS_VAL_IDNull) return null; else return row.APLICACION_DOCUMENTOS_VAL_ID; } set { if (value.HasValue) row.APLICACION_DOCUMENTOS_VAL_ID = value.Value; else row.IsAPLICACION_DOCUMENTOS_VAL_IDNull = true; } }
        public decimal? AplicacionDocumentosRecId { get { if (row.IsAPLICACION_DOCUMENTOS_REC_IDNull) return null; else return row.APLICACION_DOCUMENTOS_REC_ID; } set { if (value.HasValue) row.APLICACION_DOCUMENTOS_REC_ID = value.Value; else row.IsAPLICACION_DOCUMENTOS_REC_IDNull = true; } }
        public string Bloqueado { get { return row.BLOQUEADO; } set { row.BLOQUEADO = value; } }
        public decimal? CalendarioPagosCRCliId { get { if (row.IsCALENDARIO_PAGOS_CR_CLI_IDNull) return null; else return row.CALENDARIO_PAGOS_CR_CLI_ID; } set { if (value.HasValue) row.CALENDARIO_PAGOS_CR_CLI_ID = value.Value; else row.IsCALENDARIO_PAGOS_CR_CLI_IDNull = true; } }
        public decimal? CalendarioPagosFCCliId { get { if (row.IsCALENDARIO_PAGOS_FC_CLI_IDNull) return null; else return row.CALENDARIO_PAGOS_FC_CLI_ID; } set { if (value.HasValue) row.CALENDARIO_PAGOS_FC_CLI_ID = value.Value; else row.IsCALENDARIO_PAGOS_FC_CLI_IDNull = true; } }
        public decimal? CasoId { get { if (row.IsCASO_IDNull) return null; else return row.CASO_ID; } set { if (value.HasValue) row.CASO_ID = value.Value; else row.IsCASO_IDNull = true; } }
        public string Concepto { get { return ClaseCBABase.GetStringHelper(row.CONCEPTO); } set { row.CONCEPTO = value; } }
        public decimal CotizacionMoneda { get { return row.COTIZACION_MONEDA; } set { row.COTIZACION_MONEDA = value; } }
        public decimal Credito { get { return row.CREDITO; } set { row.CREDITO = value; } }
        public decimal CtacteConceptoId { get { return row.CTACTE_CONCEPTO_ID; } set { row.CTACTE_CONCEPTO_ID = value; } }
        public decimal? CtacteDocumentoVencId { get { if (row.IsCTACTE_DOCUMENTO_VENC_IDNull) return null; else return row.CTACTE_DOCUMENTO_VENC_ID; } set { if (value.HasValue) row.CTACTE_DOCUMENTO_VENC_ID = value.Value; else row.IsCTACTE_DOCUMENTO_VENC_IDNull = true; } }
        public decimal? CtactePagareDetId { get { if (row.IsCTACTE_PAGARE_DET_IDNull) return null; else return row.CTACTE_PAGARE_DET_ID; } set { if (value.HasValue) row.CTACTE_PAGARE_DET_ID = value.Value; else row.IsCTACTE_PAGARE_DET_IDNull = true; } }
        public decimal? CtactePagareDocId { get { if (row.IsCTACTE_PAGARE_DOC_IDNull) return null; else return row.CTACTE_PAGARE_DOC_ID; } set { if (value.HasValue) row.CTACTE_PAGARE_DOC_ID = value.Value; else row.IsCTACTE_PAGARE_DOC_IDNull = true; } }
        public decimal? CtactePagoPersonaDetId { get { if (row.IsCTACTE_PAGO_PERSONA_DET_IDNull) return null; else return row.CTACTE_PAGO_PERSONA_DET_ID; } set { if (value.HasValue) row.CTACTE_PAGO_PERSONA_DET_ID = value.Value; else row.IsCTACTE_PAGO_PERSONA_DET_IDNull = true; } }
        public decimal? CtactePagoPersonaDocId { get { if (row.IsCTACTE_PAGO_PERSONA_DOC_IDNull) return null; else return row.CTACTE_PAGO_PERSONA_DOC_ID; } set { if (value.HasValue) row.CTACTE_PAGO_PERSONA_DOC_ID = value.Value; else row.IsCTACTE_PAGO_PERSONA_DOC_IDNull = true; } }
        public decimal? CtactePagoPersonaRecId { get { if (row.IsCTACTE_PAGO_PERSONA_REC_IDNull) return null; else return row.CTACTE_PAGO_PERSONA_REC_ID; } set { if (value.HasValue) row.CTACTE_PAGO_PERSONA_REC_ID = value.Value; else row.IsCTACTE_PAGO_PERSONA_REC_IDNull = true; } }
        public decimal? CtactePersonaRelacionadaId { get { if (row.IsCTACTE_PERSONA_RELACIONADA_IDNull) return null; else return row.CTACTE_PERSONA_RELACIONADA_ID; } set { if (value.HasValue) row.CTACTE_PERSONA_RELACIONADA_ID = value.Value; else row.IsCTACTE_PERSONA_RELACIONADA_IDNull = true; } }
        public decimal? CtacteValorId { get { if (row.IsCTACTE_VALOR_IDNull) return null; else return row.CTACTE_VALOR_ID; } set { if (value.HasValue) row.CTACTE_VALOR_ID = value.Value; else row.IsCTACTE_VALOR_IDNull = true; } }
        public decimal? CuotaNumero { get { if (row.IsCUOTA_NUMERONull) return null; else return row.CUOTA_NUMERO; } set { if (value.HasValue) row.CUOTA_NUMERO = value.Value; else row.IsCUOTA_NUMERONull = true; } }
        public decimal? CuotaTotal { get { if (row.IsCUOTA_TOTALNull) return null; else return row.CUOTA_TOTAL; } set { if (value.HasValue) row.CUOTA_TOTAL = value.Value; else row.IsCUOTA_TOTALNull = true; } }
        public decimal Debito { get { return row.DEBITO; } set { row.DEBITO = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime FechaInsercion { get { return row.FECHA_INSERCION; } set { row.FECHA_INSERCION = value; } }
        public DateTime? FechaPostergacion { get { if (row.IsFECHA_POSTERGACIONNull) return null; else return row.FECHA_POSTERGACION; } set { if (value.HasValue) row.FECHA_POSTERGACION = value.Value; else row.IsFECHA_POSTERGACIONNull = true; } }
        public DateTime FechaVencimiento { get { return row.FECHA_VENCIMIENTO; } set { row.FECHA_VENCIMIENTO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Judicial { get { return row.JUDICIAL; } set { row.JUDICIAL = value; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal? OrdenPagoId { get { if (row.IsORDEN_PAGO_IDNull) return null; else return row.ORDEN_PAGO_ID; } set { if (value.HasValue) row.ORDEN_PAGO_ID = value.Value; else row.IsORDEN_PAGO_IDNull = true; } }
        public decimal PersonaId { get { return row.PERSONA_ID; } set { row.PERSONA_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private string _tipo_documento;
        public string TipoDocumento
        {
            get
            {
                if (ClaseCBABase.GetStringHelper(this._tipo_documento).Length <= 0)
                {
                    if (this.CasoId.HasValue)
                    {
                        switch((int)this.Caso.FlujoId)
                        {
                            case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                                var facturaCliente = FacturasClienteService.GetPorCaso(this.CasoId.Value);
                                this._tipo_documento = facturaCliente.TipoFacturaId;
                                break;
                            case Definiciones.FlujosIDs.CREDITOS:
                                this._tipo_documento = Definiciones.CondicionPagoTipo.CREDITO;
                                break;
                            case Definiciones.FlujosIDs.PAGO_DE_PERSONAS:
                                if (this.CtacteConceptoId == Definiciones.CuentaCorrienteConceptos.Recargo)
                                {
                                    var pagoPersona = PagosDePersonaService.GetPorCaso(this.CasoId.Value);
                                    if(pagoPersona.FCCliente1CompAutonId.HasValue)
                                        this._tipo_documento = Definiciones.CondicionPagoTipo.CONTADO;
                                    else
                                        this._tipo_documento = Definiciones.CondicionPagoTipo.CREDITO;
                                }
                                break;
                            case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                                var facturaProveedor = FacturasProveedorService.GetPorCaso(this.CasoId.Value);
                                this._tipo_documento = facturaProveedor.CtacteCondicionPago.TipoCondicionPago;
                                break;
                            case Definiciones.FlujosIDs.REFINANCIACION_DEUDAS:
                                this._tipo_documento = Definiciones.CondicionPagoTipo.CREDITO;
                                break;
                        }
                    }
                }

                if (ClaseCBABase.GetStringHelper(this._tipo_documento).Length <= 0)
                    throw new Exception("CuentaCorrientePersonasService. Tipo de documento no encontrado.");

                return this._tipo_documento;
            }
        }

        private CuentaCorrienteConceptosService _ctacte_concepto;
        public CuentaCorrienteConceptosService CtacteConcepto
        {
            get
            {
                if (this._ctacte_concepto == null)
                    this._ctacte_concepto = new CuentaCorrienteConceptosService(this.CtacteConceptoId);
                return this._ctacte_concepto;
            }
        }
        
        private CasosService _caso;
        public CasosService Caso
        {
            get
            {
                if (this._caso == null)
                {
                    //Descomentar cuando la clase sea orientada a objetos
                    //if(this.sesion != null)
                    //    this._caso = new CasosService(this.CasoId.Value, this.sesion);
                    //else
                    //    this._caso = new CasosService(this.CasoId.Value);

                    //Workaround a que sea un Pago de Personas que no guarda caso al insertar los pagos
                    if (this.CasoId.HasValue)
                        this._caso = new CasosService(this.CasoId.Value);
                    else if (this.CtactePagoPersonaDocId.HasValue)
                        this._caso = new CuentaCorrientePagosPersonaDocumentoService(this.CtactePagoPersonaDocId.Value).CtactePagosPersona.Caso;
                }
                return this._caso;
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

        private PersonasService _persona;
        public PersonasService Persona
        {
            get
            {
                if (this._persona == null)
                {
                    //Descomentar cuando la clase sea orientada a objetos
                    //if (this.sesion != null)
                    //    this._persona = new PersonasService(this.PersonaId, this.sesion);
                    //else
                    this._persona = new PersonasService(this.PersonaId);
                }
                return this._persona;
            }
        }

        private CreditosService.CalendarioService _calendario_pagos_cr_cli;
        public CreditosService.CalendarioService CalendarioPagosCRCli
        {
            get
            {
                if (this._calendario_pagos_cr_cli == null)
                {
                    //Descomentar cuando la clase sea orientada a objetos
                    //if (this.sesion != null)
                    //    this._calendario_pagos_cr_cli = new CreditosService.CalendarioService(this.CalendarioPagosCRCliId.Value, this.sesion);
                    //else
                    this._calendario_pagos_cr_cli = new CreditosService.CalendarioService(this.CalendarioPagosCRCliId.Value);
                }
                return this._calendario_pagos_cr_cli;
            }
        }

        private CuentaCorrientePersonasService _ctacte_persona_relacionada;
        public CuentaCorrientePersonasService CtactePersonaRelacionada
        {
            get
            {
                if (this._ctacte_persona_relacionada == null)
                    this._ctacte_persona_relacionada = new CuentaCorrientePersonasService(this.CtactePersonaRelacionadaId.Value);
                return this._ctacte_persona_relacionada;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_PERSONASCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_PERSONASRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true;
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(CTACTE_PERSONASRow row)
        {
            this.AlmacenarLocalmente = true;
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public CuentaCorrientePersonasService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrientePersonasService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CuentaCorrientePersonasService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        //Constructor temporal hasta que la clase se convierta a orientacion a objetos y pueda usarse el metodo Get
        public CuentaCorrientePersonasService(string columna, decimal id, SessionService sesion)
        {
            string clausulas = columna + " = " + id + " and " +
                               CTACTE_PERSONASCollection.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' ";

            var rows = sesion.db.CTACTE_PERSONASCollection.GetAsArray(clausulas, CTACTE_PERSONASCollection.IDColumnName);
            if (rows.Length > 0)
            {
                this.row = rows[0];
            }
            else
            {
                this.row = new CTACTE_PERSONASRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        public CuentaCorrientePersonasService(EdiCBA.CtactePersona edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = CuentaCorrientePagosPersonaDocumentoService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 
            this.Estado = Definiciones.Estado.Activo;

            if (edi.caso_id.HasValue)
                this.CasoId = edi.caso_id.Value;

            if (edi.cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion'.");
            this.CotizacionMoneda = edi.cotizacion.venta;

            this.CuotaNumero = edi.cuota_numero;
            this.CuotaTotal = edi.cuota_total;
            this.Credito = edi.credito;
            this.Debito = edi.debito;
            this.FechaInsercion = edi.fecha_creacion;
            this.FechaVencimiento = edi.fecha_vencimiento;
            this.CtacteValorId = edi.tipo_valor;
            this._tipo_documento = edi.tipo_documento;

            #region ctacte persona relacionada
            if (!string.IsNullOrEmpty(edi.ctacte_persona_relacionada_uuid))
                this._ctacte_persona_relacionada = CuentaCorrientePersonasService.GetPorUUID(edi.ctacte_persona_relacionada_uuid, sesion);
            if (this._ctacte_persona_relacionada == null && edi.ctacte_persona_relacionada != null)
                this._ctacte_persona_relacionada = new CuentaCorrientePersonasService(edi.ctacte_persona_relacionada, almacenar_localmente, sesion);
            if (this._ctacte_persona_relacionada != null)
            {
                if (!this.CtactePersonaRelacionada.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.CtactePersonaRelacionada.Id.HasValue)
                    this.CtactePersonaRelacionadaId = this.CtactePersonaRelacionada.Id.Value;
            }
            #endregion ctacte persona relacionada

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

            #region persona
            if (!string.IsNullOrEmpty(edi.persona_uuid))
                this._persona = PersonasService.GetPorUUID(edi.persona_uuid, sesion);
            if (this._persona == null && edi.persona != null)
                this._persona = new PersonasService(edi.persona, almacenar_localmente, sesion);
            if (this._persona == null)
                throw new Exception("No se encontró el UUID " + edi.persona_uuid + " ni se definieron los datos del objeto.");

            if (!this.Persona.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Persona.Id.HasValue)
                this.PersonaId = this.Persona.Id.Value;
            #endregion persona
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._ctacte_concepto = null;
            this._calendario_pagos_cr_cli = null;
            this._caso = null;
            this._moneda = null;
            this._persona = null;
            this._tipo_documento = string.Empty;
        }
        #endregion ResetearPropiedadesExtendidas

        #region GetCasoBloquea
        public CasosService GetCasoBloquea()
        {
            using (SessionService sesion = new SessionService())
            {
                return this.GetCasoBloquea(sesion);
            }
        }

        public CasosService GetCasoBloquea(SessionService sesion)
        {
            CasosService caso = null;

            if (this.Bloqueado != Definiciones.SiNo.Si)
                return caso;

            string sql = "select cpp." + PagosDePersonaService.CasoId_NombreCol + " " + CasosService.Id_NombreCol + " /* Pago de Personas en borrador */" +
                         "  from " + PagosDePersonaService.Nombre_Tabla + " cpp, " +
                         "       " + CuentaCorrientePagosPersonaDocumentoService.Nombre_Tabla + " cppd, " +
                         "       " + CasosService.Nombre_Tabla + " c " +
                         " where cppd." + CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = cpp." + PagosDePersonaService.Id_NombreCol +
                         "   and cpp." + PagosDePersonaService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol +  
                         "   and cppd." + CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol + " = " + this.Id +  
                         "   and cpp." + PagosDePersonaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                         "   and cppd." + CuentaCorrientePagosPersonaDocumentoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                         "   and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                         "   and c." + CasosService.EstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Borrador + "'" +
                         " union " +
                         "select cpp." + PagosDePersonaService.CasoId_NombreCol + " /* Pago de Personas abierto (compensacion) */" +
                         "  from " + PagosDePersonaService.Nombre_Tabla + " cpp, " +
                         "       " + CuentaCorrientePagosPersonaCompensacionEntradaService.Nombre_Tabla + " cppe, " +
                         "       " + CasosService.Nombre_Tabla + " c " +
                         " where cppe." + CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePagosPersonaId_NombreCol + " = cpp." + PagosDePersonaService.Id_NombreCol +
                         "   and cpp." + PagosDePersonaService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol +  
                         "   and cppe." + CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePersonaId_NombreCol + " = " + this.Id +  
                         "   and cpp." + PagosDePersonaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                         "   and cppe." + CuentaCorrientePagosPersonaCompensacionEntradaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                         "   and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                         "   and c." + CasosService.EstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Abierto + "'" +
                         " union " +
                         "select ad." + NotasCreditoPersonaAplicacionesService.CasoId_NombreCol + " /* Aplicacion de documentos en borrador o pendiente */" +
                         "  from " + NotasCreditoPersonaAplicacionesService.Nombre_Tabla + " ad," +
                         "       " + NotasCreditoPersonaAplicacionDocumentosService.Nombre_Tabla + " addx," +
                         "       " + CasosService.Nombre_Tabla + " c " +
                         " where addx." + NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocumentoId_NombreCol + " = ad." + NotasCreditoPersonaAplicacionesService.Id_NombreCol +
                         "   and ad." + NotasCreditoPersonaAplicacionesService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol +  
                         "   and addx." + NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol + " = " + this.Id +  
                         "   and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                         "   and c." + CasosService.EstadoId_NombreCol + " in ('" + Definiciones.EstadosFlujos.Borrador + "', '" + Definiciones.EstadosFlujos.Pendiente + "')" +
                         " union " +
                         "select pc." + PlanillaCobranzaService.CasoId_NombreCol + " /* Planilla de Cobranza en borrador, en-proces o rendicion */" +
                         "  from " + PlanillaCobranzaService.Nombre_Tabla + " pc," +
                         "       " + PlanillaParaCobranzaService.Nombre_Tabla + " ppc," +
                         "       " + CasosService.Nombre_Tabla + " c " +
                         " where ppc." + PlanillaParaCobranzaService.PlanillaDeCobranzaId_NombreCol + " = pc." + PlanillaCobranzaService.Id_NombreCol +
                         "   and pc." + PlanillaCobranzaService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol +  
                         "   and ppc." + PlanillaParaCobranzaService.CtaCtePersonaId_NombreCol + " = " + this.Id +  
                         "   and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                         "   and c." + CasosService.EstadoId_NombreCol + " in ('" + Definiciones.EstadosFlujos.Borrador + "', '" + Definiciones.EstadosFlujos.EnProceso + "', '" + Definiciones.EstadosFlujos.Rendicion + "')";

            DataTable dt = sesion.db.EjecutarQuery(sql);
            if (dt.Rows.Count > 0)
                caso = new CasosService((decimal)dt.Rows[0][CasosService.Id_NombreCol], sesion);

            return caso;
        }
        #endregion GetCasoBloquea

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.CtactePersona()
            {
                caso_id = this.CasoId,
                cotizacion_uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, CuentaCorrientePersonasService.CotizacionMoneda_NombreCol, this.Id.Value, sesion),
                credito = this.Credito,
                ctacte_persona_relacionada_uuid = this.CtactePersonaRelacionadaId.HasValue ? this.CtactePersonaRelacionada.GetOrCreateUUID(sesion) : null,
                cuota_numero = this.CuotaNumero.Value,
                cuota_total = this.CuotaTotal.Value,
                debito = this.Debito,
                fecha_creacion = this.FechaInsercion,
                fecha_vencimiento = this.FechaVencimiento,
                moneda_uuid = this.Moneda.GetOrCreateUUID(sesion),
                persona_uuid = this.Persona.GetOrCreateUUID(sesion),
                tipo_valor = (int)this.CtacteValorId.Value
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.ctacte_persona_relacionada = (EdiCBA.CtactePersona)this.CtactePersonaRelacionada.ToEDI(nueva_profundidad, sesion);
                e.cotizacion = new EdiCBA.Cotizacion()
                {
                    uuid = e.cotizacion_uuid,
                    fecha = this.CasoId.HasValue ? this.Caso.FechaFormulario.Value : this.FechaInsercion,
                    moneda_uuid = e.moneda_uuid,
                    venta = this.CotizacionMoneda
                };
                e.moneda = (EdiCBA.Moneda)this.Moneda.ToEDI(nueva_profundidad, sesion);
                e.persona = (EdiCBA.Persona)this.Persona.ToEDI(nueva_profundidad, sesion);
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
