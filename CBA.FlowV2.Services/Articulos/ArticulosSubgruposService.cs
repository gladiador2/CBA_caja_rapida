using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Collections;

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosSubgruposService
    {
        #region EstaActivo
        public static bool EstaActivo(decimal subgrupo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOS_SUBGRUPOSRow subgrupo = sesion.Db.ARTICULOS_SUBGRUPOSCollection.GetRow(Id_NombreCol + " = " + subgrupo_id);
                return subgrupo.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetArticulosSubgruposDataTable
        [Obsolete("Usar metodos estaticos")]
        /// <summary>
        /// Gets the articulos subgrupos sin filtrar.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosSubgruposDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_SUBGRUPOSCollection.GetAsDataTable(clausula, orden);
            }
        }

        /// <summary>
        /// Gets the articulos subgrupos sin filtrar.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetArticulosSubgruposDataTableStatic(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_SUBGRUPOSCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetArticulosSubgruposDataTable

        #region GetArticulosSubgruposInfoCompleta
        /// <summary>
        /// Gets the articulos subgrupos sin filtrar.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosSubgruposInfoCompleta(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_SUBGRUPOS_INFO_COMPCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetArticulosSubgruposInfoCompleta

        #region GetArticulosSubgrupos
        [Obsolete("Usar Metodos Estaticos")]
        /// <summary>
        /// Gets the articulos subgrupos.
        /// </summary>
        /// <param name="familia_id">The familia_id.</param>
        /// <param name="grupo_id">The grupo_id.</param>
        /// <returns></returns>
        public DataTable GetArticulosSubgrupos(decimal familia_id, decimal grupo_id)
        {
            return this.GetArticulosSubgruposDataTable(ArticulosSubgruposService.FamiliaId_NombreCol + "  = " + familia_id + " and " + ArticulosSubgruposService.GrupoId_NombreCol + " = " + grupo_id, ArticulosSubgruposService.Orden_NombreCol);
        }

        /// <summary>
        /// Gets the articulos subgrupos.
        /// </summary>
        /// <param name="familia_id">The familia_id.</param>
        /// <param name="grupo_id">The grupo_id.</param>
        /// <returns></returns>
        public static DataTable GetArticulosSubgruposStatic(decimal familia_id, decimal grupo_id)
        {
            return GetArticulosSubgruposDataTableStatic(ArticulosSubgruposService.FamiliaId_NombreCol + "  = " + familia_id + " and " + ArticulosSubgruposService.GrupoId_NombreCol + " = " + grupo_id, ArticulosSubgruposService.Nombre_NombreCol);
        }
        #endregion GetArticulosSubgrupos

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

                    ARTICULOS_SUBGRUPOSRow row = new ARTICULOS_SUBGRUPOSRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("articulos_subgrupos_sqc");
                    }
                    else
                    {
                        row = sesion.Db.ARTICULOS_SUBGRUPOSCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.FAMILIA_ID = decimal.Parse(campos[FamiliaId_NombreCol].ToString());
                    row.GRUPO_ID = decimal.Parse(campos[GrupoId_NombreCol].ToString());
                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    row.DESCRIPCION = campos[Descripcion_NombreCol].ToString();
                    row.ESTADO = campos[Estado_NombreCol].ToString();

                    if (insertarNuevo) sesion.Db.ARTICULOS_SUBGRUPOSCollection.Insert(row);
                    else sesion.Db.ARTICULOS_SUBGRUPOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

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

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_SUBGRUPOS"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "articulos_subgrupos_sqc"; }
        }
        public static string Id_NombreCol
        {
            get { return ARTICULOS_SUBGRUPOSCollection.IDColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return ARTICULOS_SUBGRUPOSCollection.DESCRIPCIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return ARTICULOS_SUBGRUPOSCollection.ESTADOColumnName; }
        }
        public static string FamiliaId_NombreCol
        {
            get { return ARTICULOS_SUBGRUPOSCollection.FAMILIA_IDColumnName; }
        }
        public static string GrupoId_NombreCol
        {
            get { return ARTICULOS_SUBGRUPOSCollection.GRUPO_IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return ARTICULOS_SUBGRUPOSCollection.NOMBREColumnName; }
        }
        public static string Codigo_NombreCol
        {
            get { return ARTICULOS_SUBGRUPOSCollection.CODIGOColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return ARTICULOS_SUBGRUPOSCollection.ORDENColumnName; }
        }
        public static string VistaFamiliaNombre_NombreCol
        {
            get { return ARTICULOS_SUBGRUPOS_INFO_COMPCollection.FAMILIA_NOMBREColumnName; }
        }
        public static string VistaGrupoNombre_NombreCol
        {
            get { return ARTICULOS_SUBGRUPOS_INFO_COMPCollection.GRUPO_NOMBREColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public static ArticulosSubgruposService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new ArticulosSubgruposService(e.RegistroId, sesion);
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
        protected ARTICULOS_SUBGRUPOSRow row;
        protected ARTICULOS_SUBGRUPOSRow rowSinModificar;
        public class Modelo : ARTICULOS_SUBGRUPOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal GrupoId { get { return row.GRUPO_ID; } set { row.GRUPO_ID = value; } }
        public decimal FamiliaId { get { return row.FAMILIA_ID; } set { row.FAMILIA_ID = value; } }
        public string Nombre { get { return ClaseCBABase.GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        public string Descripcion { get { return ClaseCBABase.GetStringHelper(row.DESCRIPCION); } set { row.DESCRIPCION = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private ArticulosFamiliasService _familia;
        public ArticulosFamiliasService Familia
        {
            get
            {
                if (this._familia == null)
                    this._familia = new ArticulosFamiliasService(this.FamiliaId);
                return this._familia;
            }
        }

        private ArticulosGruposService _grupo;
        public ArticulosGruposService Grupo
        {
            get
            {
                if (this._grupo == null)
                    this._grupo = new ArticulosGruposService(this.GrupoId);
                return this._grupo;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.ARTICULOS_SUBGRUPOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ARTICULOS_SUBGRUPOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(ARTICULOS_SUBGRUPOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public ArticulosSubgruposService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public ArticulosSubgruposService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public ArticulosSubgruposService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        public ArticulosSubgruposService(EdiCBA.ArticuloSubgrupo edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = ArticulosSubgruposService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion);

            #region familia
            if (!string.IsNullOrEmpty(edi.familia_uuid))
                this._familia = ArticulosFamiliasService.GetPorUUID(edi.familia_uuid, sesion);
            if (this._familia == null && edi.familia != null)
                this._familia = new ArticulosFamiliasService(edi.familia, almacenar_localmente, sesion);
            if (this._familia == null)
                throw new Exception("No se encontró el UUID " + edi.familia_uuid + " ni se definieron los datos del objeto.");

            if (!this.Familia.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Familia.Id.HasValue)
                this.FamiliaId = this.Familia.Id.Value;
            #endregion familia

            #region grupo
            if (!string.IsNullOrEmpty(edi.grupo_uuid))
                this._grupo = ArticulosGruposService.GetPorUUID(edi.grupo_uuid, sesion);
            
            if (this._grupo == null)
                throw new Exception("No se encontró el UUID " + edi.familia_uuid + " ni se definieron los datos del objeto.");

            if (!this.Grupo.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Grupo.Id.HasValue)
                this.GrupoId = this.Grupo.Id.Value;
            #endregion grupo

            this.Nombre = edi.nombre;
            this.Descripcion = edi.descripcion;
        }
        private ArticulosSubgruposService(ARTICULOS_SUBGRUPOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Buscar
        public static ArticulosSubgruposService[] Buscar(ClaseCBABase.Filtro[] filtros)
        {
            using (SessionService sesion = new SessionService())
            {
                return Buscar(filtros, sesion);
            }
        }
        public static ArticulosSubgruposService[] Buscar(ClaseCBABase.Filtro[] filtros, SessionService sesion)
        {
            StringBuilder clausulas = new StringBuilder();
            clausulas.Append(ArticulosSubgruposService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'");
            foreach (ClaseCBABase.Filtro f in filtros)
            {
                clausulas.Append(" and ");
                switch (f.Columna)
                {
                    case Modelo.IDColumnName:
                    case Modelo.FAMILIA_IDColumnName:
                    case Modelo.GRUPO_IDColumnName:
                        clausulas.Append(f.Columna + " = " + f.Valor);
                        break;
                    case Modelo.NOMBREColumnName:
                    case Modelo.DESCRIPCIONColumnName:
                        if (f.Exacto)
                            clausulas.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                        else
                            clausulas.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                        break;
                    default: throw new Exception(typeof(ArticulosGruposService).ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                }
            }

            ARTICULOS_SUBGRUPOSRow[] rows = sesion.db.ARTICULOS_SUBGRUPOSCollection.GetAsArray(clausulas.ToString(), string.Empty);
            ArticulosSubgruposService[] grupos = new ArticulosSubgruposService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                grupos[i] = new ArticulosSubgruposService(rows[i]);
            return grupos;
        }
        #endregion Buscar

        #region GuardarPrivado
        public decimal GuardarPrivado(SessionService sesion)
        {
            //en el formulario original, es el mismo rol
            if (!RolesService.Tiene("ARTICULOS FAMILIAS EDITAR"))
                throw new Exception("No tiene permisos para guardar");

            this.Validar();

            if (!this.ExisteEnDB)
            {
                if (!RolesService.Tiene("ARTICULOS FAMILIAS CREAR"))
                    throw new Exception("No tiene permisos para guardar");

                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.Estado = Definiciones.Estado.Activo;
                sesion.db.ARTICULOS_SUBGRUPOSCollection.Insert(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
            }
            else
            {
                sesion.db.ARTICULOS_SUBGRUPOSCollection.Update(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.rowSinModificar.ToString(), this.row.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();
            return this.Id.Value;
        }
        #endregion GuardarPrivado

        #region Validar
        private void Validar()
        {
            if (this.rowSinModificar.ESTADO == Definiciones.Estado.Activo && this.Estado == Definiciones.Estado.Inactivo)
            {
                if (ArticulosService.GetArticulosPorSubGrupo(this.Id.Value, null).Rows.Count > 0)
                    throw new Exception("El subgrupo no puede eliminarse, cuenta con artículo(s) asociado(s).");
            }
        }
        #endregion Validar

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.ArticuloSubgrupo()
            {
                nombre = this.Nombre,
                descripcion = this.Descripcion,
                familia = (EdiCBA.ArticuloFamilia)this.Familia.ToEDI(0, sesion),
                grupo = (EdiCBA.ArticuloGrupo)this.Grupo.ToEDI(0, sesion)
            };

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
