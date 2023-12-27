using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.General
{
    public class TiposArticuloFinancieroRangoService : ClaseCBA<TiposArticuloFinancieroRangoService>
    {
        #region Propiedades
        protected TIPOS_ARTICULO_FINANC_RANGORow row;
        protected TIPOS_ARTICULO_FINANC_RANGORow rowSinModificar;
        public class Modelo : TIPOS_ARTICULO_FINANC_RANGOCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal ArticuloId { get { return row.ARTICULO_ID; } set { row.ARTICULO_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaTopeId { get { return row.MONEDA_TOPE_ID; } set { row.MONEDA_TOPE_ID = value; } }
        public decimal MontoTope { get { return row.MONTO_TOPE; } set { row.MONTO_TOPE = value; } }
        public string Nombre { get { return GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        public decimal PorcentajeTope { get { return row.PORCENTAJE_TOPE; } set { row.PORCENTAJE_TOPE = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private ArticulosService _articulo;
        public ArticulosService Articulo
        {
            get
            {
                if (this._articulo == null)
                    this._articulo = new ArticulosService(this.ArticuloId);
                return this._articulo;
            }
        }

        private MonedasService _moneda_tope;
        public MonedasService MonedaTope
        {
            get
            {
                if (this._moneda_tope == null)
                    this._moneda_tope = new MonedasService(this.MonedaTopeId);
                return this._moneda_tope;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.TIPOS_ARTICULO_FINANC_RANGOCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new TIPOS_ARTICULO_FINANC_RANGORow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(TIPOS_ARTICULO_FINANC_RANGORow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public TiposArticuloFinancieroRangoService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public TiposArticuloFinancieroRangoService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public TiposArticuloFinancieroRangoService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private TiposArticuloFinancieroRangoService(TIPOS_ARTICULO_FINANC_RANGORow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            try
            {
                Validar();
                throw new Exception("No se debería modificar."); 
            }
            catch
            {
                throw;
            }
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
            this._articulo = null;
            this._moneda_tope = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override TiposArticuloFinancieroRangoService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();

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
                        case Modelo.ARTICULO_IDColumnName:
                        case Modelo.IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.NOMBREColumnName:
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
            TIPOS_ARTICULO_FINANC_RANGORow[] rows = sesion.db.TIPOS_ARTICULO_FINANC_RANGOCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            TiposArticuloFinancieroRangoService[] tafr = new TiposArticuloFinancieroRangoService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                tafr[i] = new TiposArticuloFinancieroRangoService(rows[i]);
            return tafr;
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

        #region GetDataTable
        public static DataTable GetDataTable(bool deducir_porcentajes)
        {
            using (SessionService sesion = new SessionService())
            {
                string[] noIncluir;

                if (!deducir_porcentajes)
                {
                    noIncluir = new string[] {
                        ((int)Definiciones.TiposArticuloFinancieroRango.MontoPorCuotaBase).ToString(),
                    };
                }
                else
                {
                    noIncluir = new string[] {
                        Definiciones.Error.Valor.IntPositivo.ToString(),
                    };
                }

                return sesion.db.TIPOS_ARTICULO_FINANC_RANGOCollection.GetAsDataTable(Modelo.IDColumnName + " not in (" + string.Join(",", noIncluir) + ")", Modelo.NOMBREColumnName);
            }
        }
        #endregion GetDataTable
    }
}
