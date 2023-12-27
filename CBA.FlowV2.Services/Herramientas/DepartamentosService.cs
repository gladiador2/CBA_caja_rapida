using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class DepartamentosService
    {
        #region EstaActivo
        public static bool EstaActivo(decimal departamento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DEPARTAMENTOSRow departamento = sesion.Db.DEPARTAMENTOSCollection.GetRow(Id_NombreCol+"= " + departamento_id);
                return departamento.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetDepartamentosDataTable
        /// <summary>
        /// Gets the departamentos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetDepartamentosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.DEPARTAMENTOSCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        
        public static DataTable GetDepartamentosDataTable(Decimal pais_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.DEPARTAMENTOSCollection.GetAsDataTable(PaisId_NombreCol+" = " + pais_id, "upper("+Nombre_NombreCol+")");
                return table;
            }
        }

        public static DataTable GetDepartamentosDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.DEPARTAMENTOSCollection.GetAsDataTable(PaisId_NombreCol + " = " + sesion.SucursalActiva_pais_id, "upper(" + Nombre_NombreCol + ")");
                return table;
            }
        }

        /// <summary>
        /// Gets the departamentos data table with an user-specific where and order clauses.
        /// </summary>
        /// <param name="clausulas">The where string.</param>
        /// <param name="orden">The ordering string.</param>
        /// <param name="soloActivos">Si es true se obtienen solo los activos.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetDepartamentosDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = Estado_NombreCol+" = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.DEPARTAMENTOSCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.DEPARTAMENTOSCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetDepartamentosDataTable

        #region GetNombre
        public String GetNombre(Decimal departamento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DEPARTAMENTOSRow dpto = sesion.Db.DEPARTAMENTOSCollection.GetRow(Id_NombreCol+"= " + departamento_id);
                return dpto.NOMBRE;
            }
        }
        #endregion GetNombre

        #region GetAbreviatura
        public String GetAbreviatura(Decimal departamento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DEPARTAMENTOSRow dpto = sesion.Db.DEPARTAMENTOSCollection.GetRow(Id_NombreCol+" = " + departamento_id);
                return dpto.ABREVIATURA;
            }
        }
        #endregion GetAbreviatura

        public DataTable GetDepartamento(decimal departamento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DEPARTAMENTOSCollection.GetAsDataTable(Id_NombreCol+"= " + departamento_id, "");
            }
        }

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    DEPARTAMENTOSRow departamento = new DEPARTAMENTOSRow();
                    String valorAnterior = string.Empty;
                    Decimal aux;

                    if (insertarNuevo)
                    {
                        departamento.ID = sesion.Db.GetSiguienteSecuencia("departamentos_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        departamento = sesion.Db.DEPARTAMENTOSCollection.GetRow(Id_NombreCol+" = " + decimal.Parse((string)campos[Id_NombreCol]));
                        valorAnterior = departamento.ToString();
                    }

                    departamento.NOMBRE = (string)campos[Nombre_NombreCol];
                    departamento.ABREVIATURA = (string)campos[Abreviatura_NombreCol];
                    departamento.ESTADO = (string)campos[Estado_NombreCol];

                    aux = Decimal.Parse((string)campos[PaisId_NombreCol]);
                    if (departamento.PAIS_ID != aux)
                    {
                        if (PaisesService.EstaActivo(aux)) departamento.PAIS_ID = aux;
                        else throw new System.ArgumentException("El país seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }

                    if (insertarNuevo) sesion.Db.DEPARTAMENTOSCollection.Insert(departamento);
                    else sesion.Db.DEPARTAMENTOSCollection.Update(departamento);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, departamento.ID, valorAnterior, departamento.ToString(), sesion);

                    sesion.Db.CommitTransaction();

                    return departamento.ID;
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
            get { return "DEPARTAMENTOS"; }
        }
        public static string Abreviatura_NombreCol
        {
            get { return DEPARTAMENTOSCollection.ABREVIATURAColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return DEPARTAMENTOSCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DEPARTAMENTOSCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return DEPARTAMENTOSCollection.NOMBREColumnName; }
        }
        public static string PaisId_NombreCol
        {
            get { return DEPARTAMENTOSCollection.PAIS_IDColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region Propiedades
        protected DEPARTAMENTOSRow row;
        protected DEPARTAMENTOSRow rowSinModificar;
        public class Modelo : DEPARTAMENTOSCollection_Base { public Modelo() : base(null) { } }

        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Abreviatura { get { return row.ABREVIATURA; } set { row.ABREVIATURA = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal Id { get { return row.ID; } set { row.ID = value; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        public decimal PaisId { get { return row.PAIS_ID; } set { row.PAIS_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private PaisesService _pais;
        public PaisesService Pais
        {
            get
            {
                if (this._pais == null)
                    this._pais = new PaisesService(this.PaisId);
                return this._pais;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.DEPARTAMENTOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new DEPARTAMENTOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public DepartamentosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public DepartamentosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public DepartamentosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._pais = null;
        }
        #endregion ResetearPropiedadesExtendidas
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
