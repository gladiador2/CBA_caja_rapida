#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Comercial;
using System.Collections;
using CBA.FlowV2.Services.Presupuestos;
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class PlanesFacturacionService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.PLANES_FACTURACION;
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

            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, drCabecera[PlanesFacturacionService.DepositoId_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, drDetalle[PlanesFacturacionEtapasDetallesService.ArticuloId_NombreCol]);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, );
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, drDetalle[PlanesFacturacionEtapasDetallesService.ActivoId_NombreCol]);
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
            mensaje = "";
            try
            {
                CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                PLANES_FACTURACIONRow cabeceraRow = sesion.Db.PLANES_FACTURACIONCollection.GetByCASO_ID(caso_id)[0];

                //Verificar si se cumplen los requisitos
                exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                if (!exito)
                    throw new Exception("Requisitos no cumplidos.");

                //Borrador a Anulado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //No se realiza ninguna accion

                    exito = true;
                }
                //Borrador a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Se crea la numeracion si no existia

                    exito = true;

                    #region Generar numeracion
                    if (exito && (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Length <= 0))
                    {
                        try
                        {
                            if (cabeceraRow.IsAUTONUMERACION_IDNull)
                                throw new Exception("Debe indicarse el talonario.");

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
                    #endregion Generar numeracion
                }
                //Pendiente a Borrador
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //No se realiza ninguna accion

                    exito = true;
                }
                //Pendiente a Vigente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Vigente))
                {
                    //Acciones
                    //No se realiza ninguna accion
                    exito = true;
                }
                //Vigente a Cerrado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Vigente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                {
                    //Acciones
                    //No se realiza ninguna accion
                    exito = true;
                }

                if (exito)
                {
                    sesion.Db.CASOSCollection.Update(casoRow);
                    sesion.Db.PLANES_FACTURACIONCollection.Update(cabeceraRow);
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
            PLANES_FACTURACIONRow row = sesion.Db.PLANES_FACTURACIONCollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE;
        }

        #endregion Implementacion de metodos abstract

        #region GetPlanFacturacionDataTable
        /// <summary>
        /// Gets the plan facturacion data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPlanFacturacionDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PLANES_FACTURACIONCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetFacturaCliente

        #region GetPlanFacturacionInfoCompleta
        /// <summary>
        /// Gets the plan facturacion info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPlanFacturacionInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PLANES_FACTURACION_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetFacturaClienteInfoCompleta

        #region GenerarEnAdelantado
        public static void GenerarEnAdelantado(decimal etapa_id, decimal flujo_id)
        {
            using (SessionService session = new SessionService())
            {
                GenerarEnAdelantado(etapa_id, flujo_id, session);
            }
        }

        private static void GenerarEnAdelantado(decimal etapa_id, decimal flujo_id, SessionService sesion)
        {

            try
            {
                string parametros, separador, hash;
                decimal webserviceParametroId;

                //parametros := caso + separador + flujo + separador + transicion + separador + pais + separador + entidad;
                separador = "@!@";
                parametros = "" + etapa_id + separador +
                                  flujo_id + separador +
                                  sesion.SucursalActiva.PAIS_ID + separador +
                                  sesion.Entidad.ID;
                hash = CBA.FlowV2.Services.Base.StringUtil.CrearHash(50);

                //Guardar los parametros
                webserviceParametroId = WebservicesParametrosService.Guardar(Definiciones.Webservices.PlanesFacturacionGenerarFacturas, string.Empty, parametros, hash, true);

                //No se utiliza el webservice realmente, sino que se llama directamente al metodo invocado desde el webservice
                GenerarFacturas(webserviceParametroId, hash, etapa_id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion GenerarEnAdelantado

        #region Obtener Monto y Objeto
        public static decimal GetTotal(int caso_id)
        {
            DataTable dt;

            string query = " select nvl((select nvl(round(sum(pfed." + PlanesFacturacionEtapasDetallesService.MontoBruto_NombreCol + "), m." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName + "),0) total_neto " + "\n" +
                           "  from " + PlanesFacturacionEtapasDetallesService.Nombre_Tabla + " pfed " + "\n" +
                           "  join " + PlanesFacturacionEtapasService.Nombre_Tabla + " pfe on pfe." + PlanesFacturacionEtapasService.Id_NombreCol + " = pfed." + PlanesFacturacionEtapasDetallesService.PlanFacturacionEtapaId_NombreCol + " \n" +
                           "  join " + PlanesFacturacionService.Nombre_Tabla + " pf on pf." + PlanesFacturacionService.Id_NombreCol + " = pfe." + PlanesFacturacionEtapasService.PlanFacturacionId_NombreCol + "\n" +
                           "  join " + MonedasService.Nombre_Tabla + " m on m." + MonedasService.Modelo.IDColumnName + " = pf." + PlanesFacturacionService.MonedaId_NombreCol + " \n" +
                           "  where pf." + PlanesFacturacionService.CasoId_NombreCol + " = " + caso_id + "\n" +
                           "  group by m." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName + "),0 ) total_neto" +
                           "  from dual";

            using (SessionService sesion = new SessionService())
                dt = sesion.db.EjecutarQuery(query);

            return (decimal)dt.Rows[0]["TOTAL_NETO"];
        }

        public static decimal GetTotal(decimal plan_facturacion_id)
        {
            DataTable dt;

            string query = " select nvl((select nvl(round(sum(pfed." + PlanesFacturacionEtapasDetallesService.MontoBruto_NombreCol + "), m." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName + "),0) total_neto " + "\n" +
                           "  from " + PlanesFacturacionEtapasDetallesService.Nombre_Tabla + " pfed " + "\n" +
                           "  join " + PlanesFacturacionEtapasService.Nombre_Tabla + " pfe on pfe." + PlanesFacturacionEtapasService.Id_NombreCol + " = pfed." + PlanesFacturacionEtapasDetallesService.PlanFacturacionEtapaId_NombreCol + " \n" +
                           "  join " + PlanesFacturacionService.Nombre_Tabla + " pf on pf." + PlanesFacturacionService.Id_NombreCol + " = pfe." + PlanesFacturacionEtapasService.PlanFacturacionId_NombreCol + "\n" +
                           "  join " + MonedasService.Nombre_Tabla + " m on m." + MonedasService.Modelo.IDColumnName + " = pf." + PlanesFacturacionService.MonedaId_NombreCol + " \n" +
                           "  where pf." + PlanesFacturacionService.Id_NombreCol + " = " + plan_facturacion_id + "\n" +
                           "  group by m." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName + "),0 ) total_neto" +
                           "  from dual";

            using (SessionService sesion = new SessionService())
                dt = sesion.db.EjecutarQuery(query);

            return (decimal)dt.Rows[0]["TOTAL_NETO"];
        }

        public static string GetObjeto(int caso_id)
        {
            DataTable dt;

            string query = "select p." + PresupuestosService.Objeto_NombreCol + " \n" +
                           " from " + PlanesFacturacionService.Nombre_Tabla + " pf , \n" +
                           "      " + PresupuestosService.Nombre_Tabla + " p \n" +
                           " where p." + PresupuestosService.CasoId_NombreCol + " = pf." + PlanesFacturacionService.CasoOrigenId_NombreCol + " \n" +
                           " and pf." + PlanesFacturacionService.CasoId_NombreCol + " = " + caso_id + "\n";

            using (SessionService sesion = new SessionService())
                dt = sesion.db.EjecutarQuery(query);

            string objeto = string.Empty;

            if (dt.Rows.Count > 0)
            {
                if (!Interprete.EsNullODBNull(dt.Rows[0][PresupuestosService.Objeto_NombreCol]))
                    objeto = (string)dt.Rows[0][PresupuestosService.Objeto_NombreCol];
            }

            return objeto;
        }
        #endregion Obtener Monto y Objeto

        #region GenerarFacturas
        public static string GenerarFacturas(decimal registro_id, string hash, decimal etapa_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    string[] parametros = WebservicesParametrosService.ObtenerParametros(registro_id, hash, sesion);

                    string clausulas;
                    DataTable dtPlanesFacturacion;
                    DataTable dtPlanesFacturacionEtapas;
                    DataTable dtPlanesFacturacionEtapasDet;
                    DataTable dtAutonumeracion, dtCtacteCondicionPago, dtFacturaCreada, dtLote;
                    Hashtable campos;
                    string casoFacturaEstado = string.Empty;
                    decimal casoFacturaId = Definiciones.Error.Valor.EnteroPositivo;
                    decimal cotizacionDestino, precioBrutoUnitario, monedaOrigen, cotizacionOrigen, factorConversion, precioConvertidoPorUnidad;
                    decimal porcentajeDescuento = 0;
                    DateTime fechaPrimerVencimiento, fechaSegundoVencimiento;
                    bool usarFechaPrimerVencimiento, usarFechaSegundoVencimiento;

                    dtPlanesFacturacionEtapas = PlanesFacturacionEtapasService.GetPlanesFacturacionEtapasDataTable(PlanesFacturacionEtapasService.Id_NombreCol + " = " + etapa_id, PlanesFacturacionEtapasService.Orden_NombreCol);
                    dtPlanesFacturacion = PlanesFacturacionService.GetPlanFacturacionInfoCompleta(PlanesFacturacionService.Id_NombreCol + " = " + (decimal)dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.PlanFacturacionId_NombreCol], PlanesFacturacionService.CasoId_NombreCol);

                    clausulas = PlanesFacturacionEtapasDetallesService.PlanFacturacionEtapaId_NombreCol + " = " + dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.Id_NombreCol] + " and " +
                                PlanesFacturacionEtapasDetallesService.VistaArticuloParaVenta_NombreCol + " = '" + Definiciones.SiNo.Si + "' ";
                    dtPlanesFacturacionEtapasDet = PlanesFacturacionEtapasDetallesService.GetPlanesFacturacionEtapasDetallesInfoCompleta(clausulas, PlanesFacturacionEtapasDetallesService.Id_NombreCol);

                    #region Crear cabecera de FC Cliente
                    campos = new System.Collections.Hashtable();
                    campos.Add(FacturasClienteService.CasoOrigenId_NombreCol, dtPlanesFacturacion.Rows[0][PlanesFacturacionService.CasoId_NombreCol]);
                    campos.Add(FacturasClienteService.AfectaCtacte_NombreCol, Definiciones.SiNo.Si);
                    campos.Add(FacturasClienteService.SucursalId_NombreCol, dtPlanesFacturacion.Rows[0][PlanesFacturacionService.SucursalId_NombreCol]);
                    campos.Add(FacturasClienteService.DepositoId_NombreCol, dtPlanesFacturacion.Rows[0][PlanesFacturacionService.DepositoId_NombreCol]);
                    campos.Add(FacturasClienteService.PersonaId_NombreCol, dtPlanesFacturacion.Rows[0][PlanesFacturacionService.PersonaId_NombreCol]);

                    if (dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.ProximaFecha_NombreCol] == DBNull.Value)
                    {
                        if (dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.FechaFacturacionDesde_NombreCol] == DBNull.Value)
                            campos.Add(FacturasClienteService.Fecha_NombreCol, DateTime.Parse(dtPlanesFacturacion.Rows[0][PlanesFacturacionService.Fecha_NombreCol].ToString()));
                        else
                            campos.Add(FacturasClienteService.Fecha_NombreCol, DateTime.Parse(dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.FechaFacturacionDesde_NombreCol].ToString()));
                    }
                    else
                    {
                        campos.Add(FacturasClienteService.Fecha_NombreCol, DateTime.Parse(dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.ProximaFecha_NombreCol].ToString()));
                    }

                    #region Obtener la primera autonumeracion disponible si no se definio una autonumeracion para las facturas
                    if (dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.AutonumeracionFacturaId_NombreCol] == DBNull.Value)
                    {
                        dtAutonumeracion = AutonumeracionesService.GetAutonumeracionesPorFlujo2(Definiciones.FlujosIDs.FACTURACION_CLIENTE, (decimal)dtPlanesFacturacion.Rows[0][PlanesFacturacionService.SucursalId_NombreCol]);
                        campos.Add(FacturasClienteService.AutonumeracionId_NombreCol, dtAutonumeracion.Rows[0][AutonumeracionesService.Id_NombreCol]);
                    }
                    else
                    {
                        campos.Add(FacturasClienteService.AutonumeracionId_NombreCol, (decimal)dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.AutonumeracionFacturaId_NombreCol]);
                    }
                    #endregion Obtener la primera autonumeracion disponible

                    #region Definir el tipo de factura
                    dtCtacteCondicionPago = CondicionesPagoService.GetCondicionesDataTable(CondicionesPagoService.Id_NombreCol + " = " + dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.CondicionPagoId_NombreCol], false);
                    campos.Add(FacturasClienteService.CondicionPagoId_NombreCol, dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.CondicionPagoId_NombreCol]);

                    //Contado si tiene una sola cuota y 0 dias para el vencimiento, sino Credito
                    if ((decimal)dtCtacteCondicionPago.Rows[0][CondicionesPagoService.CantidadPagos_NombreCol] == 1 && CondicionesPagoService.GetPrimerVencimientoPago((decimal)dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.CondicionPagoId_NombreCol], sesion) == 0)
                        campos.Add(FacturasClienteService.TipoFacturaId_NombreCol, Definiciones.TipoFactura.Contado);
                    else
                        campos.Add(FacturasClienteService.TipoFacturaId_NombreCol, Definiciones.TipoFactura.Credito);
                    #endregion Definir el tipo de factura

                    campos.Add(FacturasClienteService.MonedaDestinoId_NombreCol, dtPlanesFacturacion.Rows[0][PlanesFacturacionService.MonedaId_NombreCol]);

                    cotizacionDestino = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dtPlanesFacturacion.Rows[0][PlanesFacturacionService.SucursalId_NombreCol]), (decimal)dtPlanesFacturacion.Rows[0][PlanesFacturacionService.MonedaId_NombreCol], (DateTime)campos[FacturasClienteService.Fecha_NombreCol], sesion);
                    campos.Add(FacturasClienteService.CotizacionDestino_NombreCol, cotizacionDestino);

                    if (dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.ProximaFecha_NombreCol] == DBNull.Value)
                    {
                        if (dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.FechaFacturacionDesde_NombreCol] == DBNull.Value)
                            campos.Add(FacturasClienteService.FechaVencimiento_NombreCol, DateTime.Parse(dtPlanesFacturacion.Rows[0][PlanesFacturacionService.Fecha_NombreCol].ToString()));
                        else
                            campos.Add(FacturasClienteService.FechaVencimiento_NombreCol, DateTime.Parse(dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.FechaFacturacionDesde_NombreCol].ToString()));
                    }
                    else
                    {
                        campos.Add(FacturasClienteService.FechaVencimiento_NombreCol, DateTime.Parse(dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.ProximaFecha_NombreCol].ToString()));
                    }

                    if (!dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.ListaPrecioId_NombreCol].Equals(DBNull.Value))
                        campos.Add(FacturasClienteService.ListaPrecioId_NombreCol, dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.ListaPrecioId_NombreCol]);

                    campos.Add(FacturasClienteService.VendedorId_NombreCol, dtPlanesFacturacion.Rows[0][PlanesFacturacionService.FuncionarioId_NombreCol]);
                    campos.Add(FacturasClienteService.ComisionPorVenta_NombreCol, Definiciones.TiposComision.ComisionPorCobro);
                    campos.Add(FacturasClienteService.AfectaLineaCredito_NombreCol, VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCClienteAfectarLineaCredito));
                    campos.Add(FacturasClienteService.Observacion_NombreCol, string.Empty);
                    campos.Add(FacturasClienteService.PorcentajeDescSobreTotal_NombreCol, (decimal)0);
                    campos.Add(FacturasClienteService.AConsignacion_NombreCol, Definiciones.SiNo.No);
                    campos.Add(FacturasClienteService.Direccion_NombreCol, string.Empty);
                    campos.Add(FacturasClienteService.ObservacionEntrega_NombreCol, string.Empty);
                    campos.Add(FacturasClienteService.AfectaStock_NombreCol, Definiciones.SiNo.Si);
                    campos.Add(FacturasClienteService.TotalEntregaInicial_NombreCol, (decimal)0);
                    campos.Add(FacturasClienteService.ControlarCantidadMinimaDescuentoMaximo_NombreCol, Definiciones.SiNo.No);
                    campos.Add(FacturasClienteService.MoraPorcentaje_NombreCol, dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.MoraPorcentaje_NombreCol]);
                    campos.Add(FacturasClienteService.MoraDiasGracia_NombreCol, dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.MoraDiasGracia_NombreCol]);

                    FacturasClienteService.Guardar(campos, true, ref casoFacturaId, ref casoFacturaEstado, sesion);
                    #endregion Crear cabecera de FC Cliente

                    dtFacturaCreada = FacturasClienteService.GetFacturaClienteInfoCompleta(FacturasClienteService.CasoId_NombreCol + " = " + casoFacturaId, string.Empty, sesion);

                    //Actualizar la ultima FC creada a raiz de la etapa
                    PlanesFacturacionEtapasService.ActualizarProximaFC((decimal)dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.Id_NombreCol], 
                        (decimal)dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.Intervalo_NombreCol], 
                        dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.TipoIntervalo_NombreCol].ToString()[0], 
                        (DateTime)campos[FacturasClienteService.Fecha_NombreCol], sesion);
                    PlanesFacturacionEtapasService.ActualizarUltimaFCCreada((decimal)dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.Id_NombreCol], 
                        casoFacturaId, 
                        (DateTime.Parse(campos[FacturasClienteService.Fecha_NombreCol].ToString())), 
                        sesion);

                    //Se agregan los detalles segun los articulos en las etapas seleccionadas
                    for (int k = 0; k < dtPlanesFacturacionEtapasDet.Rows.Count; k++)
                    {
                        clausulas = ArticulosLotesService.Articulo_ID_NombreCol + " = " + dtPlanesFacturacionEtapasDet.Rows[k][PlanesFacturacionEtapasDetallesService.ArticuloId_NombreCol] + " and " +
                                    "(" + ArticulosLotesService.Deposito_Id_NombreCol + " is null or " + ArticulosLotesService.Deposito_Id_NombreCol + " = " + dtPlanesFacturacion.Rows[0][PlanesFacturacionService.DepositoId_NombreCol] + ") and " +
                                    ArticulosLotesService.Total_NombreCol + " > 0 ";
                        dtLote = new ArticulosLotesService().GetArticulosLotesInfoCompleta(clausulas, ArticulosLotesService.FECHA_VENCIMIENTO_NombreCol);
                        if (dtLote.Rows.Count <= 0)
                            throw new Exception("No existe un lote para el artículo " + dtPlanesFacturacionEtapasDet.Rows[k][PlanesFacturacionEtapasDetallesService.VistaArticuloCodigoEmpresa_NombreCol] + ".");

                        #region Crear detalles
                        Hashtable camposDetalle = new Hashtable();
                        camposDetalle.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol]);
                        camposDetalle.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, dtPlanesFacturacionEtapasDet.Rows[k][PlanesFacturacionEtapasDetallesService.ArticuloId_NombreCol]);

                        //Verificar si el detalle incluye un activo
                        if (!dtPlanesFacturacionEtapasDet.Rows[k].IsNull(PlanesFacturacionEtapasDetallesService.ActivoId_NombreCol))
                            camposDetalle.Add(FacturasClienteDetalleService.ActivoId_NombreCol, dtPlanesFacturacionEtapasDet.Rows[k][PlanesFacturacionEtapasDetallesService.ActivoId_NombreCol]);

                        camposDetalle.Add(FacturasClienteDetalleService.LoteId_NombreCol, dtLote.Rows[0][ArticulosLotesService.Id_NombreCol]);
                        camposDetalle.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, dtPlanesFacturacionEtapasDet.Rows[k][PlanesFacturacionEtapasDetallesService.UnidadMedidaId_NombreCol]);
                        camposDetalle.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, dtPlanesFacturacionEtapasDet.Rows[k][PlanesFacturacionEtapasDetallesService.CantidadEmbalada_NombreCol]);
                        camposDetalle.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, dtPlanesFacturacionEtapasDet.Rows[k][PlanesFacturacionEtapasDetallesService.CantidadUnitaria_NombreCol]);
                        camposDetalle.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, dtPlanesFacturacionEtapasDet.Rows[k][PlanesFacturacionEtapasDetallesService.VistaImpuestoId_NombreCol]);

                        #region Obtener precio bruto unitario
                        if ((string)dtPlanesFacturacionEtapasDet.Rows[k][PlanesFacturacionEtapasDetallesService.CalcularMonto_NombreCol] == Definiciones.SiNo.No)
                        {
                            precioBrutoUnitario = (decimal)dtPlanesFacturacionEtapasDet.Rows[k][PlanesFacturacionEtapasDetallesService.MontoBruto_NombreCol];
                        }
                        else
                        {
                            porcentajeDescuento = 0;

                            if (ArticulosService.GetControlarPrecio((decimal)dtPlanesFacturacionEtapasDet.Rows[k][PlanesFacturacionEtapasDetallesService.ArticuloId_NombreCol]))
                            {
                                precioConvertidoPorUnidad = PreciosService.GetPrecioPorArticulo(
                                                                      (decimal)dtPlanesFacturacion.Rows[0][PlanesFacturacionService.PersonaId_NombreCol],
                                                                      (decimal)dtPlanesFacturacionEtapasDet.Rows[k][PlanesFacturacionEtapasDetallesService.ArticuloId_NombreCol],
                                                                      (decimal)dtPlanesFacturacion.Rows[0][PlanesFacturacionService.MonedaId_NombreCol],
                                                                      (decimal)dtPlanesFacturacion.Rows[0][PlanesFacturacionService.SucursalId_NombreCol],
                                                                      (decimal)dtPlanesFacturacion.Rows[0][PlanesFacturacionService.CasoId_NombreCol],
                                                                       Definiciones.Error.Valor.EnteroPositivo,
                                                                      (decimal)dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.ListaPrecioId_NombreCol],
                                                                      (decimal)dtPlanesFacturacionEtapas.Rows[0][PlanesFacturacionEtapasService.CondicionPagoId_NombreCol],
                                                                      ref porcentajeDescuento,
                                                                      out monedaOrigen,
                                                                      out cotizacionOrigen,
                                                                      out fechaPrimerVencimiento,
                                                                      out usarFechaPrimerVencimiento,
                                                                      out fechaSegundoVencimiento,
                                                                      out usarFechaSegundoVencimiento, false, Definiciones.Error.Valor.EnteroPositivo);
                            }
                            else
                            {
                                precioConvertidoPorUnidad = 0;
                                monedaOrigen = (decimal)dtPlanesFacturacion.Rows[0][PlanesFacturacionService.MonedaId_NombreCol];
                                cotizacionOrigen = CotizacionesService.GetCotizacionMonedaCompra((decimal)dtPlanesFacturacion.Rows[0][PlanesFacturacionService.SucursalId_NombreCol], monedaOrigen, (DateTime)campos[FacturasClienteService.Fecha_NombreCol], sesion);
                            }

                            factorConversion = (new ArticulosConversionesService()).GetFactorConversion((decimal)dtPlanesFacturacionEtapasDet.Rows[k][PlanesFacturacionEtapasDetallesService.ArticuloId_NombreCol], (string)dtPlanesFacturacionEtapasDet.Rows[k][PlanesFacturacionEtapasDetallesService.UnidadMedidaId_NombreCol], (decimal)dtPlanesFacturacion.Rows[0][PlanesFacturacionService.SucursalId_NombreCol]);
                            precioConvertidoPorUnidad /= factorConversion;

                            if (monedaOrigen == (decimal)dtPlanesFacturacion.Rows[0][PlanesFacturacionService.MonedaId_NombreCol])
                                precioBrutoUnitario = precioConvertidoPorUnidad;
                            else
                                precioBrutoUnitario = precioConvertidoPorUnidad / cotizacionOrigen * cotizacionDestino;
                        }
                        camposDetalle.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, precioBrutoUnitario);
                        #endregion Obtener precio bruto unitario

                        camposDetalle.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, porcentajeDescuento);
                        camposDetalle.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, precioBrutoUnitario * porcentajeDescuento / 100);
                        camposDetalle.Add(FacturasClienteDetalleService.Observacion_NombreCol, string.Empty);

                        FacturasClienteDetalleService.Guardar((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], camposDetalle, true, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, sesion);
                        #endregion Crear detalles
                    }
                    sesion.Db.CommitTransaction();
                    return Definiciones.WebserviceRetorno.Exito;
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }
        #endregion GenerarFacturas

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref String estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                PLANES_FACTURACIONRow row = new PLANES_FACTURACIONRow();

                try
                {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[PlanesFacturacionService.SucursalId_NombreCol].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.PLANES_FACTURACION.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("planes_facturacion_sqc");
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;

                        row.SUCURSAL_ID = (decimal)campos[PlanesFacturacionService.SucursalId_NombreCol];
                        if (campos.Contains(PlanesFacturacionService.CasoOrigenId_NombreCol))
                            row.CASO_ORIGEN_ID = (decimal)campos[PlanesFacturacionService.CasoOrigenId_NombreCol];
                    }
                    else
                    {
                        row = sesion.Db.PLANES_FACTURACIONCollection.GetRow(PlanesFacturacionService.Id_NombreCol + " = " + campos[PlanesFacturacionService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.FECHA = (DateTime)campos[PlanesFacturacionService.Fecha_NombreCol];

                    if (campos.Contains(PlanesFacturacionService.AutonumeracionId_NombreCol))
                        row.AUTONUMERACION_ID = (decimal)campos[PlanesFacturacionService.AutonumeracionId_NombreCol];
                    else
                        row.IsAUTONUMERACION_IDNull = true;
                    row.FUNCIONARIO_ID = (decimal)campos[PlanesFacturacionService.FuncionarioId_NombreCol];
                    row.OBSERVACION = (string)campos[PlanesFacturacionService.Observacion_NombreCol];

                    if (row.DEPOSITO_ID.Equals(DBNull.Value) || !row.DEPOSITO_ID.Equals(campos.Contains(PlanesFacturacionService.DepositoId_NombreCol)))
                    {
                        row.DEPOSITO_ID = (decimal)campos[PlanesFacturacionService.DepositoId_NombreCol];
                        if (StockDepositosService.GetStockDeposito(row.DEPOSITO_ID).PARA_FACTURAR == Definiciones.SiNo.No)
                        {
                            throw new Exception("No se pude facturar del deposito seleccionado");
                        }
                    }

                    if (row.PERSONA_ID.Equals(DBNull.Value) || !row.PERSONA_ID.Equals(campos.Contains(PlanesFacturacionService.PersonaId_NombreCol)))
                    {
                        row.PERSONA_ID = (decimal)campos[PlanesFacturacionService.PersonaId_NombreCol];
                        if (!PersonasService.EsCliente((decimal)campos[PlanesFacturacionService.PersonaId_NombreCol]))
                        {
                            throw new Exception("La persona no es cliente.");
                        }
                    }

                    if (row.MONEDA_ID.Equals(DBNull.Value) || !row.MONEDA_ID.Equals(campos.Contains(PlanesFacturacionService.MonedaId_NombreCol)))
                    {
                        row.MONEDA_ID = (decimal)campos[PlanesFacturacionService.MonedaId_NombreCol];
                        if (!MonedasService.EstaActivo((decimal)campos[PlanesFacturacionService.MonedaId_NombreCol]))
                        {
                            throw new Exception("La moneda no está activa.");
                        }
                    }

                    if (insertarNuevo) sesion.Db.PLANES_FACTURACIONCollection.Insert(row);
                    else sesion.Db.PLANES_FACTURACIONCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                    camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                    camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.FUNCIONARIO_ID);
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
                    string mensaje = "Error.";

                    //Se obtienen el caso y la factura a ser borrados
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    PLANES_FACTURACIONRow row = sesion.Db.PLANES_FACTURACIONCollection.GetByCASO_ID(caso_id)[0];

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.PLANES_FACTURACIONCollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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
            get { return "PLANES_FACTURACION"; }
        }
        public static string Nombre_Vista
        {
            get { return "PLANES_FACTURACION_INFO_COMP"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return PLANES_FACTURACIONCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return PLANES_FACTURACIONCollection.CASO_IDColumnName; }
        }
        public static string CasoOrigenId_NombreCol
        {
            get { return PLANES_FACTURACIONCollection.CASO_ORIGEN_IDColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return PLANES_FACTURACIONCollection.DEPOSITO_IDColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return PLANES_FACTURACIONCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return PLANES_FACTURACIONCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PLANES_FACTURACIONCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return PLANES_FACTURACIONCollection.MONEDA_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return PLANES_FACTURACIONCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return PLANES_FACTURACIONCollection.OBSERVACIONColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return PLANES_FACTURACIONCollection.PERSONA_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return PLANES_FACTURACIONCollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return PLANES_FACTURACION_INFO_COMPCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaDepositoAbreviatura_NombreCol
        {
            get { return PLANES_FACTURACION_INFO_COMPCollection.DEPOSITO_ABREVIATURAColumnName; }
        }
        public static string VistaDepositoNombre_NombreCol
        {
            get { return PLANES_FACTURACION_INFO_COMPCollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaFuncionarioNombreCompleto_NombreCol
        {
            get { return PLANES_FACTURACION_INFO_COMPCollection.FUNCIONARIO_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return PLANES_FACTURACION_INFO_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return PLANES_FACTURACION_INFO_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaPersonaNombreCompleto_NombreCol
        {
            get { return PLANES_FACTURACION_INFO_COMPCollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return PLANES_FACTURACION_INFO_COMPCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return PLANES_FACTURACION_INFO_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
