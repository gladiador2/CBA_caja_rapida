using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static CBA.FlowV2.Services.Base.EdiCBA;
using System.Windows.Forms;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using System.Collections;
using CBA.FlowV2.Services.General;

namespace CBA.FlowV2.Caja
{
    
    public class TicketClass
    {
        public Image logotipo { get; set; }
        public decimal vCasoId { get; set; }
        public decimal vPagoId { get; set; }

        protected Hashtable campos = new Hashtable();
        private DataTable dtDetalleFactura;
        private DataTable dtPago;
        private DataTable dtPagoDetalle;
        private DataTable dtAutonumeracion;
        private PrintDocument doc = new PrintDocument();
        private PrintPreviewDialog vista = new PrintPreviewDialog();
       
        public void imprimir(TicketClass p)
        {
            CargarCampos(vCasoId,vPagoId);
            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;
            doc.PrintPage += new PrintPageEventHandler(imprimeticket);
#if DEBUG
            vista.Document = doc;
            vista.Show();
#else  
            doc.Print();
#endif
        }
        private string formatearNumero(object objeto, string cadenaDecimales)
        {
            return Math.Round((decimal)objeto).ToString(cadenaDecimales);
        }
        public void CargarCampos(decimal casoid, decimal vPagoId)
        {

            SessionService sesion = new SessionService();
            //optenemos la factura 
            DataTable dtFactura = FacturasClienteService.GetFacturaClienteInfoCompleta(FacturasClienteService.CasoId_NombreCol + "=" + casoid, string.Empty);
            DataRow drFActura = dtFactura.Rows[0];
            //
            campos.Add(FacturasClienteService.CasoId_NombreCol, drFActura[FacturasClienteService.CasoId_NombreCol]);
            campos.Add(FacturasClienteService.VistaSucursalNombre_NombreCol, drFActura[FacturasClienteService.VistaSucursalNombre_NombreCol]);
            campos.Add(FacturasClienteService.Fecha_NombreCol, drFActura[FacturasClienteService.Fecha_NombreCol]);
            campos.Add(FacturasClienteService.TipoFacturaId_NombreCol, drFActura[FacturasClienteService.TipoFacturaId_NombreCol]);
            campos.Add(FacturasClienteService.VistaNroComprobante_NombreCol, drFActura[FacturasClienteService.VistaNroComprobante_NombreCol]);
            campos.Add(FacturasClienteService.TotalMontoImpuesto_NombreCol, drFActura[FacturasClienteService.TotalMontoImpuesto_NombreCol]);
            campos.Add(FacturasClienteService.TotalNeto_NombreCol, drFActura[FacturasClienteService.TotalNeto_NombreCol]);
            campos.Add(FacturasClienteService.TotalRecargoFinanciero_NombreCol, drFActura[FacturasClienteService.TotalRecargoFinanciero_NombreCol]);
            campos.Add(FacturasClienteService.TotalMontoDto_NombreCol, drFActura[FacturasClienteService.TotalMontoDto_NombreCol]);
            campos.Add(FacturasClienteService.VistaUsuarioAutorizaDescuentoNombre_NombreCol, drFActura[FacturasClienteService.VistaUsuarioAutorizaDescuentoNombre_NombreCol]);
            campos.Add(FacturasClienteService.VistaCondicionPagoDescripcion_NombreCol, drFActura[FacturasClienteService.VistaCondicionPagoDescripcion_NombreCol]);
            campos.Add(FacturasClienteService.SucursalId_NombreCol, drFActura[FacturasClienteService.SucursalId_NombreCol]);

            campos.Add(FacturasClienteService.VistaMonedaSimbolo_NombreCol, drFActura[FacturasClienteService.VistaMonedaSimbolo_NombreCol]);

            campos.Add(FacturasClienteService.VistaPersonaNombre_NombreCol, drFActura[FacturasClienteService.VistaPersonaNombre_NombreCol]);
            campos.Add(FacturasClienteService.VistaPersonaCodigo_NombreCol, drFActura[FacturasClienteService.VistaPersonaCodigo_NombreCol]);
            dtDetalleFactura = FacturasClienteDetalleService.GetFacturaClienteDetalleInfoCompletaStatic((decimal)drFActura[FacturasClienteService.Id_NombreCol]);
            //Se obtiene la cabecera
            dtPago = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + vPagoId, string.Empty);

            //Se asignan los datos la DataTable
            dtPagoDetalle = CuentaCorrientePagosPersonaDetalleService.GetCuentaCorrientePagosPersonaDetalleInfoCompleta(vPagoId);
            //
            dtAutonumeracion = AutonumeracionesService.GetAutonumeracionesInfoCompleta(AutonumeracionesService.Id_NombreCol
                + " = " + drFActura[FacturasClienteService.AutonumeracionId_NombreCol], string.Empty);

        }
        public void imprimeticket(object sender, PrintPageEventArgs e)
        {

            
            try
            {
                int posX, posY; // Variables para controlar la posición de impresión en la página
                Font fuente = new Font("consola", 15, FontStyle.Bold); // Fuente para el texto, inicializada con tamaño 15 y negrita
                string campo = string.Empty;
                posX = 10;
                posY = 10;
                e.Graphics.DrawImage(logotipo, 30, 30, 200, 200); // Dibuja el logotipo en la posición (30, 30) con tamaño 200x200

                posY += 110;
                e.Graphics.DrawString("", fuente, Brushes.Black, posX, posY);
                posY += 20;
                e.Graphics.DrawString("", fuente, Brushes.Black, posX, posY);
                posY += 20;
                e.Graphics.DrawString("", fuente, Brushes.Black, posX, posY);
                posY += 50;
                e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                posY += 20;
                DataRow drAutonumeracion = dtAutonumeracion.Rows[0];
                e.Graphics.DrawString("                     FACTURA", fuente, Brushes.Black, posX, posY);
                posY += 20;
                e.Graphics.DrawString("                     Timbrado N°: " + drAutonumeracion[AutonumeracionesService.NumeroTimbrado_NombreCol].ToString(), fuente, Brushes.Black, posX, posY);
                posY += 20;
                DateTime fecha = (DateTime)drAutonumeracion[AutonumeracionesService.FechaInicio_NombreCol];
                e.Graphics.DrawString("                     Inicio Vigencia: " + fecha.Date.ToString("dd/MM/yyyy"), fuente, Brushes.Black, posX, posY);
                posY += 20;
              
                fecha = (DateTime)drAutonumeracion[AutonumeracionesService.Vencimiento_NombreCol];
                e.Graphics.DrawString("                     Fin Vigencia: " + fecha.Date.ToString("dd/MM/yyyy"), fuente, Brushes.Black, posX, posY);
                posY += 20;
                e.Graphics.DrawString("                     Factura Nº: " + campos[FacturasClienteService.VistaNroComprobante_NombreCol].ToString(), fuente, Brushes.Black, posX, posY);
                posY += 20;
                posY += 20;
                e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                posY += 20;
                e.Graphics.DrawString("Cliente: " + campos[FacturasClienteService.VistaPersonaNombre_NombreCol].ToString(), fuente, Brushes.Black, posX, posY);
                posY += 20;

                campo = campos[FacturasClienteService.VistaPersonaCodigo_NombreCol].ToString() + " - " + TiposDocumentosIdentidadService.GetDigitoVerificadorRUC(campos[FacturasClienteService.VistaPersonaCodigo_NombreCol].ToString()).ToString();
                e.Graphics.DrawString("R.U.C. :" + campo, fuente, Brushes.Black, posX, posY);
                posY += 20;

                e.Graphics.DrawString("Tipo de Factura :" + campos[FacturasClienteService.TipoFacturaId_NombreCol].ToString(), fuente, Brushes.Black, posX, posY);
                posY += 20;

                e.Graphics.DrawString("Emisión :" + campos[FacturasClienteService.Fecha_NombreCol].ToString(), fuente, Brushes.Black, posX, posY);
                posY += 20;


                e.Graphics.DrawString("Sucursal :" + campos[FacturasClienteService.VistaSucursalNombre_NombreCol].ToString(), fuente, Brushes.Black, posX, posY);
                posY += 20;

                e.Graphics.DrawString("Caso Nº :" + campos[FacturasClienteService.CasoId_NombreCol].ToString(), fuente, Brushes.Black, posX, posY);
                posY += 20;

             

                fuente = new Font("consola", 9, FontStyle.Bold);
                e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("CANT.     PRODUCTO              PRECIO     SUBTOTAL ", fuente, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                posY += 25;
                fuente = new Font("consola", 8, FontStyle.Bold);
                /*
                for (int i = 0; i < listaProducto.Count - 1; i++)
                {

                    e.Graphics.DrawString(Convert.ToString(listaProducto[i].producto), fuente, Brushes.Black, posX, posY);
                    posY += 15;
                    e.Graphics.DrawString(Convert.ToString(listaProducto[i].cantidad) + espaciar(listaProducto[i].cantidad.ToString().Length, 18) + "MZ" + espaciar(2, 38) + Convert.ToString(listaProducto[i].precio) + espaciar(listaProducto[i].precio.ToString().Length, 24) + Convert.ToString(listaProducto[i].subtotal), fuente, Brushes.Black, posX, posY);
                    posY += 25;

                }*/
                e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);

                posY += 20;
                e.Graphics.DrawString("                                  TOTAL :  " + "25000", fuente, Brushes.Black, posX, posY);
                posY += 45;

                fuente = new Font("consola", 10, FontStyle.Bold);
                e.Graphics.DrawString("GRACIAS POR SU COMPRA ... ", fuente, Brushes.Black, posX, posY);
                posY += 25;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }


        public string espaciar(int tamaño, int valor)
        {
            string espacio = "";
            int subvalor = 0;
            subvalor = valor - tamaño;

            for (int i = 0; i < subvalor; i++)
            {
                espacio = espacio + " ";
            }

            return espacio;

        }

    }
}
