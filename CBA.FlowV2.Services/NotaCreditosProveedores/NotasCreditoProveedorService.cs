﻿#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Stock;
using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.Facturacion;
#endregion Using

namespace CBA.FlowV2.Services.NotaCreditosProveedores
{
    public class NotasCreditoProveedorService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.NOTA_CREDITO_PROVEEDOR;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var cabecera = (NotasCreditoProveedorService)caso_cabecera;
            var detalle = (NotasCreditoProveedorDetalleService)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);

            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, cabecera.DepositoId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, detalle.ArticuloId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, detalle.TextoPredefinidoId);
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
                    var caso = new CasosService(caso_id, sesion);
                    NOTAS_CREDITO_PROVEEDORESRow cabeceraRow = sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.GetByCASO_ID(caso_id)[0];
                    NOTAS_CREDITO_PROVEEDORES_DETRow[] detalleRow = sesion.Db.NOTAS_CREDITO_PROVEEDORES_DETCollection.GetByNOTA_CREDITO_PROVEEDOR_ID(cabeceraRow.ID);
                    if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        exito = true;
                        revisarRequisitos = true;

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado
                    }
                    if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                    }
                    if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Ninguna
                        exito = true;
                    }
                    if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //Afectar la cuenta corriente del proveedor
                        //Afectar stock
                        exito = true;
                        revisarRequisitos = true;

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado

                        #region afectar ctacte
                        //Ingresar el debito
                        CuentaCorrienteProveedoresService.AgregarDebito((decimal)cabeceraRow.PROVEEDOR_ID,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.CuentaCorrienteConceptos.DebitoPorFlujo,
                                                    Definiciones.CuentaCorrienteValores.NotaDeCredito,
                                                    cabeceraRow.CASO_ID,
                                                    cabeceraRow.MONEDA_ID,
                                                    cabeceraRow.MONTO_TOTAL,
                                                    string.Empty,
                                                    DateTime.Now,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    sesion);

                        #endregion afectar ctacte

                        foreach (NOTAS_CREDITO_PROVEEDORES_DETRow detalle in detalleRow)
                        {
                            if (detalle.IsTEXTO_PREDEFINIDO_IDNull)
                            {
                                FACTURAS_PROVEEDOR_DETALLERow detalleFactura = sesion.db.FACTURAS_PROVEEDOR_DETALLECollection.GetByPrimaryKey(detalle.FACTURA_PROVEEDOR_DETALLE_ID);
                                StockService.Costo costo = null;

                                if (detalleFactura.AFECTA_STOCK.Equals(Definiciones.SiNo.Si))
                                {
                                    var dtFactura = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.Id_NombreCol + " = " + detalle.FACTURA_PROVEEDOR_ID, string.Empty, sesion);
                                    var dtFacturaDet = FacturasProveedorDetalleService.GetFacturaProveedorDetalleDataTable(FacturasProveedorDetalleService.Id_NombreCol + " = " + detalle.FACTURA_PROVEEDOR_DETALLE_ID, string.Empty, sesion);

                                    decimal montoImpuesto = 0;
                                    if ((decimal)dtFacturaDet.Rows[0][FacturasProveedorDetalleService.PorcentajeImpuesto_NombreCol] > 0)
                                        montoImpuesto = (decimal)dtFacturaDet.Rows[0][FacturasProveedorDetalleService.PrecioBrutoUnitarioOrigen_NombreCol] / (1 + (100 / (decimal)dtFacturaDet.Rows[0][FacturasProveedorDetalleService.PorcentajeImpuesto_NombreCol]));

                                    var casoFacturaProveedor = new CasosService((decimal)dtFactura.Rows[0][FacturasProveedorService.CasoId_NombreCol], sesion);

                                    costo = new StockService.Costo()
                                    {
                                        moneda_origen_id = (decimal)dtFactura.Rows[0][FacturasProveedorService.MonedaId_NombreCol],
                                        cotizacion_origen = (decimal)dtFactura.Rows[0][FacturasProveedorService.MonedaCotizacion_NombreCol],
                                        costo_origen = (decimal)dtFacturaDet.Rows[0][FacturasProveedorDetalleService.PrecioBrutoUnitarioOrigen_NombreCol] - montoImpuesto,
                                        moneda_id = casoFacturaProveedor.Sucursal.Region.SucursalCasaMatriz.Pais.MonedaId
                                    };

                                    if (costo.moneda_origen_id == costo.moneda_id)
                                    {
                                        costo.cotizacion = costo.cotizacion_origen;
                                        costo.costo = costo.costo_origen;
                                    }
                                    else
                                    {
                                        costo.cotizacion = CotizacionesService.GetCotizacionMonedaVenta(casoFacturaProveedor.Sucursal.PaisId, costo.moneda_id, caso.FechaFormulario.Value, sesion);
                                        costo.costo = costo.costo_origen / costo.cotizacion_origen * costo.cotizacion;
                                    }

                                    StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                            detalle.ARTICULO_ID,
                                                            detalle.CANTIDAD,
                                                            Definiciones.Stock.TipoMovimiento.NotaCreditoProveedor,
                                                            caso_id,
                                                            detalle.LOTE_ID,
                                                            estado_destino,
                                                            sesion,
                                                            costo,
                                                            detalle.IMPUESTO_ID,
                                                            detalle.ID);
                                }
                            }
                        }
                    }
                    if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    
                    //Verificar si se cumplen los requisitos
                    if (exito && revisarRequisitos)
                    {
                        exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                    }

                    if (exito)
                    {
                        caso.Guardar(sesion);
                        sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.Update(cabeceraRow);
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
            NOTAS_CREDITO_PROVEEDORESRow row = sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE; ;
        }

        #endregion Implementacion de metodos abstract

        #region GetAnticipoProveedorDataTable
        public static DataTable GetNotaCreditoProveedorDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaCreditoProveedorDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaCreditoProveedorDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAnticipoProveedorDataTable

        #region GetNotaCreditoProveedorInfoCompleta
        /// <summary>
        /// Gets the nota credito proveedor info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetNotaCreditoProveedorInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaCreditoProveedorInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaCreditoProveedorInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.NOTAS_CREDITO_PROVEED_INF_COMPCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetNotaCreditoProveedorInfoCompleta

        #region GetNotaCreditoProveedorPorCaso

        /// <summary>
        /// Gets the nota credito proveedor por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetNotaCreditoProveedorPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.GetAsDataTable(NotasCreditoProveedorService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetNotaCreditoProveedorPorCaso

        #region GetNotaCreditoProveedorParaOrdenDePago
        /// <summary>
        /// Gets the nota credito proveedor para orden de pago.
        /// </summary>
        /// <param name="proveedor_id">The proveedor_id.</param>
        /// <returns></returns>
        public DataTable GetNotaCreditoProveedorParaOrdenDePago(decimal proveedor_id, decimal orden_pago_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = NotasCreditoProveedorService.ProveedorId_NombreCol + " = " + proveedor_id + " and " +
                                   NotasCreditoProveedorService.VistaCasoEstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Aprobado + "' and " +
                                   "not exists(select id from " + OrdenesPagoValoresService.Nombre_Tabla + " opv " + 
                                   "            where opv." + OrdenesPagoValoresService.OrdenPagoId_NombreCol + " = " + orden_pago_id + " and " +
                                   "                  opv." + OrdenesPagoValoresService.NotaCreditoProveedorId_NombreCol + " = " + NotasCreditoProveedorService.Nombre_Vista + "." + NotasCreditoProveedorService.Id_NombreCol +
                                   "           )";

                return sesion.Db.NOTAS_CREDITO_PROVEED_INF_COMPCollection.GetAsDataTable(clausulas, NotasCreditoProveedorService.Fecha_NombreCol);
            }
        }
        #endregion GetNotaCreditoProveedorParaOrdenDePago

        #region GetNotaCreditoProveedorPorCasoFacturaProvId
        public static DataTable GetNotaCreditoProveedorPorCasoFacturaProvId(decimal caso_id, bool agrupar)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;
                string query = "";
                if (agrupar)
                {
                    query += "select LISTAGG(ncp." + NroComprobante_NombreCol + ", ', ') WITHIN " + "\n";
                    query += " GROUP( " + "\n";
                    query += " ORDER BY ncp." + NroComprobante_NombreCol + ") notas_credito, " + "\n";
                    query += " sum(round(ncpd." + NotasCreditoProveedorDetalleService.Total_NombreCol + ", (select m." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName +
                        " from " + MonedasService.Nombre_Tabla + " m where m." + MonedasService.Modelo.IDColumnName + " = ncp." + MonedaId_NombreCol +
                        "))) monto_notas_credito \n ";
                    query += "  from " + NotasCreditoProveedorService.Nombre_Tabla + " ncp, " + "\n";
                    query += "       " + NotasCreditoProveedorDetalleService.Nombre_Tabla + " ncpd, " + "\n";
                    query += "       " + CasosService.Nombre_Tabla + " c " + "\n";
                    query += " where ncp." + Id_NombreCol + " = ncpd." + NotasCreditoProveedorDetalleService.NotaCreditoId_NombreCol + " \n";
                    query += "   and ncp." + CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " \n";
                    query += "   and ncpd." + NotasCreditoProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + "\n";
                    query += "       (select fp." + FacturasProveedorService.Id_NombreCol + " from " + FacturasProveedorService.Nombre_Tabla +
                        " fp where fp." + FacturasProveedorService.CasoId_NombreCol + " = " + caso_id + ") " + "\n";
                    query += "   and c." + CasosService.EstadoId_NombreCol + " != '" + Definiciones.EstadosFlujos.Anulado + "'";
                }
                else
                {
                    query += "select ncp." + NotasCreditoProveedorService.Id_NombreCol + ", ncp." + NroComprobante_NombreCol + " nota_credito, \n";                                        
                    query += "round(ncpd." + NotasCreditoProveedorDetalleService.Total_NombreCol + ", (select m." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName +
                        " from " + MonedasService.Nombre_Tabla + " m where m." + MonedasService.Modelo.IDColumnName + " = ncp." + MonedaId_NombreCol +
                        ")) monto_nota_credito, \n ";
                    query += "ncp." + NotasCreditoProveedorService.CotizacionMoneda_NombreCol + ", \n";
                    query += "ncp." + NotasCreditoProveedorService.MonedaId_NombreCol + " \n";
                    query += "  from " + NotasCreditoProveedorService.Nombre_Tabla + " ncp, " + "\n";
                    query += "       " + NotasCreditoProveedorDetalleService.Nombre_Tabla + " ncpd, " + "\n";
                    query += "       " + CasosService.Nombre_Tabla + " c " + "\n";
                    query += " where ncp." + Id_NombreCol + " = ncpd." + NotasCreditoProveedorDetalleService.NotaCreditoId_NombreCol + " \n";
                    query += "   and ncp." + CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " \n";
                    query += "   and ncpd." + NotasCreditoProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + "\n";
                    query += "       (select fp." + FacturasProveedorService.Id_NombreCol + " from " + FacturasProveedorService.Nombre_Tabla +
                        " fp where fp." + FacturasProveedorService.CasoId_NombreCol + " = " + caso_id + ") " + "\n";
                    query += "   and c." + CasosService.EstadoId_NombreCol + " != '" + Definiciones.EstadosFlujos.Anulado + "'";
                }
                dt = sesion.db.EjecutarQuery(query);
                return dt;
            }
        }
        #endregion GetNotaCreditoProveedorPorCasoFacturaProvId

        #region VerificarPuedeAvanzarEstado
        public static bool VerificarPuedeAvanzarEstado(decimal caso_id, out string mensaje, SessionService sesion)
        {
            return FlujosService.VerificarPuedeAvanzarEstado(caso_id, out mensaje, "NOTAS CREDITO PROVEEDOR NO CONTROLAR MARGEN DIAS PUEDE AVANZAR", Definiciones.VariablesDeSistema.NCProveedorMargenDiasPuedeAvanzar, sesion);
        }
        #endregion VerificarPuedeAvanzarEstado

        #region AumentarSaldoDisponible
        /// <summary>
        /// Aumentars the saldo disponible.
        /// </summary>
        /// <param name="nota_credito_proveedor_id">The nota_credito_proveedor_id.</param>
        /// <param name="total_afectado">The total_afectado.</param>
        /// <param name="sesion">The sesion.</param>
        public void AumentarSaldoDisponible(decimal nota_credito_proveedor_id, decimal total_afectado, SessionService sesion)
        {
            NOTAS_CREDITO_PROVEEDORESRow row = sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.GetByPrimaryKey(nota_credito_proveedor_id);
            DataTable dtCaso = CasosService.GetCasosDataTable(CasosService.Id_NombreCol + " = " + row.CASO_ID, string.Empty, sesion);
            string valorAnterior = row.SALDO_POR_APLICAR.ToString();

            //Si el caso fue pasado a cerrado revertir a aprobado
            if(dtCaso.Rows[0][CasosService.EstadoId_NombreCol].Equals(Definiciones.EstadosFlujos.Cerrado))
                CambioEstadoCasoService.BorrarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Aprobado, Definiciones.EstadosFlujos.Cerrado, sesion);

            row.SALDO_POR_APLICAR += total_afectado;

            sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.Update(row);
            LogCambiosService.LogDeColumna(Nombre_Tabla, NotasCreditoProveedorService.SaldoPorAplicar_NombreCol, row.ID, valorAnterior, row.SALDO_POR_APLICAR.ToString(), sesion);

            
        }
        #endregion AumentarSaldoDisponible

        #region DisminuirSaldoDisponible
        /// <summary>
        /// Disminuirs the saldo disponible.
        /// </summary>
        /// <param name="nota_credito_proveedor_id">The nota_credito_proveedor_id.</param>
        /// <param name="total_afectado">The total_afectado.</param>
        /// <param name="sesion">The sesion.</param>
        public void DisminuirSaldoDisponible(decimal nota_credito_proveedor_id, decimal total_afectado, SessionService sesion)
        {

            NOTAS_CREDITO_PROVEEDORESRow row = sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.GetByPrimaryKey(nota_credito_proveedor_id);
            string valorAnterior = row.SALDO_POR_APLICAR.ToString();
            bool exito = false;
            string mensaje;

            if (row.SALDO_POR_APLICAR < total_afectado)
                throw new Exception("La NC no cuenta con suficiente saldo para ser aplicada.");

            row.SALDO_POR_APLICAR -= total_afectado;

            sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.Update(row);
            LogCambiosService.LogDeColumna(Nombre_Tabla, NotasCreditoProveedorService.SaldoPorAplicar_NombreCol, row.ID, valorAnterior, row.SALDO_POR_APLICAR.ToString(), sesion);

            //Si el saldo por aplicar llega a cero, el caso debe
            //ser pasado a cerrado
            if (row.SALDO_POR_APLICAR <= 0)
            {
                exito = this.ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                if (exito)
                    exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Cerrado, "El saldo de la NC llegó a cero.", sesion);
                if (exito)
                    this.EjecutarAccionesLuegoDeCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);

                if (!exito)
                    throw new Exception("Error en NotasCreditoProveedor.DisminuirSaldoDisponible. El saldo fue agotado pero el caso no pudo ser pasado a cerrado. " + mensaje + ".");
            }
        }
        #endregion DisminuirSaldoDisponible

        #region RecalcularTotal

        /// <summary>
        /// Recalculars the total.
        /// </summary>
        /// <param name="nota_credito_proveedor_id">The nota_credito_proveedor_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void RecalcularTotal(decimal nota_credito_proveedor_id, SessionService sesion)
        {
            NOTAS_CREDITO_PROVEEDORESRow row = sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.GetByPrimaryKey(nota_credito_proveedor_id);
            NOTAS_CREDITO_PROVEEDORES_DETRow[] detalleRows = sesion.Db.NOTAS_CREDITO_PROVEEDORES_DETCollection.GetByNOTA_CREDITO_PROVEEDOR_ID(nota_credito_proveedor_id);
            decimal total = 0;
            decimal impuesto = 0;
            string valorAnterior;

            valorAnterior = row.MONTO_TOTAL.ToString();

            for (int i = 0; i < detalleRows.Length; i++)
            {
                total += detalleRows[i].TOTAL;
                impuesto += detalleRows[i].IMPUESTO_MONTO;
            }

            row.MONTO_TOTAL = total;
            row.SALDO_POR_APLICAR = total;
            row.TOTAL_IMPUESTO = impuesto;

            sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.Update(row);
            LogCambiosService.LogDeColumna(Nombre_Tabla, NotasCreditoProveedorService.MontoTotal_NombreCol, row.ID, valorAnterior, row.MONTO_TOTAL.ToString(), sesion);
        }
        #endregion RecalcularTotal

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                NOTAS_CREDITO_PROVEEDORESRow row = new NOTAS_CREDITO_PROVEEDORESRow();

                try
                {
                    SucursalesService sucursal = new SucursalesService();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[NotasCreditoProveedorService.SucursalId_NombreCol].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.NOTA_CREDITO_PROVEEDOR.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("notas_credito_proveedores_sqc");
                        row.FECHA = DateTime.Now;
                        row.MONTO_TOTAL = 0;
                        row.SALDO_POR_APLICAR = 0;
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.GetByPrimaryKey((decimal)campos[NotasCreditoProveedorService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    if (row.SUCURSAL_ID != (decimal)campos[NotasCreditoProveedorService.SucursalId_NombreCol])
                    {
                        if (SucursalesService.EstaActivo((decimal)campos[NotasCreditoProveedorService.SucursalId_NombreCol]))
                        {
                            row.SUCURSAL_ID = (decimal)campos[NotasCreditoProveedorService.SucursalId_NombreCol];
                            CasosService.ActualizarSucursal(row.CASO_ID, row.SUCURSAL_ID, sesion);
                        }
                        else
                            throw new System.Exception("La sede se encuentra inactiva.");
                    }
                    if (campos.Contains(NotasCreditoProveedorService.DepositoId_NombreCol))
                    {
                       
                            row.DEPOSITO_ID = (decimal)campos[NotasCreditoProveedorService.DepositoId_NombreCol];
                       
                    }

                    if (row.PROVEEDOR_ID != (decimal)campos[NotasCreditoProveedorService.ProveedorId_NombreCol])
                    {
                        if (ProveedoresService.EstaActivo((decimal)campos[NotasCreditoProveedorService.ProveedorId_NombreCol]))
                            row.PROVEEDOR_ID = (decimal)campos[NotasCreditoProveedorService.ProveedorId_NombreCol];
                        else
                            throw new System.Exception("El proveedor se encuentra inactivo.");
                    }

                    //No se utiliza autonumeracion
                    row.IsAUTONUMERACION_IDNull = true;

                    // Se guarda el nro de timbrado y comprobante si no existe ya en db una factura de ese proveedor con ese nro de timbrado y comprobante
                    if (insertarNuevo)
                    {
                        if (!campos[NotasCreditoProveedorService.NroTimbrado_NombreCol].Equals(string.Empty) && !campos[NotasCreditoProveedorService.NroComprobante_NombreCol].Equals(string.Empty))
                        {
                            DataTable dtNCRepetidas = NotasCreditoProveedorService.GetNotaCreditoProveedorDataTable(NotasCreditoProveedorService.ProveedorId_NombreCol + " = " + (decimal)campos[NotasCreditoProveedorService.ProveedorId_NombreCol] + " and " +
                                                                                                              NotasCreditoProveedorService.NroTimbrado_NombreCol + " = '" + (string)campos[NotasCreditoProveedorService.NroTimbrado_NombreCol] + "' and " +
                                                                                                              NotasCreditoProveedorService.NroComprobante_NombreCol + " = '" + (string)campos[NotasCreditoProveedorService.NroComprobante_NombreCol] + "'", string.Empty);
                            if (dtNCRepetidas.Rows.Count > 0)
                            {
                                throw new Exception("Ya existe una nota de crédito de ese proveedor con ese nro. de timbrado y nro. de comprobante.");
                            }
                            else
                            {
                                row.NRO_COMPROBANTE = (string)campos[NotasCreditoProveedorService.NroComprobante_NombreCol];
                                row.NRO_TIMBRADO = campos[NotasCreditoProveedorService.NroTimbrado_NombreCol].ToString();
                            }
                        }
                        else
                        {
                            row.NRO_COMPROBANTE = (string)campos[NotasCreditoProveedorService.NroComprobante_NombreCol];
                            row.NRO_TIMBRADO = campos[NotasCreditoProveedorService.NroTimbrado_NombreCol].ToString();
                        }
                    }
                    else
                    {
                        if (!campos[NotasCreditoProveedorService.NroTimbrado_NombreCol].Equals(string.Empty) && !campos[NotasCreditoProveedorService.NroComprobante_NombreCol].Equals(string.Empty))
                        {
                            DataTable dtNCRepetidas = NotasCreditoProveedorService.GetNotaCreditoProveedorDataTable(NotasCreditoProveedorService.ProveedorId_NombreCol + " = " + (decimal)campos[NotasCreditoProveedorService.ProveedorId_NombreCol] + " and " +
                                                                                                                 NotasCreditoProveedorService.NroTimbrado_NombreCol + " = '" + (string)campos[NotasCreditoProveedorService.NroTimbrado_NombreCol] + "' and " +
                                                                                                                 NotasCreditoProveedorService.NroComprobante_NombreCol + " = '" + (string)campos[NotasCreditoProveedorService.NroComprobante_NombreCol] + "' and " +
                                                                                                                 NotasCreditoProveedorService.Id_NombreCol + " <> " + (decimal)campos[NotasCreditoProveedorService.Id_NombreCol], string.Empty);
                            if (dtNCRepetidas.Rows.Count > 0)
                            {
                                throw new Exception("Ya existe una nota de crédito de ese proveedor con ese nro. de timbrado y nro. de comprobante.");
                            }
                            else
                            {
                                row.NRO_COMPROBANTE = (string)campos[NotasCreditoProveedorService.NroComprobante_NombreCol];
                                row.NRO_TIMBRADO = campos[NotasCreditoProveedorService.NroTimbrado_NombreCol].ToString();
                            }
                        }
                        else
                        {
                            row.NRO_COMPROBANTE = (string)campos[NotasCreditoProveedorService.NroComprobante_NombreCol];
                            row.NRO_TIMBRADO = campos[NotasCreditoProveedorService.NroTimbrado_NombreCol].ToString();
                        }
                    }

                    row.FECHA = (DateTime)campos[NotasCreditoProveedorService.Fecha_NombreCol];

                    if (!MonedasService.EstaActivo((decimal)campos[NotasCreditoProveedorService.MonedaId_NombreCol]))
                    {
                        throw new System.Exception("La moneda se encuentra inactiva.");
                    }
                    else
                    {
                        row.MONEDA_ID = (decimal)campos[NotasCreditoProveedorService.MonedaId_NombreCol];
                        row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, row.FECHA, sesion);

                        // Si no existe una cotización definida para la fecha, intentar con la fecha de creación del caso
                        if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        {
                            DateTime fecha = (DateTime)CasosService.GetCasoPorId(Convert.ToDecimal(caso_id)).FECHA_CREACION;
                            row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, fecha, sesion);
                        }

                        if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("Debe actualizarse la cotización de la moneda.");
                    }

                    if (!FuncionariosService.EstaActivo((decimal)campos[NotasCreditoProveedorService.FuncionarioResponsableId_NombreCol]))
                        throw new System.Exception("El funcionario se encuentra inactivo.");
                    else
                        row.FUNCIONARIO_RESPONSBLE_ID = (decimal)campos[NotasCreditoProveedorService.FuncionarioResponsableId_NombreCol];

                    row.OBSERVACION = (string)campos[NotasCreditoProveedorService.Observacion_NombreCol];

                    if (insertarNuevo) sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.Insert(row);
                    else sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.ProveedorId_NombreCol, row.PROVEEDOR_ID);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
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
                    NOTAS_CREDITO_PROVEEDORESRow cabecera = sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.GetByCASO_ID(caso_id)[0];
                    DataTable dtDetalles;

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                       //Borrar los detalles del caso
                        dtDetalles = NotasCreditoProveedorDetalleService.GetNotaCreditoProveedoresDetalleDataTable(NotasCreditoProveedorDetalleService.NotaCreditoId_NombreCol + " = " + cabecera.ID, NotasCreditoProveedorDetalleService.Id_NombreCol);
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            NotasCreditoProveedorDetalleService.Borrar((decimal)dtDetalles.Rows[i][NotasCreditoProveedorDetalleService.Id_NombreCol]);
                        }

                        sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.DeleteByCASO_ID(caso_id);
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

        #region ObtenerPagosAsociados
        public static DataTable ObtenerPagosAsociados(decimal notaCreditoId)
        {
            using (SessionService sesion = new SessionService())
            {
                String sql = "";

                sql = "select c." + CasosService.Id_NombreCol + " , opv." + OrdenesPagoValoresService.MontoOrigen_NombreCol + ", c." + CasosService.EstadoId_NombreCol + "\n"
                + "  from " + OrdenesPagoValoresService.Nombre_Tabla + " opv \n"
                + "  join " + OrdenesPagoService.Nombre_Tabla + " op on opv." + OrdenesPagoValoresService.OrdenPagoId_NombreCol + " = op." + OrdenesPagoService.Id_NombreCol
                + "  join " + CasosService.Nombre_Tabla + " c on op." + OrdenesPagoService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'"
                + "   where opv." + OrdenesPagoValoresService.NotaCreditoProveedorId_NombreCol + " = " + notaCreditoId;
                return sesion.db.EjecutarQuery(sql); ;
            }
        }
        #endregion ObtenerPagosAsociados

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "NOTAS_CREDITO_PROVEEDORES"; }
        }
        public static string Nombre_Vista
        {
            get { return "NOTAS_CREDITO_PROVEED_INF_COMP"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.CASO_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.DEPOSITO_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.FECHAColumnName; }
        }
        public static string FuncionarioResponsableId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.FUNCIONARIO_RESPONSBLE_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.MONEDA_IDColumnName; }
        }
        public static string MontoTotal_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.MONTO_TOTALColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string NroTimbrado_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.NRO_TIMBRADOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.OBSERVACIONColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.PROVEEDOR_IDColumnName; }
        }
        public static string SaldoPorAplicar_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.SALDO_POR_APLICARColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.SUCURSAL_IDColumnName; }
        }
        public static string TotalImpuesto_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORESCollection.TOTAL_IMPUESTOColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEED_INF_COMPCollection.CASO_ESTADOColumnName; }
        }
        public static string VistaDepositoNombre_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEED_INF_COMPCollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEED_INF_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaProveedorNombre_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEED_INF_COMPCollection.PROVEEDOR_NOMBREColumnName; }
        }
        public static string VistaFuncionarioResponsNombre_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEED_INF_COMPCollection.FUNCIONARIO_RESPONS_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEED_INF_COMPCollection.MONEDAS_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEED_INF_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static NotasCreditoProveedorService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new NotasCreditoProveedorService(e.RegistroId, sesion);
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
        protected NOTAS_CREDITO_PROVEEDORESRow row;
        protected NOTAS_CREDITO_PROVEEDORESRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? AutonumeracionId { get { if (row.IsAUTONUMERACION_IDNull) return null; else return row.AUTONUMERACION_ID; } set { if (value.HasValue) row.AUTONUMERACION_ID = value.Value; else row.IsAUTONUMERACION_IDNull = true; } }
        public decimal CasoId { get { return row.CASO_ID; } set { row.CASO_ID = value; } }
        public decimal CotizacionMoneda { get { return row.COTIZACION_MONEDA; } set { row.COTIZACION_MONEDA = value; } }
        public decimal? DepositoId { get { if (row.IsDEPOSITO_IDNull) return null; else return row.DEPOSITO_ID; } set { if (value.HasValue) row.DEPOSITO_ID = value.Value; else row.IsDEPOSITO_IDNull = true; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public decimal FuncionarioResponsableId { get { return row.FUNCIONARIO_RESPONSBLE_ID; } set { row.FUNCIONARIO_RESPONSBLE_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal MontoTotal { get { return row.MONTO_TOTAL; } set { row.MONTO_TOTAL = value; } }
        public string NroComprobante { get { return ClaseCBABase.GetStringHelper(row.NRO_COMPROBANTE); } set { row.NRO_COMPROBANTE = value; } }
        public string NroTimbrado { get { return ClaseCBABase.GetStringHelper(row.NRO_TIMBRADO); } set { row.NRO_TIMBRADO = value; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal ProveedorId { get { return row.PROVEEDOR_ID; } set { row.PROVEEDOR_ID = value; } }
        public decimal Saldo { get { return row.SALDO_POR_APLICAR; } set { row.SALDO_POR_APLICAR = value; } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } set { row.SUCURSAL_ID = value; } }
        public decimal? TotalImpuesto { get { if (row.IsTOTAL_IMPUESTONull) return null; else return row.TOTAL_IMPUESTO; } set { if (value.HasValue) row.TOTAL_IMPUESTO = value.Value; else row.IsTOTAL_IMPUESTONull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CasosService _caso;
        public CasosService Caso
        {
            get
            {
                if (this._caso == null)
                {
                    if (this.sesion != null)
                        this._caso = new CasosService(this.CasoId, this.sesion);
                    else
                        this._caso = new CasosService(this.CasoId);
                }
                return this._caso;
            }
        }

        private StockDepositosService _deposito;
        public StockDepositosService Deposito
        {
            get
            {
                if (this._deposito == null)
                {
                    if (this.sesion != null)
                        this._deposito = new StockDepositosService(this.DepositoId.Value, this.sesion);
                    else
                        this._deposito = new StockDepositosService(this.DepositoId.Value);
                }
                return this._deposito;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                {
                    if (this.sesion != null)
                        this._moneda = new MonedasService(this.MonedaId, this.sesion);
                    else
                        this._moneda = new MonedasService(this.MonedaId);
                }
                return this._moneda;
            }
        }

        private FuncionariosService _funcionario_responsable;
        public FuncionariosService FuncionarioResponsable
        {
            get
            {
                if (this._funcionario_responsable == null)
                {
                    if (this.sesion != null)
                        this._funcionario_responsable = new FuncionariosService(this.FuncionarioResponsableId, this.sesion);
                    else
                        this._funcionario_responsable = new FuncionariosService(this.FuncionarioResponsableId);
                }
                return this._funcionario_responsable;
            }
        }

        private ProveedoresService _proveedor;
        public ProveedoresService Proveedor
        {
            get
            {
                if (this._proveedor == null)
                {
                    if (this.sesion != null)
                        this._proveedor = new ProveedoresService(this.ProveedorId, this.sesion);
                    else
                        this._proveedor = new ProveedoresService(this.ProveedorId);
                }
                return this._proveedor;
            }
        }

        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                {
                    if (this.sesion != null)
                        this._sucursal = new SucursalesService(this.SucursalId, this.sesion);
                    else
                        this._sucursal = new SucursalesService(this.SucursalId);
                }
                return this._sucursal;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.NOTAS_CREDITO_PROVEEDORESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new NOTAS_CREDITO_PROVEEDORESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(NOTAS_CREDITO_PROVEEDORESRow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public NotasCreditoProveedorService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public NotasCreditoProveedorService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public NotasCreditoProveedorService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        public NotasCreditoProveedorService(EdiCBA.NotaCreditoProveedor edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = NotasCreditoProveedorService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            this.CasoId = edi.caso_id;

            #region deposito
            if (!string.IsNullOrEmpty(edi.deposito_uuid))
                this._deposito = StockDepositosService.GetPorUUID(edi.deposito_uuid, sesion);
            if (this._deposito == null && edi.deposito != null)
                this._deposito = new StockDepositosService(edi.deposito, almacenar_localmente, sesion);
            if (this._deposito == null)
                throw new Exception("No se encontró el UUID " + edi.deposito_uuid + " ni se definieron los datos del objeto.");
            
            if (!this.Deposito.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Deposito.Id.HasValue)
                this.DepositoId = this.Deposito.Id.Value;
            #endregion deposito

            this.Fecha = edi.fecha;
            
            if(edi.cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion'.");
            this.CotizacionMoneda = edi.cotizacion.compra;
            
            #region moneda
            if (!string.IsNullOrEmpty(edi.moneda_uuid))
                this._moneda = MonedasService.GetPorUUID(edi.moneda_uuid, sesion);
           
            if (this._moneda == null)
                throw new Exception("No se encontró el UUID " + edi.moneda_uuid + " ni se definieron los datos del objeto.");

            if (!this.Moneda.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Moneda.Id.HasValue)
                this.MonedaId = this.Moneda.Id.Value;
            #endregion moneda destino

            #region funcionario responsable
            if (!string.IsNullOrEmpty(edi.funcionario_uuid))
                this._funcionario_responsable = FuncionariosService.GetPorUUID(edi.funcionario_uuid, sesion);
            if (this._funcionario_responsable == null && edi.funcionario != null)
                this._funcionario_responsable = new FuncionariosService(edi.funcionario, almacenar_localmente, sesion);
            if (this._funcionario_responsable != null)
            {
                if (!this.FuncionarioResponsable.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.FuncionarioResponsable.Id.HasValue)
                    this.FuncionarioResponsableId = this.FuncionarioResponsable.Id.Value;
            }
            #endregion funcionario responsable

            this.NroComprobante = edi.nro_comprobante;
            this.NroTimbrado = edi.nro_timbrado;
            this.Observacion = edi.observacion;
            
            #region proveedor
            if (!string.IsNullOrEmpty(edi.proveedor_uuid))
                this._proveedor = ProveedoresService.GetPorUUID(edi.proveedor_uuid, sesion);
            if (this._proveedor == null && edi.proveedor != null)
                this._proveedor = new ProveedoresService(edi.proveedor, almacenar_localmente, sesion);
            if (this._proveedor == null)
                throw new Exception("No se encontró el UUID " + edi.proveedor_uuid + " ni se definieron los datos del objeto.");

            if (!this.Proveedor.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Proveedor.Id.HasValue)
                this.ProveedorId = this.Proveedor.Id.Value;
            #endregion proveedor

            #region sucursal
            if (!string.IsNullOrEmpty(edi.sucursal_uuid))
                this._sucursal = SucursalesService.GetPorUUID(edi.sucursal_uuid, sesion);
            if (this._sucursal == null && edi.sucursal != null)
                this._sucursal = new SucursalesService(edi.sucursal, almacenar_localmente, sesion);
            if (this._sucursal == null)
                throw new Exception("No se encontró el UUID " + edi.sucursal_uuid + " ni se definieron los datos del objeto.");

            if (!this.Sucursal.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Sucursal.Id.HasValue)
                this.SucursalId = this.Sucursal.Id.Value;
            #endregion sucursal

            this.MontoTotal = edi.total_neto;
            this.TotalImpuesto = edi.total_impuesto;
            this.Saldo = edi.total_saldo;

            #region caso
            if (!this.ExisteEnDB)
            {
                this._caso = new CasosService(
                    new EdiCBA.Caso()
                    {
                        estado_id = edi.estado_id,
                        funcionario_uuid = edi.funcionario_uuid,
                        funcionario = edi.funcionario,
                        nro_comprobante = edi.nro_comprobante,
                        persona_uuid = edi.persona_uuid,
                        persona = edi.persona,
                        proveedor_uuid = edi.proveedor_uuid,
                        proveedor = edi.proveedor,
                        sucursal_uuid = edi.sucursal_uuid,
                        sucursal = edi.sucursal
                    }, almacenar_localmente, sesion
                );
                this.Caso.FechaCreacion = edi.fecha;
                this.Caso.FechaFormulario = edi.fecha;
                this.Caso.FlujoId = Definiciones.FlujosIDs.NOTA_CREDITO_PROVEEDOR;
                this.Caso.NroComprobante2 = string.Empty;
            }
            #endregion caso
        }
        private NotasCreditoProveedorService(NOTAS_CREDITO_PROVEEDORESRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCaso
        public static NotasCreditoProveedorService GetPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCaso(caso_id, sesion);
            }
        }

        public static NotasCreditoProveedorService GetPorCaso(decimal caso_id, SessionService sesion)
        {
            var row = sesion.db.NOTAS_CREDITO_PROVEEDORESCollection.GetByCASO_ID(caso_id)[0];
            return new NotasCreditoProveedorService(row);
        }
        #endregion GetPorCaso

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.NotaCreditoProveedor()
            {
                caso_id = this.CasoId,
                proveedor_uuid = this.Proveedor.GetOrCreateUUID(sesion),
                cotizacion_uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, NotasCreditoProveedorService.CotizacionMoneda_NombreCol, this.Id.Value, sesion),
                deposito_uuid = this.Deposito.GetOrCreateUUID(sesion),
                estado_id = this.Caso.EstadoId,
                fecha = this.Fecha,
                moneda_uuid = this.Moneda.GetOrCreateUUID(sesion),
                nro_comprobante = this.NroComprobante,
                nro_timbrado = this.NroTimbrado,
                observacion = this.Observacion,
                sucursal_uuid = this.Sucursal.GetOrCreateUUID(sesion),
                total_neto = this.MontoTotal,
                total_impuesto = this.TotalImpuesto.HasValue ? this.TotalImpuesto.Value : 0,
                total_saldo = this.Saldo
            };

            var detalles = NotasCreditoProveedorDetalleService.GetPorCabecera(this.Id.Value, sesion);
            e.nota_credito_proveedor_detalles_uuid = new string[detalles.Length];
            for (int i = 0; i < detalles.Length; i++)
                e.nota_credito_proveedor_detalles_uuid[i] = detalles[i].GetOrCreateUUID(sesion);

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            { 
                e.proveedor = (EdiCBA.Proveedor)this.Proveedor.ToEDI(nueva_profundidad, sesion);
                e.cotizacion = new EdiCBA.Cotizacion()
                {
                    uuid = e.cotizacion_uuid,
                    fecha = this.Fecha,
                    moneda_uuid = e.moneda_uuid,
                    compra = this.CotizacionMoneda
                };
                e.deposito = (EdiCBA.Deposito)this.Deposito.ToEDI(nueva_profundidad, sesion);
                e.funcionario = (EdiCBA.Funcionario)this.FuncionarioResponsable.ToEDI(nueva_profundidad, sesion);
                e.moneda = (EdiCBA.Moneda)this.Moneda.ToEDI(nueva_profundidad, sesion);
                e.sucursal = (EdiCBA.Sucursal)this.Sucursal.ToEDI(nueva_profundidad, sesion);

                e.nota_credito_proveedor_detalles = new EdiCBA.NotaCreditoProveedorDetalle[detalles.Length];
               
            }
            
            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value);
            }
            return e;
        }
        #endregion ToEDI
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
