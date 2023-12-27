using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Herramientas
{
    public class TransicionesService
    {
        #region GetTransicionesDataTable
        /// <summary>
        /// Gets the transiciones data table.
        /// </summary>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <returns></returns>
        public DataTable GetTransicionesDataTable(decimal flujo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = TransicionesService.EntidadId_NombreCol + " = " + sesion.Entidad.ID + " and " + TransicionesService.Estado_NombreCol + " = 'A' ";
                if(!flujo_id.Equals(Definiciones.IdNull)) clausula += " and " + TransicionesService.FlujoId_NombreCol + " = " + flujo_id;

                return this.GetTransicionesDataTable(clausula, TransicionesService.Orden_NombreCol);
            }
        }

        public static DataTable GetTransicionesDataTable2(decimal flujo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = TransicionesService.EntidadId_NombreCol + " = " + sesion.Entidad.ID + " and " + TransicionesService.Estado_NombreCol + " = 'A' ";
                if (!flujo_id.Equals(Definiciones.IdNull)) clausula += " and " + TransicionesService.FlujoId_NombreCol + " = " + flujo_id;

                return sesion.db.TRANSICIONESCollection.GetAsDataTable(clausula, TransicionesService.Orden_NombreCol);
            }
        }

        /// <summary>
        /// Gets the transiciones data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetTransicionesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = TransicionesService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
                if (clausulas.Length > 0) where += " and " + clausulas;

                return sesion.Db.TRANSICIONESCollection.GetAsDataTable(where, string.Empty);
            }
        }
        #endregion GetTransicionesDataTable

        #region GetFlujoId
        /// <summary>
        /// Gets the flujo id.
        /// </summary>
        /// <param name="transicion_id">The transicion_id.</param>
        /// <returns></returns>
        public decimal GetFlujoId(decimal transicion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                TRANSICIONESRow row = sesion.Db.TRANSICIONESCollection.GetByPrimaryKey(transicion_id);
                return row.FLUJO_ID;
            }
        }

        #endregion GetFlujoId

        #region GetTransicionSegunFlujoYEstados
        /// <summary>
        /// Gets the transicion segun flujo Y estados.
        /// </summary>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="estado_origen">The estado_origen.</param>
        /// <param name="estado_destino">The estado_destino.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal GetTransicionSegunFlujoYEstados(decimal flujo_id, string estado_origen, string estado_destino, SessionService sesion)
        {
            string clausulas = TransicionesService.FlujoId_NombreCol + " = " + flujo_id + " and " +
                               TransicionesService.EstadoOrigenId_NombreCol + " = '" + estado_origen + "' and " +
                               TransicionesService.EstadoDestinoId_NombreCol + " = '" + estado_destino + "'";

            TRANSICIONESRow[] row = sesion.db.TRANSICIONESCollection.GetAsArray(clausulas, TransicionesService.Id_NombreCol);

            if (row.Length > 0)
                return row[0].ID;
            else
                return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion GetTransicionSegunFlujoYEstados

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TRANSICIONES"; }
        }
        public static string AsignacionCasoObligatoria_NombreCol
        {
            get { return TRANSICIONESCollection.ASIGNACION_CASO_OBLIGATORIOColumnName; }
        }
        public static string EntidadId_NombreCol
        {
            get { return TRANSICIONESCollection.ENTIDAD_IDColumnName; }
        }
        public static string EstadoDestinoId_NombreCol
        {
            get { return TRANSICIONESCollection.ESTADO_DESTINO_IDColumnName; }
        }
        public static string EstadoOrigenId_NombreCol
        {
            get { return TRANSICIONESCollection.ESTADO_ORIGEN_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return TRANSICIONESCollection.ESTADOColumnName; }
        }
        public static string FlujoId_NombreCol
        {
            get { return TRANSICIONESCollection.FLUJO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return TRANSICIONESCollection.IDColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return TRANSICIONESCollection.ORDENColumnName; }
        }
        public static string RolId_NombreCol
        {
            get { return TRANSICIONESCollection.ROL_IDColumnName; }
        }
        public static string SQL_NombreCol
        {
            get { return TRANSICIONESCollection.SQLColumnName; }
        }

        public static string ComentarioObligatorio_NombreCol
        {
            get { return TRANSICIONESCollection.COMENTARIO_OBLIGATORIOColumnName; }
        }

        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region Propiedades
        protected TRANSICIONESRow row;
        protected TRANSICIONESRow rowSinModificar;
        public class Modelo : TRANSICIONESCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string AsignacionCasoObligatorio { get { return ClaseCBABase.GetStringHelper(row.ASIGNACION_CASO_OBLIGATORIO); } set { row.ASIGNACION_CASO_OBLIGATORIO = value; } }
        public string ComentarioObligatorio { get { return ClaseCBABase.GetStringHelper(row.COMENTARIO_OBLIGATORIO); } set { row.COMENTARIO_OBLIGATORIO = value; } }
        public decimal EntidadId { get { return row.ENTIDAD_ID; } set { row.ENTIDAD_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public string EstadoDestinoId { get { return row.ESTADO_DESTINO_ID; } set { row.ESTADO_DESTINO_ID = value; } }
        public string EstadoOrigenId { get { return row.ESTADO_ORIGEN_ID; } set { row.ESTADO_ORIGEN_ID = value; } }
        public decimal FlujoId { get { return row.FLUJO_ID; } set { row.FLUJO_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? Orden { get { if (row.IsORDENNull) return null; else return row.ORDEN; } set { if (value.HasValue) row.ORDEN = value.Value; else row.IsORDENNull = true; } }
        public decimal RolId { get { return row.ROL_ID; } set { row.ROL_ID = value; } }
        public string SQL { get { return ClaseCBABase.GetStringHelper(row.SQL); } set { row.SQL = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private FlujosService _flujo;
        public FlujosService Flujo
        {
            get
            {
                if (this._flujo == null)
                    this._flujo = new FlujosService(this.FlujoId);
                return this._flujo;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.TRANSICIONESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new TRANSICIONESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(TRANSICIONESRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public TransicionesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public TransicionesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public TransicionesService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        private TransicionesService(TRANSICIONESRow row)
        {
            Inicializar(row);
        }
        public TransicionesService(decimal flujo_id, string estado_origen_id, string estado_destino_id, SessionService sesion)
        {
            string clausulas = TRANSICIONESCollection.FLUJO_IDColumnName + " = " + flujo_id + " and " +
                               TRANSICIONESCollection.ESTADO_ORIGEN_IDColumnName + " = '" + estado_origen_id + "' and " +
                               TRANSICIONESCollection.ESTADO_DESTINO_IDColumnName + " = '" + estado_destino_id + "'";
            TRANSICIONESRow[] rows = sesion.db.TRANSICIONESCollection.GetAsArray(clausulas, TRANSICIONESCollection.ORDENColumnName);
            if (rows.Length > 0)
                Inicializar(rows[0]);
            else
                Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
        }
        #endregion Constructores
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
