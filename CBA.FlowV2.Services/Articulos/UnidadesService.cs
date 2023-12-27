using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Stock;


namespace CBA.FlowV2.Services.Articulos
{
    public class UnidadesService
    {
        #region Obtener Unidades
        public DataTable GetUnidades()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.UNIDADES_MEDIDACollection.GetAsDataTable("", UnidadesService.Orden_NombreCol);
            }
        }

        public static DataTable GetUnidades2(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.UNIDADES_MEDIDACollection.GetAsDataTable(clausulas, UnidadesService.Orden_NombreCol);
            }
        }
        
        public DataTable GetUnidadPorID(string unidad_medida_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.UNIDADES_MEDIDACollection.GetAsDataTable(UnidadesService.Id_NombreCol + " = '" + unidad_medida_id + "'", string.Empty);
            }
        }       
        #endregion

        #region GetCantidadDecimales
        public static int GetCantidadDecimales(string unidad_medida_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCantidadDecimales(unidad_medida_id, sesion);
            }
        }

        public static int GetCantidadDecimales(string unidad_medida_id, SessionService sesion)
        {
            return (int)sesion.db.UNIDADES_MEDIDACollection.GetByPrimaryKey(unidad_medida_id).CANTIDAD_DECIMALES;
        }
        #endregion GetCantidadDecimales

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "UNIDADES_MEDIDA"; }
        }
        public static string CantidadDecimales_NombreCol
        {
            get { return UNIDADES_MEDIDACollection.CANTIDAD_DECIMALESColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return UNIDADES_MEDIDACollection.IDColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return UNIDADES_MEDIDACollection.DESCRIPCIONColumnName; }
        }
        public static string FactorKilo_NombreCol
        {
            get { return UNIDADES_MEDIDACollection.FACTOR_KILOColumnName; }
        }
        public static string FactorMetro_NombreCol
        {
            get { return UNIDADES_MEDIDACollection.FACTOR_METROColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return UNIDADES_MEDIDACollection.ORDENColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region Propiedades
        protected UNIDADES_MEDIDARow row;
        protected UNIDADES_MEDIDARow rowSinModificar;
        public class Modelo : UNIDADES_MEDIDACollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.Length > 0; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal CantidadDecimales { get { return row.CANTIDAD_DECIMALES; } private set { row.CANTIDAD_DECIMALES = value; } }
        public string Descripcion { get { return ClaseCBABase.GetStringHelper(row.DESCRIPCION); } set { row.DESCRIPCION = value; } }
        public decimal? FactorKilo { get { if (row.IsFACTOR_KILONull) return null; else return row.FACTOR_KILO; } set { if (value.HasValue) row.FACTOR_KILO = value.Value; else row.IsFACTOR_KILONull = true; } }
        public decimal? FactorMetro { get { if (row.IsFACTOR_METRONull) return null; else return row.FACTOR_METRO; } set { if (value.HasValue) row.FACTOR_METRO = value.Value; else row.IsFACTOR_METRONull = true; } }
        public decimal? Orden { get { if (row.IsORDENNull) return null; else return row.ORDEN; } set { if (value.HasValue) row.ORDEN = value.Value; else row.IsORDENNull = true; } }
        public string Id { get { return ClaseCBABase.GetStringHelper(row.ID); } private set { row.ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        #endregion Propiedades Extendidas
        
        #region Constructores
        private void Inicializar(string id, SessionService sesion)
        {
            this.row = null;
            if (!CBA.FlowV2.Services.Common.Interprete.EsNullODBNull(id) && id.Length > 0)
            {
                this.row = sesion.db.UNIDADES_MEDIDACollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new UNIDADES_MEDIDARow();
                this.Id = null;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(UNIDADES_MEDIDARow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public UnidadesService(string id, SessionService sesion) { Inicializar(id, sesion); }
        public UnidadesService() : this(string.Empty) { }
        public UnidadesService(string id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        private UnidadesService(UNIDADES_MEDIDARow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Buscar
        public static UnidadesService[] Buscar(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return Buscar(clausulas, orden, sesion);
            }
        }
        public static UnidadesService[] Buscar(string clausulas, string orden, SessionService sesion)
        {
            UNIDADES_MEDIDARow[] rows = sesion.db.UNIDADES_MEDIDACollection.GetAsArray(clausulas, orden);
            UnidadesService[] u = new UnidadesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                u[i] = new UnidadesService(rows[i]);
            return u;
        }
        #endregion Buscar
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
