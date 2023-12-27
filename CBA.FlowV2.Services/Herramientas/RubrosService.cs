using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class RubrosService
    {
        #region EstaActivo
        public static bool EstaActivo(decimal rubro_id)
        {
            using (SessionService sesion = new SessionService())
            {
                RUBROSRow rubro = sesion.Db.RUBROSCollection.GetRow(Id_NombreCol + " = " + rubro_id);
                return rubro.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetRubrosDataTable
        /// <summary>
        /// Gets the Rubros data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRubrosDataTable()
        {
            return GetRubrosDataTable(string.Empty, "upper(" + Nombre_NombreCol + ")", false);
        }

        /// <summary>
        /// Gets the Rubros data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetRubrosDataTable(String clausulas, String orden)
        {
            return GetRubrosDataTable(clausulas, orden, false);
        }

        /// <summary>
        /// Gets the Rubros data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetRubrosDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = Estado_NombreCol + "  = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.RUBROSCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.RUBROSCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetRubrosDataTable

        #region GetRubros
        public static DataTable GetRubros(bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                if (soloActivos)
                {
                    return sesion.Db.RUBROSCollection.GetAsDataTable("estado = '" + Definiciones.Estado.Activo + "'", "upper(" + Nombre_NombreCol + ")");
                }
                else
                {
                    return sesion.Db.RUBROSCollection.GetAsDataTable(" 1=1 ", "upper(" + Nombre_NombreCol + ")");
                }
            }
        }
        #endregion GetRubros

        #region GetDescripcion
        public static string GetDescripcion(String nombre)
        {
            using (SessionService sesion = new SessionService())
            {
                RUBROSRow rubro = sesion.Db.RUBROSCollection.GetRow(Nombre_NombreCol + " = '" + nombre + "'");
                return rubro.DESCRIPCION;
            }
        }
        #endregion GetDescripcion

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

                    RUBROSRow row = new RUBROSRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("Rubros_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.RUBROSCollection.GetRow(Id_NombreCol + " = " + decimal.Parse((string)campos[Id_NombreCol]));
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = (string)campos[Nombre_NombreCol];
                    row.DESCRIPCION = (string)campos[Descripcion_NombreCol];
                    row.ORDEN = decimal.Parse(campos[Orden_NombreCol].ToString());
                    row.ESTADO = (string)campos[Estado_NombreCol];

                    if (insertarNuevo) sesion.Db.RUBROSCollection.Insert(row);
                    else sesion.Db.RUBROSCollection.Update(row);

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
            get { return "RUBROS"; }
        }
        public static string Descripcion_NombreCol
        {
            get { return RUBROSCollection.DESCRIPCIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return RUBROSCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return RUBROSCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return RUBROSCollection.NOMBREColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return RUBROSCollection.ORDENColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static RubrosService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new RubrosService(e.RegistroId, sesion);
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
        protected RUBROSRow row;
        protected RUBROSRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Descripcion { get { return row.DESCRIPCION; } set { row.DESCRIPCION = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.RUBROSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new RUBROSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }

        public RubrosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public RubrosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public RubrosService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public RubrosService(EdiCBA.Rubro edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = RubrosService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion);

            this.Nombre = edi.nombre;
        }
        #endregion Constructores

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.Rubro()
            {
                nombre = this.Nombre,
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
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
