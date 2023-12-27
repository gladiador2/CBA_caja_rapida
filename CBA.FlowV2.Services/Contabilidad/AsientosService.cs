#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Contabilidad;
using CBA.FlowV2.Services.Herramientas;
using System.Text;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Casos;
using System.Collections.Generic;
using System.Collections;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
    public class AsientosService
    {
        #region clase de configuracion para crear asiento global
        public class AsientoGlobalConfiguracion
        {
            public decimal? sucursalId;
            public decimal? regionId;
            public decimal ctbEjercicioId;
            public bool sucursalesIndividuales;
            public bool? esApertura, esRegularizacion, esCierre;
            public bool? manual;
            public DateTime fechaDesde, fechaHasta;
            public string observacion;
        }

        private class AsientoGlobalDatos
        {
            #region subclases
            public class Cabecera
            {
                private Dictionary<decimal, Detalle> detalles;
                public List<decimal> asientosOrigen;
                public decimal periodoId, sucursalId, monedaId, cotizacion;
                public string aprobado, automatico, esApertura, esRegularizacion, esCierre, observacion;
                public DateTime fecha;

                public Cabecera()
                {
                    this.detalles = new Dictionary<decimal, Detalle>();
                    this.asientosOrigen = new List<decimal>();
                    this.aprobado = this.automatico = this.esApertura = this.esRegularizacion = this.esCierre = this.observacion = string.Empty;
                }

                public void Agregar(decimal ctb_asiento_origen_id, decimal ctb_cuenta_id, decimal debe, decimal haber, object centro_costo_id, object porcentaje)
                {
                    if (!this.detalles.ContainsKey(ctb_cuenta_id))
                    {
                        //Las cuentas en positivo agrupan el debe y en negativo el haber
                        this.detalles.Add(ctb_cuenta_id, new Detalle(this, ctb_cuenta_id, this.monedaId, this.cotizacion));
                        this.detalles.Add(-ctb_cuenta_id, new Detalle(this, -ctb_cuenta_id, this.monedaId, this.cotizacion));
                    }

                    this.asientosOrigen.Add(ctb_asiento_origen_id);
                    if (debe != 0)
                        this.detalles[ctb_cuenta_id].Agregar(debe, centro_costo_id, porcentaje);
                    if (haber != 0)
                        this.detalles[-ctb_cuenta_id].Agregar(haber, centro_costo_id, porcentaje);
                }

                public Hashtable GetHashTable()
                {
                    return new Hashtable()
                    {
                        { AsientosService.CtbPeriodoId_NombreCol, this.periodoId },
                        { AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No },
                        { AsientosService.Automatico_NombreCol, Definiciones.SiNo.No},
                        { AsientosService.EsApertura_NombreCol, this.esApertura },
                        { AsientosService.EsRegularizacion_NombreCol, this.esRegularizacion },
                        { AsientosService.EsCierre_NombreCol, this.esCierre },
                        { AsientosService.EsGlobal_NombreCol, Definiciones.SiNo.Si},
                        { AsientosService.FechaAsiento_NombreCol, this.fecha },
                        { AsientosService.Observacion_NombreCol, this.observacion },
                        { AsientosService.RevisionPosterior_NombreCol, Definiciones.SiNo.No },
                        { AsientosService.SucursalId_NombreCol, this.sucursalId },
                    };
                }

                public Detalle[] GetDetalles()
                {
                    var aDetalles = new Detalle[this.detalles.Count];
                    int i = 0;
                    foreach (KeyValuePair<decimal, Detalle> item in this.detalles)
                        aDetalles[i++] = item.Value;

                    return aDetalles;
                }
            }

            public class Detalle
            {
                private Cabecera cabecera;
                private decimal cuentaId;
                private Dictionary<decimal, DetalleCentroCosto> centrosCosto;
                private Hashtable htDatos;

                //Debe entra como positivo y haber como negativo
                private decimal total;

                public Detalle(Cabecera cabecera, decimal ctb_cuenta_id, decimal moneda_id, decimal cotizacion)
                {
                    this.cabecera = cabecera;
                    this.cuentaId = ctb_cuenta_id;
                    this.total = 0;
                    this.centrosCosto = new Dictionary<decimal, DetalleCentroCosto>();

                    this.htDatos = new Hashtable();
                    this.htDatos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, this.cuentaId);
                    this.htDatos.Add(AsientosDetalleService.Debe_NombreCol, 0);
                    this.htDatos.Add(AsientosDetalleService.Haber_NombreCol, 0);
                    this.htDatos.Add(AsientosDetalleService.MonedaId_NombreCol, moneda_id);
                    this.htDatos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacion);
                    this.htDatos.Add(AsientosDetalleService.DebeOrigen_NombreCol, 0);
                    this.htDatos.Add(AsientosDetalleService.HaberOrigen_NombreCol, 0);
                    this.htDatos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, moneda_id);
                    this.htDatos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, cotizacion);
                    this.htDatos.Add(AsientosDetalleService.Observacion_NombreCol, string.Empty);
                }

                public void Agregar(decimal monto, object centro_costo_id, object porcentaje)
                {
                    decimal centroCostoId = !Interprete.EsNullODBNull(centro_costo_id) ? (decimal)centro_costo_id : Definiciones.Error.Valor.EnteroPositivo;
                    decimal porcentajeAsignado = !Interprete.EsNullODBNull(porcentaje) ? decimal.Parse(porcentaje.ToString()) : 100; //porcentaje llega como double
                    if (!this.centrosCosto.ContainsKey(centroCostoId))
                        this.centrosCosto.Add(centroCostoId, new DetalleCentroCosto(centroCostoId));
                    
                    this.total += monto;
                    this.centrosCosto[centroCostoId].Agregar(monto, centroCostoId, porcentajeAsignado);
                }

                public Hashtable GetHashTable()
                {
                    return new Hashtable()
                    {   
                        { AsientosDetalleService.CtbCuentaId_NombreCol, Math.Abs(this.cuentaId) },
                        { AsientosDetalleService.Debe_NombreCol, this.cuentaId > 0 ? this.total : 0 },
                        { AsientosDetalleService.Haber_NombreCol, this.cuentaId < 0 ? this.total : 0 },
                        { AsientosDetalleService.MonedaId_NombreCol, this.cabecera.monedaId },
                        { AsientosDetalleService.CotizacionMoneda_NombreCol, this.cabecera.cotizacion },
                        { AsientosDetalleService.DebeOrigen_NombreCol, this.total > 0 ? this.total : 0 },
                        { AsientosDetalleService.HaberOrigen_NombreCol, this.total < 0 ? -this.total : 0 },
                        { AsientosDetalleService.MonedaOrigenId_NombreCol, this.cabecera.monedaId },
                        { AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, this.cabecera.cotizacion },
                        { AsientosDetalleService.Observacion_NombreCol, this.cabecera.observacion },
                    };
                }

                public Hashtable GetCentrosCosto()
                {
                    var ht = new Hashtable();
                    foreach (KeyValuePair<decimal, DetalleCentroCosto> item in this.centrosCosto)
                    {
                        if (item.Key != Definiciones.Error.Valor.EnteroPositivo)
                            ht.Add(item.Value.centroCostoId, Math.Abs(item.Value.monto / this.total) * 100);
                    }

                    return ht;
                }
            }

            public class DetalleCentroCosto
            {
                public decimal centroCostoId; // -1 es sinonimo de que no tiene centro de costo
                public decimal monto;

                public DetalleCentroCosto(decimal centro_costo_id)
                {
                    this.centroCostoId = centro_costo_id;
                    this.monto = 0;
                }

                public void Agregar(decimal monto, decimal centro_costo_id, decimal porcentaje)
                {
                    this.centroCostoId = (decimal)centro_costo_id;
                    this.monto = monto * porcentaje / 100;
                }
            }
            #endregion subclases

            public List<Cabecera> asientos;

            public AsientoGlobalDatos()
            {
                this.asientos = new List<Cabecera>();
            }
        }
        #endregion clase de configuracion para crear asiento global

        #region GetNumeroMaximo
        /// <summary>
        /// Gets the numero maximo.
        /// </summary>
        /// <param name="ctb_ejercicio_id">The ctb_ejercicio_id.</param>
        /// <returns></returns>
        public static decimal GetNumeroMaximo(decimal ctb_ejercicio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNumeroMaximo(ctb_ejercicio_id, sesion);
            }
        }

        public static decimal GetNumeroMaximo(decimal ctb_ejercicio_id, SessionService sesion)
        {
            string clausulas = "select nvl(max(" + AsientosService.Numero_NombreCol + "), 0) " + AsientosService.Numero_NombreCol +
                               "  from " + Nombre_Vista +
                               " where " + AsientosService.VistaCtbEjercicioId_NombreCol + " = " + ctb_ejercicio_id + " and " +
                                           AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

            DataTable dt = sesion.db.EjecutarQuery(clausulas);
            return (decimal)dt.Rows[0][AsientosService.Numero_NombreCol];
        }
        #endregion GetAsientosDataTable

        #region ExistePorCasoRelacionado
        public static bool ExistePorCasoRelacionado(decimal caso_id)
        {
            return ExistePorCasoRelacionado(caso_id, Definiciones.Error.Valor.EnteroPositivo, new SessionService());
        }

        public static bool ExistePorCasoRelacionado(decimal caso_id, decimal transicion_id)
        {
            return ExistePorCasoRelacionado(caso_id, transicion_id, new SessionService());
        }

        public static bool ExistePorCasoRelacionado(decimal caso_id, decimal transicion_id, SessionService sesion)
        {
            string clausulas = AsientosService.CasoRelacionadoId_NombreCol + " = " + caso_id + " and " +
                               AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            if (transicion_id != Definiciones.Error.Valor.EnteroPositivo)
                clausulas += " and " + AsientosService.TransicionId_NombreCol + " = " + transicion_id;
            
            DataTable dt = CBA.FlowV2.Services.Contabilidad.AsientosService.GetAsientosDataTable(clausulas, string.Empty, sesion);

            return dt.Rows.Count > 0;
        }
        #endregion ExistePorCasoRelacionado

        #region GetAsientoApertura
        public static AsientosService GetAsientoApertura(decimal ejercicio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAsientoApertura(ejercicio_id, sesion);
            }
        }

        public static AsientosService GetAsientoApertura(decimal ejercicio_id, SessionService sesion)
        {
            string sql = "select a." + AsientosService.Id_NombreCol +
                         "  from " + AsientosService.Nombre_Tabla + " a," +
                         "       " + PeriodosService.Nombre_Tabla + " p" +
                         " where a." + AsientosService.CtbPeriodoId_NombreCol + " = p." + PeriodosService.Id_NombreCol +
                         "   and p." + PeriodosService.EjercicioId_NombreCol + " = " + ejercicio_id +
                         "   and p." + PeriodosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                         "   and a." + AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                         "   and a." + AsientosService.EsApertura_NombreCol + " = '" + Definiciones.SiNo.Si + "'" +
                         "   and a." + AsientosService.EsGlobal_NombreCol + " = '" + Definiciones.SiNo.No + "'" +
                         " order by a." + AsientosService.FechaCreacion_NombreCol + " desc";

            DataTable dt = sesion.db.EjecutarQuery(sql);
            if (dt.Rows.Count > 0)
                return new AsientosService((decimal)dt.Rows[0][0], sesion);
            else
                return null;
        }
        #endregion GetAsientoApertura

        #region GetAsientoCierre
        public static AsientosService GetAsientoCierre(decimal ejercicio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAsientoCierre(ejercicio_id, sesion);
            }
        }

        public static AsientosService GetAsientoCierre(decimal ejercicio_id, SessionService sesion)
        {
            string sql = "select a." + AsientosService.Id_NombreCol +
                         "  from " + AsientosService.Nombre_Tabla + " a," +
                         "       " + PeriodosService.Nombre_Tabla + " p" +
                         " where a." + AsientosService.CtbPeriodoId_NombreCol + " = p." + PeriodosService.Id_NombreCol +
                         "   and p." + PeriodosService.EjercicioId_NombreCol + " = " + ejercicio_id +
                         "   and p." + PeriodosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                         "   and a." + AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                         "   and a." + AsientosService.EsCierre_NombreCol + " = '" + Definiciones.SiNo.Si + "'" +
                         "   and a." + AsientosService.EsGlobal_NombreCol + " = '" + Definiciones.SiNo.No + "'" +
                         " order by a." + AsientosService.FechaCreacion_NombreCol + " desc";

            DataTable dt = sesion.db.EjecutarQuery(sql);
            if (dt.Rows.Count > 0)
                return new AsientosService((decimal)dt.Rows[0][0], sesion);
            else
                return null;
        }
        #endregion GetAsientoCierre

        #region GetAsientoRegularizacion
        public static AsientosService[] GetAsientoRegularizacion(decimal ejercicio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAsientoRegularizacion(ejercicio_id, sesion);
            }
        }

        public static AsientosService[] GetAsientoRegularizacion(decimal ejercicio_id, SessionService sesion)
        {
            string sql = "select a." + AsientosService.Id_NombreCol +
                         "  from " + AsientosService.Nombre_Tabla + " a," +
                         "       " + PeriodosService.Nombre_Tabla + " p" +
                         " where a." + AsientosService.CtbPeriodoId_NombreCol + " = p." + PeriodosService.Id_NombreCol +
                         "   and p." + PeriodosService.EjercicioId_NombreCol + " = " + ejercicio_id +
                         "   and p." + PeriodosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                         "   and a." + AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                         "   and a." + AsientosService.EsRegularizacion_NombreCol + " = '" + Definiciones.SiNo.Si + "'" +
                         "   and a." + AsientosService.EsGlobal_NombreCol + " = '" + Definiciones.SiNo.No + "'" +
                         " order by a." + AsientosService.FechaCreacion_NombreCol + " desc";

            DataTable dt = sesion.db.EjecutarQuery(sql);
            var asientos = new AsientosService[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                asientos[i] = new AsientosService((decimal)dt.Rows[i][0], sesion);
            return asientos;
        }
        #endregion GetAsientoRegularizacion

        #region GetAsientosDataTable
        /// <summary>
        /// Gets the asientos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAsientosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAsientosDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetAsientosDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.CTB_ASIENTOSCollection.GetAsDataTable(where, orden);
        }
        #endregion GetAsientosDataTable

        #region GetAsientosInfoCompleta
        public static DataTable GetAsientosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAsientosInfoCompleta(clausulas, orden, sesion);
            }
        }

        /// <summary>
        /// Gets the asientos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAsientosInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            string where = AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas; 
            return sesion.Db.CTB_ASIENTOS_INFO_COMPLETACollection.GetAsDataTable(where, orden);
        }
        #endregion GetAsientosInfoCompleta

        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="asiento_id">The asiento_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal asiento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return EstaActivo(asiento_id, sesion);
            }
        }

        public static bool EstaActivo(decimal asiento_id, SessionService sesion)
        {
            CTB_ASIENTOSRow row = sesion.Db.CTB_ASIENTOSCollection.GetByPrimaryKey(asiento_id);
            return row.ESTADO == Definiciones.Estado.Activo;
        }
        #endregion EstaActivo

        #region ValidarPartidaDoble
        private static bool ValidarPartidaDoble(decimal ctb_asiento_id)
        {
            decimal total = 0;
            DataTable dtDetalles;
            string clausulas;

            clausulas = AsientosDetalleService.CtbAsientoId_NombreCol + " = " + ctb_asiento_id + " and " +
                        AsientosDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            dtDetalles = AsientosDetalleService.GetAsientosDetalleDataTable(clausulas, string.Empty);

            if (dtDetalles.Rows.Count <= 0)
                return false;

            for (int i = 0; i < dtDetalles.Rows.Count; i++)
            {
                if (!dtDetalles.Rows[i][AsientosDetalleService.Haber_NombreCol].Equals(DBNull.Value))
                    total += (decimal)dtDetalles.Rows[i][AsientosDetalleService.Haber_NombreCol];

                if (!dtDetalles.Rows[i][AsientosDetalleService.Debe_NombreCol].Equals(DBNull.Value))
                    total -= (decimal)dtDetalles.Rows[i][AsientosDetalleService.Debe_NombreCol];
            }

            total = Math.Round(total, MonedasService.CantidadDecimalesStatic((decimal)dtDetalles.Rows[0][AsientosDetalleService.MonedaId_NombreCol]));

            return total == 0;
        }
        #endregion ValidarPartidaDoble

        #region AprobarEnLote
        /// <summary>
        /// Aprobars the en lote.
        /// </summary>
        /// <param name="array_ctb_asiento_id">The array_ctb_asiento_id.</param>
        public static void AprobarEnLote(decimal[] array_ctb_asiento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    //Oracle permite hasta 1000 items dentro de una clausula in (...)
                    //por lo tanto se realiza la accion usando arrays de hasta 1000 items
                    int contador = 0, largo = 0;
                    decimal[] array;

                    while (contador < array_ctb_asiento_id.Length)
                    {
                        //Crear el array a donde se compiaran los IDs
                        if (array_ctb_asiento_id.Length - contador <= 1000)
                            largo = array_ctb_asiento_id.Length - contador;
                        else
                            largo = 1000;

                        array = new decimal[largo];

                        //Copiar el array
                        Array.Copy(array_ctb_asiento_id, contador, array, 0, largo);

                        //Aprobar subconjunto de asientos
                        AprobarEnLote(array, sesion);

                        //Avanzar el contador
                        contador += largo;

                    }

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }

        /// <summary>
        /// Aprobars the en lote.
        /// </summary>
        /// <param name="array_ctb_asiento_id">The array_ctb_asiento_id.</param>
        /// <param name="sesion">The sesion.</param>
        private static void AprobarEnLote(decimal[] array_ctb_asiento_id, SessionService sesion)
        {
            string indices = string.Empty;
            string valorAnterior;

            //Se crea un string de cada elemento separado por coma
            for (int i = 0; i < array_ctb_asiento_id.Length; i++)
            {
                if (i != 0) indices += ",";

                indices += array_ctb_asiento_id[i];
            }

            //Se obtienen los registros a modificar
            CTB_ASIENTOSRow[] rows = sesion.Db.CTB_ASIENTOSCollection.GetAsArray(AsientosService.Id_NombreCol + " in (" + indices + ")", string.Empty);

            //Validar que los asientos estan balanceados
            for (int i = 0; i < rows.Length; i++)
            {
                if (!AsientosService.ValidarPartidaDoble(rows[i].ID))
                    throw new Exception("El asiento Nº " + rows[i].NUMERO + " no está balanceado (partida doble).");
            }

            string nombreUsuario = UsuariosService.GetNombreCompleto2(sesion.Usuario.ID, sesion);

            //Modificar el campo y guardar
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].APROBADO == Definiciones.SiNo.No)
                {
                    valorAnterior = rows[i].ToString();

                    rows[i].APROBADO = Definiciones.SiNo.Si;
                    rows[i].FECHA_APROBACION = DateTime.Now;
                    rows[i].USUARIO_APROBACION_ID = sesion.Usuario.ID;

                    #region Modificacion de observacion sistema
                    if (rows[i].OBSERVACION_SISTEMA == null || rows[i].OBSERVACION_SISTEMA.Length <= 0)
                        rows[i].OBSERVACION_SISTEMA = string.Empty;
                    else
                        rows[i].OBSERVACION_SISTEMA += " ";
                    rows[i].OBSERVACION_SISTEMA += "Aprobado por " + nombreUsuario + " el " + rows[i].FECHA_APROBACION + ".";
                    #endregion Modificacion de observacion sistema

                    sesion.Db.CTB_ASIENTOSCollection.Update(rows[i]);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, rows[i].ToString(), sesion);
                }
            }
        }
        #endregion AprobarEnLote

        #region ActualizarAsientoGlobal
        public static void ActualizarAsientoGlobal(decimal ctb_asiento_id, decimal? ctb_asiento_globaliza_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    ActualizarAsientoGlobal(ctb_asiento_id, ctb_asiento_globaliza_id, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public static void ActualizarAsientoGlobal(decimal ctb_asiento_id, decimal? ctb_asiento_globaliza_id, SessionService sesion)
        {
            var row = sesion.db.CTB_ASIENTOSCollection.GetByPrimaryKey(ctb_asiento_id);
            if (ctb_asiento_globaliza_id.HasValue)
                row.CTB_ASIENTO_GLOBAL_ID = ctb_asiento_globaliza_id.Value;
            else
                row.IsCTB_ASIENTO_GLOBAL_IDNull = true;
            sesion.db.CTB_ASIENTOSCollection.Update(row);
        }
        #endregion ActualizarAsientoGlobal

        #region Guardar
        public static decimal Guardar(Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                return Guardar(campos, insertarNuevo, sesion);
            }
        }

        public static decimal Guardar(Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                CTB_ASIENTOSRow row;
                DataTable dtPeriodo;
                string valorAnterior = string.Empty;
                bool cambiaFecha = false, cambiaAprobado = false;
                DateTime fechaDesde, fechaHasta, fechaAux;
                decimal ejercicioId = PeriodosService.GetEjercicio((decimal)campos[AsientosService.CtbPeriodoId_NombreCol], sesion);

                if (!EjerciciosService.EstaAbierto(ejercicioId, sesion))
                    throw new Exception("El ejercicio no se encuentra abierto.");

                if (insertarNuevo)
                {
                    if (campos.ContainsKey(EsGlobal_NombreCol) && (string)campos[AsientosService.EsGlobal_NombreCol] == Definiciones.SiNo.Si)
                    {
                        if (!RolesService.Tiene("CTB ASIENTOS GLOBALES CREAR"))
                            throw new Exception("No tiene permisos para crear un asiento global.");
                    }

                    row = new CTB_ASIENTOSRow();
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("ctb_asientos_sqc");

                    row.FECHA_CREACION = DateTime.Now;
                    row.USUARIO_CREACION_ID = sesion.Usuario_Id;
                    row.ESTADO = Definiciones.Estado.Activo;
                    row.APROBADO = Definiciones.SiNo.No;
                    row.ES_APERTURA = Definiciones.SiNo.No;
                    row.ES_REGULARIZACION = Definiciones.SiNo.No;
                    row.ES_CIERRE = Definiciones.SiNo.No;
                    row.ES_GLOBAL = Definiciones.SiNo.No;

                    //El numero del asiento es uno mas el asiento con mayor numero dentro del ejercicio
                    row.NUMERO = 1 + AsientosService.GetNumeroMaximo(ejercicioId, sesion);
                }
                else
                {
                    row = sesion.Db.CTB_ASIENTOSCollection.GetByPrimaryKey((decimal)campos[AsientosService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                //Si el usuario aprueba el asiento
                if (row.APROBADO.Equals(Definiciones.SiNo.No) && (string)campos[AsientosService.Aprobado_NombreCol] == Definiciones.SiNo.Si)
                {
                    //Validar que los detalles cumplen con la partida doble
                    if (!AsientosService.ValidarPartidaDoble(row.ID))
                        throw new Exception("Los detalles no están balanceados (partida doble).");

                    row.APROBADO = Definiciones.SiNo.Si;
                    row.FECHA_APROBACION = DateTime.Now;
                    row.USUARIO_APROBACION_ID = sesion.Usuario.ID;

                    cambiaAprobado = true;
                }

                row.AUTOMATICO = (string)campos[AsientosService.Automatico_NombreCol];

                if (campos.Contains(AsientosService.EsApertura_NombreCol))
                    row.ES_APERTURA = (string)campos[AsientosService.EsApertura_NombreCol];
                if (campos.Contains(AsientosService.EsRegularizacion_NombreCol))
                    row.ES_REGULARIZACION = (string)campos[AsientosService.EsRegularizacion_NombreCol];
                if (campos.Contains(AsientosService.EsCierre_NombreCol))
                    row.ES_CIERRE = (string)campos[AsientosService.EsCierre_NombreCol];
                
                int controlTipo = 0;
                if (row.ES_APERTURA == Definiciones.SiNo.Si) controlTipo++;
                if (row.ES_REGULARIZACION == Definiciones.SiNo.Si) controlTipo++;
                if (row.ES_CIERRE == Definiciones.SiNo.Si) controlTipo++;
                if (controlTipo > 1)
                    throw new Exception("El asiento puede tomar sólo un tipo entre Apertura, Regularización y Cierre.");

                if (campos.Contains(AsientosService.EsGlobal_NombreCol))
                    row.ES_GLOBAL = (string)campos[AsientosService.EsGlobal_NombreCol];

                row.SUCURSAL_ID = (decimal)campos[AsientosService.SucursalId_NombreCol];

                if (campos.Contains(AsientosService.TransicionId_NombreCol))
                    row.TRANSICION_ID = (decimal)campos[AsientosService.TransicionId_NombreCol];

                if (!insertarNuevo && !row.FECHA_ASIENTO.Equals((DateTime)campos[AsientosService.FechaAsiento_NombreCol]))
                    cambiaFecha = true;

                row.FECHA_ASIENTO = (DateTime)campos[AsientosService.FechaAsiento_NombreCol];
                row.REVISION_POSTERIOR = (string)campos[AsientosService.RevisionPosterior_NombreCol];

                row.CTB_PERIODO_ID = (decimal)campos[AsientosService.CtbPeriodoId_NombreCol];

                //Verificar que el preiodo esta vigente o vigente por margen permitido
                if (!PeriodosService.EstaVigenteOConMargen(row.FECHA_ASIENTO, row.CTB_PERIODO_ID, sesion))
                    throw new Exception("El período no está vigente.");

                //Controla que la fecha se encuentre dentro del periodo
                dtPeriodo = PeriodosService.GetPeriodosDataTable(PeriodosService.Id_NombreCol + " = " + row.CTB_PERIODO_ID, string.Empty);

                fechaAux = (DateTime)dtPeriodo.Rows[0][PeriodosService.FechaInicio_NombreCol];
                fechaDesde = new DateTime(fechaAux.Year, fechaAux.Month, fechaAux.Day);
                fechaAux = (DateTime)dtPeriodo.Rows[0][PeriodosService.FechaFin_NombreCol];
                fechaHasta = new DateTime(fechaAux.Year, fechaAux.Month, fechaAux.Day);
                fechaHasta = fechaHasta.AddDays(1);

                //Si el asiento se relaciona a un caso
                //No puede desvincularse un caso ya asociado
                if (campos.Contains(AsientosService.CasoRelacionadoId_NombreCol))
                    row.CASO_RELACIONADO_ID = (decimal)campos[AsientosService.CasoRelacionadoId_NombreCol];

                //Si el asiento se relaciona a una tabla y registro
                //No puede desvincularse un registro ya asociado
                if (campos.Contains(AsientosService.RegistroRelacionadoId_NombreCol))
                {
                    row.REGISTRO_RELACIONADO_ID = (decimal)campos[AsientosService.RegistroRelacionadoId_NombreCol];
                    row.TABLA_RELACIONADA_ID = (string)campos[AsientosService.TablaRelacionadaId_NombreCol];
                }

                if (campos[AsientosService.Observacion_NombreCol].Equals(string.Empty))
                    throw new Exception("La cabecera del Asiento no puede guardarse sin una observación.");
                else
                    row.OBSERVACION = (string)campos[AsientosService.Observacion_NombreCol];


                #region Modificacion de observacion sistema
                if (!insertarNuevo)
                {
                    if (row.OBSERVACION_SISTEMA == null || row.OBSERVACION_SISTEMA.Length <= 0)
                        row.OBSERVACION_SISTEMA = string.Empty;
                    else
                        row.OBSERVACION_SISTEMA += " ";

                    string nombreUsuario = UsuariosService.GetNombreCompleto2(sesion.Usuario.ID, sesion);
                    bool usarEspacio = false;

                    if (cambiaAprobado)
                    {
                        if (usarEspacio) row.OBSERVACION_SISTEMA += " ";
                        row.OBSERVACION_SISTEMA += "Aprobado por " + nombreUsuario + " el " + row.FECHA_APROBACION + ".";
                        usarEspacio = true;
                    }
                    if (cambiaFecha)
                    {
                        if (usarEspacio) row.OBSERVACION_SISTEMA += " ";
                        row.OBSERVACION_SISTEMA += "Fecha cambiada por " + nombreUsuario + ".";
                        usarEspacio = true;
                    }
                }
                #endregion Modificacion de observacion sistema

                //Avanzar en el numero de asiento hasta que permita guardar
                //Si la excepcion no es por numero duplicado lanza nuevamente la excepcion saliendo del loop
                while (true)
                {
                    try
                    {
                        if (insertarNuevo) sesion.Db.CTB_ASIENTOSCollection.Insert(row);
                        else sesion.Db.CTB_ASIENTOSCollection.Update(row);
                        break;
                    }
                    catch (OracleException exp)
                    {
                        if (exp.Number != Definiciones.OracleNumeroExcepcion.CONTABILIDAD_NUMERO_DUPLICADO)
                            throw exp;
                        else
                            row.NUMERO += 1; //Aumentar el numero para que dos asientos no tengan el mismo numero
                    }
                }

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                return row.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Guardar

        #region GetObservacion
        /// <summary>
        /// Gets the observacion.
        /// </summary>
        /// <param name="ctb_asiento_automatico_id">The ctb_asiento_automatico_id.</param>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="comprobante">The comprobante.</param>
        /// <param name="persona">The persona.</param>
        /// <param name="proveedor">The proveedor.</param>
        /// <param name="texto_adicional">The texto_adicional.</param>
        /// <param name="observacion_caso">The observacion_caso.</param>
        /// <returns></returns>
        public static string GetObservacion(int ctb_asiento_automatico_id, CasosService caso, string observacion_caso, SessionService sesion)
        {
            if (AsientosAutomaticosService.GetCopiarObservacionCaso(ctb_asiento_automatico_id, sesion) && !observacion_caso.Equals(string.Empty))
            {
                return observacion_caso;
            }
            else
            {
                StringBuilder observacion = new StringBuilder();

                if (caso.PersonaId.HasValue)
                {
                    observacion.Append(caso.Persona.NombreCompleto).Append(" - ");
                }
                else
                {
                    if (caso.ProveedorId.HasValue)
                        observacion.Append(caso.Proveedor.RazonSocial).Append(" - ");
                }
                observacion.Append(caso.Flujo.DescripcionImpresion).Append(" - ");
                observacion.Append("caso: " + caso.Id.Value);

                if (caso.NroComprobante.Length > 0)
                    observacion.Append(" (" + caso.NroComprobante + ")");

                return observacion.ToString();
            }
        }
        #endregion GetObservacion

        #region BorrarPorTablaYRegistro
        public static void BorrarPorTablaYRegistro(string tabla_id, decimal registro_id, SessionService sesion)
        {
            string clausulas = AsientosService.TablaRelacionadaId_NombreCol + " = '" + tabla_id + "' and " +
                               AsientosService.RegistroRelacionadoId_NombreCol + " = " + registro_id + " and " +
                               AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            DataTable dtAsientos = AsientosService.GetAsientosDataTable(clausulas, string.Empty, sesion);

            for (int i = 0; i < dtAsientos.Rows.Count; i++)
                AsientosService.Borrar((decimal)dtAsientos.Rows[i][AsientosService.Id_NombreCol], sesion);
        }
        #endregion BorrarPorTablaYRegistro

        #region BorrarPorCasoYTransicion
        public static void BorrarPorCasoYTransicion(decimal caso_id, decimal transicion_id, SessionService sesion)
        {
            string clausulas = AsientosService.CasoRelacionadoId_NombreCol + " = " + caso_id + " and " +
                               AsientosService.TransicionId_NombreCol + " = " + transicion_id + " and " +
                               AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            DataTable dtAsientos = AsientosService.GetAsientosDataTable(clausulas, string.Empty, sesion);

            for (int i = 0; i < dtAsientos.Rows.Count; i++)
                AsientosService.Borrar((decimal)dtAsientos.Rows[i][AsientosService.Id_NombreCol], sesion);
        }
        #endregion BorrarPorCasoYTransicion

        #region Borrar
        public static void Borrar(decimal asiento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                AsientosService.Borrar(asiento_id, sesion);
            }
        }

        public static void Borrar(decimal asiento_id, SessionService sesion)
        {
            try
            {
                CTB_ASIENTOSRow row = sesion.Db.CTB_ASIENTOSCollection.GetByPrimaryKey(asiento_id);
                DataTable dtDetalles;

                if (row.ES_GLOBAL == Definiciones.SiNo.Si)
                {
                    if (!RolesService.Tiene("CTB ASIENTOS GLOBALES BORRAR"))
                        throw new Exception("No tiene permisos para borrar un asiento global.");
                    BorrarAsientoGlobal(asiento_id, sesion);
                }

                row.ESTADO = Definiciones.Estado.Inactivo;
                row.FECHA_INACTIVACION = DateTime.Now;
                row.USUARIO_INACTIVACION_ID = sesion.Usuario.ID;

                #region Modificacion de observacion sistema
                if (row.OBSERVACION_SISTEMA == null || row.OBSERVACION_SISTEMA.Length <= 0)
                    row.OBSERVACION_SISTEMA = string.Empty;
                else
                    row.OBSERVACION_SISTEMA += " ";

                string nombreUsuario = UsuariosService.GetNombreCompleto2(row.USUARIO_INACTIVACION_ID, sesion);
                row.OBSERVACION_SISTEMA += "Borrado por " + nombreUsuario + " el " + row.FECHA_INACTIVACION + ".";
                #endregion Modificacion de observacion sistema

                //Inactivar los detalles
                dtDetalles = AsientosDetalleService.GetAsientosDetalleDataTable(AsientosDetalleService.CtbAsientoId_NombreCol + " = " + asiento_id, string.Empty, sesion);
                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                    AsientosDetalleService.Borrar((decimal)dtDetalles.Rows[i][AsientosDetalleService.Id_NombreCol], sesion);

                sesion.Db.CTB_ASIENTOSCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static void BorrarPorLote(decimal[] asiento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                AsientosService.BorrarPorLote(asiento_id, sesion);
            } 
        }

        public static void BorrarPorLote(decimal[] asiento_id, SessionService sesion)
        {
            for (int i = 0; i < asiento_id.Length; i++)
            {
                AsientosService.Borrar(asiento_id[i], sesion);
            }
        }
        #endregion borrar

        #region ModificarFecha
        /// <summary>
        /// Modificars the fecha por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="fecha_nueva">The fecha_nueva.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ModificarFechaPorCaso(decimal caso_id, DateTime fecha_nueva, SessionService sesion)
        {
            CTB_ASIENTOSRow[] rows = sesion.db.CTB_ASIENTOSCollection.GetByCASO_RELACIONADO_ID(caso_id);
            string valorAnterior;

            for (int i = 0; i < rows.Length; i++)
            {
                valorAnterior = rows[i].ToString();
                rows[i].FECHA_ASIENTO = fecha_nueva;
                sesion.db.CTB_ASIENTOSCollection.Update(rows[i]);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[i].ID, valorAnterior, rows[i].ToString(), sesion);
            }
        }
        #endregion ModificarFecha

        #region RegenerarNumeracion
        /// <summary>
        /// Regenerars the numeracion.
        /// </summary>
        /// <param name="ctb_ejercicio_id">The ctb_ejercicio_id.</param>
        public static void  RegenerarNumeracion(decimal ctb_ejercicio_id)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    DataTable dtPeriodos;
                    CTB_ASIENTOSRow[] rows;
                    string clausulas;

                    if (!EjerciciosService.EstaAbierto(ctb_ejercicio_id))
                        throw new Exception("El ejercicio no se encuentra abierto.");

                    dtPeriodos = PeriodosService.GetPeriodosDataTable(PeriodosService.EjercicioId_NombreCol + " = " + ctb_ejercicio_id, string.Empty);

                    clausulas = AsientosService.CtbPeriodoId_NombreCol + " in ( -1";
                    for (int i = 0; i < dtPeriodos.Rows.Count; i++)
                        clausulas += ", " + dtPeriodos.Rows[i][PeriodosService.Id_NombreCol];
                    clausulas += ") and " +
                                 AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                    rows = sesion.db.CTB_ASIENTOSCollection.GetAsArray(clausulas, AsientosService.FechaAsiento_NombreCol);

                    for (int i = 0; i < rows.Length; i++)
                    {
                        rows[i].NUMERO = i + 1;
                        sesion.db.CTB_ASIENTOSCollection.Update(rows[i]);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion RegenerarNumeracion

        #region SetCasoRelacionado
        public static void SetCasoRelacionadoNull(decimal asientoId, bool setNull, SessionService sesion)
        {
            try
            {
                string valorAnterior = string.Empty;
                CTB_ASIENTOSRow asiento = sesion.Db.CTB_ASIENTOSCollection.GetByPrimaryKey(asientoId);
                valorAnterior = asiento.ToString();
                asiento.IsCASO_RELACIONADO_IDNull = true;
                sesion.Db.CTB_ASIENTOSCollection.Update(asiento);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, asiento.ID, valorAnterior, asiento.ToString(), sesion);
            }
            catch (Exception exp)
            {
                sesion.Db.RollbackTransaction();
                throw exp;
            }
        }
        #endregion setCasoRelacionado

        #region CrearAsientosGlobales
        public static AsientosService[] CrearAsientosGlobales(AsientoGlobalConfiguracion configuracion, string filtro_observacion)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();


                    if (!RolesService.Tiene("CTB ASIENTOS GLOBALES CREAR"))
                        throw new Exception("No tiene permisos para crear asientos globales.");

                    var dtEjercicio = EjerciciosService.GetEjerciciosDataTable(EjerciciosService.Id_NombreCol + " = " + configuracion.ctbEjercicioId, string.Empty, sesion);
                    var paisEjercicio = new PaisesService((decimal)dtEjercicio.Rows[0][EjerciciosService.PaisId_NombreCol], sesion);
                    
                    #region creacion del sql
                    string sql =
                        "select ca." + AsientosService.Id_NombreCol + ", " +
                        "       ca." + AsientosService.CtbPeriodoId_NombreCol + ", ";
                    if(configuracion.regionId.HasValue)
                        sql += " s." + SucursalesService.RegionId_NombreCol + ", ";
                    if (configuracion.sucursalId.HasValue || configuracion.sucursalesIndividuales)
                        sql += " ca." + AsientosService.SucursalId_NombreCol + ", ";
                    sql +=
                        "       ca." + AsientosService.EsApertura_NombreCol + ", " +
                        "       ca." + AsientosService.EsRegularizacion_NombreCol + ", " +
                        "       ca." + AsientosService.EsCierre_NombreCol + ", " +
                        "       ca." + AsientosService.FechaAsiento_NombreCol + ", " +
                        "       cad." + AsientosDetalleService.CtbCuentaId_NombreCol + ", " +
                        "       sum(cad." + AsientosDetalleService.Debe_NombreCol + ") " + AsientosDetalleService.Debe_NombreCol + ", " +
                        "       sum(cad." + AsientosDetalleService.Haber_NombreCol + ") " + AsientosDetalleService.Haber_NombreCol + ", " +
                        "       max(cad." + AsientosDetalleService.CotizacionMoneda_NombreCol + ") " + AsientosDetalleService.CotizacionMoneda_NombreCol + ", " +
                        "       cadcc." + AsientosDetalleCentrosCostoService.CentroCostoId_NombreCol + ", " +
                        "       cadcc." + AsientosDetalleCentrosCostoService.Porcentaje_NombreCol +
                        "  from " + AsientosService.Nombre_Tabla + " ca, " +
                        "       " + AsientosDetalleService.Nombre_Tabla + " cad, " +
                        "       " + AsientosDetalleCentrosCostoService.Nombre_Tabla + " cadcc, " +
                        "       " + SucursalesService.Nombre_Tabla + " s " +
                        " where cad." + AsientosDetalleService.CtbAsientoId_NombreCol + " = ca." + AsientosService.Id_NombreCol +
                        "   and ca." + AsientosService.SucursalId_NombreCol + " = s." + SucursalesService.Id_NombreCol +
                        "   and cad." + AsientosDetalleService.Id_NombreCol + " = cadcc." + AsientosDetalleCentrosCostoService.CtbAsientoDetalleId_NombreCol + "(+) " +
                        "   and ca." + AsientosService.EsGlobal_NombreCol + " = '" + Definiciones.SiNo.No + "' " +
                        "   and trunc(ca." + AsientosService.FechaAsiento_NombreCol + ") >= to_date('" + configuracion.fechaDesde.ToShortDateString() + "', 'dd/mm/yyyy') " +
                        "   and trunc(ca." + AsientosService.FechaAsiento_NombreCol + ") <= to_date('" + configuracion.fechaHasta.ToShortDateString() + "', 'dd/mm/yyyy') ";
                    if (configuracion.regionId.HasValue)
                        sql += " and s." + SucursalesService.RegionId_NombreCol + " = " + configuracion.regionId.Value;
                    if (configuracion.sucursalId.HasValue)
                        sql += " and ca." + AsientosService.SucursalId_NombreCol + " = " + configuracion.sucursalId.Value;
                    if (filtro_observacion.Length > 0)
                        sql += " and upper(ca." + AsientosService.Observacion_NombreCol + ") like ('%" + filtro_observacion.ToUpper() + "%' ";
                    sql += 
                        "   and ca." + AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                        "   and cad." + AsientosDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                        " group by ca." + AsientosService.Id_NombreCol + ", " +
                        "       ca." + AsientosService.CtbPeriodoId_NombreCol + ", ";
                    if(configuracion.regionId.HasValue)
                        sql += " s." + SucursalesService.RegionId_NombreCol + ", ";
                    if (configuracion.sucursalId.HasValue || configuracion.sucursalesIndividuales)
                        sql += " ca." + AsientosService.SucursalId_NombreCol + ", ";
                    sql +=
                        "       ca." + AsientosService.EsApertura_NombreCol + ", " +
                        "       ca." + AsientosService.EsRegularizacion_NombreCol + ", " +
                        "       ca." + AsientosService.EsCierre_NombreCol + ", " +
                        "       ca." + AsientosService.FechaAsiento_NombreCol + ", " +
                        "       cad." + AsientosDetalleService.CtbCuentaId_NombreCol + ", " +
                        "       cadcc." + AsientosDetalleCentrosCostoService.CentroCostoId_NombreCol + ", " +
                        "       cadcc." + AsientosDetalleCentrosCostoService.Porcentaje_NombreCol +
                        " order by ca." + AsientosService.CtbPeriodoId_NombreCol + ", ";
                    if (configuracion.regionId.HasValue)
                        sql += " s." + SucursalesService.RegionId_NombreCol + ", ";
                    if (configuracion.sucursalId.HasValue || configuracion.sucursalesIndividuales)
                        sql += " ca." + AsientosService.SucursalId_NombreCol + ", ";
                    sql +=
                        "       ca." + AsientosService.EsApertura_NombreCol + ", " +
                        "       ca." + AsientosService.EsRegularizacion_NombreCol + ", " +
                        "       ca." + AsientosService.EsCierre_NombreCol;
                    #endregion creacion del sql

                    var dt = sesion.db.EjecutarQuery(sql);
                    AsientoGlobalDatos agd = new AsientoGlobalDatos();
                    AsientoGlobalDatos.Cabecera cabecera = null;
                    
                    SucursalesService sucursal = null;
                    RegionesService region = null;

                    #region inicializar sucursal y región según los filtros utilizados
                    if (configuracion.sucursalId.HasValue)
                    {
                        sucursal = new SucursalesService(configuracion.sucursalId.Value, sesion);
                        region = sucursal.Region;
                    }
                    else if (configuracion.regionId.HasValue)
                    {
                        region = new RegionesService(configuracion.regionId.Value, sesion);
                        sucursal = region.SucursalCasaMatriz;
                    }
                    else if(!Interprete.EsNullODBNull(dtEjercicio.Rows[0][EjerciciosService.RegionId_NombreCol]))
                    {
                        region = new RegionesService((decimal)dtEjercicio.Rows[0][EjerciciosService.RegionId_NombreCol], sesion);
                        sucursal = region.SucursalCasaMatriz;
                    }
                    else if (!Interprete.EsNullODBNull(dtEjercicio.Rows[0][EjerciciosService.SucursalId_NombreCol]))
                    {
                        sucursal = new SucursalesService((decimal)dtEjercicio.Rows[0][EjerciciosService.SucursalId_NombreCol], sesion);
                        region = sucursal.Region;
                    }
                    else
                    {
                        sucursal = new SucursalesService(sesion.SucursalActiva_Id, sesion).Region.SucursalCasaMatriz;
                        region = sucursal.Region;
                    }
                    #endregion inicializar sucursal y región según los filtros utilizados

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Si cambia alguno de los campos, debe crearse un asiento nuevo
                        if (cabecera == null ||
                            cabecera.periodoId != (decimal)dt.Rows[i][AsientosService.CtbPeriodoId_NombreCol] ||
                            configuracion.regionId.HasValue && region.Id.Value != (decimal)dt.Rows[i][SucursalesService.RegionId_NombreCol] ||
                            (configuracion.sucursalId.HasValue || configuracion.sucursalesIndividuales) && sucursal.Id.Value != (decimal)dt.Rows[i][AsientosService.SucursalId_NombreCol] ||
                            cabecera.esApertura != (string)dt.Rows[i][AsientosService.EsApertura_NombreCol] ||
                            cabecera.esRegularizacion != (string)dt.Rows[i][AsientosService.EsRegularizacion_NombreCol] ||
                            cabecera.esCierre != (string)dt.Rows[i][AsientosService.EsCierre_NombreCol]
                           )
                        {
                            //Si cambia la sucural, asignar los nuevos datos
                            if (configuracion.sucursalId.HasValue || configuracion.sucursalesIndividuales)
                            {
                                if (sucursal.Id.Value != (decimal)dt.Rows[i][AsientosService.SucursalId_NombreCol])
                                {
                                    sucursal = new SucursalesService((decimal)dt.Rows[i][AsientosService.SucursalId_NombreCol], sesion);
                                    region = sucursal.Region;
                                }
                            }
                            else if (configuracion.regionId.HasValue)
                            {
                                if (region.Id.Value != (decimal)dt.Rows[i][SucursalesService.RegionId_NombreCol])
                                {
                                    region = new RegionesService(configuracion.regionId.Value, sesion);
                                    sucursal = region.SucursalCasaMatriz;
                                }
                            }

                            cabecera = new AsientoGlobalDatos.Cabecera()
                            {
                                periodoId = (decimal)dt.Rows[i][AsientosService.CtbPeriodoId_NombreCol],
                                esApertura = (string)dt.Rows[i][AsientosService.EsApertura_NombreCol],
                                esRegularizacion = (string)dt.Rows[i][AsientosService.EsRegularizacion_NombreCol],
                                esCierre = (string)dt.Rows[i][AsientosService.EsCierre_NombreCol],
                                fecha = (DateTime)dt.Rows[i][AsientosService.FechaAsiento_NombreCol],
                                observacion = configuracion.observacion,
                                sucursalId = sucursal.Id.Value,
                                monedaId = paisEjercicio.MonedaId,
                                cotizacion = (decimal)dt.Rows[i][AsientosDetalleService.CotizacionMoneda_NombreCol],
                            };
                            
                            agd.asientos.Add(cabecera);
                        }

                        cabecera.Agregar((decimal)dt.Rows[i][AsientosDetalleService.Id_NombreCol],
                                         (decimal)dt.Rows[i][AsientosDetalleService.CtbCuentaId_NombreCol],
                                         (decimal)dt.Rows[i][AsientosDetalleService.Debe_NombreCol],
                                         (decimal)dt.Rows[i][AsientosDetalleService.Haber_NombreCol],
                                         dt.Rows[i][AsientosDetalleCentrosCostoService.CentroCostoId_NombreCol],
                                         dt.Rows[i][AsientosDetalleCentrosCostoService.Porcentaje_NombreCol]
                                         );
                    }
                    
                    var lAsientos = new List<AsientosService>();
                    #region crear asientos, detalles y desglose por centro de costo
                    foreach (var a in agd.asientos)
                    {
                        decimal cabeceraId = AsientosService.Guardar(a.GetHashTable(), true);
                        lAsientos.Add(new AsientosService(cabeceraId, sesion));

                        foreach (var d in a.GetDetalles())
                        {
                            var ht = d.GetHashTable();
                            ht.Add(AsientosDetalleService.CtbAsientoId_NombreCol, cabeceraId);
                            AsientosDetalleService.Guardar(ht, d.GetCentrosCosto(), true, sesion);
                        }

                        foreach (var asientoOrigenId in a.asientosOrigen)
                            AsientosService.ActualizarAsientoGlobal(asientoOrigenId, cabeceraId, sesion);
                    }
                    #endregion crear asientos, detalles y desglose por centro de costo

                    sesion.CommitTransaction();
                    return lAsientos.ToArray();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion CrearAsientosGlobales

        #region BorrarAsientoGlobal
        public static void BorrarAsientoGlobal(decimal ctb_asiento_id, SessionService sesion)
        {
            if (!RolesService.Tiene("CTB ASIENTOS GLOBALES BORRAR"))
                throw new Exception("No tiene permisos para borrar asientos globales.");

            string clausulas = AsientosService.CtbAsientoGlobalId_NombreCol + " = " + ctb_asiento_id + " and " +
                              AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            var rows = sesion.db.CTB_ASIENTOSCollection.GetAsArray(clausulas, string.Empty);
            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].IsCTB_ASIENTO_GLOBAL_IDNull = true;
                sesion.db.CTB_ASIENTOSCollection.Update(rows[i]);
            }
        }
        #endregion BorrarAsientoGlobal

        #region CrearAsientoApertura
        public static AsientosService CrearAsientoApertura(decimal ctb_ejercicio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    var dtEjercicio = EjerciciosService.GetEjerciciosDataTable(EjerciciosService.Id_NombreCol + " = " + ctb_ejercicio_id, string.Empty, sesion);
                    if (Interprete.EsNullODBNull(dtEjercicio.Rows[0][EjerciciosService.EjercicioAnteriorId_NombreCol]))
                        throw new Exception("El ejercicio no tiene un ejercicio anterior definido.");

                    var asientoCierre = AsientosService.GetAsientoCierre((decimal)dtEjercicio.Rows[0][EjerciciosService.EjercicioAnteriorId_NombreCol], sesion);
                    if (asientoCierre == null)
                        throw new Exception("El ejercicio anterior no tiene un asiento de cierre.");

                    var dtPeriodos = PeriodosService.GetPeriodosDataTable(PeriodosService.EjercicioId_NombreCol + " = " + ctb_ejercicio_id, PeriodosService.FechaInicio_NombreCol, sesion);
                    string observacion = "Asiento de apertura";

                    var htCabecera = new Hashtable()
                    {
                        { AsientosService.CtbPeriodoId_NombreCol, dtPeriodos.Rows[0][PeriodosService.Id_NombreCol]},
                        { AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No },
                        { AsientosService.Automatico_NombreCol, Definiciones.SiNo.No},
                        { AsientosService.EsApertura_NombreCol, Definiciones.SiNo.Si },
                        { AsientosService.EsRegularizacion_NombreCol, Definiciones.SiNo.No },
                        { AsientosService.EsCierre_NombreCol, Definiciones.SiNo.No },
                        { AsientosService.EsGlobal_NombreCol, Definiciones.SiNo.No },
                        { AsientosService.FechaAsiento_NombreCol, dtPeriodos.Rows[0][PeriodosService.FechaInicio_NombreCol] },
                        { AsientosService.Observacion_NombreCol, observacion },
                        { AsientosService.RevisionPosterior_NombreCol, Definiciones.SiNo.No },
                        { AsientosService.SucursalId_NombreCol, asientoCierre.SucursalId },
                    };
                    var asientoId = AsientosService.Guardar(htCabecera, true, sesion);

                    var dtAsientoCierreDet = AsientosDetalleService.GetAsientosDetalleDataTable(AsientosDetalleService.CtbAsientoId_NombreCol + " = " + asientoCierre.Id.Value, AsientosDetalleService.Orden_NombreCol, sesion);
                    for (int i = 0; i < dtAsientoCierreDet.Rows.Count; i++)
                    {
                        var htDetalle = new Hashtable()
                        {   
                            { AsientosDetalleService.CtbAsientoId_NombreCol, asientoId },
                            { AsientosDetalleService.CtbCuentaId_NombreCol, dtAsientoCierreDet.Rows[i][AsientosDetalleService.CtbCuentaId_NombreCol] },
                            { AsientosDetalleService.Debe_NombreCol, dtAsientoCierreDet.Rows[i][AsientosDetalleService.Debe_NombreCol] },
                            { AsientosDetalleService.Haber_NombreCol, dtAsientoCierreDet.Rows[i][AsientosDetalleService.Haber_NombreCol] },
                            { AsientosDetalleService.MonedaId_NombreCol, dtAsientoCierreDet.Rows[i][AsientosDetalleService.MonedaId_NombreCol] },
                            { AsientosDetalleService.CotizacionMoneda_NombreCol, dtAsientoCierreDet.Rows[i][AsientosDetalleService.CotizacionMoneda_NombreCol] },
                            { AsientosDetalleService.DebeOrigen_NombreCol, dtAsientoCierreDet.Rows[i][AsientosDetalleService.HaberOrigen_NombreCol] },
                            { AsientosDetalleService.HaberOrigen_NombreCol, dtAsientoCierreDet.Rows[i][AsientosDetalleService.DebeOrigen_NombreCol] },
                            { AsientosDetalleService.MonedaOrigenId_NombreCol, dtAsientoCierreDet.Rows[i][AsientosDetalleService.MonedaOrigenId_NombreCol] },
                            { AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, dtAsientoCierreDet.Rows[i][AsientosDetalleService.CotizacionMonedaOrigen_NombreCol] },
                            { AsientosDetalleService.Observacion_NombreCol, observacion },
                        };

                        var dtAsientoCierreDetCC = AsientosDetalleCentrosCostoService.GetAsientosDetalleCentrosCostoDataTable(AsientosDetalleCentrosCostoService.CtbAsientoDetalleId_NombreCol + " = " + dtAsientoCierreDet.Rows[i][AsientosDetalleService.Id_NombreCol], AsientosDetalleCentrosCostoService.Id_NombreCol, sesion);
                        var htCentroCosto = new Hashtable();
                        for (int j = 0; j < dtAsientoCierreDetCC.Rows.Count; j++)
                            htCentroCosto.Add(dtAsientoCierreDetCC.Rows[j][AsientosDetalleCentrosCostoService.CentroCostoId_NombreCol], dtAsientoCierreDetCC.Rows[j][AsientosDetalleCentrosCostoService.Porcentaje_NombreCol]);

                        AsientosDetalleService.Guardar(htDetalle, htCentroCosto, true, sesion);
                    }

                    var asientoApertura = new AsientosService(asientoId, sesion);
                    sesion.CommitTransaction();

                    return asientoApertura;
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion CrearAsientoApertura

        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "CTB_ASIENTOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "CTB_ASIENTOS_INFO_COMPLETA"; }
        }
        public static string Aprobado_NombreCol
        {
            get { return CTB_ASIENTOSCollection.APROBADOColumnName; }
        }
        public static string Automatico_NombreCol
        {
            get { return CTB_ASIENTOSCollection.AUTOMATICOColumnName; }
        }
        public static string CasoRelacionadoId_NombreCol
        {
            get { return CTB_ASIENTOSCollection.CASO_RELACIONADO_IDColumnName; }
        }
        public static string CtbAsientoGlobalId_NombreCol
        {
            get { return CTB_ASIENTOSCollection.CTB_ASIENTO_GLOBAL_IDColumnName; }
        }
        public static string CtbPeriodoId_NombreCol
        {
            get { return CTB_ASIENTOSCollection.CTB_PERIODO_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTB_ASIENTOSCollection.ESTADOColumnName; }
        }
        public static string EsApertura_NombreCol
        {
            get { return CTB_ASIENTOSCollection.ES_APERTURAColumnName; }
        }
        public static string EsCierre_NombreCol
        {
            get { return CTB_ASIENTOSCollection.ES_CIERREColumnName; }
        }
        public static string EsGlobal_NombreCol
        {
            get { return CTB_ASIENTOSCollection.ES_GLOBALColumnName; }
        }
        public static string EsRegularizacion_NombreCol
        {
            get { return CTB_ASIENTOSCollection.ES_REGULARIZACIONColumnName; }
        }
        public static string FechaAprobacion_NombreCol
        {
            get { return CTB_ASIENTOSCollection.FECHA_APROBACIONColumnName; }
        }
        public static string FechaAsiento_NombreCol
        {
            get { return CTB_ASIENTOSCollection.FECHA_ASIENTOColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return CTB_ASIENTOSCollection.FECHA_CREACIONColumnName; }
        }
        public static string FechaInactivacion_NombreCol
        {
            get { return CTB_ASIENTOSCollection.FECHA_INACTIVACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTB_ASIENTOSCollection.IDColumnName; }
        }
        public static string Numero_NombreCol
        {
            get { return CTB_ASIENTOSCollection.NUMEROColumnName; }
        }
        public static string ObservacionSistema_NombreCol
        {
            get { return CTB_ASIENTOSCollection.OBSERVACION_SISTEMAColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CTB_ASIENTOSCollection.OBSERVACIONColumnName; }
        }
        public static string RegistroRelacionadoId_NombreCol
        {
            get { return CTB_ASIENTOSCollection.REGISTRO_RELACIONADO_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CTB_ASIENTOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string TablaRelacionadaId_NombreCol
        {
            get { return CTB_ASIENTOSCollection.TABLA_RELACIONADA_IDColumnName; }
        }
        public static string TransicionId_NombreCol
        {
            get { return CTB_ASIENTOSCollection.TRANSICION_IDColumnName; }
        }
        public static string UsuarioAprobacionId_NombreCol
        {
            get { return CTB_ASIENTOSCollection.USUARIO_APROBACION_IDColumnName; }
        }
        public static string UsuarioCreacionId_NombreCol
        {
            get { return CTB_ASIENTOSCollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string UsuarioInactivacionId_NombreCol
        {
            get { return CTB_ASIENTOSCollection.USUARIO_INACTIVACION_IDColumnName; }
        }
        public static string RevisionPosterior_NombreCol
        {
            get { return CTB_ASIENTOSCollection.REVISION_POSTERIORColumnName; }
        }
        public static string VistaCasoRelacionadoFlujoId_NombreCol
        {
            get { return CTB_ASIENTOS_INFO_COMPLETACollection.CASO_RELACIONADO_FLUJO_IDColumnName; }
        }
        public static string VistaCasoRelacionadoFlujoDescripcion_NombreCol
        {
            get { return CTB_ASIENTOS_INFO_COMPLETACollection.CASO_RELACIONADO_FLUJO_DESColumnName; }
        }
        public static string VistaEntidadId_NombreCol
        {
            get { return CTB_ASIENTOS_INFO_COMPLETACollection.ENTIDAD_IDColumnName; }
        }
        public static string VistaCtbEjercicioNombre_NombreCol
        {
            get { return CTB_ASIENTOS_INFO_COMPLETACollection.CTB_EJERCICIO_NOMBREColumnName; }
        }
        public static string VistaCtbEjercicioId_NombreCol
        {
            get { return CTB_ASIENTOS_INFO_COMPLETACollection.CTB_EJERCICIO_IDColumnName; }
        }
        public static string VistaCtbPeriodoNombre_NombreCol
        {
            get { return CTB_ASIENTOS_INFO_COMPLETACollection.CTB_PERIODO_NOMBREColumnName; }
        }
        public static string VistaCtbPeriodoVigentePorMargen_NombreCol
        {
            get { return CTB_ASIENTOS_INFO_COMPLETACollection.CTB_PERIODO_VIGENTE_POR_MARGENColumnName; }
        }
        public static string VistaCtbPeriodoVigente_NombreCol
        {
            get { return CTB_ASIENTOS_INFO_COMPLETACollection.CTB_PERIODO_VIGENTEColumnName; }
        }
        public static string VistaSucuralNombre_NombreCol
        {
            get { return CTB_ASIENTOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaTotalDebe_NombreCol
        {
            get { return CTB_ASIENTOS_INFO_COMPLETACollection.TOTAL_DEBEColumnName; }
        }
        public static string VistaTotalHaber_NombreCol
        {
            get { return CTB_ASIENTOS_INFO_COMPLETACollection.TOTAL_HABERColumnName; }
        }
        public static string VistaUsuarioCreacionNombreCompleto_NombreCol
        {
            get { return CTB_ASIENTOS_INFO_COMPLETACollection.USUARIO_CREACION_NOMBREColumnName; }
        }
        #endregion Accesors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static AsientosService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid},
            });

            if (e == null)
                return null;
            else
                return new AsientosService(e.RegistroId, sesion);
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
        protected CTB_ASIENTOSRow row;
        protected CTB_ASIENTOSRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Aprobado { get { return ClaseCBABase.GetStringHelper(row.APROBADO); } set { row.APROBADO = value; } }
        public string Automatico { get { return ClaseCBABase.GetStringHelper(row.AUTOMATICO); } set { row.AUTOMATICO = value; } }
        public decimal? CasoRelacionadoId { get { if (row.IsCASO_RELACIONADO_IDNull) return null; else return row.CASO_RELACIONADO_ID; } set { if (value.HasValue) row.CASO_RELACIONADO_ID = value.Value; else row.IsCASO_RELACIONADO_IDNull = true; } }
        public decimal? CtbAsientoGlobalId { get { if (row.IsCTB_ASIENTO_GLOBAL_IDNull) return null; else return row.CTB_ASIENTO_GLOBAL_ID; } set { if (value.HasValue) row.CTB_ASIENTO_GLOBAL_ID = value.Value; else row.IsCTB_ASIENTO_GLOBAL_IDNull = true; } }
        public decimal CtbPeriodoId { get { return row.CTB_PERIODO_ID; } set { row.CTB_PERIODO_ID = value; } }
        public string EsApertura { get { return ClaseCBABase.GetStringHelper(row.ES_APERTURA); } set { row.ES_APERTURA = value; } }
        public string EsCierre { get { return ClaseCBABase.GetStringHelper(row.ES_CIERRE); } set { row.ES_CIERRE = value; } }
        public string EsGlobal { get { return ClaseCBABase.GetStringHelper(row.ES_GLOBAL); } set { row.ES_GLOBAL = value; } }
        public string EsRegularizacion { get { return ClaseCBABase.GetStringHelper(row.ES_REGULARIZACION); } set { row.ES_REGULARIZACION = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime? FechaAprobacion { get { if (row.IsFECHA_APROBACIONNull) return null; else return row.FECHA_APROBACION; } set { if (value.HasValue) row.FECHA_APROBACION = value.Value; else row.IsFECHA_APROBACIONNull = true; } }
        public DateTime FechaAsiento { get { return row.FECHA_ASIENTO; } set { row.FECHA_ASIENTO = value; } }
        public DateTime FechaCreacion { get { return row.FECHA_CREACION; } set { row.FECHA_CREACION = value; } }
        public DateTime? FechaInactivacion { get { if (row.IsFECHA_INACTIVACIONNull) return null; else return row.FECHA_INACTIVACION; } set { if (value.HasValue) row.FECHA_INACTIVACION = value.Value; else row.IsFECHA_INACTIVACIONNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal Numero { get { return row.NUMERO; } set { row.NUMERO = value; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public string ObservacionSistema { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION_SISTEMA); } set { row.OBSERVACION_SISTEMA = value; } }
        public decimal? RegistroRelacionadoId { get { if (row.IsREGISTRO_RELACIONADO_IDNull) return null; else return row.REGISTRO_RELACIONADO_ID; } set { if (value.HasValue) row.REGISTRO_RELACIONADO_ID = value.Value; else row.IsREGISTRO_RELACIONADO_IDNull = true; } }
        public string RevisionPosterior { get { return ClaseCBABase.GetStringHelper(row.REVISION_POSTERIOR); } set { row.REVISION_POSTERIOR = value; } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } set { row.SUCURSAL_ID = value; } }
        public string TablaRelacionada { get { return ClaseCBABase.GetStringHelper(row.TABLA_RELACIONADA_ID); } set { row.TABLA_RELACIONADA_ID = value; } }
        public decimal? TransicionId { get { if (row.IsTRANSICION_IDNull) return null; else return row.TRANSICION_ID; } set { if (value.HasValue) row.TRANSICION_ID = value.Value; else row.IsTRANSICION_IDNull = true; } }
        public decimal? UsuarioAprobacionId { get { if (row.IsUSUARIO_APROBACION_IDNull) return null; else return row.USUARIO_APROBACION_ID; } set { if (value.HasValue) row.USUARIO_APROBACION_ID = value.Value; else row.IsUSUARIO_APROBACION_IDNull = true; } }
        public decimal? UsuarioCreacionId { get { if (row.IsUSUARIO_CREACION_IDNull) return null; else return row.USUARIO_CREACION_ID; } set { if (value.HasValue) row.USUARIO_CREACION_ID = value.Value; else row.IsUSUARIO_CREACION_IDNull = true; } }
        public decimal? UsuarioInactivacionId { get { if (row.IsUSUARIO_INACTIVACION_IDNull) return null; else return row.USUARIO_INACTIVACION_ID; } set { if (value.HasValue) row.USUARIO_INACTIVACION_ID = value.Value; else row.IsUSUARIO_INACTIVACION_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private AsientosService _ctb_asiento_global;
        public AsientosService CtbAsientoGlobal
        {
            get
            {
                if (this._ctb_asiento_global == null)
                    this._ctb_asiento_global = new AsientosService(this.CtbAsientoGlobalId.Value);
                return this._ctb_asiento_global;
            }
        }
        
        private PeriodosService _ctb_periodo;
        public PeriodosService CtbPeriodo
        {
            get
            {
                if (this._ctb_periodo == null)
                    this._ctb_periodo = new PeriodosService(this.CtbPeriodoId);
                return this._ctb_periodo;
            }
        }

        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                    this._sucursal = new SucursalesService(this.SucursalId);
                return this._sucursal;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTB_ASIENTOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTB_ASIENTOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public AsientosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public AsientosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public AsientosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        public AsientosService(EdiCBA.Asiento edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion); 
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = AsientosService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            this.Aprobado = edi.aprobado ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
            this.Automatico = edi.automatico ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
            this.CasoRelacionadoId = edi.caso_relacionado_id;
            this.FechaAsiento = edi.fecha;
            this.FechaCreacion = edi.fecha_creacion;
            this.Numero = edi.numero;
            this.Observacion = edi.observacion;

            #region sucursal
            if (!string.IsNullOrEmpty(edi.sucursal_uuid))
                this._sucursal = SucursalesService.GetPorUUID(edi.sucursal_uuid, sesion);
            if (this._sucursal == null && edi.sucursal != null)
                this._sucursal = new SucursalesService(edi.sucursal, almacenar_localmente, sesion);
            if (this.SucursalId <= 0 && this._sucursal == null)
                throw new Exception("No se encontró el UUID " + edi.sucursal_uuid + " ni se definieron los datos del objeto.");
        
            if (!this.Sucursal.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Sucursal.Id.HasValue)
                this.SucursalId = this.Sucursal.Id.Value;
            #endregion sucursal
        }
        #endregion Constructores

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.Asiento()
            {
                aprobado = this.Aprobado == Definiciones.SiNo.Si,
                automatico = this.Automatico == Definiciones.SiNo.Si,
                caso_relacionado_id = this.CasoRelacionadoId,
                fecha = this.FechaAsiento,
                fecha_creacion = this.FechaCreacion,
                numero = this.Numero,
                observacion = this.Observacion,
                sucursal_uuid = this.Sucursal.GetOrCreateUUID(sesion)
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.sucursal = (EdiCBA.Sucursal)this.Sucursal.ToEDI(nueva_profundidad, sesion);
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
