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
using Newtonsoft.Json;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class TiposRelacionesPersonasService : ClaseCBA<TiposRelacionesPersonasService>
    {
        #region Propiedades
        protected TIPOS_RELACIONES_PERSONASRow row;
        protected TIPOS_RELACIONES_PERSONASRow rowSinModificar;
        public class Modelo : TIPOS_RELACIONES_PERSONASCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.TIPOS_RELACIONES_PERSONASCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new TIPOS_RELACIONES_PERSONASRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(TIPOS_RELACIONES_PERSONASRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public TiposRelacionesPersonasService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public TiposRelacionesPersonasService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public TiposRelacionesPersonasService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private TiposRelacionesPersonasService(TIPOS_RELACIONES_PERSONASRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            throw new Exception("Los tipos de relaciones no deben ser creados desde la UI.");
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
        protected override TiposRelacionesPersonasService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append(Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'");

            foreach (Filtro f in filtros)
            {
                if (f.OrderBy)
                    orden.Add(f.Columna + " " + f.Valor);

                if (f.Valor.ToString().Length <= 0)
                    continue;

                sb.Append(" and ");
                switch (f.Columna)
                {
                    case Modelo.IDColumnName:
                    case Modelo.NOMBREColumnName:
                        if (f.Exacto)
                            sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                        else
                            sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                        break;
                    default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                }
            }

            orden.Add(Modelo.NOMBREColumnName);
            TIPOS_RELACIONES_PERSONASRow[] rows = sesion.db.TIPOS_RELACIONES_PERSONASCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            TiposRelacionesPersonasService[] trp = new TiposRelacionesPersonasService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                trp[i] = new TiposRelacionesPersonasService(rows[i]);
            return trp;
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
                return sesion.Db.TIPOS_RELACIONES_PERSONASCollection.GetAsDataTable(Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'", Modelo.NOMBREColumnName);
            }
        }
        #endregion GetDataTable

        #region Accessors
        public static string Nombre_Tabla = "TIPOS_RELACIONES_PERSONAS";
        #endregion Accessors
    }
}
