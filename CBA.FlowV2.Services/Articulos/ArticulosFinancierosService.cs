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
using System.Text;
using CBA.FlowV2.Services.Facturacion;
#endregion Using

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosFinancierosService : ClaseCBA<ArticulosFinancierosService>
    {
        #region FiltrosExtension
        public static class FiltroExtension
        {
            public const string Articulo = "Articulo";
        }
        #endregion FiltrosExtension

        #region Propiedades
        protected ARTICULOS_FINANCIEROSRow row;
        protected ARTICULOS_FINANCIEROSRow rowSinModificar;
        public class Modelo : ARTICULOS_FINANCIEROSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string AnhoComercial { get { return GetStringHelper(row.ANHO_COMERCIAL); } set { row.ANHO_COMERCIAL = value; } }
        public decimal ArticuloId { get { return row.ARTICULO_ID; } set { row.ARTICULO_ID = value; } }
        public string AumentarCapitalPorDescuent { get { return GetStringHelper(row.AUMENTAR_CAPITAL_POR_DESCUENT); } set { row.AUMENTAR_CAPITAL_POR_DESCUENT = value; } }
        public decimal? ArticuloRefinanciacionId { get { if (row.IsARTICULO_REFINANCIACION_IDNull) return null; else return row.ARTICULO_REFINANCIACION_ID; } set { if (value.HasValue) row.ARTICULO_REFINANCIACION_ID = value.Value; else row.IsARTICULO_REFINANCIACION_IDNull = true; } }
        public string BonificacionIncluyeImpuesto { get { return GetStringHelper(row.BONIFICACION_INCLUYE_IMPUESTO); } set { row.BONIFICACION_INCLUYE_IMPUESTO = value; } }
        public decimal? CanalVentaId { get { if (row.IsCANAL_VENTA_IDNull) return null; else return row.CANAL_VENTA_ID; } set { if (value.HasValue) row.CANAL_VENTA_ID = value.Value; else row.IsCANAL_VENTA_IDNull = true; } }
        public decimal CantidadCuotas { get { return row.CANTIDAD_CUOTAS; } set { row.CANTIDAD_CUOTAS = value; } }
        public string ConceptoIncluyeImpuesto { get { return GetStringHelper(row.CONCEPTO_INCLUYE_IMPUESTO); } set { row.CONCEPTO_INCLUYE_IMPUESTO = value; } }
        public string ConRecurso { get { return GetStringHelper(row.CON_RECURSO); } set { row.CON_RECURSO = value; } }
        public decimal? CuotaMontoBase { get { if (row.IsCUOTA_MONTO_BASENull) return null; else return row.CUOTA_MONTO_BASE; } set { if (value.HasValue) row.CUOTA_MONTO_BASE = value.Value; else row.IsCUOTA_MONTO_BASENull = true; } }
        public string DesembolsarParaCliente { get { return GetStringHelper(row.DESEMBOLSAR_PARA_CLIENTE); } set { row.DESEMBOLSAR_PARA_CLIENTE = value; } }
        public string Estado { get { return GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public string FacturarBonificacionEnPagos { get { return GetStringHelper(row.FACTURAR_BONIFICACION_EN_PAGOS); } set { row.FACTURAR_BONIFICACION_EN_PAGOS = value; } }
        public decimal FacturarCapital { get { return row.FACTURAR_CAPITAL; } set { row.FACTURAR_CAPITAL = value; } }
        public string FacturarConceptosEnPagos { get { return GetStringHelper(row.FACTURAR_CONCEPTOS_EN_PAGOS); } set { row.FACTURAR_CONCEPTOS_EN_PAGOS = value; } }
        public decimal FacturarIntereses { get { return row.FACTURAR_INTERESES; } set { row.FACTURAR_INTERESES = value; } }
        public DateTime? FechaDesde { get { if (row.IsFECHA_DESDENull) return null; else return row.FECHA_DESDE; } set { if (value.HasValue) row.FECHA_DESDE = value.Value; else row.IsFECHA_DESDENull = true; } }
        public DateTime? FechaHasta { get { if (row.IsFECHA_HASTANull) return null; else return row.FECHA_HASTA; } set { if (value.HasValue) row.FECHA_HASTA = value.Value; else row.IsFECHA_HASTANull = true; } }
        public decimal Frecuencia { get { return row.FRECUENCIA; } set { row.FRECUENCIA = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string InteresIncluyeImpuesto { get { return GetStringHelper(row.INTERES_INCLUYE_IMPUESTO); } set { row.INTERES_INCLUYE_IMPUESTO = value; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal MontoRedondeo { get { return row.MONTO_REDONDEO; } set { row.MONTO_REDONDEO = value; } }
        public decimal? PersonaId { get { if (row.IsPERSONA_IDNull) return null; else return row.PERSONA_ID; } set { if (value.HasValue) row.PERSONA_ID = value.Value; else row.IsPERSONA_IDNull = true; } }
        public decimal PoliticaBusquedaRangoDias { get { return row.POLITICA_BUSQUEDA_RANGO_DIAS; } set { row.POLITICA_BUSQUEDA_RANGO_DIAS = value; } }
        public FechaUtil.VencimientoDinamico ReglasPrimerVencimiento { get { if (GetStringHelper(row.REGLAS_PRIMER_VENCIMIENTO).Length <= 0) return null; else return JsonUtil.Deserializar<FechaUtil.VencimientoDinamico>(row.REGLAS_PRIMER_VENCIMIENTO); } set { if (value != null) row.REGLAS_PRIMER_VENCIMIENTO = JsonUtil.Serializar(value); else row.REGLAS_PRIMER_VENCIMIENTO = string.Empty; } }
        public decimal TipoArticuloFinancieroId { get { return row.TIPO_ARTICULO_FINANCIERO_ID; } set { row.TIPO_ARTICULO_FINANCIERO_ID = value; } }
        public decimal TipoCreditoId { get { return row.TIPO_CREDITO_ID; } set { row.TIPO_CREDITO_ID = value; } }
        public string TipoFrecuencia { get { return GetStringHelper(row.TIPO_FRECUENCIA); } set { row.TIPO_FRECUENCIA = value; } }
        public string TipoInteresAnual { get { return row.TIPO_INTERES_ANUAL; } set { row.TIPO_INTERES_ANUAL = value; } }
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

        private ArticulosService _articulo_refinanciacion;
        public ArticulosService ArticuloRefinanciacion
        {
            get
            {
                if (this._articulo_refinanciacion == null)
                    this._articulo_refinanciacion = new ArticulosService(this.ArticuloRefinanciacionId.Value);
                return this._articulo_refinanciacion;
            }
        }

        private PersonasService _persona;
        public PersonasService Persona
        {
            get
            {
                if (this._persona == null)
                {
                    if (this.sesion != null)
                        this._persona = new PersonasService(this.PersonaId.Value, this.sesion);
                    else
                        this._persona = new PersonasService(this.PersonaId.Value);
                }
                return this._persona;
            }
        }

        private CanalesVentaService _canal_venta;
        public CanalesVentaService CanalVenta
        {
            get
            {
                if (this._canal_venta == null)
                {
                    if (this.sesion != null)
                        this._canal_venta = new CanalesVentaService(this.CanalVentaId.Value, this.sesion);
                    else
                        this._canal_venta = new CanalesVentaService(this.CanalVentaId.Value);
                }
                return this._canal_venta;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                {
                    if (this.sesion != null)
                        this._moneda = new MonedasService(this.MonedaId, this.sesion);
                    else
                        this._moneda = new MonedasService(this.MonedaId);
                }
                return this._moneda;
            }
        }

        private TiposArticuloFinancieroService _tipo_articulo_financiero;
        public TiposArticuloFinancieroService TipoArticuloFinanciero
        {
            get
            {
                if (this._tipo_articulo_financiero == null)
                {
                    if (this.sesion != null)
                        this._tipo_articulo_financiero = new TiposArticuloFinancieroService(this.TipoArticuloFinancieroId, this.sesion);
                    else
                        this._tipo_articulo_financiero = new TiposArticuloFinancieroService(this.TipoArticuloFinancieroId);
                } 
                return this._tipo_articulo_financiero;
            }
        }

        private TiposCreditoService _tipo_credito;
        public TiposCreditoService TipoCredito
        {
            get
            {
                if (this._tipo_credito == null)
                {
                    if (this.sesion != null)
                        this._tipo_credito = new TiposCreditoService(this.TipoCreditoId, this.sesion);
                    else
                        this._tipo_credito = new TiposCreditoService(this.TipoCreditoId);
                }
                return this._tipo_credito;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.ARTICULOS_FINANCIEROSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ARTICULOS_FINANCIEROSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(ARTICULOS_FINANCIEROSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public ArticulosFinancierosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public ArticulosFinancierosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public ArticulosFinancierosService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private ArticulosFinancierosService(ARTICULOS_FINANCIEROSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            if (!RolesService.Tiene("ARTICULOS FINANCIEROS EDITAR"))
                throw new Exception("No tiene permisos para guardar");

            this.Validar();

            if (!this.ExisteEnDB)
            {
                if (this.MonedaId <= 0)
                    this.MonedaId = sesion.SucursalActiva.MONEDA_ID;
                if (this.Estado.Length <= 0)
                    this.Estado = Definiciones.Estado.Activo;
                if (this.DesembolsarParaCliente.Length <= 0)
                    this.DesembolsarParaCliente = Definiciones.SiNo.Si;
                if (this.AnhoComercial.Length <= 0)
                    this.AnhoComercial = Definiciones.SiNo.Si;
                if (this.Frecuencia <= 0)
                    this.Frecuencia = 1;
                if (this.TipoFrecuencia.Length <= 0)
                    this.TipoFrecuencia = Definiciones.TiposIntervalo.Meses;
                if (this.FacturarConceptosEnPagos.Length <= 0)
                    this.FacturarConceptosEnPagos = Definiciones.SiNo.No;
                if (this.InteresIncluyeImpuesto.Length <= 0)
                    this.InteresIncluyeImpuesto = Definiciones.SiNo.No;
                if (this.ConceptoIncluyeImpuesto.Length <= 0)
                    this.ConceptoIncluyeImpuesto = Definiciones.SiNo.No;
                if (this.AumentarCapitalPorDescuent.Length <= 0)
                    this.AumentarCapitalPorDescuent = Definiciones.SiNo.Si;
                if (this.ConRecurso.Length <= 0)
                    this.ConRecurso = Definiciones.SiNo.Si;

                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                sesion.db.ARTICULOS_FINANCIEROSCollection.Insert(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
            }
            else
            {
                sesion.db.ARTICULOS_FINANCIEROSCollection.Update(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.rowSinModificar.ToString(), this.row.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();
            return this.Id.Value;
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            string clausulas = Modelo.ARTICULO_IDColumnName + " = " + this.ArticuloId + " and " +
                               Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'";
            if (this.Id.HasValue)
                clausulas += " and " + Modelo.IDColumnName + " <> " + this.Id.Value;

            ARTICULOS_FINANCIEROSRow[] rows = sesion.db.ARTICULOS_FINANCIEROSCollection.GetAsArray(clausulas, string.Empty);
            if (rows.Length > 0)
                excepciones.Agregar("El artículo ya corresponde a otro artículo financiero.", null);

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._articulo = null;
            this._articulo_refinanciacion = null;
            this._canal_venta = null;
            this._moneda = null;
            this._persona = null;
            this._tipo_articulo_financiero = null;
            this._tipo_credito = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override ArticulosFinancierosService[] Buscar(Filtro[] filtros)
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
                        case Modelo.ARTICULO_IDColumnName:
                        case Modelo.CANAL_VENTA_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.MONEDA_IDColumnName:
                        case Modelo.PERSONA_IDColumnName:
                        case Modelo.TIPO_CREDITO_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case FiltroExtension.Articulo:
                            string valorUpper = f.Valor.ToString().ToUpper();
                            sb.Append(" exists(select * from " + ArticulosService.Nombre_Tabla + " a " +
                                         "         where a." + ArticulosService.Id_NombreCol + " = " + Nombre_Tabla + "." + Modelo.ARTICULO_IDColumnName +
                                         "           and (" +
                                         "                upper(a." + ArticulosService.CodigoEmpresa_NombreCol + ") = '" + valorUpper + "' " +
                                         "             or upper(a." + ArticulosService.DescripcionInterna_NombreCol + ") like '%" + valorUpper + "%' " +
                                         "               )");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            ARTICULOS_FINANCIEROSRow[] rows = sesion.db.ARTICULOS_FINANCIEROSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            ArticulosFinancierosService[] af = new ArticulosFinancierosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                af[i] = new ArticulosFinancierosService(rows[i]);
            return af;
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

        #region GetRangoAplica
        public ArticulosFinancierosRangosService GetRangoAplica(Definiciones.TiposArticuloFinancieroRango tipo_rango, decimal monto, decimal cantidad_cuotas, int cantidad_dias)
        {
            ArticulosFinancierosRangosService rango = null;
            ArticulosFinancierosRangosService[] rangosPosibles = null;

            int diasDesde;
            switch ((int)this.PoliticaBusquedaRangoDias)
            { 
                case (int)Definiciones.ArticulosFinancierosPoliticaRangoDias.CantidadCuotasPorTreinta:
                    diasDesde = (int)cantidad_cuotas * 30;
                    break;
                case (int)Definiciones.ArticulosFinancierosPoliticaRangoDias.DiasRealesHastaVencimiento:
                    diasDesde = cantidad_dias;
                    break;
                default:
                    throw new Exception("Política de búsqueda días " + this.PoliticaBusquedaRangoDias + " no implementada.");
            }

            //monto exacto, ordenando resultado por dias descendente
            rangosPosibles = this.GetFiltrado<ArticulosFinancierosRangosService>(new Filtro[]
            {
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.ARTICULO_FINANCIERO_IDColumnName, Valor = this.Id.Value },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName, Valor = (int)tipo_rango },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.MONTO_DESDEColumnName, Valor = monto },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.MONTO_DESDEColumnName, OrderBy = true, Valor = "desc" },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.DIAS_DESDEColumnName, OrderBy = true, Valor = "desc" },
            });

            if (rangosPosibles.Length > 0)
                return rangosPosibles[0];

            //Si no se encontró, buscar priorizando el plazo en dias
            rangosPosibles = this.GetFiltrado<ArticulosFinancierosRangosService>(new Filtro[]
            {
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.ARTICULO_FINANCIERO_IDColumnName, Valor = this.Id.Value },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName, Valor = (int)tipo_rango },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.DIAS_DESDEColumnName, Valor = diasDesde, Comparacion = "<=" },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.DIAS_DESDEColumnName, OrderBy = true, Valor = "desc" },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.MONTO_DESDEColumnName, OrderBy = true, Valor = "desc" },
            });

            if (rangosPosibles.Length > 0)
                return rangosPosibles[0];

            //Si no se encontró, buscar monto igual o menor, ordenando resultado por dias descendente
            rangosPosibles = this.GetFiltrado<ArticulosFinancierosRangosService>(new Filtro[]
            {
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.ARTICULO_FINANCIERO_IDColumnName, Valor = this.Id.Value },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName, Valor = (int)tipo_rango },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.MONTO_DESDEColumnName, Valor = monto, Comparacion = "<=" },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.MONTO_DESDEColumnName, OrderBy = true, Valor = "desc" },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.DIAS_DESDEColumnName, OrderBy = true, Valor = "desc" },
            });
            
            //Si no se encontró, buscar el monto mas bajo no menor que el solicitado
            if (rangosPosibles != null)
            {
                foreach (var r in rangosPosibles)
                {
                    if (r.DiasDesde < rangosPosibles[0].DiasDesde)
                        break;
                    
                    if (r.MontoDesde <= monto || rango == null)
                        rango = r;
                }
            }

            if (rango != null)
                return rango;

            //Si no se encontro, buscar el monto y plazo mas bajos
            rangosPosibles = this.GetFiltrado<ArticulosFinancierosRangosService>(new Filtro[]
            {
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.ARTICULO_FINANCIERO_IDColumnName, Valor = this.Id.Value },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName, Valor = (int)tipo_rango },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.DIAS_DESDEColumnName, OrderBy = true, Valor = "asc"  },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.MONTO_DESDEColumnName, OrderBy = true, Valor = "asc" },
            });
            
            foreach (var r in rangosPosibles)
            {
                if (r.DiasDesde > rangosPosibles[0].DiasDesde)
                    break;

                if (r.MontoDesde <= monto)
                    rango = r;
            }

            if (rango == null)
                rango = rangosPosibles[0];

            return rango;
        }
        #endregion GetRangos

        #region GetRangoDiasDesde
        public decimal[] GetRangoDiasDesde(decimal tipo_articulo_financiero_rango_id)
        {
            if (this.sesion == null)
            {
                using (SessionService sesion = new SessionService())
                {
                    return this.GetRangoDiasDesde(tipo_articulo_financiero_rango_id, sesion);
                }
            }
            else
            {
                return this.GetRangoDiasDesde(tipo_articulo_financiero_rango_id, this.sesion);
            }
        }
        public decimal[] GetRangoDiasDesde(decimal tipo_articulo_financiero_rango_id, SessionService sesion)
        {
            string sql = "select distinct " + ArticulosFinancierosRangosService.Modelo.DIAS_DESDEColumnName +
                         "  from " + ArticulosFinancierosRangosService.Nombre_Tabla +
                         " where " + ArticulosFinancierosRangosService.Modelo.ARTICULO_FINANCIERO_IDColumnName + " = " + this.Id.Value +
                         "   and " + ArticulosFinancierosRangosService.Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName + " = " + tipo_articulo_financiero_rango_id +
                         "   and " + ArticulosFinancierosRangosService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'" +
                         " order by " + ArticulosFinancierosRangosService.Modelo.DIAS_DESDEColumnName;
            DataTable dt = sesion.db.EjecutarQuery(sql);
            var valores = new decimal[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
                valores[i] = (decimal)dt.Rows[i][0];
            return valores;
        }
        #endregion GetRangoDiasDesde

        #region GetRangoMontosDesde
        public decimal[] GetRangoMontosDesde(decimal tipo_articulo_financiero_rango_id)
        {
            if (this.sesion == null)
            {
                using (SessionService sesion = new SessionService())
                {
                    return this.GetRangoMontosDesde(tipo_articulo_financiero_rango_id, sesion);
                }
            }
            else
            {
                return this.GetRangoMontosDesde(tipo_articulo_financiero_rango_id, this.sesion);
            }
        }
        public decimal[] GetRangoMontosDesde(decimal tipo_articulo_financiero_rango_id, SessionService sesion)
        {
            string sql = "select distinct " + ArticulosFinancierosRangosService.Modelo.MONTO_DESDEColumnName +
                         "  from " + ArticulosFinancierosRangosService.Nombre_Tabla +
                         " where " + ArticulosFinancierosRangosService.Modelo.ARTICULO_FINANCIERO_IDColumnName + " = " + this.Id.Value +
                         "   and " + ArticulosFinancierosRangosService.Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName + " = " + tipo_articulo_financiero_rango_id +
                         "   and " + ArticulosFinancierosRangosService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'" +
                         " order by " + ArticulosFinancierosRangosService.Modelo.MONTO_DESDEColumnName;
            DataTable dt = sesion.db.EjecutarQuery(sql);
            var valores = new decimal[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
                valores[i] = (decimal)dt.Rows[i][0];
            return valores;
        }
        #endregion GetRangoMontosDesde

        #region SugerirCantidadCuotas
        public void SugerirCapitalYCuotas(out decimal monto, out int cuotas)
        {
            var rango = this.GetPrimero<ArticulosFinancierosRangosService>(new Filtro[]
            {
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.ARTICULO_FINANCIERO_IDColumnName, Valor = this.Id.Value },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName, Valor = (int)Definiciones.TiposArticuloFinancieroRango.InteresCorriente },
                new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.DIAS_DESDEColumnName, OrderBy = true, Valor = "desc" },
            });

            monto = rango.MontoDesde;
            cuotas = (int)rango.DiasDesde;

            switch (this.TipoFrecuencia)
            {
                case Definiciones.TiposIntervalo.Anhos:
                    cuotas /= 360;
                    break;
                case Definiciones.TiposIntervalo.Meses:
                    cuotas /= 30;
                    break;
                case Definiciones.TiposIntervalo.Semanas:
                    cuotas /= 7;
                    break;
            }
        }
        #endregion SugerirCantidadCuotas

        #region Metodos auxiliares para inicializar valores
        #region CalcularErrorCapital
        private static decimal CalcularErrorCapital(CreditosService credito, decimal devolucion)
        {
            //Calcular cuotas para que el objeto actualice el total
            var cuotas = TiposCreditoService.CalcularCuotasPorTipo(credito);

            decimal montoTotal;
            if (credito.InteresCompuesto == Definiciones.SiNo.Si)
                montoTotal = credito.MontoTotal;
            else
                montoTotal = (cuotas[0].MontoCapital + cuotas[0].MontoInteresADevengar + cuotas[0].MontoImpuesto) * credito.CantidadCuotas;

            return devolucion - montoTotal;
        }
        #endregion CalcularErrorCapital

        #region CalcularErrorInteres
        private static decimal CalcularErrorInteres(decimal interes, decimal total_a_devolver, CreditosService credito, int[] dias_periodo, int[] dias_transcurridos)
        {
            decimal deuda, pago = 0;
            decimal montoCuota = total_a_devolver / credito.CantidadCuotas;
            double interesDiario;
            int plazoDias = credito.CantidadDias;
            int diasEnAnho = credito.AnhoComercial == Definiciones.SiNo.Si ? 360 : 365;

            if (credito.InteresCompuesto == Definiciones.SiNo.Si)
            {
                interesDiario = Math.Pow((double)interes + 1, 1.00 / diasEnAnho) - 1;
                deuda = credito.MontoCapitalAprobado * (decimal)Math.Pow(1 + interesDiario, plazoDias);
                for (int i = 0; i < credito.CantidadCuotas; i++)
                    pago += montoCuota * (decimal)Math.Pow(1 + (double)interesDiario, plazoDias - dias_transcurridos[i]);
            }
            else
            {
                interesDiario = (double)interes / diasEnAnho;
                deuda = credito.MontoCapitalAprobado;
                for (int i = 0; i < credito.CantidadCuotas; i++)
                {
                    deuda = deuda * (1 + (decimal)interesDiario * dias_periodo[i]);
                    pago += montoCuota * (1 + (decimal)interesDiario * (plazoDias - dias_transcurridos[i]));
                }
            }

            return deuda - pago;
        }
        #endregion CalcularErrorInteres

        #region IniciarConceptosDefinidos
        private static void IniciarConceptosDefinidos(ref CreditosService credito, ArticulosFinancierosService articulo_financiero)
        {
            ArticulosFinancierosRangosService rangoBOC, rangoCA, rangoC, rangoGA, rangoS, rangoO, rangoMora;
            #region cerar valores
            credito.PorcentajeGastoAdminist = null;
            credito.PorcentajeSeguro = null;
            credito.PorcentajeCorretaje = null;
            credito.PorcentajeComisionAdmin = null;
            credito.PorcentajeOtros = null;
            credito.PorcentajeBonificacion = null;
            credito.PorcentajeDiarioMora = null;
            credito.MontoGastoAdministrativo = null;
            credito.MontoSeguro = null;
            credito.MontoCorretaje = null;
            credito.MontoComisionAdmin = null;
            credito.MontoOtros = null;
            credito.MontoBonificacion = null;
            credito.MontoDiarioMora = null;
            #endregion cerar valores

            #region bonificacion Orden Compra
            //Primero completar el porcentaje correspondiente a la Bonificacion sobre Orden de Compra
            //ya que en general esta acordada por contrato, no usar en la distribucion de interes
            //TODO: falta contemplar que la bonificacion sea un monto o un porcentaje anual. De esta forma es un porcentaje independinete al plazo
            rangoBOC = articulo_financiero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.BonificacionOrdenCompra, credito.MontoCapitalAprobado, credito.CantidadCuotas, credito.CantidadDias);
            if (rangoBOC.Porcentaje.HasValue)
                credito.PorcentajeBonificacion = rangoBOC.Porcentaje;
            else if (rangoBOC.Monto.HasValue)
                credito.MontoBonificacion = rangoBOC.Monto;
            else
                credito.PorcentajeBonificacion = 0;
            #endregion bonificacion Orden Compra

            #region comision administrativa
            rangoCA = articulo_financiero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.ComisionAdministrativa, credito.MontoCapitalAprobado, credito.CantidadCuotas, credito.CantidadDias);
            if (rangoCA.Porcentaje.HasValue)
                credito.PorcentajeComisionAdmin = rangoCA.Porcentaje;
            else if (rangoCA.Monto.HasValue)
                credito.MontoComisionAdmin = rangoCA.Monto;
            else
                credito.PorcentajeComisionAdmin = 0;
            #endregion comision administrativa

            #region corretaje
            rangoC = articulo_financiero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.Corretaje, credito.MontoCapitalAprobado, credito.CantidadCuotas, credito.CantidadDias);
            if (rangoC.Porcentaje.HasValue)
                credito.PorcentajeCorretaje = rangoC.Porcentaje;
            else if (rangoC.Monto.HasValue)
                credito.MontoCorretaje = rangoC.Monto;
            else
                credito.PorcentajeComisionAdmin = 0;
            #endregion corretaje

            #region gasto adminitrativo
            rangoGA = articulo_financiero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.GastoAdministrativo, credito.MontoCapitalAprobado, credito.CantidadCuotas, credito.CantidadDias);
            if (rangoGA.Porcentaje.HasValue)
                credito.PorcentajeGastoAdminist = rangoGA.Porcentaje;
            else if (rangoGA.Monto.HasValue)
                credito.MontoGastoAdministrativo = rangoGA.Monto;
            else
                credito.PorcentajeGastoAdminist = 0;
            #endregion gasto adminitrativo

            #region seguro
            rangoS = articulo_financiero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.Seguro, credito.MontoCapitalAprobado, credito.CantidadCuotas, credito.CantidadDias);
            if (rangoS.Porcentaje.HasValue)
                credito.PorcentajeSeguro = rangoS.Porcentaje;
            else if (rangoS.Monto.HasValue)
                credito.MontoSeguro = rangoS.Monto;
            else
                credito.PorcentajeSeguro = 0;
            #endregion seguro

            #region otros
            rangoO = articulo_financiero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.Otros, credito.MontoCapitalAprobado, credito.CantidadCuotas, credito.CantidadDias);
            if (rangoO.Porcentaje.HasValue)
                credito.PorcentajeOtros = rangoO.Porcentaje;
            else if (rangoO.Monto.HasValue)
                credito.MontoOtros = rangoO.Monto;
            else
                credito.PorcentajeOtros = 0;
            #endregion otros

            #region Mora
            rangoMora = articulo_financiero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.Mora, credito.MontoCapitalAprobado, credito.CantidadCuotas, credito.CantidadDias);
            if (rangoMora.Porcentaje.HasValue)
                credito.PorcentajeDiarioMora = rangoMora.Porcentaje;
            else if (rangoMora.Monto.HasValue)
                credito.MontoDiarioMora = rangoMora.Monto;
            else
                credito.PorcentajeDiarioMora = 0;
            #endregion Mora
        }
        #endregion IniciarConceptosDefinidos

        #region AjustarConceptos
        private static void AjustarConceptos(ref CreditosService credito, ArticulosFinancierosService articulo_financiero)
        {
            TiposArticuloFinancieroRangoService tafr;
            decimal porcentajeAcutal, porcentajeASumar, factor, diferencia;
            decimal saldoCapital = credito.MontoCapitalAprobado - credito.MontoCapitalSolicitado - credito.MontoDescuentos;

            if (saldoCapital <= 0)
                return;

            #region Comision Administrativa
            tafr = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.ComisionAdministrativa);
            if (credito.MontoComisionAdmin.HasValue)
            {
                porcentajeAcutal = credito.MontoComisionAdmin.Value / credito.MontoCapitalAprobado * 100;
                if (credito.ConceptoIncluyeImpuesto == Definiciones.SiNo.No)
                    porcentajeAcutal *= (1 + ImpuestosService.GetPorcentajePorId(tafr.Articulo.ImpuestoId) / 100);
            }
            else
            {
                if (!credito.PorcentajeComisionAdmin.HasValue)
                    credito.PorcentajeComisionAdmin = 0;
                porcentajeAcutal = credito.PorcentajeComisionAdmin.Value;
            }

            porcentajeASumar = Math.Min(saldoCapital / credito.MontoCapitalAprobado * 100, tafr.PorcentajeTope - porcentajeAcutal);

            factor = 1;
            if (credito.MonedaId != tafr.MonedaTopeId)
                factor = CotizacionesService.GetCotizacionMonedaVenta(credito.Sucursal.PaisId, tafr.MonedaTopeId, credito.FechaSolicitud) / credito.Cotizacion;

            diferencia = tafr.MontoTope - (porcentajeAcutal + porcentajeASumar) / 100 * credito.MontoCapitalAprobado * factor;
            if (diferencia < 0)
                porcentajeASumar *= tafr.MontoTope / (tafr.MontoTope - diferencia);

            saldoCapital -= porcentajeASumar / 100 * credito.MontoCapitalAprobado;

            if (credito.ConceptoIncluyeImpuesto == Definiciones.SiNo.No)
                porcentajeASumar /= (1 + ImpuestosService.GetPorcentajePorId(tafr.Articulo.ImpuestoId) / 100);

            if(credito.MontoComisionAdmin.HasValue)
                credito.MontoComisionAdmin += porcentajeASumar / 100 * credito.MontoCapitalAprobado;
            else
                credito.PorcentajeComisionAdmin += porcentajeASumar;

            if (saldoCapital <= 0)
                return;
            #endregion Comision Administrativa

            #region Corretaje
            tafr = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Corretaje);
            if (credito.MontoCorretaje.HasValue)
            {
                porcentajeAcutal = credito.MontoCorretaje.Value / credito.MontoCapitalAprobado * 100;
                if (credito.ConceptoIncluyeImpuesto == Definiciones.SiNo.No)
                    porcentajeAcutal *= (1 + ImpuestosService.GetPorcentajePorId(tafr.Articulo.ImpuestoId) / 100);
            }
            else
            {
                if (!credito.PorcentajeCorretaje.HasValue)
                    credito.PorcentajeCorretaje = 0;
                porcentajeAcutal = credito.PorcentajeCorretaje.Value;
            }

            porcentajeASumar = Math.Min(saldoCapital / credito.MontoCapitalAprobado * 100, tafr.PorcentajeTope - porcentajeAcutal);

            factor = 1;
            if (credito.MonedaId != tafr.MonedaTopeId)
                factor = CotizacionesService.GetCotizacionMonedaVenta(credito.Sucursal.PaisId, tafr.MonedaTopeId, credito.FechaSolicitud) / credito.Cotizacion;

            diferencia = tafr.MontoTope - (porcentajeAcutal + porcentajeASumar) / 100 * credito.MontoCapitalAprobado * factor;
            if (diferencia < 0)
                porcentajeASumar *= tafr.MontoTope / (tafr.MontoTope - diferencia);

            saldoCapital -= porcentajeASumar / 100 * credito.MontoCapitalAprobado;

            if (credito.ConceptoIncluyeImpuesto == Definiciones.SiNo.No)
                porcentajeASumar /= (1 + ImpuestosService.GetPorcentajePorId(tafr.Articulo.ImpuestoId) / 100);

            if (credito.MontoCorretaje.HasValue)
                credito.MontoCorretaje += porcentajeASumar / 100 * credito.MontoCapitalAprobado;
            else
                credito.PorcentajeCorretaje += porcentajeASumar;

            if (saldoCapital <= 0)
                return;
            #endregion Corretaje

            #region Gasto Administrativo
            tafr = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.GastoAdministrativo);
            if (credito.MontoGastoAdministrativo.HasValue)
            {
                porcentajeAcutal = credito.MontoGastoAdministrativo.Value / credito.MontoCapitalAprobado * 100;
                if (credito.ConceptoIncluyeImpuesto == Definiciones.SiNo.No)
                    porcentajeAcutal *= (1 + ImpuestosService.GetPorcentajePorId(tafr.Articulo.ImpuestoId) / 100);
            }
            else
            {
                if (!credito.PorcentajeGastoAdminist.HasValue)
                    credito.PorcentajeGastoAdminist= 0;
                porcentajeAcutal = credito.PorcentajeGastoAdminist.Value;
            }

            porcentajeASumar = Math.Min(saldoCapital / credito.MontoCapitalAprobado * 100, tafr.PorcentajeTope - porcentajeAcutal);

            factor = 1;
            if (credito.MonedaId != tafr.MonedaTopeId)
                factor = CotizacionesService.GetCotizacionMonedaVenta(credito.Sucursal.PaisId, tafr.MonedaTopeId, credito.FechaSolicitud) / credito.Cotizacion;

            diferencia = tafr.MontoTope - (porcentajeAcutal + porcentajeASumar) / 100 * credito.MontoCapitalAprobado * factor;
            if (diferencia < 0)
                porcentajeASumar *= tafr.MontoTope / (tafr.MontoTope - diferencia);

            saldoCapital -= porcentajeASumar / 100 * credito.MontoCapitalAprobado;

            if (credito.ConceptoIncluyeImpuesto == Definiciones.SiNo.No)
                porcentajeASumar /= (1 + ImpuestosService.GetPorcentajePorId(tafr.Articulo.ImpuestoId) / 100);

            if (credito.MontoGastoAdministrativo.HasValue)
                credito.MontoGastoAdministrativo += porcentajeASumar / 100 * credito.MontoCapitalAprobado;
            else
                credito.PorcentajeGastoAdminist += porcentajeASumar;

            if (saldoCapital <= 0)
                return;
            #endregion Gasto Administrativo

            #region Seguro
            tafr = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Seguro);
            if (credito.MontoSeguro.HasValue)
            {
                porcentajeAcutal = credito.MontoSeguro.Value / credito.MontoCapitalAprobado * 100;
                if (credito.ConceptoIncluyeImpuesto == Definiciones.SiNo.No)
                    porcentajeAcutal *= (1 + ImpuestosService.GetPorcentajePorId(tafr.Articulo.ImpuestoId) / 100);
            }
            else
            {
                if (!credito.PorcentajeSeguro.HasValue)
                    credito.PorcentajeSeguro = 0;
                porcentajeAcutal = credito.PorcentajeSeguro.Value;
            }

            porcentajeASumar = Math.Min(saldoCapital / credito.MontoCapitalAprobado * 100, tafr.PorcentajeTope - porcentajeAcutal);

            factor = 1;
            if (credito.MonedaId != tafr.MonedaTopeId)
                factor = CotizacionesService.GetCotizacionMonedaVenta(credito.Sucursal.PaisId, tafr.MonedaTopeId, credito.FechaSolicitud) / credito.Cotizacion;

            diferencia = tafr.MontoTope - (porcentajeAcutal + porcentajeASumar) / 100 * credito.MontoCapitalAprobado * factor;
            if (diferencia < 0)
                porcentajeASumar *= tafr.MontoTope / (tafr.MontoTope - diferencia);

            saldoCapital -= porcentajeASumar / 100 * credito.MontoCapitalAprobado;

            if (credito.ConceptoIncluyeImpuesto == Definiciones.SiNo.No)
                porcentajeASumar /= (1 + ImpuestosService.GetPorcentajePorId(tafr.Articulo.ImpuestoId) / 100);

            if (credito.MontoSeguro.HasValue)
                credito.MontoSeguro += porcentajeASumar / 100 * credito.MontoCapitalAprobado;
            else
                credito.PorcentajeSeguro += porcentajeASumar;

            if (saldoCapital <= 0)
                return;
            #endregion Seguro

            #region Otros
            tafr = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Otros);
            if (credito.MontoOtros.HasValue)
            {
                porcentajeAcutal = credito.MontoOtros.Value / credito.MontoCapitalAprobado * 100;
                if (credito.ConceptoIncluyeImpuesto == Definiciones.SiNo.No)
                    porcentajeAcutal *= (1 + ImpuestosService.GetPorcentajePorId(tafr.Articulo.ImpuestoId) / 100);
            }
            else
            {
                if (!credito.PorcentajeOtros.HasValue)
                    credito.PorcentajeOtros = 0;
                porcentajeAcutal = credito.PorcentajeOtros.Value;
            }

            porcentajeASumar = Math.Min(saldoCapital / credito.MontoCapitalAprobado * 100, tafr.PorcentajeTope - porcentajeAcutal);

            factor = 1;
            if (credito.MonedaId != tafr.MonedaTopeId)
                factor = CotizacionesService.GetCotizacionMonedaVenta(credito.Sucursal.PaisId, tafr.MonedaTopeId, credito.FechaSolicitud) / credito.Cotizacion;

            diferencia = tafr.MontoTope - (porcentajeAcutal + porcentajeASumar) / 100 * credito.MontoCapitalAprobado * factor;
            if (diferencia < 0)
                porcentajeASumar *= tafr.MontoTope / (tafr.MontoTope - diferencia);

            saldoCapital -= porcentajeASumar / 100 * credito.MontoCapitalAprobado;

            if (credito.ConceptoIncluyeImpuesto == Definiciones.SiNo.No)
                porcentajeASumar /= (1 + ImpuestosService.GetPorcentajePorId(tafr.Articulo.ImpuestoId) / 100);

            if (credito.MontoOtros.HasValue)
                credito.MontoOtros += porcentajeASumar / 100 * credito.MontoCapitalAprobado;
            else
                credito.PorcentajeOtros += porcentajeASumar;

            if (saldoCapital <= 0)
                return;
            #endregion Otros
        }
        #endregion AjustarConceptos
        #endregion Metodos auxiliares para inicializar valores

        #region InicializarValoresFinancieros
        public static void InicializarValoresFinancieros(ref CreditosService credito, ArticulosFinancierosService articulo_financiero)
        {
            if (credito.MontoCapitalSolicitado + credito.MontoCapitalOrdenCompra <= 0)
                return;

            if (articulo_financiero.TipoArticuloFinanciero.DeducirPorcentajes == Definiciones.SiNo.No)
            {
                credito.MontoCapitalAprobado = credito.MontoCapitalSolicitado;
                IniciarConceptosDefinidos(ref credito, articulo_financiero);
                
                if (credito.AumentarCapitalPorDescuent == Definiciones.SiNo.Si)
                    credito.MontoCapitalAprobado = credito.MontoCapitalSolicitado + credito.MontoDescuentos;
            }
            else
            {
                decimal montoCuota, totalADevolver, cantidadCuotasAnuales;
                decimal errorMaximo = 0.00001m;
                decimal valorObjetivo;
                decimal[] capital = new decimal[3];
                decimal[] errorCapital = new decimal[3];
                decimal[] interes = new decimal[3];
                decimal[] errorInteres = new decimal[3];
                int[] diasTranscurridos = new int[(int)credito.CantidadCuotas];
                int[] diasPeriodo = new int[(int)credito.CantidadCuotas];
                int maxIteraciones = 1000, contador;
                DateTime fechaInicio, fechaVtoAnterior, fechaVto = DateTime.Now;
                TiposArticuloFinancieroRangoService tipoRangoInteres = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente);
                decimal porcentajeImpuesto = ImpuestosService.GetPorcentajePorId(tipoRangoInteres.Articulo.ImpuestoId);

                var tipo = new { Minimo = 0, Maximo = 1, Proximo = 2 };

                if (credito.MontoCapitalAprobado <= 0)
                    credito.MontoCapitalAprobado = credito.MontoCapitalSolicitado;

                totalADevolver = credito.MontoCapitalOrdenCompra;

                var rangoMontoCuota = articulo_financiero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.MontoPorCuotaBase, credito.MontoCapitalAprobado, credito.CantidadCuotas, credito.CantidadDias);
                if (rangoMontoCuota.Monto.HasValue && rangoMontoCuota.Monto.Value > 0)
                {
                    montoCuota = credito.MontoCapitalSolicitado / articulo_financiero.CuotaMontoBase.Value * rangoMontoCuota.Monto.Value;
                    totalADevolver = montoCuota * credito.CantidadCuotas;
                }

                if (totalADevolver <= 0)
                    throw new Exception("La deducción de intereses requiere indicar el monto de Orden de Compra o tener definido el monto de cuota.");

                #region Inicializar topes maximo y minimo de capital
                capital[tipo.Maximo] = totalADevolver;

                credito.MontoCapitalAprobado = credito.MontoCapitalSolicitado;
                if (credito.AumentarCapitalPorDescuent == Definiciones.SiNo.Si)
                    IniciarConceptosDefinidos(ref credito, articulo_financiero);
                credito.MontoCapitalAprobado += credito.MontoDescuentos;
                capital[tipo.Minimo] = credito.MontoCapitalAprobado;
                #endregion Inicializar topes maximo y minimo de capital

                #region Hallar el interes corriente
                fechaInicio = credito.FechaRetiro.HasValue ? credito.FechaRetiro.Value.Date : credito.FechaSolicitud.Date;
                fechaVtoAnterior = fechaInicio;

                #region calcular fechas de vencimiento y numero cuota
                for (int i = 0; i < credito.CantidadCuotas; i++)
                {
                    switch (credito.TipoFrecuencia)
                    {
                        case Definiciones.TiposIntervalo.Anhos: fechaVto = credito.FechaPrimerVencimiento.AddYears(i * (int)credito.Frecuencia); break;
                        case Definiciones.TiposIntervalo.Dias: fechaVto = credito.FechaPrimerVencimiento.AddDays(i * (int)credito.Frecuencia); break;
                        case Definiciones.TiposIntervalo.Meses: fechaVto = credito.FechaPrimerVencimiento.AddMonths(i * (int)credito.Frecuencia); break;
                        case Definiciones.TiposIntervalo.Semanas: fechaVto = credito.FechaPrimerVencimiento.AddDays(i * 7 * (int)credito.Frecuencia); break;
                    }

                    diasTranscurridos[i] = (fechaVto - fechaInicio).Days;
                    diasPeriodo[i] = (fechaVto - fechaVtoAnterior).Days;
                    fechaVtoAnterior = fechaVto;
                }
                #endregion calcular fechas de vencimiento y numero cuota

                cantidadCuotasAnuales = 1;
                switch (credito.TipoFrecuencia)
                {
                    case Definiciones.TiposIntervalo.Anhos: cantidadCuotasAnuales = 1 / credito.Frecuencia; break;
                    case Definiciones.TiposIntervalo.Dias: cantidadCuotasAnuales = 365 / credito.Frecuencia; break;
                    case Definiciones.TiposIntervalo.Meses: cantidadCuotasAnuales = 12 / credito.Frecuencia; break;
                    case Definiciones.TiposIntervalo.Semanas: cantidadCuotasAnuales = 52 / credito.Frecuencia; break;
                }

                credito.MontoCapitalAprobado = capital[tipo.Minimo];
                valorObjetivo = totalADevolver / credito.CantidadCuotas / credito.MontoCapitalAprobado;

                interes[tipo.Maximo] = valorObjetivo * cantidadCuotasAnuales;
                //Se agrega el impuesto si no estaba incluido
                if (credito.InteresIncluyeImpuesto == Definiciones.SiNo.No)
                    interes[tipo.Maximo] *= (100 + porcentajeImpuesto) / 100;
                errorInteres[tipo.Maximo] = CalcularErrorInteres(interes[tipo.Maximo], totalADevolver, credito, diasPeriodo, diasTranscurridos);

                interes[tipo.Minimo] = 0;
                errorInteres[tipo.Minimo] = credito.MontoCapitalAprobado - totalADevolver;

                contador = 0;
                do
                {
                    //Sea una recta definida por los puntos <capital minimo; error minimo> y <capital maximo; error maximo>
                    //El nuevo capital a utilizar sera donde la recta intersecte al eje Y (error = 0)
                    interes[tipo.Proximo] = interes[tipo.Minimo] - errorInteres[tipo.Minimo] * (interes[tipo.Maximo] - interes[tipo.Minimo]) / (errorInteres[tipo.Maximo] - errorInteres[tipo.Minimo]);
                    errorInteres[tipo.Proximo] = CalcularErrorInteres(interes[tipo.Proximo], totalADevolver, credito, diasPeriodo, diasTranscurridos);

                    if (errorInteres[tipo.Proximo] > 0)
                    {
                        interes[tipo.Maximo] = interes[tipo.Proximo];
                        errorInteres[tipo.Maximo] = errorInteres[tipo.Proximo];
                    }
                    else
                    {
                        interes[tipo.Minimo] = interes[tipo.Proximo];
                        errorInteres[tipo.Minimo] = errorInteres[tipo.Proximo];
                    }
                }
                while (Math.Abs(errorInteres[tipo.Proximo]) > errorMaximo && contador++ < maxIteraciones);

                credito.PorcentajeInteres = interes[tipo.Proximo] * 100;
                //Se quita el impuesto si no estaba incluido
                if (credito.InteresIncluyeImpuesto == Definiciones.SiNo.No)
                    credito.PorcentajeInteres /= (100 + porcentajeImpuesto) / 100;
                
                var tafr = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente);
                credito.PorcentajeInteres = Math.Min(credito.PorcentajeInteres.Value, tafr.PorcentajeTope);
                #endregion Hallar el interes corriente

                #region Inicializar error de topes maximo y minimo
                credito.MontoCapitalAprobado = capital[tipo.Maximo];
                errorCapital[tipo.Maximo] = CalcularErrorCapital(credito, totalADevolver);

                credito.MontoCapitalAprobado = capital[tipo.Minimo];
                errorCapital[tipo.Minimo] = CalcularErrorCapital(credito, totalADevolver);
                #endregion Inicializar error de topes maximo y minimo

                contador = 0;
                do
                {
                    //Sea una recta definida por los puntos <capital minimo; error minimo> y <capital maximo; error maximo>
                    //El nuevo capital a utilizar sera donde la recta intersecte al eje Y (error = 0)
                    capital[tipo.Proximo] = capital[tipo.Minimo] - errorCapital[tipo.Minimo] * (capital[tipo.Maximo] - capital[tipo.Minimo]) / (errorCapital[tipo.Maximo] - errorCapital[tipo.Minimo]);
                    credito.MontoCapitalAprobado = capital[tipo.Proximo];

                    IniciarConceptosDefinidos(ref credito, articulo_financiero);

                    errorCapital[tipo.Proximo] = CalcularErrorCapital(credito, totalADevolver);

                    if (errorCapital[tipo.Proximo] > 0)
                    {
                        capital[tipo.Maximo] = capital[tipo.Proximo];
                        errorCapital[tipo.Maximo] = errorCapital[tipo.Proximo];
                    }
                    else
                    {
                        capital[tipo.Minimo] = capital[tipo.Proximo];
                        errorCapital[tipo.Minimo] = errorCapital[tipo.Proximo];
                    }
                }
                while (Math.Abs(errorCapital[tipo.Proximo]) > errorMaximo && contador++ < maxIteraciones);

                AjustarConceptos(ref credito, articulo_financiero);
            }
        }
        #endregion InicializarValoresFinancieros

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_FINANCIEROS"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "ARTICULOS_FINANCIEROS_SQC"; }
        }
        #endregion Accessors
    }
}
