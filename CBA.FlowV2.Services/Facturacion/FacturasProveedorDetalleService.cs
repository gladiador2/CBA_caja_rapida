#region using
using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.TextosPredefinidos;
#endregion using

namespace CBA.FlowV2.Services.Facturacion
{
    public class FacturasProveedorDetalleService
    {
        #region Sub clase propiedades detalle
        [Serializable]
        public class PropiedadesDetalle
        {
            public decimal FacturaProveedorId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal ActivoId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal ArticuloId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal LoteId = Definiciones.Error.Valor.EnteroPositivo;
            public string Observacion = string.Empty;
            public decimal PrecioBrutoUnitarioDestino = Definiciones.Error.Valor.EnteroPositivo;
            public decimal PorcentajeDescuento = 0;
            public decimal PorcentajeImpuesto = Definiciones.Error.Valor.EnteroPositivo;
            public decimal CantidadEmbaladaDestino = 0;
            public decimal CantidadUnitariaDestino = 0;
            public bool AfectaStock = true;
        }
        #endregion Sub clase propiedades detalle

        #region VerificarLoteRepetido
        /// <summary>
        /// Verificars the lote repetido.
        /// </summary>
        /// <param name="factura_proveedor_id">The factura_proveedor_id.</param>
        /// <param name="lote_id">The lote_id.</param>
        /// <returns></returns>
        public bool VerificarLoteRepetido(decimal factura_proveedor_id, decimal lote_id)
        {
            using (SessionService sesion = new SessionService())
            {
                if (lote_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    throw new Exception("Error en VerificarLoteRepetido. Debe especificarse el lote a consultar.");
                }

                string clausulas = FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + factura_proveedor_id + " and " +
                                   FacturasProveedorDetalleService.LoteId_NombreCol + " = " + lote_id;

                DataTable dt = sesion.Db.FACTURAS_PROVEEDOR_DETALLECollection.GetAsDataTable(clausulas, string.Empty);
                return dt.Rows.Count > 0;
            }
        }
        #endregion VerificarRepeticion

        #region ValidarFilaParaImportacion
        /// <summary>
        /// Valida la integridad de datos para la importacion de datos de una coleccion
        /// </summary>
        /// <param name="fila">
        /// Contiene un data row con los campos siguientes CodArticulo, Costo,
        /// Moneda, Cantida y porcentaje de impuesto, que debe ser validado.
        /// </param>
        /// <param name="existe">
        /// Retorna falso en caso de no encontrarse el codigo articulo
        /// </param>
        /// <returns>
        /// Existe en caso de exito, un mensaje que ayude al usuario a realizar
        /// la importacion si es que se ha encontrado un error
        /// </returns>
        public static string ValidarFilaParaImportacion(DataRow fila, decimal? sucursal_id)
        {
            DataTable resultado;
            string mensaje = String.Empty;
            string conjuncion = String.Empty;
            foreach (Object item in fila.ItemArray)
            {
                if (string.IsNullOrEmpty(item.ToString().Trim()))
                {
                    mensaje = Definiciones.Mensajes.CamposVacios;
                }
            }
            using (SessionService sesion = new SessionService())
            {
                resultado = ArticulosService.GetArticuloInfoCompletaPorCodigo(((string)fila[FacturasProveedorDetalleService.VistaArticuloCodigo_NombreCol]).Trim(), sucursal_id);
                if (resultado.Rows.Count > 0)
                {
                    decimal idSeleccionado = decimal.Parse(resultado.Rows[0][ArticulosService.Id_NombreCol].ToString());
                    if (ArticulosService.NoReponer(idSeleccionado))
                    {
                        conjuncion = ((string.IsNullOrEmpty(mensaje)) ? string.Empty : ", ");
                        mensaje += conjuncion + "El artículo esta marcado para no ser repuesto";
                    }
                    if (!ArticulosService.EstaActivo(idSeleccionado))
                    {
                        conjuncion = ((string.IsNullOrEmpty(mensaje)) ? string.Empty : ", ");
                        mensaje += conjuncion + "Artículo inactivo";
                    }

                    if (!ArticulosService.IngresoAprobado(idSeleccionado))
                    {
                        conjuncion = ((string.IsNullOrEmpty(mensaje)) ? string.Empty : ", ");
                        mensaje += conjuncion + "El ingreso del artículo aún no está aprobado.";
                    }

                    conjuncion = ((string.IsNullOrEmpty(mensaje)) ? string.Empty : " y ");
                    mensaje += conjuncion + Definiciones.Mensajes.Existe;
                }
                else
                {
                    conjuncion = ((string.IsNullOrEmpty(mensaje)) ? string.Empty : " y ");
                    mensaje += conjuncion + "el artículo " + Definiciones.Mensajes.NoExiste;
                }
            }

            return mensaje;

        }
        #endregion ValidarFilaParaImportacion

        #region Modificar Detalle
        /// <summary>
        /// Modificar los detalles
        /// </summary>
        /// <param name="campos">Campos a ser modificados</param>
        public static void ModificarDetalle(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    decimal detalleId = (decimal)campos[FacturasProveedorDetalleService.Id_NombreCol];
                    var row = sesion.Db.FACTURAS_PROVEEDOR_DETALLECollection.GetByPrimaryKey(detalleId);
                    
                    var dtFacturaProveedor = FacturasProveedorService.GetFacturaProveedorInfoCompleta(FacturasProveedorService.Id_NombreCol + " = " + row.FACTURAS_PROVEEDOR_ID, string.Empty, sesion);
                    var casoEstadoId = (string)dtFacturaProveedor.Rows[0][FacturasProveedorService.VistaCasoEstadoId_NombreCol];
                    if (casoEstadoId != Definiciones.EstadosFlujos.Borrador && casoEstadoId != Definiciones.EstadosFlujos.Pendiente)
                        throw new Exception("El detalle no puede modificarse estando el caso en " + casoEstadoId);

                    string valorAnterior = row.ToString();

                    row.CANTIDAD_EMBALADA_DESTINO = (decimal)campos[FacturasProveedorDetalleService.CantidadEmbaladaDestino_NombreCol];
                    row.CANTIDAD_UNIDAD_DESTINO = (decimal)campos[FacturasProveedorDetalleService.CantidadUnidadDestino_NombreCol];

                    //Si se trabaja con unidades las cantidades deben ser enteras
                    if (row.UNIDAD_ID_DESTINO.Equals(Definiciones.UnidadesMedida.Simbolo.Unidades))
                    {
                        row.CANTIDAD_EMBALADA_DESTINO = Interprete.Redondear(row.CANTIDAD_EMBALADA_DESTINO, 0);
                        row.CANTIDAD_UNIDAD_DESTINO = Interprete.Redondear(row.CANTIDAD_UNIDAD_DESTINO, 0);
                    }

                    if (!row.IsARTICULO_IDNull)
                    {
                        DataTable dt = new DataTable();
                        dt = ArticulosService.GetArticulos(ArticulosService.Id_NombreCol + " = " + row.ARTICULO_ID, string.Empty, false, (decimal)dtFacturaProveedor.Rows[0][FacturasProveedorService.SucursalId_NombreCol]);
                        row.UNIDAD_ID_ORIGEN = dt.Rows[0][ArticulosService.UnidadMedidaId_NombreCol].ToString();
                    }
                    else
                    {
                        row.FACTOR_CONVERSION = 1;
                        row.UNIDAD_ID_ORIGEN = row.UNIDAD_ID_DESTINO;
                    }
                    //Se marca si afecta el stock
                    row.AFECTA_STOCK = campos[FacturasProveedorDetalleService.AfectaStock_NombreCol].ToString();
                    
                    //Se cambia el precio unitario
                    row.PRECIO_BRUTO_UNITARIO_DEST = (decimal)campos[FacturasProveedorDetalleService.PrecioBrutoUnitarioDestino_NombreCol];
                    //se calculan las cantidades en la unidad de origen
                    row.CANTIDAD_POR_CAJA_DESTINO = row.CANTIDAD_POR_CAJA_ORIGEN * row.FACTOR_CONVERSION;

                    //La cantidad en unidades es la cantidad de cajas, por unidades que trae una caja
                    //mas la cantidad que se pidio suelta
                    row.CANTIDAD_UNITARIA_TOTAL_DEST = (row.CANTIDAD_EMBALADA_DESTINO * row.CANTIDAD_POR_CAJA_DESTINO) + row.CANTIDAD_UNIDAD_DESTINO;

                    row.CANTIDAD_EMBALADA_ORIGEN = row.CANTIDAD_EMBALADA_DESTINO;
                    row.CANTIDAD_UNIDAD_ORIGEN = row.CANTIDAD_UNIDAD_DESTINO / row.FACTOR_CONVERSION;
                    row.CANTIDAD_UNITARIA_TOTAL_ORIG = row.CANTIDAD_UNITARIA_TOTAL_DEST / row.FACTOR_CONVERSION;
                    row.PRECIO_BRUTO_UNITARIO_ORIG = row.PRECIO_BRUTO_UNITARIO_DEST * row.FACTOR_CONVERSION;

                    //Calcular el monto bruto
                    row.TOTAL_BRUTO = row.PRECIO_BRUTO_UNITARIO_DEST * row.CANTIDAD_UNITARIA_TOTAL_DEST;
                   
                    row.PORCENTAJE_DESCUENTO = (decimal)campos[FacturasProveedorDetalleService.PorcentajeDescuento_NombreCol];

                    //Calcular el monto del descuento
                    if (row.PORCENTAJE_DESCUENTO > 0)
                        row.TOTAL_DESCUENTO = row.TOTAL_BRUTO * (row.PORCENTAJE_DESCUENTO/100);
                    else
                        row.TOTAL_DESCUENTO = 0;

                    //Calcular el monto total a pagar
                    row.TOTAL_PAGO = row.TOTAL_BRUTO - row.TOTAL_DESCUENTO;
                    row.IMPUESTO_ID = decimal.Parse(campos[FacturasProveedorDetalleService.ImpuestoId_NombreCol].ToString());
                    row.PORCENTAJE_IMPUESTO = ImpuestosService.GetPorcentajePorId(row.IMPUESTO_ID);

                    //Calcular el monto del impuesto
                    if (row.PORCENTAJE_IMPUESTO > 0)
                        row.TOTAL_IMPUESTO_DESCONTADO = row.TOTAL_PAGO / ((100 / row.PORCENTAJE_IMPUESTO) + 1);
                    else
                        row.TOTAL_IMPUESTO_DESCONTADO = 0;

                    if (campos.Contains(FacturasProveedorDetalleService.CasoAsociadoId_NombreCol) && (decimal)campos[FacturasProveedorDetalleService.CasoAsociadoId_NombreCol] > 0)
                        row.CASO_ASOCIADO_ID = (decimal)campos[FacturasProveedorDetalleService.CasoAsociadoId_NombreCol];
                    else
                        row.IsCASO_ASOCIADO_IDNull = true;

                    if (campos.Contains(FacturasProveedorDetalleService.Observacion_NombreCol))
                        row.OBSERVACION = (string)campos[FacturasProveedorDetalleService.Observacion_NombreCol];

                    //Se deben actualizar los totales en la cabecera del caso
                    FacturasProveedorService.RecalcularTotales(row.FACTURAS_PROVEEDOR_ID, sesion);

                    sesion.Db.FACTURAS_PROVEEDOR_DETALLECollection.Update(row);
                    string valorNuevo = row.ToString();
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);

                    FacturasProveedorService.RecalcularTotales(row.FACTURAS_PROVEEDOR_ID, sesion);

                    //Se modifica la cantidad de las relaciones con la orden de servico
                    OrdenesServicioDetalleRelacionesService.ModificarDetalllePorIdFacturaProveedor(row.ID, row.CANTIDAD_UNITARIA_TOTAL_DEST, sesion);
                    OrdenesCompraDetalleRelacionesService.ModificarDetalllePorFCProveedorDet(row.ID, row.CANTIDAD_UNITARIA_TOTAL_DEST, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }

        #endregion Modificar Detalle

        #region GetFacturaProveedorDetalleDataTable
        public static DataTable GetFacturaProveedorDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFacturaProveedorDetalleDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetFacturaProveedorDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.FACTURAS_PROVEEDOR_DETALLECollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetFacturaProveedorDetalleDataTable

        #region GetFacturaProveedorTotalPagoDetalles
        /// <summary>
        /// Gets the factura proveedor data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static decimal GetFacturaProveedorTotalPagoDetalles(decimal idFacturaProveedor)
        {
            using (SessionService sesion = new SessionService())
            {

                decimal montoDetalleConDescuento = 0;
                FACTURAS_PROVEEDOR_DETALLERow[] rows = sesion.Db.FACTURAS_PROVEEDOR_DETALLECollection.GetByFACTURAS_PROVEEDOR_ID(idFacturaProveedor);

                foreach (FACTURAS_PROVEEDOR_DETALLERow item in rows)
                {
                    montoDetalleConDescuento += item.TOTAL_PAGO;
                }

                return montoDetalleConDescuento;
            }
        }
        #endregion GetFacturaProveedorTotalPagoDetalles

        #region GetFacturaProveedorDetalleInfoCompleta
        /// <summary>
        /// Gets the factura proveedor detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetFacturaProveedorDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFacturaProveedorDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetFacturaProveedorDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.FACTURAS_PROVEEDOR_DET_INFO_CCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetFacturaProveedorDetalleInfoCompleta

        #region GetFacturaProveedorDetalleInfoCompleta
        /// <summary>
        /// Gets the factura proveedor detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static decimal GetCantidadDeArticulosPorDetalleFacturaProveedor(string facturaProveedorId, SessionService sesion)
        {
            string clausulas = LoteId_NombreCol + " IS NOT NULL AND " + FacturaProveedorId_NombreCol + " = " + facturaProveedorId.ToString(); 
            return sesion.Db.FACTURAS_PROVEEDOR_DET_INFO_CCollection.GetAsDataTable(clausulas, string.Empty).Rows.Count;
        }
        #endregion GetFacturaProveedorDetalleInfoCompleta

        #region GetTieneCentrosCostoManual
        public static bool GetTieneCentrosCostoManual(decimal factura_proveedor_detalle_id, SessionService sesion)
        {
            DataTable dt = FacturasProveedorDetalleCentrosCostoService.GetFacturasProveedorDetalleCentrosCostoDataTable(FacturasProveedorDetalleCentrosCostoService.FacturaProveedorDetalleId_NombreCol + " = " + factura_proveedor_detalle_id, string.Empty, sesion);
            return dt.Rows.Count > 0;
        }
        #endregion GetTieneCentrosCostoManual

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            decimal detalleId = Guardar(campos, true);
            return detalleId;
        }
        
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal detalle_id = Guardar(campos, insertarNuevo, sesion);
                    sesion.CommitTransaction();

                    return detalle_id;
                }
                catch (Exception e)
                {
                    sesion.RollbackTransaction();
                    throw new Exception(e.Message);
                }
            }
        }

        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                FACTURAS_PROVEEDOR_DETALLERow row;
                DataTable dtCabecera = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.Id_NombreCol + " = " + campos[FacturasProveedorDetalleService.FacturaProveedorId_NombreCol], string.Empty, sesion);
                string valorAnterior = string.Empty;
                decimal cantidad_anterior = Definiciones.Error.Valor.EnteroPositivo;
                decimal lote_anterior = Definiciones.Error.Valor.EnteroPositivo;

                valorAnterior = Definiciones.Log.RegistroNuevo;
                row = new FACTURAS_PROVEEDOR_DETALLERow();

                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("facturas_proveedor_detalle_sqc");
                    row.CANTIDAD_DEVUELTA_NOTA_CREDITO = 0;
                }
                else
                {
                    row = sesion.Db.FACTURAS_PROVEEDOR_DETALLECollection.GetRow(FacturasProveedorDetalleService.Id_NombreCol + " = " + campos[FacturasProveedorDetalleService.Id_NombreCol]);
                    if (!row.IsLOTE_IDNull)
                    {
                        lote_anterior = row.LOTE_ID;
                        cantidad_anterior = row.CANTIDAD_UNITARIA_TOTAL_ORIG;
                    }
                    valorAnterior = row.ToString();

                }

                row.FACTURAS_PROVEEDOR_ID = (decimal)campos[FacturasProveedorDetalleService.FacturaProveedorId_NombreCol];
                //El campo afecta Stock es obligatorio, por lo tanto, si por alguna razon no existiese el mismo en el hashtable
                //se inserta por defeto el valo 'S'
                if (campos.Contains(FacturasProveedorDetalleService.AfectaStock_NombreCol))
                    row.AFECTA_STOCK = campos[FacturasProveedorDetalleService.AfectaStock_NombreCol].ToString();
                else
                    row.AFECTA_STOCK = Definiciones.SiNo.Si;

                if (campos.Contains(FacturasProveedorDetalleService.ArticuloId_NombreCol))
                {
                    //El articulo debe tener ingreso aprobado
                    if (!ArticulosService.IngresoAprobado(decimal.Parse(campos[ArticuloId_NombreCol].ToString())))
                    {
                        throw new System.ArgumentException("El ingreso del artículo aún no está aprobado.");
                    }

                    //El articulo debe poder reponerse
                    if (ArticulosService.NoReponer(decimal.Parse(campos[ArticuloId_NombreCol].ToString())))
                    {
                        throw new System.ArgumentException("El artículo está marcado para no ser repuesto.");
                    }

                    if (row.IsARTICULO_IDNull || row.ARTICULO_ID != (decimal)campos[FacturasProveedorDetalleService.ArticuloId_NombreCol])
                    {
                        row.ARTICULO_ID = (decimal)campos[FacturasProveedorDetalleService.ArticuloId_NombreCol];
                        if (!ArticulosService.EstaActivo(row.ARTICULO_ID, sesion))
                            throw new Exception("El artículo se encuentra inactivo.");
                    }

                    //La cantidad por caja se toma de la seccion del articulo
                    row.CANTIDAD_POR_CAJA_ORIGEN = ArticulosService.GetArticuloRowPorID(row.ARTICULO_ID, sesion).CANTIDAD_POR_CAJA;
                }
                else
                {
                    row.IsARTICULO_IDNull = true;
                    row.CANTIDAD_POR_CAJA_ORIGEN = 1;
                }

                if (campos.Contains(FacturasProveedorDetalleService.LoteId_NombreCol))
                {
                    row.LOTE_ID = (decimal)campos[FacturasProveedorDetalleService.LoteId_NombreCol];

                    //Validar que el lote pertenece al articulo
                    if (row.ARTICULO_ID != ArticulosLotesService.GetArticuloId2(row.LOTE_ID, sesion))
                        throw new Exception("El lote no pertenece al artículo.");
                }
                else
                {
                    row.IsLOTE_IDNull = true;
                }

                if (campos.Contains(FacturasProveedorDetalleService.RubroId_NombreCol))
                    row.RUBRO_ID = (decimal)campos[FacturasProveedorDetalleService.RubroId_NombreCol];
                else
                    row.IsRUBRO_IDNull = true;

                if (campos.Contains(FacturasProveedorDetalleService.RubroIVAId_NombreCol))
                    row.RUBRO_IVA_ID = (decimal)campos[FacturasProveedorDetalleService.RubroIVAId_NombreCol];
                else
                    row.IsRUBRO_IVA_IDNull = true;

                if (campos.Contains(FacturasProveedorDetalleService.TextoPredefinidoId_NombreCol))
                    row.TEXTO_PREDEFINIDO_ID = (decimal)campos[FacturasProveedorDetalleService.TextoPredefinidoId_NombreCol];
                else
                    row.IsTEXTO_PREDEFINIDO_IDNull = true;

                row.UNIDAD_ID_DESTINO = (string)campos[FacturasProveedorDetalleService.UnidadIdDestino_NombreCol];

                row.CANTIDAD_EMBALADA_DESTINO = decimal.Parse(campos[FacturasProveedorDetalleService.CantidadEmbaladaDestino_NombreCol].ToString());
                row.CANTIDAD_UNIDAD_DESTINO = decimal.Parse(campos[FacturasProveedorDetalleService.CantidadUnidadDestino_NombreCol].ToString());

                row.OBSERVACION = (string)campos[FacturasProveedorDetalleService.Observacion_NombreCol];

                row.PRECIO_BRUTO_UNITARIO_DEST = (decimal)campos[FacturasProveedorDetalleService.PrecioBrutoUnitarioDestino_NombreCol];

                if (!row.IsARTICULO_IDNull)
                {
                    //se obtiene el factor de conversion
                    row.FACTOR_CONVERSION = ArticulosConversionesService.GetFactorConversion(row.ARTICULO_ID, row.UNIDAD_ID_DESTINO, (decimal)dtCabecera.Rows[0][FacturasProveedorService.SucursalId_NombreCol], sesion);

                    DataTable dt = new DataTable();
                    dt = ArticulosService.GetArticulosDataTable(ArticulosService.Id_NombreCol + " = " + row.ARTICULO_ID, string.Empty, false, (decimal)dtCabecera.Rows[0][FacturasProveedorService.SucursalId_NombreCol], sesion);
                    row.UNIDAD_ID_ORIGEN = dt.Rows[0][ArticulosService.UnidadMedidaId_NombreCol].ToString();
                }
                else
                {
                    row.FACTOR_CONVERSION = 1;
                    row.UNIDAD_ID_ORIGEN = row.UNIDAD_ID_DESTINO;
                }

                //se calculan las cantidades en la unidad de origen
                row.CANTIDAD_POR_CAJA_DESTINO = row.CANTIDAD_POR_CAJA_ORIGEN * row.FACTOR_CONVERSION;

                //La cantidad en unidades es la cantidad de cajas, por unidades que trae una caja
                //mas la cantidad que se pidio suelta
                row.CANTIDAD_UNITARIA_TOTAL_DEST = (row.CANTIDAD_EMBALADA_DESTINO * row.CANTIDAD_POR_CAJA_DESTINO) + row.CANTIDAD_UNIDAD_DESTINO;

                row.CANTIDAD_EMBALADA_ORIGEN = row.CANTIDAD_EMBALADA_DESTINO;
                row.CANTIDAD_UNIDAD_ORIGEN = row.CANTIDAD_UNIDAD_DESTINO / row.FACTOR_CONVERSION;
                row.CANTIDAD_UNITARIA_TOTAL_ORIG = row.CANTIDAD_UNITARIA_TOTAL_DEST / row.FACTOR_CONVERSION;
                row.PRECIO_BRUTO_UNITARIO_ORIG = row.PRECIO_BRUTO_UNITARIO_DEST * row.FACTOR_CONVERSION;

                if (campos.Contains(FacturasProveedorDetalleService.ProveedorRelacionadoId_NombreCol))
                    row.PROVEEDOR_RELACIONADO_ID = (decimal)campos[FacturasProveedorDetalleService.ProveedorRelacionadoId_NombreCol];
                else
                    row.IsPROVEEDOR_RELACIONADO_IDNull = true;


                // Cargar el tipo de detalle
                if (campos.Contains(FacturasProveedorDetalleService.TipoDetalle_NombreCol))
                    row.TIPO_DETALLE = (decimal)campos[FacturasProveedorDetalleService.TipoDetalle_NombreCol];
                else
                    row.TIPO_DETALLE = Definiciones.TiposDetalleFacturaProveedor.Estandar;

                //Calcular el monto bruto
                row.TOTAL_BRUTO = row.PRECIO_BRUTO_UNITARIO_DEST * row.CANTIDAD_UNITARIA_TOTAL_DEST;

                if ((decimal)campos[FacturasProveedorDetalleService.PorcentajeDescuento_NombreCol] > 100)
                    throw new Exception("El porcentaje de descuento es mayor al permitido.");

                row.PORCENTAJE_DESCUENTO = decimal.Parse(campos[FacturasProveedorDetalleService.PorcentajeDescuento_NombreCol].ToString());

                //Calcular el monto del descuento
                if (row.PORCENTAJE_DESCUENTO > 0)
                    row.TOTAL_DESCUENTO = row.TOTAL_BRUTO * row.PORCENTAJE_DESCUENTO / 100;
                else
                    row.TOTAL_DESCUENTO = 0;

                //Calcular el monto total a pagar
                row.TOTAL_PAGO = row.TOTAL_BRUTO - row.TOTAL_DESCUENTO;

                row.IMPUESTO_ID = decimal.Parse(campos[FacturasProveedorDetalleService.ImpuestoId_NombreCol].ToString());
                row.PORCENTAJE_IMPUESTO = ImpuestosService.GetPorcentajePorId(row.IMPUESTO_ID, sesion);

                if (campos.Contains(FacturasProveedorDetalleService.CasoAsociadoId_NombreCol) && (decimal)campos[FacturasProveedorDetalleService.CasoAsociadoId_NombreCol] > 0)
                    row.CASO_ASOCIADO_ID = (decimal)campos[FacturasProveedorDetalleService.CasoAsociadoId_NombreCol];
                else
                    row.IsCASO_ASOCIADO_IDNull = true;

                //Calcular el monto del impuesto
                if (row.TIPO_DETALLE.Equals(Definiciones.TiposDetalleFacturaProveedor.Estandar))
                {
                    DataTable dtImpuesto = ImpuestosService.GetImpuestosDataTable(ImpuestosService.Id_NombreCol + " = " + row.IMPUESTO_ID, string.Empty);

                    int tipoImpuesto = int.Parse(dtImpuesto.Rows[0][ImpuestosService.TipoImpuestoId_NombreCol].ToString());
                    switch (tipoImpuesto)
                    {
                        case Definiciones.TipoImpuesto.Basico:
                        case Definiciones.TipoImpuesto.Motos:
                            if (row.PORCENTAJE_IMPUESTO > 0)
                                row.TOTAL_IMPUESTO_DESCONTADO = row.TOTAL_PAGO / ((100 / row.PORCENTAJE_IMPUESTO) + 1);
                            else
                                row.TOTAL_IMPUESTO_DESCONTADO = 0;
                            break;
                        case Definiciones.TipoImpuesto.Inmuebles:
                            if (ImpuestosCompuestosService.EsInteresCompuesto(row.IMPUESTO_ID))
                            {
                                decimal totalImpuesto = 0;
                                decimal precioTotal = row.TOTAL_PAGO;
                                DataTable dtImpuestoCompuesto = ImpuestosCompuestosService.GetImpuestosCompuestosInfoCompleta(ImpuestosCompuestosService.ImpuestoPadreId_NombreCol + " = " + row.IMPUESTO_ID, string.Empty);

                                foreach (DataRow dr in dtImpuestoCompuesto.Rows)
                                {
                                    if ((decimal)dr[ImpuestosCompuestosService.VistaImpuestoHijoPorcentaje_NombreCol] > 0)
                                        totalImpuesto += (precioTotal * (decimal)dr[ImpuestosCompuestosService.Porcentaje_NombreCol] / 100) / ((100 + (decimal)dr[ImpuestosCompuestosService.VistaImpuestoHijoPorcentaje_NombreCol]) / (decimal)dr[ImpuestosCompuestosService.VistaImpuestoHijoPorcentaje_NombreCol]);
                                }

                                row.TOTAL_IMPUESTO_DESCONTADO = totalImpuesto;
                            }
                            else
                            {
                                if (row.PORCENTAJE_IMPUESTO > 0)
                                    row.TOTAL_IMPUESTO_DESCONTADO = row.TOTAL_PAGO / ((100 / row.PORCENTAJE_IMPUESTO) + 1);
                                else
                                    row.TOTAL_IMPUESTO_DESCONTADO = 0;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if (row.TIPO_DETALLE.Equals(Definiciones.TiposDetalleFacturaProveedor.SoloIVA))
                {
                    row.TOTAL_IMPUESTO_DESCONTADO = (decimal)campos[FacturasProveedorDetalleService.TotalImpuestoDescontado_NombreCol];
                }

                //Se guarda el activo
                if (campos.Contains(FacturasProveedorDetalleService.ActivoId_NombreCol))
                    row.ACTIVO_ID = (decimal)campos[FacturasProveedorDetalleService.ActivoId_NombreCol];
                else
                    row.IsACTIVO_IDNull = true;

                if (insertarNuevo)
                    sesion.Db.FACTURAS_PROVEEDOR_DETALLECollection.Insert(row);
                else
                    sesion.Db.FACTURAS_PROVEEDOR_DETALLECollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                #region Modificacion de la Factura en Aprobado
                FACTURAS_PROVEEDORRow fc = sesion.Db.FACTURAS_PROVEEDORCollection.GetByPrimaryKey(row.FACTURAS_PROVEEDOR_ID);
                string casoEstado = CasosService.GetEstadoCaso(fc.CASO_ID, sesion);
                if (casoEstado.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    if (!fc.IsIMPORTACION_IDNull)
                        throw new Exception("La factura no puede ser modificada. Pertenece a una Importación");

                    decimal casoAsociadoId = fc.CASO_ID;
                    if (!fc.IsCASO_ASOCIADO_IDNull)
                    {
                        casoAsociadoId = fc.CASO_ASOCIADO_ID;
                        if (CasosService.GetFlujo(casoAsociadoId, sesion).Equals(Definiciones.FlujosIDs.INGRESO_DE_STOCK))
                        {
                            casoEstado = CasosService.GetEstadoCaso(fc.CASO_ASOCIADO_ID, sesion);

                            System.Collections.Hashtable camposIngresos = new System.Collections.Hashtable();
                            camposIngresos.Add(IngresoStockDetalleService.LoteId_NombreCol, row.LOTE_ID);
                            camposIngresos.Add(IngresoStockDetalleService.UnidadId_NombreCol, row.UNIDAD_ID_DESTINO);
                            camposIngresos.Add(IngresoStockDetalleService.CantidadTotalOrigen_NombreCol, row.CANTIDAD_UNITARIA_TOTAL_ORIG);
                            camposIngresos.Add(IngresoStockDetalleService.MonedaId_NombreCol, fc.MONEDA_ID);
                            camposIngresos.Add(IngresoStockDetalleService.Cotizacion_NombreCol, fc.MONEDA_COTIZACION);
                            camposIngresos.Add(IngresoStockDetalleService.Costo_NombreCol, row.TOTAL_PAGO / row.CANTIDAD_UNITARIA_TOTAL_ORIG);
                            camposIngresos.Add(IngresoStockDetalleService.CostoImpuestoPorc_NombreCol, ImpuestosService.GetPorcentajePorId(row.IMPUESTO_ID));
                            var ingresoDetId = IngresoStockDetalleService.ActualizarDetalle(camposIngresos, fc.CASO_ASOCIADO_ID, lote_anterior, sesion);

                            if (casoEstado.Equals(Definiciones.EstadosFlujos.Aprobado))
                            {
                                StockService.CorreccionStock(row.ID, casoAsociadoId, row.LOTE_ID, row.ARTICULO_ID, row.CANTIDAD_UNITARIA_TOTAL_ORIG,
                                lote_anterior, cantidad_anterior, fc.STOCK_DEPOSITO_ID, sesion, fc.FECHA_FACTURA, (row.TOTAL_PAGO - row.TOTAL_IMPUESTO_DESCONTADO) / row.CANTIDAD_UNITARIA_TOTAL_ORIG, fc.MONEDA_ID, fc.MONEDA_COTIZACION, row.IMPUESTO_ID, ingresoDetId);
                            }
                        }
                    }
                    else
                    {
                        decimal vAfectarstock = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.AfectarStock, sesion);
                        if (vAfectarstock == Definiciones.AfectarStock.PorFacturaProveedor)
                        {
                            if (fc.TIPO_FACTURA_PROVEEDOR_ID.Equals(Definiciones.TipoFacturaProveedor.CompraArticulos))
                            {
                                StockService.CorreccionStock(row.ID, casoAsociadoId, row.LOTE_ID, row.ARTICULO_ID, row.CANTIDAD_UNITARIA_TOTAL_ORIG,
                                    lote_anterior, cantidad_anterior, fc.STOCK_DEPOSITO_ID, sesion, fc.FECHA_FACTURA, (row.TOTAL_PAGO - row.TOTAL_IMPUESTO_DESCONTADO) / row.CANTIDAD_UNITARIA_TOTAL_ORIG, fc.MONEDA_ID, fc.MONEDA_COTIZACION, row.IMPUESTO_ID, row.ID);
                            }
                        }
                        if (fc.TIPO_FACTURA_PROVEEDOR_ID.Equals(Definiciones.TipoFacturaProveedor.Gastos))
                        {
                            if (!row.IsLOTE_IDNull)
                            {
                                StockService.CorreccionStock(row.ID, casoAsociadoId, row.LOTE_ID, row.ARTICULO_ID, row.CANTIDAD_UNITARIA_TOTAL_ORIG,
                                    lote_anterior, cantidad_anterior, fc.STOCK_DEPOSITO_ID, sesion, fc.FECHA_FACTURA, (row.TOTAL_PAGO - row.TOTAL_IMPUESTO_DESCONTADO) / row.CANTIDAD_UNITARIA_TOTAL_ORIG, fc.MONEDA_ID, fc.MONEDA_COTIZACION, row.IMPUESTO_ID, row.ID);
                            }
                        }
                    }
                }

                #endregion Modificacion de la Factura en Aprobado

                //Se deben actualizar los totales en la cabecera del caso
                FacturasProveedorService.RecalcularTotales(row.FACTURAS_PROVEEDOR_ID, sesion);

                return row.ID;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified factura_cliente_id.
        /// </summary>
        /// <param name="factura_proveedor_detalle_id">The factura_proveedor_detalle_id.</param>
        public static void Borrar(decimal factura_proveedor_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    FacturasProveedorService facturacionProveedor = new FacturasProveedorService(); 
                    FACTURAS_PROVEEDOR_DETALLERow row = sesion.Db.FACTURAS_PROVEEDOR_DETALLECollection.GetByPrimaryKey(factura_proveedor_detalle_id);
                    DataTable dtCuentas = FacturasProveedorDetalleCuentaContableService.GetFacturasProveedorDetalleCuentaContableDataTable(FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol + " = " + row.ID, string.Empty);
                    DataTable dtCentrosCosto = FacturasProveedorDetalleCentrosCostoService.GetFacturasProveedorDetalleCentrosCostoDataTable(FacturasProveedorDetalleCentrosCostoService.FacturaProveedorDetalleId_NombreCol + " = " + row.ID, string.Empty, sesion);

                    //Se borra la distribucion de cuentas por detalle
                    for (int i = 0; i < dtCuentas.Rows.Count; i++)
                        FacturasProveedorDetalleCuentaContableService.Borrar((decimal)dtCuentas.Rows[i][FacturasProveedorDetalleCuentaContableService.Id_NombreCol], sesion);

                    //Se borra la distribucion de centros de costo por detalle
                    for (int i = 0; i < dtCentrosCosto.Rows.Count; i++)
                        FacturasProveedorDetalleCentrosCostoService.Borrar((decimal)dtCentrosCosto.Rows[i][FacturasProveedorDetalleCentrosCostoService.Id_NombreCol], sesion);

                    //Se borra las relaciones si existen
                    OrdenesServicioDetalleRelacionesService.BorrarPorFCProveedor(row.ID, sesion);
                    OrdenesCompraDetalleRelacionesService.BorrarPorFCProveedorDet(row.ID, sesion);

                    sesion.Db.FACTURAS_PROVEEDOR_DETALLECollection.Delete(row);

                    //Se deben actualizar los totales en la cabecera del caso
                    FacturasProveedorService.RecalcularTotales(row.FACTURAS_PROVEEDOR_ID, sesion);
                    
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion Borrar

        #region Crear Detalle
        public static PropiedadesDetalle CrearDetalle(decimal facturaProveedorId, decimal articuloId, decimal cantidadUnitariaDestino, decimal loteId, decimal montoCapital, bool afecta_stock, SessionService sesion)
        {
            FacturasProveedorDetalleService.PropiedadesDetalle fcProveedorDetalles;
                        
            fcProveedorDetalles = new FacturasProveedorDetalleService.PropiedadesDetalle();
            
            fcProveedorDetalles.FacturaProveedorId = facturaProveedorId;
            fcProveedorDetalles.ArticuloId = articuloId;
            fcProveedorDetalles.CantidadUnitariaDestino = cantidadUnitariaDestino;
            fcProveedorDetalles.LoteId = loteId;
            fcProveedorDetalles.PrecioBrutoUnitarioDestino = montoCapital;
            fcProveedorDetalles.AfectaStock = afecta_stock;

            FacturasProveedorDetalleService.Crear(fcProveedorDetalles, sesion);

            return fcProveedorDetalles;
        }
        #endregion Crear Detalle

        #region Crear
        /// <summary>
        /// Crears the specified detalle.
        /// </summary>
        /// <param name="detalle">The detalle.</param>
        /// <returns></returns>
        public static decimal Crear(FacturasProveedorDetalleService.PropiedadesDetalle detalle, SessionService sesion)
        {
            try
            {
                decimal idCreado = Definiciones.Error.Valor.EnteroPositivo;
                var dtFactura = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.Id_NombreCol + " = "  + detalle.FacturaProveedorId, string.Empty, sesion);
                DataTable dtArticulo = ArticulosService.GetArticulos(ArticulosService.Id_NombreCol + " = " + detalle.ArticuloId, string.Empty, false, (decimal)dtFactura.Rows[0][FacturasProveedorService.SucursalId_NombreCol]);
                decimal cantidadPorCaja;
                bool esTrazable = false;
                bool continuar = true;
                decimal contador;

                cantidadPorCaja = 1;
                if (dtArticulo.Rows.Count > 0)
                {
                    esTrazable = dtArticulo.Rows[0][ArticulosService.EsTrazable_NombreCol].Equals(Definiciones.SiNo.Si);
                    cantidadPorCaja = (decimal)dtArticulo.Rows[0][ArticulosService.CantidadPorCaja_NombreCol];
                }

                //Si es trazable se ingresa un detalle por cada unidad
                contador = 0;
                continuar = true;
                while (continuar)
                {
                    System.Collections.Hashtable campos = new System.Collections.Hashtable();

                    campos.Add(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol, detalle.FacturaProveedorId);
                    if (!detalle.ActivoId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        campos.Add(FacturasProveedorDetalleService.ActivoId_NombreCol, detalle.ActivoId);
                    if (!detalle.ArticuloId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        campos.Add(FacturasProveedorDetalleService.ArticuloId_NombreCol, detalle.ArticuloId);

                    //Si no se indica el lote, intenta obtenerse el ultimo creado en caso el articulo no sea trazable
                    if (!detalle.LoteId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    {
                        campos.Add(FacturasProveedorDetalleService.LoteId_NombreCol, detalle.LoteId);
                    }
                    else
                    {
                        if (dtArticulo.Rows.Count > 0)
                        {
                            //Si no es trazable se busca el ultimo lote creado
                            if (!esTrazable)
                            {
                                DataTable dtArticulosLotes = ArticulosLotesService.GetArticulosLotes(detalle.ArticuloId, ArticulosLotesService.Id_NombreCol + " desc");
                                if (dtArticulosLotes.Rows.Count > 0)
                                {
                                    campos.Add(FacturasProveedorDetalleService.LoteId_NombreCol, dtArticulosLotes.Rows[0][ArticulosLotesService.Id_NombreCol]);
                                }
                            }
                        }
                    }

                    if (dtArticulo.Rows.Count > 0)
                    {
                        campos.Add(FacturasProveedorDetalleService.UnidadIdDestino_NombreCol, dtArticulo.Rows[0][ArticulosService.UnidadMedidaId_NombreCol]);
                        campos.Add(FacturasProveedorDetalleService.CantidadPorCajaDestino_NombreCol, dtArticulo.Rows[0][ArticulosService.CantidadPorCaja_NombreCol]);
                    }
                    else
                    {
                        campos.Add(FacturasProveedorDetalleService.UnidadIdDestino_NombreCol, Definiciones.UnidadesMedida.Simbolo.Unidades);
                        campos.Add(FacturasProveedorDetalleService.CantidadPorCajaDestino_NombreCol, (decimal)1);
                    }

                    campos.Add(FacturasProveedorDetalleService.Observacion_NombreCol, detalle.Observacion);
                    campos.Add(FacturasProveedorDetalleService.PrecioBrutoUnitarioDestino_NombreCol, detalle.PrecioBrutoUnitarioDestino);
                    campos.Add(FacturasProveedorDetalleService.PorcentajeDescuento_NombreCol, detalle.PorcentajeDescuento);

                    //establecer el impuesto segun datos de la ficha de articulo o segun lo provisto como dato
                    if (dtArticulo.Rows.Count > 0)
                    {
                        campos.Add(FacturasProveedorDetalleService.PorcentajeImpuesto_NombreCol, ImpuestosService.GetPorcentajePorId((decimal)dtArticulo.Rows[0][ArticulosService.ImpuestoId_NombreCol]));
                        campos.Add(FacturasProveedorDetalleService.ImpuestoId_NombreCol, dtArticulo.Rows[0][ArticulosService.ImpuestoId_NombreCol]);
                    }
                    else
                    {
                        campos.Add(FacturasProveedorDetalleService.PorcentajeImpuesto_NombreCol, detalle.PorcentajeImpuesto);
                        campos.Add(FacturasProveedorDetalleService.ImpuestoId_NombreCol, ImpuestosService.GetImpuestoIdPorPorcentaje(detalle.PorcentajeImpuesto));
                    }

                    if (esTrazable)
                    {
                        campos.Add(FacturasProveedorDetalleService.CantidadEmbaladaDestino_NombreCol, (decimal)0);
                        campos.Add(FacturasProveedorDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
                    }
                    else
                    {
                        campos.Add(FacturasProveedorDetalleService.CantidadEmbaladaDestino_NombreCol, detalle.CantidadEmbaladaDestino);
                        campos.Add(FacturasProveedorDetalleService.CantidadUnidadDestino_NombreCol, detalle.CantidadUnitariaDestino);
                    }

                    campos.Add(FacturasProveedorDetalleService.AfectaStock_NombreCol, detalle.AfectaStock ? Definiciones.SiNo.Si : Definiciones.SiNo.No);

                    idCreado = FacturasProveedorDetalleService.Guardar(campos, true, sesion);

                    //Si es trazable, se sigue iterando hasta haber insertado tantos 
                    //detalles como cantidad unitaria total indicada
                    contador++;
                    if (!esTrazable || contador >= (cantidadPorCaja * detalle.CantidadEmbaladaDestino + detalle.CantidadUnitariaDestino))
                        continuar = false;
                }

                return idCreado;
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion Crear

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "FACTURAS_PROVEEDOR_DETALLE"; }
        }

        public static string Nombre_Vista
        {
            get { return "FACTURAS_PROVEEDOR_DET_INFO_C"; }
        }

        #region Tabla
        public static string ActivoId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.ACTIVO_IDColumnName; }
        }

        public static string ArticuloId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.ARTICULO_IDColumnName; }
        }
       
        public static string CantidadDevueltaNotaCredito_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.CANTIDAD_DEVUELTA_NOTA_CREDITOColumnName; }
        }
        public static string CantidadEmbaladaDestino_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.CANTIDAD_EMBALADA_DESTINOColumnName; }
        }
        public static string CantidadPorCajaDestino_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.CANTIDAD_POR_CAJA_DESTINOColumnName; }
        }
        public static string CantidadUnidadDestino_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.CANTIDAD_UNIDAD_DESTINOColumnName; }
        }
        public static string CantidadUnitariaTotalDestino_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.CANTIDAD_UNITARIA_TOTAL_DESTColumnName; }
        }
        public static string CasoAsociadoId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.CASO_ASOCIADO_IDColumnName; }
        }
        public static string FacturaProveedorId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.FACTURAS_PROVEEDOR_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.IDColumnName; }
        }
        public static string LoteId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.LOTE_IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.OBSERVACIONColumnName; }
        }
        public static string PorcentajeDescuento_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.PORCENTAJE_DESCUENTOColumnName; }
        }
        public static string PorcentajeImpuesto_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.PORCENTAJE_IMPUESTOColumnName; }
        }
        public static string PrecioBrutoUnitarioDestino_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.PRECIO_BRUTO_UNITARIO_DESTColumnName; }
        }
        public static string TipoDetalle_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.TIPO_DETALLEColumnName; }
        }
        public static string TotalBruto_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.TOTAL_BRUTOColumnName; }
        }
        public static string TotalDescuento_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.TOTAL_DESCUENTOColumnName; }
        }
        public static string TotalImpuestoDescontado_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.TOTAL_IMPUESTO_DESCONTADOColumnName; }
        }
        public static string TotalPago_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.TOTAL_PAGOColumnName; }
        }
        public static string UnidadIdDestino_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.UNIDAD_ID_DESTINOColumnName; }
        }

        public static string UnidadIdOrigen_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.UNIDAD_ID_ORIGENColumnName; }
        }
        public static string CantidadEmbaladaOrigen_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.CANTIDAD_EMBALADA_ORIGENColumnName; }
        }
        public static string CantidadPorCajaOrigen_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.CANTIDAD_POR_CAJA_ORIGENColumnName; }
        }
        public static string CantidadUnidadOrigen_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.CANTIDAD_UNIDAD_ORIGENColumnName; }
        }
        public static string CantidadUnitariaTotalOrigen_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.CANTIDAD_UNITARIA_TOTAL_ORIGColumnName; }
        }

        public static string FactorConversion_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.FACTOR_CONVERSIONColumnName; }
        }
        public static string PrecioBrutoUnitarioOrigen_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.PRECIO_BRUTO_UNITARIO_ORIGColumnName; }
        }
        public static string RubroId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.RUBRO_IDColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.IMPUESTO_IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string AfectaStock_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.AFECTA_STOCKColumnName; }
        }

        public static string ProveedorRelacionadoId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.PROVEEDOR_RELACIONADO_IDColumnName; }
        }

        public static string RubroIVAId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DETALLECollection.RUBRO_IVA_IDColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string VistaActivoCodigo_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.ACTIVO_CODIGOColumnName; }
        }
        public static string VistaArticuloDescripcion_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.ARTICULO_DESCRIPCIONColumnName; }
        }

        public static string VistaArticuloCodigo_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.ARTICULO_CODIGOColumnName; }
        }
        public static string VistaArticuloDescripcionCompleta_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.ARTICULO_DESCRIPCION_COMPLETAColumnName; }
        }
        public static string VistaLoteNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.LOTE_NOMBREColumnName; }
        }
        public static string VistaUnidadDestinoDescripcion_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.UNIDAD_DESTINO_DESCRIPCIONColumnName; }
        }
        public static string VistaUnidadOrigenDescripcion_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.UNIDAD_ORIGEN_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloFamiliaId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.ARTICULO_FAMILIA_IDColumnName; }
        }
        public static string VistaArticuloGrupoId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.ARTICULO_GRUPO_IDColumnName; }
        }
        public static string VistaArticuloSubgrupoId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.ARTICULO_SUBGRUPO_IDColumnName; }
        }
        public static string VistaRubroNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.RUBRO_NOMBREColumnName; }
        }
        public static string VistaImpuestoCompraId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.IMPUESTO_COMPRA_IDColumnName; }
        }        
        public static string VistaImpuestoNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.IMPUESTO_NOMBREColumnName; }
        }
        public static string VistaTextoPredefinidoTexto_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.TEXTO_PREDEFINIDO_TEXTOColumnName; }
        }
        public static string VistaArticuloMarcaId
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.ARTICULO_MARCA_IDColumnName; }
        }
        public static string VistaMarcaNombre
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.MARCA_NOMBREColumnName; }
        }
        public static string VistaTotalPago_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.TOTAL_PAGOColumnName; }
        }
        public static string VistaProveedorRelacionadoNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.PROVEEDOR_RELACIONADO_NOMBREColumnName; }
        }
        public static string VistaServicioNombre_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.SERVICIOColumnName; }
        }
        public static string VistaCodigoRubro_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.CODIGO_RUBROColumnName; }
        }  
        public static string VistaDescripcionRubro_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_INFO_CCollection.DESCRIPCION_RUBROColumnName; }
        }    
        #endregion Vista

        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static FacturasProveedorDetalleService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new FacturasProveedorDetalleService(e.RegistroId, sesion);
        }

        public static decimal? GetIdPorUUID(string uuid, SessionService sesion)
        {
            if (uuid.Length <= 0)
                return null;

            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return e.RegistroId;
        }
        #endregion interfaz IEntidadMigrable

        #region Propiedades
        protected FACTURAS_PROVEEDOR_DETALLERow row;
        protected FACTURAS_PROVEEDOR_DETALLERow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? ActivoId { get { if (row.IsACTIVO_IDNull) return null; else return row.ACTIVO_ID; } set { if (value.HasValue) row.ACTIVO_ID = value.Value; else row.IsACTIVO_IDNull = true; } }
        public string AfrectaStock { get { return ClaseCBABase.GetStringHelper(row.AFECTA_STOCK); } set { row.AFECTA_STOCK = value; } }
        public decimal? ArticuloId { get { if (row.IsARTICULO_IDNull) return null; else return row.ARTICULO_ID; } set { if (value.HasValue) row.ARTICULO_ID = value.Value; else row.IsARTICULO_IDNull = true; } }
        public decimal? CantidadDevueltaNotaCredito { get { if (row.IsCANTIDAD_DEVUELTA_NOTA_CREDITONull) return null; else return row.CANTIDAD_DEVUELTA_NOTA_CREDITO; } set { if (value.HasValue) row.CANTIDAD_DEVUELTA_NOTA_CREDITO = value.Value; else row.IsCANTIDAD_DEVUELTA_NOTA_CREDITONull = true; } }
        public decimal CantidadEmbaladaDestino { get { return row.CANTIDAD_EMBALADA_DESTINO; } set { row.CANTIDAD_EMBALADA_DESTINO = value; } }
        public decimal? CantidadEmbaladaOrigen { get { if (row.IsCANTIDAD_EMBALADA_ORIGENNull) return null; else return row.CANTIDAD_EMBALADA_ORIGEN; } set { if (value.HasValue) row.CANTIDAD_EMBALADA_ORIGEN = value.Value; else row.IsCANTIDAD_EMBALADA_ORIGENNull = true; } }
        public decimal CantidadPorCajaDestino { get { return row.CANTIDAD_POR_CAJA_DESTINO; } set { row.CANTIDAD_POR_CAJA_DESTINO = value; } }
        public decimal? CantidadPorCajaOrigen { get { if (row.IsCANTIDAD_POR_CAJA_ORIGENNull) return null; else return row.CANTIDAD_POR_CAJA_ORIGEN; } set { if (value.HasValue) row.CANTIDAD_POR_CAJA_ORIGEN = value.Value; else row.IsCANTIDAD_POR_CAJA_ORIGENNull = true; } }
        public decimal CantidadUnidadDestino { get { return row.CANTIDAD_UNIDAD_DESTINO; } set { row.CANTIDAD_UNIDAD_DESTINO = value; } }
        public decimal? CantidadUnidadOrigen { get { if (row.IsCANTIDAD_UNIDAD_ORIGENNull) return null; else return row.CANTIDAD_UNIDAD_ORIGEN; } set { if (value.HasValue) row.CANTIDAD_UNIDAD_ORIGEN = value.Value; else row.IsCANTIDAD_UNIDAD_ORIGENNull = true; } }
        public decimal CantidadUnitariaTotalDest { get { return row.CANTIDAD_UNITARIA_TOTAL_DEST; } set { row.CANTIDAD_UNITARIA_TOTAL_DEST = value; } }
        public decimal? CantidadUnitariaTotalOrig { get { if (row.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull) return null; else return row.CANTIDAD_UNITARIA_TOTAL_ORIG; } set { if (value.HasValue) row.CANTIDAD_UNITARIA_TOTAL_ORIG = value.Value; else row.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull = true; } }
        public decimal? CasoAsociadoId { get { if (row.IsCASO_ASOCIADO_IDNull) return null; else return row.CASO_ASOCIADO_ID; } set { if (value.HasValue) row.CASO_ASOCIADO_ID = value.Value; else row.IsCASO_ASOCIADO_IDNull = true; } }
        public decimal? FactorConversion { get { if (row.IsFACTOR_CONVERSIONNull) return null; else return row.FACTOR_CONVERSION; } set { if (value.HasValue) row.FACTOR_CONVERSION = value.Value; else row.IsFACTOR_CONVERSIONNull = true; } }
        public decimal FacturasProveedorId { get { return row.FACTURAS_PROVEEDOR_ID; } set { row.FACTURAS_PROVEEDOR_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal ImpuestoId { get { return row.IMPUESTO_ID; } set { row.IMPUESTO_ID = value; } }
        public decimal? LoteId { get { if (row.IsLOTE_IDNull) return null; else return row.LOTE_ID; } set { if (value.HasValue) row.LOTE_ID = value.Value; else row.IsLOTE_IDNull = true; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal PorcentajeDescuento { get { return row.PORCENTAJE_DESCUENTO; } set { row.PORCENTAJE_DESCUENTO = value; } }
        public decimal PorcentajeImpuesto { get { return row.PORCENTAJE_IMPUESTO; } set { row.PORCENTAJE_IMPUESTO = value; } }
        public decimal PrecioBrutoUnitarioDest { get { return row.PRECIO_BRUTO_UNITARIO_DEST; } set { row.PRECIO_BRUTO_UNITARIO_DEST = value; } }
        public decimal? PrecioBrutoUnitarioOrig { get { if (row.IsPRECIO_BRUTO_UNITARIO_ORIGNull) return null; else return row.PRECIO_BRUTO_UNITARIO_ORIG; } set { if (value.HasValue) row.PRECIO_BRUTO_UNITARIO_ORIG = value.Value; else row.IsPRECIO_BRUTO_UNITARIO_ORIGNull = true; } }
        public decimal? ProveedorRelacionadoId { get { if (row.IsPROVEEDOR_RELACIONADO_IDNull) return null; else return row.PROVEEDOR_RELACIONADO_ID; } set { if (value.HasValue) row.PROVEEDOR_RELACIONADO_ID = value.Value; else row.IsPROVEEDOR_RELACIONADO_IDNull = true; } }
        public decimal? RubroId { get { if (row.IsRUBRO_IDNull) return null; else return row.RUBRO_ID; } set { if (value.HasValue) row.RUBRO_ID = value.Value; else row.IsRUBRO_IDNull = true; } }
        public decimal? TextoPredefinidoId { get { if (row.IsTEXTO_PREDEFINIDO_IDNull) return null; else return row.TEXTO_PREDEFINIDO_ID; } set { if (value.HasValue) row.TEXTO_PREDEFINIDO_ID = value.Value; else row.IsTEXTO_PREDEFINIDO_IDNull = true; } }
        public decimal TipoDetalle { get { return row.TIPO_DETALLE; } set { row.TIPO_DETALLE = value; } }
        public decimal TotalBruto { get { return row.TOTAL_BRUTO; } set { row.TOTAL_BRUTO = value; } }
        public decimal TotalDescuento { get { return row.TOTAL_DESCUENTO; } set { row.TOTAL_DESCUENTO = value; } }
        public decimal TotalImpuestoDescontado { get { return row.TOTAL_IMPUESTO_DESCONTADO; } set { row.TOTAL_IMPUESTO_DESCONTADO = value; } }
        public decimal TotalPago { get { return row.TOTAL_PAGO; } set { row.TOTAL_PAGO = value; } }
        public string UnidadIdDestino { get { return ClaseCBABase.GetStringHelper(row.UNIDAD_ID_DESTINO); } set { row.UNIDAD_ID_DESTINO = value; } }
        public string UnidadIdOrigen { get { return ClaseCBABase.GetStringHelper(row.UNIDAD_ID_ORIGEN); } set { row.UNIDAD_ID_ORIGEN = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private ArticulosService _articulo;
        public ArticulosService Articulo
        {
            get
            {
                if (this._articulo == null)
                    this._articulo = new ArticulosService(this.ArticuloId.Value);
                return this._articulo;
            }
        }

        private ArticulosLotesService _lote;
        public ArticulosLotesService Lote
        {
            get
            {
                if (this._lote == null)
                    this._lote = new ArticulosLotesService(this.LoteId.Value);
                return this._lote;
            }
        }

        private ImpuestosService _impuesto;
        public ImpuestosService Impuesto
        {
            get
            {
                if (this._impuesto == null)
                    this._impuesto = new ImpuestosService(this.ImpuestoId);
                return this._impuesto;
            }
        }

        private FacturasProveedorService _factura_proveedor;
        public FacturasProveedorService FacturaProveedor
        {
            get
            {
                if (this._factura_proveedor == null)
                    this._factura_proveedor = new FacturasProveedorService(this.FacturasProveedorId);
                return this._factura_proveedor;
            }
        }

        private RubrosService _rubro;
        public RubrosService Rubro
        {
            get
            {
                if (this._rubro == null)
                    this._rubro = new RubrosService(this.RubroId.Value);
                return this._rubro;
            }
        }

        private TextosPredefinidosService _texto_predefinido;
        public TextosPredefinidosService TextoPredefinido
        {
            get
            {
                if (this._texto_predefinido == null)
                    this._texto_predefinido = new TextosPredefinidosService(this.TextoPredefinidoId.Value);
                return this._texto_predefinido;
            }
        }

        private UnidadesService _unidad_destino;
        public UnidadesService UnidadDestino
        {
            get
            {
                if (this._unidad_destino == null)
                    this._unidad_destino = new UnidadesService(this.UnidadIdDestino);
                return this._unidad_destino;
            }
        }

        private UnidadesService _unidad_origen;
        public UnidadesService UnidadOrigen
        {
            get
            {
                if (this._unidad_origen == null)
                    this._unidad_origen = new UnidadesService(this.UnidadIdOrigen);
                return this._unidad_origen;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.FACTURAS_PROVEEDOR_DETALLECollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new FACTURAS_PROVEEDOR_DETALLERow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(FACTURAS_PROVEEDOR_DETALLERow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public FacturasProveedorDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public FacturasProveedorDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public FacturasProveedorDetalleService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public FacturasProveedorDetalleService(EdiCBA.FacturaProveedorDetalle edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = FacturasProveedorDetalleService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 
            
            #region articulo
            if (!string.IsNullOrEmpty(edi.articulo_uuid))
                this._articulo = ArticulosService.GetPorUUID(edi.articulo_uuid, sesion);
            

            if (this._articulo != null && !this._articulo.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this._articulo != null && this._articulo.Id.HasValue)
                this.ArticuloId = this._articulo.Id.Value;
            #endregion articulo

            this.CantidadEmbaladaDestino = edi.cantidad_embalada_destino;
            this.CantidadEmbaladaOrigen = edi.cantidad_embalada_origen;
            this.CantidadPorCajaDestino = edi.cantidad_por_caja_destino;
            this.CantidadPorCajaOrigen = edi.cantidad_por_caja_origen;
            this.CantidadUnidadDestino = edi.cantidad_unitaria_destino;
            this.CantidadUnidadOrigen = edi.cantidad_unitaria_origen;
            this.CantidadUnitariaTotalDest = edi.cantidad_unitaria_total_destino;
            this.CantidadUnitariaTotalOrig = edi.cantidad_unitaria_total_origen;
            
            this.FactorConversion = edi.factor_conversion;

            #region factura proveedor
            if (!string.IsNullOrEmpty(edi.factura_proveedor_uuid))
                this._factura_proveedor = FacturasProveedorService.GetPorUUID(edi.factura_proveedor_uuid, sesion);
            if (this._factura_proveedor == null && edi.factura_proveedor != null)
                this._factura_proveedor = new FacturasProveedorService(edi.factura_proveedor, almacenar_localmente, sesion);
            if (this._factura_proveedor != null)
            {
                if (!this.FacturaProveedor.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.FacturaProveedor.Id.HasValue)
                    this.FacturasProveedorId = this.FacturaProveedor.Id.Value;
            }
            #endregion factura proveedor
            
            #region impuesto
            if (!string.IsNullOrEmpty(edi.impuesto_uuid))
                this._impuesto = ImpuestosService.GetPorUUID(edi.impuesto_uuid, sesion);
            if (this._impuesto == null && edi.impuesto != null)
                this._impuesto = new ImpuestosService(edi.impuesto, almacenar_localmente, sesion);
            if (this._impuesto == null)
                throw new Exception("No se encontró el UUID " + edi.impuesto_uuid + " ni se definieron los datos del objeto.");

            if (!this.Impuesto.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Impuesto.Id.HasValue)
            {
                this.ImpuestoId = this.Impuesto.Id.Value;
                this.PorcentajeImpuesto = this.Impuesto.Porcentaje;
            }
            #endregion impuesto
            
            #region lote
            if (!string.IsNullOrEmpty(edi.lote_uuid))
                this._lote = ArticulosLotesService.GetPorUUID(edi.lote_uuid, sesion);
          
            if (this._lote != null && !this._lote.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this._lote != null && this._lote.Id.HasValue)
                this.LoteId = this._lote.Id.Value;
            #endregion lote

            #region rubro
            if (!string.IsNullOrEmpty(edi.rubro_uuid))
                this._rubro = RubrosService.GetPorUUID(edi.rubro_uuid, sesion);
            if (this._rubro == null && edi.rubro != null)
                this._rubro = new RubrosService(edi.rubro, almacenar_localmente, sesion);

            if (this._rubro != null && !this._rubro.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this._rubro != null && this._rubro.Id.HasValue)
                this.RubroId = this._rubro.Id.Value;
            #endregion rubro

            this.Observacion = edi.observacion;
            this.PorcentajeDescuento = edi.porcentaje_descuento;
            this.PrecioBrutoUnitarioDest = edi.precio_unitario;
            this.TotalBruto = edi.total_bruto;
            this.TotalDescuento = edi.total_descuento;
            this.TotalImpuestoDescontado = edi.total_impuesto;
            this.TotalPago = edi.total_neto;

            if (edi.unidad_destino == null)
                throw new Exception("El EDI debe contener el objeto 'unidad_destino'.");
            this.UnidadIdDestino = edi.unidad_destino.simbolo;
            if (edi.unidad_origen == null)
                throw new Exception("El EDI debe contener el objeto 'unidad_origen'.");
            this.UnidadIdOrigen = edi.unidad_origen.simbolo;
        }
        private FacturasProveedorDetalleService(FACTURAS_PROVEEDOR_DETALLERow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCabecera
        public static FacturasProveedorDetalleService[] GetPorCabecera(decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCabecera(cabecera_id, sesion);
            }
        }

        public static FacturasProveedorDetalleService[] GetPorCabecera(decimal cabecera_id, SessionService sesion)
        {
            var rows = sesion.db.FACTURAS_PROVEEDOR_DETALLECollection.GetAsArray(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = "  + cabecera_id, FacturasProveedorDetalleService.Id_NombreCol);
            FacturasProveedorDetalleService[] fcd = new FacturasProveedorDetalleService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                fcd[i] = new FacturasProveedorDetalleService(rows[i]);
            return fcd;
        }
        #endregion GetPorCabecera

        #region GetStockMovimiento
        public StockMovimientoService GetStockMovimiento(SessionService sesion)
        {
            return GetStockMovimiento(this.FacturaProveedor.CasoId, sesion);
        }
        
        public StockMovimientoService GetStockMovimiento(decimal caso_id, SessionService sesion)
        {
            var sm = new StockMovimientoService();
            sm.IniciarUsingSesion(sesion);

            var movimiento = StockMovimientoService.Instancia.GetPrimero<StockMovimientoService>(new ClaseCBABase.Filtro[] {
                new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.CASO_IDColumnName, Valor = caso_id },
                new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.REGISTRO_IDColumnName, Valor = this.Id.Value }
            });

            sm.FinalizarUsingSesion();

            return movimiento;
        }
        #endregion GetStockMovimiento

      

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._articulo = null;
            this._factura_proveedor = null;
            this._impuesto = null;
            this._lote = null;
            this._rubro = null;
            this._texto_predefinido = null;
            this._unidad_destino = null;
            this._unidad_origen = null;
        }
        #endregion ResetearPropiedadesExtendidas
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
