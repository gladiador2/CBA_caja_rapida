#region Using
using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Facturacion;
using System.Text;
using CBA.FlowV2.Services.EgresosVariosCaja;
using System.Collections.Generic;
using System.Globalization;
using CBA.FlowV2.Services.NotaCreditosProveedores;
using CBA.FlowV2.Services.Articulos;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteRetencionesEmitidasService
    {
        #region GetCuentaCorrienteRetencionesEmitidasDataTable
        /// <summary>
        /// Gets the cuenta corriente retenciones emitidas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCuentaCorrienteRetencionesEmitidasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCuentaCorrienteRetencionesEmitidasDataTable

        #region GetCuentaCorrienteRetencionesEmitidasInfoCompleta
        /// <summary>
        /// Gets the cuenta corriente retenciones emitidas info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCuentaCorrienteRetencionesEmitidasInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_RETENC_EMIT_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetCuentaCorrienteRetencionesEmitidasInfoCompletaStatic(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrienteRetencionesEmitidasInfoCompletaStatic(clausulas, orden, sesion);
            }
        }
        public static DataTable GetCuentaCorrienteRetencionesEmitidasInfoCompletaStatic(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_RETENC_EMIT_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCuentaCorrienteRetencionesEmitidasInfoCompleta

        #region GetNroComprobante
        /// <summary>
        /// Gets the nro comprobante.
        /// </summary>
        /// <param name="retencion_emitida_id">The retencion_emitida_id.</param>
        /// <returns></returns>
        public string GetNroComprobante(decimal retencion_emitida_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return this.GetNroComprobante(retencion_emitida_id, sesion);
            }
        }
        public string GetNroComprobante(decimal retencion_emitida_id, SessionService sesion)
        {
            return sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.GetByPrimaryKey(retencion_emitida_id).NRO_COMPROBANTE;
        }
        #endregion GetNroComprobante

        #region ActualizarTotal
        /// <summary>
        /// Actualizars the total.
        /// </summary>
        /// <param name="ctacte_retencion_id">The ctacte_retencion_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarTotal(decimal ctacte_retencion_id, SessionService sesion)
        {
            CTACTE_RETENCIONES_EMITIDASRow row = sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.GetByPrimaryKey(ctacte_retencion_id);
            DataTable dt = sesion.Db.CTACTE_RETENCIONES_EMIT_DETCollection.GetAsDataTable(CuentaCorrienteRetencionesEmitidasDetalleService.CtacteRetencionEmitidaId_NombreCol + " = " + ctacte_retencion_id, string.Empty);
            string valorAnterior = row.ToString();

            row.TOTAL = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
                row.TOTAL += (decimal)dt.Rows[i][CuentaCorrienteRetencionesEmitidasDetalleService.Monto_NombreCol];

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.Update(row);
        }
        #endregion ActualizarTotal

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <returns></returns>
        public decimal Guardar(decimal orden_pago_id, Hashtable campos, SessionService sesion)
        {
            try
            {
                CTACTE_RETENCIONES_EMITIDASRow row = new CTACTE_RETENCIONES_EMITIDASRow();
                string valorAnterior = string.Empty;
                decimal paisId;

                if (campos.Contains(CuentaCorrienteRetencionesEmitidasService.Id_NombreCol))
                {
                    row = sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.GetByPrimaryKey((decimal)campos[CuentaCorrienteRetencionesEmitidasService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }
                else
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_retenciones_emi_sqc");
                    row.FECHA = DateTime.Now;
                    row.TOTAL = 0;
                    row.DECLARADO_TESAKA = Definiciones.SiNo.No;
                    row.ESTADO = Definiciones.Estado.Activo;
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }

                if (campos.Contains(CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol))
                    row.FECHA = (DateTime)campos[CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol];

                //Si cambia
                if (row.SUCURSAL_ID.Equals(DBNull.Value) || row.SUCURSAL_ID != (decimal)campos[CuentaCorrienteRetencionesEmitidasService.SucursalId_NombreCol])
                {
                    row.SUCURSAL_ID = (decimal)campos[CuentaCorrienteRetencionesEmitidasService.SucursalId_NombreCol];
                    if (!SucursalesService.EstaActivo(row.SUCURSAL_ID))
                        throw new Exception("La sucursal no se encuentra activa.");
                }
                paisId = SucursalesService.GetPais((decimal)campos[CuentaCorrienteRetencionesEmitidasService.SucursalId_NombreCol]);

                //Si cambia
                if (row.MONEDA_ID.Equals(DBNull.Value) || row.MONEDA_ID != (decimal)campos[CuentaCorrienteRetencionesEmitidasService.MonedaId_NombreCol])
                {
                    row.MONEDA_ID = (decimal)campos[CuentaCorrienteRetencionesEmitidasService.MonedaId_NombreCol];
                    if (!MonedasService.EstaActivo(row.MONEDA_ID))
                        throw new Exception("La moneda no se encuentra activa.");

                    if (campos.Contains(CuentaCorrienteRetencionesEmitidasService.Cotizacion_NombreCol))
                    {
                        row.COTIZACION = (decimal)campos[CuentaCorrienteRetencionesEmitidasService.Cotizacion_NombreCol];
                    }
                    else
                    {
                        row.COTIZACION = CotizacionesService.GetCotizacionMonedaVenta(paisId, row.MONEDA_ID, row.FECHA, sesion);
                        if (row.COTIZACION == Definiciones.Error.Valor.EnteroPositivo)
                            throw new Exception("Debe actualizar la cotización de la moneda.");
                    }
                }

                row.MONEDA_PAIS_ID = PaisesService.GetMoneda(paisId, sesion);
                if (row.MONEDA_ID == row.MONEDA_PAIS_ID)
                    row.COTIZACION_MONEDA_PAIS = row.COTIZACION;
                else
                    row.COTIZACION_MONEDA_PAIS = CotizacionesService.GetCotizacionMonedaVenta(paisId, row.MONEDA_PAIS_ID, row.FECHA, sesion);

                //Si cambia
                if (row.PROVEEDOR_ID.Equals(DBNull.Value) || row.PROVEEDOR_ID != (decimal)campos[CuentaCorrienteRetencionesEmitidasService.ProveedorId_NombreCol])
                {
                    row.PROVEEDOR_ID = (decimal)campos[CuentaCorrienteRetencionesEmitidasService.ProveedorId_NombreCol];
                    if (!ProveedoresService.EstaActivo(row.PROVEEDOR_ID))
                        throw new Exception("El proveedor no se encuentra activo.");
                }

                //Si cambia
                if (row.IsAUTONUMERACION_IDNull || row.AUTONUMERACION_ID != (decimal)campos[CuentaCorrienteRetencionesEmitidasService.AutonumeracionId_NombreCol])
                {
                    row.AUTONUMERACION_ID = (decimal)campos[CuentaCorrienteRetencionesEmitidasService.AutonumeracionId_NombreCol];
                    if (!AutonumeracionesService.EstaActivo(row.AUTONUMERACION_ID))
                        throw new Exception("El talonario no se encuentra activo.");
                }

                //Si se utiliza autonumeracion se obtiene el numero de comprobante, sino se guarda el proveido por el usuario
                if (campos.Contains(CuentaCorrienteRetencionesEmitidasService.NroComprobante_NombreCol))
                {
                    if (!campos[CuentaCorrienteRetencionesEmitidasService.NroComprobante_NombreCol].ToString().Trim().Equals(string.Empty))
                        row.NRO_COMPROBANTE = (string)campos[CuentaCorrienteRetencionesEmitidasService.NroComprobante_NombreCol];
                    else
                        row.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(row.AUTONUMERACION_ID, sesion);
                }
                else
                {
                    row.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(row.AUTONUMERACION_ID, sesion);
                }

                row.OBSERVACION = (string)campos[CuentaCorrienteRetencionesEmitidasService.Observacion_NombreCol];

                if (campos.Contains(CuentaCorrienteRetencionesEmitidasService.Id_NombreCol))
                    sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.Update(row);
                else
                    sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.Insert(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Reemplazar
        public static void Reemplazar(Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    //Anular retención
                    CTACTE_RETENCIONES_EMITIDASRow rowAnterior = new CTACTE_RETENCIONES_EMITIDASRow();
                    string valorAnterior = string.Empty;

                    rowAnterior = sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.GetByPrimaryKey((decimal)campos[CuentaCorrienteRetencionesEmitidasService.Id_NombreCol]);
                    valorAnterior = rowAnterior.ToString();

                    AnularStatic(rowAnterior.ID, sesion);

                    //Insertar Nuevos Valores
                    CTACTE_RETENCIONES_EMITIDASRow rowNuevo = rowAnterior;

                    rowNuevo.ID = sesion.Db.GetSiguienteSecuencia("ctacte_retenciones_emi_sqc");
                    rowNuevo.FECHA = DateTime.Parse(campos[CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol].ToString());
                    rowNuevo.AUTONUMERACION_ID = (decimal)campos[CuentaCorrienteRetencionesEmitidasService.AutonumeracionId_NombreCol];
                    rowNuevo.SUCURSAL_ID = (decimal)campos[CuentaCorrienteRetencionesEmitidasService.SucursalId_NombreCol];
                    rowNuevo.NRO_COMPROBANTE = campos[CuentaCorrienteRetencionesEmitidasService.NroComprobante_NombreCol].ToString();
                    rowNuevo.ESTADO = Definiciones.Estado.Activo;
                    sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.Insert(rowNuevo);

                    ActualizarOrdenPagoValor((decimal)campos[CuentaCorrienteRetencionesEmitidasService.Id_NombreCol], rowAnterior.ID, sesion);
                    ActualizarCtaCteRetencionesEmitidasDetalle((decimal)campos[CuentaCorrienteRetencionesEmitidasService.Id_NombreCol], rowAnterior.ID, sesion);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rowAnterior.ID, valorAnterior, rowNuevo.ToString(), sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }

        }

        public static void ActualizarOrdenPagoValor(decimal retencion_id_anterior, decimal retencion_id_nueva, SessionService sesion)
        {
            OrdenesPagoValoresService.ActualizarDatosRetencion(retencion_id_anterior, retencion_id_nueva, sesion);
        }

        public static void ActualizarCtaCteRetencionesEmitidasDetalle(decimal retencion_id_anterior, decimal retencion_id_nueva, SessionService sesion)
        {
            CuentaCorrienteRetencionesEmitidasDetalleService.ActualizarDatosRetencion(retencion_id_anterior, retencion_id_nueva, sesion);
        }
        #endregion Reemplazar

        #region Borrar
        /// <summary>
        /// Borrars the specified ctacte_retencion_emitida_id.
        /// </summary>
        /// <param name="ctacte_retencion_emitida_id">The ctacte_retencion_emitida_id.</param>
        public void Borrar(decimal ctacte_retencion_emitida_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CuentaCorrienteRetencionesEmitidasDetalleService ctacteRetencionDet = new CuentaCorrienteRetencionesEmitidasDetalleService();
                    DataTable dtRetencionesDet = ctacteRetencionDet.GetCuentaCorrienteRetencionesEmitidasDetalleDataTable(CuentaCorrienteRetencionesEmitidasDetalleService.CtacteRetencionEmitidaId_NombreCol + " = " + ctacte_retencion_emitida_id, string.Empty);
                    CTACTE_RETENCIONES_EMITIDASRow row = sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.GetByPrimaryKey(ctacte_retencion_emitida_id);

                    for (int i = 0; i < dtRetencionesDet.Rows.Count; i++)
                        ctacteRetencionDet.Borrar((decimal)dtRetencionesDet.Rows[i][CuentaCorrienteRetencionesEmitidasDetalleService.Id_NombreCol]);

                    sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.Delete(CuentaCorrienteRetencionesEmitidasService.Id_NombreCol + " = " + ctacte_retencion_emitida_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Anular
        /// <summary>
        /// Anulars the specified ctacte_retencion_id.
        /// </summary>
        /// <param name="ctacte_retencion_id">The ctacte_retencion_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void Anular(decimal ctacte_retencion_id, SessionService sesion)
        {
            CTACTE_RETENCIONES_EMITIDASRow row = sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.GetByPrimaryKey(ctacte_retencion_id);

            if (!row.ESTADO.Equals(Definiciones.Estado.Inactivo))
            {
                string valorAnterior = row.ToString();
                row.ESTADO = Definiciones.Estado.Inactivo;
                sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
        }


        public static void AnularStatic(decimal ctacte_retencion_id, SessionService sesion)
        {
            CTACTE_RETENCIONES_EMITIDASRow row = sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.GetByPrimaryKey(ctacte_retencion_id);

            if (!row.ESTADO.Equals(Definiciones.Estado.Inactivo))
            {
                string valorAnterior = row.ToString();
                row.ESTADO = Definiciones.Estado.Inactivo;
                sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
        }
        #endregion Anular

        #region ActualizarDeclaradoTesaka
        public static void DeclaradoTesaka(decimal ctacte_retencion_id, bool declaradoTesaka)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_RETENCIONES_EMITIDASRow row = sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.GetByPrimaryKey(ctacte_retencion_id);
                string valorAnterior = row.ToString();

                if (declaradoTesaka)
                {
                    row.DECLARADO_TESAKA = Definiciones.SiNo.Si;

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    sesion.Db.CTACTE_RETENCIONES_EMITIDASCollection.Update(row);
                }
            }
        }
        #endregion ActualizarDeclaradoTesaka

        #region GetRetencionesAEmitir
        public static List<Hashtable> GetRetencionesAEmitir(decimal caso_id, decimal proveedor_id, DateTime fecha, bool unificada, SessionService sesion)
        {
            try
            {
                List<Hashtable> lRetenciones = new List<Hashtable>();                

                // Se toman los tipos de retenciones que el cliente debe emitir
                DataTable dtTiposRetenciones = TiposRetencionesService.GetTiposRetencionesDataTable(TiposRetencionesService.EmitirRetencion_NombreCol + " = '" + Definiciones.SiNo.Si + "'", string.Empty);
                if (dtTiposRetenciones.Rows.Count <= 0)
                    return lRetenciones;

                MonedasService monedaRetencion;
                decimal cotizacionMontoMinimoRetencion;
                DataTable dtCaso = CasosService.GetCasosDataTable(CasosService.Id_NombreCol + " = " + caso_id, string.Empty, sesion);
                bool retencionUsarMonedaFactura = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RetencionProveedoresUsarMonedaFactura) == Definiciones.SiNo.Si;
                bool retencionProveedoresRetenerSoloDocumentosDelCaso = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RetencionProveedoresRetenerSoloDocumentosDelCaso) == Definiciones.SiNo.Si;
                int politicaMonto = VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.RetencionProveedoresPoliticaMonto);
                int politicaMontoRetencion = VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.RetencionProveedoresPoliticaMontoRetencion);
                List<decimal> lCasosDocumentosSiendoPagados = new List<decimal>();

                // Se lanza un error si la moneda de los montos minimos de los tipos de retencion son distintos
                monedaRetencion = new MonedasService((decimal)dtTiposRetenciones.Rows[0][TiposRetencionesService.MonedaId_NombreCol], sesion);
                for (int i = 1; i < dtTiposRetenciones.Rows.Count; i++)
                {
                    if ((decimal)dtTiposRetenciones.Rows[i][TiposRetencionesService.MonedaId_NombreCol] != monedaRetencion.Id.Value)
                        throw new Exception("Todos los tipos de retención deben estar registrados con la misma moneda.");
                }
                cotizacionMontoMinimoRetencion = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtCaso.Rows[0][CasosService.SucursalId_NombreCol]), monedaRetencion.Id.Value, fecha, sesion);

                //Obtener el conjunto de facturas sobre las que se considera retener o no.
                //Cada row es un conjunto (separado por @) que debe evaluarse independientemente
                DataTable dtFacturasPasibles = GetFacturasPasiblesRetencion(caso_id, proveedor_id, sesion);

                foreach (DataRow tipoRetencion in dtTiposRetenciones.Rows)
                {
                    decimal montoMinimoRetencion = (decimal)tipoRetencion[TiposRetencionesService.MontoMinimo_NombreCol];
                    decimal retencionPorcentaje = (decimal)tipoRetencion[TiposRetencionesService.Porcentaje_NombreCol];
                    decimal tipoMontoARetener = (decimal)tipoRetencion[TiposRetencionesService.TipoMontoAAplicar_NombreCol];

                    //Evaluar cada conjunto de facturas (separado por @)
                    for (int i = 0; i < dtFacturasPasibles.Rows.Count; i++)
                    {
                        int cantidadCasos, cantidadGenerar, contador;
                        string[] casos, articulos, retenciones, monedas, fechas, casosPago, ctacteProveedores;
                        string[] strAux, montosConsiderar, strCotizaciones;
                        string observacionCasos;
                        decimal[] cotizaciones, gravado, impuesto, cuota, montoPago, retenidoPreviamente;
                        decimal sumaSujetaARetener, montoARetener, totalRetenidoPreviamentePeriodo;

                        #region inicializar arrays
                        casos = dtFacturasPasibles.Rows[i][Calculo.CasoId_Nombrecol].ToString().Split('@');
                        articulos = dtFacturasPasibles.Rows[i][Calculo.ArticuloId_Nombrecol].ToString().Split('@');
                        retenciones = dtFacturasPasibles.Rows[i][Calculo.Retencion_Nombrecol].ToString().Split('@');
                        ctacteProveedores = dtFacturasPasibles.Rows[i][Calculo.CtacteProveedorId_Nombrecol].ToString().Split('@');
                        cantidadCasos = cantidadGenerar = casos.Length;
                        monedas = dtFacturasPasibles.Rows[i][Calculo.MonedaId_Nombrecol].ToString().Split('@');
                        fechas = dtFacturasPasibles.Rows[i][Calculo.FechaFormFormatoNumero_Nombrecol].ToString().Split('@');
                        casosPago = dtFacturasPasibles.Rows[i][Calculo.CasoPago_Nombrecol].ToString().Split('@');

                        strAux = dtFacturasPasibles.Rows[i][Calculo.MonedaCotizacion_Nombrecol].ToString().Split('@');
                        cotizaciones = new decimal[cantidadCasos];
                        for (int j = 0; j < cantidadCasos; j++)
                            cotizaciones[j] = decimal.Parse(strAux[j]);

                        strAux = dtFacturasPasibles.Rows[i][Calculo.TotalGravado_NombreCol].ToString().Split('@');
                        gravado = new decimal[cantidadCasos];
                        for (int j = 0; j < cantidadCasos; j++)
                            gravado[j] = decimal.Parse(strAux[j]);

                        strAux = dtFacturasPasibles.Rows[i][Calculo.TotalImpuesto_NombreCol].ToString().Split('@');
                        impuesto = new decimal[cantidadCasos];
                        for (int j = 0; j < cantidadCasos; j++)
                            impuesto[j] = decimal.Parse(strAux[j]);

                        strAux = dtFacturasPasibles.Rows[i][Calculo.TotalCuota_NombreCol].ToString().Split('@');
                        cuota = new decimal[cantidadCasos];
                        for (int j = 0; j < cantidadCasos; j++)
                            cuota[j] = decimal.Parse(strAux[j]);

                        strAux = dtFacturasPasibles.Rows[i][Calculo.MontoPagado_Nombrecol].ToString().Split('@');
                        montoPago = new decimal[cantidadCasos];
                        for (int j = 0; j < cantidadCasos; j++)
                            montoPago[j] = decimal.Parse(strAux[j]);

                        strAux = dtFacturasPasibles.Rows[i][Calculo.TotalRetenidoPeriodo_NombreCol].ToString().Split('@');
                        totalRetenidoPreviamentePeriodo = 0;
                        for (int j = 0; j < cantidadCasos; j++)
                            totalRetenidoPreviamentePeriodo += decimal.Parse(strAux[j]);

                        strAux = dtFacturasPasibles.Rows[i][Calculo.TotalRetenido_NombreCol].ToString().Split('@');
                        retenidoPreviamente = new decimal[cantidadCasos];
                        for (int j = 0; j < cantidadCasos; j++)
                            retenidoPreviamente[j] = decimal.Parse(strAux[j]);

                        if (tipoMontoARetener == Definiciones.TiposMontosAAplicarRetenciones.IVA)
                        {
                            switch (politicaMonto)
                            {
                                case Definiciones.RetencionProveedoresPoliticaMonto.TotalFactura:
                                    montosConsiderar = dtFacturasPasibles.Rows[i][Calculo.TotalGravado_NombreCol].ToString().Split('@');
                                    break;
                                case Definiciones.RetencionProveedoresPoliticaMonto.TotalCuota:
                                    montosConsiderar = dtFacturasPasibles.Rows[i][Calculo.TotalCuota_NombreCol].ToString().Split('@');
                                    break;
                                case Definiciones.RetencionProveedoresPoliticaMonto.MontoPagado:
                                    montosConsiderar = dtFacturasPasibles.Rows[i][Calculo.MontoPagado_Nombrecol].ToString().Split('@');
                                    break;
                                default: throw new Exception("Valor de variable RetencionProveedoresPoliticaMonto no válido.");
                            }
                        }
                        else if (tipoMontoARetener == Definiciones.TiposMontosAAplicarRetenciones.TotalSinIVA)
                        {
                            montosConsiderar = dtFacturasPasibles.Rows[i][Calculo.TotalGravado_NombreCol].ToString().Split('@');
                        }
                        else
                        {
                            throw new Exception("Tipo de Retención no implementado.");
                        }
                        #endregion inicializar arrays

                        switch (int.Parse(CasosService.GetFlujo(caso_id, sesion).ToString()))
                        {
                            case Definiciones.FlujosIDs.EGRESO_VARIO_CAJA:
                                lCasosDocumentosSiendoPagados.AddRange(EgresosVariosCajaDetalleService.GetCasosIncluidos(caso_id, sesion));
                                break;
                            case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                                lCasosDocumentosSiendoPagados.AddRange(OrdenesPagoDetalleService.GetCasosIncluidos(caso_id, sesion));
                                break;
                            default: throw new Exception("CuentaCorrienteRetencionesEmitidasService.GetRetencionesAEmitir(). Flujo no implementado");
                        }

                        sumaSujetaARetener = 0;
                        for (int j = 0; j < cantidadCasos; j++)
                        {
                            if (monedaRetencion.Id.Value == decimal.Parse(monedas[j]))
                                sumaSujetaARetener += decimal.Parse(montosConsiderar[j]);
                            else
                                sumaSujetaARetener += decimal.Parse(montosConsiderar[j]) / cotizaciones[j] * cotizacionMontoMinimoRetencion;
                        }

                        //Debe retenerse si la suma del conjunto es mayor al mínimo retenible, 
                        //o si ya se retuvo antes durante el periodo (segun variable de sistema)
                        if (sumaSujetaARetener >= montoMinimoRetencion || totalRetenidoPreviamentePeriodo > 0)
                        {
                            montoARetener = 0;
                            string[] strMontos = new string[cantidadCasos];
                            string[] strMontosGenerar;
                            switch (politicaMontoRetencion)
                            {
                                case Definiciones.RetencionProveedoresPoliticaMonto.TotalFactura:
                                    for (int j = 0; j < cantidadCasos; j++)
                                    {
                                        if (!retencionProveedoresRetenerSoloDocumentosDelCaso || lCasosDocumentosSiendoPagados.Contains(decimal.Parse(casos[j])))
                                        {
                                            if (decimal.Parse(retenciones[j].ToString()) != 0)
                                                montoARetener = Math.Round((decimal)impuesto[j] * decimal.Parse(retenciones[j].ToString()) / 100, MonedasService.CantidadDecimalesStatic(decimal.Parse(monedas[j].ToString())));
                                            else
                                                montoARetener = Math.Round((decimal)impuesto[j] * retencionPorcentaje / 100, MonedasService.CantidadDecimalesStatic(decimal.Parse(monedas[j].ToString())));

                                            montoARetener -= retenidoPreviamente[j];
                                        }
                                        else
                                        {
                                            montoARetener = 0;
                                        }

                                        strMontos[j] = montoARetener.ToString();
                                        if (montoARetener <= 0) cantidadGenerar--;
                                    }
                                    break;
                                case Definiciones.RetencionProveedoresPoliticaMonto.TotalCuota:
                                    for (int j = 0; j < cantidadCasos; j++)
                                    {
                                        //Si la cuota fue pagada en forma parcial anteriormente, se asume que ya fue retenida.
                                        //Esto puede ser falso porque la cuota puede estar siendo pagada en forma parcial
                                        //y que deba ser retenida debido a la suma con otras facturas
                                        DataTable dtCTacteProveedores = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresDataTable(CuentaCorrienteProveedoresService.Id_NombreCol + " = " + ctacteProveedores[j], string.Empty, sesion);
                                        if ((decimal)dtCTacteProveedores.Rows[0][CuentaCorrienteProveedoresService.Debito_NombreCol] > 0)
                                        {
                                            montoARetener = 0;
                                        }
                                        else
                                        {
                                            if (!retencionProveedoresRetenerSoloDocumentosDelCaso || lCasosDocumentosSiendoPagados.Contains(decimal.Parse(casos[j])))
                                            {
                                                decimal retencionMaxima = 0;
                                                if (decimal.Parse(retenciones[j].ToString()) != 0)
                                                    retencionMaxima = impuesto[j] * decimal.Parse(retenciones[j].ToString()) / 100;
                                                else
                                                    retencionMaxima = impuesto[j] * retencionPorcentaje / 100;

                                                montoARetener = Math.Round((decimal)retencionMaxima * (cuota[j] / gravado[j]), MonedasService.CantidadDecimalesStatic(decimal.Parse(monedas[j].ToString())));
                                                if (montoARetener + retenidoPreviamente[j] > retencionMaxima)
                                                    montoARetener = retencionMaxima - retenidoPreviamente[j];
                                            }
                                            else
                                            {
                                                montoARetener = 0;
                                            }
                                        }

                                        strMontos[j] = montoARetener.ToString();
                                        if (montoARetener <= 0) cantidadGenerar--;
                                    }
                                    break;
                                case Definiciones.RetencionProveedoresPoliticaMonto.MontoPagado:
                                    for (int j = 0; j < cantidadCasos; j++)
                                    {
                                        if (!retencionProveedoresRetenerSoloDocumentosDelCaso || lCasosDocumentosSiendoPagados.Contains(decimal.Parse(casos[j])))
                                        {
                                            decimal retencionMaxima = 0;
                                            if (decimal.Parse(retenciones[j].ToString()) != 0)
                                                retencionMaxima = impuesto[j] * decimal.Parse(retenciones[j].ToString()) / 100;
                                            else
                                                retencionMaxima = impuesto[j] * retencionPorcentaje / 100;

                                            montoARetener = Math.Round((decimal)retencionMaxima * (montoPago[j] / gravado[j]), MonedasService.CantidadDecimalesStatic(decimal.Parse(monedas[j].ToString())));
                                            if (montoARetener + retenidoPreviamente[j] > retencionMaxima)
                                                montoARetener = retencionMaxima - retenidoPreviamente[j];
                                        }
                                        else
                                        {
                                            montoARetener = 0;
                                        }

                                        strMontos[j] = montoARetener.ToString();

                                        if (montoARetener <= 0) cantidadGenerar--;
                                    }
                                    break;
                                default: throw new Exception("Valor de variable RetencionProveedoresPoliticaMontoRetencion no válido.");
                            }

                            //Reconstruir la cadena separada por @ omitiendo las retenciones cuyo monto seria cero
                            observacionCasos = string.Empty;

                            for (int j = 0; j < cantidadCasos; j++)
                            {
                                if (decimal.Parse(strMontos[j]) <= 0)
                                    continue;

                                if (observacionCasos.Length > 0)
                                    observacionCasos += ", ";

                                observacionCasos += casos[j];
                            }

                            if (unificada)
                            {
                                Hashtable ht = new Hashtable();

                                ht.Add(CuentaCorrienteRetencionesEmitidasDetalleService.RetencionTipoId_NombreCol, (decimal)tipoRetencion[TiposRetencionesService.Id_NombreCol]);
                                ht.Add(CuentaCorrienteRetencionesEmitidasService.Observacion_NombreCol, "Retención " + tipoRetencion[TiposRetencionesService.Nombre_NombreCol] + " generada en forma automática sobre " + (casos.Length > 1 ? "los casos " : "el caso ") + observacionCasos + ".");
                                ht.Add(CuentaCorrienteRetencionesEmitidasDetalleService.CasoId_NombreCol, dtFacturasPasibles.Rows[i][Calculo.CasoId_Nombrecol]);

                                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RetencionProveedoresUsarFechaFactura) == Definiciones.SiNo.No)
                                {
                                    if ((string)dtFacturasPasibles.Rows[i][Calculo.TipoCondicionPago_NombreCol] == Definiciones.TipoFactura.Contado)
                                        ht.Add(CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol, DateTime.ParseExact(fechas[0], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None));
                                    else
                                        ht.Add(CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol, fecha);
                                }
                                else
                                {
                                    ht.Add(CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol, fecha);
                                }

                                strCotizaciones = new string[cantidadGenerar];
                                strMontosGenerar = new string[cantidadGenerar];
                                contador = 0;
                                if (retencionUsarMonedaFactura)
                                {
                                    for (int j = 0; j < cantidadCasos; j++)
                                    {
                                        if (decimal.Parse(strMontos[j]) <= 0)
                                            continue;
                                        strCotizaciones[contador] = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtCaso.Rows[0][CasosService.SucursalId_NombreCol]), decimal.Parse(monedas[j]), (DateTime)ht[CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol], sesion).ToString();
                                        strMontosGenerar[contador] = strMontos[j];
                                        contador++;
                                    }
                                    ht.Add(CuentaCorrienteRetencionesEmitidasService.MonedaId_NombreCol, dtFacturasPasibles.Rows[i][Calculo.MonedaId_Nombrecol]);
                                }
                                else
                                {
                                    for (int j = 0; j < cantidadCasos; j++)
                                    {
                                        if (decimal.Parse(strMontos[j]) <= 0)
                                            continue;

                                        decimal cotizacionMonedaRetencion = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtCaso.Rows[0][CasosService.SucursalId_NombreCol]), decimal.Parse(monedas[j]), (DateTime)ht[CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol], sesion);
                                        strCotizaciones[contador] = cotizacionMonedaRetencion.ToString();
                                        strMontosGenerar[contador] = (decimal.Parse(strMontos[j]) / cotizacionMonedaRetencion * cotizacionMontoMinimoRetencion).ToString();
                                        contador++;
                                    }
                                    ht.Add(CuentaCorrienteRetencionesEmitidasService.MonedaId_NombreCol, monedaRetencion.Id.Value.ToString());
                                }
                                ht.Add(CuentaCorrienteRetencionesEmitidasService.Cotizacion_NombreCol, string.Join("@", strCotizaciones));
                                ht.Add(CuentaCorrienteRetencionesEmitidasService.Total_NombreCol, string.Join("@", strMontosGenerar));

                                lRetenciones.Add(ht);
                            }
                            else
                            {
                                for (int j = 0; j < casos.Length; j++)
                                {
                                    if (decimal.Parse(strMontos[j]) <= 0)
                                        continue;

                                    Hashtable ht = new Hashtable();

                                    ht.Add(CuentaCorrienteRetencionesEmitidasDetalleService.RetencionTipoId_NombreCol, (decimal)tipoRetencion[TiposRetencionesService.Id_NombreCol]);

                                    if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RetencionProveedoresUsarFechaFactura) == Definiciones.SiNo.No)
                                    {
                                        if ((string)dtFacturasPasibles.Rows[i][Calculo.TipoCondicionPago_NombreCol] == Definiciones.TipoFactura.Contado)
                                            ht.Add(CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol, DateTime.ParseExact(fechas[0], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None));
                                        else
                                            ht.Add(CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol, fecha);
                                    }
                                    else
                                    {
                                        ht.Add(CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol, fecha);
                                    }

                                    ht.Add(CuentaCorrienteRetencionesEmitidasService.Observacion_NombreCol, "Retención " + tipoRetencion[TiposRetencionesService.Nombre_NombreCol] + " generada en forma automática sobre el caso " + casos[j] + ".");
                                    ht.Add(CuentaCorrienteRetencionesEmitidasDetalleService.CasoId_NombreCol, casos[j]);
                                    if (retencionUsarMonedaFactura)
                                    {
                                        decimal cotizacionMonedaFC = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtCaso.Rows[0][CasosService.SucursalId_NombreCol]), decimal.Parse(monedas[j]), (DateTime)ht[CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol], sesion);
                                        ht.Add(CuentaCorrienteRetencionesEmitidasService.MonedaId_NombreCol, monedas[j]);
                                        ht.Add(CuentaCorrienteRetencionesEmitidasService.Cotizacion_NombreCol, cotizacionMonedaFC.ToString());
                                    }
                                    else
                                    {
                                        ht.Add(CuentaCorrienteRetencionesEmitidasService.MonedaId_NombreCol, monedaRetencion.Id.Value);
                                        ht.Add(CuentaCorrienteRetencionesEmitidasService.Cotizacion_NombreCol, cotizacionMontoMinimoRetencion);

                                        if (monedaRetencion.Id.Value != decimal.Parse(monedas[j]))
                                        {
                                            decimal cotizacionMonedaRetencion = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtCaso.Rows[0][CasosService.SucursalId_NombreCol]), decimal.Parse(monedas[j]), (DateTime)ht[CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol], sesion);
                                            strMontos[j] = (decimal.Parse(strMontos[j]) / cotizacionMonedaRetencion * cotizacionMontoMinimoRetencion).ToString();
                                        }

                                    }
                                    ht.Add(CuentaCorrienteRetencionesEmitidasService.Total_NombreCol, strMontos[j]);

                                    lRetenciones.Add(ht);
                                }
                            }
                        }
                    }
                }
                return lRetenciones;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetRetencionesAEmitir

        #region GetFacturasPasiblesRetencion
        private static DataTable GetFacturasPasiblesRetencion(decimal caso_id, decimal proveedor_id, SessionService sesion)
        {
            try
            {
                #region Validaciones iniciales
                // Se toman los tipos de retenciones que el cliente debe emitir
                DataTable dtTiposRetenciones = TiposRetencionesService.GetTiposRetencionesDataTable(TiposRetencionesService.EmitirRetencion_NombreCol + " = '" + Definiciones.SiNo.Si + "'", string.Empty);
                if (dtTiposRetenciones.Rows.Count <= 0)
                    return new DataTable();

                // Se lanza un error si la moneda de los montos minimos de los tipos de retencion son distintos
                decimal monedaMontoMinimoRetencion = (decimal)dtTiposRetenciones.Rows[0][TiposRetencionesService.MonedaId_NombreCol];
                for (int i = 1; i < dtTiposRetenciones.Rows.Count; i++)
                {
                    if (!((decimal)dtTiposRetenciones.Rows[i][TiposRetencionesService.MonedaId_NombreCol] == monedaMontoMinimoRetencion))
                        throw new Exception("Todos los tipos de retenciones deben estar registrados con la misma moneda.");
                }
                #endregion Validaciones iniciales

                DataTable dtCaso = CasosService.GetCasosDataTable(CasosService.Id_NombreCol + " = " + caso_id, string.Empty, sesion);
                int politicaCasosConsiderarContado = VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.RetencionProveedoresPoliticaCasosAConsiderarContado);
                int politicaCasosConsiderarCredito = VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.RetencionProveedoresPoliticaCasosAConsiderarCredito);
                int politicaAgrupamientoContado = VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.RetencionProveedoresPoliticaAgrupamientoContado);
                int politicaAgrupamientoCredito = VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.RetencionProveedoresPoliticaAgrupamientoCredito);
                bool diferenciarCreditoYContado = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RetencionProveedoresDiferenciarCreditoYContado) == Definiciones.SiNo.Si;
                bool incluirIVAAlVerificarMinimo = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RetencionProveedoresIncluirIVAAlVerificarMinimo) == Definiciones.SiNo.Si;

                DataTable dtConjuntosDeFacturas = new DataTable();
                string sql = string.Empty;
                string sqlImpuestoNC = string.Empty;

                sqlImpuestoNC = "nvl((" +
                    "select sum(ncpd." + NotasCreditoProveedorDetalleService.ImpuestoMonto_NombreCol + ") " +
                    "  from " + NotasCreditoProveedorService.Nombre_Vista + " ncpic, " + NotasCreditoProveedorDetalleService.Nombre_Tabla + " ncpd " +
                    " where ncpd." + NotasCreditoProveedorDetalleService.FacturaProveedorId_NombreCol + " = fp." + FacturasProveedorService.Id_NombreCol +
                    "   and ncpic." + NotasCreditoProveedorService.Id_NombreCol + " = ncpd." + NotasCreditoProveedorDetalleService.NotaCreditoId_NombreCol +
                    "   and ncpic." + NotasCreditoProveedorService.VistaCasoEstadoId_NombreCol + " in ('" + Definiciones.EstadosFlujos.Aprobado + "', '" + Definiciones.EstadosFlujos.Cerrado + "') " +
                    "),0)";
                
                sql += "with facturas_afectadas as (\n" +
                       "  select fp." + FacturasProveedorService.CasoId_NombreCol + ", fpd." + FacturasProveedorDetalleService.ArticuloId_NombreCol + ", a." + ArticulosService.Retencion_Nombrecol + ", \n" +
                       "  fp." + FacturasProveedorService.MonedaId_NombreCol + ", fp." + FacturasProveedorService.MonedaCotizacion_NombreCol + ", opd." + OrdenesPagoDetalleService.CtacteProveedorId_NombreCol + ", \n" +
                       "         ccp." + CondicionesPagoService.TipoCondicionPago_NombreCol + ", case ccp." + CondicionesPagoService.TipoCondicionPago_NombreCol + " when '" + Definiciones.TipoFactura.Contado + "' then to_number(to_char(fp." + FacturasProveedorService.FechaFactura_NombreCol + ", 'yyyymmdd')) else c." + CasosService.FechaFormFormatoNumero_NombreCol + " end " + CasosService.FechaFormFormatoNumero_NombreCol + ", \n" +
                       "         round(fpd." + FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol + " - " + sqlImpuestoNC + ", m." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName + ") " + FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol + ", cp." + CuentaCorrienteProveedoresService.Credito_NombreCol + " " + Calculo.TotalCuota_NombreCol + ", \n";
                if (incluirIVAAlVerificarMinimo)
                {
                    sql += "         1 " + Calculo.RelacionGravadoImpuesto_Nombrecol + ", \n" +
                        "            round(fp." + FacturasProveedorService.TotalPago_NombreCol + ", m." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName + ") " + Calculo.TotalGravado_NombreCol + ", \n";
                }
                else
                {
                    sql += "         (fpd." + FacturasProveedorDetalleService.TotalPago_NombreCol + " - fpd." + FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol + ") * (1 - fp." + FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol + "/ 100) / fp." + FacturasProveedorService.TotalPago_NombreCol + " " + Calculo.RelacionGravadoImpuesto_Nombrecol + ", \n" +
                        "            round((fpd." + FacturasProveedorDetalleService.TotalPago_NombreCol + " - fpd." + FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol + ") * (1 - fp." + FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol + "/ 100), m." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName + ") " + Calculo.TotalGravado_NombreCol + ", \n";
                }
                sql += "         round(nvl((select sum(\n" +
                       "                 case cre." + CuentaCorrienteRetencionesEmitidasService.MonedaId_NombreCol + " when fp." + FacturasProveedorService.MonedaId_NombreCol + " then cred." + CuentaCorrienteRetencionesEmitidasDetalleService.Monto_NombreCol + "\n" +
                       "                 else cred." + CuentaCorrienteRetencionesEmitidasDetalleService.Monto_NombreCol + " / cre." + CuentaCorrienteRetencionesEmitidasService.Cotizacion_NombreCol + " * herramientas.Obtener_Cotizacion_Venta(fp." + FacturasProveedorService.SucursalId_NombreCol + ", fp." + FacturasProveedorService.MonedaId_NombreCol + ", cre." + CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol + ") \n" +
                       "                 end) \n" +
                       "            from " + CuentaCorrienteRetencionesEmitidasService.Nombre_Tabla + " cre, " + CuentaCorrienteRetencionesEmitidasDetalleService.Nombre_Tabla + " cred \n" +
                       "            where cred." + CuentaCorrienteRetencionesEmitidasDetalleService.CtacteRetencionEmitidaId_NombreCol + " = cre." + CuentaCorrienteRetencionesEmitidasService.Id_NombreCol + "\n" +
                       "              and cre." + CuentaCorrienteRetencionesEmitidasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' \n" +
                       "              and cred." + CuentaCorrienteRetencionesEmitidasDetalleService.CasoId_NombreCol + " = fp." + FacturasProveedorService.CasoId_NombreCol + "\n";
                #region obtener retenciones ya generadas en el periodo
                sql += "     and (( ccp." + CondicionesPagoService.TipoCondicionPago_NombreCol + " = '" + Definiciones.TipoFactura.Contado + "' \n";
                switch (politicaCasosConsiderarContado)
                {
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Caso:
                        //se suma todo lo ya retenido sobre la factura
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Dia:
                        sql += "     and to_number(to_char(cre." + CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol + ", 'yyyymmdd')) = " + dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol];
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Mes:
                        sql += "     and trunc(to_number(to_char(cre." + CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol + ", 'yyyymmdd')), -2) = " + Math.Truncate((decimal)dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol] / 100) * 100;
                        break;
                    default: throw new Exception("Valor de variable RetencionProveedoresPoliticaCasosAConsiderarContado no válido.");
                }
                sql += "        ) \n or ( " +
                       "         ccp." + CondicionesPagoService.TipoCondicionPago_NombreCol + " = '" + Definiciones.TipoFactura.Credito + "' \n";
                switch (politicaCasosConsiderarCredito)
                {
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Caso:
                        //se suma todo lo ya retenido sobre la factura
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Dia:
                        sql += "     and to_number(to_char(cre." + CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol + ", 'yyyymmdd')) = " + dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol];
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Mes:
                        sql += "     and trunc(to_number(to_char(cre." + CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol + ", 'yyyymmdd')), -2) = " + Math.Truncate((decimal)dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol] / 100) * 100;
                        break;
                    default: throw new Exception("Valor de variable RetencionProveedoresPoliticaCasosAConsiderarContado no válido.");
                }
                sql += "         ))), 0), m.cantidades_decimales) " + Calculo.TotalRetenidoPeriodo_NombreCol + ", \n";
                #endregion obtener retenciones ya generadas en el periodo
                sql += "         round(nvl((select sum(\n" +
                       "                 case cre." + CuentaCorrienteRetencionesEmitidasService.MonedaId_NombreCol + " when fp." + FacturasProveedorService.MonedaId_NombreCol + " then cred." + CuentaCorrienteRetencionesEmitidasDetalleService.Monto_NombreCol + "\n" +
                       "                 else cred." + CuentaCorrienteRetencionesEmitidasDetalleService.Monto_NombreCol + " / cre." + CuentaCorrienteRetencionesEmitidasService.Cotizacion_NombreCol + " * herramientas.Obtener_Cotizacion_Venta(fp." + FacturasProveedorService.SucursalId_NombreCol + ", fp." + FacturasProveedorService.MonedaId_NombreCol + ", cre." + CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol + ") \n" +
                       "                 end) \n" +
                       "            from " + CuentaCorrienteRetencionesEmitidasService.Nombre_Tabla + " cre, " + CuentaCorrienteRetencionesEmitidasDetalleService.Nombre_Tabla + " cred \n" +
                       "            where cred." + CuentaCorrienteRetencionesEmitidasDetalleService.CtacteRetencionEmitidaId_NombreCol + " = cre." + CuentaCorrienteRetencionesEmitidasService.Id_NombreCol + "\n" +
                       "              and cre." + CuentaCorrienteRetencionesEmitidasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' \n" +
                       "              and cred." + CuentaCorrienteRetencionesEmitidasDetalleService.CasoId_NombreCol + " = fp." + FacturasProveedorService.CasoId_NombreCol + "\n" +
                       "         ), 0), m.cantidades_decimales) " + Calculo.TotalRetenido_NombreCol + ", \n" +
                       "         op." + OrdenesPagoService.CasoId_NombreCol + " " + Calculo.CasoPago_Nombrecol + ", opd." + OrdenesPagoDetalleService.MontoOrigen_NombreCol + " " + Calculo.MontoPagado_Nombrecol + " \n" +
                       "    from " + CasosService.Nombre_Tabla + " c, " + OrdenesPagoService.Nombre_Tabla + " op, " + OrdenesPagoDetalleService.Nombre_Tabla + " opd, " +
                       FacturasProveedorService.Nombre_Tabla + " fp, " + FacturasProveedorDetalleService.Nombre_Tabla + " fpd, " + CondicionesPagoService.Nombre_Tabla + " ccp, " +
                       CuentaCorrienteProveedoresService.Nombre_Tabla + " cp, " + MonedasService.Nombre_Tabla + " m, \n" +
                       ArticulosService.Nombre_Tabla + " a, " + ProveedoresService.Nombre_Tabla + " p \n" +
                       "   where c." + CasosService.ProveedorId_NombreCol + " = " + proveedor_id + " \n" +
                       "     and c." + CasosService.ProveedorId_NombreCol + " = p." + ProveedoresService.Id_NombreCol + " \n" +
                       "     and c." + CasosService.FlujoId_NombreCol + " = " + Definiciones.FlujosIDs.ORDEN_DE_PAGO + " \n" +
                       "     and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' \n" +
                       "     and c." + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' \n";
                #region excluir casos de OP
                sql += "     and (( ccp." + CondicionesPagoService.TipoCondicionPago_NombreCol + " = '" + Definiciones.TipoFactura.Contado + "' \n";
                switch (politicaCasosConsiderarContado)
                {
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Caso:
                        sql += "     and c." + CasosService.Id_NombreCol + " = " + caso_id;
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Dia:
                        //sql += "     and c." + CasosService.FechaFormFormatoNumero_NombreCol + " = " + dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol];
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Mes:
                        //sql += "     and trunc(c." + CasosService.FechaFormFormatoNumero_NombreCol + ", -2) = " + Math.Truncate((decimal)dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol]/100)*100;
                        break;
                    default: throw new Exception("Valor de variable RetencionProveedoresPoliticaCasosAConsiderarContado no válido.");
                }
                sql += "        ) \n or ( " +
                       "         ccp." + CondicionesPagoService.TipoCondicionPago_NombreCol + " = '" + Definiciones.TipoFactura.Credito + "' \n";
                switch (politicaCasosConsiderarCredito)
                {
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Caso:
                        sql += "     and c." + CasosService.Id_NombreCol + " = " + caso_id;
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Dia:
                        sql += "     and c." + CasosService.FechaFormFormatoNumero_NombreCol + " = " + dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol];
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Mes:
                        sql += "     and trunc(c." + CasosService.FechaFormFormatoNumero_NombreCol + ", -2) = " + Math.Truncate((decimal)dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol] / 100) * 100;
                        break;
                    default: throw new Exception("Valor de variable RetencionProveedoresPoliticaCasosAConsiderarCredito no válido.");
                }
                sql += " ))\n";
                #endregion excluir casos de OP
                sql += "     and op." + OrdenesPagoService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " \n" +
                       "     and op." + OrdenesPagoService.OrdenPagoTipoId_NombreCol + " = " + Definiciones.TiposOrdenesPago.PagoAProveedor + " \n" +
                       "     and opd." + OrdenesPagoDetalleService.OrdenPagoId_NombreCol + " = op." + OrdenesPagoService.Id_NombreCol + " \n" +
                       "     and opd." + OrdenesPagoDetalleService.CasoReferidoId_NombreCol + " = fp." + FacturasProveedorService.CasoId_NombreCol + " \n" +
                       "     and opd." + OrdenesPagoDetalleService.CtacteProveedorId_NombreCol + " = cp." + CuentaCorrienteProveedoresService.Id_NombreCol + " \n" +
                       "     and ccp." + CondicionesPagoService.Id_NombreCol + " = fp." + FacturasProveedorService.CtacteCondicionPagoId_NombreCol + " \n" +
                       "     and fp." + FacturasProveedorService.MonedaId_NombreCol + " = m." + MonedasService.Modelo.IDColumnName + " \n" +
                       "     and (fp." + FacturasProveedorService.PasibleRetencion_NombreCol + " = '" + Definiciones.SiNo.Si + "' \n" +
                       "          or (fp." + FacturasProveedorService.PasibleRetencion_NombreCol + " = '" + Definiciones.SiNo.No + "' \n" + 
                       "          and fp." + FacturasProveedorService.FechaFactura_NombreCol + " not between p." + ProveedoresService.FechaDesdeNoRetencion_NombreCol + " and p." + ProveedoresService.FechaHastaNoRetencion_NombreCol + ")) "+
                       "     and fpd." + FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = fp." + FacturasProveedorService.Id_NombreCol + " \n" +
                       "     and fpd." + FacturasProveedorDetalleService.ArticuloId_NombreCol + " = a." + ArticulosService.Id_NombreCol + "\n" +
                       "     and fpd." + FacturasProveedorDetalleService.ImpuestoId_NombreCol + " <> " + Definiciones.Impuestos.Exenta + " \n" +
                       " union \n" +
                       "  select fp." + FacturasProveedorService.CasoId_NombreCol + ", fpd." + FacturasProveedorDetalleService.ArticuloId_NombreCol + ", a." + ArticulosService.Retencion_Nombrecol + ", fp." + FacturasProveedorService.MonedaId_NombreCol + ", fp." + FacturasProveedorService.MonedaCotizacion_NombreCol + ", evcd." + EgresosVariosCajaDetalleService.CtacteProveedorId_NombreCol + ", \n" +
                       "         ccp." + CondicionesPagoService.TipoCondicionPago_NombreCol + ", case ccp." + CondicionesPagoService.TipoCondicionPago_NombreCol + " when '" + Definiciones.TipoFactura.Contado + "' then to_number(to_char(fp." + FacturasProveedorService.FechaFactura_NombreCol + ", 'yyyymmdd')) else c." + CasosService.FechaFormFormatoNumero_NombreCol + " end " + CasosService.FechaFormFormatoNumero_NombreCol + ", \n" +
                       "         round(fpd." + FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol + " - " + sqlImpuestoNC + ", m." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName + ") " + FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol + ", cp." + CuentaCorrienteProveedoresService.Credito_NombreCol + " " + Calculo.TotalCuota_NombreCol + ", \n";
                if (incluirIVAAlVerificarMinimo)
                {
                    sql += "         1 " + Calculo.RelacionGravadoImpuesto_Nombrecol + ", \n" +
                        "            round(fp." + FacturasProveedorService.TotalPago_NombreCol + ", m." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName + ") " + Calculo.TotalGravado_NombreCol + ", \n";
                }
                else
                {
                    sql += "         (fpd." + FacturasProveedorDetalleService.TotalPago_NombreCol + " - fpd." + FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol + ") * (1 - fp." + FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol + "/ 100) / fp." + FacturasProveedorService.TotalPago_NombreCol + " " + Calculo.RelacionGravadoImpuesto_Nombrecol + ", \n" +
                        "            round((fpd." + FacturasProveedorDetalleService.TotalPago_NombreCol + " - fpd." + FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol + ") * (1 - fp." + FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol + "/ 100), m." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName + ") " + Calculo.TotalGravado_NombreCol + ", \n";
                }
                sql += "         round(nvl((select sum(\n" +
                       "                 case cre." + CuentaCorrienteRetencionesEmitidasService.MonedaId_NombreCol + " when fp." + FacturasProveedorService.MonedaId_NombreCol + " then cred." + CuentaCorrienteRetencionesEmitidasDetalleService.Monto_NombreCol + "\n" +
                       "                 else cred." + CuentaCorrienteRetencionesEmitidasDetalleService.Monto_NombreCol + " / cre." + CuentaCorrienteRetencionesEmitidasService.Cotizacion_NombreCol + " * herramientas.Obtener_Cotizacion_Venta(fp." + FacturasProveedorService.SucursalId_NombreCol + ", fp." + FacturasProveedorService.MonedaId_NombreCol + ", cre." + CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol + ") \n" +
                       "                 end) \n" +
                       "            from " + CuentaCorrienteRetencionesEmitidasService.Nombre_Tabla + " cre, " + CuentaCorrienteRetencionesEmitidasDetalleService.Nombre_Tabla + " cred \n" +
                       "            where cred." + CuentaCorrienteRetencionesEmitidasDetalleService.CtacteRetencionEmitidaId_NombreCol + " = cre." + CuentaCorrienteRetencionesEmitidasService.Id_NombreCol + "\n" +
                       "              and cre." + CuentaCorrienteRetencionesEmitidasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' \n" +
                       "              and cred." + CuentaCorrienteRetencionesEmitidasDetalleService.CasoId_NombreCol + " = fp." + FacturasProveedorService.CasoId_NombreCol + "\n";
                #region obtener retenciones ya generadas en el periodo
                sql += "     and (( ccp." + CondicionesPagoService.TipoCondicionPago_NombreCol + " = '" + Definiciones.TipoFactura.Contado + "' \n";
                switch (politicaCasosConsiderarContado)
                {
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Caso:
                        //se suma todo lo ya retenido sobre la factura
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Dia:
                        sql += "     and to_number(to_char(cre." + CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol + ", 'yyyymmdd')) = " + dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol];
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Mes:
                        sql += "     and trunc(to_number(to_char(cre." + CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol + ", 'yyyymmdd')), -2) = " + Math.Truncate((decimal)dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol] / 100) * 100;
                        break;
                    default: throw new Exception("Valor de variable RetencionProveedoresPoliticaCasosAConsiderarContado no válido.");
                }
                sql += "        ) \n or ( " +
                       "         ccp." + CondicionesPagoService.TipoCondicionPago_NombreCol + " = '" + Definiciones.TipoFactura.Credito + "' \n";
                switch (politicaCasosConsiderarCredito)
                {
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Caso:
                        //se suma todo lo ya retenido sobre la factura
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Dia:
                        sql += "     and to_number(to_char(cre." + CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol + ", 'yyyymmdd')) = " + dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol];
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Mes:
                        sql += "     and trunc(to_number(to_char(cre." + CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol + ", 'yyyymmdd')), -2) = " + Math.Truncate((decimal)dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol] / 100) * 100;
                        break;
                    default: throw new Exception("Valor de variable RetencionProveedoresPoliticaCasosAConsiderarContado no válido.");
                }
                sql += "         ))), 0), m.cantidades_decimales) " + Calculo.TotalRetenidoPeriodo_NombreCol + ", \n";
                #endregion obtener retenciones ya generadas en el periodo
                sql += "         round(nvl((select sum(\n" +
                       "                 case cre." + CuentaCorrienteRetencionesEmitidasService.MonedaId_NombreCol + " when fp." + FacturasProveedorService.MonedaId_NombreCol + " then cred." + CuentaCorrienteRetencionesEmitidasDetalleService.Monto_NombreCol + "\n" +
                       "                 else cred." + CuentaCorrienteRetencionesEmitidasDetalleService.Monto_NombreCol + " / cre." + CuentaCorrienteRetencionesEmitidasService.Cotizacion_NombreCol + " * herramientas.Obtener_Cotizacion_Venta(fp." + FacturasProveedorService.SucursalId_NombreCol + ", fp." + FacturasProveedorService.MonedaId_NombreCol + ", cre." + CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol + ") \n" +
                       "                 end) \n" +
                       "            from " + CuentaCorrienteRetencionesEmitidasService.Nombre_Tabla + " cre, " + CuentaCorrienteRetencionesEmitidasDetalleService.Nombre_Tabla + " cred \n" +
                       "            where cred." + CuentaCorrienteRetencionesEmitidasDetalleService.CtacteRetencionEmitidaId_NombreCol + " = cre." + CuentaCorrienteRetencionesEmitidasService.Id_NombreCol + "\n" +
                       "              and cre." + CuentaCorrienteRetencionesEmitidasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' \n" +
                       "              and cred." + CuentaCorrienteRetencionesEmitidasDetalleService.CasoId_NombreCol + " = fp." + FacturasProveedorService.CasoId_NombreCol + "\n" +
                       "         ), 0), m.cantidades_decimales) " + Calculo.TotalRetenido_NombreCol + ", \n" +
                       "         evc." + EgresosVariosCajaService.CasoId_NombreCol + " " + Calculo.CasoPago_Nombrecol + ", evcd." + EgresosVariosCajaDetalleService.MontoOrigen_NombreCol + " " + Calculo.MontoPagado_Nombrecol + " \n" +
                       "    from " + CasosService.Nombre_Tabla + " c, " + EgresosVariosCajaService.Nombre_Tabla + " evc, " + EgresosVariosCajaDetalleService.Nombre_Tabla + " evcd, " + CuentaCorrienteProveedoresService.Nombre_Tabla + " cp, \n" +
                       "         " + FacturasProveedorService.Nombre_Tabla + " fp, " + FacturasProveedorDetalleService.Nombre_Tabla + " fpd, \n" +
                                     CondicionesPagoService.Nombre_Tabla + " ccp, " + MonedasService.Nombre_Tabla + " m, " + ArticulosService.Nombre_Tabla + " a, \n" +
                                     ProveedoresService.Nombre_Tabla + " p \n" +
                       "   where c." + CasosService.FlujoId_NombreCol + " = " + Definiciones.FlujosIDs.EGRESO_VARIO_CAJA + " \n" +
                       "     and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' \n" +
                       "     and c." + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' \n";
                #region excluir casos de Egreso Vario
                sql += "     and (( ccp." + CondicionesPagoService.TipoCondicionPago_NombreCol + " = '" + Definiciones.TipoFactura.Contado + "' ";
                switch (politicaCasosConsiderarContado)
                {
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Caso:
                        sql += "and c." + CasosService.Id_NombreCol + " = " + caso_id;
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Dia:
                        //sql += "and c." + CasosService.FechaFormFormatoNumero_NombreCol + " = " + dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol];
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Mes:
                        //sql += "and trunc(c." + CasosService.FechaFormFormatoNumero_NombreCol + ", -2) = " + Math.Truncate((decimal)dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol] / 100) * 100;
                        break;
                    default: throw new Exception("Valor de variable RetencionProveedoresPoliticaCasosAConsiderarContado no válido.");
                }
                sql += ") \n or (" +
                       "ccp." + CondicionesPagoService.TipoCondicionPago_NombreCol + " = '" + Definiciones.TipoFactura.Credito + "' ";
                switch (politicaCasosConsiderarCredito)
                {
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Caso:
                        sql += "and c." + CasosService.Id_NombreCol + " = " + caso_id;
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Dia:
                        sql += "and c." + CasosService.FechaFormFormatoNumero_NombreCol + " = " + dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol];
                        break;
                    case Definiciones.RetencionProveedoresPoliticaCasosAConsiderar.Mes:
                        sql += "and trunc(c." + CasosService.FechaFormFormatoNumero_NombreCol + ", -2) = " + Math.Truncate((decimal)dtCaso.Rows[0][CasosService.FechaFormFormatoNumero_NombreCol] / 100) * 100;
                        break;
                    default: throw new Exception("Valor de variable RetencionProveedoresPoliticaCasosAConsiderarCredito no válido.");
                }
                sql += "))\n";
                #endregion excluir casos de Egreso Vario
                sql += "     and evc." + EgresosVariosCajaService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " \n" +
                       "     and c." + CasosService.ProveedorId_NombreCol + " = p." + ProveedoresService.Id_NombreCol + " \n" + 
                       "     and evcd." + EgresosVariosCajaDetalleService.EgresoVarioCajaId_NombreCol + " = evc." + EgresosVariosCajaService.Id_NombreCol + " \n" +
                       "     and evcd." + EgresosVariosCajaDetalleService.CtacteProveedorId_NombreCol + " = cp." + CuentaCorrienteProveedoresService.Id_NombreCol + " \n" +
                       "     and cp." + CuentaCorrienteProveedoresService.ProveedorId_NombreCol + " = " + proveedor_id + " \n" +
                       "     and fp." + FacturasProveedorService.CasoId_NombreCol + " = cp." + CuentaCorrienteProveedoresService.CasoId_NombreCol + " \n" +
                       "     and fp." + FacturasProveedorService.MonedaId_NombreCol + " = m." + MonedasService.Modelo.IDColumnName + " \n" +
                       "     and (fp." + FacturasProveedorService.PasibleRetencion_NombreCol + " = '" + Definiciones.SiNo.Si + "' \n" +
                       "          or (fp." + FacturasProveedorService.PasibleRetencion_NombreCol + " = '" + Definiciones.SiNo.No + "' \n" +
                       "          and fp." + FacturasProveedorService.FechaFactura_NombreCol + " not between p." + ProveedoresService.FechaDesdeNoRetencion_NombreCol + " and p." + ProveedoresService.FechaHastaNoRetencion_NombreCol + ")) " +
                       "     and ccp." + CondicionesPagoService.Id_NombreCol + " = fp." + FacturasProveedorService.CtacteCondicionPagoId_NombreCol + " \n" +
                       "     and fpd." + FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = fp." + FacturasProveedorService.Id_NombreCol + " \n" +
                       "     and fpd." + FacturasProveedorDetalleService.ArticuloId_NombreCol + " = a." + ArticulosService.Id_NombreCol + " \n " +
                       "     and fpd." + FacturasProveedorDetalleService.ImpuestoId_NombreCol + " <> " + Definiciones.Impuestos.Exenta + " \n" +
                       ")\n" +
                       " select LISTAGG(" + Calculo.CasoId_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.CasoId_Nombrecol + ", \n" +
                       "        LISTAGG(" + Calculo.ArticuloId_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.ArticuloId_Nombrecol + ", \n" +
                       "        LISTAGG(" + Calculo.Retencion_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.Retencion_Nombrecol + ", \n" +
                       "        LISTAGG(" + Calculo.CtacteProveedorId_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.CtacteProveedorId_Nombrecol + ", \n" +
                       "        LISTAGG(" + Calculo.MonedaId_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.MonedaId_Nombrecol + ", \n" +
                       "        LISTAGG(" + Calculo.MonedaCotizacion_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.MonedaCotizacion_Nombrecol + ", \n" +
                       "        MAX(" + Calculo.TipoCondicionPago_NombreCol + ") " + Calculo.TipoCondicionPago_NombreCol + ", \n" +
                       "        LISTAGG(" + Calculo.FechaFormFormatoNumero_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.FechaFormFormatoNumero_Nombrecol + ", \n" +
                       "        LISTAGG(" + Calculo.TotalImpuesto_NombreCol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.TotalImpuesto_NombreCol + ", \n" +
                       "        LISTAGG(" + Calculo.TotalGravado_NombreCol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.TotalGravado_NombreCol + ", \n" +
                       "        LISTAGG(" + Calculo.TotalCuota_NombreCol + " * " + Calculo.RelacionGravadoImpuesto_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.TotalCuota_NombreCol + ", \n" +
                       "        LISTAGG(" + Calculo.CasoPago_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.CasoPago_Nombrecol + ", \n" +
                       "        LISTAGG(" + Calculo.MontoPagado_Nombrecol + " * " + Calculo.RelacionGravadoImpuesto_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.MontoPagado_Nombrecol + ", \n" +
                       "        LISTAGG(" + Calculo.TotalRetenidoPeriodo_NombreCol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.TotalRetenidoPeriodo_NombreCol + ", \n" +
                       "        LISTAGG(" + Calculo.TotalRetenido_NombreCol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.TotalRetenido_NombreCol + " \n" +
                       "   from facturas_afectadas fa \n";
                if (diferenciarCreditoYContado)
                {
                    sql += " where fa." + Calculo.TipoCondicionPago_NombreCol + " = '" + Definiciones.TipoFactura.Contado + "' \n";
                    switch (politicaAgrupamientoContado)
                    {
                        case Definiciones.RetencionProveedoresPoliticaAgrupamiento.Caso:
                            sql += " group by " + Calculo.CasoId_Nombrecol;
                            break;
                        case Definiciones.RetencionProveedoresPoliticaAgrupamiento.Dia:
                            sql += " group by " + Calculo.FechaFormFormatoNumero_Nombrecol + ", " + Calculo.MonedaId_Nombrecol;
                            break;
                        case Definiciones.RetencionProveedoresPoliticaAgrupamiento.Mes:
                            sql += " group by trunc(" + Calculo.FechaFormFormatoNumero_Nombrecol + ", -2), " + Calculo.MonedaId_Nombrecol;
                            break;
                        default: throw new Exception("Valor de variable politicaAgrupamientoContado no válido.");
                    }
                    sql += "\n union \n" +
                           " select LISTAGG(" + Calculo.CasoId_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.CasoId_Nombrecol + ", \n" +
                           "        LISTAGG(" + Calculo.ArticuloId_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.ArticuloId_Nombrecol + ", \n" +
                           "        LISTAGG(" + Calculo.Retencion_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.Retencion_Nombrecol + ", \n" +
                           "        LISTAGG(" + Calculo.CtacteProveedorId_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.CtacteProveedorId_Nombrecol + ", \n" +
                           "        LISTAGG(" + Calculo.MonedaId_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.MonedaId_Nombrecol + ", \n" +
                           "        LISTAGG(" + Calculo.MonedaCotizacion_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.MonedaCotizacion_Nombrecol + ", \n" +
                           "        " + Calculo.TipoCondicionPago_NombreCol + ", \n" +
                           "        LISTAGG(" + Calculo.FechaFormFormatoNumero_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.FechaFormFormatoNumero_Nombrecol + ", \n" +
                           "        LISTAGG(" + Calculo.TotalImpuesto_NombreCol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.TotalImpuesto_NombreCol + ", \n" +
                           "        LISTAGG(" + Calculo.TotalGravado_NombreCol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.TotalGravado_NombreCol + ", \n" +
                           "        LISTAGG(" + Calculo.TotalCuota_NombreCol + " * " + Calculo.RelacionGravadoImpuesto_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.TotalCuota_NombreCol + ", \n" +
                           "        LISTAGG(" + Calculo.CasoPago_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.CasoPago_Nombrecol + ", \n" +
                           "        LISTAGG(" + Calculo.MontoPagado_Nombrecol + " * " + Calculo.RelacionGravadoImpuesto_Nombrecol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.MontoPagado_Nombrecol + ", \n" +
                           "        LISTAGG(" + Calculo.TotalRetenidoPeriodo_NombreCol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.TotalRetenidoPeriodo_NombreCol + ", \n" +
                           "        LISTAGG(" + Calculo.TotalRetenido_NombreCol + ", '@') WITHIN GROUP(ORDER BY " + Calculo.CasoId_Nombrecol + ", " + Calculo.ArticuloId_Nombrecol + ") " + Calculo.TotalRetenido_NombreCol + " \n" +
                           "   from facturas_afectadas fa \n" +
                           "  where fa." + Calculo.TipoCondicionPago_NombreCol + " = '" + Definiciones.TipoFactura.Credito + "' \n";
                    switch (politicaAgrupamientoCredito)
                    {
                        case Definiciones.RetencionProveedoresPoliticaAgrupamiento.Caso:
                            sql += " group by " + Calculo.TipoCondicionPago_NombreCol + ", " + Calculo.CasoId_Nombrecol;
                            break;
                        case Definiciones.RetencionProveedoresPoliticaAgrupamiento.Dia:
                            sql += " group by " + Calculo.TipoCondicionPago_NombreCol + ", " + Calculo.FechaFormFormatoNumero_Nombrecol + ", " + Calculo.MonedaId_Nombrecol;
                            break;
                        case Definiciones.RetencionProveedoresPoliticaAgrupamiento.Mes:
                            sql += " group by " + Calculo.TipoCondicionPago_NombreCol + ", trunc(" + Calculo.FechaFormFormatoNumero_Nombrecol + ", -2), " + Calculo.MonedaId_Nombrecol;
                            break;
                        default: throw new Exception("Valor de variable politicaAgrupamientoCredito no válido.");
                    }
                }
                else
                {
                    switch (politicaAgrupamientoCredito)
                    {
                        case Definiciones.RetencionProveedoresPoliticaAgrupamiento.Caso:
                            sql += " group by " + Calculo.CasoId_Nombrecol;
                            break;
                        case Definiciones.RetencionProveedoresPoliticaAgrupamiento.Dia:
                            sql += " group by " + Calculo.FechaFormFormatoNumero_Nombrecol + ", " + Calculo.MonedaId_Nombrecol;
                            break;
                        case Definiciones.RetencionProveedoresPoliticaAgrupamiento.Mes:
                            sql += " group by trunc(" + Calculo.FechaFormFormatoNumero_Nombrecol + ", -2), " + Calculo.MonedaId_Nombrecol;
                            break;
                        default: throw new Exception("Valor de variable politicaAgrupamientoCredito no válido.");
                    }
                }

                dtConjuntosDeFacturas = sesion.db.EjecutarQuery(sql);

                return dtConjuntosDeFacturas;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion CalcularRetenciones

        #region Accessors
        public static class Calculo
        {
            public static string CasoId_Nombrecol = "CASO_ID";
            public static string ArticuloId_Nombrecol = "ARTICULO_ID";
            public static string Retencion_Nombrecol = "RETENCION";
            public static string CasoPago_Nombrecol = "CASO_PAGO";
            public static string CtacteProveedorId_Nombrecol = OrdenesPagoDetalleService.CtacteProveedorId_NombreCol;
            public static string FechaFormFormatoNumero_Nombrecol = CasosService.FechaFormFormatoNumero_NombreCol;
            public static string MonedaId_Nombrecol = FacturasProveedorService.MonedaId_NombreCol;
            public static string MonedaCotizacion_Nombrecol = FacturasProveedorService.MonedaCotizacion_NombreCol;
            public static string MontoPagado_Nombrecol = "MONTO_PAGADO";
            public static string TipoCondicionPago_NombreCol = CondicionesPagoService.TipoCondicionPago_NombreCol;
            public static string RelacionGravadoImpuesto_Nombrecol = "RELACION_GRAVADO_IMPUESTO";
            public static string TotalCuota_NombreCol = "TOTAL_CUOTA";
            public static string TotalGravado_NombreCol = "TOTAL_GRAVADO";
            public static string TotalRetenido_NombreCol = "TOTAL_RETENIDO";
            public static string TotalRetenidoPeriodo_NombreCol = "TOTAL_RETENIDO_PERIODO";
            public static string TotalImpuesto_NombreCol = FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol;
        }
        public static string Nombre_Tabla
        {
            get { return "CTACTE_RETENCIONES_EMITIDAS"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMITIDASCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMITIDASCollection.COTIZACIONColumnName; }
        }
        public static string CotizacionMonedaPais_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMITIDASCollection.COTIZACION_MONEDA_PAISColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMITIDASCollection.ESTADOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMITIDASCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMITIDASCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMITIDASCollection.MONEDA_IDColumnName; }
        }
        public static string MonedaPaisId_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMITIDASCollection.MONEDA_PAIS_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMITIDASCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMITIDASCollection.OBSERVACIONColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMITIDASCollection.PROVEEDOR_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMITIDASCollection.SUCURSAL_IDColumnName; }
        }
        public static string Total_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMITIDASCollection.TOTALColumnName; }
        }
        public static string VistaCasoCraecionId_NombreCol
        {
            get { return CTACTE_RETENC_EMIT_INFO_COMPCollection.CASO_CREACION_IDColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_RETENC_EMIT_INFO_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_RETENC_EMIT_INFO_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaProveedorRazonSocial_NombreCol
        {
            get { return CTACTE_RETENC_EMIT_INFO_COMPCollection.PROVEEDOR_RAZON_SOCIALColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return CTACTE_RETENC_EMIT_INFO_COMPCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CTACTE_RETENC_EMIT_INFO_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
