using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrientePersonasDetalleService
    {
        #region GetCuentaCorrientePersonasDataTable
        /// <summary>
        /// Gets the cuenta corriente personas detalle data table.
        /// </summary>
        /// <param name="ctacte_persona_id">The ctacte_persona_id.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePersonasDetalleDataTable(decimal ctacte_persona_id)
        {
            string clausulas = CuentaCorrientePersonasDetalleService.CtactePersonaId_NombreCol + " = " + ctacte_persona_id;
            return CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable(clausulas, CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol);
        }

        public static DataTable GetCuentaCorrientePersonasDetalleDataTable(decimal ctacte_persona_id, SessionService sesion)
        {
            string clausulas = CuentaCorrientePersonasDetalleService.CtactePersonaId_NombreCol + " = " + ctacte_persona_id;
            return CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable(clausulas, CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol, sesion);
        }

        /// <summary>
        /// Gets the cuenta corriente personas detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePersonasDetalleDataTable(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return GetCuentaCorrientePersonasDetalleDataTable(clausulas, orden, sesion);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        public static DataTable GetCuentaCorrientePersonasDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            try
            {
                return sesion.Db.CTACTE_PERSONAS_DETALLECollection.GetAsDataTable(clausulas, orden);
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetCuentaCorrientePersonasDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified ctacte_persona_id.
        /// </summary>
        /// <param name="ctacte_persona_id">The ctacte_persona_id.</param>
        /// <param name="impuestos">The impuestos.</param>
        /// <param name="montos">The montos.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Guardar(decimal ctacte_persona_id, decimal[] impuestos, decimal[] montos, SessionService sesion)
        {
            if (impuestos.Length != montos.Length)
                throw new Exception("Error en CuentaCorrientePersonasDetalle.Guardar(). Los array de impuestos y montos son de longitudes distintas.");

            //Se toma de la DB usando la sesion debido a que aun no fue cerrada la sesion donde se inserto el movimiento
            CTACTE_PERSONASRow ctactePersonaRow = sesion.Db.CTACTE_PERSONASCollection.GetByPrimaryKey(ctacte_persona_id);

            CTACTE_PERSONAS_DETALLERow[] row = new CTACTE_PERSONAS_DETALLERow[impuestos.Length];
            decimal verificacionTotal = 0;

            for (int i = 0; i < impuestos.Length; i++)
            {
                row[i] = new CTACTE_PERSONAS_DETALLERow();

                row[i].ID = sesion.Db.GetSiguienteSecuencia("ctacte_personas_detalle_sqc");
                row[i].CTACTE_PERSONA_ID = ctacte_persona_id;
                row[i].IMPUESTO_ID = impuestos[i];
                row[i].PORCENTAJE_IMPUESTO = ImpuestosService.GetPorcentajePorId(impuestos[i]);
                row[i].MONEDA_ID = ctactePersonaRow.MONEDA_ID;
                row[i].COTIZACION_MONEDA = ctactePersonaRow.COTIZACION_MONEDA;
                row[i].MONTO = montos[i];

                verificacionTotal += montos[i];
            }

            if (Math.Round(ctactePersonaRow.DEBITO, 4) != Math.Round(verificacionTotal, 4) && Math.Round(ctactePersonaRow.CREDITO, 4) != Math.Round(verificacionTotal, 4))
                throw new Exception("Error en CuentaCorrientePersonasDetalle.Guardar(). El desglose suma " + verificacionTotal + " mientras que el débito es " + ctactePersonaRow.DEBITO + " y el crédito es " + ctactePersonaRow.CREDITO + ".");

            for (int i = 0; i < impuestos.Length; i++)
            {
                sesion.Db.CTACTE_PERSONAS_DETALLECollection.Insert(row[i]);
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified ctacte_persona_id.
        /// </summary>
        /// <param name="ctacte_persona_id">The ctacte_persona_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal ctacte_persona_id, SessionService sesion)
        {
            sesion.Db.CTACTE_PERSONAS_DETALLECollection.DeleteByCTACTE_PERSONA_ID(ctacte_persona_id);
        }
        #endregion Borrar

        #region ActualizarMontos
        /// <summary>
        /// Actualizars the montos.
        /// </summary>
        /// <param name="ctacte_persona_id">The ctacte_persona_id.</param>
        /// <param name="impuesto_id">The impuesto_id.</param>
        /// <param name="monto">The monto.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarMontos(decimal ctacte_persona_id, decimal impuesto_id, decimal monto, SessionService sesion)
        {
            CTACTE_PERSONAS_DETALLERow[] rows = sesion.Db.CTACTE_PERSONAS_DETALLECollection.GetByCTACTE_PERSONA_ID(ctacte_persona_id);
            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].MONTO = monto;
                rows[i].IMPUESTO_ID = impuesto_id;
                sesion.Db.CTACTE_PERSONAS_DETALLECollection.Update(rows[i]);
            }
        }
        #endregion ActualizarMontos

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PERSONAS_DETALLE"; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_PERSONAS_DETALLECollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtactePersonaId_NombreCol
        {
            get { return CTACTE_PERSONAS_DETALLECollection.CTACTE_PERSONA_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PERSONAS_DETALLECollection.IDColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return CTACTE_PERSONAS_DETALLECollection.IMPUESTO_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_PERSONAS_DETALLECollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTACTE_PERSONAS_DETALLECollection.MONTOColumnName; }
        }
        public static string PorcentajeImpuesto_NombreCol
        {
            get { return CTACTE_PERSONAS_DETALLECollection.PORCENTAJE_IMPUESTOColumnName; }
        }
        #endregion Accessors
    }
}
