using System.Collections.Generic;
using System.Data;
using System;

namespace CBA.FlowV2.Services.Common
{
    public static class Serializacion
    {
        public static List<Dictionary<string, object>> DataTableSerializable(DataTable datos)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in datos.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in datos.Columns)
                {
                    object temp = dr[col];
                    string campo = temp.ToString();
                    if (temp == null || DBNull.Value.Equals(temp))
                        campo = "--";
                    if (temp is DateTime)
                        campo = ((DateTime)temp).Date.ToString("d");
                    row.Add(col.ColumnName, campo);
                }
                rows.Add(row);
            }
            return rows;
        }
    }
}
