using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Herramientas
{
    public class TiposRetencionesService
    {
        #region GetTiposRetencionesDataTable
        /// <summary>
        /// Gets the tipos credito data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTiposRetencionesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTiposRetencionesDataTable(clausulas, orden, sesion);
            }
        }
        public static DataTable GetTiposRetencionesDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.TIPOS_RETENCIONESCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetTiposRetencionesDataTable

        public static int GetCtacteValorId(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                return (int)sesion.Db.TIPOS_RETENCIONESCollection.GetByPrimaryKey(id).CTACTE_VALOR_ID;
            }
        }

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TIPOS_RETENCIONES"; }
        }
        public static string EmitirRetencion_NombreCol
        {
            get { return TIPOS_RETENCIONESCollection.EMITIR_RETENCIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return TIPOS_RETENCIONESCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return TIPOS_RETENCIONESCollection.MONEDA_IDColumnName; }
        }
        public static string MontoMinimo_NombreCol
        {
            get { return TIPOS_RETENCIONESCollection.MONTO_MINIMOColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TIPOS_RETENCIONESCollection.NOMBREColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return TIPOS_RETENCIONESCollection.PORCENTAJEColumnName; }
        }
        public static string TipoMontoAAplicar_NombreCol
        {
            get { return TIPOS_RETENCIONESCollection.TIPO_MONTO_A_APLICARColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return TIPOS_RETENCIONESCollection.CTACTE_VALOR_IDColumnName; }
        }
        #endregion Accessors
    }
}
