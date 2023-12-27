using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using System.Collections;
using System.Collections.Generic;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CustodiaValoresService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.CUSTODIA_DE_VALORES;
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
                    CUSTODIA_VALORESRow cabeceraRow = sesion.Db.CUSTODIA_VALORESCollection.GetByCASO_ID(caso_id)[0];
                    DataTable dtDetalles = CustodiaValoresDetalleService.GetCustodiaValoresDetalleDataTable(CustodiaValoresDetalleService.CustodiaValorId_NombreCol + " = " + cabeceraRow.ID, string.Empty);

                    //Borrador a Anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Los detalles son borradas a fin de que los valores sean reintegrados
                        //a la caja de donde provinieron.
                        exito = true;
                        revisarRequisitos = true;

                        //Se borran los detalles
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            CustodiaValoresDetalleService.Borrar((decimal)dtDetalles.Rows[i][CustodiaValoresDetalleService.Id_NombreCol]);
                        }
                    }
                    //Borrador a Pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;

                        if (cabeceraRow.IsCTACTE_BANCARIA_IDNull)
                        {
                            foreach(DataRow row in dtDetalles.Rows)
                            {
                                if ((string)row[CustodiaValoresDetalleService.DepositoAutomatico_NombreCol] == Definiciones.SiNo.Si)
                                {
                                    exito = false;
                                    mensaje = "No se cargó una Cuenta Corriente Bancaria y al menos un detalle utiliza depósito automático.";
                                }
                            }
                        }

                        #region Se genera el numero de comprobante
                        if (exito && cabeceraRow.NRO_COMPROBANTE == null)
                        {
                            try
                            {
                                if (cabeceraRow.IsAUTONUMERACION_IDNull)
                                {
                                    exito = false;
                                    throw new Exception ("Debe seleccionar un " + Traducciones.Talonario);
                                }

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
                        #endregion Se genera el numero de comprobante
                    }
                    //Pendiente a Borrador 
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                    }
                    //Pendiente a Pre-aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.PreAprobado))
                    {
                        //Acciones:
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;

                        if (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Length == 0)
                        { 
                            mensaje = "El caso debe tener un número de comprobante.";
                            exito = false;
                        }
                    }
                    //Pre-aprobado a aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.PreAprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones:
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;

                        mensaje = "Solo el sistema puede utilizar la transición 'Pre-Aprobado' -> 'Aprobado'.";
                    }
                    //aprobado a cerrado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //ninguna.
                        exito = false;
                        revisarRequisitos = true;

                        mensaje = "Solo el sistema puede utilizar la transición 'Aprobado' -> 'Cerrado'.";
                    }

                    //Verificar si se cumplen los requisitos
                    if (exito && revisarRequisitos)
                    {
                        exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                    }

                    if (exito)
                    {
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.CUSTODIA_VALORESCollection.Update(cabeceraRow);
                    }
                }
                catch (Exception exp)
                {
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
            CUSTODIA_VALORESRow row = sesion.Db.CUSTODIA_VALORESCollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE.Equals(DBNull.Value) ? string.Empty : row.NRO_COMPROBANTE;
        }

        #endregion Implementacion de metodos abstract

        #region GetCustodiaValoresDataTable
        /// <summary>
        /// Gets the custodia valores data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCustodiaValoresDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CUSTODIA_VALORESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCustodiaValoresDataTable

        #region GetCustodiaValoresInfoCompleta
        /// <summary>
        /// Gets the custodia valores info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCustodiaValoresInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CUSTODIA_VALORES_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCustodiaValoresInfoCompleta

        #region ActualizarTotales
        public static void ActualizarTotales(decimal id, SessionService sesion)
        {
            string clausulas = CustodiaValoresDetalleService.CustodiaValorId_NombreCol + " = " + id;
            DataTable dtDetalles = CustodiaValoresDetalleService.GetCustodiaValoresDetalleDataTable(clausulas, string.Empty);

            decimal totalMontoDolares = 0;
            decimal totalCostoDolares = 0;
            foreach (DataRow fila in dtDetalles.Rows)
            {
                decimal cotizacion = (decimal)fila[CustodiaValoresDetalleService.CotizacionMoneda_NombreCol];
                
                decimal monto = (decimal)fila[CustodiaValoresDetalleService.Monto_NombreCol];
                totalMontoDolares += monto / cotizacion;

                decimal costo = (decimal)fila[CustodiaValoresDetalleService.Costo_NombreCol];
                totalCostoDolares += costo / cotizacion;
            }

            CUSTODIA_VALORESRow row = sesion.Db.CUSTODIA_VALORESCollection.GetByPrimaryKey(id);
            decimal costoAsociadoDolares = row.COSTO_ASOCIADO / row.COTIZACION_MONEDA;
            row.TOTAL_COSTO = (totalCostoDolares + costoAsociadoDolares) * row.COTIZACION_MONEDA;
            row.TOTAL_DOCUMENTOS = totalMontoDolares * row.COTIZACION_MONEDA;

            row.TOTAL_IMPUESTO = row.TOTAL_COSTO - row.TOTAL_COSTO / ((100 + row.PORCENTAJE_IMPUESTO) / 100);
            row.TOTAL_INTERES_ACORDADO = row.TOTAL_COSTO - row.TOTAL_COSTO / ((100 + row.PORCENTAJE_INTERES_ACORDADO) / 100);

            sesion.Db.CUSTODIA_VALORESCollection.Update(row);
        }
        #endregion ActualizarTotales

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id) {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                CUSTODIA_VALORESRow row = new CUSTODIA_VALORESRow();

                try
                {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[CustodiaValoresService.SucursalId_NombreCol].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.CUSTODIA_DE_VALORES.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("custodia_valores_sqc");
                        row.SUCURSAL_ID = (decimal)campos[CustodiaValoresService.SucursalId_NombreCol]; //Una vez creado el caso no puede cambiarse de sucursal
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.CUSTODIA_VALORESCollection.GetRow(CustodiaValoresService.Id_NombreCol + " = " + campos[CustodiaValoresService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    //Se controla al crear el caso que la sucursal este activa
                    if(insertarNuevo)
                    {
                        if(!SucursalesService.EstaActivo(row.SUCURSAL_ID))
                            throw new Exception("La sucursal no se encuentra activa.");
                    }

                    //Si cambia
                    if (row.CTACTE_BANCO_ID.Equals(DBNull.Value) || row.CTACTE_BANCO_ID != (decimal)campos[CustodiaValoresService.CtacteBancoId_NombreCol])
                    {
                        if (!CuentaCorrienteBancosService.EstaActivo((decimal)campos[CustodiaValoresService.CtacteBancoId_NombreCol]))
                            throw new Exception("El banco se encuentra inactivo");

                        row.CTACTE_BANCO_ID = (decimal)campos[CustodiaValoresService.CtacteBancoId_NombreCol];
                    }

                    //Si cambia
                    if (row.CTACTE_CAJA_TESORERIA_ID.Equals(DBNull.Value) || row.CTACTE_CAJA_TESORERIA_ID != (decimal)campos[CustodiaValoresService.CtacteCajaTesoreriaId_NombreCol])
                    {
                        if (!CuentaCorrienteCajasTesoreriaService.EstaActivo((decimal)campos[CustodiaValoresService.CtacteCajaTesoreriaId_NombreCol]))
                            throw new Exception("La caja de tesorería se encuentra inactiva");

                        row.CTACTE_CAJA_TESORERIA_ID = (decimal)campos[CustodiaValoresService.CtacteCajaTesoreriaId_NombreCol];
                    }

                    //Si cambia
                    if (row.MONEDA_ID.Equals(DBNull.Value) || row.MONEDA_ID != (decimal)campos[CustodiaValoresService.MonedaId_NombreCol])
                    {
                        row.MONEDA_ID = (decimal)campos[CustodiaValoresService.MonedaId_NombreCol];

                        //Se actualiza la cotizacion de la moneda
                        row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, row.FECHA, sesion);
                        if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("Debe actualizarse la cotización de la moneda destino.");
                    }

                    row.FECHA = (DateTime)campos[CustodiaValoresService.Fecha_NombreCol];
                    row.NRO_COMPROBANTE = (string)campos[CustodiaValoresService.NroComprobante_NombreCol];
                    row.OBSERVACION = (string)campos[CustodiaValoresService.Observacion_NombreCol];
                    row.PORCENTAJE_IMPUESTO = (decimal)campos[CustodiaValoresService.PorcentajeImpuesto_NombreCol];
                    row.PORCENTAJE_INTERES_ACORDADO = (decimal)campos[CustodiaValoresService.PorcentajeInteresAcordado_NombreCol];
                    row.TOTAL_COSTO = (decimal)campos[CustodiaValoresService.TotalCosto_NombreCol];

                    if (campos.Contains(CustodiaValoresService.CtaCteBancariaId_NombreCol))
                        row.CTACTE_BANCARIA_ID = (decimal)campos[CustodiaValoresService.CtaCteBancariaId_NombreCol];
                    else
                        row.IsCTACTE_BANCARIA_IDNull = true;

                    //Monto impuesto = Monto total / ((100 / porcentaje) + 1)
                    if (row.PORCENTAJE_IMPUESTO == 0)
                        row.TOTAL_IMPUESTO = 0;
                    else
                        row.TOTAL_IMPUESTO = row.TOTAL_COSTO / ((100 / row.PORCENTAJE_IMPUESTO) + 1);

                    //Monto interes = Monto total / ((100 / porcentaje) + 1)
                    if (row.PORCENTAJE_INTERES_ACORDADO == 0)
                        row.TOTAL_INTERES_ACORDADO = 0;
                    else
                        row.TOTAL_INTERES_ACORDADO = row.TOTAL_COSTO / ((100 / row.PORCENTAJE_INTERES_ACORDADO) + 1);

                    row.COSTO_ASOCIADO = (decimal)campos[CustodiaValoresService.CostoAsociado_NombreCol];
                    row.TOTAL_DOCUMENTOS = (decimal)campos[CustodiaValoresService.TotalDocumentos_NombreCol];
                    
                    if (campos.Contains(Autonumeracion_IDNombreCol))
                    {
                        row.AUTONUMERACION_ID = (decimal)campos[CambiosDivisaService.Autonumeracion_ID_NombreCol];
                    }
                    else
                    {
                        row.IsAUTONUMERACION_IDNull = true;
                    }

                    if (insertarNuevo) sesion.Db.CUSTODIA_VALORESCollection.Insert(row);
                    else sesion.Db.CUSTODIA_VALORESCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    ActualizarTotales(row.ID, sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
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
                    CUSTODIA_VALORESRow cabecera = sesion.Db.CUSTODIA_VALORESCollection.GetByCASO_ID(caso_id)[0];
                    DataTable dtDetalles;

                    if (! caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Se controla que el caso no tenga detalles
                    if (exito)
                    {
                        dtDetalles = CustodiaValoresDetalleService.GetCustodiaValoresDetalleDataTable(CustodiaValoresDetalleService.CustodiaValorId_NombreCol + " = " + cabecera.ID, string.Empty);
                        if(dtDetalles.Rows.Count > 0)
                        {
                            exito = false;
                            mensaje = "El caso no puede borrarse ya que posee detalles.";
                        }
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.CUSTODIA_VALORESCollection.DeleteByCASO_ID(caso_id);
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

        #region ConfirmarCanje
        /// <summary>
        /// Confirmars the canje.
        /// </summary>
        /// <param name="custodia_valor_id">The custodia_valor_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ConfirmarCanje(decimal custodia_valor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CustodiaValoresDetalleEntradaService.ConfirmarCanje(custodia_valor_id, sesion);
                    CustodiaValoresDetalleSalidaService.ConfirmarCanje(custodia_valor_id, sesion);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion ConfirmarCanje

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CUSTODIA_VALORES"; }
        }
        public static string CasoId_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.CASO_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string Autonumeracion_IDNombreCol
        {
            get { return CUSTODIA_VALORESCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CtacteBancoId_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.CTACTE_BANCO_IDColumnName; }
        }
        public static string CtacteCajaTesoreriaId_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.CTACTE_CAJA_TESORERIA_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.MONEDA_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.OBSERVACIONColumnName; }
        }
        public static string PorcentajeImpuesto_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.PORCENTAJE_IMPUESTOColumnName; }
        }
        public static string PorcentajeInteresAcordado_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.PORCENTAJE_INTERES_ACORDADOColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.SUCURSAL_IDColumnName; }
        }
        public static string TotalCosto_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.TOTAL_COSTOColumnName; }
        }
        public static string TotalImpuesto_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.TOTAL_IMPUESTOColumnName; }
        }
        public static string TotalInteresAcordado_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.TOTAL_INTERES_ACORDADOColumnName; }
        }
        public static string CtaCteBancariaId_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.CTACTE_BANCARIA_IDColumnName; }
        }
        public static string CostoAsociado_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.COSTO_ASOCIADOColumnName; }
        }
        public static string TotalDocumentos_NombreCol
        {
            get { return CUSTODIA_VALORESCollection.TOTAL_DOCUMENTOSColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return CUSTODIA_VALORES_INFO_COMPCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return CUSTODIA_VALORES_INFO_COMPCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CUSTODIA_VALORES_INFO_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaCtacteCajaTesoreriaAbrev_NombreCol
        {
            get { return CUSTODIA_VALORES_INFO_COMPCollection.CTACTE_CAJA_TESORERIA_ABREVColumnName; }
        }
        public static string VistaCtacteCajaTesoreriaNombre_NombreCol
        {
            get { return CUSTODIA_VALORES_INFO_COMPCollection.CTACTE_CAJA_TESORERIA_NOMBREColumnName; }
        }
        public static string VistaCtacteBancoAbreviatura_NombreCol
        {
            get { return CUSTODIA_VALORES_INFO_COMPCollection.CTACTE_BANCO_ABREVIATURAColumnName; }
        }
        public static string VistaCtacteBancoNombre_NombreCol
        {
            get { return CUSTODIA_VALORES_INFO_COMPCollection.CTACTE_BANCO_NOMBREColumnName; }
        }
        public static string VistaCtacteBancariaNroCuenta_NombreCol
        {
            get { return CUSTODIA_VALORES_INFO_COMPCollection.CTACTE_BANCARIA_NRO_CUENTAColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CUSTODIA_VALORES_INFO_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CUSTODIA_VALORES_INFO_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaOrdenPagoRespaldaCasoId_NombreCol
        {
            get { return CUSTODIA_VALORES_INFO_COMPCollection.ORDEN_PAGO_RESPALDA_CASO_IDColumnName; }
        }
        #endregion Accessors
    }
}
