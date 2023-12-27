using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using CBA.FlowV2.Services.ListaDePrecio;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Common;

namespace CBA.FlowV2.Services.Articulos
{/*
  para obtener precios
  * monedaid
  * articuloid
  * listaprecioid
  * sucursalid
  * no tener en cuenta(aun) cantidadminima y descuentomaximo del detalle
  * traer la fecha mas proxima cuando hay registros de promo
  * tener la funcion y pasarle a jose
  */
    public class PreciosService_new
    {

        #region getPrecioArticuloDePersona
        public static decimal getPrecioArticuloDePersona(decimal articuloId, decimal personaId, decimal? sucursalId, decimal moneda_destino_Id, decimal cantidadVenta, out decimal out_descuento_porcentaje, out decimal out_cotizacion_origen, out decimal out_moneda_origen_id, ref decimal listaPrecioUsada, DateTime fecha)
        {
            decimal listaPrecioId = Definiciones.Error.Valor.EnteroPositivo;
            var persona = PersonasService.GetPersonasDataTable(PersonasService.Id_NombreCol + " = " + personaId, string.Empty);
            if (persona.Rows.Count == 0)
                throw new Exception("Se debe seleccionar un cliente para continuar.");
            // si el cliente no tiene asociada una lista de precio, se consulta en la lista de precio por defecto
            if (Interprete.EsNullODBNull(persona.Rows[0][PersonasService.ListaPreciosId_NombreCol]))
                listaPrecioId = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.ListaDePrecioPorDefectoID);
            //throw new Exception("La persona "+persona.Rows[0][PersonasService.NombreCompleto_NombreCol]+" no tiene una lista de precio asignada.");
            else
                listaPrecioId = decimal.Parse(persona.Rows[0][PersonasService.ListaPreciosId_NombreCol].ToString());

            out_moneda_origen_id = ListasDePrecioService.GetListasDePrecioMonedaId(listaPrecioId);
            out_descuento_porcentaje = 0;

            decimal sucursal_id = sucursalId == null ? Definiciones.Error.Valor.EnteroPositivo : sucursalId.Value;

            using (SessionService sesion = new SessionService())
            {

                out_cotizacion_origen = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(sucursal_id), out_moneda_origen_id, DateTime.Now, sesion);

            }
                return getPrecioArticulo(articuloId, listaPrecioId, sucursalId, moneda_destino_Id, cantidadVenta, ref listaPrecioUsada, fecha);
            
        }
        #endregion getPrecioArticuloDePersona

        #region getPrecioArticulo
       
        public static decimal getPrecioArticulo(decimal articuloId, decimal listaPrecioId, decimal? sucursalId, decimal moneda_destino_Id, decimal cantidadVenta, ref decimal listaPrecioUsada, DateTime fecha){
            decimal precio = Definiciones.Error.Valor.EnteroPositivo;

            // si la lista de precio del cliente es igual a la lista de precio minorista(por defecto), cambiar a lista de precio mayorista
            if (listaPrecioId == VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.ListaDePrecioPorDefectoID))
           {
                DataTable articulo = ArticulosService.GetArticuloPorID(articuloId.ToString());
                decimal cantidadMayorista = decimal.Parse(articulo.Rows[0][ArticulosService.Cantidad_Mayorista_Nombrecol].ToString());
                // si la cantidad de venta es mayor o igual a la cantidad mayorista del articulo, entonces usamos la lista de precio mayorista
                if (cantidadVenta >= cantidadMayorista)
                    listaPrecioId = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.ListaDePrecioMayoristaID);
            }
            listaPrecioUsada = listaPrecioId;
            DataTable dt = GetPrecioArticulosDataTable(articuloId, listaPrecioId, sucursalId, fecha);

            if (dt.Rows.Count == 0)
                throw new Exception("El Artículo no cuenta con un precio definido en la lista " + ListasDePrecioService.GetListasDePrecioNombre(listaPrecioId) + " para la fecha " + fecha.ToString("dd-MM-yyyy"));

            #region cotizacion
            //Se obtiene la cotizacion destino
            decimal cotizacion_origen;
            decimal cotizacion_destino;

            cotizacion_origen = CotizacionesService.GetCotizacionMonedaCompra(moneda_destino_Id);
            cotizacion_destino = CotizacionesService.GetCotizacionMonedaCompra((decimal)dt.Rows[0][ListasDePrecioDetalleService.VistaListaPrecioMonedaId_NombreCol]);
             
            if (cotizacion_origen.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new System.ArgumentException("La moneda no tiene una cotización actualizada.");

            decimal factor;

            //Se calcula el factor: cotizacion_destino / cotizacion_origen si las monedas origen y destino son distintas
            if ((decimal)dt.Rows[0][ListasDePrecioDetalleService.VistaListaPrecioMonedaId_NombreCol] == moneda_destino_Id)
                factor = 1;
            else
                factor = (decimal)(cotizacion_destino / cotizacion_origen);

            #endregion cotizacion

            precio = decimal.Parse(dt.Rows[0][ListasDePrecioDetalleService.Precio_NombreCol].ToString()) * factor;
            return precio;
        }
        #endregion getPrecioArticulo

        #region GetPrecioArticulosDataTable
        public static DataTable GetPrecioArticulosDataTable(decimal articuloId, decimal? listaPrecioId, decimal? sucursalId, DateTime fecha)
        {
            {
                string clausulas = "";
                clausulas += ListasDePrecioDetalleService.ArticuloId_NombreCol + " =  " + articuloId + "\n";
             if(DateTime.Now.ToShortDateString().Equals(fecha.ToShortDateString()))
                clausulas += " and " + ListasDePrecioDetalleService.Estado_NombreCol + "  ='" + Definiciones.Estado.Activo + "'\n";
                if (listaPrecioId != null)
                    clausulas += " and " + ListasDePrecioDetalleService.ListaPrecioId_NombreCol + " =  " + listaPrecioId + "\n";

                if (sucursalId != null)
                {
                    clausulas += " and (" + ListasDePrecioDetalleService.SucursalId_NombreCol + " =  " + sucursalId + " \n";
                    clausulas += " or " + ListasDePrecioDetalleService.SucursalId_NombreCol + " is null )" + "\n";
                }
                else
                    clausulas += " and  " + ListasDePrecioDetalleService.SucursalId_NombreCol + " is null " + "\n";
                clausulas += "      and (trunc(" + ListasDePrecioDetalleService.FechaInicio_NombreCol + ") <= '" + fecha.ToString("dd-MM-yyyy") + "' " +
                             " and trunc(" + ListasDePrecioDetalleService.FechaFin_NombreCol + ") >= '" + fecha.ToString("dd-MM-yyyy") + "' " +
                             " or (trunc(" + ListasDePrecioDetalleService.FechaInicio_NombreCol + ") <= '" + fecha.ToString("dd-MM-yyyy") + "'  and " + ListasDePrecioDetalleService.FechaFin_NombreCol + " is null)) " + "\n";
             //   clausulas += "      and rownum = 1 " + "\n";
                string order = ListasDePrecioDetalleService.SucursalId_NombreCol + " asc, " + ListasDePrecioDetalleService.FechaFin_NombreCol + " desc, " + ListasDePrecioService.FechaInicio_NombreCol + " desc FETCH FIRST 1 ROWS ONLY";
                using (SessionService sesion = new SessionService())
                {
                    DataTable dt = sesion.Db.LISTA_PRECIOS_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, order);
                    return dt;
                }
            }
        }
        #endregion GetPrecioArticulosDataTable

        #region RedondearPrecio
        // Aplica redondeo al precio, segun variables de sistema.
        // Recibe lista de precio para decidir si se aplica o no el redondeo (segun el campo aplicar_redondeo en la tabla lista_precios)
        public static decimal RedondarPrecio(decimal precioBase, decimal listaDePrecioID)
        {
            try
            {
                // verificamos si la lista de precio en cuestion es para aplicar Redondeo
                if (!ListasDePrecioService.aplicarRedondeo(listaDePrecioID))
                {
                    return precioBase;
                }

                decimal valorRedondeo = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.ValorRedondeoEnListaDePrecio);

                decimal precioRedondeado = Definiciones.Error.Valor.EnteroPositivo;

                decimal resto = Definiciones.Error.Valor.EnteroPositivo;
                decimal cociente = Definiciones.Error.Valor.EnteroPositivo;


                switch ((int)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.TipoRedondeoEnListaDePrecio))
                {// https://parzibyte.me/blog/2019/06/20/redondear-numeros-c-sharp/
                    case 1:// redondeo hacia abajo
                        precioRedondeado = Math.Floor(precioBase);
                        resto = precioRedondeado % valorRedondeo;
                        cociente = Math.Floor(precioRedondeado / valorRedondeo);
                        precioRedondeado = valorRedondeo * cociente;
                        break;
                    case 2:// redondeo hacia arriba
                        precioRedondeado = Math.Ceiling(precioBase);
                        resto = precioRedondeado % valorRedondeo;
                        cociente = Math.Floor(precioRedondeado / valorRedondeo);
                        precioRedondeado = resto > 0 ? (valorRedondeo * cociente) + valorRedondeo : (valorRedondeo * cociente);
                        break;
                    case 3:// redondeo al valor mas cercano
                        precioRedondeado = Math.Round(precioBase);
                        resto = precioRedondeado % valorRedondeo;
                        cociente = Math.Floor(precioRedondeado / valorRedondeo);
                        if (resto >= valorRedondeo/2)
                            precioRedondeado = (valorRedondeo * cociente) + valorRedondeo;
                        else
                            precioRedondeado = valorRedondeo * cociente;
                        break;
                    default:
                        throw new NotImplementedException("Valor de Variable no definido.");
                }

                return precioRedondeado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion RedondearPrecio

        public static decimal GetPrecioPorArticulo(decimal articuloId, decimal? listaPrecioId, decimal? sucursalId)
        {
            DataTable dtprecio = GetPrecioArticulosDataTable(articuloId, listaPrecioId, sucursalId, DateTime.Now);
            if (dtprecio.Rows.Count > 0)
            {
                DataRow drPrecio = dtprecio.Rows[0];
                return decimal.Parse(drPrecio[ListasDePrecioDetalleService.Precio_NombreCol].ToString());
            }
            else
                return Definiciones.Error.Valor.EnteroPositivo;
        }
    }
}
