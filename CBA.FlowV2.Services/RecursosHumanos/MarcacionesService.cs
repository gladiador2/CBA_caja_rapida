#region using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;

#endregion using

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class MarcacionesService
    {
        #region GetMarcacionesInfoCompleta
        /// <summary>
        /// Gets the marcaciones information completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetMarcacionesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.MARCACIONES_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetMarcacionesInfoCompleta

        #region CopiarMarcaciones
        public static void CopiarMarcaciones() 
        {
            try
            {
                bool usaRelojExterno = false;
                DataTable dtMarcaciones = new DataTable();
                DataTable dtFuncionarios;
                System.Collections.Hashtable campos = new System.Collections.Hashtable();             

                #region Extraer Datos
                switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.Cliente))
                {
                  
                }
                #endregion Extraer Datos

                if (usaRelojExterno)
                {
                    #region Guardar Marcacion
                    foreach (DataRow row in dtMarcaciones.Rows)
                    {
                        campos.Clear();
                        campos.Add(RelojMarcacionID_NombreCol, row["Logid"].ToString());
                        campos.Add(FechaMarcacion_NombreCol, row["CheckTime"].ToString());
                        campos.Add(RelojFuncionarioId_NombreCol, row["UserId"].ToString());
                        campos.Add(EsCopiado_NombreCol, Definiciones.SiNo.Si);
                        campos.Add(Justificado_NombreCol, Definiciones.SiNo.No);
                        campos.Add(TipoMovimiento_NombreCol, Definiciones.TipoMovimientoMarcaciones.Otros);
                        campos.Add(FechaCopiado_NombreCol, DateTime.Now);
                        campos.Add(Descontar_NombreCol, Definiciones.SiNo.No);

                        dtFuncionarios = FuncionariosService.GetFuncionarioPorMarcacionesId(decimal.Parse(row["UserId"].ToString()));

                        if (!dtFuncionarios.Rows.Count.Equals(0))
                        {
                            campos.Add(FuncionarioID_NombreCol, dtFuncionarios.Rows[0][FuncionariosService.Id_NombreCol].ToString());
                        }

                        Guardar(campos, true, true, new SessionService());

                    }
                    #endregion Guardar Marcacion
                }
            }

            catch (Exception)
            {
                throw;
            }
        }
        #endregion CopiarMarcacion

        #region GetUltimaMarcacion
        private static decimal GetUltimaMarcacion()
        {
            using (SessionService sesion = new SessionService()) 
            {
                DataTable dt = new DataTable();
                dt= sesion.Db.EjecutarQuery("select max(" + RelojMarcacionID_NombreCol + ") from " + Nombre_Tabla);

                if (dt.Rows[0][0].Equals(DBNull.Value))
                    return 0;
                else
                    return decimal.Parse(dt.Rows[0][0].ToString());
            }
        }
        #endregion GetUltimaMarcacion

        #region GetTipoUltimaMarcacion
        /// <summary>
        /// Gets the tipo ultima marcacion.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static string GetTipoUltimaMarcacion(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string sql = "select " + MarcacionesService.TipoMovimiento_NombreCol +
                             "  from " + Nombre_Tabla + 
                             " where " + MarcacionesService.ID_NombreCol + " = (" +
                             "       select max(" + MarcacionesService.ID_NombreCol + ") from " + Nombre_Tabla + " where " + MarcacionesService.FuncionarioID_NombreCol + " = " + funcionario_id + 
                             "       )";
                DataTable dt = sesion.db.EjecutarQuery(sql);

                if (dt.Rows.Count <= 0)
                    return Definiciones.TipoMovimientoMarcaciones.Salida;
                else
                    return (string)dt.Rows[0][0];
            }
        }
        #endregion GetTipoUltimaMarcacion

        #region GetMarcacionesDataTable
        public static DataTable GetMarcacionesDataTable(DateTime desde, DateTime hasta, int filtro, string id_func) 
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    DataTable dtFuncionarios = new DataTable();
                    string campoIdFuncNombre = string.Empty;

                    #region Filtrar Funcionarios
                    if (filtro.Equals(0)) //todos los funcionarios
                    {
                        dtFuncionarios = FuncionariosService.GetFuncionariosInfoCompleta();
                        campoIdFuncNombre = FuncionariosService.Id_NombreCol;
                    }
                    else if (filtro.Equals(1)) //Funcionarios por departamento
                    {
                        dtFuncionarios = EmpresaCargosFuncionariosService.GetFuncionariosPorDepartamentoInfoCompleta(id_func);
                        campoIdFuncNombre = EmpresaCargosFuncionariosService.FuncionarioId_NombreCol;
                    }
                    else if (filtro.Equals(2)) //Funcionarios por seccion
                    {
                        EmpresaCargosFuncionariosService empresaCargos = new EmpresaCargosFuncionariosService();
                        dtFuncionarios = empresaCargos.GetFuncionariosPorSeccionInfoCompleta(Decimal.Parse(id_func));
                        campoIdFuncNombre = EmpresaCargosFuncionariosService.FuncionarioId_NombreCol;
                    }
                    else if (filtro.Equals(3)) //Funcionario por ID
                    {
                        dtFuncionarios = FuncionariosService.GetFuncionario2(Decimal.Parse(id_func));
                        campoIdFuncNombre = FuncionariosService.Id_NombreCol;
                    }

                    #endregion Filtrar Funcionarios

                    hasta = hasta.AddMinutes(1439); //Ir hasta las 23:59 de ese día
                    string clausulas = "(" + FechaMarcacion_NombreCol + " between trunc(to_date('" + desde + "','dd/mm/yyyy hh24:mi:ss'),'DD') and to_date('" + hasta + "','dd/mm/yyyy hh24:mi:ss'))" +
                                   " and " + FuncionarioID_NombreCol + " in ('0'";

                    foreach (DataRow row in dtFuncionarios.Rows)
                    {
                        if (!row[campoIdFuncNombre].Equals(DBNull.Value))
                            clausulas = clausulas + ",'" + row[campoIdFuncNombre] + "'";
                    }

                    clausulas = clausulas + ")";

                    return sesion.Db.MARCACIONES_INFO_COMPLCollection.GetAsDataTable(clausulas, FechaMarcacion_NombreCol);
                }

                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        #endregion GetMarcacionesDataTable

        #region GetMarcacionesParaEntradasSalidas
        private static DataTable GetMarcacionesParaEntradasSalidas(DateTime desde, DateTime hasta) 
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    string clausulas =  FechaMarcacion_NombreCol + " between to_date('" + desde + "','dd/mm/yyyy hh24:mi:ss') and to_date('" + hasta + "','dd/mm/yyyy hh24:mi:ss')";                    
                    return sesion.Db.MARCACIONES_ENTRADAS_SALIDASCollection.GetAsDataTable(clausulas, ID_NombreCol);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        #endregion GetMarcacionesParaEntradasSalidas

        #region SepararEntradasDeSalidas
        public static void SepararEntradasDeSalidas(DateTime desde, DateTime hasta)
        {
            DataTable dtMarcaciones = GetMarcacionesParaEntradasSalidas(desde,hasta);
            System.Collections.Hashtable campos = new System.Collections.Hashtable();
            decimal anterior = Definiciones.Error.Valor.EnteroPositivo;

            foreach(DataRow r in dtMarcaciones.Rows) 
            {
                if (!anterior.Equals(decimal.Parse(r[ID_NombreCol].ToString())))
                {
                    campos.Clear();
                    campos.Add(ID_NombreCol, r[EntradasSaildasId_NombreCol].ToString());
                    campos.Add(TipoMovimiento_NombreCol, r[EntradasSaildasTipoMovimiento_NombreCol].ToString());
                    Guardar(campos, false, false, new SessionService());
                    anterior = decimal.Parse(r[ID_NombreCol].ToString());
                }             
            }
        }
        #endregion SepararEntradasDeSalidas

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, bool procesarMarcacion)
        {
            using (SessionService sesion = new SessionService())
            {
                return Guardar(campos, insertarNuevo, procesarMarcacion, sesion);
            }
        }
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, bool procesarMarcacion, SessionService sesion)
        {
            try
            {
                #region variables
                MARCACIONESRow row = new MARCACIONESRow();
                DataTable dtTurnos;
                String valorAnterior = string.Empty;
                TimeSpan entradaAntesMargen = new TimeSpan();
                TimeSpan entrada = new TimeSpan();
                TimeSpan entradaDespuesMargen = new TimeSpan();
                TimeSpan salidaAntesMargen = new TimeSpan();
                TimeSpan salida = new TimeSpan();
                TimeSpan salidaDespuesMargen = new TimeSpan();
                TimeSpan horaMarcacion;
                decimal TurnoIdAux= Definiciones.Error.Valor.EnteroPositivo;
                int calificacion = Definiciones.CalificacionMarcaciones.Indefinido;
                bool descontar = false;
                #endregion variables

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID= sesion.Db.GetSiguienteSecuencia("marcaciones_sqc");
                }
                else
                {
                    row = sesion.Db.MARCACIONESCollection.GetByPrimaryKey(decimal.Parse(campos[ID_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }

                if (campos.Contains(FechaMarcacion_NombreCol))
                    row.FECHA_MARCACION = DateTime.Parse(campos[FechaMarcacion_NombreCol].ToString());

                if (campos.Contains(Justificado_NombreCol))
                    row.JUSTIFICADO = campos[Justificado_NombreCol].ToString();

                if (campos.Contains(RelojMarcacionID_NombreCol))
                    row.RELOJ_MARCACION_ID = decimal.Parse(campos[RelojMarcacionID_NombreCol].ToString());

                if (campos.Contains(RelojFuncionarioId_NombreCol))
                    row.RELOJ_FUNCIONARIO_ID = decimal.Parse(campos[RelojFuncionarioId_NombreCol].ToString());

                if (campos.Contains(FuncionarioID_NombreCol))
                    row.FUNCIONARIO_ID = decimal.Parse(campos[FuncionarioID_NombreCol].ToString());

                if (campos.Contains(EsCopiado_NombreCol))
                    row.ES_COPIADO = campos[EsCopiado_NombreCol].ToString();
                else
                    row.ES_COPIADO = Definiciones.SiNo.No;

                if (campos.Contains(Observacion_NombreCol))
                    row.OBSERVACION = campos[Observacion_NombreCol].ToString();

                if (campos.Contains(FechaCopiado_NombreCol))
                    row.FECHA_COPIADO = DateTime.Parse(campos[FechaCopiado_NombreCol].ToString());

                if (campos.Contains(TipoMovimiento_NombreCol))
                    row.TIPO_MOVIMIENTO = campos[TipoMovimiento_NombreCol].ToString();
                else
                    row.TIPO_MOVIMIENTO = Definiciones.TipoMovimientoMarcaciones.Otros;

                if (campos.Contains(Descuento_llegada_tardia_Id))
                    row.DESCUENTO_LLEGADA_TARDIA_ID = (decimal)campos[Descuento_llegada_tardia_Id];

                if (campos.Contains(Descontar_NombreCol))
                {
                    //Se procesará el descuento sólo si el nuevo valor para el campo Descontrar es "S" y el viejo "N"
                    descontar= campos[Descontar_NombreCol].ToString().Equals(Definiciones.SiNo.Si) && row.DESCONTAR.Equals(Definiciones.SiNo.No);
                    row.DESCONTAR = campos[Descontar_NombreCol].ToString();
                }
                else
                    row.DESCONTAR = Definiciones.SiNo.No;

                if (procesarMarcacion) //cuando se están separando entradas de salidas no es necesario procesar la marcación
                {
                    #region Procesar Movimiento
                    if (!row.IsFUNCIONARIO_IDNull)
                    {
                        dtTurnos = GetTurnos(row.FUNCIONARIO_ID, row.FECHA_MARCACION);
                        horaMarcacion = row.FECHA_MARCACION.TimeOfDay;

                        foreach (DataRow row2 in dtTurnos.Rows) //buscar a que turno corresponde y un estado
                        {
                            entradaAntesMargen = (DateTime.Parse(row2[HorariosService.VistaHorariosComplHoraInicio_NombreCol].ToString()).AddMinutes((-1) * double.Parse(row2[HorariosService.VistaHorariosComplMinAntesEntrada_NombreCol].ToString()))).TimeOfDay;
                            entrada = DateTime.Parse(row2[HorariosService.VistaHorariosComplHoraInicio_NombreCol].ToString()).TimeOfDay;
                            entradaDespuesMargen = (DateTime.Parse(row2[HorariosService.VistaHorariosComplHoraInicio_NombreCol].ToString()).AddMinutes(double.Parse(row2[HorariosService.VistaHorariosComplMinDespuesEntrada_NombreCol].ToString()))).TimeOfDay;
                            salidaAntesMargen = (DateTime.Parse(row2[HorariosService.VistaHorariosComplHoraFin_NombreCol].ToString()).AddMinutes((-1) * double.Parse(row2[HorariosService.VistaHorariosComplMinAntesSalida_NombreCol].ToString()))).TimeOfDay;
                            salida = DateTime.Parse(row2[HorariosService.VistaHorariosComplHoraFin_NombreCol].ToString()).TimeOfDay;
                            salidaDespuesMargen = (DateTime.Parse(row2[HorariosService.VistaHorariosComplHoraFin_NombreCol].ToString()).AddMinutes(double.Parse(row2[HorariosService.VistaHorariosComplMinDespuesSalida_NombreCol].ToString()))).TimeOfDay;

                            if (horaMarcacion >= entradaAntesMargen && horaMarcacion <= entrada) calificacion = Definiciones.CalificacionMarcaciones.ATiempo;
                            else if (horaMarcacion >= entrada && horaMarcacion <= entradaDespuesMargen) calificacion = Definiciones.CalificacionMarcaciones.EnMargen;
                            else if (horaMarcacion >= entradaDespuesMargen && horaMarcacion <= salidaAntesMargen) calificacion = Definiciones.CalificacionMarcaciones.ADestiempo;
                            else if (horaMarcacion >= salidaAntesMargen && horaMarcacion <= salida) calificacion = Definiciones.CalificacionMarcaciones.EnMargen;
                            else if (horaMarcacion >= salida && horaMarcacion <= salidaDespuesMargen) calificacion = Definiciones.CalificacionMarcaciones.ATiempo;

                            TurnoIdAux = decimal.Parse(row2[HorariosService.VistaHorariosComplTurnoID_NombreCol].ToString());

                            if (!calificacion.Equals(Definiciones.CalificacionMarcaciones.Indefinido)) break;
                        }

                        if (!calificacion.Equals(Definiciones.CalificacionMarcaciones.Indefinido)) //Si no se encontró un turno no deben cargarse estos datos
                        {
                            row.TURNO_ENTRADA_ANTES = DateTime.Parse(entradaAntesMargen.ToString());
                            row.TURNO_ENTRADA = DateTime.Parse(entrada.ToString());
                            row.TURNO_ENTRADA_DESPUES = DateTime.Parse(entradaDespuesMargen.ToString());
                            row.TURNO_SALIDA_ANTES = DateTime.Parse(salidaAntesMargen.ToString());
                            row.TURNO_SALIDA = DateTime.Parse(salida.ToString());
                            row.TURNO_SALIDA_DESPUES = DateTime.Parse(salidaDespuesMargen.ToString());
                            row.TURNO_ID = TurnoIdAux;
                        }
                    }

                    row.CALIFICACION = calificacion;
                    #endregion Procesar Movimiento 
                }

                //Insertar/Actualizar el registro de marcaciones
                if (insertarNuevo) sesion.Db.MARCACIONESCollection.Insert(row);
                else sesion.Db.MARCACIONESCollection.Update(row);

                /*Aqui estaba el codigo de registrar llegadas tardias, fue trasferido a descuentos funcionarios al aplicar politicas.*/
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                return row.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal marcacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.Db.BeginTransaction();

                MARCACIONESRow row = new MARCACIONESRow();
                row = sesion.Db.MARCACIONESCollection.GetByPrimaryKey(marcacion_id);
                String valorAnterior = row.ToString();

                sesion.Db.MARCACIONESCollection.DeleteByPrimaryKey(marcacion_id);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);

                sesion.Db.CommitTransaction();
            }
        }
        #endregion Borrar

        #region GetTurnos
        public static DataTable GetTurnos(decimal funcionario_id, DateTime fecha)
        {
            DataTable dt;
            string clausulas;

            clausulas = HorariosService.VistaHorariosComplFuncionarioId_NombreCol + " = " + funcionario_id + " and " +
                        HorariosService.VistaHorariosComplParaFecha_NombreCol + " = '" + Definiciones.SiNo.Si + "' and " +
                        HorariosService.VistaHorariosComplFecha_NombreCol + " = trunc(to_date('" + fecha + "','dd/mm/yyyy hh24:mi:ss'),'DD')" ;

            //Traer el horario especifico para la fecha, a nivel funcionario
            dt = HorariosService.GetHorariosCompletosDataTable(clausulas + " and " + HorariosService.VistaHorariosComplNivelAsignacion_NombreCol + " = 1 ", HorariosService.VistaHorariosComplHoraInicio_NombreCol);

            //Traer el horario especifico para la fecha, a nivel seccion
            if (dt.Rows.Count == 0)
                dt = HorariosService.GetHorariosCompletosDataTable(clausulas + " and " + HorariosService.VistaHorariosComplNivelAsignacion_NombreCol + " = 2 ", HorariosService.VistaHorariosComplHoraInicio_NombreCol);

            //Traer el horario especifico para la fecha, a nivel departamento
            if (dt.Rows.Count == 0) 
                dt = HorariosService.GetHorariosCompletosDataTable(clausulas + " and " + HorariosService.VistaHorariosComplNivelAsignacion_NombreCol + " = 3 ", HorariosService.VistaHorariosComplHoraInicio_NombreCol);

            //si no hay uno para la fecha, buscar para el dia
            if (dt.Rows.Count == 0)
            {
                DiasSemanaService diasSemana = new DiasSemanaService();
                string diaId = diasSemana.GetIdDiaEnDayOfWeek(fecha.DayOfWeek.GetHashCode());

                clausulas = HorariosService.VistaHorariosComplFuncionarioId_NombreCol + " = " + funcionario_id + " and " +
                            HorariosService.VistaHorariosComplParaFecha_NombreCol + " = '" + Definiciones.SiNo.No + "' and " +
                            HorariosService.VistaHorariosComplDiaID_NombreCol + " = " + diaId;
                
                //Buscar horarios a nivel funcionario
                dt = HorariosService.GetHorariosCompletosDataTable(clausulas + " and " + HorariosService.VistaHorariosComplNivelAsignacion_NombreCol + " = 1 ", HorariosService.VistaHorariosComplHoraInicio_NombreCol);

                //Buscar horarios a nivel seccion
                if (dt.Rows.Count == 0) 
                    dt = HorariosService.GetHorariosCompletosDataTable(clausulas + " and " + HorariosService.VistaHorariosComplNivelAsignacion_NombreCol + " = 2 ", HorariosService.VistaHorariosComplHoraInicio_NombreCol);

                //Buscar horarios a nivel departamento
                if (dt.Rows.Count == 0) 
                    dt = HorariosService.GetHorariosCompletosDataTable(clausulas + " and " + HorariosService.VistaHorariosComplNivelAsignacion_NombreCol + " = 3 ", HorariosService.VistaHorariosComplHoraInicio_NombreCol);      
            }
                        
           return dt;
        }
        #endregion GetTurnos

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "MARCACIONES"; }
        }
        public static string ID_NombreCol
        {
            get { return MARCACIONESCollection.IDColumnName; }
        }
        public static string RelojMarcacionID_NombreCol
        {
            get { return MARCACIONESCollection.RELOJ_MARCACION_IDColumnName; }
        }
        public static string EsCopiado_NombreCol
        {
            get { return MARCACIONESCollection.ES_COPIADOColumnName; }
        }
        public static string FechaCopiado_NombreCol
        {
            get { return MARCACIONESCollection.FECHA_COPIADOColumnName; }
        }
        public static string Justificado_NombreCol
        {
            get { return MARCACIONESCollection.JUSTIFICADOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return MARCACIONESCollection.OBSERVACIONColumnName; }
        }
        public static string FechaMarcacion_NombreCol
        {
            get { return MARCACIONESCollection.FECHA_MARCACIONColumnName; }
        }
        public static string RelojFuncionarioId_NombreCol
        {
            get { return MARCACIONESCollection.RELOJ_FUNCIONARIO_IDColumnName; }
        }
        public static string Calificacion_NombreCol
        {
            get { return MARCACIONESCollection.CALIFICACIONColumnName; }
        }
        public static string Descontado_NombreCol
        {
            get { return MARCACIONESCollection.DESCONTADOColumnName; }
        }
        public static string Descontar_NombreCol
        {
            get { return MARCACIONESCollection.DESCONTARColumnName; }
        }
        public static string TipoMovimiento_NombreCol
        {
            get { return MARCACIONESCollection.TIPO_MOVIMIENTOColumnName; }
        }
        public static string FuncionarioID_NombreCol
        {
            get { return MARCACIONESCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string TurnoEntradaAntes_NombreCol
        {
            get { return MARCACIONESCollection.TURNO_ENTRADA_ANTESColumnName; }
        }
        public static string TurnoEntrada_NombreCol
        {
            get { return MARCACIONESCollection.TURNO_ENTRADAColumnName; }
        }
        public static string TurnoEntradaDespues_NombreCol
        {
            get { return MARCACIONESCollection.TURNO_ENTRADA_DESPUESColumnName; }
        }
        public static string TurnoSalidaAntes_NombreCol
        {
            get { return MARCACIONESCollection.TURNO_SALIDA_ANTESColumnName; }
        }
        public static string TurnoSalida_NombreCol
        {
            get { return MARCACIONESCollection.TURNO_SALIDAColumnName; }
        }
        public static string TurnoSalidaDespues_NombreCol
        {
            get { return MARCACIONESCollection.TURNO_SALIDA_DESPUESColumnName; }
        }
        public static string TurnoId_NombreCol
        {
            get { return MARCACIONESCollection.TURNO_IDColumnName; }
        }
        public static string Descuento_llegada_tardia_Id
        {
            get { return MARCACIONESCollection.DESCUENTO_LLEGADA_TARDIA_IDColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string FuncNombreCompleto_NombreCol
        {
            get { return MARCACIONES_INFO_COMPLCollection.NOMBRE_COMPLETOColumnName; }
        }
        public static string FuncCodigo_NombreCol
        {
            get { return MARCACIONES_INFO_COMPLCollection.CODIGOColumnName; }
        }
        public static string EntradasSaildasId_NombreCol
        {
            get { return MARCACIONES_ENTRADAS_SALIDASCollection.IDColumnName; }
        }
        public static string EntradasSaildasTipoMovimiento_NombreCol
        {
            get { return MARCACIONES_ENTRADAS_SALIDASCollection.TIPO_MOVIMIENTOColumnName; }
        }
        public static string EntradasSaildasFecha_NombreCol
        {
            get { return MARCACIONES_ENTRADAS_SALIDASCollection.FECHA_MARCACIONColumnName; }
        }
        #endregion Vista
        #endregion Accessors

    }

}
