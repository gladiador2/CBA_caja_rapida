using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;


namespace CBA.FlowV2.Services.Herramientas
{
    public class ConfiguracionesValores
    {
        #region clase Configuracion
        public class Configuracion
        {
            private Hashtable propiedades;
            public decimal ConfiguracionId { get; private set; }
            public decimal? Id { get; private set; }
            protected string JSON { get; set; }
            public decimal? ReporteId { get; private set; }
            public decimal? UsuarioId { get; private set; }

            #region Constructores
            /// <summary>
            /// Obtener la configuracion (unica) del tipo especificado para el usuario logueado
            /// </summary>
            /// <param name="configuracion_id">The configuracion_id.</param>
            public Configuracion(decimal id)
            {
                using (SessionService sesion = new SessionService())
                {
                    //Se inicializa a un tipo de configuracion cualquiera, es rectificado en CargarDatos
                    InicializarPropiedades(Definiciones.Configuraciones.Filtros);

                    CargarDatos(sesion.db.CONFIGURACIONES_VALORESCollection.GetByPrimaryKey(id));
                }
            }
            
            /// <summary>
            /// Obtener la configuracion (unica) del tipo especificado para el usuario logueado
            /// </summary>
            /// <param name="configuracion_id">The configuracion_id.</param>
            public Configuracion(int configuracion_id)
            {
                using (SessionService sesion = new SessionService())
                {
                    InicializarPropiedades(configuracion_id);
                    string clausulas = ConfiguracionId_NombreCol + " = " + configuracion_id + " and " +
                                       "(" + UsuarioId_NombreCol + " is null or " + UsuarioId_NombreCol + " = " + sesion.Usuario.ID + ")";
                    CONFIGURACIONES_VALORESRow[] rows = sesion.db.CONFIGURACIONES_VALORESCollection.GetAsArray(clausulas, Id_NombreCol);

                    if (rows.Length > 0)
                        CargarDatos(rows[0]);
                    else
                        CargarDatos(null);
                }
            }

            /// <summary>
            /// Obtener la configuracion para el reporte privilegiando la definida para un usuario en especifico
            /// </summary>
            /// <param name="reporte_id">The reporte_id.</param>
            public Configuracion(int configuracion_id, decimal reporte_id)
            {
                using (SessionService sesion = new SessionService())
                {
                    InicializarPropiedades(configuracion_id);
                    string clausulas = ConfiguracionId_NombreCol + " = " + configuracion_id + " and " + 
                                       ReporteId_NombreCol + " = " + reporte_id + " and " +
                                       "(" + UsuarioId_NombreCol + " is null or " + UsuarioId_NombreCol + " = " + sesion.Usuario.ID + ")";
                    CONFIGURACIONES_VALORESRow[] rows = sesion.db.CONFIGURACIONES_VALORESCollection.GetAsArray(clausulas, UsuarioId_NombreCol);

                    if (rows.Length > 0)
                    {
                        CargarDatos(rows[0]);
                    }
                    else
                    {
                        CargarDatos(null);
                    }
                }
            }
            #endregion Constructores

            #region InicializarPropiedades
            protected virtual void InicializarPropiedades(int configuracion_id)
            {
                this.propiedades = new Hashtable();
                this.ConfiguracionId = configuracion_id;
                this.JSON = string.Empty;
            }
            #endregion InicializarPropiedades

            #region Crear
            public static Configuracion Crear(int configuracion_id)
            {
                Configuracion c = new Configuracion(configuracion_id);
                return c;
            }
            #endregion Crear

            #region CargarDatos
            private void CargarDatos(CONFIGURACIONES_VALORESRow row)
            {
                if (row != null)
                {
                    this.Id = row.ID;
                    this.ConfiguracionId = row.CONFIGURACION_ID;
                    this.JSON = row.JSON;

                    if (!row.IsREPORTE_IDNull)
                        this.ReporteId = row.REPORTE_ID;

                    if (!row.IsUSUARIO_IDNull)
                        this.UsuarioId = row.USUARIO_ID;
                }
            }
            #endregion CargarDatos

            #region ToJSON
            public virtual string ToJSON()
            {
                return JsonUtil.Serializar(this.propiedades);
            }
            #endregion ToJSON

            #region SetValor
            protected void SetValor(string propiedad, object valor)
            {
                if(this.propiedades.Contains(propiedades))
                    this.propiedades[propiedad] = valor;
                else
                    this.propiedades.Add(propiedad, valor);
            }
            #endregion SetValor

            #region GetValor
            protected object GetValor(string propiedad)
            {
                return this.propiedades[propiedades];
            }
            #endregion GetValor

            #region Guardar
            public void Guardar()
            {
                using (SessionService sesion = new SessionService())
                {
                    CONFIGURACIONES_VALORESRow row;

                    if (this.Id.HasValue)
                    {
                        row = sesion.db.CONFIGURACIONES_VALORESCollection.GetByPrimaryKey(this.Id.Value);
                    }
                    else
                    {
                        row = new CONFIGURACIONES_VALORESRow();
                        row.ID = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                        row.USUARIO_ID = sesion.Usuario.ID;
                        row.CONFIGURACION_ID = this.ConfiguracionId;
                    }

                    row.JSON = this.ToJSON();

                    //Un usuario no puede guardar una configuracion que se aplique a todos los usuarios
                    //Si usuario es null, se inserta un nuevo registro para el usuario en cuestion
                    if (row.IsUSUARIO_IDNull)
                    {
                        row.ID = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                        row.USUARIO_ID = sesion.Usuario.ID;
                        sesion.db.CONFIGURACIONES_VALORESCollection.Insert(row);
                    }
                    else
                    {
                        if (!this.Id.HasValue)
                            sesion.db.CONFIGURACIONES_VALORESCollection.Insert(row);
                        else
                            sesion.db.CONFIGURACIONES_VALORESCollection.Update(row);
                    }
                }
            }
            #endregion Guardar
        }
        #endregion clase Configuracion

        #region clase BotonesCrearCaso
        public class BotonesCrearCaso : Configuracion
        {
            #region clase BotonCrearCaso
            [Serializable]
            public class BotonCrearCaso
            {
                #region class Estructura
                [Serializable]
                public class Estructura
                {
                    public int Flujo_id { get; set; }
                }
                #endregion class Estructura

                #region Propiedades
                public string nombreBoton { get; set; }
                private string _configuracionBoton;
                public string configuracionBoton
                {
                    get 
                    {
                        return JsonUtil.Serializar(this.configuracionBotonEstructura);
                    }
                    set
                    {
                        this._configuracionBoton = value;
                        this.configuracionBotonEstructura = JsonUtil.Deserializar<Estructura>(value);
                    }
                }
                public Estructura configuracionBotonEstructura { get; set; }
                #endregion Propiedades

                #region Constructor
                public BotonCrearCaso()
                {
                    this.configuracionBotonEstructura = new Estructura();
                }
                #endregion Constructor
            }
            #endregion clase BotonCrearCaso

            #region Propiedades
            public List<BotonCrearCaso> Botones { get; private set; }
            #endregion Propiedades

            #region Constructor
            public BotonesCrearCaso()
                : base(Definiciones.Configuraciones.BotonCrearCaso)
            {
                this.Botones = JsonUtil.Deserializar<List<BotonCrearCaso>>(this.JSON);
            }
            #endregion Constructor

            #region InicializarPropiedades
            protected override void InicializarPropiedades(int configuracion_id)
            {
                base.InicializarPropiedades(configuracion_id);
                this.JSON = "[]";
            }
            #endregion InicializarPropiedades

            #region ToJSON
            public override string ToJSON()
            {
                return JsonUtil.Serializar(this.Botones);
            }
            #endregion ToJSON

            #region Agregar
            public void Agregar(string nombre, int flujo_id)
            {
                BotonCrearCaso bcc = new BotonCrearCaso();
                bcc.nombreBoton = nombre;
                bcc.configuracionBotonEstructura.Flujo_id = flujo_id;
                this.Botones.Add(bcc);
                this.Guardar();
            }
            #endregion Agregar

            #region Quitar
            public void Quitar(string nombre, int flujo_id)
            {
                for (int i = 0; i < this.Botones.Count; i++)
                {
                    BotonCrearCaso b = this.Botones[i];
                    if (b.nombreBoton == nombre && b.configuracionBotonEstructura.Flujo_id == flujo_id)
                    {
                        this.Botones.Remove(b);
                        this.Guardar();
                        break;
                    }
                }
            }
            #endregion Quitar
        }
        #endregion clase BotonesCrearCaso

        #region BotonesBuscador
        public class BotonesBuscador : Configuracion
        {
            #region clase BotonBuscador
            [Serializable]
            public class BotonBuscador
            {
                #region class Estructura
                [Serializable]
                public class Estructura
                {
                    private string[] _estados;
                    private decimal _fecha_relativo;
                    private int _flujo;
                    private decimal _funcionario_involucrado;
                    private decimal _nro_caso;
                    private decimal _persona_involucrada;
                    private decimal _proveedor_involucrado;
                    private decimal _sucursal;
                    private string[] _textos_predefinidos;
                    private decimal _usuario_creador;

                    public string Comprobante { get; set; }
                    public string[] Estados { get { return this._estados == null ? new string[0] : this._estados; } set { this._estados = value; } }
                    public bool Estados_todos { get; set; }
                    public DateTime Fecha_desde { get; set; }
                    public DateTime Fecha_hasta { get; set; }
                    public int Fecha_tipo { get; set; }
                    public decimal Fecha_relativo { get { return this._fecha_relativo == 0 ? Definiciones.Error.Valor.EnteroPositivo : this._fecha_relativo; } set { this._fecha_relativo = value; } }
                    public bool Filtrar_fecha { get; set; }
                    public int Flujo { get { return this._flujo == 0 ? Definiciones.Error.Valor.IntPositivo : this._flujo; } set { this._flujo = value; } }
                    public bool Flujo_todos { get; set; }
                    public decimal Funcionario_involucrado { get { return this._funcionario_involucrado == 0 ? Definiciones.Error.Valor.EnteroPositivo : this._funcionario_involucrado; } set { this._funcionario_involucrado = value; } }
                    public decimal Nro_caso { get { return this._nro_caso == 0 ? Definiciones.Error.Valor.EnteroPositivo : this._nro_caso; } set { this._nro_caso = value; } }
                    public decimal Persona_involucrada { get { return this._persona_involucrada == 0 ? Definiciones.Error.Valor.EnteroPositivo : this._persona_involucrada; } set { this._persona_involucrada = value; } }
                    public decimal Proveedor_involucrado { get { return this._proveedor_involucrado == 0 ? Definiciones.Error.Valor.EnteroPositivo : this._proveedor_involucrado; } set { this._proveedor_involucrado = value; } }
                    public decimal Sucursal { get { return this._sucursal == 0 ? Definiciones.Error.Valor.EnteroPositivo : this._sucursal; } set { this._sucursal = value; } }
                    public bool Sucursal_todos { get; set; }
                    public string[] Textos_predefinidos { get { return this._textos_predefinidos == null ? new string[0] : this._textos_predefinidos; } set { this._textos_predefinidos = value; } }
                    public bool Textos_predefinidos_todos { get; set; }
                    public decimal Usuario_creador { get { return this._usuario_creador == 0 ? Definiciones.Error.Valor.EnteroPositivo : this._usuario_creador; } set { this._usuario_creador = value; } }
                }
                #endregion class Estructura

                #region Propiedades
                public string nombreBoton { get; set; }
                private string _configuracionBoton;
                public string configuracionBoton
                {
                    get
                    {
                        return JsonUtil.Serializar(this.configuracionBotonEstructura);
                    }
                    set
                    {
                        this._configuracionBoton = value;
                        this.configuracionBotonEstructura = JsonUtil.Deserializar<Estructura>(value);
                    }
                }
                public Estructura configuracionBotonEstructura { get; set; }
                #endregion Propiedades

                #region Constructor
                public BotonBuscador()
                {
                    this.configuracionBotonEstructura = new Estructura();
                }
                #endregion Constructor
            }
            #endregion clase BotonBuscador

            #region Propiedades
            public List<BotonBuscador> Botones { get; private set; }
            #endregion Propiedades

            #region Constructor
            public BotonesBuscador()
                : base(Definiciones.Configuraciones.BotonBusqueda)
            {
                this.Botones = JsonUtil.Deserializar<List<BotonBuscador>>(this.JSON);
            }
            #endregion Constructor

            #region InicializarPropiedades
            protected override void InicializarPropiedades(int configuracion_id)
            {
                base.InicializarPropiedades(configuracion_id);
                this.JSON = "[]";
            }
            #endregion InicializarPropiedades

            #region ToJSON
            public override string ToJSON()
            {
                return JsonUtil.Serializar(this.Botones);
            }
            #endregion ToJSON

            #region Agregar
            public void Agregar(BotonBuscador bb)
            {
                this.Quitar(bb.nombreBoton);
                this.Botones.Add(bb);
                this.Guardar();
            }
            #endregion Agregar

            #region Quitar
            public void Quitar(string nombre)
            {
                for (int i = 0; i < this.Botones.Count; i++)
                {
                    BotonBuscador b = this.Botones[i];
                    if (b.nombreBoton == nombre)
                    {
                        this.Botones.Remove(b);
                        this.Guardar();
                        break;
                    }
                }
            }
            #endregion Quitar
        }
        #endregion BotonesBuscador

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CONFIGURACIONES_VALORES"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "configuraciones_sqc"; }
        }
        public static string ConfiguracionId_NombreCol
        {
            get { return CONFIGURACIONES_VALORESCollection.CONFIGURACION_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CONFIGURACIONES_VALORESCollection.IDColumnName; }
        }
        public static string Json_NombreCol
        {
            get { return CONFIGURACIONES_VALORESCollection.JSONColumnName; }
        }
        public static string ReporteId_NombreCol
        {
            get { return CONFIGURACIONES_VALORESCollection.REPORTE_IDColumnName; }
        }
        public static string RolId_NombreCol
        {
            get { return CONFIGURACIONES_VALORESCollection.ROL_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return CONFIGURACIONES_VALORESCollection.USUARIO_IDColumnName; }
        }
        #endregion Accessors

        /// <summary>
        /// RECONSTRUCCION EN PROGRESO
        /// Abajo queda lo pendiente de rehacer
        /// </summary>

        #region Filtros
        public class Filtros : Configuracion
        {
            #region Constructor
            public Filtros()
                : base(Definiciones.Configuraciones.Filtros)
            {
                
            }
            #endregion Constructor

            #region ToJSON
            public override string ToJSON()
            {
                return JsonUtil.Serializar(this);
            }
            #endregion ToJSON
        }
        #endregion Filtros

        #region ObtenerConfiguracionUsuario
        /// <summary>
        /// Obteners the configuracion usuario.
        /// </summary>
        /// <param name="ConfiguracionID">The configuracion ID.</param>
        /// <returns></returns>
        public static DataTable ObtenerConfiguracionUsuario(int configuracion_tipo_id)
        {
            using (SessionService sesion = new SessionService()) 
            {
                string clausula = ConfiguracionId_NombreCol + " = " + configuracion_tipo_id + " and " +
                                  "(" + UsuarioId_NombreCol + " = " + sesion.Usuario_Id + " or " + UsuarioId_NombreCol + " is null)";
                return sesion.Db.CONFIGURACIONES_VALORESCollection.GetAsDataTable(clausula, UsuarioId_NombreCol);
            }
        }
        #endregion ObtenerConfiguracionUsuario

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos) 
        {
            using (SessionService sesion = new SessionService()) 
            {
                sesion.Db.BeginTransaction();
            
                try 
                {
                    CONFIGURACIONES_VALORESRow row;
                    string valorAnterior;
                    bool insertarNuevo = false;

                    if (campos.Contains(ConfiguracionesValores.Id_NombreCol))
                    {
                        row = sesion.db.CONFIGURACIONES_VALORESCollection.GetByPrimaryKey((decimal)campos[ConfiguracionesValores.Id_NombreCol]);
                        valorAnterior = row.ToString();

                        if (row.IsUSUARIO_IDNull)
                        {
                            row = row.Clonar();
                            row.ID = sesion.Db.GetSiguienteSecuencia("configuraciones_valores_sqc");
                            row.USUARIO_ID = sesion.Usuario.ID;
                            valorAnterior = Definiciones.Log.RegistroNuevo;
                            insertarNuevo = true;
                        }
                    }
                    else
                    {
                        row = new CONFIGURACIONES_VALORESRow();
                        row.ID = sesion.Db.GetSiguienteSecuencia("configuraciones_valores_sqc");
                        row.USUARIO_ID = sesion.Usuario.ID;
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        insertarNuevo = true;
                    }

                    row.CONFIGURACION_ID = (decimal)campos[ConfiguracionesValores.ConfiguracionId_NombreCol];
                    row.JSON = (string)campos[ConfiguracionesValores.Json_NombreCol];

                    if (insertarNuevo)
                        sesion.Db.CONFIGURACIONES_VALORESCollection.Insert(row);
                    else
                        sesion.Db.CONFIGURACIONES_VALORESCollection.Update(row);
                    LogCambiosService.LogDeRegistro(ConfiguracionesValores.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception) 
                {
                    sesion.Db.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal configuracion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CONFIGURACIONES_VALORESRow row = sesion.db.CONFIGURACIONES_VALORESCollection.GetByPrimaryKey(configuracion_id);

                    if (row.IsUSUARIO_IDNull)
                        throw new Exception("No puede borrar una configuración genérica que está disponible para todos los usuarios.");

                    if (row.USUARIO_ID == sesion.Usuario.ID)
                        sesion.db.CONFIGURACIONES_VALORESCollection.Delete(row);
                    else
                        throw new Exception("No puede borrar una configuración que no le pertenece.");

                    sesion.db.CommitTransaction();
                }
                catch
                {
                    sesion.db.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Borrar
    }
}
