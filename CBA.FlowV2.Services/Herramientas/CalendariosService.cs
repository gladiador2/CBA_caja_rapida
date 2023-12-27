using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class CalendariosService
    {
        private CALENDARIOSRow calendario;

        #region accessors
        public static string Nombre_Secuencia
        { get { return "CALENDARIOS_SQC"; } }

        public static string Nombre_Tabla
        { get { return "CALENDARIOS"; } }

        public static string ID_NombreCol
        { get { return CALENDARIOSCollection.IDColumnName; } }

        public static string EntidadID_NombreCol
        { get { return CALENDARIOSCollection.ENTIDAD_IDColumnName; } }

        public static string TipoEventoCalendarioID_NombreCol
        { get { return CALENDARIOSCollection.TIPO_EVENTO_CALENDARIO_IDColumnName; } }

        public static string Fecha_NombreCol
        { get { return CALENDARIOSCollection.FECHAColumnName; } }

        public static string SucursalId_NombreCol
        { get { return CALENDARIOSCollection.SUCURSAL_IDColumnName; } }

        public static string Titulo_NombreCol
        { get { return CALENDARIOSCollection.TITULOColumnName; } }

        public static string Observacion_NombreCol
        { get { return CALENDARIOSCollection.OBSERVACIONColumnName; } }

        public static string Estado_NombreCol
        { get { return CALENDARIOSCollection.ESTADOColumnName; } }

        public static string EsCiclico_NombreCol
        { get { return CALENDARIOSCollection.ES_CICLICOColumnName; } }

        public static string Tolerancia_Minutos_Extras_NombreCol
        { get { return CALENDARIOSCollection.TOLERANCIA_MINUTOS_EXTRASColumnName; } }

        public static string VistaLaborable_NombreCol
        { get { return CALENDARIOS_INFO_COMPLETACollection.LABORABLEColumnName; } }

        public static string VistaSucursalNombre_NombreCol
        { get { return CALENDARIOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; } }

        public static string VistaEsCiclico_NombreCol
        { get { return CALENDARIOS_INFO_COMPLETACollection.ES_CICLICOColumnName; } }
        #endregion

        #region EstaActivo
        public static bool EstaActivo(decimal calendario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CALENDARIOSRow calendario = sesion.Db.CALENDARIOSCollection.GetRow(" "+CalendariosService.ID_NombreCol + "=" + calendario_id);
                return calendario.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetCalendariosInfoCompleta
        /// <summary>
        /// Obtener de la vista calendarios_info_completa las fechas activas en el calendario.
        /// </summary>
        /// <param name="fechaDesde">The fecha desde (formato 'dd/mm/yyyy').</param>
        /// <param name="fechaHasta">The fecha hasta (formato 'dd/mm/yyyy').</param>
        /// <param name="soloNoLaborables">if set to <c>true</c> [solo no laborables].</param>
        /// <returns></returns>
        public static DataTable GetCalendariosInfoCompleta(string fechaDesde, string fechaHasta, decimal idsucursal, bool soloNoLaborables)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = EntidadID_NombreCol + " = " + sesion.Entidad.ID + " and " +
                                   Fecha_NombreCol + " between to_date('" + fechaDesde + "', 'dd/mm/yyyy') and to_date('" + fechaHasta + "', 'dd/mm/yyyy')  and " + SucursalId_NombreCol + " = " + idsucursal + " or " + SucursalId_NombreCol + " is " + "null";
                if (soloNoLaborables) clausulas += " and " + VistaLaborable_NombreCol + " = '" + Definiciones.SiNo.No + "'";


                return sesion.Db.CALENDARIOS_INFO_COMPLETACollection.GetAsDataTable(clausulas, Fecha_NombreCol);
            }
        }

        public DataTable GetCalendariosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {

                return sesion.Db.CALENDARIOS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCalendariosInfoCompleta

        #region GetDataTable
        /// <summary>
        /// Gets the calendarios data table.
        /// </summary>
        /// <param name="calendario_id">The calendario_id.</param>
        /// <returns></returns>
        public DataTable GetCalendariosDataTable(decimal calendario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.CALENDARIOSCollection.GetAsDataTable(" " + CalendariosService.ID_NombreCol + "=" + calendario_id, CalendariosService.Titulo_NombreCol);
                return table;
            }
        }

        /// <summary>
        /// Gets the calendarios data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetCalendariosDataTable(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string estado = " 1=1 ";
                if (soloActivos) estado = "  " + CalendariosService.Estado_NombreCol +  " = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.CALENDARIOSCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.CALENDARIOSCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }

        public DataTable GetCalendario(decimal calendario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.CALENDARIOSCollection.GetAsDataTable(" " + CalendariosService.ID_NombreCol + " = " + calendario_id, "");
                return tabla;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendariosService"/> class.
        /// </summary>
        /// <param name="calendario_id">The calendario_id.</param>
        public CalendariosService(decimal calendario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.calendario = sesion.Db.CALENDARIOSCollection.GetByPrimaryKey(calendario_id);
            }
        }

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CALENDARIOSRow calendario = new CALENDARIOSRow();
                    string valorAnterior = "";
                    
                    if (insertarNuevo)
                    {
                        calendario.ID = ObtenerSiguienteSecuencia();
                        calendario.ENTIDAD_ID = decimal.Parse(sesion.EntidadActual_Id);
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        calendario = sesion.Db.CALENDARIOSCollection.GetRow(" "+CalendariosService.ID_NombreCol+" = " + decimal.Parse((string)campos[CalendariosService.ID_NombreCol]));
                        valorAnterior = calendario.ToString();
                    }
                    
                    calendario.TITULO = (string)campos[CalendariosService.Titulo_NombreCol];
                    calendario.OBSERVACION = (string)campos[CalendariosService.Observacion_NombreCol];
                    calendario.TIPO_EVENTO_CALENDARIO_ID = campos[CalendariosService.TipoEventoCalendarioID_NombreCol].ToString();
                    calendario.FECHA = DateTime.Parse(campos[CalendariosService.Fecha_NombreCol].ToString()); 
                    calendario.ESTADO = (string)campos[CalendariosService.Estado_NombreCol];

                    if (campos.Contains(CalendariosService.EsCiclico_NombreCol))
                    {
                        calendario.ES_CICLICO = (string)campos[CalendariosService.EsCiclico_NombreCol];
                    }

                    if (campos[CalendariosService.SucursalId_NombreCol] != null)
                    {
                        calendario.SUCURSAL_ID = (decimal)campos[CalendariosService.SucursalId_NombreCol];
                    }
                    else
                    {
                        calendario.IsSUCURSAL_IDNull = true;
                    }

                    if(campos.Contains(CalendariosService.Tolerancia_Minutos_Extras_NombreCol))
                        calendario.TOLERANCIA_MINUTOS_EXTRAS = (DateTime)campos[CalendariosService.Tolerancia_Minutos_Extras_NombreCol];

                    if (insertarNuevo)
                        sesion.Db.CALENDARIOSCollection.Insert(calendario);
                    else 
                        sesion.Db.CALENDARIOSCollection.Update(calendario);

                    LogCambiosService.LogDeRegistro(CalendariosService.Nombre_Tabla, calendario.ID, valorAnterior, calendario.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion

        public decimal ObtenerSiguienteSecuencia()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable seq = new DataTable();
                return sesion.Db.GetSiguienteSecuencia(CalendariosService.Nombre_Secuencia);
            }
        }

        public string GetTitulo(decimal calendario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CALENDARIOSRow calendario = sesion.Db.CALENDARIOSCollection.GetRow(" " + CalendariosService.ID_NombreCol + " = " + calendario_id);
                return calendario.TITULO;
            }
        }

        public static bool EsFeriado(DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                //formateo a dia/mes
                string diaMes = fecha.ToString("dd/MM");

                //seleccionar por dia/mes y es_ciclico igual a true
                DataTable dtCiclico = sesion.Db.CALENDARIOSCollection.GetAsDataTable("TO_CHAR(" + Fecha_NombreCol + ",'DD/MM')" + " = " + " '" + diaMes + "' and " + CalendariosService.TipoEventoCalendarioID_NombreCol + " = '" + Definiciones.TiposEventoCalendario.Feriado + "' and " + CalendariosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" + " and " + CalendariosService.EsCiclico_NombreCol + " = '" + Definiciones.SiNo.Si + "'", CalendariosService.Titulo_NombreCol);

                //si el datatable devuelve más de una coincidencia el método retorna true
                if (dtCiclico.Rows.Count > 0) return true;
                //sino realizamos la consulta por la fecha recibida como parámetro sin discriminar si es_ciclico
                else
                {
                    DataTable table = sesion.Db.CALENDARIOSCollection.GetAsDataTable("trunc(" + Fecha_NombreCol + ",'DD')" + "=" + "trunc(to_date('" + fecha + "','dd/mm/yyyy hh24:mi:ss'),'DD') and " + CalendariosService.TipoEventoCalendarioID_NombreCol + " = '" + Definiciones.TiposEventoCalendario.Feriado + "' and " + CalendariosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'", CalendariosService.Titulo_NombreCol);
                    return table.Rows.Count > 0;
                }

            }
        }

        public CalendariosService()
        {

        }

    }
}
