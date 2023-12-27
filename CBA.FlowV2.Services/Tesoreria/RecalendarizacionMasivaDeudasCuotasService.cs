#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.Common;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class RecalendarizacionMasivaDeudasCuotasService
    {
        #region GetRecalendarizacionMasivaDeudasCuotasDataTable
        public static DataTable GetRecalendarizacionMasivaDeudasCuotasDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.RECALENDARIZACION_MAS_CUOTASCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetRecalendarizacionMasivaDeudasCuotasDataTable

        #region GetRecalendarizacionMasivaDeudasCuotasInfoCompletaDataTable
        public static DataTable GetRecalendarizacionMasivaDeudasCuotasInfoCompletaDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.RECALEN_MAS_CUOT_INFO_COMPLETACollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetRecalendarizacionMasivaDeudasCuotasInfoCompletaDataTable

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo) 
        { using (SessionService sesion = new SessionService())
            {
              try
                {
                  sesion.BeginTransaction();
                  Guardar(campos, insertarNuevo, sesion);
                  sesion.CommitTransaction();
                }
              catch (Exception exp)
              {
                  sesion.RollbackTransaction();
                  throw exp;
              }
            }
        }

        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            if (!campos.Contains(RecalendarizacionMasivaDetId_NombreCol))
                throw new Exception("Debe indicar el detalle asociado.");
            if (!campos.Contains(CalendarioPagoCliFCOriginalId_NombreCol))
                throw new Exception("Debe indicar el calendario de pago original asociado.");
            if (!campos.Contains(NuevoVencimiento_NombreCol))
                throw new Exception("Debe indicar el nuevo vencimiento.");

            RECALENDARIZACION_MAS_CUOTASRow row = new RECALENDARIZACION_MAS_CUOTASRow();
            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("recalendarizacion_mas_cuot_sqc");
                row.RECAL_MASIVA_DET_ID = (decimal)campos[RecalendarizacionMasivaDetId_NombreCol];
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.Db.RECALENDARIZACION_MAS_CUOTASCollection.GetRow(Id_NombreCol + " = " + campos[Id_NombreCol]);
                valorAnterior = row.ToString();
            }

            row.CAL_PAGO_CLI_FC_ORIGINAL_ID = (decimal)campos[CalendarioPagoCliFCOriginalId_NombreCol];
            if (campos.Contains(CalendarioPagoCliFCNuevoId_NombreCol))
                row.CAL_PAGO_CLI_FC_NUEVO_ID = (decimal)campos[CalendarioPagoCliFCNuevoId_NombreCol];

            row.NUEVO_VENCIMIENTO = (DateTime)campos[NuevoVencimiento_NombreCol];

            if (insertarNuevo) sesion.Db.RECALENDARIZACION_MAS_CUOTASCollection.Insert(row);
            else sesion.Db.RECALENDARIZACION_MAS_CUOTASCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified detalles_id.
        /// </summary>
        /// <param name="detalles_id">The detalles_id.</param>
        public static void BorrarRelaciones(decimal detalle_id, SessionService sesion)
        {
            try
            {
                RECALENDARIZACION_MAS_CUOTASRow[] row = sesion.Db.RECALENDARIZACION_MAS_CUOTASCollection.GetByRECAL_MASIVA_DET_ID(detalle_id);

                for (int i = 0; i < row.Length; i++)
                {
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.db.RECALENDARIZACION_MAS_CUOTASCollection.Delete(row[i]);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row[i].ID, valorAnterior, valorNuevo, sesion);
                }
            }
            catch (Exception e)
            {
                sesion.Db.RollbackTransaction();
                throw e;
            }
        }
        #endregion Borrar

        #region RecalcularVencimiento
        public static void RecalcularVencimiento(decimal recalendarizacion_cuota_id, DateTime nuevo_vencimiento)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    RECALENDARIZACION_MAS_CUOTASRow row = sesion.db.RECALENDARIZACION_MAS_CUOTASCollection.GetByPrimaryKey(recalendarizacion_cuota_id);
                    var cuentaCorriente = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CalendarioPagoFcCliId_NombreCol + " = " + row.CAL_PAGO_CLI_FC_ORIGINAL_ID, string.Empty);
                    PersonasService persona = new PersonasService((decimal)cuentaCorriente .Rows[0][CuentaCorrientePersonasService.PersonaId_NombreCol]);
                    var tipo = TiposClienteRecalendarizacionService.GetTiposClientesRecalendarizacionDataTable(persona.TipoClienteId.Value);
                    int diasMinimo = 0;
                    int diasMaximo = 0;
                    if (tipo.Rows.Count > 0)
                    {
                        diasMinimo = int.Parse(tipo.Rows[0][TiposClienteRecalendarizacionService.DiasMinimo_NombreCol].ToString());
                        diasMaximo = int.Parse(tipo.Rows[0][TiposClienteRecalendarizacionService.DiasMaximo_NombreCol].ToString());
                    }

                    var fechaVencimiento = (DateTime)cuentaCorriente.Rows[0][CuentaCorrientePersonasService.FechaVencimiento_NombreCol];

                    DateTime fechaMinima = fechaVencimiento.AddDays(diasMinimo);
                    DateTime fechaMaxima = fechaVencimiento.AddDays(diasMaximo);

                    if (nuevo_vencimiento <= fechaMaxima && nuevo_vencimiento >= fechaMinima)
                    {
                        string valorAnterior = row.ToString(); 
                        row.NUEVO_VENCIMIENTO = nuevo_vencimiento;
                        sesion.db.RECALENDARIZACION_MAS_CUOTASCollection.Update(row);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    }
                    else
                    {
                        throw new Exception("La fecha no cumple el rango definido para este cliente.");
                    }

                    sesion.db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.db.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion RecalcularVencimiento

        #region AsignarNuevaCuotaId
        public static void AsignarNuevaCuotaId(decimal recal_cuota_id, decimal calendario_nuevo_id, SessionService sesion)
        {
            RECALENDARIZACION_MAS_CUOTASRow row = new RECALENDARIZACION_MAS_CUOTASRow();
            string valorAnterior = string.Empty;

            row = sesion.Db.RECALENDARIZACION_MAS_CUOTASCollection.GetByPrimaryKey(recal_cuota_id);
            valorAnterior = row.ToString();

            row.CAL_PAGO_CLI_FC_NUEVO_ID = calendario_nuevo_id;
            
            sesion.Db.RECALENDARIZACION_MAS_CUOTASCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion AsignarNuevaCuotaId

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "recalendarizacion_mas_cuotas"; }
        }
        public static string Id_NombreCol
        {
            get { return RECALENDARIZACION_MAS_CUOTASCollection.IDColumnName; }
        }
        public static string CalendarioPagoCliFCNuevoId_NombreCol
        {
            get { return RECALENDARIZACION_MAS_CUOTASCollection.CAL_PAGO_CLI_FC_NUEVO_IDColumnName; }
        }
        public static string CalendarioPagoCliFCOriginalId_NombreCol
        {
            get { return RECALENDARIZACION_MAS_CUOTASCollection.CAL_PAGO_CLI_FC_ORIGINAL_IDColumnName; }
        }
        public static string NuevoVencimiento_NombreCol
        {
            get { return RECALENDARIZACION_MAS_CUOTASCollection.NUEVO_VENCIMIENTOColumnName; }
        }
        public static string RecalendarizacionMasivaDetId_NombreCol
        {
            get { return RECALENDARIZACION_MAS_CUOTASCollection.RECAL_MASIVA_DET_IDColumnName; }
        }
        #endregion Tabla
        
        #region Vista
        public static string Nombre_Vista
        {
            get { return "recalen_mas_cuot_info_completa"; }
        }
        public static string VistaFechaVencimientoNuevo_ColumnName
        {
            get { return RECALEN_MAS_CUOT_INFO_COMPLETACollection.FECHA_VENCIMIENTO_NUEVOColumnName; }
        }
        public static string VistaFechaVencimientoOriginal_ColumnName
        {
            get { return RECALEN_MAS_CUOT_INFO_COMPLETACollection.FECHA_VENCIMIENTO_ORIGINALColumnName; }
        }
        public static string VistaInteresCuota_ColumnName
        {
            get { return RECALEN_MAS_CUOT_INFO_COMPLETACollection.INTERES_CUOTAColumnName; }
        }
        public static string VistaNumeroCuota_ColumnName
        {
            get { return RECALEN_MAS_CUOT_INFO_COMPLETACollection.NUMERO_CUOTAColumnName; }
        }
        public static string VistaMontoCuota_ColumnName
        {
            get { return RECALEN_MAS_CUOT_INFO_COMPLETACollection.MONTO_CUOTAColumnName; }
        }
        #endregion Vista
        #endregion Accessors
    }
}