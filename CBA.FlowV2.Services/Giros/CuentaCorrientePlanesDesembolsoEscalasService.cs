using System;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Data;

namespace CBA.FlowV2.Services.Giros
{
    public class CuentaCorrientePlanesDesembolsoEscalasService
    {
        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion= new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTACTE_PLANES_DESEM_ESCALASRow row = new CTACTE_PLANES_DESEM_ESCALASRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("CTACTE_PLAN_DESEM_ESCALAS_SQC");
                        row.CTACTE_PLAN_DESEMBOLSO_ID = (decimal)campos[CtaCtePlanDesembolsoId_NombreCol];
                    }
                    else
                    {
                        row = sesion.Db.CTACTE_PLANES_DESEM_ESCALASCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.MONTO_DESDE = (decimal)campos[MontoDesde_NombreCol];
                    row.MONTO_HASTA = (decimal)campos[MontoHasta_NombreCol];

                    if (campos.Contains(MontoComision_NombreCol))
                    {
                        row.MONTO_COMISION = (decimal)campos[MontoComision_NombreCol];
                    }
                    if (campos.Contains(PorcentajeComision_NombreCol))
                    {
                        row.PORCENTAJE_COMISION = (decimal)campos[PorcentajeComision_NombreCol];
                    }

                    if (insertarNuevo) sesion.Db.CTACTE_PLANES_DESEM_ESCALASCollection.Insert(row);
                    else sesion.Db.CTACTE_PLANES_DESEM_ESCALASCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region GetPlanesDesemEscalaDataTable
        /// <summary>
        /// Gets the activos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetPlanesDesemEscalaByIdPlan(decimal plan_id)
        {
            string where = where = CtaCtePlanDesembolsoId_NombreCol + " = " + plan_id;            
            return GetPlanesDesemEscalaDataTable(where, MontoDesde_NombreCol);
        }

        public static DataTable GetPlanesDesemEscalaDataTable(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_PLANES_DESEM_ESCALASCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetPlanesDesembolsoDataTable

        #region Get Monto y Porcentaje de comision segun monto a pagar
        public static decimal GetMontoComision(decimal id_plan, decimal monto)
        {
            DataTable dt = GetPlanesDesemEscalaByIdPlan(id_plan);
            decimal montoComision = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (monto >= (decimal)row[MontoDesde_NombreCol] && monto <= (decimal)row[MontoHasta_NombreCol])
                {
                    montoComision = (decimal)row[MontoComision_NombreCol];
                }
            }

            return montoComision;

        }

        public static decimal GetPorcentajeComision(decimal id_plan, decimal monto)
        {
            DataTable dt = GetPlanesDesemEscalaByIdPlan(id_plan);
            decimal porcentajeComision = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (monto >= (decimal)row[MontoDesde_NombreCol] && monto <= (decimal)row[MontoHasta_NombreCol])
                {
                    porcentajeComision = (decimal)row[PorcentajeComision_NombreCol];
                }
            }

            return porcentajeComision;

        }
        #endregion Get Monto y Porcentaje de comision segun monto a pagar

        #region Borrar

        public static void Borrar(decimal detalleId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    Borrar(detalleId, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void Borrar(decimal detalleId, SessionService sesion)
        {
            CTACTE_PLANES_DESEM_ESCALASRow row = sesion.Db.CTACTE_PLANES_DESEM_ESCALASCollection.GetByPrimaryKey(detalleId);
            sesion.Db.CTACTE_PLANES_DESEM_ESCALASCollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.IdNull, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);        
        }
        #endregion Borrar

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PLANES_DESEM_ESCALAS"; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PLANES_DESEM_ESCALASCollection.IDColumnName; }
        }
        public static string CtaCtePlanDesembolsoId_NombreCol
        {
            get { return CTACTE_PLANES_DESEM_ESCALASCollection.CTACTE_PLAN_DESEMBOLSO_IDColumnName; }
        }
        public static string MontoComision_NombreCol
        {
            get { return CTACTE_PLANES_DESEM_ESCALASCollection.MONTO_COMISIONColumnName; }
        }
        public static string MontoDesde_NombreCol
        {
            get { return CTACTE_PLANES_DESEM_ESCALASCollection.MONTO_DESDEColumnName; }
        }
        public static string MontoHasta_NombreCol
        {
            get { return CTACTE_PLANES_DESEM_ESCALASCollection.MONTO_HASTAColumnName; }
        }
        public static string PorcentajeComision_NombreCol
        {
            get { return CTACTE_PLANES_DESEM_ESCALASCollection.PORCENTAJE_COMISIONColumnName; }
        }
        #endregion Tabla

        #endregion Accessors
    }
}
