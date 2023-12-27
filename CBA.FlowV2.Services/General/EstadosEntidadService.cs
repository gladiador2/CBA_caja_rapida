using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Herramientas
{
    public class EstadosEntidadService
    {
        public DataTable GetEstadosEntidadDataTable(SessionService sesion)
        {
            DataTable table = new DataTable();
            table.Columns.Add(EstadoEntidadId_NombreCol);
            table.Columns.Add(EstadoEntidadNombre_NombreCol);
            table.Rows.Add(new object[] { Definiciones.Estado.Activo, Definiciones.Estado.GetNombre(Definiciones.Estado.Activo) });
            table.Rows.Add(new object[] { Definiciones.Estado.Inactivo, Definiciones.Estado.GetNombre(Definiciones.Estado.Inactivo) });
            return table;
        }

        public static string EstadoEntidadId_NombreCol
        {
            get { return "estadoEntidadId"; }
        }

        public static string EstadoEntidadNombre_NombreCol
        {
            get { return "estadoEntidadNombre"; }
        }
    }
}
