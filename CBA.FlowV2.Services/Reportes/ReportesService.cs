using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Reportes
{
    public class ReportesService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="reporte_id">The reporte_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal reporte_id)
        {
            using (SessionService sesion = new SessionService())
            {
                REPORTESRow reporte = sesion.Db.REPORTESCollection.GetRow(Id_NombreCol + " = " + reporte_id);
                return reporte.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetNombreReporte
        public static string GetNombreReporte(decimal reporte_id)
        {
            using (SessionService sesion = new SessionService())
            {
                decimal formatoReporteId = GetFormatoReporte(reporte_id, sesion);
                REPORTESRow reporte = sesion.Db.REPORTESCollection.GetRow(Id_NombreCol + " = " + reporte_id);

                if (formatoReporteId == Definiciones.FormatosReporte.CrystalReports)
                    return reporte.NOMBRE_FISICO;
                else
                    return reporte.RECURSO;
            }
        }

        public static string GetNombreFisico(decimal reporte_id)
        {
            using (SessionService sesion = new SessionService())
            {
                decimal formatoReporteId = GetFormatoReporte(reporte_id, sesion);
                REPORTESRow reporte = sesion.Db.REPORTESCollection.GetRow(Id_NombreCol + " = " + reporte_id);
                    
                return reporte.NOMBRE_FISICO;
            }
        }

        public static string GetRecurso(decimal reporte_id)
        {
            using (SessionService sesion = new SessionService())
            {
                decimal formatoReporteId = GetFormatoReporte(reporte_id, sesion);
                REPORTESRow reporte = sesion.Db.REPORTESCollection.GetRow(Id_NombreCol + " = " + reporte_id);

                return reporte.RECURSO;
            }
        }
        #endregion GetNombreReporte

        #region GetFormatoReporte
        public static int GetFormatoReporte(decimal reporte_id)
        {
            using (SessionService sesion = new SessionService())
            { 
                return GetFormatoReporte(reporte_id, sesion);
            }
        }

        public static int GetFormatoReporte(decimal reporte_id, SessionService sesion)
        {
            //Priorizar la configuracion del usuario y luego ver el dato en la tabla reportes
            DataTable dtConfiguracion = null;

            switch ((int)reporte_id)
            { 
                case Definiciones.Reportes.Tesoreria.FacturasdePersonasImpresion:
                    dtConfiguracion = CamposConfigurablesUsuariosService.GetValorDefinidoUsuarioDataTable(Definiciones.CamposConfigurablesItems.TablaReportes.FCClienteImpresion, sesion.Usuario.ID);
                    break;
                case Definiciones.Reportes.Tesoreria.NotaCreditoPersonaCaso:
                    dtConfiguracion = CamposConfigurablesUsuariosService.GetValorDefinidoUsuarioDataTable(Definiciones.CamposConfigurablesItems.TablaReportes.NCClienteImpresion, sesion.Usuario.ID);
                    break;
            }
            
            if (dtConfiguracion != null && dtConfiguracion.Rows.Count > 0)
            {
                return int.Parse((string)dtConfiguracion.Rows[0][CamposConfigurablesUsuariosService.VistaValor_NombreCol]);
            }
            else
            {
                REPORTESRow reporte = sesion.Db.REPORTESCollection.GetRow(Id_NombreCol + " = " + reporte_id);
                return (int)reporte.FORMATO_REPORTE_ID;
            }
        }
        #endregion GetFormatoReporte

        #region GetImpresora
        public static Definiciones.Impresora GetImpresora(int? campo_configurable_item_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CBA.FlowV2.Services.Base.Definiciones.Impresora impresora = null;

                if (campo_configurable_item_id.HasValue)
                {
                    var serializacion = CamposConfigurablesUsuariosService.GetValorDefinidoUsuarioTexto(campo_configurable_item_id.Value, sesion.Usuario_Id, sesion);
                    if (serializacion != Definiciones.Error.Valor.EnteroPositivo.ToString())
                        impresora = JsonUtil.Deserializar<CBA.FlowV2.Services.Base.Definiciones.Impresora>(serializacion);
                }

                if (impresora == null)
                {
                    impresora = new CBA.FlowV2.Services.Base.Definiciones.Impresora();
                    impresora.Tipo = CamposConfigurablesUsuariosService.GetValorGrupoUsuarioTexto(Definiciones.CamposConfigurablesGrupos.Impresoras, sesion.Usuario_Id);

                    if (impresora.Tipo == Definiciones.Error.Valor.EnteroPositivo.ToString())
                        impresora.Tipo = Definiciones.Impresoras[1];
                }

                return impresora;
            }
        }
        #endregion GetImpresora

        #region ReporteEsFormato
        public static bool ReporteEsFormato(decimal reporte_id, decimal formato)
        {
            using (SessionService sesion = new SessionService())
            {
                decimal formatoReporteId = GetFormatoReporte(reporte_id, sesion);
                return formatoReporteId == formato;
            }
        }
        #endregion ReporteEsFormato

        #region GetTituloReporte
        /// <summary>
        /// Gets the titulo reporte.
        /// </summary>
        /// <param name="reporte_id">The reporte_id.</param>
        /// <returns></returns>
        public static string GetTituloReporte(decimal reporte_id)
        {
            using (SessionService sesion = new SessionService())
            {
                REPORTESRow reporte = sesion.Db.REPORTESCollection.GetRow(Id_NombreCol + " = " + reporte_id);
                return reporte.NOMBRE;
            }
        }
        #endregion GetTituloReporte

        #region GetTipoReporteId
        public static decimal GetTipoReporteId(decimal reporte_id)
        {
            using (SessionService sesion = new SessionService())
            {
                REPORTESRow reporte = sesion.Db.REPORTESCollection.GetRow(Id_NombreCol + " = " + reporte_id);
                return reporte.TIPO_REPORTE_ID;
            }
        }
        #endregion GetTipoReporteId

        #region GetImpresionSilenciosaReporte
        /// <summary>
        /// Gets the impresion silenciosa reporte.
        /// </summary>
        /// <param name="reporte_id">The reporte_id.</param>
        /// <returns></returns>
        public static bool GetImpresionSilenciosaReporte(decimal reporte_id)
        {
            using (SessionService sesion = new SessionService())
            {
                REPORTESRow reporte = sesion.Db.REPORTESCollection.GetRow(Id_NombreCol + " = " + reporte_id);
                return reporte.IMPRESION_SILENCIOSA == Definiciones.SiNo.Si;
            }
        }
        #endregion GetImpresionSilenciosaReporte

        #region GetReportesDataTable
        /// <summary>
        /// Gets the reportes data table.
        /// </summary>
        /// <returns></returns>
        
        public static DataTable GetReportesDataTable(bool todos) { 
            using (SessionService sesion = new SessionService()){
                return sesion.Db.REPORTESCollection.GetAllAsDataTable();
                }
        }

        public static DataTable GetReportesDataTable()
        {
            return GetReportesDataTable(Definiciones.Error.Valor.EnteroPositivo, true);
        }

        /// <summary>
        /// Gets the reportes data table.
        /// </summary>
        /// <param name="tipo_reporte_id">The tipo_reporte_id.</param>
        /// <returns></returns>
        public static DataTable GetReportesDataTable(decimal tipo_reporte_id)
        {
            return GetReportesDataTable(tipo_reporte_id, true);
        }

        /// <summary>
        /// Gets the reportes data table.
        /// </summary>
        /// <param name="tipo_reporte_id">The tipo_reporte_id.</param>
        /// <returns></returns>
        public static DataTable GetReportesDataTable(decimal tipo_reporte_id, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = ReportesService.Id_NombreCol + " in (" + GetListaReportesSegunPermiso(tipo_reporte_id) + ") and " +
                               ReportesService.MostrarEnArbol_NombreCol + " = '" + Definiciones.SiNo.Si + "'";

                if (!tipo_reporte_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    where += " and " + ReportesService.TipoReporteId_NombreCol + " = " + tipo_reporte_id;
                }
                if (soloActivos)
                {
                    where += " and " + ReportesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                }

                return GetReportesDataTable(where, ReportesService.Nombre_NombreCol);
            }
        }

        /// <summary>
        /// Gets the reportes data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetReportesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.REPORTESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetReportesDataTable

        #region GetListaReportesSegunPermiso
        /// <summary>
        /// Obtener una cadena de id de reportes separados por coma. Si no hay ninguno se retorna la cadena "-1"
        /// </summary>
        /// <returns></returns>
        private static string GetListaReportesSegunPermiso(decimal tipo_reporte_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string sql = " " +
                    " select nvl(RTRIM(XMLAGG(XMLELEMENT(e, id || ', ')).EXTRACT('//text()'), ', '), -1) lista " +
                    "   from (" +
                    " select r.id " +
                    "   from permisos_reportes pr, reportes r " +
                    "  where pr.tipo_reporte_id = r.tipo_reporte_id " +
                    "    and pr.tipo_reporte_id = " + tipo_reporte_id +
                    "    and (pr.reporte_id = r.id or pr.reporte_id is null) " +
                    "    and (pr.usuario_id = " + sesion.Usuario.ID + " or pr.usuario_id is null) " +
                    "    and (pr.rol_id in (select rol_id from usuarios_roles " +
                    "                           where usuario_id = " + sesion.Usuario.ID + ") " +
                    "         or pr.rol_id is null) " +
                    "    and (pr.sucursal_id = " + sesion.SucursalActiva.ID + " or pr.sucursal_id is null) " +
                    "    and (pr.entidad_id = " + sesion.SucursalActiva.ENTIDAD_ID + " or pr.entidad_id is null) " +
                    "    and (pr.fecha_fin >= to_date(to_char(sysdate, 'dd/mm/yyyy'), 'dd/mm/yyyy') or pr.fecha_fin is null) " +
                    "   group by r.id)";

                //Se ejecuta la consulta
                DataTable dtResultado = sesion.Db.EjecutarQuery(sql);

                //Se retorna la lista de id de reportes
                return (string)dtResultado.Rows[0][0];
            }
        }
        #endregion GetListaReportesSegunPermiso

        #region Metodos estaticos
        public static string Nombre_Tabla
        {
            get { return "REPORTES"; }
        }
        public static string Estado_NombreCol
        {
            get { return REPORTESCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return REPORTESCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return REPORTESCollection.NOMBREColumnName; }
        }
        public static string NombreFisico_NombreCol
        {
            get { return REPORTESCollection.NOMBRE_FISICOColumnName; }
        }
        public static string Recurso_NombreCol
        {
            get { return REPORTESCollection.RECURSOColumnName; }
        }
        public static string TipoReporteId_NombreCol
        {
            get { return REPORTESCollection.TIPO_REPORTE_IDColumnName; }
        }
        public static string MostrarEnArbol_NombreCol
        {
            get { return REPORTESCollection.MOSTRAR_EN_ARBOLColumnName; }
        }
        public static string FormatoReporteId_NombreCol
        {
            get { return REPORTESCollection.FORMATO_REPORTE_IDColumnName; }
        }
        #endregion Metodos estaticos

        #region GetLinkableReporte
        public static string GetLinkableReporte(decimal reporte_id)
        {
            using (SessionService sesion = new SessionService())
            {
                REPORTESRow reporte = sesion.Db.REPORTESCollection.GetRow(Id_NombreCol + " = " + reporte_id);
                return reporte.LINKABLE;
            }
        }
        #endregion GetPrevisualizarReporte
    }
}
