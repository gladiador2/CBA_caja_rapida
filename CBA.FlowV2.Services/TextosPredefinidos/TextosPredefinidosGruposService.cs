#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.TextosPredefinidos
{
    public class TextosPredefinidosGruposService
    {
        #region GetTextosPredefinidosGruposDataTable
        /// <summary>
        /// Gets the Textos Predefinidos data table.
        /// </summary>
        /// <param name="tipo_id">The tipo_id.</param>
        /// <returns></returns>
        public static DataTable GetTextosPredefinidosGruposDataTable(decimal id)
        {
            return GetTextosPredefinidosGruposDataTable(Id_NombreCol + " = " + id);
        }
        
        public static DataTable GetTextosPredefinidosGruposDataTable(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TEXTOS_PREDEFINIDOS_GRUPOSCollection.GetAsDataTable(clausulas, Nombre_NombreCol);
            }
        }

        #endregion GetTextosPredefinidosDataTable

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    TEXTOS_PREDEFINIDOS_GRUPOSRow row = new TEXTOS_PREDEFINIDOS_GRUPOSRow();
                    string valorAnterior = string.Empty;

                    #region Validaciones
                    if (((string)campos[TextosPredefinidosGruposService.Nombre_NombreCol]).Length <= 0)
                        throw new Exception("Debe indicar el nombre");
                    #endregion Validaciones

                    if (!campos.Contains(TextosPredefinidosGruposService.Id_NombreCol))
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("textos_predefinidos_grupos_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.db.TEXTOS_PREDEFINIDOS_GRUPOSCollection.GetRow(TextosPredefinidosGruposService.Id_NombreCol + " = " + campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    
                    row.NOMBRE = (string)campos[TextosPredefinidosGruposService.Nombre_NombreCol];
                    row.ESTADO = (string)campos[TextosPredefinidosGruposService.Estado_NombreCol];

                    if (!campos.Contains(TextosPredefinidosGruposService.Id_NombreCol)) sesion.Db.TEXTOS_PREDEFINIDOS_GRUPOSCollection.Insert(row);
                    else sesion.Db.TEXTOS_PREDEFINIDOS_GRUPOSCollection.Update(row);

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

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TEXTOS_PREDEFINIDOS_GRUPOS"; }
        }
       
        public static string Id_NombreCol
        {
            get { return TEXTOS_PREDEFINIDOS_GRUPOSCollection.IDColumnName; }
        }

        public static string Nombre_NombreCol
        {
            get { return TEXTOS_PREDEFINIDOS_GRUPOSCollection.NOMBREColumnName; }
        }

        public static string Estado_NombreCol
        {
            get { return TEXTOS_PREDEFINIDOS_GRUPOSCollection.ESTADOColumnName; }
        }
        #endregion Accessors
    }
}




