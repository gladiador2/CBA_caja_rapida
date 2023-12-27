using System.Data;
using System;
using System.IO;

using System.Text;
using System.Web.UI;

using System.Collections.Generic;
using System.Windows.Forms;
using CBA.FlowV2.Db;
using System.Collections;
using System.Net;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.RecursosHumanos;

namespace CBA.FlowV2.Services.Sesion
{
    public abstract class ReglasLoginService
    {
        #region Enumeracion Origen
        public enum Origen : int
        { 
            web = 0,
            mobile = 1, 
            rest = 2
        }
        #endregion Enumeracion Origen

        #region GetReglasLoginDataTable
        /// <summary>
        /// Gets the reglas login data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetReglasLoginDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.db.REGLAS_LOGINCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetReglasLoginDataTable

        #region GetReglasLoginInfoCompleta
        /// <summary>
        /// Gets the reglas login information completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetReglasLoginInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.db.REGLAS_LOGIN_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetReglasLoginInfoCompleta

        #region Validar
        /// <summary>
        /// Validars the specified usuario_id.
        /// </summary>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <param name="usuario_nombre">The usuario_nombre.</param>
        /// <param name="ip_intento">The ip_intento.</param>
        /// <returns></returns>
        public static bool Validar(decimal usuario_id, string usuario_nombre, string ip_intento, ReglasLoginService.Origen origen)
        {
            using (SessionService sesion = new SessionService())
            {
                bool permitido = false, alertaIntentoExterno = false;
                bool reglaLaboral, reglaNoLaboral, funcionarioLaboral = false;
                Hashtable campos;
                IPAddress ipIntento, ipRed, ipMascara;
                DataTable dtReglas;
                string clausulas;
                decimal funcionarioId;
                string[] ips;

                //El usuario puede tener mas de una IP
                ips = ip_intento.Split(',');
                ip_intento = ips[ips.Length - 1].Trim();

                // Convierte la IP de string a IPAddress
                if (!IPAddress.TryParse(ip_intento, out ipIntento))
                {
                    campos = new Hashtable();
                    campos.Add(LogueoService.Usuario_NombreCol, usuario_nombre);
                    campos.Add(LogueoService.Ip_NombreCol, ip_intento);
                    campos.Add(LogueoService.Mensaje_NombreCol, Definiciones.Log.LoginFallaIpNoValida);
                    LogueoService.Guardar(campos);

                    permitido = false;
                    return permitido;
                }

                clausulas = ReglasLoginService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                            "((" + ReglasLoginService.FechaCaducidad_NombreCol + " is not null or " + ReglasLoginService.FechaCaducidad_NombreCol + " > sysdate) and " +
                            " (" + ReglasLoginService.UsuarioId_NombreCol + " is null and " + ReglasLoginService.RolId_NombreCol + " is null) or " +
                            " (" + ReglasLoginService.UsuarioId_NombreCol + " = " + usuario_id + " and " + ReglasLoginService.RolId_NombreCol + " is null) or " +
                            " (exists ( " +
                            "           select * from " + UsuariosRolesService.Nombre_Tabla + " ur " +
                            "            where ur." + UsuariosRolesService.UsuarioId_NombreCol + " = " + usuario_id +
                            "              and ur." + UsuariosRolesService.RolId_NombreCol + " = " + ReglasLoginService.Nombre_Tabla + "." + ReglasLoginService.RolId_NombreCol +
                            "              and (ur." + UsuariosRolesService.UsuarioId_NombreCol + " = " + ReglasLoginService.Nombre_Tabla + "." + ReglasLoginService.UsuarioId_NombreCol + " or " +
                            "                   " + ReglasLoginService.Nombre_Tabla + "." + ReglasLoginService.UsuarioId_NombreCol + " is null)" +
                            "          )" +
                            " ))";

                switch (origen)
                {
                    case Origen.web: 
                        clausulas += " and " + ReglasLoginService.AplicaWeb_NombreCol + " = '" + Definiciones.SiNo.Si + "'";
                        break;
                    case Origen.mobile:
                    case Origen.rest:
                        clausulas += " and " + ReglasLoginService.AplicaMobile_NombreCol + " = '" + Definiciones.SiNo.Si + "'";
                        break;
                    default:
                        throw new Exception("ReglasLoginService.Validar(). Origen no implementado.");
                }

                dtReglas = ReglasLoginService.GetReglasLoginDataTable(clausulas, string.Empty, sesion);

                //Se obtiene el funcionario asociado al usuario
                funcionarioId = UsuariosService.GetFuncionarioId(usuario_id);

                //Se obtiene si el funcionario esta en horario laboral
                if(!funcionarioId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    funcionarioLaboral = FuncionariosService.EstaEnHorarioLaboral(funcionarioId);

                if (dtReglas.Rows.Count <= 0)
                    permitido = true;

                //Evaluar cada regla hasta que se permita el acceso o se terminen las reglas
                for (int i = 0; !permitido && i < dtReglas.Rows.Count; i++)
                {
                    reglaLaboral = (string)dtReglas.Rows[i][ReglasLoginService.AplicaHorarioLaborable_NombreCol] == Definiciones.SiNo.Si;
                    reglaNoLaboral = (string)dtReglas.Rows[i][ReglasLoginService.AplicaHorarioNoLaborable_NombreCol] == Definiciones.SiNo.Si;

                    // Convierte la IP de string a IPAddress
                    ipRed = IPAddress.Parse((string)dtReglas.Rows[i][ReglasLoginService.IP_NombreCol]);
                    ipMascara = IPAddress.Parse((string)dtReglas.Rows[i][ReglasLoginService.Mascara_NombreCol]);

                    //Si la regla aplica a horario laboral, el usuario es funcionario y esta en un turno
                    if(reglaLaboral && funcionarioLaboral && !funcionarioId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    {
                        //Se evalua si la IP se encuentran en rango permitido
                        permitido = IPService.Validar(ipIntento, ipRed, ipMascara);
                    }

                    //Si la regla aplica a horario no laboral, el usuario es funcionario y no esta en un turno
                    if(reglaNoLaboral && !funcionarioLaboral && !funcionarioId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    {
                        //Se evalua si la IP se encuentran en rango permitido
                        permitido = IPService.Validar(ipIntento, ipRed, ipMascara);
                    }

                    //Levantar la alerta si no fue permitido el acceso y
                    //si la regla es solo para horario laboral y el funcionario no esta en horario laboral
                    if (!permitido && reglaLaboral && !reglaNoLaboral && !funcionarioLaboral)
                        alertaIntentoExterno = true;
                }

                //Se registra si el 
                if (!permitido && alertaIntentoExterno)
                {
                    campos = new Hashtable();
                    campos.Add(LogueoService.Usuario_NombreCol, usuario_nombre);
                    campos.Add(LogueoService.Ip_NombreCol, ip_intento);
                    campos.Add(LogueoService.Mensaje_NombreCol, Definiciones.Log.LoginFallaHorarioNoValido);
                    LogueoService.Guardar(campos);
                }

                return permitido;
            }
        }
        #endregion Validar

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "REGLAS_LOGIN"; }
        }
        public static string Nombre_Vista
        {
            get { return "REGLAS_LOGIN_INFO_COMPLETA"; }
        }
        public static string AplicaHorarioLaborable_NombreCol
        {
            get { return REGLAS_LOGINCollection.APLICA_HORARIO_LABORABLEColumnName; }
        }
        public static string AplicaHorarioNoLaborable_NombreCol
        {
            get { return REGLAS_LOGINCollection.APLICA_HORARIO_NO_LABORABLEColumnName; }
        }
        public static string AplicaMobile_NombreCol
        {
            get { return REGLAS_LOGINCollection.APLICA_MOBILEColumnName; }
        }
        public static string AplicaWeb_NombreCol
        {
            get { return REGLAS_LOGINCollection.APLICA_WEBColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return REGLAS_LOGINCollection.ESTADOColumnName; }
        }
        public static string FechaCaducidad_NombreCol
        {
            get { return REGLAS_LOGINCollection.FECHA_CADUCIDADColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return REGLAS_LOGINCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return REGLAS_LOGINCollection.IDColumnName; }
        }
        public static string IP_NombreCol
        {
            get { return REGLAS_LOGINCollection.IPColumnName; }
        }
        public static string Mascara_NombreCol
        {
            get { return REGLAS_LOGINCollection.MASCARAColumnName; }
        }
        public static string RolId_NombreCol
        {
            get { return REGLAS_LOGINCollection.ROL_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return REGLAS_LOGINCollection.USUARIO_IDColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string VistaUsuarioNombre_NombreCol
        {
            get { return REGLAS_LOGIN_INFO_COMPLETACollection.USUARIO_NOMBREColumnName; }
        }
        #endregion Vista
        #endregion Accessors
    }
}
