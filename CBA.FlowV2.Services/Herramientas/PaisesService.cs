#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class PaisesService
    {
        #region EstaActivo
        public static bool EstaActivo(decimal pais_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PAISESRow pais = sesion.Db.PAISESCollection.GetByPrimaryKey(pais_id);
                return pais.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetPaisesDataTable
        /// <summary>
        /// Gets the paises data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPaisesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.PAISESCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }

        /// <summary>
        /// Gets the paises data table with an user-specific where and order clauses.
        /// </summary>
        /// <param name="clausulas">The where string.</param>
        /// <param name="orden">The ordering string.</param>
        /// <param name="soloActivos">Si es true se obtienen solo los activos.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetPaisesDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = Estado_NombreCol+" = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.PAISESCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.PAISESCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }

        
        public static DataTable GetPaisesDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.PAISESCollection.GetAsDataTable(" 1=1 ", PAISESCollection.NOMBREColumnName);
                return table;
            }
        }
        #endregion GetPaisesDataTable

        #region GetPaisesActivos
        public DataTable GetPaisesActivos()
        {
            return GetPaisesDataTable("",Nombre_NombreCol,true);
        }
        #endregion GetPaisesActivos

        #region GetGentilicios
        /// <summary>
        /// Gets todos los gentilicios (activos e inactivos).
        /// </summary>
        /// <returns></returns>
        public DataTable GetGentilicios()
        {
            return GetGentilicios(false);
        }

        /// <summary>
        /// Gets the gentilicios.
        /// </summary>
        /// <param name="soloActivos">Si es true se obtienen solo los gentilicios activos.</param>
        /// <returns></returns>
        public DataTable GetGentilicios(bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                String estado;
                DataTable table;
                if(soloActivos) estado = Estado_NombreCol+"= '" + Definiciones.Estado.Activo + "'";
                else estado = " 1=1 ";

                table = sesion.Db.PAISESCollection.GetAsDataTable(estado, PAISESCollection.GENTILICIOColumnName);
                return table;
            }
        }
        #endregion GetGentilicios

        #region GetGentilicio
        public String GetGentilicio(Decimal pais_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PAISESRow pais = sesion.Db.PAISESCollection.GetRow(Id_NombreCol+"= " + pais_id);
                return pais.GENTILICIO;
            }
        }
        #endregion GetGentilicio

        #region GetNombre
        public String GetNombre(Decimal pais_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PAISESRow pais = sesion.Db.PAISESCollection.GetRow(Id_NombreCol+"= " + pais_id);
                return pais.NOMBRE;
            }
        }
        #endregion GetNombre

        #region GetMoneda
        /// <summary>
        /// Gets the moneda.
        /// </summary>
        /// <param name="pais_id">The pais_id.</param>
        /// <returns></returns>
        public static decimal GetMoneda(decimal pais_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetMoneda(pais_id, sesion);
            }
        }

        public static decimal GetMoneda(decimal pais_id, SessionService sesion)
        {
            PAISESRow pais = sesion.Db.PAISESCollection.GetRow(Id_NombreCol + "= " + pais_id);
            return pais.MONEDA_ID;
        }
        #endregion GetMoneda

        #region GetSucursalPrincipal
        public static decimal GetSucursalPrincipal(decimal pais_id, SessionService sesion)
        {
            string clausules = SucursalesService.PaisId_NombreCol + " = " + pais_id + " and " +
                               SucursalesService.EsCasaMatriz_NombreCol + " = '" + Definiciones.SiNo.Si + "'";
            DataTable dtSucursales = SucursalesService.GetSucursalesDataTable2(clausules, string.Empty, true);

            if (dtSucursales.Rows.Count > 0)
                return (decimal)dtSucursales.Rows[0][SucursalesService.Id_NombreCol];
            else
                return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion GetSucursalPrincipal

        #region GetPais
        /// <summary>
        /// Gets the pais.
        /// </summary>
        /// <param name="pais_id">The pais_id.</param>
        /// <returns></returns>
        public DataTable GetPais(Decimal pais_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.PAISESCollection.GetAsDataTable(Id_NombreCol+" = " + pais_id, string.Empty);
                return tabla;
            }
        }
        #endregion GetPais

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

                    PAISESRow pais = new PAISESRow();
                    String valorAnterior = string.Empty;
                    Decimal aux;

                    if (insertarNuevo)
                    {
                        pais.ID = sesion.Db.GetSiguienteSecuencia("paises_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        pais = sesion.Db.PAISESCollection.GetRow(Id_NombreCol+ " = " + decimal.Parse((string)campos[Id_NombreCol]));
                        valorAnterior = pais.ToString();
                    }

                    pais.NOMBRE = (string)campos[Nombre_NombreCol];
                    pais.ABREVIATURA = (string)campos[Abreviatura_NombreCol];
                    pais.ISO_3166_1 = (string)campos[ISO_3166_1_NombreCol];
                    pais.CODIGO_TEL = (string)campos[CodigoTel_NombreCol];
                    pais.GENTILICIO = (string)campos[Gentilicio_NombreCol];
                    pais.ESTADO = (string)campos[Estado_NombreCol];
                    
                    aux = Decimal.Parse((string)campos[MonedaId_NombreCol]);
                    if (pais.MONEDA_ID != aux)
                    {
                        if (MonedasService.EstaActivo(aux)) pais.MONEDA_ID = aux;
                        else throw new System.ArgumentException("La moneda seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }
                   
                    if (insertarNuevo) sesion.Db.PAISESCollection.Insert(pais);
                    else sesion.Db.PAISESCollection.Update(pais);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, pais.ID, valorAnterior, pais.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    
                    return pais.ID;
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
            get { return "PAISES"; }
        }
        public static string Nombre_NombreCol
        {
            get { return PAISESCollection.NOMBREColumnName; }
        }

        public static string Abreviatura_NombreCol
        {
            get { return PAISESCollection.ABREVIATURAColumnName; }
        }

        public static string Gentilicio_NombreCol
        {
            get { return PAISESCollection.GENTILICIOColumnName; }
        }

        public static string Estado_NombreCol
        {
            get { return PAISESCollection.ESTADOColumnName; }
        }

        public static string Id_NombreCol
        {
            get { return PAISESCollection.IDColumnName; }
        }

        public static string MonedaId_NombreCol
        {
            get { return PAISESCollection.MONEDA_IDColumnName; }
        }
        public static string ISO_3166_1_NombreCol
        {
            get { return PAISESCollection.ISO_3166_1ColumnName; }
        }
        public static string CodigoTel_NombreCol
        {
            get { return PAISESCollection.CODIGO_TELColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static PaisesService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new PaisesService(e.RegistroId, sesion);
        }

        public static decimal? GetIdPorUUID(string uuid, SessionService sesion)
        {
            if (uuid.Length <= 0)
                return null;

            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return e.RegistroId;
        }
        #endregion interfaz IEntidadMigrable

        #region Propiedades
        protected PAISESRow row;
        protected PAISESRow rowSinModificar;
        public class Modelo : PAISESCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Abreviatura { get { return ClaseCBABase.GetStringHelper(row.ABREVIATURA); } set { row.ABREVIATURA = value; } }
        public string CodigoTel { get { return ClaseCBABase.GetStringHelper(row.CODIGO_TEL); } set { row.CODIGO_TEL = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public string Gentilicio { get { return ClaseCBABase.GetStringHelper(row.GENTILICIO); } set { row.GENTILICIO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string ISO31661 { get { return ClaseCBABase.GetStringHelper(row.ISO_3166_1); } set { row.ISO_3166_1 = value; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public string Nombre { get { return ClaseCBABase.GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                    this._moneda = new MonedasService(this.MonedaId);
                return this._moneda;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.PAISESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new PAISESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(PAISESRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public PaisesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public PaisesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public PaisesService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public PaisesService(EdiCBA.Pais edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = PaisesService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion);

            this.Nombre = edi.nombre; 
            this.Abreviatura = edi.abreviatura;
            this.CodigoTel = edi.codigo_telefonico;
            this.Gentilicio = edi.gentilicio;
            this.ISO31661 = edi.ISO31661;
            this.Estado = Definiciones.Estado.Activo;

            #region moneda
            if (!string.IsNullOrEmpty(edi.moneda_uuid))
                this._moneda = MonedasService.GetPorUUID(edi.moneda_uuid, sesion);
           
            if (this._moneda == null)
                throw new Exception("No se encontró el UUID " + edi.moneda_uuid + " ni se definieron los datos del objeto.");

            if (!this.Moneda.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Moneda.Id.HasValue)
                this.MonedaId = this.Moneda.Id.Value;
            #endregion moneda
        }

        private PaisesService(PAISESRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._moneda = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.Pais()
            {
                abreviatura = this.Abreviatura,
                codigo_telefonico = this.CodigoTel,
                gentilicio = this.Gentilicio,
                ISO31661 = this.ISO31661,
                moneda_uuid = this.Moneda.GetOrCreateUUID(sesion),
                nombre = this.Nombre,
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.moneda = (EdiCBA.Moneda)this.Moneda.ToEDI(nueva_profundidad, sesion);
            }

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value);
            }
            return e;
        }
        #endregion ToEDI

        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
