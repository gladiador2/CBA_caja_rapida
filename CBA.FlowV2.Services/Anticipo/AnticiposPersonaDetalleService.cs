using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Casos;

namespace CBA.FlowV2.Services.Anticipo
{
    public class AnticiposPersonaDetalleService
    {
        #region GetAnticipoPersonaDetalleDataTable
        /// <summary>
        /// Gets the anticipo persona detalle data table.
        /// </summary>
        /// <param name="anticipo_persona_id">The anticipo_persona_id.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetAnticipoPersonaDetalleDataTable(decimal anticipo_persona_id)
        {
            return GetAnticipoPersonaDetalleDataTable(AnticiposPersonaDetalleService.AnticipoPersonaId_NombreCol + " = " + anticipo_persona_id, string.Empty);
        }

        /// <summary>
        /// Gets the anticipo persona detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetAnticipoPersonaDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ANTICIPOS_PERSONA_DETCollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetAnticipoPersonaDetalleDataTable2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAnticipoPersonaDetalleDataTable2(clausulas, orden, sesion);
            }
        }
        
        public static DataTable GetAnticipoPersonaDetalleDataTable2(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ANTICIPOS_PERSONA_DETCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAnticipoPersonaDetalleDataTable

        #region GetAnticipoPersonaDetalleInfoCompleta
        /// <summary>
        /// Gets the anticipo persona detalle info completa.
        /// </summary>
        /// <param name="anticipo_persona_id">The anticipo_persona_id.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetAnticipoPersonaDetalleInfoCompleta(decimal anticipo_persona_id)
        {
            return AnticiposPersonaDetalleService.GetAnticipoPersonaDetalleInfoCompleta(AnticiposPersonaDetalleService.AnticipoPersonaId_NombreCol + " = " + anticipo_persona_id, string.Empty);
        }

        /// <summary>
        /// Gets the anticipo persona detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAnticipoPersonaDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAnticipoPersonaDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetAnticipoPersonaDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ANTICIPOS_PERS_DET_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAnticipoPersonaDetalleInfoCompleta

        #region Guardar
        public void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                Guardar(campos, sesion);
            }
        }
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public void Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                ANTICIPOS_PERSONA_DETRow row = new ANTICIPOS_PERSONA_DETRow();
                AnticiposPersonaService anticipoPersona = new AnticiposPersonaService();
                SucursalesService sucursal = new SucursalesService();
                CuentaCorrienteChequesRecibidosService ctacteChequeRecibido = new CuentaCorrienteChequesRecibidosService();
                DataTable dtAnticipoPersona;
                string valorAnterior;
                decimal ctacteCajaSucursalId;

                valorAnterior = Definiciones.Log.RegistroNuevo;

                row.ID = sesion.Db.GetSiguienteSecuencia("anticipos_persona_det_sqc");
                row.ANTICIPO_PERSONA_ID = (decimal)campos[AnticiposPersonaDetalleService.AnticipoPersonaId_NombreCol];
                dtAnticipoPersona = AnticiposPersonaService.GetAnticipoPersonaDataTable(AnticiposPersonaService.Id_NombreCol + " = " + row.ANTICIPO_PERSONA_ID.ToString(), string.Empty, sesion);
              
                row.CTACTE_VALOR_ID = (int)campos[AnticiposPersonaDetalleService.CtacteValorId_NombreCol];

                //Campos comunes y necesarios antes de insertar cualquier valor
                if (!MonedasService.EstaActivo((decimal)campos[AnticiposPersonaDetalleService.MonedaId_NombreCol]))
                    throw new System.Exception("La moneda se encuentra inactiva.");
                row.MONEDA_ID = (decimal)campos[AnticiposPersonaDetalleService.MonedaId_NombreCol];

                //Si la cabecera del anticipo llega a tener el campo fecha, cambiar DateTime.Now por esa fecha
                if (campos.Contains(AnticiposPersonaDetalleService.CotizacionMoneda_NombreCol))
                    row.COTIZACION_MONEDA = (decimal)campos[AnticiposPersonaDetalleService.CotizacionMoneda_NombreCol];                 
                else
                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dtAnticipoPersona.Rows[0][AnticiposPersonaService.SucursalId_NombreCol]), row.MONEDA_ID, DateTime.Now, sesion);

                if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new Exception("Debe actualizarse la cotización de la moneda.");

                if (campos.Contains(AnticiposPersonaDetalleService.DepositoBancarioId_NombreCol))
                    row.DEPOSITO_BANCARIO_ID = (decimal)campos[AnticiposPersonaDetalleService.DepositoBancarioId_NombreCol];

                row.MONTO = (decimal)campos[AnticiposPersonaDetalleService.Monto_NombreCol];

                //Segun el tipo de valor, debera crearse un cheque, un anticipo, etc.
                switch ((int)campos[AnticiposPersonaDetalleService.CtacteValorId_NombreCol])
                {
                    case Definiciones.CuentaCorrienteValores.Cheque:
                        row.CHEQUE_FECHA_POSDATADO = (DateTime)campos[AnticiposPersonaDetalleService.ChequeFechaPosdatada_NombreCol];
                        row.CHEQUE_FECHA_VENCIMIENTO = (DateTime)campos[AnticiposPersonaDetalleService.ChequeFechaVencimiento_NombreCol];
                        row.CHEQUE_NOMBRE_BENEFICIARIO = (string)campos[AnticiposPersonaDetalleService.ChequeNombreBeneficiario_NombreCol];
                        row.CHEQUE_NOMBRE_EMISOR = (string)campos[AnticiposPersonaDetalleService.ChequeNombreEmisor_NombreCol];
                        row.CHEQUE_NRO_CHEQUE = (string)campos[AnticiposPersonaDetalleService.ChequeNroCheque_NombreCol];
                        row.CHEQUE_NRO_CUENTA = (string)campos[AnticiposPersonaDetalleService.ChequeNroCuenta_NombreCol];
                        row.CHEQUE_DE_TERCEROS = (string)campos[AnticiposPersonaDetalleService.ChequeDeTerceros_NombreCol];
                        row.CHEQUE_DOCUMENTO_EMISOR = (string)campos[AnticiposPersonaDetalleService.ChequeDocumentoEmisor_NombreCol];
                        row.CHEQUE_ES_DIFERIDO = (string)campos[AnticiposPersonaDetalleService.ChequeEsDiferido_NombreCol];

                        if (!CuentaCorrienteBancosService.EstaActivo((decimal)campos[AnticiposPersonaDetalleService.ChequeCtacteBancoId_NombreCol]))
                            throw new Exception("El banco no está activo.");
                        else
                            row.CHEQUE_CTACTE_BANCO_ID = (decimal)campos[AnticiposPersonaDetalleService.ChequeCtacteBancoId_NombreCol];
                        
                        row.MONTO = (decimal)campos[AnticiposPersonaDetalleService.Monto_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.DepositoBancario:
                        //Se verifica que este activa
                        if (!CuentaCorrienteCuentasBancariasService.EstaActivo((decimal)campos[AnticiposPersonaDetalleService.DepositoCtacteBancariasId_NombreCol]))
                            throw new System.Exception("La cuenta bancaria está inactiva.");
                        else
                            row.DEPOSITO_CTACTE_BANCARIAS_ID = (decimal)campos[AnticiposPersonaDetalleService.DepositoCtacteBancariasId_NombreCol];

                        row.DEPOSITO_NRO_BOLETA = (string)campos[AnticiposPersonaDetalleService.DepositoNroBoleta_NombreCol];
                        row.DEPOSITO_FECHA = (DateTime)campos[AnticiposPersonaDetalleService.DepositoFecha_NombreCol];

                        //Por el momento no se utiliza el campo ya que no es necesario 
                        //crear un caso de deposito
                        //row.DEPOSITO_BANCARIO_ID
                        break;

                    case Definiciones.CuentaCorrienteValores.Efectivo:
                    case Definiciones.CuentaCorrienteValores.Ajuste:
                        break;
                    case Definiciones.CuentaCorrienteValores.TarjetaDeCredito:
                        throw new NotImplementedException("Forma de pago aun no implementada");
                        //row.CTACTE_PROCESADORA_TARJETA_ID
                        //row.TARJETA_NRO
                        //row.TARJETA_TITULAR
                        //row.TARJETA_VENCIMIENTO
                    case Definiciones.CuentaCorrienteValores.TransferenciaBancaria:
                        string query = "select apd." + AnticiposPersonaDetalleService.Id_NombreCol + " from " + AnticiposPersonaService.Nombre_Tabla + " ap, " + AnticiposPersonaDetalleService.Nombre_Tabla + " apd, " + CasosService.Nombre_Tabla + " c \n" +
                                       "where apd." + AnticiposPersonaDetalleService.AnticipoPersonaId_NombreCol + " = ap." + AnticiposPersonaService.Id_NombreCol + " \n" +
                                       "and ap." + AnticiposPersonaService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " \n" +
                                       "and c." + CasosService.EstadoId_NombreCol + " != '" + Definiciones.EstadosFlujos.Anulado + "' \n" +
                                       "and apd." + AnticiposPersonaDetalleService.TransferenciaBancariaId_NombreCol + " = " + campos[AnticiposPersonaDetalleService.TransferenciaBancariaId_NombreCol].ToString();
                        DataTable dt = sesion.db.EjecutarQuery(query);
                        if (dt.Rows.Count > 0)                             
                            throw new System.Exception("El detalle ya tiene la transferencia bancaria.");                       
                        else
                            row.TRANSFERENCIA_BANCARIA_ID = (decimal)campos[AnticiposPersonaDetalleService.TransferenciaBancariaId_NombreCol];
                        break;                        
                    default: throw new Exception("Error. El tipo de valor indefinido.");
                }

                sesion.Db.ANTICIPOS_PERSONA_DETCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                anticipoPersona.RecalcularTotal(row.ANTICIPO_PERSONA_ID, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified ctacte_pago_persona_detalle_id.
        /// </summary>
        /// <param name="anticipo_persona_detalle_id">The anticipo_persona_detalle_id.</param>
        public void Borrar(decimal anticipo_persona_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    ANTICIPOS_PERSONA_DETRow row;
                    AnticiposPersonaService anticipoPersona = new AnticiposPersonaService();
                    CuentaCorrienteCajaService ctacteCaja = new CuentaCorrienteCajaService();

                    row = sesion.Db.ANTICIPOS_PERSONA_DETCollection.GetByPrimaryKey(anticipo_persona_detalle_id);

                   

                    sesion.Db.ANTICIPOS_PERSONA_DETCollection.DeleteByPrimaryKey(anticipo_persona_detalle_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    anticipoPersona.RecalcularTotal(row.ANTICIPO_PERSONA_ID, sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ANTICIPOS_PERSONA_DET"; }
        }
        public static string AnticipoPersonaId_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.ANTICIPO_PERSONA_IDColumnName; }
        }
        public static string ChequeCtacteBancoId_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.CHEQUE_CTACTE_BANCO_IDColumnName; }
        }
        public static string ChequeEsDiferido_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.CHEQUE_ES_DIFERIDOColumnName; }
        }
        public static string ChequeFechaPosdatada_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.CHEQUE_FECHA_POSDATADOColumnName; }
        }
        public static string ChequeFechaVencimiento_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.CHEQUE_FECHA_VENCIMIENTOColumnName; }
        }
        public static string ChequeNombreBeneficiario_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.CHEQUE_NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string ChequeNombreEmisor_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.CHEQUE_NOMBRE_EMISORColumnName; }
        }
        public static string ChequeNroCheque_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.CHEQUE_NRO_CHEQUEColumnName; }
        }
        public static string ChequeNroCuenta_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.CHEQUE_NRO_CUENTAColumnName; }
        }
        public static string ChequeDeTerceros_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.CHEQUE_DE_TERCEROSColumnName; }
        }
        public static string ChequeDocumentoEmisor_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.CHEQUE_DOCUMENTO_EMISORColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteChequeRecibidoId_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CtacteProcesadoraTarjetaId_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.CTACTE_PROCESADORA_TARJETA_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string DepositoBancarioId_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.DEPOSITO_BANCARIO_IDColumnName; }
        }
        public static string DepositoCtacteBancariasId_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.DEPOSITO_CTACTE_BANCARIAS_IDColumnName; }
        }
        public static string DepositoFecha_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.DEPOSITO_FECHAColumnName; }
        }
        public static string DepositoNroBoleta_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.DEPOSITO_NRO_BOLETAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.MONTOColumnName; }
        }
        public static string TarjetaNro_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.TARJETA_NROColumnName; }
        }
        public static string TarjetaTitular_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.TARJETA_TITULARColumnName; }
        }
        public static string TarjetaVencimiento_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.TARJETA_VENCIMIENTOColumnName; }
        }
        public static string TransferenciaBancariaId_NombreCol
        {
            get { return ANTICIPOS_PERSONA_DETCollection.TRANSFERENCIA_BANCARIA_IDColumnName; }
        }
        public static string VistaCtacteValorNombre_NombreCol
        {
            get { return ANTICIPOS_PERS_DET_INFO_COMPCollection.CTACTE_VALOR_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return ANTICIPOS_PERS_DET_INFO_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaObservacion_NombreCol
        {
            get { return ANTICIPOS_PERS_DET_INFO_COMPCollection.OBSERVACIONColumnName; }
        }
        #endregion Accessors
    }
}
