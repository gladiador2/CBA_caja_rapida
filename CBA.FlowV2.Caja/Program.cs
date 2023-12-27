using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CBA.FlowV2.Caja.Notificaciones;
using CBA.FlowV2.Services;
using ApplicationContext = CBA.FlowV2.Services.ApplicationContext;

namespace CBA.FlowV2.Caja
{
    public static class Alert
    {
        
        public static void Show(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
    }
    
    static class Program
    {
       
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Loguin());
        }
    }
}
