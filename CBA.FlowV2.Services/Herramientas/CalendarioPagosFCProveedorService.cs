using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Common;

namespace CBA.FlowV2.Services.Herramientas
{
    public class CalendarioPagosFCProveedorService
    {
        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                return Guardar(campos, sesion);
            }
        }

        public static decimal Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                CALENDARIO_PAGOS_FC_PROVEEDORRow row = new CALENDARIO_PAGOS_FC_PROVEEDORRow();
                string valorAnterior = string.Empty;
                row.ID = sesion.Db.GetSiguienteSecuencia(" calendario_pagos_fc_prov_sqc");
                row.FACTURA_PROVEEDOR_ID = decimal.Parse(campos[CalendarioPagosFCProveedorService.FacturaProveedorId_NombreCol].ToString());
                row.MONTO = decimal.Parse(campos[CalendarioPagosFCProveedorService.MontoPago_NombreCol].ToString());
                row.FECHA_VENCIMIENTO = DateTime.Parse(campos[CalendarioPagosFCProveedorService.FechaVencimiento_NombreCol].ToString());

                sesion.Db.CALENDARIO_PAGOS_FC_PROVEEDORCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                return row.ID;
            }
            catch (Exception exp)
            {
                sesion.Db.RollbackTransaction();
                throw exp;
            }

        }

        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal idCalendario)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {

                    sesion.Db.BeginTransaction();
                    Borrar(idCalendario, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        public static void Borrar(decimal idCalendario, SessionService sesion)
        {
            try
            {
                CALENDARIO_PAGOS_FC_PROVEEDORRow row = new CALENDARIO_PAGOS_FC_PROVEEDORRow();
                row = sesion.Db.CALENDARIO_PAGOS_FC_PROVEEDORCollection.GetByPrimaryKey(idCalendario);
                string valorAnterior = row.ToString();
                CuentaCorrienteProveedoresService.BorrarPorCalendarioPagoId(idCalendario, sesion);
                sesion.Db.CALENDARIO_PAGOS_FC_PROVEEDORCollection.DeleteByPrimaryKey(row.ID);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
            }
            catch
            {
                throw;
            }
        }

        public static void BorrarPorFactura(decimal idFactura)
        {
            using (SessionService sesion = new SessionService())
            {
                BorrarPorFactura(idFactura, sesion);
            }
        }

        public static void BorrarPorFactura(decimal idFactura, SessionService sesion)
        {
            try
            {
                CALENDARIO_PAGOS_FC_PROVEEDORRow[] rows; ;
                rows = sesion.Db.CALENDARIO_PAGOS_FC_PROVEEDORCollection.GetByFACTURA_PROVEEDOR_ID(idFactura);
                for (int i = 0; i < rows.Length; i++)
                {
                    Borrar(rows[i].ID, sesion);
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion Borrar

        #region ActualizarMonto
        public static void ActualizarMonto(decimal idPago, decimal monto)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CALENDARIO_PAGOS_FC_PROVEEDORRow row = new CALENDARIO_PAGOS_FC_PROVEEDORRow();
                    row = sesion.Db.CALENDARIO_PAGOS_FC_PROVEEDORCollection.GetByPrimaryKey(idPago);
                    string valorAnterior = row.ToString();
                    sesion.Db.BeginTransaction();
                    row.MONTO = monto;
                    sesion.Db.CALENDARIO_PAGOS_FC_PROVEEDORCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
                    sesion.Db.CommitTransaction();

                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion ActualizarMonto

        #region ActualizarVencimiento
        public static void ActualizarVencimiento(decimal idPago, DateTime vencimeinto)
        {
            using (SessionService sesion = new SessionService())
            {

                try
                {
                    CALENDARIO_PAGOS_FC_PROVEEDORRow row = new CALENDARIO_PAGOS_FC_PROVEEDORRow();
                    row = sesion.Db.CALENDARIO_PAGOS_FC_PROVEEDORCollection.GetByPrimaryKey(idPago);
                    string valorAnterior = row.ToString();
                    sesion.Db.BeginTransaction();
                    row.FECHA_VENCIMIENTO = vencimeinto;
                    sesion.Db.CALENDARIO_PAGOS_FC_PROVEEDORCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion ActualizarVencimiento

        #region CalcularTotalPagosPorFactura

        public static decimal CalcularTotalPagosPorFactura(decimal idFactura, SessionService sesion)
        {
            // se suman los montos de cada pago 
            decimal total = 0;
            try
            {
                CALENDARIO_PAGOS_FC_PROVEEDORRow[] rows; ;
                rows = sesion.Db.CALENDARIO_PAGOS_FC_PROVEEDORCollection.GetByFACTURA_PROVEEDOR_ID(idFactura);
                for (int i = 0; i < rows.Length; i++)
                {
                    total += rows[i].MONTO;
                }
                return total;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static decimal CalcularTotalPagosPorFactura(decimal idFactura)
        {
            using (SessionService sesion = new SessionService())
            {
                return CalcularTotalPagosPorFactura(idFactura, sesion);
            }
        }
        #endregion CalcularTotalPagosPorFactura

        #region ActualizarPagos
        public static void ActualizarPagos(decimal factura_id, DateTime fechaBase, decimal monto, decimal condicion_pago_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ActualizarPagos(factura_id, fechaBase, monto, condicion_pago_id, sesion);
            }
        }

        /// <summary>
        /// Actualizars the pagos.
        /// </summary>
        /// <param name="factura_id">The factura_id.</param>
        /// <param name="fechaBase">The fecha base.</param>
        /// <param name="monto">The monto.</param>
        /// <param name="condicion_pago_id">The condicion_pago_id.</param>
        public static void ActualizarPagos(decimal factura_id, DateTime fechaBase, decimal monto, decimal condicion_pago_id, SessionService sesion)
        {
            decimal cantidadCuotas = 0;
            DataTable plazos, dtFactura;
            string tipoCalculo = string.Empty;
            CondicionesPagoService condiciones = new CondicionesPagoService();
            DateTime vencimiento;
            decimal casoId = FacturasProveedorService.GetCasoId(factura_id, sesion);
            string casoEstado = CasosService.GetEstadoCaso(casoId, sesion);
            decimal sumaRedondeo, montoRedondeado, montoCuota;
            int cantidadDecimales;

            if (casoEstado.Equals(Definiciones.EstadosFlujos.Aprobado))
            {
                if (CuentaCorrienteProveedoresService.TienePagoCaso(casoId, sesion))
                {
                    throw new Exception("La condición de pago no puede ser cambiada porque la misma ya posee pagos");
                }
            }
            try
            {
                dtFactura = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.Id_NombreCol + " = " + factura_id, string.Empty, sesion);
                // se borra todas los pagos correspondientes a la factura
                BorrarPorFactura(factura_id, sesion);

                cantidadCuotas = CondicionesPagoService.GetCantidadPagos(condicion_pago_id, sesion);
                plazos = condiciones.GetPlazosVencimientos(condicion_pago_id, sesion);
                tipoCalculo = condiciones.GetTipoCalculo(condicion_pago_id, sesion);

                montoCuota = monto / cantidadCuotas;

                cantidadDecimales = MonedasService.CantidadDecimalesStatic((decimal)dtFactura.Rows[0][FacturasProveedorService.MonedaId_NombreCol]);
                montoRedondeado = Math.Round(montoCuota, cantidadDecimales);
                sumaRedondeo = (montoCuota - montoRedondeado) * cantidadCuotas;


                for (int i = 0; i < plazos.Rows.Count; i++)
                {
                    //calculamos las fechas de vencimiento
                    if (tipoCalculo.Equals(Definiciones.CondicionPagoTipoCalculo.Dias))
                        vencimiento = fechaBase.AddDays(double.Parse(plazos.Rows[i][CondicionesPagoService.Pagos_NombreCol].ToString()));
                    else
                        vencimiento = fechaBase.AddMonths(int.Parse(plazos.Rows[i][CondicionesPagoService.Pagos_NombreCol].ToString()));

                    //se guardan los nuevos pagos
                    System.Collections.Hashtable campos = new System.Collections.Hashtable();

                    if (i < cantidadCuotas - 1)
                        montoCuota = montoRedondeado;
                    else
                        montoCuota = Math.Round(montoRedondeado + sumaRedondeo, cantidadDecimales);

                    campos.Add(CalendarioPagosFCProveedorService.MontoPago_NombreCol, montoCuota);
                    campos.Add(CalendarioPagosFCProveedorService.FechaVencimiento_NombreCol, vencimiento);
                    campos.Add(CalendarioPagosFCProveedorService.FacturaProveedorId_NombreCol, factura_id);
                    decimal calendario_id = CalendarioPagosFCProveedorService.Guardar(campos, sesion);
                    if (casoEstado.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        if (FacturasProveedorService.AfectaCtaCteProveedor(factura_id, sesion).Equals(Definiciones.SiNo.Si))
                        {
                            CuentaCorrienteProveedoresService.AgregarCredito(FacturasProveedorService.GetProveedorId(factura_id),
                                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                                    Definiciones.CuentaCorrienteValores.Factura,
                                                                    Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                                    casoId,
                                                                    FacturasProveedorService.GetMonedaId(factura_id),
                                                                    montoCuota,
                                                                    string.Empty,
                                                                    vencimiento,
                                                                    calendario_id,
                                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                                    sesion);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion ActualizarPagos

        #region GetCalendariosPagosPorFactura
        public static DataTable GetCalendariosPagosPorFactura(decimal factura_proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    return sesion.Db.CALENDARIO_PAGOS_FC_PROVEEDORCollection.GetAsDataTable(CalendarioPagosFCProveedorService.FacturaProveedorId_NombreCol + "=" + factura_proveedor_id, CalendarioPagosFCProveedorService.FechaVencimiento_NombreCol);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }

        public static DataTable GetCalendariosPagosPorFactura(decimal factura_proveedor_id, SessionService sesion)
        {
            try
            {
                return sesion.Db.CALENDARIO_PAGOS_FC_PROVEEDORCollection.GetAsDataTable(CalendarioPagosFCProveedorService.FacturaProveedorId_NombreCol + "=" + factura_proveedor_id, CalendarioPagosFCProveedorService.FechaVencimiento_NombreCol);
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }
        #endregion GetCalendariosPagosPorFactura

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CALENDARIO_PAGOS_FC_PROVEEDOR"; }
        }
        public static string Id_NombreCol
        {
            get { return CALENDARIO_PAGOS_FC_PROVEEDORCollection.IDColumnName; }
        }
        public static string FacturaProveedorId_NombreCol
        {
            get { return CALENDARIO_PAGOS_FC_PROVEEDORCollection.FACTURA_PROVEEDOR_IDColumnName; }
        }
        public static string MontoPago_NombreCol
        {
            get { return CALENDARIO_PAGOS_FC_PROVEEDORCollection.MONTOColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return CALENDARIO_PAGOS_FC_PROVEEDORCollection.FECHA_VENCIMIENTOColumnName; }
        }
        #endregion Accessors
    }
}
