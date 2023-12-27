using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Contabilidad
{
    public class CuentasGruposService
    {
        #region Getters
        public static DataTable GetCuentasGruposDataTable(decimal id)
        {
            return GetCuentasGruposDataTable(CuentasGruposService.Id_NombreCol + " = " + id);
        }

        public static DataTable GetCuentasGruposDataTable(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTB_CUENTAS_GRUPOSCollection.GetAsDataTable(clausulas, string.Empty);
            }
        }
        #endregion

        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "CTB_CUENTAS_GRUPOS"; }
        }
        public static string Id_NombreCol
        {
            get { return CTB_CUENTAS_GRUPOSCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTB_CUENTAS_GRUPOSCollection.NOMBREColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTB_CUENTAS_GRUPOSCollection.ESTADOColumnName; }
        }
        #endregion

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTB_CUENTAS_GRUPOSRow row = new CTB_CUENTAS_GRUPOSRow();
                    string valorAnterior = string.Empty;

                    #region Validaciones
                    if (((string)campos[CuentasGruposService.Nombre_NombreCol]).Length <= 0)
                        throw new Exception("Debe indicar el nombre del grupo");
                    #endregion Validaciones

                    if (!campos.Contains(CuentasGruposService.Id_NombreCol))
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("CTB_CUENTAS_GRUPOS_SQC");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.db.CTB_CUENTAS_GRUPOSCollection.GetRow(CuentasGruposService.Id_NombreCol + " = " + campos[CuentasGruposService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = (string)campos[CuentasGruposService.Nombre_NombreCol];
                    row.ESTADO = (string)campos[CuentasGruposService.Estado_NombreCol];

                    if (!campos.Contains(CuentasGruposService.Id_NombreCol)) sesion.Db.CTB_CUENTAS_GRUPOSCollection.Insert(row);
                    else sesion.Db.CTB_CUENTAS_GRUPOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();

                    return row.ID;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        #endregion
    }
}
