using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.ToolbarFlujo;


namespace CBA.FlowV2.Services.Tesoreria
{
    public class ImportarPagosPersonasService
    {
        public static decimal CrearPago(decimal sucursalId, decimal persona_id, DateTime fecha, decimal monedaId, decimal funcionario_cobrador_id, decimal autonumeracion_recibo_id, string recibo_nro,
            decimal[] ctacte_persona_id, decimal[] monto, int ctacte_valor_id, decimal ctacte_red_pagos_id, string ctacte_red_pago_nro_comprobante, decimal ctacte_plan_desembolso_id)
        {
            decimal caso_id = Definiciones.Error.Valor.EnteroPositivo;
            bool exito = false;
            string mensaje = string.Empty;

            try
            {
                using (SessionService sesion = new SessionService())
                {
                    caso_id = PagosDePersonaService.CrearCaso(sucursalId,
                                                                 persona_id,
                                                                 fecha,
                                                                 monedaId,
                                                                 funcionario_cobrador_id,
                                                                 Definiciones.Error.Valor.EnteroPositivo,
                                                                 Definiciones.Error.Valor.EnteroPositivo,
                                                                 recibo_nro,
                                                                 autonumeracion_recibo_id,
                                                                 ctacte_persona_id,
                                                                 monto,
                                                                 ctacte_valor_id,
                                                                 ctacte_red_pagos_id,
                                                                 ctacte_red_pago_nro_comprobante,
                                                                 ctacte_plan_desembolso_id,
                                                                 true,
                                                                 null,
                                                                 sesion);

                    exito = !caso_id.Equals(Definiciones.Error.Valor.EnteroPositivo);

                    //Aprobar el pago
                    if (exito)
                    {
                        exito = (new PagosDePersonaService()).ProcesarCambioEstado(caso_id, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                        if (exito)
                            exito = (new ToolbarFlujoService()).ProcesarCambioEstado(caso_id, Definiciones.EstadosFlujos.Aprobado, "Transición automática por pago a través de Red de Pagos", sesion);
                        if (exito)
                            (new PagosDePersonaService()).EjecutarAccionesLuegoDeCambioEstado(caso_id, Definiciones.EstadosFlujos.Aprobado, sesion);
                        if (!exito)
                            throw new Exception("Error en PagoDePersonas.CrearPorRedDePago. " + mensaje + ".");
                    }

                    return caso_id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable GetPlanesDeDesembolso(decimal procesadoraId)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = CTACTE_PLANES_DESEMBOLSOCollection.CTACTE_PROCESADORA_IDColumnName + " = " + procesadoraId.ToString();

                if (procesadoraId != Definiciones.Error.Valor.EnteroPositivo)
                    return sesion.db.CTACTE_PLANES_DESEMBOLSOCollection.GetAsDataTable(clausulas, string.Empty);
                else
                    return sesion.db.CTACTE_PLANES_DESEMBOLSOCollection.GetAsDataTable(string.Empty, string.Empty);
            }
        }

        public static DataTable GetRedDePago()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.CTACTE_REDES_PAGOCollection.GetAllAsDataTable();
            }
        }


        #region Accesors
        public static string PlanDesembolsoNombre_NombreCol
        {
            get { return CTACTE_PLANES_DESEMBOLSOCollection.NOMBREColumnName; }
        }

        public static string PlanDesembolsoId_NombreCol
        {
            get { return CTACTE_PLANES_DESEMBOLSOCollection.IDColumnName; }
        }

        public static string RedPagoId_NombreCol
        {
            get { return CTACTE_REDES_PAGOCollection.IDColumnName; }
        }

        public static string RedPagoNombre_NombreCol
        {
            get { return CTACTE_REDES_PAGOCollection.NOMBREColumnName; }
        }

        #endregion Accesors

    }
}
