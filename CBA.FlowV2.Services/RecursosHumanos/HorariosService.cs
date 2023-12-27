using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class HorariosService
    {
        #region EstaActivo
        public static bool EstaActivo(decimal horario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                HORARIOSRow row = sesion.Db.HORARIOSCollection.GetByPrimaryKey(horario_id);
                return row.ESTADO.Equals(Definiciones.Estado.Activo);
            }
        }
        #endregion EstaActivo

        #region GetHorariosDataTable
        public static DataTable GetHorariosDataTable()
        {
            return GetHorariosDataTable(string.Empty, Id_NombreCol, false);
        }

        public static DataTable GetHorariosDataTable(decimal id_horario)
        {
            string clausulas = Id_NombreCol + " = " + id_horario.ToString();
            return GetHorariosDataTable(clausulas, string.Empty, false);
        }

        public static DataTable GetHorariosDataTable(String clausulas, String orden)
        {
            return GetHorariosDataTable(clausulas, orden, false);
        }

        public static DataTable GetHorariosDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = "1=1";
                if (soloActivos) estado += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.HORARIOSCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.HORARIOSCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }

        public static DataTable GetHorariosCompletosDataTable(String clausulas, String orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.HORARIOS_COMPLETOSCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }

        public static string GetHorarioNombre(decimal horario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                HORARIOSRow row = new HORARIOSRow();
                row = sesion.Db.HORARIOSCollection.GetByPrimaryKey(horario_id);
                return row.NOMBRE;
            }
        }

        public static decimal GetHorarioIdPorNombre(string nombre_horario)
        {
            string where = HorariosService.Nombre_NombreCol + " like '%" + nombre_horario + "%'";
            DataTable dt = GetHorariosDataTable(where,string.Empty);
            if (dt.Rows.Count > 0)
                return (decimal)dt.Rows[0][HorariosService.Id_NombreCol];
            else
                return Definiciones.Error.Valor.EnteroPositivo;
        }

        #endregion GetHorariosDataTable

        #region Guardar

        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    HORARIOSRow row = new HORARIOSRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("horarios_sqc");

                    }
                    else
                    {
                        row = sesion.Db.HORARIOSCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    //campos obligatorios
                    row.PARA_FECHA = campos[ParaFecha_NombreCol].ToString();
                    row.ESTADO = campos[Estado_NombreCol].ToString();
                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    row.OBSERVACION = campos[Observacion_NombreCol].ToString();

                    if (campos[ParaFecha_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                    {
                        row.FECHA = DateTime.Parse(campos[Fecha_NombreCol].ToString());
                    }
                    else 
                    {
                        row.IsFECHANull = true;
                    }

                    if (insertarNuevo) sesion.Db.HORARIOSCollection.Insert(row);
                    else sesion.Db.HORARIOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

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

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "HORARIOS"; }
        }
        public static string Estado_NombreCol
        {
            get { return HORARIOSCollection.ESTADOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return HORARIOSCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return HORARIOSCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return HORARIOSCollection.NOMBREColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return HORARIOSCollection.OBSERVACIONColumnName; }
        }
        public static string ParaFecha_NombreCol
        {
            get { return HORARIOSCollection.PARA_FECHAColumnName; }
        }
        #endregion Tabla

        #region Vistas
        public static string VistaHorariosComplId_NombreCol
        {
            get { return HORARIOS_COMPLETOSCollection.IDColumnName; }
        }
        public static string VistaHorariosComplDiaID_NombreCol
        {
            get { return HORARIOS_COMPLETOSCollection.DIA_IDColumnName; }
        }
        public static string VistaHorariosComplFecha_NombreCol
        {
            get { return HORARIOS_COMPLETOSCollection.FECHAColumnName; }
        }
        public static string VistaHorariosComplFuncionarioId_NombreCol
        {
            get { return HORARIOS_COMPLETOSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string VistaHorariosComplHoraFin_NombreCol
        {
            get { return HORARIOS_COMPLETOSCollection.HORA_FINColumnName; }
        }
        public static string VistaHorariosComplHoraInicio_NombreCol
        {
            get { return HORARIOS_COMPLETOSCollection.HORA_INICIOColumnName; }
        }
        public static string VistaHorariosComplMarcacionesId_NombreCol
        {
            get { return HORARIOS_COMPLETOSCollection.MARCACIONES_IDColumnName; }
        }
        public static string VistaHorariosComplMinAntesEntrada_NombreCol
        {
            get { return HORARIOS_COMPLETOSCollection.MINUTOS_ANTES_ENTRADAColumnName; }
        }
        public static string VistaHorariosComplMinAntesSalida_NombreCol
        {
            get { return HORARIOS_COMPLETOSCollection.MINUTOS_ANTES_SALIDAColumnName; }
        }
        public static string VistaHorariosComplMinDespuesEntrada_NombreCol
        {
            get { return HORARIOS_COMPLETOSCollection.MINUTOS_DESPUES_ENTRADAColumnName; }
        }
        public static string VistaHorariosComplMinDespuesSalida_NombreCol
        {
            get { return HORARIOS_COMPLETOSCollection.MINUTOS_DESPUES_SALIDAColumnName; }
        }
        public static string VistaHorariosComplNivelAsignacion_NombreCol
        {
            get { return HORARIOS_COMPLETOSCollection.NIVEL_ASIGNACIONColumnName; }
        }
        public static string VistaHorariosComplNombre_NombreCol
        {
            get { return HORARIOS_COMPLETOSCollection.NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaHorariosComplParaFecha_NombreCol
        {
            get { return HORARIOS_COMPLETOSCollection.PARA_FECHAColumnName; }
        }
        public static string VistaHorariosComplTurnoID_NombreCol
        {
            get { return HORARIOS_COMPLETOSCollection.TURNO_IDColumnName; }
        }
        #endregion Vistas

        #endregion Accessors
    }
}
