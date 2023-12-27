using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteFondosFijosMovimientosService
    {
        #region GetCuentaCorrienteFondosFijosMovimientosDataTable
        public DataTable GetCuentaCorrienteFondosFijosMovimientosDataTable(decimal ctacte_fondo_fijo_id)
        {
            return GetCuentaCorrienteFondosFijosMovimientosDataTable(CuentaCorrienteFondosFijosMovimientosService.CtacteFondoFijoId_NombreCol + " = " + ctacte_fondo_fijo_id, CuentaCorrienteFondosFijosMovimientosService.Fecha_NombreCol);
        }

        public DataTable GetCuentaCorrienteFondosFijosMovimientosDataTable(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return sesion.Db.CTACTE_FONDOS_FIJOS_MOVCollection.GetAsDataTable(clausulas, orden);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        public static DataTable GetCuentaCorrienteFondosFijosMovimientosDataTable2(decimal ctacte_fondo_fijo_id)
        {
            return GetCuentaCorrienteFondosFijosMovimientosDataTable2(CuentaCorrienteFondosFijosMovimientosService.CtacteFondoFijoId_NombreCol + " = " + ctacte_fondo_fijo_id, CuentaCorrienteFondosFijosMovimientosService.Fecha_NombreCol);
        }

        public static DataTable GetCuentaCorrienteFondosFijosMovimientosDataTable2(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return sesion.Db.CTACTE_FONDOS_FIJOS_MOVCollection.GetAsDataTable(clausulas, orden);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetCuentaCorrienteFondosFijosMovimientosDataTable

        #region Egreso
        /// <summary>
        /// Egresoes the specified ctacte_fondo_fijo_id.
        /// </summary>
        /// <param name="ctacte_fondo_fijo_id">The ctacte_fondo_fijo_id.</param>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="registro_id">The registro_id.</param>
        /// <param name="monto">The monto.</param>
        /// <param name="?">The ?.</param>
        /// <param name="cotizacion_moneda">The cotizacion_moneda.</param>
        /// <param name="observacion">The observacion.</param>
        /// <param name="sesion">The sesion.</param>
        public void Egreso(decimal ctacte_fondo_fijo_id, decimal fondo_fijo_id_det, int flujo_id, decimal registro_id, decimal monto, decimal cotizacion_moneda, string observacion, DateTime fecha, SessionService sesion)
        {
            try
            {
                CTACTE_FONDOS_FIJOS_MOVRow row = new CTACTE_FONDOS_FIJOS_MOVRow();
                DataTable dtFondoFijo = CuentaCorrienteFondosFijosService.GetCuentaCorrienteFondosFijosDataTable(CuentaCorrienteFondosFijosService.Id_NombreCol + " = " + ctacte_fondo_fijo_id, string.Empty, sesion);
                string valorAnterior = Definiciones.Log.RegistroNuevo;
                
                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_fondos_fijos_mov_sqc");
                row.COTIZACION_MONEDA = cotizacion_moneda;
                row.CTACTE_FONDO_FIJO_ID = ctacte_fondo_fijo_id;
                row.FECHA = fecha;

                if(fondo_fijo_id_det != Definiciones.Error.Valor.EnteroPositivo)
                    row.MOVIMIENTO_FONDO_FIJO_DET_ID = fondo_fijo_id_det;

                row.EGRESO = monto;
                row.INGRESO = 0;
                
                row.SALDO = (decimal)dtFondoFijo.Rows[0][CuentaCorrienteFondosFijosService.MontoActual_NombreCol] - monto;

                row.OBSERVACION = observacion;
                row.USUARIO_ID = sesion.Usuario.ID;

                switch(flujo_id)
                {
                    case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                        row.ORDEN_PAGO_ID = registro_id;
                        break;
                    case Definiciones.FlujosIDs.EGRESO_VARIO_CAJA:
                        row.EGRESO_VARIO_CAJA_ID = registro_id;
                        break;
                    case Definiciones.FlujosIDs.MOVIMIENTO_FONDO_FIJO:
                        row.MOVIMIENTO_FONDO_FIJO_ID = registro_id;
                        break;
                    default:
                        throw new Exception("CuentaCorrienteFondosFijosMovimientosService.Egreso(): movimiento por flujo no implementado.");
                }

                sesion.Db.CTACTE_FONDOS_FIJOS_MOVCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                //Se recalcula el monto disponible del fondo fijo
                CuentaCorrienteFondosFijosService.RecalcularMontoDisponible(ctacte_fondo_fijo_id, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Egreso

        #region Ingreso
        /// <summary>
        /// Ingresoes the specified ctacte_fondo_fijo_id.
        /// </summary>
        /// <param name="ctacte_fondo_fijo_id">The ctacte_fondo_fijo_id.</param>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="registro_id">The registro_id.</param>
        /// <param name="monto">The monto.</param>
        /// <param name="cotizacion_moneda">The cotizacion_moneda.</param>
        /// <param name="observacion">The observacion.</param>
        /// <param name="sesion">The sesion.</param>
        public void Ingreso(decimal ctacte_fondo_fijo_id,decimal fondo_fijo_id_det,int flujo_id, decimal registro_id, decimal monto, decimal cotizacion_moneda, string observacion,DateTime fecha, SessionService sesion)
        {
            try
            {
                CTACTE_FONDOS_FIJOS_MOVRow row = new CTACTE_FONDOS_FIJOS_MOVRow();
                DataTable dtFondoFijo = CuentaCorrienteFondosFijosService.GetCuentaCorrienteFondosFijosDataTable(CuentaCorrienteFondosFijosService.Id_NombreCol + " = " + ctacte_fondo_fijo_id, string.Empty, sesion);
                string valorAnterior = Definiciones.Log.RegistroNuevo;

                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_fondos_fijos_mov_sqc");
                row.COTIZACION_MONEDA = cotizacion_moneda;
                row.CTACTE_FONDO_FIJO_ID = ctacte_fondo_fijo_id;
                row.FECHA = fecha;

                if (fondo_fijo_id_det != Definiciones.Error.Valor.EnteroPositivo)
                    row.MOVIMIENTO_FONDO_FIJO_DET_ID = fondo_fijo_id_det;

                row.EGRESO = 0;
                row.INGRESO = monto;

                row.SALDO = (decimal)dtFondoFijo.Rows[0][CuentaCorrienteFondosFijosService.MontoActual_NombreCol] + monto;

                row.OBSERVACION = observacion;
                row.USUARIO_ID = sesion.Usuario.ID;

                switch (flujo_id)
                {
                    case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                        row.ORDEN_PAGO_ID = registro_id;
                        break;
                    case Definiciones.FlujosIDs.EGRESO_VARIO_CAJA:
                        row.EGRESO_VARIO_CAJA_ID = registro_id;
                        break;
                    case Definiciones.FlujosIDs.MOVIMIENTO_FONDO_FIJO:
                        row.MOVIMIENTO_FONDO_FIJO_ID = registro_id;
                        break;
                    default:
                        throw new Exception("CuentaCorrienteFondosFijosMovimientosService.Ingreso(): movimiento por flujo no implementado.");
                }

                sesion.Db.CTACTE_FONDOS_FIJOS_MOVCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                //Se recalcula el monto disponible del fondo fijo
                CuentaCorrienteFondosFijosService.RecalcularMontoDisponible(ctacte_fondo_fijo_id, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Ingreso

        #region Movimiento
        public static void Movimiento(decimal ctacte_fondo_fijo_id, decimal fondo_fijo_id_det, int flujo_id, decimal registro_id, decimal ingreso, decimal egreso, decimal cotizacion_moneda, string observacion, DateTime fecha, SessionService sesion)
        {
            try
            {
                CTACTE_FONDOS_FIJOS_MOVRow row = new CTACTE_FONDOS_FIJOS_MOVRow();
                decimal saldoActualFondoFijo = 0;

                DataTable dtFondoFijo = CuentaCorrienteFondosFijosService.GetCuentaCorrienteFondosFijosDataTable(CuentaCorrienteFondosFijosService.Id_NombreCol + " = " + ctacte_fondo_fijo_id, string.Empty, sesion);
                string valorAnterior = Definiciones.Log.RegistroNuevo;


                //Agregamos los nuevos valores a ser guardados
                saldoActualFondoFijo = (decimal)dtFondoFijo.Rows[0][CuentaCorrienteFondosFijosService.MontoActual_NombreCol] + ingreso - egreso;
                decimal limiteSuperior = (decimal)dtFondoFijo.Rows[0][CuentaCorrienteFondosFijosService.LimiteSuperior_NombreCol];

                //Controlamos que no se supere el limite inferior y  superior permitido en el fondo fijo
                if (saldoActualFondoFijo > limiteSuperior)
                {
                    throw new Exception("El monto maximo establecido es : " + limiteSuperior.ToString("N0") + " y el saldo que intenta ingresar es : " + saldoActualFondoFijo.ToString("N0"));
                }
                else if (saldoActualFondoFijo < (decimal)dtFondoFijo.Rows[0][CuentaCorrienteFondosFijosService.MontoSobregiro_NombreCol] * -1)
                {
                    throw new Exception("El fondo fijo no cuenta con saldo suficiente.");
                }
                else
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_fondos_fijos_mov_sqc");
                    row.COTIZACION_MONEDA = cotizacion_moneda;
                    row.CTACTE_FONDO_FIJO_ID = ctacte_fondo_fijo_id;
                    row.FECHA = fecha;

                    row.EGRESO = egreso;
                    row.INGRESO = ingreso;

                    row.SALDO = saldoActualFondoFijo;

                    row.OBSERVACION = observacion;
                    row.USUARIO_ID = sesion.Usuario.ID;

                    if(fondo_fijo_id_det != Definiciones.Error.Valor.EnteroPositivo)
                        row.MOVIMIENTO_FONDO_FIJO_DET_ID = fondo_fijo_id_det;

                    switch (flujo_id)
                    {
                        case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                            row.ORDEN_PAGO_ID = registro_id;
                            break;
                        case Definiciones.FlujosIDs.EGRESO_VARIO_CAJA:
                            row.EGRESO_VARIO_CAJA_ID = registro_id;
                            break;
                        case Definiciones.FlujosIDs.MOVIMIENTO_FONDO_FIJO:
                            row.MOVIMIENTO_FONDO_FIJO_ID = registro_id;
                            break;
                        case Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL:
                            row.TRANSFERENCIA_CAJA_SUC_ID = registro_id;
                            break;
                        default:
                            throw new Exception("CuentaCorrienteFondosFijosMovimientosService.Movimiento(): movimiento por flujo no implementado.");
                    }

                    sesion.Db.CTACTE_FONDOS_FIJOS_MOVCollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    //Se recalcula el monto disponible del fondo fijo
                    CuentaCorrienteFondosFijosService.RecalcularMontoDisponible(ctacte_fondo_fijo_id, sesion);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion

        #region Actualizar Fecha Movimiento

        #region ActualizarVencimiento
        /// <summary>
        /// Actualizar Fecha movimiento fondo fijo
        /// </summary>
        /// <param name="id_mov">Id del movimiento</param>
        /// <param name="fecha_mov">Fecha del movimiento</param>
        /// <param name="tipo_mov">Tipo de movimeinto</param>
        /// 

        public static void ActualizarFechaMov(decimal id_mov, int tipo_mov, DateTime fecha_mov)
        {
            using (SessionService sesion = new SessionService())
            {
                ActualizarFechaMov(id_mov, tipo_mov, fecha_mov, sesion);
            }
        }

        public static void ActualizarFechaMov(decimal id_mov, int tipo_mov, DateTime fecha_mov, SessionService sesion)
        {
            CTACTE_FONDOS_FIJOS_MOVRow[] rows;
            switch (tipo_mov)
            {
                case Definiciones.FlujosIDs.MOVIMIENTO_FONDO_FIJO:
                    rows = sesion.Db.CTACTE_FONDOS_FIJOS_MOVCollection.GetByMOVIMIENTO_FONDO_FIJO_ID(id_mov);
                    break;
                default:
                    throw new Exception("CuentaCorrienteFondosFijosMovimientosService.ActualizarFechaMov(): no implementado.");
            }
            
            for (int i = 0; i < rows.Length; i++)
            {
                string valorAnterior = string.Empty;
                valorAnterior = rows[i].ToString();
                rows[i].FECHA = fecha_mov;
                sesion.Db.CTACTE_FONDOS_FIJOS_MOVCollection.Update(rows[i]);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[i].ID, valorAnterior, rows[i].ToString(), sesion);
            }
        }

        #endregion Actualizar Fecha Movimiento


        #endregion

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_FONDOS_FIJOS_MOV"; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_MOVCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteFondoFijoId_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_MOVCollection.CTACTE_FONDO_FIJO_IDColumnName; }
        }
        public static string EgresoVarioCajaId_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_MOVCollection.EGRESO_VARIO_CAJA_IDColumnName; }
        }
        public static string Egreso_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_MOVCollection.EGRESOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_MOVCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_MOVCollection.IDColumnName; }
        }
        public static string Ingreso_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_MOVCollection.INGRESOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_MOVCollection.OBSERVACIONColumnName; }
        }
        public static string OrdenPagoId_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_MOVCollection.ORDEN_PAGO_IDColumnName; }
        }
        public static string Saldo_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_MOVCollection.SALDOColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_MOVCollection.USUARIO_IDColumnName; }
        }
        public static string MovimientoFondoFijoId_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_MOVCollection.MOVIMIENTO_FONDO_FIJO_IDColumnName; }
        }
        public static string MovimientoFondoFijoDetalleId_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_MOVCollection.MOVIMIENTO_FONDO_FIJO_DET_IDColumnName; }
        }
        #endregion Accessors
    }
}
