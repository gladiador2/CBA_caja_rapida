using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Collections;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class DescuentoDocumentosClienteDetalleService
    {
        #region GetDescuentoDocumentosClienteDetalleDataTable
        public static DataTable GetDescuentoDocumentosClienteDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetDescuentoDocumentosClienteDetalleDataTable(clausulas, orden, sesion);
            }
        }
        public static DataTable GetDescuentoDocumentosClienteDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.DESCUENTO_DOCUMENTOS_CLI_DETCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetDescuentoDocumentosClienteDetalleDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos_detalle.
        /// </summary>
        /// <param name="campos_detalle">The campos_detalle.</param>
        /// <returns></returns>
        public static decimal Guardar(Hashtable campos_detalle, Hashtable[] campos_vencimiento)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    DESCUENTO_DOCUMENTOS_CLI_DETRow row;
                    string valorAnterior;
                    DataTable dtDescuentoDocCliente;

                    if (campos_detalle.Contains(DescuentoDocumentosClienteDetalleService.Id_NombreCol))
                    {
                        row = sesion.Db.DESCUENTO_DOCUMENTOS_CLI_DETCollection.GetByPrimaryKey((decimal)campos_detalle[DescuentoDocumentosClienteDetalleService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    else
                    {
                        row = new DESCUENTO_DOCUMENTOS_CLI_DETRow();
                        row.ID = sesion.Db.GetSiguienteSecuencia("descuento_docs_cli_det_sqc");
                        row.DESCUENTO_DOCUMENTOS_CLI_ID = (decimal)campos_detalle[DescuentoDocumentosClienteDetalleService.DescuentoDocumentosCliId_NombreCol];
                    
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }

                    dtDescuentoDocCliente = DescuentoDocumentosClienteService.GetDescuentoDocumentosClienteDataTable(DescuentoDocumentosClienteService.Id_NombreCol + " = " + row.DESCUENTO_DOCUMENTOS_CLI_ID, string.Empty);

                    row.CTACTE_VALOR_ID = decimal.Parse(campos_detalle[DescuentoDocumentosClienteDetalleService.CtacteValorId_NombreCol].ToString());
                    row.FECHA_CREACION = DateTime.Parse(campos_detalle[DescuentoDocumentosClienteDetalleService.FechaCreacion_NombreCol].ToString());
                    
                    if(row.MONEDA_ID.Equals(DBNull.Value) || !row.MONEDA_ID.Equals(campos_detalle[DescuentoDocumentosClienteDetalleService.MonedaId_NombreCol]))
                    {
                        row.MONEDA_ID = (decimal)campos_detalle[DescuentoDocumentosClienteDetalleService.MonedaId_NombreCol];
                        row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dtDescuentoDocCliente.Rows[0][DescuentoDocumentosClienteService.SucursalId_NombreCol]), row.MONEDA_ID, (DateTime)dtDescuentoDocCliente.Rows[0][DescuentoDocumentosClienteService.Fecha_NombreCol], sesion);
                        if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("Debe actualizarse la cotización de la moneda.");
                    }

                    if (campos_detalle.Contains(DescuentoDocumentosClienteDetalleService.PersonaId_NombreCol))
                    {
                        row.PERSONA_ID = (decimal)campos_detalle[DescuentoDocumentosClienteDetalleService.PersonaId_NombreCol];

                        DataTable dtPersona = PersonasService.GetPersonasInfoCompleta2(PersonasService.Id_NombreCol + " = " + row.PERSONA_ID, string.Empty);
                        row.NOMBRE_DEUDOR = (string)dtPersona.Rows[0][PersonasService.NombreCompleto_NombreCol];
                    }
                    else
                    {
                        row.IsPERSONA_IDNull = true;
                        row.NOMBRE_DEUDOR = (string)campos_detalle[DescuentoDocumentosClienteDetalleService.NombreDeudor_NombreCol];
                    }

                    row.NOMBRE_BENEFICIARIO = (string)campos_detalle[DescuentoDocumentosClienteDetalleService.NombreBeneficiario_NombreCol];
                    row.NRO_COMPROBANTE = (string)campos_detalle[DescuentoDocumentosClienteDetalleService.NroComprobante_NombreCol];
                    row.OBSERVACION = (string)campos_detalle[DescuentoDocumentosClienteDetalleService.Observacion_NombreCol];

                    if ((string)dtDescuentoDocCliente.Rows[0][DescuentoDocumentosClienteService.UsarInteresEnCalculo_NombreCol] == Definiciones.SiNo.Si)
                    {
                        row.PORCENTAJE_GASTO_ADMIN = (decimal)campos_detalle[DescuentoDocumentosClienteDetalleService.PorcentajeGastoAdmin_NombreCol];
                        row.PORCENTAJE_INTERES_ANUAL = (decimal)campos_detalle[DescuentoDocumentosClienteDetalleService.PorcentajeInteresAnual_NombreCol];
                        row.TOTAL_VALOR_EFECTIVO = 0;
                    }
                    else
                    {
                        row.PORCENTAJE_GASTO_ADMIN = 0;
                        row.PORCENTAJE_INTERES_ANUAL = 0;
                        row.TOTAL_VALOR_EFECTIVO = (decimal)campos_detalle[DescuentoDocumentosClienteDetalleService.TotalValorEfectivo_NombreCol];
                    }

                    row.TOTAL_RETENCION = (decimal)campos_detalle[DescuentoDocumentosClienteDetalleService.TotalRetencion_NombreCol];
                    row.TOTAL_VALOR_NOMINAL = (decimal)campos_detalle[DescuentoDocumentosClienteDetalleService.TotalValorNominal_NombreCol];

                    #region Guardar campos segun tipo valor
                    switch (int.Parse(row.CTACTE_VALOR_ID.ToString()))
                    {
                        case Definiciones.CuentaCorrienteValores.Cheque:
                            //Si el cheque ya fue creado entre los recibidos no pueden modificarse los datos
                            if(row.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
                            {
                                row.CHEQUE_CTACTE_BANCO_ID = (decimal)campos_detalle[DescuentoDocumentosClienteDetalleService.ChequeCtacteBancoId_NombreCol];
                                row.CHEQUE_DE_TERCEROS = (string)campos_detalle[DescuentoDocumentosClienteDetalleService.ChequeDeTerceros_NombreCol];
                                row.CHEQUE_DOCUMENTO_EMISOR = (string)campos_detalle[DescuentoDocumentosClienteDetalleService.ChequeDocumentoEmisor_NombreCol];
                                row.CHEQUE_NRO_CUENTA = (string)campos_detalle[DescuentoDocumentosClienteDetalleService.ChequeNroCuenta_NombreCol];
                                row.CHEQUE_ES_DIFERIDO = Definiciones.SiNo.No;
                            }
                            break;
                        case Definiciones.CuentaCorrienteValores.LetraDeCambio:
                        case Definiciones.CuentaCorrienteValores.Factura:
                        case Definiciones.CuentaCorrienteValores.Pagare:
                            //Se ceran los valores de cheque
                            row.IsCHEQUE_CTACTE_BANCO_IDNull = true;
                            row.CHEQUE_DE_TERCEROS = string.Empty;
                            row.CHEQUE_DOCUMENTO_EMISOR = string.Empty;
                            row.CHEQUE_NRO_CUENTA = string.Empty;

                            //Si el documento ya fue cerado entre los recibidos no pueden modificarse los datos
                            if(row.IsCTACTE_DOCUMENTO_RECIBIDO_IDNull)
                            {}
                            break;
                        default: throw new Exception("Error en DescuentoDocumentosClienteDetalleService.Guardar(). Tipo de valor no implementado.");
                    }
                    #endregion Guardar campos segun tipo valor

                    if (campos_detalle.Contains(DescuentoDocumentosClienteDetalleService.Id_NombreCol))
                        sesion.Db.DESCUENTO_DOCUMENTOS_CLI_DETCollection.Update(row);
                    else
                        sesion.Db.DESCUENTO_DOCUMENTOS_CLI_DETCollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    DescuentoDocumentosClienteDetalleVencimientosService.Guardar(row.ID, campos_vencimiento, sesion);

                    //Calcular el valor efectivo
                    if ((string)dtDescuentoDocCliente.Rows[0][DescuentoDocumentosClienteService.UsarInteresEnCalculo_NombreCol] == Definiciones.SiNo.Si)
                    {
                        DescuentoDocumentosClienteDetalleService.ActualizarValorEfectivo(
                                                                        row, 
                                                                        (DateTime)dtDescuentoDocCliente.Rows[0][DescuentoDocumentosClienteService.Fecha_NombreCol], 
                                                                        (string)dtDescuentoDocCliente.Rows[0][DescuentoDocumentosClienteService.InteresIncluyeImpuesto_NombreCol] == Definiciones.SiNo.Si, 
                                                                        sesion);
                    }

                    sesion.Db.CommitTransaction();
                    return row.ID;
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
        public static void Borrar(decimal descuento_documento_cliente_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                Borrar(descuento_documento_cliente_detalle_id, sesion);
            }
        }

        /// <summary>
        /// Borrars the specified descuento_documento_cliente_detalle_id.
        /// </summary>
        /// <param name="descuento_documento_cliente_detalle_id">The descuento_documento_cliente_detalle_id.</param>
        public static void Borrar(decimal descuento_documento_cliente_detalle_id, SessionService sesion)
        {
            try
            {
                DESCUENTO_DOCUMENTOS_CLI_DETRow row = sesion.Db.DESCUENTO_DOCUMENTOS_CLI_DETCollection.GetByPrimaryKey(descuento_documento_cliente_detalle_id);

                //Se borran los vencimientos y el desglose de monto por impuesto
                DescuentoDocumentosClienteDetalleVencimientosService.Borrar(row.ID, sesion);
                DescuentoDocumentosClienteDetalleDesgloseService.Borrar(row.ID, sesion);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                sesion.Db.DESCUENTO_DOCUMENTOS_CLI_DETCollection.Delete(row);
            }
            catch
            {
                throw;
            }
        }
        #endregion Borrar

        #region BorrarTodos
        public static void BorrarTodos(decimal descuento_documento_cliente_id)
        {
            using (SessionService sesion = new SessionService())
            {
                BorrarTodos(descuento_documento_cliente_id, sesion);
            }
        }
        
        public static void BorrarTodos(decimal descuento_documento_cliente_id, SessionService sesion)
        {
            //Borrar los detalles del caso
            DESCUENTO_DOCUMENTOS_CLI_DETRow[] rows = sesion.db.DESCUENTO_DOCUMENTOS_CLI_DETCollection.GetByDESCUENTO_DOCUMENTOS_CLI_ID(descuento_documento_cliente_id);
            for (int i = 0; i < rows.Length; i++)
                DescuentoDocumentosClienteDetalleService.Borrar(rows[i].ID, sesion);
        }
        #endregion BorrarTodos

        #region ActualizarValorEfectivo
        /// <summary>
        /// Actualizars the valor efectivo.
        /// </summary>
        /// <param name="descuento_documento_cliente_id">The descuento_documento_cliente_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarValorEfectivo(decimal descuento_documento_cliente_id, DateTime fecha_inicio_descuento, bool interes_incluye_impuesto, SessionService sesion)
        {
            DESCUENTO_DOCUMENTOS_CLI_DETRow[] rows = sesion.Db.DESCUENTO_DOCUMENTOS_CLI_DETCollection.GetByDESCUENTO_DOCUMENTOS_CLI_ID(descuento_documento_cliente_id);
            for (int i = 0; i < rows.Length; i++)
            {
                DescuentoDocumentosClienteDetalleService.ActualizarValorEfectivo(rows[i], fecha_inicio_descuento, interes_incluye_impuesto, sesion);
            }
        }

        /// <summary>
        /// Actualizars the valor efectivo.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="fecha_inicio_descuento">The fecha_inicio_descuento.</param>
        /// <param name="sesion">The sesion.</param>
        private static void ActualizarValorEfectivo(DESCUENTO_DOCUMENTOS_CLI_DETRow row, DateTime fecha_inicio_descuento, bool interes_incluye_impuesto, SessionService sesion)
        {
            TimeSpan span;
            DataTable dtVencimientos = DescuentoDocumentosClienteDetalleVencimientosService.GetDescuentoDocumentosClienteDetalleVencimientosConSesion(DescuentoDocumentosClienteDetalleVencimientosService.DescuentoDocumentoDetId_NombreCol + " = " + row.ID, string.Empty, sesion);
            decimal interesDiario, relacionInteresGastoAdmin;
            decimal totalInteres = 0;
            decimal montoInteresCorriente, montoGastoAdministrativo;
            Hashtable camposDesglose;

            interesDiario = row.PORCENTAJE_INTERES_ANUAL + row.PORCENTAJE_GASTO_ADMIN;

            if (row.PORCENTAJE_INTERES_ANUAL + row.PORCENTAJE_GASTO_ADMIN > 0)
                relacionInteresGastoAdmin = row.PORCENTAJE_INTERES_ANUAL / row.PORCENTAJE_INTERES_ANUAL + row.PORCENTAJE_GASTO_ADMIN;
            else
                relacionInteresGastoAdmin = 0;
            decimal montoTotal = 0;
            for (int i = 0; i < dtVencimientos.Rows.Count; i++)
            {
                span = (DateTime)dtVencimientos.Rows[i][DescuentoDocumentosClienteDetalleVencimientosService.FechaVencimiento_NombreCol] - fecha_inicio_descuento.Date;

                if (span.Days > 0)
                    totalInteres +=  Math.Round(((interesDiario / 100 / 365) * decimal.Parse(dtVencimientos.Rows[i][DescuentoDocumentosClienteDetalleVencimientosService.Monto_NombreCol].ToString()) * span.Days), MonedasService.CantidadDecimalesStatic(row.MONEDA_ID));

                montoTotal += decimal.Parse(dtVencimientos.Rows[i][DescuentoDocumentosClienteDetalleVencimientosService.Monto_NombreCol].ToString());
            }

            if (interes_incluye_impuesto)
            {
                //Se asume que el impuesto es 10% porque no hay informacion para tomarlo de otra forma
                totalInteres *= (100 + ImpuestosService.GetPorcentajePorId(Definiciones.Impuestos.IVA_10)) / 100;
            }

            montoInteresCorriente = decimal.Parse((relacionInteresGastoAdmin * totalInteres).ToString());
            montoGastoAdministrativo = decimal.Parse(totalInteres.ToString()) - montoInteresCorriente;
            
            row.TOTAL_VALOR_EFECTIVO = montoTotal - totalInteres;

            if (row.TOTAL_VALOR_EFECTIVO > row.TOTAL_VALOR_NOMINAL)
                row.TOTAL_VALOR_EFECTIVO = row.TOTAL_VALOR_NOMINAL;

            sesion.Db.DESCUENTO_DOCUMENTOS_CLI_DETCollection.Update(row);

            #region Actualizar desglose
            DescuentoDocumentosClienteDetalleDesgloseService.Borrar(row.ID, sesion);

            //Ingresar el desglose de lo exento
            if (row.TOTAL_VALOR_EFECTIVO > 0)
            {
                camposDesglose = new Hashtable();
                camposDesglose.Add(DescuentoDocumentosClienteDetalleDesgloseService.DescuentoDocumentoDetId_NombreCol, row.ID);
                camposDesglose.Add(DescuentoDocumentosClienteDetalleDesgloseService.Monto_NombreCol, row.TOTAL_VALOR_EFECTIVO);
                camposDesglose.Add(DescuentoDocumentosClienteDetalleDesgloseService.ImpuestoId_NombreCol, Definiciones.Impuestos.Exenta);
                DescuentoDocumentosClienteDetalleDesgloseService.Guardar(camposDesglose, sesion);
            }

            //Ingresar el desglose de lo gravado 10%
            if (montoGastoAdministrativo > 0)
            {
                camposDesglose = new Hashtable();
                camposDesglose.Add(DescuentoDocumentosClienteDetalleDesgloseService.DescuentoDocumentoDetId_NombreCol, row.ID);
                camposDesglose.Add(DescuentoDocumentosClienteDetalleDesgloseService.Monto_NombreCol, montoGastoAdministrativo);
                camposDesglose.Add(DescuentoDocumentosClienteDetalleDesgloseService.ImpuestoId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.DescuentoDocClientesPorcentajeGastoAdministrativoImpuesto));
                DescuentoDocumentosClienteDetalleDesgloseService.Guardar(camposDesglose, sesion);
            }

            //Ingresar el desglose de lo gravado 5%
            if (montoInteresCorriente > 0)
            {
                camposDesglose = new Hashtable();
                camposDesglose.Add(DescuentoDocumentosClienteDetalleDesgloseService.DescuentoDocumentoDetId_NombreCol, row.ID);
                camposDesglose.Add(DescuentoDocumentosClienteDetalleDesgloseService.Monto_NombreCol, montoInteresCorriente);
                camposDesglose.Add(DescuentoDocumentosClienteDetalleDesgloseService.ImpuestoId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.DescuentoDocClientesPorcentajeInteresImpuesto));
                DescuentoDocumentosClienteDetalleDesgloseService.Guardar(camposDesglose, sesion);
            }
            #endregion Actualizar desglose
        }
        #endregion ActualizarValorEfectivo

        #region ActualizarChequeRecibido
        /// <summary>
        /// Actualizars the cheque recibido.
        /// </summary>
        /// <param name="descuento_documento_cliente_id">The descuento_documento_cliente_id.</param>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarChequeRecibido(decimal descuento_documento_cliente_id, decimal ctacte_cheque_recibido_id, SessionService sesion)
        {
            DESCUENTO_DOCUMENTOS_CLI_DETRow row = sesion.Db.DESCUENTO_DOCUMENTOS_CLI_DETCollection.GetByPrimaryKey(descuento_documento_cliente_id);
            row.CTACTE_CHEQUE_RECIBIDO_ID = ctacte_cheque_recibido_id;
            sesion.Db.DESCUENTO_DOCUMENTOS_CLI_DETCollection.Update(row);
        }
        #endregion ActualizarChequeRecibido

        #region ActualizarDocumentoRecibido
        /// <summary>
        /// Actualizars the documento recibido.
        /// </summary>
        /// <param name="descuento_documento_cliente_id">The descuento_documento_cliente_id.</param>
        /// <param name="ctacte_documento_id">The ctacte_documento_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarDocumentoRecibido(decimal descuento_documento_cliente_id, decimal ctacte_documento_id, SessionService sesion)
        {
            DESCUENTO_DOCUMENTOS_CLI_DETRow row = sesion.Db.DESCUENTO_DOCUMENTOS_CLI_DETCollection.GetByPrimaryKey(descuento_documento_cliente_id);
            row.CTACTE_DOCUMENTO_RECIBIDO_ID = ctacte_documento_id;
            sesion.Db.DESCUENTO_DOCUMENTOS_CLI_DETCollection.Update(row);
        }
        #endregion ActualizarDocumentoRecibido

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "DESCUENTO_DOCUMENTOS_CLI_DET"; }
        }
        public static string ChequeCtacteBancoId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.CHEQUE_CTACTE_BANCO_IDColumnName; }
        }
        public static string ChequeEsDiferido_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.CHEQUE_ES_DIFERIDOColumnName; }
        }
        public static string ChequeDeTerceros_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.CHEQUE_DE_TERCEROSColumnName; }
        }
        public static string ChequeDocumentoEmisor_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.CHEQUE_DOCUMENTO_EMISORColumnName; }
        }
        public static string ChequeNroCuenta_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.CHEQUE_NRO_CUENTAColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteChequeRecibidoId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CtacteDocumentoRecidibodId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.CTACTE_DOCUMENTO_RECIBIDO_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string DescuentoDocumentosCliId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.DESCUENTO_DOCUMENTOS_CLI_IDColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.FECHA_CREACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.MONEDA_IDColumnName; }
        }
        public static string NombreBeneficiario_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string NombreDeudor_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.NOMBRE_DEUDORColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.OBSERVACIONColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.PERSONA_IDColumnName; }
        }
        public static string PorcentajeGastoAdmin_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.PORCENTAJE_GASTO_ADMINColumnName; }
        }
        public static string PorcentajeInteresAnual_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.PORCENTAJE_INTERES_ANUALColumnName; }
        }
        public static string TotalRetencion_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.TOTAL_RETENCIONColumnName; }
        }
        public static string TotalValorEfectivo_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.TOTAL_VALOR_EFECTIVOColumnName; }
        }
        public static string TotalValorNominal_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_CLI_DETCollection.TOTAL_VALOR_NOMINALColumnName; }
        }
        #endregion Accessors
    }
}
