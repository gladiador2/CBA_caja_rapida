#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;

using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.CRM
{
    public class CrmHilosUsuariosService : ClaseCBA<CrmHilosUsuariosService>
    {
        #region Propiedades
        protected CRM_HILOS_USUARIOSRow row;
        protected CRM_HILOS_USUARIOSRow rowSinModificar;
        public class Modelo : CRM_HILOS_USUARIOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal CrmHiloId { get { return row.CRM_HILO_ID; } set { row.CRM_HILO_ID = value; } }
        public string Destacado { get { return row.DESTACADO; } set { row.DESTACADO = value; } }
        public DateTime? FechaArchivado { get { if (row.IsFECHA_ARCHIVADONull) return null; else return row.FECHA_ARCHIVADO; } set { if (value.HasValue) row.FECHA_ARCHIVADO = value.Value; else row.IsFECHA_ARCHIVADONull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal UsuarioId { get { return row.USUARIO_ID; } set { row.USUARIO_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CrmHilosService _crm_hilo;
        public CrmHilosService CrmHilo
        {
            get
            {
                if (this._crm_hilo == null)
                {
                    if (this.sesion != null)
                        this._crm_hilo = new CrmHilosService(this.CrmHiloId, this.sesion);
                    else
                        this._crm_hilo = new CrmHilosService(this.CrmHiloId);
                }
                return this._crm_hilo;
            }
        }

        private UsuariosService _usuario;
        public UsuariosService Usuario
        {
            get
            {
                if (this._usuario == null)
                {
                    if (this.sesion != null)
                        this._usuario = new UsuariosService(this.UsuarioId, this.sesion);
                    else
                        this._usuario = new UsuariosService(this.UsuarioId);
                }
                return this._usuario;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CRM_HILOS_USUARIOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CRM_HILOS_USUARIOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CRM_HILOS_USUARIOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CrmHilosUsuariosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CrmHilosUsuariosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CrmHilosUsuariosService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        public CrmHilosUsuariosService(CRM_HILOS_USUARIOSRow row)
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
                sesion.db.CRM_HILOS_USUARIOSCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.CRM_HILOS_USUARIOSCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), this.rowSinModificar.ToString(), sesion);
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
            this._crm_hilo = null;
            this._usuario = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override CrmHilosUsuariosService[] Buscar(Filtro[] filtros)
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
                        case Modelo.DESTACADOColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case Modelo.CRM_HILO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.USUARIO_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.FECHA_ARCHIVADOColumnName:
                            if(f.Exacto)
                                sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            else
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            var rows = sesion.db.CRM_HILOS_USUARIOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            CrmHilosUsuariosService[] chu = new CrmHilosUsuariosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                chu[i] = new CrmHilosUsuariosService(rows[i]);

            return chu;
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
        public static string Nombre_Tabla = "CRM_HILOS_USUARIOS";
        public static string Nombre_Secuencia = "CRM_HILOS_USUARIOS_SQC";
        #endregion Accessors
    }
}
