using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Common;
using System.Collections;
using System.Text.RegularExpressions;
using System.Data;
using CBA.FlowV2.Services.Casos;
using Newtonsoft.Json;

namespace CBA.FlowV2.Services.Herramientas
{
    public class RedesSocialesAuthService : ClaseCBA<RedesSocialesAuthService>
    {
        #region clase desafio
        public class Desafio
        {
            public string pregunta;
            public List<string> opciones;
            public string mensaje;
            public DateTime creacion;
        }
        #endregion clase desafio

        #region clase protocolo
        public class Protocolo
        {
            public int DesafiosGenerados;
            public int DesafiosSuperados;
            public Desafio DesafioActual;
            public string RespuestaCorrecta; //al desafio actual
        }
        #endregion clase protocolo

        #region clase Respuesta
        public class Respuesta
        {
            public Desafio desafio;
            public int timeout; //en segundos
            public bool autenticado;
            public string nombreUsuario; //Nombre de la persona o nombre fantasia del proveedor
            public string apellidoUsuario; //Apellido de la persona o razon social del proveedor

            public Respuesta()
            {
                this.desafio = null;
                this.timeout = 0;
                this.autenticado = false;
                this.nombreUsuario = string.Empty;
                this.apellidoUsuario = string.Empty;
            }
        }
        #endregion clase Respuesta

        #region Propiedades
        private delegate string GenearDesafioDelegate(ref Desafio desafio);
        protected REDES_SOCIALES_AUTHRow row;
        protected REDES_SOCIALES_AUTHRow rowSinModificar;
        public class Modelo : REDES_SOCIALES_AUTHCollection_Base { public Modelo() : base(null) { } }
        private const int cantidadDesafiosMax = 4;
        private const int cantidadDesafiosSuperadosRequeridos = 2;
        private TimeSpan tiempoParaResponder = new TimeSpan(0, 5, 0);
        private TimeSpan tiempoParaResetear = new TimeSpan(6, 0, 0);

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string Autenticado { get { return row.AUTENTICADO; } set { row.AUTENTICADO = value; } }
        public string DatosUsuario { get { return GetStringHelper(row.DATOS_USUARIO); } set { row.DATOS_USUARIO = value; } }
        public string Finalizado { get { return row.FINALIZADO; } set { row.FINALIZADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string PerfilId { get { return GetStringHelper(row.PERFIL_ID); } set { row.PERFIL_ID = value; } }
        public decimal? PersonaId { get { if (row.IsPERSONA_IDNull) return null; else return row.PERSONA_ID; } set { if (value.HasValue) row.PERSONA_ID = value.Value; else row.IsPERSONA_IDNull = true; } }
        public decimal? ProveedorId { get { if (row.IsPROVEEDOR_IDNull) return null; else return row.PROVEEDOR_ID; } set { if (value.HasValue) row.PROVEEDOR_ID = value.Value; else row.IsPROVEEDOR_IDNull = true; } }
        public decimal RedSocialId { get { return row.RED_SOCIAL_ID; } set { row.RED_SOCIAL_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private PersonasService _persona;
        public PersonasService Persona
        {
            get
            {
                if (this._persona == null)
                    this._persona = new PersonasService(this.PersonaId.Value);
                return this._persona;
            }
        }

        private ProveedoresService _proveedor;
        public ProveedoresService Proveedor
        {
            get
            {
                if (this._proveedor == null)
                    this._proveedor = new ProveedoresService(this.ProveedorId.Value);
                return this._proveedor;
            }
        }

        private Protocolo _protocolo;
        private Protocolo protocolo 
        { 
            get 
            {
                if (this._protocolo == null)
                {
                    if (Interprete.EsNullODBNull(row.PROTOCOLO))
                        this._protocolo = new Protocolo();
                    else
                        this._protocolo = JsonUtil.Deserializar<Protocolo>(row.PROTOCOLO);
                }
                return this._protocolo;
            }
            set 
            {
                this._protocolo = value;
            } 
        }

        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;                
            if (id != Definiciones.Error.Valor.EnteroPositivo)          
            {
                this.row = sesion.db.REDES_SOCIALES_AUTHCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new REDES_SOCIALES_AUTHRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(REDES_SOCIALES_AUTHRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public RedesSocialesAuthService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public RedesSocialesAuthService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public RedesSocialesAuthService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private RedesSocialesAuthService(REDES_SOCIALES_AUTHRow row)
        {
            Inicializar(row);
        }
        private RedesSocialesAuthService(int red_social_id, string perfil_id, SessionService sesion)
        {
            this.Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.RedSocialId = red_social_id;
            this.PerfilId = perfil_id;
            this.Autenticado = Definiciones.SiNo.No;
            this.Finalizado = Definiciones.SiNo.No;
            this.Guardar();
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();

            this.row.PROTOCOLO = JsonUtil.Serializar(this.protocolo);

            if (!this.ExisteEnDB)
            {
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                sesion.db.REDES_SOCIALES_AUTHCollection.Insert(this.row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.REDES_SOCIALES_AUTHCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), this.rowSinModificar.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();
            return this.Id.Value;
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();
            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._persona = null;
            this._protocolo = null;
            this._proveedor = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Crear
        private static RedesSocialesAuthService Crear(int red_social_id, string perfil_id, string tabla_id, string numero_documento, SessionService sesion)
        {
            decimal entidadId = Definiciones.Error.Valor.EnteroPositivo;

            if(tabla_id == PersonasService.Nombre_Tabla)
                entidadId = PersonasService.GetPersonaIdPorNroDocumento(numero_documento);
            else if(tabla_id == ProveedoresService.Nombre_Tabla)
                entidadId = ProveedoresService.GetProveedorIdPorNroDocumento(numero_documento);
            else
                throw new Exception("RedesSocialesAuthService.Crear. Tabla no implementada");

            RedesSocialesAuthService rsa = null;
            if (entidadId != Definiciones.Error.Valor.EnteroPositivo)
            {
                rsa = new RedesSocialesAuthService(red_social_id, perfil_id, sesion);

                if (tabla_id == PersonasService.Nombre_Tabla)
                    rsa.PersonaId = entidadId;
                else if (tabla_id == ProveedoresService.Nombre_Tabla)
                    rsa.ProveedorId = entidadId;
            }

            return rsa;
        }
        #endregion Crear

        #region GenerarDesafio
        private void GenerarDesafio(string mensaje_parcial)
        {
            GenearDesafioDelegate[] delegados = new GenearDesafioDelegate[5];
            delegados[0] = GenerarDesafioUltimoNombre;
            delegados[1] = GenerarDesafioUltimoApellido;
            delegados[2] = GenerarDesafioNacimiento;
            delegados[3] = GenerarDesafioTelefono;
            delegados[4] = GenerarDesafioUltimaCompraAnho;

            //Obtener un subindice aleatorio y valido
            int indice = (new Random()).Next(delegados.Length);

            //Obtener el desafio y establecer cual de las respuestas es la correcta
            Desafio d = new Desafio();
            this.protocolo.RespuestaCorrecta = string.Empty;

            for (int i = 0; this.protocolo.RespuestaCorrecta == string.Empty && i < 10; i++)
                this.protocolo.RespuestaCorrecta = delegados[indice](ref d);

            this.protocolo.DesafiosGenerados += 1;
            if (this.protocolo.DesafiosSuperados > 0 || mensaje_parcial.Length > 0)
            {
                int desafiosPendintes = RedesSocialesAuthService.cantidadDesafiosSuperadosRequeridos - this.protocolo.DesafiosSuperados;
                d.mensaje = mensaje_parcial + "Resta responder a " + desafiosPendintes + (desafiosPendintes == 1 ? " pregunta" : " preguntas") + " de validación.";
            }
            else
            {
                d.mensaje = "Por favor ayúdenos a validar sus datos.";
            }

            d.creacion = DateTime.Now;
            this.protocolo.DesafioActual = d;
        }

        #region Desafios
        #region GenerarDesafioUltimoNombre
        private string GenerarDesafioUltimoNombre(ref Desafio desafio)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);

                int cantidadOpciones = 4;
                string[] opciones = new string[cantidadOpciones];
                string clausulas = string.Empty;

                desafio.pregunta = "¿Cuál es su último nombre?";

                string[] nombres = this.Persona.Nombre.Split(' ');
                string respuestaCorrecta = nombres[nombres.Length - 1];

                //Buscar otras personas que no contengan dicho nombre
                clausulas = "select " + PersonasService.Nombre_NombreCol + " from (" +
                            " select " + PersonasService.Nombre_NombreCol + ", rownum from (" +
                            " select " + PersonasService.Nombre_NombreCol + ", dbms_random.random from " + PersonasService.Nombre_Tabla +
                            " where lower(" + PersonasService.Nombre_NombreCol + ") not like '%" + respuestaCorrecta + "%' " +
                            "   and " + PersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo +"'" +
                            "order by 2)) where rownum < " + cantidadOpciones;
                DataTable dt = sesion.db.EjecutarQuery(clausulas);

                opciones[0] = respuestaCorrecta;
                for (int i = 1; i < cantidadOpciones; i++)
                {
                    if (i < dt.Rows.Count)
                        opciones[i] = dt.Rows[i][PersonasService.Nombre_NombreCol].ToString();
                    else
                        opciones[i] = dt.Rows[dt.Rows.Count - 1][PersonasService.Nombre_NombreCol].ToString();

                    string[] valor = opciones[i].Split(' ');
                    opciones[i] = valor[valor.Length - 1];
                }

                MezclarOpciones<string>(opciones);
                desafio.opciones = new List<string>(opciones);

                this.FinalizarUsingSesion();
                return respuestaCorrecta;
            }
        }
        #endregion GenerarDesafioUltimoNombre

        #region GenerarDesafioUltimoApellido
        private string GenerarDesafioUltimoApellido(ref Desafio desafio)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);


                this.Get<MonedasService>(1);

                int cantidadOpciones = 4;
                string[] opciones = new string[cantidadOpciones];
                string clausulas = string.Empty;

                desafio.pregunta = "¿Cuál es su último apellido?";

                string[] apellidos = this.Persona.Apellido.Split(' ');
                string respuestaCorrecta = apellidos[apellidos.Length - 1];

                //Buscar otras personas que no contengan dicho apellido
                clausulas = "select " + PersonasService.Apellido_NombreCol + " from (" +
                            " select " + PersonasService.Apellido_NombreCol + ", rownum from (" +
                            " select " + PersonasService.Apellido_NombreCol + ", dbms_random.random from " + PersonasService.Nombre_Tabla +
                            " where lower(" + PersonasService.Apellido_NombreCol + ") not like '%" + respuestaCorrecta + "%' " +
                            "   and " + PersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                            "order by 2)) where rownum < " + cantidadOpciones;
                DataTable dt = sesion.db.EjecutarQuery(clausulas);

                opciones[0] = respuestaCorrecta;
                for (int i = 1; i < cantidadOpciones; i++)
                {
                    if (dt.Rows.Count > i)
                        opciones[i] = dt.Rows[i][PersonasService.Apellido_NombreCol].ToString();
                    else
                        opciones[i] = dt.Rows[dt.Rows.Count - 1][PersonasService.Apellido_NombreCol].ToString();

                    string[] valor = opciones[i].Split(' ');
                    opciones[i] = valor[valor.Length - 1];
                }

                MezclarOpciones<string>(opciones);
                desafio.opciones = new List<string>(opciones);

                this.FinalizarUsingSesion();
                return respuestaCorrecta;
            }
        }
        #endregion GenerarDesafioUltimoApellido

        #region GenerarDesafioNacimiento
        private string GenerarDesafioNacimiento(ref Desafio desafio)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);

                int cantidadOpciones = 4;
                string[] opciones = new string[cantidadOpciones];
                string clausulas = string.Empty;

                desafio.pregunta = "¿En qué año naciste?";

                if (!this.Persona.Nacimiento.HasValue)
                    return string.Empty;

                string respuestaCorrecta = this.Persona.Nacimiento.Value.Year.ToString();

                //Buscar otras personas que no contengan dicho anho de nacimiento
                clausulas = "select " + PersonasService.Nacimiento_NombreCol + " from (" +
                            " select " + PersonasService.Nacimiento_NombreCol + ", rownum from (" +
                            " select " + PersonasService.Nacimiento_NombreCol + ", dbms_random.random from (" +
                            " select distinct to_char(" + PersonasService.Nacimiento_NombreCol + ", 'yyyy') " + PersonasService.Nacimiento_NombreCol + " from " + PersonasService.Nombre_Tabla +
                            " where to_char(" + PersonasService.Nacimiento_NombreCol + ", 'yyyy') <> '" + respuestaCorrecta + "' " +
                            "   and " + PersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                            " ) order by 2)) where rownum < " + cantidadOpciones;
                DataTable dt = sesion.db.EjecutarQuery(clausulas);

                opciones[0] = respuestaCorrecta;
                for (int i = 1; i < cantidadOpciones; i++)
                {
                    if (i < dt.Rows.Count)
                        opciones[i] = dt.Rows[i][PersonasService.Nacimiento_NombreCol].ToString();
                    else
                        opciones[i] = dt.Rows[dt.Rows.Count - 1][PersonasService.Nacimiento_NombreCol].ToString();
                }

                MezclarOpciones<string>(opciones);
                desafio.opciones = new List<string>(opciones);

                this.FinalizarUsingSesion();
                return respuestaCorrecta;
            }
        }
        #endregion GenerarDesafioNacimiento

        #region GenerarDesafioTelefono
        private string GenerarDesafioTelefono(ref Desafio desafio)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);

                int cantidadOpciones = 4;
                string[] opciones = new string[cantidadOpciones];
                string clausulas = string.Empty;

                desafio.pregunta = "¿Cuál es su teléfono?";

                string respuestaCorrecta = this.Persona.TelefonoCobranza1;
                if(respuestaCorrecta.Length <= 0)
                    respuestaCorrecta = this.Persona.Telefono1;

                if (respuestaCorrecta.Length <= 0)
                    return string.Empty;

                //Buscar otras personas que no contengan dicho telefono
                clausulas = "select " + PersonasService.TelefonoCobranza1_NombreCol + " from (" +
                            " select " + PersonasService.TelefonoCobranza1_NombreCol + ", rownum from (" +
                            " select " + PersonasService.TelefonoCobranza1_NombreCol + ", dbms_random.random from " + PersonasService.Nombre_Tabla +
                            " where " + PersonasService.TelefonoCobranza1_NombreCol + " <> '" + respuestaCorrecta + "' " +
                            "   and " + PersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                            "order by 2)) where rownum < " + cantidadOpciones;
                DataTable dt = sesion.db.EjecutarQuery(clausulas);

                opciones[0] = respuestaCorrecta;
                for (int i = 1; i < cantidadOpciones; i++)
                {
                    if (dt.Rows.Count > i)
                        opciones[i] = dt.Rows[i][PersonasService.TelefonoCobranza1_NombreCol].ToString();
                    else
                        opciones[i] = dt.Rows[dt.Rows.Count - 1][PersonasService.TelefonoCobranza1_NombreCol].ToString();
                }

                MezclarOpciones<string>(opciones);
                desafio.opciones = new List<string>(opciones);

                this.FinalizarUsingSesion();
                return respuestaCorrecta;
            }
        }
        #endregion GenerarDesafioTelefono

        #region GenerarDesafioUltimaCompraAnho
        private string GenerarDesafioUltimaCompraAnho(ref Desafio desafio)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);

                string respuestaCorrecta; 
                int cantidadOpciones = 4;
                string[] opciones = new string[cantidadOpciones];
                string clausulas = string.Empty;

                desafio.pregunta = "¿Cuándo fue su última compra?";
                
                //Buscar la ultima compra
                clausulas = CasosService.FlujoId_NombreCol + " = " + Definiciones.FlujosIDs.FACTURACION_CLIENTE + " and " +
                            CasosService.PersonaId_NombreCol + " = " + this.PersonaId + " and " +
                            CasosService.EstadoId_NombreCol + " in ('" + Definiciones.EstadosFlujos.Caja + "', '" + Definiciones.EstadosFlujos.Cerrado + "') and " +
                            CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                DataTable dt = CasosService.GetCasosDataTable(clausulas, CasosService.FechaFormFormatoNumero_NombreCol + " desc", sesion);

                if (dt.Rows.Count <= 0)
                    return string.Empty;
                
                respuestaCorrecta = ((DateTime)dt.Rows[0][CasosService.FechaFormulario_NombreCol]).Year.ToString();

                string[] opcionesExtendido = new string[12];
                bool correctaIncluda = false;
                for (int i = 0; i < opcionesExtendido.Length; i++)
                {
                    int valor = DateTime.Now.Year - i;

                    //La respuesta correcta no tiene que estar en el array
                    if(correctaIncluda || valor.ToString() == respuestaCorrecta)
                    {
                        correctaIncluda = true;
                        opcionesExtendido[i] = (valor - 1).ToString();
                    }
                    else
                    {
                        opcionesExtendido[i] = valor.ToString();
                    }
                }

                MezclarOpciones<string>(opcionesExtendido);

                //Agregar la opcion correcta y las primeras incorrectas
                opciones[0] = respuestaCorrecta;
                for (int i = 1; i < cantidadOpciones; i++)
                    opciones[i] = opcionesExtendido[i];

                MezclarOpciones<string>(opciones);
                desafio.opciones = new List<string>(opciones);

                this.FinalizarUsingSesion();
                return respuestaCorrecta;
            }
        }
        #endregion GenerarDesafioUltimaCompraAnho
        #endregion Desafios
        #endregion GenerarDesafio

        #region MezclarOpciones
        static void MezclarOpciones<T>(T[] array)
        {
            Random random = new Random();
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + random.Next(n - i);
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }
        #endregion MezclarOpciones

        #region Buscar
        protected override RedesSocialesAuthService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();

            Filtro fRedSocial = Array.Find(filtros, delegate(Filtro filtro) { return filtro.Columna == Modelo.RED_SOCIAL_IDColumnName; });
            if (fRedSocial == null)
                return null;

            Filtro fPerfil = Array.Find(filtros, delegate(Filtro filtro) { return filtro.Columna == Modelo.PERFIL_IDColumnName; });
            if (fPerfil == null)
                return null;

            sb.Append("1=1");
            foreach (Filtro f in filtros)
            {
                if (f.OrderBy)
                {
                    orden.Add(f.Columna + " " + f.Valor);
                }
                else
                {
                    sb.Append(" and ");
                    switch (f.Columna)
                    {
                        case Modelo.IDColumnName:
                        case Modelo.PERFIL_IDColumnName:
                        case Modelo.PERSONA_IDColumnName:
                        case Modelo.PROVEEDOR_IDColumnName:
                        case Modelo.RED_SOCIAL_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.AUTENTICADOColumnName:
                        case Modelo.FINALIZADOColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            REDES_SOCIALES_AUTHRow[] rows = sesion.db.REDES_SOCIALES_AUTHCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            RedesSocialesAuthService[] rsa = new RedesSocialesAuthService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                rsa[i] = new RedesSocialesAuthService(rows[i]);
            return rsa;
        }
        
        public static RedesSocialesAuthService Buscar(Hashtable autenticacion, SessionService sesion)
        {
            RedesSocialesAuthService rsa = null;

            if (!autenticacion.Contains("red_social_id"))
                return rsa;
            if (!autenticacion.Contains("perfil_id"))
                return rsa;

            string clausulas = REDES_SOCIALES_AUTHCollection.RED_SOCIAL_IDColumnName + " = " + autenticacion["red_social_id"] + " and " + REDES_SOCIALES_AUTHCollection.PERFIL_IDColumnName + " = '" + autenticacion["perfil_id"] + "'";
            REDES_SOCIALES_AUTHRow[] rows = sesion.db.REDES_SOCIALES_AUTHCollection.GetAsArray(clausulas, REDES_SOCIALES_AUTHCollection.IDColumnName + " desc");

            if (rows.Length > 0)
                rsa = new RedesSocialesAuthService(rows[0]);

            return rsa;
        }
        #endregion Buscar

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return this.ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            throw new NotImplementedException("Falta implementar.");
        }
        #endregion ToEDI

        #region BuscarOCrear
        private static RedesSocialesAuthService BuscarOCrear(Hashtable autenticacion, SessionService sesion)
        {
            RedesSocialesAuthService rsa = RedesSocialesAuthService.Buscar(autenticacion, sesion);

            if(rsa == null)
            {
                if (!autenticacion.Contains("red_social_id"))
                    throw new Exception("El valor 'red_social_id' debe estar definido");
                if (!autenticacion.Contains("perfil_id"))
                    throw new Exception("El valor 'perfil_id' debe estar definido");

                if (autenticacion.Contains("tabla_id") && autenticacion.Contains("numero_documento"))
                {
                    string nroDocumento = (string)autenticacion["numero_documento"];
                    
                    //quitar el guion y digito verificador si existe
                    int index = nroDocumento.IndexOf("-");
                    if (index > 0)
                        nroDocumento = nroDocumento.Substring(0, index);
                    
                    //tomar solo numeros
                    Regex soloNumeros = new Regex(@"[^\d]");
                    nroDocumento = soloNumeros.Replace(nroDocumento, string.Empty);

                    rsa = Crear((int)autenticacion["red_social_id"], (string)autenticacion["perfil_id"], (string)autenticacion["tabla_id"], nroDocumento, sesion);
                }
            }

            return rsa;
        }
        #endregion BuscarOCrear

        #region Interactuar
        public static Respuesta Interactuar(Hashtable autenticacion, Hashtable desafio, SessionService sesion)
        {
            RedesSocialesAuthService rsa = BuscarOCrear(autenticacion, sesion);
            rsa.IniciarUsingSesion(sesion);

            Respuesta r = new Respuesta();
            string mensajeParcial = string.Empty;

            //No existia ni contuvo los parametros tabla_id y numero_documento
            if (rsa == null)
            {
                r.autenticado = false;
                return r;
            }

            //Ya estaba autenticado
            if (rsa.Autenticado == Definiciones.SiNo.Si)
            {
                r.autenticado = true;
                if (rsa.PersonaId.HasValue)
                {
                    r.nombreUsuario = rsa.Persona.Nombre;
                    r.apellidoUsuario = rsa.Persona.Apellido;
                }
                else if (rsa.ProveedorId.HasValue)
                {
                    r.nombreUsuario = rsa.Proveedor.NombreFantasia;
                    r.apellidoUsuario = rsa.Proveedor.RazonSocial;
                }

                return r;
            }

            //Si supero el tiempo de reseteo se reinicia el protocolo
            if (rsa.protocolo.DesafioActual == null || rsa.protocolo.DesafioActual.creacion.Add(rsa.tiempoParaResetear) < DateTime.Now)
            {
                rsa.protocolo = new Protocolo();
            }

            //Se encuentra en proceso de autenticacion
            if (desafio != null && desafio.Contains("respuesta"))
            {
                if (rsa.protocolo.RespuestaCorrecta == (string)desafio["respuesta"])
                    rsa.protocolo.DesafiosSuperados++;
                else
                    mensajeParcial = "Incorrecto. ";

                if (rsa.protocolo.DesafiosSuperados >= RedesSocialesAuthService.cantidadDesafiosSuperadosRequeridos)
                {
                    rsa.Autenticado = Definiciones.SiNo.Si;
                    rsa.Finalizado = Definiciones.SiNo.Si;
                    rsa.Guardar();

                    r.autenticado = true;
                    if (rsa.PersonaId.HasValue)
                    {
                        r.nombreUsuario = rsa.Persona.Nombre;
                        r.apellidoUsuario = rsa.Persona.Apellido;
                    }
                    else if (rsa.ProveedorId.HasValue)
                    {
                        r.nombreUsuario = rsa.Proveedor.NombreFantasia;
                        r.apellidoUsuario = rsa.Proveedor.RazonSocial;
                    }

                    return r;
                }
            }

            //Si ya supero la cantidad de intentos se rechaza la respuesta
            if (rsa.protocolo.DesafiosGenerados - rsa.protocolo.DesafiosSuperados + RedesSocialesAuthService.cantidadDesafiosSuperadosRequeridos > RedesSocialesAuthService.cantidadDesafiosMax)
            {
                r.desafio = new Desafio();
                r.desafio.mensaje = "Demasiados intos fallidos. Vuelva a intentar luego de las " + rsa.protocolo.DesafioActual.creacion.Add(rsa.tiempoParaResetear).ToShortTimeString() + ".";
                rsa.protocolo.DesafioActual = r.desafio;
                rsa.protocolo.DesafioActual.creacion = DateTime.Now;
                rsa.Guardar();
                return r;
            }

            rsa.GenerarDesafio(mensajeParcial);
            r.desafio = rsa.protocolo.DesafioActual;
            r.timeout = (int)rsa.tiempoParaResponder.TotalSeconds;

            rsa.Guardar();

            rsa.FinalizarUsingSesion();
            return r;
        }
        #endregion Interactuar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "REDES_SOCIALES_AUTH"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "REDES_SOCIALES_AUTH_SQC"; }
        }
        #endregion Accessors
    }
}
