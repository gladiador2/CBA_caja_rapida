using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using System.Collections;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Articulos;
using System.Collections.Generic;
using CBA.FlowV2.Services.General;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CreditosProveedorService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.CREDITOS_PROVEEDOR;
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
                CREDITOS_PROVEEDORRow cabeceraRow = sesion.Db.CREDITOS_PROVEEDORCollection.GetByCASO_ID(caso_id)[0];
                DataTable dtDetalles = CreditosProveedorDetalleService.GetCreditosProveedorDetalleDataTable(CreditosProveedorDetalleService.CreditoProveedorId_NombreCol + " = " + cabeceraRow.ID, string.Empty);
                
                //Borrador a Anulado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna accion
                    exito = true;
                    revisarRequisitos = true;
                }
                //Borrador a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Controlar que se haya definido un numero de comprobante
                    exito = true;
                    revisarRequisitos = true;

                    if (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Length == 0)
                    {
                        mensaje = "El caso debe tener un número de comprobante.";
                        exito = false;
                    }
                }
                //Pendiente a Borrador 
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //Ninguna accion
                    exito = true;
                }
                //Pendiente a Pre-aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones:
                    //
                    //Verificar que la suma de capital de las cuotas es igual al capital de la cabecera.
                    //
                    //Verifica que se haya relacionado el caso a asociado que da ingreso a los valores
                    //Afectar la cuenta corriente del proveedor.
                    //Si se debe, crear factura de proveedor
                    exito = true;
                    revisarRequisitos = true;
                    decimal sumaCapital;

                    if (cabeceraRow.IsCASO_RELAC_INGRESA_VALORES_IDNull)
                    {
                        mensaje = "Debe guardar el caso relacionado que da ingreso a los valores.";
                        exito = false;
                    }

                    #region Verificar suma capital
                    sumaCapital = 0;
                    for (int i=0; i < dtDetalles.Rows.Count; i++)
                        sumaCapital += (decimal)dtDetalles.Rows[i][CreditosProveedorDetalleService.MontoCapital_NombreCol];

                    if (Math.Abs(Math.Round(sumaCapital - cabeceraRow.MONTO_CAPITAL, MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID))) > 0)
                    {
                        mensaje = "La suma del capital correspondiente al conjunto de cuotas difiere del capital indicado en la cabecera en " + (sumaCapital - cabeceraRow.MONTO_CAPITAL) + ".";
                        exito = false;
                    }
                    #endregion Verificar suma capital

                    #region Actualizar cuenta corriente
                    if (exito)
                    {
                        foreach (DataRow dr in dtDetalles.Rows)
                        {
                            decimal montoPago = (decimal)dr[CreditosProveedorDetalleService.MontoCapital_NombreCol] + (decimal)dr[CreditosProveedorDetalleService.MontoInteres_NombreCol];
                            CuentaCorrienteProveedoresService.AgregarCredito(cabeceraRow.PROVEEDOR_ID,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.CuentaCorrienteValores.Credito,
                                                            Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                            casoRow.ID,
                                                            cabeceraRow.MONEDA_ID,
                                                            montoPago,
                                                            "Cuota " + dr[CreditosProveedorDetalleService.NumeroCuota_NombreCol] + "/" + dtDetalles.Rows.Count,
                                                            (DateTime)dr[CreditosProveedorDetalleService.FechaVencimiento_NombreCol],
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            (decimal)dr[CreditosProveedorDetalleService.Id_NombreCol],
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            sesion
                                                           );
                        }

                        //El impuesto puede ser pagado durante el pago de las cuotas
                        if (cabeceraRow.MONTO_IMPUESTO > 0)
                        {
                            decimal montoPago = cabeceraRow.MONTO_IMPUESTO;
                            CuentaCorrienteProveedoresService.AgregarCredito(cabeceraRow.PROVEEDOR_ID,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.CuentaCorrienteValores.Credito,
                                                            Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                            casoRow.ID,
                                                            cabeceraRow.MONEDA_ID,
                                                            montoPago,
                                                            "Impuesto correspondiente al préstamo.",
                                                            (DateTime)dtDetalles.Rows[dtDetalles.Rows.Count - 1][CreditosProveedorDetalleService.FechaVencimiento_NombreCol],
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            (decimal)dtDetalles.Rows[dtDetalles.Rows.Count - 1][CreditosProveedorDetalleService.Id_NombreCol],
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            sesion
                                                           );
                        }
                    }
                    #endregion Actualizar cuenta corriente

                    if (exito)
                    {
                        string fcProveedorObservacion = "Factura correspondiente a aprobación de Crédito de Proveedor caso " + cabeceraRow.CASO_ID + ".";
                        DateTime fcProveedorFecha;
                        if (!cabeceraRow.IsFECHA_DESEMBOLSONull)
                            fcProveedorFecha = cabeceraRow.FECHA_DESEMBOLSO;
                        else if (!cabeceraRow.IsFECHA_APROBACIONNull)
                            fcProveedorFecha = cabeceraRow.FECHA_APROBACION;
                        else
                            fcProveedorFecha = DateTime.Now;

                        CreditosProveedorService.EmitirFactura(cabeceraRow, false, cabeceraRow.MONTO_CAPITAL, cabeceraRow.MONTO_INTERES, fcProveedorFecha, fcProveedorObservacion, sesion);
                    }
                }
                //aprobado a cerrado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                {
                    //Acciones
                    //ninguna.
                    exito = true;
                    revisarRequisitos = true;

                    if (cambio_pedido_por_usuario)
                    {
                        exito = false;
                        mensaje = "Solo el sistema puede utilizar la transición 'Aprobado' -> 'Cerrado'.";
                    }
                }

                //Verificar si se cumplen los requisitos
                if (exito && revisarRequisitos)
                {
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                }

                if (exito)
                {
                    sesion.Db.CASOSCollection.Update(casoRow);
                    sesion.Db.CREDITOS_PROVEEDORCollection.Update(cabeceraRow);
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
            CREDITOS_PROVEEDORRow row = sesion.Db.CREDITOS_PROVEEDORCollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE.Equals(DBNull.Value) ? string.Empty : row.NRO_COMPROBANTE;
        }

        #endregion Implementacion de metodos abstract

        #region GetCreditosProveedorDataTable
        public static DataTable GetCreditosProveedorDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCreditosProveedorDataTable(clausulas, orden, sesion);
            }
        }

        /// <summary>
        /// Gets the creditos proveedor data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCreditosProveedorDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CREDITOS_PROVEEDORCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCreditosProveedorDataTable

        #region GetCreditosProveedorInfoCompleta
        public static DataTable GetCreditosProveedorInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CREDITOS_PROVEEDOR_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCreditosProveedorInfoCompleta

        #region ActualizarTotalesCabecera
        /// <summary>
        /// Actualizars the totales cabecera.
        /// </summary>
        /// <param name="credito_proveedor_id">The credito_proveedor_id.</param>
        public static void ActualizarTotalesCabecera(decimal credito_proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    DataTable dtDetalles = CreditosProveedorDetalleService.GetCreditosProveedorDetalleDataTable(CreditosProveedorDetalleService.CreditoProveedorId_NombreCol + " = " + credito_proveedor_id, string.Empty);
                    CREDITOS_PROVEEDORRow row = sesion.Db.CREDITOS_PROVEEDORCollection.GetByPrimaryKey(credito_proveedor_id);
                    string valorAnterior = row.ToString();

                    row.MONTO_IMPUESTO = 0;
                    row.MONTO_INTERES = 0;
                    row.MONTO_TOTAL = 0;

                    //Se suma el monto correspondiente al interes
                    for (int i = 0; i < dtDetalles.Rows.Count; i++)
                    {
                        row.MONTO_INTERES += (decimal)dtDetalles.Rows[i][CreditosProveedorDetalleService.MontoInteres_NombreCol];
                        row.MONTO_TOTAL += (decimal)dtDetalles.Rows[i][CreditosProveedorDetalleService.MontoCapital_NombreCol] + (decimal)dtDetalles.Rows[i][CreditosProveedorDetalleService.MontoInteres_NombreCol];
                    }

                    if (row.PORCENTAJE_IMPUESTO > 0)
                        row.MONTO_IMPUESTO = row.MONTO_INTERES / ((100 / row.PORCENTAJE_IMPUESTO) + 1);
                    else
                        row.MONTO_IMPUESTO = 0;
                    
                    sesion.Db.CREDITOS_PROVEEDORCollection.Update(row);
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
        #endregion ActualizarTotalesCabecera

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                CREDITOS_PROVEEDORRow row = new CREDITOS_PROVEEDORRow();
                
                try
                {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[CustodiaValoresService.SucursalId_NombreCol].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.CREDITOS_PROVEEDOR.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("creditos_proveedor_sqc");
                        row.SUCURSAL_ID = (decimal)campos[CreditosProveedorService.SucursalId_NombreCol]; //Una vez creado el caso no puede cambiarse de sucursal
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.CREDITOS_PROVEEDORCollection.GetRow(CreditosProveedorService.Id_NombreCol + " = " + campos[CreditosProveedorService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    //Se controla al crear el caso que la sucursal este activa
                    if (insertarNuevo)
                    {
                        if (!SucursalesService.EstaActivo(row.SUCURSAL_ID))
                            throw new Exception("La sucursal no se encuentra activa.");
                    }

                    if(campos.Contains(CreditosProveedorService.CasoRelacIngresaValoresId_NombreCol))
                        row.CASO_RELAC_INGRESA_VALORES_ID = (decimal)campos[CreditosProveedorService.CasoRelacIngresaValoresId_NombreCol];
                    else
                        row.IsCASO_RELAC_INGRESA_VALORES_IDNull = true;

                    //Si cambia
                    if (row.MONEDA_ID.Equals(DBNull.Value) || row.MONEDA_ID != (decimal)campos[CreditosProveedorService.MonedaId_NombreCol])
                    {
                        row.MONEDA_ID = (decimal)campos[CreditosProveedorService.MonedaId_NombreCol];

                        if(!MonedasService.EstaActivo(row.MONEDA_ID))
                            throw new Exception("La moneda no se encuentra activa.");
                    }

                    row.COTIZACION_MONEDA = (decimal)campos[CreditosProveedorService.CotizacionMoneda_NombreCol];
                    if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda.");

                    //Si cambia
                    if (row.PROVEEDOR_ID.Equals(DBNull.Value) || row.PROVEEDOR_ID != (decimal)campos[CreditosProveedorService.ProveedorId_NombreCol])
                    {
                        row.PROVEEDOR_ID = (decimal)campos[CreditosProveedorService.ProveedorId_NombreCol];

                        if (!ProveedoresService.EstaActivo(row.PROVEEDOR_ID))
                            throw new Exception("El proveedor no se encuentra activo.");   
                    }

                    row.TIPO_CREDITO_ID = (decimal)campos[CreditosProveedorService.TipoCreditoId_NombreCol];

                    if (campos.Contains(CreditosProveedorService.FechaAprobacion_NombreCol))
                        row.FECHA_APROBACION = (DateTime)campos[CreditosProveedorService.FechaAprobacion_NombreCol];
                    else
                        row.IsFECHA_APROBACIONNull = true;

                    if (campos.Contains(CreditosProveedorService.FechaDesembolso_NombreCol))
                        row.FECHA_DESEMBOLSO = (DateTime)campos[CreditosProveedorService.FechaDesembolso_NombreCol];
                    else
                        row.IsFECHA_DESEMBOLSONull = true;

                    if (campos.Contains(CreditosProveedorService.FechaSolicitud_NombreCol))
                        row.FECHA_SOLICITUD = (DateTime)campos[CreditosProveedorService.FechaSolicitud_NombreCol];
                    else
                        row.IsFECHA_SOLICITUDNull = true;

                    row.INTERES_ANUAL = (decimal)campos[CreditosProveedorService.InteresAnual_NombreCol];
                    row.MONTO_INTERES = 123; //TODO: falta calcular el monto del interes

                    row.MONTO_CAPITAL = (decimal)campos[CreditosProveedorService.MontoCapital_NombreCol];
                    row.MONTO_TOTAL = row.MONTO_CAPITAL + row.MONTO_INTERES;

                    row.PORCENTAJE_DIARIO_MORA = (decimal)campos[CreditosProveedorService.PorcentajeDiarioMora_NombreCol];
                    row.PORCENTAJE_IMPUESTO = (decimal)campos[CreditosProveedorService.PorcentajeImpuesto_NombreCol];

                    if (row.PORCENTAJE_IMPUESTO == 0)
                        row.MONTO_IMPUESTO = 0;
                    else
                        row.MONTO_IMPUESTO = row.MONTO_TOTAL / (1 + (100 / row.PORCENTAJE_IMPUESTO));

                    row.NRO_COMPROBANTE = (string)campos[CreditosProveedorService.NroComprobante_NombreCol];
                    row.OBSERVACION = (string)campos[CreditosProveedorService.Observacion_NombreCol];
                    row.FACTURAR_INTERESES_EN_PAGOS = (string)campos[CreditosProveedorService.FacturarInteresesEnPagos_NombreCol];
                    row.FACTURAR_CAPITAL_EN_PAGOS = (string)campos[CreditosProveedorService.FacturarCapitalEnPagos_NombreCol];
                    row.FACTURAR_SOLO_INTERESES = (string)campos[CreditosProveedorService.FacturarSoloIntereses_NombreCol];

                    if (insertarNuevo) sesion.Db.CREDITOS_PROVEEDORCollection.Insert(row);
                    else sesion.Db.CREDITOS_PROVEEDORCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA_SOLICITUD);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.ProveedorId_NombreCol, row.PROVEEDOR_ID);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    exito = true;
                }
                catch (Exception)
                {
                    row.ID = Definiciones.Error.Valor.EnteroPositivo;

                    //Si el caso fue creado el mismo debe borrarse
                    if (insertarNuevo && row.CASO_ID > 0)
                    {
                        (new CasosService()).Eliminar(row.CASO_ID, sesion);
                        caso_id = Definiciones.Error.Valor.EnteroPositivo;
                        estado_id = string.Empty;
                    }

                    throw;
                }

                CreditosProveedorService.ActualizarTotalesCabecera(row.ID);

                return exito;
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified caso_id.
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
                    CREDITOS_PROVEEDORRow cabecera = sesion.Db.CREDITOS_PROVEEDORCollection.GetByCASO_ID(caso_id)[0];
                    CreditosProveedorDetalleService creditoProveedorDetalle = new CreditosProveedorDetalleService();
                    DataTable dtDetalles;

                    if (! caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Se borran los detalles si existen
                    if (exito)
                    {
                        dtDetalles = CreditosProveedorDetalleService.GetCreditosProveedorDetalleDataTable(CreditosProveedorDetalleService.CreditoProveedorId_NombreCol + " = " + cabecera.ID, string.Empty);
                        for(int i =0;i<dtDetalles.Rows.Count;i++)
                        {
                            CreditosProveedorDetalleService.Borrar((decimal)dtDetalles.Rows[i][CreditosProveedorDetalleService.Id_NombreCol]);
                        }
                    }

                    if (exito)
                    {
                        sesion.Db.CREDITOS_PROVEEDORCollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                        //Se borra el caso
                        (new CasosService()).Eliminar(caso_id, sesion); 
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

        #region EmitirFacturaPorPago
        public static decimal EmitirFactura(decimal credito_proveedor_id, decimal monto_capital, decimal monto_interes, DateTime fecha, string observacion, SessionService sesion)
        {
            try
            {
                CREDITOS_PROVEEDORRow row = sesion.db.CREDITOS_PROVEEDORCollection.GetByPrimaryKey(credito_proveedor_id);
                return EmitirFactura(row, true, monto_capital, monto_interes, fecha, observacion, sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static decimal EmitirFactura(CREDITOS_PROVEEDORRow cabecera_row, bool es_pago, decimal monto_capital, decimal monto_interes, DateTime fecha, string observacion, SessionService sesion)
        {
            try
            {
                decimal facturaProveedorCasoId = Definiciones.Error.Valor.EnteroPositivo;
                bool emitirCapital, emitirInteres;

                emitirCapital = cabecera_row.FACTURAR_SOLO_INTERESES == Definiciones.SiNo.No;
                if (emitirCapital)
                {
                    emitirCapital = cabecera_row.FACTURAR_CAPITAL_EN_PAGOS == Definiciones.SiNo.Si;
                    if (!es_pago) emitirCapital = !emitirCapital;
                }

                emitirInteres = cabecera_row.FACTURAR_INTERESES_EN_PAGOS == Definiciones.SiNo.Si;
                if (!es_pago) emitirInteres = !emitirInteres;

                if ((emitirCapital && monto_capital <= 0) || (emitirInteres && monto_interes <= 0))
                    return Definiciones.Error.Valor.EnteroPositivo;

                //Si se factura intereses y/o capital desde el credito
                if (emitirCapital || emitirInteres)
                {
                    DataTable dtDepositos = StockDepositosService.GetStockDepositosDataTable2(cabecera_row.SUCURSAL_ID);
                    decimal facturaProveedorId;
                    string msgFacturaProveedor = string.Empty, nroTimbrado;
                    DateTime fechaVencimientoTimbrado;
                    FacturasProveedorService.PropiedadesCabecera fcProveedorCabecera;
                    FacturasProveedorDetalleService.PropiedadesDetalle fcProveedorDetalles;
                    
                    FacturasProveedorService.GetTimbradoAnterior(cabecera_row.PROVEEDOR_ID, out nroTimbrado, out fechaVencimientoTimbrado);

                    fcProveedorCabecera = new FacturasProveedorService.PropiedadesCabecera();
                    fcProveedorCabecera.AfectaCtacteProveedor = false;
                    fcProveedorCabecera.CondicionPagoId = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.CondicionPagoContadoCompra);
                    fcProveedorCabecera.DepositoId = (decimal)dtDepositos.Rows[0][StockDepositosService.Id_NombreCol];
                    fcProveedorCabecera.FechaEntrega_yyyymmdd = fecha.ToString("yyyyMMdd");
                    fcProveedorCabecera.FechaFactura_yyyymmdd = fcProveedorCabecera.FechaEntrega_yyyymmdd;
                    fcProveedorCabecera.FechaPedido_yyyymmdd = fcProveedorCabecera.FechaEntrega_yyyymmdd;
                    fcProveedorCabecera.MonedaId = cabecera_row.MONEDA_ID;
                    fcProveedorCabecera.NroComprobante = "Provisorio " + cabecera_row.CASO_ID + "(" + DateTime.Now + ")"; //el nro de factura debe ser editado por el usuario en el caso de FC
                    fcProveedorCabecera.NroTimbrado = nroTimbrado;
                    fcProveedorCabecera.FechaVencimientoTimbrado_yyyymmdd = fechaVencimientoTimbrado.ToString("yyyyMMdd");
                    fcProveedorCabecera.Observaciones = observacion;
                    fcProveedorCabecera.ProveedorId = cabecera_row.PROVEEDOR_ID;
                    fcProveedorCabecera.SucursalId = cabecera_row.SUCURSAL_ID;
                    fcProveedorCabecera.TipoFacturaId = Definiciones.TipoFacturaProveedor.Gastos;
                    fcProveedorCabecera.UsarFechaFactura = true;
                    fcProveedorCabecera.CasoAsociadoId = cabecera_row.CASO_ID;
                    facturaProveedorCasoId = FacturasProveedorService.Crear(fcProveedorCabecera, out facturaProveedorId, sesion);

                    if (emitirCapital)
                    {
                        DataTable dtArticuloLote = ArticulosLotesService.GetArticulosLotes(ArticulosLotesService.Articulo_ID_NombreCol + " = " + VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoCapitalArticulo), ArticulosLotesService.Id_NombreCol);
                        fcProveedorDetalles = new FacturasProveedorDetalleService.PropiedadesDetalle();
                        fcProveedorDetalles.FacturaProveedorId = facturaProveedorId;
                        fcProveedorDetalles.ArticuloId = (decimal)dtArticuloLote.Rows[0][ArticulosLotesService.Articulo_ID_NombreCol];
                        fcProveedorDetalles.CantidadUnitariaDestino = 1;
                        fcProveedorDetalles.LoteId = (decimal)dtArticuloLote.Rows[0][ArticulosLotesService.Id_NombreCol];
                        fcProveedorDetalles.PrecioBrutoUnitarioDestino = monto_capital;
                        FacturasProveedorDetalleService.Crear(fcProveedorDetalles, sesion);
                    }

                    if (emitirInteres)
                    {
                        var articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente).Articulo;
                        if (articulo.ArticulosLotes.Length <= 0)
                            throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");
                        fcProveedorDetalles = new FacturasProveedorDetalleService.PropiedadesDetalle();
                        fcProveedorDetalles.FacturaProveedorId = facturaProveedorId;
                        fcProveedorDetalles.ArticuloId = articulo.Id.Value;
                        fcProveedorDetalles.CantidadUnitariaDestino = 1;
                        fcProveedorDetalles.LoteId = articulo.ArticulosLotes[0].Id.Value;
                        fcProveedorDetalles.PrecioBrutoUnitarioDestino = monto_interes;
                        FacturasProveedorDetalleService.Crear(fcProveedorDetalles, sesion);
                    }

                    //Pasar de estado la FC a Pendiente
                    bool exitoFCProveedor = (new FacturasProveedorService()).ProcesarCambioEstado(facturaProveedorCasoId, Definiciones.EstadosFlujos.Pendiente, false, out msgFacturaProveedor, sesion);
                    if (exitoFCProveedor)
                        (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(facturaProveedorCasoId, Definiciones.EstadosFlujos.Pendiente, "Transición automática", sesion);
                    if (exitoFCProveedor)
                        (new FacturasProveedorService()).EjecutarAccionesLuegoDeCambioEstado(facturaProveedorCasoId, Definiciones.EstadosFlujos.Pendiente, sesion);
                }

                return facturaProveedorCasoId;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion EmitirFacturaPorPago

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CREDITOS_PROVEEDOR"; }
        }
        public static string Nombre_Vista
        {
            get { return "CREDITOS_PROVEEDOR_INFO_COMP"; }
        }
        public static string CasoId_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.CASO_IDColumnName; }
        }
        public static string CasoRelacIngresaValoresId_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.CASO_RELAC_INGRESA_VALORES_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string FacturarCapitalEnPagos_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.FACTURAR_CAPITAL_EN_PAGOSColumnName; }
        }
        public static string FacturarInteresesEnPagos_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.FACTURAR_INTERESES_EN_PAGOSColumnName; }
        }
        public static string FacturarSoloIntereses_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.FACTURAR_SOLO_INTERESESColumnName; }
        }
        public static string FechaAprobacion_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.FECHA_APROBACIONColumnName; }
        }
        public static string FechaDesembolso_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.FECHA_DESEMBOLSOColumnName; }
        }
        public static string FechaSolicitud_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.FECHA_SOLICITUDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.IDColumnName; }
        }
        public static string InteresAnual_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.INTERES_ANUALColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.MONEDA_IDColumnName; }
        }
        public static string MontoCapital_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.MONTO_CAPITALColumnName; }
        }
        public static string MontoImpuesto_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.MONTO_IMPUESTOColumnName; }
        }
        public static string MontoInteres_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.MONTO_INTERESColumnName; }
        }
        public static string MontoTotal_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.MONTO_TOTALColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.OBSERVACIONColumnName; }
        }
        public static string PorcentajeDiarioMora_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.PORCENTAJE_DIARIO_MORAColumnName; }
        }
        public static string PorcentajeImpuesto_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.PORCENTAJE_IMPUESTOColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.PROVEEDOR_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.SUCURSAL_IDColumnName; }
        }
        public static string TipoCreditoId_NombreCol
        {
            get { return CREDITOS_PROVEEDORCollection.TIPO_CREDITO_IDColumnName; }
        }
        public static string VistaCantidadCuotas_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_INFO_COMPCollection.CANTIDAD_CUOTASColumnName; }
        }
        public static string VistaCasoRelacIngValEstado_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_INFO_COMPCollection.CASO_RELAC_ING_VAL_ESTADOColumnName; }
        }
        public static string VistaCasoRelacIngValFlujo_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_INFO_COMPCollection.CASO_RELAC_ING_VAL_FLUJOColumnName; }
        }
        public static string VistaEstadoId_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_INFO_COMPCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_INFO_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_INFO_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaProveedorRazonSocial_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_INFO_COMPCollection.PROVEEDOR_RAZON_SOCIALColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_INFO_COMPCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_INFO_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaTipoCreditoNombre_NombreCol
        {
            get { return CREDITOS_PROVEEDOR_INFO_COMPCollection.TIPO_CREDITO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
