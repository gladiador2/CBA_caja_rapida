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
#endregion Using

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosFinancierosRangosService : ClaseCBA<ArticulosFinancierosRangosService>
    {
        #region Propiedades
        protected ARTICULOS_FINANCIEROS_RANGOSRow row;
        protected ARTICULOS_FINANCIEROS_RANGOSRow rowSinModificar;
        public class Modelo : ARTICULOS_FINANCIEROS_RANGOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal ArticuloFinancieroId { get { return row.ARTICULO_FINANCIERO_ID; } set { row.ARTICULO_FINANCIERO_ID = value; } }
        public string ConsiderarPlazo { get { return row.CONSIDERAR_PLAZO; } set { row.CONSIDERAR_PLAZO = value; } }
        public decimal DiasDesde { get { return row.DIAS_DESDE; } set { row.DIAS_DESDE = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? Monto { get { if (row.IsMONTONull) return null; else return row.MONTO; } set { if (value.HasValue) row.MONTO = value.Value; else row.IsMONTONull = true; } }
        public decimal MontoDesde { get { return row.MONTO_DESDE; } set { row.MONTO_DESDE = value; } }
        public decimal? Porcentaje { get { if (row.IsPORCENTAJENull) return null; else return row.PORCENTAJE; } set { if (value.HasValue) row.PORCENTAJE = value.Value; else row.IsPORCENTAJENull = true; } }
        public decimal TipoArticuloFinancRangoId { get { return row.TIPO_ARTICULO_FINANC_RANGO_ID; } set { row.TIPO_ARTICULO_FINANC_RANGO_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private ArticulosFinancierosService _articuloFinanciero;
        public ArticulosFinancierosService ArticuloFinanciero
        {
            get
            {
                if (this._articuloFinanciero == null)
                    this._articuloFinanciero = new ArticulosFinancierosService(this.ArticuloFinancieroId);
                return this._articuloFinanciero;
            }
        }

        private TiposArticuloFinancieroRangoService _tipoArticuloFinancRango;
        public TiposArticuloFinancieroRangoService TipoArticuloFinancRango
        {
            get
            {
                if (this._tipoArticuloFinancRango == null)
                    this._tipoArticuloFinancRango = new TiposArticuloFinancieroRangoService(this.TipoArticuloFinancRangoId);
                return this._tipoArticuloFinancRango;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.ARTICULOS_FINANCIEROS_RANGOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ARTICULOS_FINANCIEROS_RANGOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(ARTICULOS_FINANCIEROS_RANGOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public ArticulosFinancierosRangosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public ArticulosFinancierosRangosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public ArticulosFinancierosRangosService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private ArticulosFinancierosRangosService(ARTICULOS_FINANCIEROS_RANGOSRow row)
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
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.Estado = Definiciones.Estado.Activo;
                sesion.db.ARTICULOS_FINANCIEROS_RANGOSCollection.Insert(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
            }
            else
            {
                sesion.db.ARTICULOS_FINANCIEROS_RANGOSCollection.Update(this.row);
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

            if (this.Estado == Definiciones.Estado.Activo)
            {
                if (this.Porcentaje.HasValue && (this.Porcentaje.Value < 0 || this.Porcentaje.Value > 100))
                    excepciones.Agregar("El porcentaje debe estar entre 0 y 100.", null);

                if (this.Monto.HasValue && this.Monto < 0)
                    excepciones.Agregar("El monto debe ser mayor a cero.", null);
            }

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

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
            this.Estado = Definiciones.Estado.Inactivo;
            this.Guardar();
        }
        #endregion Borrar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._articuloFinanciero = null;
            this._tipoArticuloFinancRango = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override ArticulosFinancierosRangosService[] Buscar(Filtro[] filtros)
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
                        case Modelo.ARTICULO_FINANCIERO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName:
                            sb.Append(f.Columna + " = " + f.Valor);
                            break;
                        case Modelo.DIAS_DESDEColumnName:
                        case Modelo.MONTO_DESDEColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor.ToString().Replace(',', '.'));
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            ARTICULOS_FINANCIEROS_RANGOSRow[] rows = sesion.db.ARTICULOS_FINANCIEROS_RANGOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            ArticulosFinancierosRangosService[] afr = new ArticulosFinancierosRangosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                afr[i] = new ArticulosFinancierosRangosService(rows[i]);
            return afr;
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

        #region CantidadValores
        public static int CantidadValores(decimal articulo_financiero_id, decimal tipo_rango_financiero_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return CantidadValores(articulo_financiero_id, tipo_rango_financiero_id, sesion);
            }
        }

        public static int CantidadValores(decimal articulo_financiero_id, decimal tipo_rango_financiero_id, SessionService sesion)
        { 
            string sql = "select count(*) " +
                         "  from " + Nombre_Tabla + 
                         " where " + Modelo.ARTICULO_FINANCIERO_IDColumnName + " = " + articulo_financiero_id +
                         "   and " + Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName + " = " + tipo_rango_financiero_id +
                         "   and " + Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'";

            DataTable dt = sesion.db.EjecutarQuery(sql);
            return (int)(decimal)dt.Rows[0][0];
        }
        #endregion CantidadValores

        #region Importar
        public static int ImportarOReemplazar(ArticulosFinancierosRangosService[] rangos)
        {
            using(SessionService sesion = new SessionService())
            {
                return ImportarOReemplazar(rangos, sesion);
            }
        }

        public static int ImportarOReemplazar(ArticulosFinancierosRangosService[] rangos, SessionService sesion)
        {
            if (rangos.Length <= 0)
                return 0;

            int cont = 0;
            
            var objetoBase = ArticulosFinancierosRangosService.Instancia;
            objetoBase.IniciarUsingSesion(sesion);

            var fDias = new Filtro(){ Columna = Modelo.DIAS_DESDEColumnName };
            var fMonto = new Filtro(){ Columna = Modelo.MONTO_DESDEColumnName };

            var filtros = new Filtro[]
            {
                new Filtro(){ Columna = Modelo.ARTICULO_FINANCIERO_IDColumnName, Valor = rangos[0].ArticuloFinancieroId },
                new Filtro(){ Columna = Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName, Valor = rangos[0].TipoArticuloFinancRangoId },
                fDias, 
                fMonto
            };

            for (int i = 0; i < rangos.Length; i++)
            {
                fDias.Valor = rangos[i].DiasDesde;
                fMonto.Valor = rangos[i].MontoDesde;

                var r = objetoBase.GetPrimero<ArticulosFinancierosRangosService>(filtros);

                if (r == null)
                {
                    rangos[i].IniciarUsingSesion(sesion);
                    rangos[i].Guardar();
                    rangos[i].FinalizarUsingSesion();
                }
                else
                {
                    //Si no cambia algun dato, pasar al siguiente
                    if (r != null && r.Monto == rangos[i].Monto && r.Porcentaje == rangos[i].Porcentaje && r.ConsiderarPlazo == rangos[i].ConsiderarPlazo)
                        continue;

                    r.Monto = rangos[i].Monto;
                    r.Porcentaje = rangos[i].Porcentaje;
                    r.ConsiderarPlazo = rangos[i].ConsiderarPlazo;

                    r.IniciarUsingSesion(sesion);
                    r.Guardar();
                    r.FinalizarUsingSesion();
                }
                
                cont++;
            }

            objetoBase.FinalizarUsingSesion();

            return cont;
        }

        #endregion Importar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_FINANCIEROS_RANGOS"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "ARTICULOS_FINANCIEROS_RANG_SQC"; }
        }
        #endregion Accessors
    }
}
