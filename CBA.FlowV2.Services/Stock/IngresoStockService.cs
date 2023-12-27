#region Using
using System;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Facturacion;
using System.Collections;
using CBA.FlowV2.Services.Common;
using System.Collections.Generic;
using CBA.FlowV2.Services.TextosPredefinidos;

#endregion Using

namespace CBA.FlowV2.Services.Stock
{
    public class IngresoStockService : FlujosServiceBaseWorkaround
    {
        #region Crear Caso
        public static void CrearCaso(decimal pCasoFacturaProveedor, decimal pUsuario, string pDireccionIp, out decimal pCasoResultante, SessionService sesion, out string pMensaje, string estadoInicial)
        {
            //Variables de caso
            string vEstadoCaso;
            decimal vGastosImportacioSinImpuestos = 0;
            decimal vGastoFactura = 0;
            decimal vCantidadDetallesArticulos;
            decimal vTotalFacturas;
            decimal vGastosFacturasSinImpuestos = 0;
            decimal vMontoServicios = 0;
            decimal vImpuestosservicios = 0;
            decimal vTotalArticulosFactura = 0;

            pCasoResultante = Definiciones.Error.Valor.EnteroPositivo;
            pMensaje = string.Empty;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT c." + CasosService.EstadoId_NombreCol + ", \n");
                sql.Append("       fp." + FacturasProveedorService.Id_NombreCol + ", \n");
                sql.Append("       fp." + FacturasProveedorService.SucursalId_NombreCol + ", \n");
                sql.Append("       fp." + FacturasProveedorService.MonedaId_NombreCol + ", \n");
                sql.Append("       fp." + FacturasProveedorService.MonedaCotizacion_NombreCol + ", \n");
                sql.Append("       fp." + FacturasProveedorService.MonedaPaisCotizacion_NombreCol + ", \n");
                sql.Append("       fp." + FacturasProveedorService.StockDepositoId_NombreCol + ", \n");
                sql.Append("       Nvl(fp." + FacturasProveedorService.VistaPorcentajeProrrateoImportacion_NombreCol + ", 0) porc_prorrateo, \n");
                sql.Append("       fp." + FacturasProveedorService.TotalPago_NombreCol + ", \n");
                sql.Append("       fp." + FacturasProveedorService.AplicarProrrateoServicios_NombreCol + ", \n");
                sql.Append("       fp." + FacturasProveedorService.TotalImpuesto_NombreCol + " \n");
                sql.Append("FROM   facturas_proveedor_info_comp fp, \n");
                sql.Append("       casos c \n");
                sql.Append("WHERE  fp." + FacturasProveedorService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " \n");
                sql.Append("       AND c." + CasosService.Id_NombreCol + " = " + pCasoFacturaProveedor.ToString());

                DataTable dtResultado = sesion.db.EjecutarQuery(sql.ToString());

                foreach (DataRow row in dtResultado.Rows)
                {
                    bool conversionMonedaRealizada = false;

                    //vFacturaProrrateo es cero significa que la factura no se incluye en ninguna importacion.
                    if ((decimal)row["porc_prorrateo"] == 0)
                    {
                        vGastosImportacioSinImpuestos = 0;
                        vGastoFactura = 0;

                        if (row[FacturasProveedorService.AplicarProrrateoServicios_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                        {
                            string prorrateo = " select fpd.total_pago as total_pago, \n";
                            prorrateo += " fpd.porcentaje_impuesto \n";
                            prorrateo += " from facturas_proveedor fp, facturas_proveedor_detalle fpd, articulos a \n";
                            prorrateo += " where fp.id = fpd.facturas_proveedor_id \n";
                            prorrateo += " and fpd.articulo_id = a.id \n";
                            prorrateo += " and a.servicio = 'S' \n";
                            prorrateo += " and fp.caso_id=" + pCasoFacturaProveedor.ToString();

                            DataTable dtTotalProrrateo = sesion.db.EjecutarQuery(prorrateo.ToString());
                            decimal totalPago = 0;
                            decimal impuestoPorcentaje = 0;
                            vMontoServicios = 0;
                            vImpuestosservicios = 0;
                            if (dtTotalProrrateo.Rows.Count > 0)
                            {
                                totalPago = 0;
                                impuestoPorcentaje = 0;

                                for (int i = 0; i < dtTotalProrrateo.Rows.Count; i++)
                                {
                                    totalPago = decimal.Parse(dtTotalProrrateo.Rows[i]["total_pago"].ToString());
                                    impuestoPorcentaje = decimal.Parse(dtTotalProrrateo.Rows[i]["porcentaje_impuesto"].ToString());
                                    if (impuestoPorcentaje > 0)
                                        vImpuestosservicios += (totalPago / ((100 / impuestoPorcentaje) + 1));
                                    vMontoServicios += totalPago;
                                }
                                vTotalFacturas = decimal.Parse(dtResultado.Rows[0][FacturasProveedorService.TotalPago_NombreCol].ToString());
                                vTotalArticulosFactura = vTotalFacturas - vMontoServicios;
                                vMontoServicios = vMontoServicios - vImpuestosservicios;
                            }
                        }
                    }
                    else
                    {
                        StringBuilder sql2 = new StringBuilder();
                        sql2.Append("SELECT iic." + ImportacionesService.VistaTotalGastos_NombreCol + ",\n");
                        sql2.Append("       iic." + ImportacionesService.VistaTotalFacturas_NombreCol + ",\n");
                        sql2.Append("       iic." + ImportacionesService.VistaMonedaPaisId_NombreCol + ",\n");
                        sql2.Append("       iic." + ImportacionesService.VistaMonedaPaisCotizacion_NombreCol + "\n");
                        sql2.Append("FROM   importaciones_info_completa iic, \n");
                        sql2.Append("       facturas_proveedor fp2 \n");
                        sql2.Append("WHERE  fp2." + FacturasProveedorService.ImportacionId_NombreCol + " = iic." + ImportacionesService.Id_NombreCol + " \n");
                        sql2.Append("       AND fp2." + FacturasProveedorService.CasoId_NombreCol + " = " + pCasoFacturaProveedor.ToString());

                        DataTable dtTotalImportaciones;
                        dtTotalImportaciones = sesion.db.EjecutarQuery(sql2.ToString());

                        if (dtTotalImportaciones.Rows.Count > 0)
                        {
                            vGastosImportacioSinImpuestos = (decimal)dtTotalImportaciones.Rows[0][ImportacionesService.VistaTotalGastos_NombreCol];
                            vTotalFacturas = (decimal)dtTotalImportaciones.Rows[0][ImportacionesService.VistaTotalFacturas_NombreCol];
                            vGastoFactura = (decimal)row[FacturasProveedorService.TotalPago_NombreCol] * vGastosImportacioSinImpuestos / vTotalFacturas;
                            vGastosFacturasSinImpuestos = ((decimal)row[FacturasProveedorService.TotalPago_NombreCol] - (decimal)row[FacturasProveedorService.TotalImpuesto_NombreCol]) * vGastosImportacioSinImpuestos / vTotalFacturas;

                            //Si la factura tiene una moneda distinta a la moneda principal del pais, convertir el monto segun cotizaciones
                            if ((decimal)row[FacturasProveedorService.MonedaId_NombreCol] != (decimal)dtTotalImportaciones.Rows[0][ImportacionesService.VistaMonedaPaisId_NombreCol])
                            {
                                conversionMonedaRealizada = true;
                                vGastoFactura = vGastoFactura / (decimal)row[FacturasProveedorService.MonedaCotizacion_NombreCol] * (decimal)dtTotalImportaciones.Rows[0][ImportacionesService.VistaMonedaPaisCotizacion_NombreCol];
                                vGastosFacturasSinImpuestos = vGastosFacturasSinImpuestos / (decimal)row[FacturasProveedorService.MonedaCotizacion_NombreCol] * (decimal)dtTotalImportaciones.Rows[0][ImportacionesService.VistaMonedaPaisCotizacion_NombreCol];
                            }
                        }
                    }

                    //se obtiene la cantidad de articulos
                    vCantidadDetallesArticulos = FacturasProveedorDetalleService.GetCantidadDeArticulosPorDetalleFacturaProveedor(row[FacturasProveedorService.Id_NombreCol].ToString(), sesion);

                    //Si ningun detalle es de articulo y lote no se crea el caso
                    if (vCantidadDetallesArticulos > 0)
                    {
                        string vEstatdo = string.Empty;
                        vEstadoCaso = row[CasosService.EstadoId_NombreCol].ToString();
                        //El caso de factura de proveedor debe estar en el estado aprobado
                        if (vEstadoCaso != Definiciones.EstadosFlujos.Pendiente && vEstadoCaso != Definiciones.EstadosFlujos.EnRevision)
                        {
                            pMensaje = "El caso" + pCasoFacturaProveedor.ToString() + " no está pasando al estado Aprobado.";
                        }

                        //Creamos el caso de ingreso de stock
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(row[FacturasProveedorService.SucursalId_NombreCol].ToString()),
                                                         int.Parse(Definiciones.FlujosIDs.INGRESO_DE_STOCK.ToString()),
                                                         int.Parse(sesion.Usuario_Id.ToString()),
                                                         SessionService.GetClienteIP());

                        pCasoResultante = int.Parse(CrearCaso.Ejecutar(sesion, estadoInicial));

                        //Se verifica la cotizacion de la moneda
                        if (!conversionMonedaRealizada && (decimal)row[FacturasProveedorService.MonedaId_NombreCol] != VariablesSistemaEntidadService.GetValorInt(CBA.FlowV2.Services.Base.Definiciones.VariablesDeSistema.MonedaBaseSistemaId))
                        {
                            vGastoFactura = vGastoFactura * (decimal)row[FacturasProveedorService.MonedaCotizacion_NombreCol];
                            vGastosFacturasSinImpuestos = vGastosImportacioSinImpuestos * (decimal)row[FacturasProveedorService.MonedaCotizacion_NombreCol];
                        }

                        #region Insertar Cabecera
                        //Insertar la cabecera del caso nuevo
                        INGRESO_STOCKRow nuevoIngreso = new INGRESO_STOCKRow();
                       DataTable dtAutonumeracions = AutonumeracionesService.GetAutonumeracionesPorFlujo2(Definiciones.FlujosIDs.INGRESO_DE_STOCK, (decimal)row[FacturasProveedorService.SucursalId_NombreCol]);
                       if (dtAutonumeracions.Rows.Count < 1)
                           throw new Exception("La sucursal no tiene autonumeración disponible para crear el caso de Ingreso de Stock.");

                        nuevoIngreso.ID = sesion.Db.GetSiguienteSecuencia("ingreso_stock_sqc");
                        nuevoIngreso.CASO_ID = pCasoResultante;
                        nuevoIngreso.SUCURSAL_ID = (decimal)row[FacturasProveedorService.SucursalId_NombreCol];
                        nuevoIngreso.DEPOSITO_ID = (decimal)row[FacturasProveedorService.StockDepositoId_NombreCol];
                        nuevoIngreso.FECHA = DateTime.Now;
                        nuevoIngreso.AUTONUMERACION_ID = (decimal)dtAutonumeracions.Rows[0][AutonumeracionesService.Id_NombreCol];
                        nuevoIngreso.CASO_FC_PROVEEDOR_ID = pCasoFacturaProveedor;
                        nuevoIngreso.PORCENTAJE_PRORATEO = (decimal)row["porc_prorrateo"];
                        nuevoIngreso.MONTO_PRORATEO = vGastosImportacioSinImpuestos;
                        nuevoIngreso.TIPO_PRORRATEO = Definiciones.TipoProrrateo.Proporcional;

                        sesion.Db.INGRESO_STOCKCollection.Insert(nuevoIngreso);

                        #region Actualizar datos en tabla casos
                        Hashtable camposCaso = new Hashtable();
                        camposCaso.Add(CasosService.FechaFormulario_NombreCol, nuevoIngreso.FECHA);
                        camposCaso.Add(CasosService.NroComprobante_NombreCol, nuevoIngreso.NRO_COMPROBANTE);
                        camposCaso.Add(CasosService.SucursalId_NombreCol, nuevoIngreso.SUCURSAL_ID);
                        CasosService.ActualizarCampos(nuevoIngreso.CASO_ID, camposCaso, sesion);
                        #endregion Actualizar datos en tabla casos
                        #endregion Insertar Cabcecera

                        #region Insertar Detalles
                        string clausulas = FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + row[FacturasProveedorService.Id_NombreCol].ToString();
                        clausulas += " and " + FacturasProveedorDetalleService.AfectaStock_NombreCol + " = '" + Definiciones.SiNo.Si + "'";
                        DataTable dtFacturaProveedorDetalle = FacturasProveedorDetalleService.GetFacturaProveedorDetalleDataTable(clausulas, string.Empty, sesion);

                        foreach (DataRow rowDet in dtFacturaProveedorDetalle.Rows)
                        {
                            //Si el articulo no debe afectar el stock se salta el articulo y se continua con el siguiente
                            if (rowDet[FacturasProveedorDetalleService.AfectaStock_NombreCol].Equals(Definiciones.SiNo.No))
                                continue;

                            INGRESO_STOCK_DETALLESRow nuevoIngresoDetalle = new INGRESO_STOCK_DETALLESRow();
                            nuevoIngresoDetalle.ID = sesion.Db.GetSiguienteSecuencia("ingreso_stock_detalles_sqc");
                            nuevoIngresoDetalle.INGRESO_STOCK_ID = nuevoIngreso.ID;


                            if (rowDet[FacturasProveedorDetalleService.LoteId_NombreCol] != null)
                                nuevoIngresoDetalle.LOTE_ID = (decimal)rowDet[FacturasProveedorDetalleService.LoteId_NombreCol];
                            else
                                nuevoIngresoDetalle.IsLOTE_IDNull = true;

                            if (rowDet[FacturasProveedorDetalleService.CantidadUnitariaTotalOrigen_NombreCol] != null)
                                nuevoIngresoDetalle.CANTIDAD_TOTAL_ORIGEN = (decimal)rowDet[FacturasProveedorDetalleService.CantidadUnitariaTotalOrigen_NombreCol];


                            nuevoIngresoDetalle.MONEDA_ID = (decimal)row[FacturasProveedorService.MonedaId_NombreCol];
                            nuevoIngresoDetalle.COTIZACION = (decimal)row[FacturasProveedorService.MonedaCotizacion_NombreCol];
                            nuevoIngresoDetalle.MONEDA_PAIS_COTIZACION = (decimal)row[FacturasProveedorService.MonedaPaisCotizacion_NombreCol];
                            nuevoIngresoDetalle.COSTO = (decimal)rowDet[FacturasProveedorDetalleService.TotalPago_NombreCol] / (decimal)rowDet[FacturasProveedorDetalleService.CantidadUnitariaTotalOrigen_NombreCol];

                            if (rowDet[FacturasProveedorDetalleService.PorcentajeImpuesto_NombreCol] != null)
                                nuevoIngresoDetalle.COSTO_IMPUESTO_PORC = (decimal)rowDet[FacturasProveedorDetalleService.PorcentajeImpuesto_NombreCol];

                            if (rowDet[FacturasProveedorDetalleService.UnidadIdOrigen_NombreCol] != null)
                                nuevoIngresoDetalle.UNIDAD_ID = rowDet[FacturasProveedorDetalleService.UnidadIdOrigen_NombreCol].ToString();

                            if (rowDet[FacturasProveedorDetalleService.CantidadUnitariaTotalDestino_NombreCol] != null)
                                nuevoIngresoDetalle.CANTIDAD_TOTAL_DESTINO = (decimal)rowDet[FacturasProveedorDetalleService.CantidadUnitariaTotalDestino_NombreCol];
                            else
                                nuevoIngresoDetalle.IsCANTIDAD_TOTAL_DESTINONull = true;

                            if (rowDet[FacturasProveedorDetalleService.FactorConversion_NombreCol] != null)
                                nuevoIngresoDetalle.FACTOR_CONVERSION = (decimal)rowDet[FacturasProveedorDetalleService.FactorConversion_NombreCol];
                            else
                                nuevoIngresoDetalle.IsFACTOR_CONVERSIONNull = true;

                            if (row[FacturasProveedorService.MonedaId_NombreCol] != null)
                                nuevoIngresoDetalle.MONEDA_ORIGINAL_ID = (decimal)row[FacturasProveedorService.MonedaId_NombreCol];
                            else
                                nuevoIngresoDetalle.IsMONEDA_ORIGINAL_IDNull = true;

                            if (rowDet[FacturasProveedorDetalleService.CantidadUnitariaTotalDestino_NombreCol] != null)
                                nuevoIngresoDetalle.CANTIDAD_ORIGINAL = (decimal)rowDet[FacturasProveedorDetalleService.CantidadUnitariaTotalDestino_NombreCol];
                            else
                                nuevoIngresoDetalle.IsCANTIDAD_ORIGINALNull = true;

                            decimal activoId;
                            if (decimal.TryParse(rowDet[FacturasProveedorDetalleService.ActivoId_NombreCol].ToString(), out activoId))
                                nuevoIngresoDetalle.ACTIVO_ID = activoId;
                            else
                                nuevoIngresoDetalle.IsACTIVO_IDNull = true;

                            if ((decimal)row["porc_prorrateo"] != 0)
                            {
                                if (row[FacturasProveedorService.AplicarProrrateoServicios_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                {
                                    nuevoIngresoDetalle.PORCENTAJE_PRORRATEO_DETALLE = (decimal)row["porc_prorrateo"];
                                    nuevoIngresoDetalle.MONTO_PRORRATEO_DETALLE = ((decimal)rowDet[FacturasProveedorDetalleService.TotalPago_NombreCol] - (decimal)rowDet[FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol]) / nuevoIngresoDetalle.CANTIDAD_ORIGINAL * (decimal)row["porc_prorrateo"];
                                    nuevoIngresoDetalle.MONTO_PRORRATEADO = nuevoIngresoDetalle.MONTO_PRORRATEO_DETALLE + (decimal)rowDet[FacturasProveedorDetalleService.TotalPago_NombreCol] / (decimal)rowDet[FacturasProveedorDetalleService.CantidadUnidadOrigen_NombreCol];
                                }
                            }
                            else
                            {
                                nuevoIngresoDetalle.PORCENTAJE_PRORRATEO_DETALLE = 0;
                                nuevoIngresoDetalle.MONTO_PRORRATEO_DETALLE = 0;
                                nuevoIngresoDetalle.MONTO_PRORRATEADO = nuevoIngresoDetalle.COSTO;
                                if (row[FacturasProveedorService.AplicarProrrateoServicios_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                {
                                    nuevoIngresoDetalle.PORCENTAJE_PRORRATEO_DETALLE = (nuevoIngresoDetalle.COSTO * nuevoIngresoDetalle.CANTIDAD_ORIGINAL) / vTotalArticulosFactura;
                                    nuevoIngresoDetalle.MONTO_PRORRATEO_DETALLE = (vMontoServicios * nuevoIngresoDetalle.PORCENTAJE_PRORRATEO_DETALLE) / nuevoIngresoDetalle.CANTIDAD_ORIGINAL;
                                    nuevoIngresoDetalle.MONTO_PRORRATEADO = nuevoIngresoDetalle.MONTO_PRORRATEO_DETALLE + nuevoIngresoDetalle.COSTO;
                                }
                            }

                            decimal CostoNetoSinDtoOriginal = 0;
                            CostoNetoSinDtoOriginal = (decimal)rowDet[FacturasProveedorDetalleService.TotalPago_NombreCol] - (decimal)rowDet[FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol];

                            if ((decimal)rowDet[FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol] == 0)
                            {
                                CostoNetoSinDtoOriginal = CostoNetoSinDtoOriginal + (decimal)rowDet[FacturasProveedorDetalleService.TotalDescuento_NombreCol];
                            }
                            else
                            {
                                //fpd.total_descuento - (fpd.total_bruto * fpd.porcentaje_descuento / 100 / (1+(100/fpd.porcentaje_impuesto)))
                                CostoNetoSinDtoOriginal = CostoNetoSinDtoOriginal + ((decimal)rowDet[FacturasProveedorDetalleService.TotalDescuento_NombreCol]
                                                                                      - ((decimal)rowDet[FacturasProveedorDetalleService.TotalBruto_NombreCol] * (decimal)rowDet[FacturasProveedorDetalleService.PorcentajeDescuento_NombreCol]
                                                                                      / 100 / (1 + (100 / (decimal)rowDet[FacturasProveedorDetalleService.PorcentajeImpuesto_NombreCol]))));
                            }

                            nuevoIngresoDetalle.COSTO_NETO_SIN_DTO_ORIGINAL = CostoNetoSinDtoOriginal;

                            sesion.db.INGRESO_STOCK_DETALLESCollection.Insert(nuevoIngresoDetalle);

                        }
                        #endregion Insertar Detalles
                    }
                }
            }
            catch (Exception ex)
            {
                pMensaje = ex.Message;
                throw new Exception("Error al crear el caso de Ingreso stock ");
            }
        }

        #endregion Crear Caso

        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.INGRESO_DE_STOCK;
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

            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, drCabecera[IngresoStockService.DepositoId_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, drDetalle[IngresoStockDetalleService.VistaArticuloId_NombreCol]);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, );
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, drDetalle[IngresoStockDetalleService.ActivoId_NombreCol]);
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
            return string.Empty;
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
                INGRESO_STOCKRow cabeceraRow = sesion.Db.INGRESO_STOCKCollection.GetByCASO_ID(caso_id)[0];
                INGRESO_STOCK_DETALLESRow[] detalleRows = sesion.Db.INGRESO_STOCK_DETALLESCollection.GetByINGRESO_STOCK_ID(cabeceraRow.ID);
                // de borrador a anulado
                if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna accion.
                    exito = true;
                    revisarRequisitos = true;
                }
                // de borrador a pendiente
                else if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Crear número de comprobante
                    exito = true;
                    revisarRequisitos = true;

                    if (detalleRows.Length <= 0)
                    {
                        mensaje = "No existen detalles.";
                        exito = false;
                    }

                    #region Generar Autonumeración
                    if (exito)
                    {
                        if (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE == string.Empty)
                        {
                            if (cabeceraRow.IsAUTONUMERACION_IDNull)
                                throw new Exception("Debe indicarse el talonario o un número de comprobante de forma manual.");

                            cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID);
                        }
                    }
                    #endregion Generar Autonumeración
                }
                //de pendiente a borrador
                else if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //Ninguna accion.
                    exito = true;
                    revisarRequisitos = false;
                }
                //de pendiente a borrador
                else if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna accion.
                    exito = true;
                    revisarRequisitos = true;
                }
                // de pendiente a aprobado
                else if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones
                    //Afectar en forma positiva o negativa el stock.
                    revisarRequisitos = true;
                    exito = true;

                    string tipoMoviemiento = string.Empty;

                    foreach (INGRESO_STOCK_DETALLESRow detalle in detalleRows)
                    {
                        var al = new ArticulosLotesService(detalle.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;

                        if (al.Articulo.Servicio == Definiciones.SiNo.No)
                        {
                            decimal montoImpuesto = 0;
                            if (detalle.COSTO_IMPUESTO_PORC > 0)
                                montoImpuesto = detalle.COSTO / (1 + (100 / detalle.COSTO_IMPUESTO_PORC));

                            costo = new StockService.Costo()
                            {
                                moneda_origen_id = detalle.MONEDA_ID,
                                cotizacion_origen = detalle.COTIZACION,
                                moneda_id = caso.Sucursal.Region.SucursalCasaMatriz.Pais.MonedaId
                            };

                            costo.costo_origen = detalle.COSTO - montoImpuesto;
                            if (cabeceraRow.APLICAR_PRORRATEO == Definiciones.SiNo.Si)
                                costo.costo_origen += detalle.MONTO_PRORRATEO_DETALLE;

                            if (costo.moneda_origen_id == costo.moneda_id)
                            {
                                costo.cotizacion = costo.cotizacion_origen;
                                costo.costo = costo.costo_origen;
                            }
                            else
                            {
                                costo.cotizacion = detalle.MONEDA_PAIS_COTIZACION;
                                costo.costo = costo.costo_origen / costo.cotizacion_origen * costo.cotizacion;
                            }
                        }

                        #region Generar Autonumeración
                        if (exito)
                        {
                            if (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE == string.Empty)
                            {
                                if (cabeceraRow.IsAUTONUMERACION_IDNull)
                                    throw new Exception("Debe indicarse el talonario.");
                                if(AutonumeracionesService.EsGeneracionManual(cabeceraRow.AUTONUMERACION_ID))
                                    throw new Exception("Debe cargar manualmente el numero de comprobante.");

                                cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID);
                            }
                        }
                        #endregion Generar Autonumeración

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    Interprete.Redondear(detalle.CANTIDAD_TOTAL_DESTINO, 2),
                                                    Definiciones.Stock.TipoMovimiento.Compra, caso_id, detalle.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    detalle.ID);
                        al.FinalizarUsingSesion();
                    }
                    //TODO agregar generacion de alarmas con respecto a las notas de pedido que esperan el articulo ingresado
                }
                else if (caso.EstadoId.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    revisarRequisitos = true;
                    exito = true;

                    string stockMovimiento = string.Empty;
                    foreach (INGRESO_STOCK_DETALLESRow detalle in detalleRows)
                    {
                        var al = new ArticulosLotesService(detalle.LOTE_ID, sesion);
                        StockService.Costo costo = null;

                        if (al.Articulo.Servicio == Definiciones.SiNo.No)
                        {
                            decimal montoImpuesto = 0;

                            if (detalle.COSTO_IMPUESTO_PORC > 0)
                                montoImpuesto = detalle.COSTO / (1 + (100 / detalle.COSTO_IMPUESTO_PORC));

                            costo = new StockService.Costo()
                            {
                                moneda_origen_id = detalle.MONEDA_ID,
                                cotizacion_origen = detalle.COTIZACION,
                                moneda_id = caso.Sucursal.Region.SucursalCasaMatriz.Pais.MonedaId
                            };

                            costo.costo_origen = detalle.COSTO - montoImpuesto;
                            if (cabeceraRow.APLICAR_PRORRATEO == Definiciones.SiNo.Si)
                                costo.costo_origen += detalle.MONTO_PRORRATEO_DETALLE;

                            if (costo.moneda_origen_id == costo.moneda_id)
                            {
                                costo.cotizacion = costo.cotizacion_origen;
                                costo.costo = costo.costo_origen;
                            }
                            else
                            {
                                costo.cotizacion = detalle.MONEDA_PAIS_COTIZACION;
                                costo.costo = costo.costo_origen / costo.cotizacion_origen * costo.cotizacion;
                            }
                        }

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    Interprete.Redondear(-detalle.CANTIDAD_TOTAL_DESTINO, 0),
                                                    Definiciones.Stock.TipoMovimiento.Compra, caso_id, detalle.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    detalle.ID, true);
                    }
                }

                if (exito && revisarRequisitos)
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);

                if (exito)
                {
                    caso.Guardar(sesion);
                    sesion.Db.INGRESO_STOCKCollection.Update(cabeceraRow);
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

        #region GetIngresoStockDataTable
        /// <summary>
        /// Gets the ingreso stock data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetIngresoStockDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetIngresoStockDataTable(clausula, orden, sesion);
            }
        }

        public static DataTable GetIngresoStockDataTable(string clausula, string orden, SessionService sesion)
        {
            return sesion.Db.INGRESO_STOCKCollection.GetAsDataTable(clausula, orden);
        }
        #endregion GetIngresoStockDataTable

        #region GetIngresoStockInfoCompleta
        /// <summary>
        /// Gets the ingreso stock info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetIngresoStockInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetIngresoStockInfoCompleta(clausulas, orden, sesion);
            }
        }

        /// <summary>
        /// Gets the ingreso stock info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetIngresoStockInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.INGRESO_STOCK_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetIngresoStockInfoCompleta

        #region GetIngresoStockPorCaso

        public DataTable GetIngresoStockPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.INGRESO_STOCKCollection.GetAsDataTable(IngresoStockService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        public static DataTable GetIngresoStockPorCasoStatic(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetIngresoStockPorCasoStatic(caso_id, sesion);
            }
        }
        public static DataTable GetIngresoStockPorCasoStatic(decimal caso_id, SessionService sesion)
        {
            return sesion.Db.INGRESO_STOCKCollection.GetAsDataTable(IngresoStockService.CasoId_NombreCol + " = " + caso_id, string.Empty);
        }
        #endregion GetIngresoStockPorCaso

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        /// 
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return Guardar(campos, insertarNuevo, ref caso_id, ref estado_id, sesion);
            }
        }

        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id, SessionService sesion)
        {
            try
            {
                INGRESO_STOCKRow row = new INGRESO_STOCKRow();
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("ingreso_stock_sqc");
                    CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[IngresoStockService.SucursalId_NombreCol].ToString()),
                                                         int.Parse(Definiciones.FlujosIDs.INGRESO_DE_STOCK.ToString()),
                                                         int.Parse(sesion.Usuario_Id.ToString()),
                                                         SessionService.GetClienteIP());
                    row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                    estado_id = Definiciones.EstadosFlujos.Borrador;
                    row.FECHA = DateTime.Now;
                }
                else
                {
                    row = sesion.Db.INGRESO_STOCKCollection.GetRow(IngresoStockService.Id_NombreCol + " = " + campos[StockAjusteService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                row.SUCURSAL_ID = (decimal)campos[IngresoStockService.SucursalId_NombreCol];
                row.SUCURSAL_ID = (decimal)campos[IngresoStockService.SucursalId_NombreCol];
                row.DEPOSITO_ID = (decimal)campos[IngresoStockService.DepositoId_NombreCol];
                row.AUTONUMERACION_ID = (decimal)campos[IngresoStockService.AutonumeracionId_NombreCol];
                row.FECHA = (DateTime)campos[IngresoStockService.Fecha_NombreCol];
                row.APLICAR_PRORRATEO = (string)campos[IngresoStockService.AplicarProrrateo_NombreCol];

                if (campos.Contains(IngresoStockService.Observacion_NombreCol))
                    row.OBSERVACION = (string)campos[IngresoStockService.Observacion_NombreCol];

                if (campos.Contains(IngresoStockService.CasoFcProveedorId_NombreCol))
                    row.CASO_FC_PROVEEDOR_ID = decimal.Parse(campos[IngresoStockService.CasoFcProveedorId_NombreCol].ToString());

                if (campos.Contains(IngresoStockService.NroComprobante_NombreCol))
                    row.NRO_COMPROBANTE = campos[IngresoStockService.NroComprobante_NombreCol].ToString();

                if (campos.Contains(IngresoStockService.TipoProrrateo_NombreCol))
                    row.TIPO_PRORRATEO = int.Parse(campos[IngresoStockService.TipoProrrateo_NombreCol].ToString());

                if (campos.Contains(IngresoStockService.PorcentajeProrrateo_NombreCol))
                    row.PORCENTAJE_PRORATEO = (decimal)campos[IngresoStockService.PorcentajeProrrateo_NombreCol];
                else
                    row.PORCENTAJE_PRORATEO = 0;

                if (campos.Contains(IngresoStockService.MontoProrrateoId_NombreCol))
                    row.MONTO_PRORATEO = (decimal)campos[IngresoStockService.MontoProrrateoId_NombreCol];
                else
                    row.MONTO_PRORATEO = 0;

                if (campos.Contains(IngresoStockService.TextoPredefinidoId_NombreCol))
                    row.TEXTO_PREDEFINIDO_ID = (decimal)campos[IngresoStockService.TextoPredefinidoId_NombreCol];

                if (campos.Contains(IngresoStockService.NroDocumentoExterno_NombreCol))
                    row.NRO_DOCUMENTO_EXTERNO = campos[IngresoStockService.NroDocumentoExterno_NombreCol].ToString();

                if (insertarNuevo) sesion.Db.INGRESO_STOCKCollection.Insert(row);
                else sesion.Db.INGRESO_STOCKCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();
                camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                if (campos.Contains(IngresoStockService.NroDocumentoExterno_NombreCol))
                    camposCaso.Add(CasosService.NroComprobante2_NombreCol, row.NRO_DOCUMENTO_EXTERNO);
                CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                #endregion Actualizar datos en tabla casos

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Guardar

        #region Borrar
        public bool Borrar(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    bool exito = Borrar(caso_id, sesion);
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

        public bool Borrar(decimal caso_id, SessionService sesion)
        {
            bool exito = true;
            string mensaje = string.Empty;

            //Se obtienen el caso y la factura a ser borrados
            CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
            INGRESO_STOCKRow cabecera = sesion.Db.INGRESO_STOCKCollection.GetByCASO_ID(caso_id)[0];

            if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
            {
                exito = false;
                mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
            }

            if (exito)
                IngresoStockDetalleService.BorrarTodos(cabecera.ID, sesion);

            //Si no se cumple alguna condicion, se lanza la excepcion
            //caso contrario se elimina el caso de la tabla casos y de la cabecera
            if (exito)
            {
                sesion.Db.INGRESO_STOCKCollection.DeleteByCASO_ID(caso_id);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                //Se borra el caso
                (new CasosService()).Eliminar(caso_id, sesion);
            }
            else
            {
                throw new System.ArgumentException(mensaje);
            }

            return exito;
        }
        #endregion borrar

        #region Accessors
        #region Tablas
        public static string Nombre_Tabla
        {
            get { return "INGRESO_STOCK"; }
        }
        public static string Observacion_NombreCol
        {
            get { return INGRESO_STOCKCollection.OBSERVACIONColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return INGRESO_STOCKCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoFcProveedorId_NombreCol
        {
            get { return INGRESO_STOCKCollection.CASO_FC_PROVEEDOR_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return INGRESO_STOCKCollection.CASO_IDColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return INGRESO_STOCKCollection.DEPOSITO_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return INGRESO_STOCKCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return INGRESO_STOCKCollection.IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return INGRESO_STOCKCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return INGRESO_STOCKCollection.SUCURSAL_IDColumnName; }
        }
        public static string PorcentajeProrrateo_NombreCol
        {
            get { return INGRESO_STOCKCollection.PORCENTAJE_PRORATEOColumnName; }
        }
        public static string MontoProrrateoId_NombreCol
        {
            get { return INGRESO_STOCKCollection.MONTO_PRORATEOColumnName; }
        }
        public static string AplicarProrrateo_NombreCol
        {
            get { return INGRESO_STOCKCollection.APLICAR_PRORRATEOColumnName; }
        }
        public static string TipoProrrateo_NombreCol
        {
            get { return INGRESO_STOCKCollection.TIPO_PRORRATEOColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return INGRESO_STOCKCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string NroDocumentoExterno_NombreCol
        {
            get { return INGRESO_STOCKCollection.NRO_DOCUMENTO_EXTERNOColumnName; }
        }
        #endregion Tablas

        #region Vistas
        public static string Nombre_Vista
        {
            get { return "INGRESO_STOCK_INFO_COMPLETA"; }
        }
        public static string VistaCasoEstado_NombreCol
        {
            get { return INGRESO_STOCK_INFO_COMPLETACollection.CASO_ESTADOColumnName; }
        }
        public static string VistaImportacionId_NombreCol
        {
            get { return INGRESO_STOCK_INFO_COMPLETACollection.IMPORTACION_IDColumnName; }
        }
        public static string VistaCasoUsuarioCreadorId_NombreCol
        {
            get { return INGRESO_STOCK_INFO_COMPLETACollection.CASO_USUARIO_CREADOR_IDColumnName; }
        }
        public static string VistaDepositoAbreviatura_NombreCol
        {
            get { return INGRESO_STOCK_INFO_COMPLETACollection.DEPOSITO_ABREVIATURAColumnName; }
        }
        public static string VistaDepositoNombre_NombreCol
        {
            get { return INGRESO_STOCK_INFO_COMPLETACollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaFCNroComprobante_NombreCol
        {
            get { return INGRESO_STOCK_INFO_COMPLETACollection.FC_NRO_COMPROBANTEColumnName; }
        }
        public static string VistaFechaFactura_NombreCol
        {
            get { return INGRESO_STOCK_INFO_COMPLETACollection.FECHA_FACTURAColumnName; }
        }
        public static string VistaSucursalAbrevatura_NombreCol
        {
            get { return INGRESO_STOCK_INFO_COMPLETACollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return INGRESO_STOCK_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaSucursalEntidaId_NombreCol
        {
            get { return INGRESO_STOCK_INFO_COMPLETACollection.SUSCURSAL_ENTIDAD_IDColumnName; }
        }
        public static string VistaUsuarioCreador_NombreCol
        {
            get { return INGRESO_STOCK_INFO_COMPLETACollection.USUARIO_CREADORColumnName; }
        }

        public static string VistaTipoProrrateoNombre_NombreCol
        {
            get { return INGRESO_STOCK_INFO_COMPLETACollection.TIPO_PRORRATEO_NOMBREColumnName; }
        }

        #endregion Vistas
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static IngresoStockService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new IngresoStockService(e.RegistroId, sesion);
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
        protected INGRESO_STOCKRow row;
        protected INGRESO_STOCKRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string AplicarProrrateo { get { return GetStringHelper(row.APLICAR_PRORRATEO); } set { row.APLICAR_PRORRATEO = value; } }
        public decimal? AutonumeracionId { get { if (row.IsAUTONUMERACION_IDNull) return null; else return row.AUTONUMERACION_ID; } set { if (value.HasValue) row.AUTONUMERACION_ID = value.Value; else row.IsAUTONUMERACION_IDNull = true; } }
        public decimal? CasoFCProveedorId { get { if (row.IsCASO_FC_PROVEEDOR_IDNull) return null; else return row.CASO_FC_PROVEEDOR_ID; } set { if (value.HasValue) row.CASO_FC_PROVEEDOR_ID = value.Value; else row.IsCASO_FC_PROVEEDOR_IDNull = true; } }
        public decimal CasoId { get { return row.CASO_ID; } set { row.CASO_ID = value; } }
        public decimal DepositoId { get { return row.DEPOSITO_ID; } set { row.DEPOSITO_ID = value; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? MontoProrrateo { get { if (row.IsMONTO_PRORATEONull) return null; else return row.MONTO_PRORATEO; } set { if (value.HasValue) row.MONTO_PRORATEO = value.Value; else row.IsMONTO_PRORATEONull = true; } }
        public string NroComprobante { get { return GetStringHelper(row.NRO_COMPROBANTE); } set { row.NRO_COMPROBANTE = value; } }
        public string Observacion { get { return GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal? PorcentajeProrrateo { get { if (row.IsPORCENTAJE_PRORATEONull) return null; else return row.PORCENTAJE_PRORATEO; } set { if (value.HasValue) row.PORCENTAJE_PRORATEO = value.Value; else row.IsPORCENTAJE_PRORATEONull = true; } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } set { row.SUCURSAL_ID = value; } }
        public decimal? TextoPredefinidoId { get { if (row.IsTEXTO_PREDEFINIDO_IDNull) return null; else return row.TEXTO_PREDEFINIDO_ID; } set { if (value.HasValue) row.TEXTO_PREDEFINIDO_ID = value.Value; else row.IsTEXTO_PREDEFINIDO_IDNull = true; } }
        public decimal TipoProrrateo { get { return row.TIPO_PRORRATEO; } set { row.TIPO_PRORRATEO = value; } }
        public string NroDocumentoExterno { get { return GetStringHelper(row.NRO_DOCUMENTO_EXTERNO); } set { row.NRO_DOCUMENTO_EXTERNO = value; } }
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

        private CasosService _caso_fc_proveedor;
        public CasosService CasoFCProveedor
        {
            get
            {
                if (this._caso_fc_proveedor == null)
                {
                    if (this.sesion != null)
                        this._caso_fc_proveedor = new CasosService(this.CasoFCProveedorId.Value, this.sesion);
                    else
                        this._caso_fc_proveedor = new CasosService(this.CasoFCProveedorId.Value);
                }
                return this._caso_fc_proveedor;
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
                        this._deposito = new StockDepositosService(this.DepositoId, this.sesion);
                    else
                        this._deposito = new StockDepositosService(this.DepositoId);
                }
                return this._deposito;
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

        private TextosPredefinidosService _texto_predefinido;
        public TextosPredefinidosService TextoPredefinido
        {
            get
            {
                if (this._texto_predefinido == null)
                {
                    if (this.sesion != null)
                        this._texto_predefinido = new TextosPredefinidosService(this.TextoPredefinidoId.Value, this.sesion);
                    else
                        this._texto_predefinido = new TextosPredefinidosService(this.TextoPredefinidoId.Value);
                }
                return this._texto_predefinido;
            }
        }
        #endregion Propiedades Extendidas

        #region Propiedades OneToMany
        private IngresoStockDetalleService[] ingreso_stock_detalles;
        public IngresoStockDetalleService[] IngresStockDetalles
        {
            get
            {
                if (this.ingreso_stock_detalles == null)
                    this.ingreso_stock_detalles = IngresoStockDetalleService.GetPorCabecera(this.Id.Value);
                return this.ingreso_stock_detalles;
            }
        }
        #endregion Propiedades OneToMany

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.INGRESO_STOCKCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new INGRESO_STOCKRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(INGRESO_STOCKRow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public IngresoStockService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public IngresoStockService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public IngresoStockService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        private IngresoStockService(INGRESO_STOCKRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._caso = null;
            this._caso_fc_proveedor = null;
            this._deposito = null;
            this._sucursal = null;
            this._texto_predefinido = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region GetPorCaso
        public static IngresoStockService GetPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCaso(caso_id, sesion);
            }
        }

        public static IngresoStockService GetPorCaso(decimal caso_id, SessionService sesion)
        {
            var row = sesion.db.INGRESO_STOCKCollection.GetByCASO_ID(caso_id)[0];
            return new IngresoStockService(row);
        }
        #endregion GetPorCaso
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}