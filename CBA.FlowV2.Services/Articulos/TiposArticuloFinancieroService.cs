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
    public class TiposArticuloFinancieroService : ClaseCBA<TiposArticuloFinancieroService>
    {
        #region Propiedades
        protected TIPOS_ARTICULO_FINANCIERORow row;
        protected TIPOS_ARTICULO_FINANCIERORow rowSinModificar;
        public class Modelo : TIPOS_ARTICULO_FINANCIEROCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal CantidadAprobaciones { get { return row.CANTIDAD_APROBACIONES; } set { row.CANTIDAD_APROBACIONES = value; } }
        public string Estado { get { return GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public string DeducirPorcentajes { get { return GetStringHelper(row.DEDUCIR_PORCENTAJES); } set { row.DEDUCIR_PORCENTAJES = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string InteresCompuesto { get { return GetStringHelper(row.INTERES_COMPUESTO); } set { row.INTERES_COMPUESTO = value; } }
        public string Nombre { get { return GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.TIPOS_ARTICULO_FINANCIEROCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new TIPOS_ARTICULO_FINANCIERORow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(TIPOS_ARTICULO_FINANCIERORow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public TiposArticuloFinancieroService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public TiposArticuloFinancieroService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public TiposArticuloFinancieroService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private TiposArticuloFinancieroService(TIPOS_ARTICULO_FINANCIERORow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            throw new Exception("El modelo no puede ser modificado desde la interfaz.");
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
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override TiposArticuloFinancieroService[] Buscar(Filtro[] filtros)
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
                        case Modelo.CANTIDAD_APROBACIONESColumnName:
                        case Modelo.IDColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            break;
                        case Modelo.NOMBREColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "' ");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%' ");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            TIPOS_ARTICULO_FINANCIERORow[] rows = sesion.db.TIPOS_ARTICULO_FINANCIEROCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            TiposArticuloFinancieroService[] taf = new TiposArticuloFinancieroService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                taf[i] = new TiposArticuloFinancieroService(rows[i]);
            return taf;
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
        public static DataTable GetDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.TIPOS_ARTICULO_FINANCIEROCollection.GetAsDataTable(Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'", Modelo.NOMBREColumnName);
            }
        }
        #endregion GetDataTable

        #region Accessors
        public static string Nombre_Tabla = "TIPOS_ARTICULO_FINANCIERO";
        #endregion Accessors
    }
}
