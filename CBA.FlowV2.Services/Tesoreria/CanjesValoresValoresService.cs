using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CanjesValoresValoresService
    {
        #region GetCanjesValoresValoresInfoCompleta
        /// <summary>
        /// Gets the canjes valores valores info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCanjesValoresValoresInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CANJES_VALORES_VALORES_INF_CCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCanjesValoresValoresInfoCompleta

        #region GetCanjesValoresValoresDataTable
        /// <summary>
        /// Gets the canjes valores valores data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCanjesValoresValoresDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CANJES_VALORES_VALORESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCanjesValoresValoresDataTable

        #region SetIdChequeCreado
        /// <summary>
        /// Sets the id cheque creado.
        /// </summary>
        /// <param name="canje_valor_valor_id">The canje_valor_valor_id.</param>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void SetIdChequeCreado(decimal canje_valor_valor_id, decimal ctacte_cheque_recibido_id, SessionService sesion)
        {
            CANJES_VALORES_VALORESRow row = sesion.Db.CANJES_VALORES_VALORESCollection.GetByPrimaryKey(canje_valor_valor_id);
            string valorAnterior = row.ToString();
            
            row.CTACTE_CHEQUE_RECIBIDO_ID = ctacte_cheque_recibido_id;

            sesion.Db.CANJES_VALORES_VALORESCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion SetIdChequeCreado

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    DataTable dtCanjeValor;
                    int tipoValor;
                    CANJES_VALORES_VALORESRow row = new CANJES_VALORES_VALORESRow();
                    
                    string valorAnterior = Definiciones.Log.RegistroNuevo;

                    row.ID = sesion.Db.GetSiguienteSecuencia("canjes_valores_valores_sqc");
                    row.CANJE_VALOR_ID = (decimal)campos[CanjesValoresValoresService.CanjeValorId_NombreCol];

                    dtCanjeValor = CanjesValoresService.GetCanjesValoresDataTable(CanjesValoresService.Id_NombreCol + " = " + row.CANJE_VALOR_ID, string.Empty);

                    row.CTACTE_VALOR_ID = (int)campos[CanjesValoresValoresService.CtacteValorId_NombreCol];
                    tipoValor = (int)campos[CanjesValoresValoresService.CtacteValorId_NombreCol];

                    switch (tipoValor)
                    {
                        case Definiciones.CuentaCorrienteValores.Cheque:
                            row.IsCTACTE_CHEQUE_RECIBIDO_IDNull = true;

                            row.CHEQUE_DE_TERCEROS = (string)campos[CanjesValoresValoresService.ChequeDeTerceros_NombreCol];
                            row.CTACTE_BANCO_ID = (decimal)campos[CanjesValoresValoresService.CtacteBancoId_NombreCol];
                            row.FECHA_CREACION = (DateTime)campos[CanjesValoresValoresService.FechaCreacion_NombreCol];
                            row.ES_DIFERIDO = (string)campos[CanjesValoresValoresService.EsDiferido_NombreCol];
                            row.FECHA_POSDATADO = (DateTime)campos[CanjesValoresValoresService.FechaPosdatado_NombreCol];
                            row.FECHA_VENCIMIENTO = (DateTime)campos[CanjesValoresValoresService.FechaVencimiento_NombreCol];
                            row.NOMBRE_BENEFICIARIO = (string)campos[CanjesValoresValoresService.NombreBeneficiario_NombreCol];
                            row.NOMBRE_EMISOR = (string)campos[CanjesValoresValoresService.NombreEmisor_NombreCol];
                            row.NUMERO_CHEQUE = (string)campos[CanjesValoresValoresService.NumeroCheque_NombreCol];
                            row.NUMERO_CUENTA = (string)campos[CanjesValoresValoresService.NumeroCuenta_NombreCol];
                            row.NUMERO_DOCUMENTO_EMISOR = (string)campos[CanjesValoresValoresService.NumeroDocumentoEmisor_NombreCol];

                            break;
                        case Definiciones.CuentaCorrienteValores.Efectivo:
                            break;
                        default: throw new Exception("Error en CanjesValoresDetalleService.Guardar(). Tipo de valor no implementado");
                    }

                    row.MONEDA_ID = (decimal)campos[CanjesValoresDetallesService.MonedaId_NombreCol];
                    if (!MonedasService.EstaActivo(row.MONEDA_ID))
                        throw new Exception("La moneda no está activa.");

                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dtCanjeValor.Rows[0][CanjesValoresService.SucursalId_NombreCol]), row.MONEDA_ID, (DateTime)dtCanjeValor.Rows[0][CanjesValoresService.Fecha_NombreCol], sesion);
                    if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizar la cotización de la moneda.");

                    row.MONTO = (decimal)campos[CanjesValoresDetallesService.Monto_NombreCol];
                    row.OBSERVACION = (string)campos[CanjesValoresDetallesService.Observacion_NombreCol];
                    
                    sesion.Db.CANJES_VALORES_VALORESCollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                   
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
        /// <summary>
        /// Borrars the specified canje_valores_detalle_id.
        /// </summary>
        /// <param name="canje_valores_valor_id">The canje_valores_valor_id.</param>
        public static void Borrar(decimal canje_valores_valor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    CANJES_VALORES_VALORESRow row = sesion.Db.CANJES_VALORES_VALORESCollection.GetByPrimaryKey(canje_valores_valor_id);

                    sesion.Db.CANJES_VALORES_VALORESCollection.Delete(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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
            get { return "CANJES_VALORES_VALORES"; }
        }
        public static string CanjeValorId_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.CANJE_VALOR_IDColumnName; }
        }
        public static string ChequeDeTerceros_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.CHEQUE_DE_TERCEROSColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteBancoId_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.CTACTE_BANCO_IDColumnName; }
        }
        public static string CtacteChequeRecibidoId_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.FECHA_CREACIONColumnName; }
        }
        public static string EsDiferido_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.ES_DIFERIDOColumnName; }
        }
        public static string FechaPosdatado_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.FECHA_POSDATADOColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.MONTOColumnName; }
        }
        public static string NombreBeneficiario_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string NombreEmisor_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.NOMBRE_EMISORColumnName; }
        }
        public static string NumeroCheque_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.NUMERO_CHEQUEColumnName; }
        }
        public static string NumeroCuenta_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.NUMERO_CUENTAColumnName; }
        }
        public static string NumeroDocumentoEmisor_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.NUMERO_DOCUMENTO_EMISORColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CANJES_VALORES_VALORESCollection.OBSERVACIONColumnName; }
        }
        public static string VistaCtacteValorNombre_NombreCol
        {
            get { return CANJES_VALORES_VALORES_INF_CCollection.CTACTE_VALOR_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CANJES_VALORES_VALORES_INF_CCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CANJES_VALORES_VALORES_INF_CCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaValorObservacion_NombreCol
        {
            get { return CANJES_VALORES_VALORES_INF_CCollection.VALOR_OBSERVACIONColumnName; }
        }
        #endregion Accessors
    }
}
