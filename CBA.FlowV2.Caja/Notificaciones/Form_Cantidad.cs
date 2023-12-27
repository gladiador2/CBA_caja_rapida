using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBA.FlowV2.Caja.Notificaciones
{
    public partial class Form_Cantidad : Form
    {
        public Form_Cantidad()
        {
            InitializeComponent();
        }
        public decimal ObtenerCantidad()
        {
            return numericCantidad.Value;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
   
}
