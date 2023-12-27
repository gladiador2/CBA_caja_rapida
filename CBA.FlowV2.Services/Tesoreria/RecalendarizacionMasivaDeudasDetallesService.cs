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
using CBA.FlowV2.Services.Facturacion;
using System.Text;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class RecalendarizacionMasivaDeudasDetallesService
    {
        #region GetRecalendarizacionMasivaDeudasDetalleDataTable
        public static DataTable GetRecalendarizacionMasivaDeudasDetalleDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.RECALENDARIZACION_MAS_DETALLESCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetRecalendarizacionMasivaDeudasDetalleDataTable

        #region GetRecalendarizacionMasivaDeudasDetalleInfoCompletaDataTable
        public static DataTable GetRecalendarizacionMasivaDeudasDetalleInfoCompletaDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.RECALEN_MAS_DET_INFO_COMPLETACollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetRecalendarizacionMasivaDeudasDetalleInfoCompletaDataTable

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {

                if (!campos.Contains(RecalendarizacionMasivaId_NombreCol))
                    throw new Exception("Debe indicar la cabecera.");
                if (!campos.Contains(CasoFacturaId_NombreCol))
                    throw new Exception("Debe indicar la factura.");

                string query = "select cpic.* from " + FacturasClienteService.Nombre_Tabla + " fc " +
                    " join " + CalendarioPagosFCClienteService.Nombre_Tabla + " cpfc on fc." + FacturasClienteService.Id_NombreCol + " = cpfc." + CalendarioPagosFCClienteService.FacturaClienteId_NombreCol +
                    " join " + CuentaCorrientePersonasService.Nombre_Vista + " cpic on cpfc." + CalendarioPagosFCClienteService.Id_NombreCol + " = cpic." + CuentaCorrientePersonasService.CalendarioPagoFcCliId_NombreCol +
                    " where " + CuentaCorrientePersonasService.Credito_NombreCol + " > " + CuentaCorrientePersonasService.Debito_NombreCol + " and " +
                    "cpic." + CuentaCorrientePersonasService.CtactePersonaRelacionada_NombreCol + " is null and " +
                    "cpic." + CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                    "cpfc." + CalendarioPagosFCClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                    "fc." + FacturasClienteService.CasoId_NombreCol + " = " + campos[CasoFacturaId_NombreCol];

                DataTable dtCuotas = sesion.db.EjecutarQuery(query);
                if (dtCuotas.Rows.Count == 0)
                    throw new Exception("No cuenta con cuotas pendientes.");

                try
                {
                    sesion.BeginTransaction();

                    RECALENDARIZACION_MAS_DETALLESRow row = new RECALENDARIZACION_MAS_DETALLESRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("recalendarizacion_mas_det_sqc");
                        row.RECALENDARIZACION_MASIVA_ID = (decimal)campos[RecalendarizacionMasivaId_NombreCol];
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.RECALENDARIZACION_MAS_DETALLESCollection.GetRow(Id_NombreCol + " = " + campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.CASO_FACTURA_ID = (decimal)campos[CasoFacturaId_NombreCol];

                    if (insertarNuevo) sesion.Db.RECALENDARIZACION_MAS_DETALLESCollection.Insert(row);
                    else sesion.Db.RECALENDARIZACION_MAS_DETALLESCollection.Update(row);

                    PersonasService persona = new PersonasService((decimal)dtCuotas.Rows[0][CuentaCorrientePersonasService.PersonaId_NombreCol]);
                    var tipo = TiposClienteRecalendarizacionService.GetTiposClientesRecalendarizacionDataTable(persona.TipoClienteId.Value);
                    int diasPorDefecto = 0;
                    if (tipo.Rows.Count > 0)
                        diasPorDefecto = int.Parse(tipo.Rows[0][TiposClienteRecalendarizacionService.DiasDefecto_NombreCol].ToString());

                    for (int i = 0; i < dtCuotas.Rows.Count; i++)
                    {
                        RecalendarizacionMasivaDeudasCuotasService.Guardar(new Hashtable() { 
                        {RecalendarizacionMasivaDeudasCuotasService.RecalendarizacionMasivaDetId_NombreCol, row.ID} ,
                        {RecalendarizacionMasivaDeudasCuotasService.CalendarioPagoCliFCOriginalId_NombreCol, dtCuotas.Rows[i][CuentaCorrientePersonasService.CalendarioPagoFcCliId_NombreCol]} ,
                        {RecalendarizacionMasivaDeudasCuotasService.NuevoVencimiento_NombreCol, ((DateTime)dtCuotas.Rows[i][CuentaCorrientePersonasService.FechaVencimiento_NombreCol]).AddDays(diasPorDefecto)} 
                        }
                        ,
                        true,
                        sesion);
                    }
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified detalles_id.
        /// </summary>
        /// <param name="detalles_id">The detalles_id.</param>
        public static void Borrar(decimal detalles_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    RECALENDARIZACION_MAS_DETALLESRow row = new RECALENDARIZACION_MAS_DETALLESRow();

                    row = sesion.Db.RECALENDARIZACION_MAS_DETALLESCollection.GetByPrimaryKey(detalles_id);

                    RecalendarizacionMasivaDeudasCuotasService.BorrarRelaciones(row.ID, sesion);

                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.RECALENDARIZACION_MAS_DETALLESCollection.DeleteByPrimaryKey(detalles_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "recalendarizacion_mas_detalles"; }
        }
        public static string CasoFacturaId_NombreCol
        {
            get { return RECALENDARIZACION_MAS_DETALLESCollection.CASO_FACTURA_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return RECALENDARIZACION_MAS_DETALLESCollection.IDColumnName; }
        }
        public static string RecalendarizacionMasivaId_NombreCol
        {
            get { return RECALENDARIZACION_MAS_DETALLESCollection.RECALENDARIZACION_MASIVA_IDColumnName; }
        }
        #endregion Tabla
        
        #region Vista
        public static string Nombre_Vista
        {
            get { return "recalen_mas_det_info_completa"; }
        }
        public static string VistaFacturaCasoEstadoId_NombreCol
        {
            get { return RECALEN_MAS_DET_INFO_COMPLETACollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaPersonaCodigo_NombreCol
        {
            get { return RECALEN_MAS_DET_INFO_COMPLETACollection.PERSONA_CODIGOColumnName; }
        }
        public static string VistaPersonaNombreCompleto_NombreCol
        {
            get { return RECALEN_MAS_DET_INFO_COMPLETACollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaFacturaNroComprobante_NombreCol
        {
            get { return RECALEN_MAS_DET_INFO_COMPLETACollection.FACTURA_NRO_COMPROBANTEColumnName; }
        }
        #endregion Vista
        #endregion Accessors
    }
}