using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Collections;


namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class DescuentosLlegadasTardiasPorPuntosService : DescuentosLlegadasTardiasService
    {
        #region Propiedades
        private const decimal DESTIEMPO = 3;
        #endregion Propiedades

        #region Calcular Descuento
        public override decimal CalcularDescuentosPorFuncionarios(Hashtable camposDescuento)
        {
            decimal llegadasTardias = 0;
            decimal montoDescuento = 0;
            decimal salarioBruto = FuncionariosService.GetSalarioBase((decimal)camposDescuento[MarcacionesService.FuncionarioID_NombreCol]);
            List<Hashtable> listaCampos = new List<Hashtable>();

            #region Obtener llegadas tardías
            string where = "(trunc(" + MarcacionesService.FechaMarcacion_NombreCol + ")" + " >= to_date('" + camposDescuento[Definiciones.TipoFechaFiltro.StringFechaDesde] + "','DD/MM/YYYY')) " + " and " +
                           "(trunc(" + MarcacionesService.FechaMarcacion_NombreCol + ")" + " <= to_date('" + camposDescuento[Definiciones.TipoFechaFiltro.StringFechaHasta] + "','DD/MM/YYYY'))" + " and " +
                           MarcacionesService.FuncionarioID_NombreCol + " = " + (decimal)camposDescuento[MarcacionesService.FuncionarioID_NombreCol] + " and " +
                           MarcacionesService.Calificacion_NombreCol + " = " + DESTIEMPO + " and " +
                           MarcacionesService.TipoMovimiento_NombreCol + " = '" + Definiciones.TipoMovimientoMarcaciones.Entrada + "' and " +
                           MarcacionesService.Justificado_NombreCol + " = '" + Definiciones.SiNo.No + "' and " +
                           MarcacionesService.Descuento_llegada_tardia_Id + " is null ";

            DataTable dtMarcaciones = MarcacionesService.GetMarcacionesInfoCompleta(where, MarcacionesService.FechaMarcacion_NombreCol);
            #endregion Obtener llegadas tardías

            #region Analizar llevadas tardías y generar descuentos
            if (dtMarcaciones.Rows.Count > 0)
            {
                for (int i = 0; i < dtMarcaciones.Rows.Count; i++)
                {
                    DateTime turnoEntrada = new DateTime();
                    DateTime marcacion = (DateTime)dtMarcaciones.Rows[i][MarcacionesService.FechaMarcacion_NombreCol];

                    if (camposDescuento[DescuentosLlegadasTardiasService.Aplicar_Tolerancia_NombreCol].ToString() == Definiciones.SiNo.Si)
                    {
                        turnoEntrada = ((DateTime)dtMarcaciones.Rows[i][MarcacionesService.TurnoEntradaDespues_NombreCol]);

                        #region Tolerancia Calendario
                        where = CalendariosService.Fecha_NombreCol + " ='" + ((DateTime)dtMarcaciones.Rows[i][MarcacionesService.FechaMarcacion_NombreCol]).ToShortDateString() + "'";
                        DataTable dtCalendario = CalendariosService.GetCalendariosDataTable(where, string.Empty, true);

                        for (int j = 0; j < dtCalendario.Rows.Count; j++)
                        {
                            double minutosAdicionales = ((DateTime)dtCalendario.Rows[j][CalendariosService.Tolerancia_Minutos_Extras_NombreCol]).Hour * 60 +
                                                        ((DateTime)dtCalendario.Rows[j][CalendariosService.Tolerancia_Minutos_Extras_NombreCol]).Minute;
                            turnoEntrada = turnoEntrada.AddMinutes(minutosAdicionales);
                        }
                        #endregion Tolerancia Calendario
                    }
                    else
                    {
                        turnoEntrada = (DateTime)dtMarcaciones.Rows[i][MarcacionesService.TurnoEntrada_NombreCol];
                    }

                    if (turnoEntrada.Hour <= marcacion.Hour && turnoEntrada.Minute < marcacion.Minute)
                    {
                        llegadasTardias++;

                        #region Actualizar Marcación
                        Hashtable camposMarcaciones = new Hashtable();
                        camposMarcaciones.Add(MarcacionesService.ID_NombreCol, (decimal)dtMarcaciones.Rows[i][MarcacionesService.ID_NombreCol]);
                        camposMarcaciones.Add(MarcacionesService.FechaMarcacion_NombreCol, (DateTime)dtMarcaciones.Rows[i][MarcacionesService.FechaMarcacion_NombreCol]);
                        camposMarcaciones.Add(MarcacionesService.TipoMovimiento_NombreCol, (string)dtMarcaciones.Rows[i][MarcacionesService.TipoMovimiento_NombreCol]);
                        camposMarcaciones.Add(MarcacionesService.Descuento_llegada_tardia_Id, (decimal)camposDescuento[DescuentosLlegadasTardiasService.Id_NombreCol]);

                        if (dtMarcaciones.Rows[i][MarcacionesService.EsCopiado_NombreCol] != DBNull.Value)
                            camposMarcaciones.Add(MarcacionesService.EsCopiado_NombreCol, (string)dtMarcaciones.Rows[i][MarcacionesService.EsCopiado_NombreCol]);
                        if (dtMarcaciones.Rows[i][MarcacionesService.Descontar_NombreCol] != DBNull.Value)
                            camposMarcaciones.Add(MarcacionesService.Descontar_NombreCol, (string)dtMarcaciones.Rows[i][MarcacionesService.Descontar_NombreCol]);

                        listaCampos.Add(camposMarcaciones);
                        #endregion Actualizar Marcación
                    }
                }

                if (llegadasTardias > 0)
                {
                    decimal puntoFinal = llegadasTardias + 1;
                    where = DescuentosLlegadasTardiasDetallesService.Punto_Inicio_NombreCol + " >= " + llegadasTardias + " and " +
                            DescuentosLlegadasTardiasDetallesService.Punto_Fin_NombreCol + " <= " + puntoFinal + " and " +
                            DescuentosLlegadasTardiasDetallesService.DescuentoLlegadaTardiaId_NombreCol + "=" + (decimal)camposDescuento[DescuentosLlegadasTardiasService.Id_NombreCol] + " and " +
                            DescuentosLlegadasTardiasDetallesService.Estado_NombreCol + " ='" + Definiciones.Estado.Activo + "'";

                    DataTable dtPoliticaDetalle = DescuentosLlegadasTardiasDetallesService.GetDataTable(where);

                    if (dtPoliticaDetalle.Rows.Count > 0)
                    {
                        if (camposDescuento[DescuentosLlegadasTardiasService.Aplicar_Desc_Monto_Fijo_NombreCol].ToString() == Definiciones.SiNo.Si)
                        {
                            montoDescuento = (decimal)dtPoliticaDetalle.Rows[0][DescuentosLlegadasTardiasDetallesService.Monto_Descuento_NombreCol];
                        }
                        else
                        {
                            decimal diasTrabajados = CBA.FlowV2.Services.Base.VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.DiasLaboralesMes);
                            decimal horasTrabajadas = CBA.FlowV2.Services.Base.VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.HorasLaboralesDia);
                            DateTime horasPenalizadas = (DateTime)dtPoliticaDetalle.Rows[0][DescuentosLlegadasTardiasDetallesService.Horas_Penalizadas_NombreCol];

                            montoDescuento = ((salarioBruto / diasTrabajados) / horasTrabajadas) * horasPenalizadas.Hour;
                        }
                    }
                }
                //Solo si existe algún monto para descontar guardar el id de la política en la tabla marcaciones
                if (montoDescuento > 0)
                {
                    foreach (Hashtable campos in listaCampos)
                        MarcacionesService.Guardar(campos, false, false);
                }
            }
            #endregion

            return montoDescuento;
        }
        #endregion Calcular Descuento
    }
}
