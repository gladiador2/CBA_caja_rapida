using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.General
{
    public class EstadosService
    {
        public static DataTable GetEstadosDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = new DataTable();
                table.Columns.Add(EstadosService.EstadoId_NombreCol);
                table.Columns.Add(EstadosService.EstadoNombre_NombreCol);
                table.Rows.Add(new object[] { Definiciones.Estado.Activo, Definiciones.Estado.GetNombre(Definiciones.Estado.Activo) });
                table.Rows.Add(new object[] { Definiciones.Estado.Inactivo, Definiciones.Estado.GetNombre(Definiciones.Estado.Inactivo) });
                return table;
            }
        }

        public static string EstadoId_NombreCol
        {
            get { return "EstadoId"; }
        }

        public static string EstadoNombre_NombreCol
        {
            get { return "EstadoNombre"; }
        }
    }
}
