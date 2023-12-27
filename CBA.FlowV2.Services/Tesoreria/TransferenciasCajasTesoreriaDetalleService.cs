using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.NotaCreditosProveedores;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class TransferenciasCajasTesoreriaDetalleService
    {
        #region GetTransferenciaCajaDetalleInfoCompleta

        public DataTable GetTransferenciaCajaDetalleInfoCompleta(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRANSF_TESO_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, string.Empty);
            }
        }
        #endregion GetTransferenciaCajaDetalleInfoCompleta

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    TRANSFERENCIAS_TESORERIAS_DETRow row = new TRANSFERENCIAS_TESORERIAS_DETRow();
                    TransferenciasCajasTesoreriaService transferencia = new TransferenciasCajasTesoreriaService();
          
                    string valorAnterior = Definiciones.Log.RegistroNuevo;
                    //campos identificatorios
                    row.ID = sesion.Db.GetSiguienteSecuencia("TRANSF_CAJAS_TESO_DET_SQC");
                    if (campos.Contains(TransferenciaID_NombreCol)) row.TRANSFERENCIAS_ID = decimal.Parse(campos[TransferenciaID_NombreCol].ToString());
                    
                    //campos de los montos
                    if(campos.Contains(MonedaId_NombreCol)) row.MONEDA_ID = decimal.Parse(campos[MonedaId_NombreCol].ToString());
                    if(campos.Contains(Monto_NombreCol))row.MONTO = decimal.Parse(campos[Monto_NombreCol].ToString());
                    if(campos.Contains(MonedaCotizacion_NombreCol))row.COTIZACION_MONEDA=decimal.Parse(campos[MonedaCotizacion_NombreCol].ToString());
                    if (campos.Contains(CtaCteValorId_NombreCol)) row.CTACTE_VALOR_ID = decimal.Parse(campos[CtaCteValorId_NombreCol].ToString());
                    if (campos.Contains(ChequeRecibidoId_NombreCol)) row.CTACTE_CHEQUE_RECIBIDO_ID = decimal.Parse(campos[ChequeRecibidoId_NombreCol].ToString());
                    
                   

                    if (campos.Contains(Observacion_NombreCol)) row.OBSERVACION = campos[Observacion_NombreCol].ToString();
                    sesion.Db.TRANSFERENCIAS_TESORERIAS_DETCollection.Insert(row);

                    
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    transferencia.RecalcularTotal(row.TRANSFERENCIAS_ID, sesion);
                   
                    sesion.Db.CommitTransaction();



                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        public void Borrar(decimal transferencia_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    TRANSFERENCIAS_TESORERIAS_DETRow row = new TRANSFERENCIAS_TESORERIAS_DETRow();
                    TransferenciasCajasTesoreriaService movimiento = new TransferenciasCajasTesoreriaService();



                    row = sesion.Db.TRANSFERENCIAS_TESORERIAS_DETCollection.GetByPrimaryKey(transferencia_detalle_id);


                    sesion.Db.TRANSFERENCIAS_TESORERIAS_DETCollection.Delete(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                   movimiento.RecalcularTotal(row.TRANSFERENCIAS_ID, sesion);

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
        #region Tablas
        public static string Nombre_Tabla
        {
            get { return "TRANSFERENCIAS_TESORERIAS_DET"; }
        }

        public static string Id_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESO_DETCollection.IDColumnName; }
        }
        public static string MonedaCotizacion_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIAS_DETCollection.COTIZACION_MONEDAColumnName; }
        }
        
        public static string ChequeRecibidoId_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIAS_DETCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CtaCteValorId_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIAS_DETCollection.CTACTE_VALOR_IDColumnName; }
        }
      
        public static string MonedaId_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIAS_DETCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIAS_DETCollection.MONTOColumnName; }
        }
        public static string TransferenciaID_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIAS_DETCollection.TRANSFERENCIAS_IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return TRANSFERENCIAS_TESORERIAS_DETCollection.OBSERVACIONColumnName; }
        }
        #endregion Tablas
        
        #region Vistas
        public static string Nombre_Vista
        {
            get { return "TRANSFERENCIAS_TESORERIAS_DET"; }
        }

        public static string VistaChequeBeneficiario_NombreCol
        {
            get { return TRANSF_TESO_DET_INFO_COMPLCollection.CHEQUE_RECIBIDO_BENEFICIARIOColumnName; }
        }
        public static string VistaChequeEmisor_NombreCol
        {
            get { return TRANSF_TESO_DET_INFO_COMPLCollection.CHEQUE_RECIBIDO_EMISORColumnName; }
        }
        public static string VistaChequeNumero_NombreCol
        {
            get { return TRANSF_TESO_DET_INFO_COMPLCollection.CHEQUE_RECIBIDO_NUMEROColumnName; }
        }
        public static string VistaChequeNumeroCuenta_NombreCol
        {
            get { return TRANSF_TESO_DET_INFO_COMPLCollection.CHEQUE_RECIBIDO_CUENTAColumnName; }
        }
        public static string VistaNombreBancoId_NombreCol
        {
            get { return TRANSF_TESO_DET_INFO_COMPLCollection.CHEQUE_RECIBIDO_BANCO_IDColumnName; }
        }
        public static string VistaNombreBancoNombre_NombreCol
        {
            get { return TRANSF_TESO_DET_INFO_COMPLCollection.BANCO_RAZON_SOCIALColumnName; }
        }
        public static string VistaNombreBancoAbreviatura_NombreCol
        {
            get { return TRANSF_TESO_DET_INFO_COMPLCollection.BANCO_ABREVIATURAColumnName; }
        }
        public static string VistaNombreValor_NombreCol
        {
            get { return TRANSF_TESO_DET_INFO_COMPLCollection.VALOR_NOMBREColumnName; }
        }
        public static string VistaNombreMonedas_NombreCol
        {
            get { return TRANSF_TESO_DET_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaNombreSimbolo_NombreCol
        {
            get { return TRANSF_TESO_DET_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        
        #endregion Vistas
        #endregion Accessors
    }
}
