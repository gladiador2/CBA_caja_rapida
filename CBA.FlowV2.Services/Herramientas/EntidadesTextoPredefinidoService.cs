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
using CBA.FlowV2.Services.TextosPredefinidos;
#endregion Using

namespace CBA.FlowV2.Services.Articulos
{
    public class EntidadesTextoPredefinidoService : ClaseCBA<EntidadesTextoPredefinidoService>
    {
        #region Propiedades
        protected ENTIDADES_TEXTO_PREDEFINIDORow row;
        protected ENTIDADES_TEXTO_PREDEFINIDORow rowSinModificar;
        public class Modelo : ENTIDADES_TEXTO_PREDEFINIDOCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime FechaAsignacion { get { return row.FECHA_ASIGNACION; } set { row.FECHA_ASIGNACION = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal RegistroId { get { return row.REGISTRO_ID; } private set { row.REGISTRO_ID = value; } }
        public string TablaId { get { return row.TABLA_ID; } private set { row.TABLA_ID = value; } }
        public decimal TextoPredefinidoId { get { return row.TEXTO_PREDEFINIDO_ID; } private set { row.TEXTO_PREDEFINIDO_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
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
                this.row = sesion.db.ENTIDADES_TEXTO_PREDEFINIDOCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ENTIDADES_TEXTO_PREDEFINIDORow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(ENTIDADES_TEXTO_PREDEFINIDORow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public EntidadesTextoPredefinidoService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public EntidadesTextoPredefinidoService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public EntidadesTextoPredefinidoService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private EntidadesTextoPredefinidoService(ENTIDADES_TEXTO_PREDEFINIDORow row)
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
                sesion.db.ENTIDADES_TEXTO_PREDEFINIDOCollection.Insert(this.row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.ENTIDADES_TEXTO_PREDEFINIDOCollection.Update(this.row);
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
            this._texto_predefinido = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override EntidadesTextoPredefinidoService[] Buscar(Filtro[] filtros)
        {
            //Debe existir el filtro de caso, o el conjunto tabla y registro
            Filtro fTabla, fRegistro;
            string clausulas = string.Empty;

            fTabla = Array.Find(filtros, delegate(Filtro filtro) { return filtro.Columna == Modelo.TABLA_IDColumnName; });
            fRegistro = Array.Find(filtros, delegate(Filtro filtro) { return filtro.Columna == Modelo.REGISTRO_IDColumnName; });
            if (fTabla == null || fRegistro == null)
                throw new Exception(this.GetType().ToString() +  ".Buscar(). Debe filtrar por caso, o bien por tabla y registro.");

            clausulas = Modelo.TABLA_IDColumnName + " = '" + fTabla.Valor + "' and " +
                        Modelo.REGISTRO_IDColumnName + " = " + fRegistro.Valor + " and " +
                        Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'";

            ENTIDADES_TEXTO_PREDEFINIDORow[] rows = sesion.db.ENTIDADES_TEXTO_PREDEFINIDOCollection.GetAsArray(clausulas, Modelo.IDColumnName);
            EntidadesTextoPredefinidoService[] etp = new EntidadesTextoPredefinidoService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                etp[i] = new EntidadesTextoPredefinidoService(rows[i]);

            return etp;
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
        public static string Nombre_Tabla
        {
            get { return "ENTIDADES_TEXTO_PREDEFINIDO"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "ENTIDADES_TEXTO_PREDEF_SQC"; }
        }
        #endregion Accessors
    }
}
