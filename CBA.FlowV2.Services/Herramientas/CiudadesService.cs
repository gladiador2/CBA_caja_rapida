using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class CiudadesService
    {
        #region EstaActivo
        public static bool EstaActivo(decimal ciudad_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CIUDADESRow ciudad = sesion.Db.CIUDADESCollection.GetRow(Id_NombreCol+"  = " + ciudad_id);
                return ciudad.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetCiudadesDataTable
        /// <summary>
        /// Gets the ciudades data table.
        /// </summary>
        /// <param name="departamento_id">The departamento_id.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetCiudadesDataTable(Decimal departamento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.CIUDADESCollection.GetAsDataTable(DepartamentoID_NombreCol+"= " + departamento_id, "upper(nombre)");
                return table;
            }
        }

        /// <summary>
        /// Gets the ciudades data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCiudadesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.CIUDADESCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetCiudadesDataTable

        #region GetNombre
        public String GetNombre(Decimal ciudad_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CIUDADESRow ciudad = sesion.Db.CIUDADESCollection.GetRow(Id_NombreCol+"= " + ciudad_id);
                return ciudad.NOMBRE;
            }
        }
        #endregion GetNombre

        #region GetAbreviatura
        public String GetAbreviatura(Decimal ciudad_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CIUDADESRow ciudad = sesion.Db.CIUDADESCollection.GetRow(Id_NombreCol+" = " + ciudad_id);
                return ciudad.ABREVIATURA;
            }
        }
        #endregion GetAbreviatura

        #region GetCiudadDataTable
        /// <summary>
        /// Gets the ciudades data table with an user-specific where and order clauses.
        /// </summary>
        /// <param name="clausulas">The where string.</param>
        /// <param name="orden">The ordering string.</param>
        /// <param name="soloActivos">Si es true se obtienen solo los activos.</param>
        /// <returns></returns>
        public DataTable GetCiudadDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = Estado_NombreCol+" = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.CIUDADESCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.CIUDADESCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetCiudadDataTable

        public DataTable GetCiudad(Decimal ciudad_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.CIUDADESCollection.GetAsDataTable(Id_NombreCol + " = " + ciudad_id, string.Empty);
                return tabla;
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

                    CIUDADESRow ciudad = new CIUDADESRow();
                    String valorAnterior = string.Empty;
                    Decimal aux;

                    if (insertarNuevo)
                    {
                        ciudad.ID = sesion.Db.GetSiguienteSecuencia("ciudades_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        ciudad = sesion.Db.CIUDADESCollection.GetRow(Id_NombreCol+" = " + decimal.Parse((string)campos[Id_NombreCol]));
                        valorAnterior = ciudad.ToString();
                    }

                    ciudad.NOMBRE = (string)campos[Nombre_NombreCol];
                    ciudad.ABREVIATURA = (string)campos[Abreviatura_NombreCol];
                    ciudad.CODIGO_TEL = (string)campos[CodigoTel_NombreCol];
                    ciudad.ESTADO = (string)campos[Estado_NombreCol];
                    
                    aux = decimal.Parse((string)campos[DepartamentoID_NombreCol]);
                    if (ciudad.DEPARTAMENTO_ID != aux)
                    {
                        if (DepartamentosService.EstaActivo(aux)) ciudad.DEPARTAMENTO_ID = aux;
                        else throw new System.ArgumentException("El departamento seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }

                    if (insertarNuevo) sesion.Db.CIUDADESCollection.Insert(ciudad);
                    else sesion.Db.CIUDADESCollection.Update(ciudad);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, ciudad.ID, valorAnterior, ciudad.ToString(), sesion);

                    sesion.Db.CommitTransaction();

                    return ciudad.ID;
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
            get { return "CIUDADES"; }
        }
        public static string Abreviatura_NombreCol
        {
            get { return CIUDADESCollection.ABREVIATURAColumnName; }
        }
        public static string CodigoTel_NombreCol
        {
            get { return CIUDADESCollection.CODIGO_TELColumnName; }
        }
        public static string DepartamentoID_NombreCol
        {
            get { return CIUDADESCollection.DEPARTAMENTO_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CIUDADESCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CIUDADESCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CIUDADESCollection.NOMBREColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO orientacion a objetos
        #region Propiedades
        protected CIUDADESRow row;
        protected CIUDADESRow rowSinModificar;
        
        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return ClaseCBABase.GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CIUDADESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CIUDADESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public CiudadesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CiudadesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CiudadesService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        #endregion Constructores

        #endregion CODIGO NUEVO orientacion a objetos
    }
}
