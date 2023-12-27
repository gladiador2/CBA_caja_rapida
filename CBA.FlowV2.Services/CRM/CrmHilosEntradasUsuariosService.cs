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
    public class CrmHilosEntradasUsuariosService : ClaseCBA<CrmHilosEntradasUsuariosService>
    {
        #region Propiedades
        protected CRM_HILOS_ENTRADAS_USUARIOSRow row;
        protected CRM_HILOS_ENTRADAS_USUARIOSRow rowSinModificar;
        public class Modelo : CRM_HILOS_ENTRADAS_USUARIOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal CrmHiloEntradaId { get { return row.CRM_HILOS_ENTRADA_ID; } set { row.CRM_HILOS_ENTRADA_ID = value; } }
        public DateTime? FechaLectura { get { if (row.IsFECHA_LECTURANull) return null; else return row.FECHA_LECTURA; } set { if (value.HasValue) row.FECHA_LECTURA = value.Value; else row.IsFECHA_LECTURANull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal UsuarioId { get { return row.USUARIO_ID; } private set { row.USUARIO_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CrmHilosEntradasService _crm_hilo_entrada;
        public CrmHilosEntradasService CrmHiloEntrada
        {
            get
            {
                if (this._crm_hilo_entrada == null)
                {
                    if (this.sesion != null)
                        this._crm_hilo_entrada = new CrmHilosEntradasService(this.CrmHiloEntradaId, this.sesion);
                    else
                        this._crm_hilo_entrada = new CrmHilosEntradasService(this.CrmHiloEntradaId);
                }
                return this._crm_hilo_entrada;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CRM_HILOS_ENTRADAS_USUARIOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CRM_HILOS_ENTRADAS_USUARIOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CRM_HILOS_ENTRADAS_USUARIOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CrmHilosEntradasUsuariosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CrmHilosEntradasUsuariosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CrmHilosEntradasUsuariosService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        
        private CrmHilosEntradasUsuariosService(CRM_HILOS_ENTRADAS_USUARIOSRow row)
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
                sesion.db.CRM_HILOS_ENTRADAS_USUARIOSCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.CRM_HILOS_ENTRADAS_USUARIOSCollection.Update(this.row);
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
            this._crm_hilo_entrada = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override CrmHilosEntradasUsuariosService[] Buscar(Filtro[] filtros)
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
                        case Modelo.CRM_HILOS_ENTRADA_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.USUARIO_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.FECHA_LECTURAColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            var rows = sesion.db.CRM_HILOS_ENTRADAS_USUARIOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            CrmHilosEntradasUsuariosService[] cheu = new CrmHilosEntradasUsuariosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                cheu[i] = new CrmHilosEntradasUsuariosService(rows[i]);

            return cheu;
        }
        #endregion Buscar

        #region GetPorEntrada
        public static CrmHilosEntradasUsuariosService GetPorEntrada(CrmHilosEntradasService entrada)
        {
            using(SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    var cheu = GetPorEntrada(entrada, sesion);
                    sesion.CommitTransaction();
                    return cheu;
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public static CrmHilosEntradasUsuariosService GetPorEntrada(CrmHilosEntradasService entrada, SessionService sesion)
        {
            var f = new Filtro[]
            {
                new Filtro { Columna = Modelo.CRM_HILOS_ENTRADA_IDColumnName, Valor  = entrada.Id.Value },
                new Filtro { Columna = Modelo.USUARIO_IDColumnName, Valor = sesion.Usuario.ID }
            };

            var cheu = entrada.GetPrimero<CrmHilosEntradasUsuariosService>(f);
            if (cheu == null)
                cheu = new CrmHilosEntradasUsuariosService();

            if (!cheu.ExisteEnDB)
            {
                cheu.IniciarUsingSesion(sesion);
                cheu.CrmHiloEntradaId = entrada.Id.Value;
                cheu.UsuarioId = sesion.Usuario.ID;
                cheu.Guardar();
                cheu.FinalizarUsingSesion();
            }
            
            return cheu;
        }
        #endregion GetPorEntrada

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
        public static string Nombre_Tabla = "CRM_HILOS_ENTRADAS_USUARIOS";
        public static string Nombre_Secuencia = "CRM_HILOS_ENTRADAS_USUARIO_SQC";
        #endregion Accessors
    }
}
