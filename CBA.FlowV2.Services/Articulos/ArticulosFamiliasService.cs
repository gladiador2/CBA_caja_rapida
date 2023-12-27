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
    public class ArticulosFamiliasService
    {
        [Obsolete("usar metodos estaticos")]
        /// <summary>
        /// Gets the articulos familias.
        /// </summary>
        /// <returns></returns>
        public DataTable GetArticulosFamilias()
        {
            using (SessionService sesion = new SessionService())
            {
                return GetArticulosFamiliasDataTable(string.Empty, ArticulosFamiliasService.Orden_NombreCol);
            }
        }

        /// <summary>
        /// Gets the articulos familias.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetArticulosFamiliasStatic()
        {
            using (SessionService sesion = new SessionService())
            {
                return GetArticulosFamiliasDataTableStatic(string.Empty, ArticulosFamiliasService.Orden_NombreCol);
            }
        }

        [Obsolete("usar metodos estaticos")]
        /// <summary>
        /// Gets the articulos familias.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosFamiliasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = EntidadId_NombreCol + " = " + sesion.Entidad.ID;

                if (clausulas.Length > 0) where += " and " + clausulas;
                return sesion.Db.ARTICULOS_FAMILIASCollection.GetAsDataTable(where, orden);
            }
        }

        /// <summary>
        /// Gets the articulos familias.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetArticulosFamiliasDataTableStatic(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = EntidadId_NombreCol + " = " + sesion.Entidad.ID;

                if (clausulas.Length > 0) where += " and " + clausulas;
                return sesion.Db.ARTICULOS_FAMILIASCollection.GetAsDataTable(where, orden);
            }
        }

        /// <summary>
        /// Gets the articulos familias.
        /// </summary>
        /// <param name="parteTexto">The parte texto.</param>
        /// <returns></returns>
        public DataTable GetArticulosFamiliasParteTexto(string parteTexto)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = EntidadId_NombreCol + " = " + sesion.Entidad.ID;

                clausula += " and (upper(" + Nombre_NombreCol + ") like '%" + parteTexto.ToUpper() + "%' or upper(" + Descripcion_NombreCol + ") like '%" + parteTexto.ToUpper() + "%')";
                return this.GetArticulosFamiliasDataTable(clausula, ArticulosFamiliasService.Nombre_NombreCol);
            }
        }

        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="familia_id">The familia_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal familia_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOS_FAMILIASRow familia = sesion.Db.ARTICULOS_FAMILIASCollection.GetRow(Id_NombreCol+"= " + familia_id);
                return familia.ESTADO == Definiciones.Estado.Activo;
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

                    ARTICULOS_FAMILIASRow row = new ARTICULOS_FAMILIASRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("articulos_familias_sqc");
                        row.ENTIDAD_ID = sesion.Entidad.ID;
                    }
                    else
                    {
                        row = sesion.Db.ARTICULOS_FAMILIASCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    row.DESCRIPCION = campos[Descripcion_NombreCol].ToString();
                    row.ESTADO = campos[Estado_NombreCol].ToString();
                    row.EXCLUSIVO = campos[Exclusivo_NombreCol].ToString();

                    if (insertarNuevo) sesion.Db.ARTICULOS_FAMILIASCollection.Insert(row);
                    else sesion.Db.ARTICULOS_FAMILIASCollection.Update(row);
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
            get { return "ARTICULOS_FAMILIAS"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "articulos_familias_sqc"; }
        }
        public static string Id_NombreCol
        {
            get { return ARTICULOS_FAMILIASCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return ARTICULOS_FAMILIASCollection.NOMBREColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return ARTICULOS_FAMILIASCollection.ESTADOColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return ARTICULOS_FAMILIASCollection.DESCRIPCIONColumnName; }
        }
        public static string EntidadId_NombreCol
        {
            get { return ARTICULOS_FAMILIASCollection.ENTIDAD_IDColumnName; }
        }
        public static string Exclusivo_NombreCol
        {
            get { return ARTICULOS_FAMILIASCollection.EXCLUSIVOColumnName; }
        }
        public static string Codigo_NombreCol
        {
            get { return ARTICULOS_FAMILIASCollection.CODIGOColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return ARTICULOS_FAMILIASCollection.ORDENColumnName; }
        }

        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static ArticulosFamiliasService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new ArticulosFamiliasService(e.RegistroId, sesion);
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
        protected ARTICULOS_FAMILIASRow row;
        protected ARTICULOS_FAMILIASRow rowSinModificar;
        public class Modelo : ARTICULOS_FAMILIASCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Nombre  { get { return ClaseCBABase.GetStringHelper(row.NOMBRE); }  set { row.NOMBRE = value; }  }
        public string Descripcion  { get { return ClaseCBABase.GetStringHelper(row.DESCRIPCION); }  set { row.DESCRIPCION = value; }  }
        public string Estado  { get { return row.ESTADO; }  set { row.ESTADO = value; }  }
        public decimal Entidad { get { return row.ENTIDAD_ID; } set { row.ENTIDAD_ID = value; } }
        public string Exclusivo { get { return row.EXCLUSIVO; } set { row.EXCLUSIVO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.ARTICULOS_FAMILIASCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ARTICULOS_FAMILIASRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(ARTICULOS_FAMILIASRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public ArticulosFamiliasService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public ArticulosFamiliasService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public ArticulosFamiliasService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public ArticulosFamiliasService(EdiCBA.ArticuloFamilia edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion); 
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = ArticulosFamiliasService.GetIdPorUUID(edi.uuid, sesion);
            if(this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            this.Nombre = edi.nombre;
            this.Descripcion = edi.descripcion;
            this.Exclusivo = edi.exclusivo;
        }
        private ArticulosFamiliasService(ARTICULOS_FAMILIASRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Buscar
        public static ArticulosFamiliasService[] Buscar(ClaseCBABase.Filtro[] filtros)
        {
            using (SessionService sesion = new SessionService())
            {
                return Buscar(filtros, sesion);
            }
        }
        public static ArticulosFamiliasService[] Buscar(ClaseCBABase.Filtro[] filtros, SessionService sesion)
        {
            StringBuilder clausulas = new StringBuilder();
            clausulas.Append(ArticulosFamiliasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'");
            foreach (ClaseCBABase.Filtro f in filtros)
            {
                clausulas.Append(" and ");
                switch (f.Columna)
                {
                    case Modelo.IDColumnName:
                        clausulas.Append(f.Columna + " = " + f.Valor);
                        break;
                    case Modelo.NOMBREColumnName:
                    case Modelo.DESCRIPCIONColumnName:
                    case Modelo.EXCLUSIVOColumnName:
                        if (f.Exacto)
                            clausulas.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                        else
                            clausulas.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                        break;
                    default: throw new Exception(typeof(ArticulosFamiliasService).ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                }
            }

            ARTICULOS_FAMILIASRow[] rows = sesion.db.ARTICULOS_FAMILIASCollection.GetAsArray(clausulas.ToString(), string.Empty);
            ArticulosFamiliasService[] familias = new ArticulosFamiliasService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                familias[i] = new ArticulosFamiliasService(rows[i]);
            return familias;
        }
        #endregion Buscar

        #region GuardarPrivado
        public decimal GuardarPrivado(SessionService sesion)
        {
            if (!RolesService.Tiene("ARTICULOS FAMILIAS EDITAR"))
                throw new Exception("No tiene permisos para guardar");

            this.Validar();

            if (!this.ExisteEnDB)
            {
                if (!RolesService.Tiene("ARTICULOS FAMILIAS CREAR"))
                    throw new Exception("No tiene permisos para guardar");

                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.Estado = Definiciones.Estado.Activo;
                this.Entidad = sesion.Entidad.ID;
                sesion.db.ARTICULOS_FAMILIASCollection.Insert(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
            }
            else
            {
                sesion.db.ARTICULOS_FAMILIASCollection.Update(this.row);
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
                if (ArticulosGruposService.GetArticulosGruposStatic(this.Id.Value).Rows.Count > 0)
                    throw new Exception("La familia no puede eliminarse, cuenta con grupo(s) asociado(s).");
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

            var e = new EdiCBA.ArticuloFamilia()
            {
                nombre = this.Nombre,
                descripcion = this.Descripcion,
                exclusivo = this.Exclusivo
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
