using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class DescuentoDocumentosClienteDetalleDesgloseService
    {
        #region GetDescuentoDocumentosClienteDetalleDesgloseDataTable
        /// <summary>
        /// Descuentoes the documentos cliente detalle desglose data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetDescuentoDocumentosClienteDetalleDesgloseDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESCUENTO_DOC_CLI_DET_DESGLOSECollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetDescuentoDocumentosClienteDetalleDesgloseDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            DESCUENTO_DOC_CLI_DET_DESGLOSERow row = new DESCUENTO_DOC_CLI_DET_DESGLOSERow();
            row.ID = sesion.Db.GetSiguienteSecuencia("descuento_doc_cli_det_desg_sqc");

            row.DESCUENTO_DOCUMENTO_DET_ID = (decimal)campos[DescuentoDocumentosClienteDetalleDesgloseService.DescuentoDocumentoDetId_NombreCol];
            row.IMPUESTO_ID = (decimal)campos[DescuentoDocumentosClienteDetalleDesgloseService.ImpuestoId_NombreCol];
            row.MONTO = (decimal)campos[DescuentoDocumentosClienteDetalleDesgloseService.Monto_NombreCol];

            sesion.Db.DESCUENTO_DOC_CLI_DET_DESGLOSECollection.Insert(row);
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified descuento_documento_cliente_detalle_id.
        /// </summary>
        /// <param name="descuento_documento_cliente_detalle_id">The descuento_documento_cliente_detalle_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal descuento_documento_cliente_detalle_id, SessionService sesion)
        {
            sesion.Db.DESCUENTO_DOC_CLI_DET_DESGLOSECollection.DeleteByDESCUENTO_DOCUMENTO_DET_ID(descuento_documento_cliente_detalle_id);
        }

        /// <summary>
        /// Borrars the specified descuento_documento_cliente_detalle_desglose_id.
        /// </summary>
        /// <param name="descuento_documento_cliente_detalle_desglose_id">The descuento_documento_cliente_detalle_desglose_id.</param>
        private static void Borrar(decimal descuento_documento_cliente_detalle_desglose_id)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.Db.DESCUENTO_DOC_CLI_DET_DESGLOSECollection.DeleteByPrimaryKey(descuento_documento_cliente_detalle_desglose_id);
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "DESCUENTO_DOC_CLI_DET_DESGLOSE"; }
        }
        public static string DescuentoDocumentoDetId_NombreCol
        {
            get { return DESCUENTO_DOC_CLI_DET_DESGLOSECollection.DESCUENTO_DOCUMENTO_DET_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DESCUENTO_DOC_CLI_DET_DESGLOSECollection.IDColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return DESCUENTO_DOC_CLI_DET_DESGLOSECollection.IMPUESTO_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return DESCUENTO_DOC_CLI_DET_DESGLOSECollection.MONTOColumnName; }
        }
        #endregion Accessors
    }
}
