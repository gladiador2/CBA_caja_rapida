using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.General;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.ListaDePrecio;
using CBA.FlowV2.Services.PeticionesApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBA.FlowV2.Caja
{

    public partial class ClienteBasicoForm : Form
    {
        private decimal vIdSeleccionado = Definiciones.Error.Valor.EnteroPositivo;
        private bool InsertarNuevo = true;
        private decimal vIdCliente = Definiciones.Error.Valor.EnteroPositivo;
        private decimal vTipoCliente = Definiciones.TiposCliente.NoAplica;
        private string vNroDocumentoDiplomatico = "77777701";
        public ClienteBasicoForm()
        {
            InitializeComponent();

        }
        public ClienteBasicoForm(decimal clienteID)
        {
            InitializeComponent();
            this.vIdCliente = clienteID;
        }

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
           


            base.OnLoad(e);
            setdatasourses();


            radioButtonEditFisico.Checked = false;
            radioButtonEditFisico.Checked = true;

            if (this.vIdCliente != Definiciones.Error.Valor.EnteroPositivo)
            {
                obtenerCliente(this.vIdCliente);
            }

            if (radioButtonEditJuridico.Checked)
            {
                lblRazon.Text = "Razón Social: ";
                lblApellido.Visible = false;
                textBoxEditApellido.Visible = false;
            }

            else
            {
                lblRazon.Text = "Nombre: ";
                lblApellido.Visible = true;
                textBoxEditApellido.Visible = true;
            }

        }
        #endregion OnLoad

        #region setdatasourses
        public decimal GetIdSeleccionado()
        {
            return this.vIdSeleccionado;
        }

        private void setdatasourses()
        {
            RefrescarComboGentilicios(ref comboBoxEditNacionalidad);
            RefrescarComboPais(ref comboBoxEditResidencia);
            RefrescarComboTipoDoc(ref comboBoxTipoDocumento);

        }
        private void RefrescarComboPais(ref ComboBox comboBox)
        {

            comboBox.DataSource = PaisesService.GetPaisesDataTable();
            comboBox.ValueMember = PaisesService.Id_NombreCol;
            comboBox.DisplayMember = PaisesService.Nombre_NombreCol;
            comboBox.SelectedValue = 1;
        }
        private void RefrescarComboTipoDoc(ref ComboBox comboBox)
        {

            TiposDocumentosIdentidadService tipos = new TiposDocumentosIdentidadService();
            comboBox.DataSource = tipos.GetTiposDataTable();
            comboBox.ValueMember = TiposDocumentosIdentidadService.Nombre_NombreCol;
            comboBox.DisplayMember = TiposDocumentosIdentidadService.Nombre_NombreCol;
            comboBox.SelectedValue = 1;
        }
        private void RefrescarComboGentilicios(ref ComboBox comboBox)
        {
            PaisesService paises = new PaisesService();
            comboBox.DataSource = paises.GetGentilicios();
            comboBox.ValueMember = PaisesService.Id_NombreCol;
            comboBox.DisplayMember = PaisesService.Gentilicio_NombreCol;
            comboBox.SelectedValue = 1;
        }
        private void RefrescarComboBoxListaPrecio(ref ComboBox comboBox)
        {
            try
            {
                ListasDePrecioService listasDePrecio = new ListasDePrecioService();

                string clausula = ListasDePrecioService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

                clausula += " and ((" + ListasDePrecioService.FechaInicio_NombreCol + " is null or " +
                      ListasDePrecioService.FechaInicio_NombreCol + " <= to_date('" + DateTime.Now.ToShortDateString() + "','dd/mm/yyyy')) and (" +
                      ListasDePrecioService.FechaFin_NombreCol + " is null or " +
                      ListasDePrecioService.FechaFin_NombreCol + " >= to_date('" + DateTime.Now.ToShortDateString() + "','dd/mm/yyyy'))) ";

                comboBox.DataSource = listasDePrecio.GetListasDePrecioInfoCompleta(clausula, ListasDePrecioService.Nombre_NombreCol);
                comboBox.ValueMember = ListasDePrecioService.Id_NombreCol;
                comboBox.DisplayMember = ListasDePrecioService.Nombre_NombreCol;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion setdatasourses

        private void obtenerCliente(decimal clienteID)
        {
            PersonasService personas = new PersonasService();
            DataTable dtPersonas = personas.GetPersona(clienteID);
            DataRow drPersonas = dtPersonas.Rows[0];
            radioButtonEditFisico.Checked = drPersonas[PersonasService.Fisico_NombreCol].ToString() == Definiciones.SiNo.Si ? true : false;
            radioButtonEditJuridico.Checked = drPersonas[PersonasService.Fisico_NombreCol].ToString() == Definiciones.SiNo.No ? true : false;
            textBoxCodigo.Text = drPersonas[PersonasService.Codigo_NombreCol].ToString();
            comboBoxTipoDocumento.SelectedValue = drPersonas[PersonasService.TipoDocumentoIdentidadId_NombreCol].ToString();
            textBoxEditRazon.Text = drPersonas[PersonasService.Nombre_NombreCol].ToString();
            textBoxEditApellido.Text = drPersonas[PersonasService.Apellido_NombreCol].ToString();
            txtEmail.Text = drPersonas[PersonasService.Email1_NombreCol].ToString();
            txtDireccion.Text = drPersonas[PersonasService.CalleCobranza_NombreCol].ToString();
            textBoxEditRuc.Text = drPersonas[PersonasService.NumeroDocumento_NombreCol].ToString();
            txtTelefono.Text = drPersonas[PersonasService.Telefono1_NombreCol].ToString();
            if (drPersonas[PersonasService.PaisResidenciaId_NombreCol] != DBNull.Value)
                comboBoxEditResidencia.SelectedValue = decimal.Parse(drPersonas[PersonasService.PaisResidenciaId_NombreCol].ToString());
            if (drPersonas[PersonasService.PaisNacionalidadId_NombreCol] != DBNull.Value)

                comboBoxEditNacionalidad.SelectedValue = decimal.Parse(drPersonas[PersonasService.PaisNacionalidadId_NombreCol].ToString());
            checkBoxClienteDiplomatico.Checked = drPersonas[PersonasService.Ruc_NombreCol].ToString() == vNroDocumentoDiplomatico;

            this.vIdCliente = clienteID;
            this.InsertarNuevo = false;
        }

        private void textBoxEditRuc_TextChanged(object sender, EventArgs e)
        {
            textBoxEditRucDigitoVerificador.Text = string.Empty;
            if (textBoxEditRuc.Text.Length > 0)
                textBoxEditRucDigitoVerificador.Text = TiposDocumentosIdentidadService.GetDigitoVerificadorRUC(textBoxEditRuc.Text).ToString();
        }

        private void GuardarCliente()
        {
            this.vIdSeleccionado = PersonasService.CrearPersona(textBoxEditRazon.Text, textBoxEditApellido.Text, textBoxEditRuc.Text, textBoxEditRuc.Text, radioButtonEditFisico.Checked, (decimal)comboBoxEditNacionalidad.SelectedValue, (decimal)comboBoxEditResidencia.SelectedValue, txtEmail.Text, txtTelefono.Text);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            // Verifica si el texto del textboxEmail es un correo electrónico válido.
            if (txtEmail.Text != string.Empty)
            {
                if (!IsValidEmail(txtEmail.Text))
                {
                    // Si no es válido, muestra un icono de error y un mensaje.
                    errorProvider1.SetError(txtEmail, "Correo electrónico no válido.");
                }
                else
                {
                    // Si es válido, borra el icono de error y el mensaje.
                    errorProvider1.SetError(txtEmail, "");
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            // Usa una expresión regular para verificar si el email tiene un formato válido.
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void textBoxEditRuc_Validating(object sender, CancelEventArgs e)
        {
            // Verifica si el texto del txtNombre no está vacío.
            if (textBoxEditRuc.Text == string.Empty)
            {
                // Si está vacío, muestra un icono de error y un mensaje.
                errorProvider1.SetError(textBoxEditRuc, " RUC es requerido.");
            }
            else
            {
                // Si no está vacío, borra el icono de error y el mensaje.
                errorProvider1.SetError(textBoxEditRuc, "");
            }
        }

        private void textBoxEditApellido_Validating(object sender, CancelEventArgs e)
        {
            // Verifica si el texto del txtNombre no está vacío.
            if (textBoxEditApellido.Text == string.Empty)
            {
                // Si está vacío, muestra un icono de error y un mensaje.
                errorProvider1.SetError(textBoxEditApellido, " Apellido es requerido.");
            }
            else
            {
                // Si no está vacío, borra el icono de error y el mensaje.
                errorProvider1.SetError(textBoxEditApellido, "");
            }
        }

        private void TxtTelefono_Validating(object sender, CancelEventArgs e)
        {
            // Obtener el texto del txtTelefono
            string texto = txtTelefono.Text;
            // Intentar convertirlo a un número entero
            int numero;
            bool esNumerico = int.TryParse(texto, out numero);
            // Si no es numérico o está vacío
            if (!esNumerico && texto != "")
            {
                // Cancelar el evento
                e.Cancel = true;
                // Mostrar el mensaje de error
                errorProvider1.SetError(txtTelefono, "El campo teléfono solo permite números.");
            }
            else
            {
                // Limpiar el mensaje de error
                errorProvider1.SetError(txtTelefono, "");
            }
        }

        // Esta función recibe un control y un errorprovider como parámetros
        // Devuelve verdadero si el control tiene un error asociado con el errorprovider
        // Devuelve falso si el control no tiene ningún error
        private string VerificarError(Control control, ErrorProvider errorProvider)
        {
            // Obtener la cadena del mensaje de error del errorprovider para el control
            string mensaje = errorProvider.GetError(control);
            // Si la cadena está vacía, significa que no hay ningún error
            if (mensaje == string.Empty)
            {
                return mensaje;
            }
            // Si la cadena no está vacía, significa que hay un error
            else
            {
                return mensaje;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Si el formulario es válido, muestra un mensaje de éxito.
                this.ValidateChildren();

                string mensaje = string.Empty;
                if (VerificarError(textBoxEditRuc, errorProvider1) != string.Empty)
                    mensaje += " \n -" + VerificarError(textBoxEditRuc, errorProvider1);
                if (VerificarError(textBoxEditRazon, errorProvider1) != string.Empty)
                    mensaje += " \n -" + VerificarError(textBoxEditRazon, errorProvider1);
                if (VerificarError(textBoxEditApellido, errorProvider1) != string.Empty && radioButtonEditFisico.Checked)
                    mensaje += " \n -" + VerificarError(textBoxEditApellido, errorProvider1);
                //if (VerificarError(txtEmail, errorProvider1) != string.Empty)
                //    mensaje += VerificarError(txtEmail, errorProvider1) + " \n -";
                if (VerificarError(txtTelefono, errorProvider1) != string.Empty)
                    mensaje += " \n -" + VerificarError(txtTelefono, errorProvider1);
                // validacion de codigo. Solo si esta chekeado es diplomatico
                if (checkBoxClienteDiplomatico.Checked)
                {
                    if (VerificarError(textBoxCodigo, errorProvider1) != string.Empty || VerificarError(textBoxCodigo, errorProvider1) != "")
                        mensaje += " \n -" + VerificarError(textBoxCodigo, errorProvider1);
                }

                string error = string.Empty;
                if (mensaje != string.Empty)
                    error += "Por favor, completar los campos obligatorios:" + mensaje;

                if (error != string.Empty)
                    // Muestra el mensaje de error con la lista de errores.
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (this.InsertarNuevo)
                    {
                        string l_codigo_cliente = textBoxEditRuc.Text;
                        if (checkBoxClienteDiplomatico.Checked)
                            l_codigo_cliente = textBoxCodigo.Text;

                        this.vIdSeleccionado = PersonasService.CrearPersona(textBoxEditRazon.Text, radioButtonEditJuridico.Checked ? string.Empty : textBoxEditApellido.Text, textBoxEditRuc.Text, l_codigo_cliente, radioButtonEditFisico.Checked,
                            (decimal)comboBoxEditNacionalidad.SelectedValue, (decimal)comboBoxEditResidencia.SelectedValue, txtEmail.Text, txtTelefono.Text, vTipoCliente, txtDireccion.Text, comboBoxTipoDocumento.SelectedValue.ToString(), textBoxEditRucDigitoVerificador.Text);

                        this.Close();
                    }
                    else
                    {
                        System.Collections.Hashtable campos = new System.Collections.Hashtable();
                        campos.Add(PersonasService.Id_NombreCol, this.vIdCliente);
                        campos.Add(PersonasService.Fisico_NombreCol, radioButtonEditFisico.Checked ? Definiciones.SiNo.Si : Definiciones.SiNo.No);

                        campos.Add(PersonasService.Codigo_NombreCol, textBoxCodigo.Text);
                        campos.Add(PersonasService.TipoDocumentoIdentidadId_NombreCol, comboBoxTipoDocumento.SelectedValue);
                        campos.Add(PersonasService.Nombre_NombreCol, textBoxEditRazon.Text);
                        campos.Add(PersonasService.Apellido_NombreCol, textBoxEditApellido.Text);
                        campos.Add(PersonasService.Email1_NombreCol, txtEmail.Text);
                        campos.Add(PersonasService.CalleCobranza_NombreCol, txtDireccion.Text);
                        campos.Add(PersonasService.NumeroDocumento_NombreCol, textBoxEditRuc.Text);
                        if (comboBoxTipoDocumento.SelectedValue == Definiciones.TiposDocumentoIdentidad.RUC)
                            campos.Add(PersonasService.Ruc_NombreCol, textBoxEditRuc.Text + "-" + textBoxEditRucDigitoVerificador.Text);

                        campos.Add(PersonasService.Telefono1_NombreCol, txtTelefono.Text);
                        campos.Add(PersonasService.PaisResidenciaId_NombreCol, comboBoxEditResidencia.SelectedValue);
                        campos.Add(PersonasService.PaisNacionalidadId_NombreCol, comboBoxEditNacionalidad.SelectedValue);

                        this.vIdSeleccionado = PersonasService.EditClienteRapido(campos);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                PopUp oPopUp = new PopUp();
                oPopUp.mostrarPopUP(ex.Message, 5000, PopUp.TipoMensaje.Error);
            }
        }

        private void textBoxEditNombre_Validating(object sender, CancelEventArgs e)
        {
            // Verifica si el texto del txtNombre no está vacío.
            if (textBoxEditRazon.Text == string.Empty)
            {
                // Si está vacío, muestra un icono de error y un mensaje.
                errorProvider1.SetError(textBoxEditRazon, radioButtonEditFisico.Checked ? " Nombre es requerido." : "Razón Social es requerido.");
            }
            else
            {
                // Si no está vacío, borra el icono de error y el mensaje.
                errorProvider1.SetError(textBoxEditRazon, "");
            }
        }

        private void comboBoxTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string StringValorCombo = string.Empty;
            if (comboBoxTipoDocumento.SelectedValue != null)
            {
                StringValorCombo = comboBoxTipoDocumento.SelectedValue.ToString();
            }
            textBoxEditRucDigitoVerificador.Visible = StringValorCombo.Equals(Definiciones.TiposDocumentoIdentidad.RUC, StringComparison.OrdinalIgnoreCase);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButtonEditJuridico_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEditJuridico.Checked)
            {
                lblRazon.Text = "Razón Social: ";
                lblApellido.Visible = false;
                textBoxEditApellido.Visible = false;
            }
            else
            {
                lblRazon.Text = "Nombre: ";
                lblApellido.Visible = true;
                textBoxEditApellido.Visible = true;
            }
        }

        private void radioButtonEditFisico_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEditJuridico.Checked)
            {
                lblRazon.Text = "Razón Social: ";
                lblApellido.Visible = false;
                textBoxEditApellido.Visible = false;
            }
            else
            {
                lblRazon.Text = "Nombre: ";
                lblApellido.Visible = true;
                textBoxEditApellido.Visible = true;
            }

        }

        private void checkBoxClienteDiplomatico_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCodigo_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
