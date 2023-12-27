#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using System.Collections.Generic;
using System.Text;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteCuentasBancariasMovimientosService : ClaseCBA<CuentaCorrienteCuentasBancariasMovimientosService>
    {
        #region Implementacion de Filtros
        public class FiltroCuentaBancariaMovimiento : Filtro
        {
            public new static FiltroCuentaBancariaMovimiento[] FiltrosDisponibles
            {
                get
                {
                    return new FiltroCuentaBancariaMovimiento[] 
                    {
                        new FiltroCuentaBancariaMovimiento{ Nombre = "Caso", Columna = Modelo.CASO_IDColumnName},
                        new FiltroCuentaBancariaMovimiento{ Nombre = "Conciliado", Columna = Modelo.CONCILIADOColumnName},
                        new FiltroCuentaBancariaMovimiento{ Nombre = "Cuenta", Columna = Modelo.CTACTE_BANCARIA_IDColumnName},
                        new FiltroCuentaBancariaMovimiento{ Nombre = "Fecha", Columna = Modelo.FECHAColumnName},
                        new FiltroCuentaBancariaMovimiento{ Nombre = "Ingreso", Columna = Modelo.INGRESOColumnName},
                        new FiltroCuentaBancariaMovimiento{ Nombre = "Egreso", Columna = Modelo.EGRESOColumnName},
                        new FiltroCuentaBancariaMovimiento{ Nombre = "Observación", Columna = Modelo.OBSERVACIONColumnName, Exacto = false},
                        new FiltroCuentaBancariaMovimiento{ Nombre = "Usuario", Columna = Modelo.USUARIO_IDColumnName},
                    };
                }
            }

            public override string ToString()
            {
                string texto = string.Empty;

                if (this.Valor.ToString().Length == 0)
                    return texto;

                switch (this.Columna)
                {
                    case Modelo.CASO_IDColumnName:
                    case Modelo.IDColumnName:
                        if (this.Exacto)
                            texto = this.Nombre + " es " + this.Valor;
                        else
                            texto = this.Nombre + " está en " + string.Join(",", Array.ConvertAll((decimal[])this.Valor, i => i.ToString()));
                        break;
                    case Modelo.CTACTE_BANCARIA_IDColumnName:
                        if (this.Exacto)
                            texto = this.Nombre + " es " + new CuentaCorrienteCuentasBancariasService((decimal)this.Valor).NumeroCuenta;
                        else
                            texto = this.Nombre + " está en " + string.Join(",", Array.ConvertAll((decimal[])this.Valor, i => new CuentaCorrienteCuentasBancariasService(i).NumeroCuenta));
                        break;
                    case Modelo.USUARIO_IDColumnName:
                        if (this.Exacto)
                            texto = this.Nombre + " es " + new UsuariosService((decimal)this.Valor).Usuario;
                        else
                            texto = this.Nombre + " está en " + string.Join(",", Array.ConvertAll((decimal[])this.Valor, i => new UsuariosService((decimal)this.Valor).Usuario));
                        break;
                    case Modelo.EGRESOColumnName:
                    case Modelo.INGRESOColumnName:
                        texto = this.Nombre + " " + this.Comparacion + " " + this.Valor;
                        break;
                    case Modelo.CONCILIADOColumnName:
                        texto = this.Columna + " " + (this.Valor.ToString() == Definiciones.SiNo.Si ? "Sí" : "No");
                        break;
                    case Modelo.OBSERVACIONColumnName:
                        if (this.Exacto)
                            texto = this.Columna + " es " + this.Valor;
                        else
                            texto = this.Columna + " contiene " + this.Valor;
                        break;
                    case Modelo.CONCILIADO_FECHAColumnName:
                    case Modelo.DESCONCILIADO_FECHAColumnName:
                    case Modelo.FECHA_INSERCIONColumnName:
                    case Modelo.FECHAColumnName:
                        texto = this.Columna + " " + this.Comparacion + " " + ((DateTime)this.Valor).ToShortDateString();
                        break;
                }

                return texto;
            }
        }
        #endregion Implementacion de Filtros

        #region Propiedades
        protected CTACTE_BANCARIAS_MOVRow row;
        protected CTACTE_BANCARIAS_MOVRow rowSinModificar;
        public class Modelo : CTACTE_BANCARIAS_MOVCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal? AjusteBancarioId { get { if (row.IsAJUSTE_BANCARIO_IDNull) return null; return row.AJUSTE_BANCARIO_ID; } set { if (value.HasValue) row.AJUSTE_BANCARIO_ID = value.Value; else row.IsAJUSTE_BANCARIO_IDNull = true; } }
        public decimal? CasoId { get { if (row.IsCASO_IDNull) return null; return row.CASO_ID; } set { if (value.HasValue) row.CASO_ID = value.Value; else row.IsCASO_IDNull = true; } }
        public string Conciliado { get { return row.CONCILIADO; } private set { row.CONCILIADO = value; } }
        public DateTime? ConciliadoFecha { get { if (row.IsCONCILIADO_FECHANull) return null; return row.CONCILIADO_FECHA; } private set { if (value.HasValue) row.CONCILIADO_FECHA = value.Value; else row.IsCONCILIADO_FECHANull = true; } }
        public decimal? ConciliadoUsuarioId { get { if (row.IsCONCILIADO_USUARIO_IDNull) return null; return row.CONCILIADO_USUARIO_ID; } private set { if (value.HasValue) row.CONCILIADO_USUARIO_ID = value.Value; else row.IsCONCILIADO_USUARIO_IDNull = true; } }
        public decimal CotizacionMoneda { get { return row.COTIZACION_MONEDA; } set { row.COTIZACION_MONEDA = value; } }
        public decimal CtacteBancariaId { get { return row.CTACTE_BANCARIA_ID; } set { row.CTACTE_BANCARIA_ID = value; } }
        public decimal? CtacteCajaSucursalId { get { if (row.IsCTACTE_CAJA_SUCURSAL_IDNull) return null; return row.CTACTE_CAJA_SUCURSAL_ID; } set { if (value.HasValue) row.CTACTE_CAJA_SUCURSAL_ID = value.Value; else row.IsCTACTE_CAJA_SUCURSAL_IDNull = true; } }
        public decimal? CustodiaValoresId { get { if (row.IsCUSTODIA_VALORES_IDNull) return null; return row.CUSTODIA_VALORES_ID; } set { if (value.HasValue) row.CUSTODIA_VALORES_ID = value.Value; else row.IsCUSTODIA_VALORES_IDNull = true; } }
        public decimal? DepositoBancarioId { get { if (row.IsDEPOSITO_BANCARIO_IDNull) return null; return row.DEPOSITO_BANCARIO_ID; } set { if (value.HasValue) row.DEPOSITO_BANCARIO_ID = value.Value; else row.IsDEPOSITO_BANCARIO_IDNull = true; } }
        public DateTime? DesconciliadoFecha { get { if (row.IsDESCONCILIADO_FECHANull) return null; return row.DESCONCILIADO_FECHA; } private set { if (value.HasValue) row.DESCONCILIADO_FECHA = value.Value; else row.IsDESCONCILIADO_FECHANull = true; } }
        public decimal? DesconciliadoUsuarioId { get { if (row.IsDESCONCILIADO_USUARIO_IDNull) return null; return row.DESCONCILIADO_USUARIO_ID; } set { if (value.HasValue) row.DESCONCILIADO_USUARIO_ID = value.Value; else row.IsDESCONCILIADO_USUARIO_IDNull = true; } }
        public decimal? DescuentoDocumentoId { get { if (row.IsDESCUENTO_DOCUMENTO_IDNull) return null; return row.DESCUENTO_DOCUMENTO_ID; } set { if (value.HasValue) row.DESCUENTO_DOCUMENTO_ID = value.Value; else row.IsDESCUENTO_DOCUMENTO_IDNull = true; } }
        public decimal Egreso { get { return row.EGRESO; } set { row.EGRESO = value; } }
        public decimal? EgresoVarioCajaId { get { if (row.IsEGRESO_VARIO_CAJA_IDNull) return null; return row.EGRESO_VARIO_CAJA_ID; } set { if (value.HasValue) row.EGRESO_VARIO_CAJA_ID = value.Value; else row.IsEGRESO_VARIO_CAJA_IDNull = true; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public DateTime FechaInsercion { get { return row.FECHA_INSERCION; } set { row.FECHA_INSERCION = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal Ingreso { get { return row.INGRESO; } set { row.INGRESO = value; } }
        public decimal? MovimientoVarioTesoreriaId { get { if (row.IsMOVIMIENTO_VARIO_TESORERIA_IDNull) return null; return row.MOVIMIENTO_VARIO_TESORERIA_ID; } set { if (value.HasValue) row.MOVIMIENTO_VARIO_TESORERIA_ID = value.Value; else row.IsMOVIMIENTO_VARIO_TESORERIA_IDNull = true; } }
        public string Observacion { get { return row.OBSERVACION; } set { row.OBSERVACION = value; } }
        public decimal? OrdenPagoId { get { if (row.IsORDEN_PAGO_IDNull) return null; return row.ORDEN_PAGO_ID; } set { if (value.HasValue) row.ORDEN_PAGO_ID = value.Value; else row.IsORDEN_PAGO_IDNull = true; } }
        public decimal? Saldo { get { if (row.IsSALDONull) return null; return row.SALDO; } set { if (value.HasValue) row.SALDO = value.Value; else row.IsSALDONull = true; } }
        public decimal? TransferenciaBancariaId { get { if (row.IsTRANSFERENCIA_BANCARIA_IDNull) return null; return row.TRANSFERENCIA_BANCARIA_ID; } set { if (value.HasValue) row.TRANSFERENCIA_BANCARIA_ID = value.Value; else row.IsTRANSFERENCIA_BANCARIA_IDNull = true; } }
        public decimal UsuarioId { get { return row.USUARIO_ID; } set { row.USUARIO_ID = value; } }
        public decimal? CtacteChequeGiradoId { get { if (row.IsCTACTE_CHEQUE_GIRADO_IDNull) return null; return row.CTACTE_CHEQUE_GIRADO_ID; } set { if (value.HasValue) row.CTACTE_CHEQUE_GIRADO_ID = value.Value; else row.IsCTACTE_CHEQUE_GIRADO_IDNull = true; } }
        public decimal? CtacteChequeRecibidoId { get { if (row.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return null; return row.CTACTE_CHEQUE_RECIBIDO_ID; } set { if (value.HasValue) row.CTACTE_CHEQUE_RECIBIDO_ID = value.Value; else row.IsCTACTE_CHEQUE_RECIBIDO_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private UsuariosService _usuario;
        public UsuariosService Usuario
        {
            get
            {
                if (this._usuario == null)
                    this._usuario = new UsuariosService(this.UsuarioId);
                return this._usuario;
            }
        }

        private CuentaCorrienteCuentasBancariasService _ctacteBancaria;
        public CuentaCorrienteCuentasBancariasService CtacteBancaria
        {
            get
            {
                if (this._ctacteBancaria == null)
                    this._ctacteBancaria = new CuentaCorrienteCuentasBancariasService(this.CtacteBancariaId);
                return this._ctacteBancaria;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_BANCARIAS_MOVCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_BANCARIAS_MOVRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CTACTE_BANCARIAS_MOVRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CuentaCorrienteCuentasBancariasMovimientosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrienteCuentasBancariasMovimientosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CuentaCorrienteCuentasBancariasMovimientosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private CuentaCorrienteCuentasBancariasMovimientosService(CTACTE_BANCARIAS_MOVRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        //TODO: cambiar los lugares donde se llama a Guarar pasando a orientacion a objeto
        #region Guardar
        /// <summary>
        /// Guardars the specified ctacte_bancaria_id.
        /// </summary>
        /// <param name="ctacte_bancaria_id">The ctacte_bancaria_id.</param>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="ctacte_caja_sucursal_id">The ctacte_caja_sucursal_id.</param>
        /// <param name="registro_id">The registro_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <param name="monto">The monto.</param>
        /// <param name="cotizacion">The cotizacion.</param>
        /// <param name="observacion">The observacion.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Guardar(decimal ctacte_bancaria_id, int flujo_id, decimal caso_id, decimal ctacte_caja_sucursal_id, decimal registro_id, decimal moneda_id, decimal monto, decimal cotizacion, DateTime fecha, string observacion, decimal? ctacte_cheque_girado_id, decimal? ctacte_cheque_recibido_id, bool es_reversion, SessionService sesion)
        {
            CuentaCorrienteCuentasBancariasMovimientosService m = null;

            try
            {
                m = new CuentaCorrienteCuentasBancariasMovimientosService();
                m.IniciarUsingSesion(sesion);

                m.CtacteBancariaId = ctacte_bancaria_id;
                
                m.Fecha = fecha;
                if (es_reversion && VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.CuentaBancariaMovimientoReversionFechaAccion) == Definiciones.SiNo.Si)
                    m.Fecha = DateTime.Now;

                m.CotizacionMoneda = cotizacion;
                m.Observacion = observacion;
                m.UsuarioId = sesion.Usuario.ID;
                m.FechaInsercion = DateTime.Now;
                m.Conciliado = Definiciones.SiNo.No;
                m.Saldo = 0; //El campo sera eliminado proximamente
                m.CtacteChequeGiradoId = ctacte_cheque_girado_id;
                m.CtacteChequeRecibidoId = ctacte_cheque_recibido_id;

                if (ctacte_caja_sucursal_id != Definiciones.Error.Valor.EnteroPositivo)
                    m.CtacteCajaSucursalId = ctacte_caja_sucursal_id;

                if (caso_id != Definiciones.Error.Valor.EnteroPositivo)
                    m.CasoId = caso_id;

                if (!flujo_id.Equals(Definiciones.Error.Valor.IntPositivo))
                {
                    switch (flujo_id)
                    {
                        case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                            m.OrdenPagoId = registro_id;
                            break;
                        case Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA:
                            m.TransferenciaBancariaId = registro_id;
                            break;
                        case Definiciones.FlujosIDs.AJUSTE_BANCARIO:
                            m.AjusteBancarioId = registro_id;
                            break;
                        case Definiciones.FlujosIDs.DEPOSITO_BANCARIO:
                            m.DepositoBancarioId = registro_id;
                            break;
                        case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS:
                            m.DescuentoDocumentoId = registro_id;
                            break;
                        case Definiciones.FlujosIDs.EGRESO_VARIO_CAJA:
                            m.EgresoVarioCajaId = registro_id;
                            break;
                        case Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA:
                            m.MovimientoVarioTesoreriaId = registro_id;
                            break;
                        case Definiciones.FlujosIDs.PAGO_DE_PERSONAS:
                        case Definiciones.FlujosIDs.ANTICIPO_PERSONA:
                            //No se registra en una columna particular, se vincula solo por caso_id
                            break;
                        default:
                            throw new Exception("Error en CtacteBancariaMovimietnos.Guardar(). No hay implementacion para el flujo " + flujo_id);
                    }
                }

                //Si el monto es negativo fue un egreso
                if (monto < 0)
                {
                    m.Egreso = monto * (-1); //Se convierte el monto a positivo
                    m.Ingreso = 0;
                }
                else
                {
                    m.Egreso = 0;
                    m.Ingreso = monto;
                }

                m.Guardar();
                m.FinalizarUsingSesion();
            }
            catch (Exception exp)
            {
                m.FinalizarUsingSesion();
                throw exp;
            }
        }
        #endregion Guardar

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();

            if (!this.ExisteEnDB)
            {
                this.row.ID = sesion.db.GetSiguienteSecuencia("ctacte_bancarias_mov_sqc");
                sesion.db.CTACTE_BANCARIAS_MOVCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.CTACTE_BANCARIAS_MOVCollection.Update(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.row.ToString(), this.rowSinModificar.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();

            return this.row.ID;
        }
        #endregion Guardar

        #region Borrar
        public void Borrar(SessionService sesion)
        {
            sesion.db.CTACTE_BANCARIAS_MOVCollection.Delete(this.row);
        }
        #endregion Borrar

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
            this._ctacteBancaria = null;
            this._usuario = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override CuentaCorrienteCuentasBancariasMovimientosService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");

            Filtro fResumir = null;

            foreach (Filtro f in filtros)
            {
                if (f.Resumir)
                    fResumir = f;

                if (f.OrderBy)
                {
                    orden.Add(f.Columna + " " + f.Valor);
                }
                else
                {
                    if (f.Valor.ToString().Length <= 0)
                        continue;

                    sb.Append(" and ");
                    switch (f.Columna)
                    {
                        case Modelo.CASO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.CTACTE_BANCARIA_IDColumnName:
                        case Modelo.USUARIO_IDColumnName:
                            if(f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.EGRESOColumnName:
                        case Modelo.INGRESOColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            break;
                        case Modelo.CONCILIADOColumnName:
                        case Modelo.OBSERVACIONColumnName:
                            if(f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case Modelo.CONCILIADO_FECHAColumnName:
                        case Modelo.DESCONCILIADO_FECHAColumnName:
                        case Modelo.FECHA_INSERCIONColumnName:
                        case Modelo.FECHAColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.FECHAColumnName);
            CTACTE_BANCARIAS_MOVRow[] rows = sesion.db.CTACTE_BANCARIAS_MOVCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            CuentaCorrienteCuentasBancariasMovimientosService[] m = new CuentaCorrienteCuentasBancariasMovimientosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                m[i] = new CuentaCorrienteCuentasBancariasMovimientosService(rows[i]);

            if (fResumir != null && fResumir.Columna == Modelo.CASO_IDColumnName)
            {
                #region crear nuevos objetos para resumir
                int auxPK = Definiciones.Error.Valor.IntPositivo;
                CuentaCorrienteCuentasBancariasMovimientosService[] detallado = m;
                Dictionary<decimal, CuentaCorrienteCuentasBancariasMovimientosService> d = new Dictionary<decimal, CuentaCorrienteCuentasBancariasMovimientosService>();

                for (int i = 0; i < detallado.Length; i++)
                {
                    if (!detallado[i].CasoId.HasValue)
                    {
                        d.Add(auxPK--, detallado[i]);
                        continue;
                    }

                    if (d.ContainsKey(detallado[i].CasoId.Value))
                    {
                        CuentaCorrienteCuentasBancariasMovimientosService mParcial = d[detallado[i].CasoId.Value];
                        mParcial.Ingreso += detallado[i].Ingreso;
                        mParcial.Egreso += detallado[i].Egreso;

                        if (detallado[i].Observacion.Length > 0)
                            mParcial.Observacion += Environment.NewLine + detallado[i].Observacion;

                        //Si existen registros mixtos se unifica a no conciliado
                        if (mParcial.Conciliado == Definiciones.SiNo.Si && mParcial.Conciliado != detallado[i].Conciliado)
                            mParcial.Conciliado = Definiciones.SiNo.No;
                    }
                    else
                    {
                        d.Add(detallado[i].CasoId.Value, detallado[i]);
                    }
                }
                #endregion crear nuevos objetos para resumir

                m = new CuentaCorrienteCuentasBancariasMovimientosService[d.Count];
                d.Values.CopyTo(m, 0);
            }

            return m;
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

        #region Conciliar
        public void Conciliar()
        {
            Conciliar(false);
        }
        public void Conciliar(bool resumido)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);

                if(!RolesService.Tiene("CONCILIACION BANCARIA CONCILIAR"))
                    throw new Exception("No tiene permisos suficientes para conciliar.");

                if (resumido && this.CasoId.HasValue)
                { 
                    CuentaCorrienteCuentasBancariasMovimientosService[] m = this.GetFiltrado<CuentaCorrienteCuentasBancariasMovimientosService>(new Filtro { Columna = Modelo.CASO_IDColumnName, Valor = this.CasoId.Value });
                    for (int i = 0; i < m.Length; i++)
                        m[i].Conciliar(false);

                    this.Conciliado = Definiciones.SiNo.Si;
                    this.ConciliadoUsuarioId = sesion.Usuario.ID;
                    this.ConciliadoFecha = DateTime.Now;
                }
                else
                {
                    this.Conciliado = Definiciones.SiNo.Si;
                    this.ConciliadoUsuarioId = sesion.Usuario.ID;
                    this.ConciliadoFecha = DateTime.Now;
                    this.Guardar();
                }

                this.FinalizarUsingSesion();
            }
        }
        #endregion Conciliar

        #region Desconciliar
        public void Desconciliar()
        {
            Desconciliar(false);
        }
        public void Desconciliar(bool resumido)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);

                if (!RolesService.Tiene("CONCILIACION BANCARIA DESCONCILIAR"))
                    throw new Exception("No tiene permisos suficientes para desconciliar.");

                if (resumido && this.CasoId.HasValue)
                {
                    CuentaCorrienteCuentasBancariasMovimientosService[] m = this.GetFiltrado<CuentaCorrienteCuentasBancariasMovimientosService>(new Filtro { Columna = Modelo.CASO_IDColumnName, Valor = this.CasoId.Value });
                    for (int i = 0; i < m.Length; i++)
                        m[i].Desconciliar(false);

                    this.Conciliado = Definiciones.SiNo.No;
                    this.DesconciliadoUsuarioId = sesion.Usuario.ID;
                    this.DesconciliadoFecha = DateTime.Now;
                }
                else
                {
                    this.Conciliado = Definiciones.SiNo.No;
                    this.DesconciliadoUsuarioId = sesion.Usuario.ID;
                    this.DesconciliadoFecha = DateTime.Now;
                    this.Guardar();
                }

                this.FinalizarUsingSesion();
            }
        }
        #endregion Desconciliar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_BANCARIAS_MOV"; }
        }
        public static string Nombre_Vista
        {
            get { return "CTACTE_BANCARIAS_MOV_INFO_COMP"; }
        }
        public static string AjusteBancarioId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.AJUSTE_BANCARIO_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.CASO_IDColumnName; }
        }
        public static string Conciliado_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.CONCILIADOColumnName; }
        }
        public static string ConciliadoFecha_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.CONCILIADO_FECHAColumnName; }
        }
        public static string ConciliadoUsuarioId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.CONCILIADO_USUARIO_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteBancariaId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.CTACTE_BANCARIA_IDColumnName; }
        }
        public static string CtacteCajaSucursalId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        public static string CtacteChequeGiradoId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.CTACTE_CHEQUE_GIRADO_IDColumnName; }
        }
        public static string CtacteChequeRecibidoId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CustodiaValoresId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.CUSTODIA_VALORES_IDColumnName; }
        }
        public static string DepositoBancarioId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.DEPOSITO_BANCARIO_IDColumnName; }
        }
        public static string DesconciliadoFecha_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.DESCONCILIADO_FECHAColumnName; }
        }
        public static string DesconciliadoUsuarioId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.DESCONCILIADO_USUARIO_IDColumnName; }
        }
        public static string DescuentoDocumentoId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.DESCUENTO_DOCUMENTO_IDColumnName; }
        }
        public static string EgresoVarioCajaId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.EGRESO_VARIO_CAJA_IDColumnName; }
        }
        public static string Egreso_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.EGRESOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.FECHAColumnName; }
        }
        public static string FechaInsercion_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.FECHA_INSERCIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.IDColumnName; }
        }
        public static string Ingreso_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.INGRESOColumnName; }
        }
        public static string MovimientoVarioTesoreriaId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.MOVIMIENTO_VARIO_TESORERIA_IDColumnName; }
        }
        public static string ObservacionId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.OBSERVACIONColumnName; }
        }
        public static string OrdenPagoIdId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.ORDEN_PAGO_IDColumnName; }
        }
        public static string Saldo_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.SALDOColumnName; }
        }
        public static string TransferenciaBancariaId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.TRANSFERENCIA_BANCARIA_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return CTACTE_BANCARIAS_MOVCollection.USUARIO_IDColumnName; }
        }
        #endregion Accessors
    }
}
