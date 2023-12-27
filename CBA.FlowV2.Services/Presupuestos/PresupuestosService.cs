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
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Tramites;
#endregion Using

namespace CBA.FlowV2.Services.Presupuestos
{
    public class PresupuestosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.PRESUPUESTOS;
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
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, drCabecera[Presupuestos.PresupuestosService.TextoPredefinidoFueroId_NombreCol]);
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
                mensaje = string.Empty;
                try
                {
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    PRESUPUESTOSRow cabeceraRow = sesion.Db.PRESUPUESTOSCollection.GetByCASO_ID(caso_id)[0];
                    PRESUPUESTOS_ETAPASRow etapaRow = sesion.Db.PRESUPUESTOS_ETAPASCollection.GetByPRESUPUESTO_ID(cabeceraRow.ID)[0];
                    PRESUPUESTOS_DETALLERow[] detallesRows = sesion.Db.PRESUPUESTOS_DETALLECollection.GetByPRESUPUESTO_ETAPA_ID(etapaRow.ID);
                    
                    //Verificar si se cumplen los requisitos
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                    if (!exito)
                        throw new Exception("Requisitos no cumplidos.");

                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Ninguna.
                        exito = true;
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //Crear el numero de comprobante si no existe y la autonumeracion esta siendo utilizada.
                        exito = true;

                        #region generar autonumeracion
                        //Si no existe un comprobante se crea
                        if (cabeceraRow.NRO_COMPROBANTE == null)
                        {
                            if (cabeceraRow.IsAUTONUMERACION_IDNull)
                                throw new Exception("Debe indicarse el talonario o un número de comprobante de forma manual.");

                            cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID);
                            
                            //Controlar que se logro asignar una numeracion
                            if (cabeceraRow.NRO_COMPROBANTE.Equals(string.Empty))
                            {
                                exito = false;
                                mensaje = "No se pudo asignar una numeración válida";
                            }
                        }
                        #endregion generar autonumeracion
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
                        //Ninguna
                        exito = true;
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Rechazado))
                    {
                        //Acciones
                        //Verificar que el caso tiene numero de comprobante
                        exito = true;

                        //Controlar que se logro asignar una numeracion
                        if (cabeceraRow.NRO_COMPROBANTE.Equals(string.Empty))
                        {
                            exito = false;
                            mensaje = "Debe indicar el número de comprobante.";
                        }
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //Verificar que el caso tiene numero de comprobante
                        exito = true;

                        #region generar autonumeracion
                        //Si no existe un comprobante se crea
                        if (cabeceraRow.NRO_COMPROBANTE == null)
                        {
                            if (cabeceraRow.IsAUTONUMERACION_IDNull)
                                throw new Exception("Debe indicarse el talonario o un número de comprobante de forma manual.");

                            cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID);

                            //Controlar que se logro asignar una numeracion
                            if (cabeceraRow.NRO_COMPROBANTE.Equals(string.Empty))
                            {
                                exito = false;
                                mensaje = "No se pudo asignar una numeración válida";
                            }
                        }
                        #endregion generar autonumeracion

                        #region crear orden de servicio
                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.PresupuestosGenerarOrdenDeServicio) == Definiciones.SiNo.Si)
                        {
                            decimal caso_orden_servicio_creado_id = 0;
                            string estado_orden_servicio = string.Empty;
                            decimal orden_servicio_id = 0;                           
                            DataTable dtOrdenServicioCreado;
                            Hashtable campos = new Hashtable();
                            Hashtable camposDet = new Hashtable();

                            campos.Add(OrdenesServicioService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ID);
                            campos.Add(OrdenesServicioService.PersonaId_NombreCol, cabeceraRow.PERSONA_ID);
                            campos.Add(OrdenesServicioService.Descripcion_NombreCol, cabeceraRow.OBJETO);
                            campos.Add(OrdenesServicioService.TextoPredefinidoId_NombreCol, 228);
                            campos.Add(OrdenesServicioService.CasoOriginarioId_NombreCol, cabeceraRow.CASO_ID);
                            campos.Add(OrdenesServicioService.DebeFacturar_NombreCol, Definiciones.SiNo.No);
                            campos.Add(OrdenesServicioService.VistoBuenoFuncionario_NombreCol, Definiciones.SiNo.No);
                            campos.Add(OrdenesServicioService.VistoBuenoGerencia_NombreCol, Definiciones.SiNo.No);
                            campos.Add(OrdenesServicioService.VistoBuenoPersona_NombreCol, Definiciones.SiNo.No);
                            campos.Add(OrdenesServicioService.EsParaCliente_NombreCol, Definiciones.SiNo.Si);

                            OrdenesServicioService.Guardar(campos, true, ref caso_orden_servicio_creado_id, ref estado_orden_servicio);
                            dtOrdenServicioCreado = OrdenesServicioService.GetOrdenesServicioDataTable(OrdenesServicioService.CasoId_NombreCol + " = " + caso_orden_servicio_creado_id, string.Empty, sesion);
                            orden_servicio_id = (decimal)dtOrdenServicioCreado.Rows[0][OrdenesServicioService.Id_NombreCol];

                            foreach (PRESUPUESTOS_DETALLERow detalle in detallesRows)
                            {
                                camposDet.Clear();
                                camposDet.Add(OrdenesServicioDetalleService.OrdenServicioId_NombreCol, orden_servicio_id);
                                if (!detalle.IsARTICULO_IDNull)
                                {
                                    camposDet.Add(OrdenesServicioDetalleService.ArticuloId_NombreCol, detalle.ARTICULO_ID);
                                    camposDet.Add(OrdenesServicioDetalleService.UnidadId_NombreCol, detalle.UNIDAD_MEDIDA);
                                }
                                camposDet.Add(OrdenesServicioDetalleService.Descripcion_NombreCol, detalle.OBSERVACION);
                                camposDet.Add(OrdenesServicioDetalleService.CantidadHoras_NombreCol, detalle.CANTIDAD_UNIDADES);
                                camposDet.Add(OrdenesServicioDetalleService.ImpuestoId_NombreCol, detalle.IMPUESTO_ID);
                                camposDet.Add(OrdenesServicioDetalleService.TotalImpuestoMonto_NombreCol, detalle.MONTO_IMPUESTO);
                                camposDet.Add(OrdenesServicioDetalleService.Costo_Unitario_NombreCol, detalle.MONTO_BRUTO_UNITARIO);
                                camposDet.Add(OrdenesServicioDetalleService.Precio_NombreCol, detalle.CANTIDAD_UNITARIA_TOTAL * detalle.MONTO_BRUTO_UNITARIO * (100 - detalle.PORCENTAJE_DESC) / 100);
                                camposDet.Add(OrdenesServicioDetalleService.CostoTotal_NombreCol, detalle.CANTIDAD_UNITARIA_TOTAL * detalle.MONTO_BRUTO_UNITARIO * (100 - detalle.PORCENTAJE_DESC) / 100);
                                camposDet.Add(OrdenesServicioDetalleService.MonedaId_NombreCol, cabeceraRow.MONEDA_ID);
                                camposDet.Add(OrdenesServicioDetalleService.Cotizacion_NombreCol, cabeceraRow.COTIZACION);
                                camposDet.Add(OrdenesServicioDetalleService.EstadoId_NombreCol, Definiciones.EstadosFlujos.Pendiente); 

                                OrdenesServicioDetalleService.Guardar(camposDet, true);   
                            }

                            //se guarda en la tabla ordenes_servicio_casos_asoc                                                                  
                            System.Collections.Hashtable camposRelaciones = new System.Collections.Hashtable();
                            camposRelaciones.Add(OrdenesServicioCasosAsociadosService.OrdenServicioId_NombreCol, orden_servicio_id);
                            camposRelaciones.Add(OrdenesServicioCasosAsociadosService.CasoId_NombreCol, cabeceraRow.CASO_ID);
                            camposRelaciones.Add(OrdenesServicioCasosAsociadosService.Observacion_NombreCol, cabeceraRow.OBJETO);
                            camposRelaciones.Add(OrdenesServicioCasosAsociadosService.ConsiderarComoPago_NombreCol, Definiciones.SiNo.No);
                            camposRelaciones.Add(OrdenesServicioCasosAsociadosService.FechaAgregado_NombreCol, DateTime.Now);
                            camposRelaciones.Add(OrdenesServicioCasosAsociadosService.Editable_NombreCol, Definiciones.SiNo.No);

                            OrdenesServicioCasosAsociadosService.Guardar(camposRelaciones, true, sesion);                            
                        }
                        #endregion crear orden de servicio
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Rechazado))
                    {
                        //Acciones
                        //Ninguna
                        exito = true;
                    } 
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Vigente))
                    {
                        //Acciones
                        //Ninguna
                        exito = true;
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Vigente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //Ninguna
                        exito = true;
                    }
                    
                    if (exito)
                    {
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.PRESUPUESTOSCollection.Update(cabeceraRow);
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
            PRESUPUESTOSRow cabeceraRow = sesion.Db.PRESUPUESTOSCollection.GetByCASO_ID(caso_id)[0];
            return cabeceraRow.NRO_COMPROBANTE;
        }

        #endregion Implementacion de metodos abstract

        #region GetPresupuestosDataTable
        /// <summary>
        /// Gets the presupuestos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPresupuestosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PRESUPUESTOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPresupuestosDataTable

        #region GetPresupuestosInfoCompleta
        /// <summary>
        /// Gets the presupuestos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPresupuestosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PRESUPUESTOS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPresupuestosInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.BeginTransaction();
                try
                {
                    PRESUPUESTOSRow row = new PRESUPUESTOSRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("presupuestos_sqc");
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[PresupuestosService.SucursalId_NombreCol].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.PRESUPUESTOS.ToString()),
                                                             int.Parse(sesion.Usuario_Id.ToString()),
                                                             SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.SUCURSAL_ID = (decimal)campos[PresupuestosService.SucursalId_NombreCol]; //Una vez creado el caso no puede modificarse la sucursal
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.PRESUPUESTOSCollection.GetRow(PresupuestosService.Id_NombreCol + " = " + campos[PresupuestosService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.OBJETO = (string)campos[PresupuestosService.Objeto_NombreCol];

                    if (campos.Contains(PresupuestosService.TextoPredefinidoTipoId_NombreCol))
                        row.TEXTO_PREDEFINIDO_TIPO_ID = (decimal)campos[PresupuestosService.TextoPredefinidoTipoId_NombreCol];

                    if (campos.Contains(PresupuestosService.TramitesTiposId_NombreCol))
                        row.TRAMITES_TIPOS_ID = (decimal)campos[PresupuestosService.TramitesTiposId_NombreCol];

                    if (row.FUNCIONARIO_ID.Equals(System.DBNull.Value) || row.FUNCIONARIO_ID != (decimal)campos[PresupuestosService.FuncionarioId_NombreCol])
                    {
                        row.FUNCIONARIO_ID = (decimal)campos[PresupuestosService.FuncionarioId_NombreCol];
                        if (!FuncionariosService.EstaActivo(row.FUNCIONARIO_ID))
                            throw new Exception(Traducciones.El_funcionario_esta_inactivo);
                    }

                    if (row.PERSONA_ID.Equals(System.DBNull.Value) || row.PERSONA_ID != (decimal)campos[PresupuestosService.PersonaId_NombreCol])
                    {
                        row.PERSONA_ID = (decimal)campos[PresupuestosService.PersonaId_NombreCol];
                        if (!PersonasService.EstaActivo(row.PERSONA_ID))
                            throw new Exception(Traducciones.La_persona_esta_inactiva);
                    }

                    if (campos.Contains(PresupuestosService.AutonumeracionId_NombreCol))
                    {
                        if (row.IsAUTONUMERACION_IDNull || row.AUTONUMERACION_ID != (decimal)campos[PresupuestosService.AutonumeracionId_NombreCol])
                        {
                            if (AutonumeracionesService.EstaActivo((decimal)campos[PresupuestosService.AutonumeracionId_NombreCol]))
                                row.AUTONUMERACION_ID = (decimal)campos[PresupuestosService.AutonumeracionId_NombreCol];
                            else
                                throw new Exception("El talonario está inactivo.");
                        }
                    }
                    else
                        row.IsAUTONUMERACION_IDNull = true;

                    if (campos.Contains(PresupuestosService.NroComprobante_NombreCol))
                        row.NRO_COMPROBANTE = (string)campos[PresupuestosService.NroComprobante_NombreCol];
                    else
                        row.NRO_COMPROBANTE = string.Empty;

                    if (campos.Contains(PresupuestosService.TextoPredefinidoFueroId_NombreCol))
                        row.TEXTO_PREDEFINIDO_FUERO_ID = (decimal)campos[PresupuestosService.TextoPredefinidoFueroId_NombreCol];
                    else
                        row.IsTEXTO_PREDEFINIDO_FUERO_IDNull = true;

                    if (campos.Contains(PresupuestosService.CasoOrigenId_NombreCol) && ((string)campos[PresupuestosService.CasoOrigenId_NombreCol]).Length > 0)
                        row.CASO_ORIGEN_ID = decimal.Parse((string)campos[PresupuestosService.CasoOrigenId_NombreCol]);
                    else
                        row.IsCASO_ORIGEN_IDNull = true;

                    if (campos.Contains(PresupuestosService.FechaAprobacion_NombreCol))
                        row.FECHA_APROBACION = (DateTime)campos[PresupuestosService.FechaAprobacion_NombreCol];
                    else
                        row.IsFECHA_APROBACIONNull = true;

                    if (campos.Contains(PresupuestosService.FechaEntrega_NombreCol))
                        row.FECHA_ENTREGA = (DateTime)campos[PresupuestosService.FechaEntrega_NombreCol];
                    else
                        row.IsFECHA_ENTREGANull = true;

                    row.FECHA_CREACION = (DateTime)campos[PresupuestosService.FechaCreacion_NombreCol];
                    row.FECHA_VALIDEZ = (DateTime)campos[PresupuestosService.FechaValidez_NombreCol];

                    if (row.FECHA_VALIDEZ < row.FECHA_CREACION)
                        throw new Exception("La fecha de validez debe ser posterior a la de creación.");

                    if (row.MONEDA_ID.Equals(System.DBNull.Value) || row.MONEDA_ID != (decimal)campos[PresupuestosService.MonedaId_NombreCol])
                    {
                        if (MonedasService.EstaActivo((decimal)campos[PresupuestosService.MonedaId_NombreCol]))
                        {
                            row.MONEDA_ID = (decimal)campos[PresupuestosService.MonedaId_NombreCol];
                            row.COTIZACION = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, row.FECHA_CREACION, sesion);

                            if (row.COTIZACION.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                throw new Exception("Debe actualizarse la cotización de la moneda.");
                        }
                        else
                        {
                            throw new Exception("La moneda deseada no está activa.");
                        }
                    }

                    if (campos.Contains(PresupuestosService.Observacion_NombreCol))
                        row.OBSERVACION = (string)campos[PresupuestosService.Observacion_NombreCol];
                    else
                        row.OBSERVACION = string.Empty;

                    if (campos.Contains(PresupuestosService.Persona_Garante_1_Id_NombreCol)) 
                        row.PERSONA_GARANTE_1_ID = (decimal)campos[PresupuestosService.Persona_Garante_1_Id_NombreCol];
                    else
                        row.IsPERSONA_GARANTE_1_IDNull = true;

                    if ((campos.Contains(PresupuestosService.NroComprobanteExterno_NombreCol) && ((string)campos[PresupuestosService.NroComprobanteExterno_NombreCol]).Length > 0))
                        row.NRO_COMPROBANTE_EXTERNO = (string)campos[PresupuestosService.NroComprobanteExterno_NombreCol];
                    else
                        row.NRO_COMPROBANTE_EXTERNO = string.Empty;

                    if (campos.Contains(PresupuestosService.VehiculosId_NombreCol))
                        row.VEHICULO_ID = (decimal)campos[PresupuestosService.VehiculosId_NombreCol];
                    else
                        row.IsVEHICULO_IDNull = true;

                    if (campos.Contains(PresupuestosService.ArticuloId_NombreCol))
                        row.ARTICULO_ID = (decimal)campos[PresupuestosService.ArticuloId_NombreCol];
                    else
                        row.IsARTICULO_IDNull = true;

                    if (campos.Contains(PresupuestosService.ArticuloMonto_NombreCol))
                        row.ARTICULO_MONTO = (decimal)campos[PresupuestosService.ArticuloMonto_NombreCol];
                    else
                        row.IsARTICULO_MONTONull = true;
                     
                    if (campos.Contains(PresupuestosService.ListaPrecioId_Nombre_NombreCol))
                         row.LISTA_PRECIO_ID = (decimal)campos[PresupuestosService.ListaPrecioId_Nombre_NombreCol];
                     else
                         row.IsLISTA_PRECIO_IDNull = true;


                    if (insertarNuevo) sesion.Db.PRESUPUESTOSCollection.Insert(row);
                    else sesion.Db.PRESUPUESTOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA_CREACION);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.NroComprobante2_NombreCol, row.NRO_COMPROBANTE_EXTERNO);
                    camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                    camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.FUNCIONARIO_ID);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    if (insertarNuevo && estado_id.Equals(Definiciones.EstadosFlujos.Borrador))
                    { 
                        if(VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.PresupuestosAvanzarBorradorAPendienteAlCrearCaso) == Definiciones.SiNo.Si)
                        {
                            string msg;
                            bool exitoCasoAsociado = (new PresupuestosService()).ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Pendiente, false, out msg, sesion);
                            if (exitoCasoAsociado)
                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Pendiente, "Transición automática al haberse creado en estado Borrador.", sesion);
                            if (exitoCasoAsociado)
                                (new PresupuestosService()).EjecutarAccionesLuegoDeCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Pendiente, sesion);
                        }
                    }

                    sesion.CommitTransaction();
                    return true;
                }
                catch (Exception)
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified caso_id.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static void Borrar(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    //Se obtienen el caso a ser borrado
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    PRESUPUESTOSRow presupuesto = sesion.Db.PRESUPUESTOSCollection.GetByCASO_ID(caso_id)[0];

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                        throw new System.ArgumentException("El caso no puede borrarse ya que debe estar en el estado borrador.");

                    //Se obtienen los detalles del caso a ser borrados.
                    DataTable dt = PresupuestosEtapasService.GetPresupuestosEtapasDataTable(PresupuestosEtapasService.PresupuestoId_NombreCol + " = " + presupuesto.ID, string.Empty);
                    for (int i = 0; i < dt.Rows.Count; i++)
                        PresupuestosEtapasService.Borrar((decimal)dt.Rows[i][PresupuestosService.Id_NombreCol]);

                    sesion.Db.PRESUPUESTOSCollection.DeleteByCASO_ID(caso_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, presupuesto.ID, presupuesto.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    (new CasosService()).Eliminar(caso_id, sesion);

                    sesion.CommitTransaction();
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
            get { return "PRESUPUESTOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "PRESUPUESTOS_INFO_COMPLETA"; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return PRESUPUESTOSCollection.ARTICULO_IDColumnName; }
        }
        public static string ArticuloMonto_NombreCol
        {
            get { return PRESUPUESTOSCollection.ARTICULO_MONTOColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return PRESUPUESTOSCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return PRESUPUESTOSCollection.CASO_IDColumnName; }
        }
        public static string CasoOrigenId_NombreCol
        {
            get { return PRESUPUESTOSCollection.CASO_ORIGEN_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return PRESUPUESTOSCollection.COTIZACIONColumnName; }
        }
        public static string FechaAprobacion_NombreCol
        {
            get { return PRESUPUESTOSCollection.FECHA_APROBACIONColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return PRESUPUESTOSCollection.FECHA_CREACIONColumnName; }
        }
        public static string FechaEntrega_NombreCol
        {
            get { return PRESUPUESTOSCollection.FECHA_ENTREGAColumnName; }
        }
        public static string FechaValidez_NombreCol
        {
            get { return PRESUPUESTOSCollection.FECHA_VALIDEZColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return PRESUPUESTOSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PRESUPUESTOSCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return PRESUPUESTOSCollection.MONEDA_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return PRESUPUESTOSCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string NroComprobanteExterno_NombreCol
        {
            get { return PRESUPUESTOSCollection.NRO_COMPROBANTE_EXTERNOColumnName; }
        }
        public static string Objeto_NombreCol
        {
            get { return PRESUPUESTOSCollection.OBJETOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return PRESUPUESTOSCollection.OBSERVACIONColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return PRESUPUESTOSCollection.PERSONA_IDColumnName; }
        }
        public static string Persona_Garante_1_Id_NombreCol
        {
            get { return PRESUPUESTOSCollection.PERSONA_GARANTE_1_IDColumnName; }
        }
        public static string Persona_Garante_2_Id_NombreCol
        {
            get { return PRESUPUESTOSCollection.PERSONA_GARANTE_2_IDColumnName; }
        }
        public static string Persona_Garante_3_Id_NombreCol
        {
            get { return PRESUPUESTOSCollection.PERSONA_GARANTE_3_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return PRESUPUESTOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string TextoPredefinidoTipoId_NombreCol
        {
            get { return PRESUPUESTOSCollection.TEXTO_PREDEFINIDO_TIPO_IDColumnName; }
        }
        public static string TextoPredefinidoFueroId_NombreCol
        {
            get { return PRESUPUESTOSCollection.TEXTO_PREDEFINIDO_FUERO_IDColumnName; }
        }
        public static string TramitesTiposId_NombreCol
        {
            get { return PRESUPUESTOSCollection.TRAMITES_TIPOS_IDColumnName; }
        }
        public static string VehiculosId_NombreCol
        {
            get { return PRESUPUESTOSCollection.VEHICULO_IDColumnName; }
        }
        public static string ListaPrecioId_Nombre_NombreCol
        {
            get { return PRESUPUESTOSCollection.LISTA_PRECIO_IDColumnName; }
        }
        public static string VistaArticuloDescripcion_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCasoFechaCreacion_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.CASO_FECHA_CREACIONColumnName; }
        }
        public static string VistaChasisNro_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.CHASIS_NROColumnName; }
        }
        public static string VistaFuncionarioNombreCompleto_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.FUNCIONARIO_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaPersonaNombreCompleto_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaSucursalPaisId_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.SUCURSAL_PAIS_IDColumnName; }
        }
        public static string VistaSucursalPaisNombre_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.SUCURSAL_PAIS_NOMBREColumnName; }
        }
        public static string VistaTextoPredefinidoIdTipo_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.TEXTO_PREDEF_ID_TIPOColumnName; }
        }
        public static string VistaTextoPredefinidoTipoNombre_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.TEXTO_PREDEF_TIPO_NOMBREColumnName; }
        }
        public static string VistaTextoPredefinidoTipoTexto_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.TEXTO_PREDEF_TIPO_TEXTOColumnName; }
        }
        public static string VistaTextoPredefinidoIdFuero_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.TEXTO_PREDEF_ID_FUEROColumnName; }
        }
        public static string VistaTextoPredefinidoFueroNombre_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.TEXTO_PREDEF_FUERO_NOMBREColumnName; }
        }
        public static string VistaTextoPredefinidoFueroTexto_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.TEXTO_PREDEF_FUERO_TEXTOColumnName; }
        }
        public static string VistaTipoUnificadoId_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.TIPO_UNIFICADO_IDColumnName; }
        }
        public static string VistaTipoUnificado_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.TIPO_UNIFICADOColumnName; }
        }
        public static string VistaTramitesTiposNombre_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.TRAMITES_TIPOS_NOMBREColumnName; }
        }
        public static string VistaTotalMontoBruto_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.TOTAL_MONTO_BRUTOColumnName; }
        }
        public static string VistaTotalMontoDescuento_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.TOTAL_MONTO_DESCUENTOColumnName; }
        }
        public static string VistaTotalMontoImpuesto_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.TOTAL_MONTO_IMPUESTOColumnName; }
        }
        public static string VistaTotalMontoNeto_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.TOTAL_MONTO_NETOColumnName; }
        }
        public static string VistaVehiculoNombre_NombreCol
        {
            get { return PRESUPUESTOS_INFO_COMPLETACollection.VEHICULO_NOMBREColumnName; }
        }
        
        #endregion Accessors
    }
}
