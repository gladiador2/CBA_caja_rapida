using CBA.FlowV2.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static CBA.FlowV2.Services.Base.EdiCBA;

namespace CBA.FlowV2.Services.PeticionesApi
{
    public class ValidarPeticion
    {
        PopUp popUp = new PopUp();
        public async Task<JsonNode> requestWithPromise(string jsonData, string urlApi)
        {
            try
            {
                // Crear el contenido de la solicitud con el tipo de datos adecuado
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var client = new HttpClient();

                var responseTask = client.PostAsync(ConstantesApp.URL_API + urlApi, content);
                if (await Task.WhenAny(responseTask, Task.Delay(ConstantesApp.TIEMPO_ESPERA)) == responseTask)
                {
                    var response = await responseTask;
                    // Verificar si la respuesta fue exitosa
                    if (response.IsSuccessStatusCode)
                    {

                        var responseBody = await response.Content.ReadAsStringAsync();
                        //doc Json
                        JsonDocument doc = JsonDocument.Parse(responseBody);

                        //NOdo raiz
                        JsonNode nodos = JsonNode.Parse(responseBody);
                        // Obtener la raíz del documento JSON
                        JsonElement root = doc.RootElement;

                        //mensaje de error
                        string mensaje = string.Empty;
                        if (doc.RootElement.TryGetProperty(ConstantesApp.EstructuraJSON.Nodos.mensaje, out _))
                            mensaje = root.GetProperty(ConstantesApp.EstructuraJSON.Nodos.mensaje).GetString();
                        //Existe error
                        string error = string.Empty;
                        if (doc.RootElement.TryGetProperty(ConstantesApp.EstructuraJSON.Nodos.error, out _))
                            error = root.GetProperty(ConstantesApp.EstructuraJSON.Nodos.error).GetString();
                        Int64 codigo = 0;
                        if (doc.RootElement.TryGetProperty(ConstantesApp.EstructuraJSON.Nodos.codigo, out _))
                            codigo = root.GetProperty(ConstantesApp.EstructuraJSON.Nodos.codigo).GetInt64();

                        if (doc.RootElement.TryGetProperty(ConstantesApp.EstructuraJSON.Nodos.datos, out _))
                        {
                            JsonNode datos = nodos[ConstantesApp.EstructuraJSON.Nodos.datos];
                            return datos;
                        }
                        else
                        {
                            if (mensaje != string.Empty && error == Definiciones.SiNo.No)
                            {
                                popUp.mostrarPopUP(mensaje, 5000, PopUp.TipoMensaje.Exito);
                                return null;
                            }
                            if (mensaje != string.Empty && error == Definiciones.SiNo.Si)
                            {
                                popUp.mostrarPopUP(mensaje, 5000, PopUp.TipoMensaje.Error);
                                
                                //440 session finalizada
                                //461 session invalida
                                if (codigo == ConstantesApp.ExcepcionesRestError.NO_AUTENTICADO
                                    || codigo == ConstantesApp.ExcepcionesRestError.TOKEN_INVALIDO
                                    || codigo == ConstantesApp.ExcepcionesRestError.TOKEN_EXPIRADO
                                    || codigo == ConstantesApp.ExcepcionesRestError.TOKEN_REQUERIDO)
                                {
                                    
                                }
                                return null;
                            }
                            return null;
                        }
                    }
                    else
                    {
                        // Mostrar mensaje de error en un DisplayAlert
                        popUp.mostrarPopUP("\r\n¡Oops! Parece que algo inesperado ocurrió en el sistema. Nuestro equipo de expertos en solución de problemas ya está en ello. Mientras tanto, relájate y disfruta de un breve momento de calma. Todo estará en orden pronto. 😊🔧", 5000, PopUp.TipoMensaje.Error);
                        return null;
                    }
                }
                else
                {

                    popUp.mostrarPopUP("¡Espera un segundito mientras ponemos el turbo a nuestras operaciones! 🚀⏳", 5000, PopUp.TipoMensaje.Exito);


                    return null;
                }

            }
            catch (Exception ex)
            {

                popUp.mostrarPopUP(ex.Message, 5000, PopUp.TipoMensaje.Error);
                return null;
            }
        }
    }
}
