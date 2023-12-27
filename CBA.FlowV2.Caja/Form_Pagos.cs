using CBA.FlowV2.Caja.Notificaciones;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationContext = CBA.FlowV2.Services.ApplicationContext;

namespace CBA.FlowV2.Caja
{
    public partial class Form_Pagos : Form
    {
        #region Propiedades globales de clase
       
        private bool[] arrBoolPagesVisible;
        private CuentaCorrientePagosPersonaDetalleService _ctactePagoPersonaDetalle;
        private CuentaCorrientePagosPersonaDocumentoService _ctactePagoPersonaDocumento;
        private CuentaCorrienteCajasSucursalService _ctacteCajaSucursal;
        private AnticiposPersonaService _anticipoPersona;
        private NotasCreditoPersonaService _notaCreditoPersona;
        private CuentaCorrienteProcesadorasTarjetaService _procesadoraTarjeta;
        private bool vDebeEmitirseFactura;
        private ListViewItem vListViewItemValorEnProcesoDeBorrado = null;
        private int countTabPage =0;
        private decimal vFactura1CasoId;
        private string vNombreReporte = string.Empty;
        private string vTituloReporte = "Factura Nro.: ";
        private decimal vPersona;
        private bool vVentaCancelada = false;
        private decimal vCasoCajaRapida;
        public decimal vVuelto = CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo;
        private decimal vFactura2CasoId;
        private string vToolbarAccionesCompensacionTexto = "Compensar documentos";
        private string vToolbarAccionesLimpiarPagoFallido = "Limpiar pago fallido";
        private bool vPuedeModificarCotizacion = RolesService.Tiene("PAGOS DE PERSONA EDITAR COTIZACION");
        private string vResumenReciboMenuImprimir = "Imprimir";
        private string vResumenReciboMenuImprimirDuplicado = "Imprimir Duplicado";
        private string vResumenReciboMenuAnular = "Anular";
        private string vResumenReciboMenuEmitir = "Emitir";

        #region Permisos para comentarios casos
        private bool _puedeCrearComentarioPublico;
        private bool _puedeCrearComentarioPrivado;
        private bool _puedeVerComentarioPrivado;
        private bool _puedeVerComentarioPublico;
        private bool _puedeBorrarComentarioPrivado;
        private bool _puedeBorrarComentarioPublico;

        private bool puedeCrearComentarioPublico
        {
            get { return _puedeCrearComentarioPublico; }
            set { _puedeCrearComentarioPublico = value; }
        }
        private bool puedeCrearComentarioPrivado
        {
            get { return _puedeCrearComentarioPrivado; }
            set { _puedeCrearComentarioPrivado = value; }
        }
        private bool puedeVerComentarioPrivado
        {
            get { return _puedeVerComentarioPrivado; }
            set { _puedeVerComentarioPrivado = value; }
        }
        private bool puedeVerComentarioPublico
        {
            get { return _puedeVerComentarioPublico; }
            set { _puedeVerComentarioPublico = value; }
        }
        private bool puedeBorrarComentarioPrivado
        {
            get { return _puedeBorrarComentarioPrivado; }
            set { _puedeBorrarComentarioPrivado = value; }
        }
        private bool puedeBorrarComentarioPublico
        {
            get { return _puedeBorrarComentarioPublico; }
            set { _puedeBorrarComentarioPublico = value; }
        }
        #endregion Permisos para comentarios casos

        ListViewUtil listViewUtilDocumentos;
        ListViewUtil listViewUtilValores;
        decimal vCasoId; //id del caso
        string vCasoEstado; //estado del caso

        //va a guardar el id del recibo en caso que se haya emitido.
        private decimal _vNumeroRecibo;
        private string vColumnaDataGridViewCtacteSaldo = "saldo";
        private string vColumnaDataGridViewCtacteSaldoNoConfirmado = "saldo_no_confirmado";
        private string vColumnaDataGridViewDiasAtraso = "dias_atraso";
        private bool _vPuedeCambiarPersona;
        private decimal _vCabeceraId;
        private bool _vReciboEmitido;
        private bool _vPagoConfirmado;

        private decimal vFuncionarioCobradorId = Definiciones.Error.Valor.EnteroPositivo;
        private decimal vSucursalId = Definiciones.Error.Valor.EnteroPositivo;
        private bool vExisteCajaAbierta = false;

        private decimal vNumeroRecibo
        {
            get { return this._vNumeroRecibo; }
            set { this._vNumeroRecibo = value; }
        }

        private CuentaCorrientePagosPersonaDetalleService ctactePagoPersonaDetalle
        {
            get { return this._ctactePagoPersonaDetalle; }
            set { this._ctactePagoPersonaDetalle = value; }
        }
        private CuentaCorrientePagosPersonaDocumentoService ctactePagoPersonaDocumento
        {
            get { return this._ctactePagoPersonaDocumento; }
            set { this._ctactePagoPersonaDocumento = value; }
        }
        private CuentaCorrienteCajasSucursalService ctacteCajaSucursal
        {
            get { return this._ctacteCajaSucursal; }
            set { this._ctacteCajaSucursal = value; }
        }
        private AnticiposPersonaService anticipoPesona
        {
            get { return this._anticipoPersona; }
            set { this._anticipoPersona = value; }
        }
        private NotasCreditoPersonaService notaCreditoPersona
        {
            get { return this._notaCreditoPersona; }
            set { this._notaCreditoPersona = value; }
        }
        private CuentaCorrienteProcesadorasTarjetaService procesadoraTarjeta
        {
            get { return this._procesadoraTarjeta; }
            set { this._procesadoraTarjeta = value; }
        }
        private decimal vCabeceraId
        {
            get { return this._vCabeceraId; }
            set { this._vCabeceraId = value; }
        }
        private bool vPuedeCambiarPersona
        {
            get { return this._vPuedeCambiarPersona; }
            set { this._vPuedeCambiarPersona = value; }
        }
        private bool vPagoConfirmado
        {
            get { return this._vPagoConfirmado; }
            set { this._vPagoConfirmado = value; }
        }
        private bool vReciboEmitido
        {
            get { return this._vReciboEmitido; }
            set { this._vReciboEmitido = value; }
        }

        #endregion Propiedades globales de clase
        public Form_Pagos(decimal clienteID, decimal Caso)
        {
            InitializeComponent();

            this.vPersona = clienteID;
            this.vCasoCajaRapida = Caso;
            VerificarUsuarioYCajaAbierta();
        }
        public Form_Pagos()
        {
            InitializeComponent();
        }
        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetDataSourcesValores();
            //control de que la sesion sea unica y actual

            SeleccionarFactura();
            CalcularTotalDocumentos();
            CalcularTotalValores();
            this.countTabPage = tabControlValores.TabPages.Count;

        }
        #endregion OnLoad

        #region SeleccionarFactura
        private void SeleccionarFactura()
        {
            //Se crea la cabecera si todavia no se guardo
            GuardarCabecera();

            //Se guarda el detalle solo si exite cabecera creada
            if (!vCabeceraId.Equals(CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo))
            {
                try
                {
                    string clausulas = CuentaCorrientePersonasService.PersonaId_NombreCol + " = " + this.vPersona + " and " +
                                CuentaCorrientePersonasService.CasoId_NombreCol + " = " + this.vCasoCajaRapida + " and " +
                              CuentaCorrientePersonasService.Credito_NombreCol + " > " + CuentaCorrientePersonasService.Debito_NombreCol + " and " +
                              CuentaCorrientePersonasService.CtactePersonaRelacionada_NombreCol + " is null and " +
                              " (" + CuentaCorrientePersonasService.VistaJuegoPagaresAprobado_NombreCol + " is null or " + CuentaCorrientePersonasService.VistaJuegoPagaresAprobado_NombreCol + " = 'S') ";
                    DataTable dt = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(clausulas, CuentaCorrientePersonasService.FechaVencimiento_NombreCol);
                    DataRow dr = dt.Rows[0];
                    System.Collections.Hashtable campos = new System.Collections.Hashtable();
                    campos.Add(CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol, vCabeceraId);
                    campos.Add(CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol, dr[CuentaCorrientePersonasService.Id_NombreCol]);
                    campos.Add(CuentaCorrientePagosPersonaDocumentoService.Observacion_NombreCol, dr[CuentaCorrientePersonasService.VistaObservacion_NombreCol]);
                    campos.Add(CuentaCorrientePagosPersonaDocumentoService.CotizacionMoneda_NombreCol, dr[CuentaCorrientePersonasService.CotizacionMoneda_NombreCol]);
                    campos.Add(CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol, dr[CuentaCorrientePersonasService.Credito_NombreCol]);
                    //Guardar los datos
                    CuentaCorrientePagosPersonaDocumentoService.Guardar(campos);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }
        #endregion SeleccionarFactura

        #region GuardarCabecera
        private bool GuardarCabecera()
        {
            //Se valida que los campos obligatorios esten completos y que la informacion sea valida
            bool exito = false;
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    decimal funcionarioId = UsuariosService.GetFuncionarioId(sesion.Usuario_Id);
                    bool registroNuevo = true;
                    System.Collections.Hashtable campos = new System.Collections.Hashtable();

                    campos.Add(PagosDePersonaService.SucursalId_NombreCol, ApplicationContext.Session["sucursalID"]);
                    campos.Add(PagosDePersonaService.MonedaId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.MonedaBaseSistemaId));//cambiar luego por definiciones
                    campos.Add(PagosDePersonaService.CotizacionMoneda_NombreCol, CotizacionesService.GetCotizacionMonedaVenta(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.MonedaBaseSistemaId)));
                    //campos.Add(PagosDePersonaService.CotizacionMoneda_NombreCol, CotizacionesService.GetCotizacionMonedaVenta(Definiciones.Monedas.Guaranies));
                    campos.Add(PagosDePersonaService.FuncionarioCobradorId_NombreCol, funcionarioId);
                    campos.Add(PagosDePersonaService.PersonaId_NombreCol, this.vPersona);
                    campos.Add(PagosDePersonaService.VueltoConvertidoAAnticipo_NombreCol, CBA.FlowV2.Services.Base.Definiciones.SiNo.No);
                    campos.Add(PagosDePersonaService.Fecha_NombreCol, DateTime.Now);
                    /*
                    if (ComboBoxUtil.ValidarSeleccionado(cboEditarCabeceraConcepto))
                        campos.Add(PagosDePersonaService.TextoPredefinidoId_NombreCol, cboEditarCabeceraConcepto.SelectedValue);
                    
                    if (groupBoxResumenFactura1.Visible && chkResumenFactura1.Checked && ComboBoxUtil.ValidarSeleccionado(cboResumenAutonumeracionFactura1))
                        campos.Add(PagosDePersonaService.FCCliente1CompAutonId_NombreCol, cboResumenAutonumeracionFactura1.SelectedValue);

                    if (groupBoxResumenFactura2.Visible && chkResumenFacturarRecargosAparte.Checked && ComboBoxUtil.ValidarSeleccionado(cboResumenAutonumeracionFactura2))
                        campos.Add(PagosDePersonaService.FCCliente2CompAutonId_NombreCol, cboResumenAutonumeracionFactura2.SelectedValue);
                    */
                    campos.Add(PagosDePersonaService.ReciboEmitirPorDocumentos_NombreCol, CBA.FlowV2.Services.Base.Definiciones.SiNo.No);
                    /////importante////
                    ///preguntar como obtener la autonumeracion
                    AutonumeracionesService autonumServices = new AutonumeracionesService();
                    campos.Add(PagosDePersonaService.AutonumeracionReciboId_NombreCol, autonumServices.GetAutonumeracionesPorIP(Dns.GetHostName()));
                    /*
                    if (!vFuncionarioCobradorId.Equals(CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo))
                        campos.Add(PagosDePersonaService.FuncionarioCobradorExterId_NombreCol, vFuncionarioCobradorId);
                    
                    if (!vCabeceraId.Equals(CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo))
                        campos.Add(PagosDePersonaService.Id_NombreCol, vCabeceraId);
                    */
                    //Guardar los datos
                    decimal pagoId = 0;
                    exito = PagosDePersonaService.Guardar(campos, registroNuevo, ref vCasoId, ref vCasoEstado, ref pagoId);
                }
                //Si el caso fue creado con exito en esta llamada, se actualiza el id del registro
                if (exito && vCasoId != CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo)
                {
                    DataTable caso = PagosDePersonaService.GetPagosDePersonaInfoCompleta(PagosDePersonaService.CasoId_NombreCol + " = " + vCasoId, string.Empty);
                    vCabeceraId = (decimal)caso.Rows[0][PagosDePersonaService.Id_NombreCol];
                }
            }
            catch (Exception exp)
            {
                exito = false;
                MessageBox.Show(exp.Message);
            }
            return exito;
        }
        #endregion GuardarCabecera

        #region CalcularTotalValores
        private void CalcularTotalValores()
        {
            try
            {
                decimal total = CuentaCorrientePagosPersonaDetalleService.GetMontoTotal(vCabeceraId);
                decimal vuelto;
                //Se muestra el monto total
                txtPagado.Text = total > 0 ? total.ToString("###,###.##") : "0";
                txtPagado.Tag = total;
                //Se actualiza el monto del vuelto
                vuelto = Interprete.Redondear(total - (decimal)txtTotal.Tag, 0);
                txtVuelto.Tag = vuelto;

                txtVuelto.Text = vuelto != 0 ? vuelto.ToString("###,###.##") : "0";
                this.vVuelto = decimal.Parse(txtVuelto.Text);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        #endregion CalcularTotalValores

        #region CalcularTotalDocumentos
        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal totalCredito, totalContado, totalFinanciero, totalRecargo;
                CuentaCorrientePagosPersonaDocumentoService.GetMontoTotal(vCabeceraId, out totalContado, out totalCredito, out totalFinanciero, out totalRecargo);

                decimal total = totalCredito + totalContado + totalFinanciero + totalRecargo;
                decimal vuelto;
                numericValoresEfectivoMonto.Value = total;
                numericValoresPOSMonto.Value = total;
                numericValoresChequeMonto.Value = total;
                numericValoresNotaMonto.Value = total;

                //Se muestra el monto total
                txtTotal.Text = total > 0 ? total.ToString("###,###.##") : "0";
                txtTotal.Tag = total;
                //Se actualiza el monto del vuelto
                vuelto = (decimal)txtTotal.Tag - total;
                txtVuelto.Tag = vuelto;
                txtVuelto.Text = vuelto != 0 ? vuelto.ToString("###,###.##") : "0";
                this.vVuelto = decimal.Parse(txtVuelto.Text);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        #endregion CalcularTotalDocumentos

        #region VerificarUsuarioYCajaAbierta
        private void VerificarUsuarioYCajaAbierta()
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    vFuncionarioCobradorId = UsuariosService.GetFuncionarioId(sesion.Usuario_Id);
                    if (vFuncionarioCobradorId == Definiciones.Error.Valor.EnteroPositivo)
                        throw new Exception("No existe un funcionario asociado al usuario.");
                    vSucursalId = sesion.SucursalActiva_Id;

                    vExisteCajaAbierta = vExisteCajaAbierta = CuentaCorrienteCajasSucursalService.GetExisteCajaAbiertaParaSucursalYFuncionario(vSucursalId, vFuncionarioCobradorId);

                    if (!vExisteCajaAbierta)
                        throw new Exception("No existe una caja abierta para el usuario.");
                }

            }
            catch (Exception ex)
            {

                Alert.Show(ex.Message, Notificaciones.Form_Alert.enmType.Error);
            }

        }
        #region Getters
        public decimal GetUltimoVuelto()
        {
            return this.vVuelto;
        }

        public bool GetVentaCancelada()
        {
            return vVentaCancelada;
        }
        #endregion Getters

        #endregion VerificarUsuarioYCajaAbierta

        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarTabPage();
        }
        #region ValidarSeleccionado
        /// <summary>
        /// Controla que el combo tenga un valor seleccionado
        /// y que el ajax haya terminado de cargar los valores
        /// </summary>
        /// <param name="cbo">The combobox</param>
        /// <returns></returns>
        private bool ValidarSeleccionado(ComboBox cbo)
        {
            return !(cbo.SelectedItem == null || cbo.SelectedValue.ToString() == "System.Data.DataRowView");
        }
        #endregion ValidarSeleccionado

        private void MostrarTabPage()
        {
            if (ValidarSeleccionado(cboTipoPago))
            {
               int index = int.Parse(cboTipoPago.SelectedValue.ToString());
               
                for (int i = 0; i < this.countTabPage; i++)
                {
                    tabControlValores.ShowHideTab(i, false);
                }
                tabControlValores.ShowHideTab(index, true);
                // tabControlValores.TabPages[i].Visible = true;
                tabControlValores.SelectedIndex = index;
            }
        }

        #region SetDataSources
        private void SetDataSourcesValores()
        {

            //cboTipoPago
            RefrescarComboBoxATipoPago(ref cboTipoPago);
            RefrescarComboBoxMonedas(ref cboValoresEfectivoMoneda);
            RefrescarComboBoxMonedas(ref cboValoresChequeMoneda);
            RefrescarComboBoxMonedas(ref cboValoresNotaMoneda);
            //Valores POS
            RefrescarComboBoxProcesadoraTarjetas(ref cboTarjetaPOS);
            RefrescarComboBoxPos(ref cboPOS);
            RefrescarComboBoxMonedas(ref cboMonedaPOS);

        }
        private DataTable TablaValores()
        {
            // Crear un DataTable con las columnas "index" y "nombre".
            DataTable dtValores = new DataTable();
            dtValores.Columns.Add("index", typeof(int));
            dtValores.Columns.Add("nombre", typeof(string));

            // Recorrer las páginas del TabControl y agregar datos al DataTable.
            for (int i = 0; i < tabControlValores.TabPages.Count; i++)
            {
                dtValores.Rows.Add(i, tabControlValores.TabPages[i].Text);
            }

            return dtValores;
        }

        private void RefrescarComboBoxATipoPago(ref ComboBox comboBox)
        {
            comboBox.DataSource = TablaValores();
            comboBox.ValueMember = "index";
            comboBox.DisplayMember = "nombre";
            comboBox.SelectedValue = 0;
        }
        private void RefrescarComboBoxProcesadoraTarjetas(ref ComboBox comboBox)
        {
            CuentaCorrienteProcesadorasTarjetaService tarjeta = new CuentaCorrienteProcesadorasTarjetaService();
            comboBox.DataSource = null;

            comboBox.DataSource = tarjeta.GetProcesadorasTarjetaDataTable(string.Empty, string.Empty, true);
            //comboBox.DataSource = CuentaCorrienteProcesadorasTarjetaService.GetPro
            comboBox.ValueMember = CuentaCorrienteProcesadorasTarjetaService.Id_NombreCol;
            comboBox.DisplayMember = CuentaCorrienteProcesadorasTarjetaService.Nombre_NombreCol;
        }
        private void RefrescarComboBoxPos(ref ComboBox comboBox)
        {
            using (SessionService sesion = new SessionService())
            {
                decimal funcionarioId = UsuariosService.GetFuncionarioId(sesion.Usuario_Id);

                string clausulas = string.Empty;

                clausulas += CuentaCorrientePosService.SucursalId_NombreCol + " = " + (decimal)ApplicationContext.Session["sucursalID"];

                comboBox.DataSource = CuentaCorrientePosService.GetPosDataTable(clausulas, CuentaCorrientePosService.Nombre_NombreCol, true);
                comboBox.ValueMember = CuentaCorrientePosService.Id_NombreCol;
                comboBox.DisplayMember = CuentaCorrientePosService.Nombre_NombreCol;
                // selecciona POS por defecto
                DataTable dtCajaAbierta = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionarioInfoCompleta((decimal)ApplicationContext.Session["sucursalID"], funcionarioId);
                decimal cajaTesoreriaId = Definiciones.Error.Valor.EnteroPositivo;
                if (dtCajaAbierta.Rows.Count > 0)
                    cajaTesoreriaId = decimal.Parse(dtCajaAbierta.Rows[0][CuentaCorrienteCajasSucursalService.CtacteCajaTesoreriaId_NombreCol].ToString());

                DataTable dtCajaTesoreria = CuentaCorrienteCajasTesoreriaService.GetCuentaCorrienteCajasTesoreriaDataTable(CuentaCorrienteCajasTesoreriaService.Id_NombreCol + " = " + cajaTesoreriaId, string.Empty, true);
                decimal posDefectoId = Definiciones.Error.Valor.EnteroPositivo;
                if (dtCajaTesoreria.Rows.Count > 0)
                {
                    if (!dtCajaTesoreria.Rows[0][CuentaCorrienteCajasTesoreriaService.POSId_NombreCol].Equals(System.DBNull.Value))
                        posDefectoId = decimal.Parse(dtCajaTesoreria.Rows[0][CuentaCorrienteCajasTesoreriaService.POSId_NombreCol].ToString());
                    //     else // la caja no tiene asignada un POS por defecto
                }
                comboBox.SelectedValue = posDefectoId;
            }
        }
        #endregion SetDataSources

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Pagos_FormClosing(object sender, FormClosingEventArgs e)
        {
            decimal vuelto = Decimal.Parse(txtVuelto.Text);

            if (listViewValores.RowCount == 0)
            {
                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();

                camposCaso.Add(CasosService.Estado_NombreCol, Definiciones.Estado.Inactivo);
                if (this.vCasoId != 0)
                {
                    using (SessionService sesion = new SessionService())
                    {
                        CasosService.ActualizarCampos(this.vCasoId, camposCaso, sesion);
                    }
                }

                #endregion Actualizar datos en tabla casos

                vVentaCancelada = true;

            }
            else
            {
                if (vuelto < 0)
                {
                    e.Cancel = true;
                    MessageBox.Show("Debe pagar el total de la venta", "Terminar Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (vuelto >= 0)
                {
                    CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService ToolbarFlujo = new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService();

                    PagosDePersonaService pagoService = new PagosDePersonaService();
                    string mensaje;
                    bool exito;
                    using (SessionService sesion = new SessionService())
                    {
                        exito = pagoService.ProcesarCambioEstado(this.vCasoId, CBA.FlowV2.Services.Base.Definiciones.EstadosFlujos.Aprobado, true, out mensaje, sesion);
                        if (exito)

                            exito = ToolbarFlujo.ProcesarCambioEstado(this.vCasoId, CBA.FlowV2.Services.Base.Definiciones.EstadosFlujos.Aprobado, "Transición automática ", sesion);
                        if (exito)
                            pagoService.EjecutarAccionesLuegoDeCambioEstado(this.vCasoId, CBA.FlowV2.Services.Base.Definiciones.EstadosFlujos.Aprobado, sesion);
                        //verReportes(this.vCasoCajaRapida);
                        if (!mensaje.Equals(string.Empty))
                            MessageBox.Show(mensaje, "Terminar Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void RefrescarComboBoxMonedas(ref ComboBox comboBox)
        {
            comboBox.DataSource = MonedasService.GetMonedasActivasPorEntidadPais((decimal)ApplicationContext.Session["sucursalID"]);
            comboBox.ValueMember = MonedasService.Modelo.IDColumnName;
            comboBox.DisplayMember = MonedasService.Modelo.NOMBREColumnName;

            //Asegura que se disparen las acciones por cambio de seleccion
            if (ValidarSeleccionado(comboBox))
            {
                decimal monedaId = (decimal)comboBox.SelectedValue;
                comboBox.SelectedItem = null;
                comboBox.SelectedItem = null;
                comboBox.SelectedValue = monedaId;
            }
        }


        #region Actualizar Cotización
        private void ActualizarCotizacion(ref NumericUpDown numeric, ref ComboBox comboBox, DateTime fecha)
        {
            try
            {
                decimal pais_id = SucursalesService.GetPais(decimal.Parse(ApplicationContext.Session["sucursalID"].ToString()));
                decimal cotizacion = CotizacionesService.GetCotizacionMonedaVenta(pais_id, (decimal)comboBox.SelectedValue, fecha);

                if (cotizacion.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    MessageBox.Show("La moneda no tiene una cotización actualizada.");
                    return;
                }
                numeric.Value = cotizacion;
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void ActualizarCotizacion(ref NumericUpDown numeric, ref ComboBox comboBox)
        {
            ActualizarCotizacion(ref numeric, ref comboBox, DateTime.Now);
        }
        #endregion Actualizar Cotización

        private void cboValoresChequeMoneda_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ValidarSeleccionado(cboValoresChequeMoneda))
            {
                numericValoresChequeMonto.DecimalPlaces = MonedasService.CantidadDecimalesStatic((decimal)cboValoresChequeMoneda.SelectedValue);

                numericValoresChequeCotizacion.DecimalPlaces = numericValoresEfectivoMonto.DecimalPlaces;

                if ((decimal)cboValoresEfectivoMoneda.SelectedValue == VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.MonedaBaseSistemaId))
                {
                    numericValoresChequeCotizacion.Enabled = false;
                    numericValoresChequeCotizacion.Value = 1;
                }
                else
                {
                    numericValoresChequeCotizacion.Enabled = this.vPuedeModificarCotizacion;
                }
                ActualizarCotizacion(ref numericValoresPosCotizacion, ref cboValoresEfectivoMoneda);
            }
        }

        private void cboValoresNotaMoneda_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ValidarSeleccionado(cboValoresNotaMoneda))
            {
                numericValoresNotaMonto.DecimalPlaces = MonedasService.CantidadDecimalesStatic((decimal)cboValoresNotaMoneda.SelectedValue);

                numericValoresNotaCotizacion.DecimalPlaces = numericValoresEfectivoMonto.DecimalPlaces;

                if ((decimal)cboValoresNotaMoneda.SelectedValue == VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.MonedaBaseSistemaId))
                {
                    numericValoresNotaCotizacion.Enabled = false;
                    numericValoresNotaCotizacion.Value = 1;
                }
                else
                {
                    numericValoresPosCotizacion.Enabled = this.vPuedeModificarCotizacion;
                }
                ActualizarCotizacion(ref numericValoresPosCotizacion, ref cboValoresEfectivoMoneda);
            }
        }

        private void cboValoresEfectivoMoneda_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ValidarSeleccionado(cboValoresEfectivoMoneda))
            {
                numericValoresEfectivoMonto.DecimalPlaces = MonedasService.CantidadDecimalesStatic((decimal)cboValoresEfectivoMoneda.SelectedValue);

                numericValoresEfectivoCotizacion.DecimalPlaces = numericValoresEfectivoMonto.DecimalPlaces;

                if ((decimal)cboValoresEfectivoMoneda.SelectedValue == VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.MonedaBaseSistemaId))
                {
                    numericValoresEfectivoCotizacion.Enabled = false;
                    numericValoresEfectivoCotizacion.Value = 1;
                }
                else
                {
                    numericValoresPosCotizacion.Enabled = this.vPuedeModificarCotizacion;
                }
                ActualizarCotizacion(ref numericValoresEfectivoCotizacion, ref cboValoresEfectivoMoneda);
            }
        }
        private void cboMonedaPOS_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ValidarSeleccionado(cboMonedaPOS))
            {
                numericValoresPOSMonto.DecimalPlaces = MonedasService.CantidadDecimalesStatic((decimal)cboMonedaPOS.SelectedValue);

                numericValoresPosCotizacion.DecimalPlaces = numericValoresEfectivoMonto.DecimalPlaces;

                if ((decimal)cboValoresEfectivoMoneda.SelectedValue == VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.MonedaBaseSistemaId))
                {
                    numericValoresPosCotizacion.Enabled = false;
                    numericValoresPosCotizacion.Value = 1;
                }
                else
                {
                    numericValoresPosCotizacion.Enabled = this.vPuedeModificarCotizacion;
                }
                ActualizarCotizacion(ref numericValoresPosCotizacion, ref cboValoresEfectivoMoneda);
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (ValidarSeleccionado(cboTipoPago))
            {
                switch (cboTipoPago.Text)
                {
                    case Definiciones.TipoPago.Efectivo:
                        CobroEfectivo();
                        break;
                    case Definiciones.TipoPago.Cheque:
                        CobroCheque();
                        break;
                    case Definiciones.TipoPago.NotaCredito:
                        CobroNota();
                        break;
                    case Definiciones.TipoPago.POS:
                        CobroNota();
                        break;
                    default:
                        break;
                }
            }

        }

        private void cboTipoPago_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            MostrarTabPage();
        }
        private void CobroPos()
        {

            //Se crea la cabecera si todavia no se guardo
            if (vCabeceraId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                GuardarCabecera();

            //Se guarda el detalle solo si exite cabecera creada
            if (!vCabeceraId.Equals(Definiciones.Error.Valor.EnteroPositivo))
            {
                //Se valida que los campos obligatorios esten completos y que la informacion sea valida
                if (!ValidarCamposDetalle(Definiciones.CuentaCorrienteValores.POS)) return;

                try
                {
                    System.Collections.Hashtable campos = new System.Collections.Hashtable();
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol, vCabeceraId);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.POS);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.PosId_NombreCol, cboPOS.SelectedValue);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.Monto_NombreCol, numericValoresPOSMonto.Value);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.CtacteProcesadoraTarjetaId_NombreCol, CuentaCorrienteProcesadorasTarjetaService.GetProcesadorasIdporTarjetaId((decimal)cboTarjetaPOS.SelectedValue));
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.MontoNeto_NombreCol, numericValoresPOSMonto.Value);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.MonedaId_NombreCol, cboMonedaPOS.SelectedValue);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.TarjetaNro_NombreCol, txtCuponPOS.Text);
                    //Guardar los datos
                    CuentaCorrientePagosPersonaDetalleService.Guardar(campos);

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            RefrescarListViewValores();
            verificarVuelto();
        }
        private void CobroNota()
        {
            //Se crea guarda la cabecera            
            GuardarCabecera();

            //Se guarda el detalle solo si exite cabecera creada
            if (!vCabeceraId.Equals(Definiciones.Error.Valor.EnteroPositivo))
            {
                //Se valida que los campos obligatorios esten completos y que la informacion sea valida
                if (!ValidarCamposDetalle(Definiciones.CuentaCorrienteValores.NotaDeCredito)) return;

                try
                {
                    System.Collections.Hashtable campos = new System.Collections.Hashtable();
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol, vCabeceraId);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.NotaDeCredito);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.MonedaId_NombreCol, cboValoresNotaMoneda.SelectedValue);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.Monto_NombreCol, numericValoresNotaMonto.Value);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.NotaCreditoId_NombreCol, cboValoresNotaCaso.SelectedValue);
                    //Guardar los datos
                    CuentaCorrientePagosPersonaDetalleService.Guardar(campos);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                RefrescarListViewValores();
            }
        }
        private void CobroCheque() 
        {
            //Se crea la cabecera si todavia no se guardo
            if (vCabeceraId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                GuardarCabecera();

            //Se guarda el detalle solo si exite cabecera creada
            if (!vCabeceraId.Equals(Definiciones.Error.Valor.EnteroPositivo))
            {
                //Se valida que los campos obligatorios esten completos y que la informacion sea valida
                if (!ValidarCamposDetalle(Definiciones.CuentaCorrienteValores.Cheque)) return;

                try
                {
                    string nroCuentaAux = txtValoresChequeNroCuenta.Text; //guarda el valor de la ultima cuenta cargada
                    System.Collections.Hashtable campos = new System.Collections.Hashtable();

                    campos.Add(CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol, vCabeceraId);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Cheque);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.MonedaId_NombreCol, cboValoresChequeMoneda.SelectedValue);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.CotizacionMoneda_NombreCol, numericValoresChequeCotizacion.Value);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.Monto_NombreCol, numericValoresChequeMonto.Value);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.ChequeDeTerceros_NombreCol, rdoChequeDeTerceros.Checked ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.ChequeCtacteBancoId_NombreCol, cboValoresChequeBanco.SelectedValue);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.ChequeFechaPosdatada_NombreCol, dateTimeValoresChequeFechaPosdatado.Value);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.ChequeEsDiferido_NombreCol, chkValoresChequeEsDiferido.Checked ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                    if (chkValoresChequeEsDiferido.Checked)
                        campos.Add(CuentaCorrientePagosPersonaDetalleService.ChequeFechaVencimiento_NombreCol, dateTimeValoresChequeFechaVencimiento.Value);
                    else
                        campos.Add(CuentaCorrientePagosPersonaDetalleService.ChequeFechaVencimiento_NombreCol, dateTimeValoresChequeFechaPosdatado.Value);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.ChequeNombreBeneficiario_NombreCol, txtValoresChequeBeneficiario.Text);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.ChequeNombreEmisor_NombreCol, txtValoresChequeEmisor.Text);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.ChequeNroCheque_NombreCol, txtValoresChequeNroCheque.Text);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.ChequeNroCuenta_NombreCol, txtValoresChequeNroCuenta.Text);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.ChequeDocumentoEmisor_NombreCol, txtValoresChequeNroDocEmisor.Text);

                    //Guardar los datos
                    CuentaCorrientePagosPersonaDetalleService.Guardar(campos);

                    //Volver a cargar el textbox con el dato de la ultima cuenta cargada
                    txtValoresChequeNroCuenta.Text = nroCuentaAux;
                    txtValoresChequeNroCuenta.Focus();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
                RefrescarListViewValores();
            }
        }
        private void CobroEfectivo()
        {
            //Se crea la cabecera si todavia no se guardo
            if (vCabeceraId.Equals(CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo))
                GuardarCabecera();

            //Se guarda el detalle solo si exite cabecera creada
            if (!vCabeceraId.Equals(CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo))
            {
                //Se valida que los campos obligatorios esten completos y que la informacion sea valida
                if (!ValidarCamposDetalle(CBA.FlowV2.Services.Base.Definiciones.CuentaCorrienteValores.Efectivo)) return;

                try
                {
                    System.Collections.Hashtable campos = new System.Collections.Hashtable();
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol, vCabeceraId);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.CtacteValorId_NombreCol, CBA.FlowV2.Services.Base.Definiciones.CuentaCorrienteValores.Efectivo);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.MonedaId_NombreCol, cboValoresEfectivoMoneda.SelectedValue);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.Monto_NombreCol, numericValoresEfectivoMonto.Value);
                    campos.Add(CuentaCorrientePagosPersonaDetalleService.CotizacionMoneda_NombreCol, numericValoresEfectivoCotizacion.Value);
                    //Guardar los datos
                    CuentaCorrientePagosPersonaDetalleService.Guardar(campos);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            RefrescarListViewValores();
            verificarVuelto();
        }
        #region RefrescarListViewValores
        private void RefrescarListViewValores()
        {
            try
            {
                int auxInt;
                DataTable dtDetalles, dtCtactePago;


                //Si no se creo la cabecera no se asigna un DataSource
                if (vCabeceraId.Equals(CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo))
                {
                    listViewValores.DataSource = null;
                    return;
                }

                //Se obtiene la cabecera
                dtCtactePago = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + this.vCabeceraId, string.Empty);

                //Se asignan los datos la DataTable
                dtDetalles = CuentaCorrientePagosPersonaDetalleService.GetCuentaCorrientePagosPersonaDetalleInfoCompleta(vCabeceraId);

                //Columna utilizada para borrar el detalle
                dtDetalles.Columns.Add("borrar", typeof(bool));

                //Se asigna el DataSource
                listViewValores.DataSource = dtDetalles;
                int columnCount = listViewValores.ColumnCount;
                // Recorrer todas las columnas
                for (int i = 0; i < columnCount; i++)
                {
                    // Asignar la propiedad Visible a false
                    listViewValores.Columns[i].Visible = false;
                }

                #region Configuracion de columnas
                int displayIndex = 0;
                // Botón Eliminar
                int indice = listViewValores.Columns["borrar"].Index;
                listViewValores.Columns.RemoveAt(indice);
                DataGridViewImageColumn btnEliminarColumn = new DataGridViewImageColumn();
                btnEliminarColumn.Name = "borrar";
                btnEliminarColumn.HeaderText = string.Empty;
                btnEliminarColumn.Width = 25;
                btnEliminarColumn.DefaultCellStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                btnEliminarColumn.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightCoral;
                btnEliminarColumn.Image = Properties.Resources.borrar;
                btnEliminarColumn.DisplayIndex = displayIndex++;
                listViewValores.Columns.Insert(indice, btnEliminarColumn);

                auxInt = listViewValores.Columns[CuentaCorrientePagosPersonaDetalleService.VistaCtacteValorNombre_NombreCol].Index;
                listViewValores.Columns[auxInt].Visible = true;
                listViewValores.Columns[auxInt].HeaderText = "Tipo";
                listViewValores.Columns[auxInt].Width = 100;
                listViewValores.Columns[auxInt].DisplayIndex = 1;

                auxInt = listViewValores.Columns[CuentaCorrientePagosPersonaDetalleService.VistaMonedaNombre_NombreCol].Index;
                listViewValores.Columns[auxInt].Visible = true;
                listViewValores.Columns[auxInt].HeaderText = "Moneda";
                listViewValores.Columns[auxInt].Width = 70;
                listViewValores.Columns[auxInt].DisplayIndex = 2;

                auxInt = listViewValores.Columns[CuentaCorrientePagosPersonaDetalleService.Monto_NombreCol].Index;
                listViewValores.Columns[auxInt].Visible = true;
                listViewValores.Columns[auxInt].HeaderText = "Monto";
                listViewValores.Columns[auxInt].Width = 50;
                listViewValores.Columns[auxInt].DisplayIndex = 3;

                auxInt = listViewValores.Columns[CuentaCorrientePagosPersonaDetalleService.CotizacionMoneda_NombreCol].Index;
                listViewValores.Columns[auxInt].Visible = true;
                listViewValores.Columns[auxInt].HeaderText = "Cotización";
                listViewValores.Columns[auxInt].Width = 50;
                listViewValores.Columns[auxInt].DisplayIndex = 4;

                auxInt = listViewValores.Columns[CuentaCorrientePagosPersonaDetalleService.VistaObservacion_NombreCol].Index;
                listViewValores.Columns[auxInt].Visible = true;
                listViewValores.Columns[auxInt].HeaderText = "Detalle";
                listViewValores.Columns[auxInt].Width = 250;
                listViewValores.Columns[auxInt].DisplayIndex = 5;
                #endregion Configuracion de columnas


                listViewValores.CellClick += cmdQuitarListViewValoresItem_Click;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            CalcularTotalValores();
        }
        private void cmdQuitarListViewValoresItem_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {



                if (MessageBox.Show("¿Está seguro de borrar el valor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    decimal detallePagoId = decimal.Parse(listViewValores.Rows[e.RowIndex].Cells[CuentaCorrientePagosPersonaDetalleService.Id_NombreCol].Value.ToString());
                    CuentaCorrientePagosPersonaDetalleService.Borrar(detallePagoId);
                    RefrescarListViewValores();
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        #endregion RefrescarListViewValores
        #region ValidarCamposDetalle
        private bool ValidarCamposDetalle(int tipoValor)
        {
            bool ok = true;
            string message = string.Empty;

            switch (tipoValor)
            {

                case CBA.FlowV2.Services.Base.Definiciones.CuentaCorrienteValores.Efectivo:
                    if (!ValidarSeleccionado(cboValoresEfectivoMoneda))
                    {
                        ok = false;
                        message = "Debe seleccionar una moneda.";
                    }
                    break;

                case CBA.FlowV2.Services.Base.Definiciones.CuentaCorrienteValores.Cheque:
                    if (!ValidarSeleccionado(cboValoresChequeBanco))
                    {
                        ok = false;
                        message = "Debe seleccionar un banco.";
                    }
                    if (txtValoresChequeNroCuenta.Text == string.Empty)
                    {
                        ok = false;
                        message = "Debe indicar el número de cuenta bancaria.";
                    }
                    if (txtValoresChequeNroCheque.Text == string.Empty)
                    {
                        ok = false;
                        message = "Debe indicar el número de cheque.";
                    }
                    if (txtValoresChequeEmisor.Text == string.Empty)
                    {
                        ok = false;
                        message = "Debe indicar el nombre del emisor.";
                    }
                    if (txtValoresChequeBeneficiario.Text == string.Empty)
                    {
                        ok = false;
                        message = "Debe indicar el nombre del beneficiario.";
                    }
                    if (!ValidarSeleccionado(cboValoresChequeMoneda))
                    {
                        ok = false;
                        message = "Debe seleccionar una moneda.";
                    }
                    if (chkValoresChequeEsDiferido.Checked && dateTimeValoresChequeFechaVencimiento.Value < dateTimeValoresChequeFechaPosdatado.Value)
                    {
                        ok = false;
                        message = "Si el cheque es diferido, la fecha de vencimiento del cheque debe ser posterior a la fecha de emisión.";
                    }
                    break;

                case CBA.FlowV2.Services.Base.Definiciones.CuentaCorrienteValores.NotaDeCredito:
                    if (!ValidarSeleccionado(cboValoresNotaCaso))
                    {
                        ok = false;
                        message = "Debe seleccionar una Nota de Crédito a aplicar.";
                    }
                    if (numericValoresNotaMonto.Value > (decimal)lblValoresNotaSaldo.Tag)
                    {
                        ok = false;
                        message = "El monto aplicar es mayor que el saldo disponible.";
                    }
                    break;

                default:
                    break;

                    
            }
            if (message.Length > 0) MessageBox.Show(message);
            return ok;
        }
        #endregion ValidarCamposDetalle
        #region verificarVuelto
        private void verificarVuelto()
        {
            decimal vuelto = decimal.Parse(txtVuelto.Text.ToString());
            if (vuelto >= 0)
            {
                this.Close();
            }
        }
        #endregion verificarVuelto

        private void chkValoresChequeEsDiferido_CheckedChanged(object sender, EventArgs e)
        {
            dateTimeValoresChequeFechaVencimiento.Visible = chkValoresChequeEsDiferido.Checked;
            lblValoresChequeFechaVencimiento.Visible = chkValoresChequeEsDiferido.Checked;
        }

        private void rdoChequeEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoChequeEmpresa.Checked)
                txtValoresChequeBeneficiario.Text = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.NombreEmpresa);
        }

        private void rdoChequePortador_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoChequePortador.Checked)
                txtValoresChequeBeneficiario.Text = "Al Portador";
        }

        private void rdoChequeDeTerceros_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoChequeDeTerceros.Checked)
                txtValoresChequeBeneficiario.Text = "De Terceros";
        }
    }
}
