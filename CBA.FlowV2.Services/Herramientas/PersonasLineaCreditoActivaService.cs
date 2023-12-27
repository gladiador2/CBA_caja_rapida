using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PersonasLineaCreditoActivaService
    {
        #region GetPersonasLineaCreditoActivaDataTable
        public DataTable GetPersonasLineaCreditoActivaDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.PERSONAS_LINEA_CREDITO_ACTIVACollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }

        public static DataTable GetPersonasLineaCreditoActivaDataTable2(decimal persona_id)
        {
            using (SessionService sesion = new SessionService()) {
                return GetPersonasLineaCreditoActivaDataTable2(persona_id, sesion);
            }
        }
        
        public static DataTable GetPersonasLineaCreditoActivaDataTable2(decimal persona_id, SessionService sesion) 
        {
            string query = "";
            query += "select plc.id personas_linea_credito_id, " + "\n";
            query += "       plc.temporal, " + "\n";
            query += "       plc.aprobado, " + "\n";
            query += "       plc.utilizado, " + "\n";
            query += "       plc.monto_linea_credito, " + "\n";
            query += "       plc.moneda_id, " + "\n";
            query += "       plc.cotizacion, " + "\n";
            query += "       plc.fecha_asignacion, " + "\n";
            query += "       plc.persona_id, " + "\n";
            query += "       p.nombre_completo, " + "\n";
            query += "       round(nvl((select sum((cp.credito - cp.debito) / cp.cotizacion_moneda) " + "\n";
            query += "                   from ctacte_personas cp, facturas_cliente fc " + "\n";
            query += "                  where cp.ctacte_persona_relacionada_id is null " + "\n";
            query += "                    and cp.persona_id = p.id " + "\n";
            query += "                    and cp.caso_id = fc.caso_id " + "\n";
            query += "                    and fc.condicion_pago_id != 1 " + "\n";
            query += "                    and cp.estado = 'A' " + "\n";
            query += "                    and fc.estado = 'A'), " + "\n";
            query += "                 0), " + "\n";
            query += "             4) credito_menos_debito, " + "\n";
            query += "       round(nvl((select sum(case " + "\n";
            query += "                              when cp.moneda_id = plc.moneda_id then " + "\n";
            query += "                               (cp.credito - cp.debito) " + "\n";
            query += "                              else " + "\n";
            query += "                               (cp.credito - cp.debito) / cp.cotizacion_moneda * " + "\n";
            query += "                               Herramientas.Obtener_Cotizacion_Venta(c.sucursal_id, " + "\n";
            query += "                                                                     plc.moneda_id, " + "\n";
            query += "                                                                     sysdate) " + "\n";
            query += "                            end) " + "\n";
            query += "                   from ctacte_personas cp, casos c, facturas_cliente fc " + "\n";
            query += "                  where cp.ctacte_persona_relacionada_id is null " + "\n";
            query += "                    and c.id = cp.caso_id " + "\n";
            query += "                    and cp.caso_id = fc.caso_id " + "\n";
            query += "                    and c.id = fc.caso_id " + "\n";
            query += "                    and cp.persona_id = p.id " + "\n";
            query += "                    and fc.condicion_pago_id != 1 " + "\n";
            query += "                    and cp.estado = 'A' " + "\n";
            query += "                    and fc.estado = 'A'), " + "\n";
            query += "                 0), " + "\n";
            query += "             4) credito_menos_debito_moneda_lc, " + "\n";
            query += "       round(nvl((select sum(ccric.monto / ccric.cotizacion_moneda) " + "\n";
            query += "                   from ctacte_cheques_rec_info_compl ccric " + "\n";
            query += "                  where ccric.cheque_estado_id not in (13, 7) " + "\n";
            query += "                    and ccric.persona_id = plc.persona_id), " + "\n";
            query += "                 0), " + "\n";
            query += "             4) tot_cheq_no_deposit_ni_efectiv, " + "\n";
            query += "       round(nvl((select sum(case " + "\n";
            query += "                              when ccric.moneda_id = plc.moneda_id then " + "\n";
            query += "                               ccric.monto " + "\n";
            query += "                              else " + "\n";
            query += "                               ccric.monto / ccric.cotizacion_moneda * " + "\n";
            query += "                               Herramientas.Obtener_Cotizacion_Venta(ccric.sucursal_id, " + "\n";
            query += "                                                                     plc.moneda_id, " + "\n";
            query += "                                                                     sysdate) " + "\n";
            query += "                            end) " + "\n";
            query += "                   from ctacte_cheques_rec_info_compl ccric " + "\n";
            query += "                  where ccric.cheque_estado_id not in (13, 7) " + "\n";
            query += "                    and ccric.persona_id = plc.persona_id), " + "\n";
            query += "                 0), " + "\n";
            query += "             4) tot_cheq_no_dep_ni_efec_mon_lc " + "\n";
            query += "  from personas_linea_credito plc, personas p " + "\n";
            query += " where plc.persona_id = p.id " + "\n";
            query += "   and plc.id = " + "\n";
            query += "       (select max(id) " + "\n";
            query += "          from personas_linea_credito " + "\n";
            query += "         where plc.persona_id = personas_linea_credito.persona_id)" + "\n";
            query += "  and p.id = " + persona_id;

            return sesion.db.EjecutarQuery(query);
          //  return GetPersonasLineaCreditoActivaDataTable2(PersonaId + " = " + persona_id, string.Empty, sesion);
        } 
        
        public static DataTable GetPersonasLineaCreditoActivaDataTable2(string clausulas, string orden) 
        { 
            using (SessionService sesion = new SessionService()) {
                return GetPersonasLineaCreditoActivaDataTable2(clausulas, orden, sesion);
            }
        }
        
        public static DataTable GetPersonasLineaCreditoActivaDataTable2(string clausulas, string orden, SessionService sesion)
        {
            DataTable table;
            table = sesion.Db.PERSONAS_LINEA_CREDITO_ACTIVACollection.GetAsDataTable(clausulas, orden);
            return table;
        }

        #endregion GetPersonasLineaCreditoActivaDataTable

        #region Accessors
        //personas_linea_credito_id 
        public static string PersonasLineaCreditoId_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITO_ACTIVACollection.PERSONAS_LINEA_CREDITO_IDColumnName; }
        }
        //temporal 
        public static string Temporal_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITO_ACTIVACollection.TEMPORALColumnName; }
        }
        //aprobado 
        public static string Aprobado_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITO_ACTIVACollection.APROBADOColumnName; }
        }
        //utilizado 
        public static string Utilizado_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITO_ACTIVACollection.UTILIZADOColumnName; }
        }
        //monto_linea_credito 
        public static string MontoLineaCredito_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITO_ACTIVACollection.MONTO_LINEA_CREDITOColumnName; }
        }
        //moneda_id 
        public static string MonedaId_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITO_ACTIVACollection.MONEDA_IDColumnName; }
        }
        //cotizacion 
        public static string Cotizacion_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITO_ACTIVACollection.COTIZACIONColumnName; }
        }
        //fecha_asignacion 
        public static string FechaAsignacion_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITO_ACTIVACollection.FECHA_ASIGNACIONColumnName; }
        }
        //persona_id 
        public static string PersonaId
        {
            get { return PERSONAS_LINEA_CREDITO_ACTIVACollection.PERSONA_IDColumnName; }
        }
        //nombre_completo 
        public static string NombreCompleto_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITO_ACTIVACollection.NOMBRE_COMPLETOColumnName; }
        }
        //credito_menos_debito 
        public static string CreditoMenosDebito_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITO_ACTIVACollection.CREDITO_MENOS_DEBITOColumnName; }
        }
        //credito_menos_debito 
        public static string CreditoMenosDebitoMonedaLC_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITO_ACTIVACollection.CREDITO_MENOS_DEBITO_MONEDA_LCColumnName; }
        }
        //tot_cheq_no_deposit_ni_efectiv
        public static string TotCheqNoDepositNiEfectiv_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITO_ACTIVACollection.TOT_CHEQ_NO_DEPOSIT_NI_EFECTIVColumnName; }
        }
        //tot_cheq_no_deposit_ni_efectiv
        public static string TotCheqNoDepositNiEfectivMonedaLC_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITO_ACTIVACollection.TOT_CHEQ_NO_DEP_NI_EFEC_MON_LCColumnName; }
        }
        #endregion Accessors
    }
}
