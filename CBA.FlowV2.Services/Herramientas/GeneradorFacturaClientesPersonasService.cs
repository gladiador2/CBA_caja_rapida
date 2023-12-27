#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using System.Collections;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Casos;
using System.Windows.Forms;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.ToolbarFlujo;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class GeneradorFacturaClientesPersonasService
    {
        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal valor = Guardar(campos, insertarNuevo, sesion);
                    sesion.CommitTransaction();
                    return valor;
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw (exp);
                }
            }
        }

        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                bool vCampoVendedorObligatorio = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FacturaClienteVendedorObligatorio).Equals(Definiciones.SiNo.Si);
                GEN_FC_CLIENTES_PERSONASRow generadorPersonas = new GEN_FC_CLIENTES_PERSONASRow();
                String valorAnterior = "";
                decimal dAux;

                if (!campos.Contains(GeneradorFacturaClientesPersonasService.CondicionId_NombreCol))
                    throw new Exception("Debe indicar la condición de pago.");
                if (vCampoVendedorObligatorio && !campos.Contains(GeneradorFacturaClientesPersonasService.FuncionarioVendedorId_NombreCol))
                    throw new Exception("Debe indicar el vendedor.");
                if (!campos.Contains(GeneradorFacturaClientesPersonasService.Fecha_NombreCol))
                    throw new Exception("Debe indicar la fecha.");

                if (insertarNuevo)
                {
                    if (!campos.Contains(GeneradorFacturaClientesPersonasService.PersonaId_NombreCol))
                        throw new Exception("Debe indicar la persona.");
                    if (!campos.Contains(GeneradorFacturaClientesPersonasService.GeneracionId_NombreCol))
                        throw new Exception("Debe indicar la generación asociada.");

                    generadorPersonas.ID = sesion.Db.GetSiguienteSecuencia("GEN_FC_CLIENTES_PERSONAS_SQC");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    generadorPersonas.IsCASO_FACTURA_GENERADA_IDNull = true;
                    generadorPersonas.FACTURA_GENERADA = Definiciones.SiNo.No;
                }
                else
                {
                    if (!campos.Contains(GeneradorFacturaClientesPersonasService.Id_NombreCol))
                        throw new Exception("Debe Incuir el Id");
                    dAux = decimal.Parse(campos[GeneradorFacturaClientesPersonasService.Id_NombreCol].ToString());
                    generadorPersonas = sesion.Db.GEN_FC_CLIENTES_PERSONASCollection.GetByPrimaryKey(dAux);
                    valorAnterior = generadorPersonas.ToString();
                }

                if (campos.Contains(GeneradorFacturaClientesPersonasService.PersonaId_NombreCol))
                    generadorPersonas.PERSONA_ID = decimal.Parse(campos[GeneradorFacturaClientesPersonasService.PersonaId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesPersonasService.GeneracionId_NombreCol))
                    generadorPersonas.GENERACION_FC_CLIENTE_ID = decimal.Parse(campos[GeneradorFacturaClientesPersonasService.GeneracionId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesPersonasService.CondicionId_NombreCol))
                    generadorPersonas.CONDICION_ID = decimal.Parse(campos[GeneradorFacturaClientesPersonasService.CondicionId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesPersonasService.FuncionarioVendedorId_NombreCol))
                {
                    if (decimal.Parse(campos[GeneradorFacturaClientesPersonasService.FuncionarioVendedorId_NombreCol].ToString()) != Definiciones.Error.Valor.EnteroPositivo)
                        generadorPersonas.FUNCIONARIO_VENDEDOR_ID = decimal.Parse(campos[GeneradorFacturaClientesPersonasService.FuncionarioVendedorId_NombreCol].ToString());
                }
                if (campos.Contains(GeneradorFacturaClientesPersonasService.Fecha_NombreCol))
                    generadorPersonas.FECHA = DateTime.Parse(campos[GeneradorFacturaClientesPersonasService.Fecha_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesPersonasService.MonedaId_NombreCol))
                    generadorPersonas.MONEDA_ID = decimal.Parse(campos[GeneradorFacturaClientesPersonasService.MonedaId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesPersonasService.NroComprobante_NombreCol))
                    generadorPersonas.NRO_COMPROBANTE = campos[GeneradorFacturaClientesPersonasService.NroComprobante_NombreCol].ToString();
                if (campos.Contains(GeneradorFacturaClientesPersonasService.AutonumeracionId_NombreCol))
                    generadorPersonas.AUTONUMERACION_ID = decimal.Parse(campos[GeneradorFacturaClientesPersonasService.AutonumeracionId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesPersonasService.Anulada_NombreCol))
                    generadorPersonas.ANULADA = campos[GeneradorFacturaClientesPersonasService.Anulada_NombreCol].ToString();
                else
                    generadorPersonas.ANULADA = Definiciones.SiNo.No;
                if (campos.Contains(GeneradorFacturaClientesPersonasService.Pagada_NombreCol))
                    generadorPersonas.PAGADA = campos[GeneradorFacturaClientesPersonasService.Pagada_NombreCol].ToString();
                else
                    generadorPersonas.PAGADA = Definiciones.SiNo.No;
                if (campos.Contains(GeneradorFacturaClientesPersonasService.AfectaCtaCte_NombreCol))
                    generadorPersonas.AFECTA_CTACTE = campos[GeneradorFacturaClientesPersonasService.AfectaCtaCte_NombreCol].ToString();
                else
                    generadorPersonas.AFECTA_CTACTE = Definiciones.SiNo.Si;
                if (campos.Contains(GeneradorFacturaClientesPersonasService.AfectaStock_NombreCol))
                    generadorPersonas.AFECTA_STOCK = campos[GeneradorFacturaClientesPersonasService.AfectaStock_NombreCol].ToString();
                else
                    generadorPersonas.AFECTA_STOCK = Definiciones.SiNo.Si;

                if (insertarNuevo)
                    sesion.db.GEN_FC_CLIENTES_PERSONASCollection.Insert(generadorPersonas);
                else
                    sesion.db.GEN_FC_CLIENTES_PERSONASCollection.Update(generadorPersonas);

                LogCambiosService.LogDeRegistro(GeneradorFacturaClientesPersonasService.Nombre_Tabla, generadorPersonas.ID, valorAnterior, generadorPersonas.ToString(), sesion);
                return generadorPersonas.ID;
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }

        public static decimal Insertar(System.Collections.Hashtable campos, decimal[] idGenerarArticulos, decimal[] precios, decimal[] cantidades, string[] observaciones, decimal[] impuestosId, decimal[] porcentajeDto)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal valor = Insertar(campos, idGenerarArticulos, precios, cantidades, observaciones, impuestosId, porcentajeDto, sesion);
                    sesion.CommitTransaction();
                    return valor;
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw (exp);
                }
            }
        }

        public static decimal Insertar(System.Collections.Hashtable campos, decimal[] idGenerarArticulos, decimal[] precios, decimal[] cantidades, string[] observaciones, decimal[] impuestosId, decimal[] porcentajeDto, SessionService sesion)
        {
            try
            {
                decimal valor = Guardar(campos, true, sesion);
                #region Insertar Articulos
                if (idGenerarArticulos.Length != precios.Length || idGenerarArticulos.Length != cantidades.Length)
                    throw new Exception("Error en Datos de los Articulos");
                System.Collections.Hashtable detalles = new System.Collections.Hashtable();
                for (int i = 0; i < idGenerarArticulos.Length; i++)
                {
                    detalles = null;
                    detalles = new System.Collections.Hashtable();
                    detalles.Add(GeneradorFacturaClientesArticulosPersonasService.GeneradorArticuloId_NombreCol, idGenerarArticulos[i]);
                    detalles.Add(GeneradorFacturaClientesArticulosPersonasService.GeneradorPersonaId_NombreCol, valor);
                    detalles.Add(GeneradorFacturaClientesArticulosPersonasService.PrecioUnitario_NombreCol, precios[i]);
                    detalles.Add(GeneradorFacturaClientesArticulosPersonasService.Cantidad_NombreCol, cantidades[i]);
                    detalles.Add(GeneradorFacturaClientesArticulosPersonasService.Observacion_NombreCol, observaciones[i]);
                    detalles.Add(GeneradorFacturaClientesArticulosPersonasService.ImpuestoId_NombreCol, impuestosId[i]);
                    detalles.Add(GeneradorFacturaClientesArticulosPersonasService.PorcentajeDto_NombreCol, porcentajeDto[i]);

                    GeneradorFacturaClientesArticulosPersonasService.Guardar(detalles, true, sesion);
                }

                #endregion Insertar Articulos
                return valor;
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }

        public static decimal Modificar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                GEN_FC_CLIENTES_PERSONASRow generadorPersonas = new GEN_FC_CLIENTES_PERSONASRow();
                String valorAnterior = "";
                decimal dAux;

                if (!campos.Contains(GeneradorFacturaClientesPersonasService.Id_NombreCol))
                    throw new Exception("Debe Incuir el Id");

                dAux = decimal.Parse(campos[GeneradorFacturaClientesPersonasService.Id_NombreCol].ToString());
                generadorPersonas = sesion.Db.GEN_FC_CLIENTES_PERSONASCollection.GetByPrimaryKey(dAux);
                valorAnterior = generadorPersonas.ToString();

                if (campos.Contains(GeneradorFacturaClientesPersonasService.CondicionId_NombreCol))
                    generadorPersonas.CONDICION_ID = decimal.Parse(campos[GeneradorFacturaClientesPersonasService.CondicionId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesPersonasService.FuncionarioVendedorId_NombreCol))
                    generadorPersonas.FUNCIONARIO_VENDEDOR_ID = decimal.Parse(campos[GeneradorFacturaClientesPersonasService.FuncionarioVendedorId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesPersonasService.Fecha_NombreCol))
                    generadorPersonas.FECHA = DateTime.Parse(campos[GeneradorFacturaClientesPersonasService.Fecha_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesPersonasService.MonedaId_NombreCol))
                    generadorPersonas.MONEDA_ID = decimal.Parse(campos[GeneradorFacturaClientesPersonasService.MonedaId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesPersonasService.NroComprobante_NombreCol))
                    generadorPersonas.NRO_COMPROBANTE = campos[GeneradorFacturaClientesPersonasService.NroComprobante_NombreCol].ToString();
                if (campos.Contains(GeneradorFacturaClientesPersonasService.AutonumeracionId_NombreCol))
                    generadorPersonas.AUTONUMERACION_ID = decimal.Parse(campos[GeneradorFacturaClientesPersonasService.AutonumeracionId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesPersonasService.Anulada_NombreCol))
                    generadorPersonas.ANULADA = campos[GeneradorFacturaClientesPersonasService.Anulada_NombreCol].ToString();

                sesion.db.GEN_FC_CLIENTES_PERSONASCollection.Update(generadorPersonas);

                LogCambiosService.LogDeRegistro(GeneradorFacturaClientesPersonasService.Nombre_Tabla, generadorPersonas.ID, valorAnterior, generadorPersonas.ToString(), sesion);
                return generadorPersonas.ID;
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }

        public static decimal Borrar(decimal generacion_persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal valor = Borrar(generacion_persona_id, sesion);
                    sesion.CommitTransaction();
                    return valor;
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw (exp);
                }
            }
        }

        public static decimal Borrar(decimal generacion_persona_id, SessionService sesion)
        {
            try
            {
                GEN_FC_CLIENTES_PERSONASRow generadorPersonas = new GEN_FC_CLIENTES_PERSONASRow();
                String valorAnterior = generadorPersonas.ToString();

                generadorPersonas = sesion.Db.GEN_FC_CLIENTES_PERSONASCollection.GetByPrimaryKey(generacion_persona_id);
                valorAnterior = generadorPersonas.ToString();

                //se borran los detalles
                GeneradorFacturaClientesArticulosPersonasService.BorrarPorGeneradorPersonaID(generadorPersonas.ID);

                sesion.db.GEN_FC_CLIENTES_PERSONASCollection.Delete(generadorPersonas);
                LogCambiosService.LogDeRegistro(GeneradorFacturaClientesArticulosService.Nombre_Tabla, generadorPersonas.ID, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
                return generadorPersonas.ID;
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }

        public static string CrearFactura(Hashtable hashDatos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    // Obtenemos los datos de la persona
                    string mensajeFinal = string.Empty;
                    int generacion_persona_id = (int)hashDatos["generacion_persona_id"];
                    GEN_FC_CLIENTES_PERSONASRow generadorPersonas = new GEN_FC_CLIENTES_PERSONASRow();
                    generadorPersonas = sesion.db.GEN_FC_CLIENTES_PERSONASCollection.GetByPrimaryKey(generacion_persona_id);
                    DataTable dtPersona = PersonasService.GetPersonasDataTable2(PersonasService.Id_NombreCol + " = " + generadorPersonas.PERSONA_ID, string.Empty, false, sesion);
                    string personaNombre = dtPersona.Rows[0][PersonasService.NombreCompleto_NombreCol].ToString();
                    String valorAnterior = "";

                    string where = GeneradorFacturaClientesService.Id_NombreCol + " = " + generadorPersonas.GENERACION_FC_CLIENTE_ID;

                    DataTable dtGeneracion = GeneradorFacturaClientesService.GetGeneradorFacturasDataTable(where, string.Empty, sesion);
                    if (dtGeneracion.Rows.Count != 1)
                        throw new Exception("Error al obtener datos de la generación.");

                    Hashtable campos = new Hashtable();
                    //caso_id y estado de factura creada
                    decimal caso_id = Definiciones.Error.Valor.EnteroPositivo;
                    string caso_estado = string.Empty;

                    decimal sucursal_id = decimal.Parse(dtGeneracion.Rows[0][GeneradorFacturaClientesService.SucursalId_NombreCol].ToString());
                    decimal deposito_id = decimal.Parse(dtGeneracion.Rows[0][GeneradorFacturaClientesService.DepositoId_NombreCol].ToString());
                    decimal talonarioId = (decimal)hashDatos["talonario_id"];
                    decimal monedaId = (decimal)hashDatos["monedaId"];
                    string nro_comprobante = hashDatos["nro_comprobante"].ToString();
                    string anulada = hashDatos["anulada"].ToString();
                    string pagada = hashDatos["pagada"].ToString();
                    string afecta_ctacte = hashDatos["afecta_ctacte"].ToString();
                    string afecta_stock = hashDatos["afecta_stock"].ToString();
                    decimal caja_sucursal = (decimal)hashDatos["cajaSucursalId"];
                    bool esManual = AutonumeracionesService.EsGeneracionManual(talonarioId, sesion);

                    if (esManual && nro_comprobante.Equals(string.Empty))
                        throw new Exception("Debe ingresar el nro. de la factura.");

                    // Cargamos los datos de la cabecera de la factura
                    campos.Add(FacturasClienteService.SucursalId_NombreCol, sucursal_id);
                    campos.Add(FacturasClienteService.DepositoId_NombreCol, deposito_id);
                    campos.Add(FacturasClienteService.Fecha_NombreCol, generadorPersonas.FECHA);
                    campos.Add(FacturasClienteService.PersonaId_NombreCol, generadorPersonas.PERSONA_ID);
                    campos.Add(FacturasClienteService.FechaVencimiento_NombreCol, generadorPersonas.FECHA);
                    campos.Add(FacturasClienteService.AutonumeracionId_NombreCol, talonarioId);
                    campos.Add(FacturasClienteService.TotalEntregaInicial_NombreCol, decimal.Parse("0"));
                    campos.Add(FacturasClienteService.CondicionPagoId_NombreCol, generadorPersonas.CONDICION_ID);
                    campos.Add(FacturasClienteService.MonedaDestinoId_NombreCol, monedaId);
                    if (!generadorPersonas.IsFUNCIONARIO_VENDEDOR_IDNull)
                        campos.Add(FacturasClienteService.VendedorId_NombreCol, generadorPersonas.FUNCIONARIO_VENDEDOR_ID);
                    if (!dtGeneracion.Rows[0][GeneradorFacturaClientesService.ListaPrecioId_NombreCol].Equals(DBNull.Value))
                        campos.Add(FacturasClienteService.ListaPrecioId_NombreCol, decimal.Parse(dtGeneracion.Rows[0][GeneradorFacturaClientesService.ListaPrecioId_NombreCol].ToString()));
                    campos.Add(FacturasClienteService.ComisionPorVenta_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
                    campos.Add(FacturasClienteService.AfectaLineaCredito_NombreCol, VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCClienteAfectarLineaCredito));
                    campos.Add(FacturasClienteService.Observacion_NombreCol, string.Empty);
                    campos.Add(FacturasClienteService.PorcentajeDescSobreTotal_NombreCol, decimal.Parse("0"));
                    campos.Add(FacturasClienteService.AConsignacion_NombreCol, Definiciones.SiNo.No);
                    campos.Add(FacturasClienteService.AfectaStock_NombreCol, afecta_stock);
                    campos.Add(FacturasClienteService.AfectaCtacte_NombreCol, afecta_ctacte);
                    campos.Add(FacturasClienteService.CtaCteCajaSucursalId_NombreCol, caja_sucursal);
                    campos.Add(FacturasClienteService.SucursalVentaId_NombreCol, sucursal_id);
                    if (esManual)
                        campos.Add(FacturasClienteService.NroComprobante_NombreCol, nro_comprobante);

                    decimal cotizacion = CotizacionesService.GetCotizacionMonedaVenta(decimal.Parse(dtGeneracion.Rows[0][GeneradorFacturaClientesService.MonedaId_NombreCol].ToString()), generadorPersonas.FECHA);
                    campos.Add(FacturasClienteService.CotizacionDestino_NombreCol, cotizacion);
                    bool exitoCabecera = FacturasClienteService.Guardar(campos, true, ref caso_id, ref caso_estado, sesion);

                    if (!exitoCabecera)
                        return "No se pudo crear la factura para " + personaNombre + ".";

                    //Se crean los detalles de la factura
                    DataTable dtDetallesPorPersona = new DataTable();
                    where = GeneradorFacturaClientesArticulosPersonasService.GeneradorPersonaId_NombreCol + " = " + generacion_persona_id;
                    where += " and " + GeneradorFacturaClientesArticulosPersonasService.Incluir_NombreCol + " = '" + Definiciones.SiNo.Si + "'";
                    dtDetallesPorPersona = GeneradorFacturaClientesArticulosPersonasService.GetGeneradorFacturasClientesArticulosDataTableInfoCompleta(where, GeneradorFacturaClientesArticulosPersonasService.Id_NombreCol, sesion);
                    string verificarExistencia = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.VerificarExistenciaStockFacturaCliente, sesion);
                    decimal factura_id = (decimal)FacturasClienteService.GetFacturaClienteDataTable(FacturasClienteService.CasoId_NombreCol + " = " + caso_id, string.Empty, sesion).Rows[0][FacturasClienteService.Id_NombreCol];
                    DataTable dtLotes;
                    decimal cantidadDisponible;
                    decimal cantidadNecesaria;
                    decimal lote_id;

                    for (int i = 0; i < dtDetallesPorPersona.Rows.Count; i++)
                    {
                        campos = new Hashtable();
                        dtLotes = null;
                        decimal articulo_id = decimal.Parse(dtDetallesPorPersona.Rows[i][GeneradorFacturaClientesArticulosPersonasService.VistaArticuloId_NombreCol].ToString());
                        cantidadNecesaria = decimal.Parse(dtDetallesPorPersona.Rows[i][GeneradorFacturaClientesArticulosPersonasService.Cantidad_NombreCol].ToString());

                        if (!ArticulosService.EsServicio(articulo_id, sesion) && afecta_stock == Definiciones.SiNo.Si)
                            dtLotes = (new ArticulosLotesService()).GetArticulosLotesConStock(sucursal_id, deposito_id, articulo_id, verificarExistencia.Equals(Definiciones.SiNo.Si), sesion);
                        else
                            dtLotes = (new ArticulosLotesService()).GetArticulosLotesConStock(sucursal_id, deposito_id, articulo_id, false, sesion);

                        if (dtLotes.Rows.Count < 1)
                            throw new Exception("Error al obtener el lote del artículo: " + dtDetallesPorPersona.Rows[i][GeneradorFacturaClientesArticulosPersonasService.VistaArticuloDescripcion_NombreCol].ToString());

                        lote_id = Definiciones.Error.Valor.EnteroPositivo;

                        if (!ArticulosService.EsServicio(articulo_id, sesion) && afecta_stock == Definiciones.SiNo.Si && verificarExistencia == Definiciones.SiNo.Si)
                        {
                            for (int j = 0; j < dtLotes.Rows.Count; j++)
                            {
                                cantidadDisponible = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote(decimal.Parse(dtLotes.Rows[j][ArticulosLotesService.Id_NombreCol].ToString()), deposito_id, sesion);
                                if (cantidadDisponible >= cantidadNecesaria)
                                    lote_id = decimal.Parse(dtLotes.Rows[j][ArticulosLotesService.Id_NombreCol].ToString());
                            }
                        }
                        else
                        {
                            lote_id = decimal.Parse(dtLotes.Rows[0][ArticulosLotesService.Id_NombreCol].ToString());
                        }

                        if (lote_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("No existe la cantidad necesaria del artículo: " + dtDetallesPorPersona.Rows[i][GeneradorFacturaClientesArticulosPersonasService.VistaArticuloDescripcion_NombreCol].ToString() + " para generar la facturas");

                        campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, articulo_id);
                        campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, 0);
                        campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, decimal.Parse(dtDetallesPorPersona.Rows[i][GeneradorFacturaClientesArticulosPersonasService.Cantidad_NombreCol].ToString()));
                        campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, dtDetallesPorPersona.Rows[i][GeneradorFacturaClientesArticulosPersonasService.Observacion_NombreCol].ToString());
                        if (dtDetallesPorPersona.Rows[i][GeneradorFacturaClientesArticulosPersonasService.PorcentajeDto_NombreCol] != DBNull.Value)
                        {
                            campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, decimal.Parse(dtDetallesPorPersona.Rows[i][GeneradorFacturaClientesArticulosPersonasService.PorcentajeDto_NombreCol].ToString()));
                            campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)dtDetallesPorPersona.Rows[i][GeneradorFacturaClientesArticulosPersonasService.PrecioUnitario_NombreCol] * 
                                                                                    decimal.Parse(dtDetallesPorPersona.Rows[i][GeneradorFacturaClientesArticulosPersonasService.PorcentajeDto_NombreCol].ToString()) / 100);
                        }
                        else
                        {
                            campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, 0);
                            campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, 0);
                        }
                        if (dtDetallesPorPersona.Rows[i][GeneradorFacturaClientesArticulosPersonasService.PrecioUnitario_NombreCol] != DBNull.Value)
                            campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, decimal.Parse(dtDetallesPorPersona.Rows[i][GeneradorFacturaClientesArticulosPersonasService.PrecioUnitario_NombreCol].ToString()));
                        campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, factura_id);
                        campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, ArticulosService.GetUnidadBase(articulo_id));
                        campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, lote_id);
                        if (dtDetallesPorPersona.Rows[i][GeneradorFacturaClientesArticulosPersonasService.ImpuestoId_NombreCol] != DBNull.Value)
                            campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, decimal.Parse(dtDetallesPorPersona.Rows[i][GeneradorFacturaClientesArticulosPersonasService.ImpuestoId_NombreCol].ToString()));
                        else
                            campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, ArticulosService.GetImpuestoId(articulo_id).ToString());

                        DateTime fechaPrimerVencimiento = DateTime.Now, fechaSegundoVencimiento = DateTime.MinValue;
                        bool usarFechaPrimerVencimiento = false, usarFechaSegundoVencimiento = false;
                        FacturasClienteDetalleService.Guardar(factura_id, campos, false, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, sesion);
                    }

                    //Se actualizan los datos del detalle
                    generadorPersonas.FACTURA_GENERADA = Definiciones.SiNo.Si;
                    generadorPersonas.CASO_FACTURA_GENERADA_ID = caso_id;

                    sesion.db.GEN_FC_CLIENTES_PERSONASCollection.Update(generadorPersonas);
                    LogCambiosService.LogDeRegistro(GeneradorFacturaClientesPersonasService.Nombre_Tabla, generadorPersonas.ID, valorAnterior, generadorPersonas.ToString(), sesion);

                    // Los pasos de estado de la Factura se hacen en una transaccion separada
                    //De borrador a Pendiente
                    bool exito = false;
                    string mensaje = string.Empty;
                    FacturasClienteService.SetCajaSucursal(caso_id, caja_sucursal, sesion);

                    exito = (new FacturasClienteService()).ProcesarCambioEstado(caso_id, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(caso_id, Definiciones.EstadosFlujos.Pendiente, "Transición automática por el Generador de Facturas " + dtGeneracion.Rows[0][GeneradorFacturaClientesService.Nombre_NombreCol].ToString() + " al estado Pendiente.", sesion);
                    if (exito)
                        (new FacturasClienteService()).EjecutarAccionesLuegoDeCambioEstado(caso_id, Definiciones.EstadosFlujos.Pendiente, sesion);
                    if (!exito)
                        throw new Exception("Se creó la factura caso " + caso_id + ", pero al intentar pasarla a PENDIENTE surgió el problema: " + mensaje);

                    //De pendiente a caja
                    exito = (new FacturasClienteService()).ProcesarCambioEstado(caso_id, Definiciones.EstadosFlujos.Caja, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(caso_id, Definiciones.EstadosFlujos.Caja, "Transición automática por el Generador de Facturas " + dtGeneracion.Rows[0][GeneradorFacturaClientesService.Nombre_NombreCol].ToString() + " al estado Caja.", sesion);
                    if (exito)
                        (new FacturasClienteService()).EjecutarAccionesLuegoDeCambioEstado(caso_id, Definiciones.EstadosFlujos.Caja, sesion);
                    if (!exito)
                        throw new Exception("Se creó la factura, pero al intentar pasarla a CAJA surgió este problema: " + mensaje);

                    //De caja a anulado
                    if (anulada == Definiciones.SiNo.Si)
                    {
                        exito = (new FacturasClienteService()).ProcesarCambioEstado(caso_id, Definiciones.EstadosFlujos.Anulado, false, out mensaje, sesion);
                        if (exito)
                            exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(caso_id, Definiciones.EstadosFlujos.Anulado, "Transición automática por el Generador de Facturas " + dtGeneracion.Rows[0][GeneradorFacturaClientesService.Nombre_NombreCol].ToString() + " al estado Anulado.", sesion);
                        if (exito)
                            (new FacturasClienteService()).EjecutarAccionesLuegoDeCambioEstado(caso_id, Definiciones.EstadosFlujos.Anulado, sesion);
                        if (!exito)
                            throw new Exception("Se creó la factura, pero al intentar pasarla a ANULADO surgió este problema: " + mensaje);
                    }
                    //pagada == Definiciones.SiNo.Si
                    if (pagada == Definiciones.SiNo.Si && afecta_ctacte == Definiciones.SiNo.Si && CasosService.GetEstadoCaso(caso_id, sesion) != Definiciones.EstadosFlujos.Cerrado)
                    {
                        string clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + caso_id + " and " +
                                   CuentaCorrientePersonasService.CtactePersonaRelacionada_NombreCol + " is null ";
                        DataTable dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(clausulas, string.Empty, sesion);

                        decimal caso_pago = PagosDePersonaService.CrearCaso(sucursal_id,
                            generadorPersonas.PERSONA_ID,
                            generadorPersonas.FECHA,
                            monedaId,
                            CuentaCorrienteCajasSucursalService.GetFuncionarioCobradorId(caja_sucursal),
                            Definiciones.Error.Valor.EnteroPositivo,
                            Definiciones.Error.Valor.EnteroPositivo,
                            string.Empty,
                            Definiciones.Error.Valor.EnteroPositivo,
                            new decimal[] { (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Id_NombreCol] },
                            new decimal[] { (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol] },
                            Definiciones.CuentaCorrienteValores.Efectivo,
                            Definiciones.Error.Valor.EnteroPositivo,
                            string.Empty,
                            Definiciones.Error.Valor.EnteroPositivo,
                            true,
                            caso_id,
                            sesion);

                        exito = !caso_pago.Equals(Definiciones.Error.Valor.EnteroPositivo);

                        //Aprobar el pago
                        if (exito)
                        {
                            exito = (new PagosDePersonaService()).ProcesarCambioEstado(caso_pago, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                            if (exito)
                                exito = (new ToolbarFlujoService()).ProcesarCambioEstado(caso_pago, Definiciones.EstadosFlujos.Aprobado, "Transición automática por pago a través de Red de Pagos", sesion);
                            if (exito)
                                (new PagosDePersonaService()).EjecutarAccionesLuegoDeCambioEstado(caso_pago, Definiciones.EstadosFlujos.Aprobado, sesion);
                            if (!exito)
                                throw new Exception("Error en PagoDePersonas.CrearPorRedDePago. " + mensaje + ".");
                        }
                    }

                    sesion.CommitTransaction();

                    return mensajeFinal;
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Get

        public static DataTable GetGeneradorFacturasPersonasDataTable(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    return GetGeneradorFacturasPersonasDataTable(where, orderBy, sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }

        public static DataTable GetGeneradorFacturasPersonasDataTable(string where, string orderBy, SessionService sesion)
        {
            return sesion.db.GEN_FC_CLIENTES_PERSONASCollection.GetAsDataTable(where, orderBy);
        }

        public static DataTable GetGeneradorFacturasPersonasDataTableInfoCompleta(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    return GetGeneradorFacturasPersonasDataTableInfoCompleta(where, orderBy, sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }

        public static DataTable GetGeneradorFacturasPersonasDataTableInfoCompleta(string where, string orderBy, SessionService sesion)
        {
            return sesion.db.GEN_FC_CLIE_PERS_INFO_COMPLCollection.GetAsDataTable(where, orderBy);
        }
        #endregion Get

        #region Accesors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "GEN_FC_CLIENTES_PERSONAS"; }
        }
        public static string AfectaCtaCte_NombreCol
        {
            get { return GEN_FC_CLIENTES_PERSONASCollection.AFECTA_CTACTEColumnName; }
        }
        public static string AfectaStock_NombreCol
        {
            get { return GEN_FC_CLIENTES_PERSONASCollection.AFECTA_STOCKColumnName; }
        }
        public static string Anulada_NombreCol
        {
            get { return GEN_FC_CLIENTES_PERSONASCollection.ANULADAColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return GEN_FC_CLIENTES_PERSONASCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoFacturaGeneradaId_NombreCol
        {
            get { return GEN_FC_CLIENTES_PERSONASCollection.CASO_FACTURA_GENERADA_IDColumnName; }
        }
        public static string CondicionId_NombreCol
        {
            get { return GEN_FC_CLIENTES_PERSONASCollection.CONDICION_IDColumnName; }
        }
        public static string FacturaGenerada_NombreCol
        {
            get { return GEN_FC_CLIENTES_PERSONASCollection.FACTURA_GENERADAColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return GEN_FC_CLIENTES_PERSONASCollection.FECHAColumnName; }
        }
        public static string FuncionarioVendedorId_NombreCol
        {
            get { return GEN_FC_CLIENTES_PERSONASCollection.FUNCIONARIO_VENDEDOR_IDColumnName; }
        }
        public static string GeneracionId_NombreCol
        {
            get { return GEN_FC_CLIENTES_PERSONASCollection.GENERACION_FC_CLIENTE_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return GEN_FC_CLIENTES_PERSONASCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return GEN_FC_CLIENTES_PERSONASCollection.MONEDA_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return GEN_FC_CLIENTES_PERSONASCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Pagada_NombreCol
        {
            get { return GEN_FC_CLIENTES_PERSONASCollection.PAGADAColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return GEN_FC_CLIENTES_PERSONASCollection.PERSONA_IDColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string Vista_Tabla
        {
            get { return "GEN_FC_CLIE_PERS_INFO_COMPL"; }
        }
        public static string VistaCasoEstado_NombreCol
        {
            get { return GEN_FC_CLIE_PERS_INFO_COMPLCollection.CASO_ESTADOColumnName; }
        }
        public static string VistaCondicionNombre_NombreCol
        {
            get { return GEN_FC_CLIE_PERS_INFO_COMPLCollection.CONDICION_NOMBREColumnName; }
        }
        public static string VistaFuncionarioCodigo_NombreCol
        {
            get { return GEN_FC_CLIE_PERS_INFO_COMPLCollection.FUNCIONARIO_CODIGOColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return GEN_FC_CLIE_PERS_INFO_COMPLCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaPersonaCodigo_NombreCol
        {
            get { return GEN_FC_CLIE_PERS_INFO_COMPLCollection.PERSONA_CODIGOColumnName; }
        }
        public static string VistaPersonaDocumento_NombreCol
        {
            get { return GEN_FC_CLIE_PERS_INFO_COMPLCollection.PERSONA_DOCUMENTOColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return GEN_FC_CLIE_PERS_INFO_COMPLCollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return GEN_FC_CLIE_PERS_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return GEN_FC_CLIE_PERS_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaMonedaCantidadesDecimales_NombreCol
        {
            get { return GEN_FC_CLIE_PERS_INFO_COMPLCollection.MONEDA_CANTIDADES_DECIMALESColumnName; }
        }
        public static string VistaMonedaCadenaDecimales_NombreCol
        {
            get { return GEN_FC_CLIE_PERS_INFO_COMPLCollection.MONEDA_CADENA_DECIMALESColumnName; }
        }
        public static string VistaAutonumeracionCodigo_NombreCol
        {
            get { return GEN_FC_CLIE_PERS_INFO_COMPLCollection.AUTONUMERACION_CODIGOColumnName; }
        }
        public static string VistaAutonumeracionTimbrado_NombreCol
        {
            get { return GEN_FC_CLIE_PERS_INFO_COMPLCollection.AUTONUMERACION_TIMBRADOColumnName; }
        }

        #endregion Vista
        #endregion Accesors
    }
}
