using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class FuncionarioDiasTrabajadosService
    {
        #region GetDiasTrabajados


        /// <summary>
        /// Gets the dias trabajados.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <param name="fecha_inicio">The fecha_inicio.</param>
        /// <param name="fecha_fin">The fecha_fin.</param>
        /// <returns></returns>
        public static decimal GetDiasTrabajados(decimal funcionario_id,DateTime fecha_inicio, DateTime fecha_fin)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = "TO_DATE(" + FechaInicio_NombreCol + ",'DD/MM/YY')" + ">=" + "TO_DATE('" + fecha_inicio.ToShortDateString() + "','DD/MM/YY')" +
                                    " and " + "TO_DATE(" + FechaFin_NombreCol + ",'DD/MM/YY')" + "<=" + "TO_DATE('" + fecha_fin.ToShortDateString() + "','DD/MM/YY')" + 
                                    " and " + FuncionarioId_NombreCol + " = " + funcionario_id;
                FUNCIONARIOS_DIAS_TRABAJADOSRow[] funcionario = sesion.Db.FUNCIONARIOS_DIAS_TRABAJADOSCollection.GetAsArray(clausula,FechaInicio_NombreCol);
                if (funcionario != null)
                {
                    decimal total=0;
                    for (int i = 0; i < funcionario.Length; i++)
                    {
                        total+= funcionario[i].DIAS_TRABAJADOS;
                    }
                    return total;
                }
                else {
                    return 0;
                }

            }
        }
        #endregion GetDiasTrabajados



        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "FUNCIONARIOS_DIAS_TRABAJADOS"; }
        }
        public static string Id_NombreCol
        { get { return FUNCIONARIOS_DIAS_TRABAJADOSCollection.IDColumnName; } }

        public static string FuncionarioId_NombreCol
        { get { return FUNCIONARIOS_DIAS_TRABAJADOSCollection.FUNCIONARIO_IDColumnName; } }

        public static string FechaInicio_NombreCol
        { get { return FUNCIONARIOS_DIAS_TRABAJADOSCollection.FECHA_INICIOColumnName; } }

        public static string FechaFin_NombreCol
        { get { return FUNCIONARIOS_DIAS_TRABAJADOSCollection.FECHA_FINColumnName; } }

        public static string DiasTrabajados_NombreCol
        { get { return FUNCIONARIOS_DIAS_TRABAJADOSCollection.DIAS_TRABAJADOSColumnName; } }
        #endregion Accessors
    }
}
