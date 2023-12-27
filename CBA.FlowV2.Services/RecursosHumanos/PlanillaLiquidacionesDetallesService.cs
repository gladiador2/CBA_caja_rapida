#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Comercial;
using System.Text;
#endregion Using

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class PlanillaLiquidacionesDetallesService
    {
        #region GetDataTable
        /// <summary>
        /// Gets the detalles planilla.
        /// </summary>
        /// <param name="planilla_id">The planilla_id.</param>
        /// <returns></returns>
        public static DataTable GetDataTable(decimal planilla_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetDataTable(planilla_id, sesion);
            }
        }

        public static DataTable GetDataTable(decimal planilla_id, SessionService sesion)
        {
            return sesion.Db.PLANILLA_LIQ_DET_INFO_COMPLCollection.GetAsDataTable(PlanillaLiquidacionesDetallesService.PlanillaId_NombreCol + "=" + planilla_id, PlanillaLiquidacionesDetallesService.Id_NombreCol);
        }
        #endregion GetDataTable

        #region GetDataTableInfoCompleta
        public static DataTable GetInfoCompleta(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetInfoCompleta(clausula, orden, sesion);
            }
        }

        public static DataTable GetInfoCompleta(string clausula, string orden, SessionService sesion)
        {
            return sesion.Db.PLANILLA_LIQ_DET_INFO_COMPLCollection.GetAsDataTable(clausula, orden);
        }
        #endregion GetDataTableInfoCompleta

        #region ObtenerFuncionariosIncluidos
        public static decimal[,] ObtenerFuncionariosIncluidos(decimal planilla_id)
        {
            using (SessionService sesion = new SessionService())
            {

                PLANILLA_LIQUIDACIONES_DETRow[] rows = sesion.Db.PLANILLA_LIQUIDACIONES_DETCollection.GetByPLANILLA_ID(planilla_id);

                decimal[,] funcionariosId = new decimal[rows.Length, 2];

                for (int i = 0; i < rows.Length; i++)
                {
                    funcionariosId[i, 0] = rows[i].FUNCIONARIO_ID;
                    funcionariosId[i, 1] = rows[i].ID;
                }
                return funcionariosId;
            }
        }
        #endregion ObtenerFuncionariosIncluidos

        #region Borrar
        public static void Borrar(decimal planilla_detalle_id, SessionService sesion)
        {
            try
            {
                sesion.Db.BeginTransaction();
                PLANILLA_LIQUIDACIONES_DETRow row = new PLANILLA_LIQUIDACIONES_DETRow();
                row = sesion.Db.PLANILLA_LIQUIDACIONES_DETCollection.GetByPrimaryKey(planilla_detalle_id);

                //se quita referencia del detalle para poder borrarlo
                decimal liquidacion_id = row.LIQUIDACION_ID;
                row.IsLIQUIDACION_IDNull = true;
                sesion.Db.PLANILLA_LIQUIDACIONES_DETCollection.Update(row);

                //se borra la liquidacion asociada
                (new FuncionariosLiquidacionesService()).Borrar(liquidacion_id, sesion);

                String valorAnterior = row.ToString();
                sesion.Db.PLANILLA_LIQUIDACIONES_DETCollection.DeleteByPrimaryKey(planilla_detalle_id);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);

                (new PlanillaLiquidacionesService()).ActualizarTotal(row.PLANILLA_ID, sesion);
                sesion.Db.CommitTransaction();
            }
            catch (Exception exp)
            {
                sesion.Db.RollbackTransaction();
                throw exp;
            }
        }
        #endregion Borrar

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PLANILLA_LIQUIDACIONES_DETRow row = new PLANILLA_LIQUIDACIONES_DETRow();
                    PLANILLA_LIQUIDACIONESRow planillaRow = new PLANILLA_LIQUIDACIONESRow();
                    String valorAnterior = string.Empty;

                    planillaRow = sesion.Db.PLANILLA_LIQUIDACIONESCollection.GetByPrimaryKey(decimal.Parse(campos[PlanillaLiquidacionesDetallesService.PlanillaId_NombreCol].ToString()));

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("planilla_liquidaciones_det_sqc");
                        row.PLANILLA_ID = decimal.Parse(campos[PlanillaLiquidacionesDetallesService.PlanillaId_NombreCol].ToString());
                        row.FUNCIONARIO_ID = decimal.Parse(campos[PlanillaLiquidacionesDetallesService.FuncionarioId_NombreCol].ToString());
                        row.MONEDA_ID = decimal.Parse(campos[PlanillaLiquidacionesDetallesService.MonedaId_NombreCol].ToString());
                        row.COTIZACION = decimal.Parse(campos[PlanillaLiquidacionesDetallesService.Cotizacion_NombreCol].ToString());

                        switch (int.Parse(campos[PlanillaLiquidacionesService.Tipo_NombreCol].ToString()))
                        {
                            #region Insercion Planilla Salario
                            case Definiciones.TipoLiquidacion.Salario:
                                int tipoSalario = FuncionariosService.GetTipoSalario(row.FUNCIONARIO_ID);
                                switch (tipoSalario)
                                {
                                    case Definiciones.TipoSalario.Mensual:
                                        int dias_mes_1 = DateTime.DaysInMonth(planillaRow.FECHA_DESDE.Year, planillaRow.FECHA_DESDE.Month);
                                        int dias_mes_2 = DateTime.DaysInMonth(planillaRow.FECHA_HASTA.Year, planillaRow.FECHA_HASTA.Month);
                                        if (dias_mes_1 == dias_mes_2)
                                        {
                                            int total_dias_planilla = dias_mes_1;
                                            int total_dias_trabajado = (planillaRow.FECHA_HASTA - planillaRow.FECHA_DESDE).Days + 1;
                                            row.TOTAL_SALARIO = Math.Round((FuncionariosService.GetSalarioBase(row.FUNCIONARIO_ID) + FuncionariosService.GetSalarioComplementario(row.FUNCIONARIO_ID) + FuncionariosService.GetSalarioExtraordinario(row.FUNCIONARIO_ID)) * total_dias_trabajado / total_dias_planilla, MonedasService.CantidadDecimalesStatic(row.MONEDA_ID));
                                        }
                                        else
                                        {
                                            int total_dias_trabajado_mes_1 = (dias_mes_1 - planillaRow.FECHA_DESDE.Day) + 1;
                                            int total_dias_trabajado_mes_2 = planillaRow.FECHA_HASTA.Day;
                                            row.TOTAL_SALARIO = Math.Round(((FuncionariosService.GetSalarioBase(row.FUNCIONARIO_ID) + FuncionariosService.GetSalarioComplementario(row.FUNCIONARIO_ID) + FuncionariosService.GetSalarioExtraordinario(row.FUNCIONARIO_ID)) / dias_mes_1 * total_dias_trabajado_mes_1 ) +
                                                                ((FuncionariosService.GetSalarioBase(row.FUNCIONARIO_ID) + FuncionariosService.GetSalarioComplementario(row.FUNCIONARIO_ID) + FuncionariosService.GetSalarioExtraordinario(row.FUNCIONARIO_ID)) / dias_mes_2 * total_dias_trabajado_mes_2), MonedasService.CantidadDecimalesStatic(row.MONEDA_ID));
                                        }
                                            break;

                                    case Definiciones.TipoSalario.Jornalero:
                                        decimal diasTrabajados = FuncionarioDiasTrabajadosService.GetDiasTrabajados(row.FUNCIONARIO_ID, planillaRow.FECHA_DESDE, planillaRow.FECHA_HASTA);
                                        row.TOTAL_SALARIO = Math.Round(FuncionariosService.GetSalarioBase(row.FUNCIONARIO_ID) * diasTrabajados, MonedasService.CantidadDecimalesStatic(row.MONEDA_ID));
                                        break;

                                    case Definiciones.TipoSalario.Semanal:
                                        decimal weeks = ((planillaRow.FECHA_HASTA - planillaRow.FECHA_DESDE).Days + 1)/ 7;
                                        row.TOTAL_SALARIO = Math.Round(weeks * FuncionariosService.GetSalarioBase(row.FUNCIONARIO_ID), MonedasService.CantidadDecimalesStatic(row.MONEDA_ID));
                                        break;

                                    default:
                                        break;
                                }

                                row.TOTAL_BONIFICACION = 0;
                                row.TOTAL_DESCUENTO = 0;
                                row.TOTAL_A_COBRAR = row.TOTAL_SALARIO + row.TOTAL_BONIFICACION - row.TOTAL_DESCUENTO;
                                break;
                            #endregion Insercion Planilla Salario

                            #region Insercion Planilla de Aguinaldo
                            case Definiciones.TipoLiquidacion.Aguinaldo:
                                /*PASOS A SEGUIR PARA CALCULAR EL AGUINALDO*/
                                decimal bonificaciones = 0;
                                decimal descuentos = 0;
                                decimal totalSalarioBase = 0;

                                /*PASO 1: ACCEDEMOS A PLANILLAS DE SALARIOS GENERADAS POR EL RANGO DE FECHAS DE LA FORM DE PLANILLA DE LIQUIDACIONES Y QUE NO ESTEN ANULADAS*/
                                DataTable dtCabLiquidaciones = PlanillaLiquidacionesService.GetPlanilaLiquidacionesPorRangoDeFechasTipoLiquidacion(DateTime.Parse(campos[PlanillaLiquidacionesService.FechaDesde_NombreCol].ToString()), DateTime.Parse(campos[PlanillaLiquidacionesService.FechaHasta_NombreCol].ToString()), Definiciones.TipoLiquidacion.Salario);
                                foreach (DataRow cabRow in dtCabLiquidaciones.Rows)
                                {
                                    if (cabRow[PlanillaLiquidacionesService.VistaCasoEstado_NombreCol].ToString() != Definiciones.EstadosFlujos.Anulado)
                                    {
                                        /*PASO 2: ACCEDEMOS A LOS DETALLES DE CADA PLANILLA GENEREDA*/
                                        DataTable dtDetLiquidaciones = new DataTable();
                                        dtDetLiquidaciones = GetDataTable(decimal.Parse(cabRow[PlanillaLiquidacionesService.Id_NombreCol].ToString()));
                                        foreach (DataRow detRow in dtDetLiquidaciones.Rows)
                                        {
                                            /*PASO 3: VERIFICAMOS QUE EL FUNCIONARIOS DE LA PLANILLA DETALLES ES EL FUNCIONARIO EL CUAL ESTAMOS GENERANDO EL AGUINALDO*/
                                            if (decimal.Parse(detRow[PlanillaLiquidacionesDetallesService.FuncionarioId_NombreCol].ToString()) == decimal.Parse(campos[PlanillaLiquidacionesDetallesService.FuncionarioId_NombreCol].ToString()))
                                            {
                                                /*PASO 4: ACCEDEMOS !!DIRECTAMENTE!! A LAS LIQUIDACIONES DETALLES DE CADA PLANILLA DETALLE EL CUAL CUMPLA CON LOS PASOS ANTERIOS*/
                                                FUNCIONARIOS_LIQUIDACIONES_DETRow[] rows = sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.GetByFUNCIONARIOS_LIQUIDACIONES_ID(decimal.Parse(detRow[PlanillaLiquidacionesDetallesService.LiquidacionID_NombreCol].ToString()));
                                                for (int i = 0; i < rows.Length; i++)
                                                {
                                                    /*PASO 5: SUMAMOS LAS BONIFICACIONES, DESCUENTOS Y MONTOS MANUALES*/
                                                    #region SumaBonficaciones
                                                    if (rows[i].TIPO_ITEM.Equals(Definiciones.TipoItemLiquidacion.Bonificacion))
                                                    {
                                                        /*PASO 5.1: ACCEDEMOS A LA TABLA FUNCIONARIOS_BONIFICACIONES POR MEDIO DEL DETALLE DE LA LIQUIDACION QUE SEAN ACTIVOS, SI HAY*/
                                                        DataTable dtFuncionarioBonificaciones = FuncionariosBonificacionesService.GetFuncionariosBonificacionesDataTable(FuncionariosBonificacionesService.Id_NombreCol + "=" + rows[i].ITEM_ID, FuncionariosBonificacionesService.Id_NombreCol, true);

                                                        if (dtFuncionarioBonificaciones.Rows.Count > 0)
                                                        {
                                                            /*PASO 5.1.1: GENERAMOS UNA VERIFICACION DE QUE LA BONIFICACION DEL FUNCIONARIO SEA ACTIVA, SI HAY Y ESTE INCLUIDA EN EL AGUINALDO PARA SUMARLA*/
                                                            string clausula = BonificacionesService.Id_NombreCol + "=" + decimal.Parse(dtFuncionarioBonificaciones.Rows[0][FuncionariosBonificacionesService.BonificacionId_NombreCol].ToString())
                                                                                + " and " + BonificacionesService.IncluirAAaguinaldo_NombreCol + "='" + Definiciones.SiNo.Si + "'";

                                                            DataTable dtBonificaciones = BonificacionesService.GetBonificacionesDataTable(clausula, BonificacionesService.Id_NombreCol, true);
                                                            if (dtBonificaciones.Rows.Count > 0)
                                                                bonificaciones += rows[i].MONTO;
                                                        }
                                                    }
                                                    #endregion SumaBonficaciones

                                                    #region SumaDescuentos
                                                    if (rows[i].TIPO_ITEM.Equals(Definiciones.TipoItemLiquidacion.Descuento))
                                                    {
                                                        /*PASO 5.1.2: GENERAMOS UNA VERIFICACION DE QUE EL DESCUENTO DEL FUNCIONARIO SEA ACTIVA, SI HAY Y ESTE INCLUIDA EN EL AGUINALDO PARA SUMARLA*/
                                                        DataTable dtFuncionariosDescuentos = (new FuncionariosDescuentosService()).GetFuncionariosDescuentosDataTable(FuncionariosDescuentosService.Id_NombreCol + "=" + rows[i].ITEM_ID, FuncionariosDescuentosService.Id_NombreCol, true);
                                                        if (dtFuncionariosDescuentos.Rows.Count > 0)
                                                        {
                                                            string clausula = FuncionariosDescuentosService.Id_NombreCol + "=" + decimal.Parse(dtFuncionariosDescuentos.Rows[0][FuncionariosDescuentosService.DescuentoId_NombreCol].ToString())
                                                                              + " and " + DescuentosService.IncluirAAguinaldo_NombreCol + "='" + Definiciones.SiNo.Si + "'";
                                                            DataTable dtDescuentos = DescuentosService.GetDescuentosDataTable(clausula, DescuentosService.Id_NombreCol, true);
                                                            if (dtDescuentos.Rows.Count > 0)
                                                                descuentos += rows[i].MONTO;
                                                        }
                                                    }
                                                    #endregion SumaDescuentos
                                                }
                                                totalSalarioBase += decimal.Parse(detRow[PlanillaLiquidacionesDetallesService.TotalSalario_NombreCol].ToString());
                                            }
                                        }
                                    }
                                }

                                row.TOTAL_SALARIO = totalSalarioBase;
                                row.TOTAL_BONIFICACION = bonificaciones;
                                row.TOTAL_DESCUENTO = descuentos;
                                row.TOTAL_A_COBRAR = (Math.Round(totalSalarioBase + bonificaciones - descuentos) / 12);
                                break;
                            #endregion Insercion Planilla de Aguinaldo

                            #region Insercion Planilla Complementaria
                            case Definiciones.TipoLiquidacion.Complementario:
                                row.TOTAL_SALARIO = 0;
                                row.TOTAL_BONIFICACION = 0;
                                row.TOTAL_DESCUENTO = 0;
                                row.TOTAL_A_COBRAR = 0;
                                break;
                            #endregion Insercion Planilla Complementaria

                            default:
                                throw new Exception("Tipo Planilla no implementada");
                                break;
                        }

                        // Se inserta los detalles de la planilla
                        sesion.Db.PLANILLA_LIQUIDACIONES_DETCollection.Insert(row);

                        // se cargan los datos para crear la liquidacion.
                        System.Collections.Hashtable detalles = new System.Collections.Hashtable();
                        detalles.Add(FuncionariosLiquidacionesService.PlanillaSalarioId_NombreCol, row.PLANILLA_ID);

                        detalles.Add(FuncionariosLiquidacionesService.FuncionarioId_NombreCol, row.FUNCIONARIO_ID);
                        detalles.Add(FuncionariosLiquidacionesService.TotalSalario_NombreCol, row.TOTAL_SALARIO);
                        detalles.Add(FuncionariosLiquidacionesService.TotalBonificaciones_NombreCol, row.TOTAL_BONIFICACION);
                        detalles.Add(FuncionariosLiquidacionesService.TotalDescuento_NombreCol, row.TOTAL_DESCUENTO);
                        detalles.Add(FuncionariosLiquidacionesService.TotalACobrar_NombreCol, row.TOTAL_A_COBRAR);
                        detalles.Add(FuncionariosLiquidacionesService.MonedaId_NombreCol, row.MONEDA_ID);
                        detalles.Add(FuncionariosLiquidacionesService.Cotizacion_NombreCol, row.COTIZACION);
                        detalles.Add(FuncionariosLiquidacionesService.Observacion_NombreCol, string.Empty);

                        //estos son campos que deben ser obtenidos de la cabecera de la planilla
                        detalles.Add(FuncionariosLiquidacionesService.FechaInicio_NombreCol, campos[PlanillaLiquidacionesService.FechaDesde_NombreCol].ToString());
                        detalles.Add(FuncionariosLiquidacionesService.FechaFin_NombreCol, campos[PlanillaLiquidacionesService.FechaHasta_NombreCol].ToString());
                        detalles.Add(PlanillaLiquidacionesService.Tipo_NombreCol, campos[PlanillaLiquidacionesService.Tipo_NombreCol].ToString());

                        row.LIQUIDACION_ID = (new FuncionariosLiquidacionesService()).Guardar(detalles, true, sesion);

                        //Se actualiza detalle con id de la liquidación
                        sesion.db.PLANILLA_LIQUIDACIONES_DETCollection.Update(row);

                        FuncionariosLiquidacionesService.ActualizarTotales(row.LIQUIDACION_ID, sesion);
                    }
                    else
                    {
                        row = sesion.Db.PLANILLA_LIQUIDACIONES_DETCollection.GetByPrimaryKey(decimal.Parse(campos[PlanillaLiquidacionesDetallesService.Id_NombreCol].ToString()));
                    }

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

        #region ActualizarMontos
        /// <summary>
        /// Actualizars the montos.
        /// </summary>
        /// <param name="planilla_det_id">The planilla_det_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarMontos(decimal planilla_det_id, SessionService sesion)
        {
            PLANILLA_LIQUIDACIONES_DETRow planillaDetalleRow = sesion.Db.PLANILLA_LIQUIDACIONES_DETCollection.GetByPrimaryKey(planilla_det_id);
            FUNCIONARIOS_LIQUIDACIONESRow liquidacionRow = sesion.Db.FUNCIONARIOS_LIQUIDACIONESCollection.GetByPrimaryKey(planillaDetalleRow.LIQUIDACION_ID);

            planillaDetalleRow.TOTAL_SALARIO = liquidacionRow.TOTAL_SALARIO;
            planillaDetalleRow.TOTAL_BONIFICACION = liquidacionRow.TOTAL_BONIFICACIONES;
            planillaDetalleRow.TOTAL_DESCUENTO = liquidacionRow.TOTAL_DESCUENTO;
            planillaDetalleRow.TOTAL_A_COBRAR = liquidacionRow.TOTAL_COBRAR;
            planillaDetalleRow.TOTAL_APORTES_EMPRESA = liquidacionRow.TOTAL_APORTES_EMPRESA;

            sesion.Db.PLANILLA_LIQUIDACIONES_DETCollection.Update(planillaDetalleRow);

            (new PlanillaLiquidacionesService()).ActualizarTotal(planillaDetalleRow.PLANILLA_ID, sesion);
        }

        public void ActualizarMontosPorLiquidacionId(decimal liquidacion_id, SessionService sesion)
        {
            PLANILLA_LIQUIDACIONES_DETRow[] planillaDetalleRow = sesion.Db.PLANILLA_LIQUIDACIONES_DETCollection.GetByLIQUIDACION_ID(liquidacion_id);
            FUNCIONARIOS_LIQUIDACIONESRow liquidacionRow = sesion.Db.FUNCIONARIOS_LIQUIDACIONESCollection.GetByPrimaryKey(liquidacion_id);

            for (int i = 0; i < planillaDetalleRow.Length; i++)
            {
                planillaDetalleRow[i].TOTAL_SALARIO = liquidacionRow.TOTAL_SALARIO;
                planillaDetalleRow[i].TOTAL_BONIFICACION = liquidacionRow.TOTAL_BONIFICACIONES;
                planillaDetalleRow[i].TOTAL_DESCUENTO = liquidacionRow.TOTAL_DESCUENTO;
                planillaDetalleRow[i].TOTAL_A_COBRAR = liquidacionRow.TOTAL_COBRAR;
                planillaDetalleRow[i].TOTAL_APORTES_EMPRESA = liquidacionRow.TOTAL_APORTES_EMPRESA;
                sesion.Db.PLANILLA_LIQUIDACIONES_DETCollection.Update(planillaDetalleRow[i]);
                (new PlanillaLiquidacionesService()).ActualizarTotal(planillaDetalleRow[i].PLANILLA_ID, sesion);
            }
        }
        #endregion ActualizarMontos

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "PLANILLA_LIQUIDACIONES_DET"; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONES_DETCollection.COTIZACIONColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONES_DETCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string LiquidacionID_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONES_DETCollection.LIQUIDACION_IDColumnName; }
        }
        public static string PlanillaId_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONES_DETCollection.PLANILLA_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONES_DETCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONES_DETCollection.MONEDA_IDColumnName; }
        }
        public static string TotalAportesEmpresa_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONES_DETCollection.TOTAL_APORTES_EMPRESAColumnName; }
        }
        public static string TotalSalario_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONES_DETCollection.TOTAL_SALARIOColumnName; }
        }
        public static string TotalDescuento_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONES_DETCollection.TOTAL_DESCUENTOColumnName; }
        }
        public static string TotalBonificacion_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONES_DETCollection.TOTAL_BONIFICACIONColumnName; }
        }
        public static string TotalACobrar_NombreCol
        {
            get { return PLANILLA_LIQUIDACIONES_DETCollection.TOTAL_A_COBRARColumnName; }
        }

        #endregion Tabla

        #region Vista
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return PLANILLA_LIQ_DET_INFO_COMPLCollection.FUNCIONARIOS_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return PLANILLA_LIQ_DET_INFO_COMPLCollection.MONEDAS_NOMBRESColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return PLANILLA_LIQ_DET_INFO_COMPLCollection.MONEDAS_SIMBOLOColumnName; }
        }

        #endregion Vista
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static PlanillaLiquidacionesDetallesService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new PlanillaLiquidacionesDetallesService(e.RegistroId, sesion);
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
        protected PLANILLA_LIQUIDACIONES_DETRow row;
        protected PLANILLA_LIQUIDACIONES_DETRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal Cotizacion { get { return row.COTIZACION; } set { row.COTIZACION = value; } }
        public decimal FuncionarioId { get { return row.FUNCIONARIO_ID; } set { row.FUNCIONARIO_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal LiquidacionId { get { return row.LIQUIDACION_ID; } set { row.LIQUIDACION_ID = value; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal PlanillaId { get { return row.PLANILLA_ID; } set { row.PLANILLA_ID = value; } }
        public decimal TotalACobrar { get { return row.TOTAL_A_COBRAR; } set { row.TOTAL_A_COBRAR = value; } }
        public decimal TotalAporteEmpresa { get { return row.TOTAL_APORTES_EMPRESA; } set { row.TOTAL_APORTES_EMPRESA = value; } }
        public decimal TotalBonificacion { get { return row.TOTAL_BONIFICACION; } set { row.TOTAL_BONIFICACION = value; } }
        public decimal TotalDescuento { get { return row.TOTAL_DESCUENTO ; } set { row.TOTAL_DESCUENTO = value; } }
        public decimal TotalSalario { get { return row.TOTAL_SALARIO; } set { row.TOTAL_SALARIO = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private FuncionariosService _funcionario;
        public FuncionariosService Funcionario
        {
            get
            {
                if (this._funcionario == null)
                    this._funcionario = new FuncionariosService(this.FuncionarioId);
                return this._funcionario;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                    this._moneda = new MonedasService(this.MonedaId);
                return this._moneda;
            }
        }
        
        private PlanillaLiquidacionesService _planilla_liquidacion;
        public PlanillaLiquidacionesService PlanillaLiquidacion
        {
            get
            {
                if (this._planilla_liquidacion == null)
                    this._planilla_liquidacion = new PlanillaLiquidacionesService(this.PlanillaId);
                return this._planilla_liquidacion;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.PLANILLA_LIQUIDACIONES_DETCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new PLANILLA_LIQUIDACIONES_DETRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(PLANILLA_LIQUIDACIONES_DETRow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public PlanillaLiquidacionesDetallesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public PlanillaLiquidacionesDetallesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public PlanillaLiquidacionesDetallesService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public PlanillaLiquidacionesDetallesService(EdiCBA.PlanillaLiquidacionDetalle edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = PlanillaLiquidacionesDetallesService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion);

            #region funcionario
            if (!string.IsNullOrEmpty(edi.funcionario_uuid))
                this._funcionario = FuncionariosService.GetPorUUID(edi.funcionario_uuid, sesion);
            if (this._funcionario == null && edi.funcionario != null)
                this._funcionario = new FuncionariosService(edi.funcionario, almacenar_localmente, sesion);
            if (this._funcionario == null)
                throw new Exception("No se encontró el UUID " + edi.funcionario_uuid + " ni se definieron los datos del objeto.");

            if (!this.Funcionario.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Funcionario.Id.HasValue)
                this.FuncionarioId = this.Funcionario.Id.Value;
            #endregion funcionario

            if (edi.cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion'.");
            this.Cotizacion = edi.cotizacion.compra;

            #region moneda
            if (!string.IsNullOrEmpty(edi.moneda_uuid))
                this._moneda = MonedasService.GetPorUUID(edi.moneda_uuid, sesion);
         
            if (this._moneda == null)
                throw new Exception("No se encontró el UUID " + edi.moneda_uuid + " ni se definieron los datos del objeto.");
            #endregion moneda

            #region planilla liquidacion
            if (!string.IsNullOrEmpty(edi.planilla_liquidacion_uuid))
                this._planilla_liquidacion = PlanillaLiquidacionesService.GetPorUUID(edi.planilla_liquidacion_uuid, sesion);
            if (this._planilla_liquidacion == null && edi.planilla_liquidacion != null)
                this._planilla_liquidacion = new PlanillaLiquidacionesService(edi.planilla_liquidacion, almacenar_localmente, sesion);
            if (this._planilla_liquidacion != null)
            {
                if (!this.PlanillaLiquidacion.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.PlanillaLiquidacion.Id.HasValue)
                    this.PlanillaId = this.PlanillaLiquidacion.Id.Value;
            }
            #endregion planilla liquidacion

            this.TotalACobrar = edi.total_a_cobrar;
            this.TotalAporteEmpresa = edi.total_aporte_empresa;
            this.TotalBonificacion = edi.total_bonificacion;
            this.TotalDescuento = edi.total_descuento;
            this.TotalSalario = edi.total_salario;
        }
        private PlanillaLiquidacionesDetallesService(PLANILLA_LIQUIDACIONES_DETRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCabecera
        public static PlanillaLiquidacionesDetallesService[] GetPorCabecera(decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCabecera(cabecera_id, sesion);
            }
        }

        public static PlanillaLiquidacionesDetallesService[] GetPorCabecera(decimal cabecera_id, SessionService sesion)
        {
            var rows = sesion.db.PLANILLA_LIQUIDACIONES_DETCollection.GetAsArray(PlanillaLiquidacionesDetallesService.PlanillaId_NombreCol + " = " + cabecera_id, PlanillaLiquidacionesDetallesService.Id_NombreCol);
            PlanillaLiquidacionesDetallesService[] pld = new PlanillaLiquidacionesDetallesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                pld[i] = new PlanillaLiquidacionesDetallesService(rows[i]);
            return pld;
        }
        #endregion GetPorCabecera
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
