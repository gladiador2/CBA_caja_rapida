#region using
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.ListaDePrecio;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CBA.FlowV2.Db;
using ApplicationContext = CBA.FlowV2.Services.ApplicationContext;
using CBA.FlowV2.Services.Sesion;
using System.Net;
using CBA.FlowV2.Services.Stock;
using static CBA.FlowV2.Services.Herramientas.TransaccionesService;
using System.Web;
using CBA.FlowV2.Caja.Notificaciones;
using static System.Collections.Specialized.BitVector32;
using CBA.FlowV2.Services.PeticionesApi;
using CBA.FlowV2.Services.Comercial;
using static CBA.FlowV2.Services.Base.EdiCBA;
using static CBA.FlowV2.Services.Base.Definiciones;
using static CBA.FlowV2.Services.Contabilidad.AsientosDetalleService;
using Microsoft.Win32;

#endregion using

namespace CBA.FlowV2.Caja
{
    public partial class CajaForm : Form
    {
        #region Propiedades privadas
        private UsuariosService _usuarios;
        private UnidadesService _unidades;
        private ListasDePrecioService _listasDePrecio;
        private FacturasClienteDetalleArticulosPadresService _detalleArticulosPadre;
        private CotizacionesService _cotizaciones = new CotizacionesService();
        private CuentaCorrienteCajasSucursalService _cajasSucursal;
        private MenuItem[] _vToolBarMenuItemImprimir;
        private DataGridViewCellEventArgs vCelda;
        private Form ticket;
        private decimal vDeposito;
        private int contShow = 0;
        private bool permitirCambio = true;
        private bool cambioPorCodigo = false;
        private bool vProductoSeleccionado = false;
        private bool vCajaIniciada = false;
        private string vDirectoriBascula = "Y:\\grolon\\";
        private decimal vClienteDefecto = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.IdClientePorDefault);
        private decimal vPrecioServicio = Definiciones.Error.Valor.EnteroPositivo;
        private string vCodigoBalanza = string.Empty;
        private string vToolBarMenuItemAccionesCrearCasoPagoPersonas = "Crear " + FlujosService.GetFlujoDescripcion(Definiciones.FlujosIDs.PAGO_DE_PERSONAS).ToLower();
        private string vToolBarMenuItemAccionesCrearPagareGarantia = "Crear Pagaré de Garantía";
        private string vToolBarMenuItemAccionesDesmarcarImpreso = "Desmarcar Impreso";
        private string vToolBarMenuItemAccionesVerEstadoCuenta = "Ver estado de cuenta";
        private static string listViewAsignarCentrosCosto_NombreCol = "col_asignar_centros_costo";
        private System.ComponentModel.ComponentResourceManager resources;
        
        private RepartosDetalleService _repartos;
        private ListViewUtil listViewUtilDetalles;
        private ListViewUtil listViewUtilSaldos;
        private ListViewUtil listViewUtilPagosCheques;
        private ListViewUtil listViewUtilNotasCreditoRel;

        private SolicitarCamposService.Campo[] _campos;
        

        //Factor utilizado para convertir el precio traido de la base de datos
        //de la unidad de medida original del articulo al la unidad de medida seleccionada por el usuario
        string vUnidadMedidaOriginal = string.Empty; //Unidad de medida en que se maneja el articulo originalmente
        private decimal articuloRecargoFinancieroId = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteArticuloPorRecargoFinanciero);
        private int previoIndice;
        private string vNombreReporte = string.Empty;
        private string vTituloReporte = string.Empty;
        private decimal vCasoId = Definiciones.Error.Valor.EnteroPositivo;
        private decimal vAutonumeracionID = Definiciones.Error.Valor.EnteroPositivo;
        private string vNroFactura = string.Empty;
        private string vCasoNPId = string.Empty;
        private string vCasoEstado = string.Empty;
        private decimal vCasoRepartoRelacionaFC;
        private decimal vArticuloId; //para almacenar el id del articulo seleccionado
        private decimal vCabeceraID = Definiciones.Error.Valor.EnteroPositivo; //ID de la tabla cabecera del caso
        private decimal vFactClienteDetalleId; //ID del detalle de la factura creada
        private decimal vloteID;
        private decimal vSucursalId;
        private decimal vUsuarioId;
        private decimal vCantidad = 1;
        private decimal vPrecio;
        private decimal vListaPrecioID;
        private decimal vDetalleID; //ID del detalle de la tabla cabecera
        private decimal vArticuloCantidadPorCaja; //Cantidad de unidades contenidas por una caja del articulo seleccionado
        private decimal vArticuloPrecioBruto; //Precio bruto del articulo seleccionado, en la unidad original
        private bool vCampoVendedorObligatorio = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FacturaClienteVendedorObligatorio).Equals(Definiciones.SiNo.Si);
        private bool vCalendarioSoloLectura;
        private bool vPuedeVerCentrosCosto = RolesService.Tiene("FC CLIENTE ASIGNAR CENTRO COSTO VER");
        private bool vPuedeCargarEnvases = RolesService.Tiene("CAJA RAPIDA CARGAR ENVASES");

        private bool vPuedeEditarCentrosCosto = RolesService.Tiene("FC CLIENTE ASIGNAR CENTRO COSTO EDITAR");
        private bool vTieneRolActivosAsociarFlujo = RolesService.Tiene("ACTIVOS ASOCIAR FLUJO");
        private bool vTieneRolVerRecargoFinanciero = RolesService.Tiene("FC CLIENTE VER RECARGO FINANCIERO");
        private bool vTieneRolEditarDescuentoCabecera = RolesService.Tiene("FC CLIENTE EDITAR DESCUENTO CABECERA");
        private bool vPuedeDesmarcarImpreso = RolesService.Tiene("FC CLIENTE PUEDE DESMARCAR IMPRESO");
        private bool vPuedeAgregarSinStock = RolesService.Tiene("CR AGREGAR DETALLE SIN STOCK");
        private bool vPuedeVerCasoAsociado = RolesService.Tiene("FC CLIENTE DETALLE VER CASO ASOCIADO");
        private bool vPuedeVerEditarAsociado = RolesService.Tiene("FC CLIENTE DETALLE EDITAR CASO ASOCIADO");
        private bool vPuedeEditarSucursalVenta = RolesService.Tiene("FC CLIENTE EDITAR SUCURSAL VENTA");
        private bool vPuedeModificarAfectaStock = RolesService.Tiene("FC CLIENTE MODIFICAR AFECTA STOCK");
        private bool vPuedeFacturadDepositosDistintos = RolesService.Tiene("FC PERSONA PUEDE FACTURAR DISTINTOS DEPOSITOS");
        private string vAfectaStock = Definiciones.SiNo.Si;//Valor por defecto para desmarcar inicialmente el check afecta stock

        private decimal vTotalMontoSinDto;
        private bool vImprimirReporteAgrupado = false;
        private decimal? nroComprobanteSecuencia = null;
        private decimal vTalonarioId = Definiciones.Error.Valor.EnteroPositivo;

        private string vImprimirConcatenadoGarantia = Definiciones.SiNo.No;
        private string vImprimirConcatenadoPagare = Definiciones.SiNo.No;
        private string vImprimirConcatenadoContrato = Definiciones.SiNo.No;

        private bool vVerListaPreciosEnDetalle = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.EstrategiaPrecio) == Definiciones.EstrategiaPrecio.FlujoModificacionListaPrecios && RolesService.Tiene("FACTURA CLIENTE VER LISTA PRECIO EN DETALLES");

        private string vTipoFactura = string.Empty;

        #region Accesors
        private UsuariosService usuarios
        {
            get { return this._usuarios; }
            set { this._usuarios = value; }
        }
        private UnidadesService unidades
        {
            get { return this._unidades; }
            set { this._unidades = value; }
        }
        private ListasDePrecioService listasDePrecio
        {
            get { return this._listasDePrecio; }
            set { this._listasDePrecio = value; }
        }
        public CotizacionesService cotizaciones
        {
            get { return _cotizaciones; }
            set { _cotizaciones = value; }
        }
        public FacturasClienteDetalleArticulosPadresService detalleArticulosPadre
        {
            get { return _detalleArticulosPadre; }
            set { _detalleArticulosPadre = value; }
        }
        private MenuItem[] vToolBarMenuItemImprimir
        {
            get { return this._vToolBarMenuItemImprimir; }
            set { this._vToolBarMenuItemImprimir = value; }
        }
        private CuentaCorrienteCajasSucursalService cajasSucursal
        {
            get { return this._cajasSucursal; }
            set { this._cajasSucursal = value; }
        }

        private RepartosDetalleService repartos
        {
            get { return this._repartos; }
            set { this._repartos = value; }
        }

        public SolicitarCamposService.Campo[] Campos
        {
            get { return _campos; }
            private set { _campos = value; }
        }
        #endregion Accesors

        #endregion Propiedades privadas

        #region constructor
        public CajaForm()
        {
            InitializeComponent();
        }
        #endregion constructor

        #region Load
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops! Parece que algo salio mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
         
        }
        #region Cargar load
        public void Cargar() 
        {
            try
            {
                Inicializarcaja();//inicializa el usuario la sucursal activa y el hostname o caja
                obtenerAutonumeracion();//obtenemos el talonario apartir de nuesta ip o hostname

                if (this.vCasoId != Definiciones.Error.Valor.EnteroPositivo)
                {
                    cargarDatosDelCaso();
                }
                else
                {
                    RefrescarComponentes(); // inicializa los controles para una nueva venta
                }

                CargarLabelFactura();

                previoIndice = cboPersonas.SelectedIndex;
                if (this.vCasoEstado == Definiciones.EstadosFlujos.Cerrado || this.vCasoEstado == Definiciones.EstadosFlujos.Anulado || this.vCasoEstado == Definiciones.EstadosFlujos.Caja)
                    desabilitarControles();
                else
                    habilitarControles();

                txtBusCliente.Focus();
            }
            catch (Exception)
            {
                throw;
               
            }
            
        }
        #endregion Cargar load

        #region Inicializar
        public void Inicializarcaja()

        {
            if (!this.vCajaIniciada)
            {
                using (Services.Sesion.SessionService sesion = new CBA.FlowV2.Services.Sesion.SessionService())
                {
                    lblNombreUsuario.Text = sesion.Usuario_Nombre;
                    lblNombreCaja.Text = Dns.GetHostName();
                    lblSucursalActiva.Text = sesion.SucursalActiva.NOMBRE.ToString();
                    this.vSucursalId = sesion.SucursalActiva.ID;
                    this.vUsuarioId = sesion.Usuario_Id;

                }
                this.vCajaIniciada = true;
                txtBuscarCaso_Leave(null, null);
            }
           
            
        }
        #endregion Inicializar

        #region LabeldeCabecera
        private void CargarSucursalDepositoDelaSession()
        {
            lblSucursal.Text = SucursalesService.GetNombreSucursal(this.vSucursalId);
            lblDeposito.Text = obtenerDepositoNombre();
        }

       

        private void CargarLabelFactura()
        {
            try
            {
                FACTURAS_CLIENTERow drFactura = new FACTURAS_CLIENTERow();
                using (SessionService sesion = new SessionService())
                {
                    if (this.vCabeceraID != Definiciones.Error.Valor.EnteroPositivo)//controlar que el caso este creado
                        drFactura = FacturasClienteService.GetFacturaCliente(vCabeceraID, sesion);//

                    // si no esta el caso respoderblanco en 
                    if (drFactura.NRO_COMPROBANTE != null && drFactura.NRO_COMPROBANTE != "")//el caso si esta creado pero controlar que el campo cmprobante este cargado
                    //este campo se genera en el paso de estado a caja
                    {
                        lblFactura.Text = drFactura.NRO_COMPROBANTE.ToString();
                        lblFecha.Text = drFactura.FECHA.ToString("dd/MM/yyyy");
                        lblHora.Text = drFactura.FECHA.ToString("HH:mm");
                        DataTable dttalonario = AutonumeracionesService.GetAutonumeracionPorId(decimal.Parse(drFactura.AUTONUMERACION_ID.ToString()));
                        lblTimbrado.Text = dttalonario.Rows[0][AutonumeracionesService.NumeroTimbrado_NombreCol].ToString();
                    }
                    else
                    {
                        DataTable dttalonario = AutonumeracionesService.GetAutonumeracionPorId(this.vAutonumeracionID);
                        if (dttalonario.Rows.Count == 0)
                        {
                            lblFactura.Text = string.Empty;
                            lblFecha.Text = string.Empty;
                            lblTimbrado.Text = string.Empty;
                            lblHora.Text = string.Empty;
                            throw new Exception("No tiene un talonario asignado");
                        }
                        else
                        {
                            lblFactura.Text = dttalonario.Rows[0][AutonumeracionesService.Prefijo_NombreCol].ToString() + dttalonario.Rows[0][AutonumeracionesService.NumeroActual_NombreCol].ToString();
                            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy"); 
                            lblHora.Text = DateTime.Now.ToString("HH:mm"); 
                            lblTimbrado.Text = dttalonario.Rows[0][AutonumeracionesService.NumeroTimbrado_NombreCol].ToString();
                        }
                    }
                    lblCaso.Text = this.vCasoId.ToString();
                    lblEstado.Text = this.vCasoEstado.ToString();

                }
            }
            catch (Exception ex)
            {
               
              //  Alert.Show(ex.Message, Form_Alert.enmType.Error);
                throw ex;
                
                
            }

        }
        #endregion LabeldeCabecera

        #region obtener Deposito
        private void obtenerDeposito()
        {
            //optener deposito
            DataTable dtDeposito = StockDepositosService.GetStockDepositosDataTable(this.vSucursalId, true, true);
            if (!(dtDeposito.Rows.Count > 0))
                throw new Exception("No existe un depósito");
            DataRow datos = dtDeposito.Rows[0];
            this.vDeposito = (decimal)datos[StockDepositosService.Id_NombreCol];
        }
        private string obtenerDepositoNombre()
        {
            //optener deposito
            DataTable dtDeposito = StockDepositosService.GetStockDepositosDataTable(this.vSucursalId, true, true);
            if (!(dtDeposito.Rows.Count > 0))
                throw new Exception("No existe un depósito");
            DataRow datos = dtDeposito.Rows[0];
            return datos[StockDepositosService.Nombre_NombreCol].ToString();
        }
        #endregion obtener Deposito

        #region ObtenerAutonumeracion
        private void obtenerAutonumeracion()
        {
            if (this.vCajaIniciada)
            {
                try
                {
                    AutonumeracionesService autonumServices = new AutonumeracionesService();
                    this.vAutonumeracionID = autonumServices.GetAutonumeracionesPorIP(SessionService.GethostName());
                }
                catch (Exception ex)
                {
                    Alert.Show(ex.Message, Form_Alert.enmType.Error);
                }
            }
                     
        }
        #endregion ObtenerAutonumeracion

        #endregion Load

        #region estado Cuenta Cliente
        private void obtenerCuetaCliente(decimal personaID)
        {
            if (personaID == Definiciones.Error.Valor.EnteroPositivo)
            {
                lblLineaCredito.Text = "0 GS";
                lblSaldo.Text = "0 GS";
                lblDeuda.Text = "0 GS";
                return;
            }
            string CuentaCliente = string.Empty;

            //Linea de Crédito
            DataRow row = (new PersonasLineaCreditoService()).GetPersonasLineaCredito(personaID);
            decimal monto = (decimal)row[PersonasLineaCreditoService.MontoLineaCredito_NombreCol];
            string temporal = (string)row[PersonasLineaCreditoService.Temporal_NombreCol];
            
            lblLineaCredito.Text = String.Format("{0:N0}", monto) + " GS";
            //deuda
            decimal deuda = (new CuentaCorrientePersonasService()).GetSaldoPersonaEnMoneda(personaID, Definiciones.Monedas.Guaranies);
            if (deuda < 0) deuda *= -1;
            lblDeuda.Text = String.Format("{0:N0}", deuda) + " GS \n";
           
            //Saldo de Linea de Crédito
            decimal saldo = monto - deuda;
            lblSaldo.Text =  String.Format("{0:N0}", saldo) + " GS \n";


            rdMayorista.Checked = PersonasService.GetEsMayorista(personaID);
            rdMinorista.Checked = !PersonasService.GetEsMayorista(personaID);

        }

        #endregion estado Cuenta Cliente

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

        #region RefrescarComponentes
        private void RefrescarComponentes()
        {
            rdContado.Checked = true;
            CargarSucursalDepositoDelaSession();
            txtArticulo.Focus();
        }
        #region RefrescarComboBoxCliente
        private void RefrescarComboBoxCliente(ref ComboBox cboPersonas, string texto, bool esId)
        {
            string clausulas = PersonasService.EsCliente_NombreCol + " = '" + Definiciones.SiNo.Si + "' " +
                                " and " + PersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            DataTable dt;
            if (esId)
                dt = PersonasService.GetPersonasInfoCompletaPorID(texto);
            else
                dt = PersonasService.GetPersonasInfoCompletaFiltrado(texto != string.Empty ? texto : txtBusCliente.Text, clausulas, true);

            dt.Columns.Add("CiNombre", typeof(string));

            // Recorre cada fila del DataTable y concatena el nombre y el apellido
            foreach (DataRow row in dt.Rows)
            {
                string nombre = row[PersonasService.NombreCompleto_NombreCol].ToString();
                string ci = row[PersonasService.NumeroDocumento_NombreCol].ToString();
                string nombreCompleto = ci + " " + nombre;
                row["CiNombre"] = nombreCompleto;
            }
            cboPersonas.DataSource = dt;
            cboPersonas.ValueMember = PersonasService.Id_NombreCol;
            cboPersonas.DisplayMember = "CiNombre";//PersonasService.NumeroDocumento_NombreCol + " - " + PersonasService.NombreCompleto_NombreCol;
            txtBusCliente.Text = string.Empty;
        }
        #endregion RefrescarComboBoxCliente
        #endregion RefrescarComponentes

        #region Cargar Datos del Caso
        private void cargarDatosDelCaso()
        {
            try
            {

                //Se obtiene el DataRow con la informacion del flujo
                DataTable tabla = FacturasClienteService.GetFacturaClienteInfoCompleta(FacturasClienteService.CasoId_NombreCol + " = " + this.vCasoId, string.Empty);
                if (!(tabla.Rows.Count > 0))
                    throw new Exception("No existe el caso de caja rapida");
                  
                DataRow datos = tabla.Rows[0];
                this.vCabeceraID = (decimal)datos[FacturasClienteService.Id_NombreCol];
                this.vNroFactura = datos[FacturasClienteService.NroComprobante_NombreCol].ToString();
                this.vCasoEstado = datos[FacturasClienteService.VistaCasoEstadoId_NombreCol].ToString();
                lblCaso.Text = this.vCasoId.ToString();
                lblEstado.Text = this.vCasoEstado.ToString();
                RefrescarComboBoxCliente(ref cboPersonas, datos[FacturasClienteService.PersonaId_NombreCol].ToString(), true);
                cboPersonas.SelectedValue = (decimal)datos[FacturasClienteService.PersonaId_NombreCol];
                obtenerCuetaCliente((decimal)datos[FacturasClienteService.PersonaId_NombreCol]);
                RefrescardataGridDetalles();
                
                resumenEnvases();
                cargarDataGripTotales();
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        #region ResumenEnvases
        private void resumenEnvases()
        {
            FacturasEnvasesService FacEnvaseServices = new FacturasEnvasesService();
            DataTable dtresumen = FacEnvaseServices.GetResumenEnvases(this.vCabeceraID);
            // Declaramos una variable lista que contendrá el resultado de la consulta
            var lista = dtresumen.AsEnumerable()// Convertimos el datatable en una secuencia de filas (DataRow)
                .GroupBy(x => new { envase = x[FacturasEnvasesService.VistaNombre_NombreCol] })// Agrupamos las filas por el valor de la columna "Envase" y creamos una clave anónima con esa propiedad
                .Select(g => new
                {// Proyectamos cada grupo en un nuevo objeto anónimo con las siguientes propiedades:
                    Envase = g.Key.envase,// El valor de la clave del grupo, es decir, el valor de la columna "Envase"
                    cantidad = g.Sum(x => Convert.ToDecimal(x[FacturasEnvasesService.VistaCantidad_NombreCol])),// La suma de los valores de la columna "Cantidad" convertidos a enteros para cada fila del grupo
                    peso = g.Sum(x => Convert.ToDecimal(x[FacturasEnvasesService.VistaPesoFactura_NombreCol]))// La suma de los valores de la columna "Peso" convertidos a decimales para cada fila del grupo
                }).ToList();// Convertimos la secuencia resultante en una lista
            // Limpiamos el contenido del textbox
            txtPesoTotal.Clear();
            txtResumenEnvases.Clear();
            //txtResumenEnvases.AppendText("Cant. - Envase - Peso" + Environment.NewLine);
            // Recorremos la lista
            foreach (var item in lista)
            {
                // Concatenamos los valores de cada objeto con el formato cantidad - envase - peso
                string linea = item.cantidad.ToString() + " - " + item.Envase.ToString() + " - " + item.peso.ToString();
                // Añadimos la línea al textbox con un salto de línea al final
                txtResumenEnvases.AppendText(linea + Environment.NewLine);
                // Declaramos una variable pesoTotal que contendrá el resultado de la suma
                var pesoTotal = lista.Sum(x => x.peso);

                txtPesoTotal.Text = pesoTotal.ToString();
            }
        }
        #endregion ResumenEnvases
        #endregion Cargar Datos del Caso

        #region dgvTotales
        //cargar datagridview totales
        private void cargarDataGripTotales()
        {
            DataTable dtDetalle = new DataTable();

            dtDetalle = FacturasClienteDetalleService.GetFacturaClienteDetalleInfoCompletaStatic(vCabeceraID);
            if (dtDetalle.Rows.Count == 0)
                return;

            FacturasEnvasesService FacturasEnvase = new FacturasEnvasesService();
            DataTable dtEnvase;
            string clausulas = FacturasEnvasesService.VistaFacturaNroCaso_NombreCol + " = " + vCasoId;
            dtEnvase = FacturasEnvase.GetFacturasEnvasesInfoCompleta(clausulas, string.Empty);
            decimal PesoEnvase = dtEnvase.AsEnumerable().Sum(row => row.Field<decimal>(FacturasEnvasesService.VistaPesoFactura_NombreCol));
            decimal CanNeta = decimal.Parse(dtDetalle.Compute("SUM(" + FacturasClienteDetalleService.CantidadUnidadOrigen_NombreCol + ")", string.Empty).ToString());
            decimal CanBruta = CanNeta + PesoEnvase;
            int sumNeto = Convert.ToInt32(dtDetalle.Compute("SUM(" + FacturasClienteService.TotalMontoBruto_NombreCol + ")", string.Empty));
            int sumtotal = Convert.ToInt32(dtDetalle.Compute("SUM(" + FacturasClienteService.TotalNeto_NombreCol + ")", string.Empty));
            int sumdto = Convert.ToInt32(dtDetalle.Compute("SUM(" + FacturasClienteService.TotalMontoDto_NombreCol + ")", string.Empty));
            double sumPorcentajedto = 0;
            // Crear un DataTable con algunas columnas y filas
            DataTable dtTotal = new DataTable();
            dtTotal.Columns.AddRange(new DataColumn[5] { new DataColumn("EnBlanco", typeof(string)),
                                        new DataColumn("TotalNeto", typeof(string)),
                                        new DataColumn("PorcDesc", typeof(string)),
                                        new DataColumn("TotalDto", typeof(string)),
                                        new DataColumn("TotalGeneral", typeof(string)) });
            dtTotal.Rows.Add("Totales:", String.Format("{0:N0}", sumtotal), "", String.Format("{0:N0}", sumdto), String.Format("{0:N0}", sumNeto));
            dgvTotales.DataSource = dtTotal;

            int indice = dgvTotales.Columns["EnBlanco"].Index;
            dgvTotales.Columns[indice].HeaderText = " ";
            dgvTotales.Columns[indice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTotales.Columns[indice].DefaultCellStyle.Font = new Font("Georgia", 12, FontStyle.Bold);
            dgvTotales.Columns[indice].Width = 740;
            dgvTotales.Columns[indice].Visible = true;

            indice = dgvTotales.Columns["TotalNeto"].Index;
            dgvTotales.Columns[indice].HeaderText = " ";
            dgvTotales.Columns[indice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTotales.Columns[indice].DefaultCellStyle.Font = new Font("Georgia", 12, FontStyle.Bold);
            dgvTotales.Columns[indice].Width = 120;
            dgvTotales.Columns[indice].Visible = true;

            indice = dgvTotales.Columns["PorcDesc"].Index;
            dgvTotales.Columns[indice].HeaderText = " ";
            dgvTotales.Columns[indice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTotales.Columns[indice].DefaultCellStyle.Font = new Font("Georgia", 12, FontStyle.Bold);
            dgvTotales.Columns[indice].Width = 50;
            dgvTotales.Columns[indice].Visible = true;

            indice = dgvTotales.Columns["TotalDto"].Index;
            dgvTotales.Columns[indice].HeaderText = " ";
            dgvTotales.Columns[indice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTotales.Columns[indice].DefaultCellStyle.Font = new Font("Georgia", 12, FontStyle.Bold);
            dgvTotales.Columns[indice].Width = 120;
            dgvTotales.Columns[indice].Visible = true;

            indice = dgvTotales.Columns["TotalGeneral"].Index;
            dgvTotales.Columns[indice].HeaderText = " ";
            dgvTotales.Columns[indice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTotales.Columns[indice].DefaultCellStyle.Font = new Font("Georgia", 12, FontStyle.Bold);
            dgvTotales.Columns[indice].Width = 130;
            dgvTotales.Columns[indice].Visible = true;
        }
        #endregion dgvTotales

        #region Nueva Venta
        private void NuevaVenta()
        {
            try
            {
                //vaciar componentes despues de la venta
                txtArticulo.Text = string.Empty;
                txtBusCliente.Text = string.Empty;
                cboPersonas.SelectedValue = Definiciones.Error.Valor.EnteroPositivo;
                dgvDetalles.DataSource = null;
                dgvTotales.DataSource = null;
                this.vCabeceraID = Definiciones.Error.Valor.EnteroPositivo;
                this.vCasoId = Definiciones.Error.Valor.EnteroPositivo;


                Cargar();
                obtenerCuetaCliente((Definiciones.Error.Valor.EnteroPositivo));
                habilitarControles();
                rdMinorista.Checked = true;
                txtBusCliente.Focus();
                
            }
            catch (Exception)
            {

                throw;
            }
           

        }
        #endregion Nueva Venta

        #region RefrescardataGridDetalles
        private void RefrescardataGridDetalles()
        {
            try
            {

                DataTable dtDetalle = new DataTable();

                dtDetalle = FacturasClienteDetalleService.GetFacturaClienteDetalleInfoCompletaStatic(vCabeceraID);
                dgvDetalles.DataSource = null;
                dgvDetalles.Rows.Clear(); // para limpiar las filas
                dgvDetalles.Columns.Clear(); // para limpiar las columnas
                                             //si el datatable esta vacio se salta todo el proceso
                if (dtDetalle.Rows.Count == 0)
                {
                    if ((VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCClienteFiltrarArticuloCliente) == Definiciones.SiNo.Si) && (vCasoEstado == Definiciones.EstadosFlujos.Borrador))
                        PermitirCambioCboPersonas();
                    dgvDetalles.DataSource = null;
                    return;
                }

                if ((VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCClienteFiltrarArticuloCliente) == Definiciones.SiNo.Si) && (vCasoEstado == Definiciones.EstadosFlujos.Borrador))
                    EvitarCambioCboPersonas();
                //clonamos el datatable detalles 
                //de esta forma formateamos las columas totales y demas
                // con separador de miles

                // Clonar el datatable original
                DataTable dtFormateado = dtDetalle.Clone();
                // Agregar columna de botones
                DataColumn columEliminar = new DataColumn("eliminar", typeof(string));
                dtFormateado.Columns.Add(columEliminar);
                DataColumn columEnvases = new DataColumn("envases", typeof(string));
                dtFormateado.Columns.Add(columEnvases);
                // Cambiar el tipo de la columna a string
                dtFormateado.Columns[FacturasClienteDetalleService.TotalMontoBruto_NombreCol].DataType = typeof(string);
                dtFormateado.Columns[FacturasClienteDetalleService.PorcentajeDescuento_NombreCol].DataType = typeof(string);
                dtFormateado.Columns[FacturasClienteDetalleService.TotalNeto_NombreCol].DataType = typeof(string);
                dtFormateado.Columns[FacturasClienteDetalleService.CantidadUnidadOrigen_NombreCol].DataType = typeof(string);
                dtFormateado.Columns[FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol].DataType = typeof(string);
                dtFormateado.Columns[FacturasClienteDetalleService.PrecioListaDestino_NombreCol].DataType = typeof(string);
                foreach (DataColumn columnas in dtFormateado.Columns)
                {
                    columnas.AllowDBNull = true;
                }
                //vairables para consultar envases
                //dejamos fuera del bucle 
                string clausulas = string.Empty;
                DataTable BuscarEnvases = new DataTable();
                FacturasEnvasesService FacturasEnvase = new FacturasEnvasesService();

                foreach (DataRow row in dtDetalle.Rows)
                {
                    string envases = string.Empty;
                    // Crear una nueva fila con el mismo esquema que el clonado
                    DataRow newRow = dtFormateado.NewRow();
                    clausulas = FacturasEnvasesService.VistaDetallefacturaId_NombreCol + " = " + row[FacturasClienteDetalleService.Id_NombreCol].ToString();
                    BuscarEnvases = FacturasEnvase.GetFacturasEnvasesInfoCompleta(clausulas, string.Empty);
                    decimal pp = 0;
                    decimal cant = 0;
                    decimal peso = 0;
                    foreach (DataRow item in BuscarEnvases.Rows)
                    {
                        envases += item[FacturasEnvasesService.VistaNombre_NombreCol].ToString() + " = " + item[FacturasEnvasesService.Cantidad_NombreCol].ToString() + " X " + item[FacturasEnvasesService.VistaPesoFactura_NombreCol].ToString() + " ";
                        cant += decimal.Parse(item[FacturasEnvasesService.Cantidad_NombreCol].ToString());
                        peso += decimal.Parse(item[FacturasEnvasesService.Cantidad_NombreCol].ToString()) * decimal.Parse(item[FacturasEnvasesService.VistaPesoFactura_NombreCol].ToString());
                    }
                    if (envases == string.Empty)
                        newRow[FacturasClienteDetalleService.ArticuloDescripcion_NombreCol] = row[FacturasClienteDetalleService.ArticuloDescripcion_NombreCol];
                    else
                    {
                        pp = decimal.Parse(row[FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol].ToString()) / cant;
                        envases += " PP = " + pp.ToString();
                        newRow[FacturasClienteDetalleService.ArticuloDescripcion_NombreCol] = row[FacturasClienteDetalleService.ArticuloDescripcion_NombreCol] + " \n " + envases;
                    }
                    newRow[FacturasClienteDetalleService.Id_NombreCol] = row[FacturasClienteDetalleService.Id_NombreCol];
                    newRow[FacturasClienteDetalleService.MontoDescuento_NombreCol] = row[FacturasClienteDetalleService.MontoDescuento_NombreCol];
                    newRow[FacturasClienteDetalleService.LoteId_NombreCol] = row[FacturasClienteDetalleService.LoteId_NombreCol];

                    // Obtener el valor de la columna  como decimal
                    decimal TotalBruto = row.Field<decimal>(FacturasClienteDetalleService.TotalMontoBruto_NombreCol);
                    string unidad = row.Field<string>(FacturasClienteDetalleService.UnidadDestinoId_NombreCol);
                    string moneda = MonedasService.GetSimbolo(row.Field<decimal>(FacturasClienteDetalleService.MonedaOrigenId_NombreCol));
                    decimal porcentajeDto = row.Field<decimal>(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol);
                    decimal Total = row.Field<decimal>(FacturasClienteDetalleService.TotalNeto_NombreCol);
                    decimal cantidadNeta = row.Field<decimal>(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol);
                    decimal cantidadBruta = row.Field<decimal>(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol) + peso;
                    decimal Precio = row.Field<decimal>(FacturasClienteDetalleService.PrecioListaDestino_NombreCol);


                    // Formatear el valor con 0 decimales y separador de miles
                    string TotalBrutoFormateado = String.Format("{0:N0}", TotalBruto) + " " + moneda;
                    string porcenFormateado = porcentajeDto + " %";
                    int cantDecimales = UnidadesService.GetCantidadDecimales(unidad);

                    string TotalFormateada = String.Format("{0:N0}", Total) + " " + moneda;
                    string cantidadNetaFormateada = string.Format("{0:N" + cantDecimales + "}", cantidadNeta) + " ";
                    string cantidadBrutaFormateada = string.Format("{0:N" + cantDecimales + "}", cantidadBruta) + " " + unidad;
                    string precioFormateada = String.Format("{0:N0}", Precio) + " " + moneda;

                    // Asignar el valor formateado a la columna fortuna
                    newRow[FacturasClienteDetalleService.PorcentajeDescuento_NombreCol] = porcenFormateado;
                    newRow[FacturasClienteDetalleService.TotalMontoBruto_NombreCol] = TotalBrutoFormateado;
                    newRow[FacturasClienteDetalleService.TotalNeto_NombreCol] = TotalFormateada;
                    newRow[FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol] = cantidadNetaFormateada;// +" " + row[FacturasClienteDetalleService.UnidadDestinoId_NombreCol];
                    newRow[FacturasClienteDetalleService.CantidadUnidadOrigen_NombreCol] = cantidadBrutaFormateada;// +" " + row[FacturasClienteDetalleService.UnidadDestinoId_NombreCol];

                    newRow[FacturasClienteDetalleService.PrecioListaDestino_NombreCol] = precioFormateada;
                    
                    // Añadir la nueva fila al datatable clonado
                    dtFormateado.Rows.Add(newRow);
                }
                
                
                dgvDetalles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                
                dgvDetalles.DataSource = dtFormateado;


                // Obtener el número de columnas del datagridview
                int columnCount = dgvDetalles.ColumnCount;

                // Recorrer todas las columnas
                for (int i = 0; i < columnCount; i++)
                {
                    // Asignar la propiedad Visible a false
                    dgvDetalles.Columns[i].Visible = false;
                }
                #region Formato Columnas

                int displayIndex = 0;
                // Botón Eliminar
                int indice = dgvDetalles.Columns["eliminar"].Index;
                dgvDetalles.Columns.RemoveAt(indice);
                DataGridViewImageColumn btnEliminarColumn = new DataGridViewImageColumn();
                  btnEliminarColumn.Name = "eliminar";
                  btnEliminarColumn.HeaderText = string.Empty;
                  btnEliminarColumn.Width = 25;
                  btnEliminarColumn.DefaultCellStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                  btnEliminarColumn.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightCoral;
                  btnEliminarColumn.Image = Properties.Resources.borrar;
                btnEliminarColumn.DisplayIndex = displayIndex++;
                dgvDetalles.Columns.Insert(indice, btnEliminarColumn);


                // Botón Envases
                indice = dgvDetalles.Columns["envases"].Index;
                dgvDetalles.Columns.RemoveAt(indice);
                DataGridViewImageColumn btnEnvasesColumn = new DataGridViewImageColumn();
                btnEnvasesColumn.Name = "envases";
                btnEnvasesColumn.HeaderText = string.Empty;
                btnEnvasesColumn.Width = 25;
                btnEnvasesColumn.Visible = this.vPuedeCargarEnvases;
                btnEnvasesColumn.Image = Properties.Resources.caja;
                btnEnvasesColumn.ToolTipText = "Agregar envases";
                btnEnvasesColumn.DefaultCellStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                btnEnvasesColumn.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkCyan;
                btnEnvasesColumn.DisplayIndex = displayIndex++;
                dgvDetalles.Columns.Insert(indice, btnEnvasesColumn);

                indice = dgvDetalles.Columns[FacturasClienteDetalleService.Id_NombreCol].Index;
                dgvDetalles.Columns[indice].Visible = false;
                dgvDetalles.Columns[indice].DisplayIndex = displayIndex++;

                // Crear una nueva columna de texto
                DataGridViewTextBoxColumn txtDetalle = new DataGridViewTextBoxColumn();
                // Establecer el nombre y el encabezado de la columna
                txtDetalle.Name = "txtDetalle";
                txtDetalle.HeaderText = "Articulo";


                // Agregar la columna al datagridview
                dgvDetalles.Columns.Add(txtDetalle);
                // Establecer el modo de ajuste de texto a verdadero para la columna
                dgvDetalles.Columns["txtDetalle"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetalles.Columns["txtDetalle"].Width = 350;
                // Establecer el modo de cambio de tamaño de filas a automático para el datagridview
                dgvDetalles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                // Establecer el nombre de la propiedad o columna de datos para la columna de texto
                dgvDetalles.Columns["txtDetalle"].DataPropertyName = FacturasClienteDetalleService.ArticuloDescripcion_NombreCol;
                txtDetalle.DisplayIndex = displayIndex++;

                indice = dgvDetalles.Columns[FacturasClienteDetalleService.CantidadUnidadOrigen_NombreCol].Index;
                dgvDetalles.Columns[indice].HeaderText = "Cant. Bruta";
                dgvDetalles.Columns[indice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalles.Columns[indice].DefaultCellStyle.Font = new Font("Georgia", 12);
                dgvDetalles.Columns[indice].Width = 110;
                dgvDetalles.Columns[indice].Visible = true;
                dgvDetalles.Columns[indice].DisplayIndex = displayIndex++;

                indice = dgvDetalles.Columns[FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol].Index;
                dgvDetalles.Columns[indice].HeaderText = "Cant. Neta";
                dgvDetalles.Columns[indice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalles.Columns[indice].DefaultCellStyle.Font = new Font("Georgia", 12);
                dgvDetalles.Columns[indice].Width = 110;
                dgvDetalles.Columns[indice].Visible = true;
                dgvDetalles.Columns[indice].DisplayIndex = displayIndex++;

                indice = dgvDetalles.Columns[FacturasClienteDetalleService.PrecioListaDestino_NombreCol].Index;
                dgvDetalles.Columns[indice].Width = 120;
                dgvDetalles.Columns[indice].HeaderText = "Precio.";
                dgvDetalles.Columns[indice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalles.Columns[indice].DefaultCellStyle.Font = new Font("Georgia", 12);
                dgvDetalles.Columns[indice].Visible = true;
                dgvDetalles.Columns[indice].DisplayIndex = displayIndex++;

                indice = dgvDetalles.Columns[FacturasClienteDetalleService.TotalMontoBruto_NombreCol].Index;
                dgvDetalles.Columns[indice].Width = 120;
                dgvDetalles.Columns[indice].HeaderText = "Sub Total";
                dgvDetalles.Columns[indice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalles.Columns[indice].DefaultCellStyle.Font = new Font("Georgia", 12);
                dgvDetalles.Columns[indice].Visible = true;
                dgvDetalles.Columns[indice].DisplayIndex = displayIndex++;

                indice = dgvDetalles.Columns[FacturasClienteDetalleService.PorcentajeDescuento_NombreCol].Index;
                dgvDetalles.Columns[indice].Width = 50;
                dgvDetalles.Columns[indice].HeaderText = "% Dto.";
                dgvDetalles.Columns[indice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalles.Columns[indice].DefaultCellStyle.Font = new Font("Georgia", 12);
                dgvDetalles.Columns[indice].Visible = true;
                dgvDetalles.Columns[indice].DisplayIndex = displayIndex++;

                indice = dgvDetalles.Columns[FacturasClienteDetalleService.MontoDescuento_NombreCol].Index;
                dgvDetalles.Columns[indice].Width = 120;
                dgvDetalles.Columns[indice].HeaderText = "Descuento";
                dgvDetalles.Columns[indice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalles.Columns[indice].DefaultCellStyle.Font = new Font("Georgia", 12);
                dgvDetalles.Columns[indice].Visible = true;
                dgvDetalles.Columns[indice].DisplayIndex = displayIndex++;

                indice = dgvDetalles.Columns[FacturasClienteDetalleService.TotalNeto_NombreCol].Index;
                dgvDetalles.Columns[indice].Width = 130;
                dgvDetalles.Columns[indice].HeaderText = "Total";
                dgvDetalles.Columns[indice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalles.Columns[indice].DefaultCellStyle.Font = new Font("Georgia", 12);
                dgvDetalles.Columns[indice].Visible = true;
                dgvDetalles.Columns[indice].DisplayIndex = displayIndex++;

                dgvDetalles.EditMode = DataGridViewEditMode.EditOnEnter;
                #endregion  Formato Columnas
                dgvDetalles.CellClick += dataGridDetalles_CellClick;
                //dataGridDetalles.RowTemplate.Height = 200;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion RefrescardataGridDetalles

        #region habilitar desabilitar controles
        #region Habilitar
        private void habilitarControles()
        {

            flArticulos.Enabled = true;

            PermitirCambioCboPersonas();
            dgvDetalles.CellClick += dataGridDetalles_CellClick;
            flacciones.Enabled = true;
            FlVentaCerrada.Visible = false;


        }
        #endregion Habilitar
        #region Desabilitar
        private void desabilitarControles()
        {
            flArticulos.Enabled = false;
            dgvDetalles.CellClick -= dataGridDetalles_CellClick;
            flacciones.Enabled = false;
            FlVentaCerrada.Visible = true;
            EvitarCambioCboPersonas();
           
           
        }
        #endregion desabilitar
        #endregion habilitar desabilitar controles

        #region Event Handlers
        #region txt buscar Caso
        private void txtBuscarCaso_Enter(object sender, EventArgs e)
        {
            if (txtBuscarCaso.Text == "Buscar Caso")
            {
                txtBuscarCaso.Text = string.Empty;
                txtBuscarCaso.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtBuscarCaso_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscarCaso.Text))
            {
                txtBuscarCaso.Text = "Buscar Caso";
                txtBuscarCaso.ForeColor = System.Drawing.Color.Gray;
            }
        }
        private void txtBuscarCaso_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (por ejemplo, retroceso)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    this.vCasoId = decimal.Parse(txtBuscarCaso.Text);
                    Cargar();
                    txtBuscarCaso.Text = string.Empty;
                    txtBuscarCaso_Leave(null,null);
                }
                catch (Exception ex)
                {
                    Alert.Show(ex.Message, Form_Alert.enmType.Error);
                }
               
            }
            
        }
        #endregion txt buscar Caso


        #region Buscar Cliente

        private void cboPersonas_TextChanged(object sender, EventArgs e)
        {
           
        }
        // Cuando quieras evitar el cambio de selección, establece permitirCambio a false
        private void EvitarCambioCboPersonas()
        {
            if (ValidarSeleccionado(cboPersonas))
                previoIndice = cboPersonas.SelectedIndex;
            txtBusCliente.ReadOnly = true;
            permitirCambio = false;
        }

        // Cuando quieras permitir el cambio de selección, establece permitirCambio a true
        private void PermitirCambioCboPersonas()
        {
            txtBusCliente.ReadOnly = false;
            permitirCambio = true;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            PopUpAggCliente();
        }
        private void txtBusCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (dgvDetalles.RowCount > 0)
                    Alert.Show("No puede cambiar el cliente, \n ya tiene detalles cargados", Form_Alert.enmType.Info);

                else
                {
                    if (txtBusCliente.TextLength >= 3)
                    {
                        RefrescarComboBoxCliente(ref cboPersonas, string.Empty, false);
                        txtArticulo.Focus();
                    }
                    else
                        Alert.Show("Ingrese tres caracteres para  buscar el cliente", Form_Alert.enmType.Error);

                }
            }
        }
        #endregion Buscar Cliente

        // Método para manejar el evento CellClick
        private void dataGridDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Obtener el id del registro usando el índice de fila
                decimal detalleId = (decimal)dgvDetalles.Rows[e.RowIndex].Cells[FacturasClienteDetalleService.Id_NombreCol].Value;

                if (e.ColumnIndex == dgvDetalles.Columns["envases"].Index && e.RowIndex >= 0)
                {
                    contShow++;
                   if (contShow ==2)
                    {
                        FacturacionEnvasesForm form = new FacturacionEnvasesForm(detalleId);//enviamos el id del detalle como parametro al formulario
                                                                                            // form.FormClosed += FormEnvacesClose;
                        form.ShowDialog();
                        contShow = 0;
                        cargarDatosDelCaso();
                    }


                }
                if (e.ColumnIndex == dgvDetalles.Columns["eliminar"].Index && e.RowIndex >= 0)
                {
                    FacturasClienteDetalleService.Borrar(detalleId, this.vCasoId);
                    cargarDatosDelCaso();
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }
        private void FormEnvacesClose(object sender, EventArgs e)
        {
            
            cargarDatosDelCaso();
          
        }
        #region EditCliente
        public void PopUpEditCliente(decimal ClienteID)
        {
            ClienteBasicoForm EditCliente = new ClienteBasicoForm(ClienteID);
            EditCliente.Closed += new EventHandler(SeleccionarNuevoCliente);
            EditCliente.ShowDialog();
        }
        #endregion EditCliente
        #region AggCliente
        public void PopUpAggCliente()
        {
            ClienteBasicoForm AggCliente = new ClienteBasicoForm();
            AggCliente.Closed += new EventHandler(SelecccionarNuevoCliente);
            AggCliente.ShowDialog();
        }
        #endregion AggCliente
        #region SeleccionarNuevoCliente
        protected void SeleccionarNuevoCliente(object sender, EventArgs e)
        {
            try
            {
                if (!this.Enabled)
                    return;

                ClienteBasicoForm objForm = sender as ClienteBasicoForm;
                cboPersonas.SelectedItem = null;
                decimal idSeleccionado = objForm.GetIdSeleccionado();
                RefrescarComboBoxCliente(ref cboPersonas, idSeleccionado.ToString(), true);
                if (idSeleccionado != Definiciones.Error.Valor.EnteroPositivo)
                {
                    using (SessionService sesion = new SessionService())
                    {
                        cboPersonas.SelectedValue = idSeleccionado;
                    }
                }
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        #endregion SeleccionarNuevoCliente
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblReloj.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion Event Handlers


        private void CajaForm_Shown(object sender, EventArgs e)
        {
            using (Services.Sesion.SessionService sesion = new CBA.FlowV2.Services.Sesion.SessionService())
            { Alert.Show("Biembenido " + sesion.Usuario_Nombre, Form_Alert.enmType.Success); }
                
        }
        
        private void txtArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (!ValidarSeleccionado(cboPersonas))
                    {
                        DialogResult resultado = MessageBox.Show("¿No agrego cliente, agregar al cliente sin nombre?", "Agregar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.Yes)// agregar el cliente por defecto
                        {
                            RefrescarComboBoxCliente(ref cboPersonas, vClienteDefecto.ToString(), true);
                            cboPersonas.SelectedValue = vClienteDefecto;
                            AgregarDetalle();
                        }
                        else //agregar otro cliente
                        {
                            txtBusCliente.Focus();
                        }
                    }
                    else
                    {
                        AgregarDetalle();
                    }

                    txtArticulo.Text = string.Empty;
                    
                    Alert.Show("Correcto", Form_Alert.enmType.Success);
                    txtArticulo.Focus();
                }
                catch (Exception ex)
                {
                    Alert.Show(ex.Message, Form_Alert.enmType.Error);
                }
            }
        }



        #region agregarDetalle
        public void AgregarDetalle()
        {
            try
            {
                //verificar si es una venta nueva
                if (this.vCasoId == Definiciones.Error.Valor.EnteroPositivo)
                {
                    InsertarCabecera(true);//de esta manera se crea un nuevo caso cuando agrega el primer producto
                    PermitirCambioCboPersonas();
                }

                FacturasClienteDetalleService facturaDetalle = new FacturasClienteDetalleService();
                string mensaje;

                using (SessionService sesion = new SessionService())
                {
                    //Este control estaba en el services al cambio de estado 
                    // para no llegar a ese error controlo antes aqui
                    if (!facturaDetalle.ControlesAgregarDetalle(vCasoId, sesion, out mensaje))
                    {
                        throw new Exception(mensaje);
                    }
                    if (!this.vProductoSeleccionado)
                    {
                        DataRow drArticulos = obtenerProductoUnico();//devuelve un unico producto por codido de barras
                                                                     //verificamos si el producto puede tener cantidades decimales
                        this.vArticuloId = (decimal)drArticulos[ArticulosService.Id_NombreCol];//asignamos el valor en una variable global
                                                                                               //esto fue por que el sistema realiza preguntas a los usuarios y para que las funciones en bases a sus respuestas tengan acceso 

                        int cantidadDecimales = UnidadesService.GetCantidadDecimales(drArticulos[ArticulosService.UnidadMedidaId_NombreCol].ToString());

                        if (cantidadDecimales == 0)//validamos que la unidad de medida admita 0 decimales
                            if (!VerificarEntero(this.vCantidad)) //si la cantidad de decimales de producto es 0 verificamos que el la cantidad sea entera
                                throw new Exception("La unidad de medida del articulo no admite decimales");
                    }

                    decimal porcentajeDescuento; decimal cotizacion_precio; decimal moneda_precio;

                    this.vPrecio = PreciosService_new.getPrecioArticuloDePersona(this.vArticuloId, (decimal)cboPersonas.SelectedValue,sesion.SucursalActiva_Id, Definiciones.Monedas.Guaranies, this.vCantidad, out porcentajeDescuento, out cotizacion_precio, out moneda_precio, ref this.vListaPrecioID, DateTime.Now);//utilizamos la funcion de alex para obtener el precio
                    obtenerDeposito();//Obtenemos el depósito

                    vloteID = ArticulosLotesService.GetPrimerLoteId(this.vArticuloId, this.vDeposito);
                    PopUp oPopUp = new PopUp();
                    //la funcion retornara -1 si no existe un stock 
                    if (vloteID == Definiciones.Error.Valor.EnteroPositivo)
                    {
                        //si no existe stok utilizamos el lote sin stock mas nuevo
                        vloteID = ArticulosLotesService.GetLoteIdCajaRapida(this.vArticuloId, this.vDeposito);
                        if (vPuedeAgregarSinStock)
                        {
                            DialogResult resultado = MessageBox.Show("El articulo no tiene stock, ¿agregar de todos modos?", "Sin stock", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resultado == DialogResult.Yes)
                            {
                                GuardarDetalleUnitario(this.vCantidad, null);

                                this.vCantidad = 1;
                            }
                            else //agregar otro cliente
                            {
                                this.vCantidad = 1;
                                return;
                            }
                        }
                        else
                            throw new Exception("El articulo no tiene stock");


                    }
                    else
                    {
                        GuardarDetalleUnitario(this.vCantidad, null);
                        this.vCantidad = 1;

                    }
                }

               
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AgregarDetalle(decimal articuloID, decimal cantidad)
        {
            try
            {
                //verificar si es una venta nueva
                if (this.vCasoId == Definiciones.Error.Valor.EnteroPositivo)
                {
                    InsertarCabecera(true);//de esta manera se crea un nuevo caso cuando agrega el primer producto
                }
                FacturasClienteDetalleService facturaDetalle = new FacturasClienteDetalleService();
                string mensaje;

                using (SessionService sesion = new SessionService())
                {
                    //Este control estaba en el services al cambio de estado 
                    // para no llegar a ese error controlo antes aqui
                    if (!facturaDetalle.ControlesAgregarDetalle(vCasoId, sesion, out mensaje))
                    {
                        throw new Exception(mensaje);
                    }
                    decimal porcentajeDescuento; decimal cotizacion_precio; decimal moneda_precio;

                    vPrecio = this.vPrecio = PreciosService_new.getPrecioArticuloDePersona(this.vArticuloId, (decimal)cboPersonas.SelectedValue, sesion.SucursalActiva_Id, Definiciones.Monedas.Guaranies, cantidad, out porcentajeDescuento, out cotizacion_precio, out moneda_precio, ref this.vListaPrecioID, DateTime.Now);//utilizamos la funcion de alex para obtener el precio

                    obtenerDeposito();//Obtenemos el depósito

                    vloteID = ArticulosLotesService.GetPrimerLoteId(articuloID, this.vDeposito);
                    //la funcion retornara -1 si no existe un stock 
                    if (vloteID == Definiciones.Error.Valor.EnteroPositivo)
                    {
                        //si no existe stok utilizamos el lote sin stock mas nuevo
                        vloteID = ArticulosLotesService.GetLoteIdCajaRapida(articuloID, this.vDeposito);
                        // SinStockConfirmacion(); //pregunta de confirmacion para agregar el producto sin stock
                    }
                }
                

                GuardarDetalleUnitario(cantidad, articuloID);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool VerificarEntero(decimal numero)
        {
            decimal num2 = Math.Round(numero, 0);
            return num2 == numero;
        }

        private void GuardarDetalleUnitario(decimal cantidad_unitaria, decimal? articuloID)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    ARTICULOSRow oArticulos = ArticulosService.GetArticuloRowPorID(articuloID ?? this.vArticuloId);
                    DateTime fechaPrimerVencimiento = DateTime.Now, fechaSegundoVencimiento = DateTime.MinValue;
                    bool usarFechaPrimerVencimiento = false, usarFechaSegundoVencimiento = false;

                    // Traemos los datos del cliente. Para validar si es diplomatico.
                    var persona = PersonasService.GetPersonasDataTable(PersonasService.Id_NombreCol + " = " + decimal.Parse(cboPersonas.SelectedValue.ToString()), string.Empty);

                    System.Collections.Hashtable campos = new System.Collections.Hashtable();
                    campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, this.vCabeceraID);
                    campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, articuloID ?? this.vArticuloId);
                    campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, vloteID);
                    campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, oArticulos.UNIDAD_MEDIDA_ID);
                    campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, Definiciones.ValorCero.CeroDecimal);
                    campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, cantidad_unitaria);
                    // Si es diplomatico. Guardamos como exenta
                    if (decimal.Parse(persona.Rows[0][PersonasService.TipoClienteId_NombreCol].ToString()) == Definiciones.TiposCliente.Diplomatico)
                        campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, Definiciones.Impuestos.Exenta);
                    else
                        campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, oArticulos.IMPUESTO_ID);
                    //campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, oArticulos.IMPUESTO_ID);
                    //
                    // Si es diplomatico. Guardamos el precio sin iva
                    if (decimal.Parse(persona.Rows[0][PersonasService.TipoClienteId_NombreCol].ToString()) == Definiciones.TiposCliente.Diplomatico)
                    {
                        decimal porcentajeImpuesto = ImpuestosService.GetPorcentajePorId(oArticulos.IMPUESTO_ID);
                        decimal precio_aux = this.vPrecio / (1 + (porcentajeImpuesto / 100));
                        campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, precio_aux);
                    }
                    else
                        campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, this.vPrecio);
                    //campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, this.vPrecio);
                    //
                    campos.Add(FacturasClienteDetalleService.ListaPreciosId_NombreCol, this.vListaPrecioID);
                    campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, Definiciones.ValorCero.CeroDecimal);
                    campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, Definiciones.ValorCero.CeroDecimal);
                    campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, string.Empty);
                    campos.Add(FacturasClienteDetalleService.DepositoId_NombreCol, this.vDeposito);

                    //Guardar los datos
                    decimal detalleID = FacturasClienteDetalleService.Guardar(this.vCabeceraID, campos, false, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true);
                    PromocionesParametrosService.ValidarProcion(this.vCabeceraID);
                    if (rdMayorista.Checked)
                    {
                        FacturacionEnvasesForm form = new FacturacionEnvasesForm(detalleID);//enviamos el id del detalle como parametro al formulario
                       
                        form.ShowDialog();
                        Cargar();
                    }
                }
            }
            catch (Exception ex)
            {
               throw;
              
            }
            finally
            {
                RefrescardataGridDetalles();
                cargarDatosDelCaso();
            }
        }
        #endregion agregarDetalle

        #region actualizarDetalle
        private void actualizarDetalle(decimal cantidad_unitaria, decimal? articuloID)
        {

            try
            {
                using (SessionService sesion = new SessionService())
                {
                    ARTICULOSRow oArticulos = ArticulosService.GetArticuloRowPorID(articuloID ?? this.vArticuloId);
                    DateTime fechaPrimerVencimiento = DateTime.Now, fechaSegundoVencimiento = DateTime.MinValue;
                    bool usarFechaPrimerVencimiento = false, usarFechaSegundoVencimiento = false;


                    System.Collections.Hashtable campos = new System.Collections.Hashtable();
                    campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, this.vCabeceraID);
                    campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, articuloID ?? this.vArticuloId);
                    campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, vloteID);
                    campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, oArticulos.UNIDAD_MEDIDA_ID);
                    campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, Definiciones.ValorCero.CeroDecimal);
                    campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, cantidad_unitaria);
                    campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, oArticulos.IMPUESTO_ID);
                    campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, this.vPrecio);
                    campos.Add(FacturasClienteDetalleService.ListaPreciosId_NombreCol, this.vListaPrecioID);
                    campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, Definiciones.ValorCero.CeroDecimal);
                    campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, Definiciones.ValorCero.CeroDecimal);
                    campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, string.Empty);
                    campos.Add(FacturasClienteDetalleService.DepositoId_NombreCol, this.vDeposito);

                    //Guardar los datos
                    FacturasClienteDetalleService.Guardar(this.vCabeceraID, campos, false, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true);

                }
            }

            catch (Exception ex)
            {

                if (ex.InnerException == null)
                    MessageBox.Show(ex.Message);
                else
                    MessageBox.Show(ex.InnerException.InnerException.Message);

            }
            finally
            {

                RefrescardataGridDetalles();
                cargarDatosDelCaso();
            }

        }

        #endregion actualizarDetalle


        #region insertar Cabecera
        private bool InsertarCabecera(bool insertarNuevo)
        {
            bool exito = false;
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    System.Collections.Hashtable campos = new System.Collections.Hashtable();
                    campos.Add(FacturasClienteService.SucursalId_NombreCol, sesion.SucursalActiva.ID);
                    obtenerDeposito();
                    DataTable dtcondicionPago = null;
                    if (rdContado.Checked)
                        dtcondicionPago = CondicionesPagoService.GetCondicionesDataTable(CondicionesPagoService.Nombre_NombreCol + " = 'CONTADO'", true);
                    else
                        dtcondicionPago = CondicionesPagoService.GetCondicionesDataTable(CondicionesPagoService.Nombre_NombreCol + " = 'CREDITO 30 DÍAS'", true);

                    campos.Add(FacturasClienteService.DepositoId_NombreCol, this.vDeposito);
                    campos.Add(FacturasClienteService.CondicionPagoId_NombreCol, dtcondicionPago.Rows[0][CondicionesPagoService.Id_NombreCol]);//contado
                    campos.Add(FacturasClienteService.CotizacionDestino_NombreCol, CotizacionesService.GetCotizacionMonedaCompra(Definiciones.Monedas.Guaranies));//cotizacion del guarani
                    campos.Add(FacturasClienteService.TotalEntregaInicial_NombreCol, Definiciones.ValorCero.CeroString);
                    campos.Add(FacturasClienteService.AConsignacion_NombreCol, Definiciones.SiNo.No);
                    campos.Add(FacturasClienteService.MonedaDestinoId_NombreCol, Definiciones.Monedas.Guaranies);//guaranies
                    campos.Add(FacturasClienteService.Fecha_NombreCol, DateTime.Now);
                    campos.Add(FacturasClienteService.AfectaStock_NombreCol, Definiciones.SiNo.Si);//si afecta al stock pero no se controla
                    campos.Add(FacturasClienteService.FechaVencimientoTimbradoFactProveedor_NombreCol, DateTime.Now);
                    campos.Add(FacturasClienteService.PorcentajeDescSobreTotal_NombreCol, Definiciones.ValorCero.CeroString);
                    campos.Add(FacturasClienteService.ControlarCantidadMinimaDescuentoMaximo_NombreCol, Definiciones.SiNo.No);

                    campos.Add(FacturasClienteService.AfectaCtacte_NombreCol, Definiciones.SiNo.Si);
                    campos.Add(FacturasClienteService.MoraDiasGracia_NombreCol, "5");//agrgar variable del sistema
                    campos.Add(FacturasClienteService.AutonumeracionId_NombreCol, this.vAutonumeracionID);//se optiene por la ip
                    campos.Add(FacturasClienteService.Observacion_NombreCol, string.Empty);
                    campos.Add(FacturasClienteService.AfectaLineaCredito_NombreCol, Definiciones.SiNo.No);
                    campos.Add(FacturasClienteService.NroDocumentoExterno_NombreCol, string.Empty);
                    campos.Add(FacturasClienteService.ComisionPorVenta_NombreCol, "VENTA");//VENTA
                    campos.Add(FacturasClienteService.FechaVencimiento_NombreCol, DateTime.Now);
                    campos.Add(FacturasClienteService.MoraPorcentaje_NombreCol, Definiciones.ValorCero.CeroString);
                    campos.Add(FacturasClienteService.ObservacionEntrega_NombreCol, string.Empty);
                    if (this.vCabeceraID != Definiciones.Error.Valor.EnteroPositivo)
                    {
                        campos.Add(FacturasClienteService.Id_NombreCol, this.vCabeceraID);
                    }

                    if (ValidarSeleccionado(cboPersonas))
                        campos.Add(FacturasClienteService.PersonaId_NombreCol, cboPersonas.SelectedValue);
                    else
                        //agrefgar el cliente mostrador por defecto
                        campos.Add(FacturasClienteService.PersonaId_NombreCol, this.vClienteDefecto);//crear un cliente por defecto y cambiarlo o usar variable de sistema
                    campos.Add(FacturasClienteService.GenerarTransferencia_NombreCol, Definiciones.SiNo.No);
                    campos.Add(FacturasClienteService.Direccion_NombreCol, string.Empty);
                    campos.Add(Definiciones.Flujo.CajaRapida.nombre, Definiciones.SiNo.Si);
                    exito = FacturasClienteService.Guardar(campos, insertarNuevo, ref this.vCasoId, ref vCasoEstado);
                }
                //Si el caso fue creado con exito en esta llamada, se actualiza el id de la factura
                if (exito && insertarNuevo && !vCasoId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    Cargar();
                }
                cargarDatosDelCaso();
            }

            catch (Exception ex)
            {
                exito = false;
                string error2 = string.Empty;
                if (ex.InnerException == null)
                    error2 = ex.Message;
                else
                    error2 = ex.InnerException.InnerException.Message;
                Alert.Show(error2, Form_Alert.enmType.Error);
            }
            return exito;
        }

        #endregion insertar Cabecera

        #region obtenerProducto
        private DataRow obtenerProductoUnico()
        {
            try
            {
                if (txtArticulo.Text == string.Empty)
                    throw new Exception("Ingrese el codigo de barras");
                using (SessionService sesion = new SessionService())
                {
                    DataTable dt = ArticulosService.GetArticuloUnicoCR(txtArticulo.Text, sesion.SucursalActiva_Id);
                    if (dt.Rows.Count > 0)
                        return dt.Rows[0];
                    else
                        throw new Exception("Articulo no encontrado");
                }
            }
            catch (Exception )
            {
                throw;
            }
            finally
            {
                
            }

        }
        #endregion obtenerProducto

        private void btnNevaVenta_Click(object sender, EventArgs e)
        {
            try
            {
                NuevaVenta();
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message, Form_Alert.enmType.Error);
            }
            
        }

        private void btnCantidad_Click(object sender, EventArgs e)
        {
            try
            {
                using (var formInput = new Form_Cantidad())
                {
                    // Mostrar el formulario y obtener el resultado
                    DialogResult resultado = formInput.ShowDialog();

                    // Verificar el resultado y el valor ingresado por el usuario
                    if (resultado == DialogResult.OK)

                        this.vCantidad = formInput.ObtenerCantidad();



                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message, Form_Alert.enmType.Error);
            }
        }
        private void PopUpCobrar()
        {
            if (dgvDetalles.Rows.Count == 0)
            {
                Alert.Show("No tiene nada que cobrar", Form_Alert.enmType.Warning);
              
                return;
            }
            try
            {
                FacturasClienteService FC = new FacturasClienteService();
                string mensaje;//variable de salida al prosesar cambio de estado
                using (SessionService sesion = new SessionService())
                {
                    ////
                    ///realizamos un cambio de estado hasta caja 
                    ///de este modo se genera una cuenta corriente persona para posteriormente cobrar
                    ///
                    bool exito; //variables para  verificar si la funcion es exitosa
                    CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService ToolbarFlujo = new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService();


                    //cambiar caso a pendiente
                    exito = FC.ProcesarCambioEstado(this.vCasoId, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                    if (exito)
                        exito = ToolbarFlujo.ProcesarCambioEstado(this.vCasoId, Definiciones.EstadosFlujos.Pendiente, "Transición automática ", sesion);
                    if (exito)
                        FC.EjecutarAccionesLuegoDeCambioEstado(this.vCasoId, Definiciones.EstadosFlujos.Pendiente, sesion);
                    //cambiar caso a caja
                    exito = FC.ProcesarCambioEstado(this.vCasoId, Definiciones.EstadosFlujos.Caja, true, out mensaje, sesion);
                    if (exito)
                        exito = ToolbarFlujo.ProcesarCambioEstado(this.vCasoId, Definiciones.EstadosFlujos.Caja, "Transición automática ", sesion);
                    if (exito)
                        FC.EjecutarAccionesLuegoDeCambioEstado(this.vCasoId, Definiciones.EstadosFlujos.Caja, sesion);
                    if (!mensaje.Equals(string.Empty))//si tenemos algun menssale los imprimimos
                    {
                        MessageBox.Show(mensaje);
                    }
                    else
                    {
                        
                        //el detalle de pago que ejecuta el flujo pagos de persona de manera mas minimalista
                        Form_Pagos detallePago_Form = new Form_Pagos((decimal)cboPersonas.SelectedValue, vCasoId);
                        detallePago_Form.FormClosed +=  (sender, e) => {
                            // Este código se ejecutará cuando se cierre el formulario form_Pagos
                            detallePago_FormClose_Click(sender, e);
                        };
                       
                        detallePago_Form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCobrar_Click(object sender, EventArgs e)
        {
           PopUpCobrar();
        }
        private void detallePago_FormClose_Click(object sender, EventArgs e)
        {
            try
            {
                //optenemos el formulario
                Form_Pagos objForm = sender as Form_Pagos;
                if (objForm.GetVentaCancelada())
                {
                    FacturasClienteService FC = new FacturasClienteService();

                    string mensaje = string.Empty; //variable para almacenar el mensaje parametro de salida ap prosesar cambio de estado
                    using (SessionService sesion = new SessionService())
                    {
                        //llevamos el caso hasta el estado de cerrado
                        bool exito;
                        CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService ToolbarFlujo = new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService();
                        exito = FC.ProcesarCambioEstado(this.vCasoId, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                        if (exito)
                            exito = ToolbarFlujo.ProcesarCambioEstado(this.vCasoId, Definiciones.EstadosFlujos.Pendiente, "Transición automática ", sesion);
                        if (exito)
                            FC.EjecutarAccionesLuegoDeCambioEstado(this.vCasoId, Definiciones.EstadosFlujos.Pendiente, sesion);
                    }
                    Alert.Show("Cancelo el pago", Form_Alert.enmType.Success);
                    return;
                   
                }
                else
                {
                    decimal ultimoVuelto = objForm.GetUltimoVuelto(); //funcion que me da el vuelto
                    if (ultimoVuelto != Definiciones.Error.Valor.EnteroPositivo)
                    {
                        //mostrar el vuelto separado en miles
                        txtVuelto.Text = ultimoVuelto.ToString();
                        separarMiles(txtVuelto);
                    }
                    FacturasClienteService FC = new FacturasClienteService();

                    string mensaje = string.Empty; //variable para almacenar el mensaje parametro de salida ap prosesar cambio de estado
                    using (SessionService sesion = new SessionService())
                    {
                        //llevamos el caso hasta el estado de cerrado
                        bool exito;
                        CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService ToolbarFlujo = new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService();
                        exito = FC.ProcesarCambioEstado(this.vCasoId, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                        if (exito)
                            exito = ToolbarFlujo.ProcesarCambioEstado(this.vCasoId, Definiciones.EstadosFlujos.Cerrado, "Transición automática ", sesion);
                        if (exito)
                            FC.EjecutarAccionesLuegoDeCambioEstado(this.vCasoId, Definiciones.EstadosFlujos.Cerrado, sesion);
                    }

                    NuevaVenta();//no crea una nueva venta
                                 //refresca las variables y componentes para crear una nueva venta 
                    imprimir();
                    Alert.Show("Imprimiendo recibo", Form_Alert.enmType.Success);

                }



            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message, Form_Alert.enmType.Info);
                
            }
        }
        #region separador Miles
        private void separarMiles(TextBox TextBox1)
        {
            if (TextBox1.Text != string.Empty)
            {
                decimal importe;
                decimal.TryParse(TextBox1.Text, out importe);
                TextBox1.Text = String.Format("{0:N0}", importe);
                TextBox1.SelectionStart = TextBox1.TextLength;
            }

        }
        private void separarMiles(Label label)
        {
            if (!string.IsNullOrEmpty(label.Text))
            {
                decimal importe;
                if (decimal.TryParse(label.Text, out importe))
                {
                    label.Text = string.Format("{0:N0}", importe);
                }
            }
        }
        #endregion separador Miles

        private void dgvDetalles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDetalles.Rows.Count != 0)
            {
                if (e.ColumnIndex == dgvDetalles.Columns["eliminar"].Index)
                {
                    var cell = dgvDetalles.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = "Eliminar registro"; //dgvDetalles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                if (e.ColumnIndex == dgvDetalles.Columns["envases"].Index)
                {
                    var cell = dgvDetalles.Rows[e.RowIndex].Cells[e.ColumnIndex];
                  
                    cell.ToolTipText = "Asignar envases"; //dgvDetalles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
            }
          
        }
        #region imprimir
        private void imprimir()
        {
            try
            {

                TicketClass ticket = new TicketClass();
                ticket.logotipo = Logo.Image;
                ticket.vCasoId = this.vCasoId;
                ticket.vPagoId = Definiciones.Error.Valor.EnteroPositivo;
                ticket.imprimir(ticket);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        #endregion imprimir
        private void btnConsultarPrecio_Click(object sender, EventArgs e)
        {
            PopUpConsultarPrecio();
        }

        public void PopUpConsultarPrecio()
        {
            ConsultaPrecioForm consultarPrecios = new ConsultaPrecioForm();
           
            consultarPrecios.ShowDialog();
        }

        private void cboPersonas_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            PopUpBuscarArticulo();
        }
        public void PopUpBuscarArticulo()
        {
            BusquedaEntidadesForm buscardorArt = new BusquedaEntidadesForm(true, Definiciones.Error.Valor.EnteroPositivo, BusquedaEntidadesForm.EntidadBusqueda.Articulos, false);
            buscardorArt.Closed += new EventHandler(seleccionarArticulo);
            buscardorArt.ShowDialog();
        }

        private void seleccionarArticulo(object sender, EventArgs e)
        {
            try
            {
                if (!this.Enabled)
                    return;


                BusquedaEntidadesForm objForm = sender as BusquedaEntidadesForm;

                decimal idSeleccionado = objForm.GetIdSeleccionado();
                if (idSeleccionado != Definiciones.Error.Valor.EnteroPositivo)
                {
                    this.vArticuloId = idSeleccionado;
                    using (var formInput = new Form_Cantidad())
                    {
                        // Mostrar el formulario y obtener el resultado
                        DialogResult resultado = formInput.ShowDialog();

                        // Verificar el resultado y el valor ingresado por el usuario
                        if (resultado == DialogResult.OK)

                            this.vCantidad = formInput.ObtenerCantidad();
                    }
                    this.vProductoSeleccionado = true;
                    AgregarDetalle();
                    this.vProductoSeleccionado = false;
                }
                
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message, Form_Alert.enmType.Error);
            }
        }

        private void cboPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValidarSeleccionado(cboPersonas))
            {
                obtenerCuetaCliente((decimal)cboPersonas.SelectedValue);
                txtArticulo.Focus();
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            PopUpBuscarCliente();
        }
        #region buscadorCliente
        public void PopUpBuscarCliente()
        {
            BusquedaEntidadesForm buscardorClie = new BusquedaEntidadesForm(true, Definiciones.Error.Valor.EnteroPositivo, BusquedaEntidadesForm.EntidadBusqueda.Personas, false);
            buscardorClie.Closed += new EventHandler(seleccionarCliente);
            buscardorClie.ShowDialog();
        }

        protected void seleccionarCliente(object sender, EventArgs e)
        {
            try
            {
                if (!this.Enabled)
                    return;

                BusquedaEntidadesForm objForm = sender as BusquedaEntidadesForm;

                decimal idSeleccionado = objForm.GetIdSeleccionado();
                if (idSeleccionado != Definiciones.Error.Valor.EnteroPositivo)
                {
                    RefrescarComboBoxCliente(ref cboPersonas, idSeleccionado.ToString(), true);
                    using (SessionService sesion = new SessionService())
                    {
                        cboPersonas.SelectedValue = idSeleccionado;
                    }
                }
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        protected void SelecccionarNuevoCliente(object sender, EventArgs e)
        {
            try
            {
                if (!this.Enabled)
                    return;

                ClienteBasicoForm objForm = sender as ClienteBasicoForm;

                decimal idSeleccionado = objForm.GetIdSeleccionado();
                if (idSeleccionado != Definiciones.Error.Valor.EnteroPositivo)
                {
                    this.vArticuloId = idSeleccionado;
                    using (SessionService sesion = new SessionService())
                    {
                        cboPersonas.SelectedValue = idSeleccionado;
                    }
                }
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        #endregion buscadorCliente

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (ValidarSeleccionado(cboPersonas))
                PopUpEditCliente(decimal.Parse(cboPersonas.SelectedValue.ToString()));
            else
                Alert.Show("No seleccionó ningún cliente",Form_Alert.enmType.Warning);
                
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            imprimir();
        }
    }
}
