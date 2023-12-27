using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.General;
using CBA.FlowV2.Services.RecursosHumanos;
using Oracle.ManagedDataAccess.Client;

namespace CBA.FlowV2.Services.Herramientas
{
    public class FuncionariosVacacionesService
    {
        #region GetVacacionesRow
        private static FUNCIONARIOS_VACACIONESRow GetVacacionesRow(decimal funcionariosVacacionesId)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = FuncionariosVacacionesService.Id_NombreCol + " = " + funcionariosVacacionesId.ToString();
                return sesion.Db.FUNCIONARIOS_VACACIONESCollection.GetRow(clausula);
            }
        }

        private static FUNCIONARIOS_VACACIONESRow GetVacacionesRow(string where)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FUNCIONARIOS_VACACIONESCollection.GetRow(where);
            }
        }

        #endregion GetVacacionesRow

        #region GetVacacionesDataTable
        public static DataTable GetVacacionesDataTable(decimal funcionarioId)
        {
            using (SessionService sesion = new SessionService()) {
                string clausula = FuncionariosVacacionesService.FuncionarioId_NombreCol + " = " + funcionarioId.ToString();
                return sesion.Db.FUNCIONARIOS_VACACIONESCollection.GetAsDataTable(clausula, FuncionariosVacacionesService.Anho_NombreCol);
            }
        }

        public static DataTable GetVacacionesDataTable(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FUNCIONARIOS_VACACIONESCollection.GetAsDataTable(where, orderBy);
            }
        }


        #endregion GetVacacionesDataTable

        #region GetVacacionesDataTableById
        public static DataTable GetVacacionesDataTableById(decimal funcionarioVacacionesId)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = FuncionariosVacacionesService.Id_NombreCol + " = " + funcionarioVacacionesId.ToString();
                return sesion.Db.FUNCIONARIOS_VACACIONESCollection.GetAsDataTable(clausula, FuncionariosVacacionesService.Anho_NombreCol);
            }
        }
        #endregion GetVacacionesDataTableById

        #region ObtenerVacacionesDisponibles
        /// <summary>
        /// Se calcula la cantidad de días de vacaciones que el funcionario tiene disponible,
        /// teniendo en cuenta que no puede utilizar vacaciones no utilizadas en años anteriores.
        /// 
        /// Se tienen en cuenta únicamente las vacaciones no utilizadas que no hayan vencido en 
        /// relación a la fecha proveída y no se cuentan las vacaciones que han sido otorgadas 
        /// después de dicha fecha
        /// </summary>
        /// <param name="funcionarioId">The funcionario id.</param>
        /// <param name="fecha">The fecha.</param>
        /// <returns>Cantidad de días de vacaciones que le corresponden al funcionario hasta el dia indicado en la fecha dada</returns>
        public static decimal ObtenerVacacionesDisponibles(decimal funcionarioId, DateTime fecha)
        {
            //se obtienen las asignaciones de vacaciones que aun no vencieron
            string clausulas = FuncionariosVacacionesService.FechaVencimmiento_NombreCol + " >= to_date('" + fecha.ToString("yyyy/MM/dd") + "', 'yyyy/mm/dd')";
            clausulas += " and " + FuncionariosVacacionesService.FuncionarioId_NombreCol + " = " + funcionarioId.ToString();
            //se limitan las vacaciones a las que son del año proveido
            clausulas += " and " + FuncionariosVacacionesService.Anho_NombreCol + " = " + fecha.Year.ToString();
            using (SessionService sesion = new SessionService())
            {
                decimal diasAsignados = 0;
                decimal diasUtilizados = 0;
                DataTable vacaciones = sesion.Db.FUNCIONARIOS_VACACIONESCollection.GetAsDataTable(clausulas, FuncionariosVacacionesService.Anho_NombreCol);
                foreach (DataRow dr in vacaciones.Rows)
                {
                    diasAsignados += (decimal)dr[FuncionariosVacacionesService.Dias_NombreCol];
                    diasUtilizados += (decimal)dr[FuncionariosVacacionesService.DiasUtilizados_NombreCol];
                }
                return diasAsignados - diasUtilizados;
            }
        }
        #endregion ObtenerVacacionesDisponibles

        #region ObtenerDiasAsignados
        public static decimal ObtenerVacacionesAsignadas(decimal funcionarioId, decimal anho)
        {
            string clausulas =  FuncionariosVacacionesService.Anho_NombreCol + " = " + anho.ToString() +
                      " and " + FuncionariosVacacionesService.FuncionarioId_NombreCol + " = " + funcionarioId.ToString();
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOS_VACACIONESRow vacaciones = sesion.Db.FUNCIONARIOS_VACACIONESCollection.GetRow(clausulas);
                if(vacaciones != null)
                    return vacaciones.DIAS;
                return 0;
            }
        }
        #endregion ObtenerDiasAsignados

        #region ObtenerDiasUtilizados

        /// <summary>
        /// Cantidad de días de vacaciones utilizados por el funcionario con id funcionarioId 
        /// que se tomaron a cuenta del año recibido
        /// </summary>
        /// <param name="funcionarioId">The funcionario id.</param>
        /// <param name="anho">The anho.</param>
        /// <returns>cantidad de días de vacaciones utilizados en el año</returns>
        public static decimal ObtenerDiasUtilizados(decimal funcionarioId, decimal anho)
        {
            string clausula = FuncionariosVacacionesService.Anho_NombreCol + " = " + anho.ToString();
            clausula += " and " + FuncionariosVacacionesService.FuncionarioId_NombreCol + " = " + funcionarioId.ToString();
            FUNCIONARIOS_VACACIONESRow vacaciones = GetVacacionesRow(clausula);
            if (vacaciones == null)
                return 0;//si no existen vacaciones asignadas, se retorna 0
            else
                return vacaciones.DIAS_UTILIZADOS;
        }
        
        /// <summary>
        /// Cantidad de días de vacaciones utilizados por el funcionario con id funcionarioId 
        /// durante el año anho según legajo de funcionario
        /// </summary>
        /// <param name="funcionarioId">The funcionario id.</param>
        /// <param name="anho">The anho.</param>
        /// <returns>cantidad de días de vacaciones utilizados en el año</returns>
        public static decimal ObtenerDiasUtilizadosSegunLegajo(decimal funcionarioId, decimal anho)
        {
            string clausulas = LegajoFuncionarioService.TipoEntradaId_NombreCol + " = " + Definiciones.TipoEntradaLegajo.Vacaciones;
            clausulas += " and " + LegajoFuncionarioService.FuncionarioId_NombreCol + " = " + funcionarioId.ToString();
            clausulas += " and (" + LegajoFuncionarioService.FechaInicio_NombreCol + " between to_date ('" + anho.ToString() + "/01/01', 'yyyy/mm/dd') and to_date ('" + anho.ToString() + "/12/31', 'yyyy/mm/dd') ";
            clausulas += " or " + LegajoFuncionarioService.FechaFin_NombreCol + " between to_date ('" + anho.ToString() + "/01/01', 'yyyy/mm/dd') and to_date ('" + anho.ToString() + "/12/31', 'yyyy/mm/dd') )";
            DataTable vacacionesDetalle = LegajoFuncionarioService.GetLegajosDataTable(clausulas, LegajoFuncionarioService.FechaInicio_NombreCol, true);
            double diasUtilizados = 0;
            DateTime UnoDeEnero = new DateTime((int)anho, 1, 1);       
            foreach (DataRow dr in vacacionesDetalle.Rows){
                //se suma 1 porque la resta de fechas tiene que ser incluyente (es decir, si la fecha inicial y final es la misma[un día de vacaciones]
                //y la resta da 0, en realidad el día fue utilizado
                if( ((DateTime)dr[LegajoFuncionarioService.FechaInicio_NombreCol]).Year == anho )
                    diasUtilizados += 1 + ((DateTime)dr[LegajoFuncionarioService.FechaFin_NombreCol] - (DateTime)dr[LegajoFuncionarioService.FechaInicio_NombreCol]).TotalDays;
                else
                    diasUtilizados += 1 + ((DateTime)dr[LegajoFuncionarioService.FechaFin_NombreCol] - UnoDeEnero).TotalDays;
            }
            return (decimal)diasUtilizados;
        }
        #endregion ObtenerDiasUtilizados

        #region verificarDisponibilidadDeVacaciones
        public static bool verificarDisponibilidadDeVacaciones(decimal funcionarioId, decimal diasAUtilizar)
        {
            decimal diasDisponibles = ObtenerVacacionesDisponibles(funcionarioId, DateTime.Now);
            if ((decimal)diasAUtilizar > diasDisponibles)
                return false;
            return true;
        }

        public static bool verificarDisponibilidadDeVacaciones(decimal funcionarioId, DateTime fechaInicio, DateTime fechaFin)
        {
            decimal diasAUtilizar = FechaUtil.diasHabilesEntre(fechaInicio, fechaFin);
            //se descuentan los fines de semana contenidos 


            return verificarDisponibilidadDeVacaciones(funcionarioId, (decimal)diasAUtilizar);
        }
        #endregion verificarDisponibilidadDeVacaciones

        #region RestituirVacaciones
        public static void RestituirVacaciones(decimal funcionarioId, decimal diasARestituir)
        {
            //se obtiene el id de la asignacion de vacaciones más antigua a la cual restituir (no debe ser una asignacion vencida)
            string clausulas = FuncionariosVacacionesService.FuncionarioId_NombreCol + " = " + funcionarioId.ToString();
            clausulas += " and " + FuncionariosVacacionesService.FechaVencimmiento_NombreCol + " >= to_date('" + DateTime.Now.ToString("yyyy/MM/dd") + "', 'yyyy/mm/dd')";
            DataTable vacaciones = GetVacacionesDataTable(clausulas, FuncionariosVacacionesService.Anho_NombreCol);
            System.Collections.Hashtable campos = new System.Collections.Hashtable();
            campos[FuncionariosVacacionesService.FuncionarioId_NombreCol] = funcionarioId;
            campos[FuncionariosVacacionesService.Id_NombreCol] = vacaciones.Rows[0][FuncionariosVacacionesService.Id_NombreCol];
            campos[FuncionariosVacacionesService.Anho_NombreCol] = vacaciones.Rows[0][FuncionariosVacacionesService.Anho_NombreCol];
            campos[FuncionariosVacacionesService.Dias_NombreCol] = vacaciones.Rows[0][FuncionariosVacacionesService.Dias_NombreCol];
            campos[FuncionariosVacacionesService.FechaVencimmiento_NombreCol] = vacaciones.Rows[0][FuncionariosVacacionesService.FechaVencimmiento_NombreCol];
            decimal diasUtilizados = decimal.Parse(vacaciones.Rows[0][FuncionariosVacacionesService.DiasUtilizados_NombreCol].ToString());
            campos[FuncionariosVacacionesService.DiasUtilizados_NombreCol] = diasUtilizados - diasARestituir;
            Guardar(campos, false);
        }
        #endregion RestituirVacaciones

        #region UtilizarDiasVacaciones
        public static void UtilizarDiasVacaciones(decimal funcionarioId, decimal diasAUtilizar)
        {
            //se verifica que el funcionario cuenta con vacaciones disponibles, si cuenta con vacaciones suficientes, se descuentan las vacaciones, sino
            if (!verificarDisponibilidadDeVacaciones(funcionarioId, diasAUtilizar))
                return;

            //se obtiene el id de la asignacion de vacaciones más antigua de la cual se empieza a restar
            string clausulas = FuncionariosVacacionesService.FuncionarioId_NombreCol + " = " + funcionarioId.ToString();
            clausulas += " and " + FuncionariosVacacionesService.FechaVencimmiento_NombreCol + " >= to_date('" + DateTime.Now.ToString("yyyy/MM/dd") + "', 'yyyy/mm/dd')";
            clausulas += " and " + FuncionariosVacacionesService.DiasUtilizados_NombreCol + " < " + FuncionariosVacacionesService.Dias_NombreCol;

            while (diasAUtilizar > 0)
            {
                DataTable vacaciones = GetVacacionesDataTable(clausulas, FuncionariosVacacionesService.Anho_NombreCol);
                if (vacaciones.Rows.Count > 0)
                {
                    System.Collections.Hashtable campos = new System.Collections.Hashtable();
                    campos[FuncionariosVacacionesService.FuncionarioId_NombreCol] = funcionarioId;
                    campos[FuncionariosVacacionesService.Id_NombreCol] = vacaciones.Rows[0][FuncionariosVacacionesService.Id_NombreCol];
                    campos[FuncionariosVacacionesService.Anho_NombreCol] = vacaciones.Rows[0][FuncionariosVacacionesService.Anho_NombreCol];
                    campos[FuncionariosVacacionesService.Dias_NombreCol] = vacaciones.Rows[0][FuncionariosVacacionesService.Dias_NombreCol];
                    campos[FuncionariosVacacionesService.FechaVencimmiento_NombreCol] = vacaciones.Rows[0][FuncionariosVacacionesService.FechaVencimmiento_NombreCol];
                    decimal diasUtilizados = decimal.Parse(vacaciones.Rows[0][FuncionariosVacacionesService.DiasUtilizados_NombreCol].ToString());
                    decimal diasAsignados = decimal.Parse(vacaciones.Rows[0][FuncionariosVacacionesService.Dias_NombreCol].ToString());
                    decimal diasDisponibles = diasAsignados - diasUtilizados;
                    if ((decimal)diasAUtilizar >= diasDisponibles)
                    {//en este caso consumimos toda la asignación obtenida
                        diasAUtilizar -= diasDisponibles;
                        diasUtilizados = diasAsignados; //cancelamos la cantidad de días utilizados, consumiendo la asignación obtenida
                    }
                    else
                    {//en este caso no consumimos toda la asignación obtenida
                        diasUtilizados += (decimal)diasAUtilizar;
                        diasAUtilizar = 0;
                    }
                    campos[FuncionariosVacacionesService.DiasUtilizados_NombreCol] = diasUtilizados;
                    Guardar(campos, false);
                }
            }
        }
        
        public static void UtilizarDiasVacaciones(decimal funcionarioId, DateTime fechaInicio, DateTime fechaFin)
        {
            //se suma 1 porque la resta de fechas tiene que ser incluyente (es decir, si la fecha inicial y final es la misma[un día de vacaciones]
            //y la resta da 0, en realidad el día fue utilizado
            double diasAUtilizar = FechaUtil.diasHabilesEntre(fechaInicio, fechaFin);

            //se verifica que el funcionario cuenta con vacaciones disponibles, si cuenta con vacaciones suficientes, se descuentan las vacaciones, sino
            if (!verificarDisponibilidadDeVacaciones(funcionarioId, fechaInicio, fechaFin))
                return;

            //se obtiene el id de la asignacion de vacaciones más antigua de la cual se empieza a restar
            string clausulas = FuncionariosVacacionesService.FuncionarioId_NombreCol + " = " + funcionarioId.ToString();
            clausulas += " and " + FuncionariosVacacionesService.FechaVencimmiento_NombreCol + " >= to_date('" + DateTime.Now.ToString("yyyy/MM/dd") + "', 'yyyy/mm/dd')";
            clausulas += " and " + FuncionariosVacacionesService.DiasUtilizados_NombreCol + " < " + FuncionariosVacacionesService.Dias_NombreCol;
                
            while (diasAUtilizar > 0)
            {
                DataTable vacaciones = GetVacacionesDataTable(clausulas, FuncionariosVacacionesService.Anho_NombreCol);
                if (vacaciones.Rows.Count > 0)
                {
                    System.Collections.Hashtable campos = new System.Collections.Hashtable();
                    campos[FuncionariosVacacionesService.FuncionarioId_NombreCol] = funcionarioId;
                    campos[FuncionariosVacacionesService.Id_NombreCol] = vacaciones.Rows[0][FuncionariosVacacionesService.Id_NombreCol];
                    campos[FuncionariosVacacionesService.Anho_NombreCol] = vacaciones.Rows[0][FuncionariosVacacionesService.Anho_NombreCol];
                    campos[FuncionariosVacacionesService.Dias_NombreCol] = vacaciones.Rows[0][FuncionariosVacacionesService.Dias_NombreCol];
                    campos[FuncionariosVacacionesService.FechaVencimmiento_NombreCol] = vacaciones.Rows[0][FuncionariosVacacionesService.FechaVencimmiento_NombreCol];
                    decimal diasUtilizados = decimal.Parse(vacaciones.Rows[0][FuncionariosVacacionesService.DiasUtilizados_NombreCol].ToString());
                    decimal diasAsignados = decimal.Parse(vacaciones.Rows[0][FuncionariosVacacionesService.Dias_NombreCol].ToString());
                    decimal diasDisponibles = diasAsignados - diasUtilizados;
                    if((decimal)diasAUtilizar >= diasDisponibles){//en este caso consumimos toda la asignación obtenida
                        diasAUtilizar -= (double)diasDisponibles;
                        diasUtilizados = diasAsignados; //cancelamos la cantidad de días utilizados, consumiendo la asignación obtenida
                    }else{//en este caso no consumimos toda la asignación obtenida
                        diasUtilizados += (decimal)diasAUtilizar;
                        diasAUtilizar = 0;
                    }
                    campos[FuncionariosVacacionesService.DiasUtilizados_NombreCol] = diasUtilizados;
                    Guardar(campos, false);
                }
            }
        }
        #endregion UtilizarDiasVacaciones
        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    FUNCIONARIOS_VACACIONESRow row = new FUNCIONARIOS_VACACIONESRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("funcionarios_vacaciones_sqc");
                        row.FECHA_CREACION = DateTime.Now;
                    }
                    else
                    {
                        row = sesion.Db.FUNCIONARIOS_VACACIONESCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    //campos obligatorios
                    row.FUNCIONARIO_ID = decimal.Parse(campos[FuncionarioId_NombreCol].ToString());
                    row.ANHO = decimal.Parse(campos[Anho_NombreCol].ToString());
                    row.DIAS = decimal.Parse(campos[Dias_NombreCol].ToString());
                    row.FECHA_VENCIMIENTO = (DateTime)campos[FechaVencimmiento_NombreCol];
                    
                    
                    //campos no obligatorios.
                    if (campos.Contains(DiasUtilizados_NombreCol)) row.DIAS_UTILIZADOS = decimal.Parse(campos[DiasUtilizados_NombreCol].ToString()) ;
                    
                    if (insertarNuevo) sesion.Db.FUNCIONARIOS_VACACIONESCollection.Insert(row);
                    else sesion.Db.FUNCIONARIOS_VACACIONESCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (OracleException exp)
                {
                    sesion.Db.RollbackTransaction();
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            throw new System.ArgumentException("Ya han sido asignadas vacaciones para el año " + campos[Anho_NombreCol].ToString() + ".");
                        default: throw exp;
                    }
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal funcionariosVacacionesId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    FUNCIONARIOS_VACACIONESRow fila = sesion.Db.FUNCIONARIOS_VACACIONESCollection.GetByPrimaryKey(funcionariosVacacionesId);

                    sesion.Db.FUNCIONARIOS_VACACIONESCollection.DeleteByPrimaryKey(funcionariosVacacionesId);
                    LogCambiosService.LogDeRegistro(FuncionariosVacacionesService.Nombre_Tabla, funcionariosVacacionesId, fila.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    sesion.CommitTransaction();
                
                }
                catch(Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla 
        {
            get { return "FUNCIONARIOS_VACACIONES"; }
        }
        public static string Anho_NombreCol
        {
            get { return FUNCIONARIOS_VACACIONESCollection.ANHOColumnName; }
        }
        public static string Dias_NombreCol
        {
            get { return FUNCIONARIOS_VACACIONESCollection.DIASColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return FUNCIONARIOS_VACACIONESCollection.FECHA_CREACIONColumnName; }
        }
        public static string FechaVencimmiento_NombreCol
        {
            get { return FUNCIONARIOS_VACACIONESCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return FUNCIONARIOS_VACACIONESCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return FUNCIONARIOS_VACACIONESCollection.IDColumnName; }
        }
        public static string DiasUtilizados_NombreCol
        {
            get { return FUNCIONARIOS_VACACIONESCollection.DIAS_UTILIZADOSColumnName; }
        }
        
        #endregion Accessors
    }
}
