using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteCajaService
    {
        #region GetCtacteCajaDataTable
        /// <summary>
        /// Gets the ctacte caja data table2.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCtacteCajaDataTable2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCtacteCajaDataTable2(clausulas, orden, sesion);
            }
        }

        /// <summary>
        /// Gets the ctacte caja data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetCtacteCajaDataTable2(string clausulas, string orden, SessionService sesion)
        {
        
            string where = CuentaCorrienteCajaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;

            return sesion.Db.CTACTE_CAJACollection.GetAsDataTable(where, orden);
        }

        /// <summary>
        /// Gets the ctacte caja data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCtacteCajaDataTable(string clausulas, string orden)
        {
            return CuentaCorrienteCajaService.GetCtacteCajaDataTable2(clausulas, orden);
        }
        #endregion GetCtacteCajaDataTable

        #region GetCtacteCajaInfoCompleta
        /// <summary>
        /// Gets the ctacte caja info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCtacteCajaInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = CuentaCorrienteCajaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas.Length > 0)
                    where += " and " + clausulas;

                return sesion.Db.CTACTE_CAJA_INFO_COMPLETACollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetCtacteCajaInfoCompleta

        #region CorregirMonto
        public static void CorregirMonto(decimal ctacte_caja_id, decimal nuevo_monto, SessionService sesion)
        {
            CTACTE_CAJARow row = sesion.db.CTACTE_CAJACollection.GetByPrimaryKey(ctacte_caja_id);
            string valorAnterior = row.ToString();
            row.MONTO = nuevo_monto;
            sesion.db.CTACTE_CAJACollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion CorregirMonto

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns>El id del recibo</returns>
        public static decimal Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                CTACTE_CAJARow row = new CTACTE_CAJARow();
                string valorAnterior = Definiciones.Log.RegistroNuevo;

                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_caja_sqc");
                row.FECHA = (DateTime)campos[CuentaCorrienteCajaService.Fecha_NombreCol];
                row.ESTADO = Definiciones.Estado.Activo;

                if (!MonedasService.EstaActivo((decimal)campos[CuentaCorrienteCajaService.MonedaId_NombreCol]))
                    throw new System.Exception("La moneda se encuentra inactiva.");
                else
                    row.MONEDA_ID = (decimal)campos[CuentaCorrienteCajaService.MonedaId_NombreCol];

                row.COTIZACION_MONEDA = (decimal)campos[CuentaCorrienteCajaService.CotizacionMoneda_NombreCol];
                row.MONTO = (decimal)campos[CuentaCorrienteCajaService.Monto_NombreCol];
                row.CTACTE_CONCEPTO_ID = (decimal)campos[CuentaCorrienteCajaService.CtacteConceptoId_NombreCol];
                
                //Como Definiciones.CuentaCorrienteValores son de tipo int, por seguridad se convierte a decimal
                row.CTACTE_VALOR_ID = decimal.Parse(campos[CuentaCorrienteCajaService.CtacteValorId_NombreCol].ToString());
                
                //Si es un cheque recibido debe especificarse el id
                if (row.CTACTE_VALOR_ID.Equals(Definiciones.CuentaCorrienteValores.Cheque))
                    row.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)campos[CuentaCorrienteCajaService.CtacteChequeRecibidoId_NombreCol];

                //Se controla que la nueva se encuentre activa
                if (!UsuariosService.EstaActivo((decimal)campos[CuentaCorrienteCajaService.UsuarioId_NombreCol]))
                    throw new System.Exception("El usuario se encuentra inactivo.");
                else
                    row.USUARIO_ID = (decimal)campos[CuentaCorrienteCajaService.UsuarioId_NombreCol];

                //Se controla que la sucursal se encuentre activa
                if (!SucursalesService.EstaActivo((decimal)campos[CuentaCorrienteCajaService.SucursalId_NombreCol]))
                    throw new System.Exception("La sucursal se encuentra inactiva.");
                else
                    row.SUCURSAL_ID = (decimal)campos[CuentaCorrienteCajaService.SucursalId_NombreCol];

                //Se controla que el funcionario se encuentre activo
                if (!FuncionariosService.EstaActivo((decimal)campos[CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol]))
                    throw new System.Exception("El funcionario se encuentra inactivo.");
                else
                    row.FUNCIONARIO_COBRADOR_ID = (decimal)campos[CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol];

                if (campos.Contains(CuentaCorrienteCajaService.CtactePagoPersonaId_NombreCol))
                    row.CTACTE_PAGO_PERSONA_ID = (decimal)campos[CuentaCorrienteCajaService.CtactePagoPersonaId_NombreCol];
                else
                    row.IsCTACTE_PAGO_PERSONA_IDNull = true;

                if (campos.Contains(CuentaCorrienteCajaService.CtactePagoPersonaDetId_NombreCol))
                    row.CTACTE_PAGO_PERSONA_DET_ID = (decimal)campos[CuentaCorrienteCajaService.CtactePagoPersonaDetId_NombreCol];
                else 
                    row.IsCTACTE_PAGO_PERSONA_DET_IDNull = true;

                row.CTACTE_CAJA_SUCURSAL_ID = (decimal)campos[CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol];
                
                if (campos.Contains(CuentaCorrienteCajaService.EgresoVarioId_NombreCol))
                    row.EGRESO_VARIO_ID = (decimal)campos[CuentaCorrienteCajaService.EgresoVarioId_NombreCol];
                else
                    row.IsEGRESO_VARIO_IDNull = true;

                if (campos.Contains(CuentaCorrienteCajaService.MovimientoFondoFijoId_NombreCol))
                    row.MOVIMIENTO_FONDO_FIJO_ID = (decimal)campos[CuentaCorrienteCajaService.MovimientoFondoFijoId_NombreCol];
                else
                    row.IsMOVIMIENTO_FONDO_FIJO_IDNull = true;

                if (campos.Contains(CuentaCorrienteCajaService.CtacteFondoFijoMovId_NombreCol))
                    row.CTACTE_FONDO_FIJO_MOV_ID = (decimal)campos[CuentaCorrienteCajaService.CtacteFondoFijoMovId_NombreCol];
                else
                    row.IsCTACTE_FONDO_FIJO_MOV_IDNull = true;

                if (campos.Contains(CuentaCorrienteCajaService.TransferenciaCajaSucId_NombreCol))
                    row.TRANSFERENCIA_CAJA_SUC_ID = (decimal)campos[CuentaCorrienteCajaService.TransferenciaCajaSucId_NombreCol];
                else
                    row.IsTRANSFERENCIA_CAJA_SUC_IDNull = true;

                if (campos.Contains(CuentaCorrienteCajaService.AnticipoPersonaId_NombreCol))
                {
                    row.ANTICIPO_PERSONA_ID = (decimal)campos[CuentaCorrienteCajaService.AnticipoPersonaId_NombreCol];
                    row.ANTICIPO_PERSONA_DET_ID = (decimal)campos[CuentaCorrienteCajaService.AnticipoPersonaDetId_NombreCol];
                }
                else
                {
                    row.IsANTICIPO_PERSONA_IDNull = true;
                    row.IsANTICIPO_PERSONA_DET_IDNull = true;
                }

                if (campos.Contains(CuentaCorrienteCajaService.CtacteCajaReservaDetId_NombreCol))
                    row.CTACTE_CAJA_RESERVA_DET_ID = (decimal)campos[CuentaCorrienteCajaService.CtacteCajaReservaDetId_NombreCol];
                else
                    row.IsCTACTE_CAJA_RESERVA_DET_IDNull = true;

                if (campos.Contains(CuentaCorrienteCajaService.DepositoBancarioDetId_NombreCol))
                    row.DEPOSITO_BANCARIO_DET_ID = (decimal)campos[CuentaCorrienteCajaService.DepositoBancarioDetId_NombreCol];

                sesion.Db.CTACTE_CAJACollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Egreso
        /// <summary>
        /// Egresoes the specified ctacte_caja_tesoreria_id.
        /// </summary>
        /// <param name="ctacte_caja_sucursal_id">The ctacte_caja_sucursal_id.</param>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="registro_cabecera_id">The registro_cabecera_id.</param>
        /// <param name="registro_detalle_id">The registro_detalle_id.</param>
        /// <param name="ctacte_valor_id">The ctacte_valor_id.</param>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <param name="cotizacion_moneda">The cotizacion_moneda.</param>
        /// <param name="monto">The monto.</param>
        /// <param name="fecha">The fecha.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal Egreso(decimal ctacte_caja_sucursal_id, int flujo_id, decimal registro_cabecera_id, decimal registro_detalle_id, decimal ctacte_valor_id, decimal ctacte_cheque_recibido_id, decimal moneda_id, decimal cotizacion_moneda, decimal monto, DateTime fecha, SessionService sesion)
        {
            try
            {
                CuentaCorrienteChequesRecibidosService ctacteCheque = new CuentaCorrienteChequesRecibidosService();
                CuentaCorrienteCajasSucursalService ctacteCajaSucursal = new CuentaCorrienteCajasSucursalService();
                DataTable dtCtacteCajaSucursal = ctacteCajaSucursal.GetCuentaCorrienteCajasSucursalDataTable(CuentaCorrienteCajasSucursalService.Id_NombreCol + " = " + ctacte_caja_sucursal_id, string.Empty);
                System.Collections.Hashtable campos;
                string clausulas;
                string valorAnterior;
                decimal ctacteCajaId = Definiciones.Error.Valor.EnteroPositivo;
                int cantidadDecimales = MonedasService.CantidadDecimalesStatic(moneda_id, sesion);

                if (ctacte_valor_id == Definiciones.CuentaCorrienteValores.Efectivo)
                {
                    decimal saldoEnMoneda = CuentaCorrienteCajasSucursalService.GetSumaEfectivo(ctacte_caja_sucursal_id, moneda_id, sesion);
                    if (Math.Round(saldoEnMoneda, cantidadDecimales) < Math.Round(monto, cantidadDecimales))
                        throw new Exception("La caja no cuenta con saldo suficiente.");
                }

                switch (flujo_id)
                {
                    case Definiciones.FlujosIDs.DEPOSITO_BANCARIO:

                        int tipo_valor = Convert.ToInt32(ctacte_valor_id);
                        switch (tipo_valor)
                        {
                            case Definiciones.CuentaCorrienteValores.Efectivo:

                                //Agregar el egreso a la caja
                                campos = new System.Collections.Hashtable();
                                campos.Add(CuentaCorrienteCajaService.Fecha_NombreCol, fecha);
                                campos.Add(CuentaCorrienteCajaService.MonedaId_NombreCol, moneda_id);
                                campos.Add(CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, cotizacion_moneda);
                                campos.Add(CuentaCorrienteCajaService.Monto_NombreCol, -monto); //Monto negativo por ser un egreso para la caja
                                campos.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo);
                                campos.Add(CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID);
                                campos.Add(CuentaCorrienteCajaService.SucursalId_NombreCol, dtCtacteCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.SucursalId_NombreCol]);
                                campos.Add(CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, dtCtacteCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol]);
                                campos.Add(CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo);
                                campos.Add(CuentaCorrienteCajaService.DepositoBancarioDetId_NombreCol, registro_detalle_id);
                                campos.Add(CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, ctacte_caja_sucursal_id);
                                ctacteCajaId = CuentaCorrienteCajaService.Guardar(campos, sesion);

                                break;
                            case Definiciones.CuentaCorrienteValores.Cheque:
                                //Se obtiene el cheque recibido de la caja de sucursal
                                clausulas = CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol + " = " + ctacte_caja_sucursal_id + " and " +
                                            CuentaCorrienteCajaService.CtacteChequeRecibidoId_NombreCol + " = " + ctacte_cheque_recibido_id + " and " +
                                            CuentaCorrienteCajaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                                CTACTE_CAJARow ctacteCajaRow = sesion.Db.CTACTE_CAJACollection.GetAsArray(clausulas, string.Empty)[0];
                                valorAnterior = ctacteCajaRow.ToString();
                                ctacteCajaId = ctacteCajaRow.ID;

                                //Agregar al registro el id del detalle de deposito bancario
                                ctacteCajaRow.DEPOSITO_BANCARIO_DET_ID = registro_detalle_id;
                                sesion.Db.CTACTE_CAJACollection.Update(ctacteCajaRow);
                                LogCambiosService.LogDeRegistro(Nombre_Tabla, ctacteCajaRow.ID, valorAnterior, ctacteCajaRow.ToString(), sesion);

                                //Modificar el estado del cheque
                                ctacteCheque.ParaDepositoPorDepositoBancario(ctacteCajaRow.CTACTE_CHEQUE_RECIBIDO_ID, registro_cabecera_id, sesion);
                                campos = new System.Collections.Hashtable();
                                campos.Add(CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID);
                                campos.Add(CuentaCorrienteCajaService.SucursalId_NombreCol, dtCtacteCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.SucursalId_NombreCol]);
                                campos.Add(CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, dtCtacteCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol]);
                                campos.Add(CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo);


                                break;

                            case Definiciones.CuentaCorrienteValores.POS:

                                //Agregar el egreso a la caja
                                campos = new System.Collections.Hashtable();
                                campos.Add(CuentaCorrienteCajaService.Fecha_NombreCol, fecha);
                                campos.Add(CuentaCorrienteCajaService.MonedaId_NombreCol, moneda_id);
                                campos.Add(CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, cotizacion_moneda);
                                campos.Add(CuentaCorrienteCajaService.Monto_NombreCol, -monto); //Monto negativo por ser un egreso para la caja
                                campos.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.POS);
                                campos.Add(CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID);
                                campos.Add(CuentaCorrienteCajaService.SucursalId_NombreCol, dtCtacteCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.SucursalId_NombreCol]);
                                campos.Add(CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, dtCtacteCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol]);
                                campos.Add(CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo);
                                campos.Add(CuentaCorrienteCajaService.DepositoBancarioDetId_NombreCol, registro_detalle_id);
                                campos.Add(CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, ctacte_caja_sucursal_id);
                                ctacteCajaId = CuentaCorrienteCajaService.Guardar(campos, sesion);

                                break;
                        }

                        break;
                    case Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL:
                        
                        campos = new System.Collections.Hashtable();
                        campos.Add(CuentaCorrienteCajaService.Fecha_NombreCol, fecha);
                        campos.Add(CuentaCorrienteCajaService.MonedaId_NombreCol, moneda_id);
                        campos.Add(CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, cotizacion_moneda);
                        campos.Add(CuentaCorrienteCajaService.Monto_NombreCol, -monto);
                        if (ctacte_valor_id == (decimal)Definiciones.CuentaCorrienteValores.Efectivo)
                            campos.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo);
                        else if (ctacte_valor_id == (decimal)Definiciones.CuentaCorrienteValores.Cheque)
                        {
                            campos.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Cheque);
                            campos.Add(CuentaCorrienteCajaService.CtacteChequeRecibidoId_NombreCol, ctacte_cheque_recibido_id);
                        }
                        else if (ctacte_valor_id == (decimal)Definiciones.CuentaCorrienteValores.POS)
                            campos.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.POS);

                        campos.Add(CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID);
                        campos.Add(CuentaCorrienteCajaService.SucursalId_NombreCol, dtCtacteCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.SucursalId_NombreCol]);
                        campos.Add(CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, dtCtacteCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol]);
                        campos.Add(CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.EgresoPorTransferencia);
                        campos.Add(CuentaCorrienteCajaService.TransferenciaCajaSucId_NombreCol, registro_cabecera_id);
                        campos.Add(CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, ctacte_caja_sucursal_id);
                        ctacteCajaId = CuentaCorrienteCajaService.Guardar(campos, sesion);
                        break;

                    default: throw new Exception("CuentaCorrienteCajaService.Egreso. Flujo no implementado");
                }

                return ctacteCajaId;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Egreso

        #region DeshacerEgreso
        /// <summary>
        /// Deshacers the egreso.
        /// </summary>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="registro_detalle_id">The registro_detalle_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void DeshacerEgreso(int flujo_id, decimal registro_detalle_id, SessionService sesion)
        {
            try
            {
                CuentaCorrienteChequesRecibidosService ctacteCheque = new CuentaCorrienteChequesRecibidosService();
                CTACTE_CAJARow row;
                string valorAnterior;
                int ctacteValorId;

                switch(flujo_id)
                {
                    case Definiciones.FlujosIDs.DEPOSITO_BANCARIO:
                        row = sesion.Db.CTACTE_CAJACollection.GetByDEPOSITO_BANCARIO_DET_ID(registro_detalle_id)[0];
                        break;
                    default: throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.DeshacerEgreso. Flujo no implementado");
                }

                valorAnterior = row.ToString();

                ctacteValorId = Convert.ToInt32(row.CTACTE_VALOR_ID);
                switch (ctacteValorId)
                {
                    case Definiciones.CuentaCorrienteValores.Efectivo:
                        row.ESTADO = Definiciones.Estado.Inactivo;
                        sesion.Db.CTACTE_CAJACollection.Update(row);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
                        break;
                    case Definiciones.CuentaCorrienteValores.Cheque:
                        ctacteCheque.DeshacerParaDepositoPorDepositoBancario(row.CTACTE_CHEQUE_RECIBIDO_ID, sesion);
                        row.IsDEPOSITO_BANCARIO_DET_IDNull = true;

                        sesion.Db.CTACTE_CAJACollection.Update(row);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                        break;

                    default: throw new Exception("CuentaCorrienteCajaService.DeshacerEgreso. Tipo de valor no implementado");
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion DeshacerEgreso

        #region BorrarPagoPersona
        /// <summary>
        /// Borrars the pago persona.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <exception cref="System.Exception">El valor no puede ser borrado porque la caja no se encuentra abierta.</exception>
        public static void BorrarPagoPersona(decimal ctacte_pago_persona_id, SessionService sesion)
        {
            string clausulas = CuentaCorrienteCajaService.CtactePagoPersonaId_NombreCol + " = " + ctacte_pago_persona_id + " and " +
                               CuentaCorrienteCajaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            CTACTE_CAJARow[] rows = sesion.Db.CTACTE_CAJACollection.GetAsArray(clausulas, CuentaCorrienteCajaService.Id_NombreCol);

            if (rows.Length <= 0)
                return;

            //Controlar que la caja este abierta o cerrada (pero no transferida ni aceptada en tesoreria)
            DataTable dtCaja = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalDataTable2(CuentaCorrienteCajasSucursalService.Id_NombreCol + " = " + rows[0].CTACTE_CAJA_SUCURSAL_ID, string.Empty);
            if (!dtCaja.Rows[0][CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol].Equals(Definiciones.CuentaCorrienteCajaSucursalEstados.Abierta) &&
                !dtCaja.Rows[0][CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol].Equals(Definiciones.CuentaCorrienteCajaSucursalEstados.Cerrada))
            {
                throw new Exception("El valor no puede ser borrado porque la caja se encuentra en estado " + dtCaja.Rows[0][CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol] + ".");
            }

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].ESTADO = Definiciones.Estado.Inactivo;
                rows[i].IsCTACTE_CHEQUE_RECIBIDO_IDNull = true; //Se desvincula para poder borrar el cheque que no tiene borrado logico
                sesion.Db.CTACTE_CAJACollection.Update(rows[i]);
            }
        }
        #endregion BorrarPagoPersona

        #region ActualizarMovimiento
        /// <summary>
        /// Actualizars the movimiento.
        /// </summary>
        /// <param name="ctacte_caja_id">The ctacte_caja_id.</param>
        /// <param name="ctacte_caja_sucursal_id">The ctacte_caja_sucursal_id.</param>
        /// <param name="fecha">The fecha.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarMovimiento(decimal ctacte_caja_id, decimal ctacte_caja_sucursal_id, DateTime fecha, SessionService sesion)
        {
            CTACTE_CAJARow row = sesion.db.CTACTE_CAJACollection.GetByPrimaryKey(ctacte_caja_id);
            string valorAnterior = row.ToString();
            
            row.FECHA = fecha;
            row.CTACTE_CAJA_SUCURSAL_ID = ctacte_caja_sucursal_id;
            row.FUNCIONARIO_COBRADOR_ID = CuentaCorrienteCajasSucursalService.GetFuncionarioCobradorId(ctacte_caja_sucursal_id);

            sesion.db.CTACTE_CAJACollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion ActualizarMovimiento

        // poner en null DEPOSITO_BANCARIO_DET_ID para borrar el detalle del depósito
        #region ActualizarDepositoBancarioDet
        public static void ActualizarDepositoBancarioDet(decimal deposito_bancario_detalle_id, SessionService sesion)
        {
            CTACTE_CAJARow[] row = sesion.db.CTACTE_CAJACollection.GetByDEPOSITO_BANCARIO_DET_ID(deposito_bancario_detalle_id);
            string valorAnterior = row.ToString();

            foreach (CTACTE_CAJARow item in row)
            {
                item.IsDEPOSITO_BANCARIO_DET_IDNull = true;
                sesion.db.CTACTE_CAJACollection.Update(item);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, item.ID, valorAnterior, row.ToString(), sesion);    
            }
        }
        #endregion ActualizarDepositoBancarioDet

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_CAJA"; }
        }
        public static string Nombre_Vista
        {
            get { return "ctacte_caja_info_completa"; }
        }
        public static string AnticipoPersonaId_NombreCol
        {
            get { return CTACTE_CAJACollection.ANTICIPO_PERSONA_IDColumnName; }
        }
        public static string AnticipoPersonaDetId_NombreCol
        {
            get { return CTACTE_CAJACollection.ANTICIPO_PERSONA_DET_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_CAJACollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteCajaReservaDetId_NombreCol
        {
            get { return CTACTE_CAJACollection.CTACTE_CAJA_RESERVA_DET_IDColumnName; }
        }
        public static string CtacteChequeRecibidoId_NombreCol
        {
            get { return CTACTE_CAJACollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CtacteConceptoId_NombreCol
        {
            get { return CTACTE_CAJACollection.CTACTE_CONCEPTO_IDColumnName; }
        }
        public static string CtacteFondoFijoMovId_NombreCol
        {
            get { return CTACTE_CAJACollection.CTACTE_FONDO_FIJO_MOV_IDColumnName; }
        }
        public static string CtactePagoPersonaDetId_NombreCol
        {
            get { return CTACTE_CAJACollection.CTACTE_PAGO_PERSONA_DET_IDColumnName; }
        }
        public static string CtactePagoPersonaId_NombreCol
        {
            get { return CTACTE_CAJACollection.CTACTE_PAGO_PERSONA_IDColumnName; }
        }
        public static string CtacteCajaSucursalId_NombreCol
        {
            get { return CTACTE_CAJACollection.CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return CTACTE_CAJACollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string DepositoBancarioDetId_NombreCol
        {
            get { return CTACTE_CAJACollection.DEPOSITO_BANCARIO_DET_IDColumnName; }
        }
        public static string EgresoVarioId_NombreCol
        {
            get { return CTACTE_CAJACollection.EGRESO_VARIO_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_CAJACollection.ESTADOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CTACTE_CAJACollection.FECHAColumnName; }
        }
        public static string FuncionarioCobradorId_NombreCol
        {
            get { return CTACTE_CAJACollection.FUNCIONARIO_COBRADOR_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_CAJACollection.IDColumnName; }
        }
        public static string TransferenciaCajaSucId_NombreCol
        {
            get { return CTACTE_CAJACollection.TRANSFERENCIA_CAJA_SUC_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_CAJACollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTACTE_CAJACollection.MONTOColumnName; }
        }
        public static string MovimientoFondoFijoId_NombreCol
        {
            get { return CTACTE_CAJACollection.MOVIMIENTO_FONDO_FIJO_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CTACTE_CAJACollection.SUCURSAL_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return CTACTE_CAJACollection.USUARIO_IDColumnName; }
        }
        public static string VistaCtacteChequeRecDatosResum_NombreCol
        {
            get { return CTACTE_CAJA_INFO_COMPLETACollection.CTACTE_CHEQUE_REC_DATOS_RESUMColumnName; }
        }
        public static string VistaCtacteChequeRecibidoEmisor_NombreCol
        {
            get { return CTACTE_CAJA_INFO_COMPLETACollection.CTACTE_CHEQUE_RECIBIDO_EMISORColumnName; }
        }
        public static string VistaCtacteChequeRecibidoEstadoId_NombreCol
        {
            get { return CTACTE_CAJA_INFO_COMPLETACollection.CTACTE_CHQ_RECIBIDO_ESTADO_IDColumnName; }
        }
        public static string VistaCtacteChequeRecibidoEstado_NombreCol
        {
            get { return CTACTE_CAJA_INFO_COMPLETACollection.CTACTE_CHQ_RECIBIDO_ESTADOColumnName; }
        }
        public static string VistaCtacteChequeRecibidoNumero_NombreCol
        {
            get { return CTACTE_CAJA_INFO_COMPLETACollection.CTACTE_CHEQUE_RECIBIDO_NUMEROColumnName; }
        }
        public static string VistaCtacteChequeRecibidoVenc_NombreCol
        {
            get { return CTACTE_CAJA_INFO_COMPLETACollection.CTACTE_CHEQUE_RECIBIDO_VENCColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CTACTE_CAJA_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaUsuarioNombre_NombreCol
        {
            get { return CTACTE_CAJA_INFO_COMPLETACollection.USUARIO_NOMBREColumnName; }
        }
        public static string VistaUsuarioUsuario_NombreCol
        {
            get { return CTACTE_CAJA_INFO_COMPLETACollection.USUARIO_USUARIOColumnName; }
        }
        public static string VistaFuncionarioCobradorNombre_NombreCol
        {
            get { return CTACTE_CAJA_INFO_COMPLETACollection.FUNCIONARIO_COBRADOR_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_CAJA_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_CAJA_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaCtacteValorNombre_NombreCol
        {
            get { return CTACTE_CAJA_INFO_COMPLETACollection.CTACTE_VALOR_NOMBREColumnName; }
        }
        public static string VistaCtacteReciboId_NombreCol
        {
            get { return CTACTE_CAJA_INFO_COMPLETACollection.CTACTE_RECIBO_IDColumnName; }
        }
        public static string VistaCtacteReciboNro_NombreCol
        {
            get { return CTACTE_CAJA_INFO_COMPLETACollection.CTACTE_RECIBO_NROColumnName; }
        }
        #endregion Accessors
    }
}
