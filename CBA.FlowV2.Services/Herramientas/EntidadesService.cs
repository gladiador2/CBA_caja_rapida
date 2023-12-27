using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class EntidadesService
    {
        public static bool EstaActivo(decimal entidad_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ENTIDADESRow entidad = sesion.Db.ENTIDADESCollection.GetRow(EntidadId_NombreCol+ " = " + entidad_id);
                return entidad.ESTADO == Definiciones.Estado.Activo;
            }
        }

        public static DataTable GetEntidadesDataTable(string clausulas, string orderby)
        {
            using (SessionService sesion = new SessionService()) {
                DataTable table = sesion.Db.ENTIDADESCollection.GetAsDataTable(clausulas, orderby);
                return table;
            }
        }

        public DataTable GetEntidadesDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.ENTIDADESCollection.GetAsDataTable(" 1=1 ", ENTIDADESCollection.NOMBREColumnName);
                return table;
            }
        }

        public DataTable GetEntidadesActivas()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.ENTIDADESCollection.GetAsDataTable(EntidadEstado_NombreCol+" ='"+Definiciones.Estado.Activo+"' ", ENTIDADESCollection.NOMBREColumnName);
                return table;
            }
        }

        public static string EntidadId_NombreCol
        {
            get { return ENTIDADESCollection.IDColumnName; }
        }

        public static string EntidadNombre_NombreCol
        {
            get { return ENTIDADESCollection.NOMBREColumnName; }
        }

        public static string EntidadAbreviatura_NombreCol
        {
            get { return ENTIDADESCollection.ABREVIATURAColumnName; }
        }
        public static string EntidadEstado_NombreCol
        {
            get { return ENTIDADESCollection.ESTADOColumnName; }
        }
        

    }
}
