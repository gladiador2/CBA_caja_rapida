using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PersonasNivelesCreditoDetallesService
    {
        #region GetPersonasNivelesCreditoDetallesDataTable
        public DataTable GetPersonasNivelesCreditoDetallesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.PERSONAS_NIVELES_CREDITO_DETCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetPersonasNivelesCreditoDetallesDataTable

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PERSONAS_NIVELES_CREDITO_DET"; }
        }
        public static string Id_NombreCol
        {
            get { return PERSONAS_NIVELES_CREDITO_DETCollection.IDColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return PERSONAS_NIVELES_CREDITO_DETCollection.DESCRIPCIONColumnName; }
        }
        public static string PersonaNivelCreditoId_NombreCol
        {
            get { return PERSONAS_NIVELES_CREDITO_DETCollection.PERSONA_NIVEL_CREDITO_IDColumnName; }
        }
        #endregion Accessors
    }
}
