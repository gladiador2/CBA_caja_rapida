using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.General;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class CalificaionPersonasService
    {
  
        #region GetCalificaionesPersonasDataTable
        /// <summary>
        /// Gets the Calificaiones Personas data table ordenado por id
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCalificaionPersonaDataTable()
        {
            return GetCalificaionPersonaDataTable(string.Empty, string.Empty, true);
        }

        
        /// <summary>
        /// Gets the Calificaione personas data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCalificaionPersonaDataTable(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PERSONAS_CALIFICACIONESCollection.GetAsDataTable(clausulas, CalificaionPersonasService.Id_NombreCol);
            }
        }
        #endregion GetProveedoresDataTable

        #region GetProveedor
        /// <summary>
        /// Gets an specific proveedor.
        /// </summary>
        /// <param name="proveedor_id">The proveedor_id.</param>
        /// <returns></returns>
        public static DataTable GetCalificacionPersona(decimal calificaionPersonaId)
        {
            return GetCalificaionPersonaDataTable(CalificaionPersonasService.Id_NombreCol + " = " + calificaionPersonaId, string.Empty, false);
        }
        #endregion GetProveedor


        #region Guardar
        /// <summary>
        /// No implementado aun
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo) 
        {
            return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        { get { return "PERSONAS_CALIFICAIONES"; } }

        public static string Id_NombreCol
        { get { return PERSONAS_CALIFICACIONESCollection.IDColumnName;} }

        public static string Descripcion_NombreCol
        { get { return PERSONAS_CALIFICACIONESCollection.DESCRIPCIONColumnName; } }

        #endregion Accessors
    }
}
