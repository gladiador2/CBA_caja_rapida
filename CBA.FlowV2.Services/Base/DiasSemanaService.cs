using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Base
{
    public class DiasSemanaService
    {
        #region GetDiasSemanaDataTable
        /// <summary>
        /// Gets the dias semana data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDiasSemanaDataTable() 
        {
            return GetDiasSemanaDataTable(string.Empty);
        }

        /// <summary>
        /// Gets the dias semana data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <returns></returns>
        public DataTable GetDiasSemanaDataTable(string clausulas)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return sesion.Db.DIAS_SEMANACollection.GetAsDataTable(clausulas, Id_NombreCol);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        public static DataTable GetDiasSemanaDataTableStatic(string clausulas)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return sesion.Db.DIAS_SEMANACollection.GetAsDataTable(clausulas, Id_NombreCol);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetDiasSemanaDataTable

        #region GetIdDiaSemanaByName
        public string GetIdDiaSemanaByName(string dia)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    string clausulas= Nombre_NombreCol + " = '"+ dia + "'";
                    DataTable dt = new DataTable();
                    dt = GetDiasSemanaDataTable(clausulas); ;
                    return dt.Rows[0][Id_NombreCol].ToString();
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        public static string GetIdDiaSemanaByNameStatic(string dia)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    string clausulas = Nombre_NombreCol + " = '" + dia + "'";
                    DataTable dt = new DataTable();
                    dt = GetDiasSemanaDataTableStatic(clausulas); ;
                    return dt.Rows[0][Id_NombreCol].ToString();
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetIdDiaSemanaByName

        #region GetDiasLaborables
        /// <summary>
        /// Gets the dias laborables.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDiasLaborables() 
        {
            string where = Laborable_NombreCol + " = '" + Definiciones.SiNo.Si + "' ";
            return GetDiasSemanaDataTable(where);
        }
        #endregion GetDiasLaborables

        #region GetDiasNoLaborables
        /// <summary>
        /// Gets the dias no laborables.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDiasNoLaborables()
        {
            string where = Laborable_NombreCol + " = '" + Definiciones.SiNo.No + "' ";
            return GetDiasSemanaDataTable(where);
        }

        public static DataTable GetDiasNoLaborablesStatic()
        {
            string where = Laborable_NombreCol + " = '" + Definiciones.SiNo.No + "' ";
            return GetDiasSemanaDataTableStatic(where);
        }
        #endregion GetDiasNoLaborables

        #region GetTodosLosDias
        /// <summary>
        /// Gets the todos los dias.
        /// </summary>
        /// <returns></returns>
        public DataTable GetTodosLosDias()
        {
            string where = string.Empty;
            return GetDiasSemanaDataTable(where);
        }
        #endregion GetTodosLosDias

        #region GetIdDiaEnDayOfWeek
        public string GetIdDiaEnDayOfWeek(int id_DayOfWeek)
        {
            //Recibe el valor devuelto por la funcion DayOfWeek y busca el Id del mismo dia en la tabla DIAS_SEMANA
            string idEnTabla= string.Empty;

            if (id_DayOfWeek.Equals(0)) //domingo
                idEnTabla= GetIdDiaSemanaByName(Definiciones.DiasSemana.Domingo_Nombre);
            else if (id_DayOfWeek.Equals(1)) //lunes
                idEnTabla= GetIdDiaSemanaByName(Definiciones.DiasSemana.Lunes_Nombre);
            else if (id_DayOfWeek.Equals(2)) //martes
                idEnTabla= GetIdDiaSemanaByName(Definiciones.DiasSemana.Martes_Nombre);
            else if (id_DayOfWeek.Equals(3)) //miercoles
                idEnTabla= GetIdDiaSemanaByName(Definiciones.DiasSemana.Miercoles_Nombre);
            else if (id_DayOfWeek.Equals(4)) //jueves
                idEnTabla= GetIdDiaSemanaByName(Definiciones.DiasSemana.Jueves_Nombre);
            else if (id_DayOfWeek.Equals(5)) //viernes
                idEnTabla= GetIdDiaSemanaByName(Definiciones.DiasSemana.Viernes_Nombre);
            else if (id_DayOfWeek.Equals(6)) //sabado
                idEnTabla= GetIdDiaSemanaByName(Definiciones.DiasSemana.Sabado_Nombre);

            return idEnTabla;
        }

        public static string GetIdDiaEnDayOfWeekStatic(int id_DayOfWeek)
        {
            //Recibe el valor devuelto por la funcion DayOfWeek y busca el Id del mismo dia en la tabla DIAS_SEMANA
            string idEnTabla = string.Empty;

            if (id_DayOfWeek.Equals(0)) //domingo
                idEnTabla = GetIdDiaSemanaByNameStatic(Definiciones.DiasSemana.Domingo_Nombre);
            else if (id_DayOfWeek.Equals(1)) //lunes
                idEnTabla = GetIdDiaSemanaByNameStatic(Definiciones.DiasSemana.Lunes_Nombre);
            else if (id_DayOfWeek.Equals(2)) //martes
                idEnTabla = GetIdDiaSemanaByNameStatic(Definiciones.DiasSemana.Martes_Nombre);
            else if (id_DayOfWeek.Equals(3)) //miercoles
                idEnTabla = GetIdDiaSemanaByNameStatic(Definiciones.DiasSemana.Miercoles_Nombre);
            else if (id_DayOfWeek.Equals(4)) //jueves
                idEnTabla = GetIdDiaSemanaByNameStatic(Definiciones.DiasSemana.Jueves_Nombre);
            else if (id_DayOfWeek.Equals(5)) //viernes
                idEnTabla = GetIdDiaSemanaByNameStatic(Definiciones.DiasSemana.Viernes_Nombre);
            else if (id_DayOfWeek.Equals(6)) //sabado
                idEnTabla = GetIdDiaSemanaByNameStatic(Definiciones.DiasSemana.Sabado_Nombre);

            return idEnTabla;
        }
        #endregion GetIdDiaEnDayOfWeek

        #region EsFechaLaborable
        public static bool EsFechaLaborable(DateTime fecha)
        {
            string idDia = GetIdDiaEnDayOfWeekStatic((int)fecha.DayOfWeek);
            DataTable dt = GetDiasSemanaDataTableStatic(DiasSemanaService.Id_NombreCol + " = " + idDia + "and " + DiasSemanaService.Laborable_NombreCol + " like '" + Definiciones.SiNo.Si + "'" );

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        #endregion EsFechaLaborable

        #region GetSiguienteFechaLaborable
        public static DateTime GetSiguienteFechaLaborable(DateTime fecha)
        {
            bool laborable = false;
            int dias = 0;

            //controlar para 30 días para no entrar en un loop infinito
            while (laborable == false && dias < 30)
            {
                if (!CalendariosService.EsFeriado(fecha))
                {
                    if (!EsFechaLaborable(fecha))
                    {
                        fecha = fecha.AddDays(1);
                    }
                    else
                    {
                        laborable = true;
                    }
                }
                else
                {
                    fecha = fecha.AddDays(1);
                }

                dias++;
            }

            if (laborable = false && dias == 30)
                throw new Exception("No existen días laborables");
           
            return fecha;
        }
        #endregion GetSiguienteFechaLaborable

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "DIAS_SEMANA"; }
        }
        public static string Abreviatura_NombreCol
        {
            get { return DIAS_SEMANACollection.ABREVIATURAColumnName; }
        }
        public static string FinJornada_NombreCol
        {
            get { return DIAS_SEMANACollection.FIN_JORNADAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DIAS_SEMANACollection.IDColumnName; }
        }
        public static string InicioJornada_NombreCol
        {
            get { return DIAS_SEMANACollection.INICIO_JORNADAColumnName; }
        }
        public static string Laborable_NombreCol
        {
            get { return DIAS_SEMANACollection.LABORABLEColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return DIAS_SEMANACollection.NOMBREColumnName; }
        }
        #endregion Accessors

    }
}
