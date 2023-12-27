using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Common;

namespace CBA.FlowV2.Services.Contabilidad
{
    public class CuentasGruposDetalleService
    {
        #region Getters
        public static DataTable GetDataTable(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTB_CUENTAS_GRUPOS_DETCollection.GetAsDataTable(CuentasGruposDetalleService.Id_NombreCol + " = " + id, string.Empty);
            }
        }
        public static DataTable GetDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetDataTable(clausulas, orden, sesion);
            }
        }
        public static DataTable GetDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTB_CUENTAS_GRUPOS_DETCollection.GetAsDataTable(clausulas, orden);
        }

        public static DataTable GetInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTB_CUENTAS_GRUPOS_DET_INF_CCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion

        #region Guardar
        public static decimal Guardar(decimal ctb_cuenta_id, decimal ctb_cuentas_grupos_id, decimal ctb_cuentas_grupos_hijo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    #region Validar que no es parte del grupo
                    string clausulas = CuentasGruposDetalleService.CtbCuentasGruposId_NombreCol + " = " + ctb_cuentas_grupos_id + " and " +
                                       CuentasGruposDetalleService.CtbCuentaId_NombreCol + " = " + ctb_cuenta_id;
                    DataTable dt = CuentasGruposDetalleService.GetInfoCompleta(clausulas, string.Empty);

                    if (dt.Rows.Count > 0)
                        throw new Exception("La cuenta contable " + dt.Rows[0][CuentasGruposDetalleService.VistaCuentaNombre_NombreCol] + " ya forma parte del grupo.");
                    #endregion Validar que no es parte del grupo

                    CTB_CUENTAS_GRUPOS_DETRow row = new CTB_CUENTAS_GRUPOS_DETRow();
                    string valorAnterior = string.Empty;

                    row.ID = sesion.Db.GetSiguienteSecuencia("CTB_CUENTAS_GRUPOS_DET_SQC");
                    valorAnterior = Definiciones.Log.RegistroNuevo;

                    row.CTB_CUENTAS_GRUPOS_ID = ctb_cuentas_grupos_id;

                    if (!ctb_cuenta_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        row.CTB_CUENTA_ID = ctb_cuenta_id;

                    if (!ctb_cuentas_grupos_hijo_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        row.CTB_CUENTAS_GRUPOS_HIJO_ID = ctb_cuentas_grupos_hijo_id;

                    sesion.Db.CTB_CUENTAS_GRUPOS_DETCollection.Insert(row);

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

        #region GetCuentasContablesGrupos
        public static List<decimal> GetCuentasContablesGrupos(decimal cuenta_grupo_id)
        {
            List<decimal> cuentasIncluidas = new List<decimal>();
            GetCuentasEnGrupo(cuenta_grupo_id, ref cuentasIncluidas);
            return cuentasIncluidas;
        }

        private static void GetCuentasEnGrupo(decimal cuenta_grupo_id, ref List<decimal> cuentas_incluidas)
        {
            DataTable dt = GetDataTable(cuenta_grupo_id);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Interprete.EsNullODBNull(dt.Rows[i][CuentasGruposDetalleService.CtbCuentaId_NombreCol]))
                    GetCuentasEnGrupo((decimal)dt.Rows[i][CuentasGruposDetalleService.CtbCuentasGruposHijoId_NombreCol], ref cuentas_incluidas);
                else
                    cuentas_incluidas.Add((decimal)dt.Rows[i][CuentasGruposDetalleService.CtbCuentaId_NombreCol]);
            }
        }
        #endregion

        #region Borrar
        public static void Borrar(decimal grupo_det_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_CUENTAS_GRUPOS_DETRow row = sesion.Db.CTB_CUENTAS_GRUPOS_DETCollection.GetByPrimaryKey(grupo_det_id);
                sesion.Db.CTB_CUENTAS_GRUPOS_DETCollection.Delete(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
        }
        #endregion

        #region Accesors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "CTB_CUENTAS_GRUPOS_DET"; }
        }
        public static string Id_NombreCol
        {
            get { return CTB_CUENTAS_GRUPOS_DETCollection.IDColumnName; }
        }
        public static string CtbCuentaId_NombreCol
        {
            get { return CTB_CUENTAS_GRUPOS_DETCollection.CTB_CUENTA_IDColumnName; }
        }
        public static string CtbCuentasGruposId_NombreCol
        {
            get { return CTB_CUENTAS_GRUPOS_DETCollection.CTB_CUENTAS_GRUPOS_IDColumnName; }
        }
        public static string CtbCuentasGruposHijoId_NombreCol
        {
            get { return CTB_CUENTAS_GRUPOS_DETCollection.CTB_CUENTAS_GRUPOS_HIJO_IDColumnName; }
        }
        #endregion

        #region Vista
        public static string Nombre_Vista
        {
            get { return "CTB_CUENTAS_GRUPOS_DET_INF_C"; }
        }
        public static string VistaCuentaNombre_NombreCol
        {
            get { return CTB_CUENTAS_GRUPOS_DET_INF_CCollection.CUENTA_NOMBREColumnName; }
        }
        public static string VistaCuentaGrupoNombre_NombreCol
        {
            get { return CTB_CUENTAS_GRUPOS_DET_INF_CCollection.CUENTA_GRUPOS_NOMBREColumnName; }
        }
        public static string VistaCuentaGrupoEstadoNombre_NombreCol
        {
            get { return CTB_CUENTAS_GRUPOS_DET_INF_CCollection.CUENTA_GRUPOS_ESTADOColumnName; }
        }
        public static string VistaCuentaGrupoHijoNombre_NombreCol
        {
            get { return CTB_CUENTAS_GRUPOS_DET_INF_CCollection.CUENTA_GRUPOS_HIJO_NOMBREColumnName; }
        }
        #endregion

        #endregion
    }
}
