#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class MonedasDenominacionesService
    {
        #region EstaActivo
        public static bool EstaActivo(decimal monedaDenominacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                MONEDAS_DENOMINACIONESRow monedaDenomincaion = sesion.Db.MONEDAS_DENOMINACIONESCollection.GetRow(MonedaId_NombreCol + " = " + monedaDenominacion_id);
                return monedaDenomincaion.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetMonedasDenominacionesDataTable
        public static DataTable GetMonedasDenominacionesDataTable()
        {
            return GetMonedasDenominacionesDataTable("", MonedaId_NombreCol, false);
        }

        public static DataTable GetMonedasDenominacionesDataTable(string clausulas, string orden)
        {
            return GetMonedasDenominacionesDataTable(clausulas, orden, false);
        }
              
        public static DataTable GetMonedasDenominacionesDataTable(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string estado = " 1=1 ";
                if (soloActivos) estado = Estado_NombreCol + "  = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.MONEDAS_DENOMINACIONESCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.MONEDAS_DENOMINACIONESCollection.GetAsDataTable(estado, orden);
                }

                table.Columns.Add("tipo_denominacion", typeof(string));
                
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (table.Rows[i][MonedasDenominacionesService.Tipo_NombreCol].Equals(Definiciones.MonedasDenominaciones.Billete))
                        table.Rows[i]["tipo_denominacion"] = "Billetes";

                    if (table.Rows[i][MonedasDenominacionesService.Tipo_NombreCol].Equals(Definiciones.MonedasDenominaciones.Moneda))
                        table.Rows[i]["tipo_denominacion"] = "Monedas";

                    if (table.Rows[i][MonedasDenominacionesService.Tipo_NombreCol].Equals(Definiciones.MonedasDenominaciones.Cupon))
                        table.Rows[i]["tipo_denominacion"] = "Cupones";
                }
                return table;
            }
        }

        #endregion GetMonedasDenominacionesDataTable

        #region GetMonedaDenominacion
        public static DataTable GetMonedaDenominacion(decimal MonedaId, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string estado = " 1=1 ";
                string clausula = MonedaId_NombreCol + " = " + MonedaId;
                if (soloActivos) estado = Estado_NombreCol + "  = '" + Definiciones.Estado.Activo + "' ";

                table = sesion.Db.MONEDAS_DENOM_INFO_COMPLCollection.GetAsDataTable(clausula + " and " + estado, string.Empty);
                table.Columns.Add("tipo_denominacion", typeof(string));

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (table.Rows[i][MonedasDenominacionesService.Tipo_NombreCol].Equals(Definiciones.MonedasDenominaciones.Billete))
                        table.Rows[i]["tipo_denominacion"] = "Billetes";

                    if (table.Rows[i][MonedasDenominacionesService.Tipo_NombreCol].Equals(Definiciones.MonedasDenominaciones.Moneda))
                        table.Rows[i]["tipo_denominacion"] = "Monedas";

                    if (table.Rows[i][MonedasDenominacionesService.Tipo_NombreCol].Equals(Definiciones.MonedasDenominaciones.Cupon))
                        table.Rows[i]["tipo_denominacion"] = "Cupones";
                }

                return table;
            }
        }
        #endregion GetMonedaDenominacion

        #region Guardar
        
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertar_nuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    MONEDAS_DENOMINACIONESRow row = new MONEDAS_DENOMINACIONESRow();
                    String valorAnterior = string.Empty;
                                       
                    if (insertar_nuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("monedas_denominaciones_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.MONEDAS_DENOMINACIONESCollection.GetRow(Id_NombreCol + " = " + decimal.Parse((string)campos[Id_NombreCol]));
                        valorAnterior = row.ToString();
                    }

                    row.MONEDA_ID = (decimal)campos[MonedaId_NombreCol];
                    row.CTACTE_VALOR_ID = (decimal)campos[CtaCteValorId_NombreCol];
                    row.DENOMINACION = (decimal)campos[Denominacion_NombreCol];
                    row.TIPO = (decimal)campos[Tipo_NombreCol];
                    row.ESTADO = (string)campos[Estado_NombreCol];
                    row.DENOMINACION_DESCRIPCION = (string)campos[DenominacionDescripcion_NombreCol];

                    if (insertar_nuevo) sesion.Db.MONEDAS_DENOMINACIONESCollection.Insert(row);
                    else sesion.Db.MONEDAS_DENOMINACIONESCollection.Update(row);

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
            get { return "MONEDAS_DENOMINCAIONES"; }
        }
        public static string Nombre_Vista
        {
            get { return "MONEDAS_DENOM_INFO_COMPL"; }
        }
        public static string Id_NombreCol
        {
            get { return MONEDAS_DENOMINACIONESCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return MONEDAS_DENOMINACIONESCollection.MONEDA_IDColumnName; }
        }
        public static string CtaCteValorId_NombreCol
        {
            get { return MONEDAS_DENOMINACIONESCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string Denominacion_NombreCol
        {
            get { return MONEDAS_DENOMINACIONESCollection.DENOMINACIONColumnName; }
        }
        public static string DenominacionDescripcion_NombreCol
        {
            get { return MONEDAS_DENOMINACIONESCollection.DENOMINACION_DESCRIPCIONColumnName; }
        }
        public static string Tipo_NombreCol
        {
            get { return MONEDAS_DENOMINACIONESCollection.TIPOColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return MONEDAS_DENOMINACIONESCollection.ESTADOColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return MONEDAS_DENOM_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return MONEDAS_DENOM_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaCtaCteValorNombre_NombreCol
        {
            get { return MONEDAS_DENOM_INFO_COMPLCollection.CTACTE_VALOR_NOMBREColumnName; }
        }
        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return MONEDAS_DENOM_INFO_COMPLCollection.CANTIDADES_DECIMALESColumnName; }
        }
        public static string VistaMonedaCadenaDcimales_NombreCol
        {
            get { return MONEDAS_DENOM_INFO_COMPLCollection.CADENA_DECIMALESColumnName; }
        }
        #endregion Accessors
    }
}
