#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Facturacion;
using System.Collections.Generic;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Articulos;
#endregion Using

namespace CBA.FlowV2.Services.NotasCreditoPersona
{
    public class NotasCreditoPersonaDetalleService
    {
        #region GetNotaCreditoPersonaDetalleDataTable
        /// <summary>
        /// Gets the nota credito persona detalle data table.
        /// </summary>
        /// <param name="nota_credito_persona_id">The nota_credito_persona_id.</param>
        /// <returns></returns>
        public static DataTable GetNotaCreditoPersonaDetalleDataTable(decimal nota_credito_persona_id)
        {
            return GetNotaCreditoPersonaDetalleDataTable(NotasCreditoPersonaDetalleService.NotaCreditoPersonaId_NombreCol + " = " + nota_credito_persona_id, string.Empty);
        }

        /// Gets the nota credito persona detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetNotaCreditoPersonaDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaCreditoPersonaDetalleDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaCreditoPersonaDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.NOTAS_CREDITO_PERSONAS_DETCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetNotaCreditoPersonaDetalleDataTable

        #region GetNotaCreditoPersonaDetalleInfoCompleta
        public static DataTable GetNotaCreditoPersonaDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaCreditoPersonaDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaCreditoPersonaDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.NOTAS_CRED_PER_DET_INF_COMPCollection.GetAsDataTable(clausulas, string.Empty);
        }
        #endregion GetNotaCreditoPersonaDetalleInfoCompleta

        #region NcTieneDetalles
        public static bool NcTieneDetalles(decimal notaCreditoId)
        {
            string clausulas = NotaCreditoPersonaId_NombreCol + " = " + notaCreditoId.ToString();
            return GetNotaCreditoPersonaDetalleDataTable(clausulas, string.Empty).Rows.Count > 0 ? true : false;
        }

        public static bool NcTieneDetalles(decimal notaCreditoId, SessionService sesion)
        {
            string clausulas = NotaCreditoPersonaId_NombreCol + " = " + notaCreditoId.ToString();
            return GetNotaCreditoPersonaDetalleDataTable(clausulas, string.Empty, sesion).Rows.Count > 0 ? true : false;
        }
        #endregion NcTieneDetalles

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        public void Guardar(System.Collections.Hashtable campos)
        {
            NotasCreditoPersonaDetalleService.Guardar2(campos);
        }

        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        public static void Guardar2(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Guardar2(campos, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public static void Guardar2(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                NOTAS_CREDITO_PERSONAS_DETRow row = new NOTAS_CREDITO_PERSONAS_DETRow();               
                NotasCreditoPersonaService notaCreditoPersona = new NotasCreditoPersonaService();               

                SucursalesService sucursal = new SucursalesService();

                decimal facturaClienteMonedaId = Definiciones.Error.Valor.EnteroPositivo;
                int cantidadDecimales = MonedasService.CantidadDecimalesStatic(facturaClienteMonedaId, sesion);

                if (campos.Contains(NotasCreditoPersonaDetalleService.FacturaClienteId_NombreCol))
                    facturaClienteMonedaId = FacturasClienteService.GetMonedaId(FacturasClienteService.Id_NombreCol + " = " + campos[NotasCreditoPersonaDetalleService.FacturaClienteId_NombreCol], sesion);
                                
                string valorAnterior;

                valorAnterior = Definiciones.Log.RegistroNuevo;

                row.ID = sesion.Db.GetSiguienteSecuencia("notas_credito_personas_det_sqc");
                row.NOTA_CREDITO_PERSONA_ID = (decimal)campos[NotasCreditoPersonaDetalleService.NotaCreditoPersonaId_NombreCol];

                NOTAS_CREDITO_PERSONASRow notaCreditoPersonaRow;
                notaCreditoPersonaRow = NotasCreditoPersonaService.GetNotaCreditoPersona(row.NOTA_CREDITO_PERSONA_ID, sesion);
                #region verificar cantidad de detalles segun autonumeracion
                if (!notaCreditoPersonaRow.IsAUTONUMERACION_IDNull)
                {
                    var dt = AutonumeracionesService.GetAutonumeracionesDataTable(AutonumeracionesService.Id_NombreCol + " = " + notaCreditoPersonaRow.AUTONUMERACION_ID, string.Empty, sesion);
                    if (!Interprete.EsNullODBNull(dt.Rows[0][AutonumeracionesService.DetallesCantidadMaxima_NombreCol]))
                    {
                        var dtDetalles = NotasCreditoPersonaDetalleService.GetNotaCreditoPersonaDetalleDataTable(NotasCreditoPersonaDetalleService.NotaCreditoPersonaId_NombreCol + " = " + row.NOTA_CREDITO_PERSONA_ID, string.Empty, sesion);
                        if (dtDetalles.Rows.Count >= (decimal)dt.Rows[0][AutonumeracionesService.DetallesCantidadMaxima_NombreCol])
                            throw new Exception("Cantidad máxima de artículos superada.");
                    }
                }
                #endregion verificar cantidad de detalles segun autonumeracion


                FACTURAS_CLIENTE_DETALLERow rowFacturaDetalle = new FACTURAS_CLIENTE_DETALLERow();

                if(campos.Contains(NotasCreditoPersonaDetalleService.TextoPredefinidoId_NombreCol))
                    row.TEXTO_PREDEFINIDO_ID = (decimal)campos[NotasCreditoPersonaDetalleService.TextoPredefinidoId_NombreCol];

                //Si la nota de credito es por una devolucion
                if (campos.Contains(NotasCreditoPersonaDetalleService.FacturaClienteDetalleId_NombreCol))
                {

                    if (campos.Contains(NotasCreditoPersonaDetalleService.FacturaClienteId_NombreCol))
                        row.FACTURA_CLIENTE_ID = (decimal)campos[NotasCreditoPersonaDetalleService.FacturaClienteId_NombreCol];

                    row.FACTURA_CLIENTE_DETALLE_ID = (decimal)campos[NotasCreditoPersonaDetalleService.FacturaClienteDetalleId_NombreCol];

                    //Se cargan la sucursal y el deposito de la factura
                    FACTURAS_CLIENTERow rowFactura = sesion.Db.FACTURAS_CLIENTECollection.GetByPrimaryKey(row.FACTURA_CLIENTE_ID);
                    DataTable dtFactura = FacturasClienteService.GetFacturaClienteDataTable(row.FACTURA_CLIENTE_ID);

                    row.FACTURA_SUCURSAL_ID = rowFactura.SUCURSAL_ID;
                    row.FACTURA_DEPOSITO_ID = rowFactura.DEPOSITO_ID;

                    //Se cargan el articulo, lote y costo
                    rowFacturaDetalle = sesion.Db.FACTURAS_CLIENTE_DETALLECollection.GetByPrimaryKey(row.FACTURA_CLIENTE_DETALLE_ID);
                    if (Math.Round((decimal)campos[NotasCreditoPersonaDetalleService.Total_NombreCol], cantidadDecimales)  > Math.Round((rowFacturaDetalle.TOTAL_NETO_LUEGO_DE_NC + rowFacturaDetalle.TOTAL_RECARGO_FINANCIERO), cantidadDecimales))
                        throw new Exception("El monto no puede ser mayor al detalle de la factura.");

                    row.ARTICULO_ID = rowFacturaDetalle.ARTICULO_ID;
                    row.LOTE_ID = rowFacturaDetalle.LOTE_ID;
                    row.COSTO_UNITARIO = (decimal)campos[NotasCreditoPersonaDetalleService.CostoUnitario_NombreCol]; ;
                    row.CANTIDAD = (decimal)campos[NotasCreditoPersonaDetalleService.Cantidad_NombreCol];

                    //Se incluye el posible descuento de la cabecera de la FC
                    row.IMPUESTO_ID = (decimal)campos[NotasCreditoPersonaDetalleService.ImpuestoId_NombreCol];
                    row.TOTAL = (decimal)campos[NotasCreditoPersonaDetalleService.Total_NombreCol];
                    
                    decimal porcentajeImpuesto = ImpuestosService.GetPorcentajePorId(row.IMPUESTO_ID);

                    if (porcentajeImpuesto > 0) row.IMPUESTO_MONTO = row.TOTAL / ((100 / porcentajeImpuesto) + 1);
                    else row.IMPUESTO_MONTO = 0;
                    row.A_CONSIGNACION = rowFactura.A_CONSIGNACION;
                    if (!rowFacturaDetalle.IsACTIVO_IDNull)
                        row.ACTIVO_ID = rowFacturaDetalle.ACTIVO_ID;

                    if (!Interprete.EsNullODBNull(campos[NotasCreditoPersonaDetalleService.Observacion_NombreCol]))
                        row.OBSERVACION = campos[NotasCreditoPersonaDetalleService.Observacion_NombreCol].ToString();
                }
                else
                {
                    decimal montoConcepto = decimal.Parse(campos[NotasCreditoPersonaDetalleService.MontoConcepto_NombreCol].ToString());
                    
                    if (campos.Contains(NotasCreditoPersonaDetalleService.FacturaClienteId_NombreCol))
                    {
                        row.FACTURA_CLIENTE_ID = decimal.Parse(campos[NotasCreditoPersonaDetalleService.FacturaClienteId_NombreCol].ToString()); //Se relaciona a una factura. (DC)

                        decimal fcTotalNetoLuegoNC = FacturasClienteService.GetTotalNetoLuegoNC(row.FACTURA_CLIENTE_ID, sesion);
                        
                        if (montoConcepto > Math.Round(fcTotalNetoLuegoNC, MonedasService.CantidadDecimalesStatic(facturaClienteMonedaId)))
                            throw new Exception("El monto no puede ser mayor al detalle de la factura.");
                    }

                    row.MONTO_CONCEPTO = montoConcepto;
                    row.IMPUESTO_ID = decimal.Parse(campos[NotasCreditoPersonaDetalleService.ImpuestoId_NombreCol].ToString());
                    decimal porcentajeImpuesto = ImpuestosService.GetPorcentajePorId(row.IMPUESTO_ID);

                    if (porcentajeImpuesto > 0) 
                        row.IMPUESTO_MONTO = row.MONTO_CONCEPTO / ((100 / porcentajeImpuesto) + 1);
                    else 
                        row.IMPUESTO_MONTO = 0;
                    
                    row.CANTIDAD = 1;
                    row.COSTO_UNITARIO = row.MONTO_CONCEPTO;
                    row.TOTAL = row.MONTO_CONCEPTO;
                    row.A_CONSIGNACION = Definiciones.SiNo.No;

                    if (campos.Contains(NotasCreditoPersonaDetalleService.ActivoId_NombreCol))
                    {
                        row.ACTIVO_ID = decimal.Parse(campos[NotasCreditoPersonaDetalleService.ActivoId_NombreCol].ToString());
                    }
                    else
                    {
                        row.IsACTIVO_IDNull = true;
                    }
                }

                if (!Interprete.EsNullODBNull(campos[NotasCreditoPersonaDetalleService.Observacion_NombreCol]))
                    row.OBSERVACION = campos[NotasCreditoPersonaDetalleService.Observacion_NombreCol].ToString();

                sesion.Db.NOTAS_CREDITO_PERSONAS_DETCollection.Insert(row);

                //Se aumenta la cantidad devuelta en la factura, si la nota de credito es por devolucion
                if (campos.Contains(NotasCreditoPersonaDetalleService.FacturaClienteDetalleId_NombreCol)) //Las NO devoluciones no tienen detalles de factura. (DC)
                {
                    FacturasClienteDetalleService.SumarCantidadDevueltaNC(row.FACTURA_CLIENTE_DETALLE_ID, row.CANTIDAD, sesion);
                }
                else if (campos.Contains(NotasCreditoPersonaDetalleService.FacturaClienteId_NombreCol))
                { //si no es por devolucion, se actualiza solamente el campo de total_neto_despues_ns para reflejar el cambio
                    FacturasClienteService.RecalcularTotalNetoDespuesDeNC(row.FACTURA_CLIENTE_ID, row.TOTAL, sesion);
                }
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                notaCreditoPersona.RecalcularTotal(row.NOTA_CREDITO_PERSONA_ID, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static void Actualizar(NOTAS_CREDITO_PERSONAS_DETRow detalle)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    string valorAnterior = sesion.Db.NOTAS_CREDITO_PERSONAS_DETCollection.GetByPrimaryKey(detalle.ID).ToString();
                    sesion.Db.NOTAS_CREDITO_PERSONAS_DETCollection.Update(detalle);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, detalle.ID, valorAnterior, detalle.ToString(), sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified nota_credito_persona_detalle_id.
        /// </summary>
        /// <param name="nota_credito_persona_detalle_id">The nota_credito_persona_detalle_id.</param>
        public static void Borrar(decimal nota_credito_persona_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    NOTAS_CREDITO_PERSONAS_DETRow row;
                    NotasCreditoPersonaService notaCreditoPersona = new NotasCreditoPersonaService();

                    //Se obtiene el detalle de la nota de credito
                    row = sesion.Db.NOTAS_CREDITO_PERSONAS_DETCollection.GetByPrimaryKey(nota_credito_persona_detalle_id);

                    // al borrar un detalle, antes deben borrarse los detalles que afectan a la misma fatura en orden inverso, 
                    // de tal manera a mantener la correctitud de los calculos realizados, por lo tanto se mantiene una pila de 
                    // elementos que se deben volver a agregar luego de eliminar estos detalles

                    //se obtienen los elementos que se deben eliminar, en el orden correcto
                    string clausula_nc_detalles_eliminar = NotasCreditoPersonaDetalleService.FacturaClienteId_NombreCol + " = " + row.FACTURA_CLIENTE_ID +
                        " and " + NotasCreditoPersonaDetalleService.NotaCreditoPersonaId_NombreCol + " = " + row.NOTA_CREDITO_PERSONA_ID +
                        " and " + NotasCreditoPersonaDetalleService.Id_NombreCol + " > " + row.ID;


                    #region Obtener Elementos de la pila
                    NOTAS_CREDITO_PERSONAS_DETRow[] pila = sesion.db.NOTAS_CREDITO_PERSONAS_DETCollection.GetAsArray(clausula_nc_detalles_eliminar, NotasCreditoPersonaDetalleService.Id_NombreCol);
                    #endregion Obtener Elementos de la pila



                    #region Borrar Elementos de la Pila
                    //se recorre en orden inverso todos los registros posteriores al detalle que se borrara defininitivamente
                    for (int i = pila.Length - 1; i >= 0; i--)
                    {
                        // se deshace el detalle

                        // si el detalle es por devolucion, se debe modificar la cantidad en el detalle de la factura
                        if (!pila[i].IsFACTURA_CLIENTE_DETALLE_IDNull)
                        {
                            FacturasClienteDetalleService.SumarCantidadDevueltaNC(pila[i].FACTURA_CLIENTE_DETALLE_ID, -pila[i].CANTIDAD, sesion);
                        }
                        else
                        { // en caso contrario, se tiene que deshacer el detalle por concepto y redistribuir el monto
                            FacturasClienteService.RecalcularTotalNetoDespuesDeNC(pila[i].FACTURA_CLIENTE_ID, -pila[i].TOTAL, sesion);
                        }
                        //se borra el detalle de la tabla
                        sesion.Db.NOTAS_CREDITO_PERSONAS_DETCollection.DeleteByPrimaryKey(pila[i].ID);
                    }
                    #endregion Borrar Elementos de la Pila

                    //Si el detalle de la nota de credito es por devolucion
                    if (!row.IsFACTURA_CLIENTE_DETALLE_IDNull)
                    {
                        //Se obtiene el item de factura asociada al detalle y se repone la cantidad a la factura
                        FacturasClienteDetalleService.SumarCantidadDevueltaNC(row.FACTURA_CLIENTE_DETALLE_ID, -row.CANTIDAD, sesion);
                    }
                    else
                    {// en caso contrario, se tiene que deshacer el detalle por concepto y redistribuir el monto
                        FacturasClienteService.RecalcularTotalNetoDespuesDeNC(row.FACTURA_CLIENTE_ID, -row.TOTAL, sesion);
                    }

                    #region Recrear Elementos de la Pila
                    // leugo de eliminar el detalle actual, se deben agregar en el orden correcto los detalles antes eliminados
                    for (int i = 0; i < pila.Length; i++)
                    {
                        // si el detalle es por devolucion, se debe modificar la cantidad en el detalle de la factura
                        // si el detalle es por devolucion, se debe modificar la cantidad en el detalle de la factura
                        if (!pila[i].IsFACTURA_CLIENTE_DETALLE_IDNull)
                        {
                            FacturasClienteDetalleService.SumarCantidadDevueltaNC(pila[i].FACTURA_CLIENTE_DETALLE_ID, pila[i].CANTIDAD, sesion);
                        }
                        else
                        { // en caso contrario, se tiene que deshacer el detalle por concepto y redistribuir el monto
                            FacturasClienteService.RecalcularTotalNetoDespuesDeNC(pila[i].FACTURA_CLIENTE_ID, pila[i].TOTAL, sesion);
                        }
                        // recrear el elemento de la pila con un nuevo ID
                        pila[i].ID = sesion.Db.GetSiguienteSecuencia("notas_credito_personas_det_sqc");
                        sesion.db.NOTAS_CREDITO_PERSONAS_DETCollection.Insert(pila[i]);
                    }
                    #endregion Recrear Elementos de la Pila


                    sesion.Db.NOTAS_CREDITO_PERSONAS_DETCollection.DeleteByPrimaryKey(nota_credito_persona_detalle_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    notaCreditoPersona.RecalcularTotal(row.NOTA_CREDITO_PERSONA_ID, sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region GetStockMovimiento
        public StockMovimientoService GetStockMovimiento()
        {
            using (SessionService sesion = new SessionService())
            {
                return GetStockMovimiento(sesion);
            }
        }
        
        public StockMovimientoService GetStockMovimiento(SessionService sesion)
        {
            return GetStockMovimiento(this.FacturaCliente.CasoId, sesion);
        }

        public StockMovimientoService GetStockMovimiento(decimal caso_id, SessionService sesion)
        {
            var sm = new StockMovimientoService();
            sm.IniciarUsingSesion(sesion);
            
            var movimiento = StockMovimientoService.Instancia.GetPrimero<StockMovimientoService>(new ClaseCBABase.Filtro[] {
                new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.CASO_IDColumnName, Valor = caso_id },
                new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.REGISTRO_IDColumnName, Valor = this.Id.Value }
            });

            sm.FinalizarUsingSesion();

            return movimiento;
        }
        #endregion GetStockMovimiento

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "NOTAS_CREDITO_PERSONAS_DET"; }
        }
        public static string Nombre_Vista
        {
            get { return "NOTAS_CRED_PER_DET_INF_COMP"; }
        }
        public static string ActivoId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.ACTIVO_IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.ARTICULO_IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.CANTIDADColumnName; }
        }
        public static string CostoUnitario_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.COSTO_UNITARIOColumnName; }
        }
        public static string FacturaClienteDetalleId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.FACTURA_CLIENTE_DETALLE_IDColumnName; }
        }
        public static string FacturaClienteId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.FACTURA_CLIENTE_IDColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.FACTURA_DEPOSITO_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.FACTURA_SUCURSAL_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.IDColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.IMPUESTO_IDColumnName; }
        }
        public static string ImpuestoMonto_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.IMPUESTO_MONTOColumnName; }
        }
        public static string LoteId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.LOTE_IDColumnName; }
        }
        public static string MontoConcepto_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.MONTO_CONCEPTOColumnName; }
        }
        public static string NotaCreditoPersonaId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.NOTA_CREDITO_PERSONA_IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.OBSERVACIONColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string Total_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.TOTALColumnName; }
        }
        public static string AConsignacion_NombreCol
        {
            get { return NOTAS_CREDITO_PERSONAS_DETCollection.A_CONSIGNACIONColumnName; }
        }
        public static string VistaArticuloDescripcion_NombreCol
        {
            get { return NOTAS_CRED_PER_DET_INF_COMPCollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string VistaConcepto_NombreCol
        {
            get { return NOTAS_CRED_PER_DET_INF_COMPCollection.CONCEPTOColumnName; }
        }
        public static string VistaFacturaClienteCasoId_NombreCol
        {
            get { return NOTAS_CRED_PER_DET_INF_COMPCollection.FACTURA_CLIENTE_CASO_IDColumnName; }
        }
        public static string VistaFacturaClienteFecha_NombreCol
        {
            get { return NOTAS_CRED_PER_DET_INF_COMPCollection.FACTURA_CLIENTE_FECHAColumnName; }
        }
        public static string VistaFacturaClienteNroComprobante_NombreCol
        {
            get { return NOTAS_CRED_PER_DET_INF_COMPCollection.FACTURA_CLIENTE_NRO_COMPColumnName; }
        }
        public static string VistaImpuestoNombre_NombreCol
        {
            get { return NOTAS_CRED_PER_DET_INF_COMPCollection.IMPUESTO_NOMBREColumnName; }
        }
        public static string VistaImpuestoPorcentaje_NombreCol
        {
            get { return NOTAS_CRED_PER_DET_INF_COMPCollection.IMPUESTO_PORCENTAJEColumnName; }
        }
        public static string VistaLoteDescripcion_NombreCol
        {
            get { return NOTAS_CRED_PER_DET_INF_COMPCollection.LOTEColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return NOTAS_CRED_PER_DET_INF_COMPCollection.FACTURA_SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaTextoPredefinido_NombreCol
        {
            get { return NOTAS_CRED_PER_DET_INF_COMPCollection.TEXTO_PREDEFINIDOColumnName; }
        }
        public static string VistaArticuloFamiliaId_NombreCol
        {
            get { return NOTAS_CRED_PER_DET_INF_COMPCollection.ARTICULO_FAMILIA_IDColumnName; }
        }
        public static string VistaArticuloGrupoId_NombreCol
        {
            get { return NOTAS_CRED_PER_DET_INF_COMPCollection.ARTICULO_GRUPO_IDColumnName; }
        }
        public static string VistaArticuloSubgrupoId_NombreCol
        {
            get { return NOTAS_CRED_PER_DET_INF_COMPCollection.ARTICULO_SUBGRUPO_IDColumnName; }
        }
        public static string VistaCodigoActivo_NombreCol
        {
            get { return NOTAS_CRED_PER_DET_INF_COMPCollection.CODIGO_ACTIVOColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static NotasCreditoPersonaDetalleService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new NotasCreditoPersonaDetalleService(e.RegistroId, sesion);
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
        protected NOTAS_CREDITO_PERSONAS_DETRow row;
        protected NOTAS_CREDITO_PERSONAS_DETRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string AConsignacion { get { return ClaseCBABase.GetStringHelper(row.A_CONSIGNACION); } set { row.A_CONSIGNACION = value; } }
        public decimal? ActivoId { get { if (row.IsACTIVO_IDNull) return null; else return row.ACTIVO_ID; } set { if (value.HasValue) row.ACTIVO_ID = value.Value; else row.IsACTIVO_IDNull = true; } }
        public decimal? ArticuloId { get { if (row.IsARTICULO_IDNull) return null; else return row.ARTICULO_ID; } set { if (value.HasValue) row.ARTICULO_ID = value.Value; else row.IsARTICULO_IDNull = true; } }
        public decimal? Cantidad { get { if (row.IsCANTIDADNull) return null; else return row.CANTIDAD; } set { if (value.HasValue) row.CANTIDAD = value.Value; else row.IsCANTIDADNull = true; } }
        public decimal? CostoUnitario { get { if (row.IsCOSTO_UNITARIONull) return null; else return row.COSTO_UNITARIO; } set { if (value.HasValue) row.COSTO_UNITARIO = value.Value; else row.IsCOSTO_UNITARIONull = true; } }
        public decimal? FacturaClienteDetalleId { get { if (row.IsFACTURA_CLIENTE_DETALLE_IDNull) return null; else return row.FACTURA_CLIENTE_DETALLE_ID; } set { if (value.HasValue) row.FACTURA_CLIENTE_DETALLE_ID = value.Value; else row.IsFACTURA_CLIENTE_DETALLE_IDNull = true; } }
        public decimal? FacturaClienteId { get { if (row.IsFACTURA_CLIENTE_IDNull) return null; else return row.FACTURA_CLIENTE_ID; } set { if (value.HasValue) row.FACTURA_CLIENTE_ID = value.Value; else row.IsFACTURA_CLIENTE_IDNull = true; } }
        public decimal? FacturaDepositoId { get { if (row.IsFACTURA_DEPOSITO_IDNull) return null; else return row.FACTURA_DEPOSITO_ID; } set { if (value.HasValue) row.FACTURA_DEPOSITO_ID = value.Value; else row.IsFACTURA_DEPOSITO_IDNull = true; } }
        public decimal? FacturaSucursalId { get { if (row.IsFACTURA_SUCURSAL_IDNull) return null; else return row.FACTURA_SUCURSAL_ID; } set { if (value.HasValue) row.FACTURA_SUCURSAL_ID = value.Value; else row.IsFACTURA_SUCURSAL_IDNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal ImpuestoId { get { return row.IMPUESTO_ID; } set { row.IMPUESTO_ID = value; } }
        public decimal ImpuestoMonto { get { return row.IMPUESTO_MONTO; } set { row.IMPUESTO_MONTO = value; } }
        public decimal? LoteId { get { if (row.IsLOTE_IDNull) return null; else return row.LOTE_ID; } set { if (value.HasValue) row.LOTE_ID = value.Value; else row.IsLOTE_IDNull = true; } }
        public decimal? MontoConcepto { get { if (row.IsMONTO_CONCEPTONull) return null; else return row.MONTO_CONCEPTO; } set { if (value.HasValue) row.MONTO_CONCEPTO = value.Value; else row.IsMONTO_CONCEPTONull = true; } }
        public decimal NotaCreditoPersonaId { get { return row.NOTA_CREDITO_PERSONA_ID; } set { row.NOTA_CREDITO_PERSONA_ID = value; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal? TextoPredefinidoId { get { if (row.IsTEXTO_PREDEFINIDO_IDNull) return null; else return row.TEXTO_PREDEFINIDO_ID; } set { if (value.HasValue) row.TEXTO_PREDEFINIDO_ID = value.Value; else row.IsTEXTO_PREDEFINIDO_IDNull = true; } }
        public decimal Total { get { return row.TOTAL; } set { row.TOTAL = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private ArticulosService _articulo;
        public ArticulosService Articulo
        {
            get
            {
                if (this._articulo == null)
                    this._articulo = new ArticulosService(this.ArticuloId.Value);
                return this._articulo;
            }
        }

        private ArticulosLotesService _lote;
        public ArticulosLotesService Lote
        {
            get
            {
                if (this._lote == null)
                    this._lote = new ArticulosLotesService(this.LoteId.Value);
                return this._lote;
            }
        }

        private ImpuestosService _impuesto;
        public ImpuestosService Impuesto
        {
            get
            {
                if (this._impuesto == null)
                    this._impuesto = new ImpuestosService(this.ImpuestoId);
                return this._impuesto;
            }
        }

        private FacturasClienteService _factura_cliente;
        public FacturasClienteService FacturaCliente
        {
            get
            {
                if (this._factura_cliente == null)
                    this._factura_cliente = new FacturasClienteService(this.FacturaClienteId.Value);
                return this._factura_cliente;
            }
        }

        private FacturasClienteDetalleService _factura_cliente_detalle;
        public FacturasClienteDetalleService FacturaClienteDetalle
        {
            get
            {
                if (this._factura_cliente_detalle == null)
                    this._factura_cliente_detalle = new FacturasClienteDetalleService(this.FacturaClienteDetalleId.Value);
                return this._factura_cliente_detalle;
            }
        }
        
        private NotasCreditoPersonaService _nota_credito_persona;
        public NotasCreditoPersonaService NotaCreditoPersona
        {
            get
            {
                if (this._nota_credito_persona == null)
                    this._nota_credito_persona = new NotasCreditoPersonaService(this.NotaCreditoPersonaId);
                return this._nota_credito_persona;
            }
        }

        private StockService.Costo _costo_ppp;
        public StockService.Costo CostoPPP
        {
            get
            {
                if (this._costo_ppp == null)
                {
                    var sm = this.GetStockMovimiento();
                    if (sm != null)
                    {
                        this._costo_ppp = new StockService.Costo()
                        {
                            costo = sm.Costo,
                            cotizacion = sm.CostoCotizacionMoneda,
                            moneda_id = sm.CostoMonedaId
                        };
                    }
                }
                return this._costo_ppp;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.NOTAS_CREDITO_PERSONAS_DETCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new NOTAS_CREDITO_PERSONAS_DETRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(NOTAS_CREDITO_PERSONAS_DETRow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public NotasCreditoPersonaDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public NotasCreditoPersonaDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public NotasCreditoPersonaDetalleService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public NotasCreditoPersonaDetalleService(EdiCBA.NotaCreditoClienteDetalle edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = NotasCreditoPersonaDetalleService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            #region articulo
            if (!string.IsNullOrEmpty(edi.articulo_uuid))
                this._articulo = ArticulosService.GetPorUUID(edi.articulo_uuid, sesion);
            
            if (this._articulo == null)
                throw new Exception("No se encontró el UUID " + edi.articulo_uuid + " ni se definieron los datos del objeto.");

            if (!this.Articulo.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Articulo.Id.HasValue)
                this.ArticuloId = this.Articulo.Id.Value;
            #endregion articulo

            this.Cantidad = edi.cantidad_unitaria_total_destino;
            this.CostoUnitario = edi.costo_unitario_monto;

            #region nota credito
            if (!string.IsNullOrEmpty(edi.nota_credito_cliente_uuid))
                this._nota_credito_persona = NotasCreditoPersonaService.GetPorUUID(edi.nota_credito_cliente_uuid, sesion);
            if (this._nota_credito_persona == null && edi.nota_credito_cliente != null)
                this._nota_credito_persona = new NotasCreditoPersonaService(edi.nota_credito_cliente, almacenar_localmente, sesion);
            if (this._nota_credito_persona != null)
            {
                if (!this.NotaCreditoPersona.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.NotaCreditoPersona.Id.HasValue)
                    this.NotaCreditoPersonaId = this.NotaCreditoPersona.Id.Value;
            }
            #endregion nota credito

            #region impuesto
            if (!string.IsNullOrEmpty(edi.impuesto_uuid))
                this._impuesto = ImpuestosService.GetPorUUID(edi.impuesto_uuid, sesion);
            if (this._impuesto == null && edi.impuesto != null)
                this._impuesto = new ImpuestosService(edi.impuesto, almacenar_localmente, sesion);
            if (this._impuesto == null)
                throw new Exception("No se encontró el UUID " + edi.impuesto_uuid + " ni se definieron los datos del objeto.");

            if (!this.Impuesto.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Impuesto.Id.HasValue)
                this.ImpuestoId = this.Impuesto.Id.Value;
            #endregion impuesto

            if (!this.ArticuloId.HasValue)
                this.MontoConcepto = edi.total_neto;

            this.ImpuestoMonto = edi.total_impuesto;
            this.Total = edi.total_neto;

            #region lote
            if (!string.IsNullOrEmpty(edi.lote_uuid))
                this._lote = ArticulosLotesService.GetPorUUID(edi.lote_uuid, sesion);
         
            if (this._lote == null)
                throw new Exception("No se encontró el UUID " + edi.lote_uuid + " ni se definieron los datos del objeto.");

            if (!this.Lote.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Lote.Id.HasValue)
                this.LoteId = this.Lote.Id.Value;
            #endregion lote

            this.Observacion = edi.observacion;

            #region factura cliente
            if (!string.IsNullOrEmpty(edi.factura_cliente_uuid))
                this._factura_cliente = FacturasClienteService.GetPorUUID(edi.factura_cliente_uuid, sesion);
            if (this._factura_cliente == null && edi.factura_cliente != null)
                this._factura_cliente = new FacturasClienteService(edi.factura_cliente, almacenar_localmente, sesion);
            if (this._factura_cliente != null)
            {
                if (!this.FacturaCliente.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.FacturaCliente.Id.HasValue)
                    this.FacturaClienteId = this.FacturaCliente.Id.Value;
            }
            #endregion factura cliente

            #region factura cliente detalle
            if (!string.IsNullOrEmpty(edi.factura_cliente_detalle_uuid))
                this._factura_cliente_detalle = FacturasClienteDetalleService.GetPorUUID(edi.factura_cliente_detalle_uuid, sesion);
            if (this._factura_cliente_detalle == null && edi.factura_cliente_detalle != null)
                this._factura_cliente_detalle = new FacturasClienteDetalleService(edi.factura_cliente_detalle, almacenar_localmente, sesion);
            if (this._factura_cliente_detalle != null)
            {
                if (!this.FacturaClienteDetalle.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.FacturaClienteDetalle.Id.HasValue)
                    this.FacturaClienteDetalleId = this.FacturaClienteDetalle.Id.Value;
            }
            #endregion factura cliente detalle
        }
        private NotasCreditoPersonaDetalleService(NOTAS_CREDITO_PERSONAS_DETRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCaso
        public static NotasCreditoPersonaDetalleService[] GetPorCabecera(decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCabecera(cabecera_id, sesion);
            }
        }

        public static NotasCreditoPersonaDetalleService[] GetPorCabecera(decimal cabecera_id, SessionService sesion)
        {
            var rows = sesion.db.NOTAS_CREDITO_PERSONAS_DETCollection.GetAsArray(NotasCreditoPersonaDetalleService.NotaCreditoPersonaId_NombreCol + " = " + cabecera_id, NotasCreditoPersonaDetalleService.Id_NombreCol);
            NotasCreditoPersonaDetalleService[] ncpd = new NotasCreditoPersonaDetalleService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                ncpd[i] = new NotasCreditoPersonaDetalleService(rows[i]);
            return ncpd;
        }
        #endregion GetPorCaso

       

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._articulo = null;
            this._costo_ppp = null;
            this._factura_cliente = null;
            this._factura_cliente_detalle = null;
            this._impuesto = null;
            this._lote = null;
            this._nota_credito_persona = null;
        }
        #endregion ResetearPropiedadesExtendidas
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
