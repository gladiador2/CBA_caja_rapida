#region Using
using System;
using System.Collections.Generic;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.TextosPredefinidos;
using CBA.FlowV2.Services.Common;
using System.ComponentModel;
using CBA.FlowV2.Services.General;
using System.Text;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Articulos;
using System.Collections;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
    public class ActivoFijoService 
    {
        #region GetActivoFijoDataTable
        public static DataTable GetActivoFijoDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string estado = "1=1";

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.CTB_REVALUOSCollection.GetAsDataTable(clausulas, orden);
                }
                else
                {
                    table = sesion.Db.CTB_REVALUOSCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }

        public static DataTable GetActivoFijoDataTableInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string estado = "1=1" ;

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.CTB_REVALUOS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
                }
                else
                {
                    table = sesion.Db.CTB_REVALUOS_INFO_COMPLETACollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetActivoDataTable

        #region Borrar
        public static void Borrar(decimal revaluo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    CTB_REVALUOSRow revaluosRow = sesion.Db.CTB_REVALUOSCollection.GetByPrimaryKey(revaluo_id);
                    revaluosRow.ESTADO = Definiciones.Estado.Inactivo;

                    sesion.Db.CTB_REVALUOSCollection.Update(revaluosRow);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Borrar

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTB_REVALUOSRow row = new CTB_REVALUOSRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("ctb_revaluos_sqc");
                    }
                    else
                    {
                        row = sesion.Db.CTB_REVALUOSCollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.COEFICIENTE = (decimal)campos[Coeficiente_NombreCol];
                    row.ACTIVO_ID = (decimal)campos[ActivoId_NombreCol];
                    row.FECHA_REVALUO = (DateTime)campos[FechaRevaluo_NombreCol];
                    row.ESTADO = (string)campos[Estado_NombreCol];
                    row.COTIZACION = (decimal)campos[Cotizacion_NombreCol];
                    row.MONEDA_ID = (decimal)campos[MonedaId_NombreCol];
                    row.MONTO = (decimal)campos[Monto_NombreCol];
                    row.VIDA_UTIL = (decimal)campos[VidaUtil_NombreCol];
                    row.VIDA_UTIL_RESTANTE = (decimal)campos[VidaUtilRestante_NombreCol];

                    row.DEPREC_FISCAL_ACUM = (decimal)campos[DepreciacionFiscalAcumulada_NombreCol];
                    row.VALOR_FISCAL_NET_CIERRE = (decimal)campos[ValorFiscalNetoAlCierre_NombreCol];
                    row.VALOR_FISCAL_REV = (decimal)campos[ValorFiscalRevaluado_NombreCol];
                    row.CUOTA_FISCAL_DEPR_ANUAL = (decimal)campos[CuotaFiscalDepreciacionAnual_NombreCol];

                    if (campos.Contains(CtbRevaluoAnteriorId_NombreCol))
                    {
                        row.CTB_REVALUO_ANTERIOR_ID = (decimal)campos[CtbRevaluoAnteriorId_NombreCol];
                    }

                    if (insertarNuevo)
                    {
                        sesion.Db.CTB_REVALUOSCollection.Insert(row);
                    }
                    else sesion.Db.CTB_REVALUOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

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
        { get { return "CTB_REVALUOS"; } }

        public static string ActivoId_NombreCol
        { get { return CTB_REVALUOSCollection.ACTIVO_IDColumnName; } }

        public static string Id_NombreCol
        { get { return CTB_REVALUOSCollection.IDColumnName; } }

        public static string Coeficiente_NombreCol
        { get { return CTB_REVALUOSCollection.COEFICIENTEColumnName; } }

        public static string CtbRevaluoAnteriorId_NombreCol
        { get { return CTB_REVALUOSCollection.CTB_REVALUO_ANTERIOR_IDColumnName; } }

        public static string Estado_NombreCol
        { get { return CTB_REVALUOSCollection.ESTADOColumnName; } }

        public static string MonedaId_NombreCol
        { get { return CTB_REVALUOSCollection.MONEDA_IDColumnName; } }

        public static string Monto_NombreCol
        { get { return CTB_REVALUOSCollection.MONTOColumnName; } }

        public static string VidaUtil_NombreCol
        { get { return CTB_REVALUOSCollection.VIDA_UTILColumnName; } }

        public static string Cotizacion_NombreCol
        { get { return CTB_REVALUOSCollection.COTIZACIONColumnName; } }

        public static string FechaRevaluo_NombreCol
        { get { return CTB_REVALUOSCollection.FECHA_REVALUOColumnName; } }

        public static string VidaUtilRestante_NombreCol
        { get { return CTB_REVALUOSCollection.VIDA_UTIL_RESTANTEColumnName; } }

        public static string ActivoNombre_NombreCol
        { get { return CTB_REVALUOS_INFO_COMPLETACollection.ACTIVO_NOMBREColumnName; } }

        public static string ActivoRubroId_NombreCol
        { get { return CTB_REVALUOS_INFO_COMPLETACollection.ACTIVO_RUBRO_IDColumnName; } }

        public static string FechaCompra_NombreCol
        { get { return CTB_REVALUOS_INFO_COMPLETACollection.FECHA_COMPRAColumnName; } }

        public static string MonedaNombre_NombreCol
        { get { return CTB_REVALUOS_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; } }

        public static string ValorFiscalRevaluado_NombreCol
        { get { return CTB_REVALUOS_INFO_COMPLETACollection.VALOR_FISCAL_REVColumnName; } }

        public static string ValorFiscalNetoAlCierre_NombreCol
        { get { return CTB_REVALUOS_INFO_COMPLETACollection.VALOR_FISCAL_NET_CIERREColumnName; } }

        public static string CasoRelacionadoId_NombreCol
        { get { return CTB_REVALUOS_INFO_COMPLETACollection.CASO_RELACIONADO_IDColumnName; } }

        public static string CuotaFiscalDepreciacionAnual_NombreCol
        { get { return CTB_REVALUOS_INFO_COMPLETACollection.CUOTA_FISCAL_DEPR_ANUALColumnName; } }

        public static string DepreciacionFiscalAcumulada_NombreCol
        { get { return CTB_REVALUOS_INFO_COMPLETACollection.DEPREC_FISCAL_ACUMColumnName; } }

        public static string VistaActivoCodigo_NombreCol
        { get { return CTB_REVALUOS_INFO_COMPLETACollection.ACTIVO_CODIGOColumnName; } }

        public static string VistaSucursalNombre_NombreCol
        { get { return CTB_REVALUOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; } }
        
        public static string VistaActivoRubroNombre_NombreCol
        { get { return CTB_REVALUOS_INFO_COMPLETACollection.ACTIVO_RUBRO_NOMBREColumnName; } }

        public static string VistaRevaluo_NombreCol
        { get { return CTB_REVALUOS_INFO_COMPLETACollection.REVALUOColumnName; } }

        #endregion Accessors
    }
}
