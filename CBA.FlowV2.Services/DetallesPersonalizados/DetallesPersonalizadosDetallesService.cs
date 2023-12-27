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
    public class DetallesPersonalizadosDetallesService
    {
        #region GetDataTableGenerada
        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <param name="tipoDetallePersonalizado">The tipo detalle personalizado.</param>
        /// <param name="tabla_id">The tabla_id.</param>
        /// <param name="columna">The columna.</param>
        /// <param name="registro_id">The registro_id.</param>
        /// <returns></returns>
        public static DataTable GetDataTableGenerada(decimal tipoDetallePersonalizado, string tabla_id, string columna, string registro_id)
        {
            DataTable dt = new DataTable();
            decimal[] registros;

            switch((int)tipoDetallePersonalizado){
                case (int)Definiciones.TiposDetallesPersonalizado.Direccion:
                    throw(new NotImplementedException("GetDataTable().Tipo de Detalle Personalizado no implementado"));
                    break;
                case (int)Definiciones.TiposDetallesPersonalizado.ReferenciasCreditoTerceros:
                    registros = DetallesPersonalizadosService.GetDetallesPersonalizados(new decimal[] { Definiciones.TiposDetallesPersonalizado.ReferenciasCreditoTerceros },
                                                                                        tabla_id, columna, registro_id, true);
                    #region prepararColumnas
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.DetallePersonalizadoId_NombreCol, typeof(decimal));

                    //Entidad@!@Monto@!@Plazo@!@Fecha Aprobación@!@Moneda@!@Monto Cuota@!@Número de Cuota@!@Promedio Atraso@!@Máximo Atraso@!@Cancelado
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.Entidad_NombreCol, typeof(decimal));
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.Monto_NombreCol, typeof(decimal));
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.Plazo_NombreCol, typeof(decimal));
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.FechaAprobacion_NombreCol, typeof(DateTime));
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.Moneda_NombreCol, typeof(decimal));
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.MontoCuota_NombreCol, typeof(decimal));
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.NumeroCuota_NombreCol, typeof(decimal));
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.PromedioAtraso_NombreCol, typeof(decimal));
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.MaximoAtraso_NombreCol, typeof(decimal));
                    dt.Columns.Add(TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.Cancelado_NombreCol, typeof(string));
                    #endregion prepararColumnas

                    #region obtener valores
                    foreach (decimal registro in registros)
                    {
                        object[] valores = DetallesPersonalizadosDetallesService.GetValores(registro);

                        DataRow newRow = dt.NewRow();

                        //Nombre@!@Codigo@!@Observacion@!@Estado
                        newRow[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.DetallePersonalizadoId_NombreCol] = decimal.Parse(registro_id);
                        newRow[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.Entidad_NombreCol] = valores[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.Entidad_PosicionValor].ToString();
                        newRow[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.Monto_NombreCol] = valores[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.Monto_PosicionValor].ToString();
                        newRow[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.Plazo_NombreCol] = valores[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.Plazo_PosicionValor].ToString();
                        newRow[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.FechaAprobacion_NombreCol] = valores[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.FechaAprobacion_PosicionValor].ToString();
                        newRow[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.Moneda_NombreCol] = valores[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.Moneda_PosicionValor].ToString();
                        newRow[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.MontoCuota_NombreCol] = valores[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.MontoCuota_PosicionValor].ToString();
                        newRow[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.NumeroCuota_NombreCol] = valores[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.NumeroCuota_PosicionValor].ToString();
                        newRow[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.PromedioAtraso_NombreCol] = valores[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.PromedioAtraso_PosicionValor].ToString();
                        newRow[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.MaximoAtraso_NombreCol] = valores[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.MaximoAtraso_PosicionValor].ToString();
                        newRow[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.Cancelado_NombreCol] = valores[TiposDetallesPersonalizadosService.ReferenciasCreditoTerceros.Cancelado_PosicionValor].ToString();

                        dt.Rows.Add(newRow);
                    }
                    #endregion obtener valores

                    break;
                case (int)Definiciones.TiposDetallesPersonalizado.ReferenciasPersonales:
                    throw(new NotImplementedException("GetDataTable().Tipo de Detalle Personalizado no implementado"));
                    break;
                case (int)Definiciones.TiposDetallesPersonalizado.ProveedorPersonaAutorizada:
                    registros = DetallesPersonalizadosService.GetDetallesPersonalizados(new decimal[] { Definiciones.TiposDetallesPersonalizado.ProveedorPersonaAutorizada },
                                                                                        tabla_id, columna, registro_id, true);
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
                        object[] valores = DetallesPersonalizadosDetallesService.GetValores(registro);

                        DataRow newRow = dt.NewRow();

                        //Nombre@!@Codigo@!@Observacion@!@Estado
                        newRow[TiposDetallesPersonalizadosService.ProveedorPersonaAutorizada.DetallePersonalizadoId_NombreCol] = decimal.Parse(registro_id);
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
        #endregion GetDataTableGenerada

        #region GetDetallesPersonalizadosDetalleDataTable
        /// <summary>
        /// Gets the detalles personalizados detalle data table.
        /// </summary>
        /// <param name="detalle_personalizado_id">The detalle_personalizado_id.</param>
        /// <returns></returns>
        public static DataTable GetDetallesPersonalizadosDetalleDataTable(decimal detalle_personalizado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DETALLES_PERSONALIZADOS_DETCollection.GetByDETALLE_PERSONALIZADO_IDAsDataTable(detalle_personalizado_id);
            }
        }
        #endregion GetDetallesPersonalizadosDetalleDataTable

        #region GetValores
        /// <summary>
        /// Gets the valores.
        /// </summary>
        /// <param name="detalle_personalizado_id">The detalle_personalizado_id.</param>
        /// <returns></returns>
        public static object[] GetValores(decimal detalle_personalizado_id)
        {
            string[] titulos;
            int[] tiposDatos;
            decimal[] orden;
            bool[] obligatorios, disparanAlarma;
            object[] valores;
            DataTable dt;
            int indice;

            TiposDetallesPersonalizadosService.GetEstructura(Definiciones.TiposDetallesPersonalizado.Direccion, out titulos, out tiposDatos, out orden, out obligatorios, out disparanAlarma);
            dt = DetallesPersonalizadosDetallesService.GetDetallesPersonalizadosDetalleDataTable(detalle_personalizado_id);
            valores = new object[dt.Rows.Count];

            for (int i = 0; i < valores.Length; i++)
            { 
                indice = int.Parse(dt.Rows[i][DetallesPersonalizadosDetallesService.Orden_NombreCol].ToString());

                if (!dt.Rows[i][DetallesPersonalizadosDetallesService.ValorFecha_NombreCol].Equals(DBNull.Value))
                    valores[indice] = dt.Rows[i][DetallesPersonalizadosDetallesService.ValorFecha_NombreCol];
                else if (!dt.Rows[i][DetallesPersonalizadosDetallesService.ValorNumero_NombreCol].Equals(DBNull.Value))
                    valores[indice] = dt.Rows[i][DetallesPersonalizadosDetallesService.ValorNumero_NombreCol];
                else if (!dt.Rows[i][DetallesPersonalizadosDetallesService.ValorTexto_NombreCol].Equals(DBNull.Value))
                    valores[indice] = dt.Rows[i][DetallesPersonalizadosDetallesService.ValorTexto_NombreCol];
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
        /// <param name="detalle_personalizado_id">The detalle_personalizado_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal detalle_personalizado_id, SessionService sesion)
        {
            DETALLES_PERSONALIZADOS_DETRow[] rows = sesion.Db.DETALLES_PERSONALIZADOS_DETCollection.GetByDETALLE_PERSONALIZADO_ID(detalle_personalizado_id);

            for (int i = 0; i < rows.Length; i++)
                LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[i].ID, rows[i].ToString(), Definiciones.Log.RegistroBorrado, sesion);

            sesion.Db.DETALLES_PERSONALIZADOS_DETCollection.DeleteByDETALLE_PERSONALIZADO_ID(detalle_personalizado_id);
        }
        #endregion Borrar

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="valores">The valores.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos, bool crear_nuevos, SessionService sesion)
        {
            DETALLES_PERSONALIZADOS_DETRow row;
            string valorAnterior = string.Empty, clausulas;

            if (crear_nuevos)
            {
                row = new DETALLES_PERSONALIZADOS_DETRow();
                valorAnterior = Definiciones.Log.RegistroNuevo;
                row.ID = sesion.Db.GetSiguienteSecuencia("detalles_personaliz_det_sqc");

                row.DETALLE_PERSONALIZADO_ID = (decimal)campos[DetallesPersonalizadosDetallesService.DetallePersonalizadoId_NombreCol];
                row.ORDEN = (decimal)campos[DetallesPersonalizadosDetallesService.Orden_NombreCol]; 
            }
            else
            {
                clausulas = DetallesPersonalizadosDetallesService.DetallePersonalizadoId_NombreCol + " = " + campos[DetallesPersonalizadosDetallesService.DetallePersonalizadoId_NombreCol] + " and " +
                            DetallesPersonalizadosDetallesService.Orden_NombreCol + " = " + campos[DetallesPersonalizadosDetallesService.Orden_NombreCol];

                row = sesion.Db.DETALLES_PERSONALIZADOS_DETCollection.GetAsArray(clausulas, string.Empty)[0];
                valorAnterior = row.ToString();
            }

            if (campos.Contains(DetallesPersonalizadosDetallesService.ValorFecha_NombreCol))
                row.VALOR_FECHA = (DateTime)campos[DetallesPersonalizadosDetallesService.ValorFecha_NombreCol];
            else
                row.IsVALOR_FECHANull = true;

            if (campos.Contains(DetallesPersonalizadosDetallesService.ValorNumero_NombreCol))
                row.VALOR_NUMERO = (decimal)campos[DetallesPersonalizadosDetallesService.ValorNumero_NombreCol];
            else
                row.IsVALOR_NUMERONull = true;

            if (campos.Contains(DetallesPersonalizadosDetallesService.ValorTexto_NombreCol))
                row.VALOR_TEXTO = (string)campos[DetallesPersonalizadosDetallesService.ValorTexto_NombreCol];
            else
                row.VALOR_TEXTO = string.Empty;

            if (crear_nuevos) sesion.Db.DETALLES_PERSONALIZADOS_DETCollection.Insert(row);
            else sesion.Db.DETALLES_PERSONALIZADOS_DETCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "DETALLES_PERSONALIZADOS_DET"; }
        }
        public static string DetallePersonalizadoId_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_DETCollection.DETALLE_PERSONALIZADO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_DETCollection.IDColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_DETCollection.ORDENColumnName; }
        }
        public static string ValorFecha_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_DETCollection.VALOR_FECHAColumnName; }
        }
        public static string ValorNumero_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_DETCollection.VALOR_NUMEROColumnName; }
        }
        public static string ValorTexto_NombreCol
        {
            get { return DETALLES_PERSONALIZADOS_DETCollection.VALOR_TEXTOColumnName; }
        }
        #endregion Accessors
    }
}
