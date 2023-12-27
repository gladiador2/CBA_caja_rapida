#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.General;

using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.TextosPredefinidos;
#endregion Using

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosService
    {
        #region Booleans

        #region EstaActivo
        public static bool EstaActivo(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return EstaActivo(articulo_id, sesion);
            }
        }

        public static bool EstaActivo(decimal articulo_id, SessionService sesion)
        {
            ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetRow(ArticulosService.Id_NombreCol + " = " + articulo_id);
            return articulo.ESTADO == Definiciones.Estado.Activo;
        }
        #endregion EstaActivo

        #region GetControlarPrecio
        /// <summary>
        /// Gets the controlar precio.
        /// </summary>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static bool GetControlarPrecio(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetControlarPrecio(articulo_id, sesion);
            }
        }

        public static bool GetControlarPrecio(decimal articulo_id, SessionService sesion)
        {
            ARTICULOSRow row = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(articulo_id);
            return row.CONTROLAR_PRECIO == Definiciones.SiNo.Si;
        }
        #endregion GetControlarPrecio

        #region EsServicio
        /// <summary>
        /// Eses the servicio.
        /// </summary>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <returns></returns>
        public static bool EsServicio(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return EsServicio(articulo_id, sesion);
            }
        }

        public static bool EsServicio(decimal articulo_id, SessionService sesion)
        {
            ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetRow(ArticulosService.Id_NombreCol + " = " + articulo_id);
            return articulo.SERVICIO == Definiciones.SiNo.Si;
        }
        #endregion EsServicio

        #region EsParaVenta
        public static bool EsParaVenta(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetRow(ArticulosService.Id_NombreCol + " = " + articulo_id);
                return articulo.PARA_VENTA == Definiciones.SiNo.Si;
            }
        }
        #endregion EsParaVenta

        #region EsArticuloPadreRaiz
        // devulve -1, si es articulo padre raiz
        public static decimal GetArticuloPadreIdPorArticuloId(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetRow(ArticulosService.Id_NombreCol + " = " + articulo_id);
                return articulo.IsARTICULO_PADRE_IDNull ? Definiciones.Error.Valor.EnteroPositivo : articulo.ARTICULO_PADRE_ID ;
            }
        }
        #endregion EsArticuloPadreRaiz

        #region GetArticulosHijosPorArticulosId
        public static string GetArticulosHijosPorArticulosId(string articulos_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = " select LISTAGG(a.id,',') ids from articulos a " +
                                  " where a.articulo_padre_id in (" + articulos_id + ")" +
                                  " order by a.articulo_padre_id";
              DataTable dt=  sesion.Db.EjecutarQuery(clausula);
              if (dt.Rows.Count > 0)
                  return dt.Rows[0][0].ToString();
              else return string.Empty;
            }
        }
        #endregion GetArticulosHijosPorArticulosId

        #region GetArticulosPadreRaizPorArticuloId
        public static decimal GetArticuloPadreRaizPorArticuloId(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = " id = " + articulo_id + "" ;
                decimal idArticuloPadreRaiz = articulo_id;
                DataTable dt = new DataTable();
                dt = sesion.Db.ARTICULOSCollection.GetAsDataTable(clausula, string.Empty);

                while (dt.Rows.Count > 0)
                {

                    idArticuloPadreRaiz = dt.Rows[0][ArticulosService.ArticuloPadreId_NombreCol].Equals(System.DBNull.Value) ? idArticuloPadreRaiz : decimal.Parse(dt.Rows[0][ArticulosService.ArticuloPadreId_NombreCol].ToString());
                decimal    idArticuloPadreRaizAux = dt.Rows[0][ArticulosService.ArticuloPadreId_NombreCol].Equals(System.DBNull.Value) ? Definiciones.Error.Valor.EnteroPositivo : decimal.Parse(dt.Rows[0][ArticulosService.ArticuloPadreId_NombreCol].ToString());
                   
                    clausula = " id = " + idArticuloPadreRaizAux;
                    dt = sesion.Db.ARTICULOSCollection.GetAsDataTable(clausula, string.Empty);
                
                }
                return idArticuloPadreRaiz;
                
            }
        }
        #endregion GetArticulosPadreRaizPorArticuloId

        #region EsDeProduccionInterna
        public static bool EsDeProduccionInterna(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetRow(ArticulosService.Id_NombreCol + " = " + articulo_id);
                return articulo.PRODUCCION_INTERNA == Definiciones.SiNo.Si;
            }
        }
        #endregion EsDeProduccionInterna

        #region EsCombo
        public static bool EsComboRepresentativo(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow row = ArticulosService.GetArticuloRowPorID(articulo_id);
                return row.ES_COMBO_REPRESENTATIVO == Definiciones.SiNo.Si;
            }
        }
        public static bool EsComboAbierto(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow row = ArticulosService.GetArticuloRowPorID(articulo_id);
                return row.ES_COMBO_ABIERTO == Definiciones.SiNo.Si;
            }
        }
        public static bool EsFormula(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow row = ArticulosService.GetArticuloRowPorID(articulo_id);
                return row.ES_FORMULA == Definiciones.SiNo.Si;
            }
        }
        public static string TipoFormula(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow row = ArticulosService.GetArticuloRowPorID(articulo_id);
                return row.TIPO_FORMULA;
            }
        }
        public static bool EsCombo(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow row = ArticulosService.GetArticuloRowPorID(articulo_id);
                return row.ES_COMBO == Definiciones.SiNo.Si;
            }
        }
        #endregion EsCombo

        #region EsTrazable
        public static bool EsTrazable(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return EsTrazable(articulo_id, sesion);
            }
        }

        public static bool EsTrazable(decimal articulo_id, SessionService sesion)
        {

            ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetRow(ArticulosService.Id_NombreCol + " = " + articulo_id);
            return articulo.ES_TRAZABLE == Definiciones.SiNo.Si;

        }
        #endregion EsTrazable

        #region TieneRegargoFinanciero
        /// <summary>
        /// Tienes the regargo financiero.
        /// </summary>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <returns></returns>
        public static bool TieneRegargoFinanciero(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(articulo_id);
                return articulo.RECARGO_FINANCIERO == Definiciones.SiNo.Si;
            }
        }
        #endregion TieneRegargoFinanciero

        #region IngresoAprobado
        public static bool IngresoAprobado(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetRow(ArticulosService.Id_NombreCol + " = " + articulo_id);
                return articulo.INGRESO_APROBADO == Definiciones.SiNo.Si;
            }
        }
        #endregion IngresoAprobado

        #region GetEsUsado
        public static string GetEsUsado(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetEsUsado(articulo_id, sesion);
            }
        }

        public static string GetEsUsado(decimal articulo_id, SessionService sesion)
        {
            return sesion.Db.ARTICULOSCollection.GetByPrimaryKey(articulo_id).ES_USADO;
        }

        #endregion GetEsUsado

        #region GetEsDanhado
        public static string GetEsDanhado(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetEsDanhado(articulo_id, sesion);
            }
        }

        public static string GetEsDanhado(decimal articulo_id, SessionService sesion)
        {
            return sesion.Db.ARTICULOSCollection.GetByPrimaryKey(articulo_id).ES_DANHADO;
        }
        #endregion GetEsDanhado

        #region GetCantidadPorCaja
        public static decimal GetCantidadPorCaja(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOSCollection.GetByPrimaryKey(articulo_id).CANTIDAD_POR_CAJA;
            }
        }
        #endregion GetCantidadPorCaja
        #endregion Booleans

        #region Getters
        public static decimal GetCentroCosto(decimal articulo_id, SessionService sesion)
        {
            ARTICULOSRow row = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(articulo_id);
            return row.IsCENTRO_COSTO_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.CENTRO_COSTO_ID;
        }

        public static ARTICULOSRow GetArticuloRowPorID(decimal vIDArticulo)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOSCollection.GetByPrimaryKey(vIDArticulo);
            }
        }

        public static ARTICULOSRow GetArticuloRowPorID(decimal vIDArticulo, SessionService sesion)
        {
            return sesion.Db.ARTICULOSCollection.GetByPrimaryKey(vIDArticulo);
        }

        public static DataTable GetArticuloPorID(string vIDArticulo, SessionService sesion)
        {
            return GetArticulosDataTable(ArticulosService.Id_NombreCol + " = " + vIDArticulo, string.Empty, sesion, false);//xx
        }

        public static DataTable GetArticuloPorID(string vIDArticulo)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetArticulosDataTable(ArticulosService.Id_NombreCol + " = " + vIDArticulo, string.Empty, sesion, false);
            }
        }

        public static DataTable GetArticuloInfoCompletaPorID(decimal vIDArticulo, decimal? sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetArticuloInfoCompletaPorID(vIDArticulo, sucursal_id, sesion);
            }
        }
        public static DataTable GetArticuloInfoCompletaPorID(decimal vIDArticulo, decimal? sucursal_id, SessionService sesion)
        {
            return GetArticulosInfoCompleta(ArticulosService.Id_NombreCol + " = " + vIDArticulo, string.Empty, false, sucursal_id, sesion);
        }

        public static DataTable GetArticulosDataTable(string clausulas, string orden, bool soloActivos, decimal? sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetArticulosDataTable(clausulas, orden, soloActivos, sucursal_id, sesion);
            }
        }

        public static DataTable GetArticulosDataTable(string clausulas, string orden, bool soloActivos, decimal? sucursal_id, SessionService sesion)
        {
            string where = ArticulosService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
            if (clausulas.Length > 0) where += " and " + clausulas;
            if (soloActivos) where += " and " + ArticulosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionArticuloIndependiente) == Definiciones.SiNo.Si)
            {
                if (!sucursal_id.HasValue)
                    sucursal_id = sesion.Usuario.SUCURSAL_ACTIVA_ID;

                var sucursal = new SucursalesService(sucursal_id.Value, sesion);
                where += " and (" + ArticulosService.RegionId_NombreCol + " is null or " + ArticulosService.RegionId_NombreCol + " = " + sucursal.RegionId.Value + ") ";
            }

            return sesion.Db.ARTICULOSCollection.GetAsDataTable(where, orden);
        }
        public static DataTable GetArticulosDataTable(string clausulas, string orden, SessionService sesion, bool soloActivos)
        {

            string where = ArticulosService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
            if (clausulas.Length > 0) where += " and " + clausulas;
            if (soloActivos) where += " and " + ArticulosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            return sesion.Db.ARTICULOSCollection.GetAsDataTable(where, orden);

        }
        public static string GetPathImagen(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow row = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(articulo_id);
                return row.IMAGEN_PATH_TMP;
            }
        }
        public static decimal GetCantMaxima(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow row = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(articulo_id);
                return row.CANTIDAD_MAXIMA;
            }
        }
        public static decimal GetCantMinima(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow row = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(articulo_id);
                return row.CANTIDAD_MINIMA;
            }
        }

        
       

        #endregion Getters

        #region PuedeConvertirseATrazable
        /// <summary>
        /// Puedes the convertirse A trazable.
        /// </summary>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <returns></returns>
        public static bool PuedeConvertirseATrazable(decimal articulo_id)
        {
            return StockService.GetExistenciaMayorAUno(articulo_id);
        }
        #endregion PuedeConvertirseATrazable

        

        #region Guardar
        public static decimal GuardarImagenPathTmp(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal id = GuardarImagenPathTmp(campos, sesion);
                    sesion.CommitTransaction();

                    return id;
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public static decimal GuardarImagenPathTmp(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                ARTICULOSRow row = new ARTICULOSRow();
                row = sesion.Db.ARTICULOSCollection.GetByPrimaryKey((decimal)campos[ArticulosService.Id_NombreCol]);
                row.IMAGEN_PATH_TMP = campos[ArticulosService.ImagenPathTmp_Nombrecol].ToString();
                sesion.Db.ARTICULOSCollection.Update(row);
                return row.ID;
            }
            catch
            {
                sesion.RollbackTransaction();
                throw;
            }
        }

        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>

        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                ARTICULOSRow row = new ARTICULOSRow();
                decimal dAux;
                string valorAnterior = string.Empty;

                DataTable dtArticulo;
                string where = string.Empty; 
                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("articulos_sqc");
                    row.ENTIDAD_ID = sesion.Entidad.ID;
                    row.INGRESO_APROBADO = Definiciones.SiNo.Si;//VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.AprobacionIngresoArticulos);
                    row.ES_COMBO_ABIERTO = Definiciones.SiNo.No;

                    row.FECHA_APROBACION = DateTime.Now;
                    row.USUARIO_APROBACION_ID = sesion.Usuario.ID;
                    row.ES_MODIFICABLE = Definiciones.SiNo.Si;
                }
                else
                {
                    row = sesion.Db.ARTICULOSCollection.GetByPrimaryKey((decimal)campos[ArticulosService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }
                if (campos.Contains(ArticulosService.ActivoId_NombreCol))
                    row.ACTIVO_ID = (decimal)campos[ArticulosService.ActivoId_NombreCol];
                if (campos.Contains(ArticulosService.Retencion_Nombrecol))
                    row.RETENCION = (decimal)campos[ArticulosService.Retencion_Nombrecol];

                if (campos.Contains(ArticulosService.RegionId_NombreCol))
                    row.REGION_ID = (decimal)campos[ArticulosService.RegionId_NombreCol];
                else
                    row.IsREGION_IDNull = true;

                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionArticuloIndependiente) == Definiciones.SiNo.Si)
                {
                    if (row.IsREGION_IDNull)
                        throw new Exception("Debe indicar una región.");
                }

                if (campos.Contains(ArticulosService.CodigoEmpresa_NombreCol))
                {
                    row.CODIGO_EMPRESA = ((string)campos[ArticulosService.CodigoEmpresa_NombreCol]).Trim();

                    where = " upper(" + ArticulosService.CodigoEmpresa_NombreCol + ") =  upper('" + row.CODIGO_EMPRESA + "') and " +
                                   ArticulosService.Id_NombreCol + " <> " + row.ID;

                    if (row.IsREGION_IDNull)
                        dtArticulo = GetArticulos(where, string.Empty, true, null);
                    else
                        dtArticulo = GetArticulos(where, string.Empty, true, new RegionesService(row.REGION_ID).SucursalCasaMatriz.Id.Value);

                    if (dtArticulo.Rows.Count > 0)
                        throw new Exception("El código ya existe");
                }                       

                if (campos.Contains(ArticulosService.CodigoBalanza_NombreCol))
                {
                    where = ArticulosService.Id_NombreCol + " != " + row.ID + " and " + ArticulosService.CodigoBalanza_NombreCol + " = '" + campos[ArticulosService.CodigoBalanza_NombreCol].ToString() + 
                        "' and " + ArticulosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

                    dtArticulo = GetArticulos(where, string.Empty, true, null);

                    if (dtArticulo.Rows.Count > 0)
                        throw new Exception("El código de balanza ya existe");

                    row.CODIGO_BALANZA = ((string)campos[ArticulosService.CodigoBalanza_NombreCol]).Trim();
                }
                if (campos.Contains(ArticulosService.CodigoBarrasEmpresa_NombreCol))
                    row.CODIGO_BARRAS_EMPRESA = ((string)campos[ArticulosService.CodigoBarrasEmpresa_NombreCol]).Trim();
                if (campos.Contains(ArticulosService.CodigoBarrasProveedor_NombreCol))
                    row.CODIGO_BARRAS_PROVEEDOR = ((string)campos[ArticulosService.CodigoBarrasProveedor_NombreCol]).Trim();
                if (campos.Contains(ArticulosService.CodigoCatalogoProveedor_NombreCol))
                    row.CODIGO_CATALOGO_PROVEEDOR = ((string)campos[ArticulosService.CodigoCatalogoProveedor_NombreCol]).Trim();
                if (campos.Contains(ArticulosService.CodigoProveedor_NombreCol))
                    row.CODIGO_PROVEEDOR = ((string)campos[ArticulosService.CodigoProveedor_NombreCol]).Trim();
                if (campos.Contains(ArticulosService.DescripcionImpresion_NombreCol))
                    row.DESCRIPCION_IMPRESION = ((string)campos[ArticulosService.DescripcionImpresion_NombreCol]).Trim();
                if (campos.Contains(ArticulosService.DescripcionCatalogo_NombreCol))
                    row.DESCRIPCION_CATALOGO = ((string)campos[ArticulosService.DescripcionCatalogo_NombreCol]).Trim();
                if (campos.Contains(ArticulosService.DescripcionInterna_NombreCol))
                    row.DESCRIPCION_INTERNA = ((string)campos[ArticulosService.DescripcionInterna_NombreCol]).Trim();
                if (campos.Contains(ArticulosService.DescripcionProveedor_NombreCol))
                    row.DESCRIPCION_PROVEEDOR = ((string)campos[ArticulosService.DescripcionProveedor_NombreCol]).Trim();

                row.CANTIDAD_POR_CAJA = (decimal)campos[ArticulosService.CantidadPorCaja_NombreCol];
                row.CANTIDAD_MAYORISTA = (decimal)campos[ArticulosService.Cantidad_Mayorista_Nombrecol];
                row.CANTIDAD_MAXIMA = (decimal)campos[ArticulosService.Cantidad_Maxima_Nombrecol];
                row.CANTIDAD_MINIMA = (decimal)campos[ArticulosService.Cantidad_Minima_Nombrecol];

                row.CANTIDAD_MAXIMA_PRODUCCION = (decimal)campos[ArticulosService.CantidadMaximaProduccion_NombreCol];
                row.CANTIDAD_MINIMA_PRODUCCION = (decimal)campos[ArticulosService.CantidadMinimaProduccion_NombreCol];

                row.ESTADO = campos[ArticulosService.Estado_NombreCol].ToString();
                row.IMPORTADO = (string)campos[ArticulosService.Importado_NombreCol];
                row.IMPUESTO_ID = (decimal)campos[ArticulosService.ImpuestoId_NombreCol];
                row.IMPUESTO_COMPRA_ID = (decimal)campos[ArticulosService.ImpuestoCompraId_NombreCol];
                row.NO_REPONER = (string)campos[ArticulosService.NoReponer_NombreCol];
                row.PRODUCCION_INTERNA = (string)campos[ArticulosService.ProduccionInterna_NombreCol];
                row.RECARGO_FINANCIERO = Definiciones.SiNo.No;
                row.CONTROLAR_PRECIO = Definiciones.SiNo.Si;
                row.SERVICIO = (string)campos[ArticulosService.Servicio_NombreCol];
                row.UNIDAD_MEDIDA_ID = campos[ArticulosService.UnidadMedidaId_NombreCol].ToString();

                row.ES_OBSOLETO = Definiciones.SiNo.No;
                row.ES_DANHADO = Definiciones.SiNo.No;
                row.ES_USADO = Definiciones.SiNo.No;

                // Campos opcionales simples
                if (campos.Contains(ArticulosService.Unidad_Medida_Control_Nombrecol))
                    row.UNIDAD_MEDIDA_CONTROL = campos[ArticulosService.Unidad_Medida_Control_Nombrecol].ToString();

                if (campos.Contains(ArticulosService.CentroCostoId_NombreCol))
                    row.CENTRO_COSTO_ID = (decimal)campos[ArticulosService.CentroCostoId_NombreCol];
                else
                    row.IsCENTRO_COSTO_IDNull = true;

                if (campos.Contains(ArticulosService.CostoBaseMonto_Nombrecol))
                    row.COSTO_BASE_MONTO = (decimal)campos[CostoBaseMonto_Nombrecol];

                if (campos.Contains(ArticulosService.CostoBaseMonedaId_Nombrecol))
                    row.COSTO_BASE_MONEDA_ID = (decimal)campos[CostoBaseMonedaId_Nombrecol];

                if (campos.Contains(ArticulosService.CostoBaseCotizacionMoneda_Nombrecol))
                    row.COSTO_BASE_COTIZACION = (decimal)campos[CostoBaseCotizacionMoneda_Nombrecol];

                if (campos.Contains(EsCombo_NombreCol))
                    row.ES_COMBO = (string)campos[ArticulosService.EsCombo_NombreCol];

                if (campos.Contains(EsFormula_Nombrecol))
                    row.ES_FORMULA = (string)campos[ArticulosService.EsFormula_Nombrecol];

                if (campos.Contains(ArticulosService.Procedencia_NombreCol))
                    row.PROCEDENCIA = (decimal)campos[ArticulosService.Procedencia_NombreCol];

                if (campos.Contains(ArticulosService.ArticuloLineaId_NombreCol))
                    row.ARTICULO_LINEA_ID = (decimal)campos[ArticulosService.ArticuloLineaId_NombreCol];

                if (campos.Contains(ArticulosService.ArticuloPadreId_NombreCol))
                {
                    row.ARTICULO_PADRE_ID = (decimal)campos[ArticulosService.ArticuloPadreId_NombreCol];
                    row.PORCENTAJE_PRECIO_PADRE = (decimal)campos[ArticulosService.PorcentajePrecioPadre_NombreCol];
                    row.MONTO_PRECIO_PADRE = (decimal)campos[ArticulosService.MontoPrecioPadre_NombreCol];

                }
                else
                {
                    row.IsARTICULO_PADRE_IDNull = true;
                    row.PORCENTAJE_PRECIO_PADRE = (decimal)0;
                    row.MONTO_PRECIO_PADRE = (decimal)0;
                }

                if (campos.Contains(ArticulosService.Genero_NombreCol))
                    row.GENERO = (string)campos[ArticulosService.Genero_NombreCol];

                if (campos.Contains(ArticulosService.MarcaId_Nombrecol))
                    row.ARTICULO_MARCA_ID = (decimal)campos[ArticulosService.MarcaId_Nombrecol];

                if (campos.Contains(ArticulosService.ImpuestoCompraId_NombreCol))
                    row.IMPUESTO_COMPRA_ID = (decimal)campos[ArticulosService.ImpuestoCompraId_NombreCol];

                if (campos.Contains(ArticulosService.FamiliaId_NombreCol))
                {
                    dAux = (decimal)campos[ArticulosService.FamiliaId_NombreCol];
                    if (row.IsFAMILIA_IDNull || row.FAMILIA_ID != dAux)
                    {
                        if (ArticulosFamiliasService.EstaActivo(dAux))
                            row.FAMILIA_ID = dAux;
                        else
                            throw new System.ArgumentException("La familia seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }
                }
                else
                {
                    row.IsFAMILIA_IDNull = true;
                }

                if (campos.Contains(ArticulosService.GrupoId_NombreCol))
                {
                    dAux = (decimal)campos[ArticulosService.GrupoId_NombreCol];
                    if (row.IsGRUPO_IDNull || row.GRUPO_ID != dAux)
                    {
                        if (ArticulosGruposService.EstaActivo(dAux))
                            row.GRUPO_ID = dAux;
                        else
                            throw new System.ArgumentException("El grupo seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }
                }
                else
                {
                    row.IsGRUPO_IDNull = true;
                }

                if (campos.Contains(ArticulosService.SubgrupoId_NombreCol))
                {
                    dAux = (decimal)campos[ArticulosService.SubgrupoId_NombreCol];
                    if (row.IsSUBGRUPO_IDNull || row.SUBGRUPO_ID != dAux)
                    {
                        if (ArticulosSubgruposService.EstaActivo(dAux))
                            row.SUBGRUPO_ID = dAux;
                        else
                            throw new System.ArgumentException("El subgrupo seleccionado se encuentra inactivo. Los cambios no fueron guardados.");

                        CatalogosDetallesService[] cd = ClaseCBA<CatalogosDetallesService>.Instancia.GetFiltrado<CatalogosDetallesService>(new ClaseCBABase.Filtro { Columna = CatalogosDetallesService.Modelo.ARTICULO_IDColumnName, Valor = row.ID });
                        for (int i = 0; i < cd.Length; i++)
                        {
                            try
                            {
                                cd[i].IniciarUsingSesion(sesion);
                                cd[i].FamiliaId = row.FAMILIA_ID;
                                cd[i].GrupoId = row.GRUPO_ID;
                                cd[i].SubGrupoId = row.SUBGRUPO_ID;
                                cd[i].Guardar();
                                cd[i].FinalizarUsingSesion();
                            }
                            catch
                            {
                                cd[i].FinalizarUsingSesion();
                                throw;
                            }
                        }
                    }
                }
                else
                {
                    row.IsGRUPO_IDNull = true;
                }

                if (campos.Contains(ArticulosService.CodigoPresentacionId_NombreCol))
                {
                    dAux = (decimal)campos[ArticulosService.CodigoPresentacionId_NombreCol];
                    if (row.IsCODIGO_PRESENTACION_IDNull || row.CODIGO_PRESENTACION_ID != dAux)
                    {
                        if (ArticulosPresentacionesService.EstaActivo(dAux))
                            row.CODIGO_PRESENTACION_ID = dAux;
                        else
                            throw new System.ArgumentException("La presentación seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }
                }
                else
                {
                    row.IsCODIGO_PRESENTACION_IDNull = true;
                }

                if (campos.Contains(ArticulosService.CodigoEmpaqueId_NombreCol))
                {
                    dAux = (decimal)campos[ArticulosService.CodigoEmpaqueId_NombreCol];
                    if (row.IsCODIGO_EMPAQUE_IDNull || row.CODIGO_EMPAQUE_ID != dAux)
                    {
                        if (ArticulosEmpaquesService.EstaActivo(dAux))
                            row.CODIGO_EMPAQUE_ID = dAux;
                        else
                            throw new System.ArgumentException("El empaque seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }
                }
                else
                {
                    row.IsCODIGO_EMPAQUE_IDNull = true;
                }

                if (campos.Contains(ArticulosService.CodigoColorId_NombreCol))
                {
                    dAux = (decimal)campos[ArticulosService.CodigoColorId_NombreCol];
                    if (row.IsCODIGO_COLOR_IDNull || row.CODIGO_COLOR_ID != dAux)
                    {
                        if (ArticulosColoresService.EstaActivo(dAux))
                            row.CODIGO_COLOR_ID = dAux;
                        else
                            throw new System.ArgumentException("El color seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }
                }
                else
                {
                    row.IsCODIGO_COLOR_IDNull = true;
                }

                if (campos.Contains(ArticulosService.CodigoTalleId_NombreCol))
                {
                    dAux = (decimal)campos[ArticulosService.CodigoTalleId_NombreCol];
                    if (row.IsCODIGO_TALLE_IDNull || row.CODIGO_TALLE_ID != dAux)
                        if (ArticulosTallesService.EstaActivo(dAux))
                            row.CODIGO_TALLE_ID = dAux;
                        else
                            throw new System.ArgumentException("El talle seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                }
                else
                {
                    row.IsCODIGO_TALLE_IDNull = true;
                }

                if (campos.Contains(EsTrazable_NombreCol))
                {
                    string trazable = (string)campos[ArticulosService.EsTrazable_NombreCol];

                    if (trazable.Equals(Definiciones.SiNo.Si))
                    {
                        if (insertarNuevo)
                        {
                            row.ES_TRAZABLE = row.ES_TRAZABLE = (string)campos[ArticulosService.EsTrazable_NombreCol];
                        }
                        else
                        {
                            if (!PuedeConvertirseATrazable(row.ID))
                                throw new ArgumentException("El Articulo no es trazable.");
                            else
                                row.ES_TRAZABLE = (string)campos[ArticulosService.EsTrazable_NombreCol];
                        }
                    }
                    else
                    {
                        row.ES_TRAZABLE = (string)campos[ArticulosService.EsTrazable_NombreCol];
                    }

                    if (campos.Contains(ArticulosService.ParaVenta_NombreCol))
                        row.PARA_VENTA = (string)campos[ArticulosService.ParaVenta_NombreCol];
                    else
                        row.PARA_VENTA = Definiciones.SiNo.Si;

                    if (campos.Contains(ArticulosService.ParaCompra_NombreCol))
                        row.PARA_COMPRA = (string)campos[ArticulosService.ParaCompra_NombreCol];
                    else
                        row.PARA_COMPRA = Definiciones.SiNo.Si;
                }
                row.ES_COMBO_REPRESENTATIVO = Definiciones.SiNo.No;

                row.ES_FORMULA = Definiciones.SiNo.No;

                if (campos[ArticulosService.EsFormula_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                    row.ES_FORMULA = (string)campos[ArticulosService.EsFormula_NombreCol];
                else
                {
                    row.ES_FORMULA = Definiciones.SiNo.No;
                    row.TIPO_FORMULA = null;
                }
                if (campos.Contains(ArticulosService.TipoFormula_NombreCol))
                    row.TIPO_FORMULA = (string)campos[ArticulosService.TipoFormula_NombreCol];
               
                if (insertarNuevo)
                    sesion.Db.ARTICULOSCollection.Insert(row);
                else
                    sesion.Db.ARTICULOSCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                //insertar un lote por defecto al crear
                if (insertarNuevo)
                {
                    var al = new ArticulosLotesService();
                    al.IniciarUsingSesion(sesion);
                    al.ArticuloId = row.ID;
                    al.Lote = row.CODIGO_EMPRESA;
                    al.Guardar();
                    al.FinalizarUsingSesion();

                    if (row.ES_COMBO.Equals(Definiciones.SiNo.Si) && row.ES_COMBO_ABIERTO.Equals(Definiciones.SiNo.No))
                    {
                        ARTICULOS_LOTESRow[] lotesRow = sesion.db.ARTICULOS_LOTESCollection.GetByARTICULO_ID(row.ID);
                        for (int k = 0; k < lotesRow.Length; k++)
                        {
                            SUCURSALESRow[] sucursales = sesion.db.SUCURSALESCollection.GetAll();
                            for (int i = 0; i < sucursales.Length; i++)
                            {
                                STOCK_DEPOSITOSRow[] depositos = sesion.db.STOCK_DEPOSITOSCollection.GetBySUCURSAL_ID(sucursales[i].ID);
                                for (int j = 0; j < depositos.Length; j++)
                                {
                                    STOCK_SUC_DEPOSITO_ARTICULORow stock = new STOCK_SUC_DEPOSITO_ARTICULORow();
                                    stock.ID = sesion.Db.GetSiguienteSecuencia("STOCK_SUC_DEPOSITO_ART_SQC");
                                    stock.SUCURSAL_ID = sucursales[i].ID;
                                    stock.DEPOSITO_ID = depositos[j].ID;
                                    stock.ARTICULO_ID = row.ID;
                                    stock.ARTICULO_LOTE_ID = lotesRow[k].ID;
                                    sesion.db.STOCK_SUC_DEPOSITO_ARTICULOCollection.Insert(stock);
                                }
                            }
                        }
                    }
                }

                return row.ID;
            }
            catch (OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                        throw new System.ArgumentException("Ya existe un registro con ese código en la empresa.");
                    default: throw exp;
                }
            }
        }
        #endregion Guardar

        #region Devolucion
        public static ARTICULOSRow CrearArticuloDevolucion(decimal nota_credito_id, decimal id, decimal tipo_nc, decimal lote_id, out decimal lote_nuevo_id, decimal costoBase, SessionService sesion)
        {
            ARTICULOSRow articuloClon = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(id);
            articuloClon.ID = sesion.Db.GetSiguienteSecuencia(Secuencia);
            articuloClon.CODIGO_EMPRESA = ArticulosCreadosDevolucionService.GenerarCodigo(id, tipo_nc);
            articuloClon.DESCRIPCION_INTERNA += " - " + DateTime.Now.ToShortDateString();
            articuloClon.DESCRIPCION_IMPRESION = articuloClon.DESCRIPCION_INTERNA;
            articuloClon.DESCRIPCION_CATALOGO = articuloClon.DESCRIPCION_CATALOGO;
            articuloClon.NOTA_CREDITO_ID = nota_credito_id;
            articuloClon.COSTO_BASE_MONTO = costoBase;
            switch (int.Parse(tipo_nc.ToString()))
            {
                case Definiciones.TiposNotasCredito.RecuperoMercaderia:
                    articuloClon.ES_DANHADO = Definiciones.SiNo.No;
                    articuloClon.ES_USADO = Definiciones.SiNo.Si;
                    break;
                case Definiciones.TiposNotasCredito.DesperfectoMercaderia:
                    articuloClon.ES_DANHADO = Definiciones.SiNo.Si;
                    articuloClon.ES_USADO = Definiciones.SiNo.No;
                    break;
                default:
                    articuloClon.ES_DANHADO = Definiciones.SiNo.No;
                    articuloClon.ES_USADO = Definiciones.SiNo.No;
                    break;
            }

            sesion.Db.ARTICULOSCollection.Insert(articuloClon);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, articuloClon.ID, Definiciones.Log.RegistroNuevo, articuloClon.ToString(), sesion);

            // Se utiliza el código del articulo como nombre de lote
            string nombreLote = articuloClon.CODIGO_EMPRESA;
            // si el articulo es trazable de utiliza el nombre de lote Original
            if (articuloClon.ES_TRAZABLE.Equals(Definiciones.SiNo.Si))
                nombreLote = ArticulosLotesService.GetNombreLote(lote_id);

            var al = new ArticulosLotesService();
            al.IniciarUsingSesion(sesion);
            al.ArticuloId = articuloClon.ID;
            al.Lote = nombreLote;
            al.Guardar();
            al.FinalizarUsingSesion();

            lote_nuevo_id = al.Id.Value;

            return articuloClon;
        }
        #endregion Devolucion

        #region SetEsComboAbierto
        public static void SetEsComboAbierto(decimal articulo_id, bool abierto, SessionService sesion)
        {
            ARTICULOSRow row = ArticulosService.GetArticuloRowPorID(articulo_id);
            row.ES_COMBO_ABIERTO = abierto ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
            sesion.Db.ARTICULOSCollection.Update(row);
        }

        public static void SetEsComboAbierto(decimal articulo_id, bool abierto)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    SetEsComboAbierto(articulo_id, abierto, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion SetEsComboAbierto

        #region SetEsComboRepresentativo
        public static void SetEsComboRepresentativo(decimal articulo_id, bool representativo, SessionService sesion)
        {
            ARTICULOSRow row = ArticulosService.GetArticuloRowPorID(articulo_id);
            row.ES_COMBO_REPRESENTATIVO = representativo ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
            sesion.Db.ARTICULOSCollection.Update(row);
        }
        public static void SetEsComboRepresentativo(decimal articulo_id, bool representativo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    SetEsComboRepresentativo(articulo_id, representativo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion SetEsComboRepresentativo

        #region Familias, Grupos y SubGrupos
        public static DataTable GetArticulosPorSubGrupo(decimal id_subgrupo, decimal? sucursal_id)
        {
            string clausula = ArticulosService.SubgrupoId_NombreCol + " = " + id_subgrupo;
            DataTable dt = GetArticulosInfoCompleta(clausula, ArticulosService.VistaDescripcionAUtilizar_NombreCol, true, sucursal_id);
            return dt;
        }

        public static DataTable GetArticulosPorGrupo(decimal id_grupo, decimal? sucursal_id)
        {
            string clausula = ArticulosService.GrupoId_NombreCol + " = " + id_grupo;
            DataTable dt = GetArticulosInfoCompleta(clausula, ArticulosService.VistaDescripcionAUtilizar_NombreCol, true, sucursal_id);
            return dt;
        }

        public static DataTable GetArticulosPorFamilia(decimal id_familia, decimal? sucursal_id)
        {
            string clausula = ArticulosService.FamiliaId_NombreCol + " = " + id_familia;
            DataTable dt = GetArticulosInfoCompleta(clausula, ArticulosService.VistaDescripcionAUtilizar_NombreCol, true, sucursal_id);
            return dt;
        }

        #endregion Familias, Grupos y SubGrupos

        #region Statics
        public static DataTable GetArticulosPorCodigoExacto(string codigo, decimal? sucursal_id)
        {
            return GetArticulos(" upper(" + ArticulosService.CodigoEmpresa_NombreCol + ") =  upper('" + codigo + "') ", string.Empty, false, sucursal_id);
        }
        public static DataTable GetArticulosPorCodigoExacto(string codigo, decimal? sucursal_id, decimal? persona_id)
        {
            return GetArticulos(" upper(" + ArticulosService.CodigoEmpresa_NombreCol + ") =  upper('" + codigo + "') and " + ArticulosService.VistaPersonaId_NombreCol + " = " + persona_id, string.Empty, false, sucursal_id);
        }
        public static DataTable GetArticulos(string clausulas, string orden, bool soloActivos, decimal? sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetArticulos(clausulas, orden, soloActivos, sucursal_id, sesion);
            }
        }
        public static DataTable GetArticulosPorCodigoBarraExacto(string codigo, decimal? sucursal_id)
        {
            return GetArticulosPorCodigoBarraExacto(" upper(" + ArticulosService.CodigoBarrasEmpresa_NombreCol + ") =  upper('" + codigo + "') ", string.Empty, false, sucursal_id);
        }
        public static DataTable GetArticulosPorCodigoBarraExacto(string codigo, decimal? sucursal_id, decimal? persona_id)
        {
            return GetArticulosPorCodigoBarraExacto(" upper(" + ArticulosService.CodigoBarrasEmpresa_NombreCol + ") =  upper('" + codigo + "') and " + ArticulosService.VistaPersonaId_NombreCol + " = " + persona_id, string.Empty, false, sucursal_id);
        }
        public static DataTable GetArticulosPorCodigoBarraExacto(string clausulas, string orden, bool soloActivos, decimal? sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetArticulos(clausulas, orden, soloActivos, sucursal_id, sesion);
            }
        }
        /// <summary>
        /// Funcion que debe debuelve un unico registro en datatable.
        /// Realiza consultas con diferentes clausulas hasta obtener el registro o terminar las clausulas
        /// primero por codigo de barras empresa, luego codigo de barras proveedor, y pos ultimo codigo de empresa
        /// </summary>
        /// <param name="codigo">El codigo para buscar</param>
        /// <param name="sucursal_id">La sucursal</param>
        public static DataTable GetArticuloUnicoCR(string codigo, decimal? sucursal_id) 
        {
            
            using (SessionService sesion = new SessionService())
            {
                //creamos la lista de clausulas en el orden que queremos que se proceda a buscar
                List<string> listaClausulas = new List<string>();

                listaClausulas.Add(" upper(" + ArticulosService.CodigoBarrasEmpresa_NombreCol + ") =  upper('" + codigo + "')" );
                listaClausulas.Add("upper(" + ArticulosService.CodigoBarrasProveedor_NombreCol + ") =  upper('" + codigo + "')" );
                listaClausulas.Add("upper(" + ArticulosService.CodigoEmpresa_NombreCol+ ") =  upper('" + codigo + "')" );
                string[] arrayClausulas = listaClausulas.ToArray();
                DataTable dtArticulo = new DataTable();
                // Si el datatable está vacío, cambiar la consulta y repetir el proceso
                int i = 0; // Indice para recorrer el array de consultas
                while (dtArticulo.Rows.Count == 0 && i < arrayClausulas.Length)
                {
                    // Cambiar la consulta del comando
                    string where = ArticulosService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
                    if (arrayClausulas[i].Length > 0) where += " and " + arrayClausulas[i];
                    where += " and " + ArticulosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                    if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionArticuloIndependiente) == Definiciones.SiNo.Si)
                    {
                        if (!sucursal_id.HasValue)
                            sucursal_id = sesion.Usuario.SUCURSAL_ACTIVA_ID;

                        var sucursal = new SucursalesService(sucursal_id.Value, sesion);
                        where += " and (" + ArticulosService.RegionId_NombreCol + " is null or " + ArticulosService.RegionId_NombreCol + " = " + sucursal.RegionId.Value + ") ";
                    }

                    if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCClienteFiltrarArticuloCliente) == Definiciones.SiNo.Si)
                        dtArticulo = sesion.Db.ARTICULOS_INFO_COMPLETACollection.GetAsDataTable(where, string.Empty);
                    else
                        dtArticulo = sesion.Db.ARTICULOSCollection.GetAsDataTable(where, string.Empty);

                    // Incrementar el indice
                    i++;
                }
                // Retornar el datatable
                return dtArticulo;
            }
            
        }
        public static DataTable GetArticulos(string clausulas, string orden, bool soloActivos, decimal? sucursal_id, SessionService sesion)
        {
            string where = ArticulosService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
            if (clausulas.Length > 0) where += " and " + clausulas;
            if (soloActivos) where += " and " + ArticulosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionArticuloIndependiente) == Definiciones.SiNo.Si)
            {
                if (!sucursal_id.HasValue)
                    sucursal_id = sesion.Usuario.SUCURSAL_ACTIVA_ID;

                var sucursal = new SucursalesService(sucursal_id.Value, sesion);
                where += " and (" + ArticulosService.RegionId_NombreCol + " is null or " + ArticulosService.RegionId_NombreCol + " = " + sucursal.RegionId.Value + ") ";
            }

            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCClienteFiltrarArticuloCliente) == Definiciones.SiNo.Si)
                return sesion.Db.ARTICULOS_INFO_COMPLETACollection.GetAsDataTable(where, orden);
            else
                return sesion.Db.ARTICULOSCollection.GetAsDataTable(where, orden);
        }

        public static DataTable GetArticulosPorCodigo(string codigo, decimal? sucursal_id)
        {
            return GetArticulos(ArticulosService.CodigoEmpresa_NombreCol + " = '" + codigo + "' ", string.Empty, false, sucursal_id);
        }
        public static DataTable GetArticulosInfoCompleta(string clausulas, string orden, bool soloActivos, decimal? sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetArticulosInfoCompleta(clausulas, orden, soloActivos, sucursal_id, sesion);
            }
        }
        public static DataTable GetArticulosInfoCompleta_sinBusquedaFlexible(string clausulas, string orden, bool soloActivos, decimal? sucursal_id)
        {// aft, creamos el método para utilizar desde comboBoxCba
            using (SessionService sesion = new SessionService())
            {
                return GetArticulosInfoCompleta_sinBusquedaFlexible(clausulas, orden, soloActivos, sucursal_id, sesion);
            }
        }
        public static DataTable GetArticulosInfoCompleta(string clausulas, string orden, bool soloActivos, decimal? sucursal_id, SessionService sesion)
        {
            string where = ArticulosService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
            if (clausulas.Length > 0) where += " and " + clausulas;
            if (soloActivos) where += " and " + ArticulosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionArticuloIndependiente) == Definiciones.SiNo.Si)
            {
                if (!sucursal_id.HasValue)
                    sucursal_id = sesion.Usuario.SUCURSAL_ACTIVA_ID;

                var sucursal = new SucursalesService(sucursal_id.Value, sesion);
                where += " and (" + ArticulosService.RegionId_NombreCol + " is null or " + ArticulosService.RegionId_NombreCol + " = " + sucursal.RegionId.Value + ") ";
            }

            sesion.Db.IniciarBusquedaFlexible();
            DataTable articulos = sesion.Db.ARTICULOS_INFO_COMPLETACollection.GetAsDataTable(where, orden);
            sesion.Db.FinalizarBusquedaFlexible();

            return articulos;
        }

        public static DataTable GetArticulosInfoCompleta_sinBusquedaFlexible(string clausulas, string orden, bool soloActivos, decimal? sucursal_id, SessionService sesion)
        {// aft, creamos el método para utilizar desde comboBoxCba
            string where = ArticulosService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
            if (clausulas.Length > 0) where += " and " + clausulas;
            if (soloActivos) where += " and " + ArticulosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionArticuloIndependiente) == Definiciones.SiNo.Si)
            {
                if (!sucursal_id.HasValue)
                    sucursal_id = sesion.Usuario.SUCURSAL_ACTIVA_ID;

                var sucursal = new SucursalesService(sucursal_id.Value, sesion);
                where += " and (" + ArticulosService.RegionId_NombreCol + " is null or " + ArticulosService.RegionId_NombreCol + " = " + sucursal.RegionId.Value + ") ";
            }

            DataTable articulos = sesion.Db.ARTICULOS_INFO_COMPLETACollection.GetAsDataTable(where, orden);

            return articulos;
        }


        public static DataTable GetArticuloInfoCompletaPorCodigo(string vCodigo, decimal? sucursal_id)
        {
            return GetArticuloInfoCompletaPorCodigo(vCodigo, true, sucursal_id);
        }
        public static DataTable GetArticuloInfoCompletaPorCodigo(string vCodigo, bool solo_activos, decimal? sucursal_id)
        {
            decimal cantidadMinimaCaracteres = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.BusquedaCantidadMinimaCaracteres);
            if (vCodigo.Length < cantidadMinimaCaracteres)
                throw new Exception("La cantidad mínima de caracteres para buscar artículos es " + cantidadMinimaCaracteres);

            string clausulas = "upper(" + ArticulosService.CodigoEmpresa_NombreCol + ") like '%" + vCodigo.ToUpper() + "%' ";
            if (solo_activos)
                clausulas += " and " + ArticulosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            return GetArticulosInfoCompleta(clausulas, string.Empty, false, sucursal_id);
        }
        public static string GetDescripcionNvlPorCodigo(string codigo, decimal? sucursal_id)
        {
            decimal id = GetArticuloId(codigo, sucursal_id);
            return GetDescripcionNvl(id);
        }
        public static string GetDescripcionNvl(decimal id)
        {
            string descripcionNvl = GetDescripcionImpresion(id);
            if (string.IsNullOrEmpty(descripcionNvl))
                descripcionNvl = GetDescripcionInterna(id);

            return descripcionNvl;

        }
        public static string GetDescripcionImpresion(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOSCollection.GetByPrimaryKey(id).DESCRIPCION_IMPRESION;
            }
        }
        public static decimal GetImpuestoId(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetImpuestoId(id, sesion);
            }
        }
        public static decimal GetImpuestoId(decimal id, SessionService sesion)
        {
            return sesion.Db.ARTICULOSCollection.GetByPrimaryKey(id).IMPUESTO_ID;
        }

        public static string GetDescripcionInterna(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOSCollection.GetByPrimaryKey(id).DESCRIPCION_INTERNA;
            }
        }
        public static string GetUnidadBase(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOSCollection.GetByPrimaryKey(id).UNIDAD_MEDIDA_ID;
            }
        }
        public static string GetDescripcionProveedor(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOSCollection.GetByPrimaryKey(id).DESCRIPCION_PROVEEDOR;
            }
        }
        public static string GetArticuloUnidad(decimal id_articulo)
        {
            return GetArticuloRowPorID(id_articulo).UNIDAD_MEDIDA_ID;
        }
        public static string GetArticuloCodigoEmpresa(decimal id_articulo)
        {
            return GetArticuloRowPorID(id_articulo).CODIGO_EMPRESA;
        }
        public static decimal GetArticuloId(string codigo, decimal? sucursal_id)
        {
            DataTable dtArticulos = GetArticulosPorCodigo(codigo, sucursal_id);
            decimal articuloId = Definiciones.Error.Valor.EnteroPositivo;

            if (dtArticulos.Rows.Count > 0)
                articuloId = (decimal)dtArticulos.Rows[0][Id_NombreCol];
            return articuloId;
        }
        public static bool ActualizarCodigoDeBarrasEmpresaPorCodigo(string codigo, string codigo_barra_empresa, decimal? sucursal_id)
        {
            return ActualizarCodigoDeBarrasEmpresa(GetArticuloId(codigo, sucursal_id), codigo_barra_empresa);
        }
        public static bool ActualizarCodigoDeBarrasEmpresa(decimal id, string codigo_barra_empresa)
        {
            bool actualizado = false;
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(id);
                String valorAnterior = articulo.ToString();
                articulo.CODIGO_BARRAS_EMPRESA = codigo_barra_empresa;
                actualizado = sesion.Db.ARTICULOSCollection.Update(articulo);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, articulo.ID, valorAnterior, articulo.ToString(), sesion);
            }
            return actualizado;

        }

        #region Booleans
        public static bool NoReponer(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetRow(ArticulosService.Id_NombreCol + " = " + articulo_id);
                return articulo.NO_REPONER == Definiciones.SiNo.Si;
            }
        }
        #endregion Booleans

        #endregion Statics

        #region Accesors
        public static string Secuencia
        { get { return "ARTICULOS_SQC"; } }

        public static string Nombre_Tabla
        { get { return "ARTICULOS"; } }

        public static string Nombre_Vista
        { get { return "ARTICULOS_INFO_COMPLETA"; } }

        public static string ArticuloLineaId_NombreCol
        { get { return ARTICULOSCollection.ARTICULO_LINEA_IDColumnName; } }

        public static string ArticuloPadreId_NombreCol
        { get { return ARTICULOSCollection.ARTICULO_PADRE_IDColumnName; } }

        public static string CantidadPorCaja_NombreCol
        { get { return ARTICULOSCollection.CANTIDAD_POR_CAJAColumnName; } }

        public static string CentroCostoId_NombreCol
        { get { return ARTICULOSCollection.CENTRO_COSTO_IDColumnName; } }

        public static string CodigoBalanza_NombreCol
        { get { return ARTICULOSCollection.CODIGO_BALANZAColumnName; } }

        public static string CodigoBarrasEmpresa_NombreCol
        { get { return ARTICULOSCollection.CODIGO_BARRAS_EMPRESAColumnName; } }

        public static string CodigoBarrasProveedor_NombreCol
        { get { return ARTICULOSCollection.CODIGO_BARRAS_PROVEEDORColumnName; } }

        public static string CodigoCatalogoProveedor_NombreCol
        { get { return ARTICULOSCollection.CODIGO_CATALOGO_PROVEEDORColumnName; } }

        public static string CodigoColorId_NombreCol
        { get { return ARTICULOSCollection.CODIGO_COLOR_IDColumnName; } }

        public static string CodigoEmpaqueId_NombreCol
        { get { return ARTICULOSCollection.CODIGO_EMPAQUE_IDColumnName; } }

        public static string CodigoEmpresa_NombreCol
        { get { return ARTICULOSCollection.CODIGO_EMPRESAColumnName; } }

        public static string CodigoPresentacionId_NombreCol
        { get { return ARTICULOSCollection.CODIGO_PRESENTACION_IDColumnName; } }

        public static string CodigoProveedor_NombreCol
        { get { return ARTICULOSCollection.CODIGO_PROVEEDORColumnName; } }

        public static string CodigoTalleId_NombreCol
        { get { return ARTICULOSCollection.CODIGO_TALLE_IDColumnName; } }

        public static string ComboId_NombreCol
        { get { return ARTICULOSCollection.COMBO_IDColumnName; } }

        public static string ControlarPrecio_NombreCol
        { get { return ARTICULOSCollection.CONTROLAR_PRECIOColumnName; } }

        public static string DescripcionImpresion_NombreCol
        { get { return ARTICULOSCollection.DESCRIPCION_IMPRESIONColumnName; } }

        public static string DescripcionCatalogo_NombreCol
        { get { return ARTICULOSCollection.DESCRIPCION_CATALOGOColumnName; } }

        public static string DescripcionInterna_NombreCol
        { get { return ARTICULOSCollection.DESCRIPCION_INTERNAColumnName; } }

        public static string DescripcionProveedor_NombreCol
        { get { return ARTICULOSCollection.DESCRIPCION_PROVEEDORColumnName; } }

        public static string EntidadId_NombreCol
        { get { return ARTICULOSCollection.ENTIDAD_IDColumnName; } }

        public static string EsModificable_NombreCol
        { get { return ARTICULOSCollection.ES_MODIFICABLEColumnName; } }

        public static string EsDanhado_NombreCol
        { get { return ARTICULOSCollection.ES_DANHADOColumnName; } }

        public static string EsObsoleto_NombreCol
        { get { return ARTICULOSCollection.ES_OBSOLETOColumnName; } }

        public static string EsUsado_NombreCol
        { get { return ARTICULOSCollection.ES_USADOColumnName; } }

        public static string Estado_NombreCol
        { get { return ARTICULOSCollection.ESTADOColumnName; } }

        public static string EsTrazable_NombreCol
        { get { return ARTICULOSCollection.ES_TRAZABLEColumnName; } }

        public static string EsComboAbierto_NombreCol
        { get { return ARTICULOSCollection.ES_COMBO_ABIERTOColumnName; } }

        public static string FactorConversionKg_NombreCol
        { get { return ARTICULOSCollection.FACTOR_CONVERSION_KGColumnName; } }

        public static string FactorConversionM_NombreCol
        { get { return ARTICULOSCollection.FACTOR_CONVERSION_MColumnName; } }

        public static string FamiliaId_NombreCol
        { get { return ARTICULOSCollection.FAMILIA_IDColumnName; } }

        public static string FechaAprobacion_NombreCol
        { get { return ARTICULOSCollection.FECHA_APROBACIONColumnName; } }

        public static string Genero_NombreCol
        { get { return ARTICULOSCollection.GENEROColumnName; } }

        public static string GrupoId_NombreCol
        { get { return ARTICULOSCollection.GRUPO_IDColumnName; } }

        public static string Id_NombreCol
        { get { return ARTICULOSCollection.IDColumnName; } }

        public static string Importado_NombreCol
        { get { return ARTICULOSCollection.IMPORTADOColumnName; } }

        public static string ImpuestoId_NombreCol
        { get { return ARTICULOSCollection.IMPUESTO_IDColumnName; } }

        public static string ImpuestoCompraId_NombreCol
        { get { return ARTICULOSCollection.IMPUESTO_COMPRA_IDColumnName; } }

        public static string IngresoAprobado_NombreCol
        { get { return ARTICULOSCollection.INGRESO_APROBADOColumnName; } }

        public static string NoReponer_NombreCol
        { get { return ARTICULOSCollection.NO_REPONERColumnName; } }

        public static string ParaVenta_NombreCol
        { get { return ARTICULOSCollection.PARA_VENTAColumnName; } }

        public static string EsCombo_NombreCol
        { get { return ARTICULOSCollection.ES_COMBOColumnName; } }

        public static string Procedencia_NombreCol
        { get { return ARTICULOSCollection.PROCEDENCIAColumnName; } }

        public static string ProduccionInterna_NombreCol
        { get { return ARTICULOSCollection.PRODUCCION_INTERNAColumnName; } }

        public static string RecargoFinanciero_NombreCol
        { get { return ARTICULOSCollection.RECARGO_FINANCIEROColumnName; } }

        public static string RegionId_NombreCol
        { get { return ARTICULOSCollection.REGION_IDColumnName; } }

        public static string NotaCreditoId_NombreCol
        { get { return ARTICULOSCollection.NOTA_CREDITO_IDColumnName; } }

        public static string Servicio_NombreCol
        { get { return ARTICULOSCollection.SERVICIOColumnName; } }

        public static string SubgrupoId_NombreCol
        { get { return ARTICULOSCollection.SUBGRUPO_IDColumnName; } }

        public static string UnidadMedidaId_NombreCol
        { get { return ARTICULOSCollection.UNIDAD_MEDIDA_IDColumnName; } }

        public static string UsuarioAprobacionId_NombreCol
        { get { return ARTICULOSCollection.USUARIO_APROBACION_IDColumnName; } }

        public static string MarcaId_Nombrecol
        { get { return ARTICULOSCollection.ARTICULO_MARCA_IDColumnName; } }

        public static string CostoBaseMonedaId_Nombrecol
        { get { return ARTICULOSCollection.COSTO_BASE_MONEDA_IDColumnName; } }

        public static string CostoBaseMonto_Nombrecol
        { get { return ARTICULOSCollection.COSTO_BASE_MONTOColumnName; } }

        public static string Retencion_Nombrecol
        { get { return ARTICULOSCollection.RETENCIONColumnName; } }

        public static string Cantidad_Mayorista_Nombrecol
        { get { return ARTICULOSCollection.CANTIDAD_MAYORISTAColumnName; } }

        public static string Cantidad_Maxima_Nombrecol
        { get { return ARTICULOSCollection.CANTIDAD_MAXIMAColumnName; } }

        public static string Cantidad_Minima_Nombrecol
        { get { return ARTICULOSCollection.CANTIDAD_MINIMAColumnName; } }

        public static string EsFormula_Nombrecol
        { get { return ARTICULOSCollection.ES_FORMULAColumnName; } }

        public static string Unidad_Medida_Control_Nombrecol
        { get { return ARTICULOSCollection.UNIDAD_MEDIDA_CONTROLColumnName; } }
        //public static string CostoPpp_Nombrecol
        //{ get { return ARTICULOSCollection.COSTO_PPPColumnName; } }

        //public static string FechaCierre_Nombrecol
        //{ get { return ARTICULOSCollection.FECHA_CIERREColumnName; } }

        public static string CostoBaseCotizacionMoneda_Nombrecol
        { get { return ARTICULOSCollection.COSTO_BASE_COTIZACIONColumnName; } }

        public static string EsComboRepresentativo_Nombrecol
        { get { return ARTICULOSCollection.ES_COMBO_REPRESENTATIVOColumnName; } }

        public static string ImagenPathTmp_Nombrecol
        { get { return ARTICULOSCollection.IMAGEN_PATH_TMPColumnName; } }

        public static string ParaCompra_NombreCol
        { get { return ARTICULOSCollection.PARA_COMPRAColumnName; } }

        public static string EsFormula_NombreCol
        { get { return ARTICULOSCollection.ES_FORMULAColumnName; } }

        public static string CantidadMinimaProduccion_NombreCol
        { get { return ARTICULOSCollection.CANTIDAD_MINIMA_PRODUCCIONColumnName; } }

        public static string CantidadMaximaProduccion_NombreCol
        { get { return ARTICULOSCollection.CANTIDAD_MAXIMA_PRODUCCIONColumnName; } }

        public static string TipoFormula_NombreCol
        { get { return ARTICULOSCollection.TIPO_FORMULAColumnName; } }

        public static string PorcentajePrecioPadre_NombreCol
        { get { return ARTICULOSCollection.PORCENTAJE_PRECIO_PADREColumnName; } }

        public static string MontoPrecioPadre_NombreCol
        { get { return ARTICULOSCollection.MONTO_PRECIO_PADREColumnName; } }

        public static string VistaArticuloLineaNombre_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.ARTICULO_LINEA_NOMBREColumnName; } }

        public static string VistaArticuloPadreNombre_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.ARTICULO_PADRE_NOMBREColumnName; } }

        public static string VistaArticuloPadreCodigo_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.ARTICULO_PADRE_CODIGOColumnName; } }

        public static string VistaColorDescripcion_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.COLOR_DESCRIPCIONColumnName; } }

        public static string VistaEmpaqueDescripcion_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.EMPAQUE_DESCRIPCIONColumnName; } }

        public static string VistaFamiliaDescripcion_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.FAMILIA_DESCRIPCIONColumnName; } }

        public static string VistaGrupoDescripcion_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.GRUPO_DESCRIPCIONColumnName; } }

        public static string VistaImpuestoDescripcion_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.IMPUESTO_DESCRIPCIONColumnName; } }

        public static string VistaImpuestoCompraDescripcion_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.IMPUESTO_COMPRA_DESCRIPCIONColumnName; } }

        public static string VistaPresentacionDescripcion_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.PRESENTACION_DESCRIPCIONColumnName; } }

        public static string VistaProcedenciaGentilicio_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.PROCEDENCIA_GENTILICIOColumnName; } }

        public static string VistaSubgrupoDescripcion_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.SUBGRUPO_DESCRIPCIONColumnName; } }

        public static string VistaTalleDescripcion_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.TALLE_DESCRIPCIONColumnName; } }

        public static string VistaUnidadMedidaDescripcion_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.UNIDAD_MEDIDA_DESCRIPCIONColumnName; } }

        public static string VistaDescripcionAUtilizar_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.DESCRIPCION_A_UTILIZARColumnName; } }

        public static string VistaDescripcionSinCodigo_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.DESCRIPCION_SIN_CODIGOColumnName; } }

        public static string VistaUltimoIngresoStockFecha_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.ULTIMO_INGRESO_STOCK_FECHAColumnName; } }

        public static string VistaExistenciaTotal_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.EXISTENCIA_TOTALColumnName; } }

        public static string VistaMarcaDescripcion_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.ARTICULO_MARCA_NOMBREColumnName; } }

        public static string VistaPersonaId_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.PERSONA_IDColumnName; } }

        public static string VistaFamiliaCodigo_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.FAMILIA_CODIGOColumnName; } }

        public static string VistaGrupoCodigo_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.GRUPO_CODIGOColumnName; } }

        public static string VistaSubGrupoCodigo_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.SUBGRUPO_CODIGOColumnName; } }

        public static string ActivoId_NombreCol
        { get { return ARTICULOSCollection.ACTIVO_IDColumnName; } }

        public static string AutonumeracionId_NombreCol
        { get { return ARTICULOSCollection.AUTONUMERACIONES_IDColumnName; } }

        public static string VistaProveedorRazonSocial_NombreCol
        { get { return ARTICULOS_INFO_COMPLETACollection.PROVEEDOR_RAZON_SOCIALColumnName; } }


        #endregion Accesors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static ArticulosService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new ArticulosService(e.RegistroId, sesion);
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
        protected ARTICULOSRow row;
        protected ARTICULOSRow rowSinModificar;
        public class Modelo : ARTICULOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
       

        public decimal? ArticuloLineaId { get { if (row.IsARTICULO_LINEA_IDNull) return null; else return row.ARTICULO_LINEA_ID; } set { if (value.HasValue) row.ARTICULO_LINEA_ID = value.Value; else row.IsARTICULO_LINEA_IDNull = true; } }
        public decimal? ArticuloMarcaId { get { if (row.IsARTICULO_MARCA_IDNull) return null; else return row.ARTICULO_MARCA_ID; } set { if (value.HasValue) row.ARTICULO_MARCA_ID = value.Value; else row.IsARTICULO_MARCA_IDNull = true; } }
        public decimal? ArticuloPadreId { get { if (row.IsARTICULO_PADRE_IDNull) return null; else return row.ARTICULO_PADRE_ID; } set { if (value.HasValue) row.ARTICULO_PADRE_ID = value.Value; else row.IsARTICULO_PADRE_IDNull = true; } }
        public decimal CantidadPorCaja { get { return row.CANTIDAD_POR_CAJA; } private set { row.CANTIDAD_POR_CAJA = value; } }
        public decimal? CentroCostoId { get { if (row.IsCENTRO_COSTO_IDNull) return null; else return row.CENTRO_COSTO_ID; } set { if (value.HasValue) row.CENTRO_COSTO_ID = value.Value; else row.IsCENTRO_COSTO_IDNull = true; } }
        public string CodigoBarrasEmpresa { get { return ClaseCBABase.GetStringHelper(row.CODIGO_BARRAS_EMPRESA); } set { row.CODIGO_BARRAS_EMPRESA = value; } }
        public string CodigoBarrasProveedor { get { return ClaseCBABase.GetStringHelper(row.CODIGO_BARRAS_PROVEEDOR); } set { row.CODIGO_BARRAS_PROVEEDOR = value; } }
        public string CodigoCatalogoProveedor { get { return ClaseCBABase.GetStringHelper(row.CODIGO_CATALOGO_PROVEEDOR); } set { row.CODIGO_CATALOGO_PROVEEDOR = value; } }
        public decimal? CodigoColorId { get { if (row.IsCODIGO_COLOR_IDNull) return null; else return row.CODIGO_COLOR_ID; } set { if (value.HasValue) row.CODIGO_COLOR_ID = value.Value; else row.IsCODIGO_COLOR_IDNull = true; } }
        public decimal? CodigoEmpaqueId { get { if (row.IsCODIGO_EMPAQUE_IDNull) return null; else return row.CODIGO_EMPAQUE_ID; } set { if (value.HasValue) row.CODIGO_EMPAQUE_ID = value.Value; else row.IsCODIGO_EMPAQUE_IDNull = true; } }
        public string CodigoEmpresa { get { return row.CODIGO_EMPRESA; } set { row.CODIGO_EMPRESA = value; } }
        public decimal? CodigoPresentacionId { get { if (row.IsCODIGO_PRESENTACION_IDNull) return null; else return row.CODIGO_PRESENTACION_ID; } set { if (value.HasValue) row.CODIGO_PRESENTACION_ID = value.Value; else row.IsCODIGO_PRESENTACION_IDNull = true; } }
        public string CodigoProveedor { get { return ClaseCBABase.GetStringHelper(row.CODIGO_PROVEEDOR); } set { row.CODIGO_PROVEEDOR = value; } }
        public decimal? CodigoTalleId { get { if (row.IsCODIGO_TALLE_IDNull) return null; else return row.CODIGO_TALLE_ID; } set { if (value.HasValue) row.CODIGO_TALLE_ID = value.Value; else row.IsCODIGO_TALLE_IDNull = true; } }
        public decimal? ComboId { get { if (row.IsCOMBO_IDNull) return null; else return row.COMBO_ID; } set { if (value.HasValue) row.COMBO_ID = value.Value; else row.IsCOMBO_IDNull = true; } }
        public string ControlarPrecio { get { return row.CONTROLAR_PRECIO; } set { row.CONTROLAR_PRECIO = value; } }
        public decimal? CostoBaseCotizacion { get { if (row.IsCOSTO_BASE_COTIZACIONNull) return null; else return row.COSTO_BASE_COTIZACION; } set { if (value.HasValue) row.COSTO_BASE_COTIZACION = value.Value; else row.IsCOSTO_BASE_COTIZACIONNull = true; } }
        public decimal? CostoBaseMonedaId { get { if (row.IsCOSTO_BASE_MONEDA_IDNull) return null; else return row.COSTO_BASE_MONEDA_ID; } set { if (value.HasValue) row.COMBO_ID = value.Value; else row.IsCOSTO_BASE_MONEDA_IDNull = true; } }
        public decimal? CostoBaseMonto { get { if (row.IsCOSTO_BASE_MONTONull) return null; else return row.COSTO_BASE_MONTO; } set { if (value.HasValue) row.COMBO_ID = value.Value; else row.IsCOSTO_BASE_MONTONull = true; } }
        public string DescripcionCatalogo { get { return ClaseCBABase.GetStringHelper(row.DESCRIPCION_CATALOGO); } set { row.DESCRIPCION_CATALOGO = value; } }
        public string DescripcionImpresion { get { return ClaseCBABase.GetStringHelper(row.DESCRIPCION_IMPRESION); } set { row.DESCRIPCION_IMPRESION = value; } }
        public string DescripcionInterna { get { return ClaseCBABase.GetStringHelper(row.DESCRIPCION_INTERNA); } set { row.DESCRIPCION_INTERNA = value; } }
        public string DescripcionProveedor { get { return ClaseCBABase.GetStringHelper(row.DESCRIPCION_PROVEEDOR); } set { row.DESCRIPCION_PROVEEDOR = value; } }
        public decimal EntidadId { get { return row.ENTIDAD_ID; } private set { row.ENTIDAD_ID = value; } }
        public string esCombo { get { return row.ES_COMBO; } set { row.ES_COMBO = value; } }
        public string esComboAbierto { get { return row.ES_COMBO_ABIERTO; } set { row.ES_COMBO_ABIERTO = value; } }
        public string esComboRepresentativo { get { return row.ES_COMBO_REPRESENTATIVO; } set { row.ES_COMBO_REPRESENTATIVO = value; } }
        public string EsDanhado { get { return row.ES_DANHADO; } set { row.ES_DANHADO = value; } }
        public string EsModificable { get { return row.ES_MODIFICABLE; } set { row.ES_MODIFICABLE = value; } }
        public string EsObsoleto { get { return row.ES_OBSOLETO; } set { row.ES_OBSOLETO = value; } }
        public string esTrazable { get { return row.ES_TRAZABLE; } set { row.ES_TRAZABLE = value; } }
        public string EsUsado { get { return row.ES_USADO; } set { row.ES_USADO = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? FactorConversionKg { get { if (row.IsFACTOR_CONVERSION_KGNull) return null; else return row.FACTOR_CONVERSION_KG; } set { if (value.HasValue) row.FACTOR_CONVERSION_KG = value.Value; else row.IsFACTOR_CONVERSION_KGNull = true; } }
        public decimal? FactorConversionM { get { if (row.IsFACTOR_CONVERSION_MNull) return null; else return row.FACTOR_CONVERSION_M; } set { if (value.HasValue) row.FACTOR_CONVERSION_M = value.Value; else row.IsFACTOR_CONVERSION_MNull = true; } }
        public decimal? FamiliaId { get { if (row.IsFAMILIA_IDNull) return null; else return row.FAMILIA_ID; } set { if (value.HasValue) row.FAMILIA_ID = value.Value; else row.IsFAMILIA_IDNull = true; } }
        public DateTime FechaAprobacion { get { return row.FECHA_APROBACION; } set { row.FECHA_APROBACION = value; } }
        public string Genero { get { return ClaseCBABase.GetStringHelper(row.GENERO); } set { row.GENERO = value; } }
        public decimal? GrupoId { get { if (row.IsGRUPO_IDNull) return null; else return row.GRUPO_ID; } set { if (value.HasValue) row.GRUPO_ID = value.Value; else row.IsGRUPO_IDNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Importado { get { return row.IMPORTADO; } set { row.IMPORTADO = value; } }
        public decimal? ImpuestoCompraId { get { if (row.IsIMPUESTO_COMPRA_IDNull) return null; else return row.IMPUESTO_COMPRA_ID; } set { if (value.HasValue) row.IMPUESTO_COMPRA_ID = value.Value; else row.IsIMPUESTO_COMPRA_IDNull = true; } }
        public decimal ImpuestoId { get { return row.IMPUESTO_ID; } private set { row.IMPUESTO_ID = value; } }
        public string ingresoAprobado { get { return row.INGRESO_APROBADO; } set { row.INGRESO_APROBADO = value; } }
        public string noReponer { get { return row.NO_REPONER; } set { row.NO_REPONER = value; } }
        public decimal? NotaCreditoId { get { if (row.IsNOTA_CREDITO_IDNull) return null; else return row.NOTA_CREDITO_ID; } set { if (value.HasValue) row.NOTA_CREDITO_ID = value.Value; else row.IsNOTA_CREDITO_IDNull = true; } }
        public string ParaVenta { get { return row.PARA_VENTA; } set { row.PARA_VENTA = value; } }
        public decimal? ProcedenciaId { get { if (row.IsPROCEDENCIANull) return null; else return row.PROCEDENCIA; } set { if (value.HasValue) row.PROCEDENCIA = value.Value; else row.IsPROCEDENCIANull = true; } }
        public string ProduccionInterna { get { return row.PRODUCCION_INTERNA; } set { row.PRODUCCION_INTERNA = value; } }
        public string RecargoFinanciero { get { return row.RECARGO_FINANCIERO; } set { row.RECARGO_FINANCIERO = value; } }
        public decimal? RegionId { get { if (row.IsREGION_IDNull) return null; else return row.REGION_ID; } set { if (value.HasValue) row.REGION_ID = value.Value; else row.IsREGION_IDNull = true; } }
        public string Servicio { get { return row.SERVICIO; } set { row.SERVICIO = value; } }
        public decimal? SubGrupoId { get { if (row.IsSUBGRUPO_IDNull) return null; else return row.SUBGRUPO_ID; } set { if (value.HasValue) row.SUBGRUPO_ID = value.Value; else row.IsSUBGRUPO_IDNull = true; } }
        public string UnidadMedidaId { get { return row.UNIDAD_MEDIDA_ID; } private set { row.UNIDAD_MEDIDA_ID = value; } }
        public decimal? UsuarioAprobacionId { get { if (row.IsUSUARIO_APROBACION_IDNull) return null; else return row.USUARIO_APROBACION_ID; } set { if (value.HasValue) row.USUARIO_APROBACION_ID = value.Value; else row.IsUSUARIO_APROBACION_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private ArticulosLotesService[] _articulos_lotes;
        public ArticulosLotesService[] ArticulosLotes
        {
            get
            {
                if (this._articulos_lotes == null)
                {
                    this._articulos_lotes = ArticulosLotesService.Instancia.GetFiltrado<ArticulosLotesService>(new ClaseCBABase.Filtro[]
                    {
                        new ClaseCBABase.Filtro() { Columna = ArticulosLotesService.Modelo.ARTICULO_IDColumnName, Valor = this.Id.Value }
                    });
                }
                return this._articulos_lotes;
            }
        }

        private ArticulosFamiliasService _familia;
        public ArticulosFamiliasService Familia
        {
            get
            {
                if (this._familia == null)
                    this._familia = new ArticulosFamiliasService(this.FamiliaId.Value);
                return this._familia;
            }
        }

        private ArticulosGruposService _grupo;
        public ArticulosGruposService Grupo
        {
            get
            {
                if (this._grupo == null)
                    this._grupo = new ArticulosGruposService(this.GrupoId.Value);
                return this._grupo;
            }
        }

        private ArticulosSubgruposService _subgrupo;
        public ArticulosSubgruposService SubGrupo
        {
            get
            {
                if (this._subgrupo == null)
                    this._subgrupo = new ArticulosSubgruposService(this.SubGrupoId.Value);
                return this._subgrupo;
            }
        }

        public string Imagen
        {
            get
            {
                AdjuntosService adjunto = ClaseCBA<AdjuntosService>.Instancia.GetPrimero<AdjuntosService>(new ClaseCBABase.Filtro[] 
                { 
                    new ClaseCBABase.Filtro { Columna = AdjuntosService.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla},
                    new ClaseCBABase.Filtro { Columna = AdjuntosService.Modelo.REGISTROColumnName, Valor = this.Id.Value},
                });

                if (adjunto != null)
                    return adjunto.Path;
                else
                    return string.Empty;
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

        private ImpuestosService _impuesto_compra;
        public ImpuestosService ImpuestoCompra
        {
            get
            {
                if (this._impuesto_compra == null)
                    this._impuesto_compra = new ImpuestosService(this.ImpuestoCompraId.Value);
                return this._impuesto_compra;
            }
        }

        private UnidadesService _unidad_medida;
        public UnidadesService UnidadMedida
        {
            get
            {
                if (this._unidad_medida == null)
                    this._unidad_medida = new UnidadesService(this.UnidadMedidaId);
                return this._unidad_medida;
            }
        }

        private RegionesService _region;
        public RegionesService Region
        {
            get
            {
                if (this._region == null)
                    this._region = new RegionesService(this.RegionId.Value);
                return this._region;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.ARTICULOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ARTICULOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(ARTICULOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public ArticulosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public ArticulosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public ArticulosService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        private ArticulosService(ARTICULOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Buscar
        public static ArticulosService[] Buscar(string clausulas, decimal? sucursal_id, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return Buscar(clausulas, sucursal_id, orden, sesion);
            }
        }
        public static ArticulosService[] Buscar(string clausulas, decimal? sucursal_id, string orden, SessionService sesion)
        {

            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionArticuloIndependiente) == Definiciones.SiNo.Si)
            {
                if (!sucursal_id.HasValue)
                    sucursal_id = sesion.Usuario.SUCURSAL_ACTIVA_ID;

                var sucursal = new SucursalesService(sucursal_id.Value, sesion);
                if (clausulas.Length > 0)
                    clausulas += " and ";
                clausulas += " (" + ArticulosService.RegionId_NombreCol + " is null or " + ArticulosService.RegionId_NombreCol + " = " + sucursal.RegionId.Value + ") ";
            }

            ARTICULOSRow[] rows = sesion.db.ARTICULOSCollection.GetAsArray(clausulas, orden);
            ArticulosService[] articulos = new ArticulosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                articulos[i] = new ArticulosService(rows[i]);
            return articulos;
        }
        #endregion Buscar

        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
