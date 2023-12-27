using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosDatosPersonaService
    {
        #region GetArticulosDatosPersona
        public static DataTable GetArticulosDatosPersona(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetArticulosDatosPersona(clausulas, orden, sesion);
            }
        }

        public static DataTable GetArticulosDatosPersona(string clausulas, string orden, SessionService sesion)
        {
            return sesion.db.ARTICULOS_DATOS_PERSONACollection.GetAsDataTable(clausulas, orden);
        }

        public DataTable GetArticulosDatosPersona(decimal articulo_id)
        {
            return GetArticulosDatosPersona(ArticulosDatosPersonaService.ArticuloId_NombreCol + " = " + articulo_id, ArticulosDatosPersonaService.Id_NombreCol);
        }

        public DataTable GetArticulosDatosPersona()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.ARTICULOS_DATOS_PERSONACollection.GetAllAsDataTable();
            }
        }
        #endregion GetArticulosDatosPersona

        #region GetArticulosDatosPersonasInfoCompleta
        /// <summary>
        /// Gets the articulos datos personas.
        /// </summary>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <returns></returns>
        public DataTable GetArticulosDatosPersonasInfoCompleta(decimal articulo_id)
        {
            return GetArticulosDatosPersonasInfoCompleta(articulo_id, Definiciones.Error.Valor.EnteroPositivo);
        }

        /// <summary>
        /// Gets the articulos datos personas.
        /// </summary>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <param name="persona_id">The persona_id.</param>
        /// <returns></returns>
        public DataTable GetArticulosDatosPersonasInfoCompleta(decimal articulo_id, decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = ArticulosDatosPersonaService.ArticuloId_NombreCol + " = " + articulo_id;
                if (persona_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausulas += " and " + ArticulosDatosPersonaService.PersonaId_NombreCol + " = " + persona_id;

                return sesion.Db.ARTICULOS_DATOS_PERSONA_INF_CCollection.GetAsDataTable(clausulas, ArticulosDatosPersonaService.VistaPersonaNombre_NombreCol);
            }
        }
        #endregion GetArticulosDatosPersonasInfoCompleta

        #region Borrar
        /// <summary>
        /// Borrars the specified articulos_datos_persona_id.
        /// </summary>
        /// <param name="articulos_datos_persona_id">The articulos_datos_persona_id.</param>
        public void Borrar(Decimal articulos_datos_persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    ARTICULOS_DATOS_PERSONARow row = sesion.Db.ARTICULOS_DATOS_PERSONACollection.GetByPrimaryKey(articulos_datos_persona_id);
                    sesion.Db.ARTICULOS_DATOS_PERSONACollection.Delete(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    sesion.Db.CommitTransaction();
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
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    ARTICULOS_DATOS_PERSONARow row = new ARTICULOS_DATOS_PERSONARow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("articulos_datos_persona_sqc");
                    }
                    else
                    {
                        row = sesion.Db.ARTICULOS_DATOS_PERSONACollection.GetByPrimaryKey((decimal)campos[ArticulosDatosPersonaService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.PERSONA_ID = (decimal)campos[ArticulosDatosPersonaService.PersonaId_NombreCol];
                    row.ARTICULO_ID = (decimal)campos[ArticulosDatosPersonaService.ArticuloId_NombreCol];
                    row.CODIGO_BARRAS = campos[ArticulosDatosPersonaService.CodigoBarras_NombreCol].ToString();
                    row.CODIGO = campos[ArticulosDatosPersonaService.Codigo_NombreCol].ToString();
                    row.DESCRIPCION = campos[ArticulosDatosPersonaService.Descripcion_NombreCol].ToString();

                    if (insertarNuevo) sesion.Db.ARTICULOS_DATOS_PERSONACollection.Insert(row);
                    else sesion.Db.ARTICULOS_DATOS_PERSONACollection.Update(row);
                    
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Accesors
        public static string Nombre_Tabla
        { get { return "ARTICULOS_DATOS_PERSONA"; } }

        public static string Id_NombreCol
        { get { return ARTICULOS_DATOS_PERSONACollection.IDColumnName; } }

        public static string PersonaId_NombreCol
        { get { return ARTICULOS_DATOS_PERSONACollection.PERSONA_IDColumnName; } }

        public static string ArticuloId_NombreCol
        { get { return ARTICULOS_DATOS_PERSONACollection.ARTICULO_IDColumnName; } }

        public static string CodigoBarras_NombreCol
        { get { return ARTICULOS_DATOS_PERSONACollection.CODIGO_BARRASColumnName; } }

        public static string Codigo_NombreCol
        { get { return ARTICULOS_DATOS_PERSONACollection.CODIGOColumnName; } }

        public static string Descripcion_NombreCol
        { get { return ARTICULOS_DATOS_PERSONACollection.DESCRIPCIONColumnName; } }

        public static string VistaPersonaNombre_NombreCol
        { get { return ARTICULOS_DATOS_PERSONA_INF_CCollection.PERSONA_NOMBREColumnName; } }

        #endregion Accesors
    }
}
