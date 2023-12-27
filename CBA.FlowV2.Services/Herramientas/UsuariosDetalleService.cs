using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class UsuariosDetalleService
    {
        #region Metodos estaticos
        public static string Nombre_Tabla
        {
            get { return "USUARIOS_DETALLE"; }
        }
        public static string Id_NombreCol
        {
            get { return USUARIOS_DETALLECollection.IDColumnName ; }
        }
        public static string UsuarioID_NombreCol
        {
            get { return USUARIOS_DETALLECollection.USUARIO_IDColumnName; }
        }
        public static string CodigoVerificacion_NombreCol
        {
            get { return USUARIOS_DETALLECollection.CODIGO_VERIFICACIONColumnName; }
        }
        public static string FechaEnvio_NombreCol
        {
            get { return USUARIOS_DETALLECollection.FECHA_ENVIOColumnName; }
        }
        public static string FechaCaducidad_NombreCol
        {
            get { return USUARIOS_DETALLECollection.FECHA_CADUCIDADColumnName; }
        }
        public static string FechaUso_NombreCol
        {
            get { return USUARIOS_DETALLECollection.FECHA_USOColumnName; }
        }
        public static string ValidacionCorrecta_NombreCol
        {
            get { return USUARIOS_DETALLECollection.VALIDACION_CORRECTAColumnName; }
        }
        public static string IPSolicitudContrasena_NombreCol
        {
            get { return USUARIOS_DETALLECollection.IP_SOLICITUD_CONTRASENAColumnName; }
        }
        public static string IPValidacionUsuario_NombreCol
        {
            get { return USUARIOS_DETALLECollection.IP_VALIDACION_USUARIOColumnName; }
        }
        public static string SecuenciaNombre
        {
            get { return "usuarios_detalle_sqc"; }
        }
        public static string LogDeRegistro
        {
            get { return "usuarios_detalle"; }
        }
        #endregion Metodos estaticos


        #region Getters
        public DataRow GetUsuariosDetalleRow(decimal usuario_detalle_id)
        {
            using(SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.USUARIOS_DETALLECollection.GetAsDataTable(UsuariosDetalleService.Id_NombreCol + "=" + usuario_detalle_id, "");
                return table.Rows[0];
            }
        }

       

        public DataTable GetUsuariosDetalle(decimal usuario_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string where;
                where = UsuariosDetalleService.Id_NombreCol + " = " + usuario_detalle_id;
                table = sesion.Db.USUARIOS_DETALLECollection.GetAsDataTable(where, "");
                return table;
            }
        }

        /// <summary>
        /// Gets the usuarios data table with an user-specific where and order clauses.
        /// </summary>
        /// <param name="clausulas">The where string.</param>
        /// <param name="orden">The ordering string.</param>
        /// <param name="soloActivos">Si es true se obtienen solo los activos.</param>
        /// <param name="incluirRegistroTodos">if set to <c>true</c> [incluir registro todos].</param>
        /// <returns></returns>
        public DataTable GetUsuariosDetalle(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string estado = " 1=1 ";
                table = sesion.Db.USUARIOS_DETALLECollection.GetAsDataTable(estado + " and " + clausulas, orden);
                return table;
            }
        }



        #endregion Getters

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    string valorAnterior = Definiciones.Log.RegistroNuevo;

                    /*se verifica si es un registro nuevo, es decir, se registro un nuevo nonce
                     * o se valido la contrase;a. Para distinguir esto, se verifica que existan 
                     * los campos de: ip validacion, validacion correcta y la fecha de uso.
                     * 
                     */
                    USUARIOS_DETALLERow row = new USUARIOS_DETALLERow();
                    row.USUARIO_ID = decimal.Parse(campos[UsuariosDetalleService.UsuarioID_NombreCol].ToString());
                    row.CODIGO_VERIFICACION = campos[UsuariosDetalleService.CodigoVerificacion_NombreCol].ToString();
                    row.FECHA_ENVIO = DateTime.Parse(campos[UsuariosDetalleService.FechaEnvio_NombreCol].ToString());
                    row.FECHA_CADUCIDAD = DateTime.Parse(campos[UsuariosDetalleService.FechaCaducidad_NombreCol].ToString());
                    //campos que no se pueden determinar en este punto.
                    /*row.FECHA_USO;  
                    row.VALIDACION_CORRECTA;
                    row.IP_VALIDACION_USUARIO*/
                    row.IP_SOLICITUD_CONTRASENA = campos[UsuariosDetalleService.IPSolicitudContrasena_NombreCol].ToString();

                    if (campos.Contains(UsuariosDetalleService.IPValidacionUsuario_NombreCol)
                        && campos.Contains(UsuariosDetalleService.ValidacionCorrecta_NombreCol)
                        && campos.Contains(UsuariosDetalleService.FechaUso_NombreCol))
                    {
                        //buscar el ultimo nonce que no fue utilizado y traer su ID
                        row.ID = decimal.Parse( sesion.Db.USUARIOS_DETALLECollection.GetAsDataTable(
                                                    UsuariosDetalleService.UsuarioID_NombreCol + " = " + 
                                                    campos[UsuariosDetalleService.UsuarioID_NombreCol] +
                                                    " and " + UsuariosDetalleService.ValidacionCorrecta_NombreCol + 
                                                    " is null", "").Rows[0][UsuariosDetalleService.Id_NombreCol].ToString());

                        //
                        row.IP_VALIDACION_USUARIO = campos[UsuariosDetalleService.IPValidacionUsuario_NombreCol].ToString();
                        row.VALIDACION_CORRECTA = campos[UsuariosDetalleService.ValidacionCorrecta_NombreCol].ToString();
                        row.FECHA_USO = DateTime.Today;
                        sesion.Db.BeginTransaction();
                        sesion.Db.USUARIOS_DETALLECollection.Update(row);
                        LogCambiosService.LogDeRegistro(UsuariosDetalleService.LogDeRegistro, row.ID, valorAnterior, row.ToString(), sesion);
                    }
                    else
                    {
                        //hace falta invalidar todos los demas nonces enviados. Por regla general va a ser siempre uno nomas, pero 
                        //se trae igual todo el datatable igual.
                        DataTable usuarios_detalle = sesion.Db.USUARIOS_DETALLECollection.GetAsDataTable(UsuariosDetalleService.UsuarioID_NombreCol + " = "
                                                                                                + decimal.Parse(campos[UsuariosDetalleService.UsuarioID_NombreCol].ToString()), "");
                        for (int i = 0; i < usuarios_detalle.Rows.Count; i++)
                            usuarios_detalle.Rows[i][UsuariosDetalleService.ValidacionCorrecta_NombreCol] = "N";
                        sesion.Db.USUARIOS_DETALLECollection.Update(usuarios_detalle);
                        row.ID = sesion.Db.GetSiguienteSecuencia(UsuariosDetalleService.SecuenciaNombre);
                        sesion.Db.BeginTransaction();
                        sesion.Db.USUARIOS_DETALLECollection.Insert(row);
                        LogCambiosService.LogDeRegistro(UsuariosDetalleService.LogDeRegistro, row.ID, valorAnterior, row.ToString(), sesion);

                    }
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        
    }
}
