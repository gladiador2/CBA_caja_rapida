#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Common;
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
    public class StockAjusteService : FlujosServiceBaseWorkaround
    {

        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.AJUSTE_STOCK;
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

            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, drCabecera[StockAjusteService.DepositoId_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, drDetalle[StockAjusteDetalleService.ArticuloId_NombreCol]);
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
                var caso = new CasosService(caso_id, sesion);
                STOCK_AJUSTERow cabeceraRow = sesion.Db.STOCK_AJUSTECollection.GetByCASO_ID(caso_id)[0];
                STOCK_AJUSTE_DETALLERow[] detalleRows = sesion.Db.STOCK_AJUSTE_DETALLECollection.GetBySTOCK_AJUSTE_ID(cabeceraRow.ID);
                
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
                    //Ninguna accion.
                    exito = true;
                    revisarRequisitos = true;
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
                    if (detalleRows.Length == 0)
                        throw new Exception("El Caso de Ajuste no posee detalles");
                    
                    string tipoMoviemiento = string.Empty;
                    foreach (STOCK_AJUSTE_DETALLERow detalle in detalleRows)
                    {
                        if (detalle.CANTIDAD_ORIGEN > 0)
                        {
                            tipoMoviemiento = Definiciones.Stock.TipoMovimiento.AjustePositivo;
                        }
                        else
                        {
                            tipoMoviemiento = Definiciones.Stock.TipoMovimiento.AjusteNegativo;
                            detalle.CANTIDAD_ORIGEN = detalle.CANTIDAD_ORIGEN * -1;
                        }

                        StockService.Costo costo = null;
                        if (!detalle.IsCOSTO_UNITARIONull)
                        {
                            costo = new StockService.Costo()
                            {
                                moneda_origen_id = detalle.MONEDA_ID,
                                cotizacion_origen = detalle.COTIZACION,
                                costo_origen = detalle.COSTO_UNITARIO,
                                moneda_id = caso.Sucursal.Region.SucursalCasaMatriz.Pais.MonedaId
                            };

                            if (costo.moneda_origen_id == costo.moneda_id)
                            {
                                costo.cotizacion = costo.cotizacion_origen;
                                costo.costo = costo.costo_origen;
                            }
                            else
                            {
                                costo.cotizacion = CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, costo.moneda_id, caso.FechaFormulario.Value, sesion);
                                costo.costo = costo.costo_origen / costo.cotizacion_origen * costo.cotizacion;
                            }
                        }

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                             detalle.ARTICULO_ID,
                                             Interprete.Redondear(detalle.CANTIDAD_ORIGEN, UnidadesService.GetCantidadDecimales(ArticulosService.GetUnidadBase(detalle.ARTICULO_ID))),
                                             tipoMoviemiento, caso_id, detalle.LOTE_ID, estado_destino,
                                             sesion,
                                             costo,
                                             null,
                                             detalle.ID);
                    }
                }

                //Verificar si se cumplen los requisitos
                if (exito && revisarRequisitos)
                {
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                }

                if (exito)
                {
                    caso.Guardar(sesion);
                    sesion.Db.STOCK_AJUSTECollection.Update(cabeceraRow);
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

        #region GetStockAjusteDataTable
        public static DataTable GetStockAjusteDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetStockAjusteDataTable(clausula, orden, sesion);
            }
        }

        public static DataTable GetStockAjusteDataTable(string clausula, string orden, SessionService sesion)
        {
            return sesion.Db.STOCK_AJUSTECollection.GetAsDataTable(clausula, orden);
        }
        #endregion GetStockAjusteDataTable

        #region GetStockAjusteDataTablePorSucursal
        /// <summary>
        /// Gets the stock ajuste data table por sucursal.
        /// </summary>
        /// <param name="id_sucursal">The id_sucursal.</param>
        /// <returns></returns>
        public DataTable GetStockAjusteDataTablePorSucursal(decimal id_sucursal)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;


                dt = sesion.Db.STOCK_AJUSTECollection.GetAsDataTable(SucursalId_NombreCol + " = " + id_sucursal, string.Empty);

                return dt;
            }
        }
        #endregion GetStockAjusteDataTable

        #region GetStockAjusteInfoCompleta
        /// <summary>
        /// Gets the stock ajuste info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetStockAjusteInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetStockAjusteInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetStockAjusteInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.STOCK_AJUSTE_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetStockAjusteInfoCompleta

        #region GetStockAjustePorCaso
        /// <summary>
        /// Gets the stock ajuste por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetStockAjustePorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.STOCK_AJUSTECollection.GetAsDataTable(StockAjusteService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetStockAjustePorCaso

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id, ref decimal ajuste_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return Guardar(campos, insertarNuevo, ref caso_id, ref estado_id, ref ajuste_id, sesion);
            }
        }

        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id, ref decimal ajuste_id, SessionService sesion)
        {
            try
            {
                STOCK_AJUSTERow row = new STOCK_AJUSTERow();
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("stock_ajuste_sqc");
                    CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[SucursalId_NombreCol].ToString()),
                                                         int.Parse(Definiciones.FlujosIDs.AJUSTE_STOCK.ToString()),
                                                         int.Parse(sesion.Usuario_Id.ToString()),
                                                         SessionService.GetClienteIP());
                    row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                    estado_id = Definiciones.EstadosFlujos.Borrador;
                    if (campos.Contains(StockAjusteService.CasoOrigenId_NombreCol))
                    {
                        decimal casoOrigen;
                        if (decimal.TryParse(campos[StockAjusteService.CasoOrigenId_NombreCol].ToString(), out casoOrigen))
                            row.CASO_ORIGEN_ID = casoOrigen;
                    }
                }
                else
                {
                    row = sesion.Db.STOCK_AJUSTECollection.GetRow(StockAjusteService.Id_NombreCol + " = " + campos[StockAjusteService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }
                if (campos.Contains(StockAjusteService.CasoOrigenId_NombreCol))
                {
                    decimal casoOrigen;
                    if (decimal.TryParse(campos[StockAjusteService.CasoOrigenId_NombreCol].ToString(), out casoOrigen))
                        row.CASO_ORIGEN_ID = casoOrigen;
                }
                row.COSTO_TOTAL = 0;
                row.SUCURSAL_ID = (decimal)campos[StockAjusteService.SucursalId_NombreCol];
                row.DEPOSITO_ID = (decimal)campos[StockAjusteService.DepositoId_NombreCol];
                row.USUARIO_ID = sesion.Usuario.ID;

                if (campos.Contains(StockAjusteService.Fecha_Creacion_NombreCol))
                    row.FECHA_CRACION = (DateTime)campos[StockAjusteService.Fecha_Creacion_NombreCol];
                else
                    row.FECHA_CRACION = DateTime.Now;

                if (campos.Contains(StockAjusteService.Observacion_NombreCol))
                    row.OBSERVACION = (string)campos[StockAjusteService.Observacion_NombreCol];

                if (campos.Contains(StockAjusteDetalleService.Cotizacion_NombreCol))
                    row.COTIZACION = decimal.Parse(campos[StockAjusteDetalleService.Cotizacion_NombreCol].ToString());

                if (campos.Contains(StockAjusteDetalleService.MonedaId_NombreCol))
                    row.MONEDA_ID = decimal.Parse(campos[StockAjusteDetalleService.MonedaId_NombreCol].ToString());
                if (campos.Contains(StockAjusteService.TextoPredefinidoId_NombreCol))
                    row.TEXTO_PREDEFINIDO_ID = decimal.Parse(campos[StockAjusteService.TextoPredefinidoId_NombreCol].ToString());

                if (insertarNuevo) 
                    sesion.Db.STOCK_AJUSTECollection.Insert(row);
                else 
                    sesion.Db.STOCK_AJUSTECollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();
                camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA_CRACION);
                camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                #endregion Actualizar datos en tabla casos

                ajuste_id = row.ID;
                return true;
            }
            catch (Exception)
            {
                throw;
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

                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    STOCK_AJUSTERow cabecera = sesion.Db.STOCK_AJUSTECollection.GetByCASO_ID(caso_id)[0];
                    STOCK_AJUSTE_DETALLERow[] detalles = sesion.Db.STOCK_AJUSTE_DETALLECollection.GetBySTOCK_AJUSTE_ID(cabecera.ID);

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    if (exito && detalles.Length > 0)
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que posee detalles.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.STOCK_AJUSTECollection.DeleteByCASO_ID(caso_id);
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

        #region ActualizarTotal
        public static void ActualizarTotal(decimal ajuste_id, SessionService sesion)
        {
            STOCK_AJUSTERow ajuste = sesion.Db.STOCK_AJUSTECollection.GetByPrimaryKey(ajuste_id);
            STOCK_AJUSTE_DETALLERow[] ajusteDetalles = sesion.Db.STOCK_AJUSTE_DETALLECollection.GetBySTOCK_AJUSTE_ID(ajuste_id);

            string valorAnterior = ajuste.ToString();
            decimal costoTotal = 0;

            for (int i = 0; i < ajusteDetalles.Length; i++)
            {
                costoTotal += ajusteDetalles[i].COSTO_TOTAL;
            }

            ajuste.COSTO_TOTAL = costoTotal;
            sesion.Db.STOCK_AJUSTECollection.Update(ajuste);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, ajuste.ID, valorAnterior, ajuste.ToString(), sesion);
        }
        #endregion ActualizarTotal

        #region Accessors
        #region Tablas
        public static string Nombre_Tabla
        {
            get { return "STOCK_AJUSTE"; }
        }
        public static string Id_NombreCol
        {
            get { return STOCK_AJUSTECollection.IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return STOCK_AJUSTECollection.SUCURSAL_IDColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return STOCK_AJUSTECollection.DEPOSITO_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return STOCK_AJUSTECollection.USUARIO_IDColumnName; }
        }
        public static string Fecha_Creacion_NombreCol
        {
            get { return STOCK_AJUSTECollection.FECHA_CRACIONColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return STOCK_AJUSTECollection.CASO_IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return STOCK_AJUSTECollection.OBSERVACIONColumnName; }
        }
        public static string CostoTotal_NombreCol
        {
            get { return STOCK_AJUSTECollection.COSTO_TOTALColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return STOCK_AJUSTECollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return STOCK_AJUSTECollection.MONEDA_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return STOCK_AJUSTECollection.COTIZACIONColumnName; }
        }
        public static string CasoOrigenId_NombreCol
        {
            get { return STOCK_AJUSTECollection.CASO_ORIGEN_IDColumnName; }
        }
        #endregion Tablas

        #region Vistas
        public static string Nombre_Vista
        {
            get { return "STOCK_AJUSTE_INFO_COMPLETA"; }
        }
        public static string VistaId_NombreCol
        {
            get { return STOCK_AJUSTE_INFO_COMPLETACollection.IDColumnName; }
        }
        public static string VistaSucursal_Id_NombreCol
        {
            get { return STOCK_AJUSTE_INFO_COMPLETACollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaSucursal_Nombre_NombreCol
        {
            get { return STOCK_AJUSTE_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaDeposito_Id_NombreCol
        {
            get { return STOCK_AJUSTE_INFO_COMPLETACollection.DEPOSITO_IDColumnName; }
        }
        public static string VistaDeposito_Nombre_NombreCol
        {
            get { return STOCK_AJUSTE_INFO_COMPLETACollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaUsuario_Id_NombreCol
        {
            get { return STOCK_AJUSTE_INFO_COMPLETACollection.USUARIO_IDColumnName; }
        }
        public static string VistaUsuario_Nombre_NombreCol
        {
            get { return STOCK_AJUSTE_INFO_COMPLETACollection.USUARIO_NOMBREColumnName; }
        }
        public static string VistaFecha_Creacion_NombreCol
        {
            get { return STOCK_AJUSTE_INFO_COMPLETACollection.FECHA_CRACIONColumnName; }
        }
        public static string VistaCasoId_NombreCol
        {
            get { return STOCK_AJUSTE_INFO_COMPLETACollection.CASO_IDColumnName; }
        }
        public static string VistaObservacion_NombreCol
        {
            get { return STOCK_AJUSTE_INFO_COMPLETACollection.OBSERVACIONColumnName; }
        }
        public static string VistaCasoEstado_NombreCol
        {
            get { return STOCK_AJUSTE_INFO_COMPLETACollection.CASO_ESTADOColumnName; }
        }
        public static string VistaMonedaId_NombreCol
        {
            get { return STOCK_AJUSTE_INFO_COMPLETACollection.MONEDA_IDColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return STOCK_AJUSTE_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return STOCK_AJUSTE_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaCotizacion_NombreCol
        {
            get { return STOCK_AJUSTE_INFO_COMPLETACollection.COTIZACIONColumnName; }
        }
        #endregion Vistas
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static StockAjusteService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new StockAjusteService(e.RegistroId, sesion);
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
        protected STOCK_AJUSTERow row;
        protected STOCK_AJUSTERow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal CasoId { get { return row.CASO_ID; } set { row.CASO_ID = value; } }
        public decimal? CasoOrigenId { get { if (row.IsCASO_ORIGEN_IDNull) return null; else return row.CASO_ORIGEN_ID; } set { if (value.HasValue) row.CASO_ORIGEN_ID = value.Value; else row.IsCASO_ORIGEN_IDNull = true; } }
        public decimal? CostoTotal { get { if (row.IsCOSTO_TOTALNull) return null; else return row.COSTO_TOTAL; } set { if (value.HasValue) row.COSTO_TOTAL = value.Value; else row.IsCOSTO_TOTALNull = true; } }
        public decimal? Cotizacion { get { if (row.IsCOTIZACIONNull) return null; else return row.COTIZACION; } set { if (value.HasValue) row.COTIZACION = value.Value; else row.IsCOTIZACIONNull = true; } }
        public decimal DepositoId { get { return row.DEPOSITO_ID; } set { row.DEPOSITO_ID = value; } }
        public DateTime FechaCreacion { get { return row.FECHA_CRACION; } set { row.FECHA_CRACION = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? MonedaId { get { if (row.IsMONEDA_IDNull) return null; else return row.MONEDA_ID; } set { if (value.HasValue) row.MONEDA_ID = value.Value; else row.IsMONEDA_IDNull = true; } }
        public string Observacion { get { return GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } set { row.SUCURSAL_ID = value; } }
        public decimal UsuarioId { get { return row.USUARIO_ID; } set { row.USUARIO_ID = value; } }
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

        private CasosService _caso_origen;
        public CasosService CasoOrigen
        {
            get
            {
                if (this._caso_origen == null)
                {
                    if (this.sesion != null)
                        this._caso_origen = new CasosService(this.CasoOrigenId.Value, this.sesion);
                    else
                        this._caso_origen = new CasosService(this.CasoOrigenId.Value);
                }
                return this._caso_origen;
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

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                {
                    if (this.sesion != null)
                        this._moneda = new MonedasService(this.MonedaId.Value, this.sesion);
                    else
                        this._moneda = new MonedasService(this.MonedaId.Value);
                }
                return this._moneda;
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

        #region Propiedades OneToMany
        private StockAjusteDetalleService[] stock_ajuste_detalles;
        public StockAjusteDetalleService[] StockAjusteDetalles
        {
            get
            {
                if (this.stock_ajuste_detalles == null)
                    this.stock_ajuste_detalles = StockAjusteDetalleService.GetPorCabecera(this.Id.Value);
                return this.stock_ajuste_detalles;
            }
        }
        #endregion Propiedades OneToMany

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.STOCK_AJUSTECollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new STOCK_AJUSTERow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(STOCK_AJUSTERow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public StockAjusteService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public StockAjusteService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public StockAjusteService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        private StockAjusteService(STOCK_AJUSTERow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._caso = null;
            this._caso_origen = null;
            this._deposito = null;
            this._moneda = null;
            this._sucursal = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region GetPorCaso
        public static StockAjusteService GetPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCaso(caso_id, sesion);
            }
        }

        public static StockAjusteService GetPorCaso(decimal caso_id, SessionService sesion)
        {
            var row = sesion.db.STOCK_AJUSTECollection.GetByCASO_ID(caso_id)[0];
            return new StockAjusteService(row);
        }
        #endregion GetPorCaso
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}




