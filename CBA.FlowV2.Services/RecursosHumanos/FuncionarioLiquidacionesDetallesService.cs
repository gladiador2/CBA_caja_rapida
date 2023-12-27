using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Tesoreria;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class FuncionariosLiquidacionesDetallesService
    {

        #region Borrar
        /// <summary>
        /// Borrars the specified liquidacion detalle_id. 
        /// </summary>
        /// <param name="liquidacionDetalle_id">The liquidacion detalle_id.</param>
        public void Borrar(decimal liquidacionDetalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.Db.BeginTransaction();
                FUNCIONARIOS_LIQUIDACIONES_DETRow row = new FUNCIONARIOS_LIQUIDACIONES_DETRow();
                row = sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.GetByPrimaryKey(liquidacionDetalle_id);
                String valorAnterior = row.ToString();
                sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.DeleteByPrimaryKey(liquidacionDetalle_id);

                // se des asocia el item del detalle segun sea bonificacion o descuento
                if (row.TIPO_ITEM == Definiciones.TipoItemLiquidacion.Descuento)
                    (new FuncionariosDescuentosService()).SetLiquidacionAsociada(row.ITEM_ID, Definiciones.Error.Valor.EnteroPositivo, sesion);
                else if (row.TIPO_ITEM == Definiciones.TipoItemLiquidacion.Bonificacion)
                    (new FuncionariosBonificacionesService()).SetLiquidacionAsociada(row.ITEM_ID, Definiciones.Error.Valor.EnteroPositivo, sesion);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);

                FuncionariosLiquidacionesService.ActualizarTotales(row.FUNCIONARIOS_LIQUIDACIONES_ID, sesion);

                sesion.Db.CommitTransaction();
            }
        }

        /// <summary>
        /// Borrars the specified liquidacion_id.
        /// </summary>
        /// <param name="liquidacion_id">The liquidacion_id.</param>
        /// <param name="item_id">The item_id.</param>
        /// <param name="tipo">The tipo.</param>
        public void Borrar(decimal liquidacion_id, decimal item_id, decimal tipo)
        {

            using (SessionService sesion = new SessionService())
            {
                sesion.Db.BeginTransaction();
                FUNCIONARIOS_LIQUIDACIONES_DETRow row = new FUNCIONARIOS_LIQUIDACIONES_DETRow();
                string clausulas = FuncionariosLiquidacionesDetallesService.FuncionariosLiquidacionesId_NombreCol + "=" + liquidacion_id;
                clausulas += " and " + FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol + "=" + tipo;
                clausulas += " and " + FuncionariosLiquidacionesDetallesService.ItemId_NombreCol + "=" + item_id;
                row = sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.GetRow(clausulas);
                String valorAnterior = row.ToString();
                sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.DeleteByPrimaryKey(row.ID);
                // se des asocia el item del detalle segun sea bonificacion o descuento
                if (row.TIPO_ITEM == Definiciones.TipoItemLiquidacion.Descuento)
                {
                    (new FuncionariosDescuentosService()).SetLiquidacionAsociada(row.ITEM_ID, Definiciones.Error.Valor.EnteroPositivo, sesion);
                }
                else
                {
                    if (row.TIPO_ITEM == Definiciones.TipoItemLiquidacion.Bonificacion)
                    {
                        (new FuncionariosBonificacionesService()).SetLiquidacionAsociada(row.ITEM_ID, Definiciones.Error.Valor.EnteroPositivo, sesion);
                    }
                    else
                    {
                        if (row.TIPO_ITEM == Definiciones.TipoItemLiquidacion.CtaCte)
                            CuentaCorrientePersonasService.SetBloqueado(row.ITEM_ID, false, sesion);
                    }
                }
                LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);

                FuncionariosLiquidacionesService.ActualizarTotales(row.FUNCIONARIOS_LIQUIDACIONES_ID, sesion);

                sesion.Db.CommitTransaction();
            }

        }

        /// <summary>
        /// Borra en forma especica un row
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="sesion">The sesion.</param>
        private void Borrar(FUNCIONARIOS_LIQUIDACIONES_DETRow row, SessionService sesion)
        {
            string valorAnterior = row.ToString();
            sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.DeleteByPrimaryKey(row.ID);
            // se des asocia el item del detalle segun sea bonificacion o descuento
            if (row.TIPO_ITEM == Definiciones.TipoItemLiquidacion.Bonificacion)
            {
                (new FuncionariosBonificacionesService()).SetLiquidacionAsociada(row.ITEM_ID, Definiciones.Error.Valor.EnteroPositivo, sesion);

            }
            else
            {
                if (row.TIPO_ITEM == Definiciones.TipoItemLiquidacion.Descuento)
                {
                    (new FuncionariosDescuentosService()).SetLiquidacionAsociada(row.ITEM_ID, Definiciones.Error.Valor.EnteroPositivo, sesion);
                }
                else
                {
                    if (row.TIPO_ITEM == Definiciones.TipoItemLiquidacion.CtaCte)
                        CuentaCorrientePersonasService.SetBloqueado(row.ITEM_ID, false, sesion);
                }

            }
            FuncionariosLiquidacionesService.ActualizarTotales(row.FUNCIONARIOS_LIQUIDACIONES_ID, sesion);
        }

        /// <summary>
        /// Borrars the detalles por liquidacion. Este metdo se utiliza para borrar todos los detalles de una liquidacion especifica
        /// </summary>
        /// <param name="liquidacion_id">The liquidacion_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void BorrarDetallesPorLiquidacion(decimal liquidacion_id, SessionService sesion)
        {
            FUNCIONARIOS_LIQUIDACIONES_DETRow[] rows;
            // se buscan todos los detalles de la liquidacion y se borran uno a uno
            rows = sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.GetByFUNCIONARIOS_LIQUIDACIONES_ID(liquidacion_id);
            for (int i = 0; i < rows.Length; i++)
                this.Borrar(rows[i], sesion);
        }
        #endregion Borrar

        #region GenerarDetalleLiquidaciones
        /// <summary>
        /// Generars the detalle liquidaciones.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <param name="liquidacon_id">The liquidacon_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void GenerarDetalleLiquidacionesSalarial(decimal funcionario_id, decimal liquidacion_id, decimal moneda_id, SessionService sesion)
        {
            try
            {
                #region Bonificación
                FuncionariosBonificacionesService bonificacion = new FuncionariosBonificacionesService();
                string clausula = FuncionariosBonificacionesService.FuncionarioId_NombreCol + " = " + funcionario_id +
                                  " and " + FuncionariosBonificacionesService.LiquidacionAsociadaId_NombreCol + " is null " +
                                  " and " + FuncionariosBonificacionesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                                  " and " + FuncionariosBonificacionesService.MonedaId_NombreCol + " = " + moneda_id;
                //se  buscan todas las bonificaciones del funcionario que todavia no esten pagadas
                DataTable dtBonificaciones = FuncionariosBonificacionesService.GetFuncionariosBonificacionesInfoCompleta(clausula, string.Empty, true);
                System.Collections.Hashtable camposBonificaciones = new System.Collections.Hashtable();

                //cada bonificacione encontrada es insertada como detalle de la liquidacion
                foreach (DataRow c in dtBonificaciones.Rows)
                {
                    camposBonificaciones = new System.Collections.Hashtable();
                    camposBonificaciones.Add(FuncionariosLiquidacionesDetallesService.FuncionariosLiquidacionesId_NombreCol, liquidacion_id);
                    camposBonificaciones.Add(FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol, Definiciones.TipoItemLiquidacion.Bonificacion);
                    camposBonificaciones.Add(FuncionariosLiquidacionesDetallesService.ItemId_NombreCol, c[FuncionariosBonificacionesService.Id_NombreCol].ToString());
                    camposBonificaciones.Add(FuncionariosLiquidacionesDetallesService.Monto_NombreCol, c[FuncionariosBonificacionesService.Monto_NombreCol].ToString());
                    camposBonificaciones.Add(FuncionariosLiquidacionesDetallesService.MonedaId_NombreCol, c[FuncionariosBonificacionesService.MonedaId_NombreCol].ToString());
                    camposBonificaciones.Add(FuncionariosLiquidacionesDetallesService.Cotizacion_NombreCol, c[FuncionariosBonificacionesService.CotizacionMoneda_NombreCol].ToString());
                    //Datos de la planilla de liquidacion
                    camposBonificaciones.Add(PlanillaLiquidacionesService.Tipo_NombreCol, Definiciones.TipoLiquidacion.Salario);
                    this.Guardar(camposBonificaciones, sesion);
                    bonificacion.SetLiquidacionAsociada(decimal.Parse(c[FuncionariosBonificacionesService.Id_NombreCol].ToString()), liquidacion_id, sesion);
                }
                #endregion Bonificación

                #region Descuentos
                FuncionariosDescuentosService descuento = new FuncionariosDescuentosService();
                clausula = FuncionariosDescuentosService.FuncionarioId_NombreCol + " = " + funcionario_id +
                           " and " + FuncionariosDescuentosService.LiquidacionAsociadaId_NombreCol + " is null" +
                           " and " + FuncionariosDescuentosService.ConsumoVisitas_NombreCol + " = '" + Definiciones.SiNo.No + "' " +
                           " and " + FuncionariosDescuentosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                           " and " + FuncionariosDescuentosService.MonedaId_NombreCol + " = " + moneda_id;
                //se  buscan todos los descuentos del funcionario que todavia no esten pagados
                DataTable dtDescuentos = descuento.GetFuncionariosDescuentosDataTable(clausula, string.Empty, true);
                System.Collections.Hashtable camposDescuentos = new System.Collections.Hashtable();

                //cada desceunto encontrado es insertado como detalle de la liquidacion
                decimal montoDescuento = 0;
                decimal porcentaje = 0;
                string aplicarIPS = string.Empty;
                decimal idDescuentoIps;
                //Cada descuento se aplica sobre cada bonificación, si el descuento utiliza porcentaje y está indicado para aplicarse
                foreach (DataRow c in dtDescuentos.Rows)
                {
                    //monto original del descuento
                    montoDescuento = (decimal)c[FuncionariosDescuentosService.Monto_NombreCol];
                    //% del descuento
                    porcentaje = (decimal)DescuentosService.GetDescuentosDataTable(DescuentosService.Id_NombreCol + " = " + c[FuncionariosDescuentosService.DescuentoId_NombreCol], string.Empty, true).Rows[0][DescuentosService.PorcentajeSugerido_NombreCol];
                    //política de descuento, ID descuento IPS
                    aplicarIPS = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RrhhDescuentoCobroIPS);
                    idDescuentoIps = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.RrhhDescuentoIPS);
                    //si el descuento es IPS se inicializa el monto según el salario indicado en la planilla
                    if (idDescuentoIps == (decimal)c[FuncionariosDescuentosService.DescuentoId_NombreCol])
                        montoDescuento = (decimal)FuncionariosLiquidacionesService.GetLiquidacionesStaticDataTable(FuncionariosLiquidacionesService.Id_NombreCol + " = " + liquidacion_id, sesion).Rows[0][FuncionariosLiquidacionesService.TotalSalario_NombreCol] * porcentaje / 100;
                    //(si el descuento a evaluar es IPS y la politica es NO descontar. No recalcula el IPS, sí para todos los demás casos) &&
                    //está marcado la opción de utilizar %
                    if (!(idDescuentoIps == (decimal)c[FuncionariosDescuentosService.DescuentoId_NombreCol] && aplicarIPS == Definiciones.SiNo.No) &&
                        c[FuncionariosDescuentosService.UtilizarPorcentaje_NombreCol].ToString() == Definiciones.SiNo.Si)
                    {
                        foreach (DataRow bonificaciones in dtBonificaciones.Rows)
                        {
                            if (bonificaciones[FuncionariosBonificacionesService.VistaDescontar_NombreCol].ToString() == Definiciones.SiNo.Si)
                                montoDescuento += ((decimal)bonificaciones[FuncionariosBonificacionesService.Monto_NombreCol]) * porcentaje / 100;
                        }
                    }

                    camposDescuentos = new System.Collections.Hashtable();
                    camposDescuentos.Add(FuncionariosLiquidacionesDetallesService.FuncionariosLiquidacionesId_NombreCol, liquidacion_id);
                    camposDescuentos.Add(FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol, Definiciones.TipoItemLiquidacion.Descuento);
                    camposDescuentos.Add(FuncionariosLiquidacionesDetallesService.ItemId_NombreCol, c[FuncionariosDescuentosService.Id_NombreCol].ToString());
                    camposDescuentos.Add(FuncionariosLiquidacionesDetallesService.Monto_NombreCol, montoDescuento);
                    camposDescuentos.Add(FuncionariosLiquidacionesDetallesService.MonedaId_NombreCol, c[FuncionariosDescuentosService.MonedaId_NombreCol].ToString());
                    camposDescuentos.Add(FuncionariosLiquidacionesDetallesService.Cotizacion_NombreCol, c[FuncionariosDescuentosService.CotizacionMoneda_NombreCol].ToString());
                    //Datos de la planilla de liquidacion
                    camposDescuentos.Add(PlanillaLiquidacionesService.Tipo_NombreCol, Definiciones.TipoLiquidacion.Salario);
                    this.Guardar(camposDescuentos, sesion);
                    descuento.SetLiquidacionAsociada(decimal.Parse(c[FuncionariosDescuentosService.Id_NombreCol].ToString()), liquidacion_id, sesion);
                }
                #endregion Descuentos
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void GenerarDetalleLiquidacionesComplementaria(decimal funcionario_id, decimal liquidacion_id, decimal moneda_id, SessionService sesion)
        {
            {
                try
                {
                    #region Bonificación
                    FuncionariosBonificacionesService bonificacion = new FuncionariosBonificacionesService();
                    string clausula = FuncionariosBonificacionesService.FuncionarioId_NombreCol + " = " + funcionario_id +
                                        " and " + FuncionariosBonificacionesService.LiquidacionAsociadaId_NombreCol + " is null " +
                                        " and " + FuncionariosBonificacionesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                                        " and " + FuncionariosBonificacionesService.MonedaId_NombreCol + " = " + moneda_id;
                    //se  buscan todas las bonificaciones del funcionario que todavia no esten pagadas
                    DataTable dtBonificaciones = FuncionariosBonificacionesService.GetFuncionariosBonificacionesInfoCompleta(clausula, string.Empty, true);
                    System.Collections.Hashtable camposBonificaciones = new System.Collections.Hashtable();

                    //cada bonificacione encontrada es insertada como detalle de la liquidacion
                    foreach (DataRow c in dtBonificaciones.Rows)
                    {
                        camposBonificaciones = new System.Collections.Hashtable();
                        camposBonificaciones.Add(FuncionariosLiquidacionesDetallesService.FuncionariosLiquidacionesId_NombreCol, liquidacion_id);
                        camposBonificaciones.Add(FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol, Definiciones.TipoItemLiquidacion.Bonificacion);
                        camposBonificaciones.Add(FuncionariosLiquidacionesDetallesService.ItemId_NombreCol, c[FuncionariosBonificacionesService.Id_NombreCol].ToString());
                        camposBonificaciones.Add(FuncionariosLiquidacionesDetallesService.Monto_NombreCol, c[FuncionariosBonificacionesService.Monto_NombreCol].ToString());
                        camposBonificaciones.Add(FuncionariosLiquidacionesDetallesService.MonedaId_NombreCol, c[FuncionariosBonificacionesService.MonedaId_NombreCol].ToString());
                        camposBonificaciones.Add(FuncionariosLiquidacionesDetallesService.Cotizacion_NombreCol, c[FuncionariosBonificacionesService.CotizacionMoneda_NombreCol].ToString());
                        this.Guardar(camposBonificaciones, sesion);
                        bonificacion.SetLiquidacionAsociada(decimal.Parse(c[FuncionariosBonificacionesService.Id_NombreCol].ToString()), liquidacion_id, sesion);
                    }
                    #endregion Bonificación

                    #region Descuentos
                    FuncionariosDescuentosService descuento = new FuncionariosDescuentosService();
                    clausula = FuncionariosDescuentosService.FuncionarioId_NombreCol + "=" + funcionario_id +
                               " and " + FuncionariosDescuentosService.LiquidacionAsociadaId_NombreCol + " is null" +
                               " and " + FuncionariosDescuentosService.ConsumoVisitas_NombreCol + "='" + Definiciones.SiNo.No + "' " +
                               " and " + FuncionariosDescuentosService.Estado_NombreCol + "= '" + Definiciones.Estado.Activo + "'" +
                               " and " + FuncionariosDescuentosService.MonedaId_NombreCol + " = " + moneda_id;
                    //se  buscan todos los descuentos del funcionario que todavia no esten pagados
                    DataTable dtDescuentos = descuento.GetFuncionariosDescuentosDataTable(clausula, string.Empty, true);
                    System.Collections.Hashtable camposDescuentos = new System.Collections.Hashtable();

                    //cada desceunto encontrado es insertado como detalle de la liquidacion
                    decimal montoDescuento = 0;
                    decimal porcentaje = 0;
                    string aplicarIPS = string.Empty;
                    decimal idDescuentoIps;
                    //cada descuento encontrada es insertada como detalle de la liquidacion
                    foreach (DataRow c in dtDescuentos.Rows)
                    {
                        //monto original del descuento
                        montoDescuento = (decimal)c[FuncionariosDescuentosService.Monto_NombreCol];
                        //% del descuento
                        porcentaje = (decimal)DescuentosService.GetDescuentosDataTable(DescuentosService.Id_NombreCol + " = " + c[FuncionariosDescuentosService.DescuentoId_NombreCol], string.Empty, true).Rows[0][DescuentosService.PorcentajeSugerido_NombreCol];
                        //política de descuento, ID descuento IPS
                        aplicarIPS = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RrhhDescuentoCobroIPS);
                        idDescuentoIps = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.RrhhDescuentoIPS);
                        //si el descuento es IPS se inicializa el monto según el salario indicado en la planilla
                        if (idDescuentoIps == (decimal)c[FuncionariosDescuentosService.DescuentoId_NombreCol])
                            montoDescuento = (decimal)FuncionariosLiquidacionesService.GetLiquidacionesStaticDataTable(FuncionariosLiquidacionesService.Id_NombreCol + " = " + liquidacion_id, sesion).Rows[0][FuncionariosLiquidacionesService.TotalSalario_NombreCol] * porcentaje / 100;
                        //(si el descuento a evaluar es IPS y la politica es NO descontar. No recalcula el IPS, sí para todos los demás casos) &&
                        //está marcado la opción de utilizar %
                        if (!(idDescuentoIps == (decimal)c[FuncionariosDescuentosService.DescuentoId_NombreCol] && aplicarIPS == Definiciones.SiNo.No) &&
                            c[FuncionariosDescuentosService.UtilizarPorcentaje_NombreCol].ToString() == Definiciones.SiNo.Si)
                        {
                            foreach (DataRow bonificaciones in dtBonificaciones.Rows)
                            {
                                if (bonificaciones[FuncionariosBonificacionesService.VistaDescontar_NombreCol].ToString() == Definiciones.SiNo.Si)
                                    montoDescuento += ((decimal)bonificaciones[FuncionariosBonificacionesService.Monto_NombreCol]) * porcentaje / 100;
                            }
                        }

                        camposDescuentos = new System.Collections.Hashtable();
                        camposDescuentos.Add(FuncionariosLiquidacionesDetallesService.FuncionariosLiquidacionesId_NombreCol, liquidacion_id);
                        camposDescuentos.Add(FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol, Definiciones.TipoItemLiquidacion.Descuento);
                        camposDescuentos.Add(FuncionariosLiquidacionesDetallesService.ItemId_NombreCol, c[FuncionariosDescuentosService.Id_NombreCol].ToString());
                        camposDescuentos.Add(FuncionariosLiquidacionesDetallesService.Monto_NombreCol, montoDescuento);
                        camposDescuentos.Add(FuncionariosLiquidacionesDetallesService.MonedaId_NombreCol, c[FuncionariosDescuentosService.MonedaId_NombreCol].ToString());
                        camposDescuentos.Add(FuncionariosLiquidacionesDetallesService.Cotizacion_NombreCol, c[FuncionariosDescuentosService.CotizacionMoneda_NombreCol].ToString());
                        this.Guardar(camposDescuentos, sesion);
                        descuento.SetLiquidacionAsociada(decimal.Parse(c[FuncionariosDescuentosService.Id_NombreCol].ToString()), liquidacion_id, sesion);
                    }
                    #endregion Descuentos
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion GenerarDetalleLiquidaciones

        #region GetLiquidacionesDetallesDataTable
        /// <summary>
        /// Gets the liquidaciones detalles data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <returns></returns>
        public static DataTable GetLiquidacionesDetallesDataTable(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetLiquidacionesDetallesDataTable(clausula, sesion);
            }
        }

        public static DataTable GetLiquidacionesDetallesDataTable(string clausula, SessionService sesion)
        {
            return sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.GetAsDataTable(clausula, string.Empty);
        }

        /// <summary>
        /// Gets the liquidaciones detalles data table.
        /// </summary>
        /// <param name="liquidacion_id">The liquidacion_id.</param>
        /// <returns></returns>
        public DataTable GetLiquidacionesDetallesDataTable(decimal liquidacion_id)
        {
            return GetLiquidacionesDetallesDataTable(FuncionariosLiquidacionesDetallesService.FuncionariosLiquidacionesId_NombreCol + "=" + liquidacion_id);
        }

        public DataTable GetLiquidacionesDetallesDataTable(decimal liquidacion_id, decimal tipo_item)
        {
            string clausulas = FuncionariosLiquidacionesDetallesService.FuncionariosLiquidacionesId_NombreCol + "=" + liquidacion_id;
            clausulas += " and " + FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol + "=" + tipo_item;
            return GetLiquidacionesDetallesDataTable(clausulas);
        }
        #endregion GetLiquidacionesDetallesDataTable

        #region GetLiquidacionesDetallesInfoCompleta
        /// <summary>
        /// Gets the liquidaciones detalles info completa.
        /// </summary>
        /// <param name="liquidacion_id">The liquidacion_id.</param>
        /// <returns></returns>
        public DataTable GetLiquidacionesDetallesInfoCompleta(decimal liquidacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FUNC_LIQ_DET_INFO_COMPLCollection.GetAsDataTable(FuncionariosLiquidacionesDetallesService.FuncionariosLiquidacionesId_NombreCol + "=" + liquidacion_id, string.Empty);
            }
        }
        #endregion GetLiquidacionesDetallesInfoCompleta

        #region VerificarExistencia
        /// <summary>
        /// Verificars the existencia.
        /// </summary>
        /// <param name="descuento_id">The descuento_id.</param>
        /// <param name="liquidacion_id">The liquidacion_id.</param>
        /// <param name="tipo_item">The tipo_item.</param>
        /// <returns></returns>
        public static bool VerificarExistencia(decimal descuento_id, decimal liquidacion_id, decimal tipo_item)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    FUNCIONARIOS_LIQUIDACIONES_DETRow[] detalles = sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.GetByFUNCIONARIOS_LIQUIDACIONES_ID(liquidacion_id);
                    for (int i = 0; i < detalles.Length; i++)
                    {
                        if (detalles[i].ITEM_ID == descuento_id && detalles[i].TIPO_ITEM == tipo_item)
                            return true;
                    }

                    sesion.Db.CommitTransaction();
                    return false;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion VerificarExistencia

        #region GetMonto
        public static decimal GetMontoDescuento(decimal descuento_id, decimal liquidacion_id, decimal tipo_item)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    FUNCIONARIOS_LIQUIDACIONES_DETRow[] detalles = sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.GetByFUNCIONARIOS_LIQUIDACIONES_ID(liquidacion_id);
                    for (int i = 0; i < detalles.Length; i++)
                    {
                        if (detalles[i].ITEM_ID == descuento_id && detalles[i].TIPO_ITEM == tipo_item)
                        {
                            return detalles[i].MONTO;
                        }
                    }
                    sesion.Db.CommitTransaction();
                    return Definiciones.Error.Valor.EnteroPositivo;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion

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

                    FUNCIONARIOS_LIQUIDACIONES_DETRow row = new FUNCIONARIOS_LIQUIDACIONES_DETRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("funcionarios_liquidac_det_sqc");
                        row.FUNCIONARIOS_LIQUIDACIONES_ID = decimal.Parse(campos[FuncionariosLiquidacionesDetallesService.FuncionariosLiquidacionesId_NombreCol].ToString());
                    }
                    else
                    {
                        row = sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.GetByPrimaryKey(decimal.Parse(campos[FuncionariosLiquidacionesDetallesService.Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    //campos obligatorios
                    row.TIPO_ITEM = decimal.Parse(campos[FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol].ToString());

                    if (!(decimal.Parse(campos[FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol].ToString()) == Definiciones.TipoItemLiquidacion.MontoManual))
                        row.ITEM_ID = decimal.Parse(campos[FuncionariosLiquidacionesDetallesService.ItemId_NombreCol].ToString());

                    row.MONTO = decimal.Parse(campos[FuncionariosLiquidacionesDetallesService.Monto_NombreCol].ToString());
                    row.COTIZACION = decimal.Parse(campos[FuncionariosLiquidacionesDetallesService.Cotizacion_NombreCol].ToString());
                    row.MONEDA_ID = decimal.Parse(campos[FuncionariosLiquidacionesDetallesService.MonedaId_NombreCol].ToString());

                    FUNCIONARIOS_LIQUIDACIONES_DETRow[] detalles = sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.GetByFUNCIONARIOS_LIQUIDACIONES_ID(row.FUNCIONARIOS_LIQUIDACIONES_ID);
                    for (int i = 0; i < detalles.Length; i++)
                    {
                        if (!(decimal.Parse(campos[FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol].ToString()) == Definiciones.TipoItemLiquidacion.MontoManual))
                        {
                            if (detalles[i].ITEM_ID == row.ITEM_ID && detalles[i].TIPO_ITEM == row.TIPO_ITEM && detalles[i].MONTO == row.MONTO)
                            {
                                throw new System.ArgumentException("Este item ya existe en esta liquidación");
                            }
                        }
                    }

                    if (insertarNuevo) sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.Insert(row);
                    else sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    if (row.TIPO_ITEM == Definiciones.TipoItemLiquidacion.Descuento)
                    {
                        (new FuncionariosDescuentosService()).SetLiquidacionAsociada(row.ITEM_ID, row.FUNCIONARIOS_LIQUIDACIONES_ID, sesion);
                    }
                    else if (row.TIPO_ITEM == Definiciones.TipoItemLiquidacion.Bonificacion)
                    {
                        (new FuncionariosBonificacionesService()).SetLiquidacionAsociada(row.ITEM_ID, row.FUNCIONARIOS_LIQUIDACIONES_ID, sesion);
                    }
                    else if (row.TIPO_ITEM == Definiciones.TipoItemLiquidacion.CtaCte)
                    {
                        CuentaCorrientePersonasService.SetBloqueado(row.ITEM_ID, true, sesion);
                    }

                    FuncionariosLiquidacionesService.ActualizarTotales(row.FUNCIONARIOS_LIQUIDACIONES_ID, sesion);

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

        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="sesion">The sesion.</param>
        private void Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                FUNCIONARIOS_LIQUIDACIONES_DETRow row = new FUNCIONARIOS_LIQUIDACIONES_DETRow();
                String valorAnterior = string.Empty;

                valorAnterior = Definiciones.Log.RegistroNuevo;
                row.ID = sesion.Db.GetSiguienteSecuencia("funcionarios_liquidac_det_sqc");

                row.FUNCIONARIOS_LIQUIDACIONES_ID = decimal.Parse(campos[FuncionariosLiquidacionesDetallesService.FuncionariosLiquidacionesId_NombreCol].ToString());
                row.TIPO_ITEM = decimal.Parse(campos[FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol].ToString());
                row.ITEM_ID = decimal.Parse(campos[FuncionariosLiquidacionesDetallesService.ItemId_NombreCol].ToString());
                row.MONEDA_ID = decimal.Parse(campos[FuncionariosLiquidacionesService.MonedaId_NombreCol].ToString());
                row.COTIZACION = decimal.Parse(campos[FuncionariosLiquidacionesService.Cotizacion_NombreCol].ToString());
                row.MONTO = Math.Round(decimal.Parse(campos[FuncionariosLiquidacionesDetallesService.Monto_NombreCol].ToString()), MonedasService.CantidadDecimalesStatic(row.MONEDA_ID));

                sesion.Db.FUNCIONARIOS_LIQUIDACIONES_DETCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);
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
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "FUNCIONARIOS_LIQUIDACIONES_DET"; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONES_DETCollection.COTIZACIONColumnName; }
        }
        public static string FuncionariosLiquidacionesId_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONES_DETCollection.FUNCIONARIOS_LIQUIDACIONES_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONES_DETCollection.IDColumnName; }
        }
        public static string ItemId_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONES_DETCollection.ITEM_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONES_DETCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONES_DETCollection.MONTOColumnName; }
        }
        public static string TipoItem_NombreCol
        {
            get { return FUNCIONARIOS_LIQUIDACIONES_DETCollection.TIPO_ITEMColumnName; }
        }

        #endregion Tabla

        #region Vista
        public static string Nombre_Vista
        {
            get { return "FUNC_LIQ_DET_INFO_COMPL"; }
        }
        public static string VistaItemDescripcion_NombreCol
        {
            get { return FUNC_LIQ_DET_INFO_COMPLCollection.ITEM_DESCRIPCIONColumnName; }
        }
        public static string VistaTipoItemNombre_NombreCol
        {
            get { return FUNC_LIQ_DET_INFO_COMPLCollection.TIPO_ITEM_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return FUNC_LIQ_DET_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return FUNC_LIQ_DET_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        #endregion Vista
        #endregion Accessors
    }
}
