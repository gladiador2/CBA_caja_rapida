using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class HorariosTurnosService
    {
        #region Borrar
        public static void Borrar(decimal horario_turno_id)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.Db.BeginTransaction();

                HORARIOS_TURNOSRow row = new HORARIOS_TURNOSRow();
                row = sesion.Db.HORARIOS_TURNOSCollection.GetByPrimaryKey(horario_turno_id);
                String valorAnterior = row.ToString();

                sesion.Db.HORARIOS_TURNOSCollection.DeleteByPrimaryKey(horario_turno_id);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);

                sesion.Db.CommitTransaction();
            }
        }
        #endregion Borrar

        #region GetHorariosTurnosDataTable

        public static DataTable GetHorariosTurnosDataTable(string clausula,string order)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.HORARIOS_TURNOSCollection.GetAsDataTable(clausula,order);
            }
        }
        public static DataTable GetHorariosTurnosDataTable(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.HORARIOS_TURNOSCollection.GetAsDataTable(clausula, Nombre_NombreCol);
            }
        }
        public DataTable GetHorariosTurnosDataTable(decimal horario_turno_id)
        {
            return GetHorariosTurnosDataTable(HORARIOS_TURNOSCollection.IDColumnName + "=" + horario_turno_id);
        }
        #endregion GetHorariosDiasDataTable

        #region Guardar

        public static void Guardar(System.Collections.Hashtable campos)
        {
            SessionService sesion = new SessionService();
            try
            {
                sesion.Db.BeginTransaction();

                HORARIOS_TURNOSRow row = new HORARIOS_TURNOSRow();
                String valorAnterior = string.Empty;
                bool esNuevo;

                if (campos.Contains(Id_NombreCol))
                {
                    esNuevo = false;
                    row= sesion.Db.HORARIOS_TURNOSCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                    
                }
                else 
                {
                    esNuevo = true;  
                    row.ID = sesion.Db.GetSiguienteSecuencia("horarios_turnos_sqc");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }

                row.HORARIO_ID = decimal.Parse(campos[HorarioId_NombreCol].ToString());

                DateTime horaInicioAux = DateTime.Parse("01/01/2000 " + campos[HoraInicio_NombreCol].ToString());
                DateTime horaFinAux = DateTime.Parse("01/01/2000 " + campos[HoraFin_NombreCol].ToString());
                
                if (horaFinAux.CompareTo(horaInicioAux) < 0) //si la fecha de fin es menor, asumimos que pasa para el siguiente día
                {
                    horaFinAux= horaFinAux.AddDays(1);
                }
                
                row.HORA_INICIO = horaInicioAux;
                row.HORA_FIN= horaFinAux;

                if (Validar(horaInicioAux,horaFinAux,row.HORARIO_ID,row.ID))
                {
                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    row.MINUTOS_ANTES_ENTRADA = decimal.Parse(campos[MinutosAntesEntrada_NombreCol].ToString());
                    row.MINUTOS_ANTES_SALIDA = decimal.Parse(campos[MinutosAntesSalida_NombreCol].ToString());
                    row.MINUTOS_DESPUES_ENTRADA = decimal.Parse(campos[MinutosDespuesEntrada_NombreCol].ToString());
                    row.MINUTOS_DESPUES_SALIDA = decimal.Parse(campos[MinutosDespuesSalida_NombreCol].ToString());

                    if (esNuevo) sesion.Db.HORARIOS_TURNOSCollection.Insert(row);
                    else sesion.Db.HORARIOS_TURNOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
            }
            catch (Exception exp)
            {
                sesion.Db.RollbackTransaction();
                throw exp;
            }

        }

        #endregion Guardar

        #region Validar
        private  static bool Validar(DateTime inicio, DateTime fin, decimal horario_id, decimal id)
        {
            try
            {         
                string clausulas = HorarioId_NombreCol + " = " + horario_id + " and "+ Id_NombreCol + " <> " + id;
                DataTable dt = GetHorariosTurnosDataTable(clausulas, HoraInicio_NombreCol);

                bool inicioInvalido;
                bool finInvalido;

                //comparar que el turno que se va a insertar no se solape con otro
                foreach (DataRow row in dt.Rows)
                {
                    inicioInvalido = (inicio > DateTime.Parse(row[HoraInicio_NombreCol].ToString())) && (inicio < DateTime.Parse(row[HoraFin_NombreCol].ToString()));
                    finInvalido = (fin > DateTime.Parse(row[HoraInicio_NombreCol].ToString())) && (fin < DateTime.Parse(row[HoraFin_NombreCol].ToString()));

                    if (inicioInvalido || finInvalido)
                    {
                        throw new Exception("Rango de horas no válido por que se superpone a otro existente.");
                    }
                }

                return true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "HORARIOS_TURNOS"; }
        }
        public static string Id_NombreCol
        {
            get { return HORARIOS_TURNOSCollection.IDColumnName; }
        }
        public static string HoraFin_NombreCol
        {
            get { return HORARIOS_TURNOSCollection.HORA_FINColumnName; }
        }
        public static string HoraInicio_NombreCol
        {
            get { return HORARIOS_TURNOSCollection.HORA_INICIOColumnName; }
        }
        public static string HorarioId_NombreCol
        {
            get { return HORARIOS_TURNOSCollection.HORARIO_IDColumnName; }
        }
        public static string MinutosAntesEntrada_NombreCol
        {
            get { return HORARIOS_TURNOSCollection.MINUTOS_ANTES_ENTRADAColumnName; }
        }
        public static string MinutosAntesSalida_NombreCol
        {
            get { return HORARIOS_TURNOSCollection.MINUTOS_ANTES_SALIDAColumnName; }
        }
        public static string MinutosDespuesEntrada_NombreCol
        {
            get { return HORARIOS_TURNOSCollection.MINUTOS_DESPUES_ENTRADAColumnName; }
        }
        public static string MinutosDespuesSalida_NombreCol
        {
            get { return HORARIOS_TURNOSCollection.MINUTOS_DESPUES_SALIDAColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return HORARIOS_TURNOSCollection.NOMBREColumnName; }
        }
        #endregion Tabla
        
        #endregion Accessors
    }
}
