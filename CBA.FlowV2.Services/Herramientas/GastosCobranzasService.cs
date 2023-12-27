using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.General;
using System.Globalization;

namespace CBA.FlowV2.Services.Herramientas
{
    public class GastosCobranzasService
    {
        #region GetMontoGastoCobranza
        /// <summary>
        /// Gets the monto gasto cobranza.
        /// </summary>
        /// <param name="sucural_id">The sucural_id.</param>
        /// <param name="fecha_vencimiento">The fecha_vencimiento.</param>
        /// <param name="fecha_pago">The fecha_pago.</param>
        /// <param name="moneda_destino_id">The moneda_destino_id.</param>
        /// <param name="cotizacion_moneda_destino">The cotizacion_moneda_destino.</param>
        /// <param name="deuda">The deuda.</param>
        /// <returns></returns>
        public static decimal GetMontoGastoCobranza(decimal sucural_id, DateTime fecha_vencimiento, DateTime fecha_pago, decimal moneda_destino_id, decimal cotizacion_moneda_destino, decimal deuda)
        {
            using(SessionService sesion = new SessionService())
            {
                TimeSpan diasPasados = fecha_pago - fecha_vencimiento;
                string clausula = GastosCobranzasService.DiasAtrasoDesde_NombreCol + " < " + diasPasados.Days + " and " +
                                  GastosCobranzasService.MontoAdeudadoDesde_NombreCol + " < " + deuda.ToString(CultureInfo.InvariantCulture) + " and " +
                                  "(" + GastosCobranzasService.SucursalId_NombreCol + " is null or " + GastosCobranzasService.SucursalId_NombreCol + " = " + sucural_id + ") ";


                //Se da prioridad a los registros que especifican la sucursal a traves del ordenamiento
                GASTOS_COBRANZASRow[] rows = sesion.Db.GASTOS_COBRANZASCollection.GetAsArray(clausula, GastosCobranzasService.SucursalId_NombreCol + ", " + GastosCobranzasService.DiasAtrasoDesde_NombreCol + " desc , " + GastosCobranzasService.MontoAdeudadoDesde_NombreCol + " desc");
                
                decimal gasto = 0, cotizacionMonedaOrigen;

                if (rows.Length > 0)
                {
                    //Si es para una sucurasl en particular se obtiene la cotizacion por sucursal, sino del pais del usuario logueado
                    if (rows[0].IsSUCURSAL_IDNull)
                        cotizacionMonedaOrigen = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(rows[0].SUCURSAL_ID), rows[0].MONEDA_ID, fecha_pago, sesion);
                    else
                        cotizacionMonedaOrigen = CotizacionesService.GetCotizacionMonedaCompra(sesion.SucursalActiva.PAIS_ID, rows[0].MONEDA_ID, fecha_pago, sesion);

                    gasto = rows[0].MONTO / cotizacionMonedaOrigen * cotizacion_moneda_destino;
                }

                return gasto;
            }
        }
        #endregion GetMontoGastoCobranza

        #region GetGastosCobranzasDataTable
        /// <summary>
        /// Gets the gastos cobranzas data table.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        public static DataTable GetGastosCobranzasDataTable(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.GASTOS_COBRANZASCollection.GetAsDataTable(where, orderBy);
            }
        }
        #endregion GetGastosCobranzasDataTable

        #region GetGastosCobranzasInfoCompleta
        /// <summary>
        /// Gets the data table info completa.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        public static DataTable GetGastosCobranzasInfoCompleta(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.GASTOS_COBRANZAS_INFO_COMPLETACollection.GetAsDataTable(where, orderBy);
            }
        }
        #endregion GetGastosCobranzasDataTableInfoCompleta

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    GASTOS_COBRANZASRow row = new GASTOS_COBRANZASRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("gastos_cobranzas_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.GASTOS_COBRANZASCollection.GetRow(GastosCobranzasService.Id_NombreCol + " = " + campos[GastosCobranzasService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.ESTADO = (string)campos[GastosCobranzasService.Estado_NombreCol];
                    row.DIAS_ATRASO_DESDE = (decimal)campos[GastosCobranzasService.DiasAtrasoDesde_NombreCol];
                    row.MONTO_ADEUDADO_DESDE = (decimal)campos[GastosCobranzasService.MontoAdeudadoDesde_NombreCol];
                    row.MONEDA_ID = (decimal)campos[GastosCobranzasService.MonedaId_NombreCol];
                    row.MONTO = (decimal)campos[GastosCobranzasService.Monto_NombreCol];

                    if (campos.Contains(GastosCobranzasService.SucursalId_NombreCol))
                        row.SUCURSAL_ID = (decimal)campos[GastosCobranzasService.SucursalId_NombreCol];
                    else
                        row.IsSUCURSAL_IDNull = true;

                    if (insertarNuevo) sesion.Db.GASTOS_COBRANZASCollection.Insert(row);
                    else sesion.Db.GASTOS_COBRANZASCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "GASTOS_COBRANZAS"; }
        }
        public static string Id_NombreCol
        {
            get { return GASTOS_COBRANZASCollection.IDColumnName; }
        }
        public static string DiasAtrasoDesde_NombreCol
        {
            get { return GASTOS_COBRANZASCollection.DIAS_ATRASO_DESDEColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return GASTOS_COBRANZASCollection.MONTOColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return GASTOS_COBRANZASCollection.MONEDA_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return GASTOS_COBRANZASCollection.ESTADOColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return GASTOS_COBRANZASCollection.SUCURSAL_IDColumnName; }
        }
        public static string MontoAdeudadoDesde_NombreCol 
        {
            get { return GASTOS_COBRANZASCollection.MONTO_ADEUDADO_DESDEColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return GASTOS_COBRANZAS_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return GASTOS_COBRANZAS_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return GASTOS_COBRANZAS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return GASTOS_COBRANZAS_INFO_COMPLETACollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        #endregion Accessors
    }
}
