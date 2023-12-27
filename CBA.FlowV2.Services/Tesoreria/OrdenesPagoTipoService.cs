using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;

using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class OrdenesPagoTipoService
    {
        #region GetOrdenesPagoTipoDataTable
        /// <summary>
        /// Gets the ordenes pago tipo data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetOrdenesPagoTipoDataTable()
        {
            return GetOrdenesPagoTipoDataTable(string.Empty, OrdenesPagoTipoService.Orden_NombreCol);
        }

        /// <summary>
        /// Gets the ordenes pago tipo data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetOrdenesPagoTipoDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ORDENES_PAGO_TIPOCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetOrdenesPagoTipoDataTable

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ORDENES_PAGO_TIPO"; }
        }
        public static string Id_NombreCol
        {
            get { return ORDENES_PAGO_TIPOCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return ORDENES_PAGO_TIPOCollection.NOMBREColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return ORDENES_PAGO_TIPOCollection.ORDENColumnName; }
        }
        #endregion Accessors
    }
}
