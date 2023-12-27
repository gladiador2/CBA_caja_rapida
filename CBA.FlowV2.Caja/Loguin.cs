using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CBA.FlowV2.Caja.Notificaciones;

namespace CBA.FlowV2.Caja
{
    
    public partial class Loguin : Form
    {
        
        public Loguin()
        {
            InitializeComponent();
        }

       
        private void Loguear()
        {
            try
            {
               

                 //Context.DeviceIntegrator.Geolocation.GetPosition(GetPosicionHandler);

                 EntidadesService entidad = new EntidadesService();
                SucursalesService sucursal = new SucursalesService();
                string sucursalNombre = string.Empty;

                //Si no se introdujo una sucursal, tomar la sucursal matriz de la primera entidad
                if (sucursalNombre.Length <= 0)
                    sucursalNombre = VariablesSistemaEntidadService.GetValorStringSinSesionWorkaround(Definiciones.VariablesDeSistema.AbreviaturaSucursalPrincipal);

                //construye el service. Si no se especifica la sucursal, hay que cargar una sucursal por default.
                CBA.FlowV2.Services.Sesion.LogueoService logueo = new LogueoService(
                                                textBoxUsuario.Text,
                                                textBoxContrasena.Text,
                                                SessionService.GetClienteIP());
                Hashtable salida = logueo.Loguearse(true, ReglasLoginService.Origen.web);
                
                if (salida["EXITO"].ToString() == Definiciones.SiNo.Si)
                {
                    CajaForm caja = new CajaForm();
                    
                    this.Hide();
                    
                    caja.ShowDialog();
                    
                  
                }
                 
               
                else
                    throw new Exception(salida["MENSAJE"].ToString());
                /*
                //se borran las imagenes temporales del usuario
                Page page = new Page();
                string folder = page.Server.MapPath(@"~/" + "/Resources/Images/") + "tmp\\"; //ruta de las imagenes temporales
                DirectoryInfo dir = new DirectoryInfo(folder);
                if (dir.Exists)
                {
                    foreach (FileInfo fInfo in dir.GetFiles())
                    {
                        if (fInfo.Name.Contains(textBoxUsuario.Text))//solo borrara los archivos con el nombre del usuario
                        {
                            fInfo.Delete();
                        }
                    }
                }*/
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message, Form_Alert.enmType.Error);
                
            }
        }

        private void textBoxContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Loguear();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Loguear();
        }
        /*
        private void textBoxUsuario_Enter(object sender, EventArgs e)
        {
           
            if (textBoxUsuario.Text == "Usuario")
            {
                textBoxUsuario.Text = "";
                textBoxUsuario.ForeColor = System.Drawing.Color.Black; 
            }
        }

        private void textBoxUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUsuario.Text))
            {
                textBoxUsuario.Text = "Usuario";
                textBoxUsuario.ForeColor = System.Drawing.Color.Gray; 
            }
        }

        private void textBoxContrasena_Enter(object sender, EventArgs e)
        {
            if (textBoxContrasena.Text == "Contraseña")
            {
                textBoxContrasena.Text = "";
                textBoxContrasena.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxContrasena_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxContrasena.Text))
            {
                textBoxContrasena.Text = "Contraseña";
                textBoxContrasena.ForeColor = System.Drawing.Color.Gray;
            }
        }
    */
    }
}
