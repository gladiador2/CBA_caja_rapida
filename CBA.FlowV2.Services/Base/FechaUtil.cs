using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;



namespace CBA.FlowV2.Services.Base
{
    public static class FechaUtil
    {
        #region diasHabilesEntre
        /// <summary>
        /// Calcula la cantidad de días habiles teniendo en cuenta:
        ///  - fines de semana (sabados y domingos)
        ///  - feriados y asuetos segun base de datos
        /// </summary>
        /// <param name="fechaInicio">comienzo del intervalo</param>
        /// <param name="fechaFin">fin del intervalo</param>
        /// <returns>cantidad de días habiles en el intervalo</returns>
        public static int diasHabilesEntre(this DateTime fechaInicio, DateTime fechaFin)
        {
            fechaInicio = fechaInicio.Date;
            fechaFin = fechaFin.Date;
            if (fechaInicio > fechaFin)
                throw new ArgumentException("La fecha de inicio debe ser menor o igual a la fecha de fin");

            TimeSpan span = fechaFin - fechaInicio;
            int diasHabiles = span.Days + 1;
            //se calcula la cantidad de semanas completas en el intervalo (cada semana completa contiene 2 días de fin de semana)
            int semanasEnteras = diasHabiles / 7;
            
            //si la division no es exacta, se debe a que puede existir algun fin de semana completo o incompleto en los días restantes
            if (diasHabiles > semanasEnteras * 7) 
            {
                // se descuenta el fin de semana posiblemente contenido en los días "fuera" de las semanas completas
                int diaDeLaSemanaInicial = (int)fechaInicio.DayOfWeek;
                int diaDeLaSemanaFinal = (int)fechaFin.DayOfWeek;
                if (diaDeLaSemanaFinal < diaDeLaSemanaInicial)
                    diaDeLaSemanaFinal += 7;
                if (diaDeLaSemanaInicial <= 6) 
                {
                    if (diaDeLaSemanaFinal >= 7)// sabado y domingo estan en el intervalo
                    {
                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FuncionariosVacacionesSabadoLaboral) == Definiciones.SiNo.No)
                            diasHabiles -= 2;
                        else
                            diasHabiles -= 1;
                    }
                    else if (diaDeLaSemanaFinal >= 6)// solo sabado esta en el intervalo
                    {
                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FuncionariosVacacionesSabadoLaboral) == Definiciones.SiNo.No)
                            diasHabiles -= 1;
                    }
                } else if (diaDeLaSemanaInicial <= 7 && diaDeLaSemanaFinal >= 7)// solo domningo esta en el intervalo
                    diasHabiles -= 1;
            }

            // se descuentan los fines de semana enteros
            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FuncionariosVacacionesSabadoLaboral) == Definiciones.SiNo.No)
                diasHabiles -= semanasEnteras * 2;
            else
                diasHabiles -= semanasEnteras;

            decimal sucursalActual = Definiciones.Error.Valor.EnteroPositivo;

            // se descuentan los días feriados contenidos dentro del intervalo
            using (SessionService sesion = new SessionService())
            {
                sucursalActual = sesion.SucursalActiva_Id;
            }

            DataTable fechasNoLaborales = CalendariosService.GetCalendariosInfoCompleta(fechaInicio.ToString("dd/MM/yyyy"), fechaFin.ToString("dd/MM/yyyy"), sucursalActual, true);

            foreach (DataRow fecha in fechasNoLaborales.Rows) {
                DateTime fechaARestar = DateTime.Parse(fecha[CalendariosService.Fecha_NombreCol].ToString());
                // control: si la fecha en cuestión es un dia no laboral y no coincide con un sabado o domingo, se resta
                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FuncionariosVacacionesSabadoLaboral) == Definiciones.SiNo.No)
                {
                    if (fechaARestar.DayOfWeek != DayOfWeek.Saturday && fechaARestar.DayOfWeek != DayOfWeek.Sunday &&
                        fechaInicio <= fechaARestar && fechaARestar <= fechaFin)
                        diasHabiles--;
                }
                else
                {
                    if (fechaARestar.DayOfWeek != DayOfWeek.Sunday &&
                        fechaInicio <= fechaARestar && fechaARestar <= fechaFin)
                        diasHabiles--;
                }
            }
            
            return diasHabiles;
        }
        #endregion diasHabilesEntre

        #region clase VencimientoDinamico
        public class VencimientoDinamico : ICloneable
        {
            #region clases internas
            public class Resolucion
            {
                public class TipoInicio
                {
                    public const int MismaFecha = 0;
                    public const int InicioMes = 1;
                    public const int FinMes = 2;
                    public const int PrimerLunesMes = 3;

                    public static string DataTable_Valor = "_VALOR_";
                    public static string DataTable_Texto = "_TEXTO_";
                    public static DataTable GetDataTable()
                    {
                        var dt = new DataTable();
                        dt.Columns.Add(DataTable_Valor, typeof(int));
                        dt.Columns.Add(DataTable_Texto, typeof(string));
                        dt.Rows.Add(MismaFecha, "Misma fecha");
                        dt.Rows.Add(InicioMes, "Inicio mes");
                        dt.Rows.Add(FinMes, "Fin mes");
                        dt.Rows.Add(PrimerLunesMes, "Primer lunes");
                        return dt;
                    }
                }

                public int tipoInicio { get; set; }
                public int moverDias { get; set; }
                public int moverMeses { get; set; }

                public Resolucion()
                {
                    this.tipoInicio = TipoInicio.MismaFecha;
                    this.moverDias = 0;
                    this.moverMeses = 1;
                }
            }

            public class Regla
            {
                public class Tipo
                {
                    public const int DiaEntre = 0;
                    public const int MontoEntre = 1;

                    public static string DataTable_Valor = "_VALOR_";
                    public static string DataTable_Texto = "_TEXTO_";
                    public static DataTable GetDataTable()
                    {
                        var dt = new DataTable();
                        dt.Columns.Add(DataTable_Valor, typeof(int));
                        dt.Columns.Add(DataTable_Texto, typeof(string));
                        dt.Rows.Add(DiaEntre, "Día entre");
                        dt.Rows.Add(MontoEntre, "Monto entre");
                        return dt;
                    }
                }

                public int tipo { get; set; }
                public int limiteInferior { get; set; }
                public int limiteSuperior { get; set; }
                public Resolucion resolucion;

                public Regla()
                {
                    this.tipo = Tipo.DiaEntre;
                    this.limiteInferior = 1;
                    this.limiteSuperior = 31;
                    this.resolucion = new Resolucion();
                }
            }
            #endregion clases internas

            public List<Regla> reglas;

            public VencimientoDinamico()
            {
                this.reglas = new List<Regla>();
            }

            public static DateTime GetPrimerVencimiento(Regla regla, DateTime fecha_base)
            {
                DateTime resultado = fecha_base.Date;

                switch (regla.resolucion.tipoInicio)
                { 
                    case Resolucion.TipoInicio.MismaFecha:
                        break;
                    case Resolucion.TipoInicio.InicioMes:
                        resultado = new DateTime(fecha_base.Year, fecha_base.Month, 1);
                        break;
                    case Resolucion.TipoInicio.FinMes:
                        resultado = new DateTime(fecha_base.Year, fecha_base.Month, 1).AddMonths(1).AddDays(-1); 
                        break;
                    case Resolucion.TipoInicio.PrimerLunesMes:
                        resultado = new DateTime(fecha_base.Year, fecha_base.Month, 1);
                        int dias = System.DayOfWeek.Monday - resultado.DayOfWeek;
                        if (dias < 0) dias += 7;
                        resultado = resultado.AddDays(dias);
                        break;
                }

                resultado = resultado.AddMonths(regla.resolucion.moverMeses);
                resultado = resultado.AddDays(regla.resolucion.moverDias);

                return resultado;
            }

            public object Clone()
            {
                var vd = new VencimientoDinamico();
                foreach (var r in this.reglas)
                {
                    var regla = new Regla() 
                    {
                        tipo = r.tipo,
                        limiteInferior = r.limiteInferior,
                        limiteSuperior = r.limiteSuperior
                    };

                    regla.resolucion.moverDias = r.resolucion.moverDias;
                    regla.resolucion.moverMeses = r.resolucion.moverMeses;
                    regla.resolucion.tipoInicio = r.resolucion.tipoInicio;

                    vd.reglas.Add(regla);
                }

                return vd;
            }
        }
        #endregion clase VencimientoDinamico
    }
}
