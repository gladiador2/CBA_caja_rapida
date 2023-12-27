using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.General
{
    public abstract class TiposPersonasService
    {
        public static DataTable GetTiposPersonasDataTable(SessionService sesion)
        {
            DataTable table = new DataTable();
            table.Columns.Add(TiposPersonasId_NombreCol);
            table.Columns.Add(TiposPersonasNombre_NombreCol);
            table.Rows.Add(new object[] { Definiciones.TiposPersonas.Fisica, Definiciones.TiposPersonas.GetNombre(Definiciones.TiposPersonas.Fisica) });
            table.Rows.Add(new object[] { Definiciones.TiposPersonas.Juridica, Definiciones.TiposPersonas.GetNombre(Definiciones.TiposPersonas.Juridica) });

            return table;
        }

        public static string TiposPersonasId_NombreCol
        {
            get { return "tiposPersonasId"; }
        }

        public static string TiposPersonasNombre_NombreCol
        {
            get { return "tiposPersonasNombre"; }
        }
    }
}
