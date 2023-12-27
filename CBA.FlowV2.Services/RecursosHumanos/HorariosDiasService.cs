using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class HorariosDiasService
    {
        #region Borrar
        public static void Borrar(decimal horario_dia_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    HORARIOS_DIASRow row = new HORARIOS_DIASRow();
                    row = sesion.Db.HORARIOS_DIASCollection.GetByPrimaryKey(horario_dia_id);
                    String valorAnterior = row.ToString();

                    sesion.Db.HORARIOS_DIASCollection.DeleteByPrimaryKey(horario_dia_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }
        #endregion Borrar

        #region GetHorariosDiasDataTable
        public static DataTable GetHorariosDiasDataTable(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.HORARIOS_DIASCollection.GetAsDataTable(clausula, string.Empty);
            }
        }

        public static DataTable GetHorariosDiasDataTable(decimal horario_dia_id)
        {
            return GetHorariosDiasDataTable(HORARIOS_DIASCollection.IDColumnName + "=" + horario_dia_id);
        }

        public static DataTable GetHorariosDiasInfoCompleta(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.HORARIOSDIAS_INFO_COMPLCollection.GetAsDataTable(clausula,string.Empty);
            }
        }
        #endregion GetHorariosDiasDataTable

        #region GetDiasAsignadosHorarioDataTable

        public static DataTable GetDiasAsignadosHorarioDataTable(string horario_id)
        {
            DataTable dt = new DataTable();
            string clausulas = HorarioId_NombreCol + " = " + horario_id;
            dt = GetHorariosDiasDataTable(clausulas);
            return dt;
        }

        #endregion GetDiasAsignadosHorarioDataTable(horario_id)

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    if (Validar(campos[HorarioId_NombreCol].ToString(), campos[DiaId_NombreCol].ToString()))
                    {
                        HORARIOS_DIASRow row = new HORARIOS_DIASRow();
                        String valorAnterior = string.Empty;
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.Db.GetSiguienteSecuencia("horarios_dias_sqc");
                        row.HORARIO_ID = decimal.Parse(campos[HorarioId_NombreCol].ToString());
                        row.DIA_ID = decimal.Parse(campos[DiaId_NombreCol].ToString());

                        sesion.Db.HORARIOS_DIASCollection.Insert(row);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);
                       
                    }
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

        #region Validar
        private static bool Validar(string horario_id, string dia_id)
        {
            try
            {
                bool encontro= false;
                string clausulas = HorarioId_NombreCol + " = " + horario_id;
                DataTable dtFuncionarios = HorariosFuncionariosService.GetHorariosFuncionariosDataTable(clausulas);
                DataTable dtDiasAsignadosFunc;

                foreach(DataRow row in dtFuncionarios.Rows)
                {
                    if (!row[HorariosFuncionariosService.FuncionarioID_NombreCol].Equals(DBNull.Value))
                    {
                        clausulas = HorariosFuncionariosService.FuncionarioID_NombreCol + " = " + row[HorariosFuncionariosService.FuncionarioID_NombreCol].ToString();
                    }
                    else if (!row[HorariosFuncionariosService.EmpresaSeccionID_NombreCol].Equals(DBNull.Value))
                    {
                        clausulas = HorariosFuncionariosService.EmpresaSeccionID_NombreCol + " = " + row[HorariosFuncionariosService.EmpresaSeccionID_NombreCol].ToString();
                    }
                    else if (!row[HorariosFuncionariosService.EmpresaDepartamentoID_NombreCol].Equals(DBNull.Value))
                    {
                        clausulas = HorariosFuncionariosService.EmpresaDepartamentoID_NombreCol + " = '" + row[HorariosFuncionariosService.EmpresaDepartamentoID_NombreCol].ToString() + "'";
                    }

                    dtDiasAsignadosFunc = HorariosFuncionariosService.GetDiasAsignadosFuncDataTable(clausulas);

                    DataRow[] rowsConciden = dtDiasAsignadosFunc.Select(HorariosDiasService.DiaId_NombreCol + " = " + dia_id);

                    if (rowsConciden.Length > 0)
                    {
                        encontro = true;
                        throw new Exception("No se puede agregar el día por que se encontraron conflictos con otros horarios asignados");
                    }
                }
                return !encontro;     
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        #endregion Validar

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "HORARIOS_DIAS"; }
        }
        public static string Id_NombreCol
        {
            get { return HORARIOS_DIASCollection.IDColumnName;}
        }
        public static string DiaId_NombreCol
        {
            get { return HORARIOS_DIASCollection.DIA_IDColumnName; }
        }
        public static string HorarioId_NombreCol
        {
            get { return HORARIOS_DIASCollection.HORARIO_IDColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string VistaDiaNombre_NombreCol
        {
           get { return HORARIOSDIAS_INFO_COMPLCollection.NOMBREColumnName; }
        }
        #endregion Vista

        #endregion Accessors
    }
}
