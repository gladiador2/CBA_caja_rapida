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
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Tesoreria;
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class PlanesFacturacionEtapasService
    {
        #region GetPlanesFacturacionEtapasDataTable
        /// <summary>
        /// Gets the planes facturacion etapas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPlanesFacturacionEtapasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PLANES_FACTURACION_ETAPASCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPlanesFacturacionEtapasDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PLANES_FACTURACION_ETAPASRow row = new PLANES_FACTURACION_ETAPASRow();
                    string valorAnterior = Definiciones.Log.RegistroNuevo;
                    bool reordenar = false;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("planes_facturacion_etapas_sqc");
                        row.PLAN_FACTURACION_ID = (decimal)campos[PlanesFacturacionEtapasService.PlanFacturacionId_NombreCol];
                    }
                    else
                    {
                        row = sesion.Db.PLANES_FACTURACION_ETAPASCollection.GetByPrimaryKey((decimal)campos[PlanesFacturacionEtapasService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = (string)campos[PlanesFacturacionEtapasService.Nombre_NombreCol];
                    row.CONDICION_PAGO_ID = (decimal)campos[PlanesFacturacionEtapasService.CondicionPagoId_NombreCol];
                    row.INTERVALO = (decimal)campos[PlanesFacturacionEtapasService.Intervalo_NombreCol];
                    row.TIPO_INTERVALO = (string)campos[PlanesFacturacionEtapasService.TipoIntervalo_NombreCol];

                    if (campos.Contains(PlanesFacturacionEtapasService.ListaPrecioId_NombreCol))
                        row.LISTA_PRECIO_ID = (decimal)campos[PlanesFacturacionEtapasService.ListaPrecioId_NombreCol];
                    else
                        row.IsLISTA_PRECIO_IDNull = true;

                    if (campos.Contains(PlanesFacturacionEtapasService.FechaEstimadaInicio_NombreCol))
                        row.FECHA_ESTIMADA_INICIO = (DateTime)campos[PlanesFacturacionEtapasService.FechaEstimadaInicio_NombreCol];
                    else
                        row.IsFECHA_ESTIMADA_INICIONull = true;

                    if (campos.Contains(PlanesFacturacionEtapasService.FechaEstimadaFin_NombreCol))
                        row.FECHA_ESTIMADA_FIN = (DateTime)campos[PlanesFacturacionEtapasService.FechaEstimadaFin_NombreCol];
                    else
                        row.IsFECHA_ESTIMADA_FINNull = true;

                    if (campos.Contains(PlanesFacturacionEtapasService.FechaFacturacionDesde_NombreCol))
                        row.FECHA_FACTURACION_DESDE = (DateTime)campos[PlanesFacturacionEtapasService.FechaFacturacionDesde_NombreCol];
                    else
                        row.IsFECHA_FACTURACION_DESDENull = true;

                    if (campos.Contains(PlanesFacturacionEtapasService.FechaFacturacionHasta_NombreCol))
                        row.FECHA_FACTURACION_HASTA = (DateTime)campos[PlanesFacturacionEtapasService.FechaFacturacionHasta_NombreCol];
                    else
                        row.IsFECHA_FACTURACION_HASTANull = true;

                    if(!row.IsFECHA_FACTURACION_DESDENull && !row.IsFECHA_FACTURACION_HASTANull)
                    {
                        if (row.FECHA_FACTURACION_HASTA.Date < row.FECHA_FACTURACION_DESDE.Date)
                            throw new Exception("Las fechas de inicio de facturación no puede ser posterior a la de finalización.");
                    }

                    if (campos[PlanesFacturacionEtapasService.Orden_NombreCol].Equals(DBNull.Value) || !row.ORDEN.Equals(campos[PlanesFacturacionEtapasService.Orden_NombreCol]))
                    {
                        reordenar = true;
                        row.ORDEN = (decimal)campos[PlanesFacturacionEtapasService.Orden_NombreCol];
                    }

                    if (campos.Contains(PlanesFacturacionEtapasService.MoraPorcentaje_NombreCol))
                        row.MORA_PORCENTAJE = (decimal)campos[PlanesFacturacionEtapasService.MoraPorcentaje_NombreCol];
                    else
                        row.MORA_PORCENTAJE = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FacturaClientePorcentajeMora);

                    if (campos.Contains(PlanesFacturacionEtapasService.AutonumeracionFacturaId_NombreCol))
                        row.AUTONUMERACION_FACTURA_ID = (decimal)campos[PlanesFacturacionEtapasService.AutonumeracionFacturaId_NombreCol];
                    else
                        row.IsAUTONUMERACION_FACTURA_IDNull = true;

                    if (campos.Contains(PlanesFacturacionEtapasService.MoraPorcentaje_NombreCol))
                        row.MORA_DIAS_GRACIA = (decimal)campos[PlanesFacturacionEtapasService.MoraDiasGracia_NombreCol];
                    else
                        row.MORA_DIAS_GRACIA = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarMoraFCDesdeDias);

                    if (insertarNuevo) sesion.Db.PLANES_FACTURACION_ETAPASCollection.Insert(row);
                    else sesion.Db.PLANES_FACTURACION_ETAPASCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    if (reordenar)
                        ReordenarEtapas(row, sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified plan_facturacion_etapa_id.
        /// </summary>
        /// <param name="plan_facturacion_etapa_id">The plan_facturacion_etapa_id.</param>
        public static void Borrar(decimal plan_facturacion_etapa_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    PLANES_FACTURACION_ETAPASRow row = sesion.Db.PLANES_FACTURACION_ETAPASCollection.GetByPrimaryKey(plan_facturacion_etapa_id);

                    DataTable dtDetalles = PlanesFacturacionEtapasDetallesService.GetPlanesFacturacionEtapasDetallesDataTable(PlanesFacturacionEtapasDetallesService.PlanFacturacionEtapaId_NombreCol + " = " + row.ID, string.Empty);
                    //Se borran todos los detalles asociados
                    for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        PlanesFacturacionEtapasDetallesService.Borrar((decimal)dtDetalles.Rows[i][PlanesFacturacionEtapasDetallesService.Id_NombreCol]);

                    sesion.Db.PLANES_FACTURACION_ETAPASCollection.Delete(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    row.ORDEN = Definiciones.Error.Valor.EnteroPositivo; //Se modifica el orden para que no afecte al reordenamiento
                    ReordenarEtapas(row, sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region ActualizarUltimaFCCreada
        /// <summary>
        /// Actualizars the ultima FC creada.
        /// </summary>
        /// <param name="plan_facturacion_etapa_id">The plan_facturacion_etapa_id.</param>
        /// <param name="ultimo_caso_id">The ultimo_caso_id.</param>
        /// <param name="ultima_fecha">The ultima_fecha.</param>
        public static void ActualizarUltimaFCCreada(decimal plan_facturacion_etapa_id, decimal ultimo_caso_id, DateTime ultima_fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                ActualizarUltimaFCCreada(plan_facturacion_etapa_id, ultimo_caso_id, ultima_fecha, sesion);
            }
        }

        public static void ActualizarUltimaFCCreada(decimal plan_facturacion_etapa_id, decimal ultimo_caso_id, DateTime ultima_fecha, SessionService sesion)
        {
            PLANES_FACTURACION_ETAPASRow row = sesion.Db.PLANES_FACTURACION_ETAPASCollection.GetByPrimaryKey(plan_facturacion_etapa_id);
            row.ULTIMA_FC_CREADA_CASO_ID = ultimo_caso_id;
            row.ULTIMA_FC_CREADA_FECHA = ultima_fecha;
            sesion.Db.PLANES_FACTURACION_ETAPASCollection.Update(row);
        }

        public static void ActualizarProximaFC(decimal plan_facturacion_etapa_id, decimal intervalo, char tipoIntervalo, DateTime fechaActual)
        {
            using (SessionService sesion = new SessionService())
            {
                ActualizarProximaFC(plan_facturacion_etapa_id, intervalo, tipoIntervalo, fechaActual, sesion);
            }
        }

        public static void ActualizarProximaFC(decimal plan_facturacion_etapa_id, decimal intervalo, char tipoIntervalo, DateTime fechaActual, SessionService sesion)
        {
            PLANES_FACTURACION_ETAPASRow row = sesion.Db.PLANES_FACTURACION_ETAPASCollection.GetByPrimaryKey(plan_facturacion_etapa_id);

            if (!row.IsFECHA_FACTURACION_DESDENull && !row.IsULTIMA_FC_CREADA_FECHANull)
            {
                int diaFacturas = row.FECHA_FACTURACION_DESDE.Day;
                int mesUltimaFactura = row.ULTIMA_FC_CREADA_FECHA.Month;
                int anoUltimaFactura = row.ULTIMA_FC_CREADA_FECHA.Year;

                DateTime fechaTemporal = new DateTime(anoUltimaFactura, mesUltimaFactura, diaFacturas);

                while (fechaTemporal < fechaActual || fechaTemporal == fechaActual)
                {
                    fechaTemporal = CalcularSiguienteFecha(tipoIntervalo, fechaTemporal, intervalo);
                }

                row.PROXIMA_FECHA = fechaTemporal;
            }
            else
            {
                row.PROXIMA_FECHA = CalcularSiguienteFecha(tipoIntervalo, fechaActual, intervalo);
            }

            if (!DiasSemanaService.EsFechaLaborable(row.PROXIMA_FECHA))
                row.PROXIMA_FECHA = DiasSemanaService.GetSiguienteFechaLaborable(row.PROXIMA_FECHA);

            sesion.Db.PLANES_FACTURACION_ETAPASCollection.Update(row);
        }
        #endregion ActualizarUltimaFCCreada

        #region CalcularSiguienteFecha
        private static DateTime CalcularSiguienteFecha(char tipoIntervalo, DateTime fecha, decimal intervalo)
        {
            switch (tipoIntervalo)
            {
                case 'D':
                    fecha = fecha.AddDays((double)intervalo);
                    break;

                case 'S':
                    intervalo *= 7;
                    fecha = fecha.AddDays((double)intervalo);
                    break;

                case 'M':
                    fecha = fecha.AddMonths((int)intervalo);
                    break;

                case 'A':
                    fecha = fecha.AddYears((int)intervalo);
                    break;
            }

            return fecha;
        }
        #endregion CalcularSiguienteFecha

        #region ReordenarEtapas
        /// <summary>
        /// Reordenars the etapas.
        /// </summary>
        /// <param name="row_editada">The row_editada.</param>
        /// <param name="sesion">The sesion.</param>
        private static void ReordenarEtapas(PLANES_FACTURACION_ETAPASRow row_editada, SessionService sesion)
        {
            PLANES_FACTURACION_ETAPASRow[] rows = sesion.Db.PLANES_FACTURACION_ETAPASCollection.GetAsArray(PlanesFacturacionEtapasService.PlanFacturacionId_NombreCol + " = " + row_editada.PLAN_FACTURACION_ID, PlanesFacturacionEtapasService.Orden_NombreCol);
            decimal orden = 0;

            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].ID == row_editada.ID)
                    continue;

                if (orden + 1 == row_editada.ORDEN)
                    orden++;

                rows[i].ORDEN = ++orden;
                sesion.Db.PLANES_FACTURACION_ETAPASCollection.Update(rows[i]);
            }
        }
        #endregion ReordenarEtapas

        #region Accesors

        public static string Nombre_Tabla
        {
            get { return "PLANES_FACTURACION_ETAPAS"; }
        }
        public static string AutonumeracionFacturaId_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.AUTONUMERACION_FACTURA_IDColumnName; }
        }
        public static string CondicionPagoId_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.CONDICION_PAGO_IDColumnName; }
        }
        public static string FechaEstimadaFin_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.FECHA_ESTIMADA_FINColumnName; }
        }
        public static string FechaEstimadaInicio_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.FECHA_ESTIMADA_INICIOColumnName; }
        }
        public static string FechaFacturacionDesde_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.FECHA_FACTURACION_DESDEColumnName; }
        }
        public static string FechaFacturacionHasta_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.FECHA_FACTURACION_HASTAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.IDColumnName; }
        }
        public static string Intervalo_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.INTERVALOColumnName; }
        }
        public static string ListaPrecioId_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.LISTA_PRECIO_IDColumnName; }
        }
        public static string MoraDiasGracia_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.MORA_DIAS_GRACIAColumnName; }
        }

        public static string MoraPorcentaje_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.MORA_PORCENTAJEColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.NOMBREColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.ORDENColumnName; }
        }
        public static string PlanFacturacionId_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.PLAN_FACTURACION_IDColumnName; }
        }
        public static string TipoIntervalo_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.TIPO_INTERVALOColumnName; }
        }
        public static string UltimaFCCreadaCasoId_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.ULTIMA_FC_CREADA_CASO_IDColumnName; }
        }
        public static string UltimaFCCreadaFecha_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.ULTIMA_FC_CREADA_FECHAColumnName; }
        }
        public static string ProximaFecha_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPASCollection.PROXIMA_FECHAColumnName; }
        }
        #endregion Accesors
    }
}
