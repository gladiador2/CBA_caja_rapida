#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;

using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using System.Collections;
#endregion Using

namespace CBA.FlowV2.Services.CRM
{
    public class CrmHilosEntradasService : ClaseCBA<CrmHilosEntradasService>
    {
        #region FiltrosExtension
        public static class FiltroExtension
        {
            public const string EntradaSinLeer = "ENTRADA_SIN_LEER";
        }
        #endregion FiltrosExtension
        
        #region Propiedades
        protected CRM_HILOS_ENTRADASRow row;
        protected CRM_HILOS_ENTRADASRow rowSinModificar;
        public class Modelo : CRM_HILOS_ENTRADASCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal CrmHiloId { get { return row.CRM_HILO_ID; } set { row.CRM_HILO_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public DateTime? FechaAlarma { get { if (row.IsFECHA_ALARMANull) return null; else return row.FECHA_ALARMA; } set { if (value.HasValue) row.FECHA_ALARMA = value.Value; else row.IsFECHA_ALARMANull = true; } }
        public DateTime FechaCreacion { get { return row.FECHA_CREACION; } set { row.FECHA_CREACION = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Texto { get { return ClaseCBABase.GetStringHelper(row.TEXTO); } set { row.TEXTO = value; } }
        public decimal UsuarioCreacionId { get { return row.USUARIO_CREACION_ID; } set { row.USUARIO_CREACION_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CrmHilosService _crm_hilo;
        public CrmHilosService CrmHilo
        {
            get
            {
                if (this._crm_hilo == null)
                {
                    if (this.sesion != null)
                        this._crm_hilo = new CrmHilosService(this.CrmHiloId, this.sesion);
                    else
                        this._crm_hilo = new CrmHilosService(this.CrmHiloId);
                }
                return this._crm_hilo;
            }
        }

        private UsuariosService _usuario_creacion;
        public UsuariosService UsuarioCreacion
        {
            get
            {
                if (this._usuario_creacion == null)
                {
                    if (this.sesion != null)
                        this._usuario_creacion = new UsuariosService(this.UsuarioCreacionId, this.sesion);
                    else
                        this._usuario_creacion = new UsuariosService(this.UsuarioCreacionId);
                }
                return this._usuario_creacion;
            }
        }

        private CrmHilosEntradasUsuariosService _crm_hilo_entrada_usuario;
        public CrmHilosEntradasUsuariosService CrmHiloEntradaUsuario
        {
            get
            {
                if (this._crm_hilo_entrada_usuario == null)
                {
                    if (this.sesion != null)
                        this._crm_hilo_entrada_usuario = CrmHilosEntradasUsuariosService.GetPorEntrada(this, this.sesion);
                    else
                        this._crm_hilo_entrada_usuario = CrmHilosEntradasUsuariosService.GetPorEntrada(this);
                }
                return this._crm_hilo_entrada_usuario;
            }
        }
        #endregion Propiedades Extendidas

        #region Propiedades OneToMany
        private CrmHilosEntradasRelacionesService[] _crm_hilos_entradas_relaciones_relaciones;
        public CrmHilosEntradasRelacionesService[] Relaciones
        {
            get
            {
                if (this._crm_hilos_entradas_relaciones_relaciones == null)
                {
                    this._crm_hilos_entradas_relaciones_relaciones = this.GetFiltrado<CrmHilosEntradasRelacionesService>(new Filtro[] 
                    {
                        new Filtro { Columna = CrmHilosEntradasRelacionesService.Modelo.CRM_HILOS_ENTRADA_IDColumnName, Valor = this.Id.Value },
                        new Filtro { Columna = CrmHilosEntradasRelacionesService.Modelo.IDColumnName, OrderBy = true },
                    });
                }
                return this._crm_hilos_entradas_relaciones_relaciones;
            }
        }
        #endregion Propiedades OneToMany

        #region Permisos
        public Permiso Permisos = new Permiso();
        public class Permiso
        {
            private bool? _crmHilosEntradasEditarOtrosUsuarios;
            public bool CrmHilosEntradasEditarOtrosUsuarios { get { if (this._crmHilosEntradasEditarOtrosUsuarios == null) this._crmHilosEntradasEditarOtrosUsuarios = RolesService.Tiene("CRM HILOS ENTRADAS EDITAR OTROS USUARIOS"); return this._crmHilosEntradasEditarOtrosUsuarios.Value; } }
            private bool? _crmHilosEntradasNotificarCambio;
            public bool CrmHilosEntradasNotificarCambio { get { if (this._crmHilosEntradasNotificarCambio == null) this._crmHilosEntradasNotificarCambio = RolesService.Tiene("CRM HILOS ENTRADAS NOTIFICAR CAMBIO"); return this._crmHilosEntradasNotificarCambio.Value; } }
        }
        #endregion Permisos

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CRM_HILOS_ENTRADASCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CRM_HILOS_ENTRADASRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CRM_HILOS_ENTRADASRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CrmHilosEntradasService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CrmHilosEntradasService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CrmHilosEntradasService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private CrmHilosEntradasService(CRM_HILOS_ENTRADASRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            if (!this.ExisteEnDB)
                this.UsuarioCreacionId = sesion.Usuario.ID;
            this.Validar();

            if (!this.ExisteEnDB)
            {
                this.row.ID = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.row.ESTADO = Definiciones.Estado.Activo;
                this.row.FECHA_CREACION = DateTime.Now;
                if (this.Texto.Length <= 0)
                    this.row.TEXTO = " ";
                sesion.db.CRM_HILOS_ENTRADASCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion); 
            }
            else
            {
                sesion.db.CRM_HILOS_ENTRADASCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), this.rowSinModificar.ToString(), sesion);
            }

            this.CrmHilo.FechaUltimaModificacion = DateTime.Now;
            this.CrmHilo.IniciarUsingSesion(sesion);
            this.CrmHilo.Guardar();
            this.CrmHilo.FinalizarUsingSesion();

            #region Intentar parsing de texto
            if (this.Texto != this.rowSinModificar.TEXTO && this.Permisos.CrmHilosEntradasNotificarCambio)
            {
                var retorno = CBA.FlowV2.Services.Base.ParseUtil.Buscar(this.Texto, Definiciones.ParseUtil.Usuario);
                if(retorno.ContainsKey(typeof(UsuariosService)))
                {
                    string asunto = this.CrmHilo.Asunto;
                    string mensaje = "Le informamos que el hilo '" + this.CrmHilo.Asunto + "' ha sido modificado de:<br><br>" + this.rowSinModificar.TEXTO + "<br><br> a <br><br>" + this.Texto + "<br><br> Favor no responda a este correo.";
                    var lUsuarios = (List<UsuariosService>)retorno[typeof(UsuariosService)];
                    string[] direcciones = new String[lUsuarios.Count];
                    int a = 0;
                    
                    foreach (var u in lUsuarios)
                        direcciones[a++] = u.Email;

                    if (direcciones.Length > 0)
                    {
                        using (EmailService correo = new EmailService(true, sesion))
                            correo.EnviarMail(direcciones, asunto, mensaje, sesion, string.Empty, 6);
                    }
                }
            }
            #endregion Intentar parsing de texto
            
            this.rowSinModificar = this.row.Clonar();

            return this.row.ID;
        }
        #endregion Guardar

        #region Borrar
        public void Borrar()
        {
            this.Estado = Definiciones.Estado.Inactivo;

            string clausulas = CasosEtiquetasService.TablaId_NombreCol + " = '" + CrmHilosEntradasService.Nombre_Tabla + "' and " +
                               CasosEtiquetasService.RegistroId_NombreCol + " = " + this.Id.Value;
            DataTable dt = CasosEtiquetasService.GetCasosEtiquetasDataTable(clausulas, CasosEtiquetasService.TextoPredefinidoId_NombreCol);
            for (int i = 0; i < dt.Rows.Count; i++)
                CasosEtiquetasService.Borrar((decimal)dt.Rows[i][CasosEtiquetasService.Id_NombreCol], sesion);

            this.Guardar();
        }
        #endregion Borrar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            if (this.UsuarioCreacionId != sesion.Usuario.ID && !this.Permisos.CrmHilosEntradasEditarOtrosUsuarios)
                excepciones.Agregar("No puede guardar una entrada creada por otro usuario.");

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._crm_hilo = null;
            this._crm_hilo_entrada_usuario = null;
            this._usuario_creacion = null;

            this._crm_hilos_entradas_relaciones_relaciones = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override CrmHilosEntradasService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append(Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'");

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
                        case Modelo.TEXTOColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case Modelo.CRM_HILO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.USUARIO_CREACION_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.FECHAColumnName:
                        case Modelo.FECHA_ALARMAColumnName:
                        case Modelo.FECHA_CREACIONColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        case FiltroExtension.EntradaSinLeer:
                            if ((bool)f.Valor)
                                sb.Append(" not ");
                            sb.Append(" exists(select * from " + CrmHilosEntradasUsuariosService.Nombre_Tabla + " cheu" +
                                     "          where cheu." + CrmHilosEntradasUsuariosService.Modelo.CRM_HILOS_ENTRADA_IDColumnName + " = " + Nombre_Tabla + "." + Modelo.IDColumnName +
                                     "            and cheu." + CrmHilosEntradasUsuariosService.Modelo.USUARIO_IDColumnName + " = " + this.sesion.Usuario.ID +
                                     "            and cheu." + CrmHilosEntradasUsuariosService.Modelo.FECHA_LECTURAColumnName + " is not null) ");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.FECHA_CREACIONColumnName + " desc");
            var rows = sesion.db.CRM_HILOS_ENTRADASCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            CrmHilosEntradasService[] e = new CrmHilosEntradasService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                e[i] = new CrmHilosEntradasService(rows[i]);

            return e;
        }
        #endregion Buscar

        #region GetSinLeer
        public static CrmHilosEntradasService GetSinLeer(CrmHilosService hilo)
        {
            using (SessionService sesion = new SessionService())
            {
                decimal cantidad = 0;
                return GetSinLeer(hilo, out cantidad, sesion);
            }
        }

        public static CrmHilosEntradasService GetSinLeer(CrmHilosService hilo, out decimal cantidad)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetSinLeer(hilo, out cantidad, sesion);
            }
        }

        public static CrmHilosEntradasService GetSinLeer(CrmHilosService hilo, SessionService sesion)
        {
            decimal cantidad = 0;
            return GetSinLeer(hilo, out cantidad, sesion);
        }

        public static CrmHilosEntradasService GetSinLeer(CrmHilosService hilo, out decimal cantidad, SessionService sesion)
        {
            var filtros = new Filtro[]
            {
                new Filtro() { Columna = Modelo.CRM_HILO_IDColumnName, Valor = hilo.Id.Value },
                new Filtro() { Columna = FiltroExtension.EntradaSinLeer, Valor = true },
                new Filtro() { Columna = Modelo.FECHAColumnName, OrderBy = true },
            };

            var che = CrmHilosEntradasService.Instancia.GetFiltrado<CrmHilosEntradasService>(filtros);
            cantidad = che.Length;

            if(che.Length > 0)
                return che[0];
            else
                return new CrmHilosEntradasService();
        }
        #endregion GetSinLeer

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

        #region Accessors
        public static string Nombre_Tabla = "CRM_HILOS_ENTRADAS";
        public static string Nombre_Secuencia = "CRM_HILOS_ENTRADAS_SQC";
        #endregion Accessors
    }
}
