using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class HorariosFuncionariosService
    {
        #region Borrar
        public static void Borrar(decimal horario_funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.Db.BeginTransaction();

                HORARIOS_FUNCIONARIOSRow row = new HORARIOS_FUNCIONARIOSRow();
                row = sesion.Db.HORARIOS_FUNCIONARIOSCollection.GetByPrimaryKey(horario_funcionario_id);
                String valorAnterior = row.ToString();

                sesion.Db.HORARIOS_FUNCIONARIOSCollection.DeleteByPrimaryKey(horario_funcionario_id);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);

                sesion.Db.CommitTransaction();
            }
        }
        #endregion Borrar

        #region GetHorariosFuncionariosDataTable
        public static DataTable GetHorariosFuncionariosDataTable(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.HORARIOS_FUNCIONARIOSCollection.GetAsDataTable(clausula, string.Empty);
            }
        }
        public DataTable GetHorariosFuncionariosDataTable(decimal horario_funcionario_id)
        {
            return GetHorariosFuncionariosDataTable(HORARIOS_FUNCIONARIOSCollection.IDColumnName + "=" + horario_funcionario_id);
        }

        public static DataTable GetHorariosFuncInfoComplDataTable(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.HORARIOS_FUNC_INFO_COMPLCollection.GetAsDataTable(clausula, string.Empty);
            }
        }
        #endregion GetHorariosFuncionariosDataTable

        #region GetDiasAsignadosFuncDataTable

        public static DataTable GetDiasAsignadosFuncDataTable(string condicion)
        {
            DataTable dtHorarios = new DataTable();
            DataTable dtDias = new DataTable();
            dtHorarios = GetHorariosFuncionariosDataTable(condicion);
            string clausulas = HorariosDiasService.HorarioId_NombreCol + " in (0";

            foreach (DataRow row in dtHorarios.Rows)
            {
                clausulas = clausulas + "," + row[HorarioID_NombreCol].ToString();
            }

            clausulas = clausulas + ")";

            dtDias = HorariosDiasService.GetHorariosDiasDataTable(clausulas);

            return dtDias;
        }

        #endregion GetDiasAsignadosFuncDataTable

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos)
        {
            SessionService sesion = new SessionService();
            try
            {
                sesion.Db.BeginTransaction();

                string funcionarioId= string.Empty;
                string seccionId = string.Empty;
                string departamentoId = string.Empty;

                if (campos.Contains(FuncionarioID_NombreCol)) funcionarioId= campos[FuncionarioID_NombreCol].ToString();
                if (campos.Contains(EmpresaSeccionID_NombreCol)) seccionId= campos[EmpresaSeccionID_NombreCol].ToString();
                if (campos.Contains(EmpresaDepartamentoID_NombreCol)) departamentoId= campos[EmpresaDepartamentoID_NombreCol].ToString();    

                if (Validar(funcionarioId,seccionId,departamentoId,campos[HorarioID_NombreCol].ToString()))
                {
                    HORARIOS_FUNCIONARIOSRow row = new HORARIOS_FUNCIONARIOSRow();
                    String valorAnterior = string.Empty;
                    valorAnterior = Definiciones.Log.RegistroNuevo;

                    row.ID = sesion.Db.GetSiguienteSecuencia("horarios_funcionarios_sqc");
                    row.HORARIO_ID = decimal.Parse(campos[HorarioID_NombreCol].ToString());

                    if (campos.Contains(FuncionarioID_NombreCol)) 
                    {
                        row.FUNCIONARIO_ID = decimal.Parse(funcionarioId);
                    }
                    else if (campos.Contains(EmpresaSeccionID_NombreCol))
                    {
                        row.EMPRESA_SECCION_ID = decimal.Parse(seccionId);
                    }
                    else if (campos.Contains(EmpresaDepartamentoID_NombreCol))
                    {
                        row.EMPRESA_DEPARTAMENTO_ID = departamentoId;
                    }

                    sesion.Db.HORARIOS_FUNCIONARIOSCollection.Insert(row);
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
        private static bool Validar(string funcionario_id,string seccion_id, string departamento_id, string horario_id)
        {
            try
            {
                DataTable diasAsignadosFunc = new DataTable();
                DataTable diasAsignadosHorario = new DataTable();
                string texto= string.Empty;
                string clausulas = string.Empty;

                if(funcionario_id != string.Empty)
                { 
                    clausulas= FuncionarioID_NombreCol + " = " + funcionario_id;
                    texto= "el funcionario "; 
                }
                else if(seccion_id != string.Empty) 
                {
                    clausulas= EmpresaSeccionID_NombreCol + " = " + seccion_id;
                    texto= "la sección ";
                }
                else if(departamento_id != string.Empty)
                { 
                    clausulas= EmpresaDepartamentoID_NombreCol + " = '" + departamento_id + "'";
                    texto= "el departamento ";
                }

                diasAsignadosFunc = GetDiasAsignadosFuncDataTable(clausulas);
                diasAsignadosHorario = HorariosDiasService.GetDiasAsignadosHorarioDataTable(horario_id);

                bool encontro = false;

                foreach (DataRow row in diasAsignadosFunc.Rows)
                {    
                    //encontrar los dias de los horarios que estan asignados al funcionario que coinciden con el que se quiere grabar
                    DataRow [] rowsConciden = diasAsignadosHorario.Select(HorariosDiasService.DiaId_NombreCol + " = " + row[HorariosDiasService.DiaId_NombreCol]);
                    
                    if(rowsConciden.Length>0)
                    {
                        encontro= true;
                        throw new Exception("No puede agregar " + texto+ " por que los hay horarios que se superponen.");
                    }
                }

                return !encontro;
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
            get { return "HORARIOS_FUNCIONARIOS"; }
        }
        public static string Id_NombreCol
        {
            get { return HORARIOS_FUNCIONARIOSCollection.IDColumnName; }
        }
        public static string EmpresaDepartamentoID_NombreCol
        {
            get { return HORARIOS_FUNCIONARIOSCollection.EMPRESA_DEPARTAMENTO_IDColumnName; }
        }
        public static string EmpresaSeccionID_NombreCol
        {
            get { return HORARIOS_FUNCIONARIOSCollection.EMPRESA_SECCION_IDColumnName; }
        }
        public static string FuncionarioID_NombreCol
        {
            get { return HORARIOS_FUNCIONARIOSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string HorarioID_NombreCol
        {
            get { return HORARIOS_FUNCIONARIOSCollection.HORARIO_IDColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string Nombre_Vista
        {
            get { return "HORARIOS_FUNC_INFO_COMPL"; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return HORARIOS_FUNC_INFO_COMPLCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaDeptoSeccionNombre_NombreCol
        {
            get { return HORARIOS_FUNC_INFO_COMPLCollection.DEPTO_SECCION_NOMBREColumnName; }
        }
        public static string VistaDeptoNombre_NombreCol
        {
            get { return HORARIOS_FUNC_INFO_COMPLCollection.DEPTO_NOMBREColumnName; }
        }    
        #endregion Vista

        #endregion Accessors
    }
}
