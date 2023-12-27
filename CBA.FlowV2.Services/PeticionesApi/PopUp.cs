using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBA.FlowV2.Services.PeticionesApi
{
    public class PopUp
    {
        // Constructor vacío
        public PopUp()
        {
        }
        // Crear una clase estática con constantes para los tipos de mensaje
        public static class TipoMensaje
        {
            public const string Error = "error";
            public const string Informacion = "informacion";
            public const string Exito = "exito";
        }


        /// <summary>
        /// Función para mostrar un popUp con un mensaje, una duración y un tipo de mensaje.
        /// </summary>
        /// <returns>
        /// un PopUp que te permite seguir utilizando el sistema.
        /// </returns>
        public void mostrarPopUP(string mensaje, int duracion, string tipo)
        {
            // Crear un nuevo formulario
            Form popUp = new Form();
            // Establecer el tamaño del formulario
            popUp.Size = new System.Drawing.Size(400, 100);
            // Establecer el título del formulario
            popUp.Text = "PopUp";
            // Establecer el estilo del formulario para que no tenga bordes ni botones
            popUp.FormBorderStyle = FormBorderStyle.None;

            // Obtener el monitor donde se encuentra el cursor
            Screen screen = Screen.FromPoint(Cursor.Position);
            // Obtener el tamaño del monitor
            Rectangle screenSize = screen.WorkingArea;
            // Obtener la escala del monitor
            float scale = screen.Bounds.Width / (float)screen.WorkingArea.Width;
            // Establecer la posición del formulario en la esquina superior derecha del monitor ajustando la escala
            popUp.Location = new Point((int)((screenSize.Right - popUp.Width) * scale), (int)(screenSize.Top * scale));

            // Crear una nueva etiqueta
            Label label = new Label();
            // Establecer el texto de la etiqueta con el mensaje recibido
            label.Text = mensaje;
            // Establecer el tamaño de la etiqueta para que ocupe todo el formulario menos un margen de 50 píxeles a la izquierda
            label.Size = new Size(popUp.ClientSize.Width - 50, popUp.ClientSize.Height);
            // Establecer la posición de la etiqueta a 50 píxeles a la derecha del borde izquierdo del formulario
            label.Location = new Point(50, 0);
            // Establecer la alineación del texto de la etiqueta en el centro
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Establecer la fuente de la etiqueta con un tamaño mayor al predeterminado
            label.Font = new Font(label.Font.FontFamily, 16);

            // Añadir la etiqueta al formulario
            popUp.Controls.Add(label);

            // Según el tipo de mensaje recibido, establecer el color de fondo del formulario y la etiqueta y crear un icono adecuado
            Icon icono;
            switch (tipo)
            {
                case TipoMensaje.Error:
                    popUp.BackColor = Color.Red;
                    label.ForeColor = Color.Black;
                    popUp.ForeColor = Color.Red;
                    // label.BackColor = Color.Black;
                    icono = SystemIcons.Error;
                    break;
                case TipoMensaje.Informacion:
                    popUp.BackColor = Color.Yellow;
                    label.BackColor = Color.Yellow;
                    icono = SystemIcons.Information;
                    break;
                case TipoMensaje.Exito:
                    popUp.BackColor = Color.Lime;
                    label.BackColor = Color.Lime;
                    icono = SystemIcons.Shield;
                    break;
                default:
                    popUp.BackColor = Color.White;
                    label.BackColor = Color.White;
                    icono = SystemIcons.Question;
                    break;
            }

            // Crear un nuevo control PictureBox para mostrar el icono
            PictureBox pictureBox = new PictureBox();
            // Establecer el tamaño del control PictureBox al mismo que el tamaño del icono
            pictureBox.Size = icono.Size;
            // Establecer la posición del control PictureBox a 10 píxeles del borde izquierdo y superior del formulario
            pictureBox.Location = new Point(10, 10);
            // Establecer la imagen del control PictureBox con el icono creado
            pictureBox.Image = icono.ToBitmap();

            // Añadir el control PictureBox al formulario
            popUp.Controls.Add(pictureBox);

            // Establecer la opacidad del formulario a un valor menor que 1 para que sea transparente
            popUp.Opacity = 0.1;

            // Mostrar el formulario
            popUp.Show();
            // Crear un temporizador
            Timer timer = new Timer();
            // Establecer el intervalo del temporizador con la duración recibida en milisegundos
            timer.Interval = duracion;
            // Establecer el evento Tick del temporizador para que cierre el formulario y se detenga
            timer.Tick += (sender, e) =>
            {
                popUp.Close();
                timer.Stop();
            };
            // Iniciar el temporizador
            timer.Start();
        }
    }
}
