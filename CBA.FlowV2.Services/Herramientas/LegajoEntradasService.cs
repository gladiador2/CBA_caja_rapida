#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class LegajoEntradasService
    {
        #region GetLegajoPersonasEntradasDataTable
        /// <summary>
        /// Gets the legajo personas entradas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetLegajoPersonasEntradasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.LEGAJO_ENTRADASCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetLegajoPersonasEntradasDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    LEGAJO_ENTRADASRow row = new LEGAJO_ENTRADASRow();
                    string valorAnterior = string.Empty;

                    if (!campos.Contains(LegajoEntradasService.Id_NombreCol))
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("LEGAJO_ENTRADAS_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.LEGAJO_ENTRADASCollection.GetRow(LegajoEntradasService.Id_NombreCol + " = " + campos[LegajoEntradasService.Id_NombreCol].ToString());
                        valorAnterior = row.ToString();
                    }

                    row.ESTADO = (string)campos[LegajoEntradasService.Estado_NombreCol];
                    row.NOMBRE = (string)campos[LegajoEntradasService.Nombre_NombreCol];
                    row.DESCRIPCION = (string)campos[LegajoEntradasService.Nombre_NombreCol];

                    if (!campos.Contains(LegajoEntradasService.Id_NombreCol)) sesion.Db.LEGAJO_ENTRADASCollection.Insert(row);
                    else sesion.Db.LEGAJO_ENTRADASCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

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

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "LEGAJO_ENTRADAS"; }
        }
        public static string Descripcion_NombreCol
        {
            get { return LEGAJO_ENTRADASCollection.DESCRIPCIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return LEGAJO_ENTRADASCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return LEGAJO_ENTRADASCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return LEGAJO_ENTRADASCollection.NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
