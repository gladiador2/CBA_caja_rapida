#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Facturacion;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Services.NotaCreditosProveedores;
using System.Linq;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class OrdenesPagoDetalleService
    {
        #region GetOrdenesPagoDetallesDataTable
        /// <summary>
        /// Gets the ordenes pago detalles data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetOrdenesPagoDetallesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ORDENES_PAGO_DETCollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetOrdenesPagoDetallesDataTable2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return OrdenesPagoDetalleService.GetOrdenesPagoDetallesDataTable2(clausulas, orden, sesion);
            }
        }

        public static DataTable GetOrdenesPagoDetallesDataTable2(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ORDENES_PAGO_DETCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetOrdenesPagoDetallesDataTable

        #region GetOrdenesPagoDetallesInfoCompleta
        public static DataTable GetOrdenesPagoDetallesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return OrdenesPagoDetalleService.GetOrdenesPagoDetallesInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetOrdenesPagoDetallesInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ORDENES_PAGO_DET_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetOrdenesPagoDetallesInfoCompleta

        #region GetCasoRespaldadoFormaParteDeOP
        /// <summary>
        /// Gets the caso respaldado forma parte de OP.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static bool GetCasoRespaldadoFormaParteDeOP(decimal caso_id)
        {
            DataTable dtDetalles = GetOrdenesPagoDetallesDataTable2(OrdenesPagoDetalleService.CasoReferidoId_NombreCol + " = " + caso_id, string.Empty);
            DataTable dtOrdenPago;
            int contador = dtDetalles.Rows.Count;

            //Se omiten las OP que asocian el caso pero estan en anulado
            for (int i = 0; i < dtDetalles.Rows.Count; i++)
            {
                dtOrdenPago = OrdenesPagoService.GetOrdenesPagoInfoCompleta(OrdenesPagoService.Id_NombreCol + " = " + dtDetalles.Rows[i][OrdenesPagoDetalleService.OrdenPagoId_NombreCol], string.Empty);
                if (dtOrdenPago.Rows[0][OrdenesPagoService.VistaCasoEstadoId_NombreCol].Equals(Definiciones.EstadosFlujos.Anulado))
                    contador--;
            }

            return contador > 0;
        }
        #endregion GetCasoRespaldadoFormaParteDeOP

        #region GetCasosIncluidos
        public static List<decimal> GetCasosIncluidos(decimal caso_id, SessionService sesion)
        {
            List<decimal> lCasos = new List<decimal>();
            DataTable dtCabecera = OrdenesPagoService.GetOrdenesPagoDataTable(OrdenesPagoService.CasoId_NombreCol + " = " + caso_id, string.Empty, sesion);
            DataTable dtDetalles = GetOrdenesPagoDetallesDataTable2(OrdenesPagoDetalleService.OrdenPagoId_NombreCol + " = " + dtCabecera.Rows[0][OrdenesPagoService.Id_NombreCol], string.Empty, sesion);
            for (int i = 0; i < dtDetalles.Rows.Count; i++)
                lCasos.Add((decimal)dtDetalles.Rows[i][OrdenesPagoDetalleService.CasoReferidoId_NombreCol]);
            return lCasos;
        }
        #endregion GetCasosIncluidos

        #region GetTotalPorCabecera
        public static decimal GetTotalPorCabecera(decimal orden_pago_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTotalPorCabecera(orden_pago_id, sesion);
            }
        }

        public static decimal GetTotalPorCabecera(decimal orden_pago_id, SessionService sesion)
        {
            var rows = sesion.db.ORDENES_PAGO_DETCollection.GetByORDEN_PAGO_ID(orden_pago_id);
            decimal total = 0;

            for (int i = 0; i < rows.Length; i++)
                total += rows[i].MONTO_DESTINO;
            return total;
        }
        #endregion GetTotalPorCabecera

        #region GetFechaDocumento
        public static string GetFechaDocumento(decimal ordenPagoDetalleId, SessionService sesion)
        {
            DataTable dt = sesion.Db.ORDENES_PAGO_DET_INFO_COMPCollection.GetAsDataTable(OrdenesPagoDetalleService.Id_NombreCol + " = " + ordenPagoDetalleId, string.Empty);
            return dt.Rows[0][OrdenesPagoDetalleService.VistaFacturaFechaEmision_NombreCol].ToString();
        }
        #endregion GetFechaDocumento

        #region QuitarReferenciaACtaCtePersona
        public static void QuitarReferenciaACtaCtePersona(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                ORDENES_PAGO_DETRow row = sesion.db.ORDENES_PAGO_DETCollection.GetByPrimaryKey(id);
                if (null != row)
                {
                    DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoDataTable(OrdenesPagoService.Id_NombreCol + " = " + row.ORDEN_PAGO_ID, string.Empty);
                    if (dtOrdenPago.Rows.Count > 0)
                    {
                        if (dtOrdenPago.Rows[0][OrdenesPagoService.OrdenPagoTipoId_NombreCol].Equals((decimal)Definiciones.TiposOrdenesPago.PagoAPersona))
                        {
                            row.IsCTACTE_PERSONA_IDNull = true;
                            sesion.db.ORDENES_PAGO_DETCollection.Update(row);
                        }
                    }
                }
            }
        }
        #endregion QuitarReferenciaACtaCtePersona

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    Guardar(campos, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }

            }
        }
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static void Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            ORDENES_PAGO_DETRow row = new ORDENES_PAGO_DETRow();
            DataTable dtOrdenPago;

            try
            {
                int tipoOP;
                string valorAnterior = Definiciones.Log.RegistroNuevo;
                DataTable dtAux;
                DateTime fechaCotizacionOrigen;

                row.ID = sesion.Db.GetSiguienteSecuencia("ordenes_pago_det_sqc");
                row.ORDEN_PAGO_ID = (decimal)campos[OrdenesPagoDetalleService.OrdenPagoId_NombreCol];
                dtOrdenPago = OrdenesPagoService.GetOrdenesPagoInfoCompleta(OrdenesPagoService.Id_NombreCol + " = " + row.ORDEN_PAGO_ID, string.Empty, sesion);
                var sucursal = new SucursalesService((decimal)dtOrdenPago.Rows[0][OrdenesPagoService.SucursalOrigenId_NombreCol], sesion);

                fechaCotizacionOrigen = (DateTime)dtOrdenPago.Rows[0][OrdenesPagoService.Fecha_NombreCol];

                CasosService casoRelacionado = null;
                if (campos.Contains(OrdenesPagoDetalleService.CasoReferidoId_NombreCol))
                    casoRelacionado = new CasosService((decimal)campos[OrdenesPagoDetalleService.CasoReferidoId_NombreCol], sesion);

                tipoOP = Convert.ToInt32(dtOrdenPago.Rows[0][OrdenesPagoService.OrdenPagoTipoId_NombreCol]);

                //Todavia no se utiliza
                //row.CTACTE_CAJA_TESO_DESTINO_ID;

                switch (tipoOP)
                {
                    case Definiciones.TiposOrdenesPago.ReposicionFondoFijo:
                        //Si cambia
                        if (row.IsSUCURSAL_DESTINO_IDNull || !row.SUCURSAL_DESTINO_ID.Equals(campos[OrdenesPagoDetalleService.SucursalDestinoId_NombreCol]))
                        {
                            if (SucursalesService.EstaActivo((decimal)campos[OrdenesPagoDetalleService.SucursalDestinoId_NombreCol]))
                                row.SUCURSAL_DESTINO_ID = (decimal)campos[OrdenesPagoDetalleService.SucursalDestinoId_NombreCol];
                            else
                                throw new Exception("La sucursal destino no está activa.");
                        }

                        //Si cambia
                        if (row.IsCTACTE_FONDO_FIJO_IDNull || !row.CTACTE_FONDO_FIJO_ID.Equals(campos[OrdenesPagoDetalleService.CtacteFondoFijoId_NombreCol]))
                        {
                            if (CuentaCorrienteFondosFijosService.EstaActivo((decimal)campos[OrdenesPagoDetalleService.CtacteFondoFijoId_NombreCol]))
                                row.CTACTE_FONDO_FIJO_ID = (decimal)campos[OrdenesPagoDetalleService.CtacteFondoFijoId_NombreCol];
                            else
                                throw new Exception("El fondo fijo destino no está activa.");
                        }
                        break;
                    case Definiciones.TiposOrdenesPago.PagoAProveedor:

                        var ctacteProveedor = new CuentaCorrienteProveedoresService((decimal)campos[OrdenesPagoDetalleService.CtacteProveedorId_NombreCol], sesion);
                        if (!ctacteProveedor.ExisteEnDB)
                            throw new System.Exception("El documento no fue encontrado.");

                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionCtacteIndependiente, sesion) == Definiciones.SiNo.Si)
                        {
                            if (ctacteProveedor.CasoId.HasValue && ctacteProveedor.Caso.Sucursal.RegionId != sucursal.RegionId)
                                throw new Exception("El documento proviene de una región distinta al caso.");
                        }

                        row.CTACTE_PROVEEDOR_ID = (decimal)campos[OrdenesPagoDetalleService.CtacteProveedorId_NombreCol];
                        row.CASO_REFERIDO_ID = (decimal)campos[OrdenesPagoDetalleService.CasoReferidoId_NombreCol];

                        if (ctacteProveedor.Caso.FlujoId == Definiciones.FlujosIDs.FACTURACION_PROVEEDOR)
                        {
                            var dtFacturaProveedor = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " = " + ctacteProveedor.CasoId.Value, string.Empty, sesion);
                            if (CondicionesPagoService.EsContado((decimal)dtFacturaProveedor.Rows[0][FacturasProveedorService.CtacteCondicionPagoId_NombreCol], sesion))
                                fechaCotizacionOrigen = (DateTime)dtFacturaProveedor.Rows[0][FacturasProveedorService.FechaFactura_NombreCol];
                        }

                        //la creación del detalle puede venir desde una planilla de salario
                        if (campos.Contains(OrdenesPagoDetalleService.LiquidacionId_NombreCol))
                            row.LIQUIDACION_ID = (decimal)campos[OrdenesPagoDetalleService.LiquidacionId_NombreCol];

                        //Controlar que no se esta ingresando por segunda vez
                        //el mismo documento a ser pagado
                        dtAux = GetOrdenesPagoDetallesDataTable2(OrdenesPagoDetalleService.OrdenPagoId_NombreCol + " = " + row.ORDEN_PAGO_ID + " and " + OrdenesPagoDetalleService.CtacteProveedorId_NombreCol + " = " + row.CTACTE_PROVEEDOR_ID, string.Empty);
                        if (dtAux.Rows.Count > 0)
                            throw new Exception("El documento ya forma parte de los detalles de la orden de pago.");

                        break;
                    case Definiciones.TiposOrdenesPago.PagoAPersona:
                        var ctactePersona = new CuentaCorrientePersonasService((decimal)campos[OrdenesPagoDetalleService.CtactePersonaId_NombreCol], sesion);
                        if (!ctactePersona.ExisteEnDB)
                            throw new System.Exception("El documento no fue encontrado.");
                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionCtacteIndependiente, sesion) == Definiciones.SiNo.Si)
                        {
                            if (ctactePersona.CasoId.HasValue && ctactePersona.Caso.Sucursal.RegionId != sucursal.RegionId)
                                throw new Exception("El documento proviene de una región distinta al caso.");
                        }
                        row.CTACTE_PERSONA_ID = (decimal)campos[OrdenesPagoDetalleService.CtactePersonaId_NombreCol];
                        row.CASO_REFERIDO_ID = (decimal)campos[OrdenesPagoDetalleService.CasoReferidoId_NombreCol];
                        row.FLUJO_REFERIDO_ID = (decimal)campos[OrdenesPagoDetalleService.FlujoReferidoId_NombreCol];
                        //Controlar que no se esta ingresando por segunda vez
                        //el mismo documento a ser pagado
                        dtAux = GetOrdenesPagoDetallesDataTable2(OrdenesPagoDetalleService.OrdenPagoId_NombreCol + " = " + row.ORDEN_PAGO_ID + " and " + OrdenesPagoDetalleService.CtactePersonaId_NombreCol + " = " + row.CTACTE_PERSONA_ID, string.Empty);
                        if (dtAux.Rows.Count > 0)
                            throw new Exception("El documento ya forma parte de los detalles de la orden de pago.");

                        break;
                    case Definiciones.TiposOrdenesPago.RespaldoAjusteBancario:
                        row.CTACTE_PROVEEDOR_ID = (decimal)campos[OrdenesPagoDetalleService.CtacteProveedorId_NombreCol];

                        //Controlar que no se esta ingresando por segunda vez
                        //el mismo documento a ser pagado
                        DataTable dt2 = GetOrdenesPagoDetallesDataTable2(OrdenesPagoDetalleService.OrdenPagoId_NombreCol + " = " + row.ORDEN_PAGO_ID + " and " + OrdenesPagoDetalleService.CtacteProveedorId_NombreCol + " = " + row.CTACTE_PROVEEDOR_ID, string.Empty);
                        if (dt2.Rows.Count > 0)
                            throw new Exception("El documento ya forma parte de los detalles de la orden de pago.");

                        break;
                    case Definiciones.TiposOrdenesPago.RespaldoAnticipoProveedor:
                    case Definiciones.TiposOrdenesPago.RespaldoCambioDivisa:
                    case Definiciones.TiposOrdenesPago.RespaldoCustodiaValores:
                    case Definiciones.TiposOrdenesPago.RespaldoDescuentoDocumentos:
                    case Definiciones.TiposOrdenesPago.RespaldoTransferenciaBancaria:
                    case Definiciones.TiposOrdenesPago.RespaldoTransferenciaTesoreria:
                    case Definiciones.TiposOrdenesPago.AdelantoFuncionario:
                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionCtacteIndependiente, sesion) == Definiciones.SiNo.Si)
                        {
                            if (casoRelacionado.Sucursal.RegionId != sucursal.RegionId)
                                throw new Exception("El documento proviene de una región distinta al caso.");
                        }
                        row.FLUJO_REFERIDO_ID = Convert.ToDecimal(campos[OrdenesPagoDetalleService.FlujoReferidoId_NombreCol]);
                        row.CASO_REFERIDO_ID = (decimal)campos[OrdenesPagoDetalleService.CasoReferidoId_NombreCol];
                        break;
                    case Definiciones.TiposOrdenesPago.PagoFuncionarios:
                        //Si cambia
                        if (row.IsSUCURSAL_DESTINO_IDNull || !row.SUCURSAL_DESTINO_ID.Equals(campos[OrdenesPagoDetalleService.SucursalDestinoId_NombreCol]))
                        {
                            if (SucursalesService.EstaActivo((decimal)campos[OrdenesPagoDetalleService.SucursalDestinoId_NombreCol]))
                                row.SUCURSAL_DESTINO_ID = (decimal)campos[OrdenesPagoDetalleService.SucursalDestinoId_NombreCol];
                            else
                                throw new Exception("La sucursal destino no está activa.");
                        }

                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionCtacteIndependiente, sesion) == Definiciones.SiNo.Si)
                        {
                            if (casoRelacionado.Sucursal.RegionId != sucursal.RegionId)
                                throw new Exception("El documento proviene de una región distinta al caso.");
                        }

                        row.CASO_REFERIDO_ID = (decimal)campos[OrdenesPagoDetalleService.CasoReferidoId_NombreCol];
                        row.FLUJO_REFERIDO_ID = (decimal)campos[OrdenesPagoDetalleService.FlujoReferidoId_NombreCol];
                        row.LIQUIDACION_ID = (decimal)campos[OrdenesPagoDetalleService.LiquidacionId_NombreCol];
                        break;
                }

                row.MONEDA_ORIGEN_ID = (decimal)campos[OrdenesPagoDetalleService.MonedaOrigenId_NombreCol];

                //Se actualiza la cotizacion de la moneda
                if (campos.Contains(OrdenesPagoDetalleService.CotizacionMonedaOrigen_NombreCol))
                {
                    row.COTIZACION_MONEDA_ORIGEN = (decimal)campos[OrdenesPagoDetalleService.CotizacionMonedaOrigen_NombreCol];
                }
                else
                {
                    row.COTIZACION_MONEDA_ORIGEN = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtOrdenPago.Rows[0][OrdenesPagoService.SucursalOrigenId_NombreCol]), row.MONEDA_ORIGEN_ID, fechaCotizacionOrigen, sesion);
                    if (row.COTIZACION_MONEDA_ORIGEN.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda destino.");
                }

                row.MONTO_ORIGEN = (decimal)campos[OrdenesPagoDetalleService.MontoOrigen_NombreCol];

                //Si las monedas origen y destino son distintas no debe convertirse
                if (row.MONEDA_ORIGEN_ID != (decimal)dtOrdenPago.Rows[0][OrdenesPagoService.MonedaId_NombreCol])
                    row.MONTO_DESTINO = row.MONTO_ORIGEN / row.COTIZACION_MONEDA_ORIGEN * (decimal)dtOrdenPago.Rows[0][OrdenesPagoService.CotizacionMoneda_NombreCol];
                else
                    row.MONTO_DESTINO = row.MONTO_ORIGEN;

                row.OBSERVACION = (string)campos[OrdenesPagoDetalleService.Observacion_NombreCol];

                sesion.Db.ORDENES_PAGO_DETCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            if (!dtOrdenPago.Rows[0][OrdenesPagoService.ProveedorId_NombreCol].Equals(DBNull.Value))
            {
                DateTime fechaDocumento = DateTime.Parse(OrdenesPagoDetalleService.GetFechaDocumento(row.ID, sesion).ToString());

                //Verificar si debe retenerse e incluir en forma
                //automatica las retenciones como parte de los valores
                RetenerSiCorresponde(row.ORDEN_PAGO_ID, fechaDocumento, sesion);
            }
        }

        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified orden_pago_valor_id.
        /// </summary>
        /// <param name="orden_pago_detalle_id">The orden_pago_detalle_id.</param>
        public static void Borrar(decimal orden_pago_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.BeginTransaction();
                Borrar(orden_pago_detalle_id, sesion);
                sesion.CommitTransaction();
            }
        }

        public static void Borrar(decimal orden_pago_detalle_id, SessionService sesion)
        {
            ORDENES_PAGO_DETRow row;
            row = sesion.Db.ORDENES_PAGO_DETCollection.GetByPrimaryKey(orden_pago_detalle_id);

            //se guarda la fecha de la factura en una variable para luego borrar las retenciones guardadas en valores
            DateTime fechaDocumento = DateTime.Parse(OrdenesPagoDetalleService.GetFechaDocumento(orden_pago_detalle_id, sesion).ToString());
            DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoDataTable(OrdenesPagoService.Id_NombreCol + " = " + row.ORDEN_PAGO_ID, string.Empty);

            try
            {
                //se buscan las notas de credito relacionadas a la factura borrada
                string query = "";
                query += "select * from " + OrdenesPagoValoresService.Nombre_Tabla + " opv " + "\n";
                query += "where opv." + OrdenesPagoValoresService.NotaCreditoProveedorId_NombreCol + " = " + "\n";
                query += "(select ncp." + NotasCreditoProveedorService.Id_NombreCol + " \n";
                query += "from " + NotasCreditoProveedorService.Nombre_Tabla + " ncp, " + NotasCreditoProveedorDetalleService.Nombre_Tabla + " ncpd " + "\n";
                query += "where ncpd." + NotasCreditoProveedorDetalleService.NotaCreditoId_NombreCol + " = ncp." + NotasCreditoProveedorService.Id_NombreCol + " \n";
                query += "and ncpd." + NotasCreditoProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + "\n";
                query += "(select fp." + FacturasProveedorService.Id_NombreCol + " from " + FacturasProveedorService.Nombre_Tabla + " fp where fp." + FacturasProveedorService.CasoId_NombreCol + " = " + row.CASO_REFERIDO_ID + ")) \n";
                query += "and opv." + OrdenesPagoValoresService.OrdenPagoId_NombreCol + " = " + row.ORDEN_PAGO_ID;

                DataTable dtValores = sesion.db.EjecutarQuery(query);

                if (dtValores.Rows.Count > 0)
                {
                    for (int j = 0; j < dtValores.Rows.Count; j++)
                        OrdenesPagoValoresService.Borrar(decimal.Parse(dtValores.Rows[j][OrdenesPagoValoresService.Id_NombreCol].ToString()));
                }

                query = "";
                query += "select * from " + PlanillasPagosDetallesService.Nombre_Tabla + " ppd " + "\n";
                query += "where ppd." + PlanillasPagosDetallesService.OpCasoId_NombreCol + " = " + dtOrdenPago.Rows[0][OrdenesPagoService.CasoId_NombreCol] + "\n";
                query += "and ppd." + PlanillasPagosDetallesService.CtaCteProvCasoId_NombreCol + " = " + row.CASO_REFERIDO_ID;

                DataTable dtPlanillaPagosDetalles = sesion.db.EjecutarQuery(query);

                if (dtPlanillaPagosDetalles.Rows.Count > 0)
                {
                    PlanillasPagosDetallesService p = new PlanillasPagosDetallesService();
                    p.Borrar(decimal.Parse(dtPlanillaPagosDetalles.Rows[0][PlanillasPagosDetallesService.Id_NombreCol].ToString()));

                    DataTable dt = p.GetPlanillaDetallesPorPlanilla(decimal.Parse(dtPlanillaPagosDetalles.Rows[0][PlanillasPagosDetallesService.PlanillaPagoId_NombreCol].ToString()));

                    if (dt.Rows.Count == 0)
                    {
                        PlanillasPagosService.ActualizarOPGenerada(decimal.Parse(dtPlanillaPagosDetalles.Rows[0][PlanillasPagosDetallesService.PlanillaPagoId_NombreCol].ToString()), Definiciones.SiNo.No, sesion);
                        PlanillasPagosService.ActualizarTotal(decimal.Parse(dtPlanillaPagosDetalles.Rows[0][PlanillasPagosDetallesService.PlanillaPagoId_NombreCol].ToString()), 0, sesion);
                    }
                    else
                    {
                        decimal montoTotal = dt.AsEnumerable().Sum(rowDetalles => rowDetalles.Field<decimal>(PlanillasPagosDetallesService.MontoAPagar_NombreCol));
                        PlanillasPagosService.ActualizarTotal(decimal.Parse(dtPlanillaPagosDetalles.Rows[0][PlanillasPagosDetallesService.PlanillaPagoId_NombreCol].ToString()), montoTotal, sesion);
                    }
                }

                sesion.Db.ORDENES_PAGO_DETCollection.DeleteByPrimaryKey(orden_pago_detalle_id);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }

            if (!dtOrdenPago.Rows[0][OrdenesPagoService.ProveedorId_NombreCol].Equals(DBNull.Value))
            {
                //Verificar si debe retenerse e incluir en forma
                //automatica las retenciones como parte de los valores
                RetenerSiCorresponde(row.ORDEN_PAGO_ID, fechaDocumento, sesion);
            }
        }
        #endregion borrar

        #region ActualizarComprobante
        public static void ActualizarComprobante(decimal detalleId, string comprobante)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    DataTable dtDetalles;
                    ORDENES_PAGO_DETRow detalleRow;
                    string valorAnterior;

                    string clausula = OrdenesPagoDetalleService.Id_NombreCol + " = " + detalleId.ToString();
                    dtDetalles = GetOrdenesPagoDetallesDataTable2(clausula, string.Empty);
                    detalleRow = sesion.Db.ORDENES_PAGO_DETCollection.GetByPrimaryKey((decimal)dtDetalles.Rows[0][OrdenesPagoDetalleService.Id_NombreCol]);
                    valorAnterior = detalleRow.ToString();
                    detalleRow.NRO_COMPROBANTE = comprobante;

                    sesion.Db.ORDENES_PAGO_DETCollection.Update(detalleRow);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, detalleRow.ID, valorAnterior, detalleRow.ToString(), sesion);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion ActualizarComprobante

        #region Nombres para columnas del SQL de retenciones
        protected abstract class NombreColumnas
        {
            public const string casos_factura = "casos_factura";
            public const string tipo_condicion_pago = "tipo_condicion_pago";
            public const string fecha = "fecha";
            public const string moneda = "moneda_id";
            public const string gravado = "gravado";
            public const string iva = "iva";
        }
        #endregion Nombres para columnas del SQL de retenciones

        #region RetenerSiCorresponde
        private static void RetenerSiCorresponde(decimal orden_pago_id, DateTime fechaDocumento, SessionService sesion)
        {
            DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoDataTable(OrdenesPagoService.Id_NombreCol + " = " + orden_pago_id, string.Empty, sesion);
            DataTable dtOrdenPagoValor = OrdenesPagoValoresService.GetOrdenesPagoValoresDataTable(OrdenesPagoValoresService.OrdenPagoId_NombreCol + " = " + orden_pago_id + " and " + OrdenesPagoValoresService.CtacteValorId_NombreCol + " = " + Definiciones.CuentaCorrienteValores.RetencionIVA, string.Empty, sesion);
            string[] strAux;
            decimal decimalAux;

            // Se borran los valores de retencion en la OP, si existen
            for (int i = 0; i < dtOrdenPagoValor.Rows.Count; i++)
                OrdenesPagoValoresService.Borrar((decimal)dtOrdenPagoValor.Rows[i][OrdenesPagoValoresService.Id_NombreCol], sesion);

            List<Hashtable> lRetencionesAEmitir = new List<Hashtable>();

            if (ProveedoresService.EsPasibleRetencion((decimal)dtOrdenPago.Rows[0][OrdenesPagoService.ProveedorId_NombreCol], fechaDocumento))
            {
                lRetencionesAEmitir = CuentaCorrienteRetencionesEmitidasService.GetRetencionesAEmitir(
                                        (decimal)dtOrdenPago.Rows[0][OrdenesPagoService.CasoId_NombreCol],
                                        (decimal)dtOrdenPago.Rows[0][OrdenesPagoService.ProveedorId_NombreCol],
                                        dtOrdenPago.Rows[0][OrdenesPagoService.FechaReciboBeneficiario_NombreCol].Equals(DBNull.Value) ? (DateTime)dtOrdenPago.Rows[0][OrdenesPagoService.Fecha_NombreCol] : (DateTime)dtOrdenPago.Rows[0][OrdenesPagoService.FechaReciboBeneficiario_NombreCol],
                                        (string)dtOrdenPago.Rows[0][OrdenesPagoService.RetencionUnificada_NombreCol] == Definiciones.SiNo.Si,
                                        sesion);
            }

            foreach (Hashtable ht in lRetencionesAEmitir)
            {
                DataTable dtTiposRetenciones = TiposRetencionesService.GetTiposRetencionesDataTable(TiposRetencionesService.Id_NombreCol + " = " + ht[CuentaCorrienteRetencionesEmitidasDetalleService.RetencionTipoId_NombreCol], string.Empty);

                Hashtable campos = new System.Collections.Hashtable();
                campos.Add(OrdenesPagoValoresService.OrdenPagoId_NombreCol, dtOrdenPago.Rows[0][OrdenesPagoService.Id_NombreCol]);
                campos.Add(OrdenesPagoValoresService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.RetencionIVA);
                campos.Add(OrdenesPagoValoresService.RetencionTipoId_NombreCol, ht[CuentaCorrienteRetencionesEmitidasDetalleService.RetencionTipoId_NombreCol]);

                strAux = ht[CuentaCorrienteRetencionesEmitidasService.MonedaId_NombreCol].ToString().Split('@');
                campos.Add(OrdenesPagoValoresService.MonedaOrigenId_NombreCol, decimal.Parse(strAux[0]));

                //Si las monedas son distintas el total es incorrecto. Nadie deberia mezclar monedas en la 
                //misma retencion, por proteccion se sugiere sumar los detalles en vez de tomar el total de la cabecera
                strAux = ht[CuentaCorrienteRetencionesEmitidasService.Total_NombreCol].ToString().Split('@');
                decimalAux = 0;
                for (int i = 0; i < strAux.Length; i++)
                    decimalAux += decimal.Parse(strAux[i]);
                campos.Add(OrdenesPagoValoresService.MontoOrigen_NombreCol, decimalAux);

                campos.Add(OrdenesPagoValoresService.Observacion_NombreCol, ht[CuentaCorrienteRetencionesEmitidasService.Observacion_NombreCol]);
                campos.Add(OrdenesPagoValoresService.RetencionAuxCasos_NombreCol, ht[CuentaCorrienteRetencionesEmitidasDetalleService.CasoId_NombreCol]);
                campos.Add(OrdenesPagoValoresService.RetencionAuxMontos_NombreCol, ht[CuentaCorrienteRetencionesEmitidasService.Total_NombreCol]);
                campos.Add(OrdenesPagoValoresService.RetencionFecha_NombreCol, ht[CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol]);
                OrdenesPagoValoresService.Guardar(campos, sesion);
            }
        }
        #endregion RetenerSiCorresponde

        #region Accessors

        public static string Nombre_Tabla
        {
            get { return "ORDENES_PAGO_DET"; }
        }
        public static string Nombre_Vista
        {
            get { return "ORDENES_PAGO_DET_INFO_COMP"; }
        }
        public static string CasoReferidoId_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.CASO_REFERIDO_IDColumnName; }
        }
        public static string CtacteCajaTesoDestinoId_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.CTACTE_CAJA_TESO_DESTINO_IDColumnName; }
        }
        public static string CtacteFondoFijoId_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.CTACTE_FONDO_FIJO_IDColumnName; }
        }
        public static string CtactePersonaId_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.CTACTE_PERSONA_IDColumnName; }
        }
        public static string CtacteProveedorId_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.CTACTE_PROVEEDOR_IDColumnName; }
        }
        public static string CotizacionMonedaOrigen_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.COTIZACION_MONEDA_ORIGENColumnName; }
        }
        public static string FlujoReferidoId_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.FLUJO_REFERIDO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.IDColumnName; }
        }
        public static string MonedaOrigenId_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.MONEDA_ORIGEN_IDColumnName; }
        }
        public static string MontoDestino_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.MONTO_DESTINOColumnName; }
        }
        public static string MontoOrigen_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.MONTO_ORIGENColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.OBSERVACIONColumnName; }
        }
        public static string OrdenPagoId_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.ORDEN_PAGO_IDColumnName; }
        }
        public static string SucursalDestinoId_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.SUCURSAL_DESTINO_IDColumnName; }
        }
        public static string LiquidacionId_NombreCol
        {
            get { return ORDENES_PAGO_DETCollection.LIQUIDACION_IDColumnName; }
        }
        public static string VistaCasoReferidoEstadoId_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.CASO_REFERIDO_ESTADO_IDColumnName; }
        }
        public static string VistaCtacteCajaTesoDestinoAbrev_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.CTACTE_CAJA_TESO_DEST_ABREVColumnName; }
        }
        public static string VistaCtacteCajaTesoDestinoNomb_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.CTACTE_CAJA_TESO_DEST_NOMBREColumnName; }
        }
        public static string VistaFacturaFechaEmision_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.FACTURA_FECHA_EMISIONColumnName; }
        }
        public static string VistaCtacteFechaVencimiento_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.CTACTE_FECHA_VENCIMIENTOColumnName; }
        }
        public static string VistaCtacteFondoFijoAbreviatura_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.CTACTE_FONDO_FIJO_ABREVIATURAColumnName; }
        }
        public static string VistaCtacteFondoFijoNombre_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.CTACTE_FONDO_FIJO_NOMBREColumnName; }
        }
        public static string VistaCtacteProveedorCasoId_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.CTACTE_PROVEEDOR_CASO_IDColumnName; }
        }
        public static string VistaCtactePersonaCasoId_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.CTACTE_PERSONA_CASO_IDColumnName; }
        }
        public static string VistaCtacteConceptoDescripcion_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.CTACTE_CONCEPTO_DESCRIPCIONColumnName; }
        }
        public static string VistaFlujoDescripcion_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.FLUJO_DESCRIPCIONColumnName; }
        }
        public static string VistaFlujoDescripcionImpresion_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.FLUJO_DESCRIPCION_IMPRESIONColumnName; }
        }
        public static string VistaMonedaOrigenNombre_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.MONEDA_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaMonedaOrigenSimbolo_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.MONEDA_ORIGEN_SIMBOLOColumnName; }
        }
        public static string VistaSucursalDestinoAbreviatura_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.SUCURSAL_DESTINO_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalDestinoNombre_NombreCol
        {
            get { return ORDENES_PAGO_DET_INFO_COMPCollection.SUCURSAL_DESTINO_NOMBREColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static OrdenesPagoDetalleService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new OrdenesPagoDetalleService(e.RegistroId, sesion);
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
        protected ORDENES_PAGO_DETRow row;
        protected ORDENES_PAGO_DETRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? CasoReferidoId { get { if (row.IsCASO_REFERIDO_IDNull) return null; else return row.CASO_REFERIDO_ID; } set { if (value.HasValue) row.CASO_REFERIDO_ID = value.Value; else row.IsCASO_REFERIDO_IDNull = true; } }
        public decimal? CotizacionMonedaOrigen { get { if (row.IsCOTIZACION_MONEDA_ORIGENNull) return null; else return row.COTIZACION_MONEDA_ORIGEN; } set { if (value.HasValue) row.COTIZACION_MONEDA_ORIGEN = value.Value; else row.IsCOTIZACION_MONEDA_ORIGENNull = true; } }
        public decimal? CtacteFondoFijoId { get { if (row.IsCTACTE_FONDO_FIJO_IDNull) return null; else return row.CTACTE_FONDO_FIJO_ID; } set { if (value.HasValue) row.CTACTE_FONDO_FIJO_ID = value.Value; else row.IsCTACTE_FONDO_FIJO_IDNull = true; } }
        public decimal? CtacteCajaTesoDestinoId { get { if (row.IsCTACTE_CAJA_TESO_DESTINO_IDNull) return null; else return row.CTACTE_CAJA_TESO_DESTINO_ID; } set { if (value.HasValue) row.CTACTE_CAJA_TESO_DESTINO_ID = value.Value; else row.IsCTACTE_CAJA_TESO_DESTINO_IDNull = true; } }
        public decimal? CtacteProveedorId { get { if (row.IsCTACTE_PROVEEDOR_IDNull) return null; else return row.CTACTE_PROVEEDOR_ID; } set { if (value.HasValue) row.CTACTE_PROVEEDOR_ID = value.Value; else row.IsCTACTE_PROVEEDOR_IDNull = true; } }
        public decimal? CtactePersonaId { get { if (row.IsCTACTE_PERSONA_IDNull) return null; else return row.CTACTE_PERSONA_ID; } set { if (value.HasValue) row.CTACTE_PERSONA_ID = value.Value; else row.IsCTACTE_PERSONA_IDNull = true; } }
        public decimal? FlujoReferidoId { get { if (row.IsFLUJO_REFERIDO_IDNull) return null; else return row.FLUJO_REFERIDO_ID; } set { if (value.HasValue) row.FLUJO_REFERIDO_ID = value.Value; else row.IsFLUJO_REFERIDO_IDNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? LiquidacionId { get { if (row.IsLIQUIDACION_IDNull) return null; else return row.LIQUIDACION_ID; } set { if (value.HasValue) row.LIQUIDACION_ID = value.Value; else row.IsLIQUIDACION_IDNull = true; } }
        public decimal? MonedaOrigenId { get { if (row.IsMONEDA_ORIGEN_IDNull) return null; else return row.MONEDA_ORIGEN_ID; } set { if (value.HasValue) row.MONEDA_ORIGEN_ID = value.Value; else row.IsMONEDA_ORIGEN_IDNull = true; } }
        public decimal? MontoDestino { get { if (row.IsMONTO_DESTINONull) return null; else return row.MONTO_DESTINO; } set { if (value.HasValue) row.MONTO_DESTINO = value.Value; else row.IsMONTO_DESTINONull = true; } }
        public decimal? MontoOrigen { get { if (row.IsMONTO_ORIGENNull) return null; else return row.MONTO_ORIGEN; } set { if (value.HasValue) row.MONTO_ORIGEN = value.Value; else row.IsMONTO_ORIGENNull = true; } }
        public string NroComprobante { get { return ClaseCBABase.GetStringHelper(row.NRO_COMPROBANTE); } set { row.NRO_COMPROBANTE = value; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal OrdenPagoId { get { return row.ORDEN_PAGO_ID; } set { row.ORDEN_PAGO_ID = value; } }
        public decimal? SucursalDestinoId { get { if (row.IsSUCURSAL_DESTINO_IDNull) return null; else return row.SUCURSAL_DESTINO_ID; } set { if (value.HasValue) row.SUCURSAL_DESTINO_ID = value.Value; else row.IsSUCURSAL_DESTINO_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CasosService _caso_referido;
        public CasosService CasoReferido
        {
            get
            {
                if (this._caso_referido == null)
                    this._caso_referido = new CasosService(this.CasoReferidoId.Value);
                return this._caso_referido;
            }
        }

        private FlujosService _flujo_referido;
        public FlujosService FlujoReferido
        {
            get
            {
                if (this._flujo_referido == null)
                    this._flujo_referido = new FlujosService(this.FlujoReferidoId.Value);
                return this._flujo_referido;
            }
        }

        private CuentaCorrientePersonasService _ctacte_persona;
        public CuentaCorrientePersonasService CtactePersona
        {
            get
            {
                if (this._ctacte_persona == null)
                    this._ctacte_persona = new CuentaCorrientePersonasService(this.CtactePersonaId.Value);
                return this._ctacte_persona;
            }
        }

        private CuentaCorrienteProveedoresService _ctacte_proveedor;
        public CuentaCorrienteProveedoresService CtacteProveedor
        {
            get
            {
                if (this._ctacte_proveedor == null)
                    this._ctacte_proveedor = new CuentaCorrienteProveedoresService(this.CtacteProveedorId.Value);
                return this._ctacte_proveedor;
            }
        }

        private MonedasService _moneda_origen;
        public MonedasService MonedaOrigen
        {
            get
            {
                if (this._moneda_origen == null)
                    this._moneda_origen = new MonedasService(this.MonedaOrigenId.Value);
                return this._moneda_origen;
            }
        }

        private OrdenesPagoService _orden_pago;
        public OrdenesPagoService OrdenPago
        {
            get
            {
                if (this._orden_pago == null)
                    this._orden_pago = new OrdenesPagoService(this.OrdenPagoId);
                return this._orden_pago;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.ORDENES_PAGO_DETCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ORDENES_PAGO_DETRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true;
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(ORDENES_PAGO_DETRow row)
        {
            this.AlmacenarLocalmente = true;
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public OrdenesPagoDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public OrdenesPagoDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public OrdenesPagoDetalleService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        private OrdenesPagoDetalleService(ORDENES_PAGO_DETRow row)
        {
            Inicializar(row);
        }
        public OrdenesPagoDetalleService(EdiCBA.OrdenPagoDocumento edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = OrdenesPagoDetalleService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion);

            if (edi.cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion'.");
            this.CotizacionMonedaOrigen = edi.cotizacion.venta;

            #region orden pago
            if (!string.IsNullOrEmpty(edi.orden_pago_uuid))
                this._orden_pago = OrdenesPagoService.GetPorUUID(edi.orden_pago_uuid, sesion);
            if (this._orden_pago == null && edi.orden_pago != null)
                this._orden_pago = new OrdenesPagoService(edi.orden_pago, almacenar_localmente, sesion);
            if (this._orden_pago != null)
            {
                if (!this.OrdenPago.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.OrdenPago.Id.HasValue)
                    this.OrdenPagoId = this.OrdenPago.Id.Value;
            }
            #endregion orden pago

            #region ctacte proveedor
            if (!string.IsNullOrEmpty(edi.ctacte_proveedor_uuid))
                this._ctacte_proveedor = CuentaCorrienteProveedoresService.GetPorUUID(edi.ctacte_proveedor_uuid, sesion);
            if (this._ctacte_proveedor == null && edi.ctacte_proveedor != null)
                this._ctacte_proveedor = new CuentaCorrienteProveedoresService(edi.ctacte_proveedor, almacenar_localmente, sesion);

            if (this._ctacte_proveedor != null)
            {
                if (!this._ctacte_proveedor.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this._ctacte_proveedor.Id.HasValue)
                    this.CtacteProveedorId = this.CtacteProveedor.Id.Value;
            }
            #endregion ctacte proveedor

            #region moneda origen
            if (!string.IsNullOrEmpty(edi.moneda_uuid))
                this._moneda_origen = MonedasService.GetPorUUID(edi.moneda_uuid, sesion);
           
            if (this._moneda_origen == null)
                throw new Exception("No se encontró el UUID " + edi.moneda_uuid + " ni se definieron los datos del objeto.");

            if (!this.MonedaOrigen.ExisteEnDB && almacenar_localmente)
            {
                this.MonedaOrigen.IniciarUsingSesion(sesion);
                this.MonedaOrigen.Guardar();
                this.MonedaOrigen.FinalizarUsingSesion();
            }
            if (this.MonedaOrigen.Id.HasValue)
                this.MonedaOrigenId = this.MonedaOrigen.Id.Value;
            #endregion moneda origen

            this.MontoOrigen = edi.monto;
            this.MontoDestino = this.MontoOrigen;

            this.Observacion = edi.observacion;
        }
        #endregion Constructores

        #region GetPorCabecera
        public static OrdenesPagoDetalleService[] GetPorCabecera(decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCabecera(cabecera_id, sesion);
            }
        }

        public static OrdenesPagoDetalleService[] GetPorCabecera(decimal cabecera_id, SessionService sesion)
        {
            var rows = sesion.db.ORDENES_PAGO_DETCollection.GetAsArray(OrdenesPagoDetalleService.OrdenPagoId_NombreCol + " = " + cabecera_id, OrdenesPagoDetalleService.Id_NombreCol);
            OrdenesPagoDetalleService[] opd = new OrdenesPagoDetalleService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                opd[i] = new OrdenesPagoDetalleService(rows[i]);
            return opd;
        }
        #endregion GetPorCabecera

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.OrdenPagoDocumento()
            {
                orden_pago_uuid = this.OrdenPago.GetOrCreateUUID(sesion),
                cotizacion_uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, OrdenesPagoDetalleService.CotizacionMonedaOrigen_NombreCol, this.Id.Value, sesion),
                ctacte_proveedor_uuid = this.CtacteProveedorId.HasValue ? this.CtacteProveedor.GetOrCreateUUID(sesion) : null,
                moneda_uuid = this.MonedaOrigen.GetOrCreateUUID(sesion),
                monto = this.MontoOrigen.Value,
                observacion = this.Observacion,
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.cotizacion = new EdiCBA.Cotizacion()
                {
                    uuid = e.cotizacion_uuid,
                    fecha = this.OrdenPago.Fecha.Value,
                    moneda_uuid = this.MonedaOrigen.ToEDI().uuid,
                    venta = this.CotizacionMonedaOrigen.Value
                };
                e.ctacte_proveedor = this.CtacteProveedorId.HasValue ? (EdiCBA.CtacteProveedor)this.CtacteProveedor.ToEDI(nueva_profundidad, sesion) : null;
                e.moneda = (EdiCBA.Moneda)this.MonedaOrigen.ToEDI(nueva_profundidad, sesion);
            }

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value);
            }
            return e;
        }
        #endregion ToEDI
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
