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
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class OrdenesServicioService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.ORDENES_SERVICIO;
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
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, drCabecera[OrdenesServicioService.TextoPredefinidoId_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, drDetalle[OrdenesServicioDetalleService.ActivoId_NombreCol]);
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
                ORDENES_SERVICIORow ordenRow = sesion.Db.ORDENES_SERVICIOCollection.GetByCASO_ID(caso_id)[0];
                ORDENES_SERVICIO_DETALLESRow[] detallesRows = sesion.Db.ORDENES_SERVICIO_DETALLESCollection.GetByORDEN_SERVICIO_ID(ordenRow.ID);

                //Borrador a Anulado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna
                    exito = true;
                    revisarRequisitos = true;
                }
                //Pendiente a Anulado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
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
                        mensaje = "La orden de servicio no tiene detalles.";
                        exito = false;
                    }

                    #region Control de Anticipo
                    if (ordenRow.ANTICIPO_REQUERIDO.Equals(Definiciones.SiNo.Si))
                    {
                        StringBuilder sql = new StringBuilder();
                        sql.Append("select nvl(sum(osd." + OrdenesServicioDetalleService.CostoTotal_NombreCol + "),0) " + OrdenesServicioDetalleService.CostoTotal_NombreCol + " \n");
                        sql.Append("  from " + OrdenesServicioDetalleService.Nombre_Vista + " osd \n");
                        sql.Append(" where osd." + OrdenesServicioDetalleService.OrdenServicioId_NombreCol + " = " + ordenRow.ID);

                        DataTable dt = sesion.db.EjecutarQuery(sql.ToString());

                        decimal total = 0;
                        if (!dt.Rows[0][OrdenesServicioDetalleService.CostoTotal_NombreCol].Equals(DBNull.Value))
                            total = (decimal)dt.Rows[0][OrdenesServicioDetalleService.CostoTotal_NombreCol];
                        if (!ordenRow.IsANTICIPO_MONTONull)
                        {
                            if (total < ordenRow.ANTICIPO_MONTO)
                            {
                                mensaje = "El monto del Anticipo no puede ser mayor al monto de la solicitud.";
                                exito = false;
                            }
                        }
                    }
                    #endregion Control de Anticipo

                    #region Se genera el numero de comprobante
                    if (exito && !ordenRow.IsAUTONUMERACION_IDNull && ordenRow.NRO_COMPROBANTE == null)
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
                    exito = true;
                    revisarRequisitos = true;

                    decimal total = 0; //Monto total de la OS.

                    StringBuilder sql = new StringBuilder();
                    sql.Append("select nvl(sum(osd." + OrdenesServicioDetalleService.CostoTotal_NombreCol + "),0) " + OrdenesServicioDetalleService.CostoTotal_NombreCol + " \n");
                    sql.Append("  from " + OrdenesServicioDetalleService.Nombre_Vista + " osd \n");
                    sql.Append(" where osd." + OrdenesServicioDetalleService.OrdenServicioId_NombreCol + " = " + ordenRow.ID);

                    DataTable dtTotalOrdenServicio = sesion.db.EjecutarQuery(sql.ToString());

                    if (!dtTotalOrdenServicio.Rows[0][OrdenesServicioDetalleService.CostoTotal_NombreCol].Equals(DBNull.Value))
                        total = (decimal)dtTotalOrdenServicio.Rows[0][OrdenesServicioDetalleService.CostoTotal_NombreCol];

                    #region Control de Anticipo
                    if (ordenRow.ANTICIPO_REQUERIDO.Equals(Definiciones.SiNo.Si))
                    {
                        if (!ordenRow.IsANTICIPO_MONTONull)
                        {
                            if (total < ordenRow.ANTICIPO_MONTO)
                            {
                                mensaje = "El monto del Anticipo no puede ser mayor al monto de la solicitud.";
                                exito = false;
                            }
                        }
                    }
                    #endregion Control de Anticipo

                    #region Generar Anticipo
                    string tipoAnticipo = string.Empty;

                    decimal montoAnticipo = 0;

                    if (exito)
                    {
                        decimal retencion = 0;
                        decimal impuestoAnticipo = 0;
                        decimal totalAnticipo = 0;

                        StringBuilder sqlTotalImpuesto = new StringBuilder(); //Para obtener el impuesto total de la OS.
                        StringBuilder sqlMinimoRetencion = new StringBuilder(); //Para obtener el monto mínimo requerido para aplicar retención.

                        sqlTotalImpuesto.Append("select sum(nvl(osd." + OrdenesServicioDetalleService.TotalImpuestoMonto_NombreCol + ",0)) " + OrdenesServicioDetalleService.TotalImpuestoMonto_NombreCol + " \n");
                        sqlTotalImpuesto.Append("  from " + OrdenesServicioDetalleService.Nombre_Vista + " osd \n");
                        sqlTotalImpuesto.Append(" where osd." + OrdenesServicioDetalleService.OrdenServicioId_NombreCol + " = " + ordenRow.ID);

                        sqlMinimoRetencion.Append("select tr." + TiposRetencionesService.MontoMinimo_NombreCol + ", tr." + TiposRetencionesService.Porcentaje_NombreCol + " \n");
                        sqlMinimoRetencion.Append("  from " + TiposRetencionesService.Nombre_Tabla + " tr \n");
                        sqlMinimoRetencion.Append(" where tr." + TiposRetencionesService.Id_NombreCol + " = " + Definiciones.TiposRetenciones.IVA);

                        DataTable dtTotalImpuesto = sesion.db.EjecutarQuery(sqlTotalImpuesto.ToString());
                        DataTable dtMinimoRetencion = sesion.db.EjecutarQuery(sqlMinimoRetencion.ToString());

                        if (ordenRow.ANTICIPO_GENERAR.Equals(Definiciones.SiNo.Si))
                        {
                            int cantidadDecimales = MonedasService.CantidadDecimalesStatic(detallesRows[0].MONEDA_ID);

                            if (ordenRow.ANTICIPO_REQUERIDO.Equals(Definiciones.SiNo.Si))
                            {
                                //Se calcula el impuesto del anticipo cuando el monto del anticipo es diferente al total de la OS. Se redondea manualmente a Guaraníes
                                impuestoAnticipo = Math.Round((decimal)dtTotalImpuesto.Rows[0][OrdenesServicioDetalleService.TotalImpuestoMonto_NombreCol] /
                                (decimal)dtTotalOrdenServicio.Rows[0][OrdenesServicioDetalleService.CostoTotal_NombreCol] * ordenRow.ANTICIPO_MONTO, cantidadDecimales);

                                retencion = Math.Round(impuestoAnticipo * decimal.Parse(dtMinimoRetencion.Rows[0][TiposRetencionesService.Porcentaje_NombreCol].ToString()) / 100, cantidadDecimales);

                                if (!ordenRow.IsANTICIPO_MONTONull)
                                {
                                    if (ordenRow.ANTICIPO_MONTO == 0)
                                    {
                                        mensaje = "El monto del Anticipo debe ser mayor a 0.";
                                        exito = false;
                                    }
                                }
                                else
                                {
                                    mensaje = "Debe definir el monto del anticipo.";
                                    exito = false;
                                }

                                tipoAnticipo = Definiciones.TipoAnticipo.Anticipo;
                                totalAnticipo = Math.Round(ordenRow.ANTICIPO_MONTO, cantidadDecimales);

                                if ((decimal.Parse(dtMinimoRetencion.Rows[0][TiposRetencionesService.MontoMinimo_NombreCol].ToString()) <= total) &&
                                    ordenRow.APLICAR_RETENCION.Equals(Definiciones.SiNo.Si))
                                {
                                    montoAnticipo = Math.Round(ordenRow.ANTICIPO_MONTO, cantidadDecimales) - Math.Round(retencion, cantidadDecimales);
                                }
                                else
                                {
                                    montoAnticipo = Math.Round(ordenRow.ANTICIPO_MONTO, cantidadDecimales);
                                    retencion = 0;
                                }
                            }
                            else
                            {
                                //Se calcula la retención sobre el total del impuesto de la OS. Se redondea manualmente a Guaraníes
                                retencion = Math.Round((decimal)dtTotalImpuesto.Rows[0][OrdenesServicioDetalleService.TotalImpuestoMonto_NombreCol] * decimal.Parse(dtMinimoRetencion.Rows[0][TiposRetencionesService.Porcentaje_NombreCol].ToString()) / 100, cantidadDecimales);

                                tipoAnticipo = Definiciones.TipoAnticipo.PagoTotal;
                                totalAnticipo = Math.Round((decimal)dtTotalOrdenServicio.Rows[0][OrdenesServicioDetalleService.CostoTotal_NombreCol], cantidadDecimales);

                                if (!dtTotalOrdenServicio.Rows[0][OrdenesServicioDetalleService.CostoTotal_NombreCol].Equals(DBNull.Value))
                                {
                                    if ((decimal.Parse(dtMinimoRetencion.Rows[0][TiposRetencionesService.MontoMinimo_NombreCol].ToString()) <= total) &&
                                    ordenRow.APLICAR_RETENCION.Equals(Definiciones.SiNo.Si))
                                    {
                                        montoAnticipo = Math.Round((decimal)dtTotalOrdenServicio.Rows[0][OrdenesServicioDetalleService.CostoTotal_NombreCol], cantidadDecimales) - Math.Round(retencion, cantidadDecimales);
                                    }
                                    else
                                    {
                                        montoAnticipo = Math.Round((decimal)dtTotalOrdenServicio.Rows[0][OrdenesServicioDetalleService.CostoTotal_NombreCol], cantidadDecimales);
                                        retencion = 0;
                                    }
                                }
                            }

                            //Generamos el caso de Anticipo
                            decimal casoAnticipoId = Definiciones.Error.Valor.EnteroPositivo;
                            string casoAnticipoEstado = string.Empty;
                            Hashtable camposAnticipo = new Hashtable();

                            string retencionFormateado = retencion.ToString() == "0" ? "0,00" : retencion.ToString("###,###,###.##");

                            camposAnticipo.Add(AnticiposProveedorService.SucursalId_NombreCol, ordenRow.SUCURSAL_ID);
                           if (!ordenRow.PROVEEDOR_ID.Equals(DBNull.Value))
                            {
                                camposAnticipo.Add(AnticiposProveedorService.ProveedorId_NombreCol, ordenRow.PROVEEDOR_ID);
                            }
                            
                            camposAnticipo.Add(AnticiposProveedorService.Fecha_NombreCol, DateTime.Now);
                            camposAnticipo.Add(AnticiposProveedorService.MontoTotal_NombreCol, montoAnticipo);
                            camposAnticipo.Add(AnticiposProveedorService.Observacion_NombreCol, "Caso Generado para el " + tipoAnticipo + " desde el caso : " + ordenRow.CASO_ID +
                                "\nTotal Anticipo: " + totalAnticipo.ToString("###,###,###.##") + "\nRetención: " + retencionFormateado);
                            camposAnticipo.Add(AnticiposProveedorService.CasoAsociadoId_NombreCol, ordenRow.CASO_ID);

                            camposAnticipo.Add(AnticiposProveedorService.MonedaId_NombreCol, detallesRows[0].MONEDA_ID);
                            camposAnticipo.Add(AnticiposProveedorService.CotizacionMoneda_NombreCol, detallesRows[0].COTIZACION);
                            camposAnticipo.Add(AnticiposProveedorService.MontoRetencion_NombreCol, retencion);

                            DataTable dtAutonumeracion = AutonumeracionesService.GetAutonumeracionesPorFlujo2(Definiciones.FlujosIDs.ANTICIPO_PROVEEDOR, ordenRow.SUCURSAL_ID, sesion);
                            if (dtAutonumeracion.Rows.Count == 0)
                            {
                                mensaje = "No existe un Talonario Definido para la Generación del Anticipo.";
                                exito = false;
                            }
                            camposAnticipo.Add(AnticiposProveedorService.AutonmeracionId_NombreCol, (decimal)dtAutonumeracion.Rows[0][AutonumeracionesService.Id_NombreCol]);

                            exito = AnticiposProveedorService.Guardar(camposAnticipo, true, ref casoAnticipoId, ref casoAnticipoEstado, sesion);
                            if (!exito)
                                throw new Exception("No se pudo crear el anticipo a proveedor.");
                            new AnticiposProveedorService().ProcesarCambioEstado(casoAnticipoId, Definiciones.EstadosFlujos.Pendiente, true, out mensaje, sesion);
                            new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService().ProcesarCambioEstado(casoAnticipoId, Definiciones.EstadosFlujos.Pendiente, "Transición automática por Aprobación del caso :" + ordenRow.CASO_ID, sesion);

                            if (exito)
                            {
                                Hashtable camposCasosAsociados = new Hashtable();

                                camposCasosAsociados.Add(OrdenesServicioCasosAsociadosService.OrdenServicioId_NombreCol, ordenRow.ID);
                                camposCasosAsociados.Add(OrdenesServicioCasosAsociadosService.CasoId_NombreCol, casoAnticipoId);
                                camposCasosAsociados.Add(OrdenesServicioCasosAsociadosService.FechaAgregado_NombreCol, DateTime.Now);
                                camposCasosAsociados.Add(OrdenesServicioCasosAsociadosService.UsuarioId_NombreCol, (new SessionService()).Usuario_Id);
                                camposCasosAsociados.Add(OrdenesServicioCasosAsociadosService.Observacion_NombreCol, tipoAnticipo);
                                camposCasosAsociados.Add(OrdenesServicioCasosAsociadosService.Editable_NombreCol, Definiciones.SiNo.No);
                                camposCasosAsociados.Add(OrdenesServicioCasosAsociadosService.ConsiderarComoPago_NombreCol, Definiciones.SiNo.Si);

                                OrdenesServicioCasosAsociadosService.Guardar(camposCasosAsociados, true, sesion);
                            }
                        }
                    }
                    #endregion Generar Anticipo                   
                }
                //Pendiente a Rechazado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Rechazado))
                {
                    //Acciones
                    //Ninguna
                    exito = true;
                    revisarRequisitos = true;
                }
                //Aprobado a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Eliminar Anticipos si existen y están en el estado PENDIENTE
                    exito = true;
                    revisarRequisitos = true;
                    string sql = "select " + AnticiposProveedorService.CasoId_NombreCol +
                                 " from " + AnticiposProveedorService.Nombre_Tabla + " ap, " + CasosService.Nombre_Tabla + " c" +
                                 " where " + AnticiposProveedorService.CasoAsociadoId_NombreCol + " = " + ordenRow.CASO_ID +
                                 " and ap." + AnticiposProveedorService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol +
                                 " and " + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

                    DataTable dtAnticipos = sesion.db.EjecutarQuery(sql);

                    for (int i = 0; i < dtAnticipos.Rows.Count; i++)
                        exito = AnticiposProveedorService.Borrar((decimal)dtAnticipos.Rows[i][0]);
                }
                //Aprobado a EnProceso
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.EnProceso))
                {
                    exito = true;
                    revisarRequisitos = true;
                    #region Control de Anticipo
                    if (ordenRow.ANTICIPO_REQUERIDO.Equals(Definiciones.SiNo.Si))
                    {
                        StringBuilder sql = new StringBuilder();
                        sql.Append("select nvl(sum(osd." + OrdenesServicioDetalleService.CostoTotal_NombreCol + "),0) " + OrdenesServicioDetalleService.CostoTotal_NombreCol + " \n");
                        sql.Append("  from " + OrdenesServicioDetalleService.Nombre_Vista + " osd \n");
                        sql.Append(" where osd." + OrdenesServicioDetalleService.OrdenServicioId_NombreCol + " = " + ordenRow.ID);

                        DataTable dt = sesion.db.EjecutarQuery(sql.ToString());

                        decimal total = 0;
                        if (!dt.Rows[0][OrdenesServicioDetalleService.CostoTotal_NombreCol].Equals(DBNull.Value))
                            total = (decimal)dt.Rows[0][OrdenesServicioDetalleService.CostoTotal_NombreCol];
                        if (!ordenRow.IsANTICIPO_MONTONull)
                        {
                            if (total < ordenRow.ANTICIPO_MONTO)
                            {
                                mensaje = "El monto del Anticipo no puede ser mayor al monto de la solicitud.";
                                exito = false;
                            }
                        }
                    }
                    #endregion Control de Anticipo
                }
                //EnProceso a Aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones
                    //Ninguna
                    exito = true;
                    revisarRequisitos = true;
                }

                 //EnProceso a ejecutado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Ejecutado))
                {
                    //Acciones
                    //Ninguna
                    exito = true;
                    revisarRequisitos = true;
                    foreach (ORDENES_SERVICIO_DETALLESRow detalle in detallesRows)
                    {
                        if (detalle.ESTADO_ID != "FINALIZADO")
                        {
                            throw new Exception("Unos de los detalles no esta en estado FINALIZADO, favor verificar");
                            exito = false;
                        }
                    }
                }
                //Aprobado a Ejecutado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Ejecutado))
                {                               
                    exito = true;
                    revisarRequisitos = true;

                    foreach (ORDENES_SERVICIO_DETALLESRow detalle in detallesRows)
                    {
                        if (detalle.ESTADO_ID != "FINALIZADO")
                        {
                            throw new Exception("Unos de los detalles no esta en estado FINALIZADO, favor verificar");
                            exito = false;
                        }
                    }
                }
                //EnProceso a Cerrado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                {                    
                    exito = true;
                    revisarRequisitos = true;
                    
                    #region Generar Factura

                    decimal caso_factura_creada_id = 0, factura_creada_id;
                    DataTable dtFacturaCreada;
                    FacturasClienteService facturaCliente = new FacturasClienteService();                    
					DataTable dtDetallesPersonalizados;
                    string estado_caso_factura = string.Empty;
                    
                    Hashtable campos = new Hashtable();
                    Hashtable camposDet = new Hashtable();

                    StringBuilder sql = new StringBuilder();
                    try
                    {
                        sql.Append("select os.caso_id, os.descripcion, os.persona_id, os.sucursal_id, os.condicion_pago_id, os.fecha_inicio, \n");
                        sql.Append(" sum(osd.porcentaje_descuento) / count(os.id) porcentaje_descuento, \n");
                        sql.Append(" sum(case when osd.moneda_id = 1 then osd.precio \n");
                        sql.Append("     else osd.precio * herramientas.Obtener_Cotizacion_Venta(pSucursal => os.sucursal_id,pMoneda => osd.moneda_id, pFecha => nvl(os.fecha_inicio, sysdate)) end) total_precio, \n");
                        sql.Append(" sum(case when osd.moneda_id = 1 then osd.total_impuesto_monto \n");
                        sql.Append("     else osd.total_impuesto_monto * herramientas.Obtener_Cotizacion_Venta(pSucursal => os.sucursal_id,pMoneda => osd.moneda_id, pFecha => nvl(os.fecha_inicio, sysdate)) end) total_impuesto_monto, \n");
                        sql.Append(" sum(case when osd.moneda_id = 1 then osd.costo_total \n");
                        sql.Append("     else osd.costo_total * herramientas.Obtener_Cotizacion_Venta(pSucursal => os.sucursal_id,pMoneda => osd.moneda_id, pFecha => nvl(os.fecha_inicio, sysdate)) end) costo_total \n");
                        sql.Append("from ordenes_servicio os, ordenes_servicio_detalles osd \n");
                         sql.Append("where osd.orden_servicio_id = os.id \n");
                        sql.Append("and os.id = " + ordenRow.ID + " \n");
                        sql.Append("group by os.caso_id, os.descripcion, os.persona_id, os.sucursal_id, os.condicion_pago_id, os.fecha_inicio");

                        DataTable dtTotalOrdenServicio = sesion.db.EjecutarQuery(sql.ToString());
                        DataTable dtDeposito = StockDepositosService.GetStockDepositosDataTable2((decimal)dtTotalOrdenServicio.Rows[0][SucursalId_NombreCol]);

                        campos.Add(FacturasClienteService.SucursalId_NombreCol, dtTotalOrdenServicio.Rows[0][SucursalId_NombreCol]);
                        campos.Add(FacturasClienteService.DepositoId_NombreCol, dtDeposito.Rows[0]["id"]);
                        campos.Add(FacturasClienteService.Fecha_NombreCol, DateTime.Now);
                        campos.Add(FacturasClienteService.FechaVencimiento_NombreCol, DateTime.Now);
                        campos.Add(FacturasClienteService.PersonaId_NombreCol, dtTotalOrdenServicio.Rows[0]["persona_id"]);
                        campos.Add(FacturasClienteService.MonedaDestinoId_NombreCol, Definiciones.Monedas.Guaranies); //si no es detallado, total en guaranies                            
                        campos.Add(FacturasClienteService.TotalMontoImpuesto_NombreCol, dtTotalOrdenServicio.Rows[0]["total_impuesto_monto"]);
                        if (dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"] != string.Empty || (decimal)dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"] != 0)
                        {
                            campos.Add(FacturasClienteService.TotalMontoDto_NombreCol, ((decimal)dtTotalOrdenServicio.Rows[0]["total_precio"] * (decimal)dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"]) / 100);
                            campos.Add(FacturasClienteService.TotalMontoBruto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["total_precio"] + (decimal)campos[FacturasClienteService.TotalMontoDto_NombreCol]);
                        }
                        else
                        {
                            campos.Add(FacturasClienteService.TotalMontoDto_NombreCol, 0);
                            campos.Add(FacturasClienteService.TotalMontoBruto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["total_precio"]);
                        }
                        campos.Add(FacturasClienteService.TotalNeto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["total_precio"]);
                        campos.Add(FacturasClienteService.TotalCostoBruto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["costo_total"]);
                        campos.Add(FacturasClienteService.TotalCostoNeto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["costo_total"]);
                        campos.Add(FacturasClienteService.AfectaCtacte_NombreCol, Definiciones.SiNo.Si);
                        campos.Add(FacturasClienteService.Observacion_NombreCol, dtTotalOrdenServicio.Rows[0]["descripcion"]);
                        if (dtTotalOrdenServicio.Rows[0]["condicion_pago_id"].ToString() != string.Empty)
                            campos.Add(FacturasClienteService.CondicionPagoId_NombreCol, dtTotalOrdenServicio.Rows[0]["condicion_pago_id"]);
                        else
                            campos.Add(FacturasClienteService.CondicionPagoId_NombreCol, Definiciones.CondicionPago.Contado);

                        campos.Add(FacturasClienteService.Impreso_NombreCol, Definiciones.SiNo.No);
                        campos.Add(FacturasClienteService.AfectaStock_NombreCol, Definiciones.SiNo.No);
                        campos.Add(FacturasClienteService.CasoOrigenId_NombreCol, caso_id);
                        campos.Add(FacturasClienteService.TotalEntregaInicial_NombreCol, 0);
                        campos.Add(FacturasClienteService.PorcentajeDescSobreTotal_NombreCol, dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"]);
                        campos.Add(FacturasClienteService.AConsignacion_NombreCol, Definiciones.SiNo.No);
                        campos.Add(FacturasClienteService.ComisionPorVenta_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
                        campos.Add(FacturasClienteService.AfectaLineaCredito_NombreCol, Definiciones.SiNo.No);

                        decimal cotizacionDestino = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtTotalOrdenServicio.Rows[0][SucursalId_NombreCol]), Definiciones.Monedas.Guaranies, DateTime.Now);
                        campos.Add(FacturasClienteService.CotizacionDestino_NombreCol, cotizacionDestino);

                        // Se crea la factura y se obtiene el nro de caso creado
                        FacturasClienteService.Guardar(campos, true, ref caso_factura_creada_id, ref estado_caso_factura, sesion);

                        // Se obtiene el id de la factura creada
                        dtFacturaCreada = FacturasClienteService.GetFacturaClienteDataTable(FacturasClienteService.CasoId_NombreCol + " = " + caso_factura_creada_id, string.Empty, sesion);
                        factura_creada_id = (decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol];
                        
                        DateTime det_fecha_primer_vencimiento, det_fecha_segundo_vencimiento;
                        bool usar_fecha_primer_vencimiento, usar_fecha_segundo_vencimiento;

                        if (ordenRow.FACTURA_DETALLADA == Definiciones.SiNo.No)
                        {  
                            camposDet.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, factura_creada_id);
                            camposDet.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.OrdenDeServicioArticuloGenerico));
                            camposDet.Add(FacturasClienteDetalleService.MonedaOrigenId_NombreCol, Definiciones.Monedas.Guaranies);
                            camposDet.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, Definiciones.UnidadesMedida.Simbolo.Unidades);
                            camposDet.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, 0);
                            camposDet.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, 1);
                            camposDet.Add(FacturasClienteDetalleService.CantidadPorCajaDestino_NombreCol, 0);
                            camposDet.Add(FacturasClienteDetalleService.CantidadUnitariaTotalDest_NombreCol, 1);
                            camposDet.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["total_precio"]);
                            if ((decimal)dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"] != 0)
                            {
                                camposDet.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, ((decimal)dtTotalOrdenServicio.Rows[0]["total_precio"] * (decimal)dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"]) / 100);
                                camposDet.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"]);
                            }
                            else
                            {
                                camposDet.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, 0);
                                camposDet.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, 0);
                            }
                            camposDet.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, Definiciones.Impuestos.IVA_10);
                            camposDet.Add(FacturasClienteDetalleService.TotalMontoImpuesto_NombreCol, dtTotalOrdenServicio.Rows[0]["total_impuesto_monto"]);
                            if ((decimal)dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"] != 0)
                            {
                                camposDet.Add(FacturasClienteDetalleService.TotalMontoDescuento_NombreCol, ((decimal)dtTotalOrdenServicio.Rows[0]["total_precio"] * (decimal)dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"]) / 100);
                                camposDet.Add(FacturasClienteDetalleService.TotalMontoBruto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["total_precio"] + (decimal)campos[FacturasClienteService.TotalMontoDto_NombreCol]);
                            }
                            else
                            {
                                camposDet.Add(FacturasClienteDetalleService.TotalMontoDescuento_NombreCol, 0);
                                camposDet.Add(FacturasClienteDetalleService.TotalMontoBruto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["total_precio"]);
                            }
                            camposDet.Add(FacturasClienteDetalleService.TotalNeto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["total_precio"]);
                            camposDet.Add(FacturasClienteDetalleService.CantidadDevueltaNotaCredito_NombreCol, 0);
                            camposDet.Add(FacturasClienteDetalleService.UnidadOrigenId_NombreCol, Definiciones.UnidadesMedida.Simbolo.Unidades);
                            camposDet.Add(FacturasClienteDetalleService.CostoMonto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["costo_total"]);
                            camposDet.Add(FacturasClienteDetalleService.CostoMonedaId_NombreCol, Definiciones.Monedas.Guaranies);
                            camposDet.Add(FacturasClienteDetalleService.ArticuloDescripcion_NombreCol, dtTotalOrdenServicio.Rows[0]["descripcion"]);
                            camposDet.Add(FacturasClienteDetalleService.CostoMonedaCotizacion_NombreCol, cotizacionDestino);
                            camposDet.Add(FacturasClienteDetalleService.CotizacionOrigen_NombreCol, cotizacionDestino);

                            DataTable dtLote = ArticulosLotesService.GetArticulosLotesInfoCompleta2(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.OrdenDeServicioArticuloGenerico), null);
                            camposDet.Add(FacturasClienteDetalleService.LoteId_NombreCol, dtLote.Rows[0]["id"]);
                            decimal facturaClienteId = FacturasClienteDetalleService.Guardar(factura_creada_id, camposDet, false, true, out det_fecha_primer_vencimiento, out usar_fecha_primer_vencimiento, out det_fecha_segundo_vencimiento, out usar_fecha_segundo_vencimiento, false, sesion);
                        }
                        else
                        {
                             // Se crean los detalles de la factura
                            foreach (ORDENES_SERVICIO_DETALLESRow detalle in detallesRows)
                            {
                                camposDet.Clear();
                                camposDet.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, factura_creada_id);
                                if (!detalle.IsARTICULO_IDNull)
                                    camposDet.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, detalle.ARTICULO_ID);                                    
                                else 
                                    camposDet.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.OrdenDeServicioArticuloGenerico));
                                camposDet.Add(FacturasClienteDetalleService.MonedaOrigenId_NombreCol, detalle.MONEDA_ID);
                                if (detalle.UNIDAD_ID != null)
                                    camposDet.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, detalle.UNIDAD_ID);
                                else
                                    camposDet.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, Definiciones.UnidadesMedida.Simbolo.Unidades);
                                camposDet.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, 0);
                                camposDet.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, detalle.CANTIDAD_HORAS);
                                camposDet.Add(FacturasClienteDetalleService.CantidadPorCajaDestino_NombreCol, 0);
                                camposDet.Add(FacturasClienteDetalleService.CantidadUnitariaTotalDest_NombreCol, detalle.CANTIDAD_HORAS);
                                camposDet.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, detalle.PRECIO);
                                if (detalle.PORCENTAJE_DESCUENTO != 0)
                                {
                                    camposDet.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (detalle.PRECIO * detalle.PORCENTAJE_DESCUENTO) / 100);
                                    camposDet.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, detalle.PORCENTAJE_DESCUENTO);
                                }
                                else
                                {
                                    camposDet.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, 0);
                                    camposDet.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, 0);
                                }
                                camposDet.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, detalle.IMPUESTO_ID);
                                camposDet.Add(FacturasClienteDetalleService.TotalMontoImpuesto_NombreCol, detalle.TOTAL_IMPUESTO_MONTO);
                                if (detalle.PORCENTAJE_DESCUENTO != 0)
                                {
                                    camposDet.Add(FacturasClienteDetalleService.TotalMontoDescuento_NombreCol, (detalle.PRECIO * detalle.PORCENTAJE_DESCUENTO) / 100);
                                    camposDet.Add(FacturasClienteDetalleService.TotalMontoBruto_NombreCol, detalle.PRECIO + (detalle.PRECIO * detalle.PORCENTAJE_DESCUENTO) / 100);
                                }
                                else
                                {
                                    camposDet.Add(FacturasClienteDetalleService.TotalMontoDescuento_NombreCol, 0);
                                    camposDet.Add(FacturasClienteDetalleService.TotalMontoBruto_NombreCol, detalle.PRECIO);
                                }
                                camposDet.Add(FacturasClienteDetalleService.TotalNeto_NombreCol, detalle.PRECIO);
                                camposDet.Add(FacturasClienteDetalleService.CantidadDevueltaNotaCredito_NombreCol, 0);
                                if (detalle.UNIDAD_ID != null)
                                    camposDet.Add(FacturasClienteDetalleService.UnidadOrigenId_NombreCol, detalle.UNIDAD_ID);
                                else
                                    camposDet.Add(FacturasClienteDetalleService.UnidadOrigenId_NombreCol, Definiciones.UnidadesMedida.Simbolo.Unidades);
                                camposDet.Add(FacturasClienteDetalleService.CostoMonto_NombreCol, detalle.COSTO_TOTAL);
                                camposDet.Add(FacturasClienteDetalleService.CostoMonedaId_NombreCol, detalle.MONEDA_ID);
                                if (detalle.IsARTICULO_IDNull)
                                    camposDet.Add(FacturasClienteDetalleService.ArticuloDescripcion_NombreCol, detalle.DESCRIPCION);
                                camposDet.Add(FacturasClienteDetalleService.CostoMonedaCotizacion_NombreCol, detalle.COTIZACION);
                                camposDet.Add(FacturasClienteDetalleService.CotizacionOrigen_NombreCol, detalle.COTIZACION);

                                DataTable dtLote;
                                if (!detalle.IsARTICULO_IDNull)
                                    dtLote = ArticulosLotesService.GetArticulosLotesInfoCompleta2(detalle.ARTICULO_ID, null);
                                else
                                    dtLote = ArticulosLotesService.GetArticulosLotesInfoCompleta2(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.OrdenDeServicioArticuloGenerico), null);
                                camposDet.Add(FacturasClienteDetalleService.LoteId_NombreCol, dtLote.Rows[0]["id"]);
                                decimal facturaClienteId = FacturasClienteDetalleService.Guardar(factura_creada_id, camposDet, false, true, out det_fecha_primer_vencimiento, out usar_fecha_primer_vencimiento, out det_fecha_segundo_vencimiento, out usar_fecha_segundo_vencimiento, false, sesion);
                            }                            
                        }
                        //se guarda en la tabla ordenes_servicio_casos_asoc                                                                  
                        System.Collections.Hashtable camposRelaciones = new System.Collections.Hashtable();
                        camposRelaciones.Add(OrdenesServicioCasosAsociadosService.OrdenServicioId_NombreCol, ordenRow.ID);
                        camposRelaciones.Add(OrdenesServicioCasosAsociadosService.CasoId_NombreCol, caso_factura_creada_id);
                        camposRelaciones.Add(OrdenesServicioCasosAsociadosService.Observacion_NombreCol, ordenRow.DESCRIPCION);
                        camposRelaciones.Add(OrdenesServicioCasosAsociadosService.ConsiderarComoPago_NombreCol, Definiciones.SiNo.No);
                        camposRelaciones.Add(OrdenesServicioCasosAsociadosService.FechaAgregado_NombreCol, DateTime.Now);
                        camposRelaciones.Add(OrdenesServicioCasosAsociadosService.Editable_NombreCol, Definiciones.SiNo.No);

                        OrdenesServicioCasosAsociadosService.Guardar(camposRelaciones, true, sesion);

                        facturaCliente.ProcesarCambioEstado(caso_factura_creada_id, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                        if (exito)
                            exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(caso_factura_creada_id, Definiciones.EstadosFlujos.Pendiente, "Transición automática por paso de la Orden de Servicio caso " + caso_id + " al estado pendiente.", sesion);
                        if (exito)
                            facturaCliente.EjecutarAccionesLuegoDeCambioEstado(caso_factura_creada_id, Definiciones.EstadosFlujos.Pendiente, sesion);
                    }
                    catch (Exception exp)
                    {
                        mensaje = exp.Message.ToString();
                        exito = false;
                    }

                    #endregion Generar Factura
                }
                //Ejecutado a Cerrado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Ejecutado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                {
                    exito = true;
                    revisarRequisitos = true;

                    foreach (ORDENES_SERVICIO_DETALLESRow detalle in detallesRows)
                    {
                        if (detalle.ESTADO_ID != "CERRADO")
                        {
                            throw new Exception("Unos de los detalles no esta en estado CERRADO, favor verificar");
                            exito = false;
                        }
                    }

                    #region Generar Factura

                    decimal caso_factura_creada_id = 0, factura_creada_id;
                    DataTable dtFacturaCreada;
                    FacturasClienteService facturaCliente = new FacturasClienteService();
                    string estado_caso_factura = string.Empty;

                    Hashtable campos = new Hashtable();
                    Hashtable camposDet = new Hashtable();

                    StringBuilder sql = new StringBuilder();
                    try
                    {
                        sql.Append("select os.caso_id, os.descripcion, os.persona_id, os.sucursal_id, os.condicion_pago_id, os.fecha_inicio, \n");
                        sql.Append(" sum(osd.porcentaje_descuento) / count(os.id) porcentaje_descuento, \n");
                        sql.Append(" sum(case when osd.moneda_id = 1 then osd.precio \n");
                        sql.Append("     else osd.precio * herramientas.Obtener_Cotizacion_Venta(pSucursal => os.sucursal_id,pMoneda => osd.moneda_id, pFecha => nvl(os.fecha_inicio, sysdate)) end) total_precio, \n");
                        sql.Append(" sum(case when osd.moneda_id = 1 then osd.total_impuesto_monto \n");
                        sql.Append("     else osd.total_impuesto_monto * herramientas.Obtener_Cotizacion_Venta(pSucursal => os.sucursal_id,pMoneda => osd.moneda_id, pFecha => nvl(os.fecha_inicio, sysdate)) end) total_impuesto_monto, \n");
                        sql.Append(" sum(case when osd.moneda_id = 1 then osd.costo_total \n");
                        sql.Append("     else osd.costo_total * herramientas.Obtener_Cotizacion_Venta(pSucursal => os.sucursal_id,pMoneda => osd.moneda_id, pFecha => nvl(os.fecha_inicio, sysdate)) end) costo_total \n");
                        sql.Append("from ordenes_servicio os, ordenes_servicio_detalles osd \n");
                        sql.Append("where osd.orden_servicio_id = os.id \n");
                        sql.Append("and os.id = " + ordenRow.ID + " \n");
                        sql.Append("group by os.caso_id, os.descripcion, os.persona_id, os.sucursal_id, os.condicion_pago_id, os.fecha_inicio");

                        DataTable dtTotalOrdenServicio = sesion.db.EjecutarQuery(sql.ToString());
                        DataTable dtDeposito = StockDepositosService.GetStockDepositosDataTable2((decimal)dtTotalOrdenServicio.Rows[0][SucursalId_NombreCol]);

                        campos.Add(FacturasClienteService.SucursalId_NombreCol, dtTotalOrdenServicio.Rows[0][SucursalId_NombreCol]);
                        campos.Add(FacturasClienteService.DepositoId_NombreCol, dtDeposito.Rows[0]["id"]);
                        campos.Add(FacturasClienteService.Fecha_NombreCol, DateTime.Now);
                        campos.Add(FacturasClienteService.FechaVencimiento_NombreCol, DateTime.Now);
                        campos.Add(FacturasClienteService.PersonaId_NombreCol, dtTotalOrdenServicio.Rows[0]["persona_id"]);
                        campos.Add(FacturasClienteService.MonedaDestinoId_NombreCol, Definiciones.Monedas.Guaranies); //si no es detallado, total en guaranies                            
                        campos.Add(FacturasClienteService.TotalMontoImpuesto_NombreCol, dtTotalOrdenServicio.Rows[0]["total_impuesto_monto"]);
                        if (dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"] != string.Empty || (decimal)dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"] != 0)
                        {
                            campos.Add(FacturasClienteService.TotalMontoDto_NombreCol, ((decimal)dtTotalOrdenServicio.Rows[0]["total_precio"] * (decimal)dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"]) / 100);
                            campos.Add(FacturasClienteService.TotalMontoBruto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["total_precio"] + (decimal)campos[FacturasClienteService.TotalMontoDto_NombreCol]);
                        }
                        else
                        {
                            campos.Add(FacturasClienteService.TotalMontoDto_NombreCol, 0);
                            campos.Add(FacturasClienteService.TotalMontoBruto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["total_precio"]);
                        }
                        campos.Add(FacturasClienteService.TotalNeto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["total_precio"]);
                        campos.Add(FacturasClienteService.TotalCostoBruto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["costo_total"]);
                        campos.Add(FacturasClienteService.TotalCostoNeto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["costo_total"]);
                        campos.Add(FacturasClienteService.AfectaCtacte_NombreCol, Definiciones.SiNo.Si);
                        campos.Add(FacturasClienteService.Observacion_NombreCol, dtTotalOrdenServicio.Rows[0]["descripcion"]);
                        if (dtTotalOrdenServicio.Rows[0]["condicion_pago_id"].ToString() != string.Empty)
                            campos.Add(FacturasClienteService.CondicionPagoId_NombreCol, dtTotalOrdenServicio.Rows[0]["condicion_pago_id"]);
                        else
                            campos.Add(FacturasClienteService.CondicionPagoId_NombreCol, Definiciones.CondicionPago.Contado);

                        campos.Add(FacturasClienteService.Impreso_NombreCol, Definiciones.SiNo.No);
                        campos.Add(FacturasClienteService.AfectaStock_NombreCol, Definiciones.SiNo.No);
                        campos.Add(FacturasClienteService.CasoOrigenId_NombreCol, caso_id);
                        campos.Add(FacturasClienteService.TotalEntregaInicial_NombreCol, 0);
                        campos.Add(FacturasClienteService.PorcentajeDescSobreTotal_NombreCol, dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"]);
                        campos.Add(FacturasClienteService.AConsignacion_NombreCol, Definiciones.SiNo.No);
                        campos.Add(FacturasClienteService.ComisionPorVenta_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
                        campos.Add(FacturasClienteService.AfectaLineaCredito_NombreCol, Definiciones.SiNo.No);

                        decimal cotizacionDestino = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtTotalOrdenServicio.Rows[0][SucursalId_NombreCol]), Definiciones.Monedas.Guaranies, DateTime.Now);
                        campos.Add(FacturasClienteService.CotizacionDestino_NombreCol, cotizacionDestino);

                        // Se crea la factura y se obtiene el nro de caso creado
                        FacturasClienteService.Guardar(campos, true, ref caso_factura_creada_id, ref estado_caso_factura, sesion);

                        // Se obtiene el id de la factura creada
                        dtFacturaCreada = FacturasClienteService.GetFacturaClienteDataTable(FacturasClienteService.CasoId_NombreCol + " = " + caso_factura_creada_id, string.Empty, sesion);
                        factura_creada_id = (decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol];

                        DateTime det_fecha_primer_vencimiento, det_fecha_segundo_vencimiento;
                        bool usar_fecha_primer_vencimiento, usar_fecha_segundo_vencimiento;

                        if (ordenRow.FACTURA_DETALLADA == Definiciones.SiNo.No)
                        {
                            camposDet.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, factura_creada_id);
                            camposDet.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.OrdenDeServicioArticuloGenerico));
                            camposDet.Add(FacturasClienteDetalleService.MonedaOrigenId_NombreCol, Definiciones.Monedas.Guaranies);
                            camposDet.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, Definiciones.UnidadesMedida.Simbolo.Unidades);
                            camposDet.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, 0);
                            camposDet.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, 1);
                            camposDet.Add(FacturasClienteDetalleService.CantidadPorCajaDestino_NombreCol, 0);
                            camposDet.Add(FacturasClienteDetalleService.CantidadUnitariaTotalDest_NombreCol, 1);
                            camposDet.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["total_precio"]);
                            if ((decimal)dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"] != 0)
                            {
                                camposDet.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, ((decimal)dtTotalOrdenServicio.Rows[0]["total_precio"] * (decimal)dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"]) / 100);
                                camposDet.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"]);
                            }
                            else
                            {
                                camposDet.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, 0);
                                camposDet.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, 0);
                            }
                            camposDet.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, Definiciones.Impuestos.IVA_10);
                            camposDet.Add(FacturasClienteDetalleService.TotalMontoImpuesto_NombreCol, dtTotalOrdenServicio.Rows[0]["total_impuesto_monto"]);
                            if ((decimal)dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"] != 0)
                            {
                                camposDet.Add(FacturasClienteDetalleService.TotalMontoDescuento_NombreCol, ((decimal)dtTotalOrdenServicio.Rows[0]["total_precio"] * (decimal)dtTotalOrdenServicio.Rows[0]["porcentaje_descuento"]) / 100);
                                camposDet.Add(FacturasClienteDetalleService.TotalMontoBruto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["total_precio"] + (decimal)campos[FacturasClienteService.TotalMontoDto_NombreCol]);
                            }
                            else
                            {
                                camposDet.Add(FacturasClienteDetalleService.TotalMontoDescuento_NombreCol, 0);
                                camposDet.Add(FacturasClienteDetalleService.TotalMontoBruto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["total_precio"]);
                            }
                            camposDet.Add(FacturasClienteDetalleService.TotalNeto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["total_precio"]);
                            camposDet.Add(FacturasClienteDetalleService.CantidadDevueltaNotaCredito_NombreCol, 0);
                            camposDet.Add(FacturasClienteDetalleService.UnidadOrigenId_NombreCol, Definiciones.UnidadesMedida.Simbolo.Unidades);
                            camposDet.Add(FacturasClienteDetalleService.CostoMonto_NombreCol, (decimal)dtTotalOrdenServicio.Rows[0]["costo_total"]);
                            camposDet.Add(FacturasClienteDetalleService.CostoMonedaId_NombreCol, Definiciones.Monedas.Guaranies);
                            camposDet.Add(FacturasClienteDetalleService.ArticuloDescripcion_NombreCol, dtTotalOrdenServicio.Rows[0]["descripcion"]);
                            camposDet.Add(FacturasClienteDetalleService.CostoMonedaCotizacion_NombreCol, cotizacionDestino);
                            camposDet.Add(FacturasClienteDetalleService.CotizacionOrigen_NombreCol, cotizacionDestino);

                            DataTable dtLote = ArticulosLotesService.GetArticulosLotesInfoCompleta2(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.OrdenDeServicioArticuloGenerico), null);
                            camposDet.Add(FacturasClienteDetalleService.LoteId_NombreCol, dtLote.Rows[0]["id"]);
                            decimal facturaClienteId = FacturasClienteDetalleService.Guardar(factura_creada_id, camposDet, false, true, out det_fecha_primer_vencimiento, out usar_fecha_primer_vencimiento, out det_fecha_segundo_vencimiento, out usar_fecha_segundo_vencimiento, false, sesion);
                        }
                        else
                        {
                            // Se crean los detalles de la factura
                            foreach (ORDENES_SERVICIO_DETALLESRow detalle in detallesRows)
                            {
                                camposDet.Clear();
                                camposDet.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, factura_creada_id);
                                if (!detalle.IsARTICULO_IDNull)
                                    camposDet.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, detalle.ARTICULO_ID);
                                else
                                    camposDet.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.OrdenDeServicioArticuloGenerico));
                                camposDet.Add(FacturasClienteDetalleService.MonedaOrigenId_NombreCol, detalle.MONEDA_ID);
                                if (detalle.UNIDAD_ID != null)
                                    camposDet.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, detalle.UNIDAD_ID);
                                else
                                    camposDet.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, Definiciones.UnidadesMedida.Simbolo.Unidades);
                                camposDet.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, 0);
                                camposDet.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, detalle.CANTIDAD_HORAS);
                                camposDet.Add(FacturasClienteDetalleService.CantidadPorCajaDestino_NombreCol, 0);
                                camposDet.Add(FacturasClienteDetalleService.CantidadUnitariaTotalDest_NombreCol, detalle.CANTIDAD_HORAS);
                                camposDet.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, detalle.PRECIO);
                                if (detalle.PORCENTAJE_DESCUENTO != 0)
                                {
                                    camposDet.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (detalle.PRECIO * detalle.PORCENTAJE_DESCUENTO) / 100);
                                    camposDet.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, detalle.PORCENTAJE_DESCUENTO);
                                }
                                else
                                {
                                    camposDet.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, 0);
                                    camposDet.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, 0);
                                }
                                camposDet.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, detalle.IMPUESTO_ID);
                                camposDet.Add(FacturasClienteDetalleService.TotalMontoImpuesto_NombreCol, detalle.TOTAL_IMPUESTO_MONTO);
                                if (detalle.PORCENTAJE_DESCUENTO != 0)
                                {
                                    camposDet.Add(FacturasClienteDetalleService.TotalMontoDescuento_NombreCol, (detalle.PRECIO * detalle.PORCENTAJE_DESCUENTO) / 100);
                                    camposDet.Add(FacturasClienteDetalleService.TotalMontoBruto_NombreCol, detalle.PRECIO + (detalle.PRECIO * detalle.PORCENTAJE_DESCUENTO) / 100);
                                }
                                else
                                {
                                    camposDet.Add(FacturasClienteDetalleService.TotalMontoDescuento_NombreCol, 0);
                                    camposDet.Add(FacturasClienteDetalleService.TotalMontoBruto_NombreCol, detalle.PRECIO);
                                }
                                camposDet.Add(FacturasClienteDetalleService.TotalNeto_NombreCol, detalle.PRECIO);
                                camposDet.Add(FacturasClienteDetalleService.CantidadDevueltaNotaCredito_NombreCol, 0);
                                if (detalle.UNIDAD_ID != null)
                                    camposDet.Add(FacturasClienteDetalleService.UnidadOrigenId_NombreCol, detalle.UNIDAD_ID);
                                else
                                    camposDet.Add(FacturasClienteDetalleService.UnidadOrigenId_NombreCol, Definiciones.UnidadesMedida.Simbolo.Unidades);
                                camposDet.Add(FacturasClienteDetalleService.CostoMonto_NombreCol, detalle.COSTO_TOTAL);
                                camposDet.Add(FacturasClienteDetalleService.CostoMonedaId_NombreCol, detalle.MONEDA_ID);
                                if (detalle.IsARTICULO_IDNull)
                                    camposDet.Add(FacturasClienteDetalleService.ArticuloDescripcion_NombreCol, detalle.DESCRIPCION);
                                camposDet.Add(FacturasClienteDetalleService.CostoMonedaCotizacion_NombreCol, detalle.COTIZACION);
                                camposDet.Add(FacturasClienteDetalleService.CotizacionOrigen_NombreCol, detalle.COTIZACION);

                                DataTable dtLote;
                                if (!detalle.IsARTICULO_IDNull)
                                    dtLote = ArticulosLotesService.GetArticulosLotesInfoCompleta2(detalle.ARTICULO_ID, null);
                                else
                                    dtLote = ArticulosLotesService.GetArticulosLotesInfoCompleta2(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.OrdenDeServicioArticuloGenerico), null);
                                camposDet.Add(FacturasClienteDetalleService.LoteId_NombreCol, dtLote.Rows[0]["id"]);
                                decimal facturaClienteId = FacturasClienteDetalleService.Guardar(factura_creada_id, camposDet, false, true, out det_fecha_primer_vencimiento, out usar_fecha_primer_vencimiento, out det_fecha_segundo_vencimiento, out usar_fecha_segundo_vencimiento, false, sesion);
                            }
                        }
                        //se guarda en la tabla ordenes_servicio_casos_asoc                                                                  
                        System.Collections.Hashtable camposRelaciones = new System.Collections.Hashtable();
                        camposRelaciones.Add(OrdenesServicioCasosAsociadosService.OrdenServicioId_NombreCol, ordenRow.ID);
                        camposRelaciones.Add(OrdenesServicioCasosAsociadosService.CasoId_NombreCol, caso_factura_creada_id);
                        camposRelaciones.Add(OrdenesServicioCasosAsociadosService.Observacion_NombreCol, ordenRow.DESCRIPCION);
                        camposRelaciones.Add(OrdenesServicioCasosAsociadosService.ConsiderarComoPago_NombreCol, Definiciones.SiNo.No);
                        camposRelaciones.Add(OrdenesServicioCasosAsociadosService.FechaAgregado_NombreCol, DateTime.Now);
                        camposRelaciones.Add(OrdenesServicioCasosAsociadosService.Editable_NombreCol, Definiciones.SiNo.No);

                        OrdenesServicioCasosAsociadosService.Guardar(camposRelaciones, true, sesion);

                        facturaCliente.ProcesarCambioEstado(caso_factura_creada_id, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                        if (exito)
                            exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(caso_factura_creada_id, Definiciones.EstadosFlujos.Pendiente, "Transición automática por paso de la Orden de Servicio caso " + caso_id + " al estado pendiente.", sesion);
                        if (exito)
                            facturaCliente.EjecutarAccionesLuegoDeCambioEstado(caso_factura_creada_id, Definiciones.EstadosFlujos.Pendiente, sesion);
                    }
                    catch (Exception exp)
                    {
                        mensaje = exp.Message.ToString();
                        exito = false;
                    }

                    #endregion Generar Factura
                }

                //Verificar si se cumplen los requisitos
                if (exito && revisarRequisitos)
                {
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                }

                if (exito)
                {
                    sesion.Db.CASOSCollection.Update(casoRow);
                    sesion.Db.ORDENES_SERVICIOCollection.Update(ordenRow);
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
        public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion)
        {

        }

        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            throw new NotImplementedException();
        }

        #endregion Implementacion de metodos abstract

        #region GetOrdenesServicioDataTable
        /// <summary>
        /// Gets the ordenes servicio data table.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="orderby">The orderby.</param>
        /// <returns></returns>
        public static DataTable GetOrdenesServicioDataTable(string where, string orderby)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ORDENES_SERVICIOCollection.GetAsDataTable(where, orderby);
            }
        }

        public static DataTable GetOrdenesServicioDataTable(string where, string orderby, SessionService sesion)
        {

            return sesion.Db.ORDENES_SERVICIOCollection.GetAsDataTable(where, orderby);

        }
        #endregion GetOrdenesServicioDataTable

        #region GetOrdenesServicioInfoCompleta
        /// <summary>
        /// Gets the ordenes servicio data table.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="orderby">The orderby.</param>
        /// <returns></returns>
        public static DataTable GetOrdenesServicioInfoCompleta(string where, string orderby)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ORDENES_SERVICIO_INFO_COMPLETACollection.GetAsDataTable(where, orderby);
            }
        }
        #endregion GetOrdenesServicioInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref String estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    ORDENES_SERVICIORow row = new ORDENES_SERVICIORow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("ordenes_servicio_sqc");
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[OrdenesServicioService.SucursalId_NombreCol].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.ORDENES_SERVICIO.ToString()),
                                                             int.Parse(sesion.Usuario_Id.ToString()),
                                                             SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.ORDENES_SERVICIOCollection.GetRow(OrdenesServicioService.Id_NombreCol + " = " + campos[OrdenesServicioService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.ES_PARA_CLIENTE = (string)campos[OrdenesServicioService.EsParaCliente_NombreCol];

                    if (row.ES_PARA_CLIENTE.Equals(Definiciones.SiNo.Si))
                    {
                        row.PERSONA_ID = (decimal)campos[OrdenesServicioService.PersonaId_NombreCol];
                        row.IsPROVEEDOR_IDNull = true;
                    }
                    else
                    {
                        row.PROVEEDOR_ID = (decimal)campos[OrdenesServicioService.ProveedorId_NombreCol];
                        row.IsPERSONA_IDNull = true;
                    }

                    row.SUCURSAL_ID = (decimal)campos[OrdenesServicioService.SucursalId_NombreCol];
                    row.TEXTO_PREDEFINIDO_ID = decimal.Parse(campos[OrdenesServicioService.TextoPredefinidoId_NombreCol].ToString());
                    row.DEBE_FACTURAR = (string)campos[OrdenesServicioService.DebeFacturar_NombreCol];
                    row.VISTO_BUENO_FUNCIONARIO = (string)campos[OrdenesServicioService.VistoBuenoFuncionario_NombreCol];
                    row.VISTO_BUENO_GERENCIA = (string)campos[OrdenesServicioService.VistoBuenoGerencia_NombreCol];
                    row.VISTO_BUENO_PERSONA = (string)campos[OrdenesServicioService.VistoBuenoPersona_NombreCol];

                    if (campos.Contains(OrdenesServicioService.AutonumeracionId_NombreCol))
                    {
                        if (row.IsAUTONUMERACION_IDNull || row.AUTONUMERACION_ID != (decimal)campos[OrdenesServicioService.AutonumeracionId_NombreCol])
                        {
                            if (AutonumeracionesService.EstaActivo((decimal)campos[OrdenesServicioService.AutonumeracionId_NombreCol]))
                                row.AUTONUMERACION_ID = (decimal)campos[OrdenesServicioService.AutonumeracionId_NombreCol];
                            else
                                throw new Exception("El talonario deseado está inactivo.");
                        }
                    }
                    else
                        row.IsAUTONUMERACION_IDNull = true;

                    if (campos.Contains(OrdenesServicioService.NroComprobante_NombreCol))
                        row.NRO_COMPROBANTE = (string)campos[OrdenesServicioService.NroComprobante_NombreCol];


                    if (campos.Contains(OrdenesServicioService.Titulo_NombreCol))
                        row.TITULO = (string)campos[OrdenesServicioService.Titulo_NombreCol];
                    else
                        row.TITULO = string.Empty;

                    if (campos.Contains(OrdenesServicioService.Descripcion_NombreCol))
                        row.DESCRIPCION = (string)campos[OrdenesServicioService.Descripcion_NombreCol];
                    else
                        row.DESCRIPCION = string.Empty;

                    if (campos.Contains(OrdenesServicioService.FechaInicio_NombreCol))
                        row.FECHA_INICIO = (DateTime)campos[OrdenesServicioService.FechaInicio_NombreCol];
                    else
                        row.IsFECHA_INICIONull = true;

                    if (campos.Contains(OrdenesServicioService.FechaFin_NombreCol))
                        row.FECHA_FIN = (DateTime)campos[OrdenesServicioService.FechaFin_NombreCol];
                    else
                        row.IsFECHA_FINNull = true;

                    if (campos.Contains(OrdenesServicioService.CasoOriginarioId_NombreCol))
                        row.CASO_ORIGINARIO_ID = (decimal)campos[OrdenesServicioService.CasoOriginarioId_NombreCol];

                    if (campos.Contains(OrdenesServicioService.CondicionPagoId_NombreCol))
                        row.CONDICION_PAGO_ID = (decimal)campos[OrdenesServicioService.CondicionPagoId_NombreCol];

                    if (campos.Contains(OrdenesServicioService.CentroCostosId_NombreCol))
                        row.CENTRO_COSTO_ID = (decimal)campos[OrdenesServicioService.CentroCostosId_NombreCol];
                    else
                        row.IsCENTRO_COSTO_IDNull = true;

                    if (campos.Contains(OrdenesServicioService.RequiereAnticipo_NombreCol))
                        row.ANTICIPO_REQUERIDO = (string)campos[OrdenesServicioService.RequiereAnticipo_NombreCol];
                    else
                        row.ANTICIPO_REQUERIDO = Definiciones.SiNo.No;

                    if (row.ANTICIPO_REQUERIDO.Equals(Definiciones.SiNo.Si))
                    {
                        if (campos.Contains(OrdenesServicioService.MontoAnticipo_NombreCol))
                            row.ANTICIPO_MONTO = (decimal)campos[OrdenesServicioService.MontoAnticipo_NombreCol];
                        else
                            row.ANTICIPO_MONTO = 0;
                    }
                    else
                    {
                        row.ANTICIPO_MONTO = 0;
                    }

                    if (campos.Contains(OrdenesServicioService.FacturaDetallada_NombreCol))
                        row.FACTURA_DETALLADA = (string)campos[OrdenesServicioService.FacturaDetallada_NombreCol];   

                    if (campos.Contains(OrdenesServicioService.GenerarAnticipo_NombreCol))
                        row.ANTICIPO_GENERAR = (string)campos[OrdenesServicioService.GenerarAnticipo_NombreCol];
                    else
                        row.ANTICIPO_GENERAR = Definiciones.SiNo.No;

                    if (campos.Contains(OrdenesServicioService.AplicarRetencion_NombreCol))
                        row.APLICAR_RETENCION = (string)campos[OrdenesServicioService.AplicarRetencion_NombreCol];

                    if (insertarNuevo)
                        sesion.Db.ORDENES_SERVICIOCollection.Insert(row);
                    else
                        sesion.Db.ORDENES_SERVICIOCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                    if (!row.IsFECHA_INICIONull)
                        camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA_INICIO);
                    if (!row.IsPERSONA_IDNull)
                        camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                    if (!row.IsPROVEEDOR_IDNull)
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
                    ORDENES_SERVICIORow pedido = sesion.Db.ORDENES_SERVICIOCollection.GetByCASO_ID(caso_id)[0];

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Se obtienen los detalles del caso a ser borrados.
                    DataTable detalles = OrdenesServicioDetalleService.GetOrdenesServicioDetalleDataTable(OrdenesServicioDetalleService.OrdenServicioId_NombreCol + " = " + pedido.ID, string.Empty);

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
                        sesion.Db.ORDENES_SERVICIOCollection.DeleteByCASO_ID(caso_id);
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

        #region BorrarCondicionPago
        public static void BorrarCondicionPago(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    ORDENES_SERVICIORow rowPedido = sesion.Db.ORDENES_SERVICIOCollection.GetByCASO_ID(caso_id)[0];
                    rowPedido.IsCONDICION_PAGO_IDNull = true;
                    sesion.Db.ORDENES_SERVICIOCollection.Update(rowPedido);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion BorrarCondicionPago

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ORDENES_SERVICIO"; }
        }
        public static string Nombre_Vista
        {
            get { return "ordenes_servicio_info_completa"; }
        }

        public static string AutonumeracionId_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.CASO_IDColumnName; }
        }
        public static string CasoOriginarioId_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.CASO_ORIGINARIO_IDColumnName; }
        }
        public static string DebeFacturar_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.DEBE_FACTURARColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.DESCRIPCIONColumnName; }
        }
        public static string EsParaCliente_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.ES_PARA_CLIENTEColumnName; }
        }
        public static string FechaFin_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.FECHA_FINColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.FECHA_INICIOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.PERSONA_IDColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.PROVEEDOR_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.SUCURSAL_IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string Titulo_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.TITULOColumnName; }
        }
        public static string CondicionPagoId_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.CONDICION_PAGO_IDColumnName; }
        }
        public static string CentroCostosId_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string VistoBuenoFuncionario_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.VISTO_BUENO_FUNCIONARIOColumnName; }
        }
        public static string VistoBuenoGerencia_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.VISTO_BUENO_GERENCIAColumnName; }
        }
        public static string VistoBuenoPersona_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.VISTO_BUENO_PERSONAColumnName; }
        }
        public static string RequiereAnticipo_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.ANTICIPO_REQUERIDOColumnName; }
        }
        public static string MontoAnticipo_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.ANTICIPO_MONTOColumnName; }
        }
        public static string GenerarAnticipo_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.ANTICIPO_GENERARColumnName; }
        }
        public static string AplicarRetencion_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.APLICAR_RETENCIONColumnName; }
        }
        public static string FacturaDetallada_NombreCol
        {
            get { return ORDENES_SERVICIOCollection.FACTURA_DETALLADAColumnName; }
        }
        public static string VistaAutonumeracionTimbrado_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.AUTONUMERACION_TIMBRADOColumnName; }
        }
        public static string VistaCasoOriginarioFlujoDescr_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.CASO_ORIGINARIO_FLUJO_DESCColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCasoFechaCreacion_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.CASO_FECHA_CREACIONColumnName; }
        }
        public static string VistaCasoOriginarioFlujoId_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.CASO_ORIGINARIO_FLUJO_IDColumnName; }
        }
        public static string VistaEntidadId_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.ENTIDAD_IDColumnName; }
        }
        public static string VistaHoraFin_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.HORA_FINColumnName; }
        }
        public static string VistaHoraInicio_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.HORA_INICIOColumnName; }
        }
        public static string VistaPersonaNombreCompleto_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaProveedorRazonSocial_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.PROVEEDOR_RAZON_SOCIALColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaTextoPredefinido_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.TEXTO_PREDEFINIDOColumnName; }
        }
        public static string VistaTieneCasoConsideradoPago_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.TIENE_CASO_CONSIDERADO_PAGOColumnName; }
        }
        public static string VistaTipoTextoPredefinido_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.TIPO_TEXTO_PREDEFINIDO_NOMBREColumnName; }
        }
        public static string VistaCondicionPagoNombre_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.CONDICION_PAGO_NOMBREColumnName; }
        }
        public static string VistaCentroCostosNombre_NombreCol
        {
            get { return ORDENES_SERVICIO_INFO_COMPLETACollection.CENTRO_COSTOS_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
