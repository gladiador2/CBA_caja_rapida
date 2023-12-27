#region Using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Giros;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Articulos
{
    public class CatalogosService : ClaseCBA<CatalogosService>
    {
        #region Propiedades
        protected CATALOGOSRow row;
        protected CATALOGOSRow rowSinModificar;
        public class Modelo : CATALOGOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime? FechaDesde { get { if (row.IsFECHA_DESDENull) return null; else return row.FECHA_DESDE; } set { if (value.HasValue) row.FECHA_DESDE = value.Value; else row.IsFECHA_DESDENull = true; } }
        public DateTime? FechaHasta { get { if (row.IsFECHA_HASTANull) return null; else return row.FECHA_HASTA; } set { if (value.HasValue) row.FECHA_HASTA = value.Value; else row.IsFECHA_HASTANull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        public decimal TipoCatalogoId { get { return row.TIPO_CATALOGO_ID; } set { row.TIPO_CATALOGO_ID = value; } }
        #endregion Propiedades

        #region Propiedades extendidas
        private TiposCatalogosService _tipo_catalogo;
        public TiposCatalogosService TipoCatalogo
        {
            get
            {
                if (this._tipo_catalogo == null)
                    this._tipo_catalogo = new TiposCatalogosService(this.TipoCatalogoId);
                return this._tipo_catalogo;
            }

        }
        #endregion Propiedades extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CATALOGOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CATALOGOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CATALOGOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CatalogosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CatalogosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CatalogosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private CatalogosService(CATALOGOSRow row)
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
                sesion.db.CATALOGOSCollection.Insert(this.row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.CATALOGOSCollection.Update(this.row);
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
            this._tipo_catalogo = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override CatalogosService[] Buscar(Filtro[] filtros)
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
                        case Modelo.IDColumnName:
                        case Modelo.TIPO_CATALOGO_IDColumnName:
                            sb.Append(f.Columna + " = " + f.Valor);
                            break;
                        case Modelo.NOMBREColumnName:
                        case Modelo.ESTADOColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case Modelo.FECHA_DESDEColumnName:
                        case Modelo.FECHA_HASTAColumnName:
                            if(f.Exacto)
                                sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            else
                                sb.Append("(trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy') or " + f.Columna + " is null)");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            CATALOGOSRow[] rows = sesion.db.CATALOGOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            CatalogosService[] c = new CatalogosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                c[i] = new CatalogosService(rows[i]);
            return c;
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
        public static string Nombre_Tabla = "CATALOGOS";
        public static string Nombre_Secuencia = "CATALOGOS_SQC";
        #endregion Accessors
    }
}
