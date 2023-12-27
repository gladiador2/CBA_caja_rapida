using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;

namespace CBA.FlowV2.Services.General
{
    public class ChequesEstadosService
    {
        public static DataTable GetChequesEstadosDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_CHEQUES_ESTADOSCollection.GetAllAsDataTable();
            }
        }

        public static DataTable GetChequesEstadosDatatable(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_CHEQUES_ESTADOSCollection.GetAsDataTable(clausulas, string.Empty);
            }
        }

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_CHEQUES_ESTADOS"; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_CHEQUES_ESTADOSCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTACTE_CHEQUES_ESTADOSCollection.NOMBREColumnName; }
        }
        public static string Alias_NombreCol
        {
            get { return CTACTE_CHEQUES_ESTADOSCollection.ALIASColumnName; }
        }
        #endregion Accessors


    }
}
