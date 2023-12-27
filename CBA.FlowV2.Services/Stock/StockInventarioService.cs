#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;

using System.Collections;

#endregion Using

namespace CBA.FlowV2.Services.Stock
{
    public class StockInventarioService : FlujosServiceBaseWorkaround
    {

        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.STOCK_INVENTARIO;
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

            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, drCabecera[StockInventarioService.DepositoId_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, drDetalle[StockInventarioDetalleService.ArticuloId_NombreCol]);
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
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    STOCK_INVENTARIORow cabeceraRow = sesion.Db.STOCK_INVENTARIOCollection.GetByCASO_ID(caso_id)[0];
                    STOCK_INVENTARIO_DETALLERow[] detalleRows = sesion.Db.STOCK_INVENTARIO_DETALLECollection.GetBySTOCK_INVENTANRIO_ID(cabeceraRow.ID);
                    // de borrador a anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Ninguna accion.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    // de borrador a pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.EnProceso))
                    {
                        //Acciones
                        //Ninguna accion.

                        #region generar autonumeracion

                        //Si no existe un comprobante se crea
                        if (cabeceraRow.NRO_COMPROBANTE == null)
                        {
                            if (cabeceraRow.AUTONUMERACION_ID==null)
                                throw new Exception("Debe indicarse el talonario o un número de comprobante de forma manual.");

                            cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, sesion);

                        }
                        #endregion generar autonumeracion

                        #region Bloquer Articulos
                        ARTICULOSRow articulo;
                        foreach (STOCK_INVENTARIO_DETALLERow row in detalleRows)
                        {
                            articulo = ArticulosService.GetArticuloRowPorID(row.ARTICULO_ID);
                            articulo.ESTADO=Definiciones.Estado.Inactivo;
                            sesion.Db.ARTICULOSCollection.Update(articulo);
                        }
                        #endregion Bloquer Articulos

                        exito = true;
                        revisarRequisitos = true;
                    }
                    //de pendiente a borrador
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                           estado_destino.Equals(Definiciones.EstadosFlujos.EnRevision))
                    {
                        //Acciones
                        //Ninguna accion.
                        exito = true;
                        revisarRequisitos = false;
                    }
                    //de pendiente a borrador
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnRevision) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Desbloquear los articulos.
                        exito = true;
                        revisarRequisitos = true;

                        #region Desbloquer Articulos
                        ARTICULOSRow articulo;
                        foreach (STOCK_INVENTARIO_DETALLERow row in detalleRows)
                        {
                            articulo = ArticulosService.GetArticuloRowPorID(row.ARTICULO_ID);
                            articulo.ESTADO = Definiciones.Estado.Activo;
                            sesion.Db.ARTICULOSCollection.Update(articulo);
                        }
                        #endregion Bloquer Articulos

                    }
                    // de pendiente a aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnRevision) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //Desbloquear los articulos
                        //Afectar en forma positiva o negativa el stock.
                        revisarRequisitos = true;
                        exito = true;

                        #region Desbloquer Articulos
                        ARTICULOSRow articulo;
                        foreach (STOCK_INVENTARIO_DETALLERow row in detalleRows)
                        {
                            articulo = ArticulosService.GetArticuloRowPorID(row.ARTICULO_ID);
                            articulo.ESTADO = Definiciones.Estado.Activo;
                            sesion.Db.ARTICULOSCollection.Update(articulo);
                        }
                        #endregion Bloquer Articulos

                        #region Crear Caso de Ajuste

                        #region Cabecera
                        decimal casoAjusteId = Definiciones.Error.Valor.EnteroPositivo;
                        string vCasoEstado=string.Empty;
                        decimal ajusteID= Definiciones.Error.Valor.EnteroPositivo; 
                        System.Collections.Hashtable campos = new System.Collections.Hashtable();       
                        campos.Add(StockAjusteService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ID);
                        campos.Add(StockAjusteService.DepositoId_NombreCol, cabeceraRow.DEPOSITO_ID);
                        campos.Add(StockAjusteDetalleService.MonedaId_NombreCol, VariablesSistemaEntidadService.GetValorInt(CBA.FlowV2.Services.Base.Definiciones.VariablesDeSistema.MonedaBaseSistemaId));
                        campos.Add(StockAjusteDetalleService.Cotizacion_NombreCol, decimal.Parse("1"));
                        campos.Add(StockAjusteService.CasoOrigenId_NombreCol, cabeceraRow.CASO_ID);
                        campos.Add(StockAjusteService.Observacion_NombreCol,"Caso de Ajuste Creado por Inventario N°"+ cabeceraRow.NRO_COMPROBANTE+" Caso ("+cabeceraRow.CASO_ID+")");
                        exito = StockAjusteService.Guardar(campos, true, ref casoAjusteId, ref vCasoEstado, ref ajusteID);
                        #endregion Cabecera

                        #region Detalles

                        System.Collections.Hashtable camposDetalles = new System.Collections.Hashtable();

                        if (exito)
                        {
                            foreach (STOCK_INVENTARIO_DETALLERow row in detalleRows)
                            {
                                camposDetalles = null;
                                camposDetalles = new System.Collections.Hashtable();

                                camposDetalles.Add(StockAjusteDetalleService.StockAjusteId_NombreCol, ajusteID);
                                camposDetalles.Add(StockAjusteDetalleService.ArticuloId_NombreCol, row.ARTICULO_ID);
                                camposDetalles.Add(StockAjusteDetalleService.LoteId_NombreCol, row.LOTE_ID);
                                camposDetalles.Add(StockAjusteDetalleService.UnidadMedidaDestino_NombreCol, row.UNIDAD_ID);
                                camposDetalles.Add(StockAjusteDetalleService.CantidadDestino_NombreCol, row.CANTIDAD_MANUAL - row.CANTIDAD_SISTEMA);
                                camposDetalles.Add(StockAjusteDetalleService.Observacion_NombreCol, "Cantidad : Sistema= " + row.CANTIDAD_SISTEMA + " Encontado= " + row.CANTIDAD_MANUAL);
                                camposDetalles.Add(StockAjusteDetalleService.InventarioCantidadEncontrada_NombreCol, row.CANTIDAD_MANUAL);
                                camposDetalles.Add(StockAjusteDetalleService.InventarioCantidadSistema_NombreCol, row.CANTIDAD_SISTEMA);

                                StockAjusteDetalleService.Guardar(camposDetalles, true);
                            }
                        }
                        #endregion Detalles
                        #endregion Crear Caso de Ajuste
                        try
                        {
                            #region StockUbicacion
                            System.Collections.Hashtable param = new System.Collections.Hashtable();
                            foreach (STOCK_INVENTARIO_DETALLERow row in detalleRows)
                            {
                                param = null;
                                param = new System.Collections.Hashtable();

                                String where = StockService.DepositoId_NombreCol + "=" + cabeceraRow.DEPOSITO_ID + " and " + StockService.ArticuloLoteId_NombreCol + " =" + row.LOTE_ID;
                                STOCK_SUC_DEPOSITO_ARTICULORow[] deposito = sesion.Db.STOCK_SUC_DEPOSITO_ARTICULOCollection.GetAsArray(where, string.Empty);
                                if (deposito.Length > 0)
                                {
                                    param.Add(StockUbicacionService.StockArtiDeposito_NombreCol, deposito[0].ID);
                                }
                                else
                                {
                                    STOCK_SUC_DEPOSITO_ARTICULORow dep = new STOCK_SUC_DEPOSITO_ARTICULORow();
                                    StockService.InsertarStockEnDeposito(sesion, cabeceraRow.SUCURSAL_ID, cabeceraRow.DEPOSITO_ID, row.ARTICULO_ID, row.LOTE_ID, out dep);

                                    param.Add(StockUbicacionService.StockArtiDeposito_NombreCol, dep.ID);
                                }

                                param.Add(StockUbicacionService.Pasillo_NombreCol, row.PASILLO);
                                param.Add(StockUbicacionService.Estante_NombreCol, row.ESTANTE);
                                param.Add(StockUbicacionService.Nivel_NombreCol, row.NIVEL);
                                param.Add(StockUbicacionService.Columna_NombreCol, row.COLUMNA);
                                param.Add(StockUbicacionService.Cantidad_NombreCol, row.CANTIDAD_MANUAL - row.CANTIDAD_SISTEMA);

                                StockUbicacionService.Guardar(param, true);
                            }
                            #endregion StockUbicacion
                        }
                        catch (Exception exp)
                        {
 
                        }
                    }
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        #region desbloquer articulos
                        ARTICULOSRow articulo;
                        foreach (STOCK_INVENTARIO_DETALLERow row in detalleRows)
                        {
                            articulo = ArticulosService.GetArticuloRowPorID(row.ARTICULO_ID);
                            articulo.ESTADO = Definiciones.Estado.Activo;
                            sesion.Db.ARTICULOSCollection.Update(articulo);
                        }
                        #endregion desbloquer articulos

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
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.STOCK_INVENTARIOCollection.Update(cabeceraRow);
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

        #region GetStockInventarioDataTable


        public DataTable GetStockInventarioDataTable(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;
                dt = sesion.Db.STOCK_INVENTARIOCollection.GetAsDataTable(clausula,string.Empty);

                return dt;
            }
        }



        /// <summary>
        /// Gets the stock inventario data table.
        /// </summary>
        /// <param name="id_sucursal">The id_sucursal.</param>
        /// <returns></returns>
        public DataTable GetStockInventarioDataTable(decimal id_sucursal)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;


                dt = sesion.Db.STOCK_INVENTARIOCollection.GetAsDataTable(StockInventarioService.SucursalId_NombreCol + " = " + id_sucursal, string.Empty);

                return dt;
            }
        }
        #endregion GetStockInventarioDataTable

        #region GetStockInventarioInfoCompleta



        /// <summary>
        /// Gets the stock inventario info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetStockInventarioInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;

                dt = sesion.Db.STOCK_INVENTARIO_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);

          
                return dt;
            }
        }
        #endregion GetStockInventarioInfoCompleta

        #region GetStockInventarioPorCaso

        /// <summary>
        /// Gets the stock inventario por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetStockInventarioPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.STOCK_INVENTARIOCollection.GetAsDataTable(StockInventarioService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetStockInventarioPorCaso

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    STOCK_INVENTARIORow row = new STOCK_INVENTARIORow();
                    string valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("stock_inventario_sqc");
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[StockInventarioService.SucursalId_NombreCol].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.STOCK_INVENTARIO.ToString()),
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
                        row = sesion.Db.STOCK_INVENTARIOCollection.GetRow(StockInventarioService.Id_NombreCol + " = " + campos[StockInventarioService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    row.SUCURSAL_ID = (decimal)campos[StockInventarioService.SucursalId_NombreCol];
                    row.DEPOSITO_ID = (decimal)campos[StockInventarioService.DepositoId_NombreCol];
                    row.AUTONUMERACION_ID = (decimal)campos[StockInventarioService.AutonumeracionId_NombreCol];
                    row.FECHA = DateTime.Now;
                    

                    if (insertarNuevo) sesion.Db.STOCK_INVENTARIOCollection.Insert(row);
                    else sesion.Db.STOCK_INVENTARIOCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

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
        public bool Borrar(decimal caso_id)
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
                    STOCK_INVENTARIORow cabecera = sesion.Db.STOCK_INVENTARIOCollection.GetByCASO_ID(caso_id)[0];
                    STOCK_INVENTARIO_DETALLERow[] detalles = sesion.Db.STOCK_INVENTARIO_DETALLECollection.GetBySTOCK_INVENTANRIO_ID(cabecera.ID);

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    if(exito && detalles.Length > 0)
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que posee detalles.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.STOCK_INVENTARIOCollection.DeleteByCASO_ID(caso_id);
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

        #region GetCasoAjusteAsociado
        public static decimal GetCasoAjusteAsociado(decimal caso_id) 
        {
            decimal casoAjuste= Definiciones.Error.Valor.EnteroPositivo;
            SessionService sesion = new SessionService();
            STOCK_AJUSTERow[] ajuste = sesion.db.STOCK_AJUSTECollection.GetByCASO_ORIGEN_ID(caso_id);

            if (ajuste.Length != 0)
                casoAjuste = ajuste[0].CASO_ID;

            return casoAjuste;

        }
        #endregion GetCasoAjusteAsociado

        #region Accessors
        #region Tablas
        public static string Nombre_Tabla
        {
            get { return "STOCK_INVENTARIO"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return STOCK_INVENTARIOCollection.AUTONUMERACION_IDColumnName; }
        }
       
        public static string CasoId_NombreCol
        {
            get { return STOCK_INVENTARIOCollection.CASO_IDColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return STOCK_INVENTARIOCollection.DEPOSITO_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return STOCK_INVENTARIOCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return STOCK_INVENTARIOCollection.IDColumnName; }
        }

        public static string NroComprobante_NombreCol
        {
            get { return STOCK_INVENTARIOCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return STOCK_INVENTARIOCollection.SUCURSAL_IDColumnName; }
        }
       
        #endregion Tablas

        #region Vistas
        public static string VistaCasoEstado_NombreCol
        {
            get { return STOCK_INVENTARIO_INFO_COMPLCollection.CASO_ESTADOColumnName; }
        }
        
        public static string VistaDepositoNombre_NombreCol
        {
            get { return STOCK_INVENTARIO_INFO_COMPLCollection.DEPOSITO_NOMBREColumnName; }
        }
        
        public static string VistaSucursalNombre_NombreCol
        {
            get { return STOCK_INVENTARIO_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; }
        }
        
        public static string VistaUsuarioCreador_NombreCol
        {
            get { return STOCK_INVENTARIO_INFO_COMPLCollection.USUARIOColumnName; }
        }
       
        #endregion Vistas
        #endregion Accessors
    }
}




