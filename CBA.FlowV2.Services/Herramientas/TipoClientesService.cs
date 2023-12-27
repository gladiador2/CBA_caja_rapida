using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Common;

namespace CBA.FlowV2.Services.Herramientas
{
    public class TipoClientesService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="tipoclientes_id">The tipoClientes_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal tipoClientes_id)
        {
            using (SessionService sesion = new SessionService())
            {
                TIPOS_CLIENTESRow row = sesion.Db.TIPOS_CLIENTESCollection.GetRow(ID_ColumnName + " = " + tipoClientes_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetTipoClientesDataTable
        /// <summary>
        /// Gets the tipoClientes data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTipoClientesDataTable()
        {
            return GetTipoClientesDataTable(string.Empty, "upper(" + Nombre_ColumnName + ")", false);
        }

        /// <summary>
        /// Gets the tipoClientes data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTipoClientesDataTable(String clausulas, String orden) 
        {
            return GetTipoClientesDataTable(clausulas, orden, true);
        }

        /// <summary>
        /// Gets the tipoClientes data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetTipoClientesDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = Estado_ColumnName+"  = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.TIPOS_CLIENTESCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.TIPOS_CLIENTESCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetTipoClientesDataTable

        #region GetTipoClientesActivos
        /// <summary>
        /// Gets the articulosMarcas activos.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTipoClientesActivos()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.TIPOS_CLIENTESCollection.GetAsDataTable(Estado_ColumnName+" ='"+Definiciones.Estado.Activo+"' ", "upper("+Nombre_ColumnName+")");
                return table;
            }
        }
        #endregion GetTipoClientesActivos

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    TIPOS_CLIENTESRow row = new TIPOS_CLIENTESRow();
                    String valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("tipos_clientes_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.TIPOS_CLIENTESCollection.GetRow(ID_ColumnName+" = " + decimal.Parse((string)campos[ID_ColumnName]));
                        valorAnterior = row.ToString();
                    }

                    row.CODIGO = (string)campos[Codigo_ColumnName];
                    row.NOMBRE = (string)campos[Nombre_ColumnName];
                    row.OBSERVACION = (string)campos[Observacion_ColumnName];
                    row.ESTADO = (string)campos[Estado_ColumnName];
                    row.ENTIDAD_ID = decimal.Parse(sesion.EntidadActual_Id);

                    if (insertarNuevo) sesion.Db.TIPOS_CLIENTESCollection.Insert(row);
                    else sesion.Db.TIPOS_CLIENTESCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

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

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TIPOS_CLIENTES"; }
        }
        public static string ID_ColumnName
        {
            get { return TIPOS_CLIENTESCollection.IDColumnName; }
        }
        public static string Codigo_ColumnName
        {
            get { return TIPOS_CLIENTESCollection.CODIGOColumnName;  }
        }
        public static string Nombre_ColumnName
        {
            get { return TIPOS_CLIENTESCollection.NOMBREColumnName; }
        }
        public static string Observacion_ColumnName
        {
            get { return TIPOS_CLIENTESCollection.OBSERVACIONColumnName; }
        }
        public static string Estado_ColumnName
        {
            get { return TIPOS_CLIENTESCollection.ESTADOColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region Propiedades
        protected TIPOS_CLIENTESRow row;
        protected TIPOS_CLIENTESRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Codigo { get { return row.CODIGO; } set { row.CODIGO = value; } }
        public decimal EntidadId { get { return row.ENTIDAD_ID; } set { row.ENTIDAD_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        public string Observacion { get { return Interprete.EsNullODBNull(row.OBSERVACION) ? string.Empty : row.OBSERVACION; } set { row.OBSERVACION = value; } }
        #endregion Propiedades
        
        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.TIPOS_CLIENTESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new TIPOS_CLIENTESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public TipoClientesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public TipoClientesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public TipoClientesService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        #endregion Constructores
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
