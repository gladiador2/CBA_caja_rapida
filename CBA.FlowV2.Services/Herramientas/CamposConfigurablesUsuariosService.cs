#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class CamposConfigurablesUsuariosService
    {

        #region GetValorDefinidoUsuario
        //Valores numéricos
        public static decimal GetValorDefinidoUsuarioNumero(int campo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetValorDefinidoUsuarioNumero(campo_id, sesion.Usuario.ID, sesion);
            }
        }
        public static decimal GetValorDefinidoUsuarioNumero(int campo_id, decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetValorDefinidoUsuarioNumero(campo_id, usuario_id, sesion);
            }
        }

        public static decimal GetValorDefinidoUsuarioNumero(int campo_id, decimal usuario_id, SessionService sesion)
        {
            DataTable dt = GetValorDefinidoUsuarioDataTable(campo_id, usuario_id);

            if (dt.Rows.Count == 0)
                return Definiciones.Error.Valor.EnteroPositivo;
            else
                return Decimal.Parse(dt.Rows[0][CamposConfigurablesUsuariosService.VistaValor_NombreCol].ToString());
        }

        //Valores de texto
        public static string GetValorDefinidoUsuarioTexto(int campo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetValorDefinidoUsuarioTexto(campo_id, sesion.Usuario.ID);
            }
        }
        public static string GetValorDefinidoUsuarioTexto(int campo_id, decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetValorDefinidoUsuarioTexto(campo_id, usuario_id, sesion);
            }
        }
        public static string GetValorDefinidoUsuarioTexto(int campo_id, decimal usuario_id, SessionService sesion)
        {
            DataTable dt = GetValorDefinidoUsuarioDataTable(campo_id, usuario_id);

            if (dt.Rows.Count == 0)
                return Definiciones.Error.Valor.EnteroPositivo.ToString();
            else
                return dt.Rows[0][CamposConfigurablesUsuariosService.VistaValor_NombreCol].ToString();
        }

        public static string GetValorGrupoUsuarioTexto(int campo_id, decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = GetValorDefinidoGrupoDataTable(campo_id, usuario_id);

                if (dt.Rows.Count == 0)
                    return Definiciones.Error.Valor.EnteroPositivo.ToString();
                else
                    return dt.Rows[0][CamposConfigurablesUsuariosService.VistaValor_NombreCol].ToString();
            }
        }

        //Valores de Fecha
        public DateTime GetValorDefinidoUsuarioFecha(int campo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetValorDefinidoUsuarioFecha(campo_id, sesion.Usuario.ID);
            }
        }

        public static DateTime GetValorDefinidoUsuarioFecha(int campo_id, decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = GetValorDefinidoUsuarioDataTable(campo_id, usuario_id);

                if (dt.Rows.Count == 0)
                    return DateTime.Today;
                else
                    return DateTime.Parse(dt.Rows[0][CamposConfigurablesUsuariosService.VistaValor_NombreCol].ToString());
            }
        }

        public static DataTable GetValorDefinidoUsuarioDataTable(int campo_id, decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                //buscar si el usuario definió valor para el campo
                string clausulas = CamposConfigurablesUsuariosService.CampoConfItemId_NombreCol + " = " + campo_id + " and " +
                                   "(" + CamposConfigurablesUsuariosService.UsuarioId_NombreCol + " = " + usuario_id + " or " + CamposConfigurablesUsuariosService.UsuarioId_NombreCol + " is null) ";
                DataTable dtValorUsu = sesion.Db.CAMPOS_CONF_USUARIOS_INFO_COMPCollection.GetAsDataTable(clausulas, CamposConfigurablesUsuariosService.UsuarioId_NombreCol);

                if (dtValorUsu.Rows.Count == 0)
                {
                    //Buscar si el usuario definió valor para el grupo
                    clausulas = CamposConfigurablesItemsService.Id_NombreCol + " = " + campo_id;
                    DataTable dtCampo = CamposConfigurablesItemsService.GetTablasDataTableInfoCompleta(clausulas);
                    decimal idGrupoAux = Decimal.Parse(dtCampo.Rows[0][CamposConfigurablesItemsService.VistaGrupoId_NombreCol].ToString());
                    return GetValorDefinidoGrupoDataTable(idGrupoAux, usuario_id);
                }
                else
                {
                    return dtValorUsu;
                }
            }
        }

        public static DataTable GetValorDefinidoGrupoDataTable(decimal grupo_id, decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                //buscar si el usuario definió valor para el grupo
                string clausulas = CamposConfigurablesUsuariosService.VistaGrupoAsignadoId_NombreCol + " = " + grupo_id + " and " +
                                   "(" + CamposConfigurablesUsuariosService.UsuarioId_NombreCol + " = " + usuario_id + " or " + CamposConfigurablesUsuariosService.UsuarioId_NombreCol + " is null) ";
                return sesion.Db.CAMPOS_CONF_USUARIOS_INFO_COMPCollection.GetAsDataTable(clausulas, CamposConfigurablesUsuariosService.UsuarioId_NombreCol);
            }
        }

        #endregion GetValorDefinidoUsuario

        #region GetCamposConfigurablesUsuDataTable
        public static DataTable GetCamposConfigurablesUsuDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CAMPOS_CONFIGURABLES_USUARIOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        public static DataTable GetCamposConfigurablesUsuDataTable()
        {
            return GetCamposConfigurablesUsuDataTable(string.Empty, string.Empty);
        }
        public static DataTable GetCamposConfUsuInfoCompDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CAMPOS_CONF_USUARIOS_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        public static DataTable GetCamposConfUsuInfoCompDataTable()
        {
            return GetCamposConfUsuInfoCompDataTable(string.Empty, string.Empty);
        }

        #endregion GetCamposConfigurablesUsuDataTable

        #region Borrar
        public static void Borrar(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    CAMPOS_CONFIGURABLES_USUARIOSRow fila = sesion.Db.CAMPOS_CONFIGURABLES_USUARIOSCollection.GetByPrimaryKey(id);

                    sesion.Db.CAMPOS_CONFIGURABLES_USUARIOSCollection.DeleteByPrimaryKey(id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla,id, fila.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo) {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    if (validarRegistro(campos, insertarNuevo, sesion))
                    {
                        CAMPOS_CONFIGURABLES_USUARIOSRow registro = new CAMPOS_CONFIGURABLES_USUARIOSRow();
                        string valorAnterior = "";

                        if (insertarNuevo)
                        {
                            registro.ID = sesion.Db.GetSiguienteSecuencia("CAMPOS_CONF_USUARIOS_SQC");
                            valorAnterior = Definiciones.Log.RegistroNuevo;
                        }
                        else
                        {
                            registro = sesion.Db.CAMPOS_CONFIGURABLES_USUARIOSCollection.GetRow(Id_NombreCol + " = " + campos[Id_NombreCol]);
                            valorAnterior = registro.ToString();
                        }

                        if (campos.Contains(UsuarioId_NombreCol))
                            registro.USUARIO_ID = (decimal)campos[UsuarioId_NombreCol];
                        else
                            registro.IsUSUARIO_IDNull = true;

                        if (campos.Contains(CampoConfGrupoId_NombreCol))
                        {
                            registro.CAMPO_CONF_GRUPO_ID = (decimal)campos[CampoConfGrupoId_NombreCol];
                            registro.IsCAMPO_CONF_ITEM_IDNull = true;
                        }

                        if (campos.Contains(CampoConfItemId_NombreCol))
                        {
                            registro.CAMPO_CONF_ITEM_ID = (decimal)campos[CampoConfItemId_NombreCol];
                            registro.IsCAMPO_CONF_GRUPO_IDNull = true;
                        }

                        if (campos.Contains(ValorFecha_NombreCol))
                        {
                            registro.VALOR_FECHA = DateTime.Parse(campos[ValorFecha_NombreCol].ToString());
                            registro.IsVALOR_NUMERONull = true;
                            registro.VALOR_TEXTO = null;
                        }
                        if (campos.Contains(ValorNumero_NombreCol))
                        {
                            registro.VALOR_NUMERO = (decimal)campos[ValorNumero_NombreCol];
                            registro.IsVALOR_FECHANull = true;
                            registro.VALOR_TEXTO = null;
                        }
                        if (campos.Contains(ValorTexto_NombreCol))
                        {
                            registro.VALOR_TEXTO = campos[ValorTexto_NombreCol].ToString();
                            registro.IsVALOR_FECHANull = true;
                            registro.IsVALOR_NUMERONull = true;
                        }

                        if (insertarNuevo) sesion.Db.CAMPOS_CONFIGURABLES_USUARIOSCollection.Insert(registro);
                        else sesion.Db.CAMPOS_CONFIGURABLES_USUARIOSCollection.Update(registro);
                        
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, registro.ID, valorAnterior, registro.ToString(), sesion);

                        return registro.ID;
                    }
                    else
                    {
                        throw new Exception("Los datos que se intentan guardar ya existen.");
                    }
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region validarRegistro
        private static bool validarRegistro(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion) 
        {
            try
            {
                string clausulas;

                if (campos.Contains(CampoConfGrupoId_NombreCol))
                    clausulas = CampoConfGrupoId_NombreCol + " = " + campos[CampoConfGrupoId_NombreCol].ToString();
                else
                    clausulas = CampoConfItemId_NombreCol + " = " + campos[CampoConfItemId_NombreCol].ToString();

                if(campos.Contains(UsuarioId_NombreCol))
                    clausulas += " and " + UsuarioId_NombreCol + " = " + campos[UsuarioId_NombreCol];
                else
                    clausulas += " and " + UsuarioId_NombreCol + " = " + sesion.Usuario.ID;

                if (!insertarNuevo)
                    clausulas += " and " + Id_NombreCol + " <> " + campos[Id_NombreCol].ToString();

                DataTable dt = CamposConfigurablesUsuariosService.GetCamposConfigurablesUsuDataTable(clausulas, string.Empty);

                return (dt.Rows.Count == 0);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion validarRegistro

        #region Metodos estaticos
        
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "CAMPOS_CONFIGURABLES_USUARIOS"; }
        }
        public static string Id_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_USUARIOSCollection.IDColumnName; }
        }
        public static string CampoConfGrupoId_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_USUARIOSCollection.CAMPO_CONF_GRUPO_IDColumnName; }
        }
        public static string CampoConfItemId_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_USUARIOSCollection.CAMPO_CONF_ITEM_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_USUARIOSCollection.USUARIO_IDColumnName; }
        }
        public static string ValorFecha_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_USUARIOSCollection.VALOR_FECHAColumnName; }
        }
        public static string ValorNumero_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_USUARIOSCollection.VALOR_NUMEROColumnName; }
        }
        public static string ValorTexto_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_USUARIOSCollection.VALOR_TEXTOColumnName; }
        }

        #endregion Tabla

        #region Vista
        public static string VistaGrupoId_NombreCol
        {
            get { return CAMPOS_CONF_USUARIOS_INFO_COMPCollection.GRUPO_IDColumnName; }
        }
        public static string VistaCampoItemId_NombreCol
        {
            get { return CAMPOS_CONF_USUARIOS_INFO_COMPCollection.CAMPO_CONF_ITEM_IDColumnName; }
        }
        public static string VistaCampoFlujoId_NombreCol
        {
            get { return CAMPOS_CONF_USUARIOS_INFO_COMPCollection.CAMPO_FLUJO_IDColumnName; }
        }
        public static string VistaCampoTablaId_NombreCol
        {
            get { return CAMPOS_CONF_USUARIOS_INFO_COMPCollection.CAMPO_TABLA_IDColumnName; }
        }
        public static string VistaTipoDatoId_NombreCol
        {
            get { return CAMPOS_CONF_USUARIOS_INFO_COMPCollection.TIPO_DATO_IDColumnName; }
        }
        public static string VistaValor_NombreCol
        {
            get { return CAMPOS_CONF_USUARIOS_INFO_COMPCollection.VALORColumnName; }
        }
        public static string VistaGrupoNombre_NombreCol
        {
            get { return CAMPOS_CONF_USUARIOS_INFO_COMPCollection.GRUPO_NOMBREColumnName; }
        }
        public static string VistaFlujoNombre_NombreCol
        {
            get { return CAMPOS_CONF_USUARIOS_INFO_COMPCollection.FLUJO_NOMBREColumnName; }
        }
        public static string VistaCampoNombre_NombreCol
        {
            get { return CAMPOS_CONF_USUARIOS_INFO_COMPCollection.CAMPO_NOMBREColumnName; }
        }
        public static string VistaCampoGrupoAsignadoId_NombreCol
        {
            get { return CAMPOS_CONF_USUARIOS_INFO_COMPCollection.CAMPO_GRUPO_ASIGNADO_IDColumnName; }
        }
        public static string VistaGrupoAsignadoId_NombreCol
        {
            get { return CAMPOS_CONF_USUARIOS_INFO_COMPCollection.GRUPO_ASIGNADO_IDColumnName; }
        }
        #endregion Vista

        #endregion Metodos estaticos
    }
}
