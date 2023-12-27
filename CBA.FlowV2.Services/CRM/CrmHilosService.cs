#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;

using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.TextosPredefinidos;
using CBA.FlowV2.Services.Casos;
#endregion Using

namespace CBA.FlowV2.Services.CRM
{
    public class CrmHilosService : ClaseCBA<CrmHilosService>
    {
        #region FiltrosExtension
        public static class FiltroExtension
        {
            public const string EntradaSinLeer = "ENTRADA_SIN_LEER";
            public const string EntradaEtiquetas = "ENTRADA_ETIQUETAS";
            public const string EntradaRelaciones = "ENTRADA_RELACIONES";
        }
        #endregion FiltrosExtension

        #region Propiedades
        protected CRM_HILOSRow row;
        protected CRM_HILOSRow rowSinModificar;
        public class Modelo : CRM_HILOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string Asunto { get { return ClaseCBABase.GetStringHelper(row.ASUNTO); } set { row.ASUNTO = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public DateTime FechaCreacion { get { return row.FECHA_CREACION; } set { row.FECHA_CREACION = value; } }
        public DateTime FechaUltimaModificacion { get { return row.FECHA_ULTIMA_MODIFICACION; } set { row.FECHA_ULTIMA_MODIFICACION = value; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal? TextoPredefinidoId { get { if (row.IsTEXTO_PREDEFINIDO_IDNull) return null; else return row.TEXTO_PREDEFINIDO_ID; } set { if (value.HasValue) row.TEXTO_PREDEFINIDO_ID = value.Value; else row.IsTEXTO_PREDEFINIDO_IDNull = true; } }
        public decimal UsuarioCreacionId { get { return row.USUARIO_CREACION_ID; } set { row.USUARIO_CREACION_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
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

        private TextosPredefinidosService _texto_predefinido;
        public TextosPredefinidosService TextoPredefinido
        {
            get
            {
                if (this._texto_predefinido == null)
                {
                    if (this.sesion != null)
                        this._texto_predefinido = new TextosPredefinidosService(this.TextoPredefinidoId.Value, this.sesion);
                    else
                        this._texto_predefinido = new TextosPredefinidosService(this.TextoPredefinidoId.Value);
                }
                return this._texto_predefinido;
            }
        }
        #endregion Propiedades Extendidas

        #region Propiedades OneToMany
        private CrmHilosEntradasService[] _crm_hilos_entradas;
        public CrmHilosEntradasService[] CrmHilosEntradas
        {
            get
            {
                if (this._crm_hilos_entradas == null)
                {
                    this._crm_hilos_entradas = this.GetFiltrado<CrmHilosEntradasService>(new Filtro[] 
                    {
                        new Filtro { Columna = CrmHilosEntradasService.Modelo.CRM_HILO_IDColumnName, Valor = this.Id.Value },
                        new Filtro { Columna = CrmHilosEntradasService.Modelo.FECHAColumnName, OrderBy = true },
                    });
                }
                return this._crm_hilos_entradas;
            }
        }
        #endregion Propiedades OneToMany

        #region Permisos
        public Permiso Permisos = new Permiso();
        public class Permiso
        {
            private bool? _crmHilosBorrar;
            public bool CrmHilosBorrar { get { if (this._crmHilosBorrar == null) this._crmHilosBorrar = RolesService.Tiene("CRM HILOS BORRAR"); return this._crmHilosBorrar.Value; } }
        }
        #endregion Permisos

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CRM_HILOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CRM_HILOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CRM_HILOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CrmHilosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CrmHilosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CrmHilosService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        public CrmHilosService(CRM_HILOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();

            if (!this.ExisteEnDB)
            {
                this.row.ID = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.row.ESTADO = Definiciones.Estado.Activo;
                this.row.FECHA_CREACION = DateTime.Now;
                this.row.USUARIO_CREACION_ID = sesion.Usuario.ID;
                sesion.db.CRM_HILOSCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion); 
            }
            else
            {
                sesion.db.CRM_HILOSCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), this.rowSinModificar.ToString(), sesion);
            }

            this.FechaUltimaModificacion = DateTime.Now;

            this.rowSinModificar = this.row.Clonar();

            return this.row.ID;
        }
        #endregion Guardar

        #region Borrar
        public void Borrar()
        {
            if (this.sesion == null)
            {
                using (SessionService sesion = new SessionService())
                {
                    try
                    {
                        sesion.BeginTransaction();
                        this.IniciarUsingSesion(sesion);
                        Borrar(sesion);
                        this.FinalizarUsingSesion();
                        sesion.CommitTransaction();
                    }
                    catch
                    {
                        sesion.RollbackTransaction();
                        throw;
                    }
                }
            }
            else
            {
                Borrar(this.sesion);
            }
        }

        public void Borrar(SessionService sesion)
        {
            if (!this.Permisos.CrmHilosBorrar)
                throw new Exception("No tiene permisos para borrar hilos.");

            foreach (var e in this.CrmHilosEntradas)
            {
                e.IniciarUsingSesion(sesion);
                e.Borrar();
                e.FinalizarUsingSesion();
            }

            this.Estado = Definiciones.Estado.Inactivo;
            this.Guardar();
        }
        #endregion Borrar

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
            this._usuario_creacion = null;
            this._texto_predefinido = null;

            this._crm_hilos_entradas = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override CrmHilosService[] Buscar(Filtro[] filtros)
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
                        case Modelo.ASUNTOColumnName:
                        case Modelo.OBSERVACIONColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case Modelo.IDColumnName:
                        case Modelo.TEXTO_PREDEFINIDO_IDColumnName:
                        case Modelo.USUARIO_CREACION_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.FECHA_CREACIONColumnName:
                        case Modelo.FECHA_ULTIMA_MODIFICACIONColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        case FiltroExtension.EntradaSinLeer:
                            using(SessionService sesionInterna = new SessionService())
                            {
                                if (!(bool)f.Valor)
                                    sb.Append(" not ");
                                sb.Append(" exists(select che." + CrmHilosEntradasService.Modelo.IDColumnName +
                                         "           from " + CrmHilosEntradasService.Nombre_Tabla + " che" +
                                         "          where che." + CrmHilosEntradasService.Modelo.CRM_HILO_IDColumnName + " = " + Nombre_Tabla + "." + Modelo.IDColumnName +
                                         "            and che." + CrmHilosEntradasService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'" +
                                         "          minus " +
                                         "          select che." + CrmHilosEntradasService.Modelo.IDColumnName +
                                         "           from " + CrmHilosEntradasService.Nombre_Tabla + " che, " + CrmHilosEntradasUsuariosService.Nombre_Tabla + " cheu" +
                                         "          where che." + CrmHilosEntradasService.Modelo.CRM_HILO_IDColumnName + " = " + Nombre_Tabla + "." + Modelo.IDColumnName +
                                         "            and che." + CrmHilosEntradasService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'" +
                                         "            and cheu." + CrmHilosEntradasUsuariosService.Modelo.CRM_HILOS_ENTRADA_IDColumnName + " = che." + CrmHilosEntradasService.Modelo.IDColumnName +
                                         "            and cheu." + CrmHilosEntradasUsuariosService.Modelo.USUARIO_IDColumnName + " = " + sesionInterna.Usuario.ID +
                                         "            and cheu." + CrmHilosEntradasUsuariosService.Modelo.FECHA_LECTURAColumnName + " is not null " +
                                         "  ) ");
                            }
                            break;
                        case FiltroExtension.EntradaEtiquetas:
                            sb.Append(" exists(select che." + CrmHilosEntradasService.Modelo.IDColumnName +
                                     "           from " + CrmHilosEntradasService.Nombre_Tabla + " che, " + CasosEtiquetasService.Nombre_Tabla + " ce" +
                                     "          where che." + CrmHilosEntradasService.Modelo.CRM_HILO_IDColumnName + " = " + Nombre_Tabla + "." + Modelo.IDColumnName +
                                     "            and che." + CrmHilosEntradasService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'" +
                                     "            and ce." + CasosEtiquetasService.TablaId_NombreCol + " = '" + CrmHilosEntradasService.Nombre_Tabla + "'" +
                                     "            and ce." + CasosEtiquetasService.RegistroId_NombreCol + " = che." + CrmHilosEntradasService.Modelo.IDColumnName +
                                     "            and ce." + CasosEtiquetasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'");
                            if(f.Exacto)
                            {
                                sb.Append(" and ce." + CasosEtiquetasService.TextoPredefinidoId_NombreCol + " = " + f.Valor);
                            }
                            else
                            {
                                var lId = new List<string>();
                                foreach (var o in (object[])f.Valor)
                                    lId.Add(o.ToString());

                                sb.Append(" and ce." + CasosEtiquetasService.TextoPredefinidoId_NombreCol + " in (" + string.Join(",", lId.ToArray()) + ")");
                            }
                            sb.Append(")");
                            break;
                        case FiltroExtension.EntradaRelaciones:
                            sb.Append(" exists(select che." + CrmHilosEntradasService.Modelo.IDColumnName +
                                     "           from " + CrmHilosEntradasService.Nombre_Tabla + " che, " + CrmHilosEntradasRelacionesService.Nombre_Tabla + " cer" +
                                     "          where che." + CrmHilosEntradasService.Modelo.CRM_HILO_IDColumnName + " = " + Nombre_Tabla + "." + Modelo.IDColumnName +
                                     "            and che." + CrmHilosEntradasService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'" +
                                     "            and cer." + CrmHilosEntradasRelacionesService.Modelo.CRM_HILOS_ENTRADA_IDColumnName + " = che." + CrmHilosEntradasService.Modelo.IDColumnName +
                                     "            and cer." + CrmHilosEntradasRelacionesService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'");

                            var lValores = new List<string>();
                            foreach (KeyValuePair<int, string> item in (Dictionary<int, string>)f.Valor)
                                lValores.Add("(" + item.Key + ",'" + item.Value + "')");
                            sb.Append(" and (cer." + CrmHilosEntradasRelacionesService.Modelo.TIPO_DE_DATO_IDColumnName + ", coalesce(cer." + CrmHilosEntradasRelacionesService.Modelo.VALOR_TEXTOColumnName + ", to_char(cer." + CrmHilosEntradasRelacionesService.Modelo.VALOR_NUMEROColumnName + "), to_char(cer." + CrmHilosEntradasRelacionesService.Modelo.VALOR_FECHAColumnName + ", 'dd/mm/yyyy'),''))");
                            sb.Append(" in (" + string.Join(",", lValores.ToArray()) + ")");
                            sb.Append(")");

                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.FECHA_CREACIONColumnName + " desc");
            var rows = sesion.db.CRM_HILOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            CrmHilosService[] h = new CrmHilosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                h[i] = new CrmHilosService(rows[i]);

            return h;
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

        #region Accessors
        public static string Nombre_Tabla = "CRM_HILOS";
        public static string Nombre_Secuencia = "CRM_HILOS_SQC";
        #endregion Accessors
    }
}
