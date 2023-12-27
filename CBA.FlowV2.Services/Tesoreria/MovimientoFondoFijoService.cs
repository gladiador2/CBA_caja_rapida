#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.RecursosHumanos;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class MovimientoFondoFijoService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de Metodos Heredados
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.MOVIMIENTO_FONDO_FIJO;
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
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, drDetalle[MovimientoFondoFijoDetalleService.TextoPredefinidoId_NombreCol]);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }

        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            MOVIMIENTO_FONDO_FIJORow[] rows;
            rows = sesion.Db.MOVIMIENTO_FONDO_FIJOCollection.GetByCASO_ID(caso_id);
            if (rows.Length == 1)
            {
                return rows[0].NRO_COMPROBANTE.ToString();
            }
            else
            {
                return string.Empty;
            }
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
                mensaje = string.Empty;
                bool exito = false;
                bool revisarRequisitos = false;
                mensaje = "";
                decimal transicionId;

                try
                {
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    MOVIMIENTO_FONDO_FIJORow cabeceraRow = sesion.Db.MOVIMIENTO_FONDO_FIJOCollection.GetByCASO_ID(caso_id)[0];
                    string clausula = MovimientoFondoFijoDetalleService.MovimientoFondoFijoId_NombreCol +"="+ cabeceraRow.ID;
                    DataTable dtMovimientoFondoFijoDetalles = MovimientoFondoFijoDetalleService.GetMovimientoFondoFijoDetallesInfoCompleta(clausula, MovimientoFondoFijoDetalleService.Id_NombreCol);
                    // de borrador a anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {

                        exito = true;
                        revisarRequisitos = true;

                    }
                    // de borrador a pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado

                        if (exito)
                        {
                            if (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Length <= 0)
                                cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID);
                            sesion.Db.MOVIMIENTO_FONDO_FIJOCollection.Update(cabeceraRow);
                        }

                        exito = true;
                        revisarRequisitos = true;
                    }
                    //de pendiente a borrador
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                           estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {

                        exito = true;
                        revisarRequisitos = true;

                    }
                    //de pendiente a anulado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        
                        exito = true;
                        revisarRequisitos = true;
                    }
                    // de pendiente a aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        exito = true;
                        revisarRequisitos = true;

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado

                        if (exito)
                        {
                            //Si es desde fondo fijo, validar que hay saldo suficiente en el fondo fijo
                            //Si es desde caja sucursal, validar que está abierta
                            if (!cabeceraRow.IsCTACTE_FONDO_FIJO_IDNull)
                            {
                                if (!CuentaCorrienteFondosFijosService.EstaActivo(cabeceraRow.CTACTE_FONDO_FIJO_ID, sesion))
                                    throw new Exception("El fondo fijo no está activo.");

                                CuentaCorrienteFondosFijosMovimientosService ctacteFondoFijoMov = new CuentaCorrienteFondosFijosMovimientosService();
                                DataTable dtCtacteFondoFijo = CuentaCorrienteFondosFijosService.GetCuentaCorrienteFondosFijosDataTable(CuentaCorrienteFondosFijosService.Id_NombreCol + " = " + cabeceraRow.CTACTE_FONDO_FIJO_ID, string.Empty);

                                //Confirmar que existe saldo suficiente
                                if (Math.Round(cabeceraRow.MONTO_TOTAL_INGRESO - cabeceraRow.MONTO_TOTAL_EGRESO, 2) * -1 > Math.Round((decimal)dtCtacteFondoFijo.Rows[0][CuentaCorrienteFondosFijosService.MontoActual_NombreCol] + (decimal)dtCtacteFondoFijo.Rows[0][CuentaCorrienteFondosFijosService.MontoSobregiro_NombreCol], 2))
                                {
                                    //salta el mensaje en caso de que el egreso mayor que el ingreso y a su vez supere el saldo del fondo fijo
                                    mensaje = "No existe saldo suficiente. El fondo fijo tiene una disponibilidad de " + Math.Round((decimal)dtCtacteFondoFijo.Rows[0][CuentaCorrienteFondosFijosService.MontoActual_NombreCol] + (decimal)dtCtacteFondoFijo.Rows[0][CuentaCorrienteFondosFijosService.MontoSobregiro_NombreCol], 2) +
                                              " y el egreso es " + Math.Round(cabeceraRow.MONTO_TOTAL_INGRESO - cabeceraRow.MONTO_TOTAL_EGRESO) + ".";
                                    throw new Exception(mensaje);
                                }

                                #region afectar fondo fijo
                                if (dtMovimientoFondoFijoDetalles.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtMovimientoFondoFijoDetalles.Rows.Count; i++)
                                    {
                                        decimal ingreso = (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.VistaMontoIngresoDestino_NombreCol] * (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.VistaCantidad_NombreCol];
                                        decimal egreso = (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.VistaMontoEgresoDestino_NombreCol] * (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.VistaCantidad_NombreCol];

                                        CuentaCorrienteFondosFijosMovimientosService.Movimiento(cabeceraRow.CTACTE_FONDO_FIJO_ID,
                                                          (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.Id_NombreCol],
                                                          Definiciones.FlujosIDs.MOVIMIENTO_FONDO_FIJO,
                                                          cabeceraRow.ID,
                                                          ingreso,
                                                          egreso,
                                                          cabeceraRow.COTIZACION_MONEDA,
                                                          "Movimiento de Fondo Fijo " + cabeceraRow.CASO_ID + " pasado al estado " + estado_destino + ".",
                                                          cabeceraRow.FECHA,
                                                          sesion);
                                    }
                                }
                                else
                                {
                                    /*Si el movimiento no tiene detalles*/
                                    CuentaCorrienteFondosFijosMovimientosService.Movimiento(cabeceraRow.CTACTE_FONDO_FIJO_ID,
                                                          Definiciones.Error.Valor.EnteroPositivo,
                                                          Definiciones.FlujosIDs.MOVIMIENTO_FONDO_FIJO,
                                                          cabeceraRow.ID,
                                                          cabeceraRow.MONTO_TOTAL_INGRESO,
                                                          cabeceraRow.MONTO_TOTAL_EGRESO,
                                                          cabeceraRow.COTIZACION_MONEDA,
                                                          "Movimiento de Fondo Fijo " + cabeceraRow.CASO_ID + " pasado al estado " + estado_destino + ".",
                                                          cabeceraRow.FECHA,
                                                          sesion);
                                }
                                #endregion afectar fondo fijo
                            }
                            else if (!cabeceraRow.IsCTACTE_CAJA_SUCURSAL_IDNull)
                            {
                                if (!CuentaCorrienteCajasSucursalService.EstaAbierta(cabeceraRow.CTACTE_CAJA_SUCURSAL_ID))
                                    throw new Exception("La Caja de Sucursal seleccionada no está abierta.");

                                #region afectar caja sucursal
                                for (int i = 0; i < dtMovimientoFondoFijoDetalles.Rows.Count; i++)
                                {
                                    decimal ingreso = (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.MontoIngresoDestino_NombreCol] * (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.Cantidad_NombreCol];
                                    decimal egreso = (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.MontoEgresoDestino_NombreCol] * (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.Cantidad_NombreCol];

                                    var campos = new System.Collections.Hashtable()
                                {
                                    { CuentaCorrienteCajaService.Fecha_NombreCol, cabeceraRow.FECHA },
                                    { CuentaCorrienteCajaService.MonedaId_NombreCol, dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol] },
                                    { CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.CotizacionDestino_NombreCol] },
                                    { CuentaCorrienteCajaService.Monto_NombreCol, ingreso - egreso },
                                    { CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo },
                                    { CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID },
                                    { CuentaCorrienteCajaService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ID },
                                    { CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, CuentaCorrienteCajasSucursalService.GetFuncionarioCobradorId(cabeceraRow.CTACTE_CAJA_SUCURSAL_ID, sesion) },
                                    { CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.MontoIngresoDestino_NombreCol] > 0 ? Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo : Definiciones.CuentaCorrienteConceptos.DebitoPorFlujo },
                                    { CuentaCorrienteCajaService.MovimientoFondoFijoId_NombreCol, cabeceraRow.ID },
                                    { CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, cabeceraRow.CTACTE_CAJA_SUCURSAL_ID }
                                };
                                    CuentaCorrienteCajaService.Guardar(campos, sesion);
                                }
                                #endregion afectar caja sucursal
                            }
                        }

                        if(exito)
                            MovimientoFondoFijoDetalleService.GenerarCasosAsociados(cabeceraRow.ID, sesion);
                    }
                    // de aprobado a pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        exito = true;
                        revisarRequisitos = true;

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado

                        if (exito)
                        {
                            //Confirmar que no se crearon anticipos a funcionario a partir del movimiento
                            DataTable dtAdelantos = new FuncionarioAdelantoService().GetFuncionarioAdelantoDataTable(FuncionarioAdelantoService.CasoOrigenId_NombreCol + " = " + cabeceraRow.CASO_ID, string.Empty);
                            if (dtAdelantos.Rows.Count > 0)
                                throw new Exception("No pueden deshacerse los adelantos a funcionarios creados a partir del Movimiento de Fondo Fijo caso " + cabeceraRow.CASO_ID + ".");

                            if (!cabeceraRow.IsCTACTE_FONDO_FIJO_IDNull)
                            {
                                if (!CuentaCorrienteFondosFijosService.EstaActivo(cabeceraRow.CTACTE_FONDO_FIJO_ID, sesion))
                                    throw new Exception("El fondo fijo no está activo.");

                                if (dtMovimientoFondoFijoDetalles.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtMovimientoFondoFijoDetalles.Rows.Count; i++)
                                    {
                                        decimal ingreso = (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.VistaMontoIngresoDestino_NombreCol] * (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.VistaCantidad_NombreCol];
                                        decimal egreso = (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.VistaMontoEgresoDestino_NombreCol] * (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.VistaCantidad_NombreCol];

                                        CuentaCorrienteFondosFijosMovimientosService.Movimiento(cabeceraRow.CTACTE_FONDO_FIJO_ID,
                                                              (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.Id_NombreCol],
                                                              Definiciones.FlujosIDs.MOVIMIENTO_FONDO_FIJO,
                                                              cabeceraRow.ID,
                                                              egreso,
                                                              ingreso,
                                                              cabeceraRow.COTIZACION_MONEDA,
                                                              "Reversión del Movimiento de Fondo Fijo " + cabeceraRow.CASO_ID + " pasado al estado " + estado_destino + ".",
                                                              cabeceraRow.FECHA,
                                                              sesion);
                                    }
                                }
                                else
                                {
                                    /*Si el movimiento no tiene detalles*/
                                    CuentaCorrienteFondosFijosMovimientosService.Movimiento(cabeceraRow.CTACTE_FONDO_FIJO_ID,
                                                              Definiciones.Error.Valor.EnteroPositivo,
                                                              Definiciones.FlujosIDs.MOVIMIENTO_FONDO_FIJO,
                                                              cabeceraRow.ID,
                                                              cabeceraRow.MONTO_TOTAL_EGRESO,
                                                              cabeceraRow.MONTO_TOTAL_INGRESO,
                                                              cabeceraRow.COTIZACION_MONEDA,
                                                              "Reversión del Movimiento de Fondo Fijo " + cabeceraRow.CASO_ID + " pasado al estado " + estado_destino + ".",
                                                              cabeceraRow.FECHA,
                                                              sesion);
                                }
                            }
                            else if (!cabeceraRow.IsCTACTE_CAJA_SUCURSAL_IDNull)
                            {
                                if (!CuentaCorrienteCajasSucursalService.EstaAbierta(cabeceraRow.CTACTE_CAJA_SUCURSAL_ID))
                                    throw new Exception("La Caja de Sucursal seleccionada no está abierta.");

                                #region afectar caja sucursal
                                for (int i = 0; i < dtMovimientoFondoFijoDetalles.Rows.Count; i++)
                                {
                                    decimal ingreso = (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.MontoIngresoDestino_NombreCol] * (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.Cantidad_NombreCol];
                                    decimal egreso = (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.MontoEgresoDestino_NombreCol] * (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.Cantidad_NombreCol];
                                    var campos = new System.Collections.Hashtable()
                                    {
                                        { CuentaCorrienteCajaService.Fecha_NombreCol, cabeceraRow.FECHA },
                                        { CuentaCorrienteCajaService.MonedaId_NombreCol, dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol] },
                                        { CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.CotizacionDestino_NombreCol] },
                                        { CuentaCorrienteCajaService.Monto_NombreCol, egreso - ingreso },
                                        { CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo },
                                        { CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID },
                                        { CuentaCorrienteCajaService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ID },
                                        { CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, CuentaCorrienteCajasSucursalService.GetFuncionarioCobradorId(cabeceraRow.CTACTE_CAJA_SUCURSAL_ID, sesion) },
                                        { CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, (decimal)dtMovimientoFondoFijoDetalles.Rows[i][MovimientoFondoFijoDetalleService.MontoIngresoDestino_NombreCol] > 0 ? Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo : Definiciones.CuentaCorrienteConceptos.DebitoPorFlujo },
                                        { CuentaCorrienteCajaService.MovimientoFondoFijoId_NombreCol, cabeceraRow.ID },
                                        { CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, cabeceraRow.CTACTE_CAJA_SUCURSAL_ID }
                                    };
                                    CuentaCorrienteCajaService.Guardar(campos, sesion);
                                }
                                #endregion afectar caja sucursal
                            }
                        }

                        if (exito)
                        {
                            //Borrar el asiento contable de la transicion inversa, si existe
                            transicionId = TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.MOVIMIENTO_FONDO_FIJO, estado_destino, casoRow.ESTADO_ID, sesion);
                            CBA.FlowV2.Services.Contabilidad.AsientosService.BorrarPorCasoYTransicion(cabeceraRow.CASO_ID, transicionId, sesion);
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
                        sesion.Db.MOVIMIENTO_FONDO_FIJOCollection.Update(cabeceraRow);
                    }
         
                    return exito;

                }
                catch (Exception exp)
                {
                    exito = false;
                    throw exp;
                }
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza acciones necesarias una vez que se efectuo el cambio de estado
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion) { }

        #endregion Implementacion de Metodos Heredados

        #region GetMovimientoFondoFijoDataTable
        public static DataTable GetMovimientoFondoFijoDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetMovimientoFondoFijoDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetMovimientoFondoFijoDataTable(string clausulas, string orden, SessionService sesion)
        {
            if (clausulas != string.Empty)
                clausulas += " and ";
            clausulas += MovimientoFondoFijoService.Estado_NombreCol +" = '"+Definiciones.Estado.Activo+"'"; 

            return sesion.Db.MOVIMIENTO_FONDO_FIJOCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetMovimientoFondoFijoDataTable

        #region GetMovimientoFondoFijoInfoCompleta
        public static DataTable GetMovimientoFondoFijoInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetMovimientoFondoFijoInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetMovimientoFondoFijoInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            if (clausulas != string.Empty)
                clausulas += " and ";
            clausulas += MovimientoFondoFijoService.VistaEstado_NombreCol + " = '" + Definiciones.Estado.Activo + "'"; 

            return sesion.Db.MOVIMIENTO_FONDO_FIJO_INFO_CCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetMovimientoFondoFijoInfoCompleta

        #region VerificarPuedeAvanzarEstado
        public static bool VerificarPuedeAvanzarEstado(decimal caso_id, out string mensaje, SessionService sesion)
        {
            return FlujosService.VerificarPuedeAvanzarEstado(caso_id, out mensaje, "MOVIMIENTO FONDO FIJO NO CONTROLAR MARGEN DIAS PUEDE AVANZAR", Definiciones.VariablesDeSistema.MovimientoFondoFijoMargenDiasPuedeAvanzar, sesion);
        }
        #endregion VerificarPuedeAvanzarEstado

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                MOVIMIENTO_FONDO_FIJORow row = new MOVIMIENTO_FONDO_FIJORow();
                try
                {
                    string valorAnterior = string.Empty;
                    string estadoId = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("MOVIMIENTO_FONDO_FIJO_SQC");
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[SucursalId_NombreCol].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.MOVIMIENTO_FONDO_FIJO.ToString()),
                                                             int.Parse(sesion.Usuario_Id.ToString()),
                                                             SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                        row.FECHA = DateTime.Now;
                        row.USUARIO_CREACION_ID = sesion.Usuario.ID;

                        row.MONTO_TOTAL_EGRESO = 0;
                        row.MONTO_TOTAL_INGRESO = 0;
                        row.MONEDA_ID = (decimal)campos[MovimientoFondoFijoService.MonedaId_NombreCol];
                        row.ESTADO = Definiciones.Estado.Activo;
                    }
                    else
                    {
                        row = sesion.Db.MOVIMIENTO_FONDO_FIJOCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                        estadoId = CasosService.GetEstadoCaso(row.CASO_ID, sesion);
                    }

                    // a partir de este punto se asignan los valores
                    if (campos.Contains(SucursalId_NombreCol)) row.SUCURSAL_ID = decimal.Parse(campos[SucursalId_NombreCol].ToString());
                    else throw new System.ArgumentException("La sucursal no puede ser nula");
                    
                    if (campos.Contains(AutonumeracionId_NombreCol)) row.AUTONUMERACION_ID = decimal.Parse(campos[AutonumeracionId_NombreCol].ToString());
                    else throw new System.ArgumentException("La autonumeración no puede ser nula");

                    if (campos.Contains(MovimientoFondoFijoService.FondoFijoId_NombreCol))
                        row.CTACTE_FONDO_FIJO_ID = (decimal)campos[MovimientoFondoFijoService.FondoFijoId_NombreCol];
                    else
                        row.IsCTACTE_FONDO_FIJO_IDNull = true;
                    if (campos.Contains(MovimientoFondoFijoService.CtacteCajaSucursalId_NombreCol))
                        row.CTACTE_CAJA_SUCURSAL_ID = (decimal)campos[MovimientoFondoFijoService.CtacteCajaSucursalId_NombreCol];
                    else
                        row.IsCTACTE_CAJA_SUCURSAL_IDNull = true;

                    if (campos.Contains(NroComprobante_NombreCol)) row.NRO_COMPROBANTE = campos[NroComprobante_NombreCol].ToString();
                    if (campos.Contains(Observacion_NombreCol)) row.OBSERVACION = campos[Observacion_NombreCol].ToString();
                    if (campos.Contains(Estado_NombreCol)) row.ESTADO = campos[Estado_NombreCol].ToString();
                    
                    if (!MonedasService.EstaActivo((decimal)campos[MovimientoFondoFijoService.MonedaId_NombreCol]))
                        throw new Exception("La moneda no está activa");

                    row.MONEDA_ID = (decimal)campos[MovimientoFondoFijoService.MonedaId_NombreCol];

                    //en caso que se haya cambiado la fecha en estado aprobado, se actualiza en ctacte_fondo_fijo_mov
                    if ((row.FECHA.Date != ((DateTime)campos[MovimientoFondoFijoService.Fecha_NombreCol]).Date) && (estadoId.Equals(Definiciones.EstadosFlujos.Aprobado)))
                        CuentaCorrienteFondosFijosMovimientosService.ActualizarFechaMov(row.ID, Definiciones.FlujosIDs.MOVIMIENTO_FONDO_FIJO, (DateTime)campos[MovimientoFondoFijoService.Fecha_NombreCol]);

                    row.FECHA = (DateTime)campos[MovimientoFondoFijoService.Fecha_NombreCol];

                    //Se actualiza la cotizacion de la moneda
                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, row.FECHA, sesion);
                    if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda.");

                    if (campos.Contains(MovimientoFondoFijoService.PagoContratistaDetalleId_NombreCol))
                        row.PAGO_CONTRATISTA_DETALLE_ID = (decimal)campos[MovimientoFondoFijoService.PagoContratistaDetalleId_NombreCol];

                    if (insertarNuevo) sesion.Db.MOVIMIENTO_FONDO_FIJOCollection.Insert(row);
                    else sesion.Db.MOVIMIENTO_FONDO_FIJOCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    CalcularTotales(row.ID, sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    return true;
                }
                catch (Exception)
                {
                    if (insertarNuevo && row.CASO_ID > 0)
                    {
                        (new CasosService()).Eliminar(row.CASO_ID, sesion);
                        caso_id = Definiciones.Error.Valor.EnteroPositivo;
                        estado_id = string.Empty;
                    }
                    
                    throw;
                }
            }
        }

        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borra de la base de datos el caso y la cabecera del flujo
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
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
                    MOVIMIENTO_FONDO_FIJORow cabecera = sesion.Db.MOVIMIENTO_FONDO_FIJOCollection.GetByCASO_ID(caso_id)[0];
                    DataTable detalles = MovimientoFondoFijoDetalleService.GetMovimientoFondoFijoDetallesInfoCompleta(MovimientoFondoFijoDetalleService.FondoFijoId_NombreCol + " = " + cabecera.ID,MovimientoFondoFijoDetalleService.Id_NombreCol);

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    if (exito && detalles.Rows.Count > 0)
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que posee detalles.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        cabecera.ESTADO = Definiciones.Estado.Inactivo;
                        sesion.Db.MOVIMIENTO_FONDO_FIJOCollection.Update(cabecera);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                        caso.ESTADO = Definiciones.Estado.Inactivo;
                        sesion.db.CASOSCollection.Update(caso);
                        LogCambiosService.LogDeRegistro(CasosService.Nombre_Tabla, caso.ID, caso.ToString(), Definiciones.Log.RegistroBorrado, sesion);
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

        #region CalcularTotales
        /// <summary>
        /// Calculars the totales.
        /// </summary>
        /// <param name="egreso_vario_caja_id">The egreso_vario_caja_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void CalcularTotales(decimal movimiento_fondo_fijo_id, SessionService sesion)
        {
            /*Se aplica un borrado logico por lo que solo debe aplicar los registros activos*/
            string clausula = MovimientoFondoFijoDetalleService.MovimientoFondoFijoId_NombreCol + " = " + movimiento_fondo_fijo_id +" and "+ MovimientoFondoFijoDetalleService.Estado_NombreCol +" = '"+Definiciones.Estado.Activo+"'";
            DataTable dtMovimientoFondoFijoDetalle = sesion.Db.MOVIMIENTO_FONDO_FIJO_DETCollection.GetAsDataTable(clausula,MovimientoFondoFijoDetalleService.Id_NombreCol);
            MOVIMIENTO_FONDO_FIJORow row = sesion.Db.MOVIMIENTO_FONDO_FIJOCollection.GetByPrimaryKey(movimiento_fondo_fijo_id);
            string valorAnterior = row.ToString();

            row.MONTO_TOTAL_EGRESO = 0;
            row.MONTO_TOTAL_INGRESO = 0;

            for (int i = 0; i < dtMovimientoFondoFijoDetalle.Rows.Count; i++)
            {
                row.MONTO_TOTAL_INGRESO += (decimal)dtMovimientoFondoFijoDetalle.Rows[i][MovimientoFondoFijoDetalleService.MontoIngresoDestino_NombreCol] * (decimal)dtMovimientoFondoFijoDetalle.Rows[i][MovimientoFondoFijoDetalleService.Cantidad_NombreCol];
                row.MONTO_TOTAL_EGRESO += (decimal)dtMovimientoFondoFijoDetalle.Rows[i][MovimientoFondoFijoDetalleService.MontoEgresoDestino_NombreCol] * (decimal)dtMovimientoFondoFijoDetalle.Rows[i][MovimientoFondoFijoDetalleService.Cantidad_NombreCol];
            }
                
            sesion.Db.MOVIMIENTO_FONDO_FIJOCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion CalcularTotales

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "MOVIMIENTO_FONDO_FIJO"; }
        }
        public static string Id_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.IDColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.CASO_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteCajaSucursalId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        public static string FondoFijoId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.CTACTE_FONDO_FIJO_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.FECHAColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.MONEDA_IDColumnName; }
        }
        public static string MontoTotalIngreso_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.MONTO_TOTAL_INGRESOColumnName; }
        }
        public static string MontoTotalEgreso_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.MONTO_TOTAL_EGRESOColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string PagoContratistaDetalleId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.PAGO_CONTRATISTA_DETALLE_IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.OBSERVACIONColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.SUCURSAL_IDColumnName; }
        }
        public static string UsuarioCreacionId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJOCollection.ESTADOColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string Nombre_Vista
        {
            get { return "MOVIMIENTO_FONDO_FIJO_INFO_C"; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_INFO_CCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_INFO_CCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_INFO_CCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaCtacteFondoFijoNombre_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_INFO_CCollection.CTACTE_FONDO_FIJO_NOMBREColumnName; }
        }
        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_INFO_CCollection.MONEDA_CANTIDADES_DECIMALESColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_INFO_CCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaAnticipoProvUtilizaCasoId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_INFO_CCollection.ANTICIPO_PROV_UTILIZA_CASO_IDColumnName; }
        }
        public static string VistaEstado_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_INFO_CCollection.ESTADOColumnName; }
        }
        #endregion Vista

        #endregion Accessors
    }
}




