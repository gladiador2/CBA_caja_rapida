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
using CBA.FlowV2.Services.Anticipo;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class PlanillaCobranzaValoresService : ClaseCBA<PlanillaCobranzaValoresService>
    {
        #region Propiedades
        protected PLANILLA_COBRANZA_VALORESRow row;
        protected PLANILLA_COBRANZA_VALORESRow rowSinModificar;
        public class Modelo : PLANILLA_COBRANZA_VALORESCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal CasoId { get { return row.CASO_ID; } set { row.CASO_ID = value; } }
        public decimal Cotizacion { get { return row.COTIZACION; } set { row.COTIZACION = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal MontoUtilizar { get { return row.MONTO_UTILIZAR; } set { row.MONTO_UTILIZAR = value; } }
        public decimal PlanillaCobranzaId { get { return row.PLANILLA_COBRANZA_ID; } set { row.PLANILLA_COBRANZA_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CasosService _caso;
        public CasosService Caso
        {
            get
            {
                if (this._caso == null)
                {
                    if (this.sesion == null)
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._caso = new CasosService(this.CasoId, sesion);
                        }
                    }
                    else
                    {
                        this._caso = new CasosService(this.CasoId, this.sesion);
                    }
                }
                return this._caso;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                {
                    if (this.sesion == null)
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._moneda = new MonedasService(this.MonedaId, sesion);
                        }
                    }
                    else
                    {
                        this._moneda = new MonedasService(this.MonedaId, this.sesion);
                    }
                }
                return this._moneda;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.PLANILLA_COBRANZA_VALORESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new PLANILLA_COBRANZA_VALORESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(PLANILLA_COBRANZA_VALORESRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public PlanillaCobranzaValoresService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public PlanillaCobranzaValoresService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public PlanillaCobranzaValoresService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private PlanillaCobranzaValoresService(PLANILLA_COBRANZA_VALORESRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            DataTable dtCabecera = PlanillaCobranzaService.GetPlanillaCobranza(this.PlanillaCobranzaId, sesion);
            
            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionCtacteIndependiente, sesion) == Definiciones.SiNo.Si)
            {
                var sucursal = new SucursalesService((decimal)dtCabecera.Rows[0][PlanillaCobranzaService.SucursalId_NombreCol], sesion);
                if (this.Caso.Sucursal.RegionId != sucursal.RegionId)
                    throw new Exception("El documento proviene de una región distinta al caso.");
            }

            switch ((int)this.Caso.FlujoId)
            {
                case Definiciones.FlujosIDs.ANTICIPO_PERSONA:
                    if (this.Caso.EstadoId != Definiciones.EstadosFlujos.Aprobado)
                        excepciones.Agregar("El Anticipo debe estar en estado Aprobado.");
                    break;
                case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:
                    if (this.Caso.EstadoId != Definiciones.EstadosFlujos.Aprobado)
                        excepciones.Agregar("La Nota de Crédito debe estar en estado Aprobado.");
                    break;
                default:
                    throw new Exception("No puede utilizar un caso del flujo " + this.Caso.Flujo.DescripcionImpresion + ".");
            }
            
            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._caso = null;
            this._moneda = null;
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
                sesion.db.PLANILLA_COBRANZA_VALORESCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.PLANILLA_COBRANZA_VALORESCollection.Update(this.row);
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
        protected override PlanillaCobranzaValoresService[] Buscar(Filtro[] filtros)
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
                        case Modelo.CASO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.MONTO_UTILIZARColumnName:
                        case Modelo.PLANILLA_COBRANZA_IDColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            PLANILLA_COBRANZA_VALORESRow[] rows = sesion.db.PLANILLA_COBRANZA_VALORESCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            PlanillaCobranzaValoresService[] pcv = new PlanillaCobranzaValoresService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                pcv[i] = new PlanillaCobranzaValoresService(rows[i]);

            return pcv;
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
        public static string Nombre_Tabla = "PLANILLA_COBRANZA_VALORES";
        public static string Nombre_Secuencia = "PLANILLA_COBRANZA_VALORES_SQC";
        #endregion Accessors
    }
}
