using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteChequesEstadosService
    {
        #region GetChequesEstados
        /// <summary>
        /// Gets the cheques estados.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetChequesEstados()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_CHEQUES_ESTADOSCollection.GetAllAsDataTable();
            }
        }
        #endregion GetChequesEstados

        #region GetNombre
        /// <summary>
        /// Gets the nombre.
        /// </summary>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static string GetNombre(decimal estado_id)
        {
            using(SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_CHEQUES_ESTADOSCollection.GetByPrimaryKey(estado_id).NOMBRE;
            }
        }
        #endregion GetNombre

        #region GetAlias
        /// <summary>
        /// Gets the alias.
        /// </summary>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static string GetAlias(decimal estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_CHEQUES_ESTADOSCollection.GetByPrimaryKey(estado_id).NOMBRE;
            }
        }
        #endregion GetAlias

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_CHEQUES_ESTADOS"; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_CHEQUES_ESTADOSCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTACTE_CHEQUES_ESTADOSCollection.NOMBREColumnName; }
        }
        public static string Alias_NombreCol
        {
            get { return CTACTE_CHEQUES_ESTADOSCollection.ALIASColumnName; }
        }
        
        #endregion Accessors


    }
}
