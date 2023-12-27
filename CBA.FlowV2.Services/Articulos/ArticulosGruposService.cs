using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosGruposService
    {

        #region GetArticulosGrupos
        /// <summary>
        /// Gets the articulos grupos sin filtrar.
        /// </summary>
        /// <returns></returns>
        public DataTable GetArticulosGrupos()
        {
            using (SessionService sesion = new SessionService())
            {
                return this.GetArticulosGruposDataTable(string.Empty, ArticulosGruposService.Nombre_NombreCol);
            }
        }

        [Obsolete("Usar metodos estaticos")]
        /// <summary>
        /// Gets the articulos grupos.
        /// </summary>
        /// <param name="familia_id">The familia_id.</param>
        /// <returns></returns>
        public DataTable GetArticulosGrupos(decimal familia_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return this.GetArticulosGruposDataTable(ArticulosGruposService.FamiliaId_NombreCol + " = " + familia_id, ArticulosGruposService.Orden_NombreCol);
            }
        }

        /// <summary>
        /// Gets the articulos grupos.
        /// </summary>
        /// <param name="familia_id">The familia_id.</param>
        /// <returns></returns>
        public static DataTable GetArticulosGruposStatic(decimal familia_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetArticulosGruposDataTableStatic(ArticulosGruposService.FamiliaId_NombreCol + " = " + familia_id, ArticulosGruposService.Orden_NombreCol);
            }
        }

        #endregion GetArticulosGrupos

        #region GetArticulosGruposDataTable
        [Obsolete("Usar metodos estaticos")]
        /// <summary>
        /// Gets the articulos grupos sin filtrar.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosGruposDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_GRUPOSCollection.GetAsDataTable(clausulas, orden);
            }
        }

        /// <summary>
        /// Gets the articulos grupos sin filtrar.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetArticulosGruposDataTableStatic(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_GRUPOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosGruposDataTable

        #region GetArticulosGruposInfoCompleta
        /// <summary>
        /// Gets the articulos grupos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosGruposInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_GRUPOS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosGruposInfoCompleta

        #region EstaActivo
        public static bool EstaActivo(decimal grupo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOS_GRUPOSRow grupo = sesion.Db.ARTICULOS_GRUPOSCollection.GetRow(Id_NombreCol + " = " + grupo_id);
                return grupo.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

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

                    ARTICULOS_GRUPOSRow row = new ARTICULOS_GRUPOSRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("articulos_grupos_sqc");
                    }
                    else
                    {
                        row = sesion.Db.ARTICULOS_GRUPOSCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.FAMILIA_ID = decimal.Parse(campos[FamiliaId_NombreCol].ToString());
                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    row.DESCRIPCION = campos[Descripcion_NombreCol].ToString();
                    row.ESTADO = campos[Estado_NombreCol].ToString();

                    if (insertarNuevo) sesion.Db.ARTICULOS_GRUPOSCollection.Insert(row);
                    else sesion.Db.ARTICULOS_GRUPOSCollection.Update(row);
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
            get { return "ARTICULOS_GRUPOS"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "articulos_grupos_sqc"; }
        }
        public static string Id_NombreCol
        {
            get { return ARTICULOS_GRUPOSCollection.IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return ARTICULOS_GRUPOSCollection.ESTADOColumnName; }
        }
        public static string FamiliaId_NombreCol
        {
            get { return ARTICULOS_GRUPOSCollection.FAMILIA_IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return ARTICULOS_GRUPOSCollection.NOMBREColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return ARTICULOS_GRUPOSCollection.DESCRIPCIONColumnName; }
        }
        public static string Codigo_NombreCol
        {
            get { return ARTICULOS_GRUPOSCollection.CODIGOColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return ARTICULOS_GRUPOSCollection.ORDENColumnName; }
        }
        public static string VistaFamiliaNombre_NombreCol
        {
            get { return ARTICULOS_GRUPOS_INFO_COMPLETACollection.FAMILIA_NOMBREColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static ArticulosGruposService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new ArticulosGruposService(e.RegistroId, sesion);
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
        protected ARTICULOS_GRUPOSRow row;
        protected ARTICULOS_GRUPOSRow rowSinModificar;
        public class Modelo : ARTICULOS_GRUPOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

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
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.ARTICULOS_GRUPOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ARTICULOS_GRUPOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(ARTICULOS_GRUPOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public ArticulosGruposService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public ArticulosGruposService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public ArticulosGruposService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

       
        private ArticulosGruposService(ARTICULOS_GRUPOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Buscar
        public static ArticulosGruposService[] Buscar(ClaseCBABase.Filtro[] filtros)
        {
            using (SessionService sesion = new SessionService())
            {
                return Buscar(filtros, sesion);
            }
        }
        public static ArticulosGruposService[] Buscar(ClaseCBABase.Filtro[] filtros, SessionService sesion)
        {
            StringBuilder clausulas = new StringBuilder();
            clausulas.Append(ArticulosGruposService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'");
            foreach (ClaseCBABase.Filtro f in filtros)
            {
                clausulas.Append(" and ");
                switch (f.Columna)
                {
                    case Modelo.IDColumnName:
                    case Modelo.FAMILIA_IDColumnName:
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

            ARTICULOS_GRUPOSRow[] rows = sesion.db.ARTICULOS_GRUPOSCollection.GetAsArray(clausulas.ToString(), string.Empty);
            ArticulosGruposService[] grupos = new ArticulosGruposService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                grupos[i] = new ArticulosGruposService(rows[i]);
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
                sesion.db.ARTICULOS_GRUPOSCollection.Insert(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
            }
            else
            {
                sesion.db.ARTICULOS_GRUPOSCollection.Update(this.row);
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
                if (ArticulosSubgruposService.GetArticulosSubgruposStatic(this.FamiliaId, this.Id.Value).Rows.Count > 0)
                    throw new Exception("El grupo no puede eliminarse, cuenta con subgrupo(s) asociado(s).");
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

            var e = new EdiCBA.ArticuloGrupo()
            {
                nombre = this.Nombre,
                descripcion = this.Descripcion,
                familia = (EdiCBA.ArticuloFamilia)this.Familia.ToEDI(0, sesion),
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