using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class TiposCuentaCorrienteBancariasService
    {
        #region GetTiposCuentaCorrienteBancariasDataTable
        /// <summary>
        /// Retorna un datatable con la informacion de los tipos de cuenta bancaria
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetTiposCuentaCorrienteBancariasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = " 1=1 ";
                if (clausulas.Length > 0) where += " and " + clausulas;

                return sesion.Db.TIPOS_CTACTE_BANCARIASCollection.GetAsDataTable(where, orden);
            }
        }

        #endregion GetTiposCuentaCorrienteBancariasDataTable

        #region Guardar
        //a la fecha de creacion del script, se agregan manualmente los registros (2013-05-28)
        #endregion Guardar

        #region Constructor
        public TiposCuentaCorrienteBancariasService() { 
        
        }

        #endregion Constructor

        #region Accessors

        #region Tabla

        public static string Nombre_Tabla
        {
            get { return "TIPOS_CTACTE_BANCARIAS"; }
        }
        //id
        public static string Id_NombreCol
        {
            get { return TIPOS_CTACTE_BANCARIASCollection.IDColumnName; }
        }
        //descripcion
        public static string Descripcion_NombreCol
        {
            get { return TIPOS_CTACTE_BANCARIASCollection.DESCRIPCIONColumnName; }
        }

        #endregion Tabla

        #region Vista
        //no existe vista en esta tabla
        #endregion Vista

        #endregion Accessors
    }
}
