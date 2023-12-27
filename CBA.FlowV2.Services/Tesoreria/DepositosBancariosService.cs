using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.Contabilidad;
using CBA.FlowV2.Framework.Common;
using CBA.FlowV2.Services.TextosPredefinidos;
using CBA.FlowV2.Services.Anticipo;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class DepositosBancariosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.DEPOSITO_BANCARIO;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var cabecera = (DepositosBancariosService)caso_cabecera;
            var detalle = (DepositosBancariosDetalleService)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);
            
            if (detalle.TextoPredefinidoId.HasValue)
                campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, detalle.TextoPredefinidoId);
            else
                campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, cabecera.TextoPredefinidoId);

            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, );
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
                DEPOSITOS_BANCARIOSRow cabeceraRow = sesion.Db.DEPOSITOS_BANCARIOSCollection.GetByCASO_ID(caso_id)[0];
                DepositosBancariosDetalleService depositoDetalle = new DepositosBancariosDetalleService();
                DataTable dtDetalles = DepositosBancariosDetalleService.GetDepositosBancariosDetalleInfoCompleta(DepositosBancariosDetalleService.DepositoBancarioId_NombreCol + " = " + cabeceraRow.ID, string.Empty, sesion);

                //Borrador a Anulado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Los valores son reintegrados a la caja de donde provinieron.
                    exito = true;
                    revisarRequisitos = true;

                    if (cabeceraRow.DEPOSITO_DESDE_SUC.Equals(Definiciones.SiNo.Si))
                    {
                        CuentaCorrienteCajaService ctacteCajaSucursalMov = new CuentaCorrienteCajaService();

                        //Se reingresa cada valor
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            ctacteCajaSucursalMov.DeshacerEgreso(Definiciones.FlujosIDs.DEPOSITO_BANCARIO, (decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.Id_NombreCol], sesion);
                        }
                    }
                    else
                    {
                        //Se reingresa cada valor
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.DEPOSITO_BANCARIO, string.Empty, (decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.Id_NombreCol], cabeceraRow.CASO_ID, sesion);
                        }
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

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    if (exito && dtDetalles.Rows.Count == 0)
                    {
                        exito = false;
                        mensaje = "El caso no tiene detalles";
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
                    //Los valores son reintegrados a la caja de donde provinieron.
                    exito = true;
                    revisarRequisitos = true;

                    if (cabeceraRow.DEPOSITO_DESDE_SUC.Equals(Definiciones.SiNo.Si))
                    {
                        CuentaCorrienteCajaService ctacteCajaSucursalMov = new CuentaCorrienteCajaService();

                        //Se reingresa cada valor
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            ctacteCajaSucursalMov.DeshacerEgreso(Definiciones.FlujosIDs.DEPOSITO_BANCARIO, (decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.Id_NombreCol], sesion);
                        }
                    }
                    else
                    {
                        //Se reingresa cada valor
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.DEPOSITO_BANCARIO, string.Empty, (decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.Id_NombreCol], cabeceraRow.CASO_ID, sesion);
                        }
                    }
                }
                //Pendiente a Pre-aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.PreAprobado))
                {
                    //Acciones:
                    //ninguna.
                    exito = true;
                    revisarRequisitos = true;

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado
                }
                // Pre-aprobado a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.PreAprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones:
                    //ninguna.
                    exito = true;
                    revisarRequisitos = true;

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado
                }
                //Pre-aprobado a aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.PreAprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones
                    //Los valores ingresan a la cuenta bancaria cuyo saldo se ve afectado.
                    exito = true;
                    revisarRequisitos = true;

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    //Debe haberse ingresado el numero de cupon
                    if (exito && GetStringHelper(cabeceraRow.NRO_COMPROBANTE).Length <= 0)
                    {
                        exito = false;
                        mensaje = "Debe ingresar el número de cupón";
                    }

                    if (exito)
                    {
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            string observacion = string.Empty;
                            decimal? ctacteChequeRecibidoId = null;

                            if ((decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.CtacteValorId_NombreCol] == Definiciones.CuentaCorrienteValores.Cheque)
                            {
                                observacion = dtDetalles.Rows[i][DepositosBancariosDetalleService.VistaCtacteBancoAbreviatura_NombreCol] + " Nº" +
                                              dtDetalles.Rows[i][DepositosBancariosDetalleService.VistaCtacteChequeRecibidoNum_NombreCol] +
                                              ". Depósito Bancario caso " + cabeceraRow.CASO_ID + " boleta " + cabeceraRow.NRO_COMPROBANTE;
                                ctacteChequeRecibidoId = (decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.CtacteChequeRecibidoId_NombreCol];
                                (new CuentaCorrienteChequesRecibidosService()).DepositadoPorDepositoBancario(ctacteChequeRecibidoId.Value, cabeceraRow.ID, sesion);
                            }
                            else
                            {
                                observacion = "Depósito Bancario caso " + cabeceraRow.CASO_ID + " boleta " + cabeceraRow.NRO_COMPROBANTE;
                            }

                            CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                cabeceraRow.CTACTE_BANCARIA_ID,
                                Definiciones.FlujosIDs.DEPOSITO_BANCARIO,
                                cabeceraRow.CASO_ID,
                                Definiciones.Error.Valor.EnteroPositivo,
                                cabeceraRow.ID,
                                CuentaCorrienteCuentasBancariasService.GetMoneda(cabeceraRow.CTACTE_BANCARIA_ID),
                                (decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.Importe_NombreCol],
                                cabeceraRow.COTIZACION_MONEDA,
                                cabeceraRow.FECHA,
                                observacion,
                                null,
                                ctacteChequeRecibidoId,
                                false,
                                sesion);
                        }
                        if (cabeceraRow.CREAR_ANTICIPO_PERSONA == Definiciones.SiNo.Si)
                        {
                            
                            string query = "";

                            query += "select * " + "\n";
                            
                            query += "from "+ Nombre_Tabla +" dp, " + "\n";
                            query += CuentaCorrienteCuentasBancariasService.Nombre_Tabla+" cb " + "\n";
                            query += "where dp." + CtacteBancariaId_NombreCol + " = cb." + CuentaCorrienteCuentasBancariasService.Id_NombreCol + "\n";
                            
                            query += "and dp."+Id_NombreCol+" = " + cabeceraRow.ID;

                            DataTable dtDeposito = sesion.db.EjecutarQuery(query);
                            
                            //DataTable dtDeposito = GetDepositosBancariosDataTable(Id_NombreCol + " = " + cabeceraRow.ID, string.Empty);
                            Hashtable campos = new Hashtable();

                            campos.Add(AnticiposPersonaService.SucursalId_NombreCol, sesion.Usuario.SUCURSAL_ACTIVA_ID);
                            campos.Add(AnticiposPersonaService.PersonaId_NombreCol, dtDeposito.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.PersonaId_NombreCol]);
                            campos.Add(AnticiposPersonaService.MonedaId_NombreCol, dtDeposito.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol]);
                            campos.Add(AnticiposPersonaService.FuncionarioCobradorId_NombreCol, dtDeposito.Rows[0][FuncionarioId_NombreCol]);
                            campos.Add(AnticiposPersonaService.Fecha_NombreCol, dtDeposito.Rows[0][Fecha_NombreCol]);
                            campos.Add(AnticiposPersonaService.Observacion_NombreCol, "Anticipo creado desde Deposito Bancario");
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
                            camposDetalle.Add(AnticiposPersonaDetalleService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.DepositoBancario);
                            camposDetalle.Add(AnticiposPersonaDetalleService.MonedaId_NombreCol, dtDeposito.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol]);
                            camposDetalle.Add(AnticiposPersonaDetalleService.Monto_NombreCol, dtDeposito.Rows[0][TotalImporte_NombreCol]);
                            camposDetalle.Add(AnticiposPersonaDetalleService.CotizacionMoneda_NombreCol, dtDeposito.Rows[0][CotizacionMoneda_NombreCol]);
                            camposDetalle.Add(AnticiposPersonaDetalleService.DepositoBancarioId_NombreCol, cabeceraRow.ID);
                            camposDetalle.Add(AnticiposPersonaDetalleService.DepositoFecha_NombreCol, dtDeposito.Rows[0][Fecha_NombreCol]);
                            camposDetalle.Add(AnticiposPersonaDetalleService.DepositoCtacteBancariasId_NombreCol, dtDeposito.Rows[0][CtacteBancariaId_NombreCol]);
                            camposDetalle.Add(AnticiposPersonaDetalleService.DepositoNroBoleta_NombreCol, dtDeposito.Rows[0][NroComprobante_NombreCol]);
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
                }
                //Aprobado a Pre-aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                         estado_destino.Equals(Definiciones.EstadosFlujos.PreAprobado))
                {
                    //Acciones
                    //Verificar que el deposito no fue utilizado en un pago de personas
                    //Los valores egresan de la cuenta bancaria.
                    exito = true;
                    revisarRequisitos = true;

                    string clausulas;

                    #region Verificar que el deposito no fue utilizado en un pago de personas
                    clausulas = "select c." + CasosService.Id_NombreCol + " from " + Anticipo.AnticiposPersonaService.Nombre_Tabla + " ap," + Anticipo.AnticiposPersonaDetalleService.Nombre_Tabla + " apd, " + CasosService.Nombre_Tabla + " c " +
                                   " where apd." + Anticipo.AnticiposPersonaDetalleService.DepositoBancarioId_NombreCol + " = " + cabeceraRow.ID +
                                   "   and apd." + Anticipo.AnticiposPersonaDetalleService.AnticipoPersonaId_NombreCol + " = ap." + Anticipo.AnticiposPersonaService.Id_NombreCol +
                                   "   and ap." + Anticipo.AnticiposPersonaService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol +
                                   "   and c." + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' " +
                                   "   and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                                   " union " +
                                   "select c." + CasosService.Id_NombreCol + " from " + CuentaCorrientePagosPersonaDetalleService.Nombre_Tabla + " ccpd," + PagosDePersonaService.Nombre_Tabla + " ccp, " + CasosService.Nombre_Tabla + " c " +
                                   " where ccpd." + CuentaCorrientePagosPersonaDetalleService.DepositoBancarioId_NombreCol + " = " + cabeceraRow.ID +
                                   "   and ccpd." + CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol + " = ccp." + PagosDePersonaService.Id_NombreCol +
                                   "   and ccp." + PagosDePersonaService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol +
                                   "   and c." + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' " +
                                   "   and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                                   " union " +
                                   "select c." + CasosService.Id_NombreCol + " from " + DescuentoDocumentosPagosService.Nombre_Tabla + " ddp," + DescuentoDocumentosService.Nombre_Tabla + " dd, " + CasosService.Nombre_Tabla + " c " +
                                   " where ddp." + DescuentoDocumentosPagosService.DepositoBancarioId_NombreCol + " = " + cabeceraRow.ID +
                                   "   and ddp." + DescuentoDocumentosPagosService.DescuentoDocumentoId_NombreCol + " = dd." + DescuentoDocumentosService.Id_NombreCol +
                                   "   and dd." + DescuentoDocumentosService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol +
                                   "   and c." + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' " +
                                   "   and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                                   " union " +
                                   "select c." + CasosService.Id_NombreCol + " from " + Giros.DesembolsosGirosService.Nombre_Tabla + " dg," + CasosService.Nombre_Tabla + " c " +
                                   " where dg." + Giros.DesembolsosGirosService.DepositoBancarioId_NombreCol + " = " + cabeceraRow.ID +
                                   "   and dg." + Giros.DesembolsosGirosService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol +
                                   "   and c." + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' " +
                                   "   and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                    DataTable dt = sesion.db.EjecutarQuery(clausulas);
                    if (dt.Rows.Count > 0)
                        throw new Exception("El Depósito Bancario caso " + cabeceraRow.CASO_ID + " está siendo utilizado en el caso " + dt.Rows[0][CasosService.Id_NombreCol] + ".");
                    #endregion Verificar que el deposito no fue utilizado en un pago de personas

                    if (exito)
                    {
                        string observacion = "Depósito Bancario caso " + cabeceraRow.CASO_ID + " boleta " + cabeceraRow.NRO_COMPROBANTE + " pasado de " + casoRow.ESTADO_ID + " a " + estado_destino + ".";
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            decimal? ctacteChequeRecibidoId = null;

                            if ((decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.CtacteValorId_NombreCol] == Definiciones.CuentaCorrienteValores.Cheque)
                            {
                                ctacteChequeRecibidoId = (decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.CtacteChequeRecibidoId_NombreCol];
                                (new CuentaCorrienteChequesRecibidosService()).DeshacerParaDepositoPorDepositoBancario(ctacteChequeRecibidoId.Value, sesion);
                            }

                            CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                cabeceraRow.CTACTE_BANCARIA_ID,
                                Definiciones.FlujosIDs.DEPOSITO_BANCARIO,
                                cabeceraRow.CASO_ID,
                                Definiciones.Error.Valor.EnteroPositivo,
                                cabeceraRow.ID,
                                CuentaCorrienteCuentasBancariasService.GetMoneda(cabeceraRow.CTACTE_BANCARIA_ID),
                                (decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.Importe_NombreCol] * (-1),
                                cabeceraRow.COTIZACION_MONEDA,
                                cabeceraRow.FECHA,
                                observacion,
                                null,
                                ctacteChequeRecibidoId,
                                true,
                                sesion);
                        }

                        //Borrar el asiento que se creo
                        CBA.FlowV2.Services.Contabilidad.AsientosService.BorrarPorCasoYTransicion(
                            cabeceraRow.CASO_ID,
                            TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.DEPOSITO_BANCARIO, Definiciones.EstadosFlujos.PreAprobado, Definiciones.EstadosFlujos.Aprobado, sesion),
                            sesion);
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
                    sesion.Db.DEPOSITOS_BANCARIOSCollection.Update(cabeceraRow);
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

        #region GetDepositosBancariosDataTable

        public static DataTable GetDepositosBancariosDataTable(string clausulas, string orden, SessionService sesion)
        {
            
                return sesion.Db.DEPOSITOS_BANCARIOSCollection.GetAsDataTable(clausulas, orden);
            
        }
        /// <summary>
        /// Gets the depositos bancarios data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetDepositosBancariosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DEPOSITOS_BANCARIOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetDepositosBancariosDataTable

        #region GetDepositosBancariosInfoCompleta
        [Obsolete("utilizar métodos estáticos")]
        /// <summary>
        /// Gets the depositos bancarios info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        /// 

        public static DataTable GetDepositosBancariosParaFlujos(decimal sucursal_id, decimal moneda_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = DepositosBancariosService.SucursalId_NombreCol + " = " + sucursal_id + " and " +
                                   DepositosBancariosService.VistaMonedaId_NombreCol + " = " + moneda_id + " and " +
                                   DepositosBancariosService.VistaCasoEstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Aprobado + "'";

                return sesion.Db.DEPOSITOS_BANCARIOS_INFO_COMPLCollection.GetAsDataTable(clausulas, DepositosBancariosService.Fecha_NombreCol);
            }
        }

        /// <summary>
        /// Gets the depositos bancarios info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetDepositosBancariosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetDepositosBancariosInfoCompleta(clausulas, orden, sesion);
            }
        }    

        public static DataTable GetDepositosBancariosInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.DEPOSITOS_BANCARIOS_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        }

        public static DataTable GetDepositosBancariosInfoCompleta2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetDepositosBancariosInfoCompleta2(clausulas, orden, sesion);
            }
        }

        public static DataTable GetDepositosBancariosInfoCompleta2(string clausulas, string orden, SessionService sesion)
        {
            string query = "";
            query += "select db." + DepositosBancariosService.Id_NombreCol + ", " + "\n";
            query += "       db." + DepositosBancariosService.CasoId_NombreCol + ", " + "\n";
            query += "       db." + DepositosBancariosService.IncluyePersona_NombreCol + ", " + "\n";
            query += "       db." + DepositosBancariosService.PersonaId_NombreCol + ", " + "\n";
            query += "       c." + CasosService.EstadoId_NombreCol + " caso_estado_id, " + "\n";
            query += "       db." + DepositosBancariosService.SucursalId_NombreCol + ", " + "\n";
            query += "       s." + SucursalesService.Nombre_NombreCol + " sucursal_nombre, " + "\n";
            query += "       s." + SucursalesService.Abreviatura_NombreCol + " sucursal_abreviatura, " + "\n";
            query += "       db." + DepositosBancariosService.FuncionarioId_NombreCol + ", " + "\n";
            query += "       f." + FuncionariosService.Nombre_NombreCol + " || ' ' || f." + FuncionariosService.Apellido_NombreCol + " funcionario_nombre_completo, " + "\n";
            query += "       db." + DepositosBancariosService.Fecha_NombreCol + ", " + "\n";
            query += "       db." + DepositosBancariosService.DepositoDesdeSuc_NombreCol + ", " + "\n";
            query += "       cbca." + CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol + ", " + "\n";
            query += "       m." + MonedasService.Modelo.NOMBREColumnName + " moneda_nombre, " + "\n";
            query += "       m." + MonedasService.Modelo.CADENA_DECIMALESColumnName + " moneda_cadena_decimales, " + "\n";
            query += "       m." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName + " moneda_cantidades_decimales, " + "\n";
            query += "       db." + DepositosBancariosService.CotizacionMoneda_NombreCol + ", " + "\n";
            query += "       cbca." + CuentaCorrienteCuentasBancariasService.CtacteBancoId_NombreCol + ", " + "\n";
            query += "       cbco." + CuentaCorrienteBancosService.RazonSocial_NombreCol + " ctacte_banco_nombre, " + "\n";
            query += "       cbco." + CuentaCorrienteBancosService.Abreviatura_NombreCol + " ctacte_banco_abreviatura, " + "\n";
            query += "       db." + DepositosBancariosService.CtacteBancariaId_NombreCol + ", " + "\n";
            query += "       cbca." + CuentaCorrienteCuentasBancariasService.NumeroCuenta_NombreCol + ", " + "\n";
            query += "       db." + DepositosBancariosService.CtacteCajaTesoreriaId_NombreCol + ", " + "\n";
            query += "       cct." + CuentaCorrienteCajasTesoreriaService.Nombre_NombreCol + " ctacte_caja_tesoreria_nombre, " + "\n";
            query += "       cct." + CuentaCorrienteCajasTesoreriaService.Abreviatura_NombreCol + " ctacte_caja_teso_abreviatura, " + "\n";
            query += "       db." + DepositosBancariosService.CtacteCajaSucursalId_NombreCol + ", " + "\n";
            query += "       fccs." + FuncionariosService.Nombre_NombreCol + " || ' ' || fccs." + FuncionariosService.Apellido_NombreCol + " ctacte_caja_suc_func_nombre, " + "\n";
            query += "       ccs." + CuentaCorrienteCajasSucursalService.Modelo.NRO_COMPROBANTEColumnName + " ctacte_caja_suc_nro_comp, " + "\n";
            query += "       ccs." + CuentaCorrienteCajasSucursalService.Modelo.FECHA_INICIOColumnName + " ctacte_caja_suc_fecha_ini, " + "\n";
            query += "       ccs." + CuentaCorrienteCajasSucursalService.Modelo.FECHA_FINColumnName + " ctacte_caja_suc_fecha_fin, " + "\n";
            query += "       db." + DepositosBancariosService.NroComprobante_NombreCol + ", " + "\n";
            query += "       db." + DepositosBancariosService.TotalEfectivo_NombreCol + ", " + "\n";
            query += "       db." + DepositosBancariosService.TotalChequeMismoBanco_NombreCol + ", " + "\n";
            query += "       db." + DepositosBancariosService.TotalChequeOtroBanco_NombreCol + ", " + "\n";
            query += "       db." + DepositosBancariosService.TotalImporte_NombreCol + ", " + "\n";
            query += "       db." + DepositosBancariosService.Observacion_NombreCol + ", " + "\n";
            query += "       db." + DepositosBancariosService.TextoPredefinidoId_NombreCol + ", " + "\n";
            query += "       db." + DepositosBancariosService.IncluyePersona_NombreCol + ", " + "\n";
            query += "       tp." + TextosPredefinidosService.Texto_NombreCol + " texto_predefinido_nombre, " + "\n";
            query += "       p." + PersonasService.NombreCompleto_NombreCol + " persona_nombre_completo \n"; 
            query += "  from " + DepositosBancariosService.Nombre_Tabla + " db, " + "\n";
            query += "       " + SucursalesService.Nombre_Tabla + " s, " + "\n";
            query += "       " + FuncionariosService.Nombre_Tabla + " f, " + "\n";
            query += "       " + CuentaCorrienteCuentasBancariasService.Nombre_Tabla + " cbca, " + "\n";
            query += "       " + CuentaCorrienteBancosService.Nombre_Tabla + " cbco, " + "\n";
            query += "       " + CasosService.Nombre_Tabla + " c, " + "\n";
            query += "       " + CuentaCorrienteCajasSucursalService.Nombre_Tabla + " ccs, " + "\n";
            query += "       " + FuncionariosService.Nombre_Tabla + " fccs, \n";   
            query += "       " + CuentaCorrienteCajasTesoreriaService.Nombre_Tabla + " cct, " + "\n";
            query += "       " + TextosPredefinidosService.Nombre_Tabla + " tp, " + "\n";
            query += "       " + MonedasService.Nombre_Tabla + " m, " + "\n";
            query += "       " + PersonasService.Nombre_Tabla + " p " + "\n";
            query += "  where db." + DepositosBancariosService.SucursalId_NombreCol + " = s." + SucursalesService.Id_NombreCol + " " + "\n";
            query += "    and db." + DepositosBancariosService.FuncionarioId_NombreCol + " = f." + FuncionariosService.Id_NombreCol + " " + "\n";
            query += "    and db." + DepositosBancariosService.CtacteBancariaId_NombreCol + " = cbca." + CuentaCorrienteCuentasBancariasService.Id_NombreCol + " " + "\n";
            query += "    and cbca." + CuentaCorrienteCuentasBancariasService.CtacteBancoId_NombreCol + " = cbco." + CuentaCorrienteBancosService.Id_NombreCol + "\n";
            query += "    and cbca." + CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol + " = m." + MonedasService.Modelo.IDColumnName + " " + "\n";
            query += "    and db." + DepositosBancariosService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " " + "\n";
            query += "    and db." + DepositosBancariosService.CtacteCajaTesoreriaId_NombreCol + " = cct." + CuentaCorrienteCajasTesoreriaService.Id_NombreCol + "(+) " + "\n";
            query += "    and db." + DepositosBancariosService.CtacteCajaSucursalId_NombreCol + " = ccs.id(+) " + "\n";
            query += "    and ccs." + CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol + " = fccs." + FuncionariosService.Id_NombreCol + "(+) \n";
            query += "    and db." + DepositosBancariosService.TextoPredefinidoId_NombreCol + " = tp." + TextosPredefinidosService.Id_NombreCol + "(+) \n";
            query += "    and db." + DepositosBancariosService.PersonaId_NombreCol + " = p." + PersonasService.Id_NombreCol + "(+) \n";  


            if (clausulas != string.Empty)
                query += " and " + clausulas;

            return sesion.Db.EjecutarQuery(query);
        }
        #endregion GetDepositosBancariosInfoCompleta

        #region GetDepositosBancariosPorCaso
        /// <summary>
        /// Gets the depositos bancarios por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetDepositosBancariosPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DEPOSITOS_BANCARIOSCollection.GetAsDataTable(DepositosBancariosService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetDepositosBancariosPorCaso

        #region VerificarPuedeAvanzarEstado
        public static bool VerificarPuedeAvanzarEstado(decimal caso_id, out string mensaje, SessionService sesion)
        {
            return FlujosService.VerificarPuedeAvanzarEstado(caso_id, out mensaje, "DEPOSITOS BANCARIOS NO CONTROLAR MARGEN DIAS PUEDE AVANZAR", Definiciones.VariablesDeSistema.DepositoBancarioMargenDiasPuedeAvanzar, sesion);
        }
        #endregion VerificarPuedeAvanzarEstado

        #region CalcularTotales
        public void CalcularTotales(decimal deposito_bancario_id, SessionService sesion)
        {
            DataTable dtDepositoBancarioDet = DepositosBancariosDetalleService.GetDepositosBancariosDetalleDataTable(DepositosBancariosDetalleService.DepositoBancarioId_NombreCol + " = " + deposito_bancario_id, string.Empty, sesion);
            DEPOSITOS_BANCARIOSRow row = sesion.Db.DEPOSITOS_BANCARIOSCollection.GetByPrimaryKey(deposito_bancario_id);
            DataTable dtCtacteBancaria = CuentaCorrienteCuentasBancariasService.GetCuentaCorrienteBancariasDataTableTodo(CuentaCorrienteCuentasBancariasService.Id_NombreCol + " = " + row.CTACTE_BANCARIA_ID, string.Empty, false);
            string valorAnterior = row.ToString();

            row.TOTAL_CHEQUE_MISMO_BANCO = 0;
            row.TOTAL_CHEQUE_OTRO_BANCO = 0;
            row.TOTAL_EFECTIVO = 0;
            row.TOTAL_IMPORTE = 0;

            for (int i = 0; i < dtDepositoBancarioDet.Rows.Count; i++)
            {
                //Si es efectivo
                if ((decimal)dtDepositoBancarioDet.Rows[i][DepositosBancariosDetalleService.CtacteValorId_NombreCol] == Definiciones.CuentaCorrienteValores.Efectivo)
                {
                    //Se suma al total en efectivo
                    row.TOTAL_EFECTIVO += (decimal)dtDepositoBancarioDet.Rows[i][DepositosBancariosDetalleService.Importe_NombreCol];
                }
                //Si es cheque
                else if ((decimal)dtDepositoBancarioDet.Rows[i][DepositosBancariosDetalleService.CtacteValorId_NombreCol] == Definiciones.CuentaCorrienteValores.Cheque)
                {
                    DataTable dtCtacteCheque = CuentaCorrienteChequesRecibidosService.GetDataTable(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + dtDepositoBancarioDet.Rows[i][DepositosBancariosDetalleService.CtacteChequeRecibidoId_NombreCol], string.Empty, sesion);

                    //Si el cheque es del mismo banco que la cuenta bancaria donde se deposita
                    if (dtCtacteCheque.Rows[0][CuentaCorrienteChequesRecibidosService.CtacteBancoId_NombreCol] == dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.CtacteBancoId_NombreCol])
                    {
                        //Se suma al total de cheques del mismo banco
                        row.TOTAL_CHEQUE_MISMO_BANCO += (decimal)dtDepositoBancarioDet.Rows[i][DepositosBancariosDetalleService.Importe_NombreCol];
                    }
                    else
                    {
                        //Se suma al total de cheques de otros bancos
                        row.TOTAL_CHEQUE_OTRO_BANCO += (decimal)dtDepositoBancarioDet.Rows[i][DepositosBancariosDetalleService.Importe_NombreCol];
                    }
                }
                else   if ((decimal)dtDepositoBancarioDet.Rows[i][DepositosBancariosDetalleService.CtacteValorId_NombreCol] == Definiciones.CuentaCorrienteValores.POS)
                {
                    //Se suma al total en efectivo

                    row.TOTAL_EFECTIVO += (decimal)dtDepositoBancarioDet.Rows[i][DepositosBancariosDetalleService.Importe_NombreCol];
                }
                else
                {
                    throw new Exception("DepositosBancariosService.CalcularTotales. Tipo de valor no implementado.");
                }
            }

            row.TOTAL_IMPORTE = row.TOTAL_CHEQUE_MISMO_BANCO + row.TOTAL_CHEQUE_OTRO_BANCO + row.TOTAL_EFECTIVO;

            sesion.Db.DEPOSITOS_BANCARIOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion CalcularTotales

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                bool exito = Guardar(campos, insertarNuevo, ref caso_id, ref estado_id, sesion);
                return exito;
            }
        }

        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id, SessionService sesion)
        {
            
                bool exito = false;

                DEPOSITOS_BANCARIOSRow row = new DEPOSITOS_BANCARIOSRow();

                try
                {
                    DataTable dtCtaBancaria, dtCajaSucursal, dtCajaTesoreria;

                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[DepositosBancariosService.SucursalId_NombreCol].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.DEPOSITO_BANCARIO.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("depositos_bancarios_sqc");
                        row.SUCURSAL_ID = (decimal)campos[DepositosBancariosService.SucursalId_NombreCol]; //Una vez creado el caso no puede cambiarse de sucursal
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.DEPOSITOS_BANCARIOSCollection.GetRow(DepositosBancariosService.Id_NombreCol + " = " + campos[DepositosBancariosService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    //Se controla al crear el caso que la sucursal este activa
                    if (insertarNuevo)
                    {
                        if (!SucursalesService.EstaActivo(row.SUCURSAL_ID))
                            throw new Exception("La sucursal no se encuentra activa.");
                    }

                    row.FECHA = (DateTime)campos[DepositosBancariosService.Fecha_NombreCol];

                    if (campos.Contains(DepositosBancariosService.TextoPredefinidoId_NombreCol))
                    {
                        row.TEXTO_PREDEFINIDO_ID = (decimal)campos[DepositosBancariosService.TextoPredefinidoId_NombreCol];
                        if ((decimal)campos[DepositosBancariosService.TextoPredefinidoId_NombreCol] == VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.IdConceptoProcTarjDepoBanc))
                            row.NRO_COMPROBANTE = row.CASO_ID.ToString();
                        else
                            row.IsTEXTO_PREDEFINIDO_IDNull = true;
                    }

                    if (campos.Contains(DepositosBancariosService.PersonaId_NombreCol))
                    {
                        row.PERSONA_ID = (decimal)campos[DepositosBancariosService.PersonaId_NombreCol];
                        row.INCLUYE_PERSONA = Definiciones.SiNo.Si;
                    }
                    else
                        row.INCLUYE_PERSONA = Definiciones.SiNo.No;
                    row.CREAR_ANTICIPO_PERSONA = campos[CrearAnticipoPersona_NombreCol].ToString();
                    //Si cambia la cuenta bancaria
                    if (row.CTACTE_BANCARIA_ID.Equals(DBNull.Value) || row.CTACTE_BANCARIA_ID != (decimal)campos[DepositosBancariosService.CtacteBancariaId_NombreCol])
                    {
                        if (!CuentaCorrienteCuentasBancariasService.EstaActivo((decimal)campos[DepositosBancariosService.CtacteBancariaId_NombreCol]))
                            throw new Exception("La cuenta bancaria no se encuentra activa");

                        row.CTACTE_BANCARIA_ID = (decimal)campos[DepositosBancariosService.CtacteBancariaId_NombreCol];

                        dtCtaBancaria = CuentaCorrienteCuentasBancariasService.GetCuentaCorrienteBancariasDataTableTodo(CuentaCorrienteCuentasBancariasService.Id_NombreCol + " = " + row.CTACTE_BANCARIA_ID, string.Empty, false);

                        //Se actualiza la cotizacion de la moneda
                        row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(CuentaCorrienteBancosService.GetPais((decimal)dtCtaBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.CtacteBancoId_NombreCol]), (decimal)dtCtaBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol], row.FECHA, sesion);
                        if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("Debe actualizarse la cotización de la moneda destino.");
                    }

                    //La caja de tesoreria o sucursal no pueden cambiar en estado PreAprobado, Aprobado ni Anulado
                    string casoEstadoId = CasosService.GetEstadoCaso(row.CASO_ID, sesion);
                    if (casoEstadoId != Definiciones.EstadosFlujos.PreAprobado && casoEstadoId != Definiciones.EstadosFlujos.Aprobado && casoEstadoId != Definiciones.EstadosFlujos.Anulado)
                    {
                        #region guardar caja de sucursal o tesoreria
                        //Segun se deposite desde una caja de sucursal cerrada o de tesoreria
                        row.DEPOSITO_DESDE_SUC = (string)campos[DepositosBancariosService.DepositoDesdeSuc_NombreCol];
                        if (row.DEPOSITO_DESDE_SUC.Equals(Definiciones.SiNo.Si))
                        {
                            row.IsCTACTE_CAJA_TESORERIA_IDNull = true;

                            if (!campos.Contains(DepositosBancariosService.CtacteCajaSucursalId_NombreCol))
                                throw new Exception("Debe indicar la caja de sucursal de donde se tomarán los valores.");

                            //Si cambia
                            if (row.IsCTACTE_CAJA_SUCURSAL_IDNull || row.CTACTE_CAJA_SUCURSAL_ID != (decimal)campos[DepositosBancariosService.CtacteCajaSucursalId_NombreCol])
                            {
                                //Se obtiene la caja de sucursal
                                dtCajaSucursal = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalDataTable2(CuentaCorrienteCajasSucursalService.Id_NombreCol + " = " + campos[DepositosBancariosService.CtacteCajaSucursalId_NombreCol], string.Empty);

                                //Se verifica que la caja este Cerrada o abierta, pero no remitida o aceptada
                                if (!dtCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol].Equals(Definiciones.CuentaCorrienteCajaSucursalEstados.Abierta) &&
                                   !dtCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.CtacteCajaSucursalEstadoId_NombreCol].Equals(Definiciones.CuentaCorrienteCajaSucursalEstados.Cerrada))
                                {
                                    throw new Exception("La caja de sucursal seleccionada debe estar abierta o cerrada y aun no remitida a tesorería.");
                                }

                                //Se asigna la nueva caja de sucursal
                                row.CTACTE_CAJA_SUCURSAL_ID = (decimal)dtCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.Id_NombreCol];
                            }
                        }
                        else
                        {
                            row.IsCTACTE_CAJA_SUCURSAL_IDNull = true;

                            if (!campos.Contains(DepositosBancariosService.CtacteCajaTesoreriaId_NombreCol))
                                throw new Exception("Debe indicar la caja de tesorería de donde se tomarán los valores.");

                            //Si cambia
                            if (row.IsCTACTE_CAJA_TESORERIA_IDNull || row.CTACTE_CAJA_TESORERIA_ID != (decimal)campos[DepositosBancariosService.CtacteCajaTesoreriaId_NombreCol])
                            {
                                //Se obtiene la caja de tesoreria
                                dtCajaTesoreria = CuentaCorrienteCajasTesoreriaService.GetCuentaCorrienteCajasTesoreriaDataTable(CuentaCorrienteCajasTesoreriaService.Id_NombreCol + " = " + campos[DepositosBancariosService.CtacteCajaTesoreriaId_NombreCol], string.Empty);

                                //Se verifica que la caja este activa
                                if (dtCajaTesoreria.Rows[0][CuentaCorrienteCajasTesoreriaService.Estado_NombreCol].Equals(Definiciones.Estado.Inactivo))
                                    throw new Exception("La caja de tesorería no se encuentra activa.");

                                //Se asigna la nueva caja de sucursal
                                row.CTACTE_CAJA_TESORERIA_ID = (decimal)dtCajaTesoreria.Rows[0][CuentaCorrienteCajasTesoreriaService.Id_NombreCol];
                            }
                        }
                        #endregion guardar caja de sucursal o tesoreria
                    }

                    //Si cambia
                    if (row.FUNCIONARIO_ID.Equals(DBNull.Value) || row.FUNCIONARIO_ID != (decimal)campos[DepositosBancariosService.FuncionarioId_NombreCol])
                    {
                        if (!FuncionariosService.EstaActivo((decimal)campos[DepositosBancariosService.FuncionarioId_NombreCol]))
                            throw new Exception("El funcionario no se encuentra activo.");

                        row.FUNCIONARIO_ID = (decimal)campos[DepositosBancariosService.FuncionarioId_NombreCol];
                    }

                    //Verificar el número de comprobante
                    if (!campos[DepositosBancariosService.NroComprobante_NombreCol].ToString().Equals(string.Empty))
                    {
                        DataTable dt;
                        if (insertarNuevo)
                            dt = sesion.Db.DEPOSITOS_BANCARIOS_INFO_COMPLCollection.GetAsDataTable(DepositosBancariosService.CtacteBancariaId_NombreCol + " = " + campos[DepositosBancariosService.CtacteBancariaId_NombreCol] + " and " + DepositosBancariosService.NroComprobante_NombreCol + " = '" + campos[DepositosBancariosService.NroComprobante_NombreCol] + "' and " + DepositosBancariosService.VistaCasoEstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' ", string.Empty);
                        else
                            dt = sesion.Db.DEPOSITOS_BANCARIOS_INFO_COMPLCollection.GetAsDataTable(DepositosBancariosService.CtacteBancariaId_NombreCol + " = " + campos[DepositosBancariosService.CtacteBancariaId_NombreCol] + " and " + DepositosBancariosService.NroComprobante_NombreCol + " = '" + campos[DepositosBancariosService.NroComprobante_NombreCol] + "' and " + DepositosBancariosService.Id_NombreCol + " <> " + campos[DepositosBancariosService.Id_NombreCol].ToString() + " and " + DepositosBancariosService.VistaCasoEstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' ", string.Empty);

                        if (dt.Rows.Count > 0)
                            throw new Exception("El número de cupón ya ha sido utilizado.");
                        else
                            row.NRO_COMPROBANTE = (string)campos[DepositosBancariosService.NroComprobante_NombreCol];
                    }

                    row.OBSERVACION = (string)campos[DepositosBancariosService.Observacion_NombreCol];

                    // Se verifica si los cambios son en el estado APROBADO
                    if (!insertarNuevo)
                    {
                        string casoEstado = CasosService.GetEstadoCaso(row.CASO_ID, sesion);
                        DataTable dtDepositoBancario = DepositosBancariosService.GetDepositosBancariosDataTable(DepositosBancariosService.Id_NombreCol + " = " + row.ID, string.Empty);
                        if (casoEstado.Equals(Definiciones.EstadosFlujos.Aprobado))
                        {
                            //Si cambia la fecha, actualizar en ctacte_bancarias_mov
                            if ((DateTime)dtDepositoBancario.Rows[0][DepositosBancariosService.Fecha_NombreCol] != (DateTime)campos[DepositosBancariosService.Fecha_NombreCol])
                            {
                                var ctacteBancariaMov = CuentaCorrienteCuentasBancariasMovimientosService.Instancia.GetFiltrado<CuentaCorrienteCuentasBancariasMovimientosService>(new Filtro[]
                                {
                                    new Filtro { Columna = CuentaCorrienteCuentasBancariasMovimientosService.Modelo.CASO_IDColumnName, Valor = row.CASO_ID}
                                });

                                foreach (var mov in ctacteBancariaMov)
                                {
                                    mov.IniciarUsingSesion(sesion);
                                    mov.Fecha = row.FECHA;
                                    mov.Guardar();
                                    mov.FinalizarUsingSesion();
                                }
                            }

                            // Si la cuenta bancaria se cambia en el estado aprobado, se debe deshacer el movimiento bancario anterior, y rehacerlo con la nueva cuenta bancaria
                            if ((decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.CtacteBancariaId_NombreCol] != (decimal)campos[DepositosBancariosService.CtacteBancariaId_NombreCol])
                            {
                                // Si la moneda de la cuenta bancaria anterior es distinta a la moneda de la cuenta bancaria nueva, se lanza una excepcion
                                if (!CuentaCorrienteCuentasBancariasService.GetMoneda((decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.CtacteBancariaId_NombreCol]).Equals(CuentaCorrienteCuentasBancariasService.GetMoneda((decimal)campos[DepositosBancariosService.CtacteBancariaId_NombreCol])))
                                {
                                    throw new Exception("No se puede cambiar la cuenta bancaria a una con distinta moneda en el estado APROBADO.");
                                }

                                // Se corrige la cuenta bancaria
                                decimal ctaBancariaOriginal = (decimal)dtDepositoBancario.Rows[0][DepositosBancariosService.CtacteBancariaId_NombreCol];
                                row.CTACTE_BANCARIA_ID = (decimal)campos[DepositosBancariosService.CtacteBancariaId_NombreCol];

                                // Se deshace el movimiento bancario realizado al haber aprobado el caso anteriormente
                                DataTable dtDetalles = DepositosBancariosDetalleService.GetDepositosBancariosDetalleInfoCompleta(DepositosBancariosDetalleService.DepositoBancarioId_NombreCol + " = " + row.ID, string.Empty);
                                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                                {
                                    string observacion = string.Empty;
                                    decimal? ctacteChequeRecibidoId = null;

                                    if ((decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.CtacteValorId_NombreCol] == Definiciones.CuentaCorrienteValores.Cheque)
                                    {
                                        observacion = dtDetalles.Rows[i][DepositosBancariosDetalleService.VistaCtacteBancoAbreviatura_NombreCol] + " Nº" +
                                                      dtDetalles.Rows[i][DepositosBancariosDetalleService.VistaCtacteChequeRecibidoNum_NombreCol] +
                                                      ". Correción en depósito bancario caso " + row.CASO_ID + " boleta " + row.NRO_COMPROBANTE;
                                        ctacteChequeRecibidoId = (decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.CtacteChequeRecibidoId_NombreCol];
                                        // No es necesario hacer nada con el cheque recibido, porque el mismo sigue apuntando a este caso de Deposito Bancario
                                    }
                                    else
                                    {
                                        observacion = "Corrección en depósito bancario caso " + row.CASO_ID + " boleta " + row.NRO_COMPROBANTE;
                                    }

                                    CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                        ctaBancariaOriginal,
                                        Definiciones.FlujosIDs.DEPOSITO_BANCARIO,
                                        row.CASO_ID,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        row.ID,
                                        CuentaCorrienteCuentasBancariasService.GetMoneda(ctaBancariaOriginal),
                                        (decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.Importe_NombreCol] * -1, // Debe ser negativo porq es Egreso
                                        row.COTIZACION_MONEDA,
                                        row.FECHA,
                                        observacion,
                                        null,
                                        ctacteChequeRecibidoId,
                                        true,
                                        sesion);
                                }

                                // Se hace nuevo movimiento bancario con la cuenta bancaria nueva
                                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                                {
                                    string observacion = string.Empty;
                                    decimal? ctacteChequeRecibidoId = null;

                                    if ((decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.CtacteValorId_NombreCol] == Definiciones.CuentaCorrienteValores.Cheque)
                                    {
                                        observacion = dtDetalles.Rows[i][DepositosBancariosDetalleService.VistaCtacteBancoAbreviatura_NombreCol] + " Nº" +
                                                      dtDetalles.Rows[i][DepositosBancariosDetalleService.VistaCtacteChequeRecibidoNum_NombreCol] +
                                                      ". Depósito bancario caso " + row.CASO_ID + " boleta " + row.NRO_COMPROBANTE;
                                        ctacteChequeRecibidoId = (decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.CtacteChequeRecibidoId_NombreCol];
                                        // No es necesario hacer nada con el cheque recibido, porque el mismo sigue apuntando a este caso de Deposito Bancario
                                    }
                                    else
                                    {
                                        observacion = "Depósito bancario caso " + row.CASO_ID + " boleta " + row.NRO_COMPROBANTE;
                                    }

                                    CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                        row.CTACTE_BANCARIA_ID,
                                        Definiciones.FlujosIDs.DEPOSITO_BANCARIO,
                                        row.CASO_ID,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        row.ID,
                                        CuentaCorrienteCuentasBancariasService.GetMoneda(row.CTACTE_BANCARIA_ID),
                                        (decimal)dtDetalles.Rows[i][DepositosBancariosDetalleService.Importe_NombreCol],
                                        row.COTIZACION_MONEDA,
                                        row.FECHA,
                                        observacion,
                                        null,
                                        ctacteChequeRecibidoId,
                                        false,
                                        sesion);
                                }
                            }
                        }
                    }

                    if (insertarNuevo) sesion.Db.DEPOSITOS_BANCARIOSCollection.Insert(row);
                    else sesion.Db.DEPOSITOS_BANCARIOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    if (!insertarNuevo && CasosService.GetEstadoCaso(row.CASO_ID, sesion).Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Borrar y regenerar el asiento que puede o no existir
                        decimal transicionId = TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.DEPOSITO_BANCARIO, Definiciones.EstadosFlujos.PreAprobado, Definiciones.EstadosFlujos.Aprobado, sesion);
                        AsientosService.BorrarPorCasoYTransicion(row.CASO_ID, transicionId, sesion);
                        AsientosAutomaticosService.GenerarAsientosPorTransicion(transicionId, row.CASO_ID, Definiciones.FlujosIDs.DEPOSITO_BANCARIO, true, DateTime.Now, sesion);
                    }

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.FUNCIONARIO_ID);
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

                    //Se obtienen el caso y el deposito bancario a ser borrados
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    DEPOSITOS_BANCARIOSRow cabecera = sesion.Db.DEPOSITOS_BANCARIOSCollection.GetByCASO_ID(caso_id)[0];

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    if (exito)
                    {
                        // temporal hasta tener el borrado lógico
                        DEPOSITOS_BANCARIOS_DETRow[] detalles = sesion.Db.DEPOSITOS_BANCARIOS_DETCollection.GetByDEPOSITO_BANCARIO_ID(cabecera.ID);
                        foreach (DEPOSITOS_BANCARIOS_DETRow row in detalles)
                        {
                            CuentaCorrienteCajaService.ActualizarDepositoBancarioDet(row.ID, sesion);
                            DepositosBancariosDetalleService.Eliminar(row.ID, sesion);
                        }
                    }
                    else
                    {
                        throw new System.ArgumentException(mensaje);
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.DEPOSITOS_BANCARIOSCollection.DeleteByCASO_ID(caso_id);
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
        public static string Nombre_Tabla
        {
            get { return "DEPOSITOS_BANCARIOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "depositos_bancarios_info_compl"; }
        }
        public static string CasoId_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.CASO_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteBancariaId_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.CTACTE_BANCARIA_IDColumnName; }
        }
        public static string CtacteCajaSucursalId_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        public static string CtacteCajaTesoreriaId_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.CTACTE_CAJA_TESORERIA_IDColumnName; }
        }
        public static string DepositoDesdeSuc_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.DEPOSITO_DESDE_SUCColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.FECHAColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string CrearAnticipoPersona_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.CREAR_ANTICIPO_PERSONAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.IDColumnName; }
        }
        public static string IncluyePersona_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.INCLUYE_PERSONAColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.OBSERVACIONColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.PERSONA_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string TotalChequeMismoBanco_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.TOTAL_CHEQUE_MISMO_BANCOColumnName; }
        }
        public static string CtacteBancariaID_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.CTACTE_BANCARIA_IDColumnName; }
        }
        public static string TotalChequeOtroBanco_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.TOTAL_CHEQUE_OTRO_BANCOColumnName; }
        }
        public static string TotalEfectivo_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.TOTAL_EFECTIVOColumnName; }
        }
        public static string TotalImporte_NombreCol
        {
            get { return DEPOSITOS_BANCARIOSCollection.TOTAL_IMPORTEColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCtacteBancoAbreviatura_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.CTACTE_BANCO_ABREVIATURAColumnName; }
        }
        public static string VistaCtacteBancoId_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.CTACTE_BANCO_IDColumnName; }
        }
        public static string VistaCtacteBancoNombre_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.CTACTE_BANCO_NOMBREColumnName; }
        }
        public static string VistaCtacteCajaSucFechaIni_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.CTACTE_CAJA_SUC_FECHA_INIColumnName; }
        }
        public static string VistaCtacteCajaSucFechaFin_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.CTACTE_CAJA_SUC_FECHA_FINColumnName; }
        }
        public static string VistaCtacteCajaSucFunNombre_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.CTACTE_CAJA_SUC_FUNC_NOMBREColumnName; }
        }
        public static string VistaCtacteCajaSucNroComp_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.CTACTE_CAJA_SUC_NRO_COMPColumnName; }
        }
        public static string VistaCtacteCajaTesoAbreviatura_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.CTACTE_CAJA_TESO_ABREVIATURAColumnName; }
        }
        public static string VistaCtacteCajaTesoNombre_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.CTACTE_CAJA_TESORERIA_NOMBREColumnName; }
        }
        public static string VistaFuncionarioNombreCompleto_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.FUNCIONARIO_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaMonedaCadenaDecimales_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.MONEDA_CADENA_DECIMALESColumnName; }
        }
        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.MONEDA_CANTIDADES_DECIMALESColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaId_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.MONEDA_IDColumnName; }
        }
        public static string VistaCtacteBancariaNumeroCuenta_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.NUMERO_CUENTAColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaTextoPredefinidoNombre_NombreCol
        {
            get { return DEPOSITOS_BANCARIOS_INFO_COMPLCollection.TEXTO_PREDEFINIDO_NOMBREColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static DepositosBancariosService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new DepositosBancariosService(e.RegistroId, sesion);
        }

        public static decimal? GetIdPorUUID(string uuid, SessionService sesion)
        {
            if (uuid.Length <= 0)
                return null;

            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return e.RegistroId;
        }
        #endregion interfaz IEntidadMigrable

        #region Propiedades
        protected DEPOSITOS_BANCARIOSRow row;
        protected DEPOSITOS_BANCARIOSRow rowSinModificar;
        public class Modelo : DEPOSITOS_BANCARIOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal CasoId { get { return row.CASO_ID; } set { row.CASO_ID = value; } }
        public decimal CotizacionMoneda { get { return row.COTIZACION_MONEDA; } set { row.COTIZACION_MONEDA = value; } }
        public decimal CtacteBancariaId { get { return row.CTACTE_BANCARIA_ID; } set { row.CTACTE_BANCARIA_ID = value; } }
        public decimal? CtacteCajaSucursalId { get { if (row.IsCTACTE_CAJA_SUCURSAL_IDNull) return null; else return row.CTACTE_CAJA_SUCURSAL_ID; } set { if (value.HasValue) row.CTACTE_CAJA_SUCURSAL_ID = value.Value; else row.IsCTACTE_CAJA_SUCURSAL_IDNull = true; } }
        public decimal? CtacteCajaTesoreriaId { get { if (row.IsCTACTE_CAJA_TESORERIA_IDNull) return null; else return row.CTACTE_CAJA_TESORERIA_ID; } set { if (value.HasValue) row.CTACTE_CAJA_TESORERIA_ID = value.Value; else row.IsCTACTE_CAJA_TESORERIA_IDNull = true; } }
        public string DepositoDesdeSucursal { get { return GetStringHelper(row.DEPOSITO_DESDE_SUC); } set { row.DEPOSITO_DESDE_SUC = value; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public decimal FuncionarioId { get { return row.FUNCIONARIO_ID; } set { row.FUNCIONARIO_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string NroComprobante { get { return GetStringHelper(row.NRO_COMPROBANTE); } set { row.NRO_COMPROBANTE = value; } }
        public string Observacion { get { return GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } set { row.SUCURSAL_ID = value; } }
        public decimal? TextoPredefinidoId { get { if (row.IsTEXTO_PREDEFINIDO_IDNull) return null; else return row.TEXTO_PREDEFINIDO_ID; } set { if (value.HasValue) row.TEXTO_PREDEFINIDO_ID = value.Value; else row.IsTEXTO_PREDEFINIDO_IDNull = true; } }
        public decimal TotalChequeMismoBanco { get { return row.TOTAL_CHEQUE_MISMO_BANCO; } set { row.TOTAL_CHEQUE_MISMO_BANCO = value; } }
        public decimal TotalChequeOtroBanco { get { return row.TOTAL_CHEQUE_OTRO_BANCO; } set { row.TOTAL_CHEQUE_OTRO_BANCO = value; } }
        public decimal TotalEfectivo { get { return row.TOTAL_EFECTIVO; } set { row.TOTAL_EFECTIVO = value; } }
        public decimal TotalImporte { get { return row.TOTAL_IMPORTE; } set { row.TOTAL_IMPORTE = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CasosService _caso;
        public CasosService Caso
        {
            get
            {
                if (this._caso == null)
                {
                    if (this.sesion != null)
                        this._caso = new CasosService(this.CasoId, this.sesion);
                    else
                        this._caso = new CasosService(this.CasoId);
                }
                return this._caso;
            }
        }

        private CuentaCorrienteCuentasBancariasService _ctacte_bancaria;
        public CuentaCorrienteCuentasBancariasService CtacteBancaria
        {
            get
            {
                if (this._ctacte_bancaria == null)
                {
                    if (this.sesion != null)
                        this._ctacte_bancaria = new CuentaCorrienteCuentasBancariasService(this.CtacteBancariaId, this.sesion);
                    else
                        this._ctacte_bancaria = new CuentaCorrienteCuentasBancariasService(this.CtacteBancariaId);
                }
                return this._ctacte_bancaria;
            }
        }

        private CuentaCorrienteCajasSucursalService _ctacte_caja_sucursal;
        public CuentaCorrienteCajasSucursalService CtacteCajaSucursal
        {
            get
            {
                if (this._ctacte_caja_sucursal == null)
                {
                    if (this.sesion != null)
                        this._ctacte_caja_sucursal = new CuentaCorrienteCajasSucursalService(this.CtacteCajaSucursalId.Value, this.sesion);
                    else
                        this._ctacte_caja_sucursal = new CuentaCorrienteCajasSucursalService(this.CtacteCajaSucursalId.Value);
                }
                return this._ctacte_caja_sucursal;
            }
        }

        private CuentaCorrienteCajasTesoreriaService _ctacte_caja_tesoreria;
        public CuentaCorrienteCajasTesoreriaService CtacteCajaTesoreria
        {
            get
            {
                if (this._ctacte_caja_tesoreria == null)
                {
                    if (this.sesion != null)
                        this._ctacte_caja_tesoreria = new CuentaCorrienteCajasTesoreriaService(this.CtacteCajaTesoreriaId.Value, this.sesion);
                    else
                        this._ctacte_caja_tesoreria = new CuentaCorrienteCajasTesoreriaService(this.CtacteCajaTesoreriaId.Value);
                }
                return this._ctacte_caja_tesoreria;
            }
        }

        private FuncionariosService _funcionario;
        public FuncionariosService Funcionario
        {
            get
            {
                if (this._funcionario == null)
                {
                    if (this.sesion != null)
                        this._funcionario = new FuncionariosService(this.FuncionarioId, this.sesion);
                    else
                        this._funcionario = new FuncionariosService(this.FuncionarioId);
                }
                return this._funcionario;
            }
        }

        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                {
                    if (this.sesion != null)
                        this._sucursal = new SucursalesService(this.SucursalId, this.sesion);
                    else
                        this._sucursal = new SucursalesService(this.SucursalId);
                }
                return this._sucursal;
            }
        }

        private TextosPredefinidosService _texto_predefinido;
        public TextosPredefinidosService TextoPredefinido
        {
            get
            {
                if (this._texto_predefinido == null)
                {
                    if (this.sesion != null)
                        this._texto_predefinido = new TextosPredefinidosService(this.TextoPredefinidoId.Value, this.sesion);
                    else
                        this._texto_predefinido = new TextosPredefinidosService(this.TextoPredefinidoId.Value);
                }
                return this._texto_predefinido;
            }
        }
        #endregion Propiedades Extendidas

        #region Propiedades OneToMany
        private DepositosBancariosDetalleService[] _deposito_bancario_detalles;
        public DepositosBancariosDetalleService[] DepositoBancarioDetalles
        {
            get
            {
                if (this._deposito_bancario_detalles == null)
                    this._deposito_bancario_detalles = DepositosBancariosDetalleService.GetPorCabecera(this.Id.Value);
                return this._deposito_bancario_detalles;
            }
        }
        #endregion Propiedades OneToMany

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.DEPOSITOS_BANCARIOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new DEPOSITOS_BANCARIOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(DEPOSITOS_BANCARIOSRow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public DepositosBancariosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public DepositosBancariosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public DepositosBancariosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        public DepositosBancariosService(EdiCBA.DepositoBancario edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = DepositosBancariosService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            this.CasoId = edi.caso_id;

            if (edi.cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion'.");
            this.CotizacionMoneda = edi.cotizacion.venta;

            #region cuenta bancaria
            if (!string.IsNullOrEmpty(edi.cuenta_bancaria_uuid))
                this._ctacte_bancaria = CuentaCorrienteCuentasBancariasService.GetPorUUID(edi.cuenta_bancaria_uuid, sesion);
            if (this._ctacte_bancaria == null && edi.cuenta_bancaria != null)
                this._ctacte_bancaria = new CuentaCorrienteCuentasBancariasService(edi.cuenta_bancaria, almacenar_localmente, sesion);
            if (this._ctacte_bancaria == null)
                throw new Exception("No se encontró el UUID " + edi.cuenta_bancaria_uuid + " ni se definieron los datos del objeto.");
            
            if(!this.CtacteBancaria.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.CtacteBancaria.Id.HasValue)
                this.CtacteBancariaId = this.CtacteBancaria.Id.Value;
            #endregion cuenta bancaria
            
            #region Caja sucursal
            if (!string.IsNullOrEmpty(edi.caja_recaudacion_uuid))
                this._ctacte_caja_sucursal = CuentaCorrienteCajasSucursalService.GetPorUUID(edi.caja_recaudacion_uuid, sesion);
            if (this._ctacte_caja_sucursal == null && edi.caja_recaudacion != null)
                this._ctacte_caja_sucursal = new CuentaCorrienteCajasSucursalService(edi.caja_recaudacion, almacenar_localmente, sesion);
            if (this._ctacte_caja_sucursal != null)
            {
                if (!this._ctacte_caja_sucursal.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this._ctacte_caja_sucursal.Id.HasValue)
                    this.CtacteCajaSucursalId = this._ctacte_caja_sucursal.Id.Value;
            }
            #endregion Caja sucursal

            #region Caja tesoreria
            if (!string.IsNullOrEmpty(edi.caja_tesoreria_uuid))
                this._ctacte_caja_tesoreria = CuentaCorrienteCajasTesoreriaService.GetPorUUID(edi.caja_tesoreria_uuid, sesion);
            if (this._ctacte_caja_tesoreria == null && edi.caja_tesoreria != null)
                this._ctacte_caja_tesoreria = new CuentaCorrienteCajasTesoreriaService(edi.caja_tesoreria, almacenar_localmente, sesion);
            if (this._ctacte_caja_tesoreria != null)
            {
                if (!this._ctacte_caja_tesoreria.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this._ctacte_caja_tesoreria.Id.HasValue)
                    this.CtacteCajaTesoreriaId = this._ctacte_caja_tesoreria.Id.Value;
            }
            #endregion Caja tesoreria

            this.DepositoDesdeSucursal = Definiciones.SiNo.No;
            if(this._ctacte_caja_sucursal != null || this.CtacteCajaSucursalId.HasValue)
                this.DepositoDesdeSucursal = Definiciones.SiNo.Si;

            this.Fecha = edi.fecha;
            
            #region funcionario
            if (!string.IsNullOrEmpty(edi.funcionario_uuid))
                this._funcionario = FuncionariosService.GetPorUUID(edi.funcionario_uuid, sesion);
            if (this._funcionario == null && edi.funcionario != null)
                this._funcionario = new FuncionariosService(edi.funcionario, almacenar_localmente, sesion);
            if (this._funcionario != null)
            {
                if (!this.Funcionario.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.Funcionario.Id.HasValue)
                    this.FuncionarioId = this.Funcionario.Id.Value;
            }
            #endregion funcionario

            this.NroComprobante = edi.nro_comprobante;
            this.Observacion = edi.observacion;
            
            #region sucursal
            if (!string.IsNullOrEmpty(edi.sucursal_uuid))
                this._sucursal = SucursalesService.GetPorUUID(edi.sucursal_uuid, sesion);
            if (this._sucursal == null && edi.sucursal != null)
                this._sucursal = new SucursalesService(edi.sucursal, almacenar_localmente, sesion);
            if (this._sucursal == null)
                throw new Exception("No se encontró el UUID " + edi.sucursal_uuid + " ni se definieron los datos del objeto.");

            if (!this.Sucursal.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Sucursal.Id.HasValue)
                this.SucursalId = this.Sucursal.Id.Value;
            #endregion sucursal
            
            //TODO: descomentar cuando Texto Predefinido tenga orientación a objetos
            //#region texto predefinido
            //if (!string.IsNullOrEmpty(edi.texto_predefinido_uuid))
            //    this._texto_predefinido = TextosPredefinidosService.GetPorUUID(edi.texto_predefinido_uuid, sesion);
            //if (this._texto_predefinido == null && edi.texto_predefinido != null)
            //    this._texto_predefinido = new TextosPredefinidosService(edi.texto_predefinidoucursal, almacenar_localmente, sesion);
            //if (this._texto_predefinido == null)
            //    throw new Exception("No se encontró el UUID " + edi.texto_predefinido_uuid + " ni se definieron los datos del objeto.");

            //if (!this.TextoPredefinido.ExisteEnDB && almacenar_localmente)
            //{
            //    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
            //    throw new NotImplementedException("Debe guardarse localmente la entidad.");
            //}
            //if (this.TextoPredefinido.Id.HasValue)
            //    this.TextoPredefinidoId = this.TextoPredefinido.Id.Value;
            //#endregion texto predefinido
            
            this.TotalChequeMismoBanco = edi.total_cheques_mismo_banco;
            this.TotalChequeOtroBanco = edi.total_cheques_otro_banco;
            this.TotalEfectivo = edi.total_efectivo;
            this.TotalImporte = edi.total;

            #region caso
            if (!this.ExisteEnDB)
            {
                this._caso = new CasosService(
                    new EdiCBA.Caso()
                    {
                        estado_id = edi.estado_id,
                        funcionario_uuid = edi.funcionario_uuid,
                        funcionario = edi.funcionario,
                        nro_comprobante = edi.nro_comprobante,
                        persona_uuid = edi.persona_uuid,
                        persona = edi.persona,
                        proveedor_uuid = edi.proveedor_uuid,
                        proveedor = edi.proveedor,
                        sucursal_uuid = edi.sucursal_uuid,
                        sucursal = edi.sucursal
                    }, almacenar_localmente, sesion
                );
                this.Caso.FechaCreacion = edi.fecha;
                this.Caso.FechaFormulario = edi.fecha;
                this.Caso.FlujoId = Definiciones.FlujosIDs.DEPOSITO_BANCARIO;
                this.Caso.NroComprobante2 = string.Empty;
            }
            #endregion caso
        }
        private DepositosBancariosService(DEPOSITOS_BANCARIOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCaso
        public static DepositosBancariosService GetPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCaso(caso_id, sesion);
            }
        }

        public static DepositosBancariosService GetPorCaso(decimal caso_id, SessionService sesion)
        {
            var row = sesion.db.DEPOSITOS_BANCARIOSCollection.GetByCASO_ID(caso_id)[0];
            return new DepositosBancariosService(row);
        }
        #endregion GetPorCaso

        #region ResetearPropiedadesExtendidas
#pragma warning disable CS0114 // 'DepositosBancariosService.ResetearPropiedadesExtendidas()' oculta el miembro heredado 'FlujosServiceBaseWorkaround.ResetearPropiedadesExtendidas()'. Para hacer que el miembro actual invalide esa implementación, agregue la palabra clave override. Si no, agregue la palabra clave new.
        public void ResetearPropiedadesExtendidas()
#pragma warning restore CS0114 // 'DepositosBancariosService.ResetearPropiedadesExtendidas()' oculta el miembro heredado 'FlujosServiceBaseWorkaround.ResetearPropiedadesExtendidas()'. Para hacer que el miembro actual invalide esa implementación, agregue la palabra clave override. Si no, agregue la palabra clave new.
        {
            this._caso = null;
            this._ctacte_bancaria = null;
            this._ctacte_caja_sucursal = null;
            this._ctacte_caja_tesoreria = null;
            this._deposito_bancario_detalles = null;
            this._funcionario = null;
            this._sucursal = null;
            this._texto_predefinido = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.DepositoBancario()
            {
                caja_recaudacion_uuid = this.CtacteCajaSucursalId.HasValue ? this.CtacteCajaSucursal.GetOrCreateUUID(sesion) : null,
                caja_tesoreria_uuid = this.CtacteCajaTesoreriaId.HasValue ? this.CtacteCajaTesoreria.GetOrCreateUUID(sesion) : null,
                caso_id = this.CasoId,
                cuenta_bancaria_uuid = this.CtacteBancaria.GetOrCreateUUID(sesion),
                cotizacion_uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, Modelo.COTIZACION_MONEDAColumnName, this.Id.Value, sesion),
                estado_id = this.Caso.EstadoId,
                fecha = this.Fecha,
                funcionario_uuid = this.Funcionario.GetOrCreateUUID(sesion),
                nro_comprobante = this.NroComprobante,
                observacion = this.Observacion,
                sucursal_uuid = this.Sucursal.GetOrCreateUUID(sesion),
                total = this.TotalImporte,
                total_cheques_mismo_banco = this.TotalChequeMismoBanco,
                total_cheques_otro_banco = this.TotalChequeOtroBanco,
                total_efectivo = this.TotalEfectivo,
            };

            var detalles = DepositosBancariosDetalleService.GetPorCabecera(this.Id.Value, sesion);
            e.deposito_bancario_detalles_uuid = new string[detalles.Length];
            for (int i = 0; i < detalles.Length; i++)
                e.deposito_bancario_detalles_uuid[i] = detalles[i].GetOrCreateUUID(sesion);

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                if(this.CtacteCajaSucursalId.HasValue)
                    e.caja_recaudacion = (EdiCBA.CajaRecaudacion)this.CtacteCajaSucursal.ToEDI(nueva_profundidad, sesion);
                if (this.CtacteCajaTesoreriaId.HasValue)
                    e.caja_tesoreria = (EdiCBA.CajaTesoreria)this.CtacteCajaTesoreria.ToEDI(nueva_profundidad, sesion);
                e.cuenta_bancaria = (EdiCBA.CuentaBancaria)this.CtacteBancaria.ToEDI(nueva_profundidad, sesion);
                e.cotizacion = new EdiCBA.Cotizacion()
                {
                    uuid = e.cotizacion_uuid,
                    fecha = this.Fecha,
                    moneda_uuid = e.cuenta_bancaria.moneda_uuid,
                    venta = this.CotizacionMoneda
                };
                e.funcionario = (EdiCBA.Funcionario)this.Funcionario.ToEDI(nueva_profundidad, sesion);
                e.sucursal = (EdiCBA.Sucursal)this.Sucursal.ToEDI(nueva_profundidad, sesion);

                e.deposito_bancario_detalles = new EdiCBA.DepositoBancarioDetalle[detalles.Length];
                for (int i = 0; i < detalles.Length; i++)
                    e.deposito_bancario_detalles[i] = (EdiCBA.DepositoBancarioDetalle)detalles[i].ToEDI(nueva_profundidad, sesion);
            }

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value);
            }
            return e;
        }
        #endregion ToEDI
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
