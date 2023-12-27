#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.NotaCreditosProveedores;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class MovimientoVarioCajaTesoreriaDetalleService
    {
        #region GetNotaCreditoPersonaDetalleDataTable
        public static DataTable GetMovimientoVarioCajaDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetMovimientoVarioCajaDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetMovimientoVarioCajaDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.MOV_VARIOS_TESO_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, MovimientoVarioCajaTesoreriaDetalleService.Id_NombreCol);
        }
        #endregion GetNotaCreditoPersonaDetalleDataTable

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    MOVIMIENTOS_VARIOS_TESO_DETRow row = new MOVIMIENTOS_VARIOS_TESO_DETRow();
                    MovimientoVarioCajaTesoreriaService movimiento = new MovimientoVarioCajaTesoreriaService();
          
                    string valorAnterior = Definiciones.Log.RegistroNuevo;
                    
                    //campos identificatorios
                    row.ID = sesion.Db.GetSiguienteSecuencia("movimientos_vario_teso_det_sqc");
                    if (campos.Contains(MovimientoVarioID_NombreCol)) row.MOVIMIENTO_VARIO_ID = decimal.Parse(campos[MovimientoVarioID_NombreCol].ToString());
                    
                    //campos de los montos
                    if(campos.Contains(MonedaId_NombreCol)) row.MONEDA_ID = decimal.Parse(campos[MonedaId_NombreCol].ToString());
                    if(campos.Contains(Monto_NombreCol))row.MONTO = decimal.Parse(campos[Monto_NombreCol].ToString());
                    if(campos.Contains(MonedaCotizacion_NombreCol)) row.COTIZACION_MONEDA = decimal.Parse(campos[MonedaCotizacion_NombreCol].ToString());
                    if(campos.Contains(CtaCteValorId_NombreCol)) row.CTACTE_VALOR_ID = decimal.Parse(campos[CtaCteValorId_NombreCol].ToString());

                    //si el monto es de entrada y es en cheque
                    if (campos.Contains(ChequeEmisor_NombreCol)) row.NOMBRE_EMISOR = campos[ChequeEmisor_NombreCol].ToString();
                    if (campos.Contains(ChequeNumero_NombreCol)) row.NUMERO_CHEQUE = campos[ChequeNumero_NombreCol].ToString();
                    if (campos.Contains(ChequeNumeroCuenta_NombreCol)) row.NUMERO_CUENTA = campos[ChequeNumeroCuenta_NombreCol].ToString();
                    if (campos.Contains(ChequeDeTerceros_NombreCol)) row.CHEQUE_DE_TERCEROS = campos[ChequeDeTerceros_NombreCol].ToString();
                    
                    //si el monto es de salida y es en cheque recibido
                    if (campos.Contains(CtaCteChequeRecibidoId_NombreCol)) row.CTACTE_CHEQUE_RECIBIDO_ID= decimal.Parse(campos[CtaCteChequeRecibidoId_NombreCol].ToString());
                    if (campos.Contains(ChequeBeneficiario_NombreCol)) row.NOMBRE_BENEFICIARIO = campos[ChequeBeneficiario_NombreCol].ToString();

                    //si el monto es de salida y es en cheque girado
                    if (campos.Contains(MovimientoVarioCajaTesoreriaDetalleService.CtacteBancariaId_NombreCol)) row.CTACTE_BANCARIA_ID = (decimal)campos[MovimientoVarioCajaTesoreriaDetalleService.CtacteBancariaId_NombreCol];
                    if (campos.Contains(MovimientoVarioCajaTesoreriaDetalleService.UsarChequera_NombreCol)) row.USAR_CHEQUERA = (string)campos[MovimientoVarioCajaTesoreriaDetalleService.UsarChequera_NombreCol];
                    if (campos.Contains(MovimientoVarioCajaTesoreriaDetalleService.AutonumeracionId_NombreCol)) row.AUTONUMERACION_ID = (decimal)campos[MovimientoVarioCajaTesoreriaDetalleService.AutonumeracionId_NombreCol];
                    
                    //el identificador del banco emisor del cheque sea emitido o recibido;
                    if (campos.Contains(CtaCteBancoId_NombreCol)) row.CTACTE_BANCO_ID = decimal.Parse(campos[CtaCteBancoId_NombreCol].ToString());
                   
                    //otros datos comunes de los cheques
                    if (campos.Contains(FechaCreacion_NombreCol)) row.FECHA_CREACION = DateTime.Parse(campos[FechaCreacion_NombreCol].ToString());
                    if (campos.Contains(FechaPosdatado_NombreCol)) row.FECHA_POSDATADO = DateTime.Parse(campos[FechaPosdatado_NombreCol].ToString());
                    if (campos.Contains(Fechavencimiento_NombreCol)) row.FECHA_VENCIMIENTO = DateTime.Parse(campos[Fechavencimiento_NombreCol].ToString());
                    if (campos.Contains(EsDiferido_NombreCol)) row.ES_DIFERIDO = campos[EsDiferido_NombreCol].ToString();

                    if (campos.Contains(Observacion_NombreCol)) row.OBSERVACION = campos[Observacion_NombreCol].ToString();
                    sesion.Db.MOVIMIENTOS_VARIOS_TESO_DETCollection.Insert(row);
                    
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    movimiento.RecalcularTotal(row.MOVIMIENTO_VARIO_ID, sesion);
                    return row.ID;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal movimiento_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    MOVIMIENTOS_VARIOS_TESO_DETRow row = sesion.db.MOVIMIENTOS_VARIOS_TESO_DETCollection.GetByPrimaryKey(movimiento_detalle_id);
                    MovimientoVarioCajaTesoreriaService movimiento = new MovimientoVarioCajaTesoreriaService();

                    DataTable dtCabecera = MovimientoVarioCajaTesoreriaService.GetMovimientoVarioCajaTesoreriaDataTable(MovimientoVarioCajaTesoreriaService.Id_NombreCol + " = " + row.MOVIMIENTO_VARIO_ID, string.Empty, sesion);
                    
                    if((string)dtCabecera.Rows[0][MovimientoVarioCajaTesoreriaService.TipoOperacion] == Definiciones.TiposMovimientosCaja.Egreso)
                        CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA, MovimientoVarioCajaTesoreriaService.Nombre_Tabla, movimiento_detalle_id, (decimal)dtCabecera.Rows[0][MovimientoVarioCajaTesoreriaService.CasoId_NombreCol], sesion);
                    else
                        CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerIngreso(Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA, MovimientoVarioCajaTesoreriaService.Nombre_Tabla, movimiento_detalle_id, (decimal)dtCabecera.Rows[0][MovimientoVarioCajaTesoreriaService.CasoId_NombreCol], sesion);
                    
                    sesion.Db.MOVIMIENTOS_VARIOS_TESO_DETCollection.Delete(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    movimiento.RecalcularTotal(row.MOVIMIENTO_VARIO_ID, sesion);

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
            get { return "MOVIMIENTOS_VARIOS_TESO_DET"; }
        }
        public static string Nombre_Vista
        {
            get { return "MOV_VARIOS_TESO_DET_INFO_COMPL"; }
        }
        public static string Id_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.IDColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string MonedaCotizacion_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteBancariaId_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.CTACTE_BANCARIA_IDColumnName; }
        }
        public static string CtaCteBancoId_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.CTACTE_BANCO_IDColumnName; }
        }
        public static string CtaCteChequeGiradoId_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.CTACTE_CHEQUE_GIRADO_IDColumnName; }
        }
        public static string CtaCteChequeRecibidoId_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CtaCteValorId_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.FECHA_CREACIONColumnName; }
        }
        public static string EsDiferido_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.ES_DIFERIDOColumnName; }
        }
        public static string FechaPosdatado_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.FECHA_POSDATADOColumnName; }
        }
        public static string Fechavencimiento_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.MONTOColumnName; }
        }
        public static string MovimientoVarioID_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.MOVIMIENTO_VARIO_IDColumnName; }
        }
        public static string ChequeBeneficiario_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string ChequeDeTerceros_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.CHEQUE_DE_TERCEROSColumnName; }
        }
        public static string ChequeEmisor_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.NOMBRE_EMISORColumnName; }
        }
        public static string ChequeNumero_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.NUMERO_CHEQUEColumnName; }
        }
        public static string ChequeNumeroCuenta_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.NUMERO_CUENTAColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.OBSERVACIONColumnName; }
        }
        public static string UsarChequera_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.USAR_CHEQUERAColumnName; }
        }
        #region Vistas
        public static string VistaNombreBanco_NombreCol
        {
            get { return MOV_VARIOS_TESO_DET_INFO_COMPLCollection.CTACTE_BANCO_NOMBREColumnName; }
        }
       
        public static string VistaNombreValor_NombreCol
        {
            get { return MOV_VARIOS_TESO_DET_INFO_COMPLCollection.CTACTE_VALOR_NOMBREColumnName; }
        }
        public static string VistaNombreMonedas_NombreCol
        {
            get { return MOV_VARIOS_TESO_DET_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaNombreSimbolo_NombreCol
        {
            get { return MOV_VARIOS_TESO_DET_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        
        #endregion Vistas
        #endregion Accessors
    }
}
