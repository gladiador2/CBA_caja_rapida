using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace CBA.FlowV2.Services.Base
{
    public class MensajeExterno
    {
        public string mensaje;
        public string html;
        public int ancho = 150; //De la ventana que contiene el mensaje
        public int alto = 50; //De la ventana que contiene el mensaje
        public string uriImagenRecibo; //Si se quiere poner una imagen en el recibo
    }
}
