using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class TiposActivosService
    {
        #region GetTiposActivos
        public static DataTable GetTiposActivos()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.TIPOS_ACTIVOSCollection.GetAllAsDataTable();
                return table;
            }
        }
        #endregion GetTiposActivos

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TIPOS_ACTIVOS"; }
        }
        public static string Id_NombreCol
        {
            get { return TIPOS_ACTIVOSCollection.IDColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return TIPOS_ACTIVOSCollection.DESCRIPCIONColumnName; }
        }
        #endregion Accessors

    }
}
