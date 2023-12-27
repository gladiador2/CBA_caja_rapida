using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Common;
using System.Text;

namespace CBA.FlowV2.Services.Herramientas
{
    public class RequisitosFlujoDetalleService
    {
        #region GetDataTable
        public static DataTable GetDataTable(string clausulas, string orden)
        {
            using(SessionService sesion = new SessionService())
            {
                return GetDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.db.REQUISITOS_FLUJO_DETALLECollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetDataTable
        
        #region GetRequisitoCumplido
        /// <summary>
        /// Gets the requisito cumplido.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="requisito_flujo_id">The requisito_flujo_id.</param>
        /// <returns></returns>
        public static bool GetRequisitoCumplidoStatic(decimal caso_id, decimal requisito_flujo_id) 
        {
            using (SessionService sesion = new SessionService())
            {
                REQUISITOS_FLUJO_DETALLERow[] rows;
                string where = "" +
                    RequisitoFlujoId_NombreCol + " = " + requisito_flujo_id + " and " +
                    CasoId_NombreCol + " = " + caso_id + " and " +
                    Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                rows = sesion.Db.REQUISITOS_FLUJO_DETALLECollection.GetAsArray(where, "");

                //Si existe un registro, debe ser el unico activo
                if (rows.Length > 1) 
                    throw new Exception("Error en RequisitosFlujosDetalle.GetRequisitoCumplido. Hay más de un registro activo para el id " + Id_NombreCol);

                return rows.Length == 1;
            }
        }
        public bool GetRequisitoCumplido(decimal caso_id, decimal requisito_flujo_id)
        {
            return GetRequisitoCumplidoStatic(caso_id, requisito_flujo_id);
        }
        #endregion GetRequisitoCumplido

        #region GetRequisitosFlujoDetalleDataTable
        /// <summary>
        /// Gets the requisitos flujo detalle data table (solo registros activos).
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetRequisitosFlujoDetalleDataTable(decimal caso_id, SessionService sesion)
        {
            return GetRequisitosFlujoDetalleDataTable(caso_id, true, sesion);
        }
        public DataTable GetRequisitosFlujoDetalleDataTable(decimal caso_id, bool soloActivos, SessionService sesion)
        {
            string where = CasoId_NombreCol + " = " + caso_id;

            if (soloActivos)
                where += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            
            return sesion.Db.REQUISITOS_FLUJO_DETALLECollection.GetAsDataTable(where, "");
        }
        #endregion GetRequisitoCumplido

        #region Check
        /// <summary>
        /// Checks the specified requisitos_flujo_id.
        /// </summary>
        /// <param name="requisitos_flujo_id">The requisitos_flujo_id.</param>
        /// <param name="caso_id">The caso_id.</param>
        public static void Check(decimal requisitos_flujo_id, decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    REQUISITOS_FLUJO_DETALLERow row = new REQUISITOS_FLUJO_DETALLERow();
                    string valorAnterior = Definiciones.Log.RegistroNuevo;
                    DataTable dtRequisito = RequisitosFlujoService.GetRequisitosFlujoDataTable(RequisitosFlujoService.Id_NombreCol + " = " + requisitos_flujo_id);

                    if(!Interprete.EsNullODBNull(dtRequisito.Rows[0][RequisitosFlujoService.RolEditar_NombreCol]))
                    {
                        if(!RolesService.Tiene((decimal)dtRequisito.Rows[0][RequisitosFlujoService.RolEditar_NombreCol]))
                            throw new Exception("No tiene permisos suficientes para realizar la acción.");
                    }

                    row.ID = sesion.Db.GetSiguienteSecuencia("requisitos_flujo_detalle_sqc");
                    row.CASO_ID = caso_id;
                    row.ESTADO = Definiciones.Estado.Activo;
                    row.FECHA_CARGA = DateTime.Now;
                    row.REQUISITO_FLUJO_ID = requisitos_flujo_id;
                    row.USUARIO_CARGA_ID = sesion.Usuario_Id;

                    sesion.Db.REQUISITOS_FLUJO_DETALLECollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion Check

        #region Uncheck
        /// <summary>
        /// Unchecks the specified requisitos_flujo_detalle_id.
        /// </summary>
        /// <param name="requisitos_flujo_id">The requisitos_flujo_id.</param>
        /// <param name="caso_id">The caso_id.</param>
        public static void Uncheck(decimal requisitos_flujo_id, decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    DataTable dtRequisito = RequisitosFlujoService.GetRequisitosFlujoDataTable(RequisitosFlujoService.Id_NombreCol + " = " + requisitos_flujo_id);
                    string valorAnterior;
                    string where = RequisitoFlujoId_NombreCol + " = " + requisitos_flujo_id +
                            " and " + CasoId_NombreCol + " = " + caso_id +
                            " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                    if(!Interprete.EsNullODBNull(dtRequisito.Rows[0][RequisitosFlujoService.RolEditar_NombreCol]))
                    {
                        if (!RolesService.Tiene((decimal)dtRequisito.Rows[0][RequisitosFlujoService.RolEditar_NombreCol]))
                            throw new Exception("No tiene permisos suficientes para realizar la acción.");
                    }

                    REQUISITOS_FLUJO_DETALLERow[] rows = sesion.Db.REQUISITOS_FLUJO_DETALLECollection.GetAsArray(where, "");

                    //Deberia haber un solo registro activo, no obstante
                    //si por algun error hay mas de uno, el foreach
                    //soluciona la inconsistencia
                    foreach (REQUISITOS_FLUJO_DETALLERow row in rows)
                    {
                        valorAnterior = row.ToString();

                        row.ESTADO = Definiciones.Estado.Inactivo;
                        row.FECHA_BORRADO = DateTime.Now;
                        row.USUARIO_BORRADO_ID = sesion.Usuario_Id;

                        sesion.Db.REQUISITOS_FLUJO_DETALLECollection.Update(row);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion Uncheck

        #region Metodos estaticos
        public static string Nombre_Tabla
        {
            get { return "REQUISITOS_FLUJO_DETALLE"; }
        }
        public static string Id_NombreCol
        {
            get { return REQUISITOS_FLUJO_DETALLECollection.IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return REQUISITOS_FLUJO_DETALLECollection.CASO_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return REQUISITOS_FLUJO_DETALLECollection.ESTADOColumnName; }
        }
        public static string FechaBorrado_NombreCol
        {
            get { return REQUISITOS_FLUJO_DETALLECollection.FECHA_BORRADOColumnName; }
        }
        public static string FechaCarga_NombreCol
        {
            get { return REQUISITOS_FLUJO_DETALLECollection.FECHA_CARGAColumnName; }
        }
        public static string RequisitoFlujoId_NombreCol
        {
            get { return REQUISITOS_FLUJO_DETALLECollection.REQUISITO_FLUJO_IDColumnName; }
        }
        public static string UsuarioBorradoId_NombreCol
        {
            get { return REQUISITOS_FLUJO_DETALLECollection.USUARIO_BORRADO_IDColumnName; }
        }
        public static string UsuarioCargaId_NombreCol
        {
            get { return REQUISITOS_FLUJO_DETALLECollection.USUARIO_CARGA_IDColumnName; }
        }
        #endregion Metodos estaticos
    }
}
