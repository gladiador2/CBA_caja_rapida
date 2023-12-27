using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.NotaCreditosProveedores;
using System.Collections;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class PlanillaCobranzaDetallesService
    {
        #region GetPlanillaDetalles
        public static DataTable GetPlanillaDetalles(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPlanillaDetalles(where, orden, sesion);
            }
        }

        public static DataTable GetPlanillaDetalles(string where, string orden, SessionService sesion)
        {
            return sesion.Db.PLANILLA_COBRANZA_DETALLESCollection.GetAsDataTable(where, orden);
        }
        #endregion GetPlanillaDetalles

        #region GetPlanillaDetallesInfoCompletaPorPlanilla
        public DataTable GetPlanillaDetallesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PLANILLA_COBR_DET_INF_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPlanillaDetallesInfoCompletaPorPlanilla

        #region ActulizarCasoPago
        public static void ActulizarCasoPago(decimal planilla_detalle_id, decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    ActulizarCasoPago(planilla_detalle_id, caso_id, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void ActulizarCasoPago(decimal planilla_detalle_id, decimal caso_id, SessionService sesion)
        {
            PLANILLA_COBRANZA_DETALLESRow row = sesion.Db.PLANILLA_COBRANZA_DETALLESCollection.GetByPrimaryKey(planilla_detalle_id);
            string valorAnterior = row.ToString();

            if (caso_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                row.IsCASO_PAGO_IDNull = true;
            else
                row.CASO_PAGO_ID = caso_id;

            sesion.Db.PLANILLA_COBRANZA_DETALLESCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion ActulizarCasoPago

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool esNuevo, SessionService sesion)
        {
            decimal montoAnterior = 0;
            decimal cobradoanterior = 0;
            PLANILLA_COBRANZA_DETALLESRow row = new PLANILLA_COBRANZA_DETALLESRow();
            string valorAnterior = string.Empty;

            if (esNuevo)
            {
                valorAnterior = Definiciones.Log.RegistroNuevo;
                //campos identificatorios
                row.ID = sesion.Db.GetSiguienteSecuencia("PLANILLA_COBRANZA_DETALLES_SQC");
            }
            else
            {
                decimal id = (decimal)campos[PlanillaCobranzaDetallesService.Id_NombreCol];
                row = sesion.Db.PLANILLA_COBRANZA_DETALLESCollection.GetByPrimaryKey(id);
                valorAnterior = row.ToString();
            }

            if (campos.Contains(PlanillaCobranzaDetallesService.PlanillaCobranzaId_NombreCol))
                row.PLANILLA_COBRANZA_ID = (decimal)campos[PlanillaCobranzaDetallesService.PlanillaCobranzaId_NombreCol];
            
            if (campos.Contains(PlanillaCobranzaDetallesService.PersonaId_NombreCol))
                row.PERSONA_ID = (decimal)campos[PlanillaCobranzaDetallesService.PersonaId_NombreCol];
            
            if (campos.Contains(PlanillaCobranzaDetallesService.Observacion_NombreCol))
                row.OBSERVACION = (string)campos[PlanillaCobranzaDetallesService.Observacion_NombreCol];
            
            if (campos.Contains(PlanillaCobranzaDetallesService.CtaCteReciboImpresoId_NombreCol))
                row.CTACTE_RECIBO_IMPRESO_ID = (decimal)campos[PlanillaCobranzaDetallesService.CtaCteReciboImpresoId_NombreCol];
            
            if (campos.Contains(PlanillaCobranzaDetallesService.CtaCteReciboEntregadoId_NombreCol))
                row.CTACTE_RECIBO_ENTREGADO_ID = (decimal)campos[PlanillaCobranzaDetallesService.CtaCteReciboEntregadoId_NombreCol];

            if (!row.IsMONEDA_COBRADO_IDNull)
                cobradoanterior = row.MONTO_COBRADO;
            row.MONTO_COBRADO = (decimal)campos[PlanillaCobranzaDetallesService.MontoCobrado_NombreCol];

            montoAnterior = esNuevo ? 0 : row.MONTO_CUOTA;
            row.MONTO_CUOTA = (decimal)campos[PlanillaCobranzaDetallesService.MontoCuota_NombreCol];

            montoAnterior += esNuevo ? 0 : row.MONTO_MORA;
            row.MONTO_MORA = (decimal)campos[PlanillaCobranzaDetallesService.MontoMora_NombreCol];
            
            if (campos.Contains(PlanillaCobranzaDetallesService.MonedaId_NombreCol))
                row.MONEDA_ID = (decimal)campos[PlanillaCobranzaDetallesService.MonedaId_NombreCol];
            if (campos.Contains(PlanillaCobranzaDetallesService.MonedaCobradoId_NombreCol))
                row.MONEDA_COBRADO_ID = (decimal)campos[PlanillaCobranzaDetallesService.MonedaCobradoId_NombreCol];
            if (campos.Contains(PlanillaCobranzaDetallesService.DireccionCobro_NombreCol))
                row.DIRECCION_COBRO = (string)campos[PlanillaCobranzaDetallesService.DireccionCobro_NombreCol];
            if (campos.Contains(PlanillaCobranzaDetallesService.CotizacionCobrado_NombreCol))
                row.COTIZACION_COBRADA = (decimal)campos[PlanillaCobranzaDetallesService.CotizacionCobrado_NombreCol];
            if (campos.Contains(PlanillaCobranzaDetallesService.Cobrado_NombreCol))
                row.COBRADO = (string)campos[PlanillaCobranzaDetallesService.Cobrado_NombreCol];
            if (campos.Contains(PlanillaCobranzaDetallesService.CasoPagoId_NombreCol))
                row.CASO_PAGO_ID = (decimal)campos[PlanillaCobranzaDetallesService.CasoPagoId_NombreCol];

            //insercion o actaulizacion del detalle
            if (esNuevo)
                sesion.Db.PLANILLA_COBRANZA_DETALLESCollection.Insert(row);
            else
                sesion.Db.PLANILLA_COBRANZA_DETALLESCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            //actualizacion del monto del recibo
            if (!row.IsCTACTE_RECIBO_IMPRESO_IDNull)
            {
                if (row.MONTO_CUOTA + row.MONTO_MORA != montoAnterior)
                    CuentaCorrienteRecibosService.ActulizarMonto(row.CTACTE_RECIBO_IMPRESO_ID, row.MONTO_CUOTA + row.MONTO_MORA, sesion);
            }
            if (!row.IsCTACTE_RECIBO_ENTREGADO_IDNull)
            {
                if (row.MONTO_COBRADO != cobradoanterior)
                    CuentaCorrienteRecibosService.ActulizarMonto(row.CTACTE_RECIBO_ENTREGADO_ID, row.MONTO_COBRADO, sesion);
            }
            return row.ID;
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified planilla_detalle_id.
        /// </summary>
        /// <param name="planilla_detalle_id">The planilla_detalle_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal planilla_detalle_id, SessionService sesion)
        {
            PLANILLA_COBRANZA_DETALLESRow row = new PLANILLA_COBRANZA_DETALLESRow();
            row = sesion.Db.PLANILLA_COBRANZA_DETALLESCollection.GetByPrimaryKey(planilla_detalle_id);
            sesion.Db.PLANILLA_COBRANZA_DETALLESCollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

            if (!row.IsCTACTE_RECIBO_IMPRESO_IDNull)
                CuentaCorrienteRecibosService.Anular(row.CTACTE_RECIBO_IMPRESO_ID, sesion);

            if (!row.IsCTACTE_RECIBO_ENTREGADO_IDNull)
                CuentaCorrienteRecibosService.Anular(row.CTACTE_RECIBO_ENTREGADO_ID, sesion);
        }
        #endregion Borrar

        #region GenerarDetalles
        /// <summary>
        /// Generars the detalles.
        /// </summary>
        /// <param name="planilla_cobranza_id">The planilla_cobranza_id.</param>
        public static void GenerarDetalles(decimal planilla_cobranza_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    DataTable dtPlanillaDetalles;

                    DataTable dtParaCobranza;
                    DataRow[] drParaCobranza;
                    DataTable dtFiltradoPorPersona;
                    DataTable dtFiltraodPorMoneda;

                    string resultadoMontoCuota = string.Empty, resultadoMontoMora = string.Empty;
                    string resultadoCobrado = string.Empty;

                    decimal montoCuota = 0, montoMora = 0;
                    decimal cobrado = 0;
                    decimal planillaCobranzaDetalleId;

                    Hashtable campos = new Hashtable();

                    #region Actualizacion de los Detalles ya Existentes
                    //Se obtienen los datos de la planilla para cobranza que deben ser actualizados
                    string clausulasParaCobranza = PlanillaParaCobranzaService.PlanillaDeCobranzaId_NombreCol + " = " + planilla_cobranza_id;
                    dtParaCobranza = PlanillaParaCobranzaService.GetPlanillaParaCobranzaInfoCompleta(clausulasParaCobranza, PlanillaParaCobranzaService.Id_NombreCol, sesion);

                    // se obtienen los detalles de la planilla de cobranza
                    string clausualasDetalle = PlanillaCobranzaDetallesService.PlanillaCobranzaId_NombreCol + " = " + +planilla_cobranza_id;
                    dtPlanillaDetalles = PlanillaCobranzaDetallesService.GetPlanillaDetalles(clausualasDetalle, PlanillaCobranzaDetallesService.Id_NombreCol, sesion);

                    string clausula = string.Empty;
                    //se itera sobre el resultado de los detalles para buscar los datos que deben ser actualizados
                    for (int d = 0; d < dtPlanillaDetalles.Rows.Count; d++)
                    {
                        clausula = PlanillaParaCobranzaService.VistaPersonaId_NombreCol + " = " + dtPlanillaDetalles.Rows[d][PlanillaCobranzaDetallesService.PersonaId_NombreCol].ToString();
                        clausula += " and " + PlanillaParaCobranzaService.VistaMonedaId_NombreCol + " = " + dtPlanillaDetalles.Rows[d][PlanillaCobranzaDetallesService.MonedaId_NombreCol].ToString();
                        drParaCobranza = dtParaCobranza.Select(clausula);
                        if (drParaCobranza.Length > 0)
                        {
                            clausula = PlanillaParaCobranzaService.VistaPersonaId_NombreCol + "=" + dtPlanillaDetalles.Rows[d][PlanillaCobranzaDetallesService.PersonaId_NombreCol].ToString();
                            clausula += " and " + PlanillaParaCobranzaService.VistaMonedaId_NombreCol + "=" + dtPlanillaDetalles.Rows[d][PlanillaCobranzaDetallesService.MonedaId_NombreCol].ToString();
                            resultadoMontoCuota = dtParaCobranza.Compute("Sum(" + PlanillaParaCobranzaService.MontoCuota_NombreCol + ")", clausula).ToString();
                            resultadoMontoMora = dtParaCobranza.Compute("Sum(" + PlanillaParaCobranzaService.MontoMora_NombreCol + ")", clausula).ToString();
                            resultadoCobrado = dtParaCobranza.Compute("Sum(" + PlanillaParaCobranzaService.Cobrado_NombreCol + ")", clausula).ToString();

                            if (decimal.TryParse(resultadoMontoCuota, out montoCuota) && decimal.TryParse(resultadoMontoMora, out montoMora) && decimal.TryParse(resultadoCobrado, out cobrado))
                            {
                                campos = null;
                                campos = new Hashtable();
                                campos.Add(PlanillaCobranzaDetallesService.DireccionCobro_NombreCol, dtPlanillaDetalles.Rows[d][PlanillaCobranzaDetallesService.DireccionCobro_NombreCol]);
                                campos.Add(PlanillaCobranzaDetallesService.MonedaId_NombreCol, (decimal)dtPlanillaDetalles.Rows[d][PlanillaCobranzaDetallesService.MonedaId_NombreCol]);
                                campos.Add(PlanillaCobranzaDetallesService.PersonaId_NombreCol, (decimal)dtPlanillaDetalles.Rows[d][PlanillaCobranzaDetallesService.PersonaId_NombreCol]);
                                campos.Add(PlanillaCobranzaDetallesService.PlanillaCobranzaId_NombreCol, planilla_cobranza_id);
                                campos.Add(PlanillaCobranzaDetallesService.MontoCuota_NombreCol, montoCuota);
                                campos.Add(PlanillaCobranzaDetallesService.MontoMora_NombreCol, montoMora);
                                campos.Add(PlanillaCobranzaDetallesService.MontoCobrado_NombreCol, cobrado);
                                campos.Add(PlanillaCobranzaDetallesService.MonedaCobradoId_NombreCol, (decimal)dtPlanillaDetalles.Rows[d][PlanillaCobranzaDetallesService.MonedaCobradoId_NombreCol]);
                                campos.Add(PlanillaCobranzaDetallesService.CotizacionCobrado_NombreCol, (decimal)dtPlanillaDetalles.Rows[d][PlanillaCobranzaDetallesService.CotizacionCobrado_NombreCol]);
                                campos.Add(PlanillaCobranzaDetallesService.Id_NombreCol, (decimal)dtPlanillaDetalles.Rows[d][PlanillaCobranzaDetallesService.Id_NombreCol]);
                                planillaCobranzaDetalleId = Guardar(campos, false, sesion);

                                for (int p = 0; p < drParaCobranza.Length; p++)
                                    PlanillaParaCobranzaService.ActualizarPlanillaCobranzaDetalleId((decimal)drParaCobranza[p][PlanillaParaCobranzaService.Id_NombreCol], planillaCobranzaDetalleId, sesion);
                            }
                        }
                    }
                    #endregion Actualizacion de los Detalles ya Existentes

                    #region Agregar los nuevos Detalles
                    // se obtienen las datos de la palnilla para la  cobranza que no tienen detalles de planilla de cobranza
                    clausulasParaCobranza = PlanillaParaCobranzaService.PlanillaDeCobranzaId_NombreCol + " = " + planilla_cobranza_id;
                    clausulasParaCobranza += " and " + PlanillaParaCobranzaService.PlanillaDeCobranzaDetalleId_NombreCol + " is null ";
                    dtParaCobranza = PlanillaParaCobranzaService.GetPlanillaParaCobranzaInfoCompleta(clausulasParaCobranza, PlanillaParaCobranzaService.Id_NombreCol, sesion);

                    dtFiltradoPorPersona = sesion.db.GetDistintos(PlanillaParaCobranzaService.Nombre_Vista, PlanillaParaCobranzaService.VistaPersonaId_NombreCol + "," + PlanillaParaCobranzaService.VistaPersonaDireccion_NombreCol, clausulasParaCobranza);
                    dtFiltraodPorMoneda = sesion.db.GetDistintos(PlanillaParaCobranzaService.Nombre_Vista, PlanillaParaCobranzaService.VistaMonedaId_NombreCol, clausulasParaCobranza);

                    for (int p = 0; p < dtFiltradoPorPersona.Rows.Count; p++)
                    {
                        for (int m = 0; m < dtFiltraodPorMoneda.Rows.Count; m++)
                        {
                            campos = null;
                            campos = new Hashtable();
                            string clausulas = string.Empty;
                            montoCuota = montoMora = 0;
                            clausulas += PlanillaParaCobranzaService.VistaPersonaId_NombreCol + " = " + dtFiltradoPorPersona.Rows[p][PlanillaParaCobranzaService.VistaPersonaId_NombreCol];
                            clausulas += " and " + PlanillaParaCobranzaService.VistaMonedaId_NombreCol + " = " + dtFiltraodPorMoneda.Rows[m][PlanillaParaCobranzaService.VistaMonedaId_NombreCol];
                            resultadoMontoCuota = dtParaCobranza.Compute("Sum(" + PlanillaParaCobranzaService.MontoCuota_NombreCol + ")", clausulas).ToString();
                            resultadoMontoMora = dtParaCobranza.Compute("Sum(" + PlanillaParaCobranzaService.MontoMora_NombreCol+ ")", clausulas).ToString();
                            resultadoCobrado = dtParaCobranza.Compute("Sum(" + PlanillaParaCobranzaService.Cobrado_NombreCol + ")", clausulas).ToString();

                            if (decimal.TryParse(resultadoMontoCuota, out montoCuota) && decimal.TryParse(resultadoMontoMora, out montoMora) && decimal.TryParse(resultadoCobrado, out cobrado))
                            {
                                campos.Add(PlanillaCobranzaDetallesService.DireccionCobro_NombreCol, dtFiltradoPorPersona.Rows[p][PlanillaParaCobranzaService.VistaPersonaDireccion_NombreCol]);
                                campos.Add(PlanillaCobranzaDetallesService.MonedaId_NombreCol, dtFiltraodPorMoneda.Rows[m][PlanillaParaCobranzaService.VistaMonedaId_NombreCol]);
                                campos.Add(PlanillaCobranzaDetallesService.PersonaId_NombreCol, dtFiltradoPorPersona.Rows[p][PlanillaParaCobranzaService.VistaPersonaId_NombreCol]);
                                campos.Add(PlanillaCobranzaDetallesService.PlanillaCobranzaId_NombreCol, planilla_cobranza_id);
                                campos.Add(PlanillaCobranzaDetallesService.MontoCuota_NombreCol, montoCuota);
                                campos.Add(PlanillaCobranzaDetallesService.MontoMora_NombreCol, montoMora);
                                campos.Add(PlanillaCobranzaDetallesService.MontoCobrado_NombreCol, cobrado);
                                campos.Add(PlanillaCobranzaDetallesService.MonedaCobradoId_NombreCol, dtFiltraodPorMoneda.Rows[m][PlanillaParaCobranzaService.VistaMonedaId_NombreCol]);
                                campos.Add(PlanillaCobranzaDetallesService.CotizacionCobrado_NombreCol, dtParaCobranza.Rows[0][PlanillaParaCobranzaService.VistaCotizacionMoneda_NombreCol]);
                                planillaCobranzaDetalleId = Guardar(campos, true, sesion);

                                drParaCobranza = dtParaCobranza.Select(clausulas);
                                for (int d1 = 0; d1 < drParaCobranza.Length; d1++)
                                    PlanillaParaCobranzaService.ActualizarPlanillaCobranzaDetalleId((decimal)drParaCobranza[d1][PlanillaParaCobranzaService.Id_NombreCol], planillaCobranzaDetalleId, sesion);
                            }
                        }
                    }
                    #endregion Agregar los nuevos Detalles

                    #region Borrar los detalles no existentes en la planilla para Cobranza
                    //Se obtienen los datos de la planilla para cobranza que deben ser borrados
                    if (dtParaCobranza.Rows.Count > 0)
                    {
                        clausualasDetalle = PlanillaCobranzaDetallesService.PlanillaCobranzaId_NombreCol + " = " + planilla_cobranza_id + " and " + 
                                            PlanillaCobranzaDetallesService.Id_NombreCol + " not in " + 
                                            "   (select x." + PlanillaParaCobranzaService.PlanillaDeCobranzaDetalleId_NombreCol + 
                                            "      from " + PlanillaParaCobranzaService.Nombre_Tabla + " x" +
                                            "     where x." + PlanillaParaCobranzaService.PlanillaDeCobranzaId_NombreCol + " = " + planilla_cobranza_id +
                                            "   )";
                        dtPlanillaDetalles = PlanillaCobranzaDetallesService.GetPlanillaDetalles(clausualasDetalle, PlanillaCobranzaDetallesService.Id_NombreCol, sesion);

                        for (int b = 0; b < dtPlanillaDetalles.Rows.Count; b++)
                            PlanillaCobranzaDetallesService.Borrar((decimal)dtPlanillaDetalles.Rows[b][PlanillasPagosDetallesService.Id_NombreCol], sesion);
                    }
                    #endregion Borrar los detalles no existentes en la planilla para Cobranza
                
                    sesion.CommitTransaction();
                }
                catch (Exception)
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion GenerarDetalles

        #region Generar Recibos
        public static void GenerarReciboImpreso( Hashtable campos, decimal detalle_id)
        {
             using (SessionService sesion = new SessionService())
             {
                 try
                 {
                     sesion.Db.BeginTransaction();
                     PLANILLA_COBRANZA_DETALLESRow row = new PLANILLA_COBRANZA_DETALLESRow();
                     string valorAnterior = string.Empty;

                     row = sesion.Db.PLANILLA_COBRANZA_DETALLESCollection.GetByPrimaryKey(detalle_id);
                     valorAnterior = row.ToString();
                     
                     row.CTACTE_RECIBO_IMPRESO_ID = CuentaCorrienteRecibosService.Guardar(campos, true, false, Definiciones.Error.Valor.EnteroPositivo, sesion);

                     sesion.Db.PLANILLA_COBRANZA_DETALLESCollection.Update(row);
                     LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                     sesion.Db.CommitTransaction();
                 } 
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void GenerarReciboEntregado(Hashtable campos, decimal detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    PLANILLA_COBRANZA_DETALLESRow row = new PLANILLA_COBRANZA_DETALLESRow();
                    string valorAnterior = string.Empty;

                    row = sesion.Db.PLANILLA_COBRANZA_DETALLESCollection.GetByPrimaryKey(detalle_id);
                    valorAnterior = row.ToString();

                    row.CTACTE_RECIBO_ENTREGADO_ID = CuentaCorrienteRecibosService.Guardar(campos, true, false, Definiciones.Error.Valor.EnteroPositivo, sesion);

                    sesion.Db.PLANILLA_COBRANZA_DETALLESCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Generar Recibos

        #region Anular Recibos
        public static void AnularRecibo(decimal recibo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                   sesion.Db.BeginTransaction();
                   CuentaCorrienteRecibosService.Anular(recibo_id, sesion);
                   sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Anular Recibos

        #region ActualizarRecibo
        public static void ActualizarRecibo(decimal detalle_id, decimal recibo_id, SessionService sesion)
        {
            PLANILLA_COBRANZA_DETALLESRow detalleRow = sesion.db.PLANILLA_COBRANZA_DETALLESCollection.GetByPrimaryKey(detalle_id);
            detalleRow.CTACTE_RECIBO_ENTREGADO_ID = recibo_id;
            sesion.db.PLANILLA_COBRANZA_DETALLESCollection.Update(detalleRow);
        }
        #endregion ActualizarRecibo

        #region Accessors
        #region Tablas
        public static string Nombre_Tabla
        {
            get { return "PLANILLA_COBRANZA_DETALLES"; }
        }

        public static string Id_NombreCol
        {
            get { return PLANILLA_COBRANZA_DETALLESCollection.IDColumnName; }
        }
        public static string CasoPagoId_NombreCol
        {
            get { return PLANILLA_COBRANZA_DETALLESCollection.CASO_PAGO_IDColumnName; }
        }
        public static string Cobrado_NombreCol
        {
            get { return PLANILLA_COBRANZA_DETALLESCollection.COBRADOColumnName; }
        }
        public static string CotizacionCobrado_NombreCol
        {
            get { return PLANILLA_COBRANZA_DETALLESCollection.COTIZACION_COBRADAColumnName; }
        }
        public static string DireccionCobro_NombreCol
        {
            get { return PLANILLA_COBRANZA_DETALLESCollection.DIRECCION_COBROColumnName; }
        }
        public static string MonedaCobradoId_NombreCol
        {
            get { return PLANILLA_COBRANZA_DETALLESCollection.MONEDA_COBRADO_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return PLANILLA_COBRANZA_DETALLESCollection.MONEDA_IDColumnName; }
        }
        public static string MontoCobrado_NombreCol
        {
            get { return PLANILLA_COBRANZA_DETALLESCollection.MONTO_COBRADOColumnName; }
        }
        public static string MontoCuota_NombreCol
        {
            get { return PLANILLA_COBRANZA_DETALLESCollection.MONTO_CUOTAColumnName; }
        }
        public static string MontoMora_NombreCol
        {
            get { return PLANILLA_COBRANZA_DETALLESCollection.MONTO_MORAColumnName; }
        }
        public static string CtaCteReciboEntregadoId_NombreCol
        {
            get { return PLANILLA_COBRANZA_DETALLESCollection.CTACTE_RECIBO_ENTREGADO_IDColumnName; }
        }
        public static string CtaCteReciboImpresoId_NombreCol
        {
            get { return PLANILLA_COBRANZA_DETALLESCollection.CTACTE_RECIBO_IMPRESO_IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return PLANILLA_COBRANZA_DETALLESCollection.OBSERVACIONColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return PLANILLA_COBRANZA_DETALLESCollection.PERSONA_IDColumnName; }
        }
        public static string PlanillaCobranzaId_NombreCol
        {
            get { return PLANILLA_COBRANZA_DETALLESCollection.PLANILLA_COBRANZA_IDColumnName; }
        }
        #endregion Tablas
        
        #region Vistas
        public static string Nombre_Vista
        {
            get { return "PLANILLA_COBR_DET_INF_COMPL"; }
        }
        public static string VistaCasoPagoComprobante_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.CASO_PAGO_COMPROBANTEColumnName; }
        }
        public static string VistaCasoPagoEstado_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.CASO_PAGO_ESTADOColumnName; }
        }
        public static string VistaMonedaCobradoNombre_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.MONEDA_COBRADO_NOMBREColumnName; }
        }
        public static string VistaMonedaCobradoSimbolo_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.MONEDA_COBRADO_SIMBOLOColumnName; }
        }
        public static string VistaMonedaCobradoDecimales_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.MONEDA_COBRADO_DECIMALESColumnName; }
        }
        public static string VistaMonedaCobradoCadenaDecimales_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.MONEDA_COBRAD_CADENA_DECIMALESColumnName; }
        }
        public static string VistaMonedaMontoNombre_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.MONEDA_MONTO_NOMBREColumnName; }
        }
        public static string VistaMonedaMontoSimbolo_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.MONEDA_MONTO_SIMBOLOColumnName; }
        }
        public static string VistaMonedaMontoDecimales_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.MONEDA_MONTO_DECIMALESColumnName; }
        }
        public static string VistaMonedaMontoCadenaDecimales_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.MONEDA_MONTO_CADENA_DECIMALESColumnName; }
        }
        public static string VistaPersonaCodigo_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.PERSONA_CODIGOColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaPagoConfirmado_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.PAGO_CONFIRMADOColumnName; }
        }
        public static string VistaPagoCajeroNombre_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.FUNCIONARIO_CAJERO_NOMBREColumnName; }
        }
        
        public static string VistaFechaPostergacion_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.FECHA_POSTERGACIONColumnName; }
        }
        public static string VistaNroReciboImpreso_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.NRO_RECIBO_IMPRESOColumnName; }
        }
        public static string VistaEstadoReciboImpreso_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.RECIBO_IMPRESO_ESTADOColumnName; }
        }
        public static string VistaTipoReciboImpreso_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.REC_IMPRESO_TALONARIO_TIPOColumnName; }
        }
        public static string VistaNroReciboEntregado_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.NRO_RECIBO_ENTREGADOColumnName; }
        }
        public static string VistaEstadoReciboEntregado_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.RECIBO_ENTREGADO_ESTADOColumnName; }
        }
        public static string VistaTipoReciboEntregado_NombreCol
        {
            get { return PLANILLA_COBR_DET_INF_COMPLCollection.REC_ENTREGADO_TALONARIO_TIPOColumnName; }
        }
        #endregion Vistas
        #endregion Accessors
    }
}
