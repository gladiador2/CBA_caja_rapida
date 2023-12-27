#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Giros;
#endregion Using

namespace CBA.FlowV2.Services.Giros
{
    public class DesembolsosGirosDetService
    {
        #region GetDesembolsoGirosDetDataTable
        /// <summary>
        /// Gets the ordenes pago detalles data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetDesembolsoGirosDetDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetDesembolsoGirosDetDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetDesembolsoGirosDetInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESEM_GIROS_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetDesembolsoGirosDetDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.DESEMBOLSOS_GIROS_DETCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetDesembolsoGirosDetDataTable

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                DESEMBOLSOS_GIROS_DETRow row = new DESEMBOLSOS_GIROS_DETRow();
                DataTable dt = new DataTable();

                try
                {
                    sesion.Db.BeginTransaction();

                    decimal desembolsoId = (decimal)campos[DesembolsoGiroId_NombreCol];
                    decimal giroMovimientoId = (decimal)campos[CtacteGirosMovimientoId_NombreCol];
                    dt = GetDesembolsoGirosDetDataTable(DesembolsoGiroId_NombreCol + " = " + desembolsoId + " and " + CtacteGirosMovimientoId_NombreCol + " = "  + giroMovimientoId, string.Empty);

                    //validar que el mismo movimiento no sea incluido mas de una vez
                    if(dt.Rows.Count>0)
                    {
                        throw new Exception("El detalle ya se encuentra incluido en el desembolso.");
                    }                    

                    string valorAnterior = Definiciones.Log.RegistroNuevo;

                    row.ID = sesion.Db.GetSiguienteSecuencia("desembolsos_giros_det_sqc");
                    row.DESEMBOLSO_GIRO_ID = desembolsoId;
                    row.CTACTE_GIROS_MOVIMIENTO_ID = giroMovimientoId;
                    row.MONEDA_ORIGEN_ID = (decimal)campos[MonedaOrigenId_NombreCol];
                    row.MONTO_ORIGEN = (decimal)campos[MontoOrigen_NombreCol];

                    dt = DesembolsosGirosService.GetDesembolsosGirosDataTable(DesembolsosGirosService.Id_NombreCol + " = " + row.DESEMBOLSO_GIRO_ID,string.Empty);

                    row.COTIZACION_MONEDA_ORIGEN = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dt.Rows[0][DesembolsosGirosService.SucursalOrigenId_NombreCol]), row.MONEDA_ORIGEN_ID, (DateTime)dt.Rows[0][DesembolsosGirosService.Fecha_NombreCol], sesion);
                    
                    if (row.COTIZACION_MONEDA_ORIGEN.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda destino.");

                   
                    //Si las monedas origen y destino son distintas no debe convertirse
                    if (row.MONEDA_ORIGEN_ID != (decimal)dt.Rows[0][DesembolsosGirosService.MonedaId_NombreCol])
                        row.MONTO_DESTINO = row.MONTO_ORIGEN / row.COTIZACION_MONEDA_ORIGEN * (decimal)dt.Rows[0][DesembolsosGirosService.CotizacionMoneda_NombreCol];
                    else
                        row.MONTO_DESTINO = row.MONTO_ORIGEN;
                    
                    sesion.Db.DESEMBOLSOS_GIROS_DETCollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    DesembolsosGirosService.ActualizarMontoTotal(row.DESEMBOLSO_GIRO_ID,sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Borrar(detalle_id, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        public static void Borrar(decimal detalle_id, SessionService sesion)
        {           
            try
            {
                DESEMBOLSOS_GIROS_DETRow row;       
                row = sesion.Db.DESEMBOLSOS_GIROS_DETCollection.GetByPrimaryKey(detalle_id);
                decimal idDesembolso=  row.DESEMBOLSO_GIRO_ID;

                sesion.Db.DESEMBOLSOS_GIROS_DETCollection.DeleteByPrimaryKey(detalle_id);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                DesembolsosGirosService.ActualizarMontoTotal(idDesembolso,sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion borrar

        #region Accessors

        public static string Nombre_Tabla
        {
            get { return "DESEMBOLSOS_GIROS_DET"; }
        }
        public static string CotizacionMonedaOrigen_NombreCol
        {
            get { return DESEMBOLSOS_GIROS_DETCollection.COTIZACION_MONEDA_ORIGENColumnName; }
        }
        public static string CtacteGirosMovimientoId_NombreCol
        {
            get { return DESEMBOLSOS_GIROS_DETCollection.CTACTE_GIROS_MOVIMIENTO_IDColumnName; }
        }
        public static string DesembolsoGiroId_NombreCol
        {
            get { return DESEMBOLSOS_GIROS_DETCollection.DESEMBOLSO_GIRO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DESEMBOLSOS_GIROS_DETCollection.IDColumnName; }
        }
        public static string MonedaOrigenId_NombreCol
        {
            get { return DESEMBOLSOS_GIROS_DETCollection.MONEDA_ORIGEN_IDColumnName; }
        }
        public static string MontoDestino_NombreCol
        {
            get { return DESEMBOLSOS_GIROS_DETCollection.MONTO_DESTINOColumnName; }
        }
        public static string MontoOrigen_NombreCol
        {
            get { return DESEMBOLSOS_GIROS_DETCollection.MONTO_ORIGENColumnName; }
        }
        public static string VistaGiroComprobante_NombreCol
        {
            get { return DESEM_GIROS_DET_INFO_COMPLCollection.GIRO_COMPROBANTEColumnName; }
        }
        public static string VistaCtaCteGiroMovFechaDesembolso_NombreCol
        {
            get { return DESEM_GIROS_DET_INFO_COMPLCollection.CTACTE_GIRO_MOV_FECHA_DESEMBColumnName; }
        }
        public static string VistaGiroMovimientoCuotaDes_NombreCol
        {
            get { return DESEM_GIROS_DET_INFO_COMPLCollection.GIRO_MOV_CUOTA_DESColumnName; }
        }
        public static string VistaGiroMovimientoSaldo_NombreCol
        {
            get { return DESEM_GIROS_DET_INFO_COMPLCollection.GIRO_MOV_SALDOColumnName; }
        }
        public static string VistaGiroMovMonedaNombre_NombreCol
        {
            get { return DESEM_GIROS_DET_INFO_COMPLCollection.GIRO_MOV_MONEDA_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
