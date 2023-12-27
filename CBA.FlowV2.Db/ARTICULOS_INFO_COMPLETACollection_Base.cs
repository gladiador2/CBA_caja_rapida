// <fileinfo name="ARTICULOS_INFO_COMPLETACollection_Base.cs">
//		<copyright>
//			All rights reserved.
//		</copyright>
//		<remarks>
//			Do not change this source code manually. Changes to this file may 
//			cause incorrect behavior and will be lost if the code is regenerated.
//		</remarks>
//		<generator rewritefile="True" infourl="http://www.SharpPower.com">RapTier</generator>
// </fileinfo>

using System;
using System.Data;

namespace CBA.FlowV2.Db
{
	/// <summary>
	/// The base class for <see cref="ARTICULOS_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ARTICULOS_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string REGION_IDColumnName = "REGION_ID";
		public const string CODIGO_EMPRESAColumnName = "CODIGO_EMPRESA";
		public const string CODIGO_PROVEEDORColumnName = "CODIGO_PROVEEDOR";
		public const string FAMILIA_IDColumnName = "FAMILIA_ID";
		public const string GRUPO_IDColumnName = "GRUPO_ID";
		public const string SUBGRUPO_IDColumnName = "SUBGRUPO_ID";
		public const string CODIGO_BARRAS_EMPRESAColumnName = "CODIGO_BARRAS_EMPRESA";
		public const string CODIGO_BARRAS_PROVEEDORColumnName = "CODIGO_BARRAS_PROVEEDOR";
		public const string DESCRIPCION_INTERNAColumnName = "DESCRIPCION_INTERNA";
		public const string DESCRIPCION_IMPRESIONColumnName = "DESCRIPCION_IMPRESION";
		public const string DESCRIPCION_CATALOGOColumnName = "DESCRIPCION_CATALOGO";
		public const string DESCRIPCION_PROVEEDORColumnName = "DESCRIPCION_PROVEEDOR";
		public const string DESCRIPCION_A_UTILIZARColumnName = "DESCRIPCION_A_UTILIZAR";
		public const string DESCRIPCION_SIN_CODIGOColumnName = "DESCRIPCION_SIN_CODIGO";
		public const string CODIGO_PRESENTACION_IDColumnName = "CODIGO_PRESENTACION_ID";
		public const string CODIGO_EMPAQUE_IDColumnName = "CODIGO_EMPAQUE_ID";
		public const string CODIGO_COLOR_IDColumnName = "CODIGO_COLOR_ID";
		public const string CODIGO_TALLE_IDColumnName = "CODIGO_TALLE_ID";
		public const string CODIGO_BALANZAColumnName = "CODIGO_BALANZA";
		public const string CODIGO_CATALOGO_PROVEEDORColumnName = "CODIGO_CATALOGO_PROVEEDOR";
		public const string PROVEEDOR_RAZON_SOCIALColumnName = "PROVEEDOR_RAZON_SOCIAL";
		public const string IMPORTADOColumnName = "IMPORTADO";
		public const string PRODUCCION_INTERNAColumnName = "PRODUCCION_INTERNA";
		public const string NO_REPONERColumnName = "NO_REPONER";
		public const string UNIDAD_MEDIDA_IDColumnName = "UNIDAD_MEDIDA_ID";
		public const string FACTOR_CONVERSION_KGColumnName = "FACTOR_CONVERSION_KG";
		public const string FACTOR_CONVERSION_MColumnName = "FACTOR_CONVERSION_M";
		public const string CANTIDAD_POR_CAJAColumnName = "CANTIDAD_POR_CAJA";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string IMPUESTO_COMPRA_IDColumnName = "IMPUESTO_COMPRA_ID";
		public const string SERVICIOColumnName = "SERVICIO";
		public const string COMBO_IDColumnName = "COMBO_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string INGRESO_APROBADOColumnName = "INGRESO_APROBADO";
		public const string USUARIO_APROBACION_IDColumnName = "USUARIO_APROBACION_ID";
		public const string FECHA_APROBACIONColumnName = "FECHA_APROBACION";
		public const string PORCENTAJE_PRECIO_PADREColumnName = "PORCENTAJE_PRECIO_PADRE";
		public const string MONTO_PRECIO_PADREColumnName = "MONTO_PRECIO_PADRE";
		public const string IMPUESTO_DESCRIPCIONColumnName = "IMPUESTO_DESCRIPCION";
		public const string IMPUESTO_COMPRA_DESCRIPCIONColumnName = "IMPUESTO_COMPRA_DESCRIPCION";
		public const string FAMILIA_DESCRIPCIONColumnName = "FAMILIA_DESCRIPCION";
		public const string GRUPO_DESCRIPCIONColumnName = "GRUPO_DESCRIPCION";
		public const string SUBGRUPO_DESCRIPCIONColumnName = "SUBGRUPO_DESCRIPCION";
		public const string PRESENTACION_DESCRIPCIONColumnName = "PRESENTACION_DESCRIPCION";
		public const string EMPAQUE_DESCRIPCIONColumnName = "EMPAQUE_DESCRIPCION";
		public const string COLOR_DESCRIPCIONColumnName = "COLOR_DESCRIPCION";
		public const string TALLE_DESCRIPCIONColumnName = "TALLE_DESCRIPCION";
		public const string FAMILIA_CODIGOColumnName = "FAMILIA_CODIGO";
		public const string GRUPO_CODIGOColumnName = "GRUPO_CODIGO";
		public const string SUBGRUPO_CODIGOColumnName = "SUBGRUPO_CODIGO";
		public const string FAMILIA_ORDENColumnName = "FAMILIA_ORDEN";
		public const string GRUPO_ORDENColumnName = "GRUPO_ORDEN";
		public const string SUBGRUPO_ORDENColumnName = "SUBGRUPO_ORDEN";
		public const string ES_TRAZABLEColumnName = "ES_TRAZABLE";
		public const string ES_USADOColumnName = "ES_USADO";
		public const string ES_DANHADOColumnName = "ES_DANHADO";
		public const string PARA_VENTAColumnName = "PARA_VENTA";
		public const string ES_COMBOColumnName = "ES_COMBO";
		public const string UNIDAD_MEDIDA_DESCRIPCIONColumnName = "UNIDAD_MEDIDA_DESCRIPCION";
		public const string ARTICULO_LINEA_IDColumnName = "ARTICULO_LINEA_ID";
		public const string ARTICULO_LINEA_NOMBREColumnName = "ARTICULO_LINEA_NOMBRE";
		public const string PROCEDENCIAColumnName = "PROCEDENCIA";
		public const string PROCEDENCIA_GENTILICIOColumnName = "PROCEDENCIA_GENTILICIO";
		public const string GENEROColumnName = "GENERO";
		public const string ARTICULO_PADRE_IDColumnName = "ARTICULO_PADRE_ID";
		public const string ES_COMBO_ABIERTOColumnName = "ES_COMBO_ABIERTO";
		public const string ARTICULO_PADRE_NOMBREColumnName = "ARTICULO_PADRE_NOMBRE";
		public const string ARTICULO_PADRE_CODIGOColumnName = "ARTICULO_PADRE_CODIGO";
		public const string ARTICULO_MARCA_IDColumnName = "ARTICULO_MARCA_ID";
		public const string ARTICULO_MARCA_NOMBREColumnName = "ARTICULO_MARCA_NOMBRE";
		public const string ULTIMO_INGRESO_STOCK_FECHAColumnName = "ULTIMO_INGRESO_STOCK_FECHA";
		public const string EXISTENCIA_TOTALColumnName = "EXISTENCIA_TOTAL";
		public const string ES_MODIFICABLEColumnName = "ES_MODIFICABLE";
		public const string RECARGO_FINANCIEROColumnName = "RECARGO_FINANCIERO";
		public const string CONTROLAR_PRECIOColumnName = "CONTROLAR_PRECIO";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string TIPO_NOTA_CREDITO_IDColumnName = "TIPO_NOTA_CREDITO_ID";
		public const string COSTO_BASE_MONTOColumnName = "COSTO_BASE_MONTO";
		public const string COSTO_BASE_MONEDA_IDColumnName = "COSTO_BASE_MONEDA_ID";
		public const string COSTO_BASE_COTIZACIONColumnName = "COSTO_BASE_COTIZACION";
		public const string CENTRO_COSTO_IDColumnName = "CENTRO_COSTO_ID";
		public const string ES_OBSOLETOColumnName = "ES_OBSOLETO";
		public const string ES_COMBO_REPRESENTATIVOColumnName = "ES_COMBO_REPRESENTATIVO";
		public const string IMAGEN_PATH_TMPColumnName = "IMAGEN_PATH_TMP";
		public const string COSTO_PPPColumnName = "COSTO_PPP";
		public const string FECHA_CIERREColumnName = "FECHA_CIERRE";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string RETENCIONColumnName = "RETENCION";
		public const string CANTIDAD_MINIMAColumnName = "CANTIDAD_MINIMA";
		public const string CANTIDAD_MAXIMAColumnName = "CANTIDAD_MAXIMA";
		public const string CANTIDAD_MAYORISTAColumnName = "CANTIDAD_MAYORISTA";
		public const string UNIDAD_MEDIDA_CONTROLColumnName = "UNIDAD_MEDIDA_CONTROL";
		public const string PARA_COMPRAColumnName = "PARA_COMPRA";
		public const string ES_FORMULAColumnName = "ES_FORMULA";
		public const string TIPO_FORMULAColumnName = "TIPO_FORMULA";
		public const string AUTONUMERACIONES_IDColumnName = "AUTONUMERACIONES_ID";
		public const string CANTIDAD_MINIMA_PRODUCCIONColumnName = "CANTIDAD_MINIMA_PRODUCCION";
		public const string CANTIDAD_MAXIMA_PRODUCCIONColumnName = "CANTIDAD_MAXIMA_PRODUCCION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ARTICULOS_INFO_COMPLETACollection_Base(CBAV2 db)
		{
			_db = db;
		}

		/// <summary>
		/// Gets the database object that this view belongs to.
		///	</summary>
		///	<value>The <see cref="CBAV2"/> object.</value>
		protected CBAV2 Database
		{
			get { return _db; }
		}

		/// <summary>
		/// Gets an array of all records from the <c>ARTICULOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="ARTICULOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual ARTICULOS_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ARTICULOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ARTICULOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ARTICULOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ARTICULOS_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ARTICULOS_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ARTICULOS_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ARTICULOS_INFO_COMPLETARow"/> objects.</returns>
		public ARTICULOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example:
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <param name="startIndex">The index of the first record to return.</param>
		/// <param name="length">The number of records to return.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>An array of <see cref="ARTICULOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual ARTICULOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
							int startIndex, int length, ref int totalRecordCount)
		{
			using(IDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object filled with data that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: "FirstName='Smith' AND Zip=75038".</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: "LastName ASC, FirstName ASC".</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetAsDataTable(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsDataTable(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object filled with data that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: "FirstName='Smith' AND Zip=75038".</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: "LastName ASC, FirstName ASC".</param>
		/// <param name="startIndex">The index of the first record to return.</param>
		/// <param name="length">The number of records to return.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAsDataTable(string whereSql, string orderBySql,
							int startIndex, int length, ref int totalRecordCount)
		{
			using(IDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
			{
				return MapRecordsToDataTable(reader, startIndex, length, ref totalRecordCount);
			}
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object for the specified search criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: "FirstName='Smith' AND Zip=75038".</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: "LastName ASC, FirstName ASC".</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetCommand(string whereSql, string orderBySql)
		{
			            
			string sql = "SELECT * FROM TRC.ARTICULOS_INFO_COMPLETA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Reads data using the specified command and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>An array of <see cref="ARTICULOS_INFO_COMPLETARow"/> objects.</returns>
		protected ARTICULOS_INFO_COMPLETARow[] MapRecords(IDbCommand command)
		{
			using(IDataReader reader = _db.ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
		/// <returns>An array of <see cref="ARTICULOS_INFO_COMPLETARow"/> objects.</returns>
		protected ARTICULOS_INFO_COMPLETARow[] MapRecords(IDataReader reader)
		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
		/// <param name="startIndex">The index of the first record to map.</param>
		/// <param name="length">The number of records to map.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>An array of <see cref="ARTICULOS_INFO_COMPLETARow"/> objects.</returns>
		protected virtual ARTICULOS_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int region_idColumnIndex = reader.GetOrdinal("REGION_ID");
			int codigo_empresaColumnIndex = reader.GetOrdinal("CODIGO_EMPRESA");
			int codigo_proveedorColumnIndex = reader.GetOrdinal("CODIGO_PROVEEDOR");
			int familia_idColumnIndex = reader.GetOrdinal("FAMILIA_ID");
			int grupo_idColumnIndex = reader.GetOrdinal("GRUPO_ID");
			int subgrupo_idColumnIndex = reader.GetOrdinal("SUBGRUPO_ID");
			int codigo_barras_empresaColumnIndex = reader.GetOrdinal("CODIGO_BARRAS_EMPRESA");
			int codigo_barras_proveedorColumnIndex = reader.GetOrdinal("CODIGO_BARRAS_PROVEEDOR");
			int descripcion_internaColumnIndex = reader.GetOrdinal("DESCRIPCION_INTERNA");
			int descripcion_impresionColumnIndex = reader.GetOrdinal("DESCRIPCION_IMPRESION");
			int descripcion_catalogoColumnIndex = reader.GetOrdinal("DESCRIPCION_CATALOGO");
			int descripcion_proveedorColumnIndex = reader.GetOrdinal("DESCRIPCION_PROVEEDOR");
			int descripcion_a_utilizarColumnIndex = reader.GetOrdinal("DESCRIPCION_A_UTILIZAR");
			int descripcion_sin_codigoColumnIndex = reader.GetOrdinal("DESCRIPCION_SIN_CODIGO");
			int codigo_presentacion_idColumnIndex = reader.GetOrdinal("CODIGO_PRESENTACION_ID");
			int codigo_empaque_idColumnIndex = reader.GetOrdinal("CODIGO_EMPAQUE_ID");
			int codigo_color_idColumnIndex = reader.GetOrdinal("CODIGO_COLOR_ID");
			int codigo_talle_idColumnIndex = reader.GetOrdinal("CODIGO_TALLE_ID");
			int codigo_balanzaColumnIndex = reader.GetOrdinal("CODIGO_BALANZA");
			int codigo_catalogo_proveedorColumnIndex = reader.GetOrdinal("CODIGO_CATALOGO_PROVEEDOR");
			int proveedor_razon_socialColumnIndex = reader.GetOrdinal("PROVEEDOR_RAZON_SOCIAL");
			int importadoColumnIndex = reader.GetOrdinal("IMPORTADO");
			int produccion_internaColumnIndex = reader.GetOrdinal("PRODUCCION_INTERNA");
			int no_reponerColumnIndex = reader.GetOrdinal("NO_REPONER");
			int unidad_medida_idColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_ID");
			int factor_conversion_kgColumnIndex = reader.GetOrdinal("FACTOR_CONVERSION_KG");
			int factor_conversion_mColumnIndex = reader.GetOrdinal("FACTOR_CONVERSION_M");
			int cantidad_por_cajaColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int impuesto_compra_idColumnIndex = reader.GetOrdinal("IMPUESTO_COMPRA_ID");
			int servicioColumnIndex = reader.GetOrdinal("SERVICIO");
			int combo_idColumnIndex = reader.GetOrdinal("COMBO_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int ingreso_aprobadoColumnIndex = reader.GetOrdinal("INGRESO_APROBADO");
			int usuario_aprobacion_idColumnIndex = reader.GetOrdinal("USUARIO_APROBACION_ID");
			int fecha_aprobacionColumnIndex = reader.GetOrdinal("FECHA_APROBACION");
			int porcentaje_precio_padreColumnIndex = reader.GetOrdinal("PORCENTAJE_PRECIO_PADRE");
			int monto_precio_padreColumnIndex = reader.GetOrdinal("MONTO_PRECIO_PADRE");
			int impuesto_descripcionColumnIndex = reader.GetOrdinal("IMPUESTO_DESCRIPCION");
			int impuesto_compra_descripcionColumnIndex = reader.GetOrdinal("IMPUESTO_COMPRA_DESCRIPCION");
			int familia_descripcionColumnIndex = reader.GetOrdinal("FAMILIA_DESCRIPCION");
			int grupo_descripcionColumnIndex = reader.GetOrdinal("GRUPO_DESCRIPCION");
			int subgrupo_descripcionColumnIndex = reader.GetOrdinal("SUBGRUPO_DESCRIPCION");
			int presentacion_descripcionColumnIndex = reader.GetOrdinal("PRESENTACION_DESCRIPCION");
			int empaque_descripcionColumnIndex = reader.GetOrdinal("EMPAQUE_DESCRIPCION");
			int color_descripcionColumnIndex = reader.GetOrdinal("COLOR_DESCRIPCION");
			int talle_descripcionColumnIndex = reader.GetOrdinal("TALLE_DESCRIPCION");
			int familia_codigoColumnIndex = reader.GetOrdinal("FAMILIA_CODIGO");
			int grupo_codigoColumnIndex = reader.GetOrdinal("GRUPO_CODIGO");
			int subgrupo_codigoColumnIndex = reader.GetOrdinal("SUBGRUPO_CODIGO");
			int familia_ordenColumnIndex = reader.GetOrdinal("FAMILIA_ORDEN");
			int grupo_ordenColumnIndex = reader.GetOrdinal("GRUPO_ORDEN");
			int subgrupo_ordenColumnIndex = reader.GetOrdinal("SUBGRUPO_ORDEN");
			int es_trazableColumnIndex = reader.GetOrdinal("ES_TRAZABLE");
			int es_usadoColumnIndex = reader.GetOrdinal("ES_USADO");
			int es_danhadoColumnIndex = reader.GetOrdinal("ES_DANHADO");
			int para_ventaColumnIndex = reader.GetOrdinal("PARA_VENTA");
			int es_comboColumnIndex = reader.GetOrdinal("ES_COMBO");
			int unidad_medida_descripcionColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_DESCRIPCION");
			int articulo_linea_idColumnIndex = reader.GetOrdinal("ARTICULO_LINEA_ID");
			int articulo_linea_nombreColumnIndex = reader.GetOrdinal("ARTICULO_LINEA_NOMBRE");
			int procedenciaColumnIndex = reader.GetOrdinal("PROCEDENCIA");
			int procedencia_gentilicioColumnIndex = reader.GetOrdinal("PROCEDENCIA_GENTILICIO");
			int generoColumnIndex = reader.GetOrdinal("GENERO");
			int articulo_padre_idColumnIndex = reader.GetOrdinal("ARTICULO_PADRE_ID");
			int es_combo_abiertoColumnIndex = reader.GetOrdinal("ES_COMBO_ABIERTO");
			int articulo_padre_nombreColumnIndex = reader.GetOrdinal("ARTICULO_PADRE_NOMBRE");
			int articulo_padre_codigoColumnIndex = reader.GetOrdinal("ARTICULO_PADRE_CODIGO");
			int articulo_marca_idColumnIndex = reader.GetOrdinal("ARTICULO_MARCA_ID");
			int articulo_marca_nombreColumnIndex = reader.GetOrdinal("ARTICULO_MARCA_NOMBRE");
			int ultimo_ingreso_stock_fechaColumnIndex = reader.GetOrdinal("ULTIMO_INGRESO_STOCK_FECHA");
			int existencia_totalColumnIndex = reader.GetOrdinal("EXISTENCIA_TOTAL");
			int es_modificableColumnIndex = reader.GetOrdinal("ES_MODIFICABLE");
			int recargo_financieroColumnIndex = reader.GetOrdinal("RECARGO_FINANCIERO");
			int controlar_precioColumnIndex = reader.GetOrdinal("CONTROLAR_PRECIO");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int tipo_nota_credito_idColumnIndex = reader.GetOrdinal("TIPO_NOTA_CREDITO_ID");
			int costo_base_montoColumnIndex = reader.GetOrdinal("COSTO_BASE_MONTO");
			int costo_base_moneda_idColumnIndex = reader.GetOrdinal("COSTO_BASE_MONEDA_ID");
			int costo_base_cotizacionColumnIndex = reader.GetOrdinal("COSTO_BASE_COTIZACION");
			int centro_costo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_ID");
			int es_obsoletoColumnIndex = reader.GetOrdinal("ES_OBSOLETO");
			int es_combo_representativoColumnIndex = reader.GetOrdinal("ES_COMBO_REPRESENTATIVO");
			int imagen_path_tmpColumnIndex = reader.GetOrdinal("IMAGEN_PATH_TMP");
			int costo_pppColumnIndex = reader.GetOrdinal("COSTO_PPP");
			int fecha_cierreColumnIndex = reader.GetOrdinal("FECHA_CIERRE");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int retencionColumnIndex = reader.GetOrdinal("RETENCION");
			int cantidad_minimaColumnIndex = reader.GetOrdinal("CANTIDAD_MINIMA");
			int cantidad_maximaColumnIndex = reader.GetOrdinal("CANTIDAD_MAXIMA");
			int cantidad_mayoristaColumnIndex = reader.GetOrdinal("CANTIDAD_MAYORISTA");
			int unidad_medida_controlColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_CONTROL");
			int para_compraColumnIndex = reader.GetOrdinal("PARA_COMPRA");
			int es_formulaColumnIndex = reader.GetOrdinal("ES_FORMULA");
			int tipo_formulaColumnIndex = reader.GetOrdinal("TIPO_FORMULA");
			int autonumeraciones_idColumnIndex = reader.GetOrdinal("AUTONUMERACIONES_ID");
			int cantidad_minima_produccionColumnIndex = reader.GetOrdinal("CANTIDAD_MINIMA_PRODUCCION");
			int cantidad_maxima_produccionColumnIndex = reader.GetOrdinal("CANTIDAD_MAXIMA_PRODUCCION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ARTICULOS_INFO_COMPLETARow record = new ARTICULOS_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(region_idColumnIndex))
						record.REGION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(region_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_empresaColumnIndex))
						record.CODIGO_EMPRESA = Convert.ToString(reader.GetValue(codigo_empresaColumnIndex));
					if(!reader.IsDBNull(codigo_proveedorColumnIndex))
						record.CODIGO_PROVEEDOR = Convert.ToString(reader.GetValue(codigo_proveedorColumnIndex));
					if(!reader.IsDBNull(familia_idColumnIndex))
						record.FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(grupo_idColumnIndex))
						record.GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(subgrupo_idColumnIndex))
						record.SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(subgrupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_barras_empresaColumnIndex))
						record.CODIGO_BARRAS_EMPRESA = Convert.ToString(reader.GetValue(codigo_barras_empresaColumnIndex));
					if(!reader.IsDBNull(codigo_barras_proveedorColumnIndex))
						record.CODIGO_BARRAS_PROVEEDOR = Convert.ToString(reader.GetValue(codigo_barras_proveedorColumnIndex));
					if(!reader.IsDBNull(descripcion_internaColumnIndex))
						record.DESCRIPCION_INTERNA = Convert.ToString(reader.GetValue(descripcion_internaColumnIndex));
					if(!reader.IsDBNull(descripcion_impresionColumnIndex))
						record.DESCRIPCION_IMPRESION = Convert.ToString(reader.GetValue(descripcion_impresionColumnIndex));
					if(!reader.IsDBNull(descripcion_catalogoColumnIndex))
						record.DESCRIPCION_CATALOGO = Convert.ToString(reader.GetValue(descripcion_catalogoColumnIndex));
					if(!reader.IsDBNull(descripcion_proveedorColumnIndex))
						record.DESCRIPCION_PROVEEDOR = Convert.ToString(reader.GetValue(descripcion_proveedorColumnIndex));
					if(!reader.IsDBNull(descripcion_a_utilizarColumnIndex))
						record.DESCRIPCION_A_UTILIZAR = Convert.ToString(reader.GetValue(descripcion_a_utilizarColumnIndex));
					if(!reader.IsDBNull(descripcion_sin_codigoColumnIndex))
						record.DESCRIPCION_SIN_CODIGO = Convert.ToString(reader.GetValue(descripcion_sin_codigoColumnIndex));
					if(!reader.IsDBNull(codigo_presentacion_idColumnIndex))
						record.CODIGO_PRESENTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(codigo_presentacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_empaque_idColumnIndex))
						record.CODIGO_EMPAQUE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(codigo_empaque_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_color_idColumnIndex))
						record.CODIGO_COLOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(codigo_color_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_talle_idColumnIndex))
						record.CODIGO_TALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(codigo_talle_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_balanzaColumnIndex))
						record.CODIGO_BALANZA = Convert.ToString(reader.GetValue(codigo_balanzaColumnIndex));
					if(!reader.IsDBNull(codigo_catalogo_proveedorColumnIndex))
						record.CODIGO_CATALOGO_PROVEEDOR = Convert.ToString(reader.GetValue(codigo_catalogo_proveedorColumnIndex));
					if(!reader.IsDBNull(proveedor_razon_socialColumnIndex))
						record.PROVEEDOR_RAZON_SOCIAL = Convert.ToString(reader.GetValue(proveedor_razon_socialColumnIndex));
					record.IMPORTADO = Convert.ToString(reader.GetValue(importadoColumnIndex));
					record.PRODUCCION_INTERNA = Convert.ToString(reader.GetValue(produccion_internaColumnIndex));
					record.NO_REPONER = Convert.ToString(reader.GetValue(no_reponerColumnIndex));
					record.UNIDAD_MEDIDA_ID = Convert.ToString(reader.GetValue(unidad_medida_idColumnIndex));
					if(!reader.IsDBNull(factor_conversion_kgColumnIndex))
						record.FACTOR_CONVERSION_KG = Math.Round(Convert.ToDecimal(reader.GetValue(factor_conversion_kgColumnIndex)), 9);
					if(!reader.IsDBNull(factor_conversion_mColumnIndex))
						record.FACTOR_CONVERSION_M = Math.Round(Convert.ToDecimal(reader.GetValue(factor_conversion_mColumnIndex)), 9);
					record.CANTIDAD_POR_CAJA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_cajaColumnIndex)), 9);
					record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					if(!reader.IsDBNull(impuesto_compra_idColumnIndex))
						record.IMPUESTO_COMPRA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_compra_idColumnIndex)), 9);
					record.SERVICIO = Convert.ToString(reader.GetValue(servicioColumnIndex));
					if(!reader.IsDBNull(combo_idColumnIndex))
						record.COMBO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(combo_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.INGRESO_APROBADO = Convert.ToString(reader.GetValue(ingreso_aprobadoColumnIndex));
					if(!reader.IsDBNull(usuario_aprobacion_idColumnIndex))
						record.USUARIO_APROBACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_aprobacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_aprobacionColumnIndex))
						record.FECHA_APROBACION = Convert.ToDateTime(reader.GetValue(fecha_aprobacionColumnIndex));
					if(!reader.IsDBNull(porcentaje_precio_padreColumnIndex))
						record.PORCENTAJE_PRECIO_PADRE = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_precio_padreColumnIndex)), 9);
					if(!reader.IsDBNull(monto_precio_padreColumnIndex))
						record.MONTO_PRECIO_PADRE = Math.Round(Convert.ToDecimal(reader.GetValue(monto_precio_padreColumnIndex)), 9);
					if(!reader.IsDBNull(impuesto_descripcionColumnIndex))
						record.IMPUESTO_DESCRIPCION = Convert.ToString(reader.GetValue(impuesto_descripcionColumnIndex));
					if(!reader.IsDBNull(impuesto_compra_descripcionColumnIndex))
						record.IMPUESTO_COMPRA_DESCRIPCION = Convert.ToString(reader.GetValue(impuesto_compra_descripcionColumnIndex));
					if(!reader.IsDBNull(familia_descripcionColumnIndex))
						record.FAMILIA_DESCRIPCION = Convert.ToString(reader.GetValue(familia_descripcionColumnIndex));
					if(!reader.IsDBNull(grupo_descripcionColumnIndex))
						record.GRUPO_DESCRIPCION = Convert.ToString(reader.GetValue(grupo_descripcionColumnIndex));
					if(!reader.IsDBNull(subgrupo_descripcionColumnIndex))
						record.SUBGRUPO_DESCRIPCION = Convert.ToString(reader.GetValue(subgrupo_descripcionColumnIndex));
					if(!reader.IsDBNull(presentacion_descripcionColumnIndex))
						record.PRESENTACION_DESCRIPCION = Convert.ToString(reader.GetValue(presentacion_descripcionColumnIndex));
					if(!reader.IsDBNull(empaque_descripcionColumnIndex))
						record.EMPAQUE_DESCRIPCION = Convert.ToString(reader.GetValue(empaque_descripcionColumnIndex));
					if(!reader.IsDBNull(color_descripcionColumnIndex))
						record.COLOR_DESCRIPCION = Convert.ToString(reader.GetValue(color_descripcionColumnIndex));
					if(!reader.IsDBNull(talle_descripcionColumnIndex))
						record.TALLE_DESCRIPCION = Convert.ToString(reader.GetValue(talle_descripcionColumnIndex));
					if(!reader.IsDBNull(familia_codigoColumnIndex))
						record.FAMILIA_CODIGO = Convert.ToString(reader.GetValue(familia_codigoColumnIndex));
					if(!reader.IsDBNull(grupo_codigoColumnIndex))
						record.GRUPO_CODIGO = Convert.ToString(reader.GetValue(grupo_codigoColumnIndex));
					if(!reader.IsDBNull(subgrupo_codigoColumnIndex))
						record.SUBGRUPO_CODIGO = Convert.ToString(reader.GetValue(subgrupo_codigoColumnIndex));
					if(!reader.IsDBNull(familia_ordenColumnIndex))
						record.FAMILIA_ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(familia_ordenColumnIndex)), 9);
					if(!reader.IsDBNull(grupo_ordenColumnIndex))
						record.GRUPO_ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(grupo_ordenColumnIndex)), 9);
					if(!reader.IsDBNull(subgrupo_ordenColumnIndex))
						record.SUBGRUPO_ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(subgrupo_ordenColumnIndex)), 9);
					record.ES_TRAZABLE = Convert.ToString(reader.GetValue(es_trazableColumnIndex));
					record.ES_USADO = Convert.ToString(reader.GetValue(es_usadoColumnIndex));
					record.ES_DANHADO = Convert.ToString(reader.GetValue(es_danhadoColumnIndex));
					record.PARA_VENTA = Convert.ToString(reader.GetValue(para_ventaColumnIndex));
					record.ES_COMBO = Convert.ToString(reader.GetValue(es_comboColumnIndex));
					if(!reader.IsDBNull(unidad_medida_descripcionColumnIndex))
						record.UNIDAD_MEDIDA_DESCRIPCION = Convert.ToString(reader.GetValue(unidad_medida_descripcionColumnIndex));
					if(!reader.IsDBNull(articulo_linea_idColumnIndex))
						record.ARTICULO_LINEA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_linea_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_linea_nombreColumnIndex))
						record.ARTICULO_LINEA_NOMBRE = Convert.ToString(reader.GetValue(articulo_linea_nombreColumnIndex));
					if(!reader.IsDBNull(procedenciaColumnIndex))
						record.PROCEDENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(procedenciaColumnIndex)), 9);
					if(!reader.IsDBNull(procedencia_gentilicioColumnIndex))
						record.PROCEDENCIA_GENTILICIO = Convert.ToString(reader.GetValue(procedencia_gentilicioColumnIndex));
					if(!reader.IsDBNull(generoColumnIndex))
						record.GENERO = Convert.ToString(reader.GetValue(generoColumnIndex));
					if(!reader.IsDBNull(articulo_padre_idColumnIndex))
						record.ARTICULO_PADRE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_padre_idColumnIndex)), 9);
					record.ES_COMBO_ABIERTO = Convert.ToString(reader.GetValue(es_combo_abiertoColumnIndex));
					if(!reader.IsDBNull(articulo_padre_nombreColumnIndex))
						record.ARTICULO_PADRE_NOMBRE = Convert.ToString(reader.GetValue(articulo_padre_nombreColumnIndex));
					if(!reader.IsDBNull(articulo_padre_codigoColumnIndex))
						record.ARTICULO_PADRE_CODIGO = Convert.ToString(reader.GetValue(articulo_padre_codigoColumnIndex));
					if(!reader.IsDBNull(articulo_marca_idColumnIndex))
						record.ARTICULO_MARCA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_marca_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_marca_nombreColumnIndex))
						record.ARTICULO_MARCA_NOMBRE = Convert.ToString(reader.GetValue(articulo_marca_nombreColumnIndex));
					if(!reader.IsDBNull(ultimo_ingreso_stock_fechaColumnIndex))
						record.ULTIMO_INGRESO_STOCK_FECHA = Convert.ToDateTime(reader.GetValue(ultimo_ingreso_stock_fechaColumnIndex));
					if(!reader.IsDBNull(existencia_totalColumnIndex))
						record.EXISTENCIA_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(existencia_totalColumnIndex)), 9);
					record.ES_MODIFICABLE = Convert.ToString(reader.GetValue(es_modificableColumnIndex));
					record.RECARGO_FINANCIERO = Convert.ToString(reader.GetValue(recargo_financieroColumnIndex));
					record.CONTROLAR_PRECIO = Convert.ToString(reader.GetValue(controlar_precioColumnIndex));
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_nota_credito_idColumnIndex))
						record.TIPO_NOTA_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_nota_credito_idColumnIndex)), 9);
					if(!reader.IsDBNull(costo_base_montoColumnIndex))
						record.COSTO_BASE_MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_base_montoColumnIndex)), 9);
					if(!reader.IsDBNull(costo_base_moneda_idColumnIndex))
						record.COSTO_BASE_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_base_moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(costo_base_cotizacionColumnIndex))
						record.COSTO_BASE_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(costo_base_cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(centro_costo_idColumnIndex))
						record.CENTRO_COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_idColumnIndex)), 9);
					record.ES_OBSOLETO = Convert.ToString(reader.GetValue(es_obsoletoColumnIndex));
					record.ES_COMBO_REPRESENTATIVO = Convert.ToString(reader.GetValue(es_combo_representativoColumnIndex));
					if(!reader.IsDBNull(imagen_path_tmpColumnIndex))
						record.IMAGEN_PATH_TMP = Convert.ToString(reader.GetValue(imagen_path_tmpColumnIndex));
					if(!reader.IsDBNull(costo_pppColumnIndex))
						record.COSTO_PPP = Math.Round(Convert.ToDecimal(reader.GetValue(costo_pppColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_cierreColumnIndex))
						record.FECHA_CIERRE = Convert.ToDateTime(reader.GetValue(fecha_cierreColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencionColumnIndex))
						record.RETENCION = Math.Round(Convert.ToDecimal(reader.GetValue(retencionColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_minimaColumnIndex))
						record.CANTIDAD_MINIMA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_minimaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_maximaColumnIndex))
						record.CANTIDAD_MAXIMA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_maximaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_mayoristaColumnIndex))
						record.CANTIDAD_MAYORISTA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_mayoristaColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_medida_controlColumnIndex))
						record.UNIDAD_MEDIDA_CONTROL = Convert.ToString(reader.GetValue(unidad_medida_controlColumnIndex));
					record.PARA_COMPRA = Convert.ToString(reader.GetValue(para_compraColumnIndex));
					record.ES_FORMULA = Convert.ToString(reader.GetValue(es_formulaColumnIndex));
					if(!reader.IsDBNull(tipo_formulaColumnIndex))
						record.TIPO_FORMULA = Convert.ToString(reader.GetValue(tipo_formulaColumnIndex));
					if(!reader.IsDBNull(autonumeraciones_idColumnIndex))
						record.AUTONUMERACIONES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeraciones_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_minima_produccionColumnIndex))
						record.CANTIDAD_MINIMA_PRODUCCION = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_minima_produccionColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_maxima_produccionColumnIndex))
						record.CANTIDAD_MAXIMA_PRODUCCION = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_maxima_produccionColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ARTICULOS_INFO_COMPLETARow[])(recordList.ToArray(typeof(ARTICULOS_INFO_COMPLETARow)));
		}

		/// <summary>
		/// Reads data using the specified command and returns 
		/// a filled <see cref="System.Data.DataTable"/> object.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected DataTable MapRecordsToDataTable(IDbCommand command)
		{
			using(IDataReader reader = _db.ExecuteReader(command))
			{
				return MapRecordsToDataTable(reader);
			}
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// a filled <see cref="System.Data.DataTable"/> object.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected DataTable MapRecordsToDataTable(IDataReader reader)
		{
			int totalRecordCount = 0;
			return MapRecordsToDataTable(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		
		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// a filled <see cref="System.Data.DataTable"/> object.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
		/// <param name="startIndex">The index of the first record to read.</param>
		/// <param name="length">The number of records to read.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable MapRecordsToDataTable(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int columnCount = reader.FieldCount;
			int ri = -startIndex;
			
			DataTable dataTable = CreateDataTable();
			dataTable.BeginLoadData();
			object[] values = new object[columnCount];

			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					reader.GetValues(values);
					dataTable.LoadDataRow(values, true);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}
			dataTable.EndLoadData();

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return dataTable;
		}

		/// <summary>
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ARTICULOS_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ARTICULOS_INFO_COMPLETARow"/> object.</returns>
		protected virtual ARTICULOS_INFO_COMPLETARow MapRow(DataRow row)
		{
			ARTICULOS_INFO_COMPLETARow mappedObject = new ARTICULOS_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "REGION_ID"
			dataColumn = dataTable.Columns["REGION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGION_ID = (decimal)row[dataColumn];
			// Column "CODIGO_EMPRESA"
			dataColumn = dataTable.Columns["CODIGO_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_EMPRESA = (string)row[dataColumn];
			// Column "CODIGO_PROVEEDOR"
			dataColumn = dataTable.Columns["CODIGO_PROVEEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_PROVEEDOR = (string)row[dataColumn];
			// Column "FAMILIA_ID"
			dataColumn = dataTable.Columns["FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_ID = (decimal)row[dataColumn];
			// Column "GRUPO_ID"
			dataColumn = dataTable.Columns["GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_ID = (decimal)row[dataColumn];
			// Column "SUBGRUPO_ID"
			dataColumn = dataTable.Columns["SUBGRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_ID = (decimal)row[dataColumn];
			// Column "CODIGO_BARRAS_EMPRESA"
			dataColumn = dataTable.Columns["CODIGO_BARRAS_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_BARRAS_EMPRESA = (string)row[dataColumn];
			// Column "CODIGO_BARRAS_PROVEEDOR"
			dataColumn = dataTable.Columns["CODIGO_BARRAS_PROVEEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_BARRAS_PROVEEDOR = (string)row[dataColumn];
			// Column "DESCRIPCION_INTERNA"
			dataColumn = dataTable.Columns["DESCRIPCION_INTERNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION_INTERNA = (string)row[dataColumn];
			// Column "DESCRIPCION_IMPRESION"
			dataColumn = dataTable.Columns["DESCRIPCION_IMPRESION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION_IMPRESION = (string)row[dataColumn];
			// Column "DESCRIPCION_CATALOGO"
			dataColumn = dataTable.Columns["DESCRIPCION_CATALOGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION_CATALOGO = (string)row[dataColumn];
			// Column "DESCRIPCION_PROVEEDOR"
			dataColumn = dataTable.Columns["DESCRIPCION_PROVEEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION_PROVEEDOR = (string)row[dataColumn];
			// Column "DESCRIPCION_A_UTILIZAR"
			dataColumn = dataTable.Columns["DESCRIPCION_A_UTILIZAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION_A_UTILIZAR = (string)row[dataColumn];
			// Column "DESCRIPCION_SIN_CODIGO"
			dataColumn = dataTable.Columns["DESCRIPCION_SIN_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION_SIN_CODIGO = (string)row[dataColumn];
			// Column "CODIGO_PRESENTACION_ID"
			dataColumn = dataTable.Columns["CODIGO_PRESENTACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_PRESENTACION_ID = (decimal)row[dataColumn];
			// Column "CODIGO_EMPAQUE_ID"
			dataColumn = dataTable.Columns["CODIGO_EMPAQUE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_EMPAQUE_ID = (decimal)row[dataColumn];
			// Column "CODIGO_COLOR_ID"
			dataColumn = dataTable.Columns["CODIGO_COLOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_COLOR_ID = (decimal)row[dataColumn];
			// Column "CODIGO_TALLE_ID"
			dataColumn = dataTable.Columns["CODIGO_TALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_TALLE_ID = (decimal)row[dataColumn];
			// Column "CODIGO_BALANZA"
			dataColumn = dataTable.Columns["CODIGO_BALANZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_BALANZA = (string)row[dataColumn];
			// Column "CODIGO_CATALOGO_PROVEEDOR"
			dataColumn = dataTable.Columns["CODIGO_CATALOGO_PROVEEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_CATALOGO_PROVEEDOR = (string)row[dataColumn];
			// Column "PROVEEDOR_RAZON_SOCIAL"
			dataColumn = dataTable.Columns["PROVEEDOR_RAZON_SOCIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_RAZON_SOCIAL = (string)row[dataColumn];
			// Column "IMPORTADO"
			dataColumn = dataTable.Columns["IMPORTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTADO = (string)row[dataColumn];
			// Column "PRODUCCION_INTERNA"
			dataColumn = dataTable.Columns["PRODUCCION_INTERNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRODUCCION_INTERNA = (string)row[dataColumn];
			// Column "NO_REPONER"
			dataColumn = dataTable.Columns["NO_REPONER"];
			if(!row.IsNull(dataColumn))
				mappedObject.NO_REPONER = (string)row[dataColumn];
			// Column "UNIDAD_MEDIDA_ID"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_ID = (string)row[dataColumn];
			// Column "FACTOR_CONVERSION_KG"
			dataColumn = dataTable.Columns["FACTOR_CONVERSION_KG"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTOR_CONVERSION_KG = (decimal)row[dataColumn];
			// Column "FACTOR_CONVERSION_M"
			dataColumn = dataTable.Columns["FACTOR_CONVERSION_M"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTOR_CONVERSION_M = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA = (decimal)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "IMPUESTO_COMPRA_ID"
			dataColumn = dataTable.Columns["IMPUESTO_COMPRA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_COMPRA_ID = (decimal)row[dataColumn];
			// Column "SERVICIO"
			dataColumn = dataTable.Columns["SERVICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SERVICIO = (string)row[dataColumn];
			// Column "COMBO_ID"
			dataColumn = dataTable.Columns["COMBO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMBO_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "INGRESO_APROBADO"
			dataColumn = dataTable.Columns["INGRESO_APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_APROBADO = (string)row[dataColumn];
			// Column "USUARIO_APROBACION_ID"
			dataColumn = dataTable.Columns["USUARIO_APROBACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_APROBACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_APROBACION"
			dataColumn = dataTable.Columns["FECHA_APROBACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_APROBACION = (System.DateTime)row[dataColumn];
			// Column "PORCENTAJE_PRECIO_PADRE"
			dataColumn = dataTable.Columns["PORCENTAJE_PRECIO_PADRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_PRECIO_PADRE = (decimal)row[dataColumn];
			// Column "MONTO_PRECIO_PADRE"
			dataColumn = dataTable.Columns["MONTO_PRECIO_PADRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_PRECIO_PADRE = (decimal)row[dataColumn];
			// Column "IMPUESTO_DESCRIPCION"
			dataColumn = dataTable.Columns["IMPUESTO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_DESCRIPCION = (string)row[dataColumn];
			// Column "IMPUESTO_COMPRA_DESCRIPCION"
			dataColumn = dataTable.Columns["IMPUESTO_COMPRA_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_COMPRA_DESCRIPCION = (string)row[dataColumn];
			// Column "FAMILIA_DESCRIPCION"
			dataColumn = dataTable.Columns["FAMILIA_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_DESCRIPCION = (string)row[dataColumn];
			// Column "GRUPO_DESCRIPCION"
			dataColumn = dataTable.Columns["GRUPO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_DESCRIPCION = (string)row[dataColumn];
			// Column "SUBGRUPO_DESCRIPCION"
			dataColumn = dataTable.Columns["SUBGRUPO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_DESCRIPCION = (string)row[dataColumn];
			// Column "PRESENTACION_DESCRIPCION"
			dataColumn = dataTable.Columns["PRESENTACION_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRESENTACION_DESCRIPCION = (string)row[dataColumn];
			// Column "EMPAQUE_DESCRIPCION"
			dataColumn = dataTable.Columns["EMPAQUE_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPAQUE_DESCRIPCION = (string)row[dataColumn];
			// Column "COLOR_DESCRIPCION"
			dataColumn = dataTable.Columns["COLOR_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COLOR_DESCRIPCION = (string)row[dataColumn];
			// Column "TALLE_DESCRIPCION"
			dataColumn = dataTable.Columns["TALLE_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TALLE_DESCRIPCION = (string)row[dataColumn];
			// Column "FAMILIA_CODIGO"
			dataColumn = dataTable.Columns["FAMILIA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_CODIGO = (string)row[dataColumn];
			// Column "GRUPO_CODIGO"
			dataColumn = dataTable.Columns["GRUPO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_CODIGO = (string)row[dataColumn];
			// Column "SUBGRUPO_CODIGO"
			dataColumn = dataTable.Columns["SUBGRUPO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_CODIGO = (string)row[dataColumn];
			// Column "FAMILIA_ORDEN"
			dataColumn = dataTable.Columns["FAMILIA_ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_ORDEN = (decimal)row[dataColumn];
			// Column "GRUPO_ORDEN"
			dataColumn = dataTable.Columns["GRUPO_ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_ORDEN = (decimal)row[dataColumn];
			// Column "SUBGRUPO_ORDEN"
			dataColumn = dataTable.Columns["SUBGRUPO_ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_ORDEN = (decimal)row[dataColumn];
			// Column "ES_TRAZABLE"
			dataColumn = dataTable.Columns["ES_TRAZABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_TRAZABLE = (string)row[dataColumn];
			// Column "ES_USADO"
			dataColumn = dataTable.Columns["ES_USADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_USADO = (string)row[dataColumn];
			// Column "ES_DANHADO"
			dataColumn = dataTable.Columns["ES_DANHADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_DANHADO = (string)row[dataColumn];
			// Column "PARA_VENTA"
			dataColumn = dataTable.Columns["PARA_VENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PARA_VENTA = (string)row[dataColumn];
			// Column "ES_COMBO"
			dataColumn = dataTable.Columns["ES_COMBO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_COMBO = (string)row[dataColumn];
			// Column "UNIDAD_MEDIDA_DESCRIPCION"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_DESCRIPCION = (string)row[dataColumn];
			// Column "ARTICULO_LINEA_ID"
			dataColumn = dataTable.Columns["ARTICULO_LINEA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_LINEA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_LINEA_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULO_LINEA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_LINEA_NOMBRE = (string)row[dataColumn];
			// Column "PROCEDENCIA"
			dataColumn = dataTable.Columns["PROCEDENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCEDENCIA = (decimal)row[dataColumn];
			// Column "PROCEDENCIA_GENTILICIO"
			dataColumn = dataTable.Columns["PROCEDENCIA_GENTILICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCEDENCIA_GENTILICIO = (string)row[dataColumn];
			// Column "GENERO"
			dataColumn = dataTable.Columns["GENERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERO = (string)row[dataColumn];
			// Column "ARTICULO_PADRE_ID"
			dataColumn = dataTable.Columns["ARTICULO_PADRE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_PADRE_ID = (decimal)row[dataColumn];
			// Column "ES_COMBO_ABIERTO"
			dataColumn = dataTable.Columns["ES_COMBO_ABIERTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_COMBO_ABIERTO = (string)row[dataColumn];
			// Column "ARTICULO_PADRE_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULO_PADRE_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_PADRE_NOMBRE = (string)row[dataColumn];
			// Column "ARTICULO_PADRE_CODIGO"
			dataColumn = dataTable.Columns["ARTICULO_PADRE_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_PADRE_CODIGO = (string)row[dataColumn];
			// Column "ARTICULO_MARCA_ID"
			dataColumn = dataTable.Columns["ARTICULO_MARCA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_MARCA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_MARCA_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULO_MARCA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_MARCA_NOMBRE = (string)row[dataColumn];
			// Column "ULTIMO_INGRESO_STOCK_FECHA"
			dataColumn = dataTable.Columns["ULTIMO_INGRESO_STOCK_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ULTIMO_INGRESO_STOCK_FECHA = (System.DateTime)row[dataColumn];
			// Column "EXISTENCIA_TOTAL"
			dataColumn = dataTable.Columns["EXISTENCIA_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.EXISTENCIA_TOTAL = (decimal)row[dataColumn];
			// Column "ES_MODIFICABLE"
			dataColumn = dataTable.Columns["ES_MODIFICABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_MODIFICABLE = (string)row[dataColumn];
			// Column "RECARGO_FINANCIERO"
			dataColumn = dataTable.Columns["RECARGO_FINANCIERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECARGO_FINANCIERO = (string)row[dataColumn];
			// Column "CONTROLAR_PRECIO"
			dataColumn = dataTable.Columns["CONTROLAR_PRECIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTROLAR_PRECIO = (string)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "TIPO_NOTA_CREDITO_ID"
			dataColumn = dataTable.Columns["TIPO_NOTA_CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_NOTA_CREDITO_ID = (decimal)row[dataColumn];
			// Column "COSTO_BASE_MONTO"
			dataColumn = dataTable.Columns["COSTO_BASE_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_BASE_MONTO = (decimal)row[dataColumn];
			// Column "COSTO_BASE_MONEDA_ID"
			dataColumn = dataTable.Columns["COSTO_BASE_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_BASE_MONEDA_ID = (decimal)row[dataColumn];
			// Column "COSTO_BASE_COTIZACION"
			dataColumn = dataTable.Columns["COSTO_BASE_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_BASE_COTIZACION = (decimal)row[dataColumn];
			// Column "CENTRO_COSTO_ID"
			dataColumn = dataTable.Columns["CENTRO_COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_ID = (decimal)row[dataColumn];
			// Column "ES_OBSOLETO"
			dataColumn = dataTable.Columns["ES_OBSOLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_OBSOLETO = (string)row[dataColumn];
			// Column "ES_COMBO_REPRESENTATIVO"
			dataColumn = dataTable.Columns["ES_COMBO_REPRESENTATIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_COMBO_REPRESENTATIVO = (string)row[dataColumn];
			// Column "IMAGEN_PATH_TMP"
			dataColumn = dataTable.Columns["IMAGEN_PATH_TMP"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMAGEN_PATH_TMP = (string)row[dataColumn];
			// Column "COSTO_PPP"
			dataColumn = dataTable.Columns["COSTO_PPP"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_PPP = (decimal)row[dataColumn];
			// Column "FECHA_CIERRE"
			dataColumn = dataTable.Columns["FECHA_CIERRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CIERRE = (System.DateTime)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "RETENCION"
			dataColumn = dataTable.Columns["RETENCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION = (decimal)row[dataColumn];
			// Column "CANTIDAD_MINIMA"
			dataColumn = dataTable.Columns["CANTIDAD_MINIMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MINIMA = (decimal)row[dataColumn];
			// Column "CANTIDAD_MAXIMA"
			dataColumn = dataTable.Columns["CANTIDAD_MAXIMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MAXIMA = (decimal)row[dataColumn];
			// Column "CANTIDAD_MAYORISTA"
			dataColumn = dataTable.Columns["CANTIDAD_MAYORISTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MAYORISTA = (decimal)row[dataColumn];
			// Column "UNIDAD_MEDIDA_CONTROL"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_CONTROL"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_CONTROL = (string)row[dataColumn];
			// Column "PARA_COMPRA"
			dataColumn = dataTable.Columns["PARA_COMPRA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PARA_COMPRA = (string)row[dataColumn];
			// Column "ES_FORMULA"
			dataColumn = dataTable.Columns["ES_FORMULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_FORMULA = (string)row[dataColumn];
			// Column "TIPO_FORMULA"
			dataColumn = dataTable.Columns["TIPO_FORMULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_FORMULA = (string)row[dataColumn];
			// Column "AUTONUMERACIONES_ID"
			dataColumn = dataTable.Columns["AUTONUMERACIONES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACIONES_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_MINIMA_PRODUCCION"
			dataColumn = dataTable.Columns["CANTIDAD_MINIMA_PRODUCCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MINIMA_PRODUCCION = (decimal)row[dataColumn];
			// Column "CANTIDAD_MAXIMA_PRODUCCION"
			dataColumn = dataTable.Columns["CANTIDAD_MAXIMA_PRODUCCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MAXIMA_PRODUCCION = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ARTICULOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ARTICULOS_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REGION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_EMPRESA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_PROVEEDOR", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FAMILIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUBGRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_BARRAS_EMPRESA", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_BARRAS_PROVEEDOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_INTERNA", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_IMPRESION", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_CATALOGO", typeof(string));
			dataColumn.MaxLength = 1000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_PROVEEDOR", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_A_UTILIZAR", typeof(string));
			dataColumn.MaxLength = 953;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_SIN_CODIGO", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_PRESENTACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_EMPAQUE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_COLOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_TALLE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_BALANZA", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_CATALOGO_PROVEEDOR", typeof(string));
			dataColumn.MaxLength = 4000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_RAZON_SOCIAL", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPORTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRODUCCION_INTERNA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NO_REPONER", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTOR_CONVERSION_KG", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTOR_CONVERSION_M", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_COMPRA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SERVICIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COMBO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_APROBADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_APROBACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_APROBACION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_PRECIO_PADRE", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_PRECIO_PADRE", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_COMPRA_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FAMILIA_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUBGRUPO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRESENTACION_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMPAQUE_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COLOR_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TALLE_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FAMILIA_CODIGO", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_CODIGO", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUBGRUPO_CODIGO", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FAMILIA_ORDEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_ORDEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUBGRUPO_ORDEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_TRAZABLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_USADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_DANHADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PARA_VENTA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_COMBO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_LINEA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_LINEA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROCEDENCIA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROCEDENCIA_GENTILICIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GENERO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_PADRE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_COMBO_ABIERTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_PADRE_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_PADRE_CODIGO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_MARCA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_MARCA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ULTIMO_INGRESO_STOCK_FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EXISTENCIA_TOTAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_MODIFICABLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RECARGO_FINANCIERO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTROLAR_PRECIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_NOTA_CREDITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_BASE_MONTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_BASE_MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_BASE_COTIZACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_OBSOLETO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_COMBO_REPRESENTATIVO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMAGEN_PATH_TMP", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_PPP", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_CIERRE", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RETENCION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MINIMA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MAXIMA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MAYORISTA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_CONTROL", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PARA_COMPRA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_FORMULA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_FORMULA", typeof(string));
			dataColumn.MaxLength = 12;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACIONES_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MINIMA_PRODUCCION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MAXIMA_PRODUCCION", typeof(decimal));
			dataColumn.ReadOnly = true;
			return dataTable;
		}
		
		/// <summary>
		/// Adds a new parameter to the specified command.
		/// </summary>
		/// <param name="cmd">The <see cref="System.Data.IDbCommand"/> object to add the parameter to.</param>
		/// <param name="paramName">The name of the parameter.</param>
		/// <param name="value">The value of the parameter.</param>
		/// <returns>A reference to the added parameter.</returns>
		protected virtual IDbDataParameter AddParameter(IDbCommand cmd, string paramName, object value)
		{
			IDbDataParameter parameter;
			switch(paramName)
			{
				case "ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REGION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_PROVEEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUBGRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO_BARRAS_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_BARRAS_PROVEEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION_INTERNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION_IMPRESION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION_CATALOGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION_PROVEEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION_A_UTILIZAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION_SIN_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_PRESENTACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO_EMPAQUE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO_COLOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO_TALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO_BALANZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_CATALOGO_PROVEEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_RAZON_SOCIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPORTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PRODUCCION_INTERNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NO_REPONER":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "UNIDAD_MEDIDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTOR_CONVERSION_KG":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTOR_CONVERSION_M":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_COMPRA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SERVICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "COMBO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "INGRESO_APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_APROBACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_APROBACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PORCENTAJE_PRECIO_PADRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_PRECIO_PADRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPUESTO_COMPRA_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FAMILIA_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GRUPO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUBGRUPO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRESENTACION_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMPAQUE_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COLOR_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TALLE_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FAMILIA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GRUPO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUBGRUPO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FAMILIA_ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GRUPO_ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUBGRUPO_ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_TRAZABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_USADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_DANHADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PARA_VENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_COMBO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "UNIDAD_MEDIDA_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_LINEA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_LINEA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROCEDENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROCEDENCIA_GENTILICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GENERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ARTICULO_PADRE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_COMBO_ABIERTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ARTICULO_PADRE_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_PADRE_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_MARCA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_MARCA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ULTIMO_INGRESO_STOCK_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "EXISTENCIA_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_MODIFICABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "RECARGO_FINANCIERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONTROLAR_PRECIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_NOTA_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_BASE_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_BASE_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_BASE_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CENTRO_COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_OBSOLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_COMBO_REPRESENTATIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "IMAGEN_PATH_TMP":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COSTO_PPP":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CIERRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MINIMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MAXIMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MAYORISTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_MEDIDA_CONTROL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PARA_COMPRA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_FORMULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TIPO_FORMULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACIONES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MINIMA_PRODUCCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MAXIMA_PRODUCCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ARTICULOS_INFO_COMPLETACollection_Base class
}  // End of namespace
