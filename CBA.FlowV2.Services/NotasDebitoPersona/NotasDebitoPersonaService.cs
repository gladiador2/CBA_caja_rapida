using System;
using System.Data;
using CBA.FlowV2.Db;

using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Stock;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

namespace CBA.FlowV2.Services.NotasDebitoPersona
{
    public class NotasDebitoPersonaService : FlujosServiceBaseWorkaround
    {
        #region ActualizarImpreso

        public static void ActualizarImpreso(decimal casoId)
        {
            using (SessionService sesion = new SessionService())
            {
                NOTA_DEBITO_PERSONARow row = new NOTA_DEBITO_PERSONARow();
                string valorAnterior = string.Empty;
                try
                {
                    sesion.Db.BeginTransaction();
                    row = sesion.Db.NOTA_DEBITO_PERSONACollection.GetRow(CasoId_NombreCol + " = " + casoId);
                    valorAnterior = row.ToString();

                    if (EsActualizable && row.IMPRESO == Definiciones.SiNo.No)
                    {
                        row.FECHA = DateTime.Today.Date;
                        row.COTIZACION = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, row.FECHA, sesion);
                    }

                    row.IMPRESO = Definiciones.SiNo.Si;

                    sesion.Db.NOTA_DEBITO_PERSONACollection.Update(row);
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
        /// <returns>True si fue impreso, False en caso contrario.</returns>
        public static bool FueImpreso(decimal casoId)
        {
            if (casoId == Definiciones.Error.Valor.EnteroPositivo) return false;
            using (SessionService sesion = new SessionService())
            {
                NOTA_DEBITO_PERSONARow row = sesion.Db.NOTA_DEBITO_PERSONACollection.GetRow(CasoId_NombreCol + " = " + casoId);
                return row.IMPRESO.Equals(Definiciones.SiNo.Si);
            }
        }

        #endregion ActualizarImpreso

        #region Actualizar
        private static bool Actualizar(NOTA_DEBITO_PERSONARow filaNueva)
        {
            bool res = false;
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    res = Actualizar(filaNueva, sesion);
                    sesion.db.CommitTransaction();

                }
                catch (Exception e)
                {
                    sesion.db.RollbackTransaction();
                    throw e;
                }
            }
            return res;
        }
        private static bool Actualizar(NOTA_DEBITO_PERSONARow filaNueva, SessionService sesion)
        {
            bool res = false;
            try
            {
                NOTA_DEBITO_PERSONARow filaVieja = sesion.db.NOTA_DEBITO_PERSONACollection.GetByPrimaryKey(filaNueva.ID);
                // TRIGGERS BEFORE
                res = sesion.db.NOTA_DEBITO_PERSONACollection.Update(filaNueva);
                // TRIGGERS AFTER
                LogCambiosService.LogDeRegistro(Nombre_Tabla, filaNueva.ID, filaVieja.ToString(), filaNueva.ToString(), sesion);
            }
            catch (Exception e)
            {
                sesion.db.RollbackTransaction();
                throw e;
            }
            return res;
        }
        #endregion Actualizar

        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.NOTA_DEBITO_PERSONA;
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
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, );
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, drDetalle[NotasDebitoPersonaDetalleService.ActivoId_NombreCol]);
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
                NOTA_DEBITO_PERSONARow cabeceraRow = sesion.Db.NOTA_DEBITO_PERSONACollection.GetByCASO_ID(caso_id)[0];
                NOTA_DEBITO_PERSONA_DETALLERow[] detalleRow = sesion.Db.NOTA_DEBITO_PERSONA_DETALLECollection.GetByNOTA_DEBITO_PERSONA_ID(cabeceraRow.ID);
                #region BORRADOR A ANULADO
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna.
                    exito = true;
                    revisarRequisitos = true;
                }
                #endregion BORRADOR A ANULADO

                #region BORRADOR A PENDIENTE
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Crear una autonumeracion si no existe.
                    exito = true;
                    revisarRequisitos = true;

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    #region generar autonumeracion

                    //Si no existe un comprobante se crea
                    if (exito && cabeceraRow.NRO_COMPROBANTE == null)
                        cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, sesion);
                    #endregion generar autonumeracion
                }
                #endregion BORRADOR A PENDIENTE

                #region PENDIENTE A BORRADOR
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //ninguna.
                    exito = true;
                }
                #endregion PENDIENTE A BORRADOR

                #region PENDIENTE A ANULADO
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna
                    exito = true;
                }
                #endregion PENDIENTE A ANULADO

                #region PENDIENTE A APROBADO
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones
                    //Afectar la cuenta corriente de la persona
                    exito = true;
                    revisarRequisitos = true;

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    if (exito)
                    {
                        System.Collections.Hashtable montoPorImpuesto = new System.Collections.Hashtable();
                        DataTable dtImpuesto;
                        decimal[] impuestoId, monto;
                        decimal montoVerificacion;
                        int indiceAux;

                        #region Controlar que tenga una caja asignada
                        /*if (cabeceraRow.IsCTACTE_CAJA_SUCURSAL_IDNull)
                        {
                            throw new Exception("No se definió la caja de sucursal asignada.");
                        }*/
                        #endregion Controlar que tenga una caja asignada

                        #region Calcular monto por tipo de impuesto
                        for (int i = 0; i < detalleRow.Length; i++)
                        {
                            dtImpuesto = ImpuestosService.GetImpuestosDataTable(ImpuestosService.Porcentaje_NombreCol + " = " + detalleRow[i].PORCENTAJE_IMPUESTO.ToString(CultureInfo.InvariantCulture), string.Empty);
                            if (dtImpuesto.Rows.Count <= 0)
                                throw new Exception("Error en NotasDebitoPersonasService.ProcesarCambioEstado(). No se encuentra un impuesto con porcentaje " + detalleRow[i].MONTO_IMPUESTO + ".");

                            if (montoPorImpuesto.Contains(dtImpuesto.Rows[0][ImpuestosService.Id_NombreCol]))
                                montoPorImpuesto[dtImpuesto.Rows[0][ImpuestosService.Id_NombreCol]] = (decimal)montoPorImpuesto[dtImpuesto.Rows[0][ImpuestosService.Id_NombreCol]] + detalleRow[i].MONTO;
                            else
                                montoPorImpuesto.Add(dtImpuesto.Rows[0][ImpuestosService.Id_NombreCol], detalleRow[i].MONTO);
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

                        if (cabeceraRow.MONTO != montoVerificacion)
                            throw new Exception("Error en NotasDebitoPersonasService.ProcesarCambioEstado(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + cabeceraRow.MONTO + ".");
                        #endregion Calcular monto por tipo de impuesto

                        #region afectar ctacte
                        //Ingresar el debito
                        CuentaCorrientePersonasService.AgregarCredito((decimal)cabeceraRow.PERSONA_ID,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                    cabeceraRow.CASO_ID,
                                                    cabeceraRow.MONEDA_ID,
                                                    cabeceraRow.COTIZACION,
                                                    impuestoId,
                                                    monto,
                                                    string.Empty,
                                                    DateTime.Now,
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

                        #endregion afectar ctacte
                    }
                }
                #endregion PENDIENTE A APROBADO

                #region APROBADO A CERRADO
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                {
                    //Acciones
                    //ninguna.
                    exito = true;
                    revisarRequisitos = true;
                }
                #endregion APROBADO A CERRADO

                //Verificar si se cumplen los requisitos
                if (exito && revisarRequisitos)
                {
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                }

                if (exito)
                {
                    sesion.Db.CASOSCollection.Update(casoRow);
                    sesion.Db.NOTA_DEBITO_PERSONACollection.Update(cabeceraRow);
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
            try
            {
                CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                NOTA_DEBITO_PERSONARow cabeceraRow = sesion.Db.NOTA_DEBITO_PERSONACollection.GetByCASO_ID(caso_id)[0];
                return cabeceraRow.NRO_COMPROBANTE;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Implementacion de metodos abstract

        #region GetNotaDebitoPersonaDataTable
        /// <summary>
        /// Gets the nota debito persona data table.
        /// </summary>
        /// <param name="nota_debito_persona_id">The nota_debito_persona_id.</param>
        /// <returns></returns>
        public static DataTable GetNotaDebitoPersonaDataTable(decimal nota_debito_persona_id)
        {
            return GetNotaDebitoPersonaDataTable(Id_NombreCol + " = " + nota_debito_persona_id, string.Empty);
        }

        /// <summary>
        /// Gets the nota debito persona data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetNotaDebitoPersonaDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaDebitoPersonaDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaDebitoPersonaDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.NOTA_DEBITO_PERSONACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetNotaDebitoPersonaDataTable

        #region GetNotaDebitoPersonaInfoCompleta
        /// <summary>
        /// Gets the nota debito persona info completa.
        /// </summary>
        /// <param name="nota_debito_persona_id">The nota_debito_persona_id.</param>
        /// <returns></returns>
        public static DataTable GetNotaDebitoPersonaInfoCompleta(decimal nota_debito_persona_id)
        {
            return GetNotaDebitoPersonaInfoCompleta(Id_NombreCol + " = " + nota_debito_persona_id, string.Empty);
        }

        /// <summary>
        /// Gets the nota debito persona info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetNotaDebitoPersonaInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaDebitoPersonaInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaDebitoPersonaInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ND_PERSONA_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetNotaDebitoPersonaInfoCompleta

        #region GetNotaDebitoPersonaPorCaso

        /// <summary>
        /// Gets the nota debito persona por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static DataTable GetNotaDebitoPersonaPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.NOTA_DEBITO_PERSONACollection.GetAsDataTable(CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        public static DataTable GetNotaDebitoPersonaPorCasoInfoCompleta(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ND_PERSONA_INFO_COMPLETACollection.GetAsDataTable(CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetNotaDebitoPersonaPorCaso

        /// <summary>
        /// Sets the ctacte_caja_sucursal_id.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="ctacte_caja_sucursal_id">The ctacte_caja_sucursal_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void SetCajaSucursal(decimal caso_id, decimal ctacte_caja_sucursal_id, SessionService sesion)
        {
            NOTA_DEBITO_PERSONARow row = new NOTA_DEBITO_PERSONARow();

            try
            {
                row = sesion.Db.NOTA_DEBITO_PERSONACollection.GetRow(CasoId_NombreCol + " = " + caso_id);
                string valorAnteriorFactura = row.ToString();
                row.CTACTE_CAJA_SUCURSAL_ID = ctacte_caja_sucursal_id;
                sesion.db.NOTA_DEBITO_PERSONACollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnteriorFactura, row.ToString(), sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region VerificarPuedeAvanzarEstado
        public static bool VerificarPuedeAvanzarEstado(decimal caso_id, out string mensaje, SessionService sesion)
        {
            return FlujosService.VerificarPuedeAvanzarEstado(caso_id, out mensaje, "NOTAS DEBITO PERSONA NO CONTROLAR MARGEN DIAS PUEDE AVANZAR", Definiciones.VariablesDeSistema.NDPersonasMargenDiasPuedeAvanzar, sesion);
        }
        #endregion VerificarPuedeAvanzarEstado

        #region RecalcularTotal
        /// <summary>
        /// Recalculars the total.
        /// </summary>
        /// <param name="nota_credito_persona_id">The nota_credito_persona_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void RecalcularTotal(decimal nota_debito_persona_id, SessionService sesion)
        {
            NOTA_DEBITO_PERSONARow row = sesion.Db.NOTA_DEBITO_PERSONACollection.GetByPrimaryKey(nota_debito_persona_id);
            NOTA_DEBITO_PERSONA_DETALLERow[] detalleRows = sesion.Db.NOTA_DEBITO_PERSONA_DETALLECollection.GetByNOTA_DEBITO_PERSONA_ID(nota_debito_persona_id);
            decimal total = 0;
            decimal impuesto = 0;
            string valorAnterior;

            valorAnterior = row.MONTO.ToString();

            for (int i = 0; i < detalleRows.Length; i++)
            {
                total += detalleRows[i].MONTO;
                impuesto += detalleRows[i].MONTO_IMPUESTO;
            }

            row.MONTO = total;

            row.MONTO_IMPUESTO = impuesto;

            sesion.Db.NOTA_DEBITO_PERSONACollection.Update(row);
            LogCambiosService.LogDeColumna(Nombre_Tabla, Monto_NombreCol, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion RecalcularTotal

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                NOTA_DEBITO_PERSONARow row = new NOTA_DEBITO_PERSONARow();

                try
                {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[SucursalId_NombreCol].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.NOTA_DEBITO_PERSONA.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("NOTA_DEBITO_PERSONA_SQC");
                        row.IMPRESO = Definiciones.SiNo.No;
                        row.MONTO = 0;

                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.NOTA_DEBITO_PERSONACollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    if (row.SUCURSAL_ID != decimal.Parse(campos[SucursalId_NombreCol].ToString()))
                    {
                        if (SucursalesService.EstaActivo(decimal.Parse(campos[SucursalId_NombreCol].ToString())))
                        {
                            row.SUCURSAL_ID = decimal.Parse(campos[SucursalId_NombreCol].ToString());
                            CasosService.ActualizarSucursal(row.CASO_ID, row.SUCURSAL_ID, sesion);
                        }
                        else
                            throw new System.Exception("La sucursal se encuentra inactiva.");
                    }


                    if (row.PERSONA_ID != decimal.Parse(campos[PersonaId_NombreCol].ToString()))
                    {
                        if (PersonasService.EstaActivo(decimal.Parse(campos[PersonaId_NombreCol].ToString())))
                            row.PERSONA_ID = decimal.Parse(campos[PersonaId_NombreCol].ToString());
                        else
                            throw new System.Exception("La persona se encuentra inactiva.");
                    }

                    if (campos.Contains(NotasDebitoPersonaService.CtaCteCajaSucursalId_NombreCol))
                        row.CTACTE_CAJA_SUCURSAL_ID = (decimal)campos[NotasDebitoPersonaService.CtaCteCajaSucursalId_NombreCol];
                    else
                        row.IsCTACTE_CAJA_SUCURSAL_IDNull = true;

                    row.AUTONUMERACION_ID = decimal.Parse(campos[AutonumeracionId_NombreCol].ToString());

                    if (campos.Contains(NroComprobante_NombreCol)) row.NRO_COMPROBANTE = (string)campos[NroComprobante_NombreCol];

                    if (!MonedasService.EstaActivo((decimal.Parse(campos[MonedaId_NombreCol].ToString()))))
                    {
                        throw new System.Exception("La moneda se encuentra inactiva.");
                    }
                    else
                    {
                        row.MONEDA_ID = decimal.Parse(campos[MonedaId_NombreCol].ToString());
                            
                        row.COTIZACION = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, row.FECHA, sesion);

                        // Si no existe una cotización definida para la fecha, intentar con la fecha de creación del caso
                        if (row.COTIZACION.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        {
                            DateTime fecha = (DateTime)CasosService.GetCasoPorId(Convert.ToDecimal(caso_id)).FECHA_CREACION;
                            row.COTIZACION = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, fecha, sesion);
                        }

                        if (row.COTIZACION.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("Debe actualizarse la cotización de la moneda.");
                    }

                    row.OBSERVACION = (string)campos[Observacion_NombreCol];

                    if (insertarNuevo)
                    {
                        sesion.Db.NOTA_DEBITO_PERSONACollection.Insert(row);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    }
                    else
                    {
                        Actualizar(row, sesion);
                    }

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
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
        /// <returns></returns>
        public static bool Borrar(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    bool exito = true;
                    String mensaje = "Error.";

                    //Se obtiene el caso a ser borrado
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    NOTA_DEBITO_PERSONARow cabecera = sesion.Db.NOTA_DEBITO_PERSONACollection.GetByCASO_ID(caso_id)[0];
                    DataTable dtDetalles;

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        //Borrar los detalles del caso
                        dtDetalles = NotasDebitoPersonaDetalleService.GetNotaDebitoPersonaDetalleDataTable(cabecera.ID);
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            NotasDebitoPersonaDetalleService.Borrar((decimal)dtDetalles.Rows[i][Id_NombreCol]);
                        }

                        sesion.Db.NOTA_DEBITO_PERSONACollection.DeleteByCASO_ID(caso_id);
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
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "NOTA_DEBITO_PERSONA"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return NOTA_DEBITO_PERSONACollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return NOTA_DEBITO_PERSONACollection.CASO_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return NOTA_DEBITO_PERSONACollection.COTIZACIONColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get
            { return NOTA_DEBITO_PERSONACollection.FECHAColumnName; }
        }

        public static string Id_NombreCol
        {
            get { return NOTA_DEBITO_PERSONACollection.IDColumnName; }
        }
        public static string Impreso_NombreCol
        {
            get { return NOTA_DEBITO_PERSONACollection.IMPRESOColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return NOTA_DEBITO_PERSONACollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return NOTA_DEBITO_PERSONACollection.MONTOColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return NOTA_DEBITO_PERSONACollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return NOTA_DEBITO_PERSONACollection.OBSERVACIONColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return NOTA_DEBITO_PERSONACollection.PERSONA_IDColumnName; }
        }

        public static string SucursalId_NombreCol
        {
            get { return NOTA_DEBITO_PERSONACollection.SUCURSAL_IDColumnName; }
        }
        public static string TotalImpuesto_NombreCol
        {
            get { return NOTA_DEBITO_PERSONACollection.MONTO_IMPUESTOColumnName; }
        }
        public static string CtaCteCajaSucursalId_NombreCol
        {
            get { return NOTA_DEBITO_PERSONACollection.CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        #endregion Tabla
        #region Vista
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return ND_PERSONA_INFO_COMPLETACollection.CASO_ESTADOColumnName; }
        }

        public static string VistaSucursalNombre_NombreCol
        {
            get { return ND_PERSONA_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return ND_PERSONA_INFO_COMPLETACollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return ND_PERSONA_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return ND_PERSONA_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaFechaCaso_NombreCol
        {
            get { return ND_PERSONA_INFO_COMPLETACollection.CASO_FECHAColumnName; }
        }
        #endregion Vista
        #endregion Accessors
    }
}
