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
    public class EstadoCivilService
    {
        public static string EstadoCivilNombre_NombreCol
        {
            get { return ESTADOS_CIVILCollection.NOMBREColumnName; }
        }

        public static string EstadoCivilDescripcion_NombreCol
        {
            get { return ESTADOS_CIVILCollection.DESCRIPCIONColumnName; }
        }

        public static string EstadoCivilEstado_NombreCol
        {
            get { return ESTADOS_CIVILCollection.ESTADOColumnName; }
        }

        public static string EstadoCivilOrden_NombreCol
        {
            get { return ESTADOS_CIVILCollection.ORDENColumnName; }
        }

        #region GetEstadosCivilesDataTable
        /// <summary>
        /// Gets the estados civiles data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEstadosCivilesDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ESTADOS_CIVILCollection.GetAsDataTable(string.Empty, ESTADOS_CIVILCollection.ORDENColumnName);
            }
        }
        public static DataTable GetEstadosCivilesDataTable(string clausulas, string orderby)
        {
            using (SessionService sesion = new SessionService()) {
                return sesion.Db.ESTADOS_CIVILCollection.GetAsDataTable(clausulas, orderby);
            }
        }

        #endregion GetEstadosCivilesDataTable



        #region EstaActivo
        public static bool EstaActivo(string estado_civil_nombre)
        {
            using (SessionService sesion = new SessionService()) {
                ESTADOS_CIVILRow estadoCivil = sesion.Db.ESTADOS_CIVILCollection.GetRow(EstadoCivilNombre_NombreCol  + " = '" + estado_civil_nombre + "'");
                return estadoCivil.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo



    }
}
