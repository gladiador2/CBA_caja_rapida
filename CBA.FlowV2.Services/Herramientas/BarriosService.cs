using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class BarriosService
    {
        #region EstaActivo
        public static bool EstaActivo(decimal barrio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                BARRIOSRow barrio = sesion.Db.BARRIOSCollection.GetRow(" id = " + barrio_id);
                return barrio.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetBarriosDataTable
        /// <summary>
        /// Gets the barrios data table.
        /// </summary>
        /// <param name="ciudad_id">The ciudad_id.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetBarriosDataTable(Decimal ciudad_id)
        {
            return BarriosService.GetBarriosDataTable(BarriosService.CiudadId_NombreCol + " = " + ciudad_id, BarriosService.Nombre_NombreCol);
        }

        public static DataTable GetBarriosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.BARRIOSCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetBarriosDataTable

        #region GetBarrioDataTable
        /// <summary>
        /// Gets the barrios data table with an user-specific where and order clauses.
        /// </summary>
        /// <param name="clausulas">The where string.</param>
        /// <param name="orden">The ordering string.</param>
        /// <param name="soloActivos">Si es true se obtienen solo los activos.</param>
        /// <returns></returns>
        public DataTable GetBarrioDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = Estado_NombreCol+" = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.BARRIOSCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.CIUDADESCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetBarrioDataTable

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try{
                    sesion.Db.BeginTransaction();

                    BARRIOSRow barrio = new BARRIOSRow();
                    String valorAnterior = string.Empty;
                    Decimal aux;

                    if (insertarNuevo)
                    {
                        barrio.ID = sesion.Db.GetSiguienteSecuencia("barrios_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        barrio = sesion.Db.BARRIOSCollection.GetRow(Id_NombreCol+"= " + decimal.Parse((string)campos[Id_NombreCol]));
                        valorAnterior = barrio.ToString();
                    }

                    barrio.NOMBRE = (string)campos[Nombre_NombreCol];
                    barrio.ABREVIATURA = (string)campos[Abreviatura_NombreCol];
                    barrio.ESTADO = (string)campos[Estado_NombreCol];
                    
                    aux = decimal.Parse((string)campos[CiudadId_NombreCol]);
                    if (barrio.CIUDAD_ID != aux)
                    {
                        if (CiudadesService.EstaActivo(aux)) barrio.CIUDAD_ID = aux;
                        else throw new System.ArgumentException("La ciudad seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }

                    if (insertarNuevo) sesion.Db.BARRIOSCollection.Insert(barrio);
                    else sesion.Db.BARRIOSCollection.Update(barrio);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, barrio.ID, valorAnterior, barrio.ToString(), sesion);

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
            get { return "BARRIOS"; }
        }
        public static string Abreviatura_NombreCol
        {
            get { return BARRIOSCollection.ABREVIATURAColumnName; }
        }
        public static string CiudadId_NombreCol
        {
            get { return BARRIOSCollection.CIUDAD_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return BARRIOSCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return BARRIOSCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return BARRIOSCollection.NOMBREColumnName; }
        }
        #endregion Accessors
    
        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region Propiedades
        protected BARRIOSRow row;
        protected BARRIOSRow rowSinModificar;
        public class Modelo : BARRIOSCollection_Base { public Modelo() : base(null) { } }

        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal Id { get { return row.ID; } set { row.ID = value; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        public string Abreviatura { get { return row.ABREVIATURA; } set { row.ABREVIATURA = value; } }
        public decimal Ciudad_Id { get { return row.CIUDAD_ID; } set { row.CIUDAD_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        /*
        private CiudadesService _ciudad;
        public CiudadesService Ciudad
        {
            get
            {
                if (this._ciudad == null)
                    this._ciudad = new CiudadesService(this._ciudad.Value);
                return this._ciudad;
            }
        }
        */
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.BARRIOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new BARRIOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public BarriosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public BarriosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public BarriosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
       // public void ResetearPropiedadesExtendidas()
        //{
         //   this._ciudad = null;
        //}
        #endregion ResetearPropiedadesExtendidas
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
