using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using System.Collections;
using CBA.FlowV2.Services.Common;
using System.Collections.Generic;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class AjustesBancariosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.AJUSTE_BANCARIO;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var drCabecera = (DataRow)caso_cabecera;
            var drDetalle = (DataRow)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);

            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, );
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, drDetalle[AjustesBancariosDetalleService.TextoPredefinidoId_NombreCol]);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza las acciones necesarias al cambiar de estado un caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_destino">The estado_destino.</param>
        /// <param name="cambio_pedido_por_usuario">El cambio fue pedido por el usuario o por el sistema</param>
        /// <param name="mensaje">The mensaje de salida.</param>
        /// <returns>
        /// True si no los controles se ejecutaron exitosamente, si no false.
        /// </returns>
        public override bool ProcesarCambioEstado(decimal caso_id, string estado_destino, bool cambio_pedido_por_usuario, out string mensaje, SessionService sesion)
        {
                bool exito = false;
                bool revisarRequisitos = false;
                mensaje = string.Empty;
                try
                {
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    AJUSTES_BANCARIOSRow cabeceraRow = sesion.Db.AJUSTES_BANCARIOSCollection.GetByCASO_ID(caso_id)[0];
                    AJUSTES_BANCARIOS_DETRow[] detalleRows = sesion.Db.AJUSTES_BANCARIOS_DETCollection.GetByAJUSTE_BANCARIO_ID(cabeceraRow.ID);

                    //Borrador a Anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    //Borrador a Pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;

                        if (detalleRows.Length <= 0)
                        {
                            exito = false;
                            mensaje = "El caso no contiene detalles.";
                        }
                    }
                    //Pendiente a Borrador 
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;

                    }
                    //Pendiente a Anulado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    //Pendiente a Aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado

                        if (detalleRows.Length <= 0)
                        {
                            exito = false;
                            mensaje = "El caso no contiene detalles.";
                        }
                    }
                    //Aprobado a Pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado

                        if (detalleRows.Length <= 0)
                        {
                            exito = false;
                            mensaje = "El caso no contiene detalles.";
                        }
                    }
                    //Aprobado a Cerrado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Se verifica que el caso de ajuste en cuestion no pertenezca a ninguna orden de pago.
                        if (cambio_pedido_por_usuario)
                        {
                            #region Verificar Puede Avanzar Estado
                            if (exito)
                            {
                                exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                            }
                            #endregion Verificar Puede Avanzar Estado

                            DataTable dt = OrdenesPagoValoresService.GetOrdenesPagoValoresDataTable(OrdenesPagoValoresService.AjusteBancarioId_NombreCol + " = " + cabeceraRow.ID, string.Empty, sesion);
                            if (dt.Rows.Count > 0)
                                throw new Exception("No se puede aprobar el caso de ajuste bancario. El mismo pertenece a una orden de pago.");
                        }

                        //Acciones
                        //Se crea el movimiento bancario que afecta al saldo de la cuenta.
                        exito = true;
                        revisarRequisitos = true;

                        DataTable dtCtacteBancaria = CuentaCorrienteCuentasBancariasService.GetCuentaCorrienteBancariasDataTable(CuentaCorrienteCuentasBancariasService.Id_NombreCol + " = " + cabeceraRow.CTACTE_BANCARIA_ID, string.Empty, true);
                        SucursalesService sucursal = new SucursalesService();
                        decimal cotizacion;
                        decimal totalEgreso, totalIngreso;

                        if (detalleRows.Length <= 0)
                        {
                            exito = false;
                            mensaje = "El caso no contiene detalles.";
                        }

                        //Se obtiene la cotizacion
                        if (!Interprete.EsNullODBNull(dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.SucursalId_NombreCol]))
                            cotizacion = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.SucursalId_NombreCol]), (decimal)dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol], cabeceraRow.FECHA, sesion);
                        else
                            cotizacion = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(casoRow.SUCURSAL_ID), (decimal)dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol], cabeceraRow.FECHA, sesion);

                        if (cotizacion.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        {
                            exito = false;
                            mensaje = "Debe actualizar la cotización de la moneda de la cuenta bancaria.";
                        }

                        if (exito)
                        {
                            AjustesBancariosService.GetTotales(cabeceraRow.ID, out totalIngreso, out totalEgreso, sesion);

                            if (totalEgreso > 0)
                            {
                                CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                    cabeceraRow.CTACTE_BANCARIA_ID,
                                    Definiciones.FlujosIDs.AJUSTE_BANCARIO,
                                    cabeceraRow.CASO_ID,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    cabeceraRow.ID,
                                    (decimal)dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol],
                                    totalEgreso * (-1),
                                    cotizacion,
                                    cabeceraRow.FECHA,
                                    "Caso " + cabeceraRow.CASO_ID + " de Ajuste Bancario pasado al estado " + estado_destino + ".",
                                    null,
                                    null,
                                    false,
                                    sesion);
                            }

                            if (totalIngreso > 0)
                            {
                                CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                    cabeceraRow.CTACTE_BANCARIA_ID,
                                    Definiciones.FlujosIDs.AJUSTE_BANCARIO,
                                    cabeceraRow.CASO_ID,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    cabeceraRow.ID,
                                    (decimal)dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol],
                                    totalIngreso,
                                    cotizacion,
                                    cabeceraRow.FECHA,
                                    "Caso " + cabeceraRow.CASO_ID + " de Ajuste Bancario pasado al estado " + estado_destino + ".",
                                    null,
                                    null,
                                    false,
                                    sesion);
                            }
                        }
                    }
                    //Cerrado a Aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Cerrado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Se verifica que el caso de ajuste en cuestion no pertenezca a ninguna orden de pago.
                        if (cambio_pedido_por_usuario)
                        {
                            #region Verificar Puede Avanzar Estado
                            if (exito)
                            {
                                exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                            }
                            #endregion Verificar Puede Avanzar Estado

                            DataTable dt = OrdenesPagoValoresService.GetOrdenesPagoValoresDataTable(OrdenesPagoValoresService.AjusteBancarioId_NombreCol + " = " + cabeceraRow.ID, string.Empty, sesion);
                            if (dt.Rows.Count > 0)
                            {
                                dt = OrdenesPagoService.GetOrdenesPagoInfoCompleta(OrdenesPagoService.Id_NombreCol + " = " + dt.Rows[0][OrdenesPagoValoresService.OrdenPagoId_NombreCol], string.Empty, sesion);
                                if((string)dt.Rows[0][OrdenesPagoService.VistaCasoEstadoId_NombreCol] != Definiciones.EstadosFlujos.Anulado)
                                    throw new Exception("No se puede aprobar el caso de ajuste bancario. El mismo está vinculado a la OP caso " + dt.Rows[0][OrdenesPagoService.CasoId_NombreCol] + ".");
                            }
                        }

                        //Acciones
                        //Se crea el movimiento inverso que afecta al saldo de la cuenta.
                        exito = true;
                        revisarRequisitos = true;

                        DataTable dtCtacteBancaria = CuentaCorrienteCuentasBancariasService.GetCuentaCorrienteBancariasDataTable(CuentaCorrienteCuentasBancariasService.Id_NombreCol + " = " + cabeceraRow.CTACTE_BANCARIA_ID, string.Empty, true);
                        SucursalesService sucursal = new SucursalesService();
                        decimal cotizacion;
                        decimal totalEgreso, totalIngreso;

                        if (detalleRows.Length <= 0)
                        {
                            exito = false;
                            mensaje = "El caso no contiene detalles.";
                        }

                        //Se obtiene la cotizacion
                        if (!Interprete.EsNullODBNull(dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.SucursalId_NombreCol]))
                            cotizacion = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.SucursalId_NombreCol]), (decimal)dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol], cabeceraRow.FECHA, sesion);
                        else
                            cotizacion = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(casoRow.SUCURSAL_ID), (decimal)dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol], cabeceraRow.FECHA, sesion);

                        if (cotizacion.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        {
                            exito = false;
                            mensaje = "Debe actualizar la cotización de la moneda de la cuenta bancaria.";
                        }

                        if (exito)
                        {
                            AjustesBancariosService.GetTotales(cabeceraRow.ID, out totalIngreso, out totalEgreso, sesion);

                            if (totalEgreso > 0)
                            {
                                CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                    cabeceraRow.CTACTE_BANCARIA_ID,
                                    Definiciones.FlujosIDs.AJUSTE_BANCARIO,
                                    cabeceraRow.CASO_ID,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    cabeceraRow.ID,
                                    (decimal)dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol],
                                    totalEgreso,
                                    cotizacion,
                                    cabeceraRow.FECHA,
                                    "Caso " + cabeceraRow.CASO_ID + " de Ajuste Bancario pasado del estado " + casoRow.ESTADO_ID + " a " + estado_destino + ".",
                                    null,
                                    null,
                                    true,
                                    sesion);
                            }

                            if (totalIngreso > 0)
                            {
                                CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                    cabeceraRow.CTACTE_BANCARIA_ID,
                                    Definiciones.FlujosIDs.AJUSTE_BANCARIO,
                                    cabeceraRow.CASO_ID,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    cabeceraRow.ID,
                                    (decimal)dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol],
                                    totalIngreso * (-1),
                                    cotizacion,
                                    cabeceraRow.FECHA,
                                    "Caso " + cabeceraRow.CASO_ID + " de Ajuste Bancario pasado del estado " + casoRow.ESTADO_ID + " a " + estado_destino + ".",
                                    null,
                                    null,
                                    true,
                                    sesion);
                            }

                            //Borrar el asiento que se creo
                            CBA.FlowV2.Services.Contabilidad.AsientosService.BorrarPorCasoYTransicion(
                            cabeceraRow.CASO_ID,
                            TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.AJUSTE_BANCARIO, Definiciones.EstadosFlujos.Aprobado, Definiciones.EstadosFlujos.Cerrado, sesion),
                            sesion);
                        }
                    }

                    //Verificar si se cumplen los requisitos
                    if (exito && revisarRequisitos)
                    {
                        exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                    }

                    if (exito)
                    {
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.AJUSTES_BANCARIOSCollection.Update(cabeceraRow);
                    }
                }
                catch (Exception exp)
                {
                    exito = false;
                    throw exp;
                }
                return exito;
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza acciones necesarias una vez que se efectuo el cambio de estado
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion) { }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Obtener el numero de comprobante
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns>String con el numero de comprobante</returns>
        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion) 
        {
            return string.Empty;
        }

        #endregion Implementacion de metodos abstract

        #region GetAjustesBancariosDataTable
        /// <summary>
        /// Gets the ajustes bancarios data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAjustesBancariosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAjustesBancariosDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetAjustesBancariosDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.AJUSTES_BANCARIOSCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAjustesBancariosDataTable

        #region GetAjustesBancariosInfoCompleta
        /// <summary>
        /// Gets the ajustes bancarios info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAjustesBancariosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAjustesBancariosInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetAjustesBancariosInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.AJUSTES_BANCARIOS_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAjustesBancariosDataTable

        #region GetOrdenesPago
        /// <summary>
        /// Gets the ajustes bancarios.
        /// </summary>
        /// <param name="ajuste_bancario_id">The ajuste_bancario_id.</param>
        /// <returns></returns>
        public static AJUSTES_BANCARIOSRow GetAjustesBancarios(decimal ajuste_bancario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.AJUSTES_BANCARIOSCollection.GetByPrimaryKey(ajuste_bancario_id);
            }
        }
        #endregion GetOrdenesPago

        #region GetAjustesBancariosPorCaso
        /// <summary>
        /// Gets the ajustes bancarios por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static DataTable GetAjustesBancariosPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.AJUSTES_BANCARIOSCollection.GetAsDataTable(AjustesBancariosService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetAjustesBancariosPorCaso

        #region VerificarPuedeAvanzarEstado
        public static bool VerificarPuedeAvanzarEstado(decimal caso_id, out string mensaje, SessionService sesion)
        {
            return FlujosService.VerificarPuedeAvanzarEstado(caso_id, out mensaje, "AJUSTES BANCARIOS NO CONTROLAR MARGEN DIAS PUEDE AVANZAR", Definiciones.VariablesDeSistema.AjustesBancariosMargenDiasPuedeAvanzar, sesion);
        }
        #endregion VerificarPuedeAvanzarEstado

        #region ActualizarTotal
        public static void ActualizarTotal(decimal ajuste_bancario_id, SessionService sesion)
        {
            AJUSTES_BANCARIOSRow row = sesion.Db.AJUSTES_BANCARIOSCollection.GetByPrimaryKey(ajuste_bancario_id);
            DataTable dtDetalles = sesion.Db.AJUSTES_BANCARIOS_DETCollection.GetByAJUSTE_BANCARIO_IDAsDataTable(ajuste_bancario_id);
            decimal total = 0;
            string valorAnterior = row.TOTAL.ToString();

            for (int i = 0; i < dtDetalles.Rows.Count; i++)
                total += (decimal)dtDetalles.Rows[i][AjustesBancariosDetalleService.Monto_NombreCol];

            row.TOTAL = total;

            decimal cotizacion = CotizacionesService.GetCotizacionMonedaVenta(CuentaCorrienteCuentasBancariasService.GetMoneda(row.CTACTE_BANCARIA_ID));

            row.COTIZACION = cotizacion;
            
            sesion.Db.AJUSTES_BANCARIOSCollection.Update(row);
            LogCambiosService.LogDeColumna(Nombre_Tabla, AjustesBancariosService.Total_NombreCol, row.ID, valorAnterior, row.TOTAL.ToString(), sesion);
        }
        #endregion ActualizarTotal

        #region GetTotales
        /// <summary>
        /// Gets the totales.
        /// </summary>
        /// <param name="ajuste_bancario_id">The ajuste_bancario_id.</param>
        /// <param name="total_credito">The total_credito.</param>
        /// <param name="total_debito">The total_debito.</param>
        /// <param name="sesion">The sesion.</param>
        public static void GetTotales(decimal ajuste_bancario_id, out decimal total_credito, out decimal total_debito, SessionService sesion)
        {
            DataTable dtDetalles = sesion.Db.AJUSTES_BANCARIOS_DETCollection.GetByAJUSTE_BANCARIO_IDAsDataTable(ajuste_bancario_id);
            total_credito = 0;
            total_debito = 0;

            for (int i = 0; i < dtDetalles.Rows.Count; i++)
            {
                if ((decimal)dtDetalles.Rows[i][AjustesBancariosDetalleService.Monto_NombreCol] < 0)
                    total_debito += (decimal)dtDetalles.Rows[i][AjustesBancariosDetalleService.Monto_NombreCol];
                else
                    total_credito += (decimal)dtDetalles.Rows[i][AjustesBancariosDetalleService.Monto_NombreCol];
            }

            //Se pasa el debito de negativo a positivo
            total_debito *= (-1);
        }
        #endregion GetTotales

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id) {
            string dummmy = string.Empty;
            return Guardar(campos, insertarNuevo, ref caso_id, ref estado_id, ref dummmy);
        }
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id, ref string id_creado)
        {
            using (SessionService sesion = new SessionService()) {
                bool exito = false;
                AJUSTES_BANCARIOSRow row = new AJUSTES_BANCARIOSRow();

                try {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo) {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(sesion.SucursalActiva.ID.ToString()), //Se toma la sucursal del usuario que crea el caso y no de la cuenta bancaria
                                                              int.Parse(Definiciones.FlujosIDs.AJUSTE_BANCARIO.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("ajustes_bancarios_sqc");
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    } else {
                        row = sesion.Db.AJUSTES_BANCARIOSCollection.GetRow(AjustesBancariosService.Id_NombreCol + " = " + campos[AjustesBancariosService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }


                    //Si cambia, se controla que la nueva se encuentre activa
                    if (row.CTACTE_BANCARIA_ID.Equals(DBNull.Value) ||
                        !row.CTACTE_BANCARIA_ID.Equals(campos[AjustesBancariosService.CtacteBancariaId_NombreCol])) {
                        row.CTACTE_BANCARIA_ID = (decimal)campos[AjustesBancariosService.CtacteBancariaId_NombreCol];
                    }

                    row.FECHA = (DateTime)campos[AjustesBancariosService.Fecha_NombreCol];
                    row.OBSERVACION = (string)campos[OrdenesPagoService.Observacion_NombreCol];

                    //row.TOTAL = ; //tomar el total del service detalles

                    if (insertarNuevo) sesion.Db.AJUSTES_BANCARIOSCollection.Insert(row);
                    else sesion.Db.AJUSTES_BANCARIOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    
                    id_creado = row.ID.ToString();

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    exito = true;
                } catch (Exception) {
                    //Si el caso fue creado el mismo debe borrarse
                    if (insertarNuevo && row.CASO_ID > 0) {
                        (new CasosService()).Eliminar(row.CASO_ID, sesion);
                        caso_id = Definiciones.Error.Valor.EnteroPositivo;
                        estado_id = string.Empty;
                    }

                    throw;
                }
                return exito;
            }
        }

        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borra de la base de datos el caso y la cabecera del flujo
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public static bool Borrar(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    bool exito = true;
                    string mensaje = string.Empty;

                    //Se obtienen el caso y la factura a ser borrados
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    AJUSTES_BANCARIOSRow cabecera = sesion.Db.AJUSTES_BANCARIOSCollection.GetByCASO_ID(caso_id)[0];

                    if (! caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Se obtienen los detalles del caso a ser borrados.
                    DataTable detalles = AjustesBancariosService.GetAjustesBancariosDataTable(AjustesBancariosService.Id_NombreCol + " = " + cabecera.ID, string.Empty);

                    //Si el caso posee detalles no puede ser borrado
                    if (detalles.Rows.Count > 0)
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que posee detalles.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.AJUSTES_BANCARIOSCollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                        //Se borra el caso
                        (new CasosService()).Eliminar(caso_id, sesion); 
                    }
                    else
                    {
                        throw new System.ArgumentException(mensaje);
                    }

                    sesion.CommitTransaction();
                    return exito;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "AJUSTES_BANCARIOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "AJUSTES_BANCARIOS_INFO_COMPL"; }
        }
        public static string CasoId_NombreCol
        {
            get { return AJUSTES_BANCARIOSCollection.CASO_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return AJUSTES_BANCARIOSCollection.COTIZACIONColumnName; }
        }
        public static string CtacteBancariaId_NombreCol
        {
            get { return AJUSTES_BANCARIOSCollection.CTACTE_BANCARIA_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return AJUSTES_BANCARIOSCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return AJUSTES_BANCARIOSCollection.IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return AJUSTES_BANCARIOSCollection.OBSERVACIONColumnName; }
        }
        public static string Total_NombreCol
        {
            get { return AJUSTES_BANCARIOSCollection.TOTALColumnName; }
        }
        public static string VistaBancoAbreviatura_NombreCol
        {
            get { return AJUSTES_BANCARIOS_INFO_COMPLCollection.BANCO_ABREVIATURAColumnName; }
        }
        public static string VistaBancoNombre_NombreCol
        {
            get { return AJUSTES_BANCARIOS_INFO_COMPLCollection.BANCO_NOMBREColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return AJUSTES_BANCARIOS_INFO_COMPLCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCtacteBancariaNumeroCuenta_NombreCol
        {
            get { return AJUSTES_BANCARIOS_INFO_COMPLCollection.CTACTE_BANCARIA_NUMERO_CUENTAColumnName; }
        }
        public static string VistaCtacteBancoId_NombreCol
        {
            get { return AJUSTES_BANCARIOS_INFO_COMPLCollection.CTACTE_BANCO_IDColumnName; }
        }
        public static string VistaMonedaId_NombreCol
        {
            get { return AJUSTES_BANCARIOS_INFO_COMPLCollection.MONEDA_IDColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return AJUSTES_BANCARIOS_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaMoneda_NombreCol
        {
            get { return AJUSTES_BANCARIOS_INFO_COMPLCollection.MONEDAColumnName; }
        }
        public static string VistaSucursalId_NombreCol
        {
            get { return AJUSTES_BANCARIOS_INFO_COMPLCollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return AJUSTES_BANCARIOS_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
