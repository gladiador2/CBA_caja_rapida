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
    public class CuentaCorrienteGirosMovimientosService
    {
        #region Insertar Movimento Relacionado
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void InsertarMovientoRelacionado(decimal movimiento_id,decimal moneda_id, decimal monto,decimal cotizacion, decimal caso_id, decimal detalle_id, SessionService sesion)
        {
            try
            {
                CTACTE_GIROS_MOVIMIENTOSRow row = new CTACTE_GIROS_MOVIMIENTOSRow();
                CTACTE_GIROS_MOVIMIENTOSRow rowPadre = new CTACTE_GIROS_MOVIMIENTOSRow();
                String valorAnterior = Definiciones.Log.RegistroNuevo;
                row.ID = sesion.Db.GetSiguienteSecuencia("CTACTE_GIROS_MOVIMIENTOS_SQC");
                row.CTACTE_GIRO_RELACIONADO_ID = movimiento_id;
                row.COTIZACION = cotizacion;
                row.FECHA_INSERCION = DateTime.Today;
                row.MONEDA_ID = moneda_id;
                row.CREDITO = monto;
                row.DEBITO = monto;
                row.CASO_ID = caso_id;
                row.DESEMBOLSO_GIRO_DET_ID = detalle_id;

                sesion.Db.CTACTE_GIROS_MOVIMIENTOSCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                //Actualizar el movimiento original
                rowPadre = sesion.db.CTACTE_GIROS_MOVIMIENTOSCollection.GetByPrimaryKey(movimiento_id);
                valorAnterior = rowPadre.ToString();

                rowPadre.DEBITO += monto;
                sesion.Db.CTACTE_GIROS_MOVIMIENTOSCollection.Update(rowPadre);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, rowPadre.ID, valorAnterior, rowPadre.ToString(), sesion);

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion region Insertar Movimento Relacionado

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                CTACTE_GIROS_MOVIMIENTOSRow row = new CTACTE_GIROS_MOVIMIENTOSRow();
                String valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("CTACTE_GIROS_MOVIMIENTOS_SQC");
                    row.CTACTE_GIRO_ID = (decimal)campos[CtaCteGiroId_NombreCol];

                    if (campos.Contains(CuentaCorrienteGirosMovimientosService.CtaCteGiroRelacionadoId_NombreCol))
                        row.CTACTE_GIRO_RELACIONADO_ID = (decimal)campos[CuentaCorrienteGirosMovimientosService.CtaCteGiroRelacionadoId_NombreCol];

                    row.COTIZACION = (decimal)campos[CuentaCorrienteGirosMovimientosService.Cotizacion_NombreCol];
                    row.FECHA_DESEMBOLSO = DateTime.Parse(campos[CuentaCorrienteGirosMovimientosService.FechaDesembolso_NombreCol].ToString());
                    row.FECHA_INSERCION = DateTime.Parse(campos[CuentaCorrienteGirosMovimientosService.FechaInsercion_NombreCol].ToString());
                    row.MONEDA_ID = (decimal)campos[CuentaCorrienteGirosMovimientosService.MonedaId_NombreCol];
                    row.NRO_CUOTA = (decimal)campos[CuentaCorrienteGirosMovimientosService.NroCuota_NombreCol];
                    row.TOTAL_CUOTAS = (decimal)campos[CuentaCorrienteGirosMovimientosService.TotalCuotas_NombreCol];
                    row.CASO_ID = (decimal)campos[CuentaCorrienteGirosMovimientosService.CasoId_NombreCol];
                }
                else
                {
                    row = sesion.Db.CTACTE_GIROS_MOVIMIENTOSCollection.GetByPrimaryKey(decimal.Parse(campos[CuentaCorrienteGirosMovimientosService.Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }

                row.CREDITO = (decimal)campos[Credito_NombreCol];
                row.DEBITO = (decimal)campos[Debito_NombreCol];

                if (insertarNuevo) sesion.Db.CTACTE_GIROS_MOVIMIENTOSCollection.Insert(row);
                else sesion.Db.CTACTE_GIROS_MOVIMIENTOSCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal ctacte_giro_id, SessionService sesion)
        { 
            string clausulas = CuentaCorrienteGirosMovimientosService.CtaCteGiroId_NombreCol + " = " + ctacte_giro_id + " and " +
                               CuentaCorrienteGirosMovimientosService.CtaCteGiroRelacionadoId_NombreCol + " is null ";
            CTACTE_GIROS_MOVIMIENTOSRow[] rows = sesion.db.CTACTE_GIROS_MOVIMIENTOSCollection.GetAsArray(clausulas, string.Empty);
            
            if(rows.Length <= 0 ) 
                return;

            if(rows[0].DEBITO > 0)
                throw new Exception("El giro ya fue desembolsado parcial o totalmente.");

            sesion.db.CTACTE_GIROS_MOVIMIENTOSCollection.Delete(rows[0]);
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
        public static DataTable GetGirosMovimientosDataTable(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_GIROS_MOVIMIENTOSCollection.GetAsDataTable(where, orden);
            }
        }

        public static DataTable GetGirosMovimientosInfoCompleta(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_GIROS_MOV_INFO_COMPCollection.GetAsDataTable(where, orden);
            }
        }

        #endregion GetGirosDataTable

        #region Accessors

        public static string Nombre_Tabla
        {
            get { return "CTACTE_GIROS_MOVIMIENTOS"; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_GIROS_MOVIMIENTOSCollection.IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return CTACTE_GIROS_MOVIMIENTOSCollection.CASO_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return CTACTE_GIROS_MOVIMIENTOSCollection.COTIZACIONColumnName; }
        }
        public static string Credito_NombreCol
        {
            get { return CTACTE_GIROS_MOVIMIENTOSCollection.CREDITOColumnName; }
        }
        public static string CtaCteGiroId_NombreCol
        {
            get { return CTACTE_GIROS_MOVIMIENTOSCollection.CTACTE_GIRO_IDColumnName; }
        }
        public static string CtaCteGiroRelacionadoId_NombreCol
        {
            get { return CTACTE_GIROS_MOVIMIENTOSCollection.CTACTE_GIRO_RELACIONADO_IDColumnName; }
        }
        public static string Debito_NombreCol
        {
            get { return CTACTE_GIROS_MOVIMIENTOSCollection.DEBITOColumnName; }
        }
        public static string DesembolsoGiroDetId_NombreCol
        {
            get { return CTACTE_GIROS_MOVIMIENTOSCollection.DESEMBOLSO_GIRO_DET_IDColumnName; }
        }
        public static string FechaDesembolso_NombreCol
        {
            get { return CTACTE_GIROS_MOVIMIENTOSCollection.FECHA_DESEMBOLSOColumnName; }
        }
        public static string FechaInsercion_NombreCol
        {
            get { return CTACTE_GIROS_MOVIMIENTOSCollection.FECHA_INSERCIONColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_GIROS_MOVIMIENTOSCollection.MONEDA_IDColumnName; }
        }
        public static string NroCuota_NombreCol
        {
            get { return CTACTE_GIROS_MOVIMIENTOSCollection.NRO_CUOTAColumnName; }
        }
        public static string TotalCuotas_NombreCol
        {
            get { return CTACTE_GIROS_MOVIMIENTOSCollection.TOTAL_CUOTASColumnName; }
        }
        public static string VistaCasoFecha_NombreCol
        {
            get { return CTACTE_GIROS_MOV_INFO_COMPCollection.CASO_FECHAColumnName; }
        }
        public static string VistaCtactePlanesDesembolsoId_NombreCol
        {
            get { return CTACTE_GIROS_MOV_INFO_COMPCollection.CTACTE_PLANES_DESEMBOLSO_IDColumnName; }
        }
        public static string VistaFlujoId_NombreCol
        {
            get { return CTACTE_GIROS_MOV_INFO_COMPCollection.FLUJO_IDColumnName; }
        }
        public static string VistaFlujoDescripcion_NombreCol
        {
            get { return CTACTE_GIROS_MOV_INFO_COMPCollection.FLUJO_DESCRIPCIONColumnName; }
        }
        public static string VistaGiroComprobante_NombreCol
        {
            get { return CTACTE_GIROS_MOV_INFO_COMPCollection.GIRO_COMPROBANTEColumnName; }
        }
        public static string VistaGiroMovimientoCuotaDes_NombreCol
        {
            get { return CTACTE_GIROS_MOV_INFO_COMPCollection.GIRO_MOV_CUOTA_DESColumnName; }
        }
        public static string VistaGiroMonedaNombre_NombreCol
        {
            get { return CTACTE_GIROS_MOV_INFO_COMPCollection.GIRO_MOV_MONEDA_NOMBREColumnName; }
        }
        public static string VistaGiroMovSaldo_NombreCol
        {
            get { return CTACTE_GIROS_MOV_INFO_COMPCollection.GIRO_MOV_SALDOColumnName; }
        }
        public static string VistaCtacteProcesadoraId_NombreCol
        {
            get { return CTACTE_GIROS_MOV_INFO_COMPCollection.CTACTE_PROCESADORA_IDColumnName; }
        }
        public static string VistaCtacteRedPagoId_NombreCol
        {
            get { return CTACTE_GIROS_MOV_INFO_COMPCollection.CTACTE_RED_PAGO_IDColumnName; }
        }

        #endregion Accessors
    }
}
