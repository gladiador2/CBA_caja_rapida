using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteCajasSucursalEstadosService
    {
        #region GetCuentaCorrienteCajasSucursalEstadosServiceDataTable
        public DataTable GetCuentaCorrienteCajasSucursalEstadosServiceDataTable()
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return sesion.Db.CTACTE_CAJAS_SUCURSAL_ESTADOSCollection.GetAllAsDataTable();
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetCuentaCorrienteCajasSucursalEstadosServiceDataTable
        
        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_CAJAS_SUCURSAL_ESTADOS"; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTACTE_CAJAS_SUCURSAL_ESTADOSCollection.NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
