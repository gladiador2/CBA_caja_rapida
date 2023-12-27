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
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Articulos;
using System.Collections;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
    public class DevengamientosDetallesService : ClaseCBA<DevengamientosDetallesService>
    {
        #region Propiedades
        protected CTB_DEVENGAMIENTOS_DETRow row;
        protected CTB_DEVENGAMIENTOS_DETRow rowSinModificar;
        public class Modelo : CTB_DEVENGAMIENTOS_DETCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal ADevengarVencido { get { return row.A_DEVENGAR_VENCIDO; } set { row.A_DEVENGAR_VENCIDO = value; } }
        public decimal ADevengarVencidoAum { get { return row.A_DEVENGAR_VENCIDO_AUM; } set { row.A_DEVENGAR_VENCIDO_AUM = value; } }
        public decimal ADevengarVencidoDis { get { return row.A_DEVENGAR_VENCIDO_DIS; } set { row.A_DEVENGAR_VENCIDO_DIS = value; } }
        public decimal ADevengarVigente { get { return row.A_DEVENGAR_VIGENTE; } set { row.A_DEVENGAR_VIGENTE = value; } }
        public decimal ADevengarVigenteAum { get { return row.A_DEVENGAR_VIGENTE_AUM; } set { row.A_DEVENGAR_VIGENTE_AUM = value; } }
        public decimal ADevengarVigenteDis { get { return row.A_DEVENGAR_VIGENTE_DIS; } set { row.A_DEVENGAR_VIGENTE_DIS = value; } }
        public decimal CalendarioPagosCrPersId { get { return row.CALENDARIO_PAGOS_CR_PERS_ID; } set { row.CALENDARIO_PAGOS_CR_PERS_ID = value; } }
        public decimal CantidadDiasDevengados { get { return row.CANTIDAD_DIAS_DEVENGADOS; } set { row.CANTIDAD_DIAS_DEVENGADOS = value; } }
        public decimal CapitalACobrarVencido { get { return row.CAPITAL_A_COBRAR_VENCIDO; } set { row.CAPITAL_A_COBRAR_VENCIDO = value; } }
        public decimal CapitalACobrarVencidoAum { get { return row.CAPITAL_A_COBRAR_VENCIDO_AUM; } set { row.CAPITAL_A_COBRAR_VENCIDO_AUM = value; } }
        public decimal CapitalACobrarVencidoDis { get { return row.CAPITAL_A_COBRAR_VENCIDO_DIS; } set { row.CAPITAL_A_COBRAR_VENCIDO_DIS = value; } }
        public decimal CapitalACobrarVigente { get { return row.CAPITAL_A_COBRAR_VIGENTE; } set { row.CAPITAL_A_COBRAR_VIGENTE = value; } }
        public decimal CapitalACobrarVigenteAum { get { return row.CAPITAL_A_COBRAR_VIGENTE_AUM; } set { row.CAPITAL_A_COBRAR_VIGENTE_AUM = value; } }
        public decimal CapitalACobrarVigenteDis { get { return row.CAPITAL_A_COBRAR_VIGENTE_DIS; } set { row.CAPITAL_A_COBRAR_VIGENTE_DIS = value; } }
        public decimal CapitalVencidoCobrado { get { return row.CAPITAL_VENCIDO_COBRADO; } set { row.CAPITAL_VENCIDO_COBRADO = value; } }
        public decimal CtbDevengamientoId { get { return row.CTB_DEVENGAMIENTO_ID; } set { row.CTB_DEVENGAMIENTO_ID = value; } }
        public decimal Devengado { get { return row.DEVENGADO; } set { row.DEVENGADO = value; } }
        public decimal DevengadoAum { get { return row.DEVENGADO_AUM; } set { row.DEVENGADO_AUM = value; } }
        public decimal DevengadoDis { get { return row.DEVENGADO_DIS; } set { row.DEVENGADO_DIS = value; } }
        public decimal EnSuspenso { get { return row.EN_SUSPENSO; } set { row.EN_SUSPENSO = value; } }
        public decimal EnSuspensoAum { get { return row.EN_SUSPENSO_AUM; } set { row.EN_SUSPENSO_AUM = value; } }
        public decimal EnSuspensoDis { get { return row.EN_SUSPENSO_DIS; } set { row.EN_SUSPENSO_DIS = value; } }
        public string Estado { get { return GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal InteresACobrarVencido { get { return row.INTERES_A_COBRAR_VENCIDO; } set { row.INTERES_A_COBRAR_VENCIDO = value; } }
        public decimal InteresACobrarVencidoAum { get { return row.INTERES_A_COBRAR_VENCIDO_AUM; } set { row.INTERES_A_COBRAR_VENCIDO_AUM = value; } }
        public decimal InteresACobrarVencidoDis { get { return row.INTERES_A_COBRAR_VENCIDO_DIS; } set { row.INTERES_A_COBRAR_VENCIDO_DIS = value; } }
        public decimal InteresACobrarVigente { get { return row.INTERES_A_COBRAR_VIGENTE; } set { row.INTERES_A_COBRAR_VIGENTE = value; } }
        public decimal InteresACobrarVigenteAum { get { return row.INTERES_A_COBRAR_VIGENTE_AUM; } set { row.INTERES_A_COBRAR_VIGENTE_AUM = value; } }
        public decimal InteresACobrarVigenteDis { get { return row.INTERES_A_COBRAR_VIGENTE_DIS; } set { row.INTERES_A_COBRAR_VIGENTE_DIS = value; } }
        public decimal InteresVencidoCobrado { get { return row.INTERES_VENCIDO_COBRADO; } set { row.INTERES_VENCIDO_COBRADO = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CreditosService.CalendarioService _calendario_pagos_cr_pers;
        public CreditosService.CalendarioService CalendarioPagosCrPers
        {
            get
            {
                if (this._calendario_pagos_cr_pers == null)
                {
                    if (this.sesion == null)
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._calendario_pagos_cr_pers = new CreditosService.CalendarioService(this.CalendarioPagosCrPersId, sesion);
                        }
                    }
                    else
                    {
                        this._calendario_pagos_cr_pers = new CreditosService.CalendarioService(this.CalendarioPagosCrPersId, this.sesion);
                    }
                }
                return this._calendario_pagos_cr_pers;
            }
        }

        private DevengamientosService _ctb_devengamiento;
        public DevengamientosService CtbDevengamiento
        {
            get
            {
                if (this._ctb_devengamiento == null)
                {
                    if (this.sesion == null)
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._ctb_devengamiento = new DevengamientosService(this.CtbDevengamientoId, sesion);
                        }
                    }
                    else
                    {
                        this._ctb_devengamiento = new DevengamientosService(this.CtbDevengamientoId, this.sesion);
                    }
                }
                return this._ctb_devengamiento;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTB_DEVENGAMIENTOS_DETCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTB_DEVENGAMIENTOS_DETRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CTB_DEVENGAMIENTOS_DETRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public DevengamientosDetallesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public DevengamientosDetallesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public DevengamientosDetallesService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }

        private DevengamientosDetallesService(CTB_DEVENGAMIENTOS_DETRow row)
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
                this.Estado = Definiciones.Estado.Activo;
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);

                sesion.db.CTB_DEVENGAMIENTOS_DETCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.CTB_DEVENGAMIENTOS_DETCollection.Update(this.row);
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
            this._calendario_pagos_cr_pers = null;
            this._ctb_devengamiento = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Borrar
        public void Borrar()
        {
            this.Estado = Definiciones.Estado.Inactivo;
            this.Guardar();
        }
        #endregion Borrar

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return this.ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            throw new NotImplementedException("ToEDI() no implementado.");
        }
        #endregion ToEDI

        #region Buscar
        protected override DevengamientosDetallesService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append(Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'");

            foreach (Filtro f in filtros)
            {
                if (f.OrderBy)
                {
                    orden.Add(f.Columna + " " + (f.Valor == null ? "" : f.Valor));
                }
                else
                {
                    sb.Append(" and ");
                    switch (f.Columna)
                    {
                        case Modelo.IDColumnName:
                        case Modelo.CALENDARIO_PAGOS_CR_PERS_IDColumnName:
                        case Modelo.CTB_DEVENGAMIENTO_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            CTB_DEVENGAMIENTOS_DETRow[] rows = sesion.db.CTB_DEVENGAMIENTOS_DETCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            DevengamientosDetallesService[] dd = new DevengamientosDetallesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                dd[i] = new DevengamientosDetallesService(rows[i]);
            return dd;
        }
        #endregion Buscar

        #region Buscar Extendido
        public static DevengamientosDetallesService[] BuscarPorCredito(CreditosService credito, DateTime? fecha_corte, SessionService sesion)
        {
            //Si se realizan devengamientos de cuotas por conjunto,
            //debe buscarse el mayor devengamiento donde esté la cuota
            //Se asume que entre dos devengamientos con fecha distinta,
            //el mayor ID siempre corresponde al de mayor fecha
            string sql =
                "select max(dd." + Modelo.IDColumnName + ")" +
                "  from " + Nombre_Tabla + " dd," +
                "       " + DevengamientosService.Nombre_Tabla + " d" +
                " where d." + DevengamientosService.Modelo.IDColumnName + " = dd." + Modelo.CTB_DEVENGAMIENTO_IDColumnName +
                "   and dd." + Modelo.CALENDARIO_PAGOS_CR_PERS_IDColumnName + " in (" + string.Join(",", Array.ConvertAll(credito.Calendario, i => i.Id.Value.ToString())) + ") ";
            if(fecha_corte.HasValue)
                sql += " and trunc(d." + DevengamientosService.Modelo.FECHAColumnName + ") >= to_date('" + fecha_corte.Value.ToShortDateString() + "', 'dd/mm/yyyy')";
            sql += " and dd." + Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'" +
                "    and d." + DevengamientosService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'" +
                " group by dd." + Modelo.CALENDARIO_PAGOS_CR_PERS_IDColumnName +
                " order by dd." + Modelo.CALENDARIO_PAGOS_CR_PERS_IDColumnName;

            var dt = sesion.db.EjecutarQuery(sql);
            var dd = new DevengamientosDetallesService[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                dd[i] = new DevengamientosDetallesService((decimal)dt.Rows[i][0], sesion);

            return dd;
        }

        public static DevengamientosDetallesService BuscarPorCuota(CreditosService.CalendarioService cuota, DateTime? fecha_corte, SessionService sesion)
        {
            //Si se realizan devengamientos de cuotas por conjunto,
            //debe buscarse el mayor devengamiento donde esté la cuota
            //Se asume que entre dos devengamientos con fecha distinta,
            //el mayor ID siempre corresponde al de mayor fecha
            string sql =
                "select max(dd." + Modelo.IDColumnName + ")" +
                "  from " + Nombre_Tabla + " dd," +
                "       " + DevengamientosService.Nombre_Tabla + " d" +
                " where d." + DevengamientosService.Modelo.IDColumnName + " = dd." + Modelo.CTB_DEVENGAMIENTO_IDColumnName +
                "   and dd." + Modelo.CALENDARIO_PAGOS_CR_PERS_IDColumnName + " = " + cuota.Id;
            if (fecha_corte.HasValue)
                sql += " and trunc(d." + DevengamientosService.Modelo.FECHAColumnName + ") >= to_date('" + fecha_corte.Value.ToShortDateString() + "', 'dd/mm/yyyy')";
            sql += " and dd." + Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'" +
                "    and d." + DevengamientosService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'" +
                " group by dd." + Modelo.CALENDARIO_PAGOS_CR_PERS_IDColumnName +
                " order by dd." + Modelo.CALENDARIO_PAGOS_CR_PERS_IDColumnName;

            var dt = sesion.db.EjecutarQuery(sql);
            if(dt.Rows.Count > 0)
                return new DevengamientosDetallesService((decimal)dt.Rows[0][0], sesion);
            else
                return null;
        }
        #endregion Buscar Extendido

        #region Accessors
        public static string Nombre_Tabla = "CTB_DEVENGAMIENTOS_DET";
        public static string Nombre_Secuencia = "CTB_DEVENGAMIENTOS_DET_SQC";
        #endregion Accessors
    }
}
