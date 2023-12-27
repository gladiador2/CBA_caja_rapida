#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
   public class IndicadoresService
   {
        #region GetIndicadoresDataTable

       /// <summary>
       /// Gets the indicadores data table.
       /// </summary>
       /// <param name="clausulas">The clausulas.</param>
       /// <param name="orden">The orden.</param>
       /// <returns></returns>
        public DataTable GetIndicadoresDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = EntidadId_NombreCol + " = " + sesion.Entidad.ID;

                if (clausulas.Length > 0)
                {
                    where += " and " + clausulas;
                }

                return sesion.Db.CTB_INDICADORESCollection.GetAsDataTable(where, orden);               
            }
        }

        #endregion GetIndicadoresDataTable.

        #region GetIndicadoresInfoCompleta

        /// <summary>
        /// Gets the indicadores data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetIndicadoresInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = EntidadId_NombreCol + " = " + sesion.Entidad.ID;

                if (clausulas.Length > 0)
                {
                    where += " and " + clausulas;
                }

                return sesion.Db.CTB_INDICADORES_INFO_COMPLCollection.GetAsDataTable(where, orden);
            }
        }

        #endregion GetIndicadoresInfoCompleta

        #region Borrar

        /// <summary>
        /// Borrars the specified indicador_id.
        /// </summary>
        /// <param name="indicador_id">The indicador_id.</param>
        public void Borrar(decimal indicador_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_INDICADORESRow row;
                IndicadoresService indicador = new IndicadoresService();
                IndicadoresDetalleService indicadorDetalle = new IndicadoresDetalleService();

                DataTable dtIndicadorDetalles = indicadorDetalle.GetIndicadoresDetalleDataTable(IndicadoresDetalleService.CtbIndicadorId_NombreCol + " = " + indicador_id, string.Empty);

                for (int i = 0; i < dtIndicadorDetalles.Rows.Count; i++)
                { 
                    indicadorDetalle.Borrar(decimal.Parse(dtIndicadorDetalles.Rows[i].ToString()));
                }

                row = sesion.Db.CTB_INDICADORESCollection.GetByPrimaryKey(indicador_id);

                sesion.Db.CTB_INDICADORESCollection.DeleteByPrimaryKey(indicador_id);
                
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
        }
        #endregion borrar
       
        #region Guardar

        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <returns></returns>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTB_INDICADORESRow row = new CTB_INDICADORESRow();
                    
                    string valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("ctb_indicadores_sqc");
                        row.ENTIDAD_ID = sesion.Entidad.ID;
                    }
                    else
                    {
                        row = sesion.Db.CTB_INDICADORESCollection.GetByPrimaryKey((decimal)campos[IndicadoresService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = campos[IndicadoresService.Nombre_NombreCol].ToString();
                    row.DESCRIPCION = campos[IndicadoresService.Descripcion_NombreCol].ToString();
                    row.CTB_PLAN_CUENTAS = (decimal)campos[IndicadoresService.CtbPlanCuentas_NombreCol];

                    row.LIMITE_INFERIOR_NORMAL = (decimal)campos[IndicadoresService.LimiteInferiorNormal_NombreCol];
                    row.LIMITE_SUPERIOR_NORMAL = (decimal)campos[IndicadoresService.LimiteSuperiorNormal_NombreCol];
                    if (campos.Contains(IndicadoresService.LimiteInferiorMultinacional_NombreCol))
                        row.LIMITE_INFERIOR_MULTINACIONAL = (decimal)campos[IndicadoresService.LimiteInferiorMultinacional_NombreCol];
                    if (campos.Contains(IndicadoresService.LimiteSuperiorMultinacional_NombreCol))
                        row.LIMITE_SUPERIOR_MULTINACIONAL = (decimal)campos[IndicadoresService.LimiteSuperiorMultinacional_NombreCol];
                    row.PORCENTAJE_DE_ALARMA = (decimal)campos[IndicadoresService.PorcentajeDeAlarma_NombreCol];

                    if (insertarNuevo) sesion.Db.CTB_INDICADORESCollection.Insert(row);
                    else sesion.Db.CTB_INDICADORESCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch (Exception exc)
                {
                    sesion.Db.RollbackTransaction();
                    throw exc;
                }
            }
        }
        #endregion Guardar

        #region ObtenerFormula

        /// <summary>
        /// Obteners the formula.
        /// </summary>
        /// <param name="indicador_id">The indicador_id.</param>
        /// <param name="detalle_id">The detalle_id.</param>
        /// <returns></returns>
        public string ObtenerFormula(decimal indicador_id, decimal detalle_id)
        {
            string formula;
            IndicadoresDetalleService indicadoresDetalle = new IndicadoresDetalleService();
            CuentasService cuenta = new CuentasService();
            IndicadoresOperacionesService indicadoresOperacion = new IndicadoresOperacionesService();
            DataTable detalles;

            //Si es la raiz
            if (indicador_id != Definiciones.Error.Valor.EnteroPositivo && detalle_id == Definiciones.Error.Valor.EnteroPositivo)
            {
                //Se obtiene la raiz
                detalles = indicadoresDetalle.GetIndicadoresDetalleDataTable(IndicadoresDetalleService.CtbIndicadorId_NombreCol + " = " + indicador_id + " and " + IndicadoresDetalleService.CtbIndicadoresDetallePadre_NombreCol + " is null", string.Empty);

                //Si todavia no tiene detalles
                if (detalles.Rows.Count < 1)
                    return string.Empty;
                
                //La UI deberia realizar las validaciones siguientes
                #region Validaciones Innecesarias

                //Si tiene mas de una raiz, esta incorrecta la formula
                if (detalles.Rows.Count > 1)
                    return "Error. La formula tiene dos raices.";

                //Si la raiz no tiene operacion, esta incorrecta la formula
                if (detalles.Rows[0][IndicadoresDetalleService.Operacion_NombreCol].Equals(DBNull.Value))
                    return "Error. La raiz no tiene operacion.";

                #endregion Validaciones Innecesarias

                formula = ObtenerFormula(Definiciones.Error.Valor.EnteroPositivo, decimal.Parse(detalles.Rows[0][IndicadoresDetalleService.CtbIndicadoresDetalle1_NombreCol].ToString()));

                formula += " " + indicadoresOperacion.GetSimbolo(decimal.Parse(detalles.Rows[0][IndicadoresDetalleService.Operacion_NombreCol].ToString())) + " ";

                formula += ObtenerFormula(Definiciones.Error.Valor.EnteroPositivo, decimal.Parse(detalles.Rows[0][IndicadoresDetalleService.CtbIndicadoresDetalle2_NombreCol].ToString()));
            }
            //Si no es la raiz
            else
            {
                detalles = indicadoresDetalle.GetIndicadoresDetalleDataTable(IndicadoresDetalleService.Id_NombreCol + " = " + detalle_id, string.Empty);

                //Si no es hoja
                if (!detalles.Rows[0][IndicadoresDetalleService.Operacion_NombreCol].Equals(DBNull.Value))
                {
                    formula = "(";

                    formula += ObtenerFormula(Definiciones.Error.Valor.EnteroPositivo, decimal.Parse(detalles.Rows[0][IndicadoresDetalleService.CtbIndicadoresDetalle1_NombreCol].ToString()));

                    formula += " " + indicadoresOperacion.GetSimbolo(decimal.Parse(detalles.Rows[0][IndicadoresDetalleService.Operacion_NombreCol].ToString())) + " ";

                    formula += ObtenerFormula(Definiciones.Error.Valor.EnteroPositivo, decimal.Parse(detalles.Rows[0][IndicadoresDetalleService.CtbIndicadoresDetalle2_NombreCol].ToString()));

                    formula += ")";

                }
                //Si es hoja
                else
                {
                    formula = cuenta.GetNombre(decimal.Parse(detalles.Rows[0][IndicadoresDetalleService.CtbCuentaId_NombreCol].ToString()));
                }
            }

            return formula;
        }

        #endregion ObtenerFormula

        #region Accessors

        public static string Nombre_Tabla
        {
            get { return "CTB_INDICADORES"; }
        }

        public static string CtbPlanCuentas_NombreCol
        {
            get { return CTB_INDICADORESCollection.CTB_PLAN_CUENTASColumnName; }
        }

        public static string Descripcion_NombreCol
        {
            get { return CTB_INDICADORESCollection.DESCRIPCIONColumnName; }
        }

        public static string EntidadId_NombreCol
        {
            get { return CTB_INDICADORESCollection.ENTIDAD_IDColumnName; }
        }

        public static string Id_NombreCol
        {
            get { return CTB_INDICADORESCollection.IDColumnName; }
        }

        public static string LimiteInferiorMultinacional_NombreCol
        {
            get { return CTB_INDICADORESCollection.LIMITE_INFERIOR_MULTINACIONALColumnName; }
        }

        public static string LimiteSuperiorMultinacional_NombreCol
        {
            get { return CTB_INDICADORESCollection.LIMITE_SUPERIOR_MULTINACIONALColumnName; }
        }

        public static string LimiteInferiorNormal_NombreCol
        {
            get { return CTB_INDICADORESCollection.LIMITE_INFERIOR_NORMALColumnName; }
        }

        public static string LimiteSuperiorNormal_NombreCol
        {
            get { return CTB_INDICADORESCollection.LIMITE_SUPERIOR_NORMALColumnName; }
        }
        
        public static string Nombre_NombreCol
        {
            get { return CTB_INDICADORESCollection.NOMBREColumnName; }
        }

        public static string PorcentajeDeAlarma_NombreCol
        {
            get { return CTB_INDICADORESCollection.PORCENTAJE_DE_ALARMAColumnName; }
        }

        public static string VistaCtbPlanCuentasNombre_NombreCol
        {
            get { return CTB_INDICADORES_INFO_COMPLCollection.CTB_PLAN_CUENTAS_NOMBREColumnName; }
        }

        public static string VistaEntidadNombre_NombreCol
        {
            get { return CTB_INDICADORES_INFO_COMPLCollection.ENTIDAD_NOMBREColumnName; }
        }

        #endregion Accessors
    }
}
