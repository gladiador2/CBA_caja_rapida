using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Data;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteDocumentosVencimientosService
    {
        #region GetCuentaCorrienteDocumentosVencimientosDataTable
        /// <summary>
        /// Gets the cuenta corriente documentos vencimientos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrienteDocumentosVencimientosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrienteDocumentosVencimientosDataTable(clausulas, orden, sesion);
            }
        }

        /// <summary>
        /// Gets the cuenta corriente documentos vencimientos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrienteDocumentosVencimientosDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_DOCUMENTOS_VENCIMIENTOSCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCuentaCorrienteDocumentosVencimientosDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            CTACTE_DOCUMENTOS_VENCIMIENTOSRow row = new CTACTE_DOCUMENTOS_VENCIMIENTOSRow();
            string valorAnterior = Definiciones.Log.RegistroNuevo;

            row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_documentos_ven_sqc");

            row.CTACTE_DOCUMENTO_ID = (decimal)campos[CuentaCorrienteDocumentosVencimientosService.CtaCteDocumentoId_NombreCol];
            row.FECHA_VENCIMIENTO = (DateTime)campos[CuentaCorrienteDocumentosVencimientosService.FechaVencimiento_NombreCol];
            row.MONTO = (decimal)campos[CuentaCorrienteDocumentosVencimientosService.Monto_NombreCol];

            sesion.Db.CTACTE_DOCUMENTOS_VENCIMIENTOSCollection.Insert(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_DOCUMENTOS_VENCIMIENTOS"; }
        }
        public static string CtaCteDocumentoId_NombreCol
        {
            get { return CTACTE_DOCUMENTOS_VENCIMIENTOSCollection.CTACTE_DOCUMENTO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_DOCUMENTOS_VENCIMIENTOSCollection.IDColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return CTACTE_DOCUMENTOS_VENCIMIENTOSCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTACTE_DOCUMENTOS_VENCIMIENTOSCollection.MONTOColumnName; }
        }
        #endregion Accessors
    }
}
