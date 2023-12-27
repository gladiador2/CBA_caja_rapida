using System;
using System.IO;
using System.Xml.Serialization;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Base
{
    public class WebservicesParametrosService
    {
        #region Variables de clase
        private static string[] vSeparador = { "@!@" };
        #endregion Variables de clase

        #region ObtenerParametros
        /// <summary>
        /// Obteners the parametros.
        /// </summary>
        /// <param name="webservice_parametro_id">The webservice_parametro_id.</param>
        /// <param name="hash">The hash.</param>
        /// <returns></returns>
        public static string[] ObtenerParametros(decimal webservice_parametro_id, string hash, SessionService sesion)
        {
            WEBSERVICES_PARAMETROSRow row = sesion.db.WEBSERVICES_PARAMETROSCollection.GetRow(WebservicesParametrosService.Id_NombreColumna + " = " + webservice_parametro_id);
            string[] parametros = new string[0];

            if (row != null && row.UTILIZADO == Definiciones.SiNo.No && row.HASH.Equals(hash))
            {
                if (row.PARAMETROS == null || row.PARAMETROS.Length <= 0)
                    parametros = new string[0];
                else
                    parametros = row.PARAMETROS.Split(WebservicesParametrosService.vSeparador, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                throw new Exception("No se encontraron los parámetros para invocar al WebService.");
            }

            row.UTILIZADO = Definiciones.SiNo.Si;
            sesion.db.WEBSERVICES_PARAMETROSCollection.Update(row);

            return parametros;
        }
        #endregion ObtenerParametros

        #region MarcarComoFinalizado
        /// <summary>
        /// Marcar como finalizado.
        /// </summary>
        /// <param name="webservice_parametro_id">The webservice_parametro_id.</param>
        /// <returns></returns>

        public static void MarcarComoFinalizado(decimal webservice_parametro_id, string hash, string resultado, SessionService sesion)
        {
            WEBSERVICES_PARAMETROSRow row = sesion.db.WEBSERVICES_PARAMETROSCollection.GetRow(WebservicesParametrosService.Id_NombreColumna + " = " + webservice_parametro_id);
            if (row != null && row.UTILIZADO == Definiciones.SiNo.Si && row.FINALIZADO == Definiciones.SiNo.No && row.HASH.Equals(hash) && resultado != null)
            {
                row.FINALIZADO = Definiciones.SiNo.Si;
                row.RESULTADO = resultado;
                sesion.db.WEBSERVICES_PARAMETROSCollection.Update(row);
            }
            else
            {
                if (row != null)
                {
                       throw new Exception(
                            "No se pudo marcar el registro como finalizado." +
                            "row: " + row.ToString() + "; " +
                            "row.UTILIZADO: " + row.UTILIZADO + "; " +
                            "row.FINALIZADO: " + row.FINALIZADO + "; " +
                            "Hash: " + hash + "; " +
                            "row.HASH: " + row.HASH + "; " +
                            "resultado : " + resultado
                          );
                }
                throw new Exception("No se pudo marcar el registro webservice parametros. La fila es nula");
            }
        }
        #endregion MarcarComoFinalizado

        #region Guardar
        /// <summary>
        /// Guardars the specified webservice_id.
        /// </summary>
        /// <param name="webservice_id">The webservice_id.</param>
        /// <param name="webmethod">The webmethod.</param>
        /// <param name="parametros">The parametros.</param>
        /// <param name="hash">The hash.</param>
        /// <param name="usar_sesion">if set to <c>true</c> [usar_sesion].</param>
        /// <returns></returns>
        public static decimal Guardar(decimal webservice_id, string webmethod, string parametros, string hash, bool usar_sesion)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    WEBSERVICES_PARAMETROSRow row = new WEBSERVICES_PARAMETROSRow();
                    string valorAnterior = Definiciones.Log.RegistroNuevo;

                    if (usar_sesion)
                    {
                        row.USUARIO_ID = sesion.Usuario.ID;
                    }

                    row.IP = SessionService.GetClienteIP();
                    row.ID = sesion.Db.GetSiguienteSecuencia("webservices_parametros_sqc");
                    row.FECHA_CREACION = DateTime.Now;
                    row.HASH = hash;

                    if (!webservice_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        row.WEBSERVICE_ID = webservice_id;

                    row.WEBMETHOD = webmethod;
                    row.PARAMETROS = parametros;
                    row.UTILIZADO = Definiciones.SiNo.No;
                    row.FINALIZADO = Definiciones.SiNo.No;

                    sesion.Db.WEBSERVICES_PARAMETROSCollection.Insert(row);

                    if (usar_sesion)
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    return row.ID;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion Guardar

        #region GuardarRespuesta
        /// <summary>
        /// Guardars the respuesta.
        /// </summary>
        /// <param name="webservice_parametro_id">The webservice_parametro_id.</param>
        /// <param name="resultado">The resultado.</param>
        public static void GuardarRespuesta(decimal webservice_parametro_id, object resultado)
        {
            using (SessionService sesion = new SessionService())
            {
                WEBSERVICES_PARAMETROSRow row = sesion.db.WEBSERVICES_PARAMETROSCollection.GetByPrimaryKey(webservice_parametro_id);
                row.RESULTADO = JsonUtil.Serializar(resultado);

                //Limitar longitud
                if (row.RESULTADO.Length > 4000)
                    row.RESULTADO = row.RESULTADO.Substring(0, 3999);

                sesion.db.WEBSERVICES_PARAMETROSCollection.Update(row);
            }
        }
        #endregion GuardarRespuesta

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "WEBSERVICES_PARAMETROS"; }
        }
        public static string FechaCreacion_Id_NombreColumna
        {
            get { return WEBSERVICES_PARAMETROSCollection.FECHA_CREACIONColumnName; }
        }
        public static string Hash_NombreColumna
        {
            get { return WEBSERVICES_PARAMETROSCollection.HASHColumnName; }
        }
        public static string Id_NombreColumna
        {
            get { return WEBSERVICES_PARAMETROSCollection.IDColumnName; }
        }
        public static string IP_NombreColumna
        {
            get { return WEBSERVICES_PARAMETROSCollection.IPColumnName; }
        }
        public static string Parametros_NombreColumna
        {
            get { return WEBSERVICES_PARAMETROSCollection.PARAMETROSColumnName; }
        }
        public static string UsuarioId_NombreColumna
        {
            get { return WEBSERVICES_PARAMETROSCollection.USUARIO_IDColumnName; }
        }
        public static string Utilizado_NombreColumna
        {
            get { return WEBSERVICES_PARAMETROSCollection.UTILIZADOColumnName; }
        }
        public static string Webmethod_NombreColumna
        {
            get { return WEBSERVICES_PARAMETROSCollection.WEBMETHODColumnName; }
        }
        public static string WebserviceId_NombreColumna
        {
            get { return WEBSERVICES_PARAMETROSCollection.WEBSERVICE_IDColumnName; }
        }
        #endregion Accessors
    }
}
