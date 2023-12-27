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
    public class CreditosDetallesService : ClaseCBA<CreditosDetallesService>
    {
        #region Propiedades
        protected CREDITOS_DETALLESRow row;
        protected CREDITOS_DETALLESRow rowSinModificar;
        public class Modelo : CREDITOS_DETALLESCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal CreditoId { get { return row.CREDITO_ID; } set { row.CREDITO_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal Monto { get { return row.MONTO; } set { row.MONTO = value; } }
        public string Observacion { get { return GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal TextoPredefinidoId { get { return row.TEXTO_PREDEFINIDO_ID; } set { row.TEXTO_PREDEFINIDO_ID = value; } }
        public decimal TipoTextoPredefinidoId { get { return row.TIPO_TEXTO_PREDEFINIDO_ID; } set { row.TIPO_TEXTO_PREDEFINIDO_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CreditosService _credito;
        public CreditosService Credito
        {
            get
            {
                if (this._credito == null)
                    this._credito= new CreditosService(this.CreditoId);
                return this._credito;
            }
        }

        private TextosPredefinidosService _texto_predefinido;
        public TextosPredefinidosService TextoPredefinido
        {
            get
            {
                if (this._texto_predefinido == null)
                    this._texto_predefinido = new TextosPredefinidosService(this.TextoPredefinidoId);
                return this._texto_predefinido;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CREDITOS_DETALLESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CREDITOS_DETALLESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CREDITOS_DETALLESRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CreditosDetallesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CreditosDetallesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CreditosDetallesService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private CreditosDetallesService(CREDITOS_DETALLESRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

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
            this._credito = null;
            this._texto_predefinido = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();

            if (!this.ExisteEnDB)
            {
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                sesion.db.CREDITOS_DETALLESCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
            }
            else
            {
                sesion.db.CREDITOS_DETALLESCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.rowSinModificar.ToString(), this.row.ToString(), sesion);
            }

            if (this.TipoTextoPredefinidoId == Definiciones.TipoTextoPredefinido.CreditosTiposIngreso)
                this.Credito.TotalIngresos += this.Monto;
            else if (this.TipoTextoPredefinidoId == Definiciones.TipoTextoPredefinido.CreditosTiposEgreso)
                this.Credito.TotalEgresos += this.Monto;
            else
                throw new Exception("CreditosDetalleService.Guardar(). Tipo de texto predefinido no implementado.");
            this.Credito.Guardar();

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
                if (this.TipoTextoPredefinidoId == Definiciones.TipoTextoPredefinido.CreditosTiposIngreso)
                    this.Credito.TotalIngresos -= this.Monto;
                else if (this.TipoTextoPredefinidoId == Definiciones.TipoTextoPredefinido.CreditosTiposEgreso)
                    this.Credito.TotalEgresos -= this.Monto;
                else
                    throw new Exception("CreditosDetalleService.Borrar(). Tipo de texto predefinido no implementado.");
                this.Credito.Guardar();

                if(this.ExisteEnDB)
                    sesion.db.CREDITOS_DETALLESCollection.DeleteByPrimaryKey(this.Id.Value);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroBorrado, this.rowSinModificar.ToString(), sesion);
            }
            catch
            {
                throw;
            }
        }
        #endregion Borrar

        #region Buscar
        protected override CreditosDetallesService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append(" 1=1 ");

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
                        case Modelo.IDColumnName:
                        case Modelo.TEXTO_PREDEFINIDO_IDColumnName:
                        case Modelo.TIPO_TEXTO_PREDEFINIDO_IDColumnName:
                            sb.Append(f.Columna + " = " + f.Valor);
                            break;
                        case Modelo.MONTOColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            CREDITOS_DETALLESRow[] rows = sesion.db.CREDITOS_DETALLESCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            CreditosDetallesService[] cd = new CreditosDetallesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                cd[i] = new CreditosDetallesService(rows[i]);

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
        public static string Nombre_Tabla = "CREDITOS_DETALLES";
        public static string Nombre_Secuencia = "CREDITOS_DETALLES_SQC";
        #endregion Accessors
    }
}
