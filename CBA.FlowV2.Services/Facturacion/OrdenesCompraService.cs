#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class OrdenesCompraService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.ORDENES_COMPRA;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var drCabecera = (DataRow)caso_cabecera;
            var drDetalle = (DataRow)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, drCabecera[OrdenesCompraService.DepositoId_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, drDetalle[OrdenesCompraDetalleService.ArticuloId_NombreCol]);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, );
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
            mensaje = "";
            try
            {
                CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                ORDENES_COMPRARow ordenRow = sesion.Db.ORDENES_COMPRACollection.GetByCASO_ID(caso_id)[0];
                ORDENES_COMPRA_DETALLESRow[] detallesRows = sesion.Db.ORDENES_COMPRA_DETALLESCollection.GetByORDEN_COMPRA_ID(ordenRow.ID);

                //Borrador a Anulado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna
                    exito = true;
                    revisarRequisitos = true;
                }
                //Borrador a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Se genera la numeracion de la NP a partir de la autonumeracion que haya indicado el usuario, si el 
                    //caso no tenia previamente un numero asignado (i.e. realizo la transicion anteriormete). 

                    exito = true;
                    revisarRequisitos = true;
                    if (detallesRows.Length <= 0)
                    {
                        mensaje = "La orden de compra no tiene detalles.";
                        exito = false;
                    }

                    #region Se genera el numero de comprobante
                    if (exito && ordenRow.NRO_COMPROBANTE == null)
                    {
                        try
                        {
                            ordenRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(ordenRow.AUTONUMERACION_ID);

                            //Controlar que se logro asignar una numeracion
                            if (ordenRow.NRO_COMPROBANTE.Equals(""))
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
                    #endregion Se genera el numero de comprobante
                }
                //Pendiente a Borrador 
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //Ninguna
                    exito = true;
                }
                //Pendiente a Aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones
                    //Genera FC Proveedor con los detalles de la orden de compra
                    //Se genera las relaciones factura proveedor detalle con orden de compra detalle
                    exito = true;
                    revisarRequisitos = true;

                    decimal depositoId = Definiciones.Error.Valor.EnteroPositivo;
                    if (ordenRow.IsDEPOSITO_IDNull)
                    {
                        DataTable dtDepositos = StockDepositosService.GetStockDepositosDataTable(ordenRow.SUCURSAL_ID, false, true);
                        if (dtDepositos.Rows.Count == 0)
                        {
                            mensaje = "No existe ningún depósito creado para esta sucursal.";
                            exito = false;
                        }
                        depositoId = (decimal)dtDepositos.Rows[0][StockDepositosService.Id_NombreCol];
                    }
                    else
                    {
                        depositoId = ordenRow.DEPOSITO_ID;
                    }
                    
                    //desde aqui
                    string clausulas = FacturasProveedorService.CasoAsociadoId_NombreCol + " = " + ordenRow.CASO_ID;
                    DataTable fac = FacturasProveedorService.GetFacturaProveedorInfoCompleta(clausulas, FacturasProveedorService.CasoId_NombreCol);

                    if (fac.Rows.Count > 0)//verificamos si existe FC asociada al caso cambiar a mayor que 43361
                    {
                        string NumeroCasos = string.Empty;
                        for (int i = 0; i < fac.Rows.Count; i++)
                        {
                            var estado = CasosService.GetCasoPorId((decimal)fac.Rows[i][FacturasProveedorService.CasoId_NombreCol]);
                            NumeroCasos += fac.Rows[i][FacturasProveedorService.CasoId_NombreCol] + " - " + estado.ESTADO_ID.ToString() + ", ";
                        }

                        System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Ya existe una factura proveedor asociada con caso Nº: " + NumeroCasos + "\n ¿Desea crear una nueva factura y anular la enterior?", "Confirmacion", System.Windows.Forms.MessageBoxButtons.YesNo);
                        if (dialogResult == System.Windows.Forms.DialogResult.Yes) //factura asociada pere elige crear nueva
                        {// verificamos es estado para poder anular la factura
                            for (int i = 0; i < fac.Rows.Count; i++)
                            {
                                decimal facExitente = (decimal)fac.Rows[i][FacturasProveedorService.CasoId_NombreCol];
                                var estado = CasosService.GetCasoPorId(facExitente);  //verificamos estado de la factura 
                                if (estado.ESTADO_ID.ToString() != Definiciones.EstadosFlujos.Cerrado || estado.ESTADO_ID.ToString() != Definiciones.EstadosFlujos.Aprobado)//si la factura aun no fue aprobada
                                {
                                    //cambio de estado a anulado la fatura existente
                                    CasosService.ActualizarEstado(estado.ID, Definiciones.EstadosFlujos.Anulado, estado.ESTADO_ID.ToString(), sesion);

                                }
                                else
                                    throw new Exception("La factura " + facExitente.ToString() + " aprobada no se puede anular \n por que ya fue aprobada");//si la factura fue aprobada

                            }


                            //Generamos nueva factura
                            System.Collections.Hashtable campos = new System.Collections.Hashtable();
                            campos.Add(FacturasProveedorService.SucursalId_NombreCol, ordenRow.SUCURSAL_ID);
                            campos.Add(FacturasProveedorService.ProveedorId_NombreCol, ordenRow.PROVEEDOR_ID);
                            campos.Add(FacturasProveedorService.StockDepositoId_NombreCol, depositoId);
                            campos.Add(FacturasProveedorService.CtacteCondicionPagoId_NombreCol, Definiciones.CondicionPago.Contado);
                            campos.Add(FacturasProveedorService.Fecha_NombreCol, ordenRow.FECHA_PEDIDO);
                            campos.Add(FacturasProveedorService.FechaFactura_NombreCol, ordenRow.FECHA_PEDIDO);
                            campos.Add(FacturasProveedorService.FechaVencimientoTimbrado_NombreCol, ordenRow.FECHA_PEDIDO);
                            campos.Add(FacturasProveedorService.MonedaId_NombreCol, ordenRow.MONEDA_ID);
                            campos.Add(FacturasProveedorService.NroComprobante_NombreCol, "FP-" + ordenRow.NRO_COMPROBANTE);
                            campos.Add(FacturasProveedorService.NroTimbrado_NombreCol, "--");
                            campos.Add(FacturasProveedorService.Observacion_NombreCol, string.Empty);
                            campos.Add(FacturasProveedorService.TipoFacturaProveedorId_NombreCol, Definiciones.TipoFacturaProveedor.CompraArticulos);
                            campos.Add(FacturasProveedorService.PagarPorFondoFijo_NombreCol, Definiciones.SiNo.No);
                            campos.Add(FacturasProveedorService.PasibleRetencion_NombreCol, Definiciones.SiNo.No);
                            campos.Add(FacturasProveedorService.AfectaCtacteProveedor_NombreCol, Definiciones.SiNo.Si);
                            campos.Add(FacturasProveedorService.AfectaCtactePersona_NombreCol, Definiciones.SiNo.No);
                            campos.Add(FacturasProveedorService.AfectaCreditoFiscalEmpresa_NombreCol, Definiciones.SiNo.Si);
                            campos.Add(FacturasProveedorService.CasoAsociadoId_NombreCol, ordenRow.CASO_ID);
                            campos.Add(FacturasProveedorService.EsTicket_NombreCol, Definiciones.SiNo.No);
                            campos.Add(FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol, 0);
                            campos.Add(FacturasProveedorService.CentroCostoObligatorio_NombreCol, Definiciones.SiNo.No);

                            if (exito)
                            {
                                //Guardar los datos
                                decimal vCasoId = Definiciones.Error.Valor.EnteroPositivo;
                                string vCasoEstado = string.Empty;
                                decimal factProveedorId = FacturasProveedorService.Guardar(campos, true, ref vCasoId, ref vCasoEstado, sesion);

                                for (int i = 0; i < detallesRows.Length; i++)
                                {
                                    System.Collections.Hashtable camposDetalle = new System.Collections.Hashtable();
                                    camposDetalle.Add(FacturasProveedorDetalleService.ArticuloId_NombreCol, detallesRows[i].ARTICULO_ID);

                                    // para lote
                                    DataTable dt = ArticulosLotesService.GetArticulosLotes(detallesRows[i].ARTICULO_ID, ArticulosLotesService.Id_NombreCol);
                                    decimal lote_id = decimal.Parse(dt.Rows[0][ArticulosLotesService.Id_NombreCol].ToString());
                                    camposDetalle.Add(FacturasProveedorDetalleService.LoteId_NombreCol, lote_id);
                                    camposDetalle.Add(FacturasProveedorDetalleService.TipoDetalle_NombreCol, (decimal)Definiciones.TiposDetalleFacturaProveedor.Estandar);
                                    camposDetalle.Add(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol, factProveedorId);
                                    camposDetalle.Add(FacturasProveedorDetalleService.UnidadIdDestino_NombreCol, detallesRows[i].UNIDAD_MEDIDA_ID);
                                    camposDetalle.Add(FacturasProveedorDetalleService.PrecioBrutoUnitarioDestino_NombreCol, detallesRows[i].COSTO_UNITARIO);
                                    camposDetalle.Add(FacturasProveedorDetalleService.PorcentajeDescuento_NombreCol, 0m);
                                    camposDetalle.Add(FacturasProveedorDetalleService.ImpuestoId_NombreCol, ArticulosService.GetImpuestoId(detallesRows[i].ARTICULO_ID));
                                    camposDetalle.Add(FacturasProveedorDetalleService.CantidadEmbaladaDestino_NombreCol, 0m);
                                    camposDetalle.Add(FacturasProveedorDetalleService.CantidadUnidadDestino_NombreCol, detallesRows[i].CANTIDAD);
                                    decimal detalleFactProvId = FacturasProveedorDetalleService.Guardar(camposDetalle, true, sesion);

                                    System.Collections.Hashtable camposRelaciones = new System.Collections.Hashtable();
                                    camposRelaciones.Add(OrdenesCompraDetalleRelacionesService.OrdenCompraDetalleId_NombreCol, detallesRows[i].ID);
                                    camposRelaciones.Add(OrdenesCompraDetalleRelacionesService.FacturaProveedorDetalleId_NombreCol, detalleFactProvId);
                                    camposRelaciones.Add(OrdenesCompraDetalleRelacionesService.Cantidad_NombreCol, detallesRows[i].CANTIDAD);
                                    OrdenesCompraDetalleRelacionesService.Guardar(camposRelaciones, true, sesion);
                                }
                            }



                        }
                        else if (dialogResult == System.Windows.Forms.DialogResult.No)
                        {
                            //Si tine factura asociada permanece con esa factura
                        }
                    }
                    else
                    {
                        //Generamos nueva factura
                        System.Collections.Hashtable campos = new System.Collections.Hashtable();
                        campos.Add(FacturasProveedorService.SucursalId_NombreCol, ordenRow.SUCURSAL_ID);
                        campos.Add(FacturasProveedorService.ProveedorId_NombreCol, ordenRow.PROVEEDOR_ID);
                        campos.Add(FacturasProveedorService.StockDepositoId_NombreCol, depositoId);
                        campos.Add(FacturasProveedorService.CtacteCondicionPagoId_NombreCol, Definiciones.CondicionPago.Contado);
                        campos.Add(FacturasProveedorService.Fecha_NombreCol, ordenRow.FECHA_PEDIDO);
                        campos.Add(FacturasProveedorService.FechaFactura_NombreCol, ordenRow.FECHA_PEDIDO);
                        campos.Add(FacturasProveedorService.FechaVencimientoTimbrado_NombreCol, ordenRow.FECHA_PEDIDO);
                        campos.Add(FacturasProveedorService.MonedaId_NombreCol, ordenRow.MONEDA_ID);
                        campos.Add(FacturasProveedorService.NroComprobante_NombreCol, "FP-" + ordenRow.NRO_COMPROBANTE);
                        campos.Add(FacturasProveedorService.NroTimbrado_NombreCol, "--");
                        campos.Add(FacturasProveedorService.Observacion_NombreCol, string.Empty);
                        campos.Add(FacturasProveedorService.TipoFacturaProveedorId_NombreCol, Definiciones.TipoFacturaProveedor.CompraArticulos);
                        campos.Add(FacturasProveedorService.PagarPorFondoFijo_NombreCol, Definiciones.SiNo.No);
                        campos.Add(FacturasProveedorService.PasibleRetencion_NombreCol, Definiciones.SiNo.No);
                        campos.Add(FacturasProveedorService.AfectaCtacteProveedor_NombreCol, Definiciones.SiNo.Si);
                        campos.Add(FacturasProveedorService.AfectaCtactePersona_NombreCol, Definiciones.SiNo.No);
                        campos.Add(FacturasProveedorService.AfectaCreditoFiscalEmpresa_NombreCol, Definiciones.SiNo.Si);
                        campos.Add(FacturasProveedorService.CasoAsociadoId_NombreCol, ordenRow.CASO_ID);
                        campos.Add(FacturasProveedorService.EsTicket_NombreCol, Definiciones.SiNo.No);
                        campos.Add(FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol, 0);
                        campos.Add(FacturasProveedorService.CentroCostoObligatorio_NombreCol, Definiciones.SiNo.No);

                        if (exito)
                        {
                            //Guardar los datos
                            decimal vCasoId = Definiciones.Error.Valor.EnteroPositivo;
                            string vCasoEstado = string.Empty;
                            decimal factProveedorId = FacturasProveedorService.Guardar(campos, true, ref vCasoId, ref vCasoEstado, sesion);

                            for (int i = 0; i < detallesRows.Length; i++)
                            {
                                System.Collections.Hashtable camposDetalle = new System.Collections.Hashtable();
                                camposDetalle.Add(FacturasProveedorDetalleService.ArticuloId_NombreCol, detallesRows[i].ARTICULO_ID);

                                // para lote
                                DataTable dt = ArticulosLotesService.GetArticulosLotes(detallesRows[i].ARTICULO_ID, ArticulosLotesService.Id_NombreCol);
                                decimal lote_id = decimal.Parse(dt.Rows[0][ArticulosLotesService.Id_NombreCol].ToString());
                                camposDetalle.Add(FacturasProveedorDetalleService.LoteId_NombreCol, lote_id);
                                camposDetalle.Add(FacturasProveedorDetalleService.TipoDetalle_NombreCol, (decimal)Definiciones.TiposDetalleFacturaProveedor.Estandar);
                                camposDetalle.Add(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol, factProveedorId);
                                camposDetalle.Add(FacturasProveedorDetalleService.UnidadIdDestino_NombreCol, detallesRows[i].UNIDAD_MEDIDA_ID);
                                camposDetalle.Add(FacturasProveedorDetalleService.PrecioBrutoUnitarioDestino_NombreCol, detallesRows[i].COSTO_UNITARIO);
                                camposDetalle.Add(FacturasProveedorDetalleService.PorcentajeDescuento_NombreCol, 0m);
                                camposDetalle.Add(FacturasProveedorDetalleService.ImpuestoId_NombreCol, ArticulosService.GetImpuestoId(detallesRows[i].ARTICULO_ID));
                                camposDetalle.Add(FacturasProveedorDetalleService.CantidadEmbaladaDestino_NombreCol, 0m);
                                camposDetalle.Add(FacturasProveedorDetalleService.CantidadUnidadDestino_NombreCol, detallesRows[i].CANTIDAD);
                                decimal detalleFactProvId = FacturasProveedorDetalleService.Guardar(camposDetalle, true, sesion);

                                System.Collections.Hashtable camposRelaciones = new System.Collections.Hashtable();
                                camposRelaciones.Add(OrdenesCompraDetalleRelacionesService.OrdenCompraDetalleId_NombreCol, detallesRows[i].ID);
                                camposRelaciones.Add(OrdenesCompraDetalleRelacionesService.FacturaProveedorDetalleId_NombreCol, detalleFactProvId);
                                camposRelaciones.Add(OrdenesCompraDetalleRelacionesService.Cantidad_NombreCol, detallesRows[i].CANTIDAD);
                                OrdenesCompraDetalleRelacionesService.Guardar(camposRelaciones, true, sesion);
                            }
                        }
                    }
                }
                //Aprobado a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Se verifica si existe relaciones, si la FC Proveedor se encuentra en un estado avanzado, no avanza la orden de compra
                    exito = true;
                    revisarRequisitos = true;

                    StringBuilder query = new StringBuilder();
                    query.Append("select fp.id fact_prov_id, c.estado_id \n");
                    query.Append("  from ordenes_compra oc \n");
                    query.Append("  join ordenes_compra_detalles ocd on oc.id = ocd.orden_compra_id \n");
                    query.Append("  join ordenes_compra_det_relaciones ocdr on ocd.id = ocdr.orden_compra_det_id \n");
                    query.Append("  join facturas_proveedor_detalle fpd on ocdr.fc_proveedor_det_id = fpd.id \n");
                    query.Append("  join facturas_proveedor fp on fpd.facturas_proveedor_id = fp.id \n");
                    query.Append("  join casos c on c.id = fp.caso_id");
                    query.Append(" where fp.caso_asociado_id = " + ordenRow.CASO_ID);

                    DataTable fact_proveedores = sesion.db.EjecutarQuery(query.ToString());
                    bool fac_prov_avanzo = fact_proveedores.Select("estado_id in ('" + Definiciones.EstadosFlujos.Aprobado + "', '" + Definiciones.EstadosFlujos.Cerrado + "')").Length > 0;

                    if (!fac_prov_avanzo)
                    {
                        for (int i = 0; i < detallesRows.Length; i++)
                            OrdenesCompraDetalleRelacionesService.BorrarPorOrdenCompraDet(detallesRows[i].ID);

                        for (int i = 0; i < fact_proveedores.Rows.Count; i++)
                        {
                            var proveedor = new FacturasProveedorService((decimal)fact_proveedores.Rows[i]["fact_prov_id"]);
                            proveedor.CasoAsociadoId = null;
                            proveedor.Guardar();
                        }
                    }
                    else
                    {
                        mensaje = "Existen facturas asociadas en estado APROBADO o CERRADO";
                        exito = false;
                    }
                }
                //EnProceso a Cerrado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                {
                    exito = true;
                    revisarRequisitos = true;

                    if (cambio_pedido_por_usuario)
                    {
                        exito = false;
                        mensaje = "Solo el sistema puede utilizar la transición 'Cerrado' -> 'Aprobado'.";
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
                    sesion.Db.ORDENES_COMPRACollection.Update(ordenRow);
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

        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            throw new NotImplementedException();
        }
       
        #endregion Implementacion de metodos abstract

        #region GetOrdenesCompraDataTable
        public static DataTable GetOrdenesCompraDataTable(string where, string orderby)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ORDENES_COMPRACollection.GetAsDataTable(where, orderby);
            }
        }

        public static DataTable GetOrdenesCompraDataTable(string where, string orderby, SessionService sesion)
        {
            return sesion.Db.ORDENES_COMPRACollection.GetAsDataTable(where, orderby);
        }
        #endregion GetOrdenesCompraDataTable

        #region GetOrdenesCompraInfoCompleta
        public static DataTable GetOrdenesCompraInfoCompleta(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                if (orden.Equals(string.Empty))
                    orden = OrdenesCompraService.CasoId_NombreCol;

                return sesion.Db.ORDENES_COMPRA_INFO_COMPLETACollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetOrdenesCompraInfoCompleta

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref String estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    if (!campos.Contains(OrdenesCompraService.SucursalId_NombreCol))
                        throw new Exception("Debe indicar la sucursal.");

                    if (!campos.Contains(OrdenesCompraService.ProveedorId_NombreCol))
                        throw new Exception("Debe indicar el proveedor.");

                    if (!campos.Contains(OrdenesCompraService.MonedaId_NombreCol))
                        throw new Exception("Debe indicar la moneda.");

                    ORDENES_COMPRARow row = new ORDENES_COMPRARow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("ordenes_compra_sqc");
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[OrdenesCompraService.SucursalId_NombreCol].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.ORDENES_COMPRA.ToString()),
                                                             int.Parse(sesion.Usuario_Id.ToString()),
                                                             SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.ORDENES_COMPRACollection.GetRow(OrdenesCompraService.Id_NombreCol + " = " + campos[OrdenesCompraService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    if (!Interprete.EsNullODBNull(OrdenesCompraService.SucursalId_NombreCol))
                        row.SUCURSAL_ID = (decimal)campos[OrdenesCompraService.SucursalId_NombreCol];
                    else
                        throw new Exception("Valor no admitido en sucursal");

                    if (campos.Contains(OrdenesCompraService.DepositoId_NombreCol))
                    {
                        if (!Interprete.EsNullODBNull(OrdenesCompraService.DepositoId_NombreCol))
                            row.DEPOSITO_ID = (decimal)campos[OrdenesCompraService.DepositoId_NombreCol];
                        else
                            row.IsDEPOSITO_IDNull = true;
                    }

                    if (!Interprete.EsNullODBNull(OrdenesCompraService.ProveedorId_NombreCol))
                        row.PROVEEDOR_ID = (decimal)campos[OrdenesCompraService.ProveedorId_NombreCol];
                    else
                        throw new Exception("Valor no admitido en proveedor");

                    if (!Interprete.EsNullODBNull(OrdenesCompraService.MonedaId_NombreCol))
                        row.MONEDA_ID = (decimal)campos[OrdenesCompraService.MonedaId_NombreCol];
                    else
                        throw new Exception("Valor no admitido en moneda");

                    if (campos.Contains(OrdenesCompraService.FechaPedido_NombreCol))
                        row.FECHA_PEDIDO = (DateTime)campos[OrdenesCompraService.FechaPedido_NombreCol];

                    if (campos.Contains(OrdenesCompraService.AutonumeracionId_NombreCol))
                    {
                        if (!Interprete.EsNullODBNull(OrdenesCompraService.AutonumeracionId_NombreCol))
                        {
                            if (AutonumeracionesService.EstaActivo((decimal)campos[OrdenesCompraService.AutonumeracionId_NombreCol]))
                                row.AUTONUMERACION_ID = (decimal)campos[OrdenesCompraService.AutonumeracionId_NombreCol];
                            else
                                throw new Exception("El talonario deseado está inactivo.");
                        }
                        else
                        {
                            row.IsAUTONUMERACION_IDNull = true;
                        }
                    }
                    else
                    {
                        row.IsAUTONUMERACION_IDNull = true;
                    }

                    if (campos.Contains(OrdenesCompraService.NroComprobante_NombreCol))
                        row.NRO_COMPROBANTE = (string)campos[OrdenesCompraService.NroComprobante_NombreCol];

                    if (campos.Contains(OrdenesCompraService.Observacion_NombreCol))
                        row.OBSERVACION = (string)campos[OrdenesCompraService.Observacion_NombreCol];
                    
                    if (campos.Contains(OrdenesCompraService.FuncionarioId_NombreCol))
                        row.FUNCIONARIO_ID = (decimal)campos[OrdenesCompraService.FuncionarioId_NombreCol];
                    
                    if (insertarNuevo)
                        sesion.Db.ORDENES_COMPRACollection.Insert(row);
                    else
                        sesion.Db.ORDENES_COMPRACollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA_PEDIDO);
                    camposCaso.Add(CasosService.ProveedorId_NombreCol, row.PROVEEDOR_ID);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion guardar

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
                    String mensaje = "Error.";

                    //Se obtienen el caso y el pedido a ser borrados
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    ORDENES_COMPRARow compra = sesion.Db.ORDENES_COMPRACollection.GetByCASO_ID(caso_id)[0];

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Se obtienen los detalles del caso a ser borrados.
                    DataTable detalles = OrdenesCompraDetalleService.GetOrdenesCompraDetalleDataTable(OrdenesCompraDetalleService.OrdenCompraId_NombreCol + " = " + compra.ID, string.Empty);

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
                        sesion.Db.ORDENES_COMPRACollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, compra.ID, compra.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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
            get { return "ORDENES_COMPRA"; }
        }
        public static string Nombre_Vista
        {
            get { return "ordenes_compra_info_completa"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return ORDENES_COMPRACollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return ORDENES_COMPRACollection.CASO_IDColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return ORDENES_COMPRACollection.DEPOSITO_IDColumnName; }
        }
        public static string FechaPedido_NombreCol
        {
            get { return ORDENES_COMPRACollection.FECHA_PEDIDOColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return ORDENES_COMPRACollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ORDENES_COMPRACollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return ORDENES_COMPRACollection.MONEDA_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return ORDENES_COMPRACollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return ORDENES_COMPRACollection.OBSERVACIONColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return ORDENES_COMPRACollection.PROVEEDOR_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return ORDENES_COMPRACollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaTotalOrden_NombreCol
        {
            get { return ORDENES_COMPRA_INFO_COMPLETACollection.TOTAL_ORDEN_COMPRAColumnName; }
        }

        #endregion Accessors
    }
}
