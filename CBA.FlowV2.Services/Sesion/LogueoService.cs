using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Db.Usuarios;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Net.Http;
using System.Web;

using Microsoft.AspNetCore.Http;
using System.Web.SessionState;

namespace CBA.FlowV2.Services.Sesion
{
    public class LogueoService
    {
        private string _nombreUsuario;
        private string _contrasena;
        private string _IPCliente;

        private string IPCliente
        {
            get { return this._IPCliente; }
            set { this._IPCliente = value; }
        }

        private string nombreUsuario
        {
            get { return this._nombreUsuario; }
            set { this._nombreUsuario = value; }
        }
        private string contrasena
        {
            set { this._contrasena = value; }
            get { return this._contrasena; }
        }

        public LogueoService(string nombre_usuario, string contrasena, string ip)
        {
            this.contrasena = contrasena;
            this.nombreUsuario = nombre_usuario;
            this.IPCliente = ip;
        }

        #region Loguearse
        /// <summary>
        /// Cambia la contrasena. Se asume que los campos son correctos
        /// en el sentido UI -> Service -> BD. 
        /// Las validaciones asumidas son elementales: no pasan de verificar
        /// que las nuevas contrase;as sean identicas al repetirse.
        /// </summary>
        /// <returns></returns>
        public Hashtable Loguearse(bool usando_WebGUI, ReglasLoginService.Origen origen)
        {
            try
            {
                Hashtable mensaje = new Hashtable();  
                bool habilitado = true;
                DataTable dtUsuario;
                string clausulas;
                string sesionId;
                string HostName = SessionService.GethostName();

                // Se busca al usuario por nombre
                clausulas = "lower(" + UsuariosService.Usuario_NombreCol + ") = '" + this.nombreUsuario.ToLower() + "'";
                dtUsuario = UsuariosService.GetUsuarios(clausulas, string.Empty);

                //Si no existe el usuario se registra el intento fallido
                if (dtUsuario.Rows.Count <= 0)
                {
                    Hashtable campos = new Hashtable();
                    campos.Add(LogueoService.Usuario_NombreCol, this.nombreUsuario);
                    campos.Add(LogueoService.Ip_NombreCol, this.IPCliente);
                    campos.Add(LogueoService.Mensaje_NombreCol, Definiciones.Log.LoginFallaUsuarioInexistente);
                    LogueoService.Guardar(campos);

                    habilitado = false;
                }

                if (habilitado)
                    habilitado = ReglasLoginService.Validar((decimal)dtUsuario.Rows[0][UsuariosService.Id_NombreCol], this.nombreUsuario, this.IPCliente, origen);
               
                if (habilitado)
                {
                    Logueo nuevo_logueo = new Logueo(this.nombreUsuario, this.contrasena, this.IPCliente);

                    mensaje = nuevo_logueo.Ejecutar();

                    if (mensaje["EXITO"].ToString() == "S")
                    {
                        if(usando_WebGUI)
                            sesionId = this.AsignarVariablesDeSesion(nuevo_logueo.sesion, nuevo_logueo.id, nuevo_logueo.sucursalId, nuevo_logueo.entidadID, HostName);
                        else 
                            sesionId = this.AsignarVariablesDeSesion(decimal.Parse(nuevo_logueo.id), null);
                            
                        mensaje["SESSION"] = sesionId;
                        mensaje["USUARIO_ID"] = dtUsuario.Rows[0][UsuariosService.Id_NombreCol];
                    }
                }

                if (!habilitado)
                {
                    mensaje["EXITO"] = "NO";
                    mensaje["MENSAJE"] = "No puede iniciar sesión.";
                }

                return mensaje;
            }
            catch (System.Exception exp)
            {
                //TODO manejar las excepcionies. Si el mensaje indica cambio de contrasena hay que manejarlo.
                throw exp;
            }
        }
        #endregion

        #region AsignarVariablesDeSesion
        private string AsignarVariablesDeSesion(string sesion, string id_usuario, string sucursal_id, string entidad_id, string HostName)//OracleParameterCollection parametros)
        {


            ApplicationContext.Session.Add("user" , this.nombreUsuario);
            ApplicationContext.Session["sesionID"] = sesion;// parametros["SESION"].Value.ToString();// !Convert.IsDBNull(parametros["SESION"].Value) ? ((Int32)parametros["SESION"].Value).ToString().Trim() : "";            
            ApplicationContext.Session["usuarioID"] = id_usuario;// parametros["ID"].Value.ToString();// !Convert.IsDBNull(parametros["ID"].Value) ? ((Int32)parametros["ID"].Value).ToString().Trim() : "";            
            ApplicationContext.Session["userIPAddress"] = this.IPCliente;
            ApplicationContext.Session["sucursalID"] = sucursal_id;//parametros["SUCURSAL_ID"].Value.ToString();//!Convert.IsDBNull(parametros["SUCURSAL_ID"].Value) ? ((Int32)parametros["SUCURSAL_ID"].Value).ToString().Trim() : "";
            ApplicationContext.Session["entidadID"] = entidad_id;// parametros["ENTIDAD_ID"].Value.ToString();//!Convert.IsDBNull(parametros["ENTIDAD_ID"].Value) ? ((Int32)parametros["ENTIDAD_ID"].Value).ToString().Trim() : "";            
            ApplicationContext.Session["hostName"] = HostName;
            if (!string.IsNullOrEmpty(ApplicationContext.Session["entidadID"].ToString()) && !ApplicationContext.Session["entidadID"].ToString().Equals("null"))
                ApplicationContext.Session["nombreEntidad"] = SessionService.GetNombreEntidad(Convert.ToDecimal(entidad_id));//parametros["ENTIDAD_ID"].Value.ToString()));
            else
                ApplicationContext.Session["nombreEntidad"] = "";

            if (ApplicationContext.Session["sucursalID"].ToString().Equals(""))
                ApplicationContext.Session["sucursalID"] = "0";

            if (!string.IsNullOrEmpty(ApplicationContext.Session["usuarioID"].ToString()) && !ApplicationContext.Session["usuarioID"].ToString().Equals("null"))
            {
                decimal auxDecimal;
                UsuariosService usuario = new UsuariosService();
                DataRow datosUsuario = usuario.GetUsuarioDataRow(decimal.Parse(ApplicationContext.Session["usuarioID"].ToString()));
                ApplicationContext.Session["nombreUsuario"] = datosUsuario[UsuariosService.Usuario_NombreCol];

                //Si el usuario tiene una persona asociada, se carga a la variable de sesion
                if (decimal.TryParse(datosUsuario[UsuariosService.PersonaId_NombreCol].ToString(), out auxDecimal))
                    ApplicationContext.Session["personaId"] = auxDecimal;
                else ApplicationContext.Session["personaId"] = Definiciones.Error.Valor.EnteroPositivo;

                //Si el usuario tiene una persona asociada, se carga a la variable de sesion
                if (decimal.TryParse(datosUsuario[UsuariosService.FuncionarioId_NombreCol].ToString(), out auxDecimal))
                    ApplicationContext.Session["funcionarioId"] = auxDecimal;
                else ApplicationContext.Session["funcionarioId"] = Definiciones.Error.Valor.EnteroPositivo;
            }

            if (!string.IsNullOrEmpty(ApplicationContext.Session["usuarioID"].ToString())
                && !ApplicationContext.Session["usuarioID"].ToString().Equals("null")
                 && !string.IsNullOrEmpty(ApplicationContext.Session["entidadID"].ToString())
                  && !ApplicationContext.Session["entidadID"].ToString().Equals("null")
                )
                
            SessionService.InicializarVariables(Convert.ToDecimal(ApplicationContext.Session["usuarioID"]), Convert.ToDecimal(ApplicationContext.Session["entidadID"]));
            
            #region Almacenar si tiene roles en particular
            ApplicationContext.Session["permisoPuedeVerCasosTodasSucursales"] = RolesService.Tiene("USUARIO PUEDE VER CASOS TODAS SUCURSALES");
            ApplicationContext.Session["permisoPuedeVerCasosAjenos"] = RolesService.Tiene("USUARIO PUEDE VER CASOS AJENOS");
            #endregion Almacenar si tiene roles en particular
            
            return sesion;

        }

        public void AsignarVariablesDeSesion()
        {
            this.AsignarVariablesDeSesion(Definiciones.Usuarios.Soporte, null);
        }

        public void AsignarVariablesDeSesion(decimal usuario_id)
        {
            this.AsignarVariablesDeSesion(usuario_id, null);
        }

        public string AsignarVariablesDeSesion(decimal usuario_id, System.Web.HttpContext context)
        {
            //Si es null es porque no es una llamada originada en un request web
            //sino que fue lanzado como una llamada asincrona a un metodo y debe falsearse
            if (System.Web.HttpContext.Current == null && context != null)
            {

                System.Web.HttpContext.Current = new System.Web.HttpContext(context.Request, context.Response);
                System.Web.HttpContext.Current.User = context.User;

                HttpSessionStateContainer sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                                            new HttpStaticObjectsCollection(), 10, true,
                                            HttpCookieMode.AutoDetect,
                                            SessionStateMode.InProc, false);

                SessionStateUtility.AddHttpSessionStateToContext(System.Web.HttpContext.Current, sessionContainer);
            }

            //Se instancia db para no utilizar SessionService
            CBAV2 db = new CBAV2();
            DataTable dtUsuario = db.USUARIOSCollection.GetAsDataTable(UsuariosService.Id_NombreCol + " = " + decimal.ToInt16(usuario_id), string.Empty);
            DataTable dtSucursales = db.SUCURSALESCollection.GetAsDataTable(SucursalesService.Id_NombreCol + " = " + dtUsuario.Rows[0][UsuariosService.SucursalActivaId_NombreCol], string.Empty);
            string sesionId = string.Empty;

            System.Web.HttpContext.Current.Session["user"] = dtUsuario.Rows[0][UsuariosService.Usuario_NombreCol];
            System.Web.HttpContext.Current.Session["sesionID"] = dtUsuario.Rows[0][UsuariosService.Sesion_NombreCol];
            System.Web.HttpContext.Current.Session["usuarioID"] = dtUsuario.Rows[0][UsuariosService.Id_NombreCol];
            System.Web.HttpContext.Current.Session["userIPAddress"] = SessionService.GetClienteIP();

            System.Web.HttpContext.Current.Session["sucursalID"] = dtSucursales.Rows[0][SucursalesService.Id_NombreCol];
            System.Web.HttpContext.Current.Session["entidadID"] = dtSucursales.Rows[0][SucursalesService.EntidadId_NombreCol];

            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["entidadID"].ToString()) && !System.Web.HttpContext.Current.Session["entidadID"].ToString().Equals("null"))
                System.Web.HttpContext.Current.Session["nombreEntidad"] = SessionService.GetNombreEntidad((decimal)dtSucursales.Rows[0][SucursalesService.EntidadId_NombreCol]);
            else
                System.Web.HttpContext.Current.Session["nombreEntidad"] = "";

            if (System.Web.HttpContext.Current.Session["sucursalID"].ToString().Equals(""))
                System.Web.HttpContext.Current.Session["sucursalID"] = "0";

            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["usuarioID"].ToString()) && !System.Web.HttpContext.Current.Session["usuarioID"].ToString().Equals("null"))
            {
                decimal auxDecimal;
                UsuariosService usuario = new UsuariosService();
                System.Web.HttpContext.Current.Session["nombreUsuario"] = dtUsuario.Rows[0][UsuariosService.Usuario_NombreCol];

                //Si el usuario tiene una persona asociada, se carga a la variable de sesion
                if (decimal.TryParse(dtUsuario.Rows[0][UsuariosService.PersonaId_NombreCol].ToString(), out auxDecimal))
                    System.Web.HttpContext.Current.Session["personaId"] = auxDecimal;
                else System.Web.HttpContext.Current.Session["personaId"] = Definiciones.Error.Valor.EnteroPositivo;

                //Si el usuario tiene una persona asociada, se carga a la variable de sesion
                if (decimal.TryParse(dtUsuario.Rows[0][UsuariosService.FuncionarioId_NombreCol].ToString(), out auxDecimal))
                    System.Web.HttpContext.Current.Session["funcionarioId"] = auxDecimal;
                else System.Web.HttpContext.Current.Session["funcionarioId"] = Definiciones.Error.Valor.EnteroPositivo;
            }

            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["usuarioID"].ToString())
                && !System.Web.HttpContext.Current.Session["usuarioID"].ToString().Equals("null")
                && !string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["entidadID"].ToString())
                && !System.Web.HttpContext.Current.Session["entidadID"].ToString().Equals("null"))
            {
                SessionService.InicializarVariables(Convert.ToDecimal(System.Web.HttpContext.Current.Session["usuarioID"]), Convert.ToDecimal(System.Web.HttpContext.Current.Session["entidadID"]));
            }

            #region Almacenar si tiene roles en particular
            System.Web.HttpContext.Current.Session["permisoPuedeVerCasosTodasSucursales"] = RolesService.Tiene("USUARIO PUEDE VER CASOS TODAS SUCURSALES");
            System.Web.HttpContext.Current.Session["permisoPuedeVerCasosAjenos"] = RolesService.Tiene("USUARIO PUEDE VER CASOS AJENOS");
            #endregion Almacenar si tiene roles en particular

            return System.Web.HttpContext.Current.Session["sesionID"].ToString();
        }
        #endregion AsignarVariablesDeSesion

        #region Guardar
        /// <summary>
        /// Hace un insert del registro (autenticacion rechazada)
        /// </summary>
        /// <param name="campos">Campos del registro.</param>
        public static void Guardar(System.Collections.Hashtable campos) 
        {
            using (SessionService sesion = new SessionService())
            {
                try 
                {
                    LOG_SESIONESRow row = new LOG_SESIONESRow();
                    
                    row.ID = sesion.Db.GetSiguienteSecuencia("log_sesiones_sqc");
                    row.USUARIO = (string)campos[LogueoService.Usuario_NombreCol];
                    row.SUCURSAL = string.Empty;
                    row.IsENTIDAD_IDNull = true;
                    row.EXTERNO = string.Empty; 
                    row.FECHA_INTENTO = DateTime.Now;
                    row.IP = (string)campos[LogueoService.Ip_NombreCol];
                    row.EXITO = Definiciones.SiNo.No;
                    row.NRO_SESION = "0";
                    row.MENSAJE = (string)campos[LogueoService.Mensaje_NombreCol];
                    row.EVENTO = "LOGUEO";
                    
                    // Se registra en log_sesiones el intento de autenticacion fallido 
                    sesion.Db.LOG_SESIONESCollection.Insert(row);
                }
                catch (System.Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Accessors
        public static string Secuencia
        { get { return "LOG_SESIONES_SQC"; } }
        public static string Nombre_Tabla
        { get { return "LOG_SESIONES"; } }
        public static string Id_NombreCol
        { get { return LOG_SESIONESCollection.IDColumnName;  } }
        public static string Usuario_NombreCol
        { get { return LOG_SESIONESCollection.USUARIOColumnName;  } }
        public static string Sucursal_NombreCol
        { get { return LOG_SESIONESCollection.SUCURSALColumnName;  } }
        public static string EntidadId_NombreCol
        { get { return LOG_SESIONESCollection.ENTIDAD_IDColumnName;  } }
        public static string Externo_NombreCol
        { get { return LOG_SESIONESCollection.EXTERNOColumnName;  } }
        public static string FechaIntento_NombreCol
        { get { return LOG_SESIONESCollection.FECHA_INTENTOColumnName;  } }
        public static string Ip_NombreCol
        { get { return LOG_SESIONESCollection.IPColumnName;  } }
        public static string Exito_NombreCol
        { get { return LOG_SESIONESCollection.EXITOColumnName;  } }
        public static string NroSesion_NombreCol
        { get { return LOG_SESIONESCollection.NRO_SESIONColumnName;  } }
        public static string Mensaje_NombreCol
        { get { return LOG_SESIONESCollection.MENSAJEColumnName;  } }
        public static string Evento_NombreCol
        { get { return LOG_SESIONESCollection.EVENTOColumnName;  } }
        #endregion Accessors
    }
}
