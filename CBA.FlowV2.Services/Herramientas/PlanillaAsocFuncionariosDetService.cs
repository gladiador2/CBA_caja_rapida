using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PlanillaAsocFuncionariosDetService
    {
        #region GetPlanillaAsocFuncionariosDetDataTable
        public static DataTable GetPlanillaAsocFuncionariosDetDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.PLANILLA_ASOC_FUNCIONARIOS_DETCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetPlanillaAsocFuncionariosDetDataTable

        #region GetPlanillaAsocFuncionariosDetInfoCompletaDataTable
        public static DataTable GetPlanillaAsocFuncionariosDetInfoCompletaDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.PLANILLA_ASOC_FUNC_DET_INFO_CCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetPlanillaAsocFuncionariosInfoCompletaDetDataTable

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PLANILLA_ASOC_FUNCIONARIOS_DETRow planillaAsocFuncionariosDet = new PLANILLA_ASOC_FUNCIONARIOS_DETRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        planillaAsocFuncionariosDet.ID = sesion.Db.GetSiguienteSecuencia("planilla_asoc_func_det_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        planillaAsocFuncionariosDet = sesion.Db.PLANILLA_ASOC_FUNCIONARIOS_DETCollection.GetRow(Id_NombreCol + " = " + decimal.Parse((string)campos[Id_NombreCol]));
                        valorAnterior = planillaAsocFuncionariosDet.ToString();
                    }

                    if (campos.Contains(PlanillaAsocFuncionariosDetService.Id_NombreCol))
                        planillaAsocFuncionariosDet.ID = (decimal)campos[PlanillaAsocFuncionariosDetService.Id_NombreCol];

                    if (campos.Contains(PlanillaAsocFuncionariosDetService.PlanillaAsocFuncionariosId_NombreCol))
                        planillaAsocFuncionariosDet.PLANILLA_ASOC_FUNCIONARIOS_ID = (decimal)campos[PlanillaAsocFuncionariosDetService.PlanillaAsocFuncionariosId_NombreCol];

                    if (campos.Contains(PlanillaAsocFuncionariosDetService.PersonaId_NombreCol))
                        planillaAsocFuncionariosDet.PERSONA_ID = (decimal)campos[PlanillaAsocFuncionariosDetService.PersonaId_NombreCol];

                    if (campos.Contains(PlanillaAsocFuncionariosDetService.Monto_NombreCol))
                        planillaAsocFuncionariosDet.MONTO = (decimal)campos[PlanillaAsocFuncionariosDetService.Monto_NombreCol];

                    if (campos.Contains(PlanillaAsocFuncionariosDetService.Observacion_NombreCol))
                        planillaAsocFuncionariosDet.OBSERVACION = (string)campos[PlanillaAsocFuncionariosDetService.Observacion_NombreCol];

                    if (campos.Contains(PlanillaAsocFuncionariosDetService.CasoAsociadoId_NombreCol))
                        planillaAsocFuncionariosDet.CASO_ASOCIADO_ID = (decimal)campos[PlanillaAsocFuncionariosDetService.CasoAsociadoId_NombreCol];

                    if (insertarNuevo) sesion.Db.PLANILLA_ASOC_FUNCIONARIOS_DETCollection.Insert(planillaAsocFuncionariosDet);
                    else sesion.Db.PLANILLA_ASOC_FUNCIONARIOS_DETCollection.Update(planillaAsocFuncionariosDet);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, planillaAsocFuncionariosDet.ID, valorAnterior, planillaAsocFuncionariosDet.ToString(), sesion);

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
        public static void Borrar(decimal factura_cliente_detalle_id, SessionService sesion)
        {
            PLANILLA_ASOC_FUNCIONARIOS_DETRow row = sesion.Db.PLANILLA_ASOC_FUNCIONARIOS_DETCollection.GetByPrimaryKey(factura_cliente_detalle_id);
            sesion.Db.PLANILLA_ASOC_FUNCIONARIOS_DETCollection.Delete(row);
        }

        public static void Borrar(decimal detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Borrar(detalle_id, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        #endregion Borrar

        #region ActualizarCasoAsociado
        public static void ActualizarCasoAsociado(decimal planlila_aso_funcionarios_det_id, decimal caso_id, SessionService sesion)
        {
            PLANILLA_ASOC_FUNCIONARIOS_DETRow row = sesion.db.PLANILLA_ASOC_FUNCIONARIOS_DETCollection.GetByPrimaryKey(planlila_aso_funcionarios_det_id);
            row.CASO_ASOCIADO_ID = caso_id;
            sesion.db.PLANILLA_ASOC_FUNCIONARIOS_DETCollection.Update(row);
        }
        #endregion ActualizarCasoAsociado

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PLANILLA_ASOC_FUNCIONARIOS_DET"; }
        }

        public static string Id_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOS_DETCollection.IDColumnName; }
        }

        public static string CasoAsociadoId_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOS_DETCollection.CASO_ASOCIADO_IDColumnName; }
        }

        public static string PlanillaAsocFuncionariosId_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOS_DETCollection.PLANILLA_ASOC_FUNCIONARIOS_IDColumnName; }
        }

        public static string PersonaId_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOS_DETCollection.PERSONA_IDColumnName; }
        }

        public static string Monto_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOS_DETCollection.MONTOColumnName; }
        }

        public static string Observacion_NombreCol
        {
            get { return PLANILLA_ASOC_FUNCIONARIOS_DETCollection.OBSERVACIONColumnName; }
        }

        public static string PersonaNombreCompleto_NombreCol
        {
            get { return PLANILLA_ASOC_FUNC_DET_INFO_CCollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }

        #endregion Accessors
    }
}
