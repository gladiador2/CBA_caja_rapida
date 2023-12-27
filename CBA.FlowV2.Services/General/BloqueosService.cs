using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Herramientas
{
    public class BloqueosService
    {
        public DataTable GetEstados()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = new DataTable();
                table.Columns.Add("id");
                table.Columns.Add("descripcion");
                table.Rows.Add(new object[] { "S", "BLOQUEADO" });
                table.Rows.Add(new object[] { "N", "NO BLOQUEADO" });
                return table;
            }
        }
    }
}
