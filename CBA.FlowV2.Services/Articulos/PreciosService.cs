using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.ListaDePrecio;
using CBA.FlowV2.Services.Sesion;
using System.Globalization;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Casos;

namespace CBA.FlowV2.Services.Articulos
{
    public class PreciosService
    {
        #region Clase GetPrecioWebservice
        private static class GetPrecio
        {
           
        }
        #endregion Clase GetPrecioWebservice

        #region GetPrecioPorArticulo
        public static decimal GetPrecioPorArticulo(decimal persona_id, decimal articulo_id, decimal moneda_destino_id, decimal sucursal_id, decimal caso_id,
                                                   decimal cotizacion_destino, decimal lista_de_precios_id, decimal condicion_pago_id,
                                                   ref decimal descuento_porcentaje, out decimal out_moneda_origen_id, out decimal out_cotizacion_origen,
                                                   out DateTime fecha_primer_vencimiento, out bool usar_fecha_primer_vencimiento, out DateTime fecha_segundo_vencimiento,
                                                   out bool usar_fecha_segundo_vencimiento, bool controlar_cantidad_minima, decimal cantidad)
        {

            decimal listaPrecioDetId = Definiciones.Error.Valor.EnteroPositivo;
            fecha_primer_vencimiento = DateTime.Now;
            fecha_segundo_vencimiento = DateTime.Now;
            usar_fecha_primer_vencimiento = false;
            usar_fecha_segundo_vencimiento = false;

            DateTime fechaConsultaPrecio = DateTime.Now;

            decimal flujo = CasosService.GetFlujo(caso_id);

            if (flujo == Definiciones.FlujosIDs.FACTURACION_CLIENTE && RolesService.Tiene("OBTENER PRECIO SEGUN FECHA DE FACTURA"))
            {
                using (SessionService sesion = new SessionService())
                {
                    FACTURAS_CLIENTERow cabeceraRow = sesion.Db.FACTURAS_CLIENTECollection.GetByCASO_ID(caso_id)[0];
                    fechaConsultaPrecio = (DateTime)cabeceraRow.FECHA;
                }
            }
            
            return PreciosService_new.getPrecioArticuloDePersona(articulo_id,
                                persona_id,
                                sucursal_id,
                                moneda_destino_id,
                                cantidad,
                                out descuento_porcentaje,
                                out out_cotizacion_origen,
                                out out_moneda_origen_id,
                                ref listaPrecioDetId,
                                fechaConsultaPrecio);
            #region metodoAnterior
            /*using (SessionService sesion = new SessionService())
            {
                return GetPrecioPorArticulo(persona_id, articulo_id, moneda_destino_id, sucursal_id, caso_id, cotizacion_destino, lista_de_precios_id, 
                                            condicion_pago_id, ref descuento_porcentaje, out out_moneda_origen_id, out out_cotizacion_origen, 
                                            out fecha_primer_vencimiento, out usar_fecha_primer_vencimiento, out fecha_segundo_vencimiento, 
                                            out usar_fecha_segundo_vencimiento, false, controlar_cantidad_minima, cantidad, sesion);
            }*/
            #endregion metodoAnterior

        }

        /// <summary>
        /// Obtener el precio segun la estrategia de precios (por flujo o por modulo).
        /// </summary>
        /// <param name="articulo_id">Articulo consultado.</param>
        /// <param name="moneda_destino_id">Moneda en la que se requiere el precio.</param>
        /// <param name="sucursal_id">Sucursal utilizada para hallar el pais de la cotizacion.</param>
        /// <param name="cotizacion_destino">Cotizacion de la moneda destino, o Definiciones.Error.Valor.EnteroPositivo.</param>
        /// <param name="lista_de_precios_id">Lista de precios, si se utiliza la estrategia por flujo.</param>
        /// <param name="out_moneda_origen_id">Moneda origen en la cual esta guardado el precio.</param>
        /// <param name="out_cotizacion_origen">Cotizacion utilizada para la moneda origen.</param>
        /// <param name="articulo_no_perteneciente_a_lista_de_precios">if set to <c>true</c> [articulo_no_perteneciente_a_lista_de_precios].</param>
        /// <returns></returns>
        public static decimal GetPrecioPorArticulo(decimal persona_id, decimal articulo_id, decimal moneda_destino_id, decimal sucursal_id, decimal caso_id,
                                                   decimal cotizacion_destino, decimal lista_de_precios_id, decimal condicion_pago_id,
                                                   ref decimal descuento_porcentaje, out decimal out_moneda_origen_id, out decimal out_cotizacion_origen,
                                                   out DateTime fecha_primer_vencimiento, out bool usar_fecha_primer_vencimiento,
                                                   out DateTime fecha_segundo_vencimiento, out bool usar_fecha_segundo_vencimiento,
                                                   bool articulo_no_perteneciente_a_lista_de_precios, bool controlar_cantidad_minima, decimal cantidad,
                                                   SessionService sesion)
        {

            try
            {
                decimal listaPrecioDetId = Definiciones.Error.Valor.EnteroPositivo;
                fecha_primer_vencimiento = DateTime.Now;
                fecha_segundo_vencimiento = DateTime.Now;
                usar_fecha_primer_vencimiento = false;
                usar_fecha_segundo_vencimiento = false;

                DateTime fechaConsultaPrecio = DateTime.Now;

                decimal flujo = CasosService.GetFlujo(caso_id);

                if (flujo == Definiciones.FlujosIDs.FACTURACION_CLIENTE && RolesService.Tiene("OBTENER PRECIO SEGUN FECHA DE FACTURA"))
                {
                     FACTURAS_CLIENTERow cabeceraRow = sesion.Db.FACTURAS_CLIENTECollection.GetByCASO_ID(caso_id)[0];
                   fechaConsultaPrecio = (DateTime) cabeceraRow.FECHA;
                 }            

                return PreciosService_new.getPrecioArticuloDePersona(articulo_id,
                                    persona_id,
                                    sucursal_id,
                                    moneda_destino_id,
                                    cantidad,
                                    out descuento_porcentaje,
                                    out out_cotizacion_origen,
                                    out out_moneda_origen_id,
                                    ref listaPrecioDetId,
                                    fechaConsultaPrecio);
                #region metodoAnterior

                /*
            
                DataTable consultaDT;
                decimal precio;
                int estrategiaPrecio;
                fecha_primer_vencimiento = DateTime.Now;
                fecha_segundo_vencimiento = DateTime.MinValue;
                usar_fecha_primer_vencimiento = false;
                usar_fecha_segundo_vencimiento = false;

                DataTable dtArticulo = ArticulosService.GetArticulos(ArticulosService.Id_NombreCol + " = " + articulo_id, string.Empty, false, sucursal_id);
                if (!dtArticulo.Rows[0][ArticulosService.ControlarPrecio_NombreCol].Equals(Definiciones.SiNo.Si))
                    throw new Exception("PreciosService.GetPrecioPorArticulo(). Error, no debe pedirse o controlarse el precio del artículo.");

                estrategiaPrecio = int.Parse(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.EstrategiaPrecio).ToString());

                //Se obtienen los datos del precio segun la estrategia
                switch (estrategiaPrecio)
                {
                    case Definiciones.EstrategiaPrecio.FlujoModificacionListaPrecios:

                        if (articulo_no_perteneciente_a_lista_de_precios)
                        {
                            out_moneda_origen_id = moneda_destino_id;
                            out_cotizacion_origen = cotizacion_destino;
                            precio = 0;
                            descuento_porcentaje = 0;
                        }
                        else
                        {
                            //Si no se proveyo una lista de precios, tomar la primera con la moneda indicada
                            if (lista_de_precios_id == Definiciones.Error.Valor.EnteroPositivo)
                            {
                                var dtListasPrecio = ListasDePrecioService.GetListasDePrecioDataTable2(ListasDePrecioService.MonedaId_NombreCol + " = " + moneda_destino_id, ListasDePrecioService.Id_NombreCol);
                                if (dtListasPrecio.Rows.Count > 0)
                                    lista_de_precios_id = (decimal)dtListasPrecio.Rows[0][ListasDePrecioService.Id_NombreCol];
                                                    
                            }

                            string clausulasPrecio = ListasDePrecioDetalleService.ListaPrecioId_NombreCol + " = " + lista_de_precios_id + " and " +
                                                     ListasDePrecioDetalleService.ArticuloId_NombreCol + " = " + articulo_id;
                            DataTable dtPrecio = (new ListasDePrecioDetalleService()).GetListasDePrecioDetalleInfoCompleta(clausulasPrecio, string.Empty);
                            if (dtPrecio.Rows.Count <= 0)
                                throw new Exception("El artículo no forma parte de la lista de precios seleccionada.");

                            out_moneda_origen_id = (decimal)dtPrecio.Rows[0][ListasDePrecioDetalleService.VistaListaPrecioMonedaId_NombreCol];
                            precio = (decimal)dtPrecio.Rows[0][ListasDePrecioDetalleService.Precio_NombreCol];

                            decimal descuentoMaximo = descuento_porcentaje;
                            if (!CBA.FlowV2.Services.Common.Interprete.EsNullODBNull(dtPrecio.Rows[0][ListasDePrecioDetalleService.DescuentoMaximo_NombreCol]))
                                descuentoMaximo = (decimal)dtPrecio.Rows[0][ListasDePrecioDetalleService.DescuentoMaximo_NombreCol];

                            descuento_porcentaje = Math.Min(descuento_porcentaje, descuentoMaximo);
                            out_cotizacion_origen = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(sucursal_id), out_moneda_origen_id, DateTime.Now, sesion);

                            if (out_cotizacion_origen == Definiciones.Error.Valor.EnteroPositivo)
                                throw new Exception("Debe actualizarse la cotización de la moneda " + dtPrecio.Rows[0][ListasDePrecioDetalleService.VistaListaPrecioMonedaNombre_NombreCol] + ".");
                        }
                        break;

                    case Definiciones.EstrategiaPrecio.ModuloPrecios:

                        string where = Db.ARTICULOS_PRECIOSCollection.ARTICULO_IDColumnName + " = " + articulo_id +
                                      " and " + Db.ARTICULOS_PRECIOSCollection.SUCURSAL_IDColumnName + " = " + sucursal_id;
                        consultaDT = sesion.Db.ARTICULOS_PRECIOSCollection.GetAsDataTable(where, string.Empty);

                        if (!(consultaDT.Rows.Count > 0)) 
                            throw new System.ArgumentException("No existe un precio definido para el artículo.");

                        //Se obtiene la cotizacion destino
                        decimal cotizacion;

                        if (cotizacion_destino == Definiciones.Error.Valor.EnteroPositivo)
                        {
                            cotizacion = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(sucursal_id), moneda_destino_id, DateTime.Now, sesion);
                            if (cotizacion.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                throw new System.ArgumentException("La moneda no tiene una cotización actualizada.");
                        }
                        else
                        {
                            cotizacion = cotizacion_destino;
                        }


                        decimal factor;

                        //Se calcula el factor: cotizacion_destino / cotizacion_origen si las monedas origen y destino son distintas
                        if ((decimal)consultaDT.Rows[0][PreciosService.MONEDA_ID_NombreCol] == moneda_destino_id)
                            factor = 1;
                        else
                            factor = cotizacion / (decimal)consultaDT.Rows[0][PreciosService.COTIZACION_MONEDA_NombreCol];

                        //Se actualiza la moneda en que se expresa el precio,
                        //El precio es pasado a la moneda destino segun sea la cotizacion (factor de conversion)
                        //Se actualiza la cotizacion utilizada
                        out_moneda_origen_id = moneda_destino_id;
                        precio = (decimal)consultaDT.Rows[0][PreciosService.PRECIO_NombreCol] * factor;

                        if (controlar_cantidad_minima)
                        {
                            if (!Interprete.EsNullODBNull(consultaDT.Rows[0][PreciosService.CantidadMinima_NombreCol]) &&
                                cantidad < (decimal)consultaDT.Rows[0][PreciosService.CantidadMinima_NombreCol])
                            {
                                throw new System.ArgumentException("La cantidad debe ser mayor o igual a: " + (decimal)consultaDT.Rows[0][PreciosService.CantidadMinima_NombreCol]);
                            }
                        }

                        if (!Interprete.EsNullODBNull(consultaDT.Rows[0][PreciosService.DescuentoMaximo_NombreCol]) &&
                            descuento_porcentaje > (decimal)consultaDT.Rows[0][PreciosService.DescuentoMaximo_NombreCol])
                        {
                            throw new System.ArgumentException("El descuento no puede ser mayor a: " + (decimal)consultaDT.Rows[0][PreciosService.DescuentoMaximo_NombreCol]);
                        }

                        out_cotizacion_origen = cotizacion_destino;

                        break;

                    case Definiciones.EstrategiaPrecio.WebService:
                        int clienteId = Convert.ToInt32(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.Cliente));

                        switch (clienteId)
                        {
                            case Definiciones.Clientes.Electroban:
                                consultaDT = ArticulosService.GetArticulos(ArticulosService.Id_NombreCol + " = " + articulo_id, string.Empty, false, sucursal_id);
                                string articuloCodigo = (string)consultaDT.Rows[0][ArticulosService.CodigoEmpresa_NombreCol];

                                decimal[] articulosPrecios, articulosDescuentoPorcentaje;
                                articulosDescuentoPorcentaje = new decimal[] { descuento_porcentaje };

                                GetPrecio.Cliente_9(persona_id,
                                                    sucursal_id,
                                                    caso_id,
                                                    DateTime.Now,
                                                    0,
                                                    condicion_pago_id,
                                                    ref articulosDescuentoPorcentaje,
                                                    new string[] { articuloCodigo },
                                                    new decimal[] { 1 },
                                                    out articulosPrecios,
                                                    out fecha_primer_vencimiento,
                                                    out fecha_segundo_vencimiento,
                                                    sesion);

                                usar_fecha_primer_vencimiento = true;
                                usar_fecha_segundo_vencimiento = fecha_segundo_vencimiento != DateTime.MinValue;

                                out_moneda_origen_id = moneda_destino_id;
                                out_cotizacion_origen = cotizacion_destino;
                                precio = articulosPrecios[0];
                                descuento_porcentaje = articulosDescuentoPorcentaje[0];
                                if (precio.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                {
                                    throw new Exception("El Articulo no cuenta con un precio definido");
                                }
                                break;
                            default:
                                throw new NotImplementedException("PreciosService.GetPrecioPorArticulo(). WebService de cliente no definido.");
                        }

                        break;

                    default:
                        throw new Exception("Error en PreciosService.GetPrecioPorArticulo(). Estrategia de precio no implementada, variable de sistema EstrategiaPrecio");
                }

                return precio;
                */
                #endregion metodoAnterior

            }
            catch (System.Exception exp)
            {
                throw exp;
            }

        }

        public static void GetPrecioPorArticulo(decimal persona_id, decimal[] articulos_id, decimal[] articulos_cantidad, decimal moneda_destino_id,
                                                decimal sucursal_id, decimal caso_id, decimal cotizacion_destino, decimal lista_de_precios_id,
                                                decimal condicion_pago_id, decimal monto_entrega_inicial, DateTime fecha_documento,
                                                ref decimal[] descuento_porcentaje, out decimal[] articulos_precios, out decimal out_moneda_origen_id,
                                                out decimal out_cotizacion_origen, out DateTime fecha_primer_vencimiento, out bool usar_fecha_primer_vencimiento,
                                                out DateTime fecha_segundo_vencimiento, out bool usar_fecha_segundo_vencimiento,
                                                bool articulo_no_perteneciente_a_lista_de_precios, SessionService sesion)
        {
            try
            {
                DataTable consultaDT;
                int estrategiaPrecio;
                decimal articuloRecargoId;

                fecha_primer_vencimiento = DateTime.Now;
                usar_fecha_primer_vencimiento = true;

                for (int i = 0; i < articulos_id.Length; i++)
                {
                    DataTable dtArticulo = ArticulosService.GetArticulos(ArticulosService.Id_NombreCol + " = " + articulos_id[i], string.Empty, false, sucursal_id);
                    if (!dtArticulo.Rows[0][ArticulosService.ControlarPrecio_NombreCol].Equals(Definiciones.SiNo.Si))
                        throw new Exception("PreciosService.GetPrecioPorArticulo(). Error, no debe pedirse o controlarse el precio del artículo.");
                }

                estrategiaPrecio = int.Parse(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.EstrategiaPrecio).ToString());
                articuloRecargoId = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteArticuloPorRecargoFinanciero);

                articulos_precios = null;

                //Se obtienen los datos del precio segun la estrategia
                switch (estrategiaPrecio)
                {
                    case Definiciones.EstrategiaPrecio.FlujoModificacionListaPrecios:
                        throw new NotImplementedException("PreciosService.GetPrecioPorArticulo(). Estrategia de precios no implementada para recalcular todos los articulos.");
                    case Definiciones.EstrategiaPrecio.ModuloPrecios:
                        throw new NotImplementedException("PreciosService.GetPrecioPorArticulo(). Estrategia de precios no implementada para recalcular todos los articulos.");
                    case Definiciones.EstrategiaPrecio.WebService:
                        throw new NotImplementedException("PreciosService.GetPrecioPorArticulo(). Estrategia de precios no implementada para recalcular todos los articulos.");
                       
                        int clienteId = Convert.ToInt32(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.Cliente));
                        string[] articulosCodigo = new string[articulos_id.Length];

                        switch (clienteId)
                        {
                            case Definiciones.Clientes.Electroban:

                                for (int i = 0; i < articulos_id.Length; i++)
                                {
                                    if (articulos_id[i] != articuloRecargoId)
                                    {
                                        consultaDT = ArticulosService.GetArticulos(ArticulosService.Id_NombreCol + " = " + articulos_id[i], string.Empty, false, sucursal_id);
                                        articulosCodigo[i] = (string)consultaDT.Rows[0][ArticulosService.CodigoEmpresa_NombreCol];
                                    }
                                    else
                                    {
                                        articulosCodigo[i] = Definiciones.Error.Valor.EnteroPositivo.ToString();
                                    }
                                }

                                

                                usar_fecha_primer_vencimiento = true;

                                usar_fecha_segundo_vencimiento = fecha_segundo_vencimiento != DateTime.MinValue;

                                out_moneda_origen_id = moneda_destino_id;
                                out_cotizacion_origen = cotizacion_destino;
                                break;
                            default:
                                throw new NotImplementedException("PreciosService.GetPrecioPorArticulo(). WebService de cliente no definido.");
                        }

                        break;

                    default:
                        throw new Exception("Error en PreciosService.GetPrecioPorArticulo(). Estrategia de precio no implementada, variable de sistema EstrategiaPrecio");
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetPrecioPorArticulo

        #region GetPrecioArticulosDataTable
        public DataTable GetPrecioArticulosDataTable(string clausulas)
        {
            if (VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.EstrategiaPrecio) != Definiciones.EstrategiaPrecio.ModuloPrecios)
                throw new Exception("PreciosService.GetPrecioArticulos() puede ser utilizado solo si la estrategia de precios es por módulo Precios.");

            using (SessionService sesion = new SessionService())
            {
                if (!clausulas.Equals(string.Empty)) clausulas += " and ";
                clausulas += PreciosService.SucursalEntidadId_NombreCol + " = " + sesion.Entidad.ID;
                DataTable dt = sesion.Db.ART_PRECIOS_HIST_INFO_COMPLCollection.GetAsDataTable(clausulas, ArticuloNombre_NombreCol);
                return dt;
            }
        }
        #endregion GetPrecioArticulosDataTable

        #region GetPrecioPorArticuloSucursal
        public DataTable GetPrecioPorArticuloSucursal(decimal articulo_id, decimal sucursal_id)
        {
            if (VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.EstrategiaPrecio) != Definiciones.EstrategiaPrecio.ModuloPrecios)
                throw new Exception("PreciosService.GetPrecioArticulos() puede ser utilizado solo si la estrategia de precios es por módulo Precios.");

            using (SessionService sesion = new SessionService())
            {
                string clausula = PreciosService.ArticuloId_NombreCol + "=" + articulo_id + " and "
                                + PreciosService.SUCURSAL_ID_NombreCol + "=" + sucursal_id;
                DataTable dt = sesion.Db.ART_PRECIOS_HIST_INFO_COMPLCollection.GetAsDataTable(clausula, string.Empty);
                return dt;
            }
        }
        #endregion GetPrecioPorArticuloSucursal

        #region Guardar
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            if (VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.EstrategiaPrecio) != Definiciones.EstrategiaPrecio.ModuloPrecios)
                throw new Exception("PreciosService.GetPrecioArticulos() puede ser utilizado solo si la estrategia de precios es por módulo Precios.");

            using (SessionService sesion = new SessionService())
            {
                sesion.Db.BeginTransaction();
                ARTICULOS_PRECIOS_HISTORICOSRow row = new ARTICULOS_PRECIOS_HISTORICOSRow();

                row.ID = sesion.Db.GetSiguienteSecuencia("articulos_precios_hist_sqc");
                row.FECHA = DateTime.Now;
                row.USUARIO_ID = sesion.Usuario_Id;
                row.ARTICULO_ID = decimal.Parse(campos[PreciosService.ArticuloId_NombreCol].ToString());
                row.MONEDA_ID = decimal.Parse(campos[PreciosService.MONEDA_ID_NombreCol].ToString());
                row.PRECIO = Math.Round((decimal)campos[PreciosService.PRECIO_NombreCol], MonedasService.CantidadDecimalesStatic(row.MONEDA_ID));
                row.SUCURSAL_ID = decimal.Parse(campos[PreciosService.SUCURSAL_ID_NombreCol].ToString());
                row.COTIZACION_MONEDA = decimal.Parse(campos[PreciosService.COTIZACION_MONEDA_NombreCol].ToString());
                row.OBSERVACION = campos[PreciosService.Observacion_NombreCol].ToString();
                row.DESCUENTO_MAXIMO = (decimal)campos[PreciosService.DescuentoMaximo_NombreCol];
                row.CANTIDAD_MINIMA = (decimal)campos[PreciosService.CantidadMinima_NombreCol];

                ARTICULOSRow art = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(row.ARTICULO_ID);

                row.IMPUESTO_ID = art.IMPUESTO_ID;

                sesion.Db.ARTICULOS_PRECIOS_HISTORICOSCollection.Insert(row);
                sesion.Db.CommitTransaction();
            }
        }
        #endregion Guardar

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_PRECIOS"; }
        }
        public static string ArticulosPreciosHistoricos_Nombre_Tabla
        {
            get { return "ARTICULOS_PRECIOS_HISTORICOS"; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return ARTICULOS_PRECIOSCollection.ARTICULO_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return ARTICULOS_PRECIOS_HISTORICOSCollection.FECHAColumnName; }
        }
        public static string COTIZACION_MONEDA_NombreCol
        {
            get { return ARTICULOS_PRECIOSCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string IMPUESTO_ID_NombreCol
        {
            get { return ARTICULOS_PRECIOSCollection.IMPUESTO_IDColumnName; }
        }
        public static string MONEDA_ID_NombreCol
        {
            get { return ARTICULOS_PRECIOSCollection.MONEDA_IDColumnName; }
        }
        public static string PRECIO_NombreCol
        {
            get { return ARTICULOS_PRECIOSCollection.PRECIOColumnName; }
        }
        public static string SUCURSAL_ID_NombreCol
        {
            get { return ARTICULOS_PRECIOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ARTICULOS_PRECIOS_HISTORICOSCollection.IDColumnName; }
        }
        public static string DescuentoMaximo_NombreCol
        {
            get { return ARTICULOS_PRECIOS_HISTORICOSCollection.DESCUENTO_MAXIMOColumnName; }
        }
        public static string CantidadMinima_NombreCol
        {
            get { return ARTICULOS_PRECIOS_HISTORICOSCollection.CANTIDAD_MINIMAColumnName; }
        }
        #endregion Tabla

        #region Vistas
        public static string ArticuloNombre_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.ARTICULO_DESCRIPCION_INTERNAColumnName; }
        }
        public static string SucursalNombre_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.SUCURSALES_NOMBREColumnName; }
        }
        public static string SucursalAbreviarua_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.SUCURSALES_ABREVIATURAColumnName; }
        }
        public static string MonedaNombre_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.MONEDAS_NOMBREColumnName; }
        }
        public static string MonedaSimbolo_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.MONEDAS_SIMBOLOColumnName; }
        }
        public static string ArticuloCodigo_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.CODIGO_EMPRESAColumnName; }
        }
        public static string ArticuloFamiliaId_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.ARTICULOS_FAMILIA_IDColumnName; }
        }
        public static string ArticuloFamiliaNombre_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.ARTICULOS_FAMILIA_NOMBREColumnName; }
        }
        public static string ArticuloGrupoId_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.ARTICULOS_GRUPO_IDColumnName; }
        }
        public static string ArticuloGrupoNombre_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.ARTICULOS_GRUPO_NOMBREColumnName; }
        }
        public static string ArticuloSubGrupoId_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.ARTICULOS_SUB_GRUPO_IDColumnName; }
        }
        public static string ArticuloSubGrupoNombre_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.ARTICULOS_SUBGRUPOS_NOMBREColumnName; }
        }
        public static string SucursalEntidadId_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.SUCURSALES_ENTIDAD_IDColumnName; }
        }
        public static string SucursalEntidadNombre_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.SUCURSALES_ENTIDAD_NOMBREColumnName; }
        }
        public static string ImpuestoNombre_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.IMPUESTOS_NOMBREColumnName; }
        }
        public static string UsuarioNombre_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.USUARIOS_USUARIOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.OBSERVACIONColumnName; }
        }
        public static string Costo_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.COSTOColumnName; }
        }
        public static string CostoMonedaId_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.COSTO_MONEDA_IDColumnName; }
        }
        public static string CostoMonedaCotizacion_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.COSTO_MONEDA_COTIZACIONColumnName; }
        }
        public static string CostoMonedaSimbolo_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.COSTO_MONEDA_SIMBOLOColumnName; }
        }
        public static string MarcaId_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.MARCA_IDColumnName; }
        }
        public static string MarcaNombre_NombreCol
        {
            get { return ART_PRECIOS_HIST_INFO_COMPLCollection.NOMBRE_MARCAColumnName; }
        }
        #endregion Vistas
        #endregion Accessors
    }
}
