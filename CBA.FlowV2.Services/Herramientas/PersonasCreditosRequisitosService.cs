using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PersonasCreditosRequisitosService
    {
        #region GetPersonasCreditosRequisitosDataTable
        public DataTable GetPersonasCreditosRequisitosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.PERSONAS_CREDITOS_REQUISITOSCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetPersonasCreditosRequisitosDataTable

        #region PersonaTieneRequisito
        public bool PersonaTieneRequisito(decimal personaId,decimal requisitoId)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string clausulas = PersonaId_NombreCol + " = " + personaId.ToString() + " and " +
                    PersonasNivelesCreditoDetId_NombreCol + " = " + requisitoId.ToString();
                table = sesion.Db.PERSONAS_CREDITOS_REQUISITOSCollection.GetAsDataTable(clausulas, string.Empty);
                return table.Rows.Count>0;
            }
        }
        #endregion PersonaTieneRequisito

        #region Guardar
        public void Guardar(SessionService sesion, decimal personaId, string[] requisitos)
        {
            //borrar los requisitos de la persona antes de agregar
            sesion.Db.PERSONAS_CREDITOS_REQUISITOSCollection.Delete(PersonaId_NombreCol + " = " + personaId.ToString());

            for (int i = 0; i < requisitos.Length; i++)
            {
                PERSONAS_CREDITOS_REQUISITOSRow row = new PERSONAS_CREDITOS_REQUISITOSRow();
                row.PERS_NIVELES_CREDITO_DET_ID = decimal.Parse(requisitos[i]);
                row.PERSONA_ID = personaId;
                sesion.Db.PERSONAS_CREDITOS_REQUISITOSCollection.Insert(row);
            }
        }
        #endregion Guardar        

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PERSONAS_CREDITOS_REQUISITOS"; }
        }
        public static string PersonasNivelesCreditoDetId_NombreCol
        {
            get { return PERSONAS_CREDITOS_REQUISITOSCollection.PERS_NIVELES_CREDITO_DET_IDColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return PERSONAS_CREDITOS_REQUISITOSCollection.PERSONA_IDColumnName; }
        }
        #endregion Accessors
    }
}
