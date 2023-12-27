#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using System.Collections;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotasDebitoPersona;
using System.Collections.Generic;
using CBA.FlowV2.Services.Common;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class RefinanciacionDeudasService : FlujosServiceBaseWorkaround
    {
        #region Clase Webmethods
        public static class Webmethods
        {
           

          

            #region Clase Refinanciar
            private static class RefinanciarClientes
            {
              
            }
            #endregion Clase Refinanciar

            #region Clase ConsultarNumeroDocumentoExterno
            public static class ConsultarNumeroDocumentoExterno
            {
               
            }
            #endregion ConsultarNumeroDocumentoExterno

            #region Clase ActualizarNumeroDocumentoExterno
            public static class ActualizarNumeroDocumentoExterno
            {
               
            }
            #endregion ActualizarNumeroDocumentoExterno
        }
        #endregion Clase Webmethods

        #region Implementacion de Metodos Heredados
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.REFINANCIACION_DEUDAS;
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

        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            REFINANCIACION_DEUDASRow[] rows;
            rows = sesion.Db.REFINANCIACION_DEUDASCollection.GetByCASO_ID(caso_id);
            if (rows.Length == 1)
                return rows[0].NRO_COMPROBANTE;
            else
                return string.Empty;
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
            mensaje = string.Empty;
            bool exito = false;
            bool revisarRequisitos = false;
            mensaje = "";
            try
            {
                CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                REFINANCIACION_DEUDASRow cabeceraRow = sesion.Db.REFINANCIACION_DEUDASCollection.GetByCASO_ID(caso_id)[0];
                REFINANCIACION_DEUDAS_DOCRow[] detallesRows = sesion.db.REFINANCIACION_DEUDAS_DOCCollection.GetByREFINANCIACION_DEUDAS_ID(cabeceraRow.ID);
               
                // de borrador a anulado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    exito = true;
                    revisarRequisitos = true;

                    #region desbloquear las nuevas cuotas
                    string clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + cabeceraRow.CASO_REFINANCIADO_ID + " and " +
                                       CuentaCorrientePersonasService.Credito_NombreCol + " > " + CuentaCorrientePersonasService.Debito_NombreCol + " and " +
                                       CuentaCorrientePersonasService.Bloqueado_NombreCol + " = '" + Definiciones.SiNo.Si + "'";
                    var dtCuotas = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(clausulas, string.Empty, sesion);

                    for (int i = 0; i < dtCuotas.Rows.Count; i++)
                        CuentaCorrientePersonasService.SetBloqueado((decimal)dtCuotas.Rows[i][CuentaCorrientePersonasService.Id_NombreCol], false, sesion);
                    #endregion desbloquear las nuevas cuotas
                }
                // de borrador a pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    exito = true;
                    revisarRequisitos = true;

                    decimal totalDocumentos, totalNuevasCuotasCapital;
                    string clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + cabeceraRow.CASO_REFINANCIADO_ID + " and " +
                                       CuentaCorrientePersonasService.Credito_NombreCol + " > " + CuentaCorrientePersonasService.Debito_NombreCol;
                    DataTable dtCtactePersonas = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(clausulas, string.Empty);

                    #region Verificar que el monto de las nuevas cuotas de capital es igual a las cuotas refinanciadas
                    totalDocumentos = 0;
                    totalNuevasCuotasCapital = 0;
                    for (int i = 0; i < dtCtactePersonas.Rows.Count; i++)
                        totalDocumentos += (decimal)dtCtactePersonas.Rows[i][CuentaCorrientePersonasService.Credito_NombreCol] - (decimal)dtCtactePersonas.Rows[i][CuentaCorrientePersonasService.Debito_NombreCol];

                    for (int i = 0; i < detallesRows.Length; i++)
                    {
                        if (detallesRows[i].ES_INTERES.Equals(Definiciones.SiNo.No))
                            totalNuevasCuotasCapital += detallesRows[i].IMPORTE;
                    }

                    if (Math.Round(totalDocumentos, MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID)) != Math.Round(totalNuevasCuotasCapital, MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID)))
                        throw new Exception("El monto refinanciado no coincide con el capital de las cuotas.");
                    #endregion Verificar que el monto de las nuevas cuotas de capital es igual a las cuotas refinanciadas

                    if (exito && VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RefinanciacionDeudasValidarNroDocumentoExterno) == Definiciones.SiNo.Si)
                        exito = GetConsultarNumeroDocumentoExterno(cabeceraRow, out mensaje, sesion);
                }
                //de pendiente a borrador
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    exito = true;
                    revisarRequisitos = true;
                }
                // de pendiente a aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    decimal totalDocumentos, totalNuevasCuotasCapital;
                    string clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + cabeceraRow.CASO_REFINANCIADO_ID + " and " +
                                       CuentaCorrientePersonasService.Credito_NombreCol + " > " + CuentaCorrientePersonasService.Debito_NombreCol;
                    DataTable dtCtactePersonas = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(clausulas, string.Empty);

                    #region Verificar que el monto de las nuevas cuotas de capital es igual a las cuotas refinanciadas
                    totalDocumentos = 0;
                    totalNuevasCuotasCapital = 0;
                    for (int i = 0; i < dtCtactePersonas.Rows.Count; i++)
                        totalDocumentos += (decimal)dtCtactePersonas.Rows[i][CuentaCorrientePersonasService.Credito_NombreCol] - (decimal)dtCtactePersonas.Rows[i][CuentaCorrientePersonasService.Debito_NombreCol];

                    for (int i = 0; i < detallesRows.Length; i++)
                    {
                        if(detallesRows[i].ES_INTERES.Equals(Definiciones.SiNo.No))
                            totalNuevasCuotasCapital += detallesRows[i].IMPORTE;
                    }

                    if (Math.Round(totalDocumentos, MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID)) != Math.Round(totalNuevasCuotasCapital, MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID)))
                        throw new Exception("El monto refinanciado no coincide con el capital de las cuotas.");
                    #endregion Verificar que el monto de las nuevas cuotas de capital es igual a las cuotas refinanciadas

                    if (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Length <= 0)
                        cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID);

                    // Saldar Deuda anterior
                    PagarCuotasAnteriores(cabeceraRow.ID, dtCtactePersonas, sesion);
                    
                    CrearNuevasCuotas(cabeceraRow.ID, dtCtactePersonas,sesion);

                    Hashtable personas = new Hashtable();
                    personas.Add(PersonasService.EstadoMorosidadId_NombreCol, cabeceraRow.PERSONAS_ESTADO_MOROSIDAD_ID);
                    PersonasService.ModificarDatosPersona(cabeceraRow.PERSONA_ID, personas);
                    exito = true;
                    revisarRequisitos = true;

                    if (exito && VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RefinanciacionDeudasValidarNroDocumentoExterno) == Definiciones.SiNo.Si)
                        ActualizarNumeroDocumentoExterno(cabeceraRow, out mensaje, sesion);
                }

                //Verificar si se cumplen los requisitos
                if (exito && revisarRequisitos)
                {
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                }

                if (exito)
                {
                    sesion.Db.CASOSCollection.Update(casoRow);
                    sesion.Db.REFINANCIACION_DEUDASCollection.Update(cabeceraRow);
                }
     
                return exito;
            }
            catch (Exception exp)
            {
                exito = false;
                throw exp;
            }
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza acciones necesarias una vez que se efectuo el cambio de estado
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion) { }

        #endregion Implementacion de Metodos Heredados

        #region GetRefinanciacionDeudasDataTable
        public static DataTable GetRefinanciacionDeudasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetRefinanciacionDeudasDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetRefinanciacionDeudasDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.REFINANCIACION_DEUDASCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetRefinanciacionDeudasDataTable

        #region GetExisteNroComprobante
        private static bool GetExisteNroComprobante(decimal refinanciacion_id, decimal autonumeracion_id, string nro_comprobante, SessionService sesion)
        {
            string clausulas = " 1=1 ";

            if (!autonumeracion_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                clausulas += " and " + RefinanciacionDeudasService.AutonumeracionId_NombreCol + " = " + autonumeracion_id;

            clausulas += " and " + RefinanciacionDeudasService.NroComprobante_NombreCol + " = '" + nro_comprobante + "' " +
                         " and " + RefinanciacionDeudasService.Id_NombreCol + " <> " + refinanciacion_id;

            REFINANCIACION_DEUDASRow[] rows = sesion.Db.REFINANCIACION_DEUDASCollection.GetAsArray(clausulas, string.Empty);

            return rows.Length > 0;
        }
        #endregion GetExisteNroComprobante

        #region Generar Nro. de Comprobante
        public static string GenerarNumeroComprobante(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                REFINANCIACION_DEUDASRow cabeceraRow = sesion.Db.REFINANCIACION_DEUDASCollection.GetByCASO_ID(caso_id)[0];
                string nroComprobante = string.Empty;
                decimal numeroActual = Definiciones.IdNull;

                if (cabeceraRow.IsAUTONUMERACION_IDNull)
                    throw new Exception("Debe indicarse el talonario o un número de comprobante manual.");

                //Si no existe un nro. de comprobante se crea.
                if (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Length <= 0)
                {
                    nroComprobante = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, out numeroActual, sesion);

                    if (GetExisteNroComprobante(cabeceraRow.ID, cabeceraRow.AUTONUMERACION_ID, nroComprobante, sesion))
                    {
                        throw new Exception("Ya existe una factura con el mismo número de comprobante.");
                    }
                }

                //Controlar que se logro asignar una numeracion
                if (nroComprobante.Equals(""))
                {
                    throw new Exception("No se pudo asignar una numeración válida");
                }

                return nroComprobante;
            }
        }

        #endregion Generar Nro. de Comprobante

        #region ConfirmarRefinanciacion
        private static void CrearNuevasCuotas(decimal refinanciacion_deudas_id,DataTable dt_cta_cte_personas, SessionService sesion)
        {
            try
            {
                REFINANCIACION_DEUDASRow cabeceraRow = sesion.db.REFINANCIACION_DEUDASCollection.GetByPrimaryKey(refinanciacion_deudas_id);
                REFINANCIACION_DEUDAS_DOCRow[] detalleRow = sesion.Db.REFINANCIACION_DEUDAS_DOCCollection.GetAsArray(RefinanciacionDeudasDetalleService.RefinancionDeudasId_NombreCol + "=" + refinanciacion_deudas_id, RefinanciacionDeudasDetalleService.Vencimiento_NombreCol);

                //Se obtienen los datos del flujo refinanciado
                decimal casoFlujoBase = cabeceraRow.CASO_REFINANCIADO_ID;
                int flujoId = int.Parse(CasosService.GetFlujo(casoFlujoBase, sesion).ToString());
                REFINANCIACION_DEUDASRow[] cabeceraRowAux;
                int j = 0;
                //Se iteran hasta encontrar el caso base que dio origen a la refinanciacion
                while (flujoId.Equals(Definiciones.FlujosIDs.REFINANCIACION_DEUDAS))
                {
                    cabeceraRowAux=sesion.db.REFINANCIACION_DEUDASCollection.GetByCASO_ID(casoFlujoBase);
                    if (cabeceraRowAux.Length == 1)
                    {
                        casoFlujoBase = cabeceraRowAux[0].CASO_REFINANCIADO_ID;
                        flujoId = int.Parse(CasosService.GetFlujo(casoFlujoBase, sesion).ToString());
                    }
                    else {
                        throw new Exception("Error al obtener los datos del caso Base");
                    }
                    j++;
                    //control de proteccíon de bucle infinito, no deberia ocurrir ya que todos los casos de refinanciacòn deberìan tener un caso
                    // base que le da origen, pero de se coloca un numero arbitrario de 100 veces que puede buscar recursivamente el caso base.
                    if (j > 99)
                    {
                        throw new Exception("Error al obtener los datos del caso Base");
                    }
                }

                DateTime maximoVencimiento = DateTime.MinValue;
                decimal cuotaNuevaId= Definiciones.Error.Valor.EnteroPositivo;

                for (int i = 0; i < detalleRow.Length; i++)
                {
                    if (detalleRow[i].ES_INTERES.Equals(Definiciones.SiNo.No))
                    {
                        switch (flujoId)
                        {
                            case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                                #region agregar cuota a calendario
                                Hashtable campos = new Hashtable();
                                DataTable dtFactura = FacturasClienteService.GetFacturaClienteDataTable(FacturasClienteService.CasoId_NombreCol + " = " + casoFlujoBase, string.Empty);
                                campos.Add(CalendarioPagosFCClienteService.FacturaClienteId_NombreCol, (decimal)dtFactura.Rows[0][FacturasClienteService.Id_NombreCol]);
                                campos.Add(CalendarioPagosFCClienteService.MontoCapital_NombreCol, detalleRow[i].IMPORTE);
                                campos.Add(CalendarioPagosFCClienteService.MontoInteres_NombreCol, (decimal)0);
                                campos.Add(CalendarioPagosFCClienteService.NumeroCuota_NombreCol, detalleRow[i].CUOTA);
                                campos.Add(CalendarioPagosFCClienteService.FechaVencimiento_NombreCol, detalleRow[i].VENCIMIENTO);

                                cuotaNuevaId = CalendarioPagosFCClienteService.Guardar(campos, sesion);
                                #endregion agregar cuota a calendario

                                // se actualiza el vencimiento de la factura
                                FacturasClienteService.ActualizarFechaVencimiento((decimal)dtFactura.Rows[0][FacturasClienteService.Id_NombreCol], maximoVencimiento, false, false, sesion);
                                break;
                            case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                                break;
                            case Definiciones.FlujosIDs.CREDITOS:
                                break;
                            default:
                                break;
                        }
                       

                        #region Agregar la cuota a la cuenta corriente
                        CuentaCorrientePersonasService.AgregarCredito((decimal)cabeceraRow.PERSONA_ID,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                            cabeceraRow.CASO_ID,
                                                            detalleRow[i].MONEDA_ID,
                                                            detalleRow[i].COTIZACION,
                                                            new decimal[] { Definiciones.Impuestos.IVA_10 }, //Se pierde la distribucion real de impuestos
                                                            new decimal[] { detalleRow[i].IMPORTE },
                                                            string.Empty,
                                                            detalleRow[i].VENCIMIENTO,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            cuotaNuevaId,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            detalleRow[i].CUOTA,
                                                            detalleRow.Length,
                                                            sesion);
                        #endregion Agregar la cuota a la cuenta corriente
                    }
                }


                
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion ConfirmarRefinanciacion

        #region PagarCuotasAnteriores
        private static void PagarCuotasAnteriores(decimal refinanciacion_deuda_id, DataTable dt_ctacte_personas, SessionService sesion)
        {
            decimal saldo, proporcion;

            DataTable dtCtactePersonaDet;
            Hashtable montoPorImpuesto;
            decimal[] impuestoId, monto;
            int indiceAux;
            decimal montoVerificacion;

            //Obtenemos la cabecera del caso
            REFINANCIACION_DEUDASRow cabeceraRow = sesion.db.REFINANCIACION_DEUDASCollection.GetByPrimaryKey(refinanciacion_deuda_id);

            //Ingresar el pago de cada cuota
            for (int i = 0; i < dt_ctacte_personas.Rows.Count; i++)
            {

                //Se obtienen los datos del flujo refinanciado
                decimal casoFlujoBase = cabeceraRow.CASO_REFINANCIADO_ID;
                int flujoId = int.Parse(CasosService.GetFlujo(casoFlujoBase, sesion).ToString());
                REFINANCIACION_DEUDASRow[] cabeceraRowAux;
                int m = 0;
                //Se iteran hasta encontrar el caso base que dio origen a la refinanciacion
                while (flujoId.Equals(Definiciones.FlujosIDs.REFINANCIACION_DEUDAS))
                {
                    cabeceraRowAux = sesion.db.REFINANCIACION_DEUDASCollection.GetByCASO_ID(casoFlujoBase);
                    if (cabeceraRowAux.Length == 1)
                    {
                        casoFlujoBase = cabeceraRowAux[0].CASO_REFINANCIADO_ID;
                        flujoId = int.Parse(CasosService.GetFlujo(casoFlujoBase, sesion).ToString());
                    }
                    else
                    {
                        throw new Exception("Error al obtener los datos del caso Base");
                    }
                    m++;
                    //control de proteccíon de bucle infinito, no deberia ocurrir ya que todos los casos de refinanciacòn deberìan tener un caso
                    // base que le da origen, pero de se coloca un numero arbitrario de 100 veces que puede buscar recursivamente el caso base.
                    if (m > 99)
                    {
                        throw new Exception("Error al obtener los datos del caso Base");
                    }
                }

                switch (flujoId)
                {
                    case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                        //Inactivar cuotas en el calendario de pago
                        CalendarioPagosFCClienteService.SetEstado((decimal)dt_ctacte_personas.Rows[i][CuentaCorrientePersonasService.CalendarioPagoFcCliId_NombreCol], Definiciones.Estado.Inactivo, sesion);
                        break;

                    case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:

                        break;

                    case Definiciones.FlujosIDs.CREDITOS:

                        break;

                    default:

                        break;
                }
   
                
                //Saldo antes del pago actual
                saldo = (decimal)dt_ctacte_personas.Rows[i][CuentaCorrientePersonasService.Credito_NombreCol] -
                        (decimal)dt_ctacte_personas.Rows[i][CuentaCorrientePersonasService.Debito_NombreCol];

                proporcion = saldo / (decimal)dt_ctacte_personas.Rows[i][CuentaCorrientePersonasService.Credito_NombreCol];

                #region Calcular monto por tipo de impuesto
                montoPorImpuesto = new System.Collections.Hashtable();
                dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable((decimal)dt_ctacte_personas.Rows[i][CuentaCorrientePersonasService.Id_NombreCol], sesion);

                for (int j = 0; j < dtCtactePersonaDet.Rows.Count; j++)
                {
                    if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                        montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + (decimal)dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol] * proporcion;
                    else
                        montoPorImpuesto.Add(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], (decimal)dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol] * proporcion);
                }

                impuestoId = new decimal[montoPorImpuesto.Count];
                monto = new decimal[montoPorImpuesto.Count];

                indiceAux = 0;
                montoVerificacion = 0;
                foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                {
                    impuestoId[indiceAux] = (decimal)par.Key;
                    monto[indiceAux] = (decimal)par.Value;

                    montoVerificacion += monto[indiceAux];

                    indiceAux++;
                }

                if (Math.Round(saldo, int.Parse(dt_ctacte_personas.Rows[i][CuentaCorrientePersonasService.VistaMonedaCantidadDecimales_NombreCol].ToString())) != Math.Round(montoVerificacion, int.Parse(dt_ctacte_personas.Rows[i][CuentaCorrientePersonasService.VistaMonedaCantidadDecimales_NombreCol].ToString())))
                    throw new Exception("Error en RefinanciacionDeudasService.ConfirmarDocumentos(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el saldo es de " + saldo + ".");
                #endregion Calcular monto por tipo de impuesto

                //Ingresar el debito
                CuentaCorrientePersonasService.AgregarDebito(cabeceraRow.PERSONA_ID,
                                            (decimal)dt_ctacte_personas.Rows[i][CuentaCorrientePersonasService.Id_NombreCol],
                                            Definiciones.CuentaCorrienteConceptos.DebitoPorPago,
                                            Definiciones.CuentaCorrienteValores.Efectivo, //Se agrega efectivo por completar el dato simplemente
                                            cabeceraRow.CASO_ID,
                                            (decimal)dt_ctacte_personas.Rows[i][CuentaCorrientePersonasService.MonedaId_NombreCol],
                                            (decimal)dt_ctacte_personas.Rows[i][CuentaCorrientePersonasService.CotizacionMoneda_NombreCol],
                                            impuestoId,
                                            monto,
                                            string.Empty,
                                            cabeceraRow.FECHA,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            sesion);

                //Se desbloquea la cuota pagada
                CuentaCorrientePersonasService.SetBloqueado((decimal)dt_ctacte_personas.Rows[i][CuentaCorrientePersonasService.Id_NombreCol], false, sesion);
            }
        }
        #endregion PagarCuotasAnteriores

        #region GetCuotasPagadas
        public static DataTable GetCuotasPagadas(decimal caso_id)
        {
            DataTable dt= new DataTable();
            using (SessionService sesion = new SessionService())
            {
                string  query = "select (cp2."+CuentaCorrientePersonasService.Credito_NombreCol+" - cp2."+CuentaCorrientePersonasService.Debito_NombreCol +"+ cp1."+CuentaCorrientePersonasService.Debito_NombreCol+") as SALDO_DEBITO,";
                        query+="cp2."+CuentaCorrientePersonasService.VistaCuota_NombreCol+",";
                        query+="cp2."+CuentaCorrientePersonasService.FechaVencimiento_NombreCol+",";
                        query+="cp2."+CuentaCorrientePersonasService.VistaMonedaSimbolo_NombreCol+",";
                        query+="cp2."+CuentaCorrientePersonasService.VistaMonedaCadenaDecimales_NombreCol;
                        query+=" from " +CuentaCorrientePersonasService.Nombre_Tabla +" cp1, "+CuentaCorrientePersonasService.Nombre_Vista+" cp2 ";
                        query+=" where cp1." +CuentaCorrientePersonasService.CasoId_NombreCol+" = "+caso_id;
                        query += " and cp2." + CuentaCorrientePersonasService.Id_NombreCol + " = cp1." + CuentaCorrientePersonasService.CtactePersonaRelacionada_NombreCol;
                        query += " and cp1." + CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                        query += " and cp2." + CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                        dt = sesion.db.EjecutarQuery(query);
                        return dt;
 
            }
        }
        #endregion GetCuotasPagadas

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                REFINANCIACION_DEUDASRow row = new REFINANCIACION_DEUDASRow();
                try
                {
                    string valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("REFINANCIACION_DEUDAS_SQC");
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[SucursalId_NombreCol].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.REFINANCIACION_DEUDAS.ToString()),
                                                             int.Parse(sesion.Usuario_Id.ToString()),
                                                             SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                        row.FECHA = DateTime.Now;
                    }
                    else
                    {
                        row = sesion.Db.REFINANCIACION_DEUDASCollection.GetByPrimaryKey((decimal)campos[RefinanciacionDeudasService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    if (campos.Contains(RefinanciacionDeudasService.PersonaEstadoMorosidadId_NombreCol))
                        row.PERSONAS_ESTADO_MOROSIDAD_ID = (decimal)campos[RefinanciacionDeudasService.PersonaEstadoMorosidadId_NombreCol];
                    if (campos.Contains(RefinanciacionDeudasService.EsRecalendarizacion_NombreCol))
                        row.ES_RECALENDARIZACION = (string)campos[RefinanciacionDeudasService.EsRecalendarizacion_NombreCol];
                    if (campos.Contains(RefinanciacionDeudasService.FechaPrimerVenciemiento_NombreCol))
                        row.FECHA_PRIMER_VENCIMIENTO = (DateTime)campos[RefinanciacionDeudasService.FechaPrimerVenciemiento_NombreCol];

                    if (row.FECHA_PRIMER_VENCIMIENTO.Date < row.FECHA.Date)
                        throw new Exception("La primera fecha de vencimiento es inválida.");

                    row.PERSONA_ID = (decimal)campos[RefinanciacionDeudasService.PersonaId_NombreCol];
                    row.SUCURSAL_ID = (decimal)campos[RefinanciacionDeudasService.SucursalId_NombreCol];

                    if (row.CASO_REFINANCIADO_ID.Equals(DBNull.Value) || !row.CASO_REFINANCIADO_ID.Equals((decimal)campos[RefinanciacionDeudasService.CasoRefinanciadoId_NombreCol]))
                    {
                        string clausulas;
                        DataTable dtCuotas;

                        if (!row.CASO_REFINANCIADO_ID.Equals(DBNull.Value) && row.CASO_REFINANCIADO_ID != 0)
                        {
                            #region desbloquear las cuotas del caso anterior
                            clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + row.CASO_REFINANCIADO_ID + " and " +
                                        CuentaCorrientePersonasService.Credito_NombreCol + " > " + CuentaCorrientePersonasService.Debito_NombreCol;
                            dtCuotas = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(clausulas, string.Empty, sesion);

                            for (int i = 0; i < dtCuotas.Rows.Count; i++)
                                CuentaCorrientePersonasService.SetBloqueado((decimal)dtCuotas.Rows[i][CuentaCorrientePersonasService.Id_NombreCol], false, sesion);
                            #endregion desbloquear las cuotas del caso anterior
                        }

                        row.CASO_REFINANCIADO_ID = (decimal)campos[RefinanciacionDeudasService.CasoRefinanciadoId_NombreCol];

                        #region bloquear las nuevas cuotas
                        clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + row.CASO_REFINANCIADO_ID + " and " +
                                    CuentaCorrientePersonasService.Credito_NombreCol + " > " + CuentaCorrientePersonasService.Debito_NombreCol;
                        dtCuotas = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(clausulas, string.Empty, sesion);
                        
                        for (int i = 0; i < dtCuotas.Rows.Count; i++)
                        {
                            //Si la cuota ya estaba bloqueada no se puede crear la refinanciación
                            if ((string)dtCuotas.Rows[i][CuentaCorrientePersonasService.Bloqueado_NombreCol] == Definiciones.SiNo.Si)
                                throw new Exception("La cuota " + dtCuotas.Rows[i][CuentaCorrientePersonasService.CuotaNumero_NombreCol] + " se encuentra bloqueada.");

                            CuentaCorrientePersonasService.SetBloqueado((decimal)dtCuotas.Rows[i][CuentaCorrientePersonasService.Id_NombreCol], true, sesion);
                        }
                        #endregion bloquear las nuevas cuotas
                    }

                    if (row.MONEDA_ID.Equals(DBNull.Value) || row.MONEDA_ID != (decimal)campos[RefinanciacionDeudasService.MonedaId_NombreCol])
                    {
                        if (!MonedasService.EstaActivo((decimal)campos[RefinanciacionDeudasService.MonedaId_NombreCol]))
                            throw new Exception("La moneda no está activa");

                        row.MONEDA_ID = (decimal)campos[RefinanciacionDeudasService.MonedaId_NombreCol];

                        //Se actualiza la cotizacion de la moneda
                        row.COTIZACION = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, row.FECHA, sesion);
                        if (row.COTIZACION.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("Debe actualizarse la cotización de la moneda.");
                    }

                    if (campos.Contains(RefinanciacionDeudasService.AutonumeracionId_NombreCol))
                        row.AUTONUMERACION_ID = (decimal)campos[RefinanciacionDeudasService.AutonumeracionId_NombreCol];
                    else
                        row.IsAUTONUMERACION_IDNull = true;

                    if (campos.Contains(RefinanciacionDeudasService.NroComprobante_NombreCol))
                        row.NRO_COMPROBANTE = (string)campos[RefinanciacionDeudasService.NroComprobante_NombreCol];

                    if (campos.Contains(RefinanciacionDeudasService.NroComprobanteExterno_NombreCol))
                        row.NRO_COMPROBANTE_EXTERNO = (string)campos[RefinanciacionDeudasService.NroComprobanteExterno_NombreCol];
                    else
                        row.NRO_COMPROBANTE_EXTERNO = string.Empty;

                    if (campos.Contains(RefinanciacionDeudasService.EntregaInicial_NombreCol))
                        row.ENTREGA_INICIAL = (decimal)campos[EntregaInicial_NombreCol];
                    else
                        row.IsENTREGA_INICIALNull = true;

                    if (campos.Contains(RefinanciacionDeudasService.MontoCuota_NombreCol))
                    {
                        row.MONTO_CUOTA_PROPUESTO = (decimal)campos[RefinanciacionDeudasService.MontoCuota_NombreCol];
                        if (row.ES_RECALENDARIZACION == Definiciones.SiNo.No && row.MONTO_CUOTA_PROPUESTO <= 0)
                            throw new Exception("El monto de cuota propuesto debe ser mayor a cero.");
                    }
                    else
                    {
                        row.IsMONTO_CUOTA_PROPUESTONull = true;
                    }

                    if (insertarNuevo) sesion.Db.REFINANCIACION_DEUDASCollection.Insert(row);
                    else sesion.Db.REFINANCIACION_DEUDASCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.NroComprobante2_NombreCol, row.NRO_COMPROBANTE_EXTERNO);
                    camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    return row.ID;
                }
                catch (Exception)
                {
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

        #region ActualizarNumeroDocumentoExterno
        public static void ActualizarNumeroDocumentoExterno(REFINANCIACION_DEUDASRow refinanciacion, out string mensaje, SessionService sesion)
        {
            try
            {
                mensaje = string.Empty;

               
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion ActualizarNumeroDocumentoExterno

        #region GetConsultarNumeroDocumentoExterno
        /// <summary>
        /// Gets the consultar numero documento externo.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <param name="mensaje">The mensaje.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static bool GetConsultarNumeroDocumentoExterno(REFINANCIACION_DEUDASRow refinanciacion, out string mensaje, SessionService sesion)
        {
            try
            {
                bool exito = true;
                mensaje = string.Empty;

               

                return exito;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion GetConsultarNumeroDocumentoExterno
        
        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "REFINANCIACION_DEUDAS"; }
        }
        public static string Id_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.IDColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.PERSONA_IDColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.CASO_IDColumnName; }
        }
        public static string CasoRefinanciadoId_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.CASO_REFINANCIADO_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.COTIZACIONColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.FECHAColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.MONEDA_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string NroComprobanteExterno_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.NRO_COMPROBANTE_EXTERNOColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.SUCURSAL_IDColumnName; }
        }
        public static string MontoCuota_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.MONTO_CUOTA_PROPUESTOColumnName; }
        }
        public static string EntregaInicial_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.ENTREGA_INICIALColumnName; }
        }
        public static string PersonaEstadoMorosidadId_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.PERSONAS_ESTADO_MOROSIDAD_IDColumnName; }
        }
        public static string EsRecalendarizacion_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.ES_RECALENDARIZACIONColumnName; }
        }
        public static string FechaPrimerVenciemiento_NombreCol
        {
            get { return REFINANCIACION_DEUDASCollection.FECHA_PRIMER_VENCIMIENTOColumnName; }
        }
        #endregion Tabla

        #region Vista

        public static string Nombre_Vista
        {
            get { return "REFI_DEUDAS_INFO_COMP"; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return REFI_DEUDAS_INFO_COMPCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaMonedaCadenaDecimales_NombreCol
        {
            get { return REFI_DEUDAS_INFO_COMPCollection.MONEDA_CADENA_DECIMALESColumnName; }
        }
        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return REFI_DEUDAS_INFO_COMPCollection.MONEDA_CANTIDAD_DECIMALESColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return REFI_DEUDAS_INFO_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return REFI_DEUDAS_INFO_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaPersonaCodigo_NombreCol
        {
            get { return REFI_DEUDAS_INFO_COMPCollection.PERSONA_CODIGOColumnName; }
        }
        public static string VistaPersonaNombreCompleto_NombreCol
        {
            get { return REFI_DEUDAS_INFO_COMPCollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return REFI_DEUDAS_INFO_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return REFI_DEUDAS_INFO_COMPCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaEstadoMorosidad_NombreCol
        {
            get { return REFI_DEUDAS_INFO_COMPCollection.ESTADO_MOROSIDADColumnName; }
        }
        
        #endregion Vista
        #endregion Accessors
    }
}