using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.General
{
    public class TiposEmbarqueService
    {
        public DataTable GetTiposEmbarque()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.TIPOS_EMBARQUECollection.GetAsDataTable(" 1=1 ", "upper(nombre)" );
                return table;
            }
        }

        public TiposEmbarqueService()
        {
        }
        public static string Nombre_Tabla
        {
            get { return "TIPOS EMBARQUE"; }
        }
        public static string Id_NombreCol
        {
            get { return TIPOS_EMBARQUECollection.IDColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return TIPOS_EMBARQUECollection.DESCRIPCIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return TIPOS_EMBARQUECollection.ESTADOColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TIPOS_EMBARQUECollection.NOMBREColumnName; }
        }
    }
}
