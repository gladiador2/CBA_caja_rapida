using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;

using System.Net;
using System.Collections.Specialized;
using System.Text;
using System.Collections;

namespace CBA.FlowV2.Services.Base
{
    public class ManualesService
    {

        public static Hashtable ObtenerFlagsHashtable(string csv_flags)
        {
            Hashtable result = new Hashtable();
            string[] flags = csv_flags.Split(',');
            foreach (string flag in flags) {
                result[flag.Trim()] = true;
            }
            //TODO: ver de donde sacar el tema de los flags
            return result;
        }

        public static HttpWebResponse ManualLatex(Hashtable campos, string prefijo)
        {
            string url = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.DireccionServidorLatex);
            
            //preparar el http request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            string jsonData = JsonUtil.Serializar(campos);
            string prefijoJson = JsonUtil.Serializar(prefijo);
            var postData = "prefijo=" + prefijoJson;
            postData += "&data=" + jsonData;

            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            //escribir el dato en el request
            using (var stream = request.GetRequestStream()) {
                stream.Write(data, 0, data.Length);
            }

            return (HttpWebResponse)request.GetResponse();
        }

        #region GetManualesActivos
        public static DataTable GetManualesActivos(string nombre_tabla, string identificador_texto)
        {
            using (SessionService sesion = new SessionService()) 
            {
                try 
                {
                    return GetManualesActivos(nombre_tabla, identificador_texto, sesion.Usuario.ENTIDAD_ID);
                }
                catch (System.Exception exp) 
                {
                    throw exp;
                }
            }
        }

        public static DataTable GetManualesActivos(string nombre_tabla, string identificador_texto, decimal entidad_id)
        {
            using (SessionService sesion = new SessionService()) {
                try {
                    string clausulas = ManualesService.EntidadId_NombreCol + " = " + entidad_id;
                    clausulas += " and " + ManualesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                    if (nombre_tabla.Length > 0) clausulas += " and " + ManualesService.TablaId_NombreCol + " = '" + nombre_tabla + "' ";
                    else if (identificador_texto.Length > 0) clausulas += " and " + ManualesService.IdentificadorTexto_NombreCol + " = '" + identificador_texto + "' ";
                    else throw new Exception("ManualesService.GetManualesActivos: No se especificó la tabla ni el identificador del manual.");

                    return sesion.Db.MANUALESCollection.GetAsDataTable(clausulas, string.Empty);

                } catch (System.Exception exp) {
                    throw exp;
                }
            }
        }
        #endregion GetManualesActivos

        #region GetYoutubeId
        public static string GetYoutubeId(string nombre_tabla, string identificador_texto, decimal entidad_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    DataTable dt;
                    string clausulas = ManualesService.EntidadId_NombreCol + " = " + entidad_id;
                    string orden = ManualesService.Version_NombreCol + " desc";

                    if (nombre_tabla.Length > 0) clausulas += " and " + ManualesService.TablaId_NombreCol + " = '" + nombre_tabla + "' ";
                    else if (identificador_texto.Length > 0) clausulas += " and " + ManualesService.IdentificadorTexto_NombreCol + " = '" + identificador_texto + "' ";
                    else throw new Exception("ManualesService.GetYoutubeId: No se especificó la tabla ni el identificador del manual.");

                    dt = sesion.Db.MANUALESCollection.GetAsDataTable(clausulas, orden);

                    if (dt.Rows.Count > 0 && !dt.Rows[0][ManualesService.YoutubeId_NombreCol].Equals(DBNull.Value))
                        return (string)dt.Rows[0][ManualesService.YoutubeId_NombreCol];
                    else
                        return string.Empty;
                }
                catch (System.Exception exp)
                {
                    throw exp;
                }
            }
        }

        public static string GetYoutubeId(string nombre_tabla, string identificador_texto)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    return GetYoutubeId(nombre_tabla, identificador_texto, sesion.Usuario.ENTIDAD_ID);
                }
                catch (System.Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion GetYoutubeId

        #region GetNombreArchivoManual

        /// <summary>
        /// Gets the nombre archivo manual.
        /// </summary>
        /// <param name="nombre_tabla">The nombre_tabla.</param>
        /// <returns></returns>
        public string GetNombreArchivoManual(string nombre_tabla, string identificador_texto)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    return GetNombreArchivoManual(nombre_tabla, identificador_texto, sesion.Usuario.ENTIDAD_ID);
                }
                catch (System.Exception exp)
                {
                    throw exp;
                }
            }
        }

        /// <summary>
        /// Gets the nombre archivo manual.
        /// </summary>
        /// <param name="nombre_tabla">The nombre_tabla.</param>
        /// <param name="entidad_id">The entidad_id.</param>
        /// <returns></returns>
        public string GetNombreArchivoManual(string nombre_tabla, string identificador_texto, decimal entidad_id) 
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    DataTable dt;
                    string clausulas = ManualesService.EntidadId_NombreCol + " = " + entidad_id;
                    string orden = ManualesService.Version_NombreCol + " desc";

                    if (nombre_tabla.Length > 0) clausulas += " and " + ManualesService.TablaId_NombreCol + " = '" + nombre_tabla + "' ";
                    else if (identificador_texto.Length > 0) clausulas += " and " + ManualesService.IdentificadorTexto_NombreCol + " = '" + identificador_texto + "' ";
                    else throw new Exception("No se especificó la tabla ni el identificador del manual.");

                    dt = sesion.Db.MANUALESCollection.GetAsDataTable(clausulas, orden);

                    if (dt.Rows.Count > 0)
                        return (string)dt.Rows[0][ManualesService.NombreArchivo_NombreCol];
                    else
                        return string.Empty;
                }
                catch (System.Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion GetNombreArchivoManual

   

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "MANUALES"; }
        }
        public static string EntidadId_NombreCol
        {
            get { return MANUALESCollection.ENTIDAD_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return MANUALESCollection.IDColumnName; }
        }
        public static string IdentificadorTexto_NombreCol
        {
            get { return MANUALESCollection.IDENTIFICADOR_TEXTOColumnName; }
        }
        public static string NombreArchivo_NombreCol
        {
            get { return MANUALESCollection.NOMBRE_ARCHIVOColumnName; }
        }
        public static string TablaId_NombreCol
        {
            get { return MANUALESCollection.TABLA_IDColumnName; }
        }
        public static string Version_NombreCol
        {
            get { return MANUALESCollection.VERSIONColumnName; }
        }
        public static string YoutubeId_NombreCol
        {
            get { return MANUALESCollection.YOUTUBE_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return MANUALESCollection.ESTADOColumnName; }
        }
        public static string FlagsLatex_NombreCol
        {
            get { return MANUALESCollection.FLAGS_LATEXColumnName; }
        }
        public static string NombrePantalla_NombreCol
        {
            get { return MANUALESCollection.NOMBRE_PANTALLAColumnName; }
        }
        
        #endregion Accessors
    }
}
