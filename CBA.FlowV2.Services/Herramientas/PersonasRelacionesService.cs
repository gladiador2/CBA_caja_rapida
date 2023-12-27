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

namespace CBA.FlowV2.Services.Herramientas
{
    public class PersonasRelacionesService : ClaseCBA<PersonasRelacionesService>
    {
        #region Propiedades
        protected PERSONAS_RELACIONESRow row;
        protected PERSONAS_RELACIONESRow rowSinModificar;
        public class Modelo : PERSONAS_RELACIONESCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal PersonaId { get { return row.PERSONA_ID; } set { row.PERSONA_ID = value; } }
        public decimal PersonaRelacionadaId { get { return row.PERSONA_RELACIONADA_ID; } set { row.PERSONA_RELACIONADA_ID = value; } }
        public decimal TipoRelacionPersonaId { get { return row.TIPO_RELACION_PERSONA_ID; } set { row.TIPO_RELACION_PERSONA_ID = value; } }
        #endregion Propiedades

        #region Propiedades extendidas
        private PersonasService _persona;
        public PersonasService Persona
        {
            get
            {
                if (this._persona == null)
                    this._persona = new PersonasService(this.PersonaId);
                return this._persona;
            }

        }

        private PersonasService _persona_relacionada;
        public PersonasService PersonaRelacionada
        {
            get
            {
                if (this._persona_relacionada == null)
                    this._persona_relacionada = new PersonasService(this.PersonaRelacionadaId);
                return this._persona_relacionada;
            }

        }

        private TiposRelacionesPersonasService _tipo_relacion;
        public TiposRelacionesPersonasService TipoRelacion
        {
            get
            {
                if (this._tipo_relacion == null)
                    this._tipo_relacion = new TiposRelacionesPersonasService(this.TipoRelacionPersonaId);
                return this._tipo_relacion;
            }

        }
        #endregion Propiedades extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.PERSONAS_RELACIONESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new PERSONAS_RELACIONESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(PERSONAS_RELACIONESRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public PersonasRelacionesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public PersonasRelacionesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public PersonasRelacionesService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private PersonasRelacionesService(PERSONAS_RELACIONESRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            if (!RolesService.Tiene("PERSONAS RELACIONES EDITAR"))
                throw new Exception("No tiene permisos para editar");

            this.Validar();

            if (!this.ExisteEnDB)
            {
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.Estado = Definiciones.Estado.Activo;
                sesion.db.PERSONAS_RELACIONESCollection.Insert(this.row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.PERSONAS_RELACIONESCollection.Update(this.row);
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

            if (this.PersonaId == this.PersonaRelacionadaId)
                excepciones.Agregar("Las personas relacionadas no pueden ser la misma");

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._persona = null;
            this._persona_relacionada = null;
            this._tipo_relacion = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override PersonasRelacionesService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append(Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'");
            
            foreach (Filtro f in filtros)
            {
                if (f.OrderBy)
                    orden.Add(f.Columna);

                if (f.Valor.ToString().Length <= 0)
                    continue;

                sb.Append(" and ");
                switch (f.Columna)
                {
                    case Modelo.IDColumnName:
                    case Modelo.PERSONA_IDColumnName:
                    case Modelo.PERSONA_RELACIONADA_IDColumnName:
                    case Modelo.TIPO_RELACION_PERSONA_IDColumnName:
                        sb.Append(f.Columna + " = " + f.Valor);
                        break;
                    default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                }
            }

            orden.Add(Modelo.IDColumnName);
            PERSONAS_RELACIONESRow[] rows = sesion.db.PERSONAS_RELACIONESCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            PersonasRelacionesService[] pr = new PersonasRelacionesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                pr[i] = new PersonasRelacionesService(rows[i]);
            return pr;
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

        #region Accessors
        public static string Nombre_Tabla = "PERSONAS_RELACIONES";
        public static string Nombre_Secuencia = "PERSONAS_RELACIONES_SQC";
        #endregion Accessors
    }
}
