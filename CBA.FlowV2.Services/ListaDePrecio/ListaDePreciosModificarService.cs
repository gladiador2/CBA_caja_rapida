#region Using
using System;
using System.Data;
using System.Collections;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using System.Collections.Generic;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Articulos;

#endregion Using

namespace CBA.FlowV2.Services.ListaDePrecio
{
    public class ListaDePreciosModificarService : FlujosServiceBaseWorkaround
    {
        //Falta modificar el precio cuando se pasa a aprobado
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.MODIFICAR_LISTA_PRECIOS;
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
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, drDetalle[ListaDePreciosModificarDetallesService.ArticuloId_NombreCol]);
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
                LISTA_PRECIOS_MODIFICARRow cabeceraRow = sesion.Db.LISTA_PRECIOS_MODIFICARCollection.GetByCASO_ID(caso_id)[0];
                DataTable dtDetalles = (new ListaDePreciosModificarDetallesService()).GetListaDePreciosModificarDetallesInfoCompleta(ListaDePreciosModificarDetallesService.ListaPreciosModificarId_NombreCol + " = " + cabeceraRow.ID, ListaDePreciosModificarDetallesService.Id_NombreCol);
                ListasDePrecioDetalleService listaPreciosDetalle = new ListasDePrecioDetalleService();

                //Borrador a Anulado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna accion.

                    exito = true;
                    revisarRequisitos = true;
                }
                //Pendiente a anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna accion.

                    exito = true;
                    revisarRequisitos = true;
                }
                //Borrador a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Se genera la numeracion, si todavia no existe.

                    exito = true;
                    revisarRequisitos = true;

                    if (dtDetalles.Rows.Count <= 0)
                    {
                        mensaje = "El caso no tiene detalles.";
                        exito = false;
                    }

                    #region Generar numeracion
                    if (exito && (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Length <= 0))
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
                    #endregion Generar numeracion
                }
                //Pendiente a Aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones:
                    //Se modifica el precio de los articulos para la lista de precios en especifico
                    Hashtable campos;
                    decimal margenRentabilidadMinimo = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.MargenRentabilidad);
                    DataTable dtSucursalesAfectadas = null;

                    exito = true;
                    revisarRequisitos = true;

                    //Se controla que todos los detalles tengan un margen de rentabilidad 
                    //mayor al indicado por la variable de sistema
                    if (!Interprete.EsNullODBNull(cabeceraRow.SUCURSALES_ID))
                        dtSucursalesAfectadas = getSucursalesAfectadas(cabeceraRow.SUCURSALES_ID.ToString());
                    else
                        dtSucursalesAfectadas = getSucursalesAfectadas(string.Empty);

                    for (int i = 0; i < dtDetalles.Rows.Count; i++)
                    {
                        if ((decimal)dtDetalles.Rows[i][ListaDePreciosModificarDetallesService.MargenRentabilidad_NombreCol] < margenRentabilidadMinimo)
                            throw new Exception("El margen de rentabilidad es menor al mínimo permitido.");

                        #region actualizarlistasdeprecios
                        //si en la cabecera se indican ciertas sucursales

                        for (int k = 0; k < dtSucursalesAfectadas.Rows.Count; k++)
                        {
                            campos = new Hashtable();

                            if (!Interprete.EsNullODBNull(dtSucursalesAfectadas.Rows[k][SucursalesService.Id_NombreCol]))
                                campos.Add(ListasDePrecioDetalleService.SucursalId_NombreCol, dtSucursalesAfectadas.Rows[k][SucursalesService.Id_NombreCol]);
                            // la lista de precio recibida es una la lista base, definida como variable de sistema y seleccionada en el flujo
                            // las otras listas de precios se actualizan, cuando se pasa true a listaPreciosDetalle.Guardar(campos, actualizarTodasLasListas, sesion);
                            campos.Add(ListasDePrecioDetalleService.ListaPrecioId_NombreCol, cabeceraRow.LISTA_PRECIOS_ID);
                            campos.Add(ListasDePrecioDetalleService.ArticuloId_NombreCol, dtDetalles.Rows[i][ListaDePreciosModificarDetallesService.ArticuloId_NombreCol]);
                            campos.Add(ListasDePrecioDetalleService.Precio_NombreCol, (decimal)dtDetalles.Rows[i][ListaDePreciosModificarDetallesService.PrecioNuevo_NombreCol]);
                            campos.Add(ListasDePrecioDetalleService.CantidadMinima_NombreCol, (decimal)dtDetalles.Rows[i][ListaDePreciosModificarDetallesService.CantidadMinima_NombreCol]);
                            campos.Add(ListasDePrecioDetalleService.DescuentoMaximo_NombreCol, (decimal)dtDetalles.Rows[i][ListaDePreciosModificarDetallesService.DescuentoMaximo_NombreCol]);
                            campos.Add(ListasDePrecioDetalleService.FechaInicio_NombreCol, dtDetalles.Rows[i][ListaDePreciosModificarDetallesService.FechaInicio_NombreCol]);
                            campos.Add(ListasDePrecioDetalleService.FechaFin_NombreCol, dtDetalles.Rows[i][ListaDePreciosModificarDetallesService.FechaFin_NombreCol]);
                            campos.Add(ListasDePrecioDetalleService.Estado_NombreCol, Definiciones.Estado.Activo);

                           // listaPreciosDetalle.InactivarRegistrosDePrecios(campos, sesion);
                            bool actualizarTodasLasListas = true;
                            listaPreciosDetalle.Guardar(campos, actualizarTodasLasListas, sesion);
                        }
                        // si en la cabecera no se indica sucursal, entonces id sucursal null
                        if (dtSucursalesAfectadas.Rows.Count == 0)
                        {
                            campos = new Hashtable();
                            // la lista de precio recibida es la lista base
                            // las otras listas de precios se actualizan, cuando se pasa true a listaPreciosDetalle.Guardar(campos, actualizarTodasLasListas, sesion);
                            campos.Add(ListasDePrecioDetalleService.ListaPrecioId_NombreCol, cabeceraRow.LISTA_PRECIOS_ID);
                            campos.Add(ListasDePrecioDetalleService.ArticuloId_NombreCol, dtDetalles.Rows[i][ListaDePreciosModificarDetallesService.ArticuloId_NombreCol]);
                            campos.Add(ListasDePrecioDetalleService.Precio_NombreCol, (decimal)dtDetalles.Rows[i][ListaDePreciosModificarDetallesService.PrecioNuevo_NombreCol]);
                            campos.Add(ListasDePrecioDetalleService.CantidadMinima_NombreCol, (decimal)dtDetalles.Rows[i][ListaDePreciosModificarDetallesService.CantidadMinima_NombreCol]);
                            campos.Add(ListasDePrecioDetalleService.DescuentoMaximo_NombreCol, (decimal)dtDetalles.Rows[i][ListaDePreciosModificarDetallesService.DescuentoMaximo_NombreCol]);
                            campos.Add(ListasDePrecioDetalleService.FechaInicio_NombreCol, dtDetalles.Rows[i][ListaDePreciosModificarDetallesService.FechaInicio_NombreCol]);
                            campos.Add(ListasDePrecioDetalleService.FechaFin_NombreCol, dtDetalles.Rows[i][ListaDePreciosModificarDetallesService.FechaFin_NombreCol]);
                            campos.Add(ListasDePrecioDetalleService.Estado_NombreCol, Definiciones.Estado.Activo);

                          //  listaPreciosDetalle.InactivarRegistrosDePrecios(campos, sesion);

                            listaPreciosDetalle.Guardar(campos, true, sesion);
                        }
                        #endregion actualizarlistasdeprecios

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
                    sesion.Db.LISTA_PRECIOS_MODIFICARCollection.Update(cabeceraRow);
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
            LISTA_PRECIOS_MODIFICARRow row = sesion.Db.LISTA_PRECIOS_MODIFICARCollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE;
        }

        #endregion Implementacion de metodos abstract

        #region GetListaPreciosModificarDataTable
        /// <summary>
        /// Gets the lista precios modificar data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetListaPreciosModificarDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.LISTA_PRECIOS_MODIFICARCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetListaPreciosModificarDataTable

        #region GetListaPreciosModificarInfoCompleta
        /// <summary>
        /// Gets the lista precios modificar info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetListaPreciosModificarInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.LISTA_PRECIOS_MODIF_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetListaPreciosModificarInfoCompleta

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        public bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                LISTA_PRECIOS_MODIFICARRow row = new LISTA_PRECIOS_MODIFICARRow();
                LISTA_PRECIOS_MODIFICAR_DETRow r = new LISTA_PRECIOS_MODIFICAR_DETRow();

                try
                {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(sesion.Usuario.SUCURSAL_ACTIVA_ID.ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.MODIFICAR_LISTA_PRECIOS.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("lista_precios_modificar_sqc");
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                        row.ENTIDAD_ID = sesion.Usuario.ENTIDAD_ID;

                    }
                    else
                    {
                        row = sesion.Db.LISTA_PRECIOS_MODIFICARCollection.GetRow(ListaDePreciosModificarService.Id_NombreCol + " = " + campos[ListaDePreciosModificarService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    if (campos.Contains(ListaDePreciosModificarService.SucursalesID_NombreCol))
                        row.SUCURSALES_ID = campos[ListaDePreciosModificarService.SucursalesID_NombreCol].ToString();
                    else
                        row.SUCURSALES_ID = string.Empty;


                    row.FECHA = (DateTime)campos[ListaDePreciosModificarService.Fecha_NombreCol];

                    row.AUTONUMERACION_ID = (decimal)campos[ListaDePreciosModificarService.AutonumeracionId_NombreCol];

                    if (row.LISTA_PRECIOS_ID != (decimal)campos[ListaDePreciosModificarService.ListaPreciosId_NombreCol])
                    {
                        ListasDePrecioService lista = new ListasDePrecioService();
                        DataTable dtLista = lista.GetListasDePrecioDataTable(campos[ListaDePreciosModificarService.ListaPreciosId_NombreCol].ToString());

                        row.LISTA_PRECIOS_ID = (decimal)dtLista.Rows[0][ListasDePrecioService.Id_NombreCol];
                        row.MONEDA_ID = (decimal)dtLista.Rows[0][ListasDePrecioService.MonedaId_NombreCol];

                        row.COTIZACION = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(sesion.Usuario.SUCURSAL_ACTIVA_ID), row.MONEDA_ID, row.FECHA, sesion);
                        if (row.COTIZACION.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("La cotización debe ser actualizada.");
                    }

                    row.OBSERVACION = (string)campos[ListaDePreciosModificarService.Observacion_NombreCol];

                    if (insertarNuevo) sesion.Db.LISTA_PRECIOS_MODIFICARCollection.Insert(row);
                    else sesion.Db.LISTA_PRECIOS_MODIFICARCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
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


        public static DataTable getSucursalesAfectadas(decimal ArticuloId)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = new DataTable();
                string query = string.Empty;

                query = "select s.id, am.articulos_id, am.lista_precios_id, am.sucursales_id, am.porcentaje, am.fecha_inicio, am.fecha_fin, am.fecha_creacion, am.estado from articulos_margen_rentabilidad am, sucursales s\n" +
                    "where s.id(+) = am.sucursales_id \n" +
                    "and am.articulos_id = " + ArticuloId;
                dt = sesion.Db.EjecutarQuery(query);

                return dt;
            }
        }
        public static DataTable getSucursalesAfectadas(string idSucursales)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = new DataTable();
                string clausulas = string.Empty;
                if (idSucursales != string.Empty)
                    clausulas = SucursalesService.Id_NombreCol + " in ( " + idSucursales + " )";
                else
                    clausulas = " 1 = 0";
                // return null;
                dt = sesion.Db.SUCURSALES_INFO_COMPLETACollection.GetAsDataTable(clausulas, SucursalesService.Nombre_NombreCol);

                return dt;
            }
        }

        #region GenerarNumeroComprobante
        /// <summary>
        /// Generars the numero comprobante.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        private string GenerarNumeroComprobante(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                LISTA_PRECIOS_MODIFICARRow cabeceraRow = sesion.Db.LISTA_PRECIOS_MODIFICARCollection.GetByCASO_ID(caso_id)[0];

                string nroComprobante = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, sesion);

                //Controlar que se logro asignar una numeracion
                if (nroComprobante.Equals(""))
                {
                    throw new Exception("No se pudo asignar una numeración válida");
                }
                return nroComprobante;
            }
        }
        #endregion GenerarNumeroComprobante

        #region Borrar
        /// <summary>
        /// Borra de la base de datos el caso y la cabecera del flujo
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public bool Borrar(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    bool exito = true;
                    String mensaje = "Error.";

                    //Se obtienen el caso y la factura a ser borrados
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    LISTA_PRECIOS_MODIFICARRow cabecera = sesion.Db.LISTA_PRECIOS_MODIFICARCollection.GetByCASO_ID(caso_id)[0];
                    ListaDePreciosModificarDetallesService listaPrecioMidificarDet = new ListaDePreciosModificarDetallesService();

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    if (exito)
                    {
                        DataTable dtDetalles = listaPrecioMidificarDet.GetListaDePreciosModificarDetallesDataTable(ListaDePreciosModificarDetallesService.ListaPreciosModificarId_NombreCol + " = " + cabecera.ID, string.Empty);
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                            listaPrecioMidificarDet.Borrar((decimal)dtDetalles.Rows[i][ListaDePreciosModificarDetallesService.Id_NombreCol]);
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.LISTA_PRECIOS_MODIFICARCollection.DeleteByCASO_ID(caso_id);
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
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "LISTA_PRECIOS_MODIFICAR"; }
        }
        public static string Nombre_Vista
        {
            get { return "lista_precios_modif_info_comp"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return LISTA_PRECIOS_MODIFICARCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return LISTA_PRECIOS_MODIFICARCollection.CASO_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return LISTA_PRECIOS_MODIFICARCollection.COTIZACIONColumnName; }
        }
        public static string EntidadId_NombreCol
        {
            get { return LISTA_PRECIOS_MODIFICARCollection.ENTIDAD_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return LISTA_PRECIOS_MODIFICARCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return LISTA_PRECIOS_MODIFICARCollection.IDColumnName; }
        }
        public static string ListaPreciosId_NombreCol
        {
            get { return LISTA_PRECIOS_MODIFICARCollection.LISTA_PRECIOS_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return LISTA_PRECIOS_MODIFICARCollection.MONEDA_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return LISTA_PRECIOS_MODIFICARCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return LISTA_PRECIOS_MODIFICARCollection.OBSERVACIONColumnName; }
        }
        public static string SucursalesID_NombreCol
        {
            get { return LISTA_PRECIOS_MODIFICARCollection.SUCURSALES_IDColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return LISTA_PRECIOS_MODIF_INFO_COMPCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaListaPreciosNombre_NombreCol
        {
            get { return LISTA_PRECIOS_MODIF_INFO_COMPCollection.LISTA_PRECIOS_NOMBREColumnName; }
        }
        public static string VistaMonedaId_NombreCol
        {
            get { return LISTA_PRECIOS_MODIF_INFO_COMPCollection.MONEDA_IDColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return LISTA_PRECIOS_MODIF_INFO_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return LISTA_PRECIOS_MODIF_INFO_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        #endregion Accessors
    }
}
