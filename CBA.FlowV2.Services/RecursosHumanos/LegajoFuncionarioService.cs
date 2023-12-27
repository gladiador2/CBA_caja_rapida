using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class LegajoFuncionarioService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="legajo_id">The legajo_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal legajo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                LEGAJO_FUNCIONARIOSRow row = sesion.Db.LEGAJO_FUNCIONARIOSCollection.GetByPrimaryKey(legajo_id);
                return row.ESTADO.Equals(Definiciones.Estado.Activo);
            }
        }
        #endregion EstaActivo

        #region GetLegajosDataTable
        /// <summary>
        /// Gets the legajos data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLegajosDataTable()
        {
            return GetLegajosDataTable(string.Empty, Id_NombreCol, false);
        }
        /// <summary>
        /// Gets the legajos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetLegajosDataTable(String clausulas, String orden)
        {
            return GetLegajosDataTable(clausulas, orden, false);
        }
        /// <summary>
        /// Gets the legajos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetLegajosDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = "1=1";
                if (soloActivos) estado +=" and "+ Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.LEGAJO_FUNCIONARIOSCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.LEGAJO_FUNCIONARIOSCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #region GetLegajosDataTableInfoCompleta
        /// <summary>
        /// Gets the legajos info completa por funcionario.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public DataTable GetLegajosInfoCompletaPorFuncionario(decimal funcionario_id) 
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.LEGAJO_FUNCIONARIOS_INFO_COMPLCollection.GetAsDataTable(FuncionarioId_NombreCol+"="+funcionario_id,Id_NombreCol);
            }
        }
        /// <summary>
        /// Gets the legajos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <returns></returns>
        public DataTable GetLegajosInfoCompleta(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                string entidad = VistaFuncionarioEntidadId_NombreCol + "=" + sesion.Entidad.ID;
                if (clausulas.Equals(string.Empty)) clausulas = entidad;
                else clausulas +=" and " +entidad;

                return sesion.Db.LEGAJO_FUNCIONARIOS_INFO_COMPLCollection.GetAsDataTable(clausulas, Id_NombreCol);
            }
        }
        #endregion GetLegajosDataTableInfoCompleta


        #endregion GetTiposDeEntradaDataTable

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

                    LEGAJO_FUNCIONARIOSRow row = new LEGAJO_FUNCIONARIOSRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("legajo_funcionarios_sqc");
                        row.USUARIO_CREACION_ID = sesion.Usuario_Id;
                        row.FECHA_CREACION = DateTime.Now;                        
                    }
                    else
                    {
                        row = sesion.Db.LEGAJO_FUNCIONARIOSCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    //campos obligatorios
                    row.FUNCIONARIO_ID = decimal.Parse(campos[FuncionarioId_NombreCol].ToString());
                    row.ENTRADA_AUTOMATICA = campos[EntradaAutomatica_NombreCol].ToString();
                    row.OBSERVACION = campos[Observacion_NombreCol].ToString();
                    row.TIPO_ENTRADA_ID = decimal.Parse(campos[TipoEntradaId_NombreCol].ToString());
                    
                    //campos no obligatorios.
                    if (campos.Contains(FechaInicio_NombreCol)) row.FECHA_INICIO = DateTime.Parse(campos[FechaInicio_NombreCol].ToString());
                    if (campos.Contains(FechaFin_NombreCol)) row.FECHA_FIN = DateTime.Parse(campos[FechaFin_NombreCol].ToString());

                    // se revisa si la entrada es nueva
                    if (!insertarNuevo)
                    {
                        // si no es nueva se revisa si esta activo 
                        if (row.ESTADO.Equals(Definiciones.Estado.Activo))
                        {
                            // si se pasa del estado activo a inactivo se registra el usuario y la fecha que lo realiza
                            row.ESTADO = campos[Estado_NombreCol].ToString();
                            if (row.ESTADO.Equals(Definiciones.Estado.Inactivo))
                            {
                                row.USUARIO_ANULACION_ID = sesion.Usuario_Id;
                                row.FECHA_ANULACION = DateTime.Now;
                            }
                        }
                        else 
                        {
                            // no se permite reactivar entradas ya inactivadas
                            // si la entrada se encuentra inactiva y trata de pasarse al estado inactivo se lanza una excepcion
                            row.ESTADO = campos[Estado_NombreCol].ToString();
                            if (row.ESTADO.Equals(Definiciones.Estado.Activo)) 
                            {
                                throw new System.ArgumentException("No se puede reactivar una entrada del legajo anulada");
                            }
                        }
                    }
                    else 
                    {
                        //si la entrada es nueva se carga el dato enviado desde la UI
                        row.ESTADO = campos[Estado_NombreCol].ToString();
                        //si se cargo como inactivo se marca el usuario y la fecha
                        if (row.ESTADO.Equals(Definiciones.Estado.Inactivo))
                        {
                            row.USUARIO_ANULACION_ID = sesion.Usuario_Id;
                            row.FECHA_ANULACION = DateTime.Now;
                        }
                    }

                    if (row.TIPO_ENTRADA_ID == Definiciones.TipoEntradaLegajo.Vacaciones)
                    {                        
                        string sql = "select * from " + Nombre_Tabla + " lf " +
                                     " where ((trunc(lf." + FechaInicio_NombreCol + ") >= '" + row.FECHA_INICIO.ToShortDateString() + "'" +
                                     " and trunc(lf." + FechaFin_NombreCol + ") <= '" + row.FECHA_FIN.ToShortDateString() + "') " +
                                     " or ('" + row.FECHA_INICIO.ToShortDateString() + "' between trunc(lf." + FechaInicio_NombreCol + ") " +
                                     " and trunc(lf." + FechaFin_NombreCol + "))" +
                                     " or ('" + row.FECHA_FIN.ToShortDateString() + "' between trunc(lf." + FechaInicio_NombreCol + ") " +
                                     " and trunc(lf." + FechaFin_NombreCol + ")))" +
                                     " and lf." + FuncionarioId_NombreCol + " = " + row.FUNCIONARIO_ID + 
                                     " and lf." + TipoEntradaId_NombreCol + " = " + Definiciones.TipoEntradaLegajo.Vacaciones +
                                     " and lf." + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                                     " and lf." + Id_NombreCol + " != " + row.ID;

                        DataTable auxLegajosFuncionarios = sesion.Db.EjecutarQuery(sql);

                        if (auxLegajosFuncionarios.Rows.Count > 0)
                            throw new System.ArgumentException("Ya se han usado las fecha de vacaciones que se quiere insertar.");
                    }
                    if (insertarNuevo) sesion.Db.LEGAJO_FUNCIONARIOSCollection.Insert(row);
                    else sesion.Db.LEGAJO_FUNCIONARIOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (OracleException exp)
                {
                    sesion.Db.RollbackTransaction();
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            throw new System.ArgumentException("Ya existe un registro con ese nombre.");
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

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "LEGAJO_FUNCIONARIOS"; }
        }
        public static string EntradaAutomatica_NombreCol
        { 
            get { return LEGAJO_FUNCIONARIOSCollection.ENTRADA_AUTOMATICAColumnName; } 
        }

        public static string Estado_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOSCollection.ESTADOColumnName; }
        }
        public static string FechaAnulacion_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOSCollection.FECHA_ANULACIONColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOSCollection.FECHA_CREACIONColumnName; }
        }
        public static string FechaFin_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOSCollection.FECHA_FINColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOSCollection.FECHA_INICIOColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOSCollection.IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOSCollection.OBSERVACIONColumnName; }
        }
        public static string TipoEntradaId_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOSCollection.TIPO_ENTRADA_IDColumnName; }
        }
        public static string UsuarioAnulacion_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOSCollection.USUARIO_ANULACION_IDColumnName; }
        }
        
        #endregion Tabla
        #region Vista
        public static string VistaFuncionarioEntidadId_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOS_INFO_COMPLCollection.FUNCIONARIO_ENTIDAD_IDColumnName; }
        }
        public static string VistaFuncionarioEntidadNombre_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOS_INFO_COMPLCollection.FUNCIONARIO_ENTIDAD_NOMBREColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOS_INFO_COMPLCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaTipoEntradaNombre_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOS_INFO_COMPLCollection.TIPO_ENTRADA_NOMBREColumnName; }
        }
        public static string VistaUsuarioAnulacionNombre_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOS_INFO_COMPLCollection.USUARIO_ANULACION_NOMBREColumnName; }
        }
        public static string VistaUsuarioCreacionNombre_NombreCol
        {
            get { return LEGAJO_FUNCIONARIOS_INFO_COMPLCollection.USUARIO_CREACION_NOMBREColumnName; }
        }
        #endregion Vista
        #endregion Accessors
    }
}
