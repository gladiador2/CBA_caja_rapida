
#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;

#endregion Using

namespace CBA.FlowV2.Services.Presupuestos
{
    public class PresupuestosEtapasService
    {
        #region GetPresupuestosEtapasDataTable
        /// <summary>
        /// Gets the presupuestos etapas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPresupuestosEtapasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PRESUPUESTOS_ETAPASCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPresupuestosEtapasDataTable

        #region GetPresupuestosEtapasInfoCompleta
        /// <summary>
        /// Gets the presupuestos etapas info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPresupuestosEtapasInfoCompleta(string clausulas,  string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PRESUPUESTOS_ETAPAS_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPresupuestosEtapasInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PRESUPUESTOS_ETAPASRow row = new PRESUPUESTOS_ETAPASRow();
                    string valorAnterior = Definiciones.Log.RegistroNuevo;
                    bool reordenar = false;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("PRESUPUESTOS_ETAPAS_SQC");
                        row.PRESUPUESTO_ID = (decimal)campos[PresupuestosEtapasService.PresupuestoId_NombreCol];
                    }
                    else
                    {
                        row = sesion.Db.PRESUPUESTOS_ETAPASCollection.GetByPrimaryKey((decimal)campos[PresupuestosEtapasService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = (string)campos[PresupuestosEtapasService.Nombre_NombreCol];
                    row.FUNCIONARIO_RESPONSABLE_ID = (decimal)campos[PresupuestosEtapasService.FuncionarioResponsableId_NombreCol];

                    if (campos.Contains(PresupuestosEtapasService.FechaEstimadaInicio_NombreCol))
                        row.FECHA_ESTIMADA_INICIO = (DateTime)campos[PresupuestosEtapasService.FechaEstimadaInicio_NombreCol];
                    else
                        row.IsFECHA_ESTIMADA_INICIONull = true;
                    
                    if (campos.Contains(PresupuestosEtapasService.FechaEstimadaFin_NombreCol))
                        row.FECHA_ESTIMADA_FIN = (DateTime)campos[PresupuestosEtapasService.FechaEstimadaFin_NombreCol];
                    else
                        row.IsFECHA_ESTIMADA_FINNull = true;

                    if (campos[PresupuestosEtapasService.Orden_NombreCol].Equals(DBNull.Value) || !row.ORDEN.Equals(campos[PresupuestosEtapasService.Orden_NombreCol]))
                    {
                        reordenar = true;
                        row.ORDEN = (decimal)campos[PresupuestosEtapasService.Orden_NombreCol];
                    }

                    if (campos.Contains(PresupuestosEtapasService.MoraPorcentaje_NombreCol))
                        row.MORA_PORCENTAJE = (decimal)campos[PresupuestosEtapasService.MoraPorcentaje_NombreCol];
                    else
                        row.MORA_PORCENTAJE = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FacturaClientePorcentajeMora);

                    if (campos.Contains(PresupuestosEtapasService.MoraPorcentaje_NombreCol))
                        row.MORA_DIAS_GRACIA = (decimal)campos[PresupuestosEtapasService.MoraDiasGracia_NombreCol];
                    else
                        row.MORA_DIAS_GRACIA = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarMoraFCDesdeDias);

                    if (campos.Contains(PresupuestosEtapasService.ArticuloPorcentaje_NombreCol))
                        row.ARTICULO_PORCENTAJE = (decimal)campos[PresupuestosEtapasService.ArticuloPorcentaje_NombreCol];
                    else
                        row.ARTICULO_PORCENTAJE = 0;

                    if (insertarNuevo) sesion.Db.PRESUPUESTOS_ETAPASCollection.Insert(row);
                    else sesion.Db.PRESUPUESTOS_ETAPASCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    if(reordenar)
                        ReordenarEtapas(row, sesion);

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
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified presupuesto_etapa_id.
        /// </summary>
        /// <param name="presupuesto_etapa_id">The presupuesto_etapa_id.</param>
        public static void Borrar(decimal presupuesto_etapa_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    PRESUPUESTOS_ETAPASRow row = sesion.Db.PRESUPUESTOS_ETAPASCollection.GetByPrimaryKey(presupuesto_etapa_id);

                    DataTable dtDetalles = PresupuestosDetalleService.GetPresupuestosDetalleDataTable(PresupuestosDetalleService.PresupuestoEtapaId_NombreCol + " = " + row.ID, string.Empty);
                    //Se borran todos los detalles asociados
                    for (int i = 0; i < dtDetalles.Rows.Count; i++ )
                        PresupuestosDetalleService.Borrar((decimal)dtDetalles.Rows[i][PresupuestosDetalleService.Id_NombreCol]);
                    
                    sesion.Db.PRESUPUESTOS_ETAPASCollection.Delete(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    row.ORDEN = Definiciones.Error.Valor.EnteroPositivo; //Se modifica el orden para que no afecte al reordenamiento
                    ReordenarEtapas(row, sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region ReordenarEtapas
        /// <summary>
        /// Reordenars the etapas.
        /// </summary>
        /// <param name="row_editada">The row_editada.</param>
        /// <param name="sesion">The sesion.</param>
        private static void ReordenarEtapas(PRESUPUESTOS_ETAPASRow row_editada, SessionService sesion)
        {
            PRESUPUESTOS_ETAPASRow[] rows = sesion.Db.PRESUPUESTOS_ETAPASCollection.GetAsArray(PresupuestosEtapasService.PresupuestoId_NombreCol + " = " + row_editada.PRESUPUESTO_ID, PresupuestosEtapasService.Orden_NombreCol);
            decimal orden = 0;

            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].ID == row_editada.ID) 
                    continue;

                if (orden + 1 == row_editada.ORDEN)
                    orden++;

                rows[i].ORDEN = ++orden;
                sesion.Db.PRESUPUESTOS_ETAPASCollection.Update(rows[i]);
            }
        }
        #endregion ReordenarEtapas

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PRESUPUESTOS_ETAPAS"; }
        }
        public static string Nombre_Vista
        {
            get { return "PRESUPUESTOS_ETAPAS_INFO_COMPL"; }
        }
        public static string ArticuloPorcentaje_NombreCol
        {
            get { return PRESUPUESTOS_ETAPASCollection.ARTICULO_PORCENTAJEColumnName; }
        }
        public static string FechaEstimadaFin_NombreCol
        {
            get { return PRESUPUESTOS_ETAPASCollection.FECHA_ESTIMADA_FINColumnName; }
        }
        public static string FechaEstimadaInicio_NombreCol
        {
            get { return PRESUPUESTOS_ETAPASCollection.FECHA_ESTIMADA_INICIOColumnName; }
        }
        public static string FuncionarioResponsableId_NombreCol
        {
            get { return PRESUPUESTOS_ETAPASCollection.FUNCIONARIO_RESPONSABLE_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PRESUPUESTOS_ETAPASCollection.IDColumnName; }
        }
        public static string MoraDiasGracia_NombreCol
        {
            get { return PRESUPUESTOS_ETAPASCollection.MORA_DIAS_GRACIAColumnName; }
        }
        public static string MoraPorcentaje_NombreCol
        {
            get { return PRESUPUESTOS_ETAPASCollection.MORA_PORCENTAJEColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return PRESUPUESTOS_ETAPASCollection.NOMBREColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return PRESUPUESTOS_ETAPASCollection.ORDENColumnName; }
        }
        public static string PresupuestoId_NombreCol
        {
            get { return PRESUPUESTOS_ETAPASCollection.PRESUPUESTO_IDColumnName; }
        }
        public static string VistaFuncionarioNombrecompleto_NombreCol
        {
            get { return PRESUPUESTOS_ETAPAS_INFO_COMPLCollection.FUNCIONARIO_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaPresupuestoObjeto_NombreCol
        {
            get { return PRESUPUESTOS_ETAPAS_INFO_COMPLCollection.PRESUPUESTO_OBJETOColumnName; }
        }
        public static string VistaTotalMontoBruto_NombreCol
        {
            get { return PRESUPUESTOS_ETAPAS_INFO_COMPLCollection.TOTAL_MONTO_BRUTOColumnName; }
        }
        public static string VistaTotalMontoDescuento_NombreCol
        {
            get { return PRESUPUESTOS_ETAPAS_INFO_COMPLCollection.TOTAL_MONTO_DESCUENTOColumnName; }
        }
        public static string VistaTotalMontoImpuesto_NombreCol
        {
            get { return PRESUPUESTOS_ETAPAS_INFO_COMPLCollection.TOTAL_MONTO_IMPUESTOColumnName; }
        }
        public static string VistaTotalMontoNeto_NombreCol
        {
            get { return PRESUPUESTOS_ETAPAS_INFO_COMPLCollection.TOTAL_MONTO_NETOColumnName; }
        }
        #endregion Accessors
    }
}
