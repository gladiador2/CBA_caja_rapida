using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Facturacion;
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

    public partial class BusquedaEntidadesForm : Form
    {
        #region Variables Privadas
        private decimal idSeleccionado = Definiciones.Error.Valor.EnteroPositivo;
        private decimal idCargado = Definiciones.Error.Valor.EnteroPositivo;
        private decimal? sucursalId;
        private string vTitulo = string.Empty;
        private bool devolverArticuloSeleccionado;
        private EntidadBusqueda vEntidadBusqueda;

        #endregion Variables Privadas

        public enum EntidadBusqueda
        {
            Articulos = 1,
            Personas = 2,
            Proveedores = 3,
            Funcionarios = 4
        }
        #region Constructores

        public decimal GetIdSeleccionado()
        {
            return idSeleccionado;
        }

        public BusquedaEntidadesForm(bool devolverArticuloSeleccionado, decimal id, EntidadBusqueda entidadBuscar)
        {
            InitializeComponent();
            idCargado = id;
            this.vEntidadBusqueda = entidadBuscar;

        }
        public BusquedaEntidadesForm(bool devolverArticuloSeleccionado, decimal id, EntidadBusqueda entidadBuscar, bool MostrarBotonBuscar)
        {
            InitializeComponent();
            idCargado = id;
            this.vEntidadBusqueda = entidadBuscar;
            

        }

        public BusquedaEntidadesForm(bool devolverArticuloSeleccionado, decimal id, EntidadBusqueda entidadBuscar, string titulo)
            : this(devolverArticuloSeleccionado, id, entidadBuscar)
        {

            idCargado = id;
            this.vEntidadBusqueda = entidadBuscar;
            this.vTitulo = titulo;
        }

        public BusquedaEntidadesForm(bool devolverArticuloSeleccionado, EntidadBusqueda entidadBuscar, string titulo)
            : this(devolverArticuloSeleccionado, Definiciones.Error.Valor.EnteroPositivo, entidadBuscar)
        {

            idCargado = Definiciones.Error.Valor.EnteroPositivo;
            this.vEntidadBusqueda = entidadBuscar;
            this.vTitulo = titulo;
        }

        public BusquedaEntidadesForm(bool devolverArticuloSeleccionado, EntidadBusqueda entidadBuscar)
            : this(devolverArticuloSeleccionado, Definiciones.Error.Valor.EnteroPositivo, entidadBuscar)
        {
            idCargado = Definiciones.Error.Valor.EnteroPositivo;
            this.vEntidadBusqueda = entidadBuscar;
        }

        #endregion Constructores

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.MinimizeBox = false;

            InicializarTraducciones();
           

        }

        private void InicializarTraducciones()
        {
            switch (this.vEntidadBusqueda)
            {
                case BusquedaEntidadesForm.EntidadBusqueda.Articulos:
                    labelBusqueda.Text = vTitulo.Equals(string.Empty) ? "Buscar Artículo" : vTitulo;
                    break;
                case BusquedaEntidadesForm.EntidadBusqueda.Personas:
                    labelBusqueda.Text = vTitulo.Equals(string.Empty) ? "Buscar Cliennte" : vTitulo;
                    break;
                case BusquedaEntidadesForm.EntidadBusqueda.Proveedores:
                    this.Text = vTitulo.Equals(string.Empty) ? "Buscar Proveedor" : vTitulo;
                    break;
                case BusquedaEntidadesForm.EntidadBusqueda.Funcionarios:
                    this.Text = vTitulo.Equals(string.Empty) ? "Buscar Funcionario" : vTitulo;
                    break;
                default:
                    this.Text = "Buscar";
                    return;
            }

        }
        #region Refrescar Campos
        private void RefrescarListView()
        {
           
            //Inicializa el id seleccionado
            idSeleccionado = Definiciones.Error.Valor.EnteroPositivo;
            try
            {
                switch (this.vEntidadBusqueda)
                {
                    case BusquedaEntidadesForm.EntidadBusqueda.Articulos:
                        buscarArticulo();
                        break;
                    case BusquedaEntidadesForm.EntidadBusqueda.Personas:
                        buscarPersonas();
                        break;
                    default:
                        return;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        #endregion Refrescar Campos

        #region buscarArticulo
        private void buscarArticulo()
        {
            string clausulas = string.Empty;
            string txt = textBoxFiltro.Text.ToUpper();
            DataTable dt = new DataTable();


            if (txt.Length > 2)
            {
               
                    string texto = textBoxFiltro.Text.ToUpper();

                    clausulas += "    (upper(" + ArticulosService.CodigoEmpresa_NombreCol + ") like '%" + texto + "%' ";
                    clausulas += "     or upper(" + ArticulosService.CodigoProveedor_NombreCol + ") like '%" + texto + "%' ";
                    clausulas += "     or upper(" + ArticulosService.CodigoBarrasEmpresa_NombreCol + ") like '%" + texto + "%' ";
                    clausulas += "     or upper(" + ArticulosService.CodigoBarrasProveedor_NombreCol + ") like '%" + texto + "%') ";

                    clausulas += " or (upper(" + ArticulosService.DescripcionInterna_NombreCol + ") like '%" + texto + "%' ";
                    clausulas += "     or upper(" + ArticulosService.DescripcionImpresion_NombreCol + ") like '%" + texto + "%' ";
                    clausulas += "     or upper(" + ArticulosService.DescripcionProveedor_NombreCol + ") like '%" + texto + "%') ";

                    clausulas += " or (" + ArticulosService.VistaFamiliaDescripcion_NombreCol + " like '%" + texto + "' ";
                    clausulas += "     or upper(" + ArticulosService.VistaGrupoDescripcion_NombreCol + ") like '%" + texto + "%' ";
                    clausulas += "     or upper(" + ArticulosService.VistaSubgrupoDescripcion_NombreCol + ") like '%" + texto + "%') ";

                    dt = ArticulosService.GetArticulosInfoCompleta(clausulas, ArticulosService.CodigoEmpresa_NombreCol, false, this.sucursalId);
                

            }
            else
            {
                dt = null;
            }

            if (dt == null)
            {
                listViewResultados.DataSource = null;
                return;
            }
            else
            {
                //si el datatable esta vacio se salta todo el proceso
                if (dt.Rows.Count == 0)
                {
                    listViewResultados.DataSource = null;
                    return;
                }
            }


            //nuevas columnas para los botones de guardar y quitar
            dt.Columns.Add("Seleccionar", typeof(bool));


            listViewResultados.DataSource = dt;

          
            // Recorrer todas las columnas
            for (int i = 0; i < listViewResultados.Columns.Count; i++)
            {
                // Asignar la propiedad Visible a false
                listViewResultados.Columns[i].Visible = false;
            }

            #region Formato Columnas

            int indice = 0;
            int displayIndex = 0;

            indice = listViewResultados.Columns["Seleccionar"].Index;
             
            
            listViewResultados.Columns.RemoveAt(indice);
            DataGridViewButtonColumn btnSeleccionarColumn = new DataGridViewButtonColumn();
            btnSeleccionarColumn.Name = "Seleccionar";
            btnSeleccionarColumn.HeaderText = string.Empty;
            btnSeleccionarColumn.Width = 100;
            
            btnSeleccionarColumn.Text = "Seleccionar";
            btnSeleccionarColumn.DisplayIndex = displayIndex++;
            listViewResultados.Columns.Insert(indice, btnSeleccionarColumn);

            indice = listViewResultados.Columns[ ArticulosService.VistaDescripcionAUtilizar_NombreCol].Index;
            listViewResultados.Columns[indice].Width = 300;
            listViewResultados.Columns[indice].Visible = true;
            listViewResultados.Columns[indice].HeaderText = "Código - Descripción";
            listViewResultados.Columns[indice].DisplayIndex = displayIndex++;

             indice = listViewResultados.Columns[ ArticulosService.VistaFamiliaDescripcion_NombreCol].Index;
            listViewResultados.Columns[indice].Width = 150;
            listViewResultados.Columns[indice].Visible = true;
            listViewResultados.Columns[indice].HeaderText = "Familia";
            listViewResultados.Columns[indice].DisplayIndex = displayIndex++;

             indice = listViewResultados.Columns[ ArticulosService.VistaGrupoDescripcion_NombreCol].Index;
            listViewResultados.Columns[indice].Width = 150;
            listViewResultados.Columns[indice].Visible = true;
            listViewResultados.Columns[indice].HeaderText = "Grupo";
            listViewResultados.Columns[indice].DisplayIndex = displayIndex++;

            #endregion Formato Columnas

            #region Agregar Controles
            listViewResultados.CellClick += listViewResultados_CellClick;
            #endregion Agregar Controles
        }


        #endregion buscarArticulo


        #region buscarPersonas
        private void buscarPersonas()
        {
            //Inicializa el id seleccionado
            //idSeleccionado = Definiciones.Error.Valor.EnteroPositivo;

            string clausulas = string.Empty;
            string txt = textBoxFiltro.Text.ToUpper();
            DataTable dt = new DataTable();

            if (txt.Length > 2)
            {
                
                    string texto = textBoxFiltro.Text.ToUpper();

                    clausulas += "     upper(" + PersonasService.Nombre_NombreCol + ") like '%" + txt + "%' " +
                                    " or upper(" + PersonasService.Apellido_NombreCol + ") like '%" + txt + "%' " +
                                    " or upper(" + PersonasService.Ruc_NombreCol + ") like '%" + txt + "%' " +
                                    " or upper(" + PersonasService.Codigo_NombreCol + ") like '%" + txt + "%' " +
                                    " or upper(" + PersonasService.CodigoExterno_NombreCol + ") like '%" + txt + "%' " +
                                    " or ( upper(" + PersonasService.Telefono1_NombreCol + ") like '%" + txt + "%' " +
                                    "    or upper(" + PersonasService.Telefono2_NombreCol + ") like '%" + txt + "%' " +
                                    "    or upper(" + PersonasService.Telefono3_NombreCol + ") like '%" + txt + "%' " +
                                    "    or upper(" + PersonasService.Telefono4_NombreCol + ") like '%" + txt + "%' " +
                                    "    or upper(" + PersonasService.TelefonoCobranza1_NombreCol + ") like '%" + txt + "%' " +
                                    "    or upper(" + PersonasService.TelefonoCobranza2_NombreCol + ") like '%" + txt + "%' ) " +
                                    " or upper(" + PersonasService.NumeroDocumento_NombreCol + ") like '%" + txt + "%' " +
                                    " or ( upper(" + PersonasService.Email1_NombreCol + ") like '%" + txt + "%' " +
                                    "    or upper(" + PersonasService.Email2_NombreCol + ") like '%" + txt + "%' " +
                                    "    or upper(" + PersonasService.Email3_NombreCol + ") like '%" + txt + "%') " +
                                    "    or upper(" + PersonasService.NombreCompleto_NombreCol + ") like '%" + txt + "%' ";
                    dt = PersonasService.GetPersonasDataTable(clausulas, string.Empty);
                
            }
            else
            {
                dt = null;
            }

            if (dt == null)
            {
                listViewResultados.DataSource = null;
                return;
            }
            else
            {
                //si el datatable esta vacio se salta todo el proceso
                if (dt.Rows.Count == 0)
                {
                    listViewResultados.DataSource = null;
                    return;
                }
            }

            //nuevas columnas para los botones de guardar y quitar
            dt.Columns.Add("Seleccionar", typeof(bool));


            listViewResultados.DataSource = dt;

            //ocultar todas las columnas del ListView
            for (int i = 0; i < listViewResultados.Columns.Count; i++)
            {
                // Asignar la propiedad Visible a false
                listViewResultados.Columns[i].Visible = false;
            }

            #region Formato Columnas

            int indice = 0;
            int displayIndex = 0;

            indice = listViewResultados.Columns["Seleccionar"].Index;


            listViewResultados.Columns.RemoveAt(indice);
            DataGridViewButtonColumn btnSeleccionarColumn = new DataGridViewButtonColumn();
            btnSeleccionarColumn.Name = "Seleccionar";
            btnSeleccionarColumn.HeaderText = string.Empty;
            btnSeleccionarColumn.Width = 100;
            btnSeleccionarColumn.Text = "Seleccionar";
            btnSeleccionarColumn.DisplayIndex = displayIndex++;
            listViewResultados.Columns.Insert(indice, btnSeleccionarColumn);




            indice = listViewResultados.Columns[ PersonasService.NombreCompleto_NombreCol].Index;
            listViewResultados.Columns[indice].Width = 300;
            listViewResultados.Columns[indice].Visible = true;
            listViewResultados.Columns[indice].HeaderText = "Nombre Completo";
            listViewResultados.Columns[indice].DisplayIndex = displayIndex++;

            indice = listViewResultados.Columns[ PersonasService.Ruc_NombreCol].Index;
            listViewResultados.Columns[indice].Width = 100;
            listViewResultados.Columns[indice].Visible = true;
            listViewResultados.Columns[indice].HeaderText = "RUC";
            listViewResultados.Columns[indice].DisplayIndex = displayIndex++;

            indice = listViewResultados.Columns[ PersonasService.Email1_NombreCol].Index;
            listViewResultados.Columns[indice].Width = 100;
            listViewResultados.Columns[indice].Visible = true;
            listViewResultados.Columns[indice].HeaderText = "E-Mail";
            listViewResultados.Columns[indice].DisplayIndex = displayIndex++;

            indice = listViewResultados.Columns[ PersonasService.EsCliente_NombreCol].Index;
            listViewResultados.Columns[indice].Width = 50;
            listViewResultados.Columns[indice].Visible = true;
            listViewResultados.Columns[indice].HeaderText = "Es Cliente";
            listViewResultados.Columns[indice].DisplayIndex = displayIndex++;

            indice = listViewResultados.Columns[ PersonasService.Estado_NombreCol].Index;
            listViewResultados.Columns[indice].Width = 50;
            listViewResultados.Columns[indice].Visible = true;
            listViewResultados.Columns[indice].HeaderText = "Estado";
            listViewResultados.Columns[indice].DisplayIndex = displayIndex++;
            #endregion Formato Columnas

            #region Agregar Controles
            //obtener índices de las columnas
            listViewResultados.CellClick += listViewResultados_CellClick;
            #endregion Agregar Controles
        }
        #endregion buscarPersonas

        private void listViewResultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idSeleccionado = (decimal)listViewResultados.Rows[e.RowIndex].Cells[ArticulosService.Id_NombreCol].Value;
                this.Close();
            }
            catch (Exception ex)
            {

                Alert.Show(ex.Message,Notificaciones.Form_Alert.enmType.Error);
            }
           
        }

        private void textBoxFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    RefrescarListView();
                }
                catch (Exception ex)
                {

                    Alert.Show(ex.Message, Notificaciones.Form_Alert.enmType.Error);
                }
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            RefrescarListView();
        }
    }
}
