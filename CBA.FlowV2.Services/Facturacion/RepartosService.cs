#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.NotasDebitoPersona;
using System.Collections;
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class RepartosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.REPARTO;
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

            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, drCabecera[RepartosService.DepositoId_NombreCol]);
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
                FacturasClienteService facturas = new FacturasClienteService();
                bool exito = false;
                bool revisarRequisitos = false;
                mensaje = "";
                try
                {
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    REPARTOSRow cabeceraRow = sesion.Db.REPARTOSCollection.GetByCASO_ID(caso_id)[0];
                    REPARTOS_DETALLERow[] detalleRows = sesion.Db.REPARTOS_DETALLECollection.GetByREPARTO_ID(cabeceraRow.ID);
                    FacturasClienteService factura = new FacturasClienteService();

                    #region Borrador a Anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Se cambia el estado del las FC relacionadas a "Para-Reparto", dejando
                        //el detalle a modo informativo.
                        exito = true;
                        revisarRequisitos = true;
                        CambioEstadoCasoService cambioEstado = new CambioEstadoCasoService();
                        int flujoId=0;
                        foreach (REPARTOS_DETALLERow detalle in detalleRows)
                        {
                            try
                            {

                                flujoId = int.Parse(CasosService.GetFlujo(detalle.CASO_ID, sesion).ToString());

                                    switch (flujoId)
                                    {
                                        case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                                            //Cambiar el caso de FC al estado ParaReparto
                                            exito = factura.ProcesarCambioEstado(detalle.CASO_ID, Definiciones.EstadosFlujos.ParaReparto, false, out mensaje,sesion);
                                            if (exito)
                                                exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(detalle.CASO_ID, Definiciones.EstadosFlujos.ParaReparto, "Transición automática por paso del Reparto Nro. " + cabeceraRow.CASO_ID + " al estado Anulado.",sesion);
                                            if (exito)
                                                factura.EjecutarAccionesLuegoDeCambioEstado(detalle.CASO_ID, Definiciones.EstadosFlujos.ParaReparto, sesion);
                                        break;

                                       

                                        case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:

                                        break;
                                        default: throw new System.ArgumentException("Error Repartos Service, situacion para flujo no implementado");
                                    }
                                    
                                
                            }
                            catch (Exception exp)
                            {
                                exito = false;
                                mensaje = exp.Message;
                            }
                           
                            if (!exito) break;
                        }
                    }   
                    #endregion Borrador a Anulado

                    #region Borrador a Pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //Se genera la numeracion del Reparto a partir de la autonumeracion que haya indicado el usuario, si el 
                        //caso no tenia previamente un numero asignado (i.e. realizo la transicion anteriormete). 

                        exito = true;
                        revisarRequisitos = true;

                        if (cabeceraRow.NRO_COMPROBANTE == null)
                        {
                            try
                            {
                                cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, sesion);

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
                    #endregion Borrador a Pendiente

                    #region Pendiente a Borrador 
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                    }
                    #endregion Pendiente a Borrador

                    #region Pendiente a Viajando
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Viajando))
                    {
                        //Acciones:
                        //Controlar que se completaron la fecha de salida y el km del camion
                        //y que todas las FC incluidas tengan número de comprobante
                        exito = true;
                        revisarRequisitos = true;
                        mensaje = "Errores encontrados:\n";

                        if (cabeceraRow.IsFECHA_SALIDANull)
                        {
                            exito = false;
                            mensaje = mensaje + "Debe indicar la fecha y hora en que el camión sale de reparto...\n";
                        }

                        if (cabeceraRow.IsKILOMETRAJE_SALIDANull)
                        {
                            exito = false;
                            mensaje = mensaje + "Debe indicar el kilometraje del camión al salir de reparto...\n";
                        }

                        //Si algunas de las facturas de cliente no posee número de comprobante asignado no se puede avanzar al estado viajando.
                        
                         exito = true;
                        revisarRequisitos = true;
                        CambioEstadoCasoService cambioEstado = new CambioEstadoCasoService();
                        int flujoId=0;
                        foreach (REPARTOS_DETALLERow detalle in detalleRows)
                        {
                            try
                            {

                                flujoId = int.Parse(CasosService.GetFlujo(detalle.CASO_ID, sesion).ToString());
                                string casoEstado = CasosService.GetEstadoCaso(detalle.CASO_ID, sesion);
                                    switch (flujoId)
                                    {
                                        case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                                            //Cambiar el caso de FC al estado ParaReparto
                                            if (factura.GetNumeroComprobante(detalle.CASO_ID, sesion) == string.Empty)
                                            {
                                                exito = false;
                                                mensaje = mensaje + "La factura correspondiente al caso " + detalle.CASO_ID.ToString() + " no tiene nro. de comprobante asignado...\n";
                                            }
                                        break;
                                        case Definiciones.FlujosIDs.TRANSFERENCIA_DE_ARTICULOS:
                                       
                                        if (casoEstado.Equals(Definiciones.EstadosFlujos.Aprobado))
                                        {
                                            exito = (new StockTransferenciasService()).ProcesarCambioEstado(detalle.CASO_ID, Definiciones.EstadosFlujos.Viajando, false, out mensaje, sesion);
                                            if (exito)
                                                exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(detalle.CASO_ID, Definiciones.EstadosFlujos.Viajando, "Transición por inclusion en caso de Reparto Nro: " + cabeceraRow.CASO_ID, sesion);
                                            if (exito)
                                                (new StockTransferenciasService()).EjecutarAccionesLuegoDeCambioEstado(detalle.CASO_ID, Definiciones.EstadosFlujos.Viajando, sesion);
                                        }
                                        break;
                                       

                                        case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:

                                        break;
                                        default: throw new System.ArgumentException("Error Repartos Service, situacion para flujo no implementado");
                                    }
                                    
                                
                            }
                            catch (Exception exp)
                            {
                                exito = false;
                                mensaje = exp.Message;
                            }
                           
                            if (!exito) break;
                        }
                                     
                            
                    }
                    #endregion Pendiente a Viajando

                    #region Viajando a Rendicion
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Viajando) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Rendicion))
                    {
                        //Acciones
                        //ninguna
                        exito = true;
                        revisarRequisitos = true;
                    }
                    #endregion Viajando a Rendicion

                    #region Rendicion a Cerrado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Rendicion) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //Se controla que hayan sido ingresados los datos de hora y kilometraje del camion a su regreso
                        //Se controla que todos los detalles hayan sido marcados como entrega exitosa o no exitosa
                        //Actualizar el kilometraje del vehiculo
                        //Los casos de FC marcados como exitosamente entregadas son pasadas al estado “Caja”. En cambio, 
                        //los casos de FC con problema son devueltos al estado “Para Reparto” y podrán ser incluidos en un futuro caso de Reparto.
                        exito = true;
                        revisarRequisitos = true;
                        if(VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.UtilizarCajaEnReparto).Equals(Definiciones.SiNo.Si))
                        {
                            if (cabeceraRow.IsCTACTE_CAJA_SUC_IDNull)
                            {
                                exito = false;
                                mensaje = "Debe indicar la caja de para registrar los documentos a utilizar";
                            }
                        }
                        

                        if (cabeceraRow.IsFECHA_REGRESONull)
                        {
                            exito = false;
                            mensaje = "Debe indicar la fecha y hora en que el camión regresó del reparto.";
                        }
                        else 
                        {
                            if (cabeceraRow.FECHA_REGRESO < cabeceraRow.FECHA_SALIDA) 
                            {
                                exito = false;
                                mensaje = "La fecha de regreso del camión debe ser posterior a la de salida.";
                            }
                        }

                        if (cabeceraRow.IsKILOMETRAJE_REGRESONull)
                        {
                            exito = false;
                            mensaje = "Debe indicar el kilometraje con que el camión regresó luego del reparto.";
                        }
                        else
                        {
                            if (cabeceraRow.KILOMETRAJE_REGRESO < cabeceraRow.KILOMETRAJE_SALIDA)
                            {
                                exito = false;
                                mensaje = "El kilometraje al regreso del camión debe ser mayor al de salida.";
                            }
                        }

                        if(exito)
                        {
                            foreach (REPARTOS_DETALLERow d in detalleRows) 
                            {
                                if (!(d.ENTREGA_EXITOSA == Definiciones.SiNo.Si || d.ENTREGA_EXITOSA == Definiciones.SiNo.No))
                                {
                                    exito = false;
                                    mensaje = "Todos los Casos que componen el detalle deben marcarse como entregados o no exitosamente.";
                                    break;
                                }
                            }
                        }

                        if (exito)
                        {
                            CambioEstadoCasoService cambioEstado = new CambioEstadoCasoService();
                            CuentaCorrientePersonasService ctactePersona = new CuentaCorrientePersonasService();
                            CalendarioPagosFCClienteService pagos = new CalendarioPagosFCClienteService();
                            NotasDebitoPersonaService notaDebito = new NotasDebitoPersonaService();
                            NotasCreditoPersonaService notaCredito = new NotasCreditoPersonaService();
                            DataTable dtFactura = new DataTable();
                            DataTable dtPagos = new DataTable();


                            //Actualizar el kilometraje del vehiculo
                            VehiculosService.SetKilometrajeActual(cabeceraRow.VEHICULO_ID, cabeceraRow.KILOMETRAJE_REGRESO, sesion);

                            foreach (REPARTOS_DETALLERow detalle in detalleRows)
                            {
                                try 
                                {
                                    int flujoId = 0;
                                    flujoId = int.Parse(CasosService.GetFlujo(detalle.CASO_ID, sesion).ToString());
                                    string casoEstado = CasosService.GetEstadoCaso(detalle.CASO_ID, sesion);

                                    if (detalle.ENTREGA_EXITOSA.Equals(Definiciones.SiNo.Si))
                                    {


                                        switch (flujoId)
                                        {
                                            case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                                                //Cambiar el caso de FC al estado Caja SOLO SI ES UN CASO DE FACTURA, en otros flujos no hay cambio de estado automatico

                                                if (CasosService.GetEstadoCaso(detalle.CASO_ID,sesion).Equals(Definiciones.EstadosFlujos.EnReparto))
                                                {
                                                    FacturasClienteService.SetCajaSucursal(detalle.CASO_ID, cabeceraRow.CTACTE_CAJA_SUC_ID, sesion);
                                                    exito = factura.ProcesarCambioEstado(detalle.CASO_ID, Definiciones.EstadosFlujos.Caja, false, out mensaje, sesion);

                                                    if (exito)
                                                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(detalle.CASO_ID, Definiciones.EstadosFlujos.Caja, "Transición automática por paso del Reparto Nro. " + cabeceraRow.CASO_ID + " al estado Cerrado.", sesion);
                                                    if (exito)
                                                        factura.EjecutarAccionesLuegoDeCambioEstado(detalle.CASO_ID, Definiciones.EstadosFlujos.Caja, sesion);
                                                }
                                                break;

                                            case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:
                                                // Cambiar la caja de sucursal asociada de la NC si es un caso de NC
                                                 NotasCreditoPersonaService.SetCajaSucursal(detalle.CASO_ID, cabeceraRow.CTACTE_CAJA_SUC_ID, sesion);
                                                break;

                                            case Definiciones.FlujosIDs.NOTA_DEBITO_PERSONA:
                                                // Cambiar la caja de sucursal asociada de la ND si es un caso de ND
                                                NotasDebitoPersonaService.SetCajaSucursal(detalle.CASO_ID, cabeceraRow.CTACTE_CAJA_SUC_ID, sesion);
                                                break;
                                            case Definiciones.FlujosIDs.TRANSFERENCIA_DE_ARTICULOS:
                                                break;
                                            default: throw new System.ArgumentException("Error Repartos Service, situacion para flujo no implementado");
                                        }
                                        
                                       
                                        
                                        
                                    }
                                    else if (detalle.ENTREGA_EXITOSA.Equals(Definiciones.SiNo.No))
                                    {
                                                                             
                                        switch (flujoId)
                                        {
                                            case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                                                //Cambiar el caso de FC al estado ParaReparto
                                                exito = factura.ProcesarCambioEstado(detalle.CASO_ID, Definiciones.EstadosFlujos.ParaReparto, false, out mensaje, sesion);
                                                if (exito)
                                                    exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(detalle.CASO_ID, Definiciones.EstadosFlujos.ParaReparto, "Transición automática por paso del Reparto Nro. " + cabeceraRow.CASO_ID + " al estado Cerrado.", sesion);
                                                if (exito)
                                                    factura.EjecutarAccionesLuegoDeCambioEstado(detalle.CASO_ID, Definiciones.EstadosFlujos.ParaReparto, sesion);
                                                break;

                                            case Definiciones.FlujosIDs.TRANSFERENCIA_DE_ARTICULOS:

                                                if (casoEstado.Equals(Definiciones.EstadosFlujos.Viajando))
                                                {
                                                    exito = (new StockTransferenciasService()).ProcesarCambioEstado(detalle.CASO_ID, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                                                    if (exito)
                                                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(detalle.CASO_ID, Definiciones.EstadosFlujos.Aprobado, "Transición por inclusion en caso de Reparto Nro: " + detalle.CASO_ID, sesion);
                                                    if (exito)
                                                        (new StockTransferenciasService()).EjecutarAccionesLuegoDeCambioEstado(detalle.CASO_ID, Definiciones.EstadosFlujos.Aprobado, sesion);
                                                }
                                                break;

                                            case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:

                                                break;
                                            default: throw new System.ArgumentException("Error Repartos Service, situacion para flujo no implementado");
                                        }
                                        

                                    }
                                    else
                                    {
                                        throw new System.ArgumentException("En el Reparto caso Nro. " + cabeceraRow.CASO_ID + " la FC caso Nro. " + detalle.CASO_ID + " no fue marcada como entregada o no exitosamente.");
                                    }

                                    if (!exito) break;
                                }
                                catch (Exception exp)
                                {
                                    exito = false;
                                    mensaje = exp.Message;
                                }
                            }
                        }
                    }
                    #endregion Rendicion a Cerrado

                    //Verificar si se cumplen los requisitos
                    if (exito && revisarRequisitos)
                    {
                        exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                    }

                    if (exito)
                    {
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.REPARTOSCollection.Update(cabeceraRow);
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
            REPARTOSRow row = sesion.Db.REPARTOSCollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE;
        }

        #endregion Implementacion de metodos abstract
        
        #region GetRepartosDataTable
        /// <summary>
        /// Gets the repartos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetRepartosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.REPARTOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetRepartosDataTable

        #region GetRepartosInfoCompleta
        /// <summary>
        /// Gets the repartos information completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetRepartosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.REPARTOS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetRepartosInfoCompleta

        #region GetReparto

        /// <summary>
        /// Gets the reparto.
        /// </summary>
        /// <param name="reparto_id">The reparto_id.</param>
        /// <returns></returns>
        public static REPARTOSRow GetReparto(Decimal reparto_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.REPARTOSCollection.GetByPrimaryKey(reparto_id);
            }
        }
        #endregion GetReparto

        #region GetRepartoPorCaso
        /// <summary>
        /// Gets the reparto por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static DataTable GetRepartoPorCaso(Decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.REPARTOSCollection.GetAsDataTable(" caso_id = " + caso_id, "");
            }
        }
        #endregion GetRepartoPorCaso

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref String estado_id) {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                REPARTOSRow row = new REPARTOSRow();

                try
                {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[RepartosService.SucursalId_NombreCol].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.REPARTO.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("repartos_sqc");
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                        row.IMPRESO = Definiciones.SiNo.No;
                    }
                    else
                    {
                        row = sesion.Db.REPARTOSCollection.GetRow(RepartosService.Id_NombreCol + " = " + decimal.Parse((string)campos[RepartosService.Id_NombreCol]));
                        valorAnterior = row.ToString();
                    }

                    //Panel Reparto
                    if (campos.Contains(RepartosService.SucursalId_NombreCol)) row.SUCURSAL_ID = decimal.Parse(campos[RepartosService.SucursalId_NombreCol].ToString());
                    else row.IsSUCURSAL_IDNull = true;
                    if (campos.Contains(RepartosService.DepositoId_NombreCol)) row.DEPOSITO_ID = decimal.Parse(campos[RepartosService.DepositoId_NombreCol].ToString());
                    else row.IsDEPOSITO_IDNull = true;
                    if (campos.Contains(RepartosService.Fecha_NombreCol)) row.FECHA = DateTime.Parse((string)campos[RepartosService.Fecha_NombreCol]);
                    else row.IsFECHANull = true;
                    if (campos.Contains(RepartosService.AutonumeracionId_NombreCol)) row.AUTONUMERACION_ID = decimal.Parse(campos[RepartosService.AutonumeracionId_NombreCol].ToString());
                    else row.IsAUTONUMERACION_IDNull = true;
                    row.NRO_COMPROBANTE = campos[RepartosService.NroComprobante_NombreCol].ToString();

                    if (campos.Contains(RepartosService.CtaCteCajaSucId_NombreCol)) row.CTACTE_CAJA_SUC_ID = decimal.Parse(campos[RepartosService.CtaCteCajaSucId_NombreCol].ToString());
                    else row.IsCTACTE_CAJA_SUC_IDNull = true;

                    if (campos.Contains(RepartosService.KilometrajeSalida_NombreCol)) 
                        row.KILOMETRAJE_SALIDA = decimal.Parse(campos[RepartosService.KilometrajeSalida_NombreCol].ToString());
                    else
                        row.IsKILOMETRAJE_SALIDANull = true;   

                    if (campos["ACTUALIZAR_FECHA_SALIDA"].ToString() == Definiciones.SiNo.Si)
                    {
                        if (campos.Contains(RepartosService.FechaSalida_NombreCol)) row.FECHA_SALIDA = DateTime.Parse(campos[RepartosService.FechaSalida_NombreCol].ToString());
                        else row.IsFECHA_SALIDANull = true;
                    }

                    if (campos["ACTUALIZAR_FECHA_REGRESO"].ToString() == Definiciones.SiNo.Si)
                    {
                        if (campos.Contains(RepartosService.FechaRegreso_NombreCol)) row.FECHA_REGRESO = DateTime.Parse(campos[RepartosService.FechaRegreso_NombreCol].ToString());
                        else row.IsFECHA_REGRESONull = true;
                        if (campos.Contains(RepartosService.KilometrajeRegreso_NombreCol)) row.KILOMETRAJE_REGRESO = decimal.Parse(campos[RepartosService.KilometrajeRegreso_NombreCol].ToString());
                        else row.IsKILOMETRAJE_REGRESONull = true;
                    }

                    //Se obtiene el id del chofer y cada acompanhante
                    decimal chofer, aco1, aco2;
                    if (campos.Contains(RepartosService.FuncionarioChoferId_NombreCol)) chofer = decimal.Parse(campos[RepartosService.FuncionarioChoferId_NombreCol].ToString());
                    else chofer = Definiciones.Error.Valor.EnteroPositivo;
                    if (campos.Contains(RepartosService.FuncionarioAcompanhante1_NombreCol)) aco1 = decimal.Parse(campos[RepartosService.FuncionarioAcompanhante1_NombreCol].ToString());
                    else aco1 = Definiciones.Error.Valor.EnteroPositivo;
                    if (campos.Contains(RepartosService.FuncionarioAcompanhante2_NombreCol)) aco2 = decimal.Parse(campos[RepartosService.FuncionarioAcompanhante2_NombreCol].ToString());
                    else aco2 = Definiciones.Error.Valor.EnteroPositivo;
                    //Se controla que no este definido el mismo funcionario en mas de un puesto
                    if ((chofer != Definiciones.Error.Valor.EnteroPositivo && (chofer == aco1 || chofer == aco2 )) ||
                       (aco1 != Definiciones.Error.Valor.EnteroPositivo && (aco1 == chofer || aco1 == aco2 )) ||
                       (aco2 != Definiciones.Error.Valor.EnteroPositivo && (aco2 == chofer || aco2 == aco1 ))
                       )
                    {
                        throw new System.ArgumentException("Un mismo funcionario no puede ocupar más de un puesto");
                    }

                    if (campos.Contains(RepartosService.FuncionarioChoferId_NombreCol)) row.FUNCIONARIO_CHOFER_ID = decimal.Parse(campos[RepartosService.FuncionarioChoferId_NombreCol].ToString());
                    else row.IsFUNCIONARIO_CHOFER_IDNull = true;
                    if (campos.Contains(RepartosService.FuncionarioAcompanhante1_NombreCol)) row.FUNCIONARIO_ACOMPANHANTE_1 = decimal.Parse(campos[RepartosService.FuncionarioAcompanhante1_NombreCol].ToString());
                    else row.IsFUNCIONARIO_ACOMPANHANTE_1Null = true;
                    if (campos.Contains(RepartosService.FuncionarioAcompanhante2_NombreCol)) row.FUNCIONARIO_ACOMPANHANTE_2 = decimal.Parse(campos[RepartosService.FuncionarioAcompanhante2_NombreCol].ToString());
                    else row.IsFUNCIONARIO_ACOMPANHANTE_2Null = true;
                    
                    //Panel Observacion
                    row.OBSERVACION = campos[RepartosService.Observacion_NombreCol].ToString();

                    //Vehiculo Asociado
                    if(campos.Contains(RepartosService.VehiculoId_NombreCol))
                        row.VEHICULO_ID = decimal.Parse(campos[RepartosService.VehiculoId_NombreCol].ToString());
                    else
                        throw new System.ArgumentException("Se debe asociar un vehiculo al caso de reparto");
                    
                    if (insertarNuevo) sesion.Db.REPARTOSCollection.Insert(row);
                    else sesion.Db.REPARTOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(RepartosService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                    if(!row.IsFUNCIONARIO_CHOFER_IDNull)
                        camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.FUNCIONARIO_CHOFER_ID);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos
                    
                    exito = true;
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
                return exito;
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borra de la base de datos el caso y la cabecera del flujo
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public static bool Borrar(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    bool exito = true;
                    String mensaje = "Error.";

                    //Se obtienen el caso y la factura a ser borrados
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    REPARTOSRow cabecera = sesion.Db.REPARTOSCollection.GetByCASO_ID(caso_id)[0];

                    
                    if (! caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Se obtienen los detalles del caso a ser borrados.
                    DataTable detalles = (new RepartosDetalleService()).GetRepartoDetalle(cabecera.ID);

                    //Si el caso posee detalles no puede ser borrado
                    if (detalles.Rows.Count > 0)
                    {
                       
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.REPARTOSCollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro(RepartosService.Nombre_Tabla, cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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

        #region ActualizarImpreso
        public static void ActualizarImpreso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                REPARTOSRow row = new REPARTOSRow();
                string valorAnterior = string.Empty;
                try
                {
                    sesion.Db.BeginTransaction();

                    row = sesion.Db.REPARTOSCollection.GetRow(CasoId_NombreCol + " = " + caso_id);
                    valorAnterior = row.ToString();
                    
                    if (EsActualizable && row.IMPRESO == Definiciones.SiNo.No)
                        row.FECHA = DateTime.Today.Date;

                    row.IMPRESO = Definiciones.SiNo.Si;

                    sesion.Db.REPARTOSCollection.Update(row);
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
        public static bool EsActualizable
        {
            get
            {
                return VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.ReportesActualizarImpreso).Equals(Definiciones.SiNo.Si);
            }
        }

        /// <summary>
        /// Metodo auxiliar para saber si un caso ya fue impreso
        /// </summary>
        /// <param name="casoId">El Id del Caso.</param>
        /// <returns>True si fue impreso, False en caso contrario o si no existe.</returns>

        public static bool FueImpreso(decimal casoId)
        {
            if (casoId == Definiciones.Error.Valor.EnteroPositivo) return false;
            using (SessionService sesion = new SessionService())
            {
                REPARTOSRow row = sesion.Db.REPARTOSCollection.GetRow(CasoId_NombreCol + " = " + casoId);
                return row.IMPRESO.Equals(Definiciones.SiNo.Si);
            }
        }

        #endregion ActualizarImpreso

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "REPARTOS"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return REPARTOSCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return REPARTOSCollection.CASO_IDColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return REPARTOSCollection.DEPOSITO_IDColumnName; }
        }
        public static string FechaRegreso_NombreCol
        {
            get { return REPARTOSCollection.FECHA_REGRESOColumnName; }
        }
        public static string FechaSalida_NombreCol
        {
            get { return REPARTOSCollection.FECHA_SALIDAColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return REPARTOSCollection.FECHAColumnName; }
        }
        public static string FuncionarioAcompanhante1_NombreCol
        {
            get { return REPARTOSCollection.FUNCIONARIO_ACOMPANHANTE_1ColumnName; }
        }
        public static string FuncionarioAcompanhante2_NombreCol
        {
            get { return REPARTOSCollection.FUNCIONARIO_ACOMPANHANTE_2ColumnName; }
        }
        public static string FuncionarioChoferId_NombreCol
        {
            get { return REPARTOSCollection.FUNCIONARIO_CHOFER_IDColumnName; }
        }
        public static string Impreso_NombreCol
        {
            get { return REPARTOSCollection.IMPRESOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return REPARTOSCollection.IDColumnName; }
        }
        public static string KilometrajeRegreso_NombreCol
        {
            get { return REPARTOSCollection.KILOMETRAJE_REGRESOColumnName; }
        }
        public static string KilometrajeSalida_NombreCol
        {
            get { return REPARTOSCollection.KILOMETRAJE_SALIDAColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return REPARTOSCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return REPARTOSCollection.OBSERVACIONColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return REPARTOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string VehiculoId_NombreCol
        {
            get { return REPARTOSCollection.VEHICULO_IDColumnName; }
        }
        public static string CtaCteCajaSucId_NombreCol
        {
            get { return REPARTOSCollection.CTACTE_CAJA_SUC_IDColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return REPARTOS_INFO_COMPLETACollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCasoFechaCreacion_NombreCol
        {
            get { return REPARTOS_INFO_COMPLETACollection.CASO_FECHA_CREACIONColumnName; }
        }
        public static string VistaCasoUsuarioNombre_NombreCol
        {
            get { return REPARTOS_INFO_COMPLETACollection.CASO_USUARIO_NOMBREColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return REPARTOS_INFO_COMPLETACollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return REPARTOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaDepositoAbreviatura_NombreCol
        {
            get { return REPARTOS_INFO_COMPLETACollection.DEPOSITO_ABREVIATURAColumnName; }
        }
        public static string VistaDepositoNombre_NombreCol
        {
            get { return REPARTOS_INFO_COMPLETACollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaFuncionarioAcomp1NombreComp_NombreCol
        {
            get { return REPARTOS_INFO_COMPLETACollection.FUNCIONARIO_ACOMP1_NOMBRE_COMPColumnName; }
        }
        public static string VistaFuncionarioAcomp2NombreComp_NombreCol
        {
            get { return REPARTOS_INFO_COMPLETACollection.FUNCIONARIO_ACOMP2_NOMBRE_COMPColumnName; }
        }
        public static string VistaFuncionarioChoferNombreComp_NombreCol
        {
            get { return REPARTOS_INFO_COMPLETACollection.FUNCIONARIO_CHOFER_NOMBRE_COMPColumnName; }
        }
        public static string VistaVehiculoMarca_NombreCol 
        {
            get { return REPARTOS_INFO_COMPLETACollection.MARCAColumnName; }
        }
        public static string VistaVehiculoModelo_NombreCol
        {
            get { return REPARTOS_INFO_COMPLETACollection.MODELOColumnName; }
        }
        public static string VistaVehiculoAbreviatura_NombreCol
        {
            get { return REPARTOS_INFO_COMPLETACollection.ABREVIATURAColumnName; }
        }
        public static string VistaVehiculoNombre_NombreCol
        {
            get { return REPARTOS_INFO_COMPLETACollection.NOMBREColumnName; }
        }
        public static string VistaVehiculoMatricula_NombreCol
        {
            get { return REPARTOS_INFO_COMPLETACollection.MATRICULAColumnName; }
        }
        

        #endregion Vista
        #endregion Accessors
    }
}
