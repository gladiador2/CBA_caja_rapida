#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;

using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Services.TextosPredefinidos;
using CBA.FlowV2.Services.Herramientas;
using System.Collections;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteCajaReservasDetalleService : ClaseCBA<CuentaCorrienteCajaReservasDetalleService>
    {
        #region Propiedades
        protected CTACTE_CAJA_RESERVAS_DETRow row;
        protected CTACTE_CAJA_RESERVAS_DETRow rowSinModificar;
        public class Modelo : CTACTE_CAJA_RESERVAS_DETCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal Cotizacion { get { return row.COTIZACION; } set { row.COTIZACION = value; } }
        public decimal CtacteCajaReservaId { get { return row.CTACTE_CAJA_RESERVA_ID; } set { row.CTACTE_CAJA_RESERVA_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal Monto { get { return row.MONTO; } set { row.MONTO = value; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal? TextoPredefinidoId { get { if (row.IsTEXTO_PREDEFINIDO_IDNull) return null; else return row.TEXTO_PREDEFINIDO_ID; } set { if (value.HasValue) row.TEXTO_PREDEFINIDO_ID = value.Value; else row.IsTEXTO_PREDEFINIDO_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CuentaCorrienteCajaReservasService _ctacte_caja_reserva;
        public CuentaCorrienteCajaReservasService CtacteCajaReserva
        {
            get
            {
                if (this._ctacte_caja_reserva == null)
                {
                    if (this.sesion != null)
                    {
                        this._ctacte_caja_reserva = new CuentaCorrienteCajaReservasService(this.CtacteCajaReservaId, this.sesion);
                    }
                    else
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            this._ctacte_caja_reserva = new CuentaCorrienteCajaReservasService(this.CtacteCajaReservaId, sesion);
                        }
                    }
                }
                return this._ctacte_caja_reserva;
            }
        }

        private TextosPredefinidosService _texto_predefinido;
        public TextosPredefinidosService TextoPredefinido
        {
            get
            {
                if (this._texto_predefinido == null)
                {
                    if(this.sesion != null)
                    {
                        this._texto_predefinido = new TextosPredefinidosService(this.TextoPredefinidoId.Value, this.sesion);
                    }
                    else
                    {
                        using(SessionService sesion = new SessionService())
                        {
                            this._texto_predefinido = new TextosPredefinidosService(this.TextoPredefinidoId.Value, sesion);
                        }
                    }
                }
                return this._texto_predefinido;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_CAJA_RESERVAS_DETCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_CAJA_RESERVAS_DETRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CTACTE_CAJA_RESERVAS_DETRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CuentaCorrienteCajaReservasDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrienteCajaReservasDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        internal CuentaCorrienteCajaReservasDetalleService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        internal CuentaCorrienteCajaReservasDetalleService(CTACTE_CAJA_RESERVAS_DETRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();

            //Actualizar la cotizacion segun la fecha
            this.CtacteCajaReserva.IniciarUsingSesion(sesion);
            this.Cotizacion = CotizacionesService.GetCotizacionMonedaCompra(this.CtacteCajaReserva.CtacteCajasSucursalOrigen.Sucursal.PaisId, this.CtacteCajaReserva.MonedaId, this.Fecha);
            this.CtacteCajaReserva.FinalizarUsingSesion();
            if (this.Cotizacion == Definiciones.Error.Valor.EnteroPositivo)
                throw new Exception("No existe una cotización actualizada para el " + this.Fecha.ToShortDateString() + ".");

            if (!this.ExisteEnDB)
            {
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.Estado = Definiciones.Estado.Activo;
                sesion.db.CTACTE_CAJA_RESERVAS_DETCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.CTACTE_CAJA_RESERVAS_DETCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), this.rowSinModificar.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();
            
            #region Afectar a la caja de sucursal
            Hashtable campos = new Hashtable();
            campos.Add(CuentaCorrienteCajaService.Fecha_NombreCol, this.Fecha);
            campos.Add(CuentaCorrienteCajaService.MonedaId_NombreCol, this.CtacteCajaReserva.MonedaId);
            campos.Add(CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, this.Cotizacion);
            campos.Add(CuentaCorrienteCajaService.Monto_NombreCol, (-1) * this.Monto);
            campos.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo);
            campos.Add(CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID);
            campos.Add(CuentaCorrienteCajaService.SucursalId_NombreCol, this.CtacteCajaReserva.CtacteCajasSucursalOrigen.SucursalId);
            campos.Add(CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, this.CtacteCajaReserva.CtacteCajasSucursalOrigen.FuncionarioId);
            campos.Add(CuentaCorrienteCajaService.CtacteCajaReservaDetId_NombreCol, this.Id.Value);
            campos.Add(CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, this.Monto > 0 ? Definiciones.CuentaCorrienteConceptos.EgresoPorTransferencia : Definiciones.CuentaCorrienteConceptos.IngresoPorTransferencia);
            campos.Add(CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, this.CtacteCajaReserva.CtacteCajaSucursalOrigenId);
            CuentaCorrienteCajaService.Guardar(campos, sesion);
            #endregion Afectar a la caja de sucursal

            this.CtacteCajaReserva.ResetearPropiedadesExtendidas();
            return this.row.ID;
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            if(this.CtacteCajaReserva.Estado != Definiciones.Estado.Activo)
                excepciones.Agregar("La reserva no se encuentra activa.");

            if (this.Monto == 0)
                excepciones.Agregar("El monto no puede ser cero.");

            if (this.CtacteCajaReserva.Saldo + this.Monto < 0)
                excepciones.Agregar("El saldo de la reserva es " + this.CtacteCajaReserva.Saldo.ToString(this.CtacteCajaReserva.Moneda.CadenaDecimales) + ".");

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._ctacte_caja_reserva = null;
            this._texto_predefinido = null;
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
        protected override CuentaCorrienteCajaReservasDetalleService[] Buscar(Filtro[] filtros)
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
                        case Modelo.CTACTE_CAJA_RESERVA_IDColumnName:
                        case Modelo.IDColumnName:
                            sb.Append(f.Columna + " = " + f.Valor);
                            break;
                        case Modelo.MONTOColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
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
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.FECHAColumnName);
            orden.Add(Modelo.IDColumnName);
            CTACTE_CAJA_RESERVAS_DETRow[] rows = sesion.db.CTACTE_CAJA_RESERVAS_DETCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            CuentaCorrienteCajaReservasDetalleService[] ccrd = new CuentaCorrienteCajaReservasDetalleService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                ccrd[i] = new CuentaCorrienteCajaReservasDetalleService(rows[i]);

            return ccrd;
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

        public static void TransladarSaldo(CuentaCorrienteCajaReservasService reserva, decimal saldo_inicial, SessionService sesion)
        {
            var reservaDestalle = new CuentaCorrienteCajaReservasDetalleService()
            {
                CtacteCajaReservaId = reserva.Id.Value,
                Fecha = reserva.Fecha,
                Monto = saldo_inicial,
                Observacion = "Translado de reserva proveniente de caja anterior.",
                Cotizacion = CotizacionesService.GetCotizacionMonedaCompra(reserva.CtacteCajasSucursalOrigen.Sucursal.PaisId, reserva.MonedaId, reserva.Fecha),
            };

            if (reservaDestalle.Cotizacion == Definiciones.Error.Valor.EnteroPositivo)
                throw new Exception("No existe una cotización actualizada para el " + reserva.Fecha.ToShortDateString() + ".");

            //Insertar en forma directa en vez de con el Guardar para evitar que se cree el egreso de la caja
            reservaDestalle.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
            reservaDestalle.Estado = Definiciones.Estado.Activo;
            sesion.db.CTACTE_CAJA_RESERVAS_DETCollection.Insert(reservaDestalle.row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, reservaDestalle.Id.Value, reservaDestalle.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
        }

        #region Accessors
        public static string Nombre_Tabla = "CTACTE_CAJA_RESERVAS_DET";
        public static string Nombre_Secuencia = "CTACTE_CAJA_RESERVAS_DET_SQC";
        #endregion Accessors
    }
}
