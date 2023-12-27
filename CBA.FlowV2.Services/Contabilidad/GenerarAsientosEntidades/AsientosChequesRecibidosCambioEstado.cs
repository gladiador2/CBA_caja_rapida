#region Using
using System.Collections;
using CBA.FlowV2.Services.Base;
using System;
using System.Data;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Casos;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosEntidades
{
    public class AsientosChequesRecibidosCambioEstado
    {
        #region AsentarCambioEstado
        public static void AsentarCambioEstado(decimal ctacte_cheque_recibido_id, decimal estado_anterior_id, decimal estado_nuevo_id, decimal pais_id)
        {
            using (SessionService sesion = new SessionService())
            {
                AsentarCambioEstado(ctacte_cheque_recibido_id, estado_anterior_id, estado_nuevo_id, pais_id, sesion);
            }
        }

        public static void AsentarCambioEstado(decimal ctacte_cheque_recibido_id, decimal estado_anterior_id, decimal estado_nuevo_id, decimal pais_id, SessionService sesion)
        {
            try
            {
                DataTable dtChequeRecibido = CuentaCorrienteChequesRecibidosService.GetDataTable(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + ctacte_cheque_recibido_id, string.Empty, sesion);
                CasosService caso = new CasosService((decimal)dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CasoCreadorId_NombreCol], sesion);

                DataTable dtPeriodos = PeriodosService.GetPeriodoActivoAAsentar(DateTime.Now, caso, sesion);
                if (dtPeriodos.Rows.Count <= 0)
                    throw new Exception("No se encontró un período contable activo.");

                foreach (DataRow drPeriodo in dtPeriodos.Rows)
                {
                    try
                    {
                        if (estado_anterior_id == Definiciones.CuentaCorrienteChequesEstados.Adelantado && estado_nuevo_id == Definiciones.CuentaCorrienteChequesEstados.AlDia)
                        {
                            AsientosChequesRecibidosCambioEstado.AsentarAdelantadoAAlDia(ctacte_cheque_recibido_id, caso, (decimal)drPeriodo[PeriodosService.Id_NombreCol], sesion);
                        }
                        else if (estado_anterior_id == Definiciones.CuentaCorrienteChequesEstados.AlDia && estado_nuevo_id == Definiciones.CuentaCorrienteChequesEstados.Efectivizado)
                        {
                            AsientosChequesRecibidosCambioEstado.AsentarAlDiaAEfectivizado(ctacte_cheque_recibido_id, caso, (decimal)drPeriodo[PeriodosService.Id_NombreCol], sesion);
                        }
                        else if (estado_anterior_id == Definiciones.CuentaCorrienteChequesEstados.Custodia && estado_nuevo_id == Definiciones.CuentaCorrienteChequesEstados.Depositado)
                        {
                            AsientosChequesRecibidosCambioEstado.AsentarCustodiaADepositado(ctacte_cheque_recibido_id, caso, (decimal)drPeriodo[PeriodosService.Id_NombreCol], sesion);
                        }
                        else if (estado_anterior_id == Definiciones.CuentaCorrienteChequesEstados.Negociado && estado_nuevo_id == Definiciones.CuentaCorrienteChequesEstados.Depositado)
                        {
                            AsientosChequesRecibidosCambioEstado.AsentarNegociadoADepositado(ctacte_cheque_recibido_id, caso, (decimal)drPeriodo[PeriodosService.Id_NombreCol], sesion);
                        }
                        else if (estado_anterior_id == Definiciones.CuentaCorrienteChequesEstados.Depositado && estado_nuevo_id == Definiciones.CuentaCorrienteChequesEstados.Rechazado)
                        {
                            AsientosChequesRecibidosCambioEstado.AsentarDepositadoARechazado(ctacte_cheque_recibido_id, caso, (decimal)drPeriodo[PeriodosService.Id_NombreCol], sesion);
                        }
                    }
                    catch
                    {
                        //Se continua aunque no se haya podido crear el asiento
                    }
                }
            }
            catch
            {
                //Se continua aunque no haya un periodo activo
            }
        }
        #endregion AsentarCambioEstado

        #region AsentarAdelantadoAAlDia
        /// <summary>
        /// Asentars the borrador A aprobado.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        private static void AsentarAdelantadoAAlDia(decimal ctacte_cheque_recibido_id, CasosService caso, decimal periodo_id, SessionService sesion)
        {
            DataTable dtCtacteChequeRecibido = CuentaCorrienteChequesRecibidosService.GetCuentaCorrienteChequesRecibidosInfoCompleta2(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + ctacte_cheque_recibido_id, string.Empty, sesion);
            DataTable dtAsientosDetalle = AsientosAutomaticosDetalleService.GetAsientosAutomaticosDetalleInfoCompleta(AsientosAutomaticosDetalleService.AsientoAutomaticoId_NombreCol + " = " + Definiciones.Contabilidad.AsientosAutomaticos.ChequeRecibido_Adelantado_a_AlDia + " and " + AsientosAutomaticosDetalleService.VistaCantidadCuentasRelacionadas_NombreCol + " > " + 0, AsientosAutomaticosDetalleService.Orden_NombreCol, sesion);
            
            Hashtable campos = new Hashtable();
            Hashtable sumaPorCuenta;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux = 0;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, (DateTime)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.FechaVencimiento_NombreCol], sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.TablaRelacionadaId_NombreCol, CuentaCorrienteChequesRecibidosService.Nombre_Tabla);
            campos.Add(AsientosService.RegistroRelacionadoId_NombreCol, ctacte_cheque_recibido_id);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, DateTime.Now);
            campos.Add(AsientosService.Observacion_NombreCol, "Cheque recibido " + dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaDatosResumidosSinMonto_NombreCol] + " cambiado de Adelantado a Al Día");
            campos.Add(AsientosService.RevisionPosterior_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.SucursalId_NombreCol, caso.SucursalId);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < dtAsientosDetalle.Rows.Count; i++)
            {
                switch (int.Parse(dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.ChequeRecibido_Adelantado_a_AlDia.Activo_DisminuirCaja:

                        #region calcular
                                            
                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol];

                        //Obtener el monto en la moneda del pais
                        if ((decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol] != monedaPais)
                            montoAux = montoAux / (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol] * cotizacionMonedaPais;

                        #endregion calcular

                        #region crear detalles del asiento
                        campos = new Hashtable();
                        campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                        campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                        campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                        campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                        campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                        campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                        campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol]);
                        campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol]);
                        AsientosDetalleService.Guardar(campos, true, sesion);
                        #endregion crear detalles del asiento

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.ChequeRecibido_Adelantado_a_AlDia.Activo_AumentarCaja:

                        #region calcular

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol];

                        //Obtener el monto en la moneda del pais
                        if ((decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol] != monedaPais)
                            montoAux = montoAux / (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol] * cotizacionMonedaPais;

                        #endregion calcular

                        #region crear detalles del asiento
                        campos = new Hashtable();
                        campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                        campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                        campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                        campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                        campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                        campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                        campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol]);
                        campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol]);
                        AsientosDetalleService.Guardar(campos, true, sesion);
                        #endregion crear detalles del asiento

                        break;
                }
            }
        }
        #endregion AsentarAdelantadoAAlDia

        #region AsentarAlDiaAEfectivizado
        /// <summary>
        /// Asentars the al dia A efectivizado.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        private static void AsentarAlDiaAEfectivizado(decimal ctacte_cheque_recibido_id, CasosService caso, decimal periodo_id, SessionService sesion)
        {
            DataTable dtCtacteChequeRecibido = CuentaCorrienteChequesRecibidosService.GetCuentaCorrienteChequesRecibidosInfoCompleta2(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + ctacte_cheque_recibido_id, string.Empty, sesion);
            DataTable dtAsientosDetalle = AsientosAutomaticosDetalleService.GetAsientosAutomaticosDetalleInfoCompleta(AsientosAutomaticosDetalleService.AsientoAutomaticoId_NombreCol + " = " + Definiciones.Contabilidad.AsientosAutomaticos.ChequeRecibido_AlDia_a_Efectivizado + " and " + AsientosAutomaticosDetalleService.VistaCantidadCuentasRelacionadas_NombreCol + " > " + 0, AsientosAutomaticosDetalleService.Orden_NombreCol, sesion);

            Hashtable campos = new Hashtable();
            Hashtable sumaPorCuenta;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux = 0;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, (DateTime)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.FechaVencimiento_NombreCol], sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.TablaRelacionadaId_NombreCol, CuentaCorrienteChequesRecibidosService.Nombre_Tabla);
            campos.Add(AsientosService.RegistroRelacionadoId_NombreCol, ctacte_cheque_recibido_id);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, DateTime.Now);
            campos.Add(AsientosService.Observacion_NombreCol, "Cheque recibido " + dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaDatosResumidosSinMonto_NombreCol] + " cambiado de Al Día a Efectivizado.");
            campos.Add(AsientosService.RevisionPosterior_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.SucursalId_NombreCol, caso.SucursalId);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < dtAsientosDetalle.Rows.Count; i++)
            {
                switch (int.Parse(dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.ChequeRecibido_AlDia_a_Efectivizado.Activo_DisminuirCaja:

                        #region calcular

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol];

                        //Obtener el monto en la moneda del pais
                        if ((decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol] != monedaPais)
                            montoAux = montoAux / (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol] * cotizacionMonedaPais;

                        #endregion calcular

                        #region crear detalles del asiento
                        campos = new Hashtable();
                        campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                        campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                        campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                        campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                        campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                        campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                        campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol]);
                        campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol]);
                        AsientosDetalleService.Guardar(campos, true, sesion);
                        #endregion crear detalles del asiento

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.ChequeRecibido_AlDia_a_Efectivizado.Activo_AumentarCaja:

                        #region calcular

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol];

                        //Obtener el monto en la moneda del pais
                        if ((decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol] != monedaPais)
                            montoAux = montoAux / (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol] * cotizacionMonedaPais;

                        #endregion calcular

                        #region crear detalles del asiento
                        campos = new Hashtable();
                        campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                        campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                        campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                        campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                        campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                        campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                        campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol]);
                        campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol]);
                        AsientosDetalleService.Guardar(campos, true, sesion);
                        #endregion crear detalles del asiento

                        break;
                }
            }
        }
        #endregion AsentarAlDiaAEfectivizado

        #region AsentarCustodiaADepositado
        /// <summary>
        /// Asentars the custodia A depositado.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        private static void AsentarCustodiaADepositado(decimal ctacte_cheque_recibido_id, CasosService caso, decimal periodo_id, SessionService sesion)
        {
            DataTable dtCtacteChequeRecibido = CuentaCorrienteChequesRecibidosService.GetCuentaCorrienteChequesRecibidosInfoCompleta2(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + ctacte_cheque_recibido_id, string.Empty, sesion);
            DataTable dtAsientosDetalle = AsientosAutomaticosDetalleService.GetAsientosAutomaticosDetalleInfoCompleta(AsientosAutomaticosDetalleService.AsientoAutomaticoId_NombreCol + " = " + Definiciones.Contabilidad.AsientosAutomaticos.ChequeRecibido_Custodia_a_Depositado + " and " + AsientosAutomaticosDetalleService.VistaCantidadCuentasRelacionadas_NombreCol + " > " + 0, AsientosAutomaticosDetalleService.Orden_NombreCol, sesion);

            Hashtable campos = new Hashtable();
            Hashtable sumaPorCuenta;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux = 0;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, (DateTime)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.FechaVencimiento_NombreCol], sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.TablaRelacionadaId_NombreCol, CuentaCorrienteChequesRecibidosService.Nombre_Tabla);
            campos.Add(AsientosService.RegistroRelacionadoId_NombreCol, ctacte_cheque_recibido_id);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, DateTime.Now);
            campos.Add(AsientosService.Observacion_NombreCol, "Cheque recibido " + dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaDatosResumidosSinMonto_NombreCol] + " cambiado de Custodia a Depositado.");
            campos.Add(AsientosService.RevisionPosterior_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.SucursalId_NombreCol, caso.SucursalId);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < dtAsientosDetalle.Rows.Count; i++)
            {
                switch (int.Parse(dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.ChequeRecibido_Custodia_a_Depositado.Activo_DisminuirCaja:

                        #region calcular

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol];

                        //Obtener el monto en la moneda del pais
                        if ((decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol] != monedaPais)
                            montoAux = montoAux / (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol] * cotizacionMonedaPais;

                        #endregion calcular

                        #region crear detalles del asiento
                        campos = new Hashtable();
                        campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                        campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                        campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                        campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                        campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                        campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                        campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol]);
                        campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol]);
                        AsientosDetalleService.Guardar(campos, true, sesion);
                        #endregion crear detalles del asiento

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.ChequeRecibido_Custodia_a_Depositado.Activo_AumentarCaja:

                        #region calcular

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol];

                        //Obtener el monto en la moneda del pais
                        if ((decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol] != monedaPais)
                            montoAux = montoAux / (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol] * cotizacionMonedaPais;

                        #endregion calcular

                        #region crear detalles del asiento
                        campos = new Hashtable();
                        campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                        campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                        campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                        campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                        campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                        campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                        campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol]);
                        campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol]);
                        AsientosDetalleService.Guardar(campos, true, sesion);
                        #endregion crear detalles del asiento

                        break;
                }
            }
        }
        #endregion AsentarCustodiaADepositado

        #region AsentarNegociadoADepositado
        /// <summary>
        /// Asentars the negociado A depositado.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        private static void AsentarNegociadoADepositado(decimal ctacte_cheque_recibido_id, CasosService caso, decimal periodo_id, SessionService sesion)
        {
            DataTable dtCtacteChequeRecibido = CuentaCorrienteChequesRecibidosService.GetCuentaCorrienteChequesRecibidosInfoCompleta2(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + ctacte_cheque_recibido_id, string.Empty, sesion);
            DataTable dtAsientosDetalle = AsientosAutomaticosDetalleService.GetAsientosAutomaticosDetalleInfoCompleta(AsientosAutomaticosDetalleService.AsientoAutomaticoId_NombreCol + " = " + Definiciones.Contabilidad.AsientosAutomaticos.ChequeRecibido_Negociado_a_Depositado + " and " + AsientosAutomaticosDetalleService.VistaCantidadCuentasRelacionadas_NombreCol + " > " + 0, AsientosAutomaticosDetalleService.Orden_NombreCol, sesion);

            Hashtable campos = new Hashtable();
            Hashtable sumaPorCuenta;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux = 0;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, (DateTime)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.FechaVencimiento_NombreCol], sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.TablaRelacionadaId_NombreCol, CuentaCorrienteChequesRecibidosService.Nombre_Tabla);
            campos.Add(AsientosService.RegistroRelacionadoId_NombreCol, ctacte_cheque_recibido_id);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, DateTime.Now);
            campos.Add(AsientosService.Observacion_NombreCol, "Cheque recibido " + dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaDatosResumidosSinMonto_NombreCol] + " cambiado de Negociado a Depositado.");
            campos.Add(AsientosService.RevisionPosterior_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.SucursalId_NombreCol, caso.SucursalId);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < dtAsientosDetalle.Rows.Count; i++)
            {
                switch (int.Parse(dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.ChequeRecibido_Negociado_a_Depositado.Activo_DisminuirNegociado:

                        #region calcular

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol];

                        //Obtener el monto en la moneda del pais
                        if ((decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol] != monedaPais)
                            montoAux = montoAux / (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol] * cotizacionMonedaPais;

                        #endregion calcular

                        #region crear detalles del asiento
                        campos = new Hashtable();
                        campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                        campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                        campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                        campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                        campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                        campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                        campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol]);
                        campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol]);
                        AsientosDetalleService.Guardar(campos, true, sesion);
                        #endregion crear detalles del asiento

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.ChequeRecibido_Negociado_a_Depositado.Activo_AumentarBanco:

                        #region calcular

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol];

                        //Obtener el monto en la moneda del pais
                        if ((decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol] != monedaPais)
                            montoAux = montoAux / (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol] * cotizacionMonedaPais;

                        #endregion calcular

                        #region crear detalles del asiento
                        campos = new Hashtable();
                        campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                        campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                        campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                        campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                        campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                        campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                        campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol]);
                        campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol]);
                        AsientosDetalleService.Guardar(campos, true, sesion);
                        #endregion crear detalles del asiento

                        break;
                }
            }
        }
        #endregion AsentarNegociadoADepositado

        #region AsentarDepositadoARechazado
        /// <summary>
        /// Asentars the depositado a rechazado.
        /// </summary>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <exception cref="System.Exception">No se encontró un período contable activo.</exception>
        private static void AsentarDepositadoARechazado(decimal ctacte_cheque_recibido_id, CasosService caso, decimal periodo_id, SessionService sesion)
        {
            DataTable dtCtacteChequeRecibido = CuentaCorrienteChequesRecibidosService.GetCuentaCorrienteChequesRecibidosInfoCompleta2(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + ctacte_cheque_recibido_id, string.Empty, sesion);
            DataTable dtAsientosDetalle = AsientosAutomaticosDetalleService.GetAsientosAutomaticosDetalleInfoCompleta(AsientosAutomaticosDetalleService.AsientoAutomaticoId_NombreCol + " = " + Definiciones.Contabilidad.AsientosAutomaticos.ChequeRecibido_Depositado_a_Rechazado + " and " + AsientosAutomaticosDetalleService.VistaCantidadCuentasRelacionadas_NombreCol + " > " + 0, AsientosAutomaticosDetalleService.Orden_NombreCol, sesion);

            Hashtable campos = new Hashtable();
            Hashtable sumaPorCuenta;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux = 0;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, (DateTime)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.FechaVencimiento_NombreCol], sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.TablaRelacionadaId_NombreCol, CuentaCorrienteChequesRecibidosService.Nombre_Tabla);
            campos.Add(AsientosService.RegistroRelacionadoId_NombreCol, ctacte_cheque_recibido_id);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, DateTime.Now);
            campos.Add(AsientosService.Observacion_NombreCol, "Cheque recibido " + dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaDatosResumidosSinMonto_NombreCol] + " cambiado de Depositado a Rechazado.");
            campos.Add(AsientosService.RevisionPosterior_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.SucursalId_NombreCol, caso.SucursalId);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < dtAsientosDetalle.Rows.Count; i++)
            {
                switch (int.Parse(dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.ChequeRecibido_Depositado_a_Rechazado.Activo_DisminuirBanco:

                        #region calcular

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol];

                        //Obtener el monto en la moneda del pais
                        if ((decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol] != monedaPais)
                            montoAux = montoAux / (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol] * cotizacionMonedaPais;

                        #endregion calcular

                        #region crear detalles del asiento
                        campos = new Hashtable();
                        campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                        campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                        campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                        campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                        campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                        campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                        campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol]);
                        campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol]);
                        AsientosDetalleService.Guardar(campos, true, sesion);
                        #endregion crear detalles del asiento

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.ChequeRecibido_Depositado_a_Rechazado.Activo_AumentarCaja:

                        #region calcular

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaPersonaId_NombreCol]);
                        if (dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol] != null && !dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol].Equals(DBNull.Value))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaProveedorId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol];

                        //Obtener el monto en la moneda del pais
                        if ((decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol] != monedaPais)
                            montoAux = montoAux / (decimal)dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol] * cotizacionMonedaPais;

                        #endregion calcular

                        #region crear detalles del asiento
                        campos = new Hashtable();
                        campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                        campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                        campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                        campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                        campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                        campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                        campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol]);
                        campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, dtCtacteChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol]);
                        campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol]);
                        AsientosDetalleService.Guardar(campos, true, sesion);
                        #endregion crear detalles del asiento

                        break;
                }
            }
        }
        #endregion AsentarDepositadoARechazado
    }
}
