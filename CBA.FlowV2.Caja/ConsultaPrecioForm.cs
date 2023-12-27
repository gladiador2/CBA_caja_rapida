using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.ListaDePrecio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CBA.FlowV2.Services.Base.EdiCBA;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ApplicationContext = CBA.FlowV2.Services.ApplicationContext;

namespace CBA.FlowV2.Caja
{
    public partial class ConsultaPrecioForm : Form
    {
       
        #region Constructores
        public ConsultaPrecioForm()
        {
            InitializeComponent();
        }

        #endregion Constructores
        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Text = "Consultar Precios";
            
        }

        #endregion OnLoad

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region refrescarDataGrip
        private void refrescarDataGrip()
        {
            
            string clausulas = string.Empty;
            string txt = txtFiltro.Text.ToUpper();
            //control de que la sesion sea unica y actual
            

            try
            {
                if (txt.Equals(string.Empty))
                    clausulas += " 1 = 1 ";
                else
                {
                    clausulas += ArticulosService.DescripcionInterna_NombreCol + " like upper('%" + txt + "%')";
                    clausulas += " or " + ArticulosService.DescripcionImpresion_NombreCol + " like upper('%" + txt + "%')";
                    clausulas += " or " + ArticulosService.DescripcionCatalogo_NombreCol + " like upper('%" + txt + "%')";
                    clausulas += " or " + ArticulosService.CodigoBarrasEmpresa_NombreCol + " like upper('%" + txt + "%')";
                    clausulas += " or " + ArticulosService.CodigoBarrasProveedor_NombreCol + " like upper('%" + txt + "%')";
                    clausulas += " or " + ArticulosService.CodigoEmpresa_NombreCol + " like upper('%" + txt + "%')";
                }
                ArticulosService oArticulos = new ArticulosService();

                DataTable dtArticulos = ArticulosService.GetArticulosInfoCompleta(clausulas, string.Empty, true, (decimal)ApplicationContext.Session["sucursalID"]);
                
                dgvArticulos.DataSource = dtArticulos;
                // Recorrer todas las columnas
                for (int i = 0; i < dgvArticulos.Columns.Count; i++)
                {
                    // Asignar la propiedad Visible a false
                    dgvArticulos.Columns[i].Visible = false;
                }
                int indice = 0;
                int displayIndex = 0;

                indice = dgvArticulos.Columns[ArticulosService.VistaDescripcionAUtilizar_NombreCol].Index;
                dgvArticulos.Columns[indice].Width = 300;
                dgvArticulos.Columns[indice].Visible = true;
                dgvArticulos.Columns[indice].HeaderText = "Artículo";
                dgvArticulos.Columns[indice].DisplayIndex = displayIndex++;

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        #endregion refrescarDataGrip

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            refrescarDataGrip();
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                refrescarDataGrip();
        }
        #region refrescarListView
        private void refrescarListView(decimal idArticulo)
        {
           

            
            try
            {
                string clausula = ListasDePrecioService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.ListaPreciosRestringirPorMoneda) == Definiciones.SiNo.Si)
                    clausula += " and " + ListasDePrecioService.MonedaId_NombreCol + " = " + Definiciones.Monedas.Guaranies;

                clausula += " and ((" + ListasDePrecioService.FechaInicio_NombreCol + " is null or " +
                       ListasDePrecioService.FechaInicio_NombreCol + " <= to_date('" + DateTime.Now.ToShortDateString() + "','dd/mm/yyyy')) and (" +
                       ListasDePrecioService.FechaFin_NombreCol + " is null or " +
                       ListasDePrecioService.FechaFin_NombreCol + " >= to_date('" + DateTime.Now.ToShortDateString() + "','dd/mm/yyyy'))) and " +
                       "(" + ListasDePrecioService.RegionId_NombreCol + " is null or " + ListasDePrecioService.RegionId_NombreCol + " = " + new SucursalesService(decimal.Parse(ApplicationContext.Session["sucursalID"].ToString())).RegionId.Value + ") and " +
                       "(" + ListasDePrecioService.SucursalId_NombreCol + " is null or " + ListasDePrecioService.SucursalId_NombreCol + " = " + ApplicationContext.Session["sucursalID"].ToString() + ")";

                ListasDePrecioService listasDePrecio = new ListasDePrecioService();
                DataTable dtListaPrecio = listasDePrecio.GetListasDePrecioInfoCompleta(clausula, ListasDePrecioService.Nombre_NombreCol);
                string idsString = "";

                // Recorrer las filas del datatable
                foreach (DataRow row in dtListaPrecio.Rows)
                {
                    // Obtener el id de la fila y convertirlo en cadena
                    string id = row["id"].ToString();
                    // Concatenar el id con la cadena y agregar una coma
                    idsString += id + ",";
                }
                // Eliminar la última coma de la cadena
                idsString = idsString.TrimEnd(',');

                ListasDePrecioDetalleService LisPreciosDet = new ListasDePrecioDetalleService();
                String clausula2 = string.Empty;
                clausula2 = ListasDePrecioDetalleService.ListaPrecioId_NombreCol + " in (" + idsString + ")" +
                     " and " + ListasDePrecioDetalleService.ArticuloId_NombreCol + " = " + idArticulo +
                     " and " + ListasDePrecioDetalleService.Precio_NombreCol + " > 0";
                DataTable dtListaPrecioDetalle = LisPreciosDet.GetListasDePrecioDetalleInfoCompleta(clausula2, string.Empty);
                // Ocultar todas las columnas con un bucle
                dgvListaPrecios.DataSource = dtListaPrecioDetalle;
                // Recorrer todas las columnas
                for (int i = 0; i < dgvListaPrecios.Columns.Count; i++)
                {
                    // Asignar la propiedad Visible a false
                    dgvListaPrecios.Columns[i].Visible = false;
                }
                int indice = 0;
                int displayIndex = 0;

                indice = dgvListaPrecios.Columns[ListasDePrecioDetalleService.VistaListaPrecioNombre_NombreCol].Index;
                dgvListaPrecios.Columns[indice].Width = 200;
                dgvListaPrecios.Columns[indice].Visible = true;
                dgvListaPrecios.Columns[indice].HeaderText = "Lista Precio";
                dgvListaPrecios.Columns[indice].DisplayIndex = displayIndex++;

                indice = dgvListaPrecios.Columns[ListasDePrecioDetalleService.Precio_NombreCol].Index;
                dgvListaPrecios.Columns[indice].Width = 100;
                dgvListaPrecios.Columns[indice].Visible = true;
                dgvListaPrecios.Columns[indice].HeaderText = "Precio";
               
                dgvListaPrecios.Columns[indice].DisplayIndex = displayIndex++;


               
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        #endregion refrescarListView

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows.Count > 0)
            {
                int idSeleccionado = int.Parse( dgvArticulos.SelectedRows[0].Cells["ID"].Value.ToString());
                refrescarListView(idSeleccionado);
                lblArticulo.Text = dgvArticulos.SelectedRows[0].Cells[ArticulosService.VistaDescripcionSinCodigo_NombreCol].Value.ToString();
            }
        }
    }
}
