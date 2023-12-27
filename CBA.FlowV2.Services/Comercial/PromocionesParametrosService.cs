using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.TextosPredefinidos;
using CBA.FlowV2.Services.ListaDePrecio;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Comercial
{
    public class PromocionesParametrosService
    {
        #region Getters
        public static DataTable GetPromocionesParametrosDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PROMOCIONES_PARAMETROSCollection.GetAsDataTable(clausula, orden);
            }
        }

        public static DataTable GetPromocionesParametrosInfoCompleta(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                if (clausula.Equals(string.Empty))
                    clausula = "1=1";

                string query = string.Empty;
                query += "select pp.*, s." + SucursalesService.Modelo.NOMBREColumnName + ", \n" +
                    "sd." + StockDepositosService.Modelo.NOMBREColumnName + ", \n" +
                    "nvl(a." +  ArticulosService.Modelo.DESCRIPCION_IMPRESIONColumnName + ", a." + ArticulosService.Modelo.DESCRIPCION_INTERNAColumnName + ") " + ArticulosService.Modelo.DESCRIPCION_IMPRESIONColumnName + ", \n" +
                    "tp." + TextosPredefinidosService.Modelo.TEXTOColumnName + ", \n" +
                    "lp." + ListasDePrecioService.Nombre_NombreCol + " \n" +
                    "from " + Nombre_Tabla + " pp, \n" +
                    SucursalesService.Nombre_Tabla + " s, \n" +
                    StockDepositosService.Nombre_Tabla + " sd, \n" +
                    ArticulosService.Nombre_Tabla + " a, \n" +
                    TextosPredefinidosService.Nombre_Tabla + " tp, \n" +
                    ListasDePrecioService.Nombre_Tabla + " lp \n" +
                    "where pp." + Modelo.SUCURSAL_IDColumnName + " = s." + SucursalesService.Modelo.IDColumnName + " \n" +
                    " and pp." + Modelo.DEPOSITO_IDColumnName + " = sd." + StockDepositosService.Modelo.IDColumnName + " \n" +
                    " and pp." + Modelo.ARTICULO_IDColumnName + " = a." + ArticulosService.Modelo.IDColumnName + "(+) \n" +
                    " and pp." + Modelo.TEXTO_PREDEFINIDO_IDColumnName + " = tp." + TextosPredefinidosService.Modelo.IDColumnName + " \n" +
                    " and pp." + Modelo.LISTA_PRECIO_ID_DESTINOColumnName + " = lp." + ListasDePrecioService.Id_NombreCol + " \n" +
                    " and " + clausula;

                return sesion.db.EjecutarQuery(query);
            }
        }
        #endregion Getters
        
        private static decimal ObtenerPrecioPorArticulo(DataRow drDetallesFactura, DataRow drPromo, decimal sucursalID)
        {
            decimal precio = PreciosService_new.GetPrecioPorArticulo(
                decimal.Parse(drDetallesFactura[FacturasClienteDetalleService.ArticuloId_NombreCol].ToString()),
                decimal.Parse(drPromo[Modelo.LISTA_PRECIO_ID_DESTINOColumnName].ToString()), sucursalID);

            return precio;
        }

       


        //aplicar la promocion correspondiente a la factura de vanta
        public static void ValidarProcion(decimal facturaID) 
        {
            using (SessionService sesion = new SessionService())
            {
              FACTURAS_CLIENTERow fc =  sesion.db.FACTURAS_CLIENTECollection.GetByPrimaryKey(facturaID);
                //verificar si existe promocion activa para seguir
              if (!ExistePromo(fc.SUCURSAL_ID, fc.DEPOSITO_ID, fc.FECHA))
                  return; //de esta manera solo si existe recorremos los detalles y ahorramos tiempo
              //verificamos todos los detalles de la factura sumando los articulos del mismo id 
              string query = string.Empty;
              query += "select sum(fcd." + FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol +") "+ FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol+", fcd." + FacturasClienteDetalleService.ArticuloId_NombreCol + " from " + FacturasClienteDetalleService.Nombre_Tabla + " fcd where fcd." + FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + facturaID.ToString() + " group by " + FacturasClienteDetalleService.ArticuloId_NombreCol + "";
              DataTable dtDetalle = sesion.db.EjecutarQuery(query); //primero sumamos todos los articulos iguales para obtener la cantidad
              foreach (DataRow drDetalle in dtDetalle.Rows)
              {
                  DataTable dtPromo = ObtenerPromocion(fc.SUCURSAL_ID, fc.DEPOSITO_ID, fc.FECHA, decimal.Parse(drDetalle[FacturasClienteDetalleService.ArticuloId_NombreCol].ToString()), fc.TOTAL_MONTO_BRUTO, decimal.Parse(drDetalle[FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol].ToString()));
                  
                  //en caso de tener mas de una procion
                  //aplicar la promocion cuyo precio sea el menor
                      decimal PrecioMinimo = decimal.MaxValue;
                      decimal ListaPrecioID = CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo;
                      foreach (DataRow drPromo in dtPromo.Rows)
                      {
                          decimal precio = ObtenerPrecioPorArticulo(drDetalle, drPromo, fc.SUCURSAL_ID);
                          if (precio < PrecioMinimo && precio != CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo)
                          {
                              PrecioMinimo = precio;
                              ListaPrecioID = decimal.Parse(drPromo[Modelo.LISTA_PRECIO_ID_DESTINOColumnName].ToString());
                          }
                      }
                      query = "select *  from " + FacturasClienteDetalleService.Nombre_Tabla + " fcd where fcd." + FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + facturaID.ToString() + "and " + FacturasClienteDetalleService.ArticuloId_NombreCol + " = " + drDetalle[FacturasClienteDetalleService.ArticuloId_NombreCol].ToString();
                      DataTable dtDetalleFactura = sesion.db.EjecutarQuery(query); //primero sumamos todos los articulos iguales para obtener la cantidad
                      foreach (DataRow drDetallesFactura in dtDetalleFactura.Rows)
                      {
                          if (PrecioMinimo != CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo && PrecioMinimo != decimal.MaxValue)
                          {
                              actualizarDetalleFactura(fc.ID, drDetallesFactura, PrecioMinimo, ListaPrecioID);
                          }

                      }
                  
                      
                  /*
                  else if (dtPromo.Rows.Count == 1)
                  {
                      //aqui es donde cambiaremos los precios
                      //tenemos dos reglas por cantidad y por monto
                      DataRow drPromo = dtPromo.Rows[0];
                      if (drPromo[Modelo.TEXTO_PREDEFINIDO_IDColumnName].ToString() == "234") //por articulo y cantidad
                      {
                          #region ActualizarPrecio
                          //obtenemos los registros con el mismo articuloID
                          query = "select *  from " + FacturasClienteDetalleService.Nombre_Tabla + " fcd where fcd." + FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + facturaID.ToString() + "and " + FacturasClienteDetalleService.ArticuloId_NombreCol + " = " + drDetalle[FacturasClienteDetalleService.ArticuloId_NombreCol].ToString();
                          DataTable dtDetalleFactura = sesion.db.EjecutarQuery(query); //primero sumamos todos los articulos iguales para obtener la cantidad
                          foreach (DataRow drDetallesFactura in dtDetalleFactura.Rows)
                          {
                              decimal precio = PreciosService_new.GetPrecioPorArticulo(decimal.Parse(drDetallesFactura[FacturasClienteDetalleService.ArticuloId_NombreCol].ToString()), decimal.Parse(drPromo[Modelo.LISTA_PRECIO_ID_DESTINOColumnName].ToString()), fc.SUCURSAL_ID);

                              if (precio != CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo)
                              {
                                  actualizarDetalleFactura(fc.ID,drDetallesFactura, precio, decimal.Parse(drPromo[Modelo.LISTA_PRECIO_ID_DESTINOColumnName].ToString()));
                              }

                          }
                          #endregion ActualizarPrecio
                      }
                      if (drPromo[Modelo.TEXTO_PREDEFINIDO_IDColumnName].ToString() == "233") //por monto de la venta
                      {
                          #region ActualizarPrecio
                          //obtenemos los detalles
                          query = "select *  from " + FacturasClienteDetalleService.Nombre_Tabla + " fcd where fcd." + FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + facturaID.ToString();
                          DataTable dtDetalleFactura = sesion.db.EjecutarQuery(query); //primero sumamos todos los articulos iguales para obtener la cantidad
                          foreach (DataRow drDetallesFactura in dtDetalleFactura.Rows)
                          {
                              decimal precio = PreciosService_new.GetPrecioPorArticulo(decimal.Parse(drDetallesFactura[FacturasClienteDetalleService.ArticuloId_NombreCol].ToString()), decimal.Parse(drPromo[Modelo.LISTA_PRECIO_ID_DESTINOColumnName].ToString()), fc.SUCURSAL_ID);

                              if (precio != CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo)
                              {
                                  actualizarDetalleFactura(fc.ID, drDetallesFactura, precio, decimal.Parse(drPromo[Modelo.LISTA_PRECIO_ID_DESTINOColumnName].ToString()));
                              
                              }

                          }
                          #endregion ActualizarPrecio
                      }
                   
                  }
                   */
              }
               
            }
        }
        private static void actualizarDetalleFactura(decimal FacturaId, DataRow drDetallesFactura, decimal Precio, decimal ListaPrecioId) 
        {
            DateTime fechaPrimerVencimiento = DateTime.Now, fechaSegundoVencimiento = DateTime.MinValue;
            bool usarFechaPrimerVencimiento = false, usarFechaSegundoVencimiento = false;

            // Traemos los datos del cliente. Para validar si es diplomatico.

            System.Collections.Hashtable campos = new System.Collections.Hashtable();
            campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, FacturaId);
            campos.Add(FacturasClienteDetalleService.Id_NombreCol, decimal.Parse(drDetallesFactura[FacturasClienteDetalleService.Id_NombreCol].ToString()));
            campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, decimal.Parse(drDetallesFactura[FacturasClienteDetalleService.ArticuloId_NombreCol].ToString()));
            campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, decimal.Parse(drDetallesFactura[FacturasClienteDetalleService.LoteId_NombreCol].ToString()));
            campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, drDetallesFactura[FacturasClienteDetalleService.UnidadDestinoId_NombreCol].ToString());
            campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, decimal.Parse(drDetallesFactura[FacturasClienteDetalleService.CantidadEmbalada_NombreCol].ToString()));
            campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, decimal.Parse(drDetallesFactura[FacturasClienteDetalleService.CantidadUnidadOrigen_NombreCol].ToString()));
            campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, decimal.Parse(drDetallesFactura[FacturasClienteDetalleService.ImpuestoId_NombreCol].ToString()));
            campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, Precio);
            campos.Add(FacturasClienteDetalleService.ListaPreciosId_NombreCol, ListaPrecioId);
            campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, decimal.Parse(drDetallesFactura[FacturasClienteDetalleService.MontoDescuento_NombreCol].ToString()));
            campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, decimal.Parse(drDetallesFactura[FacturasClienteDetalleService.PorcentajeDescuento_NombreCol].ToString()));
            campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, drDetallesFactura[FacturasClienteDetalleService.Observacion_NombreCol].ToString());
            campos.Add(FacturasClienteDetalleService.DepositoId_NombreCol, decimal.Parse(drDetallesFactura[FacturasClienteDetalleService.DepositoId_NombreCol].ToString()));

            //Guardar los datos
            FacturasClienteDetalleService.Guardar(FacturaId, campos, false, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true);

        }
        public static bool ExistePromo(decimal sucursalId, decimal deposito, DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    DataTable dtPromocion = sesion.Db.PROMOCIONES_PARAMETROSCollection.GetAsDataTable(Modelo.SUCURSAL_IDColumnName + " = " + sucursalId.ToString() + " \n" +
                                    "AND " + Modelo.DEPOSITO_IDColumnName + " = " + deposito.ToString() + " \n" +
                                   "AND " + Modelo.FECHA_INICIOColumnName + " <= TO_DATE('" + fecha.ToString("dd/MM/yyyy") + "', 'DD/MM/YYYY') " + " \n" +
                                   "AND (" + Modelo.FECHA_FINColumnName + " IS NULL OR " + Modelo.FECHA_FINColumnName + " >= TO_DATE('" + fecha.ToString("dd/MM/yyyy") + "', 'DD/MM/YYYY')) " , string.Empty);
                    return dtPromocion.Rows.Count > 0;
                }
                catch (Exception exp)
                {

                    throw exp;
                }

            }
        }
        public static DataTable ObtenerPromocion(decimal sucursalId, decimal deposito, DateTime fecha, decimal articuloId, decimal monto, decimal cantidad) 
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    string where = Modelo.SUCURSAL_IDColumnName + " = " + sucursalId.ToString() + " \n" +
                                    "AND " + Modelo.DEPOSITO_IDColumnName + " = " + deposito.ToString() + " \n" +
                                   "AND " + Modelo.FECHA_INICIOColumnName + " <= TO_DATE('" + fecha.ToString("dd/MM/yyyy") + "', 'DD/MM/YYYY') " + " \n" +
                                   "AND (" + Modelo.FECHA_FINColumnName+ " IS NULL OR " + Modelo.FECHA_FINColumnName + " >= TO_DATE('" + fecha.ToString("dd/MM/yyyy") + "', 'DD/MM/YYYY')) " + " \n" +
                                   "AND ( " + " \n" +
                                    " (" + Modelo.TEXTO_PREDEFINIDO_IDColumnName + " = 234 AND " + Modelo.ARTICULO_IDColumnName + " = " + articuloId.ToString() + " AND " + Modelo.VALOR_MINIMOColumnName + " <= " + cantidad + ") " + " \n" +
                                     "OR " +
                                     "(" + Modelo.TEXTO_PREDEFINIDO_IDColumnName + " = 233 AND " + Modelo.VALOR_MINIMOColumnName+ " <= "+monto+") " + " \n" +
                                     "OR " + " \n" +
                                     "" + Modelo.TEXTO_PREDEFINIDO_IDColumnName + " NOT IN (233, 234))";
                    DataTable dtPromocion = sesion.Db.PROMOCIONES_PARAMETROSCollection.GetAsDataTable(where, string.Empty);
                    return dtPromocion;
                }
                catch (Exception exp)
                {

                    throw exp;
                }
                
            }
        }

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PROMOCIONES_PARAMETROSRow promocionesParametros = new PROMOCIONES_PARAMETROSRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        promocionesParametros.ID = sesion.Db.GetSiguienteSecuencia("promociones_parametros_sqc");                        
                        valorAnterior = CBA.FlowV2.Services.Base.Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        promocionesParametros = sesion.Db.PROMOCIONES_PARAMETROSCollection.GetRow(Modelo.IDColumnName + " = " + decimal.Parse(campos[Modelo.IDColumnName].ToString()));
                        valorAnterior = promocionesParametros.ToString();
                    }

                    promocionesParametros.TEXTO_PREDEFINIDO_ID = decimal.Parse(campos[Modelo.TEXTO_PREDEFINIDO_IDColumnName].ToString());
                    promocionesParametros.SUCURSAL_ID = decimal.Parse(campos[Modelo.SUCURSAL_IDColumnName].ToString());
                    promocionesParametros.DEPOSITO_ID = decimal.Parse(campos[Modelo.DEPOSITO_IDColumnName].ToString());
                    if (campos.Contains(Modelo.ARTICULO_IDColumnName))
                        promocionesParametros.ARTICULO_ID = decimal.Parse(campos[Modelo.ARTICULO_IDColumnName].ToString());

                    promocionesParametros.VALOR_MINIMO = decimal.Parse(campos[Modelo.VALOR_MINIMOColumnName].ToString());
                    promocionesParametros.LISTA_PRECIO_ID_DESTINO = decimal.Parse(campos[Modelo.LISTA_PRECIO_ID_DESTINOColumnName].ToString());
                    promocionesParametros.FECHA_INICIO = DateTime.Parse(campos[Modelo.FECHA_INICIOColumnName].ToString());
                    if (campos.Contains(Modelo.FECHA_FINColumnName))
                        promocionesParametros.FECHA_FIN = DateTime.Parse(campos[Modelo.FECHA_FINColumnName].ToString());

                    if (insertarNuevo) sesion.Db.PROMOCIONES_PARAMETROSCollection.Insert(promocionesParametros);
                    else sesion.Db.PROMOCIONES_PARAMETROSCollection.Update(promocionesParametros);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, promocionesParametros.ID, valorAnterior, promocionesParametros.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Accesors
        public const string Nombre_Tabla = "PROMOCIONES_PARAMETROS";
        public class Modelo : PROMOCIONES_PARAMETROSCollection_Base { public Modelo() : base(null) { } }
        #endregion Accesors
    }
}
