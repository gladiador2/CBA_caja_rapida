#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.Facturacion;
#endregion Using

namespace CBA.FlowV2.Services.Anticipo
{
    public class AnticiposProveedorService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.ANTICIPO_PROVEEDOR;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);

            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Obtener el numero de comprobante
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns>String con el numero de comprobante</returns>
        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            ANTICIPOS_PROVEEDORRow row = sesion.Db.ANTICIPOS_PROVEEDORCollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE;
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
                ANTICIPOS_PROVEEDORRow cabeceraRow = sesion.Db.ANTICIPOS_PROVEEDORCollection.GetByCASO_ID(caso_id)[0];

                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Si fue emitido un recibo, el mismo es anulado.
                    exito = true;
                    revisarRequisitos = true;

                   
                }
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Si no existe un recibo, generarlo.
                    //Si ya existe y cambio el monto total, actualizar el recibo
                    exito = true;
                    revisarRequisitos = true;
                    if (exito && cabeceraRow.NRO_COMPROBANTE == null)
                    {
                        try
                        {
                            cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, sesion);

                            //Controlar que se logro asignar una numeracion
                            if (cabeceraRow.NRO_COMPROBANTE.Equals(""))
                            {
                                exito = false;
                                mensaje = "No se pudo asignar una numeración válida";
                            }
                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                        }
                    }

                    
                }
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //ninguna.
                    exito = true;
                }
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Se anula el recibo.
                    exito = true;

           
                }
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones
                    //Ninguna accion
                    //Crear los valores.
                    //Afectar la cuenta corriente del proveedor
                    exito = true;
                    revisarRequisitos = true;
                } 
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                     estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Verificar que el Anticipo no es parte de una OP de respaldo
                    exito = true;
                    revisarRequisitos = true;

                    //Verificar que el Anticipo no es parte de una OP de respaldo
                    DataTable dtOrdenPagoDetalle = OrdenesPagoDetalleService.GetOrdenesPagoDetallesDataTable2(OrdenesPagoDetalleService.CasoReferidoId_NombreCol + " = " + cabeceraRow.CASO_ID, string.Empty, sesion);
                    if (dtOrdenPagoDetalle.Rows.Count > 0)
                    {
                        string clausulas = OrdenesPagoService.VistaCasoEstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' and " + OrdenesPagoService.Id_NombreCol + " in (" + Definiciones.Error.Valor.EnteroPositivo;
                        for (int i = 0; i < dtOrdenPagoDetalle.Rows.Count; i++)
                            clausulas += ", " + dtOrdenPagoDetalle.Rows[i][OrdenesPagoDetalleService.OrdenPagoId_NombreCol];
                        clausulas += ")";

                        DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoInfoCompleta(clausulas, string.Empty, sesion);
                        if (dtOrdenPago.Rows.Count > 0)
                            throw new Exception("El Anticipo participa en la Orden de Pago caso " + dtOrdenPago.Rows[0][OrdenesPagoService.CasoId_NombreCol] + ".");
                    }
                }
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Aplicacion))
                {
                    //Acciones
                    //Crear los valores.
                    //Afectar la cuenta corriente del proveedor
                    revisarRequisitos = true;
                    exito = true;

                    if (cambio_pedido_por_usuario)
                    {
                        exito = false;
                        mensaje = "Solo el sistema puede utilizar la transición 'Aprobado' -> 'Aplicación'.";
                    }

                    if (exito)
                    {
                        revisarRequisitos = true;
                        if (cabeceraRow.NRO_COMPROBANTE != null)
                        {
                            CuentaCorrienteProveedoresService.AgregarDebito(cabeceraRow.PROVEEDOR_ID,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.CuentaCorrienteConceptos.DebitoPorFlujo,
                                                            Definiciones.CuentaCorrienteValores.Anticipo,
                                                            casoRow.ID,
                                                            cabeceraRow.MONEDA_ID,
                                                            cabeceraRow.TOTAL_ANTICIPO,
                                                            string.Empty,
                                                            cabeceraRow.FECHA,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                             Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            sesion);
                            exito = true;

                        }
                        else
                        {

                            exito = false;
                            mensaje = "Debe asignar un numero de comprobante";
                        }
                    }
                }
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aplicacion) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones
                    //Validar que el anticipo tiene el saldo completo (no fue utilizado)
                    //Validar que la OP que respaldó al anticipo no está en Cerrado.
                    revisarRequisitos = true;
                    exito = true;

                    if (cambio_pedido_por_usuario)
                        throw new Exception("Solo el sistema puede utilizar la transición 'Aplicación' -> 'Aprobado'.");

                    if (cabeceraRow.TOTAL_ANTICIPO != cabeceraRow.SALDO_POR_APLICAR)
                        throw new Exception("El anticipo ya fue utilizado total o parcialmente.");

                    DataTable dtOrdenPagoDetalle = OrdenesPagoDetalleService.GetOrdenesPagoDetallesDataTable2(OrdenesPagoDetalleService.CasoReferidoId_NombreCol + " = " + cabeceraRow.CASO_ID, string.Empty, sesion);
                    if (dtOrdenPagoDetalle.Rows.Count > 0)
                    {
                        string clausulas = OrdenesPagoService.VistaCasoEstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Cerrado + "' and " + OrdenesPagoService.Id_NombreCol + " in (" + Definiciones.Error.Valor.EnteroPositivo;
                        for (int i = 0; i < dtOrdenPagoDetalle.Rows.Count; i++)
                            clausulas += ", " + dtOrdenPagoDetalle.Rows[i][OrdenesPagoDetalleService.OrdenPagoId_NombreCol];
                        clausulas += ")";

                        DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoInfoCompleta(clausulas, string.Empty, sesion);
                        if (dtOrdenPago.Rows.Count > 0)
                            throw new Exception("Debe revertir la Orden de Pago caso " + dtOrdenPago.Rows[0][OrdenesPagoService.CasoId_NombreCol] + ".");
                    }
                } 
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aplicacion) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                {
                    //Acciones
                    //ninguna.
                    revisarRequisitos = true;

                    if (cambio_pedido_por_usuario)
                    {
                        exito = false;
                        mensaje = "Solo el sistema puede utilizar la transición 'Aplicación' -> 'Cerrado'.";
                    }
                    else
                    {
                        exito = true;
                    }
                }
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aplicacion) &&
                estado_destino.Equals(Definiciones.EstadosFlujos.Devolucion))
                {
                    //Acciones
                    //ninguna.
                    exito = true;
                    revisarRequisitos = true;

                }
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Devolucion) &&
                estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                {
                    //Acciones
                    //ninguna.
                    exito = false;
                    revisarRequisitos = true;

                    decimal montoCasoDevolucion, saldoAnticipo;

                    if (cabeceraRow.IsDEVOLUCION_CASO_IDNull)
                        throw new Exception("Aun no se ha especificado el caso asociado que da ingreso a los valores.");

                    if(cabeceraRow.DEVOLUCION_FLUJO_ID == Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA)
                    {
                        DataTable dtMovVarioCajaTeso = MovimientoVarioCajaTesoreriaService.GetMovimientoVarioCajaTesoreriaDataTable(MovimientoVarioCajaTesoreriaService.CasoId_NombreCol + " = " + cabeceraRow.DEVOLUCION_CASO_ID, string.Empty);

                        //Verificar que el monto es igual al que se debe ingresar comparando en dolares
                        montoCasoDevolucion = (decimal)dtMovVarioCajaTeso.Rows[0][MovimientoVarioCajaTesoreriaService.TotalDoalrizado_NombreCol];
                        saldoAnticipo = cabeceraRow.SALDO_POR_APLICAR / cabeceraRow.MONEDA_COTIZACION;

                        if (Math.Round(montoCasoDevolucion - saldoAnticipo, 4) != 0)
                            throw new Exception("El monto a devolver en dólares es " + Math.Round(saldoAnticipo, 4) + " mientras que el caso de devolución en dólares es por " + Math.Round(montoCasoDevolucion) + ".");

                        if (CasosService.GetEstadoCaso(cabeceraRow.DEVOLUCION_CASO_ID) == Definiciones.EstadosFlujos.Aprobado)
                            exito = true;
                        
                    }
                    else if(cabeceraRow.DEVOLUCION_FLUJO_ID == Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA)
                    {
                        DataTable dtTransferenciaBanc = TransferenciasBancariasService.GetDataTable(TransferenciasBancariasService.CasoId_NombreCol + " = " + cabeceraRow.DEVOLUCION_CASO_ID, string.Empty, sesion);

                        //Verificar que el monto es igual al que se debe ingresar comparando en dolares
                        montoCasoDevolucion = (decimal)dtTransferenciaBanc.Rows[0][TransferenciasBancariasService.MontoDestino_NombreCol] / (decimal)dtTransferenciaBanc.Rows[0][TransferenciasBancariasService.CotizacionMonedaDestino_NombreCol];
                        saldoAnticipo = cabeceraRow.SALDO_POR_APLICAR / cabeceraRow.MONEDA_COTIZACION;

                        if (Math.Round(montoCasoDevolucion - saldoAnticipo, 4) != 0)
                            throw new Exception("El monto a devolver en dólares es " + Math.Round(saldoAnticipo, 4) + " mientras que el caso de devolución en dólares es por " + Math.Round(montoCasoDevolucion, 4) + ".");

                        if (CasosService.GetEstadoCaso(cabeceraRow.DEVOLUCION_CASO_ID) == Definiciones.EstadosFlujos.Cerrado)
                            exito = true;
                    }
                    else if (cabeceraRow.DEVOLUCION_FLUJO_ID == Definiciones.FlujosIDs.MOVIMIENTO_FONDO_FIJO)
                    {
                        DataTable dtMovimientoFondoFijo = MovimientoFondoFijoService.GetMovimientoFondoFijoDataTable(MovimientoFondoFijoService.CasoId_NombreCol +"="+cabeceraRow.DEVOLUCION_CASO_ID,string.Empty,sesion);

                        //Verificar que el monto es igual al que se debe ingresar comparando en dolares
                        decimal montoTotalMovimiento = 0;
                        decimal montoIngreso = (decimal)dtMovimientoFondoFijo.Rows[0][MovimientoFondoFijoService.MontoTotalIngreso_NombreCol];
                        decimal montoEgreso = (decimal)dtMovimientoFondoFijo.Rows[0][MovimientoFondoFijoService.MontoTotalEgreso_NombreCol];

                        if(montoIngreso > montoEgreso)
                            montoTotalMovimiento = montoIngreso - montoEgreso;
                        else
                            throw new Exception ("El movimiento de fondo fijo asignado posee un saldo negativo, no puede realizar devoluciones con saldos negativos.");

                        montoCasoDevolucion = Math.Round(montoTotalMovimiento / (decimal)dtMovimientoFondoFijo.Rows[0][MovimientoFondoFijoService.CotizacionMoneda_NombreCol], MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID, sesion));
                        saldoAnticipo = Math.Round(cabeceraRow.SALDO_POR_APLICAR / (decimal)dtMovimientoFondoFijo.Rows[0][MovimientoFondoFijoService.CotizacionMoneda_NombreCol], MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID, sesion));

                        if (Math.Round(montoCasoDevolucion - saldoAnticipo, 4) != 0)
                            throw new Exception("El monto a devolver en dólares es " + Math.Round(saldoAnticipo, 4) + " mientras que el caso de devolución en dólares es por " + Math.Round(montoCasoDevolucion, 4) + ".");

                        if (CasosService.GetEstadoCaso(cabeceraRow.DEVOLUCION_CASO_ID) == Definiciones.EstadosFlujos.Aprobado)
                            exito = true;
                    }
                    else
                    {
                        throw new Exception("AnticiposProveedoresService.ProcesarCambioEstado(). Flujo de devolución no implementado.");
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
                    sesion.Db.ANTICIPOS_PROVEEDORCollection.Update(cabeceraRow);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, cabeceraRow.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, cabeceraRow.NRO_COMPROBANTE);
                    if (!cabeceraRow.IsPROVEEDOR_IDNull)
                        camposCaso.Add(CasosService.ProveedorId_NombreCol, cabeceraRow.PROVEEDOR_ID);
                    CasosService.ActualizarCampos(cabeceraRow.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos
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

        #endregion Implementacion de metodos abstract

        #region GetAnticipoProveedorDataTable
        public static DataTable GetAnticipoProveedorDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAnticipoProveedorDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetAnticipoProveedorDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ANTICIPOS_PROVEEDORCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAnticipoProveedorDataTable

        #region GetAnticipoProveedorInfoCompleta
        /// <summary>
        /// Gets the anticipo proveedor info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAnticipoProveedorInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAnticipoProveedorInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetAnticipoProveedorInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ANTICIPOS_PROVEED_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAnticipoProveedorInfoCompleta

        #region GetAnticipoProveedorParaOrdenDePago
        /// <summary>
        /// Gets the anticipo proveedor para orden de pago.
        /// </summary>
        /// <param name="proveedor_id">The proveedor_id.</param>
        /// <returns></returns>
        public static DataTable GetAnticipoProveedorParaOrdenDePago(decimal proveedor_id, decimal orden_pago_caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = "(" + AnticiposProveedorService.VistaOrdenPagoUtilizaCasoId_NombreCol + " not like '%" + orden_pago_caso_id + "%' or " +
                                   AnticiposProveedorService.VistaOrdenPagoUtilizaCasoId_NombreCol + " is null) and " +
                                   AnticiposProveedorService.ProveedorId_NombreCol + " = " + proveedor_id + " and " +
                                   AnticiposProveedorService.VistaCasoEstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Aplicacion + "'";

                return sesion.Db.ANTICIPOS_PROVEED_INFO_COMPLCollection.GetAsDataTable(clausulas, AnticiposProveedorService.Fecha_NombreCol);
            }
        }
        #endregion GetAnticipoProveedorParaOrdenDePago

        #region GetFacturaAsociada
        public static decimal GetCasoFacturaAsociada(decimal caso_asociado)
        {
            /*OBS=Retorna la factura asociada al anticipo*/
            string clausula = FacturasProveedorService.CasoAsociadoId_NombreCol + "=" + caso_asociado;
            DataTable dtFactura = FacturasProveedorService.GetFacturaProveedorInfoCompleta(clausula, FacturasProveedorService.CasoAsociadoId_NombreCol);
            if (dtFactura.Rows.Count > 0)
            {
                if (dtFactura.Rows[0][FacturasProveedorService.VistaCasoEstadoId_NombreCol].ToString() != Definiciones.EstadosFlujos.Anulado)
                    return decimal.Parse(dtFactura.Rows[0][FacturasProveedorService.CasoId_NombreCol].ToString());
                else
                    return Definiciones.Error.Valor.EnteroPositivo;
            }
            else
                return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion

        #region GetAnticipoIdPorCaso
        public static decimal GetAnticipoIdPorCaso(decimal caso)
        { 
            /*OBS=Retorna el id de del anticipo por el caso*/
            string where = AnticiposProveedorService.CasoId_NombreCol + "=" + caso;
            DataTable dtAnticipo = AnticiposProveedorService.GetAnticipoProveedorDataTable(where, string.Empty);
            if (dtAnticipo.Rows.Count > 0)
                return decimal.Parse(dtAnticipo.Rows[0][AnticiposProveedorService.Id_NombreCol].ToString());
            else
                return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion

        #region AumentarSaldoDisponible
        /// <summary>
        /// Aumentars the saldo disponible.
        /// </summary>
        /// <param name="anticipo_proveedor_id">The anticipo_proveedor_id.</param>
        /// <param name="total_afectado">The total_afectado.</param>
        /// <param name="sesion">The sesion.</param>
        public void AumentarSaldoDisponible(decimal anticipo_proveedor_id, decimal total_afectado, SessionService sesion)
        {
            ANTICIPOS_PROVEEDORRow row = sesion.Db.ANTICIPOS_PROVEEDORCollection.GetByPrimaryKey(anticipo_proveedor_id);
            string valorAnterior = row.SALDO_POR_APLICAR.ToString();
            bool exito = false;
            string mensaje;

            //Si el saldo habia llegado a cero, el caso fue cerrado y debe abrirse nuevamente
            if (row.SALDO_POR_APLICAR <= 0)
            {
                exito = this.ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Aplicacion, false, out mensaje, sesion);
                if (exito)
                    exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Aplicacion, "El saldo del anticipo fue reintegrado parcial o totalmente.", sesion);
                if (exito)
                    this.EjecutarAccionesLuegoDeCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Aplicacion, sesion);

                if (!exito)
                    throw new Exception("Error en AnticiposPersonasService.AumentarSaldoDisponible. El caso debîa reabrirse ya que se encontraba en cerrado porque el saldo habâ sido agotado. " + mensaje + ".");
            }

            row.SALDO_POR_APLICAR += total_afectado;

            sesion.Db.ANTICIPOS_PROVEEDORCollection.Update(row);
            LogCambiosService.LogDeColumna(Nombre_Tabla, AnticiposPersonaService.SaldoPorAplicar_NombreCol, row.ID, valorAnterior, row.SALDO_POR_APLICAR.ToString(), sesion);
        }
        #endregion AumentarSaldoDisponible

        #region DisminuirSaldoDisponible
        /// <summary>
        /// Disminuirs the saldo disponible.
        /// </summary>
        /// <param name="anticipo_proveedor_id">The anticipo_proveedor_id.</param>
        /// <param name="total_afectado">The total_afectado.</param>
        /// <param name="sesion">The sesion.</param>
        public void DisminuirSaldoDisponible(decimal anticipo_proveedor_id, decimal total_afectado, SessionService sesion)
        {
            ANTICIPOS_PROVEEDORRow row = sesion.Db.ANTICIPOS_PROVEEDORCollection.GetByPrimaryKey(anticipo_proveedor_id);
            string valorAnterior = row.SALDO_POR_APLICAR.ToString();
            bool exito = false;
            string mensaje;

            if (row.SALDO_POR_APLICAR < total_afectado)
                throw new Exception("El anticipo no cuenta con suficiente saldo para ser aplicado.");
            
            row.SALDO_POR_APLICAR -= total_afectado;

            sesion.Db.ANTICIPOS_PROVEEDORCollection.Update(row);
            LogCambiosService.LogDeColumna(Nombre_Tabla, AnticiposPersonaService.SaldoPorAplicar_NombreCol, row.ID, valorAnterior, row.SALDO_POR_APLICAR.ToString(), sesion);

            //Si el saldo por aplicar llega a cero, el caso debe
            //ser pasado a cerrado
            if (row.SALDO_POR_APLICAR <= 0)
            {
                exito = this.ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                if (exito)
                    exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Cerrado, "El saldo del anticipo llegó a cero.", sesion);
                if (exito)
                    this.EjecutarAccionesLuegoDeCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);

                if (!exito)
                    throw new Exception("Error en AnticiposProveedorService.DisminuirSaldoDisponible. El saldo fue agotado pero el caso no pudo ser pasado a cerrado. " + mensaje + ".");
            }
        }
        #endregion DisminuirSaldoDisponible

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    bool exito = Guardar(campos, insertarNuevo, ref caso_id, ref estado_id, sesion);
                    sesion.CommitTransaction();

                    return exito;
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id, SessionService sesion)
        {
            bool exito = false;
            ANTICIPOS_PROVEEDORRow row = new ANTICIPOS_PROVEEDORRow();

            try
            {
                string casoEstadoId;

                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[AnticiposProveedorService.SucursalId_NombreCol].ToString()),
                                                          int.Parse(Definiciones.FlujosIDs.ANTICIPO_PROVEEDOR.ToString()),
                                                          int.Parse(sesion.Usuario_Id.ToString()),
                                                          SessionService.GetClienteIP());
                    row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                    row.ID = sesion.Db.GetSiguienteSecuencia("anticipos_proveedor_sqc");
                    row.FECHA = DateTime.Now;

                    caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                    estado_id = Definiciones.EstadosFlujos.Borrador;


                }
                else
                {
                    row = sesion.Db.ANTICIPOS_PROVEEDORCollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                //Si el estado es borrador o pendiente se guardan todos los campos.
                //En los demas estados se guardan solo el flujo y caso de devolucion.
                casoEstadoId = CasosService.GetEstadoCaso(row.CASO_ID, sesion);
                if (casoEstadoId.Equals(Definiciones.EstadosFlujos.Borrador) ||
                    casoEstadoId.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    if (campos.Contains(CasoAsociadoId_NombreCol))
                    {
                        row.CASO_ASOCIADO_ID = decimal.Parse(campos[CasoAsociadoId_NombreCol].ToString());
                    }
                    
                    if (campos.Contains(MontoTotal_NombreCol))
                    {
                        row.TOTAL_ANTICIPO = decimal.Parse(campos[MontoTotal_NombreCol].ToString());
                        row.SALDO_POR_APLICAR = row.TOTAL_ANTICIPO;
                    }
                    if (campos.Contains(ProveedorId_NombreCol))
                    {
                        row.PROVEEDOR_ID = decimal.Parse(campos[ProveedorId_NombreCol].ToString());
                    }

                    if (campos.Contains(SucursalId_NombreCol))
                    {
                        if (SucursalesService.EstaActivo((decimal)campos[SucursalId_NombreCol]))
                            row.SUCURSAL_ID = (decimal)campos[SucursalId_NombreCol];
                        else
                            throw new System.Exception("La sede se encuentra inactiva.");
                    }
                    if (campos.Contains(Fecha_NombreCol))
                    {
                        row.FECHA = DateTime.Parse(campos[Fecha_NombreCol].ToString());
                    }
                    if (campos.Contains(MonedaId_NombreCol))
                    {
                        row.MONEDA_ID = decimal.Parse(campos[MonedaId_NombreCol].ToString());
                    }
                    if (campos.Contains(MonedaCotizacion_NombreCol))
                    {
                        row.MONEDA_COTIZACION = decimal.Parse(campos[MonedaCotizacion_NombreCol].ToString());
                    }
                    if (campos.Contains(AutonmeracionId_NombreCol))
                    {
                        row.AUTONUMERACION_ID = decimal.Parse(campos[AutonmeracionId_NombreCol].ToString());
                    }
                    if (campos.Contains(NroComprobante_NombreCol))
                    {
                        row.NRO_COMPROBANTE = campos[NroComprobante_NombreCol].ToString();
                    }

                    if (campos.Contains(Observacion_NombreCol))
                    {
                        row.OBSERVACION = (string)campos[Observacion_NombreCol];
                    }
                    if (campos.Contains(MontoRetencion_NombreCol))
                    {
                        row.MONTO_RETENCION = decimal.Parse(campos[MontoRetencion_NombreCol].ToString());
                    }
                }
                else if (casoEstadoId.Equals(Definiciones.EstadosFlujos.Devolucion))
                {
                    if (campos.Contains(DevolucionCasoId_NombreCol))
                    {
                        row.DEVOLUCION_CASO_ID = decimal.Parse(campos[DevolucionCasoId_NombreCol].ToString());
                    }
                    if (campos.Contains(DevolucionFlujoId_NombreCol))
                    {
                        row.DEVOLUCION_FLUJO_ID = decimal.Parse(campos[DevolucionFlujoId_NombreCol].ToString());
                    }
                }

                if (campos.Contains(Observacion_NombreCol) && RolesService.Tiene("ANTICIPOS PROVEEDOR EDITAR OBSERVACION EN APROBADO"))
                {
                    row.OBSERVACION = (string)campos[Observacion_NombreCol];
                }

                if (insertarNuevo) sesion.Db.ANTICIPOS_PROVEEDORCollection.Insert(row);
                else sesion.Db.ANTICIPOS_PROVEEDORCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();
                camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                if (!row.IsPROVEEDOR_IDNull)
                    camposCaso.Add(CasosService.ProveedorId_NombreCol, row.PROVEEDOR_ID);
                CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                #endregion Actualizar datos en tabla casos

                exito = true;
            }
            catch (Exception)
            {
                //Si el caso fue creado el mismo debe borrarse
                if (insertarNuevo && row.CASO_ID > 0)
                {
                    (new CasosService()).Eliminar(row.CASO_ID, sesion);
                    caso_id = Definiciones.Error.Valor.EnteroPositivo;
                    estado_id = string.Empty;
                }

                throw;
            }
            return exito;
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
                    String mensaje = "Error.";

                    //Se obtiene el caso a ser borrado
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    ANTICIPOS_PROVEEDORRow cabecera = sesion.Db.ANTICIPOS_PROVEEDORCollection.GetByCASO_ID(caso_id)[0];

                    if (caso.ESTADO_ID == Definiciones.EstadosFlujos.Aprobado ||
                        caso.ESTADO_ID == Definiciones.EstadosFlujos.Aplicacion ||
                        caso.ESTADO_ID == Definiciones.EstadosFlujos.Devolucion ||
                        caso.ESTADO_ID == Definiciones.EstadosFlujos.Cerrado)
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse en el estado " + caso.ESTADO_ID + ".";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        //No se borra fisicamente por problemas de FK. Cuando exista borrado logico debera cambiar de estado aqui
                        //sesion.Db.ANTICIPOS_PROVEEDORCollection.DeleteByPrimaryKey(cabecera.ID);
                        //LogCambiosService.LogDeRegistro(Nombre_Tabla, cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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
            get { return "ANTICIPOS_PROVEEDOR"; }
        }
        public static string AutonmeracionId_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.CASO_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.MONEDA_COTIZACIONColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.MONEDA_IDColumnName; }
        }
        public static string MontoTotal_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.TOTAL_ANTICIPOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.OBSERVACIONColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.PROVEEDOR_IDColumnName; }
        }
        public static string SaldoPorAplicar_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.SALDO_POR_APLICARColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.SUCURSAL_IDColumnName; }
        }
        public static string MonedaCotizacion_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.MONEDA_COTIZACIONColumnName; }
        }
        public static string MontoRetencion_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.MONTO_RETENCIONColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string DevolucionCasoId_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.DEVOLUCION_CASO_IDColumnName; }
        }
        public static string DevolucionFlujoId_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.DEVOLUCION_FLUJO_IDColumnName; }
        }
        public static string CasoAsociadoId_NombreCol
        {
            get { return ANTICIPOS_PROVEEDORCollection.CASO_ASOCIADO_IDColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return ANTICIPOS_PROVEED_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return ANTICIPOS_PROVEED_INFO_COMPLCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaProveedorRazonSocial_NombreCol
        {
            get { return ANTICIPOS_PROVEED_INFO_COMPLCollection.PROVEEDOR_RAZON_SOCIALColumnName; }
        }    
        public static string VistaMonedaNombre_NombreCol
        {
            get { return ANTICIPOS_PROVEED_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return ANTICIPOS_PROVEED_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return ANTICIPOS_PROVEED_INFO_COMPLCollection.MONEDA_CANTIDADES_DECIMALESColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return ANTICIPOS_PROVEED_INFO_COMPLCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaDevolucionCasoObservacion_NombreCol
        {
            get { return ANTICIPOS_PROVEED_INFO_COMPLCollection.DEVOLUCION_CASO_OBSERVACIONColumnName; }
        }
        public static string VistaDevolucionFlujoDescripcion_NombreCol
        {
            get { return ANTICIPOS_PROVEED_INFO_COMPLCollection.DEVOLUCION_FLUJO_DESCRIPCIONColumnName; }
        }
        public static string VistaEntidadId_NombreCol
        {
            get { return ANTICIPOS_PROVEED_INFO_COMPLCollection.ENTIDAD_IDColumnName; }
        }
        public static string VistaOrdenPagoRespaldaCasoId_NombreCol
        {
            get { return ANTICIPOS_PROVEED_INFO_COMPLCollection.ORDEN_PAGO_RESPALDA_CASO_IDColumnName; }
        }
        public static string VistaOrdenPagoUtilizaCasoId_NombreCol
        {
            get { return ANTICIPOS_PROVEED_INFO_COMPLCollection.ORDEN_PAGO_UTILIZA_CASO_IDColumnName; }
        }
        #endregion Accessors
    }
}
