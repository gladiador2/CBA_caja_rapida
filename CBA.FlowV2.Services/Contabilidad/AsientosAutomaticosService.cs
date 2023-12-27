#region Using
using System;
using System.Data;
using System.Globalization;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using System.Collections.Generic;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos;
using System.Text.RegularExpressions;
using System.Collections;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.NotaCreditosProveedores;
using CBA.FlowV2.Services.RecursosHumanos;


#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
    public class AsientosAutomaticosService
    {
        #region sub clase UnificacionCentroCostoHelper
        private class UnificacionCentroCostoHelper
        {
            private decimal total;
            private List<decimal> lMontos;
            private List<DataTable> lCentrosCosto;

            public UnificacionCentroCostoHelper()
            {
                this.total = 0;
                this.lMontos = new List<decimal>();
                this.lCentrosCosto = new List<DataTable>();
            }

            public void Agregar(decimal monto, DataTable centros_costo) 
            {
                this.total += monto;
                this.lMontos.Add(monto);
                this.lCentrosCosto.Add(centros_costo);
            }

            public Hashtable GetUnificado()
            {
                var ht = new Hashtable();
                var dCentros = new Dictionary<decimal, decimal>();

                for (int i = 0; i < this.lMontos.Count; i++)
                {
                    var dtCentrosOriginal = this.lCentrosCosto[i];
                    for (int j = 0; j < dtCentrosOriginal.Rows.Count; j++)
                    {
                        decimal centroCostoId = (decimal)dtCentrosOriginal.Rows[j][AsientosDetalleCentrosCostoService.CentroCostoId_NombreCol];
                        if (!dCentros.ContainsKey(centroCostoId))
                            dCentros.Add(centroCostoId, 0);
                        dCentros[centroCostoId] += this.lMontos[i] * (decimal)dtCentrosOriginal.Rows[j][AsientosDetalleCentrosCostoService.Porcentaje_NombreCol] / 100;
                    }
                }

                foreach (KeyValuePair<decimal, decimal> item in dCentros)
                    ht.Add(item.Key, (decimal)item.Value / this.total * 100);

                return ht;
            }
        }
        #endregion sub clase UnificacionCentroCostoHelper

        #region sub clase UnificacionRelacionesHelper
        private class UnificacionRelacionesHelper
        {
            //Diccionario <nombre tabla; id regsitro; monto>
            private Dictionary<string, Dictionary<decimal, decimal>> relaciones;

            public UnificacionRelacionesHelper()
            {
                this.relaciones = new Dictionary<string, Dictionary<decimal, decimal>>();
            }

            public void Agregar(DataTable asiento_detalle_relaciones, bool signo_positivo)
            {
                for (int i = 0; i < asiento_detalle_relaciones.Rows.Count; i++)
                {
                    string tabla_id = (string)asiento_detalle_relaciones.Rows[i][AsientosDetalleRelacionesService.TablaRelacionadaId_NombreCol];
                    decimal registro_id = (decimal)asiento_detalle_relaciones.Rows[i][AsientosDetalleRelacionesService.RegistroRelacionadoId_NombreCol];
                    decimal monto = (decimal)asiento_detalle_relaciones.Rows[i][AsientosDetalleRelacionesService.Monto_NombreCol];

                    if (!this.relaciones.ContainsKey(tabla_id))
                        this.relaciones.Add(tabla_id, new Dictionary<decimal, decimal>());
                    if (!this.relaciones[tabla_id].ContainsKey(registro_id))
                        this.relaciones[tabla_id].Add(registro_id, 0);

                    this.relaciones[tabla_id][registro_id] += (signo_positivo ? monto : -monto);
                }
            }

            public List<Tuple<string, decimal?, decimal?>> GetUnificado()
            {
                var relaciones = new List<Tuple<string, decimal?, decimal?>>();

                foreach (KeyValuePair<string, Dictionary<decimal, decimal>> tabla in this.relaciones)
                {
                    foreach (KeyValuePair<decimal, decimal> registro in tabla.Value)
                    {
                        relaciones.Add((new Tuple<string, decimal?, decimal?>(tabla.Key, registro.Key, Math.Abs(registro.Value))));
                    }
                }
                return relaciones;
            }
        }
        #endregion sub clase UnificacionRelacionesHelper

        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="ctb_asiento_automatico_id">The ctb_asiento_automatico_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal ctb_asiento_automatico_id, SessionService sesion)
        {
            CTB_ASIENTOS_AUTOMATICOSRow row = sesion.Db.CTB_ASIENTOS_AUTOMATICOSCollection.GetByPrimaryKey(ctb_asiento_automatico_id);
            return row.ESTADO == Definiciones.Estado.Activo;
        }
        #endregion EstaActivo

        #region GetRevisionPosterior
        /// <summary>
        /// Gets the revision posterior.
        /// </summary>
        /// <param name="ctb_asiento_automatico_id">The ctb_asiento_automatico_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static bool GetRevisionPosterior(decimal ctb_asiento_automatico_id, SessionService sesion)
        {
            CTB_ASIENTOS_AUTOMATICOSRow row = sesion.Db.CTB_ASIENTOS_AUTOMATICOSCollection.GetByPrimaryKey(ctb_asiento_automatico_id);
            return row.REVISION_POSTERIOR == Definiciones.SiNo.Si;
        }
        #endregion GetRevisionPosterior

        #region GetCopiarObservacionCaso
        /// <summary>
        /// Gets the copiar observacion caso.
        /// </summary>
        /// <param name="ctb_asiento_automatico_id">The ctb_asiento_automatico_id.</param>
        /// <returns></returns>
        public static bool GetCopiarObservacionCaso(decimal ctb_asiento_automatico_id, SessionService sesion)
        {
            CTB_ASIENTOS_AUTOMATICOSRow row = sesion.Db.CTB_ASIENTOS_AUTOMATICOSCollection.GetByPrimaryKey(ctb_asiento_automatico_id);
            return row.COPIAR_OBSERVACION_CASO == Definiciones.SiNo.Si;
        }
        #endregion GetCopiarObservacionCaso

        #region GetUnificarDetallesMismaCuenta
        /// <summary>
        /// Gets the copiar observacion caso.
        /// </summary>
        /// <param name="ctb_asiento_automatico_id">The ctb_asiento_automatico_id.</param>
        /// <returns></returns>
        public static bool GetUnificarDetallesMismaCuenta(decimal ctb_asiento_automatico_id, SessionService sesion)
        {
            CTB_ASIENTOS_AUTOMATICOSRow row = sesion.Db.CTB_ASIENTOS_AUTOMATICOSCollection.GetByPrimaryKey(ctb_asiento_automatico_id);
            return row.UNIFICAR_DETALLES_MISMA_CUENTA == Definiciones.SiNo.Si;
        }
        #endregion GetUnificarDetallesMismaCuenta

        #region ExisteParaTransicion
        public static bool ExisteParaTransicion(decimal transicion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return ExisteParaTransicion(transicion_id, sesion);
            }
        }

        /// <summary>
        /// Existes the para transicion.
        /// </summary>
        /// <param name="transicion_id">The transicion_id.</param>
        /// <returns></returns>
        public static bool ExisteParaTransicion(decimal transicion_id, SessionService sesion)
        {
            CTB_ASIENTOS_AUTOMATICOSRow[] rows = sesion.Db.CTB_ASIENTOS_AUTOMATICOSCollection.GetByTRANSICION_ID(transicion_id);
            return rows.Length > 0;
        }
        #endregion ExisteParaTransicion

        #region GetAsientosAutomaticosDataTable
        /// <summary>
        /// Gets the asientos automaticos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAsientosAutomaticosDataTable(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = AsientosAutomaticosService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
                if (soloActivos) where += " and " + AsientosAutomaticosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas.Length > 0) where += " and " + clausulas;

                return sesion.Db.CTB_ASIENTOS_AUTOMATICOSCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetAsientosAutomaticosDataTable

        #region GetAsientosAutomaticosInfoCompleta

        /// <summary>
        /// Gets the asientos automaticos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetAsientosAutomaticosInfoCompleta(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = AsientosAutomaticosService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
                if (soloActivos) where += " and " + AsientosAutomaticosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas.Length > 0) where += " and " + clausulas;

                return sesion.Db.CTB_ASIENTOS_AUTOM_INFO_COMPLCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetAsientosAutomaticosInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    CTB_ASIENTOS_AUTOMATICOSRow row;
                    string valorAnterior;

                    row = sesion.Db.CTB_ASIENTOS_AUTOMATICOSCollection.GetByPrimaryKey((decimal)campos[AsientosAutomaticosService.Id_NombreCol]);
                    valorAnterior = row.ToString();

                    row.ESTADO = (string)campos[AsientosAutomaticosService.Estado_NombreCol];
                    row.ESTRUCTURA_OBSERVACION = (string)campos[AsientosAutomaticosService.EstructuraObservacion_NombreCol];
                    row.TRANSICION_ID = (decimal)campos[AsientosAutomaticosService.TransicionId_NombreCol];
                    row.NOMBRE = (string)campos[AsientosAutomaticosService.Nombre_NombreCol];
                    row.COPIAR_OBSERVACION_CASO = (string)campos[AsientosAutomaticosService.CopiarObservacionCaso_NombreCol];
                    row.MOSTRAR_OBS_DET_REPORTE = (string)campos[AsientosAutomaticosService.MostrarObsDetReporte_NombreCol];
                    row.UNIFICAR_DETALLES_MISMA_CUENTA = (string)campos[AsientosAutomaticosService.UnificarDetallesMismaCuenta_NombreCol];
                    row.USAR_FECHA_TRANSICION = (string)campos[AsientosAutomaticosService.UsarFechaTransaccion_NombreCol];

                    if (row.PAIS_ID.Equals(DBNull.Value) || row.PAIS_ID != (decimal)campos[AsientosAutomaticosService.PaisId_NombreCol])
                    {
                        if (!PaisesService.EstaActivo((decimal)campos[AsientosAutomaticosService.PaisId_NombreCol]))
                            throw new Exception("El país no se encuentra activo.");

                        row.PAIS_ID = (decimal)campos[AsientosAutomaticosService.PaisId_NombreCol];
                    }

                    row.REVISION_POSTERIOR = (string)campos[AsientosAutomaticosService.RevisionPosterior_NombreCol];

                    sesion.Db.CTB_ASIENTOS_AUTOMATICOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    
                    sesion.CommitTransaction();
                    return row.ID;
                }
                catch (Exception)
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Guardar

        #region BorrarTodosLosAsientos
        /// <summary>
        /// Borrars the todos los asientos.
        /// </summary>
        /// <param name="fecha_desde">The fecha_desde.</param>
        /// <param name="fecha_hasta">The fecha_hasta.</param>
        public static void BorrarTodosLosAsientos(DateTime fecha_desde, DateTime fecha_hasta, bool incluir_aprobados)
        {
            BorrarTodosLosAsientos(fecha_desde, fecha_hasta, Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo, incluir_aprobados);
        }

        /// <summary>
        /// Borrars the todos los asientos.
        /// </summary>
        /// <param name="fecha_desde">The fecha_desde.</param>
        /// <param name="fecha_hasta">The fecha_hasta.</param>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <exception cref="System.Exception">La fecha inicio debe ser anterior a la fecha fin.</exception>
        public static void BorrarTodosLosAsientos(DateTime fecha_desde, DateTime fecha_hasta, decimal flujo_id, decimal sucursal_id, bool incluir_aprobados)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    string clausulas;
                    DataTable dtAsientos;

                    if (fecha_hasta < fecha_desde)
                        throw new Exception("La fecha inicio debe ser anterior a la fecha fin.");

                    clausulas = "trunc(" + AsientosService.FechaAsiento_NombreCol + ") >= to_date('" + fecha_desde.ToShortDateString() + "', 'dd/mm/yyyy') and " +
                                "trunc(" + AsientosService.FechaAsiento_NombreCol + ") <= to_date('" + fecha_hasta.ToShortDateString() + "', 'dd/mm/yyyy') and " +
                                AsientosService.Automatico_NombreCol + " = '" + Definiciones.SiNo.Si + "' and " +
                                AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                    if (flujo_id != Definiciones.Error.Valor.EnteroPositivo)
                        clausulas += " and " + AsientosService.VistaCasoRelacionadoFlujoId_NombreCol + " = " + flujo_id;

                    if (sucursal_id != Definiciones.Error.Valor.EnteroPositivo)
                        clausulas += " and " + AsientosService.SucursalId_NombreCol + " = " + sucursal_id;

                    if (!incluir_aprobados)
                        clausulas += " and " + AsientosService.Aprobado_NombreCol + " = '" + Definiciones.SiNo.No + "' ";

                    dtAsientos = AsientosService.GetAsientosInfoCompleta(clausulas, AsientosService.Id_NombreCol, sesion);

                    for (int i = 0; i < dtAsientos.Rows.Count; i++)
                        AsientosService.Borrar((decimal)dtAsientos.Rows[i][AsientosService.Id_NombreCol], sesion);

                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion BorrarTodosLosAsientos

        #region RegenerarTodosLosAsientos

        /// <summary>
        /// Regenerars the todos los asientos.
        /// </summary>
        /// <param name="fecha_desde">The fecha_desde.</param>
        /// <param name="fecha_hasta">The fecha_hasta.</param>
        public static void RegenerarTodosLosAsientos(DateTime fecha_desde, DateTime fecha_hasta, bool por_fecha_formulario, decimal flujo_id, decimal sucursal_id)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    string clausulas = string.Empty;
                    DataTable dtOperaciones;

                    if (fecha_hasta < fecha_desde)
                        throw new Exception("La fecha inicio debe ser anterior a la fecha fin.");

                    if (por_fecha_formulario)
                    {
                        clausulas += "trunc(" + OperacionesService.VistaFechaFormulario_NombreCol + ") >= to_date('" + fecha_desde.ToShortDateString() + "', 'dd/mm/yyyy') and " +
                                     "trunc(" + OperacionesService.VistaFechaFormulario_NombreCol + ") <= to_date('" + fecha_hasta.ToShortDateString() + "', 'dd/mm/yyyy') and ";
                    }
                    else
                    {
                        clausulas += "trunc(" + OperacionesService.Fecha_NombreCol + ") >= to_date('" + fecha_desde.ToShortDateString() + "', 'dd/mm/yyyy') and " +
                                     "trunc(" + OperacionesService.Fecha_NombreCol + ") <= to_date('" + fecha_hasta.ToShortDateString() + "', 'dd/mm/yyyy') and ";
                    }

                    clausulas += OperacionesService.TransicionId_NombreCol + " in (select " + AsientosAutomaticosService.TransicionId_NombreCol + " from " + AsientosAutomaticosService.Nombre_Tabla + ") and " +
                                " not exists (select * from " + AsientosService.Nombre_Tabla + " ca " +
                                "              where ca." + AsientosService.TransicionId_NombreCol + " = " + OperacionesService.Nombre_Tabla + "." + OperacionesService.TransicionId_NombreCol + " and " +
                                "                    ca." + AsientosService.CasoRelacionadoId_NombreCol + " = " + OperacionesService.Nombre_Tabla + "." + OperacionesService.CasoId_NombreCol + " and " +
                                "                    ca." + AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "') " +
                                " and " + OperacionesService.VistaCasoEstado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                    
                    if (flujo_id != Definiciones.Error.Valor.EnteroPositivo)
                        clausulas += "and " + OperacionesService.VistaFlujoId_NombreCol + " = " + flujo_id.ToString("#");

                    if (sucursal_id != Definiciones.Error.Valor.EnteroPositivo)
                        clausulas += "and " + OperacionesService.VistaSucursalId_NombreCol + " = " + sucursal_id.ToString("#");

                    dtOperaciones = OperacionesService.GetOperacionesInfoCompletaStatic(clausulas, OperacionesService.Id_NombreCol, sesion);

                    for (int i = 0; i < dtOperaciones.Rows.Count; i++)
                    {
                        try
                        {
                            if ((decimal)dtOperaciones.Rows[i][OperacionesService.TransicionId_NombreCol] == Definiciones.Error.Valor.EnteroPositivo)
                                continue;

                            //No se crea si ya existe un asiento activo para el caso
                            if (AsientosService.ExistePorCasoRelacionado((decimal)dtOperaciones.Rows[i][OperacionesService.CasoId_NombreCol], (decimal)dtOperaciones.Rows[i][OperacionesService.TransicionId_NombreCol], sesion))
                                continue;

                            sesion.BeginTransaction();
                            try
                            {
                                AsientosAutomaticosService.GenerarAsientosPorTransicion((decimal)dtOperaciones.Rows[i][OperacionesService.TransicionId_NombreCol],
                                                                                        (decimal)dtOperaciones.Rows[i][OperacionesService.CasoId_NombreCol],
                                                                                        (decimal)dtOperaciones.Rows[i][OperacionesService.VistaFlujoId_NombreCol],
                                                                                        true,
                                                                                        (DateTime)dtOperaciones.Rows[i][OperacionesService.Fecha_NombreCol],
                                                                                        sesion);
                            }
                            catch
                            {
                                //Se permite continuar aunque no haya podido generarse el asiento
                            }
                            sesion.CommitTransaction();
                        }
                        catch
                        {
                            sesion.RollbackTransaction();
                            throw;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion RegenerarTodosLosAsientos

        #region GenerarAsientosPorTransicion
        public static void GenerarAsientosPorTransicion(decimal transicion_id, decimal caso_id, decimal flujo_id, bool usuario_logueado, DateTime fecha_transicion)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    GenerarAsientosPorTransicion(transicion_id, caso_id, flujo_id, usuario_logueado, fecha_transicion, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public static void GenerarAsientosPorTransicion(decimal transicion_id, decimal caso_id, decimal flujo_id, bool usuario_logueado, DateTime fecha_transicion, SessionService sesion)
        {
            try 
            {
                if (transicion_id == Definiciones.Error.Valor.EnteroPositivo)
                    return;

                string parametros, separador, hash;
                decimal webserviceParametroId;

                //parametros := caso + separador + flujo + separador + transicion + separador + pais + separador + entidad;
                separador = "@!@";
                parametros = "" + caso_id + separador +
                                  flujo_id + separador +
                                  transicion_id + separador +
                                  sesion.SucursalActiva.PAIS_ID + separador +
                                  sesion.Entidad.ID + separador +
                                  fecha_transicion.ToShortDateString();
                hash = CBA.FlowV2.Services.Base.StringUtil.CrearHash(50);

                //Guardar los parametros
                webserviceParametroId = WebservicesParametrosService.Guardar(Definiciones.Webservices.AsientosAutomaticosGenerarPorTransicion, string.Empty, parametros, hash, true);

                //No se utiliza el webservice realmente, sino que se llama directamente al metodo invocado desde el webservice
                AsientosAutomaticosService.GenerarAsientosPorTransicion(webserviceParametroId, hash, usuario_logueado, fecha_transicion, sesion);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static string GenerarAsientosPorTransicion(decimal registro_id, string hash, bool usuario_logueado, DateTime fecha_transicion, SessionService sesion)
        {
            try
            {
                /*
                 * Se están implementando paulatinamente los asientos automáticos pseudo orientados a objeto
                 * Se utiliza un diccionario para distinguir los que ya fueron implementados y cuando
                 * no quede ninguno pendiente, se podrá borrar este método intermedio
                 */
                var asientosImplementados = new List<int>()
                {
                    Definiciones.Contabilidad.AsientosAutomaticos.DepositoBancario_PreAprobado_a_Aprobado,
                    Definiciones.Contabilidad.AsientosAutomaticos.FCClientes_Pendiente_a_Caja,
                    Definiciones.Contabilidad.AsientosAutomaticos.FCClientes_EnReparto_a_Caja,
                    Definiciones.Contabilidad.AsientosAutomaticos.FCClientes_Caja_a_Anualdo,
                    Definiciones.Contabilidad.AsientosAutomaticos.FCProveedores_Aprobado_a_Pendiente,
                    Definiciones.Contabilidad.AsientosAutomaticos.FCProveedores_EnRevision_a_Aprobado,
                    Definiciones.Contabilidad.AsientosAutomaticos.FCProveedores_Pendiente_a_Aprobado,
                    Definiciones.Contabilidad.AsientosAutomaticos.NotaCreditoPersona_PreAprobado_a_Aprobado,
                    Definiciones.Contabilidad.AsientosAutomaticos.NotaCreditoProveedor_Pendiente_a_Aprobado,
                    Definiciones.Contabilidad.AsientosAutomaticos.PagoDePersonas_Borrador_a_Aprobado,
                    Definiciones.Contabilidad.AsientosAutomaticos.PagoDePersonas_Aprobado_a_Borrador,
                    Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Aprobado_a_Generacion,
                    Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Aprobado_a_Generacion_UNIFICADO,
                    Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Generacion_a_Anulado,
                    Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Generacion_a_Anulado_UNIFICADO,
                    Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Generacion_a_Cerrado,
                    Definiciones.Contabilidad.AsientosAutomaticos.Remisiones_Aprobado_a_Anulado,
                    Definiciones.Contabilidad.AsientosAutomaticos.Remisiones_Pendiente_a_Aprobado,
                    Definiciones.Contabilidad.AsientosAutomaticos.PlanillaLiquidaciones_Pendiente_a_Aprobado
                };

                string clausulas;
                DataTable dtAsientosAuto, dtAsientoAutoDet, dtPeriodos;
                decimal asientoId = Definiciones.Error.Valor.EnteroPositivo;

                //Inicializar sesion para soporte
                if (!usuario_logueado)
                {
                    LogueoService logueo = new LogueoService(string.Empty, string.Empty, string.Empty);
                    logueo.AsignarVariablesDeSesion();
                }

                //Estructura
                //caso | flujo | transicion | pais | entidad | fechaTransicion
                string[] parametros = WebservicesParametrosService.ObtenerParametros(registro_id, hash, sesion);
                decimal casoId = decimal.Parse(parametros[0]);
                decimal flujoId = decimal.Parse(parametros[1]);
                decimal transicionId = decimal.Parse(parametros[2]);
                decimal paisId = decimal.Parse(parametros[3]);
                decimal entidadId = decimal.Parse(parametros[4]);
                DateTime fechaTransicion = DateTime.ParseExact(parametros[5], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                //Evaluar asientos automaticos para la transicion del flujo
                clausulas = AsientosAutomaticosService.EntidadId_NombreCol + " = " + entidadId + " and " +
                            AsientosAutomaticosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                            AsientosAutomaticosService.PaisId_NombreCol + " = " + paisId + " and " +
                            AsientosAutomaticosService.TransicionId_NombreCol + " = " + transicionId;
                dtAsientosAuto = AsientosAutomaticosService.GetAsientosAutomaticosDataTable(clausulas, AsientosAutomaticosService.Id_NombreCol, true);
                if (dtAsientosAuto.Rows.Count <= 0)
                    return Definiciones.WebserviceRetorno.Exito;

                AsientosAutomaticosService asientoAutomatico = new AsientosAutomaticosService((decimal)dtAsientosAuto.Rows[0][AsientosAutomaticosService.Id_NombreCol], sesion);

                if (asientosImplementados.Contains((int)asientoAutomatico.Id.Value))
                {
                    Hashtable htDatosCaso = CargarDatosPorFlujo(asientoAutomatico, casoId, null, true, sesion);
                    asientoAutomatico.Generar(htDatosCaso, fecha_transicion, usuario_logueado, sesion);
                    return Definiciones.WebserviceRetorno.Exito;
                }
                else
                {
                    DateTime fechaAsiento;

                    dtAsientoAutoDet = AsientosAutomaticosDetalleService.GetAsientosAutomaticosDetalleInfoCompleta(AsientosAutomaticosDetalleService.AsientoAutomaticoId_NombreCol + " = " + dtAsientosAuto.Rows[0][AsientosAutomaticosService.Id_NombreCol] + " and " + AsientosAutomaticosDetalleService.VistaCantidadCuentasRelacionadas_NombreCol + " > " + 0, AsientosAutomaticosDetalleService.Orden_NombreCol, sesion);
                    if (dtAsientoAutoDet.Rows.Count <= 0)
                        return Definiciones.WebserviceRetorno.Exito;

                    CasosService caso = new CasosService(casoId, sesion);
                    if (asientoAutomatico.UsarFechaTransicion == Definiciones.SiNo.Si)
                        fechaAsiento = fecha_transicion;
                    else
                        fechaAsiento = caso.FechaFormulario.Value;

                    dtPeriodos = PeriodosService.GetPeriodoActivoAAsentar(fechaAsiento, caso, sesion);
                    if (dtPeriodos.Rows.Count <= 0)
                        throw new Exception("No se encontró un período contable activo.");

                    foreach (DataRow drPeriodo in dtPeriodos.Rows)
                    {
                        try
                        {
                            for (int i = 0; i < dtAsientosAuto.Rows.Count; i++)
                            {
                                #region generar segun tipo de asiento automatico
                                switch ((int)asientoAutomatico.Id.Value)
                                {
                                    case Definiciones.Contabilidad.AsientosAutomaticos.StockTransferencia_Aprobado_a_Viajando:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosStockTransferenciasService.AsentarAprobadoAViajando(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.StockTransferencia_EnRevision_a_Cerrado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosStockTransferenciasService.AsentarEnRevisionACerrado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.TransferenciaBancaria_Aprobado_a_Cerrado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosTransferenciasBancariasService.AsentarAprobadoACerrado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.IngresoStock_Pendiente_a_Aprobado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosIngresoStockService.AsentarPendienteAAprobado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.EgresoVarioCaja_Pendiente_a_Aprobado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosEgresoVarioCajaService.AsentarPendienteAAprobado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.MovimientoVarioTesoreria_Pendiente_a_Aprobado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosMovimientoVarioTesoreriaService.AsentarPendienteAAprobado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.MovimientoVarioTesoreria_Aprobado_a_Anulado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosMovimientoVarioTesoreriaService.AsentarAprobadoAAnulado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.NotaDebitoPersona_Pendiente_a_Aprobado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosNotasDebitoPersonasService.AsentarPendienteAAprobado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.NotaDebitoProveedor_Pendiente_a_Aprobado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosNotasDebitoProveedoresService.AsentarPendienteAAprobado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.AjusteStock_Pendiente_a_Aprobado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosAjusteStockService.AsentarPendienteAAprobado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.UsoDeInsumos_Pendiente_a_Aprobado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosUsoDeInsumosService.AsentarPendienteAAprobado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.AnticipoProveedor_Aprobado_a_Aplicacion:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosAnticiposProveedoresService.AsentarAprobadoAAplicacion(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.AnticipoPersona_Pendiente_a_Aprobado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosAnticiposPersonasService.AsentarPendienteAAprobado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.AjusteBancario_Aprobado_a_Cerrado:
                                        asientoId = new AsientosAjusteBancarioService((int)asientoAutomatico.Id.Value).AsentarAprobadoACerrado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.MovimientoFondoFijo_Pendiente_a_Aprobado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosMovimientoFondoFijoService.AsentarPendienteAAprobado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.TransferenciaCajasSucursal_EnProceso_a_Cerrado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosTransferenciaCajaSucursalService.AsentarEnProcesoACerrado(caso, true, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosTransferenciaCajaSucursalService.AsentarEnProcesoACerrado(caso, false, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.CreditoProveedor_Pendiente_a_Aprobado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosCreditoProveedorService.AsentarPendienteAAprobado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.TransferenciaCuentaCorriente_Pendiente_a_Aprobado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosTransferenciaCuentaCorrienteService.AsentarPendienteAAprobado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.AplicacionDocumentos_Pendiente_a_Aprobado:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosAplicacionDocumentosService.AsentarPendienteAAprobado(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.CreditoCliente_Aprobado_a_Vigente:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosCreditoClienteService.AsentarAprobadoAVigente(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    case Definiciones.Contabilidad.AsientosAutomaticos.CreditoCliente_EnRevision_a_Vigente:
                                        asientoId = CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos.AsientosCreditoClienteService.AsentarEnRevisionAVigente(caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                        break;
                                    default:
                                        throw new Exception("AsientosAutomaticosService.GenerarAsientosPorTransicion() el asiento automático " + asientoAutomatico.Nombre + " no está implementado.");
                                }
                                #endregion generar segun tipo de asiento automatico
                            }
                        }
                        catch
                        {
                            //Se permite continuar aunque no haya podido generarse el asiento
                        }

                        if (asientoId != Definiciones.Error.Valor.EnteroPositivo)
                        {
                            DataTable detalle = AsientosDetalleService.GetAsientosDetalleDataTable(AsientosDetalleService.CtbAsientoId_NombreCol + " = " + asientoId, string.Empty, sesion);
                            if (detalle.Rows.Count <= 0)
                            {
                                AsientosService.Borrar(asientoId, sesion);
                                return Definiciones.WebserviceRetorno.Fallo;
                            }
                        }
                    }
                }
                return Definiciones.WebserviceRetorno.Exito;
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }
        #endregion GenerarAsientosPorTransicion

        #region CargarDatosPorFlujo
        public static Hashtable CargarDatosPorFlujo(AsientosAutomaticosService asiento_automatico, decimal? caso_id, EdiCBA.Estructura edi, bool almacenar_localmente, SessionService sesion)
        {
            Hashtable htDatosCaso = null;
            object cabecera = null, detalles = null, documentos = null, valores = null;

            #region cargar datos segun flujo
            switch ((int)asiento_automatico.Id.Value)
            {
                case Definiciones.Contabilidad.AsientosAutomaticos.DepositoBancario_PreAprobado_a_Aprobado:
                    if (edi == null)
                    {
                        cabecera = DepositosBancariosService.GetPorCaso(caso_id.Value, sesion);
                        detalles = DepositosBancariosDetalleService.GetPorCabecera(((DepositosBancariosService)cabecera).Id.Value, sesion);
                    }
                    else
                    {
                        cabecera = new DepositosBancariosService((EdiCBA.DepositoBancario)edi, almacenar_localmente, sesion);
                        if (((EdiCBA.DepositoBancario)edi).deposito_bancario_detalles_uuid != null && ((EdiCBA.DepositoBancario)edi).deposito_bancario_detalles_uuid.Length > 0)
                        {
                            detalles = new DepositosBancariosDetalleService[((EdiCBA.DepositoBancario)edi).deposito_bancario_detalles_uuid.Length];
                            for (int i = 0; i < ((EdiCBA.DepositoBancario)edi).deposito_bancario_detalles_uuid.Length; i++)
                                ((DepositosBancariosDetalleService[])detalles)[i] = DepositosBancariosDetalleService.GetPorUUID(((EdiCBA.DepositoBancario)edi).deposito_bancario_detalles_uuid[i], sesion);
                        }
                        else if (((EdiCBA.DepositoBancario)edi).deposito_bancario_detalles != null && ((EdiCBA.DepositoBancario)edi).deposito_bancario_detalles.Length > 0)
                        {
                            detalles = new DepositosBancariosDetalleService[((EdiCBA.DepositoBancario)edi).deposito_bancario_detalles.Length];
                            for (int i = 0; i < ((EdiCBA.DepositoBancario)edi).deposito_bancario_detalles.Length; i++)
                                ((DepositosBancariosDetalleService[])detalles)[i] = new DepositosBancariosDetalleService(((EdiCBA.DepositoBancario)edi).deposito_bancario_detalles[i], almacenar_localmente, sesion);
                        }
                    }
                    break;
                case Definiciones.Contabilidad.AsientosAutomaticos.FCClientes_Pendiente_a_Caja:
                case Definiciones.Contabilidad.AsientosAutomaticos.FCClientes_EnReparto_a_Caja:
                case Definiciones.Contabilidad.AsientosAutomaticos.FCClientes_Caja_a_Anualdo:
                    if (edi == null)
                    {
                        cabecera = FacturasClienteService.GetPorCaso(caso_id.Value, sesion);
                        detalles = FacturasClienteDetalleService.GetPorCabecera(((FacturasClienteService)cabecera).Id.Value, sesion);
                    }
                    else
                    {
                        cabecera = new FacturasClienteService((EdiCBA.FacturaCliente)edi, almacenar_localmente, sesion);
                        if (((EdiCBA.FacturaCliente)edi).factura_cliente_detalles_uuid != null && ((EdiCBA.FacturaCliente)edi).factura_cliente_detalles_uuid.Length > 0)
                        {
                            detalles = new FacturasClienteDetalleService[((EdiCBA.FacturaCliente)edi).factura_cliente_detalles_uuid.Length];
                            for (int i = 0; i < ((EdiCBA.FacturaCliente)edi).factura_cliente_detalles_uuid.Length; i++)
                                ((FacturasClienteDetalleService[])detalles)[i] = FacturasClienteDetalleService.GetPorUUID(((EdiCBA.FacturaCliente)edi).factura_cliente_detalles_uuid[i], sesion);
                        }
                        else if (((EdiCBA.FacturaCliente)edi).factura_cliente_detalles != null && ((EdiCBA.FacturaCliente)edi).factura_cliente_detalles.Length > 0)
                        {
                            detalles = new FacturasClienteDetalleService[((EdiCBA.FacturaCliente)edi).factura_cliente_detalles.Length];
                            for (int i = 0; i < ((EdiCBA.FacturaCliente)edi).factura_cliente_detalles.Length; i++)
                                ((FacturasClienteDetalleService[])detalles)[i] = new FacturasClienteDetalleService(((EdiCBA.FacturaCliente)edi).factura_cliente_detalles[i], almacenar_localmente, sesion);
                        }
                    }
                    break;
                case Definiciones.Contabilidad.AsientosAutomaticos.FCProveedores_Aprobado_a_Pendiente:
                case Definiciones.Contabilidad.AsientosAutomaticos.FCProveedores_EnRevision_a_Aprobado:
                case Definiciones.Contabilidad.AsientosAutomaticos.FCProveedores_Pendiente_a_Aprobado:
                    if (edi == null)
                    {
                        cabecera = FacturasProveedorService.GetPorCaso(caso_id.Value, sesion);
                        detalles = FacturasProveedorDetalleService.GetPorCabecera(((FacturasProveedorService)cabecera).Id.Value, sesion);
                    }
                    else
                    {
                        cabecera = new FacturasProveedorService((EdiCBA.FacturaProveedor)edi, almacenar_localmente, sesion);
                        if (((EdiCBA.FacturaProveedor)edi).factura_proveedor_detalles_uuid != null && ((EdiCBA.FacturaProveedor)edi).factura_proveedor_detalles_uuid.Length > 0)
                        {
                            detalles = new FacturasProveedorDetalleService[((EdiCBA.FacturaProveedor)edi).factura_proveedor_detalles_uuid.Length];
                            for (int i = 0; i < ((EdiCBA.FacturaProveedor)edi).factura_proveedor_detalles_uuid.Length; i++)
                                ((FacturasProveedorDetalleService[])detalles)[i] = FacturasProveedorDetalleService.GetPorUUID(((EdiCBA.FacturaProveedor)edi).factura_proveedor_detalles_uuid[i], sesion);
                        }
                        else if (((EdiCBA.FacturaProveedor)edi).factura_proveedor_detalles != null && ((EdiCBA.FacturaProveedor)edi).factura_proveedor_detalles.Length > 0)
                        {
                            detalles = new FacturasProveedorDetalleService[((EdiCBA.FacturaProveedor)edi).factura_proveedor_detalles.Length];
                            for (int i = 0; i < ((EdiCBA.FacturaProveedor)edi).factura_proveedor_detalles.Length; i++)
                                ((FacturasProveedorDetalleService[])detalles)[i] = new FacturasProveedorDetalleService(((EdiCBA.FacturaProveedor)edi).factura_proveedor_detalles[i], almacenar_localmente, sesion);
                        }
                    }
                    break;
                case Definiciones.Contabilidad.AsientosAutomaticos.NotaCreditoPersona_PreAprobado_a_Aprobado:
                    if (edi == null)
                    {
                        cabecera = NotasCreditoPersonaService.GetPorCaso(caso_id.Value, sesion);
                        detalles = NotasCreditoPersonaDetalleService.GetPorCabecera(((NotasCreditoPersonaService)cabecera).Id.Value, sesion);
                    }
                    else
                    {
                        cabecera = new NotasCreditoPersonaService((EdiCBA.NotaCreditoCliente)edi, almacenar_localmente, sesion);
                        if (((EdiCBA.NotaCreditoCliente)edi).nota_credito_cliente_detalles_uuid != null && ((EdiCBA.NotaCreditoCliente)edi).nota_credito_cliente_detalles_uuid.Length > 0)
                        {
                            detalles = new NotasCreditoPersonaDetalleService[((EdiCBA.NotaCreditoCliente)edi).nota_credito_cliente_detalles_uuid.Length];
                            for (int i = 0; i < ((EdiCBA.NotaCreditoCliente)edi).nota_credito_cliente_detalles_uuid.Length; i++)
                                ((NotasCreditoPersonaDetalleService[])detalles)[i] = NotasCreditoPersonaDetalleService.GetPorUUID(((EdiCBA.NotaCreditoCliente)edi).nota_credito_cliente_detalles_uuid[i], sesion);
                        }
                        else if (((EdiCBA.NotaCreditoCliente)edi).nota_credito_cliente_detalles != null && ((EdiCBA.NotaCreditoCliente)edi).nota_credito_cliente_detalles.Length > 0)
                        {
                            detalles = new NotasCreditoPersonaDetalleService[((EdiCBA.NotaCreditoCliente)edi).nota_credito_cliente_detalles.Length];
                            for (int i = 0; i < ((EdiCBA.NotaCreditoCliente)edi).nota_credito_cliente_detalles.Length; i++)
                                ((NotasCreditoPersonaDetalleService[])detalles)[i] = new NotasCreditoPersonaDetalleService(((EdiCBA.NotaCreditoCliente)edi).nota_credito_cliente_detalles[i], almacenar_localmente, sesion);
                        }
                    }
                    break;
                case Definiciones.Contabilidad.AsientosAutomaticos.NotaCreditoProveedor_Pendiente_a_Aprobado:
                    if (edi == null)
                    {
                        cabecera = NotasCreditoProveedorService.GetPorCaso(caso_id.Value, sesion);
                        detalles = NotasCreditoProveedorDetalleService.GetPorCabecera(((NotasCreditoProveedorService)cabecera).Id.Value, sesion);
                    }
                    else
                    {
                        cabecera = new NotasCreditoProveedorService((EdiCBA.NotaCreditoProveedor)edi, almacenar_localmente, sesion);
                        if (((EdiCBA.NotaCreditoProveedor)edi).nota_credito_proveedor_detalles_uuid != null && ((EdiCBA.NotaCreditoProveedor)edi).nota_credito_proveedor_detalles_uuid.Length > 0)
                        {
                            detalles = new NotasCreditoProveedorDetalleService[((EdiCBA.NotaCreditoProveedor)edi).nota_credito_proveedor_detalles_uuid.Length];
                            for (int i = 0; i < ((EdiCBA.NotaCreditoProveedor)edi).nota_credito_proveedor_detalles_uuid.Length; i++)
                                ((NotasCreditoProveedorDetalleService[])detalles)[i] = NotasCreditoProveedorDetalleService.GetPorUUID(((EdiCBA.NotaCreditoProveedor)edi).nota_credito_proveedor_detalles_uuid[i], sesion);
                        }
                        else if (((EdiCBA.NotaCreditoProveedor)edi).nota_credito_proveedor_detalles != null && ((EdiCBA.NotaCreditoProveedor)edi).nota_credito_proveedor_detalles.Length > 0)
                        {
                            detalles = new NotasCreditoProveedorDetalleService[((EdiCBA.NotaCreditoProveedor)edi).nota_credito_proveedor_detalles.Length];
                            for (int i = 0; i < ((EdiCBA.NotaCreditoProveedor)edi).nota_credito_proveedor_detalles.Length; i++)
                                ((NotasCreditoProveedorDetalleService[])detalles)[i] = new NotasCreditoProveedorDetalleService(((EdiCBA.NotaCreditoProveedor)edi).nota_credito_proveedor_detalles[i], almacenar_localmente, sesion);
                        }
                    }
                    break;
                case Definiciones.Contabilidad.AsientosAutomaticos.PagoDePersonas_Borrador_a_Aprobado:
                case Definiciones.Contabilidad.AsientosAutomaticos.PagoDePersonas_Aprobado_a_Borrador:
                    if (edi == null)
                    {
                        cabecera = PagosDePersonaService.GetPorCaso(caso_id.Value, sesion);
                        documentos = CuentaCorrientePagosPersonaDocumentoService.GetPorCabecera(((PagosDePersonaService)cabecera).Id.Value, sesion);
                        valores = CuentaCorrientePagosPersonaDetalleService.GetPorCabecera(((PagosDePersonaService)cabecera).Id.Value, sesion);
                    }
                    else
                    {
                        cabecera = new PagosDePersonaService((EdiCBA.Cobranza)edi, almacenar_localmente, sesion);
                        if (((EdiCBA.Cobranza)edi).cobranza_documentos_uuid != null && ((EdiCBA.Cobranza)edi).cobranza_documentos_uuid.Length > 0)
                        {
                            documentos = new CuentaCorrientePagosPersonaDocumentoService[((EdiCBA.Cobranza)edi).cobranza_documentos_uuid.Length];
                            for (int i = 0; i < ((EdiCBA.Cobranza)edi).cobranza_documentos_uuid.Length; i++)
                                ((CuentaCorrientePagosPersonaDocumentoService[])documentos)[i] = CuentaCorrientePagosPersonaDocumentoService.GetPorUUID(((EdiCBA.Cobranza)edi).cobranza_documentos_uuid[i], sesion);
                        }
                        else if (((EdiCBA.Cobranza)edi).cobranza_documentos != null && ((EdiCBA.Cobranza)edi).cobranza_documentos.Length > 0)
                        {
                            documentos = new CuentaCorrientePagosPersonaDocumentoService[((EdiCBA.Cobranza)edi).cobranza_documentos.Length];
                            for (int i = 0; i < ((EdiCBA.Cobranza)edi).cobranza_documentos.Length; i++)
                                ((CuentaCorrientePagosPersonaDocumentoService[])documentos)[i] = new CuentaCorrientePagosPersonaDocumentoService(((EdiCBA.Cobranza)edi).cobranza_documentos[i], almacenar_localmente, sesion);
                        }

                        if (((EdiCBA.Cobranza)edi).cobranza_valores_uuid != null && ((EdiCBA.Cobranza)edi).cobranza_valores_uuid.Length > 0)
                        {
                            valores = new CuentaCorrientePagosPersonaDetalleService[((EdiCBA.Cobranza)edi).cobranza_valores_uuid.Length];
                            for (int i = 0; i < ((EdiCBA.Cobranza)edi).cobranza_valores_uuid.Length; i++)
                                ((CuentaCorrientePagosPersonaDetalleService[])valores)[i] = CuentaCorrientePagosPersonaDetalleService.GetPorUUID(((EdiCBA.Cobranza)edi).cobranza_valores_uuid[i], sesion);
                        }
                        else if (((EdiCBA.Cobranza)edi).cobranza_valores != null && ((EdiCBA.Cobranza)edi).cobranza_valores.Length > 0)
                        {
                            valores = new CuentaCorrientePagosPersonaDetalleService[((EdiCBA.Cobranza)edi).cobranza_valores.Length];
                            for (int i = 0; i < ((EdiCBA.Cobranza)edi).cobranza_valores.Length; i++)
                                ((CuentaCorrientePagosPersonaDetalleService[])valores)[i] = new CuentaCorrientePagosPersonaDetalleService(((EdiCBA.Cobranza)edi).cobranza_valores[i], almacenar_localmente, sesion);
                        }
                    }
                    break;

                case Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Aprobado_a_Generacion:
                case Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Generacion_a_Anulado:
                case Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Generacion_a_Cerrado:
                case Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Aprobado_a_Generacion_UNIFICADO:
                case Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Generacion_a_Anulado_UNIFICADO:
                    if (edi == null)
                    {
                        cabecera = OrdenesPagoService.GetPorCaso(caso_id.Value, sesion);
                        documentos = OrdenesPagoDetalleService.GetPorCabecera(((OrdenesPagoService)cabecera).Id.Value, sesion);
                        valores = OrdenesPagoValoresService.GetPorCabecera(((OrdenesPagoService)cabecera).Id.Value, sesion);
                    }
                    else
                    {
                        cabecera = new OrdenesPagoService((EdiCBA.OrdenPago)edi, almacenar_localmente, sesion);
                        if (((EdiCBA.OrdenPago)edi).orden_pago_documentos_uuid != null && ((EdiCBA.OrdenPago)edi).orden_pago_documentos_uuid.Length > 0)
                        {
                            documentos = new OrdenesPagoDetalleService[((EdiCBA.OrdenPago)edi).orden_pago_documentos_uuid.Length];
                            for (int i = 0; i < ((EdiCBA.OrdenPago)edi).orden_pago_documentos_uuid.Length; i++)
                                ((OrdenesPagoDetalleService[])documentos)[i] = OrdenesPagoDetalleService.GetPorUUID(((EdiCBA.OrdenPago)edi).orden_pago_documentos_uuid[i], sesion);
                        }
                        else if (((EdiCBA.OrdenPago)edi).orden_pago_documentos != null && ((EdiCBA.OrdenPago)edi).orden_pago_documentos.Length > 0)
                        {
                            documentos = new OrdenesPagoDetalleService[((EdiCBA.OrdenPago)edi).orden_pago_documentos.Length];
                            for (int i = 0; i < ((EdiCBA.OrdenPago)edi).orden_pago_documentos.Length; i++)
                                ((OrdenesPagoDetalleService[])documentos)[i] = new OrdenesPagoDetalleService(((EdiCBA.OrdenPago)edi).orden_pago_documentos[i], almacenar_localmente, sesion);
                        }

                        if (((EdiCBA.OrdenPago)edi).orden_pago_valores_uuid != null && ((EdiCBA.OrdenPago)edi).orden_pago_valores_uuid.Length > 0)
                        {
                            valores = new OrdenesPagoValoresService[((EdiCBA.OrdenPago)edi).orden_pago_valores_uuid.Length];
                            for (int i = 0; i < ((EdiCBA.OrdenPago)edi).orden_pago_valores_uuid.Length; i++)
                                ((OrdenesPagoValoresService[])valores)[i] = OrdenesPagoValoresService.GetPorUUID(((EdiCBA.OrdenPago)edi).orden_pago_valores_uuid[i], sesion);
                        }
                        
                    }
                    break;
                case Definiciones.Contabilidad.AsientosAutomaticos.Remisiones_Aprobado_a_Anulado:
                case Definiciones.Contabilidad.AsientosAutomaticos.Remisiones_Pendiente_a_Aprobado:
                    if (edi == null)
                    {
                        cabecera = RemisionesService.GetPorCaso(caso_id.Value, sesion);
                        detalles = ((RemisionesService)cabecera).Detalles;
                    }
                    else
                    {
                        throw new NotImplementedException("Creación con EDI no implementada");
                    }
                    break;
                case Definiciones.Contabilidad.AsientosAutomaticos.PlanillaLiquidaciones_Pendiente_a_Aprobado:
                    if (edi == null)
                    {
                        cabecera = PlanillaLiquidacionesService.GetPorCaso(caso_id.Value, sesion);
                        detalles = PlanillaLiquidacionesDetallesService.GetPorCabecera(((PlanillaLiquidacionesService)cabecera).Id.Value, sesion);
                    }
                    else
                    {
                        cabecera = new PlanillaLiquidacionesService((EdiCBA.PlanillaLiquidacion)edi, almacenar_localmente, sesion);
                        if (((EdiCBA.PlanillaLiquidacion)edi).planilla_liquidacion_detalles_uuid != null && ((EdiCBA.PlanillaLiquidacion)edi).planilla_liquidacion_detalles_uuid.Length > 0)
                        {
                            detalles = new PlanillaLiquidacionesDetallesService[((EdiCBA.FacturaCliente)edi).factura_cliente_detalles_uuid.Length];
                            for (int i = 0; i < ((EdiCBA.FacturaCliente)edi).factura_cliente_detalles_uuid.Length; i++)
                                ((PlanillaLiquidacionesDetallesService[])detalles)[i] = PlanillaLiquidacionesDetallesService.GetPorUUID(((EdiCBA.PlanillaLiquidacion)edi).planilla_liquidacion_detalles_uuid[i], sesion);
                        }
                        else if (((EdiCBA.PlanillaLiquidacion)edi).planilla_liquidacion_detalles != null && ((EdiCBA.PlanillaLiquidacion)edi).planilla_liquidacion_detalles.Length > 0)
                        {
                            detalles = new PlanillaLiquidacionesDetallesService[((EdiCBA.PlanillaLiquidacion)edi).planilla_liquidacion_detalles.Length];
                            for (int i = 0; i < ((EdiCBA.FacturaCliente)edi).factura_cliente_detalles.Length; i++)
                                ((PlanillaLiquidacionesDetallesService[])detalles)[i] = new PlanillaLiquidacionesDetallesService(((EdiCBA.PlanillaLiquidacion)edi).planilla_liquidacion_detalles[i], almacenar_localmente, sesion);
                        }
                    }
                    break;
                default:
                    throw new Exception("AsientosAutomaticosService.CargarDatosPorFlujo() el asiento automático " + asiento_automatico.Nombre + " no está implementado con orientación a objetos.");
            }
            #endregion cargar datos segun flujo

            htDatosCaso = new Hashtable();
            if (cabecera != null)
                htDatosCaso.Add(Definiciones.Contabilidad.ClavesDatos.Cabecera, cabecera);
            if (cabecera != null)
                htDatosCaso.Add(Definiciones.Contabilidad.ClavesDatos.Detalles, detalles);
            if (cabecera != null)
                htDatosCaso.Add(Definiciones.Contabilidad.ClavesDatos.Documentos, documentos);
            if (cabecera != null)
                htDatosCaso.Add(Definiciones.Contabilidad.ClavesDatos.Valores, valores);

            return htDatosCaso;
        }
        #endregion CargarDatosPorFlujo

        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "CTB_ASIENTOS_AUTOMATICOS"; }
        }
        public static string CopiarObservacionCaso_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOSCollection.COPIAR_OBSERVACION_CASOColumnName; }
        }
        public static string EntidadId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOSCollection.ENTIDAD_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOSCollection.ESTADOColumnName; }
        }
        public static string EstructuraObservacion_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOSCollection.ESTRUCTURA_OBSERVACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOSCollection.IDColumnName; }
        }
        public static string MostrarObsDetReporte_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOSCollection.MOSTRAR_OBS_DET_REPORTEColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOSCollection.NOMBREColumnName; }
        }
        public static string PaisId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOSCollection.PAIS_IDColumnName; }
        }
        public static string RevisionPosterior_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOSCollection.REVISION_POSTERIORColumnName; }
        }
        public static string TransicionId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOSCollection.TRANSICION_IDColumnName; }
        }
        public static string UnificarDetallesMismaCuenta_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOSCollection.UNIFICAR_DETALLES_MISMA_CUENTAColumnName; }
        }
        public static string UsarFechaTransaccion_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOSCollection.USAR_FECHA_TRANSICIONColumnName; }
        }
        public static string VistaEntidadNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOM_INFO_COMPLCollection.ENTIDAD_NOMBREColumnName; }
        }
        public static string VistaPaisNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOM_INFO_COMPLCollection.PAIS_NOMBREColumnName; }
        }
        public static string VistaTransicionDescripcion_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOM_INFO_COMPLCollection.TRANSICION_DESCRIPCIONColumnName; }
        }
        public static string VistaTransicionFlujoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOM_INFO_COMPLCollection.TRANSICION_FLUJO_IDColumnName; }
        }
        public static string VistaTransicionFlujoDescripcion_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOM_INFO_COMPLCollection.TRANSICION_FLUJO_DESCRIPCIONColumnName; }
        }

        #endregion Accesors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region Metodos a implementar en herencia
        protected virtual string CalcularObservacionCabecera(CasosService caso, object cabecera, SessionService sesion) { return string.Empty; }
        protected virtual string CalcularObservacionDetalle(AsientosAutomaticosDetalleService asiento_automatico_detalle, CasosService caso, object cabecera, object detalle, SessionService sesion) { return string.Empty; }
        #endregion Metodos a implementar en herencia

        #region Propiedades
        protected CTB_ASIENTOS_AUTOMATICOSRow row;
        protected CTB_ASIENTOS_AUTOMATICOSRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string CopiarObservacionCaso { get { return row.COPIAR_OBSERVACION_CASO; } set { row.COPIAR_OBSERVACION_CASO = value; } }
        public decimal EntidadId { get { return row.ENTIDAD_ID; } set { row.ENTIDAD_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public string EstructuraObservacion { get { return row.ESTRUCTURA_OBSERVACION; } set { row.ESTRUCTURA_OBSERVACION = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string MostrarObsDetReporte { get { return row.MOSTRAR_OBS_DET_REPORTE; } set { row.MOSTRAR_OBS_DET_REPORTE = value; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        public decimal PaisId { get { return row.PAIS_ID; } set { row.PAIS_ID = value; } }
        public string RevisionPosterior { get { return row.REVISION_POSTERIOR; } set { row.REVISION_POSTERIOR = value; } }
        public decimal? TransicionId { get { if (row.IsTRANSICION_IDNull) return null; else return row.TRANSICION_ID; } set { if (value.HasValue) row.TRANSICION_ID = value.Value; else row.IsTRANSICION_IDNull = true; } }
        public string UnificarDetallesMismaCuenta { get { return row.UNIFICAR_DETALLES_MISMA_CUENTA; } set { row.UNIFICAR_DETALLES_MISMA_CUENTA = value; } }
        public string UsarFechaTransicion { get { return row.USAR_FECHA_TRANSICION; } set { row.USAR_FECHA_TRANSICION = value; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTB_ASIENTOS_AUTOMATICOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTB_ASIENTOS_AUTOMATICOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public AsientosAutomaticosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public AsientosAutomaticosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public AsientosAutomaticosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        #endregion Constructores

        #region Generar
        public AsientosService Generar(Hashtable datos_caso, DateTime fecha_transicion, bool usuario_logueado, SessionService sesion)
        { 
            try
            {
                decimal asientoId = Definiciones.Error.Valor.EnteroPositivo;
                DataTable dtAsientoAutoDet, dtPeriodos;
                DateTime fechaAsiento = fecha_transicion;
                decimal sucursalId = Definiciones.Error.Valor.EnteroPositivo;

                //Inicializar sesion para soporte
                if (!usuario_logueado)
                {
                    LogueoService logueo = new LogueoService(string.Empty, string.Empty, string.Empty);
                    logueo.AsignarVariablesDeSesion();
                }

                dtAsientoAutoDet = AsientosAutomaticosDetalleService.GetAsientosAutomaticosDetalleInfoCompleta(AsientosAutomaticosDetalleService.AsientoAutomaticoId_NombreCol + " = " + this.Id.Value + " and " + AsientosAutomaticosDetalleService.VistaCantidadCuentasRelacionadas_NombreCol + " > " + 0, AsientosAutomaticosDetalleService.Orden_NombreCol, sesion);
                if (dtAsientoAutoDet.Rows.Count <= 0)
                    return null;

                if (!datos_caso.ContainsKey(Definiciones.Contabilidad.ClavesDatos.Cabecera))
                    throw new Exception("El diccionario de datos debe contener la clave '" + Definiciones.Contabilidad.ClavesDatos.Cabecera + "'.");

                switch ((int)this.Id.Value)
                {
                    case Definiciones.Contabilidad.AsientosAutomaticos.DepositoBancario_PreAprobado_a_Aprobado:
                        var DepositoBancarioCabecera = (DepositosBancariosService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];

                        sucursalId = DepositoBancarioCabecera.SucursalId;
                        if (this.UsarFechaTransicion == Definiciones.SiNo.No)
                            fechaAsiento = DepositoBancarioCabecera.Fecha;
                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticos.FCClientes_Pendiente_a_Caja:
                    case Definiciones.Contabilidad.AsientosAutomaticos.FCClientes_EnReparto_a_Caja:
                    case Definiciones.Contabilidad.AsientosAutomaticos.FCClientes_Caja_a_Anualdo:
                        var FCClienteCabecera = (FacturasClienteService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];

                        sucursalId = FCClienteCabecera.SucursalId.Value;
                        if (this.UsarFechaTransicion == Definiciones.SiNo.No)
                            fechaAsiento = FCClienteCabecera.Fecha.Value;
                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticos.FCProveedores_Aprobado_a_Pendiente:
                    case Definiciones.Contabilidad.AsientosAutomaticos.FCProveedores_EnRevision_a_Aprobado:
                    case Definiciones.Contabilidad.AsientosAutomaticos.FCProveedores_Pendiente_a_Aprobado:
                        var FCProveedorCabecera = (FacturasProveedorService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];

                        sucursalId = FCProveedorCabecera.SucursalId;
                        if (this.UsarFechaTransicion == Definiciones.SiNo.No)
                            //fechaAsiento = FCProveedorCabecera.Fecha;
                            fechaAsiento = (DateTime)FCProveedorCabecera.FechaFactura;
                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticos.NotaCreditoPersona_PreAprobado_a_Aprobado:
                        var NCPersonaCabecera = (NotasCreditoPersonaService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];

                        sucursalId = NCPersonaCabecera.SucursalId;
                        if (this.UsarFechaTransicion == Definiciones.SiNo.No)
                            fechaAsiento = NCPersonaCabecera.Fecha;
                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticos.NotaCreditoProveedor_Pendiente_a_Aprobado:
                        var NCProveedorCabecera = (NotasCreditoProveedorService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];

                        sucursalId = NCProveedorCabecera.SucursalId;
                        if (this.UsarFechaTransicion == Definiciones.SiNo.No)
                            fechaAsiento = NCProveedorCabecera.Fecha;
                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticos.PagoDePersonas_Aprobado_a_Borrador:
                    case Definiciones.Contabilidad.AsientosAutomaticos.PagoDePersonas_Borrador_a_Aprobado:
                        var pagoPersona = (PagosDePersonaService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];

                        sucursalId = pagoPersona.SucursalId;
                        if (this.UsarFechaTransicion == Definiciones.SiNo.No)
                            fechaAsiento = pagoPersona.Fecha;
                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Aprobado_a_Generacion:
                    case Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Aprobado_a_Generacion_UNIFICADO:
                    case Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Generacion_a_Anulado:
                    case Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Generacion_a_Anulado_UNIFICADO:
                    case Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Generacion_a_Cerrado:
                        var ordenPago = (OrdenesPagoService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];

                        sucursalId = ordenPago.SucursalOrigenId;
                        if (this.UsarFechaTransicion == Definiciones.SiNo.No)
                            fechaAsiento = ordenPago.Fecha.Value;
                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticos.Remisiones_Aprobado_a_Anulado:
                    case Definiciones.Contabilidad.AsientosAutomaticos.Remisiones_Pendiente_a_Aprobado:
                        var remision = (RemisionesService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];

                        sucursalId = remision.SucursalId;
                        if (this.UsarFechaTransicion == Definiciones.SiNo.No)
                            fechaAsiento = remision.Fecha;
                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticos.PlanillaLiquidaciones_Pendiente_a_Aprobado:
                        var planillaLiquidacion = (PlanillaLiquidacionesService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];

                        sucursalId = planillaLiquidacion.SucursalId;
                        if (this.UsarFechaTransicion == Definiciones.SiNo.No)
                            fechaAsiento = planillaLiquidacion.FechaDesde;
                        break;
                    default:
                        throw new Exception("AsientosAutomaticosService.Generar() " + this.Nombre + " no implementado en orientación a objetos.");
                }

                dtPeriodos = PeriodosService.GetPeriodoActivoAAsentar(fechaAsiento, sucursalId, sesion);
                if (dtPeriodos.Rows.Count <= 0)
                    throw new Exception("No se encontró un período contable activo.");

                foreach (DataRow drPeriodo in dtPeriodos.Rows)
                {
                    try
                    {
                        switch ((int)this.Id.Value)
                        {
                            case Definiciones.Contabilidad.AsientosAutomaticos.DepositoBancario_PreAprobado_a_Aprobado:
                                asientoId = new AsientosDepositoBancarioService((int)this.Id.Value).AsentarPreAprobadoAAprobado(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.FCClientes_Pendiente_a_Caja:
                                asientoId = new AsientosFacturasClientesService((int)this.Id.Value).AsentarPendienteACaja(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.FCClientes_EnReparto_a_Caja:
                                asientoId = new AsientosFacturasClientesService((int)this.Id.Value).AsentarEnRepartoACaja(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.FCClientes_Caja_a_Anualdo:
                                asientoId = new AsientosFacturasClientesService((int)this.Id.Value).AsentarCajaAAnulado(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.FCProveedores_Aprobado_a_Pendiente:
                                asientoId = new AsientosFacturasProveedorService((int)this.Id.Value).AsentarAprobadoAPendiente(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.FCProveedores_EnRevision_a_Aprobado:
                                asientoId = new AsientosFacturasProveedorService((int)this.Id.Value).AsentarEnRevisionAAprobado(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.FCProveedores_Pendiente_a_Aprobado:
                                asientoId = new AsientosFacturasProveedorService((int)this.Id.Value).AsentarPendienteAAprobado(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.NotaCreditoPersona_PreAprobado_a_Aprobado:
                                asientoId = new AsientosNotaCreditoClientesService((int)this.Id.Value).AsentarPreAprobadoAAprobado(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.NotaCreditoProveedor_Pendiente_a_Aprobado:
                                asientoId = new AsientosNotaCreditoProveedoresService((int)this.Id.Value).AsentarPendienteAAprobado(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.PagoDePersonas_Borrador_a_Aprobado:
                                asientoId = new AsientosPagoDePersonasService((int)this.Id.Value).AsentarBorradorAAprobado(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.PagoDePersonas_Aprobado_a_Borrador:
                                asientoId = new AsientosPagoDePersonasService((int)this.Id.Value).AsentarAprobadoABorrador(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Aprobado_a_Generacion:
                                asientoId = new AsientosOrdenDePagoService((int)this.Id.Value).AsentarAprobadoAGeneracion(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Generacion_a_Anulado:
                                asientoId = new AsientosOrdenDePagoService((int)this.Id.Value).AsentarGeneracionAAnulado(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Generacion_a_Cerrado:
                                asientoId = new AsientosOrdenDePagoService((int)this.Id.Value).AsentarGeneracionACerrado(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Aprobado_a_Generacion_UNIFICADO:
                                asientoId = new AsientosOrdenDePagoService((int)this.Id.Value).AsentarAprobadoAGeneracionUNIFICADO(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.OrdenDePago_Generacion_a_Anulado_UNIFICADO:
                                asientoId = new AsientosOrdenDePagoService((int)this.Id.Value).AsentarGeneracionAAnuladoUNIFICADO(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.Remisiones_Pendiente_a_Aprobado:
                                asientoId = new AsientosRemisionesService((int)this.Id.Value).AsentarPendienteAAprobado(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.Remisiones_Aprobado_a_Anulado:
                                asientoId = new AsientosRemisionesService((int)this.Id.Value).AsentarAprobadoAAnulado(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            case Definiciones.Contabilidad.AsientosAutomaticos.PlanillaLiquidaciones_Pendiente_a_Aprobado:
                                asientoId = new AsientosPlanillaLiquidacionesService((int)this.Id.Value).AsentarPendienteAAprobado(datos_caso, fechaAsiento, (decimal)drPeriodo[PeriodosService.Id_NombreCol], dtAsientoAutoDet, sesion);
                                break;
                            default:
                                throw new Exception("AsientosAutomaticosService.Generar() " + this.Nombre + " no implementado en orientación a objetos.");
                        }
                    }
                    catch
                    {
                        //Se permite continuar aunque no haya podido generarse el asiento
                    }

                    if (asientoId != Definiciones.Error.Valor.EnteroPositivo)
                    {
                        DataTable detalle = AsientosDetalleService.GetAsientosDetalleDataTable(AsientosDetalleService.CtbAsientoId_NombreCol + " = " + asientoId, string.Empty, sesion);
                        if (detalle.Rows.Count <= 0)
                        {
                            AsientosService.Borrar(asientoId, sesion);
                            return null;
                        }
                    }

                }

                return new AsientosService(asientoId, sesion);
            }
            catch (Exception exp)
            {
                return null;
            }
        }
        #endregion Generar

        #region EjecutarUnificarDetallesMismaCuenta
        public static void EjecutarUnificarDetallesMismaCuenta(decimal asientoCabeceraId, SessionService sesion)
        {
            var asientoCabecera = new AsientosService(asientoCabeceraId, sesion);
            var asientoDetalles = AsientosDetalleService.GetPorCabecera(asientoCabeceraId, sesion);

            var dDetallesPorCuenta = new Dictionary<decimal, List<AsientosDetalleService>>();
            
            //Agregar al diccionario la lista de detalles por cada cuenta contable
            for (int i = 0; i < asientoDetalles.Length; i++)
            {
                if (!dDetallesPorCuenta.ContainsKey(asientoDetalles[i].CtbCuentaId))
                    dDetallesPorCuenta.Add(asientoDetalles[i].CtbCuentaId, new List<AsientosDetalleService>());
                dDetallesPorCuenta[asientoDetalles[i].CtbCuentaId].Add(asientoDetalles[i]);
            }

            /*
             * Si existe más de un detalle para una misma cuenta, realizar la unificación:
             *      - encontrar el detalle con mayor monto para basarse en sus datos (observacion, moneda origen, etc.)
             *      - utilizar solo el debe o solo el haber
             *      - unificar la distribución por centro de costo
             *      - unificar relaciones del detalles (ctb_asientos_detalle_rel)
             */
            foreach (KeyValuePair<decimal, List<AsientosDetalleService>> item in dDetallesPorCuenta)
            {
                if (item.Value.Count <= 1)
                    continue;

                AsientosDetalleService detalleMayor = null;
                decimal montoMayor = 0;
                var ccHelper = new UnificacionCentroCostoHelper();
                var relacionesHelper = new UnificacionRelacionesHelper();

                #region hallar mayor detalle
                foreach (var d in item.Value)
                {
                    if(montoMayor < Math.Abs(d.Debe - d.Haber))
                    {
                        detalleMayor = d;
                        montoMayor = Math.Abs(d.Debe - d.Haber);
                    }
                }
                #endregion hallar mayor detalle

                #region inicializar campos
                if (!detalleMayor.MonedaOrigenId.HasValue)
                {
                    detalleMayor.MonedaOrigenId = detalleMayor.MonedaId;
                    detalleMayor.CotizacionMonedaOrigen = detalleMayor.CotizacionMoneda;
                }
                if (!detalleMayor.DebeOrigen.HasValue)
                    detalleMayor.DebeOrigen = 0;
                if (!detalleMayor.HaberOrigen.HasValue)
                    detalleMayor.HaberOrigen = 0;
                #endregion inicializar campos

                #region sumar debe y haber de detalles al detalle mayor
                foreach (var d in item.Value)
                {
                    if (d != detalleMayor)
                    {
                        detalleMayor.Debe += d.Debe;
                        detalleMayor.Haber += d.Haber;

                        if (detalleMayor.MonedaOrigenId.Value == (d.MonedaOrigenId ?? d.MonedaId))
                        {
                            detalleMayor.DebeOrigen += d.DebeOrigen ?? 0;
                            detalleMayor.HaberOrigen += d.HaberOrigen ?? 0;
                        }
                        else
                        {
                            detalleMayor.DebeOrigen += (d.DebeOrigen ?? 0 / d.CotizacionMonedaOrigen * detalleMayor.CotizacionMonedaOrigen);
                            detalleMayor.HaberOrigen += (d.HaberOrigen ?? 0 / d.CotizacionMonedaOrigen * detalleMayor.CotizacionMonedaOrigen);
                        }
                    }

                    var dtCentrosCosto = AsientosDetalleCentrosCostoService.GetAsientosDetalleCentrosCostoDataTable(AsientosDetalleCentrosCostoService.CtbAsientoDetalleId_NombreCol + " = " + d.Id, string.Empty, sesion);
                    ccHelper.Agregar(Math.Abs(d.Debe - d.Haber), dtCentrosCosto);

                    var dtRelaciones = AsientosDetalleRelacionesService.GetAsientosDetalleRelacionesDataTable(AsientosDetalleRelacionesService.CtbAsientosDetalle_NombreCol + " = " + d.Id, string.Empty, sesion);
                    relacionesHelper.Agregar(dtRelaciones, d.Debe > d.Haber);

                    //Se borra lo antes posible para no afectar el ordenamiento
                    AsientosDetalleService.Borrar(d.Id.Value, sesion);
                }
                #endregion sumar debe y haber de detalles al detalle mayor

                #region usar solo debe o haber
                if (detalleMayor.Debe > detalleMayor.Haber)
                {
                    detalleMayor.Debe -= detalleMayor.Haber;
                    detalleMayor.Haber = 0;
                }
                else
                {
                    detalleMayor.Haber -= detalleMayor.Debe;
                    detalleMayor.Debe = 0;
                }

                if (detalleMayor.DebeOrigen > detalleMayor.HaberOrigen)
                {
                    detalleMayor.DebeOrigen -= detalleMayor.HaberOrigen;
                    detalleMayor.HaberOrigen = 0;
                }
                else
                {
                    detalleMayor.HaberOrigen -= detalleMayor.DebeOrigen;
                    detalleMayor.DebeOrigen = 0;
                }
                #endregion usar solo debe o haber

                #region guardar detalle mayor
                var htDetalle = new Hashtable()
                {
                    { AsientosDetalleService.CtbAsientoId_NombreCol, detalleMayor.CtbAsientoId },
                    { AsientosDetalleService.CtbCuentaId_NombreCol, detalleMayor.CtbCuentaId },
                    { AsientosDetalleService.DebeOrigen_NombreCol, detalleMayor.DebeOrigen.Value },
                    { AsientosDetalleService.HaberOrigen_NombreCol, detalleMayor.HaberOrigen.Value },
                    { AsientosDetalleService.MonedaOrigenId_NombreCol, detalleMayor.MonedaOrigenId.Value },
                    { AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, detalleMayor.CotizacionMonedaOrigen.Value },
                    { AsientosDetalleService.MonedaId_NombreCol, detalleMayor.MonedaId },
                    { AsientosDetalleService.CotizacionMoneda_NombreCol, detalleMayor.CotizacionMoneda },
                    { AsientosDetalleService.Observacion_NombreCol, detalleMayor.Observacion },
                    { AsientosDetalleService.Debe_NombreCol, detalleMayor.Debe },
                    { AsientosDetalleService.Haber_NombreCol, detalleMayor.Haber }
                };

                var datosRelacionados = relacionesHelper.GetUnificado();
                if (datosRelacionados.Count > 0)
                    htDetalle.Add("datos_relacionados", datosRelacionados);

                AsientosDetalleService.Guardar(htDetalle, ccHelper.GetUnificado(), true, sesion);
                #endregion guardar detalle mayor
            }
        }
        #endregion EjecutarUnificarDetallesMismaCuenta

        #region clase EstructuraObservacionHelper
        public class EstructuraObservacionHelper
        {
            #region enum Campo
            public static class Campo
            {
                public const string CasoId = "CasoId";
                public const string CasoNroComprobante = "CasoNroComprobante";
                public const string Sucursal = "Sucursal";
                public const string Deposito = "Deposito";
                public const string Persona = "Persona";
                public const string Proveedor = "Proveedor";
                public const string FuncionarioCabecera = "FuncionarioCabecera";
                public const string FuncionarioDetalle = "FuncionarioDetalle";
                public const string ArticuloCodigo = "ArticuloCodigo";
                public const string ArticuloDescripcion = "ArticuloDescripcion";
                public const string FondoFijo = "FondoFijo";
                public const string CajaTesoreria = "CajaTesoreria";
                public const string TextoPredefinidoCabecera = "TextoPredefinidoCabecera";
                public const string TextoPredefinidoDetalle = "TextoPredefinidoDetalle";
                public const string ObservacionCabecera = "ObservacionCabecera";
                public const string ObservacionDetalle = "ObservacionDetalle";
                public const string CuentaBancaria = "CuentaBancaria";
                public const string Cantidad = "Cantidad";
                public const string CasoAsociado = "CasoAsociado";
                public const string Lote = "Lote";
                public const string DepositoOrigen = "DepositoOrigen";
                public const string DepositoDestino = "DepositoDestino";
            }
            #endregion enum Campo

            #region propiedades
            public const string tagOpen = "<t>";
            public const string tagClose = "</t>";
            public string observacion;

            public string[] Campos {
                get 
                {
                    string[] tokens = Regex.Split(this.observacion, @"<t>(.*?)</t>");
                    string[] resultado = new string[tokens.Length / 2];
                    
                    for (int i = 1; i < tokens.Length; i += 2)
                        resultado[i / 2] = tokens[i];

                    return resultado;
                } 
            }
            #endregion propiedades

            #region Constructores
            public EstructuraObservacionHelper(string estructura_base)
            {
                this.observacion = estructura_base;
            }
            #endregion Constructores

            #region Set
            public void Set(string campo, object valor)
            {
                string str = string.Empty;
                if (valor != null && valor != DBNull.Value)
                    str = valor.ToString();

                this.observacion = this.observacion.Replace(tagOpen + campo + tagClose, str);
            }
            #endregion Set
        }
        #endregion clase EstructuraObservacionHelper
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
