using System;
using System.Data;
using CBA.FlowV2.Db;

using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.NotasDebitoPersona;
using CBA.FlowV2.Services.Sesion;
using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.ToolbarFlujo;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class TransferenciasCtaCtePersonasService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.TRANSFERENCIA_CTACTE_PERSONA;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);
            
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, );
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
                    TRANSFERENCIA_CTACTE_PERSONARow cabeceraRow = sesion.Db.TRANSFERENCIA_CTACTE_PERSONACollection.GetByCASO_ID(caso_id)[0];
                    DataTable dtDetalles = TransferenciasCtaCtePersonasDetallesService.GetTransferenciaDetalles(TransferenciasCtaCtePersonasDetallesService.TransferenciaCtaCtePersonaId_NombreCol + " = " + cabeceraRow.ID, string.Empty);

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

                        if (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE == string.Empty)
                        {
                            try
                            {
                                cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID);

                                //Controlar que se logro asignar una numeracion
                                if (cabeceraRow.NRO_COMPROBANTE.Equals(""))
                                {
                                    exito = false;
                                    mensaje = "No se pudo asignar una numeración válida";
                                }
                            }
                            catch (Exception exp)
                            {
                                mensaje = exp.Message.ToString();
                                exito = false;
                            }
                        }
                       
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

                        exito = true;
                        revisarRequisitos = true;

                        DataTable dtCtactePersonaDet, dtCtactePersonas;
                        System.Collections.Hashtable montoPorImpuesto = new System.Collections.Hashtable();
                        decimal[] impuestoId, monto;
                        int indiceAux;
                        decimal montoVerificacion;

                        #region Calcular monto por tipo de impuesto CREDITO
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            if ((decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.MontoCreditoDestino_NombreCol] <= 0)
                                continue;

                            dtCtactePersonas = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.Id_NombreCol + " = " + (decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.CtaCtePersonaOrigenId_NombreCol], string.Empty, sesion);
                            dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable((decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.CtaCtePersonaOrigenId_NombreCol], sesion);
                        
                            for (int j = 0; j < dtCtactePersonaDet.Rows.Count; j++)
                            {

                                decimal montoAux = (decimal)dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol] / (decimal)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol] * (decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.MontoCreditoDestino_NombreCol];

                                if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                                    montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + montoAux;
                                else
                                    montoPorImpuesto.Add(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], montoAux);
                            }
                        }

                        impuestoId = new decimal[montoPorImpuesto.Count];
                        monto = new decimal[montoPorImpuesto.Count];

                        indiceAux = 0;
                        montoVerificacion = 0;
                        foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                        {
                            impuestoId[indiceAux] = (decimal)par.Key;
                            monto[indiceAux] = (decimal)par.Value;

                            montoVerificacion += (decimal)par.Value;

                            indiceAux++;
                        }

                        if (cabeceraRow.MONTO_TOTAL_CREDITO != montoVerificacion)
                            throw new Exception("Error en TransferenciasCtaCtePersonasService.ProcesarCambioEstado(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total crédito en cabecera suma " + cabeceraRow.MONTO_TOTAL_CREDITO + ".");
                        #endregion Calcular monto por tipo de impuesto CREDITO

                        #region Afectar ctacte CREDITO
                        if (exito)
                        {
                            #region Agregar Credito a la CtaCte Destino
                            try
                            {
                                //Ingresar el credito a la persona que recibe la deuda
                                decimal ctacteDestinoId = CuentaCorrientePersonasService.AgregarCredito((decimal)cabeceraRow.PERSONA_DESTINO_ID,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.CuentaCorrienteConceptos.CreditoTransferenciaDeCtaCte,
                                                                cabeceraRow.CASO_ID,
                                                                cabeceraRow.MONEDA_ID,
                                                                cabeceraRow.COTIZACION,
                                                                impuestoId,
                                                                monto,
                                                                "Crédito por Transferencia de CtaCte Caso N°: " + cabeceraRow.CASO_ID,
                                                                cabeceraRow.FECHA_VENCIMIENTO_DESTINO,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                1,
                                                                1,
                                                                sesion);
                            }
                            catch (Exception exp)
                            {
                                mensaje = exp.Message.ToString();
                                exito = false;
                            }
                            #endregion Agregar Credito a la CtaCte Destino

                            #region Agregar debito a la CtaCte Origen
                            montoPorImpuesto = new System.Collections.Hashtable();
                            for (int i = 0; i < dtDetalles.Rows.Count; i++)
                            {
                                if ((decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.MontoCreditoDestino_NombreCol] <= 0)
                                    continue;

                                montoPorImpuesto = new System.Collections.Hashtable();

                                dtCtactePersonas = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.Id_NombreCol + " = " + (decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.CtaCtePersonaOrigenId_NombreCol], string.Empty, sesion);
                                dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable((decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.CtaCtePersonaOrigenId_NombreCol], sesion);

                                for (int j = 0; j < dtCtactePersonaDet.Rows.Count; j++)
                                {
                                    decimal montoAux = (decimal)dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol] / (decimal)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol] * (decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.MontoCreditoOrigen_NombreCol];

                                    if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                                        montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + montoAux;
                                    else
                                        montoPorImpuesto.Add(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], montoAux);
                                }

                                impuestoId = new decimal[montoPorImpuesto.Count];
                                monto = new decimal[montoPorImpuesto.Count];

                                indiceAux = 0;
                                montoVerificacion = 0;
                                foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                                {
                                    impuestoId[indiceAux] = (decimal)par.Key;
                                    monto[indiceAux] = (decimal)par.Value;

                                    montoVerificacion += (decimal)par.Value;

                                    indiceAux++;
                                }

                                //Se comparan el saldo contra la suma de movimientos, redondeando a 4 decimales
                                if (Math.Round((decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.MontoCreditoOrigen_NombreCol], 4) != Math.Round(montoVerificacion, 4))
                                    throw new Exception("Error en TransferenciasCtaCtePersonasService.ProcesarCambioEstado(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total débito en cabecera suma " + cabeceraRow.MONTO_TOTAL_DEBITO + ".");
                               
                                //Ingresar el debito
                                CuentaCorrientePersonasService.AgregarDebito((decimal)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.PersonaId_NombreCol],
                                                            (decimal)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.Id_NombreCol],
                                                            Definiciones.CuentaCorrienteConceptos.DebitoTransferenciaDeCtaCte,
                                                            Definiciones.CuentaCorrienteValores.Efectivo, //Se agrega efectivo por completar el dato simplemente
                                                            cabeceraRow.CASO_ID,
                                                            (decimal)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.MonedaId_NombreCol],
                                                            (decimal)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.CotizacionMoneda_NombreCol],
                                                            impuestoId,
                                                            monto,
                                                            "Debito por Transferencia de CtaCte Caso N°: " + cabeceraRow.CASO_ID,
                                                            cabeceraRow.FECHA,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            sesion);
                            }
                            #endregion Agregar debito a la CtaCte Origen
                        }
                        #endregion Afectar ctacte CREDITO

                        #region Calcular monto por tipo de impuesto DEBITO
                        montoPorImpuesto = new System.Collections.Hashtable();
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            if ((decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.MontoDebitoDestino_NombreCol] <= 0)
                                continue;

                            dtCtactePersonas = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.Id_NombreCol + " = " + (decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.CtaCtePersonaOrigenId_NombreCol], string.Empty, sesion);
                            dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable((decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.CtaCtePersonaOrigenId_NombreCol], sesion);

                            for (int j = 0; j < dtCtactePersonaDet.Rows.Count; j++)
                            {
                                decimal montoAux = (decimal)dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol] / (decimal)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol] * (decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.MontoDebitoDestino_NombreCol];

                                if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                                    montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + montoAux;
                                else
                                    montoPorImpuesto.Add(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], montoAux);
                            }
                        }

                        impuestoId = new decimal[montoPorImpuesto.Count];
                        monto = new decimal[montoPorImpuesto.Count];

                        indiceAux = 0;
                        montoVerificacion = 0;
                        foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                        {
                            impuestoId[indiceAux] = (decimal)par.Key;
                            monto[indiceAux] = (decimal)par.Value;

                            montoVerificacion += (decimal)par.Value;

                            indiceAux++;
                        }

                        if (cabeceraRow.MONTO_TOTAL_DEBITO != montoVerificacion)
                            throw new Exception("Error en TransferenciasCtaCtePersonasService.ProcesarCambioEstado(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total débito en cabecera suma " + cabeceraRow.MONTO_TOTAL_DEBITO + ".");
                        #endregion Calcular monto por tipo de impuesto DEBITO

                        #region Afectar ctacte DEBITO
                        if (exito)
                        {
                            #region Agregar Debito a la CtaCte Destino
                            try
                            {
                                //Ingresar el debito a la persona que recibe
                                decimal ctacteDestinoId = CuentaCorrientePersonasService.AgregarDebito((decimal)cabeceraRow.PERSONA_DESTINO_ID,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.CuentaCorrienteConceptos.DebitoTransferenciaDeCtaCte,
                                                                Definiciones.CuentaCorrienteValores.Efectivo,
                                                                cabeceraRow.CASO_ID,
                                                                cabeceraRow.MONEDA_ID,
                                                                cabeceraRow.COTIZACION,
                                                                impuestoId,
                                                                monto,
                                                                "Drébito por Transferencia de CtaCte Caso N°: " + cabeceraRow.CASO_ID,
                                                                cabeceraRow.FECHA_VENCIMIENTO_DESTINO,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                sesion);
                            }
                            catch (Exception exp)
                            {
                                mensaje = exp.Message.ToString();
                                exito = false;
                            }
                            #endregion Agregar Debito a la CtaCte Destino

                            #region Agregar credito a la CtaCte Origen
                            montoPorImpuesto = new System.Collections.Hashtable();
                            for (int i = 0; i < dtDetalles.Rows.Count; i++)
                            {
                                if ((decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.MontoDebitoDestino_NombreCol] <= 0)
                                    continue;

                                montoPorImpuesto = new System.Collections.Hashtable();

                                dtCtactePersonas = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.Id_NombreCol + " = " + (decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.CtaCtePersonaOrigenId_NombreCol], string.Empty, sesion);
                                dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable((decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.CtaCtePersonaOrigenId_NombreCol], sesion);

                                for (int j = 0; j < dtCtactePersonaDet.Rows.Count; j++)
                                {
                                    decimal montoAux = (decimal)dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol] / (decimal)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol] * (decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.MontoDebitoOrigen_NombreCol];

                                    if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                                        montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + montoAux;
                                    else
                                        montoPorImpuesto.Add(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], montoAux);
                                }

                                impuestoId = new decimal[montoPorImpuesto.Count];
                                monto = new decimal[montoPorImpuesto.Count];

                                indiceAux = 0;
                                montoVerificacion = 0;
                                foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                                {
                                    impuestoId[indiceAux] = (decimal)par.Key;
                                    monto[indiceAux] = (decimal)par.Value;

                                    montoVerificacion += (decimal)par.Value;

                                    indiceAux++;
                                }

                                //Se comparan el saldo contra la suma de movimientos, redondeando a 4 decimales
                                if (Math.Round((decimal)dtDetalles.Rows[i][TransferenciasCtaCtePersonasDetallesService.MontoDebitoOrigen_NombreCol], 4) != Math.Round(montoVerificacion, 4))
                                    throw new Exception("Error en TransferenciasCtaCtePersonasService.ProcesarCambioEstado(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total débito en cabecera suma " + cabeceraRow.MONTO_TOTAL_DEBITO + ".");

                                //Ingresar el credito
                                decimal ctacteDestinoId = CuentaCorrientePersonasService.AgregarCredito((decimal)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.PersonaId_NombreCol],
                                                            (decimal)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.Id_NombreCol],
                                                            Definiciones.CuentaCorrienteConceptos.CreditoTransferenciaDeCtaCte,
                                                            cabeceraRow.CASO_ID,
                                                            (decimal)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.MonedaId_NombreCol],
                                                            (decimal)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.CotizacionMoneda_NombreCol],
                                                            impuestoId,
                                                            monto,
                                                            "Crédito por Transferencia de CtaCte Caso N°: " + cabeceraRow.CASO_ID,
                                                            cabeceraRow.FECHA_VENCIMIENTO_DESTINO,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            1,
                                                            1, 
                                                            sesion);
                            }
                            #endregion Agregar credito a la CtaCte Origen
                        }
                        #endregion Afectar ctacte DEBITO
                    }
                    
                    
                    //Verificar si se cumplen los requisitos
                    if (exito && revisarRequisitos)
                    {
                        exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                    }

                    if (exito)
                    {
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.TRANSFERENCIA_CTACTE_PERSONACollection.Update(cabeceraRow);
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
        public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion) 
        {
            try
            {
                CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                TRANSFERENCIA_CTACTE_PERSONARow cabeceraRow = sesion.Db.TRANSFERENCIA_CTACTE_PERSONACollection.GetByCASO_ID(caso_id)[0];
                TRANSF_CTACTE_PERSONA_DETRow[] detalleRows = sesion.Db.TRANSF_CTACTE_PERSONA_DETCollection.GetByTRANSF_CTACTE_PERSONA_ID(cabeceraRow.ID);
                int flujoId;
                string mensaje, clausulas;
                bool exitoCasoAsociado;

                if (casoRow.ESTADO_ID == Definiciones.EstadosFlujos.Aprobado)
                {
                    for (int i = 0; i < detalleRows.Length; i++)
                    {
                        DataTable dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.Id_NombreCol + " = " + detalleRows[i].CTACTE_PERSONA_ORIG_ID, string.Empty, sesion);

                        //Se obtienen todos los registros relacionados con saldo mayor a 0.01 salvo el que se esta pagando
                        if (!dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol].Equals(DBNull.Value))
                        {
                            clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol] + " and " +
                                        "abs(" + CuentaCorrientePersonasService.Credito_NombreCol + " - " + CuentaCorrientePersonasService.Debito_NombreCol + ") > 0.01 ";
                        }
                        else
                        {
                            if (!dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaCtactePagareId_NombreCol].Equals(DBNull.Value))
                            {
                                clausulas = CuentaCorrientePersonasService.VistaCtactePagareId_NombreCol + " = " + dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaCtactePagareId_NombreCol] + " and " +
                                           "abs(" + CuentaCorrientePersonasService.Credito_NombreCol + " - " + CuentaCorrientePersonasService.Debito_NombreCol + ") > 0.01 ";
                            }
                            else
                            {
                                clausulas = "abs(" + CuentaCorrientePersonasService.Credito_NombreCol + " - " + CuentaCorrientePersonasService.Debito_NombreCol + ") > 0.01 ";
                            }
                        }

                        DataTable dtCtactePersonaTotal = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(clausulas, string.Empty, sesion);

                        if (!dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol].Equals(DBNull.Value))
                        {
                            //Si el saldo redondeado a 2 decimales es cero, se da por finiquitado el documento o valor
                            //y no hay otras cuotas pendientes
                            if (Math.Round((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol] - (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol], 2) == 0
                                && dtCtactePersonaTotal.Rows.Count <= 1)
                            {
                                flujoId = int.Parse(CasosService.GetFlujo((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], sesion).ToString());
                                switch (flujoId)
                                {
                                    #region Flujos de los que se transfirieron credito
                                    case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                                        FacturasClienteService facturaCliente = new FacturasClienteService();
                                        exitoCasoAsociado = facturaCliente.ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                                        if (exitoCasoAsociado)
                                            exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                                        if (exitoCasoAsociado)
                                            facturaCliente.EjecutarAccionesLuegoDeCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, sesion);

                                        if (!exitoCasoAsociado)
                                            throw new Exception("Error en TransferenciasCajasTesoreriaService.EjecutarAccionesLuegoDeCambioEstado(), Facturacion Cliente. " + mensaje + ".");
                                        break;

                                    case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                                        
                                        break;

                                    case Definiciones.FlujosIDs.NOTA_DEBITO_PERSONA:
                                        NotasDebitoPersonaService notaDebitoPersona = new NotasDebitoPersonaService();
                                        exitoCasoAsociado = notaDebitoPersona.ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                                        if (exitoCasoAsociado)
                                            exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                                        if (exitoCasoAsociado)
                                            notaDebitoPersona.EjecutarAccionesLuegoDeCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, sesion);

                                        if (!exitoCasoAsociado)
                                            throw new Exception("Error en TransferenciasCajasTesoreriaService.EjecutarAccionesLuegoDeCambioEstado(), Nota de débito persona. " + mensaje + ".");
                                        break;
                                    case Definiciones.FlujosIDs.CREDITOS:
                                        var credito = CreditosService.GetPorCaso((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], sesion);
                                        credito.IniciarUsingSesion(sesion);
                                        credito.ProcesarCambioEstado(Definiciones.EstadosFlujos.Cerrado, false, new ToolbarFlujoService.ComentarioTransicion { texto = "Transición automática por deuda finiquitada." }, sesion);
                                        credito.FinalizarUsingSesion();
                                        break;
                                    #endregion Flujos de los que se transfirieron credito

                                    #region Flujos de los que se transfirieron debito
                                    case Definiciones.FlujosIDs.ANTICIPO_PERSONA:
                                        exitoCasoAsociado = (new AnticiposPersonaService()).ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                                        if (exitoCasoAsociado)
                                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                                        if (exitoCasoAsociado)
                                            (new AnticiposPersonaService()).EjecutarAccionesLuegoDeCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, sesion);

                                        if (!exitoCasoAsociado)
                                            throw new Exception("Error en TransferenciasCajasTesoreriaService.EjecutarAccionesLuegoDeCambioEstado(), Anticipo Persona. " + mensaje + ".");
                                        break;
                                    case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:
                                        exitoCasoAsociado = (new NotasCreditoPersonaService()).ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                                        if (exitoCasoAsociado)
                                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                                        if (exitoCasoAsociado)
                                            (new NotasCreditoPersonaService()).EjecutarAccionesLuegoDeCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, sesion);

                                        if (!exitoCasoAsociado)
                                            throw new Exception("Error en TransferenciasCajasTesoreriaService.EjecutarAccionesLuegoDeCambioEstado(), NC Persona. " + mensaje + ".");
                                        break;
                                    case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES:
                                        exitoCasoAsociado = new DescuentoDocumentosClienteService().ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                                        if (exitoCasoAsociado)
                                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                                        if (exitoCasoAsociado)
                                            new DescuentoDocumentosClienteService().EjecutarAccionesLuegoDeCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, sesion);

                                        if (!exitoCasoAsociado)
                                            throw new Exception("Error en TransferenciasCajasTesoreriaService.EjecutarAccionesLuegoDeCambioEstado(), Descuento Documento Persona. " + mensaje + ".");
                                        break;
                                    #endregion Flujos de los que se transfirieron debito

                                    default: throw new Exception("Error en TransferenciasCajasTesoreriaService.EjecutarAccionesLuegoDeCambioEstado(), Flujo " + flujoId + " no implementado.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

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

        #region GetTransferenciaDataTable
        /// <summary>
        /// Gets the transferencia data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTransferenciaDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTransferenciaDataTable(clausulas, orden, sesion);
            }
        }
        public static DataTable GetTransferenciaDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.TRANSFERENCIA_CTACTE_PERSONACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetTransferenciaDataTable

        #region GetTransferenciaInfoCompleta
        /// <summary>
        /// Gets the transferencia info completa.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTransferenciaInfoCompleta(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTransferenciaInfoCompleta(where, orden, sesion);
            }
        }

        public static DataTable GetTransferenciaInfoCompleta(string where, string orden, SessionService sesion)
        {
            return sesion.Db.TRANSF_CTACTE_PERS_INFO_COMPLCollection.GetAsDataTable(where, orden);
        }
        #endregion GetTransferenciaInfoCompleta

        #region GetTransferenciaInfoCompletaPorTransferencia
        /// <summary>
        /// Gets the transferencia info completa por transferencia.
        /// </summary>
        /// <param name="transferencia_id">The transferencia_id.</param>
        /// <returns></returns>
        public static DataTable GetTransferenciaInfoCompletaPorTransferencia(decimal transferencia_id)
        {
            string where = TransferenciasCtaCtePersonasService.Id_NombreCol + "=" + transferencia_id;
            return GetTransferenciaInfoCompleta(where, TransferenciasCtaCtePersonasService.Id_NombreCol);
        }
        #endregion GetTransferenciaInfoCompletaPorTransferencia

        #region GetTransferenciaInfoCompletaPorCaso
        /// <summary>
        /// Gets the transferencia info completa por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static DataTable GetTransferenciaInfoCompletaPorCaso(decimal caso_id)
        {
            string where = TransferenciasCtaCtePersonasService.CasoId_NombreCol + "=" + caso_id;
            return GetTransferenciaInfoCompleta(where, TransferenciasCtaCtePersonasService.Id_NombreCol);
        }
        #endregion GetTransferenciaInfoCompletaPorCaso

        #region ActualizarTotal

        /// <summary>
        /// Actualizars the total.
        /// </summary>
        /// <param name="transferencia_id">The transferencia_id.</param>
        /// <param name="total">The total.</param>
        public static void ActualizarTotal(decimal transferencia_id, decimal total_credito, decimal total_debito)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.Db.BeginTransaction();
                TRANSFERENCIA_CTACTE_PERSONARow row = sesion.Db.TRANSFERENCIA_CTACTE_PERSONACollection.GetByPrimaryKey(transferencia_id);
                row.MONTO_TOTAL_CREDITO = total_credito;
                row.MONTO_TOTAL_DEBITO = total_debito;
                sesion.Db.TRANSFERENCIA_CTACTE_PERSONACollection.Update(row);
                sesion.Db.CommitTransaction();
                
            }

        }

        #endregion ActualizarTotal

        #region Guardar
        /// <summary>
         /// Hace un update o insert del registro.
         /// </summary>
         /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
         /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
         /// <param name="caso_id">The caso_id.</param>
         /// <param name="estado_id">The estado_id.</param>
         /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id) {
            using (SessionService sesion = new SessionService())
            {
                TRANSFERENCIA_CTACTE_PERSONARow row = new TRANSFERENCIA_CTACTE_PERSONARow();

                try
                {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(sesion.SucursalActiva_Id.ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.TRANSFERENCIA_CTACTE_PERSONA.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("trans_ctacte_persona_sqc");
                        row.MONTO_TOTAL_CREDITO = 0;
                        row.MONTO_TOTAL_DEBITO = 0;
                        caso_id = row.CASO_ID; 
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.TRANSFERENCIA_CTACTE_PERSONACollection.GetRow(TransferenciasCtaCtePersonasService.Id_NombreCol + " = " + campos[TransferenciasCtaCtePersonasService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.FECHA = (DateTime)campos[TransferenciasCtaCtePersonasService.Fecha_NombreCol];
                    row.FECHA_VENCIMIENTO_DESTINO= (DateTime)campos[TransferenciasCtaCtePersonasService.FechaVencimientoDestino_NombreCol];
                    row.AUTONUMERACION_ID = (decimal)campos[TransferenciasCtaCtePersonasService.AutonumeracionId_NombreCol];
                    row.SUCURSAL_ID = (decimal)campos[TransferenciasCtaCtePersonasService.SucursalId_NombreCol];
                    row.MONEDA_ID = (decimal)campos[TransferenciasCtaCtePersonasService.MonedaId_NombreCol];
                    row.PERSONA_DESTINO_ID = (decimal)campos[TransferenciasCtaCtePersonasService.PersonaDestinoId_NombreCol];
                    row.PERSONA_ORIGEN_ID = (decimal)campos[TransferenciasCtaCtePersonasService.PersonaOrigenId_NombreCol];
                    row.COTIZACION = (decimal)campos[TransferenciasCtaCtePersonasService.Cotizacion_NombreCol];

                    if (campos.Contains(TransferenciasCtaCtePersonasService.Observacion_NombreCol))
                    {
                        row.OBSERVACION = (string)campos[TransferenciasCtaCtePersonasService.Observacion_NombreCol];
                    }

                    if (campos.Contains(TransferenciasCtaCtePersonasService.MontoTotalCredito_NombreCol))
                        row.MONTO_TOTAL_CREDITO = (decimal)campos[TransferenciasCtaCtePersonasService.MontoTotalCredito_NombreCol];

                    if (campos.Contains(TransferenciasCtaCtePersonasService.MontoTotalDebito_NombreCol))
                        row.MONTO_TOTAL_DEBITO = (decimal)campos[TransferenciasCtaCtePersonasService.MontoTotalDebito_NombreCol];

                    if (insertarNuevo) sesion.Db.TRANSFERENCIA_CTACTE_PERSONACollection.Insert(row);
                    else sesion.Db.TRANSFERENCIA_CTACTE_PERSONACollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ORIGEN_ID);
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    return row.ID;
                }
                catch (Exception)
                {
                    //Si el caso fue creado el mismo debe borrarse
                    if (insertarNuevo && row.CASO_ID > 0)
                    {
                        (new CasosService()).Eliminar(row.CASO_ID, sesion);
                        caso_id = Definiciones.Error.Valor.EnteroPositivo;
                        estado_id = string.Empty;
                    }

                    throw;
                }
            }
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
                    TRANSFERENCIA_CTACTE_PERSONARow cabecera = sesion.Db.TRANSFERENCIA_CTACTE_PERSONACollection.GetByCASO_ID(caso_id)[0];

                    if (! caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.TRANSFERENCIA_CTACTE_PERSONACollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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

        #region Accessors
        #region Tablas
        public static string Nombre_Tabla
        {
            get { return "TRANSFERENCIA_CTACTE_PERSONA"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return TRANSFERENCIA_CTACTE_PERSONACollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return TRANSFERENCIA_CTACTE_PERSONACollection.CASO_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return TRANSFERENCIA_CTACTE_PERSONACollection.FECHAColumnName; }
        }
        public static string FechaVencimientoDestino_NombreCol
        {
            get { return TRANSFERENCIA_CTACTE_PERSONACollection.FECHA_VENCIMIENTO_DESTINOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return TRANSFERENCIA_CTACTE_PERSONACollection.IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return TRANSFERENCIA_CTACTE_PERSONACollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return TRANSFERENCIA_CTACTE_PERSONACollection.OBSERVACIONColumnName; }
        }
        public static string PersonaDestinoId_NombreCol
        {
            get { return TRANSFERENCIA_CTACTE_PERSONACollection.PERSONA_DESTINO_IDColumnName; }
        }
        public static string PersonaOrigenId_NombreCol
        {
            get { return TRANSFERENCIA_CTACTE_PERSONACollection.PERSONA_ORIGEN_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return TRANSFERENCIA_CTACTE_PERSONACollection.SUCURSAL_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return TRANSFERENCIA_CTACTE_PERSONACollection.MONEDA_IDColumnName; }
        }
        public static string MontoTotalCredito_NombreCol
        {
            get { return TRANSFERENCIA_CTACTE_PERSONACollection.MONTO_TOTAL_CREDITOColumnName; }
        }
        public static string MontoTotalDebito_NombreCol
        {
            get { return TRANSFERENCIA_CTACTE_PERSONACollection.MONTO_TOTAL_DEBITOColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return TRANSFERENCIA_CTACTE_PERSONACollection.COTIZACIONColumnName; }
        }
        #endregion Tablas
        #region Vistas
        public static string VistaCasoUsuarioCreadorId_NombreCol
        {
            get { return TRANSF_CTACTE_PERS_INFO_COMPLCollection.CASO_USUARIO_CREACION_IDColumnName; }
        }
        public static string VistaCasoUsuarioCreador_NombreCol
        {
            get { return TRANSF_CTACTE_PERS_INFO_COMPLCollection.CASO_USUARIO_CREADORColumnName; }
        }
        public static string VistaCasoEstado_NombreCol
        {
            get { return TRANSF_CTACTE_PERS_INFO_COMPLCollection.CASO_ESTADOColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return TRANSF_CTACTE_PERS_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return TRANSF_CTACTE_PERS_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaPersonaDestinoCodigo_NombreCol
        {
            get { return TRANSF_CTACTE_PERS_INFO_COMPLCollection.PERSONA_DESTINO_CODIGOColumnName; }
        }
        public static string VistaPersonaDestinoNombre_NombreCol
        {
            get { return TRANSF_CTACTE_PERS_INFO_COMPLCollection.PERSONA_DESTINO_NOMBREColumnName; }
        }
        public static string VistaPersonaOrigenCodigo_NombreCol
        {
            get { return TRANSF_CTACTE_PERS_INFO_COMPLCollection.PERSONA_ORIGEN_CODIGOColumnName; }
        }
        public static string VistaPersonaOrigenNombre_NombreCol
        {
            get { return TRANSF_CTACTE_PERS_INFO_COMPLCollection.PERSONA_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return TRANSF_CTACTE_PERS_INFO_COMPLCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return TRANSF_CTACTE_PERS_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaMontoSaldoCredito_NombreCol
        {
            get { return TRANSF_CTACTE_PERS_INFO_COMPLCollection.MONTO_SALDO_CREDITOColumnName; }
        }
        public static string VistaMontoSaldoDebito_NombreCol
        {
            get { return TRANSF_CTACTE_PERS_INFO_COMPLCollection.MONTO_SALDO_DEBITOColumnName; }
        }
        #endregion Vistas

        #endregion Accessors
    }
}
