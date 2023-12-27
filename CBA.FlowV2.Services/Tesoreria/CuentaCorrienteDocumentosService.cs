using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using System.Data;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteDocumentosService
    {
        #region GetCuentaCorrienteDocumentosDataTable
        /// <summary>
        /// Gets the cuenta corriente documentos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrienteDocumentosDataTable(string clausulas, string orden)
        { 
            using(SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_DOCUMENTOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCuentaCorrienteDocumentosDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            CTACTE_DOCUMENTOSRow row = new CTACTE_DOCUMENTOSRow();
            string valorAnterior = Definiciones.Log.RegistroNuevo;

            row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_documentos_sqc");

            row.PERSONA_ID = (decimal)campos[CuentaCorrienteDocumentosService.PersonaId_NombreCol];
            row.COTIZACION_MONEDA = (decimal)campos[CuentaCorrienteDocumentosService.CotizacionMoneda_NombreCol];
            row.CTACTE_VALOR_ID = (decimal)campos[CuentaCorrienteDocumentosService.CtacteValorId_NombreCol];
            row.FECHA_CREACION = (DateTime)campos[CuentaCorrienteDocumentosService.FechaCreacion_NombreCol];
            row.MONEDA_ID = (decimal)campos[CuentaCorrienteDocumentosService.MonedaId_NombreCol];
            row.NOMBRE_BENEFICIARIO = (string)campos[CuentaCorrienteDocumentosService.NombreBeneficiario_NombreCol];
            row.NOMBRE_DEUDOR = (string)campos[CuentaCorrienteDocumentosService.NombreDeudor_NombreCol];
            row.NRO_COMPROBANTE = (string)campos[CuentaCorrienteDocumentosService.NroComprobante_NombreCol];
            row.OBSERVACION = (string)campos[CuentaCorrienteDocumentosService.Observacion_NombreCol];
            row.TOTAL_BRUTO = (decimal)campos[CuentaCorrienteDocumentosService.TotalBruto_NombreCol];
            row.TOTAL_RETENCION = (decimal)campos[CuentaCorrienteDocumentosService.TotalRetencion_NombreCol];
        
            //Si el documento fue creado por un descuento de documentos a cliente
            if (campos.Contains(CuentaCorrienteDocumentosService.DescDocCliDetId_NombreCol))
                row.DESC_DOC_CLI_DET_ID = (decimal)campos[CuentaCorrienteDocumentosService.DescDocCliDetId_NombreCol];

            sesion.Db.CTACTE_DOCUMENTOSCollection.Insert(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }
        #endregion Guardar

        #region Accessors

        public static string Nombre_Tabla
        {
            get { return "CTACTE_DOCUMENTOS"; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_DOCUMENTOSCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return CTACTE_DOCUMENTOSCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string DescDocCliDetId_NombreCol
        {
            get { return CTACTE_DOCUMENTOSCollection.DESC_DOC_CLI_DET_IDColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return CTACTE_DOCUMENTOSCollection.FECHA_CREACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_DOCUMENTOSCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_DOCUMENTOSCollection.MONEDA_IDColumnName; }
        }
        public static string NombreBeneficiario_NombreCol
        {
            get { return CTACTE_DOCUMENTOSCollection.NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string NombreDeudor_NombreCol
        {
            get { return CTACTE_DOCUMENTOSCollection.NOMBRE_DEUDORColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return CTACTE_DOCUMENTOSCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CTACTE_DOCUMENTOSCollection.OBSERVACIONColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return CTACTE_DOCUMENTOSCollection.PERSONA_IDColumnName; }
        }
        public static string TotalBruto_NombreCol
        {
            get { return CTACTE_DOCUMENTOSCollection.TOTAL_BRUTOColumnName; }
        }
        public static string TotalRetencion_NombreCol
        {
            get { return CTACTE_DOCUMENTOSCollection.TOTAL_RETENCIONColumnName; }
        }
        #endregion Accessors
    }
}
