#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.Net;
using System.IO;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class CotizacionesService
    {
        #region Getters

        #region GetCotizacionesDataTable
        public static DataTable GetCotizacionesDataTable(string clausula, SessionService sesion)
        {            
            return sesion.Db.COTIZACIONESCollection.GetAsDataTable(clausula, Modelo.IDColumnName);            
        }
        #endregion GetCotizacionesDataTable

        #region GetCotizacionesActuales
        /// <summary>
        /// Gets the cotizaciones actuales.
        /// </summary>
        /// <param name="pais_id">The pais_id.</param>
        /// <returns></returns>
        public static DataTable GetCotizacionesActuales(decimal pais_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = Modelo.ENTIDAD_IDColumnName + " = " + sesion.Usuario.ENTIDAD_ID + " and " +
                                  Modelo.PAIS_IDColumnName + " = " + pais_id;
                return sesion.Db.COTIZACIONES_MONEDACollection.GetAsDataTable(clausula, VistaModelo.MONEDAColumnName);
            }
        }

        public static DataTable GetCotizacionesActuales()
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = Modelo.ENTIDAD_IDColumnName + " = " + sesion.Usuario.ENTIDAD_ID;
                return sesion.Db.COTIZACIONES_MONEDACollection.GetAsDataTable(clausula, VistaModelo.MONEDAColumnName);
            }
        }
        #endregion GetCotizacionesActuales

        #region GetCotizacionesHistorico
        /// <summary>
        /// Gets the Historico.
        /// </summary>
        /// <param name="pais_id">The pais_id.</param>
        /// <returns></returns>
        public static DataTable GetCotizacionesHistorico(decimal pais_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = Modelo.ENTIDAD_IDColumnName + " = " + sesion.Usuario.ENTIDAD_ID + " and " +
                                  Modelo.PAIS_IDColumnName + " = " + pais_id;
                return sesion.Db.COTIZACIONESCollection.GetAsDataTable(clausula, Modelo.FECHAColumnName + " desc");
            }
        }

        public static DataTable GetCotizacionesHistoricoPorMoneda(decimal moneda_id, string fecha_desde, string fecha_hasta)
        {
            using (SessionService sesion = new SessionService())
            {
                string query = "select c.*, m." + MonedasService.Modelo.NOMBREColumnName + "\n" +
                               " from " + CotizacionesService.Nombre_Tabla + " c, \n" +
                               MonedasService.Nombre_Tabla + " m \n" +
                               " where c." + Modelo.MONEDA_IDColumnName + " = m." + MonedasService.Modelo.IDColumnName + "\n" +
                               " and c." + Modelo.ENTIDAD_IDColumnName + " = " + sesion.Usuario.ENTIDAD_ID +
                               " and c." + Modelo.MONEDA_IDColumnName + " = " + moneda_id + "\n";
                if (fecha_desde != string.Empty)
                    query += " and c." + Modelo.FECHAColumnName + " >= '" + fecha_desde + "'";
                if (fecha_hasta != string.Empty)
                    query += " and c." + Modelo.FECHAColumnName + " <= '" + fecha_hasta + "'"; 

                query += " order by c." + Modelo.FECHAColumnName + " desc, c." + Modelo.IDColumnName + " desc";

                return sesion.db.EjecutarQuery(query); 
            }
        }
        #endregion GetCotizacionesHistorico

        #region GetCotizacionMonedaCompra
        /// <summary>
        /// Devuelve la cotizacion de compra.
        /// </summary>
        /// <param name="pais_id">The pais_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <returns>La cotizacion o Definiciones.Error.Valor.EnteroPositivo si no existe cotizacion</returns>
        public static decimal GetCotizacionMonedaCompra(decimal pais_id, decimal moneda_id, DateTime fecha, SessionService sesion)
        {
            if (moneda_id == Definiciones.Monedas.Guaranies) return 1;
            string consulta = Modelo.ENTIDAD_IDColumnName + " = " + sesion.Usuario.ENTIDAD_ID + " and " +
                              Modelo.PAIS_IDColumnName + " = " + pais_id + " and " +
                              Modelo.MONEDA_IDColumnName + " = " + moneda_id + " and " +
                              "trunc(" + Modelo.FECHAColumnName + ") >= to_date('" + fecha.ToShortDateString() + "', 'dd/mm/yyyy') - " + VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.CotizacionDiasMaximoAntiguedad) + " and " +
                              "trunc(" + Modelo.FECHAColumnName + ") <= to_date('" + fecha.ToShortDateString() + "', 'dd/mm/yyyy') ";
            string orden = Modelo.FECHAColumnName + " desc, " + Modelo.IDColumnName + " desc";
            COTIZACIONESRow[] cotizacion = sesion.Db.COTIZACIONESCollection.GetAsArray(consulta, orden);
            return cotizacion.Length <= 0 ? Definiciones.Error.Valor.EnteroPositivo : cotizacion[0].COMPRA;
        }

        public static decimal GetCotizacionMonedaCompra(decimal pais_id, decimal moneda_id, DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCotizacionMonedaCompra(pais_id, moneda_id, fecha, sesion);
            }
        }

        /// <summary>
        /// Gets the cotizacion moneda compra.
        /// </summary>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <returns></returns>
        public static decimal GetCotizacionMonedaCompra(decimal pais_id, decimal moneda_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCotizacionMonedaCompra(pais_id, moneda_id, DateTime.Now, sesion);
            }
        }

        /// <summary>
        /// Gets the cotizacion moneda compra.
        /// </summary>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <returns></returns>
        public static decimal GetCotizacionMonedaCompra(decimal moneda_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCotizacionMonedaCompra(sesion.SucursalActiva.PAIS_ID, moneda_id, DateTime.Now, sesion);
            }
        }

        public static decimal GetCotizacionMonedaCompraActual(decimal pais_id, decimal moneda_id)
        {
            if (moneda_id == Definiciones.Monedas.Guaranies) return 1;
            using (SessionService sesion = new SessionService())
            {
                string consulta = Modelo.ENTIDAD_IDColumnName + " = " + sesion.Usuario.ENTIDAD_ID + " and " +
                                  Modelo.PAIS_IDColumnName + " = " + pais_id + " and " +
                                  Modelo.MONEDA_IDColumnName + " = " + moneda_id;
                string orden = "trunc(" + Modelo.FECHAColumnName + ") desc, " + Modelo.IDColumnName + " desc";
                COTIZACIONESRow[] cotizacion = sesion.Db.COTIZACIONESCollection.GetAsArray(consulta, orden);
                return cotizacion.Length <= 0 ? Definiciones.Error.Valor.EnteroPositivo : cotizacion[0].COMPRA;
            }
        }

        public static decimal GetCotizacionMonedaCompraActual(decimal moneda_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCotizacionMonedaCompraActual(sesion.SucursalActiva.PAIS_ID, moneda_id);
            }
        }
        #endregion GetCotizacionMonedaCompra

        #region GetCotizacionMonedaVenta
        /// <summary>
        /// Devuelve la cotizacion de venta.
        /// </summary>
        /// <param name="pais_id">The pais_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <returns>La cotizacion o Definiciones.Error.Valor.EnteroPositivo si no existe cotizacion</returns>
        public static decimal GetCotizacionMonedaVenta(decimal pais_id, decimal moneda_id, DateTime fecha, SessionService sesion)
        {
            if (moneda_id == Definiciones.Monedas.Guaranies) return 1;
            if (fecha > DateTime.Now) fecha = DateTime.Now;
            decimal paisId = pais_id;
            if (paisId == Definiciones.Error.Valor.EnteroPositivo) paisId = sesion.SucursalActiva.PAIS_ID;
            String consulta = Modelo.ENTIDAD_IDColumnName + " = " + sesion.Usuario.ENTIDAD_ID + " and " +
                              Modelo.PAIS_IDColumnName + " = " + paisId + " and " +
                              Modelo.MONEDA_IDColumnName + " = " + moneda_id + " and " +
                              "trunc(" + Modelo.FECHAColumnName + ") >= to_date('" + fecha.ToShortDateString() + "', 'dd/mm/yyyy') - " + VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.CotizacionDiasMaximoAntiguedad) + " and " +
                              "trunc(" + Modelo.FECHAColumnName + ") <= to_date('" + fecha.ToShortDateString() + "', 'dd/mm/yyyy') ";
            string orden = Modelo.FECHAColumnName + " desc, " + Modelo.IDColumnName + " desc";
            COTIZACIONESRow[] cotizacion = sesion.Db.COTIZACIONESCollection.GetAsArray(consulta, orden);
            return cotizacion.Length == 0 ? Definiciones.Error.Valor.EnteroPositivo : cotizacion[0].VENTA;
        }

        public static decimal GetCotizacionMonedaVenta(decimal pais_id, decimal moneda_id, DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCotizacionMonedaVenta(pais_id, moneda_id, fecha, sesion);
            }
        }

        /// <summary>
        /// Devuelve la cotizacion de venta del pais del usuario logueado.
        /// </summary>
        /// <param name="pais_id">The pais_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <returns>La cotizacion o Definiciones.Error.Valor.EnteroPositivo si no existe cotizacion</returns>
        public static decimal GetCotizacionMonedaVenta(decimal pais_id, decimal moneda_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCotizacionMonedaVenta(pais_id, moneda_id, DateTime.Now, sesion);
            }
        }

        /// <summary>
        /// Devuelve la cotizacion de venta del pais del usuario logueado.
        /// </summary>
        /// <param name="pais_id">The pais_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <returns>La cotizacion o Definiciones.Error.Valor.EnteroPositivo si no existe cotizacion</returns>
        public static decimal GetCotizacionMonedaVenta(decimal moneda_id, DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCotizacionMonedaVenta(sesion.SucursalActiva.PAIS_ID, moneda_id, fecha, sesion);
            }
        }

        /// <summary>
        /// Devuelve la cotizacion de venta del pais del usuario logueado.
        /// </summary>
        /// <param name="pais_id">The pais_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <returns>La cotizacion o Definiciones.Error.Valor.EnteroPositivo si no existe cotizacion</returns>
        public static decimal GetCotizacionMonedaVenta(decimal moneda_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCotizacionMonedaVenta(sesion.SucursalActiva.PAIS_ID, moneda_id, DateTime.Now);
            }
        }
        #endregion GetCotizacionMonedaVenta

        #region GetMonedasConCotizacionesPorPaisEntidad
        public DataTable GetMonedasConCotizacionesPorPaisEntidad()
        {
            using (SessionService sesion = new SessionService())
            {
                return GetMonedasConCotizacionesPorPaisEntidad(sesion.SucursalActiva_pais_id);
            }
        }

        public DataTable GetMonedasConCotizacionesPorPaisEntidad(decimal pais_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = Modelo.PAIS_IDColumnName + " = " + pais_id +
                                  " and " + Modelo.ENTIDAD_IDColumnName + " = " + sesion.EntidadActual_Id;
                DataTable dt = sesion.Db.COTIZACIONES_MONEDACollection.GetAsDataTable(clausula, MonedasService.Modelo.ORDENColumnName);
                return dt;
            }
        }
        #endregion GetMonedasConCotizacionesPorPaisEntidad

        #region ActualizarCotizacionesPorPais
        /// <summary>
        /// Actualizars the cotizaciones por pais.
        /// </summary>
        /// <param name="pais_id">The pais_id.</param>
        public void ActualizarCotizacionesPorPais(decimal pais_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dtCotizaciones;
                System.Collections.Hashtable campos;
                if (!PaisesService.EstaActivo(pais_id))
                    throw new System.ArgumentException("El país se encuentra inactivo.");

                dtCotizaciones = CotizacionesService.GetCotizacionesActuales(pais_id);
                for (int i = 0; i < dtCotizaciones.Rows.Count; i++)
                {
                    if ((decimal)dtCotizaciones.Rows[i][Modelo.MONEDA_IDColumnName] != Definiciones.Monedas.Guaranies)
                    {
                        campos = new System.Collections.Hashtable();
                        campos.Add(Modelo.PAIS_IDColumnName, dtCotizaciones.Rows[i][Modelo.PAIS_IDColumnName]);
                        campos.Add(Modelo.MONEDA_IDColumnName, dtCotizaciones.Rows[i][Modelo.MONEDA_IDColumnName]);
                        campos.Add(Modelo.COMPRAColumnName, dtCotizaciones.Rows[i][Modelo.COMPRAColumnName]);
                        campos.Add(Modelo.VENTAColumnName, dtCotizaciones.Rows[i][Modelo.VENTAColumnName]);
                        this.Guardar(campos);
                    }
                }
            }
        }
        #endregion ActualizarCotizacionesPorPais

        #region Obtener CotizacionesJSON
        public static void ObtenerCotizacionJSON(out double cotizacion_compra, out double cotizacion_venta, string tipo_cotizacion, string fecha_cotizacion)
        {
            cotizacion_compra = 0;
            cotizacion_venta = 0;           
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.CotizacionWebServiceDireccion));
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonUtil.Serializar(new
                {
                    usdpyg = tipo_cotizacion,
                    updated = fecha_cotizacion
                });                
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();             
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    CotizacionesJSON cotizacion = JsonUtil.Deserializar<CotizacionesJSON>(result);
                    switch (tipo_cotizacion)
                    {
                        case "set":
                            cotizacion_compra = cotizacion.Usdpyg.set.compra;
                            cotizacion_venta = cotizacion.Usdpyg.set.venta;
                            break;
                        case "bcp":
                            cotizacion_compra = cotizacion.Usdpyg.bcp.compra;
                            cotizacion_venta = cotizacion.Usdpyg.bcp.venta;
                            break;
                        case "cambioschaco":
                            cotizacion_compra = cotizacion.Usdpyg.cambioschaco.compra;
                            cotizacion_venta = cotizacion.Usdpyg.cambioschaco.venta;
                            break;
                        case "maxicambios":
                            cotizacion_compra = cotizacion.Usdpyg.maxicambios.compra;
                            cotizacion_venta = cotizacion.Usdpyg.maxicambios.venta;
                            break;
                        case "cambiosalberdi":
                            cotizacion_compra = cotizacion.Usdpyg.cambiosalberdi.compra;
                            cotizacion_venta = cotizacion.Usdpyg.cambiosalberdi.venta;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }
        #endregion Obtener CotizacionesJSON

        #region Sub-clase CotizacionesJSON
        public class Bcp
        {
            public double compra { get; set; }
            public double referencial_diario { get; set; }
            public double venta { get; set; }
        }

        public class Cambiosalberdi
        {
            public double compra { get; set; }
            public double venta { get; set; }
        }

        public class Cambioschaco
        {
            public double compra { get; set; }
            public double venta { get; set; }
        }

        public class Maxicambios
        {
            public double compra { get; set; }
            public double venta { get; set; }
        }

        public class Set
        {
            public double compra { get; set; }
            public double venta { get; set; }
        }

        public class usdpyg
        {
            public Bcp bcp { get; set; }
            public Cambiosalberdi cambiosalberdi { get; set; }
            public Cambioschaco cambioschaco { get; set; }
            public Maxicambios maxicambios { get; set; }
            public Set set { get; set; }
        }

        public class CotizacionesJSON
        {
            public usdpyg Usdpyg  { get; set; }
            public string updated { get; set; }
        }
        #endregion Sub-clase CotizacionesJSON

        #endregion Getters

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro.</param>
        /// 
        public void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    decimal dAux;
                    string valorAnterior = string.Empty;
                    bool insertarNuevo = true;
                    DataTable dt = new DataTable();
                    COTIZACIONESRow cotizacion = new COTIZACIONESRow();
                    if (campos.ContainsKey(Modelo.FECHAColumnName))
                    {
                        DateTime fecha = (DateTime)campos[Modelo.FECHAColumnName];
                        dt = CotizacionesService.GetCotizacionesDataTable(
                            "trunc(" + Modelo.FECHAColumnName + " , 'DDD') = '" + fecha.ToShortDateString() + "'", sesion);
                    }
                    else
                    {
                        dt = CotizacionesService.GetCotizacionesDataTable(
                            "trunc(" + Modelo.FECHAColumnName + " , 'DDD') = '" + DateTime.Now + "'", sesion);
                    }

                    if (dt.Rows.Count > 0)
                    {
                        cotizacion = sesion.Db.COTIZACIONESCollection.GetRow(Modelo.IDColumnName + " = " + decimal.Parse(dt.Rows[0][Modelo.IDColumnName].ToString()));
                        valorAnterior = cotizacion.ToString();
                        insertarNuevo = false;
                    }
                    else
                    {
                        cotizacion.ID = sesion.Db.GetSiguienteSecuencia("cotizaciones_sqc");
                        cotizacion.USUARIO_ID = sesion.Usuario.ID;
                        cotizacion.ENTIDAD_ID = sesion.Usuario.ENTIDAD_ID;
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }                    

                    if (campos.ContainsKey(Modelo.FECHAColumnName))
                    {
                        cotizacion.FECHA = (DateTime)campos[Modelo.FECHAColumnName];
                        //Si se esta indicando una cotizacion con fecha futura, se ubica
                        //a los 1 segundos de media noche para que el cambio de cotizacion
                        //en dicho dia tenga un horario de dia mayor (con alta probabilidad)
                        //y si es con fecha pasada entonces se ubica 1 segundo antes del dia siguiente
                        if (cotizacion.FECHA.Date > DateTime.Now.Date)
                        {
                            TimeSpan ts = new TimeSpan(0, 0, 1);
                            cotizacion.FECHA = cotizacion.FECHA.Date + ts;
                        }
                        else if (cotizacion.FECHA.Date < DateTime.Now.Date)
                        {
                            TimeSpan ts = new TimeSpan(23, 59, 59);
                            cotizacion.FECHA = cotizacion.FECHA.Date + ts;
                        }
                    }
                    else
                    {
                        cotizacion.FECHA = DateTime.Now;
                    }

                    dAux = (decimal)campos[Modelo.PAIS_IDColumnName];
                    if (cotizacion.PAIS_ID != dAux)
                    {
                        if (PaisesService.EstaActivo(dAux)) cotizacion.PAIS_ID = dAux;
                        else throw new System.ArgumentException("El país seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }

                    dAux = (decimal)campos[Modelo.MONEDA_IDColumnName];
                    if (cotizacion.MONEDA_ID != dAux)
                    {
                        if (MonedasService.EstaActivo(dAux)) cotizacion.MONEDA_ID = dAux;
                        else throw new System.ArgumentException("La moneda seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }

                    if (cotizacion.MONEDA_ID == Definiciones.Monedas.Guaranies)
                    {
                        throw new System.ArgumentException("No se puede modificar la cotización del Guaraní. Los cambios no fueron guardados.");
                    }

                    cotizacion.COMPRA = (decimal)campos[Modelo.COMPRAColumnName];
                    cotizacion.VENTA = (decimal)campos[Modelo.VENTAColumnName];
                    if (insertarNuevo)
                        sesion.Db.COTIZACIONESCollection.Insert(cotizacion);
                    else
                        sesion.Db.COTIZACIONESCollection.Update(cotizacion);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, cotizacion.ID, Definiciones.Log.RegistroNuevo, cotizacion.ToString(), sesion);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion Guardar

        #region Accessors
        public class Modelo : COTIZACIONESCollection_Base { public Modelo() : base(null) { } }
        public class VistaModelo : COTIZACIONES_MONEDACollection_Base { public VistaModelo() : base(null) { } }
        public static string Nombre_Tabla
        {
            get { return "COTIZACIONES"; }
        }
        public static string Nombre_Vista
        {
            get { return "COTIZACIONES_MONEDA"; }
        }    
        #endregion Accessors
    }
}
