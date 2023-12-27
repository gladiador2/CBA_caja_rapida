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
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Facturacion;

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosCostosCierresDetallesService : ClaseCBA<ArticulosCostosCierresDetallesService>
    {
        #region FiltrosExtension
        public static class FiltroExtension
        {
            public const string ArticulosCostosCierreRegionId = "REGION_ID";
            public const string ArticulosCostosCierreFecha = "FECHA_CIERRE";
        }
        #endregion FiltrosExtension
        
        #region Propiedades
        protected ARTICULOS_COSTOS_CIERRES_DETRow row;
        protected ARTICULOS_COSTOS_CIERRES_DETRow rowSinModificar;
        public class Modelo : ARTICULOS_COSTOS_CIERRES_DETCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal ArticuloCostoCierreId { get { return row.ARTICULO_COSTO_CIERRE_ID; } set { row.ARTICULO_COSTO_CIERRE_ID = value; } }
        public decimal ArticuloId { get { return row.ARTICULO_ID; } set { row.ARTICULO_ID = value; } }
        public decimal CantidadAnterior { get { return row.CANTIDAD_ANTERIOR; } set { row.CANTIDAD_ANTERIOR = value; } }
        public decimal CantidadVariacionNegativa { get { return row.CANTIDAD_VARIACION_NEGATIVA; } set { row.CANTIDAD_VARIACION_NEGATIVA = value; } }
        public decimal CantidadVariacionPositiva { get { return row.CANTIDAD_VARIACION_POSITIVA; } set { row.CANTIDAD_VARIACION_POSITIVA = value; } }
        public decimal CostoActual { get { return row.COSTO_ACTUAL; } set { row.COSTO_ACTUAL = value; } }
        public decimal CostoAnterior { get { return row.COSTO_ANTERIOR; } set { row.COSTO_ANTERIOR = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        #endregion Propiedades
        
        #region Propiedades Extendidas
        private ArticulosService _articulo;
        public ArticulosService Articulo
        {
            get
            {
                if (this._articulo == null)
                {
                    if (this.sesion != null)
                        this._articulo = new ArticulosService(this.ArticuloId, this.sesion);
                    else
                        this._articulo = new ArticulosService(this.ArticuloId);
                }
                return this._articulo;
            }
        }
        
        private ArticulosCostosCierresService _articulo_costo_cierre;
        public ArticulosCostosCierresService ArticuloCostoCierre
        {
            get
            {
                if (this._articulo_costo_cierre == null)
                    this._articulo_costo_cierre = this.Get<ArticulosCostosCierresService>(this.ArticuloCostoCierreId);
                return this._articulo_costo_cierre;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.ARTICULOS_COSTOS_CIERRES_DETCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ARTICULOS_COSTOS_CIERRES_DETRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(ARTICULOS_COSTOS_CIERRES_DETRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public ArticulosCostosCierresDetallesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public ArticulosCostosCierresDetallesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public ArticulosCostosCierresDetallesService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private ArticulosCostosCierresDetallesService(ARTICULOS_COSTOS_CIERRES_DETRow row)
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
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.Estado = Definiciones.Estado.Activo;

                sesion.db.ARTICULOS_COSTOS_CIERRES_DETCollection.Insert(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
            }
            else
            {
                sesion.db.ARTICULOS_COSTOS_CIERRES_DETCollection.Update(this.row);
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

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._articulo = null;
            this._articulo_costo_cierre = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override ArticulosCostosCierresDetallesService[] Buscar(Filtro[] filtros)
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
                        case Modelo.ARTICULO_COSTO_CIERRE_IDColumnName:
                        case Modelo.ARTICULO_IDColumnName:
                        case Modelo.CANTIDAD_ANTERIORColumnName:
                        case Modelo.CANTIDAD_VARIACION_NEGATIVAColumnName:
                        case Modelo.CANTIDAD_VARIACION_POSITIVAColumnName:
                        case Modelo.COSTO_ACTUALColumnName:
                        case Modelo.COSTO_ANTERIORColumnName:
                        case Modelo.IDColumnName:
                            if(f.Exacto)
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + f.Valor + ")");
                            break;
                        case FiltroExtension.ArticulosCostosCierreRegionId:
                            sb.Append(" exists(select * from " + ArticulosCostosCierresService.Nombre_Tabla + " acc " +
                                         "         where acc." + ArticulosCostosCierresService.Modelo.IDColumnName + " = " + Nombre_Tabla + "." + Modelo.ARTICULO_COSTO_CIERRE_IDColumnName +
                                         "           and acc." + f.Columna + " = " + f.Valor + ") ");
                            break;
                        case FiltroExtension.ArticulosCostosCierreFecha:
                            sb.Append(" exists(select * from " + ArticulosCostosCierresService.Nombre_Tabla + " acc " +
                                         "         where acc." + ArticulosCostosCierresService.Modelo.IDColumnName + " = " + Nombre_Tabla + "." + Modelo.ARTICULO_COSTO_CIERRE_IDColumnName +
                                         "           and trunc(acc." + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')) ");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            var rows = sesion.db.ARTICULOS_COSTOS_CIERRES_DETCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            ArticulosCostosCierresDetallesService[] acc = new ArticulosCostosCierresDetallesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                acc[i] = new ArticulosCostosCierresDetallesService(rows[i]);
            return acc;
        }
        #endregion Buscar

        #region Borrar
        public void Borrar()
        {
            this.Estado = Definiciones.Estado.Inactivo;
            this.Guardar();
        }
        #endregion Borrar

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
        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_COSTOS_CIERRES_DET"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "ARTICULOS_COSTOS_CIER_DET_SQC"; }
        }
        #endregion Accessors
    }
}
