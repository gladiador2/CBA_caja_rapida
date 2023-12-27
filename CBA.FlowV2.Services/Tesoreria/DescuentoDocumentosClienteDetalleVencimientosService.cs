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
    public class DescuentoDocumentosClienteDetalleVencimientosService
    {
        #region GetDescuentoDocumentosClienteDetalleVencimientosConSesion
        /// <summary>
        /// Gets the descuento documentos cliente detalle vencimientos con sesion.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetDescuentoDocumentosClienteDetalleVencimientosConSesion(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.DESCUENTO_DOC_CLI_DET_VENCIMCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetDescuentoDocumentosClienteDetalleVencimientosConSesion

        #region GetDescuentoDocumentosClienteDetalleVencimientosDataTable
        /// <summary>
        /// Descuentoes the documentos cliente detalle vencimientos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetDescuentoDocumentosClienteDetalleVencimientosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESCUENTO_DOC_CLI_DET_VENCIMCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetDescuentoDocumentosClienteDetalleVencimientosDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="descuento_documento_cliente_det_id">The descuento_documento_cliente_det_id.</param>
        /// <param name="campos">The campos.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Guardar(decimal descuento_documento_cliente_det_id, System.Collections.Hashtable[] campos, SessionService sesion)
        {
            //Borrar los datos anteriores
            DescuentoDocumentosClienteDetalleVencimientosService.Borrar(descuento_documento_cliente_det_id, sesion);

            //Crear los vencimientos
            for (int i = 0; i < campos.Length; i++)
            {
                if ((decimal)campos[i][DescuentoDocumentosClienteDetalleVencimientosService.Monto_NombreCol] <= 0) continue;
                DescuentoDocumentosClienteDetalleVencimientosService.Guardar(descuento_documento_cliente_det_id, campos[i], sesion);
            }
        }

        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="descuento_documento_cliente_det_id">The descuento_documento_cliente_det_id.</param>
        /// <param name="campos">The campos.</param>
        /// <param name="sesion">The sesion.</param>
        private static void Guardar(decimal descuento_documento_cliente_det_id, System.Collections.Hashtable campos, SessionService sesion)
        {
            DESCUENTO_DOC_CLI_DET_VENCIMRow row = new DESCUENTO_DOC_CLI_DET_VENCIMRow();
            row.ID = sesion.Db.GetSiguienteSecuencia("descuento_doc_cli_det_venc_sqc");
            row.DESCUENTO_DOCUMENTO_DET_ID = descuento_documento_cliente_det_id;
            row.FECHA_VENCIMIENTO = (DateTime)campos[DescuentoDocumentosClienteDetalleVencimientosService.FechaVencimiento_NombreCol];
            row.MONTO = (decimal)campos[DescuentoDocumentosClienteDetalleVencimientosService.Monto_NombreCol];

            sesion.Db.DESCUENTO_DOC_CLI_DET_VENCIMCollection.Insert(row);
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
            sesion.Db.DESCUENTO_DOC_CLI_DET_VENCIMCollection.DeleteByDESCUENTO_DOCUMENTO_DET_ID(descuento_documento_cliente_detalle_id);
        }

        /// <summary>
        /// Borrars the specified descuento_documento_cliente_detalle_vencimiento_id.
        /// </summary>
        /// <param name="descuento_documento_cliente_detalle_vencimiento_id">The descuento_documento_cliente_detalle_vencimiento_id.</param>
        public static void Borrar(decimal descuento_documento_cliente_detalle_vencimiento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.Db.DESCUENTO_DOC_CLI_DET_VENCIMCollection.DeleteByPrimaryKey(descuento_documento_cliente_detalle_vencimiento_id);
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "DESCUENTO_DOC_CLI_DET_VENCIM"; }
        }
        public static string DescuentoDocumentoDetId_NombreCol
        {
            get { return DESCUENTO_DOC_CLI_DET_VENCIMCollection.DESCUENTO_DOCUMENTO_DET_IDColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return DESCUENTO_DOC_CLI_DET_VENCIMCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DESCUENTO_DOC_CLI_DET_VENCIMCollection.IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return DESCUENTO_DOC_CLI_DET_VENCIMCollection.MONTOColumnName; }
        }
        #endregion Accessors
    }
}
