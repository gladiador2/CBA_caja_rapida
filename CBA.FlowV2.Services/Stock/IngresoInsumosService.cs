using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Common;
using System.Data;
using CBA.FlowV2.Services.Casos;
using System.Collections;


namespace CBA.FlowV2.Services.Stock
{
    public class IngresoInsumosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.INGRESO_INSUMOS;
        }
        #endregion Implementacion de metodos abstract

        #region Getters
        public static DataTable GetIngresoInsumosDataTable(string where, string orderby)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.INGRESO_INSUMOSCollection.GetAsDataTable(where, orderby);
            }
        }
        #endregion Getters

        #region ProcesarCambioEstado
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
                INGRESO_INSUMOSRow cabeceraRow = sesion.Db.INGRESO_INSUMOSCollection.GetByCASO_ID(caso_id)[0];
                INGRESO_INSUMOS_DETALLESRow[] detallesRows = sesion.Db.INGRESO_INSUMOS_DETALLESCollection.GetByINGRESO_ID(cabeceraRow.ID);

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
                    //Se genera el numero de comprobante

                    exito = true;
                    revisarRequisitos = true;
                    if (detallesRows.Length <= 0)
                    {
                        mensaje = "El ingreso de insumos no tiene detalles.";
                        exito = false;
                    }

                    #region Se genera el numero de comprobante
                    if (exito && cabeceraRow.NRO_COMPROBANTE == null)
                    {
                        try
                        {
                            cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID);

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
                    //Se ingresa el insumo al stock
                    exito = true;
                    revisarRequisitos = true;

                    foreach (INGRESO_INSUMOS_DETALLESRow detalle in detallesRows)
                    {
                        var al = new ArticulosLotesService(detalle.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;

                        decimal cantidad = 0;
                        if (detalle.USAR_CANTIDAD_BASCULA == Definiciones.SiNo.Si)
                        {
                            cantidad = detalle.CANTIDAD_BASCULA;
                            if (detalle.MERMA != 0)
                                cantidad = cantidad - (cantidad * detalle.MERMA / 100);
                            else
                                cantidad = cantidad - (cantidad * cabeceraRow.MERMA / 100);
                        }
                        else
                        if (detalle.USAR_CANTIDAD_BL == Definiciones.SiNo.Si)
                        {
                            cantidad = detalle.CANTIDAD_BL;
                            if (detalle.MERMA != 0)
                                cantidad = cantidad - (cantidad * detalle.MERMA / 100);
                            else
                                cantidad = cantidad - (cantidad * cabeceraRow.MERMA / 100);
                        }
                        else
                        if (detalle.USAR_CANTIDAD_DRAFT == Definiciones.SiNo.Si)
                        {
                            cantidad = detalle.CANTIDAD_DRAFT;
                            if (detalle.MERMA != 0)
                                cantidad = cantidad - (cantidad * detalle.MERMA / 100);
                            else
                                cantidad = cantidad - (cantidad * cabeceraRow.MERMA / 100);
                        }
                        else
                        if (detalle.USAR_CANTIDAD_REMISION == Definiciones.SiNo.Si)
                        {
                            cantidad = detalle.CANTIDAD_REMISION;                                    
                            if (detalle.MERMA != 0)
                                cantidad = cantidad - (cantidad * detalle.MERMA / 100);
                            else
                                cantidad = cantidad - (cantidad * cabeceraRow.MERMA / 100);
                        }

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    cantidad,
                                                    Definiciones.Stock.TipoMovimiento.Compra, caso_id, detalle.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    detalle.ID);
                        al.FinalizarUsingSesion();
                    }
                }
                //Aprobado a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Se revierte el ingreso de insumo al stock
                    revisarRequisitos = true;
                    exito = true;

                    string stockMovimiento = string.Empty;
                    foreach (INGRESO_INSUMOS_DETALLESRow detalle in detallesRows)
                    {
                        var al = new ArticulosLotesService(detalle.LOTE_ID, sesion);
                        StockService.Costo costo = null;

                        decimal cantidad = 0;
                        if (detalle.USAR_CANTIDAD_BASCULA == Definiciones.SiNo.Si)
                        {
                            cantidad = detalle.CANTIDAD_BASCULA;
                            if (detalle.MERMA != 0)
                                cantidad = cantidad - (cantidad * detalle.MERMA / 100);
                            else
                                cantidad = cantidad - (cantidad * cabeceraRow.MERMA / 100);
                        }
                        else
                        if (detalle.USAR_CANTIDAD_BL == Definiciones.SiNo.Si)
                        {
                            cantidad = detalle.CANTIDAD_BL;
                            if (detalle.MERMA != 0)
                                cantidad = cantidad - (cantidad * detalle.MERMA / 100);
                            else
                                cantidad = cantidad - (cantidad * cabeceraRow.MERMA / 100);
                        }
                        else
                        if (detalle.USAR_CANTIDAD_DRAFT == Definiciones.SiNo.Si)
                        {
                            cantidad = detalle.CANTIDAD_DRAFT;
                            if (detalle.MERMA != 0)
                                cantidad = cantidad - (cantidad * detalle.MERMA / 100);
                            else
                                cantidad = cantidad - (cantidad * cabeceraRow.MERMA / 100);
                        }
                        else
                        if (detalle.USAR_CANTIDAD_REMISION == Definiciones.SiNo.Si)
                        {
                            cantidad = detalle.CANTIDAD_REMISION;
                            if (detalle.MERMA != 0)
                                cantidad = cantidad - (cantidad * detalle.MERMA / 100);
                            else
                                cantidad = cantidad - (cantidad * cabeceraRow.MERMA / 100);
                        }

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    -cantidad,
                                                    Definiciones.Stock.TipoMovimiento.Compra, caso_id, detalle.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    detalle.ID, true);
                    }
                }
                //Aprobado a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Se revierte el ingreso de insumo al stock
                    revisarRequisitos = true;
                    exito = true;

                    string stockMovimiento = string.Empty;
                    foreach (INGRESO_INSUMOS_DETALLESRow detalle in detallesRows)
                    {
                        var al = new ArticulosLotesService(detalle.LOTE_ID, sesion);
                        StockService.Costo costo = null;

                        decimal cantidad = 0;
                        if (detalle.USAR_CANTIDAD_BASCULA == Definiciones.SiNo.Si)
                        {
                            cantidad = detalle.CANTIDAD_BASCULA;
                            if (detalle.MERMA != 0)
                                cantidad = cantidad - (cantidad * detalle.MERMA / 100);
                            else
                                cantidad = cantidad - (cantidad * cabeceraRow.MERMA / 100);
                        }
                        else
                        if (detalle.USAR_CANTIDAD_BL == Definiciones.SiNo.Si)
                        {
                            cantidad = detalle.CANTIDAD_BL;
                            if (detalle.MERMA != 0)
                                cantidad = cantidad - (cantidad * detalle.MERMA / 100);
                            else
                                cantidad = cantidad - (cantidad * cabeceraRow.MERMA / 100);
                        }
                        else
                        if (detalle.USAR_CANTIDAD_DRAFT == Definiciones.SiNo.Si)
                        {
                            cantidad = detalle.CANTIDAD_DRAFT;
                            if (detalle.MERMA != 0)
                                cantidad = cantidad - (cantidad * detalle.MERMA / 100);
                            else
                                cantidad = cantidad - (cantidad * cabeceraRow.MERMA / 100);
                        }
                        else
                        if (detalle.USAR_CANTIDAD_REMISION == Definiciones.SiNo.Si)
                        {
                            cantidad = detalle.CANTIDAD_REMISION;
                            if (detalle.MERMA != 0)
                                cantidad = cantidad - (cantidad * detalle.MERMA / 100);
                            else
                                cantidad = cantidad - (cantidad * cabeceraRow.MERMA / 100);
                        }

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    -cantidad,
                                                    Definiciones.Stock.TipoMovimiento.Compra, caso_id, detalle.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    detalle.ID, true);
                    }
                }
                //Borrador a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna
                    exito = true;
                    revisarRequisitos = true;
                }
                //Pendiente a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna
                    exito = true;
                    revisarRequisitos = true;
                }
                if (exito && revisarRequisitos)
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);

                if (exito)
                {
                    sesion.Db.CASOSCollection.Update(casoRow);
                    sesion.Db.INGRESO_INSUMOSCollection.Update(cabeceraRow);
                }
            }
            catch (Exception exp)
            {
                exito = false;
                throw exp;
            }
            return exito;
        }
        #endregion ProcesarCambioEstado

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref String estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    if (!campos.Contains(IngresoInsumosService.SucursalId_NombreCol))
                        throw new Exception("Debe indicar la sucursal.");

                    if (!campos.Contains(IngresoInsumosService.PersonaId_NombreCol))
                        throw new Exception("Debe indicar el cliente.");

                    INGRESO_INSUMOSRow row = new INGRESO_INSUMOSRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("ingreso_insumos_sqc");
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[IngresoInsumosService.SucursalId_NombreCol].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.INGRESO_INSUMOS.ToString()),
                                                             int.Parse(sesion.Usuario_Id.ToString()),
                                                             SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.INGRESO_INSUMOSCollection.GetRow(IngresoInsumosService.Id_NombreCol + " = " + campos[IngresoInsumosService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    if (!Interprete.EsNullODBNull(IngresoInsumosService.SucursalId_NombreCol))
                        row.SUCURSAL_ID = (decimal)campos[IngresoInsumosService.SucursalId_NombreCol];
                    else
                        throw new Exception("Valor no admitido en sucursal");

                    if (campos.Contains(IngresoInsumosService.DepositoId_NombreCol))
                    {
                        if (!Interprete.EsNullODBNull(IngresoInsumosService.DepositoId_NombreCol))
                            row.DEPOSITO_ID = (decimal)campos[IngresoInsumosService.DepositoId_NombreCol];
                        else
                            row.IsDEPOSITO_IDNull = true;
                    }

                    if (campos.Contains(IngresoInsumosService.BoxId_NombreCol))
                    {
                        if (!Interprete.EsNullODBNull(IngresoInsumosService.BoxId_NombreCol))
                            row.BOX_ID = (decimal)campos[IngresoInsumosService.BoxId_NombreCol];
                        else
                            row.IsBOX_IDNull = true;
                    }

                    if (campos.Contains(IngresoInsumosService.TipoIngreso_NombreCol))
                        row.TIPO_INGRESO = (string)campos[IngresoInsumosService.TipoIngreso_NombreCol];


                    if (row.TIPO_INGRESO.Equals("FLUVIAL"))
                    {
                        if (campos.Contains(IngresoInsumosService.BuqueId_NombreCol))
                        {                          
                            if (!Interprete.EsNullODBNull(IngresoInsumosService.BuqueId_NombreCol))
                                row.BUQUE_ID = (decimal)campos[IngresoInsumosService.BuqueId_NombreCol];
                            else
                                row.IsBUQUE_IDNull = true;
                        }                       
                    }
                    else
                        row.IsBUQUE_IDNull = true;

                    if (!Interprete.EsNullODBNull(IngresoInsumosService.PersonaId_NombreCol))
                        row.PERSONA_ID = (decimal)campos[IngresoInsumosService.PersonaId_NombreCol];
                    else
                        throw new Exception("Valor no admitido en cliente");

                    if (campos.Contains(IngresoInsumosService.FechaInicio_NombreCol))
                        row.FECHA_INICIO = (DateTime)campos[IngresoInsumosService.FechaInicio_NombreCol];
                    if (campos.Contains(IngresoInsumosService.FechaFin_NombreCol))
                        row.FECHA_FIN = (DateTime)campos[IngresoInsumosService.FechaFin_NombreCol];

                    if (campos.Contains(IngresoInsumosService.AutonumeracionId_NombreCol))
                    {
                        if (!Interprete.EsNullODBNull(IngresoInsumosService.AutonumeracionId_NombreCol))
                        {
                            if (AutonumeracionesService.EstaActivo((decimal)campos[IngresoInsumosService.AutonumeracionId_NombreCol]))
                                row.AUTONUMERACION_ID = (decimal)campos[IngresoInsumosService.AutonumeracionId_NombreCol];
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

                    if (campos.Contains(IngresoInsumosService.NroComprobante_NombreCol))
                        row.NRO_COMPROBANTE = (string)campos[IngresoInsumosService.NroComprobante_NombreCol];
                    if (campos.Contains(IngresoInsumosService.Factura_NombreCol))
                        row.FACTURA = (string)campos[IngresoInsumosService.Factura_NombreCol];
                    if (campos.Contains(IngresoInsumosService.Observaciones_NombreCol))
                        row.OBSERVACIONES = (string)campos[IngresoInsumosService.Observaciones_NombreCol];                    
                    if (campos.Contains(IngresoInsumosService.Registro_NombreCol))
                        row.REGISTRO = (string)campos[IngresoInsumosService.Registro_NombreCol];
                    if (campos.Contains(IngresoInsumosService.Despacho_NombreCol))
                        row.DESPACHO = (string)campos[IngresoInsumosService.Despacho_NombreCol];
                    if (campos.Contains(IngresoInsumosService.AutorizacionDna_NombreCol))
                        row.AUTORIZACION_DNA = (string)campos[IngresoInsumosService.AutorizacionDna_NombreCol];
                    if (campos.Contains(IngresoInsumosService.Transportista_NombreCol))
                        row.TRANSPORTISTA = (string)campos[IngresoInsumosService.Transportista_NombreCol];
                    if (campos.Contains(IngresoInsumosService.Merma_NombreCol ))
                        row.MERMA = (decimal)campos[IngresoInsumosService.Merma_NombreCol];

                    if (insertarNuevo)
                        sesion.Db.INGRESO_INSUMOSCollection.Insert(row);
                    else
                        sesion.Db.INGRESO_INSUMOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA_INICIO);
                    camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
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
                    INGRESO_INSUMOSRow ingresoInsumo = sesion.Db.INGRESO_INSUMOSCollection.GetByCASO_ID(caso_id)[0];

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Se obtienen los detalles del caso a ser borrados.
                    DataTable detalles = IngresoInsumosDetallesService.GetIngresoInsumosDetalleDataTable(IngresoInsumosDetallesService.IngresoId_NombreCol + " = " + ingresoInsumo.ID, string.Empty);

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
                        sesion.Db.INGRESO_INSUMOSCollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, ingresoInsumo.ID, ingresoInsumo.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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
            get { return "INGRESO_INSUMOS"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string AutorizacionDna_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.AUTORIZACION_DNAColumnName; }
        }
        public static string BoxId_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.BOX_IDColumnName; }
        }
        public static string BuqueId_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.BUQUE_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.CASO_IDColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.DEPOSITO_IDColumnName; }
        }
        public static string Despacho_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.DESPACHOColumnName; }
        }
        public static string Factura_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.FACTURAColumnName; }
        }
        public static string FechaFin_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.FECHA_FINColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.FECHA_INICIOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.IDColumnName; }
        }
        public static string Merma_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.MERMAColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observaciones_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.OBSERVACIONESColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.PERSONA_IDColumnName; }
        }
        public static string Registro_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.REGISTROColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string TipoIngreso_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.TIPO_INGRESOColumnName; }
        }
        public static string Transportista_NombreCol
        {
            get { return INGRESO_INSUMOSCollection.TRANSPORTISTAColumnName; }
        }

        #endregion Accessors
    }
}
