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
    public class ActivosRubrosService
    {
        #region GetActivosRubros
        public static DataTable GetActivosRubros()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.ACTIVOS_RUBROSCollection.GetAllAsDataTable();
                return table;
            }
        }
        #endregion GetTiposActivos

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ACTIVOS_RUBROS"; }
        }
        public static string Id_NombreCol
        {
            get { return ACTIVOS_RUBROSCollection.IDColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return ACTIVOS_RUBROSCollection.DESCRIPCIONColumnName; }
        }
        public static string VidaUtil_NombreCol
        {
            get { return ACTIVOS_RUBROSCollection.VIDA_UTIL_ANHOSColumnName; }
        }
        #endregion Accessors

    }
}
