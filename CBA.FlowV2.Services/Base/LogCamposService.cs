using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Base
{
    public class LogCamposService : ClaseCBA<LogCamposService>
    {
        #region Propiedades
        protected LOG_CAMPOSRow row;
        protected LOG_CAMPOSRow rowSinModificar;
        public class Modelo : LOG_CAMPOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string CampoId { get { return GetStringHelper(row.CAMPO_ID); } set { row.CAMPO_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string TablaId { get { return GetStringHelper(row.TABLA_ID); } set { row.TABLA_ID = value; } }
        public string TipoDato { get { return GetStringHelper(row.TIPO_DATO); } set { row.TIPO_DATO = value; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.LOG_CAMPOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new LOG_CAMPOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(LOG_CAMPOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public LogCamposService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public LogCamposService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public LogCamposService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private LogCamposService(LOG_CAMPOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            try
            {
                //No debe poder crearse ni guardarse cambios
                return Definiciones.Error.Valor.EnteroPositivo;
            }
            catch
            {
                throw;
            }
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();
            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override LogCamposService[] Buscar(Filtro[] filtros)
        {
            //Debe existir el filtro de caso, o el conjunto tabla y registro
            Filtro fTabla, fCampo;
            fTabla = Array.Find(filtros, delegate(Filtro filtro) { return filtro.Columna == Modelo.TABLA_IDColumnName; });
            fCampo = Array.Find(filtros, delegate(Filtro filtro) { return filtro.Columna == Modelo.CAMPO_IDColumnName; });
                
            if (fTabla == null)
                throw new Exception(this.GetType().ToString() + ".Buscar(). Debe filtrar por tabla.");

            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");

            foreach (Filtro f in filtros)
            {
                if (f.OrderBy)
                {
                    orden.Add(f.Columna + " " + f.Valor);
                }
                else
                {
                    sb.Append(" and ");
                    switch (f.Columna)
                    {
                        case Modelo.IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.CAMPO_IDColumnName:
                        case Modelo.TABLA_IDColumnName:
                        case Modelo.TIPO_DATOColumnName:
                            sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(LOG_CAMPOSCollection.CAMPO_IDColumnName + " desc");
            LOG_CAMPOSRow[] rows = sesion.db.LOG_CAMPOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            LogCamposService[] lc = new LogCamposService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                lc[i] = new LogCamposService(rows[i]);

            return lc;
        }
        #endregion Buscar

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return this.ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            throw new NotImplementedException("Falta implementar.");
        }
        #endregion ToEDI

        #region Accessors
        public static string Nombre_Tabla = "LOG_CAMPOS";
        public static string Nombre_Secuencia = "LOG_CAMPOS_SQC";
        #endregion Accessors

        #region CODIGO VIEJO
        #region GetLogCamposDataTable
        /// <summary>
        /// Gets the log campos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetLogCamposDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.LOG_CAMPOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetLogCamposDataTable

        #region GetLogCampos
        /// <summary>
        /// Gets the log campos.
        /// </summary>
        /// <param name="tabla">The tabla.</param>
        /// <param name="columna">The columna.</param>
        /// <returns></returns>
        public static decimal GetLogCampos(string tabla, string columna)
        {
            string clausulas = LogCamposService.TablaId_NombreCol + " = '" + tabla + "' and ";

            if (columna.Length > 0)
                clausulas += LogCamposService.CampoId_NombreCol + " = '" + columna + "' and ";
            else
                clausulas += LogCamposService.CampoId_NombreCol + " is null";

            DataTable dt = LogCamposService.GetLogCamposDataTable(clausulas, string.Empty);
            
            if (dt.Rows.Count <= 0)
                throw new Exception("LogCamposService.GetLogCampos(). Campo no encontrado.");

            return (decimal)dt.Rows[0][LogCamposService.Id_NombreCol];
        }
        #endregion GetLogCampos

        #region GetTabla

        /// <summary>
        /// Gets the tabla.
        /// </summary>
        /// <param name="log_campos_id">The log_campos_id.</param>
        /// <returns></returns>
        public string GetTabla(decimal log_campos_id)
        {
            using (SessionService sesion = new SessionService())
            {
                LOG_CAMPOSRow row = sesion.Db.LOG_CAMPOSCollection.GetByPrimaryKey(log_campos_id);
                return row.TABLA_ID;
            }
        }

        #endregion GetTabla

        #region Accessors
        public static string CampoId_NombreCol
        {
            get { return LOG_CAMPOSCollection.CAMPO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return LOG_CAMPOSCollection.IDColumnName; }
        }
        public static string TablaId_NombreCol
        {
            get { return LOG_CAMPOSCollection.TABLA_IDColumnName; }
        }
        public static string TipoDato_NombreCol
        {
            get { return LOG_CAMPOSCollection.TIPO_DATOColumnName; }
        }
        #endregion Accessors
        #endregion CODIGO VIEJO
    }
}
