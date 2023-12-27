#region Using
using System;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Data;
#endregion Using

namespace CBA.FlowV2.Services.Giros
{
    public class CuentaCorrienteGirosService
    {
        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos, decimal caso_id, SessionService sesion)
        {
            try
            {
                decimal idPlanDesembolso = (decimal)campos[CtaCtePlanesDesembolsoId_NombreCol];
                CTACTE_GIROSRow row = new CTACTE_GIROSRow();

                row.ID = sesion.Db.GetSiguienteSecuencia("CTACTE_GIROS_SQC");
                row.COMPROBANTE = campos[Comprobante_NombreCol].ToString();
                row.COTIZACION = (decimal)campos[Cotizacion_NombreCol];
                row.CTACTE_PLANES_DESEMBOLSO_ID = idPlanDesembolso;
                row.FECHA = DateTime.Today;
                row.MONEDA_ID = (decimal)campos[MonedaId_NombreCol];
                row.MONTO_PAGO = (decimal)campos[MontoPago_NombreCol];

                if (campos.Contains(Observaciones_NombreCol) && campos[Observaciones_NombreCol] != null)
                {
                    row.OBSERVACIONES = (string)campos[Observaciones_NombreCol];
                }
                
                row.PERSONA_ID = (decimal)campos[PersonaId_NombreCol];

                //Buscar valores del plan de desembolso
                string clausulas = CuentaCorrientePlanesDesembolsoService.Id_NombreCol + " = " + idPlanDesembolso;
                DataTable dt = CuentaCorrientePlanesDesembolsoService.GetPlanesDesembolsoDataTable(clausulas, string.Empty);

                row.CONDICION_DESEMBOLSO_ID = (decimal)dt.Rows[0][CuentaCorrientePlanesDesembolsoService.CondicionDesembolsoId_NombreCol];
                row.DESEMBOLSO_AUTOMATICO = dt.Rows[0][CuentaCorrientePlanesDesembolsoService.DesembolsoAutomatico_NombreCol].ToString();
                row.DIAS_DESDE_INICIO_MES = (decimal)dt.Rows[0][CuentaCorrientePlanesDesembolsoService.DiasDesdeInicioMes_NombreCol];
                row.POLITICA_PRIMER_DESEMBOLSO = (decimal)dt.Rows[0][CuentaCorrientePlanesDesembolsoService.PoliticaPrimerDesembolso_NombreCol];
                row.COMISION_MONTO_FIJO = CuentaCorrientePlanesDesembolsoEscalasService.GetMontoComision(idPlanDesembolso, row.MONTO_PAGO);
                row.COMISION_PORCENTAJE = CuentaCorrientePlanesDesembolsoEscalasService.GetPorcentajeComision(idPlanDesembolso, row.MONTO_PAGO);

                row.MOTO_A_COBRAR = row.MONTO_PAGO - row.COMISION_MONTO_FIJO - ((row.MONTO_PAGO * row.COMISION_PORCENTAJE) / 100);

                sesion.Db.CTACTE_GIROSCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);

                #region Generar Fechas de Desembolso
                decimal cantidadCuotas = CuentaCorrienteCondicionesDesembolsoService.GetCantidadCuotas(row.CONDICION_DESEMBOLSO_ID);
                String tipoCalculo = CuentaCorrienteCondicionesDesembolsoService.GetTipoCalculo((row.CONDICION_DESEMBOLSO_ID));
                DataTable plazos = CuentaCorrienteCondicionesDesembolsoService.GetPlazosDesembolsos((row.CONDICION_DESEMBOLSO_ID));
                
                DateTime fechaBase; 
                if(row.POLITICA_PRIMER_DESEMBOLSO == Definiciones.PoliticasPrimerDesembolso.FechaDeGiro)
                {
                    fechaBase= row.FECHA;
                }
                else
                {
                    fechaBase = row.FECHA.AddMonths(1);
                    fechaBase = DateTime.Parse("01/" + fechaBase.Month + "/" + fechaBase.Year);
                    fechaBase = fechaBase.AddDays((double)row.DIAS_DESDE_INICIO_MES);
                }
                
                DateTime desembolso;
                
                for (int i = 0; i < plazos.Rows.Count; i++)
                {
                    System.Collections.Hashtable campos2 = new System.Collections.Hashtable();
                    campos2.Add(CuentaCorrienteGirosMovimientosService.CtaCteGiroId_NombreCol, row.ID);
                    campos2.Add(CuentaCorrienteGirosMovimientosService.Cotizacion_NombreCol, row.COTIZACION);
                    campos2.Add(CuentaCorrienteGirosMovimientosService.FechaInsercion_NombreCol, row.FECHA);
                    campos2.Add(CuentaCorrienteGirosMovimientosService.MonedaId_NombreCol, row.MONEDA_ID);
                    campos2.Add(CuentaCorrienteGirosMovimientosService.NroCuota_NombreCol, (decimal)i + 1);
                    campos2.Add(CuentaCorrienteGirosMovimientosService.TotalCuotas_NombreCol, cantidadCuotas);
                    campos2.Add(CuentaCorrienteGirosMovimientosService.Credito_NombreCol, row.MOTO_A_COBRAR / cantidadCuotas); 
                    campos2.Add(CuentaCorrienteGirosMovimientosService.Debito_NombreCol,(decimal)0);
                    campos2.Add(CuentaCorrienteGirosMovimientosService.CasoId_NombreCol, caso_id);

                    if (tipoCalculo.Equals(Definiciones.CondicionPagoTipoCalculo.Dias))
                        desembolso = fechaBase.AddDays(double.Parse(plazos.Rows[i][CuentaCorrienteCondicionesDesembolsoService.Desembolso_NombreCol].ToString()));
                    else desembolso = fechaBase.AddMonths(int.Parse(plazos.Rows[i][CuentaCorrienteCondicionesDesembolsoService.Desembolso_NombreCol].ToString()));

                    campos2.Add(CuentaCorrienteGirosMovimientosService.FechaDesembolso_NombreCol, desembolso);
                    CuentaCorrienteGirosMovimientosService.Guardar(campos2, true,sesion);
                }
                #endregion Generar Fechas de Desembolso

                return row.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal ctacte_giro_id, SessionService sesion)
        {
            CuentaCorrienteGirosMovimientosService.Borrar(ctacte_giro_id, sesion);
            sesion.db.CTACTE_GIROSCollection.DeleteByPrimaryKey(ctacte_giro_id);
        }
        #endregion Borrar

        #region GetGirosDataTable
        /// <summary>
        /// Gets the activos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetGirosDataTable(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_GIROSCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetGirosDataTable

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "CTACTE_GIROS"; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_GIROSCollection.IDColumnName; }
        }
        public static string ComisionMontoFijo_NombreCol
        {
            get { return CTACTE_GIROSCollection.COMISION_MONTO_FIJOColumnName; }
        }
        public static string ComisionPorcentaje_NombreCol
        {
            get { return CTACTE_GIROSCollection.COMISION_PORCENTAJEColumnName; }
        }
        public static string Comprobante_NombreCol
        {
            get { return CTACTE_GIROSCollection.COMPROBANTEColumnName; }
        }
        public static string CondicionDesembolsoId_NombreCol
        {
            get { return CTACTE_GIROSCollection.CONDICION_DESEMBOLSO_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return CTACTE_GIROSCollection.COTIZACIONColumnName; }
        }
        public static string CtaCtePlanesDesembolsoId_NombreCol
        {
            get { return CTACTE_GIROSCollection.CTACTE_PLANES_DESEMBOLSO_IDColumnName; }
        }
        public static string DesembolsoAutomatico_NombreCol
        {
            get { return CTACTE_GIROSCollection.DESEMBOLSO_AUTOMATICOColumnName; }
        }
        public static string DiasDesdeInicioMes_NombreCol
        {
            get { return CTACTE_GIROSCollection.DIAS_DESDE_INICIO_MESColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CTACTE_GIROSCollection.FECHAColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_GIROSCollection.MONEDA_IDColumnName; }
        }
        public static string MontoPago_NombreCol
        {
            get { return CTACTE_GIROSCollection.MONTO_PAGOColumnName; }
        }
        public static string MontoACobrar_NombreCol
        {
            get { return CTACTE_GIROSCollection.MOTO_A_COBRARColumnName; }
        }
        public static string Observaciones_NombreCol
        {
            get { return CTACTE_GIROSCollection.OBSERVACIONESColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return CTACTE_GIROSCollection.PERSONA_IDColumnName; }
        }
        public static string PoliticaPrimerDesembolso_NombreCol
        {
            get { return CTACTE_GIROSCollection.POLITICA_PRIMER_DESEMBOLSOColumnName; }
        }
        #endregion Tabla

        #endregion Accessors
    }
}
