using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
using System.Collections;
using System.Windows.Forms;
using System.Text;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class FuncionariosLiquidacionesService
    {
        #region Borrar
        public void Borrar(decimal liquidacion_id, SessionService sesion)
        {
            try
            {
                FUNCIONARIOS_LIQUIDACIONESRow row = new FUNCIONARIOS_LIQUIDACIONESRow();
                row = sesion.Db.FUNCIONARIOS_LIQUIDACIONESCollection.GetByPrimaryKey(liquidacion_id);
                String valorAnterior = row.ToString();
                (new FuncionariosLiquidacionesDetallesService()).BorrarDetallesPorLiquidacion(liquidacion_id, sesion);
                sesion.Db.FUNCIONARIOS_LIQUIDACIONESCollection.DeleteByPrimaryKey(liquidacion_id);
                // LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Borrar

        #region VerificarValidezDePeriodo
        /// <summary>
        /// Verificars the validez de periodo.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <param name="inicio">The inicio.</param>
        /// <param name="fin">The fin.</param>
        /// <returns></returns>
        public string VerificarValidezDePeriodo(decimal funcionario_id, DateTime inicio, DateTime fin, int tipoDePlanillaGenerada, decimal planilla_id, decimal moneda_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string mensaje = string.Empty;

                string clausula = FuncionarioId_NombreCol + " = " + funcionario_id + " and " +
                                  PlanillaSalarioId_NombreCol + " <> " + planilla_id + " and " +
                                  PlanillaSalarioId_NombreCol + " in (select " + PlanillaLiquidacionesService.Id_NombreCol + 
                                                                      " from " + PlanillaLiquidacionesService.Nombre_Tabla + 
                                                                     " where " + PlanillaLiquidacionesService.Tipo_NombreCol + " = " + tipoDePlanillaGenerada + ") and " +
                                  MonedaId_NombreCol + " = " + moneda_id;

                FUNCIONARIOS_LIQUIDACIONESRow[] liq_existentes = sesion.Db.FUNCIONARIOS_LIQUIDACIONESCollection.GetAsArray(clausula, string.Empty);
 
                for (int i = 0; i < liq_existentes.Length; i++)
                {
                    switch (tipoDePlanillaGenerada)
                    {
                        #region Salario
                        case Definiciones.TipoLiquidacion.Salario:
                            // determinar que el periodo a crear esté dentro del rango de una planilla existente
                            // o por lo menos el inicio o el fin pertenezcan al rango de una planilla existente
                            if (((inicio >= liq_existentes[i].FECHA_INICIO) && (inicio <= liq_existentes[i].FECHA_FIN)) ||
                                ((fin >= liq_existentes[i].FECHA_INICIO) && (fin <= liq_existentes[i].FECHA_FIN)))
                            {
                                string funcionario_nombre = FuncionariosService.GetNombre(funcionario_id);
                                DataTable dtPlanilla = PlanillaLiquidacionesService.GetPlanilaLiquidacionesDataTable(PlanillaLiquidacionesService.Id_NombreCol + " = " + liq_existentes[i].PLANILLA_SALARIO_ID, string.Empty);
                                return "El funcionario: " + funcionario_nombre + " ya tiene una liquidación " + Traducciones.Caso + " Nº " + dtPlanilla.Rows[0][PlanillaLiquidacionesService.CasoId_NombreCol] + " para dicho periodo.";
                            }
                            //determinar que el lo creado esté dentro del rango de la planilla a crear 
                            else if (((liq_existentes[i].FECHA_INICIO >= inicio) && (liq_existentes[i].FECHA_INICIO <= fin)) &&
                                     ((liq_existentes[i].FECHA_FIN >= inicio) && (liq_existentes[i].FECHA_FIN <= fin)))
                            {
                                string funcionario_nombre = FuncionariosService.GetNombre(funcionario_id);
                                DataTable dtPlanilla = PlanillaLiquidacionesService.GetPlanilaLiquidacionesDataTable(PlanillaLiquidacionesService.Id_NombreCol + " = " + liq_existentes[i].PLANILLA_SALARIO_ID, string.Empty);
                                return "El funcionario: " + funcionario_nombre + " ya tiene una liquidación " + Traducciones.Caso + " Nº " + dtPlanilla.Rows[0][PlanillaLiquidacionesService.CasoId_NombreCol] + " dentro del periodo.";
                                
                            }
                            break;
                        #endregion Salario

                        #region Aguinaldo
                        case Definiciones.TipoLiquidacion.Aguinaldo:
                            if (inicio == liq_existentes[i].FECHA_INICIO && (fin <= liq_existentes[i].FECHA_FIN || fin > liq_existentes[i].FECHA_FIN))
                            {
                                DataTable dtPlanilla = PlanillaLiquidacionesService.GetPlanilaLiquidacionesDataTable(PlanillaLiquidacionesService.Id_NombreCol + " = " + liq_existentes[i].PLANILLA_SALARIO_ID, string.Empty);
                                return mensaje = "Ya existe liquidacion para el funcionario. Liquidación " + Traducciones.Caso + " Nº: " + dtPlanilla.Rows[0][PlanillaLiquidacionesService.CasoId_NombreCol];
                            }
                            else
                            {
                                if ((inicio > liq_existentes[i].FECHA_INICIO && inicio < liq_existentes[i].FECHA_FIN) && (fin <= liq_existentes[i].FECHA_FIN || fin > liq_existentes[i].FECHA_FIN))
                                {
                                    DataTable dtPlanilla = PlanillaLiquidacionesService.GetPlanilaLiquidacionesDataTable(PlanillaLiquidacionesService.Id_NombreCol + " = " + liq_existentes[i].PLANILLA_SALARIO_ID, string.Empty);
                                    return mensaje = "Ya existe liquidacion para el funcionario. Liquidación " + Traducciones.Caso + " Nº: " + dtPlanilla.Rows[0][PlanillaLiquidacionesService.CasoId_NombreCol];
                                }
                                else
                                {
                                    if (inicio < liq_existentes[i].FECHA_INICIO && (fin <= liq_existentes[i].FECHA_FIN || fin > liq_existentes[i].FECHA_FIN))
                                    {
                                        DataTable dtPlanilla = PlanillaLiquidacionesService.GetPlanilaLiquidacionesDataTable(PlanillaLiquidacionesService.Id_NombreCol + " = " + liq_existentes[i].PLANILLA_SALARIO_ID, string.Empty);
                                        return mensaje = "Ya existe liquidacion para el funcionario. Liquidación " + Traducciones.Caso + " Nº: " + dtPlanilla.Rows[0][PlanillaLiquidacionesService.CasoId_NombreCol];
                                    }
                                }
                            }
                            break;
                        #endregion Aguinaldo

                        #region Complementario
                        case Definiciones.TipoLiquidacion.Complementario:
                            //sin control de fechas
                            break;
                        #endregion Complementario

                        default:
                            throw new Exception("Tipo de planilla no implementada.");
                            break;
                    }
                }
                return mensaje;
            }
        }
        #endregion VerificarValidezDePeriodo

        #region GetLiquidacionesDataTable
        /// <summary>
        /// Gets the liquidaciones data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <returns></returns>
        public DataTable GetLiquidacionesDataTable(string clausula) 
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FUNCIONARIOS_LIQUIDACIONESCollection.GetAsDataTable(clausula, string.Empty);
            }
        }

        public static DataTable GetLiquidacionesStaticDataTable(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetLiquidacionesStaticDataTable(clausula, sesion);
            }
        }

        public static DataTable GetLiquidacionesStaticDataTable(string clausula, SessionService sesion)
        {
            return sesion.Db.FUNCIONARIOS_LIQUIDACIONESCollection.GetAsDataTable(clausula, string.Empty);
        }
        #endregion GetLiquidacionesDataTable

        #region GetLiquidacionesInfoCompletaDataTable
        public static DataTable GetLiquidacionesInfoCompletaDataTable2(string clausula, string order)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetLiquidacionesInfoCompletaDataTable2(clausula, order, sesion);
            }
        }
        public static DataTable GetLiquidacionesInfoCompletaDataTable2(string clausula, string order, SessionService sesion)
        {
            return sesion.Db.FUNCIONARIOS_LIQ_INFO_COMPCollection.GetAsDataTable(clausula, order);
        }
        #endregion GetLiquidacionesInfoCompletaDataTable

        #region ActualizarCampos()
        /// <summary>
        /// Actualizar los campos usando NULL si se quiere desasignar alguno.
        /// </summary>
        /// <param name="campos">The campos.</param>
        public void ActualizarCampos(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    DataTable dt = GetLiquidacionesDataTable(FuncionariosLiquidacionesService.Id_NombreCol + " = " + campos[FuncionariosLiquidacionesService.Id_NombreCol]);
                    System.Collections.Hashtable camposNuevos = new System.Collections.Hashtable();

                    for (int i = 0; i < dt.Columns.Count; i++)
                    { 
                        if(!Interprete.EsNullODBNull(dt.Rows[0][i]))
                            camposNuevos.Add(dt.Columns[i].ColumnName, dt.Rows[0][i]);
                    }

                    foreach (DictionaryEntry entry in campos)
                    {
                        if (entry.Value != null)
                        {
                            if (camposNuevos.Contains(entry.Key))
                                camposNuevos[entry.Key] = entry.Value;
                            else
                                camposNuevos.Add(entry.Key, entry.Value);
                        }
                        else
                        {
                            if (camposNuevos.Contains(entry.Key))
                                camposNuevos.Remove(entry.Key);
                        }
                    }

                    Guardar(camposNuevos, false, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception)
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion ActualizarCampos()

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                FUNCIONARIOS_LIQUIDACIONESRow row = new FUNCIONARIOS_LIQUIDACIONESRow();
                String valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("funcionarios_liquidaciones_sqc");
                    row.USUARIO_ID = sesion.Usuario_Id;
                    row.FECHA_CREACION = DateTime.Now;
                    row.PLANILLA_SALARIO_ID = decimal.Parse(campos[FuncionariosLiquidacionesService.PlanillaSalarioId_NombreCol].ToString());
                }
                else
                {
                    row = sesion.Db.FUNCIONARIOS_LIQUIDACIONESCollection.GetByPrimaryKey(decimal.Parse(campos[FuncionariosLiquidacionesService.Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }

                row.FUNCIONARIO_ID = decimal.Parse(campos[FuncionariosLiquidacionesService.FuncionarioId_NombreCol].ToString());
                row.FECHA_INICIO = DateTime.Parse(campos[FuncionariosLiquidacionesService.FechaInicio_NombreCol].ToString());
                row.FECHA_FIN = DateTime.Parse(campos[FuncionariosLiquidacionesService.FechaFin_NombreCol].ToString());
                row.TIPO = (decimal)FuncionariosService.GetTipoSalario(row.FUNCIONARIO_ID);
                row.TOTAL_SALARIO = decimal.Parse(campos[FuncionariosLiquidacionesService.TotalSalario_NombreCol].ToString());
                row.TOTAL_BONIFICACIONES = decimal.Parse(campos[FuncionariosLiquidacionesService.TotalBonificaciones_NombreCol].ToString());
                row.TOTAL_DESCUENTO = decimal.Parse(campos[FuncionariosLiquidacionesService.TotalDescuento_NombreCol].ToString());
                row.TOTAL_COBRAR = decimal.Parse(campos[FuncionariosLiquidacionesService.TotalACobrar_NombreCol].ToString());
                row.COTIZACION = decimal.Parse(campos[FuncionariosLiquidacionesService.Cotizacion_NombreCol].ToString());
                row.MONEDA_ID = decimal.Parse(campos[FuncionariosLiquidacionesService.MonedaId_NombreCol].ToString());
                if (campos.Contains(FuncionariosLiquidacionesService.DiasTrabajados_NombreCol)
                    && !campos[FuncionariosLiquidacionesService.DiasTrabajados_NombreCol].Equals(string.Empty))
                    row.DIAS_TRABAJADOS = decimal.Parse(campos[FuncionariosLiquidacionesService.DiasTrabajados_NombreCol].ToString());
                else
                    row.IsDIAS_TRABAJADOSNull = true;

                if (Interprete.EsNullODBNull(campos[FuncionariosLiquidacionesService.Observacion_NombreCol]))
                    row.OBSERVACION = string.Empty;
                else
                    row.OBSERVACION = campos[FuncionariosLiquidacionesService.Observacion_NombreCol].ToString();

                if (campos.Contains(FuncionariosLiquidacionesService.CasoAsociadoId_NombreCol))
                {
                    DataTable dtCaso, dtFuncionario, dtProveedor;

                    row.CASO_ASOCIADO_ID = (decimal)campos[FuncionariosLiquidacionesService.CasoAsociadoId_NombreCol];

                    #region validaciones de caso asociado
                    //El caso asociado debe ser una FC de proveedor en estado Aprobado del mismo proveedor
                    dtCaso = CasosService.GetCasosDataTable(CasosService.Id_NombreCol + " = " + row.CASO_ASOCIADO_ID, string.Empty, sesion);
                    if (dtCaso.Rows.Count <= 0)
                        throw new Exception("No se encontró el caso asociado indicacdo");

                    if ((string)dtCaso.Rows[0][CasosService.EstadoId_NombreCol] != Definiciones.EstadosFlujos.Aprobado)
                        throw new Exception("El caso asociado debe estar en estado APROBADO y está en " + dtCaso.Rows[0][CasosService.EstadoId_NombreCol] + ".");

                    if (Interprete.EsNullODBNull(dtCaso.Rows[0][CasosService.ProveedorId_NombreCol]))
                        throw new Exception("El caso asociado no tiene un proveedor asociado");

                    dtProveedor = ProveedoresService.GetProveedoresDataTable2(ProveedoresService.Id_NombreCol + " = " + dtCaso.Rows[0][CasosService.ProveedorId_NombreCol], string.Empty, true);
                    dtFuncionario = FuncionariosService.GetFuncionariosDataTable2(FuncionariosService.Id_NombreCol + " = " + row.FUNCIONARIO_ID, string.Empty, true);

                    if (Interprete.EsNullODBNull(dtProveedor.Rows[0][ProveedoresService.PersonaId_NombreCol]))
                        throw new Exception("El proveedor del caso asociado y el funcionario deben ser la misma persona.");

                    if ((decimal)dtProveedor.Rows[0][ProveedoresService.PersonaId_NombreCol] != (decimal)dtFuncionario.Rows[0][FuncionariosService.Persona_IdNombreCol])
                        throw new Exception("El proveedor del caso asociado y el funcionario deben ser la misma persona.");
                    #endregion validaciones de caso asociado
                }
                else
                {
                    row.IsCASO_ASOCIADO_IDNull = true;
                }

                if (insertarNuevo)
                {
                    sesion.Db.FUNCIONARIOS_LIQUIDACIONESCollection.Insert(row);

                    switch (int.Parse(campos[PlanillaLiquidacionesService.Tipo_NombreCol].ToString()))
                    {
                        case Definiciones.TipoLiquidacion.Salario:
                            (new FuncionariosLiquidacionesDetallesService()).GenerarDetalleLiquidacionesSalarial(row.FUNCIONARIO_ID, row.ID, row.MONEDA_ID, sesion);
                            break;

                        case Definiciones.TipoLiquidacion.Complementario:
                            (new FuncionariosLiquidacionesDetallesService()).GenerarDetalleLiquidacionesComplementaria(row.FUNCIONARIO_ID, row.ID, row.MONEDA_ID, sesion);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    sesion.Db.FUNCIONARIOS_LIQUIDACIONESCollection.Update(row);
                }

                LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);
                return row.ID;
            }
            catch (OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                        throw new System.ArgumentException("Ya existe un registro con ese nombre.");
                    default: throw exp;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Guardar

        #region ActualizarTotales
        /// <summary>
        /// Actualizars the totales.
        /// </summary>
        /// <param name="bonificaciones">The bonificaciones.</param>
        /// <param name="descuentos">The descuentos.</param>
        /// <param name="liquidacion_id">The liquidacion_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarTotales(decimal liquidacion_id, SessionService sesion)
        {
            #region Contadores
            FUNCIONARIOS_LIQUIDACIONES_DETRow[] fun_liq_det = sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.GetByFUNCIONARIOS_LIQUIDACIONES_ID(liquidacion_id);
            decimal bonificaciones = 0;
            decimal descuentos = 0;
            decimal montoManual = 0;

            for (int i = 0; i < fun_liq_det.Length; i++)
            {
                if (fun_liq_det[i].TIPO_ITEM.Equals(Definiciones.TipoItemLiquidacion.Bonificacion))
                {
                    bonificaciones += fun_liq_det[i].MONTO;
                }
                else if (fun_liq_det[i].TIPO_ITEM.Equals(Definiciones.TipoItemLiquidacion.Descuento))
                {
                    descuentos += fun_liq_det[i].MONTO;
                }
                else if (fun_liq_det[i].TIPO_ITEM.Equals(Definiciones.TipoItemLiquidacion.CtaCte))
                {
                    descuentos += fun_liq_det[i].MONTO;
                }
                else if (fun_liq_det[i].TIPO_ITEM.Equals(Definiciones.TipoItemLiquidacion.MontoManual))
                {
                    montoManual += fun_liq_det[i].MONTO;
                }
            }
            #endregion Contadores

            FUNCIONARIOS_LIQUIDACIONESRow row = sesion.Db.FUNCIONARIOS_LIQUIDACIONESCollection.GetByPrimaryKey(liquidacion_id);
            DataTable rowPlanillaDet = PlanillaLiquidacionesDetallesService.GetInfoCompleta(PlanillaLiquidacionesDetallesService.LiquidacionID_NombreCol + "=" + liquidacion_id, PlanillaLiquidacionesDetallesService.Id_NombreCol, sesion);

            if (rowPlanillaDet.Rows.Count > 0)
            {
                DataTable rowPlanilla = PlanillaLiquidacionesService.GetPlanilaLiquidacionesDataTable(PlanillaLiquidacionesService.Id_NombreCol + "=" + rowPlanillaDet.Rows[0][PlanillaLiquidacionesDetallesService.PlanillaId_NombreCol], PlanillaLiquidacionesService.Id_NombreCol);

                switch (int.Parse(rowPlanilla.Rows[0][PlanillaLiquidacionesService.Tipo_NombreCol].ToString()))
                {
                    #region Calculo Salario
                    case Definiciones.TipoLiquidacion.Salario:
                        row.TOTAL_BONIFICACIONES = bonificaciones;
                        row.TOTAL_DESCUENTO = descuentos;
                        row.TOTAL_COBRAR = row.TOTAL_SALARIO + row.TOTAL_BONIFICACIONES - row.TOTAL_DESCUENTO;
                        row.TOTAL_APORTES_EMPRESA = 0;

                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RrhhDescuentoCobroIPS) == Definiciones.SiNo.Si)
                        {
                            int total_dias_planilla = DateTime.DaysInMonth(row.FECHA_INICIO.Year, row.FECHA_INICIO.Month);
                            int total_dias_trabajado = (row.FECHA_FIN - row.FECHA_INICIO).Days + 1;
                            //El salario se calcula en base al rango de fechas que se incluye en la planilla.
                            //Por lo tanto, no es cierto que el salario básico complenetario y extra pueden variar y no ser lo que figure en la ficha.
                            if (FuncionariosService.AplicarDescuentoBasico(row.FUNCIONARIO_ID))
                                row.TOTAL_APORTES_EMPRESA += FuncionariosService.GetSalarioBase(row.FUNCIONARIO_ID) * total_dias_trabajado / total_dias_planilla;
                            if (FuncionariosService.AplicarDescuentoComplementario(row.FUNCIONARIO_ID))
                                row.TOTAL_APORTES_EMPRESA += FuncionariosService.GetSalarioComplementario(row.FUNCIONARIO_ID) * total_dias_trabajado / total_dias_planilla;
                            if (FuncionariosService.AplicarDescuentoExtra(row.FUNCIONARIO_ID))
                                row.TOTAL_APORTES_EMPRESA += FuncionariosService.GetSalarioExtraordinario(row.FUNCIONARIO_ID) * total_dias_trabajado / total_dias_planilla;

                            DataTable dtFuncionarioLiquidacionesDet = FuncionariosLiquidacionesDetallesService.GetLiquidacionesDetallesDataTable(FuncionariosLiquidacionesDetallesService.FuncionariosLiquidacionesId_NombreCol + " = " + liquidacion_id, sesion);
                            for (int i = 0; i < dtFuncionarioLiquidacionesDet.Rows.Count; i++)
                            {
                                if ((decimal)dtFuncionarioLiquidacionesDet.Rows[i][FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol] == Definiciones.TipoItemLiquidacion.Bonificacion)
                                {
                                    DataTable dtFuncionarioBonificacion = FuncionariosBonificacionesService.GetFuncionariosBonificacionesDataTable(FuncionariosBonificacionesService.Id_NombreCol + " = " + dtFuncionarioLiquidacionesDet.Rows[i][FuncionariosLiquidacionesDetallesService.ItemId_NombreCol], string.Empty);
                                    if (BonificacionesService.AplicarDescuento((decimal)dtFuncionarioBonificacion.Rows[0][FuncionariosBonificacionesService.BonificacionId_NombreCol], sesion))
                                    {
                                        row.TOTAL_APORTES_EMPRESA += (decimal)dtFuncionarioLiquidacionesDet.Rows[i][FuncionariosLiquidacionesDetallesService.Monto_NombreCol];
                                    }
                                }
                            }

                            decimal porcentajeAporteEmpresa = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FuncionariosLiquidacionesAportesEmpresaPorcentaje);
                            row.TOTAL_APORTES_EMPRESA = Math.Round(row.TOTAL_APORTES_EMPRESA * porcentajeAporteEmpresa / 100, MonedasService.CantidadDecimalesStatic(row.MONEDA_ID, sesion));
                        }
                        break;
                    #endregion Calculo Salario

                    #region Calculo Aguinaldo
                    case Definiciones.TipoLiquidacion.Aguinaldo:
                        decimal totalSalarioBase = 0;
                        bonificaciones = 0;
                        descuentos = 0;

                        DataTable dtCabLiquidaciones = PlanillaLiquidacionesService.GetPlanilaLiquidacionesPorRangoDeFechasTipoLiquidacion(DateTime.Parse(row.FECHA_INICIO.ToString()), DateTime.Parse(row.FECHA_FIN.ToString()), Definiciones.TipoLiquidacion.Salario);
                        foreach (DataRow cabRow in dtCabLiquidaciones.Rows)
                        {
                            if (cabRow[PlanillaLiquidacionesService.VistaCasoEstado_NombreCol].ToString() != Definiciones.EstadosFlujos.Anulado)
                            {
                                DataTable dtDetLiquidaciones = new DataTable();
                                //accede a cada planilla extraida en dtCabLiquidaciones filtrada por rango de fechas.
                                dtDetLiquidaciones = PlanillaLiquidacionesDetallesService.GetDataTable(decimal.Parse(cabRow[PlanillaLiquidacionesService.Id_NombreCol].ToString()));
                                foreach (DataRow detRow in dtDetLiquidaciones.Rows)
                                {
                                    if (decimal.Parse(detRow[PlanillaLiquidacionesDetallesService.FuncionarioId_NombreCol].ToString()) == decimal.Parse(row.FUNCIONARIO_ID.ToString()))
                                    {
                                        FUNCIONARIOS_LIQUIDACIONES_DETRow[] rows = sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.GetByFUNCIONARIOS_LIQUIDACIONES_ID(decimal.Parse(detRow[PlanillaLiquidacionesDetallesService.LiquidacionID_NombreCol].ToString()));
                                        for (int i = 0; i < rows.Length; i++)
                                        {
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
                                            #endregion

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
                                            #endregion
                                        }
                                        totalSalarioBase += decimal.Parse(detRow[PlanillaLiquidacionesDetallesService.TotalSalario_NombreCol].ToString());
                                    }
                                }
                            }
                        }
                        row.TOTAL_COBRAR = Math.Round((totalSalarioBase + bonificaciones - descuentos) / 12) + montoManual;
                        break;
                    #endregion Calculo Aguinaldo

                    #region Calculo Complementario
                    case Definiciones.TipoLiquidacion.Complementario:

                        row.TOTAL_BONIFICACIONES = bonificaciones;
                        row.TOTAL_DESCUENTO = descuentos;
                        row.TOTAL_COBRAR = row.TOTAL_SALARIO + row.TOTAL_BONIFICACIONES - row.TOTAL_DESCUENTO;

                        break;
                    #endregion Calculo Complementario
                }
            }

            sesion.Db.FUNCIONARIOS_LIQUIDACIONESCollection.Update(row);
            (new PlanillaLiquidacionesDetallesService()).ActualizarMontosPorLiquidacionId(row.ID, sesion);
        }
        #endregion ActualizarTotales

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "FUNCIONARIOS_LIQUIDACIONES"; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.COTIZACIONColumnName; }
        }
        public static string CasoAsociadoId_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.CASO_ASOCIADO_IDColumnName; }
        }
        public static string DiasTrabajados_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.DIAS_TRABAJADOSColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.FECHA_CREACIONColumnName; }
        }
        public static string FechaFin_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.FECHA_FINColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.FECHA_INICIOColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.MONEDA_IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.OBSERVACIONColumnName; }
        }
        public static string TotalAportesEmpresa_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.TOTAL_APORTES_EMPRESAColumnName; }
        }
        public static string TipoSalario_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.TIPOColumnName; }
        }
        public static string TotalBonificaciones_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.TOTAL_BONIFICACIONESColumnName; }
        }
        public static string TotalACobrar_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.TOTAL_COBRARColumnName; }
        }
        public static string TotalDescuento_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.TOTAL_DESCUENTOColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.USUARIO_IDColumnName; }
        }
        public static string TotalSalario_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.TOTAL_SALARIOColumnName; }
        }
        public static string PlanillaSalarioId_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONESCollection.PLANILLA_SALARIO_IDColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string VistaCasoAsociadoNroComprobante_NombreCol
        {
            get { return FUNCIONARIOS_LIQ_INFO_COMPCollection.CASO_ASOCIADO_NRO_COMPROBANTEColumnName; }
        }
        public static string VistaFuncionarioNombreCompleto_NombreCol
        {
            get { return FUNCIONARIOS_LIQ_INFO_COMPCollection.FUNCIONARIO_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaOrdenPagoId_NombreCol
        {
            get { return FUNCIONARIOS_LIQ_INFO_COMPCollection.ORDEN_PAGO_IDColumnName; }
        }
        public static string VistaOrdenCasoId_NombreCol
        {
            get { return FUNCIONARIOS_LIQ_INFO_COMPCollection.ORDEN_PAGO_CASO_IDColumnName; }
        }
        public static string VistaOrdenCasoEstadoId_NombreCol
        {
            get { return FUNCIONARIOS_LIQ_INFO_COMPCollection.ORDEN_PAGO_CASO_ESTADOColumnName; }
        }
        public static string VistaPlanillaSalarioDetalleId_NonmbreCol
        {
            get { return FUNCIONARIOS_LIQ_INFO_COMPCollection.PLANILLA_SALARIO_DET_IDColumnName;  }        
        }
        #endregion Vista
        #endregion Accessors
    }
}
