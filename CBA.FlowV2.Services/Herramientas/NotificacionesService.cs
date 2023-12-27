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
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Tesoreria;
using System.Text.RegularExpressions;
using System.Collections;
using System.Text;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class NotificacionesService : ClaseCBA<NotificacionesService>
    {
        #region clase EstructuraHelper
        public class EstructuraHelper
        {
            #region enum Campo
            public static class Campo
            {
                public const string Deposito = "Deposito";
                public const string Funcionario = "Funcionario";
                public const string FuncionarioId = "FuncionarioId";
                public const string MonedaSimbolo = "MonedaSimbolo";
                public const string Nombre = "Nombre";
                public const string NotificacionId = "NotificacionId";
                public const string NroComprobante = "NroComprobante";
                public const string Persona = "Persona";
                public const string PersonaId = "PersonaId";
                public const string Proveedor = "Proveedor";
                public const string ProveedorId = "ProveedorId";
                public const string UsuarioId = "UsuarioId";
                public const string PK = "PK"; //PrimaryKey valido para id del caso, funcionario, persona, etc.
                public const string Sucursal = "Sucursal";
                public const string SucursalId = "SucursalId";
                public const string Total = "Total";
                public const string DocumentoNroComprobante = "DocumentoNroComprobante";
                public const string ValoresResumen = "ValoresResumen";
                //Datos de logistica
                public const string Contenedor = "Contenedor";
                public const string LineaMaritima = "LineaMaritima";
                public const string Booking = "Booking";
                public const string Precintos = "Precintos";
                public const string PesoNeto = "PesoNeto";
                public const string VGM = "VGM";
                public const string Ticket = "Ticket";
                public const string FechaHora = "FechaHora";
                public const string FechaInicio = "Inicio";
                public const string FechaFin = "Fin";
                public const string Chofer = "Chofer";
                public const string RUACamion = "RUACamion";
                public const string RUACarreta = "RUACarreta";
                public const string Buque = "Buque";
                public const string Viaje = "Viaje";
                public const string ListaContendores = "ListaContendores";
                public const string Cantidad = "Cantidad";
                public const string Fecha = "Fecha";
                public const string Tipo = "Tipo";
                public const string Amarre = "Amarre";
                public const string Desamarre = "Desamarre";
                public const string Tabla = "Tabla";
            }
            #endregion enum Campo

            #region propiedades
            public const string tagOpen = "<t>";
            public const string tagClose = "</t>";
            public string texto;
            public string asunto;

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
            public EstructuraHelper(string estructura_base, string descripcion)
            {
                this.texto = estructura_base;
                this.asunto = descripcion;
            }
            #endregion Constructores

            #region Set
            public void Set(string campo, object valor)
            {
                string str = string.Empty;
                if (valor != null && valor != DBNull.Value)
                    str = valor.ToString();

                this.texto = this.texto.Replace(tagOpen + campo + tagClose, str);
                this.asunto = this.asunto.Replace(tagOpen + campo + tagClose, str);
            }
            #endregion Set
        }
        #endregion clase EstructuraHelper

        #region Propiedades
        protected NOTIFICACIONESRow row;
        protected NOTIFICACIONESRow rowSinModificar;
        public class Modelo : NOTIFICACIONESCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string AccionCreacion { get { return row.ACCION_CREACION; } set { row.ACCION_CREACION = value; } }
        public string AccionEdicion { get { return row.ACCION_EDICION; } set { row.ACCION_EDICION = value; } }
        public string CondicionSQL { get { return GetStringHelper(row.CONDICION_SQL); } set { row.CONDICION_SQL = value; } }
        public string CondicionValor { get { return GetStringHelper(row.CONDICION_VALOR); } set { row.CONDICION_VALOR = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public string PlantillaAsunto { get { return GetStringHelper(row.PLANTILLA_ASUNTO); } set { row.PLANTILLA_ASUNTO = value; } }
        public string Descripcion { get { return GetStringHelper(row.DESCRIPCION); } set { row.DESCRIPCION = value; } }
        public decimal? FlujoId { get { if (row.IsFLUJO_IDNull) return null; else return row.FLUJO_ID; } set { if (value.HasValue) row.FLUJO_ID = value.Value; else row.IsFLUJO_IDNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? LogCampoId { get { if (row.IsLOG_CAMPO_IDNull) return null; else return row.LOG_CAMPO_ID; } set { if (value.HasValue) row.LOG_CAMPO_ID = value.Value; else row.IsLOG_CAMPO_IDNull = true; } }
        public string PlantillaCorta { get { return GetStringHelper(row.PLANTILLA_CORTA); } set { row.PLANTILLA_CORTA = value; } }
        public string PlantillaLarga { get { return GetStringHelper(row.PLANTILLA_LARGA); } set { row.PLANTILLA_LARGA = value; } }
        public string TablaId { get { return GetStringHelper(row.TABLA_ID); } set { row.TABLA_ID = value; } }
        public decimal? TransicionId { get { if (row.IsTRANSICION_IDNull) return null; else return row.TRANSICION_ID; } set { if (value.HasValue) row.TRANSICION_ID = value.Value; else row.IsTRANSICION_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private FlujosService _flujo;
        public FlujosService Flujo
        {
            get
            {
                if (this._flujo == null)
                    this._flujo = new FlujosService(this.FlujoId.Value);
                return this._flujo;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.NOTIFICACIONESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new NOTIFICACIONESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(NOTIFICACIONESRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public NotificacionesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public NotificacionesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public NotificacionesService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private NotificacionesService(NOTIFICACIONESRow row)
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

            if (!this.ExisteEnDB)
            {
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                sesion.db.NOTIFICACIONESCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.NOTIFICACIONESCollection.Update(this.row);
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
            this._flujo = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override NotificacionesService[] Buscar(Filtro[] filtros)
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
                        case Modelo.FLUJO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.LOG_CAMPO_IDColumnName:
                        case Modelo.TRANSICION_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.ACCION_CREACIONColumnName:
                        case Modelo.ACCION_EDICIONColumnName:
                        case Modelo.CONDICION_SQLColumnName:
                        case Modelo.CONDICION_VALORColumnName:
                        case Modelo.DESCRIPCIONColumnName:
                        case Modelo.TABLA_IDColumnName:
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
            NOTIFICACIONESRow[] rows = sesion.db.NOTIFICACIONESCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            NotificacionesService[] n = new NotificacionesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                n[i] = new NotificacionesService(rows[i]);

            return n;
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

        #region Evaluar
        public bool EvaluarCondicionSQL(string query, SessionService sesion)
        {
            DataTable dt = sesion.db.EjecutarQuery(query);
            if (dt.Rows.Count <= 0 || dt.Rows[0][0].ToString() == Definiciones.SiNo.No)
                return false;
            else
                return true;
        }

        public static void EvaluarPorFlujo(TransicionesService transicion, CasosService caso, SessionService sesion)
        {
            List<Filtro> lFiltros = new List<Filtro>();
            lFiltros.Add(new Filtro { Columna = Modelo.FLUJO_IDColumnName, Valor = caso.FlujoId });
            if (transicion != null)
            {
                lFiltros.Add(new Filtro { Columna = Modelo.TRANSICION_IDColumnName, Valor = transicion.Id.Value });
                lFiltros.Add(new Filtro { Columna = Modelo.ACCION_EDICIONColumnName, Valor = Definiciones.SiNo.Si });
            }
            else
            {
                lFiltros.Add(new Filtro { Columna = Modelo.ACCION_CREACIONColumnName, Valor = Definiciones.SiNo.Si });
            }

            NotificacionesService[] notificaciones = NotificacionesService.Instancia.GetFiltrado<NotificacionesService>(lFiltros.ToArray());


            foreach (NotificacionesService n in notificaciones)
            {
                bool notificar = false;
                object cabecera = null;
                Hashtable datosCondiciones = new Hashtable();
                string archivoAdjunto = string.Empty;
                bool autoEnviarCopia = false;
                //Por cada flujo soportado debe agregarse el case con
                //la logica especifica para evaluar SQL y valores por campo
                switch ((int)caso.FlujoId)
                {
                    case Definiciones.FlujosIDs.PAGO_DE_PERSONAS:
                        #region Pago de Personas
                        if (n.CondicionSQL.Length > 0)
                        {
                            DataTable dtPagoPersona = PagosDePersonaService.GetPagosDePersonaInfoCompleta(PagosDePersonaService.CasoId_NombreCol + " = " + caso.Id.Value, string.Empty, sesion);
                            cabecera = dtPagoPersona;

                            datosCondiciones[NotificacionesSuscripcionesService.EstructuraHelper.Campo.FuncionarioId] = dtPagoPersona.Rows[0][PagosDePersonaService.FuncionarioCobradorId_NombreCol];
                            datosCondiciones[NotificacionesSuscripcionesService.EstructuraHelper.Campo.PersonaId] = dtPagoPersona.Rows[0][PagosDePersonaService.PersonaId_NombreCol];
                            datosCondiciones[NotificacionesSuscripcionesService.EstructuraHelper.Campo.UsuarioId] = sesion.Usuario_Id;

                            EstructuraHelper eh = new EstructuraHelper(n.CondicionSQL, n.PlantillaAsunto);
                            foreach (string campo in eh.Campos)
                            {
                                switch (campo)
                                {
                                    case EstructuraHelper.Campo.PK:
                                        eh.Set(campo, caso.Id.Value);
                                        break;
                                    case EstructuraHelper.Campo.NotificacionId:
                                        eh.Set(campo, n.Id.Value);
                                        break;
                                    case EstructuraHelper.Campo.NroComprobante:
                                        eh.Set(campo, dtPagoPersona.Rows[0][PagosDePersonaService.VistaCtacteReciboNroComprobante_NombreCol]);
                                        break;
                                    case EstructuraHelper.Campo.SucursalId:
                                        eh.Set(campo, caso.SucursalId);
                                        break;
                                    case EstructuraHelper.Campo.FuncionarioId:
                                        eh.Set(campo, caso.FuncionarioId.Value);
                                        break;
                                     case EstructuraHelper.Campo.PersonaId:
                                        eh.Set(campo, caso.PersonaId.Value);
                                        break;
                                    default:
                                        throw new Exception("Campo no implementado");
                                }
                            }

                            notificar = n.EvaluarCondicionSQL(eh.texto, sesion);
                        }
                        break;
                        #endregion Pago de Personas
                    case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                        #region Orden de pago
                        if (n.CondicionSQL.Length > 0)
                        {
                            DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoInfoCompleta(OrdenesPagoService.CasoId_NombreCol + " = " + caso.Id.Value, string.Empty, sesion);
                            cabecera = dtOrdenPago;

                            if (caso.FuncionarioId.HasValue) 
                                datosCondiciones[NotificacionesSuscripcionesService.EstructuraHelper.Campo.FuncionarioId] = caso.FuncionarioId.Value;
                            if (caso.PersonaId.HasValue)
                                datosCondiciones[NotificacionesSuscripcionesService.EstructuraHelper.Campo.PersonaId] = caso.PersonaId.Value;
                            if (caso.ProveedorId.HasValue)
                                datosCondiciones[NotificacionesSuscripcionesService.EstructuraHelper.Campo.ProveedorId] = caso.ProveedorId.Value;
                            if (caso.FuncionarioId.HasValue)
                                datosCondiciones[NotificacionesSuscripcionesService.EstructuraHelper.Campo.FuncionarioId] = caso.FuncionarioId.Value;
                            datosCondiciones[NotificacionesSuscripcionesService.EstructuraHelper.Campo.UsuarioId] = sesion.Usuario_Id;

                            EstructuraHelper eh = new EstructuraHelper(n.CondicionSQL, n.PlantillaAsunto);
                            foreach (string campo in eh.Campos)
                            {
                                switch (campo)
                                {
                                    case EstructuraHelper.Campo.PK:
                                        eh.Set(campo, caso.Id.Value);
                                        break;
                                    case EstructuraHelper.Campo.NotificacionId:
                                        eh.Set(campo, n.Id.Value);
                                        break;
                                    case EstructuraHelper.Campo.NroComprobante:
                                        eh.Set(campo, caso.NroComprobante);
                                        break;
                                    case EstructuraHelper.Campo.SucursalId:
                                        eh.Set(campo, caso.SucursalId);
                                        break;
                                    case EstructuraHelper.Campo.FuncionarioId:
                                        eh.Set(campo, caso.FuncionarioId.HasValue ? caso.FuncionarioId.Value : Definiciones.Error.Valor.EnteroPositivo);
                                        break;
                                    case EstructuraHelper.Campo.PersonaId:
                                        eh.Set(campo, caso.PersonaId.HasValue ? caso.PersonaId.Value : Definiciones.Error.Valor.EnteroPositivo);
                                        break;
                                    case EstructuraHelper.Campo.ProveedorId:
                                        eh.Set(campo, caso.ProveedorId.HasValue ? caso.ProveedorId.Value : Definiciones.Error.Valor.EnteroPositivo);
                                        break;
                                    default:
                                        throw new Exception("Campo no implementado");
                                }
                            }

                            notificar = n.EvaluarCondicionSQL(eh.texto, sesion);
                        }
                        break;
                        #endregion Orden de pago
                }

                if (notificar)
                    n.EnviarNotificaciones(caso, cabecera, transicion == null, datosCondiciones, archivoAdjunto, true, sesion);
            }
        }

        public static void EvaluarPorEntidad(string tabla_id, decimal registro_id, bool es_nuevo, string archivo_adjunto, SessionService sesion)
        {
            List<Filtro> lFiltros = new List<Filtro>();
            lFiltros.Add(new Filtro { Columna = Modelo.TABLA_IDColumnName, Valor = tabla_id });
            if (es_nuevo)
                lFiltros.Add(new Filtro { Columna = Modelo.ACCION_CREACIONColumnName, Valor = Definiciones.SiNo.Si });
            else
                lFiltros.Add(new Filtro { Columna = Modelo.ACCION_EDICIONColumnName, Valor = Definiciones.SiNo.Si });

            NotificacionesService[] notificaciones = NotificacionesService.Instancia.GetFiltrado<NotificacionesService>(lFiltros.ToArray());
            foreach (NotificacionesService n in notificaciones)
            {
                bool notificar = false;
                LogCamposService logCampo = new LogCamposService(n.LogCampoId.Value, sesion);
                object objeto = null;
                Hashtable datosCondiciones = new Hashtable();
                string archivoAdjunto = string.Empty;
                //Por cada entidad soportada debe agregarse el case con
                //el nombre de la tabla y la logica especifica para 
                //evaluar condicion SQL y condicion valor segun log_campo_id
                switch (logCampo.TablaId)
                {
                    case CuentaCorrienteFondosFijosService.Nombre_Tabla:
                        #region CuentaCorrienteFondosFijos
                        CuentaCorrienteFondosFijosService ctacteFondoFijo = new CuentaCorrienteFondosFijosService(registro_id, sesion);
                        objeto = ctacteFondoFijo;

                        datosCondiciones[NotificacionesSuscripcionesService.EstructuraHelper.Campo.FuncionarioId] = ctacteFondoFijo.FuncionarioId;
                        datosCondiciones[NotificacionesSuscripcionesService.EstructuraHelper.Campo.UsuarioId] = sesion.Usuario_Id;

                        if (n.CondicionSQL.Length > 0)
                        {
                            EstructuraHelper eh = new EstructuraHelper(n.CondicionSQL, n.PlantillaAsunto);
                            foreach (string campo in eh.Campos)
                            {
                                switch (campo)
                                {
                                    case EstructuraHelper.Campo.FuncionarioId:
                                        eh.Set(campo, ctacteFondoFijo.FuncionarioId);
                                        break;
                                    case EstructuraHelper.Campo.NotificacionId:
                                        eh.Set(campo, n.Id.Value);
                                        break;
                                    case EstructuraHelper.Campo.PK:
                                        eh.Set(campo, registro_id);
                                        break;
                                    default:
                                        throw new Exception("Campo no implementado");
                                }
                            }

                            notificar = n.EvaluarCondicionSQL(eh.texto, sesion);
                            if (notificar)
                                n.EnviarNotificaciones(logCampo, objeto, es_nuevo, datosCondiciones, archivoAdjunto, true, sesion);
                        }

                        break;
                        #endregion CuentaCorrienteFondosFijos
                   
                }
            }
        }
        #endregion Evaluar

        #region CompletarPlantilla
        private string CompletarPlantilla(string plantilla, string descripcion, CasosService caso, object cabecera, bool es_nuevo, SessionService sesion)
        {
            if (plantilla.Length <= 0) return string.Empty;

            EstructuraHelper eh = new EstructuraHelper(plantilla, descripcion);

            //Por cada flujo soportado debe agregarse el case con
            //la logica especifica para evaluar SQL y condiciones
            switch ((int)caso.FlujoId)
            {
                case Definiciones.FlujosIDs.PAGO_DE_PERSONAS:
                    #region Pago de Personas
                    DataTable dtCabecera = (DataTable)cabecera; ;

                    foreach (string campo in eh.Campos)
                    {
                        switch (campo)
                        {
                            case EstructuraHelper.Campo.Funcionario:
                                eh.Set(campo, caso.Funcionario.Nombre + " " + caso.Funcionario.Apellido);
                                break;
                            case EstructuraHelper.Campo.NroComprobante:
                                if (Interprete.EsNullODBNull(dtCabecera.Rows[0][PagosDePersonaService.CtacteReciboId_NombreCol]))
                                    eh.Set(campo, "(no existe un recibo por pago contado)");
                                else
                                    eh.Set(campo, dtCabecera.Rows[0][PagosDePersonaService.VistaCtacteReciboNroComprobante_NombreCol]);
                                break;
                            case EstructuraHelper.Campo.Persona:
                                eh.Set(campo, caso.Persona.NombreCompleto);
                                break;
                            case EstructuraHelper.Campo.PK:
                                eh.Set(campo, caso.Id.Value);
                                break;
                            case EstructuraHelper.Campo.Sucursal:
                                eh.Set(campo, caso.Sucursal.Nombre);
                                break;
                            case EstructuraHelper.Campo.Total:
                                decimal montoContado, montoCredito, montoFinanciero, montoRecargo;
                                CuentaCorrientePagosPersonaDocumentoService.GetMontoTotal((decimal)dtCabecera.Rows[0][PagosDePersonaService.Id_NombreCol], out montoContado, out montoCredito, out montoFinanciero, out montoRecargo, sesion);
                                MonedasService moneda = new MonedasService((decimal)dtCabecera.Rows[0][PagosDePersonaService.MonedaId_NombreCol], sesion);
                                string strTotal;

                                if (montoContado > 0 && (montoCredito + montoFinanciero + montoRecargo) > 0)
                                    strTotal = montoContado.ToString(moneda.CadenaDecimales) + " contado y " + (montoCredito + montoFinanciero + montoRecargo).ToString(moneda.CadenaDecimales) + " crédito";
                                else
                                    strTotal = (montoContado + montoCredito + montoFinanciero + montoRecargo).ToString(moneda.CadenaDecimales);
                                eh.Set(campo, strTotal);
                                break;
                            default:
                                throw new Exception("Campo no implementado");
                        }
                    }
                    break;
                    #endregion Pago de Personas
                case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                    #region Orden de pago
                    dtCabecera = (DataTable)cabecera;

                    foreach (string campo in eh.Campos)
                    {
                        switch (campo)
                        {
                            case EstructuraHelper.Campo.Funcionario:
                                eh.Set(campo, caso.Funcionario.Nombre + " " + caso.Funcionario.Apellido);
                                break;
                            case EstructuraHelper.Campo.NroComprobante:
                                eh.Set(campo, caso.NroComprobante);
                                break;
                            case EstructuraHelper.Campo.Persona:
                                eh.Set(campo, caso.Persona.NombreCompleto);
                                break;
                            case EstructuraHelper.Campo.Proveedor:
                                eh.Set(campo, caso.Proveedor.RazonSocial);
                                break;
                            case EstructuraHelper.Campo.PK:
                                eh.Set(campo, caso.Id.Value);
                                break;
                            case EstructuraHelper.Campo.Sucursal:
                                eh.Set(campo, caso.Sucursal.Nombre);
                                break;
                            case EstructuraHelper.Campo.MonedaSimbolo:
                                MonedasService monedaSimbolo = new MonedasService((decimal)dtCabecera.Rows[0][OrdenesPagoService.MonedaId_NombreCol], sesion);
                                eh.Set(campo, monedaSimbolo.Simbolo);
                                break;
                            case EstructuraHelper.Campo.Total:
                                MonedasService monedaTotal = new MonedasService((decimal)dtCabecera.Rows[0][OrdenesPagoService.MonedaId_NombreCol], sesion);
                                string strTotal;
                                strTotal = ((decimal)dtCabecera.Rows[0][OrdenesPagoService.MontoTotal_NombreCol]).ToString(monedaTotal.CadenaDecimales);
                                eh.Set(campo, strTotal);
                                break;
                            case EstructuraHelper.Campo.DocumentoNroComprobante:
                                string sqlDocumentoNroComprobante = 
                                             "select nvl(LISTAGG(" + CasosService.Modelo.NRO_COMPROBANTEColumnName + ", ', ') WITHIN GROUP(ORDER BY " + CasosService.Modelo.NRO_COMPROBANTEColumnName + "), '') " +
                                             " from (" +
                                             "      select distinct c." + CasosService.Modelo.NRO_COMPROBANTEColumnName +
                                             "        from " + CasosService.Nombre_Tabla + " c, " + OrdenesPagoDetalleService.Nombre_Tabla + " opd " +
                                             "       where opd." + OrdenesPagoDetalleService.OrdenPagoId_NombreCol + " = " + dtCabecera.Rows[0][OrdenesPagoService.Id_NombreCol] +
                                             "         and c." + CasosService.Id_NombreCol + " = opd." + OrdenesPagoDetalleService.CasoReferidoId_NombreCol +
                                             "       )";
                                DataTable dtDocumentoNroComprobante = sesion.db.EjecutarQuery(sqlDocumentoNroComprobante);
                                eh.Set(campo, (string)dtDocumentoNroComprobante.Rows[0][0]);
                                break;
                            case EstructuraHelper.Campo.ValoresResumen:
                                string sqlValoresResumen =
                                             " select nvl(LISTAGG(opvic." + OrdenesPagoValoresService.VistaCtacteValorNombre_NombreCol + " || ' ' || opvic." + OrdenesPagoValoresService.MontoOrigen_NombreCol + " || ' (' || opvic." + OrdenesPagoValoresService.VistaResumen_NombreCol + " || ')', ', ') WITHIN GROUP(ORDER BY opvic." + OrdenesPagoValoresService.VistaResumen_NombreCol + "), '') " +
                                             "   from " + OrdenesPagoValoresService.Nombre_Vista + " opvic " +
                                             "  where opvic." + OrdenesPagoValoresService.OrdenPagoId_NombreCol + " = " + dtCabecera.Rows[0][OrdenesPagoService.Id_NombreCol];
                                DataTable dtValoresResumen = sesion.db.EjecutarQuery(sqlValoresResumen);
                                eh.Set(campo, (string)dtValoresResumen.Rows[0][0]);
                                break;
                            default:
                                throw new Exception("Campo no implementado");
                        }
                    }
                    break;
                    #endregion Orden de pago
            }

            return eh.texto;
        }

        private NotificacionesService CompletarPlantilla(bool corta, NotificacionesService n, LogCamposService log_campo, object objeto, bool es_nuevo, Hashtable datos_condiciones, SessionService sesion)
        {
            EstructuraHelper eh;

            if (corta)
                eh = new EstructuraHelper(n.PlantillaCorta, n.PlantillaAsunto);
            else
                eh = new EstructuraHelper(n.PlantillaLarga, n.PlantillaAsunto);

           

            n.PlantillaAsunto = eh.asunto;
            if (corta)
                n.PlantillaCorta = eh.texto;
            else
                n.PlantillaLarga = eh.texto;
            return n;
        }
        #endregion CompletarPlantilla

        #region EnviarNotificaciones
        public void EnviarNotificaciones(LogCamposService log_campo, object objeto, bool es_nuevo, Hashtable datos_condiciones, string archivo_adjunto, bool usar_smtp_cliente, SessionService sesion)
        {
            NotificacionesService nAux = new NotificacionesService(this.Id.Value, sesion);

            nAux = this.CompletarPlantilla(false, nAux, log_campo, objeto, es_nuevo, datos_condiciones, sesion);
            nAux = this.CompletarPlantilla(true, nAux, log_campo, objeto, es_nuevo, datos_condiciones, sesion);

            NotificacionesSuscripcionesService.Enviar(nAux, datos_condiciones, sesion, archivo_adjunto, usar_smtp_cliente);
        }

        public void EnviarNotificaciones(CasosService caso, object cabecera, bool es_nuevo, Hashtable datos_condiciones, string archivo_adjunto, bool usar_smtp_cliente, SessionService sesion)
        {
            this.PlantillaLarga = this.CompletarPlantilla(this.PlantillaLarga, this.PlantillaAsunto, caso, cabecera, es_nuevo, sesion);
            this.PlantillaCorta = this.CompletarPlantilla(this.PlantillaCorta, this.PlantillaAsunto, caso, cabecera, es_nuevo, sesion);

            NotificacionesSuscripcionesService.Enviar(this, datos_condiciones, sesion, archivo_adjunto, usar_smtp_cliente);
        }
        #endregion EnviarNotificaciones

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "NOTIFICACIONES"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "NOTIFICACIONES_SQC"; }
        }
        #endregion Accessors
    }
}
