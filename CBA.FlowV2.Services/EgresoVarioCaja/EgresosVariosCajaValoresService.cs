#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Tesoreria;
#endregion Using

namespace CBA.FlowV2.Services.EgresosVariosCaja
{
    public class EgresosVariosCajaValoresService
    {
        #region GetDataTable
        public static DataTable GetDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = EgresosVariosCajaValoresService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.EGRESOS_VARIOS_CAJA_VALCollection.GetAsDataTable(where, orden);
        }
        #endregion GetDataTable

        #region GetInfoCompleta
        public static DataTable GetInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            string where = EgresosVariosCajaValoresService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.EGRESOS_VARIOS_CAJA_VAL_INF_CCollection.GetAsDataTable(where, orden);
        }
        #endregion GetInfoCompleta

        #region GetTotal
        public static decimal GetTotal(decimal egreso_vario_caja_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTotal(egreso_vario_caja_id, sesion);
            }
        }
        public static decimal GetTotal(decimal egreso_vario_caja_id, SessionService sesion)
        {
            return GetTotal(egreso_vario_caja_id, Definiciones.Error.Valor.IntPositivo, sesion);
        }

        public static decimal GetTotal(decimal egreso_vario_caja_id, int ctacte_valor_id, SessionService sesion)
        {
            decimal total = 0;
            string clausulas = EgresosVariosCajaValoresService.EgresoVarioCajaId_NombreCol + " = " + egreso_vario_caja_id + " and " +
                               EgresosVariosCajaValoresService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            if (ctacte_valor_id != Definiciones.Error.Valor.IntPositivo)
                clausulas += " and " + EgresosVariosCajaValoresService.CtacteValorId_NombreCol + " = " + ctacte_valor_id;
            
            EGRESOS_VARIOS_CAJA_VALRow[] rows = sesion.db.EGRESOS_VARIOS_CAJA_VALCollection.GetAsArray(clausulas, string.Empty);
            for (int i = 0; i < rows.Length; i++)
                total += rows[i].MONTO_DESTINO;
            return total;
        }
        #endregion GetTotal

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                EgresosVariosCajaValoresService.Guardar(campos, sesion);
            }
        }

        public static decimal Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                int ctacteValorId;

                DataTable dtCabecera;
                EGRESOS_VARIOS_CAJA_VALRow row = new EGRESOS_VARIOS_CAJA_VALRow();
                string valorAnterior = Definiciones.Log.RegistroNuevo;

                row.ID = sesion.Db.GetSiguienteSecuencia("egresos_varios_caja_val_sqc");
                row.EGRESO_VARIO_CAJA_ID = (decimal)campos[EgresosVariosCajaValoresService.EgresoVarioCajaId_NombreCol];
                row.ESTADO = Definiciones.Estado.Activo;

                dtCabecera = EgresosVariosCajaService.GetEgresosVariosCajaDataTable(EgresosVariosCajaService.Id_NombreCol + " = " + row.EGRESO_VARIO_CAJA_ID, string.Empty, sesion);

                //Se inicializa a No sin importar el tipo de valor
                row.CG_USAR_AUTONUM = Definiciones.SiNo.No;

                ctacteValorId = int.Parse(campos[EgresosVariosCajaValoresService.CtacteValorId_NombreCol].ToString());
                switch (ctacteValorId)
                {
                    case Definiciones.CuentaCorrienteValores.Efectivo:
                        break;
                    case Definiciones.CuentaCorrienteValores.Cheque:
                        decimal decimalAuxOPCaso;

                        //Cheque girado
                        row.CG_CTACTE_BANCARIA_ID = (decimal)campos[EgresosVariosCajaValoresService.CGCtacteBancariaId_NombreCol];
                        row.CG_ES_DIFERIDO = (string)campos[EgresosVariosCajaValoresService.CGEsDiferido_NombreCol];
                        row.CG_FECHA_EMISION = (DateTime)campos[EgresosVariosCajaValoresService.CGFechaEmision_NombreCol];
                        row.CG_FECHA_VENCIMIENTO = (DateTime)campos[EgresosVariosCajaValoresService.CGFechaVencimiento_NombreCol];
                        row.CG_NOMBRE_BENEFICIARIO = (string)campos[EgresosVariosCajaValoresService.CGNombreBeneficiario_NombreCol];
                        row.CG_NOMBRE_EMISOR = (string)campos[EgresosVariosCajaValoresService.CGNombreEmisor_NombreCol];
                        row.CG_NUMERO_CHEQUE = (string)campos[EgresosVariosCajaValoresService.CGNumeroCheque_NombreCol];
                        row.CG_USAR_AUTONUM = (string)campos[EgresosVariosCajaValoresService.CGUsarAutonum_NombreCol];

                        if (row.CG_USAR_AUTONUM == Definiciones.SiNo.Si)
                            row.CG_AUTONUMERACION_ID = (decimal)campos[EgresosVariosCajaValoresService.CGAutonumeracionId_NombreCol];

                        //Comprobar que no exista un cheque activo emitido con el mismo numero perteneciente a la misma cuenta
                        if (CuentaCorrienteChequesGiradosService.ExisteNumero(row.CG_CTACTE_BANCARIA_ID, row.CG_NUMERO_CHEQUE))
                        {
                            throw new Exception("Ya existe un cheque emitido con número " + row.CG_NUMERO_CHEQUE + " de la cuenta seleccionada.");
                        }
                        //Advertir si existe otra OP con valores aun no generados y que posteriormente emitirian 
                        //un cheque de la misma cuenta con mismo numero
                        else if (CuentaCorrienteChequesGiradosService.ExisteChequeGiradoParaCuentaYNumero(row.CG_CTACTE_BANCARIA_ID, row.CG_NUMERO_CHEQUE, out decimalAuxOPCaso))
                        {
                            throw new Exception("Existe un cheque con misma cuenta y número en la OP caso " + decimalAuxOPCaso + ".");
                        }
                        break;
                    case Definiciones.CuentaCorrienteValores.RetencionIVA:
                        //Creada en el cambio de estado de la OP
                        if (campos.Contains(EgresosVariosCajaValoresService.RetencionEmitidaId_NombreCol))
                            row.RETENCION_EMITIDA_ID = (decimal)campos[EgresosVariosCajaValoresService.RetencionEmitidaId_NombreCol];
                        row.RETENCION_FECHA = (DateTime)campos[EgresosVariosCajaValoresService.RetencionFecha_NombreCol];
                        row.RETENCION_TIPO_ID = (decimal)campos[EgresosVariosCajaValoresService.RetencionTipoId_NombreCol];
                        row.RETENCION_AUX_CASOS = (string)campos[EgresosVariosCajaValoresService.RetencionAuxCasos_NombreCol];
                        row.RETENCION_AUX_MONTOS = (string)campos[EgresosVariosCajaValoresService.RetencionAuxMontos_NombreCol];
                        if (campos.Contains(EgresosVariosCajaValoresService.RetencionProveedorId_NombreCol))
                            row.RETENCION_PROVEEDOR_ID = (decimal)campos[EgresosVariosCajaValoresService.RetencionProveedorId_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.Ajuste:
                        break;
                    default: throw new Exception("Tipo de valor no implementado.");
                }
                row.CTACTE_VALOR_ID = Convert.ToDecimal(ctacteValorId);

                if (campos.Contains(EgresosVariosCajaValoresService.CotizacionMonedaDestino_NombreCol))
                    row.COTIZACION_MONEDA_DESTINO = (decimal)campos[EgresosVariosCajaValoresService.CotizacionMonedaDestino_NombreCol];
                else
                    row.COTIZACION_MONEDA_DESTINO = (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.CotizacionMoneda_NombreCol];

                if (row.COTIZACION_MONEDA_DESTINO.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new Exception("Debe actualizarse la cotización de la moneda destino.");

                row.MONEDA_ORIGEN_ID = (decimal)campos[EgresosVariosCajaValoresService.MonedaOrigenId_NombreCol];
                if (row.MONEDA_ORIGEN_ID == (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.MonedaId_NombreCol])
                {
                    row.COTIZACION_MONEDA_ORIGEN = row.COTIZACION_MONEDA_DESTINO;
                }
                else
                {
                    if (campos.Contains(EgresosVariosCajaValoresService.CotizacionMonedaOrigen_NombreCol))
                        row.COTIZACION_MONEDA_ORIGEN = (decimal)campos[EgresosVariosCajaValoresService.CotizacionMonedaOrigen_NombreCol];
                    else
                        row.COTIZACION_MONEDA_ORIGEN = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtCabecera.Rows[0][EgresosVariosCajaService.SucursalId_NombreCol]), row.MONEDA_ORIGEN_ID, (DateTime)dtCabecera.Rows[0][EgresosVariosCajaService.Fecha_NombreCol], sesion);
                }

                if (row.COTIZACION_MONEDA_ORIGEN.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new Exception("Debe actualizarse la cotización de la moneda origen.");

                row.MONTO_ORIGEN = (decimal)campos[EgresosVariosCajaValoresService.MontoOrigen_NombreCol];
                row.MONTO_DESTINO = row.MONTO_ORIGEN / row.COTIZACION_MONEDA_ORIGEN * row.COTIZACION_MONEDA_DESTINO;

                row.OBSERVACION = (string)campos[EgresosVariosCajaValoresService.Observacion_NombreCol];

                if (campos.Contains(EgresosVariosCajaValoresService.NroComprobanteRetencion_NombreCol))
                    row.NRO_COMPROBANTE = (string)campos[EgresosVariosCajaValoresService.NroComprobanteRetencion_NombreCol];

                sesion.Db.EGRESOS_VARIOS_CAJA_VALCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                //Se recalculan los totales de la cabecera
                EgresosVariosCajaService.CalcularTotales(row.EGRESO_VARIO_CAJA_ID, sesion);

                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal egreso_vario_caja_valor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                Borrar(egreso_vario_caja_valor_id, sesion);
            }
        }

        public static void Borrar(decimal egreso_vario_caja_valor_id, SessionService sesion)
        {
            try
            {
                EGRESOS_VARIOS_CAJA_VALRow row = sesion.Db.EGRESOS_VARIOS_CAJA_VALCollection.GetByPrimaryKey(egreso_vario_caja_valor_id);
                string valorAnterior = row.ToString();
                row.ESTADO = Definiciones.Estado.Inactivo;
                sesion.Db.EGRESOS_VARIOS_CAJA_VALCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                //Se recalculan los totales de la cabecera
                EgresosVariosCajaService.CalcularTotales(row.EGRESO_VARIO_CAJA_ID, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion borrar

        #region ActualizarRetenciones
        public static decimal ActualizarRetenciones(decimal egreso_vario_caja_valor_id, string nro_comprobante, SessionService sesion)
        {
            EGRESOS_VARIOS_CAJA_VALRow row = sesion.Db.EGRESOS_VARIOS_CAJA_VALCollection.GetByPrimaryKey(egreso_vario_caja_valor_id);
            string valorAnterior = row.ToString();;

            row.NRO_COMPROBANTE = nro_comprobante;

            sesion.Db.EGRESOS_VARIOS_CAJA_VALCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.RETENCION_EMITIDA_ID;
        }

        public static void ActualizarRetenciones(decimal egreso_vario_caja_valor_id, decimal retencion_emitida_id, DateTime fecha, SessionService sesion)
        {
            EGRESOS_VARIOS_CAJA_VALRow row;
            string valorAnterior;
            string nroComprobante = new CuentaCorrienteRetencionesEmitidasService().GetNroComprobante(retencion_emitida_id, sesion);

            row = sesion.Db.EGRESOS_VARIOS_CAJA_VALCollection.GetByPrimaryKey(egreso_vario_caja_valor_id);
            valorAnterior = row.ToString();

            if (nroComprobante.Length > 0)
                row.NRO_COMPROBANTE = nroComprobante;

            row.RETENCION_FECHA = fecha;
            row.RETENCION_EMITIDA_ID = retencion_emitida_id;

            sesion.Db.EGRESOS_VARIOS_CAJA_VALCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion ActualizarRetenciones

        #region Actualizar Estado
        public static void ActualizarEstado(decimal egreso_vario_caja_valor_id, string estado)
        {
            using (SessionService sesion = new SessionService())
            {
                ActualizarEstado(egreso_vario_caja_valor_id, estado, sesion);
            }
        }
        public static void ActualizarEstado(decimal egreso_vario_caja_valor_id, string estado, SessionService sesion)
        {
            EGRESOS_VARIOS_CAJA_VALRow row = sesion.Db.EGRESOS_VARIOS_CAJA_VALCollection.GetByPrimaryKey(egreso_vario_caja_valor_id);
            string valorAnterior = row.ToString(); ;

            row.ESTADO = estado;

            sesion.Db.EGRESOS_VARIOS_CAJA_VALCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion Actualizar Estado

        #region ReemplazarCheque
        public static void ReemplazarCheque(System.Collections.Hashtable campos, bool anularCheque)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    decimal valorId = (decimal)campos[EgresosVariosCajaValoresService.Id_NombreCol];
                    EGRESOS_VARIOS_CAJA_VALRow valorReemplazadoRow = sesion.db.EGRESOS_VARIOS_CAJA_VALCollection.GetByPrimaryKey(valorId);
                    DataTable dtEgresoVario = EgresosVariosCajaService.GetEgresosVariosCajaDataTable(EgresosVariosCajaService.Id_NombreCol + " = " + valorReemplazadoRow.EGRESO_VARIO_CAJA_ID, string.Empty, sesion);
                    CASOSRow casoRow = sesion.db.CASOSCollection.GetByPrimaryKey((decimal)dtEgresoVario.Rows[0][EgresosVariosCajaService.CasoId_NombreCol]);

                    #region Se anula el cheque girado asociado al valor de la OP y se borra ese valor
                    // O se anula el cheque
                    if (anularCheque)
                    {
                        //Se anula el cheque
                        CuentaCorrienteChequesGiradosService.Anular(valorReemplazadoRow.CG_CTACTE_CHEQUE_GIRADO_ID,
                                                  "Reemplazo de cheque en Egreso Vario de Caja " + Traducciones.Caso + " " + dtEgresoVario.Rows[0][EgresosVariosCajaService.CasoId_NombreCol].ToString() + " en estado " + casoRow.ESTADO_ID + ".",
                                                  sesion);
                    }
                    // O se borra el cheque y sus movimientos asociados
                    else
                    {
                        // Se borra el cheque girado
                        CuentaCorrienteChequesGiradosService.Borrar(valorReemplazadoRow.CG_CTACTE_CHEQUE_GIRADO_ID, sesion);
                    }

                    //Se afecta la cuenta bancaria si el cheque ya la habia afectado
                    if (CuentaCorrienteChequesGiradosService.SaldoAfectado(valorReemplazadoRow.CG_CTACTE_CHEQUE_GIRADO_ID, sesion))
                    {
                        CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                              valorReemplazadoRow.CG_CTACTE_BANCARIA_ID,
                              Definiciones.FlujosIDs.EGRESO_VARIO_CAJA,
                              casoRow.ID,
                              Definiciones.Error.Valor.EnteroPositivo,
                              (decimal)dtEgresoVario.Rows[0][EgresosVariosCajaService.Id_NombreCol],
                              valorReemplazadoRow.MONEDA_ORIGEN_ID,
                              valorReemplazadoRow.MONTO_ORIGEN,
                              valorReemplazadoRow.COTIZACION_MONEDA_ORIGEN,
                              valorReemplazadoRow.CG_FECHA_VENCIMIENTO,
                              "Reemplazo de cheque en Caso " + dtEgresoVario.Rows[0][EgresosVariosCajaService.CasoId_NombreCol].ToString() + " de " + Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.EGRESO_VARIO_CAJA) + " en estado " + casoRow.ESTADO_ID + ". Anulación del cheque " + valorReemplazadoRow.CG_NUMERO_CHEQUE + " fecha " + valorReemplazadoRow.CG_FECHA_EMISION.Date + ".",
                              valorReemplazadoRow.CG_CTACTE_CHEQUE_GIRADO_ID,
                              null,
                              false,
                              sesion);
                    }

                    // Se borra el valor asociado
                    EgresosVariosCajaValoresService.Borrar(valorId, sesion);
                    #endregion Se anula el cheque girado asociado al valor de la OP y se borra ese valor

                    #region Se crea el nuevo valor, el cheque girado asociado y se realizan las acciones correspondientes a la transicion a GENERACION de la OP
                    // Se crea un nuevo valor para la OP con los datos del cheque nuevo
                    decimal valorNuevoId = EgresosVariosCajaValoresService.Guardar(campos, sesion);

                    EGRESOS_VARIOS_CAJA_VALRow valorNuevoRow = sesion.db.EGRESOS_VARIOS_CAJA_VALCollection.GetByPrimaryKey(valorNuevoId);
                    System.Collections.Hashtable camposCG = new System.Collections.Hashtable();
                    decimal autonumeracion_id = Definiciones.Error.Valor.EnteroPositivo;
                    string nroCheque;

                    camposCG.Add(CuentaCorrienteChequesGiradosService.CasoCreadorId_NombreCol, (decimal)dtEgresoVario.Rows[0][EgresosVariosCajaService.CasoId_NombreCol]);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.CotizacionMoneda_NombreCol, valorNuevoRow.COTIZACION_MONEDA_ORIGEN);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.CtaCteBancariaId_NombreCol, valorNuevoRow.CG_CTACTE_BANCARIA_ID);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.EsDiferido_NombreCol, valorNuevoRow.CG_ES_DIFERIDO);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.FechaPosdatado_NombreCol, valorNuevoRow.CG_FECHA_EMISION);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.FechaVencimiento_NombreCol, valorNuevoRow.CG_FECHA_VENCIMIENTO);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.MonedaId_NombreCol, valorNuevoRow.MONEDA_ORIGEN_ID);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.Monto_NombreCol, valorNuevoRow.MONTO_ORIGEN);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol, valorNuevoRow.CG_NOMBRE_BENEFICIARIO);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.NumeroCtaBeneficiario_NombreCol, string.Empty);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.NombreEmisor_NombreCol, valorNuevoRow.CG_NOMBRE_EMISOR);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.Observacion_NombreCol, valorNuevoRow.OBSERVACION);

                    if (!valorNuevoRow.IsCG_AUTONUMERACION_IDNull)
                    {
                        autonumeracion_id = valorNuevoRow.CG_AUTONUMERACION_ID;
                        camposCG.Add(CuentaCorrienteChequesGiradosService.AutonumeracionId_NombreCol, valorNuevoRow.CG_AUTONUMERACION_ID);
                    }

                    if (valorNuevoRow.CG_NUMERO_CHEQUE != null && valorNuevoRow.CG_NUMERO_CHEQUE.Length > 0)
                        camposCG.Add(CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol, valorNuevoRow.CG_NUMERO_CHEQUE);

                    //Se crea el cheque girado
                    valorNuevoRow.CG_CTACTE_CHEQUE_GIRADO_ID = CuentaCorrienteChequesGiradosService.Emitir(camposCG, autonumeracion_id, out nroCheque, sesion);
                    valorNuevoRow.CG_NUMERO_CHEQUE = nroCheque;

                    //Se actualiza en la base de datos el id del cheque girado
                    sesion.Db.EGRESOS_VARIOS_CAJA_VALCollection.Update(valorNuevoRow);

                    //Se afecta la cuenta bancaria si el cheque no es adelantado
                    if (valorNuevoRow.CG_FECHA_VENCIMIENTO.Date <= DateTime.Now.Date && valorNuevoRow.CG_ES_DIFERIDO == Definiciones.SiNo.No)
                    {
                        CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                              valorNuevoRow.CG_CTACTE_BANCARIA_ID,
                              Definiciones.FlujosIDs.EGRESO_VARIO_CAJA,
                              (decimal)dtEgresoVario.Rows[0][EgresosVariosCajaService.CasoId_NombreCol],
                              Definiciones.Error.Valor.EnteroPositivo,
                              (decimal)dtEgresoVario.Rows[0][EgresosVariosCajaService.Id_NombreCol],
                              valorNuevoRow.MONEDA_ORIGEN_ID,
                              valorNuevoRow.MONTO_ORIGEN * (-1),
                              valorNuevoRow.COTIZACION_MONEDA_ORIGEN,
                              (DateTime)dtEgresoVario.Rows[0][EgresosVariosCajaService.Fecha_NombreCol],
                              "Reemplazo de cheque en Caso " + dtEgresoVario.Rows[0][EgresosVariosCajaService.CasoId_NombreCol].ToString() + " de " + FlujosService.GetDescripcionImpresion(Definiciones.FlujosIDs.EGRESO_VARIO_CAJA) + " (" + valorNuevoRow.CG_NOMBRE_BENEFICIARIO + "). Cheque " + valorNuevoRow.CG_NUMERO_CHEQUE + " fecha " + valorNuevoRow.CG_FECHA_EMISION.Date + ".",
                              valorNuevoRow.CG_CTACTE_CHEQUE_GIRADO_ID,
                              null,
                              false,
                              sesion);
                    }
                    #endregion Se crea el nuevo valor, el cheque girado asociado y se realizan las acciones correspondientes a la transicion a GENERACION de la OP

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion ReemplazarCheque

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "EGRESOS_VARIOS_CAJA_VAL"; }
        }
        public static string Nombre_Vista
        {
            get { return "EGRESOS_VARIOS_CAJA_VAL_INF_C"; }
        }
        public static string CGAutonumeracionId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.CG_AUTONUMERACION_IDColumnName; }
        }
        public static string CGCtacteBancariaId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.CG_CTACTE_BANCARIA_IDColumnName; }
        }
        public static string CGCtacteChequeGiradoId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.CG_CTACTE_CHEQUE_GIRADO_IDColumnName; }
        }
        public static string CGEsDiferido_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.CG_ES_DIFERIDOColumnName; }
        }
        public static string CGFechaEmision_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.CG_FECHA_EMISIONColumnName; }
        }
        public static string CGFechaVencimiento_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.CG_FECHA_VENCIMIENTOColumnName; }
        }
        public static string CGNombreBeneficiario_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.CG_NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string CGNombreEmisor_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.CG_NOMBRE_EMISORColumnName; }
        }
        public static string CGNumeroCheque_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.CG_NUMERO_CHEQUEColumnName; }
        }
        public static string CGUsarAutonum_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.CG_USAR_AUTONUMColumnName; }
        }
        public static string CotizacionMonedaDestino_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.COTIZACION_MONEDA_DESTINOColumnName; }
        }
        public static string CotizacionMonedaOrigen_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.COTIZACION_MONEDA_ORIGENColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string EgresoVarioCajaId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.EGRESO_VARIO_CAJA_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.IDColumnName; }
        }
        public static string MonedaOrigenId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.MONEDA_ORIGEN_IDColumnName; }
        }
        public static string MontoDestino_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.MONTO_DESTINOColumnName; }
        }
        public static string MontoOrigen_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.MONTO_ORIGENColumnName; }
        }
        public static string NroComprobanteRetencion_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.OBSERVACIONColumnName; }
        }
        public static string RetencionAuxCasos_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.RETENCION_AUX_CASOSColumnName; }
        }
        public static string RetencionAuxMontos_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.RETENCION_AUX_MONTOSColumnName; }
        }
        public static string RetencionEmitidaId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.RETENCION_EMITIDA_IDColumnName; }
        }
        public static string RetencionProveedorId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.RETENCION_PROVEEDOR_IDColumnName; }
        }
        public static string RetencionTipoId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.RETENCION_TIPO_IDColumnName; }
        }
        public static string RetencionFecha_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VALCollection.RETENCION_FECHAColumnName; }
        }
        public static string VistaCasoId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VAL_INF_CCollection.CASO_IDColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VAL_INF_CCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCtacteValorNombre_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VAL_INF_CCollection.CTACTE_VALOR_NOMBREColumnName; }
        }
        public static string VistaMonedaOrigenNombre_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VAL_INF_CCollection.MONEDA_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaMonedaOrigenSimbolo_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VAL_INF_CCollection.MONEDA_ORIGEN_SIMBOLOColumnName; }
        }
        public static string VistaCGCtacteBancoId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VAL_INF_CCollection.CG_CTACTE_BANCO_IDColumnName; }
        }
        public static string VistaCGCtacteBancariaNro_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VAL_INF_CCollection.CG_CTACTE_BANCARIA_NROColumnName; }
        }
        public static string VistaResumen_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VAL_INF_CCollection.RESUMENColumnName; }
        }
        public static string VistaRetencionTipoId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_VAL_INF_CCollection.RETENCION_TIPO_IDColumnName; }
        }
        #endregion Accessors
    }
}
