using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net;
using System.Windows.Forms;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Web.SessionState;
using System.Web;
using FB = CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Sesion
{
    public class SessionService : IDisposable
    {
        protected USUARIOSRow mUsuario;
        protected ENTIDADESRow mEntidadActual;
        protected SUCURSALESRow mSucursalActiva;
        protected System.Windows.Forms.Form mVentanaPrincipal;
        protected System.Windows.Forms.Panel mPanelListaCasos;
        protected bool mPermisoPuedeVerCasosTodasSucursales;
        protected bool mPermisoPuedeVerCasosAjenos;
        protected decimal redondeo;
        protected decimal costo; //TODO Uri: estudiar si se puede borrar
        protected MONEDASRow[] monedas;
        protected List<string> lRoles;

        //Modificado para que pueda pasarse como parametro;
        public CBAV2 db;

       

        #region InicializarVariables
        public static void InicializarVariables(decimal usuarioId, decimal entidadId)
        {
            using (CBAV2 db = new CBAV2())
            {
                USUARIOSRow usu = db.USUARIOSCollection.GetByPrimaryKey(usuarioId);
                string clausulas = string.Empty;

                //Segun haya un usuario logueado al sistema en forma habitual o
                //la ejecucion provenga de un webservice
                if (ApplicationContext.Instance != null)
                {
                    
                    ApplicationContext.Session["usuarioRow"] = usu;
                    ApplicationContext.Session["entidadActualRow"] = db.ENTIDADESCollection.GetByPrimaryKey(entidadId);
                    ApplicationContext.Session["sucursalRow"] = db.SUCURSALESCollection.GetByPrimaryKey(usu.SUCURSAL_ACTIVA_ID);
                    ApplicationContext.Session["sucursalID"] = usu.SUCURSAL_ACTIVA_ID;
                    ApplicationContext.Session["ventanaPrincipal"] = null;
                    ApplicationContext.Session["panelListaCasos"] = null;
                    ApplicationContext.Session["permisoPuedeVerCasosTodasSucursales"] = false;
                    ApplicationContext.Session["permisoPuedeVerCasosAjenos"] = false;

                    clausulas = UsuariosRolesService.UsuarioId_NombreCol + " = " + usuarioId + 
                                " and (" + UsuariosRolesService.FechaCaducidad_NombreCol + " is null or trunc(" + UsuariosRolesService.FechaCaducidad_NombreCol + ") >= to_date('" + DateTime.Now.ToShortDateString() + "', 'dd/mm/yyyy'))";
                    DataTable dtRoles = db.USUARIOS_ROLES_INFO_COMPLETACollection.GetAsDataTable(clausulas, string.Empty);
                    List<string> lRoles = new List<string>();
                    for (int i = 0; i < dtRoles.Rows.Count; i++)
                        lRoles.Add(((string)dtRoles.Rows[i][UsuariosRolesService.VistaRolDescripcion_NombreCol]).ToUpper());
                    ApplicationContext.Session["roles"] = lRoles;
                }
                else if (ApplicationContext.Session["user"] != null)
                {
                    ApplicationContext.Session["usuarioRow"] = usu;
                    ApplicationContext.Session["entidadActualRow"] = db.ENTIDADESCollection.GetByPrimaryKey(entidadId);
                    ApplicationContext.Session["sucursalRow"] = db.SUCURSALESCollection.GetByPrimaryKey(usu.SUCURSAL_ACTIVA_ID);
                    ApplicationContext.Session["sucursalID"] = usu.SUCURSAL_ACTIVA_ID;
                    ApplicationContext.Session["ventanaPrincipal"] = null;
                    ApplicationContext.Session["panelListaCasos"] = null;
                    ApplicationContext.Session["permisoPuedeVerCasosTodasSucursales"] = false;
                    ApplicationContext.Session["permisoPuedeVerCasosAjenos"] = false;

                    clausulas = UsuariosRolesService.UsuarioId_NombreCol + " = " + usuarioId +
                                " and (" + UsuariosRolesService.FechaCaducidad_NombreCol + " is null or trunc(" + UsuariosRolesService.FechaCaducidad_NombreCol + ") >= to_date('" + DateTime.Now.ToShortDateString() + "', 'dd/mm/yyyy'))";
                    DataTable dtRoles = db.USUARIOS_ROLES_INFO_COMPLETACollection.GetAsDataTable(clausulas, string.Empty);
                    List<string> lRoles = new List<string>();
                    for (int i = 0; i < dtRoles.Rows.Count; i++)
                        lRoles.Add(((string)dtRoles.Rows[i][UsuariosRolesService.VistaRolDescripcion_NombreCol]).ToUpper());
                    ApplicationContext.Session["roles"] = lRoles;
                }
                else
                {
                    throw new Exception("No existen datos de sesión.");
                }

                //Se controla el permiso de si puede ver los casos de todas las sucursales
                string descripcion = "USUARIO PUEDE VER CASOS TODAS SUCURSALES";

                ROLESRow rolesRow = db.ROLESCollection.GetRow(RolesService.EntidadID_NombreCol + " = " + entidadId + " and upper(" + RolesService.Descripcion_NombreCol + ") = '" + descripcion.ToUpper() + "'");
                bool tieneRol = false;
                if (rolesRow != null)
                {
                    clausulas = UsuariosRolesService.UsuarioId_NombreCol + " = " + usuarioId +
                                " and (" + UsuariosRolesService.FechaCaducidad_NombreCol + " is null or trunc(" + UsuariosRolesService.FechaCaducidad_NombreCol + ") >= to_date('" + DateTime.Now.ToShortDateString() + "', 'dd/mm/yyyy'))" +
                                " and " + UsuariosRolesService.RolId_NombreCol + " = " + rolesRow.ID;
                    USUARIOS_ROLESRow permiso = db.USUARIOS_ROLESCollection.GetRow(clausulas);
                    tieneRol = permiso == null ? false : true;
                }

                //Segun haya un usuario logueado al sistema en forma habitual o
                //la ejecucion provenga de un webservice
                if(ApplicationContext.Session != null)
                    ApplicationContext.Session["permisoPuedeVerCasosTodasSucursales"] = tieneRol;
                else
                    ApplicationContext.Session["permisoPuedeVerCasosTodasSucursales"] = tieneRol;

                //Se controla el permiso de si puede ver los casos ajenos.
                descripcion = "USUARIO PUEDE VER CASOS AJENOS";
                
                tieneRol = false;
                rolesRow = db.ROLESCollection.GetRow(RolesService.EntidadID_NombreCol + " = " + entidadId + " and upper(" + RolesService.Descripcion_NombreCol + ") = '" + descripcion.ToUpper() + "'");
                if (rolesRow != null)
                {
                    clausulas = UsuariosRolesService.UsuarioId_NombreCol + " = " + usuarioId +
                                " and (" + UsuariosRolesService.FechaCaducidad_NombreCol + " is null or trunc(" + UsuariosRolesService.FechaCaducidad_NombreCol + ") >= to_date('" + DateTime.Now.ToShortDateString() + "', 'dd/mm/yyyy'))" +
                                " and " + UsuariosRolesService.RolId_NombreCol + " = " + rolesRow.ID;
                    USUARIOS_ROLESRow permiso = db.USUARIOS_ROLESCollection.GetRow(clausulas);
                    tieneRol = permiso == null ? false : true;
                }

                string clausulasVariableRedondeo = VariablesSistemaEntidadService.EntidadId_NombreCol + " = " + entidadId + " and " +
                                                   VariablesSistemaEntidadService.VariableSistemaId_NombreCol + " = " + Definiciones.VariablesDeSistema.TipoDeRedondeo;


                string clausulasVariableCosto = VariablesSistemaEntidadService.EntidadId_NombreCol + " = " + entidadId + " and " +
                                                VariablesSistemaEntidadService.VariableSistemaId_NombreCol + " = " + Definiciones.VariablesDeSistema.TipoCosto;

                //Segun haya un usuario logueado al sistema en forma habitual o
                //la ejecucion provenga de un webservice
                if (ApplicationContext.Instance != null)
                {
                    ApplicationContext.Session["permisoPuedeVerCasosAjenos"] = tieneRol;
                    ApplicationContext.Session["redondeo"] = db.VARIABLES_SISTEMA_ENTIDADCollection.GetRow(clausulasVariableRedondeo).VALOR;
                    ApplicationContext.Session["monedas"] = db.MONEDASCollection.GetAsArray("1=1", string.Empty);
                    ApplicationContext.Session["costo"] = db.VARIABLES_SISTEMA_ENTIDADCollection.GetRow(clausulasVariableCosto).VALOR;
                }
                else
                {
                    ApplicationContext.Session["permisoPuedeVerCasosAjenos"] = tieneRol;
                    ApplicationContext.Session["redondeo"] = db.VARIABLES_SISTEMA_ENTIDADCollection.GetRow(clausulasVariableRedondeo).VALOR;
                    ApplicationContext.Session["monedas"] = db.MONEDASCollection.GetAsArray("1=1", string.Empty);
                    ApplicationContext.Session["costo"] = db.VARIABLES_SISTEMA_ENTIDADCollection.GetRow(clausulasVariableCosto).VALOR;
                }
            }
        }
        #endregion InicializarVariables

        #region GetClienteIP
        public static string GetClienteIP()
        {
            try
            {
                string hostName = Dns.GetHostName();
                IPAddress[] addresses = Dns.GetHostAddresses(hostName);
                string ip= string.Empty;
                // Mostrar la dirección IP en el cuadro de texto
                foreach (IPAddress address in addresses)
                {
                    if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) // Filtrar direcciones IPv4
                    {
                        ip = address.ToString();
                       
                    }
                }
                return ip;
            }
            catch
            {
                return "127.0.0.1";
            }
        }
        #endregion GetClienteIP

        #region GetHostName
        public static string GethostName()
        {
            try
            {
                string HostName = System.Net.Dns.GetHostName();
               
                return HostName;
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion GetHostName

        #region Constructor
        public SessionService() : this(false){}
        public SessionService(bool usar_cuenta_soporte)
        {
            if (!usar_cuenta_soporte)
            {
                if (ApplicationContext.Session == null)
                {
                    this.mUsuario = null;
                    this.mSucursalActiva = null;
                    this.mEntidadActual = null;
                    this.mVentanaPrincipal = null;
                    this.mPanelListaCasos = null;
                    this.monedas = null;
                    this.lRoles = null;
                }
                else if (ApplicationContext.Session != null)
                {
                    this.mUsuario = ApplicationContext.Session["usuarioRow"] as USUARIOSRow;
                    this.mSucursalActiva = ApplicationContext.Session["sucursalRow"] as SUCURSALESRow;
                    this.mEntidadActual = ApplicationContext.Session["entidadActualRow"] as ENTIDADESRow;
                    this.mVentanaPrincipal = ApplicationContext.Session["ventanaPrincipal"] as System.Windows.Forms.Form;
                    this.mPanelListaCasos = ApplicationContext.Session["panelListaCasos"] as System.Windows.Forms.Panel;

                    if (ApplicationContext.Session["permisoPuedeVerCasosTodasSucursales"] != null)
                        this.mPermisoPuedeVerCasosTodasSucursales = (bool)ApplicationContext.Session["permisoPuedeVerCasosTodasSucursales"];
                    if (ApplicationContext.Session["permisoPuedeVerCasosAjenos"] != null)
                        this.mPermisoPuedeVerCasosAjenos = (bool)ApplicationContext.Session["permisoPuedeVerCasosAjenos"];

                    if (ApplicationContext.Session["redondeo"] != null)
                        this.redondeo = decimal.Parse(ApplicationContext.Session["redondeo"].ToString());
                    if (ApplicationContext.Session["costo"] != null)
                        this.costo = decimal.Parse(ApplicationContext.Session["costo"].ToString());

                    this.monedas = ApplicationContext.Session["monedas"] as MONEDASRow[];
                    this.lRoles = ApplicationContext.Session["roles"] as List<string>;
                }
               
                this.db = new CBAV2();
            }
        }
        #endregion Constructor

        #region IDisposable Members
        public void Dispose()
        {
            if (this.db != null)
                this.db.Dispose();
        }
        #endregion

        #region Propiedades
        public CBAV2 Db
        {
            get { return this.db; }
        }

        public USUARIOSRow Usuario
        {
            get { return this.mUsuario; }
        }

        public SUCURSALESRow SucursalActiva
        {
            get { return this.mSucursalActiva; }
        }

        public Decimal SucursalActiva_pais_id
        {
            get { return this.mSucursalActiva.PAIS_ID; }
        }

        public ENTIDADESRow Entidad
        {
            get { return this.mEntidadActual; }
        }
        public bool permisoPuedeVerCasosTodasSucursales
        {
            get { return this.mPermisoPuedeVerCasosTodasSucursales; }
        }
        public bool permisoPuedeVerCasosAjenos
        {
            get { return this.mPermisoPuedeVerCasosAjenos; }
        }
        public List<string> Roles
        {
            get { return this.lRoles; }
        }
        #endregion Propiedades

        #region Usuarios
        // Usuarios
        public string Usuario_Nombre
        {
            get { return this.mUsuario.NOMBRE + " " + this.mUsuario.APELLIDO; }
        }

        public decimal Usuario_Funcionario_id
        {
            get 
            {
                if (this.mUsuario.IsFUNCIONARIO_IDNull) return Definiciones.IdNull;
                else return this.mUsuario.FUNCIONARIO_ID; 
            }
        }

        public decimal Usuario_Persona_id
        {
            get
            {
                if (this.mUsuario.IsPERSONA_IDNull) return Definiciones.IdNull;
                else return this.mUsuario.PERSONA_ID;
            }
        }

        public decimal Usuario_Id
        {
            get { return this.mUsuario.ID; }
            set
            {
                // Si el valor del ID nuevo es diferente del actual
                if (this.mUsuario == null || !this.mUsuario.ID.ToString().Equals(value))
                {
                    this.mUsuario = db.USUARIOSCollection.GetByPrimaryKey(value);
                    ApplicationContext.Session["usuarioRow"] = this.mUsuario;
                }
            }
        }
        #endregion Usuarios

        #region Objetos Visuales
        public System.Windows.Forms.Form VentanaPrincipal
        {
            get { return this.mVentanaPrincipal; }
            set { ApplicationContext.Session["ventanaPrincipal"] = value; }
        }

        public System.Windows.Forms.Panel PanelListaCasos
        {
            get { return this.mPanelListaCasos; }
            set { ApplicationContext.Session["panelListaCasos"] = value; }
        }
        #endregion Objetos Visuales

        #region Entidades
        // Entidades
        public string EntidadActual_Id
        {
            get { return this.mEntidadActual.ID.ToString(); }
            set
            {
                if (this.mEntidadActual == null || !this.mEntidadActual.ID.ToString().Equals(value))
                {
                    this.mEntidadActual = db.ENTIDADESCollection.GetByPrimaryKey(decimal.Parse(value));
                    ApplicationContext.Session["entidadActualRow"] = this.mEntidadActual;
                    ApplicationContext.Session["sucursalID"] = SucursalActiva_Id;
                }
            }
        }

        public DataTable EntidadesDisponibles
        {
            get
            {
                return db.ENTIDADESCollection.GetAsDataTable("id in (select u.entidad_id from usuarios u  where u.id = " + this.mUsuario.ID + ")", "");
            }
        }
        #endregion Entidades

        #region Sucursales

        public decimal SucursalActiva_Id
        {
            get
            {
                return mSucursalActiva.ID;
            }
        }

        public string SucursalActiva_Nombre
        {
            get
            {
                return mSucursalActiva.NOMBRE;
            }
        }

        #endregion Sucursales

        #region GetNumeroSesionSoporte
        public static decimal GetNumeroSesionSoporte()
        {
            using (CBAV2 db = new CBAV2())
            {
                return db.USUARIOSCollection.GetByPrimaryKey(Definiciones.Usuarios.Soporte).SESION;
            }
        }
        #endregion GetNumeroSesionSoporte

        #region GetNombreEntidad
        public static string GetNombreEntidad(decimal entidadId)
        {
            string nombreEntidad = "";
            using (CBAV2 db = new CBAV2())
            {
                nombreEntidad = db.ENTIDADESCollection.GetByPrimaryKey(entidadId).NOMBRE;
            }
            return nombreEntidad;
        }

        public static string GetNombreCortoEntidad(string usuario)
        {
            string nombreCorto = "";
            using (CBAV2 db = new CBAV2())
            {
                USUARIOSRow usuRow = db.USUARIOSCollection.GetRow(USUARIOSCollection.USUARIOColumnName + " = '" + usuario + "'");
                if (usuRow != null)
                    nombreCorto = db.ENTIDADESCollection.GetByPrimaryKey(usuRow.ENTIDAD_ID).ABREVIATURA;
            }
            return nombreCorto;
        }
        #endregion GetNombreEntidad

        public static decimal GetSucursalActivaPaisId()
        {
            SessionService service = new SessionService();
            return service.SucursalActiva_pais_id;
        }

        public string cadenaDecimales(decimal monedaId)
        {
            for (int i = 0; i < monedas.Length; i++)
            {
                if (monedas[i].ID == monedaId)
                {
                    return monedas[i].CADENA_DECIMALES;
                }
            }
            return "##,###";
        }

        public int cantidadDecimales(decimal monedaId)
        {
            for (int i = 0; i < monedas.Length; i++)
            {
                if (monedas[i].ID == monedaId)
                {
                    return int.Parse(monedas[i].CANTIDADES_DECIMALES.ToString());
                }
            }
            return 0;
        }

        public decimal tipoRedondeo
        {
            get
            {
                return this.redondeo;
            }
        }

        public decimal tipoCosto
        {
            get
            {
                return this.costo;
            }
        }
        
        public void BeginTransaction()
        {
            db.BeginTransaction();
        }

        public void CommitTransaction()
        {
            db.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            db.RollbackTransaction();
        }
    }
}
