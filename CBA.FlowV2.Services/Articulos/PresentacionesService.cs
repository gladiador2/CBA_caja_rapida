using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Articulos
{
    public class PresentacionesService
    {
        #region Getters
        public static DataTable GetPresentacionesTodosDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PRESENTACIONESCollection.GetAllAsDataTable();
            }
        }
        #endregion Getters     
        
        #region Accesors
        public const string Nombre_Tabla = "PRESENTACIONES";
        public class Modelo : PRESENTACIONESCollection_Base { public Modelo() : base(null) { } }
        public static string Id_NombreCol
        {
            get { return PRESENTACIONESCollection.IDColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return PRESENTACIONESCollection.DESCRIPCIONColumnName; }
        }

        #endregion Accesors
    }
}
