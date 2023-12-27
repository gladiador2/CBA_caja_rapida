#region Using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.DetallesPersonalizados;
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class NotasDePedidosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.PEDIDO_DE_CLIENTE;
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
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, drCabecera[NotasDePedidosService.DEPOSITO_ID_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, drDetalle[NotasDePedidoDetalleService.ArticuloId_NombreCol]);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, );
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, drDetalle[NotasDePedidoDetalleService.ActivoId_NombreCol]);
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
                PEDIDOS_CLIENTERow pedidoRow = sesion.Db.PEDIDOS_CLIENTECollection.GetByCASO_ID(caso_id)[0];
                PEDIDOS_CLIENTE_DETALLERow[] pedidoDetRows = sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPEDIDOS_CLIENTE_ID(pedidoRow.ID);
                PERSONASRow personaRow = sesion.Db.PERSONASCollection.GetByPrimaryKey(pedidoRow.PERSONA_ID);
                PersonasBloqueosService personasBloqueos = new PersonasBloqueosService();
                string valorAnteriorPedido = pedidoRow.ToString();
                //Borrador a Anulado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
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
                    if (pedidoDetRows.Length <= 0)
                    {
                        mensaje = "La nota de pedido no tiene detalles.";
                        exito = false;
                    }

                    if (pedidoRow.TOTAL_MONTO_BRUTO_INICIAL <= 0)
                    {
                        mensaje = "La nota de pedido debe tener un monto mayor a cero.";
                        exito = false;
                    }                   

                    #region Verificar persona bloqueada
                    if (exito && personasBloqueos.PersonaBloqueada(personaRow.ID))
                    {
                        mensaje = "La persona se encuentra bloqueada";
                        exito = false;
                    }
                    #endregion Verificar persona bloqueada

                    #region Verificacion de Pagos
                    try
                    {
                        decimal totalPagos = pedidoRow.TOTAL_ENTREGA_INICIAL + CalendarioPagosNPClienteService.GetTotal(pedidoRow.ID, sesion);
                        if (Interprete.Redondear(totalPagos, 2) != Interprete.Redondear(pedidoRow.TOTAL_NETO, 2))
                        {
                            exito = false;
                            mensaje = "La suma de los Pagos no coinciden con el total del Pedido";
                        }
                    }
                    catch (Exception exp)
                    {
                        mensaje = exp.Message.ToString();
                        exito = false;
                    }
                    #endregion Verificacion de Pagos

                    #region Se genera el numero de comprobante
                    if (exito && pedidoRow.NRO_COMPROBANTE == null)
                    {
                        try
                        {
                            decimal funcionarioId = Definiciones.Error.Valor.EnteroPositivo;
                            if (!pedidoRow.IsVENDEDOR_IDNull)
                                funcionarioId = pedidoRow.VENDEDOR_ID;
                            else if (!sesion.Usuario.IsFUNCIONARIO_IDNull)
                                funcionarioId = sesion.Usuario.FUNCIONARIO_ID;
                            if (!AutonumeracionesService.FuncionarioPuedeUsar(pedidoRow.AUTONUMERACION_ID, funcionarioId, sesion))
                                throw new Exception("El talonario no puede ser utilizado por el funcionario seleccionado.");
                            
                            pedidoRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(pedidoRow.AUTONUMERACION_ID, sesion);

                            //Controlar que se logro asignar una numeracion
                            if (pedidoRow.NRO_COMPROBANTE.Equals(""))
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

                    #region Controlar linea de credito sin bloquear persona por linea temporal
                    if (exito && pedidoRow.AFECTA_LINEA_CREDITO == Definiciones.SiNo.Si)
                    {
                        decimal factor;
                        decimal cotizacionLineaCredito = CotizacionesService.GetCotizacionMonedaVenta(personaRow.MONEDA_LIMITE_CREDITO_ID);

                        if (personaRow.MONEDA_LIMITE_CREDITO_ID == pedidoRow.MONEDA_DESTINO_ID)
                        {
                            factor = 1;
                        }
                        else
                        {
                            // El factor es la division entre la cotizacion venta de la moneda en que se encuentra la
                            //linea de credito, y la cotizacion utilizada en la FC
                            factor = cotizacionLineaCredito / pedidoRow.COTIZACION_DESTINO;
                        }

                        //Se actualiza la cotizacino de la moneda de la linea de credito, en el detalle
                        foreach (PEDIDOS_CLIENTE_DETALLERow detalle in pedidoDetRows)
                        {
                            detalle.COTIZACION_MONEDA_LINEA_CRED = cotizacionLineaCredito;
                            sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.Update(detalle);
                        }

                        //Se actualiza el monto en el que afecta la FC a la linea de credito
                        pedidoRow.MONTO_AFECTA_LINEA_CREDITO = factor * pedidoRow.TOTAL_MONTO_BRUTO_FINAL;

                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.NotaPedidoControlLineaCredito).Equals(Definiciones.SiNo.Si))
                        {
                            if (exito && ControlLineaCredito(factor, personaRow.ID, cotizacionLineaCredito, pedidoRow.TOTAL_MONTO_BRUTO_FINAL, pedidoRow.COTIZACION_DESTINO))
                            {
                                mensaje = "La persona no cuenta con suficiente saldo en su línea de crédito.";
                                exito = false;
                            }
                        }                        
                    }
                    #endregion Controlar linea de credito sin bloquear persona por linea temporal

                    #region  Aprobacion de Precio
                    //se verifica los precios, si los mismos son mayores a iguales a la lista de precio, se aprueban directamente.
                    if (exito && VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.PedidoDeClienteVerificarAprobacionPrecioYCredito) == Definiciones.SiNo.Si)
                    {
                        bool aprobarPrecios = true;

                        if (pedidoRow.APROBACION_DPTO_PRECIOS.Equals(Definiciones.SiNo.Si))
                        {
                            foreach (PEDIDOS_CLIENTE_DETALLERow d in pedidoDetRows)
                            {
                                if (d.IsPRECIO_UNITARIO_APROBADONull)
                                {
                                    if (d.PRECIO_LISTA_DESTINO < d.PRECIO_LISTA_ORIGEN)
                                    {
                                        aprobarPrecios = false;
                                    }
                                }
                                else {
                                    if (d.PRECIO_LISTA_DESTINO < d.PRECIO_UNITARIO_APROBADO)
                                    {
                                        aprobarPrecios = false;
                                    }
                                }
                            }
                            if (!aprobarPrecios)
                            {
                                pedidoRow.APROBACION_DPTO_PRECIOS = Definiciones.SiNo.No;
                                //pedidoRow.IsUSUARIO_APROB_DPTO_PRECIOSNull = true;
                                //pedidoRow.IsTEXTO_OBS_DPTO_PRECIOS_IDNull = true;
                            }
                            else {
                                NotasDePedidoDetalleService.AprobacionPrecios(pedidoRow.ID, sesion, true);
                            }                                                   
                        }
                    }
                    #endregion  Aprobacion de Precio

                    #region Aprobacion de Credito
                    if (!pedidoRow.IsMONTO_CREDITO_APROBADONull)
                    {
                        if (pedidoRow.MONTO_CREDITO_APROBADO >= pedidoRow.TOTAL_NETO)
                        {
                            pedidoRow.APROBACION_DPTO_CREDITO = Definiciones.SiNo.Si;
                        }
                        else
                        {
                            pedidoRow.APROBACION_DPTO_CREDITO = Definiciones.SiNo.No;
                            //pedidoRow.IsUSUARIO_APROB_DPTO_CREDITONull = true;
                            //pedidoRow.IsFECHA_APROB_DPTO_CREDITONull = true;
                            //pedidoRow.IsTEXTO_OBS_DPTO_CREDITO_IDNull = true;
                        }
                    }
                    #endregion Aprobacion de Credito

                    #region Verificar Cantidad Minima y Porcentaje maximo de descuento por lista de precio
                    if (pedidoRow.CONTROLAR_CANT_MIN_DESC_MAX.Equals(Definiciones.SiNo.Si) && (VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.EstrategiaPrecio) == Definiciones.EstrategiaPrecio.FlujoModificacionListaPrecios))
                    {
                        for (int i = 0; i < pedidoDetRows.Length; i++)
                        {
                            if (!ListaDePrecio.ListasDePrecioService.CumpleConCantMinimaDescMaximo(pedidoRow.LISTA_PRECIO_ID, pedidoDetRows[i].ARTICULO_ID, pedidoDetRows[0].CANTIDAD_TOTAL_PEDIDA, pedidoDetRows[i].PORCENTAJE_DTO))
                            {
                                string codigoArticulo = ArticulosService.GetArticulos(ArticulosService.Id_NombreCol + " = " + pedidoDetRows[i].ARTICULO_ID, string.Empty, false, pedidoRow.SUCURSAL_ID).Rows[0][ArticulosService.CodigoEmpresa_NombreCol].ToString();

                                mensaje += " No se cumple con la cantidad mínima o descuento máximo establecidos en la lista de precios para el artículo " + codigoArticulo + "\n";
                                exito = false;
                            }
                        }
                    }
                    #endregion Verificar Cantidad Minima y Porcentaje maximo de descuento por lista de precio
                }
                //Pendiente a Borrador 
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //Se actualiza el monto en que afecta la NP a la linea de credito
                    //Se borran las aprobaciones de los Dptos Credito y Precios
                    exito = true;

                    pedidoRow.MONTO_AFECTA_LINEA_CREDITO = 0;

                    //Se borran las aprobaciones de los Dptos Credito y Precios

                    //pedidoRow.APROBACION_DPTO_PRECIOS = Definiciones.SiNo.No;
                    /*pedidoRow.IsUSUARIO_APROB_DPTO_PRECIOSNull = true;
                    pedidoRow.IsFECHA_APROB_DPTO_PRECIOSNull = true;
                    pedidoRow.IsTEXTO_OBS_DPTO_PRECIOS_IDNull = true;*/

                    pedidoRow.APROBACION_DPTO_CREDITO = Definiciones.SiNo.No;
                    if (pedidoRow.IsMONTO_CREDITO_APROBADONull)
                    {
                        pedidoRow.IsUSUARIO_APROB_DPTO_CREDITONull = true;
                        pedidoRow.IsFECHA_APROB_DPTO_CREDITONull = true;
                        pedidoRow.IsTEXTO_OBS_DPTO_CREDITO_IDNull = true;
                    }
                }
                //Pendiente a Pre-aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.PreAprobado))
                {
                    //Acciones
                    //Controla que la nota este aprobada por los Dptos Credito y Precios
                    exito = true;
                    if (pedidoRow.TOTAL_MONTO_BRUTO_INICIAL <= 0)
                    {
                        mensaje = "La nota de pedido debe tener un monto mayor a cero.";
                        exito = false;
                    }

                    if (!pedidoRow.IsMONTO_CREDITO_APROBADONull && pedidoRow.MONTO_CREDITO_APROBADO >= pedidoRow.TOTAL_MONTO_BRUTO_FINAL)
                        pedidoRow.APROBACION_DPTO_CREDITO = Definiciones.SiNo.Si;

                    if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.PedidoDeClienteVerificarAprobacionPrecioYCredito) == Definiciones.SiNo.Si)
                    {
                        if (pedidoRow.APROBACION_DPTO_CREDITO.Equals(Definiciones.SiNo.No))
                        {
                            mensaje = "El caso no puede pasar de estado porque no fue aprobado por los Departamento de Crédito.";
                            exito = false;
                        }
                        else if (pedidoRow.APROBACION_DPTO_PRECIOS.Equals(Definiciones.SiNo.No))
                        {
                            mensaje = "El caso no puede pasar de estado porque no fue aprobado por el departamento de Precios.";
                            exito = false;
                        }
                        else
                        {
                            if (pedidoRow.IsMONTO_CREDITO_APROBADONull)
                                pedidoRow.MONTO_CREDITO_APROBADO = pedidoRow.TOTAL_MONTO_BRUTO_FINAL;

                            exito = true;
                            revisarRequisitos = true;
                        }
                    }
                    else
                    {
                        pedidoRow.MONTO_CREDITO_APROBADO = pedidoRow.TOTAL_MONTO_BRUTO_FINAL;
                    }

                    #region Controlar linea de credito
                    if (exito && pedidoRow.AFECTA_LINEA_CREDITO == Definiciones.SiNo.Si)
                    {
                        decimal factor;
                        decimal cotizacionLineaCredito = CotizacionesService.GetCotizacionMonedaVenta(personaRow.MONEDA_LIMITE_CREDITO_ID);

                        if (personaRow.MONEDA_LIMITE_CREDITO_ID == pedidoRow.MONEDA_DESTINO_ID)
                        {
                            factor = 1;
                        }
                        else
                        {
                            // El factor es la division entre la cotizacion venta de la moneda en que se encuentra la
                            //linea de credito, y la cotizacion utilizada en la FC
                            factor = cotizacionLineaCredito / pedidoRow.COTIZACION_DESTINO;
                        }

                        //Se actualiza la cotizacino de la moneda de la linea de credito, en el detalle
                        foreach (PEDIDOS_CLIENTE_DETALLERow detalle in pedidoDetRows)
                        {
                            detalle.COTIZACION_MONEDA_LINEA_CRED = cotizacionLineaCredito;
                            sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.Update(detalle);
                        }

                        //Se actualiza el monto en el que afecta la FC a la linea de credito
                        pedidoRow.MONTO_AFECTA_LINEA_CREDITO = factor * pedidoRow.TOTAL_MONTO_BRUTO_FINAL;

                        //obtener la linea de credito
                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.NotaPedidoControlLineaCredito).Equals(Definiciones.SiNo.Si))
                        {
                            if (exito && ControlLineaCredito(factor, personaRow.ID, cotizacionLineaCredito, pedidoRow.TOTAL_MONTO_BRUTO_FINAL, pedidoRow.COTIZACION_DESTINO))
                            {
                                mensaje = "La persona no cuenta con suficiente saldo en su línea de crédito.";
                                exito = false;
                            }
                        }

                    }
                    #endregion Controlar linea de credito

                    if (exito)
                    {
                        DepositoPreparacionEstadoService depositoPreparacionEstado = new DepositoPreparacionEstadoService();
                        foreach (PEDIDOS_CLIENTE_DETALLERow d in pedidoDetRows)
                        {
                            Hashtable campos2 = new Hashtable();
                            campos2.Add(DepositoPreparacionEstadoService.DepositoEstado_NombreCol, Definiciones.EstadosDeposito.ParaPreparar);
                            campos2.Add(DepositoPreparacionEstadoService.Fecha_NombreCol, DateTime.Now);
                            campos2.Add(DepositoPreparacionEstadoService.PedidoClienteId_NombreCol, pedidoRow.ID);
                            campos2.Add(DepositoPreparacionEstadoService.ArticuloId_NombreCol, d.ARTICULO_ID);

                            depositoPreparacionEstado.Guardar(sesion, campos2, true);
                        }
                    }
                }
                //Pre-aprobado a Borrador
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.PreAprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //Se actualiza el credito de la persona para reflejar su linea de credito excluyendo la NP en cuestion.
                    //Se borran las aprobaciones de los Dptos Credito y Precios
                    exito = true;
                    pedidoRow.MONTO_AFECTA_LINEA_CREDITO = 0;

                    //Se borran las aprobaciones de los Dptos Credito y Precios
                    pedidoRow.APROBACION_DPTO_CREDITO = Definiciones.SiNo.No;
                    if (pedidoRow.IsMONTO_CREDITO_APROBADONull)
                    {
                        pedidoRow.IsUSUARIO_APROB_DPTO_CREDITONull = true;
                        pedidoRow.IsFECHA_APROB_DPTO_CREDITONull = true;
                        pedidoRow.IsTEXTO_OBS_DPTO_CREDITO_IDNull = true;
                    }

                    string clausulas;
                    DepositoPreparacionEstadoService depositoPreparacionEstado = new DepositoPreparacionEstadoService();
                    clausulas = DepositoPreparacionEstadoService.PedidoClienteId_NombreCol + " = " + pedidoRow.ID.ToString();
                    DataTable dt = depositoPreparacionEstado.GetDepositoPreparacionEstadoActual(clausulas);
                    
                    foreach (DataRow item in dt.Rows)//se inactivan los estados de preparacion existentes 
                    {
                        Hashtable campos = new Hashtable();
                        campos.Add(DepositoPreparacionEstadoService.Estado_NombreCol, Definiciones.Estado.Inactivo);
                        campos.Add(DepositoPreparacionEstadoService.Id_NombreCol, item[DepositoPreparacionEstadoService.Id_NombreCol].ToString());

                        depositoPreparacionEstado.Guardar(sesion, campos, false);
                    }                    
                    //pedidoRow.APROBACION_DPTO_PRECIOS = Definiciones.SiNo.No;
                    //pedidoRow.IsUSUARIO_APROB_DPTO_PRECIOSNull = true;
                    //pedidoRow.IsFECHA_APROB_DPTO_PRECIOSNull = true;
                    //pedidoRow.IsTEXTO_OBS_DPTO_PRECIOS_IDNull = true;
                }
                //Pre-aprobado a Preparado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.PreAprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Preparado))
                {
                    //Acciones
                    //Se genera la numeracion de la NP a partir de la autonumeracion que haya indicado el usuario. 
                    
                    exito = true;
                    revisarRequisitos = true;
                    string clausulas;

                    if (pedidoRow.TOTAL_MONTO_BRUTO_FINAL <= 0)
                    {
                        mensaje = "La nota de pedido debe tener un monto mayor a cero.";
                        exito = false;
                    }

                    #region Preparacion en Depositos
                    if (exito)
                    {
                        DepositoPreparacionEstadoService depositoPreparacionEstado = new DepositoPreparacionEstadoService();
                        clausulas = DepositoPreparacionEstadoService.PedidoClienteId_NombreCol + " = " + pedidoRow.ID.ToString();
                        DataTable dt = depositoPreparacionEstado.GetDepositoPreparacionEstadoActual(clausulas);

                        Boolean listo = true;

                        foreach (DataRow item in dt.Rows)
                        {
                            if (!item[DepositoPreparacionEstadoService.DepositoEstado_NombreCol].ToString().Equals(Definiciones.EstadosDeposito.Preparado))
                            {
                                listo = false;
                            }
                        }
                        if (!listo) //esto es en caso de que no todos los articulos se prepararon
                        {
                            //mensaje = "El caso no puede pasar de estado porque el pedido aun no se encuentra preparado";
                            //exito = false;
                            foreach (DataRow item in dt.Rows)//se inactivan los estados de preparacion existentes 
                            {
                                Hashtable campos = new Hashtable();
                                campos.Add(DepositoPreparacionEstadoService.Estado_NombreCol, Definiciones.Estado.Inactivo);
                                campos.Add(DepositoPreparacionEstadoService.Id_NombreCol, item[DepositoPreparacionEstadoService.Id_NombreCol].ToString());
                                
                                depositoPreparacionEstado.Guardar(sesion, campos, false);                                
                            }

                            foreach (PEDIDOS_CLIENTE_DETALLERow d in pedidoDetRows) //se preparan TODOS los articulos de la nota de pedido
                            {
                                Hashtable campos = new Hashtable();
                                campos.Add(DepositoPreparacionEstadoService.DepositoEstado_NombreCol, Definiciones.EstadosDeposito.Preparado);
                                campos.Add(DepositoPreparacionEstadoService.Fecha_NombreCol, DateTime.Now);
                                campos.Add(DepositoPreparacionEstadoService.PedidoClienteId_NombreCol, pedidoRow.ID);
                                campos.Add(DepositoPreparacionEstadoService.ArticuloId_NombreCol, d.ARTICULO_ID);
                                campos.Add(DepositoPreparacionEstadoService.Cantidad_NombreCol, d.CANTIDAD_TOTAL_PEDIDA);
                                campos.Add(DepositoPreparacionEstadoService.PuedeProcesar_NombreCol, Definiciones.SiNo.Si);                                

                                depositoPreparacionEstado.Guardar(sesion, campos, true);
                            }
                        }
                    }
                    #endregion Preparacion en Depositos
                }
                //De Preparado a Aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Preparado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {                       
                    string clausulas;
                    exito = true;
                    
                    #region Verificacion de Pagos
                    try
                    {
                        decimal totalPagos = pedidoRow.TOTAL_ENTREGA_INICIAL + CalendarioPagosNPClienteService.GetTotal(pedidoRow.ID, sesion);
                        if (Interprete.Redondear(totalPagos, 2) != Interprete.Redondear(pedidoRow.TOTAL_NETO, 2))
                        {
                            exito = false;
                            mensaje = "La suma de los Pagos no coinciden con el total del Pedido";
                        }
                    }
                    catch (Exception exp)
                    {
                        mensaje = exp.Message.ToString();
                        exito = false;
                    }
                    #endregion Verificacion de Pagos

                    //Acciones
                    //Se genera un nuevo caso de Factura a Cliente automáticamente si corresponde.
                    #region Crear Caso de Factura
                    if (pedidoRow.USAR_REMISIONES.Equals(Definiciones.SiNo.No))
                    {
                        decimal caso_factura_creada_id = 0, factura_creada_id;
                        DataTable dtFacturaCreada;
                        FacturasClienteService facturaCliente = new FacturasClienteService();
                        DataTable dtDetallesPersonalizados;
                        if (exito)
                        {
                            try
                            {
                                Hashtable campos = new Hashtable();
                                Hashtable camposDet = new Hashtable();
                                string estado_caso_factura = string.Empty;
                                bool puede_facturar = false;

                                //controlar si hay detalles para crear factura
                                foreach (PEDIDOS_CLIENTE_DETALLERow detalle in pedidoDetRows)
                                {
                                    string query = "select nvl(sum(pcfr." + NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol +
                                        "), 0) " + NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol +
                                        " from " + NotasDePedidoDetalleFacturaClienteRelacionesService.Nombre_Tabla + " pcfr where pcfr." +
                                        NotasDePedidoDetalleFacturaClienteRelacionesService.PedidoClienteDetalleId_NombreCol + " = " + detalle.ID;

                                    DataTable dt = new DataTable();
                                    dt = sesion.db.EjecutarQuery(query);

                                    if ((decimal)dt.Rows[0][NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol] == 0)
                                    {
                                        puede_facturar = true;
                                    }
                                    else
                                    {
                                        if (detalle.CANTIDAD_TOTAL_PEDIDA - (decimal)dt.Rows[0][NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol] > 0)
                                            puede_facturar = true;
                                    }
                                }

                                if (puede_facturar)
                                {
                                    // Se crea un hashtable con los campos de la fc, quitados del pedido asociado
                                    campos.Add(FacturasClienteService.SucursalId_NombreCol, pedidoRow.SUCURSAL_ID);
                                    campos.Add(FacturasClienteService.DepositoId_NombreCol, pedidoRow.DEPOSITO_ID);
                                    campos.Add(FacturasClienteService.Fecha_NombreCol, DateTime.Now);
                                    campos.Add(FacturasClienteService.FechaVencimiento_NombreCol, DateTime.Now);
                                    if (!pedidoRow.IsVENDEDOR_IDNull)
                                        campos.Add(FacturasClienteService.VendedorId_NombreCol, pedidoRow.VENDEDOR_ID);
                                    campos.Add(FacturasClienteService.PersonaId_NombreCol, pedidoRow.PERSONA_ID);
                                    campos.Add(FacturasClienteService.TipoFacturaId_NombreCol, pedidoRow.TIPO_FACTURA_ID);
                                    if (!pedidoRow.IsLISTA_PRECIO_IDNull)
                                        campos.Add(FacturasClienteService.ListaPrecioId_NombreCol, pedidoRow.LISTA_PRECIO_ID);
                                    if (!pedidoRow.IsPORCENTAJE_DESC_SOBRE_TOTALNull)
                                        campos.Add(FacturasClienteService.PorcentajeDescSobreTotal_NombreCol, pedidoRow.PORCENTAJE_DESC_SOBRE_TOTAL);
                                    campos.Add(FacturasClienteService.MonedaDestinoId_NombreCol, pedidoRow.MONEDA_DESTINO_ID);
                                    campos.Add(FacturasClienteService.CotizacionDestino_NombreCol, pedidoRow.COTIZACION_DESTINO);
                                    campos.Add(FacturasClienteService.TotalMontoImpuesto_NombreCol, pedidoRow.TOTAL_MONTO_IMPUESTO);
                                    campos.Add(FacturasClienteService.TotalMontoDto_NombreCol, pedidoRow.TOTAL_MONTO_DTO);
                                    campos.Add(FacturasClienteService.TotalMontoBruto_NombreCol, pedidoRow.TOTAL_MONTO_BRUTO_FINAL);
                                    campos.Add(FacturasClienteService.TotalNeto_NombreCol, pedidoRow.TOTAL_NETO);
                                    campos.Add(FacturasClienteService.TotalCostoBruto_NombreCol, pedidoRow.TOTAL_COSTO_BRUTO);
                                    campos.Add(FacturasClienteService.TotalCostoNeto_NombreCol, pedidoRow.TOTAL_COSTO_NETO);
                                    campos.Add(FacturasClienteService.TotalComisionVendedor_NombreCol, pedidoRow.TOTAL_COMISION_VENDEDOR);
                                    campos.Add(FacturasClienteService.TotalRecargoFinanciero_NombreCol, pedidoRow.TOTAL_RECARGO_FINANCIERO);
                                    campos.Add(FacturasClienteService.TotalEntregaInicial_NombreCol, pedidoRow.TOTAL_ENTREGA_INICIAL);
                                    if (!pedidoRow.IsUSUARIO_ID_AUTORIZA_DESCUENTONull)
                                        campos.Add(FacturasClienteService.UsuarioIdAutorizaDescuento_NombreCol, pedidoRow.USUARIO_ID_AUTORIZA_DESCUENTO);
                                    if (!pedidoRow.IsFECHA_AUTORIZACION_DESCUENTONull)
                                        campos.Add(FacturasClienteService.FechaAutorizacionDescuento_NombreCol, pedidoRow.FECHA_AUTORIZACION_DESCUENTO);
                                    if (!pedidoRow.IsDESCUENTO_MAX_AUTORIZADONull)
                                        campos.Add(FacturasClienteService.DescuentoMaxAutorizado_NombreCol, pedidoRow.DESCUENTO_MAX_AUTORIZADO);
                                    campos.Add(FacturasClienteService.AfectaLineaCredito_NombreCol, pedidoRow.AFECTA_LINEA_CREDITO);
                                    if (!pedidoRow.IsMONTO_AFECTA_LINEA_CREDITONull)
                                        campos.Add(FacturasClienteService.MontoAfectaLineaCredito_NombreCol, pedidoRow.MONTO_AFECTA_LINEA_CREDITO);
                                    campos.Add(FacturasClienteService.AfectaCtacte_NombreCol, Definiciones.SiNo.Si);
                                    campos.Add(FacturasClienteService.ComisionPorVenta_NombreCol, pedidoRow.COMISION_POR_VENTA);
                                    campos.Add(FacturasClienteService.Observacion_NombreCol, pedidoRow.OBSERVACION);
                                    campos.Add(FacturasClienteService.CondicionPagoId_NombreCol, pedidoRow.CONDICION_PAGO_ID);
                                    campos.Add(FacturasClienteService.CondicionDescripcion_NombreCol, CondicionesPagoService.GetNombre(pedidoRow.CONDICION_PAGO_ID));
                                    campos.Add(FacturasClienteService.AConsignacion_NombreCol, pedidoRow.A_CONSIGNACION);
                                    campos.Add(FacturasClienteService.Impreso_NombreCol, Definiciones.SiNo.No);
                                    campos.Add(FacturasClienteService.AfectaStock_NombreCol, Definiciones.SiNo.Si);
                                    campos.Add(FacturasClienteService.CasoOrigenId_NombreCol, caso_id);

                                    // Se crea la factura y se obtiene el nro de caso creado
                                    FacturasClienteService.Guardar(campos, true, ref caso_factura_creada_id, ref estado_caso_factura, sesion);

                                    // Se obtiene el id de la factura creada
                                    dtFacturaCreada = FacturasClienteService.GetFacturaClienteDataTable(FacturasClienteService.CasoId_NombreCol + " = " + caso_factura_creada_id, string.Empty, sesion);
                                    factura_creada_id = (decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol];

                                    DateTime det_fecha_primer_vencimiento, det_fecha_segundo_vencimiento;
                                    bool usar_fecha_primer_vencimiento, usar_fecha_segundo_vencimiento;

                                    // Se crean los detalles de la factura
                                    foreach (PEDIDOS_CLIENTE_DETALLERow detalle in pedidoDetRows)
                                    {
                                        string query = "select nvl(sum(pcfr." + NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol +
                                            "), 0) " + NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol +
                                            " from " + NotasDePedidoDetalleFacturaClienteRelacionesService.Nombre_Tabla + " pcfr where pcfr." +
                                            NotasDePedidoDetalleFacturaClienteRelacionesService.PedidoClienteDetalleId_NombreCol + " = " + detalle.ID;

                                        DataTable dt = new DataTable();
                                        dt = sesion.db.EjecutarQuery(query);

                                        if ((decimal)dt.Rows[0][NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol] == 0)
                                        {
                                            camposDet.Clear();
                                            camposDet.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, factura_creada_id);
                                            camposDet.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, detalle.ARTICULO_ID);
                                            camposDet.Add(FacturasClienteDetalleService.MonedaOrigenId_NombreCol, detalle.MONEDA_ORIGEN_ID);
                                            camposDet.Add(FacturasClienteDetalleService.CotizacionOrigen_NombreCol, detalle.COTIZACION_ORIGEN);
                                            if (!detalle.IsCOTIZACION_MONEDA_LINEA_CREDNull)
                                                camposDet.Add(FacturasClienteDetalleService.CotizacionMonedaLineaCred_NombreCol, detalle.COTIZACION_MONEDA_LINEA_CRED);
                                            camposDet.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, detalle.UNIDAD_DESTINO_ID);
                                            camposDet.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, detalle.CANTIDAD_CAJAS_ENTREGADA);
                                            camposDet.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, detalle.CANTIDAD_UNITARIA_ENTREGADA);
                                            camposDet.Add(FacturasClienteDetalleService.CantidadPorCajaDestino_NombreCol, detalle.CANTIDAD_POR_CAJA_DESTINO);
                                            camposDet.Add(FacturasClienteDetalleService.CantidadUnitariaTotalDest_NombreCol, detalle.CANTIDAD_TOTAL_ENTREGADA);
                                            camposDet.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, detalle.PRECIO_LISTA_DESTINO);
                                            camposDet.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, detalle.MONTO_DESCUENTO);
                                            camposDet.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, detalle.PORCENTAJE_DTO);
                                            camposDet.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, detalle.IMPUESTO_ID);
                                            camposDet.Add(FacturasClienteDetalleService.PorcentajeComisionVenta_NombreCol, detalle.PORCENTAJE_COMISION_VEN);
                                            camposDet.Add(FacturasClienteDetalleService.MontoComisionVenta_NombreCol, detalle.MONTO_COMISION_VEN);
                                            camposDet.Add(FacturasClienteDetalleService.TotalMontoImpuesto_NombreCol, detalle.TOTAL_MONTO_IMPUESTO);
                                            camposDet.Add(FacturasClienteDetalleService.TotalMontoDescuento_NombreCol, detalle.TOTAL_MONTO_DTO);
                                            camposDet.Add(FacturasClienteDetalleService.TotalMontoBruto_NombreCol, detalle.TOTAL_MONTO_BRUTO);
                                            camposDet.Add(FacturasClienteDetalleService.TotalNeto_NombreCol, detalle.TOTAL_NETO);
                                            camposDet.Add(FacturasClienteDetalleService.TotalRecargoFinanciero_NombreCol, detalle.TOTAL_RECARGO_FINANCIERO);
                                            camposDet.Add(FacturasClienteDetalleService.CantidadDevueltaNotaCredito_NombreCol, 0);
                                            camposDet.Add(FacturasClienteDetalleService.LoteId_NombreCol, detalle.LOTE_ID);
                                            camposDet.Add(FacturasClienteDetalleService.UnidadOrigenId_NombreCol, detalle.UNIDAD_ORIGEN_ID);
                                            camposDet.Add(FacturasClienteDetalleService.CantidadUnidadOrigen_NombreCol, detalle.CANTIDAD_UNIDAD_ORIGEN);
                                            camposDet.Add(FacturasClienteDetalleService.CantidadPorCajaOrigen_NombreCol, detalle.CANTIDAD_POR_CAJA_ORIGEN);
                                            camposDet.Add(FacturasClienteDetalleService.CantidadUnitariaTotalOrig_NombreCol, detalle.CANTIDAD_UNITARIA_TOTAL_ORIG);
                                            camposDet.Add(FacturasClienteDetalleService.PrecioListaOrigen_NombreCol, detalle.PRECIO_LISTA_ORIGEN);
                                            camposDet.Add(FacturasClienteDetalleService.FactorConversion_NombreCol, detalle.FACTOR_CONVERSION);
                                            if (!detalle.IsCOSTO_IDNull)
                                                camposDet.Add(FacturasClienteDetalleService.CostoId_NombreCol, detalle.COSTO_ID);
                                            camposDet.Add(FacturasClienteDetalleService.CostoMonto_NombreCol, detalle.COSTO_MONTO);
                                            camposDet.Add(FacturasClienteDetalleService.CostoMonedaId_NombreCol, detalle.COSTO_MONEDA_ID);
                                            camposDet.Add(FacturasClienteDetalleService.CostoMonedaCotizacion_NombreCol, detalle.COSTO_MONEDA_COTIZACION);
                                            camposDet.Add(FacturasClienteDetalleService.PorcentajeImpuesto_NombreCol, detalle.PORCENTAJE_IMPUESTO);
                                            camposDet.Add(FacturasClienteDetalleService.TotalNetoLuegoDeNC_NombreCol, detalle.TOTAL_NETO);
                                            camposDet.Add(FacturasClienteDetalleService.TotalNetoLuegoDeNCAux_NombreCol, Definiciones.Error.Valor.EnteroPositivo);
                                            camposDet.Add(FacturasClienteDetalleService.CantidadAnteriorAux_NombreCol, Definiciones.Error.Valor.EnteroPositivo);
                                            decimal facturaClienteId = FacturasClienteDetalleService.Guardar(factura_creada_id, camposDet, false, true, out det_fecha_primer_vencimiento, out usar_fecha_primer_vencimiento, out det_fecha_segundo_vencimiento, out usar_fecha_segundo_vencimiento, false, sesion);
                                            //se guarda en la tabla PedidosClienteFCRelacion
                                            System.Collections.Hashtable camposRelaciones = new System.Collections.Hashtable();
                                            camposRelaciones.Add(NotasDePedidoDetalleFacturaClienteRelacionesService.FacturaClienteDetalleId_NombreCol, facturaClienteId);
                                            camposRelaciones.Add(NotasDePedidoDetalleFacturaClienteRelacionesService.PedidoClienteDetalleId_NombreCol, detalle.ID);
                                            camposRelaciones.Add(NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol, detalle.CANTIDAD_UNITARIA_ENTREGADA);
                                            NotasDePedidoDetalleFacturaClienteRelacionesService.Guardar(camposRelaciones, true, sesion);  
                                        }
                                        else
                                        {
                                            if (detalle.CANTIDAD_TOTAL_PEDIDA - (decimal)dt.Rows[0][NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol] > 0)
                                            {
                                                camposDet.Clear();
                                                camposDet.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, factura_creada_id);
                                                camposDet.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, detalle.ARTICULO_ID);
                                                camposDet.Add(FacturasClienteDetalleService.MonedaOrigenId_NombreCol, detalle.MONEDA_ORIGEN_ID);
                                                camposDet.Add(FacturasClienteDetalleService.CotizacionOrigen_NombreCol, detalle.COTIZACION_ORIGEN);
                                                camposDet.Add(FacturasClienteDetalleService.CotizacionMonedaLineaCred_NombreCol, detalle.COTIZACION_MONEDA_LINEA_CRED);
                                                camposDet.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, detalle.UNIDAD_DESTINO_ID);
                                                camposDet.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, detalle.CANTIDAD_CAJAS_ENTREGADA);
                                                camposDet.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, detalle.CANTIDAD_UNITARIA_ENTREGADA - (decimal)dt.Rows[0][NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol]);
                                                camposDet.Add(FacturasClienteDetalleService.CantidadPorCajaDestino_NombreCol, detalle.CANTIDAD_POR_CAJA_DESTINO);
                                                camposDet.Add(FacturasClienteDetalleService.CantidadUnitariaTotalDest_NombreCol, detalle.CANTIDAD_TOTAL_ENTREGADA - (decimal)dt.Rows[0][NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol]);
                                                camposDet.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, detalle.PRECIO_LISTA_DESTINO);
                                                camposDet.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, detalle.MONTO_DESCUENTO);
                                                camposDet.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, detalle.PORCENTAJE_DTO);
                                                camposDet.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, detalle.IMPUESTO_ID);
                                                camposDet.Add(FacturasClienteDetalleService.PorcentajeComisionVenta_NombreCol, detalle.PORCENTAJE_COMISION_VEN);
                                                camposDet.Add(FacturasClienteDetalleService.MontoComisionVenta_NombreCol, detalle.MONTO_COMISION_VEN);
                                                camposDet.Add(FacturasClienteDetalleService.TotalMontoImpuesto_NombreCol, detalle.TOTAL_MONTO_IMPUESTO);
                                                camposDet.Add(FacturasClienteDetalleService.TotalMontoDescuento_NombreCol, detalle.TOTAL_MONTO_DTO);
                                                camposDet.Add(FacturasClienteDetalleService.TotalMontoBruto_NombreCol, detalle.TOTAL_MONTO_BRUTO);
                                                camposDet.Add(FacturasClienteDetalleService.TotalNeto_NombreCol, detalle.TOTAL_NETO);
                                                camposDet.Add(FacturasClienteDetalleService.TotalRecargoFinanciero_NombreCol, detalle.TOTAL_RECARGO_FINANCIERO);
                                                camposDet.Add(FacturasClienteDetalleService.CantidadDevueltaNotaCredito_NombreCol, 0);
                                                camposDet.Add(FacturasClienteDetalleService.LoteId_NombreCol, detalle.LOTE_ID);
                                                camposDet.Add(FacturasClienteDetalleService.UnidadOrigenId_NombreCol, detalle.UNIDAD_ORIGEN_ID);
                                                camposDet.Add(FacturasClienteDetalleService.CantidadUnidadOrigen_NombreCol, detalle.CANTIDAD_UNIDAD_ORIGEN);
                                                camposDet.Add(FacturasClienteDetalleService.CantidadPorCajaOrigen_NombreCol, detalle.CANTIDAD_POR_CAJA_ORIGEN);
                                                camposDet.Add(FacturasClienteDetalleService.CantidadUnitariaTotalOrig_NombreCol, detalle.CANTIDAD_UNITARIA_TOTAL_ORIG);
                                                camposDet.Add(FacturasClienteDetalleService.PrecioListaOrigen_NombreCol, detalle.PRECIO_LISTA_ORIGEN);
                                                camposDet.Add(FacturasClienteDetalleService.FactorConversion_NombreCol, detalle.FACTOR_CONVERSION);
                                                if (!detalle.IsCOSTO_IDNull)
                                                    camposDet.Add(FacturasClienteDetalleService.CostoId_NombreCol, detalle.COSTO_ID);
                                                camposDet.Add(FacturasClienteDetalleService.CostoMonto_NombreCol, detalle.COSTO_MONTO);
                                                camposDet.Add(FacturasClienteDetalleService.CostoMonedaId_NombreCol, detalle.COSTO_MONEDA_ID);
                                                camposDet.Add(FacturasClienteDetalleService.CostoMonedaCotizacion_NombreCol, detalle.COSTO_MONEDA_COTIZACION);
                                                camposDet.Add(FacturasClienteDetalleService.PorcentajeImpuesto_NombreCol, detalle.PORCENTAJE_IMPUESTO);
                                                camposDet.Add(FacturasClienteDetalleService.TotalNetoLuegoDeNC_NombreCol, detalle.TOTAL_NETO);
                                                camposDet.Add(FacturasClienteDetalleService.TotalNetoLuegoDeNCAux_NombreCol, Definiciones.Error.Valor.EnteroPositivo);
                                                camposDet.Add(FacturasClienteDetalleService.CantidadAnteriorAux_NombreCol, Definiciones.Error.Valor.EnteroPositivo);
                                                decimal facturaClienteId = FacturasClienteDetalleService.Guardar(factura_creada_id, camposDet, false, true, out det_fecha_primer_vencimiento, out usar_fecha_primer_vencimiento, out det_fecha_segundo_vencimiento, out usar_fecha_segundo_vencimiento, false, sesion);
                                                //se guarda en la tabla PedidosClienteFCRelacion                                                                  
                                                System.Collections.Hashtable camposRelaciones = new System.Collections.Hashtable();
                                                camposRelaciones.Add(NotasDePedidoDetalleFacturaClienteRelacionesService.FacturaClienteDetalleId_NombreCol, facturaClienteId);
                                                camposRelaciones.Add(NotasDePedidoDetalleFacturaClienteRelacionesService.PedidoClienteDetalleId_NombreCol, detalle.ID);
                                                camposRelaciones.Add(NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol, detalle.CANTIDAD_UNITARIA_ENTREGADA - (decimal)dt.Rows[0][NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol]);                                
                                                NotasDePedidoDetalleFacturaClienteRelacionesService.Guardar(camposRelaciones, true, sesion);                                                
                                            }
                                        }
                                    }
                                    
                                    // Se actualiza la fecha de vencimiento en la factura creada                            
                                    //DataTable dtCalendarioPagosNotaPedido = CalendarioPagosNPClienteService.GetCalendarioPagosDataTable(CalendarioPagosNPClienteService.NotaPedidoClienteId_NombreCol + " = " + pedidoRow.ID, CalendarioPagosNPClienteService.FechaVencimiento_NombreCol + " asc");
                                    //Hashtable camposCalendario = new Hashtable();
                                    //DateTime fecha_venc = new DateTime();
                                    //foreach (DataRow row in dtCalendarioPagosNotaPedido.Rows)
                                    //    fecha_venc = (DateTime)row[CalendarioPagosNPClienteService.FechaVencimiento_NombreCol];
                                    //FacturasClienteService.ActualizarFechaVencimiento(factura_creada_id, fecha_venc, true, false, sesion);

                                    // Se copian detalles personalizados.
                                    // Esto mismo se hacia en la db, pero mas abajo se hace algo que no estoy seguro sea lo mismo porque se filtra por tipo de detalle
                                    DataTable legajo = LegajoService.GetLegajoInfoCompleta(LegajoService.PersonaId_NombreCol + " = " + pedidoRow.PERSONA_ID + " and " + LegajoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'", string.Empty);
                                    decimal[] tipos_detalle_personalizado = new Decimal[1];

                                    foreach (DataRow fila in legajo.Rows)
                                    {
                                        DataTable detallesPersonalizados = new DataTable();
                                        tipos_detalle_personalizado[0] = (decimal)fila[LegajoService.VistaTipoDetallePersonalizadoId_NombreCol];
                                        detallesPersonalizados = DetallesPersonalizadosService.GetDetallesPersonalizadosDataTable(tipos_detalle_personalizado, LegajoService.Nombre_Tabla, LegajoService.Id_NombreCol, fila[LegajoService.Id_NombreCol].ToString(), false);

                                        foreach (DataRow detPers in detallesPersonalizados.Rows)
                                        {
                                            // Este metodo ya crea los detalles tambien
                                            DetallesPersonalizadosHistoricoService.Guardar((decimal)detPers[DetallesPersonalizadosService.TipoDetallePersonalizadoId_NombreCol],
                                                                                            LegajoService.Nombre_Tabla, LegajoService.Id_NombreCol,
                                                                                            detPers[DetallesPersonalizadosService.RegistroId_NombreCol].ToString(),
                                                                                            false,
                                                                                            pedidoRow.CASO_ID,
                                                                                            sesion);
                                        }
                                    }

                                    //Con el id de factura, cambiar el caso de FC al estado Pendiente
                                    facturaCliente.ProcesarCambioEstado(caso_factura_creada_id, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                                    if (exito)
                                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(caso_factura_creada_id, Definiciones.EstadosFlujos.Pendiente, "Transición automática por paso de la Nota de Pedido caso " + pedidoRow.CASO_ID + " al estado Aprobado.", sesion);
                                    if (exito)
                                        facturaCliente.EjecutarAccionesLuegoDeCambioEstado(caso_factura_creada_id, Definiciones.EstadosFlujos.Pendiente, sesion);                                    
                                }
                            }
                            catch (Exception exp)
                            {
                                mensaje = exp.Message.ToString();
                                exito = false;
                            }
                        }

                        #region afectar stock
                        if (exito)
                        {
                            foreach (PEDIDOS_CLIENTE_DETALLERow detalle in pedidoDetRows)
                            {
                                StockService.modificarStock(pedidoRow.DEPOSITO_ID,
                                                            detalle.ARTICULO_ID,
                                                            Interprete.Redondear(detalle.CANTIDAD_UNITARIA_TOTAL_ORIG, 2),
                                                            Definiciones.Stock.TipoMovimiento.Venta, caso_id, detalle.LOTE_ID, estado_destino,
                                                            sesion,
                                                            null,
                                                            detalle.IMPUESTO_ID,
                                                            detalle.ID);
                            }
                        }
                        #endregion afectar stock
                        
                        #region copiar detalles personalizados
                    //Copiar los detalles personalizados de referencias al historico para que no sean modificables
                    if (exito)
                    {
                        #region Detalles personalizados - Referencia creditos de terceros
                        clausulas = LegajoService.PersonaId_NombreCol + " = " + pedidoRow.PERSONA_ID + " and " +
                                    LegajoService.VistaTipoDetallePersonalizadoId_NombreCol + " = " + Definiciones.TiposDetallesPersonalizado.ReferenciasCreditoTerceros + " and " +
                                    LegajoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                        dtDetallesPersonalizados = LegajoService.GetLegajoInfoCompleta(clausulas, string.Empty);
                        if (dtDetallesPersonalizados.Rows.Count > 0)
                            DetallesPersonalizados.DetallesPersonalizadosHistoricoService.Guardar(Definiciones.TiposDetallesPersonalizado.ReferenciasCreditoTerceros, LegajoService.Nombre_Tabla, LegajoService.Id_NombreCol, dtDetallesPersonalizados.Rows[0][LegajoService.Id_NombreCol].ToString(), true, pedidoRow.CASO_ID, sesion);
                        #endregion Detalles personalizados - Referencia creditos de terceros

                        #region Detalles personalizados - Referencias personales
                        clausulas = LegajoService.PersonaId_NombreCol + " = " + pedidoRow.PERSONA_ID + " and " +
                                    LegajoService.VistaTipoDetallePersonalizadoId_NombreCol + " = " + Definiciones.TiposDetallesPersonalizado.ReferenciasPersonales + " and " +
                                    LegajoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                        dtDetallesPersonalizados = LegajoService.GetLegajoInfoCompleta(clausulas, string.Empty);
                        if (dtDetallesPersonalizados.Rows.Count > 0)
                            DetallesPersonalizados.DetallesPersonalizadosHistoricoService.Guardar(Definiciones.TiposDetallesPersonalizado.ReferenciasPersonales, LegajoService.Nombre_Tabla, LegajoService.Id_NombreCol, dtDetallesPersonalizados.Rows[0][LegajoService.Id_NombreCol].ToString(), true, pedidoRow.CASO_ID, sesion);
                        #endregion Detalles personalizados - Referencias personales

                        #region Detalles personalizados - Referencias Laborales
                        clausulas = LegajoService.PersonaId_NombreCol + " = " + pedidoRow.PERSONA_ID + " and " +
                                    LegajoService.VistaTipoDetallePersonalizadoId_NombreCol + " = " + Definiciones.TiposDetallesPersonalizado.ReferenciasLaborales + " and " +
                                    LegajoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                        dtDetallesPersonalizados = LegajoService.GetLegajoInfoCompleta(clausulas, string.Empty);
                        if (dtDetallesPersonalizados.Rows.Count > 0)
                            DetallesPersonalizados.DetallesPersonalizadosHistoricoService.Guardar(Definiciones.TiposDetallesPersonalizado.ReferenciasLaborales, LegajoService.Nombre_Tabla, LegajoService.Id_NombreCol, dtDetallesPersonalizados.Rows[0][LegajoService.Id_NombreCol].ToString(), true, pedidoRow.CASO_ID, sesion);
                        #endregion Detalles personalizados - Referencias Laborales
                    }
                    #endregion copiar detalles personalizados
                    }
                    #endregion Crear Caso de Factura
                    else
                    #region Crear Caso de Remision
                    {
                        decimal remision_creada_id;                        
                        RemisionesService remision = new RemisionesService();                                       
                        
                        if (exito)
                        {
                            try
                            {
                                Hashtable campos = new Hashtable();
                                Hashtable camposDet = new Hashtable();
                                string estado_caso_remision = string.Empty;
                                bool puede_remitir = false;

                                //controlar si hay detalles para crear remisión
                                foreach (PEDIDOS_CLIENTE_DETALLERow detalle in pedidoDetRows)
                                {
                                    string query = "select nvl(sum(rd." + RemisionesDetallesService.Modelo.CANTIDADColumnName +
                                        "), 0) " + RemisionesDetallesService.Modelo.CANTIDADColumnName +
                                        " from " + RemisionesService.Nombre_Tabla + " r, " + CasosService.Nombre_Tabla + " c, " + 
                                        RemisionesDetallesService.Nombre_Tabla + " rd where rd." +
                                        RemisionesDetallesService.Modelo.REMISION_IDColumnName + " = r." + RemisionesService.Modelo.IDColumnName + 
                                        " and r." + RemisionesService.Modelo.CASO_IDColumnName + " = c." + CasosService.Id_NombreCol + " and rd." +
                                        RemisionesDetallesService.Modelo.PEDIDO_CLIENTE_DETALLE_IDColumnName + " = " + detalle.ID + 
                                        " and c." + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "'";

                                    DataTable dt = new DataTable();
                                    dt = sesion.db.EjecutarQuery(query);

                                    if ((decimal)dt.Rows[0][RemisionesDetallesService.Modelo.CANTIDADColumnName] == 0)
                                    {
                                        puede_remitir = true;
                                    }
                                    else
                                    {
                                        if (detalle.CANTIDAD_TOTAL_PEDIDA - (decimal)dt.Rows[0][RemisionesDetallesService.Modelo.CANTIDADColumnName] > 0)
                                            puede_remitir = true;
                                    }
                                }

                                if (puede_remitir)
                                {
                                    remision.SucursalId = pedidoRow.SUCURSAL_ID;
                                    remision.DepositoId = pedidoRow.DEPOSITO_ID;
                                    remision.Fecha = DateTime.Now;
                                    remision.PersonaId = pedidoRow.PERSONA_ID;
                                    remision.AutonumeracionId = pedidoRow.AUTONUMERACION_ID;                                    
                                    remision_creada_id = remision.Guardar();

                                    // Se crean los detalles de la remisión                                   
                                    foreach (PEDIDOS_CLIENTE_DETALLERow detalle in pedidoDetRows)
                                    {
                                        string query = "select nvl(sum(rd." + RemisionesDetallesService.Modelo.CANTIDADColumnName +
                                            "), 0) " + RemisionesDetallesService.Modelo.CANTIDADColumnName + "\n" +
                                            " from " + RemisionesService.Nombre_Tabla + " r, " + CasosService.Nombre_Tabla + " c," + RemisionesDetallesService.Nombre_Tabla + " rd \n " +
                                            "where rd." + RemisionesDetallesService.Modelo.REMISION_IDColumnName + " = r." + RemisionesService.Modelo.IDColumnName + " and \n" +
                                            "r." + RemisionesService.Modelo.CASO_IDColumnName + " = c." + CasosService.Id_NombreCol + " and \n"+
                                            "rd." +RemisionesDetallesService.Modelo.PEDIDO_CLIENTE_DETALLE_IDColumnName + " = " + detalle.ID + " and \n " + 
                                            "c." + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "'";
                                        DataTable dt = new DataTable();
                                        dt = sesion.db.EjecutarQuery(query);
                                        RemisionesDetallesService remisionDetalle = new RemisionesDetallesService();       

                                        if ((decimal)dt.Rows[0][RemisionesDetallesService.Modelo.CANTIDADColumnName] == 0)
                                        {                                         
                                            remisionDetalle.RemisionId = remision_creada_id;
                                            remisionDetalle.UnidadMedidaId = detalle.UNIDAD_ORIGEN_ID;
                                            remisionDetalle.Cantidad = detalle.CANTIDAD_UNITARIA_ENTREGADA;
                                            remisionDetalle.ArticuloId = detalle.ARTICULO_ID;
                                            remisionDetalle.LoteId = detalle.LOTE_ID;
                                            remisionDetalle.CasoOrigenId = pedidoRow.CASO_ID;
                                            remisionDetalle.PedidoClienteDetalleId = detalle.ID;
                                            remisionDetalle.Guardar();
                                          
                                        }
                                        else
                                        {
                                            if (detalle.CANTIDAD_TOTAL_PEDIDA - (decimal)dt.Rows[0][RemisionesDetallesService.Modelo.CANTIDADColumnName] > 0)
                                            {
                                                remisionDetalle.RemisionId = remision_creada_id;
                                                remisionDetalle.UnidadMedidaId = detalle.UNIDAD_ORIGEN_ID;
                                                remisionDetalle.Cantidad = detalle.CANTIDAD_UNITARIA_ENTREGADA - (decimal)dt.Rows[0][RemisionesDetallesService.Modelo.CANTIDADColumnName];
                                                remisionDetalle.ArticuloId = detalle.ARTICULO_ID;
                                                remisionDetalle.LoteId = detalle.LOTE_ID;
                                                remisionDetalle.CasoOrigenId = pedidoRow.CASO_ID;
                                                remisionDetalle.PedidoClienteDetalleId = detalle.ID;                                                
                                                remisionDetalle.Guardar();
                                            }
                                        }
                                    }
                                }
                            }
                    #endregion Crear caso de remision
                            catch (Exception exp)
                            {
                                mensaje = exp.Message.ToString();
                                exito = false;
                            }
                        }
                    }
                }
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Preparado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.PreAprobado))
                {
                    exito = true;
                    revisarRequisitos = true;

                    try
                    {
                        string query;
                        DataTable dt = new DataTable();
                        if (pedidoRow.USAR_REMISIONES.Equals(CBA.FlowV2.Services.Base.Definiciones.SiNo.No))
                        {
                            query = "select fc." + FacturasClienteService.CasoId_NombreCol + ", fcdic." + FacturasClienteDetalleService.ArticuloDescripcion_NombreCol + ", fcdic." + FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol + "\n";
                            query += "from " + NotasDePedidoDetalleService.Nombre_Tabla + " pcd, " + NotasDePedidoDetalleFacturaClienteRelacionesService.Nombre_Tabla + " pcfr, " + FacturasClienteService.Nombre_Tabla + " fc, " + FacturasClienteDetalleService.Nombre_vista + " fcdic, " + CasosService.Nombre_Tabla + " c \n";
                            query += "where pcd." + NotasDePedidoDetalleService.Id_NombreCol + " = pcfr." + NotasDePedidoDetalleFacturaClienteRelacionesService.PedidoClienteDetalleId_NombreCol + " and " + "\n";
                            query += "pcfr." + NotasDePedidoDetalleFacturaClienteRelacionesService.FacturaClienteDetalleId_NombreCol + " = fcdic." + FacturasClienteDetalleService.Id_NombreCol + " and " + "\n";
                            query += "fcdic." + FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = fc." + FacturasClienteService.Id_NombreCol + " and " + "\n";
                            query += "fc." + FacturasClienteService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " and \n";
                            query += "c." + CasosService.EstadoId_NombreCol + " <> '" + CBA.FlowV2.Services.Base.Definiciones.EstadosFlujos.Anulado + "' and \n";
                            query += "pcd." + NotasDePedidoDetalleService.PedidosClienteId_NombreCol + " = " + pedidoRow.ID;

                            dt = sesion.db.EjecutarQuery(query);
                        }
                        else
                        {
                            query = "select r." + RemisionesService.Modelo.CASO_IDColumnName + ", pcdic." + NotasDePedidoDetalleService.VistaCodigoEmpresa_NombreCol + " || ' - ' || pcdic." + NotasDePedidoDetalleService.VistaArticulo_NombreCol + " " + NotasDePedidoDetalleService.VistaArticulo_NombreCol + ", rd." + RemisionesDetallesService.Modelo.CANTIDADColumnName + "\n";
                            query += "from " + NotasDePedidoDetalleService.Nombre_Vista + " pcdic, " + RemisionesService.Nombre_Tabla + " r, " + RemisionesDetallesService.Nombre_Tabla + " rd, " + CasosService.Nombre_Tabla + " c \n";
                            query += "where rd." + RemisionesDetallesService.Modelo.PEDIDO_CLIENTE_DETALLE_IDColumnName + " = pcdic." + NotasDePedidoDetalleService.Id_NombreCol + " and " + "\n";
                            query += "rd." + RemisionesDetallesService.Modelo.REMISION_IDColumnName + " = r." + RemisionesService.Modelo.IDColumnName + " and \n";
                            query += "r." + RemisionesService.Modelo.CASO_IDColumnName + " = c." + CasosService.Id_NombreCol + " and \n";
                            query += "c." + CasosService.EstadoId_NombreCol + " <> '" + CBA.FlowV2.Services.Base.Definiciones.EstadosFlujos.Anulado + "' and \n";
                            query += "rd." + RemisionesDetallesService.Modelo.ESTADOColumnName + " = '" + CBA.FlowV2.Services.Base.Definiciones.Estado.Activo + "' and \n";
                            query += "pcdic." + NotasDePedidoDetalleService.PedidosClienteId_NombreCol + " = " + pedidoRow.ID;


                            dt = sesion.db.EjecutarQuery(query);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            mensaje = "No se puede retroceder un pedido que tiene casos asociados.";
                            exito = false;
                        }
                    }
                    catch (Exception exp)
                    {
                        mensaje = exp.Message.ToString();
                        exito = false;
                    }
                }
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Anulado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    exito = true;
                    revisarRequisitos = true;
                }
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Preparado))
                {
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
                    sesion.db.CASOSCollection.Update(casoRow);
                    sesion.db.PEDIDOS_CLIENTECollection.Update(pedidoRow);                                  
                    LogCambiosService.LogDeRegistro(NotasDePedidosService.Nombre_Tabla, pedidoRow.ID, valorAnteriorPedido, pedidoRow.ToString(), sesion);
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                exito = false;

                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.STOCK_INCONSISTENCIA:
                        throw new System.ArgumentException("Inconsistencia de stock. Favor comuníquese con el soporte técnico.");
                    default: throw exp;
                }
            }
            catch (Exception exp)
            {
                exito = false;
                throw exp;
            }
            return exito;
        }

        /// <exito>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza acciones necesarias una vez que se efectuo el cambio de estado
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion)
        {

        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Obtener el numero de comprobante
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns>String con el numero de comprobante</returns>
        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            PEDIDOS_CLIENTERow row = sesion.Db.PEDIDOS_CLIENTECollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE;
        }

        #endregion Implementacion de metodos abstract

        #region ControlLineaCredito
        public bool ControlLineaCredito(decimal factor, decimal personaId, decimal cotizacionLineaCredito, decimal pedidoMonto, decimal pedidoCotizacion)
        {
            //obtener la linea de credito
            PersonasLineaCreditoService personasLineaCredito = new PersonasLineaCreditoService();
            DataRow lineaCredito = personasLineaCredito.GetPersonasLineaCredito(personaId);
            decimal lineaCreditoMonto = (decimal)lineaCredito[PersonasLineaCreditoService.MontoLineaCredito_NombreCol];

            DataTable dtPedidosPendientes = PersonasLineaCreditoService.GetPedidosPendientes(PersonasLineaCreditoService.VistaPedidosPersonaId_NombreCol + " = " + personaId);

            string clausulas = PersonasLineaCreditoService.VistaFacturasPersonaId_NombreCol + " = " + personaId + " or " +
                               "nvl(" + PersonasLineaCreditoService.VistaFacturasPersonaGarante1Id_NombreCol + ", -1) = " + personaId + " or " +
                               "nvl(" + PersonasLineaCreditoService.VistaFacturasPersonaGarante2Id_NombreCol + ", -1) = " + personaId + " or " +
                               "nvl(" + PersonasLineaCreditoService.VistaFacturasPersonaGarante3Id_NombreCol + ", -1) = " + personaId;
            DataTable dtFacturasPendientes = PersonasLineaCreditoService.GetFacturasPendientes(clausulas);

            decimal facturasEnDolares = 0;
            if (dtFacturasPendientes.Rows.Count > 0)
            {
                //todas las facturas convertidas a dolares
                foreach (DataRow columns in dtFacturasPendientes.Rows)
                {
                    facturasEnDolares += ((decimal)columns[PersonasLineaCreditoService.VistaFacturasPendientes_NombreCol] / (decimal)columns[PersonasLineaCreditoService.VistaFacturasCotizacion_NombreCol]);
                }
            }

            decimal pedidosEnDolares = 0;
            if (dtPedidosPendientes.Rows.Count > 0)
            {
                //todos los pedidos convertidos a dolares
                foreach (DataRow columns in dtPedidosPendientes.Rows)
                {
                    pedidosEnDolares += ((decimal)columns[PersonasLineaCreditoService.VistaPedidosPendientes_NombreCol] / (decimal)columns[PersonasLineaCreditoService.VistaPedidoCotizacion_NombreCol]);
                }
            }

            //pedido actual convertido a dolares
            decimal pedidoActualEnDolares = (pedidoMonto / pedidoCotizacion);
            //calculo del saldo comprometido, conversiones a la moneda de la linea de credito
            decimal pedidoActual = pedidoActualEnDolares * cotizacionLineaCredito;
            decimal saldoPersonaEnDolares = CuentaCorrientePersonasService.GetSaldoPersonaEnDolares(personaId);
            decimal saldoComprometido = (saldoPersonaEnDolares + facturasEnDolares + pedidosEnDolares - pedidoActualEnDolares) * cotizacionLineaCredito;

            return ((lineaCreditoMonto - saldoComprometido) < pedidoActual);
        }
        #endregion ControlLineaCredito

        #region ActualizarImpreso
        public static void ActualizarImpreso(decimal casoId)
        {
            using (SessionService sesion = new SessionService())
            {
                PEDIDOS_CLIENTERow row;
                try
                { 
                    sesion.Db.BeginTransaction();
                    row = sesion.Db.PEDIDOS_CLIENTECollection.GetRow(CASO_ID_NombreCol + " = " + casoId);
                    string valorAnteriorPedido = row.ToString();
                    
                    if (EsActualizable && row.IMPRESO == Definiciones.SiNo.No)
                        row.FECHA = DateTime.Today.Date;

                    row.IMPRESO = Definiciones.SiNo.Si;
                    
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnteriorPedido, row.ToString(), sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        public static bool EsActualizable
        {
            get
            {
                return VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.ReportesActualizarImpreso).Equals(Definiciones.SiNo.Si);
            }
        }
        /// <summary>
        /// Metodo auxiliar para saber si un caso ya fue impreso
        /// </summary>
        /// <param name="casoId">El Id del Caso.</param>
        /// <returns>True si fue impreso, False en caso contrario.</returns>
        public static bool FueImpreso(decimal casoId)
        {
            if (casoId == Definiciones.Error.Valor.EnteroPositivo) return false;
            using (SessionService sesion = new SessionService())
            {
                PEDIDOS_CLIENTERow row = sesion.Db.PEDIDOS_CLIENTECollection.GetRow(CASO_ID_NombreCol + " = " + casoId);
                return row.IMPRESO.Equals(Definiciones.SiNo.Si);
            }
        }
        #endregion ActualizarImpreso

        #region Getters

        #region GetNroCasoFacturaClienteGenerada

        public static decimal GetNroCasoFacturaClienteGenerada(decimal casoId)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNroCasoFacturaClienteGenerada(casoId, sesion); 
            }
        }

        public static decimal GetNroCasoFacturaClienteGenerada(decimal casoId, SessionService sesion)
        {
            string clausulas = FacturasClienteService.CasoOrigenId_NombreCol + " = " + casoId;
            DataTable dtFactura = FacturasClienteService.GetFacturaClienteDataTable(clausulas, FacturasClienteService.Id_NombreCol + " desc", sesion);

            if (dtFactura.Rows.Count != 0)
            {
                var estado = CasosService.GetEstadoCaso((decimal)dtFactura.Rows[0][FacturasClienteService.CasoId_NombreCol], sesion);
                              
                if (!estado.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    return (decimal)dtFactura.Rows[0][FacturasClienteService.CasoId_NombreCol];
                }               
            }
            return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion GetNroCasoFacturaClienteGenerada

        #region GetNroCasoRemisionGenerada

        public static decimal GetNroCasoRemisionGenerada(decimal casoId)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNroCasoRemisionGenerada(casoId, sesion);
            }
        }

        public static decimal GetNroCasoRemisionGenerada(decimal casoId, SessionService sesion)
        {
            string query = "select r." + RemisionesService.Modelo.CASO_IDColumnName +
                           " from " + RemisionesService.Nombre_Tabla + " r, " + RemisionesDetallesService.Nombre_Tabla + " rd " + 
                           "where rd." + RemisionesDetallesService.Modelo.REMISION_IDColumnName + " = r." + RemisionesService.Modelo.IDColumnName + 
                           " and rd." + RemisionesDetallesService.Modelo.CASO_ORIGEN_IDColumnName + " = " + casoId + " order by r." + RemisionesService.Modelo.IDColumnName + " desc" ;

            DataTable dtRemision = sesion.db.EjecutarQuery(query);

            if (dtRemision.Rows.Count != 0)
            {
                var estado = CasosService.GetEstadoCaso((decimal)dtRemision.Rows[0][RemisionesService.Modelo.CASO_IDColumnName], sesion);
                if (!estado.Equals(Definiciones.EstadosFlujos.Anulado))
                    return (decimal)dtRemision.Rows[0][RemisionesService.Modelo.CASO_IDColumnName];
            }
            return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion GetNroCasoRemisionGenerada

        #region GetPedidoDeCliente
        /// <summary>
        /// Gets the pedido de cliente.
        /// </summary>
        /// <param name="pedido_cliente_id">The pedido_cliente_id.</param>
        /// <returns></returns>
        public static PEDIDOS_CLIENTERow GetPedidoDeCliente2(decimal pedido_cliente_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPedidoDeCliente2(pedido_cliente_id, sesion);
            }
        }
        /// <summary>
        /// Gets the pedido de cliente2.
        /// </summary>
        /// <param name="pedido_cliente_id">The pedido_cliente_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static PEDIDOS_CLIENTERow GetPedidoDeCliente2(decimal pedido_cliente_id, SessionService sesion)
        {
            return sesion.Db.PEDIDOS_CLIENTECollection.GetByPrimaryKey(pedido_cliente_id);
        }

        #endregion getPedidoDeCliente

        #region GenerarAlarmasPorCambioDeStock
        /// <summary>
        /// Basado en las existencias del artículo insertado en stock
        /// y en la demanda de las preventas, genera alarmas 
        /// del sistema para preventas que incluyen a dicho artículo
        /// </summary>
        public static void GenerarAlarmasPorCambioDeStock(decimal articuloId)
        {
            //obtenemos detalle del artículo
            ARTICULOSRow articulo = ArticulosService.GetArticuloRowPorID(articuloId);

            //se obtienen todos los casos de preventa en estado borrador y pendiente que tienen el articulo agregadi en alguno de sus detalles
            string where = NotasDePedidoDetalleService.ArticuloId_NombreCol + " = " + articuloId.ToString();
            DataTable dtDetalles = NotasDePedidoDetalleService.GetPedidoDeClienteDetalleDataTable(where);
            List<decimal> pedidosId = new List<decimal>();
            foreach (DataRow dr in dtDetalles.Rows)
            {
                if (CasosService.GetEstadoCaso((decimal)dr[NotasDePedidoDetalleService.PedidosClienteId_NombreCol]).Equals(Definiciones.EstadosFlujos.Borrador) ||
                    CasosService.GetEstadoCaso((decimal)dr[NotasDePedidoDetalleService.PedidosClienteId_NombreCol]).Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    pedidosId.Add((decimal)dr[NotasDePedidoDetalleService.PedidosClienteId_NombreCol]);
                }
            }
            //creamos un DataTable con los pedidos de cliente obtenidos
            string clausulaPedidos = NotasDePedidosService.ID_NombreCol + CBAV2.CrearClausulaIn(pedidosId.Select(x => x.ToString()).ToArray(), false);
            clausulaPedidos += " and " + NotasDePedidosService.Preventa_NombreCol + " = '" + Definiciones.SiNo.Si + "'";
            if (pedidosId.Count > 0)
            {
                DataTable pedidos = NotasDePedidosService.GetPedidoDeClienteDataTable(clausulaPedidos, NotasDePedidosService.PreventaOrden_NombreCol);

                if (pedidos.Rows.Count > 0)
                {
                    //se genera el mensaje del sistema
                    string htmlMensaje = "<h2>Cambios en el stock estan relacionados a Casos de Preventa</h2>";
                    htmlMensaje += "El cambio realizado en stock del artículo \"" + articulo.DESCRIPCION_IMPRESION + "," + articulo.DESCRIPCION_INTERNA + "," + articulo.DESCRIPCION_PROVEEDOR
                        + "\" puede afectar los siguientes casos de Preventa:</br>";
                    htmlMensaje += "<ul>";
                    foreach (DataRow pedido in pedidos.Rows)
                    {
                        htmlMensaje += "<li>" + pedido[NotasDePedidosService.CASO_ID_NombreCol].ToString() + "</li>";
                    }
                    htmlMensaje += "</ul>";
                    //se envía el mensaje a todos los usuarios con el rol "recibir aviso stock preventa"
                    System.Collections.Hashtable campos = new System.Collections.Hashtable();
                    campos.Add(MensajesDeSistemaService.Estado_NombreCol, Definiciones.Estado.Activo);
                    campos.Add(MensajesDeSistemaService.FechaInicio_NombreCol, DateTime.Today);
                    campos.Add(MensajesDeSistemaService.Texto_NombreCol, htmlMensaje);
                    campos.Add(MensajesDeSistemaService.RolId_NombreCol, RolesService.GetRolPorDescripcion("alarmas destinatario stock preventas").ID);

                    MensajesDeSistemaService.Guardar(campos, true);
                }
            }
        }

        #endregion GenerarAlarmasPorCambioDeStock

        #region GetPedidoDeClienteDataTable
        /// <summary>
        /// Gets the pedido de cliente data table.
        /// </summary>
        /// <param name="pedidoId">The pedido id.</param>
        /// <returns></returns>
        public static DataTable GetPedidoDeClienteDataTable(decimal pedidoId)
        {
            string where = NotasDePedidosService.ID_NombreCol + "=" + pedidoId;
            return GetPedidoDeClienteDataTable(where, string.Empty);
        }

        #endregion GetPedidoDeClienteDataTable

        #region GetPedidoDeClienteDataTable
        /// <summary>
        /// Gets the pedido de cliente por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static DataTable GetPedidoDeClienteDataTable(string where, string orderby)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPedidoDeClienteDataTable(where, orderby, sesion);
            }
        }

        /// <summary>
        /// Gets the pedido de cliente data table.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="orderby">The orderby.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetPedidoDeClienteDataTable(string where, string orderby, SessionService sesion)
        {
            return sesion.Db.PEDIDOS_CLIENTE_INFO_COMPLCollection.GetAsDataTable(where, orderby);
        }
        #endregion GetPedidoDeClienteDataTable

        #region GetPedidoDeClientePorCaso
        /// <summary>
        /// Gets the pedido de cliente por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetPedidoDeClientePorCaso(Decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PEDIDOS_CLIENTE_INFO_COMPLCollection.GetAsDataTable(CASO_ID_NombreCol + " = " + caso_id, "");
            }
        }

        public static DataTable GetPedidoDeClienteInfoCompletaPorId(Decimal pedido_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PEDIDOS_CLIENTE_INFO_COMPLCollection.GetAsDataTable(ID_NombreCol + " = " + pedido_id, "");
            }
        }
        #endregion GetPedidoDeClientePorCaso

        #region GetMontoPedidosPorPersonasSinAprobar
        /// <summary>
        /// Solo la suma de los pedidos en pendiente, borrador y pre aprobado
        /// </summary> 
        /// <param name="persona">The persona.</param>
        /// <param name="?">The ?.</param>
        /// <returns></returns>
        public static decimal GetMontoPedidosPorPersonasSinAprobar(decimal persona_id, decimal moeda_id)
        {
            decimal total = 0;
            decimal monto = 0;
            decimal cotizacion = 0;
            using (SessionService sesion = new SessionService())
            {
                string clausualas = NotasDePedidosService.PERSONA_ID_NombreCol + "=" + persona_id + " and " +
                                   NotasDePedidosService.VistaEstadoId_NombreCol + " not in ('" + Definiciones.EstadosFlujos.Aprobado + "','" +
                                   Definiciones.EstadosFlujos.Anulado + "')";

                PEDIDOS_CLIENTE_INFO_COMPLRow[] rows = sesion.db.PEDIDOS_CLIENTE_INFO_COMPLCollection.GetAsArray(clausualas, string.Empty);
                for (int i = 0; i < rows.Length; i++)
                {
                    PEDIDOS_CLIENTE_INFO_COMPLRow row = rows[i];
                    monto = row.TOTAL_NETO;
                    cotizacion = row.COTIZACION_DESTINO;
                    total += monto / cotizacion;
                }
                cotizacion = CotizacionesService.GetCotizacionMonedaVenta(moeda_id);
                total = total / cotizacion;
            }
            return total;
        }
        #endregion GetMontoPedidosPorPersonasSinAprobar

        #region GetCasoIdPorId
        public static decimal GetCasoIdPorId(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    decimal notaDePedidoID = GetCasoIdPorId(id, sesion);
                    sesion.db.CommitTransaction();
                    return notaDePedidoID;
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        public static decimal GetCasoIdPorId(decimal id, SessionService sesion)
        {
            PEDIDOS_CLIENTERow row = sesion.Db.PEDIDOS_CLIENTECollection.GetByPrimaryKey(id);
            return row.CASO_ID;
        }
        #endregion GetCasoIdPorId

        #region GetCantidadFacturada
        public static decimal GetCantidadFacturada(decimal pedido_cliente_id)
        {
            DataTable dtCantidadFacturada = new DataTable();
            using (SessionService sesion = new SessionService())
            {
                string sql = "";
                sql += "select sum(pcfr." + NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol + ") " + NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol + " \n" +
                       "from " + NotasDePedidosService.Nombre_Tabla + " pc, " + "\n" +
                       NotasDePedidoDetalleService.Nombre_Tabla + " pcd, " + "\n" +
                       NotasDePedidoDetalleFacturaClienteRelacionesService.Nombre_Tabla + " pcfr " + "\n" +
                       "where pcd." + NotasDePedidoDetalleService.PedidosClienteId_NombreCol + " = pc." + NotasDePedidosService.ID_NombreCol + " and " + "\n" +
                       "pcfr." + NotasDePedidoDetalleFacturaClienteRelacionesService.PedidoClienteDetalleId_NombreCol + " = pcd." + NotasDePedidoDetalleService.Id_NombreCol + " and " + "\n" +
                       "pc." + NotasDePedidosService.UsarRemisiones_NombreCol + " = '" + Definiciones.SiNo.No + "' and pc." + NotasDePedidosService.ID_NombreCol + " = " + pedido_cliente_id;

                dtCantidadFacturada = sesion.db.EjecutarQuery(sql);

                var cantidadFacturada = (decimal)dtCantidadFacturada.Rows[0][NotasDePedidoDetalleFacturaClienteRelacionesService.Cantidad_NombreCol];
                return cantidadFacturada;
            }
        }
        #endregion GetCantidadFacturada

        #region GetCantidadPedida
        public static decimal GetCantidadPedida(decimal pedido_cliente_id)
        {
             DataTable dtCantidadPedida = new DataTable();
             using (SessionService sesion = new SessionService())
             {
                 string sql = "select sum(pcd." + NotasDePedidoDetalleService.CantidadUnitariaEntregada_NombreCol + ") cantidad " + "\n" +
                              "from " + NotasDePedidoDetalleService.Nombre_Tabla + " pcd, " + "\n" +
                              NotasDePedidosService.Nombre_Tabla + " pc " + "\n" +
                              "where pcd." + NotasDePedidoDetalleService.PedidosClienteId_NombreCol + " = pc." + NotasDePedidosService.ID_NombreCol + " and pc." + NotasDePedidosService.UsarRemisiones_NombreCol + " = '" + Definiciones.SiNo.No + "' " + "\n" +
                              "and pc." + NotasDePedidosService.ID_NombreCol + " = " + pedido_cliente_id;

                 dtCantidadPedida = sesion.db.EjecutarQuery(sql);

                 var cantidadPedida = (decimal)dtCantidadPedida.Rows[0]["cantidad"];
                 return cantidadPedida;
             }
        }
        #endregion GetCantidadPedida           

        #endregion Getters

        #region Obtener siguiente secuencia
        /// <summary>
        /// Obteners the siguiente secuencia.
        /// </summary>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public decimal ObtenerSiguienteSecuencia(SessionService sesion)
        {
            DataTable seq = new DataTable();
            seq = sesion.Db.EjecutarQuery("select pedidos_cliente_sqc.nextval from dual");
            return seq.Rows[0].Field<Decimal>(0);
        }
        #endregion obtener siguiente secuencia

        #region ObtenerSiguienteOrdenPreventa
        public decimal ObtenerSiguienteOrdenPreventa()
        {
            using (SessionService sesion = new SessionService())
            {
                string query = string.Format("select (nvl(max({0}),0)+1) orden from {1}", PreventaOrden_NombreCol, Nombre_Tabla);
                DataTable tabla = sesion.Db.EjecutarQuery(query);
                return decimal.Parse(tabla.Rows[0][0].ToString());
            }
        }
        #endregion ObtenerSiguienteOrdenPreventa

        #region AumentarOrdenPreventa
        public void AumentarOrdenPreventa(SessionService sesion, decimal orden)
        {
            string sql = string.Format("update {0} set {1}={1}+1 where {2}='{3}' and {1} >= {4}",
                Nombre_Tabla, PreventaOrden_NombreCol, Preventa_NombreCol, Definiciones.SiNo.Si, orden);
            sesion.Db.EjecutarQuery(sql);
        }
        #endregion AumentarOrdenPreventa

        #region DisminuirOrdenPreventa
        public void DisminuirOrdenPreventa(SessionService sesion, decimal orden)
        {
            string sql = string.Format("update {0} set {1}={1}-1 where {2}='{3}' and {1} > {4}",
                Nombre_Tabla, PreventaOrden_NombreCol, Preventa_NombreCol, Definiciones.SiNo.Si, orden);
            sesion.Db.EjecutarQuery(sql);
        }
        #endregion DisminuirOrdenPreventa

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        public bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref String estado_id,bool pasarDeEstado)
        {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                bool actualizarCuotas = false;
                PEDIDOS_CLIENTERow row = new PEDIDOS_CLIENTERow();

                try
                {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[SUCURSAL_ID_NombreCol].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.PEDIDO_DE_CLIENTE.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = ObtenerSiguienteSecuencia(sesion);
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                        row.IMPRESO = Definiciones.SiNo.No;
                        row.USAR_REMISIONES = Definiciones.SiNo.No;
                        row.TOTAL_COMISION_VENDEDOR = 0;
                        row.TOTAL_COSTO_BRUTO = 0;
                        row.TOTAL_COSTO_NETO = 0;
                        row.TOTAL_MONTO_BRUTO_FINAL = 0;
                        row.TOTAL_MONTO_DTO = 0;
                        row.TOTAL_MONTO_IMPUESTO = 0;
                        row.TOTAL_NETO = 0;                    }
                    else
                    {
                        row = sesion.Db.PEDIDOS_CLIENTECollection.GetRow(ID_NombreCol + " = " + decimal.Parse((string)campos[ID_NombreCol]));
                        valorAnterior = row.ToString();
                    }

                    //Panel Nota de Pedido

                    if (campos.Contains(UsarRemisiones_NombreCol))
                        row.USAR_REMISIONES = campos[UsarRemisiones_NombreCol].ToString();

                    if (campos.Contains(SUCURSAL_ID_NombreCol))
                    {
                        row.SUCURSAL_ID = decimal.Parse(campos[SUCURSAL_ID_NombreCol].ToString());
                        CasosService.ActualizarSucursal(row.CASO_ID, row.SUCURSAL_ID, sesion);
                    }
                    else 
                        row.IsSUCURSAL_IDNull = true;

                    if (campos.Contains(DEPOSITO_ID_NombreCol))
                    {
                        row.DEPOSITO_ID = decimal.Parse(campos[DEPOSITO_ID_NombreCol].ToString());
                        if (StockDepositosService.GetStockDeposito(row.DEPOSITO_ID).PARA_FACTURAR == Definiciones.SiNo.No)
                        {
                            throw new Exception("No se pude facturar del deposito seleccionado");
                        }
                    }
                    if (campos.Contains(FECHA_NombreCol)) row.FECHA = DateTime.Parse((string)campos[FECHA_NombreCol]);
                    else row.IsFECHANull = true;

                    if (campos.Contains(PERSONA_ID_NombreCol))
                    {
                        row.PERSONA_ID = decimal.Parse(campos[PERSONA_ID_NombreCol].ToString());
                        if (!PersonasService.EstaActivo(row.PERSONA_ID))
                            throw new Exception(Traducciones.La_persona_esta_inactiva);
                    }
                    else
                    {
                        row.IsPERSONA_IDNull = true;
                    }

                    if (campos.Contains(AUTONUMERACION_ID_NombreCol)) row.AUTONUMERACION_ID = decimal.Parse(campos[AUTONUMERACION_ID_NombreCol].ToString());
                    else row.IsAUTONUMERACION_IDNull = true;
                    row.NRO_COMPROBANTE = campos[NRO_COMPROBANTE_NombreCol].ToString();

                    if (row.TOTAL_ENTREGA_INICIAL != (decimal)campos[TOTAL_ENTREGA_INICIAL_NombreCol])
                    {
                        row.TOTAL_ENTREGA_INICIAL = (decimal)campos[TOTAL_ENTREGA_INICIAL_NombreCol];
                        actualizarCuotas = true;
                    }

                    if (campos.Contains(ControlarCantidadMinimaDescuentoMaximo_NombreCol)) 
                        row.CONTROLAR_CANT_MIN_DESC_MAX = campos[ControlarCantidadMinimaDescuentoMaximo_NombreCol].ToString();

                    if (campos.Contains(MONEDA_DESTINO_ID_NombreCol)) row.MONEDA_DESTINO_ID = decimal.Parse(campos[MONEDA_DESTINO_ID_NombreCol].ToString());
                    else row.IsMONEDA_DESTINO_IDNull = true;
                    
                    if (campos.Contains(COTIZACION_DESTINO_NombreCol)) row.COTIZACION_DESTINO = decimal.Parse(campos[COTIZACION_DESTINO_NombreCol].ToString());
                    else row.IsCOTIZACION_DESTINONull = true;
                    
                    if (campos.Contains(CONDICION_PAGO_ID_NombreCol))
                    {
                        //Si cambia el dato
                        if (row.IsCONDICION_PAGO_IDNull || row.CONDICION_PAGO_ID != decimal.Parse(campos[CONDICION_PAGO_ID_NombreCol].ToString()))
                        {
                            row.CONDICION_PAGO_ID = decimal.Parse(campos[CONDICION_PAGO_ID_NombreCol].ToString());

                            if (CondicionesPagoService.EsContado(row.CONDICION_PAGO_ID))
                                row.TIPO_FACTURA_ID = Definiciones.TipoFactura.Contado;
                            else
                                row.TIPO_FACTURA_ID = Definiciones.TipoFactura.Credito;

                            actualizarCuotas = true;
                        }
                    }
                    else
                    {
                        row.IsCONDICION_PAGO_IDNull = true;
                    }

                    //TODO: desarrolar la funcionalidad para
                    //que un usuario pueda autorizar mayor descuento
                    //row.DESCUENTO_MAX_AUTORIZADO;
                    //row.FECHA_AUTORIZACION_DESCUENTO;
                    //row.USUARIO_ID_AUTORIZA_DESCUENTO;

                    //Panel Vendedor
                    if(campos.Contains(NotasDePedidosService.VENDEDOR_ID_NombreCol))
                        row.VENDEDOR_ID = decimal.Parse(campos[VENDEDOR_ID_NombreCol].ToString());
                    else
                        row.IsVENDEDOR_IDNull = true;

                    row.LISTA_PRECIO_ID = decimal.Parse(campos[LISTA_PRECIO_ID_NombreCol].ToString());
                    row.COMISION_POR_VENTA = campos[COMISION_POR_VENTA_NombreCol].ToString();

                    if (!row.IsVENDEDOR_IDNull)
                    {
                        DataRow vendedor = FuncionariosService.GetFuncionario2(row.VENDEDOR_ID).Rows[0];
                        if (vendedor[FuncionariosService.SucursalId_NombreCol].Equals(DBNull.Value))
                            row.SUCURSAL_VENTA_ID = row.SUCURSAL_ID;
                        else
                            row.SUCURSAL_VENTA_ID = decimal.Parse(vendedor[FuncionariosService.SucursalId_NombreCol].ToString());
                    }
                    else
                    {
                        row.SUCURSAL_VENTA_ID = row.SUCURSAL_ID;
                    }

                    //Panel Linea de Credito
                    row.AFECTA_LINEA_CREDITO = campos[AFECTA_LINEA_CREDITO_NombreCol].ToString();

                    if (row.APROBACION_DPTO_CREDITO == null) row.APROBACION_DPTO_CREDITO = Definiciones.SiNo.No;
                    bool sobreescribirAprobacionCredito = row.IsMONTO_CREDITO_APROBADONull || row.MONTO_CREDITO_APROBADO < row.TOTAL_NETO;
                    if (sobreescribirAprobacionCredito &&
                        row.APROBACION_DPTO_CREDITO != campos[APROBACION_DPTO_CREDITO_NombreCol].ToString())
                    {
                        row.APROBACION_DPTO_CREDITO = campos[APROBACION_DPTO_CREDITO_NombreCol].ToString();
                        row.FECHA_APROB_DPTO_CREDITO = DateTime.Now;
                        row.USUARIO_APROB_DPTO_CREDITO = sesion.Usuario.ID;
                        row.MONTO_CREDITO_APROBADO = row.TOTAL_NETO;
                    }

                    if (campos.Contains(TEXTO_OBS_DPTO_CREDITO_ID_NombreCol))
                        row.TEXTO_OBS_DPTO_CREDITO_ID = decimal.Parse(campos[TEXTO_OBS_DPTO_CREDITO_ID_NombreCol].ToString());
                    else
                        row.IsTEXTO_OBS_DPTO_CREDITO_IDNull = true;

                    if (row.APROBACION_DPTO_PRECIOS == null) row.APROBACION_DPTO_PRECIOS = Definiciones.SiNo.No;
                    if (row.APROBACION_DPTO_PRECIOS != campos[APROBACION_DPTO_PRECIOS_NombreCol].ToString())
                    {
                        row.APROBACION_DPTO_PRECIOS = campos[APROBACION_DPTO_PRECIOS_NombreCol].ToString();
                        row.FECHA_APROB_DPTO_PRECIOS = DateTime.Now;
                        row.USUARIO_APROB_DPTO_PRECIOS = sesion.Usuario.ID;
                        NotasDePedidoDetalleService.AprobacionPrecios(row.ID, sesion, true);
                    }

                    if (campos.Contains(TEXTO_OBS_DPTO_PRECIOS_ID_NombreCol))
                        row.TEXTO_OBS_DPTO_PRECIOS_ID = decimal.Parse(campos[TEXTO_OBS_DPTO_PRECIOS_ID_NombreCol].ToString());
                    else
                        row.IsTEXTO_OBS_DPTO_PRECIOS_IDNull = true;

                    row.OBSERVACION = campos[OBSERVACION_NombreCol].ToString();
                    row.PORCENTAJE_DESC_SOBRE_TOTAL = (decimal)campos[PorcentajeDescSobreTotal_NombreCol];
                    row.A_CONSIGNACION = (string)campos[AConsignacion_NombreCol];
                    row.USAR_REMISIONES = (string)campos[UsarRemisiones_NombreCol];

                    if (insertarNuevo)
                    {
                        if ((bool)campos[Preventa_NombreCol])
                        {
                            row.PREVENTA = Definiciones.SiNo.Si;
                            decimal orden = (decimal)campos[PreventaOrden_NombreCol];
                            decimal siguienteOrden = ObtenerSiguienteOrdenPreventa();
                            if (orden >= siguienteOrden)
                            {
                                row.PREVENTA_ORDEN = siguienteOrden;
                            }
                            else
                            {
                                AumentarOrdenPreventa(sesion, orden);
                                row.PREVENTA_ORDEN = orden;
                            }
                            row.PREVENTA_FECHA_ENTREGA = (DateTime)campos[PreventaFechaEntrega_NombreCol];
                        }
                        else
                        {
                            row.PREVENTA = Definiciones.SiNo.No;
                        }
                    }
                    else
                    {
                        if ((bool)campos[Preventa_NombreCol])
                        {
                            decimal orden = (decimal)campos[PreventaOrden_NombreCol];
                            decimal siguienteOrden = ObtenerSiguienteOrdenPreventa();

                            //se pasa de no ser preventa a preventa
                            if (row.PREVENTA == Definiciones.SiNo.No)
                            {
                                if (orden >= siguienteOrden)
                                {
                                    row.PREVENTA_ORDEN = siguienteOrden;
                                }
                                else
                                {
                                    AumentarOrdenPreventa(sesion, orden);
                                    row.PREVENTA_ORDEN = orden;
                                }
                            }
                            else //era preventa y se mantiene siendo
                            {
                                siguienteOrden--;
                                //cambio de orden
                                if (row.PREVENTA_ORDEN != orden)
                                {
                                    DisminuirOrdenPreventa(sesion, row.PREVENTA_ORDEN);

                                    if (orden >= siguienteOrden)
                                    {
                                        row.PREVENTA_ORDEN = siguienteOrden;
                                    }
                                    else
                                    {
                                        AumentarOrdenPreventa(sesion, orden);
                                        row.PREVENTA_ORDEN = orden;
                                    }
                                }
                            }
                            row.PREVENTA = Definiciones.SiNo.Si;
                            row.PREVENTA_FECHA_ENTREGA = (DateTime)campos[PreventaFechaEntrega_NombreCol];
                        }
                        else
                        {
                            //era preventa y deja de ser
                            if (row.PREVENTA == Definiciones.SiNo.Si)
                            {
                                DisminuirOrdenPreventa(sesion, row.PREVENTA_ORDEN);
                                row.IsPREVENTA_ORDENNull = true;
                                row.IsPREVENTA_FECHA_ENTREGANull = true;
                            }
                            row.PREVENTA = Definiciones.SiNo.No;
                        }
                    }

                    if (insertarNuevo)
                    {
                        sesion.Db.PEDIDOS_CLIENTECollection.Insert(row);
                    }
                    else
                    {
                        sesion.db.PEDIDOS_CLIENTECollection.Update(row);
                    }
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    //Actualizar el calendario de pagos si la nota de pedido no es nueva
                    if (actualizarCuotas && !insertarNuevo)
                    {
                        decimal cantidadCuotas = CondicionesPagoService.GetCantidadPagos(row.CONDICION_PAGO_ID);
                        CalendarioPagosNPClienteService.CrearCuotas(row.ID, (row.TOTAL_NETO - row.TOTAL_ENTREGA_INICIAL ) / cantidadCuotas, row.FECHA, sesion);
                    }

                    if (CasosService.GetEstadoCaso(row.CASO_ID, sesion).Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        if (!row.IsMONTO_CREDITO_APROBADONull && row.MONTO_CREDITO_APROBADO >= row.TOTAL_MONTO_BRUTO_FINAL)
                            row.APROBACION_DPTO_CREDITO = Definiciones.SiNo.Si;
                    }

                    if (row.APROBACION_DPTO_CREDITO.Equals(Definiciones.SiNo.Si) && row.APROBACION_DPTO_PRECIOS.Equals(Definiciones.SiNo.Si))
                    {
                        if (pasarDeEstado)
                        {
                            CambiarAPreAprobado(row.CASO_ID, sesion);
                        }
                    }

                    RecalcularTotales(row.ID, sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                    if(!row.IsPERSONA_IDNull)
                        camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                    if(!row.IsVENDEDOR_IDNull)
                        camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.VENDEDOR_ID);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    exito = true;
                }
                catch (Exception)
                {
                    //Si el caso fue creado el mismo debe borrarse
                    // No entiendo lo que significa el comentario anterior
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
        #endregion guardar

        #region CambiarA
        /// <summary>
        /// Cambiars the A pre aprobado.
        /// </summary>
        /// <param name="idCaso">The id caso.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        private bool CambiarAPreAprobado(decimal idCaso, SessionService sesion)
        {
            try
            {
                string mensaje = string.Empty;
                bool exitoCasoAsociado = this.ProcesarCambioEstado(idCaso, Definiciones.EstadosFlujos.PreAprobado, false, out mensaje, sesion);
                if (exitoCasoAsociado)
                    exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(idCaso, Definiciones.EstadosFlujos.PreAprobado, "Cambio de estado por aprobaciones completas", sesion);
                if (exitoCasoAsociado)
                    this.EjecutarAccionesLuegoDeCambioEstado(idCaso, Definiciones.EstadosFlujos.PreAprobado, sesion);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CambiarAPreparado(decimal idCaso)
        {
            using (SessionService sesion = new SessionService())
            {
                return CambiarAPreparado(idCaso, sesion);
            }
        }
        public bool CambiarAPreparado(decimal idCaso, SessionService sesion)
        {
            try
            {
                string mensaje = string.Empty;
                bool exitoCasoAsociado = this.ProcesarCambioEstado(idCaso, Definiciones.EstadosFlujos.Preparado, false, out mensaje, sesion);
                if (exitoCasoAsociado)
                    exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(idCaso, Definiciones.EstadosFlujos.Preparado, "Cambio de Estado", sesion);
                if (exitoCasoAsociado)
                    this.EjecutarAccionesLuegoDeCambioEstado(idCaso, Definiciones.EstadosFlujos.Preparado, sesion);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CambiarABorrador(decimal idCaso)
        {
            using (SessionService sesion = new SessionService())
            {
                return CambiarABorrador(idCaso, sesion);
            }
        }
        public  bool CambiarABorrador(decimal idCaso, SessionService sesion)
        {
            try
            {
                string mensaje = string.Empty;
                bool exitoCasoAsociado = this.ProcesarCambioEstado(idCaso, Definiciones.EstadosFlujos.Borrador, false, out mensaje, sesion);
                if (exitoCasoAsociado)
                    exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(idCaso, Definiciones.EstadosFlujos.Borrador, "Cambio de Estado por Crédito Aprobado fue sobrepasado", sesion);
                if (exitoCasoAsociado)
                    this.EjecutarAccionesLuegoDeCambioEstado(idCaso, Definiciones.EstadosFlujos.Borrador, sesion);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CambiarAAprobado(decimal idCaso)
        {
            using (SessionService sesion = new SessionService())
            {
                return CambiarAAprobado(idCaso, sesion);
            }
        }
        public bool CambiarAAprobado(decimal idCaso, SessionService sesion)
        {
            try
            {
                string mensaje = string.Empty;
                bool exitoCasoAsociado = this.ProcesarCambioEstado(idCaso, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                if (exitoCasoAsociado)
                    exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(idCaso, Definiciones.EstadosFlujos.Aprobado, "Cambio de Estado", sesion);
                if (exitoCasoAsociado)
                    this.EjecutarAccionesLuegoDeCambioEstado(idCaso, Definiciones.EstadosFlujos.Aprobado, sesion);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion CambiarA

        #region SetCondicionPago
        public static void SetCondicionPago(decimal pedido_cliente_id, decimal condicion_pago_id, SessionService sesion)
        {
            PEDIDOS_CLIENTERow row = new PEDIDOS_CLIENTERow();

            try
            {
                row = sesion.Db.PEDIDOS_CLIENTECollection.GetRow(ID_NombreCol + " = " + pedido_cliente_id);
                string valorAnteriorPedido = row.ToString();
                row.CONDICION_PAGO_ID = condicion_pago_id;
                sesion.db.PEDIDOS_CLIENTECollection.Update(row);
                LogCambiosService.LogDeRegistro(NotasDePedidosService.Nombre_Tabla, row.ID, valorAnteriorPedido, row.ToString(), sesion);

                RecalcularTotales(pedido_cliente_id, sesion);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion SetCondicionPago

        #region Recalcular totales
        /// <summary>
        /// Recalcular totales en la cabecera. La transaccion no es abierta ni cerrada dentro del metodo
        /// </summary>
        /// <param name="pedido_cliente_id">The pedido_cliente_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void RecalcularTotales(decimal pedido_cliente_id, SessionService sesion)
        {
            try
            {
                PEDIDOS_CLIENTERow pedido = GetPedidoDeCliente2(pedido_cliente_id, sesion);
                PEDIDOS_CLIENTE_DETALLERow[] detalles= sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPEDIDOS_CLIENTE_ID(pedido_cliente_id);

                decimal totalNetoAnterior = pedido.TOTAL_NETO;

                DateTime fechaPrimerVencimiento = DateTime.Now;
                DateTime fechaSegundoVencimiento = DateTime.MinValue;
                bool usarFechaPrimerVencimiento = false;
                bool usarFechaSegundoVencimiento = false;

                #region Actualizar precios si estrategia es por WebService
                //Si la estrategia de precios es webservice deben actualizarse los totales por cada articulo
                if ((VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.EstrategiaPrecio) == Definiciones.EstrategiaPrecio.WebService))
                {
                    List<decimal> listArticulos = new List<decimal>();
                    List<decimal> listArticulosCantidades = new List<decimal>();
                    List<decimal> listArticulosDescuentoPorcentaje = new List<decimal>();
                    decimal[] articulosId, articulosCantidades, articulosDescuentoPorcentaje;
                    decimal[] articulosPrecios;
                    decimal monedaOrigen, cotizacionOrigen;

                    for (int i = 0; i < detalles.Length; i++)
                    {
                        if (ArticulosService.GetControlarPrecio(detalles[i].ARTICULO_ID))
                        {
                            listArticulos.Add(detalles[i].ARTICULO_ID);
                            listArticulosCantidades.Add(detalles[i].CANTIDAD_TOTAL_ENTREGADA);
                            listArticulosDescuentoPorcentaje.Add(detalles[i].PORCENTAJE_DTO);
                        }
                    }

                    articulosId = listArticulos.ToArray();
                    articulosCantidades = listArticulosCantidades.ToArray();
                    articulosDescuentoPorcentaje = listArticulosDescuentoPorcentaje.ToArray();

                    PreciosService.GetPrecioPorArticulo(pedido.PERSONA_ID, articulosId, articulosCantidades, pedido.MONEDA_DESTINO_ID, pedido.SUCURSAL_ID, pedido.CASO_ID, pedido.COTIZACION_DESTINO, pedido.LISTA_PRECIO_ID, pedido.CONDICION_PAGO_ID,
                                                        pedido.TOTAL_ENTREGA_INICIAL, pedido.FECHA, ref articulosDescuentoPorcentaje, out articulosPrecios, out monedaOrigen, out cotizacionOrigen,
                                                        out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, false, sesion);

                    for (int i = 0; i < detalles.Length; i++)
                    {
                        detalles[i].PRECIO_LISTA_ORIGEN = articulosPrecios[i];
                        detalles[i].PRECIO_LISTA_DESTINO = articulosPrecios[i];
                        detalles[i].TOTAL_MONTO_BRUTO = detalles[i].PRECIO_LISTA_DESTINO * detalles[i].CANTIDAD_TOTAL_ENTREGADA;
                        detalles[i].PORCENTAJE_DTO = articulosDescuentoPorcentaje[i];
                        detalles[i].MONTO_DESCUENTO = articulosPrecios[i] * articulosDescuentoPorcentaje[i] / 100;
                        detalles[i].TOTAL_MONTO_DTO = detalles[i].MONTO_DESCUENTO * detalles[i].CANTIDAD_TOTAL_ENTREGADA;

                        detalles[i].TOTAL_RECARGO_FINANCIERO = 0;
                        //Si la operacion no es contado
                        if (pedido.TIPO_FACTURA_ID == Definiciones.TipoFactura.Credito)
                        {
                            #region Calcular recargo financiero
                            //Si el articulo tiene recargo financiero guardar el monto
                            DataTable dtArticulos = ArticulosService.GetArticuloInfoCompletaPorID(detalles[i].ARTICULO_ID, pedido.SUCURSAL_ID, sesion);
                            if ((string)dtArticulos.Rows[0][ArticulosService.RecargoFinanciero_NombreCol] == Definiciones.SiNo.Si)
                            {
                                //Monto neto por recargo mensual por cantidad de pagos
                                // neto - neto / (1 + recargo * meses)
                                detalles[i].TOTAL_RECARGO_FINANCIERO = detalles[i].TOTAL_MONTO_BRUTO - detalles[i].TOTAL_MONTO_BRUTO /
                                                               (1 + VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClientePorcentajeRecargoFinanciero) / 100 * CondicionesPagoService.GetCantidadPagos(pedido.CONDICION_PAGO_ID));
                            }
                            #endregion Calcular recargo financiero
                        }

                        detalles[i].TOTAL_NETO = detalles[i].TOTAL_MONTO_BRUTO - detalles[i].TOTAL_MONTO_DTO - detalles[i].TOTAL_RECARGO_FINANCIERO;

                        if (detalles[i].PORCENTAJE_IMPUESTO == 0)
                            detalles[i].TOTAL_MONTO_IMPUESTO = 0;
                        else
                            detalles[i].TOTAL_MONTO_IMPUESTO = detalles[i].TOTAL_NETO / ((100 / detalles[i].PORCENTAJE_IMPUESTO) + 1);

                        detalles[i].MONTO_COMISION_VEN = (detalles[i].PORCENTAJE_COMISION_VEN * (detalles[i].TOTAL_NETO - detalles[i].TOTAL_MONTO_IMPUESTO)) / 100;

                        sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.Update(detalles[i]);
                    }
                }
                #endregion Actualizar precios si estrategia es por WebService

                pedido.TOTAL_RECARGO_FINANCIERO = 0;
                for (int i = 0; i < detalles.Length; i++)
                    pedido.TOTAL_RECARGO_FINANCIERO += detalles[i].TOTAL_RECARGO_FINANCIERO;
                
                NotasDePedidoDetalleService.ActualizarArticuloRecargoFinanciero(pedido.ID, pedido.CASO_ID, pedido.TOTAL_RECARGO_FINANCIERO, sesion);

                //Se recargan los detalles ya habiendo actualizado el articulo por recargo financiero
                detalles = sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPEDIDOS_CLIENTE_ID(pedido_cliente_id);
                string valorAnteriorPedido = pedido.ToString();
                pedido.TOTAL_MONTO_BRUTO_FINAL = 0;
                pedido.TOTAL_MONTO_DTO = 0;
                pedido.TOTAL_MONTO_IMPUESTO = 0;
                pedido.TOTAL_NETO = 0;
                pedido.TOTAL_FINAL_SUBITEMS = 0;
                pedido.TOTAL_RECARGO_FINANCIERO = 0;

                for (int i = 0; i < detalles.Length; i++)
                {
                    pedido.TOTAL_MONTO_BRUTO_FINAL += detalles[i].TOTAL_MONTO_BRUTO;
                    pedido.TOTAL_MONTO_DTO += detalles[i].TOTAL_MONTO_DTO;
                    pedido.TOTAL_MONTO_IMPUESTO += detalles[i].TOTAL_MONTO_IMPUESTO;
                    pedido.TOTAL_NETO += detalles[i].TOTAL_NETO;
                    pedido.TOTAL_FINAL_SUBITEMS += detalles[i].CANTIDAD_SUBITEMS_FINAL;
                    pedido.TOTAL_RECARGO_FINANCIERO += detalles[i].TOTAL_RECARGO_FINANCIERO;
                }

                decimal descuento = (pedido.TOTAL_NETO * pedido.PORCENTAJE_DESC_SOBRE_TOTAL) / 100;

                pedido.TOTAL_MONTO_DTO += descuento;
                pedido.TOTAL_NETO -= descuento;
                pedido.TOTAL_RECARGO_FINANCIERO *= (1 - pedido.PORCENTAJE_DESC_SOBRE_TOTAL / 100);

                string estadoCaso = CasosService.GetEstadoCaso(pedido.CASO_ID, sesion); 
                if (estadoCaso.Equals(Definiciones.EstadosFlujos.Borrador) || estadoCaso.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    pedido.TOTAL_MONTO_BRUTO_INICIAL = pedido.TOTAL_MONTO_BRUTO_FINAL;
                }
                else {
                    if (estadoCaso.Equals(Definiciones.EstadosFlujos.PreAprobado))
                    {
 
                    }
                }

                sesion.db.PEDIDOS_CLIENTECollection.Update(pedido);
                LogCambiosService.LogDeRegistro(NotasDePedidosService.Nombre_Tabla, pedido.ID, valorAnteriorPedido, pedido.ToString(), sesion);

                //Si cambia recalcular las cuotas
                if (totalNetoAnterior != pedido.TOTAL_NETO)
                {
                    if (pedido.TOTAL_NETO - pedido.TOTAL_ENTREGA_INICIAL <= 0)
                    {
                        CalendarioPagosNPClienteService.BorrarPorPedido(pedido.ID);
                    }
                    else
                    {
                        decimal cantidadCuotas = CondicionesPagoService.GetCantidadPagos(pedido.CONDICION_PAGO_ID);
                        CalendarioPagosNPClienteService.CrearCuotas(pedido.ID, (pedido.TOTAL_NETO - pedido.TOTAL_ENTREGA_INICIAL) / cantidadCuotas, pedido.FECHA, sesion);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion recalcular totales               

        #region EstaPrecioAprobado
        public static bool EstaPrecioAprobado(decimal detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return Definiciones.SiNo.Si.Equals(sesion.db.PEDIDOS_CLIENTECollection.GetByPrimaryKey(detalle_id).APROBACION_DPTO_PRECIOS);
            }
        }
        #endregion EstaPrecioAprobado

        #region EstaCreditoAprobado
        public static bool EstaCreditoAprobado(decimal detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return Definiciones.SiNo.Si.Equals(sesion.db.PEDIDOS_CLIENTECollection.GetByPrimaryKey(detalle_id).APROBACION_DPTO_CREDITO);
            }
        }
        #endregion EstaCreditoAprobado

        #region Borrar
        /// <summary>
        /// Borra de la base de datos el caso y la cabecera del flujo
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public bool Borrar(decimal caso_id)
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
                    PEDIDOS_CLIENTERow pedido = sesion.Db.PEDIDOS_CLIENTECollection.GetByCASO_ID(caso_id)[0];

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Se obtienen los detalles del caso a ser borrados.
                    DataTable detalles = (new NotasDePedidoDetalleService()).GetPedidoDeClienteDetalle(pedido.ID);

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
                        sesion.Db.PEDIDOS_CLIENTECollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, pedido.ID, pedido.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "PEDIDOS_CLIENTE"; }
        }
        public static string Nombre_Vista
        {
            get { return "PEDIDOS_CLIENTE_INFO_COMPL"; }
        }
        public static string ID_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.IDColumnName; }
        }
        public static string AFECTA_LINEA_CREDITO_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.AFECTA_LINEA_CREDITOColumnName; }
        }
        public static string APROBACION_DPTO_CREDITO_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.APROBACION_DPTO_CREDITOColumnName; }
        }
        public static string APROBACION_DPTO_PRECIOS_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.APROBACION_DPTO_PRECIOSColumnName; }
        }
        public static string AUTONUMERACION_ID_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CASO_ID_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.CASO_IDColumnName; }
        }
        public static string COMISION_POR_VENTA_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.COMISION_POR_VENTAColumnName; }
        }
        public static string CONDICION_PAGO_ID_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.CONDICION_PAGO_IDColumnName; }
        }
        public static string COTIZACION_DESTINO_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.COTIZACION_DESTINOColumnName; }
        }
        public static string DEPOSITO_ID_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.DEPOSITO_IDColumnName; }
        }
        public static string DESCUENTO_MAX_AUTORIZADO_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.DESCUENTO_MAX_AUTORIZADOColumnName; }
        }
        public static string FECHA_APROB_DPTO_CREDITO_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.FECHA_APROB_DPTO_CREDITOColumnName; }
        }
        public static string FECHA_APROB_DPTO_PRECIOS_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.FECHA_APROB_DPTO_PRECIOSColumnName; }
        }
        public static string FECHA_AUTORIZACION_DESCUENTO_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.FECHA_AUTORIZACION_DESCUENTOColumnName; }
        }
        public static string FECHA_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.FECHAColumnName; }
        }
        public static string Impreso_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.IMPRESOColumnName; }
        }
        public static string LISTA_PRECIO_ID_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.LISTA_PRECIO_IDColumnName; }
        }
        public static string MONEDA_DESTINO_ID_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.MONEDA_DESTINO_IDColumnName; }
        }
        public static string MONTO_AFECTA_LINEA_CREDITO_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.MONTO_AFECTA_LINEA_CREDITOColumnName; }
        }
        public static string MontoCreditoAprobado_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.MONTO_CREDITO_APROBADOColumnName; }
        }
        public static string NRO_COMPROBANTE_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.NRO_COMPROBANTEColumnName; }
        }
        public static string TEXTO_OBS_DPTO_CREDITO_ID_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.TEXTO_OBS_DPTO_CREDITO_IDColumnName; }
        }
        public static string TEXTO_OBS_DPTO_PRECIOS_ID_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.TEXTO_OBS_DPTO_PRECIOS_IDColumnName; }
        }
        public static string OBSERVACION_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.OBSERVACIONColumnName; }
        }
        public static string PERSONA_ID_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.PERSONA_IDColumnName; }
        }
        public static string SUCURSAL_ID_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.SUCURSAL_IDColumnName; }
        }
        public static string SUCURSAL_VENTA_ID_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.SUCURSAL_VENTA_IDColumnName; }
        }
        public static string TIPO_FACTURA_ID_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.TIPO_FACTURA_IDColumnName; }
        }
        public static string TOTAL_COMISION_VENDEDOR_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.TOTAL_COMISION_VENDEDORColumnName; }
        }
        public static string TOTAL_ENTREGA_INICIAL_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.TOTAL_ENTREGA_INICIALColumnName; }
        }
        public static string TOTAL_COSTO_BRUTO_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.TOTAL_COSTO_BRUTOColumnName; }
        }
        public static string TOTAL_COSTO_NETO_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.TOTAL_COSTO_NETOColumnName; }
        }
        public static string TOTAL_MONTO_BRUTO_FINALNombreCol
        {
            get { return PEDIDOS_CLIENTECollection.TOTAL_MONTO_BRUTO_FINALColumnName; }
        }
        public static string TOTAL_MONTO_BRUTO_INICIALNombreCol
        {
            get { return PEDIDOS_CLIENTECollection.TOTAL_MONTO_BRUTO_INICIALColumnName; }
        }
        public static string TOTAL_MONTO_DTO_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.TOTAL_MONTO_DTOColumnName; }
        }
        public static string TOTAL_MONTO_IMPUESTO_DTO_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.TOTAL_MONTO_IMPUESTOColumnName; }
        }
        public static string TOTAL_NETO_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.TOTAL_NETOColumnName; }
        }
        public static string TOTAL_FINAL_SUBITEMS_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.TOTAL_FINAL_SUBITEMSColumnName; }
        }
        public static string TotalRecargoFinanciero_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.TOTAL_RECARGO_FINANCIEROColumnName; }
        }
        public static string UsarRemisiones_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.USAR_REMISIONESColumnName; }
        }
        public static string USUARIO_APROB_DPTO_CREDITO_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.USUARIO_APROB_DPTO_CREDITOColumnName; }
        }
        public static string USUARIO_APROB_DPTO_PRECIOS_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.USUARIO_APROB_DPTO_PRECIOSColumnName; }
        }
        public static string USUARIO_ID_AUTORIZA_DESCUENTO_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.USUARIO_ID_AUTORIZA_DESCUENTOColumnName; }
        }
        public static string VENDEDOR_ID_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.VENDEDOR_IDColumnName; }
        }
        public static string PorcentajeDescSobreTotal_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.PORCENTAJE_DESC_SOBRE_TOTALColumnName; }
        }
        public static string Preventa_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.PREVENTAColumnName; }
        }
        public static string PreventaOrden_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.PREVENTA_ORDENColumnName; }
        }
        public static string PreventaFechaEntrega_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.PREVENTA_FECHA_ENTREGAColumnName; }
        }
        public static string AConsignacion_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.A_CONSIGNACIONColumnName; }
        }

        public static string ControlarCantidadMinimaDescuentoMaximo_NombreCol
        {
            get { return PEDIDOS_CLIENTECollection.CONTROLAR_CANT_MIN_DESC_MAXColumnName; }
        }

        #endregion Tabla

        #region Vista        
        public static string VistaEstadoId_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.SUCURSALColumnName; }
        }
        public static string VistaDepositoNombre_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.DEPOSITOColumnName; }
        }
        public static string VistaVendedorNombre_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.VENDEDORColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.PERSONAColumnName; }
        }
        public static string VistaPersonaRuc_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.RUCColumnName; }
        }
        public static string VistaDireccion_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.DIRECCIONColumnName; }
        }
        public static string VistaAutonumeracionTimbrado_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.AUTONUMERACION_TIMBRADOColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.MONEDA_DESTINOColumnName; }
        }        
        public static string VistaEntidadIdasoFacturaClienteNombre_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.ENTIDAD_IDColumnName; }
        }
        public static string VistaCondicionPagoNombre_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.CONDICION_PAGO_NOMBREColumnName; }
        }
        public static string VistaSucursalVenta_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.SUCURSAL_VENTAColumnName; }
        }
        public static string VistaTextoObsDptoCredito_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.TEXTO_OBS_DPTO_CREDITOColumnName; }
        }
        public static string VistaCasoId_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.CASO_IDColumnName; }
        }
        public static string VistaNroComprobante_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaFecha_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.FECHAColumnName; }
        }
        public static string VistaTotalMontoNeto_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.TOTAL_NETOColumnName; }
        }
        public static string VistaMonedaDestinoId_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.MONEDA_DESTINO_IDColumnName; }
        }

        public static string VistaMonedaDestinoCantidadDecimales_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.MONEDA_CANTIDAD_DECIMALESColumnName; }
        }

        public static string VistaMonedaDestinoCadenaDecimales_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.MONEDA_CADENA_DECIMALESColumnName; }
        }

        public static string VistaMonedaDestinoSimbolo_NombreCol
        {
            get { return PEDIDOS_CLIENTE_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        #endregion Vista
        #endregion Accessors

        #region Triggers

        private static TriggerNotasDePedidoCliente trigger = new TriggerNotasDePedidoCliente();

        private class TriggerNotasDePedidoCliente : TriggerBase<PEDIDOS_CLIENTERow>
        {
            public override void AfterUpdate(PEDIDOS_CLIENTERow fila_nueva, PEDIDOS_CLIENTERow fila_vieja, SessionService sesion)
            {
                if (!fila_nueva.FECHA.Date.Equals(fila_vieja.FECHA.Date))
                {
                    AlCambiarFecha(fila_nueva, fila_vieja, sesion);
                }
            }

            public override void AfterInsert(PEDIDOS_CLIENTERow fila_nueva, SessionService sesion)
            {
                throw new NotImplementedException();
            }
            public override void BeforeInsert(ref PEDIDOS_CLIENTERow fila_nueva, SessionService sesion)
            {
                throw new NotImplementedException();
            }

            public override void BeforeUpdate(ref PEDIDOS_CLIENTERow fila_nueva, PEDIDOS_CLIENTERow fila_vieja, SessionService sesion)
            {
                throw new NotImplementedException();
            }
            
            private static void AlCambiarFecha(PEDIDOS_CLIENTERow fila_nueva, PEDIDOS_CLIENTERow fila_vieja, SessionService sesion)
            {
                string valorAnterior = String.Empty;

                CALENDARIO_PAGOS_NP_CLIENTERow[] calendarios = sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.GetByNOTA_PEDIDO_CLIENTE_ID(fila_nueva.ID);
                foreach (CALENDARIO_PAGOS_NP_CLIENTERow calendario in calendarios)
                {
                    valorAnterior = calendario.ToString();
                    calendario.FECHA_VENCIMIENTO = calendario.FECHA_VENCIMIENTO.Date + (fila_nueva.FECHA.Date - fila_vieja.FECHA.Date);
                    LogCambiosService.LogDeRegistro(CalendarioPagosNPClienteService.Nombre_Tabla, calendario.ID, valorAnterior, calendario.ToString(), sesion);
                    sesion.db.CALENDARIO_PAGOS_NP_CLIENTECollection.Update(calendario);
                    valorAnterior = String.Empty;
                }
            }
        }

        #endregion Triggers
    }
}
