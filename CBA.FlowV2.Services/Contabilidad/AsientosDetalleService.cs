#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Contabilidad;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Common;
using System.Collections;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CBA.FlowV2.Services.Casos;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
    public class AsientosDetalleService
    {
        #region Clase Detalles
        public class Detalle
        {
            public decimal CuentaId;
            public decimal Debe;
            public decimal Haber;
            public decimal MonedaId;
            public decimal Cotizacion;
            public decimal DebeOrigen;
            public decimal HeberOrigen;
            public decimal MonedaOrigenId;
            public decimal CotizacionOrigen;
            public string Observacion;
            public decimal? RegistroRelacionadoId;
            public string TablaRelacionadaId;
            public decimal? Monto;
            public List<Tuple<string, decimal?, decimal?>> DatosRelacionados;

            public Detalle(decimal ctb_cuenta_id, decimal moneda_id, decimal cotizacion, decimal moneda_origen_id, decimal cotizacion_origen, string observacion, string tabla_relacionada_id, decimal? registro_relacionado_id, decimal? porcentaje)
            {
                this.CuentaId = ctb_cuenta_id;
                this.MonedaId = moneda_id;
                this.Cotizacion = cotizacion;
                this.CotizacionOrigen = cotizacion_origen;
                this.MonedaOrigenId = moneda_origen_id;
                this.Observacion = observacion;

                this.RegistroRelacionadoId = registro_relacionado_id;
                this.TablaRelacionadaId = tabla_relacionada_id;
                this.Monto = porcentaje;

                this.Debe = 0;
                this.Haber = 0;
                this.DebeOrigen = 0;
                this.HeberOrigen = 0;
            }

            public Detalle(decimal ctb_cuenta_id, decimal moneda_id, decimal cotizacion, decimal moneda_origen_id, decimal cotizacion_origen, string observacion, string tabla_relacionada_id, decimal? registro_relacionado_id, decimal? porcentaje, decimal debe, decimal haber, decimal debe_origen, decimal haber_origen, List<Tuple<string, decimal?, decimal?>> detalle_relacionado)
                : this(ctb_cuenta_id, moneda_id, cotizacion, moneda_origen_id, cotizacion_origen, observacion, tabla_relacionada_id, registro_relacionado_id, porcentaje)
            {
                this.Debe = debe;
                this.Haber = haber;
                this.DebeOrigen = debe_origen;
                this.HeberOrigen = haber_origen;
                this.DatosRelacionados = detalle_relacionado;
            }
        }

        public class Detalles
        {
            public decimal AsientoId;
            public bool Resumido;
            private Hashtable vDetalles;
            public string vTablaRelacionadaId { get; set; }
            public decimal vRegistroRelacionadoId { get; set; }

            public Detalles(decimal ctb_asiento_id, bool resumido)
            {
                this.AsientoId = ctb_asiento_id;
                this.Resumido = resumido;
                this.vDetalles = new Hashtable();
            }

            public void Agregar<T>(decimal ctb_cuenta_id, decimal debe, decimal haber, decimal moneda_id, decimal cotizacion, decimal moneda_origen_id, decimal cotizacion_origen, string observacion, bool invertir_debe_haber, bool invertir_si_es_negativo, CentrosCostoService.CentrosCostoAplicacion<T> centro_costo_aplicacion, decimal? caso_detalle_id, decimal centro_costo_porcentaje, Dictionary<decimal, decimal> centros_costo) where T : new()
            {
                Agregar(ctb_cuenta_id, debe, haber, moneda_id, cotizacion, moneda_origen_id, cotizacion_origen, observacion, invertir_debe_haber, invertir_si_es_negativo, centro_costo_aplicacion, caso_detalle_id, centro_costo_porcentaje, centros_costo, null, null);
            }

            public void Agregar<T>(decimal ctb_cuenta_id, decimal debe, decimal haber, decimal moneda_id, decimal cotizacion, decimal moneda_origen_id, decimal cotizacion_origen, string observacion, bool invertir_debe_haber, bool invertir_si_es_negativo, CentrosCostoService.CentrosCostoAplicacion<T> centro_costo_aplicacion, decimal? caso_detalle_id, decimal centro_costo_porcentaje, Dictionary<decimal, decimal> centros_costo, decimal? registroRelacionadoId, string tablaRelacionadaId) where T : new()
            {
                if (debe == 0 && haber == 0)
                    return;

                Detalle d;
                decimal[] arrCotizaciones = new decimal[] { cotizacion_origen, cotizacion };
                decimal[] arrMonedas = new decimal[] { moneda_origen_id, moneda_id };
                Tuple<decimal, decimal[], decimal[]> tuple = new Tuple<decimal, decimal[], decimal[]>(ctb_cuenta_id, arrMonedas, arrCotizaciones);

                if (this.vDetalles.Contains(tuple))
                {
                    List<Detalle> l = (List<Detalle>)this.vDetalles[tuple];

                    if (this.Resumido)
                    {
                        d = l[0];
                    }
                    else
                    {
                        d = new Detalle(ctb_cuenta_id, moneda_id, cotizacion, moneda_origen_id, cotizacion_origen, observacion, tablaRelacionadaId, registroRelacionadoId, null);
                        l.Add(d);
                    }
                }
                else
                {
                    d = new Detalle(ctb_cuenta_id, moneda_id, cotizacion, moneda_origen_id, cotizacion_origen, observacion, tablaRelacionadaId, registroRelacionadoId, null);
                    List<Detalle> l = new List<Detalle>();
                    l.Add(d);
                    this.vDetalles[tuple] = l;
                }

                if (tablaRelacionadaId != null && registroRelacionadoId != null)
                {
                    vTablaRelacionadaId = tablaRelacionadaId;
                    vRegistroRelacionadoId = registroRelacionadoId.Value;
                }

                if (invertir_si_es_negativo)
                {

                    if (debe < 0)
                        d.HeberOrigen += debe * -1;
                    else
                        d.DebeOrigen += debe;

                    if (haber < 0)
                        d.DebeOrigen += haber * -1;
                    else
                        d.HeberOrigen += haber;
                }
                else
                {
                    d.DebeOrigen += invertir_debe_haber ? haber : debe;
                    d.HeberOrigen += invertir_debe_haber ? debe : haber;
                }

                if (d.MonedaId == d.MonedaOrigenId)
                {
                    d.Debe = d.DebeOrigen;
                    d.Haber = d.HeberOrigen;
                }
                else
                {
                    d.Debe = d.DebeOrigen / d.CotizacionOrigen * d.Cotizacion;
                    d.Haber = d.HeberOrigen / d.CotizacionOrigen * d.Cotizacion;
                }

                d.Monto = d.Debe > 0 ? d.Debe : d.Haber;

                centro_costo_aplicacion.AgregarCuentaContable(caso_detalle_id, d, centros_costo, centro_costo_porcentaje);
            }

            public List<Detalle> Resultado()
            {
                List<Detalle> l = new List<Detalle>();

                foreach (DictionaryEntry entry in this.vDetalles)
                    l.AddRange((List<Detalle>)entry.Value);

                if (this.Resumido)
                {
                    var agrupado = (from y in l
                                    group y by new { y.CuentaId, y.MonedaId, y.CotizacionOrigen } into z
                                    select new
                                    {
                                        CuentaId = z.Key.CuentaId,
                                        Debe = z.Sum(a => a.Debe),
                                        Haber = z.Sum(a => a.Haber),
                                        MonedaId = z.Max(a => a.MonedaId),
                                        Cotizacion = z.Max(a => a.Cotizacion),
                                        DebeOrigen = z.Sum(a => a.DebeOrigen),
                                        HeberOrigen = z.Sum(a => a.HeberOrigen),
                                        MonedaOrigenId = z.Max(a => a.MonedaOrigenId),
                                        CotizacionOrigen = z.Max(a => a.CotizacionOrigen),
                                        Observacion = z.Max(a => a.Observacion),
                                        RegistroRelacionadoId = z.Max(a => a.RegistroRelacionadoId),
                                        TablaRelacionadaId = z.Max(a => a.TablaRelacionadaId),
                                        Porcentaje = z.Max(a => a.Monto)
                                    }).ToList();

                    List<Detalle> r = new List<Detalle>();

                    List<Tuple<string, decimal?, decimal?>> datosRelacionados;
                    foreach (var i in agrupado)
                    {
                        datosRelacionados = new List<Tuple<string, decimal?, decimal?>>();

                        foreach (Detalle det in l)
                        {
                            if (i.CuentaId == det.CuentaId && det.TablaRelacionadaId != null && det.RegistroRelacionadoId != null)
                                datosRelacionados.Add(new Tuple<string, decimal?, decimal?>(det.TablaRelacionadaId, det.RegistroRelacionadoId, det.Monto));
                        }

                        r.Add(new Detalle(i.CuentaId, i.MonedaId, i.Cotizacion, i.MonedaOrigenId, i.CotizacionOrigen, i.Observacion, i.TablaRelacionadaId, i.RegistroRelacionadoId, i.Porcentaje, i.Debe, i.Haber, i.DebeOrigen, i.HeberOrigen, datosRelacionados));
                    }

                    return r;
                }

                foreach (Detalle det in l)
                {
                    if (det.RegistroRelacionadoId != null)
                    {
                        det.DatosRelacionados = new List<Tuple<string, decimal?, decimal?>>();
                        det.DatosRelacionados.Add(new Tuple<string, decimal?, decimal?>(det.TablaRelacionadaId, det.RegistroRelacionadoId, det.Monto));
                    }
                }
                return l;
            }
        }
        #endregion Clase Detalles

        #region GetOrdenMaximo
        /// <summary>
        /// Gets the orden maximo.
        /// </summary>
        /// <param name="ctb_asiento_id">The ctb_asiento_id.</param>
        /// <returns></returns>
        public static decimal GetOrdenMaximo(decimal ctb_asiento_id, SessionService sesion)
        {
            string clausulas = AsientosDetalleService.CtbAsientoId_NombreCol + " = " + ctb_asiento_id + " and " +
                               AsientosDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

            CTB_ASIENTOS_DETALLERow[] rows = sesion.Db.CTB_ASIENTOS_DETALLECollection.GetAsArray(clausulas, AsientosDetalleService.Orden_NombreCol + " desc");

            if (rows.Length > 0) return rows[0].ORDEN;
            else return 0;
        }
        #endregion GetAsientosDataTable

        #region GetAsientosDetalleDataTable
        /// <summary>
        /// Gets the asientos detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAsientosDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAsientosDetalleDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetAsientosDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTB_ASIENTOS_DETALLECollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAsientosDetalleDataTable

        #region GetAsientosDetalleInfoCompleta
        /// <summary>
        /// Gets the asientos detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAsientosDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAsientosDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetAsientosDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTB_ASIENTOS_DET_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAsientosDetalleInfoCompleta

        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="asiento_detalle_id">The asiento_detalle_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal asiento_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_ASIENTOS_DETALLERow row = sesion.Db.CTB_ASIENTOS_DETALLECollection.GetByPrimaryKey(asiento_detalle_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region AbrirHuecoOrden
        /// <summary>
        /// Abrirs the hueco orden.
        /// </summary>
        /// <param name="ctb_asiento_id">The ctb_asiento_id.</param>
        /// <param name="orden_hueco">The orden_hueco.</param>
        /// <param name="sesion">The sesion.</param>
        private static void AbrirHuecoOrden(decimal ctb_asiento_id, decimal orden_acutal, decimal orden_nuevo, SessionService sesion)
        {
            string valorAnterior;
            string clausulas = AsientosDetalleService.CtbAsientoId_NombreCol + " = " + ctb_asiento_id + " and " +
                               AsientosDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " + " and " +
                               AsientosDetalleService.Orden_NombreCol + " >= " + orden_nuevo + " and " +
                               AsientosDetalleService.Orden_NombreCol + " <= " + orden_acutal;

            CTB_ASIENTOS_DETALLERow[] rows = sesion.Db.CTB_ASIENTOS_DETALLECollection.GetAsArray(clausulas, string.Empty);

            for (int i = 0; i < rows.Length; i++)
            {
                valorAnterior = rows[i].ORDEN.ToString();
                rows[i].ORDEN++;
                sesion.Db.CTB_ASIENTOS_DETALLECollection.Update(rows[i]);
                LogCambiosService.LogDeColumna(Nombre_Tabla, AsientosDetalleService.Orden_NombreCol, rows[i].ID, valorAnterior, rows[i].ORDEN.ToString(), sesion);
            }
        }
        #endregion AbrirHuecoOrden

        #region CerrarHuecoOrden
        /// <summary>
        /// Abrirs the hueco orden.
        /// </summary>
        /// <param name="ctb_asiento_id">The ctb_asiento_id.</param>
        /// <param name="orden_hueco">The orden_hueco.</param>
        /// <param name="sesion">The sesion.</param>
        private static void CerrarHuecoOrden(decimal ctb_asiento_id, decimal orden_hueco, SessionService sesion)
        {
            string valorAnterior;
            string clausulas = AsientosDetalleService.CtbAsientoId_NombreCol + " = " + ctb_asiento_id + " and " +
                               AsientosDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " + " and " +
                               AsientosDetalleService.Orden_NombreCol + " >= " + orden_hueco;

            CTB_ASIENTOS_DETALLERow[] rows = sesion.Db.CTB_ASIENTOS_DETALLECollection.GetAsArray(clausulas, string.Empty);

            for (int i = 0; i < rows.Length; i++)
            {
                valorAnterior = rows[i].ORDEN.ToString();
                rows[i].ORDEN--;
                sesion.Db.CTB_ASIENTOS_DETALLECollection.Update(rows[i]);
                LogCambiosService.LogDeColumna(Nombre_Tabla, AsientosDetalleService.Orden_NombreCol, rows[i].ID, valorAnterior, rows[i].ORDEN.ToString(), sesion);
            }
        }
        #endregion CerrarHuecoOrden

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <returns></returns>
        public static decimal Guardar(Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                return Guardar(campos, null, insertarNuevo, sesion);
            }
        }

        public static decimal Guardar(Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            return Guardar(campos, null, insertarNuevo, sesion);
        }

        public static decimal Guardar<T>(decimal ctb_asiento_id, AsientosDetalleService.Detalle detalle, CentrosCostoService.CentrosCostoAplicacion<T> centros_costo, SessionService sesion) where T : new()
        {
            Hashtable campos = new Hashtable();
            campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, ctb_asiento_id);
            campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, detalle.CuentaId);
            campos.Add(AsientosDetalleService.Debe_NombreCol, detalle.Debe);
            campos.Add(AsientosDetalleService.Haber_NombreCol, detalle.Haber);
            campos.Add(AsientosDetalleService.MonedaId_NombreCol, detalle.MonedaId);
            campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, detalle.Cotizacion);
            campos.Add(AsientosDetalleService.DebeOrigen_NombreCol, detalle.DebeOrigen);
            campos.Add(AsientosDetalleService.HaberOrigen_NombreCol, detalle.HeberOrigen);
            campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, detalle.MonedaOrigenId);
            campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, detalle.CotizacionOrigen);
            campos.Add(AsientosDetalleService.Observacion_NombreCol, detalle.Observacion);

            if (detalle.DatosRelacionados != null)
                campos.Add("datos_relacionados", detalle.DatosRelacionados);

            decimal idCreado;

            if (centros_costo == null)
                idCreado = Guardar(campos, null, true, sesion);
            else
                idCreado = Guardar(campos, centros_costo.GetCentrosCosto(detalle), true, sesion);

            return idCreado;
        }

        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="centros_costo">The centros_costo.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal Guardar(Hashtable campos, Hashtable centros_costo, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                CTB_ASIENTOS_DETALLERow row, rowAntes;
                string valorAnterior = string.Empty;
                decimal ordenMaximo = AsientosDetalleService.GetOrdenMaximo((decimal)campos[AsientosDetalleService.CtbAsientoId_NombreCol], sesion);
                DataTable dtAsiento = AsientosService.GetAsientosDataTable(AsientosService.Id_NombreCol + " = " + campos[AsientosDetalleService.CtbAsientoId_NombreCol], string.Empty, sesion);

                //Controla que el debe o haber sean mayor a cero
                if (!Interprete.EsNullODBNull(campos[AsientosDetalleService.Debe_NombreCol]) && !Interprete.EsNullODBNull(campos[AsientosDetalleService.Haber_NombreCol]))
                {
                    if ((decimal)campos[AsientosDetalleService.Debe_NombreCol] <= 0 && (decimal)campos[AsientosDetalleService.Haber_NombreCol] <= 0)
                        return Definiciones.Error.Valor.EnteroPositivo;
                }
                else if (!Interprete.EsNullODBNull(campos[AsientosDetalleService.DebeOrigen_NombreCol]) && !Interprete.EsNullODBNull(campos[AsientosDetalleService.HaberOrigen_NombreCol]))
                {
                    if ((decimal)campos[AsientosDetalleService.DebeOrigen_NombreCol] <= 0 && (decimal)campos[AsientosDetalleService.HaberOrigen_NombreCol] <= 0)
                        return Definiciones.Error.Valor.EnteroPositivo;
                }

                if (insertarNuevo)
                {
                    row = new CTB_ASIENTOS_DETALLERow();
                    rowAntes = new CTB_ASIENTOS_DETALLERow();
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("ctb_asientos_detalle_sqc");

                    row.FECHA = DateTime.Now;
                    row.USUARIO_CREACION_ID = sesion.Usuario_Id;
                    row.ESTADO = Definiciones.Estado.Activo;

                    //El numero del asiento es uno mas el asiento con mayor numero dentro del ejercicio
                    row.ORDEN = 1 + ordenMaximo;
                }
                else
                {
                    row = sesion.Db.CTB_ASIENTOS_DETALLECollection.GetByPrimaryKey((decimal)campos[AsientosDetalleService.Id_NombreCol]);

                    rowAntes = new CTB_ASIENTOS_DETALLERow();
                    rowAntes.CTB_CUENTA_ID = row.CTB_CUENTA_ID;
                    rowAntes.DEBE = row.DEBE;
                    rowAntes.HABER = row.HABER;
                    rowAntes.ORDEN = row.ORDEN;

                    valorAnterior = row.ToString();
                }

                row.CTB_ASIENTO_ID = (decimal)campos[AsientosDetalleService.CtbAsientoId_NombreCol];

                bool insertarRelacion = campos.Contains("datos_relacionados");

                //Validar que la cabecera esta activa
                if ((string)dtAsiento.Rows[0][AsientosService.Estado_NombreCol] == Definiciones.Estado.Inactivo)
                    throw new Exception("El asiento fue borrado.");

                //Si cambia
                if (row.CTB_CUENTA_ID.Equals(DBNull.Value) || row.CTB_CUENTA_ID != (decimal)campos[AsientosDetalleService.CtbCuentaId_NombreCol])
                {
                    row.CTB_CUENTA_ID = (decimal)campos[AsientosDetalleService.CtbCuentaId_NombreCol];
                    if (!CuentasService.EsAsentable(row.CTB_CUENTA_ID))
                        throw new Exception("La cuenta no es asentable.");
                }

                if (campos.Contains(AsientosDetalleService.MonedaOrigenId_NombreCol))
                {
                    row.MONEDA_ORIGEN_ID = (decimal)campos[AsientosDetalleService.MonedaOrigenId_NombreCol];
                    if (rowAntes.IsMONEDA_ORIGEN_IDNull || rowAntes.MONEDA_ORIGEN_ID != row.MONEDA_ORIGEN_ID)
                        row.COTIZACION_MONEDA_ORIGEN = Definiciones.Error.Valor.EnteroPositivo;
                }

                if (campos.Contains(AsientosDetalleService.MonedaId_NombreCol))
                {
                    row.MONEDA_ID = (decimal)campos[AsientosDetalleService.MonedaId_NombreCol];
                    if (rowAntes.MONEDA_ID != row.MONEDA_ID)
                        row.COTIZACION_MONEDA = Definiciones.Error.Valor.EnteroPositivo;
                }

                if (campos.Contains(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol))
                    row.COTIZACION_MONEDA_ORIGEN = (decimal)campos[AsientosDetalleService.CotizacionMonedaOrigen_NombreCol];
                else
                    row.COTIZACION_MONEDA_ORIGEN = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(sesion.SucursalActiva.ID), row.MONEDA_ORIGEN_ID, (DateTime)dtAsiento.Rows[0][AsientosService.FechaAsiento_NombreCol], sesion);

                if (row.COTIZACION_MONEDA_ORIGEN.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new Exception("Se debe indicar la cotización de la moneda origen.");

                if (row.MONEDA_ID == row.MONEDA_ORIGEN_ID)
                {
                    row.COTIZACION_MONEDA = row.COTIZACION_MONEDA_ORIGEN;
                }
                else
                {
                    if (campos.Contains(AsientosDetalleService.CotizacionMoneda_NombreCol))
                        row.COTIZACION_MONEDA = (decimal)campos[AsientosDetalleService.CotizacionMoneda_NombreCol];
                    else
                        row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais(sesion.SucursalActiva.ID), row.MONEDA_ID, (DateTime)dtAsiento.Rows[0][AsientosService.FechaAsiento_NombreCol], sesion);
                }

                if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new Exception("Se debe indicar la cotización de la moneda local.");

                if (campos.Contains(AsientosDetalleService.HaberOrigen_NombreCol))
                    row.HABER_ORIGEN = (decimal)campos[AsientosDetalleService.HaberOrigen_NombreCol];
                if (campos.Contains(AsientosDetalleService.DebeOrigen_NombreCol))
                    row.DEBE_ORIGEN = (decimal)campos[AsientosDetalleService.DebeOrigen_NombreCol];
                if (campos.Contains(AsientosDetalleService.Haber_NombreCol))
                    row.HABER = (decimal)campos[AsientosDetalleService.Haber_NombreCol];
                else
                    row.HABER = (decimal)campos[AsientosDetalleService.HaberOrigen_NombreCol];
                if (campos.Contains(AsientosDetalleService.Debe_NombreCol))
                    row.DEBE = (decimal)campos[AsientosDetalleService.Debe_NombreCol];
                else
                    row.DEBE = (decimal)campos[AsientosDetalleService.DebeOrigen_NombreCol];

                //Si cambia se debe reordenar
                if (campos.Contains(AsientosDetalleService.Orden_NombreCol))
                {
                    if (row.IsORDENNull || row.ORDEN != decimal.Parse(campos[AsientosDetalleService.Orden_NombreCol].ToString()))
                    {
                        AsientosDetalleService.AbrirHuecoOrden(row.CTB_ASIENTO_ID, row.ORDEN, decimal.Parse(campos[AsientosDetalleService.Orden_NombreCol].ToString()), sesion);

                        row.ORDEN = decimal.Parse(campos[AsientosDetalleService.Orden_NombreCol].ToString());

                        //Se verifica que el orden sea valido
                        if ((row.ORDEN > ordenMaximo && !insertarNuevo) ||
                            (row.ORDEN > (1 + ordenMaximo) && insertarNuevo))
                        {
                            throw new Exception("El orden es mayor a la cantidad de detalles.");
                        }
                    }
                }

                row.OBSERVACION = (string)campos[AsientosDetalleService.Observacion_NombreCol];
                if (row.OBSERVACION.Length <= 0) row.OBSERVACION = " ";

                #region Modificacion de observacion sistema
                if (!insertarNuevo)
                {
                    if (row.OBSERVACION_SISTEMA == null || row.OBSERVACION_SISTEMA.Length <= 0)
                        row.OBSERVACION_SISTEMA = string.Empty;
                    else
                        row.OBSERVACION_SISTEMA += " ";

                    string nombreUsuario = UsuariosService.GetNombreCompleto2(sesion.Usuario.ID, sesion);
                    bool usarEspacio = false;

                    if (rowAntes.CTB_CUENTA_ID != row.CTB_CUENTA_ID)
                    {
                        if (usarEspacio) row.OBSERVACION_SISTEMA += " ";
                        row.OBSERVACION_SISTEMA += "Cuenta modificada por " + nombreUsuario + " el " + DateTime.Now + ".";
                        usarEspacio = true;
                    }
                    if (rowAntes.DEBE != row.DEBE)
                    {
                        if (usarEspacio) row.OBSERVACION_SISTEMA += " ";
                        row.OBSERVACION_SISTEMA += "Debe modificado por " + nombreUsuario + " el " + DateTime.Now + ".";
                        usarEspacio = true;
                    }
                    if (rowAntes.HABER != row.HABER)
                    {
                        if (usarEspacio) row.OBSERVACION_SISTEMA += " ";
                        row.OBSERVACION_SISTEMA += "Haber modificado por " + nombreUsuario + " el " + DateTime.Now + ".";
                        usarEspacio = true;
                    }
                    if (rowAntes.ORDEN != row.ORDEN)
                    {
                        if (usarEspacio) row.OBSERVACION_SISTEMA += " ";
                        row.OBSERVACION_SISTEMA += "Orden modificado por " + nombreUsuario + " el " + DateTime.Now + ".";
                        usarEspacio = true;
                    }
                }
                #endregion Modificacion de observacion sistema

                if (insertarNuevo)
                {
                    sesion.Db.CTB_ASIENTOS_DETALLECollection.Insert(row);
                    AsientosDetalleCentrosCostoService.Crear(row.ID, centros_costo, sesion);

                    if (insertarRelacion)
                    {
                        List<Tuple<string, decimal?, decimal?>> datosRelacionados = (List<Tuple<string, decimal?, decimal?>>)campos["datos_relacionados"];
                        foreach (Tuple<string, decimal?, decimal?> dato in datosRelacionados)
                            GuardarAsientoDetalleRelacionado(row.ID, dato.Item2, dato.Item3, dato.Item1);
                    }
                }
                else
                {
                    sesion.Db.CTB_ASIENTOS_DETALLECollection.Update(row);
                }

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                return row.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void GuardarAsientoDetalleRelacionado(decimal ctbAsientoDetalleId, decimal? registroRelacionadoId, decimal? monto, string tablaRelacionadaId)
        {
            Hashtable campos = new Hashtable();
            campos.Add(AsientosDetalleRelacionesService.CtbAsientosDetalle_NombreCol, ctbAsientoDetalleId);
            campos.Add(AsientosDetalleRelacionesService.RegistroRelacionadoId_NombreCol, registroRelacionadoId);
            campos.Add(AsientosDetalleRelacionesService.TablaRelacionadaId_NombreCol, tablaRelacionadaId);
            campos.Add(AsientosDetalleRelacionesService.Monto_NombreCol, monto);

            AsientosDetalleRelacionesService.Guardar(campos, true);
        }

        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal asiento_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Borrar(asiento_detalle_id, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        /// <summary>
        /// Borrars the specified asiento_detalle_id.
        /// </summary>
        /// <param name="asiento_detalle_id">The asiento_detalle_id.</param>
        public static void Borrar(decimal asiento_detalle_id, SessionService sesion)
        {
            CTB_ASIENTOS_DETALLERow row = sesion.Db.CTB_ASIENTOS_DETALLECollection.GetByPrimaryKey(asiento_detalle_id);
            AsientosDetalleService asientoDetalle = new AsientosDetalleService();
            string valorAnterior = row.ESTADO;

            //Validar que la cabecera esta activa
            if (!AsientosService.EstaActivo(row.CTB_ASIENTO_ID, sesion))
                throw new Exception("El asiento fue borrado.");

            row.ESTADO = Definiciones.Estado.Inactivo;

            #region Modificacion de observacion sistema
            if (row.OBSERVACION_SISTEMA == null || row.OBSERVACION_SISTEMA.Length <= 0)
                row.OBSERVACION_SISTEMA = string.Empty;
            else
                row.OBSERVACION_SISTEMA += " ";

            string nombreUsuario = UsuariosService.GetNombreCompleto2(sesion.Usuario.ID, sesion);
            row.OBSERVACION_SISTEMA += "Borrado por " + nombreUsuario + " el " + DateTime.Now + ".";
            #endregion Modificacion de observacion sistema

            sesion.Db.CTB_ASIENTOS_DETALLECollection.Update(row);
            LogCambiosService.LogDeColumna(Nombre_Tabla, AsientosDetalleService.Estado_NombreCol, row.ID, valorAnterior, row.ESTADO, sesion);

            //Cerrar el hueco dejado por el detalle borrado
            AsientosDetalleService.CerrarHuecoOrden(row.CTB_ASIENTO_ID, row.ORDEN, sesion);
        }
        #endregion borrar

        #region Accesors

        public static string Nombre_Tabla
        {
            get { return "CTB_ASIENTOS_DETALLE"; }
        }
        public static string Nombre_Vista
        {
            get { return "CTB_ASIENTOS_DET_INFO_COMPLETA"; }
        }
        public static string CotizacionMonedaOrigen_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.COTIZACION_MONEDA_ORIGENColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtbAsientoId_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.CTB_ASIENTO_IDColumnName; }
        }
        public static string CtbCuentaId_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.CTB_CUENTA_IDColumnName; }
        }
        public static string DebeOrigen_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.DEBE_ORIGENColumnName; }
        }
        public static string Debe_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.DEBEColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.ESTADOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.FECHAColumnName; }
        }
        public static string HaberOrigen_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.HABER_ORIGENColumnName; }
        }
        public static string Haber_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.HABERColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.MONEDA_IDColumnName; }
        }
        public static string MonedaOrigenId_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.MONEDA_ORIGEN_IDColumnName; }
        }
        public static string ObservacionSistema_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.OBSERVACION_SISTEMAColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.OBSERVACIONColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.ORDENColumnName; }
        }
        public static string UsuarioCreacionId_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLECollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string VistaCtbCuentaCodigoCompleto_NombreCol
        {
            get { return CTB_ASIENTOS_DET_INFO_COMPLETACollection.CTB_CUENTA_CODIGO_COMPLETOColumnName; }
        }
        public static string VistaCtbCuentaNombre_NombreCol
        {
            get { return CTB_ASIENTOS_DET_INFO_COMPLETACollection.CTB_CUENTA_NOMBREColumnName; }
        }
        public static string VistaCtbEjercicioId_NombreCol
        {
            get { return CTB_ASIENTOS_DET_INFO_COMPLETACollection.CTB_EJERCICIO_IDColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTB_ASIENTOS_DET_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTB_ASIENTOS_DET_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaMonedaOrigenNombre_NombreCol
        {
            get { return CTB_ASIENTOS_DET_INFO_COMPLETACollection.MONEDA_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaMonedaOrigenSimbolo_NombreCol
        {
            get { return CTB_ASIENTOS_DET_INFO_COMPLETACollection.MONEDA_ORIGEN_SIMBOLOColumnName; }
        }
        public static string VistaUsuarioCreacionNombre_NombreCol
        {
            get { return CTB_ASIENTOS_DET_INFO_COMPLETACollection.USUARIO_CREACION_NOMBREColumnName; }
        }
        public static string VistaPlanCuentaId_NombreCol
        {
            get { return CTB_ASIENTOS_DET_INFO_COMPLETACollection.CTB_PLAN_CUENTA_IDColumnName; }
        }
        public static string VistaPlanCuentaNombre_NombreCol
        {
            get { return CTB_ASIENTOS_DET_INFO_COMPLETACollection.CTB_PLAN_CUENTA_NOMBREColumnName; }
        }
        public static string VistaCentrosCostos_NombreCol
        {
            get { return CTB_ASIENTOS_DET_INFO_COMPLETACollection.CENTROS_COSTOSColumnName; }
        }
        #endregion Accesors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static AsientosDetalleService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid},
            });

            if (e == null)
                return null;
            else
                return new AsientosDetalleService(e.RegistroId, sesion);
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
        protected CTB_ASIENTOS_DETALLERow row;
        protected CTB_ASIENTOS_DETALLERow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal CotizacionMoneda { get { return row.COTIZACION_MONEDA; } set { row.COTIZACION_MONEDA = value; } }
        public decimal? CotizacionMonedaOrigen { get { if (row.IsCOTIZACION_MONEDA_ORIGENNull) return null; else return row.COTIZACION_MONEDA_ORIGEN; } set { if (value.HasValue) row.COTIZACION_MONEDA_ORIGEN = value.Value; else row.IsCOTIZACION_MONEDA_ORIGENNull = true; } }
        public decimal CtbAsientoId { get { return row.CTB_ASIENTO_ID; } set { row.CTB_ASIENTO_ID = value; } }
        public decimal CtbCuentaId { get { return row.CTB_CUENTA_ID; } set { row.CTB_CUENTA_ID = value; } }
        public decimal Debe { get { return row.DEBE; } set { row.DEBE = value; } }
        public decimal? DebeOrigen { get { if (row.IsDEBE_ORIGENNull) return null; else return row.DEBE_ORIGEN; } set { if (value.HasValue) row.DEBE_ORIGEN = value.Value; else row.IsDEBE_ORIGENNull = true; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public decimal Haber { get { return row.HABER; } set { row.HABER = value; } }
        public decimal? HaberOrigen { get { if (row.IsHABER_ORIGENNull) return null; else return row.HABER_ORIGEN; } set { if (value.HasValue) row.HABER_ORIGEN = value.Value; else row.IsHABER_ORIGENNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal? MonedaOrigenId { get { if (row.IsMONEDA_ORIGEN_IDNull) return null; else return row.MONEDA_ORIGEN_ID; } set { if (value.HasValue) row.MONEDA_ORIGEN_ID = value.Value; else row.IsMONEDA_ORIGEN_IDNull = true; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public string ObservacionSistema { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION_SISTEMA); } set { row.OBSERVACION_SISTEMA = value; } }
        public decimal Orden { get { return row.ORDEN; } set { row.ORDEN = value; } }
        public decimal UsuarioCreacionId { get { return row.USUARIO_CREACION_ID; } set { row.USUARIO_CREACION_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private AsientosService _ctb_asiento;
        public AsientosService CtbAsiento
        {
            get
            {
                if (this._ctb_asiento == null)
                    this._ctb_asiento = new AsientosService(this.CtbAsientoId);
                return this._ctb_asiento;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                    this._moneda = new MonedasService(this.MonedaId);
                return this._moneda;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTB_ASIENTOS_DETALLECollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTB_ASIENTOS_DETALLERow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true;
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(CTB_ASIENTOS_DETALLERow row)
        {
            this.AlmacenarLocalmente = true;
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }
        
        public AsientosDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public AsientosDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public AsientosDetalleService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        private AsientosDetalleService(CTB_ASIENTOS_DETALLERow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCabecera
        public static AsientosDetalleService[] GetPorCabecera(decimal ctb_asiento_id, SessionService sesion)
        { 
            string clausulas = AsientosDetalleService.CtbAsientoId_NombreCol + " = " + ctb_asiento_id + " and " + 
                               AsientosDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            var rows = sesion.db.CTB_ASIENTOS_DETALLECollection.GetAsArray(clausulas, AsientosDetalleService.Orden_NombreCol);
            var detalles = new AsientosDetalleService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                detalles[i] = new AsientosDetalleService(rows[i]);
            return detalles;
        }
        #endregion GetPorCabecera
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
