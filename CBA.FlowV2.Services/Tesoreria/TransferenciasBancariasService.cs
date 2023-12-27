#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using System.Collections;
using CBA.FlowV2.Services.TextosPredefinidos;
using System.Collections.Generic;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Anticipo;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class TransferenciasBancariasService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var drCabecera = (DataRow)caso_cabecera;
            var drDetalle = (DataRow)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);
            
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, );
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, drCabecera[TransferenciasBancariasService.TextoPredefinidoId_NombreCol]);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza las acciones necesarias al cambiar de estado un caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_destino">The estado_destino.</param>
        /// <param name="cambio_pedido_por_usuario">El cambio fue pedido por el usuario o por el sistema</param>
        /// <param name="mensaje">The mensaje de salida.</param>
        /// <returns>
        /// True si no los controles se ejecutaron exitosamente, si no false.
        /// </returns>
        public override bool ProcesarCambioEstado(decimal caso_id, string estado_destino, bool cambio_pedido_por_usuario, out string mensaje, SessionService sesion)
        {
                bool exito = false;
                bool revisarRequisitos = false;
                mensaje = string.Empty;
                try
                {
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    TRANSFERENCIAS_BANCARIASRow cabeceraRow = sesion.Db.TRANSFERENCIAS_BANCARIASCollection.GetByCASO_ID(caso_id)[0];

                    //Borrador a Anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    //Borrador a Pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    //Pendiente a Borrador 
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                    }
                    //Pendiente a Anulado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    //Pendiente a Aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones:
                        //si la cuenta origen es administrada por el 
                        //sistema, disminuye su saldo según el monto transferido
                        //Si la transferencia es con cheque debe crearse
                        exito = true;
                        revisarRequisitos = true;

                        //si la cuenta origen es administrada por el 
                        //sistema, disminuye su saldo según el monto transferido
                        if (cabeceraRow.CUENTA_ORIGEN_ADMINISTRADA.Equals(Definiciones.SiNo.Si))
                        {
                            // Si se emite cheque con la transferencia, se crea el cheque y el movimiento bancario
                            if (!cabeceraRow.IsCG_FECHA_EMISIONNull)
                            {
                                Hashtable campos = new Hashtable();
                                decimal autonumeracion_id = Definiciones.Error.Valor.EnteroPositivo;
                                string nroCheque;

                                campos.Add(CuentaCorrienteChequesGiradosService.CasoCreadorId_NombreCol, cabeceraRow.CASO_ID);
                                campos.Add(CuentaCorrienteChequesGiradosService.CotizacionMoneda_NombreCol, cabeceraRow.COTIZACION_MONEDA_ORIGEN);
                                campos.Add(CuentaCorrienteChequesGiradosService.CtaCteBancariaId_NombreCol, cabeceraRow.CTACTE_BANCARIA_ORIGEN_ID);
                                campos.Add(CuentaCorrienteChequesGiradosService.EsDiferido_NombreCol, cabeceraRow.CG_ES_DIFERIDO);
                                campos.Add(CuentaCorrienteChequesGiradosService.FechaPosdatado_NombreCol, cabeceraRow.CG_FECHA_EMISION);
                                campos.Add(CuentaCorrienteChequesGiradosService.FechaVencimiento_NombreCol, cabeceraRow.CG_FECHA_VENCIMIENTO);
                                campos.Add(CuentaCorrienteChequesGiradosService.MonedaId_NombreCol, cabeceraRow.MONEDA_ORIGEN_ID);
                                campos.Add(CuentaCorrienteChequesGiradosService.Monto_NombreCol, cabeceraRow.MONTO_ORIGEN);
                                campos.Add(CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol, cabeceraRow.CG_NOMBRE_BENEFICIARIO);
                                campos.Add(CuentaCorrienteChequesGiradosService.NumeroCtaBeneficiario_NombreCol, string.Empty);
                                campos.Add(CuentaCorrienteChequesGiradosService.NombreEmisor_NombreCol, cabeceraRow.CG_NOMBRE_EMISOR);
                                campos.Add(CuentaCorrienteChequesGiradosService.Observacion_NombreCol, cabeceraRow.OBSERVACION);

                                if (cabeceraRow.CG_USAR_CHEQUERA == Definiciones.SiNo.Si)
                                {
                                    campos.Add(CuentaCorrienteChequesGiradosService.AutonumeracionId_NombreCol, cabeceraRow.CG_AUTONUMERACION_ID);
                                    autonumeracion_id = cabeceraRow.CG_AUTONUMERACION_ID;
                                }

                                if (cabeceraRow.CG_NUMERO_CHEQUE != null && cabeceraRow.CG_NUMERO_CHEQUE.Length > 0)
                                    campos.Add(CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol, cabeceraRow.CG_NUMERO_CHEQUE);
                                        

                                //Se crea el cheque girado
                                cabeceraRow.CG_CHEQUE_GIRADO_ID = CuentaCorrienteChequesGiradosService.Emitir(campos, autonumeracion_id, out nroCheque, sesion);
                                cabeceraRow.CG_NUMERO_CHEQUE = nroCheque;

                                //Se actualiza en la base de datos el id del cheque girado
                                sesion.Db.TRANSFERENCIAS_BANCARIASCollection.Update(cabeceraRow);

                                //Se afecta la cuenta bancaria si el cheque no es adelantado
                                if (cabeceraRow.CG_FECHA_VENCIMIENTO.Date <= DateTime.Now.Date)
                                {
                                    CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                        cabeceraRow.CTACTE_BANCARIA_ORIGEN_ID,
                                        Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA,
                                        cabeceraRow.CASO_ID,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        cabeceraRow.ID,
                                        cabeceraRow.MONEDA_ORIGEN_ID,
                                        cabeceraRow.MONTO_ORIGEN * (-1),
                                        cabeceraRow.COTIZACION_MONEDA_ORIGEN,
                                        cabeceraRow.FECHA,
                                        "Caso " + cabeceraRow.CASO_ID + " de " + FlujosService.GetDescripcionImpresion(Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA) + " pasado al estado " + estado_destino + ". Cheque " + cabeceraRow.CG_NUMERO_CHEQUE + " fecha " + cabeceraRow.CG_FECHA_EMISION.Date + ".",
                                        cabeceraRow.CG_CHEQUE_GIRADO_ID,
                                        null,
                                        false,
                                        sesion);
                                }
                            }
                            // Si no se emite cheque con la transferencia, solo se crea el movimiento bancario
                            else
                            {
                                CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                    cabeceraRow.CTACTE_BANCARIA_ORIGEN_ID, 
                                    Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA,
                                    cabeceraRow.CASO_ID,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    cabeceraRow.ID,
                                    cabeceraRow.MONEDA_ORIGEN_ID,
                                    cabeceraRow.MONTO_ORIGEN * (-1), //-1 por ser egreso
                                    cabeceraRow.COTIZACION_MONEDA_ORIGEN,
                                    cabeceraRow.FECHA,
                                    "Caso " + cabeceraRow.CASO_ID + " de " + Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA) + " pasado al estado " + estado_destino + ".",
                                    null,
                                    null,
                                    false,
                                    sesion);
                            }
                        }
                    }
                    //Aprobado a Anulado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones:
                        //si la cuenta origen es administrada por el 
                        //sistema, aumenta su saldo según el monto transferido
                        //Si se emitio un cheque debe ser anulado
                        exito = true;
                        revisarRequisitos = true;

                        //si la cuenta origen es administrada por el 
                        //sistema, disminuye su saldo según el monto transferido
                        if (cabeceraRow.CUENTA_ORIGEN_ADMINISTRADA.Equals(Definiciones.SiNo.Si))
                        {
                            // Si se emite cheque con la transferencia, se crea el cheque y el movimiento bancario
                            if (!cabeceraRow.IsCG_CHEQUE_GIRADO_IDNull)
                            {
                                #region Cheque girado
                                DataTable dtChequeGirado = CuentaCorrienteChequesGiradosService.GetCuentaCorrienteChequesGiradosDataTable(CuentaCorrienteChequesGiradosService.Id_NombreCol + " = " + cabeceraRow.CG_CHEQUE_GIRADO_ID, string.Empty);

                                //Se anula el cheque
                                CuentaCorrienteChequesGiradosService.Anular(cabeceraRow.CG_CHEQUE_GIRADO_ID,
                                                          "Anulado al pasar Transferencia Bancaria caso " + cabeceraRow.CASO_ID + " del estado " + casoRow.ESTADO_ID + " a " + estado_destino + ".",
                                                          sesion);

                                if (CuentaCorrienteChequesGiradosService.SaldoAfectado(cabeceraRow.CG_CHEQUE_GIRADO_ID, sesion))
                                {
                                    CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                        (decimal)dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.CtaCteBancariaId_NombreCol],
                                        Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA,
                                        cabeceraRow.CASO_ID,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        cabeceraRow.ID,
                                        (decimal)dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.MonedaId_NombreCol],
                                        (decimal)dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.Monto_NombreCol],
                                        (decimal)dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.CotizacionMoneda_NombreCol],
                                        (DateTime)dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.FechaVencimiento_NombreCol],
                                        "Caso " + cabeceraRow.CASO_ID + " de " + Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA) + " pasado del estado " + casoRow.ESTADO_ID + " al estado " + estado_destino + ". Anulación del cheque " + dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol] + " fecha " + ((DateTime)dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.FechaPosdatado_NombreCol]).Date + ".",
                                        cabeceraRow.CG_CHEQUE_GIRADO_ID,
                                        null,
                                        true,
                                        sesion);
                                }
                                #endregion Cheque girado
                            }
                            // Si no se emite cheque con la transferencia, solo se crea el movimiento bancario
                            else
                            {
                                CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                    cabeceraRow.CTACTE_BANCARIA_ORIGEN_ID,
                                    Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA,
                                    cabeceraRow.CASO_ID,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    cabeceraRow.ID,
                                    cabeceraRow.MONEDA_ORIGEN_ID,
                                    cabeceraRow.MONTO_ORIGEN,
                                    cabeceraRow.COTIZACION_MONEDA_ORIGEN,
                                    cabeceraRow.FECHA,
                                    "Caso " + cabeceraRow.CASO_ID + " de " + Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA) + " pasado al estado " + estado_destino + ".",
                                    null,
                                    null,
                                    true,
                                    sesion);
                            }
                        }
                    }
                    //Aprobado a Pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones:
                        //si la cuenta origen es administrada por el 
                        //sistema, aumenta su saldo según el monto transferido
                        //Si se emitio un cheque debe ser borrado
                        exito = true;
                        revisarRequisitos = true;
                        decimal chequeGiradoId;

                        //si la cuenta origen es administrada por el 
                        //sistema, disminuye su saldo según el monto transferido
                        if (cabeceraRow.CUENTA_ORIGEN_ADMINISTRADA.Equals(Definiciones.SiNo.Si))
                        {
                            // Si se emite cheque con la transferencia, se crea el cheque y el movimiento bancario
                            if (!cabeceraRow.IsCG_CHEQUE_GIRADO_IDNull)
                            {
                                chequeGiradoId = cabeceraRow.CG_CHEQUE_GIRADO_ID;
                                cabeceraRow.IsCG_CHEQUE_GIRADO_IDNull = true;
                                sesion.db.TRANSFERENCIAS_BANCARIASCollection.Update(cabeceraRow);

                                #region Cheque girado
                                DataTable dtChequeGirado = CuentaCorrienteChequesGiradosService.GetCuentaCorrienteChequesGiradosDataTable(CuentaCorrienteChequesGiradosService.Id_NombreCol + " = " + chequeGiradoId, string.Empty);

                                if (CuentaCorrienteChequesGiradosService.SaldoAfectado(chequeGiradoId, sesion))
                                {
                                    CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                        (decimal)dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.CtaCteBancariaId_NombreCol],
                                        Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA,
                                        cabeceraRow.CASO_ID,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        cabeceraRow.ID,
                                        (decimal)dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.MonedaId_NombreCol],
                                        (decimal)dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.Monto_NombreCol],
                                        (decimal)dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.CotizacionMoneda_NombreCol],
                                        (DateTime)dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.FechaVencimiento_NombreCol],
                                        "Caso " + cabeceraRow.CASO_ID + " de " + Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA) + " pasado del estado " + casoRow.ESTADO_ID + " al estado " + estado_destino + ". Anulación del cheque " + dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol] + " fecha " + ((DateTime)dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.FechaPosdatado_NombreCol]).Date + ".",
                                        chequeGiradoId,
                                        null,
                                        true,
                                        sesion);
                                }

                                //Se borra el cheque
                                CuentaCorrienteChequesGiradosService.Borrar(chequeGiradoId, sesion);
                                #endregion Cheque girado
                            }
                            // Si no se emite cheque con la transferencia, solo se crea el movimiento bancario
                            else
                            {
                                CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                    cabeceraRow.CTACTE_BANCARIA_ORIGEN_ID,
                                    Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA,
                                    cabeceraRow.CASO_ID,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    cabeceraRow.ID,
                                    cabeceraRow.MONEDA_ORIGEN_ID,
                                    cabeceraRow.MONTO_ORIGEN,
                                    cabeceraRow.COTIZACION_MONEDA_ORIGEN,
                                    cabeceraRow.FECHA,
                                    "Caso " + cabeceraRow.CASO_ID + " de " + Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA) + " pasado al estado " + estado_destino + ".",
                                    null,
                                    null,
                                    true,
                                    sesion);
                            }
                        }
                    }
                    //Aprobado a Cerrado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //si la cuenta destino es administrada por el sistema, aumenta su 
                        //saldo incluyendo el monto recibido: monto enviado menos costo de 
                        //transferencia,  multiplicado por el factor de conversión entre monedas.
                        exito = true;
                        revisarRequisitos = true;


                        //Si la cuenta destino es administrada, afectar el saldo
                        if (cabeceraRow.CUENTA_DESTINO_ADMINISTRADA.Equals(Definiciones.SiNo.Si))
                        {
                            // Si no se emitio cheque para la transferencia
                            if (cabeceraRow.IsCG_FECHA_EMISIONNull)
                            {
                                CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                    cabeceraRow.CTACTE_BANCARIA_DESTINO_ID,
                                    Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA,
                                    cabeceraRow.CASO_ID,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    cabeceraRow.ID,
                                    cabeceraRow.MONEDA_DESTINO_ID,
                                    cabeceraRow.MONTO_DESTINO,
                                    cabeceraRow.COTIZACION_MONEDA_DESTINO,
                                    cabeceraRow.FECHA,
                                    "Caso " + cabeceraRow.CASO_ID + " de " + Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA) + " pasado al estado " + estado_destino + ".",
                                    null,
                                    null,
                                    false,
                                    sesion);
                            }
                            // Si se emitio cheque para la transferencia
                            else
                            {
                                CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                    cabeceraRow.CTACTE_BANCARIA_DESTINO_ID,
                                    Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA,
                                    cabeceraRow.CASO_ID,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    cabeceraRow.ID,
                                    cabeceraRow.MONEDA_DESTINO_ID,
                                    cabeceraRow.MONTO_DESTINO,
                                    cabeceraRow.COTIZACION_MONEDA_DESTINO,
                                    cabeceraRow.FECHA,
                                    "Caso " + cabeceraRow.CASO_ID + " de " + Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA) + " pasado al estado " + estado_destino + ". Cheque " + cabeceraRow.CG_NUMERO_CHEQUE + " fecha " + cabeceraRow.CG_FECHA_EMISION.Date + ".",
                                    cabeceraRow.CG_CHEQUE_GIRADO_ID,
                                    null,
                                    false,
                                    sesion);
                            }
                        }

                        if (cabeceraRow.CREAR_ANTICIPO_PERSONA == Definiciones.SiNo.Si)
                        {
                            string query = "";
                            query += "select ccbt." + CuentaCorrienteCuentasBancariasTercerosService.PersonaId_NombreCol + ", " + "\n";                            
                            query += "       tb." + TransferenciasBancariasService.MontoOrigen_NombreCol + ", " + "\n";                            
                            query += "       tb." + TransferenciasBancariasService.Fecha_NombreCol + "\n";
                            query += "from " + TransferenciasBancariasService.Nombre_Tabla + " tb, " + "\n";
                            query += CuentaCorrienteCuentasBancariasTercerosService.Nombre_Tabla + " ccbt " + "\n";
                            query += "where tb." + TransferenciasBancariasService.CtaCteBancTercerosOrigenId_NombreCol + " = ccbt." + CuentaCorrienteCuentasBancariasTercerosService.Id_NombreCol + " \n";
                            query += "and tb." + TransferenciasBancariasService.Id_NombreCol + " = " + cabeceraRow.ID;

                            DataTable dtTransferencia = sesion.db.EjecutarQuery(query);

                            Hashtable campos = new Hashtable();

                            campos.Add(AnticiposPersonaService.SucursalId_NombreCol, sesion.Usuario.SUCURSAL_ACTIVA_ID );
                            campos.Add(AnticiposPersonaService.PersonaId_NombreCol, dtTransferencia.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.PersonaId_NombreCol]);
                            campos.Add(AnticiposPersonaService.MonedaId_NombreCol, dtTransferencia.Rows[0][MonedaOrigenId_NombreCol]);
                            campos.Add(AnticiposPersonaService.FuncionarioCobradorId_NombreCol, sesion.Usuario.FUNCIONARIO_ID);                         
                            campos.Add(AnticiposPersonaService.Fecha_NombreCol, dtTransferencia.Rows[0][Fecha_NombreCol]);
                            campos.Add(AnticiposPersonaService.Observacion_NombreCol, "Anticipo creado desde Transferencias Bancarias");
                            DataTable dtRecibo = AutonumeracionesService.GetAutonumeracionesPorTabla2(CuentaCorrienteRecibosService.Nombre_Tabla);
                            campos.Add(AnticiposPersonaService.AutonmeracionReciboId_NombreCol, dtRecibo.Rows[0][CuentaCorrienteRecibosService.Id_NombreCol]);
                            
                            decimal vCasoAnticipo = Definiciones.Error.Valor.EnteroPositivo;
                            string vEstadoAnticipo = string.Empty;
                            decimal vIdAnticipo = Definiciones.Error.Valor.EnteroPositivo;

                            AnticiposPersonaService.Guardar(campos, true, ref vCasoAnticipo, ref vEstadoAnticipo, ref vIdAnticipo, sesion);

                            Hashtable camposDetalle = new Hashtable();
                            DataTable dtAnticipo = AnticiposPersonaService.GetAnticipoPersonaPorCasoDataTable2(vCasoAnticipo, sesion);
                            AnticiposPersonaDetalleService anticipoPersonaDetalle = new AnticiposPersonaDetalleService();

                            camposDetalle.Add(AnticiposPersonaDetalleService.AnticipoPersonaId_NombreCol, vIdAnticipo);
                            camposDetalle.Add(AnticiposPersonaDetalleService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.TransferenciaBancaria);
                            camposDetalle.Add(AnticiposPersonaDetalleService.MonedaId_NombreCol, cabeceraRow.MONEDA_ORIGEN_ID);
                            camposDetalle.Add(AnticiposPersonaDetalleService.Monto_NombreCol, cabeceraRow.MONTO_ORIGEN);
                            camposDetalle.Add(AnticiposPersonaDetalleService.CotizacionMoneda_NombreCol, cabeceraRow.COTIZACION_MONEDA_ORIGEN);
                            camposDetalle.Add(AnticiposPersonaDetalleService.TransferenciaBancariaId_NombreCol, cabeceraRow.ID);

                            anticipoPersonaDetalle.Guardar(camposDetalle, sesion);

                            exito = new AnticiposPersonaService().ProcesarCambioEstado(vCasoAnticipo, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                            if (exito)
                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(vCasoAnticipo, Definiciones.EstadosFlujos.Pendiente, "Transición Automática por creación desde Transferencia Bancaria", sesion);
                            
                            exito = new AnticiposPersonaService().ProcesarCambioEstado(vCasoAnticipo, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                            if (exito)
                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(vCasoAnticipo, Definiciones.EstadosFlujos.Aprobado, "Transición Automática por creación desde Transferencia Bancaria", sesion);

                            exito = new AnticiposPersonaService().ProcesarCambioEstado(vCasoAnticipo, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                            if (exito)
                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(vCasoAnticipo, Definiciones.EstadosFlujos.Cerrado, "Transición Automática por creación desde Transferencia Bancaria", sesion);

                            if (!exito)
                                throw new Exception("Error al tratar de pasar de estado el Anticipo");
                        }
                    }
                    //Cerrado a Aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Cerrado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //Verificar que la transferenica no fue utilizada en otros flujos
                        //
                        //si la cuenta destino es administrada por el sistema, disminuye su 
                        //saldo incluyendo el monto recibido: monto enviado menos costo de 
                        //transferencia,  multiplicado por el factor de conversión entre monedas.
                        exito = true;
                        revisarRequisitos = true;

                        #region Crear query
                        string sql = 
                            "select c." + CasosService.Id_NombreCol + " from " + Anticipo.AnticiposPersonaDetalleService.Nombre_Tabla + " apd, " + Anticipo.AnticiposPersonaService.Nombre_Tabla + " ap, " + CasosService.Nombre_Tabla + " c \n" +
                            " where apd." + Anticipo.AnticiposPersonaDetalleService.TransferenciaBancariaId_NombreCol + " = " + cabeceraRow.ID + " \n" +
                            "   and ap." + AnticiposPersonaService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " \n" + 
                            "   and apd." + Anticipo.AnticiposPersonaDetalleService.AnticipoPersonaId_NombreCol + " = ap." + Anticipo.AnticiposPersonaService.Id_NombreCol + " \n" +
                            "   and c."  + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' \n" +
                            "   and c."  + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' \n" +
                            " union \n" +
                            "select c." + CasosService.Id_NombreCol + " from " + DescuentoDocumentosPagosService.Nombre_Tabla + " ddp, " + DescuentoDocumentosService.Nombre_Tabla + " dd, " + CasosService.Nombre_Tabla + " c \n" +
                            " where ddp." + DescuentoDocumentosPagosService.TransferenciaBancariaId_NombreCol + " = " + cabeceraRow.ID + " \n" + 
                            "   and ddp." + DescuentoDocumentosPagosService.DescuentoDocumentoId_NombreCol + " = dd." + DescuentoDocumentosService.Id_NombreCol + " \n" + 
                            "   and dd." + DescuentoDocumentosService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " \n" + 
                            "   and c."  + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' \n" +
                            "   and c."  + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' \n" +
                            " union \n" +
                            "select c." + CasosService.Id_NombreCol + " from " + Giros.DesembolsosGirosService.Nombre_Tabla + " dg, " + CasosService.Nombre_Tabla + " c \n" +
                            " where dg." + Giros.DesembolsosGirosService.TransferenciaBancariaId_NombreCol + " = " + cabeceraRow.ID + " \n" + 
                            "   and dg." + Giros.DesembolsosGirosService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " \n" + 
                            "   and c."  + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' \n" +
                            "   and c."  + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' \n" +
                            " union \n" +
                            "select c." + CasosService.Id_NombreCol + " from " + OrdenesPagoValoresService.Nombre_Tabla + " opv, " + OrdenesPagoService.Nombre_Tabla + " op, " + CasosService.Nombre_Tabla + " c \n" +
                            " where opv." + OrdenesPagoValoresService.TransferenciaBancariaId_NombreCol + " = " + cabeceraRow.ID + " \n" + 
                            "   and opv." + OrdenesPagoValoresService.OrdenPagoId_NombreCol + " = op." + OrdenesPagoService.Id_NombreCol + " \n" + 
                            "   and op." + OrdenesPagoService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " \n" + 
                            "   and c."  + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' \n" +
                            "   and c."  + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' \n" +
                            " union \n" +
                            "select c." + CasosService.Id_NombreCol + " from " + CuentaCorrientePagosPersonaDetalleService.Nombre_Tabla + " cppd, " + PagosDePersonaService.Nombre_Tabla + " cpp, " + CasosService.Nombre_Tabla + " c \n" +
                            " where cppd." + CuentaCorrientePagosPersonaDetalleService.TransferenciaBancariaId_NombreCol + " = " + cabeceraRow.ID + " \n" +
                            "   and cppd." + CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol + " = cpp." + PagosDePersonaService.Id_NombreCol + " \n" +
                            "   and cppd." + CuentaCorrientePagosPersonaDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' \n" +
                            "   and cpp." + PagosDePersonaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' \n" + 
                            "   and cpp." + PagosDePersonaService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " \n" + 
                            "   and c."  + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' \n" +
                            "   and c."  + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' \n";
                        #endregion Crear query

                        DataTable dt = sesion.db.EjecutarQuery(sql);
                        if (dt.Rows.Count > 0)
                            throw new Exception("La Tranferencia Bancaria caso " + cabeceraRow.CASO_ID + " está siendo utilizada en el caso " + dt.Rows[0][CasosService.Id_NombreCol] + ".");

                        //Si la cuenta destino es administrada, afectar el saldo
                        if (cabeceraRow.CUENTA_DESTINO_ADMINISTRADA.Equals(Definiciones.SiNo.Si))
                        {
                            decimal? ctacteChequeGiradoId = null;
                            if (!cabeceraRow.IsCG_CHEQUE_GIRADO_IDNull)
                                ctacteChequeGiradoId = cabeceraRow.CG_CHEQUE_GIRADO_ID;

                            CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                cabeceraRow.CTACTE_BANCARIA_DESTINO_ID,
                                Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA,
                                cabeceraRow.CASO_ID,
                                Definiciones.Error.Valor.EnteroPositivo,
                                cabeceraRow.ID,
                                cabeceraRow.MONEDA_DESTINO_ID,
                                cabeceraRow.MONTO_DESTINO * (-1),
                                cabeceraRow.COTIZACION_MONEDA_DESTINO,
                                cabeceraRow.FECHA,
                                "Caso " + cabeceraRow.CASO_ID + " de " + Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA) + " pasado de " + casoRow.ESTADO_ID + " al estado " + estado_destino + ".",
                                ctacteChequeGiradoId,
                                null,
                                true,
                                sesion);
                         }

                        //Borrar el asiento que se creo
                        CBA.FlowV2.Services.Contabilidad.AsientosService.BorrarPorCasoYTransicion(
                        cabeceraRow.CASO_ID,
                        TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA, Definiciones.EstadosFlujos.Aprobado, Definiciones.EstadosFlujos.Cerrado, sesion),
                        sesion);
                    }

                    //Verificar si se cumplen los requisitos
                    if (exito && revisarRequisitos)
                    {
                        exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                    }

                    if (exito)
                    {
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.TRANSFERENCIAS_BANCARIASCollection.Update(cabeceraRow);
                    }
                }
                catch (Exception exp)
                {
                    exito = false;
                    throw exp;
                }
                return exito;
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza acciones necesarias una vez que se efectuo el cambio de estado
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion) { }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Obtener el numero de comprobante
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns>String con el numero de comprobante</returns>
        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion) 
        {
            return string.Empty;
        }

        #endregion Implementacion de metodos abstract

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
            return sesion.Db.TRANSFERENCIAS_BANCARIASCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetDataTable

        #region GetTransferenciasBancariasInfoCompleta
        /// <summary>
        /// Gets the transferencias bancarias info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTransferenciasBancariasInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTransferenciasBancariasInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetTransferenciasBancariasInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.TRANSFERENCIAS_BANCARIAS_INF_CCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetTransferenciasBancariasInfoCompleta

        #region GetTransferenciasBancariasPorId
        public static DataTable GetTransferenciasBancariasPorId(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRANSFERENCIAS_BANCARIASCollection.GetAsDataTable(TransferenciasBancariasService.Id_NombreCol + " = " + id, string.Empty);
            }
        }
        #endregion GetTransferenciasBancariasPorId

        #region GetTransferenciasBancariasPorCaso
        /// <summary>
        /// Gets the transferencias bancarias por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetTransferenciasBancariasPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRANSFERENCIAS_BANCARIASCollection.GetAsDataTable(TransferenciasBancariasService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetOrdenesPagoPorCaso

        #region GetTransferenciasBancariasParaOrdenDePago
        /// <summary>
        /// Gets the transferencias para otros flujos que se relacionen con una Transferencia bancaria.
        /// </summary>
        /// <param name="sucursal_id">The sucursal_id.</param>
        /// <returns></returns>
        /// 
        public static DataTable GetTransferenciasBancariasParaDesembolsoGiro(decimal sucursal_id, decimal moneda_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = TransferenciasBancariasService.VistaOrdenPagoUtilizaCasoId_NombreCol + " is null and " +
                                   "(" + TransferenciasBancariasService.SucursalOrigenId_NombreCol + " = " + sucursal_id + " or " + TransferenciasBancariasService.SucursalOrigenId_NombreCol + " is null) and " +
                                   TransferenciasBancariasService.MonedaDestinoId_NombreCol + " = " + moneda_id + " and " +
                                   TransferenciasBancariasService.CuentaOrigenAdministrada_NombreCol + " = '" + Definiciones.SiNo.No + "' and " +
                                   TransferenciasBancariasService.CuentaDestinoAdministrada_NombreCol + " = '" + Definiciones.SiNo.Si + "' and " +
                                   TransferenciasBancariasService.VistaCasoEstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Cerrado + "'";

                return sesion.Db.TRANSFERENCIAS_BANCARIAS_INF_CCollection.GetAsDataTable(clausulas, TransferenciasBancariasService.Fecha_NombreCol);
            }
        }

        public static DataTable GetTransferenciasBancariasParaOrdenDePago(decimal sucursal_id, int tipo_orden_pago_id,decimal beficiario_id, string clausulas_extra)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = TransferenciasBancariasService.VistaOrdenPagoUtilizaCasoId_NombreCol + " is null and " +
                                   "(" + TransferenciasBancariasService.SucursalOrigenId_NombreCol + " = " + sucursal_id + " or " + TransferenciasBancariasService.SucursalOrigenId_NombreCol + " is null) and " +
                                   TransferenciasBancariasService.CuentaOrigenAdministrada_NombreCol + " = '" + Definiciones.SiNo.Si + "' and " +
                                   TransferenciasBancariasService.CuentaDestinoAdministrada_NombreCol + " = '" + Definiciones.SiNo.No + "' and " +
                                   TransferenciasBancariasService.VistaCasoEstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Cerrado + "'";

                if (clausulas_extra.Length > 0)
                    clausulas += " and (" + clausulas_extra + ")";

                switch (tipo_orden_pago_id)
                {
                    case Definiciones.TiposOrdenesPago.PagoAProveedor:
                        clausulas += " and " + TransferenciasBancariasService.VistaFuncionarioDestinoId_NombreCol + " is null";
                        clausulas += " and " + TransferenciasBancariasService.VistaPersonaDestinoId_NombreCol + " is null";
                        if(!beficiario_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            clausulas += " and " + TransferenciasBancariasService.VistaProveedorDestinoId_NombreCol + "=" + beficiario_id;
                        break;
                    case Definiciones.TiposOrdenesPago.AdelantoFuncionario:
                    case Definiciones.TiposOrdenesPago.PagoFuncionarios:
                        clausulas += " and " + TransferenciasBancariasService.VistaFuncionarioDestinoId_NombreCol + " is not null";
                        if (!beficiario_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            clausulas += " and " + TransferenciasBancariasService.VistaFuncionarioDestinoId_NombreCol + "=" + beficiario_id;
                        break;
                    case Definiciones.TiposOrdenesPago.PagoAPersona:
                        clausulas += " and " + TransferenciasBancariasService.VistaFuncionarioDestinoId_NombreCol + " is null";
                        clausulas += " and " + TransferenciasBancariasService.VistaProveedorDestinoId_NombreCol + " is null";
                        if (!beficiario_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            clausulas += " and " + TransferenciasBancariasService.VistaPersonaDestinoId_NombreCol + "=" + beficiario_id;
                        break;
                }

                return sesion.Db.TRANSFERENCIAS_BANCARIAS_INF_CCollection.GetAsDataTable(clausulas, TransferenciasBancariasService.CasoId_NombreCol+" desc");
            }
        }
        #endregion GetTransferenciasBancariasParaOrdenDePago

        #region GetTransferenciasBancariasParaDescuentoDocumentos
        /// <summary>
        /// Gets the transferencias bancarias para orden de pago.
        /// </summary>
        /// <param name="sucursal_id">The sucursal_id.</param>
        /// <returns></returns>
        public static DataTable GetTransferenciasBancariasParaDescuentoDocumentos(decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = TransferenciasBancariasService.VistaOrdenPagoUtilizaCasoId_NombreCol + " is null and " +
                                   "(" + TransferenciasBancariasService.SucursalDestinoId_NombreCol + " = " + sucursal_id + " or " + TransferenciasBancariasService.SucursalDestinoId_NombreCol + " is null) and " +
                                   TransferenciasBancariasService.CuentaDestinoAdministrada_NombreCol + " = '" + Definiciones.SiNo.Si + "' and " +
                                   TransferenciasBancariasService.CuentaOrigenAdministrada_NombreCol + " = '" + Definiciones.SiNo.No + "' and " +
                                   TransferenciasBancariasService.VistaCasoEstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Cerrado + "'";

                return sesion.Db.TRANSFERENCIAS_BANCARIAS_INF_CCollection.GetAsDataTable(clausulas, TransferenciasBancariasService.Fecha_NombreCol);
            }
        }
        #endregion GetTransferenciasBancariasParaDescuentoDocumentos

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return Guardar(campos, insertarNuevo, ref caso_id, ref estado_id, sesion);
            }
        }

        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id, SessionService sesion) 
        {
            bool exito = false;
            TRANSFERENCIAS_BANCARIASRow row = new TRANSFERENCIAS_BANCARIASRow();

            try
            {
                SucursalesService sucursal = new SucursalesService();
                CuentaCorrienteBancosService banco = new CuentaCorrienteBancosService();
                CuentaCorrienteCuentasBancariasService ctaBancaria = new CuentaCorrienteCuentasBancariasService();
                
                string valorAnterior = string.Empty;

                int sucursalId = int.Parse(sesion.SucursalActiva_Id.ToString());
                if (campos.Contains(TransferenciasBancariasService.SucursalDestinoId_NombreCol))
                    sucursalId = int.Parse(campos[TransferenciasBancariasService.SucursalDestinoId_NombreCol].ToString());
                if (campos.Contains(TransferenciasBancariasService.SucursalOrigenId_NombreCol))
                    sucursalId = int.Parse(campos[TransferenciasBancariasService.SucursalOrigenId_NombreCol].ToString());

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    
                    CrearCasos CrearCaso = new CrearCasos(sucursalId,
                                                          int.Parse(Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA.ToString()),
                                                          int.Parse(sesion.Usuario_Id.ToString()),
                                                          SessionService.GetClienteIP());
                    row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                    row.ID = sesion.Db.GetSiguienteSecuencia("transferencias_bancarias_sqc");
                    caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                    estado_id = Definiciones.EstadosFlujos.Borrador;
                }
                else
                {
                    row = sesion.Db.TRANSFERENCIAS_BANCARIASCollection.GetRow(TransferenciasBancariasService.Id_NombreCol + " = " + campos[TransferenciasBancariasService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                row.FECHA = (DateTime)campos[TransferenciasBancariasService.Fecha_NombreCol];
                row.COSTO_TRANSFERENCIA = (decimal)campos[TransferenciasBancariasService.CostoTransferencia_NombreCol];

                //Si se utiliza
                if (campos.Contains(TransferenciasBancariasService.CtacteBancariaDestinoId_NombreCol))
                {
                    if (!CuentaCorrienteCuentasBancariasService.EstaActivo((decimal)campos[TransferenciasBancariasService.CtacteBancariaDestinoId_NombreCol]))
                        throw new Exception("La cuenta bancaria destino no se encuentra activa");

                    row.CTACTE_BANCARIA_DESTINO_ID = (decimal)campos[TransferenciasBancariasService.CtacteBancariaDestinoId_NombreCol];
                }
                else
                {
                    row.IsCTACTE_BANCARIA_DESTINO_IDNull = true;
                }

                //Si se utiliza (Cuenta destino de terceros)
                if (campos.Contains(TransferenciasBancariasService.CtaCteBancTercerosDestId_NombreCol))
                    row.CTACTE_BANC_TERCEROS_DEST_ID = (decimal)campos[TransferenciasBancariasService.CtaCteBancTercerosDestId_NombreCol];
                else
                    row.IsCTACTE_BANC_TERCEROS_DEST_IDNull = true;
                
                //Si se utiliza (Cuenta origen de terceros)
                if (campos.Contains(TransferenciasBancariasService.CtaCteBancTercerosOrigenId_NombreCol))
                    row.CTACTE_BANC_TERCEROS_ORIGEN_ID = (decimal)campos[TransferenciasBancariasService.CtaCteBancTercerosOrigenId_NombreCol];
                else
                    row.IsCTACTE_BANC_TERCEROS_ORIGEN_IDNull = true;

                //Si se utiliza
                if (campos.Contains(TransferenciasBancariasService.CtacteBancariaOrigenId_NombreCol))
                {
                    if (!CuentaCorrienteCuentasBancariasService.EstaActivo((decimal)campos[TransferenciasBancariasService.CtacteBancariaOrigenId_NombreCol]))
                        throw new Exception("La cuenta bancaria origen no se encuentra activa");

                    row.CTACTE_BANCARIA_ORIGEN_ID = (decimal)campos[TransferenciasBancariasService.CtacteBancariaOrigenId_NombreCol];
                }
                else
                {
                    row.IsCTACTE_BANCARIA_ORIGEN_IDNull = true;
                }

                //Si se utiliza
                if (campos.Contains(TransferenciasBancariasService.TextoPredefinidoId_NombreCol))
                    row.TEXTO_PREDEFINIDO_ID = (decimal)campos[TransferenciasBancariasService.TextoPredefinidoId_NombreCol];
                else
                    row.IsTEXTO_PREDEFINIDO_IDNull = true;


                row.CUENTA_DESTINO_ADMINISTRADA = (string)campos[TransferenciasBancariasService.CuentaDestinoAdministrada_NombreCol];
                row.CUENTA_ORIGEN_ADMINISTRADA = (string)campos[TransferenciasBancariasService.CuentaOrigenAdministrada_NombreCol];
                //cuentas de terceros
                row.CUENTA_ORIGEN_TERCEROS = (string)campos[TransferenciasBancariasService.CuentaOrigenTerceros_NombreCol];
                row.CUENTA_DESTINO_TERCEROS = (string)campos[TransferenciasBancariasService.CuentaDestinoTerceros_NombreCol];

                //Validar que al menos una de las cuentas sea de la empresa
                if (row.CUENTA_ORIGEN_ADMINISTRADA.Equals(Definiciones.SiNo.No) && row.CUENTA_DESTINO_ADMINISTRADA.Equals(Definiciones.SiNo.No))
                    throw new Exception("Al menos una de las cuentas debe ser de la empresa");

                row.COTIZACION_MONEDA_DESTINO = (decimal)campos[TransferenciasBancariasService.CotizacionMonedaDestino_NombreCol];
                row.MONEDA_DESTINO_ID = (decimal)campos[TransferenciasBancariasService.MonedaDestinoId_NombreCol];
                row.MONTO_DESTINO = (decimal)campos[TransferenciasBancariasService.MontoDestino_NombreCol];
                
                row.COTIZACION_MONEDA_ORIGEN = (decimal)campos[TransferenciasBancariasService.CotizacionMonedaOrigen_NombreCol];
                row.MONEDA_ORIGEN_ID = (decimal)campos[TransferenciasBancariasService.MonedaOrigenId_NombreCol]; 
                row.MONTO_ORIGEN = (decimal)campos[TransferenciasBancariasService.MontoOrigen_NombreCol];

                row.ES_COTIZACION_DIRECTA = (string)campos[TransferenciasBancariasService.EsCotizacionDirecta_NombreCol];

                if (campos[TransferenciasBancariasService.EsCotizacionDirecta_NombreCol].ToString() == Definiciones.SiNo.Si)
                    row.MONEDA_COT_DIRECTA_ID = (decimal)campos[TransferenciasBancariasService.MonedaCotDirectaId_NombreCol];

                //Banco y numero de cuentas de origen
                if (row.CUENTA_ORIGEN_TERCEROS.Equals(Definiciones.SiNo.Si))
                {
                    string clausulas = string.Empty;
                    clausulas = CuentaCorrienteCuentasBancariasTercerosService.Id_NombreCol + " = " + row.CTACTE_BANC_TERCEROS_ORIGEN_ID;
                    CuentaCorrienteCuentasBancariasTercerosService ctacteCuentaBancariaTerceros = new CuentaCorrienteCuentasBancariasTercerosService();
                    DataTable tabla = ctacteCuentaBancariaTerceros.GetCuentaCorrienteBancariasTercerosInfoCompleta(clausulas, CuentaCorrienteCuentasBancariasTercerosService.Id_NombreCol);
                    DataRow datos = tabla.Rows[0];
                    row.NUMERO_CUENTA_ORIGEN = (string)datos[CuentaCorrienteCuentasBancariasTercerosService.NumeroCuenta_NombreCol];
                    row.CTACTE_BANCO_ORIGEN_ID = (decimal)datos[CuentaCorrienteCuentasBancariasTercerosService.CtacteBancoId_NombreCol];
                }
                else 
                {
                    row.NUMERO_CUENTA_ORIGEN = (string)campos[TransferenciasBancariasService.NumeroCuentaOrigen_NombreCol];
                    if (row.CTACTE_BANCO_ORIGEN_ID.Equals(DBNull.Value) ||
                        row.CTACTE_BANCO_ORIGEN_ID != (decimal)campos[TransferenciasBancariasService.CtacteBancoOrigenId_NombreCol])
                    {
                        if (!CuentaCorrienteBancosService.EstaActivo((decimal)campos[TransferenciasBancariasService.CtacteBancoOrigenId_NombreCol]))
                            throw new Exception("El banco origen no se encuentra activo");

                        row.CTACTE_BANCO_ORIGEN_ID = (decimal)campos[TransferenciasBancariasService.CtacteBancoOrigenId_NombreCol];
                    }
                }

                //Banco y numero de cuentas destino
                if (row.CUENTA_DESTINO_TERCEROS.Equals(Definiciones.SiNo.Si))
                {
                    string clausulas = string.Empty;
                    clausulas = CuentaCorrienteCuentasBancariasTercerosService.Id_NombreCol + " = " + row.CTACTE_BANC_TERCEROS_DEST_ID;
                    CuentaCorrienteCuentasBancariasTercerosService ctacteCuentaBancariaTerceros = new CuentaCorrienteCuentasBancariasTercerosService();
                    DataTable tabla = ctacteCuentaBancariaTerceros.GetCuentaCorrienteBancariasTercerosInfoCompleta(clausulas, CuentaCorrienteCuentasBancariasTercerosService.Id_NombreCol);
                    DataRow datos = tabla.Rows[0];
                    row.NUMERO_CUENTA_DESTINO = (string)datos[CuentaCorrienteCuentasBancariasTercerosService.NumeroCuenta_NombreCol];
                    row.CTACTE_BANCO_DESTINO_ID = (decimal)datos[CuentaCorrienteCuentasBancariasTercerosService.CtacteBancoId_NombreCol];
                }
                else
                {
                    row.NUMERO_CUENTA_DESTINO = (string)campos[TransferenciasBancariasService.NumeroCuentaDestino_NombreCol];
                    if (row.CTACTE_BANCO_DESTINO_ID.Equals(DBNull.Value) ||
                       row.CTACTE_BANCO_DESTINO_ID != (decimal)campos[TransferenciasBancariasService.CtacteBancoDestinoId_NombreCol])
                   {
                       if (!CuentaCorrienteBancosService.EstaActivo((decimal)campos[TransferenciasBancariasService.CtacteBancoDestinoId_NombreCol]))
                           throw new Exception("El banco destino no se encuentra activo");

                       row.CTACTE_BANCO_DESTINO_ID = (decimal)campos[TransferenciasBancariasService.CtacteBancoDestinoId_NombreCol];
                   }                    
                }

                row.NUMERO_TRANSACCION = (string)campos[TransferenciasBancariasService.NumeroTransaccion_NombreCol];
                row.OBSERVACION = (string)campos[TransferenciasBancariasService.Observacion_NombreCol];
                row.NRO_SOLICITUD=(string)campos[TransferenciasBancariasService.NumeroSolicitud_NombreCol];
                
                //Si se utiliza
                if (campos.Contains(TransferenciasBancariasService.SucursalDestinoId_NombreCol))
                {
                    //Si cambia
                    if (row.IsSUCURSAL_DESTINO_IDNull ||
                        row.SUCURSAL_DESTINO_ID.Equals(DBNull.Value) ||
                        row.SUCURSAL_DESTINO_ID == (decimal)campos[TransferenciasBancariasService.SucursalDestinoId_NombreCol])
                    {
                        if (!SucursalesService.EstaActivo((decimal)campos[TransferenciasBancariasService.SucursalDestinoId_NombreCol]))
                            throw new Exception("La sucursal destino no se encuentra activa");

                        row.SUCURSAL_DESTINO_ID = (decimal)campos[TransferenciasBancariasService.SucursalDestinoId_NombreCol];
                    }
                }
                else
                {
                    row.IsSUCURSAL_DESTINO_IDNull = true;
                }

                //Si se utiliza
                if (campos.Contains(TransferenciasBancariasService.SucursalOrigenId_NombreCol))
                {
                    //Si cambia
                    if (row.IsSUCURSAL_ORIGEN_IDNull ||
                        row.SUCURSAL_ORIGEN_ID.Equals(DBNull.Value) ||
                        row.SUCURSAL_ORIGEN_ID == (decimal)campos[TransferenciasBancariasService.SucursalOrigenId_NombreCol])
                    {
                        if (!SucursalesService.EstaActivo((decimal)campos[TransferenciasBancariasService.SucursalOrigenId_NombreCol]))
                            throw new Exception("La sucursal origen no se encuentra activa");

                        row.SUCURSAL_ORIGEN_ID = (decimal)campos[TransferenciasBancariasService.SucursalOrigenId_NombreCol];
                    }
                }
                else
                {
                    row.IsSUCURSAL_ORIGEN_IDNull = true;
                }

                // Se guardan los campos del cheque a emitir, si se utilizan
                if (campos.Contains(TransferenciasBancariasService.CGAutonumeracionId_NombreCol))
                    row.CG_AUTONUMERACION_ID = (decimal)campos[TransferenciasBancariasService.CGAutonumeracionId_NombreCol];
                if (campos.Contains(TransferenciasBancariasService.CGEsDiferido_NombreCol))
                    row.CG_ES_DIFERIDO = (string)campos[TransferenciasBancariasService.CGEsDiferido_NombreCol];
                if (campos.Contains(TransferenciasBancariasService.CGFechaEmision_NombreCol))
                    row.CG_FECHA_EMISION = (DateTime)campos[TransferenciasBancariasService.CGFechaEmision_NombreCol];
                if (campos.Contains(TransferenciasBancariasService.CGFechaVencimiento_NombreCol))
                    row.CG_FECHA_VENCIMIENTO = (DateTime)campos[TransferenciasBancariasService.CGFechaVencimiento_NombreCol];
                if (campos.Contains(TransferenciasBancariasService.CGNombreBeneficiario_NombreCol))
                    row.CG_NOMBRE_BENEFICIARIO = (string)campos[TransferenciasBancariasService.CGNombreBeneficiario_NombreCol];
                if (campos.Contains(TransferenciasBancariasService.CGNombreEmisor_NombreCol))
                    row.CG_NOMBRE_EMISOR = (string)campos[TransferenciasBancariasService.CGNombreEmisor_NombreCol];
                if (campos.Contains(TransferenciasBancariasService.CGNumeroCheque_NombreCol))
                    row.CG_NUMERO_CHEQUE = (string)campos[TransferenciasBancariasService.CGNumeroCheque_NombreCol];
                if (campos.Contains(TransferenciasBancariasService.CGUsarChequera_NombreCol))
                    row.CG_USAR_CHEQUERA = (string)campos[TransferenciasBancariasService.CGUsarChequera_NombreCol];
                row.CREAR_ANTICIPO_PERSONA = (string)campos[TransferenciasBancariasService.CrearAnticipoCliente_NombreCol];
                
                if (insertarNuevo) sesion.Db.TRANSFERENCIAS_BANCARIASCollection.Insert(row);
                else sesion.Db.TRANSFERENCIAS_BANCARIASCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();
                camposCaso.Add(CasosService.SucursalId_NombreCol, (decimal)sucursalId);
                camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NUMERO_TRANSACCION);
                if (!Interprete.EsNullODBNull(row.NRO_SOLICITUD))
                    camposCaso.Add(CasosService.NroComprobante2_NombreCol, row.NRO_SOLICITUD);
                if (!row.IsCTACTE_BANC_TERCEROS_ORIGEN_IDNull || !row.IsCTACTE_BANC_TERCEROS_DEST_IDNull)
                {
                    DataTable dt;

                    if(!row.IsCTACTE_BANC_TERCEROS_ORIGEN_IDNull)
                        dt = CuentaCorrienteCuentasBancariasTercerosService.GetCuentaCorrienteBancariasTercerosDataTable(CuentaCorrienteCuentasBancariasTercerosService.Id_NombreCol + " = " + row.CTACTE_BANC_TERCEROS_ORIGEN_ID, string.Empty);
                    else
                        dt = CuentaCorrienteCuentasBancariasTercerosService.GetCuentaCorrienteBancariasTercerosDataTable(CuentaCorrienteCuentasBancariasTercerosService.Id_NombreCol + " = " + row.CTACTE_BANC_TERCEROS_DEST_ID, string.Empty);
                    
                    if (!Interprete.EsNullODBNull(dt.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.PersonaId_NombreCol]))
                        camposCaso.Add(CasosService.PersonaId_NombreCol, dt.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.PersonaId_NombreCol]);
                    if (!Interprete.EsNullODBNull(dt.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.ProveedorId_NombreCol]))
                        camposCaso.Add(CasosService.ProveedorId_NombreCol, dt.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.ProveedorId_NombreCol]);
                    if (!Interprete.EsNullODBNull(dt.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.FuncionarioId_NombreCol]))
                        camposCaso.Add(CasosService.FuncionarioId_NombreCol, dt.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.FuncionarioId_NombreCol]);
                }
                CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                #endregion Actualizar datos en tabla casos

                exito = true;
            }
            catch (Exception)
            {
                exito = false;

                //Si el caso fue creado el mismo debe borrarse
                if (insertarNuevo && row.CASO_ID > 0)
                {
                    (new CasosService()).Eliminar(row.CASO_ID, sesion);
                    caso_id = Definiciones.Error.Valor.EnteroPositivo;
                    estado_id = string.Empty;
                }

                throw;
            }
            return exito;
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borra de la base de datos el caso y la cabecera del flujo
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static bool Borrar(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    bool exito = true;
                    string mensaje = string.Empty;

                    //Se obtienen el caso y la factura a ser borrados
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    TRANSFERENCIAS_BANCARIASRow cabecera = sesion.Db.TRANSFERENCIAS_BANCARIASCollection.GetByCASO_ID(caso_id)[0];

                    if (caso.ESTADO_ID == Definiciones.EstadosFlujos.Aprobado || caso.ESTADO_ID == Definiciones.EstadosFlujos.Cerrado)
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse en el estado " + caso.ESTADO_ID + ".";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        //No se borra fisicamente por problemas de FK. Cuando exista borrado logico debera cambiar de estado aqui
                        //sesion.Db.TRANSFERENCIAS_BANCARIASCollection.DeleteByCASO_ID(caso_id);
                        //LogCambiosService.LogDeRegistro(Nombre_Tabla, cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                        //Se borra el caso
                        (new CasosService()).Eliminar(caso_id, sesion); 
                    }
                    else
                    {
                        throw new System.ArgumentException(mensaje);
                    }

                    sesion.CommitTransaction();
                    return exito;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion borrar

        #region CrearOrdenPago
        public static decimal CrearOrdenPago(decimal caso_id)
        {
            using(SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal casoCreadoId = Definiciones.Error.Valor.EnteroPositivo;
                    Hashtable[] detalles = new Hashtable[0];
                    Hashtable valor = new Hashtable();
                    DataTable dtTransferencia = TransferenciasBancariasService.GetTransferenciasBancariasInfoCompleta(CasoId_NombreCol + " = " + caso_id, string.Empty);
                    
                    if ((string)dtTransferencia.Rows[0][TransferenciasBancariasService.VistaCasoEstadoId_NombreCol] != Definiciones.EstadosFlujos.Cerrado)
                        throw new Exception("La transferencia debe estar en estado Cerrado para generar una Orden de Pago");

                    if ((string)dtTransferencia.Rows[0][TransferenciasBancariasService.CuentaOrigenAdministrada_NombreCol] != Definiciones.SiNo.Si || Interprete.EsNullODBNull(dtTransferencia.Rows[0][TransferenciasBancariasService.VistaProveedorDestinoId_NombreCol]))
                        throw new Exception("La transferencia debe ser de la empresa a un proveedor");

                    DataTable dtCataTesoreria = CuentaCorrienteCajasTesoreriaService.GetCuentaCorrienteCajasTesoreriaDataTable(CuentaCorrienteCajasTesoreriaService.SucursalId_NombreCol + " = " + dtTransferencia.Rows[0][TransferenciasBancariasService.SucursalOrigenId_NombreCol], CuentaCorrienteCajasTesoreriaService.Orden_NombreCol);
                    if (dtCataTesoreria.Rows.Count <= 0)
                        throw new Exception("No se encontró una caja de tesorería en la sucursal " + dtTransferencia.Rows[0][TransferenciasBancariasService.VistaSucursalOrigenNombre_NombreCol] + ".");

                    #region cabecera
                    Hashtable cabecera = new Hashtable();
                    cabecera.Add(OrdenesPagoService.OrdenPagoTipoId_NombreCol, Definiciones.TiposOrdenesPago.PagoAProveedor);
                    cabecera.Add(OrdenesPagoService.SucursalOrigenId_NombreCol, dtTransferencia.Rows[0][TransferenciasBancariasService.SucursalOrigenId_NombreCol]);
                    cabecera.Add(OrdenesPagoService.MonedaId_NombreCol, dtTransferencia.Rows[0][TransferenciasBancariasService.MonedaDestinoId_NombreCol]);
                    cabecera.Add(OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol, dtCataTesoreria.Rows[0][CuentaCorrienteCajasTesoreriaService.Id_NombreCol]);
                    cabecera.Add(OrdenesPagoService.ProveedorId_NombreCol, dtTransferencia.Rows[0][TransferenciasBancariasService.VistaProveedorDestinoId_NombreCol]);
                    cabecera.Add(OrdenesPagoService.Fecha_NombreCol, dtTransferencia.Rows[0][TransferenciasBancariasService.Fecha_NombreCol]);
                    cabecera.Add(OrdenesPagoService.Observacion_NombreCol, "Orden de Pago generada desde Transferencia Bancaria caso " + caso_id + ".");
                    #endregion cabecera

                    #region detalles
                    // Si hay una factura cuya deuda coincida con el monto de la transferencia, se agrega como detalle
                    Hashtable detalle = new Hashtable();
                    decimal cantidadDecimales = MonedasService.CantidadDecimalesStatic((decimal)dtTransferencia.Rows[0][TransferenciasBancariasService.MonedaDestinoId_NombreCol]);

                    string clausulas = CuentaCorrienteProveedoresService.ProveedorId_NombreCol + " = " + dtTransferencia.Rows[0][TransferenciasBancariasService.VistaProveedorDestinoId_NombreCol] + " and " +
                                       CuentaCorrienteProveedoresService.MonedaId_NombreCol + " = " + dtTransferencia.Rows[0][TransferenciasBancariasService.MonedaDestinoId_NombreCol] + " and " +
                                       "round(" + CuentaCorrienteProveedoresService.Credito_NombreCol + " - " + CuentaCorrienteProveedoresService.Debito_NombreCol + ", " + cantidadDecimales + ") = round(" + dtTransferencia.Rows[0][TransferenciasBancariasService.MontoDestino_NombreCol] + "," + cantidadDecimales + ") ";
                    DataTable dtCtacteProveedor = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresInfoCompleta(clausulas, CuentaCorrienteProveedoresService.FechaVencimiento_NombreCol, sesion);

                    if (dtCtacteProveedor.Rows.Count > 0)
                    {
                        detalles = new Hashtable[1];
                        detalles[0] = new Hashtable();
                        detalles[0].Add(OrdenesPagoDetalleService.CtacteProveedorId_NombreCol, (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.Id_NombreCol]);
                        detalles[0].Add(OrdenesPagoDetalleService.MonedaOrigenId_NombreCol, (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.MonedaId_NombreCol]);
                        detalles[0].Add(OrdenesPagoDetalleService.CasoReferidoId_NombreCol, (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.CasoId_NombreCol]);
                        detalles[0].Add(OrdenesPagoDetalleService.MontoOrigen_NombreCol, (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.Credito_NombreCol] - (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.Debito_NombreCol]);
                        detalles[0].Add(OrdenesPagoDetalleService.Observacion_NombreCol, (string)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.VistaObservacion_NombreCol]);
                    }
                    #endregion detalles

                    #region valores
                    valor.Add(OrdenesPagoValoresService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.TransferenciaBancaria);
                    valor.Add(OrdenesPagoValoresService.MonedaOrigenId_NombreCol, dtTransferencia.Rows[0][TransferenciasBancariasService.MonedaDestinoId_NombreCol]);
                    valor.Add(OrdenesPagoValoresService.MontoOrigen_NombreCol, dtTransferencia.Rows[0][TransferenciasBancariasService.MontoDestino_NombreCol]);
                    valor.Add(OrdenesPagoValoresService.Observacion_NombreCol, string.Empty);
                    valor.Add(OrdenesPagoValoresService.TransferenciaBancariaId_NombreCol, dtTransferencia.Rows[0][TransferenciasBancariasService.Id_NombreCol]);
                    #endregion valores

                    casoCreadoId = OrdenesPagoService.CrearOrdenPago(cabecera, detalles, Definiciones.Error.Valor.IntPositivo, valor, true, false, sesion);
                    sesion.CommitTransaction();

                    return casoCreadoId;
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion CrearOrdenPago

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TRANSFERENCIAS_BANCARIAS"; }
        }
        public static string Nombre_Vista
        {
            get { return "TRANSFERENCIAS_BANCARIAS_INF_C"; }
        }
        public static string CasoId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CASO_IDColumnName; }
        }
        public static string CGAutonumeracionId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CG_AUTONUMERACION_IDColumnName; }
        }
        public static string CGChequeGiradoId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CG_CHEQUE_GIRADO_IDColumnName; }
        }
        public static string CGEsDiferido_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CG_ES_DIFERIDOColumnName; }
        }
        public static string CGFechaEmision_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CG_FECHA_EMISIONColumnName; }
        }
        public static string CGFechaVencimiento_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CG_FECHA_VENCIMIENTOColumnName; }
        }
        public static string CGNombreBeneficiario_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CG_NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string CGNombreEmisor_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CG_NOMBRE_EMISORColumnName; }
        }
        public static string CGNumeroCheque_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CG_NUMERO_CHEQUEColumnName; }
        }
        public static string CGUsarChequera_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CG_USAR_CHEQUERAColumnName; }
        }
        public static string CostoTransferencia_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.COSTO_TRANSFERENCIAColumnName; }
        }
        public static string CotizacionMonedaDestino_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.COTIZACION_MONEDA_DESTINOColumnName; }
        }
        public static string CotizacionMonedaOrigen_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.COTIZACION_MONEDA_ORIGENColumnName; }
        }
        public static string CrearAnticipoCliente_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CREAR_ANTICIPO_PERSONAColumnName; }
        }
        public static string CtacteBancariaDestinoId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CTACTE_BANCARIA_DESTINO_IDColumnName; }
        }
        public static string CtacteBancariaOrigenId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CTACTE_BANCARIA_ORIGEN_IDColumnName; }
        }
        public static string CtacteBancoDestinoId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CTACTE_BANCO_DESTINO_IDColumnName; }
        }
        public static string CtacteBancoOrigenId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CTACTE_BANCO_ORIGEN_IDColumnName; }
        }
        public static string CuentaDestinoAdministrada_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CUENTA_DESTINO_ADMINISTRADAColumnName; }
        }
        public static string CuentaOrigenAdministrada_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CUENTA_ORIGEN_ADMINISTRADAColumnName; }
        }
        public static string EsCotizacionDirecta_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.ES_COTIZACION_DIRECTAColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.IDColumnName; }
        }
        public static string MonedaCotDirectaId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.MONEDA_COT_DIRECTA_IDColumnName; }
        }
        public static string MonedaDestinoId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.MONEDA_DESTINO_IDColumnName; }
        }
        public static string MonedaOrigenId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.MONEDA_ORIGEN_IDColumnName; }
        }
        public static string MontoDestino_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.MONTO_DESTINOColumnName; }
        }
        public static string MontoOrigen_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.MONTO_ORIGENColumnName; }
        }
        public static string NumeroCuentaDestino_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.NUMERO_CUENTA_DESTINOColumnName; }
        }
        public static string NumeroCuentaOrigen_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.NUMERO_CUENTA_ORIGENColumnName; }
        }
        public static string NumeroTransaccion_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.NUMERO_TRANSACCIONColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.OBSERVACIONColumnName; }
        }
        public static string SucursalDestinoId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.SUCURSAL_DESTINO_IDColumnName; }
        }
        public static string SucursalOrigenId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.SUCURSAL_ORIGEN_IDColumnName; }
        }
        public static string NumeroSolicitud_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.NRO_SOLICITUDColumnName; }
        }
        public static string CuentaOrigenTerceros_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CUENTA_ORIGEN_TERCEROSColumnName; }
        }
        public static string CuentaDestinoTerceros_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CUENTA_DESTINO_TERCEROSColumnName; }
        }
        public static string CtaCteBancTercerosOrigenId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CTACTE_BANC_TERCEROS_ORIGEN_IDColumnName; }
        }
        public static string CtaCteBancTercerosDestId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.CTACTE_BANC_TERCEROS_DEST_IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIASCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string VistaAnticipoProvUtilizaCasoId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.ANTICIPO_PROV_UTILIZA_CASO_IDColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCtacteBancoDestinoAbrev_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.CTACTE_BANCO_DESTINO_ABREVColumnName; }
        }
        public static string VistaCtacteBancoDestinoNombre_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.CTACTE_BANCO_DESTINO_NOMBREColumnName; }
        }
        public static string VistaCtacteBancoOrigenAbrev_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.CTACTE_BANCO_ORIGEN_ABREVColumnName; }
        }
        public static string VistaCtacteBancoOrigenNombre_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.CTACTE_BANCO_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaCtacteBancariaOrigenId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.CTACTE_BANCARIA_ORIGEN_IDColumnName; }
        }
        public static string VistaCtacteBancariaDestinoId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.CTACTE_BANCARIA_DESTINO_IDColumnName; }
        }
        public static string VistaMonedaDestinoNombre_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.MONEDA_DESTINO_NOMBREColumnName; }
        }
        public static string VistaMonedaDestinoSimbolo_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.MONEDA_DESTINO_SIMBOLOColumnName; }
        }
        public static string VistaMonedaOrigenNombre_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.MONEDA_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaMonedaOrigenSimbolo_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.MONEDA_ORIGEN_SIMBOLOColumnName; }
        }
        public static string VistaMonedaDirectaNombre_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.MONEDA_DIRECTA_NOMBREColumnName; }
        }
        public static string VistaMonedaDirectaSimbolo_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.MONEDA_DIRECTA_SIMBOLOColumnName; }
        }
        public static string VistaOrdenPagoRespaldaCasoId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.ORDEN_PAGO_RESPALDA_CASO_IDColumnName; }
        }
        public static string VistaOrdenPagoUtilizaCasoId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.ORDEN_PAGO_UTILIZA_CASO_IDColumnName; }
        }
        public static string VistaSucursalDestinoNombre_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.SUCURSAL_DESTINO_NOMBREColumnName; }
        }
        public static string VistaSucursalOrigenNombre_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.SUCURSAL_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaPersonaOrigenId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.PERSONA_ORIGEN_IDColumnName; }
        }
        public static string VistaPersonaDestinoId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.PERSONA_DESTINO_IDColumnName; }
        }
        public static string VistaProveedorOrigenId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.PROVEEDOR_ORIGEN_IDColumnName; }
        }
        public static string VistaProveedorDestinoId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.PROVEEDOR_DESTINO_IDColumnName; }
        }
        public static string VistaFuncionarioOrigenId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.FUNCIONARIO_ORIGEN_IDColumnName; }
        }
        public static string VistaFuncionarioDestinoId_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.FUNCIONARIO_DESTINO_IDColumnName; }
        }
        public static string VistaPersonaOrigenNombre_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.PERSONA_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaPersonaDestinoNombre_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.PERSONA_DESTINO_NOMBREColumnName; }
        }
        public static string VistaProveedorOrigenNombre_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.PROVEEDOR_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaProveedorDestinoNombre_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.PROVEEDOR_DESTINO_NOMBREColumnName; }
        }
        public static string VistaFuncionarioOrigenNombre_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.FUNCIONARIO_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaFuncionarioDestinoNombre_NombreCol
        {
            get { return TRANSFERENCIAS_BANCARIAS_INF_CCollection.FUNCIONARIO_DESTINO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
