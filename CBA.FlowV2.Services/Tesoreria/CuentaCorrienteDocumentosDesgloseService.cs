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
    public class CuentaCorrienteDocumentosDesgloseService
    {
        #region GetCuentaCorrienteDocumentosDesgloseDataTable
        /// <summary>
        /// Gets the cuenta corriente documentos desglose data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrienteDocumentosDesgloseDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_DOCUMENTOS_DESGLOSECollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCuentaCorrienteDocumentosDesgloseDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            CTACTE_DOCUMENTOS_DESGLOSERow row = new CTACTE_DOCUMENTOS_DESGLOSERow();
            string valorAnterior = Definiciones.Log.RegistroNuevo;

            row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_documentos_des_sqc");

            row.CTACTE_DOCUMENTO_ID = (decimal)campos[CuentaCorrienteDocumentosDesgloseService.CtaCteDocumentoId_NombreCol];
            row.IMPUESTO_ID = (decimal)campos[CuentaCorrienteDocumentosDesgloseService.ImpuestoId_NombreCol];
            row.MONTO = (decimal)campos[CuentaCorrienteDocumentosDesgloseService.Monto_NombreCol];

            sesion.Db.CTACTE_DOCUMENTOS_DESGLOSECollection.Insert(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_DOCUMENTOS_DESGLOSE"; }
        }
        public static string CtaCteDocumentoId_NombreCol
        {
            get { return CTACTE_DOCUMENTOS_DESGLOSECollection.CTACTE_DOCUMENTO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_DOCUMENTOS_DESGLOSECollection.IDColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return CTACTE_DOCUMENTOS_DESGLOSECollection.IMPUESTO_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTACTE_DOCUMENTOS_DESGLOSECollection.MONTOColumnName; }
        }
        #endregion Accessors
    }
}
