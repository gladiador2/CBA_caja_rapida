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
using CBA.FlowV2.Services.Common;

#endregion Using

namespace CBA.FlowV2.Services.Stock
{
    public class UsoDeInsumosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.USO_DE_INSUMOS;
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

            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, drCabecera[UsoDeInsumosService.DepositoId_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, drDetalle[UsoDeInsumosDetalleService.ModeloVista.ARTICULO_IDColumnName]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, drCabecera[UsoDeInsumosService.TextoPredefinidoId_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, drDetalle[UsoDeInsumosDetalleService.ModeloVista.ACTIVO_IDColumnName]);
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }

        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            throw new NotImplementedException();
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
                USO_DE_INSUMOSRow cabeceraRow = sesion.Db.USO_DE_INSUMOSCollection.GetByCASO_ID(caso_id)[0];
                USO_DE_INSUMOS_DETALLERow[] detalleRows = sesion.Db.USO_DE_INSUMOS_DETALLECollection.GetByUSO_DE_INSUMO_ID(cabeceraRow.ID);
               
                #region Borrador a Anulado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna acción.
                    exito = true;
                    revisarRequisitos = true;
                }
                #endregion Borrador a Anulado

                #region Borrador a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Generar nro de comprobante
                    exito = true;
                    revisarRequisitos = true;

                    if (detalleRows.Length <= 0)
                    {
                        mensaje = "No existen detalles.";
                        exito = false;
                    }

                    //Generar autonumeración. Si no existe un comprobante, se crea
                    if (cabeceraRow.NRO_DE_COMPROBANTE == null)
                        cabeceraRow.NRO_DE_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, sesion);
                }
                #endregion Borrador a Pendiente

                #region Pendiente a Borrador
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //Ninguna accion.
                    exito = true;
                    revisarRequisitos = false;
                }
                #endregion Pendiente a Borrador

                #region Pendiente a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna accion.
                    exito = true;
                    revisarRequisitos = true;
                }
                #endregion Pendiente a Anulado

                #region Pendiente a Aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                 
                    //Acciones
                    //Afectar el stock.
                    revisarRequisitos = true;
                    exito = true;
                    //xxxxxxx
                    string tns = VariablesSistemaEntidadService.GetValorString(CBA.FlowV2.Services.Base.Definiciones.VariablesDeSistema.UsoInsumoObligatorioCasoAsociado);
                    if (tns.Equals("S"))
                    {
                        if (cabeceraRow.CASO_ASOCIADO_ID.Equals(null) || cabeceraRow.CASO_ASOCIADO_ID.Equals(0))
                        {
                            throw new InvalidOperationException("Debe seleccionar el caso asociado");
                            exito = false;
                            return exito;
                        }
                    }
                    #region Afectar stock
                    //Si es una insercion cantidad_original es cero, si es una modificacion
                    //se modifica solo la diferencia entre la cantidad actual y la anterior

                    ArticulosLotesService lote = new ArticulosLotesService();

                    foreach (USO_DE_INSUMOS_DETALLERow detalle in detalleRows)
                    {
                        decimal articuloId = lote.GetArticuloId(detalle.ARTICULO_LOTE_ID);
                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                      articuloId,
                                                      detalle.CANTIDAD_UNITARIA_TOTAL_ORIGEN,
                                                      Definiciones.Stock.TipoMovimiento.UsoDeInsumo, caso_id, detalle.ARTICULO_LOTE_ID, estado_destino,
                                                      sesion,
                                                      null,
                                                      null,
                                                      detalle.ID);
                    }
                    #endregion Afectar stock
                }
                #endregion Pendiente a Aprobado

                #region Aprobado a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones:
                    //Se devuelven los artículos al stock
                    exito = true;
                    revisarRequisitos = true;

                    if (exito)
                    {
                        ArticulosLotesService lote = new ArticulosLotesService();
                        foreach (USO_DE_INSUMOS_DETALLERow detalle in detalleRows)
                        {
                            decimal articuloId = lote.GetArticuloId(detalle.ARTICULO_LOTE_ID);
                            StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    articuloId,
                                                    -detalle.CANTIDAD_UNITARIA_TOTAL_ORIGEN,
                                                    Definiciones.Stock.TipoMovimiento.UsoDeInsumo, caso_id, detalle.ARTICULO_LOTE_ID, estado_destino,
                                                    sesion, null, null, detalle.ID,true);
                        }
                    }
                }
                #endregion Aprobado a Pendiente

                if (exito && revisarRequisitos)
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);

                if (exito)
                {
                    sesion.Db.CASOSCollection.Update(casoRow);
                    sesion.Db.USO_DE_INSUMOSCollection.Update(cabeceraRow);
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

        #region GeUsoDeInsumosDataTable
        public static DataTable GetUsoDeInsumosDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetUsoDeInsumosDataTable(clausula, orden, sesion);
            }
        }

        public static DataTable GetUsoDeInsumosDataTable(string clausula, string orden, SessionService sesion)
        {
            return sesion.Db.USO_DE_INSUMOSCollection.GetAsDataTable(clausula, orden);
        }
        #endregion GeUsoDeInsumosDataTable

        #region GetUsoDeInsumosInfoCompleta
        public static DataTable GetUsoDeInsumosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetUsoDeInsumosInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetUsoDeInsumosInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.USO_DE_INSUMOS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetUsoDeInsumosInfoCompleta

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                USO_DE_INSUMOSRow row = new USO_DE_INSUMOSRow();
                try
                {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("uso_de_insumos_sqc");
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[UsoDeInsumosService.SucursalId_NombreCol].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.USO_DE_INSUMOS.ToString()),
                                                             int.Parse(sesion.Usuario_Id.ToString()),
                                                             SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.USO_DE_INSUMOSCollection.GetRow(UsoDeInsumosService.Id_NombreCol + " = " + campos[UsoDeInsumosService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.AUTONUMERACION_ID = (decimal)campos[UsoDeInsumosService.AutonumeracionId_NombreCol];
                    row.DEPOSITO_ID = (decimal)campos[UsoDeInsumosService.DepositoId_NombreCol];
                    row.FUNCIONARIO_ID = (decimal)campos[UsoDeInsumosService.FuncionarioId_NombreCol];
                    row.TEXTO_PREDEFINIDO_ID = (decimal)campos[UsoDeInsumosService.TextoPredefinidoId_NombreCol];
                    row.SUCURSAL_ID = (decimal)campos[UsoDeInsumosService.SucursalId_NombreCol];
                    row.FECHA = DateTime.Parse(campos[UsoDeInsumosService.Fecha_NombreCol].ToString());
                    row.NRO_DE_COMPROBANTE = campos[UsoDeInsumosService.NroComprobante_NombreCol].ToString();

                    //Actualizar el caso asociado segun varíen los datos en el Uso de Insumos
                    ActualizarCasoAsociado(row, campos, sesion);
                    if (campos.Contains(UsoDeInsumosService.CasoAsociadoId_NombreCol))
                        row.CASO_ASOCIADO_ID = (decimal)campos[UsoDeInsumosService.CasoAsociadoId_NombreCol];
                    else
                        row.IsCASO_ASOCIADO_IDNull = true;

                    if (UsoDeInsumosService.GetExisteNroComprobante(row.ID, row.AUTONUMERACION_ID, row.NRO_DE_COMPROBANTE, sesion))
                        throw new Exception("El número de comprobante ya existe");

                    if (insertarNuevo)
                        sesion.Db.USO_DE_INSUMOSCollection.Insert(row);
                    else
                        sesion.Db.USO_DE_INSUMOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_DE_COMPROBANTE);
                    camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.FUNCIONARIO_ID);
					camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    return true;
                }
                catch (Exception exp)
                {
                    //Eliminar el caso creado
                    if (insertarNuevo && row.CASO_ID > 0)
                    {
                        (new CasosService()).Eliminar(row.CASO_ID, sesion);
                        caso_id = Definiciones.Error.Valor.EnteroPositivo;
                        estado_id = string.Empty;
                    }
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region ActualizarCasoAsociado
        private static void ActualizarCasoAsociado(USO_DE_INSUMOSRow row, Hashtable campos, SessionService sesion)
        {
            Hashtable camposAsociar = null;
            decimal casoAsociadoNuevoId = Definiciones.Error.Valor.EnteroPositivo;
            if(campos.Contains(UsoDeInsumosService.CasoAsociadoId_NombreCol))
                casoAsociadoNuevoId = (decimal)campos[UsoDeInsumosService.CasoAsociadoId_NombreCol];

            //Desasociar el anterior si cambia
            if (!row.IsCASO_ASOCIADO_IDNull && row.CASO_ASOCIADO_ID != casoAsociadoNuevoId)
            {
                var casoAnterior = new CasosService(row.CASO_ASOCIADO_ID, sesion);
                switch ((int)casoAnterior.FlujoId)
                { 
                    case Definiciones.FlujosIDs.TRAMITES:
                        Tramites.TramitesCasosAsociadosService.BorrarPorCasoAsociado(row.CASO_ASOCIADO_ID, sesion);
                        break;
                }
            }

            //Crear la nueva asociacion
            if (casoAsociadoNuevoId != Definiciones.Error.Valor.EnteroPositivo)
            {
                var casoActual = new CasosService(casoAsociadoNuevoId, sesion);
                switch ((int)casoActual.FlujoId)
                {
                    case Definiciones.FlujosIDs.TRAMITES:
                        var dtTramite = Tramites.TramitesService.GetTramitesDataTable(Tramites.TramitesService.CasoId_NombreCol + " = " + casoActual.Id, string.Empty, sesion);
                        camposAsociar = new Hashtable();
                        camposAsociar.Add(Tramites.TramitesCasosAsociadosService.TramiteId_NombreCol, dtTramite.Rows[0][Tramites.TramitesService.Id_NombreCol]);
                        camposAsociar.Add(Tramites.TramitesCasosAsociadosService.FechaAgregado_NombreCol, DateTime.Now);
                        camposAsociar.Add(Tramites.TramitesCasosAsociadosService.UsuarioId_NombreCol, sesion.Usuario_Id);
                        camposAsociar.Add(Tramites.TramitesCasosAsociadosService.Observacion_NombreCol, string.Empty);
                        camposAsociar.Add(Tramites.TramitesCasosAsociadosService.CasoId_NombreCol, row.CASO_ID);
                        Tramites.TramitesCasosAsociadosService.Guardar(camposAsociar, true, sesion);
                        break;
                }
            }
        }
        #endregion ActualizarCasoAsociado

        #region Borrar
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
                    USO_DE_INSUMOSRow cabecera = sesion.Db.USO_DE_INSUMOSCollection.GetByCASO_ID(caso_id)[0];
                    USO_DE_INSUMOS_DETALLERow[] detalles = sesion.Db.USO_DE_INSUMOS_DETALLECollection.GetByUSO_DE_INSUMO_ID(cabecera.ID);

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso debe estar en el estado borrador para poder borrarse.";
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
                        sesion.Db.USO_DE_INSUMOSCollection.DeleteByCASO_ID(caso_id);
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

        #region GetExisteNroComprobante
        private static bool GetExisteNroComprobante(decimal uso_de_insumo_id, decimal autonumeracion_id, string nro_comprobante, SessionService sesion)
        {
            bool existe = false;
            string clausulas = UsoDeInsumosService.NroComprobante_NombreCol + " = '" + nro_comprobante + "' " +
                 " and " + UsoDeInsumosService.Id_NombreCol + " <> " + uso_de_insumo_id;

            if (!autonumeracion_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                clausulas += " and " + UsoDeInsumosService.AutonumeracionId_NombreCol + " = " + autonumeracion_id;

            USO_DE_INSUMOSRow[] rows = sesion.Db.USO_DE_INSUMOSCollection.GetAsArray(clausulas, string.Empty);

            existe = rows.Length > 0;

            return existe;
        }
        #endregion GetExisteNroComprobante

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "USO_DE_INSUMOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "USO_DE_INSUMOS_INFO_COMPLETA"; }
        }

        public static string AutonumeracionId_NombreCol
        {
            get { return USO_DE_INSUMOSCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return USO_DE_INSUMOSCollection.CASO_IDColumnName; }
        }
        public static string CasoAsociadoId_NombreCol
        {
            get { return USO_DE_INSUMOSCollection.CASO_ASOCIADO_IDColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return USO_DE_INSUMOSCollection.DEPOSITO_IDColumnName; }
        }

        public static string Fecha_NombreCol
        {
            get { return USO_DE_INSUMOSCollection.FECHAColumnName; }
        }

        public static string FuncionarioId_NombreCol
        {
            get { return USO_DE_INSUMOSCollection.FUNCIONARIO_IDColumnName; }
        }

        public static string Id_NombreCol
        {
            get { return USO_DE_INSUMOSCollection.IDColumnName; }
        }

        public static string NroComprobante_NombreCol
        {
            get { return USO_DE_INSUMOSCollection.NRO_DE_COMPROBANTEColumnName; }
        }

        public static string SucursalId_NombreCol
        {
            get { return USO_DE_INSUMOSCollection.SUCURSAL_IDColumnName; }
        }

        public static string TextoPredefinidoId_NombreCol
        {
            get { return USO_DE_INSUMOSCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }

        public static string VistaDepositoNombre_NombreCol
        {
            get { return USO_DE_INSUMOS_INFO_COMPLETACollection.DEPOSITO_NOMBREColumnName; }
        }

        public static string VistaEstadoCaso_NombreCol
        {
            get { return USO_DE_INSUMOS_INFO_COMPLETACollection.ESTADO_IDColumnName; }
        }

        public static string VistaFuncionarioNombreCompleto_NombreCol
        {
            get { return USO_DE_INSUMOS_INFO_COMPLETACollection.FUNCIONARIO_NOMBRE_COMPLETOColumnName; }
        }

        public static string VistaSucursalNombre_NombreCol
        {
            get { return USO_DE_INSUMOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }

        public static string VistaTextoPredefinido_NombreCol
        {
            get { return USO_DE_INSUMOS_INFO_COMPLETACollection.TEXTO_PREDEFINIDOColumnName; }
        }
        #endregion Accessors
    }
}



