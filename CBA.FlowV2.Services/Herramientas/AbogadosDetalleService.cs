#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;

using System.Collections.Generic;
using System.Text;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class AbogadosDetalleService : ClaseCBA<AbogadosDetalleService>
    {
        #region FiltrosExtension
        public static class FiltroExtension
        {
            public const string Nombres = "_NOMBRES_";
        }
        #endregion FiltrosExtension

        #region Propiedades
        protected ABOGADOS_DETRow row;
        protected ABOGADOS_DETRow rowSinModificar;
        public class Modelo : ABOGADOS_DETCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal AbogadoId { get { return row.ABOGADO_ID; } set { row.ABOGADO_ID = value; } }
        public string Email { get { return GetStringHelper(row.EMAIL); } set { row.EMAIL = value; } }
        public string Estado { get { return GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        public string Observacion { get { return GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal? PersonaId { get { if (row.IsPERSONA_IDNull) return null; else return row.PERSONA_ID; } set { if (value.HasValue) row.PERSONA_ID = value.Value; else row.IsPERSONA_IDNull = true; } }
        public decimal? ProveedorId { get { if (row.IsPROVEEDOR_IDNull) return null; else return row.PROVEEDOR_ID; } set { if (value.HasValue) row.PROVEEDOR_ID = value.Value; else row.IsPROVEEDOR_IDNull = true; } }
        public string Telefono { get { return GetStringHelper(row.TELEFONO); } set { row.TELEFONO = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private AbogadosService _abogado;
        public AbogadosService Abogado
        {
            get
            {
                if (this._persona == null)
                {
                    if (this.sesion != null)
                        this._abogado = new AbogadosService(this.AbogadoId, this.sesion);
                    else
                        this._abogado = new AbogadosService(this.AbogadoId);
                }
                return this._abogado;
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

        private ProveedoresService _proveedor;
        public ProveedoresService Proveedor
        {
            get
            {
                if (this._proveedor == null)
                {
                    if (this.sesion != null)
                        this._proveedor = new ProveedoresService(this.ProveedorId.Value, this.sesion);
                    else
                        this._proveedor = new ProveedoresService(this.ProveedorId.Value);
                }
                return this._proveedor;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.ABOGADOS_DETCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ABOGADOS_DETRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true;
            
            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(ABOGADOS_DETRow row)
        {
            this.AlmacenarLocalmente = true;
            this.row = row;
            
            this.rowSinModificar = this.row.Clonar();
        }

        public AbogadosDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public AbogadosDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public AbogadosDetalleService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private AbogadosDetalleService(ABOGADOS_DETRow row)
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
                this.row.ID = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.Estado = Definiciones.Estado.Activo;
                sesion.db.ABOGADOS_DETCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
            }
            else
            {
                sesion.db.ABOGADOS_DETCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.rowSinModificar.ToString(), this.row.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();

            return this.row.ID;
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
            this._abogado = null;
            this._persona = null;
            this._proveedor = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override AbogadosDetalleService[] Buscar(Filtro[] filtros)
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
                        case Modelo.ABOGADO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.PERSONA_IDColumnName:
                        case Modelo.PROVEEDOR_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.EMAILColumnName:
                        case Modelo.NOMBREColumnName:
                        case Modelo.OBSERVACIONColumnName:
                        case Modelo.TELEFONOColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case FiltroExtension.Nombres:
                            string valor = f.Valor.ToString().Trim().ToUpper();
                            if (f.Exacto)
                            {
                                sb.Append("(" +
                                          "upper(" + Modelo.NOMBREColumnName + ") " + f.Comparacion + " '" + valor + "' or " +
                                          "(" + Modelo.PERSONA_IDColumnName + " is not null and exists(select p.id from " + PersonasService.Nombre_Tabla + " p where p." + PersonasService.Id_NombreCol + " = " + Nombre_Tabla + "." + Modelo.PERSONA_IDColumnName + " and p." + PersonasService.NombreCompleto_NombreCol + " " + f.Comparacion + " '" + valor + "')) or " +
                                          "(" + Modelo.PROVEEDOR_IDColumnName + " is not null and exists(select p.id from " + ProveedoresService.Nombre_Tabla + " p where p." + ProveedoresService.Id_NombreCol + " = " + Nombre_Tabla + "." + Modelo.PROVEEDOR_IDColumnName + " and p." + ProveedoresService.RazonSocial_NombreCol+ " " + f.Comparacion + " '" + valor + "')) " +
                                          ")");
                            }
                            else
                            {
                                sb.Append("(" +
                                          "upper(" + Modelo.NOMBREColumnName + ") like '%" + valor + "%' or " +
                                          "(" + Modelo.PERSONA_IDColumnName + " is not null and exists(select p.id from " + PersonasService.Nombre_Tabla + " p where p." + PersonasService.Id_NombreCol + " = " + Nombre_Tabla + "." + Modelo.PERSONA_IDColumnName + " and p." + PersonasService.NombreCompleto_NombreCol + " like '%" + valor + "%')) or " +
                                          "(" + Modelo.PROVEEDOR_IDColumnName + " is not null and exists(select p.id from " + ProveedoresService.Nombre_Tabla + " p where p." + ProveedoresService.Id_NombreCol + " = " + Nombre_Tabla + "." + Modelo.PROVEEDOR_IDColumnName + " and p." + ProveedoresService.RazonSocial_NombreCol + " like '%" + valor + "%')) " +
                                          ")");
                            }
                            break; 
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.NOMBREColumnName);
            ABOGADOS_DETRow[] rows = sesion.db.ABOGADOS_DETCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            AbogadosDetalleService[] ad = new AbogadosDetalleService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                ad[i] = new AbogadosDetalleService(rows[i]);

            return ad;
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
        public static string Nombre_Tabla = "ABOGADOS_DET";
        public static string Nombre_Secuencia = "ABOGADOS_DET_SQC";
        #endregion Accessors
    }
}
