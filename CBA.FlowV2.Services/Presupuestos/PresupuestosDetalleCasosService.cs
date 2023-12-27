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
    public class PresupuestosDetalleCasosService
    {
        #region GetPresupuestosDetalleCasosDataTable
        /// <summary>
        /// Gets the presupuestos detalle casos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPresupuestosDetalleCasosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PRESUPUESTOS_DET_CASOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPresupuestosDetalleCasosDataTable

        #region GetPresupuestosDetalleCasosInfoCompleta
        /// <summary>
        /// Gets the presupuestos detalle casos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPresupuestosDetalleCasosInfoCompleta(string clausulas,  string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PRESUPUESTOS_DET_CAS_INF_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPresupuestosDetalleCasosInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PRESUPUESTOS_DET_CASOSRow row = new PRESUPUESTOS_DET_CASOSRow();
                    string valorAnterior = Definiciones.Log.RegistroNuevo;

                    if (!campos.Contains(PresupuestosDetalleCasosService.Id_NombreCol))
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("PRESUPUESTOS_DET_CASOS_SQC");
                        row.PRESUPUESTOS_DETALLE_ID = (decimal)campos[PresupuestosDetalleCasosService.PresupuestoDetalleId_NombreCol];
                    }
                    else
                    {
                        row = sesion.Db.PRESUPUESTOS_DET_CASOSCollection.GetByPrimaryKey((decimal)campos[PresupuestosDetalleCasosService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.CASO_ID = (decimal)campos[PresupuestosDetalleCasosService.CasoId_NombreCol];
                    row.OBSERVACION = (string)campos[PresupuestosDetalleCasosService.Observacion_NombreCol];

                    if (!campos.Contains(PresupuestosDetalleCasosService.Id_NombreCol)) sesion.Db.PRESUPUESTOS_DET_CASOSCollection.Insert(row);
                    else sesion.Db.PRESUPUESTOS_DET_CASOSCollection.Update(row);
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

        #region Borrar
        /// <summary>
        /// Borrars the specified presupuesto_det_caso_id.
        /// </summary>
        /// <param name="presupuesto_det_caso_id">The presupuesto_det_caso_id.</param>
        public static void Borrar(decimal presupuesto_det_caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    PRESUPUESTOS_DET_CASOSRow row = sesion.Db.PRESUPUESTOS_DET_CASOSCollection.GetByPrimaryKey(presupuesto_det_caso_id);

                    sesion.Db.PRESUPUESTOS_DET_CASOSCollection.DeleteByPrimaryKey(presupuesto_det_caso_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PRESUPUESTOS_DET_CASOS"; }
        }
        public static string CasoId_NombreCol
        {
            get { return PRESUPUESTOS_DET_CASOSCollection.CASO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PRESUPUESTOS_DET_CASOSCollection.IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return PRESUPUESTOS_DET_CASOSCollection.OBSERVACIONColumnName; }
        }
        public static string PresupuestoDetalleId_NombreCol
        {
            get { return PRESUPUESTOS_DET_CASOSCollection.PRESUPUESTOS_DETALLE_IDColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return PRESUPUESTOS_DET_CAS_INF_COMPCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCasoFlujoDesc_NombreCol
        {
            get { return PRESUPUESTOS_DET_CAS_INF_COMPCollection.CASO_FLUJO_DESCColumnName; }
        }
        public static string VistaCasoFlujoId_NombreCol
        {
            get { return PRESUPUESTOS_DET_CAS_INF_COMPCollection.CASO_FLUJO_IDColumnName; }
        }
        public static string VistaPresupuestoDetalleObservacion_NombreCol
        {
            get { return PRESUPUESTOS_DET_CAS_INF_COMPCollection.PRESUPUESTO_DETALLE_OBSColumnName; }
        }
        public static string VistaPresupuestoEtapaNombre_NombreCol
        {
            get { return PRESUPUESTOS_DET_CAS_INF_COMPCollection.PRESUPUESTO_ETAPA_NOMBREColumnName; }
        }
        public static string VistaPresupuestoId_NombreCol
        {
            get { return PRESUPUESTOS_DET_CAS_INF_COMPCollection.PRESUPUESTO_IDColumnName; }
        }
        public static string VistaPresupuestoObjeto_NombreCol
        {
            get { return PRESUPUESTOS_DET_CAS_INF_COMPCollection.PRESUPUESTO_OBJETOColumnName; }
        }
        #endregion Accessors
    }
}
