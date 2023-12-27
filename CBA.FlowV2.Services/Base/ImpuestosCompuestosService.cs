#region Using
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
#endregion Using

namespace CBA.FlowV2.Services.Base
{
    public class ImpuestosCompuestosService
    {
        #region GetImpuestosCompuestosDataTable
        /// <summary>
        /// Gets the impuestos compuestos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetImpuestosCompuestosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.IMPUESTOS_COMPUESTOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetImpuestosCompuestosDataTable

        #region GetImpuestosCompuestosInfoCompleta
        /// <summary>
        /// Gets the impuestos compuestos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetImpuestosCompuestosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.IMPUESTOS_COMPUESTOS_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPorcentajePorId

        #region GetPorcentajeTotal
        /// <summary>
        /// Gets the porcentaje total.
        /// </summary>
        /// <param name="impuesto_padre_id">The impuesto_padre_id.</param>
        /// <returns></returns>
        public static decimal GetPorcentajeTotal(decimal impuesto_padre_id)
        {
            using (SessionService sesion = new SessionService())
            {
                IMPUESTOS_COMPUESTOS_INFO_COMPRow[] rows = sesion.db.IMPUESTOS_COMPUESTOS_INFO_COMPCollection.GetAsArray(ImpuestosCompuestosService.ImpuestoPadreId_NombreCol + " = " + impuesto_padre_id, string.Empty);
                decimal porcentaje = 0;

                if (rows.Length <= 0)
                {
                    porcentaje = Definiciones.Error.Valor.EnteroPositivo;
                }
                else
                {
                    //Se suma el porcentaje del impuesto simple dividido el porcentaje de incidencia
                    for (int i = 0; i < rows.Length; i++)
                        porcentaje += rows[i].IMPUESTO_HIJO_PORCENTAJE * rows[i].PORCENTAJE / 100;
                }
                
                return porcentaje;
            }
        }
        #endregion GetPorcentajeTotal

        #region EsInteresCompuesto
        public static bool EsInteresCompuesto(decimal impuesto_padre_id)
        {
            using (SessionService sesion = new SessionService())
            {
                IMPUESTOS_COMPUESTOS_INFO_COMPRow[] rows = sesion.db.IMPUESTOS_COMPUESTOS_INFO_COMPCollection.GetAsArray(ImpuestosCompuestosService.ImpuestoPadreId_NombreCol + " = " + impuesto_padre_id, string.Empty);
            
                return rows.Length > 0;
            }
        }
        #endregion EsInteresCompuesto


        #region GetCongtieneGravado
        /// <summary>
        /// Gets the congtiene gravado.
        /// </summary>
        /// <param name="impuesto_padre_id">The impuesto_padre_id.</param>
        /// <param name="impuesto_hijo_id">The impuesto_hijo_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static bool GetContieneGravado(decimal impuesto_padre_id, decimal impuesto_hijo_id, SessionService sesion)
        {
            string clausulas = ImpuestosCompuestosService.ImpuestoPadreId_NombreCol + " = " + impuesto_padre_id + " and " +
                               ImpuestosCompuestosService.ImpuestoHijoId_NombreCol + " = " + impuesto_hijo_id;
            IMPUESTOS_COMPUESTOSRow[] rows = sesion.db.IMPUESTOS_COMPUESTOSCollection.GetAsArray(clausulas, string.Empty);
            return rows.Length > 0;
        }
        #endregion GetCongtieneGravado

        #region Accesors

        public static string Nombre_Tabla
        {
            get { return "IMPUESTOS_COMPUESTOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "IMPUESTOS_COMPUESTOS_INFO_COMP"; }
        }
        public static string Id_NombreCol
        {
            get { return IMPUESTOS_COMPUESTOSCollection.IDColumnName; }
        }
        public static string ImpuestoHijoId_NombreCol
        {
            get { return IMPUESTOS_COMPUESTOSCollection.IMPUESTO_HIJO_IDColumnName; }
        }
        public static string ImpuestoPadreId_NombreCol
        {
            get { return IMPUESTOS_COMPUESTOSCollection.IMPUESTO_PADRE_IDColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return IMPUESTOS_COMPUESTOSCollection.PORCENTAJEColumnName; }
        }
        public static string VistaImpuestoHijoNombre_NombreCol
        {
            get { return IMPUESTOS_COMPUESTOS_INFO_COMPCollection.IMPUESTO_HIJO_NOMBREColumnName; }
        }
        public static string VistaImpuestoHijoPorcentaje_NombreCol
        {
            get { return IMPUESTOS_COMPUESTOS_INFO_COMPCollection.IMPUESTO_HIJO_PORCENTAJEColumnName; }
        }
        public static string VistaImpuestoPadreNombre_NombreCol
        {
            get { return IMPUESTOS_COMPUESTOS_INFO_COMPCollection.IMPUESTO_PADRE_NOMBREColumnName; }
        }
        #endregion Accesors
    }
}
