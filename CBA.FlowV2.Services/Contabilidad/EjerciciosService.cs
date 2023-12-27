#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Contabilidad;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
    public class EjerciciosService
    {
        #region GetEjerciciosDataTable
        /// <summary>
        /// Gets the ejercicios data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetEjerciciosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetEjerciciosDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetEjerciciosDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTB_EJERCICIOSCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetEjerciciosDataTable

        #region GetEjerciciosInfoCompleta

        public static DataTable GetEjerciciosInfoCompleta()
        {
            return GetEjerciciosInfoCompleta(string.Empty, string.Empty);
        }

        public static DataTable GetEjerciciosInfoCompleta(String clausulas, String orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTB_EJERCICIOS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
            }
        }

        #endregion GetEjerciciosInfoCompleta

        #region GetFechaInicio
        /// <summary>
        /// Gets the fecha inicio.
        /// </summary>
        /// <param name="ejercicio_id_origen">The ejercicio_id_origen.</param>
        /// <returns></returns>
        public static DateTime GetFechaInicio(decimal ejercicio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_EJERCICIOSRow row = sesion.Db.CTB_EJERCICIOSCollection.GetByPrimaryKey(ejercicio_id);
                return row.FECHA_INICIO;
            }
        }
        #endregion GetFechaInicio

        #region GetFechaFin
        /// <summary>
        /// Gets the fecha fin.
        /// </summary>
        /// <param name="ejercicio_id_origen">The ejercicio_id_origen.</param>
        /// <returns></returns>
        public static DateTime GetFechaFinal(decimal ejercicio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_EJERCICIOSRow row = sesion.Db.CTB_EJERCICIOSCollection.GetByPrimaryKey(ejercicio_id);
                return row.FECHA_FIN;
            }
        }
        #endregion GetFechaFin

        #region GetNombre
        /// <summary>
        /// Gets the nombre.
        /// </summary>
        /// <param name="ejercicio_id">The ejercicio_id_origen.</param>
        /// <returns></returns>
        public static string GetNombre(decimal ejercicio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_EJERCICIOSRow row = sesion.Db.CTB_EJERCICIOSCollection.GetByPrimaryKey(ejercicio_id);
                return row.NOMBRE;
            }
        }
        #endregion GetNombre

        #region GetNombre
        public static decimal GetEjercicioActivo()
        {
            using (SessionService sesion = new SessionService())
            {
                return GetEjercicioActivo(sesion.SucursalActiva_Id);
            }
        }

        public static decimal GetEjercicioActivo(decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = "to_date('" + DateTime.Now.ToShortDateString() + "', 'dd/mm/yyyy') between " + FechaInicio_NombreCol + " and " + FechaFin_NombreCol + " and " +
                                   PaisId_NombreCol + " = " + SucursalesService.GetPais(sucursal_id) + " and " +
                                   SeAbrio_NombreCol + " = '" + Definiciones.SiNo.Si + "'" + " and " +
                                   Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                CTB_EJERCICIOSRow[] rows = sesion.Db.CTB_EJERCICIOSCollection.GetAsArray(clausulas, Id_NombreCol + " desc");

                if (rows.Length > 0)
                    return rows[0].ID;
                else
                    return Definiciones.Error.Valor.EnteroPositivo;
            }
        }
        #endregion GetNombre

        #region GetPlanDeCuentas

        /// <summary>
        /// Gets the plan de cuentas.
        /// </summary>
        /// <param name="ejercicio_id">The ejercicio_id.</param>
        /// <returns></returns>
        public static decimal GetPlanDeCuentas(decimal ejercicio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_EJERCICIOSRow row = sesion.Db.CTB_EJERCICIOSCollection.GetByPrimaryKey(ejercicio_id);
                return row.CTB_PLAN_CUENTA_ID;
            }
        }

        #endregion GetPlanDeCuentas

        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="ejercicio_id">The ejercicio_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal ejercicio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_EJERCICIOSRow row = sesion.Db.CTB_EJERCICIOSCollection.GetRow(Id_NombreCol + "=" + ejercicio_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region EstaAbierto
        /// <summary>
        /// Estas the abierto.
        /// </summary>
        /// <param name="ejercicio_id">The ejercicio_id.</param>
        /// <returns></returns>
        public static bool EstaAbierto(decimal ejercicio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return EstaAbierto(ejercicio_id, sesion);
            }
        }

        public static bool EstaAbierto(decimal ejercicio_id, SessionService sesion)
        {
            CTB_EJERCICIOSRow row = sesion.Db.CTB_EJERCICIOSCollection.GetRow(Id_NombreCol + "=" + ejercicio_id);
            return row.SE_ABRIO == Definiciones.SiNo.Si && row.SE_CERRO == Definiciones.SiNo.No;
        }
        #endregion EstaAbierto

        #region SetFechaInicio
        public static void SetFechaInicio(decimal ejercicio_id, DateTime valor, SessionService sesion)
        {
            CTB_EJERCICIOSRow row = sesion.Db.CTB_EJERCICIOSCollection.GetByPrimaryKey(ejercicio_id);
            string valorAnterior = row.ToString();
            row.FECHA_INICIO = valor;
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion SetFechaInicio

        #region SetFechaFin
        public static void SetFechaFin(decimal ejercicio_id, DateTime valor, SessionService sesion)
        {
            CTB_EJERCICIOSRow row = sesion.Db.CTB_EJERCICIOSCollection.GetByPrimaryKey(ejercicio_id);
            string valorAnterior = row.ToString();
            row.FECHA_FIN = valor;
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion SetFechaFin

        #region SetNombre
        public static void SetNombre(decimal ejercicio_id, string valor, SessionService sesion)
        {
            CTB_EJERCICIOSRow row = sesion.Db.CTB_EJERCICIOSCollection.GetByPrimaryKey(ejercicio_id);
            string valorAnterior = row.ToString();
            row.NOMBRE = valor;
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion SetNombre

        #region SetEstado
        public static void SetEstado(decimal ejercicio_id, string valor, SessionService sesion)
        {
            CTB_EJERCICIOSRow row = sesion.Db.CTB_EJERCICIOSCollection.GetByPrimaryKey(ejercicio_id);
            string valorAnterior = row.ToString();
            row.ESTADO = valor;
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion SetEstado

        #region AbrirEjercicio
        /// <summary>
        /// Abrirs the ejercicio.
        /// </summary>
        /// <param name="ejercicio_id">The ejercicio_id.</param>
        public static void AbrirEjercicio(decimal ejercicio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_EJERCICIOSRow row = sesion.Db.CTB_EJERCICIOSCollection.GetByPrimaryKey(ejercicio_id);
                string valorAnterior = row.ToString();

                if (row.SE_ABRIO != Definiciones.SiNo.No)
                    throw new Exception("El ejercicio ya estaba abierto.");

                if (row.SE_CERRO != Definiciones.SiNo.No)
                    throw new Exception("El ejercicio ya estaba cerrado.");

                DataTable dTPeriodos = PeriodosService.GetPeriodosDataTable(PeriodosService.EjercicioId_NombreCol + " = " + row.ID, string.Empty);
                if (dTPeriodos.Rows.Count == 0)
                    throw new Exception("Para abrir un ejercicio debe existir al menos un periodo.");

                row.SE_ABRIO = Definiciones.SiNo.Si;
                sesion.Db.CTB_EJERCICIOSCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
        }
        #endregion AbrirEjercicio

        #region CerrarEjercicio
        /// <summary>
        /// Cerrars the ejercicio.
        /// </summary>
        /// <param name="ejercicio_id">The ejercicio_id.</param>
        public static void CerrarEjercicio(decimal ejercicio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_EJERCICIOSRow row = sesion.Db.CTB_EJERCICIOSCollection.GetByPrimaryKey(ejercicio_id);
                string valorAnterior = row.ToString();

                if (row.SE_ABRIO != Definiciones.SiNo.Si)
                    throw new Exception("El ejercicio no estaba abierto.");

                if (row.SE_CERRO != Definiciones.SiNo.No)
                    throw new Exception("El ejercicio ya estaba cerrado.");

                //debe controlarse que todos los asientos hayan sido aprobados.
                AsientosService asientos = new AsientosService();
                string clausulas = AsientosService.VistaCtbEjercicioId_NombreCol + " = " + row.ID + " and " +
                                   AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                                   AsientosService.Aprobado_NombreCol + " = '" + Definiciones.SiNo.No + "' ";
                DataTable dtAsientos = AsientosService.GetAsientosInfoCompleta(clausulas, string.Empty);
                if (dtAsientos.Rows.Count > 0)
                    throw new Exception("Todos los asientos del Ejercicio deben estar cerrados.");

                row.SE_CERRO = Definiciones.SiNo.Si;
                sesion.Db.CTB_EJERCICIOSCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
        }
        #endregion CerrarEjercicio

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTB_EJERCICIOSRow row = new CTB_EJERCICIOSRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("ctb_ejercicios_sqc");

                        row.FECHA_CREACION = DateTime.Now;
                        row.USUARIO_CREACION_ID = sesion.Usuario_Id;
                        row.SE_ABRIO = Definiciones.SiNo.No;
                        row.SE_CERRO = Definiciones.SiNo.No;
                        row.SALDO_INICIAL_GENERADO = Definiciones.SiNo.No;
                    }
                    else
                    {
                        row = sesion.Db.CTB_EJERCICIOSCollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    if (row.CTB_PLAN_CUENTA_ID.Equals(DBNull.Value) || !row.CTB_PLAN_CUENTA_ID.Equals((decimal)campos[EjerciciosService.PlanDeCuentasId_NombreCol]))
                    {
                        if (!PlanesDeCuentaService.EstaActivo((decimal)campos[EjerciciosService.PlanDeCuentasId_NombreCol]))
                            throw new Exception("El plan de cuentas no está activo.");
                        else
                            row.CTB_PLAN_CUENTA_ID = (decimal)campos[EjerciciosService.PlanDeCuentasId_NombreCol];
                    }

                    if (campos.Contains(EjerciciosService.RegionId_NombreCol))
                        row.REGION_ID = (decimal)campos[EjerciciosService.RegionId_NombreCol];
                    else
                        row.IsREGION_IDNull = true;

                    if (campos.Contains(EjerciciosService.SucursalId_NombreCol))
                        row.SUCURSAL_ID = (decimal)campos[EjerciciosService.SucursalId_NombreCol];
                    else
                        row.IsSUCURSAL_IDNull = true;

                    row.NOMBRE = (string)campos[Nombre_NombreCol];
                    row.FECHA_INICIO = (DateTime)campos[FechaInicio_NombreCol];
                    row.FECHA_FIN = (DateTime)campos[FechaFin_NombreCol];
                    row.PAIS_ID = (decimal)campos[PaisId_NombreCol];

                    if (campos.Contains(EjerciciosService.EjercicioAnteriorId_NombreCol))
                        row.CTB_EJERCICIO_ANTERIOR = (decimal)campos[EjerciciosService.EjercicioAnteriorId_NombreCol];
                    else
                        row.IsCTB_EJERCICIO_ANTERIORNull = true;

                    if (row.SALDO_INICIAL_GENERADO.Equals(Definiciones.SiNo.No) && (string)campos[SaldoInicialGenerado_NombreCol] == Definiciones.SiNo.Si)
                        row.SALDO_INICIAL_GENERADO = Definiciones.SiNo.Si;

                    //Registrar cuando se inactiva un registro
                    if (row.ESTADO != null)
                    {
                        if (row.ESTADO.Equals(Definiciones.Estado.Activo) && campos[EjerciciosService.Estado_NombreCol].Equals(Definiciones.Estado.Inactivo))
                        {
                            row.USUARIO_INACTIVACION_ID = sesion.Usuario_Id;
                            row.FECHA_INACTIVACION = DateTime.Now;
                        }
                    }

                    row.ESTADO = (string)campos[Estado_NombreCol];

                    //Verifica si la fecha del ejercicio nuevo no se solapa con la fecha de ejercicios existentes.
                    if (ExistenFechasSolapadas(insertarNuevo ? row.ID : (decimal)campos[Id_NombreCol], row, sesion))
                        throw new Exception("Las fechas del ejercicio nuevo se solapa con las fechas de ejercicios existentes.");

                    if (insertarNuevo) sesion.Db.CTB_EJERCICIOSCollection.Insert(row);
                    else sesion.Db.CTB_EJERCICIOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
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

        #region Generar Saldo Inicial
        public static void generarSaldoInicial(decimal ejercicio_id_origen, decimal ejercicio_id_destino)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    CTB_EJERCICIOSRow rowEjercicioOrigen, rowEjercicioDestino;

                    DataTable dtCuenta, dtAsientosDetalle, dtPeriodo;
                    string clausula;
                    decimal moneda_id = sesion.SucursalActiva.MONEDA_ID;
                    decimal nuevoAsiento;

                    //El debe y haber va del Ejercicio Anterior al Ejercicio
                    rowEjercicioOrigen = sesion.Db.CTB_EJERCICIOSCollection.GetByPrimaryKey(ejercicio_id_origen);
                    rowEjercicioDestino = sesion.Db.CTB_EJERCICIOSCollection.GetByPrimaryKey(ejercicio_id_destino);

                    //1: Verificar si Ejercicio tiene Ejercicio Anterior
                    if (rowEjercicioDestino.IsCTB_EJERCICIO_ANTERIORNull)
                        throw new Exception("Este Ejercicio no tiene relacionado un Ejercicio anterior requerido para la generación de saldos iniciales.");
                    //2: Verificar si periodo anterior esta cerrado (los asientos deben estar aprobados)
                    if (Definiciones.SiNo.No == rowEjercicioOrigen.SE_CERRO)
                        throw new Exception("El Ejercicio anterior no esta cerrado.");

                    //Cuenta del Ejercicio Origen
                    dtCuenta = CuentasService.GetCuentasInfoCompleta(CuentasService.CtbPlanCuentaId_NombreCol + " = " + rowEjercicioOrigen.CTB_PLAN_CUENTA_ID
                                                            + " and " + CuentasService.Asentable_NombreCol + " = '" + Definiciones.SiNo.Si + "'", string.Empty);
                    //Crear Cabecera
                    #region Creacion de la cabecera
                    System.Collections.Hashtable camposAsiento = new System.Collections.Hashtable();
                    camposAsiento.Add(AsientosService.Id_NombreCol, ejercicio_id_destino);
                    camposAsiento.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
                    camposAsiento.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
                    camposAsiento.Add(AsientosService.FechaAsiento_NombreCol, (DateTime)DateTime.Today.Date);
                    camposAsiento.Add(AsientosService.Observacion_NombreCol, "Saldo inicial generado con origen en el Ejercicio " + rowEjercicioOrigen.NOMBRE + ".");
                    camposAsiento.Add(AsientosService.Estado_NombreCol, (string)Definiciones.Estado.Activo);

                    //Conseguir el Periodo Vigente    
                    clausula = PeriodosService.EjercicioId_NombreCol + " = " + ejercicio_id_destino
                                    + " and " + PeriodosService.VistaVigente_NombreCol + " = '" + Definiciones.SiNo.Si + "'";
                    dtPeriodo = PeriodosService.GetPeriodosInfoCompleta(clausula, string.Empty);
                    if (dtPeriodo.Rows.Count <= 0)
                        throw new Exception("No se encuentra un periodo vigente en el ejercicio.");

                    camposAsiento.Add(AsientosService.CtbPeriodoId_NombreCol, (decimal)dtPeriodo.Rows[0][PeriodosService.Id_NombreCol]);
                    camposAsiento.Add(AsientosService.SucursalId_NombreCol, PaisesService.GetSucursalPrincipal(rowEjercicioDestino.PAIS_ID, sesion));

                    //Guardar los datos
                    nuevoAsiento = AsientosService.Guardar(camposAsiento, true);
                    #endregion Creacion de la cabecera

                    //Trasladar el DEBE y HABER pero de manera invertida
                    for (int h = 0; h < dtCuenta.Rows.Count; h++)
                    {
                        //Suma del DEBE y HABER de Asientos Detalles
                        clausula = AsientosDetalleService.CtbCuentaId_NombreCol + " = " + dtCuenta.Rows[h][CuentasService.Id_NombreCol] + " and " +
                                   AsientosDetalleService.VistaCtbEjercicioId_NombreCol + " = " + rowEjercicioOrigen.CTB_EJERCICIO_ANTERIOR;

                        dtAsientosDetalle = AsientosDetalleService.GetAsientosDetalleInfoCompleta(clausula, string.Empty);

                        #region Calculo del debe y haber
                        decimal suma_debe = 0;
                        decimal suma_haber = 0;
                        for (int j = 0; j < dtAsientosDetalle.Rows.Count; j++)
                        {
                            if (j <= 0)
                            {
                                moneda_id = (decimal)dtAsientosDetalle.Rows[j][AsientosDetalleService.MonedaId_NombreCol];
                            }
                            else
                            {
                                if (moneda_id != (decimal)dtAsientosDetalle.Rows[j][AsientosDetalleService.MonedaId_NombreCol])
                                    throw new Exception("No todos los detalles de asiento tienen la misma moneda.");
                            }

                            if (!dtAsientosDetalle.Rows[j][AsientosDetalleService.Debe_NombreCol].Equals(DBNull.Value))
                                suma_debe += (decimal)dtAsientosDetalle.Rows[j][AsientosDetalleService.Debe_NombreCol];

                            if (!dtAsientosDetalle.Rows[j][AsientosDetalleService.Haber_NombreCol].Equals(DBNull.Value))
                                suma_haber += (decimal)dtAsientosDetalle.Rows[j][AsientosDetalleService.Haber_NombreCol];
                        }
                        #endregion Calculo del debe y haber

                        #region Creacion del detalle
                        //Crear Detalle
                        System.Collections.Hashtable camposAsientoDetalle = new System.Collections.Hashtable();
                        camposAsientoDetalle.Add(AsientosDetalleService.CtbAsientoId_NombreCol, nuevoAsiento);
                        camposAsientoDetalle.Add(AsientosDetalleService.CtbCuentaId_NombreCol, dtCuenta.Rows[h][CuentasService.Id_NombreCol]);
                        camposAsientoDetalle.Add(AsientosDetalleService.Debe_NombreCol, suma_haber);    //Se invierte el Debe y Haber
                        camposAsientoDetalle.Add(AsientosDetalleService.Haber_NombreCol, suma_debe);
                        camposAsientoDetalle.Add(AsientosDetalleService.MonedaId_NombreCol, moneda_id);
                        camposAsientoDetalle.Add(AsientosDetalleService.Orden_NombreCol, h + 1);        //Enumera cada Asiento Detalle creado
                        camposAsientoDetalle.Add(AsientosDetalleService.Observacion_NombreCol, "Asiento Detalle generado por el Saldo Inicial del Ejercicio " + rowEjercicioOrigen.NOMBRE + ".");
                        camposAsientoDetalle.Add(AsientosDetalleService.Estado_NombreCol, (string)Definiciones.Estado.Activo);

                        //Guardar los datos
                        AsientosDetalleService.Guardar(camposAsientoDetalle, true, sesion);
                        #endregion Creacion del detalle

                        //Marcar la generacion de saldo inicial
                        rowEjercicioDestino.SALDO_INICIAL_GENERADO = Definiciones.SiNo.Si;

                        sesion.Db.CommitTransaction();
                    }
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Generar Saldo Inicial

        #region Metodos Privados
        /// <summary>
        /// Verifica si el nuevo Ejercicio que se desea insertar a la tabla PlanDeCuentas no se solapa con los demas Ejercicios existentes.
        /// </summary>
        /// <param name="ctb_ejercicio_id">The ctb_ejercicio_id.</param>
        /// <param name="fecha_inicio_ejercicio_nuevo">The fecha_inicio_ejercicio_nuevo.</param>
        /// <param name="fecha_fin_ejercicio_nuevo">The fecha_fin_ejercicio_nuevo.</param>
        /// <param name="pais_id">The pais_id.</param>
        /// <returns></returns>
        private static bool ExistenFechasSolapadas(decimal ctb_ejercicio_id, CTB_EJERCICIOSRow row, SessionService sesion)
        {
            string clausulas = EjerciciosService.Id_NombreCol + " <> " + ctb_ejercicio_id + " and " +
                               EjerciciosService.PaisId_NombreCol + " = " + row.PAIS_ID + " and " +
                               EjerciciosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                               EjerciciosService.SeAbrio_NombreCol + " = '" + Definiciones.SiNo.Si + "' and " +
                               EjerciciosService.SeCerro_NombreCol + " = '" + Definiciones.SiNo.No + "' ";

            if (row.IsREGION_IDNull)
                clausulas += " and " + EjerciciosService.RegionId_NombreCol + " is null ";
            else
                clausulas += " and " + EjerciciosService.RegionId_NombreCol + " = " + row.REGION_ID;

            if (row.IsSUCURSAL_IDNull)
                clausulas += " and " + EjerciciosService.SucursalId_NombreCol + " is null ";
            else
                clausulas += " and " + EjerciciosService.SucursalId_NombreCol + " = " + row.SUCURSAL_ID;

            DataTable dtEjercicios = EjerciciosService.GetEjerciciosDataTable(clausulas, string.Empty, sesion);

            for (int i = 0; i < dtEjercicios.Rows.Count; i++)
            {
                DateTime fechaInicioEjercicio = (DateTime)dtEjercicios.Rows[i][EjerciciosService.FechaInicio_NombreCol];
                DateTime fechaFinEjercicio = (DateTime)dtEjercicios.Rows[i][EjerciciosService.FechaFin_NombreCol];

                //Verificar si fechas se solapan:
                //La fecha inicio y fin del ejercicio nuevo DEBE ser estrictamente mayor o menor que la fecha inicio y fin de los periodos ya definidos.
                int primera_prueba = fechaInicioEjercicio.CompareTo(row.FECHA_INICIO);
                int segunda_prueba = fechaFinEjercicio.CompareTo(row.FECHA_INICIO);
                int tercera_prueba = fechaInicioEjercicio.CompareTo(row.FECHA_FIN);
                int cuarta_prueba = fechaFinEjercicio.CompareTo(row.FECHA_FIN);

                //Las fechas no coinciden
                if (primera_prueba != 0 && segunda_prueba != 0 && tercera_prueba != 0 && cuarta_prueba != 0)
                {
                    //Las fechas siempre son superiores (o siempre son inferiores)
                    if ((primera_prueba == segunda_prueba) && (tercera_prueba == cuarta_prueba))
                    {
                        //Las fechas se excluyen
                        if (primera_prueba == tercera_prueba)
                            continue;
                        return true;
                    }
                    return true;
                }
                return true;
            }
            return false;
        }
        #endregion Metodos Privados

        #region Borrar
        /// <summary>
        /// Borrar ejercicio_id_origen.
        /// </summary>
        /// <param name="ctacte_pagares_id">The ejercicio_id_origen.</param>
        public static void Borrar(decimal ejercicio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    EjerciciosService ejercicio = new EjerciciosService();

                    CTB_EJERCICIOSRow rows = sesion.Db.CTB_EJERCICIOSCollection.GetByPrimaryKey(ejercicio_id);

                    //ToDo: Se controla que el ejercicio no tenga periodos asociados
                    PeriodosService periodos = new PeriodosService();
                    string clausula = PeriodosService.EjercicioId_NombreCol + " = " + ejercicio_id;
                    DataTable dtPeriodos = PeriodosService.GetPeriodosDataTable(clausula, string.Empty);
                    if (dtPeriodos.Rows.Count > 0)
                        throw new Exception("El ejercicio ya tiene periodos asociados. No puede eliminar este ejercicio.");

                    sesion.Db.CTB_EJERCICIOSCollection.Delete(rows);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rows.ID, rows.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion borrar

        #region Accesors

        public static string Nombre_Tabla
        { get { return "CTB_EJERCICIOS"; } }

        public static string EjercicioAnteriorId_NombreCol
        { get { return CTB_EJERCICIOSCollection.CTB_EJERCICIO_ANTERIORColumnName; } }

        public static string PlanDeCuentasId_NombreCol
        { get { return CTB_EJERCICIOSCollection.CTB_PLAN_CUENTA_IDColumnName; } }

        public static string FechaInicio_NombreCol
        { get { return CTB_EJERCICIOSCollection.FECHA_INICIOColumnName; } }

        public static string FechaFin_NombreCol
        { get { return CTB_EJERCICIOSCollection.FECHA_FINColumnName; } }

        public static string FechaCreacion_NombreCol
        { get { return CTB_EJERCICIOSCollection.FECHA_CREACIONColumnName; } }

        public static string FechaInacativacion_NombreCol
        { get { return CTB_EJERCICIOSCollection.FECHA_INACTIVACIONColumnName; } }

        public static string Estado_NombreCol
        { get { return CTB_EJERCICIOSCollection.ESTADOColumnName; } }

        public static string Id_NombreCol
        { get { return CTB_EJERCICIOSCollection.IDColumnName; } }

        public static string Nombre_NombreCol
        { get { return CTB_EJERCICIOSCollection.NOMBREColumnName; } }

        public static string PaisId_NombreCol
        { get { return CTB_EJERCICIOSCollection.PAIS_IDColumnName; } }

        public static string RegionId_NombreCol
        { get { return CTB_EJERCICIOSCollection.REGION_IDColumnName; } }

        public static string SeAbrio_NombreCol
        { get { return CTB_EJERCICIOSCollection.SE_ABRIOColumnName; } }

        public static string SeCerro_NombreCol
        { get { return CTB_EJERCICIOSCollection.SE_CERROColumnName; } }

        public static string SaldoInicialGenerado_NombreCol
        { get { return CTB_EJERCICIOSCollection.SALDO_INICIAL_GENERADOColumnName; } }

        public static string SucursalId_NombreCol
        { get { return CTB_EJERCICIOSCollection.SUCURSAL_IDColumnName; } }
        
        public static string UsuarioCreacionId_NombreCol
        { get { return CTB_EJERCICIOSCollection.USUARIO_CREACION_IDColumnName; } }

        public static string UsuarioInactivacionId_NombreCol
        { get { return CTB_EJERCICIOSCollection.USUARIO_INACTIVACION_IDColumnName; } }

        public static string VistaEjercicioAnteriorNombre_NombreCol
        { get { return CTB_EJERCICIOS_INFO_COMPLETACollection.EJERCICIO_ANTERIOR_NOMBREColumnName; } }

        public static string VistaPlanDeCuentasNombre_NombreCol
        { get { return CTB_EJERCICIOS_INFO_COMPLETACollection.PLAN_CUENTA_NOMBREColumnName; } }

        public static string VistaRegionNombre_NombreCol
        { get { return CTB_EJERCICIOS_INFO_COMPLETACollection.REGION_NOMBREColumnName; } }

        public static string VistaSucursalNombre_NombreCol
        { get { return CTB_EJERCICIOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; } }

        public static string VistaUsuarioCreacionNombre_NombreCol
        { get { return CTB_EJERCICIOS_INFO_COMPLETACollection.USUARIO_CREACION_NOMBREColumnName; } }

        public static string VistaUsuarioInactivacionNombre_NombreCol
        { get { return CTB_EJERCICIOS_INFO_COMPLETACollection.USUARIO_INACTIVACION_NOMBREColumnName; } }

        public static string VistaPaisNombre_NombreCol
        { get { return CTB_EJERCICIOS_INFO_COMPLETACollection.PAIS_NOMBREColumnName; } }

        #endregion Accesors
    }
}
