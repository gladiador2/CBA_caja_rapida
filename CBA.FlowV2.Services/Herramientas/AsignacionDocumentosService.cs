using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Activos;
using CBA.FlowV2.Services.TextosPredefinidos;
using System.Collections.Generic;
using System.Text;

namespace CBA.FlowV2.Services.Herramientas
{
    public class AsignacionDocumentosService : ClaseCBA<AsignacionDocumentosService>
    {
        #region Enumeracion
        public enum Tipo : int { Asignacion, Caso, Ctacte, Pagares, Cheques, Activos }
        #endregion Enumeracion

        #region FiltrosExtension
        public static class FiltroExtension
        {
            public const string FechaFinAsignada = "FechaFinAsignada";
        }
        #endregion FiltrosExtension

        #region Propiedades
        protected ASIGNACION_DOCUMENTOSRow row;
        protected ASIGNACION_DOCUMENTOSRow rowSinModificar;
        public class Modelo : ASIGNACION_DOCUMENTOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal? ActivoId { get { if (row.IsACTIVO_IDNull) return null; else return row.ACTIVO_ID; } set { this._activo = null; if (value.HasValue) row.ACTIVO_ID = value.Value; else row.IsACTIVO_IDNull = true; } }
        public decimal? CasoId { get { if (row.IsCASO_IDNull) return null; else return row.CASO_ID; } set { this._caso = null; if (value.HasValue) row.CASO_ID = value.Value; else row.IsCASO_IDNull = true; } }
        public decimal? CtacteBancoId { get { if (row.IsCTACTE_BANCO_IDNull) return null; else return row.CTACTE_BANCO_ID; } set { if (value.HasValue) row.CTACTE_BANCO_ID = value.Value; else row.IsCTACTE_BANCO_IDNull = true; } }
        public decimal? CtacteChequeRecibidoId { get { if (row.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return null; else return row.CTACTE_CHEQUE_RECIBIDO_ID; } set { if (value.HasValue) row.CTACTE_CHEQUE_RECIBIDO_ID = value.Value; else row.IsCTACTE_CHEQUE_RECIBIDO_IDNull = true; } }
        public decimal? CtactePagareId { get { if (row.IsCTACTE_PAGARE_IDNull) return null; else return row.CTACTE_PAGARE_ID; } set { if (value.HasValue) row.CTACTE_PAGARE_ID = value.Value; else row.IsCTACTE_PAGARE_IDNull = true; } }
        public decimal? CtactePersonaId { get { if (row.IsCTACTE_PERSONA_IDNull) return null; else return row.CTACTE_PERSONA_ID; } set { this._ctacte_persona = null; if (value.HasValue) row.CTACTE_PERSONA_ID = value.Value; else row.IsCTACTE_PERSONA_IDNull = true; } }
        public decimal? DepositoId { get { if (row.IsDEPOSITO_IDNull) return null; else return row.DEPOSITO_ID; } set { if (value.HasValue) row.DEPOSITO_ID = value.Value; else row.IsDEPOSITO_IDNull = true; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public string ExisteAsignacionPosterior { get { return ClaseCBABase.GetStringHelper(row.EXISTE_ASIGNACION_POSTERIOR); } set { row.EXISTE_ASIGNACION_POSTERIOR = value; } }
        public DateTime FechaCreacion { get { return row.FECHA_CREACION; } set { row.FECHA_CREACION = value; } }
        public DateTime? FechaFin { get { if (row.IsFECHA_FINNull) return null; else return row.FECHA_FIN; } set { if (value.HasValue) row.FECHA_FIN = value.Value; else row.IsFECHA_FINNull = true; } }
        public DateTime FechaInicio { get { return row.FECHA_INICIO; } set { row.FECHA_INICIO = value; } }
        public decimal? FuncionarioId { get { if (row.IsFUNCIONARIO_IDNull) return null; else return row.FUNCIONARIO_ID; } set { this._funcionario = null; if (value.HasValue) row.FUNCIONARIO_ID = value.Value; else row.IsFUNCIONARIO_IDNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string ObservacionFin { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION_FIN); } set { row.OBSERVACION_FIN = value; } }
        public string ObservacionInicio { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION_INICIO); } set { row.OBSERVACION_INICIO = value; } }
        public decimal? SucursalId { get { if (row.IsSUCURSAL_IDNull) return null; else return row.SUCURSAL_ID; } set { this._sucursal = null; if (value.HasValue) row.SUCURSAL_ID = value.Value; else row.IsSUCURSAL_IDNull = true; } }
        public decimal? TextoPredefinidoFinId { get { if (row.IsTEXTO_PREDEFINIDO_FIN_IDNull) return null; else return row.TEXTO_PREDEFINIDO_FIN_ID; } set { this._texto_predefinido_fin = null; if (value.HasValue) row.TEXTO_PREDEFINIDO_FIN_ID = value.Value; else row.IsTEXTO_PREDEFINIDO_FIN_IDNull = true; } }
        public decimal? TextoPredefinidoInicioId { get { if (row.IsTEXTO_PREDEFINIDO_INICIO_IDNull) return null; else return row.TEXTO_PREDEFINIDO_INICIO_ID; } set { this._texto_predefinido_inicio = null; if (value.HasValue) row.TEXTO_PREDEFINIDO_INICIO_ID = value.Value; else row.IsTEXTO_PREDEFINIDO_INICIO_IDNull = true; } }
        public decimal? UsuarioId { get { if (row.IsUSUARIO_IDNull) return null; else return row.USUARIO_ID; } set { if (value.HasValue) row.USUARIO_ID = value.Value; else row.IsUSUARIO_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private ActivosService _activo;
        public ActivosService Activo
        {
            get
            {
                if (this._caso == null)
                {
                    if (this.sesion != null)
                    {
                        this._activo = new ActivosService(this.ActivoId.Value, this.sesion);
                    }
                    else
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._activo = new ActivosService(this.ActivoId.Value, sesion);
                        }
                    }
                }
                return this._activo;
            }
        }

        private CasosService _caso;
        public CasosService Caso
        {
            get
            {
                if (this._caso == null)
                {
                    if (this.sesion != null)
                    {
                        this._caso = new CasosService(this.CasoId.Value, this.sesion);
                    }
                    else
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._caso = new CasosService(this.CasoId.Value, sesion);
                        }
                    }
                }
                return this._caso;
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
                        this._ctacte_persona = new CuentaCorrientePersonasService(this.CtactePersonaId.Value, this.sesion);
                    }
                    else
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._ctacte_persona = new CuentaCorrientePersonasService(this.CtactePersonaId.Value, sesion);
                        }
                    }
                }
                return this._ctacte_persona;
            }
        }

        private FuncionariosService _funcionario;
        public FuncionariosService Funcionario
        {
            get
            {
                if (this._funcionario == null)
                {
                    if (this.sesion != null)
                    {
                        this._funcionario = new FuncionariosService(this.FuncionarioId.Value, this.sesion);
                    }
                    else
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._funcionario = new FuncionariosService(this.FuncionarioId.Value, sesion);
                        }
                    }
                }
                return this._funcionario;
            }
        }

        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                {
                    if (this.sesion != null)
                    {
                        this._sucursal = new SucursalesService(this.SucursalId.Value, this.sesion);
                    }
                    else
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._sucursal = new SucursalesService(this.SucursalId.Value, sesion);
                        }
                    }
                }
                return this._sucursal;
            }
        }

        private TextosPredefinidosService _texto_predefinido_fin;
        public TextosPredefinidosService TextoPredefinidoFin
        {
            get
            {
                if (this._texto_predefinido_fin == null)
                {
                    if (this.sesion != null)
                    {
                        this._texto_predefinido_fin = new TextosPredefinidosService(this.TextoPredefinidoFinId.Value, this.sesion);
                    }
                    else
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._texto_predefinido_fin = new TextosPredefinidosService(this.TextoPredefinidoFinId.Value, sesion);
                        }
                    }
                }
                return this._texto_predefinido_fin;
            }
        }

        private TextosPredefinidosService _texto_predefinido_inicio;
        public TextosPredefinidosService TextoPredefinidoInicio
        {
            get
            {
                if (this._texto_predefinido_inicio == null)
                {
                    if (this.sesion != null)
                    {
                        this._texto_predefinido_inicio = new TextosPredefinidosService(this.TextoPredefinidoInicioId.Value, this.sesion);
                    }
                    else
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._texto_predefinido_inicio = new TextosPredefinidosService(this.TextoPredefinidoInicioId.Value, sesion);
                        }
                    }
                }
                return this._texto_predefinido_inicio;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.ASIGNACION_DOCUMENTOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ASIGNACION_DOCUMENTOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(ASIGNACION_DOCUMENTOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public AsignacionDocumentosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public AsignacionDocumentosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public AsignacionDocumentosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private AsignacionDocumentosService(ASIGNACION_DOCUMENTOSRow row)
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
                #region Actualizar existe asignacion posterior en registros anteriores
                List<Filtro> lFiltro = new List<Filtro>();
                lFiltro.Add(new Filtro() { Columna = Modelo.EXISTE_ASIGNACION_POSTERIORColumnName, Valor = Definiciones.SiNo.No } );
                if (this.ActivoId.HasValue)
                    lFiltro.Add(new Filtro() { Columna = Modelo.ACTIVO_IDColumnName, Valor = this.ActivoId.Value } );
                else if (this.CasoId.HasValue)
                    lFiltro.Add(new Filtro() { Columna = Modelo.CASO_IDColumnName, Valor = this.CasoId.Value } );
                else if (this.CtacteChequeRecibidoId.HasValue)
                    lFiltro.Add(new Filtro() { Columna = Modelo.CTACTE_CHEQUE_RECIBIDO_IDColumnName, Valor = this.CtacteChequeRecibidoId.Value } );
                else if (this.CtactePagareId.HasValue)
                    lFiltro.Add(new Filtro() { Columna = Modelo.CTACTE_PAGARE_IDColumnName, Valor = this.CtactePagareId.Value } );
                else if (this.CtactePersonaId.HasValue)
                    lFiltro.Add(new Filtro() { Columna = Modelo.CTACTE_PERSONA_IDColumnName, Valor = this.CtactePersonaId.Value } );
                else
                    throw new Exception("ActualizarExistePosterior. Tipo de asignacion no implementada.");

                foreach (var ad in this.GetFiltrado<AsignacionDocumentosService>(lFiltro))
	            {
                    ad.IniciarUsingSesion(this.sesion);
            	    ad.ExisteAsignacionPosterior = Definiciones.SiNo.Si;
	                ad.Guardar();
                    ad.FinalizarUsingSesion();
                }
                #endregion Actualizar existe asignacion posterior en registros anteriores

                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.ExisteAsignacionPosterior = Definiciones.SiNo.No;
                this.Estado = Definiciones.Estado.Activo;
                this.FechaCreacion = DateTime.Now;
                sesion.db.ASIGNACION_DOCUMENTOSCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
            }
            else
            {
                sesion.db.ASIGNACION_DOCUMENTOSCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.rowSinModificar.ToString(), this.row.ToString(), sesion);
            }

            //Si es un activo y cambia la sucursal, actualizar la sucursal del activo
            if (this.ActivoId.HasValue && this.SucursalId.HasValue)
            {
                if (!this.Activo.SucursalId.HasValue || this.Activo.SucursalId.Value != this.SucursalId.Value)
                {
                    //Este codigo debe ser cambiado cuando ActivosService herede de CBABase
                    ActivosService.ActualizarSucursal(this.ActivoId.Value, this.SucursalId, sesion);
                }
            }

            this.rowSinModificar = this.row.Clonar();

            return this.row.ID;
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            int contador = 0;
            if (this.ActivoId.HasValue)
                contador++;
            else if (this.CasoId.HasValue)
                contador++;
            else if (this.CtacteChequeRecibidoId.HasValue)
                contador++;
            else if (this.CtactePagareId.HasValue)
                contador++;
            else if (this.CtactePersonaId.HasValue)
                contador++;

            if (contador != 1)
                excepciones.Agregar("Cada asignación debe ser sobre sólo una entidad.");

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._activo = null;
            this._caso = null;
            this._ctacte_persona = null;
            this._funcionario = null;
            this._sucursal = null;
            this._texto_predefinido_fin = null;
            this._texto_predefinido_inicio = null;
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
        protected override AsignacionDocumentosService[] Buscar(Filtro[] filtros)
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
                        case Modelo.ACTIVO_IDColumnName:
                        case Modelo.CASO_IDColumnName:
                        case Modelo.CTACTE_BANCO_IDColumnName:
                        case Modelo.CTACTE_CHEQUE_RECIBIDO_IDColumnName:
                        case Modelo.CTACTE_PAGARE_IDColumnName:
                        case Modelo.CTACTE_PERSONA_IDColumnName:
                        case Modelo.DEPOSITO_IDColumnName:
                        case Modelo.FUNCIONARIO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.SUCURSAL_IDColumnName:
                        case Modelo.TEXTO_PREDEFINIDO_FIN_IDColumnName:
                        case Modelo.TEXTO_PREDEFINIDO_INICIO_IDColumnName:
                        case Modelo.USUARIO_IDColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            break;
                        case Modelo.FECHA_CREACIONColumnName:
                        case Modelo.FECHA_FINColumnName:
                        case Modelo.FECHA_INICIOColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        case Modelo.EXISTE_ASIGNACION_POSTERIORColumnName:
                        case Modelo.OBSERVACION_FINColumnName:
                        case Modelo.OBSERVACION_INICIOColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case FiltroExtension.FechaFinAsignada:
                            sb.Append(Modelo.FECHA_FINColumnName + " is " + ((bool)f.Valor ? "not" : string.Empty) + " null");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.FECHA_INICIOColumnName);
            ASIGNACION_DOCUMENTOSRow[] rows = sesion.db.ASIGNACION_DOCUMENTOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            AsignacionDocumentosService[] ad = new AsignacionDocumentosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                ad[i] = new AsignacionDocumentosService(rows[i]);

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

        #region AsignarRango
        public static void AsignarRango(AsignacionDocumentosService[] asignaciones)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    foreach (var ad in asignaciones)
                    {
                        try
                        {
                            ad.IniciarUsingSesion(sesion);
                            ad.Guardar();
                            ad.FinalizarUsingSesion();
                        }
                        catch
                        {
                            ad.FinalizarUsingSesion();
                            throw;
                        }
                    }
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public void AsignarRango(decimal[] entidades_asignadas, Tipo tipo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    this.AsignarRango(entidades_asignadas, tipo, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public void AsignarRango(decimal[] entidades_asignadas, Tipo tipo, SessionService sesion)
        {
            try
            {
                this.IniciarUsingSesion(sesion);

                //Previene que un ID haya sido seleccionado mas de una vez
                List<decimal> lTabu = new List<decimal>();

                switch (tipo)
                {
                    case Tipo.Asignacion:
                        for (int i = 0; i < entidades_asignadas.Length; i++)
                        {
                            if (lTabu.Contains(entidades_asignadas[i]))
                                continue;
                            else
                                lTabu.Add(entidades_asignadas[i]);

                            this.Id = Definiciones.Error.Valor.EnteroPositivo;
                            
                            var ad = this.Get<AsignacionDocumentosService>(entidades_asignadas[i]);
                            this.ActivoId = ad.ActivoId;
                            this.CasoId = ad.CasoId;
                            this.CtacteChequeRecibidoId = ad.CtacteChequeRecibidoId;
                            this.CtactePagareId = ad.CtactePagareId;
                            this.CtactePersonaId = ad.CtactePersonaId;
                            
                            this.Guardar();
                        }
                        break;
                    case Tipo.Activos:
                        for (int i = 0; i < entidades_asignadas.Length; i++)
                        {
                            if (lTabu.Contains(entidades_asignadas[i]))
                                continue;
                            else
                                lTabu.Add(entidades_asignadas[i]);
                            
                            this.Id = Definiciones.Error.Valor.EnteroPositivo;
                            this.ActivoId = entidades_asignadas[i];
                            this.Guardar();
                        }
                        break;
                    case Tipo.Caso:
                        for (int i = 0; i < entidades_asignadas.Length; i++)
                        {
                            if (lTabu.Contains(entidades_asignadas[i]))
                                continue;
                            else
                                lTabu.Add(entidades_asignadas[i]);

                            this.Id = Definiciones.Error.Valor.EnteroPositivo;
                            this.CasoId = entidades_asignadas[i];
                            this.Guardar();
                        }
                        break;
                    case Tipo.Cheques:
                        for (int i = 0; i < entidades_asignadas.Length; i++)
                        {
                            if (lTabu.Contains(entidades_asignadas[i]))
                                continue;
                            else
                                lTabu.Add(entidades_asignadas[i]);

                            this.Id = Definiciones.Error.Valor.EnteroPositivo;
                            this.CtacteChequeRecibidoId = entidades_asignadas[i];
                            this.Guardar();
                        }
                        break;
                    case Tipo.Ctacte:
                        for (int i = 0; i < entidades_asignadas.Length; i++)
                        {
                            if (lTabu.Contains(entidades_asignadas[i]))
                                continue;
                            else
                                lTabu.Add(entidades_asignadas[i]);

                            this.Id = Definiciones.Error.Valor.EnteroPositivo;
                            this.CtactePersonaId = entidades_asignadas[i];
                            this.Guardar();
                        }
                        break;
                        
                    case Tipo.Pagares:
                        for (int i = 0; i < entidades_asignadas.Length; i++)
                        {
                            if (lTabu.Contains(entidades_asignadas[i]))
                                continue;
                            else
                                lTabu.Add(entidades_asignadas[i]); 
                            
                            this.Id = Definiciones.Error.Valor.EnteroPositivo;
                            this.CtactePagareId = entidades_asignadas[i];
                            this.Guardar();
                        }
                        break;
                    default:
                        throw new Exception("AsignarRango. Tipo no implementado.");
                }
                this.FinalizarUsingSesion();
            }
            catch
            {
                this.FinalizarUsingSesion();
                throw;
            }
        }
        #endregion AsignarRango

        #region DesasignarRango
        public void DesasignarRango(decimal[] entidades_asignadas, Tipo tipo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    this.DesasignarRango(entidades_asignadas, tipo, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public void DesasignarRango(decimal[] entidades_desasignadas, Tipo tipo, SessionService sesion)
        {
            try
            {
                this.IniciarUsingSesion(sesion);
                Filtro fExisteFechaFin = new Filtro() { Columna = FiltroExtension.FechaFinAsignada, Valor = false };
                Filtro fExistePosterior = new Filtro() { Columna = Modelo.EXISTE_ASIGNACION_POSTERIORColumnName, Valor = Definiciones.SiNo.No };
                Filtro fEntidadId = new Filtro();

                //Previene que un ID haya sido seleccionado mas de una vez
                List<decimal> lTabu = new List<decimal>();

                switch (tipo)
                {
                    case Tipo.Asignacion:
                        fEntidadId.Columna = Modelo.IDColumnName;
                        break;
                    case Tipo.Activos:
                        fEntidadId.Columna = Modelo.ACTIVO_IDColumnName;
                        break;
                    case Tipo.Caso:
                        fEntidadId.Columna = Modelo.CASO_IDColumnName;
                        break;
                    case Tipo.Cheques:
                        fEntidadId.Columna = Modelo.CTACTE_CHEQUE_RECIBIDO_IDColumnName;
                        break;
                    case Tipo.Ctacte:
                        fEntidadId.Columna = Modelo.CTACTE_PERSONA_IDColumnName;
                        break;
                    case Tipo.Pagares:
                        fEntidadId.Columna = Modelo.CTACTE_PAGARE_IDColumnName;
                        break;
                    default:
                        throw new Exception("DesasignarRango. Tipo no implementado.");
                }

                for (int i = 0; i < entidades_desasignadas.Length; i++)
                {
                    if (lTabu.Contains(entidades_desasignadas[i]))
                        continue;
                    else
                        lTabu.Add(entidades_desasignadas[i]);

                    fEntidadId.Valor = entidades_desasignadas[i];
                    var asignacion = this.GetPrimero<AsignacionDocumentosService>(new Filtro[] { fEntidadId, fExistePosterior });
                    if (asignacion == null)
                        throw new Exception("Asignación del ítem " + (i+1) + " no encontrada.");

                    try
                    {
                        asignacion.IniciarUsingSesion(sesion);
                        asignacion.FechaFin = this.FechaFin;
                        asignacion.TextoPredefinidoFinId = this.TextoPredefinidoFinId;
                        asignacion.ObservacionFin = this.ObservacionFin;
                        asignacion.Guardar();
                        asignacion.FinalizarUsingSesion();
                    }
                    catch
                    {
                        asignacion.FinalizarUsingSesion();
                        throw;
                    }
                }

                this.FinalizarUsingSesion();
            }
            catch
            {
                this.FinalizarUsingSesion();
                throw;
            }
        }
        #endregion DesasignarRango

        #region Accessors
        public static string Nombre_Tabla = "ASIGNACION_DOCUMENTOS";
        public static string Nombre_Secuencia = "ASIGNACION_DOCUMENTOS_SQC";
        #endregion Accessors
    }
}
