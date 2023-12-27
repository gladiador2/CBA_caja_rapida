#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.IO;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.DetallesPersonalizados
{
    public class DetallesPersonalizadosHistoricoDetallesService
    {

        #region GetDataTable
        public static DataTable GetDataTable(decimal tipoDetallePersonalizado, string tablaId, string columna, string registroId, decimal caso_id)
        {
            DataTable dt = new DataTable();
            switch((int)tipoDetallePersonalizado){
                case (int)Definiciones.TiposDetallesPersonalizado.Direccion:
                    throw(new NotImplementedException("GetDataTable().Tipo de Detalle Personalizado no implementado"));
                    break;
                case (int)Definiciones.TiposDetallesPersonalizado.ReferenciasCreditoTerceros:
                    throw(new NotImplementedException("GetDataTable().Tipo de Detalle Personalizado no implementado"));
                    break;
                case (int)Definiciones.TiposDetallesPersonalizado.ReferenciasPersonales:
                    throw(new NotImplementedException("GetDataTable().Tipo de Detalle Personalizado no implementado"));
                    break;
                case (int)Definiciones.TiposDetallesPersonalizado.ProveedorPersonaAutorizada:
                    decimal[] registros = DetallesPersonalizadosHistoricoService.GetDetallesPersonalizados(new decimal[] { Definiciones.TiposDetallesPersonalizado.ProveedorPersonaAutorizada },
                                                                                                                   tablaId, columna, registroId, true, caso_id);
                    #region prepararColumnas
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ProveedorPersonaAutorizada.DetallePersonalizadoId_NombreCol, typeof(decimal));

                    //Nombre@!@Codigo@!@Observacion@!@Estado
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ProveedorPersonaAutorizada.Nombre_NombreCol, typeof(string));
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ProveedorPersonaAutorizada.Codigo_NombreCol, typeof(string));
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ProveedorPersonaAutorizada.Observacion_NombreCol, typeof(string));
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ProveedorPersonaAutorizada.Estado_NombreCol, typeof(string));
                    #endregion prepararColumnas

                    #region obtener valores
                    foreach (decimal registro in registros)
                    {
                        object[] valores = DetallesPersonalizadosHistoricoDetallesService.GetValores(registro);

                        DataRow newRow = dt.NewRow();

                        //Nombre@!@Codigo@!@Observacion@!@Estado
                        newRow[TiposDetallesPersonalizadosService.ProveedorPersonaAutorizada.DetallePersonalizadoId_NombreCol] = decimal.Parse(registroId);
                        newRow[TiposDetallesPersonalizadosService.ProveedorPersonaAutorizada.Nombre_NombreCol] = valores[TiposDetallesPersonalizadosService.ProveedorPersonaAutorizada.Nombre_PosicionValor].ToString();
                        newRow[TiposDetallesPersonalizadosService.ProveedorPersonaAutorizada.Codigo_NombreCol] = valores[TiposDetallesPersonalizadosService.ProveedorPersonaAutorizada.Codigo_PosicionValor].ToString();
                        newRow[TiposDetallesPersonalizadosService.ProveedorPersonaAutorizada.Observacion_NombreCol] = valores[TiposDetallesPersonalizadosService.ProveedorPersonaAutorizada.Observacion_PosicionValor].ToString();
                        newRow[TiposDetallesPersonalizadosService.ProveedorPersonaAutorizada.Estado_NombreCol] = valores[TiposDetallesPersonalizadosService.ProveedorPersonaAutorizada.Estado_PosicionValor].ToString();

                        dt.Rows.Add(newRow);
                    }
                    #endregion obtener valores

                    break;
                case (int)Definiciones.TiposDetallesPersonalizado.SolicitudReferenciaProveedor:
                    throw(new NotImplementedException("GetDataTable().Tipo de Detalle Personalizado no implementado"));
                    break;
                default:
                    throw (new NotImplementedException("GetDataTable().Tipo de Detalle Personalizado no está en el switch"));
                    
            }
            return dt;
        }
        #endregion GetDataTable

        #region GetDetallesPersonalizadosDetalleDataTable
        /// <summary>
        /// Gets the detalles personalizados detalle data table.
        /// </summary>
        /// <param name="detalle_personalizado_historico_id">The detalle_personalizado_historico_id.</param>
        /// <returns></returns>
        private static DataTable GetDetallesPersonalizadosDetalleDataTable(decimal detalle_personalizado_historico_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DETALLES_PERSONALIZADOS_HIST_DCollection.GetByDETALLE_PERSONALIZADO_HIST_IDAsDataTable(detalle_personalizado_historico_id);
            }
        }
        #endregion GetDetallesPersonalizadosDetalleDataTable

        #region GetValores
        /// <summary>
        /// Gets the valores.
        /// </summary>
        /// <param name="detalle_personalizado_historico_id">The detalle_personalizado_historico_id.</param>
        /// <returns></returns>
        public static object[] GetValores(decimal detalle_personalizado_historico_id)
        {
            string[] titulos;
            int[] tiposDatos;
            decimal[] orden;
            bool[] obligatorios, disparanAlarma;
            object[] valores;
            DataTable dt;
            int indice;

            TiposDetallesPersonalizadosService.GetEstructura(Definiciones.TiposDetallesPersonalizado.Direccion, out titulos, out tiposDatos, out orden, out obligatorios, out disparanAlarma);
            dt = DetallesPersonalizadosHistoricoDetallesService.GetDetallesPersonalizadosDetalleDataTable(detalle_personalizado_historico_id);
            valores = new object[dt.Rows.Count];

            for (int i = 0; i < valores.Length; i++)
            {
                indice = int.Parse(dt.Rows[i][DetallesPersonalizadosHistoricoDetallesService.Orden_NombreCol].ToString());

                if (!dt.Rows[i][DetallesPersonalizadosHistoricoDetallesService.ValorFecha_NombreCol].Equals(DBNull.Value))
                    valores[indice] = dt.Rows[i][DetallesPersonalizadosHistoricoDetallesService.ValorFecha_NombreCol];
                else if (!dt.Rows[i][DetallesPersonalizadosHistoricoDetallesService.ValorNumero_NombreCol].Equals(DBNull.Value))
                    valores[indice] = dt.Rows[i][DetallesPersonalizadosHistoricoDetallesService.ValorNumero_NombreCol];
                else if (!dt.Rows[i][DetallesPersonalizadosHistoricoDetallesService.ValorTexto_NombreCol].Equals(DBNull.Value))
                    valores[indice] = dt.Rows[i][DetallesPersonalizadosHistoricoDetallesService.ValorTexto_NombreCol];
                else
                    valores[indice] = null;
            }

            return valores;
        }
        #endregion GetValores

        #region Borrar
        /// <summary>
        /// Borrars the specified detalle_personalizado_id.
        /// </summary>
        /// <param name="detalle_personalizado_historico_id">The detalle_personalizado_historico_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal detalle_personalizado_historico_id, SessionService sesion)
        {
            sesion.Db.DETALLES_PERSONALIZADOS_HIST_DCollection.DeleteByDETALLE_PERSONALIZADO_HIST_ID(detalle_personalizado_historico_id);
        }
        #endregion Borrar

        #region Guardar
        /// <summary>
        /// Guardars the specified detalle_personalizado_historico_id.
        /// </summary>
        /// <param name="detalle_personalizado_historico_id">The detalle_personalizado_historico_id.</param>
        /// <param name="valor">The valor.</param>
        /// <param name="es_numero">if set to <c>true</c> [es_numero].</param>
        /// <param name="es_texto">if set to <c>true</c> [es_texto].</param>
        /// <param name="es_fecha">if set to <c>true</c> [es_fecha].</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Guardar(decimal detalle_personalizado_historico_id, object valor, bool es_numero, bool es_texto, bool es_fecha, decimal orden, SessionService sesion)
        {
            DETALLES_PERSONALIZADOS_HIST_DRow row = new DETALLES_PERSONALIZADOS_HIST_DRow();
            
            row.ID = sesion.Db.GetSiguienteSecuencia("detalles_personaliz_hist_d_sqc");
            row.DETALLE_PERSONALIZADO_HIST_ID = detalle_personalizado_historico_id;
            row.ORDEN = orden;

            if (es_numero) row.VALOR_NUMERO = (decimal)valor;
            if (es_texto) row.VALOR_TEXTO = valor == null || valor.Equals(DBNull.Value) ? string.Empty : (string)valor;
            if (es_fecha) row.VALOR_FECHA = (DateTime)valor;

            sesion.Db.DETALLES_PERSONALIZADOS_HIST_DCollection.Insert(row);
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "DETALLES_PERSONALIZADOS_HIST_D"; }
        }
        public static string DetallePersonalizadoHistId_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HIST_DCollection.DETALLE_PERSONALIZADO_HIST_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HIST_DCollection.IDColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HIST_DCollection.ORDENColumnName; }
        }
        public static string ValorFecha_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HIST_DCollection.VALOR_FECHAColumnName; }
        }
        public static string ValorNumero_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HIST_DCollection.VALOR_NUMEROColumnName; }
        }
        public static string ValorTexto_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_HIST_DCollection.VALOR_TEXTOColumnName; }
        }
        #endregion Accessors
    }
}
