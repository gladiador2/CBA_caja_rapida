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
    public class DevengamientosService : ClaseCBA<DevengamientosService>
    {
        #region Clases privadas auxiliares
        private class DeltaCalculos
        {
            public decimal deltaCapital = 0, deltaInteres = 0, deltaADevengarAum = 0, deltaADevengarDis = 0;
            public decimal creditoCapital = 0, creditoInteres = 0, creditoADevengar = 0;
        }
        #endregion Clases privadas auxiliares

        #region Propiedades
        protected CTB_DEVENGAMIENTOSRow row;
        protected CTB_DEVENGAMIENTOSRow rowSinModificar;
        public class Modelo : CTB_DEVENGAMIENTOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal ADevengarVencido { get { return row.A_DEVENGAR_VENCIDO; } set { row.A_DEVENGAR_VENCIDO = value; } }
        public decimal ADevengarVencidoAum { get { return row.A_DEVENGAR_VENCIDO_AUM; } set { row.A_DEVENGAR_VENCIDO_AUM = value; } }
        public decimal ADevengarVencidoDis { get { return row.A_DEVENGAR_VENCIDO_DIS; } set { row.A_DEVENGAR_VENCIDO_DIS = value; } }
        public decimal ADevengarVigente { get { return row.A_DEVENGAR_VIGENTE; } set { row.A_DEVENGAR_VIGENTE = value; } }
        public decimal ADevengarVigenteAum { get { return row.A_DEVENGAR_VIGENTE_AUM; } set { row.A_DEVENGAR_VIGENTE_AUM = value; } }
        public decimal ADevengarVigenteDis { get { return row.A_DEVENGAR_VIGENTE_DIS; } set { row.A_DEVENGAR_VIGENTE_DIS = value; } }
        public decimal? CanalVentaId { get { if (row.IsCANAL_VENTA_IDNull) return null; else return row.CANAL_VENTA_ID; } set { if (value.HasValue) { if (this.CanalVentaId != value) this._canal_venta = null; row.CANAL_VENTA_ID = value.Value; } else { row.IsCANAL_VENTA_IDNull = true; } } }
        public decimal CapitalACobrarVencido { get { return row.CAPITAL_A_COBRAR_VENCIDO; } set { row.CAPITAL_A_COBRAR_VENCIDO = value; } }
        public decimal CapitalACobrarVencidoAum { get { return row.CAPITAL_A_COBRAR_VENCIDO_AUM; } set { row.CAPITAL_A_COBRAR_VENCIDO_AUM = value; } }
        public decimal CapitalACobrarVencidoDis { get { return row.CAPITAL_A_COBRAR_VENCIDO_DIS; } set { row.CAPITAL_A_COBRAR_VENCIDO_DIS = value; } }
        public decimal CapitalACobrarVigente { get { return row.CAPITAL_A_COBRAR_VIGENTE; } set { row.CAPITAL_A_COBRAR_VIGENTE = value; } }
        public decimal CapitalACobrarVigenteAum { get { return row.CAPITAL_A_COBRAR_VIGENTE_AUM; } set { row.CAPITAL_A_COBRAR_VIGENTE_AUM = value; } }
        public decimal CapitalACobrarVigenteDis { get { return row.CAPITAL_A_COBRAR_VIGENTE_DIS; } set { row.CAPITAL_A_COBRAR_VIGENTE_DIS = value; } }
        public decimal CapitalVencidoCobrado { get { return row.CAPITAL_VENCIDO_COBRADO; } set { row.CAPITAL_VENCIDO_COBRADO = value; } }
        public decimal Cotizacion { get { return row.COTIZACION; } set { row.COTIZACION = value; } }
        public decimal Devengado { get { return row.DEVENGADO; } set { row.DEVENGADO = value; } }
        public decimal DevengadoAum { get { return row.DEVENGADO_AUM; } set { row.DEVENGADO_AUM = value; } }
        public decimal DevengadoDis { get { return row.DEVENGADO_DIS; } set { row.DEVENGADO_DIS = value; } }
        public decimal EnSuspenso { get { return row.EN_SUSPENSO; } set { row.EN_SUSPENSO = value; } }
        public decimal EnSuspensoAum { get { return row.EN_SUSPENSO_AUM; } set { row.EN_SUSPENSO_AUM = value; } }
        public decimal EnSuspensoDis { get { return row.EN_SUSPENSO_DIS; } set { row.EN_SUSPENSO_DIS = value; } }
        public string Estado { get { return GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public string ExistePersonaRelacionada { get { return GetStringHelper(row.EXISTE_PERSONA_RELACIONADA); } set { row.EXISTE_PERSONA_RELACIONADA = value; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal InteresACobrarVencido { get { return row.INTERES_A_COBRAR_VENCIDO; } set { row.INTERES_A_COBRAR_VENCIDO = value; } }
        public decimal InteresACobrarVencidoAum { get { return row.INTERES_A_COBRAR_VENCIDO_AUM; } set { row.INTERES_A_COBRAR_VENCIDO_AUM = value; } }
        public decimal InteresACobrarVencidoDis { get { return row.INTERES_A_COBRAR_VENCIDO_DIS; } set { row.INTERES_A_COBRAR_VENCIDO_DIS = value; } }
        public decimal InteresACobrarVigente { get { return row.INTERES_A_COBRAR_VIGENTE; } set { row.INTERES_A_COBRAR_VIGENTE = value; } }
        public decimal InteresACobrarVigenteAum { get { return row.INTERES_A_COBRAR_VIGENTE_AUM; } set { row.INTERES_A_COBRAR_VIGENTE_AUM = value; } }
        public decimal InteresACobrarVigenteDis { get { return row.INTERES_A_COBRAR_VIGENTE_DIS; } set { row.INTERES_A_COBRAR_VIGENTE_DIS = value; } }
        public decimal InteresVencidoCobrado { get { return row.INTERES_VENCIDO_COBRADO; } set { row.INTERES_VENCIDO_COBRADO = value; } }
        public decimal LimiteDiasEnSuspenso { get { return row.LIMITE_DIAS_EN_SUSPENSO; } set { row.LIMITE_DIAS_EN_SUSPENSO = value; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal? PersonaRelacionadaId { get { if (row.IsPERSONA_RELACIONADA_IDNull) return null; else return row.PERSONA_RELACIONADA_ID; } set { if (value.HasValue) { if (this.PersonaRelacionadaId != value) this._persona_relacionada = null; row.PERSONA_RELACIONADA_ID = value.Value; } else { row.IsPERSONA_RELACIONADA_IDNull = true; } } }
        public decimal? RegionId { get { if (row.IsREGION_IDNull) return null; else return row.REGION_ID; } set { if (value.HasValue) { if (this.RegionId != value) this._region = null; row.REGION_ID = value.Value; } else { row.IsREGION_IDNull = true; } } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private DevengamientosDetallesService[] _devengamiento_detalles;
        public DevengamientosDetallesService[] DevengamientoDetalles
        {
            get
            {
                if (this._devengamiento_detalles == null)
                {
                    var filtro = new Filtro() {  Columna = DevengamientosDetallesService.Modelo.CTB_DEVENGAMIENTO_IDColumnName, Valor = this.Id };
                    this._devengamiento_detalles = this.GetFiltrado<DevengamientosDetallesService>(filtro);
                }
                return this._devengamiento_detalles;
            }
        }

        private CanalesVentaService _canal_venta;
        public CanalesVentaService CanalVenta
        {
            get
            {
                if (this._canal_venta == null)
                {
                    if (this.sesion == null)
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._canal_venta = new CanalesVentaService(this.CanalVentaId.Value, sesion);
                        }
                    }
                    else
                    {
                        this._canal_venta = new CanalesVentaService(this.CanalVentaId.Value, this.sesion);
                    }
                }
                return this._canal_venta;
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

        private PersonasService _persona_relacionada;
        public PersonasService PersonaRelacionada
        {
            get
            {
                if (this._persona_relacionada == null)
                {
                    if (this.sesion == null)
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._persona_relacionada = new PersonasService(this.PersonaRelacionadaId.Value, sesion);
                        }
                    }
                    else
                    {
                        this._persona_relacionada = new PersonasService(this.PersonaRelacionadaId.Value, this.sesion);
                    }
                }
                return this._persona_relacionada;
            }
        }

        private RegionesService _region;
        public RegionesService Region
        {
            get
            {
                if (this._region == null)
                {
                    if(this.sesion == null)
                    {
                        using(SessionService sesion = new SessionService())
                        {
                            this._region = new RegionesService(this.RegionId.Value, sesion);
                        }
                    }
                    else
                    {
                        this._region = new RegionesService(this.RegionId.Value, this.sesion);
                    }
                }
                return this._region;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTB_DEVENGAMIENTOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTB_DEVENGAMIENTOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CTB_DEVENGAMIENTOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public DevengamientosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public DevengamientosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public DevengamientosService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        public DevengamientosService(EdiCBA.Devengamiento edi, SessionService sesion)
        {
            if (edi.id.HasValue)
                Inicializar(edi.id.Value, sesion);
            else
                Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);

            this.ADevengarVencido = edi.aDevengarVencido;
            this.ADevengarVigente = edi.aDevengarVigente;
            this.CanalVentaId = edi.cantalVentaId;
            this.CapitalACobrarVencido = edi.capitalACobrarVencido;
            this.CapitalACobrarVigente = edi.capitalACobrarVigente;
            this.CapitalVencidoCobrado = edi.capitalVencidoCobrado;
            this.Cotizacion = edi.cotizacion;
            this.Devengado = edi.devengado;
            this.EnSuspenso = edi.enSuspenso;
            this.ExistePersonaRelacionada = edi.existePersonaRelacionada;
            this.Fecha = edi.fecha;
            this.InteresACobrarVencido = edi.interesACobrarVencido;
            this.InteresACobrarVigente = edi.interesACobrarVigente;
            this.InteresVencidoCobrado = edi.interesVencidoCobrado;
            this.LimiteDiasEnSuspenso = edi.limiteDiasEnSuspenso;
            this.MonedaId = edi.monedaId;
            this.PersonaRelacionadaId = edi.personaRelacionadaId;
            this.RegionId = edi.regionId;
        }

        private DevengamientosService(CTB_DEVENGAMIENTOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Permisos
        public Permiso Permisos = new Permiso();
        public class Permiso
        {
            private bool? _ver;
            public bool Ver { get { if (this._ver == null) this._ver = RolesService.Tiene("CTB DEVENGAMIENTOS VER"); return this._ver.Value; } }

            private bool? _editar;
            public bool Editar { get { if (this._editar == null) this._editar = RolesService.Tiene("CTB DEVENGAMIENTOS EDITAR"); return this._editar.Value; } }
        }
        #endregion Permisos

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            if (!this.Permisos.Editar)
                throw new Exception("No tiene permisos para guardar.");

            this.Validar();

            if (!this.ExisteEnDB)
            {
                this.Estado = Definiciones.Estado.Activo;
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);

                //Guardar una primera vez para que exista en la db ya que 
                //las cuotas referencian al primer devengamiento en que participaron
                sesion.db.CTB_DEVENGAMIENTOSCollection.Insert(this.row);
                
                //Calcular el resultado del devengamiento
                this.CalcularMontos(false);

                //Guardar resultado
                sesion.db.CTB_DEVENGAMIENTOSCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);

                //Crear el asiento contable
                Contabilidad.GenerarAsientosEntidades.AsientosDevengamiento.AsentarDevengamiento(this, sesion);
            }
            else
            {
                sesion.db.CTB_DEVENGAMIENTOSCollection.Update(this.row);
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

            if (!this.ExisteEnDB)
            {
                //Verificar que no existe un devengamiento Anterior
                DateTime ultimoDevengamiento = GetFechaMaxima(this, sesion);
                if (this.Fecha.Date <= ultimoDevengamiento.Date)
                {
                    if (this.RegionId.HasValue)
                        excepciones.Agregar("El devengamiento ya fue realizado hasta la fecha " + ultimoDevengamiento.ToShortDateString() + " en " + this.Region.Nombre + ".");
                    else
                        excepciones.Agregar("El devengamiento ya fue realizado hasta la fecha " + ultimoDevengamiento.ToShortDateString() + ".");
                }
            }
            
            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return this.ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            var e = new CBA.FlowV2.Services.Base.EdiCBA.Devengamiento()
            {
                aDevengarVencido = this.ADevengarVencido,
                aDevengarVigente = this.ADevengarVigente,
                cantalVentaId = this.CanalVentaId,
                capitalACobrarVencido = this.CapitalACobrarVencido,
                capitalACobrarVigente = this.CapitalACobrarVigente,
                capitalVencidoCobrado = this.CapitalVencidoCobrado,
                cotizacion = this.Cotizacion,
                devengado = this.Devengado,
                enSuspenso = this.EnSuspenso,
                existePersonaRelacionada = this.ExistePersonaRelacionada,
                fecha = this.Fecha,
                interesACobrarVencido = this.InteresACobrarVencido,
                interesACobrarVigente = this.InteresACobrarVigente,
                interesVencidoCobrado = this.InteresVencidoCobrado,
                limiteDiasEnSuspenso = this.LimiteDiasEnSuspenso,
                monedaId = this.MonedaId,
                personaRelacionadaId = this.PersonaRelacionadaId,
                regionId = this.RegionId
            };

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value);
            }

            return e;
        }
        #endregion ToEDI

        #region BorrarEnCascada
        public void BorrarEnCascada()
        {
            using(SessionService sesion = new SessionService())
            {
                try
                {
                    this.IniciarUsingSesion(sesion);
                    sesion.BeginTransaction();
                    BorrarEnCascada(sesion);
                    sesion.CommitTransaction();
                    this.FinalizarUsingSesion();
                }
                catch(Exception)
                {
                    sesion.RollbackTransaction();
                    this.FinalizarUsingSesion();
                    throw;
                }
            }
        }

        public void BorrarEnCascada(SessionService sesion)
        {
            List<Filtro> lFiltros = new List<Filtro>();
            lFiltros.Add(new Filtro { Columna = Modelo.FECHAColumnName, OrderBy = true, Valor = "desc"});
            lFiltros.Add(new Filtro { Columna = Modelo.FECHAColumnName, Valor = this.Fecha, Comparacion = ">=" });
            if (this.CanalVentaId.HasValue)
                lFiltros.Add(new Filtro { Columna = Modelo.CANAL_VENTA_IDColumnName, Valor = this.CanalVentaId.Value });
            if (this.ExistePersonaRelacionada.Length > 0)
                lFiltros.Add(new Filtro { Columna = Modelo.EXISTE_PERSONA_RELACIONADAColumnName, Valor = "not null", Comparacion = "is" });
            else
                lFiltros.Add(new Filtro { Columna = Modelo.EXISTE_PERSONA_RELACIONADAColumnName, Valor = "null", Comparacion = "is" });
            if (this.PersonaRelacionadaId.HasValue)
                lFiltros.Add(new Filtro { Columna = Modelo.PERSONA_RELACIONADA_IDColumnName, Valor = this.PersonaRelacionadaId.Value });
            if (this.RegionId.HasValue)
                lFiltros.Add(new Filtro { Columna = Modelo.REGION_IDColumnName, Valor = this.RegionId.Value });

            var filtroDetalle = new Filtro() { Columna = DevengamientosDetallesService.Modelo.CTB_DEVENGAMIENTO_IDColumnName, Valor = Definiciones.Error.Valor.EnteroPositivo };

            DevengamientosService ultimoBorrado = null;
            foreach (var d in this.GetFiltrado<DevengamientosService>(lFiltros))
			{
                d.IniciarUsingSesion(sesion);
                d.Estado = Definiciones.Estado.Inactivo;
                d.Guardar();

                #region borrar detalles
                filtroDetalle.Valor = d.Id;
                foreach (var dd in this.GetFiltrado<DevengamientosDetallesService>(filtroDetalle))
                {
                    dd.IniciarUsingSesion(sesion);
                    dd.Borrar();
                    dd.FinalizarUsingSesion();
                }
                #endregion borrar detalles

                //Borrar el asiento contable si existe
                CBA.FlowV2.Services.Contabilidad.AsientosService.BorrarPorTablaYRegistro(Nombre_Tabla, this.Id.Value, sesion);

                d.FinalizarUsingSesion();
                ultimoBorrado = d;
			}

            //Actualizar el interes en el calendario de cuotas
            if (ultimoBorrado != null)
            {
                ultimoBorrado.IniciarUsingSesion(sesion);
                var d = GetAnterior(ultimoBorrado);
                ultimoBorrado.FinalizarUsingSesion();

                if (d == null)
                {
                    d = new DevengamientosService() 
                    {
                        CanalVentaId = ultimoBorrado.CanalVentaId,
                        PersonaRelacionadaId = ultimoBorrado.PersonaRelacionadaId,
                        ExistePersonaRelacionada = ultimoBorrado.ExistePersonaRelacionada,
                        RegionId = ultimoBorrado.RegionId,
                        Fecha = DateTime.MinValue,
                        Cotizacion = ultimoBorrado.Cotizacion,
                        MonedaId = ultimoBorrado.MonedaId,
                        LimiteDiasEnSuspenso = ultimoBorrado.LimiteDiasEnSuspenso,
                    };
                }

                d.IniciarUsingSesion(sesion);
                d.CalcularMontos(true);
                d.FinalizarUsingSesion();
            }
        }
        #endregion BorrarEnCascada

        #region CalcularMontos
        private DataTable CalcularMontosGetDataTable(bool recalculo_por_borrado, string fecha_vencimiento_anterior_ColumnName, string fecha_cuota_mas_vencida_ColumnName, SessionService sesion)
        {
            string sql = string.Empty;
            #region sql
            sql = " with tabla as ( " +
                  " select c." + CreditosService.Modelo.CASO_IDColumnName + ", " +
                  "        trunc(c." + CreditosService.Modelo.FECHA_RETIROColumnName + ") " + CreditosService.Modelo.FECHA_RETIROColumnName + ", " +
                  "        cpcp." + CreditosService.CalendarioService.Modelo.CREDITO_IDColumnName + ", " +
                  "        cpcp." + CreditosService.CalendarioService.Modelo.NUMERO_CUOTAColumnName + ", " +
                  "        trunc(cpcp." + CreditosService.CalendarioService.Modelo.FECHA_VENCIMIENTOColumnName + ") " + CreditosService.CalendarioService.Modelo.FECHA_VENCIMIENTOColumnName + ", " +
                  "        trunc(nvl(" +
                  "            (select cpcp2." + CreditosService.CalendarioService.Modelo.FECHA_VENCIMIENTOColumnName +
                  "               from " + CreditosService.CalendarioService.Nombre_Tabla + " cpcp2 " +
                  "              where cpcp2." + CreditosService.CalendarioService.Modelo.CREDITO_IDColumnName + " = c." + CreditosService.Modelo.IDColumnName +
                  "                and cpcp2." + CreditosService.CalendarioService.Modelo.NUMERO_CUOTAColumnName + " = cpcp." + CreditosService.CalendarioService.Modelo.NUMERO_CUOTAColumnName + " - 1 " +
                  "                and cpcp2." + CreditosService.CalendarioService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'), c." + CreditosService.Modelo.FECHA_RETIROColumnName +
                  "         )) " + fecha_vencimiento_anterior_ColumnName + ", " +
                  "       cpcp." + CreditosService.CalendarioService.Modelo.MONTO_CAPITALColumnName + ", " +
                  "       cpcp." + CreditosService.CalendarioService.Modelo.MONTO_INTERES_A_DEVENGARColumnName + ", " +
                  "       cpcp." + CreditosService.CalendarioService.Modelo.MONTO_INTERES_DEVENGADOSColumnName + ", " +
                  "       cpcp." + CreditosService.CalendarioService.Modelo.MONTO_INTERES_EN_SUSPENSOColumnName + ", " +
                  "       cpcp." + CreditosService.CalendarioService.Modelo.MONTO_IMPUESTOColumnName + ", " +
                  "       cpcp." + CreditosService.CalendarioService.Modelo.DEVENGAMIENTO_CAPITAL_A_COBRARColumnName + ", " +
                  "       cpcp." + CreditosService.CalendarioService.Modelo.DEVENGAMIENTO_INTERES_A_COBRARColumnName + ", " +
                  "       cpcp." + CreditosService.CalendarioService.Modelo.CASO_ASOCIADO_IDColumnName + ", " +
                  "       cp." + CuentaCorrientePersonasService.Id_NombreCol + " ctacte_persona_id, " +
                  "       cp." + CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol + ", " +
                  "       cp." + CuentaCorrientePersonasService.MonedaId_NombreCol + ", " +
                  "       m." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName + ", " +
                  "       cp." + CuentaCorrientePersonasService.CotizacionMoneda_NombreCol + ", " +
                  "       cp." + CuentaCorrientePersonasService.Credito_NombreCol + ", " +
                  "       nvl((select sum(cp2." + CuentaCorrientePersonasService.Debito_NombreCol + ") from " + CuentaCorrientePersonasService.Nombre_Tabla + " cp2 where cp2." + CuentaCorrientePersonasService.CtactePersonaRelacionada_NombreCol + " = cp." + CuentaCorrientePersonasService.Id_NombreCol + " and cp2." + CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and trunc(cp2." + CuentaCorrientePersonasService.FechaVencimiento_NombreCol + ") <= to_date('" + this.Fecha.ToShortDateString() + "', 'dd/mm/yyyy')), 0) " + CuentaCorrientePersonasService.Debito_NombreCol +
                  " from " + CreditosService.Nombre_Tabla + " c, " +
                  "      " + MonedasService.Nombre_Tabla + " m, " +
                  "      " + SucursalesService.Nombre_Tabla + " s, " +
                  "      " + CuentaCorrientePersonasService.Nombre_Tabla + " cp, " +
                  "      " + CreditosService.CalendarioService.Nombre_Tabla + " cpcp " +
                  "where c." + CreditosService.Modelo.IDColumnName + " = cpcp." + CreditosService.CalendarioService.Modelo.CREDITO_IDColumnName +
                  "  and c." + CreditosService.Modelo.MONEDA_IDColumnName + " = m." + MonedasService.Modelo.IDColumnName +
                  "  and c." + CreditosService.Modelo.SUCURSAL_IDColumnName + " = s." + SucursalesService.Id_NombreCol;
            if (!recalculo_por_borrado)
                sql += "  and trunc(c." + CreditosService.Modelo.FECHA_RETIROColumnName + ") <= to_date('" + this.Fecha.ToShortDateString() + "', 'dd/mm/yyyy')";
            if (this.CanalVentaId.HasValue)
                sql += " and c." + CreditosService.Modelo.CANAL_VENTA_IDColumnName + " = " + this.CanalVentaId.Value;
            if (this.ExistePersonaRelacionada == Definiciones.SiNo.No)
                sql += " and c." + CreditosService.Modelo.PERSONA_GARANTE1_IDColumnName + " is null";
            else if (this.ExistePersonaRelacionada == Definiciones.SiNo.Si)
                sql += " and c." + CreditosService.Modelo.PERSONA_GARANTE1_IDColumnName + " is not null";
            if (this.PersonaRelacionadaId.HasValue)
            {
                sql += " and (c." + CreditosService.Modelo.PERSONA_IDColumnName + " = " + this.PersonaRelacionadaId.Value +
                       "   or c." + CreditosService.Modelo.PERSONA_GARANTE1_IDColumnName + " = " + this.PersonaRelacionadaId.Value +
                       "   or c." + CreditosService.Modelo.PERSONA_GARANTE2_IDColumnName + " = " + this.PersonaRelacionadaId.Value +
                       "     )";
            }
            if (this.RegionId.HasValue)
                sql += " and s." + SucursalesService.RegionId_NombreCol + " = " + this.RegionId.Value;
            sql += " and cp." + CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol + " = cpcp." + CreditosService.CalendarioService.Modelo.IDColumnName +
                  "  and cpcp." + CreditosService.CalendarioService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' " +
                  "  and cp." + CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                  "  and c." + CreditosService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' " +
                  ") " +
                  " select t.*, " +
                  "       nvl((select trunc(min(t2." + CuentaCorrientePersonasService.FechaVencimiento_NombreCol + ")) " +
                  "          from tabla t2 " +
                  "         where t2." + CuentaCorrientePersonasService.CasoId_NombreCol + " = t." + CuentaCorrientePersonasService.CasoId_NombreCol +
                  "           and round(t2." + CuentaCorrientePersonasService.Credito_NombreCol + " - t2." + CuentaCorrientePersonasService.Debito_NombreCol + ", t2." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName + ") > 0 " +
                  "       ), t." + CreditosService.Modelo.FECHA_RETIROColumnName + ") " + fecha_cuota_mas_vencida_ColumnName +
                  "  from tabla t ";
            if (!recalculo_por_borrado)
            {
                sql += "   where t." + CreditosService.CalendarioService.Modelo.CASO_ASOCIADO_IDColumnName + " is null";
            }
            sql += " order by t." + CreditosService.Modelo.CASO_IDColumnName + ", t." + CreditosService.CalendarioService.Modelo.NUMERO_CUOTAColumnName;
            #endregion sql
            return sesion.db.EjecutarQuery(sql);
        }

        private void CalcularMontos(bool recalculo_por_borrado)
        {
            decimal creditoAnteriorId = Definiciones.Error.Valor.EnteroPositivo;
            string fechaVencimientoAnterior = "fecha_vencimiento_anterior";
            string fechaCuotaMasVencida = "fecha_cuota_mas_vencida";
            decimal ctacteCondicionPagoCredito = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.CondicionPagoCredito);
            var devengamientoAnterior = DevengamientosService.GetAnterior(this);

            /*
             * Diccionario donde la clave es el caso de credito y el valor es el hashtable hPorCaso
             * con el siguiente contenido:
             *   creditoAntesEnMora: bool,
             *   creditoAhoraEnMora: bool,
             *   lPorCuota: una lista de Hashtables que contiene
             *   {
             *     devengamientoDetalle: el objeto DevengamientosDetallesService que se tendra que guardar
             *     cuota: el objeto de la cuota que se está devengando
             *     cuotaOriginal: el objeto cuota antes de los cambios
             *     deltas: valores numéricos que son parte del devengamiento
             *     cuotaPrimeraVez: bool que indica si la cuota se devenga por primera vez
             *   }
             *
            */
            var dCalculos = new Dictionary<decimal, Hashtable>();
            Hashtable hPorCaso = null;
            List<Hashtable> lPorCuota = null;
                    
            var aFiltroDetalle = new Filtro[]
            {
                new Filtro() { Columna = DevengamientosDetallesService.Modelo.CTB_DEVENGAMIENTO_IDColumnName, Valor = Definiciones.Error.Valor.EnteroPositivo },
                new Filtro() { Columna = DevengamientosDetallesService.Modelo.CALENDARIO_PAGOS_CR_PERS_IDColumnName, Valor = Definiciones.Error.Valor.EnteroPositivo },
            };

            DataTable dt = CalcularMontosGetDataTable(recalculo_por_borrado, fechaVencimientoAnterior, fechaCuotaMasVencida, sesion);

            if (devengamientoAnterior == null)
            {
                devengamientoAnterior = new DevengamientosService();
                devengamientoAnterior.Fecha = DateTime.MinValue;
            }

            this.ADevengarVigente = devengamientoAnterior.ADevengarVigente;
            this.ADevengarVencido = devengamientoAnterior.ADevengarVencido;
            this.Devengado = devengamientoAnterior.Devengado;
            this.EnSuspenso = devengamientoAnterior.EnSuspenso;
            this.CapitalACobrarVigente = devengamientoAnterior.CapitalACobrarVigente;
            this.CapitalACobrarVencido = devengamientoAnterior.CapitalACobrarVencido;
            this.InteresACobrarVigente = devengamientoAnterior.InteresACobrarVigente;
            this.InteresACobrarVencido = devengamientoAnterior.InteresACobrarVencido;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal factorCotizacion = 1;
                var cuota = this.Get<CreditosService.CalendarioService>((decimal)dt.Rows[i][CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol]);
                var devengamientoDetalle = new DevengamientosDetallesService();
                var cuotaPrimeraVez = false;
                DevengamientosDetallesService devengamientoAnteriorDetalle = null;
                DeltaCalculos deltas = new DeltaCalculos();
                decimal totalInteres = cuota.MontoInteresADevengar + cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;
                decimal interesDiario;
                int diasTranscurridos;

                //Cada vez que se pasa de un credito al siguiente
                //agregar la suma de capital e intereses ya sean vigentes o vencidos
                if (creditoAnteriorId != cuota.CreditoId)
                {
                    creditoAnteriorId = cuota.CreditoId;

                    lPorCuota = new List<Hashtable>();
                    hPorCaso = new Hashtable()
                    {
                        { "creditoAntesEnMora", false },
                        { "creditoAhoraEnMora", false },
                        { "lPorCuota", lPorCuota }
                    };
                    dCalculos.Add(creditoAnteriorId, hPorCaso);
                }

                cuota.IniciarUsingSesion(this.sesion);

                //Guardar el monto a devengar anterior o cero si es la primera
                //vez que se contabiliza el caso
                var cuotaOriginal = new CreditosService.CalendarioService 
                {
                    MontoInteresADevengar = cuota.MontoInteresADevengar,
                    MontoInteresDevengado = cuota.MontoInteresDevengado,
                    MontoInteresEnSuspenso = cuota.MontoInteresEnSuspenso,
                    DevengamientoCapitalACobrar = cuota.DevengamientoCapitalACobrar,
                    DevengamientoInteresACobrar = cuota.DevengamientoInteresACobrar,
                };

                //Si es la primera vez que aparece el caso, inicializar el interes a devengar
                if (!cuota.CtbDevengamientoPrimeroId.HasValue)
                {
                    cuotaPrimeraVez = true;
                    cuotaOriginal.MontoInteresADevengar = 0;
                    cuotaOriginal.MontoInteresDevengado = 0;
                    cuotaOriginal.MontoInteresEnSuspenso = 0;
                    cuotaOriginal.DevengamientoCapitalACobrar = 0;
                    cuotaOriginal.DevengamientoInteresACobrar = 0;

                    if(!recalculo_por_borrado)
                        cuota.CtbDevengamientoPrimeroId = this.Id;
                }

                #region seleccionar o crear el devengamiento detalle
                if (!recalculo_por_borrado && this.ExisteEnDB)
                {
                    aFiltroDetalle[0].Valor = this.Id.Value;
                    aFiltroDetalle[1].Valor = cuota.Id;
                    devengamientoDetalle = this.GetPrimero<DevengamientosDetallesService>(aFiltroDetalle);

                    if (devengamientoDetalle == null)
                    {
                        devengamientoDetalle = new DevengamientosDetallesService()
                        {
                            CtbDevengamientoId = this.Id.Value,
                            CalendarioPagosCrPersId = cuota.Id.Value
                        };
                    }
                }

                if (devengamientoAnterior.ExisteEnDB)
                {
                    devengamientoAnteriorDetalle = this.GetPrimero<DevengamientosDetallesService>(new Filtro[]
                    {
                        new Filtro { Columna = DevengamientosDetallesService.Modelo.CTB_DEVENGAMIENTO_IDColumnName, Valor = devengamientoAnterior.Id },
                        new Filtro { Columna = DevengamientosDetallesService.Modelo.CALENDARIO_PAGOS_CR_PERS_IDColumnName, Valor  = cuota.Id },
                    });
                }
                if (devengamientoAnteriorDetalle == null || !devengamientoAnteriorDetalle.ExisteEnDB)
                    devengamientoAnteriorDetalle = new DevengamientosDetallesService() { CalendarioPagosCrPersId = cuota.Id.Value };

                //Inicializar con el detalle correspondiente al devengamiento anterior
                devengamientoDetalle.ADevengarVigente = devengamientoAnteriorDetalle.ADevengarVigente;
                devengamientoDetalle.ADevengarVencido = devengamientoAnteriorDetalle.ADevengarVencido;
                devengamientoDetalle.Devengado = devengamientoAnteriorDetalle.Devengado;
                devengamientoDetalle.EnSuspenso = devengamientoAnteriorDetalle.EnSuspenso;
                devengamientoDetalle.CapitalACobrarVigente = devengamientoAnteriorDetalle.CapitalACobrarVigente;
                devengamientoDetalle.CapitalACobrarVencido = devengamientoAnteriorDetalle.CapitalACobrarVencido;
                devengamientoDetalle.InteresACobrarVigente = devengamientoAnteriorDetalle.InteresACobrarVigente;
                devengamientoDetalle.InteresACobrarVencido = devengamientoAnteriorDetalle.InteresACobrarVencido;
                #endregion seleccionar o crear el devengamiento detalle

                lPorCuota.Add(new Hashtable()
                { 
                    { "devengamientoDetalle", devengamientoDetalle },
                    { "cuota", cuota },
                    { "cuotaOriginal", cuotaOriginal },
                    { "deltas", deltas },
                    { "cuotaPrimeraVez", cuotaPrimeraVez }
                });

                //Si es un borrado y el devengamiento es previo a la fecha de 
                //otorgamiento, marcar la cuota como no computada
                if (recalculo_por_borrado && (!this.Id.HasValue  || cuota.CtbDevengamientoPrimeroId.HasValue && cuota.CtbDevengamientoPrimeroId.Value > this.Id.Value))
                    cuota.CtbDevengamientoPrimeroId = null;

                DateTime fechaHasta = this.Fecha;
                if (this.Fecha > ((DateTime)dt.Rows[i][CuentaCorrientePersonasService.FechaVencimiento_NombreCol]).Date)
                    fechaHasta = ((DateTime)dt.Rows[i][CuentaCorrientePersonasService.FechaVencimiento_NombreCol]).Date;

                //Si la fecha a devengar es anterior a la del vencimiento anterior, tomar como 0 dias transcurridos
                diasTranscurridos = Math.Max(0, (fechaHasta - ((DateTime)dt.Rows[i][fechaVencimientoAnterior]).Date).Days);
                
                if (this.MonedaId != (decimal)dt.Rows[i][CuentaCorrientePersonasService.MonedaId_NombreCol])
                    factorCotizacion = this.Cotizacion / (decimal)dt.Rows[i][CuentaCorrientePersonasService.CotizacionMoneda_NombreCol];

                //El interes diario es la suma de intereses dividido la cantidad de dias entre el vencimiento actual y el anterior
                int cantidadDias = ((DateTime)dt.Rows[i][CuentaCorrientePersonasService.FechaVencimiento_NombreCol] - (DateTime)dt.Rows[i][fechaVencimientoAnterior]).Days;
                
                interesDiario = totalInteres / Math.Max(cantidadDias, 1);

                hPorCaso["creditoAntesEnMora"] = (bool)hPorCaso["creditoAntesEnMora"] | cuotaOriginal.MontoInteresEnSuspenso > 0;

                if (diasTranscurridos > 0 && (fechaHasta - (DateTime)dt.Rows[i][fechaCuotaMasVencida]).Days > this.LimiteDiasEnSuspenso)
                {
                    hPorCaso["creditoAhoraEnMora"] = true;

                    //Cantidad de dias total en suspenso
                    int diasSuspenso = Math.Min(diasTranscurridos, (fechaHasta - (DateTime)dt.Rows[i][fechaCuotaMasVencida]).Days - (int)this.LimiteDiasEnSuspenso);
                    devengamientoDetalle.CantidadDiasDevengados =  (int)Math.Max(0, (fechaHasta - (DateTime)dt.Rows[i][fechaVencimientoAnterior]).Days - diasSuspenso);

                    cuota.MontoInteresEnSuspenso = diasSuspenso * interesDiario * factorCotizacion;
                    cuota.MontoInteresDevengado = devengamientoDetalle.CantidadDiasDevengados * interesDiario * factorCotizacion;
                    cuota.MontoInteresADevengar = totalInteres - cuota.MontoInteresEnSuspenso - cuota.MontoInteresDevengado;
                }
                else
                {
                    devengamientoDetalle.CantidadDiasDevengados = diasTranscurridos;

                    cuota.MontoInteresDevengado = devengamientoDetalle.CantidadDiasDevengados * interesDiario * factorCotizacion;
                    cuota.MontoInteresEnSuspenso = 0;
                    cuota.MontoInteresADevengar = totalInteres - cuota.MontoInteresEnSuspenso - cuota.MontoInteresDevengado;
                }

                if (cuota.MontoInteresDevengado > cuotaOriginal.MontoInteresDevengado)
                    devengamientoDetalle.DevengadoAum = cuota.MontoInteresDevengado - cuotaOriginal.MontoInteresDevengado;
                else
                    devengamientoDetalle.DevengadoDis = cuotaOriginal.MontoInteresDevengado - cuota.MontoInteresDevengado;

                if (cuota.MontoInteresEnSuspenso >= cuotaOriginal.MontoInteresEnSuspenso)
                    devengamientoDetalle.EnSuspensoAum += cuota.MontoInteresEnSuspenso - cuotaOriginal.MontoInteresEnSuspenso;
                else
                    devengamientoDetalle.EnSuspensoDis += cuotaOriginal.MontoInteresEnSuspenso - cuota.MontoInteresEnSuspenso;

                if (cuota.MontoInteresADevengar >= cuotaOriginal.MontoInteresADevengar)
                    deltas.deltaADevengarAum += (cuota.MontoInteresADevengar - cuotaOriginal.MontoInteresADevengar) * factorCotizacion;
                else
                    deltas.deltaADevengarDis += (cuotaOriginal.MontoInteresADevengar - cuota.MontoInteresADevengar) * factorCotizacion;

                //Si es la primera vez que aparece la cuota se aumenta y disminuye aunque el neto queda cero
                if (cuotaPrimeraVez)
                {
                    deltas.deltaADevengarAum += cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;
                    deltas.deltaADevengarDis += cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;
                }

                //Capital menos los pagos hechos, priorizando el monto por intereses
                cuota.DevengamientoCapitalACobrar = cuota.MontoCapital + cuota.MontoImpuesto - Math.Max(0, (decimal)dt.Rows[i][CuentaCorrientePersonasService.Debito_NombreCol] - totalInteres);
                cuota.DevengamientoInteresACobrar = totalInteres - Math.Min(totalInteres, (decimal)dt.Rows[i][CuentaCorrientePersonasService.Debito_NombreCol]);

                deltas.deltaCapital = (cuota.DevengamientoCapitalACobrar - cuotaOriginal.DevengamientoCapitalACobrar) * factorCotizacion;
                deltas.deltaInteres = (cuota.DevengamientoInteresACobrar - cuotaOriginal.DevengamientoInteresACobrar) * factorCotizacion;

                deltas.creditoCapital = cuota.DevengamientoCapitalACobrar;
                deltas.creditoInteres = cuota.DevengamientoInteresACobrar;
                deltas.creditoADevengar = cuota.MontoInteresADevengar;

                #region Si existen facturas por devengamiento no puede modificarse la distribucion de intereses
                if (cuota.CasoAsociadoId.HasValue &&
                    (Math.Round(cuota.MontoInteresADevengar, 4) != Math.Round(cuotaOriginal.MontoInteresADevengar, 4) ||
                     Math.Round(cuota.MontoInteresDevengado, 4) != Math.Round(cuotaOriginal.MontoInteresDevengado, 4) ||
                     Math.Round(cuota.MontoInteresEnSuspenso, 4) != Math.Round(cuotaOriginal.MontoInteresEnSuspenso, 4))
                    )
                {
                    throw new Exception("La cuota " + cuota.NumeroCuota + " del crédito caso " + 
                                        cuota.Credito.CasoId + " ya generó a la factura caso " + 
                                        cuota.CasoAsociadoId.Value + " por devengamiento.");
                }
                #endregion Si existen facturas por devengamiento no puede modificarse la distribucion de intereses

                #region Facturar intereses si corresponde
                //Facturar si:
                //- No existía una factura ya creada
                //- El crédito indica que la facturación de los intereses se hace en devengamiento
                //- La columna Interés a Devengar es cero
                //- El interés se encuentra o se está pasando a Devengado y no a En-Suspenso
                if( !recalculo_por_borrado &&
                    !cuota.CasoAsociadoId.HasValue && 
                    (cuota.Credito.FacturarIntereses == Definiciones.CreditosPoliticaFacturacion.Devengamiento || cuota.Credito.FacturarCapital == Definiciones.CreditosPoliticaFacturacion.Devengamiento) &&
                    Math.Round(cuota.MontoInteresADevengar, 4) == 0 &&
                    Math.Round(cuota.MontoInteresEnSuspenso, 4) == 0)
                {
                    string casoFacturaEstado = string.Empty;
                    Hashtable camAum;
                    decimal casoFacturaId = Definiciones.Error.Valor.EnteroPositivo;
                    decimal totalFactura = 0;
                    DateTime fechaPrimerVencimiento = DateTime.Now, fechaSegundoVencimiento = DateTime.MinValue;
                    bool usarFechaPrimerVencimiento = false, usarFechaSegundoVencimiento = false, exitoFactura;
                    string clausulas, mensajeFactura;

                    decimal sucursalCasaMatrizId = SucursalesService.GetSucursalCasaMatriz(this.RegionId, null, sesion);
                    clausulas = CuentaCorrienteCajasSucursalService.SucursalId_NombreCol + " = " + sucursalCasaMatrizId + " and " +
                                CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol + " = '" + Definiciones.CuentaCorrienteCajaSucursalEstados.Abierta + "'";

                    DataTable dtCtacteCajaSucursal = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalDataTable2(clausulas, CuentaCorrienteCajasSucursalService.Id_NombreCol);
                    if (dtCtacteCajaSucursal.Rows.Count <= 0)
                        throw new Exception("No existe una caja abierta en la casa matriz.");

                    DataTable dtAutonumeracion = AutonumeracionesService.GetAutonumeracionesPorFlujo2(Definiciones.FlujosIDs.FACTURACION_CLIENTE, sucursalCasaMatrizId, sesion);
                    if (dtAutonumeracion.Rows.Count <= 0)
                        throw new Exception("No existe una autonumeración de Factura Cliente en la casa matriz.");

                    #region Crear cabecera
                    camAum = new Hashtable();
                    camAum.Add(FacturasClienteService.AConsignacion_NombreCol, Definiciones.SiNo.No);
                    camAum.Add(FacturasClienteService.AfectaCtacte_NombreCol, Definiciones.SiNo.No);
                    camAum.Add(FacturasClienteService.AfectaLineaCredito_NombreCol, Definiciones.SiNo.No);
                    camAum.Add(FacturasClienteService.AfectaStock_NombreCol, Definiciones.SiNo.No);
                    camAum.Add(FacturasClienteService.AutonumeracionId_NombreCol, dtAutonumeracion.Rows[0][AutonumeracionesService.Id_NombreCol]);
                    camAum.Add(FacturasClienteService.CasoOrigenId_NombreCol, cuota.Credito.CasoId.Value);
                    camAum.Add(FacturasClienteService.ComisionPorVenta_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
                    camAum.Add(FacturasClienteService.CondicionPagoId_NombreCol, ctacteCondicionPagoCredito);
                    camAum.Add(FacturasClienteService.CotizacionDestino_NombreCol, this.Cotizacion);
                    camAum.Add(FacturasClienteService.Direccion_NombreCol, string.Empty);
                    camAum.Add(FacturasClienteService.FechaVencimiento_NombreCol, this.Fecha);
                    camAum.Add(FacturasClienteService.Fecha_NombreCol, this.Fecha);
                    camAum.Add(FacturasClienteService.MonedaDestinoId_NombreCol, this.MonedaId);
                    camAum.Add(FacturasClienteService.TotalEntregaInicial_NombreCol, (decimal)0);
                    camAum.Add(FacturasClienteService.ObservacionEntrega_NombreCol, string.Empty);
                    camAum.Add(FacturasClienteService.Observacion_NombreCol, "Factura creada por crédito " + Traducciones.Caso + " Nº" + cuota.Credito.CasoId.Value);
                    camAum.Add(FacturasClienteService.PersonaId_NombreCol, cuota.Credito.PersonaId);
                    camAum.Add(FacturasClienteService.PorcentajeDescSobreTotal_NombreCol, (decimal)0);
                    camAum.Add(FacturasClienteService.SucursalId_NombreCol, sucursalCasaMatrizId);
                    camAum.Add(FacturasClienteService.TipoFacturaId_NombreCol, Definiciones.TipoFactura.Credito);
                    camAum.Add(FacturasClienteService.CtaCteCajaSucursalId_NombreCol, dtCtacteCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.Id_NombreCol]);

                    #region Obtener el primer deposito activo de la sucursal
                    DataTable dtStockDepositoAux = Stock.StockDepositosService.GetStockDepositosDataTable((decimal)dtAutonumeracion.Rows[0][AutonumeracionesService.SucursalId_NombreCol], true, true);
                    if (dtStockDepositoAux.Rows.Count <= 0)
                        throw new Exception("La sucursal debe tener al menos un depósito en el cual se pueda facturar.");
                    camAum.Add(FacturasClienteService.DepositoId_NombreCol, dtStockDepositoAux.Rows[0][Stock.StockDepositosService.Id_NombreCol]);
                    #endregion Obtener el primer deposito activo de la sucursal

                    FacturasClienteService.Guardar(camAum, true, ref casoFacturaId, ref casoFacturaEstado, sesion);

                    if (casoFacturaId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("No pudo crearse la factura pro intereses en crédito.");

                    DataTable dtFacturaCreada = FacturasClienteService.GetFacturaClienteInfoCompleta(FacturasClienteService.CasoId_NombreCol + " = " + casoFacturaId, string.Empty, sesion);
                    #endregion Crear cabecera

                    #region FC Detalle por capital
                    if (cuota.Credito.FacturarCapital == Definiciones.CreditosPoliticaFacturacion.Devengamiento)
                    {
                        var articulo = new ArticulosService(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoCapitalArticulo, sesion), sesion);
                        if (articulo.ArticulosLotes.Length <= 0)
                            throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                        camAum = new System.Collections.Hashtable();
                        camAum.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol]);
                        camAum.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, articulo.ArticulosLotes[0].ArticuloId);
                        camAum.Add(FacturasClienteDetalleService.LoteId_NombreCol, articulo.ArticulosLotes[0].Id.Value);
                        camAum.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, articulo.UnidadMedidaId);
                        camAum.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, (decimal)0);
                        camAum.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
                        camAum.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, articulo.ImpuestoId);
                        camAum.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, cuota.MontoCapital);
                        camAum.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)0);
                        camAum.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)0);
                        camAum.Add(FacturasClienteDetalleService.Observacion_NombreCol, articulo.DescripcionImpresion + " devengado " + this.Fecha.ToShortDateString() + ".");

                        FacturasClienteDetalleService.Guardar((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], camAum, true, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, sesion);
                        totalFactura += cuota.MontoCapital;
                    }
                    #endregion FC Detalle por capital

                    #region FC Detalle por interes
                    if (cuota.Credito.FacturarIntereses == Definiciones.CreditosPoliticaFacturacion.Devengamiento)
                    {
                        var articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente).Articulo;
                        if (articulo.ArticulosLotes.Length <= 0)
                            throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                        camAum = new System.Collections.Hashtable();
                        camAum.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol]);
                        camAum.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, articulo.ArticulosLotes[0].ArticuloId);
                        camAum.Add(FacturasClienteDetalleService.LoteId_NombreCol, articulo.ArticulosLotes[0].Id.Value);
                        camAum.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, articulo.UnidadMedidaId);
                        camAum.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, (decimal)0);
                        camAum.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
                        camAum.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, articulo.ImpuestoId);
                        camAum.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, cuota.MontoInteresDevengado);
                        camAum.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)0);
                        camAum.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)0);
                        camAum.Add(FacturasClienteDetalleService.Observacion_NombreCol, articulo.DescripcionImpresion + " devengado " + this.Fecha.ToShortDateString() + ".");

                        FacturasClienteDetalleService.Guardar((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], camAum, true, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, sesion);
                        totalFactura += cuota.MontoInteresDevengado;
                    }
                    #endregion FC Detalle por interes

                    //Crear calendario de pagos
                    CalendarioPagosFCClienteService.CrearCuotas((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol],
                                                                 totalFactura,
                                                                 (DateTime)dtFacturaCreada.Rows[0][FacturasClienteService.Fecha_NombreCol],
                                                                 fechaPrimerVencimiento,
                                                                 usarFechaPrimerVencimiento,
                                                                 fechaSegundoVencimiento,
                                                                 usarFechaSegundoVencimiento,
                                                                 sesion);

                    #region Aprobar el caso de FC Cliente
                    //Pasar a Pendiente
                    exitoFactura = new FacturasClienteService().ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Pendiente, false, out mensajeFactura, sesion);
                    if (exitoFactura)
                        (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Pendiente, "Transición automática.", sesion);
                    if (exitoFactura)
                        new FacturasClienteService().EjecutarAccionesLuegoDeCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Pendiente, sesion);
                    if (!exitoFactura)
                        throw new Exception(mensajeFactura);

                    //Pasar a Caja
                    exitoFactura = new FacturasClienteService().ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Caja, false, out mensajeFactura, sesion);
                    if (exitoFactura)
                        (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Caja, "Transición automática.", sesion);
                    if (exitoFactura)
                        new FacturasClienteService().EjecutarAccionesLuegoDeCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Caja, sesion);
                    if (!exitoFactura)
                        throw new Exception(mensajeFactura);

                    //Pasar a Cerrado
                    exitoFactura = new FacturasClienteService().ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Cerrado, false, out mensajeFactura, sesion);
                    if (exitoFactura)
                        (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Cerrado, "Transición automática.", sesion);
                    if (exitoFactura)
                        new FacturasClienteService().EjecutarAccionesLuegoDeCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Cerrado, sesion);
                    if (!exitoFactura)
                        throw new Exception(mensajeFactura);
                    #endregion Aprobar el caso de FC Cliente

                    cuota.CasoAsociadoId = casoFacturaId;
                }
                #endregion Facturar intereses si corresponde

                cuota.Guardar();
                cuota.FinalizarUsingSesion();
            }

            #region sumar resultados parciales del credito
            foreach (KeyValuePair<decimal, Hashtable> item in dCalculos)
            {
                var antesEnMora = (bool)item.Value["creditoAntesEnMora"];
                var ahoraEnMora = (bool)item.Value["creditoAhoraEnMora"];
                var lCuotas = (List<Hashtable>)item.Value["lPorCuota"];

                foreach (var ht in lCuotas)
                {
                    var dd = (DevengamientosDetallesService)ht["devengamientoDetalle"];
                    var c = (CreditosService.CalendarioService)ht["cuota"];
                    var ca = (CreditosService.CalendarioService)ht["cuotaOriginal"];
                    var delta = (DeltaCalculos)ht["deltas"];
                    var cuotaPrimeraVez = (bool)ht["cuotaPrimeraVez"];

                    #region modificar según el valor de antesEnMora y ahoraEnMora
                    if (!antesEnMora && !ahoraEnMora)
                    {
                        dd.ADevengarVigenteAum = delta.deltaADevengarAum;
                        this.ADevengarVigenteAum += dd.ADevengarVigenteAum;
                        dd.ADevengarVigenteDis = delta.deltaADevengarDis;
                        this.ADevengarVigenteDis += dd.ADevengarVigenteDis;

                        if (delta.deltaCapital > 0)
                        {
                            dd.CapitalACobrarVigenteAum = delta.deltaCapital;
                            this.CapitalACobrarVigenteAum += dd.CapitalACobrarVigenteAum;
                        }
                        else
                        {
                            dd.CapitalACobrarVigenteDis = -delta.deltaCapital;
                            this.CapitalACobrarVigenteDis += dd.CapitalACobrarVigenteDis;
                        }

                        if (delta.deltaInteres > 0)
                        {
                            dd.InteresACobrarVigenteAum = delta.deltaInteres;
                            this.InteresACobrarVigenteAum += dd.InteresACobrarVigenteAum;
                        }
                        else
                        {
                            dd.InteresACobrarVigenteDis = -delta.deltaInteres;
                            this.InteresACobrarVigenteDis += dd.InteresACobrarVigenteDis;
                        }
                    }
                    else if (antesEnMora && ahoraEnMora)
                    {
                        dd.ADevengarVencidoAum = delta.deltaADevengarAum;
                        this.ADevengarVencidoAum += dd.ADevengarVencidoAum;
                        dd.ADevengarVencidoDis = delta.deltaADevengarDis;
                        this.ADevengarVencidoDis += dd.ADevengarVencidoDis;

                        if (delta.deltaCapital > 0)
                        {
                            dd.CapitalACobrarVencidoAum = delta.deltaCapital;
                            this.CapitalACobrarVencidoAum += dd.CapitalACobrarVencidoAum;
                        }
                        else
                        {
                            dd.CapitalACobrarVencidoDis = -delta.deltaCapital;
                            this.CapitalACobrarVencidoDis += dd.CapitalACobrarVencidoDis;
                        }

                        if (delta.deltaInteres > 0)
                        {
                            dd.InteresACobrarVencidoAum = delta.deltaInteres;
                            this.InteresACobrarVencidoAum += dd.InteresACobrarVencidoAum;
                        }
                        else
                        {
                            dd.InteresACobrarVencidoDis = -delta.deltaInteres;
                            this.InteresACobrarVencidoDis += dd.InteresACobrarVencidoDis;
                        }
                    }
                    else if (!antesEnMora && ahoraEnMora)
                    {
                        dd.ADevengarVencidoAum = delta.creditoADevengar;
                        this.ADevengarVencidoAum += dd.ADevengarVencidoAum;
                        dd.CapitalACobrarVencidoAum = delta.creditoCapital;
                        this.CapitalACobrarVencidoAum += dd.CapitalACobrarVencidoAum;
                        dd.InteresACobrarVencidoAum = delta.creditoInteres;
                        this.InteresACobrarVencidoAum += dd.InteresACobrarVencidoAum;

                        if (!cuotaPrimeraVez)
                        {
                            dd.ADevengarVigenteDis = delta.creditoADevengar + delta.deltaADevengarAum - delta.deltaADevengarDis;
                            this.ADevengarVigenteDis += dd.ADevengarVigenteDis;
                            dd.CapitalACobrarVigenteDis = delta.creditoCapital + delta.deltaCapital;
                            this.CapitalACobrarVigenteDis += dd.CapitalACobrarVigenteDis;
                            dd.InteresACobrarVigenteDis = delta.creditoInteres + delta.deltaInteres;
                            this.InteresACobrarVigenteDis += dd.InteresACobrarVigenteDis;

                            dd.CapitalVencidoCobrado = delta.deltaCapital;
                            this.CapitalVencidoCobrado += dd.CapitalVencidoCobrado;
                            dd.InteresVencidoCobrado = delta.deltaInteres;
                            this.InteresVencidoCobrado += dd.InteresVencidoCobrado;
                        }
                    }
                    else if (antesEnMora && !ahoraEnMora)
                    {
                        dd.ADevengarVigenteAum = delta.creditoADevengar;
                        this.ADevengarVigenteAum += dd.ADevengarVigenteAum;
                        dd.CapitalACobrarVigenteAum = delta.creditoCapital;
                        this.CapitalACobrarVigenteAum += dd.CapitalACobrarVigenteAum;
                        dd.InteresACobrarVigenteAum = delta.creditoInteres;
                        this.InteresACobrarVigenteAum += dd.InteresACobrarVigenteAum;

                        if (!cuotaPrimeraVez)
                        {
                            dd.ADevengarVencidoDis = delta.creditoADevengar + delta.deltaADevengarAum - delta.deltaADevengarDis;
                            this.ADevengarVencidoDis += dd.ADevengarVencidoDis;
                            dd.CapitalACobrarVencidoDis = delta.creditoCapital + delta.deltaCapital;
                            this.CapitalACobrarVencidoDis += dd.CapitalACobrarVencidoDis;
                            dd.InteresACobrarVencidoDis = delta.creditoInteres + delta.deltaInteres;
                            this.InteresACobrarVencidoDis += dd.InteresACobrarVencidoDis;

                            dd.CapitalVencidoCobrado = delta.deltaCapital;
                            this.CapitalVencidoCobrado += dd.CapitalVencidoCobrado;
                            dd.InteresVencidoCobrado = delta.deltaInteres;
                            this.InteresVencidoCobrado += dd.InteresVencidoCobrado;
                        }
                    }
                    #endregion modificar según el valor de antesEnMora y ahoraEnMora

                    this.DevengadoAum += dd.DevengadoAum;
                    this.DevengadoDis += dd.DevengadoDis;
                    this.EnSuspensoAum += dd.EnSuspensoAum;
                    this.EnSuspensoDis += dd.EnSuspensoDis;

                    #region calcular valores netos del detalle
                    dd.ADevengarVigente += dd.ADevengarVigenteAum - dd.ADevengarVigenteDis;
                    dd.ADevengarVencido += dd.ADevengarVencidoAum - dd.ADevengarVencidoDis;
                    dd.Devengado += dd.DevengadoAum - dd.DevengadoDis;
                    dd.EnSuspenso += dd.EnSuspensoAum - dd.EnSuspensoDis;
                    dd.CapitalACobrarVigente += dd.CapitalACobrarVigenteAum - dd.CapitalACobrarVigenteDis;
                    dd.CapitalACobrarVencido += dd.CapitalACobrarVencidoAum - dd.CapitalACobrarVencidoDis;
                    dd.InteresACobrarVigente += dd.InteresACobrarVigenteAum - dd.InteresACobrarVigenteDis;
                    dd.InteresACobrarVencido += dd.InteresACobrarVencidoAum - dd.InteresACobrarVencidoDis;
                    #endregion calcular valores netos del detalle

                    if (!recalculo_por_borrado && this.ExisteEnDB)
                    {
                        dd.IniciarUsingSesion(this.sesion);
                        dd.Guardar();
                        dd.FinalizarUsingSesion();
                    }
                }
            }
            #endregion sumar resultados parciales del credito

            #region calcular valores netos del devengamiento
            this.ADevengarVigente += this.ADevengarVigenteAum - this.ADevengarVigenteDis;
            this.ADevengarVencido += this.ADevengarVencidoAum - this.ADevengarVencidoDis;
            this.Devengado += this.DevengadoAum - this.DevengadoDis;
            this.EnSuspenso += this.EnSuspensoAum - this.EnSuspensoDis;
            this.CapitalACobrarVigente += this.CapitalACobrarVigenteAum - this.CapitalACobrarVigenteDis;
            this.CapitalACobrarVencido += this.CapitalACobrarVencidoAum - this.CapitalACobrarVencidoDis;
            this.InteresACobrarVigente += this.InteresACobrarVigenteAum - this.InteresACobrarVigenteDis;
            this.InteresACobrarVencido += this.InteresACobrarVencidoAum - this.InteresACobrarVencidoDis;
            #endregion calcular valores netos del devengamiento y la variacion
        }
        #endregion CalcularMontos

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._canal_venta = null;
            this._moneda = null;
            this._persona_relacionada = null;
            this._region = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override DevengamientosService[] Buscar(Filtro[] filtros)
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
                        case Modelo.CANAL_VENTA_IDColumnName:
                        case Modelo.PERSONA_RELACIONADA_IDColumnName:
                        case Modelo.REGION_IDColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            break;
                        case Modelo.EXISTE_PERSONA_RELACIONADAColumnName:
                            if(f.Comparacion.ToUpper() == "IS") 
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            else
                                sb.Append("upper(" + f.Columna + ") " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "'");
                            break;
                        case Modelo.FECHAColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            CTB_DEVENGAMIENTOSRow[] rows = sesion.db.CTB_DEVENGAMIENTOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            DevengamientosService[] d = new DevengamientosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                d[i] = new DevengamientosService(rows[i]);
            return d;
        }
        #endregion Buscar

        #region GetAnterior
        public static DevengamientosService GetAnterior(DevengamientosService devengamiento)
        {
            string sql = "select nvl(max(" + Modelo.IDColumnName + "), -1) " +
                         "  from " + Nombre_Tabla +
                         " where trunc(" + Modelo.FECHAColumnName + ") < to_date('" + devengamiento.Fecha.ToShortDateString() + "', 'dd/mm/yyyy')" +
                         "   and " + Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'";
            
            if (devengamiento.CanalVentaId.HasValue)
                sql += " and " + Modelo.CANAL_VENTA_IDColumnName + " = " + devengamiento.CanalVentaId.Value;
            else
                sql += " and " + Modelo.CANAL_VENTA_IDColumnName + " is null";

            if (devengamiento.ExistePersonaRelacionada.Length <= 0)
                sql += " and nvl(" + Modelo.EXISTE_PERSONA_RELACIONADAColumnName + ",'') || 'X' = 'X'"; //Se concatena la X para evaluar tanto que sea null como que sea cadena vacía
            else
                sql += " and " + Modelo.EXISTE_PERSONA_RELACIONADAColumnName + " = '" + devengamiento.ExistePersonaRelacionada + "'";

            if (devengamiento.PersonaRelacionadaId.HasValue)
                sql += " and " + Modelo.PERSONA_RELACIONADA_IDColumnName + " = " + devengamiento.PersonaRelacionadaId.Value;
            else
                sql += " and " + Modelo.PERSONA_RELACIONADA_IDColumnName + " is null";

            if (devengamiento.RegionId.HasValue)
                sql += " and " + Modelo.REGION_IDColumnName + " = " + devengamiento.RegionId.Value;
            else
                sql += " and " + Modelo.REGION_IDColumnName + " is null";
            
            DataTable dt = devengamiento.sesion.db.EjecutarQuery(sql);

            if ((decimal)dt.Rows[0][0] != Definiciones.Error.Valor.EnteroPositivo)
                return new DevengamientosService((decimal)dt.Rows[0][0], devengamiento.sesion);
            else
                return null;
        }
        #endregion GetAnterior

        #region GetFechaMaxima
        public static DateTime GetFechaMaxima(DevengamientosService devengamiento)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFechaMaxima(devengamiento, sesion);
            }
        }

        public static DateTime GetFechaMaxima(DevengamientosService devengamiento, SessionService sesion)
        {
            string sql;

            if (devengamiento == null)
                devengamiento = DevengamientosService.Instancia;

            //Tomar segun cual exista: la maxima fecha de devengamiento, o la minima fecha de vencimiento de cuota, o DateTime.MinValue
            sql = "select trunc(coalesce((";

            sql += "select max(" + Modelo.FECHAColumnName + ") from " + Nombre_Tabla + " where " + Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'";
            if (devengamiento.CanalVentaId.HasValue)
                sql += " and " + Modelo.CANAL_VENTA_IDColumnName + " = " + devengamiento.CanalVentaId.Value;
            else
                sql += " and " + Modelo.CANAL_VENTA_IDColumnName + " is null";

            if (devengamiento.ExistePersonaRelacionada.Length <= 0)
                sql += " and nvl(" + Modelo.EXISTE_PERSONA_RELACIONADAColumnName + ",'') = ''";
            else
                sql += " and " + Modelo.EXISTE_PERSONA_RELACIONADAColumnName + " = '" + devengamiento.ExistePersonaRelacionada + "'";

            if (devengamiento.PersonaRelacionadaId.HasValue)
                sql += " and " + Modelo.PERSONA_RELACIONADA_IDColumnName + " = " + devengamiento.PersonaRelacionadaId.Value;
            else
                sql += " and " + Modelo.PERSONA_RELACIONADA_IDColumnName + " is null";

            if (devengamiento.RegionId.HasValue)
                sql += " and " + Modelo.REGION_IDColumnName + " = " + devengamiento.RegionId.Value;
            else
                sql += " and " + Modelo.REGION_IDColumnName + " is null";
            
            sql += "),(" +
               "select min(" + CuentaCorrientePersonasService.FechaVencimiento_NombreCol + ") from (" + 
               "select " + CuentaCorrientePersonasService.FechaVencimiento_NombreCol + " from " + CuentaCorrientePersonasService.Nombre_Tabla + " where " + CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol + " is not null and " + CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
               " union " +
               "select " + CreditosService.Modelo.FECHA_RETIROColumnName + " from " + CreditosService.Nombre_Tabla +
               ")" +
               "), to_date('" + DateTime.MinValue.ToShortDateString() + "', 'dd/mm/yyyy'))) from dual";
            DataTable dt = sesion.db.EjecutarQuery(sql);
            return (DateTime)dt.Rows[0][0];
        }
        #endregion GetFechaMaxima

        #region Accessors
        public static string Nombre_Tabla = "CTB_DEVENGAMIENTOS";
        public static string Nombre_Secuencia = "CTB_DEVENGAMIENTOS_SQC";
        #endregion Accessors
    }
}
