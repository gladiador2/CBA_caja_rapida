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
    public class AbogadosService : ClaseCBA<AbogadosService>
    {
        #region FiltrosExtension
        public static class FiltroExtension
        {
            public const string Nombres = "_NOMBRES_";
        }
        #endregion FiltrosExtension

        #region Propiedades
        protected ABOGADOSRow row;
        protected ABOGADOSRow rowSinModificar;
        public class Modelo : ABOGADOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Apellido { get { return GetStringHelper(row.APELLIDO); } set { row.APELLIDO = value; } }
        public decimal? BarrioId { get { if (row.IsBARRIO_IDNull) return null; else return row.BARRIO_ID; } set { if (value.HasValue) row.BARRIO_ID = value.Value; else row.IsBARRIO_IDNull = true; } }
        public string Calle { get { return GetStringHelper(row.CALLE); } set { row.CALLE = value; } }
        public decimal? CiudadId { get { if (row.IsCIUDAD_IDNull) return null; else return row.CIUDAD_ID; } set { if (value.HasValue) row.CIUDAD_ID = value.Value; else row.IsCIUDAD_IDNull = true; } }
        public string CodigoPostal { get { return GetStringHelper(row.CODIGO_POSTAL); } set { row.CODIGO_POSTAL = value; } }
        public decimal? DepartamentoId { get { if (row.IsDEPARTAMENTO_IDNull) return null; else return row.DEPARTAMENTO_ID; } set { if (value.HasValue) row.DEPARTAMENTO_ID = value.Value; else row.IsDEPARTAMENTO_IDNull = true; } }
        public string EmailContacto { get { return GetStringHelper(row.EMAIL_CONTACTO); } set { row.EMAIL_CONTACTO = value; } }
        public string Email1 { get { return GetStringHelper(row.EMAIL1); } set { row.EMAIL1 = value; } }
        public string Email2 { get { return GetStringHelper(row.EMAIL2); } set { row.EMAIL2 = value; } }
        public string Email3 { get { return GetStringHelper(row.EMAIL3); } set { row.EMAIL3 = value; } }
        public decimal EntidadId { get { return row.ENTIDAD_ID; } set { row.ENTIDAD_ID = value; } }
        public string Estado { get { return GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        public string NombreContacto { get { return GetStringHelper(row.NOMBRE_CONTACTO); } set { row.NOMBRE_CONTACTO = value; } }
        public string NombreEstudio { get { return GetStringHelper(row.NOMBRE_ESTUDIO); } set { row.NOMBRE_ESTUDIO = value; } }
        public decimal? PaisId { get { if (row.IsPAIS_IDNull) return null; else return row.PAIS_ID; } set { if (value.HasValue) row.PAIS_ID = value.Value; else row.IsPAIS_IDNull = true; } }
        public string Ruc { get { return GetStringHelper(row.RUC); } set { row.RUC = value; } }
        public string TelefonoContacto { get { return GetStringHelper(row.TELEFONO_CONTACTO); } set { row.TELEFONO_CONTACTO = value; } }
        public string Telefono1 { get { return GetStringHelper(row.TELEFONO1); } set { row.TELEFONO1 = value; } }
        public string Telefono2 { get { return GetStringHelper(row.TELEFONO2); } set { row.TELEFONO2 = value; } }
        public string Telefono3 { get { return GetStringHelper(row.TELEFONO3); } set { row.TELEFONO3 = value; } }
        public string Telefono4 { get { return GetStringHelper(row.TELEFONO4); } set { row.TELEFONO4 = value; } }
        #endregion Propiedades

        #region Permisos
        public Permiso Permisos = new Permiso();
        public class Permiso
        {
            private bool? _abogadosEditar;
            public bool AbogadosEditar { get { if (this._abogadosEditar == null) this._abogadosEditar = RolesService.Tiene("ABOGADOS EDITAR"); return this._abogadosEditar.Value; } }
            private bool? _abogadosVer;
            public bool AbogadosVer { get { if (this._abogadosVer == null) this._abogadosVer = RolesService.Tiene("ABOGADOS VER"); return this._abogadosVer.Value; } }

            private bool? _puedeCrearComentarioPublico;
            public bool PuedeCrearComentarioPublico { get { if (this._puedeCrearComentarioPublico == null) this._puedeCrearComentarioPublico = RolesService.Tiene("comentarios casos crear publico abogados"); return this._puedeCrearComentarioPublico.Value; } }
            private bool? _puedeCrearComentarioPrivado;
            public bool PuedeCrearComentarioPrivado { get { if (this._puedeCrearComentarioPrivado == null) this._puedeCrearComentarioPrivado = RolesService.Tiene("comentarios casos crear privado abogados"); return this._puedeCrearComentarioPrivado.Value; } }
            private bool? _puedeVerComentarioPublico;
            public bool PuedeVerComentarioPublico { get { if (this._puedeVerComentarioPublico == null) this._puedeVerComentarioPublico = RolesService.Tiene("comentarios casos ver publico abogados"); return this._puedeVerComentarioPublico.Value; } }
            private bool? _puedeVerComentarioPrivado;
            public bool PuedeVerComentarioPrivado { get { if (this._puedeVerComentarioPrivado == null) this._puedeVerComentarioPrivado = RolesService.Tiene("comentarios casos ver privado abogados"); return this._puedeVerComentarioPrivado.Value; } }
            private bool? _puedeBorrarComentarioPublico;
            public bool PuedeBorrarComentarioPublico { get { if (this._puedeBorrarComentarioPublico == null) this._puedeBorrarComentarioPublico = RolesService.Tiene("comentarios casos borrar publico abogados"); return this._puedeBorrarComentarioPublico.Value; } }
            private bool? _puedeBorrarComentarioPrivado;
            public bool PuedeBorrarComentarioPrivado { get { if (this._puedeBorrarComentarioPrivado == null) this._puedeBorrarComentarioPrivado = RolesService.Tiene("comentarios casos borrar privado abogados"); return this._puedeBorrarComentarioPrivado.Value; } }
        }
        #endregion Permisos

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.ABOGADOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ABOGADOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true;
            
            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(ABOGADOSRow row)
        {
            this.AlmacenarLocalmente = true;
            this.row = row;
            
            this.rowSinModificar = this.row.Clonar();
        }

        public AbogadosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public AbogadosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public AbogadosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private AbogadosService(ABOGADOSRow row)
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
                this.EntidadId = sesion.Usuario.ENTIDAD_ID;
                sesion.db.ABOGADOSCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
            }
            else
            {
                sesion.db.ABOGADOSCollection.Update(this.row);
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

            if (!this.Permisos.AbogadosEditar)
                excepciones.Agregar("No tiene permisos para guardar.", null);

            if (this.row.NOMBRE.Length <= 0)
                excepciones.Agregar("Debe indicar el nombre.", null);

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
        protected override AbogadosService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            bool filtroEstado = false;
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
                        case Modelo.BARRIO_IDColumnName:
                        case Modelo.CIUDAD_IDColumnName:
                        case Modelo.DEPARTAMENTO_IDColumnName:
                        case Modelo.ENTIDAD_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.PAIS_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.APELLIDOColumnName:
                        case Modelo.CALLEColumnName:
                        case Modelo.CODIGO_POSTALColumnName:
                        case Modelo.EMAIL_CONTACTOColumnName:
                        case Modelo.EMAIL1ColumnName:
                        case Modelo.EMAIL2ColumnName:
                        case Modelo.EMAIL3ColumnName:
                        case Modelo.NOMBRE_CONTACTOColumnName:
                        case Modelo.NOMBRE_ESTUDIOColumnName:
                        case Modelo.NOMBREColumnName:
                        case Modelo.RUCColumnName:
                        case Modelo.TELEFONO_CONTACTOColumnName:
                        case Modelo.TELEFONO1ColumnName:
                        case Modelo.TELEFONO2ColumnName:
                        case Modelo.TELEFONO3ColumnName:
                        case Modelo.TELEFONO4ColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case Modelo.ESTADOColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            else
                                sb.Append(f.Columna + " in ('" + string.Join("','", Array.ConvertAll((string[])f.Valor, i => i.ToString())) + "')");
                            filtroEstado = true;
                            break;
                        case FiltroExtension.Nombres:
                            string valor = f.Valor.ToString().Trim().ToUpper();
                            if (f.Exacto)
                            {
                                sb.Append("(" +
                                          "upper(" + Modelo.NOMBREColumnName + ") " + f.Comparacion + " '" + valor + "' or " +
                                          "upper(" + Modelo.APELLIDOColumnName + ") " + f.Comparacion + " '" + valor + "' or " +
                                          "upper(" + Modelo.NOMBRE_ESTUDIOColumnName + ") " + f.Comparacion + " '" + valor + "' or " +
                                          "upper(" + Modelo.NOMBRE_CONTACTOColumnName + ") " + f.Comparacion + " '" + valor + "'" +
                                          ")");
                            }
                            else
                            {
                                sb.Append("(" +
                                          "upper(" + Modelo.NOMBREColumnName + ") like '%" + valor + "%' or " +
                                          "upper(" + Modelo.APELLIDOColumnName + ") like '%" + valor + "%' or " +
                                          "upper(" + Modelo.NOMBRE_ESTUDIOColumnName + ") like '%" + valor + "%' or " +
                                          "upper(" + Modelo.NOMBRE_CONTACTOColumnName + ") like '%" + valor + "%'" +
                                          ")");
                            }
                            break; 
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            if (!filtroEstado)
                sb.Append(" and " + Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'");

            orden.Add(Modelo.NOMBREColumnName);
            ABOGADOSRow[] rows = sesion.db.ABOGADOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            AbogadosService[] a = new AbogadosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                a[i] = new AbogadosService(rows[i]);

            return a;
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
        public static string Nombre_Tabla = "ABOGADOS";
        public static string Nombre_Secuencia = "ABOGADOS_SQC";
        #endregion Accessors
    }
}
