using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class TratamientosService
    {
        public static bool EstaActivo(String tratamiento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                TRATAMIENTOSRow tratamiento = sesion.Db.TRATAMIENTOSCollection.GetRow(Nombre_NombreCol+"  = '" + tratamiento_id + "'");
                return tratamiento.ESTADO == Definiciones.Estado.Activo;
            }
        }

        public DataTable GetTratamientosDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.TRATAMIENTOSCollection.GetAsDataTable(" 1=1 ", "upper("+TratamientosService.Descripcion_NombreCol+")" );
                return table;
            }
        }

        public static DataTable GetTratamientosDataTable(string clausula, string order_by)
        {
            using (SessionService sesion = new SessionService()) {
                DataTable table = sesion.Db.TRATAMIENTOSCollection.GetAsDataTable(clausula, order_by);
                return table;
            }
        }


        public DataTable GetTratamientosActivos()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.TRATAMIENTOSCollection.GetAsDataTable(TratamientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ", TratamientosService.Descripcion_NombreCol);
                return table;
            }
        }

        public String GetDescripcion(String nombre)
        {
            using (SessionService sesion = new SessionService())
            {
                TRATAMIENTOSRow t = sesion.Db.TRATAMIENTOSCollection.GetRow(TratamientosService.Nombre_NombreCol + " = '" + nombre + "'");
                return t.DESCRIPCION;
            }
        }
        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TRATAMIENTOS"; }
        }
        public static string Nombre_NombreCol
        {
            get { return TRATAMIENTOSCollection.NOMBREColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return TRATAMIENTOSCollection.ESTADOColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return TRATAMIENTOSCollection.DESCRIPCIONColumnName; }
        }

        #endregion Accessors
    }
}
