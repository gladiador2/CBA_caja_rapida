#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Contabilidad;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
#endregion Using
namespace CBA.FlowV2.Services.Contabilidad
{
    public class PeriodosService
    {
        #region GetPeriodosDataTable
        public static DataTable GetPeriodosDataTable()
        {
            return GetPeriodosDataTable(string.Empty, string.Empty);
        }

        public static DataTable GetPeriodosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPeriodosDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetPeriodosDataTable(string clausulas, string orden, SessionService sesion)
        {
            DataTable table;
            string estado = "1=1";

            if (!clausulas.Equals(string.Empty))
                table = sesion.Db.CTB_PERIODOSCollection.GetAsDataTable(clausulas, orden);
            else
                table = sesion.Db.CTB_PERIODOSCollection.GetAsDataTable(estado, orden);
            return table;
        }
        #endregion GetPeriodosDataTable

        #region GetPeriodosInfoCompleta
        public static DataTable GetPeriodosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string estado = " 1=1 ";

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.CTB_PERIODOS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
                }
                else
                {
                    table = sesion.Db.CTB_PERIODOS_INFO_COMPLETACollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetPeriodosInfoCompleta

        #region GetPreiodoActivoAAsentar
        public static DataTable GetPeriodoActivoAAsentar(DateTime fecha, CasosService caso, SessionService sesion)
        {
            return GetPeriodoActivoAAsentar(fecha, caso.SucursalId, sesion);
        }

        public static DataTable GetPeriodoActivoAAsentar(DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPeriodoActivoAAsentar(fecha, sesion.SucursalActiva_Id, sesion);
            }
        }

        public static DataTable GetPeriodoActivoAAsentar(DateTime fecha, decimal sucursal_id, SessionService sesion)
        {
            var sucursal = new SucursalesService(sucursal_id, sesion);
            decimal regionId = Definiciones.Error.Valor.EnteroPositivo;
            if (sucursal.RegionId.HasValue)
                regionId = sucursal.RegionId.Value;

            string sql = " select min(" + PeriodosService.Id_NombreCol + ") " + PeriodosService.Id_NombreCol +
                         "   from " + Nombre_Vista +
                         "  where " + PeriodosService.VistaEntidadId_NombreCol + " = " + sesion.Entidad.ID +
                         "    and " + PeriodosService.VistaEjercicioPaisId_NombreCol + " = " + sucursal.PaisId +
                         "    and " + "(" + PeriodosService.VistaEjercicioRegionId_NombreCol + " = " + regionId + " or " + PeriodosService.VistaEjercicioRegionId_NombreCol + " is null) " +
                         "    and (" + PeriodosService.VistaEjercicioSucursalId_NombreCol + " = " + sucursal.Id.Value + " or " + PeriodosService.VistaEjercicioSucursalId_NombreCol + " is null) " +
                         "    and " + PeriodosService.VistaEjercicioSeAbrio_NombreCol + " = '" + Definiciones.SiNo.Si + "' " +
                         "    and " + PeriodosService.VistaEjercicioSeCerro_NombreCol + " = '" + Definiciones.SiNo.No + "' and (VIGENTE = 'S' OR VIGENTE_POR_MARGEN = 'S') " +
                         "    and to_date('" + fecha.ToShortDateString() + "', 'dd/mm/yyyy') " + " between " + PeriodosService.FechaInicio_NombreCol + " and " + PeriodosService.FechaFin_NombreCol +
                         " group by " + PeriodosService.VistaEjercicioPlanCuentaId_NombreCol;

            DataTable dtPeriodos = sesion.db.EjecutarQuery(sql);
            if (dtPeriodos.Rows.Count <= 0)
                return new DataTable();

            string[] ids = new string[dtPeriodos.Rows.Count];
            for (int i = 0; i < dtPeriodos.Rows.Count; i++)
                ids[i] = dtPeriodos.Rows[i][PeriodosService.Id_NombreCol].ToString();

            sql = PeriodosService.Id_NombreCol + " in (" + string.Join(",", ids) + ")";
            DataTable dt = PeriodosService.GetPeriodosInfoCompleta(sql, PeriodosService.Id_NombreCol);

            return dt;
        }
        #endregion GetPreiodoActivoAAsentar

        #region EstaVigenteOConMargen
        /// <summary>
        /// Estas the vigente O con margen.
        /// </summary>
        /// <param name="periodo_id">The periodo_id.</param>
        /// <returns></returns>
        public static bool EstaVigenteOConMargen(DateTime fecha, decimal periodo_id, SessionService sesion)
        {
            string clausulas = PeriodosService.Id_NombreCol + " = " + periodo_id + " and " +
               PeriodosService.VistaEntidadId_NombreCol + " = " + sesion.Entidad.ID + " and " +
               PeriodosService.VistaEjercicioSeAbrio_NombreCol + " = '" + Definiciones.SiNo.Si + "' and " +
               PeriodosService.VistaEjercicioSeCerro_NombreCol + " = '" + Definiciones.SiNo.No + "' and " +
               "to_date('" + fecha.ToShortDateString() + "', 'dd/mm/yyyy') " +
               " between " + PeriodosService.FechaInicio_NombreCol + " - " + VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.CTBAsientosCrearDiasAntesFechaInicioPeriodo) +
               "     and " + PeriodosService.FechaFin_NombreCol + " + " + VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.CTBAsientosCrearDiasLuegoFechaFinalPeriodo);

            DataTable dt = PeriodosService.GetPeriodosInfoCompleta(clausulas, string.Empty);
            return dt.Rows.Count > 0;
        }
        #endregion EstaVigenteOConMargen

        #region EstaActivo
        public static bool EstaActivo(decimal periodo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_PERIODOSRow row = sesion.Db.CTB_PERIODOSCollection.GetRow(Id_NombreCol + "=" + periodo_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetEjercicio
        /// <summary>
        /// Gets the ejercicio.
        /// </summary>
        /// <param name="periodo_id">The periodo_id.</param>
        /// <returns></returns>
        public static decimal GetEjercicio(decimal periodo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetEjercicio(periodo_id, sesion);
            }
        }
        public static decimal GetEjercicio(decimal periodo_id, SessionService sesion)
        {
            CTB_PERIODOSRow row = sesion.Db.CTB_PERIODOSCollection.GetRow(Id_NombreCol + " = " + periodo_id);
            return row.CTB_EJERCICIO_ID;
        }
        #endregion GetEjercicio

        #region GetPlanCuenta
        /// <summary>
        /// Gets the plan cuenta.
        /// </summary>
        /// <param name="periodo_id">The periodo_id.</param>
        /// <returns></returns>
        public static decimal GetPlanCuenta(decimal periodo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPlanCuenta(periodo_id, sesion);
            }
        }
        public static decimal GetPlanCuenta(decimal periodo_id, SessionService sesion)
        {
            DataTable dt = EjerciciosService.GetEjerciciosDataTable(EjerciciosService.Id_NombreCol + " = " + GetEjercicio(periodo_id, sesion), string.Empty, sesion);
            return (decimal)dt.Rows[0][EjerciciosService.PlanDeCuentasId_NombreCol];
        }
        #endregion GetEjercicio

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTB_PERIODOSRow row = new CTB_PERIODOSRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("ctb_periodos_sqc");

                        row.FECHA_CREACION = DateTime.Now;
                        row.USUARIO_CREACION_ID = sesion.Usuario_Id;
                    }
                    else
                    {
                        row = sesion.Db.CTB_PERIODOSCollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    if (!row.CTB_EJERCICIO_ID.Equals((decimal)campos[PeriodosService.EjercicioId_NombreCol]))
                    {
                        if (! EjerciciosService.EstaActivo((decimal)campos[PeriodosService.EjercicioId_NombreCol]))
                            throw new Exception("El ejercicio no está activo.");
                    }
                    row.CTB_EJERCICIO_ID = (decimal)campos[PeriodosService.EjercicioId_NombreCol];

                    row.NOMBRE = (string)campos[Nombre_NombreCol];
                    row.FECHA_INICIO = (DateTime)campos[FechaInicio_NombreCol];
                    row.FECHA_FIN = (DateTime)campos[FechaFin_NombreCol];

                    //Registrar cuando se inactiva un registro
                    if (row.ESTADO != null)
                    {
                        if (row.ESTADO.Equals(Definiciones.Estado.Activo) && campos[PeriodosService.Estado_NombreCol].Equals(Definiciones.Estado.Inactivo))
                        {
                            row.USUARIO_INACTIVACION_ID = sesion.Usuario_Id;
                            row.FECHA_INACTIVACION = DateTime.Now;
                        }
                    }
                    row.ESTADO = (string)campos[Estado_NombreCol];

                    if (insertarNuevo) sesion.Db.CTB_PERIODOSCollection.Insert(row);
                    else sesion.Db.CTB_PERIODOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
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
        /// <summary>
        /// Borrar periodo_id.
        /// </summary>
        /// <param name="ctacte_pagares_id">The periodo_id.</param>
        public static void Borrar(decimal periodo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    AsientosService asiento = new AsientosService();
                    
                    //DataTable dtPeriodos = periodo.GetPeriodosDataTable( PeriodosService.Id_NombreCol + " = " + periodo_id , string.Empty);
                    CTB_PERIODOSRow row = sesion.Db.CTB_PERIODOSCollection.GetByPrimaryKey(periodo_id);

                    DataTable dtAsientos = AsientosService.GetAsientosDataTable(AsientosService.CtbPeriodoId_NombreCol + " = " + row.ID, string.Empty, sesion);
                    if(dtAsientos.Rows.Count > 0)
                        throw new Exception("El periodo tiene asientos registrados. No lo puede eliminar.");

                    sesion.Db.CTB_PERIODOSCollection.Delete(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void BorrarTodos(decimal id_ejercicio)
        {
            try
            {              
                DataTable dtPeriodos = new DataTable();
                dtPeriodos = PeriodosService.GetPeriodosDataTable( PeriodosService.EjercicioId_NombreCol + " = " + id_ejercicio, string.Empty);
                for (int i = 0; i < dtPeriodos.Rows.Count; i++)
                {
                    int idRegistro = int.Parse(dtPeriodos.Rows[i][Id_NombreCol].ToString());
                    PeriodosService.Borrar(idRegistro);
                }
                    }
                catch (Exception exp)
                {
                    throw exp;
                }
        }

        #endregion borrar

        #region Accesors

        public static string Nombre_Tabla
        { get { return "CTB_PERIODOS"; } }

        public static string Nombre_Vista
        { get { return "CTB_PERIODOS_INFO_COMPLETA"; } }

        public static string EjercicioId_NombreCol
        { get { return CTB_PERIODOSCollection.CTB_EJERCICIO_IDColumnName; } }

        public static string FechaInicio_NombreCol
        { get { return CTB_PERIODOSCollection.FECHA_INICIOColumnName; } }

        public static string FechaFin_NombreCol
        { get { return CTB_PERIODOSCollection.FECHA_FINColumnName; } }

        public static string FechaCreacion_NombreCol
        { get { return CTB_PERIODOSCollection.FECHA_CREACIONColumnName; } }

        public static string FechaInacativacion_NombreCol
        { get { return CTB_PERIODOSCollection.FECHA_INACTIVACIONColumnName; } }

        public static string Nombre_NombreCol
        { get { return CTB_PERIODOSCollection.NOMBREColumnName; } }

        public static string Estado_NombreCol
        { get { return CTB_PERIODOSCollection.ESTADOColumnName; } }

        public static string UsuarioCreacionId_NombreCol
        { get { return CTB_PERIODOSCollection.USUARIO_CREACION_IDColumnName; } }

        public static string UsuarioInactivacionId_NombreCol
        { get { return CTB_PERIODOSCollection.USUARIO_INACTIVACION_IDColumnName; } }

        public static string Id_NombreCol
        { get { return CTB_PERIODOSCollection.IDColumnName; } }

        public static string VistaEntidadId_NombreCol
        { get { return CTB_PERIODOS_INFO_COMPLETACollection.ENTIDAD_IDColumnName; } }

        public static string VistaEjercicioNombre_NombreCol
        { get { return CTB_PERIODOS_INFO_COMPLETACollection.EJERCICIO_NOMBREColumnName; } }

        public static string VistaEjercicioPaisId_NombreCol
        { get { return CTB_PERIODOS_INFO_COMPLETACollection.EJERCICIO_PAIS_IDColumnName; } }

        public static string VistaEjercicioPlanCuentaId_NombreCol
        { get { return CTB_PERIODOS_INFO_COMPLETACollection.EJERCICIO_PLAN_CUENTA_IDColumnName; } }

        public static string VistaEjercicioRegionId_NombreCol
        { get { return CTB_PERIODOS_INFO_COMPLETACollection.EJERCICIO_REGION_IDColumnName; } }

        public static string VistaEjercicioSeAbrio_NombreCol
        { get { return CTB_PERIODOS_INFO_COMPLETACollection.EJERCICIO_SE_ABRIOColumnName; } }

        public static string VistaEjercicioSeCerro_NombreCol
        { get { return CTB_PERIODOS_INFO_COMPLETACollection.EJERCICIO_SE_CERROColumnName; } }

        public static string VistaEjercicioSucursalId_NombreCol
        { get { return CTB_PERIODOS_INFO_COMPLETACollection.EJERCICIO_SUCURSAL_IDColumnName; } }

        public static string VistaUsuarioCreacionNombre_NombreCol
        { get { return CTB_PERIODOS_INFO_COMPLETACollection.USUARIO_CREACION_NOMBREColumnName; } }
        
        public static string VistaUsuarioInactivacionNombre_NombreCol
        { get { return CTB_PERIODOS_INFO_COMPLETACollection.USUARIO_INACTIVACION_NOMBREColumnName; } }

        public static string VistaVigente_NombreCol
        { get { return CTB_PERIODOS_INFO_COMPLETACollection.VIGENTEColumnName ; } }

        public static string VistaVigentePorMargen_NombreCol
        { get { return CTB_PERIODOS_INFO_COMPLETACollection.VIGENTE_POR_MARGENColumnName; } }

        #endregion Accesors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static PeriodosService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid},
            });

            if (e == null)
                return null;
            else
                return new PeriodosService(e.RegistroId, sesion);
        }

        public static decimal? GetIdPorUUID(string uuid, SessionService sesion)
        {
            if (uuid.Length <= 0)
                return null;

            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return e.RegistroId;
        }
        #endregion interfaz IEntidadMigrable
        
        #region Propiedades
        protected CTB_PERIODOSRow row;
        protected CTB_PERIODOSRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal CtbEjercicioId { get { return row.CTB_EJERCICIO_ID; } set { row.CTB_EJERCICIO_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime FechaCreacion { get { return row.FECHA_CREACION; } set { row.FECHA_CREACION = value; } }
        public DateTime FechaFin { get { return row.FECHA_FIN; } set { row.FECHA_FIN = value; } }
        public DateTime? FechaInactivacion { get { if (row.IsFECHA_INACTIVACIONNull) return null; else return row.FECHA_INACTIVACION; } set { if (value.HasValue) row.FECHA_INACTIVACION = value.Value; else row.IsFECHA_INACTIVACIONNull = true; } }
        public DateTime FechaInicio { get { return row.FECHA_INICIO; } set { row.FECHA_INICIO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return ClaseCBABase.GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        public decimal UsuarioCreacion { get { return row.USUARIO_CREACION_ID; } set { row.USUARIO_CREACION_ID = value; } }
        public decimal? UsuarioInactivacionId { get { if (row.IsUSUARIO_INACTIVACION_IDNull) return null; else return row.USUARIO_INACTIVACION_ID; } set { if (value.HasValue) row.USUARIO_INACTIVACION_ID = value.Value; else row.IsUSUARIO_INACTIVACION_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTB_PERIODOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTB_PERIODOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public PeriodosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public PeriodosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public PeriodosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        #endregion Constructores
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
