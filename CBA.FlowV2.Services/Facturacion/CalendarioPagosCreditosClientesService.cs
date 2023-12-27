#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Common;
using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Contabilidad;

#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public partial class CreditosService
    {
        #region clase CalendarioService
        public class CalendarioService : ClaseCBA<CalendarioService>
        {
            #region Propiedades
            protected CALENDARIO_PAGOS_CR_PERSONASRow row;
            protected CALENDARIO_PAGOS_CR_PERSONASRow rowSinModificar;
            public class Modelo : CALENDARIO_PAGOS_CR_PERSONASCollection_Base { public Modelo() : base(null) { } }

            public bool ExisteEnDB { get { return this.Id.HasValue; } }
            public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

            public string CancelacionAnticipada { get { return ClaseCBABase.GetStringHelper(row.CANCELACION_ANTICIPADA); } set { row.CANCELACION_ANTICIPADA = value; } }
            public decimal? CasoAsociadoId { get { if (row.IsCASO_ASOCIADO_IDNull) return null; else return row.CASO_ASOCIADO_ID; } set { if (value.HasValue) row.CASO_ASOCIADO_ID = value.Value; else row.IsCASO_ASOCIADO_IDNull = true; } }
            public decimal CreditoId { get { return row.CREDITO_ID; } set { row.CREDITO_ID = value; } }
            public decimal? CtbDevengamientoPrimeroId { get { if (row.IsCTB_DEVENGAMIENTO_PRIMERO_IDNull) return null; else return row.CTB_DEVENGAMIENTO_PRIMERO_ID; } set { if (value.HasValue) row.CTB_DEVENGAMIENTO_PRIMERO_ID = value.Value; else row.IsCTB_DEVENGAMIENTO_PRIMERO_IDNull = true; } }
            public decimal DevengamientoCapitalACobrar { get { return row.DEVENGAMIENTO_CAPITAL_A_COBRAR; } set { row.DEVENGAMIENTO_CAPITAL_A_COBRAR = value; } }
            public decimal DevengamientoInteresACobrar { get { return row.DEVENGAMIENTO_INTERES_A_COBRAR; } set { row.DEVENGAMIENTO_INTERES_A_COBRAR = value; } }
            public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
            public DateTime FechaVencimiento { get { return row.FECHA_VENCIMIENTO; } set { row.FECHA_VENCIMIENTO = value; } }
            public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
            public decimal MontoCapital { get { return row.MONTO_CAPITAL; } set { row.MONTO_CAPITAL = value; } }
            public decimal MontoImpuesto { get { return row.MONTO_IMPUESTO; } set { row.MONTO_IMPUESTO = value; } }
            public decimal MontoInteresADevengar { get { return row.MONTO_INTERES_A_DEVENGAR; } set { row.MONTO_INTERES_A_DEVENGAR = value; } }
            public decimal MontoInteresDevengado { get { return row.MONTO_INTERES_DEVENGADOS; } set { row.MONTO_INTERES_DEVENGADOS = value; } }
            public decimal MontoInteresEnSuspenso { get { return row.MONTO_INTERES_EN_SUSPENSO; } set { row.MONTO_INTERES_EN_SUSPENSO = value; } }
            public decimal? MontoMoraManual { get { if (row.IsMONTO_MORA_MANUALNull) return null; else return row.MONTO_MORA_MANUAL; } set { if (value.HasValue) row.MONTO_MORA_MANUAL = value.Value; else row.IsMONTO_MORA_MANUALNull = true; } }
            public decimal NumeroCuota { get { return row.NUMERO_CUOTA; } set { row.NUMERO_CUOTA = value; } }
            #endregion Propiedades

            #region Propiedades Extendidas
            private CasosService _caso_asociado;
            public CasosService CasoAsociado
            {
                get
                {
                    if (this._caso_asociado == null)
                    {
                        if (this.sesion != null)
                            this._caso_asociado = new CasosService(this.CasoAsociadoId.Value, this.sesion);
                        else
                            this._caso_asociado = new CasosService(this.CasoAsociadoId.Value);
                    }
                    return this._caso_asociado;
                }
            }

            private CreditosService _credito;
            public CreditosService Credito
            {
                get
                {
                    if (this._credito == null)
                    {
                        if (this.sesion != null)
                            this._credito = new CreditosService(this.CreditoId, this.sesion);
                        else
                            this._credito = new CreditosService(this.CreditoId);
                    }
                    return this._credito;
                }
            }

            private DevengamientosService _ctb_devengamiento_primero;
            public DevengamientosService CtbDevengamientoPrimero
            {
                get
                {
                    if (this._ctb_devengamiento_primero == null)
                    {
                        if (this.sesion != null)
                            this._ctb_devengamiento_primero = new DevengamientosService(this.CtbDevengamientoPrimeroId.Value, this.sesion);
                        else
                            this._ctb_devengamiento_primero = new DevengamientosService(this.CtbDevengamientoPrimeroId.Value);
                    }
                    return this._ctb_devengamiento_primero;
                }
            }

            private CuentaCorrientePersonasService _ctacte_persona;
            public CuentaCorrientePersonasService CtactePersona
            {
                get
                {
                    if (this._ctacte_persona == null)
                    {
                        if (this.sesion != null)
                        {
                            this._ctacte_persona = new CuentaCorrientePersonasService(CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol, this.Id.Value, this.sesion);
                        }
                        else
                        {
                            using (SessionService sesion = new SessionService())
                            {
                                this._ctacte_persona = new CuentaCorrientePersonasService(CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol, this.Id.Value, sesion);
                            }
                        }
                    }
                    return this._ctacte_persona;
                }
            }
            #endregion Propiedades Extendidas

            #region Constructores
            private void Inicializar(decimal id, SessionService sesion)
            {
                this.row = null;
                if (id != Definiciones.Error.Valor.EnteroPositivo)
                {
                    this.row = sesion.db.CALENDARIO_PAGOS_CR_PERSONASCollection.GetByPrimaryKey(id);
                }
                else
                {
                    this.row = new CALENDARIO_PAGOS_CR_PERSONASRow();
                    this.Id = Definiciones.Error.Valor.EnteroPositivo;
                }

                this.rowSinModificar = this.row.Clonar();
            }
            private void Inicializar(CALENDARIO_PAGOS_CR_PERSONASRow row)
            {
                this.row = row;
                this.rowSinModificar = this.row.Clonar();
            }

            public CalendarioService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
            public CalendarioService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
            internal CalendarioService(decimal id)
            {
                using (SessionService sesion = new SessionService())
                {
                    this.IniciarUsingSesion(sesion);
                    Inicializar(id, sesion);
                    this.FinalizarUsingSesion();
                }
            }
            internal CalendarioService(CALENDARIO_PAGOS_CR_PERSONASRow row)
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
                    this.CancelacionAnticipada = Definiciones.SiNo.No;
                    this.Estado = Definiciones.Estado.Activo;
                    this.DevengamientoCapitalACobrar = this.MontoCapital + this.MontoImpuesto;
                    this.DevengamientoInteresACobrar = this.MontoInteresADevengar + this.MontoInteresDevengado + this.MontoInteresEnSuspenso;
                    sesion.db.CALENDARIO_PAGOS_CR_PERSONASCollection.Insert(this.row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
                }
                else
                {
                    sesion.db.CALENDARIO_PAGOS_CR_PERSONASCollection.Update(this.row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.rowSinModificar.ToString(), this.row.ToString(), sesion);
                }

                if (this.CancelacionAnticipada != this.rowSinModificar.CANCELACION_ANTICIPADA && this.CtactePersona.ExisteEnDB)
                    CuentaCorrientePersonasService.SetBloqueado(this.CtactePersona.Id.Value, this.CancelacionAnticipada == Definiciones.SiNo.Si, this.sesion);

                this.rowSinModificar = this.row.Clonar();

                return this.row.ID;
            }
            #endregion Guardar

            #region Validar
            protected override void ValidarPrivado(SessionService sesion)
            {
                CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

                if (this.ExisteEnDB && this.CtactePersona != null && this.CtactePersona.Bloqueado == Definiciones.SiNo.Si)
                {
                    decimal? montoMoraManualAnterior = null;
                    if (!this.rowSinModificar.IsMONTO_MORA_MANUALNull)
                        montoMoraManualAnterior = this.rowSinModificar.MONTO_MORA_MANUAL;
                    if (this.MontoMoraManual != montoMoraManualAnterior)
                        excepciones.Agregar("La cuota no puede modificarse porque está bloqueada.");
                }

                if (excepciones.ExistenErrores)
                    throw new Exception(excepciones.ToString());
            }
            #endregion Validar

            #region ResetearPropiedadesExtendidas
            public override void ResetearPropiedadesExtendidas()
            {
                this._caso_asociado = null;
                this._credito = null;
                this._ctb_devengamiento_primero = null;
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
            protected override CalendarioService[] Buscar(Filtro[] filtros)
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
                            case Modelo.CREDITO_IDColumnName:
                            case Modelo.IDColumnName:
                            case Modelo.CASO_ASOCIADO_IDColumnName:
                            case Modelo.CTB_DEVENGAMIENTO_PRIMERO_IDColumnName:
                            case Modelo.NUMERO_CUOTAColumnName:
                                if (f.Exacto)
                                    sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                                else
                                    sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                                break;
                            case Modelo.CANCELACION_ANTICIPADAColumnName:
                                sb.Append(f.Columna + " " + f.Comparacion + " '" + f.Valor + "'");
                                break;
                            case Modelo.FECHA_VENCIMIENTOColumnName:
                                sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                                break;
                            default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                        }
                    }
                }

                orden.Add(Modelo.NUMERO_CUOTAColumnName);
                CALENDARIO_PAGOS_CR_PERSONASRow[] rows = sesion.db.CALENDARIO_PAGOS_CR_PERSONASCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
                CalendarioService[] cpc = new CalendarioService[rows.Length];
                for (int i = 0; i < rows.Length; i++)
                    cpc[i] = new CalendarioService(rows[i]);

                return cpc;
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

            #region CalcularMontoMora
            public decimal CalcularMontoMora()
            {
                decimal moraCuota = 0;
                int diasAtraso;
                
                if (this.Credito.FechaCancelacionAnticipada.HasValue)
                    diasAtraso = (this.Credito.FechaCancelacionAnticipada.Value.Date - this.CtactePersona.FechaVencimiento.Date).Days;
                else
                    diasAtraso = (DateTime.Now.Date - this.CtactePersona.FechaVencimiento.Date).Days;
                        
                if (this.MontoMoraManual.HasValue)
                    return this.MontoMoraManual.Value;

                if (diasAtraso > this.Credito.DiasGracia)
                {
                    if (this.Credito.MontoDiarioMora.HasValue)
                        moraCuota = this.Credito.MontoDiarioMora.Value * diasAtraso;
                    else
                        moraCuota = this.Credito.PorcentajeDiarioMora.Value / 100 * diasAtraso * (this.CtactePersona.Credito - this.CtactePersona.Debito);
                }

                return moraCuota;
            }
            #endregion CalcularMontoMora

            #region Accessors
            public static string Nombre_Tabla = "CALENDARIO_PAGOS_CR_PERSONAS";
            public static string Nombre_Secuencia = "CALENDARIO_PAGOS_CR_PERS_SQC";
            #endregion Accessors
        }
        #endregion clase CalendarioService

        #region CalcularVencimientos
        public static DateTime[] CalcularVencimientos(DateTime primer_vencimiento, int cantidad_cuotas, string tipo_frecuencia, int frecuencia)
        {
            DateTime[] vencimientos = new DateTime[cantidad_cuotas];
            DateTime fecha = primer_vencimiento;

            vencimientos[0] = primer_vencimiento;
            switch (tipo_frecuencia)
            {
                case Definiciones.TiposIntervalo.Anhos:
                    for (int i = 1; i < cantidad_cuotas; i++)
                        vencimientos[i] = vencimientos[i - 1].AddYears((int)frecuencia);
                    break;
                case Definiciones.TiposIntervalo.Dias:
                    for (int i = 1; i < cantidad_cuotas; i++)
                        vencimientos[i] = vencimientos[i - 1].AddDays((int)frecuencia);
                    break;
                case Definiciones.TiposIntervalo.Meses:
                    for (int i = 1; i < cantidad_cuotas; i++)
                        vencimientos[i] = vencimientos[i - 1].AddMonths((int)frecuencia);
                    break;
                case Definiciones.TiposIntervalo.Semanas:
                    for (int i = 1; i < cantidad_cuotas; i++)
                        vencimientos[i] = vencimientos[i - 1].AddDays((int)frecuencia * 7);
                    break;
            }

            return vencimientos;
        }
        #endregion CalcularVencimientos

        #region DesplazarVencimientos
        public void DesplazarVencimientos(decimal cantidad, string tipo_intervalo)
        {
            if (this.sesion == null)
            {
                using (SessionService sesion = new SessionService())
                {
                    this.IniciarUsingSesion(sesion);
                    DesplazarVencimientos(cantidad, tipo_intervalo, sesion);
                    this.FinalizarUsingSesion();
                }
            }
            else
            {
                DesplazarVencimientos(cantidad, tipo_intervalo, this.sesion);
            }
        }
        public void DesplazarVencimientos(decimal cantidad, string tipo_intervalo, SessionService sesion)
        {
            string clausulas, strAux;

            if (this.Caso.EstadoId == Definiciones.EstadosFlujos.Cerrado || this.Caso.EstadoId == Definiciones.EstadosFlujos.Anulado)
                throw new Exception("No pueden modificarse los vencimientos de un " + Traducciones.Caso + " en " + this.Caso.EstadoId + ".");

            if (this.Caso.EstadoId == Definiciones.EstadosFlujos.Aprobado || this.Caso.EstadoId == Definiciones.EstadosFlujos.Vigente)
            {
                if (!RolesService.Tiene("CREDITOS CALENDARIO PAGOS DESPLAZAR VENCIMIENTOS EN VIGENTE"))
                    throw new Exception("No tiene permiso de modificar vencimientos de un " + Traducciones.Caso + " en " + this.Caso.EstadoId + ".");
            }

            strAux = Definiciones.Error.Valor.EnteroPositivo.ToString();
            for (int i = 0; i < this.Calendario.Length; i++)
            {
                switch (tipo_intervalo)
                {
                    case Definiciones.TiposIntervalo.Dias:
                        this.Calendario[i].FechaVencimiento.AddDays(int.Parse(cantidad.ToString()));
                        break;
                    case Definiciones.TiposIntervalo.Semanas:
                        this.Calendario[i].FechaVencimiento.AddDays(int.Parse(cantidad.ToString()) * 7);
                        break;
                    case Definiciones.TiposIntervalo.Meses:
                        this.Calendario[i].FechaVencimiento.AddMonths(int.Parse(cantidad.ToString()));
                        break;
                    case Definiciones.TiposIntervalo.Anhos:
                        this.Calendario[i].FechaVencimiento.AddYears(int.Parse(cantidad.ToString()));
                        break;
                }
                this.Calendario[i].Guardar();

                strAux += ", " + this.Calendario[i].Id.Value;
            }

            //Actualizar el registro en ctacte personas, si existe
            clausulas = CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol + " in (" + strAux + ")";
            DataTable dtCtacte = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(clausulas, string.Empty, sesion);
            for (int i = 0; i < dtCtacte.Rows.Count; i++)
            {
                for (int j = 0; j < this.Calendario.Length; j++)
                {
                    if (this.Calendario[i].Id.Value == (decimal)dtCtacte.Rows[i][CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol])
                    {
                        CuentaCorrientePersonasService.ActualizarFechaVencimientoYMonto((decimal)dtCtacte.Rows[i][CuentaCorrientePersonasService.Id_NombreCol], this.Calendario[i].FechaVencimiento, (decimal)dtCtacte.Rows[i][CuentaCorrientePersonasService.Credito_NombreCol], false, sesion);
                        break;
                    }
                }
            }
        }
        #endregion DesplazarVencimientos
    }
}
