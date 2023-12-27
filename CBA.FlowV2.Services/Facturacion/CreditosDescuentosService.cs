#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.TextosPredefinidos;
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class CreditosDescuentosService : ClaseCBA<CreditosDescuentosService>
    {
        #region Propiedades
        protected CREDITOS_DESCUENTOSRow row;
        protected CREDITOS_DESCUENTOSRow rowSinModificar;
        public class Modelo : CREDITOS_DESCUENTOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal? CasoCreadoId { get { if (row.IsCASO_CREADO_IDNull) return null; else return row.CASO_CREADO_ID; } set { if (value.HasValue) row.CASO_CREADO_ID = value.Value; else row.IsCASO_CREADO_IDNull = true; } }
        public decimal Cotizacion { get { return row.COTIZACION; } set { row.COTIZACION = value; } }
        public decimal CreditoId { get { return row.CREDITO_ID; } set { row.CREDITO_ID = value; } }
        public decimal? CtactePersonaId { get { if (row.IsCTACTE_PERSONA_IDNull) return null; else return row.CTACTE_PERSONA_ID; } set { if (value.HasValue) row.CTACTE_PERSONA_ID = value.Value; else row.IsCTACTE_PERSONA_IDNull = true; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal Monto { get { return row.MONTO; } set { row.MONTO = value; } }
        public string Observacion { get { return GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal PersonaId { get { return row.PERSONA_ID; } set { row.PERSONA_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CasosService _caso_creado;
        public CasosService CasoCreado
        {
            get
            {
                if (this._caso_creado == null)
                {
                    if (this.sesion == null)
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._caso_creado = new CasosService(this.CasoCreado.Id.Value, sesion);
                        }
                    }
                    else
                    {
                        this._caso_creado = new CasosService(this.CasoCreado.Id.Value, this.sesion);
                    }
                }
                return this._caso_creado;
            }
        }

        private CreditosService _credito;
        public CreditosService Credito
        {
            get
            {
                if (this._credito == null)
                {
                    if (this.sesion == null)
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._credito = new CreditosService(this.CreditoId, sesion);
                        }
                    }
                    else
                    {
                        this._credito = new CreditosService(this.CreditoId, this.sesion);
                    }
                }
                return this._credito;
            }
        }

        private CuentaCorrientePersonasService _ctacte_persona;
        public CuentaCorrientePersonasService CtactePersona
        {
            get
            {
                if (this._ctacte_persona == null)
                {
                    if (this.sesion == null)
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._ctacte_persona = new CuentaCorrientePersonasService(this.CtactePersonaId.Value, sesion);
                        }
                    }
                    else
                    {
                        this._ctacte_persona = new CuentaCorrientePersonasService(this.CtactePersonaId.Value, this.sesion);
                    }
                }
                return this._ctacte_persona;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                {
                    if(this.sesion == null)
                    {
                        using(SessionService sesion = new SessionService())
                        {
                            this._moneda= new MonedasService(this.MonedaId, sesion);
                        }
                    }
                    else
                    {
                        this._moneda= new MonedasService(this.MonedaId, this.sesion);
                    }
                }
                return this._moneda;
            }
        }

        private PersonasService _persona;
        public PersonasService Persona
        {
            get
            {
                if (this._persona == null)
                {
                    if(this.sesion == null)
                    {
                        using(SessionService sesion = new SessionService())
                        {
                            this._persona= new PersonasService(this.PersonaId, sesion);
                        }
                    }
                    else
                    {
                        this._persona= new PersonasService(this.PersonaId, this.sesion);
                    }
                }
                return this._persona;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CREDITOS_DESCUENTOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CREDITOS_DESCUENTOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CREDITOS_DESCUENTOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CreditosDescuentosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CreditosDescuentosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CreditosDescuentosService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private CreditosDescuentosService(CREDITOS_DESCUENTOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            if (this.CtactePersonaId.HasValue && 
                this.CtactePersona.Bloqueado == Definiciones.SiNo.Si &&
                (this.rowSinModificar.IsCTACTE_PERSONA_IDNull || this.rowSinModificar.CTACTE_PERSONA_ID != this.CtactePersonaId.Value))
            {
                if (this.CtactePersona.CasoId.HasValue && this.CtactePersona.CuotaNumero.HasValue)
                    excepciones.Agregar("El documento caso " + this.CtactePersona.CasoId.Value + " cuota " + this.CtactePersona.CuotaNumero.Value + "/" + this.CtactePersona.CuotaTotal.Value + " se encuentra bloqueado.");
                else
                    excepciones.Agregar("El documento se encuentra bloqueado.");
            }

            //Si el campo que cambia no es esencial
            if (this.Estado != this.rowSinModificar.ESTADO ||
                this.Monto != this.rowSinModificar.MONTO ||
                this.MonedaId != this.rowSinModificar.MONEDA_ID ||
                this.Cotizacion != this.rowSinModificar.COTIZACION ||
                this.CtactePersonaId.HasValue == this.rowSinModificar.IsCTACTE_PERSONA_IDNull ||
                (this.CtactePersonaId.HasValue && this.CtactePersonaId.Value != this.rowSinModificar.CTACTE_PERSONA_ID))
            {
                this.Credito.IniciarUsingSesion(sesion);
                switch (this.Credito.Caso.EstadoId)
                {
                    case Definiciones.EstadosFlujos.Borrador:
                    case Definiciones.EstadosFlujos.Pendiente:
                        break;
                    default:
                        excepciones.Agregar("No se pueden modificar los descuentos cuando el caso está en " + this.Credito.Caso.EstadoId + ".");
                        break;
                }
                this.Credito.FinalizarUsingSesion();
            }

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._caso_creado = null;
            this._credito = null;
            this._ctacte_persona = null;
            this._moneda = null;
            this._persona = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();

            if (!this.ExisteEnDB)
            {
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.Estado = Definiciones.Estado.Activo;
                sesion.db.CREDITOS_DESCUENTOSCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.CREDITOS_DESCUENTOSCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), this.rowSinModificar.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();
            return this.Id.Value;
        }
        #endregion Guardar

        #region Borrar
        public void Borrar()
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Borrar(sesion);
                this.FinalizarUsingSesion();
            }
        }

        public void Borrar(SessionService sesion)
        {
            try
            {
                this.Estado = Definiciones.Estado.Inactivo;
                this.Guardar();
            }
            catch
            {
                throw;
            }
        }
        #endregion Borrar

        #region Buscar
        protected override CreditosDescuentosService[] Buscar(Filtro[] filtros)
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
                        case Modelo.CREDITO_IDColumnName:
                        case Modelo.CTACTE_PERSONA_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.MONEDA_IDColumnName:
                        case Modelo.MONTOColumnName:
                        case Modelo.PERSONA_IDColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            break;
                        case Modelo.OBSERVACIONColumnName:
                            if(f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            CREDITOS_DESCUENTOSRow[] rows = sesion.db.CREDITOS_DESCUENTOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            CreditosDescuentosService[] cd = new CreditosDescuentosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                cd[i] = new CreditosDescuentosService(rows[i]);

            return cd;
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
        public static string Nombre_Tabla = "CREDITOS_DESCUENTOS";
        public static string Nombre_Secuencia = "CREDITOS_DESCUENTOS_SQC";
        #endregion Accessors
    }
}
