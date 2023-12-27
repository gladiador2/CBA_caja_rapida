using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Base;
using System.Data;
using CBA.FlowV2.Services.Herramientas;
using System.Collections;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public  class DescuentosLlegadasTardiasPorTiempoService : DescuentosLlegadasTardiasService
    {
        #region Propiedades
        private const decimal calificacion = 3;
        #endregion

        #region Getters
        private decimal GetMontoDescuentoPorTiempo(TimeSpan MinutosDeRetraso, decimal turno_id)
        {
            decimal montoDescontado = 0;
            string sql = HorariosTurnosService.Id_NombreCol + "=" + turno_id;
            DataTable dtHorario = HorariosTurnosService.GetHorariosTurnosDataTable(sql, string.Empty);

            string where = DescuentosLlegadasTardiasDetallesService.Tiempo_Inicio_NombreCol + ">=" + MinutosDeRetraso + " and " +
                           DescuentosLlegadasTardiasDetallesService.Tiempo_Fin_NombreCol + "<=" + MinutosDeRetraso;

            DataTable dtPolitica = DescuentosLlegadasTardiasDetallesService.GetDataTable(where);

            if (dtPolitica.Rows.Count > 0)
            {
                montoDescontado = (decimal)dtPolitica.Rows[0][DescuentosLlegadasTardiasDetallesService.Monto_Descuento_NombreCol];
            }

            return montoDescontado;
        }
        #endregion

        #region Calcular Descuentos
        public override decimal CalcularDescuentosPorFuncionarios(Hashtable camposDescuento)
        {
            decimal descuento = 0;
            decimal turno_id = 0;

            #region Datos marcacion
            string where = "(trunc(" + MarcacionesService.FechaMarcacion_NombreCol + ")" + " >= to_date('" + (DateTime)camposDescuento["fecha_desde"] + "','DD/MM/YYYY')) " + " and " +
                           "(trunc(" + MarcacionesService.FechaMarcacion_NombreCol + ")" + " <= to_date('" + (DateTime)camposDescuento["fecha_hasta"] + "','DD/MM/YYYY'))" + " and " +
                           MarcacionesService.FuncionarioID_NombreCol + " = " + (decimal)camposDescuento[MarcacionesService.FuncionarioID_NombreCol] + " and " +
                           //MarcacionesService.TurnoId_NombreCol + " = " + turno_id + " and " +
                           //MarcacionesService.Calificacion_NombreCol + " = " + calificacion + " and " +
                           MarcacionesService.Justificado_NombreCol + " =' " + Definiciones.SiNo.No + "'";

            DataTable dtMarcaciones = MarcacionesService.GetMarcacionesInfoCompleta(where, string.Empty);
            #endregion

            if (dtMarcaciones.Rows.Count > 0)//Implica que el funcionario no realizo llegadas tardias
            {
                for (int i = 0; i < dtMarcaciones.Rows.Count; i++)
                {
                    /*El datatable trae registro tanto de entrada como salida asi asi que se lleva el control de las entradas y hora de marcacion con respecto a la tolerancia*/
                    if ((string)dtMarcaciones.Rows[i][MarcacionesService.TipoMovimiento_NombreCol] == Definiciones.TipoMovimientoMarcaciones.Entrada)
                    {
                        TimeSpan MinutosDeRetraso = (DateTime)dtMarcaciones.Rows[i][MarcacionesService.FechaMarcacion_NombreCol] - (DateTime)dtMarcaciones.Rows[i][MarcacionesService.TurnoEntradaDespues_NombreCol];

                        /*Se accede a la tabla de politicas de descuentos para obtener el monto de descuento que debe aplicarse*/
                        descuento = GetMontoDescuentoPorTiempo(MinutosDeRetraso, turno_id);
                    }
                }
            }
            return Math.Round(descuento);
        }
        #endregion
    }
}
