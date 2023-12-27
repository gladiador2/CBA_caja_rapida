#region Using
using System;
using System.Collections.Generic;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.TextosPredefinidos;
using CBA.FlowV2.Services.Common;
using System.ComponentModel;
using CBA.FlowV2.Services.General;
using System.Text.RegularExpressions;
using System.Collections;
using System.Text;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class NotificacionesSuscripcionesService : ClaseCBA<NotificacionesSuscripcionesService>
    { 
        #region clase EstructuraHelper
        public class EstructuraHelper
        {
            #region enum Campo
            public static class Campo
            {
                public const string FuncionarioId = "FuncionarioId";
                public const string PersonaId = "PersonaId";
                public const string PK = "PK"; //PrimaryKey de notificaciones_suscripciones
                public const string ProveedorId = "ProveedorId";
                public const string UsuarioId = "SucursalId";
                public const string Tipo = "Tipo";
 				public const string LineaId = "LineaId";
            }
            #endregion enum Campo

            #region propiedades
            public const string tagOpen = "<t>";
            public const string tagClose = "</t>";
            public string texto;

            public string[] Campos
            {
                get
                {
                    string[] tokens = Regex.Split(this.texto, @"<t>(.*?)</t>");
                    string[] resultado = new string[tokens.Length / 2];

                    for (int i = 1; i < tokens.Length; i += 2)
                        resultado[i / 2] = tokens[i];

                    return resultado;
                }
            }
            #endregion propiedades

            #region Constructores
            public EstructuraHelper(string estructura_base)
            {
                this.texto = estructura_base;
            }
            #endregion Constructores

            #region Set
            public void Set(string campo, object valor)
            {
                string str = string.Empty;
                if (valor != null && valor != DBNull.Value)
                    str = valor.ToString();

                this.texto = this.texto.Replace(tagOpen + campo + tagClose, str);
            }
            #endregion Set
        }
        #endregion clase EstructuraHelper

        #region Clase GestorEnvio
        public class GestorEnvio
        {
            #region Clase Remitente
            public class Remitente
            {
                public int CanalComunicacion; //Corresponde a Definiciones.CanalesComunicacion
                public string Direccion;
                public string Observacion;
                public decimal? UsuarioId;
                public decimal? PersonaId;
                public decimal? ProveedorId;
                public decimal? FuncionarioId;

                private UsuariosService _usuario;
                [Newtonsoft.Json.JsonIgnore]
                public UsuariosService Usuario
                {
                    get
                    {
                        if (!this.UsuarioId.HasValue)
                            throw new Exception("El usuairo no está definido.");

                        if (this._usuario == null)
                            this._usuario = new UsuariosService(this.UsuarioId.Value);
                        return this._usuario;
                    }
                }

                private PersonasService _persona;
                [Newtonsoft.Json.JsonIgnore]
                public PersonasService Persona
                {
                    get
                    {
                        if (!this.PersonaId.HasValue)
                            throw new Exception("La persona no está definida.");

                        if (this._persona == null)
                            this._persona = new PersonasService(this.PersonaId.Value);
                        return this._persona;
                    }
                }

                private ProveedoresService _proveedor;
                [Newtonsoft.Json.JsonIgnore]
                public ProveedoresService Proveedor
                {
                    get
                    {
                        if (!this.ProveedorId.HasValue)
                            throw new Exception("El proveedor no está definido.");

                        if (this._proveedor == null)
                            this._proveedor = new ProveedoresService(this.ProveedorId.Value);
                        return this._proveedor;
                    }
                }

                private FuncionariosService _funcionario;
                [Newtonsoft.Json.JsonIgnore]
                public FuncionariosService Funcionario
                {
                    get
                    {
                        if (!this.FuncionarioId.HasValue)
                            throw new Exception("El funcionario no está definido.");

                        if (this._funcionario == null)
                            this._funcionario = new FuncionariosService(this.FuncionarioId.Value);
                        return this._funcionario;
                    }
                }

                public Remitente()
                { 
                    CanalComunicacion=Definiciones.Error.Valor.IntPositivo; //Corresponde a Definiciones.CanalesComunicacion
                    Direccion=string.Empty;
                    Observacion = string.Empty;
                }
            }
            #endregion Clase Remitente

            #region Propiedades
            public List<Remitente> Remitentes;
            #endregion Propiedades

            #region Constructores
            public GestorEnvio()
            {
                this.Remitentes = new List<Remitente>();
            }
            #endregion Constructores

            #region Agregar
            public void Agregar(Remitente remitente)
            {
                this.Remitentes.Add(remitente);
            }
            #endregion Agregar

            #region Quitar
            public void Quitar(Remitente remitente)
            {
                Remitente item = null;
                if (remitente.UsuarioId.HasValue)
                {
                    foreach (Remitente r in this.Remitentes)
                    {
                        if (r.UsuarioId == remitente.UsuarioId)
                        {
                            item = r;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (Remitente r in this.Remitentes)
                    {
                        if (r.Direccion == remitente.Direccion)
                        {
                            item = r;
                            break;
                        }
                    }
                }

                if (item != null)
                    this.Remitentes.Remove(item);
            }
            #endregion Quitar

            #region EnviarNotificaciones
            public void EnviarNotificaciones(NotificacionesService notificacion, NotificacionesSuscripcionesService notificacion_suscriptor, SessionService sesion, string archivo_adjunto)
            {
                EnviarNotificaciones(notificacion,notificacion_suscriptor, false, archivo_adjunto, sesion);
            }

            public void EnviarNotificaciones(NotificacionesService notificacion,NotificacionesSuscripcionesService notificacion_suscriptor, bool usar_smtp_cliente, string archivo_adjunto, SessionService sesion)
            {
                List<string> destinatariosAlarma = new List<string>();
                List<string> destinatariosAlarmaImportante = new List<string>();
                string mailCuerpo = "<html><body>" + notificacion.PlantillaAsunto + "<br><br>" + notificacion.PlantillaLarga + "</body></html>";

                foreach (Remitente r in this.Remitentes)
                {
                    //Preparar los destinatarios de notificacion para enviar a todos de una vez
                    switch(r.CanalComunicacion)
                    {
                        case Definiciones.CanalesComunicacion.Notificador:
                            if(r.UsuarioId.HasValue)
                                destinatariosAlarma.Add(r.UsuarioId.ToString());
                            break;
                        case Definiciones.CanalesComunicacion.NotificadorImportante:
                            if (r.UsuarioId.HasValue)
                                destinatariosAlarmaImportante.Add(r.UsuarioId.ToString());
                            break;
                        case Definiciones.CanalesComunicacion.Email:
                            using (EmailService correo = new EmailService(usar_smtp_cliente, sesion))
                            {
                                if (r.Direccion.Length > 0)
                                    correo.EnviarMail(r.Direccion, notificacion.PlantillaAsunto, mailCuerpo, sesion, archivo_adjunto);

                                if (notificacion_suscriptor.DestinosMailUsarFicha == Definiciones.SiNo.Si)
                                {
                                    string direccion = string.Empty;
                                    if (r.UsuarioId.HasValue)
                                        correo.EnviarMail(r.Usuario.Email, notificacion.PlantillaAsunto, mailCuerpo, sesion, archivo_adjunto);

                                    if (r.PersonaId.HasValue)
                                    {
                                        if (r.Persona.Email1.Length > 0)
                                            correo.EnviarMail(r.Persona.Email1, notificacion.PlantillaAsunto, mailCuerpo, sesion, archivo_adjunto);
                                        if (r.Persona.Email2.Length > 0)
                                            correo.EnviarMail(r.Persona.Email2, notificacion.PlantillaAsunto, mailCuerpo, sesion, archivo_adjunto);
                                        if (r.Persona.Email3.Length > 0)
                                            correo.EnviarMail(r.Persona.Email3, notificacion.PlantillaAsunto, mailCuerpo, sesion, archivo_adjunto);

                                    }
                                    if (r.FuncionarioId.HasValue)
                                    {
                                        if (r.Funcionario.Email1.Length > 0)
                                            correo.EnviarMail(r.Funcionario.Email1, notificacion.PlantillaAsunto, mailCuerpo, sesion, archivo_adjunto);
                                        if (r.Funcionario.Email2.Length > 0)
                                            correo.EnviarMail(r.Funcionario.Email2, notificacion.PlantillaAsunto, mailCuerpo, sesion, archivo_adjunto);
                                        if (r.Funcionario.Email3.Length > 0)
                                            correo.EnviarMail(r.Funcionario.Email3, notificacion.PlantillaAsunto, mailCuerpo, sesion, archivo_adjunto);
                                    }
                                    if (r.ProveedorId.HasValue)
                                    {
                                        if (r.Proveedor.ContactoEmail.Length > 0)
                                            correo.EnviarMail(r.Proveedor.Email1, notificacion.PlantillaAsunto, mailCuerpo, sesion, archivo_adjunto);
                                        if (r.Proveedor.Email1.Length > 0)
                                            correo.EnviarMail(r.Proveedor.Email1, notificacion.PlantillaAsunto, mailCuerpo, sesion, archivo_adjunto);
                                        if (r.Proveedor.Email2.Length > 0)
                                            correo.EnviarMail(r.Proveedor.Email2, notificacion.PlantillaAsunto, mailCuerpo, sesion, archivo_adjunto);
                                        if (r.Proveedor.Email3.Length > 0)
                                            correo.EnviarMail(r.Proveedor.Email3, notificacion.PlantillaAsunto, mailCuerpo, sesion, archivo_adjunto);
                                    }
                                }
                            }
                            break;
                        default:
                            throw new Exception("Canal de comunicación " + r.CanalComunicacion + " no implementado.");
                    }
                }

                if (destinatariosAlarma.Count > 0)
                    NotificadorService.Enviar(string.Join(",", destinatariosAlarma.ToArray()), notificacion_suscriptor.Notificacion.PlantillaAsunto, notificacion_suscriptor.Notificacion.PlantillaCorta, true, false, string.Empty, sesion);
                if (destinatariosAlarmaImportante.Count > 0)
                    NotificadorService.Enviar(string.Join(",", destinatariosAlarmaImportante.ToArray()), notificacion_suscriptor.Notificacion.PlantillaAsunto, notificacion_suscriptor.Notificacion.PlantillaCorta, true, true, string.Empty, sesion);
            }
            #endregion EnviarNotificaciones
        }
        #endregion Clase GestorEnvio

        #region FiltrosExtension
        public static class FiltroExtension
        {
            public const string DatosCondiciones = "DatosCondiciones";
        }
        #endregion FiltrosExtension

        #region Propiedades
        protected NOTIFICACIONES_SUSCRIPCIONESRow row;
        protected NOTIFICACIONES_SUSCRIPCIONESRow rowSinModificar;
        public class Modelo : NOTIFICACIONES_SUSCRIPCIONESCollection_Base { public Modelo() : base(null) { } }
        
        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string DestinosJSON { get { return GetStringHelper(row.DESTINOS_JSON); } set { row.DESTINOS_JSON = value; } }
        public string DestinosMailUsarFicha { get { return row.DESTINOS_MAIL_USAR_FICHA; } set { row.DESTINOS_MAIL_USAR_FICHA = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? FuncionarioId { get { if (row.IsFUNCIONARIO_IDNull) return null; else return row.FUNCIONARIO_ID; } set { if (value.HasValue) row.FUNCIONARIO_ID = value.Value; else row.IsFUNCIONARIO_IDNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal NotificacionId { get { return row.NOTIFICACION_ID; } set { row.NOTIFICACION_ID = value; } }
        public decimal? PersonaId { get { if (row.IsPERSONA_IDNull) return null; else return row.PERSONA_ID; } set { if (value.HasValue) row.PERSONA_ID = value.Value; else row.IsPERSONA_IDNull = true; } }
        public decimal? ProveedorId { get { if (row.IsPROVEEDOR_IDNull) return null; else return row.PROVEEDOR_ID; } set { if (value.HasValue) row.PROVEEDOR_ID = value.Value; else row.IsPROVEEDOR_IDNull = true; } }
        public decimal? UsuarioId { get { if (row.IsUSUARIO_IDNull) return null; else return row.USUARIO_ID; } set { if (value.HasValue) row.USUARIO_ID = value.Value; else row.IsUSUARIO_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private GestorEnvio _destinos;
        public GestorEnvio Destinos
        {
            get
            {
                if (this._destinos == null)
                {
                    if (Interprete.EsNullODBNull(row.DESTINOS_JSON))
                    {
                        this._destinos = new GestorEnvio();
                        row.DESTINOS_JSON = JsonUtil.Serializar(this._destinos);
                    }
                    else
                    {
                        this._destinos = JsonUtil.Deserializar<GestorEnvio>(row.DESTINOS_JSON);
                    }
                }
                return this._destinos;
            }
        }

        private NotificacionesService _notificacion;
        public NotificacionesService Notificacion
        {
            get
            {
                if (this._notificacion == null)
                    this._notificacion = new NotificacionesService(this.NotificacionId);
                return this._notificacion;
            }
        }

        private FuncionariosService _funcionario;
        public FuncionariosService Funcionario
        {
            get
            {
                if (this._funcionario == null)
                    this._funcionario = new FuncionariosService(this.FuncionarioId.Value);
                return this._funcionario;
            }
        }

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

        private UsuariosService _usuario;
        public UsuariosService Usuario
        {
            get
            {
                if (this._usuario == null)
                    this._usuario = new UsuariosService(this.UsuarioId.Value);
                return this._usuario;
            }
        }
        #endregion Propiedades Extendidas

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._funcionario = null;
            this._notificacion = null;
            this._persona = null;
            this._proveedor = null;
            this._usuario = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.NOTIFICACIONES_SUSCRIPCIONESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new NOTIFICACIONES_SUSCRIPCIONESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(NOTIFICACIONES_SUSCRIPCIONESRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public NotificacionesSuscripcionesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public NotificacionesSuscripcionesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public NotificacionesSuscripcionesService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private NotificacionesSuscripcionesService(NOTIFICACIONES_SUSCRIPCIONESRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            if (!RolesService.Tiene("NOTIFICACIONES EDITAR"))
                throw new Exception("No tiene permisos para guardar"); 
            
            this.Validar();

            row.DESTINOS_JSON = JsonUtil.Serializar(this.Destinos);

            if (!this.ExisteEnDB)
            {
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                sesion.db.NOTIFICACIONES_SUSCRIPCIONESCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.NOTIFICACIONES_SUSCRIPCIONESCollection.Update(this.row);
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

        #region Buscar
        protected override NotificacionesSuscripcionesService[] Buscar(Filtro[] filtros)
        {
            Filtro fNotificadocion, fDatosAsociados;

            fNotificadocion = Array.Find(filtros, delegate(Filtro filtro) { return filtro.Columna == Modelo.NOTIFICACION_IDColumnName; });
            if (fNotificadocion == null)
                throw new Exception(this.GetType().ToString() + ".Buscar(). Debe filtrar por notificacion.");

            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();

            sb.Append(Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' and " +
                      Modelo.NOTIFICACION_IDColumnName + " = " + fNotificadocion.Valor);

            fDatosAsociados = Array.Find(filtros, delegate(Filtro filtro) { return filtro.Columna == FiltroExtension.DatosCondiciones; });
            if (fDatosAsociados != null)
            {
                Hashtable ht = (Hashtable)fDatosAsociados.Valor;

                if (ht.Contains(EstructuraHelper.Campo.PersonaId))
                {
                    sb.Append(" and (" + NotificacionesSuscripcionesService.Modelo.PERSONA_IDColumnName + " = " + ht[NotificacionesSuscripcionesService.EstructuraHelper.Campo.PersonaId] + " or ");
                    sb.Append("      " + NotificacionesSuscripcionesService.Modelo.PERSONA_IDColumnName + " is null )");
                }
                if (ht.Contains(EstructuraHelper.Campo.ProveedorId))
                {
                    sb.Append(" and (" + NotificacionesSuscripcionesService.Modelo.PROVEEDOR_IDColumnName + " = " + ht[NotificacionesSuscripcionesService.EstructuraHelper.Campo.ProveedorId] + " or ");
                    sb.Append("      " + NotificacionesSuscripcionesService.Modelo.PROVEEDOR_IDColumnName + " is null )");
                }
                if (ht.Contains(EstructuraHelper.Campo.FuncionarioId))
                {
                    sb.Append(" and (" + NotificacionesSuscripcionesService.Modelo.FUNCIONARIO_IDColumnName + " = " + ht[NotificacionesSuscripcionesService.EstructuraHelper.Campo.FuncionarioId] + " or ");
                    sb.Append("      " + NotificacionesSuscripcionesService.Modelo.FUNCIONARIO_IDColumnName + " is null )");
                }
                if (ht.Contains(EstructuraHelper.Campo.UsuarioId))
                {
                    sb.Append(" and (" + NotificacionesSuscripcionesService.Modelo.USUARIO_IDColumnName + " = " + ht[NotificacionesSuscripcionesService.EstructuraHelper.Campo.UsuarioId] + " or ");
                    sb.Append("      " + NotificacionesSuscripcionesService.Modelo.USUARIO_IDColumnName + " is null )");
                }
            }

            orden.Add(Modelo.IDColumnName);
            NOTIFICACIONES_SUSCRIPCIONESRow[] rows = sesion.db.NOTIFICACIONES_SUSCRIPCIONESCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            NotificacionesSuscripcionesService[] ns = new NotificacionesSuscripcionesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                ns[i] = new NotificacionesSuscripcionesService(rows[i]);
            return ns;
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

        #region Enviar
        public static void Enviar(NotificacionesService notificacion, Hashtable datos_condiciones, SessionService sesion, string archivo_adjunto, bool usar_smtp_cliente)
        {
            NotificacionesSuscripcionesService[] suscripciones = NotificacionesSuscripcionesService.Instancia.GetFiltrado<NotificacionesSuscripcionesService>(new Filtro[]
                {
                    new Filtro { Columna = Modelo.NOTIFICACION_IDColumnName, Valor = notificacion.Id.Value},
                    new Filtro { Columna = FiltroExtension.DatosCondiciones, Valor = datos_condiciones}
                }
            );

            foreach (NotificacionesSuscripcionesService s in suscripciones)
                s.Destinos.EnviarNotificaciones(notificacion, s, usar_smtp_cliente, archivo_adjunto, sesion);
        }
        #endregion Enviar

        public static DataTable GetAsDataTable(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'";
                if (clausulas.Length > 0)
                    where += " and (" + clausulas + ")";
                return sesion.db.NOTIFICACIONES_SUSCRIPCIONESCollection.GetAsDataTable(clausulas, NOTIFICACIONES_SUSCRIPCIONESCollection.IDColumnName);
            }
        }

        #region Accessors
        public static string Nombre_Tabla = "NOTIFICACIONES_SUSCRIPCIONES";
        public static string Nombre_Secuencia = "NOTIFICACIONES_SUSCRIPC_SQC";
        #endregion Accessors
    }
}
