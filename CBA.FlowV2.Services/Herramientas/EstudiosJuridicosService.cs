using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class EstudiosJuridicosService
    {
        public static bool EstaActivo(decimal abogado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ABOGADOSRow abogado = sesion.Db.ABOGADOSCollection.GetRow(" id = " + abogado_id);
                return abogado.ESTADO == Definiciones.Estado.Activo;
            }
        }

        public DataTable GetEstudios()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.ABOGADOSCollection.GetAsDataTable(" entidad_id= "+sesion.Entidad.ID, "upper(nombre_estudio)" );
                return table;
            }
        }

        public String GetNombreEstudio(Decimal abogado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ABOGADOSRow abogado = sesion.Db.ABOGADOSCollection.GetRow(" id = " + abogado_id);
                return abogado.NOMBRE_ESTUDIO;
            }
        }
    }
}
