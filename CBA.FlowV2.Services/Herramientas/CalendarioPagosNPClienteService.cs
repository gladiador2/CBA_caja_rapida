using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Sesion;
using System.Collections;

namespace CBA.FlowV2.Services.Herramientas
{
    public class CalendarioPagosNPClienteService
    {
        #region GetCalendarioPagosDataTable
        /// <summary>
        /// Gets the calendario pagos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCalendarioPagosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CALENDARIO_PAGOS_NP_CLIENTECollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetTotal
        
        #region GetCalendariosPagosPorPedido
        /// <summary>
        /// Gets the calendarios pagos por pedido.
        /// </summary>
        /// <param name="pedido_cliente_id">The pedido_cliente_id.</param>
        /// <returns></returns>
        public static DataTable GetCalendariosPagosPorPedido(decimal pedido_cliente_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CALENDARIO_PAGOS_NP_CLIENTECollection.GetAsDataTable(CalendarioPagosNPClienteService.NotaPedidoClienteId_NombreCol + " = " + pedido_cliente_id, CalendarioPagosNPClienteService.NumeroCuota_NombreCol);
            }
        }
        #endregion GetCalendariosPagosPorPedido
        
        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                CALENDARIO_PAGOS_NP_CLIENTERow row = new CALENDARIO_PAGOS_NP_CLIENTERow();
                string valorAnterior = string.Empty;
                row.ID = sesion.Db.GetSiguienteSecuencia("calendario_pagos_np_cli_sqc");
                row.NOTA_PEDIDO_CLIENTE_ID = (decimal)campos[CalendarioPagosNPClienteService.NotaPedidoClienteId_NombreCol];
                row.MONTO_CAPITAL = (decimal)campos[CalendarioPagosNPClienteService.MontoCapital_NombreCol];
                row.MONTO_INTERES = (decimal)campos[CalendarioPagosNPClienteService.MontoInteres_NombreCol];
                row.FECHA_VENCIMIENTO = (DateTime)campos[CalendarioPagosNPClienteService.FechaVencimiento_NombreCol];
                row.NUMERO_CUOTA = (decimal)campos[CalendarioPagosNPClienteService.NumeroCuota_NombreCol];

                sesion.Db.CALENDARIO_PAGOS_NP_CLIENTECollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Exception) 
            {
                throw;
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the por pedido.
        /// </summary>
        /// <param name="pedido_cliente_id">The pedido_cliente_id.</param>
        public static void BorrarPorPedido(decimal pedido_cliente_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.CALENDARIO_PAGOS_NP_CLIENTECollection.DeleteByNOTA_PEDIDO_CLIENTE_ID(pedido_cliente_id);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion Borrar

        #region GetTotal
        /// <summary>
        /// Gets the total.
        /// </summary>
        /// <param name="pedido_cliente_id">The pedido_cliente_id.</param>
        /// <returns></returns>
        public static decimal GetTotal(decimal pedido_cliente_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTotal(pedido_cliente_id, sesion);
            }
        }
        
        /// <summary>
        /// Gets the total.
        /// </summary>
        /// <param name="pedido_cliente_id">The pedido_cliente_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal GetTotal(decimal pedido_cliente_id, SessionService sesion)
        {
            decimal total = 0;
            CALENDARIO_PAGOS_NP_CLIENTERow[] rows = sesion.Db.CALENDARIO_PAGOS_NP_CLIENTECollection.GetByNOTA_PEDIDO_CLIENTE_ID(pedido_cliente_id);
            
            for (int i = 0; i < rows.Length; i++)
                total += rows[i].MONTO_CAPITAL;
            
            return total;
        }
        #endregion GetTotal

        #region CrearCuotas
        public static void CrearCuotas(decimal pedido_cliente_id, decimal monto_cuota, DateTime fecha_base)
        { 
            using (SessionService sesion = new SessionService())
            {
                CrearCuotas(pedido_cliente_id, monto_cuota, fecha_base, sesion);
            }
        }

        public static void CrearCuotas(decimal pedido_cliente_id, decimal monto_cuota, DateTime fecha_base, SessionService sesion)
        {
            if (monto_cuota <= 0)
                throw new Exception("El monto de la cuota debe ser mayor a 0.");

            DataTable dtPedido = NotasDePedidosService.GetPedidoDeClienteDataTable(NotasDePedidosService.ID_NombreCol + " = " + pedido_cliente_id, string.Empty, sesion);
            DataTable dtCondicionPago = CondicionesPagoService.GetCondicionesDataTable(CondicionesPagoService.Id_NombreCol + " = " + dtPedido.Rows[0][NotasDePedidosService.CONDICION_PAGO_ID_NombreCol], false);

            int cantidadCuotas = Convert.ToInt32(dtCondicionPago.Rows[0][CondicionesPagoService.CantidadPagos_NombreCol]);

            //Se borran las cuotas existentes
            CalendarioPagosNPClienteService.BorrarPorPedido(pedido_cliente_id);

            for (int i = 0; i < cantidadCuotas; i++)
            {
                Hashtable campos = new Hashtable();

                campos.Add(CalendarioPagosNPClienteService.NotaPedidoClienteId_NombreCol, pedido_cliente_id);
                campos.Add(CalendarioPagosNPClienteService.MontoCapital_NombreCol, monto_cuota);
                campos.Add(CalendarioPagosNPClienteService.MontoInteres_NombreCol, (decimal)0);
                campos.Add(CalendarioPagosNPClienteService.NumeroCuota_NombreCol, (decimal)1 + i);
                campos.Add(CalendarioPagosNPClienteService.FechaVencimiento_NombreCol, CondicionesPagoService.GetVencimiento((decimal)dtCondicionPago.Rows[0][CondicionesPagoService.Id_NombreCol], i + 1, fecha_base));

                CalendarioPagosNPClienteService.Guardar(campos, sesion);
            }
        }
        #endregion CrearCuotas

        #region AgregarCuotaNueva
        /// <summary>
        /// Agregars the cuota.
        /// </summary>
        /// <param name="pedido_cliente_id">The pedido_cliente_id.</param>
        /// <param name="monto_cuota">The monto_cuota.</param>
        /// <param name="vencimiento">The vencimiento.</param>
        /// <param name="insertar_atras">if set to <c>true</c> inserta como primera cuota, si no como ultima cuota.</param>
        public static void AgregarCuotaNueva(decimal pedido_cliente_id, decimal monto_cuota, DateTime vencimiento, bool insertar_atras)
        {
            using (SessionService sesion = new SessionService())
            {
                if (monto_cuota <= 0)
                    throw new Exception("El monto de la cuota debe ser mayor a 0.");

                DataTable dtPedido = NotasDePedidosService.GetPedidoDeClienteDataTable(pedido_cliente_id);
                CALENDARIO_PAGOS_NP_CLIENTERow[] rows = sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.GetAsArray(CalendarioPagosNPClienteService.NotaPedidoClienteId_NombreCol + " = " + pedido_cliente_id, CalendarioPagosNPClienteService.NumeroCuota_NombreCol);

                if (rows.Length <= 0)
                    throw new Exception("No existe cuotas definidas.");

                //Validar que el vencimiento sera el primero o el ultimo
                if (insertar_atras)
                {
                    if (rows[rows.Length - 1].FECHA_VENCIMIENTO > vencimiento)
                        throw new Exception("Si desea insertar la cuota al final, la fecha de vencimiento debe ser posterior al " + rows[rows.Length - 1].FECHA_VENCIMIENTO.ToShortDateString());
                }
                else
                {
                    if (rows[0].FECHA_VENCIMIENTO < vencimiento)
                        throw new Exception("Si desea insertar la cuota al inicio, la fecha de vencimiento debe ser anterior al " + rows[0].FECHA_VENCIMIENTO.ToShortDateString());
                }

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].NUMERO_CUOTA++;
                    sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.Update(rows[i]);
                }

                #region guardar nueva cuota
                Hashtable campos = new Hashtable();

                campos.Add(CalendarioPagosNPClienteService.NotaPedidoClienteId_NombreCol, pedido_cliente_id);
                campos.Add(CalendarioPagosNPClienteService.MontoCapital_NombreCol, monto_cuota);
                campos.Add(CalendarioPagosNPClienteService.MontoInteres_NombreCol, (decimal)0);
                campos.Add(CalendarioPagosNPClienteService.NumeroCuota_NombreCol, insertar_atras ? (decimal)2 + rows.Length : (decimal)1);
                campos.Add(CalendarioPagosNPClienteService.FechaVencimiento_NombreCol, vencimiento);

                CalendarioPagosNPClienteService.Guardar(campos, sesion);
                #endregion guardar nueva cuota
            }
        }
        #endregion AgregarCuotaNueva

        #region AgregarMontoACuota
        /// <summary>
        /// Agregars the monto A cuota.
        /// </summary>
        /// <param name="pedido_cliente_id">The pedido_cliente_id.</param>
        /// <param name="monto_capital_agregado">The monto_capital_agregado.</param>
        /// <param name="monto_interes_agregado">The monto_interes_agregado.</param>
        /// <param name="numero_cuota">The numero_cuota.</param>
        public static void AgregarMontoACuota(decimal pedido_cliente_id, decimal monto_capital_agregado, decimal monto_interes_agregado, int numero_cuota)
        {
            using (SessionService sesion = new SessionService())
            {
                if (monto_capital_agregado + monto_interes_agregado <= 0)
                    throw new Exception("El monto agregado debe ser mayor a 0.");

                string clausulas = CalendarioPagosNPClienteService.NotaPedidoClienteId_NombreCol + " = " + pedido_cliente_id + " and " +
                                   CalendarioPagosNPClienteService.NumeroCuota_NombreCol + " = " + numero_cuota;

                CALENDARIO_PAGOS_NP_CLIENTERow[] rows = sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.GetAsArray(clausulas, string.Empty);
                string valorAnterior;

                if (rows.Length <= 0)
                    throw new Exception("No se encontró la cuota a modificar.");

                valorAnterior = rows[0].ToString();

                rows[0].MONTO_CAPITAL += monto_capital_agregado;
                rows[0].MONTO_INTERES += monto_interes_agregado;
                sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.Update(rows[0]);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[0].ID, valorAnterior, rows[0].ToString(), sesion);
            }
        }
        #endregion AgregarMontoACuota

        #region DesplazarVencimientos
        /// <summary>
        /// Desplazars the vencimientos.
        /// </summary>
        /// <param name="pedido_cliente_id">The pedido_cliente_id.</param>
        /// <param name="cantidad_desplazamiento">The cantidad_desplazamiento.</param>
        /// <param name="tipo_desplazamiento">The tipo_desplazamiento.</param>
        /// <param name="monto_capital_agregado">The monto_capital_agregado.</param>
        /// <param name="monto_interes_agregado">The monto_interes_agregado.</param>
        /// <param name="distribuir_equitativamente">Toma precedencia sobre aumentar_inicio y aumentar_final.</param>
        /// <param name="aumentar_inicio">Toma precendencia sobre aumentar_final.</param>
        /// <param name="aumentar_final">if set to <c>true</c> [aumentar_final].</param>
        public static void DesplazarVencimientos(decimal pedido_cliente_id, int cantidad_desplazamiento, string tipo_desplazamiento, decimal monto_capital_agregado, decimal monto_interes_agregado, bool distribuir_equitativamente, bool aumentar_inicio, bool aumentar_final)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = CalendarioPagosNPClienteService.NotaPedidoClienteId_NombreCol + " = " + pedido_cliente_id;

                CALENDARIO_PAGOS_NP_CLIENTERow[] rows = sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.GetAsArray(clausulas, CalendarioPagosNPClienteService.NumeroCuota_NombreCol);
                string valorAnterior;

                if (rows.Length <= 0)
                    throw new Exception("No se encontró la cuota a modificar.");

                #region agregar monto
                if (distribuir_equitativamente)
                {
                    decimal montoCapital = monto_capital_agregado / rows.Length;
                    decimal montoInteres = monto_interes_agregado / rows.Length;

                    for (int i = 0; i < rows.Length; i++)
                    {
                        valorAnterior = rows[i].ToString();
                        rows[i].MONTO_CAPITAL += montoCapital;
                        rows[i].MONTO_INTERES += montoInteres;
                        sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.Update(rows[i]);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[i].ID, valorAnterior, rows[i].ToString(), sesion);
                    }
                }
                else if (aumentar_inicio)
                {
                    valorAnterior = rows[0].ToString();
                    rows[0].MONTO_CAPITAL += monto_capital_agregado;
                    rows[0].MONTO_INTERES += monto_interes_agregado;
                    sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.Update(rows[0]);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[0].ID, valorAnterior, rows[0].ToString(), sesion);
                }
                else if (aumentar_final)
                {
                    valorAnterior = rows[rows.Length - 1].ToString();
                    rows[rows.Length - 1].MONTO_CAPITAL += monto_capital_agregado;
                    rows[rows.Length - 1].MONTO_INTERES += monto_interes_agregado;
                    sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.Update(rows[rows.Length - 1]);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[rows.Length - 1].ID, valorAnterior, rows[rows.Length - 1].ToString(), sesion);
                }
                else
                {
                    throw new NotImplementedException("CalendarioPagosNPClienteService.DesplazarVencimientos(). Configuración inconsistente");
                }
                #endregion agregar monto

                #region desplazar fecha
                switch (tipo_desplazamiento)
                {
                    case Definiciones.CondicionPagoTipoCalculo.Dias:
                        for (int i = 0; i < rows.Length; i++)
                        {
                            valorAnterior = rows[i].ToString();
                            rows[i].FECHA_VENCIMIENTO = rows[i].FECHA_VENCIMIENTO.AddDays(cantidad_desplazamiento);
                            sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.Update(rows[i]);
                            LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[i].ID, valorAnterior, rows[i].ToString(), sesion);
                        } 
                        break;
                    case Definiciones.CondicionPagoTipoCalculo.Meses:
                        for (int i = 0; i < rows.Length; i++)
                        {
                            valorAnterior = rows[i].ToString();
                            rows[i].FECHA_VENCIMIENTO = rows[i].FECHA_VENCIMIENTO.AddMonths(cantidad_desplazamiento);
                            sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.Update(rows[i]);
                            LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[i].ID, valorAnterior, rows[i].ToString(), sesion);
                        }
                        break;
                    default: throw new NotImplementedException("CalendarioPagosNPClienteService.DesplazarVencimientos(). Tipo de desplazamiento no implementado");
                }
                #endregion desplazar fecha
            }
        }
        #endregion DesplazarVencimientos

        #region ModificarVencimiento
        /// <summary>
        /// Modificars the vencimiento.
        /// </summary>
        /// <param name="calendario_pago_id">The calendario_pago_id.</param>
        /// <param name="vencimiento">The vencimiento.</param>
        public static void ModificarVencimiento(decimal calendario_pago_id, DateTime vencimiento)
        {
            using (SessionService sesion = new SessionService())
            {
                CALENDARIO_PAGOS_NP_CLIENTERow row = sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.GetByPrimaryKey(calendario_pago_id);
                string valorAnterior = row.ToString();

                row.FECHA_VENCIMIENTO = vencimiento;
                sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
        }
        #endregion ModificarVencimiento

        #region ModificarMontoCapital
        /// <summary>
        /// Modificars the monto capital.
        /// </summary>
        /// <param name="calendario_pago_id">The calendario_pago_id.</param>
        /// <param name="monto_capital">The monto_capital.</param>
        public static void ModificarMontoCapital(decimal calendario_pago_id, decimal monto_capital)
        {
            using (SessionService sesion = new SessionService())
            {
                if (monto_capital < 0)
                    throw new Exception("El monto no puede ser negativo.");

                CALENDARIO_PAGOS_NP_CLIENTERow row = sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.GetByPrimaryKey(calendario_pago_id);
                string valorAnterior = row.ToString();

                row.MONTO_CAPITAL = monto_capital;
                sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
        }
        #endregion ModificarMontoCapital

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CALENDARIO_PAGOS_NP_CLIENTE"; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return CALENDARIO_PAGOS_NP_CLIENTECollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CALENDARIO_PAGOS_NP_CLIENTECollection.IDColumnName; }
        }
        public static string MontoCapital_NombreCol
        {
            get { return CALENDARIO_PAGOS_NP_CLIENTECollection.MONTO_CAPITALColumnName; }
        }
        public static string MontoInteres_NombreCol
        {
            get { return CALENDARIO_PAGOS_NP_CLIENTECollection.MONTO_INTERESColumnName; }
        }
        public static string NotaPedidoClienteId_NombreCol
        {
            get { return CALENDARIO_PAGOS_NP_CLIENTECollection.NOTA_PEDIDO_CLIENTE_IDColumnName; }
        }
        public static string NumeroCuota_NombreCol
        {
            get { return CALENDARIO_PAGOS_NP_CLIENTECollection.NUMERO_CUOTAColumnName; }
        }
        #endregion Accessors
    }
}
