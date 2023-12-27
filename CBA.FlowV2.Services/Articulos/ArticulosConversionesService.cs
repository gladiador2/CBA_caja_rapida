using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Stock;


namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosConversionesService
    {
        #region GetFactorConversion
        /// <summary>
        /// Gets the factor conversion.
        /// </summary>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <param name="unidadDestino">The unidad destino.</param>
        /// <returns></returns>
        public decimal GetFactorConversion(decimal articulo_id, string unidadDestino, decimal? sucursal_id)
        {
            DataTable dtArticulos = new DataTable();
            DataTable dtConversiones = new DataTable();
            decimal factorConversion = 0;
            ARTICULOS_CONVERSIONRow conversionesRows = new ARTICULOS_CONVERSIONRow();
            string unidadPrincipal = string.Empty;
            using (SessionService sesion = new SessionService()) 
            {
                dtArticulos = ArticulosService.GetArticulos(ArticulosService.Id_NombreCol + " = " + articulo_id, string.Empty, false, sucursal_id);
                if (dtArticulos.Rows.Count == 1)
                {
                    unidadPrincipal = dtArticulos.Rows[0][ArticulosService.UnidadMedidaId_NombreCol].ToString();
                    if (unidadDestino.Equals(unidadPrincipal)) 
                    {
                        return 1;
                    }
                    if (!unidadPrincipal.Equals(string.Empty))
                    {
                        string clausula = ArticulosConversionesService.ArticuloId_NombreCol + "=" + articulo_id + " and " +
                                            ArticulosConversionesService.UnidadPrincipalId_NombreCol + " = '" + unidadPrincipal + "' and " +
                                            ArticulosConversionesService.UnidadDestinoId_NombreCol + "= '" + unidadDestino+"'";

                        dtConversiones = sesion.Db.ARTICULOS_CONVERSIONCollection.GetAsDataTable(clausula, string.Empty);
                        if (dtConversiones.Rows.Count == 1)
                        {
                            factorConversion = decimal.Parse(dtConversiones.Rows[0][ArticulosConversionesService.FactorConversion_NombreCol].ToString());
                        }
                        else 
                        {
                            throw new System.ArgumentException("Error al obtener el factor de conversión del articulo.");
                        }
                    }
                    else 
                    {
                        throw new System.ArgumentException("Error al obtener la unidad de medida principal del articulo.");
                    }
                }
                else 
                {
                    throw new System.ArgumentException("Error al obtener la unidad de medida principal del articulo.");
                }
                
               

                
            }

            return factorConversion;
        }
        public static decimal GetFactorConversion(decimal articulo_id, string unidadDestino, decimal? sucursal_id, SessionService sesion)
        {
            DataTable dtArticulos = new DataTable();
            DataTable dtConversiones = new DataTable();
            decimal factorConversion = 0;
            ARTICULOS_CONVERSIONRow conversionesRows = new ARTICULOS_CONVERSIONRow();
            string unidadPrincipal = string.Empty;

            dtArticulos = ArticulosService.GetArticulosDataTable(ArticulosService.Id_NombreCol + " = " + articulo_id, string.Empty, false, sucursal_id, sesion);
            if (dtArticulos.Rows.Count == 1)
            {
                unidadPrincipal = dtArticulos.Rows[0][ArticulosService.UnidadMedidaId_NombreCol].ToString();
                if (unidadDestino.Equals(unidadPrincipal))
                {
                    return 1;
                }
                if (!unidadPrincipal.Equals(string.Empty))
                {
                    string clausula = ArticulosConversionesService.ArticuloId_NombreCol + "=" + articulo_id + " and " +
                                        ArticulosConversionesService.UnidadPrincipalId_NombreCol + " = '" + unidadPrincipal + "' and " +
                                        ArticulosConversionesService.UnidadDestinoId_NombreCol + "= '" + unidadDestino + "'";

                    dtConversiones = sesion.Db.ARTICULOS_CONVERSIONCollection.GetAsDataTable(clausula, string.Empty);
                    if (dtConversiones.Rows.Count == 1)
                    {
                        factorConversion = decimal.Parse(dtConversiones.Rows[0][ArticulosConversionesService.FactorConversion_NombreCol].ToString());
                    }
                    else
                    {
                        throw new System.ArgumentException("Error al obtener el factor de conversión del articulo.");
                    }
                }
                else
                {
                    throw new System.ArgumentException("Error al obtener la unidad de medida principal del articulo.");
                }
            }
            else
            {
                throw new System.ArgumentException("Error al obtener la unidad de medida principal del articulo.");
            }

            return factorConversion;
        }
        #endregion GetFactorConversion

        #region GetUnidadesDeMedidaPorArticulo
        /// <summary>
        /// Gets the unidades de medida por articulo.
        /// </summary>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <returns></returns>
        /// 
        public static DataTable GetUnidadesDeMedidaPorArticulo(decimal articulo_id, decimal? sucursal_id, SessionService sesion)
        {
            DataTable dtUnidades = new DataTable();
            DataTable dtArticulos = new DataTable();
            DataTable dtConversiones = new DataTable();
            ARTICULOS_CONVERSIONRow conversionesRows = new ARTICULOS_CONVERSIONRow();
            string unidadPrincipal = string.Empty;

            string query = "select a.*, um." + UnidadesService.Descripcion_NombreCol + " " + ArticulosService.VistaUnidadMedidaDescripcion_NombreCol +
               " from " + ArticulosService.Nombre_Tabla + " a, " + UnidadesService.Nombre_Tabla + " um where a." +
               ArticulosService.UnidadMedidaId_NombreCol + " = um." + UnidadesService.Id_NombreCol + " and a." + ArticulosService.Id_NombreCol + " = " + articulo_id;

            dtArticulos = sesion.db.EjecutarQuery(query);
            if (dtArticulos.Rows.Count == 1)
            {
                unidadPrincipal = dtArticulos.Rows[0][ArticulosService.UnidadMedidaId_NombreCol].ToString();
                if (!unidadPrincipal.Equals(string.Empty))
                {
                    string clausula = ArticulosConversionesService.ArticuloId_NombreCol + "=" + articulo_id + " and " +
                                        ArticulosConversionesService.UnidadPrincipalId_NombreCol + " = '" + unidadPrincipal + "'";

                    dtConversiones = sesion.Db.ART_CONVERSION_INFO_COMPLCollection.GetAsDataTable(clausula, string.Empty);
                    dtUnidades.Columns.Add(UnidadesService.Id_NombreCol, typeof(string));
                    dtUnidades.Columns.Add(UnidadesService.Descripcion_NombreCol, typeof(string));

                    dtUnidades.Rows.Add(unidadPrincipal, dtArticulos.Rows[0][ArticulosService.VistaUnidadMedidaDescripcion_NombreCol]);
                    if (dtConversiones.Rows.Count > 0)
                    {
                        foreach (DataRow c in dtConversiones.Rows)
                        {
                            dtUnidades.Rows.Add(c[ArticulosConversionesService.UnidadDestinoId_NombreCol].ToString(), c[ArticulosConversionesService.VistaUnidadDestinoNombre_NombreCol].ToString() + " (" + c[ArticulosConversionesService.FactorConversion_NombreCol].ToString() + ")");
                        }
                    }

                }
                else
                {
                    throw new System.ArgumentException("Error al obtener la unidad de medida principal del articulo.");
                }
            }
            else
            {
                throw new System.ArgumentException("Error al obtener la unidad de medida principal del articulo.");
            }
            return dtUnidades;
        }
        public static DataTable GetUnidadesDeMedidaPorArticulo(decimal articulo_id, decimal? sucursal_id) 
        {
            using (SessionService sesion = new SessionService())
            {
                return GetUnidadesDeMedidaPorArticulo(articulo_id, sucursal_id, sesion);
            }
        }
        #endregion GetUnidadesDeMedidaPorArticulo

        #region GetFactoresConversionPorArticulo
        /// <summary>
        /// Gets the factores conversion por articulo.
        /// </summary>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <param name="unidad_id">The unidad_id.</param>
        /// <returns></returns>
        public DataTable GetFactoresConversionPorArticulo(decimal articulo_id, string unidad_id) 
        {
            DataTable dt = new DataTable();
            using (SessionService sesion = new SessionService()) 
            {
                string clausula = ArticulosConversionesService.ArticuloId_NombreCol + " = " + articulo_id + " and " +
                                    ArticulosConversionesService.UnidadPrincipalId_NombreCol + " = '" + unidad_id +"'";
                dt = sesion.Db.ART_CONVERSION_INFO_COMPLCollection.GetAsDataTable(clausula, string.Empty);
            }
            return dt;
        }
        #endregion GetFactoresConversionPorArticulo

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="esNuevo">if set to <c>true</c> [es nuevo].</param>
        public void Guardar(System.Collections.Hashtable campos, bool esNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOS_CONVERSIONRow row = new ARTICULOS_CONVERSIONRow();
                sesion.Db.BeginTransaction();
                string valorAnterior = string.Empty;
                if (esNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("articulos_conversiones_sqc");
                    row.ARTICULO_ID = decimal.Parse(campos[ArticulosConversionesService.ArticuloId_NombreCol].ToString());
                    row.UNIDAD_PRINCIPAL_ID = campos[ArticulosConversionesService.UnidadPrincipalId_NombreCol].ToString();
                    row.UNIDAD_DESTINO_ID = campos[ArticulosConversionesService.UnidadDestinoId_NombreCol].ToString();
                }
                else 
                {
                    decimal id = decimal.Parse(campos[ArticulosConversionesService.ArticuloId_NombreCol].ToString());
                    row = sesion.Db.ARTICULOS_CONVERSIONCollection.GetByPrimaryKey(id);
                    valorAnterior = row.ToString();
                }

                row.FACTOR_CONVERSION = decimal.Parse(campos[ArticulosConversionesService.FactorConversion_NombreCol].ToString());
                if (esNuevo) sesion.Db.ARTICULOS_CONVERSIONCollection.Insert(row);
                else sesion.Db.ARTICULOS_CONVERSIONCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                
                sesion.Db.CommitTransaction();
            }
        }
        #endregion Guardar

        #region Borrar
        public void Borrar(decimal conversion_id) 
        {
            ARTICULOS_CONVERSIONRow row = new ARTICULOS_CONVERSIONRow();
            string valorAnterior = string.Empty;
            using (SessionService sesion = new SessionService()) 
            {
                sesion.Db.BeginTransaction();
                row = sesion.Db.ARTICULOS_CONVERSIONCollection.GetByPrimaryKey(conversion_id);
                valorAnterior = row.ToString();
                sesion.Db.ARTICULOS_CONVERSIONCollection.Delete(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
                sesion.Db.CommitTransaction();

            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_CONVERSION"; }
        }

        #region Tablas
        public static string Id_NombreCol
        {
            get { return ARTICULOS_CONVERSIONCollection.IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return ARTICULOS_CONVERSIONCollection.ARTICULO_IDColumnName; }
        }
        public static string UnidadPrincipalId_NombreCol
        {
            get { return ARTICULOS_CONVERSIONCollection.UNIDAD_PRINCIPAL_IDColumnName; }
        }
        public static string UnidadDestinoId_NombreCol
        {
            get { return ARTICULOS_CONVERSIONCollection.UNIDAD_DESTINO_IDColumnName; }
        }
        public static string FactorConversion_NombreCol
        {
            get { return ARTICULOS_CONVERSIONCollection.FACTOR_CONVERSIONColumnName; }
        }
        #endregion Tablas

        #region Vistas
        public static string VistaArticuloDescripcion_NombreCol
        {
            get { return ART_CONVERSION_INFO_COMPLCollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloEntidadId_NombreCol
        {
            get { return ART_CONVERSION_INFO_COMPLCollection.ARTICULO_ENTIDAD_IDColumnName; }
        }
        public static string VistaUnidadDestinoNombre_NombreCol
        {
            get { return ART_CONVERSION_INFO_COMPLCollection.UNIDAD_DESTINO_NOMBREColumnName; }
        }
        public static string VistaUnidadPrincipalNombre_NombreCol
        {
            get { return ART_CONVERSION_INFO_COMPLCollection.UNIDAD_PRINCIPAL_NOMBREColumnName; }
        }
        #endregion Vistas




        #endregion Accessors
    }
}
