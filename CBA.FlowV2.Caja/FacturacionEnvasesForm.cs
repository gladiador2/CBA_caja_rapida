using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBA.FlowV2.Caja
{
    public partial class FacturacionEnvasesForm : Form
    {
        #region Propiedades Privadas
        private System.ComponentModel.ComponentResourceManager resources;
        UnidadesService _Unidad = new UnidadesService();
        ArticulosEnvasesService _envase = new ArticulosEnvasesService();
        FacturasEnvasesService _facturaEnvase = new FacturasEnvasesService();
        Decimal idSeleccionado;
        Decimal idFacEnvaseSeleccionado;
        Decimal facProvDetId;
        string TextoBusqueda = string.Empty;
        TextBox txtBusEnvase;

        #region Clase Columnas
        private static class Columnas
        {
            public static class FacturasEnvases
            {
                public static int Id;
                public static int FacturaDetId;
                public static int EnvasesId;
                public static int FacturaEnvaseId;
                public static int Codigo;
                public static int Envases;
                public static int Peso;
                public static int Pesable;
                public static int Cantidad;
                //public static int SoloLectura;
                public static int Guardar;
                // public static int Color;
                public static int Borrar;
                public static int Buscar;
            }
        }
        #endregion Clase Columnas

        #region Accesors
        public UnidadesService Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }
        public ArticulosEnvasesService envase
        {
            get { return _envase; }
            set { _envase = value; }
        }
        public FacturasEnvasesService FacturasEnvase
        {
            get { return _facturaEnvase; }
            set { _facturaEnvase = value; }
        }
        #endregion Accesors

        #endregion Propiedades Privadas
        public FacturacionEnvasesForm()
        {
            InitializeComponent();
        }
        public FacturacionEnvasesForm(decimal factura_proveedor_detalle_id)
        {
            InitializeComponent();
            Unidad = new UnidadesService();
            envase = new ArticulosEnvasesService();
            facProvDetId = factura_proveedor_detalle_id;
            idSeleccionado = Definiciones.Error.Valor.EnteroPositivo;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
           
            base.OnLoad(e);
            // dgvListaEnvases.Click += new EventHandler(dataGridView_SelectionChanged);
            SetDataSources();
        }
        #endregion OnLoad
        #region SetDataSources
        private void SetDataSources()
        {
            //  RefrescarlistViewEnvaces();
            // RefrescarDataGrid();
            refrescarDataGripEnvases();
            refrescarComboboxEnvases();
            refrescarListaEnvases();
        }
        #endregion SetDataSources
        #region refrescarDataGripEnvases
        private void refrescarDataGripEnvases() 
        {
            try
            {
                string clausulas = string.Empty;
                clausulas = FacturasEnvasesService.VistaDetallefacturaId_NombreCol + " = " + facProvDetId;
                DataTable BuscarEnvases = new DataTable();
                DataColumn columEliminar = new DataColumn("eliminar", typeof(string));
              
                BuscarEnvases = FacturasEnvase.GetFacturasEnvasesInfoCompleta(clausulas, string.Empty);
                BuscarEnvases.Columns.Add(columEliminar);
                dgvEnvasesFactura.DataSource = BuscarEnvases;
                foreach (DataGridViewColumn c in dgvEnvasesFactura.Columns)
                {
                    c.Visible = false;
                }
                int displayIndex = 0;
                // Botón Eliminar
                int indice = dgvEnvasesFactura.Columns["eliminar"].Index;
                dgvEnvasesFactura.Columns.RemoveAt(indice);
                DataGridViewImageColumn btnEliminarColumn = new DataGridViewImageColumn();
                btnEliminarColumn.Name = "eliminar";
                btnEliminarColumn.HeaderText = string.Empty;
                btnEliminarColumn.Width = 25;
                btnEliminarColumn.DefaultCellStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                btnEliminarColumn.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightCoral;
                btnEliminarColumn.Image = Properties.Resources.borrar;
                btnEliminarColumn.DisplayIndex = displayIndex++;
                dgvEnvasesFactura.Columns.Insert(indice, btnEliminarColumn);

                indice = dgvEnvasesFactura.Columns[FacturasEnvasesService.VistaNombre_NombreCol].Index;
                dgvEnvasesFactura.Columns[indice].Visible = true;
                dgvEnvasesFactura.Columns[indice].HeaderText = "Envases";
                dgvEnvasesFactura.Columns[indice].Width = 150;
                dgvEnvasesFactura.Columns[indice].DisplayIndex = displayIndex++;

                indice = dgvEnvasesFactura.Columns[FacturasEnvasesService.Cantidad_NombreCol].Index;
                dgvEnvasesFactura.Columns[indice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvEnvasesFactura.Columns[indice].Visible = true;
                dgvEnvasesFactura.Columns[indice].Visible = true;
                dgvEnvasesFactura.Columns[indice].HeaderText = "Cant.";
                dgvEnvasesFactura.Columns[indice].Width = 90;
                dgvEnvasesFactura.Columns[indice].DisplayIndex = displayIndex++;


                indice = dgvEnvasesFactura.Columns[FacturasEnvasesService.Peso_NombreCol].Index;
                dgvEnvasesFactura.Columns[indice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                
                dgvEnvasesFactura.Columns[indice].Visible = true;
                dgvEnvasesFactura.Columns[indice].Visible = true;
                dgvEnvasesFactura.Columns[indice].HeaderText = "Peso.";
                dgvEnvasesFactura.Columns[indice].Width = 90;
                dgvEnvasesFactura.Columns[indice].DisplayIndex = displayIndex++;
                dgvEnvasesFactura.CellClick += dgvEnvasesFactura_CellClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oop! algo salio mal");
            }
        }
        #endregion refrescarDataGripEnvases
        private void dgvEnvasesFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Obtener el id del registro usando el índice de fila
                decimal detalleId = (decimal)dgvEnvasesFactura.Rows[e.RowIndex].Cells[FacturasEnvasesService.VistaFacturaEnvaseId_NombreCol].Value;

              
                if (e.ColumnIndex == dgvEnvasesFactura.Columns["eliminar"].Index && e.RowIndex >= 0)
                {
                    FacturasEnvasesService facEnvases = new FacturasEnvasesService();
                    facEnvases.Borrar(detalleId);
                    refrescarDataGripEnvases();
                }
                
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        #region refrescarComboboxEnvases
        private void refrescarComboboxEnvases()
        { 
            cboEnvases.DataSource =  envase.GetArticulosEnvasesInfoCompleta("1=1", string.Empty);
            cboEnvases.DisplayMember = ArticulosEnvasesService.Nombre_NombreCol;
            cboEnvases.ValueMember = ArticulosEnvasesService.Id_NombreCol;
        }
        #endregion refrescarComboboxEnvases
        #region refrescar dgvListaEnvases
        private void refrescarListaEnvases() 
        {
            try
            {
                dgvListaEnvases.DataSource = envase.GetArticulosEnvasesInfoCompleta("1=1",string.Empty);
                foreach (DataGridViewColumn c in  dgvListaEnvases.Columns)
                {
                    c.Visible = false;
                }

                 dgvListaEnvases.Columns[ArticulosEnvasesService.Id_NombreCol].Visible = false;
                 dgvListaEnvases.Columns[ArticulosEnvasesService.Nombre_NombreCol].Visible = true;
                 dgvListaEnvases.Columns[ArticulosEnvasesService.Codigo_NombreCol].Visible = true;
                 dgvListaEnvases.Columns[ArticulosEnvasesService.UnidadId_NombreCol].Visible = false;
                 dgvListaEnvases.Columns[ArticulosEnvasesService.Pesable_NombreCol].Visible = false;
                 dgvListaEnvases.Columns[ArticulosEnvasesService.Peso_NombreCol].Visible = false;

                 dgvListaEnvases.Columns[ArticulosEnvasesService.UnidadId_NombreCol].HeaderText = "Unidad de Medida";
                 dgvListaEnvases.Columns[ArticulosEnvasesService.Nombre_NombreCol].HeaderText = "Nombre";
                 dgvListaEnvases.Columns[ArticulosEnvasesService.Codigo_NombreCol].HeaderText = "Codigo";
                 dgvListaEnvases.Columns[ArticulosEnvasesService.Pesable_NombreCol].HeaderText = "Es Pesable";
                 dgvListaEnvases.Columns[ArticulosEnvasesService.Peso_NombreCol].HeaderText = "Peso";

                 dgvListaEnvases.Columns[ArticulosEnvasesService.Id_NombreCol].DisplayIndex = 0;
                 dgvListaEnvases.Columns[ArticulosEnvasesService.Codigo_NombreCol].DisplayIndex = 1;
                 dgvListaEnvases.Columns[ArticulosEnvasesService.Nombre_NombreCol].DisplayIndex = 2;
                 dgvListaEnvases.Columns[ArticulosEnvasesService.UnidadId_NombreCol].DisplayIndex = 3;
                 dgvListaEnvases.Columns[ArticulosEnvasesService.Pesable_NombreCol].DisplayIndex = 4;
                 dgvListaEnvases.Columns[ArticulosEnvasesService.Peso_NombreCol].DisplayIndex = 5;

                 dgvListaEnvases.AutoResizeColumns();
                 dgvListaEnvases.ClearSelection();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }
        #endregion refrescar dgvListaEnvases

        private void btnAgregar_Click(object sender, EventArgs e)
        {
                try
                {
                    DataTable registroActual = new DataTable();
                    System.Collections.Hashtable campos = new System.Collections.Hashtable();
                /*
                    if (!lvi.SubItems[Columnas.FacturasEnvases.FacturaEnvaseId].Equals(Definiciones.Error.Valor.EnteroPositivo))

                        idFacEnvaseSeleccionado = decimal.Parse(lvi.SubItems[Columnas.FacturasEnvases.FacturaEnvaseId].Text);
                    else*/
                        idFacEnvaseSeleccionado = Definiciones.Error.Valor.EnteroPositivo;
                    bool registroNuevo = idFacEnvaseSeleccionado == Definiciones.Error.Valor.EnteroPositivo;

                if (registroNuevo)
                    campos.Add(FacturasEnvasesService.EnvaseId_NombreCol, cboEnvases.SelectedValue);
                else
                {
                    campos.Add(FacturasEnvasesService.EnvaseId_NombreCol, cboEnvases.SelectedValue);
                        campos.Add(FacturasEnvasesService.Id_NombreCol, idFacEnvaseSeleccionado);
                    }
                    campos.Add(FacturasEnvasesService.FacturaClienteDetalleID_NombreCol, this.facProvDetId);
                   
                    campos.Add(FacturasEnvasesService.Peso_NombreCol, numPeso.Value);
                   
                    campos.Add(FacturasEnvasesService.Cantidad_NombreCol, NumCantidad.Value);
                    FacturasEnvase.Guardar(campos, registroNuevo);
                    // Recarga el dataGridView
                    SetDataSources();
                    //LimpiarCampos();
                     Alert.Show("Se guardo el registro", Notificaciones.Form_Alert.enmType.Success);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

            

        }
    }
}
