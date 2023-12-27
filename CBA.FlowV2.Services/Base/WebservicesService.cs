using System;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using System.Collections;

namespace CBA.FlowV2.Services.Base
{
    public class WebservicesService
    {
        #region ValidarHash
        /// <summary>
        /// Validars the hash.
        /// </summary>
        /// <param name="webservice_id">The webservice_id.</param>
        /// <param name="hash">The hash.</param>
        /// <returns></returns>
        public static bool ValidarHash(int webservice_id, string hash)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    WEBSERVICESRow row = sesion.db.WEBSERVICESCollection.GetByPrimaryKey(webservice_id);
                    return row.HASH == hash;
                }
            }
            catch (Exception)
            {
                throw new Exception("Problemas para validar el WebService.");
            }
        }
        #endregion ValidarHash

        #region ObtenerParametros
        /// <summary>
        /// Validars the hash.
        /// </summary>
        /// <param name="webservice_id">The webservice_id.</param>
        /// <param name="hash">The hash.</param>
        /// <returns></returns>
        public static bool ValidarHash(decimal webservice_id, string hash)
        {
            using (CBAV2 db = new CBAV2())
            {
                WEBSERVICESRow row = db.WEBSERVICESCollection.GetByPrimaryKey(webservice_id);

                return row.HASH.Equals(hash);
            }
        }
        #endregion ObtenerParametros

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "WEBSERVICES"; }
        }
        public static string Estado_NombreCol
        {
            get { return WEBSERVICESCollection.ESTADOColumnName; }
        }
        public static string Hash_NombreCol
        {
            get { return WEBSERVICESCollection.HASHColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return WEBSERVICESCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return WEBSERVICESCollection.NOMBREColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return WEBSERVICESCollection.OBSERVACIONColumnName; }
        }
        #endregion Accessors
    }
}
