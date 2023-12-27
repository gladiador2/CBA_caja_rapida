#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.NotaCreditosProveedores;
using CBA.FlowV2.Services.RecursosHumanos;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotasDebitoProveedor;
using CBA.FlowV2.Services.NotasCreditoPersona;
using System.Windows.Forms;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Articulos;
using System.Text;
using CBA.FlowV2.Services.ToolbarFlujo;
using CBA.FlowV2.Services.TextosPredefinidos;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class OrdenesPagoService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.ORDEN_DE_PAGO;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var cabecera = (OrdenesPagoService)caso_cabecera;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);

            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, );
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, cabecera.TextoPredefinidoId);
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
                ORDENES_PAGORow cabeceraRow = sesion.Db.ORDENES_PAGOCollection.GetByCASO_ID(caso_id)[0];
                ORDENES_PAGO_DETRow[] detalleRows = sesion.Db.ORDENES_PAGO_DETCollection.GetByORDEN_PAGO_ID(cabeceraRow.ID);
                ORDENES_PAGO_VALORES_INFO_COMPRow[] valoresRows = sesion.Db.ORDENES_PAGO_VALORES_INFO_COMPCollection.GetAsArray(OrdenesPagoValoresService.OrdenPagoId_NombreCol + " = " + cabeceraRow.ID, OrdenesPagoValoresService.Id_NombreCol);
                DataTable dtCtacteProveedor;

                //Borrador a Pendiente
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Validar que la suma de los documentos y los valores coincide
                    //segun el tipo de OP

                    exito = true;
                    revisarRequisitos = true;

                    if (detalleRows.Length < 1)
                    {
                        mensaje = "Debe agregar al menos un detalle al pago.";
                        exito = false;
                    }

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    if (cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAProveedor ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAPersona ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.ReposicionFondoFijo ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.RespaldoAnticipoProveedor ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.AdelantoFuncionario ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.RespaldoAjusteBancario ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoFuncionarios
                        )
                    {

                        if (!RolesService.Tiene("ORDENES PAGO NO CONTROLAR SUMA VALORES IGUAL DETALLES"))
                        {
                            decimal totalDocumentos = 0, totalValores = 0;
                            for (int i = 0; i < detalleRows.Length; i++)
                                totalDocumentos += detalleRows[i].MONTO_DESTINO;

                            totalDocumentos = Math.Round(totalDocumentos, MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID));
                            totalValores = Math.Round(cabeceraRow.MONTO_TOTAL, MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID));

                            if (totalDocumentos != totalValores)
                            {
                                mensaje = "Los documentos a pagar suman " + totalDocumentos + " pero los valores suman " + totalValores + ".";
                                exito = false;
                            }
                        }

                        #region Controlar Anticipos
                        //obtener los ids de las facturas
                        List<decimal> facturasOP = new List<decimal>();
                        CuentaCorrienteProveedoresService cuentaCorrienteProveedor = new CuentaCorrienteProveedoresService();
                        FacturasProveedorService facturaProveedor = new FacturasProveedorService();
                        foreach (ORDENES_PAGO_DETRow detalle in detalleRows)
                        {
                            if (!detalle.IsCTACTE_PROVEEDOR_IDNull)
                            {
                                string clausulas = CuentaCorrienteProveedoresService.Id_NombreCol + " = " + detalle.CTACTE_PROVEEDOR_ID.ToString();
                                dtCtacteProveedor = cuentaCorrienteProveedor.GetCuentaCorrienteProveedoresDataTable(clausulas, string.Empty);
                                decimal casoId = (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.CasoId_NombreCol];
                                clausulas = FacturasProveedorService.CasoId_NombreCol + " = " + casoId.ToString();
                                DataTable dtFactura = facturaProveedor.GetFacturaProveedorDataTable(clausulas, string.Empty);
                                if (dtFactura.Rows.Count > 0)
                                {
                                    decimal facturaId = (decimal)dtFactura.Rows[0][FacturasProveedorService.Id_NombreCol];
                                    facturasOP.Add(facturaId);
                                }
                            }
                        }

                        //controlar si los anticipos continen las facturas
                        AnticiposPorFacturasProveedorService anticipoPorFacturaProveedor = new AnticiposPorFacturasProveedorService();
                        foreach (ORDENES_PAGO_VALORES_INFO_COMPRow valor in valoresRows)
                        {
                            if (!valor.IsANTICIPO_PROVEEDOR_IDNull)
                            {
                                bool contiene = anticipoPorFacturaProveedor.ContieneFactura(valor.ANTICIPO_PROVEEDOR_ID, facturasOP);
                                if (!contiene)
                                {
                                    mensaje = "Se agrego una orden de pago cuyas facturas no coinciden con las ingresadas";
                                    exito = false;
                                    break;
                                }
                            }
                        }
                        #endregion Controlar Anticipos
                    }
                }
                //Borrador a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Si es un pago a funcionarios desafectar la liquidacion.
                    exito = true;
                    revisarRequisitos = true;

                    //Se quita la asociación entre la planilla de salario y detalle
                    if (cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoFuncionarios || 
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAProveedor)
                    {
                        for (int i = 0; i < detalleRows.Length; i++)
                        {
                            if (!detalleRows[i].IsLIQUIDACION_IDNull)
                            {
                                detalleRows[i].IsLIQUIDACION_IDNull = true;
                                sesion.Db.ORDENES_PAGO_DETCollection.Update(detalleRows[i]);
                            }
                        }
                    }
                    else if (cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAPersona)
                    {
                        //se borran las referencias de los detalles a la cuenta corriente en caso de que exista, de tal manera a no bloquear la eliminacion de la ctacte persona
                        DataTable detalles = OrdenesPagoDetalleService.GetOrdenesPagoDetallesDataTable2(OrdenesPagoDetalleService.OrdenPagoId_NombreCol + " = " + cabeceraRow.ID, string.Empty, sesion);
                        foreach (DataRow dr in detalles.Rows)
                        {
                            OrdenesPagoDetalleService.QuitarReferenciaACtaCtePersona(decimal.Parse(dr[OrdenesPagoDetalleService.Id_NombreCol].ToString()));
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
                    //Si es un pago a funcionarios desafectar la liquidacion.
                    //Si hay retenciones aplicadas sobre facturas de proveedores, quitarlas.
                    exito = true;
                    revisarRequisitos = true;

                    //Se quita la asociación entre la planilla de salario y detalle
                    if (cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoFuncionarios ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAProveedor)
                    {
                        for (int i = 0; i < detalleRows.Length; i++)
                        {
                            if (!detalleRows[i].IsLIQUIDACION_IDNull)
                            {
                                detalleRows[i].IsLIQUIDACION_IDNull = true;
                                sesion.Db.ORDENES_PAGO_DETCollection.Update(detalleRows[i]);
                            }
                        }
                    }
                    else if (cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAProveedor)
                    {
                        //Nada que hacer
                    }
                    else if (cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAPersona)
                    {
                        //se borran las referencias de los detalles a la cuenta corriente en caso de que exista, de tal manera a no bloquear la eliminacion de la ctacte persona
                        DataTable detalles = OrdenesPagoDetalleService.GetOrdenesPagoDetallesDataTable2(OrdenesPagoDetalleService.OrdenPagoId_NombreCol + " = " + cabeceraRow.ID, string.Empty, sesion);
                        foreach (DataRow dr in detalles.Rows)
                        {
                            OrdenesPagoDetalleService.QuitarReferenciaACtaCtePersona(decimal.Parse(dr[OrdenesPagoDetalleService.Id_NombreCol].ToString()));
                        }
                    }
                }
                //Pendiente a Aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones:
                    //Validar que la suma de los documentos y los valores coincide
                    //Se genera el número de comprobante basado en la autonumeracion.
                    exito = true;
                    revisarRequisitos = true;

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    if (!RolesService.Tiene("ORDENES PAGO NO CONTROLAR SUMA VALORES IGUAL DETALLES"))
                    {
                        decimal totalDocumentos = 0, totalValores = 0;
                        for (int i = 0; i < detalleRows.Length; i++)
                            totalDocumentos += detalleRows[i].MONTO_DESTINO;

                        totalDocumentos = Math.Round(totalDocumentos, MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID));
                        totalValores = Math.Round(cabeceraRow.MONTO_TOTAL, MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID));

                        if (totalDocumentos != totalValores)
                        {
                            mensaje = "Los documentos a pagar suman " + totalDocumentos + " pero los valores suman " + totalValores + ".";
                            exito = false;
                        }
                    }

                    if (exito && cabeceraRow.NRO_COMPROBANTE == null)
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
                //Pendiente a Aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones:
                    //Ninguna
                    exito = true;
                    revisarRequisitos = true;
                }
                //Aprobado a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Si es un pago a funcionarios desafectar la liquidacion.
                    //Si hay retenciones aplicadas sobre facturas de proveedores, quitarlas.
                    exito = true;
                    revisarRequisitos = true;

                    //Se quita la asociación entre la planilla de salario y detalle
                    if (cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoFuncionarios ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAProveedor)
                    {
                        for (int i = 0; i < detalleRows.Length; i++)
                        {
                            if (!detalleRows[i].IsLIQUIDACION_IDNull)
                            {
                                detalleRows[i].IsLIQUIDACION_IDNull = true;
                                sesion.Db.ORDENES_PAGO_DETCollection.Update(detalleRows[i]);
                            }
                        }
                    }
                    else if (cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAPersona)
                    {
                        //se borran las referencias de los detalles a la cuenta corriente en caso de que exista, de tal manera a no bloquear la eliminacion de la ctacte persona
                        DataTable detalles = OrdenesPagoDetalleService.GetOrdenesPagoDetallesDataTable2(OrdenesPagoDetalleService.OrdenPagoId_NombreCol + " = " + cabeceraRow.ID, string.Empty, sesion);
                        foreach (DataRow dr in detalles.Rows)
                        {
                            OrdenesPagoDetalleService.QuitarReferenciaACtaCtePersona(decimal.Parse(dr[OrdenesPagoDetalleService.Id_NombreCol].ToString()));
                        }
                    }
                }
                //Aprobado a Generacion
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Generacion))
                {
                    //Acciones
                    //Validar que la suma de los documentos y los valores coincide
                    //Se disminuyen los saldos que correspondan segun los 
                    //detalles de valores de pago (e.g. cuentas bancarias, 
                    //efectivo en caja, saldo de NC o anticipo).

                    exito = true;
                    revisarRequisitos = true;

                    if (detalleRows.Length < 1)
                    {
                        mensaje = "Debe agregar al menos un detalle al pago.";
                        exito = false;
                    }

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    if (!RolesService.Tiene("ORDENES PAGO NO CONTROLAR SUMA VALORES IGUAL DETALLES"))
                    {
                        decimal totalDocumentos = 0, totalValores = 0;
                        for (int i = 0; i < detalleRows.Length; i++)
                            totalDocumentos += detalleRows[i].MONTO_DESTINO;

                        totalDocumentos = Math.Round(totalDocumentos, MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID));
                        totalValores = Math.Round(cabeceraRow.MONTO_TOTAL, MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_ID));

                        if (totalDocumentos != totalValores)
                        {
                            mensaje = "Los documentos a pagar suman " + totalDocumentos + " pero los valores suman " + totalValores + ".";
                            exito = false;
                        }
                    }

                    int ctacteValor;
                    CuentaCorrienteCajasTesoreriaService ctacteCajaTesoreria = new CuentaCorrienteCajasTesoreriaService();
                    Hashtable campos;

                    //Unicamente estos tipos de OP emiten valores.
                    //Los demas utilizan la OP unicamente como respaldo
                    if (cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAProveedor ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAPersona ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.ReposicionFondoFijo ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.RespaldoAnticipoProveedor ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.AdelantoFuncionario ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoFuncionarios)
                    {

                        if (!RolesService.Tiene("ORDENES PAGO EMITIR CHEQUE CON SALDO NEGATIVO"))
                        {
                            #region controlar valores negativos para los cheques (girados)
                            //traer todos los valores como Datatable
                            DataTable valores = sesion.Db.ORDENES_PAGO_VALORES_INFO_COMPCollection.GetAsDataTable(OrdenesPagoValoresService.OrdenPagoId_NombreCol + " = " + cabeceraRow.ID, string.Empty);
                            //filtrar por cheques en un array de DataRows
                            DataRow[] chequesRows = valores.Select(OrdenesPagoValoresService.CtacteValorId_NombreCol + "= " + Definiciones.CuentaCorrienteValores.Cheque + " and " + OrdenesPagoValoresService.CGCtacteBancariaId_NombreCol + " is not null ");
                            //copiar los DataRows a un DataTable  

                            //verificar que exista al menos un cheque
                            if (chequesRows.Length > 0)
                            {
                                DataTable cheques = chequesRows.CopyToDataTable();
                                //Hacer un distinct para los bancos 
                                DataTable distinctBancos = cheques.DefaultView.ToTable(true, OrdenesPagoValoresService.VistaCGCtacteBancariaId_NombreCol);

                                //recorrer los bancos de los valores que son cheques
                                foreach (DataRow item in distinctBancos.Rows)
                                {
                                    //traer el saldo del banco
                                    DataTable dtCtacteCuentaBancaria = CuentaCorrienteCuentasBancariasService.GetCuentaCorrienteBancariasInfoCompleta(CuentaCorrienteCuentasBancariasService.Id_NombreCol + " = " + item[OrdenesPagoValoresService.VistaCGCtacteBancariaId_NombreCol], string.Empty, false);
                                    string saldo = dtCtacteCuentaBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.VistaSaldoActual_NombreCol].ToString();
                                    string sobregiro = dtCtacteCuentaBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.MontoSobregiro_NombreCol].ToString();

                                    if (!saldo.Equals(string.Empty))
                                    {
                                        //sumar los montos para los cheques del mismo banco
                                        object suma = cheques.Compute("sum(" + OrdenesPagoValoresService.MontoOrigen_NombreCol + ")", OrdenesPagoValoresService.VistaCGCtacteBancariaId_NombreCol + " = " + item[OrdenesPagoValoresService.VistaCGCtacteBancariaId_NombreCol].ToString());
                                        //obtener la diferencia con el saldo en cuenta bancaria
                                        decimal diferencia = (decimal.Parse(saldo) - (decimal)suma);
                                        //restringir el paso de estado si es menor al valor del sobregiro y mostrar un mensaje de advertencia
                                        if (diferencia < (decimal.Parse(sobregiro) * -1))
                                        {
                                            mensaje = "El saldo en el banco " + dtCtacteCuentaBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.VistaCtacteBancoNombre_NombreCol].ToString() + " quedará con saldo negativo";
                                            return false;
                                        }
                                    }
                                }
                            }
                            #endregion controlar valores negativos para los cheque
                        }

                        for (int i = 0; i < valoresRows.Length; i++)
                        {
                            ctacteValor = Convert.ToInt32(valoresRows[i].CTACTE_VALOR_ID);
                            switch (ctacteValor)
                            {
                                case Definiciones.CuentaCorrienteValores.Efectivo:
                                    #region Efectivo
                                    //Se realiza el egreso
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(cabeceraRow.CTACTE_CAJA_TESO_ORIGEN_ID,
                                                                  Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                                                  string.Empty,
                                                                  cabeceraRow.ID,
                                                                  valoresRows[i].ID,
                                                                  valoresRows[i].CTACTE_VALOR_ID,
                                                                  Definiciones.Error.Valor.EnteroPositivo,
                                                                  valoresRows[i].MONEDA_ORIGEN_ID,
                                                                  valoresRows[i].COTIZACION_MONEDA_ORIGEN,
                                                                  valoresRows[i].MONTO_ORIGEN,
                                                                  cabeceraRow.FECHA,
                                                                  sesion);
                                    #endregion Efectivo
                                    break;
                                case Definiciones.CuentaCorrienteValores.Cheque:
                                    if (valoresRows[i].IsCR_CTACTE_CHEQUE_RECIBIDO_IDNull)
                                    {
                                        #region Cheque girado
                                        ORDENES_PAGO_VALORESRow ordenPagoValorRow;
                                        campos = new Hashtable();
                                        decimal autonumeracion_id = Definiciones.Error.Valor.EnteroPositivo;
                                        string nroCheque;

                                        campos.Add(CuentaCorrienteChequesGiradosService.CasoCreadorId_NombreCol, cabeceraRow.CASO_ID);
                                        campos.Add(CuentaCorrienteChequesGiradosService.CotizacionMoneda_NombreCol, valoresRows[i].COTIZACION_MONEDA_ORIGEN);
                                        campos.Add(CuentaCorrienteChequesGiradosService.CtaCteBancariaId_NombreCol, valoresRows[i].CG_CTACTE_BANCARIA_ID);
                                        campos.Add(CuentaCorrienteChequesGiradosService.EsDiferido_NombreCol, valoresRows[i].CG_ES_DIFERIDO);
                                        campos.Add(CuentaCorrienteChequesGiradosService.FechaPosdatado_NombreCol, valoresRows[i].CG_FECHA_EMISION);
                                        campos.Add(CuentaCorrienteChequesGiradosService.FechaVencimiento_NombreCol, valoresRows[i].CG_FECHA_VENCIMIENTO);
                                        campos.Add(CuentaCorrienteChequesGiradosService.MonedaId_NombreCol, valoresRows[i].MONEDA_ORIGEN_ID);
                                        campos.Add(CuentaCorrienteChequesGiradosService.Monto_NombreCol, valoresRows[i].MONTO_ORIGEN);
                                        campos.Add(CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol, valoresRows[i].CG_NOMBRE_BENEFICIARIO);
                                        campos.Add(CuentaCorrienteChequesGiradosService.NumeroCtaBeneficiario_NombreCol, Interprete.ObtenerString(valoresRows[i].CG_NUMERO_CTA_BENEFICIARIO));
                                        campos.Add(CuentaCorrienteChequesGiradosService.NombreEmisor_NombreCol, valoresRows[i].CG_NOMBRE_EMISOR);
                                        campos.Add(CuentaCorrienteChequesGiradosService.Observacion_NombreCol, valoresRows[i].OBSERVACION);
                                        if (!valoresRows[i].IsCG_AUTONUMERACION_IDNull)
                                        {
                                            campos.Add(CuentaCorrienteChequesGiradosService.AutonumeracionId_NombreCol, valoresRows[i].CG_AUTONUMERACION_ID);
                                            autonumeracion_id = valoresRows[i].CG_AUTONUMERACION_ID;
                                        }

                                        if (valoresRows[i].CG_NUMERO_CHEQUE != null && valoresRows[i].CG_NUMERO_CHEQUE.Length > 0)
                                            campos.Add(CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol, valoresRows[i].CG_NUMERO_CHEQUE);

                                        //Se obtiene el registro para posterior update
                                        ordenPagoValorRow = sesion.Db.ORDENES_PAGO_VALORESCollection.GetByPrimaryKey(valoresRows[i].ID);

                                        //Se crea el cheque girado
                                        ordenPagoValorRow.CG_CTACTE_CHEQUE_GIRADO_ID = CuentaCorrienteChequesGiradosService.Emitir(campos, autonumeracion_id, out nroCheque, sesion);
                                        valoresRows[i].CG_CTACTE_CHEQUE_GIRADO_ID = ordenPagoValorRow.CG_CTACTE_CHEQUE_GIRADO_ID;
                                        ordenPagoValorRow.CG_NUMERO_CHEQUE = nroCheque;
                                        valoresRows[i].CG_NUMERO_CHEQUE = nroCheque;

                                        //Se actualiza en la base de datos el id del cheque girado
                                        sesion.Db.ORDENES_PAGO_VALORESCollection.Update(ordenPagoValorRow);

                                        //Se afecta la cuenta bancaria si el cheque no es adelantado
                                        if (valoresRows[i].CG_FECHA_VENCIMIENTO.Date <= DateTime.Now.Date)
                                        {
                                            CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                                  valoresRows[i].CG_CTACTE_BANCARIA_ID,
                                                  Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                                  cabeceraRow.CASO_ID,
                                                  Definiciones.Error.Valor.EnteroPositivo,
                                                  cabeceraRow.ID,
                                                  valoresRows[i].MONEDA_ORIGEN_ID,
                                                  valoresRows[i].MONTO_ORIGEN * (-1),
                                                  valoresRows[i].COTIZACION_MONEDA_ORIGEN,
                                                  valoresRows[i].CG_FECHA_VENCIMIENTO,
                                                  "Caso " + cabeceraRow.CASO_ID + " de " + FlujosService.GetDescripcionImpresion(Definiciones.FlujosIDs.ORDEN_DE_PAGO) + " " + cabeceraRow.NRO_COMPROBANTE + " (" + valoresRows[i].CG_NOMBRE_BENEFICIARIO + ") pasado al estado " + estado_destino + ". Cheque " + valoresRows[i].CG_NUMERO_CHEQUE + " fecha " + valoresRows[i].CG_FECHA_EMISION.Date + ".",
                                                  valoresRows[i].CG_CTACTE_CHEQUE_GIRADO_ID,
                                                  null,
                                                  false,
                                                  sesion);
                                        }
                                        #endregion Cheque girado
                                    }
                                    else
                                    {
                                        #region Cheque recibido

                                        //Se egresa el cheque de la caja de tesoreria
                                        CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(cabeceraRow.CTACTE_CAJA_TESO_ORIGEN_ID,
                                                                  Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                                                  string.Empty,
                                                                  cabeceraRow.ID,
                                                                  valoresRows[i].ID,
                                                                  valoresRows[i].CTACTE_VALOR_ID,
                                                                  valoresRows[i].CR_CTACTE_CHEQUE_RECIBIDO_ID,
                                                                  valoresRows[i].MONEDA_ORIGEN_ID,
                                                                  valoresRows[i].COTIZACION_MONEDA_ORIGEN,
                                                                  valoresRows[i].MONTO_ORIGEN,
                                                                  cabeceraRow.FECHA,
                                                                  sesion);

                                        #endregion Cheque recibido
                                    }
                                    break;
                                case Definiciones.CuentaCorrienteValores.TarjetaDeCredito:
                                    #region Tarjeta de Crédito
                                    if (valoresRows[i].MONTO_ORIGEN > 0)
                                    {
                                        CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(cabeceraRow.CTACTE_CAJA_TESO_ORIGEN_ID,
                                                                      Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                                                      string.Empty,
                                                                      cabeceraRow.ID,
                                                                      valoresRows[i].ID,
                                                                      valoresRows[i].CTACTE_VALOR_ID,
                                                                      Definiciones.Error.Valor.EnteroPositivo,
                                                                      valoresRows[i].MONEDA_ORIGEN_ID,
                                                                      valoresRows[i].COTIZACION_MONEDA_ORIGEN,
                                                                      valoresRows[i].MONTO_ORIGEN,
                                                                      cabeceraRow.FECHA,
                                                                      sesion);
                                    }
                                    else
                                    {
                                        CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(cabeceraRow.CTACTE_CAJA_TESO_ORIGEN_ID,
                                                                      Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                                                      string.Empty,
                                                                      cabeceraRow.ID,
                                                                      valoresRows[i].ID,
                                                                      valoresRows[i].CTACTE_VALOR_ID,
                                                                      Definiciones.Error.Valor.EnteroPositivo,
                                                                      valoresRows[i].MONEDA_ORIGEN_ID,
                                                                      valoresRows[i].COTIZACION_MONEDA_ORIGEN,
                                                                      valoresRows[i].MONTO_ORIGEN * (-1),
                                                                      cabeceraRow.FECHA,
                                                                      sesion);
                                    }
                                    #endregion Tarjeta de Crédito
                                    break;
                                case Definiciones.CuentaCorrienteValores.Anticipo:
                                    #region Anticipo
                                    dtCtacteProveedor = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresDataTable(CuentaCorrienteProveedoresService.CasoId_NombreCol + " = " + valoresRows[i].CASO_RELACIONADO_ID, string.Empty, sesion);

                                    if (dtCtacteProveedor.Rows.Count <= 0)
                                        throw new Exception("Error en OrdenesPagoService.ProcesarCambioEstado() El Anticipo no fue encontrado en la ctacte.");

                                    //Ingresar el debito
                                    CuentaCorrienteProveedoresService.AgregarCredito(cabeceraRow.PROVEEDOR_ID,
                                                                (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.Id_NombreCol],
                                                                Definiciones.CuentaCorrienteValores.Anticipo,
                                                                Definiciones.CuentaCorrienteConceptos.CreditoPorPago,
                                                                cabeceraRow.CASO_ID,
                                                                valoresRows[i].MONEDA_ORIGEN_ID,
                                                                valoresRows[i].MONTO_ORIGEN,
                                                                string.Empty,
                                                                DateTime.Now,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                valoresRows[i].ID,
                                                                sesion);

                                    //Se disminuye el saldo
                                    (new AnticiposProveedorService()).DisminuirSaldoDisponible(valoresRows[i].ANTICIPO_PROVEEDOR_ID, valoresRows[i].MONTO_ORIGEN, sesion);
                                    #endregion Anticipo
                                    break;
                                case Definiciones.CuentaCorrienteValores.NotaDeCredito:
                                    #region Nota de Credito
                                    dtCtacteProveedor = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresDataTable(CuentaCorrienteProveedoresService.CasoId_NombreCol + " = " + valoresRows[i].CASO_RELACIONADO_ID, string.Empty, sesion);

                                    if (dtCtacteProveedor.Rows.Count <= 0)
                                        throw new Exception("Error en OrdenesPagoService.ProcesarCambioEstado() La Nota de Crédito no fue encontrada en la ctacte.");

                                    //Ingresar el debito
                                    CuentaCorrienteProveedoresService.AgregarCredito(cabeceraRow.PROVEEDOR_ID,
                                                                (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.Id_NombreCol],
                                                                Definiciones.CuentaCorrienteValores.NotaDeCredito,
                                                                Definiciones.CuentaCorrienteConceptos.CreditoPorPago,
                                                                cabeceraRow.CASO_ID,
                                                                valoresRows[i].MONEDA_ORIGEN_ID,
                                                                valoresRows[i].MONTO_ORIGEN,
                                                                string.Empty,
                                                                DateTime.Now,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                valoresRows[i].ID,
                                                                sesion);

                                    //Se disminuye el saldo
                                    (new NotasCreditoProveedorService()).DisminuirSaldoDisponible(valoresRows[i].NOTA_CREDITO_PROVEEDOR_ID, valoresRows[i].MONTO_ORIGEN, sesion);

                                    #endregion Nota de Credito
                                    break;
                                case Definiciones.CuentaCorrienteValores.TransferenciaBancaria:
                                    #region Transferencia Bancaria

                                    //Se verifica que la transferencia no haya sido utilizada
                                    //como valor en otra OP ya en estado Generacion o Cerrado
                                    DataTable dtTransferenciaBancaria;
                                    string clausulas;

                                    clausulas = TransferenciasBancariasService.Id_NombreCol + " = " + valoresRows[i].TRANSFERENCIA_BANCARIA_ID + " and " +
                                                TransferenciasBancariasService.VistaOrdenPagoUtilizaCasoId_NombreCol + " is not null and " +
                                                TransferenciasBancariasService.VistaOrdenPagoUtilizaCasoId_NombreCol + " not like '%" + cabeceraRow.CASO_ID + "%'";

                                    dtTransferenciaBancaria = TransferenciasBancariasService.GetTransferenciasBancariasInfoCompleta(clausulas, string.Empty, sesion);

                                    if (dtTransferenciaBancaria.Rows.Count > 0)
                                        throw new Exception("La transferencia bancaria caso " + valoresRows[i].CASO_RELACIONADO_ID + " ya está siendo utilizada como valor de pago en la OP caso " + dtTransferenciaBancaria.Rows[0][TransferenciasBancariasService.VistaOrdenPagoUtilizaCasoId_NombreCol] + ".");

                                    #endregion Transferencia Bancaria
                                    break;
                                case Definiciones.CuentaCorrienteValores.RetencionRenta:
                                case Definiciones.CuentaCorrienteValores.RetencionIVA:
                                    #region Retencion
                                    FacturasProveedorService facturaProveedor = new FacturasProveedorService();
                                    ORDENES_PAGO_VALORESRow ordenPagoValorEditado;
                                    CuentaCorrienteRetencionesEmitidasService retencionEmitida = new CuentaCorrienteRetencionesEmitidasService();
                                    CuentaCorrienteRetencionesEmitidasDetalleService retencionEmitidaDet = new CuentaCorrienteRetencionesEmitidasDetalleService();
                                    decimal retencion_detalle_id;
                                    string[] strAuxFacturas, strAuxMontos;

                                    // Se verifica que exista una autonumeracion para las retenciones a emitir en la cabecera de la OP
                                    if (cabeceraRow.IsRETENCION_AUTONUMERACION_IDNull)
                                        throw new Exception("Debe definir una autonumeración para las retenciones a emitir en la cabecera de la OP.");

                                    //Se desglosan los detalles de retencion que se crearan
                                    strAuxFacturas = valoresRows[i].RETENCION_AUX_CASOS.Split('@');
                                    strAuxMontos = valoresRows[i].RETENCION_AUX_MONTOS.Split('@');

                                    // Se crea la cabecera de la retencion 
                                    campos = new Hashtable();
                                    campos.Add(CuentaCorrienteRetencionesEmitidasService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ORIGEN_ID);
                                    campos.Add(CuentaCorrienteRetencionesEmitidasService.MonedaId_NombreCol, valoresRows[i].MONEDA_ORIGEN_ID);
                                    campos.Add(CuentaCorrienteRetencionesEmitidasService.Cotizacion_NombreCol, valoresRows[i].COTIZACION_MONEDA_ORIGEN);
                                    campos.Add(CuentaCorrienteRetencionesEmitidasService.ProveedorId_NombreCol, cabeceraRow.PROVEEDOR_ID);
                                    campos.Add(CuentaCorrienteRetencionesEmitidasService.AutonumeracionId_NombreCol, cabeceraRow.RETENCION_AUTONUMERACION_ID);
                                    campos.Add(CuentaCorrienteRetencionesEmitidasService.Observacion_NombreCol, string.Empty);

                                    #region Actualizar la fecha de la retencion
                                    if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RetencionProveedoresUsarFechaFactura) == Definiciones.SiNo.No)
                                    {
                                        DataTable dtFacturaProveedor = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " = " + strAuxFacturas[0], string.Empty, sesion);
                                        if (CondicionesPagoService.EsContado((decimal)dtFacturaProveedor.Rows[0][FacturasProveedorService.CtacteCondicionPagoId_NombreCol]))
                                            campos.Add(CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol, dtFacturaProveedor.Rows[0][FacturasProveedorService.FechaFactura_NombreCol]);
                                        else
                                            campos.Add(CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol, cabeceraRow.IsFECHA_RECIBO_BENEFICIARIONull ? cabeceraRow.FECHA : cabeceraRow.FECHA_RECIBO_BENEFICIARIO);
                                    }
                                    else
                                    {
                                        campos.Add(CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol, cabeceraRow.IsFECHA_RECIBO_BENEFICIARIONull ? cabeceraRow.FECHA : cabeceraRow.FECHA_RECIBO_BENEFICIARIO);
                                    }
                                    valoresRows[i].RETENCION_FECHA = (DateTime)campos[CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol];
                                    #endregion Actualizar la fecha de la retencion

                                    DataTable dtValores = OrdenesPagoValoresService.GetOrdenesPagoValoresDataTable(OrdenesPagoValoresService.Id_NombreCol + " = " + valoresRows[i].ID, string.Empty);

                                    if (!dtValores.Rows[0][OrdenesPagoValoresService.NroComprobanteRetencion_NombreCol].ToString().Trim().Equals(string.Empty))
                                    {
                                        campos.Add(CuentaCorrienteRetencionesEmitidasService.NroComprobante_NombreCol, dtValores.Rows[i][OrdenesPagoValoresService.NroComprobanteRetencion_NombreCol]);
                                        valoresRows[i].RETENCION_EMITIDA_ID = retencionEmitida.Guardar(cabeceraRow.ID, campos, sesion);
                                    }
                                    else
                                    {
                                        valoresRows[i].RETENCION_EMITIDA_ID = retencionEmitida.Guardar(cabeceraRow.ID, campos, sesion);
                                    }
                                    
                                    // Se crean los detalles de la retencion
                                    for (int indexDetalle = 0; indexDetalle < strAuxFacturas.Length; indexDetalle++)
                                    {
                                        campos = new Hashtable();
                                        campos.Add(CuentaCorrienteRetencionesEmitidasDetalleService.CtacteRetencionEmitidaId_NombreCol, valoresRows[i].RETENCION_EMITIDA_ID);
                                        campos.Add(CuentaCorrienteRetencionesEmitidasDetalleService.RetencionTipoId_NombreCol, valoresRows[i].RETENCION_TIPO_ID);
                                        campos.Add(CuentaCorrienteRetencionesEmitidasDetalleService.Monto_NombreCol, decimal.Parse(strAuxMontos[indexDetalle]));
                                        campos.Add(CuentaCorrienteRetencionesEmitidasDetalleService.CasoId_NombreCol, decimal.Parse(strAuxFacturas[indexDetalle]));
                                        retencion_detalle_id = retencionEmitidaDet.Guardar(campos, sesion);
                                    }

                                    // Se actualiza el id de cabecera y numero de comprobante tomando el dato de la cabecera de retencion
                                    ordenPagoValorEditado = sesion.Db.ORDENES_PAGO_VALORESCollection.GetByPrimaryKey(valoresRows[i].ID);
                                    ordenPagoValorEditado.RETENCION_EMITIDA_ID = valoresRows[i].RETENCION_EMITIDA_ID;
                                    ordenPagoValorEditado.RETENCION_FECHA = valoresRows[i].RETENCION_FECHA;
                                    sesion.Db.ORDENES_PAGO_VALORESCollection.Update(ordenPagoValorEditado);

                                    #endregion Retencion
                                    break;
                                case Definiciones.CuentaCorrienteValores.Ajuste:
                                    #region Ajuste
                                    if (valoresRows[i].MONTO_ORIGEN > 0)
                                    {
                                        CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(cabeceraRow.CTACTE_CAJA_TESO_ORIGEN_ID,
                                                                      Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                                                      string.Empty,
                                                                      cabeceraRow.ID,
                                                                      valoresRows[i].ID,
                                                                      valoresRows[i].CTACTE_VALOR_ID,
                                                                      Definiciones.Error.Valor.EnteroPositivo,
                                                                      valoresRows[i].MONEDA_ORIGEN_ID,
                                                                      valoresRows[i].COTIZACION_MONEDA_ORIGEN,
                                                                      valoresRows[i].MONTO_ORIGEN,
                                                                      cabeceraRow.FECHA,
                                                                      sesion);
                                    }
                                    else
                                    {
                                        CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(cabeceraRow.CTACTE_CAJA_TESO_ORIGEN_ID,
                                                                      Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                                                      string.Empty,
                                                                      cabeceraRow.ID,
                                                                      valoresRows[i].ID,
                                                                      valoresRows[i].CTACTE_VALOR_ID,
                                                                      Definiciones.Error.Valor.EnteroPositivo,
                                                                      valoresRows[i].MONEDA_ORIGEN_ID,
                                                                      valoresRows[i].COTIZACION_MONEDA_ORIGEN,
                                                                      valoresRows[i].MONTO_ORIGEN * (-1),
                                                                      cabeceraRow.FECHA,
                                                                      sesion);
                                    }
                                    #endregion Ajuste
                                    break;
                                case Definiciones.CuentaCorrienteValores.DebitoAutomatico:
                                    #region Debito automatico
                                    CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                                  valoresRows[i].DEBITO_AUTOM_CTACTE_BANC_ID,
                                                  Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                                  cabeceraRow.CASO_ID,
                                                  Definiciones.Error.Valor.EnteroPositivo,
                                                  cabeceraRow.ID,
                                                  valoresRows[i].MONEDA_ORIGEN_ID,
                                                  valoresRows[i].MONTO_ORIGEN * (-1),
                                                  valoresRows[i].COTIZACION_MONEDA_ORIGEN,
                                                  cabeceraRow.FECHA,
                                                  "Caso " + cabeceraRow.CASO_ID + " de " + FlujosService.GetDescripcionImpresion(Definiciones.FlujosIDs.ORDEN_DE_PAGO) + " " + cabeceraRow.NRO_COMPROBANTE + " pasado al estado " + estado_destino + ". Débito automático.",
                                                  null,
                                                  null,
                                                  false,
                                                  sesion);
                                    #endregion Debito automatico
                                    break;
                                default: throw new Exception("Tipo de valor no implementado.");
                            }
                        }
                    }
                }
                #region generacion a aprobado  _new transicion
                //Generacion a Aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Generacion) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones
                    //Principal: revertir los procesos realizados en la transicion aprobado a generacion
                    //Se aumentan los saldos que correspondan segun los 
                    //detalles de valores de pago (e.g. cuentas bancarias, 
                    //efectivo en caja, saldo de NC o anticipo).

                    exito = true;
                    revisarRequisitos = true;

                    if (detalleRows.Length < 1)
                    {
                        mensaje = "Debe agregar al menos un detalle al pago.";
                        exito = false;
                    }

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    int ctacteValor;
                    CuentaCorrienteCajasTesoreriaService ctacteCajaTesoreria = new CuentaCorrienteCajasTesoreriaService();
                    Hashtable campos;

                    //Unicamente estos tipos de OP emiten valores.
                    //Los demas utilizan la OP unicamente como respaldo
                    if (cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAProveedor ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAPersona ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.ReposicionFondoFijo ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.RespaldoAnticipoProveedor ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.AdelantoFuncionario ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoFuncionarios)
                    {
                        #region procesos
                        for (int i = 0; i < valoresRows.Length; i++)
                        {
                            ctacteValor = Convert.ToInt32(valoresRows[i].CTACTE_VALOR_ID);
                            switch (ctacteValor)
                            {
                                case Definiciones.CuentaCorrienteValores.Efectivo:
                                    #region Efectivo
                                    //Se deshace el egreso
                                    CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.ORDEN_DE_PAGO, string.Empty, valoresRows[i].ID, cabeceraRow.CASO_ID, sesion);
                                    #endregion Efectivo
                                    break;
                                case Definiciones.CuentaCorrienteValores.Cheque:
                                    if (valoresRows[i].IsCR_CTACTE_CHEQUE_RECIBIDO_IDNull)
                                    {
                                        #region Cheque girado
                                        //Se anula el cheque
                                        CuentaCorrienteChequesGiradosService.Anular(valoresRows[i].CG_CTACTE_CHEQUE_GIRADO_ID,
                                                                  "Anulado al pasar Orden de Pago caso " + cabeceraRow.CASO_ID + " del estado " + casoRow.ESTADO_ID + " a " + estado_destino + ".",
                                                                  sesion);

                                        //Se afecta la cuenta bancaria si el cheque ya la habia afectado
                                        if (CuentaCorrienteChequesGiradosService.SaldoAfectado(valoresRows[i].CG_CTACTE_CHEQUE_GIRADO_ID, sesion))
                                        {
                                            CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                                  valoresRows[i].CG_CTACTE_BANCARIA_ID,
                                                  Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                                  cabeceraRow.CASO_ID,
                                                  Definiciones.Error.Valor.EnteroPositivo,
                                                  cabeceraRow.ID,
                                                  valoresRows[i].MONEDA_ORIGEN_ID,
                                                  valoresRows[i].MONTO_ORIGEN,
                                                  valoresRows[i].COTIZACION_MONEDA_ORIGEN,
                                                  valoresRows[i].CG_FECHA_VENCIMIENTO,
                                                  "Caso " + cabeceraRow.CASO_ID + " de " + Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.ORDEN_DE_PAGO) + " " + cabeceraRow.NRO_COMPROBANTE + " pasado del estado " + casoRow.ESTADO_ID + " al estado " + estado_destino + ". Anulación del cheque " + valoresRows[i].CG_NUMERO_CHEQUE + " fecha " + valoresRows[i].CG_FECHA_EMISION.Date + ".",
                                                  valoresRows[i].CG_CTACTE_CHEQUE_GIRADO_ID,
                                                  null,
                                                  true,
                                                  sesion);
                                        }
                                        #endregion Cheque girado
                                    }
                                    else
                                    {
                                        #region Cheque recibido

                                        //Se egresa el cheque de la caja de tesoreria
                                        CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.ORDEN_DE_PAGO, string.Empty, valoresRows[i].ID, cabeceraRow.CASO_ID, sesion);
                                        #endregion Cheque recibido
                                    }
                                    break;
                                case Definiciones.CuentaCorrienteValores.TarjetaDeCredito://xyxyxy ver si se implementa  o no si es tarjeta de credito
                                    #region Tarjeta de Crédito
                                    if (valoresRows[i].MONTO_ORIGEN > 0)
                                    {
                                        CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                                                                                        string.Empty,
                                                                                                        valoresRows[i].ID,
                                                                                                        cabeceraRow.CASO_ID,
                                                                                                        sesion);
                                    }
                                    else
                                    {
                                        CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerIngreso(Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                                                                                        string.Empty,
                                                                                                        valoresRows[i].ID,
                                                                                                        cabeceraRow.CASO_ID,
                                                                                                        sesion);
                                    }
                                    #endregion Tarjeta de Crédito
                                    break;
                                case Definiciones.CuentaCorrienteValores.Anticipo:
                                    #region Anticipo
                                    //Deshacer ingreso de debito
                                    CuentaCorrienteProveedoresService.DeshacerAgregarDebitoDesdeOP(valoresRows[i].ID, sesion);

                                    //Se aumenta el saldo
                                    (new AnticiposProveedorService()).AumentarSaldoDisponible(valoresRows[i].ANTICIPO_PROVEEDOR_ID, valoresRows[i].MONTO_ORIGEN, sesion);

                                    #endregion Anticipo
                                    break;
                                case Definiciones.CuentaCorrienteValores.NotaDeCredito:
                                    #region Nota de Credito
                                    //Deshacer ingreso de debito
                                    CuentaCorrienteProveedoresService.DeshacerAgregarDebitoDesdeOP(valoresRows[i].ID, sesion);

                                    //Se aumenta el saldo
                                    (new NotasCreditoProveedorService()).AumentarSaldoDisponible(valoresRows[i].NOTA_CREDITO_PROVEEDOR_ID, valoresRows[i].MONTO_ORIGEN, sesion);

                                    #endregion Nota de Credito
                                    break;
                                case Definiciones.CuentaCorrienteValores.TransferenciaBancaria:
                                    //No se realizan acciones
                                    break;
                                case Definiciones.CuentaCorrienteValores.RetencionRenta:
                                    //No se realizan acciones
                                    break;
                                case Definiciones.CuentaCorrienteValores.RetencionIVA:
                                    //Anular los comprobantes de retencion
                                    CuentaCorrienteRetencionesEmitidasService ctacteRetencionEmitida = new CuentaCorrienteRetencionesEmitidasService();
                                    ctacteRetencionEmitida.Anular(valoresRows[i].RETENCION_EMITIDA_ID, sesion);
                                    break;
                                case Definiciones.CuentaCorrienteValores.Ajuste:
                                    #region Ajuste
                                    if (valoresRows[i].MONTO_ORIGEN > 0)
                                        CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.ORDEN_DE_PAGO, string.Empty, valoresRows[i].ID, cabeceraRow.CASO_ID, sesion);
                                    else
                                        CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerIngreso(Definiciones.FlujosIDs.ORDEN_DE_PAGO, string.Empty, valoresRows[i].ID, cabeceraRow.CASO_ID, sesion);
                                    #endregion Ajuste
                                    break;
                                case Definiciones.CuentaCorrienteValores.DebitoAutomatico:
                                    #region Debito automatico
                                    CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                                 valoresRows[i].DEBITO_AUTOM_CTACTE_BANC_ID,
                                                 Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                                 cabeceraRow.CASO_ID,
                                                 Definiciones.Error.Valor.EnteroPositivo,
                                                 cabeceraRow.ID,
                                                 valoresRows[i].MONEDA_ORIGEN_ID,
                                                 valoresRows[i].MONTO_ORIGEN,
                                                 valoresRows[i].COTIZACION_MONEDA_ORIGEN,
                                                 cabeceraRow.FECHA,
                                                 "Caso " + cabeceraRow.CASO_ID + " de " + FlujosService.GetDescripcionImpresion(Definiciones.FlujosIDs.ORDEN_DE_PAGO) + " " + cabeceraRow.NRO_COMPROBANTE + " pasado al estado " + estado_destino + ". Débito automático.",
                                                 null,
                                                 null,
                                                 true,
                                                 sesion);
                                    #endregion Debito automatico
                                    break;
                                default: throw new Exception("Tipo de valor no implementado.");
                            }
                        }
                        #endregion procesos
                    }

                }
                #endregion generacion a aprobado


                //Generacion a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Generacion) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Se reintegran los valores al lugar de donde provenían y 
                    //se anulan los cheques emitidos (si existen).
                    exito = true;
                    revisarRequisitos = true;

                    int ctacteValor;
                    CuentaCorrienteCajasTesoreriaService ctacteCajaTesoreria = new CuentaCorrienteCajasTesoreriaService();
                    CuentaCorrienteRetencionesEmitidasService ctacteRetencionEmitida = new CuentaCorrienteRetencionesEmitidasService();

                    for (int i = 0; i < valoresRows.Length; i++)
                    {
                        ctacteValor = Convert.ToInt32(valoresRows[i].CTACTE_VALOR_ID);
                        switch (ctacteValor)
                        {
                            case Definiciones.CuentaCorrienteValores.Efectivo:
                                #region Efectivo
                                //Se deshace el egreso
                                CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.ORDEN_DE_PAGO, string.Empty, valoresRows[i].ID, cabeceraRow.CASO_ID, sesion);
                                #endregion Efectivo
                                break;
                            case Definiciones.CuentaCorrienteValores.Cheque:
                                if (valoresRows[i].IsCR_CTACTE_CHEQUE_RECIBIDO_IDNull)
                                {
                                    #region Cheque girado
                                    //Se anula el cheque
                                    CuentaCorrienteChequesGiradosService.Anular(valoresRows[i].CG_CTACTE_CHEQUE_GIRADO_ID,
                                                              "Anulado al pasar Orden de Pago caso " + cabeceraRow.CASO_ID + " del estado " + casoRow.ESTADO_ID + " a " + estado_destino + ".",
                                                              sesion);

                                    //Se afecta la cuenta bancaria si el cheque ya la habia afectado
                                    if (CuentaCorrienteChequesGiradosService.SaldoAfectado(valoresRows[i].CG_CTACTE_CHEQUE_GIRADO_ID, sesion))
                                    {
                                        CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                              valoresRows[i].CG_CTACTE_BANCARIA_ID,
                                              Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                              cabeceraRow.CASO_ID,
                                              Definiciones.Error.Valor.EnteroPositivo,
                                              cabeceraRow.ID,
                                              valoresRows[i].MONEDA_ORIGEN_ID,
                                              valoresRows[i].MONTO_ORIGEN,
                                              valoresRows[i].COTIZACION_MONEDA_ORIGEN,
                                              valoresRows[i].CG_FECHA_VENCIMIENTO,
                                              "Caso " + cabeceraRow.CASO_ID + " de " + Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.ORDEN_DE_PAGO) + " " + cabeceraRow.NRO_COMPROBANTE + " pasado del estado " + casoRow.ESTADO_ID + " al estado " + estado_destino + ". Anulación del cheque " + valoresRows[i].CG_NUMERO_CHEQUE + " fecha " + valoresRows[i].CG_FECHA_EMISION.Date + ".",
                                              valoresRows[i].CG_CTACTE_CHEQUE_GIRADO_ID,
                                              null,
                                              true,
                                              sesion);
                                    }
                                    #endregion Cheque girado
                                }
                                else
                                {
                                    #region Cheque recibido

                                    //Se egresa el cheque de la caja de tesoreria
                                    CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.ORDEN_DE_PAGO, string.Empty, valoresRows[i].ID, cabeceraRow.CASO_ID, sesion);
                                    #endregion Cheque recibido
                                }
                                break;
                            case Definiciones.CuentaCorrienteValores.TarjetaDeCredito:
                                throw new Exception("OrdenesPagoService.ProcesarCambioEstado. Tipo de valor no implementado: Tarjeta de Credito.");
                            case Definiciones.CuentaCorrienteValores.Anticipo:
                                #region Anticipo
                                //Deshacer ingreso de debito
                                CuentaCorrienteProveedoresService.DeshacerAgregarDebitoDesdeOP(valoresRows[i].ID, sesion);

                                //Se aumenta el saldo
                                (new AnticiposProveedorService()).AumentarSaldoDisponible(valoresRows[i].ANTICIPO_PROVEEDOR_ID, valoresRows[i].MONTO_ORIGEN, sesion);

                                #endregion Anticipo
                                break;
                            case Definiciones.CuentaCorrienteValores.NotaDeCredito:
                                #region Nota de Credito
                                //Deshacer ingreso de debito
                                CuentaCorrienteProveedoresService.DeshacerAgregarDebitoDesdeOP(valoresRows[i].ID, sesion);

                                //Se aumenta el saldo
                                (new NotasCreditoProveedorService()).AumentarSaldoDisponible(valoresRows[i].NOTA_CREDITO_PROVEEDOR_ID, valoresRows[i].MONTO_ORIGEN, sesion);

                                #endregion Nota de Credito
                                break;
                            case Definiciones.CuentaCorrienteValores.TransferenciaBancaria:
                                #region Transferencia Bancaria

                                //No se realizan acciones

                                #endregion Transferencia Bancaria

                                break;
                            case Definiciones.CuentaCorrienteValores.RetencionIVA:
                                //Anular los comprobantes de retencion
                                ctacteRetencionEmitida.Anular(valoresRows[i].RETENCION_EMITIDA_ID, sesion);
                                break;
                            case Definiciones.CuentaCorrienteValores.Ajuste:
                                #region Ajuste
                                if (valoresRows[i].MONTO_ORIGEN > 0)
                                    CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.ORDEN_DE_PAGO, string.Empty, valoresRows[i].ID, cabeceraRow.CASO_ID, sesion);
                                else
                                    CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerIngreso(Definiciones.FlujosIDs.ORDEN_DE_PAGO, string.Empty, valoresRows[i].ID, cabeceraRow.CASO_ID, sesion);
                                #endregion Ajuste
                                break;
                            case Definiciones.CuentaCorrienteValores.DebitoAutomatico:
                                CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                                  valoresRows[i].DEBITO_AUTOM_CTACTE_BANC_ID,
                                                  Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                                  cabeceraRow.CASO_ID,
                                                  Definiciones.Error.Valor.EnteroPositivo,
                                                  cabeceraRow.ID,
                                                  valoresRows[i].MONEDA_ORIGEN_ID,
                                                  valoresRows[i].MONTO_ORIGEN,
                                                  valoresRows[i].COTIZACION_MONEDA_ORIGEN,
                                                  cabeceraRow.FECHA,
                                                  "Caso " + cabeceraRow.CASO_ID + " de " + FlujosService.GetDescripcionImpresion(Definiciones.FlujosIDs.ORDEN_DE_PAGO) + " " + cabeceraRow.NRO_COMPROBANTE + " pasado al estado " + estado_destino + ". Débito automático.",
                                                  null,
                                                  null,
                                                  true,
                                                  sesion);
                                break;
                            default: throw new Exception("Tipo de valor no implementado.");
                        }
                    }
                    //Se quita la asociación entre la planilla de salario y detalle
                    if (cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoFuncionarios ||
                        cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAProveedor)
                    {
                        for (int j = 0; j < detalleRows.Length; j++)
                        {
                            if (!detalleRows[j].IsLIQUIDACION_IDNull)
                            {
                                detalleRows[j].IsLIQUIDACION_IDNull = true;
                                sesion.Db.ORDENES_PAGO_DETCollection.Update(detalleRows[j]);
                            }
                        }
                    }
                    else if (cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAPersona)
                    {
                        //se borran las referencias de los detalles a la cuenta corriente en caso de que exista, de tal manera a no bloquear la eliminacion de la ctacte persona
                        DataTable detalles = OrdenesPagoDetalleService.GetOrdenesPagoDetallesDataTable2(OrdenesPagoDetalleService.OrdenPagoId_NombreCol + " = " + cabeceraRow.ID, string.Empty, sesion);
                        foreach (DataRow dr in detalles.Rows)
                        {
                            OrdenesPagoDetalleService.QuitarReferenciaACtaCtePersona(decimal.Parse(dr[OrdenesPagoDetalleService.Id_NombreCol].ToString()));
                        }
                    }
                }
                //Generacion a Cerrado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Generacion) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                {
                    //Acciones
                    //Segun sea el tipo de OP, se da ingreso a los valores 
                    //a la caja de tesorería correspondiente, al fondo fijo, etc. 
                    //De ser un pago de facturas a proveedor se actualiza la cuenta corriente.
                    //Si el saldo de una FC de proveedor llega a cero el caso es cerrado
                    //Si existen, se cambia de estado a los casos respaldados.

                    exito = true;
                    revisarRequisitos = true;

                    bool exitoCasoAsociado;
                    string msgCasoAsociado;
                    int tipoOP = Convert.ToInt32(cabeceraRow.ORDEN_PAGO_TIPO_ID);
                    var lCasosPlanillaSalarioACerrar = new List<decimal>();

                    for (int i = 0; i < detalleRows.Length; i++)
                    {
                        switch (tipoOP)
                        {
                            case Definiciones.TiposOrdenesPago.ReposicionFondoFijo:
                                #region ReposicionFondoFijo
                                CuentaCorrienteFondosFijosMovimientosService ctacteFondoFijoMov = new CuentaCorrienteFondosFijosMovimientosService();

                                ctacteFondoFijoMov.Ingreso(detalleRows[i].CTACTE_FONDO_FIJO_ID,
                                                           Definiciones.Error.Valor.EnteroPositivo,
                                                           Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                                           detalleRows[i].ORDEN_PAGO_ID,
                                                           detalleRows[i].MONTO_DESTINO,
                                                           cabeceraRow.COTIZACION_MONEDA,
                                                           "Ingreso por Orden de Pago caso " + cabeceraRow.CASO_ID + " pasado al estado " + estado_destino + ".",
                                                           cabeceraRow.FECHA,
                                                           sesion);
                                #endregion ReposicionFondoFijo
                                break;
                            case Definiciones.TiposOrdenesPago.PagoAProveedor:
                                #region PagoAProveedor
                                dtCtacteProveedor = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresInfoCompleta(CuentaCorrienteProveedoresService.Id_NombreCol + " = " + detalleRows[i].CTACTE_PROVEEDOR_ID, string.Empty, sesion);
                                decimal deudaMovimiento = (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.Credito_NombreCol] - (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.Debito_NombreCol];

                                if (Math.Round(detalleRows[i].MONTO_ORIGEN, 4) > Math.Round(deudaMovimiento, 4))
                                    throw new Exception("No pueden descontarse " + detalleRows[i].MONTO_ORIGEN + " ya que el movimiento actualmente tiene una deuda de " + deudaMovimiento + ".");

                                CuentaCorrienteProveedoresService.AgregarDebito(cabeceraRow.PROVEEDOR_ID,
                                                detalleRows[i].CTACTE_PROVEEDOR_ID,
                                                Definiciones.CuentaCorrienteConceptos.DebitoPorFlujo,
                                                Definiciones.CuentaCorrienteValores.OrdenDePago,
                                                cabeceraRow.CASO_ID,
                                                detalleRows[i].MONEDA_ORIGEN_ID,
                                                detalleRows[i].MONTO_ORIGEN,
                                                string.Empty,
                                                cabeceraRow.IsFECHA_RECIBO_BENEFICIARIONull ? cabeceraRow.FECHA : cabeceraRow.FECHA_RECIBO_BENEFICIARIO,
                                                cabeceraRow.ID,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                sesion);

                                switch (int.Parse(dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.VistaFlujoId_NombreCol].ToString()))
                                {
                                    case Definiciones.FlujosIDs.CREDITOS_PROVEEDOR:
                                        DataTable dtCredito = CreditosProveedorService.GetCreditosProveedorDataTable(CreditosProveedorService.CasoId_NombreCol + " = " + dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.CasoId_NombreCol], string.Empty, sesion);
                                        DataTable dtCreditoDet = CreditosProveedorDetalleService.GetCreditosProveedorDetalleDataTable(CreditosProveedorDetalleService.Id_NombreCol + " = " + dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.CreditoProveedorDetId_NombreCol], string.Empty);
                                        decimal relacionInteresCapital = 0;

                                        if ((decimal)dtCreditoDet.Rows[0][CreditosProveedorDetalleService.MontoCapital_NombreCol] != 0)
                                            relacionInteresCapital = (decimal)dtCreditoDet.Rows[0][CreditosProveedorDetalleService.MontoInteres_NombreCol] / (decimal)dtCreditoDet.Rows[0][CreditosProveedorDetalleService.MontoCapital_NombreCol];

                                        CreditosProveedorService.EmitirFactura((decimal)dtCredito.Rows[0][CreditosProveedorService.Id_NombreCol],
                                                                               (1 - relacionInteresCapital) * detalleRows[i].MONTO_ORIGEN,
                                                                               relacionInteresCapital * detalleRows[i].MONTO_ORIGEN,
                                                                               cabeceraRow.FECHA,
                                                                               "Factura correspondiente a pago de Crédito de Proveedor caso " + dtCredito.Rows[0][CreditosProveedorService.CasoId_NombreCol] + " con la Orden de Pago caso " + cabeceraRow.CASO_ID + ".",
                                                                               sesion);

                                        break;
                                }

                                //detalle asociado a una liquidación de salario
                                if (!detalleRows[i].IsLIQUIDACION_IDNull)
                                {
                                    decimal planillaId = (decimal)FuncionariosLiquidacionesService.GetLiquidacionesStaticDataTable(FuncionariosLiquidacionesService.Id_NombreCol + " = " + detalleRows[i].LIQUIDACION_ID).Rows[0][FuncionariosLiquidacionesService.PlanillaSalarioId_NombreCol];
                                    decimal planillaCasoId = (decimal)PlanillaLiquidacionesService.GetPlanilaLiquidacionesDataTable(PlanillaLiquidacionesService.Id_NombreCol + " = " + planillaId, string.Empty).Rows[0][PlanillaLiquidacionesService.CasoId_NombreCol];

                                    bool puedeCerrar = PlanillaLiquidacionesService.PuedeCerrarPlanilla(planillaCasoId, cabeceraRow.CASO_ID, sesion);
                                    //Si todas las OP que asociadas a una planilla de pago estan cerradas
                                    //entonces debe cerrarse el caso de planilla
                                    if (puedeCerrar)
                                    {
                                        exitoCasoAsociado = (new PlanillaLiquidacionesService()).ProcesarCambioEstado(planillaCasoId, Definiciones.EstadosFlujos.Cerrado, false, out msgCasoAsociado, sesion);
                                        if (exitoCasoAsociado)
                                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(planillaCasoId, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso de la Orden de Pago caso " + cabeceraRow.CASO_ID + " al estado " + estado_destino + ".", sesion);
                                        if (exitoCasoAsociado)
                                            (new PlanillaLiquidacionesService()).EjecutarAccionesLuegoDeCambioEstado(planillaCasoId, Definiciones.EstadosFlujos.Cerrado, sesion);
                                        if (!exitoCasoAsociado)
                                            throw new Exception("Error en OrdenesPago.CambioEstado().PlanillaLiquidacionesService.ProcesarCambioEstado(). Pago a Proveedor");
                                    }
                                }
                                #endregion PagoAProveedor
                                break;
                            case Definiciones.TiposOrdenesPago.PagoAPersona:
                                #region PagoAPersona
                                decimal saldoMovimiento = CuentaCorrientePersonasService.GetSaldoDeMovimiento(detalleRows[i].CTACTE_PERSONA_ID, sesion);
                                int flujoId;

                                DataTable dtCtactePersonaDet, dtCtactePersona;
                                System.Collections.Hashtable montoPorImpuesto = new System.Collections.Hashtable();
                                decimal[] impuestoId, monto;
                                int indiceAux;
                                decimal montoVerificacion, montoTotalDocumento, relacionEntrePagoYTotal;

                                if (detalleRows[i].MONTO_ORIGEN > saldoMovimiento)
                                    throw new Exception("No pueden acreditarse " + detalleRows[i].MONTO_ORIGEN + " ya que el movimiento actualmente tiene un saldo de " + saldoMovimiento + ".");

                                #region Calcular monto por tipo de impuesto

                                //Se obtiene el registro de la cuenta corriente de la persona
                                dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.Id_NombreCol + " = " + (decimal)detalleRows[i].CTACTE_PERSONA_ID, string.Empty, sesion);
                                montoTotalDocumento = (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol];
                                relacionEntrePagoYTotal = detalleRows[i].MONTO_ORIGEN / montoTotalDocumento;

                                dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable((decimal)detalleRows[i].CTACTE_PERSONA_ID, sesion);

                                for (int k = 0; k < dtCtactePersonaDet.Rows.Count; k++)
                                {
                                    if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                                        montoPorImpuesto[dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + (decimal)dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.Monto_NombreCol] * relacionEntrePagoYTotal;
                                    else
                                        montoPorImpuesto.Add(dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], (decimal)dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.Monto_NombreCol] * relacionEntrePagoYTotal);
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

                                if (Math.Round(detalleRows[i].MONTO_ORIGEN) != Math.Round(montoVerificacion))
                                    throw new Exception("Error en TransferenciasCtaCtePersonasService.ProcesarCambioEstado(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + cabeceraRow.MONTO_TOTAL + ".");
                                #endregion Calcular monto por tipo de impuesto

                                CuentaCorrientePersonasService.AgregarCredito(cabeceraRow.PERSONA_ID,
                                                detalleRows[i].CTACTE_PERSONA_ID,
                                                Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                cabeceraRow.CASO_ID,
                                                detalleRows[i].MONEDA_ORIGEN_ID,
                                                detalleRows[i].COTIZACION_MONEDA_ORIGEN,
                                                impuestoId,
                                                monto,
                                                string.Empty,
                                                DateTime.Now,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                cabeceraRow.ID,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                1,
                                                1,
                                                sesion);

                                flujoId = int.Parse(detalleRows[i].FLUJO_REFERIDO_ID.ToString());
                                switch (flujoId)
                                {
                                    case Definiciones.FlujosIDs.ANTICIPO_PERSONA:
                                        //Se disminuye el saldo
                                        DataTable dtAnticipoPersona = AnticiposPersonaService.GetAnticipoPersonaDataTable(AnticiposPersonaService.CasoId_NombreCol + " = " + detalleRows[i].CASO_REFERIDO_ID, string.Empty);
                                        AnticiposPersonaService.DisminuirSaldoDisponible((decimal)dtAnticipoPersona.Rows[0][AnticiposPersonaService.Id_NombreCol], detalleRows[i].MONTO_ORIGEN, true, sesion);
                                        break;
                                    case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:
                                        //Se disminuye el saldo
                                        DataTable dtNotaCreditoPersona = NotasCreditoPersonaService.GetNotaCreditoPersonaDataTable(NotasCreditoPersonaService.CasoId_NombreCol + " = " + detalleRows[i].CASO_REFERIDO_ID, string.Empty);
                                        NotasCreditoPersonaService.DisminuirSaldoDisponible((decimal)dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.Id_NombreCol], detalleRows[i].MONTO_ORIGEN, true, sesion);
                                        break;
                                    case Definiciones.FlujosIDs.CREDITOS:
                                        //Una vez que se haya finalizado el desembolso por el credito, el mismo debe pasar a En-Proceso
                                        //Esa accion es realizada en el metodo EjecutarAccionesLuegoDeCAmbioEstado
                                        break;
                                    case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES:
                                        //Una vez que se haya finalizado el desembolso por el credito, el mismo debe pasar a En-Proceso
                                        //Esa accion es realizada en el metodo EjecutarAccionesLuegoDeCAmbioEstado
                                        break;
                                    default:
                                        throw new Exception("Error en OrdenesPagoService.ProcesarCambioEstado(). Flujo no implementado para devolución a persona.");
                                }
                                #endregion PagoAPersona
                                break;
                            case Definiciones.TiposOrdenesPago.RespaldoAjusteBancario:
                                #region RespaldoAjusteBancario
                                decimal deudaMovimientoAjusteBancario = CuentaCorrienteProveedoresService.GetDeudaDeMovimiento(detalleRows[i].CTACTE_PROVEEDOR_ID, sesion);

                                if (detalleRows[i].MONTO_ORIGEN > deudaMovimientoAjusteBancario)
                                    throw new Exception("No pueden descontarse " + detalleRows[i].MONTO_ORIGEN + " ya que el movimiento actualmente tiene una deuda de " + deudaMovimientoAjusteBancario + ".");

                                //Se afecta la ctacte del proveedor
                                CuentaCorrienteProveedoresService.AgregarDebito(cabeceraRow.PROVEEDOR_ID,
                                                detalleRows[i].CTACTE_PROVEEDOR_ID,
                                                Definiciones.CuentaCorrienteConceptos.DebitoPorFlujo,
                                                Definiciones.CuentaCorrienteValores.OrdenDePago,
                                                cabeceraRow.CASO_ID,
                                                detalleRows[i].MONEDA_ORIGEN_ID,
                                                detalleRows[i].MONTO_ORIGEN,
                                                string.Empty,
                                                DateTime.Now,
                                                cabeceraRow.ID,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                sesion);
                                #endregion RespaldoAjusteBancario
                                break;
                            case Definiciones.TiposOrdenesPago.RespaldoAnticipoProveedor:
                                #region RespaldoAnticipoProveedor
                                exitoCasoAsociado = (new AnticiposProveedorService()).ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Aplicacion, false, out msgCasoAsociado, sesion);
                                if (exitoCasoAsociado)
                                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Aplicacion, "Transición automática por paso de la Orden de Pago caso " + detalleRows[i].CASO_REFERIDO_ID + " al estado " + estado_destino + ".", sesion);
                                if (exitoCasoAsociado)
                                    (new AnticiposProveedorService()).EjecutarAccionesLuegoDeCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Aplicacion, sesion);
                                #endregion RespaldoAnticipoProveedor
                                break;
                            case Definiciones.TiposOrdenesPago.RespaldoCambioDivisa:
                                //Como accion *posterior* al cambio de estado se cambia
                                //el estado de los casos Cambio de Divisa a Aprobado
                                break;
                            case Definiciones.TiposOrdenesPago.RespaldoCustodiaValores:
                                #region RespaldoCustodiaValores
                                exitoCasoAsociado = (new CustodiaValoresService()).ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Aprobado, false, out msgCasoAsociado, sesion);
                                if (exitoCasoAsociado)
                                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Aprobado, "Transición automática por paso de la Orden de Pago caso " + detalleRows[i].CASO_REFERIDO_ID + " al estado " + estado_destino + ".", sesion);
                                if (exitoCasoAsociado)
                                    (new CustodiaValoresService()).EjecutarAccionesLuegoDeCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Aprobado, sesion);
                                #endregion RespaldoCustodiaValores
                                break;
                            case Definiciones.TiposOrdenesPago.RespaldoDescuentoDocumentos:
                                #region RespaldoDescuentoDocumentos
                                exitoCasoAsociado = (new DescuentoDocumentosService()).ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Cerrado, false, out msgCasoAsociado, sesion);
                                if (exitoCasoAsociado)
                                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso de la Orden de Pago caso " + detalleRows[i].CASO_REFERIDO_ID + " al estado " + estado_destino + ".", sesion);
                                if (exitoCasoAsociado)
                                    (new DescuentoDocumentosService()).EjecutarAccionesLuegoDeCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);
                                #endregion RespaldoDescuentoDocumentos
                                break;
                            case Definiciones.TiposOrdenesPago.RespaldoTransferenciaBancaria:
                                //La OP no hace cambiar el estado
                                break;
                            case Definiciones.TiposOrdenesPago.RespaldoTransferenciaTesoreria:
                                throw new Exception("OrdenesPagoService.ProcesarCambioEstado(). Flujo Transferencia Cajas de Tesoreria no implementado");
                            case Definiciones.TiposOrdenesPago.AdelantoFuncionario:
                                #region AdelantoFuncionario
                                exitoCasoAsociado = (new FuncionarioAdelantoService()).ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Cerrado, false, out msgCasoAsociado, sesion);
                                if (exitoCasoAsociado)
                                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso de la Orden de Pago caso " + cabeceraRow.CASO_ID + " al estado " + estado_destino + ".", sesion);
                                if (exitoCasoAsociado)
                                    (new FuncionarioAdelantoService()).EjecutarAccionesLuegoDeCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);
                                #endregion AdelantoFuncionario
                                break;
                            case Definiciones.TiposOrdenesPago.PagoFuncionarios:
                                #region PagoFuncionarios
                                //detalle asociado a una liquidación de salario
                                if (!detalleRows[i].IsCASO_REFERIDO_IDNull)
                                {
                                    //Si todas las OP que asociadas a una planilla de pago estan cerradas
                                    //entonces debe cerrarse el caso de planilla
                                    bool puedeCerrar = PlanillaLiquidacionesService.PuedeCerrarPlanilla(detalleRows[i].CASO_REFERIDO_ID, cabeceraRow.CASO_ID, sesion);
                                    if (puedeCerrar && !lCasosPlanillaSalarioACerrar.Contains(detalleRows[i].CASO_REFERIDO_ID))
                                        lCasosPlanillaSalarioACerrar.Add(detalleRows[i].CASO_REFERIDO_ID);
                                }
                                //Si el detalle es una factura de proveedor asociada al pago de salario
                                else
                                {
                                    throw new Exception("OrdenesPagoService.ProcesarCambioEstado(). Pago proveedor en Orden de Pago tipo Pago a Funcionario.");
                                }
                                #endregion PagoFuncionarios
                                break;
                        }
                    }

                    foreach (var casoId in lCasosPlanillaSalarioACerrar)
                    {
                        exitoCasoAsociado = (new PlanillaLiquidacionesService()).ProcesarCambioEstado(casoId, Definiciones.EstadosFlujos.Cerrado, false, out msgCasoAsociado, sesion);
                        if (exitoCasoAsociado)
                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoId, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso de la Orden de Pago caso " + cabeceraRow.CASO_ID + " al estado " + estado_destino + ".", sesion);
                        if (exitoCasoAsociado)
                            (new PlanillaLiquidacionesService()).EjecutarAccionesLuegoDeCambioEstado(casoId, Definiciones.EstadosFlujos.Cerrado, sesion);
                        if (!exitoCasoAsociado)
                            throw new Exception("Error en OrdenesPago.CambioEstado().PlanillaLiquidacionesService.ProcesarCambioEstado(). Pago a Funcionario.");
                    }

                    //TODO: Comentario de Uri: no me parece logico el codigo a continuacion en este punto de ejecucion
                    //Se pasan a aprobado los casos de ajuste bancario cuando la OP es del tipo Repaldo Ajuste Bancario
                    if (cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.RespaldoAjusteBancario)
                    {
                        for (int i = 0; i < valoresRows.Length; i++)
                        {
                            exitoCasoAsociado = (new AjustesBancariosService()).ProcesarCambioEstado(valoresRows[i].AJUSTE_BANCARIO_CASO_ID, Definiciones.EstadosFlujos.Cerrado, false, out msgCasoAsociado, sesion);
                            if (exitoCasoAsociado)
                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(valoresRows[i].AJUSTE_BANCARIO_CASO_ID, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso de la Orden de Pago caso " + caso_id + " al estado " + estado_destino + ".", sesion);
                        }
                    }
                }

                //Cerrado a Generacion
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Cerrado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Generacion))
                {
                    //Acciones
                    //Si es pago a proveedores, se deshace el pago sobre los documentos
                    //Si es reposicion de fondo fijo, se egresa el efectivo del FF
                    exito = true;
                    revisarRequisitos = true;

                    if (cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAProveedor)
                    {
                        //Actualizar la cuenta corriente del proveedor
                        for (int i = 0; i < detalleRows.Length; i++)
                        {
                            CuentaCorrienteProveedoresService.DeshacerPagarCredito(detalleRows[i].CTACTE_PROVEEDOR_ID, cabeceraRow.CASO_ID, sesion);

                            //detalle asociado a una liquidación de salario
                            if (!detalleRows[i].IsLIQUIDACION_IDNull)
                            {
                                decimal planillaId = (decimal)FuncionariosLiquidacionesService.GetLiquidacionesStaticDataTable(FuncionariosLiquidacionesService.Id_NombreCol + " = " + detalleRows[i].LIQUIDACION_ID).Rows[0][FuncionariosLiquidacionesService.PlanillaSalarioId_NombreCol];
                                decimal planillaCasoId = (decimal)PlanillaLiquidacionesService.GetPlanilaLiquidacionesDataTable(PlanillaLiquidacionesService.Id_NombreCol + " = " + planillaId, string.Empty).Rows[0][PlanillaLiquidacionesService.CasoId_NombreCol];

                                bool exitoCasoAsociado;
                                string msgCasoAsociado;

                                exitoCasoAsociado = (new PlanillaLiquidacionesService()).ProcesarCambioEstado(planillaCasoId, Definiciones.EstadosFlujos.Aprobado, false, out msgCasoAsociado, sesion);
                                if (exitoCasoAsociado)
                                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(planillaCasoId, Definiciones.EstadosFlujos.Aprobado, "Transición automática por paso de la Orden de Pago caso " + cabeceraRow.CASO_ID + " al estado " + estado_destino + ".", sesion);
                                if (exitoCasoAsociado)
                                    (new PlanillaLiquidacionesService()).EjecutarAccionesLuegoDeCambioEstado(planillaCasoId, Definiciones.EstadosFlujos.Cerrado, sesion);
                                if (!exitoCasoAsociado)
                                    throw new Exception("Error en OrdenesPago.CambioEstado().PlanillaLiquidacionesService.ProcesarCambioEstado(). Pago a Proveedor");
                            }
                        }
                    }
                    else if(cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.ReposicionFondoFijo)
                    {
                        CuentaCorrienteFondosFijosMovimientosService ctacteFondoFijoMov = new CuentaCorrienteFondosFijosMovimientosService();
                        for (int i = 0; i < detalleRows.Length; i++)
                        {
                            ctacteFondoFijoMov.Egreso(detalleRows[i].CTACTE_FONDO_FIJO_ID, Definiciones.Error.Valor.EnteroPositivo,
                                                      Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                                                      detalleRows[i].ORDEN_PAGO_ID,
                                                      detalleRows[i].MONTO_DESTINO,
                                                      cabeceraRow.COTIZACION_MONEDA,
                                                      "Egreso por Orden de Pago caso " + cabeceraRow.CASO_ID + " pasado del estado " + casoRow.ESTADO_ID + " a " + estado_destino + ".",
                                                      cabeceraRow.FECHA,
                                                      sesion);
                        }
                    }
                    else if(cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.RespaldoAnticipoProveedor)
                    {
                        //Se pasa el Anticipo a Aprobado en las acciones posteriores al cambio de estado
                    }
                    else if (cabeceraRow.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoFuncionarios)
                    {
                        for (int i = 0; i < detalleRows.Length; i++)
                        {
                            if (!detalleRows[i].IsCASO_REFERIDO_IDNull)
                            {
                                bool exitoCasoAsociado;
                                string msgCasoAsociado;

                                exitoCasoAsociado = (new PlanillaLiquidacionesService()).ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Aprobado, false, out msgCasoAsociado, sesion);
                                if (exitoCasoAsociado)
                                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Aprobado, "Transición automática por paso de la Orden de Pago caso " + cabeceraRow.CASO_ID + " al estado " + estado_destino + ".", sesion);
                                if (exitoCasoAsociado)
                                    (new PlanillaLiquidacionesService()).EjecutarAccionesLuegoDeCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);
                                if (!exitoCasoAsociado)
                                    throw new Exception("Error en OrdenesPago.CambioEstado().PlanillaLiquidacionesService.ProcesarCambioEstado(). Pago a Funcionario.");
                            }
                            else
                            {
                                if (!detalleRows[i].IsCTACTE_PROVEEDOR_IDNull)
                                    throw new Exception("El pago a funcionario tiene asociado una factura proveedor.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("La OP de tipo " + OrdenesPagoTipoService.GetOrdenesPagoTipoDataTable(OrdenesPagoTipoService.Id_NombreCol + " = " + cabeceraRow.ORDEN_PAGO_TIPO_ID, string.Empty).Rows[0][OrdenesPagoTipoService.Nombre_NombreCol] + " no puede ser revertida.");
                    }

                    //Borrar el asiento que se creo cuando se aprobo el pago
                    CBA.FlowV2.Services.Contabilidad.AsientosService.BorrarPorCasoYTransicion(
                    cabeceraRow.CASO_ID,
                    TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.ORDEN_DE_PAGO, Definiciones.EstadosFlujos.Generacion, Definiciones.EstadosFlujos.Cerrado, sesion),
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
                    sesion.Db.ORDENES_PAGOCollection.Update(cabeceraRow);
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
                ORDENES_PAGORow cabeceraRow = sesion.Db.ORDENES_PAGOCollection.GetByCASO_ID(caso_id)[0];
                ORDENES_PAGO_DETRow[] detalleRows = sesion.Db.ORDENES_PAGO_DETCollection.GetByORDEN_PAGO_ID(cabeceraRow.ID);
                string msg;
                bool exitoCasoAsociado;

                int tipoOP = Convert.ToInt32(cabeceraRow.ORDEN_PAGO_TIPO_ID);
                int flujoId;
                decimal casoReferidoId;

                //Lista tabu para evitar tratar de cambiar de estado mas de una vez
                //un mismo caso por estar incluidas 2 o mas cuotas del mismo
                List<decimal> casosYaProcesados = new List<decimal>();

                //Generacion a Cerrado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Cerrado) &&
                    casoRow.ESTADO_ANTERIOR_ID.Equals(Definiciones.EstadosFlujos.Generacion))
                {
                    for (int i = 0; i < detalleRows.Length; i++)
                    {
                        switch (tipoOP)
                        {
                            case Definiciones.TiposOrdenesPago.ReposicionFondoFijo:
                                break;
                            case Definiciones.TiposOrdenesPago.PagoAProveedor:
                                decimal deudaMovimiento = CuentaCorrienteProveedoresService.GetDeudaTotal(detalleRows[i].CTACTE_PROVEEDOR_ID, sesion);

                                //Cerrar la FC de Proveedor si el saldo es cero
                                if (Math.Round(deudaMovimiento, 4) == 0)
                                {
                                    DataTable dtCtacteProv = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresInfoCompleta(CuentaCorrienteProveedoresService.Id_NombreCol + " = " + detalleRows[i].CTACTE_PROVEEDOR_ID, string.Empty);
                                    casoReferidoId = (decimal)dtCtacteProv.Rows[0][CuentaCorrienteProveedoresService.CasoId_NombreCol];
                                    flujoId = int.Parse(dtCtacteProv.Rows[0][CuentaCorrienteProveedoresService.VistaFlujoId_NombreCol].ToString());

                                    //Lista tabu para evitar tratar de cambiar de estado mas de una vez
                                    //un mismo caso por estar incluidas 2 o mas cuotas del mismo
                                    if (casosYaProcesados.Contains(casoReferidoId))
                                        continue;
                                    else
                                        casosYaProcesados.Add(casoReferidoId);

                                    switch (flujoId)
                                    {
                                        case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                                            exitoCasoAsociado = (new FacturasProveedorService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, false, out msg, sesion);
                                            if (exitoCasoAsociado)
                                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso de la Orden de Pago caso " + cabeceraRow.CASO_ID + " al estado " + casoRow.ESTADO_ID + ".", sesion);
                                            if (exitoCasoAsociado)
                                                (new FacturasProveedorService()).EjecutarAccionesLuegoDeCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);
                                            if (!exitoCasoAsociado)
                                                throw new Exception("Error en OrdenesPagoService.EjecutarAccionesLuegoDeCambioEstado(), FC Proveedor. " + msg + ".");
                                            break;
                                        case Definiciones.FlujosIDs.NOTA_DEBITO_PROVEEDOR:
                                            exitoCasoAsociado = (new NotasDebitoProveedorService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, false, out msg, sesion);
                                            if (exitoCasoAsociado)
                                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso de la Orden de Pago caso " + cabeceraRow.CASO_ID + " al estado " + casoRow.ESTADO_ID + ".", sesion);
                                            if (exitoCasoAsociado)
                                                (new NotasDebitoProveedorService()).EjecutarAccionesLuegoDeCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);
                                            if (!exitoCasoAsociado)
                                                throw new Exception("Error en OrdenesPagoService.EjecutarAccionesLuegoDeCambioEstado(), ND Proveedor. " + msg + ".");
                                            break;
                                        case Definiciones.FlujosIDs.CREDITOS_PROVEEDOR:
                                            exitoCasoAsociado = (new CreditosProveedorService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, false, out msg, sesion);
                                            if (exitoCasoAsociado)
                                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                                            if (exitoCasoAsociado)
                                                (new NotasDebitoProveedorService()).EjecutarAccionesLuegoDeCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);
                                            if (!exitoCasoAsociado)
                                                throw new Exception("Error en OrdenesPagoService.EjecutarAccionesLuegoDeCambioEstado(), Crédito Proveedor. " + msg + ".");
                                            break;
                                        default:
                                            throw new Exception("Error en OrdenesPagoService.EjecutarAccionesLuegoDeCambioEstado(). Flujo no implementado para pago a proveedor.");
                                    }
                                }
                                break;
                            case Definiciones.TiposOrdenesPago.PagoAPersona:
                                decimal saldoMovimiento = CuentaCorrientePersonasService.GetSaldoDeMovimiento(detalleRows[i].CTACTE_PERSONA_ID, sesion);

                                //Cerrar la FC de Proveedor si el saldo es cero
                                if (Math.Round(saldoMovimiento, 4) == 0)
                                {
                                    DataTable dtCtactePers = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.Id_NombreCol + " = " + detalleRows[i].CTACTE_PERSONA_ID, string.Empty, sesion);
                                    casoReferidoId = (decimal)dtCtactePers.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol];
                                    flujoId = int.Parse(dtCtactePers.Rows[0][CuentaCorrientePersonasService.VistaFlujoId_NombreCol].ToString());

                                    switch (flujoId)
                                    {
                                        case Definiciones.FlujosIDs.ANTICIPO_PERSONA:
                                            exitoCasoAsociado = (new AnticiposPersonaService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, false, out msg, sesion);
                                            if (exitoCasoAsociado)
                                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso de la Orden de Pago caso " + cabeceraRow.CASO_ID + " al estado " + casoRow.ESTADO_ID + ".", sesion);
                                            if (exitoCasoAsociado)
                                                (new AnticiposPersonaService()).EjecutarAccionesLuegoDeCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);
                                            if (!exitoCasoAsociado)
                                                throw new Exception("Error en OrdenesPagoService.EjecutarAccionesLuegoDeCambioEstado(), Anticipo Persona. " + msg + ".");
                                            break;
                                        case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:
                                            exitoCasoAsociado = (new NotasCreditoPersonaService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, false, out msg, sesion);
                                            if (exitoCasoAsociado)
                                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoReferidoId, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso de la Orden de Pago caso " + cabeceraRow.CASO_ID + " al estado " + casoRow.ESTADO_ID + ".", sesion);
                                            if (exitoCasoAsociado)
                                                (new NotasCreditoPersonaService()).EjecutarAccionesLuegoDeCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);
                                            if (!exitoCasoAsociado)
                                                throw new Exception("Error en OrdenesPagoService.EjecutarAccionesLuegoDeCambioEstado(), NC Persona. " + msg + ".");
                                            break;
                                        case Definiciones.FlujosIDs.CREDITOS:
                                            var credito = CreditosService.GetPorCaso(detalleRows[i].CASO_REFERIDO_ID, sesion);
                                            credito.IniciarUsingSesion(sesion);
                                            credito.ProcesarCambioEstado(Definiciones.EstadosFlujos.Vigente, false, new ToolbarFlujoService.ComentarioTransicion { texto = "Transición automática." }, sesion);
                                            credito.FinalizarUsingSesion();
                                            break;
                                        case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES:
                                            exitoCasoAsociado = new DescuentoDocumentosClienteService().ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Vigente, false, out msg, sesion);
                                            if (exitoCasoAsociado)
                                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Vigente, "Transición automática.", sesion);
                                            if (exitoCasoAsociado)
                                                new DescuentoDocumentosClienteService().EjecutarAccionesLuegoDeCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Vigente, sesion);
                                            if (!exitoCasoAsociado)
                                                throw new Exception("Error en OrdenesPagoService.EjecutarAccionesLuegoDeCambioEstado(), Descuento Documento Persona. " + msg + ".");
                                            break;
                                        default:
                                            throw new Exception("Error en OrdenesPagoService.EjecutarAccionesLuegoDeCambioEstado(). Flujo no implementado para pago a personas.");
                                    }
                                }
                                break;
                            case Definiciones.TiposOrdenesPago.RespaldoAnticipoProveedor:
                                break;
                            case Definiciones.TiposOrdenesPago.RespaldoCambioDivisa:
                                //Realizar las acciones del paso de estdo en el flujo especifico
                                exitoCasoAsociado = (new CambiosDivisaService()).ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Aprobado, false, out msg, sesion);
                                if (exitoCasoAsociado)
                                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Aprobado, "Transición automática por paso de la Orden de Pago caso " + detalleRows[i].CASO_REFERIDO_ID + " al estado " + casoRow.ESTADO_ID + ".", sesion);
                                if (exitoCasoAsociado)
                                    (new CambiosDivisaService()).EjecutarAccionesLuegoDeCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Aprobado, sesion);
                                if (!exitoCasoAsociado)
                                    throw new Exception(msg);
                                break;
                            case Definiciones.TiposOrdenesPago.RespaldoCustodiaValores:
                            case Definiciones.TiposOrdenesPago.RespaldoDescuentoDocumentos:
                            case Definiciones.TiposOrdenesPago.RespaldoTransferenciaBancaria:
                            case Definiciones.TiposOrdenesPago.RespaldoTransferenciaTesoreria:
                            case Definiciones.TiposOrdenesPago.AdelantoFuncionario:
                                break;
                            case Definiciones.TiposOrdenesPago.PagoFuncionarios:
                                //Si se trata de un detalle de factura de proveedor en un caso de pago a funcionarios
                                if (!detalleRows[i].IsCTACTE_PROVEEDOR_IDNull && detalleRows[i].IsCASO_REFERIDO_IDNull)
                                {
                                    decimal deudaMovimiento2 = CuentaCorrienteProveedoresService.GetDeudaTotal(detalleRows[i].CTACTE_PROVEEDOR_ID, sesion);

                                    //Cerrar la FC de Proveedor si el saldo es cero
                                    if (Math.Round(deudaMovimiento2, 4) == 0)
                                    {
                                        DataTable dtCtacteProv = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresDataTable(CuentaCorrienteProveedoresService.Id_NombreCol + " = " + detalleRows[i].CTACTE_PROVEEDOR_ID, string.Empty, sesion);
                                        decimal facturaProveedorCasoId = (decimal)dtCtacteProv.Rows[0][CuentaCorrienteProveedoresService.CasoId_NombreCol];

                                        exitoCasoAsociado = (new FacturasProveedorService()).ProcesarCambioEstado(facturaProveedorCasoId, Definiciones.EstadosFlujos.Cerrado, false, out msg, sesion);
                                        if (exitoCasoAsociado)
                                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(facturaProveedorCasoId, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso de la Orden de Pago caso " + cabeceraRow.CASO_ID + " al estado " + casoRow.ESTADO_ID + ".", sesion);
                                        if (exitoCasoAsociado)
                                            (new FacturasProveedorService()).EjecutarAccionesLuegoDeCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);
                                        if (!exitoCasoAsociado)
                                            throw new Exception(msg);
                                    }
                                }
                                break;
                        }
                    }
                }
                //Cerrado a Generacion
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Generacion) &&
                         casoRow.ESTADO_ANTERIOR_ID.Equals(Definiciones.EstadosFlujos.Cerrado))
                {
                    for (int i = 0; i < detalleRows.Length; i++)
                    {
                        switch (tipoOP)
                        {
                            case Definiciones.TiposOrdenesPago.ReposicionFondoFijo:
                            case Definiciones.TiposOrdenesPago.PagoAProveedor:
                            case Definiciones.TiposOrdenesPago.PagoAPersona:
                                break;
                            case Definiciones.TiposOrdenesPago.RespaldoAnticipoProveedor:
                                exitoCasoAsociado = (new AnticiposProveedorService()).ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Aprobado, false, out msg, sesion);
                                if (exitoCasoAsociado)
                                    exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Aprobado, "Transición automática por paso de la Orden de Pago caso " + cabeceraRow.CASO_ID + " al estado " + casoRow.ESTADO_ID + ".", sesion);
                                if (exitoCasoAsociado)
                                    (new AnticiposProveedorService()).EjecutarAccionesLuegoDeCambioEstado(detalleRows[i].CASO_REFERIDO_ID, Definiciones.EstadosFlujos.Aprobado, sesion);
                                if (!exitoCasoAsociado)
                                    throw new Exception(msg);
                                break;
                            case Definiciones.TiposOrdenesPago.RespaldoCambioDivisa:
                            case Definiciones.TiposOrdenesPago.RespaldoCustodiaValores:
                            case Definiciones.TiposOrdenesPago.RespaldoDescuentoDocumentos:
                            case Definiciones.TiposOrdenesPago.RespaldoTransferenciaBancaria:
                            case Definiciones.TiposOrdenesPago.RespaldoTransferenciaTesoreria:
                            case Definiciones.TiposOrdenesPago.AdelantoFuncionario:
                            case Definiciones.TiposOrdenesPago.PagoFuncionarios:
                                break;
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
            ORDENES_PAGORow row = sesion.Db.ORDENES_PAGOCollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE;
        }

        #endregion Implementacion de metodos abstract

        #region GetOrdenesPagoDataTable
        public static DataTable GetOrdenesPagoDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetOrdenesPagoDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetOrdenesPagoDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ORDENES_PAGOCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetOrdenesPagoDataTable

        #region GetOrdenesPagoInfoCompleta
        public static DataTable GetOrdenesPagoInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetOrdenesPagoInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetOrdenesPagoInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ORDENES_PAGO_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
        }

        [Obsolete("Utilizar los metodos estaticos.")]
        public Decimal GetOrdenPagoIdPorCaso(decimal caso_id)
        {
            return GetOrdenPagoIDPorCaso2(caso_id);
        }

        public static decimal GetOrdenPagoIDPorCaso2(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {

                ORDENES_PAGORow[] row = sesion.Db.ORDENES_PAGOCollection.GetByCASO_ID(caso_id);
                decimal ordenId = row[0].ID;
                return ordenId;
            }
        }
        #endregion GetOrdenesPagoInfoCompleta

        #region GetOrdenesPagoPorCaso
        /// <summary>
        /// Gets the ordenes pago por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetOrdenesPagoPorCaso(decimal caso_id)
        {
            return GetOrdenesPagoInfoCompleta(OrdenesPagoService.CasoId_NombreCol + " = " + caso_id, string.Empty);
        }


        #endregion GetOrdenesPagoPorCaso

        #region GetOrdenesPagoCasoPorId
        /// <summary>
        /// Gets the ordenes pago por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public Decimal GetOrdenesPagoCasoPorId(decimal id)
        {
            DataTable dt = GetOrdenesPagoInfoCompleta(OrdenesPagoService.Id_NombreCol + " = " + id, string.Empty);
            if (dt.Rows.Count > 0)
                return (decimal)dt.Rows[0][OrdenesPagoService.CasoId_NombreCol];
            else
                return Definiciones.Error.Valor.EnteroPositivo;
        }



        #endregion GetOrdenesPagoPorCaso

        #region GetFlujosRespaldadosPorOrdenesPago
        public static DataTable GetFlujosRespaldadosPorOrdenesPago()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(FlujosService.Id_NombreCol, typeof(int));
            dt.Columns.Add(FlujosService.Descripcion_NombreCol, typeof(string));

            dt.Rows.Add(Definiciones.FlujosIDs.ANTICIPO_PROVEEDOR, Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.ANTICIPO_PROVEEDOR));
            dt.Rows.Add(Definiciones.FlujosIDs.CAMBIO_DIVISA, Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.CAMBIO_DIVISA));
            dt.Rows.Add(Definiciones.FlujosIDs.CUSTODIA_DE_VALORES, Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.CUSTODIA_DE_VALORES));
            dt.Rows.Add(Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA, Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA));
            dt.Rows.Add(Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_TESORERIA, Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_TESORERIA));
            dt.Rows.Add(Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS, Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS));
            dt.Rows.Add(Definiciones.FlujosIDs.ADELANTO_FUNCIONARIO, Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.ADELANTO_FUNCIONARIO));

            return dt;
        }
        #endregion GetFlujosRespaldadosPorOrdenesPago

        #region GetFacturasProveedoresPorPagar
        /// <summary>
        /// Gets the facturas proveedores por pagar.
        /// </summary>
        /// <param name="proveedor_id">The proveedor_id.</param>
        /// <returns></returns>
        public DataTable GetFacturasProveedoresPorPagar(decimal proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = string.Empty;

                clausulas = CuentaCorrienteProveedoresService.ProveedorId_NombreCol + " = " + proveedor_id + " and " +
                            CuentaCorrienteProveedoresService.Credito_NombreCol + " > " + CuentaCorrienteProveedoresService.Debito_NombreCol;

                return CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresInfoCompleta(clausulas, string.Empty, sesion);
            }
        }
        #endregion GetFacturasProveedoresPorPagar

        #region VerificarPuedeAvanzarEstado
        public static bool VerificarPuedeAvanzarEstado(decimal caso_id, out string mensaje, SessionService sesion)
        {
            return FlujosService.VerificarPuedeAvanzarEstado(caso_id, out mensaje, "ORDENES PAGO NO CONTROLAR MARGEN DIAS PUEDE AVANZAR", Definiciones.VariablesDeSistema.OrdenesPagoMargenDiasPuedeAvanzar, sesion);
        }
        #endregion VerificarPuedeAvanzarEstado

        #region CalcularTotales
        /// <summary>
        /// Calculars the totales.
        /// </summary>
        /// <param name="orden_pago_id">The orden_pago_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void CalcularTotales(decimal orden_pago_id, SessionService sesion)
        {
            DataTable dtOrdenPagoValores = sesion.Db.ORDENES_PAGO_VALORESCollection.GetByORDEN_PAGO_IDAsDataTable(orden_pago_id);
            ORDENES_PAGORow row = sesion.Db.ORDENES_PAGOCollection.GetByPrimaryKey(orden_pago_id);
            string valorAnterior = row.ToString();

            row.MONTO_TOTAL = 0;

            for (int i = 0; i < dtOrdenPagoValores.Rows.Count; i++)
                row.MONTO_TOTAL += (decimal)dtOrdenPagoValores.Rows[i][OrdenesPagoValoresService.MontoDestino_NombreCol];

            sesion.Db.ORDENES_PAGOCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion CalcularTotales

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return Guardar(campos, insertarNuevo, ref caso_id, ref estado_id, sesion);
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
            ORDENES_PAGORow row = new ORDENES_PAGORow();

            try
            {
                SucursalesService sucursal = new SucursalesService();
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[OrdenesPagoService.SucursalOrigenId_NombreCol].ToString()),
                                                          int.Parse(Definiciones.FlujosIDs.ORDEN_DE_PAGO.ToString()),
                                                          int.Parse(sesion.Usuario_Id.ToString()),
                                                          SessionService.GetClienteIP());
                    row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                    row.ID = sesion.Db.GetSiguienteSecuencia("ordenes_pago_sqc");
                    caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                    estado_id = Definiciones.EstadosFlujos.Borrador;
                }
                else
                {
                    row = sesion.Db.ORDENES_PAGOCollection.GetRow(OrdenesPagoService.Id_NombreCol + " = " + campos[OrdenesPagoService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                if (campos.Contains(OrdenesPagoService.AutonumeracionId_NombreCol))
                    row.AUTONUMERACION_ID = (decimal)campos[OrdenesPagoService.AutonumeracionId_NombreCol];
                else
                    row.IsAUTONUMERACION_IDNull = true;

                if (campos.Contains(OrdenesPagoService.CasoOriginarioId_NombreCol))
                    row.CASO_ORIGINARIO_ID = (decimal)campos[OrdenesPagoService.CasoOriginarioId_NombreCol];
                else
                    row.IsCASO_ORIGINARIO_IDNull = true;

                if (campos.Contains(OrdenesPagoService.RetencionAutonumeracionId_NombreCol))
                    row.RETENCION_AUTONUMERACION_ID = (decimal)campos[OrdenesPagoService.RetencionAutonumeracionId_NombreCol];
                else
                    row.IsRETENCION_AUTONUMERACION_IDNull = true;

                if (campos.Contains(OrdenesPagoService.NroComprobante_NombreCol))
                    row.NRO_COMPROBANTE = (string)campos[OrdenesPagoService.NroComprobante_NombreCol];

                if (campos.Contains(OrdenesPagoService.FechaReciboBeneficiario_NombreCol))
                    row.FECHA_RECIBO_BENEFICIARIO = (DateTime)campos[OrdenesPagoService.FechaReciboBeneficiario_NombreCol];
                else
                    row.IsFECHA_RECIBO_BENEFICIARIONull = true;

                if (campos.Contains(OrdenesPagoService.Fecha_NombreCol))
                    row.FECHA = (DateTime)campos[OrdenesPagoService.Fecha_NombreCol];
                else
                    row.IsFECHANull = true;

                if (campos.Contains(OrdenesPagoService.RetencionUnificada_NombreCol))
                    row.RETENCION_UNIFICADA = campos[OrdenesPagoService.RetencionUnificada_NombreCol].ToString();
                else
                    row.RETENCION_UNIFICADA = Definiciones.SiNo.No;

                if (campos.Contains(OrdenesPagoService.NumeroSolicitud_NombreCol))
                    row.NUMERO_SOLICITUD = (string)campos[OrdenesPagoService.NumeroSolicitud_NombreCol];
                else
                    row.NUMERO_SOLICITUD = string.Empty;

                row.NRO_RECIBO_BENEFICIARIO = (string)campos[OrdenesPagoService.NroReciboBeneficiario_NombreCol];
                row.NOMBRE_BENEFICIARIO = (string)campos[OrdenesPagoService.NombreBeneficiario_NombreCol];

                row.OBSERVACION = (string)campos[OrdenesPagoService.Observacion_NombreCol];
                row.OBSERVACION_INTERNA = (string)campos[OrdenesPagoService.ObservacionInterna_NombreCol];

                row.ORDEN_PAGO_TIPO_ID = decimal.Parse(campos[OrdenesPagoService.OrdenPagoTipoId_NombreCol].ToString());

                //Si cambia
                if (!row.SUCURSAL_ORIGEN_ID.Equals(campos[OrdenesPagoService.SucursalOrigenId_NombreCol]))
                {
                    if (!SucursalesService.EstaActivo((decimal)campos[OrdenesPagoService.SucursalOrigenId_NombreCol]))
                        throw new Exception("La sucursal origen no está activa.");

                    row.SUCURSAL_ORIGEN_ID = (decimal)campos[OrdenesPagoService.SucursalOrigenId_NombreCol];
                    CasosService.ActualizarSucursal(row.CASO_ID, row.SUCURSAL_ORIGEN_ID, sesion);
                }

                //Si cambia
                if (row.MONEDA_ID.Equals(DBNull.Value) || row.MONEDA_ID != (decimal)campos[OrdenesPagoService.MonedaId_NombreCol])
                {
                    if (!MonedasService.EstaActivo((decimal)campos[OrdenesPagoService.MonedaId_NombreCol]))
                        throw new Exception("La moneda origen no está activa");

                    row.MONEDA_ID = (decimal)campos[OrdenesPagoService.MonedaId_NombreCol];
                }

                if (campos.Contains(OrdenesPagoService.CotizacionMoneda_NombreCol))
                    row.COTIZACION_MONEDA = (decimal)campos[OrdenesPagoService.CotizacionMoneda_NombreCol];
                else
                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais(row.SUCURSAL_ORIGEN_ID), row.MONEDA_ID, row.FECHA, sesion);

                if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new Exception("Debe actualizarse la cotización de la moneda origen.");
                else if (row.COTIZACION_MONEDA <= 0)
                    throw new Exception("La cotización no es válida.");

                //Si cambia
                if (campos.Contains(OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol))
                    if (row.IsCTACTE_CAJA_TESO_ORIGEN_IDNull || row.CTACTE_CAJA_TESO_ORIGEN_ID != (decimal)campos[OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol])
                    {
                        if (!CuentaCorrienteCajasTesoreriaService.EstaActivo((decimal)campos[OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol]))
                            throw new Exception("La caja de tesorería origen no está activa.");

                        row.CTACTE_CAJA_TESO_ORIGEN_ID = (decimal)campos[OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol];
                    }

                if (row.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAProveedor)
                {
                    //Si cambia
                    if (row.IsPROVEEDOR_IDNull || !row.PROVEEDOR_ID.Equals(campos[OrdenesPagoService.ProveedorId_NombreCol]))
                    {
                        if (!ProveedoresService.EstaActivo((decimal)campos[OrdenesPagoService.ProveedorId_NombreCol]))
                            throw new Exception("El proveedor no está activo.");

                        row.PROVEEDOR_ID = (decimal)campos[OrdenesPagoService.ProveedorId_NombreCol];
                    }
                }
                else
                {
                    row.IsPROVEEDOR_IDNull = true;
                }

                if (row.ORDEN_PAGO_TIPO_ID == Definiciones.TiposOrdenesPago.PagoAPersona)
                {
                    //Si cambia
                    if (row.IsPERSONA_IDNull || !row.PERSONA_ID.Equals(campos[OrdenesPagoService.PersonaId_NombreCol]))
                    {
                        if (!PersonasService.EstaActivo((decimal)campos[OrdenesPagoService.PersonaId_NombreCol]))
                            throw new Exception("El proveedor no está activo.");

                        row.PERSONA_ID = (decimal)campos[OrdenesPagoService.PersonaId_NombreCol];
                    }
                }
                else
                {
                    row.IsPERSONA_IDNull = true;
                }

                if (campos.Contains(OrdenesPagoService.TextoPredefinidoId_NombreCol))
                    row.TEXTO_PREDEFINIDO_ID = (decimal)campos[OrdenesPagoService.TextoPredefinidoId_NombreCol];

                if (insertarNuevo) sesion.Db.ORDENES_PAGOCollection.Insert(row);
                else sesion.Db.ORDENES_PAGOCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();
                camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                if (!Interprete.EsNullODBNull(row.NRO_RECIBO_BENEFICIARIO))
                    camposCaso.Add(CasosService.NroComprobante2_NombreCol, row.NRO_RECIBO_BENEFICIARIO);
                if (!row.IsPERSONA_IDNull)
                    camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                if (!row.IsPROVEEDOR_IDNull)
                    camposCaso.Add(CasosService.ProveedorId_NombreCol, row.PROVEEDOR_ID);
                camposCaso.Add(CasosService.TipoEspecifico_NombreCol, row.ORDEN_PAGO_TIPO_ID);
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
                    ORDENES_PAGORow cabecera = sesion.Db.ORDENES_PAGOCollection.GetByCASO_ID(caso_id)[0];

                    if (caso.ESTADO_ID == Definiciones.EstadosFlujos.Generacion || caso.ESTADO_ID == Definiciones.EstadosFlujos.Cerrado)
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse en el estado " + caso.ESTADO_ID + ".";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        //No se borra fisicamente por problemas de FK. Cuando exista borrado logico debera cambiar de estado aqui
                        //sesion.Db.ORDENES_PAGOCollection.DeleteByCASO_ID(caso_id);
                        //LogCambiosService.LogDeRegistro(Nombre_Tabla, cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                        //Desvincular los valores que pueden ser usados una sola vez, como Trnasferencia Bancaria
                        DataTable dtValores = OrdenesPagoValoresService.GetOrdenesPagoValoresDataTable(OrdenesPagoValoresService.OrdenPagoId_NombreCol + " = " + cabecera.ID, string.Empty, sesion);
                        for (int i = 0; i < dtValores.Rows.Count; i++)
                        {
                            switch ((int)dtValores.Rows[i][OrdenesPagoValoresService.CtacteValorId_NombreCol])
                            {
                                case Definiciones.CuentaCorrienteValores.TransferenciaBancaria:
                                case Definiciones.CuentaCorrienteValores.AjusteBancario:
                                    OrdenesPagoValoresService.Borrar((decimal)dtValores.Rows[i][OrdenesPagoValoresService.Id_NombreCol], sesion);
                                    break;
                            }
                        }

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
        public static decimal CrearOrdenPago(Hashtable cabecera, Hashtable[] detalles, Hashtable valores_datos, int ctacte_valor_completar_id, bool priorizar_cuenta_a_favor_empresa, bool avanzar_hasta_cerrado)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal id = CrearOrdenPago(cabecera, detalles, ctacte_valor_completar_id, valores_datos, priorizar_cuenta_a_favor_empresa, avanzar_hasta_cerrado, sesion);
                    sesion.CommitTransaction();
                    return id;
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public static decimal CrearOrdenPago(Hashtable cabecera, Hashtable[] detalles, int ctacte_valor_completar_id, Hashtable valores_datos, bool priorizar_cuenta_a_favor_empresa, bool avanzar_hasta_cerrado, SessionService sesion)
        {
            try
            {
                decimal casoId = Definiciones.Error.Valor.EnteroPositivo;
                string estado_id = string.Empty;
                int tipoOP;

                #region Cabecera
                // Se verifican los campos obligatorios de la OP
                if (!cabecera.Contains(OrdenesPagoService.SucursalOrigenId_NombreCol))
                    throw new Exception("Error de implementación: se requiere sucursal para crear la orden de pago.");
                if (!cabecera.Contains(OrdenesPagoService.OrdenPagoTipoId_NombreCol))
                    throw new Exception("Error de implementación: se requiere tipo para crear la orden de pago.");
                if (!cabecera.Contains(OrdenesPagoService.MonedaId_NombreCol))
                    throw new Exception("Error de implementación: se requiere moneda para crear la orden de pago.");

                tipoOP = Convert.ToInt32(cabecera[OrdenesPagoService.OrdenPagoTipoId_NombreCol]);

                // Si no trae autonumeracion, se elige la primera activa de la sucursal para este flujo
                if (!cabecera.Contains(OrdenesPagoService.AutonumeracionId_NombreCol))
                {
                    DataTable dtAutonumeraciones = AutonumeracionesService.GetAutonumeracionesPorFlujo2(Definiciones.Flujo.OrdenDePago.ID, (decimal)cabecera[OrdenesPagoService.SucursalOrigenId_NombreCol], AutonumeracionesService.Id_NombreCol, sesion);
                    if (dtAutonumeraciones.Rows.Count > 0)
                        cabecera.Add(OrdenesPagoService.AutonumeracionId_NombreCol, (decimal)dtAutonumeraciones.Rows[0][AutonumeracionesService.Id_NombreCol]);
                    else
                        throw new Exception("Debe existir un talonario activo en la sucursal para Órdenes de Pago para crear la OP desde la FC Proveedor.");
                }

                cabecera.Add(OrdenesPagoService.RetencionUnificada_NombreCol, Definiciones.SiNo.No);

                // Si no trae autonumeracion para la retencion, se elige la primera activa de esta sucursal para Retenciones Emitidas
                if (!cabecera.Contains(OrdenesPagoService.RetencionAutonumeracionId_NombreCol))
                {
                    DataTable dtRetencionAutonumeraciones = AutonumeracionesService.GetAutonumeracionesPorTabla2(Definiciones.Tablas.CtaCteRetencionesEmitidas, (decimal)cabecera[OrdenesPagoService.SucursalOrigenId_NombreCol], string.Empty, AutonumeracionesService.Id_NombreCol, sesion);
                    if (dtRetencionAutonumeraciones.Rows.Count > 0)
                        cabecera.Add(OrdenesPagoService.RetencionAutonumeracionId_NombreCol, (decimal)dtRetencionAutonumeraciones.Rows[0][AutonumeracionesService.Id_NombreCol]);
                }

                // Si no trae caja de tesoreria, se elige la primera que se obtiene
                if (!cabecera.Contains(OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol))
                {
                    DataTable dtCajasTesoreria = CuentaCorrienteCajasTesoreriaService.GetCuentaCorrienteCajasTesoreriaDataTable(CuentaCorrienteCajasTesoreriaService.SucursalId_NombreCol + " = " + ((decimal)cabecera[OrdenesPagoService.SucursalOrigenId_NombreCol]).ToString(), CuentaCorrienteCajasTesoreriaService.Orden_NombreCol, true, sesion);
                    if (dtCajasTesoreria.Rows.Count > 0)
                        cabecera.Add(OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol, (decimal)dtCajasTesoreria.Rows[0][AutonumeracionesService.Id_NombreCol]);
                    else
                        throw new Exception("Debe existir una caja de tesorería activa en la sucursal para crear la OP desde la FC Proveedor.");
                }

                // Se verifican campos obligatorios por tipo de OP
                switch (tipoOP)
                {
                    case Definiciones.TiposOrdenesPago.PagoAProveedor:
                        if (!cabecera.Contains(OrdenesPagoService.ProveedorId_NombreCol))
                            throw new Exception("Error de implementación: se requiere proveedor para crear una orden de pago de pago a proveedor.");
                        break;
                    case Definiciones.TiposOrdenesPago.PagoAPersona:
                        if (!cabecera.Contains(OrdenesPagoService.PersonaId_NombreCol))
                            throw new Exception("Error de implementación: se requiere persona para crear una orden de pago de pago a persona.");
                        break;
                    default:
                        throw new Exception("Error de implementación: tipo de OP no implementado en creación de cabecera de CrearOrdenPago().");
                }

                // Se guarda la cabecera
                OrdenesPagoService.Guardar(cabecera, true, ref casoId, ref estado_id, sesion);
                #endregion Cabecera

                #region Detalles
                // Se obtiene la id del caso recien creado
                DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoDataTable(OrdenesPagoService.CasoId_NombreCol + " = " + casoId, string.Empty, sesion);
                decimal ordenPagoId = (decimal)dtOrdenPago.Rows[0][OrdenesPagoService.Id_NombreCol];
                decimal saldoValores = 0;

                // Se crean los detalles
                foreach (Hashtable detalle in detalles)
                {
                    detalle.Add(OrdenesPagoDetalleService.OrdenPagoId_NombreCol, ordenPagoId);

                    // Se verifican los campos obligatorios del detalle de OP
                    if (!detalle.Contains(OrdenesPagoDetalleService.MonedaOrigenId_NombreCol))
                        throw new Exception("Error de implementación: debe indicar la moneda origen de los detalles de la OP.");
                    if (!detalle.Contains(OrdenesPagoDetalleService.MontoOrigen_NombreCol))
                        throw new Exception("Error de implementación: debe indicar el monto origen de los detalles de la OP.");

                    // Se verifican los campos obligatorios por tipo de OP
                    switch (tipoOP)
                    {
                        case Definiciones.TiposOrdenesPago.PagoAProveedor:
                            if (!detalle.Contains(OrdenesPagoDetalleService.CtacteProveedorId_NombreCol))
                                throw new Exception("Error de implementación: los detalles de OP de pago a proveedor deben tener registro de cta. cte. asociado.");
                            if (!detalle.Contains(OrdenesPagoDetalleService.CasoReferidoId_NombreCol))
                                throw new Exception("Error de implementación: los detalles de OP de pago a proveedor deben tener caso referido.");
                            break;
                        default:
                            throw new Exception("Error de implementación: tipo de OP no implementado en creación de detalles en CrearOrdenPago().");
                            break;
                    }

                    OrdenesPagoDetalleService.Guardar(detalle, sesion);

                    // Se calcula el total de la OP
                    if (((decimal)detalle[OrdenesPagoDetalleService.MonedaOrigenId_NombreCol]).Equals(dtOrdenPago.Rows[0][OrdenesPagoService.MonedaId_NombreCol]))
                        saldoValores += (decimal)detalle[OrdenesPagoDetalleService.MontoOrigen_NombreCol];
                    else
                        saldoValores += ((decimal)detalle[OrdenesPagoDetalleService.MontoOrigen_NombreCol] / (decimal)detalle[OrdenesPagoDetalleService.CotizacionMonedaOrigen_NombreCol]) * (decimal)dtOrdenPago.Rows[0][OrdenesPagoService.CotizacionMoneda_NombreCol];
                }
                #endregion Detalles

                #region Valores
                // Se contemplan valores creados automaticamente (retenciones)
                DataTable dtValores = OrdenesPagoValoresService.GetOrdenesPagoValoresDataTable(OrdenesPagoValoresService.OrdenPagoId_NombreCol + "= " + ordenPagoId, string.Empty, sesion);
                foreach (DataRow valor in dtValores.Rows)
                    saldoValores -= (decimal)valor[OrdenesPagoValoresService.MontoDestino_NombreCol];

                #region valor indicado en parametro valores_datos si define CtacteValorId
                if (valores_datos!= null && valores_datos.Contains(OrdenesPagoValoresService.CtacteValorId_NombreCol))
                {
                    Hashtable camposValor = new Hashtable();
                    valores_datos[OrdenesPagoValoresService.OrdenPagoId_NombreCol] = ordenPagoId;
                    OrdenesPagoValoresService.Guardar(valores_datos, sesion);
                    saldoValores -= (decimal)valores_datos[OrdenesPagoValoresService.MontoOrigen_NombreCol];
                }
                #endregion valor indicado en parametro valores_datos si define CtacteValorId

                #region priorizar_cuenta_a_favor_empresa
                if (priorizar_cuenta_a_favor_empresa)
                {
                    decimal montoValor = 0;
                    // Se buscan todos los anticipos disponibles del proveedor
                    DataTable dtAnticipos = AnticiposProveedorService.GetAnticipoProveedorDataTable(AnticiposProveedorService.ProveedorId_NombreCol + " = " + dtOrdenPago.Rows[0][OrdenesPagoService.ProveedorId_NombreCol].ToString() + " and " + AnticiposProveedorService.SaldoPorAplicar_NombreCol + " > 0", AnticiposProveedorService.Fecha_NombreCol);
                    foreach (DataRow anticipo in dtAnticipos.Rows)
                    {
                        if (saldoValores <= 0)
                            break;
                        bool mismaMoneda = true;

                        // Se toma el saldo del anticipo en la moneda de la OP
                        decimal saldoAnticipo = (decimal)anticipo[AnticiposProveedorService.SaldoPorAplicar_NombreCol];
                        if (!((decimal)anticipo[AnticiposProveedorService.MonedaId_NombreCol]).Equals((decimal)dtOrdenPago.Rows[0][OrdenesPagoService.MonedaId_NombreCol]))
                        {
                            saldoAnticipo = (saldoAnticipo / (decimal)anticipo[AnticiposProveedorService.CotizacionMoneda_NombreCol]) * (decimal)dtOrdenPago.Rows[0][OrdenesPagoService.CotizacionMoneda_NombreCol];
                            mismaMoneda = false;
                        }

                        // Se define el monto del valor de la OP
                        if (saldoAnticipo <= saldoValores)
                        {
                            if (mismaMoneda)
                                montoValor = saldoAnticipo;
                            else
                                montoValor = (decimal)anticipo[NotasCreditoProveedorService.SaldoPorAplicar_NombreCol];
                        }
                        else
                        {
                            if (mismaMoneda)
                                montoValor = saldoValores;
                            else
                                montoValor = (saldoValores / (decimal)dtOrdenPago.Rows[0][OrdenesPagoService.CotizacionMoneda_NombreCol]) * (decimal)anticipo[AnticiposProveedorService.MonedaCotizacion_NombreCol];
                        }

                        // Se crea el valor de la OP
                        Hashtable camposValor = new Hashtable();
                        camposValor.Add(OrdenesPagoValoresService.OrdenPagoId_NombreCol, ordenPagoId);
                        camposValor.Add(OrdenesPagoValoresService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Anticipo);
                        camposValor.Add(OrdenesPagoValoresService.MonedaOrigenId_NombreCol, anticipo[AnticiposProveedorService.MonedaId_NombreCol]);
                        camposValor.Add(OrdenesPagoValoresService.MontoOrigen_NombreCol, montoValor);
                        camposValor.Add(OrdenesPagoValoresService.Observacion_NombreCol, "Anticipo utilizado de manera automática en creación de OP desde FC Proveedor.");
                        camposValor.Add(OrdenesPagoValoresService.AnticipoProveedorId_NombreCol, anticipo[AnticiposProveedorService.Id_NombreCol]);
                        decimal valorId = OrdenesPagoValoresService.Guardar(camposValor, sesion);
                        DataTable dtValorAgregado = OrdenesPagoValoresService.GetOrdenesPagoValoresDataTable(OrdenesPagoValoresService.Id_NombreCol + " = " + valorId, string.Empty, sesion);

                        // Se resta el monto restante a pagar en la OP
                        if (mismaMoneda)
                            saldoValores -= montoValor;
                        else
                            saldoValores -= montoValor / (decimal)dtValorAgregado.Rows[0][OrdenesPagoValoresService.CotizacionMonedaOrigen_NombreCol] * (decimal)dtValorAgregado.Rows[0][OrdenesPagoValoresService.CotizacionMonedaDestino_NombreCol];
                    }

                    // Se buscan todas las NC Proveedor disponibles si aun queda saldo a pagar en la OP
                    if (saldoValores > 0)
                    {
                        DataTable dtNotasCredito = NotasCreditoProveedorService.GetNotaCreditoProveedorDataTable(NotasCreditoProveedorService.ProveedorId_NombreCol + " = " + dtOrdenPago.Rows[0][OrdenesPagoService.ProveedorId_NombreCol].ToString() + " and " + NotasCreditoProveedorService.SaldoPorAplicar_NombreCol + " > 0", NotasCreditoProveedorService.Fecha_NombreCol);
                        foreach (DataRow notaCredito in dtNotasCredito.Rows)
                        {
                            if (saldoValores <= 0)
                                break;
                            bool mismaMoneda = true;

                            // Se toma el saldo del anticipo en la moneda de la OP
                            decimal saldoNotaCredito = (decimal)notaCredito[NotasCreditoProveedorService.SaldoPorAplicar_NombreCol];
                            if (!((decimal)notaCredito[NotasCreditoProveedorService.MonedaId_NombreCol]).Equals((decimal)dtOrdenPago.Rows[0][OrdenesPagoService.MonedaId_NombreCol]))
                            {
                                saldoNotaCredito = (saldoNotaCredito / (decimal)notaCredito[NotasCreditoProveedorService.CotizacionMoneda_NombreCol]) * (decimal)dtOrdenPago.Rows[0][OrdenesPagoService.CotizacionMoneda_NombreCol];
                                mismaMoneda = false;
                            }

                            // Se define el monto del valor de la OP
                            if (saldoNotaCredito <= saldoValores)
                            {
                                if (mismaMoneda)
                                    montoValor = saldoNotaCredito;
                                else
                                    montoValor = (decimal)notaCredito[NotasCreditoProveedorService.SaldoPorAplicar_NombreCol];
                            }
                            else
                            {
                                if (mismaMoneda)
                                    montoValor = saldoValores;
                                else
                                    montoValor = (saldoValores / (decimal)dtOrdenPago.Rows[0][OrdenesPagoService.CotizacionMoneda_NombreCol]) * (decimal)notaCredito[NotasCreditoProveedorService.CotizacionMoneda_NombreCol];
                            }

                            // Se crea el valor de la OP
                            Hashtable camposValor = new Hashtable();
                            camposValor.Add(OrdenesPagoValoresService.OrdenPagoId_NombreCol, ordenPagoId);
                            camposValor.Add(OrdenesPagoValoresService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.NotaDeCredito);
                            camposValor.Add(OrdenesPagoValoresService.MonedaOrigenId_NombreCol, notaCredito[NotasCreditoProveedorService.MonedaId_NombreCol]);
                            camposValor.Add(OrdenesPagoValoresService.MontoOrigen_NombreCol, montoValor);
                            camposValor.Add(OrdenesPagoValoresService.Observacion_NombreCol, "NC utilizada de manera automática en creación de OP desde FC Proveedor.");
                            camposValor.Add(OrdenesPagoValoresService.NotaCreditoProveedorId_NombreCol, notaCredito[NotasCreditoProveedorService.Id_NombreCol]);
                            decimal valorId = OrdenesPagoValoresService.Guardar(camposValor, sesion);

                            DataTable dtValorAgregado = OrdenesPagoValoresService.GetOrdenesPagoValoresDataTable(OrdenesPagoValoresService.Id_NombreCol + " = " + valorId, string.Empty, sesion);

                            // Se resta el monto restante a pagar en la OP
                            if (mismaMoneda)
                                saldoValores -= montoValor;
                            else
                                saldoValores -= montoValor / (decimal)dtValorAgregado.Rows[0][OrdenesPagoValoresService.CotizacionMonedaOrigen_NombreCol] * (decimal)dtValorAgregado.Rows[0][OrdenesPagoValoresService.CotizacionMonedaDestino_NombreCol];
                        }
                    }
                }
                #endregion priorizar_cuenta_a_favor_empresa

                if (saldoValores > 0)
                {
                    Hashtable camposValor = new Hashtable();
                    camposValor.Add(OrdenesPagoValoresService.OrdenPagoId_NombreCol, ordenPagoId);
                    camposValor.Add(OrdenesPagoValoresService.CtacteValorId_NombreCol, ctacte_valor_completar_id);
                            
                    switch (ctacte_valor_completar_id)
                    { 
                        case Definiciones.Error.Valor.IntPositivo:
                            break;
                        case Definiciones.CuentaCorrienteValores.Efectivo:
                            camposValor.Add(OrdenesPagoValoresService.MonedaOrigenId_NombreCol, dtOrdenPago.Rows[0][OrdenesPagoService.MonedaId_NombreCol]);
                            camposValor.Add(OrdenesPagoValoresService.MontoOrigen_NombreCol, saldoValores);
                            camposValor.Add(OrdenesPagoValoresService.Observacion_NombreCol, "Valor en efectivo agregado automáticamente al crear la OP desde FC Proveedor.");
                            OrdenesPagoValoresService.Guardar(camposValor, sesion);
                            break;
                        case Definiciones.CuentaCorrienteValores.DebitoAutomatico:
                            DataTable dtCtacteBancaria = CuentaCorrienteCuentasBancariasService.GetCuentaCorrienteBancariasDataTable(CuentaCorrienteCuentasBancariasService.Id_NombreCol + " = " + valores_datos[OrdenesPagoValoresService.DebitoAutomCtacteBancId_NombreCol], string.Empty, false);
                            decimal cotizacionOrigen = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtOrdenPago.Rows[0][OrdenesPagoService.SucursalOrigenId_NombreCol]), (decimal)dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol], (DateTime)dtOrdenPago.Rows[0][OrdenesPagoService.Fecha_NombreCol]);

                            camposValor.Add(OrdenesPagoValoresService.CotizacionMonedaOrigen_NombreCol, cotizacionOrigen);
                            camposValor.Add(OrdenesPagoValoresService.MonedaOrigenId_NombreCol, dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol]);
                            camposValor.Add(OrdenesPagoValoresService.MontoOrigen_NombreCol, (saldoValores / (decimal)dtOrdenPago.Rows[0][OrdenesPagoService.CotizacionMoneda_NombreCol]) * cotizacionOrigen);
                            camposValor.Add(OrdenesPagoValoresService.Observacion_NombreCol, "Valor Débito Automático agregado automáticamente al crear la OP desde FC Proveedor.");
                            camposValor.Add(OrdenesPagoValoresService.DebitoAutomCtacteBancId_NombreCol, dtCtacteBancaria.Rows[0][CuentaCorrienteCuentasBancariasService.Id_NombreCol]);
                            OrdenesPagoValoresService.Guardar(camposValor, sesion);
                            break;
                        default: throw new Exception("OrdenPagoService.CrearOrdenPago. Tipo de valor no implementado.");
                    }
                }
                #endregion Valores

                #region Aprobar el caso de OP
                if (avanzar_hasta_cerrado)
                {
                    bool exito = false;
                    OrdenesPagoService ordenPago = new OrdenesPagoService();
                    string mensaje;

                    exito = ordenPago.ProcesarCambioEstado(casoId, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoId, Definiciones.EstadosFlujos.Pendiente, string.Empty, sesion);
                    if (exito)
                        ordenPago.EjecutarAccionesLuegoDeCambioEstado(casoId, Definiciones.EstadosFlujos.Pendiente, sesion);

                    if (exito)
                        exito = ordenPago.ProcesarCambioEstado(casoId, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoId, Definiciones.EstadosFlujos.Aprobado, string.Empty, sesion);
                    if (exito)
                        ordenPago.EjecutarAccionesLuegoDeCambioEstado(casoId, Definiciones.EstadosFlujos.Aprobado, sesion);

                    if (exito)
                        exito = ordenPago.ProcesarCambioEstado(casoId, Definiciones.EstadosFlujos.Generacion, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoId, Definiciones.EstadosFlujos.Generacion, string.Empty, sesion);
                    if (exito)
                        ordenPago.EjecutarAccionesLuegoDeCambioEstado(casoId, Definiciones.EstadosFlujos.Generacion, sesion);

                    if (exito)
                        exito = ordenPago.ProcesarCambioEstado(casoId, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoId, Definiciones.EstadosFlujos.Cerrado, string.Empty, sesion);
                    if (exito)
                        ordenPago.EjecutarAccionesLuegoDeCambioEstado(casoId, Definiciones.EstadosFlujos.Cerrado, sesion);
                }
                #endregion Aprobar el caso de OP

                return casoId;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion CrearOrdenPago

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ORDENES_PAGO"; }
        }
        public static string Nombre_Vista
        {
            get { return "ordenes_pago_info_completa"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return ORDENES_PAGOCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return ORDENES_PAGOCollection.CASO_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return ORDENES_PAGOCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteCajaTesoOrigenId_NombreCol
        {
            get { return ORDENES_PAGOCollection.CTACTE_CAJA_TESO_ORIGEN_IDColumnName; }
        }
        public static string FechaReciboBeneficiario_NombreCol
        {
            get { return ORDENES_PAGOCollection.FECHA_RECIBO_BENEFICIARIOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return ORDENES_PAGOCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ORDENES_PAGOCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return ORDENES_PAGOCollection.MONEDA_IDColumnName; }
        }
        public static string MontoTotal_NombreCol
        {
            get { return ORDENES_PAGOCollection.MONTO_TOTALColumnName; }
        }
        public static string NombreBeneficiario_NombreCol
        {
            get { return ORDENES_PAGOCollection.NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string NumeroSolicitud_NombreCol
        {
            get { return ORDENES_PAGOCollection.NUMERO_SOLICITUDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return ORDENES_PAGOCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string NroReciboBeneficiario_NombreCol
        {
            get { return ORDENES_PAGOCollection.NRO_RECIBO_BENEFICIARIOColumnName; }
        }
        public static string ObservacionInterna_NombreCol
        {
            get { return ORDENES_PAGOCollection.OBSERVACION_INTERNAColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return ORDENES_PAGOCollection.OBSERVACIONColumnName; }
        }
        public static string OrdenPagoTipoId_NombreCol
        {
            get { return ORDENES_PAGOCollection.ORDEN_PAGO_TIPO_IDColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return ORDENES_PAGOCollection.PERSONA_IDColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return ORDENES_PAGOCollection.PROVEEDOR_IDColumnName; }
        }
        public static string RetencionAutonumeracionId_NombreCol
        {
            get { return ORDENES_PAGOCollection.RETENCION_AUTONUMERACION_IDColumnName; }
        }
        public static string RetencionUnificada_NombreCol
        {
            get { return ORDENES_PAGOCollection.RETENCION_UNIFICADAColumnName; }
        }
        public static string SucursalOrigenId_NombreCol
        {
            get { return ORDENES_PAGOCollection.SUCURSAL_ORIGEN_IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return ORDENES_PAGOCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string CasoOriginarioId_NombreCol
        {
            get { return ORDENES_PAGOCollection.CASO_ORIGINARIO_IDColumnName; }
        }
        public static string VistaAutonumeracionTimbrado_NombreCol
        {
            get { return ORDENES_PAGO_INFO_COMPLETACollection.AUTONUMERACION_TIMBRADOColumnName; }
        }
        public static string VistaCtacteCajaTesoOrigenNomb_NombreCol
        {
            get { return ORDENES_PAGO_INFO_COMPLETACollection.CTACTE_CAJA_TESO_ORIGEN_NOMBColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return ORDENES_PAGO_INFO_COMPLETACollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCasoId_NombreCol
        {
            get { return ORDENES_PAGO_INFO_COMPLETACollection.CASO_IDColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return ORDENES_PAGO_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return ORDENES_PAGO_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return ORDENES_PAGO_INFO_COMPLETACollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaProveedorNombreFantasia_NombreCol
        {
            get { return ORDENES_PAGO_INFO_COMPLETACollection.PROVEEDOR_NOMBRE_FANTASIAColumnName; }
        }
        public static string VistaProveedorRazonSocial_NombreCol
        {
            get { return ORDENES_PAGO_INFO_COMPLETACollection.PROVEEDOR_RAZON_SOCIALColumnName; }
        }
        public static string VistaProveedorRuc_NombreCol
        {
            get { return ORDENES_PAGO_INFO_COMPLETACollection.PROVEEDOR_RUCColumnName; }
        }
        public static string VistaProveedorCodigo_NombreCol
        {
            get { return ORDENES_PAGO_INFO_COMPLETACollection.PROVEEDOR_CODIGOColumnName; }
        }
        public static string VistaSucursalOrigenAbreviatura_NombreCol
        {
            get { return ORDENES_PAGO_INFO_COMPLETACollection.SUCURSAL_ORIGEN_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalOrigenNombre_NombreCol
        {
            get { return ORDENES_PAGO_INFO_COMPLETACollection.SUCURSAL_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaTipoNombre_NombreCol
        {
            get { return ORDENES_PAGO_INFO_COMPLETACollection.ORDEN_PAGO_TIPO_NOMBREColumnName; }
        }
        public static string VistaNombreTextoPredefinido_NombreCol
        {
            get { return ORDENES_PAGO_INFO_COMPLETACollection.NOMBRE_TEXTO_PREDEFINIDOColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static OrdenesPagoService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new OrdenesPagoService(e.RegistroId, sesion);
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
        protected ORDENES_PAGORow row;
        protected ORDENES_PAGORow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? AutonumeracionId { get { if (row.IsAUTONUMERACION_IDNull) return null; else return row.AUTONUMERACION_ID; } set { if (value.HasValue) row.AUTONUMERACION_ID = value.Value; else row.IsAUTONUMERACION_IDNull = true; } }
        public decimal CasoId { get { return row.CASO_ID; } set { row.CASO_ID = value; } }
        public decimal? CasoOriginarioId { get { if (row.IsCASO_ORIGINARIO_IDNull) return null; else return row.CASO_ORIGINARIO_ID; } set { if (value.HasValue) row.CASO_ORIGINARIO_ID = value.Value; else row.IsCASO_ORIGINARIO_IDNull = true; } }
        public decimal CotizacionMoneda { get { return row.COTIZACION_MONEDA; } set { row.COTIZACION_MONEDA = value; } }
        public decimal? CtacteCajaTesoOrigenId { get { if (row.IsCTACTE_CAJA_TESO_ORIGEN_IDNull) return null; else return row.CTACTE_CAJA_TESO_ORIGEN_ID; } set { if (value.HasValue) row.CTACTE_CAJA_TESO_ORIGEN_ID = value.Value; else row.IsCTACTE_CAJA_TESO_ORIGEN_IDNull = true; } }
        public DateTime? Fecha { get { if (row.IsFECHANull) return null; else return row.FECHA; } set { if (value.HasValue) row.FECHA = value.Value; else row.IsFECHANull = true; } }
        public DateTime? FechaReciboBeneficiario { get { if (row.IsFECHA_RECIBO_BENEFICIARIONull) return null; else return row.FECHA_RECIBO_BENEFICIARIO; } set { if (value.HasValue) row.FECHA_RECIBO_BENEFICIARIO = value.Value; else row.IsFECHA_RECIBO_BENEFICIARIONull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal MontoTotal { get { return row.MONTO_TOTAL; } set { row.MONTO_TOTAL = value; } }
        public string NombreBeneficiario { get { return ClaseCBABase.GetStringHelper(row.NOMBRE_BENEFICIARIO); } set { row.NOMBRE_BENEFICIARIO = value; } }
        public string NumeroSolicitud { get { return ClaseCBABase.GetStringHelper(row.NUMERO_SOLICITUD); } set { row.NUMERO_SOLICITUD = value; } }
        public string NroComprobante { get { return ClaseCBABase.GetStringHelper(row.NRO_COMPROBANTE); } set { row.NRO_COMPROBANTE = value; } }
        public string NroReciboBeneficiario { get { return ClaseCBABase.GetStringHelper(row.NRO_RECIBO_BENEFICIARIO); } set { row.NRO_RECIBO_BENEFICIARIO = value; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public string ObservacionInterna { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION_INTERNA); } set { row.OBSERVACION_INTERNA = value; } }
        public decimal OrdenPagoTipoId { get { return row.ORDEN_PAGO_TIPO_ID; } set { row.ORDEN_PAGO_TIPO_ID = value; } }
        public decimal? PersonaId { get { if (row.IsPERSONA_IDNull) return null; else return row.PERSONA_ID; } set { if (value.HasValue) row.PERSONA_ID = value.Value; else row.IsPERSONA_IDNull = true; } }
        public decimal? ProveedorId { get { if (row.IsPROVEEDOR_IDNull) return null; else return row.PROVEEDOR_ID; } set { if (value.HasValue) row.PROVEEDOR_ID = value.Value; else row.IsPROVEEDOR_IDNull = true; } }
        public decimal? RetencionAutonumeracionId { get { if (row.IsRETENCION_AUTONUMERACION_IDNull) return null; else return row.RETENCION_AUTONUMERACION_ID; } set { if (value.HasValue) row.RETENCION_AUTONUMERACION_ID = value.Value; else row.IsRETENCION_AUTONUMERACION_IDNull = true; } }
        public string RetencionUnificada { get { return ClaseCBABase.GetStringHelper(row.RETENCION_UNIFICADA); } set { row.RETENCION_UNIFICADA = value; } }
        public decimal SucursalOrigenId { get { return row.SUCURSAL_ORIGEN_ID; } set { row.SUCURSAL_ORIGEN_ID = value; } }
        public decimal? TextoPredefinidoId { get { if (row.IsTEXTO_PREDEFINIDO_IDNull) return null; else return row.TEXTO_PREDEFINIDO_ID; } set { if (value.HasValue) row.TEXTO_PREDEFINIDO_ID = value.Value; else row.IsTEXTO_PREDEFINIDO_IDNull = true; } }
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
        
        private CasosService _caso_originario;
        public CasosService CasoOriginario
        {
            get
            {
                if (this._caso_originario == null)
                {
                    if (this.sesion != null)
                        this._caso_originario = new CasosService(this.CasoOriginarioId.Value, this.sesion);
                    else
                        this._caso_originario = new CasosService(this.CasoOriginarioId.Value);
                }
                return this._caso_originario;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                {
                    if (this.sesion != null)
                        this._moneda = new MonedasService(this.MonedaId, this.sesion);
                    else
                        this._moneda = new MonedasService(this.MonedaId);
                }
                return this._moneda;
            }
        }

        private PersonasService _persona;
        public PersonasService Persona
        {
            get
            {
                if (this._persona == null)
                {
                    if (this.sesion != null)
                        this._persona = new PersonasService(this.PersonaId.Value, this.sesion);
                    else
                        this._persona = new PersonasService(this.PersonaId.Value);
                }
                return this._persona;
            }
        }

        private ProveedoresService _proveedor;
        public ProveedoresService Proveedor
        {
            get
            {
                if (this._proveedor == null)
                {
                    if (this.sesion != null)
                        this._proveedor = new ProveedoresService(this.ProveedorId.Value, this.sesion);
                    else
                        this._proveedor = new ProveedoresService(this.ProveedorId.Value);
                }
                return this._proveedor;
            }
        }

        private SucursalesService _sucursal_origen;
        public SucursalesService SucursalOrigen
        {
            get
            {
                if (this._sucursal_origen == null)
                {
                    if (this.sesion != null)
                        this._sucursal_origen = new SucursalesService(this.SucursalOrigenId, this.sesion);
                    else
                        this._sucursal_origen = new SucursalesService(this.SucursalOrigenId);
                }
                return this._sucursal_origen;
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

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.ORDENES_PAGOCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ORDENES_PAGORow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(ORDENES_PAGORow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public OrdenesPagoService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public OrdenesPagoService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public OrdenesPagoService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        public OrdenesPagoService(EdiCBA.OrdenPago edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = OrdenesPagoService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            this.OrdenPagoTipoId = edi.tipo_orden_pago_id;
            this.CasoId = edi.caso_id;

            if (edi.cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion'.");
            this.CotizacionMoneda = edi.cotizacion.venta;

            this.Fecha = edi.fecha;

            #region moneda
            if (!string.IsNullOrEmpty(edi.moneda_uuid))
                this._moneda = MonedasService.GetPorUUID(edi.moneda_uuid, sesion);
            
            if (this._moneda == null)
                throw new Exception("No se encontró el UUID " + edi.moneda_uuid + " ni se definieron los datos del objeto.");

            if (!this.Moneda.ExisteEnDB && almacenar_localmente)
            {
                this.Moneda.IniciarUsingSesion(sesion);
                this.Moneda.Guardar();
                this.Moneda.FinalizarUsingSesion();
            }
            if (this.Moneda.Id.HasValue)
                this.MonedaId = this.Moneda.Id.Value;
            #endregion moneda

            this.MontoTotal = edi.total;
            this.NroComprobante = edi.nro_comprobante;

            #region proveedor
            if (!string.IsNullOrEmpty(edi.proveedor_uuid))
                this._proveedor = ProveedoresService.GetPorUUID(edi.proveedor_uuid, sesion);
            if (this._proveedor == null && edi.proveedor != null)
                this._proveedor = new ProveedoresService(edi.proveedor, almacenar_localmente, sesion);
            if (this.OrdenPagoTipoId == Definiciones.TiposOrdenesPago.PagoAProveedor && this._proveedor == null)
                throw new Exception("No se encontró el UUID " + edi.proveedor_uuid + " ni se definieron los datos del objeto.");

            if (this._proveedor != null && !this._proveedor.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this._proveedor != null && this._proveedor.Id.HasValue)
                this.ProveedorId = this._proveedor.Id.Value;
            #endregion proveedor

            #region sucursal origen
            if (!string.IsNullOrEmpty(edi.sucursal_uuid))
                this._sucursal_origen = SucursalesService.GetPorUUID(edi.sucursal_uuid, sesion);
            if (this._sucursal_origen == null && edi.sucursal != null)
                this._sucursal_origen = new SucursalesService(edi.sucursal, almacenar_localmente, sesion);
            if (this._sucursal_origen == null)
                throw new Exception("No se encontró el UUID " + edi.sucursal_uuid + " ni se definieron los datos del objeto.");

            if (!this.SucursalOrigen.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.SucursalOrigen.Id.HasValue)
                this.SucursalOrigenId = this.SucursalOrigen.Id.Value;
            #endregion sucursal origen

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
                this.Caso.FlujoId = Definiciones.FlujosIDs.ORDEN_DE_PAGO;
                this.Caso.NroComprobante2 = this.NroReciboBeneficiario;
            }
            #endregion caso
        }
        private OrdenesPagoService(ORDENES_PAGORow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCaso
        public static OrdenesPagoService GetPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCaso(caso_id, sesion);
            }
        }

        public static OrdenesPagoService GetPorCaso(decimal caso_id, SessionService sesion)
        {
            var row = sesion.db.ORDENES_PAGOCollection.GetByCASO_ID(caso_id)[0];
            return new OrdenesPagoService(row);
        }
        #endregion GetPorCaso

       
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
