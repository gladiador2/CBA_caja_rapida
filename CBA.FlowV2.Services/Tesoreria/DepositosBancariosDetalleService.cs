using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.TextosPredefinidos;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class DepositosBancariosDetalleService
    {
        #region GetDepositosBancariosDetalleDataTable
        public static DataTable GetDepositosBancariosDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetDepositosBancariosDetalleDataTable(clausulas, orden, sesion);
            }
        }

        /// <summary>
        /// Gets the depositos bancarios detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetDepositosBancariosDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = DepositosBancariosDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;

            return sesion.Db.DEPOSITOS_BANCARIOS_DETCollection.GetAsDataTable(where, orden);
        }
        #endregion GetDepositosBancariosDetalleDataTable

        #region GetDepositosBancariosDetalleInfoCompleta
        /// <summary>
        /// Gets the depositos bancarios detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetDepositosBancariosDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetDepositosBancariosDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetDepositosBancariosDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            string where = DepositosBancariosDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;

            return sesion.Db.DEPOSITOS_BANC_DET_INFO_COMPLCollection.GetAsDataTable(where, orden);
        }
        #endregion GetDepositosBancariosDetalleInfoCompleta

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Guardar(campos, sesion);
                    sesion.CommitTransaction();
                }

                catch (Exception)
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }


        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static void Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                //Necesario para que haga rollback correctamente
                //Por algun motivo si hay una excepcion no borra el registro insertado
                DataTable dtDepositoBancario, dtChequeRecibido;
                int ctacteValorId;

                DEPOSITOS_BANCARIOS_DETRow row = new DEPOSITOS_BANCARIOS_DETRow();
                string valorAnterior = Definiciones.Log.RegistroNuevo;

                row.ID = sesion.Db.GetSiguienteSecuencia("depositos_bancarios_det_sqc");
                row.ESTADO = Definiciones.Estado.Activo;
                row.DEPOSITO_BANCARIO_ID = (decimal)campos[DepositosBancariosDetalleService.DepositoBancarioId_NombreCol];

                dtDepositoBancario = DepositosBancariosService.GetDepositosBancariosInfoCompleta(DepositosBancariosService.Id_NombreCol + " = " + row.DEPOSITO_BANCARIO_ID, string.Empty, sesion);
                ctacteValorId = (int)campos[DepositosBancariosDetalleService.CtacteValorId_NombreCol];
                row.CTACTE_VALOR_ID = ctacteValorId;

                //Si es efectivo la caja solo puede estar abierta
                //Si es cheque puede provenir de una caja abierta o cerrada
                if ((string)dtDepositoBancario.Rows[0][DepositosBancariosService.DepositoDesdeSuc_NombreCol] == Definiciones.SiNo.Si)
                {
                    if (CuentaCorrienteCajasSucursalService.GetEstado((decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.CtacteCajaSucursalId_NombreCol], sesion) == Definiciones.CuentaCorrienteCajaSucursalEstados.Cerrada &&
                        row.CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Efectivo)
                    {
                        throw new Exception("No puede depositarse efectivo desde una caja cerrada.");
                    }
                }

                if (campos.Contains(DepositosBancariosDetalleService.TextoPredefinidoId_NombreCol))
                    row.TEXTO_PREDEFINIDO_ID = (decimal)campos[DepositosBancariosDetalleService.TextoPredefinidoId_NombreCol];

                //Se realiza el insert para que exista el parent del foreign key
                //en la tabla de movimientos de tesoreria y de sucursal
                sesion.Db.DEPOSITOS_BANCARIOS_DETCollection.Insert(row);

                switch (ctacteValorId)
                {
                    #region efectivo
                    case Definiciones.CuentaCorrienteValores.Efectivo:
                        row.IMPORTE = (decimal)campos[DepositosBancariosDetalleService.Importe_NombreCol];

                        if (dtDepositoBancario.Rows[0][DepositosBancariosService.DepositoDesdeSuc_NombreCol].Equals(Definiciones.SiNo.No))
                        {
                            //Se afecta el saldo de la caja de tesoreria
                            CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(
                                  (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.CtacteCajaTesoreriaId_NombreCol],
                                  Definiciones.FlujosIDs.DEPOSITO_BANCARIO,
                                  string.Empty,
                                  row.DEPOSITO_BANCARIO_ID,
                                  row.ID,
                                  Definiciones.CuentaCorrienteValores.Efectivo,
                                  Definiciones.Error.Valor.EnteroPositivo,
                                  (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.VistaMonedaId_NombreCol],
                                  (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.CotizacionMoneda_NombreCol],
                                  row.IMPORTE,
                                  (DateTime)dtDepositoBancario.Rows[0][DepositosBancariosService.Fecha_NombreCol],
                                  sesion
                               );
                        }
                        else
                        {
                            //Se indica que el efectivo salio de la caja de sucursal
                            CuentaCorrienteCajaService.Egreso(
                                  (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.CtacteCajaSucursalId_NombreCol],
                                  Definiciones.FlujosIDs.DEPOSITO_BANCARIO,
                                  row.DEPOSITO_BANCARIO_ID,
                                  row.ID,
                                  Definiciones.CuentaCorrienteValores.Efectivo,
                                  Definiciones.Error.Valor.EnteroPositivo,
                                  (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.VistaMonedaId_NombreCol],
                                  (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.CotizacionMoneda_NombreCol],
                                  row.IMPORTE,
                                  (DateTime)dtDepositoBancario.Rows[0][DepositosBancariosService.Fecha_NombreCol],
                                  sesion
                               );
                        }

                        break;
                    #endregion efectivo

                    #region  cheque
                    case Definiciones.CuentaCorrienteValores.Cheque:
                        row.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)campos[DepositosBancariosDetalleService.CtacteChequeRecibidoId_NombreCol];
                        //Se obtiene el cheque
                        dtChequeRecibido = CuentaCorrienteChequesRecibidosService.GetDataTable(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + row.CTACTE_CHEQUE_RECIBIDO_ID, string.Empty, sesion);

                        //Se controla que el cheque no haya sido depositado, rechazado o efectivizado previamente
                        if (!((decimal)dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol] == Definiciones.CuentaCorrienteChequesEstados.AlDia ||
                              (decimal)dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol] == Definiciones.CuentaCorrienteChequesEstados.Adelantado))
                        {
                            //Se personaliza el mensaje para mejor entendimiento
                            if (dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol].Equals(Definiciones.CuentaCorrienteChequesEstados.Depositado))
                                throw new Exception("El cheque ya fue depositado previamente.");
                            if (dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol].Equals(Definiciones.CuentaCorrienteChequesEstados.Rechazado))
                                throw new Exception("El cheque fue rechazado previamente.");
                            if (dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol].Equals(Definiciones.CuentaCorrienteChequesEstados.Efectivizado))
                                throw new Exception("El cheque fue efectivizado previamente.");

                            //En caso que no se haya encontrado el motivo
                            throw new Exception("El cheque no puede ser depositado.");
                        }

                        //Se controla la fecha de vencimiento (desde la que se puede depositar)
                        DateTime fechaVencimiento = (DateTime)dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.FechaVencimiento_NombreCol];
                        if (fechaVencimiento.CompareTo((DateTime)dtDepositoBancario.Rows[0][DepositosBancariosService.Fecha_NombreCol]) > 0)
                        {
                            throw new Exception("La fecha de vencimiento del cheque es posterior a la del depósito.");
                        }

                        row.IMPORTE = (decimal)dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol];

                        if (dtDepositoBancario.Rows[0][DepositosBancariosService.DepositoDesdeSuc_NombreCol].Equals(Definiciones.SiNo.No))
                        {
                            //Se afecta el saldo de la caja
                            CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(
                                  (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.CtacteCajaTesoreriaId_NombreCol],
                                  Definiciones.FlujosIDs.DEPOSITO_BANCARIO,
                                  string.Empty,
                                  row.DEPOSITO_BANCARIO_ID,
                                  row.ID,
                                  Definiciones.CuentaCorrienteValores.Cheque,
                                  row.CTACTE_CHEQUE_RECIBIDO_ID,
                                  (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.VistaMonedaId_NombreCol],
                                  (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.CotizacionMoneda_NombreCol],
                                  row.IMPORTE,
                                  (DateTime)dtDepositoBancario.Rows[0][DepositosBancariosService.Fecha_NombreCol],
                                  sesion
                               );
                        }
                        else
                        {
                            if (dtDepositoBancario.Rows[0][DepositosBancariosService.DepositoDesdeSuc_NombreCol].Equals(Definiciones.SiNo.No))
                            {
                                throw new Exception("No se puede realizar la operacion.");
                            }
                            else
                            {
                                //Se indica que lo cobrado por el POS salio de la caja de sucursal, como deposito bancario
                                CuentaCorrienteCajaService.Egreso(
                                  (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.CtacteCajaSucursalId_NombreCol],
                                  Definiciones.FlujosIDs.DEPOSITO_BANCARIO,
                                  row.DEPOSITO_BANCARIO_ID,
                                  row.ID,
                                  Definiciones.CuentaCorrienteValores.POS,
                                  Definiciones.Error.Valor.EnteroPositivo,
                                  (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.VistaMonedaId_NombreCol],
                                  (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.CotizacionMoneda_NombreCol],
                                  row.IMPORTE,
                                  (DateTime)dtDepositoBancario.Rows[0][DepositosBancariosService.Fecha_NombreCol],
                                  sesion
                               );
                            }
                        }

                        break;
                    #endregion  cheque

                    #region  POS

                    case Definiciones.CuentaCorrienteValores.POS:
                        row.IMPORTE = (decimal)campos[DepositosBancariosDetalleService.Importe_NombreCol];

                        if (dtDepositoBancario.Rows[0][DepositosBancariosService.DepositoDesdeSuc_NombreCol].Equals(Definiciones.SiNo.No))
                        { throw new Exception("No se puede realizar la operacion."); }
                        else
                        {
                            CuentaCorrienteCajaService.Egreso(
                                     (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.CtacteCajaSucursalId_NombreCol],
                                     Definiciones.FlujosIDs.DEPOSITO_BANCARIO,
                                     row.DEPOSITO_BANCARIO_ID,
                                     row.ID,
                                     Definiciones.CuentaCorrienteValores.POS,
                                     Definiciones.Error.Valor.EnteroPositivo,
                                     (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.VistaMonedaId_NombreCol],
                                     (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.CotizacionMoneda_NombreCol],
                                     row.IMPORTE,
                                     (DateTime)dtDepositoBancario.Rows[0][DepositosBancariosService.Fecha_NombreCol],
                                     sesion
                                  );
                        }
                        break;
                    #endregion  POS

                    default: throw new Exception("Tipo de valor no implementado.");
                }

                sesion.Db.DEPOSITOS_BANCARIOS_DETCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                //Se recalculan los totales de la cabecera
                (new DepositosBancariosService()).CalcularTotales(row.DEPOSITO_BANCARIO_ID, sesion);

            }
            catch (Exception)
            {
               // sesion.RollbackTransaction();
                throw;
            }

        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified deposito_bancario_detalle_id.
        /// </summary>
        /// <param name="deposito_bancario_detalle_id">The deposito_bancario_detalle_id.</param>
        /// <returns></returns>
        public static void Borrar(decimal deposito_bancario_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    DEPOSITOS_BANCARIOS_DETRow row = sesion.Db.DEPOSITOS_BANCARIOS_DETCollection.GetByPrimaryKey(deposito_bancario_detalle_id);
                    DepositosBancariosService depositoBancario = new DepositosBancariosService();
                    CuentaCorrienteCajaService ctacteCajaSucursalMov = new CuentaCorrienteCajaService();
                    DataTable dtDepositoBancario = DepositosBancariosService.GetDepositosBancariosDataTable(DepositosBancariosService.Id_NombreCol + " = " + row.DEPOSITO_BANCARIO_ID, string.Empty);

                    if (dtDepositoBancario.Rows[0][DepositosBancariosService.DepositoDesdeSuc_NombreCol].Equals(Definiciones.SiNo.No))
                    {
                        //Se afecta la caja de tesoreria
                        CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.DEPOSITO_BANCARIO, string.Empty, row.ID, (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.CasoId_NombreCol], sesion);
                    }
                    else
                    {
                        //Se afecta la caja de sucursal
                        ctacteCajaSucursalMov.DeshacerEgreso(Definiciones.FlujosIDs.DEPOSITO_BANCARIO, row.ID, sesion);
                    }

                    row.ESTADO = Definiciones.Estado.Inactivo;

                    //Se borra el detalle
                    sesion.Db.DEPOSITOS_BANCARIOS_DETCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    //Se recalculan los totales de la cabecera
                    (new DepositosBancariosService()).CalcularTotales(row.DEPOSITO_BANCARIO_ID, sesion);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        public static void Eliminar(decimal deposito_bancario_detalle_id, SessionService sesion)
        {
            try
            {
                DEPOSITOS_BANCARIOS_DETRow row = sesion.Db.DEPOSITOS_BANCARIOS_DETCollection.GetByPrimaryKey(deposito_bancario_detalle_id);
                sesion.Db.DEPOSITOS_BANCARIOS_DETCollection.DeleteByPrimaryKey(deposito_bancario_detalle_id);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "DEPOSITOS_BANCARIOS_DET"; }
        }
        public static string CtacteChequeRecibidoId_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_DETCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_DETCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string DepositoBancarioId_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_DETCollection.DEPOSITO_BANCARIO_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_DETCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_DETCollection.IDColumnName; }
        }
        public static string Importe_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_DETCollection.IMPORTEColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_DETCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string VistaCtacteBancoAbreviatura_NombreCol
        {
            get { return DEPOSITOS_BANC_DET_INFO_COMPLCollection.CTACTE_BANCO_ABREVIATURAColumnName; }
        }
        public static string VistaCtacteBancoId_NombreCol
        {
            get { return DEPOSITOS_BANC_DET_INFO_COMPLCollection.CTACTE_BANCO_IDColumnName; }
        }
        public static string VistaCtacteBancoNombre_NombreCol
        {
            get { return DEPOSITOS_BANC_DET_INFO_COMPLCollection.CTACTE_BANCO_NOMBREColumnName; }
        }
        public static string VistaCtacteChequeRecibidoNum_NombreCol
        {
            get { return DEPOSITOS_BANC_DET_INFO_COMPLCollection.CTACTE_CHEQUE_RECIBIDO_NUMColumnName; }
        }
        public static string VistaCtacteValorNombre_NombreCol
        {
            get { return DEPOSITOS_BANC_DET_INFO_COMPLCollection.CTACTE_VALOR_NOMBREColumnName; }
        }
        public static string VistaDescripcionCheque_NombreCol
        {
            get { return DEPOSITOS_BANC_DET_INFO_COMPLCollection.CTACTE_BANCO_ABREVIATURAColumnName + "-Nº " + DEPOSITOS_BANC_DET_INFO_COMPLCollection.CTACTE_CHEQUE_RECIBIDO_NUMColumnName; }
        }
        public static string VistaMonedaId_NombreCol
        {
            get { return DEPOSITOS_BANC_DET_INFO_COMPLCollection.MONEDA_IDColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return DEPOSITOS_BANC_DET_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaObservacion_NombreCol
        {
            get { return DEPOSITOS_BANC_DET_INFO_COMPLCollection.OBSERVACIONColumnName; }
        }
        public static string VistaTextoPredefinidoTexto_NombreCol
        {
            get { return DEPOSITOS_BANC_DET_INFO_COMPLCollection.TEXTOColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static DepositosBancariosDetalleService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new DepositosBancariosDetalleService(e.RegistroId, sesion);
        }

        public static decimal? GetIdPorUUID(string uuid, SessionService sesion)
        {
            if (uuid.Length <= 0)
                return null;

            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return e.RegistroId;
        }
        #endregion interfaz IEntidadMigrable

        #region Propiedades
        protected DEPOSITOS_BANCARIOS_DETRow row;
        protected DEPOSITOS_BANCARIOS_DETRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? CtacteChequeRecibidoId { get { if (row.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return null; else return row.CTACTE_CHEQUE_RECIBIDO_ID; } set { if (value.HasValue) row.CTACTE_CHEQUE_RECIBIDO_ID = value.Value; else row.IsCTACTE_CHEQUE_RECIBIDO_IDNull = true; } }
        public decimal CtacteValorId { get { return row.CTACTE_VALOR_ID; } set { row.CTACTE_VALOR_ID = value; } }
        public decimal DepositoBancarioId { get { return row.DEPOSITO_BANCARIO_ID; } set { row.DEPOSITO_BANCARIO_ID = value; } }
        public string Estado { get { return ClaseCBABase.GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? Importe { get { if (row.IsIMPORTENull) return null; else return row.IMPORTE; } set { if (value.HasValue) row.IMPORTE = value.Value; else row.IsIMPORTENull = true; } }
        public decimal? TextoPredefinidoId { get { if (row.IsTEXTO_PREDEFINIDO_IDNull) return null; else return row.TEXTO_PREDEFINIDO_ID; } set { if (value.HasValue) row.TEXTO_PREDEFINIDO_ID = value.Value; else row.IsTEXTO_PREDEFINIDO_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CuentaCorrienteChequesRecibidosService _ctacte_cheque_recibido;
        public CuentaCorrienteChequesRecibidosService CtacteChequeRecibido
        {
            get
            {
                if (this._ctacte_cheque_recibido == null)
                    this._ctacte_cheque_recibido = new CuentaCorrienteChequesRecibidosService(this.CtacteChequeRecibidoId.Value);
                return this._ctacte_cheque_recibido;
            }
        }

        private DepositosBancariosService _deposito_bancario;
        public DepositosBancariosService DepositoBancario
        {
            get
            {
                if (this._deposito_bancario == null)
                    this._deposito_bancario = new DepositosBancariosService(this.DepositoBancarioId);
                return this._deposito_bancario;
            }
        }

        private TextosPredefinidosService _texto_predefinido;
        public TextosPredefinidosService TextoPredefinido
        {
            get
            {
                if (this._texto_predefinido == null)
                    this._texto_predefinido = new TextosPredefinidosService(this.TextoPredefinidoId.Value);
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
                this.row = sesion.db.DEPOSITOS_BANCARIOS_DETCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new DEPOSITOS_BANCARIOS_DETRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true;
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(DEPOSITOS_BANCARIOS_DETRow row)
        {
            this.AlmacenarLocalmente = true;
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public DepositosBancariosDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public DepositosBancariosDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public DepositosBancariosDetalleService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public DepositosBancariosDetalleService(EdiCBA.DepositoBancarioDetalle edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = DepositosBancariosDetalleService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion);

            #region cheque recibido
            if (!string.IsNullOrEmpty(edi.cheque_recibido_uuid))
                this._ctacte_cheque_recibido = CuentaCorrienteChequesRecibidosService.GetPorUUID(edi.cheque_recibido_uuid, sesion);
            if (this._ctacte_cheque_recibido == null && edi.cheque_recibido != null)
                this._ctacte_cheque_recibido = new CuentaCorrienteChequesRecibidosService(edi.cheque_recibido, almacenar_localmente, sesion);
            if (this._ctacte_cheque_recibido != null)
            {
                if (!this.CtacteChequeRecibido.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.CtacteChequeRecibido.Id.HasValue)
                    this.CtacteChequeRecibidoId = this.CtacteChequeRecibido.Id.Value;
            }
            #endregion cheque recibido

            this.CtacteValorId = edi.tipo_valor;

            #region deposito bancario
            if (!string.IsNullOrEmpty(edi.deposito_bancario_uuid))
                this._deposito_bancario = DepositosBancariosService.GetPorUUID(edi.deposito_bancario_uuid, sesion);
            if (this._deposito_bancario == null && edi.deposito_bancario != null)
                this._deposito_bancario = new DepositosBancariosService(edi.deposito_bancario, almacenar_localmente, sesion);
            if (this._deposito_bancario != null)
            {
                if (!this.DepositoBancario.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.DepositoBancario.Id.HasValue)
                    this.DepositoBancarioId = this.DepositoBancario.Id.Value;
            }
            #endregion deposito bancario

            this.Estado = Definiciones.Estado.Activo;
            this.Importe = edi.monto;

            //TODO: descomentar cuando texto predefinido tenga orientación a objeto
            //#region texto predefinido
            //if (!string.IsNullOrEmpty(edi.texto_predefinido_uuid))
            //    this._texto_predefinido = TextosPredefinidosService.GetPorUUID(edi.texto_predefinido_uuid, sesion);
            //if (this._texto_predefinido == null && edi.texto_predefinido != null)
            //    this._texto_predefinido = new TextosPredefinidosService(edi.texto_predefinido, almacenar_localmente, sesion);
            //if (this._texto_predefinido != null)
            //{
            //    if (!this.TextoPredefinido.ExisteEnDB && almacenar_localmente)
            //    {
            //        //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
            //        throw new NotImplementedException("Debe guardarse localmente la entidad.");
            //    }
            //    if (this.TextoPredefinido.Id.HasValue)
            //        this.TextoPredefinidoId = this.TextoPredefinido.Id.Value;
            //}
            //#endregion texto predefinido
        }
        private DepositosBancariosDetalleService(DEPOSITOS_BANCARIOS_DETRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCabecera
        public static DepositosBancariosDetalleService[] GetPorCabecera(decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCabecera(cabecera_id, sesion);
            }
        }

        public static DepositosBancariosDetalleService[] GetPorCabecera(decimal cabecera_id, SessionService sesion)
        {
            var rows = sesion.db.DEPOSITOS_BANCARIOS_DETCollection.GetAsArray(DepositosBancariosDetalleService.DepositoBancarioId_NombreCol + " = " + cabecera_id +
                                                                             " and " + DepositosBancariosDetalleService.Estado_NombreCol + " = '" +
                                                                             Definiciones.Estado.Activo + "'", DepositosBancariosDetalleService.Id_NombreCol);
            DepositosBancariosDetalleService[] dpd = new DepositosBancariosDetalleService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                dpd[i] = new DepositosBancariosDetalleService(rows[i]);
            return dpd;
        }
        #endregion GetPorCabecera

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.DepositoBancarioDetalle()
            {
                cheque_recibido_uuid = this.CtacteChequeRecibidoId.HasValue ? this.CtacteChequeRecibido.GetOrCreateUUID(sesion) : null,
                deposito_bancario_uuid = this.DepositoBancario.GetOrCreateUUID(sesion),
                monto = this.Importe.Value,
                tipo_valor = (int)this.CtacteValorId
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.cheque_recibido = (EdiCBA.ChequeRecibido)this.CtacteChequeRecibido.ToEDI(nueva_profundidad, sesion);
                e.deposito_bancario = (EdiCBA.DepositoBancario)this.DepositoBancario.ToEDI(nueva_profundidad, sesion);
            }

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value);
            }
            return e;
        }
        #endregion ToEDI

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._ctacte_cheque_recibido = null;
            this._deposito_bancario = null;
            this._texto_predefinido = null;
        }
        #endregion ResetearPropiedadesExtendidas
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
