#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;

using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteCajaReservasService : ClaseCBA<CuentaCorrienteCajaReservasService>
    {
        #region FiltrosExtension
        public static class FiltroExtension
        {
            public const string SucursalId = CTACTE_CAJAS_SUCURSALCollection.SUCURSAL_IDColumnName;
            public const string FuncionarioId = CTACTE_CAJAS_SUCURSALCollection.FUNCIONARIO_IDColumnName;
            public const string CtacteCajaSucursalEstadoId = CTACTE_CAJAS_SUCURSALCollection.CTACTE_CAJA_SUCURSAL_ESTADO_IDColumnName;
        }
        #endregion FiltrosExtension

        #region Permisos
        public Permiso Permisos = new Permiso();
        public class Permiso
        {
            private bool? _reservar;
            public bool Reservar { get { if (this._reservar == null) this._reservar = RolesService.Tiene("CTACTE CAJAS SUCURSAL RESERVAS RESERVAR"); return this._reservar.Value; } }

            private bool? _desreservar;
            public bool Desreservar { get { if (this._desreservar == null) this._desreservar = RolesService.Tiene("CTACTE CAJAS SUCURSAL RESERVAS DESRESERVAR"); return this._desreservar.Value; } }
        }
        #endregion Permisos

        #region Propiedades
        protected CTACTE_CAJA_RESERVASRow row;
        protected CTACTE_CAJA_RESERVASRow rowSinModificar;
        public class Modelo : CTACTE_CAJA_RESERVASCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal CtacteCajaSucursalOrigenId { get { return row.CTACTE_CAJA_SUCURSAL_ORIGEN_ID; } set { row.CTACTE_CAJA_SUCURSAL_ORIGEN_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CuentaCorrienteCajasSucursalService _ctacte_caja_sucursal_origen;
        public CuentaCorrienteCajasSucursalService CtacteCajasSucursalOrigen
        {
            get
            {
                if (this._ctacte_caja_sucursal_origen == null)
                {
                    if (this.sesion != null)
                    {
                        this._ctacte_caja_sucursal_origen = new CuentaCorrienteCajasSucursalService(this.CtacteCajaSucursalOrigenId, this.sesion);
                    }
                    else
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._ctacte_caja_sucursal_origen = new CuentaCorrienteCajasSucursalService(this.CtacteCajaSucursalOrigenId, sesion);                        
                        }
                    }
                }
                return this._ctacte_caja_sucursal_origen;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                    this._moneda = this.Get<MonedasService>(this.MonedaId);
                return this._moneda;
            }
        }

        public decimal Saldo
        {
            get
            {
                decimal total = 0;
                foreach (var d in this.Detalles)
                    total += d.Monto;
                return total;
            }
        }
        #endregion Propiedades Extendidas

        #region Propiedades OneToMany
        private CuentaCorrienteCajaReservasDetalleService[] _detalles;
        public CuentaCorrienteCajaReservasDetalleService[] Detalles
        {
            get
            {
                if (this._detalles == null)
                    this._detalles = this.GetFiltrado<CuentaCorrienteCajaReservasDetalleService>(new Filtro { Columna = CuentaCorrienteCajaReservasDetalleService.Modelo.CTACTE_CAJA_RESERVA_IDColumnName, Valor = this.Id.Value });
                return this._detalles;
            }
        }
        #endregion Propiedades OneToMany

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_CAJA_RESERVASCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_CAJA_RESERVASRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CTACTE_CAJA_RESERVASRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CuentaCorrienteCajaReservasService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrienteCajaReservasService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        internal CuentaCorrienteCajaReservasService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        internal CuentaCorrienteCajaReservasService(CTACTE_CAJA_RESERVASRow row)
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
                this.Estado = Definiciones.Estado.Activo;
                sesion.db.CTACTE_CAJA_RESERVASCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.CTACTE_CAJA_RESERVASCollection.Update(this.row);
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
            this._moneda = null;
            this._ctacte_caja_sucursal_origen = null;

            this._detalles = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Borrar
        public void Borrar()
        {
            this.Estado = Definiciones.Estado.Inactivo;
            this.Guardar();
        }
        #endregion Borrar

        #region Buscar
        protected override CuentaCorrienteCajaReservasService[] Buscar(Filtro[] filtros)
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
                        case Modelo.CTACTE_CAJA_SUCURSAL_ORIGEN_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.MONEDA_IDColumnName:
                            sb.Append(f.Columna + " = " + f.Valor);
                            break;
                        case Modelo.ESTADOColumnName:
                            sb.Append(f.Columna + " = '" + f.Valor.ToString().ToUpper() + "'");
                            break;
                        case Modelo.OBSERVACIONColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case Modelo.FECHAColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        case FiltroExtension.FuncionarioId:
                        case FiltroExtension.SucursalId:
                            sb.Append(" exists(select * from " + CuentaCorrienteCajasSucursalService.Nombre_Tabla + " a " +
                                         "         where a." + CuentaCorrienteCajasSucursalService.Id_NombreCol + " = " + Nombre_Tabla + "." + Modelo.CTACTE_CAJA_SUCURSAL_ORIGEN_IDColumnName +
                                         "           and a." + f.Columna + " = " + f.Valor + ") ");
                            break;
                        case FiltroExtension.CtacteCajaSucursalEstadoId:
                            sb.Append(" exists(select * from " + CuentaCorrienteCajasSucursalService.Nombre_Tabla + " a " +
                                         "         where a." + CuentaCorrienteCajasSucursalService.Id_NombreCol + " = " + Nombre_Tabla + "." + Modelo.CTACTE_CAJA_SUCURSAL_ORIGEN_IDColumnName +
                                         "           and a." + f.Columna + " = '" + f.Valor + "') ");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.FECHAColumnName);
            orden.Add(Modelo.IDColumnName);
            CTACTE_CAJA_RESERVASRow[] rows = sesion.db.CTACTE_CAJA_RESERVASCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            CuentaCorrienteCajaReservasService[] ccr = new CuentaCorrienteCajaReservasService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                ccr[i] = new CuentaCorrienteCajaReservasService(rows[i]);

            return ccr;
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

        #region TransladarANuevaCaja
        public static void TransladarANuevaCaja(decimal ctacte_caja_sucursal_id, SessionService sesion)
        {
            CuentaCorrienteCajaReservasService transladoReserva = null;

            try
            {
                DataTable dtCaja = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalDataTable2(CuentaCorrienteCajasSucursalService.Id_NombreCol + " = " + ctacte_caja_sucursal_id, string.Empty, sesion);
                if (Interprete.EsNullODBNull(dtCaja.Rows[0][CuentaCorrienteCajasSucursalService.CtacteCajaSucAnteriorId_NombreCol]))
                    return;

                var reservas = CuentaCorrienteCajaReservasService.Instancia.GetFiltrado<CuentaCorrienteCajaReservasService>(new ClaseCBABase.Filtro[]
                {
                    new ClaseCBABase.Filtro { Columna = CuentaCorrienteCajaReservasService.Modelo.CTACTE_CAJA_SUCURSAL_ORIGEN_IDColumnName, Valor = dtCaja.Rows[0][CuentaCorrienteCajasSucursalService.CtacteCajaSucAnteriorId_NombreCol] },
                    new ClaseCBABase.Filtro { Columna = CuentaCorrienteCajaReservasService.Modelo.ESTADOColumnName, Valor = Definiciones.Estado.Activo }
                });

                foreach (var r in reservas)
                {
                    if (r.Saldo <= 0)
                        continue;

                    transladoReserva = new CuentaCorrienteCajaReservasService
                    {
                        CtacteCajaSucursalOrigenId = ctacte_caja_sucursal_id,
                        Fecha = (DateTime)dtCaja.Rows[0][CuentaCorrienteCajasSucursalService.FechaInicio_NombreCol],
                        MonedaId = r.MonedaId,
                        Observacion = r.Observacion
                    };

                    transladoReserva.IniciarUsingSesion(sesion);
                    transladoReserva.Guardar();
                    CuentaCorrienteCajaReservasDetalleService.TransladarSaldo(transladoReserva, r.Saldo , sesion);
                    transladoReserva.FinalizarUsingSesion();
                }
            }
            catch
            {
                transladoReserva.FinalizarUsingSesion();
                throw;
            }
        }
        #endregion TransladarANuevaCaja

        #region Accessors
        public static string Nombre_Tabla = "CTACTE_CAJA_RESERVAS";
        public static string Nombre_Secuencia = "CTACTE_CAJA_RESERVAS_SQC";
        #endregion Accessors
    }
}
