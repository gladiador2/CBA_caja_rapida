using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.General
{
    public class TiposAutonumeracionesService
    {
        [Obsolete("Utilizar métodos estáticos")]
        public DataTable GetTiposAutonumeracion()
        {
            return GetTiposAutonumeracion2();
        }
        public static DataTable GetTiposAutonumeracion2()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.TIPOS_AUTONUMERACIONCollection.GetAllAsDataTable();
                return table;
            }
        }

        public TiposAutonumeracionesService()
        {
        }
        #region Nombre de Columnas
        public static string Id_NombreCol
        {
            get { return TIPOS_CONTENEDORCollection.IDColumnName; }
        }
        public static string DESCRIPCION_NombreCol
        {
            get { return TIPOS_AUTONUMERACIONCollection.DESCRIPCIONColumnName; }
        }
        public static string NOMBRE_NombreCol
        {
            get { return TIPOS_AUTONUMERACIONCollection.NOMBREColumnName; }
        }
        public static string TIENE_VENCIMIENTO_NombreCol
        {
            get { return TIPOS_AUTONUMERACIONCollection.TIENE_VENCIMIENTOColumnName; }
        }
        public static string ESTADO_NombreCol
        {
            get { return TIPOS_AUTONUMERACIONCollection.ESTADOColumnName; }
        }
        #endregion Nombre de Columnas
    }
}
