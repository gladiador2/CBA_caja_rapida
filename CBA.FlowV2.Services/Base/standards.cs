using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CBA.FlowV2.Services.Base
{
    public abstract class standards
    {


        /// <summary>
        /// Función para mostrar un popUp con un mensaje, una duración y un tipo de mensaje.
        /// </summary>
        /// <returns>
        /// un PopUp que te permite seguir utilizando el sistema.
        /// </returns>
        public void MensajeError(string mensaje) 
        {
            MessageBox.Show(
           mensaje,
           "oOp! Algo salio mal",
           MessageBoxButtons.OK,
           MessageBoxIcon.Warning
       );
        }
    }
}
