using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Base
{
    public static class EsquemaService
    {
        public static DataTable RelacionesDeTabla(string tabla)
        {
            StringBuilder query = new StringBuilder();
            StringBuilder subquery1 = new StringBuilder();
            StringBuilder subquery2 = new StringBuilder();
            string ucc = "user_cons_columns";
            string uc = "user_constraints";
            subquery2.AppendFormat("select constraint_name {0}, r_constraint_name {1} from {2} where constraint_type = 'R' and table_name = '{3}'", ReferenciaConstraint_NombreCol, ValorConstraint_NombreCol,uc, tabla);
            subquery1.AppendFormat("select ucc_fp.*, ucc_a.table_name {0} , ucc_a.column_name {1} from {2} ucc_a join ({3}) ucc_fp on ucc_a.constraint_name = ucc_fp.{4} ", ReferenciaTabla_NombreCol, ReferenciaColumna_NombreCol, ucc, subquery2, ReferenciaConstraint_NombreCol);
            query.AppendFormat("select ucc_ic.*, ucc_c.table_name {0}, ucc_c.column_name {1} from user_cons_columns ucc_c join ({2}) ucc_ic on ucc_c.constraint_name = ucc_ic.{3}", ValorTabla_NombreCol, ValorColumna_NombreCol, subquery1, ValorConstraint_NombreCol);
            return new SessionService().Db.EjecutarQuery(query.ToString());
        }
        public static DataTable SelectTabla(string tabla)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat(@"SELECT * FROM ""{0}"";", tabla);
            return new SessionService().Db.EjecutarQuery(query.ToString());
        }
        public static DataTable SelectEsquemaTabla(string tabla)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat(@"SELECT * FROM ""{0}"" where rownum = {1}", tabla, 0);
            return new SessionService().Db.EjecutarQuery(query.ToString());
        }
        #region Accessors
        public static string ReferenciaConstraint_NombreCol
        {
            get { return "REF_CONSTRAINT"; }
        }
        public static string ReferenciaColumna_NombreCol
        {
            get { return "REF_COLUMNA"; }
        }
        public static string ReferenciaTabla_NombreCol
        {
            get { return "REF_TABLA"; }
        }
        public static string ValorConstraint_NombreCol
        {
            get { return "VAL_CONSTRAINT"; }
        }
        public static string ValorColumna_NombreCol
        {
            get { return "VAL_COLUMNA"; }
        }
        public static string ValorTabla_NombreCol
        {
            get { return "VAL_TABLA"; }
        }

        #endregion Accessors
    }
}
